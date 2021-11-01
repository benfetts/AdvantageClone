Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ServiceFeeListDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ServiceFeeListDialog))
            Me.DataGridViewForm_ServiceFees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Ok = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_SelectFees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelForm_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Main.SuspendLayout()
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_ServiceFees
            '
            Me.DataGridViewForm_ServiceFees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ServiceFees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ServiceFees.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ServiceFees.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ServiceFees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ServiceFees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_ServiceFees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ServiceFees.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_ServiceFees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ServiceFees.ItemDescription = "Item(s)"
            Me.DataGridViewForm_ServiceFees.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewForm_ServiceFees.MultiSelect = True
            Me.DataGridViewForm_ServiceFees.Name = "DataGridViewForm_ServiceFees"
            Me.DataGridViewForm_ServiceFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ServiceFees.RunStandardValidation = True
            Me.DataGridViewForm_ServiceFees.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_ServiceFees.Size = New System.Drawing.Size(603, 350)
            Me.DataGridViewForm_ServiceFees.TabIndex = 0
            Me.DataGridViewForm_ServiceFees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ServiceFees.ViewCaptionHeight = -1
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(540, 394)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(459, 394)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 2
            Me.ButtonForm_Create.Text = "Create"
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ok.Location = New System.Drawing.Point(459, 394)
            Me.ButtonForm_Ok.Name = "ButtonForm_Ok"
            Me.ButtonForm_Ok.SecurityEnabled = True
            Me.ButtonForm_Ok.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ok.TabIndex = 1
            Me.ButtonForm_Ok.Text = "OK"
            '
            'LabelForm_SelectFees
            '
            Me.LabelForm_SelectFees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectFees.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectFees.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectFees.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectFees.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectFees.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectFees.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectFees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectFees.Dock = System.Windows.Forms.DockStyle.Top
            Me.LabelForm_SelectFees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectFees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectFees.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_SelectFees.Name = "LabelForm_SelectFees"
            Me.LabelForm_SelectFees.Size = New System.Drawing.Size(603, 20)
            Me.LabelForm_SelectFees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectFees.TabIndex = 25
            Me.LabelForm_SelectFees.Text = "Select Service Fee(s) to Create"
            '
            'PanelForm_Main
            '
            Me.PanelForm_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Main.Controls.Add(Me.DataGridViewForm_ServiceFees)
            Me.PanelForm_Main.Controls.Add(Me.PanelForm_TopSection)
            Me.PanelForm_Main.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_Main.Name = "PanelForm_Main"
            Me.PanelForm_Main.Size = New System.Drawing.Size(603, 376)
            Me.PanelForm_Main.TabIndex = 26
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_TopSection.Controls.Add(Me.LabelForm_SelectFees)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(603, 26)
            Me.PanelForm_TopSection.TabIndex = 26
            '
            'ServiceFeeListDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(627, 426)
            Me.Controls.Add(Me.PanelForm_Main)
            Me.Controls.Add(Me.ButtonForm_Ok)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ServiceFeeListDialog"
            Me.Text = "Service Fees"
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Main.ResumeLayout(False)
            CType(Me.PanelForm_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ServiceFees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Ok As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_SelectFees As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_Main As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
    End Class

End Namespace
