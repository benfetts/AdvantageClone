Namespace WinForm.Presentation.MVCControls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MultiSelectControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.PanelControl_RightSection = New AdvantageFramework.WinForm.Presentation.MVCControls.Panel()
			Me.ButtonRightSection_RemoveObject = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonRightSection_AddObject = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.DataGridViewRightSection_SelectedObjects = New AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView()
			Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
			Me.PanelControl_LeftSection = New AdvantageFramework.WinForm.Presentation.MVCControls.Panel()
            Me.DataGridViewLeftSection_AvailableObjects = New AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView()
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
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveObject)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddObject)
            Me.PanelControl_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedObjects)
            Me.PanelControl_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_RightSection.Location = New System.Drawing.Point(253, 0)
            Me.PanelControl_RightSection.Name = "PanelControl_RightSection"
            Me.PanelControl_RightSection.Size = New System.Drawing.Size(317, 394)
            Me.PanelControl_RightSection.TabIndex = 30
            '
            'ButtonRightSection_RemoveObject
            '
            Me.ButtonRightSection_RemoveObject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveObject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveObject.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveObject.Name = "ButtonRightSection_RemoveObject"
            Me.ButtonRightSection_RemoveObject.SecurityEnabled = True
            Me.ButtonRightSection_RemoveObject.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveObject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveObject.TabIndex = 24
            Me.ButtonRightSection_RemoveObject.Text = "<"
            '
            'ButtonRightSection_AddObject
            '
            Me.ButtonRightSection_AddObject.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddObject.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddObject.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddObject.Name = "ButtonRightSection_AddObject"
            Me.ButtonRightSection_AddObject.SecurityEnabled = True
            Me.ButtonRightSection_AddObject.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddObject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddObject.TabIndex = 22
            Me.ButtonRightSection_AddObject.Text = ">"
            '
            'DataGridViewRightSection_SelectedObjects
            '
            Me.DataGridViewRightSection_SelectedObjects.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_SelectedObjects.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedObjects.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedObjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedObjects.ControlType = AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_SelectedObjects.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedObjects.ItemDescription = "Item(s)"
            Me.DataGridViewRightSection_SelectedObjects.Location = New System.Drawing.Point(85, 0)
            Me.DataGridViewRightSection_SelectedObjects.MultiSelect = True
            Me.DataGridViewRightSection_SelectedObjects.Name = "DataGridViewRightSection_SelectedObjects"
            Me.DataGridViewRightSection_SelectedObjects.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedObjects.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedObjects.Size = New System.Drawing.Size(232, 394)
            Me.DataGridViewRightSection_SelectedObjects.TabIndex = 21
            Me.DataGridViewRightSection_SelectedObjects.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedObjects.ViewCaptionHeight = -1
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
            Me.PanelControl_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableObjects)
            Me.PanelControl_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelControl_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_LeftSection.Name = "PanelControl_LeftSection"
            Me.PanelControl_LeftSection.Size = New System.Drawing.Size(247, 394)
            Me.PanelControl_LeftSection.TabIndex = 29
            '
            'DataGridViewLeftSection_AvailableObjects
            '
            Me.DataGridViewLeftSection_AvailableObjects.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableObjects.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableObjects.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableObjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableObjects.ControlType = AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableObjects.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableObjects.ItemDescription = "Item(s)"
            Me.DataGridViewLeftSection_AvailableObjects.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableObjects.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableObjects.Name = "DataGridViewLeftSection_AvailableObjects"
            Me.DataGridViewLeftSection_AvailableObjects.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableObjects.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableObjects.Size = New System.Drawing.Size(241, 394)
            Me.DataGridViewLeftSection_AvailableObjects.TabIndex = 23
            Me.DataGridViewLeftSection_AvailableObjects.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableObjects.ViewCaptionHeight = -1
            '
            'MultiSelectControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.Controls.Add(Me.PanelControl_LeftSection)
            Me.Name = "MultiSelectControl"
            Me.Size = New System.Drawing.Size(570, 394)
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_RightSection.ResumeLayout(False)
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_RightSection As AdvantageFramework.WinForm.Presentation.MVCControls.Panel
		Friend WithEvents ButtonRightSection_RemoveObject As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonRightSection_AddObject As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents DataGridViewRightSection_SelectedObjects As AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView
		Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
		Friend WithEvents PanelControl_LeftSection As AdvantageFramework.WinForm.Presentation.MVCControls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableObjects As AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView

    End Class

End Namespace
