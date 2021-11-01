Imports Telerik.Web.UI

Public Class JobForecast_Edit
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const _BillingPostPeriodColumPrefix As String = "GridNumericColumnBillingPostPeriod"
    Private Const _RevenuePostPeriodColumPrefix As String = "GridNumericColumnRevenuePostPeriod"

#End Region

#Region " Enum "

    Private Enum ToolBarCommand
        Back
        Save
        Approve
        ApproveConfirm
        JobComponents
        CreateRevision
        IndirectCategories
        Unapprove
        DeleteRevision
        Settings
        Bookmark
        DeleteJobComponent
        ExportToExcel
        ActualsByMonth
        Refresh
        ExportOptions
    End Enum

#End Region

#Region " Variables "

    Private _JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
    Private _JobForecastRevisionID As Integer = 0
    Private _SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
    Private _JobForecastSettings As Webvantage.cAppVars = Nothing
    Private _GridSource As System.Data.DataTable = Nothing

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Protected Property GridSource As System.Data.DataTable
        Get

            If _GridSource Is Nothing Then

                _GridSource = BuildJobForecastJobDetailsDataTable(Me.DbContext)

            End If

            GridSource = _GridSource

        End Get
        Set(value As System.Data.DataTable)
            _GridSource = value
        End Set
    End Property
    Protected Property IsHighestRevision As Boolean
        Get
            Try
                IsHighestRevision = ViewState("JF_IsHighestRevision")
            Catch ex As Exception
                IsHighestRevision = False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("JF_IsHighestRevision") = value
        End Set
    End Property
    Protected Property HasMultipleRevisions As Boolean
        Get
            Try
                HasMultipleRevisions = ViewState("JF_HasMultipleRevisions")
            Catch ex As Exception
                HasMultipleRevisions = True
            End Try
        End Get
        Set(value As Boolean)
            ViewState("JF_HasMultipleRevisions") = value
        End Set
    End Property
    Protected Property HasApprovedRevision As Boolean
        Get
            Try
                HasApprovedRevision = ViewState("JF_HasApprovedRevision")
            Catch ex As Exception
                HasApprovedRevision = True
            End Try
        End Get
        Set(value As Boolean)
            ViewState("JF_HasApprovedRevision") = value
        End Set
    End Property
    Protected ReadOnly Property IsRevisionEditable As Boolean
        Get
            Return Not Me.JobForecastRevision.IsApproved AndAlso Me.IsHighestRevision AndAlso Me.CanUserUpdate
        End Get
    End Property
    Protected ReadOnly Property DataContext As AdvantageFramework.Database.DataContext
        Get
            If _DataContext Is Nothing OrElse _DataContext.IsDisposed Then
                _DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DataContext
        End Get
    End Property
    Protected ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing OrElse _DbContext.IsDisposed Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Protected ReadOnly Property JobForecastSettings As Webvantage.cAppVars
        Get
            If _JobForecastSettings Is Nothing Then
                _JobForecastSettings = New cAppVars(cAppVars.Application.JOB_FORECAST, _Session.UserCode, _Session.User.EmployeeCode)
                _JobForecastSettings.getAllAppVars()
            End If
            Return _JobForecastSettings
        End Get
    End Property
    Protected ReadOnly Property JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision
        Get
            If _JobForecastRevision Is Nothing Then
                _JobForecastRevision = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobForecastRevision).Include("JobForecast").Include("JobForecastJobs")
                                        Where Entity.ID = _JobForecastRevisionID
                                        Select Entity).Single
            End If
            Return _JobForecastRevision
        End Get
    End Property
    Protected ReadOnly Property JobForecast As AdvantageFramework.Database.Entities.JobForecast
        Get
            If _JobForecastRevision Is Nothing Then
                _JobForecastRevision = Me.JobForecastRevision
            End If
            Return _JobForecastRevision.JobForecast
        End Get
    End Property
    Protected ReadOnly Property ShowEstimateAmount As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowApprovedEstimateAmount", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Protected ReadOnly Property ForecastType As AdvantageFramework.JobForecast.JobForecastTypes
        Get
            Return CType(Me.JobForecast.ForecastType.GetValueOrDefault(0), AdvantageFramework.JobForecast.JobForecastTypes)
        End Get
    End Property
    Protected ReadOnly Property CanUserUpdate As Boolean
        Get
            If ViewState("JF_CanUserUpdate") Is Nothing Then
                ViewState("JF_CanUserUpdate") = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserUpdate")
        End Get
    End Property
    Protected ReadOnly Property CanUserAdd As Boolean
        Get
            If ViewState("JF_CanUserAdd") Is Nothing Then
                ViewState("JF_CanUserAdd") = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserAdd")
        End Get
    End Property
    Protected ReadOnly Property CanUserPrint As Boolean
        Get
            If ViewState("JF_CanUserPrint") Is Nothing Then
                ViewState("JF_CanUserPrint") = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserPrint")
        End Get
    End Property
    Protected ReadOnly Property FiscalYearStartMonth As Short
        Get

            If ViewState("FiscalYearStartMonth") Is Nothing Then

                ViewState("FiscalYearStartMonth") = AdvantageFramework.JobForecast.LoadFiscalStartMonth(Me.DbContext)

            End If

            Return ViewState("FiscalYearStartMonth")

        End Get
    End Property
    Protected Property ShowActualsByMonth As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowActualsByMonth", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Me.JobForecastSettings.setAppVar("ShowActualsByMonth", value.ToString, "Boolean")
            Me.JobForecastSettings.setAppVarDB("ShowActualsByMonth", value.ToString, "Boolean")
        End Set
    End Property
    Protected ReadOnly Property RadComboBoxGroupOptions As Telerik.Web.UI.RadComboBox
        Get
            Try
                Return DirectCast(RadToolBarButtonGroupOptions.FindControl("RadComboBoxGroupOptions"), Telerik.Web.UI.RadComboBox)
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Protected Property GridGroupByOption As String
        Get
            Try
                Return Me.JobForecastSettings.getAppVar("GridGroupByOption", "String", "C").ToString
            Catch ex As Exception
                Return "C"
            End Try
        End Get
        Set(value As String)
            Me.JobForecastSettings.setAppVar("GridGroupByOption", value, "String")
            Me.JobForecastSettings.setAppVarDB("GridGroupByOption", value, "String")
        End Set
    End Property
    Protected ReadOnly Property ShowSalesClass As Boolean
        Get
            Try
                Return CBool(Me.JobForecastSettings.getAppVar("ShowSalesClass", "Boolean", "False"))
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Protected ReadOnly Property GroupKeys As Generic.List(Of String)
        Get

            Dim GroupKeyList As Generic.List(Of String) = Nothing
            Dim ClientCode As String = Nothing
            Dim SalesClassCode As String = Nothing

            GroupKeyList = New Generic.List(Of String)

            For Each DataRow In Me.GridSource.Rows.OfType(Of System.Data.DataRow)

                ClientCode = DataRow("ClientCode")
                SalesClassCode = DataRow("SalesClassCode")

                If Me.GridGroupByOption = "C" Then

                    GroupKeyList.Add(ClientCode)

                ElseIf Me.GridGroupByOption = "CS" Then

                    GroupKeyList.Add(ClientCode & "|" & SalesClassCode)

                ElseIf Me.GridGroupByOption = "S" Then

                    GroupKeyList.Add(SalesClassCode)

                End If

            Next

            Return GroupKeyList.Distinct().OrderBy(Function(key) key).ToList

        End Get
    End Property

#End Region

#Region " Methods "

    Private Function BuildJobForecastJobDetailsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing

        DataTable = AdvantageFramework.JobForecast.BuildJobForecastJobDetailsDataTable(DbContext, Me.JobForecastRevision)

        BuildJobForecastJobDetailsDataTable = DataTable

    End Function
    Private Function LoadExpandOptions() As Integer

        'objects
        Dim ExpandOption As Integer = 0

        Try

            If Request.QueryString("ExpandOption") IsNot Nothing Then

                ExpandOption = CType(Request.QueryString("ExpandOption"), Integer)

            End If

        Catch ex As Exception
            ExpandOption = 0
        End Try

        LoadExpandOptions = ExpandOption

    End Function
    Private Function SaveJobForecastRevision()

        'objects
        Dim Saved As Boolean = False
        Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing

        Try

            If Me.JobForecastRevision IsNot Nothing Then

                If RadTextBoxComment.Text <> Me.JobForecastRevision.Comment Then

                    Me.JobForecastRevision.Comment = RadTextBoxComment.Text

                    AdvantageFramework.JobForecast.UpdateJobForecastRevision(Me.DbContext, Me.JobForecastRevision)

                End If

                If Me.JobForecast Is Nothing Then

                    JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(Me.DbContext, Me.JobForecastRevision.JobForecastID)

                Else

                    JobForecast = Me.JobForecast

                End If

                If RadTextBoxDescription.Text <> JobForecast.Description OrElse JobForecast.Budget <> RadNumericTextBoxForecastBudget.Value OrElse JobForecast.Budget.HasValue <> RadNumericTextBoxForecastBudget.Value.HasValue Then

                    JobForecast.Description = RadTextBoxDescription.Text
                    JobForecast.Budget = RadNumericTextBoxForecastBudget.Value

                    If String.IsNullOrWhiteSpace(JobForecast.Description) Then

                        Me.ShowMessage("Description is required.")
                        Exit Function

                    End If

                    AdvantageFramework.JobForecast.UpdateJobForecast(Me.DbContext, JobForecast)

                End If

                For Each GridEditableItem In RadGridJobForecast.Items.OfType(Of Telerik.Web.UI.GridEditableItem)()

                    SaveGridItem(GridEditableItem)

                Next

                Saved = True

            End If

        Catch ex As Exception
            Saved = False
        Finally
            SaveJobForecastRevision = Saved
        End Try

    End Function
    Private Sub FormatHeaderRow(ByRef TreeListDataItem As Telerik.Web.UI.TreeListDataItem)

        Try

            DirectCast(TreeListDataItem("TreeListEditCommandColumn"), Telerik.Web.UI.TreeListTableCell).Controls(0).Visible = False

        Catch ex As Exception

        End Try

        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString() Then

            TreeListDataItem.Expanded = True

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.DarkGray
                TableCell.Font.Bold = True
                TableCell.Text = ""

            Next

        Else

            For Each TableCell In TreeListDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                TableCell.BackColor = Drawing.Color.DarkGray
                TableCell.Font.Bold = True

            Next

            Try

                TreeListDataItem.Item("TreeListBoundColumn" & AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).Text = FormatCurrency(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString))

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'objects
        Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

        PropertyDescriptor = AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)

        If PropertyDescriptor IsNot Nothing Then

            RadTextBoxDescription.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

        End If

    End Sub
    Private Sub CheckToCollapseNode(ByVal TreeListDataItem As Telerik.Web.UI.TreeListDataItem, ByVal NestedLevel As Integer)

        If TreeListDataItem.HierarchyIndex.NestedLevel = NestedLevel Then

            If TreeListDataItem.DataItem IsNot Nothing AndAlso TypeOf TreeListDataItem.DataItem Is System.Data.DataRowView Then

                If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString()) <> "" OrElse
                        DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString()) <> AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                    TreeListDataItem.Expanded = False

                End If

            Else

                TreeListDataItem.Expanded = False

            End If

        End If

        If TreeListDataItem.ChildItems.Any Then

            For Each ChildTreeListDataItem In TreeListDataItem.ChildItems.ToList

                CheckToCollapseNode(ChildTreeListDataItem, NestedLevel)

            Next

        End If

    End Sub
    Private Function GetJobForecastRevisionIDFromQueryString() As Integer

        'objects
        Dim JobForecastRevisionID As Integer = Nothing

        Try

            If Request.QueryString("JobForecastRevisionID") IsNot Nothing Then

                JobForecastRevisionID = CType(Request.QueryString("JobForecastRevisionID"), Integer)

            End If

        Catch ex As Exception
            JobForecastRevisionID = 0
        End Try

        GetJobForecastRevisionIDFromQueryString = JobForecastRevisionID

    End Function
    Private Function GetPostPeriodColumns() As Generic.List(Of Telerik.Web.UI.GridNumericColumn)

        GetPostPeriodColumns = RadGridJobForecast.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn).Where(Function(GridTempCol) GridTempCol.UniqueName.StartsWith(_BillingPostPeriodColumPrefix) = True OrElse GridTempCol.UniqueName.StartsWith(_RevenuePostPeriodColumPrefix) = True).ToList()

    End Function
    Private Function CreatePostPeriodColumnYearGroup(ByVal PostPeriodYear As String) As Telerik.Web.UI.GridColumnGroup

        'objects
        Dim Create As Boolean = True
        Dim GridColumnGroup As Telerik.Web.UI.GridColumnGroup = Nothing
        Dim HeaderText As String = Nothing

        If String.IsNullOrWhiteSpace(PostPeriodYear) = False Then

            HeaderText = PostPeriodYear

            If Me.ForecastType <> AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                HeaderText &= " " & AdvantageFramework.EnumUtilities.LoadEnumObject(Me.ForecastType).Description

            End If

            If RadGridJobForecast.MasterTableView.ColumnGroups IsNot Nothing Then

                GridColumnGroup = RadGridJobForecast.MasterTableView.ColumnGroups.Where(Function(ColGroup) ColGroup.HeaderText = HeaderText).FirstOrDefault

            End If

            If GridColumnGroup Is Nothing Then

                GridColumnGroup = RadGridJobForecast.MasterTableView.ColumnGroups.Where(Function(ColGroup) ColGroup.HeaderText = "" AndAlso ColGroup.Name.StartsWith("YearGroup") = True).FirstOrDefault()

                If GridColumnGroup IsNot Nothing Then

                    GridColumnGroup.HeaderText = HeaderText

                End If

            End If

        End If

        CreatePostPeriodColumnYearGroup = GridColumnGroup

    End Function
    Private Function CreatePostPeriodColumnMonthGroup(ByVal YearGridColumnGroup As Telerik.Web.UI.GridColumnGroup, ByVal PostPeriodMonth As String) As Telerik.Web.UI.GridColumnGroup

        'objects
        Dim Create As Boolean = True
        Dim GridColumnGroup As Telerik.Web.UI.GridColumnGroup = Nothing
        Dim ParentGridColumnGroup As Telerik.Web.UI.GridColumnGroup = Nothing

        If YearGridColumnGroup IsNot Nothing AndAlso String.IsNullOrWhiteSpace(PostPeriodMonth) = False Then

            If RadGridJobForecast.MasterTableView.ColumnGroups IsNot Nothing Then

                GridColumnGroup = RadGridJobForecast.MasterTableView.ColumnGroups.Where(Function(ColGroup) ColGroup.HeaderText = PostPeriodMonth AndAlso ColGroup.ParentGroupName = YearGridColumnGroup.Name).FirstOrDefault

            End If

            If GridColumnGroup Is Nothing Then

                GridColumnGroup = RadGridJobForecast.MasterTableView.ColumnGroups.Where(Function(ColGroup) ColGroup.HeaderText = "" AndAlso ColGroup.Name.StartsWith("PostPeriod") = True).FirstOrDefault()

                If GridColumnGroup IsNot Nothing Then

                    GridColumnGroup.ParentGroupName = YearGridColumnGroup.Name
                    GridColumnGroup.HeaderText = PostPeriodMonth

                End If

            End If

        End If

        CreatePostPeriodColumnMonthGroup = GridColumnGroup

    End Function
    Private Sub BuildGridStructure()

        'objects
        Dim BillingGridNumericColumn As Telerik.Web.UI.GridNumericColumn = Nothing
        Dim RevenueGridNumericColumn As Telerik.Web.UI.GridNumericColumn = Nothing
        Dim PostPeriodColumns As Generic.List(Of Telerik.Web.UI.GridNumericColumn) = Nothing
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
        Dim FiscalStartMonth As Short = 0

        If Me.JobForecastRevision IsNot Nothing Then

            With DirectCast(RadGridJobForecast.MasterTableView.GetColumnSafe("GridNumericColumnApprovedEstimateAmount"), Telerik.Web.UI.GridBoundColumn)

                .Visible = Me.ShowEstimateAmount

                If Me.ForecastType = AdvantageFramework.JobForecast.Methods.JobForecastTypes.Revenue Then

                    .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.ApprovedEstimateRevenueAmount.ToString

                Else

                    .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.ApprovedEstimateBillingAmount.ToString

                End If

            End With

            With DirectCast(RadGridJobForecast.MasterTableView.GetColumnSafe("GridBoundColumnSalesClass"), Telerik.Web.UI.GridBoundColumn)

                .Visible = Me.ShowSalesClass AndAlso Me.GridGroupByOption = "C"
                .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.SalesClassDescription.ToString

            End With

            PostPeriodColumns = GetPostPeriodColumns()

            PostPeriodList = AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(Me.DbContext, Me.JobForecast)
            FiscalStartMonth = Me.FiscalYearStartMonth

            For I = 1 To (PostPeriodColumns.Count() / 2)

                PostPeriod = Nothing

                BillingGridNumericColumn = PostPeriodColumns.Where(Function(GridNumCol) GridNumCol.UniqueName = _BillingPostPeriodColumPrefix & I.ToString).SingleOrDefault
                RevenueGridNumericColumn = PostPeriodColumns.Where(Function(GridNumCol) GridNumCol.UniqueName = _RevenuePostPeriodColumPrefix & I.ToString).SingleOrDefault

                If PostPeriodList.Count() >= I Then

                    Try

                        PostPeriod = PostPeriodList(I - 1)

                    Catch ex As Exception

                    End Try

                End If

                SetupPostPeriodInputColumns(BillingGridNumericColumn, RevenueGridNumericColumn, PostPeriod, FiscalStartMonth)

            Next

        End If

    End Sub
    Private Sub SetupPostPeriodInputColumns(ByVal BillingGridNumericColumn As Telerik.Web.UI.GridNumericColumn,
                                            ByVal RevenueGridNumericColumn As Telerik.Web.UI.GridNumericColumn,
                                            ByVal PostPeriod As AdvantageFramework.Database.Entities.PostPeriod,
                                            ByVal FiscalStartMonth As Short)

        'objects
        Dim YearGridColumnGroup As Telerik.Web.UI.GridColumnGroup = Nothing
        Dim MonthGridColumnGroup As Telerik.Web.UI.GridColumnGroup = Nothing
        Dim Month As String = Nothing
        Dim GroupName As String = Nothing
        Dim BillingHeader As String = Nothing
        Dim RevenueHeader As String = Nothing
        Dim ActualMonth As Short = Nothing

        If BillingGridNumericColumn Is Nothing Then

            BillingGridNumericColumn = New Telerik.Web.UI.GridNumericColumn

        End If

        If RevenueGridNumericColumn Is Nothing Then

            RevenueGridNumericColumn = New Telerik.Web.UI.GridNumericColumn

        End If

        If PostPeriod IsNot Nothing Then

            ActualMonth = CInt(PostPeriod.Month.GetValueOrDefault(0)) + (FiscalStartMonth - 1)

            If ActualMonth > 12 Then

                ActualMonth = ActualMonth - 12

            End If

            Month = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ActualMonth)

            YearGridColumnGroup = CreatePostPeriodColumnYearGroup(PostPeriod.Year)

            If Me.ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                MonthGridColumnGroup = CreatePostPeriodColumnMonthGroup(YearGridColumnGroup, Month)

                GroupName = MonthGridColumnGroup.Name
                BillingHeader = "Billing"
                RevenueHeader = "Revenue"

            Else

                GroupName = YearGridColumnGroup.Name
                BillingHeader = Month
                RevenueHeader = Month

            End If

            BillingGridNumericColumn.ColumnGroupName = GroupName
            RevenueGridNumericColumn.ColumnGroupName = GroupName

            If Me.ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Billing OrElse Me.ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                BillingGridNumericColumn.DataField = AdvantageFramework.JobForecast.GetBillingPostPeriodColumnDataField(PostPeriod.Code)
                BillingGridNumericColumn.HeaderText = BillingHeader
                BillingGridNumericColumn.Visible = True
                BillingGridNumericColumn.ReadOnly = False

            Else

                BillingGridNumericColumn.Visible = False
                BillingGridNumericColumn.ReadOnly = True

            End If

            If Me.ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.Revenue OrElse Me.ForecastType = AdvantageFramework.JobForecast.JobForecastTypes.BillingAndRevenue Then

                RevenueGridNumericColumn.DataField = AdvantageFramework.JobForecast.GetRevenuePostPeriodColumnDataField(PostPeriod.Code)
                RevenueGridNumericColumn.HeaderText = RevenueHeader
                RevenueGridNumericColumn.Visible = True
                RevenueGridNumericColumn.ReadOnly = False

            Else

                RevenueGridNumericColumn.Visible = False
                RevenueGridNumericColumn.ReadOnly = True

            End If

        Else

            BillingGridNumericColumn.ReadOnly = True
            BillingGridNumericColumn.Visible = False

            RevenueGridNumericColumn.ReadOnly = True
            RevenueGridNumericColumn.Visible = False

        End If

    End Sub
    Private Sub SaveJobForecastJobDetail(ByVal PostPeriodCode As String, ByVal Value As Decimal?)

        'objects
        Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing

        JobForecastJobDetail = (From Item In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastRevisionID(Me.DbContext, _JobForecastRevisionID)
                                Where Item.PostPeriod = PostPeriodCode
                                Select Item).SingleOrDefault

        If JobForecastJobDetail IsNot Nothing Then

            If JobForecastJobDetail.BillingAmount <> Value Then

                JobForecastJobDetail.BillingAmount = Value

                AdvantageFramework.JobForecast.UpdateJobForecastJobDetail(Me.DbContext, JobForecastJobDetail)

            End If

        ElseIf Value.HasValue Then



        End If

    End Sub
    Private Sub SaveGridItem(ByVal GridEditableItem As Telerik.Web.UI.GridEditableItem)

        'objects
        Dim JobForecastJobID As Integer = Nothing
        Dim OriginalValues As Hashtable = Nothing
        Dim NewValues As Hashtable = Nothing
        Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
        Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
        Dim ChangedPostPeriods As Hashtable = Nothing

        OriginalValues = GridEditableItem.SavedOldValues
        NewValues = New Hashtable
        GridEditableItem.OwnerTableView.ExtractValuesFromItem(NewValues, GridEditableItem)

        JobForecastJobID = CInt(GridEditableItem.GetDataKeyValue("JobForecastJobID"))

        For Each DictionaryEntry In NewValues.OfType(Of DictionaryEntry)()

            If DictionaryEntry.Value <> OriginalValues(DictionaryEntry.Key) Then

                If DictionaryEntry.Key = AdvantageFramework.JobForecast.StaticJobForecastColumn.Actual.ToString OrElse
                    DictionaryEntry.Key = AdvantageFramework.JobForecast.StaticJobForecastColumn.Comments.ToString Then

                    If JobForecastJob Is Nothing Then

                        JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(Me.DbContext, JobForecastJobID)

                    End If

                    If JobForecastJob IsNot Nothing Then

                        Try

                            JobForecastJob.IncomeAmount = CDec(NewValues(AdvantageFramework.JobForecast.StaticJobForecastColumn.Actual.ToString))

                        Catch ex As Exception
                            JobForecastJob.IncomeAmount = Nothing
                        End Try

                        JobForecastJob.Comment = NewValues(AdvantageFramework.JobForecast.StaticJobForecastColumn.Comments.ToString)

                    End If

                Else

                    'all other editable columns are post period columns
                    If ChangedPostPeriods Is Nothing Then

                        ChangedPostPeriods = New Hashtable

                    End If

                    If ChangedPostPeriods IsNot Nothing Then

                        ChangedPostPeriods.Add(DictionaryEntry.Key, DictionaryEntry.Value)

                    End If

                End If

            End If

        Next

        If ChangedPostPeriods IsNot Nothing AndAlso ChangedPostPeriods.Count > 0 Then

            AdvantageFramework.JobForecast.UpdateJobForecastJobDetailBatch(Me.DbContext, JobForecastJobID, ChangedPostPeriods)

        End If

        If JobForecastJob IsNot Nothing Then

            AdvantageFramework.JobForecast.UpdateJobForecastJob(Me.DbContext, JobForecastJob)

        End If

    End Sub
    Private Function DeleteGridItem(ByVal GridEditableItem As Telerik.Web.UI.GridEditableItem) As Boolean

        'objects
        Dim JobForecastJobID As Integer = Nothing
        Dim Deleted As Boolean = False

        Try

            If GridEditableItem IsNot Nothing Then

                JobForecastJobID = CInt(GridEditableItem.GetDataKeyValue("JobForecastJobID"))

                Deleted = AdvantageFramework.JobForecast.DeleteJobForecastJobFromForecast(Me.DbContext, JobForecastJobID)

            End If

        Catch ex As Exception
            Deleted = False
        Finally
            DeleteGridItem = Deleted
        End Try

    End Function
    Private Sub HideOrShowRadToolBarButton(ByVal RadToolBarButton As Telerik.Web.UI.RadToolBarButton, ByVal Visible As Boolean)

        'objects
        Dim IsButtonSurroundedBySeparators As Boolean = False
        Dim RadToolBar As Telerik.Web.UI.RadToolBar = Nothing
        Dim RadToolBarItem As Telerik.Web.UI.RadToolBarItem = Nothing

        RadToolBar = RadToolBarButton.ToolBar

        RadToolBarItem = RadToolBar.Items(RadToolBarButton.Index - 1)

        If TypeOf RadToolBarItem Is Telerik.Web.UI.RadToolBarButton AndAlso CType(RadToolBarItem, Telerik.Web.UI.RadToolBarButton).IsSeparator = True Then

            RadToolBarItem = RadToolBar.Items(RadToolBarButton.Index + 1)

            If TypeOf RadToolBarItem Is Telerik.Web.UI.RadToolBarButton AndAlso CType(RadToolBarItem, Telerik.Web.UI.RadToolBarButton).IsSeparator = True Then

                IsButtonSurroundedBySeparators = True

            End If

        End If

        RadToolBarButton.Visible = Visible

        If IsButtonSurroundedBySeparators Then

            RadToolBarItem.Visible = Visible

        End If

    End Sub
    Private Sub CheckUserRights()

        If Not Me.CanUserUpdate Then

            DisableMenuItem(RadToolBarButtonSave)
            DisableMenuItem(RadToolBarButtonGridJobComponents)
            DisableMenuItem(RadToolBarButtonDeleteRevision)
            DisableMenuItem(RadToolBarButtonApprove)
            DisableMenuItem(RadToolBarButtonUnapprove)
            DisableMenuItem(RadToolBarButtonActualize)
            RadToolTipActualize.Enabled = False
            DisableMenuItem(RadToolBarButtonAllocate)
            RadToolTipAllocate.Enabled = False
            DisableMenuItem(RadToolBarButtonGridDelete)

        End If

        If Not Me.CanUserAdd Then

            DisableMenuItem(RadToolBarButtonCreateRevision)

        End If

        If Not Me.CanUserPrint Then

            DisableMenuItem(RadToolBarDropDownExport)

        End If

    End Sub
    Private Sub DisableMenuItem(ByVal RadToolBarItem As Telerik.Web.UI.RadToolBarItem)

        With RadToolBarItem

            .Enabled = False

            If TypeOf RadToolBarItem Is Telerik.Web.UI.RadToolBarButton Then

                With DirectCast(RadToolBarItem, Telerik.Web.UI.RadToolBarButton)

                    .Value = Nothing
                    .CommandName = Nothing

                End With

            End If

        End With

    End Sub
    Private Sub SetupGridGrouping()

        'objects
        Dim GridGroupByExpression As Telerik.Web.UI.GridGroupByExpression = Nothing
        Dim IsSalesClassVisible As Boolean = False
        Dim SalesClassColumn As Telerik.Web.UI.GridColumn = Nothing

        RadGridJobForecast.MasterTableView.GroupByExpressions.Clear()

        GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression

        Select Case Me.GridGroupByOption

            Case "C"

                GridGroupByExpression.SelectFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientName"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientName"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientCode"})
                IsSalesClassVisible = Me.ShowSalesClass

            Case "CS"

                GridGroupByExpression.SelectFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientName"})
                GridGroupByExpression.SelectFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassDescription"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientName"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "ClientCode"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassDescription"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassCode"})
                IsSalesClassVisible = False

            Case "S"

                GridGroupByExpression.SelectFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassDescription"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassDescription"})
                GridGroupByExpression.GroupByFields.Add(New Telerik.Web.UI.GridGroupByField With {.FieldName = "SalesClassCode"})
                IsSalesClassVisible = False

        End Select

        SalesClassColumn = RadGridJobForecast.MasterTableView.GetColumnSafe("GridBoundColumnSalesClass")

        If SalesClassColumn IsNot Nothing Then

            SalesClassColumn.Visible = IsSalesClassVisible

        End If

        RadGridJobForecast.MasterTableView.GroupByExpressions.Add(GridGroupByExpression)

    End Sub

#Region "  Form Event Handlers "

    Private Sub JobForecast_Edit_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.GridSource = Nothing

        End If

        RadToolBarButtonGridDelete.ToolTip = "Delete selected row(s)"

        _JobForecastRevisionID = GetJobForecastRevisionIDFromQueryString()

        BuildGridStructure()

    End Sub
    Private Sub JobForecast_Edit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim TreeListBoundColumn As Telerik.Web.UI.TreeListBoundColumn = Nothing
        Dim TreeListEditCommandColumn As Telerik.Web.UI.TreeListEditCommandColumn = Nothing
        Dim CommandName As String = ""
        Dim LoadGrid As Boolean = True
        Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        Dim TotalColumnWidth As Long = 0
        Dim JobForecastRevisions As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastRevision) = Nothing
        Dim ExpandOption As Integer = 0
        Dim IsBookmark As Boolean = False
        Dim DataField As String = ""
        Dim PostPeriodStart As String = Nothing
        Dim PostPeriodEnd As String = Nothing
        Dim UserThemeSettings As Webvantage.UserThemeSettings = Nothing
        Dim ActualMonth As Short = Nothing

        If Request.QueryString("bm") Is Nothing Then
            Me.PageTitle = "Job Forecast"
        End If

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)

        LoadControlSettings(Me.DbContext)

        If Me.IsPostBack Then

            LoadGrid = False

        End If

        If LoadGrid Then

            SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(Me.DataContext)

            If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                _JobForecastRevision = Nothing

            End If

            If Me.JobForecastRevision IsNot Nothing Then

                If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                    JobForecastRevisions = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(Me.DbContext, Me.JobForecastRevision.JobForecastID).ToList

                    If Me.JobForecastRevision.RevisionNumber = JobForecastRevisions.Select(Function(JfRev) JfRev.RevisionNumber).Max Then

                        Me.IsHighestRevision = True

                    Else

                        Me.IsHighestRevision = False

                    End If

                    Me.HasApprovedRevision = JobForecastRevisions.Any(Function(item) item.IsApproved = True)

                    Me.HasMultipleRevisions = JobForecastRevisions.Count > 1

                    RadToolBarButtonSave.Enabled = Me.IsRevisionEditable
                    HideOrShowRadToolBarButton(RadToolBarButtonApprove, Not Me.JobForecastRevision.IsApproved)
                    HideOrShowRadToolBarButton(RadToolBarButtonUnapprove, Me.JobForecastRevision.IsApproved)
                    HideOrShowRadToolBarButton(RadToolBarButtonAllocate, Me.IsRevisionEditable)
                    HideOrShowRadToolBarButton(RadToolBarButtonActualize, Me.IsRevisionEditable)
                    RadToolBarButtonDeleteRevision.Enabled = Not Me.JobForecastRevision.IsApproved
                    RadToolBarButtonGridJobComponents.Enabled = Me.IsRevisionEditable
                    RadToolBarButtonGridDelete.Enabled = Me.IsRevisionEditable
                    RadToolBarButtonActualsByMonth.Checked = Me.ShowActualsByMonth

                    If Me.RadComboBoxGroupOptions IsNot Nothing Then

                        Me.RadComboBoxGroupOptions.SelectedValue = Me.GridGroupByOption

                    End If

                    SetupGridGrouping()

                    UserThemeSettings = New Webvantage.UserThemeSettings

                    UserThemeSettings.BindColorPicker(TryCast(RadContextMenuGrid.FindItemByValue("Color").FindControl("RadColorPickerGrid"), Telerik.Web.UI.RadColorPicker))

                    If RadToolBarButtonApprove.Visible Then

                        If JobForecastRevisions.Any(Function(JfRev) JfRev.IsApproved = True) Then

                            RadToolBarButtonApprove.CommandName = Me.ToolBarCommand.ApproveConfirm.ToString
                            RadToolBarButtonApprove.CommandArgument = [String].Format("Approval of revision ({0}) will be removed and this revision ({1}) will be approved.",
                                                                                      AdvantageFramework.StringUtilities.PadWithCharacter(JobForecastRevisions.Single(Function(JfRev) JfRev.IsApproved = True).RevisionNumber.ToString, 3, "0", True),
                                                                                      AdvantageFramework.StringUtilities.PadWithCharacter(Me.JobForecastRevision.RevisionNumber.ToString, 3, "0", True))

                        Else

                            RadToolBarButtonApprove.CommandName = Me.ToolBarCommand.Approve.ToString
                            RadToolBarButtonApprove.CommandArgument = Nothing

                        End If

                    End If

                    DropDownListJobForecastRevision.DataSource = (From JobForecastRevision In JobForecastRevisions
                                                                  Select [Number] = AdvantageFramework.StringUtilities.PadWithCharacter(JobForecastRevision.RevisionNumber, 3, "0", True),
                                                                         [ID] = JobForecastRevision.ID).ToList
                    DropDownListJobForecastRevision.DataBind()
                    DropDownListJobForecastRevision.SelectedValue = Me.JobForecastRevision.ID

                    If JobForecastRevisions.Count = 1 Then

                        RadToolBarButtonDeleteRevision.Text = "Delete Forecast"
                        RadToolBarButtonDeleteRevision.CommandName = "Delete"
                        RadToolBarButtonDeleteRevision.ToolTip = "Delete forecast"

                    Else

                        RadToolBarButtonDeleteRevision.Text = "Delete Revision"
                        RadToolBarButtonDeleteRevision.CommandName = "DeleteRevision"
                        RadToolBarButtonDeleteRevision.ToolTip = "Delete revision"

                    End If

                    If Me.JobForecastRevision.IsApproved = True Then

                        LabelApproved.Visible = True
                        LabelApproved.Text = "Approved"

                    End If

                    RadContextMenuGrid.Enabled = Me.IsRevisionEditable
                    RadContextMenuGrid.Visible = Me.IsRevisionEditable
                    RadContextMenuDelete.Visible = Me.IsRevisionEditable

                    RadTextBoxDescription.ReadOnly = Not Me.IsRevisionEditable
                    RadTextBoxComment.ReadOnly = Not Me.IsRevisionEditable
                    RadNumericTextBoxForecastBudget.ReadOnly = Not Me.IsRevisionEditable

                    With AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(Me.DbContext, Me.JobForecast.PostPeriodStart)

                        ActualMonth = .Month.GetValueOrDefault(0) + (Me.FiscalYearStartMonth - 1)

                        If ActualMonth > 12 Then

                            ActualMonth = ActualMonth - 12

                        End If

                        PostPeriodStart = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ActualMonth) & " " & .StartDate.Value.Year

                    End With

                    With AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(Me.DbContext, Me.JobForecast.PostPeriodEnd)

                        ActualMonth = .Month.GetValueOrDefault(0) + (Me.FiscalYearStartMonth - 1)

                        If ActualMonth > 12 Then

                            ActualMonth = ActualMonth - 12

                        End If

                        PostPeriodEnd = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ActualMonth) & " " & .StartDate.Value.Year

                    End With

                    LabelMonthYear.Text = PostPeriodStart & " - " & PostPeriodEnd
                    LabelAssignedEmployee.Text = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(Me.DbContext, Me.JobForecast.AssignedToEmployeeCode).ToString
                    LabelOffice.Text = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(Me.DbContext, Me.JobForecast.OfficeCode).ToString
                    RadTextBoxDescription.Text = Me.JobForecast.Description
                    RadTextBoxComment.Text = Me.JobForecastRevision.Comment
                    RadNumericTextBoxForecastBudget.Value = Me.JobForecast.Budget

                    LabelCreatedBy.Text = ""
                    LabelModifiedBy.Text = ""
                    LabelApprovedBy.Text = ""

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each SecEmployee In (From SecUser In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee")
                                                 Where SecUser.UserCode = Me.JobForecastRevision.CreatedByUserCode OrElse
                                                       SecUser.UserCode = Me.JobForecastRevision.ModifiedByUserCode OrElse
                                                       SecUser.UserCode = Me.JobForecastRevision.ApprovedByUserCode
                                                 Select SecUser.Employee).ToList

                            If Me.JobForecastRevision.CreatedByUserCode <> "" Then

                                LabelCreatedBy.Text = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(Me.TimeZoneOffset, Me.JobForecastRevision.CreatedDate))

                            End If

                            If Me.JobForecastRevision.ModifiedByUserCode IsNot Nothing Then

                                LabelModifiedBy.Text = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(Me.TimeZoneOffset, Me.JobForecastRevision.ModifiedDate))

                            End If

                            If Me.JobForecastRevision.ApprovedByUserCode IsNot Nothing Then

                                LabelApprovedBy.Text = SecEmployee.ToString & " on " & LoGlo.FormatDateTime(AdvantageFramework.Database.Procedures.Generic.GetOffsetDateTime(Me.TimeZoneOffset, Me.JobForecastRevision.ApprovedDate))

                            End If

                        Next

                    End Using

                    RadComboBoxPostPeriodCutoff.DataSource = (From Item In AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(Me.DbContext, Me.JobForecast)
                                                              Order By Item.StartDate Descending
                                                              Select [Code] = Item.Code,
                                                                     [Description] = Item.Code & " - " & Item.Description).ToList
                    RadComboBoxPostPeriodCutoff.DataBind()

                    RadGridJobForecast.PageSize = MiscFN.LoadPageSize(RadGridJobForecast.ID)

                    If RadGridJobForecast.PageSize > 20 Then

                        RadGridJobForecast.PageSize = 20

                    End If

                End If

            Else

                If Not Request.QueryString("bm") Is Nothing Then

                    If Request.QueryString("bm") = "1" Then

                        IsBookmark = True

                    End If

                End If

                If IsBookmark = True Then

                    Me.ShowMessage("Job Forecast is no longer available. Please delete your bookmark.")
                    Me.CloseThisWindow()

                Else

                    LabelAssignedEmployee.Text = ""
                    LabelMonthYear.Text = ""
                    RadTextBoxDescription.Text = ""
                    LabelCreatedBy.Text = ""
                    LabelModifiedBy.Text = ""
                    LabelApprovedBy.Text = ""

                End If

            End If

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.RadToolBarJobForecastRevision.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        End If

        ''This just reloads the page???
        ''Removed for:  734-1-4396 - Issues with Telerik ASP.Net AJAX upgrade
        'Me.AddJavascriptToPage("setWindowNavigateUrl('JobForecast_Edit.aspx?" & Request.QueryString.ToString & "')")

        CheckUserRights()

    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        RadToolTipAllocate.Visible = RadToolBarButtonAllocate.Enabled
        RadToolTipActualize.Visible = RadToolBarButtonActualize.Enabled

    End Sub
    Private Sub JobForecast_Edit_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

            End If

        Catch ex As Exception

        End Try

        Try

            If _DataContext IsNot Nothing Then

                _DataContext.Dispose()

            End If

        Catch ex As Exception

        End Try

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridJobForecast_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobForecast.ItemCommand

        If e.CommandName = Telerik.Web.UI.RadGrid.UpdateCommandName Then

            If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then

                SaveGridItem(e.Item)

                Me.GridSource = Nothing

            End If

        ElseIf e.CommandName = Telerik.Web.UI.RadGrid.DeleteCommandName Then

            If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then

                DeleteGridItem(e.Item)

                Me.GridSource = Nothing

            End If

        End If

        RadGridJobForecast.Rebind()

    End Sub
    Private Sub RadGridJobForecast_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobForecast.ItemCreated

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing
        Dim GridGroupFooterItem As Telerik.Web.UI.GridGroupFooterItem = Nothing
        Dim MonthActual As Decimal = Nothing
        Dim GroupKey As String = Nothing
        Dim DataRowView As System.Data.DataRowView = Nothing
        Dim DisplayedComponents As String() = Nothing

        If _GridSource IsNot Nothing Then

            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem OrElse
            TypeOf e.Item Is Telerik.Web.UI.GridGroupFooterItem Then

                Try

                    DataRowView = DirectCast(e.Item, Telerik.Web.UI.GridItem).DataItem

                Catch ex As Exception

                End Try

                If DataRowView IsNot Nothing Then

                    If Me.GridGroupByOption = "C" Then

                        GroupKey = DataRowView("ClientCode")

                    ElseIf Me.GridGroupByOption = "CS" Then

                        GroupKey = DataRowView("ClientCode") & "|" & DataRowView("SalesClassCode")

                    ElseIf Me.GridGroupByOption = "S" Then

                        GroupKey = DataRowView("SalesClassCode")

                    End If

                End If

                DirectCast(e.Item, Telerik.Web.UI.GridItem).Attributes("GrpIdx") = Me.GroupKeys.IndexOf(GroupKey)

            End If

            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                For Each GridColumn In RadGridJobForecast.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

                    If TypeOf GridColumn Is Telerik.Web.UI.GridNumericColumn Then

                        With DirectCast(GridColumn, Telerik.Web.UI.GridNumericColumn)

                            .ItemStyle.HorizontalAlign = HorizontalAlign.Right
                            .AllowRounding = True
                            .NumericType = Telerik.Web.UI.NumericType.Number
                            .DataFormatString = "{0:N2}"
                            .DecimalDigits = 2

                            If e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

                                For Each RadNumericTextBox In GridDataItem(.UniqueName).Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox)()

                                    RadNumericTextBox.CssClass = "radgrid-amount-input radPreventDecorate"
                                    RadNumericTextBox.WrapperCssClass = "radgrid-amount-input radPreventDecorate"
                                    RadNumericTextBox.NumberFormat.DecimalDigits = 2
                                    RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
                                    RadNumericTextBox.EnabledStyle.HorizontalAlign = HorizontalAlign.Right

                                    If .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.Forecast.ToString OrElse
                                        .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.Actual.ToString OrElse
                                        .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.Variance.ToString OrElse
                                        .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.ApprovedEstimateBillingAmount.ToString OrElse
                                        .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.ApprovedEstimateRevenueAmount.ToString OrElse
                                        .DataField = AdvantageFramework.JobForecast.StaticJobForecastColumn.ApprovedEstimateAmount.ToString Then

                                        RadNumericTextBox.Enabled = False
                                        RadNumericTextBox.ReadOnly = True

                                        RadNumericTextBox.Attributes("MonthActual") = "&nbsp;"

                                    Else

                                        RadNumericTextBox.Enabled = Me.IsRevisionEditable
                                        RadNumericTextBox.ReadOnly = Not RadNumericTextBox.Enabled
                                        RadNumericTextBox.MaxValue = 9999999.99

                                        MonthActual = 0

                                        Try

                                            If Not IsDBNull(DirectCast(e.Item.DataItem, System.Data.DataRowView)(.DataField & "_Actual")) Then

                                                MonthActual = DirectCast(e.Item.DataItem, System.Data.DataRowView)(.DataField & "_Actual")

                                            End If

                                        Catch ex As Exception
                                            MonthActual = 0
                                        End Try

                                        RadNumericTextBox.Attributes("MonthActual") = MonthActual.ToString("N2")

                                    End If

                                    If Me.IsHighestRevision Then

                                        If .UniqueName.StartsWith(_BillingPostPeriodColumPrefix) OrElse .UniqueName.StartsWith(_RevenuePostPeriodColumPrefix) Then

                                            RadNumericTextBox.ClientEvents.OnValueChanged = "updateAmount"

                                        End If

                                    End If

                                Next

                            End If

                        End With

                    End If

                Next

            ElseIf TypeOf e.Item Is Telerik.Web.UI.GridGroupFooterItem Then

                GridGroupFooterItem = TryCast(e.Item, Telerik.Web.UI.GridGroupFooterItem)
                GridGroupFooterItem.HorizontalAlign = HorizontalAlign.NotSet

                For Each GridNumericColumn In RadGridJobForecast.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn).Where(Function(col) col.Visible = True).ToList

                    Dim RadNumericTextBoxTotal As Telerik.Web.UI.RadNumericTextBox = Nothing

                    RadNumericTextBoxTotal = New Telerik.Web.UI.RadNumericTextBox

                    With RadNumericTextBoxTotal

                        .ID = GridNumericColumn.DataField & "_Group_Total"
                        .Enabled = False
                        .ReadOnly = True
                        .CssClass = "radgrid-amount-input radPreventDecorate"
                        .WrapperCssClass = "radgrid-amount-input radPreventDecorate"
                        .NumberFormat.DecimalDigits = 2
                        .NumberFormat.KeepTrailingZerosOnFocus = True
                        .EnabledStyle.HorizontalAlign = HorizontalAlign.Right

                    End With

                    GridGroupFooterItem(GridNumericColumn.UniqueName).Controls.Add(RadNumericTextBoxTotal)

                Next

            ElseIf TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then

                GridFooterItem = TryCast(e.Item, Telerik.Web.UI.GridFooterItem)

                Try

                    DisplayedComponents = (From Item In RadGridJobForecast.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)
                                           Where Item.DataItem IsNot Nothing AndAlso TypeOf Item.DataItem Is System.Data.DataRowView
                                           Let DataRow = DirectCast(Item.DataItem, System.Data.DataRowView)
                                           Select [JfJobID] = DataRow("JobForecastJobID").ToString()).ToArray

                Catch ex As Exception

                End Try

                Dim FirstColumn As Telerik.Web.UI.GridColumn = Nothing
                Dim LastColumn As Telerik.Web.UI.GridColumn = Nothing

                FirstColumn = RadGridJobForecast.MasterTableView.GetColumn("GridTemplateColumnJobAndComponent")
                LastColumn = RadGridJobForecast.MasterTableView.GetColumn("GridNumericColumnApprovedEstimateAmount")

                With RadGridJobForecast.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn).Where(Function(gc) gc.OrderIndex >= FirstColumn.OrderIndex AndAlso gc.OrderIndex < LastColumn.OrderIndex).ToList

                    GridFooterItem(FirstColumn).ColumnSpan = .Where(Function(gc) gc.Visible = True).Count()
                    GridFooterItem(FirstColumn).Text = "<div style='font-weight:bold;text-align:right;'>Forecast Totals:</div>"

                    .ForEach(Function(gc)

                                 If gc.OrderIndex <> FirstColumn.OrderIndex Then

                                     GridFooterItem(gc).Visible = False

                                 End If

                             End Function)

                End With

                For Each GridNumericColumn In RadGridJobForecast.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn).Where(Function(col) col.Visible = True).ToList

                    Dim RadNumericTextBoxTotal As Telerik.Web.UI.RadNumericTextBox = Nothing
                    Dim NonDisplayedSum As Decimal = Nothing

                    RadNumericTextBoxTotal = New Telerik.Web.UI.RadNumericTextBox

                    Try

                        NonDisplayedSum = (From DataRow In Me.GridSource.Rows.OfType(Of System.Data.DataRow)
                                           Where DisplayedComponents.Contains(DataRow("JobForecastJobID").ToString) = False
                                           Let Val = DataRow(GridNumericColumn.DataField)
                                           Select CDec(If(IsDBNull(Val), 0, Val))).Sum()

                    Catch ex As Exception

                    End Try

                    With RadNumericTextBoxTotal

                        .ID = GridNumericColumn.DataField & "_Total"
                        .Enabled = False
                        .ReadOnly = True
                        .CssClass = "radgrid-amount-input radPreventDecorate"
                        .WrapperCssClass = "radgrid-amount-input radPreventDecorate"
                        .NumberFormat.DecimalDigits = 2
                        .NumberFormat.KeepTrailingZerosOnFocus = True
                        .EnabledStyle.HorizontalAlign = HorizontalAlign.Right
                        .Attributes("oItems") = NonDisplayedSum

                    End With

                    GridFooterItem(GridNumericColumn.UniqueName).Controls.Add(RadNumericTextBoxTotal)

                Next

            End If

        End If

    End Sub
    Private Sub RadGridJobForecast_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobForecast.ItemDataBound

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim HiddenFieldRowColor As System.Web.UI.WebControls.HiddenField = Nothing
        Dim LabelJobAndComponent As System.Web.UI.WebControls.Label = Nothing
        Dim DataRow As System.Data.DataRow = Nothing
        Dim JobComponentText As String = Nothing
        Dim GroupHeaderText As String = ""
        Dim SalesClassDescription As String = ""

        If _GridSource IsNot Nothing Then

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse
            e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse
            e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

                Try

                    GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                Catch ex As Exception

                End Try

                If GridDataItem IsNot Nothing Then

                    If GridDataItem.DataItem IsNot Nothing AndAlso TypeOf GridDataItem.DataItem Is System.Data.DataRowView Then

                        DataRow = TryCast(GridDataItem.DataItem, System.Data.DataRowView).Row

                    End If

                    LabelJobAndComponent = TryCast(GridDataItem.FindControl("LabelJobAndComponent"), System.Web.UI.WebControls.Label)

                    JobComponentText = String.Format("{0} - {1} {2}",
                                                     AdvantageFramework.StringUtilities.PadWithCharacter(DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.JobNumber.ToString), 6, "0", True),
                                                     AdvantageFramework.StringUtilities.PadWithCharacter(DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.JobComponentNumber.ToString), 3, "0", True),
                                                     DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.JobComponentDescription.ToString))

                    LabelJobAndComponent.Text = JobComponentText
                    LabelJobAndComponent.ToolTip = JobComponentText

                    HiddenFieldRowColor = TryCast(GridDataItem.FindControl("HiddenFieldRowColor"), System.Web.UI.WebControls.HiddenField)

                    HiddenFieldRowColor.Value = Nothing

                    If DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.Color.ToString) IsNot Nothing Then

                        Try

                            GridDataItem.BackColor = System.Drawing.Color.FromArgb(CInt(DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.Color.ToString)))
                            HiddenFieldRowColor.Value = System.Drawing.ColorTranslator.ToHtml(GridDataItem.BackColor)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.GroupHeader Then

                If TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then

                    With DirectCast(e.Item, Telerik.Web.UI.GridGroupHeaderItem)

                        If Me.RadComboBoxGroupOptions IsNot Nothing Then

                            DataRow = CType(.DataItem, System.Data.DataRowView).Row

                            Select Case Me.RadComboBoxGroupOptions.SelectedItem.Value

                                Case "C"

                                    GroupHeaderText = String.Format("Client: {0}", DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.ClientName.ToString).ToString)

                                Case "S"

                                    SalesClassDescription = DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.SalesClassDescription.ToString).ToString

                                    If String.IsNullOrWhiteSpace(SalesClassDescription) Then

                                        SalesClassDescription = "[None]"

                                    End If

                                    GroupHeaderText = String.Format("Sales Class: {0}", SalesClassDescription)

                                Case "CS"

                                    SalesClassDescription = DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.SalesClassDescription.ToString).ToString

                                    If String.IsNullOrWhiteSpace(SalesClassDescription) Then

                                        SalesClassDescription = "[None]"

                                    End If

                                    GroupHeaderText = String.Format("Client: {0}&nbsp;&nbsp;|&nbsp;&nbsp;Sales Class: {1}", DataRow(AdvantageFramework.JobForecast.StaticJobForecastColumn.ClientName.ToString).ToString, SalesClassDescription)

                            End Select

                        End If

                        If Not String.IsNullOrWhiteSpace(GroupHeaderText) Then

                            .DataCell.Text = GroupHeaderText

                        End If

                    End With

                End If

            End If

        End If

    End Sub
    Private Sub RadGridJobForecast_PreRender(sender As Object, e As EventArgs) Handles RadGridJobForecast.PreRender

        'objects
        Dim Rebind As Boolean = False
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        For Each Item In RadGridJobForecast.MasterTableView.Items

            If TypeOf Item Is Telerik.Web.UI.GridEditableItem Then

                GridEditableItem = CType(Item, Telerik.Web.UI.GridDataItem)

                If GridEditableItem.Edit = False Then

                    GridEditableItem.Edit = True
                    Rebind = True

                End If

            End If

        Next

        With DirectCast(RadGridJobForecast.MasterTableView.GetColumn("ExpandColumn"), Telerik.Web.UI.GridExpandColumn)

            .HeaderButtonType = Telerik.Web.UI.GridHeaderButtonType.PushButton

        End With

        If Rebind Then

            RadGridJobForecast.Rebind()

        End If

    End Sub
    Private Sub RadGridJobForecast_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobForecast.NeedDataSource

        RadGridJobForecast.DataSource = Me.GridSource

    End Sub
    Private Sub RadToolBarJobForecastRevision_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecastRevision.ButtonClick

        'objects
        Dim ApprovedJobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim NewJobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim RevisionCreated As Boolean = False
        Dim JobForecastRevisionID As Integer = 0
        Dim Rebind As Boolean = False
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        _JobForecastRevision = Nothing

        Select Case e.Item.Value

            Case ToolBarCommand.Save.ToString

                If SaveJobForecastRevision() Then

                    Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", _JobForecastRevisionID))

                End If

            Case ToolBarCommand.CreateRevision.ToString

                If _JobForecastRevisionID <> 0 Then

                    If Me.JobForecastRevision IsNot Nothing Then

                        If AdvantageFramework.JobForecast.ReviseJobForcast(Me.DbContext, Me.JobForecastRevision, NewJobForecastRevision) Then

                            Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", NewJobForecastRevision.ID))

                        End If

                    End If

                End If

            Case ToolBarCommand.Approve.ToString, ToolBarCommand.ApproveConfirm.ToString

                If _JobForecastRevisionID <> 0 Then

                    If Me.JobForecastRevision IsNot Nothing Then

                        If AdvantageFramework.JobForecast.ApproveJobForecastRevision(Me.DbContext, Me.JobForecastRevision) Then

                            Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", _JobForecastRevisionID))

                        End If

                    End If

                End If

            Case ToolBarCommand.Unapprove.ToString

                If _JobForecastRevisionID <> 0 Then

                    If Me.JobForecastRevision IsNot Nothing Then

                        AdvantageFramework.JobForecast.UnapproveJobForecastRevision(Me.DbContext, Me.JobForecastRevision)

                    End If

                End If

                Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", _JobForecastRevisionID))

            Case ToolBarCommand.DeleteRevision.ToString

                If AdvantageFramework.JobForecast.DeleteJobForecastRevision(Me.DbContext, Me.JobForecastRevision, True) Then

                    Try

                        JobForecastRevisionID = (From Item In DropDownListJobForecastRevision.Items.OfType(Of Telerik.Web.UI.RadComboBoxItem)()
                                                 Where CInt(Item.Value) <> _JobForecastRevisionID
                                                 Select [ID] = CInt(Item.Value)
                                                 Order By ID Descending).First

                    Catch ex As Exception
                        JobForecastRevisionID = 0
                    Finally

                        If JobForecastRevisionID <> 0 Then

                            Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", JobForecastRevisionID))

                        Else

                            Me.CloseThisWindowAndRefreshCaller("JobForecast_Main.aspx")

                        End If

                    End Try

                Else

                    Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", Me.JobForecastRevision.ID))

                End If

            Case ToolBarCommand.Settings.ToString

                If _JobForecastRevisionID <> 0 Then

                    Me.OpenWindow("Job Forecast Settings", [String].Format("JobForecast_Settings.aspx?JobForecastRevisionID={0}", _JobForecastRevisionID), 500, 625, False, True)

                End If

            Case ToolBarCommand.Bookmark.ToString()

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_JobForecast
                    .UserCode = Session("UserCode")
                    .Name = "JF: " & Me.RadTextBoxDescription.Text
                    .PageURL = "JobForecast_Edit.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

            Case ToolBarCommand.ExportOptions.ToString

                QueryString = New AdvantageFramework.Web.QueryString

                With QueryString

                    .Page = "JobForecast_Print.aspx"
                    .Add("JobForecastRevisionID", _JobForecastRevisionID)
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                End With

                Me.OpenWindow(QueryString, "Export Options", 300, 600, False, False)

            Case ToolBarCommand.ExportToExcel.ToString

                QueryString = New AdvantageFramework.Web.QueryString

                With QueryString

                    .Page = "JobForecast_Print.aspx"
                    .Add("JobForecastRevisionID", _JobForecastRevisionID)
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                End With

                Me.OpenPrintSendSilently(QueryString)

            Case ToolBarCommand.ActualsByMonth.ToString

                Me.ShowActualsByMonth = RadToolBarButtonActualsByMonth.Checked

                Rebind = True
                'RadGridJobForecast.Rebind()

            Case ToolBarCommand.JobComponents.ToString

                If _JobForecastRevisionID <> 0 Then

                    Me.OpenWindow("Job Components", [String].Format("JobForecast_AddJobComponents.aspx?JobForecastRevisionID={0}", _JobForecastRevisionID), 650, 1000, False, True)

                End If

            Case ToolBarCommand.DeleteJobComponent.ToString

                For Each GridDataItem In RadGridJobForecast.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If DeleteGridItem(GridDataItem) Then

                        Rebind = True

                    End If

                Next

            Case ToolBarCommand.Refresh.ToString

                Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", Me.JobForecastRevision.ID))

        End Select

        If Rebind Then

            Me.GridSource = Nothing

            RadGridJobForecast.Rebind()

        End If

    End Sub
    Private Sub DropDownListJobForecastRevision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListJobForecastRevision.SelectedIndexChanged

        If DropDownListJobForecastRevision.SelectedValue IsNot Nothing AndAlso DropDownListJobForecastRevision.SelectedValue <> "" Then

            Response.Redirect([String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", DropDownListJobForecastRevision.SelectedValue))

        End If

    End Sub
    Private Sub RadContextMenuGrid_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadContextMenuGrid.ItemClick

        'objects
        Dim Rebind As Boolean = False
        Dim SelectedGridDataItems As Generic.List(Of Telerik.Web.UI.GridDataItem) = Nothing

        If RadGridJobForecast.SelectedItems.Count() > 0 Then

            SelectedGridDataItems = RadGridJobForecast.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).ToList

        Else

            SelectedGridDataItems = RadGridJobForecast.Items.OfType(Of Telerik.Web.UI.GridDataItem).Where(Function(DataItem) DataItem.ItemIndexHierarchical = HiddenFieldContextMenuSelectedRow.Value).ToList 'should only return 1

        End If

        Select Case e.Item.Value

            Case "Delete"

                If SelectedGridDataItems IsNot Nothing AndAlso SelectedGridDataItems.Count > 0 Then

                    For Each GridDataItem In SelectedGridDataItems

                        DeleteGridItem(GridDataItem)

                    Next

                End If

                Me.GridSource = Nothing

                Rebind = True

        End Select

        If Rebind Then

            RadGridJobForecast.Rebind()

        End If

    End Sub
    Private Sub RadButtonActualize_Click(sender As Object, e As EventArgs) Handles RadButtonActualize.Click

        'objects
        Dim GridDataItems As Telerik.Web.UI.GridDataItemCollection = Nothing
        Dim JobForecastJobs As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing
        Dim JobForecastJobIDs As Integer() = Nothing
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

        If Not Me.IsRevisionEditable Then

            Me.ShowMessage("This revision cannot be modified.")
            Exit Sub

        Else

            Select Case RadioButtonListActualizeType.SelectedValue

                Case "0" ' all

                    If RadGridJobForecast.Items.OfType(Of Telerik.Web.UI.GridDataItem).Count = 0 Then

                        Me.ShowMessage("There are not any job components to actualize.")
                        Exit Sub

                    End If

                Case "1" ' selected

                    If RadGridJobForecast.MasterTableView.GetSelectedItems.Count > 0 Then

                        JobForecastJobIDs = (From Item In RadGridJobForecast.MasterTableView.GetSelectedItems()
                                             Select CInt(Item.GetDataKeyValue("JobForecastJobID"))).ToArray

                        JobForecastJobs = (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(Me.DbContext, _JobForecastRevisionID)
                                           Where JobForecastJobIDs.Contains(Item.ID)
                                           Select Item).ToList

                    End If

                    If JobForecastJobs Is Nothing OrElse JobForecastJobs.Count = 0 Then

                        Me.ShowMessage("Please select at least one job component to actualize.")
                        Exit Sub

                    End If

            End Select

            If AdvantageFramework.JobForecast.ActualizeJobForecast(Me.DbContext, _JobForecastRevisionID, RadComboBoxPostPeriodCutoff.SelectedValue, RadButtonRollForwardBalances.Checked, RadButtonRollForwardToNextMonthOnly.Checked, JobForecastJobs) Then

                Try

                    _DataContext.Dispose()

                Catch ex As Exception

                End Try

                Try

                    _DbContext.Dispose()

                Catch ex As Exception

                End Try

                _GridSource = Nothing
                RadGridJobForecast.DataSource = Nothing
                RadGridJobForecast.Rebind()

            End If

        End If

    End Sub
    Private Sub RadButtonAllocate_Click(sender As Object, e As EventArgs) Handles RadButtonAllocate.Click

        'objects
        Dim JobForecastJobIDs As Integer() = Nothing

        If Not Me.IsRevisionEditable Then

            Me.ShowMessage("This revision cannot be modified.")
            Exit Sub

        Else

            Select Case RadioButtonListAllocateType.SelectedValue

                Case "0" ' all

                    If RadGridJobForecast.Items.OfType(Of Telerik.Web.UI.GridDataItem).Count = 0 Then

                        Me.ShowMessage("There are not any job components to allocate.")
                        Exit Sub

                    End If

                Case "1" ' selected

                    If RadGridJobForecast.MasterTableView.GetSelectedItems.Count > 0 Then

                        JobForecastJobIDs = (From Item In RadGridJobForecast.MasterTableView.GetSelectedItems()
                                             Select CInt(Item.GetDataKeyValue("JobForecastJobID"))).ToArray

                    End If

                    If JobForecastJobIDs Is Nothing OrElse JobForecastJobIDs.Count = 0 Then

                        Me.ShowMessage("Please select at least one job component.")
                        Exit Sub

                    End If

            End Select

            Session("JF_Allocate_Revision") = _JobForecastRevisionID
            Session("JF_Allocate_Jobs") = JobForecastJobIDs
            Me.OpenWindow("Allocate", "JobForecast_Allocate.aspx", Nothing, Nothing, False, True)

        End If

    End Sub
    Private Sub RadGridJobForecast_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridJobForecast.PageSizeChanged

        MiscFN.SavePageSize(RadGridJobForecast.ID, e.NewPageSize)

    End Sub
    Protected Sub RadComboBoxGroupOptions_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Me.GridGroupByOption = DirectCast(sender, Telerik.Web.UI.RadComboBox).SelectedItem.Value

        SetupGridGrouping()

        RadGridJobForecast.Rebind()

    End Sub

#End Region

#End Region

End Class
