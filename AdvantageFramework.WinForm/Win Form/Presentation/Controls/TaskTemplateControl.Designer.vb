Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class TaskTemplateControl
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
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_TaskTemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxForm_ScheduleCompletionDays = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxScheduleCompletionDays_Rush = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelScheduleCompletionDays_Rush = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxScheduleCompletionDays_Standard = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelScheduleCompletionDays_Standard = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.GroupBoxForm_ScheduleCompletionDays, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_ScheduleCompletionDays.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(268, 0)
            Me.TextBoxForm_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(536, 22)
            Me.TextBoxForm_Description.TabIndex = 3
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'TextBoxForm_Code
            '
            '
            '
            '
            Me.TextBoxForm_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Code.CheckSpellingOnValidate = False
            Me.TextBoxForm_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Code.FocusHighlightEnabled = True
            Me.TextBoxForm_Code.Location = New System.Drawing.Point(57, 0)
            Me.TextBoxForm_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxForm_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Code.Name = "TextBoxForm_Code"
            Me.TextBoxForm_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Code.Size = New System.Drawing.Size(108, 22)
            Me.TextBoxForm_Code.TabIndex = 1
            Me.TextBoxForm_Code.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(173, 0)
            Me.LabelForm_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(87, 25)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 2
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_Code
            '
            Me.LabelForm_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelForm_Code.Name = "LabelForm_Code"
            Me.LabelForm_Code.Size = New System.Drawing.Size(49, 25)
            Me.LabelForm_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Code.TabIndex = 0
            Me.LabelForm_Code.Text = "Code:"
            '
            'DataGridViewForm_TaskTemplateDetails
            '
            Me.DataGridViewForm_TaskTemplateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_TaskTemplateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_TaskTemplateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_TaskTemplateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewForm_TaskTemplateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_TaskTemplateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_TaskTemplateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_TaskTemplateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_TaskTemplateDetails.ItemDescription = ""
            Me.DataGridViewForm_TaskTemplateDetails.Location = New System.Drawing.Point(0, 101)
            Me.DataGridViewForm_TaskTemplateDetails.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.DataGridViewForm_TaskTemplateDetails.MultiSelect = True
            Me.DataGridViewForm_TaskTemplateDetails.Name = "DataGridViewForm_TaskTemplateDetails"
            Me.DataGridViewForm_TaskTemplateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_TaskTemplateDetails.RunStandardValidation = True
            Me.DataGridViewForm_TaskTemplateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_TaskTemplateDetails.Size = New System.Drawing.Size(804, 319)
            Me.DataGridViewForm_TaskTemplateDetails.TabIndex = 4
            Me.DataGridViewForm_TaskTemplateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_TaskTemplateDetails.ViewCaptionHeight = -1
            '
            'GroupBoxForm_ScheduleCompletionDays
            '
            Me.GroupBoxForm_ScheduleCompletionDays.Controls.Add(Me.TextBoxScheduleCompletionDays_Rush)
            Me.GroupBoxForm_ScheduleCompletionDays.Controls.Add(Me.LabelScheduleCompletionDays_Rush)
            Me.GroupBoxForm_ScheduleCompletionDays.Controls.Add(Me.TextBoxScheduleCompletionDays_Standard)
            Me.GroupBoxForm_ScheduleCompletionDays.Controls.Add(Me.LabelScheduleCompletionDays_Standard)
            Me.GroupBoxForm_ScheduleCompletionDays.Location = New System.Drawing.Point(0, 32)
            Me.GroupBoxForm_ScheduleCompletionDays.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.GroupBoxForm_ScheduleCompletionDays.Name = "GroupBoxForm_ScheduleCompletionDays"
            Me.GroupBoxForm_ScheduleCompletionDays.Size = New System.Drawing.Size(389, 62)
            Me.GroupBoxForm_ScheduleCompletionDays.TabIndex = 5
            Me.GroupBoxForm_ScheduleCompletionDays.Text = "Schedule Completion Days"
            '
            'TextBoxScheduleCompletionDays_Rush
            '
            '
            '
            '
            Me.TextBoxScheduleCompletionDays_Rush.Border.Class = "TextBoxBorder"
            Me.TextBoxScheduleCompletionDays_Rush.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxScheduleCompletionDays_Rush.CheckSpellingOnValidate = False
            Me.TextBoxScheduleCompletionDays_Rush.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxScheduleCompletionDays_Rush.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxScheduleCompletionDays_Rush.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxScheduleCompletionDays_Rush.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxScheduleCompletionDays_Rush.FocusHighlightEnabled = True
            Me.TextBoxScheduleCompletionDays_Rush.Location = New System.Drawing.Point(265, 30)
            Me.TextBoxScheduleCompletionDays_Rush.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxScheduleCompletionDays_Rush.MaxFileSize = CType(0, Long)
            Me.TextBoxScheduleCompletionDays_Rush.Name = "TextBoxScheduleCompletionDays_Rush"
            Me.TextBoxScheduleCompletionDays_Rush.ReadOnly = True
            Me.TextBoxScheduleCompletionDays_Rush.ShowSpellCheckCompleteMessage = True
            Me.TextBoxScheduleCompletionDays_Rush.Size = New System.Drawing.Size(117, 22)
            Me.TextBoxScheduleCompletionDays_Rush.TabIndex = 6
            Me.TextBoxScheduleCompletionDays_Rush.TabOnEnter = True
            '
            'LabelScheduleCompletionDays_Rush
            '
            Me.LabelScheduleCompletionDays_Rush.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelScheduleCompletionDays_Rush.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelScheduleCompletionDays_Rush.Location = New System.Drawing.Point(211, 30)
            Me.LabelScheduleCompletionDays_Rush.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelScheduleCompletionDays_Rush.Name = "LabelScheduleCompletionDays_Rush"
            Me.LabelScheduleCompletionDays_Rush.Size = New System.Drawing.Size(47, 25)
            Me.LabelScheduleCompletionDays_Rush.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelScheduleCompletionDays_Rush.TabIndex = 5
            Me.LabelScheduleCompletionDays_Rush.Text = "Rush:"
            '
            'TextBoxScheduleCompletionDays_Standard
            '
            '
            '
            '
            Me.TextBoxScheduleCompletionDays_Standard.Border.Class = "TextBoxBorder"
            Me.TextBoxScheduleCompletionDays_Standard.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxScheduleCompletionDays_Standard.CheckSpellingOnValidate = False
            Me.TextBoxScheduleCompletionDays_Standard.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxScheduleCompletionDays_Standard.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxScheduleCompletionDays_Standard.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxScheduleCompletionDays_Standard.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxScheduleCompletionDays_Standard.FocusHighlightEnabled = True
            Me.TextBoxScheduleCompletionDays_Standard.Location = New System.Drawing.Point(85, 30)
            Me.TextBoxScheduleCompletionDays_Standard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxScheduleCompletionDays_Standard.MaxFileSize = CType(0, Long)
            Me.TextBoxScheduleCompletionDays_Standard.Name = "TextBoxScheduleCompletionDays_Standard"
            Me.TextBoxScheduleCompletionDays_Standard.ReadOnly = True
            Me.TextBoxScheduleCompletionDays_Standard.ShowSpellCheckCompleteMessage = True
            Me.TextBoxScheduleCompletionDays_Standard.Size = New System.Drawing.Size(117, 22)
            Me.TextBoxScheduleCompletionDays_Standard.TabIndex = 4
            Me.TextBoxScheduleCompletionDays_Standard.TabOnEnter = True
            '
            'LabelScheduleCompletionDays_Standard
            '
            Me.LabelScheduleCompletionDays_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelScheduleCompletionDays_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelScheduleCompletionDays_Standard.Location = New System.Drawing.Point(7, 30)
            Me.LabelScheduleCompletionDays_Standard.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelScheduleCompletionDays_Standard.Name = "LabelScheduleCompletionDays_Standard"
            Me.LabelScheduleCompletionDays_Standard.Size = New System.Drawing.Size(71, 25)
            Me.LabelScheduleCompletionDays_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelScheduleCompletionDays_Standard.TabIndex = 3
            Me.LabelScheduleCompletionDays_Standard.Text = "Standard:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxForm_ScheduleCompletionDays)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Description)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewForm_TaskTemplateDetails)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxForm_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Description)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(804, 420)
            Me.PanelControl_Control.TabIndex = 45
            '
            'TaskTemplateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "TaskTemplateControl"
            Me.Size = New System.Drawing.Size(804, 420)
            CType(Me.GroupBoxForm_ScheduleCompletionDays, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_ScheduleCompletionDays.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_TaskTemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxForm_ScheduleCompletionDays As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxScheduleCompletionDays_Rush As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelScheduleCompletionDays_Rush As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxScheduleCompletionDays_Standard As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelScheduleCompletionDays_Standard As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
