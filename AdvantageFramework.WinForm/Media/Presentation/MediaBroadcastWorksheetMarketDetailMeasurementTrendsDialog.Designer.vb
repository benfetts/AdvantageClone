Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog
		Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog))
            Me.DataGridViewForm_Trends = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_Vendor = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_VendorName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DaysTimeData = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DaysTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_Breakouts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RadioButtonForm_Hours = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_QuarterHours = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_TimeSpan = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxForm_ShowLeadInOut = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelForm_DemoLabel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Demo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Copyright = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonForm_ExportTrends = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_ExportBreakouts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_ShowBreakout = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_ProgramData = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Program = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_SourceData = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Trends
            '
            Me.DataGridViewForm_Trends.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Trends.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Trends.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Trends.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Trends.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Trends.Location = New System.Drawing.Point(12, 90)
            Me.DataGridViewForm_Trends.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Trends.ModifyGridRowHeight = False
            Me.DataGridViewForm_Trends.MultiSelect = False
            Me.DataGridViewForm_Trends.Name = "DataGridViewForm_Trends"
            Me.DataGridViewForm_Trends.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Trends.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Trends.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Trends.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Trends.Size = New System.Drawing.Size(685, 253)
            Me.DataGridViewForm_Trends.TabIndex = 11
            Me.DataGridViewForm_Trends.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Trends.ViewCaptionHeight = -1
            '
            'LabelForm_Vendor
            '
            Me.LabelForm_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Vendor.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Vendor.Name = "LabelForm_Vendor"
            Me.LabelForm_Vendor.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Vendor.TabIndex = 0
            Me.LabelForm_Vendor.Text = "Vendor:"
            '
            'LabelForm_VendorName
            '
            Me.LabelForm_VendorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_VendorName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_VendorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_VendorName.Location = New System.Drawing.Point(86, 12)
            Me.LabelForm_VendorName.Name = "LabelForm_VendorName"
            Me.LabelForm_VendorName.Size = New System.Drawing.Size(611, 20)
            Me.LabelForm_VendorName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_VendorName.TabIndex = 1
            '
            'LabelForm_DaysTimeData
            '
            Me.LabelForm_DaysTimeData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaysTimeData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaysTimeData.Location = New System.Drawing.Point(86, 38)
            Me.LabelForm_DaysTimeData.Name = "LabelForm_DaysTimeData"
            Me.LabelForm_DaysTimeData.Size = New System.Drawing.Size(269, 20)
            Me.LabelForm_DaysTimeData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaysTimeData.TabIndex = 3
            '
            'LabelForm_DaysTime
            '
            Me.LabelForm_DaysTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaysTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaysTime.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_DaysTime.Name = "LabelForm_DaysTime"
            Me.LabelForm_DaysTime.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_DaysTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaysTime.TabIndex = 2
            Me.LabelForm_DaysTime.Text = "Days/Time:"
            '
            'DataGridViewForm_Breakouts
            '
            Me.DataGridViewForm_Breakouts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Breakouts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Breakouts.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Breakouts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Breakouts.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Breakouts.Location = New System.Drawing.Point(12, 375)
            Me.DataGridViewForm_Breakouts.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Breakouts.ModifyGridRowHeight = False
            Me.DataGridViewForm_Breakouts.MultiSelect = False
            Me.DataGridViewForm_Breakouts.Name = "DataGridViewForm_Breakouts"
            Me.DataGridViewForm_Breakouts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Breakouts.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Breakouts.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Breakouts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Breakouts.Size = New System.Drawing.Size(685, 253)
            Me.DataGridViewForm_Breakouts.TabIndex = 18
            Me.DataGridViewForm_Breakouts.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Breakouts.ViewCaptionHeight = -1
            '
            'RadioButtonForm_Hours
            '
            Me.RadioButtonForm_Hours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Hours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Hours.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Hours.Location = New System.Drawing.Point(361, 349)
            Me.RadioButtonForm_Hours.Name = "RadioButtonForm_Hours"
            Me.RadioButtonForm_Hours.SecurityEnabled = True
            Me.RadioButtonForm_Hours.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonForm_Hours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Hours.TabIndex = 15
            Me.RadioButtonForm_Hours.TabOnEnter = True
            Me.RadioButtonForm_Hours.TabStop = False
            Me.RadioButtonForm_Hours.Text = "Hours"
            '
            'RadioButtonForm_QuarterHours
            '
            Me.RadioButtonForm_QuarterHours.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonForm_QuarterHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_QuarterHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_QuarterHours.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_QuarterHours.Checked = True
            Me.RadioButtonForm_QuarterHours.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_QuarterHours.CheckValue = "Y"
            Me.RadioButtonForm_QuarterHours.Location = New System.Drawing.Point(467, 349)
            Me.RadioButtonForm_QuarterHours.Name = "RadioButtonForm_QuarterHours"
            Me.RadioButtonForm_QuarterHours.SecurityEnabled = True
            Me.RadioButtonForm_QuarterHours.Size = New System.Drawing.Size(149, 20)
            Me.RadioButtonForm_QuarterHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_QuarterHours.TabIndex = 16
            Me.RadioButtonForm_QuarterHours.TabOnEnter = True
            Me.RadioButtonForm_QuarterHours.Text = "Quarter-Hours"
            '
            'LabelForm_TimeSpan
            '
            Me.LabelForm_TimeSpan.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TimeSpan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TimeSpan.Location = New System.Drawing.Point(280, 349)
            Me.LabelForm_TimeSpan.Name = "LabelForm_TimeSpan"
            Me.LabelForm_TimeSpan.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_TimeSpan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TimeSpan.TabIndex = 14
            Me.LabelForm_TimeSpan.Text = "Time Span:"
            '
            'CheckBoxForm_ShowLeadInOut
            '
            Me.CheckBoxForm_ShowLeadInOut.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ShowLeadInOut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowLeadInOut.CheckValue = 0
            Me.CheckBoxForm_ShowLeadInOut.CheckValueChecked = 1
            Me.CheckBoxForm_ShowLeadInOut.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ShowLeadInOut.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowLeadInOut.ChildControls = Nothing
            Me.CheckBoxForm_ShowLeadInOut.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowLeadInOut.Location = New System.Drawing.Point(124, 349)
            Me.CheckBoxForm_ShowLeadInOut.Name = "CheckBoxForm_ShowLeadInOut"
            Me.CheckBoxForm_ShowLeadInOut.OldestSibling = Nothing
            Me.CheckBoxForm_ShowLeadInOut.SecurityEnabled = True
            Me.CheckBoxForm_ShowLeadInOut.SiblingControls = Nothing
            Me.CheckBoxForm_ShowLeadInOut.Size = New System.Drawing.Size(150, 20)
            Me.CheckBoxForm_ShowLeadInOut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowLeadInOut.TabIndex = 13
            Me.CheckBoxForm_ShowLeadInOut.TabOnEnter = True
            Me.CheckBoxForm_ShowLeadInOut.Text = "Show Lead In/Out"
            '
            'LabelForm_DemoLabel
            '
            Me.LabelForm_DemoLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DemoLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DemoLabel.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_DemoLabel.Name = "LabelForm_DemoLabel"
            Me.LabelForm_DemoLabel.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_DemoLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DemoLabel.TabIndex = 6
            Me.LabelForm_DemoLabel.Text = "Demo:"
            '
            'LabelForm_Demo
            '
            Me.LabelForm_Demo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Demo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Demo.Location = New System.Drawing.Point(86, 64)
            Me.LabelForm_Demo.Name = "LabelForm_Demo"
            Me.LabelForm_Demo.Size = New System.Drawing.Size(269, 20)
            Me.LabelForm_Demo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Demo.TabIndex = 7
            '
            'LabelForm_Copyright
            '
            Me.LabelForm_Copyright.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Copyright.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Copyright.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Copyright.ForeColor = System.Drawing.Color.Red
            Me.LabelForm_Copyright.Location = New System.Drawing.Point(12, 634)
            Me.LabelForm_Copyright.Name = "LabelForm_Copyright"
            Me.LabelForm_Copyright.Size = New System.Drawing.Size(685, 20)
            Me.LabelForm_Copyright.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Copyright.TabIndex = 19
            '
            'ButtonForm_ExportTrends
            '
            Me.ButtonForm_ExportTrends.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ExportTrends.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ExportTrends.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ExportTrends.Location = New System.Drawing.Point(622, 64)
            Me.ButtonForm_ExportTrends.Name = "ButtonForm_ExportTrends"
            Me.ButtonForm_ExportTrends.SecurityEnabled = True
            Me.ButtonForm_ExportTrends.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_ExportTrends.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ExportTrends.TabIndex = 10
            Me.ButtonForm_ExportTrends.Text = "Export"
            '
            'ButtonForm_ExportBreakouts
            '
            Me.ButtonForm_ExportBreakouts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ExportBreakouts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ExportBreakouts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ExportBreakouts.Location = New System.Drawing.Point(622, 349)
            Me.ButtonForm_ExportBreakouts.Name = "ButtonForm_ExportBreakouts"
            Me.ButtonForm_ExportBreakouts.SecurityEnabled = True
            Me.ButtonForm_ExportBreakouts.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_ExportBreakouts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ExportBreakouts.TabIndex = 17
            Me.ButtonForm_ExportBreakouts.Text = "Export"
            '
            'ButtonForm_ShowBreakout
            '
            Me.ButtonForm_ShowBreakout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ShowBreakout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ShowBreakout.Location = New System.Drawing.Point(12, 349)
            Me.ButtonForm_ShowBreakout.Name = "ButtonForm_ShowBreakout"
            Me.ButtonForm_ShowBreakout.SecurityEnabled = True
            Me.ButtonForm_ShowBreakout.Size = New System.Drawing.Size(106, 20)
            Me.ButtonForm_ShowBreakout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ShowBreakout.TabIndex = 12
            Me.ButtonForm_ShowBreakout.Text = "Show Breakout"
            '
            'LabelForm_ProgramData
            '
            Me.LabelForm_ProgramData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProgramData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProgramData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProgramData.Location = New System.Drawing.Point(435, 38)
            Me.LabelForm_ProgramData.Name = "LabelForm_ProgramData"
            Me.LabelForm_ProgramData.Size = New System.Drawing.Size(262, 20)
            Me.LabelForm_ProgramData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProgramData.TabIndex = 5
            '
            'LabelForm_Program
            '
            Me.LabelForm_Program.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Program.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Program.Location = New System.Drawing.Point(361, 38)
            Me.LabelForm_Program.Name = "LabelForm_Program"
            Me.LabelForm_Program.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Program.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Program.TabIndex = 4
            Me.LabelForm_Program.Text = "Program:"
            '
            'LabelForm_SourceData
            '
            Me.LabelForm_SourceData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SourceData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SourceData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SourceData.Location = New System.Drawing.Point(435, 64)
            Me.LabelForm_SourceData.Name = "LabelForm_SourceData"
            Me.LabelForm_SourceData.Size = New System.Drawing.Size(181, 20)
            Me.LabelForm_SourceData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SourceData.TabIndex = 9
            '
            'LabelForm_Source
            '
            Me.LabelForm_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Source.Location = New System.Drawing.Point(361, 64)
            Me.LabelForm_Source.Name = "LabelForm_Source"
            Me.LabelForm_Source.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Source.TabIndex = 8
            Me.LabelForm_Source.Text = "Source:"
            '
            'MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 666)
            Me.Controls.Add(Me.LabelForm_SourceData)
            Me.Controls.Add(Me.LabelForm_Source)
            Me.Controls.Add(Me.LabelForm_ProgramData)
            Me.Controls.Add(Me.LabelForm_Program)
            Me.Controls.Add(Me.ButtonForm_ShowBreakout)
            Me.Controls.Add(Me.ButtonForm_ExportBreakouts)
            Me.Controls.Add(Me.ButtonForm_ExportTrends)
            Me.Controls.Add(Me.LabelForm_Copyright)
            Me.Controls.Add(Me.LabelForm_Demo)
            Me.Controls.Add(Me.LabelForm_DemoLabel)
            Me.Controls.Add(Me.CheckBoxForm_ShowLeadInOut)
            Me.Controls.Add(Me.LabelForm_TimeSpan)
            Me.Controls.Add(Me.RadioButtonForm_Hours)
            Me.Controls.Add(Me.RadioButtonForm_QuarterHours)
            Me.Controls.Add(Me.DataGridViewForm_Breakouts)
            Me.Controls.Add(Me.LabelForm_DaysTimeData)
            Me.Controls.Add(Me.LabelForm_DaysTime)
            Me.Controls.Add(Me.LabelForm_VendorName)
            Me.Controls.Add(Me.LabelForm_Vendor)
            Me.Controls.Add(Me.DataGridViewForm_Trends)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog"
            Me.ShowInTaskbar = False
            Me.TitleText = "<font color=""#FFFFFF"">Market Measurement Trends</font>"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Trends As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Vendor As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_VendorName As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_DaysTimeData As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_DaysTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Breakouts As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonForm_Hours As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_QuarterHours As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_TimeSpan As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_ShowLeadInOut As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_DemoLabel As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Demo As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Copyright As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonForm_ExportTrends As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_ExportBreakouts As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_ShowBreakout As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents LabelForm_ProgramData As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Program As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_SourceData As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Source As WinForm.MVC.Presentation.Controls.Label
    End Class

End Namespace