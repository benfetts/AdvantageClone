Namespace WinForm.MVC.Presentation.Controls

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class DataGridView
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
			Me.DataGridView_GridControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridControl()
			Me.GridViewGridControl_MainView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
			Me.PanelControl_BottomPanel = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
			Me.ButtonBottomPanel_DeselectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonBottomPanel_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.PopupMenuGrid_Popup = New DevExpress.XtraBars.PopupMenu()
			Me.BarSubItemPopup_Columns = New DevExpress.XtraBars.BarSubItem()
			Me.BarManagerGrid_BarManager = New DevExpress.XtraBars.BarManager()
			Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
			CType(Me.DataGridView_GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.GridViewGridControl_MainView, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PanelControl_BottomPanel, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelControl_BottomPanel.SuspendLayout()
			CType(Me.PopupMenuGrid_Popup, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.BarManagerGrid_BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'DataGridView_GridControl
			'
			Me.DataGridView_GridControl.Dock = System.Windows.Forms.DockStyle.Fill
			Me.DataGridView_GridControl.Location = New System.Drawing.Point(0, 0)
			Me.DataGridView_GridControl.MainView = Me.GridViewGridControl_MainView
			Me.DataGridView_GridControl.Name = "DataGridView_GridControl"
			Me.DataGridView_GridControl.Size = New System.Drawing.Size(413, 174)
			Me.DataGridView_GridControl.TabIndex = 1
			Me.DataGridView_GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewGridControl_MainView})
			'
			'GridViewGridControl_MainView
			'
			Me.GridViewGridControl_MainView.AFActiveFilterString = ""
			Me.GridViewGridControl_MainView.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
			Me.GridViewGridControl_MainView.EnableDisabledRows = False
			Me.GridViewGridControl_MainView.GridControl = Me.DataGridView_GridControl
			Me.GridViewGridControl_MainView.Name = "GridViewGridControl_MainView"
			Me.GridViewGridControl_MainView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
			Me.GridViewGridControl_MainView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
			Me.GridViewGridControl_MainView.OptionsSelection.MultiSelect = True
			Me.GridViewGridControl_MainView.OptionsView.BestFitMaxRowCount = 20
			Me.GridViewGridControl_MainView.OptionsView.ColumnAutoWidth = False
			Me.GridViewGridControl_MainView.OptionsView.ShowGroupPanel = False
			Me.GridViewGridControl_MainView.OptionsView.ShowViewCaption = True
			'
			'PanelControl_BottomPanel
			'
			Me.PanelControl_BottomPanel.Appearance.BackColor = System.Drawing.Color.White
			Me.PanelControl_BottomPanel.Appearance.Options.UseBackColor = True
			Me.PanelControl_BottomPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			Me.PanelControl_BottomPanel.Controls.Add(Me.ButtonBottomPanel_DeselectAll)
			Me.PanelControl_BottomPanel.Controls.Add(Me.ButtonBottomPanel_SelectAll)
			Me.PanelControl_BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.PanelControl_BottomPanel.Location = New System.Drawing.Point(0, 174)
			Me.PanelControl_BottomPanel.Name = "PanelControl_BottomPanel"
			Me.PanelControl_BottomPanel.Size = New System.Drawing.Size(413, 30)
			Me.PanelControl_BottomPanel.TabIndex = 2
			Me.PanelControl_BottomPanel.Visible = False
			'
			'ButtonBottomPanel_DeselectAll
			'
			Me.ButtonBottomPanel_DeselectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonBottomPanel_DeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonBottomPanel_DeselectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonBottomPanel_DeselectAll.Location = New System.Drawing.Point(81, 5)
			Me.ButtonBottomPanel_DeselectAll.Name = "ButtonBottomPanel_DeselectAll"
			Me.ButtonBottomPanel_DeselectAll.SecurityEnabled = True
			Me.ButtonBottomPanel_DeselectAll.Size = New System.Drawing.Size(75, 20)
			Me.ButtonBottomPanel_DeselectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonBottomPanel_DeselectAll.TabIndex = 8
			Me.ButtonBottomPanel_DeselectAll.Text = "Deselect All"
			'
			'ButtonBottomPanel_SelectAll
			'
			Me.ButtonBottomPanel_SelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonBottomPanel_SelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.ButtonBottomPanel_SelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonBottomPanel_SelectAll.Location = New System.Drawing.Point(0, 5)
			Me.ButtonBottomPanel_SelectAll.Name = "ButtonBottomPanel_SelectAll"
			Me.ButtonBottomPanel_SelectAll.SecurityEnabled = True
			Me.ButtonBottomPanel_SelectAll.Size = New System.Drawing.Size(75, 20)
			Me.ButtonBottomPanel_SelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonBottomPanel_SelectAll.TabIndex = 7
			Me.ButtonBottomPanel_SelectAll.Text = "Select All"
			'
			'PopupMenuGrid_Popup
			'
			Me.PopupMenuGrid_Popup.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItemPopup_Columns)})
			Me.PopupMenuGrid_Popup.Manager = Me.BarManagerGrid_BarManager
			Me.PopupMenuGrid_Popup.Name = "PopupMenuGrid_Popup"
			'
			'BarSubItemPopup_Columns
			'
			Me.BarSubItemPopup_Columns.Caption = "Columns"
			Me.BarSubItemPopup_Columns.Id = 1
			Me.BarSubItemPopup_Columns.Name = "BarSubItemPopup_Columns"
			'
			'BarManagerGrid_BarManager
			'
			Me.BarManagerGrid_BarManager.DockControls.Add(Me.barDockControlTop)
			Me.BarManagerGrid_BarManager.DockControls.Add(Me.barDockControlBottom)
			Me.BarManagerGrid_BarManager.DockControls.Add(Me.barDockControlLeft)
			Me.BarManagerGrid_BarManager.DockControls.Add(Me.barDockControlRight)
			Me.BarManagerGrid_BarManager.Form = Me
			Me.BarManagerGrid_BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItemPopup_Columns})
			Me.BarManagerGrid_BarManager.MaxItemId = 2
			'
			'barDockControlTop
			'
			Me.barDockControlTop.CausesValidation = False
			Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
			Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
			Me.barDockControlTop.Size = New System.Drawing.Size(413, 0)
			'
			'barDockControlBottom
			'
			Me.barDockControlBottom.CausesValidation = False
			Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.barDockControlBottom.Location = New System.Drawing.Point(0, 204)
			Me.barDockControlBottom.Size = New System.Drawing.Size(413, 0)
			'
			'barDockControlLeft
			'
			Me.barDockControlLeft.CausesValidation = False
			Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
			Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
			Me.barDockControlLeft.Size = New System.Drawing.Size(0, 204)
			'
			'barDockControlRight
			'
			Me.barDockControlRight.CausesValidation = False
			Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
			Me.barDockControlRight.Location = New System.Drawing.Point(413, 0)
			Me.barDockControlRight.Size = New System.Drawing.Size(0, 204)
			'
			'DataGridView
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.DataGridView_GridControl)
			Me.Controls.Add(Me.PanelControl_BottomPanel)
			Me.Controls.Add(Me.barDockControlLeft)
			Me.Controls.Add(Me.barDockControlRight)
			Me.Controls.Add(Me.barDockControlBottom)
			Me.Controls.Add(Me.barDockControlTop)
			Me.Name = "DataGridView"
			Me.Size = New System.Drawing.Size(413, 204)
			CType(Me.DataGridView_GridControl, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.GridViewGridControl_MainView, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PanelControl_BottomPanel, System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelControl_BottomPanel.ResumeLayout(False)
			CType(Me.PopupMenuGrid_Popup, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.BarManagerGrid_BarManager, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Protected WithEvents DataGridView_GridControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridControl
		Protected WithEvents GridViewGridControl_MainView As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
		Protected WithEvents PanelControl_BottomPanel As AdvantageFramework.WinForm.Presentation.Controls.Panel
		Protected WithEvents ButtonBottomPanel_DeselectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
		Protected WithEvents ButtonBottomPanel_SelectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents PopupMenuGrid_Popup As DevExpress.XtraBars.PopupMenu
		Friend WithEvents BarManagerGrid_BarManager As DevExpress.XtraBars.BarManager
		Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
		Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
		Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
		Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
		Friend WithEvents BarSubItemPopup_Columns As DevExpress.XtraBars.BarSubItem

	End Class

End Namespace