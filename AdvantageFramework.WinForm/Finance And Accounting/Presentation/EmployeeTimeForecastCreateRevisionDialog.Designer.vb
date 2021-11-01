Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastCreateRevisionDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastCreateRevisionDialog))
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_UpdateRevenueAmounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_UpdateEmployeeRates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(363, 90)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 11
            Me.ButtonForm_Create.Text = "Create"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(444, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 12
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_ExcludeHoursEnteredInCopy
            '
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.BackgroundStyle.Class = ""
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValue = 0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeHoursEnteredInCopy.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Enabled = False
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Location = New System.Drawing.Point(12, 64)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Name = "CheckBoxForm_ExcludeHoursEnteredInCopy"
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeHoursEnteredInCopy.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Size = New System.Drawing.Size(507, 20)
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.TabIndex = 10
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.TabStop = False
            Me.CheckBoxForm_ExcludeHoursEnteredInCopy.Text = "Exclude hours entered in copy"
            '
            'CheckBoxForm_UpdateRevenueAmounts
            '
            Me.CheckBoxForm_UpdateRevenueAmounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UpdateRevenueAmounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_UpdateRevenueAmounts.BackgroundStyle.Class = ""
            Me.CheckBoxForm_UpdateRevenueAmounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValue = 0
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValueChecked = 1
            Me.CheckBoxForm_UpdateRevenueAmounts.CheckValueUnchecked = 0
            Me.CheckBoxForm_UpdateRevenueAmounts.ChildControls = CType(resources.GetObject("CheckBoxForm_UpdateRevenueAmounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateRevenueAmounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UpdateRevenueAmounts.Enabled = False
            Me.CheckBoxForm_UpdateRevenueAmounts.Location = New System.Drawing.Point(12, 38)
            Me.CheckBoxForm_UpdateRevenueAmounts.Name = "CheckBoxForm_UpdateRevenueAmounts"
            Me.CheckBoxForm_UpdateRevenueAmounts.OldestSibling = Nothing
            Me.CheckBoxForm_UpdateRevenueAmounts.SecurityEnabled = True
            Me.CheckBoxForm_UpdateRevenueAmounts.SiblingControls = CType(resources.GetObject("CheckBoxForm_UpdateRevenueAmounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateRevenueAmounts.Size = New System.Drawing.Size(507, 20)
            Me.CheckBoxForm_UpdateRevenueAmounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UpdateRevenueAmounts.TabIndex = 9
            Me.CheckBoxForm_UpdateRevenueAmounts.TabStop = False
            Me.CheckBoxForm_UpdateRevenueAmounts.Text = "Update Forecast with current revenue amounts based on approved estimates"
            '
            'CheckBoxForm_UpdateEmployeeRates
            '
            Me.CheckBoxForm_UpdateEmployeeRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_UpdateEmployeeRates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_UpdateEmployeeRates.BackgroundStyle.Class = ""
            Me.CheckBoxForm_UpdateEmployeeRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValue = 0
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValueChecked = 1
            Me.CheckBoxForm_UpdateEmployeeRates.CheckValueUnchecked = 0
            Me.CheckBoxForm_UpdateEmployeeRates.ChildControls = CType(resources.GetObject("CheckBoxForm_UpdateEmployeeRates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateEmployeeRates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_UpdateEmployeeRates.Enabled = False
            Me.CheckBoxForm_UpdateEmployeeRates.Location = New System.Drawing.Point(12, 12)
            Me.CheckBoxForm_UpdateEmployeeRates.Name = "CheckBoxForm_UpdateEmployeeRates"
            Me.CheckBoxForm_UpdateEmployeeRates.OldestSibling = Nothing
            Me.CheckBoxForm_UpdateEmployeeRates.SecurityEnabled = True
            Me.CheckBoxForm_UpdateEmployeeRates.SiblingControls = CType(resources.GetObject("CheckBoxForm_UpdateEmployeeRates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UpdateEmployeeRates.Size = New System.Drawing.Size(507, 20)
            Me.CheckBoxForm_UpdateEmployeeRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UpdateEmployeeRates.TabIndex = 8
            Me.CheckBoxForm_UpdateEmployeeRates.TabStop = False
            Me.CheckBoxForm_UpdateEmployeeRates.Text = "Update Forecast with current employee rates and recalculate totals"
            '
            'EmployeeTimeForecastCreateRevisionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(531, 122)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.CheckBoxForm_ExcludeHoursEnteredInCopy)
            Me.Controls.Add(Me.CheckBoxForm_UpdateRevenueAmounts)
            Me.Controls.Add(Me.CheckBoxForm_UpdateEmployeeRates)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastCreateRevisionDialog"
            Me.Text = "Create Employee Time Forecast Office Detail Revision"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_ExcludeHoursEnteredInCopy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UpdateRevenueAmounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_UpdateEmployeeRates As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace