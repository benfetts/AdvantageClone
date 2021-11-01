Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketDetailMakegoodDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailMakegoodDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.BandedDataGridViewForm_MakegoodDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView()
            Me.LabelForm_DaypartValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Daypart = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Length = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_CableNetwork = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_LengthValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_StartTimeValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_EndTimeValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DaysValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_CableNetworkValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DefaultRateValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_DefaultRate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Program = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_ProgramValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(710, 450)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 17
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(791, 450)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 18
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'BandedDataGridViewForm_MakegoodDetails
            '
            Me.BandedDataGridViewForm_MakegoodDetails.AllowSelectGroupHeaderRow = True
            Me.BandedDataGridViewForm_MakegoodDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BandedDataGridViewForm_MakegoodDetails.AutoUpdateViewCaption = True
            Me.BandedDataGridViewForm_MakegoodDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.BandedDataGridViewForm_MakegoodDetails.ItemDescription = "Makegood Detail(s)"
            Me.BandedDataGridViewForm_MakegoodDetails.Location = New System.Drawing.Point(12, 64)
            Me.BandedDataGridViewForm_MakegoodDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.BandedDataGridViewForm_MakegoodDetails.ModifyGridRowHeight = True
            Me.BandedDataGridViewForm_MakegoodDetails.MultiSelect = True
            Me.BandedDataGridViewForm_MakegoodDetails.Name = "BandedDataGridViewForm_MakegoodDetails"
            Me.BandedDataGridViewForm_MakegoodDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.BandedDataGridViewForm_MakegoodDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.BandedDataGridViewForm_MakegoodDetails.ShowRowSelectionIfHidden = True
            Me.BandedDataGridViewForm_MakegoodDetails.ShowSelectDeselectAllButtons = False
            Me.BandedDataGridViewForm_MakegoodDetails.Size = New System.Drawing.Size(854, 368)
            Me.BandedDataGridViewForm_MakegoodDetails.TabIndex = 16
            Me.BandedDataGridViewForm_MakegoodDetails.UseEmbeddedNavigator = False
            Me.BandedDataGridViewForm_MakegoodDetails.ViewCaptionHeight = -1
            '
            'LabelForm_DaypartValue
            '
            Me.LabelForm_DaypartValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DaypartValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaypartValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaypartValue.Location = New System.Drawing.Point(86, 12)
            Me.LabelForm_DaypartValue.Name = "LabelForm_DaypartValue"
            Me.LabelForm_DaypartValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_DaypartValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaypartValue.TabIndex = 1
            '
            'LabelForm_Daypart
            '
            Me.LabelForm_Daypart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Daypart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Daypart.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Daypart.Name = "LabelForm_Daypart"
            Me.LabelForm_Daypart.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Daypart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Daypart.TabIndex = 0
            Me.LabelForm_Daypart.Text = "Daypart:"
            '
            'LabelForm_Length
            '
            Me.LabelForm_Length.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Length.Location = New System.Drawing.Point(195, 12)
            Me.LabelForm_Length.Name = "LabelForm_Length"
            Me.LabelForm_Length.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Length.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Length.TabIndex = 2
            Me.LabelForm_Length.Text = "Length:"
            '
            'LabelForm_Days
            '
            Me.LabelForm_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Days.Location = New System.Drawing.Point(378, 12)
            Me.LabelForm_Days.Name = "LabelForm_Days"
            Me.LabelForm_Days.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Days.TabIndex = 4
            Me.LabelForm_Days.Text = "Days:"
            '
            'LabelForm_StartTime
            '
            Me.LabelForm_StartTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartTime.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_StartTime.Name = "LabelForm_StartTime"
            Me.LabelForm_StartTime.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartTime.TabIndex = 8
            Me.LabelForm_StartTime.Text = "Start Time:"
            '
            'LabelForm_EndTime
            '
            Me.LabelForm_EndTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndTime.Location = New System.Drawing.Point(195, 38)
            Me.LabelForm_EndTime.Name = "LabelForm_EndTime"
            Me.LabelForm_EndTime.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndTime.TabIndex = 10
            Me.LabelForm_EndTime.Text = "End Time:"
            '
            'LabelForm_CableNetwork
            '
            Me.LabelForm_CableNetwork.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CableNetwork.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CableNetwork.Location = New System.Drawing.Point(561, 12)
            Me.LabelForm_CableNetwork.Name = "LabelForm_CableNetwork"
            Me.LabelForm_CableNetwork.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_CableNetwork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CableNetwork.TabIndex = 6
            Me.LabelForm_CableNetwork.Text = "Cable Network:"
            '
            'LabelForm_LengthValue
            '
            Me.LabelForm_LengthValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_LengthValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_LengthValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_LengthValue.Location = New System.Drawing.Point(269, 12)
            Me.LabelForm_LengthValue.Name = "LabelForm_LengthValue"
            Me.LabelForm_LengthValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_LengthValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_LengthValue.TabIndex = 3
            '
            'LabelForm_StartTimeValue
            '
            Me.LabelForm_StartTimeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_StartTimeValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartTimeValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartTimeValue.Location = New System.Drawing.Point(86, 38)
            Me.LabelForm_StartTimeValue.Name = "LabelForm_StartTimeValue"
            Me.LabelForm_StartTimeValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_StartTimeValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartTimeValue.TabIndex = 9
            '
            'LabelForm_EndTimeValue
            '
            Me.LabelForm_EndTimeValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_EndTimeValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndTimeValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndTimeValue.Location = New System.Drawing.Point(269, 38)
            Me.LabelForm_EndTimeValue.Name = "LabelForm_EndTimeValue"
            Me.LabelForm_EndTimeValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_EndTimeValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndTimeValue.TabIndex = 11
            '
            'LabelForm_DaysValue
            '
            Me.LabelForm_DaysValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DaysValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DaysValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DaysValue.Location = New System.Drawing.Point(452, 12)
            Me.LabelForm_DaysValue.Name = "LabelForm_DaysValue"
            Me.LabelForm_DaysValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_DaysValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DaysValue.TabIndex = 5
            '
            'LabelForm_CableNetworkValue
            '
            Me.LabelForm_CableNetworkValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CableNetworkValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CableNetworkValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CableNetworkValue.Location = New System.Drawing.Point(649, 12)
            Me.LabelForm_CableNetworkValue.Name = "LabelForm_CableNetworkValue"
            Me.LabelForm_CableNetworkValue.Size = New System.Drawing.Size(217, 20)
            Me.LabelForm_CableNetworkValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CableNetworkValue.TabIndex = 7
            '
            'LabelForm_DefaultRateValue
            '
            Me.LabelForm_DefaultRateValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_DefaultRateValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultRateValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultRateValue.Location = New System.Drawing.Point(452, 38)
            Me.LabelForm_DefaultRateValue.Name = "LabelForm_DefaultRateValue"
            Me.LabelForm_DefaultRateValue.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_DefaultRateValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultRateValue.TabIndex = 13
            '
            'LabelForm_DefaultRate
            '
            Me.LabelForm_DefaultRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultRate.Location = New System.Drawing.Point(378, 38)
            Me.LabelForm_DefaultRate.Name = "LabelForm_DefaultRate"
            Me.LabelForm_DefaultRate.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_DefaultRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultRate.TabIndex = 12
            Me.LabelForm_DefaultRate.Text = "Default Rate:"
            '
            'LabelForm_Program
            '
            Me.LabelForm_Program.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Program.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Program.Location = New System.Drawing.Point(561, 38)
            Me.LabelForm_Program.Name = "LabelForm_Program"
            Me.LabelForm_Program.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_Program.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Program.TabIndex = 14
            Me.LabelForm_Program.Text = "Program:"
            '
            'LabelForm_ProgramValue
            '
            Me.LabelForm_ProgramValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ProgramValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ProgramValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ProgramValue.Location = New System.Drawing.Point(649, 38)
            Me.LabelForm_ProgramValue.Name = "LabelForm_ProgramValue"
            Me.LabelForm_ProgramValue.Size = New System.Drawing.Size(217, 20)
            Me.LabelForm_ProgramValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ProgramValue.TabIndex = 15
            '
            'MediaBroadcastWorksheetMarketDetailMakegoodDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(878, 482)
            Me.Controls.Add(Me.LabelForm_ProgramValue)
            Me.Controls.Add(Me.LabelForm_Program)
            Me.Controls.Add(Me.LabelForm_DefaultRateValue)
            Me.Controls.Add(Me.LabelForm_DefaultRate)
            Me.Controls.Add(Me.LabelForm_CableNetworkValue)
            Me.Controls.Add(Me.LabelForm_DaysValue)
            Me.Controls.Add(Me.LabelForm_EndTimeValue)
            Me.Controls.Add(Me.LabelForm_StartTimeValue)
            Me.Controls.Add(Me.LabelForm_LengthValue)
            Me.Controls.Add(Me.LabelForm_CableNetwork)
            Me.Controls.Add(Me.LabelForm_EndTime)
            Me.Controls.Add(Me.LabelForm_StartTime)
            Me.Controls.Add(Me.LabelForm_Days)
            Me.Controls.Add(Me.LabelForm_Length)
            Me.Controls.Add(Me.LabelForm_DaypartValue)
            Me.Controls.Add(Me.LabelForm_Daypart)
            Me.Controls.Add(Me.BandedDataGridViewForm_MakegoodDetails)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailMakegoodDialog"
            Me.Text = "Makegood"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents BandedDataGridViewForm_MakegoodDetails As WinForm.MVC.Presentation.Controls.BandedDataGridView
        Friend WithEvents LabelForm_DaypartValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Daypart As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Length As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndTimeValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Days As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_DaysValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_CableNetworkValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_DefaultRateValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_CableNetwork As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_LengthValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartTimeValue As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_DefaultRate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Program As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_ProgramValue As WinForm.MVC.Presentation.Controls.Label
    End Class

End Namespace