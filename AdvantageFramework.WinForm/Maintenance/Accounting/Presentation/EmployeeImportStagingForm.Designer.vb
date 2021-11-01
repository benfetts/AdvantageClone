Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeImportStagingForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeImportStagingForm))
            Me.DataGridViewForm_ImportedEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_ImportStaging = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarImportStaging_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_ImportStaging.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'DataGridViewForm_ImportedEmployees
            '
            Me.DataGridViewForm_ImportedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ImportedEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ImportedEmployees.ItemDescription = "Item(s)"
            Me.DataGridViewForm_ImportedEmployees.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ImportedEmployees.MultiSelect = True
            Me.DataGridViewForm_ImportedEmployees.Name = "DataGridViewForm_ImportedEmployees"
            Me.DataGridViewForm_ImportedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ImportedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ImportedEmployees.Size = New System.Drawing.Size(934, 466)
            Me.DataGridViewForm_ImportedEmployees.TabIndex = 0
            Me.DataGridViewForm_ImportedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ImportedEmployees.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_ImportStaging
            '
            Me.RibbonBarMergeContainerForm_ImportStaging.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
            Me.RibbonBarMergeContainerForm_ImportStaging.Controls.Add(Me.RibbonBarImportStaging_Actions)
            Me.RibbonBarMergeContainerForm_ImportStaging.Location = New System.Drawing.Point(207, 215)
            Me.RibbonBarMergeContainerForm_ImportStaging.Name = "RibbonBarMergeContainerForm_ImportStaging"
            Me.RibbonBarMergeContainerForm_ImportStaging.RibbonTabText = "Employee Import"
            Me.RibbonBarMergeContainerForm_ImportStaging.Size = New System.Drawing.Size(352, 96)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ImportStaging.Style.Class = ""
            Me.RibbonBarMergeContainerForm_ImportStaging.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ImportStaging.StyleMouseDown.Class = ""
            Me.RibbonBarMergeContainerForm_ImportStaging.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_ImportStaging.StyleMouseOver.Class = ""
            Me.RibbonBarMergeContainerForm_ImportStaging.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_ImportStaging.TabIndex = 1
            Me.RibbonBarMergeContainerForm_ImportStaging.Visible = False
            '
            'RibbonBarImportStaging_Actions
            '
            Me.RibbonBarImportStaging_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarImportStaging_Actions.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarImportStaging_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImportStaging_Actions.BackgroundStyle.Class = ""
            Me.RibbonBarImportStaging_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImportStaging_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarImportStaging_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarImportStaging_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Import, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarImportStaging_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarImportStaging_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarImportStaging_Actions.Name = "RibbonBarImportStaging_Actions"
            Me.RibbonBarImportStaging_Actions.Size = New System.Drawing.Size(208, 96)
            Me.RibbonBarImportStaging_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarImportStaging_Actions.TabIndex = 0
            Me.RibbonBarImportStaging_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarImportStaging_Actions.TitleStyle.Class = ""
            Me.RibbonBarImportStaging_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarImportStaging_Actions.TitleStyleMouseOver.Class = ""
            Me.RibbonBarImportStaging_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarImportStaging_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.Stretch = True
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.Stretch = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'EmployeeImportStagingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(958, 490)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_ImportStaging)
            Me.Controls.Add(Me.DataGridViewForm_ImportedEmployees)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeImportStagingForm"
            Me.Text = "Employee Import Staging"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_ImportStaging.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ImportedEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_ImportStaging As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarImportStaging_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Import As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace