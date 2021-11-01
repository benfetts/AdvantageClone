Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RateFlagEntryControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewForm_AllBillingRateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_BillingRateFlags = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_StructureLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_BillingRateLevel = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelControl_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_AllBillingRateDetails
            '
            Me.DataGridViewForm_AllBillingRateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AllBillingRateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AllBillingRateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AllBillingRateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AllBillingRateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AllBillingRateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AllBillingRateDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_AllBillingRateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AllBillingRateDetails.ItemDescription = ""
            Me.DataGridViewForm_AllBillingRateDetails.Location = New System.Drawing.Point(0, 34)
            Me.DataGridViewForm_AllBillingRateDetails.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_AllBillingRateDetails.MultiSelect = True
            Me.DataGridViewForm_AllBillingRateDetails.Name = "DataGridViewForm_AllBillingRateDetails"
            Me.DataGridViewForm_AllBillingRateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AllBillingRateDetails.RunStandardValidation = True
            Me.DataGridViewForm_AllBillingRateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AllBillingRateDetails.Size = New System.Drawing.Size(689, 361)
            Me.DataGridViewForm_AllBillingRateDetails.TabIndex = 36
            Me.DataGridViewForm_AllBillingRateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AllBillingRateDetails.ViewCaptionHeight = -1
            '
            'DataGridViewForm_BillingRateFlags
            '
            Me.DataGridViewForm_BillingRateFlags.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_BillingRateFlags.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_BillingRateFlags.AutoFilterLookupColumns = False
            Me.DataGridViewForm_BillingRateFlags.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_BillingRateFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_BillingRateFlags.DataSource = Nothing
            Me.DataGridViewForm_BillingRateFlags.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_BillingRateFlags.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_BillingRateFlags.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_BillingRateFlags.ItemDescription = ""
            Me.DataGridViewForm_BillingRateFlags.Location = New System.Drawing.Point(0, 34)
            Me.DataGridViewForm_BillingRateFlags.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_BillingRateFlags.MultiSelect = True
            Me.DataGridViewForm_BillingRateFlags.Name = "DataGridViewForm_BillingRateFlags"
            Me.DataGridViewForm_BillingRateFlags.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_BillingRateFlags.RunStandardValidation = True
            Me.DataGridViewForm_BillingRateFlags.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_BillingRateFlags.Size = New System.Drawing.Size(689, 361)
            Me.DataGridViewForm_BillingRateFlags.TabIndex = 34
            Me.DataGridViewForm_BillingRateFlags.UseEmbeddedNavigator = False
            Me.DataGridViewForm_BillingRateFlags.ViewCaptionHeight = -1
            '
            'LabelForm_StructureLevel
            '
            Me.LabelForm_StructureLevel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StructureLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StructureLevel.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_StructureLevel.Margin = New System.Windows.Forms.Padding(4)
            Me.LabelForm_StructureLevel.Name = "LabelForm_StructureLevel"
            Me.LabelForm_StructureLevel.Size = New System.Drawing.Size(115, 25)
            Me.LabelForm_StructureLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StructureLevel.TabIndex = 28
            Me.LabelForm_StructureLevel.Text = "Structure Level:"
            '
            'ComboBoxForm_BillingRateLevel
            '
            Me.ComboBoxForm_BillingRateLevel.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_BillingRateLevel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_BillingRateLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_BillingRateLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_BillingRateLevel.AutoFindItemInDataSource = False
            Me.ComboBoxForm_BillingRateLevel.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_BillingRateLevel.BookmarkingEnabled = False
            Me.ComboBoxForm_BillingRateLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.BillingRateLevel
            Me.ComboBoxForm_BillingRateLevel.DisableMouseWheel = False
            Me.ComboBoxForm_BillingRateLevel.DisplayMember = "Description"
            Me.ComboBoxForm_BillingRateLevel.DisplayName = ""
            Me.ComboBoxForm_BillingRateLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_BillingRateLevel.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_BillingRateLevel.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_BillingRateLevel.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_BillingRateLevel.FocusHighlightEnabled = True
            Me.ComboBoxForm_BillingRateLevel.FormattingEnabled = True
            Me.ComboBoxForm_BillingRateLevel.ItemHeight = 14
            Me.ComboBoxForm_BillingRateLevel.Location = New System.Drawing.Point(123, 0)
            Me.ComboBoxForm_BillingRateLevel.Margin = New System.Windows.Forms.Padding(4)
            Me.ComboBoxForm_BillingRateLevel.Name = "ComboBoxForm_BillingRateLevel"
            Me.ComboBoxForm_BillingRateLevel.PreventEnterBeep = False
            Me.ComboBoxForm_BillingRateLevel.ReadOnly = False
            Me.ComboBoxForm_BillingRateLevel.SecurityEnabled = True
            Me.ComboBoxForm_BillingRateLevel.Size = New System.Drawing.Size(566, 20)
            Me.ComboBoxForm_BillingRateLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_BillingRateLevel.TabIndex = 33
            Me.ComboBoxForm_BillingRateLevel.ValueMember = "ID"
            Me.ComboBoxForm_BillingRateLevel.WatermarkText = "Select Billing Rate Level"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewForm_BillingRateFlags)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewForm_AllBillingRateDetails)
            Me.PanelControl_Control.Controls.Add(Me.PanelControl_TopSection)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(689, 395)
            Me.PanelControl_Control.TabIndex = 45
            '
            'PanelControl_TopSection
            '
            Me.PanelControl_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_TopSection.Controls.Add(Me.LabelForm_StructureLevel)
            Me.PanelControl_TopSection.Controls.Add(Me.ComboBoxForm_BillingRateLevel)
            Me.PanelControl_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_TopSection.Margin = New System.Windows.Forms.Padding(4)
            Me.PanelControl_TopSection.Name = "PanelControl_TopSection"
            Me.PanelControl_TopSection.Size = New System.Drawing.Size(689, 34)
            Me.PanelControl_TopSection.TabIndex = 37
            Me.PanelControl_TopSection.Visible = False
            '
            'RateFlagEntryControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "RateFlagEntryControl"
            Me.Size = New System.Drawing.Size(689, 395)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_StructureLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_BillingRateLevel As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_BillingRateFlags As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_AllBillingRateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelControl_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
