Namespace GeneralLedger.Processing.Presentation

    Public Class UpdateToSummaryForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.Processing.UpdateToSummaryViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.GeneralLedger.Processing.UpdateToSummaryController = Nothing
        Protected _CanClearAndRepost As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableDisableActions()

            ButtonItemActions_Clear.SecurityEnabled = _CanClearAndRepost AndAlso _ViewModel.ClearablePostPeriodCodes IsNot Nothing AndAlso _ViewModel.ClearablePostPeriodCodes.Count > 0

            ButtonItemActions_Save.Enabled = DataGridViewForm_GLSourcePost.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost).Any(Function(G) G.Post = True)

            ButtonItemView_QueryUnposted.Enabled = DataGridViewForm_GLSourcePost.HasRows

        End Sub
        Private Sub LoadViewModel()

            Me.ShowWaitForm("Loading...")

            _ViewModel = _Controller.Load()

            DataGridViewLeftSection_PostPeriods.DataSource = _ViewModel.PostPeriodsWithUnpostedEntries
            DataGridViewLeftSection_PostPeriods.CurrentView.BestFitColumns()

            LoadGrid()

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadGrid()

            Dim PostPeriodCodes As IEnumerable(Of String) = Nothing

            If DataGridViewLeftSection_PostPeriods.HasASelectedRow Then

                PostPeriodCodes = (From Entity In DataGridViewLeftSection_PostPeriods.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod)
                                   Select Entity.Code).ToArray

                DataGridViewForm_GLSourcePost.DataSource = (From Entity In _ViewModel.UnpostedJournalEntryList
                                                            Where PostPeriodCodes.Contains(Entity.PostPeriodCode)
                                                            Select Entity.Source, Entity.HeaderDescription).Distinct.Select(Function(E) New AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost(E.Source, E.HeaderDescription)).OrderBy(Function(E) E.SourceType).ToList

            Else

                DataGridViewForm_GLSourcePost.DataSource = New Generic.List(Of AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost)

            End If

            DataGridViewForm_GLSourcePost.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim UpdateToSummaryForm As GeneralLedger.Processing.Presentation.UpdateToSummaryForm = Nothing

            UpdateToSummaryForm = New GeneralLedger.Processing.Presentation.UpdateToSummaryForm

            UpdateToSummaryForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UpdateToSummaryForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Clear.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_QueryUnposted.Image = AdvantageFramework.My.Resources.ViewImage

            DataGridViewLeftSection_PostPeriods.OptionsBehavior.Editable = False

            _CanClearAndRepost = AdvantageFramework.Security.DoesUserHaveAccessToModule(Session, AdvantageFramework.Security.Modules.GeneralLedger_Processing_UpdateToSummary_Actions_OptionToClearAndRepost)

            _Controller = New AdvantageFramework.Controller.GeneralLedger.Processing.UpdateToSummaryController(Me.Session)

        End Sub
        Private Sub UpdateToSummaryForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadViewModel()

            EnableDisableActions()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Clear_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Clear.Click

            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim PostPeriodCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.GLSummaryClearAndRepost, True, True, SelectedPostPeriods, False) = Windows.Forms.DialogResult.OK Then

                Try

                    PostPeriodCode = (From Entity In SelectedPostPeriods
                                      Select Entity.Code).FirstOrDefault

                Catch ex As Exception
                    PostPeriodCode = Nothing
                End Try

                If PostPeriodCode IsNot Nothing AndAlso AdvantageFramework.WinForm.MessageBox.Show("This process will clear the summary data for the selected post period.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm", MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                    If _Controller.Clear(PostPeriodCode, ErrorMessage) Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                        LoadViewModel()

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage, Title:="An error occurred during procesing")

                    End If

                    EnableDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

            LoadViewModel()

            EnableDisableActions()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim PostPeriodCode As String = Nothing
            Dim SourceTypes As IEnumerable(Of String) = Nothing
            Dim ErrorMessage As String = Nothing

            PostPeriodCode = DirectCast(DataGridViewLeftSection_PostPeriods.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod).Code

            SourceTypes = DataGridViewForm_GLSourcePost.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost).Where(Function(G) G.Post = True).Select(Function(G) G.SourceType).ToArray

            If _Controller.Save(PostPeriodCode, SourceTypes, _ViewModel, ErrorMessage) Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                LoadViewModel()

                EnableDisableActions()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemView_QueryUnposted_Click(sender As Object, e As EventArgs) Handles ButtonItemView_QueryUnposted.Click

            Dim PostPeriodCode As String = Nothing

            If DataGridViewLeftSection_PostPeriods.HasASelectedRow Then

                PostPeriodCode = DirectCast(DataGridViewLeftSection_PostPeriods.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod).Code

                AdvantageFramework.GeneralLedger.Processing.Presentation.UnpostedJournalEntryDialog.ShowFormDialog(_ViewModel.UnpostedJournalEntryList.Where(Function(UJE) UJE.PostPeriodCode = PostPeriodCode).ToList)

            End If

        End Sub
        Private Sub DataGridViewForm_GLSourcePost_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GLSourcePost.CellValueChangingEvent

            Dim GLSourcePost As AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost = Nothing

            GLSourcePost = DataGridViewForm_GLSourcePost.CurrentView.GetRow(e.RowHandle)

            If e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost.Properties.Post.ToString Then

                GLSourcePost.Post = e.Value

            End If

            EnableDisableActions()

        End Sub
        Private Sub DataGridViewForm_GLSourcePost_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_GLSourcePost.ShowingEditorEvent

            If DataGridViewForm_GLSourcePost.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost.Properties.Post.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_GLSourcePost_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_GLSourcePost.RowDoubleClickEvent

            Dim SourceType As String = Nothing
            Dim PostPeriodCode As String = Nothing

            SourceType = DirectCast(DataGridViewForm_GLSourcePost.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.Processing.GLSourcePost).SourceType

            PostPeriodCode = DirectCast(DataGridViewLeftSection_PostPeriods.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.GeneralLedger.JournalEntry.PostPeriod).Code

            AdvantageFramework.GeneralLedger.Processing.Presentation.UnpostedJournalEntryDialog.ShowFormDialog(_ViewModel.UnpostedJournalEntryList.Where(Function(UJE) UJE.PostPeriodCode = PostPeriodCode AndAlso UJE.Source = SourceType).ToList)

        End Sub
        Private Sub DataGridViewLeftSection_PostPeriods_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_PostPeriods.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadGrid()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
