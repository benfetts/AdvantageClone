Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientMediaSalesClassOverrideCopyDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientMediaSalesClassOverrideCopyDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_DeleteExistingOverrides = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewForm_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_CopyTo = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_CopyToOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(646, 480)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 52
            Me.ButtonForm_Close.Text = "Close"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(565, 480)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 51
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'CheckBoxForm_DeleteExistingOverrides
            '
            '
            '
            '
            Me.CheckBoxForm_DeleteExistingOverrides.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_DeleteExistingOverrides.CheckValue = 0
            Me.CheckBoxForm_DeleteExistingOverrides.CheckValueChecked = 1
            Me.CheckBoxForm_DeleteExistingOverrides.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_DeleteExistingOverrides.CheckValueUnchecked = 0
            Me.CheckBoxForm_DeleteExistingOverrides.ChildControls = CType(resources.GetObject("CheckBoxForm_DeleteExistingOverrides.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DeleteExistingOverrides.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_DeleteExistingOverrides.Location = New System.Drawing.Point(12, 454)
            Me.CheckBoxForm_DeleteExistingOverrides.Name = "CheckBoxForm_DeleteExistingOverrides"
            Me.CheckBoxForm_DeleteExistingOverrides.OldestSibling = Nothing
            Me.CheckBoxForm_DeleteExistingOverrides.SecurityEnabled = True
            Me.CheckBoxForm_DeleteExistingOverrides.SiblingControls = CType(resources.GetObject("CheckBoxForm_DeleteExistingOverrides.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_DeleteExistingOverrides.Size = New System.Drawing.Size(656, 20)
            Me.CheckBoxForm_DeleteExistingOverrides.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_DeleteExistingOverrides.TabIndex = 44
            Me.CheckBoxForm_DeleteExistingOverrides.TabOnEnter = True
            Me.CheckBoxForm_DeleteExistingOverrides.Text = "Delete Existing Overrides"
            Me.CheckBoxForm_DeleteExistingOverrides.Visible = False
            '
            'DataGridViewForm_CopyFrom
            '
            Me.DataGridViewForm_CopyFrom.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CopyFrom.AllowDragAndDrop = False
            Me.DataGridViewForm_CopyFrom.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CopyFrom.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CopyFrom.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CopyFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CopyFrom.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CopyFrom.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CopyFrom.AutoUpdateViewCaption = False
            Me.DataGridViewForm_CopyFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CopyFrom.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CopyFrom.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CopyFrom.ItemDescription = "Copy From"
            Me.DataGridViewForm_CopyFrom.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_CopyFrom.MultiSelect = False
            Me.DataGridViewForm_CopyFrom.Name = "DataGridViewForm_CopyFrom"
            Me.DataGridViewForm_CopyFrom.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CopyFrom.RunStandardValidation = True
            Me.DataGridViewForm_CopyFrom.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CopyFrom.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CopyFrom.Size = New System.Drawing.Size(709, 81)
            Me.DataGridViewForm_CopyFrom.TabIndex = 53
            Me.DataGridViewForm_CopyFrom.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CopyFrom.ViewCaptionHeight = -1
            '
            'DataGridViewForm_CopyTo
            '
            Me.DataGridViewForm_CopyTo.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CopyTo.AllowDragAndDrop = False
            Me.DataGridViewForm_CopyTo.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CopyTo.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CopyTo.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CopyTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CopyTo.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CopyTo.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CopyTo.AutoUpdateViewCaption = False
            Me.DataGridViewForm_CopyTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CopyTo.DataSource = Nothing
            Me.DataGridViewForm_CopyTo.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CopyTo.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CopyTo.ItemDescription = "Copy To"
            Me.DataGridViewForm_CopyTo.Location = New System.Drawing.Point(12, 99)
            Me.DataGridViewForm_CopyTo.MultiSelect = True
            Me.DataGridViewForm_CopyTo.Name = "DataGridViewForm_CopyTo"
            Me.DataGridViewForm_CopyTo.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CopyTo.RunStandardValidation = True
            Me.DataGridViewForm_CopyTo.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CopyTo.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_CopyTo.Size = New System.Drawing.Size(709, 375)
            Me.DataGridViewForm_CopyTo.TabIndex = 54
            Me.DataGridViewForm_CopyTo.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CopyTo.ViewCaptionHeight = -1
            '
            'LabelForm_CopyToOptions
            '
            Me.LabelForm_CopyToOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CopyToOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CopyToOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CopyToOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_CopyToOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_CopyToOptions.Location = New System.Drawing.Point(12, 428)
            Me.LabelForm_CopyToOptions.Name = "LabelForm_CopyToOptions"
            Me.LabelForm_CopyToOptions.Size = New System.Drawing.Size(656, 20)
            Me.LabelForm_CopyToOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CopyToOptions.TabIndex = 55
            Me.LabelForm_CopyToOptions.Text = "Copy To Options:"
            Me.LabelForm_CopyToOptions.Visible = False
            '
            'ClientMediaSalesClassOverrideCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(733, 512)
            Me.Controls.Add(Me.DataGridViewForm_CopyTo)
            Me.Controls.Add(Me.DataGridViewForm_CopyFrom)
            Me.Controls.Add(Me.CheckBoxForm_DeleteExistingOverrides)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.LabelForm_CopyToOptions)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientMediaSalesClassOverrideCopyDialog"
            Me.Text = "Sales Class Override Copy"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_DeleteExistingOverrides As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_CopyFrom As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_CopyTo As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_CopyToOptions As WinForm.Presentation.Controls.Label
    End Class

End Namespace