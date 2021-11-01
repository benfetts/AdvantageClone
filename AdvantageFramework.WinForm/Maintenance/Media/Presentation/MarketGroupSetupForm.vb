Namespace Maintenance.Media.Presentation

    Public Class MarketGroupSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MarketGroupSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MarketGroupSetupController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Update.Enabled = _ViewModel.UpdateEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Export.Enabled = _ViewModel.ExportEnabled

            ButtonItemMarkets_Add.Enabled = _ViewModel.AddMarketsEnabled
            ButtonItemMarkets_Delete.Enabled = _ViewModel.DeleteMarketsEnabled
            ButtonItemMarkets_MoveUp.Enabled = _ViewModel.MoveUpMarketEnabled
            ButtonItemMarkets_MoveDown.Enabled = _ViewModel.MoveDownMarketEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewLeftSection_MarketGroups.ByPassUserEntryChanged = True
            DataGridViewLeftSection_MarketGroups.OptionsBehavior.Editable = False
            DataGridViewLeftSection_MarketGroups.OptionsSelection.MultiSelect = False

            DataGridViewLeftSection_MarketGroups.ItemDescription = "Market Group(s)"

            DataGridViewRightSection_MarketGroupMarkets.ByPassUserEntryChanged = True
            DataGridViewRightSection_MarketGroupMarkets.OptionsBehavior.Editable = False
            DataGridViewRightSection_MarketGroupMarkets.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_MarketGroupMarkets.OptionsCustomization.AllowSort = False
            DataGridViewRightSection_MarketGroupMarkets.OptionsMenu.EnableColumnMenu = False
            DataGridViewRightSection_MarketGroupMarkets.OptionsSelection.MultiSelect = True
            DataGridViewRightSection_MarketGroupMarkets.SetBookmarkColumnIndex(0)

            DataGridViewRightSection_MarketGroupMarkets.ItemDescription = "Market(s)"

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub LoadGrid()

            DataGridViewLeftSection_MarketGroups.DataSource = _ViewModel.MarketGroups

        End Sub
        Private Sub FormatGrid()

            DataGridViewLeftSection_MarketGroups.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGrid_Markets()

            DataGridViewRightSection_MarketGroupMarkets.DataSource = _ViewModel.MarketGroupMarkets.ToList

        End Sub
        Private Sub FormatGrid_Markets()

            DataGridViewRightSection_MarketGroupMarkets.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MarketGroupSetupForm As AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSetupForm = Nothing

            MarketGroupSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSetupForm()

            MarketGroupSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MarketGroupSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            ButtonItemMarkets_Add.Image = AdvantageFramework.My.Resources.DetailAddImage
            ButtonItemMarkets_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemMarkets_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemMarkets_MoveDown.Image = AdvantageFramework.My.Resources.DownImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MarketGroupSetupController(Me.Session)

            _ViewModel = _Controller.Load()

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MarketGroupSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewLeftSection_MarketGroups.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim MarketGroupID As Integer = 0

            If AdvantageFramework.Maintenance.Media.Presentation.MarketGroupEditDialog.ShowFormDialog(MarketGroupID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.RefreshMarketGroups(_ViewModel)

                LoadGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_MarketGroups.SelectRow(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.ID.ToString, MarketGroupID, True)

                DataGridViewLeftSection_MarketGroups.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim MarketGroupID As Integer = 0

            MarketGroupID = _ViewModel.SelectedMarketGroup.ID

            If AdvantageFramework.Maintenance.Media.Presentation.MarketGroupEditDialog.ShowFormDialog(MarketGroupID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.RefreshMarketGroups(_ViewModel)

                LoadGrid()

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_MarketGroups.SelectRow(AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroup.Properties.ID.ToString, MarketGroupID, True)

                DataGridViewLeftSection_MarketGroups.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) Then

                        _Controller.RefreshMarketGroups(_ViewModel)

                        LoadGrid()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewLeftSection_MarketGroups.GridViewSelectionChanged()
                        DataGridViewRightSection_MarketGroupMarkets.GridViewSelectionChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewLeftSection_MarketGroups.Print(Me.Session, Me.DefaultLookAndFeel.LookAndFeel, "Market Groups")

        End Sub
        Private Sub ButtonItemMarkets_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Add.Click

            'objects
            Dim MarketGroupID As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                MarketGroupID = _ViewModel.SelectedMarketGroup.ID

                If AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSelectMarketsDialog.ShowFormDialog(MarketGroupID) = Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.MarketGroupSelectionChanged(_ViewModel, DataGridViewLeftSection_MarketGroups.GetFirstSelectedRowDataBoundItem())

                    LoadGrid_Markets()

                    FormatGrid_Markets()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewRightSection_MarketGroupMarkets.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Delete.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.DeleteMarkets(_ViewModel, ErrorMessage) Then

                        LoadGrid_Markets()

                        RefreshViewModel()

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        DataGridViewRightSection_MarketGroupMarkets.GridViewSelectionChanged()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_MoveUp.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                If _Controller.MoveUpMarkets(_ViewModel, ErrorMessage) Then

                    LoadGrid_Markets()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewRightSection_MarketGroupMarkets.CurrentView.RefreshData()
                    DataGridViewRightSection_MarketGroupMarkets.CurrentView.RefreshEditor(True)

                    DataGridViewRightSection_MarketGroupMarkets.GridViewSelectionChanged()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_MoveDown.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                If _Controller.MoveDownMarkets(_ViewModel, ErrorMessage) Then

                    LoadGrid_Markets()

                    RefreshViewModel()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewRightSection_MarketGroupMarkets.CurrentView.RefreshData()
                    DataGridViewRightSection_MarketGroupMarkets.CurrentView.RefreshEditor(True)

                    DataGridViewRightSection_MarketGroupMarkets.GridViewSelectionChanged()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MarketGroups_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_MarketGroups.ColumnFilterChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                DataGridViewLeftSection_MarketGroups.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MarketGroups_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_MarketGroups.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                _Controller.MarketGroupSelectionChanged(_ViewModel, DataGridViewLeftSection_MarketGroups.GetFirstSelectedRowDataBoundItem())

                LoadGrid_Markets()

                FormatGrid_Markets()

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewRightSection_MarketGroupMarkets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_MarketGroupMarkets.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                _Controller.MarketGroupMarketSelectionChanged(_ViewModel, DataGridViewRightSection_MarketGroupMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.MarketGroup.MarketGroupMarket).ToList)

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace