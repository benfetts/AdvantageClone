Namespace Reporting.Presentation

    Public Class MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum BuyType
            Pre
            Post
        End Enum

        Public Enum MediaType
            TV
            Radio
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Reporting.MediaBroadcastWorksheetCriteriaViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Reporting.MediaBroadcastWorksheetCriteriaController = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Pre
        Private _MediaBroadcastWorksheetID As Integer? = Nothing
        Private _MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV
        Private _IsPuertoRico As Boolean = False
        Private _ShowOmitRatings As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ParameterDictionary As Generic.Dictionary(Of String, Object), MediaBroadcastWorksheetPrePostReportCriteriaBuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType,
                        MediaBroadcastWorksheetPrePostReportCriteriaMediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType,
                        MediaBroadcastWorksheetID As Integer, IsPuertoRico As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = MediaBroadcastWorksheetPrePostReportCriteriaBuyType
            _MediaBroadcastWorksheetPrePostReportCriteriaMediaType = MediaBroadcastWorksheetPrePostReportCriteriaMediaType
            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _IsPuertoRico = IsPuertoRico

            If _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Post Then

                Me.Text = "Broadcast Worksheet Post Buy Criteria"

            End If

        End Sub
        Private Sub New(DynamicReport As AdvantageFramework.Reporting.DynamicReports, BuyType As BuyType, MediaType As MediaType, ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport
            _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = BuyType
            _MediaBroadcastWorksheetPrePostReportCriteriaMediaType = MediaType
            _ShowOmitRatings = True

            If _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Post Then

                Me.Text = "Broadcast Worksheet Post Buy Criteria"

            End If

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim SubItemDateInput As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput = Nothing
            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim VisibleIndex As Integer = 0

            If LoadGrid Then

                DataGridViewForm_Markets.DataSource = _ViewModel.MediaBroadcastWorksheetMarketBooksPreBuy
                DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketVendors

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

                End Using

                For Each GridColumn In DataGridViewForm_Markets.CurrentView.Columns

                    If (GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.WorksheetName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.Division.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.DivisionName.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.Product.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ProductName.ToString) AndAlso
                                _MediaBroadcastWorksheetID.HasValue Then

                        GridColumn.Visible = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.IsCable.ToString Then

                        GridColumn.Visible = (_IsPuertoRico = False AndAlso _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV)

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                        If _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                            If _IsPuertoRico = False Then

                                SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                                SubItemGridLookUpEditControl.DataSource = _ViewModel.RepositoryNielsenTVBooks

                                If SubItemGridLookUpEditControl.View.Columns.ColumnByFieldName("ID") IsNot Nothing Then

                                    SubItemGridLookUpEditControl.View.Columns.ColumnByFieldName("ID").Visible = False

                                End If

                                If GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString AndAlso
                                        _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Pre Then

                                    GridColumn.Caption = "Pre Buy Share Book"

                                End If

                                If GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                                    GridColumn.Visible = (_MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Pre)

                                    If _ViewModel.MediaBroadcastWorksheet IsNot Nothing AndAlso
                                            _ViewModel.MediaBroadcastWorksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                        GridColumn.Caption = "SIU"

                                    End If

                                End If

                            Else

                                GridColumn.Visible = False

                            End If

                        ElseIf _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString Then

                        GridColumn.Visible = (_IsPuertoRico = True AndAlso _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV AndAlso
                                              _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Pre)

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString Then

                        If _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                            GridColumn.Visible = False

                        ElseIf _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Post Then

                            GridColumn.Caption = "Override Post Book"

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString Then

                        If _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV OrElse
                                _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Post Then

                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.UseImpressions.ToString Then

                        If _DynamicReport = Nothing OrElse _DynamicReport = 0 Then

                            If _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                                GridColumn.Caption = "Use AQH (00)"

                            End If

                        Else

                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString Then

                        SubItemDateInput = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput)
                        SubItemDateInput.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput.Type.Broadcast
                        SubItemDateInput.BroadcastCalendarWeeks = BroadcastCalendarWeeks

                        AddHandler SubItemDateInput.DisableCalendarDate, AddressOf StartDate_DisableCalendarDate

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString Then

                        SubItemDateInput = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput)
                        SubItemDateInput.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemDateInput.Type.Broadcast
                        SubItemDateInput.BroadcastCalendarWeeks = BroadcastCalendarWeeks

                        AddHandler SubItemDateInput.DisableCalendarDate, AddressOf EndDate_DisableCalendarDate

                    End If

                Next

                If DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString) IsNot Nothing AndAlso
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString).Visible AndAlso
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString) IsNot Nothing AndAlso
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString).Visible AndAlso
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString).VisibleIndex <=
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString).VisibleIndex Then

                    DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString).VisibleIndex =
                        DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString).VisibleIndex + 1

                End If

                DataGridViewForm_Markets.SelectAll()
                DataGridViewForm_Vendors.SelectAll()

            Else

                DataGridViewForm_Markets.CurrentView.RefreshData()
                DataGridViewForm_Vendors.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub StartDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

            'objects
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            Try

                MediaBroadcastWorksheetMarketBook = DataGridViewForm_Markets.CurrentView.GetFocusedRow

            Catch ex As Exception
                MediaBroadcastWorksheetMarketBook = Nothing
            End Try

            If e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                If MediaBroadcastWorksheetMarketBook IsNot Nothing Then

                    If e.Date < MediaBroadcastWorksheetMarketBook.WorksheetStartDate Then

                        e.IsDisabled = True

                    ElseIf e.Date > MediaBroadcastWorksheetMarketBook.WorksheetEndDate Then

                        e.IsDisabled = True

                    Else

                        If e.Date = MediaBroadcastWorksheetMarketBook.WorksheetStartDate Then

                            e.IsDisabled = False

                        ElseIf e.Date = MediaBroadcastWorksheetMarketBook.WorksheetEndDate Then

                            e.IsDisabled = False

                        Else

                            If e.Date.DayOfWeek = DayOfWeek.Monday Then

                                e.IsDisabled = False

                            Else

                                e.IsDisabled = True

                            End If

                        End If

                    End If

                Else

                    If e.Date.DayOfWeek = DayOfWeek.Monday Then

                        e.IsDisabled = False

                    Else

                        e.IsDisabled = True

                    End If

                End If

            End If

        End Sub
        Private Sub EndDate_DisableCalendarDate(sender As Object, e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

            'objects
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            Try

                MediaBroadcastWorksheetMarketBook = DataGridViewForm_Markets.CurrentView.GetFocusedRow

            Catch ex As Exception
                MediaBroadcastWorksheetMarketBook = Nothing
            End Try

            If e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                If MediaBroadcastWorksheetMarketBook IsNot Nothing Then

                    If e.Date < MediaBroadcastWorksheetMarketBook.WorksheetStartDate Then

                        e.IsDisabled = True

                    ElseIf e.Date > MediaBroadcastWorksheetMarketBook.WorksheetEndDate Then

                        e.IsDisabled = True

                    Else

                        If e.Date = MediaBroadcastWorksheetMarketBook.WorksheetStartDate Then

                            e.IsDisabled = False

                        ElseIf e.Date = MediaBroadcastWorksheetMarketBook.WorksheetEndDate Then

                            e.IsDisabled = False

                        Else

                            If e.Date.DayOfWeek = DayOfWeek.Sunday Then

                                e.IsDisabled = False

                            Else

                                e.IsDisabled = True

                            End If

                        End If

                    End If

                Else

                    If e.Date.DayOfWeek = DayOfWeek.Sunday Then

                        e.IsDisabled = False

                    Else

                        e.IsDisabled = True

                    End If

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object), BuyType As BuyType, MediaType As MediaType, MediaBroadcastWorksheetID As Integer, IsPuertoRico As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog = Nothing

            MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog(ParameterDictionary, BuyType, MediaType, MediaBroadcastWorksheetID, IsPuertoRico)

            ShowFormDialog = MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ParameterDictionary

            End If

        End Function
        Public Shared Function ShowFormDialog(DynamicReport As AdvantageFramework.Reporting.DynamicReports, BuyType As BuyType, MediaType As MediaType, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog = Nothing

            MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog(DynamicReport, BuyType, MediaType, ParameterDictionary)

            ShowFormDialog = MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Modifying

        End Sub
        Private Sub MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Point As System.Drawing.Point = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            'DateTimePickerStartDateRange_FromDate.Value = DateSerial(Now.Year, 1, 1)
            'DateTimePickerStartDateRange_ToDate.Value = DateSerial(Now.Year, 12, 31)

            DataGridViewForm_Markets.ShowSelectDeselectAllButtons = True
            DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = True

            'DateTimePickerStartDateRange_FromDate.Enabled = False
            'DateTimePickerStartDateRange_ToDate.Enabled = False

            If Not _MediaBroadcastWorksheetID.HasValue Then

                DataGridViewForm_Markets.ItemDescription = "Worksheet / Markets"

            End If

            _Controller = New AdvantageFramework.Controller.Reporting.MediaBroadcastWorksheetCriteriaController(Me.Session)

            If _MediaBroadcastWorksheetID.HasValue Then

                _ViewModel = _Controller.Load(_MediaBroadcastWorksheetID.Value, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, _MediaBroadcastWorksheetPrePostReportCriteriaMediaType)

                Point = New System.Drawing.Point(12, 12)

                DataGridViewForm_Markets.Location = Point
                DataGridViewForm_Markets.Height += 55

            Else

                _ViewModel = _Controller.Load(_MediaBroadcastWorksheetPrePostReportCriteriaBuyType, _MediaBroadcastWorksheetPrePostReportCriteriaMediaType)

                SearchableComboBoxForm_Client.DataSource = _ViewModel.Clients
                SearchableComboBoxForm_Client.SetRequired(True)

                ComboBoxForm_Source.DataSource = _ViewModel.RatingsServiceList
                ComboBoxForm_Source.SetRequired(True)

            End If

        End Sub
        Private Sub MediaBroadcastWorksheetPrePostBuyInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CheckBoxForm_OmitRatings.Visible = _ShowOmitRatings

            RefreshViewModel(True)

            DataGridViewForm_Markets.CurrentView.BestFitColumns()
            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

            DataGridViewForm_Markets.SelectAll()
            DataGridViewForm_Vendors.SelectAll()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim AllMediaBroadcastWorksheetMarketBooks As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
            Dim MediaBroadcastWorksheetMarketBooks As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing
            Dim WorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor) = Nothing

            DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_Markets.HasASelectedRow Then

                If Not Me.DataGridViewForm_Markets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).Where(Function(Entity) Entity.HasError).Any Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    AllMediaBroadcastWorksheetMarketBooks = DataGridViewForm_Markets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).ToList
                    WorksheetMarketVendors = DataGridViewForm_Vendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor).ToList

                    MediaBroadcastWorksheetMarketBooks = New Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

                    For Each WorksheetMarketVendor In WorksheetMarketVendors

                        If MediaBroadcastWorksheetMarketBooks.Any(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = WorksheetMarketVendor.MediaBroadcastWorksheetMarketID) = False Then

                            Try

                                MediaBroadcastWorksheetMarketBook = AllMediaBroadcastWorksheetMarketBooks.SingleOrDefault(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = WorksheetMarketVendor.MediaBroadcastWorksheetMarketID)

                            Catch ex As Exception
                                MediaBroadcastWorksheetMarketBook = Nothing
                            End Try

                            If MediaBroadcastWorksheetMarketBook IsNot Nothing Then

                                If MediaBroadcastWorksheetMarketBooks.Any(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketBook.MediaBroadcastWorksheetMarketID) = False Then

                                    MediaBroadcastWorksheetMarketBooks.Add(MediaBroadcastWorksheetMarketBook)

                                End If

                            End If

                        End If

                    Next

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.Session.ToString) = Me.Session
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.MediaBroadcastWorksheetMarketBooks.ToString) = MediaBroadcastWorksheetMarketBooks
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString) = WorksheetMarketVendors
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.OmitRatings.ToString) = (CheckBoxForm_OmitRatings.Visible AndAlso CheckBoxForm_OmitRatings.Checked)

                    _Controller.SaveCriteria(DataGridViewForm_Markets.GetAllRowsDataBoundItems.OfType(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).ToList, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, _MediaBroadcastWorksheetPrePostReportCriteriaMediaType)

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid for selected rows.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one market in the grid.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonForm_Refresh.Click

            Dim ClientCode As String = ""
            Dim StartDate As Date? = Nothing
            Dim EndDate As Date? = Nothing
            Dim MarketsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
            Dim VendorsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
            Dim RatingServiceID As Integer = 0

            If Me.FormShown Then

                StartDate = DateTimePickerStartDateRange_FromDate.GetValue
                EndDate = DateTimePickerStartDateRange_ToDate.GetValue

                If SearchableComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Source.HasASelectedValue AndAlso StartDate.HasValue AndAlso EndDate.HasValue Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

                    MarketsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Markets, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)
                    VendorsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Vendors, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

                    System.Windows.Forms.Application.DoEvents()

                    ClientCode = SearchableComboBoxForm_Client.GetSelectedValue

                    RatingServiceID = ComboBoxForm_Source.GetSelectedValue()

                    _Controller.GetMediaBroadcastWorksheetMarketBooks(ClientCode, StartDate, EndDate, _ViewModel, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, RatingServiceID)

                    RefreshViewModel(True)

                    DataGridViewForm_Markets.CurrentView.BestFitColumns()
                    DataGridViewForm_Vendors.CurrentView.BestFitColumns()

                    DataGridViewForm_Markets.SelectAll()
                    DataGridViewForm_Vendors.SelectAll()

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(MarketsOverlaySplayScreenHandle)
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(VendorsOverlaySplayScreenHandle)

                    DataGridViewForm_Markets.CurrentView.LoadingPanelVisible = False
                    DataGridViewForm_Vendors.CurrentView.LoadingPanelVisible = False

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please pick Source, Client, From Date and To Date.")

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Markets.QueryPopupNeedDatasourceEvent

            'objects
            Dim ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing
            Dim ShareBookID As Nullable(Of Integer) = Nothing

            If FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString Then

                If _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    Datasource = _Controller.GetRepositorySecondaryDemographics(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook))
                    OverrideDefaultDatasource = True

                ElseIf _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    Datasource = _Controller.GetRadioRepositorySecondaryDemographics(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook))
                    OverrideDefaultDatasource = True

                End If

                'ElseIf Not _ViewModel.BypassLoadingYearMonthRepository AndAlso (FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.BroadcastStartYearMonth.ToString OrElse
                '        FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.BroadcastEndYearMonth.ToString) Then

                '    Datasource = _Controller.GetRepositoryYearMonths(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook))
                '    OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                If FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                    ShareBookID = DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook).ShareBookID

                End If

                Datasource = _Controller.GetRepositoryNielsenTVBooks(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ShareBookID)
                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString))

                Datasource = _Controller.GetRepositoryNielsenRadioPeriods(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString))

                Datasource = _Controller.GetRepositoryNielsenRadioPeriods(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString))

                Datasource = _Controller.GetRepositoryNielsenRadioPeriods(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString))

                Datasource = _Controller.GetRepositoryNielsenRadioPeriods(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            ElseIf FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString Then

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString))
                ExcludeNielsenRadioPeriodIDs.Add(DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString))

                Datasource = _Controller.GetRepositoryNielsenRadioPeriods(DirectCast(DataGridViewForm_Markets.CurrentView.GetRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle), DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook), ExcludeNielsenRadioPeriodIDs)

                DirectCast(DataGridViewForm_Markets.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewForm_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                Datasource = _ViewModel.RepositoryNielsenTVBooks

            ElseIf _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV AndAlso
                    (FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PrimaryMediaDemographicID.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString) Then

                Datasource = _ViewModel.RepositoryMediaDemographics

            ElseIf _ViewModel.MediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio AndAlso
                    (FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PrimaryMediaDemographicID.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString) Then

                Datasource = _ViewModel.RepositoryRadioMediaDemographics

            ElseIf FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString OrElse
                    FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString Then

                Datasource = _ViewModel.RepositoryNielsenRadioBooks

                'ElseIf FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.BroadcastStartYearMonth.ToString OrElse
                '        FieldName = DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.BroadcastEndYearMonth.ToString Then

                '    Datasource = _ViewModel.RepositoryYearMonths

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Markets.ShowingEditorEvent

            If DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PrimaryMediaDemographicID.ToString Then

                e.Cancel = True

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString) = 0 Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString) = 0 Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString) = 0 Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString) = 0 Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString Then

                If DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString) = Nothing OrElse
                        DataGridViewForm_Markets.CurrentView.GetFocusedRowCellValue(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString) = 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Markets.ShownEditorEvent

            'objects
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            If DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString OrElse
                    DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString Then

                If DataGridViewForm_Markets.CurrentView.ActiveEditor IsNot Nothing AndAlso TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

                    Try

                        MediaBroadcastWorksheetMarketBook = DataGridViewForm_Markets.CurrentView.GetFocusedRow

                    Catch ex As Exception
                        MediaBroadcastWorksheetMarketBook = Nothing
                    End Try

                    If MediaBroadcastWorksheetMarketBook IsNot Nothing Then

                        CType(DataGridViewForm_Markets.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = MediaBroadcastWorksheetMarketBook.WorksheetStartDate
                        CType(DataGridViewForm_Markets.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MaxValue = MediaBroadcastWorksheetMarketBook.WorksheetEndDate

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Markets.SelectionChangedEvent

            'objects
            Dim MediaBroadcastWorksheetMarketIDs As Generic.List(Of Integer) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_Markets.HasASelectedRow Then

                    MediaBroadcastWorksheetMarketIDs = DataGridViewForm_Markets.GetAllSelectedRowsBookmarkValues(1).OfType(Of Integer).ToList

                Else

                    MediaBroadcastWorksheetMarketIDs = New Generic.List(Of Integer)

                End If

                _Controller.GetVendors(_ViewModel, MediaBroadcastWorksheetMarketIDs)

                DataGridViewForm_Vendors.DataSource = _ViewModel.WorksheetMarketVendors

                DataGridViewForm_Vendors.CurrentView.BestFitColumns()

                DataGridViewForm_Vendors.SelectAll()

            End If

        End Sub
        'Private Sub DateTimePickerStartDateRange_FromDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartDateRange_FromDate.ValueChanged

        '    Dim ClientCode As String = ""
        '    Dim StartDate As Date = Date.MinValue
        '    Dim EndDate As Date = Date.MinValue
        '    Dim MarketsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim VendorsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim RatingServiceID As Integer = 0

        '    If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

        '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

        '        MarketsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Markets, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)
        '        VendorsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Vendors, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

        '        System.Windows.Forms.Application.DoEvents()

        '        ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
        '        StartDate = DateTimePickerStartDateRange_FromDate.GetValue
        '        EndDate = DateTimePickerStartDateRange_ToDate.GetValue
        '        RatingServiceID = ComboBoxForm_Source.GetSelectedValue()

        '        _Controller.GetMediaBroadcastWorksheetMarketBooks(ClientCode, StartDate, EndDate, _ViewModel, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, RatingServiceID)

        '        Try

        '            RefreshViewModel(True)

        '        Catch ex As Exception

        '        End Try

        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(MarketsOverlaySplayScreenHandle)
        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(VendorsOverlaySplayScreenHandle)

        '        DataGridViewForm_Markets.CurrentView.LoadingPanelVisible = False
        '        DataGridViewForm_Vendors.CurrentView.LoadingPanelVisible = False

        '        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        '    End If

        'End Sub
        'Private Sub DateTimePickerStartDateRange_ToDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartDateRange_ToDate.ValueChanged

        '    Dim ClientCode As String = ""
        '    Dim StartDate As Date = Date.MinValue
        '    Dim EndDate As Date = Date.MinValue
        '    Dim MarketsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim VendorsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim RatingServiceID As Integer = 0

        '    If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

        '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

        '        MarketsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Markets, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)
        '        VendorsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Vendors, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

        '        System.Windows.Forms.Application.DoEvents()

        '        ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
        '        StartDate = DateTimePickerStartDateRange_FromDate.GetValue
        '        EndDate = DateTimePickerStartDateRange_ToDate.GetValue
        '        RatingServiceID = ComboBoxForm_Source.GetSelectedValue()

        '        _Controller.GetMediaBroadcastWorksheetMarketBooks(ClientCode, StartDate, EndDate, _ViewModel, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, RatingServiceID)

        '        Try

        '            RefreshViewModel(True)

        '        Catch ex As Exception

        '        End Try

        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(MarketsOverlaySplayScreenHandle)
        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(VendorsOverlaySplayScreenHandle)

        '        DataGridViewForm_Markets.CurrentView.LoadingPanelVisible = False
        '        DataGridViewForm_Vendors.CurrentView.LoadingPanelVisible = False

        '        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        '    End If

        'End Sub
        'Private Sub SearchableComboBoxForm_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Client.EditValueChanged

        '    Dim ClientCode As String = ""
        '    Dim StartDate As Date = Date.MinValue
        '    Dim EndDate As Date = Date.MinValue
        '    Dim MarketsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim VendorsOverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        '    Dim RatingServiceID As Integer = 0

        '    If Me.FormShown Then

        '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

        '        MarketsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Markets, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)
        '        VendorsOverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(DataGridViewForm_Vendors, True, True, System.Drawing.Color.White, System.Drawing.Color.FromArgb(1, 115, 199), 100, AdvantageFramework.My.Resources.SpinnerImage, Nothing)

        '        System.Windows.Forms.Application.DoEvents()

        '        ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
        '        StartDate = DateTimePickerStartDateRange_FromDate.GetValue
        '        EndDate = DateTimePickerStartDateRange_ToDate.GetValue
        '        RatingServiceID = ComboBoxForm_Source.GetSelectedValue()

        '        _Controller.GetMediaBroadcastWorksheetMarketBooks(ClientCode, StartDate, EndDate, _ViewModel, _MediaBroadcastWorksheetPrePostReportCriteriaBuyType, RatingServiceID)

        '        RefreshViewModel(True)

        '        DataGridViewForm_Markets.CurrentView.BestFitColumns()
        '        DataGridViewForm_Vendors.CurrentView.BestFitColumns()

        '        DataGridViewForm_Markets.SelectAll()
        '        DataGridViewForm_Vendors.SelectAll()

        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(MarketsOverlaySplayScreenHandle)
        '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(VendorsOverlaySplayScreenHandle)

        '        DataGridViewForm_Markets.CurrentView.LoadingPanelVisible = False
        '        DataGridViewForm_Vendors.CurrentView.LoadingPanelVisible = False

        '        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        '        DateTimePickerStartDateRange_FromDate.Enabled = True
        '        DateTimePickerStartDateRange_ToDate.Enabled = True

        '    End If

        'End Sub
        Private Sub ComboBoxForm_Source_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Source.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ComboBoxForm_Source.HasASelectedValue Then

                    _Controller.DynamicReports_SetSource(_ViewModel, DirectCast(ComboBoxForm_Source.SelectedItem, AdvantageFramework.DTO.ComboBoxItem).Value)

                    _IsPuertoRico = (ComboBoxForm_Source.GetSelectedValue = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico)

                Else

                    _Controller.DynamicReports_SetSource(_ViewModel, Nothing)

                    _IsPuertoRico = False

                End If

                SearchableComboBoxForm_Client.DataSource = _ViewModel.Clients

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Markets.CellValueChangedEvent

            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString AndAlso (e.Value Is Nothing OrElse e.Value < 0) Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString, Nothing)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID2.ToString AndAlso (e.Value Is Nothing OrElse e.Value < 0) Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString, Nothing)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID3.ToString AndAlso (e.Value Is Nothing OrElse e.Value < 0) Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString, Nothing)
                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString, Nothing)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID4.ToString AndAlso (e.Value Is Nothing OrElse e.Value < 0) Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID5.ToString, Nothing)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString AndAlso (e.Value Is Nothing OrElse e.Value < 0) Then

                DataGridViewForm_Markets.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.HPUTBookID.ToString, Nothing)

            ElseIf e.Value IsNot Nothing AndAlso (e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString) Then

                MediaBroadcastWorksheetMarketBook = DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle)

                If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString Then

                    MediaBroadcastWorksheetMarketBook.StartDate = e.Value

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString Then

                    MediaBroadcastWorksheetMarketBook.EndDate = e.Value

                End If

                _Controller.UpdateMediaBroadcastWorksheetMarketBooks(_ViewModel, MediaBroadcastWorksheetMarketBook)

                RefreshViewModel(False)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString Then

                _Controller.SetRequiredFields(DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle))

                DataGridViewForm_Markets.ValidateAllRows()

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Markets.CellValueChangingEvent

            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            MediaBroadcastWorksheetMarketBook = DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle)

            If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.UsePrimaryDemo.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.UseImpressions.ToString Then

                If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.UsePrimaryDemo.ToString Then

                    MediaBroadcastWorksheetMarketBook.UsePrimaryDemo = e.Value

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.SecondaryMediaDemographicID.ToString Then

                    MediaBroadcastWorksheetMarketBook.SecondaryMediaDemographicID = e.Value

                ElseIf e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.UseImpressions.ToString Then

                    MediaBroadcastWorksheetMarketBook.UseImpressions = e.Value

                End If

                _Controller.UpdateMediaBroadcastWorksheetMarketBooks(_ViewModel, MediaBroadcastWorksheetMarketBook)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_Markets.ValidatingEditorEvent

            Dim FocusedRow As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing
            Dim ErrorText As String = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            FocusedRow = DataGridViewForm_Markets.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateEntityProperty(FocusedRow, DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewForm_Markets.CurrentView.SetColumnError(DataGridViewForm_Markets.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

                If DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString Then

                    FocusedRow.StartDate = e.Value

                    ErrorText = _Controller.ValidateEntityProperty(FocusedRow, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString, True, FocusedRow.EndDate)

                    GridColumn = DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString)

                    If GridColumn IsNot Nothing Then

                        DataGridViewForm_Markets.CurrentView.SetColumnError(GridColumn, ErrorText)

                    End If

                ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.EndDate.ToString Then

                    FocusedRow.EndDate = e.Value

                    ErrorText = _Controller.ValidateEntityProperty(FocusedRow, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString, True, FocusedRow.StartDate)

                    GridColumn = DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.StartDate.ToString)

                    If GridColumn IsNot Nothing Then

                        DataGridViewForm_Markets.CurrentView.SetColumnError(GridColumn, ErrorText)

                    End If

                ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString Then

                    FocusedRow.PeriodStart = e.Value

                    ErrorText = _Controller.ValidateEntityProperty(FocusedRow, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString, True, FocusedRow.PeriodEnd)

                    GridColumn = DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString)

                    If GridColumn IsNot Nothing Then

                        DataGridViewForm_Markets.CurrentView.SetColumnError(GridColumn, ErrorText)

                    End If

                ElseIf DataGridViewForm_Markets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString Then

                    FocusedRow.PeriodEnd = e.Value

                    ErrorText = _Controller.ValidateEntityProperty(FocusedRow, AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString, True, FocusedRow.PeriodStart)

                    GridColumn = DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString)

                    If GridColumn IsNot Nothing Then

                        DataGridViewForm_Markets.CurrentView.SetColumnError(GridColumn, ErrorText)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_Markets.CustomDrawCellEvent

            'objects
            Dim BaseEditViewInfo As DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo = Nothing
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            If _MediaBroadcastWorksheetPrePostReportCriteriaBuyType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaBuyType.Pre Then

                If _MediaBroadcastWorksheetPrePostReportCriteriaMediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.TV Then

                    If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.ShareBookID.ToString Then

                        BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                        MediaBroadcastWorksheetMarketBook = DirectCast(DataGridViewForm_Markets.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

                        If MediaBroadcastWorksheetMarketBook.ShareBookID.HasValue = False Then

                            BaseEditViewInfo.ErrorIconText = "Select a book in order to see updated estimates."
                            BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                            BaseEditViewInfo.ShowErrorIcon = True

                        End If

                    End If

                ElseIf _MediaBroadcastWorksheetPrePostReportCriteriaMediaType = AdvantageFramework.Database.Entities.Methods.MediaBroadcastWorksheetPrePostReportCriteriaMediaType.Radio Then

                    If e.Column.FieldName = AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.NielsenRadioPeriodID1.ToString Then

                        BaseEditViewInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo).ViewInfo

                        MediaBroadcastWorksheetMarketBook = DirectCast(DataGridViewForm_Markets.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

                        If MediaBroadcastWorksheetMarketBook.NielsenRadioPeriodID1.HasValue = False Then

                            BaseEditViewInfo.ErrorIconText = "Select a book in order to see updated estimates."
                            BaseEditViewInfo.ErrorIcon = DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider.GetErrorIconInternal(DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning)
                            BaseEditViewInfo.ShowErrorIcon = True

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Markets.ValidateRowEvent

            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.MediaBroadcastWorksheetMarketBookValidateEntity(e.Row, e.Valid)

                MediaBroadcastWorksheetMarketBook = e.Row

                If DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString) IsNot Nothing Then

                    DataGridViewForm_Markets.CurrentView.SetColumnError(DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString),
                                                                        MediaBroadcastWorksheetMarketBook.LoadErrorText(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodStart.ToString))

                End If

                If DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString) IsNot Nothing Then

                    DataGridViewForm_Markets.CurrentView.SetColumnError(DataGridViewForm_Markets.CurrentView.Columns(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString),
                                                                        MediaBroadcastWorksheetMarketBook.LoadErrorText(AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook.Properties.PeriodEnd.ToString))

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
