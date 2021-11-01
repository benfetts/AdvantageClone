Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserCDPLimitControl
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
            Me.PanelControl_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveCDP = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddCDP = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedCDPs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelControl_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableCDPs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
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
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveCDP)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddCDP)
            Me.PanelControl_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedCDPs)
            Me.PanelControl_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_RightSection.Location = New System.Drawing.Point(253, 0)
            Me.PanelControl_RightSection.Name = "PanelControl_RightSection"
            Me.PanelControl_RightSection.Size = New System.Drawing.Size(317, 394)
            Me.PanelControl_RightSection.TabIndex = 30
            '
            'ButtonRightSection_RemoveCDP
            '
            Me.ButtonRightSection_RemoveCDP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveCDP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveCDP.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveCDP.Name = "ButtonRightSection_RemoveCDP"
            Me.ButtonRightSection_RemoveCDP.SecurityEnabled = True
            Me.ButtonRightSection_RemoveCDP.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveCDP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveCDP.TabIndex = 24
            Me.ButtonRightSection_RemoveCDP.Text = "<"
            '
            'ButtonRightSection_AddCDP
            '
            Me.ButtonRightSection_AddCDP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddCDP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddCDP.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddCDP.Name = "ButtonRightSection_AddCDP"
            Me.ButtonRightSection_AddCDP.SecurityEnabled = True
            Me.ButtonRightSection_AddCDP.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddCDP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddCDP.TabIndex = 22
            Me.ButtonRightSection_AddCDP.Text = ">"
            '
            'DataGridViewRightSection_SelectedCDPs
            '
            Me.DataGridViewRightSection_SelectedCDPs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedCDPs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedCDPs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedCDPs.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedCDPs.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedCDPs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_SelectedCDPs.DataSource = Nothing
            Me.DataGridViewRightSection_SelectedCDPs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedCDPs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedCDPs.ItemDescription = "Limited CDP(s)"
            Me.DataGridViewRightSection_SelectedCDPs.Location = New System.Drawing.Point(85, 0)
            Me.DataGridViewRightSection_SelectedCDPs.MultiSelect = True
            Me.DataGridViewRightSection_SelectedCDPs.Name = "DataGridViewRightSection_SelectedCDPs"
            Me.DataGridViewRightSection_SelectedCDPs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedCDPs.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedCDPs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedCDPs.Size = New System.Drawing.Size(232, 394)
            Me.DataGridViewRightSection_SelectedCDPs.TabIndex = 21
            Me.DataGridViewRightSection_SelectedCDPs.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedCDPs.ViewCaptionHeight = -1
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
            Me.PanelControl_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableCDPs)
            Me.PanelControl_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelControl_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_LeftSection.Name = "PanelControl_LeftSection"
            Me.PanelControl_LeftSection.Size = New System.Drawing.Size(247, 394)
            Me.PanelControl_LeftSection.TabIndex = 29
            '
            'DataGridViewLeftSection_AvailableCDPs
            '
            Me.DataGridViewLeftSection_AvailableCDPs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableCDPs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableCDPs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableCDPs.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableCDPs.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableCDPs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableCDPs.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableCDPs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableCDPs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableCDPs.ItemDescription = "Client Division Product(s)"
            Me.DataGridViewLeftSection_AvailableCDPs.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableCDPs.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableCDPs.Name = "DataGridViewLeftSection_AvailableCDPs"
            Me.DataGridViewLeftSection_AvailableCDPs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableCDPs.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableCDPs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableCDPs.Size = New System.Drawing.Size(241, 394)
            Me.DataGridViewLeftSection_AvailableCDPs.TabIndex = 23
            Me.DataGridViewLeftSection_AvailableCDPs.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableCDPs.ViewCaptionHeight = -1
            '
            'UserCDPLimitControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.Controls.Add(Me.PanelControl_LeftSection)
            Me.Name = "UserCDPLimitControl"
            Me.Size = New System.Drawing.Size(570, 394)
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_RightSection.ResumeLayout(False)
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveCDP As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddCDP As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_SelectedCDPs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelControl_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableCDPs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace
