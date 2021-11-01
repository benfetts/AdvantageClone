Namespace Media.Presentation

    Public Class MediaPlanOrderBillDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _MediaPlanDetailID As Integer = 0
        Private _DataTable As System.Data.DataTable = Nothing
        Private _DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing
        Private _CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType = MediaPlanning.CreateOrderBroadcastCalendarType.FromPlan
        Private _CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions = MediaPlanning.CreateOrderOptions.Default
        Private _SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
        Private _IsCalendarMonth As Boolean = False
        Private _MediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings = Nothing
        Private _HasOrderGroupingBeenChanged As Boolean = False
        Private _MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
        Private _MediaPlanOrderGroupings As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
        Private _OrderGroupingLevelLinesDataTable As System.Data.DataTable = Nothing
        Private _DoesHaveCustomDates As Boolean = False
        Private _PlanStartDate As Date = Date.MinValue
        Private _PlanEndDate As Date = Date.MinValue
        Private _RowIndexes As IEnumerable(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property OrderGroupingLevelLinesDataTable As System.Data.DataTable
            Get
                OrderGroupingLevelLinesDataTable = _OrderGroupingLevelLinesDataTable
            End Get
        End Property
        Public ReadOnly Property DataTable As System.Data.DataTable
            Get
                DataTable = _DataTable
            End Get
        End Property
        Public ReadOnly Property MediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings
            Get
                MediaPlanOrderGrouping = _MediaPlanOrderGrouping
            End Get
        End Property
        Public ReadOnly Property CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType
            Get
                CreateOrderBroadcastCalendarType = _CreateOrderBroadcastCalendarType
            End Get
        End Property
        Public ReadOnly Property CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions
            Get
                CreateOrderOption = _CreateOrderOption
            End Get
        End Property
        Public ReadOnly Property DoesHaveCustomDates As Boolean
            Get
                DoesHaveCustomDates = _DoesHaveCustomDates
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaPlanID As Integer, MediaPlanDetailID As Integer, DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                        RowIndexes As IEnumerable(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanID = MediaPlanID
            _MediaPlanDetailID = MediaPlanDetailID
            _DataFilter = DataFilter
            _CreateOrderOption = CreateOrderOption
            _RowIndexes = RowIndexes

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.TagTypes = AdvantageFramework.MediaPlanning.TagTypes.Default
            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing
            Dim Width As Integer = 0
            Dim MaxLength As Long = -1

            DataGridViewForm_DetailsLevelLines.ClearGridCustomization()
            DataGridViewForm_DetailsLevelLines.ItemDescription = "Level/Line(s)"

            DataGridViewForm_DetailsLevelLines.DataSource = _OrderGroupingLevelLinesDataTable

            For Each GridColumn In DataGridViewForm_DetailsLevelLines.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            For Each DataColumn In _OrderGroupingLevelLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)).ToList

                Try

                    GridColumn = DataGridViewForm_DetailsLevelLines.Columns(DataColumn.ColumnName)

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString Then

                        GridColumn.Visible = True

                        'If DataColumn.ColumnName = AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString Then

                        '    GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(GridColumn.FieldName)
                        '    GridColumn.OptionsColumn.ReadOnly = False
                        '    AddSubItemComboBox(Me.Session, DataGridViewForm_DetailsLevelLines, GridColumn)

                        'Else

                        GridColumn.OptionsColumn.ReadOnly = True

                        'End If

                    Else

                        GridColumn.Visible = False

                    End If

                End If

            Next

            For Each DataColumn In _OrderGroupingLevelLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)).ToList

                If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString Then

                    Try

                        GridColumn = DataGridViewForm_DetailsLevelLines.Columns(DataColumn.ColumnName)

                    Catch ex As Exception
                        GridColumn = Nothing
                    End Try

                    If GridColumn IsNot Nothing Then

                        Try

                            GridColumn.VisibleIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)

                        Catch ex As Exception
                            GridColumn.VisibleIndex = 0
                        End Try

                    End If

                End If

            Next

            DataGridViewForm_DetailsLevelLines.CurrentView.BeginUpdate()

            DataGridViewForm_DetailsLevelLines.MakeColumnVisible(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)

            DataGridViewForm_DetailsLevelLines.Columns(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString).Caption = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)
            DataGridViewForm_DetailsLevelLines.Columns(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString).OptionsColumn.ReadOnly = False
            AddSubItemComboBox(Me.Session, DataGridViewForm_DetailsLevelLines, DataGridViewForm_DetailsLevelLines.Columns(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString))

            DataGridViewForm_DetailsLevelLines.CurrentView.EndUpdate()

            DataGridViewForm_DetailsLevelLines.CurrentView.BestFitColumns()

        End Sub
        Private Sub AddSubItemComboBox(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                       GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

            SubItemGridLookUpEditControl.Session = Session
            SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject
            SubItemGridLookUpEditControl.EnumType = GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings)
            SubItemGridLookUpEditControl.ValueType = GetType(Integer)
            SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
            SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
            SubItemGridLookUpEditControl.LoadDefaultDataSourceView()

            DataGridView.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

            GridColumn.ColumnEdit = SubItemGridLookUpEditControl

        End Sub
        Private Sub EnableOrDisableItems()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanID As Integer, MediaPlanDetailID As Integer, DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                              ByRef DataTable As System.Data.DataTable,
                                              ByRef OrderGroupingLevelLinesDataTable As System.Data.DataTable,
                                              ByRef MediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings,
                                              ByRef CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType,
                                              ByRef CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                              ByRef DoesHaveCustomDates As Boolean, Optional ByVal RowIndexes As IEnumerable(Of Integer) = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanOrderBillDialog As AdvantageFramework.Media.Presentation.MediaPlanOrderBillDialog = Nothing

            MediaPlanOrderBillDialog = New AdvantageFramework.Media.Presentation.MediaPlanOrderBillDialog(MediaPlanID, MediaPlanDetailID, DataFilter, CreateOrderOption, RowIndexes)

            ShowFormDialog = MediaPlanOrderBillDialog.ShowDialog()

            OrderGroupingLevelLinesDataTable = MediaPlanOrderBillDialog.OrderGroupingLevelLinesDataTable
            DataTable = MediaPlanOrderBillDialog.DataTable
            MediaPlanOrderGrouping = MediaPlanOrderBillDialog.MediaPlanOrderGrouping
            CreateOrderBroadcastCalendarType = MediaPlanOrderBillDialog.CreateOrderBroadcastCalendarType
            CreateOrderOption = MediaPlanOrderBillDialog.CreateOrderOption
            DoesHaveCustomDates = MediaPlanOrderBillDialog.DoesHaveCustomDates

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanOrderBillDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim DefaultGroupingType As Integer = 0
            Dim HasDataLongerThanAMonth As Boolean = False
            Dim TempDataTable As System.Data.DataTable = Nothing

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            'DateEditForm_StartDate.SecurityEnabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, _MediaPlanID)

                If MediaPlan IsNot Nothing Then

                    _MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, _MediaPlanDetailID, True)

                    If _MediaPlanDetail IsNot Nothing Then

                        _SalesClassTypeEnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), _MediaPlanDetail.SalesClassType)
                        _IsCalendarMonth = _MediaPlanDetail.IsCalendarMonth

                        DateEditForm_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.StartDate)
                        DateEditForm_EndDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.EndDate)

                        DateEditForm_StartDate.Properties.MinValue = MediaPlan.StartDate
                        DateEditForm_StartDate.Properties.MaxValue = MediaPlan.EndDate

                        DateEditForm_EndDate.Properties.MinValue = MediaPlan.StartDate
                        DateEditForm_EndDate.Properties.MaxValue = MediaPlan.EndDate

                        DateEditForm_StartDate.EditValue = MediaPlan.StartDate
                        DateEditForm_EndDate.EditValue = MediaPlan.EndDate

                        _PlanStartDate = MediaPlan.StartDate
                        _PlanEndDate = MediaPlan.EndDate

                        Try

                            _OrderGroupingLevelLinesDataTable = AdvantageFramework.MediaPlanning.BuildOrderGroupingLevelLines(Me.Session, _MediaPlanDetail)

                            If _RowIndexes IsNot Nothing Then

                                TempDataTable = _OrderGroupingLevelLinesDataTable.Clone

                                For Each Row As System.Data.DataRow In _OrderGroupingLevelLinesDataTable.Rows

                                    If _RowIndexes.Contains(Row("RowIndex")) Then

                                        TempDataTable.ImportRow(Row)

                                    End If

                                Next

                                _OrderGroupingLevelLinesDataTable = TempDataTable

                            End If

                        Catch ex As Exception
                            _OrderGroupingLevelLinesDataTable = New System.Data.DataTable
                        End Try

                        LoadGrid()

                        If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                            _MediaPlanOrderGroupings = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings)).Where(Function(Entity) Entity.Code <> "6").ToList

                            If _MediaPlanDetail.SalesClassType = "R" OrElse _MediaPlanDetail.SalesClassType = "T" Then

                                If _MediaPlanDetail.OrderGrouping <> 0 AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList

                                Else

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                                End If

                            ElseIf _MediaPlanDetail.SalesClassType = "I" Then

                                If _MediaPlanDetail.OrderGrouping <> 0 AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList

                                Else

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                                End If

                            ElseIf _MediaPlanDetail.SalesClassType = "M" Then

                                If _MediaPlanDetail.OrderGrouping <> 0 AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList

                                Else

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                                End If

                            ElseIf _MediaPlanDetail.SalesClassType = "N" Then

                                If _MediaPlanDetail.OrderGrouping <> 0 AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList

                                Else

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                                End If

                            ElseIf _MediaPlanDetail.SalesClassType = "O" Then

                                If _MediaPlanDetail.OrderGrouping <> 0 AndAlso
                                        _MediaPlanDetail.OrderGrouping <> AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList

                                Else

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek).ToList

                                End If

                            End If

                            If _MediaPlanDetail.OrderGrouping > 0 Then

                                If _MediaPlanDetail.SalesClassType = "R" OrElse _MediaPlanDetail.SalesClassType = "T" Then

                                    ComboBoxOrders_Grouping.SecurityEnabled = False

                                Else

                                    ComboBoxOrders_Grouping.SecurityEnabled = (_MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any() = False)

                                End If

                                ComboBoxOrders_Grouping.SelectedItem = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings), CStr(_MediaPlanDetail.OrderGrouping))

                            Else

                                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    If _MediaPlanDetail.SalesClassType = "I" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_INT), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "M" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_MAG), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "N" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_NEW), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "O" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "R" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_RAD), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "T" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_TV), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    End If

                                End Using

                            End If

                        Else

                            _MediaPlanOrderGroupings = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings))

                            If _MediaPlanDetail.SalesClassType = "R" OrElse _MediaPlanDetail.SalesClassType = "T" Then

                                ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                            ElseIf _MediaPlanDetail.SalesClassType = "I" Then

                                If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week OrElse _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                End If

                            ElseIf _MediaPlanDetail.SalesClassType = "M" Then

                                ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                            ElseIf _MediaPlanDetail.SalesClassType = "N" Then

                                ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList

                            ElseIf _MediaPlanDetail.SalesClassType = "O" Then

                                If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                                    ComboBoxOrders_Grouping.DataSource = _MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList

                                End If

                            End If

                            If _MediaPlanDetail.OrderGrouping > 0 Then

                                If _MediaPlanDetail.SalesClassType = "R" OrElse _MediaPlanDetail.SalesClassType = "T" Then

                                    ComboBoxOrders_Grouping.SecurityEnabled = False

                                Else

                                    ComboBoxOrders_Grouping.SecurityEnabled = (_MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any() = False)

                                End If

                                ComboBoxOrders_Grouping.SelectedItem = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings), CStr(_MediaPlanDetail.OrderGrouping))

                            Else

                                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    If _MediaPlanDetail.SalesClassType = "I" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_INT), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "M" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_MAG), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "N" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_NEW), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "O" Then

                                        If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                        ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                                If DefaultGroupingType = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek Then

                                                    ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                                Else

                                                    ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                                End If

                                            Else

                                                ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                            End If

                                        Else

                                            If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_OUT), DefaultGroupingType) Then

                                                ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                            Else

                                                ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period))

                                            End If

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "R" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_RAD), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    ElseIf _MediaPlanDetail.SalesClassType = "T" Then

                                        If Integer.TryParse(AdvantageFramework.Agency.LoadDefaultGroupingType(DataContext, Agency.Methods.Settings.DEF_GRP_TYPE_TV), DefaultGroupingType) Then

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(DefaultGroupingType)

                                        Else

                                            ComboBoxOrders_Grouping.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth))

                                        End If

                                    End If

                                End Using

                            End If

                        End If

                        If _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.Default Then

                            CheckBoxCreateOrderOptions_Default.Checked = True

                        ElseIf _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.AddToOrder Then

                            CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = True

                        ElseIf _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.NewOrderLineForEveryPeriod Then

                            CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = True

                        End If

                        CheckBoxCreateOrderOptions_Default.SecurityEnabled = (_MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any() = False)
                        CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.SecurityEnabled = (_MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any() = False)

                        DateEditForm_StartDate.ByPassUserEntryChanged = True
                        DateEditForm_EndDate.ByPassUserEntryChanged = True
                        ComboBoxOrders_Grouping.ByPassUserEntryChanged = True

                        EnableOrDisableItems()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The media plan detail you are trying to view does not exist anymore.")
                        Me.Close()

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to view does not exist anymore.")
                    Me.Close()

                End If

            End Using

        End Sub
        Private Sub MediaPlanOrderBillDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            DateEditForm_StartDate.Focus()

            If _RowIndexes IsNot Nothing Then

                DateEditForm_StartDate.Enabled = False
                DateEditForm_EndDate.Enabled = False

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow() As System.Data.DataRow = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If DateEditForm_StartDate.EditValue > DateEditForm_EndDate.EditValue Then

                    ErrorMessage = "Please select a start date on or before the end date."

                End If

                If ErrorMessage = "" Then

                    Me.ShowWaitForm("Preparing...")

                    Try

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DataTable = AdvantageFramework.Exporting.CreateDataTableFromTemplate(DbContext, AdvantageFramework.Exporting.ExportTypes.MediaPlanData, Nothing)

                        End Using

                        If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(Me.Session, AdvantageFramework.Exporting.ExportTypes.MediaPlanData, Nothing, _DataFilter, DataTable) Then

                            _DataTable = DataTable.Clone

                            DataRow = DataTable.Select("StartDate >= '" & DateEditForm_StartDate.EditValue & "' AND StartDate <='" & DateEditForm_EndDate.EditValue & "'")

                            For Each Row In DataRow

                                _DataTable.ImportRow(Row)

                            Next

                            _CreateOrderBroadcastCalendarType = AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType.FromPlan

                            If CheckBoxCreateOrderOptions_Default.Checked Then

                                _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.Default

                            ElseIf CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked Then

                                _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.AddToOrder

                            ElseIf CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked Then

                                _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.NewOrderLineForEveryPeriod

                            End If

                            _MediaPlanOrderGrouping = ComboBoxOrders_Grouping.GetSelectedValue

                            If DateEditForm_StartDate.EditValue <> _PlanStartDate OrElse
                                    DateEditForm_EndDate.EditValue <> _PlanEndDate Then

                                _DoesHaveCustomDates = True

                            End If

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.CloseWaitForm()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxOrders_Grouping_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOrders_Grouping.SelectedIndexChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso ComboBoxOrders_Grouping.SelectedIndex > -1 Then

                If _HasOrderGroupingBeenChanged = False AndAlso _MediaPlanDetail.OrderGrouping > 0 AndAlso _MediaPlanDetail.OrderGrouping <> ComboBoxOrders_Grouping.SelectedValue AndAlso
                        _MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any() Then

                    If AdvantageFramework.WinForm.MessageBox.Show("WARNING: The original Grouping Option was " & AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Exporting.MediaPlanOrderGroupings), _MediaPlanDetail.OrderGrouping) & ". " &
                                                                  "If you proceed with this New Grouping Option, changes to the order may affect billing.", WinForm.MessageBox.MessageBoxButtons.OKCancel, "IMPORTANT") = WinForm.MessageBox.DialogResults.OK Then

                        _HasOrderGroupingBeenChanged = True

                    Else

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

                        ComboBoxOrders_Grouping.SelectedValue = CStr(_MediaPlanDetail.OrderGrouping)

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    End If

                End If

                For Each DataRow In _OrderGroupingLevelLinesDataTable.Rows.OfType(Of System.Data.DataRow)

                    If DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = False Then

                        DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) = ComboBoxOrders_Grouping.GetSelectedValue

                    End If

                Next

                DataGridViewForm_DetailsLevelLines.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub DataGridViewForm_DetailsLevelLines_ShownEditorEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_DetailsLevelLines.ShownEditorEvent

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim MediaPlanOrderGroupings As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            If DataGridViewForm_DetailsLevelLines.CurrentView.FocusedColumn IsNot Nothing AndAlso
                    DataGridViewForm_DetailsLevelLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString Then

                MediaPlanOrderGroupings = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                BindingSource = New System.Windows.Forms.BindingSource
                GridLookUpEdit = CType(DataGridViewForm_DetailsLevelLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                If _MediaPlanDetail.SalesClassType = "R" OrElse _MediaPlanDetail.SalesClassType = "T" Then

                    MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList)

                ElseIf _MediaPlanDetail.SalesClassType = "I" Then

                    If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week OrElse _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    End If

                ElseIf _MediaPlanDetail.SalesClassType = "M" Then

                    MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList)

                ElseIf _MediaPlanDetail.SalesClassType = "N" Then

                    MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                            Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth).ToList)

                ElseIf _MediaPlanDetail.SalesClassType = "O" Then

                    If _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth OrElse
                                                                                                                Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    ElseIf _MediaPlanDetail.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                        MediaPlanOrderGroupings.AddRange(_MediaPlanOrderGroupings.ToList.Where(Function(Entity) Entity.Code = AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period).ToList)

                    End If

                End If

                If DataGridViewForm_DetailsLevelLines.CurrentView.FocusedValue > 0 AndAlso
                        MediaPlanOrderGroupings.Any(Function(Entity) Entity.Code = DataGridViewForm_DetailsLevelLines.CurrentView.FocusedValue) = False Then

                    MediaPlanOrderGroupings.Add(_MediaPlanOrderGroupings.ToList.Single(Function(Entity) Entity.Code = DataGridViewForm_DetailsLevelLines.CurrentView.FocusedValue))

                End If

                BindingSource.DataSource = MediaPlanOrderGroupings

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, GridLookUpEdit.Properties.DisplayMember, GridLookUpEdit.Properties.ValueMember,
                                                                                                  "[None]", 0, True, True)


                GridLookUpEdit.Properties.DataSource = BindingSource

            End If

        End Sub
        Private Sub DataGridViewForm_DetailsLevelLines_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_DetailsLevelLines.ShowingEditorEvent

            'objects
            Dim RowIndex As Integer = -1

            If DataGridViewForm_DetailsLevelLines.CurrentView.FocusedColumn IsNot Nothing AndAlso
                    DataGridViewForm_DetailsLevelLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString Then

                RowIndex = DataGridViewForm_DetailsLevelLines.CurrentView.GetRowCellValue(DataGridViewForm_DetailsLevelLines.CurrentView.FocusedRowHandle, AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)

                If DataGridViewForm_DetailsLevelLines.CurrentView.GetRowCellValue(DataGridViewForm_DetailsLevelLines.CurrentView.FocusedRowHandle, AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.HasMediaOrder.ToString) = True AndAlso
                        DataGridViewForm_DetailsLevelLines.CurrentView.FocusedValue > 0 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailsLevelLines_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_DetailsLevelLines.CustomColumnDisplayTextEvent

            'objects
            Dim MediaPlanOrderGrouping As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            If e.Column.FieldName = AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString Then

                If e.Value = 0 Then

                    e.DisplayText = "[None]"

                Else

                    If _MediaPlanOrderGroupings IsNot Nothing AndAlso _MediaPlanOrderGroupings.Count > 0 Then

                        MediaPlanOrderGrouping = _MediaPlanOrderGroupings.SingleOrDefault(Function(MPOG) MPOG.Code = e.Value)

                        If MediaPlanOrderGrouping IsNot Nothing Then

                            e.DisplayText = MediaPlanOrderGrouping.Description

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DateEditForm_StartDate_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DateEditForm_StartDate.EditValueChanging

            If IsDate(e.NewValue) Then

                If DateEditForm_StartDate.Properties.MinValue <> e.NewValue Then

                    CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                    CheckBoxCreateOrderOptions_Default.Checked = True
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = False
                    CheckBoxCreateOrderOptions_Default.Enabled = False
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Enabled = False

                Else

                    If _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.Default Then

                        CheckBoxCreateOrderOptions_Default.Checked = True
                        CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                        CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = False

                    ElseIf _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.AddToOrder Then

                        CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = True
                        CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                        CheckBoxCreateOrderOptions_Default.Checked = False

                    End If

                    'CheckBoxCreateOrderOptions_Default.Enabled = True
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Enabled = True

                End If

            End If

        End Sub
        Private Sub DateEditForm_EndDate_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DateEditForm_EndDate.EditValueChanging

            If IsDate(e.NewValue) Then

                If DateEditForm_EndDate.Properties.MaxValue <> e.NewValue Then

                    CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                    CheckBoxCreateOrderOptions_Default.Checked = True
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = False
                    CheckBoxCreateOrderOptions_Default.Enabled = False
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Enabled = False

                Else

                    If _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.Default Then

                        CheckBoxCreateOrderOptions_Default.Checked = True
                        CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                        CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = False

                    ElseIf _CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.AddToOrder Then

                        CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked = True
                        CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                        CheckBoxCreateOrderOptions_Default.Checked = False

                    End If

                    'CheckBoxCreateOrderOptions_Default.Enabled = True
                    CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Enabled = True

                End If

            End If

        End Sub
        Private Sub CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.CheckedChanged

            If CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Checked Then

                CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                CheckBoxCreateOrderOptions_Default.Checked = False

            Else

                CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Checked = False
                CheckBoxCreateOrderOptions_Default.Checked = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
