Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountGroupControl
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
            Me.LabelControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlControl_FullAccountCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlControl_BaseAccountCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelControl_Use = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewControl_AccountGroupDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(88, 25)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 0
            Me.LabelControl_Code.Text = "Code:"
            '
            'TextBoxControl_Code
            '
            Me.TextBoxControl_Code.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(96, 0)
            Me.TextBoxControl_Code.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.ReadOnly = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(516, 22)
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(0, 32)
            Me.LabelControl_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(88, 25)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 2
            Me.LabelControl_Description.Text = "Description:"
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(96, 32)
            Me.TextBoxControl_Description.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(516, 22)
            Me.TextBoxControl_Description.TabIndex = 3
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'RadioButtonControlControl_FullAccountCode
            '
            Me.RadioButtonControlControl_FullAccountCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlControl_FullAccountCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlControl_FullAccountCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlControl_FullAccountCode.Checked = True
            Me.RadioButtonControlControl_FullAccountCode.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlControl_FullAccountCode.CheckValue = "Y"
            Me.RadioButtonControlControl_FullAccountCode.Location = New System.Drawing.Point(96, 64)
            Me.RadioButtonControlControl_FullAccountCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlControl_FullAccountCode.Name = "RadioButtonControlControl_FullAccountCode"
            Me.RadioButtonControlControl_FullAccountCode.SecurityEnabled = True
            Me.RadioButtonControlControl_FullAccountCode.Size = New System.Drawing.Size(161, 25)
            Me.RadioButtonControlControl_FullAccountCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlControl_FullAccountCode.TabIndex = 5
            Me.RadioButtonControlControl_FullAccountCode.Text = "Full Account Code"
            '
            'RadioButtonControlControl_BaseAccountCode
            '
            Me.RadioButtonControlControl_BaseAccountCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlControl_BaseAccountCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlControl_BaseAccountCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlControl_BaseAccountCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlControl_BaseAccountCode.Location = New System.Drawing.Point(265, 64)
            Me.RadioButtonControlControl_BaseAccountCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.RadioButtonControlControl_BaseAccountCode.Name = "RadioButtonControlControl_BaseAccountCode"
            Me.RadioButtonControlControl_BaseAccountCode.SecurityEnabled = True
            Me.RadioButtonControlControl_BaseAccountCode.Size = New System.Drawing.Size(347, 25)
            Me.RadioButtonControlControl_BaseAccountCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlControl_BaseAccountCode.TabIndex = 6
            Me.RadioButtonControlControl_BaseAccountCode.TabStop = False
            Me.RadioButtonControlControl_BaseAccountCode.Text = "Base Account Code"
            '
            'LabelControl_Use
            '
            Me.LabelControl_Use.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Use.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Use.Location = New System.Drawing.Point(0, 64)
            Me.LabelControl_Use.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.LabelControl_Use.Name = "LabelControl_Use"
            Me.LabelControl_Use.Size = New System.Drawing.Size(88, 25)
            Me.LabelControl_Use.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Use.TabIndex = 4
            Me.LabelControl_Use.Text = "Use:"
            '
            'DataGridViewControl_AccountGroupDetails
            '
            Me.DataGridViewControl_AccountGroupDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_AccountGroupDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_AccountGroupDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_AccountGroupDetails.AutoFilterLookupColumns = False
            Me.DataGridViewControl_AccountGroupDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_AccountGroupDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_AccountGroupDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_AccountGroupDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_AccountGroupDetails.ItemDescription = "Item(s)"
            Me.DataGridViewControl_AccountGroupDetails.Location = New System.Drawing.Point(0, 96)
            Me.DataGridViewControl_AccountGroupDetails.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.DataGridViewControl_AccountGroupDetails.MultiSelect = True
            Me.DataGridViewControl_AccountGroupDetails.Name = "DataGridViewControl_AccountGroupDetails"
            Me.DataGridViewControl_AccountGroupDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_AccountGroupDetails.RunStandardValidation = True
            Me.DataGridViewControl_AccountGroupDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_AccountGroupDetails.Size = New System.Drawing.Size(612, 334)
            Me.DataGridViewControl_AccountGroupDetails.TabIndex = 7
            Me.DataGridViewControl_AccountGroupDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_AccountGroupDetails.ViewCaptionHeight = -1
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_AccountGroupDetails)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Use)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.RadioButtonControlControl_BaseAccountCode)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.RadioButtonControlControl_FullAccountCode)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Description)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(612, 430)
            Me.PanelControl_Control.TabIndex = 45
            '
            'AccountGroupControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.Name = "AccountGroupControl"
            Me.Size = New System.Drawing.Size(612, 430)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Use As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlControl_FullAccountCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlControl_BaseAccountCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewControl_AccountGroupDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel

    End Class

End Namespace
