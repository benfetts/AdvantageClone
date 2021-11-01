Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastJobComponentsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastJobComponentsDialog))
            Me.ButtonForm_AddAllJobComponents = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddJobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RemoveJobComponent = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_AvailableJobComponents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_CurrentJobComponents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_ShowJobsForAllOffices = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SuspendLayout()
            '
            'ButtonForm_AddAllJobComponents
            '
            Me.ButtonForm_AddAllJobComponents.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddAllJobComponents.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddAllJobComponents.Location = New System.Drawing.Point(343, 64)
            Me.ButtonForm_AddAllJobComponents.Name = "ButtonForm_AddAllJobComponents"
            Me.ButtonForm_AddAllJobComponents.SecurityEnabled = True
            Me.ButtonForm_AddAllJobComponents.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddAllJobComponents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddAllJobComponents.TabIndex = 8
            Me.ButtonForm_AddAllJobComponents.Text = ">>"
            '
            'ButtonForm_AddJobComponent
            '
            Me.ButtonForm_AddJobComponent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddJobComponent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddJobComponent.Location = New System.Drawing.Point(343, 38)
            Me.ButtonForm_AddJobComponent.Name = "ButtonForm_AddJobComponent"
            Me.ButtonForm_AddJobComponent.SecurityEnabled = True
            Me.ButtonForm_AddJobComponent.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddJobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddJobComponent.TabIndex = 7
            Me.ButtonForm_AddJobComponent.Text = ">"
            '
            'ButtonForm_RemoveJobComponent
            '
            Me.ButtonForm_RemoveJobComponent.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveJobComponent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_RemoveJobComponent.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveJobComponent.Location = New System.Drawing.Point(755, 38)
            Me.ButtonForm_RemoveJobComponent.Name = "ButtonForm_RemoveJobComponent"
            Me.ButtonForm_RemoveJobComponent.SecurityEnabled = True
            Me.ButtonForm_RemoveJobComponent.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveJobComponent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveJobComponent.TabIndex = 10
            Me.ButtonForm_RemoveJobComponent.Text = "X"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(755, 505)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 11
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_AvailableJobComponents
            '
            Me.DataGridViewForm_AvailableJobComponents.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_AvailableJobComponents.AllowDragAndDrop = False
            Me.DataGridViewForm_AvailableJobComponents.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_AvailableJobComponents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableJobComponents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AvailableJobComponents.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AvailableJobComponents.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AvailableJobComponents.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableJobComponents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AvailableJobComponents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AvailableJobComponents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableJobComponents.ItemDescription = "Available Job Component(s)"
            Me.DataGridViewForm_AvailableJobComponents.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_AvailableJobComponents.MultiSelect = True
            Me.DataGridViewForm_AvailableJobComponents.Name = "DataGridViewForm_AvailableJobComponents"
            Me.DataGridViewForm_AvailableJobComponents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableJobComponents.RunStandardValidation = True
            Me.DataGridViewForm_AvailableJobComponents.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_AvailableJobComponents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableJobComponents.Size = New System.Drawing.Size(325, 461)
            Me.DataGridViewForm_AvailableJobComponents.TabIndex = 6
            Me.DataGridViewForm_AvailableJobComponents.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableJobComponents.ViewCaptionHeight = -1
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(39, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 0
            Me.LabelForm_Client.Text = "Client:"
            '
            'ComboBoxForm_Client
            '
            Me.ComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Client.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Client.BookmarkingEnabled = False
            Me.ComboBoxForm_Client.ClientCode = ""
            Me.ComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxForm_Client.DisableMouseWheel = False
            Me.ComboBoxForm_Client.DisplayMember = "Name"
            Me.ComboBoxForm_Client.DisplayName = ""
            Me.ComboBoxForm_Client.DivisionCode = ""
            Me.ComboBoxForm_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Client.FocusHighlightEnabled = True
            Me.ComboBoxForm_Client.FormattingEnabled = True
            Me.ComboBoxForm_Client.ItemHeight = 14
            Me.ComboBoxForm_Client.Location = New System.Drawing.Point(57, 12)
            Me.ComboBoxForm_Client.Name = "ComboBoxForm_Client"
            Me.ComboBoxForm_Client.ReadOnly = False
            Me.ComboBoxForm_Client.SecurityEnabled = True
            Me.ComboBoxForm_Client.Size = New System.Drawing.Size(220, 20)
            Me.ComboBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Client.TabIndex = 1
            Me.ComboBoxForm_Client.TabOnEnter = True
            Me.ComboBoxForm_Client.ValueMember = "Code"
            Me.ComboBoxForm_Client.WatermarkText = "Select Client"
            '
            'DataGridViewForm_CurrentJobComponents
            '
            Me.DataGridViewForm_CurrentJobComponents.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CurrentJobComponents.AllowDragAndDrop = False
            Me.DataGridViewForm_CurrentJobComponents.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CurrentJobComponents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CurrentJobComponents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CurrentJobComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CurrentJobComponents.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CurrentJobComponents.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CurrentJobComponents.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CurrentJobComponents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CurrentJobComponents.DataSource = Nothing
            Me.DataGridViewForm_CurrentJobComponents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CurrentJobComponents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CurrentJobComponents.ItemDescription = "Current Job Component(s)"
            Me.DataGridViewForm_CurrentJobComponents.Location = New System.Drawing.Point(424, 38)
            Me.DataGridViewForm_CurrentJobComponents.MultiSelect = True
            Me.DataGridViewForm_CurrentJobComponents.Name = "DataGridViewForm_CurrentJobComponents"
            Me.DataGridViewForm_CurrentJobComponents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CurrentJobComponents.RunStandardValidation = True
            Me.DataGridViewForm_CurrentJobComponents.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CurrentJobComponents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CurrentJobComponents.Size = New System.Drawing.Size(325, 461)
            Me.DataGridViewForm_CurrentJobComponents.TabIndex = 9
            Me.DataGridViewForm_CurrentJobComponents.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CurrentJobComponents.ViewCaptionHeight = -1
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(283, 12)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(46, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 2
            Me.LabelForm_Division.Text = "Division:"
            '
            'ComboBoxForm_Division
            '
            Me.ComboBoxForm_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Division.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Division.BookmarkingEnabled = False
            Me.ComboBoxForm_Division.ClientCode = ""
            Me.ComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxForm_Division.DisableMouseWheel = False
            Me.ComboBoxForm_Division.DisplayMember = "Description"
            Me.ComboBoxForm_Division.DisplayName = ""
            Me.ComboBoxForm_Division.DivisionCode = ""
            Me.ComboBoxForm_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Division.FocusHighlightEnabled = True
            Me.ComboBoxForm_Division.FormattingEnabled = True
            Me.ComboBoxForm_Division.ItemHeight = 14
            Me.ComboBoxForm_Division.Location = New System.Drawing.Point(335, 12)
            Me.ComboBoxForm_Division.Name = "ComboBoxForm_Division"
            Me.ComboBoxForm_Division.ReadOnly = False
            Me.ComboBoxForm_Division.SecurityEnabled = True
            Me.ComboBoxForm_Division.Size = New System.Drawing.Size(220, 20)
            Me.ComboBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Division.TabIndex = 3
            Me.ComboBoxForm_Division.TabOnEnter = True
            Me.ComboBoxForm_Division.ValueMember = "Code"
            Me.ComboBoxForm_Division.WatermarkText = "Select Division"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(561, 12)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(43, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 4
            Me.LabelForm_Product.Text = "Product:"
            '
            'ComboBoxForm_Product
            '
            Me.ComboBoxForm_Product.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Product.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Product.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Product.BookmarkingEnabled = False
            Me.ComboBoxForm_Product.ClientCode = ""
            Me.ComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Product
            Me.ComboBoxForm_Product.DisableMouseWheel = False
            Me.ComboBoxForm_Product.DisplayMember = "Name"
            Me.ComboBoxForm_Product.DisplayName = ""
            Me.ComboBoxForm_Product.DivisionCode = ""
            Me.ComboBoxForm_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Product.FocusHighlightEnabled = True
            Me.ComboBoxForm_Product.FormattingEnabled = True
            Me.ComboBoxForm_Product.ItemHeight = 14
            Me.ComboBoxForm_Product.Location = New System.Drawing.Point(610, 12)
            Me.ComboBoxForm_Product.Name = "ComboBoxForm_Product"
            Me.ComboBoxForm_Product.ReadOnly = False
            Me.ComboBoxForm_Product.SecurityEnabled = True
            Me.ComboBoxForm_Product.Size = New System.Drawing.Size(220, 20)
            Me.ComboBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Product.TabIndex = 5
            Me.ComboBoxForm_Product.TabOnEnter = True
            Me.ComboBoxForm_Product.ValueMember = "Code"
            Me.ComboBoxForm_Product.WatermarkText = "Select Product"
            '
            'CheckBoxForm_ShowJobsForAllOffices
            '
            '
            '
            '
            Me.CheckBoxForm_ShowJobsForAllOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowJobsForAllOffices.CheckValue = 0
            Me.CheckBoxForm_ShowJobsForAllOffices.CheckValueChecked = 1
            Me.CheckBoxForm_ShowJobsForAllOffices.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowJobsForAllOffices.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowJobsForAllOffices.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowJobsForAllOffices.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsForAllOffices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowJobsForAllOffices.Location = New System.Drawing.Point(12, 505)
            Me.CheckBoxForm_ShowJobsForAllOffices.Name = "CheckBoxForm_ShowJobsForAllOffices"
            Me.CheckBoxForm_ShowJobsForAllOffices.OldestSibling = Nothing
            Me.CheckBoxForm_ShowJobsForAllOffices.SecurityEnabled = True
            Me.CheckBoxForm_ShowJobsForAllOffices.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowJobsForAllOffices.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowJobsForAllOffices.Size = New System.Drawing.Size(325, 20)
            Me.CheckBoxForm_ShowJobsForAllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowJobsForAllOffices.TabIndex = 12
            Me.CheckBoxForm_ShowJobsForAllOffices.TabOnEnter = True
            Me.CheckBoxForm_ShowJobsForAllOffices.Text = "Show Jobs for All Offices"
            '
            'EmployeeTimeForecastJobComponentsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(842, 537)
            Me.Controls.Add(Me.CheckBoxForm_ShowJobsForAllOffices)
            Me.Controls.Add(Me.ComboBoxForm_Product)
            Me.Controls.Add(Me.LabelForm_Product)
            Me.Controls.Add(Me.ComboBoxForm_Division)
            Me.Controls.Add(Me.ButtonForm_RemoveJobComponent)
            Me.Controls.Add(Me.LabelForm_Division)
            Me.Controls.Add(Me.DataGridViewForm_AvailableJobComponents)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.ButtonForm_AddAllJobComponents)
            Me.Controls.Add(Me.ButtonForm_AddJobComponent)
            Me.Controls.Add(Me.ComboBoxForm_Client)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.DataGridViewForm_CurrentJobComponents)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastJobComponentsDialog"
            Me.Text = "Add Employee Time Forecast Job Components"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_AddAllJobComponents As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddJobComponent As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_RemoveJobComponent As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_AvailableJobComponents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_CurrentJobComponents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_ShowJobsForAllOffices As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace