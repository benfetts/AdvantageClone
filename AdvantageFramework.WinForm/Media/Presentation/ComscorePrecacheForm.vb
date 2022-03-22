'Option Strict On

Namespace Media.Presentation

    Public Class ComscorePrecacheForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.ComscorePrecacheViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.ComscorePrecacheController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            Me.ShowWaitForm("Loading...")

            _ViewModel = _Controller.Load()

            DataGridViewLeftSection_Markets.DataSource = _ViewModel.Markets

            If DataGridViewLeftSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.Select.ToString) IsNot Nothing Then

                DataGridViewLeftSection_Markets.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.Market.Properties.Select.ToString).Visible = False

            End If

            DataGridViewRightSection_Stations.DataSource = _ViewModel.MarketStations
            DataGridViewRightSection_Stations.CurrentView.BestFitColumns()

            DataGridViewBooks_Books.DataSource = _ViewModel.MarketBooks
            DataGridViewBooks_Books.CurrentView.BestFitColumns()

            DataGridViewDemographics_Demographics.DataSource = _ViewModel.MarketDemographics
            DataGridViewDemographics_Demographics.CurrentView.BestFitColumns()

            DataGridViewCached_Cached.DataSource = _ViewModel.MarketCached
            DataGridViewCached_Cached.CurrentView.BestFitColumns()

            Me.CloseWaitForm()

        End Sub
        Private Sub RefreshViewModel()

            Me.ShowWaitForm("Refreshing...")

            DataGridViewLeftSection_Markets.CurrentView.RefreshData()
            DataGridViewRightSection_Stations.CurrentView.RefreshData()
            DataGridViewBooks_Books.CurrentView.RefreshData()
            DataGridViewDemographics_Demographics.CurrentView.RefreshData()
            DataGridViewCached_Cached.CurrentView.RefreshData()

            Me.CloseWaitForm()

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.SelectedMarket = DirectCast(DataGridViewLeftSection_Markets.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.ComscorePrecache.Market)

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ComscorePrecacheForm As AdvantageFramework.Media.Presentation.ComscorePrecacheForm = Nothing

            ComscorePrecacheForm = New AdvantageFramework.Media.Presentation.ComscorePrecacheForm

            ComscorePrecacheForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ComscorePrecacheForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            DataGridViewLeftSection_Markets.OptionsBehavior.Editable = False
            DataGridViewRightSection_Stations.OptionsBehavior.Editable = True
            DataGridViewBooks_Books.OptionsBehavior.Editable = True
            DataGridViewDemographics_Demographics.OptionsBehavior.Editable = True
            DataGridViewCached_Cached.OptionsBehavior.Editable = False

            _Controller = New AdvantageFramework.Controller.Media.ComscorePrecacheController(Me.Session)

        End Sub
        Private Sub ComscorePrecacheForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            Dim SelectedMarkets As IEnumerable = Nothing
            Dim MarketCode As String = Nothing

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ComscoreMarket, True, False, SelectedMarkets, False) = Windows.Forms.DialogResult.OK Then

                If SelectedMarkets IsNot Nothing Then

                    Try

                        MarketCode = (From Entity In SelectedMarkets
                                      Select Entity.Code).FirstOrDefault

                    Catch ex As Exception
                        MarketCode = Nothing
                    End Try

                    If MarketCode IsNot Nothing Then

                        _Controller.AddMarket(MarketCode, _ViewModel)
                        DataGridViewLeftSection_Markets.DataSource = _ViewModel.Markets

                        RefreshViewModel()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            If _ViewModel.SelectedMarket IsNot Nothing Then

                If AdvantageFramework.WinForm.MessageBox.Show("Remove market '" & _ViewModel.SelectedMarket.Name & "' from pre-cache markets?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm") = WinForm.MessageBox.DialogResults.Yes Then

                    _Controller.DeleteMarket(_ViewModel)
                    DataGridViewLeftSection_Markets.DataSource = _ViewModel.Markets

                End If

            End If

        End Sub
        Private Sub DataGridViewBooks_Books_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewBooks_Books.ColumnEditValueChangingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewBooks_Books.HasMultipleSelectedRows = False AndAlso
                    DataGridViewBooks_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.ComscorePrecache.Book.Properties.IsSelected.ToString Then

                If CBool(e.NewValue) = True Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    _Controller.AddMarketBook(_ViewModel, DirectCast(DataGridViewBooks_Books.CurrentView.GetRow(DataGridViewBooks_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Book).ComscoreTVBookID)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    _Controller.DeleteMarketBook(_ViewModel, DirectCast(DataGridViewBooks_Books.CurrentView.GetRow(DataGridViewBooks_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Book).MarketBookID.Value)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DataGridViewBooks_Books_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewBooks_Books.ShowingEditorEvent

            If DataGridViewBooks_Books.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.ComscorePrecache.Book.Properties.IsSelected.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewDemographics_Demographics_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewDemographics_Demographics.ColumnEditValueChangingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewDemographics_Demographics.HasMultipleSelectedRows = False AndAlso
                    DataGridViewDemographics_Demographics.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.ComscorePrecache.Book.Properties.IsSelected.ToString Then

                If CBool(e.NewValue) = True Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    _Controller.AddMarketDemographic(_ViewModel, DirectCast(DataGridViewDemographics_Demographics.CurrentView.GetRow(DataGridViewDemographics_Demographics.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Demographic).ComscoreDemoNumber)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    _Controller.DeleteMarketDemographic(_ViewModel, DirectCast(DataGridViewDemographics_Demographics.CurrentView.GetRow(DataGridViewDemographics_Demographics.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Demographic).MarketDemoID.Value)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DataGridViewDemographics_Demographics_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewDemographics_Demographics.ShowingEditorEvent

            If DataGridViewDemographics_Demographics.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.ComscorePrecache.Book.Properties.IsSelected.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_Markets.FocusedRowChangedEvent

            If Me.FormShown Then

                If DataGridViewLeftSection_Markets.HasASelectedRow Then

                    SaveViewModel()

                    _Controller.GetMarketStations(_ViewModel)

                    RefreshViewModel()

                Else

                    SaveViewModel()

                    _Controller.ClearMarketStations(_ViewModel)

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Stations_ColumnEditValueChangingEvent(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DataGridViewRightSection_Stations.ColumnEditValueChangingEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewRightSection_Stations.HasMultipleSelectedRows = False AndAlso
                    DataGridViewRightSection_Stations.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.ComscorePrecache.Station.Properties.IsSelected.ToString Then

                If CBool(e.NewValue) = True Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                    _Controller.AddMarketStation(_ViewModel, DirectCast(DataGridViewRightSection_Stations.CurrentView.GetRow(DataGridViewRightSection_Stations.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Station).Number)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    _Controller.DeleteMarketStation(_ViewModel, DirectCast(DataGridViewRightSection_Stations.CurrentView.GetRow(DataGridViewRightSection_Stations.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.ComscorePrecache.Station).MarketStationID.Value)

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Stations_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightSection_Stations.ShowingEditorEvent

            If DataGridViewRightSection_Stations.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.ComscorePrecache.Station.Properties.IsSelected.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TabControlForm_ComscorePrecacheDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ComscorePrecacheDetails.SelectedTabChanged

            If e.NewTab.Equals(TabItemForm_BooksTab) Then

                _Controller.GetMarketBooks(_ViewModel)
                RefreshViewModel()

            ElseIf e.NewTab.Equals(TabItemForm_DemographicsTab) Then

                _Controller.GetMarketDemographics(_ViewModel)
                RefreshViewModel()

            ElseIf e.NewTab.Equals(TabItemForm_CachedTab) Then

                _Controller.GetMarketCached(_ViewModel)
                RefreshViewModel()

            End If

        End Sub
        Private Sub TabControlForm_ComscorePrecacheDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_ComscorePrecacheDetails.SelectedTabChanging

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel.SelectedMarket Is Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select a market first.")
                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
