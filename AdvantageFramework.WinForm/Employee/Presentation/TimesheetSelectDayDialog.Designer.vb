Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TimesheetSelectDayDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimesheetSelectDayDialog))
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_DayOne = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DayTwo = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DayThree = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DayFour = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DayFive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DaySix = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_DaySeven = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(63, 194)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 8
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(144, 194)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'CheckBoxForm_DayOne
            '
            '
            '
            '
            Me.CheckBoxForm_DayOne.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DayOne.CheckValue = 0
            Me.CheckBoxForm_DayOne.CheckValueChecked = 1
            Me.CheckBoxForm_DayOne.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DayOne.CheckValueUnchecked = 0
            Me.CheckBoxForm_DayOne.ChildControls = CType(resources.GetObject("CheckBoxForm_DayOne.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayOne.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DayOne.Location = New System.Drawing.Point(12, 12)
            Me.CheckBoxForm_DayOne.Name = "CheckBoxForm_DayOne"
            Me.CheckBoxForm_DayOne.OldestSibling = Nothing
            Me.CheckBoxForm_DayOne.SecurityEnabled = True
            Me.CheckBoxForm_DayOne.SiblingControls = CType(resources.GetObject("CheckBoxForm_DayOne.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayOne.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DayOne.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DayOne.TabIndex = 11
            Me.CheckBoxForm_DayOne.Text = "{Day 1}"
            '
            'CheckBoxForm_DayTwo
            '
            '
            '
            '
            Me.CheckBoxForm_DayTwo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DayTwo.CheckValue = 0
            Me.CheckBoxForm_DayTwo.CheckValueChecked = 1
            Me.CheckBoxForm_DayTwo.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DayTwo.CheckValueUnchecked = 0
            Me.CheckBoxForm_DayTwo.ChildControls = CType(resources.GetObject("CheckBoxForm_DayTwo.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayTwo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DayTwo.Location = New System.Drawing.Point(12, 38)
            Me.CheckBoxForm_DayTwo.Name = "CheckBoxForm_DayTwo"
            Me.CheckBoxForm_DayTwo.OldestSibling = Nothing
            Me.CheckBoxForm_DayTwo.SecurityEnabled = True
            Me.CheckBoxForm_DayTwo.SiblingControls = CType(resources.GetObject("CheckBoxForm_DayTwo.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayTwo.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DayTwo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DayTwo.TabIndex = 12
            Me.CheckBoxForm_DayTwo.Text = "{Day 2}"
            '
            'CheckBoxForm_DayThree
            '
            '
            '
            '
            Me.CheckBoxForm_DayThree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DayThree.CheckValue = 0
            Me.CheckBoxForm_DayThree.CheckValueChecked = 1
            Me.CheckBoxForm_DayThree.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DayThree.CheckValueUnchecked = 0
            Me.CheckBoxForm_DayThree.ChildControls = CType(resources.GetObject("CheckBoxForm_DayThree.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayThree.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DayThree.Location = New System.Drawing.Point(12, 64)
            Me.CheckBoxForm_DayThree.Name = "CheckBoxForm_DayThree"
            Me.CheckBoxForm_DayThree.OldestSibling = Nothing
            Me.CheckBoxForm_DayThree.SecurityEnabled = True
            Me.CheckBoxForm_DayThree.SiblingControls = CType(resources.GetObject("CheckBoxForm_DayThree.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayThree.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DayThree.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DayThree.TabIndex = 13
            Me.CheckBoxForm_DayThree.Text = "{Day 3}"
            '
            'CheckBoxForm_DayFour
            '
            '
            '
            '
            Me.CheckBoxForm_DayFour.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DayFour.CheckValue = 0
            Me.CheckBoxForm_DayFour.CheckValueChecked = 1
            Me.CheckBoxForm_DayFour.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DayFour.CheckValueUnchecked = 0
            Me.CheckBoxForm_DayFour.ChildControls = CType(resources.GetObject("CheckBoxForm_DayFour.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayFour.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DayFour.Location = New System.Drawing.Point(12, 90)
            Me.CheckBoxForm_DayFour.Name = "CheckBoxForm_DayFour"
            Me.CheckBoxForm_DayFour.OldestSibling = Nothing
            Me.CheckBoxForm_DayFour.SecurityEnabled = True
            Me.CheckBoxForm_DayFour.SiblingControls = CType(resources.GetObject("CheckBoxForm_DayFour.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayFour.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DayFour.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DayFour.TabIndex = 14
            Me.CheckBoxForm_DayFour.Text = "{Day 4}"
            '
            'CheckBoxForm_DayFive
            '
            '
            '
            '
            Me.CheckBoxForm_DayFive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DayFive.CheckValue = 0
            Me.CheckBoxForm_DayFive.CheckValueChecked = 1
            Me.CheckBoxForm_DayFive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DayFive.CheckValueUnchecked = 0
            Me.CheckBoxForm_DayFive.ChildControls = CType(resources.GetObject("CheckBoxForm_DayFive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayFive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DayFive.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_DayFive.Name = "CheckBoxForm_DayFive"
            Me.CheckBoxForm_DayFive.OldestSibling = Nothing
            Me.CheckBoxForm_DayFive.SecurityEnabled = True
            Me.CheckBoxForm_DayFive.SiblingControls = CType(resources.GetObject("CheckBoxForm_DayFive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DayFive.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DayFive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DayFive.TabIndex = 15
            Me.CheckBoxForm_DayFive.Text = "{Day 5}"
            '
            'CheckBoxForm_DaySix
            '
            '
            '
            '
            Me.CheckBoxForm_DaySix.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DaySix.CheckValue = 0
            Me.CheckBoxForm_DaySix.CheckValueChecked = 1
            Me.CheckBoxForm_DaySix.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DaySix.CheckValueUnchecked = 0
            Me.CheckBoxForm_DaySix.ChildControls = CType(resources.GetObject("CheckBoxForm_DaySix.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DaySix.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DaySix.Location = New System.Drawing.Point(12, 142)
            Me.CheckBoxForm_DaySix.Name = "CheckBoxForm_DaySix"
            Me.CheckBoxForm_DaySix.OldestSibling = Nothing
            Me.CheckBoxForm_DaySix.SecurityEnabled = True
            Me.CheckBoxForm_DaySix.SiblingControls = CType(resources.GetObject("CheckBoxForm_DaySix.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DaySix.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DaySix.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DaySix.TabIndex = 16
            Me.CheckBoxForm_DaySix.Text = "{Day 6}"
            '
            'CheckBoxForm_DaySeven
            '
            '
            '
            '
            Me.CheckBoxForm_DaySeven.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DaySeven.CheckValue = 0
            Me.CheckBoxForm_DaySeven.CheckValueChecked = 1
            Me.CheckBoxForm_DaySeven.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DaySeven.CheckValueUnchecked = 0
            Me.CheckBoxForm_DaySeven.ChildControls = CType(resources.GetObject("CheckBoxForm_DaySeven.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DaySeven.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DaySeven.Location = New System.Drawing.Point(12, 168)
            Me.CheckBoxForm_DaySeven.Name = "CheckBoxForm_DaySeven"
            Me.CheckBoxForm_DaySeven.OldestSibling = Nothing
            Me.CheckBoxForm_DaySeven.SecurityEnabled = True
            Me.CheckBoxForm_DaySeven.SiblingControls = CType(resources.GetObject("CheckBoxForm_DaySeven.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DaySeven.Size = New System.Drawing.Size(207, 20)
            Me.CheckBoxForm_DaySeven.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DaySeven.TabIndex = 17
            Me.CheckBoxForm_DaySeven.Text = "{Day 7}"
            '
            'TimesheetSelectDayDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(231, 226)
            Me.Controls.Add(Me.CheckBoxForm_DaySeven)
            Me.Controls.Add(Me.CheckBoxForm_DaySix)
            Me.Controls.Add(Me.CheckBoxForm_DayFive)
            Me.Controls.Add(Me.CheckBoxForm_DayFour)
            Me.Controls.Add(Me.CheckBoxForm_DayThree)
            Me.Controls.Add(Me.CheckBoxForm_DayTwo)
            Me.Controls.Add(Me.CheckBoxForm_DayOne)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TimesheetSelectDayDialog"
            Me.Text = "Select Days"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_DayOne As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DayTwo As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DayThree As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DayFour As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DayFive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DaySix As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_DaySeven As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace