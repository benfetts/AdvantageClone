Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingWorksheetMediaInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingWorksheetMediaInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlMedia_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Media = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemMediaCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Media = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemMediaCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID = New DevComponents.DotNetBar.TabControlPanel()
            Me.BillingBatchChooserControl_Media = New AdvantageFramework.WinForm.Presentation.Controls.BillingBatchChooserControl()
            Me.TabItemMediaCriteria_BillingBatchIDTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.BillingWorksheetMediaControl = New AdvantageFramework.WinForm.Presentation.Controls.BillingWorksheetMediaControl()
            Me.TabItemMediaCriteria_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlMedia_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlMedia_Criteria.SuspendLayout()
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.SuspendLayout()
            Me.TabControlPanelMediaOptionsTab_Options.SuspendLayout()
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
            'TabControlMedia_Criteria
            '
            Me.TabControlMedia_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlMedia_Criteria.BackColor = System.Drawing.Color.White
            Me.TabControlMedia_Criteria.CanReorderTabs = True
            Me.TabControlMedia_Criteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlMedia_Criteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlMedia_Criteria.Controls.Add(Me.TabControlPanelMediaOptionsTab_Options)
            Me.TabControlMedia_Criteria.Controls.Add(Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlMedia_Criteria.Controls.Add(Me.TabControlPanelMediaSelectClientsTab_SelectClients)
            Me.TabControlMedia_Criteria.Controls.Add(Me.TabControlPanelMediaBillingBatchTab_BillingBatchID)
            Me.TabControlMedia_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlMedia_Criteria.Name = "TabControlMedia_Criteria"
            Me.TabControlMedia_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlMedia_Criteria.SelectedTabIndex = 0
            Me.TabControlMedia_Criteria.Size = New System.Drawing.Size(720, 543)
            Me.TabControlMedia_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlMedia_Criteria.TabIndex = 13
            Me.TabControlMedia_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlMedia_Criteria.Tabs.Add(Me.TabItemMediaCriteria_OptionsTab)
            Me.TabControlMedia_Criteria.Tabs.Add(Me.TabItemMediaCriteria_BillingBatchIDTab)
            Me.TabControlMedia_Criteria.Tabs.Add(Me.TabItemMediaCriteria_SelectClientsTab)
            Me.TabControlMedia_Criteria.Tabs.Add(Me.TabItemMediaCriteria_SelectAccountExecutivesTab)
            Me.TabControlMedia_Criteria.Text = "TabControl1"
            '
            'TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.AEChooserControl_Media)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 13
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemMediaCriteria_SelectAccountExecutivesTab
            '
            'AEChooserControl_Media
            '
            Me.AEChooserControl_Media.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AEChooserControl_Media.BackColor = System.Drawing.Color.Transparent
            Me.AEChooserControl_Media.Location = New System.Drawing.Point(4, 4)
            Me.AEChooserControl_Media.Name = "AEChooserControl_Media"
            Me.AEChooserControl_Media.Size = New System.Drawing.Size(712, 508)
            Me.AEChooserControl_Media.TabIndex = 1
            '
            'TabItemMediaCriteria_SelectAccountExecutivesTab
            '
            Me.TabItemMediaCriteria_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemMediaCriteria_SelectAccountExecutivesTab.Name = "TabItemMediaCriteria_SelectAccountExecutivesTab"
            Me.TabItemMediaCriteria_SelectAccountExecutivesTab.Text = "Select Account Executives"
            '
            'TabControlPanelMediaSelectClientsTab_SelectClients
            '
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControl_Media)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Name = "TabControlPanelMediaSelectClientsTab_SelectClients"
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.TabIndex = 9
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.TabItem = Me.TabItemMediaCriteria_SelectClientsTab
            '
            'CDPChooserControl_Media
            '
            Me.CDPChooserControl_Media.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControl_Media.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControl_Media.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControl_Media.Name = "CDPChooserControl_Media"
            Me.CDPChooserControl_Media.Size = New System.Drawing.Size(712, 508)
            Me.CDPChooserControl_Media.TabIndex = 1
            '
            'TabItemMediaCriteria_SelectClientsTab
            '
            Me.TabItemMediaCriteria_SelectClientsTab.AttachedControl = Me.TabControlPanelMediaSelectClientsTab_SelectClients
            Me.TabItemMediaCriteria_SelectClientsTab.Name = "TabItemMediaCriteria_SelectClientsTab"
            Me.TabItemMediaCriteria_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanelMediaBillingBatchTab_BillingBatchID
            '
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Controls.Add(Me.BillingBatchChooserControl_Media)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Name = "TabControlPanelMediaBillingBatchTab_BillingBatchID"
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.Style.GradientAngle = 90
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.TabIndex = 5
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.TabItem = Me.TabItemMediaCriteria_BillingBatchIDTab
            '
            'BillingBatchChooserControl_Media
            '
            Me.BillingBatchChooserControl_Media.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BillingBatchChooserControl_Media.BackColor = System.Drawing.Color.Transparent
            Me.BillingBatchChooserControl_Media.Location = New System.Drawing.Point(4, 4)
            Me.BillingBatchChooserControl_Media.Name = "BillingBatchChooserControl_Media"
            Me.BillingBatchChooserControl_Media.Size = New System.Drawing.Size(712, 508)
            Me.BillingBatchChooserControl_Media.TabIndex = 1
            '
            'TabItemMediaCriteria_BillingBatchIDTab
            '
            Me.TabItemMediaCriteria_BillingBatchIDTab.AttachedControl = Me.TabControlPanelMediaBillingBatchTab_BillingBatchID
            Me.TabItemMediaCriteria_BillingBatchIDTab.Name = "TabItemMediaCriteria_BillingBatchIDTab"
            Me.TabItemMediaCriteria_BillingBatchIDTab.Text = "Billing Batch ID"
            '
            'TabControlPanelMediaOptionsTab_Options
            '
            Me.TabControlPanelMediaOptionsTab_Options.Controls.Add(Me.BillingWorksheetMediaControl)
            Me.TabControlPanelMediaOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaOptionsTab_Options.Name = "TabControlPanelMediaOptionsTab_Options"
            Me.TabControlPanelMediaOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaOptionsTab_Options.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelMediaOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelMediaOptionsTab_Options.TabIndex = 1
            Me.TabControlPanelMediaOptionsTab_Options.TabItem = Me.TabItemMediaCriteria_OptionsTab
            '
            'BillingWorksheetMediaControl
            '
            Me.BillingWorksheetMediaControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BillingWorksheetMediaControl.BackColor = System.Drawing.Color.Transparent
            Me.BillingWorksheetMediaControl.Location = New System.Drawing.Point(4, 4)
            Me.BillingWorksheetMediaControl.Name = "BillingWorksheetMediaControl"
            Me.BillingWorksheetMediaControl.Size = New System.Drawing.Size(712, 508)
            Me.BillingWorksheetMediaControl.TabIndex = 9
            '
            'TabItemMediaCriteria_OptionsTab
            '
            Me.TabItemMediaCriteria_OptionsTab.AttachedControl = Me.TabControlPanelMediaOptionsTab_Options
            Me.TabItemMediaCriteria_OptionsTab.Name = "TabItemMediaCriteria_OptionsTab"
            Me.TabItemMediaCriteria_OptionsTab.Text = "Options"
            '
            'BillingWorksheetMediaInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(744, 593)
            Me.Controls.Add(Me.TabControlMedia_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingWorksheetMediaInitialLoadingDialog"
            Me.Text = "Billing Worksheet Media Criteria"
            CType(Me.TabControlMedia_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlMedia_Criteria.ResumeLayout(False)
            Me.TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.TabControlPanelMediaSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelMediaBillingBatchTab_BillingBatchID.ResumeLayout(False)
            Me.TabControlPanelMediaOptionsTab_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlMedia_Criteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelMediaOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BillingWorksheetMediaControl As WinForm.Presentation.Controls.BillingWorksheetMediaControl
        Friend WithEvents TabItemMediaCriteria_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AEChooserControl_Media As WinForm.Presentation.Controls.AEChooserControl
        Friend WithEvents TabItemMediaCriteria_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControl_Media As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemMediaCriteria_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaBillingBatchTab_BillingBatchID As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BillingBatchChooserControl_Media As WinForm.Presentation.Controls.BillingBatchChooserControl
        Friend WithEvents TabItemMediaCriteria_BillingBatchIDTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace