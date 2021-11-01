Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBuyerSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBuyerSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
			Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
			Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
			Me.DataGridViewForm_MediaBuyer = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
			Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
			Me.SuspendLayout()
			'
			'RibbonBarMergeContainerForm_Options
			'
			Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
			Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
			Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
			Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
			Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(473, 98)
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
			Me.RibbonBarMergeContainerForm_Options.Visible = False
			'
			'RibbonBarOptions_Actions
			'
			Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
			'
			'
			'
			Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
			Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
			Me.RibbonBarOptions_Actions.DragDropSupport = True
			Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
			Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
			Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
			Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
			Me.RibbonBarOptions_Actions.SecurityEnabled = True
			Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(209, 98)
			Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RibbonBarOptions_Actions.TabIndex = 0
			Me.RibbonBarOptions_Actions.Text = "Actions"
			'
			'
			'
			Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			'
			'
			'
			Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
			'
			'ButtonItemActions_Export
			'
			Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
			Me.ButtonItemActions_Export.RibbonWordWrap = False
			Me.ButtonItemActions_Export.Stretch = True
			Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Export.Text = "Export"
			'
			'ButtonItemActions_Delete
			'
			Me.ButtonItemActions_Delete.BeginGroup = True
			Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
			Me.ButtonItemActions_Delete.RibbonWordWrap = False
			Me.ButtonItemActions_Delete.Stretch = True
			Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Delete.Text = "Delete"
			'
			'ButtonItemActions_Cancel
			'
			Me.ButtonItemActions_Cancel.BeginGroup = True
			Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
			Me.ButtonItemActions_Cancel.Enabled = False
			Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
			Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
			Me.ButtonItemActions_Cancel.RibbonWordWrap = False
			Me.ButtonItemActions_Cancel.Stretch = True
			Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
			Me.ButtonItemActions_Cancel.Text = "Cancel"
			'
			'DataGridViewForm_MediaBuyer
			'
			Me.DataGridViewForm_MediaBuyer.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_MediaBuyer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_MediaBuyer.DataSource = Nothing
			Me.DataGridViewForm_MediaBuyer.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_MediaBuyer.ItemDescription = "Media Buyer(s)"
			Me.DataGridViewForm_MediaBuyer.Location = New System.Drawing.Point(12, 12)
			Me.DataGridViewForm_MediaBuyer.MultiSelect = True
			Me.DataGridViewForm_MediaBuyer.Name = "DataGridViewForm_MediaBuyer"
			Me.DataGridViewForm_MediaBuyer.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
			Me.DataGridViewForm_MediaBuyer.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_MediaBuyer.Size = New System.Drawing.Size(689, 397)
			Me.DataGridViewForm_MediaBuyer.TabIndex = 4
			Me.DataGridViewForm_MediaBuyer.ViewCaptionHeight = -1
			'
			'MediaBuyerSetupForm
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(713, 421)
			Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
			Me.Controls.Add(Me.DataGridViewForm_MediaBuyer)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaBuyerSetupForm"
			Me.Text = "Media Buyer Maintenance"
			Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
		Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
		Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents DataGridViewForm_MediaBuyer As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
	End Class

End Namespace

