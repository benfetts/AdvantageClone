Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleGanttViewDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleGanttViewDialog))
            Dim GanttDiagram1 As DevExpress.XtraCharts.GanttDiagram = New DevExpress.XtraCharts.GanttDiagram()
            Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim OverlappedGanttSeriesView1 As DevExpress.XtraCharts.OverlappedGanttSeriesView = New DevExpress.XtraCharts.OverlappedGanttSeriesView()
            Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
            Dim OverlappedGanttSeriesView2 As DevExpress.XtraCharts.OverlappedGanttSeriesView = New DevExpress.XtraCharts.OverlappedGanttSeriesView()
            Dim OverlappedGanttSeriesView3 As DevExpress.XtraCharts.OverlappedGanttSeriesView = New DevExpress.XtraCharts.OverlappedGanttSeriesView()
            Me.RibbonBarOptions_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemOptions_Calculate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemOptions_Month = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Week = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOptions_Day = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerOptions_Options = New DevComponents.DotNetBar.ItemContainer()
            Me.CheckBoxItemOptions_Phase = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemOptions_Labels = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemOptions_RelatedJobs = New DevComponents.DotNetBar.CheckBoxItem()
            Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(GanttDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(OverlappedGanttSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(OverlappedGanttSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(OverlappedGanttSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(874, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(874, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_View, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.ChartControl1)
            Me.PanelForm_Form.Size = New System.Drawing.Size(874, 418)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 573)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(874, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Calculate})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(66, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 2
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
            'ButtonItemOptions_Calculate
            '
            Me.ButtonItemOptions_Calculate.BeginGroup = True
            Me.ButtonItemOptions_Calculate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Calculate.Name = "ButtonItemOptions_Calculate"
            Me.ButtonItemOptions_Calculate.RibbonWordWrap = False
            Me.ButtonItemOptions_Calculate.SecurityEnabled = True
            Me.ButtonItemOptions_Calculate.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Calculate.Text = "Calculate"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_Month, Me.ButtonItemOptions_Week, Me.ButtonItemOptions_Day, Me.ItemContainerOptions_Options})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(169, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(228, 92)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 3
            Me.RibbonBarOptions_View.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemOptions_Month
            '
            Me.ButtonItemOptions_Month.AutoCheckOnClick = True
            Me.ButtonItemOptions_Month.BeginGroup = True
            Me.ButtonItemOptions_Month.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Month.Name = "ButtonItemOptions_Month"
            Me.ButtonItemOptions_Month.RibbonWordWrap = False
            Me.ButtonItemOptions_Month.SecurityEnabled = True
            Me.ButtonItemOptions_Month.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Month.Text = "Month"
            '
            'ButtonItemOptions_Week
            '
            Me.ButtonItemOptions_Week.AutoCheckOnClick = True
            Me.ButtonItemOptions_Week.BeginGroup = True
            Me.ButtonItemOptions_Week.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Week.Name = "ButtonItemOptions_Week"
            Me.ButtonItemOptions_Week.RibbonWordWrap = False
            Me.ButtonItemOptions_Week.SecurityEnabled = True
            Me.ButtonItemOptions_Week.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Week.Text = "Week"
            '
            'ButtonItemOptions_Day
            '
            Me.ButtonItemOptions_Day.AutoCheckOnClick = True
            Me.ButtonItemOptions_Day.BeginGroup = True
            Me.ButtonItemOptions_Day.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_Day.Name = "ButtonItemOptions_Day"
            Me.ButtonItemOptions_Day.RibbonWordWrap = False
            Me.ButtonItemOptions_Day.SecurityEnabled = True
            Me.ButtonItemOptions_Day.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_Day.Text = "Day"
            '
            'ItemContainerOptions_Options
            '
            '
            '
            '
            Me.ItemContainerOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_Options.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerOptions_Options.MinimumSize = New System.Drawing.Size(110, 0)
            Me.ItemContainerOptions_Options.Name = "ItemContainerOptions_Options"
            Me.ItemContainerOptions_Options.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemOptions_Phase, Me.CheckBoxItemOptions_Labels, Me.CheckBoxItemOptions_RelatedJobs})
            '
            '
            '
            Me.ItemContainerOptions_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerOptions_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'CheckBoxItemOptions_Phase
            '
            Me.CheckBoxItemOptions_Phase.Name = "CheckBoxItemOptions_Phase"
            Me.CheckBoxItemOptions_Phase.Text = "Phase"
            '
            'CheckBoxItemOptions_Labels
            '
            Me.CheckBoxItemOptions_Labels.Name = "CheckBoxItemOptions_Labels"
            Me.CheckBoxItemOptions_Labels.Text = "Labels"
            '
            'CheckBoxItemOptions_RelatedJobs
            '
            Me.CheckBoxItemOptions_RelatedJobs.Name = "CheckBoxItemOptions_RelatedJobs"
            Me.CheckBoxItemOptions_RelatedJobs.Text = "Related Jobs"
            '
            'ChartControl1
            '
            GanttDiagram1.AxisX.VisibleInPanesSerializable = "-1"
            GanttDiagram1.AxisY.VisibleInPanesSerializable = "-1"
            Me.ChartControl1.Diagram = GanttDiagram1
            Me.ChartControl1.Location = New System.Drawing.Point(3, 6)
            Me.ChartControl1.Name = "ChartControl1"
            Me.ChartControl1.PaletteName = "Origin"
            Series1.Name = "Series 1"
            Series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime
            Series1.View = OverlappedGanttSeriesView1
            Series2.Name = "Series 2"
            Series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime
            Series2.View = OverlappedGanttSeriesView2
            Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1, Series2}
            Me.ChartControl1.SeriesTemplate.View = OverlappedGanttSeriesView3
            Me.ChartControl1.Size = New System.Drawing.Size(868, 406)
            Me.ChartControl1.TabIndex = 0
            '
            'ProjectScheduleGanttViewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(884, 593)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleGanttViewDialog"
            Me.Text = "Project Schedule"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(GanttDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(OverlappedGanttSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(OverlappedGanttSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(OverlappedGanttSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemOptions_Calculate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemOptions_Month As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Week As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOptions_Day As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerOptions_Options As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents CheckBoxItemOptions_Phase As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemOptions_Labels As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemOptions_RelatedJobs As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    End Class

End Namespace