Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IncomeOnlyCopyDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncomeOnlyCopyDialog))
            Me.DataGridViewSelectJobComponents_JobComponents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_SelectJobComponents = New DevExpress.XtraWizard.WizardPage()
            Me.WizardPageWizard_SelectJob = New DevExpress.XtraWizard.WizardPage()
            Me.SearchableComboBoxSelectJob_Component = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxSelectJob_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxSelectJob_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxSelectJob_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.SearchableComboBoxSelectJob_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.LabelSelectJob_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectJob_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectJob_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectJob_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectJob_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CdpJobCompFilterForm_Filter = New AdvantageFramework.WinForm.Presentation.Controls.CDPJobCompFilter(Me.components)
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_SelectJobComponents.SuspendLayout()
            Me.WizardPageWizard_SelectJob.SuspendLayout()
            CType(Me.SearchableComboBoxSelectJob_Component.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSelectJob_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSelectJob_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSelectJob_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSelectJob_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewSelectJobComponents_JobComponents
            '
            Me.DataGridViewSelectJobComponents_JobComponents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectJobComponents_JobComponents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectJobComponents_JobComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectJobComponents_JobComponents.AutoFilterLookupColumns = False
            Me.DataGridViewSelectJobComponents_JobComponents.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectJobComponents_JobComponents.AutoUpdateViewCaption = True
            Me.DataGridViewSelectJobComponents_JobComponents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSelectJobComponents_JobComponents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectJobComponents_JobComponents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectJobComponents_JobComponents.ItemDescription = "Item(s)"
            Me.DataGridViewSelectJobComponents_JobComponents.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectJobComponents_JobComponents.MultiSelect = True
            Me.DataGridViewSelectJobComponents_JobComponents.Name = "DataGridViewSelectJobComponents_JobComponents"
            Me.DataGridViewSelectJobComponents_JobComponents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectJobComponents_JobComponents.RunStandardValidation = True
            Me.DataGridViewSelectJobComponents_JobComponents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectJobComponents_JobComponents.Size = New System.Drawing.Size(551, 284)
            Me.DataGridViewSelectJobComponents_JobComponents.TabIndex = 0
            Me.DataGridViewSelectJobComponents_JobComponents.UseEmbeddedNavigator = False
            Me.DataGridViewSelectJobComponents_JobComponents.ViewCaptionHeight = -1
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectJobComponents)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectJob)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WizardPageWizard_SelectJobComponents, Me.WizardPageWizard_SelectJob})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(589, 433)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_SelectJobComponents
            '
            Me.WizardPageWizard_SelectJobComponents.Controls.Add(Me.DataGridViewSelectJobComponents_JobComponents)
            Me.WizardPageWizard_SelectJobComponents.DescriptionText = ""
            Me.WizardPageWizard_SelectJobComponents.Name = "WizardPageWizard_SelectJobComponents"
            Me.WizardPageWizard_SelectJobComponents.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SelectJobComponents.Text = "Select Job Component(s)"
            '
            'WizardPageWizard_SelectJob
            '
            Me.WizardPageWizard_SelectJob.AllowDrop = True
            Me.WizardPageWizard_SelectJob.AllowNext = False
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.SearchableComboBoxSelectJob_Component)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.SearchableComboBoxSelectJob_Job)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.SearchableComboBoxSelectJob_Product)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.SearchableComboBoxSelectJob_Division)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.SearchableComboBoxSelectJob_Client)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.LabelSelectJob_Component)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.LabelSelectJob_Job)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.LabelSelectJob_Product)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.LabelSelectJob_Division)
            Me.WizardPageWizard_SelectJob.Controls.Add(Me.LabelSelectJob_Client)
            Me.WizardPageWizard_SelectJob.DescriptionText = ""
            Me.WizardPageWizard_SelectJob.Name = "WizardPageWizard_SelectJob"
            Me.WizardPageWizard_SelectJob.Size = New System.Drawing.Size(557, 290)
            Me.WizardPageWizard_SelectJob.Text = "Select Job Component to Copy To"
            '
            'SearchableComboBoxSelectJob_Component
            '
            Me.SearchableComboBoxSelectJob_Component.ActiveFilterString = ""
            Me.SearchableComboBoxSelectJob_Component.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSelectJob_Component.BookmarkingEnabled = False
            Me.SearchableComboBoxSelectJob_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxSelectJob_Component.DataSource = Nothing
            Me.SearchableComboBoxSelectJob_Component.DisableMouseWheel = False
            Me.SearchableComboBoxSelectJob_Component.DisplayName = ""
            Me.SearchableComboBoxSelectJob_Component.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSelectJob_Component.Location = New System.Drawing.Point(84, 107)
            Me.SearchableComboBoxSelectJob_Component.Name = "SearchableComboBoxSelectJob_Component"
            Me.SearchableComboBoxSelectJob_Component.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSelectJob_Component.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSelectJob_Component.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxSelectJob_Component.Properties.ShowClearButton = False
            Me.SearchableComboBoxSelectJob_Component.Properties.ValueMember = "Number"
            Me.SearchableComboBoxSelectJob_Component.Properties.View = Me.GridView4
            Me.SearchableComboBoxSelectJob_Component.SecurityEnabled = True
            Me.SearchableComboBoxSelectJob_Component.SelectedValue = Nothing
            Me.SearchableComboBoxSelectJob_Component.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxSelectJob_Component.TabIndex = 19
            '
            'GridView4
            '
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxSelectJob_Job
            '
            Me.SearchableComboBoxSelectJob_Job.ActiveFilterString = ""
            Me.SearchableComboBoxSelectJob_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSelectJob_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxSelectJob_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxSelectJob_Job.DataSource = Nothing
            Me.SearchableComboBoxSelectJob_Job.DisableMouseWheel = False
            Me.SearchableComboBoxSelectJob_Job.DisplayName = ""
            Me.SearchableComboBoxSelectJob_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSelectJob_Job.Location = New System.Drawing.Point(84, 81)
            Me.SearchableComboBoxSelectJob_Job.Name = "SearchableComboBoxSelectJob_Job"
            Me.SearchableComboBoxSelectJob_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSelectJob_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSelectJob_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxSelectJob_Job.Properties.ShowClearButton = False
            Me.SearchableComboBoxSelectJob_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxSelectJob_Job.Properties.View = Me.GridView3
            Me.SearchableComboBoxSelectJob_Job.SecurityEnabled = True
            Me.SearchableComboBoxSelectJob_Job.SelectedValue = Nothing
            Me.SearchableComboBoxSelectJob_Job.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxSelectJob_Job.TabIndex = 17
            '
            'GridView3
            '
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxSelectJob_Product
            '
            Me.SearchableComboBoxSelectJob_Product.ActiveFilterString = ""
            Me.SearchableComboBoxSelectJob_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSelectJob_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxSelectJob_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxSelectJob_Product.DataSource = Nothing
            Me.SearchableComboBoxSelectJob_Product.DisableMouseWheel = False
            Me.SearchableComboBoxSelectJob_Product.DisplayName = ""
            Me.SearchableComboBoxSelectJob_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSelectJob_Product.Location = New System.Drawing.Point(84, 55)
            Me.SearchableComboBoxSelectJob_Product.Name = "SearchableComboBoxSelectJob_Product"
            Me.SearchableComboBoxSelectJob_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSelectJob_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSelectJob_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxSelectJob_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxSelectJob_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSelectJob_Product.Properties.View = Me.GridView2
            Me.SearchableComboBoxSelectJob_Product.SecurityEnabled = True
            Me.SearchableComboBoxSelectJob_Product.SelectedValue = Nothing
            Me.SearchableComboBoxSelectJob_Product.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxSelectJob_Product.TabIndex = 15
            '
            'GridView2
            '
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxSelectJob_Division
            '
            Me.SearchableComboBoxSelectJob_Division.ActiveFilterString = ""
            Me.SearchableComboBoxSelectJob_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSelectJob_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxSelectJob_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxSelectJob_Division.DataSource = Nothing
            Me.SearchableComboBoxSelectJob_Division.DisableMouseWheel = False
            Me.SearchableComboBoxSelectJob_Division.DisplayName = ""
            Me.SearchableComboBoxSelectJob_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSelectJob_Division.Location = New System.Drawing.Point(84, 29)
            Me.SearchableComboBoxSelectJob_Division.Name = "SearchableComboBoxSelectJob_Division"
            Me.SearchableComboBoxSelectJob_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSelectJob_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSelectJob_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxSelectJob_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxSelectJob_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSelectJob_Division.Properties.View = Me.GridView1
            Me.SearchableComboBoxSelectJob_Division.SecurityEnabled = True
            Me.SearchableComboBoxSelectJob_Division.SelectedValue = Nothing
            Me.SearchableComboBoxSelectJob_Division.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxSelectJob_Division.TabIndex = 13
            '
            'GridView1
            '
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            '
            'SearchableComboBoxSelectJob_Client
            '
            Me.SearchableComboBoxSelectJob_Client.ActiveFilterString = ""
            Me.SearchableComboBoxSelectJob_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSelectJob_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxSelectJob_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxSelectJob_Client.DataSource = Nothing
            Me.SearchableComboBoxSelectJob_Client.DisableMouseWheel = False
            Me.SearchableComboBoxSelectJob_Client.DisplayName = ""
            Me.SearchableComboBoxSelectJob_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSelectJob_Client.Location = New System.Drawing.Point(84, 3)
            Me.SearchableComboBoxSelectJob_Client.Name = "SearchableComboBoxSelectJob_Client"
            Me.SearchableComboBoxSelectJob_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSelectJob_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSelectJob_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxSelectJob_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxSelectJob_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSelectJob_Client.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxSelectJob_Client.SecurityEnabled = True
            Me.SearchableComboBoxSelectJob_Client.SelectedValue = Nothing
            Me.SearchableComboBoxSelectJob_Client.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxSelectJob_Client.TabIndex = 11
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            '
            'LabelSelectJob_Component
            '
            Me.LabelSelectJob_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectJob_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectJob_Component.Location = New System.Drawing.Point(3, 107)
            Me.LabelSelectJob_Component.Name = "LabelSelectJob_Component"
            Me.LabelSelectJob_Component.Size = New System.Drawing.Size(75, 20)
            Me.LabelSelectJob_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectJob_Component.TabIndex = 18
            Me.LabelSelectJob_Component.Text = "Component:"
            '
            'LabelSelectJob_Job
            '
            Me.LabelSelectJob_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectJob_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectJob_Job.Location = New System.Drawing.Point(3, 81)
            Me.LabelSelectJob_Job.Name = "LabelSelectJob_Job"
            Me.LabelSelectJob_Job.Size = New System.Drawing.Size(75, 20)
            Me.LabelSelectJob_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectJob_Job.TabIndex = 16
            Me.LabelSelectJob_Job.Text = "Job:"
            '
            'LabelSelectJob_Product
            '
            Me.LabelSelectJob_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectJob_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectJob_Product.Location = New System.Drawing.Point(3, 55)
            Me.LabelSelectJob_Product.Name = "LabelSelectJob_Product"
            Me.LabelSelectJob_Product.Size = New System.Drawing.Size(75, 20)
            Me.LabelSelectJob_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectJob_Product.TabIndex = 14
            Me.LabelSelectJob_Product.Text = "Product:"
            '
            'LabelSelectJob_Division
            '
            Me.LabelSelectJob_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectJob_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectJob_Division.Location = New System.Drawing.Point(3, 29)
            Me.LabelSelectJob_Division.Name = "LabelSelectJob_Division"
            Me.LabelSelectJob_Division.Size = New System.Drawing.Size(75, 20)
            Me.LabelSelectJob_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectJob_Division.TabIndex = 12
            Me.LabelSelectJob_Division.Text = "Division:"
            '
            'LabelSelectJob_Client
            '
            Me.LabelSelectJob_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectJob_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectJob_Client.Location = New System.Drawing.Point(3, 3)
            Me.LabelSelectJob_Client.Name = "LabelSelectJob_Client"
            Me.LabelSelectJob_Client.Size = New System.Drawing.Size(75, 20)
            Me.LabelSelectJob_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectJob_Client.TabIndex = 10
            Me.LabelSelectJob_Client.Text = "Client:"
            '
            'CdpJobCompFilterForm_Filter
            '
            Me.CdpJobCompFilterForm_Filter.ClientCode = Nothing
            Me.CdpJobCompFilterForm_Filter.ClientDisplayControl = Me.SearchableComboBoxSelectJob_Client
            Me.CdpJobCompFilterForm_Filter.ClientSource = Nothing
            Me.CdpJobCompFilterForm_Filter.DivisionCode = Nothing
            Me.CdpJobCompFilterForm_Filter.DivisionDisplayControl = Me.SearchableComboBoxSelectJob_Division
            Me.CdpJobCompFilterForm_Filter.DivisionSource = Nothing
            Me.CdpJobCompFilterForm_Filter.JobComponentDisplayControl = Me.SearchableComboBoxSelectJob_Component
            Me.CdpJobCompFilterForm_Filter.JobComponentNumber = Nothing
            Me.CdpJobCompFilterForm_Filter.JobComponentSource = Nothing
            Me.CdpJobCompFilterForm_Filter.JobDisplayControl = Me.SearchableComboBoxSelectJob_Job
            Me.CdpJobCompFilterForm_Filter.JobNumber = Nothing
            Me.CdpJobCompFilterForm_Filter.JobSource = Nothing
            Me.CdpJobCompFilterForm_Filter.ProductCode = Nothing
            Me.CdpJobCompFilterForm_Filter.ProductDisplayControl = Me.SearchableComboBoxSelectJob_Product
            Me.CdpJobCompFilterForm_Filter.ProductSource = Nothing
            '
            'IncomeOnlyCopyDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(589, 433)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "IncomeOnlyCopyDialog"
            Me.Text = "Income Only"
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_SelectJobComponents.ResumeLayout(False)
            Me.WizardPageWizard_SelectJob.ResumeLayout(False)
            CType(Me.SearchableComboBoxSelectJob_Component.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSelectJob_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSelectJob_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSelectJob_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSelectJob_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewSelectJobComponents_JobComponents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Friend WithEvents WizardPageWizard_SelectJobComponents As DevExpress.XtraWizard.WizardPage
        Friend WithEvents WizardPageWizard_SelectJob As DevExpress.XtraWizard.WizardPage
        Friend WithEvents SearchableComboBoxSelectJob_Component As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxSelectJob_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxSelectJob_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxSelectJob_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents SearchableComboBoxSelectJob_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LabelSelectJob_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectJob_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectJob_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectJob_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectJob_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CdpJobCompFilterForm_Filter As AdvantageFramework.WinForm.Presentation.Controls.CDPJobCompFilter
    End Class

End Namespace
