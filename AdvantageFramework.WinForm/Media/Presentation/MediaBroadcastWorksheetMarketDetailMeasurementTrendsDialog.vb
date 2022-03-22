Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm = Nothing
        Protected _RowIndex As Integer = -1
        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
        Protected _HasGridBeenFormatted As Boolean = False
        Private WithEvents _GridViewMeasurementTrendDetails As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView = Nothing
        Private _PreviousRowHandle As Integer = -1
        Private _TrendPreviousRowHandle As Integer = -1
        Private _WeeklyDataSources As Hashtable = Nothing
        Protected _ParsingImpressionsValue As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByRef DetailsForm As Media.Presentation.MediaBroadcastWorksheetMarketDetailForm,
                       ByRef Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController,
                       ByRef ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _DetailsForm = DetailsForm
            _Controller = Controller
            _ViewModel = ViewModel

        End Sub
        Private Sub LoadGrid()

            If _BackgroundWorker IsNot Nothing AndAlso _BackgroundWorker.IsBusy Then

                _BackgroundWorker.CancelAsync()

            End If

            DataGridViewForm_Trends.CurrentView.LoadingPanelVisible = True

            'If _BackgroundWorker Is Nothing Then

            _BackgroundWorker = New System.ComponentModel.BackgroundWorker

            _BackgroundWorker.WorkerReportsProgress = True
            _BackgroundWorker.WorkerSupportsCancellation = True

            'End If

            _BackgroundWorker.RunWorkerAsync()

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.ID.ToString) IsNot Nothing Then

                DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.ID.ToString).Visible = False
                DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.ID.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.ID.ToString).OptionsColumn.AllowEdit = False

            End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString).OptionsColumn.AllowEdit = False

                    If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString).Caption = "SIU"

                    End If

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString) IsNot Nothing Then

                    'DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString).OptionsColumn.AllowEdit = False

                End If

                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookProgram.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookShare.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookImpressions.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQHRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQH.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString)

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString) IsNot Nothing Then

                    'DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString) IsNot Nothing Then

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString).OptionsColumn.AllowEdit = False

                End If

                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookProgram.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookShare.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookImpressions.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQHRating.ToString)
                DataGridViewForm_Trends.MakeColumnNotVisible(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQH.ToString)

            End If

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                'Add subitem grid look up here
                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

            Else
                'Add subitem grid look up here
                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

                If DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString) IsNot Nothing Then

                    RepositoryItemGridLookUpEdit = CreateNielsenBookLookUpEditControl()

                    DataGridViewForm_Trends.GridControl.RepositoryItems.Add(RepositoryItemGridLookUpEdit)

                    DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString).ColumnEdit = RepositoryItemGridLookUpEdit

                End If

            End If

        End Sub
        Private Sub SetControlPropertySettings()

            'objects
            Dim AccountTransactionDetailsGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing

            DataGridViewForm_Trends.OptionsBehavior.Editable = True

            DataGridViewForm_Trends.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Trends.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Trends.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Trends.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Trends.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_Trends.OptionsCustomization.AllowSort = False

            DataGridViewForm_Trends.HideRowSelection()
            DataGridViewForm_Trends.ShowRowSelectionIfHidden = False

            DataGridViewForm_Trends.CurrentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            DataGridViewForm_Trends.OptionsSelection.EnableAppearanceFocusedCell = True
            DataGridViewForm_Trends.OptionsSelection.EnableAppearanceFocusedRow = True
            DataGridViewForm_Trends.OptionsSelection.EnableAppearanceHideSelection = True

            DataGridViewForm_Trends.OptionsMenu.EnableColumnMenu = True
            DataGridViewForm_Trends.OptionsMenu.EnableFooterMenu = False
            DataGridViewForm_Trends.OptionsMenu.EnableGroupPanelMenu = False

            DataGridViewForm_Trends.OptionsView.ShowGroupPanel = False
            DataGridViewForm_Trends.OptionsView.ShowViewCaption = False
            DataGridViewForm_Trends.OptionsHint.ShowCellHints = False

            '_BackgroundWorker = New System.ComponentModel.BackgroundWorker

            '_BackgroundWorker.WorkerReportsProgress = True
            '_BackgroundWorker.WorkerSupportsCancellation = True

            DataGridViewForm_Trends.OptionsDetail.EnableMasterViewMode = True
            DataGridViewForm_Trends.OptionsDetail.AllowZoomDetail = False
            DataGridViewForm_Trends.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded
            DataGridViewForm_Trends.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.False
            DataGridViewForm_Trends.CurrentView.LevelIndent = 0
            DataGridViewForm_Trends.CurrentView.DetailVerticalIndent = 0

            _GridViewMeasurementTrendDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView

            DataGridViewForm_Trends.GridControl.LevelTree.Nodes.Add("MeasurementTrendDetails", _GridViewMeasurementTrendDetails)

            _GridViewMeasurementTrendDetails.OptionsView.ShowColumnHeaders = False
            _GridViewMeasurementTrendDetails.LevelIndent = 1
            _GridViewMeasurementTrendDetails.ChildGridLevelName = "MeasurementTrendDetails"
            _GridViewMeasurementTrendDetails.GridControl = DataGridViewForm_Trends.GridControl
            _GridViewMeasurementTrendDetails.Name = "_GridViewMeasurementTrendDetails"
            _GridViewMeasurementTrendDetails.OptionsView.ShowViewCaption = False
            _GridViewMeasurementTrendDetails.OptionsView.ShowFooter = False
            _GridViewMeasurementTrendDetails.OptionsDetail.ShowDetailTabs = False
            _GridViewMeasurementTrendDetails.ViewCaption = "Trend Details"
            _GridViewMeasurementTrendDetails.OptionsView.ShowGroupPanel = False
            _GridViewMeasurementTrendDetails.DetailVerticalIndent = 0
            _GridViewMeasurementTrendDetails.OptionsView.ColumnAutoWidth = False
            _GridViewMeasurementTrendDetails.OptionsBehavior.Editable = False
            _GridViewMeasurementTrendDetails.OptionsMenu.EnableColumnMenu = False
            _GridViewMeasurementTrendDetails.OptionsCustomization.AllowFilter = False
            _GridViewMeasurementTrendDetails.OptionsCustomization.AllowSort = False
            _GridViewMeasurementTrendDetails.OptionsCustomization.AllowColumnMoving = False

            '_GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Book.ToString,
            '                                                                                                '.Width = DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString).Width,
            '.Visible = True})
            _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Book.ToString,
                                                                                                            .Visible = True})
            _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Program.ToString,
                                                                                                            .Visible = True})
            _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Rating.ToString,
                                                                                                            .Visible = True})
            _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Share.ToString,
                                                                                                            .Visible = True})

            If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.HPUT.ToString,
                                                                                                                .Caption = "SIU",
                                                                                                                .CustomizationCaption = "SIU",
                                                                                                                .Visible = True})
            Else

                _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.HPUT.ToString,
                                                                                                                .Caption = "HUT/PUT",
                                                                                                                .Visible = True})
            End If

            _GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Impressions.ToString,
                                                                                                            .Caption = "Imp (000)",
                                                                                                            .Visible = True})
            '_GridViewMeasurementTrendDetails.Columns.Add(New DevExpress.XtraGrid.Columns.GridColumn() With {.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.WeekDate.ToString,
            '                                                                                                .Visible = False})

            DataGridViewForm_Trends.OptionsDetail.ShowDetailTabs = False

            DataGridViewForm_Breakouts.ItemDescription = "Breakouts"

            DataGridViewForm_Breakouts.OptionsBehavior.Editable = False

            DataGridViewForm_Breakouts.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Breakouts.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Breakouts.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Breakouts.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Breakouts.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_Breakouts.OptionsCustomization.AllowSort = False

            DataGridViewForm_Breakouts.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_Breakouts.OptionsMenu.EnableFooterMenu = False
            DataGridViewForm_Breakouts.OptionsMenu.EnableGroupPanelMenu = False

            DataGridViewForm_Breakouts.OptionsView.ShowGroupPanel = False
            DataGridViewForm_Breakouts.OptionsView.ShowViewCaption = False
            DataGridViewForm_Breakouts.OptionsHint.ShowCellHints = False

            DataGridViewForm_Breakouts.HideRowSelection()
            DataGridViewForm_Breakouts.ShowRowSelectionIfHidden = False

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Public Sub RefreshFormData(RowIndex As Integer, VendorName As String, DaysAndTime As AdvantageFramework.DTO.DaysAndTime, Program As String, SimpleRefresh As Boolean)

            _RowIndex = RowIndex

            If _WeeklyDataSources Is Nothing Then

                _WeeklyDataSources = New Hashtable

            Else

                _WeeklyDataSources.Clear()

            End If

            LabelForm_VendorName.Text = VendorName
            LabelForm_ProgramData.Text = Program

            If _ViewModel IsNot Nothing AndAlso _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                LabelForm_Program.Visible = False
                LabelForm_ProgramData.Visible = False

            Else

                LabelForm_Program.Visible = True
                LabelForm_ProgramData.Visible = True

            End If

            If DaysAndTime IsNot Nothing Then

                LabelForm_DaysTimeData.Text = String.Empty

                If String.IsNullOrWhiteSpace(DaysAndTime.Days) = False Then

                    LabelForm_DaysTimeData.Text = DaysAndTime.Days

                End If

                If String.IsNullOrWhiteSpace(DaysAndTime.StartTime) = False Then

                    If LabelForm_DaysTimeData.Text = String.Empty Then

                        LabelForm_DaysTimeData.Text = DaysAndTime.StartTime

                    Else

                        LabelForm_DaysTimeData.Text &= " " & DaysAndTime.StartTime

                    End If

                End If

                If String.IsNullOrWhiteSpace(DaysAndTime.EndTime) = False Then

                    If LabelForm_DaysTimeData.Text = String.Empty Then

                        LabelForm_DaysTimeData.Text = DaysAndTime.EndTime

                    Else

                        If String.IsNullOrWhiteSpace(DaysAndTime.StartTime) = False Then

                            LabelForm_DaysTimeData.Text &= "-" & DaysAndTime.EndTime

                        Else

                            LabelForm_DaysTimeData.Text &= " " & DaysAndTime.EndTime

                        End If

                    End If

                End If

            Else

                LabelForm_DaysTimeData.Text = String.Empty

            End If

            LabelForm_Demo.Text = _Controller.MarketDetails_GetMeasurementTrendsDemo(_ViewModel)

            LabelForm_SourceData.Text = _ViewModel.Worksheet.RatingsServiceID.ToString

            RefreshGrid(SimpleRefresh)

        End Sub
        Public Sub RefreshGrid(SimpleRefresh As Boolean)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            If SimpleRefresh Then

                DataTable = CType(CType(DataGridViewForm_Trends.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable)

                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString)
                DataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString) = _ViewModel.MeasurementTrendsDataTable.Rows(0)(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString)

                DataGridViewForm_Trends.CurrentView.RefreshData()

                For Each GridColumn In DataGridViewForm_Trends.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.BestFit()

                Next

            Else

                LoadGrid()

            End If

        End Sub
        Private Function CreateButtonItem(Caption As String, EventHanlder As EventHandler, BeingGroup As Boolean, Optional Image As System.Drawing.Image = Nothing) As DevExpress.Utils.Menu.DXMenuItem

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(Caption, EventHanlder, Image)

            DXMenuItem.BeginGroup = BeingGroup

            CreateButtonItem = DXMenuItem

        End Function
        Protected Sub OnUndoRatingShareOverrideClick(sender As Object, e As EventArgs)

            _DetailsForm.MeasurementTrendsUndoRatingShareOverride(_RowIndex)

        End Sub
        Protected Sub OnUndoProgramOverrideClick(sender As Object, e As EventArgs)

            _DetailsForm.MeasurementTrendsUndoProgramOverride(_RowIndex)

        End Sub
        Protected Sub OnRatingChanged(Rating As Decimal)

            _DetailsForm.MeasurementTrendsRatingChanged(Rating)

        End Sub
        Protected Sub OnShareChanged(Share As Decimal)

            _DetailsForm.MeasurementTrendsShareChanged(Share)

        End Sub
        Protected Sub OnAQHChanged(AQH As Long)

            _DetailsForm.MeasurementTrendsAQHChanged(AQH)

        End Sub
        Protected Sub OnImpressionsChanged(Impressions As Long)

            _DetailsForm.MeasurementTrendsImpressionsChanged(Impressions)

        End Sub
        Private Function CreateNielsenBookLookUpEditControl() As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

            'objects
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            RepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

            RepositoryItemGridLookUpEdit.NullText = ""
            RepositoryItemGridLookUpEdit.DisplayMember = "Description"
            RepositoryItemGridLookUpEdit.ValueMember = "ID"

            RepositoryItemGridLookUpEdit.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
            RepositoryItemGridLookUpEdit.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    RepositoryItemGridLookUpEdit.DataSource = _ViewModel.WorksheetMarketNielsenTVBooks.ToList

                Else

                    RepositoryItemGridLookUpEdit.DataSource = _ViewModel.WorksheetMarketTrendNielsenTVBooks.ToList

                End If

            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                RepositoryItemGridLookUpEdit.DataSource = _ViewModel.WorksheetMarketNielsenRadioPeriods.ToList

            End If

            CreateNielsenBookLookUpEditControl = RepositoryItemGridLookUpEdit

        End Function
        Protected Sub OnBestFitAllColumns(sender As Object, e As EventArgs)

            For Each GridColumn In DataGridViewForm_Trends.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.BestFit()

            Next

        End Sub
        Private Sub RepositoryItemRating_EditValueChanged(sender As Object, e As EventArgs)

            If _Controller.MarketDetails_CheckShareValueAfterRatingChange(_ViewModel, CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue, _RowIndex, True) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(Me, "A rating override that recalculates Share over 100 cannot be allowed.")

                CType(sender, DevExpress.XtraEditors.SpinEdit).EditValue = CType(sender, DevExpress.XtraEditors.SpinEdit).OldEditValue

            End If

        End Sub
        'Private Sub RepositoryItemImpressions_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs)

        '    If _ParsingImpressionsValue = False Then

        '        If DataGridViewForm_Trends.CurrentView.ActiveEditor Is sender Then

        '            e.Value = CInt(Math.Round(e.Value * 1000, 0))

        '            _ParsingImpressionsValue = True

        '        Else

        '            e.Value = Math.Round(e.Value / 1000, 1)

        '        End If

        '        e.Handled = True

        '    Else

        '        _ParsingImpressionsValue = False

        '    End If

        'End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

            DataGridViewForm_Trends.CurrentView.CloseEditorForUpdating()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = System.Windows.Forms.CloseReason.UserClosing Then

                e.Cancel = True

                Me.Hide()

                _DetailsForm.MeasurementTrendsFormHiding()

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            _WeeklyDataSources = New Hashtable

            'RadioButtonForm_Hours.SecurityEnabled = False

            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen OrElse
                        _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    ButtonForm_ShowBreakout.SecurityEnabled = True

                    CheckBoxForm_ShowLeadInOut.SecurityEnabled = True
                    RadioButtonForm_Hours.SecurityEnabled = True
                    RadioButtonForm_QuarterHours.SecurityEnabled = True
                    DataGridViewForm_Breakouts.Enabled = True
                    ButtonForm_ExportBreakouts.SecurityEnabled = True
                    LabelForm_TimeSpan.Enabled = True

                    CheckBoxForm_ShowLeadInOut.Checked = True

                Else

                    ButtonForm_ShowBreakout.SecurityEnabled = False

                    CheckBoxForm_ShowLeadInOut.SecurityEnabled = False
                    RadioButtonForm_Hours.SecurityEnabled = False
                    RadioButtonForm_QuarterHours.SecurityEnabled = False
                    DataGridViewForm_Breakouts.Enabled = False
                    ButtonForm_ExportBreakouts.SecurityEnabled = False
                    LabelForm_TimeSpan.Enabled = False

                End If

            Else

                ButtonForm_ShowBreakout.SecurityEnabled = False
                CheckBoxForm_ShowLeadInOut.SecurityEnabled = False
                RadioButtonForm_Hours.SecurityEnabled = False
                RadioButtonForm_QuarterHours.SecurityEnabled = False
                DataGridViewForm_Breakouts.Enabled = False
                ButtonForm_ExportBreakouts.SecurityEnabled = False
                LabelForm_TimeSpan.Enabled = False

            End If

            If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                LabelForm_Copyright.Text = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            ElseIf _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                LabelForm_Copyright.Text = "Copyright © " & Now.Year.ToString & " Comscore"

            End If

            SetControlPropertySettings()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailMeasurementTrendsDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Trends_GridViewKeyDownEvent(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles DataGridViewForm_Trends.GridViewKeyDownEvent

            If e.KeyCode = System.Windows.Forms.Keys.Up Then

                DataGridViewForm_Trends.CurrentView.CloseEditorForUpdating()

                _DetailsForm.MeasurementTrendsMoveToNextLine(True)

            ElseIf e.KeyCode = System.Windows.Forms.Keys.Down Then

                DataGridViewForm_Trends.CurrentView.CloseEditorForUpdating()

                _DetailsForm.MeasurementTrendsMoveToNextLine(False)

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Trends.CustomColumnDisplayTextEvent

            'objects
            Dim HUTPUTBookID As Integer = 0
            Dim WorksheetMarketNielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook = Nothing
            Dim WorksheetMarketNielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing
            Dim NeilsenRadioPeriodID1 As Integer = 0
            Dim NeilsenRadioPeriodID2 As Integer = 0
            Dim NeilsenRadioPeriodID3 As Integer = 0
            Dim NeilsenRadioPeriodID4 As Integer = 0
            Dim NeilsenRadioPeriodID5 As Integer = 0

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString Then

                    If e.Value = 0 Then

                        e.DisplayText = ""

                    Else

                        If e.ListSourceRowIndex = 0 Then

                            If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                                HUTPUTBookID = DataGridViewForm_Trends.CurrentView.GetRowCellValue(DataGridViewForm_Trends.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString)

                                If HUTPUTBookID > 0 Then

                                    If _ViewModel.Worksheet.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                        WorksheetMarketNielsenTVBook = _ViewModel.WorksheetMarketNielsenTVBooks.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = HUTPUTBookID)

                                    Else

                                        WorksheetMarketNielsenTVBook = _ViewModel.WorksheetMarketTrendNielsenTVBooks.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = HUTPUTBookID)

                                    End If

                                    If WorksheetMarketNielsenTVBook IsNot Nothing Then

                                        e.DisplayText &= " / " & WorksheetMarketNielsenTVBook.Description

                                    End If

                                End If

                            ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                                e.DisplayText = e.DisplayText

                            End If

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString Then

                    If e.Value = 0 Then

                        e.DisplayText = ""

                    Else

                        If e.ListSourceRowIndex = 0 Then

                            NeilsenRadioPeriodID2 = DataGridViewForm_Trends.CurrentView.GetRowCellValue(DataGridViewForm_Trends.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString)

                            If NeilsenRadioPeriodID2 > 0 Then

                                WorksheetMarketNielsenRadioPeriod = _ViewModel.WorksheetMarketNielsenRadioPeriods.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = NeilsenRadioPeriodID2)

                                If WorksheetMarketNielsenRadioPeriod IsNot Nothing Then

                                    'If WorksheetMarketNielsenRadioPeriod.Month > 12 Then

                                    '    e.DisplayText &= " / " & AdvantageFramework.StringUtilities.RemoveAllNonAlpha(WorksheetMarketNielsenRadioPeriod.Description).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                    'Else

                                    '    e.DisplayText &= " / " & MonthName(WorksheetMarketNielsenRadioPeriod.Month, True).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                    'End If

                                    e.DisplayText &= " / " & WorksheetMarketNielsenRadioPeriod.Description

                                End If

                            End If

                            If NeilsenRadioPeriodID2 > 0 Then

                                NeilsenRadioPeriodID3 = DataGridViewForm_Trends.CurrentView.GetRowCellValue(DataGridViewForm_Trends.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString)

                                If NeilsenRadioPeriodID3 > 0 Then

                                    WorksheetMarketNielsenRadioPeriod = _ViewModel.WorksheetMarketNielsenRadioPeriods.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = NeilsenRadioPeriodID3)

                                    If WorksheetMarketNielsenRadioPeriod IsNot Nothing Then

                                        'If WorksheetMarketNielsenRadioPeriod.Month > 12 Then

                                        '    e.DisplayText &= " / " & AdvantageFramework.StringUtilities.RemoveAllNonAlpha(WorksheetMarketNielsenRadioPeriod.Description).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'Else

                                        '    e.DisplayText &= " / " & MonthName(WorksheetMarketNielsenRadioPeriod.Month, True).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'End If

                                        e.DisplayText &= " / " & WorksheetMarketNielsenRadioPeriod.Description

                                    End If

                                End If

                            End If

                            If NeilsenRadioPeriodID3 > 0 Then

                                NeilsenRadioPeriodID4 = DataGridViewForm_Trends.CurrentView.GetRowCellValue(DataGridViewForm_Trends.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString)

                                If NeilsenRadioPeriodID4 > 0 Then

                                    WorksheetMarketNielsenRadioPeriod = _ViewModel.WorksheetMarketNielsenRadioPeriods.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = NeilsenRadioPeriodID4)

                                    If WorksheetMarketNielsenRadioPeriod IsNot Nothing Then

                                        'If WorksheetMarketNielsenRadioPeriod.Month > 12 Then

                                        '    e.DisplayText &= " / " & AdvantageFramework.StringUtilities.RemoveAllNonAlpha(WorksheetMarketNielsenRadioPeriod.Description).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'Else

                                        '    e.DisplayText &= " / " & MonthName(WorksheetMarketNielsenRadioPeriod.Month, True).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'End If

                                        e.DisplayText &= " / " & WorksheetMarketNielsenRadioPeriod.Description

                                    End If

                                End If

                            End If

                            If NeilsenRadioPeriodID4 > 0 Then

                                NeilsenRadioPeriodID5 = DataGridViewForm_Trends.CurrentView.GetRowCellValue(DataGridViewForm_Trends.CurrentView.GetRowHandle(e.ListSourceRowIndex), AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString)

                                If NeilsenRadioPeriodID5 > 0 Then

                                    WorksheetMarketNielsenRadioPeriod = _ViewModel.WorksheetMarketNielsenRadioPeriods.FirstOrDefault(Function(WMNTVB) WMNTVB.ID = NeilsenRadioPeriodID5)

                                    If WorksheetMarketNielsenRadioPeriod IsNot Nothing Then

                                        'If WorksheetMarketNielsenRadioPeriod.Month > 12 Then

                                        '    e.DisplayText &= " / " & AdvantageFramework.StringUtilities.RemoveAllNonAlpha(WorksheetMarketNielsenRadioPeriod.Description).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'Else

                                        '    e.DisplayText &= " / " & MonthName(WorksheetMarketNielsenRadioPeriod.Month, True).ToUpper & WorksheetMarketNielsenRadioPeriod.Year.ToString.Substring(2)

                                        'End If

                                        e.DisplayText &= " / " & WorksheetMarketNielsenRadioPeriod.Description

                                    End If

                                End If

                            End If

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString Then

                    e.DisplayText = FormatNumber((e.Value / 1000), 1, TriState.True, TriState.False, TriState.True)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 1)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.CumeRating.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 1)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString Then

                    e.DisplayText = FormatNumber((e.Value / 100), 0, TriState.True, TriState.False, TriState.True)

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Cume.ToString Then

                    e.DisplayText = FormatNumber((e.Value / 100), 0, TriState.True, TriState.False, TriState.True)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_Trends.CustomColumnSortEvent

            e.Result = 0

            e.Handled = True

        End Sub
        Private Sub DataGridViewForm_Trends_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_Trends.PopupMenuShowingEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit

                            MenuItem.Visible = True

                        Case Else

                            MenuItem.Visible = False

                    End Select

                Next

                e.Menu.Items.Add(CreateButtonItem("Best Fit All Columns", New EventHandler(AddressOf OnBestFitAllColumns), False, Nothing))

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then

                If DataGridViewForm_Trends.CurrentView.IsDataRow(e.HitInfo.RowHandle) AndAlso _RowIndex > -1 Then

                    DataRow = CType(DataGridViewForm_Trends.CurrentView.GetRow(e.HitInfo.RowHandle), System.Data.DataRowView).Row

                    If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV AndAlso
                            _ViewModel.SelectedWorksheetMarket.SharebookNielsenTVBookID.GetValueOrDefault(0) > 0 Then

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString) OrElse
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookShare.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString) Then

                            e.Menu.Items.Add(CreateButtonItem("Undo Rating\Share Override", New EventHandler(AddressOf OnUndoRatingShareOverrideClick), False))

                        End If

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookProgram.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString) Then

                            e.Menu.Items.Add(CreateButtonItem("Undo Program Override", New EventHandler(AddressOf OnUndoProgramOverrideClick), True))

                        End If

                    ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio AndAlso
                            _ViewModel.SelectedWorksheetMarket.NeilsenRadioPeriodID1.GetValueOrDefault(0) > 0 Then

                        If DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQHRating.ToString) <> DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString) Then

                            e.Menu.Items.Add(CreateButtonItem("Undo Rating Override", New EventHandler(AddressOf OnUndoRatingShareOverrideClick), False))

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_Trends.RowCellStyleEvent

            If e.RowHandle = 0 Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookRating.ToString) <> e.CellValue Then

                            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookShare.ToString) <> e.CellValue Then

                            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Program.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookProgram.ToString) <> e.CellValue Then

                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookImpressions.ToString) <> e.CellValue Then

                            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    End If

                ElseIf _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotRadio Then

                    If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQHRating.ToString) <> e.CellValue Then

                            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString Then

                        If DataGridViewForm_Trends.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookAQH.ToString) <> e.CellValue Then

                            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
                            e.Appearance.ForeColor = System.Drawing.Color.Blue

                        End If

                    End If

                End If

            Else

                If DataGridViewForm_Trends.CurrentView.GetMasterRowExpanded(e.RowHandle) Then

                    e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_Trends.CustomDrawCellEvent

            'objects
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim IsMasterRowEmpty As Boolean = False

            GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

            If e.Column.VisibleIndex = 0 AndAlso GridView.OptionsDetail.SmartDetailExpandButtonMode <> DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled Then

                If (GridView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails) Then

                    IsMasterRowEmpty = GridView.IsMasterRowEmptyEx(e.RowHandle, 0)

                Else

                    IsMasterRowEmpty = GridView.IsMasterRowEmpty(e.RowHandle)

                End If

                If IsMasterRowEmpty Then

                    CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).CellButtonRect = System.Drawing.Rectangle.Empty

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_Trends.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.99
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.EditValueChangedDelay = 10000
                RepositoryItemSpinEdit.Buttons.Clear()

                AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemRating_EditValueChanged

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.99
                RepositoryItemSpinEdit.MaxLength = 5
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "f1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "f1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "f1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "f1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 99.9
                RepositoryItemSpinEdit.MaxLength = 4
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n1"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n1"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n1"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n1"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999999
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                'AddHandler RepositoryItemSpinEdit.ParseEditValue, AddressOf RepositoryItemImpressions_ParseEditValue

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "n0"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "n0"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "n0"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "n0"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = False
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999999
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HPUTBookID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID1.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID2.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID3.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID4.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.NeilsenRadioPeriodID5.ToString Then

                e.RepositoryItem = CreateNielsenBookLookUpEditControl()

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Trends.ShowingEditorEvent

            If DataGridViewForm_Trends.CurrentView.FocusedRowHandle <> 0 Then

                e.Cancel = True

            Else

                If _RowIndex < 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_ColumnValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Trends.ColumnValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Rating.ToString Then

                OnRatingChanged(e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Share.ToString Then

                OnShareChanged(e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQHRating.ToString Then

                OnRatingChanged(e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.AQH.ToString Then

                OnAQHChanged(e.Value)

            ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.Impressions.ToString Then

                OnImpressionsChanged(e.Value)

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_ColumnWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles DataGridViewForm_Trends.ColumnWidthChangedEvent

            If _GridViewMeasurementTrendDetails IsNot Nothing Then

                If _GridViewMeasurementTrendDetails.Columns.ColumnByFieldName(e.Column.FieldName) IsNot Nothing Then

                    _GridViewMeasurementTrendDetails.Columns(e.Column.FieldName).Width = e.Column.Width

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString Then

                    _GridViewMeasurementTrendDetails.Columns(AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Book.ToString).Width = e.Column.Width

                ElseIf e.Column.FieldName = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString Then

                    _GridViewMeasurementTrendDetails.Columns(AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.HPUT.ToString).Width = e.Column.Width

                End If

            End If

        End Sub
        Private Sub _GridViewMeasurementTrendDetails_ColumnWidthChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles _GridViewMeasurementTrendDetails.ColumnWidthChanged

            If DataGridViewForm_Trends.Columns.ColumnByFieldName(e.Column.FieldName) IsNot Nothing Then

                DataGridViewForm_Trends.Columns(e.Column.FieldName).Width = e.Column.Width

            ElseIf e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Book.ToString Then

                DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.BookID.ToString).Width = e.Column.Width

            ElseIf e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.HPUT.ToString Then

                DataGridViewForm_Trends.Columns(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetails_MeasurementTrendsColumns.HUTPUT.ToString).Width = e.Column.Width

            End If

        End Sub
        Private Sub _BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            e.Result = _Controller.MarketDetails_RefreshsMeasurementTrendsDataTableDefaultRows(_ViewModel, _RowIndex)

        End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            DataGridViewForm_Trends.CurrentView.BeginUpdate()

            DataGridViewForm_Trends.CurrentView.CollapseAllDetails()

            DataGridViewForm_Trends.DataSource = CType(e.Result, System.Data.DataTable)

            If _HasGridBeenFormatted = False Then

                FormatGrid()

                _HasGridBeenFormatted = True

            End If

            DataGridViewForm_Trends.CurrentView.EndUpdate()

            For Each GridColumn In DataGridViewForm_Trends.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.BestFit()

            Next

            DataGridViewForm_Trends.CurrentView.LoadingPanelVisible = False

            If DataGridViewForm_Trends.CurrentView.RowCount > 0 Then

                DataGridViewForm_Trends.GridViewSelectionChanged()

            End If

            If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                If DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.HPUT.ToString) IsNot Nothing Then

                    DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.HPUT.ToString).Caption = "SIU"

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_Trends.MasterRowEmptyEvent

            If e.RowHandle > 0 Then

                If _ViewModel.Worksheet.MediaType = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes.SpotTV Then

                    If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen OrElse
                            _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        e.IsEmpty = False

                    Else

                        e.IsEmpty = True

                    End If

                Else

                    e.IsEmpty = True

                End If

            Else

                e.IsEmpty = True

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_Trends.MasterRowGetChildListEvent

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim MeasurementTrendRowIndex As Integer = 0
            Dim MeasurementTrendDetails As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail) = Nothing
            Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

            If e.RowHandle > 0 Then

                OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Trends, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.RefreshImage, Nothing)

                BindingSource = New System.Windows.Forms.BindingSource

                MeasurementTrendRowIndex = e.RowHandle

                If _WeeklyDataSources.ContainsKey(MeasurementTrendRowIndex) Then

                    MeasurementTrendDetails = _WeeklyDataSources(MeasurementTrendRowIndex)

                Else

                    MeasurementTrendDetails = _Controller.MarketDetails_LoadMeasurementTrendsDetails(_ViewModel, _RowIndex, MeasurementTrendRowIndex)

                    _WeeklyDataSources(MeasurementTrendRowIndex) = MeasurementTrendDetails

                End If

                BindingSource.DataSource = MeasurementTrendDetails

                e.ChildList = BindingSource

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_Trends.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_Trends.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "MeasurementTrendDetails"

            End Select

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_Trends.MasterRowExpandedEvent

            'objects
            'Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            'BaseView = DataGridViewForm_Trends.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            'If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

            'BaseView.BestFitColumns()
            ' DataGridViewForm_Trends.CurrentView.BestFitColumns()

            For Each GridColumn In DataGridViewForm_Trends.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.BestFit()

            Next

            'End If

        End Sub
        Private Sub DataGridViewForm_Trends_MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewForm_Trends.MasterRowGetLevelDefaultViewEvent

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewMeasurementTrendDetails

            End Select

        End Sub
        Private Sub DataGridViewForm_Trends_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Trends.FocusedRowChangedEvent

            'objects
            Dim LeadInLeadOutParameters As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutParameters = Nothing
            Dim MeasurementTrendsRowIndex As Integer = 0

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso e.FocusedRowHandle >= 0 AndAlso DataGridViewForm_Trends.HasOnlyOneSelectedRow AndAlso
                    DataGridViewForm_Trends.CurrentView.LoadingPanelVisible = False AndAlso (_BackgroundWorker Is Nothing OrElse (_BackgroundWorker IsNot Nothing AndAlso _BackgroundWorker.IsBusy = False)) Then

                _PreviousRowHandle = e.FocusedRowHandle

                DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)

            Else

                DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)

            End If

        End Sub
        Private Sub _GridViewMeasurementTrendDetails_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles _GridViewMeasurementTrendDetails.CustomColumnDisplayText

            If e.Column IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Impressions.ToString Then

                    e.DisplayText = FormatNumber((e.Value / 1000), 1, TriState.True, TriState.False, TriState.True)

                ElseIf e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Rating.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.Share.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                ElseIf e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail.Properties.HPUT.ToString Then

                    e.DisplayText = FormatNumber(e.Value, 2)

                End If

            End If

        End Sub
        Private Sub _GridViewMeasurementTrendDetails_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles _GridViewMeasurementTrendDetails.FocusedRowChanged

            'objects
            Dim LeadInLeadOutParameters As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutParameters = Nothing
            Dim MeasurementTrendsRowIndex As Integer = 0

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso e.FocusedRowHandle >= 0 AndAlso DataGridViewForm_Trends.HasOnlyOneSelectedRow AndAlso
                    DataGridViewForm_Trends.CurrentView.LoadingPanelVisible = False AndAlso (_BackgroundWorker Is Nothing OrElse (_BackgroundWorker IsNot Nothing AndAlso _BackgroundWorker.IsBusy = False)) Then

                _TrendPreviousRowHandle = e.FocusedRowHandle

                DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)

            Else

                DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)

            End If

        End Sub
        Private Sub CheckBoxForm_ShowLeadInOut_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_ShowLeadInOut.CheckedChanged

            'objects
            Dim FocusedRowHandle As Integer = 0

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle) IsNot Nothing AndAlso
                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle > 0 Then

                    FocusedRowHandle = CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                    If FocusedRowHandle = 0 Then

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = 1

                    Else

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle - 1

                    End If

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle

                ElseIf DataGridViewForm_Trends.CurrentView.FocusedRowHandle > -1 Then

                    DataGridViewForm_Trends.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_QuarterHours_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_QuarterHours.CheckedChanged

            'objects
            Dim FocusedRowHandle As Integer = 0

            If RadioButtonForm_QuarterHours.Checked Then

                If DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle) IsNot Nothing AndAlso
                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle > 0 Then

                    FocusedRowHandle = CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                    If FocusedRowHandle = 0 Then

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = 1

                    Else

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle - 1

                    End If

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle

                ElseIf DataGridViewForm_Trends.CurrentView.FocusedRowHandle > -1 Then

                    DataGridViewForm_Trends.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_Hours_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Hours.CheckedChanged

            'objects
            Dim FocusedRowHandle As Integer = 0

            If RadioButtonForm_Hours.Checked Then

                If DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle) IsNot Nothing AndAlso
                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle > 0 Then

                    FocusedRowHandle = CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Refreshing

                    If FocusedRowHandle = 0 Then

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = 1

                    Else

                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle - 1

                    End If

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle = FocusedRowHandle

                ElseIf DataGridViewForm_Trends.CurrentView.FocusedRowHandle > -1 Then

                    DataGridViewForm_Trends.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonForm_ExportTrends_Click(sender As Object, e As EventArgs) Handles ButtonForm_ExportTrends.Click

            For Each GridColumn In DataGridViewForm_Trends.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.RealColumnEdit IsNot Nothing Then

                    GridColumn.RealColumnEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                End If

            Next

            For Each GridColumn In _GridViewMeasurementTrendDetails.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.RealColumnEdit IsNot Nothing Then

                    GridColumn.RealColumnEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                End If

            Next

            Me.TopMost = False

            DataGridViewForm_Trends.Print(_Controller.Session, Me.DefaultLookAndFeel.LookAndFeel, "Trends")

            Me.TopMost = True

        End Sub
        Private Sub ButtonForm_ExportBreakouts_Click(sender As Object, e As EventArgs) Handles ButtonForm_ExportBreakouts.Click

            If DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Impressions.ToString) IsNot Nothing Then

                DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Impressions.ToString).ColumnEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            End If

            Me.TopMost = False

            DataGridViewForm_Breakouts.Print(_Controller.Session, Me.DefaultLookAndFeel.LookAndFeel, "Breakouts")

            Me.TopMost = True

        End Sub
        Private Sub DataGridViewForm_Breakouts_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Breakouts.CustomColumnDisplayTextEvent

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Impressions.ToString Then

                e.DisplayText = FormatNumber((e.Value / 1000), 1, TriState.True, TriState.False, TriState.True)

            End If

        End Sub
        Private Sub DataGridViewForm_Trends_RowClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_Trends.RowClickEvent

            If e.Button = Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 1 AndAlso e.RowHandle = _PreviousRowHandle Then

                DataGridViewForm_Trends.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_ShowBreakout_Click(sender As Object, e As EventArgs) Handles ButtonForm_ShowBreakout.Click

            'objects
            Dim LeadInLeadOutParameters As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutParameters = Nothing
            Dim MeasurementTrendsRowIndex As Integer = 0
            Dim Week As Integer = 0
            Dim WeekDate As Date = Date.MinValue
            Dim FocusedRowHandle As Integer = 0
            Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
            Dim MeasurementTrendDetail As AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail = Nothing

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewForm_Trends.HasOnlyOneSelectedRow AndAlso
                    DataGridViewForm_Trends.CurrentView.LoadingPanelVisible = False AndAlso (_BackgroundWorker Is Nothing OrElse (_BackgroundWorker IsNot Nothing AndAlso _BackgroundWorker.IsBusy = False)) Then

                MeasurementTrendsRowIndex = DataGridViewForm_Trends.CurrentView.GetDataSourceRowIndex(DataGridViewForm_Trends.CurrentView.FocusedRowHandle)

                If DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle) IsNot Nothing AndAlso
                        CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle > 0 Then

                    FocusedRowHandle = CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).FocusedRowHandle
                    MeasurementTrendDetail = CType(DataGridViewForm_Trends.CurrentView.GetVisibleDetailView(DataGridViewForm_Trends.CurrentView.FocusedRowHandle), DevExpress.XtraGrid.Views.Grid.GridView).GetFocusedRow

                    Week = FocusedRowHandle + 1
                    WeekDate = MeasurementTrendDetail.WeekDate

                End If

                LeadInLeadOutParameters = _Controller.MarketDetails_CreateLeadInLeadOutParameters(_ViewModel, _RowIndex, MeasurementTrendsRowIndex, Week, CheckBoxForm_ShowLeadInOut.Checked, RadioButtonForm_QuarterHours.Checked)

                If LeadInLeadOutParameters IsNot Nothing Then

                    OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Breakouts, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

                    ButtonForm_ShowBreakout.Enabled = False
                    CheckBoxForm_ShowLeadInOut.Enabled = False
                    RadioButtonForm_Hours.Enabled = False
                    RadioButtonForm_QuarterHours.Enabled = False

                    Try

                        DataGridViewForm_Breakouts.DataSource = _Controller.MarketDetails_LoadLeadInLeadOutDetails(_ViewModel.Worksheet.RatingsServiceID, LeadInLeadOutParameters)

                    Catch ex As Exception
                        DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)
                    End Try

                    ButtonForm_ShowBreakout.Enabled = True
                    CheckBoxForm_ShowLeadInOut.Enabled = True
                    RadioButtonForm_Hours.Enabled = True
                    RadioButtonForm_QuarterHours.Enabled = True

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                Else

                    DataGridViewForm_Breakouts.DataSource = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary)

                End If

                DataGridViewForm_Breakouts.MakeColumnVisible(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Rating.ToString)
                DataGridViewForm_Breakouts.MakeColumnVisible(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Share.ToString)
                DataGridViewForm_Breakouts.MakeColumnVisible(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.HPUT.ToString)
                DataGridViewForm_Breakouts.MakeColumnVisible(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.Impressions.ToString)

                If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    If DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.HPUT.ToString) IsNot Nothing Then

                        DataGridViewForm_Breakouts.Columns(AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutSummary.Properties.HPUT.ToString).Caption = "SIU"

                    End If

                End If

                DataGridViewForm_Breakouts.CurrentView.BestFitColumns()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
