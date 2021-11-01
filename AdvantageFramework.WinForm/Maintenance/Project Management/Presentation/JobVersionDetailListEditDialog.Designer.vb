Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobVersionDetailListEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobVersionDetailListEditDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_List = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_JobVersionTemplateListValues = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_List = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(277, 328)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 4
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(358, 328)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_List
            '
            Me.LabelForm_List.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_List.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_List.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_List.Name = "LabelForm_List"
            Me.LabelForm_List.Size = New System.Drawing.Size(29, 20)
            Me.LabelForm_List.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_List.TabIndex = 0
            Me.LabelForm_List.Text = "List:"
            '
            'DataGridViewForm_JobVersionTemplateListValues
            '
            Me.DataGridViewForm_JobVersionTemplateListValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_JobVersionTemplateListValues.AutoFilterLookupColumns = False
            Me.DataGridViewForm_JobVersionTemplateListValues.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_JobVersionTemplateListValues.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_JobVersionTemplateListValues.DataSource = Nothing
            Me.DataGridViewForm_JobVersionTemplateListValues.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_JobVersionTemplateListValues.ItemDescription = ""
            Me.DataGridViewForm_JobVersionTemplateListValues.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_JobVersionTemplateListValues.MultiSelect = True
            Me.DataGridViewForm_JobVersionTemplateListValues.Name = "DataGridViewForm_JobVersionTemplateListValues"
            Me.DataGridViewForm_JobVersionTemplateListValues.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_JobVersionTemplateListValues.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_JobVersionTemplateListValues.Size = New System.Drawing.Size(421, 284)
            Me.DataGridViewForm_JobVersionTemplateListValues.TabIndex = 2
            Me.DataGridViewForm_JobVersionTemplateListValues.UseEmbeddedNavigator = False
            Me.DataGridViewForm_JobVersionTemplateListValues.ViewCaptionHeight = -1
            '
            'ButtonForm_Delete
            '
            Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Delete.Location = New System.Drawing.Point(12, 328)
            Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
            Me.ButtonForm_Delete.SecurityEnabled = True
            Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Delete.TabIndex = 3
            Me.ButtonForm_Delete.Text = "Delete"
            '
            'ComboBoxForm_List
            '
            Me.ComboBoxForm_List.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_List.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_List.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_List.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_List.BookmarkingEnabled = False
            Me.ComboBoxForm_List.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.JobVersionTemplateDetail
            Me.ComboBoxForm_List.DisableMouseWheel = False
            Me.ComboBoxForm_List.DisplayMember = "Description"
            Me.ComboBoxForm_List.DisplayName = ""
            Me.ComboBoxForm_List.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_List.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_List.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_List.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_List.FocusHighlightEnabled = True
            Me.ComboBoxForm_List.FormattingEnabled = True
            Me.ComboBoxForm_List.ItemHeight = 14
            Me.ComboBoxForm_List.Location = New System.Drawing.Point(47, 12)
            Me.ComboBoxForm_List.Name = "ComboBoxForm_List"
            Me.ComboBoxForm_List.PreventEnterBeep = False
            Me.ComboBoxForm_List.ReadOnly = False
            Me.ComboBoxForm_List.Size = New System.Drawing.Size(386, 20)
            Me.ComboBoxForm_List.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_List.TabIndex = 1
            Me.ComboBoxForm_List.ValueMember = "ID"
            Me.ComboBoxForm_List.WatermarkText = "Select"
            '
            'JobVersionDetailListEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(445, 360)
            Me.Controls.Add(Me.ComboBoxForm_List)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.DataGridViewForm_JobVersionTemplateListValues)
            Me.Controls.Add(Me.LabelForm_List)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobVersionDetailListEditDialog"
            Me.Text = "Job Version Template Detail List Values"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_List As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_JobVersionTemplateListValues As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_List As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace