Namespace WinForm.MVC.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class CRUDDialog
		Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRUDDialog))
			Me.DataGridViewForm_Objects = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
			Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_Exclude = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.SuspendLayout()
			'
			'DataGridViewForm_Objects
			'
			Me.DataGridViewForm_Objects.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_Objects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_Objects.DataSource = Nothing
			Me.DataGridViewForm_Objects.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_Objects.ItemDescription = "Item(s)"
			Me.DataGridViewForm_Objects.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewForm_Objects.MultiSelect = True
			Me.DataGridViewForm_Objects.Name = "DataGridViewForm_Objects"
			Me.DataGridViewForm_Objects.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewForm_Objects.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_Objects.Size = New System.Drawing.Size(663, 344)
			Me.DataGridViewForm_Objects.TabIndex = 0
			Me.DataGridViewForm_Objects.ViewCaptionHeight = -1
			'
			'ButtonForm_Add
			'
			Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Add.Location = New System.Drawing.Point(12, 362)
			Me.ButtonForm_Add.Name = "ButtonForm_Add"
			Me.ButtonForm_Add.SecurityEnabled = True
			Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Add.TabIndex = 1
			Me.ButtonForm_Add.Text = "Add"
			'
			'ButtonForm_Edit
			'
			Me.ButtonForm_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Edit.Location = New System.Drawing.Point(93, 362)
			Me.ButtonForm_Edit.Name = "ButtonForm_Edit"
			Me.ButtonForm_Edit.SecurityEnabled = True
			Me.ButtonForm_Edit.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Edit.TabIndex = 2
			Me.ButtonForm_Edit.Text = "Edit"
			'
			'ButtonForm_Delete
			'
			Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Delete.Location = New System.Drawing.Point(174, 362)
			Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
			Me.ButtonForm_Delete.SecurityEnabled = True
			Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Delete.TabIndex = 3
			Me.ButtonForm_Delete.Text = "Delete"
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(600, 362)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 5
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'ButtonForm_Select
			'
			Me.ButtonForm_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Select.Location = New System.Drawing.Point(519, 362)
			Me.ButtonForm_Select.Name = "ButtonForm_Select"
			Me.ButtonForm_Select.SecurityEnabled = True
			Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Select.TabIndex = 5
			Me.ButtonForm_Select.Text = "Select"
			'
			'ButtonForm_Close
			'
			Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Close.Location = New System.Drawing.Point(600, 362)
			Me.ButtonForm_Close.Name = "ButtonForm_Close"
			Me.ButtonForm_Close.SecurityEnabled = True
			Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Close.TabIndex = 6
			Me.ButtonForm_Close.Text = "Close"
			'
			'ButtonForm_Copy
			'
			Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Copy.Location = New System.Drawing.Point(255, 362)
			Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
			Me.ButtonForm_Copy.SecurityEnabled = True
			Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Copy.TabIndex = 4
			Me.ButtonForm_Copy.Text = "Copy"
			Me.ButtonForm_Copy.Visible = False
			'
			'ButtonForm_Exclude
			'
			Me.ButtonForm_Exclude.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Exclude.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Exclude.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Exclude.Location = New System.Drawing.Point(336, 362)
			Me.ButtonForm_Exclude.Name = "ButtonForm_Exclude"
			Me.ButtonForm_Exclude.SecurityEnabled = True
			Me.ButtonForm_Exclude.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Exclude.TabIndex = 7
			Me.ButtonForm_Exclude.Text = "Exclude"
			Me.ButtonForm_Exclude.Visible = False
			'
			'CRUDDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(687, 394)
			Me.Controls.Add(Me.ButtonForm_Exclude)
			Me.Controls.Add(Me.ButtonForm_Copy)
			Me.Controls.Add(Me.ButtonForm_Close)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Controls.Add(Me.ButtonForm_Select)
			Me.Controls.Add(Me.ButtonForm_Delete)
			Me.Controls.Add(Me.ButtonForm_Edit)
			Me.Controls.Add(Me.ButtonForm_Add)
			Me.Controls.Add(Me.DataGridViewForm_Objects)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "CRUDDialog"
			Me.Text = "CRUD Dialog"
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents DataGridViewForm_Objects As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Delete As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Exclude As AdvantageFramework.WinForm.Presentation.Controls.Button
	End Class

End Namespace