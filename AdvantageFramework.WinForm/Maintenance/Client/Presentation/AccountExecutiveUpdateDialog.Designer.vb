Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountExecutiveUpdateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountExecutiveUpdateDialog))
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_NewAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_NewAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CurrentAE = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_UpdateOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_AssignToOpen = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_AssignToClosed = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_MakeInactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_SetAsDefault = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewForm_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_CurrentAEDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(480, 497)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 10
            Me.ButtonForm_Update.Text = "Update"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(561, 497)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_NewAccountExecutive
            '
            Me.ComboBoxForm_NewAccountExecutive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_NewAccountExecutive.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_NewAccountExecutive.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_NewAccountExecutive.BookmarkingEnabled = False
            Me.ComboBoxForm_NewAccountExecutive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxForm_NewAccountExecutive.DisplayMember = "FullName"
            Me.ComboBoxForm_NewAccountExecutive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_NewAccountExecutive.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_NewAccountExecutive.FocusHighlightEnabled = True
            Me.ComboBoxForm_NewAccountExecutive.FormattingEnabled = True
            Me.ComboBoxForm_NewAccountExecutive.ItemHeight = 14
            Me.ComboBoxForm_NewAccountExecutive.Location = New System.Drawing.Point(82, 38)
            Me.ComboBoxForm_NewAccountExecutive.Name = "ComboBoxForm_NewAccountExecutive"
            Me.ComboBoxForm_NewAccountExecutive.PreventEnterBeep = False
            Me.ComboBoxForm_NewAccountExecutive.Size = New System.Drawing.Size(554, 20)
            Me.ComboBoxForm_NewAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_NewAccountExecutive.TabIndex = 3
            Me.ComboBoxForm_NewAccountExecutive.ValueMember = "Code"
            Me.ComboBoxForm_NewAccountExecutive.WatermarkText = "Select Employee"
            '
            'LabelForm_NewAccountExecutive
            '
            Me.LabelForm_NewAccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_NewAccountExecutive.BackgroundStyle.Class = ""
            Me.LabelForm_NewAccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_NewAccountExecutive.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_NewAccountExecutive.Name = "LabelForm_NewAccountExecutive"
            Me.LabelForm_NewAccountExecutive.Size = New System.Drawing.Size(64, 20)
            Me.LabelForm_NewAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_NewAccountExecutive.TabIndex = 2
            Me.LabelForm_NewAccountExecutive.Text = "New A/E:"
            '
            'LabelForm_CurrentAE
            '
            Me.LabelForm_CurrentAE.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentAE.BackgroundStyle.Class = ""
            Me.LabelForm_CurrentAE.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentAE.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_CurrentAE.Name = "LabelForm_CurrentAE"
            Me.LabelForm_CurrentAE.Size = New System.Drawing.Size(64, 20)
            Me.LabelForm_CurrentAE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentAE.TabIndex = 0
            Me.LabelForm_CurrentAE.Text = "Current A/E:"
            '
            'LabelForm_UpdateOptions
            '
            Me.LabelForm_UpdateOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_UpdateOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateOptions.BackgroundStyle.Class = ""
            Me.LabelForm_UpdateOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UpdateOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_UpdateOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_UpdateOptions.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_UpdateOptions.Name = "LabelForm_UpdateOptions"
            Me.LabelForm_UpdateOptions.Size = New System.Drawing.Size(624, 20)
            Me.LabelForm_UpdateOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UpdateOptions.TabIndex = 4
            Me.LabelForm_UpdateOptions.Text = "Update Options"
            '
            'CheckBoxForm_AssignToOpen
            '
            Me.CheckBoxForm_AssignToOpen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_AssignToOpen.BackgroundStyle.Class = ""
            Me.CheckBoxForm_AssignToOpen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AssignToOpen.CheckValue = 0
            Me.CheckBoxForm_AssignToOpen.CheckValueChecked = 1
            Me.CheckBoxForm_AssignToOpen.CheckValueUnchecked = 0
            Me.CheckBoxForm_AssignToOpen.ChildControls = CType(resources.GetObject("CheckBoxForm_AssignToOpen.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AssignToOpen.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AssignToOpen.Location = New System.Drawing.Point(12, 90)
            Me.CheckBoxForm_AssignToOpen.Name = "CheckBoxForm_AssignToOpen"
            Me.CheckBoxForm_AssignToOpen.OldestSibling = Nothing
            Me.CheckBoxForm_AssignToOpen.SiblingControls = CType(resources.GetObject("CheckBoxForm_AssignToOpen.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AssignToOpen.Size = New System.Drawing.Size(624, 20)
            Me.CheckBoxForm_AssignToOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AssignToOpen.TabIndex = 5
            Me.CheckBoxForm_AssignToOpen.Text = "Assign new A/E to open jobs assigned to current A/E (will be added to the A/E lis" & _
        "t if it does not exist for selected C/D/P's)"
            '
            'CheckBoxForm_AssignToClosed
            '
            Me.CheckBoxForm_AssignToClosed.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_AssignToClosed.BackgroundStyle.Class = ""
            Me.CheckBoxForm_AssignToClosed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AssignToClosed.CheckValue = 0
            Me.CheckBoxForm_AssignToClosed.CheckValueChecked = 1
            Me.CheckBoxForm_AssignToClosed.CheckValueUnchecked = 0
            Me.CheckBoxForm_AssignToClosed.ChildControls = CType(resources.GetObject("CheckBoxForm_AssignToClosed.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AssignToClosed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AssignToClosed.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_AssignToClosed.Name = "CheckBoxForm_AssignToClosed"
            Me.CheckBoxForm_AssignToClosed.OldestSibling = Nothing
            Me.CheckBoxForm_AssignToClosed.SiblingControls = CType(resources.GetObject("CheckBoxForm_AssignToClosed.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AssignToClosed.Size = New System.Drawing.Size(624, 20)
            Me.CheckBoxForm_AssignToClosed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AssignToClosed.TabIndex = 6
            Me.CheckBoxForm_AssignToClosed.Text = "Assign new A/E to closed jobs assigned to current A/E (will be added to the A/E l" & _
        "ist if it does not exist for selected C/D/P's)"
            '
            'CheckBoxForm_MakeInactive
            '
            Me.CheckBoxForm_MakeInactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_MakeInactive.BackgroundStyle.Class = ""
            Me.CheckBoxForm_MakeInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_MakeInactive.CheckValue = 0
            Me.CheckBoxForm_MakeInactive.CheckValueChecked = 1
            Me.CheckBoxForm_MakeInactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_MakeInactive.ChildControls = CType(resources.GetObject("CheckBoxForm_MakeInactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_MakeInactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_MakeInactive.Location = New System.Drawing.Point(12, 142)
            Me.CheckBoxForm_MakeInactive.Name = "CheckBoxForm_MakeInactive"
            Me.CheckBoxForm_MakeInactive.OldestSibling = Nothing
            Me.CheckBoxForm_MakeInactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_MakeInactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_MakeInactive.Size = New System.Drawing.Size(624, 20)
            Me.CheckBoxForm_MakeInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_MakeInactive.TabIndex = 7
            Me.CheckBoxForm_MakeInactive.Text = "Make current A/E Inactive"
            '
            'CheckBoxForm_SetAsDefault
            '
            Me.CheckBoxForm_SetAsDefault.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_SetAsDefault.BackgroundStyle.Class = ""
            Me.CheckBoxForm_SetAsDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SetAsDefault.CheckValue = 0
            Me.CheckBoxForm_SetAsDefault.CheckValueChecked = 1
            Me.CheckBoxForm_SetAsDefault.CheckValueUnchecked = 0
            Me.CheckBoxForm_SetAsDefault.ChildControls = CType(resources.GetObject("CheckBoxForm_SetAsDefault.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SetAsDefault.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SetAsDefault.Location = New System.Drawing.Point(12, 168)
            Me.CheckBoxForm_SetAsDefault.Name = "CheckBoxForm_SetAsDefault"
            Me.CheckBoxForm_SetAsDefault.OldestSibling = Nothing
            Me.CheckBoxForm_SetAsDefault.SiblingControls = CType(resources.GetObject("CheckBoxForm_SetAsDefault.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SetAsDefault.Size = New System.Drawing.Size(624, 20)
            Me.CheckBoxForm_SetAsDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SetAsDefault.TabIndex = 8
            Me.CheckBoxForm_SetAsDefault.Text = "Assign new A/E as default A/E"
            '
            'DataGridViewForm_Products
            '
            Me.DataGridViewForm_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Products.DataSource = Nothing
            Me.DataGridViewForm_Products.ItemDescription = "Product(s)"
            Me.DataGridViewForm_Products.Location = New System.Drawing.Point(12, 194)
            Me.DataGridViewForm_Products.MultiSelect = True
            Me.DataGridViewForm_Products.Name = "DataGridViewForm_Products"
            Me.DataGridViewForm_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Products.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Products.Size = New System.Drawing.Size(624, 297)
            Me.DataGridViewForm_Products.TabIndex = 9
            '
            'LabelForm_CurrentAEDescription
            '
            Me.LabelForm_CurrentAEDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CurrentAEDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentAEDescription.BackgroundStyle.Class = ""
            Me.LabelForm_CurrentAEDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentAEDescription.Location = New System.Drawing.Point(82, 12)
            Me.LabelForm_CurrentAEDescription.Name = "LabelForm_CurrentAEDescription"
            Me.LabelForm_CurrentAEDescription.Size = New System.Drawing.Size(554, 20)
            Me.LabelForm_CurrentAEDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentAEDescription.TabIndex = 12
            '
            'AccountExecutiveUpdateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(648, 529)
            Me.Controls.Add(Me.LabelForm_CurrentAEDescription)
            Me.Controls.Add(Me.DataGridViewForm_Products)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_CurrentAE)
            Me.Controls.Add(Me.LabelForm_UpdateOptions)
            Me.Controls.Add(Me.CheckBoxForm_SetAsDefault)
            Me.Controls.Add(Me.CheckBoxForm_MakeInactive)
            Me.Controls.Add(Me.CheckBoxForm_AssignToOpen)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.CheckBoxForm_AssignToClosed)
            Me.Controls.Add(Me.LabelForm_NewAccountExecutive)
            Me.Controls.Add(Me.ComboBoxForm_NewAccountExecutive)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountExecutiveUpdateDialog"
            Me.Text = "Account Executive Update"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_NewAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_NewAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CurrentAE As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_UpdateOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_AssignToOpen As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_AssignToClosed As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_MakeInactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_SetAsDefault As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_CurrentAEDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace