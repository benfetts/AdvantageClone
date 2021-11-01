Namespace Security.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportSelectionDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectionDialog))
            Me.LabelForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_View = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_Selection = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxForm_ShowOnlyAccessibleModules = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeelOffice2010Blue.LookAndFeel.SkinName = "Office 2010 Blue"
            '
            'LabelForm_Report
            '
            Me.LabelForm_Report.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelForm_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Report.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Report.Name = "LabelForm_Report"
            Me.LabelForm_Report.Size = New System.Drawing.Size(39, 20)
            Me.LabelForm_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Report.TabIndex = 0
            Me.LabelForm_Report.Text = "Report:"
            '
            'ButtonForm_View
            '
            Me.ButtonForm_View.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_View.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_View.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_View.Location = New System.Drawing.Point(515, 406)
            Me.ButtonForm_View.Name = "ButtonForm_View"
            Me.ButtonForm_View.SecurityEnabled = True
            Me.ButtonForm_View.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_View.TabIndex = 6
            Me.ButtonForm_View.Text = "View"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(596, 406)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_Report
            '
            Me.ComboBoxForm_Report.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Report.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Report.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Report.BookmarkingEnabled = False
            Me.ComboBoxForm_Report.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Report.DisableMouseWheel = False
            Me.ComboBoxForm_Report.DisplayMember = "Name"
            Me.ComboBoxForm_Report.DisplayName = ""
            Me.ComboBoxForm_Report.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Report.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Report.FocusHighlightEnabled = True
            Me.ComboBoxForm_Report.FormattingEnabled = True
            Me.ComboBoxForm_Report.ItemHeight = 14
            Me.ComboBoxForm_Report.Location = New System.Drawing.Point(57, 12)
            Me.ComboBoxForm_Report.Name = "ComboBoxForm_Report"
            Me.ComboBoxForm_Report.PreventEnterBeep = True
            Me.ComboBoxForm_Report.Size = New System.Drawing.Size(614, 20)
            Me.ComboBoxForm_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Report.TabIndex = 1
            Me.ComboBoxForm_Report.ValueMember = "Value"
            Me.ComboBoxForm_Report.WatermarkText = "Select"
            '
            'DataGridViewForm_Selection
            '
            Me.DataGridViewForm_Selection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Selection.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Selection.DataSource = Nothing
            Me.DataGridViewForm_Selection.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Selection.ItemDescription = ""
            Me.DataGridViewForm_Selection.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_Selection.MultiSelect = True
            Me.DataGridViewForm_Selection.Name = "DataGridViewForm_Selection"
            Me.DataGridViewForm_Selection.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Selection.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Selection.Size = New System.Drawing.Size(659, 336)
            Me.DataGridViewForm_Selection.TabIndex = 5
            Me.DataGridViewForm_Selection.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Selection.ViewCaptionHeight = -1
            '
            'RadioButtonForm_Select
            '
            '
            '
            '
            Me.RadioButtonForm_Select.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Select.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Select.Location = New System.Drawing.Point(57, 38)
            Me.RadioButtonForm_Select.Name = "RadioButtonForm_Select"
            Me.RadioButtonForm_Select.Size = New System.Drawing.Size(57, 20)
            Me.RadioButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Select.TabIndex = 3
            Me.RadioButtonForm_Select.TabStop = False
            Me.RadioButtonForm_Select.Text = "Select"
            '
            'RadioButtonForm_All
            '
            '
            '
            '
            Me.RadioButtonForm_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_All.Checked = True
            Me.RadioButtonForm_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_All.CheckValue = "Y"
            Me.RadioButtonForm_All.Location = New System.Drawing.Point(12, 38)
            Me.RadioButtonForm_All.Name = "RadioButtonForm_All"
            Me.RadioButtonForm_All.Size = New System.Drawing.Size(39, 20)
            Me.RadioButtonForm_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_All.TabIndex = 2
            Me.RadioButtonForm_All.Text = "All"
            '
            'CheckBoxForm_ShowOnlyAccessibleModules
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Location = New System.Drawing.Point(493, 38)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Name = "CheckBoxForm_ShowOnlyAccessibleModules"
            Me.CheckBoxForm_ShowOnlyAccessibleModules.OldestSibling = Nothing
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SecurityEnabled = True
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowOnlyAccessibleModules.TabIndex = 4
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Text = "Show Only Accessible Modules"
            '
            'ReportSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(683, 438)
            Me.Controls.Add(Me.ComboBoxForm_Report)
            Me.Controls.Add(Me.LabelForm_Report)
            Me.Controls.Add(Me.CheckBoxForm_ShowOnlyAccessibleModules)
            Me.Controls.Add(Me.RadioButtonForm_Select)
            Me.Controls.Add(Me.RadioButtonForm_All)
            Me.Controls.Add(Me.DataGridViewForm_Selection)
            Me.Controls.Add(Me.ButtonForm_View)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ReportSelectionDialog"
            Me.Text = "Select Report"
            CType(Me._ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Report As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_View As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Report As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_Selection As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxForm_ShowOnlyAccessibleModules As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace