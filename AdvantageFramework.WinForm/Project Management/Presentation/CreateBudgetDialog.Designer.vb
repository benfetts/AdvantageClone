Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CreateBudgetDialog
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
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_MaxPeriods = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_BeginPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_BeginPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.NumericInputForm_MaxPeriods = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(196, 64)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_MaxPeriods
            '
            Me.LabelForm_MaxPeriods.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MaxPeriods.BackgroundStyle.Class = ""
            Me.LabelForm_MaxPeriods.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MaxPeriods.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_MaxPeriods.Name = "LabelForm_MaxPeriods"
            Me.LabelForm_MaxPeriods.Size = New System.Drawing.Size(97, 20)
            Me.LabelForm_MaxPeriods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MaxPeriods.TabIndex = 0
            Me.LabelForm_MaxPeriods.Text = "Max Periods:"
            '
            'LabelForm_BeginPostPeriod
            '
            Me.LabelForm_BeginPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_BeginPostPeriod.BackgroundStyle.Class = ""
            Me.LabelForm_BeginPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_BeginPostPeriod.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_BeginPostPeriod.Name = "LabelForm_BeginPostPeriod"
            Me.LabelForm_BeginPostPeriod.Size = New System.Drawing.Size(97, 20)
            Me.LabelForm_BeginPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_BeginPostPeriod.TabIndex = 2
            Me.LabelForm_BeginPostPeriod.Text = "Begin Post Period:"
            '
            'TextBoxForm_BeginPostPeriod
            '
            Me.TextBoxForm_BeginPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_BeginPostPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_BeginPostPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_BeginPostPeriod.ButtonCustom.Visible = True
            Me.TextBoxForm_BeginPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.PostPeriod
            Me.TextBoxForm_BeginPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_BeginPostPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_BeginPostPeriod.FocusHighlightEnabled = True
            Me.TextBoxForm_BeginPostPeriod.Location = New System.Drawing.Point(115, 38)
            Me.TextBoxForm_BeginPostPeriod.Name = "TextBoxForm_BeginPostPeriod"
            Me.TextBoxForm_BeginPostPeriod.Size = New System.Drawing.Size(156, 20)
            Me.TextBoxForm_BeginPostPeriod.TabIndex = 3
            Me.TextBoxForm_BeginPostPeriod.TabOnEnter = True
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(115, 64)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 4
            Me.ButtonForm_Create.Text = "Create"
            '
            'NumericInputForm_MaxPeriods
            '
            Me.NumericInputForm_MaxPeriods.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_MaxPeriods.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Integer
            Me.NumericInputForm_MaxPeriods.Location = New System.Drawing.Point(115, 12)
            Me.NumericInputForm_MaxPeriods.Properties.MinValue = 1
            Me.NumericInputForm_MaxPeriods.Name = "NumericInputForm_MaxPeriods"
            Me.NumericInputForm_MaxPeriods.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputForm_MaxPeriods.TabIndex = 1
            Me.NumericInputForm_MaxPeriods.Value = 1
            '
            'CreateBudgetDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(283, 96)
            Me.Controls.Add(Me.NumericInputForm_MaxPeriods)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.LabelForm_BeginPostPeriod)
            Me.Controls.Add(Me.TextBoxForm_BeginPostPeriod)
            Me.Controls.Add(Me.LabelForm_MaxPeriods)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Name = "CreateBudgetDialog"
            Me.Text = "Create Budget"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_MaxPeriods As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_BeginPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_BeginPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents NumericInputForm_MaxPeriods As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace