Namespace Database.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class APIDatabaseUpdateForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(APIDatabaseUpdateForm))
            Me.RadTreeViewForm_Updates = New Telerik.WinControls.UI.RadTreeView()
            Me.LabelForm_APIVersion = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_APIVersionNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemView_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_VersionInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AvailableUpdates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_UpdateLog = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UpdateLog = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.RadTreeViewForm_Updates, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RadTreeViewForm_Updates
            '
            Me.RadTreeViewForm_Updates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadTreeViewForm_Updates.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.RadTreeViewForm_Updates.CheckBoxes = True
            Me.RadTreeViewForm_Updates.Location = New System.Drawing.Point(12, 38)
            Me.RadTreeViewForm_Updates.Name = "RadTreeViewForm_Updates"
            '
            '
            '
            Me.RadTreeViewForm_Updates.RootElement.AccessibleDescription = Nothing
            Me.RadTreeViewForm_Updates.RootElement.AccessibleName = Nothing
            Me.RadTreeViewForm_Updates.RootElement.ControlBounds = New System.Drawing.Rectangle(0, 0, 150, 250)
            Me.RadTreeViewForm_Updates.ShowLines = True
            Me.RadTreeViewForm_Updates.Size = New System.Drawing.Size(231, 390)
            Me.RadTreeViewForm_Updates.SpacingBetweenNodes = -1
            Me.RadTreeViewForm_Updates.TabIndex = 1
            '
            'LabelForm_APIVersion
            '
            Me.LabelForm_APIVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_APIVersion.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_APIVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_APIVersion.Location = New System.Drawing.Point(249, 38)
            Me.LabelForm_APIVersion.Name = "LabelForm_APIVersion"
            Me.LabelForm_APIVersion.Size = New System.Drawing.Size(111, 20)
            Me.LabelForm_APIVersion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_APIVersion.TabIndex = 2
            Me.LabelForm_APIVersion.Text = "Advantage Version:"
            '
            'LabelForm_APIVersionNumber
            '
            Me.LabelForm_APIVersionNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_APIVersionNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_APIVersionNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_APIVersionNumber.Location = New System.Drawing.Point(366, 38)
            Me.LabelForm_APIVersionNumber.Name = "LabelForm_APIVersionNumber"
            Me.LabelForm_APIVersionNumber.Size = New System.Drawing.Size(231, 20)
            Me.LabelForm_APIVersionNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_APIVersionNumber.TabIndex = 4
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(328, 259)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(270, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 6
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ExpandAll, Me.ButtonItemView_CollapseAll})
            Me.RibbonBarOptions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(65, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(74, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 4
            Me.RibbonBarOptions_View.Text = "View"
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
            'ButtonItemView_ExpandAll
            '
            Me.ButtonItemView_ExpandAll.Name = "ButtonItemView_ExpandAll"
            Me.ButtonItemView_ExpandAll.Stretch = True
            Me.ButtonItemView_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_ExpandAll.Text = "Expand All"
            '
            'ButtonItemView_CollapseAll
            '
            Me.ButtonItemView_CollapseAll.BeginGroup = True
            Me.ButtonItemView_CollapseAll.Name = "ButtonItemView_CollapseAll"
            Me.ButtonItemView_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemView_CollapseAll.Text = "Collapse All"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(65, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'LabelForm_VersionInformation
            '
            Me.LabelForm_VersionInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_VersionInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_VersionInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_VersionInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VersionInformation.Location = New System.Drawing.Point(249, 12)
            Me.LabelForm_VersionInformation.Name = "LabelForm_VersionInformation"
            Me.LabelForm_VersionInformation.Size = New System.Drawing.Size(348, 20)
            Me.LabelForm_VersionInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VersionInformation.TabIndex = 9
            Me.LabelForm_VersionInformation.Text = "Version Information"
            '
            'LabelForm_AvailableUpdates
            '
            Me.LabelForm_AvailableUpdates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AvailableUpdates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AvailableUpdates.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_AvailableUpdates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AvailableUpdates.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_AvailableUpdates.Name = "LabelForm_AvailableUpdates"
            Me.LabelForm_AvailableUpdates.Size = New System.Drawing.Size(231, 20)
            Me.LabelForm_AvailableUpdates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AvailableUpdates.TabIndex = 10
            Me.LabelForm_AvailableUpdates.Text = "Available Updates"
            '
            'LabelForm_UpdateLog
            '
            Me.LabelForm_UpdateLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_UpdateLog.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateLog.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_UpdateLog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UpdateLog.Location = New System.Drawing.Point(249, 64)
            Me.LabelForm_UpdateLog.Name = "LabelForm_UpdateLog"
            Me.LabelForm_UpdateLog.Size = New System.Drawing.Size(348, 20)
            Me.LabelForm_UpdateLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UpdateLog.TabIndex = 11
            Me.LabelForm_UpdateLog.Text = "Update Log"
            '
            'TextBoxForm_UpdateLog
            '
            Me.TextBoxForm_UpdateLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_UpdateLog.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UpdateLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UpdateLog.CheckSpellingOnValidate = False
            Me.TextBoxForm_UpdateLog.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_UpdateLog.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UpdateLog.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_UpdateLog.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UpdateLog.FocusHighlightEnabled = True
            Me.TextBoxForm_UpdateLog.Location = New System.Drawing.Point(249, 90)
            Me.TextBoxForm_UpdateLog.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_UpdateLog.Multiline = True
            Me.TextBoxForm_UpdateLog.Name = "TextBoxForm_UpdateLog"
            Me.TextBoxForm_UpdateLog.ReadOnly = True
            Me.TextBoxForm_UpdateLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxForm_UpdateLog.SecurityEnabled = True
            Me.TextBoxForm_UpdateLog.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_UpdateLog.Size = New System.Drawing.Size(348, 338)
            Me.TextBoxForm_UpdateLog.StartingFolderName = Nothing
            Me.TextBoxForm_UpdateLog.TabIndex = 12
            Me.TextBoxForm_UpdateLog.TabOnEnter = True
            '
            'APIDatabaseUpdateForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(609, 440)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TextBoxForm_UpdateLog)
            Me.Controls.Add(Me.LabelForm_UpdateLog)
            Me.Controls.Add(Me.LabelForm_AvailableUpdates)
            Me.Controls.Add(Me.LabelForm_VersionInformation)
            Me.Controls.Add(Me.RadTreeViewForm_Updates)
            Me.Controls.Add(Me.LabelForm_APIVersionNumber)
            Me.Controls.Add(Me.LabelForm_APIVersion)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "APIDatabaseUpdateForm"
            Me.Text = "Database Update"
            CType(Me.RadTreeViewForm_Updates, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_APIVersion As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_APIVersionNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemView_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_VersionInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AvailableUpdates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_UpdateLog As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_UpdateLog As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents RadTreeViewForm_Updates As Telerik.WinControls.UI.RadTreeView
    End Class

End Namespace
