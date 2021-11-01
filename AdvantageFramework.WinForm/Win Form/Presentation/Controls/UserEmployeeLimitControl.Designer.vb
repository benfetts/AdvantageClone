Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserEmployeeLimitControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.PanelControl_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelControl_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_RightSection.SuspendLayout()
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelControl_RightSection
            '
            Me.PanelControl_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelControl_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveEmployee)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddEmployee)
            Me.PanelControl_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedEmployees)
            Me.PanelControl_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_RightSection.Location = New System.Drawing.Point(253, 0)
            Me.PanelControl_RightSection.Name = "PanelControl_RightSection"
            Me.PanelControl_RightSection.Size = New System.Drawing.Size(317, 394)
            Me.PanelControl_RightSection.TabIndex = 30
            '
            'ButtonRightSection_RemoveEmployee
            '
            Me.ButtonRightSection_RemoveEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveEmployee.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveEmployee.Name = "ButtonRightSection_RemoveEmployee"
            Me.ButtonRightSection_RemoveEmployee.SecurityEnabled = True
            Me.ButtonRightSection_RemoveEmployee.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveEmployee.TabIndex = 24
            Me.ButtonRightSection_RemoveEmployee.Text = "<"
            '
            'ButtonRightSection_AddEmployee
            '
            Me.ButtonRightSection_AddEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddEmployee.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddEmployee.Name = "ButtonRightSection_AddEmployee"
            Me.ButtonRightSection_AddEmployee.SecurityEnabled = True
            Me.ButtonRightSection_AddEmployee.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddEmployee.TabIndex = 22
            Me.ButtonRightSection_AddEmployee.Text = ">"
            '
            'DataGridViewRightSection_SelectedEmployees
            '
            Me.DataGridViewRightSection_SelectedEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_SelectedEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedEmployees.ItemDescription = "Limited Employee(s)"
            Me.DataGridViewRightSection_SelectedEmployees.Location = New System.Drawing.Point(85, 0)
            Me.DataGridViewRightSection_SelectedEmployees.MultiSelect = True
            Me.DataGridViewRightSection_SelectedEmployees.Name = "DataGridViewRightSection_SelectedEmployees"
            Me.DataGridViewRightSection_SelectedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedEmployees.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedEmployees.Size = New System.Drawing.Size(232, 394)
            Me.DataGridViewRightSection_SelectedEmployees.TabIndex = 21
            Me.DataGridViewRightSection_SelectedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedEmployees.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl_LeftRight
            '
            Me.ExpandableSplitterControl_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl_LeftRight.ExpandableControl = Me.PanelControl_LeftSection
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.Location = New System.Drawing.Point(247, 0)
            Me.ExpandableSplitterControl_LeftRight.Name = "ExpandableSplitterControl_LeftRight"
            Me.ExpandableSplitterControl_LeftRight.Size = New System.Drawing.Size(6, 394)
            Me.ExpandableSplitterControl_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl_LeftRight.TabIndex = 32
            Me.ExpandableSplitterControl_LeftRight.TabStop = False
            '
            'PanelControl_LeftSection
            '
            Me.PanelControl_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelControl_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableEmployees)
            Me.PanelControl_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelControl_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_LeftSection.Name = "PanelControl_LeftSection"
            Me.PanelControl_LeftSection.Size = New System.Drawing.Size(247, 394)
            Me.PanelControl_LeftSection.TabIndex = 29
            '
            'DataGridViewLeftSection_AvailableEmployees
            '
            Me.DataGridViewLeftSection_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableEmployees.ItemDescription = "Employee(s)"
            Me.DataGridViewLeftSection_AvailableEmployees.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableEmployees.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableEmployees.Name = "DataGridViewLeftSection_AvailableEmployees"
            Me.DataGridViewLeftSection_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableEmployees.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableEmployees.Size = New System.Drawing.Size(241, 394)
            Me.DataGridViewLeftSection_AvailableEmployees.TabIndex = 23
            Me.DataGridViewLeftSection_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableEmployees.ViewCaptionHeight = -1
            '
            'UserEmployeeLimitControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.Controls.Add(Me.PanelControl_LeftSection)
            Me.Name = "UserEmployeeLimitControl"
            Me.Size = New System.Drawing.Size(570, 394)
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_RightSection.ResumeLayout(False)
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_SelectedEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelControl_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
