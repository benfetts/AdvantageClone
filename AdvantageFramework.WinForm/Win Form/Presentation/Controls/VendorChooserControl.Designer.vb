Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorChooserControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewControl_Vendors = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseVendors = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_Vendors
            '
            Me.DataGridViewControl_Vendors.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_Vendors.AllowDragAndDrop = False
            Me.DataGridViewControl_Vendors.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Vendors.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_Vendors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_Vendors.AutoFilterLookupColumns = False
            Me.DataGridViewControl_Vendors.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Vendors.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_Vendors.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewControl_Vendors.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewControl_Vendors.MultiSelect = True
            Me.DataGridViewControl_Vendors.Name = "DataGridViewControl_Vendors"
            Me.DataGridViewControl_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_Vendors.RunStandardValidation = True
            Me.DataGridViewControl_Vendors.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_Vendors.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Vendors.Size = New System.Drawing.Size(571, 356)
            Me.DataGridViewControl_Vendors.TabIndex = 15
            Me.DataGridViewControl_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Vendors.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllVendors
            '
            Me.RadioButtonControl_AllVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllVendors.Checked = True
            Me.RadioButtonControl_AllVendors.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllVendors.CheckValue = "Y"
            Me.RadioButtonControl_AllVendors.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllVendors.Name = "RadioButtonControl_AllVendors"
            Me.RadioButtonControl_AllVendors.SecurityEnabled = True
            Me.RadioButtonControl_AllVendors.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllVendors.TabIndex = 16
            Me.RadioButtonControl_AllVendors.TabOnEnter = True
            Me.RadioButtonControl_AllVendors.Text = "All Vendors"
            '
            'RadioButtonControl_ChooseVendors
            '
            Me.RadioButtonControl_ChooseVendors.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseVendors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseVendors.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseVendors.Location = New System.Drawing.Point(142, 0)
            Me.RadioButtonControl_ChooseVendors.Name = "RadioButtonControl_ChooseVendors"
            Me.RadioButtonControl_ChooseVendors.SecurityEnabled = True
            Me.RadioButtonControl_ChooseVendors.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseVendors.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseVendors.TabIndex = 17
            Me.RadioButtonControl_ChooseVendors.TabOnEnter = True
            Me.RadioButtonControl_ChooseVendors.TabStop = False
            Me.RadioButtonControl_ChooseVendors.Text = "Choose Vendors"
            '
            'VendorChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioButtonControl_AllVendors)
            Me.Controls.Add(Me.RadioButtonControl_ChooseVendors)
            Me.Controls.Add(Me.DataGridViewControl_Vendors)
            Me.Name = "VendorChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_Vendors As DataGridView
        Friend WithEvents RadioButtonControl_AllVendors As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseVendors As RadioButtonControl
    End Class

End Namespace