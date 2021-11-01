Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeContractControl
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
            Me.DataGridViewForm_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_Form = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Contracts
            '
            Me.DataGridViewForm_Contracts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Contracts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Contracts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Contracts.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Contracts.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Contracts.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Contracts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Contracts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Contracts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_Contracts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Contracts.ItemDescription = "Service Fee Contract(s)"
            Me.DataGridViewForm_Contracts.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_Contracts.MultiSelect = True
            Me.DataGridViewForm_Contracts.Name = "DataGridViewForm_Contracts"
            Me.DataGridViewForm_Contracts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_Contracts.RunStandardValidation = True
            Me.DataGridViewForm_Contracts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Contracts.Size = New System.Drawing.Size(714, 388)
            Me.DataGridViewForm_Contracts.TabIndex = 20
            Me.DataGridViewForm_Contracts.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Contracts.ViewCaptionHeight = -1
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Contracts)
            Me.PanelForm_Form.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_Form.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_Form.Name = "PanelForm_Form"
            Me.PanelForm_Form.Size = New System.Drawing.Size(714, 388)
            Me.PanelForm_Form.TabIndex = 21
            '
            'ServiceFeeContractControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelForm_Form)
            Me.Name = "ServiceFeeContractControl"
            Me.Size = New System.Drawing.Size(714, 388)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Contracts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_Form As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
