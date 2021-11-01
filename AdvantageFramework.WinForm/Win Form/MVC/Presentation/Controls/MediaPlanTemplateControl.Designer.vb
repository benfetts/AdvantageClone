Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanTemplateControl
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
            Me.DataGridViewControl_PlanEstimateTemplates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.PanelControl_Panel = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxControl_IsInactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Panel.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewControl_PlanEstimateTemplates
            '
            Me.DataGridViewControl_PlanEstimateTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_PlanEstimateTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_PlanEstimateTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewControl_PlanEstimateTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_PlanEstimateTemplates.ItemDescription = "Estimate Template(s)"
            Me.DataGridViewControl_PlanEstimateTemplates.Location = New System.Drawing.Point(0, 53)
            Me.DataGridViewControl_PlanEstimateTemplates.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_PlanEstimateTemplates.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_PlanEstimateTemplates.ModifyGridRowHeight = False
            Me.DataGridViewControl_PlanEstimateTemplates.MultiSelect = True
            Me.DataGridViewControl_PlanEstimateTemplates.Name = "DataGridViewControl_PlanEstimateTemplates"
            Me.DataGridViewControl_PlanEstimateTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_PlanEstimateTemplates.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_PlanEstimateTemplates.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_PlanEstimateTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_PlanEstimateTemplates.Size = New System.Drawing.Size(424, 365)
            Me.DataGridViewControl_PlanEstimateTemplates.TabIndex = 7
            Me.DataGridViewControl_PlanEstimateTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewControl_PlanEstimateTemplates.ViewCaptionHeight = -1
            '
            'PanelControl_Panel
            '
            Me.PanelControl_Panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Panel.Controls.Add(Me.CheckBoxControl_IsInactive)
            Me.PanelControl_Panel.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Panel.Controls.Add(Me.LabelControl_Description)
            Me.PanelControl_Panel.Controls.Add(Me.DataGridViewControl_PlanEstimateTemplates)
            Me.PanelControl_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Panel.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Panel.Name = "PanelControl_Panel"
            Me.PanelControl_Panel.Size = New System.Drawing.Size(424, 418)
            Me.PanelControl_Panel.TabIndex = 0
            '
            'CheckBoxControl_IsInactive
            '
            Me.CheckBoxControl_IsInactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_IsInactive.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxControl_IsInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_IsInactive.CheckValue = 0
            Me.CheckBoxControl_IsInactive.CheckValueChecked = 1
            Me.CheckBoxControl_IsInactive.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_IsInactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_IsInactive.ChildControls = Nothing
            Me.CheckBoxControl_IsInactive.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_IsInactive.Location = New System.Drawing.Point(74, 26)
            Me.CheckBoxControl_IsInactive.Name = "CheckBoxControl_IsInactive"
            Me.CheckBoxControl_IsInactive.OldestSibling = Nothing
            Me.CheckBoxControl_IsInactive.SecurityEnabled = True
            Me.CheckBoxControl_IsInactive.SiblingControls = Nothing
            Me.CheckBoxControl_IsInactive.Size = New System.Drawing.Size(350, 20)
            Me.CheckBoxControl_IsInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_IsInactive.TabIndex = 8
            Me.CheckBoxControl_IsInactive.TabOnEnter = True
            Me.CheckBoxControl_IsInactive.Text = "Inactive"
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.AgencyImportPath = Nothing
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.DisplayName = ""
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(74, 0)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.PreventEnterBeep = True
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(350, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 3
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(68, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 0
            Me.LabelControl_Description.Text = "Description:"
            '
            'MediaPlanTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Panel)
            Me.Name = "MediaPlanTemplateControl"
            Me.Size = New System.Drawing.Size(424, 418)
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Panel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Public WithEvents DataGridViewControl_PlanEstimateTemplates As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Panel As WinForm.Presentation.Controls.Panel
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Description As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_IsInactive As CheckBox
    End Class

End Namespace
