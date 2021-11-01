Imports Telerik.Web.UI

Public Class JobForecast_Allocate
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

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
    Private Property TotalPostPeriods As Integer
        Get
            If Me.ViewState("TotalPostPeriods") Is Nothing Then
                Me.TotalPostPeriods = 0
            End If
            Return Me.ViewState("TotalPostPeriods")
        End Get
        Set(value As Integer)
            Me.ViewState("TotalPostPeriods") = value
            HiddenFieldTotalPostPeriods.Value = value
        End Set
    End Property
    Private Property DataSource As Generic.List(Of AdvantageFramework.JobForecast.Classes.AllocateJobComponent)
        Get
            If Me.ViewState("DataSource") Is Nothing Then

                Me.DataSource = New Generic.List(Of AdvantageFramework.JobForecast.Classes.AllocateJobComponent)

            End If
            Return Me.ViewState("DataSource")
        End Get
        Set(value As Generic.List(Of AdvantageFramework.JobForecast.Classes.AllocateJobComponent))
            Me.ViewState("DataSource") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub SaveGridChangesToViewState()

        'objects
        Dim AllocateJobComponent As AdvantageFramework.JobForecast.Classes.AllocateJobComponent = Nothing

        'save grid changes in viewstate
        For Each GridDataItem In RadGridComponents.Items.OfType(Of Telerik.Web.UI.GridDataItem)

            AllocateJobComponent = Me.DataSource.SingleOrDefault(Function(item) item.JobForecastJobID = CInt(GridDataItem.GetDataKeyValue("JobForecastJobID")))

            If AllocateJobComponent IsNot Nothing Then

                AllocateJobComponent.BillingAmountToAllocateByPostPeriod = DirectCast(GridDataItem.FindControl("RadNumericTextBoxAllocateAmountPerPostPeriodBilling"), Telerik.Web.UI.RadNumericTextBox).Value
                AllocateJobComponent.BillingAmountToAllocate = DirectCast(GridDataItem.FindControl("RadNumericTextBoxAllocateAmountBilling"), Telerik.Web.UI.RadNumericTextBox).Value

                AllocateJobComponent.RevenueAmountToAllocateByPostPeriod = DirectCast(GridDataItem.FindControl("RadNumericTextBoxAllocateAmountPerPostPeriodRevenue"), Telerik.Web.UI.RadNumericTextBox).Value
                AllocateJobComponent.RevenueAmountToAllocate = DirectCast(GridDataItem.FindControl("RadNumericTextBoxAllocateAmountRevenue"), Telerik.Web.UI.RadNumericTextBox).Value

            End If

        Next

    End Sub

#Region " Page Methods "

    Protected Sub JobForecast_Allocate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim AllocateJobComponents As Generic.List(Of AdvantageFramework.JobForecast.Classes.AllocateJobComponent) = Nothing
        Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
        Dim JobForecastJobIDs As Integer() = Nothing
        Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
        Dim PostPeriodCount As Integer = Nothing
        Dim JobForecastRevisionID As Integer = Nothing
        Dim BillingColumnsVisible As Boolean = False
        Dim RevenueColumnsVisible As Boolean = False
        Me.Title = "Allocate"

        If Not Me.IsPostBack Then

            If Session("JF_Allocate_Revision") IsNot Nothing Then

                JobForecastRevisionID = CInt(Session("JF_Allocate_Revision"))
                JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastRevisionID)

                If JobForecastRevision IsNot Nothing Then

                    If JobForecastRevision.ID <> (From Item In AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastRevision.JobForecastID)
                                                  Order By Item.RevisionNumber Descending
                                                  Select Item).FirstOrDefault.ID Then

                        Me.ShowMessage("Only the highest revision can be modified.")
                        Me.CloseThisWindow()

                    ElseIf JobForecastRevision.IsApproved Then

                        Me.ShowMessage("This revision is approved and cannot be modified.")
                        Me.CloseThisWindow()

                    Else

                        JobForecast = AdvantageFramework.Database.Procedures.JobForecast.LoadByID(Me.DbContext, JobForecastRevision.JobForecastID)

                        With DirectCast(RadGridComponents.MasterTableView.GetColumnSafe("GridNumericColumnApprovedEstimateAmount"), Telerik.Web.UI.GridBoundColumn)

                            Select Case JobForecast.ForecastType.GetValueOrDefault(0)

                                Case AdvantageFramework.JobForecast.JobForecastTypes.Billing

                                    .DataField = AdvantageFramework.JobForecast.Classes.JobForecastJobSummary.Properties.ApprovedEstimateBillingAmount.ToString
                                    BillingColumnsVisible = True
                                    RevenueColumnsVisible = False

                                Case AdvantageFramework.JobForecast.JobForecastTypes.Revenue

                                    .DataField = AdvantageFramework.JobForecast.Classes.JobForecastJobSummary.Properties.ApprovedEstimateRevenueAmount.ToString
                                    BillingColumnsVisible = False
                                    RevenueColumnsVisible = True

                                Case Else

                                    .DataField = AdvantageFramework.JobForecast.Classes.JobForecastJobSummary.Properties.ApprovedEstimateBillingAmount.ToString
                                    BillingColumnsVisible = True
                                    RevenueColumnsVisible = True

                            End Select

                        End With

                        RadGridComponents.MasterTableView.GetColumnSafe("GridTemplateColumnAllocateAmountPerPostPeriodBilling").Visible = BillingColumnsVisible
                        RadGridComponents.MasterTableView.GetColumnSafe("GridTemplateColumnAllocateAmountBilling").Visible = BillingColumnsVisible
                        RadGridComponents.MasterTableView.GetColumnSafe("GridTemplateColumnAllocateAmountPerPostPeriodRevenue").Visible = RevenueColumnsVisible
                        RadGridComponents.MasterTableView.GetColumnSafe("GridTemplateColumnAllocateAmountRevenue").Visible = RevenueColumnsVisible

                        Me.TotalPostPeriods = AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(Me.DbContext, JobForecast).Count()

                        AllocateJobComponents = (From Item In AdvantageFramework.JobForecast.LoadJobForecastJobsSummary(Me.DbContext, JobForecastRevisionID)
                                                 Select New AdvantageFramework.JobForecast.Classes.AllocateJobComponent(Item, Me.TotalPostPeriods)).ToList

                        If Session("JF_Allocate_Jobs") IsNot Nothing Then

                            JobForecastJobIDs = Session("JF_Allocate_Jobs")

                            AllocateJobComponents = (From Item In AllocateJobComponents
                                                     Join ID In JobForecastJobIDs On Item.JobForecastJobID Equals ID
                                                     Select Item).ToList

                        End If

                        If AllocateJobComponents IsNot Nothing AndAlso AllocateJobComponents.Count > 0 Then

                            If Not BillingColumnsVisible Then

                                AllocateJobComponents = AllocateJobComponents.Select(Function(item)
                                                                                         item.BillingAmountToAllocate = Nothing
                                                                                         item.BillingAmountToAllocateByPostPeriod = Nothing
                                                                                         Return item
                                                                                     End Function).ToList

                            End If

                            If Not RevenueColumnsVisible Then

                                AllocateJobComponents = AllocateJobComponents.Select(Function(item)
                                                                                         item.RevenueAmountToAllocate = Nothing
                                                                                         item.RevenueAmountToAllocateByPostPeriod = Nothing
                                                                                         Return item
                                                                                     End Function).ToList

                            End If

                            Me.DataSource = AllocateJobComponents

                        End If

                    End If

                End If

            End If

        Else

            SaveGridChangesToViewState()

        End If

    End Sub
    Private Sub JobForecast_Allocate_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        Try

            If _DbContext IsNot Nothing Then

                _DbContext.Dispose()
                _DbContext = Nothing

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadGridComponents_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridComponents.NeedDataSource

        RadGridComponents.DataSource = Me.DataSource

    End Sub
    Private Sub RadToolBarJobForecastAllocate_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarJobForecastAllocate.ButtonClick

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                If AdvantageFramework.JobForecast.AllocateJobForecastJobs(Me.DbContext, Me.DataSource) Then

                    Me.CloseThisWindowAndRefreshCaller("JobForecast_Edit.aspx", False, False)

                End If

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadGridComponents_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridComponents.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.GroupHeader Then

            If TypeOf e.Item Is Telerik.Web.UI.GridGroupHeaderItem Then

                With DirectCast(e.Item, Telerik.Web.UI.GridGroupHeaderItem)

                    .DataCell.Text = CType(.DataItem, System.Data.DataRowView)("ClientName")

                End With

            End If

        End If

    End Sub

#End Region

#End Region

End Class