Public Class JobForecast_Job
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property DbContext As AdvantageFramework.Database.DbContext
        Get
            If _DbContext Is Nothing Then
                _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            End If
            Return _DbContext
        End Get
    End Property
    Private ReadOnly Property CanUserUpdate As Boolean
        Get
            If ViewState("JF_CanUserUpdate") Is Nothing Then
                ViewState("JF_CanUserUpdate") = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserUpdate")
        End Get
    End Property
    Private ReadOnly Property CanUserAdd As Boolean
        Get
            If ViewState("JF_CanUserAdd") Is Nothing Then
                ViewState("JF_CanUserAdd") = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Methods.Modules.FinanceAccounting_JobForecast)
            End If
            Return ViewState("JF_CanUserAdd")
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub SetupRadGrid()

        For Each GridColumn In RadGridJobForecastJobDetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

            If TypeOf GridColumn Is Telerik.Web.UI.GridNumericColumn Then

                With TryCast(GridColumn, Telerik.Web.UI.GridNumericColumn)

                    .ItemStyle.Width = Unit.Pixel(100)
                    .HeaderStyle.Width = Unit.Pixel(100)
                    .ItemStyle.HorizontalAlign = HorizontalAlign.Right
                    .AllowRounding = True
                    .NumericType = Telerik.Web.UI.NumericType.Number
                    .DataFormatString = "{0:N2}"
                    .DecimalDigits = 2

                End With

            End If

        Next

    End Sub
    Private Sub CheckUserRights()

        If Not Me.CanUserUpdate AndAlso Not Me.CanUserAdd Then

            DisableMenuItem(RadToolBarButtonNew)

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

#Region "  Form Event Handlers "

    Private Sub JobForecast_Job_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            _JobNumber = .JobNumber
            _JobComponentNumber = .JobComponentNumber

        End With

        SetupRadGrid()

    End Sub
    Private Sub JobForecast_Job_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobForecast)

            End Using

            If _JobNumber <= 0 AndAlso _JobComponentNumber <= 0 Then


            Else

            End If

            'RadGridJobForecastJobDetails.Rebind()

        End If

        CheckUserRights()

    End Sub
    Private Sub JobForecast_Job_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()

                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarJobForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobForecast.ButtonClick

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        Select Case e.Item.Value

            Case "New"

                QueryString = New AdvantageFramework.Web.QueryString

                With QueryString

                    .Page = "JobForecast_New.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber

                End With

                Me.OpenWindow(QueryString, "", 600, 950, False, False)

            Case "Settings"

                Me.OpenWindow("Job Forecast Settings", "JobForecast_Settings.aspx", 500, 625, False, True)

            Case "refresh"

                RadGridJobForecastJobDetails.DataSource = Nothing
                RadGridJobForecastJobDetails.Rebind()

        End Select

    End Sub
    Private Sub RadGridJobForecastJobDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobForecastJobDetails.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobForecastRevisionID As Integer = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobForecastJobDetails.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "View"

                If CurrentGridDataItem IsNot Nothing Then

                    JobForecastRevisionID = CInt(CurrentGridDataItem.GetDataKeyValue("JobForecastRevisionID"))

                    Me.OpenWindow("", [String].Format("JobForecast_Edit.aspx?JobForecastRevisionID={0}", JobForecastRevisionID))

                End If

        End Select

    End Sub
    Private Sub RadGridJobForecastJobDetails_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobForecastJobDetails.ItemCreated

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobForecastEntry As AdvantageFramework.JobForecast.Classes.JobForecastEntry = Nothing
        Dim JobForecastDescription As String = Nothing
        Dim RevisionNumber As String = Nothing
        Dim BillingOrRevenue As Boolean = False

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            GridDataItem = e.Item

            JobForecastEntry = e.Item.DataItem

            If JobForecastEntry IsNot Nothing Then

                If e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

                    For Each GridNumericColumn In RadGridJobForecastJobDetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn)()

                        For Each RadNumericTextBox In GridDataItem(GridNumericColumn.UniqueName).Controls.OfType(Of Telerik.Web.UI.RadNumericTextBox)()

                            RadNumericTextBox.Width = GridNumericColumn.ItemStyle.Width
                            RadNumericTextBox.NumberFormat.DecimalDigits = GridNumericColumn.DecimalDigits
                            RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
                            RadNumericTextBox.EnabledStyle.HorizontalAlign = GridNumericColumn.ItemStyle.HorizontalAlign

                            If GridNumericColumn.DataField = AdvantageFramework.JobForecast.Classes.JobForecastEntry.Properties.BillingAmount.ToString Then

                                RadNumericTextBox.Visible = JobForecastEntry.IsBillingEditable()
                                BillingOrRevenue = True

                            ElseIf GridNumericColumn.DataField = AdvantageFramework.JobForecast.Classes.JobForecastEntry.Properties.RevenueAmount.ToString Then

                                RadNumericTextBox.Visible = JobForecastEntry.IsRevenueEditable()
                                BillingOrRevenue = True

                            Else

                                BillingOrRevenue = False

                            End If

                            If RadNumericTextBox.Visible = True Then

                                If BillingOrRevenue = True Then

                                    RadNumericTextBox.ClientEvents.OnValueChanged = "updateAmount"

                                End If

                            End If

                        Next

                    Next

                End If

            End If

        ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.GroupHeader Then

            With TryCast(e.Item, Telerik.Web.UI.GridGroupHeaderItem)

                If .DataItem IsNot Nothing Then

                    JobForecastDescription = TryCast(.DataItem, System.Data.DataRowView)(AdvantageFramework.JobForecast.Classes.JobForecastEntry.Properties.JobForecastDescription.ToString)
                    RevisionNumber = TryCast(.DataItem, System.Data.DataRowView)(AdvantageFramework.JobForecast.Classes.JobForecastEntry.Properties.RevisionNumber.ToString)

                    RevisionNumber = AdvantageFramework.StringUtilities.PadWithCharacter(RevisionNumber, 3, "0", True)

                    .DataCell.Text = [String].Format("{0} ({1})", JobForecastDescription, RevisionNumber)

                End If

            End With

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridGroupFooterItem Then

            'Dim GridGroupFooterItem As Telerik.Web.UI.GridGroupFooterItem = Nothing

            'GridGroupFooterItem = TryCast(e.Item, Telerik.Web.UI.GridGroupFooterItem)

            'For Each GridNumericColumn In RadGridJobForecastJobDetails.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridNumericColumn)()

            '    GridGroupFooterItem(GridNumericColumn.UniqueName).Text = [String].Format("<div class='{0} total-display' style='text-align: right;'></div>", GridNumericColumn.DataField)

            'Next

        End If

    End Sub
    Private Sub RadGridJobForecastJobDetails_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobForecastJobDetails.ItemDataBound

        'objects
        Dim DataRowView As System.Data.DataRowView = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then

            With TryCast(e.Item, Telerik.Web.UI.GridGroupHeaderItem)

                'DataRowView = e.Item.DataItem

                '.DataCell.Text = [String].Format("{0} ({1})", DataRowView.Row("JobForecastDescription"), AdvantageFramework.StringUtilities.PadWithCharacter(DataRowView.Row("RevisionNumber"), 3, "0", True))

            End With

        End If

    End Sub
    Private Sub RadGridJobForecastJobDetails_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobForecastJobDetails.NeedDataSource

        'objects
        Dim JobForecastJobList As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing
        Dim JobForecastJobDetailList As Generic.List(Of AdvantageFramework.Database.Entities.JobForecastJobDetail) = Nothing
        Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
        Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim JobForecastEntryList As Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastEntry) = Nothing
        Dim JobForecastEntry As AdvantageFramework.JobForecast.Classes.JobForecastEntry = Nothing
        Dim HighestRevision As Integer = Nothing
        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
        Dim ForecastHasApprovedRevision As Boolean = False

        Try

            JobForecastJobList = (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.Load(Me.DbContext)
                                  Where Item.JobNumber = _JobNumber AndAlso
                                       Item.JobComponentNumber = _JobComponentNumber
                                  Select Item).ToList

            JobForecastEntryList = New Generic.List(Of AdvantageFramework.JobForecast.Classes.JobForecastEntry)

            For Each JobForecastID In JobForecastJobList.Select(Function(JfJob) JfJob.JobForecastID).Distinct.ToArray

                JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(Me.DbContext, JobForecastID)

                PostPeriods = AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(Me.DbContext, JobForecastID)

                HighestRevision = (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(Me.DbContext, JobForecast.ID)
                                   Select Item.RevisionNumber).Max

                JobForecastRevision = (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(Me.DbContext, JobForecast.ID)
                                       Where Item.IsApproved = True
                                       Select Item).FirstOrDefault

                If JobForecastRevision Is Nothing Then

                    JobForecastRevision = (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(Me.DbContext, JobForecast.ID)
                                           Where Item.RevisionNumber = HighestRevision
                                           Select Item).FirstOrDefault

                    ForecastHasApprovedRevision = False

                Else

                    ForecastHasApprovedRevision = True

                End If

                If JobForecastRevision IsNot Nothing Then

                    For Each JobForecastJob In JobForecastJobList.Where(Function(JfJob) JfJob.JobForecastID = JobForecastID AndAlso JfJob.JobForecastRevisionID = JobForecastRevision.ID).ToList

                        JobForecastJobDetailList = AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(Me.DbContext, JobForecastJob.ID).ToList

                        For Each PostPeriod In PostPeriods

                            JobForecastJobDetail = Nothing

                            JobForecastEntry = New AdvantageFramework.JobForecast.Classes.JobForecastEntry With {.PostPeriodCode = PostPeriod.Code,
                                                                                                                     .IsHighestRevision = If(JobForecastRevision.RevisionNumber = HighestRevision, True, False),
                                                                                                                     .IsRevisionApproved = JobForecastRevision.IsApproved,
                                                                                                                     .ForecastHasApprovedRevision = ForecastHasApprovedRevision,
                                                                                                                     .JobForecastRevisionID = JobForecastRevision.ID,
                                                                                                                     .JobForecastID = JobForecast.ID,
                                                                                                                     .JobForecastDescription = JobForecast.Description,
                                                                                                                     .RevisionNumber = JobForecastRevision.RevisionNumber,
                                                                                                                     .ForecastType = JobForecast.ForecastType.GetValueOrDefault(0),
                                                                                                                     .JobForecastJobID = JobForecastJob.ID,
                                                                                                                     .PostPeriodStartDate = PostPeriod.StartDate,
                                                                                                                     .JobForecastCreateDate = JobForecast.CreatedDate}

                            JobForecastJobDetail = (From Item In JobForecastJobDetailList
                                                    Where Item.PostPeriod = PostPeriod.Code
                                                    Select Item).SingleOrDefault

                            If JobForecastJobDetail IsNot Nothing Then

                                With JobForecastEntry

                                    .ID = JobForecastJobDetail.ID
                                    .BillingAmount = JobForecastJobDetail.BillingAmount
                                    .RevenueAmount = JobForecastJobDetail.RevenueAmount

                                End With

                            End If

                            JobForecastEntryList.Add(JobForecastEntry)

                        Next

                    Next

                End If

            Next

            Dim counter = 1

            For Each jfID In JobForecastEntryList.OrderBy(Function(item) item.PostPeriodStartDate).ThenByDescending(Function(item) item.JobForecastCreateDate).Select(Function(item) item.JobForecastID).Distinct

                For Each JfEntry In JobForecastEntryList.Where(Function(item) item.JobForecastID = jfID).ToList

                    JfEntry.GroupOrder = counter

                Next

                counter += 1

            Next

            RadGridJobForecastJobDetails.DataSource = JobForecastEntryList

        Catch ex As Exception

        End Try
         
    End Sub
    Private Sub RadGridJobForecastJobDetails_PreRender(sender As Object, e As EventArgs) Handles RadGridJobForecastJobDetails.PreRender

        'objects
        Dim Rebind As Boolean = False
        Dim JobForecastEntry As AdvantageFramework.JobForecast.Classes.JobForecastEntry = Nothing

        For Each GridDataItem In RadGridJobForecastJobDetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If TypeOf GridDataItem.DataItem Is AdvantageFramework.JobForecast.Classes.JobForecastEntry Then

                JobForecastEntry = GridDataItem.DataItem

                If Not JobForecastEntry.IsRevisionApproved AndAlso JobForecastEntry.IsHighestRevision = True AndAlso GridDataItem.IsInEditMode = False AndAlso Me.CanUserUpdate Then

                    GridDataItem.Edit = True
                    Rebind = True

                End If

            End If

        Next

        If Rebind Then

            RadGridJobForecastJobDetails.Rebind()

        End If

    End Sub

#End Region

#End Region

End Class