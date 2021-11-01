Namespace Media.Presentation

    Public Class MediaManagerAdServingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaManagerAdServingViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaManagerAdServingController = Nothing
        Protected _OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
        Protected _AdServerID As Integer = 0
        Protected _DCProfileID As Long = 0
        Protected _DCReportID As Nullable(Of Long) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(OrderNumberLineNumbers As IEnumerable(Of String), AdServerID As Integer, DCProfileID As Long, DCReportID As Nullable(Of Long))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _OrderNumberLineNumbers = OrderNumberLineNumbers
            _AdServerID = AdServerID
            _DCProfileID = DCProfileID
            _DCReportID = DCReportID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_DCProfileID, _DCReportID)

            If Not String.IsNullOrWhiteSpace(_ViewModel.DoubleClickAPIErrorString) Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.DoubleClickAPIErrorString)

                Me.Close()

            End If

        End Sub
        Private Sub LoadGrid(RefreshRepositoryDataSources As Boolean)

            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If RefreshRepositoryDataSources Then

                If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerAdvertiserID.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerAdvertiserID.ToString).ColumnEdit

                    If RepositoryItemGridLookUpEdit IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(_ViewModel.DictionaryAdServerAdvertiserID)
                        RepositoryItemGridLookUpEdit.DataSource = BindingSource

                    End If

                End If

                If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSiteID.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSiteID.ToString).ColumnEdit

                    If RepositoryItemGridLookUpEdit IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(_ViewModel.DictionaryAdServerSiteID)
                        RepositoryItemGridLookUpEdit.DataSource = BindingSource

                    End If

                End If

                If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString).ColumnEdit

                    If RepositoryItemGridLookUpEdit IsNot Nothing Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(_ViewModel.DictionaryAdServerPlacementIDNames)
                        RepositoryItemGridLookUpEdit.DataSource = BindingSource

                    End If

                End If

            End If

            DataGridViewForm_AdServing.DataSource = _ViewModel.MediaManagerAdServingDetailViewModelList
            DataGridViewForm_AdServing.CurrentView.BestFitColumns()

            If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString) IsNot Nothing Then

                DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString).Width = 79

            End If

            If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString) IsNot Nothing Then

                RepositoryItemGridLookUpEdit = DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString).ColumnEdit

                If RepositoryItemGridLookUpEdit IsNot Nothing Then

                    DirectCast(RepositoryItemGridLookUpEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                End If

            End If

            'If DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdditionalAdSizeCount.ToString) IsNot Nothing Then

            '    AddSubItemTextBoxForPackageDetails(Me.Session, DataGridViewForm_AdServing, DataGridViewForm_AdServing.CurrentView.Columns(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdditionalAdSizeCount.ToString))

            'End If

        End Sub
        Private Sub RefreshViewModel(ReloadGridDataSource As Boolean, RefreshGrid As Boolean)

            If ReloadGridDataSource Then

                Me.ClearChanged()

                LoadViewModel()

                LoadGrid(True)

                DataGridViewForm_AdServing.RefreshDataSource()

            ElseIf RefreshGrid Then

                DataGridViewForm_AdServing.RefreshDataSource()

            End If

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged
            ButtonItemActions_CreateAdvertisers.Enabled = Not Me.UserEntryChanged AndAlso _ViewModel.CreateAdvertisersEnabled
            ButtonItemActions_CreateCampaigns.Enabled = Not Me.UserEntryChanged AndAlso _ViewModel.CreateCampaignsEnabled
            ButtonItemActions_CreatePlacements.Enabled = Not Me.UserEntryChanged AndAlso _ViewModel.CreatePlacementsEnabled
            ButtonItemActions_UpdatePlacements.Enabled = Not Me.UserEntryChanged AndAlso _ViewModel.UpdatePlacementsEnabled
            ButtonItemActions_ClearPlacement.Enabled = _ViewModel.ClearPlacementsEnabled
            ButtonItemActions_Refresh.Enabled = Not Me.UserEntryChanged
            ButtonItemActions_Report.Enabled = _ViewModel.AdServerReportID.HasValue

        End Sub
        'Private Function CheckForExistingButton(ByVal RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

        '    'objects
        '    Dim ButtonExists As Boolean = False

        '    For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

        '        If EditorButton.Kind = ButtonPredefines Then

        '            ButtonExists = True
        '            Exit For

        '        End If

        '    Next

        '    CheckForExistingButton = ButtonExists

        'End Function
        'Private Sub AddSubItemTextBoxForPackageDetails(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView,
        '                                               GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

        '    'objects
        '    Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

        '    RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        '    RepositoryItemButtonEdit.ReadOnly = True

        '    If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

        '        RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

        '    Else

        '        For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

        '            If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

        '                EditorButton.Visible = True
        '                Exit For

        '            End If

        '        Next

        '    End If

        '    DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

        '    GridColumn.ColumnEdit = RepositoryItemButtonEdit

        '    AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEditPackageDetails_ButtonClick

        'End Sub
        'Private Sub RepositoryItemButtonEditPackageDetails_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        '    'objects
        '    Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
        '    Dim RowHandle As Integer = 0

        '    If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis AndAlso DataGridViewForm_AdServing.IsNewItemRow = False Then

        '        Try

        '            GridColumn = DataGridViewForm_AdServing.CurrentView.FocusedColumn

        '        Catch ex As Exception
        '            GridColumn = Nothing
        '        End Try

        '        If GridColumn IsNot Nothing Then

        '            Try

        '                RowHandle = DataGridViewForm_AdServing.CurrentView.FocusedRowHandle

        '            Catch ex As Exception
        '                RowHandle = 0
        '            End Try

        '            If AdvantageFramework.Media.Presentation.MediaManagerAdditionalAdSizeDialog.ShowFormDialog(_MediaPlan, RowHandle) = System.Windows.Forms.DialogResult.OK Then

        '                Me.FormAction = WinForm.Presentation.FormActions.Loading

        '                'LoadGrid()

        '                Me.FormAction = WinForm.Presentation.FormActions.None

        '                'EnableOrDisableActions()

        '                Try

        '                    DataGridViewForm_AdServing.CurrentView.FocusedRowHandle = RowHandle
        '                    DataGridViewForm_AdServing.CurrentView.FocusedColumn = DataGridViewForm_AdServing.CurrentView.Columns(GridColumn.FieldName)
        '                    DataGridViewForm_AdServing.CurrentView.SelectCell(RowHandle, DataGridViewForm_AdServing.CurrentView.FocusedColumn)

        '                Catch ex As Exception

        '                End Try

        '            End If

        '        End If

        '    End If

        'End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(OrderNumberLineNumbers As IEnumerable(Of String), AdServerID As AdvantageFramework.Database.Entities.AdServerID, DCProfileID As Long, DCReportID As Nullable(Of Long)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerAdServingDialog As AdvantageFramework.Media.Presentation.MediaManagerAdServingDialog = Nothing

            MediaManagerAdServingDialog = New AdvantageFramework.Media.Presentation.MediaManagerAdServingDialog(OrderNumberLineNumbers, AdServerID, DCProfileID, DCReportID)

            ShowFormDialog = MediaManagerAdServingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerAdServingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_CreateAdvertisers.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemActions_CreateCampaigns.Image = AdvantageFramework.My.Resources.CampaignImage
            ButtonItemActions_CreatePlacements.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_UpdatePlacements.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_ClearPlacement.Image = AdvantageFramework.My.Resources.ClearImage
            ButtonItemActions_Report.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemGrid_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGrid_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage
            ButtonItemGrid_SelectAll.Image = AdvantageFramework.My.Resources.TableSelectedAllImage

            DataGridViewForm_AdServing.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            _Controller = New AdvantageFramework.Controller.Media.MediaManagerAdServingController(Me.Session, _OrderNumberLineNumbers, _AdServerID)

        End Sub
        Private Sub MediaManagerAdServingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            LoadViewModel()

            LoadGrid(False)

            RefreshViewModel(False, False)

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaManagerAdServingDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            RefreshViewModel(False, False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_AdServing.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_AdServing.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_AdServing.CurrentView.BestFitColumns()
            DataGridViewForm_AdServing.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_AdServing.Print(DefaultLookAndFeel.LookAndFeel, "Media Manager Ad Serving", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.ShowWaitForm("Loading...")

            LoadViewModel()

            RefreshViewModel(True, False)

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_ClearPlacement_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ClearPlacement.Click

            DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

            AdvantageFramework.WinForm.MessageBox.Show("A Cleared Placement allows the order/line to be re-established with a new placement ID. Clearing a placement in Advantage does not update DCM.", WinForm.MessageBox.MessageBoxButtons.OK,, Windows.Forms.MessageBoxIcon.Warning, Windows.Forms.MessageBoxDefaultButton.Button2)

            _Controller.ClearPlacements(_ViewModel)

            DataGridViewForm_AdServing.SetUserEntryChanged()

            RefreshViewModel(False, True)

        End Sub
        Private Sub ButtonItemActions_CreateAdvertisers_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CreateAdvertisers.Click

            Dim ErrorString As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to create advertisers in DoubleClick for selected rows.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo,,, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Creating Advertisers...")

                DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

                If _Controller.CreateAdvertisers(_ViewModel, ErrorString) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorString)

                End If

                RefreshViewModel(True, False)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_CreateCampaigns_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CreateCampaigns.Click

            Dim ErrorString As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to create campaigns in DoubleClick for selected rows.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo,,, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Creating Campaigns...")

                DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

                If _Controller.CreateCampaigns(_ViewModel, _AdServerID, ErrorString) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorString)

                End If

                RefreshViewModel(True, False)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_CreatePlacements_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CreatePlacements.Click

            Dim ErrorString As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to create placements in DoubleClick for selected rows.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo,,, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Creating Placements...")

                DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

                If _Controller.CreatePlacements(_ViewModel, ErrorString) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorString)

                End If

                RefreshViewModel(True, False)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.ShowWaitForm("Refreshing...")

            LoadViewModel()

            RefreshViewModel(True, False)

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Report_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Report.Click

            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog.ShowFormDialog("Select Date Range", _ViewModel.ReportCriteria, False) = Windows.Forms.DialogResult.OK Then

                Me.ShowWaitForm("Processing...")

                If _Controller.RunReport(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Report completed successfully.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = ""

            Me.ShowWaitForm("Saving...")

            DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

            If _Controller.Save(_ViewModel, ErrorMessage) Then

                RefreshViewModel(True, False)

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_UpdatePlacements_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_UpdatePlacements.Click

            Dim ErrorString As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to update placements in DoubleClick for selected rows.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo,,, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Updating Placements...")

                DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

                If _Controller.UpdatePlacements(_ViewModel, ErrorString) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorString)

                End If

                RefreshViewModel(True, False)

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_AdServing.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetType.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString Then

                _Controller.SetValuesBasedOnRepositoryValue(e.Column.FieldName, e.Value, _ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignStartDate.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignEndDate.ToString Then

                _Controller.SetUpdateCampaignEntity(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerAdvertiserID.ToString Then

                _Controller.SetAdServingAdvertiserID(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerCampaignID.ToString Then

                _Controller.SetAdServingCampaignID(_ViewModel)

            ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSiteID.ToString Then

                _Controller.SetAdServingSiteID(_ViewModel)

                'ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetPlacement1.ToString Then

                '    _Controller.SetOrderLinePlacement(_ViewModel, e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString Then

                _Controller.SetAdServingPlacementID(_ViewModel, e.Value)

            End If

            RefreshViewModel(False, True)

        End Sub
        Private Sub DataGridViewForm_AdServing_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_AdServing.CellValueChangingEvent

            'objects
            Dim ErrorMessage As String = Nothing
            Dim AdServerPlacementGroupID As Long = 0
            Dim Action As String = "archive"

            If e.Column.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.IsPlacementArchived.ToString Then

                If _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue Then

                    If Not e.Value Then

                        Action = "unarchive"

                    End If

                    If AdvantageFramework.WinForm.MessageBox.Show("This placement is part of a package, you must " & Action & " the entire package.  Do you want to continue to " & Action & " the entire package?",
                                                                  WinForm.MessageBox.MessageBoxButtons.YesNo, "", Windows.Forms.MessageBoxIcon.Exclamation,
                                                                  Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Updating...")

                        If _Controller.UpdatePackageArchived(_ViewModel, e.Value, ErrorMessage) Then

                            Saved = True

                            AdServerPlacementGroupID = _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.Value

                            For Each MediaManagerAdServingDetailViewModel In _ViewModel.MediaManagerAdServingDetailViewModelList

                                If MediaManagerAdServingDetailViewModel.AdServerPlacementGroupID = AdServerPlacementGroupID Then

                                    MediaManagerAdServingDetailViewModel.IsPlacementArchived = CBool(e.Value)

                                End If

                            Next

                        End If

                        Me.CloseWaitForm()

                    End If

                Else

                    Me.ShowWaitForm("Updating...")

                    If _Controller.UpdatePlacementArchived(_ViewModel, e.Value, ErrorMessage) Then

                        Saved = True

                        _ViewModel.SelectedMediaManagerAdServingDetailViewModel.IsPlacementArchived = CBool(e.Value)

                    End If

                    Me.CloseWaitForm()

                End If

                If Not Saved Then

                    Saved = True

                    DataGridViewForm_AdServing.CurrentView.CloseEditorForUpdating()

                End If

                If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

                RefreshViewModel(False, True)

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_DeselectAllEvent() Handles DataGridViewForm_AdServing.DeselectAllEvent

            _Controller.DeselectAllDetail(_ViewModel)

            If DataGridViewForm_AdServing.HasRows Then

                _Controller.SelectedMediaManagerAdServingDetailViewModelChanged(_ViewModel, DataGridViewForm_AdServing.CurrentView.GetRow(DataGridViewForm_AdServing.CurrentView.FocusedRowHandle))

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_AdServing.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString Then

                Datasource = _ViewModel.AdSizeList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetType.ToString Then

                Datasource = _ViewModel.InternetTypeList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString Then

                Datasource = _ViewModel.CampaignList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerAdvertiserID.ToString Then

                Datasource = _ViewModel.DictionaryAdServerAdvertiserID

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerCampaignID.ToString Then

                Datasource = (From Entity In _ViewModel.AdServerCampaignDataTable
                              Select New With {.ID = Entity.Item("ID"),
                                               .Description = Entity.Item("Name")}).ToList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSiteID.ToString Then

                Datasource = _ViewModel.DictionaryAdServerSiteID

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString Then

                Datasource = _ViewModel.DictionaryAdServerPlacementIDNames

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_AdServing.QueryPopupNeedDatasourceEvent

            Dim AdvertiserID As Long? = Nothing
            Dim AdServerSiteID As Long? = Nothing

            If FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString Then

                OverrideDefaultDatasource = True

                _Controller.RefreshCampaignList(_ViewModel)

                Datasource = _ViewModel.CampaignList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerCampaignID.ToString Then

                AdvertiserID = DirectCast(DataGridViewForm_AdServing.CurrentView.GetRow(DataGridViewForm_AdServing.CurrentView.FocusedRowHandle), AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel).AdServerAdvertiserID

                OverrideDefaultDatasource = True

                _Controller.SetSelectedMediaManagerAdServingDetailAdServerCampaignDataTable(_ViewModel, AdvertiserID)

                Datasource = (From Entity In _ViewModel.SelectedMediaManagerAdServingDetailAdServerCampaignDataTable
                              Select New With {.ID = Entity.Item("ID"),
                                               .Description = Entity.Item("Name")}).ToList

            ElseIf FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString Then

                Me.ShowWaitForm("Retrieving...")

                AdvertiserID = DirectCast(DataGridViewForm_AdServing.CurrentView.GetRow(DataGridViewForm_AdServing.CurrentView.FocusedRowHandle), AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel).AdServerAdvertiserID
                AdServerSiteID = DirectCast(DataGridViewForm_AdServing.CurrentView.GetRow(DataGridViewForm_AdServing.CurrentView.FocusedRowHandle), AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel).AdServerSiteID

                OverrideDefaultDatasource = True

                _Controller.SetSelectedMediaManagerAdServingDetailDictionaryAdServerPlacementIDNames(_ViewModel, AdvertiserID, AdServerSiteID)

                Datasource = _ViewModel.DictionaryAdServerPlacementIDNames

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_SelectAllEvent() Handles DataGridViewForm_AdServing.SelectAllEvent

            _Controller.SelectAllDetail(_ViewModel)

        End Sub
        Private Sub DataGridViewForm_AdServing_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AdServing.SelectionChangedEvent

            _Controller.SelectedMediaManagerAdServingDetailViewModelChanged(_ViewModel, DataGridViewForm_AdServing.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel).ToList)

            RefreshViewModel(False, False)

        End Sub
        Private Sub DataGridViewForm_AdServing_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_AdServing.ShowingEditorEvent

            If _ViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                If (DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignStartDate.ToString OrElse
                        DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignEndDate.ToString) Then

                    If _ViewModel.SelectedMediaManagerAdServingDetailViewModel.IsCancelled OrElse _ViewModel.SelectedMediaManagerAdServingDetailViewModel.CampaignID.HasValue = False Then

                        e.Cancel = True

                    End If

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignID.ToString Then

                    e.Cancel = (_ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerCampaignID.HasValue OrElse _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue OrElse
                        _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue)

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerAdvertiserID.ToString Then

                    e.Cancel = _ViewModel.SelectedMediaManagerAdServingDetailViewModel.HasAdServerAdvertiserID

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerCampaignID.ToString Then

                    e.Cancel = Not _ViewModel.SelectedMediaManagerAdServingDetailViewModel.HasAdServerAdvertiserID OrElse _ViewModel.SelectedMediaManagerAdServingDetailViewModel.HasCampaignID

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSiteID.ToString Then

                    e.Cancel = _ViewModel.SelectedMediaManagerAdServingDetailViewModel.HasAdServerSiteID

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetType.ToString Then

                    e.Cancel = _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue OrElse _ViewModel.SelectedMediaManagerAdServingDetailViewModel.IsCancelled OrElse
                        _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementGroupID.HasValue

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.IsPlacementArchived.ToString Then

                    e.Cancel = Not _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue

                ElseIf DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString Then

                    e.Cancel = (_ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementID.HasValue AndAlso Not _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerPlacementManual) OrElse
                        (_ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerAdvertiserID.HasValue = False OrElse _ViewModel.SelectedMediaManagerAdServingDetailViewModel.AdServerSiteID.HasValue = False) OrElse
                        _ViewModel.SelectedMediaManagerAdServingDetailViewModel.IsNewPackage

                ElseIf (DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString) Then

                    e.Cancel = _ViewModel.SelectedMediaManagerAdServingDetailViewModel.IsCancelled

                ElseIf (DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_AdServing.ValidatingEditorEvent

            If _ViewModel.SelectedMediaManagerAdServingDetailViewModel IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntityProperty(_ViewModel.SelectedMediaManagerAdServingDetailViewModel, DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

            End If

            If Not e.Valid AndAlso (DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.StartDate.ToString OrElse
                    DataGridViewForm_AdServing.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.EndDate.ToString) Then

                AdvantageFramework.WinForm.MessageBox.Show("A date must be entered.")

            Else

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewForm_AdServing_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_AdServing.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

            End If

            e.Valid = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
