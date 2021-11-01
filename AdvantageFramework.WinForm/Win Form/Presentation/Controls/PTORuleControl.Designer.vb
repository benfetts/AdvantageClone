Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PTORuleControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTORuleControl))
            Me.DataGridViewControl_RuleDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxControl_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxControlOptions_Qualify = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControlOptions_Default = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxControl_Action = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlAction_Replace = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAction_Accrue = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxControl_PTOType = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlPTOType_Sick = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlPTOType_Vacation = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlPTOType_Personal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxControl_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.GroupBoxControl_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Options.SuspendLayout()
            CType(Me.GroupBoxControl_Action, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Action.SuspendLayout()
            CType(Me.GroupBoxControl_PTOType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_PTOType.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewControl_RuleDetails
            '
            Me.DataGridViewControl_RuleDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_RuleDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_RuleDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_RuleDetails.AutoFilterLookupColumns = False
            Me.DataGridViewControl_RuleDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_RuleDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_RuleDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_RuleDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_RuleDetails.ItemDescription = ""
            Me.DataGridViewControl_RuleDetails.Location = New System.Drawing.Point(0, 207)
            Me.DataGridViewControl_RuleDetails.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.DataGridViewControl_RuleDetails.MultiSelect = False
            Me.DataGridViewControl_RuleDetails.Name = "DataGridViewControl_RuleDetails"
            Me.DataGridViewControl_RuleDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_RuleDetails.RunStandardValidation = True
            Me.DataGridViewControl_RuleDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_RuleDetails.Size = New System.Drawing.Size(804, 272)
            Me.DataGridViewControl_RuleDetails.TabIndex = 6
            Me.DataGridViewControl_RuleDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_RuleDetails.ViewCaptionHeight = -1
            '
            'GroupBoxControl_Options
            '
            Me.GroupBoxControl_Options.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Options.Controls.Add(Me.CheckBoxControlOptions_Qualify)
            Me.GroupBoxControl_Options.Controls.Add(Me.CheckBoxControlOptions_Default)
            Me.GroupBoxControl_Options.Location = New System.Drawing.Point(341, 101)
            Me.GroupBoxControl_Options.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.GroupBoxControl_Options.Name = "GroupBoxControl_Options"
            Me.GroupBoxControl_Options.Size = New System.Drawing.Size(463, 98)
            Me.GroupBoxControl_Options.TabIndex = 5
            Me.GroupBoxControl_Options.Text = "Options"
            '
            'CheckBoxControlOptions_Qualify
            '
            '
            '
            '
            Me.CheckBoxControlOptions_Qualify.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControlOptions_Qualify.CheckValue = 0
            Me.CheckBoxControlOptions_Qualify.CheckValueChecked = 1
            Me.CheckBoxControlOptions_Qualify.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControlOptions_Qualify.CheckValueUnchecked = 0
            Me.CheckBoxControlOptions_Qualify.ChildControls = CType(resources.GetObject("CheckBoxControlOptions_Qualify.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControlOptions_Qualify.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControlOptions_Qualify.Location = New System.Drawing.Point(7, 63)
            Me.CheckBoxControlOptions_Qualify.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CheckBoxControlOptions_Qualify.Name = "CheckBoxControlOptions_Qualify"
            Me.CheckBoxControlOptions_Qualify.OldestSibling = Nothing
            Me.CheckBoxControlOptions_Qualify.SecurityEnabled = True
            Me.CheckBoxControlOptions_Qualify.SiblingControls = CType(resources.GetObject("CheckBoxControlOptions_Qualify.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControlOptions_Qualify.Size = New System.Drawing.Size(256, 25)
            Me.CheckBoxControlOptions_Qualify.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControlOptions_Qualify.TabIndex = 34
            Me.CheckBoxControlOptions_Qualify.Text = "Qualify a Partial Month As Whole?"
            '
            'CheckBoxControlOptions_Default
            '
            '
            '
            '
            Me.CheckBoxControlOptions_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControlOptions_Default.CheckValue = 0
            Me.CheckBoxControlOptions_Default.CheckValueChecked = 1
            Me.CheckBoxControlOptions_Default.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControlOptions_Default.CheckValueUnchecked = 0
            Me.CheckBoxControlOptions_Default.ChildControls = CType(resources.GetObject("CheckBoxControlOptions_Default.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControlOptions_Default.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControlOptions_Default.Location = New System.Drawing.Point(7, 31)
            Me.CheckBoxControlOptions_Default.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CheckBoxControlOptions_Default.Name = "CheckBoxControlOptions_Default"
            Me.CheckBoxControlOptions_Default.OldestSibling = Nothing
            Me.CheckBoxControlOptions_Default.SecurityEnabled = True
            Me.CheckBoxControlOptions_Default.SiblingControls = CType(resources.GetObject("CheckBoxControlOptions_Default.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControlOptions_Default.Size = New System.Drawing.Size(256, 25)
            Me.CheckBoxControlOptions_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControlOptions_Default.TabIndex = 33
            Me.CheckBoxControlOptions_Default.Text = "Default Rule for PTO Type?"
            '
            'GroupBoxControl_Action
            '
            Me.GroupBoxControl_Action.Controls.Add(Me.RadioButtonControlAction_Replace)
            Me.GroupBoxControl_Action.Controls.Add(Me.RadioButtonControlAction_Accrue)
            Me.GroupBoxControl_Action.Location = New System.Drawing.Point(0, 101)
            Me.GroupBoxControl_Action.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.GroupBoxControl_Action.Name = "GroupBoxControl_Action"
            Me.GroupBoxControl_Action.Size = New System.Drawing.Size(336, 98)
            Me.GroupBoxControl_Action.TabIndex = 4
            Me.GroupBoxControl_Action.Text = "Action"
            '
            'RadioButtonControlAction_Replace
            '
            Me.RadioButtonControlAction_Replace.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAction_Replace.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAction_Replace.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAction_Replace.Location = New System.Drawing.Point(7, 63)
            Me.RadioButtonControlAction_Replace.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlAction_Replace.Name = "RadioButtonControlAction_Replace"
            Me.RadioButtonControlAction_Replace.SecurityEnabled = True
            Me.RadioButtonControlAction_Replace.Size = New System.Drawing.Size(323, 25)
            Me.RadioButtonControlAction_Replace.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAction_Replace.TabIndex = 2
            Me.RadioButtonControlAction_Replace.TabStop = False
            Me.RadioButtonControlAction_Replace.Text = "Replace"
            '
            'RadioButtonControlAction_Accrue
            '
            Me.RadioButtonControlAction_Accrue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAction_Accrue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAction_Accrue.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAction_Accrue.Checked = True
            Me.RadioButtonControlAction_Accrue.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlAction_Accrue.CheckValue = "Y"
            Me.RadioButtonControlAction_Accrue.Location = New System.Drawing.Point(7, 31)
            Me.RadioButtonControlAction_Accrue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlAction_Accrue.Name = "RadioButtonControlAction_Accrue"
            Me.RadioButtonControlAction_Accrue.SecurityEnabled = True
            Me.RadioButtonControlAction_Accrue.Size = New System.Drawing.Size(323, 25)
            Me.RadioButtonControlAction_Accrue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAction_Accrue.TabIndex = 1
            Me.RadioButtonControlAction_Accrue.Text = "Accrue"
            '
            'GroupBoxControl_PTOType
            '
            Me.GroupBoxControl_PTOType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_PTOType.Controls.Add(Me.RadioButtonControlPTOType_Sick)
            Me.GroupBoxControl_PTOType.Controls.Add(Me.RadioButtonControlPTOType_Vacation)
            Me.GroupBoxControl_PTOType.Controls.Add(Me.RadioButtonControlPTOType_Personal)
            Me.GroupBoxControl_PTOType.Location = New System.Drawing.Point(0, 32)
            Me.GroupBoxControl_PTOType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.GroupBoxControl_PTOType.Name = "GroupBoxControl_PTOType"
            Me.GroupBoxControl_PTOType.Size = New System.Drawing.Size(804, 62)
            Me.GroupBoxControl_PTOType.TabIndex = 3
            Me.GroupBoxControl_PTOType.Text = "PTO Type"
            '
            'RadioButtonControlPTOType_Sick
            '
            Me.RadioButtonControlPTOType_Sick.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPTOType_Sick.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPTOType_Sick.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPTOType_Sick.Location = New System.Drawing.Point(149, 31)
            Me.RadioButtonControlPTOType_Sick.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlPTOType_Sick.Name = "RadioButtonControlPTOType_Sick"
            Me.RadioButtonControlPTOType_Sick.SecurityEnabled = True
            Me.RadioButtonControlPTOType_Sick.Size = New System.Drawing.Size(135, 25)
            Me.RadioButtonControlPTOType_Sick.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPTOType_Sick.TabIndex = 2
            Me.RadioButtonControlPTOType_Sick.TabStop = False
            Me.RadioButtonControlPTOType_Sick.Text = "Sick"
            '
            'RadioButtonControlPTOType_Vacation
            '
            Me.RadioButtonControlPTOType_Vacation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPTOType_Vacation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPTOType_Vacation.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPTOType_Vacation.Checked = True
            Me.RadioButtonControlPTOType_Vacation.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlPTOType_Vacation.CheckValue = "Y"
            Me.RadioButtonControlPTOType_Vacation.Location = New System.Drawing.Point(7, 31)
            Me.RadioButtonControlPTOType_Vacation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlPTOType_Vacation.Name = "RadioButtonControlPTOType_Vacation"
            Me.RadioButtonControlPTOType_Vacation.SecurityEnabled = True
            Me.RadioButtonControlPTOType_Vacation.Size = New System.Drawing.Size(135, 25)
            Me.RadioButtonControlPTOType_Vacation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPTOType_Vacation.TabIndex = 1
            Me.RadioButtonControlPTOType_Vacation.Text = "Vacation"
            '
            'RadioButtonControlPTOType_Personal
            '
            Me.RadioButtonControlPTOType_Personal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPTOType_Personal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPTOType_Personal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPTOType_Personal.Location = New System.Drawing.Point(292, 31)
            Me.RadioButtonControlPTOType_Personal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlPTOType_Personal.Name = "RadioButtonControlPTOType_Personal"
            Me.RadioButtonControlPTOType_Personal.SecurityEnabled = True
            Me.RadioButtonControlPTOType_Personal.Size = New System.Drawing.Size(135, 25)
            Me.RadioButtonControlPTOType_Personal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPTOType_Personal.TabIndex = 3
            Me.RadioButtonControlPTOType_Personal.TabStop = False
            Me.RadioButtonControlPTOType_Personal.Text = "Personal"
            '
            'TextBoxControl_Name
            '
            Me.TextBoxControl_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Name.CheckSpellingOnValidate = False
            Me.TextBoxControl_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Name.FocusHighlightEnabled = True
            Me.TextBoxControl_Name.Location = New System.Drawing.Point(64, 0)
            Me.TextBoxControl_Name.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxControl_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Name.Name = "TextBoxControl_Name"
            Me.TextBoxControl_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Name.Size = New System.Drawing.Size(647, 22)
            Me.TextBoxControl_Name.TabIndex = 1
            Me.TextBoxControl_Name.TabOnEnter = True
            '
            'LabelControl_Name
            '
            Me.LabelControl_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Name.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Name.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelControl_Name.Name = "LabelControl_Name"
            Me.LabelControl_Name.Size = New System.Drawing.Size(56, 25)
            Me.LabelControl_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Name.TabIndex = 0
            Me.LabelControl_Name.Text = "Name:"
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
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(720, 0)
            Me.CheckBoxControl_Inactive.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(84, 28)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 2
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_RuleDetails)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Name)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_Options)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_Action)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Name)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_PTOType)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(804, 479)
            Me.PanelControl_Control.TabIndex = 45
            '
            'PTORuleControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "PTORuleControl"
            Me.Size = New System.Drawing.Size(804, 479)
            CType(Me.GroupBoxControl_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Options.ResumeLayout(False)
            CType(Me.GroupBoxControl_Action, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Action.ResumeLayout(False)
            CType(Me.GroupBoxControl_PTOType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_PTOType.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxControl_PTOType As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlPTOType_Sick As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlPTOType_Vacation As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlPTOType_Personal As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxControl_Action As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlAction_Replace As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAction_Accrue As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxControl_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxControlOptions_Qualify As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxControlOptions_Default As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewControl_RuleDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
