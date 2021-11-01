Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderApprovalRuleEmployeesSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderApprovalRuleEmployeesSetupForm))
            Me.DataGridViewForm_POApprovalRuleEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_MinMaxRange = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Instructions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Ok = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'DataGridViewForm_POApprovalRuleEmployees
            '
            Me.DataGridViewForm_POApprovalRuleEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_POApprovalRuleEmployees.AutoValidate = System.Windows.Forms.AutoValidate.Disable
            Me.DataGridViewForm_POApprovalRuleEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_POApprovalRuleEmployees.DataSource = Nothing
            Me.DataGridViewForm_POApprovalRuleEmployees.ItemDescription = ""
            Me.DataGridViewForm_POApprovalRuleEmployees.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_POApprovalRuleEmployees.MultiSelect = False
            Me.DataGridViewForm_POApprovalRuleEmployees.Name = "DataGridViewForm_POApprovalRuleEmployees"
            Me.DataGridViewForm_POApprovalRuleEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_POApprovalRuleEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_POApprovalRuleEmployees.Size = New System.Drawing.Size(689, 368)
            Me.DataGridViewForm_POApprovalRuleEmployees.TabIndex = 4
            Me.DataGridViewForm_POApprovalRuleEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_POApprovalRuleEmployees.ViewCaptionHeight = -1
            '
            'LabelForm_MinMaxRange
            '
            Me.LabelForm_MinMaxRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MinMaxRange.BackgroundStyle.Class = ""
            Me.LabelForm_MinMaxRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MinMaxRange.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_MinMaxRange.Name = "LabelForm_MinMaxRange"
            Me.LabelForm_MinMaxRange.Size = New System.Drawing.Size(689, 20)
            Me.LabelForm_MinMaxRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MinMaxRange.TabIndex = 5
            Me.LabelForm_MinMaxRange.Text = "Minimum Range: 0.00  Maximum Range:  1.00"
            '
            'LabelForm_Instructions
            '
            Me.LabelForm_Instructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Instructions.BackgroundStyle.Class = ""
            Me.LabelForm_Instructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Instructions.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Instructions.Name = "LabelForm_Instructions"
            Me.LabelForm_Instructions.Size = New System.Drawing.Size(689, 20)
            Me.LabelForm_Instructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Instructions.TabIndex = 6
            Me.LabelForm_Instructions.Text = "Select one primary approver and up to 9 alternate approvers."
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(626, 438)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ok.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.ButtonForm_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ok.Location = New System.Drawing.Point(545, 438)
            Me.ButtonForm_Ok.Name = "ButtonForm_Ok"
            Me.ButtonForm_Ok.SecurityEnabled = True
            Me.ButtonForm_Ok.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ok.TabIndex = 7
            Me.ButtonForm_Ok.Text = "Ok"
            '
            'PurchaseOrderApprovalRuleEmployeesSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 470)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Ok)
            Me.Controls.Add(Me.LabelForm_Instructions)
            Me.Controls.Add(Me.LabelForm_MinMaxRange)
            Me.Controls.Add(Me.DataGridViewForm_POApprovalRuleEmployees)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PurchaseOrderApprovalRuleEmployeesSetupForm"
            Me.Text = "Approvers"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_POApprovalRuleEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_MinMaxRange As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Instructions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Ok As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace

