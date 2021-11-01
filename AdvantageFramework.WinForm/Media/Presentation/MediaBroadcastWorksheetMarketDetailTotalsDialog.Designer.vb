Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketDetailTotalsDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailTotalsDialog))
            Me.DataGridViewForm_Totals = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_ClientName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_WorksheetName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Worksheet = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_MarketName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Market = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DemoName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Demo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_FilterString = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Filter = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonForm_Export = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.RadioButtonForm_MarketSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.RadioButtonForm_DaypartSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_StationSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_LengthSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_DaypartLengthSummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_MarketMonthlySummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_StationMonthlySummary = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Totals
            '
            Me.DataGridViewForm_Totals.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Totals.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Totals.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Totals.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Totals.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Totals.Location = New System.Drawing.Point(12, 220)
            Me.DataGridViewForm_Totals.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Totals.ModifyGridRowHeight = False
            Me.DataGridViewForm_Totals.MultiSelect = False
            Me.DataGridViewForm_Totals.Name = "DataGridViewForm_Totals"
            Me.DataGridViewForm_Totals.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Totals.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Totals.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Totals.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Totals.Size = New System.Drawing.Size(636, 354)
            Me.DataGridViewForm_Totals.TabIndex = 18
            Me.DataGridViewForm_Totals.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Totals.ViewCaptionHeight = -1
            '
            'LabelForm_ClientName
            '
            Me.LabelForm_ClientName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ClientName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientName.Location = New System.Drawing.Point(86, 12)
            Me.LabelForm_ClientName.Name = "LabelForm_ClientName"
            Me.LabelForm_ClientName.Size = New System.Drawing.Size(562, 20)
            Me.LabelForm_ClientName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientName.TabIndex = 1
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 0
            Me.LabelForm_Client.Text = "Client:"
            '
            'LabelForm_WorksheetName
            '
            Me.LabelForm_WorksheetName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_WorksheetName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_WorksheetName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_WorksheetName.Location = New System.Drawing.Point(86, 38)
            Me.LabelForm_WorksheetName.Name = "LabelForm_WorksheetName"
            Me.LabelForm_WorksheetName.Size = New System.Drawing.Size(562, 20)
            Me.LabelForm_WorksheetName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_WorksheetName.TabIndex = 3
            Me.LabelForm_WorksheetName.UseMnemonic = False
            '
            'LabelForm_Worksheet
            '
            Me.LabelForm_Worksheet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Worksheet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Worksheet.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Worksheet.Name = "LabelForm_Worksheet"
            Me.LabelForm_Worksheet.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Worksheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Worksheet.TabIndex = 2
            Me.LabelForm_Worksheet.Text = "Worksheet:"
            '
            'LabelForm_MarketName
            '
            Me.LabelForm_MarketName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MarketName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MarketName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MarketName.Location = New System.Drawing.Point(86, 64)
            Me.LabelForm_MarketName.Name = "LabelForm_MarketName"
            Me.LabelForm_MarketName.Size = New System.Drawing.Size(562, 20)
            Me.LabelForm_MarketName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MarketName.TabIndex = 5
            '
            'LabelForm_Market
            '
            Me.LabelForm_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Market.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Market.Name = "LabelForm_Market"
            Me.LabelForm_Market.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Market.TabIndex = 4
            Me.LabelForm_Market.Text = "Market:"
            '
            'LabelForm_DemoName
            '
            Me.LabelForm_DemoName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DemoName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DemoName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DemoName.Location = New System.Drawing.Point(86, 90)
            Me.LabelForm_DemoName.Name = "LabelForm_DemoName"
            Me.LabelForm_DemoName.Size = New System.Drawing.Size(562, 20)
            Me.LabelForm_DemoName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DemoName.TabIndex = 7
            '
            'LabelForm_Demo
            '
            Me.LabelForm_Demo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Demo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Demo.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Demo.Name = "LabelForm_Demo"
            Me.LabelForm_Demo.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Demo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Demo.TabIndex = 6
            Me.LabelForm_Demo.Text = "Demo:"
            '
            'LabelForm_FilterString
            '
            Me.LabelForm_FilterString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_FilterString.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FilterString.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FilterString.Location = New System.Drawing.Point(86, 116)
            Me.LabelForm_FilterString.Name = "LabelForm_FilterString"
            Me.LabelForm_FilterString.Size = New System.Drawing.Size(562, 20)
            Me.LabelForm_FilterString.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FilterString.TabIndex = 9
            '
            'LabelForm_Filter
            '
            Me.LabelForm_Filter.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Filter.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_Filter.Name = "LabelForm_Filter"
            Me.LabelForm_Filter.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Filter.TabIndex = 8
            Me.LabelForm_Filter.Text = "Filter:"
            '
            'ButtonForm_Export
            '
            Me.ButtonForm_Export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Export.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Export.Location = New System.Drawing.Point(573, 194)
            Me.ButtonForm_Export.Name = "ButtonForm_Export"
            Me.ButtonForm_Export.SecurityEnabled = True
            Me.ButtonForm_Export.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Export.TabIndex = 17
            Me.ButtonForm_Export.Text = "Export"
            '
            'RadioButtonForm_MarketSummary
            '
            Me.RadioButtonForm_MarketSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_MarketSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_MarketSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_MarketSummary.Checked = True
            Me.RadioButtonForm_MarketSummary.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_MarketSummary.CheckValue = "Y"
            Me.RadioButtonForm_MarketSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_MarketSummary.Location = New System.Drawing.Point(12, 142)
            Me.RadioButtonForm_MarketSummary.Name = "RadioButtonForm_MarketSummary"
            Me.RadioButtonForm_MarketSummary.SecurityEnabled = True
            Me.RadioButtonForm_MarketSummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_MarketSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_MarketSummary.TabIndex = 10
            Me.RadioButtonForm_MarketSummary.TabOnEnter = True
            Me.RadioButtonForm_MarketSummary.Text = "Market {0} Summary"
            '
            'ToolTipController
            '
            '
            'RadioButtonForm_DaypartSummary
            '
            Me.RadioButtonForm_DaypartSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DaypartSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DaypartSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DaypartSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_DaypartSummary.Location = New System.Drawing.Point(480, 168)
            Me.RadioButtonForm_DaypartSummary.Name = "RadioButtonForm_DaypartSummary"
            Me.RadioButtonForm_DaypartSummary.SecurityEnabled = True
            Me.RadioButtonForm_DaypartSummary.Size = New System.Drawing.Size(168, 20)
            Me.RadioButtonForm_DaypartSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DaypartSummary.TabIndex = 11
            Me.RadioButtonForm_DaypartSummary.TabOnEnter = True
            Me.RadioButtonForm_DaypartSummary.TabStop = False
            Me.RadioButtonForm_DaypartSummary.Text = "Daypart Summary"
            '
            'RadioButtonForm_DaypartWeeklyDailySpendSummary
            '
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.Location = New System.Drawing.Point(324, 142)
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.Name = "RadioButtonForm_DaypartWeeklyDailySpendSummary"
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.SecurityEnabled = True
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.TabIndex = 12
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.TabOnEnter = True
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.TabStop = False
            Me.RadioButtonForm_DaypartWeeklyDailySpendSummary.Text = "Daypart {0} $"
            '
            'RadioButtonForm_DaypartWeeklyDailyGRPSummary
            '
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.Location = New System.Drawing.Point(480, 142)
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.Name = "RadioButtonForm_DaypartWeeklyDailyGRPSummary"
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.SecurityEnabled = True
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.Size = New System.Drawing.Size(168, 20)
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.TabIndex = 13
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.TabOnEnter = True
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.TabStop = False
            Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary.Text = "Daypart {0} GRP"
            '
            'RadioButtonForm_StationSummary
            '
            Me.RadioButtonForm_StationSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_StationSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_StationSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_StationSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_StationSummary.Location = New System.Drawing.Point(12, 168)
            Me.RadioButtonForm_StationSummary.Name = "RadioButtonForm_StationSummary"
            Me.RadioButtonForm_StationSummary.SecurityEnabled = True
            Me.RadioButtonForm_StationSummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_StationSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_StationSummary.TabIndex = 14
            Me.RadioButtonForm_StationSummary.TabOnEnter = True
            Me.RadioButtonForm_StationSummary.TabStop = False
            Me.RadioButtonForm_StationSummary.Text = "Station Summary"
            '
            'RadioButtonForm_LengthSummary
            '
            Me.RadioButtonForm_LengthSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_LengthSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_LengthSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_LengthSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_LengthSummary.Location = New System.Drawing.Point(12, 194)
            Me.RadioButtonForm_LengthSummary.Name = "RadioButtonForm_LengthSummary"
            Me.RadioButtonForm_LengthSummary.SecurityEnabled = True
            Me.RadioButtonForm_LengthSummary.Size = New System.Drawing.Size(462, 20)
            Me.RadioButtonForm_LengthSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_LengthSummary.TabIndex = 15
            Me.RadioButtonForm_LengthSummary.TabOnEnter = True
            Me.RadioButtonForm_LengthSummary.TabStop = False
            Me.RadioButtonForm_LengthSummary.Text = "Length Summary"
            '
            'RadioButtonForm_DaypartLengthSummary
            '
            Me.RadioButtonForm_DaypartLengthSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_DaypartLengthSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_DaypartLengthSummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_DaypartLengthSummary.FocusCuesEnabled = False
            Me.RadioButtonForm_DaypartLengthSummary.Location = New System.Drawing.Point(324, 168)
            Me.RadioButtonForm_DaypartLengthSummary.Name = "RadioButtonForm_DaypartLengthSummary"
            Me.RadioButtonForm_DaypartLengthSummary.SecurityEnabled = True
            Me.RadioButtonForm_DaypartLengthSummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_DaypartLengthSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_DaypartLengthSummary.TabIndex = 16
            Me.RadioButtonForm_DaypartLengthSummary.TabOnEnter = True
            Me.RadioButtonForm_DaypartLengthSummary.TabStop = False
            Me.RadioButtonForm_DaypartLengthSummary.Text = "Daypart/Length Summary"
            '
            'RadioButtonForm_MarketMonthlySummary
            '
            Me.RadioButtonForm_MarketMonthlySummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_MarketMonthlySummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_MarketMonthlySummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_MarketMonthlySummary.FocusCuesEnabled = False
            Me.RadioButtonForm_MarketMonthlySummary.Location = New System.Drawing.Point(168, 142)
            Me.RadioButtonForm_MarketMonthlySummary.Name = "RadioButtonForm_MarketMonthlySummary"
            Me.RadioButtonForm_MarketMonthlySummary.SecurityEnabled = True
            Me.RadioButtonForm_MarketMonthlySummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_MarketMonthlySummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_MarketMonthlySummary.TabIndex = 19
            Me.RadioButtonForm_MarketMonthlySummary.TabOnEnter = True
            Me.RadioButtonForm_MarketMonthlySummary.TabStop = False
            Me.RadioButtonForm_MarketMonthlySummary.Text = "Market Monthly Summary"
            '
            'RadioButtonForm_StationMonthlySummary
            '
            Me.RadioButtonForm_StationMonthlySummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_StationMonthlySummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_StationMonthlySummary.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_StationMonthlySummary.FocusCuesEnabled = False
            Me.RadioButtonForm_StationMonthlySummary.Location = New System.Drawing.Point(168, 168)
            Me.RadioButtonForm_StationMonthlySummary.Name = "RadioButtonForm_StationMonthlySummary"
            Me.RadioButtonForm_StationMonthlySummary.SecurityEnabled = True
            Me.RadioButtonForm_StationMonthlySummary.Size = New System.Drawing.Size(150, 20)
            Me.RadioButtonForm_StationMonthlySummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_StationMonthlySummary.TabIndex = 20
            Me.RadioButtonForm_StationMonthlySummary.TabOnEnter = True
            Me.RadioButtonForm_StationMonthlySummary.TabStop = False
            Me.RadioButtonForm_StationMonthlySummary.Text = "Station Monthly Summary"
            '
            'MediaBroadcastWorksheetMarketDetailTotalsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(660, 586)
            Me.Controls.Add(Me.RadioButtonForm_StationMonthlySummary)
            Me.Controls.Add(Me.RadioButtonForm_MarketMonthlySummary)
            Me.Controls.Add(Me.RadioButtonForm_DaypartLengthSummary)
            Me.Controls.Add(Me.RadioButtonForm_LengthSummary)
            Me.Controls.Add(Me.RadioButtonForm_StationSummary)
            Me.Controls.Add(Me.RadioButtonForm_DaypartWeeklyDailyGRPSummary)
            Me.Controls.Add(Me.RadioButtonForm_DaypartWeeklyDailySpendSummary)
            Me.Controls.Add(Me.RadioButtonForm_DaypartSummary)
            Me.Controls.Add(Me.RadioButtonForm_MarketSummary)
            Me.Controls.Add(Me.ButtonForm_Export)
            Me.Controls.Add(Me.LabelForm_FilterString)
            Me.Controls.Add(Me.LabelForm_Filter)
            Me.Controls.Add(Me.LabelForm_DemoName)
            Me.Controls.Add(Me.LabelForm_Demo)
            Me.Controls.Add(Me.LabelForm_MarketName)
            Me.Controls.Add(Me.LabelForm_Market)
            Me.Controls.Add(Me.LabelForm_WorksheetName)
            Me.Controls.Add(Me.LabelForm_Worksheet)
            Me.Controls.Add(Me.LabelForm_ClientName)
            Me.Controls.Add(Me.LabelForm_Client)
            Me.Controls.Add(Me.DataGridViewForm_Totals)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailTotalsDialog"
            Me.ShowInTaskbar = False
            Me.Text = "Market Summary"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Totals As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents LabelForm_ClientName As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_WorksheetName As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_Worksheet As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_MarketName As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_Market As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_DemoName As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_Demo As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_FilterString As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_Filter As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ButtonForm_Export As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents RadioButtonForm_MarketSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents RadioButtonForm_DaypartSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_DaypartWeeklyDailySpendSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_DaypartWeeklyDailyGRPSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_StationSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_LengthSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_DaypartLengthSummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_MarketMonthlySummary As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_StationMonthlySummary As WinForm.Presentation.Controls.RadioButtonControl
    End Class

End Namespace