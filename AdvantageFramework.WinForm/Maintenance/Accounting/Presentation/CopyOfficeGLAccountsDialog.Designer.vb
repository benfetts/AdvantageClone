Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CopyOfficeGLAccountsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopyOfficeGLAccountsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Create = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.GroupBoxForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxCopy_SalesTaxAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_MediaSalesClassAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_ProductionFunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_DefaultMediaAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_DefaultProductionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCopy_DefaultAccounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ReplaceOfficeSegment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.GroupBoxForm_Copy, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Copy.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(477, 188)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Create
            '
            Me.ButtonForm_Create.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Create.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Create.Location = New System.Drawing.Point(396, 188)
            Me.ButtonForm_Create.Name = "ButtonForm_Create"
            Me.ButtonForm_Create.SecurityEnabled = True
            Me.ButtonForm_Create.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Create.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Create.TabIndex = 3
            Me.ButtonForm_Create.Text = "Create"
            '
            'GroupBoxForm_Copy
            '
            Me.GroupBoxForm_Copy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_SalesTaxAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_MediaSalesClassAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_ProductionFunctionAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_DefaultMediaAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_DefaultProductionAccounts)
            Me.GroupBoxForm_Copy.Controls.Add(Me.CheckBoxCopy_DefaultAccounts)
            Me.GroupBoxForm_Copy.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_Copy.Name = "GroupBoxForm_Copy"
            Me.GroupBoxForm_Copy.Size = New System.Drawing.Size(540, 144)
            Me.GroupBoxForm_Copy.TabIndex = 2
            Me.GroupBoxForm_Copy.Text = "Copy"
            '
            'CheckBoxCopy_SalesTaxAccounts
            '
            Me.CheckBoxCopy_SalesTaxAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_SalesTaxAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_SalesTaxAccounts.CheckValue = 0
            Me.CheckBoxCopy_SalesTaxAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_SalesTaxAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_SalesTaxAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_SalesTaxAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_SalesTaxAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_SalesTaxAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_SalesTaxAccounts.Location = New System.Drawing.Point(233, 113)
            Me.CheckBoxCopy_SalesTaxAccounts.Name = "CheckBoxCopy_SalesTaxAccounts"
            Me.CheckBoxCopy_SalesTaxAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_SalesTaxAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_SalesTaxAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_SalesTaxAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_SalesTaxAccounts.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxCopy_SalesTaxAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_SalesTaxAccounts.TabIndex = 6
            Me.CheckBoxCopy_SalesTaxAccounts.Text = "Sales Tax Accounts"
            '
            'CheckBoxCopy_MediaSalesClassAccounts
            '
            Me.CheckBoxCopy_MediaSalesClassAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_MediaSalesClassAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_MediaSalesClassAccounts.CheckValue = 0
            Me.CheckBoxCopy_MediaSalesClassAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_MediaSalesClassAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_MediaSalesClassAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_MediaSalesClassAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_MediaSalesClassAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_MediaSalesClassAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_MediaSalesClassAccounts.Location = New System.Drawing.Point(233, 87)
            Me.CheckBoxCopy_MediaSalesClassAccounts.Name = "CheckBoxCopy_MediaSalesClassAccounts"
            Me.CheckBoxCopy_MediaSalesClassAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_MediaSalesClassAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_MediaSalesClassAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_MediaSalesClassAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_MediaSalesClassAccounts.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxCopy_MediaSalesClassAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_MediaSalesClassAccounts.TabIndex = 5
            Me.CheckBoxCopy_MediaSalesClassAccounts.Text = "Media Sales Class Accounts"
            '
            'CheckBoxCopy_ProductionFunctionAccounts
            '
            Me.CheckBoxCopy_ProductionFunctionAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_ProductionFunctionAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_ProductionFunctionAccounts.CheckValue = 0
            Me.CheckBoxCopy_ProductionFunctionAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_ProductionFunctionAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_ProductionFunctionAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_ProductionFunctionAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_ProductionFunctionAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_ProductionFunctionAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_ProductionFunctionAccounts.Location = New System.Drawing.Point(233, 61)
            Me.CheckBoxCopy_ProductionFunctionAccounts.Name = "CheckBoxCopy_ProductionFunctionAccounts"
            Me.CheckBoxCopy_ProductionFunctionAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_ProductionFunctionAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_ProductionFunctionAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_ProductionFunctionAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_ProductionFunctionAccounts.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxCopy_ProductionFunctionAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_ProductionFunctionAccounts.TabIndex = 4
            Me.CheckBoxCopy_ProductionFunctionAccounts.Text = "Production Function Accounts"
            '
            'CheckBoxCopy_ProductionSalesClassFunctionAccounts
            '
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.CheckValue = 0
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_ProductionSalesClassFunctionAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Location = New System.Drawing.Point(233, 35)
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Name = "CheckBoxCopy_ProductionSalesClassFunctionAccounts"
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_ProductionSalesClassFunctionAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.TabIndex = 3
            Me.CheckBoxCopy_ProductionSalesClassFunctionAccounts.Text = "Production Sales Class/Function Accounts"
            '
            'CheckBoxCopy_DefaultMediaAccounts
            '
            Me.CheckBoxCopy_DefaultMediaAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_DefaultMediaAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_DefaultMediaAccounts.CheckValue = 0
            Me.CheckBoxCopy_DefaultMediaAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_DefaultMediaAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_DefaultMediaAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_DefaultMediaAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_DefaultMediaAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultMediaAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_DefaultMediaAccounts.Location = New System.Drawing.Point(36, 87)
            Me.CheckBoxCopy_DefaultMediaAccounts.Name = "CheckBoxCopy_DefaultMediaAccounts"
            Me.CheckBoxCopy_DefaultMediaAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_DefaultMediaAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_DefaultMediaAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_DefaultMediaAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultMediaAccounts.Size = New System.Drawing.Size(176, 20)
            Me.CheckBoxCopy_DefaultMediaAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_DefaultMediaAccounts.TabIndex = 2
            Me.CheckBoxCopy_DefaultMediaAccounts.Text = "Default Media Accounts"
            '
            'CheckBoxCopy_DefaultProductionAccounts
            '
            Me.CheckBoxCopy_DefaultProductionAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_DefaultProductionAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_DefaultProductionAccounts.CheckValue = 0
            Me.CheckBoxCopy_DefaultProductionAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_DefaultProductionAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_DefaultProductionAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_DefaultProductionAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_DefaultProductionAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultProductionAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_DefaultProductionAccounts.Location = New System.Drawing.Point(36, 61)
            Me.CheckBoxCopy_DefaultProductionAccounts.Name = "CheckBoxCopy_DefaultProductionAccounts"
            Me.CheckBoxCopy_DefaultProductionAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_DefaultProductionAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_DefaultProductionAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_DefaultProductionAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultProductionAccounts.Size = New System.Drawing.Size(176, 20)
            Me.CheckBoxCopy_DefaultProductionAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_DefaultProductionAccounts.TabIndex = 1
            Me.CheckBoxCopy_DefaultProductionAccounts.Text = "Default Production Accounts"
            '
            'CheckBoxCopy_DefaultAccounts
            '
            Me.CheckBoxCopy_DefaultAccounts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCopy_DefaultAccounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCopy_DefaultAccounts.CheckValue = 0
            Me.CheckBoxCopy_DefaultAccounts.CheckValueChecked = 1
            Me.CheckBoxCopy_DefaultAccounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCopy_DefaultAccounts.CheckValueUnchecked = 0
            Me.CheckBoxCopy_DefaultAccounts.ChildControls = CType(resources.GetObject("CheckBoxCopy_DefaultAccounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCopy_DefaultAccounts.Location = New System.Drawing.Point(36, 35)
            Me.CheckBoxCopy_DefaultAccounts.Name = "CheckBoxCopy_DefaultAccounts"
            Me.CheckBoxCopy_DefaultAccounts.OldestSibling = Nothing
            Me.CheckBoxCopy_DefaultAccounts.SecurityEnabled = True
            Me.CheckBoxCopy_DefaultAccounts.SiblingControls = CType(resources.GetObject("CheckBoxCopy_DefaultAccounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCopy_DefaultAccounts.Size = New System.Drawing.Size(176, 20)
            Me.CheckBoxCopy_DefaultAccounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCopy_DefaultAccounts.TabIndex = 0
            Me.CheckBoxCopy_DefaultAccounts.Text = "Default Accounts"
            '
            'CheckBoxForm_ReplaceOfficeSegment
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValue = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueChecked = 1
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueUnchecked = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.ChildControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ReplaceOfficeSegment.Location = New System.Drawing.Point(12, 162)
            Me.CheckBoxForm_ReplaceOfficeSegment.Name = "CheckBoxForm_ReplaceOfficeSegment"
            Me.CheckBoxForm_ReplaceOfficeSegment.OldestSibling = Nothing
            Me.CheckBoxForm_ReplaceOfficeSegment.SecurityEnabled = True
            Me.CheckBoxForm_ReplaceOfficeSegment.SiblingControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxForm_ReplaceOfficeSegment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ReplaceOfficeSegment.TabIndex = 2
            Me.CheckBoxForm_ReplaceOfficeSegment.Text = "Replace Office Segment in GL Accounts"
            '
            'CopyOfficeGLAccountsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(564, 220)
            Me.Controls.Add(Me.CheckBoxForm_ReplaceOfficeSegment)
            Me.Controls.Add(Me.GroupBoxForm_Copy)
            Me.Controls.Add(Me.ButtonForm_Create)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CopyOfficeGLAccountsDialog"
            Me.Text = "Office - Copy GL Accounts"
            CType(Me.GroupBoxForm_Copy, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Copy.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Create As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxCopy_SalesTaxAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_MediaSalesClassAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_ProductionFunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_ProductionSalesClassFunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_DefaultMediaAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_DefaultProductionAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCopy_DefaultAccounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ReplaceOfficeSegment As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace