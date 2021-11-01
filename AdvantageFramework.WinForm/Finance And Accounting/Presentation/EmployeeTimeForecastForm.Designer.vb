Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastForm))
            Me.DataGridViewForm_EmployeeTimeForecasts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerSearch_LeftSection = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerLeftSection_TopSection = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTopSection_PostPeriod = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemTopSection_PostPeriod = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ItemContainerSearch_RightSection = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerRightSection_TopSection = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemTopSection_Office = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemTopSection_Office = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ItemContainerRightSection_BottomSection = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemBottomSection_Employee = New DevComponents.DotNetBar.LabelItem()
            Me.ComboBoxItemBottomSection_Employee = New DevComponents.DotNetBar.ComboBoxItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_ComparisonDashboard = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Settings = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_EmployeeTimeForecasts
            '
            Me.DataGridViewForm_EmployeeTimeForecasts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_EmployeeTimeForecasts.AllowDragAndDrop = False
            Me.DataGridViewForm_EmployeeTimeForecasts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_EmployeeTimeForecasts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_EmployeeTimeForecasts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_EmployeeTimeForecasts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_EmployeeTimeForecasts.AutoFilterLookupColumns = False
            Me.DataGridViewForm_EmployeeTimeForecasts.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_EmployeeTimeForecasts.AutoUpdateViewCaption = True
            Me.DataGridViewForm_EmployeeTimeForecasts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_EmployeeTimeForecasts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_EmployeeTimeForecasts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_EmployeeTimeForecasts.ItemDescription = "Employee Time Forecast(s)"
            Me.DataGridViewForm_EmployeeTimeForecasts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_EmployeeTimeForecasts.MultiSelect = False
            Me.DataGridViewForm_EmployeeTimeForecasts.Name = "DataGridViewForm_EmployeeTimeForecasts"
            Me.DataGridViewForm_EmployeeTimeForecasts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_EmployeeTimeForecasts.RunStandardValidation = True
            Me.DataGridViewForm_EmployeeTimeForecasts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_EmployeeTimeForecasts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_EmployeeTimeForecasts.Size = New System.Drawing.Size(864, 408)
            Me.DataGridViewForm_EmployeeTimeForecasts.TabIndex = 1
            Me.DataGridViewForm_EmployeeTimeForecasts.UseEmbeddedNavigator = False
            Me.DataGridViewForm_EmployeeTimeForecasts.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 167)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(847, 98)
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
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.DragDropSupport = True
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_LeftSection, Me.ItemContainerSearch_RightSection})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(302, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(472, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 1
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerSearch_LeftSection
            '
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_LeftSection.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_LeftSection.Name = "ItemContainerSearch_LeftSection"
            Me.ItemContainerSearch_LeftSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerLeftSection_TopSection})
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_LeftSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerLeftSection_TopSection
            '
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerLeftSection_TopSection.Name = "ItemContainerLeftSection_TopSection"
            Me.ItemContainerLeftSection_TopSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTopSection_PostPeriod, Me.ComboBoxItemTopSection_PostPeriod})
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerLeftSection_TopSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemTopSection_PostPeriod
            '
            Me.LabelItemTopSection_PostPeriod.Name = "LabelItemTopSection_PostPeriod"
            Me.LabelItemTopSection_PostPeriod.PaddingBottom = 4
            Me.LabelItemTopSection_PostPeriod.PaddingTop = 4
            Me.LabelItemTopSection_PostPeriod.Text = "Post Period:"
            Me.LabelItemTopSection_PostPeriod.Width = 75
            '
            'ComboBoxItemTopSection_PostPeriod
            '
            Me.ComboBoxItemTopSection_PostPeriod.ComboWidth = 125
            Me.ComboBoxItemTopSection_PostPeriod.DropDownHeight = 106
            Me.ComboBoxItemTopSection_PostPeriod.Name = "ComboBoxItemTopSection_PostPeriod"
            Me.ComboBoxItemTopSection_PostPeriod.Text = "ComboBoxItem1"
            '
            'ItemContainerSearch_RightSection
            '
            '
            '
            '
            Me.ItemContainerSearch_RightSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_RightSection.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_RightSection.Name = "ItemContainerSearch_RightSection"
            Me.ItemContainerSearch_RightSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRightSection_TopSection, Me.ItemContainerRightSection_BottomSection})
            '
            '
            '
            Me.ItemContainerSearch_RightSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_RightSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerRightSection_TopSection
            '
            '
            '
            '
            Me.ItemContainerRightSection_TopSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRightSection_TopSection.Name = "ItemContainerRightSection_TopSection"
            Me.ItemContainerRightSection_TopSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemTopSection_Office, Me.ComboBoxItemTopSection_Office})
            '
            '
            '
            Me.ItemContainerRightSection_TopSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRightSection_TopSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemTopSection_Office
            '
            Me.LabelItemTopSection_Office.Name = "LabelItemTopSection_Office"
            Me.LabelItemTopSection_Office.PaddingBottom = 4
            Me.LabelItemTopSection_Office.PaddingTop = 4
            Me.LabelItemTopSection_Office.Text = "Office:"
            Me.LabelItemTopSection_Office.Width = 60
            '
            'ComboBoxItemTopSection_Office
            '
            Me.ComboBoxItemTopSection_Office.ComboWidth = 200
            Me.ComboBoxItemTopSection_Office.DropDownHeight = 106
            Me.ComboBoxItemTopSection_Office.Name = "ComboBoxItemTopSection_Office"
            Me.ComboBoxItemTopSection_Office.Text = "ComboBoxItem1"
            '
            'ItemContainerRightSection_BottomSection
            '
            '
            '
            '
            Me.ItemContainerRightSection_BottomSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRightSection_BottomSection.Name = "ItemContainerRightSection_BottomSection"
            Me.ItemContainerRightSection_BottomSection.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemBottomSection_Employee, Me.ComboBoxItemBottomSection_Employee})
            '
            '
            '
            Me.ItemContainerRightSection_BottomSection.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRightSection_BottomSection.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemBottomSection_Employee
            '
            Me.LabelItemBottomSection_Employee.Name = "LabelItemBottomSection_Employee"
            Me.LabelItemBottomSection_Employee.PaddingBottom = 4
            Me.LabelItemBottomSection_Employee.PaddingTop = 4
            Me.LabelItemBottomSection_Employee.Text = "Employee: "
            Me.LabelItemBottomSection_Employee.Width = 60
            '
            'ComboBoxItemBottomSection_Employee
            '
            Me.ComboBoxItemBottomSection_Employee.ComboWidth = 200
            Me.ComboBoxItemBottomSection_Employee.DropDownHeight = 106
            Me.ComboBoxItemBottomSection_Employee.Name = "ComboBoxItemBottomSection_Employee"
            Me.ComboBoxItemBottomSection_Employee.Text = "ComboBoxItem2"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_View, Me.ButtonItemActions_Add, Me.ButtonItemActions_ComparisonDashboard, Me.ButtonItemActions_Settings, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(302, 98)
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
            '
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_ComparisonDashboard
            '
            Me.ButtonItemActions_ComparisonDashboard.BeginGroup = True
            Me.ButtonItemActions_ComparisonDashboard.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ComparisonDashboard.Name = "ButtonItemActions_ComparisonDashboard"
            Me.ButtonItemActions_ComparisonDashboard.RibbonWordWrap = False
            Me.ButtonItemActions_ComparisonDashboard.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ComparisonDashboard.Text = "Comparison Dashboard"
            '
            'ButtonItemActions_Settings
            '
            Me.ButtonItemActions_Settings.BeginGroup = True
            Me.ButtonItemActions_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Settings.Name = "ButtonItemActions_Settings"
            Me.ButtonItemActions_Settings.RibbonWordWrap = False
            Me.ButtonItemActions_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Settings.Text = "Settings"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'EmployeeTimeForecastForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(888, 432)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_EmployeeTimeForecasts)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastForm"
            Me.Text = "Employee Time Forecast"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_EmployeeTimeForecasts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerSearch_LeftSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerLeftSection_TopSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTopSection_PostPeriod As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ComboBoxItemTopSection_PostPeriod As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ItemContainerSearch_RightSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerRightSection_TopSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemTopSection_Office As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ComboBoxItemTopSection_Office As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ItemContainerRightSection_BottomSection As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemBottomSection_Employee As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ComboBoxItemBottomSection_Employee As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_ComparisonDashboard As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Settings As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace