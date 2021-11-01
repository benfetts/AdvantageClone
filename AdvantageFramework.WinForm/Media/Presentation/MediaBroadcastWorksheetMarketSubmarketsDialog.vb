Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketSubmarketsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketSubmarketsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetMarketID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetMarketID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

        End Sub
        Private Sub LoadViewModel()

            LoadAvailableMarketsGrid()
            LoadSelectedMarketsGrid()

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonForm_Add.Enabled = _ViewModel.AddEnabled
            ButtonForm_AddAll.Enabled = _ViewModel.AddAllEnabled
            ButtonForm_Remove.Enabled = _ViewModel.RemoveEnabled
            ButtonForm_RemoveAll.Enabled = _ViewModel.RemoveAllEnabled

            ButtonForm_MoveUp.Enabled = _ViewModel.MoveUpEnabled
            ButtonForm_MoveDown.Enabled = _ViewModel.MoveDownEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_AvailableMarkets.OptionsBehavior.Editable = False
            DataGridViewForm_AvailableMarkets.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_AvailableMarkets.OptionsCustomization.AllowGroup = False
            DataGridViewForm_AvailableMarkets.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_AvailableMarkets.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_AvailableMarkets.MultiSelect = True
            DataGridViewForm_AvailableMarkets.OptionsView.ColumnAutoWidth = False

            DataGridViewForm_SelectedMarkets.OptionsBehavior.Editable = False
            DataGridViewForm_SelectedMarkets.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_SelectedMarkets.OptionsCustomization.AllowGroup = False
            DataGridViewForm_SelectedMarkets.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_SelectedMarkets.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_SelectedMarkets.MultiSelect = True
            DataGridViewForm_SelectedMarkets.OptionsView.ColumnAutoWidth = False

            DataGridViewForm_AvailableMarkets.SetBookmarkColumnIndex(2)
            DataGridViewForm_SelectedMarkets.SetBookmarkColumnIndex(2)

        End Sub
        Private Sub LoadAvailableMarketsGrid()

            DataGridViewForm_AvailableMarkets.DataSource = _ViewModel.AvailableMarkets.ToList

        End Sub
        Private Sub LoadSelectedMarketsGrid()

            DataGridViewForm_SelectedMarkets.DataSource = _ViewModel.SelectedMarkets.ToList

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_AvailableMarkets.CurrentView.BestFitColumns()
            DataGridViewForm_SelectedMarkets.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetMarketID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketSubmarketsDialog As Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsDialog = Nothing

            MediaBroadcastWorksheetMarketSubmarketsDialog = New Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsDialog(MediaBroadcastWorksheetMarketID)

            ShowFormDialog = MediaBroadcastWorksheetMarketSubmarketsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketSubmarketsDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemMarketGroups_Add.Image = AdvantageFramework.My.Resources.DetailAddImage

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            _ViewModel = _Controller.MarketSubmarkets_Load(_MediaBroadcastWorksheetMarketID)

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaBroadcastWorksheetMarketSubmarketsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
            DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                If _Controller.MarketSubmarkets_Save(_ViewModel, ErrorMessage) Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemMarketGroups_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemMarketGroups_Add.Click

            'objects
            Dim MarketGroupID As Integer = 0

            If AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketSubmarketsAddMarketGroupDialog.ShowFormDialog(_ViewModel.MediaBroadcastWorksheetMarketID, MarketGroupID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.MarketSubmarkets_AddMarketGroup(_ViewModel, MarketGroupID)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
                DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim AvailableMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                AvailableMarkets = DataGridViewForm_AvailableMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                _Controller.MarketSubmarkets_AddMarkets(_ViewModel, AvailableMarkets)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
                DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddAll.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.MarketSubmarkets_AddAllMarkets(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
                DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_Remove_Click(sender As Object, e As EventArgs) Handles ButtonForm_Remove.Click

            'objects
            Dim SelectedMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                SelectedMarkets = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                _Controller.MarketSubmarkets_RemoveMarkets(_ViewModel, SelectedMarkets)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
                DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_RemoveAll.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.MarketSubmarkets_RemoveAllMarkets(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableMarkets.GridViewSelectionChanged()
                DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveUp.Click

            'objects
            Dim SelectedMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectedMarkets = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                If SelectedMarkets IsNot Nothing AndAlso SelectedMarkets.Count = 1 Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    _Controller.MarketSubmarkets_MoveUpMarkets(_ViewModel, SelectedMarkets(0))

                    LoadSelectedMarketsGrid()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    RefreshViewModel()

                    DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonForm_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveDown.Click

            'objects
            Dim SelectedMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectedMarkets = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                If SelectedMarkets IsNot Nothing AndAlso SelectedMarkets.Count = 1 Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    _Controller.MarketSubmarkets_MoveDownMarkets(_ViewModel, SelectedMarkets(0))

                    LoadSelectedMarketsGrid()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    RefreshViewModel()

                    DataGridViewForm_SelectedMarkets.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AvailableMarkets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AvailableMarkets.SelectionChangedEvent

            'objects
            Dim AvailableMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                AvailableMarkets = DataGridViewForm_AvailableMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                _Controller.MarketSubmarkets_AvailableMarketsSelectedChanged(_ViewModel, AvailableMarkets)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_SelectedMarkets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_SelectedMarkets.SelectionChangedEvent

            'objects
            Dim SelectedMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectedMarkets = DataGridViewForm_SelectedMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket).ToList

                _Controller.MarketSubmarkets_SelectedMarketsSelectedChanged(_ViewModel, SelectedMarkets)

                RefreshViewModel()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace