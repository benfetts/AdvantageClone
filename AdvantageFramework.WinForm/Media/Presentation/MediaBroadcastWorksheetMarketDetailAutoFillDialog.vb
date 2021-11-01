Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailAutoFillDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _WorksheetMarketDetailAutoFill As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill = Nothing
        Protected _DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
        Protected _RowIndexes As Generic.List(Of Integer) = Nothing
        Protected _SelectedItemIndex As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property WorksheetMarketDetailAutoFill As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill
            Get
                WorksheetMarketDetailAutoFill = _WorksheetMarketDetailAutoFill
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel, RowIndexes As Generic.List(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketDetailsViewModel
            _RowIndexes = RowIndexes

        End Sub
        Private Sub LoadViewModel()

            ComboBoxForm_Daypart.SelectedValue = _WorksheetMarketDetailAutoFill.DaypartCode
            CheckBoxForm_DaypartClear.Checked = _WorksheetMarketDetailAutoFill.DaypartClear

            NumericInputForm_Length.EditValue = _WorksheetMarketDetailAutoFill.Length
            CheckBoxForm_LengthClear.Checked = _WorksheetMarketDetailAutoFill.LengthClear

            TextBoxForm_Days.Text = _WorksheetMarketDetailAutoFill.Days
            CheckBoxForm_DaysClear.Checked = _WorksheetMarketDetailAutoFill.DaysClear

            TextBoxForm_StartTime.Text = _WorksheetMarketDetailAutoFill.StartTime
            CheckBoxForm_StartTimeClear.Checked = _WorksheetMarketDetailAutoFill.StartTimeClear

            TextBoxForm_EndTime.Text = _WorksheetMarketDetailAutoFill.EndTime
            CheckBoxForm_EndTimeClear.Checked = _WorksheetMarketDetailAutoFill.EndTimeClear

            TextBoxForm_Comments.Text = _WorksheetMarketDetailAutoFill.Comments
            CheckBoxForm_CommentsClear.Checked = _WorksheetMarketDetailAutoFill.CommentsClear

            CheckBoxForm_AddedValue.Checked = _WorksheetMarketDetailAutoFill.ValueAdded
            'CheckBoxForm_Bookends.Checked = _WorksheetMarketDetailAutoFill.Bookend

        End Sub
        Private Sub SaveViewModel()

            _WorksheetMarketDetailAutoFill.DaypartCode = ComboBoxForm_Daypart.GetSelectedValue
            _WorksheetMarketDetailAutoFill.DaypartClear = CheckBoxForm_DaypartClear.Checked

            _WorksheetMarketDetailAutoFill.Length = NumericInputForm_Length.GetValue
            _WorksheetMarketDetailAutoFill.LengthClear = CheckBoxForm_LengthClear.Checked

            _WorksheetMarketDetailAutoFill.Days = TextBoxForm_Days.GetText
            _WorksheetMarketDetailAutoFill.DaysClear = CheckBoxForm_DaysClear.Checked

            _WorksheetMarketDetailAutoFill.StartTime = TextBoxForm_StartTime.GetText
            _WorksheetMarketDetailAutoFill.StartTimeClear = CheckBoxForm_StartTimeClear.Checked

            _WorksheetMarketDetailAutoFill.EndTime = TextBoxForm_EndTime.GetText
            _WorksheetMarketDetailAutoFill.EndTimeClear = CheckBoxForm_EndTimeClear.Checked

            _WorksheetMarketDetailAutoFill.Comments = TextBoxForm_Comments.GetText
            _WorksheetMarketDetailAutoFill.CommentsClear = CheckBoxForm_CommentsClear.Checked

            _WorksheetMarketDetailAutoFill.ValueAdded = CheckBoxForm_AddedValue.Checked
            '_WorksheetMarketDetailAutoFill.Bookend = CheckBoxForm_Bookends.Checked

            _WorksheetMarketDetailAutoFill.DaypartCode = If(String.IsNullOrWhiteSpace(_WorksheetMarketDetailAutoFill.DaypartCode), "", _WorksheetMarketDetailAutoFill.DaypartCode)
            _WorksheetMarketDetailAutoFill.Days = If(String.IsNullOrWhiteSpace(_WorksheetMarketDetailAutoFill.Days), "", _WorksheetMarketDetailAutoFill.Days)
            _WorksheetMarketDetailAutoFill.StartTime = If(String.IsNullOrWhiteSpace(_WorksheetMarketDetailAutoFill.StartTime), "", _WorksheetMarketDetailAutoFill.StartTime)
            _WorksheetMarketDetailAutoFill.EndTime = If(String.IsNullOrWhiteSpace(_WorksheetMarketDetailAutoFill.EndTime), "", _WorksheetMarketDetailAutoFill.EndTime)
            _WorksheetMarketDetailAutoFill.Comments = If(String.IsNullOrWhiteSpace(_WorksheetMarketDetailAutoFill.Comments), "", _WorksheetMarketDetailAutoFill.Comments)

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonControlForm_FromBlank.Checked Then

                ButtonForm_SelectFirst.Visible = False
                ButtonForm_SelectLast.Visible = False
                ButtonForm_SelectNext.Visible = False
                ButtonForm_SelectPrevious.Visible = False

            Else

                ButtonForm_SelectFirst.Visible = True
                ButtonForm_SelectLast.Visible = True
                ButtonForm_SelectNext.Visible = True
                ButtonForm_SelectPrevious.Visible = True

                ButtonForm_SelectFirst.Enabled = Convert.ToBoolean(_SelectedItemIndex)
                ButtonForm_SelectLast.Enabled = If(_SelectedItemIndex + 1 < _RowIndexes.Count, True, False)
                ButtonForm_SelectNext.Enabled = If(_SelectedItemIndex + 1 < _RowIndexes.Count, True, False)
                ButtonForm_SelectPrevious.Enabled = Convert.ToBoolean(_SelectedItemIndex)

            End If

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxForm_Daypart.DataSource = _ViewModel.Dayparts.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            NumericInputForm_Length.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            'If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

            '    CheckBoxForm_Bookends.Visible = False

            'Else

            '    CheckBoxForm_Bookends.Visible = False

            'End If

        End Sub
        Private Sub LoadAutoFillObject()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If RadioButtonControlForm_FromBlank.Checked Then

                _WorksheetMarketDetailAutoFill = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill

            Else

                _WorksheetMarketDetailAutoFill = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill

                DataRow = _ViewModel.DataTable.Rows(_RowIndexes(_SelectedItemIndex))

                _WorksheetMarketDetailAutoFill.DaypartCode = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString)
                _WorksheetMarketDetailAutoFill.Length = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString)
                _WorksheetMarketDetailAutoFill.Days = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString)
                _WorksheetMarketDetailAutoFill.StartTime = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) Is DBNull.Value, String.Empty, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString))
                _WorksheetMarketDetailAutoFill.EndTime = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) Is DBNull.Value, String.Empty, DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString))
                _WorksheetMarketDetailAutoFill.Comments = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString)
                _WorksheetMarketDetailAutoFill.ValueAdded = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
                                              ByRef WorksheetMarketDetailAutoFill As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailAutoFill,
                                              RowIndexes As Generic.List(Of Integer)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketDetailAutoFillDialog As MediaBroadcastWorksheetMarketDetailAutoFillDialog = Nothing

            MediaBroadcastWorksheetMarketDetailAutoFillDialog = New MediaBroadcastWorksheetMarketDetailAutoFillDialog(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndexes)

            ShowFormDialog = MediaBroadcastWorksheetMarketDetailAutoFillDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                WorksheetMarketDetailAutoFill = MediaBroadcastWorksheetMarketDetailAutoFillDialog.WorksheetMarketDetailAutoFill

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailAutoFillDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)
            _DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            SetControlPropertySettings()

            SetControlDataSources()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailAutoFillDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadAutoFillObject()

            LoadViewModel()

            EnableOrDisableActions()

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                SaveViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub TextBoxForm_Days_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxForm_Days.FinalizeValidationEvent

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.HasValue

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.HasValue

            End If

            _DaysAndTimeController.ParseDays(_WorksheetMarketDetailAutoFill.DaysAndTime, TextBoxForm_Days.Text, IsValid)

            If IsValid Then

                ErrorText = String.Empty

            Else

                ErrorText = "Invalid Day Entry."

            End If

        End Sub
        Private Sub TextBoxForm_StartTime_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxForm_StartTime.FinalizeValidationEvent

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.HasValue

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.HasValue

            End If

            If TextBoxForm_StartTime.Text IsNot Nothing Then

                TextBoxForm_StartTime.Text = TextBoxForm_StartTime.Text.Trim

            End If

            _DaysAndTimeController.ParseTime(_WorksheetMarketDetailAutoFill.DaysAndTime, True, TextBoxForm_StartTime.Text, IsValid)

            If IsValid Then

                ErrorText = String.Empty

            Else

                ErrorText = "Invalid Time Entry."

            End If

        End Sub
        Private Sub TextBoxForm_EndTime_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxForm_EndTime.FinalizeValidationEvent

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.HasValue

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                _WorksheetMarketDetailAutoFill.DaysAndTime.IsUsing3rdPartyData = _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.HasValue

            End If

            If TextBoxForm_EndTime.Text IsNot Nothing Then

                TextBoxForm_EndTime.Text = TextBoxForm_EndTime.Text.Trim

            End If

            _DaysAndTimeController.ParseTime(_WorksheetMarketDetailAutoFill.DaysAndTime, False, TextBoxForm_EndTime.Text, IsValid)

            If IsValid Then

                ErrorText = String.Empty

            Else

                ErrorText = "Invalid Time Entry."

            End If

        End Sub
        Private Sub RadioButtonControlForm_FromBlank_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControlForm_FromBlank.CheckedChanged

            If RadioButtonControlForm_FromBlank.Checked Then

                LoadAutoFillObject()

                LoadViewModel()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonControlForm_UpdateFromSelected_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControlForm_UpdateFromSelected.CheckedChanged

            If RadioButtonControlForm_UpdateFromSelected.Checked Then

                LoadAutoFillObject()

                LoadViewModel()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_SelectFirst_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectFirst.Click

            _SelectedItemIndex = 0

            LoadAutoFillObject()

            LoadViewModel()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectLast_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectLast.Click

            If _RowIndexes.Count > 0 Then

                _SelectedItemIndex = _RowIndexes.Count - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadAutoFillObject()

            LoadViewModel()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectNext_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectNext.Click

            If _RowIndexes.Count > 0 AndAlso _SelectedItemIndex + 1 < _RowIndexes.Count Then

                _SelectedItemIndex = _SelectedItemIndex + 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadAutoFillObject()

            LoadViewModel()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectPrevious_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectPrevious.Click

            If _RowIndexes.Count > 0 AndAlso _SelectedItemIndex - 1 >= 0 Then

                _SelectedItemIndex = _SelectedItemIndex - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadAutoFillObject()

            LoadViewModel()

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_DaypartClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_DaypartClear.CheckedChanged

            If CheckBoxForm_DaypartClear.Checked Then

                ComboBoxForm_Daypart.SelectedIndex = 0
                ComboBoxForm_Daypart.Enabled = False

            Else

                ComboBoxForm_Daypart.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_LengthClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_LengthClear.CheckedChanged

            If CheckBoxForm_LengthClear.Checked Then

                NumericInputForm_Length.EditValue = 0
                NumericInputForm_Length.Enabled = False

            Else

                NumericInputForm_Length.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_DaysClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_DaysClear.CheckedChanged

            If CheckBoxForm_DaysClear.Checked Then

                TextBoxForm_Days.Text = String.Empty
                TextBoxForm_Days.Enabled = False

            Else

                TextBoxForm_Days.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_StartTimeClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_StartTimeClear.CheckedChanged

            If CheckBoxForm_StartTimeClear.Checked Then

                TextBoxForm_StartTime.Text = String.Empty
                TextBoxForm_StartTime.Enabled = False

            Else

                TextBoxForm_StartTime.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_EndTimeClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_EndTimeClear.CheckedChanged

            If CheckBoxForm_EndTimeClear.Checked Then

                TextBoxForm_EndTime.Text = String.Empty
                TextBoxForm_EndTime.Enabled = False

            Else

                TextBoxForm_EndTime.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxForm_CommentsClear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_CommentsClear.CheckedChanged

            If CheckBoxForm_CommentsClear.Checked Then

                TextBoxForm_Comments.Text = String.Empty
                TextBoxForm_Comments.Enabled = False

            Else

                TextBoxForm_Comments.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
