Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientDiscountControl
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
            Me.DataGridViewControl_Exclusions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.PanelControl_Panel = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxControl_IsInactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelControl_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.NumericInputControl_Percent = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_Percent = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Panel.SuspendLayout()
            CType(Me.NumericInputControl_Percent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewControl_Exclusions
            '
            Me.DataGridViewControl_Exclusions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_Exclusions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_Exclusions.AutoUpdateViewCaption = True
            Me.DataGridViewControl_Exclusions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_Exclusions.ItemDescription = "Exclusion(s)"
            Me.DataGridViewControl_Exclusions.Location = New System.Drawing.Point(0, 53)
            Me.DataGridViewControl_Exclusions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_Exclusions.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_Exclusions.ModifyGridRowHeight = False
            Me.DataGridViewControl_Exclusions.MultiSelect = True
            Me.DataGridViewControl_Exclusions.Name = "DataGridViewControl_Exclusions"
            Me.DataGridViewControl_Exclusions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_Exclusions.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_Exclusions.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_Exclusions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_Exclusions.Size = New System.Drawing.Size(424, 365)
            Me.DataGridViewControl_Exclusions.TabIndex = 7
            Me.DataGridViewControl_Exclusions.UseEmbeddedNavigator = False
            Me.DataGridViewControl_Exclusions.ViewCaptionHeight = -1
            '
            'PanelControl_Panel
            '
            Me.PanelControl_Panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Panel.Controls.Add(Me.CheckBoxControl_IsInactive)
            Me.PanelControl_Panel.Controls.Add(Me.LabelControl_Name)
            Me.PanelControl_Panel.Controls.Add(Me.TextBoxControl_Name)
            Me.PanelControl_Panel.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_Panel.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Panel.Controls.Add(Me.NumericInputControl_Percent)
            Me.PanelControl_Panel.Controls.Add(Me.LabelControl_Percent)
            Me.PanelControl_Panel.Controls.Add(Me.DataGridViewControl_Exclusions)
            Me.PanelControl_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Panel.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Panel.Name = "PanelControl_Panel"
            Me.PanelControl_Panel.Size = New System.Drawing.Size(424, 418)
            Me.PanelControl_Panel.TabIndex = 0
            '
            'CheckBoxControl_IsInactive
            '
            Me.CheckBoxControl_IsInactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_IsInactive.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxControl_IsInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IsInactive.CheckValue = 0
            Me.CheckBoxControl_IsInactive.CheckValueChecked = 1
            Me.CheckBoxControl_IsInactive.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IsInactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_IsInactive.ChildControls = Nothing
            Me.CheckBoxControl_IsInactive.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IsInactive.Location = New System.Drawing.Point(138, 26)
            Me.CheckBoxControl_IsInactive.Name = "CheckBoxControl_IsInactive"
            Me.CheckBoxControl_IsInactive.OldestSibling = Nothing
            Me.CheckBoxControl_IsInactive.SecurityEnabled = True
            Me.CheckBoxControl_IsInactive.SiblingControls = Nothing
            Me.CheckBoxControl_IsInactive.Size = New System.Drawing.Size(286, 20)
            Me.CheckBoxControl_IsInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IsInactive.TabIndex = 8
            Me.CheckBoxControl_IsInactive.TabOnEnter = True
            Me.CheckBoxControl_IsInactive.Text = "Inactive"
            '
            'LabelControl_Name
            '
            Me.LabelControl_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Name.Location = New System.Drawing.Point(138, 0)
            Me.LabelControl_Name.Name = "LabelControl_Name"
            Me.LabelControl_Name.Size = New System.Drawing.Size(48, 20)
            Me.LabelControl_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Name.TabIndex = 2
            Me.LabelControl_Name.Text = "Name:"
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
            Me.TextBoxControl_Name.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Name.FocusHighlightEnabled = True
            Me.TextBoxControl_Name.Location = New System.Drawing.Point(192, 0)
            Me.TextBoxControl_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Name.Name = "TextBoxControl_Name"
            Me.TextBoxControl_Name.PreventEnterBeep = True
            Me.TextBoxControl_Name.SecurityEnabled = True
            Me.TextBoxControl_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Name.Size = New System.Drawing.Size(232, 21)
            Me.TextBoxControl_Name.StartingFolderName = Nothing
            Me.TextBoxControl_Name.TabIndex = 3
            Me.TextBoxControl_Name.TabOnEnter = True
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(60, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 0
            Me.LabelControl_Code.Text = "Code:"
            '
            'TextBoxControl_Code
            '
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(66, 0)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.PreventEnterBeep = True
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(66, 21)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'NumericInputControl_Percent
            '
            Me.NumericInputControl_Percent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_Percent.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.Percent
            Me.NumericInputControl_Percent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_Percent.EnterMoveNextControl = True
            Me.NumericInputControl_Percent.Location = New System.Drawing.Point(66, 26)
            Me.NumericInputControl_Percent.Name = "NumericInputControl_Percent"
            Me.NumericInputControl_Percent.Properties.AllowMouseWheel = False
            Me.NumericInputControl_Percent.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_Percent.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_Percent.Properties.DisplayFormat.FormatString = "p2"
            Me.NumericInputControl_Percent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Percent.Properties.EditFormat.FormatString = "p2"
            Me.NumericInputControl_Percent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Percent.Properties.Mask.EditMask = "p2"
            Me.NumericInputControl_Percent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_Percent.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputControl_Percent.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputControl_Percent.SecurityEnabled = True
            Me.NumericInputControl_Percent.Size = New System.Drawing.Size(66, 20)
            Me.NumericInputControl_Percent.TabIndex = 5
            '
            'LabelControl_Percent
            '
            Me.LabelControl_Percent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Percent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Percent.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_Percent.Name = "LabelControl_Percent"
            Me.LabelControl_Percent.Size = New System.Drawing.Size(60, 20)
            Me.LabelControl_Percent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Percent.TabIndex = 4
            Me.LabelControl_Percent.Text = "Percent:"
            '
            'DiscountControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Panel)
            Me.Name = "DiscountControl"
            Me.Size = New System.Drawing.Size(424, 418)
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Panel.ResumeLayout(False)
            CType(Me.NumericInputControl_Percent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Public WithEvents DataGridViewControl_Exclusions As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Panel As WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelControl_Name As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Name As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents NumericInputControl_Percent As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_Percent As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_IsInactive As CheckBox
    End Class

End Namespace
