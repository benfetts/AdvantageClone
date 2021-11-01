Namespace Media.Presentation

    Public Class MediaManagerApproveInvoicesDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OrderNumberLineNumbers As IEnumerable(Of String) = Nothing
        Private _ApproveInvoiceOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder) = Nothing
        Private _ApproveInvoiceList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing
        Private _ModifiedOrderLines As Generic.List(Of String) = Nothing
        Private _GoToApproveInvoice As AdvantageFramework.MediaManager.Classes.ApproveInvoice = Nothing
        Private _BroadcastOrderDetailVerifications As Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification) = Nothing
        Private _FilteredBroadcastOrderDetailVerifications As Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification) = Nothing
        Private _OrderWorksheetDetail As OrderWorksheetDetail = Nothing
        Private _DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
        Private _RatingsImpressionsCalculated As Boolean = False
        Private _SumEstRating As Decimal = 0
        Private _SumActRating As Decimal = 0
        Private _SumEstImps As Decimal = 0
        Private _SumActImps As Decimal = 0
        Private _OrderLineSumEstRating As Decimal = 0
        Private _OrderLineSumActRating As Decimal = 0
        Private _OrderLineSumEstImps As Decimal = 0
        Private _OrderLineSumActImps As Decimal = 0
        Private _OrderUpdated As Boolean = False
        Private _IsRadio As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedBroadcastInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)
            Get

                'objects
                Dim TVInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing
                Dim RadioInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing

                TVInvoices = Me.SelectedTVInvoices
                RadioInvoices = Me.SelectedRadioInvoices

                If TVInvoices Is Nothing Then

                    TVInvoices = New List(Of MediaManager.Classes.ApproveInvoice)

                End If

                If RadioInvoices Is Nothing Then

                    RadioInvoices = New List(Of MediaManager.Classes.ApproveInvoice)

                End If

                SelectedBroadcastInvoices = RadioInvoices.Union(TVInvoices).ToList

            End Get
        End Property
        Private ReadOnly Property SelectedRadioInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)
            Get
                SelectedRadioInvoices = DataGridViewInvoiceDetails_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice).Where(Function(ai) ai.MediaType.ToUpper = "RADIO").ToList
            End Get
        End Property
        Private ReadOnly Property SelectedTVInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)
            Get
                SelectedTVInvoices = DataGridViewInvoiceDetails_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice).Where(Function(ai) ai.MediaType.ToUpper = "TV").ToList
            End Get
        End Property
        Private ReadOnly Property GoToApproveInvoice As AdvantageFramework.MediaManager.Classes.ApproveInvoice
            Get
                GoToApproveInvoice = _GoToApproveInvoice
            End Get
        End Property
        Private ReadOnly Property OrderUpdated As Boolean
            Get
                OrderUpdated = _OrderUpdated
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal OrderNumberLineNumbers As IEnumerable(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            _OrderNumberLineNumbers = OrderNumberLineNumbers

        End Sub
        Private Sub RefreshApproveInvoiceLists()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _ApproveInvoiceOrderList = AdvantageFramework.MediaManager.LoadMediaManagerApproveInvoiceOrders(DbContext, _OrderNumberLineNumbers)

                _ApproveInvoiceList = AdvantageFramework.MediaManager.LoadMediaManagerApproveInvoices(DbContext, _OrderNumberLineNumbers)

            End Using

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim SelectedApproveInvoiceOrder As AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder = Nothing
            Dim ApproveInvoiceOrder As AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder = Nothing

            Me.ShowWaitForm("Loading...")

            SelectedApproveInvoiceOrder = DataGridViewInvoices_Orders.GetFirstSelectedRowDataBoundItem

            RefreshApproveInvoiceLists()

            DataGridViewInvoices_Orders.DataSource = _ApproveInvoiceOrderList

            If SelectedApproveInvoiceOrder IsNot Nothing Then

                DataGridViewInvoices_Orders.CurrentView.BeginSelection()

                DataGridViewInvoices_Orders.CurrentView.ClearSelection()

                For Each RowHandlesAndDataBoundItem In DataGridViewInvoices_Orders.GetAllRowsRowHandlesAndDataBoundItems

                    Try

                        ApproveInvoiceOrder = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        ApproveInvoiceOrder = Nothing
                    End Try

                    If ApproveInvoiceOrder IsNot Nothing AndAlso ApproveInvoiceOrder.OrderNumber = SelectedApproveInvoiceOrder.OrderNumber Then

                        DataGridViewInvoices_Orders.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                        DataGridViewInvoices_Orders.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewInvoices_Orders.CurrentView.EndSelection()

            End If

            DataGridViewInvoices_Orders.CurrentView.BestFitColumns()

            TabItemInvoiceItems_InvoiceDetail.Tag = True

            Me.CloseWaitForm()

        End Sub
        Private Sub LoadInvoices()

            'objects
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            OrderNumbers = (From AIO In DataGridViewInvoices_Orders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder).ToList
                            Select AIO.OrderNumber).Distinct.ToArray

            DataGridViewInvoiceDetails_InvoiceDetails.DataSource = (From AI In _ApproveInvoiceList
                                                                    Where OrderNumbers.Contains(AI.OrderNumber)
                                                                    Select AI).OrderBy(Function(AI) AI.OrderNumber).ThenBy(Function(AI) AI.LineNumber).ToList

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.BestFitColumns()

            For Each GridColumn In DataGridViewInvoiceDetails_InvoiceDetails.Columns

                If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.InvoiceQtySpots.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.APGrossAmount.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.APNetAmount.ToString Then

                    GridColumn.OptionsColumn.AllowFocus = False

                ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalNotes.ToString Then

                    GridColumn.OptionsColumn.AllowFocus = True

                Else

                    GridColumn.OptionsColumn.AllowFocus = False

                End If

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged
            ButtonItemActions_GoToOrder.Enabled = Not Me.UserEntryChanged AndAlso DataGridViewInvoiceDetails_InvoiceDetails.HasASelectedRow

            RibbonPanelFile_FilePanel.SuspendLayout()

            RibbonBarOptions_Spots.Visible = False
            RibbonBarOptions_Amounts.Visible = False
            RibbonBarOptions_RatingsImps.Visible = False
            RibbonBarOptions_InvoiceDetail.Visible = False
            RibbonBarOptions_Documents.Visible = False
            RibbonBarOptions_ApprovalStatus.Visible = False
            RibbonBarOptions_Filter.Visible = False
            RibbonBarOptions_View.Visible = False
            RibbonBarOptions_SpotDetail.Visible = False

            RibbonBarOptions_SpotDetail.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSpotDetailsTabSelected

            RibbonBarOptions_View.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetail)

            RibbonBarOptions_Filter.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetail)

            RibbonBarOptions_Documents.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected

            ButtonItemDocuments_Upload.Enabled = ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected AndAlso ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.CanUpload AndAlso
                                                    ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedRow

            RibbonBarOptions_InvoiceDetail.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching)

            RibbonBarOptions_RatingsImps.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) AndAlso _OrderWorksheetDetail.OrderIsOnWorksheet

            RibbonBarOptions_Amounts.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching)

            RibbonBarOptions_Spots.Visible = TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching)

            ButtonItemInvoiceDetail_Approve.Enabled = DataGridViewInvoiceDetailMatching_InvoiceDetails.HasASelectedRow
            ButtonItemInvoiceDetail_Unapprove.Enabled = DataGridViewInvoiceDetailMatching_InvoiceDetails.HasASelectedRow

            If ((From Entity In DataGridViewInvoiceDetailMatching_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)
                 Select Entity.OrderNumber).Distinct.Count = 1) Then

                ButtonItemInvoiceDetail_AutoFill.Enabled = True

            Else

                ButtonItemInvoiceDetail_AutoFill.Enabled = False

            End If

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) Then

                RibbonBarOptions_ApprovalStatus.Visible = False

                If _BroadcastOrderDetailVerifications.Count > 0 AndAlso _BroadcastOrderDetailVerifications.First.MediaType.Substring(0, 1) = "R" Then

                    _IsRadio = True

                    ButtonItemInvoiceDetail_ShowIMPs.Text = "Show AQH (00)"

                    If _OrderWorksheetDetail IsNot Nothing AndAlso _OrderWorksheetDetail.OrderIsOnWorksheet AndAlso _OrderWorksheetDetail.PrimaryMediaDemoID.HasValue Then

                        ButtonItemInvoiceDetail_ShowGRPs.Enabled = True
                        ButtonItemInvoiceDetail_ShowIMPs.Enabled = True

                    Else

                        ButtonItemInvoiceDetail_ShowGRPs.Enabled = False
                        ButtonItemInvoiceDetail_ShowIMPs.Enabled = False

                    End If

                ElseIf _BroadcastOrderDetailVerifications.Count > 0 AndAlso _BroadcastOrderDetailVerifications.First.MediaType.Substring(0, 1) = "T" Then

                    _IsRadio = False

                    ButtonItemInvoiceDetail_ShowIMPs.Text = "Show Imps"

                    If _OrderWorksheetDetail IsNot Nothing AndAlso _OrderWorksheetDetail.OrderIsOnWorksheet AndAlso _OrderWorksheetDetail.PrimaryMediaDemoID.HasValue Then

                        ButtonItemInvoiceDetail_ShowGRPs.Enabled = True
                        ButtonItemInvoiceDetail_ShowIMPs.Enabled = True

                    Else

                        ButtonItemInvoiceDetail_ShowGRPs.Enabled = False
                        ButtonItemInvoiceDetail_ShowIMPs.Enabled = False

                    End If

                End If

                RibbonBarOptions_RatingsImps.ResetCachedContentSize()
                RibbonBarOptions_RatingsImps.Refresh()
                RibbonBarOptions_RatingsImps.Width = RibbonBarOptions_RatingsImps.GetAutoSizeWidth
                RibbonBarOptions_RatingsImps.Refresh()

            Else

                RibbonBarOptions_ApprovalStatus.Visible = True

            End If

            TabItemInvoiceItems_InvoiceDetailMatching.Visible = Me.SelectedBroadcastInvoices.Any

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                    ButtonItemDocuments_Download.Enabled = If(ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasOnlyOneSelectedDocument, Not ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSelectedDocumentAURL, ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasASelectedDocument)
                    ButtonItemDocuments_OpenURL.Enabled = If(ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.HasOnlyOneSelectedDocument, ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSelectedDocumentAURL, False)

                ElseIf ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsSpotDetailsTabSelected Then

                    ButtonItemSpotDetail_Cancel.Enabled = ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SpotDetailsIsNewItemRow
                    ButtonItemSpotDetail_Delete.Enabled = ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SpotDetailsHasASelectedRow

                End If

            End If

            RibbonPanelFile_FilePanel.ResumeLayout()

        End Sub
        Private Sub SetMediaStatus()

            Dim ApproveInvoice As AdvantageFramework.MediaManager.Classes.ApproveInvoice = Nothing
            Dim NewMediaStatus As Nullable(Of Short) = Nothing

            If ComboBoxApprovalStatus_Status.HasASelectedValue Then

                NewMediaStatus = CShort(ComboBoxApprovalStatus_Status.GetSelectedValue)

            End If

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.CloseEditorForUpdating()

            For Each RowHandlesAndDataBoundItem In DataGridViewInvoiceDetails_InvoiceDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Try

                    ApproveInvoice = RowHandlesAndDataBoundItem.Value

                Catch ex As Exception
                    ApproveInvoice = Nothing
                End Try

                If ApproveInvoice IsNot Nothing Then

                    ApproveInvoice.ApprovalStatus = NewMediaStatus
                    ApproveInvoice.ApprovalNotes = Nothing

                    DataGridViewInvoiceDetails_InvoiceDetails.AddToModifiedRows(RowHandlesAndDataBoundItem.Key)

                    DataGridViewInvoiceDetails_InvoiceDetails.SetUserEntryChanged()

                End If

            Next

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub
        Private Sub LoadAPInvoicesDetailTab()

            Dim ApproveInvoiceList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            If DataGridViewInvoiceDetails_InvoiceDetails.HasASelectedRow Then

                ApproveInvoiceList = DataGridViewInvoiceDetails_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice).ToList

                LineNumbers = (From Entity In ApproveInvoiceList
                               Select CInt(Entity.LineNumber)).ToList

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.LoadControl(ApproveInvoiceList.First.OrderNumber, LineNumbers, ApproveInvoiceList.First.MediaType, True)

            End If

            TabItemAPInvoiceDetail_APInvoiceDetail.Tag = True

        End Sub
        Private Sub FilterGrid()

            Dim ApproveInvoiceList As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.CloseEditorForUpdating()

            ApproveInvoiceList = _ApproveInvoiceList

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.AFActiveFilterString = Nothing

            If ButtonItemFilter_HasVariance.Checked Then

                ApproveInvoiceList = ApproveInvoiceList.Where(Function(AI) AI.NetBalance <> 0).ToList

            End If

            If ButtonItemFilter_Unapproved.Checked Then

                ApproveInvoiceList = ApproveInvoiceList.Where(Function(AI) AI.ApprovalStatus IsNot Nothing AndAlso AI.ApprovalStatus = 1).ToList

            End If

            DataGridViewInvoiceDetails_InvoiceDetails.DataSource = ApproveInvoiceList.OrderBy(Function(AI) AI.OrderNumber).ThenBy(Function(AI) AI.LineNumber).ToList

        End Sub
        Private Sub LoadInvoiceDetailMatchingOrderLines(DbContext As AdvantageFramework.Database.DbContext, OrderNumbers As Generic.List(Of Integer), OrderNumberLines As Generic.List(Of String), OrderNumberYearMonths As Generic.List(Of String))

            'objects
            Dim SqlParameterOrderNumberLineNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderYearMonths As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowWeekOf As System.Data.SqlClient.SqlParameter = Nothing
            Dim BroadcastOrderVerifications As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) = Nothing

            SqlParameterOrderNumberLineNumbers = New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumbers", SqlDbType.VarChar)
            SqlParameterOrderYearMonths = New System.Data.SqlClient.SqlParameter("@OrderYearMonths", SqlDbType.VarChar)
            SqlParameterOrderNumbers = New System.Data.SqlClient.SqlParameter("@OrderNumbers", SqlDbType.VarChar)
            SqlParameterShowWeekOf = New System.Data.SqlClient.SqlParameter("@ShowWeekOf", SqlDbType.Bit)

            SqlParameterOrderNumberLineNumbers.Value = String.Join(",", OrderNumberLines.ToArray)
            SqlParameterOrderYearMonths.Value = String.Join(",", OrderNumberYearMonths.ToArray)
            SqlParameterOrderNumbers.Value = String.Join(",", OrderNumbers.ToArray)
            SqlParameterShowWeekOf.Value = ButtonItemInvoiceDetail_ShowWeeks.Checked

            BroadcastOrderVerifications = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)("EXEC advsp_broadcast_order_verification @OrderNumberLineNumbers, @OrderYearMonths, @OrderNumbers, @ShowWeekOf",
                                                                                SqlParameterOrderNumberLineNumbers, SqlParameterOrderYearMonths, SqlParameterOrderNumbers, SqlParameterShowWeekOf).ToList

            DataGridViewInvoiceDetailMatching_OrderLines.DataSource = BroadcastOrderVerifications

        End Sub
        Private Function LoadDetailVerifications(DbContext As AdvantageFramework.Database.DbContext, OrderNumbers As Generic.List(Of Integer),
                                                 OrderNumberLines As Generic.List(Of String), OrderNumberYearMonths As Generic.List(Of String)) As Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)

            'objects
            Dim SqlParameterOrderNumberLineNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatchAdditionalParameters As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderYearMonths As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim BroadcastOrderDetailVerifications As Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification) = Nothing
            Dim SqlParameterShowWeekOf As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderNumberLineNumbers = New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumbers", SqlDbType.VarChar)
            SqlParameterMatchAdditionalParameters = New System.Data.SqlClient.SqlParameter("@MatchAdditionalParameters", SqlDbType.Bit)
            SqlParameterOrderYearMonths = New System.Data.SqlClient.SqlParameter("@OrderYearMonths", SqlDbType.VarChar)
            SqlParameterOrderNumbers = New System.Data.SqlClient.SqlParameter("@OrderNumbers", SqlDbType.VarChar)
            SqlParameterShowWeekOf = New System.Data.SqlClient.SqlParameter("@ShowWeekOf", SqlDbType.Bit)

            SqlParameterOrderNumberLineNumbers.Value = String.Join(",", OrderNumberLines.ToArray)
            SqlParameterMatchAdditionalParameters.Value = True
            SqlParameterOrderYearMonths.Value = String.Join(",", OrderNumberYearMonths.ToArray)
            SqlParameterOrderNumbers.Value = String.Join(",", OrderNumbers.ToArray)
            SqlParameterShowWeekOf.Value = ButtonItemInvoiceDetail_ShowWeeks.Checked

            BroadcastOrderDetailVerifications = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)("EXEC advsp_broadcast_order_dtl_verification @OrderNumberLineNumbers, @MatchAdditionalParameters, @OrderYearMonths, @OrderNumbers, @ShowWeekOf",
                                                                                SqlParameterOrderNumberLineNumbers, SqlParameterMatchAdditionalParameters, SqlParameterOrderYearMonths, SqlParameterOrderNumbers, SqlParameterShowWeekOf).ToList

            LoadDetailVerifications = BroadcastOrderDetailVerifications

        End Function
        Private Sub LoadSpotVerificationTab()

            'objects
            Dim OrderNumbers As Generic.List(Of Integer) = Nothing
            Dim OrderNumberLines As Generic.List(Of String) = Nothing
            Dim OrderNumberYearMonths As Generic.List(Of String) = Nothing

            If Me.SelectedBroadcastInvoices.Any Then

                Me.ShowWaitForm("Loading...")

                OrderNumbers = New Generic.List(Of Integer)
                OrderNumberLines = New Generic.List(Of String)
                OrderNumberYearMonths = New Generic.List(Of String)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If Me.SelectedRadioInvoices IsNot Nothing AndAlso Me.SelectedRadioInvoices.Count > 0 Then

                        OrderNumbers.AddRange(Me.SelectedRadioInvoices.Select(Function(i) i.OrderNumber).Distinct.ToArray)
                        OrderNumberLines.AddRange(Me.SelectedRadioInvoices.Select(Function(i) i.OrderNumber & "|" & i.LineNumber).Distinct.ToArray)
                        OrderNumberYearMonths.AddRange(Me.SelectedRadioInvoices.Select(Function(i) i.OrderNumber & "|" & i.YearNumber.Value.ToString & "|" & i.MonthNumber.Value.ToString).Distinct.ToArray)

                    End If

                    If Me.SelectedTVInvoices IsNot Nothing AndAlso Me.SelectedTVInvoices.Count > 0 Then

                        OrderNumbers.AddRange(Me.SelectedTVInvoices.Select(Function(i) i.OrderNumber).Distinct.ToArray)
                        OrderNumberLines.AddRange(Me.SelectedTVInvoices.Select(Function(i) i.OrderNumber & "|" & i.LineNumber).Distinct.ToArray)
                        OrderNumberYearMonths.AddRange(Me.SelectedTVInvoices.Select(Function(i) i.OrderNumber & "|" & i.YearNumber.Value.ToString & "|" & i.MonthNumber.Value.ToString).Distinct.ToArray)

                    End If

                    _BroadcastOrderDetailVerifications = LoadDetailVerifications(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                    _FilteredBroadcastOrderDetailVerifications = New Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)(_BroadcastOrderDetailVerifications)

                    _OrderWorksheetDetail = DbContext.Database.SqlQuery(Of OrderWorksheetDetail)(String.Format("exec dbo.[advsp_media_broadcast_worksheet_get_by_order_number] {0}", OrderNumbers.First)).FirstOrDefault

                    LoadInvoiceDetailMatchingOrderLines(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                    If (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Load(DbContext)
                        Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                              Entity.OrderLineNumber Is Nothing
                        Select Entity).Any OrElse
                        (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Load(DbContext)
                         Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                               Entity.OrderLineNumber Is Nothing
                         Select Entity).Any Then

                        MatchUnmatchedLines(DbContext, OrderNumbers)

                        RefreshApproveInvoiceLists()

                        _BroadcastOrderDetailVerifications = LoadDetailVerifications(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                        _FilteredBroadcastOrderDetailVerifications = New Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)(_BroadcastOrderDetailVerifications)

                        LoadInvoiceDetailMatchingOrderLines(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                    End If

                    'If RefineVarianceSpots(DbContext) Then

                    '    _BroadcastOrderDetailVerifications = LoadDetailVerifications(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                    '    _FilteredBroadcastOrderDetailVerifications = New Generic.List(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)(_BroadcastOrderDetailVerifications)

                    '    LoadInvoiceDetailMatchingOrderLines(DbContext, OrderNumbers, OrderNumberLines, OrderNumberYearMonths)

                    'End If

                    '_OrderWorksheetDetail = DbContext.Database.SqlQuery(Of OrderWorksheetDetail)(String.Format("exec dbo.[advsp_media_broadcast_worksheet_get_by_order_number] {0}", OrderNumbers.First)).FirstOrDefault

                    LabelItemDemographic.Text = _OrderWorksheetDetail.PrimaryMediaDemographicDescription
                    LabelItemRatingsSource.Text = _OrderWorksheetDetail.RatingsService

                    LabelItemInvoicedAmount.Text = "Gross Amt: " & FormatNumber((From Entity In _ApproveInvoiceOrderList
                                                                                 Where Entity.OrderNumber = OrderNumbers.First
                                                                                 Select Entity.GrossInvoiceAmount).Sum, 2)

                    LabelItemInvoicedNetAmount.Text = "Net Amt: " & FormatNumber((From Entity In _ApproveInvoiceOrderList
                                                                                  Where Entity.OrderNumber = OrderNumbers.First
                                                                                  Select Entity.NetInvoiceAmount).Sum, 2)

                    LabelItemOrderedAmount.Text = "Gross Amt: " & FormatNumber((From Entity In _ApproveInvoiceOrderList
                                                                                Where Entity.OrderNumber = OrderNumbers.First
                                                                                Select Entity.GrossOrderAmount).Sum, 2)

                    LabelItemOrderedNetAmount.Text = "Net Amt: " & FormatNumber((From Entity In _ApproveInvoiceOrderList
                                                                                 Where Entity.OrderNumber = OrderNumbers.First
                                                                                 Select Entity.NetOrderAmount).Sum, 2)

                    LabelItemInvoicedSpots.Text = "Spots: " & (From Entity In _ApproveInvoiceOrderList
                                                               Where Entity.OrderNumber = OrderNumbers.First
                                                               Select Entity.InvoiceQtySpots.GetValueOrDefault(0)).Sum

                    LabelItemOrderedSpots.Text = "Spots: " & (From Entity In _ApproveInvoiceOrderList
                                                              Where Entity.OrderNumber = OrderNumbers.First
                                                              Select Entity.OrderQtySpots.GetValueOrDefault(0)).Sum

                    _RatingsImpressionsCalculated = False

                    CalculateRatingsImpressions()

                    'If DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartDateTime.ToString) IsNot Nothing Then

                    '    'FormatBroadcastDetailsTimeEditor(DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartDateTime.ToString).RealColumnEdit)

                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartDateTime.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartDateTime.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartDateTime.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True

                    'End If

                    'If DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndDateTime.ToString) IsNot Nothing Then

                    '    'FormatBroadcastDetailsTimeEditor(DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndDateTime.ToString).RealColumnEdit)

                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndDateTime.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndDateTime.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                    '    DataGridViewInvoiceDetailMatching_OrderLines.Columns(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndDateTime.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True

                    'End If

                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.BestFitColumns()

                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.UpdateSummary()

                End Using

                Me.CloseWaitForm()

            End If

            TabItemInvoiceItems_InvoiceDetailMatching.Tag = True

        End Sub
        Private Sub SetInvoiceDetailsGridCaption()

            If ButtonItemInvoiceDetail_ShowAll.Checked Then

                DataGridViewInvoiceDetailMatching_InvoiceDetails.ItemDescription = "Invoice Detail(s)"

            Else

                DataGridViewInvoiceDetailMatching_InvoiceDetails.ItemDescription = "Variant Invoice Detail(s)"

            End If

        End Sub
        Private Sub FormatBroadcastDetailsTimeEditor(ByVal RepositoryItemTimeEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput)

            RepositoryItemTimeEdit.EditMask = "t"
            RepositoryItemTimeEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            RepositoryItemTimeEdit.Mask.EditMask = "t"

            RepositoryItemTimeEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            RepositoryItemTimeEdit.DisplayFormat.FormatString = "t"

        End Sub
        Private Sub ShowGrossNetColumns(ShowGross As Boolean, ShowNet As Boolean)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0

            For Each GridColumn In DataGridViewInvoices_Orders.Columns

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder), GridColumn.FieldName) Then

                    If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.GrossBalance.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.GrossInvoiceAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.GrossOrderAmount.ToString) Then

                        If ShowGross Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.NetBalance.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.NetInvoiceAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder.Properties.NetOrderAmount.ToString) Then

                        If ShowNet Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                    End If

                End If

            Next

            VisibleIndex = 0

            For Each GridColumn In DataGridViewInvoiceDetails_InvoiceDetails.Columns

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.MediaManager.Classes.ApproveInvoice), GridColumn.FieldName) Then

                    If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.GrossBalance.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.APGrossAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.GrossOrderAmount.ToString) Then

                        If ShowGross Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.NetBalance.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.APNetAmount.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.NetOrderAmount.ToString) Then

                        If ShowNet Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                    End If

                End If

            Next

        End Sub
        Private Sub SaveMediaManagerApproveInvoiceView()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim ViewCheckedValue As String = Nothing

            ViewCheckedValue = IIf(ButtonItemView_ShowBoth.Checked, "B", IIf(ButtonItemView_ShowGross.Checked, "G", "N"))

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerApproveInvoiceView.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ViewCheckedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerApproveInvoiceView.ToString, ViewCheckedValue, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SetMediaManagerApproveInvoiceView()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerApproveInvoiceView.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    If UserSetting.StringValue = "B" Then

                        ButtonItemView_ShowBoth.Checked = True

                    ElseIf UserSetting.StringValue = "G" Then

                        ButtonItemView_ShowGross.Checked = True

                    Else

                        ButtonItemView_ShowNet.Checked = True

                    End If

                Else

                    ButtonItemView_ShowGross.Checked = True

                End If

            End Using

        End Sub
        Private Function GetNewColumn(ByVal FieldName As String, Optional ByVal Visible As Boolean = True, Optional ByVal Caption As String = "") As DevExpress.XtraGrid.Columns.GridColumn

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            If Caption = "" Then

                GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(FieldName)

            Else

                GridColumn.Caption = Caption

            End If

            GridColumn.FieldName = FieldName
            GridColumn.Visible = Visible

            GetNewColumn = GridColumn

        End Function
        Private Sub RefreshInvoiceDetailMatchingInvoiceDetails()

            'objects
            Dim IsRowVisible As Boolean = True
            Dim AllWeeks As IEnumerable(Of Date) = Nothing
            Dim SelectedOrderLines As IEnumerable(Of Short) = Nothing

            If _FilteredBroadcastOrderDetailVerifications IsNot Nothing Then

                SelectedOrderLines = (From Item In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                      Where Item.OrderLineNumber.HasValue
                                      Select Item.OrderLineNumber.Value).Distinct.ToArray

                _FilteredBroadcastOrderDetailVerifications.Clear()

                For Each BroadcastOrderDetailVerification In _BroadcastOrderDetailVerifications

                    IsRowVisible = True

                    If Not ButtonItemInvoiceDetail_ShowAll.Checked Then

                        If BroadcastOrderDetailVerification.IsAdNumberVerified AndAlso BroadcastOrderDetailVerification.IsDayOfWeekVerified AndAlso BroadcastOrderDetailVerification.IsLengthVerified AndAlso
                                BroadcastOrderDetailVerification.IsNetworkVerified AndAlso BroadcastOrderDetailVerification.IsRateVerified AndAlso BroadcastOrderDetailVerification.IsScheduleVerified AndAlso
                                BroadcastOrderDetailVerification.IsTimeSeparationVerified AndAlso BroadcastOrderDetailVerification.IsTimeVerified AndAlso String.IsNullOrWhiteSpace(BroadcastOrderDetailVerification.IsBookendVerified) Then

                            IsRowVisible = False

                        End If

                    End If

                    If IsRowVisible Then

                        If BroadcastOrderDetailVerification.OrderLineNumber.HasValue Then

                            If ButtonItemInvoiceDetail_ShowWeeks.Checked AndAlso BroadcastOrderDetailVerification.WeekOf.HasValue Then

                                If (From Item In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                    Where Item.OrderNumber = BroadcastOrderDetailVerification.OrderNumber AndAlso
                                          Item.OrderLineNumber.GetValueOrDefault(0) = BroadcastOrderDetailVerification.OrderLineNumber.GetValueOrDefault(0) AndAlso
                                          Item.WeekOf.GetValueOrDefault("01/01/1901") = BroadcastOrderDetailVerification.WeekOf.GetValueOrDefault("01/01/1901")
                                    Select Item).Any = False Then

                                    IsRowVisible = False

                                    AllWeeks = (From Item In DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                                Where Item.OrderNumber = BroadcastOrderDetailVerification.OrderNumber AndAlso
                                                      Item.OrderLineNumber.GetValueOrDefault(0) = BroadcastOrderDetailVerification.OrderLineNumber.GetValueOrDefault(0) AndAlso
                                                      Item.WeekOf.HasValue
                                                Select Item.WeekOf.Value).ToList

                                    If SelectedOrderLines.Contains(BroadcastOrderDetailVerification.OrderLineNumber.GetValueOrDefault(0)) AndAlso
                                            BroadcastOrderDetailVerification.WeekOf.HasValue AndAlso AllWeeks.Contains(BroadcastOrderDetailVerification.WeekOf.Value) = False Then

                                        IsRowVisible = True

                                    End If

                                End If

                            Else

                                If (From Item In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                    Where Item.OrderNumber = BroadcastOrderDetailVerification.OrderNumber AndAlso
                                          Item.OrderLineNumber.GetValueOrDefault(0) = BroadcastOrderDetailVerification.OrderLineNumber.GetValueOrDefault(0)
                                    Select Item).Any = False Then

                                    IsRowVisible = False

                                End If

                            End If

                        Else

                            If (From Item In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                Where Item.OrderNumber = BroadcastOrderDetailVerification.OrderNumber
                                Select Item).Any = False Then

                                IsRowVisible = False

                            End If

                        End If

                    End If

                    If IsRowVisible Then

                        _FilteredBroadcastOrderDetailVerifications.Add(BroadcastOrderDetailVerification)

                    End If

                Next

                DataGridViewInvoiceDetailMatching_InvoiceDetails.DataSource = _FilteredBroadcastOrderDetailVerifications.OrderBy(Function(i) i.OrderNumber).ThenBy(Function(i) i.OrderLineNumber).ToList

                ToggleColumnVisibility()

                If DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString) IsNot Nothing AndAlso
                                DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).RealColumnEdit IsNot Nothing Then

                    FormatBroadcastDetailsTimeEditor(DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).RealColumnEdit)

                    DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value
                    DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
                    DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True
                    'DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RunDateTime.ToString).SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                End If

                DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.BestFitColumns()

                DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.UpdateSummary()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub SaveApprovedInvoices()

            'objects
            Dim ApproveInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ApprovedInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice) = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.CloseEditorForUpdating()

            ApproveInvoices = DataGridViewInvoiceDetails_InvoiceDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice).ToList
            ApprovedInvoices = New List(Of MediaManager.Classes.ApproveInvoice)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    For Each ApproveInvoice In ApproveInvoices

                        Try

                            DbTransaction = DbContext.Database.BeginTransaction

                            If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, ApproveInvoice.AccountPayableID, ApproveInvoice.OrderNumber,
                                                                                   ApproveInvoice.LineNumber, ApproveInvoice.MediaType.Substring(0, 1), ApproveInvoice.ApprovalStatus,
                                                                                   Session.UserCode, ApproveInvoice.ApprovalNotes, "MEDIA") Then

                                If ApproveInvoice.ApprovalStatus.HasValue Then

                                    If ApproveInvoice.ApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved OrElse
                                            ApproveInvoice.ApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatus.ApprovedWithChanges OrElse
                                            ApproveInvoice.ApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatus.ApprovalNotRequired Then

                                        ApprovedInvoices.Add(ApproveInvoice)

                                    End If

                                End If

                                DbTransaction.Commit()

                            Else

                                DbTransaction.Rollback()

                            End If

                        Catch ex As Exception

                            DbTransaction.Rollback()

                        End Try

                    Next

                    If AdvantageFramework.Agency.GetOptionAutomaticallyRemovePaymentHoldOnApproval(DataContext) Then

                        AdvantageFramework.AccountPayable.ModifyPaymentHoldForApprovedInvoices(DbContext, ApproveInvoices)

                    End If

                    If ApprovedInvoices IsNot Nothing AndAlso ApprovedInvoices.Count > 0 Then

                        AdvantageFramework.AccountPayable.SendMediaApprovalAlerts(Me.Session, DbContext, ApprovedInvoices, ErrorMessage)

                        If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                        End If

                    End If

                End Using

            End Using

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Public Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim VendorCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Saving...")

                    If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetail) Then

                        SaveApprovedInvoices()

                    ElseIf TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) Then

                        IsOkay = UpdateOrder()

                    ElseIf TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                        ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SaveSpotDetail()

                        TabItemInvoiceItems_InvoiceDetailMatching.Tag = False

                        Me.ClearChanged()

                    End If

                    Me.CloseWaitForm()

                Else

                    If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetail) Then

                        RefreshApproveInvoiceLists()

                    End If

                    Me.ClearChanged()

                    EnableOrDisableActions()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function UpdateOrder() As Boolean

            Dim Updated As Boolean = True
            Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
            Dim MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
            Dim MediaBroadcastWorksheetMarketCreateOrdersViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketCreateOrdersViewModel = Nothing
            Dim Value As Object = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim VendorCode As String = Nothing
            Dim ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CancelledImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim DetailDates As Generic.List(Of Date) = Nothing
            Dim DateValue As Date = Nothing
            Dim MediaBroadcastWorsheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            Dim OrderLines As Generic.List(Of AdvantageFramework.Controller.Media.MakegoodDeliveryController.OrderLine) = Nothing
            Dim MakegoodDeliveryController As AdvantageFramework.Controller.Media.MakegoodDeliveryController = Nothing
            Dim OLs As Generic.List(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderLine) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.CloseEditorForUpdating()

            If DataGridViewInvoiceDetailMatching_OrderLines.HasAnyInvalidRows Then

                Updated = False

                AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.")

            Else

                'possibly add check here to make sure still editable
                If _OrderWorksheetDetail IsNot Nothing AndAlso _OrderWorksheetDetail.IsEditable AndAlso _OrderWorksheetDetail.OrderIsOnWorksheet Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving

                    Me.ShowWaitForm("Saving...")

                    MediaBroadcastWorksheetController = New Controller.Media.MediaBroadcastWorksheetController(Session)

                    MediaBroadcastWorksheetMarketDetailsViewModel = MediaBroadcastWorksheetController.MarketDetails_Load(_OrderWorksheetDetail.MediaBroadcastWorksheetID, _OrderWorksheetDetail.MediaBroadcastWorksheetMarketID)

                    RowIndexes = New Generic.List(Of Integer)
                    MediaBroadcastWorsheetMarketDetailIDs = New Generic.List(Of Integer)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        For Each BroadcastOrderVerification In DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.GetAllModifiedRows.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                            VendorCode = BroadcastOrderVerification.VendorCode

                            DetailDates = New Generic.List(Of Date)

                            For Each Key In MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Keys

                                DetailDates.Add(Key)

                            Next

                            If BroadcastOrderVerification.WeekOf.HasValue AndAlso BroadcastOrderVerification.WorksheetLineNumber.HasValue AndAlso
                                    (MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.ContainsKey(BroadcastOrderVerification.WeekOf.Value) OrElse
                                     BroadcastOrderVerification.WeekOf.Value < DetailDates.Min() AndAlso BroadcastOrderVerification.WeekOf.Value > DateAdd(DateInterval.Day, -6, DetailDates.Min())) Then

                                If MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.ContainsKey(BroadcastOrderVerification.WeekOf.Value) Then

                                    Value = MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(BroadcastOrderVerification.WeekOf.Value)
                                    DateValue = BroadcastOrderVerification.WeekOf.Value

                                ElseIf BroadcastOrderVerification.IsDaily Then

                                    Value = MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(BroadcastOrderVerification.StartDate)
                                    DateValue = BroadcastOrderVerification.StartDate

                                ElseIf BroadcastOrderVerification.WeekOf.Value < DetailDates.Min() Then

                                    Value = MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(DetailDates.Min())
                                    DateValue = DetailDates.Min()

                                End If

                                DataRow = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Select("VendorCode = '" & BroadcastOrderVerification.VendorCode & "' AND LineNumber = " & BroadcastOrderVerification.WorksheetLineNumber.Value & " AND MakegoodNumber = " & BroadcastOrderVerification.WorksheetMakegoodNumber).FirstOrDefault

                                If DataRow IsNot Nothing Then

                                    RowIndex = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(DataRow)

                                    If BroadcastOrderVerification.Daypart.HasValue Then

                                        Daypart = DbContext.Dayparts.Where(Function(DP) DP.ID = BroadcastOrderVerification.Daypart).FirstOrDefault

                                    End If

                                    DaysAndTime = DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString)

                                    DaysAndTime.Days = BroadcastOrderVerification.Days
                                    DaysAndTime.StartTime = BroadcastOrderVerification.StartTime
                                    DaysAndTime.EndTime = BroadcastOrderVerification.EndTime

                                    DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                                    DaysAndTimeController.ParseDays(DaysAndTime, DaysAndTime.Days, True) 'necessary to check Monday, Tuesday, properties etc.

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString) = DaysAndTime

                                    DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates(DateValue)) = BroadcastOrderVerification.Spots.GetValueOrDefault(0)

                                    DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.RateDates(DateValue)) = BroadcastOrderVerification.GrossRate

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString) = BroadcastOrderVerification.Days

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) = BroadcastOrderVerification.StartTime

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) = BroadcastOrderVerification.EndTime

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = BroadcastOrderVerification.Length

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) = If(Daypart IsNot Nothing, Daypart.Code, "")

                                    DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) = BroadcastOrderVerification.Program

                                    MediaBroadcastWorksheetController.MarketDetails_MarketDetailDateValueChanged(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndex, Value)
                                    MediaBroadcastWorksheetController.MarketDetails_MarketDetailChanged(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndex)

                                    RowIndexes.Add(RowIndex)

                                    If MediaBroadcastWorsheetMarketDetailIDs.Contains(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString)) = False Then

                                        MediaBroadcastWorsheetMarketDetailIDs.Add(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString))

                                    End If

                                End If

                            End If

                        Next

                    End Using

                    MediaBroadcastWorksheetController.MarketDetails_Save(MediaBroadcastWorksheetMarketDetailsViewModel)

                    MediaBroadcastWorksheetMarketCreateOrdersViewModel = MediaBroadcastWorksheetController.MarketCreateOrders_Load(MediaBroadcastWorksheetMarketDetailsViewModel)

                    MediaBroadcastWorksheetMarketDetailsViewModel.GenerateApproveMediaBroadcastWorsheetMarketDetailIDs = MediaBroadcastWorsheetMarketDetailIDs

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        OLs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                               Where Entity.OrderNumber.HasValue AndAlso
                                     Entity.OrderLineNumber.HasValue AndAlso
                                     MediaBroadcastWorsheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                               Select New AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.OrderLine With {.OrderNumber = Entity.OrderNumber.Value,
                                                                                                                   .LineNumber = Entity.OrderLineNumber.Value}).Distinct.ToList

                        If OLs IsNot Nothing AndAlso OLs.Count > 0 Then

                            LineNumbers = OLs.Where(Function(OL) OL.OrderNumber = _OrderWorksheetDetail.OrderNumber).Select(Function(OL) OL.LineNumber).Distinct.ToArray

                            If (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)).Any Then

                                MediaBroadcastWorksheetMarketCreateOrdersViewModel.StartDate = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)
                                                                                                Where Entity.StartDate IsNot Nothing AndAlso
                                                                                                      LineNumbers.Contains(Entity.LineNumber)
                                                                                                Select Entity.StartDate).Min

                                MediaBroadcastWorksheetMarketCreateOrdersViewModel.EndDate = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)
                                                                                              Where Entity.EndDate IsNot Nothing AndAlso
                                                                                                    LineNumbers.Contains(Entity.LineNumber)
                                                                                              Select Entity.EndDate).Max

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)).Any Then

                                MediaBroadcastWorksheetMarketCreateOrdersViewModel.StartDate = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)
                                                                                                Where Entity.StartDate IsNot Nothing AndAlso
                                                                                                      LineNumbers.Contains(Entity.LineNumber)
                                                                                                Select Entity.StartDate).Min

                                MediaBroadcastWorksheetMarketCreateOrdersViewModel.EndDate = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, _OrderWorksheetDetail.OrderNumber)
                                                                                              Where Entity.EndDate IsNot Nothing AndAlso
                                                                                                    LineNumbers.Contains(Entity.LineNumber)
                                                                                              Select Entity.EndDate).Max

                            End If

                        End If

                    End Using

                    ImportOrders = MediaBroadcastWorksheetController.MarketDetails_CreateImportOrderList(MediaBroadcastWorksheetMarketDetailsViewModel, MediaBroadcastWorksheetMarketCreateOrdersViewModel, MediaBroadcastWorksheetMarketDetailsViewModel.SelectedWorksheetMarketRevisionNumber, RowIndexes)

                    AdvantageFramework.Media.AssignOrderID(Me.Session, AdvantageFramework.MediaPlanning.CreateOrderOptions.Default, ImportOrders)

                    If ImportOrders.Count > 0 Then

                        CancelledImportOrders = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                        If Not AdvantageFramework.Importing.SaveOrders(Session, ImportOrders, False, False, False, "", False, False, CancelledImportOrders, Nothing, Nothing, ErrorMessage, MediaInterface:="MM") Then

                            AdvantageFramework.WinForm.MessageBox.Show("Problem creating orders: " & ErrorMessage)

                        Else

                            OrderLines = MediaBroadcastWorksheetController.MarketDetails_GetOrderLineNumbers(MediaBroadcastWorksheetMarketDetailsViewModel)

                            If OrderLines IsNot Nothing AndAlso OrderLines.Count > 0 Then

                                MakegoodDeliveryController = New Controller.Media.MakegoodDeliveryController(Me.Session)

                                MakegoodDeliveryController.AcceptOrderForVendorRep(OrderLines, Session.User.EmployeeCode)

                            End If

                        End If

                    End If

                    LoadGrid()

                    LoadSpotVerificationTab()

                    Me.ClearChanged()

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    EnableOrDisableActions()

                    Me.CloseWaitForm()

                End If

            End If

            If Not _OrderUpdated Then

                _OrderUpdated = Updated

            End If

            UpdateOrder = Updated

        End Function
        Private Sub MatchUnmatchedLines(DbContext As AdvantageFramework.Database.DbContext, OrderNumbers As Generic.List(Of Integer))

            Dim AccountPayableRadioBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail) = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim BroadcastOrderDetailVerification As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
            Dim LineNumber As Short = 0
            Dim AccountPayableTVBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail) = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim IsNetOrder As Boolean = False
            Dim BroadcastOrderVerificationList As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) = Nothing
            Dim MatchedLinesList As Generic.List(Of MatchedLines) = Nothing
            Dim AllRadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim AllTVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim TVOrders As Generic.List(Of AdvantageFramework.Database.Entities.TVOrder) = Nothing
            Dim RadioOrders As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrder) = Nothing
            Dim Matched As Boolean = False
            Dim OrderAdjacencyList As Generic.List(Of AdvantageFramework.Media.Presentation.OrderAdjacency) = Nothing
            Dim Adjacency As AdvantageFramework.Media.Presentation.OrderAdjacency = Nothing

            'For Each BroadcastOrderDetailVerification In _BroadcastOrderDetailVerifications.Where(Function(bv) bv.OrderLineNumber.HasValue).ToList

            '    If BroadcastOrderDetailVerification.MediaType = "Radio" Then

            '        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", BroadcastOrderDetailVerification.OrderLineNumber.Value, BroadcastOrderDetailVerification.DetailID))

            '    ElseIf BroadcastOrderDetailVerification.MediaType = "TV" Then

            '        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", BroadcastOrderDetailVerification.OrderLineNumber.Value, BroadcastOrderDetailVerification.DetailID))

            '    End If

            'Next

            AccountPayableRadioBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Load(DbContext)
                                                   Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                                         Entity.OrderLineNumber Is Nothing
                                                   Select Entity).ToList

            If AccountPayableRadioBroadcastDetails IsNot Nothing AndAlso AccountPayableRadioBroadcastDetails.Count > 0 Then

                OrderAdjacencyList = LoadAdjacencyList(DbContext, AccountPayableRadioBroadcastDetails.Select(Function(O) O.OrderNumber).Distinct.ToList, "T")

                AllRadioOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumbers(DbContext, OrderNumbers).ToList
                                        Select Entity).ToList

                RadioOrders = (From Entity In AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)
                               Where OrderNumbers.Contains(Entity.OrderNumber)
                               Select Entity).ToList

            End If

            For Each AccountPayableRadioBroadcastDetail In AccountPayableRadioBroadcastDetails

                Matched = -False
                IsNetOrder = False

                RadioOrder = RadioOrders.Where(Function(R) R.OrderNumber = AccountPayableRadioBroadcastDetail.OrderNumber).SingleOrDefault

                If RadioOrder IsNot Nothing AndAlso RadioOrder.NetGross.GetValueOrDefault(1) = 0 Then

                    IsNetOrder = True

                End If

                Adjacency = OrderAdjacencyList.Where(Function(AL) AL.OrderNumber = AccountPayableRadioBroadcastDetail.OrderNumber).SingleOrDefault

                RadioOrderDetails = (From Entity In AllRadioOrderDetails
                                     Where Entity.RadioOrderNumber = AccountPayableRadioBroadcastDetail.OrderNumber AndAlso
                                           Entity.MinDate <= AccountPayableRadioBroadcastDetail.RunDate AndAlso
                                           Entity.MaxDate >= AccountPayableRadioBroadcastDetail.RunDate AndAlso
                                           ((IsNetOrder AndAlso Entity.NetRate = AccountPayableRadioBroadcastDetail.NetRate) OrElse
                                            (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableRadioBroadcastDetail.GrossRate)) AndAlso
                                           Entity.Length.GetValueOrDefault(0) = AccountPayableRadioBroadcastDetail.Length AndAlso
                                           ((IsDate(Entity.StartTime) AndAlso IsDate(Entity.EndTime) AndAlso
                                            Entity.GetStartHourMinute(Adjacency.AdjacencyBefore) <= AccountPayableRadioBroadcastDetail.HourMinute AndAlso
                                            Entity.GetEndHourMinute(Adjacency.AdjacencyAfter) >= AccountPayableRadioBroadcastDetail.HourMinute) OrElse
                                            (Not IsDate(Entity.StartTime) AndAlso Not IsDate(Entity.EndTime))) AndAlso
                                           (((Entity.Monday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 1) OrElse
                                            (Entity.Tuesday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 2) OrElse
                                            (Entity.Wednesday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 3) OrElse
                                            (Entity.Thursday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 4) OrElse
                                            (Entity.Friday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 5) OrElse
                                            (Entity.Saturday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 6) OrElse
                                            (Entity.Sunday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 7)) OrElse (AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 0))
                                     Select Entity).ToList

                If RadioOrderDetails.Count > 1 Then

                    If RadioOrderDetails.Where(Function(T) T.TotalSpots > 0).Count = 1 Then

                        UpdateAccountPayableRadioBroadcastDetailLineNumber(DbContext, RadioOrderDetails.Where(Function(T) T.TotalSpots > 0).First, AccountPayableRadioBroadcastDetail)
                        Matched = True

                    ElseIf RadioOrderDetails.Where(Function(T) T.TotalSpots > 0).Count > 1 Then

                        UpdateAccountPayableRadioBroadcastDetailLineNumber(DbContext, RadioOrderDetails.Where(Function(T) T.TotalSpots > 0).First, AccountPayableRadioBroadcastDetail)
                        Matched = True

                    ElseIf RadioOrderDetails.Where(Function(T) T.TotalSpots > 0).Count = 0 Then

                        UpdateAccountPayableRadioBroadcastDetailLineNumber(DbContext, RadioOrderDetails.First, AccountPayableRadioBroadcastDetail)
                        Matched = True

                    End If

                End If

                If Matched = False AndAlso RadioOrderDetails.Count = 1 Then

                    UpdateAccountPayableRadioBroadcastDetailLineNumber(DbContext, RadioOrderDetails(0), AccountPayableRadioBroadcastDetail)
                    Matched = True

                    'ElseIf AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, AccountPayableRadioBroadcastDetail.OrderNumber).Count = 1 Then

                    '    LineNumber = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, AccountPayableRadioBroadcastDetail.OrderNumber).First.LineNumber

                    '    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", LineNumber, AccountPayableRadioBroadcastDetail.ID))

                    '    BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableRadioBroadcastDetail.ID AndAlso
                    '                                                                                               BODV.MediaType = "Radio").SingleOrDefault

                    '    If BroadcastOrderDetailVerification IsNot Nothing Then

                    '        BroadcastOrderDetailVerification.OrderLineNumber = LineNumber

                    '    End If

                End If

                If Matched = False Then

                    BroadcastOrderVerificationList = (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllEnabledRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList
                                                      Where Entity.StartDate <= AccountPayableRadioBroadcastDetail.RunDate AndAlso
                                                            Entity.EndDate >= AccountPayableRadioBroadcastDetail.RunDate AndAlso
                                                            ((IsNetOrder AndAlso Entity.GrossRate = AccountPayableRadioBroadcastDetail.NetRate) OrElse
                                                             (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableRadioBroadcastDetail.GrossRate))
                                                      Select Entity).ToList

                    If BroadcastOrderVerificationList.Where(Function(BOV) BOV.Spots.GetValueOrDefault(0) > 0 AndAlso BOV.WeekOf IsNot Nothing AndAlso BOV.WeekOf.Value <= AccountPayableRadioBroadcastDetail.RunDate).OrderBy(Function(BOV) DateDiff(DateInterval.Day, AccountPayableRadioBroadcastDetail.RunDate, BOV.WeekOf.Value)).Any Then

                        MatchedLinesList = (From BOV In BroadcastOrderVerificationList
                                            Where BOV.Spots.GetValueOrDefault(0) > 0 AndAlso
                                                  BOV.WeekOf IsNot Nothing AndAlso
                                                  BOV.WeekOf.Value <= AccountPayableRadioBroadcastDetail.RunDate
                                            Select New MatchedLines With {.Days = DateDiff(DateInterval.Day, BOV.WeekOf.Value, AccountPayableRadioBroadcastDetail.RunDate), .OrderLineNumber = BOV.OrderLineNumber}).ToList

                        If MatchedLinesList IsNot Nothing AndAlso MatchedLinesList.Count > 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber, AccountPayableRadioBroadcastDetail.ID))

                            BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableRadioBroadcastDetail.ID AndAlso
                                                                                                                       BODV.MediaType = "Radio").SingleOrDefault

                            If BroadcastOrderDetailVerification IsNot Nothing Then

                                BroadcastOrderDetailVerification.OrderLineNumber = MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber

                            End If

                        End If

                    End If

                End If

            Next

            AccountPayableTVBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Load(DbContext)
                                                Where OrderNumbers.Contains(Entity.OrderNumber) AndAlso
                                                      Entity.OrderLineNumber Is Nothing
                                                Select Entity).ToList

            If AccountPayableTVBroadcastDetails IsNot Nothing AndAlso AccountPayableTVBroadcastDetails.Count > 0 Then

                OrderAdjacencyList = LoadAdjacencyList(DbContext, AccountPayableTVBroadcastDetails.Select(Function(O) O.OrderNumber).Distinct.ToList, "T")

                AllTVOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumbers(DbContext, OrderNumbers).ToList
                                     Select Entity).ToList

                TVOrders = (From Entity In AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)
                            Where OrderNumbers.Contains(Entity.OrderNumber)
                            Select Entity).ToList

            End If

            For Each AccountPayableTVBroadcastDetail In AccountPayableTVBroadcastDetails

                Matched = False
                IsNetOrder = False

                TVOrder = TVOrders.Where(Function(T) T.OrderNumber = AccountPayableTVBroadcastDetail.OrderNumber).SingleOrDefault

                If TVOrder IsNot Nothing AndAlso TVOrder.NetGross.GetValueOrDefault(1) = 0 Then

                    IsNetOrder = True

                End If

                Adjacency = OrderAdjacencyList.Where(Function(AL) AL.OrderNumber = AccountPayableTVBroadcastDetail.OrderNumber).SingleOrDefault

                TVOrderDetails = (From Entity In AllTVOrderDetails
                                  Where Entity.TVOrderNumber = AccountPayableTVBroadcastDetail.OrderNumber AndAlso
                                        Entity.MinDate <= AccountPayableTVBroadcastDetail.RunDate AndAlso
                                        Entity.MaxDate >= AccountPayableTVBroadcastDetail.RunDate AndAlso
                                        ((IsNetOrder AndAlso Entity.NetRate = AccountPayableTVBroadcastDetail.NetRate) OrElse
                                         (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableTVBroadcastDetail.GrossRate)) AndAlso
                                        Entity.Length.GetValueOrDefault(0) = AccountPayableTVBroadcastDetail.Length AndAlso
                                        ((IsDate(Entity.StartTime) AndAlso IsDate(Entity.EndTime) AndAlso
                                         Entity.GetStartHourMinute(Adjacency.AdjacencyBefore) <= AccountPayableTVBroadcastDetail.HourMinute AndAlso
                                         Entity.GetEndHourMinute(Adjacency.AdjacencyAfter) >= AccountPayableTVBroadcastDetail.HourMinute) OrElse
                                         (Not IsDate(Entity.StartTime) AndAlso Not IsDate(Entity.EndTime))) AndAlso
                                         AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(AccountPayableTVBroadcastDetail.NetworkID).ToUpper = AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(Entity.NetworkID).ToUpper AndAlso
                                        (((Entity.Monday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 1) OrElse
                                          (Entity.Tuesday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 2) OrElse
                                          (Entity.Wednesday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 3) OrElse
                                          (Entity.Thursday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 4) OrElse
                                          (Entity.Friday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 5) OrElse
                                          (Entity.Saturday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 6) OrElse
                                          (Entity.Sunday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 7)) OrElse (AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 0))
                                  Select Entity).ToList

                If TVOrderDetails.Count > 1 Then

                    If TVOrderDetails.Where(Function(T) T.TotalSpots > 0).Count = 1 Then

                        UpdateAccountPayableTVBroadcastDetailLineNumber(DbContext, TVOrderDetails.Where(Function(T) T.TotalSpots > 0).First, AccountPayableTVBroadcastDetail)
                        Matched = True

                    ElseIf TVOrderDetails.Where(Function(T) T.TotalSpots > 0).Count > 1 Then

                        UpdateAccountPayableTVBroadcastDetailLineNumber(DbContext, TVOrderDetails.Where(Function(T) T.TotalSpots > 0).First, AccountPayableTVBroadcastDetail)
                        Matched = True

                    ElseIf TVOrderDetails.Where(Function(T) T.TotalSpots > 0).Count = 0 Then

                        UpdateAccountPayableTVBroadcastDetailLineNumber(DbContext, TVOrderDetails.First, AccountPayableTVBroadcastDetail)
                        Matched = True

                    End If

                End If

                If Matched = False AndAlso TVOrderDetails.Count = 1 Then

                    UpdateAccountPayableTVBroadcastDetailLineNumber(DbContext, TVOrderDetails.First, AccountPayableTVBroadcastDetail)
                    Matched = True

                    'ElseIf AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, AccountPayableTVBroadcastDetail.OrderNumber).Count = 1 Then

                    '    LineNumber = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, AccountPayableTVBroadcastDetail.OrderNumber).First.LineNumber

                    '    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", LineNumber, AccountPayableTVBroadcastDetail.ID))

                    '    BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableTVBroadcastDetail.ID AndAlso
                    '                                                                                               BODV.MediaType = "TV").SingleOrDefault

                    '    If BroadcastOrderDetailVerification IsNot Nothing Then

                    '        BroadcastOrderDetailVerification.OrderLineNumber = LineNumber

                    '    End If

                End If

                If Matched = False Then

                    BroadcastOrderVerificationList = (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllEnabledRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList
                                                      Where Entity.StartDate <= AccountPayableTVBroadcastDetail.RunDate AndAlso
                                                            Entity.EndDate >= AccountPayableTVBroadcastDetail.RunDate AndAlso
                                                            ((IsNetOrder AndAlso Entity.GrossRate = AccountPayableTVBroadcastDetail.NetRate) OrElse
                                                             (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableTVBroadcastDetail.GrossRate)) AndAlso
                                                            ((IsDate(Entity.StartTime) AndAlso IsDate(Entity.EndTime) AndAlso
                                                              CDate(Entity.StartTime).Hour <= AccountPayableTVBroadcastDetail.TimeOfDay.Hours AndAlso
                                                              CDate(Entity.EndTime).Hour >= AccountPayableTVBroadcastDetail.TimeOfDay.Hours) OrElse (Not IsDate(Entity.StartTime) AndAlso Not IsDate(Entity.EndTime))) AndAlso
                                                            AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(AccountPayableTVBroadcastDetail.NetworkID).ToUpper = AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(Entity.NetworkID).ToUpper
                                                      Select Entity).ToList

                    If BroadcastOrderVerificationList.Where(Function(BOV) BOV.Spots.GetValueOrDefault(0) > 0 AndAlso BOV.WeekOf IsNot Nothing AndAlso BOV.WeekOf.Value <= AccountPayableTVBroadcastDetail.RunDate).OrderBy(Function(BOV) DateDiff(DateInterval.Day, AccountPayableTVBroadcastDetail.RunDate, BOV.WeekOf.Value)).Any Then

                        MatchedLinesList = (From BOV In BroadcastOrderVerificationList
                                            Where BOV.Spots.GetValueOrDefault(0) > 0 AndAlso
                                                  BOV.WeekOf IsNot Nothing AndAlso
                                                  BOV.WeekOf.Value <= AccountPayableTVBroadcastDetail.RunDate
                                            Select New MatchedLines With {.Days = DateDiff(DateInterval.Day, BOV.WeekOf.Value, AccountPayableTVBroadcastDetail.RunDate), .OrderLineNumber = BOV.OrderLineNumber}).ToList

                        If MatchedLinesList IsNot Nothing AndAlso MatchedLinesList.Count > 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber, AccountPayableTVBroadcastDetail.ID))

                            BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableTVBroadcastDetail.ID AndAlso
                                                                                                                       BODV.MediaType = "TV").SingleOrDefault

                            If BroadcastOrderDetailVerification IsNot Nothing Then

                                BroadcastOrderDetailVerification.OrderLineNumber = MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber

                            End If

                        End If

                    End If

                End If

            Next

        End Sub
        Private Sub UpdateAccountPayableRadioBroadcastDetailLineNumber(DbContext As AdvantageFramework.Database.DbContext, RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail,
                                                                       AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

            Dim BroadcastOrderDetailVerification As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", RadioOrderDetail.LineNumber, AccountPayableRadioBroadcastDetail.ID))

            BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableRadioBroadcastDetail.ID AndAlso
                                                                                                       BODV.MediaType = "Radio").SingleOrDefault

            If BroadcastOrderDetailVerification IsNot Nothing Then

                BroadcastOrderDetailVerification.OrderLineNumber = RadioOrderDetail.LineNumber

            End If

        End Sub
        Private Sub UpdateAccountPayableTVBroadcastDetailLineNumber(DbContext As AdvantageFramework.Database.DbContext, TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail,
                                                                    AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

            Dim BroadcastOrderDetailVerification As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", TVOrderDetail.LineNumber, AccountPayableTVBroadcastDetail.ID))

            BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableTVBroadcastDetail.ID AndAlso
                                                                                                       BODV.MediaType = "TV").SingleOrDefault

            If BroadcastOrderDetailVerification IsNot Nothing Then

                BroadcastOrderDetailVerification.OrderLineNumber = TVOrderDetail.LineNumber

            End If

        End Sub
        Private Sub CalculateRatingsImpressions()

            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim Stream As String = Nothing
            Dim MediaBroadcastWorksheetMarketBook As AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook = Nothing
            Dim MediaBroadcastWorksheetMarketBookList As Generic.List(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing
            Dim WorksheetMarketVendors As Generic.List(Of DTO.Reporting.WorksheetMarketVendor) = Nothing
            Dim WorksheetMarketVendor As DTO.Reporting.WorksheetMarketVendor = Nothing
            Dim ParameterDictionary As Dictionary(Of String, Object) = Nothing
            Dim MediaBroadcastWorksheetPostBuyReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPostBuyReport) = Nothing
            Dim BroadcastOrderDetailVerification As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
            Dim BroadcastOrderVerifications As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) = Nothing
            Dim MediaBroadcastWorksheetRadioPostBuyReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport) = Nothing
            Dim ComscoreUseNewMarket As Boolean = False

            If Not _RatingsImpressionsCalculated AndAlso Me.SelectedTVInvoices IsNot Nothing AndAlso Me.SelectedTVInvoices.Count > 0 Then

                If _OrderWorksheetDetail.OrderIsOnWorksheet AndAlso _OrderWorksheetDetail.PrimaryMediaDemoID.HasValue AndAlso (ButtonItemInvoiceDetail_ShowGRPs.Checked OrElse ButtonItemInvoiceDetail_ShowIMPs.Checked) Then

                    Me.ShowWaitForm("Calculating...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComscoreUseNewMarket = True

                        MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, _OrderWorksheetDetail.MediaBroadcastWorksheetMarketID)

                        If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen AndAlso Session.IsNielsenSetup Then

                            Stream = "L3"

                            If MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

                                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                                    NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value)

                                    If NielsenTVBook IsNot Nothing Then

                                        Stream = NielsenTVBook.Stream

                                    End If

                                End Using

                            End If

                        ElseIf MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso Session.IsComscoreSetup Then

                            Stream = "LO"

                        End If

                        MediaBroadcastWorksheetMarketBookList = New Generic.List(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

                        MediaBroadcastWorksheetMarketBook = New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(MediaBroadcastWorksheetMarket, ComscoreUseNewMarket)

                        MediaBroadcastWorksheetMarketBook.IsFromMediaManager = True

                        MediaBroadcastWorksheetMarketBookList.Add(MediaBroadcastWorksheetMarketBook)

                        WorksheetMarketVendors = New Generic.List(Of DTO.Reporting.WorksheetMarketVendor)

                        For Each MediaBroadcastWorksheetMarketDetail In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Where(Function(MBWMD) MBWMD.VendorCode = _BroadcastOrderDetailVerifications.First.VendorCode).Distinct.ToList

                            WorksheetMarketVendor = New DTO.Reporting.WorksheetMarketVendor(MediaBroadcastWorksheetMarketDetail)

                            If Not (From Entity In WorksheetMarketVendors
                                    Where Entity.MediaBroadcastWorksheetMarketID = WorksheetMarketVendor.MediaBroadcastWorksheetMarketID AndAlso
                                          Entity.VendorCode = WorksheetMarketVendor.VendorCode).Any Then

                                WorksheetMarketVendors.Add(WorksheetMarketVendor)

                            End If

                        Next

                        ParameterDictionary = New Dictionary(Of String, Object)
                        ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.Session.ToString) = Session
                        ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.MediaBroadcastWorksheetMarketBooks.ToString) = MediaBroadcastWorksheetMarketBookList
                        ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString) = WorksheetMarketVendors

                        MediaBroadcastWorksheetPostBuyReports = AdvantageFramework.Reporting.LoadMediaBroadcastWorksheetPostBuyData(DbContext, ParameterDictionary, False, Stream)

                        For Each MediaBroadcastWorksheetPostBuyReport In MediaBroadcastWorksheetPostBuyReports

                            If MediaBroadcastWorksheetPostBuyReport.DetailID.HasValue Then

                                BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(V) V.DetailID = MediaBroadcastWorksheetPostBuyReport.DetailID.Value).SingleOrDefault

                                If BroadcastOrderDetailVerification IsNot Nothing Then

                                    BroadcastOrderDetailVerification.EstimatedGRP = MediaBroadcastWorksheetPostBuyReport.DetailEstimateRating
                                    BroadcastOrderDetailVerification.EstimatedImpressions = MediaBroadcastWorksheetPostBuyReport.DetailEstimateImpression

                                    If MediaBroadcastWorksheetPostBuyReport.OverridePost Then

                                        BroadcastOrderDetailVerification.ActualGRP = MediaBroadcastWorksheetPostBuyReport.DetailEstimateRating

                                        If BroadcastOrderDetailVerification.EstimatedGRP = 0 Then

                                            BroadcastOrderDetailVerification.RatingIndex = 0

                                        Else

                                            BroadcastOrderDetailVerification.RatingIndex = BroadcastOrderDetailVerification.ActualGRP / BroadcastOrderDetailVerification.EstimatedGRP * 100

                                        End If

                                    Else

                                        BroadcastOrderDetailVerification.ActualGRP = MediaBroadcastWorksheetPostBuyReport.DetailActualRating

                                        BroadcastOrderDetailVerification.RatingIndex = MediaBroadcastWorksheetPostBuyReport.DetailActualRatingIndex

                                    End If

                                    If MediaBroadcastWorksheetPostBuyReport.OverridePostImpressions Then

                                        BroadcastOrderDetailVerification.ActualImpressions = MediaBroadcastWorksheetPostBuyReport.DetailEstimateImpression

                                        If BroadcastOrderDetailVerification.EstimatedGRP = 0 Then

                                            BroadcastOrderDetailVerification.ImpressionIndex = 0

                                        Else

                                            BroadcastOrderDetailVerification.ImpressionIndex = BroadcastOrderDetailVerification.ActualImpressions / BroadcastOrderDetailVerification.EstimatedImpressions * 100

                                        End If

                                    Else

                                        BroadcastOrderDetailVerification.ActualImpressions = MediaBroadcastWorksheetPostBuyReport.DetailActualImpression

                                        BroadcastOrderDetailVerification.ImpressionIndex = MediaBroadcastWorksheetPostBuyReport.DetailActualImpressionIndex

                                    End If

                                    BroadcastOrderDetailVerification.Book = MediaBroadcastWorksheetPostBuyReport.BookName

                                End If

                            End If

                        Next

                        BroadcastOrderVerifications = DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                        For Each BroadcastOrderVerification In BroadcastOrderVerifications.Where(Function(BOV) BOV.ActualSpots.GetValueOrDefault(0) = 0)

                            BroadcastOrderVerification.EstimatedGRP = Nothing
                            BroadcastOrderVerification.EstimatedImpressions = Nothing

                        Next

                        For Each BroadcastOrderVerification In BroadcastOrderVerifications.Where(Function(BOV) BOV.ActualSpots.GetValueOrDefault(0) > 0)

                            If ButtonItemInvoiceDetail_ShowWeeks.Checked Then

                                BroadcastOrderVerification.ActualGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                            D.OrderLineNumber.HasValue AndAlso
                                                                                                                            BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                            D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                            D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.ActualGRP)

                                BroadcastOrderVerification.ActualImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                    D.OrderLineNumber.HasValue AndAlso
                                                                                                                                    BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                    D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                    D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.ActualImpressions)

                                If _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                        D.OrderLineNumber.HasValue AndAlso
                                                                                        BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                        D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                        D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Any Then

                                    BroadcastOrderVerification.EstimatedGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                   D.OrderLineNumber.HasValue AndAlso
                                                                                                                                   BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                   D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                   D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.EstimatedGRP)

                                    BroadcastOrderVerification.EstimatedImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                           D.OrderLineNumber.HasValue AndAlso
                                                                                                                                           BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                           D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                           D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.EstimatedImpressions)

                                End If

                            Else

                                BroadcastOrderVerification.ActualGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                            D.OrderLineNumber.HasValue AndAlso
                                                                                                                            BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                            D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.ActualGRP)

                                BroadcastOrderVerification.ActualImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                    D.OrderLineNumber.HasValue AndAlso
                                                                                                                                    BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                    D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.ActualImpressions)

                                If _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                        D.OrderLineNumber.HasValue AndAlso
                                                                                        BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                        D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Any Then

                                    BroadcastOrderVerification.EstimatedGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                   D.OrderLineNumber.HasValue AndAlso
                                                                                                                                   BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                   D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.EstimatedGRP)

                                    BroadcastOrderVerification.EstimatedImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                           D.OrderLineNumber.HasValue AndAlso
                                                                                                                                           BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                           D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.EstimatedImpressions)

                                End If

                            End If

                            If BroadcastOrderVerification.EstimatedGRP.GetValueOrDefault(0) = 0 Then

                                BroadcastOrderVerification.RatingIndex = 0

                            Else

                                BroadcastOrderVerification.RatingIndex = Strings.FormatNumber(BroadcastOrderVerification.ActualGRP.GetValueOrDefault(0) / BroadcastOrderVerification.EstimatedGRP.GetValueOrDefault(0) * 100, 0)

                            End If

                            If BroadcastOrderVerification.EstimatedImpressions.GetValueOrDefault(0) = 0 Then

                                BroadcastOrderVerification.ImpressionIndex = 0

                            Else

                                BroadcastOrderVerification.ImpressionIndex = Strings.FormatNumber(BroadcastOrderVerification.ActualImpressions.GetValueOrDefault(0) / BroadcastOrderVerification.EstimatedImpressions.GetValueOrDefault(0) * 100, 0)

                            End If

                        Next

                        _RatingsImpressionsCalculated = True

                    End Using

                    Me.CloseWaitForm()

                End If

            ElseIf Not _RatingsImpressionsCalculated AndAlso Me.SelectedRadioInvoices IsNot Nothing AndAlso Me.SelectedRadioInvoices.Count > 0 Then

                If _OrderWorksheetDetail.OrderIsOnWorksheet AndAlso _OrderWorksheetDetail.PrimaryMediaDemoID.HasValue AndAlso (ButtonItemInvoiceDetail_ShowGRPs.Checked OrElse ButtonItemInvoiceDetail_ShowIMPs.Checked) Then

                    Me.ShowWaitForm("Calculating...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, _OrderWorksheetDetail.MediaBroadcastWorksheetMarketID)

                        If (MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen AndAlso Session.IsNielsenSetup) OrElse
                                (MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso Session.IsEastlanSetup) Then

                            MediaBroadcastWorksheetMarketBookList = New Generic.List(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

                            MediaBroadcastWorksheetMarketBook = New DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook(MediaBroadcastWorksheetMarket, ComscoreUseNewMarket)

                            MediaBroadcastWorksheetMarketBook.IsFromMediaManager = True

                            MediaBroadcastWorksheetMarketBookList.Add(MediaBroadcastWorksheetMarketBook)

                            WorksheetMarketVendors = New Generic.List(Of DTO.Reporting.WorksheetMarketVendor)

                            For Each MediaBroadcastWorksheetMarketDetail In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Where(Function(MBWMD) MBWMD.VendorCode = _BroadcastOrderDetailVerifications.First.VendorCode).Distinct.ToList

                                WorksheetMarketVendor = New DTO.Reporting.WorksheetMarketVendor(MediaBroadcastWorksheetMarketDetail)

                                If Not (From Entity In WorksheetMarketVendors
                                        Where Entity.MediaBroadcastWorksheetMarketID = WorksheetMarketVendor.MediaBroadcastWorksheetMarketID AndAlso
                                              Entity.VendorCode = WorksheetMarketVendor.VendorCode).Any Then

                                    WorksheetMarketVendors.Add(WorksheetMarketVendor)

                                End If

                            Next

                            ParameterDictionary = New Dictionary(Of String, Object)
                            ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.Session.ToString) = Session
                            ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.MediaBroadcastWorksheetMarketBooks.ToString) = MediaBroadcastWorksheetMarketBookList
                            ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString) = WorksheetMarketVendors

                            MediaBroadcastWorksheetRadioPostBuyReports = AdvantageFramework.Reporting.LoadMediaBroadcastWorksheetRadioPostBuyData(DbContext, ParameterDictionary, False)

                            For Each MediaBroadcastWorksheetRadioPostBuyReport In MediaBroadcastWorksheetRadioPostBuyReports

                                If MediaBroadcastWorksheetRadioPostBuyReport.DetailID.HasValue Then

                                    BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(V) V.DetailID = MediaBroadcastWorksheetRadioPostBuyReport.DetailID.Value).SingleOrDefault

                                    If BroadcastOrderDetailVerification IsNot Nothing Then

                                        BroadcastOrderDetailVerification.EstimatedGRP = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateRating
                                        BroadcastOrderDetailVerification.EstimatedImpressions = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateImpression

                                        If ((MediaBroadcastWorksheetMarketBook.UseImpressions = False AndAlso MediaBroadcastWorksheetRadioPostBuyReport.OverridePost = False) OrElse
                                            (MediaBroadcastWorksheetMarketBook.UseImpressions AndAlso MediaBroadcastWorksheetRadioPostBuyReport.OverridePostAQH = False)) Then

                                            BroadcastOrderDetailVerification.ActualGRP = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualRating
                                            BroadcastOrderDetailVerification.ActualImpressions = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualImpression

                                            BroadcastOrderDetailVerification.RatingIndex = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualRatingIndex

                                            BroadcastOrderDetailVerification.ImpressionIndex = MediaBroadcastWorksheetRadioPostBuyReport.DetailActualImpressionIndex

                                        Else

                                            BroadcastOrderDetailVerification.ActualGRP = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateRating
                                            BroadcastOrderDetailVerification.ActualImpressions = MediaBroadcastWorksheetRadioPostBuyReport.DetailEstimateImpression

                                            If BroadcastOrderDetailVerification.EstimatedGRP = 0 Then

                                                BroadcastOrderDetailVerification.RatingIndex = 0

                                            Else

                                                BroadcastOrderDetailVerification.RatingIndex = BroadcastOrderDetailVerification.ActualGRP / BroadcastOrderDetailVerification.EstimatedGRP * 100

                                            End If

                                            If BroadcastOrderDetailVerification.EstimatedGRP = 0 Then

                                                BroadcastOrderDetailVerification.ImpressionIndex = 0

                                            Else

                                                BroadcastOrderDetailVerification.ImpressionIndex = BroadcastOrderDetailVerification.ActualImpressions / BroadcastOrderDetailVerification.EstimatedImpressions * 100

                                            End If

                                        End If

                                        BroadcastOrderDetailVerification.Book = MediaBroadcastWorksheetRadioPostBuyReport.BookName

                                    End If

                                End If

                            Next

                            BroadcastOrderVerifications = DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                            For Each BroadcastOrderVerification In BroadcastOrderVerifications.Where(Function(BOV) BOV.ActualSpots.GetValueOrDefault(0) = 0)

                                BroadcastOrderVerification.EstimatedGRP = Nothing
                                BroadcastOrderVerification.EstimatedImpressions = Nothing

                            Next

                            For Each BroadcastOrderVerification In BroadcastOrderVerifications.Where(Function(BOV) BOV.ActualSpots.GetValueOrDefault(0) > 0)

                                If ButtonItemInvoiceDetail_ShowWeeks.Checked Then

                                    BroadcastOrderVerification.ActualGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                D.OrderLineNumber.HasValue AndAlso
                                                                                                                                BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.ActualGRP)

                                    BroadcastOrderVerification.ActualImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                        D.OrderLineNumber.HasValue AndAlso
                                                                                                                                        BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                        D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                        D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.ActualImpressions)

                                    If _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                            D.OrderLineNumber.HasValue AndAlso
                                                                                            BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                            D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                            D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Any Then

                                        BroadcastOrderVerification.EstimatedGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                       D.OrderLineNumber.HasValue AndAlso
                                                                                                                                       BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                       D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                       D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.EstimatedGRP)

                                        BroadcastOrderVerification.EstimatedImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                               D.OrderLineNumber.HasValue AndAlso
                                                                                                                                               BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                               D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso
                                                                                                                                               D.WeekOf.GetValueOrDefault("01/01/1901").Equals(BroadcastOrderVerification.WeekOf.GetValueOrDefault("01/01/1901"))).Sum(Function(D) D.EstimatedImpressions)

                                    End If

                                Else

                                    BroadcastOrderVerification.ActualGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                D.OrderLineNumber.HasValue AndAlso
                                                                                                                                BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.ActualGRP)

                                    BroadcastOrderVerification.ActualImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                        D.OrderLineNumber.HasValue AndAlso
                                                                                                                                        BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                        D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.ActualImpressions)

                                    If _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                            D.OrderLineNumber.HasValue AndAlso
                                                                                            BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                            D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Any Then

                                        BroadcastOrderVerification.EstimatedGRP = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                       D.OrderLineNumber.HasValue AndAlso
                                                                                                                                       BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                       D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.EstimatedGRP)

                                        BroadcastOrderVerification.EstimatedImpressions = _BroadcastOrderDetailVerifications.Where(Function(D) D.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso
                                                                                                                                               D.OrderLineNumber.HasValue AndAlso
                                                                                                                                               BroadcastOrderVerification.OrderLineNumber.HasValue AndAlso
                                                                                                                                               D.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber).Sum(Function(D) D.EstimatedImpressions)

                                    End If

                                End If

                                If BroadcastOrderVerification.EstimatedGRP.GetValueOrDefault(0) = 0 Then

                                    BroadcastOrderVerification.RatingIndex = 0

                                Else

                                    BroadcastOrderVerification.RatingIndex = Strings.FormatNumber(BroadcastOrderVerification.ActualGRP.GetValueOrDefault(0) / BroadcastOrderVerification.EstimatedGRP.GetValueOrDefault(0) * 100, 0)

                                End If

                                If BroadcastOrderVerification.EstimatedImpressions.GetValueOrDefault(0) = 0 Then

                                    BroadcastOrderVerification.ImpressionIndex = 0

                                Else

                                    BroadcastOrderVerification.ImpressionIndex = Strings.FormatNumber(BroadcastOrderVerification.ActualImpressions.GetValueOrDefault(0) / BroadcastOrderVerification.EstimatedImpressions.GetValueOrDefault(0) * 100, 0)

                                End If

                            Next

                            _RatingsImpressionsCalculated = True

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

            ToggleColumnVisibility()

        End Sub
        Private Sub ToggleColumnVisibility()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0

            DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.OptionsView.ShowFooter = (ButtonItemInvoiceDetail_ShowGRPs.Checked OrElse ButtonItemInvoiceDetail_ShowIMPs.Checked)

            DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.OptionsView.ShowFooter = (ButtonItemInvoiceDetail_ShowGRPs.Checked OrElse ButtonItemInvoiceDetail_ShowIMPs.Checked)

            For Each GridColumn In DataGridViewInvoiceDetailMatching_OrderLines.Columns

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification), GridColumn.FieldName) Then

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedGRP.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualGRP.ToString Then

                        If ButtonItemInvoiceDetail_ShowGRPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.RatingIndex.ToString Then

                        If ButtonItemInvoiceDetail_ShowGRPs.Checked AndAlso ButtonItemInvoiceDetail_ShowIMPs.Checked Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf ButtonItemInvoiceDetail_ShowGRPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedImpressions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualImpressions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ImpressionIndex.ToString Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedImpressions.ToString Then

                            If _IsRadio Then

                                GridColumn.Caption = "Est GIMP" & vbCrLf & "(00)"

                            Else

                                GridColumn.Caption = "Est GIMP" & vbCrLf & "(000)"

                            End If

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualImpressions.ToString Then

                            If _IsRadio Then

                                GridColumn.Caption = "Act GIMP" & vbCrLf & "(00)"

                            Else

                                GridColumn.Caption = "Act GIMP" & vbCrLf & "(000)"

                            End If

                        End If

                        If ButtonItemInvoiceDetail_ShowIMPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.WeekOf.ToString Then

                        If ButtonItemInvoiceDetail_ShowWeeks.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.NetworkID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Program.ToString Then

                        If Me.SelectedRadioInvoices IsNot Nothing AndAlso Me.SelectedRadioInvoices.Count > 0 Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                    End If

                End If

            Next

            For Each GridColumn In DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns

                If AdvantageFramework.WinForm.Presentation.Controls.EntityColumnShowsInGrid(GetType(AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification), GridColumn.FieldName) Then

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedGRP.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualGRP.ToString Then

                        If ButtonItemInvoiceDetail_ShowGRPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RatingIndex.ToString Then

                        If ButtonItemInvoiceDetail_ShowGRPs.Checked AndAlso ButtonItemInvoiceDetail_ShowIMPs.Checked Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf ButtonItemInvoiceDetail_ShowGRPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedImpressions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualImpressions.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ImpressionIndex.ToString Then

                        If GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedImpressions.ToString Then

                            If _IsRadio Then

                                GridColumn.Caption = "Est AQH" & vbCrLf & "(00)"

                            Else

                                GridColumn.Caption = "Est GIMP" & vbCrLf & "(000)"

                            End If

                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualImpressions.ToString Then

                            If _IsRadio Then

                                GridColumn.Caption = "Act AQH" & vbCrLf & "(00)"

                            Else

                                GridColumn.Caption = "Act GIMP" & vbCrLf & "(000)"

                            End If

                        ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ImpressionIndex.ToString Then

                            If _IsRadio Then

                                GridColumn.Caption = "AQH Index"

                            Else

                                GridColumn.Caption = "GIMP Index"

                            End If

                        End If

                        If ButtonItemInvoiceDetail_ShowIMPs.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.WeekOf.ToString Then

                        If ButtonItemInvoiceDetail_ShowWeeks.Checked Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Book.ToString Then

                        If _OrderWorksheetDetail.RatingsService <> Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore.ToString AndAlso (ButtonItemInvoiceDetail_ShowIMPs.Checked OrElse ButtonItemInvoiceDetail_ShowGRPs.Checked) Then

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        Else

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        End If

                    Else

                        GridColumn.VisibleIndex = VisibleIndex
                        VisibleIndex += 1
                        GridColumn.Visible = True

                    End If

                End If

            Next

            DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.BestFitColumns()
            DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.UpdateSummary()

            DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.BestFitColumns()
            DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.UpdateSummary()

        End Sub
        Private Function LoadAdjacencyList(DbContext As AdvantageFramework.Database.DbContext, OrderNumbers As Generic.List(Of Integer), MediaType As String) As Generic.List(Of AdvantageFramework.Media.Presentation.OrderAdjacency)

            'objects
            Dim SqlParameterOrderNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderNumbers = New System.Data.SqlClient.SqlParameter("@ORDER_NUMBERS", SqlDbType.VarChar)
            SqlParameterMediaType = New System.Data.SqlClient.SqlParameter("@MEDIA_TYPE", SqlDbType.Char)

            SqlParameterOrderNumbers.Value = String.Join(",", OrderNumbers.ToArray)
            SqlParameterMediaType.Value = MediaType

            LoadAdjacencyList = DbContext.Database.SqlQuery(Of AdvantageFramework.Media.Presentation.OrderAdjacency)("EXEC advsp_get_spot_matching_adjacency_settings @ORDER_NUMBERS, @MEDIA_TYPE",
                                                                                 SqlParameterOrderNumbers, SqlParameterMediaType).ToList

        End Function
        'Private Function RefineVarianceSpots(DbContext As AdvantageFramework.Database.DbContext) As Boolean

        '    Dim RefineBroadcastOrderVerificationList As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) = Nothing
        '    Dim IsNetOrder As Boolean = False
        '    Dim AccountPayableRadioBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail) = Nothing
        '    Dim AccountPayableTVBroadcastDetails As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail) = Nothing
        '    Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
        '    Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
        '    Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
        '    Dim BroadcastOrderVerificationList As Generic.List(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification) = Nothing
        '    Dim MatchedLinesList As Generic.List(Of MatchedLines) = Nothing
        '    Dim BroadcastOrderDetailVerification As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
        '    Dim Refined As Boolean = False

        '    RefineBroadcastOrderVerificationList = (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
        '                                            Where Entity.Variance > 0
        '                                            Select Entity).ToList

        '    If RefineBroadcastOrderVerificationList.Count > 0 Then

        '        For Each RefineBroadcastOrderVerification In (From Entity In RefineBroadcastOrderVerificationList
        '                                                      Select Entity.OrderNumber, Entity.OrderLineNumber).Distinct.ToList

        '            AccountPayableRadioBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Load(DbContext)
        '                                                   Where Entity.OrderNumber = RefineBroadcastOrderVerification.OrderNumber AndAlso
        '                                                         Entity.OrderLineNumber = RefineBroadcastOrderVerification.OrderLineNumber
        '                                                   Select Entity).ToList

        '            For Each AccountPayableRadioBroadcastDetail In AccountPayableRadioBroadcastDetails

        '                IsNetOrder = False

        '                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, AccountPayableRadioBroadcastDetail.OrderNumber)

        '                If RadioOrder IsNot Nothing AndAlso RadioOrder.NetGross.GetValueOrDefault(1) = 0 Then

        '                    IsNetOrder = True

        '                End If

        '                BroadcastOrderVerificationList = (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllEnabledRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList
        '                                                  Where Entity.StartDate <= AccountPayableRadioBroadcastDetail.RunDate AndAlso
        '                                                        Entity.EndDate >= AccountPayableRadioBroadcastDetail.RunDate AndAlso
        '                                                        ((IsNetOrder AndAlso Entity.GrossRate = AccountPayableRadioBroadcastDetail.NetRate) OrElse
        '                                                         (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableRadioBroadcastDetail.GrossRate)) AndAlso
        '                                                        Entity.Length.GetValueOrDefault(0) = AccountPayableRadioBroadcastDetail.Length AndAlso
        '                                                        ((IsDate(Entity.StartTime) AndAlso IsDate(Entity.EndTime) AndAlso
        '                                                          CDate(Entity.StartTime).Hour <= AccountPayableRadioBroadcastDetail.TimeOfDay.Hours AndAlso
        '                                                          CDate(Entity.EndTime).Hour >= AccountPayableRadioBroadcastDetail.TimeOfDay.Hours) OrElse (Not IsDate(Entity.StartTime) AndAlso Not IsDate(Entity.EndTime))) AndAlso
        '                                                        (((Entity.Monday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 1) OrElse
        '                                                         (Entity.Tuesday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 2) OrElse
        '                                                         (Entity.Wednesday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 3) OrElse
        '                                                         (Entity.Thursday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 4) OrElse
        '                                                         (Entity.Friday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 5) OrElse
        '                                                         (Entity.Saturday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 6) OrElse
        '                                                         (Entity.Sunday = 1 AndAlso AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 7)) OrElse (AccountPayableRadioBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 0))
        '                                                  Select Entity).ToList

        '                If BroadcastOrderVerificationList.Where(Function(BOV) BOV.Spots.GetValueOrDefault(0) > 0 AndAlso BOV.WeekOf IsNot Nothing AndAlso BOV.WeekOf.Value <= AccountPayableRadioBroadcastDetail.RunDate).OrderBy(Function(BOV) DateDiff(DateInterval.Day, AccountPayableRadioBroadcastDetail.RunDate, BOV.WeekOf.Value)).Any Then

        '                    MatchedLinesList = (From BOV In BroadcastOrderVerificationList
        '                                        Where BOV.Spots.GetValueOrDefault(0) > 0 AndAlso
        '                                              BOV.WeekOf IsNot Nothing AndAlso
        '                                              BOV.WeekOf.Value <= AccountPayableRadioBroadcastDetail.RunDate
        '                                        Select New MatchedLines With {.Days = DateDiff(DateInterval.Day, BOV.WeekOf.Value, AccountPayableRadioBroadcastDetail.RunDate), .OrderLineNumber = BOV.OrderLineNumber}).ToList

        '                    If MatchedLinesList IsNot Nothing AndAlso MatchedLinesList.Count > 0 Then

        '                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber, AccountPayableRadioBroadcastDetail.ID))

        '                        BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableRadioBroadcastDetail.ID AndAlso
        '                                                                                                                   BODV.MediaType = "Radio").SingleOrDefault

        '                        If BroadcastOrderDetailVerification IsNot Nothing Then

        '                            BroadcastOrderDetailVerification.OrderLineNumber = MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber

        '                            Refined = True

        '                        End If

        '                    End If

        '                End If

        '            Next

        '            AccountPayableTVBroadcastDetails = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Load(DbContext)
        '                                                Where Entity.OrderNumber = RefineBroadcastOrderVerification.OrderNumber AndAlso
        '                                                      Entity.OrderLineNumber = RefineBroadcastOrderVerification.OrderLineNumber
        '                                                Select Entity).ToList

        '            For Each AccountPayableTVBroadcastDetail In AccountPayableTVBroadcastDetails

        '                IsNetOrder = False

        '                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, AccountPayableTVBroadcastDetail.OrderNumber)

        '                If TVOrder IsNot Nothing AndAlso TVOrder.NetGross.GetValueOrDefault(1) = 0 Then

        '                    IsNetOrder = True

        '                End If

        '                BroadcastOrderVerificationList = (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllEnabledRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList
        '                                                  Where Entity.StartDate <= AccountPayableTVBroadcastDetail.RunDate AndAlso
        '                                                        Entity.EndDate >= AccountPayableTVBroadcastDetail.RunDate AndAlso
        '                                                        ((IsNetOrder AndAlso Entity.GrossRate = AccountPayableTVBroadcastDetail.NetRate) OrElse
        '                                                         (IsNetOrder = False AndAlso Entity.GrossRate = AccountPayableTVBroadcastDetail.GrossRate)) AndAlso
        '                                                        Entity.Length.GetValueOrDefault(0) = AccountPayableTVBroadcastDetail.Length AndAlso
        '                                                        ((IsDate(Entity.StartTime) AndAlso IsDate(Entity.EndTime) AndAlso
        '                                                          CDate(Entity.StartTime).Hour <= AccountPayableTVBroadcastDetail.TimeOfDay.Hours AndAlso
        '                                                          CDate(Entity.EndTime).Hour >= AccountPayableTVBroadcastDetail.TimeOfDay.Hours) OrElse (Not IsDate(Entity.StartTime) AndAlso Not IsDate(Entity.EndTime))) AndAlso
        '                                                        AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(AccountPayableTVBroadcastDetail.NetworkID).ToUpper = AdvantageFramework.StringUtilities.ToEmptyStringIfNullOrWhiteSpace(Entity.NetworkID).ToUpper AndAlso
        '                                                        (((Entity.Monday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 1) OrElse
        '                                                         (Entity.Tuesday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 2) OrElse
        '                                                         (Entity.Wednesday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 3) OrElse
        '                                                         (Entity.Thursday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 4) OrElse
        '                                                         (Entity.Friday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 5) OrElse
        '                                                         (Entity.Saturday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 6) OrElse
        '                                                         (Entity.Sunday = 1 AndAlso AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 7)) OrElse (AccountPayableTVBroadcastDetail.DayOfWeek.GetValueOrDefault(0) = 0))
        '                                                  Select Entity).ToList

        '                If BroadcastOrderVerificationList.Where(Function(BOV) BOV.Spots.GetValueOrDefault(0) > 0 AndAlso BOV.WeekOf IsNot Nothing AndAlso BOV.WeekOf.Value <= AccountPayableTVBroadcastDetail.RunDate).OrderBy(Function(BOV) DateDiff(DateInterval.Day, AccountPayableTVBroadcastDetail.RunDate, BOV.WeekOf.Value)).Any Then

        '                    MatchedLinesList = (From BOV In BroadcastOrderVerificationList
        '                                        Where BOV.Spots.GetValueOrDefault(0) > 0 AndAlso
        '                                              BOV.WeekOf IsNot Nothing AndAlso
        '                                              BOV.WeekOf.Value <= AccountPayableTVBroadcastDetail.RunDate
        '                                        Select New MatchedLines With {.Days = DateDiff(DateInterval.Day, BOV.WeekOf.Value, AccountPayableTVBroadcastDetail.RunDate), .OrderLineNumber = BOV.OrderLineNumber}).ToList

        '                    If MatchedLinesList IsNot Nothing AndAlso MatchedLinesList.Count > 0 Then

        '                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = {0} WHERE DTL_ID = {1}", MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber, AccountPayableTVBroadcastDetail.ID))

        '                        BroadcastOrderDetailVerification = _BroadcastOrderDetailVerifications.Where(Function(BODV) BODV.DetailID = AccountPayableTVBroadcastDetail.ID AndAlso
        '                                                                                                                   BODV.MediaType = "TV").SingleOrDefault

        '                        If BroadcastOrderDetailVerification IsNot Nothing Then

        '                            BroadcastOrderDetailVerification.OrderLineNumber = MatchedLinesList.OrderBy(Function(ML) ML.Days).First.OrderLineNumber

        '                            Refined = True

        '                        End If

        '                    End If

        '                End If

        '            Next

        '        Next

        '    End If

        '    RefineVarianceSpots = Refined

        'End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OrderNumberLineNumbers As IEnumerable(Of String),
                                              ByRef OrderLine As Integer?, ByRef LineNumber As Short?, ByRef OrderUpdated As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerApproveInvoicesDialog As AdvantageFramework.Media.Presentation.MediaManagerApproveInvoicesDialog = Nothing

            MediaManagerApproveInvoicesDialog = New AdvantageFramework.Media.Presentation.MediaManagerApproveInvoicesDialog(OrderNumberLineNumbers)

            ShowFormDialog = MediaManagerApproveInvoicesDialog.ShowDialog()

            If MediaManagerApproveInvoicesDialog.DialogResult = Windows.Forms.DialogResult.Abort AndAlso MediaManagerApproveInvoicesDialog.GoToApproveInvoice IsNot Nothing Then

                OrderLine = MediaManagerApproveInvoicesDialog.GoToApproveInvoice.OrderNumber
                LineNumber = MediaManagerApproveInvoicesDialog.GoToApproveInvoice.LineNumber

            End If

            OrderUpdated = MediaManagerApproveInvoicesDialog.OrderUpdated

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerApproveInvoicesDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            SaveMediaManagerApproveInvoiceView()

        End Sub
        Private Sub MediaManagerApproveInvoicesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_GoToOrder.Image = AdvantageFramework.My.Resources.ExitImage

            ButtonItemView_ShowGross.Image = AdvantageFramework.My.Resources.ShowFieldListImage
            ButtonItemView_ShowNet.Image = AdvantageFramework.My.Resources.ShowFieldListImage
            ButtonItemView_ShowBoth.Image = AdvantageFramework.My.Resources.ShowFieldListImage

            ButtonItemFilter_HasVariance.Image = AdvantageFramework.My.Resources.FilterImage
            ButtonItemFilter_Unapproved.Image = AdvantageFramework.My.Resources.FilterImage

            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemUpload_EmailLink.Icon = AdvantageFramework.My.Resources.EmailSendIcon
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            ButtonItemInvoiceDetail_ShowAll.Image = AdvantageFramework.My.Resources.ShowAllColumnsImage
            ButtonItemInvoiceDetail_ShowWeeks.Image = AdvantageFramework.My.Resources.CalendarWeekImage
            ButtonItemInvoiceDetail_Approve.Image = AdvantageFramework.My.Resources.ApproveImage
            ButtonItemInvoiceDetail_Unapprove.Image = AdvantageFramework.My.Resources.UnapproveImage
            ButtonItemInvoiceDetail_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage
            ButtonItemInvoiceDetail_Rematch.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemSpotDetail_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemSpotDetail_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            DataGridViewInvoices_Orders.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewInvoices_Orders.MultiSelect = False
            DataGridViewInvoices_Orders.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder))

            DataGridViewInvoiceDetails_InvoiceDetails.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewInvoiceDetails_InvoiceDetails.ShowSelectDeselectAllButtons = True
            DataGridViewInvoiceDetails_InvoiceDetails.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice))

            DataGridViewInvoiceDetailMatching_OrderLines.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewInvoiceDetailMatching_OrderLines.ShowSelectDeselectAllButtons = True

            DataGridViewInvoiceDetailMatching_InvoiceDetails.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewInvoiceDetailMatching_InvoiceDetails.ShowSelectDeselectAllButtons = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            Try

                GridColumn = DataGridViewInvoiceDetails_InvoiceDetails.Columns.ColumnByFieldName(AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalStatus.ToString)

                If GridColumn IsNot Nothing Then

                    SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                GridColumn.FieldName, Nothing, Nothing,
                                                                                                                                GetType(AdvantageFramework.Database.Entities.MediaApprovalStatus), True)

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                        SubItemGridLookUpEditControl.ValueType = GetType(Short)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                            End Using

                        End Using

                        DataGridViewInvoiceDetails_InvoiceDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                        GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                    End If

                End If

            Catch ex As Exception

            End Try

            ComboBoxApprovalStatus_Status.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatus)).ToList
                                                        Select [Name] = EnumObject.Description,
                                                               [Value] = EnumObject.Code).ToList

            ComboBoxApprovalStatus_Status.ByPassUserEntryChanged = True

            _ModifiedOrderLines = New List(Of String)

        End Sub
        Private Sub MediaManagerApproveInvoicesDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ButtonItemInvoiceDetail_ShowWeeks.Checked = True

            LoadGrid()

            LoadInvoices()

            SetMediaManagerApproveInvoiceView()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub MediaManagerApproveInvoicesDialog_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SelectedDocumentChanged() Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SelectedDocumentChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SelectedTabChanged() Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SpotDetailInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SpotDetailInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ApInvoiceControlAPInvoiceDetail_APInvoiceDetail_SpotDetailSelectionChangedEvent(sender As Object, e As EventArgs) Handles ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SpotDetailSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) Then

                LoadSpotVerificationTab()

            ElseIf TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                LoadAPInvoicesDetailTab()

            End If

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_GoToOrder_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_GoToOrder.Click

            If DataGridViewInvoiceDetails_InvoiceDetails.HasASelectedRow Then

                _GoToApproveInvoice = DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.GetRow(DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.FocusedRowHandle)
                Me.DialogResult = Windows.Forms.DialogResult.Abort

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetail) Then

                SaveApprovedInvoices()

            ElseIf TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) Then

                UpdateOrder()

            ElseIf TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SaveSpotDetail()

                TabItemInvoiceItems_InvoiceDetailMatching.Tag = False

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.DownloadSelectedDocument()

            End If

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            If TabControlPanel_InvoiceItems.SelectedTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.DownloadSelectedDocument()

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.UploadNewDocument()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.IsDocumentsTabSelected Then

                ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.SendASPUploadEmail()

            End If

        End Sub
        Private Sub ButtonItemView_ShowBoth_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowBoth.CheckedChanged

            If ButtonItemView_ShowBoth.Checked Then

                ShowGrossNetColumns(True, True)

            End If

        End Sub
        Private Sub ButtonItemView_ShowGross_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowGross.CheckedChanged

            If ButtonItemView_ShowGross.Checked Then

                ShowGrossNetColumns(True, False)

            End If

        End Sub
        Private Sub ButtonItemView_ShowNet_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemView_ShowNet.CheckedChanged

            If ButtonItemView_ShowNet.Checked Then

                ShowGrossNetColumns(False, True)

            End If

        End Sub
        Private Sub ButtonItemFilter_HasVariance_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_HasVariance.CheckedChanged

            FilterGrid()

        End Sub
        Private Sub ButtonItemFilter_UnapprovedOnly_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemFilter_Unapproved.CheckedChanged

            FilterGrid()

        End Sub
        Private Sub ButtonItemMediaStatus_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaStatus_MarkSelected.Click

            SetMediaStatus()

        End Sub
        Private Sub ComboBoxApprovalStatus_Status_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxApprovalStatus_Status.SelectedValueChanged

            If Me.FormShown Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetails_InvoiceDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoiceDetails_InvoiceDetails.CellValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewInvoiceDetails_InvoiceDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoiceDetails_InvoiceDetails.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalStatus.ToString Then

                DirectCast(DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.MediaManager.Classes.ApproveInvoice).ApprovalNotes = Nothing

                DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.RefreshRow(e.RowHandle)

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetails_InvoiceDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetails_InvoiceDetails.SelectionChangedEvent

            TabItemAPInvoiceDetail_APInvoiceDetail.Tag = False
            TabItemInvoiceItems_InvoiceDetailMatching.Tag = False

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlPanel_InvoiceItems_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlPanel_InvoiceItems.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlPanel_InvoiceItems_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlPanel_InvoiceItems.SelectedTabChanging

            Dim IsOkay As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                IsOkay = CheckForUnsavedChanges()

                If IsOkay Then

                    If e.NewTab.Equals(TabItemAPInvoiceDetail_APInvoiceDetail) AndAlso e.NewTab.Tag = False Then

                        LoadAPInvoicesDetailTab()

                    ElseIf e.NewTab.Equals(TabItemInvoiceItems_InvoiceDetailMatching) Then

                        If Me.SelectedBroadcastInvoices.Any Then

                            If e.NewTab.Tag = False Then

                                LoadSpotVerificationTab()

                            End If

                        Else

                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemInvoiceItems_InvoiceDetail) Then

                        If Me.FormShown Then

                            LoadGrid()

                        End If

                    End If

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetails_InvoiceDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewInvoiceDetails_InvoiceDetails.ShowingEditorEvent

            If (DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalNotes.ToString OrElse
                    DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalStatus.ToString) AndAlso
                    DirectCast(DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.GetRow(DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.ApproveInvoice).DoesNotHaveAP Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetails_InvoiceDetails_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetails_InvoiceDetails.ShownEditorEvent

            Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing

            If TypeOf DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.ActiveEditor Is DevExpress.XtraEditors.MemoExEdit Then

                If DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.ApproveInvoice.Properties.ApprovalNotes.ToString Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        MemoExEdit = DataGridViewInvoiceDetails_InvoiceDetails.CurrentView.ActiveEditor
                        MemoExEdit.Properties.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.AccountPayableMediaApproval), AdvantageFramework.Database.Entities.AccountPayableMediaApproval.Properties.Comments.ToString))

                    End Using

                End If

            End If
        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.ShowingEditorEvent

            If DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Approved.ToString OrElse
                DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Comment.ToString OrElse
                DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.OrderLineNumber.ToString Then

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_Approve_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_Approve.Click

            'objects
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim AccountPayableBroadcastDetail As Object = Nothing
            Dim Saved As Boolean = False

            If DataGridViewInvoiceDetailMatching_InvoiceDetails.HasASelectedRow Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each BroadcastOrderDetailVerificationView In DataGridViewInvoiceDetailMatching_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).ToList

                            _ModifiedOrderLines.Add(BroadcastOrderDetailVerificationView.OrderNumber.ToString & "|" & BroadcastOrderDetailVerificationView.OrderLineNumber.ToString)

                            AccountPayableBroadcastDetail = BroadcastOrderDetailVerificationView.GetAccountPayableBroadcastDetail(DbContext)

                            If AccountPayableBroadcastDetail IsNot Nothing Then

                                If TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail Then

                                    AccountPayableRadioBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

                                    If AccountPayableRadioBroadcastDetail IsNot Nothing AndAlso AccountPayableRadioBroadcastDetail.IsApproved.GetValueOrDefault(0) = 0 Then

                                        AccountPayableRadioBroadcastDetail.IsApproved = 1
                                        AccountPayableRadioBroadcastDetail.ApprovedBy = Me.Session.User.EmployeeCode
                                        AccountPayableRadioBroadcastDetail.ApprovedDate = System.DateTime.Now

                                        DbContext.UpdateObject(AccountPayableRadioBroadcastDetail)

                                    End If

                                ElseIf TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail Then

                                    AccountPayableTVBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

                                    If AccountPayableTVBroadcastDetail IsNot Nothing AndAlso AccountPayableTVBroadcastDetail.IsApproved.GetValueOrDefault(0) = 0 Then

                                        AccountPayableTVBroadcastDetail.IsApproved = 1
                                        AccountPayableTVBroadcastDetail.ApprovedBy = Me.Session.User.EmployeeCode
                                        AccountPayableTVBroadcastDetail.ApprovedDate = System.DateTime.Now

                                        DbContext.UpdateObject(AccountPayableTVBroadcastDetail)

                                    End If

                                End If

                            End If

                            BroadcastOrderDetailVerificationView.Approved = 1

                        Next

                        DbContext.SaveChanges()

                        Saved = True

                        RefreshInvoiceDetailMatchingInvoiceDetails()

                    End Using

                Catch ex As Exception

                End Try

                If Not Saved Then

                    DataGridViewInvoiceDetailMatching_InvoiceDetails.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_Unapprove_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_Unapprove.Click

            'objects
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim AccountPayableBroadcastDetail As Object = Nothing
            Dim Saved As Boolean = False

            If DataGridViewInvoiceDetailMatching_InvoiceDetails.HasASelectedRow Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each BroadcastOrderDetailVerificationView In DataGridViewInvoiceDetailMatching_InvoiceDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).ToList

                            _ModifiedOrderLines.Add(BroadcastOrderDetailVerificationView.OrderNumber.ToString & "|" & BroadcastOrderDetailVerificationView.OrderLineNumber.ToString)

                            AccountPayableBroadcastDetail = BroadcastOrderDetailVerificationView.GetAccountPayableBroadcastDetail(DbContext)

                            If AccountPayableBroadcastDetail IsNot Nothing Then

                                If TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail Then

                                    AccountPayableRadioBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

                                    If AccountPayableRadioBroadcastDetail IsNot Nothing AndAlso AccountPayableRadioBroadcastDetail.IsApproved.GetValueOrDefault(0) = 1 Then

                                        AccountPayableRadioBroadcastDetail.IsApproved = 0
                                        AccountPayableRadioBroadcastDetail.ApprovedBy = Nothing
                                        AccountPayableRadioBroadcastDetail.ApprovedDate = Nothing

                                        DbContext.UpdateObject(AccountPayableRadioBroadcastDetail)

                                    End If

                                ElseIf TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail Then

                                    AccountPayableTVBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

                                    If AccountPayableTVBroadcastDetail IsNot Nothing AndAlso AccountPayableTVBroadcastDetail.IsApproved.GetValueOrDefault(0) = 1 Then

                                        AccountPayableTVBroadcastDetail.IsApproved = 0
                                        AccountPayableTVBroadcastDetail.ApprovedBy = Nothing
                                        AccountPayableTVBroadcastDetail.ApprovedDate = Nothing

                                        DbContext.UpdateObject(AccountPayableTVBroadcastDetail)

                                    End If

                                End If

                            End If

                            BroadcastOrderDetailVerificationView.Approved = 0

                        Next

                        DbContext.SaveChanges()

                        Saved = True

                        RefreshInvoiceDetailMatchingInvoiceDetails()

                    End Using

                Catch ex As Exception

                End Try

                If Not Saved Then

                    DataGridViewInvoiceDetailMatching_InvoiceDetails.SetUserEntryChanged()

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.CellValueChangingEvent

            'objects
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim BroadcastOrderDetailVerificationView As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
            Dim AccountPayableBroadcastDetail As Object = Nothing
            Dim RefreshVariance As Boolean = False
            Dim DbBroadcastOrderDetailVerificationView As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
            Dim DbBroadcastOrderVerificationView As AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification = Nothing
            Dim ApproveInvoiceList As Generic.List(Of String) = Nothing
            Dim BroadcastOrderVerificationView As AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Approved.ToString OrElse
                e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Comment.ToString OrElse
                e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.OrderLineNumber.ToString Then

                BroadcastOrderDetailVerificationView = DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)

                If e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Approved.ToString Then

                    _ModifiedOrderLines.Add(BroadcastOrderDetailVerificationView.OrderNumber.ToString & "|" & BroadcastOrderDetailVerificationView.OrderLineNumber.ToString)

                    Try

                        BroadcastOrderDetailVerificationView.Approved = CShort(e.Value)

                    Catch ex As Exception

                    End Try

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.Comment.ToString Then

                    Try

                        BroadcastOrderDetailVerificationView.Comment = e.Value

                    Catch ex As Exception

                    End Try

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.OrderLineNumber.ToString Then

                    RefreshVariance = True

                    Try

                        BroadcastOrderDetailVerificationView.OrderLineNumber = e.Value

                    Catch ex As Exception

                    End Try

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AccountPayableBroadcastDetail = BroadcastOrderDetailVerificationView.GetAccountPayableBroadcastDetail(DbContext)

                    If AccountPayableBroadcastDetail IsNot Nothing Then

                        If TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail Then

                            AccountPayableRadioBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

                            If AccountPayableRadioBroadcastDetail.IsApproved.GetValueOrDefault(0) = 0 Then

                                AccountPayableRadioBroadcastDetail.ApprovedBy = Nothing
                                AccountPayableRadioBroadcastDetail.ApprovedDate = Nothing

                            Else

                                AccountPayableRadioBroadcastDetail.ApprovedBy = Me.Session.User.EmployeeCode
                                AccountPayableRadioBroadcastDetail.ApprovedDate = System.DateTime.Now

                            End If

                            Saved = AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Update(DbContext, AccountPayableRadioBroadcastDetail)

                        ElseIf TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail Then

                            AccountPayableTVBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

                            If AccountPayableTVBroadcastDetail.IsApproved.GetValueOrDefault(0) = 0 Then

                                AccountPayableTVBroadcastDetail.ApprovedBy = Nothing
                                AccountPayableTVBroadcastDetail.ApprovedDate = Nothing

                            Else

                                AccountPayableTVBroadcastDetail.ApprovedBy = Me.Session.User.EmployeeCode
                                AccountPayableTVBroadcastDetail.ApprovedDate = System.DateTime.Now

                            End If

                            Saved = AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Update(DbContext, AccountPayableTVBroadcastDetail)

                        End If

                    End If

                    If Saved AndAlso RefreshVariance Then

                        ApproveInvoiceList = New Generic.List(Of String)

                        ApproveInvoiceList.AddRange(From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList
                                                    Select Entity.OrderNumber.ToString & "|" & Entity.OrderLineNumber.ToString)

                        LoadSpotVerificationTab()

                        DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.BeginSelection()

                        DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.ClearSelection()

                        For Each RowHandlesAndDataBoundItem In DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsRowHandlesAndDataBoundItems

                            Try

                                BroadcastOrderVerificationView = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                BroadcastOrderVerificationView = Nothing
                            End Try

                            If BroadcastOrderVerificationView IsNot Nothing AndAlso ApproveInvoiceList.Contains(BroadcastOrderVerificationView.OrderNumber.ToString & "|" & BroadcastOrderVerificationView.OrderLineNumber.ToString) Then

                                DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                                DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                            End If

                        Next

                        DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.EndSelection()

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_ShowAll_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_ShowAll.CheckedChanged

            SetInvoiceDetailsGridCaption()

            RefreshInvoiceDetailMatchingInvoiceDetails()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.CustomSummaryCalculateEvent

            Dim GridSummaryItem As DevExpress.XtraGrid.GridSummaryItem = Nothing

            If e.IsTotalSummary Then

                If e.Item.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RatingIndex.ToString Then

                    GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

                    Select Case e.SummaryProcess

                        Case DevExpress.Data.CustomSummaryProcess.Start

                            _SumEstRating = 0
                            _SumActRating = 0

                        Case DevExpress.Data.CustomSummaryProcess.Calculate

                            _SumEstRating += DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).EstimatedGRP.GetValueOrDefault(0)
                            _SumActRating += DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).ActualGRP.GetValueOrDefault(0)

                        Case DevExpress.Data.CustomSummaryProcess.Finalize

                            If _SumEstRating = 0 Then

                                e.TotalValue = 0

                            Else

                                e.TotalValue = _SumActRating / _SumEstRating * 100

                            End If

                    End Select

                ElseIf e.Item.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ImpressionIndex.ToString Then

                    GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

                    Select Case e.SummaryProcess

                        Case DevExpress.Data.CustomSummaryProcess.Start

                            _SumEstImps = 0
                            _SumActImps = 0

                        Case DevExpress.Data.CustomSummaryProcess.Calculate

                            _SumEstImps += DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).EstimatedImpressions.GetValueOrDefault(0)
                            _SumActImps += DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).ActualImpressions.GetValueOrDefault(0)

                        Case DevExpress.Data.CustomSummaryProcess.Finalize

                            If _SumEstImps = 0 Then

                                e.TotalValue = 0

                            Else

                                e.TotalValue = _SumActImps / _SumEstImps * 100

                            End If

                    End Select

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                For Each GridColumn In DataGridViewInvoiceDetailMatching_InvoiceDetails.Columns

                    If GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedGRP.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualGRP.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewInvoiceDetailMatching_InvoiceDetails, GridColumn.FieldName)

                        GridColumn.SummaryItem.DisplayFormat = "{0:n2}"

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedImpressions.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualImpressions.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewInvoiceDetailMatching_InvoiceDetails, GridColumn.FieldName)

                        If _BroadcastOrderDetailVerifications.Count > 0 AndAlso _BroadcastOrderDetailVerifications.First.MediaType.Substring(0, 1) = "R" Then

                            GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                        Else

                            GridColumn.SummaryItem.DisplayFormat = "{0:n1}"

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.RatingIndex.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ImpressionIndex.ToString Then

                        If GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Custom Then

                            GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                        End If

                    End If

                Next

            End If

            SetInvoiceDetailsGridCaption()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.SelectionChangedEvent

            RefreshInvoiceDetailMatchingInvoiceDetails()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.QueryPopupNeedDatasourceEvent

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim BroadcastOrderDetailVerificationView As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing

            If FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.OrderLineNumber.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    OverrideDefaultDatasource = True

                    BroadcastOrderDetailVerificationView = DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.GetFocusedRow, AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)

                    OrderNumber = DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.GetRow(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).OrderNumber

                    LineNumbers = DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).Where(Function(V) V.OrderNumber = OrderNumber AndAlso V.OrderLineNumber.HasValue).Select(Function(V) V.OrderLineNumber.Value).ToArray

                    If BroadcastOrderDetailVerificationView.MediaType = "Radio" Then

                        Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, BroadcastOrderDetailVerificationView.OrderNumber).Where(Function(ord) LineNumbers.Contains(ord.LineNumber)))

                    ElseIf BroadcastOrderDetailVerificationView.MediaType = "TV" Then

                        Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, BroadcastOrderDetailVerificationView.OrderNumber).Where(Function(ord) LineNumbers.Contains(ord.LineNumber)))

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewInvoices_Orders_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoices_Orders.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                LoadInvoices()

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_AutoFill.Click

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim SelectedItems As IEnumerable = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim SelectedObject As Object = Nothing
            Dim BroadcastOrderDetailVerificationView As AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification = Nothing
            Dim AccountPayableBroadcastDetail As Object = Nothing
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim FocusedRowHandle As Integer = 0

            DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.CloseEditorForUpdating()

            OrderNumber = DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.GetRow(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification).OrderNumber

            SelectedItems = DataGridViewInvoiceDetailMatching_OrderLines.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).Where(Function(V) V.OrderNumber = OrderNumber AndAlso V.OrderLineNumber.HasValue).Select(Function(V) V).ToList

            If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems, SelectedObject) = Windows.Forms.DialogResult.OK Then

                FocusedRowHandle = DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedRowHandle

                RowHandlesAndDataBoundItems = DataGridViewInvoiceDetailMatching_InvoiceDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each RowHandlesAndDataBoundItem In RowHandlesAndDataBoundItems

                        BroadcastOrderDetailVerificationView = DirectCast(DataGridViewInvoiceDetailMatching_InvoiceDetails.CurrentView.GetRow(RowHandlesAndDataBoundItem.Key), AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification)

                        AccountPayableBroadcastDetail = BroadcastOrderDetailVerificationView.GetAccountPayableBroadcastDetail(DbContext)

                        If AccountPayableBroadcastDetail IsNot Nothing Then

                            If TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail Then

                                AccountPayableRadioBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)

                                AccountPayableRadioBroadcastDetail.OrderLineNumber = DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).OrderLineNumber

                                AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Update(DbContext, AccountPayableRadioBroadcastDetail)

                            ElseIf TypeOf AccountPayableBroadcastDetail Is AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail Then

                                AccountPayableTVBroadcastDetail = DirectCast(AccountPayableBroadcastDetail, AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

                                AccountPayableTVBroadcastDetail.OrderLineNumber = DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).OrderLineNumber

                                AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Update(DbContext, AccountPayableTVBroadcastDetail)

                            End If

                        End If

                    Next

                    LoadSpotVerificationTab()

                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.BeginSelection()
                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.ClearSelection()

                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.SelectRow(FocusedRowHandle)
                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedRowHandle = FocusedRowHandle

                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.EndSelection()

                End Using

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_ShowWeeks_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_ShowWeeks.CheckedChanged

            LoadSpotVerificationTab()

            ToggleColumnVisibility()

        End Sub
        Private Sub DataGridViewInvoices_Orders_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewInvoices_Orders.LeavingRowEvent

            If FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.CellValueChangedEvent

            Dim BroadcastOrderVerification As AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification = Nothing
            Dim Spots As Integer? = Nothing
            Dim Daypart As Integer? = Nothing
            Dim Program As String = Nothing
            Dim StartTime As String = Nothing
            Dim EndTime As String = Nothing
            Dim Days As String = Nothing
            Dim GrossRate As Decimal = 0
            Dim Length As Short? = Nothing

            BroadcastOrderVerification = DataGridViewInvoiceDetailMatching_OrderLines.GetRowDataBoundItem(e.RowHandle)

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartTime.ToString Then

                StartTime = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.StartTime.Equals(BroadcastOrderVerification.StartTime) Then

                        Row.StartTime = StartTime

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndTime.ToString Then

                EndTime = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.EndTime.Equals(BroadcastOrderVerification.EndTime) Then

                        Row.EndTime = EndTime

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Days.ToString Then

                Days = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.Days.Equals(BroadcastOrderVerification.Days) Then

                        Row.Days = Days

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.GrossRate.ToString Then

                GrossRate = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.GrossRate.Equals(BroadcastOrderVerification.GrossRate) Then

                        Row.GrossRate = GrossRate

                        DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.AddToModifiedRows(Row)

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Length.ToString Then

                Length = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.Length.Equals(BroadcastOrderVerification.Length) Then

                        Row.Length = Length

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Daypart.ToString Then

                Daypart = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.Daypart.Equals(BroadcastOrderVerification.Daypart) Then

                        Row.Daypart = Daypart

                    End If

                Next

            ElseIf e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Program.ToString Then

                Program = e.Value

                For Each Row In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ToList

                    If Row.OrderNumber = BroadcastOrderVerification.OrderNumber AndAlso Row.OrderLineNumber = BroadcastOrderVerification.OrderLineNumber AndAlso Not Row.Program.Equals(BroadcastOrderVerification.Program) Then

                        Row.Program = Program

                    End If

                Next

            End If

            DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.RefreshData()

            DataGridViewInvoiceDetailMatching_OrderLines.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.ShowingEditorEvent

            Dim BroadcastOrderVerification As AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification = Nothing

            If Not ButtonItemInvoiceDetail_ShowWeeks.Checked OrElse _OrderWorksheetDetail.OrderIsOnWorksheet = False Then

                e.Cancel = True

            ElseIf _OrderWorksheetDetail.IsEditable = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Edits cannot take place, the worksheet has been modified.")

                e.Cancel = True

            Else

                BroadcastOrderVerification = DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.GetRow(DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)

                If BroadcastOrderVerification.CanEdit = False Then

                    e.Cancel = True

                ElseIf DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Spots.ToString Then

                    If BroadcastOrderVerification.IsHiatus.GetValueOrDefault(False) = True OrElse BroadcastOrderVerification.AllowSpotsToBeEntered.GetValueOrDefault(True) = False Then

                        e.Cancel = True

                    End If

                ElseIf DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartTime.ToString AndAlso
                         DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndTime.ToString AndAlso
                         DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Days.ToString AndAlso
                         DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Length.ToString AndAlso
                         DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Daypart.ToString AndAlso
                         DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Program.ToString Then
                    'DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.GrossRate.ToString AndAlso

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.ValidatingEditorEvent

            'objects
            Dim BroadcastOrderVerification As AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorText As String = String.Empty
            Dim Time As String = Nothing

            BroadcastOrderVerification = DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.GetRow(DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)

            If DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Spots.ToString Then

                BroadcastOrderVerification.ValidateEntityProperty(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Spots.ToString, IsValid, e.Value)

                e.Valid = True

            ElseIf DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.GrossRate.ToString Then

                BroadcastOrderVerification.ValidateEntityProperty(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.GrossRate.ToString, IsValid, e.Value)

                e.Valid = True

            ElseIf DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Length.ToString Then

                BroadcastOrderVerification.ValidateEntityProperty(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Length.ToString, IsValid, e.Value)

                e.Valid = True

            ElseIf DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Days.ToString OrElse
                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartTime.ToString OrElse
                    DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EndTime.ToString Then

                DaysAndTime = New AdvantageFramework.DTO.DaysAndTime()

                If BroadcastOrderVerification.MediaType.Substring(0, 1) = "R" Then

                    DaysAndTime.BroadcastType = DTO.DaysAndTime.BroadcastTypes.Radio

                ElseIf BroadcastOrderVerification.MediaType.Substring(0, 1) = "T" Then

                    DaysAndTime.BroadcastType = DTO.DaysAndTime.BroadcastTypes.TV

                End If

                If DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Days.ToString Then

                    _DaysAndTimeController.ParseDays(DaysAndTime, e.Value, IsValid)

                    If Not IsValid Then

                        ErrorText = "Invalid Day Entry"

                    End If

                    BroadcastOrderVerification.SetPropertyError(AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Days.ToString, ErrorText)

                    e.Valid = True

                Else

                    Time = e.Value

                    If DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.StartTime.ToString Then

                        _DaysAndTimeController.ParseTime(DaysAndTime, True, Time, IsValid)

                    Else

                        _DaysAndTimeController.ParseTime(DaysAndTime, False, Time, IsValid)

                    End If

                    e.Value = Time

                    ErrorText = _DaysAndTimeController.ValidateEntityProperty(DaysAndTime, DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName, IsValid, e.Value)

                    BroadcastOrderVerification.SetPropertyError(DataGridViewInvoiceDetailMatching_OrderLines.CurrentView.FocusedColumn.FieldName, ErrorText)

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewInvoiceDetailMatching_OrderLines.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.Daypart.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                        Where Entity.MediaType.Substring(0, 1) = "R").Any Then

                        Datasource = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList
                                      Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList
                    Else

                        Datasource = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList
                                      Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_ShowGRPs_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_ShowGRPs.CheckedChanged

            CalculateRatingsImpressions()

        End Sub
        Private Sub ButtonItemInvoiceDetail_ShowIMPs_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_ShowIMPs.CheckedChanged

            CalculateRatingsImpressions()

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.CustomSummaryCalculateEvent

            Dim GridSummaryItem As DevExpress.XtraGrid.GridSummaryItem = Nothing

            If e.IsTotalSummary Then

                If e.Item.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.RatingIndex.ToString Then

                    GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

                    Select Case e.SummaryProcess

                        Case DevExpress.Data.CustomSummaryProcess.Start

                            _OrderLineSumEstRating = 0
                            _OrderLineSumActRating = 0

                        Case DevExpress.Data.CustomSummaryProcess.Calculate

                            _OrderLineSumEstRating += DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).EstimatedGRP.GetValueOrDefault(0)
                            _OrderLineSumActRating += DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ActualGRP.GetValueOrDefault(0)

                        Case DevExpress.Data.CustomSummaryProcess.Finalize

                            If _OrderLineSumEstRating = 0 Then

                                e.TotalValue = 0

                            Else

                                e.TotalValue = _OrderLineSumActRating / _OrderLineSumEstRating * 100

                            End If

                    End Select

                ElseIf e.Item.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ImpressionIndex.ToString Then

                    GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

                    Select Case e.SummaryProcess

                        Case DevExpress.Data.CustomSummaryProcess.Start

                            _OrderLineSumEstImps = 0
                            _OrderLineSumActImps = 0

                        Case DevExpress.Data.CustomSummaryProcess.Calculate

                            _OrderLineSumEstImps += DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).EstimatedImpressions.GetValueOrDefault(0)
                            _OrderLineSumActImps += DirectCast(DataGridViewInvoiceDetailMatching_OrderLines.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).ActualImpressions.GetValueOrDefault(0)

                        Case DevExpress.Data.CustomSummaryProcess.Finalize

                            If _OrderLineSumEstImps = 0 Then

                                e.TotalValue = 0

                            Else

                                e.TotalValue = _OrderLineSumActImps / _OrderLineSumEstImps * 100

                            End If

                    End Select

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                For Each GridColumn In DataGridViewInvoiceDetailMatching_OrderLines.Columns

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedGRP.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualGRP.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewInvoiceDetailMatching_OrderLines, GridColumn.FieldName)

                        GridColumn.SummaryItem.DisplayFormat = "{0:n2}"

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedImpressions.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualImpressions.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewInvoiceDetailMatching_OrderLines, GridColumn.FieldName)

                        If _BroadcastOrderDetailVerifications.Count > 0 AndAlso _BroadcastOrderDetailVerifications.First.MediaType.Substring(0, 1) = "R" Then

                            GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                        Else

                            GridColumn.SummaryItem.DisplayFormat = "{0:n1}"

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.RatingIndex.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ImpressionIndex.ToString Then

                        If GridColumn.SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Custom Then

                            GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                            GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_OrderLines_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewInvoiceDetailMatching_OrderLines.CustomDrawCellEvent

            If _IsRadio AndAlso IsNumeric(e.CellValue) Then

                If (e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualImpressions.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedImpressions.ToString) Then

                    e.DisplayText = FormatNumber(e.CellValue, 0)

                ElseIf (e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.ActualGRP.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification.Properties.EstimatedGRP.ToString) Then

                    e.DisplayText = FormatNumber(e.CellValue, 1)

                End If

            End If

        End Sub
        Private Sub DataGridViewInvoiceDetailMatching_InvoiceDetails_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewInvoiceDetailMatching_InvoiceDetails.CustomDrawCellEvent

            If _IsRadio AndAlso IsNumeric(e.CellValue) Then

                If (e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualImpressions.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedImpressions.ToString) Then

                    e.DisplayText = FormatNumber(e.CellValue, 0)

                ElseIf (e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.ActualGRP.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Classes.BroadcastOrderDetailVerification.Properties.EstimatedGRP.ToString) Then

                    e.DisplayText = FormatNumber(e.CellValue, 1)

                End If

            End If

        End Sub
        Private Sub ButtonItemSpotDetail_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemSpotDetail_Cancel.Click

            ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.CancelAddNewSpotDetail()

        End Sub
        Private Sub ButtonItemSpotDetail_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemSpotDetail_Delete.Click

            If ApInvoiceControlAPInvoiceDetail_APInvoiceDetail.DeleteSpotDetail() Then

                TabItemInvoiceItems_InvoiceDetailMatching.Tag = False

            End If

        End Sub
        Private Sub ButtonItemInvoiceDetail_Rematch_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceDetail_Rematch.Click

            Dim OrderNumbers As Generic.List(Of Integer) = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Would you like to clear and re-match all spots currently associated with the selected order/lines?", WinForm.MessageBox.MessageBoxButtons.YesNo, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Matching...")

                OrderNumbers = New Generic.List(Of Integer)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each OL In (From Entity In DataGridViewInvoiceDetailMatching_OrderLines.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification)
                                    Where Entity.OrderLineNumber IsNot Nothing
                                    Select Entity.MediaType, Entity.OrderNumber, OrderLineNumber = Entity.OrderLineNumber.Value).Distinct.ToList

                        If OL.MediaType = "Radio" Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_RADIO_BROADCAST_DTL SET ORDER_LINE_NBR = NULL WHERE ORDER_NBR = {0} AND ORDER_LINE_NBR = {1}", OL.OrderNumber, OL.OrderLineNumber))

                        ElseIf OL.MediaType = "TV" Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_TV_BROADCAST_DTL SET ORDER_LINE_NBR = NULL WHERE ORDER_NBR = {0} AND ORDER_LINE_NBR = {1}", OL.OrderNumber, OL.OrderLineNumber))

                        End If

                        OrderNumbers.Add(OL.OrderNumber)

                    Next

                    MatchUnmatchedLines(DbContext, OrderNumbers)

                    LoadSpotVerificationTab()

                End Using

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

    Friend Class OrderWorksheetDetail

        Public Property MediaBroadcastWorksheetID As Nullable(Of Integer)
        Public Property MediaBroadcastWorksheetMarketID As Nullable(Of Integer)
        Public Property IsEditable As Boolean
        Public Property OrderIsOnWorksheet As Boolean
        Public Property OrderNumber As Integer
        Public Property PrimaryMediaDemoID As Nullable(Of Integer)
        Public Property MarketNumber As Nullable(Of Integer)
        Public Property PrimaryMediaDemographicDescription As String
        Public Property RatingsService As String

    End Class

    Friend Class MatchedLines
        Public Property Days As Integer
        Public Property OrderLineNumber As Integer
    End Class

    Friend Class OrderAdjacency
        Public Property OrderNumber As Integer
        Public Property AdjacencyBefore As Short
        Public Property AdjacencyAfter As Short
    End Class

End Namespace
