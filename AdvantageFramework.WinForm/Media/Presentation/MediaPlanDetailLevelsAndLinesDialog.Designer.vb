Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailLevelsAndLinesDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelsAndLinesDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_DetailLines = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_AddLevel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddRow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_CopyLines = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemCopyLines_LinesOnly = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCopyLines_IncludeData = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonForm_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_SpellCheck = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.RadioButtonForm_None = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_AdSize = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_PackageLevels = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(905, 698)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_DetailLines
            '
            Me.DataGridViewForm_DetailLines.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_DetailLines.AllowDragAndDrop = False
            Me.DataGridViewForm_DetailLines.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_DetailLines.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_DetailLines.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_DetailLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_DetailLines.AutoFilterLookupColumns = False
            Me.DataGridViewForm_DetailLines.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_DetailLines.AutoUpdateViewCaption = True
            Me.DataGridViewForm_DetailLines.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_DetailLines.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_DetailLines.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_DetailLines.ItemDescription = "Level/Line(s)"
            Me.DataGridViewForm_DetailLines.Location = New System.Drawing.Point(123, 12)
            Me.DataGridViewForm_DetailLines.MultiSelect = True
            Me.DataGridViewForm_DetailLines.Name = "DataGridViewForm_DetailLines"
            Me.DataGridViewForm_DetailLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_DetailLines.RunStandardValidation = True
            Me.DataGridViewForm_DetailLines.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_DetailLines.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_DetailLines.Size = New System.Drawing.Size(857, 680)
            Me.DataGridViewForm_DetailLines.TabIndex = 0
            Me.DataGridViewForm_DetailLines.UseEmbeddedNavigator = False
            Me.DataGridViewForm_DetailLines.ViewCaptionHeight = -1
            '
            'ButtonForm_AddLevel
            '
            Me.ButtonForm_AddLevel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_AddLevel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddLevel.Location = New System.Drawing.Point(123, 698)
            Me.ButtonForm_AddLevel.Name = "ButtonForm_AddLevel"
            Me.ButtonForm_AddLevel.SecurityEnabled = True
            Me.ButtonForm_AddLevel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddLevel.TabIndex = 1
            Me.ButtonForm_AddLevel.Text = "Add Level"
            '
            'ButtonForm_AddRow
            '
            Me.ButtonForm_AddRow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_AddRow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddRow.Location = New System.Drawing.Point(204, 698)
            Me.ButtonForm_AddRow.Name = "ButtonForm_AddRow"
            Me.ButtonForm_AddRow.SecurityEnabled = True
            Me.ButtonForm_AddRow.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddRow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddRow.TabIndex = 2
            Me.ButtonForm_AddRow.Text = "Add Row"
            '
            'ButtonForm_CopyFrom
            '
            Me.ButtonForm_CopyFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_CopyFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_CopyFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_CopyFrom.Location = New System.Drawing.Point(366, 698)
            Me.ButtonForm_CopyFrom.Name = "ButtonForm_CopyFrom"
            Me.ButtonForm_CopyFrom.SecurityEnabled = True
            Me.ButtonForm_CopyFrom.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_CopyFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_CopyFrom.TabIndex = 4
            Me.ButtonForm_CopyFrom.Text = "Copy From"
            '
            'ButtonForm_CopyLines
            '
            Me.ButtonForm_CopyLines.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_CopyLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_CopyLines.AutoExpandOnClick = True
            Me.ButtonForm_CopyLines.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_CopyLines.Location = New System.Drawing.Point(285, 698)
            Me.ButtonForm_CopyLines.Name = "ButtonForm_CopyLines"
            Me.ButtonForm_CopyLines.SecurityEnabled = True
            Me.ButtonForm_CopyLines.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_CopyLines.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_CopyLines.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCopyLines_LinesOnly, Me.ButtonItemCopyLines_IncludeData})
            Me.ButtonForm_CopyLines.TabIndex = 3
            Me.ButtonForm_CopyLines.Text = "Copy Lines"
            '
            'ButtonItemCopyLines_LinesOnly
            '
            Me.ButtonItemCopyLines_LinesOnly.GlobalItem = False
            Me.ButtonItemCopyLines_LinesOnly.Name = "ButtonItemCopyLines_LinesOnly"
            Me.ButtonItemCopyLines_LinesOnly.SecurityEnabled = True
            Me.ButtonItemCopyLines_LinesOnly.Text = "Lines Only"
            '
            'ButtonItemCopyLines_IncludeData
            '
            Me.ButtonItemCopyLines_IncludeData.GlobalItem = False
            Me.ButtonItemCopyLines_IncludeData.Name = "ButtonItemCopyLines_IncludeData"
            Me.ButtonItemCopyLines_IncludeData.SecurityEnabled = True
            Me.ButtonItemCopyLines_IncludeData.Text = "Include Data"
            '
            'ButtonForm_MoveDown
            '
            Me.ButtonForm_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveDown.Location = New System.Drawing.Point(12, 38)
            Me.ButtonForm_MoveDown.Name = "ButtonForm_MoveDown"
            Me.ButtonForm_MoveDown.SecurityEnabled = True
            Me.ButtonForm_MoveDown.Size = New System.Drawing.Size(105, 20)
            Me.ButtonForm_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveDown.TabIndex = 4
            Me.ButtonForm_MoveDown.Text = "Move Down"
            '
            'ButtonForm_MoveUp
            '
            Me.ButtonForm_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MoveUp.Location = New System.Drawing.Point(12, 12)
            Me.ButtonForm_MoveUp.Name = "ButtonForm_MoveUp"
            Me.ButtonForm_MoveUp.SecurityEnabled = True
            Me.ButtonForm_MoveUp.Size = New System.Drawing.Size(105, 20)
            Me.ButtonForm_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MoveUp.TabIndex = 3
            Me.ButtonForm_MoveUp.Text = "Move Up"
            '
            'ButtonForm_SpellCheck
            '
            Me.ButtonForm_SpellCheck.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_SpellCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_SpellCheck.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_SpellCheck.Location = New System.Drawing.Point(447, 698)
            Me.ButtonForm_SpellCheck.Name = "ButtonForm_SpellCheck"
            Me.ButtonForm_SpellCheck.SecurityEnabled = True
            Me.ButtonForm_SpellCheck.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_SpellCheck.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_SpellCheck.TabIndex = 5
            Me.ButtonForm_SpellCheck.Text = "Spell Check"
            '
            'RadioButtonForm_None
            '
            Me.RadioButtonForm_None.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_None.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_None.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_None.Location = New System.Drawing.Point(12, 64)
            Me.RadioButtonForm_None.Name = "RadioButtonForm_None"
            Me.RadioButtonForm_None.SecurityEnabled = True
            Me.RadioButtonForm_None.Size = New System.Drawing.Size(105, 20)
            Me.RadioButtonForm_None.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_None.TabIndex = 0
            Me.RadioButtonForm_None.TabOnEnter = True
            Me.RadioButtonForm_None.TabStop = False
            Me.RadioButtonForm_None.Tag = ""
            Me.RadioButtonForm_None.Text = "None"
            '
            'RadioButtonForm_AdSize
            '
            Me.RadioButtonForm_AdSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_AdSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_AdSize.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_AdSize.Location = New System.Drawing.Point(12, 116)
            Me.RadioButtonForm_AdSize.Name = "RadioButtonForm_AdSize"
            Me.RadioButtonForm_AdSize.SecurityEnabled = True
            Me.RadioButtonForm_AdSize.Size = New System.Drawing.Size(105, 20)
            Me.RadioButtonForm_AdSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_AdSize.TabIndex = 1
            Me.RadioButtonForm_AdSize.TabOnEnter = True
            Me.RadioButtonForm_AdSize.TabStop = False
            Me.RadioButtonForm_AdSize.Tag = ""
            Me.RadioButtonForm_AdSize.Text = "Add'l Ad Sizes"
            '
            'RadioButtonForm_PackageLevels
            '
            Me.RadioButtonForm_PackageLevels.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_PackageLevels.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_PackageLevels.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_PackageLevels.Location = New System.Drawing.Point(12, 90)
            Me.RadioButtonForm_PackageLevels.Name = "RadioButtonForm_PackageLevels"
            Me.RadioButtonForm_PackageLevels.SecurityEnabled = True
            Me.RadioButtonForm_PackageLevels.Size = New System.Drawing.Size(105, 20)
            Me.RadioButtonForm_PackageLevels.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_PackageLevels.TabIndex = 2
            Me.RadioButtonForm_PackageLevels.TabOnEnter = True
            Me.RadioButtonForm_PackageLevels.TabStop = False
            Me.RadioButtonForm_PackageLevels.Tag = ""
            Me.RadioButtonForm_PackageLevels.Text = "Package Levels"
            '
            'MediaPlanDetailLevelsAndLinesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Controls.Add(Me.RadioButtonForm_PackageLevels)
            Me.Controls.Add(Me.RadioButtonForm_AdSize)
            Me.Controls.Add(Me.RadioButtonForm_None)
            Me.Controls.Add(Me.ButtonForm_SpellCheck)
            Me.Controls.Add(Me.ButtonForm_MoveDown)
            Me.Controls.Add(Me.ButtonForm_MoveUp)
            Me.Controls.Add(Me.ButtonForm_CopyLines)
            Me.Controls.Add(Me.ButtonForm_CopyFrom)
            Me.Controls.Add(Me.ButtonForm_AddRow)
            Me.Controls.Add(Me.ButtonForm_AddLevel)
            Me.Controls.Add(Me.DataGridViewForm_DetailLines)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanDetailLevelsAndLinesDialog"
            Me.Text = "Manage Detail Levels/Lines"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_DetailLines As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_AddLevel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddRow As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_CopyLines As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemCopyLines_LinesOnly As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCopyLines_IncludeData As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonForm_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_SpellCheck As WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonForm_None As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_AdSize As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_PackageLevels As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace