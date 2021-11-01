Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterInvoicesAssignedDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterInvoicesAssignedDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_InvoicesAssigned = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInvoicesAssigned_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewJournalEntries_InvoicesAssigned = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoicesAssigned_InvoicesAssigned = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelJournalEntries_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewJournalEntries_JournalEntries = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoicesAssigned_JournalEntries = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_InvoicesAssigned, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_InvoicesAssigned.SuspendLayout()
            Me.TabControlPanelInvoicesAssigned_Details.SuspendLayout()
            Me.TabControlPanelJournalEntries_Details.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(699, 406)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'TabControlForm_InvoicesAssigned
            '
            Me.TabControlForm_InvoicesAssigned.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_InvoicesAssigned.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_InvoicesAssigned.CanReorderTabs = False
            Me.TabControlForm_InvoicesAssigned.Controls.Add(Me.TabControlPanelInvoicesAssigned_Details)
            Me.TabControlForm_InvoicesAssigned.Controls.Add(Me.TabControlPanelJournalEntries_Details)
            Me.TabControlForm_InvoicesAssigned.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_InvoicesAssigned.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_InvoicesAssigned.Name = "TabControlForm_InvoicesAssigned"
            Me.TabControlForm_InvoicesAssigned.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_InvoicesAssigned.SelectedTabIndex = 0
            Me.TabControlForm_InvoicesAssigned.Size = New System.Drawing.Size(762, 388)
            Me.TabControlForm_InvoicesAssigned.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_InvoicesAssigned.TabIndex = 0
            Me.TabControlForm_InvoicesAssigned.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_InvoicesAssigned.Tabs.Add(Me.TabItemInvoicesAssigned_InvoicesAssigned)
            Me.TabControlForm_InvoicesAssigned.Tabs.Add(Me.TabItemInvoicesAssigned_JournalEntries)
            Me.TabControlForm_InvoicesAssigned.TabStop = False
            '
            'TabControlPanelInvoicesAssigned_Details
            '
            Me.TabControlPanelInvoicesAssigned_Details.Controls.Add(Me.DataGridViewJournalEntries_InvoicesAssigned)
            Me.TabControlPanelInvoicesAssigned_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInvoicesAssigned_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoicesAssigned_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoicesAssigned_Details.Name = "TabControlPanelInvoicesAssigned_Details"
            Me.TabControlPanelInvoicesAssigned_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoicesAssigned_Details.Size = New System.Drawing.Size(762, 361)
            Me.TabControlPanelInvoicesAssigned_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesAssigned_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoicesAssigned_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoicesAssigned_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoicesAssigned_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoicesAssigned_Details.Style.GradientAngle = 90
            Me.TabControlPanelInvoicesAssigned_Details.TabIndex = 12
            Me.TabControlPanelInvoicesAssigned_Details.TabItem = Me.TabItemInvoicesAssigned_InvoicesAssigned
            '
            'DataGridViewJournalEntries_InvoicesAssigned
            '
            Me.DataGridViewJournalEntries_InvoicesAssigned.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.AllowDragAndDrop = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJournalEntries_InvoicesAssigned.AutoFilterLookupColumns = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.AutoloadRepositoryDatasource = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.AutoUpdateViewCaption = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJournalEntries_InvoicesAssigned.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJournalEntries_InvoicesAssigned.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJournalEntries_InvoicesAssigned.ItemDescription = "Invoice(s) Assigned"
            Me.DataGridViewJournalEntries_InvoicesAssigned.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewJournalEntries_InvoicesAssigned.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewJournalEntries_InvoicesAssigned.MultiSelect = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.Name = "DataGridViewJournalEntries_InvoicesAssigned"
            Me.DataGridViewJournalEntries_InvoicesAssigned.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJournalEntries_InvoicesAssigned.RunStandardValidation = True
            Me.DataGridViewJournalEntries_InvoicesAssigned.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.Size = New System.Drawing.Size(752, 351)
            Me.DataGridViewJournalEntries_InvoicesAssigned.TabIndex = 7
            Me.DataGridViewJournalEntries_InvoicesAssigned.UseEmbeddedNavigator = False
            Me.DataGridViewJournalEntries_InvoicesAssigned.ViewCaptionHeight = -1
            '
            'TabItemInvoicesAssigned_InvoicesAssigned
            '
            Me.TabItemInvoicesAssigned_InvoicesAssigned.AttachedControl = Me.TabControlPanelInvoicesAssigned_Details
            Me.TabItemInvoicesAssigned_InvoicesAssigned.Name = "TabItemInvoicesAssigned_InvoicesAssigned"
            Me.TabItemInvoicesAssigned_InvoicesAssigned.Text = "Invoices Assigned"
            '
            'TabControlPanelJournalEntries_Details
            '
            Me.TabControlPanelJournalEntries_Details.Controls.Add(Me.DataGridViewJournalEntries_JournalEntries)
            Me.TabControlPanelJournalEntries_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelJournalEntries_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelJournalEntries_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelJournalEntries_Details.Name = "TabControlPanelJournalEntries_Details"
            Me.TabControlPanelJournalEntries_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelJournalEntries_Details.Size = New System.Drawing.Size(762, 361)
            Me.TabControlPanelJournalEntries_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntries_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelJournalEntries_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelJournalEntries_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelJournalEntries_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelJournalEntries_Details.Style.GradientAngle = 90
            Me.TabControlPanelJournalEntries_Details.TabIndex = 0
            Me.TabControlPanelJournalEntries_Details.TabItem = Me.TabItemInvoicesAssigned_JournalEntries
            '
            'DataGridViewJournalEntries_JournalEntries
            '
            Me.DataGridViewJournalEntries_JournalEntries.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewJournalEntries_JournalEntries.AllowDragAndDrop = False
            Me.DataGridViewJournalEntries_JournalEntries.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewJournalEntries_JournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewJournalEntries_JournalEntries.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewJournalEntries_JournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewJournalEntries_JournalEntries.AutoFilterLookupColumns = False
            Me.DataGridViewJournalEntries_JournalEntries.AutoloadRepositoryDatasource = False
            Me.DataGridViewJournalEntries_JournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewJournalEntries_JournalEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewJournalEntries_JournalEntries.DataSource = Nothing
            Me.DataGridViewJournalEntries_JournalEntries.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewJournalEntries_JournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewJournalEntries_JournalEntries.ItemDescription = ""
            Me.DataGridViewJournalEntries_JournalEntries.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewJournalEntries_JournalEntries.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewJournalEntries_JournalEntries.MultiSelect = True
            Me.DataGridViewJournalEntries_JournalEntries.Name = "DataGridViewJournalEntries_JournalEntries"
            Me.DataGridViewJournalEntries_JournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewJournalEntries_JournalEntries.RunStandardValidation = True
            Me.DataGridViewJournalEntries_JournalEntries.ShowColumnMenuOnRightClick = False
            Me.DataGridViewJournalEntries_JournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewJournalEntries_JournalEntries.Size = New System.Drawing.Size(752, 351)
            Me.DataGridViewJournalEntries_JournalEntries.TabIndex = 0
            Me.DataGridViewJournalEntries_JournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewJournalEntries_JournalEntries.ViewCaptionHeight = -1
            '
            'TabItemInvoicesAssigned_JournalEntries
            '
            Me.TabItemInvoicesAssigned_JournalEntries.AttachedControl = Me.TabControlPanelJournalEntries_Details
            Me.TabItemInvoicesAssigned_JournalEntries.Name = "TabItemInvoicesAssigned_JournalEntries"
            Me.TabItemInvoicesAssigned_JournalEntries.Text = "Journal Entries"
            '
            'BillingCommandCenterInvoicesAssignedDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(786, 438)
            Me.Controls.Add(Me.TabControlForm_InvoicesAssigned)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterInvoicesAssignedDialog"
            Me.Text = "Billing Command Center Invoices Assigned"
            CType(Me.TabControlForm_InvoicesAssigned, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_InvoicesAssigned.ResumeLayout(False)
            Me.TabControlPanelInvoicesAssigned_Details.ResumeLayout(False)
            Me.TabControlPanelJournalEntries_Details.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_InvoicesAssigned As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelJournalEntries_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewJournalEntries_JournalEntries As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemInvoicesAssigned_JournalEntries As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInvoicesAssigned_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemInvoicesAssigned_InvoicesAssigned As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewJournalEntries_InvoicesAssigned As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace