Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableApprovalDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableApprovalDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelApproval_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelApproval_Comments = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_Approval = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxForm_OnHold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxApproval_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxApproval_Status = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_ApprovalHistory = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelFormNotice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_Approval, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Approval.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(260, 388)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(341, 388)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelApproval_Status
            '
            Me.LabelApproval_Status.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelApproval_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelApproval_Status.Location = New System.Drawing.Point(5, 26)
            Me.LabelApproval_Status.Name = "LabelApproval_Status"
            Me.LabelApproval_Status.Size = New System.Drawing.Size(45, 20)
            Me.LabelApproval_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelApproval_Status.TabIndex = 0
            Me.LabelApproval_Status.Text = "Status:"
            '
            'LabelApproval_Comments
            '
            Me.LabelApproval_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelApproval_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelApproval_Comments.Location = New System.Drawing.Point(5, 52)
            Me.LabelApproval_Comments.Name = "LabelApproval_Comments"
            Me.LabelApproval_Comments.Size = New System.Drawing.Size(73, 20)
            Me.LabelApproval_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelApproval_Comments.TabIndex = 3
            Me.LabelApproval_Comments.Text = "Comments:"
            '
            'GroupBoxForm_Approval
            '
            Me.GroupBoxForm_Approval.Controls.Add(Me.CheckBoxForm_OnHold)
            Me.GroupBoxForm_Approval.Controls.Add(Me.TextBoxApproval_Comments)
            Me.GroupBoxForm_Approval.Controls.Add(Me.ComboBoxApproval_Status)
            Me.GroupBoxForm_Approval.Controls.Add(Me.LabelApproval_Status)
            Me.GroupBoxForm_Approval.Controls.Add(Me.LabelApproval_Comments)
            Me.GroupBoxForm_Approval.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_Approval.Name = "GroupBoxForm_Approval"
            Me.GroupBoxForm_Approval.Size = New System.Drawing.Size(404, 123)
            Me.GroupBoxForm_Approval.TabIndex = 0
            Me.GroupBoxForm_Approval.Text = "Set Approval Status"
            '
            'CheckBoxForm_OnHold
            '
            '
            '
            '
            Me.CheckBoxForm_OnHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_OnHold.CheckValue = 0
            Me.CheckBoxForm_OnHold.CheckValueChecked = 1
            Me.CheckBoxForm_OnHold.CheckValueUnchecked = 0
            Me.CheckBoxForm_OnHold.ChildControls = Nothing
            Me.CheckBoxForm_OnHold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_OnHold.Enabled = False
            Me.CheckBoxForm_OnHold.Location = New System.Drawing.Point(269, 26)
            Me.CheckBoxForm_OnHold.Name = "CheckBoxForm_OnHold"
            Me.CheckBoxForm_OnHold.OldestSibling = Nothing
            Me.CheckBoxForm_OnHold.SecurityEnabled = True
            Me.CheckBoxForm_OnHold.SiblingControls = Nothing
            Me.CheckBoxForm_OnHold.Size = New System.Drawing.Size(130, 20)
            Me.CheckBoxForm_OnHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_OnHold.TabIndex = 2
            Me.CheckBoxForm_OnHold.Text = "Place A/P on Hold"
            '
            'TextBoxApproval_Comments
            '
            Me.TextBoxApproval_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxApproval_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxApproval_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxApproval_Comments.CheckSpellingOnValidate = False
            Me.TextBoxApproval_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxApproval_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxApproval_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxApproval_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxApproval_Comments.FocusHighlightEnabled = True
            Me.TextBoxApproval_Comments.Location = New System.Drawing.Point(84, 52)
            Me.TextBoxApproval_Comments.Multiline = True
            Me.TextBoxApproval_Comments.Name = "TextBoxApproval_Comments"
            Me.TextBoxApproval_Comments.Size = New System.Drawing.Size(315, 66)
            Me.TextBoxApproval_Comments.TabIndex = 4
            Me.TextBoxApproval_Comments.TabOnEnter = True
            '
            'ComboBoxApproval_Status
            '
            Me.ComboBoxApproval_Status.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxApproval_Status.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxApproval_Status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxApproval_Status.AutoSelectSingleItemDatasource = False
            Me.ComboBoxApproval_Status.BookmarkingEnabled = False
            Me.ComboBoxApproval_Status.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxApproval_Status.DisableMouseWheel = True
            Me.ComboBoxApproval_Status.DisplayName = "Status"
            Me.ComboBoxApproval_Status.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxApproval_Status.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxApproval_Status.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxApproval_Status.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxApproval_Status.FocusHighlightEnabled = True
            Me.ComboBoxApproval_Status.FormattingEnabled = True
            Me.ComboBoxApproval_Status.ItemHeight = 14
            Me.ComboBoxApproval_Status.Location = New System.Drawing.Point(84, 26)
            Me.ComboBoxApproval_Status.Name = "ComboBoxApproval_Status"
            Me.ComboBoxApproval_Status.PreventEnterBeep = False
            Me.ComboBoxApproval_Status.ReadOnly = False
            Me.ComboBoxApproval_Status.Size = New System.Drawing.Size(179, 20)
            Me.ComboBoxApproval_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxApproval_Status.TabIndex = 1
            '
            'DataGridViewForm_ApprovalHistory
            '
            Me.DataGridViewForm_ApprovalHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ApprovalHistory.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ApprovalHistory.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ApprovalHistory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_ApprovalHistory.DataSource = Nothing
            Me.DataGridViewForm_ApprovalHistory.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ApprovalHistory.ItemDescription = ""
            Me.DataGridViewForm_ApprovalHistory.Location = New System.Drawing.Point(12, 170)
            Me.DataGridViewForm_ApprovalHistory.MultiSelect = True
            Me.DataGridViewForm_ApprovalHistory.Name = "DataGridViewForm_ApprovalHistory"
            Me.DataGridViewForm_ApprovalHistory.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ApprovalHistory.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ApprovalHistory.Size = New System.Drawing.Size(404, 212)
            Me.DataGridViewForm_ApprovalHistory.TabIndex = 1
            Me.DataGridViewForm_ApprovalHistory.TabStop = False
            Me.DataGridViewForm_ApprovalHistory.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ApprovalHistory.ViewCaptionHeight = -1
            '
            'LabelFormNotice
            '
            Me.LabelFormNotice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFormNotice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFormNotice.Location = New System.Drawing.Point(13, 141)
            Me.LabelFormNotice.Name = "LabelFormNotice"
            Me.LabelFormNotice.Size = New System.Drawing.Size(403, 23)
            Me.LabelFormNotice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFormNotice.TabIndex = 4
            Me.LabelFormNotice.Text = "Approval History - (*) Identifies Current Status"
            '
            'AccountsPayableApprovalDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(428, 420)
            Me.Controls.Add(Me.LabelFormNotice)
            Me.Controls.Add(Me.DataGridViewForm_ApprovalHistory)
            Me.Controls.Add(Me.GroupBoxForm_Approval)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableApprovalDialog"
            Me.Text = "AP Line Item Approval"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_Approval, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Approval.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelApproval_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelApproval_Comments As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Approval As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxApproval_Status As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxApproval_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_OnHold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_ApprovalHistory As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelFormNotice As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace