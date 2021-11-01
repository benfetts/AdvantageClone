﻿Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderApprovalRuleControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderApprovalRuleControl))
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'CheckBoxControl_Inactive
            '
            Me.CheckBoxControl_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(824, 0)
            Me.CheckBoxControl_Inactive.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(107, 25)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 4
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'DataGridViewControl_PurchaseOrderApprovalRuleDetails
            '
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.AutoFilterLookupColumns = False
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.DataSource = Nothing
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.ItemDescription = ""
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.Location = New System.Drawing.Point(0, 32)
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.MultiSelect = True
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.Name = "DataGridViewControl_PurchaseOrderApprovalRuleDetails"
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.RunStandardValidation = True
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.Size = New System.Drawing.Size(931, 412)
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.TabIndex = 5
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails.ViewCaptionHeight = -1
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(268, 0)
            Me.TextBoxControl_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(548, 22)
            Me.TextBoxControl_Description.TabIndex = 3
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'TextBoxControl_Code
            '
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(63, 0)
            Me.TextBoxControl_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(103, 22)
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(173, 0)
            Me.LabelForm_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(87, 25)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(55, 25)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_PurchaseOrderApprovalRuleDetails)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(931, 444)
            Me.PanelControl_Control.TabIndex = 45
            '
            'PurchaseOrderApprovalRuleControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "PurchaseOrderApprovalRuleControl"
            Me.Size = New System.Drawing.Size(931, 444)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Protected Friend WithEvents DataGridViewControl_PurchaseOrderApprovalRuleDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
