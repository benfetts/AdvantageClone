Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ShareHPUTBookControl
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
            Me.DataGridViewControl_ShareHPUTBook = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.CheckBoxControl_UseLatest = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelControl_Panel = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.GroupBoxControl_Latest = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonLatest_L7 = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLatest_L3 = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLatest_L1 = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLatest_LS = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLatest_LV = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Panel.SuspendLayout()
            CType(Me.GroupBoxControl_Latest, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Latest.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewControl_ShareHPUTBook
            '
            Me.DataGridViewControl_ShareHPUTBook.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_ShareHPUTBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_ShareHPUTBook.AutoUpdateViewCaption = True
            Me.DataGridViewControl_ShareHPUTBook.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_ShareHPUTBook.ItemDescription = "Book(s)"
            Me.DataGridViewControl_ShareHPUTBook.Location = New System.Drawing.Point(0, 88)
            Me.DataGridViewControl_ShareHPUTBook.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_ShareHPUTBook.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_ShareHPUTBook.ModifyGridRowHeight = False
            Me.DataGridViewControl_ShareHPUTBook.MultiSelect = True
            Me.DataGridViewControl_ShareHPUTBook.Name = "DataGridViewControl_ShareHPUTBook"
            Me.DataGridViewControl_ShareHPUTBook.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_ShareHPUTBook.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_ShareHPUTBook.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_ShareHPUTBook.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_ShareHPUTBook.Size = New System.Drawing.Size(434, 330)
            Me.DataGridViewControl_ShareHPUTBook.TabIndex = 4
            Me.DataGridViewControl_ShareHPUTBook.UseEmbeddedNavigator = False
            Me.DataGridViewControl_ShareHPUTBook.ViewCaptionHeight = -1
            '
            'CheckBoxControl_UseLatest
            '
            Me.CheckBoxControl_UseLatest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_UseLatest.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxControl_UseLatest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_UseLatest.CheckValue = 0
            Me.CheckBoxControl_UseLatest.CheckValueChecked = 1
            Me.CheckBoxControl_UseLatest.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_UseLatest.CheckValueUnchecked = 0
            Me.CheckBoxControl_UseLatest.ChildControls = Nothing
            Me.CheckBoxControl_UseLatest.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_UseLatest.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxControl_UseLatest.Name = "CheckBoxControl_UseLatest"
            Me.CheckBoxControl_UseLatest.OldestSibling = Nothing
            Me.CheckBoxControl_UseLatest.SecurityEnabled = True
            Me.CheckBoxControl_UseLatest.SiblingControls = Nothing
            Me.CheckBoxControl_UseLatest.Size = New System.Drawing.Size(434, 20)
            Me.CheckBoxControl_UseLatest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_UseLatest.TabIndex = 2
            Me.CheckBoxControl_UseLatest.TabOnEnter = True
            Me.CheckBoxControl_UseLatest.Text = "Use Latest"
            '
            'PanelControl_Panel
            '
            Me.PanelControl_Panel.Controls.Add(Me.GroupBoxControl_Latest)
            Me.PanelControl_Panel.Controls.Add(Me.CheckBoxControl_UseLatest)
            Me.PanelControl_Panel.Controls.Add(Me.DataGridViewControl_ShareHPUTBook)
            Me.PanelControl_Panel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Panel.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Panel.Name = "PanelControl_Panel"
            Me.PanelControl_Panel.Size = New System.Drawing.Size(434, 418)
            Me.PanelControl_Panel.TabIndex = 5
            '
            'GroupBoxControl_Latest
            '
            Me.GroupBoxControl_Latest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxControl_Latest.Controls.Add(Me.RadioButtonLatest_L7)
            Me.GroupBoxControl_Latest.Controls.Add(Me.RadioButtonLatest_L3)
            Me.GroupBoxControl_Latest.Controls.Add(Me.RadioButtonLatest_L1)
            Me.GroupBoxControl_Latest.Controls.Add(Me.RadioButtonLatest_LS)
            Me.GroupBoxControl_Latest.Controls.Add(Me.RadioButtonLatest_LV)
            Me.GroupBoxControl_Latest.Location = New System.Drawing.Point(0, 26)
            Me.GroupBoxControl_Latest.Name = "GroupBoxControl_Latest"
            Me.GroupBoxControl_Latest.Size = New System.Drawing.Size(434, 55)
            Me.GroupBoxControl_Latest.TabIndex = 3
            Me.GroupBoxControl_Latest.Text = "Latest Stream"
            '
            'RadioButtonLatest_L7
            '
            Me.RadioButtonLatest_L7.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLatest_L7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLatest_L7.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLatest_L7.Location = New System.Drawing.Point(349, 24)
            Me.RadioButtonLatest_L7.Name = "RadioButtonLatest_L7"
            Me.RadioButtonLatest_L7.SecurityEnabled = True
            Me.RadioButtonLatest_L7.Size = New System.Drawing.Size(80, 20)
            Me.RadioButtonLatest_L7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLatest_L7.TabIndex = 4
            Me.RadioButtonLatest_L7.TabOnEnter = True
            Me.RadioButtonLatest_L7.TabStop = False
            Me.RadioButtonLatest_L7.Tag = "L7"
            Me.RadioButtonLatest_L7.Text = "L7"
            '
            'RadioButtonLatest_L3
            '
            Me.RadioButtonLatest_L3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLatest_L3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLatest_L3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLatest_L3.Location = New System.Drawing.Point(263, 24)
            Me.RadioButtonLatest_L3.Name = "RadioButtonLatest_L3"
            Me.RadioButtonLatest_L3.SecurityEnabled = True
            Me.RadioButtonLatest_L3.Size = New System.Drawing.Size(80, 20)
            Me.RadioButtonLatest_L3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLatest_L3.TabIndex = 3
            Me.RadioButtonLatest_L3.TabOnEnter = True
            Me.RadioButtonLatest_L3.TabStop = False
            Me.RadioButtonLatest_L3.Tag = "L3"
            Me.RadioButtonLatest_L3.Text = "L3"
            '
            'RadioButtonLatest_L1
            '
            Me.RadioButtonLatest_L1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLatest_L1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLatest_L1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLatest_L1.Location = New System.Drawing.Point(177, 24)
            Me.RadioButtonLatest_L1.Name = "RadioButtonLatest_L1"
            Me.RadioButtonLatest_L1.SecurityEnabled = True
            Me.RadioButtonLatest_L1.Size = New System.Drawing.Size(80, 20)
            Me.RadioButtonLatest_L1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLatest_L1.TabIndex = 2
            Me.RadioButtonLatest_L1.TabOnEnter = True
            Me.RadioButtonLatest_L1.TabStop = False
            Me.RadioButtonLatest_L1.Tag = "L1"
            Me.RadioButtonLatest_L1.Text = "L1"
            '
            'RadioButtonLatest_LS
            '
            Me.RadioButtonLatest_LS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLatest_LS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLatest_LS.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLatest_LS.Location = New System.Drawing.Point(91, 24)
            Me.RadioButtonLatest_LS.Name = "RadioButtonLatest_LS"
            Me.RadioButtonLatest_LS.SecurityEnabled = True
            Me.RadioButtonLatest_LS.Size = New System.Drawing.Size(80, 20)
            Me.RadioButtonLatest_LS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLatest_LS.TabIndex = 1
            Me.RadioButtonLatest_LS.TabOnEnter = True
            Me.RadioButtonLatest_LS.TabStop = False
            Me.RadioButtonLatest_LS.Tag = "LS"
            Me.RadioButtonLatest_LS.Text = "LS"
            '
            'RadioButtonLatest_LV
            '
            Me.RadioButtonLatest_LV.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLatest_LV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLatest_LV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLatest_LV.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonLatest_LV.Name = "RadioButtonLatest_LV"
            Me.RadioButtonLatest_LV.SecurityEnabled = True
            Me.RadioButtonLatest_LV.Size = New System.Drawing.Size(80, 20)
            Me.RadioButtonLatest_LV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLatest_LV.TabIndex = 0
            Me.RadioButtonLatest_LV.TabOnEnter = True
            Me.RadioButtonLatest_LV.TabStop = False
            Me.RadioButtonLatest_LV.Tag = "LO"
            Me.RadioButtonLatest_LV.Text = "L"
            '
            'ShareHPUTBookControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Panel)
            Me.Name = "ShareHPUTBookControl"
            Me.Size = New System.Drawing.Size(434, 418)
            CType(Me.PanelControl_Panel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Panel.ResumeLayout(False)
            CType(Me.GroupBoxControl_Latest, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Latest.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Public WithEvents DataGridViewControl_ShareHPUTBook As DataGridView
		Friend WithEvents CheckBoxControl_UseLatest As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelControl_Panel As WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxControl_Latest As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonLatest_L7 As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLatest_L3 As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLatest_L1 As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLatest_LS As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLatest_LV As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace
