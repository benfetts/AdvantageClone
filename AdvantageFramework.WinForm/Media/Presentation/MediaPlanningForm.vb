Namespace Media.Presentation

    Public Class MediaPlanningForm

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum Columns
            [Estimate]
            [MediaType]
            [SalesClass]
            [Campaign]
            [Buyer]
            [EstimateBudgetAmount]
            [EntryDate]
            [Demo1]
            [Demo2]
            [Units]
            [Impressions]
            [Clicks]
            [Dollars]
            [BillAmount]
            [GrossBudgetAmount]
        End Enum

#End Region

#Region " Variables "

        Private _CanUserEditTemplate As Boolean = False
        Private _FlowChartMediaPlanOptions As AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions = Nothing
        Protected _ColumnEditAdded As Boolean = False
        Protected _AlreadyActivated As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            'Dim IsActiveFilterString As Boolean = False

            'IsActiveFilterString = DataGridViewLeftSection_MediaPlans.CurrentView.ActiveFilterEnabled

            'DataGridViewLeftSection_MediaPlans.CurrentView.ActiveFilterEnabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False, False)

                    DataGridViewLeftSection_MediaPlans.DataSource = (From MediaPlan In AdvantageFramework.Database.Procedures.MediaPlan.Load(DbContext).Include("Client").Include("Division").Include("Product").Include("MediaPlanDetails").Include("MediaPlanMasterPlanDetails").Include("MediaPlanMasterPlanDetails.MediaPlanMasterPlan").ToList
                                                                     Where Products.Any(Function(Entity) Entity.ClientCode = MediaPlan.ClientCode AndAlso Entity.DivisionCode = MediaPlan.DivisionCode AndAlso Entity.Code = MediaPlan.ProductCode) = True
                                                                     Select MediaPlan).ToList.Select(Function(Entity) New AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly(Entity)).ToList

                End Using

            End Using

            'If IsActiveFilterString Then

            '    DataGridViewLeftSection_MediaPlans.CurrentView.ActiveFilterEnabled = True

            'End If

            DataGridViewLeftSection_MediaPlans.SetBookmarkColumnIndex(0)

            If DataGridViewLeftSection_MediaPlans.Columns(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString) IsNot Nothing Then

                DataGridViewLeftSection_MediaPlans.Columns(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString).OptionsColumn.AllowEdit = True

                If _ColumnEditAdded = False Then

                    If TypeOf DataGridViewLeftSection_MediaPlans.Columns(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString).ColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                        AddHandler CType(DataGridViewLeftSection_MediaPlans.Columns(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString).ColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).EditValueChanging, AddressOf RepositoryItemIsInactive_EditValueChanging
                        _ColumnEditAdded = True

                    End If

                End If

            End If

            DataGridViewLeftSection_MediaPlans.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadPlanInformation()

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim Amount As System.Nullable(Of Decimal) = 0
            Dim ClearInfo As Boolean = True

            If _FlowChartMediaPlanOptions IsNot Nothing Then

                _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Clear()

            End If

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                    If MediaPlan IsNot Nothing Then

                        ButtonItemActions_Update.Enabled = True ' Not MediaPlan.IsApproved
                        ButtonItemActions_Delete.Enabled = (MediaPlan.MediaPlanDetails.Any = False) AndAlso ((MediaPlan.IsTemplate AndAlso _CanUserEditTemplate) OrElse Not MediaPlan.IsTemplate)

                        ClearInfo = False

                        Amount = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, MediaPlanID).Select(Function(Entity) Entity.BillAmount).Sum

                        ProgressBarRightSection_OverallStatus.Text = "Budget Amount: " & FormatCurrency(MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))
                        ProgressBarRightSection_OverallStatus.Maximum = If(MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) > Integer.MaxValue, Integer.MaxValue, MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))
                        ProgressBarRightSection_OverallStatus.Minimum = 0

                        If Amount.GetValueOrDefault(0) > Integer.MaxValue Then

                            Amount = Integer.MaxValue

                        ElseIf Amount.GetValueOrDefault(0) < Integer.MinValue Then

                            Amount = Integer.MinValue

                        End If

                        ProgressBarRightSection_OverallStatus.Value = Amount.GetValueOrDefault(0)

                        If Amount.GetValueOrDefault(0) > MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) Then

                            ProgressBarRightSection_OverallStatus.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Error

                        Else

                            If Amount.GetValueOrDefault(0) >= MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) * 0.75 Then

                                ProgressBarRightSection_OverallStatus.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Paused

                            Else

                                ProgressBarRightSection_OverallStatus.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Normal

                            End If

                        End If

                        ProgressBarRightSection_OverallStatus.BackgroundStyle.TextColor = Drawing.Color.Black
                        ProgressBarRightSection_OverallStatus.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center

                        DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, MediaPlanID)

                        If TabItemReport_DashboardTab.Visible Then

                            LoadDashboard(DbContext, MediaPlan.ID, MediaPlan.StartDate, MediaPlan.EndDate, MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))

                        End If

                        DataGridViewMasterPlans_MasterPlans.DataSource = (From MediaPlanMasterPlan In AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Load(DbContext).Include("MediaPlanMasterPlanDetails")
                                                                          Where MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Any(Function(Entity) Entity.MediaPlanID = MediaPlanID) = True
                                                                          Select MediaPlanMasterPlan).ToList

                    End If

                    DbContext.Database.Connection.Close()

                End Using

            End If

            If ClearInfo Then

                ButtonItemActions_Update.Enabled = False
                ButtonItemActions_Delete.Enabled = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, -1)

                End Using

                LoadDashboardDataSource(CreateDashboardDataTable)

                ProgressBarRightSection_OverallStatus.Text = "Budget Amount: $0.00"
                ProgressBarRightSection_OverallStatus.Value = 0
                ProgressBarRightSection_OverallStatus.Maximum = 0
                ProgressBarRightSection_OverallStatus.Minimum = 0
                ProgressBarRightSection_OverallStatus.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Normal

                DataGridViewMasterPlans_MasterPlans.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanMasterPlan)

            End If

            If DataGridViewEstimates_Estimates.Columns("Ordered") IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewEstimates_Estimates, DataGridViewEstimates_Estimates.Columns("Ordered"))

            End If

            If DataGridViewEstimates_Estimates.Columns("DollarsAmount") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("DollarsAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("NetCharge") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("NetCharge").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("NetCharge").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("NetCharge").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("NetCharge").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("Commission") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("Commission").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("Commission").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("Commission").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("Commission").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("AgencyFee") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("AgencyFee").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("AgencyFee").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("AgencyFee").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("AgencyFee").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("BillableAmount") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("BillableAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("BudgetAmount") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("BudgetAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("BudgetAmount").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("BudgetAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("BudgetAmount").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("BudgetVariance") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("BudgetVariance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("BudgetVariance").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("BudgetVariance").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("BudgetVariance").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("PartialOrdered") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("PartialOrdered").Visible = False
                DataGridViewEstimates_Estimates.Columns("PartialOrdered").OptionsColumn.AllowShowHide = False
                DataGridViewEstimates_Estimates.Columns("PartialOrdered").OptionsColumn.ShowInCustomizationForm = False
                DataGridViewEstimates_Estimates.Columns("PartialOrdered").OptionsColumn.ShowInExpressionEditor = False
                DataGridViewEstimates_Estimates.Columns("PartialOrdered").OptionsColumn.AllowMove = False

            End If

            If DataGridViewEstimates_Estimates.Columns("FullOrdered") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("FullOrdered").Visible = False
                DataGridViewEstimates_Estimates.Columns("FullOrdered").OptionsColumn.AllowShowHide = False
                DataGridViewEstimates_Estimates.Columns("FullOrdered").OptionsColumn.ShowInCustomizationForm = False
                DataGridViewEstimates_Estimates.Columns("FullOrdered").OptionsColumn.ShowInExpressionEditor = False
                DataGridViewEstimates_Estimates.Columns("FullOrdered").OptionsColumn.AllowMove = False

            End If

            If DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString) IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString).Visible = False
                DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString).OptionsColumn.AllowShowHide = False
                DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString).OptionsColumn.ShowInCustomizationForm = False
                DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString).OptionsColumn.ShowInExpressionEditor = False
                DataGridViewEstimates_Estimates.Columns(AdvantageFramework.MediaPlanning.Classes.Estimate.Properties.SalesClassType.ToString).OptionsColumn.AllowMove = False

            End If

            'DataGridViewEstimates_Estimates.MakeColumnNotVisible("ID")
            DataGridViewEstimates_Estimates.CurrentView.BestFitColumns()
            DataGridViewMasterPlans_MasterPlans.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadEstimates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer) As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.Estimate)

            'objects
            Dim Estimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.Estimate) = Nothing
            Dim MediaPlanDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing
            Dim NetAmount As Decimal = 0
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim VendorCommission As Nullable(Of Decimal) = Nothing
            Dim Estimate As AdvantageFramework.MediaPlanning.Classes.Estimate = Nothing

            MediaPlanDetailsList = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Include("MediaPlanDetailLevelLineDatas").
                                                                                                                                    Include("MediaPlanDetailChangeLogs").
                                                                                                                                    Include("MediaPlanDetailLevels").
                                                                                                                                    Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines").
                                                                                                                                    Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines.MediaPlanDetailLevelLineTags").
                                                                                                                                    OrderBy(Function(Entity) Entity.OrderNumber).ToList

            Estimates = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.Estimate)

            For Each MediaPlanDetail In MediaPlanDetailsList

                Estimate = New AdvantageFramework.MediaPlanning.Classes.Estimate

                Estimate.PlanID = MediaPlanDetail.MediaPlanID
                Estimate.ID = MediaPlanDetail.ID
                Estimate.Estimate = MediaPlanDetail.Name
                Estimate.LockedBy = MediaPlanDetail.LockedByUserCode
                Estimate.CreatedBy = MediaPlanDetail.CreatedByUserCode
                Estimate.CreatedDate = MediaPlanDetail.CreatedDate
                Estimate.ModifiedBy = MediaPlanDetail.ModifiedByUserCode
                Estimate.ModifiedDate = MediaPlanDetail.ModifiedDate
                Estimate.FullOrdered = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Count = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Count) AndAlso MediaPlanDetail.MediaPlanDetailLevelLineDatas.Count > 0
                Estimate.PartialOrdered = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Any
                Estimate.Ordered = If(Estimate.FullOrdered, 0, (If(Estimate.PartialOrdered, 1, 2)))
                Estimate.BudgetAmount = MediaPlanDetail.GrossBudgetAmount
                Estimate.DollarsAmount = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum
                Estimate.NetCharge = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.NetCharge.GetValueOrDefault(0)).Sum

                Estimate.AgencyFee = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.AgencyFee.GetValueOrDefault(0)).Sum
                Estimate.BillableAmount = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum
                Estimate.BudgetVariance = MediaPlanDetail.GrossBudgetAmount - MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum
                Estimate.LastChangedByUser = If(MediaPlanDetail.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).LastOrDefault IsNot Nothing, MediaPlanDetail.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).Last.CreatedByUserCode, Nothing)
                Estimate.LastChangedDate = If(MediaPlanDetail.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).LastOrDefault IsNot Nothing, MediaPlanDetail.MediaPlanDetailChangeLogs.OrderByDescending(Function(Entity) Entity.CreatedDate).Last.CreatedDate.ToShortDateString, "")
                Estimate.SalesClassType = MediaPlanDetail.SalesClassType

                MediaPlanDetailLevel = MediaPlanDetail.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

                If MediaPlanDetailLevel IsNot Nothing Then

                    If MediaPlanDetail.IsEstimateGrossAmount Then

                        NetAmount = 0

                        For Each VendorName In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Select(Function(Entity) Entity.Description).Distinct.ToList

                            For Each RowIndex In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Select(Function(Entity) Entity.RowIndex).Distinct.ToList

                                VendorCommission = Nothing

                                For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.Description = VendorName AndAlso Entity.RowIndex = RowIndex).ToList

                                    If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing AndAlso MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault IsNot Nothing Then

                                        VendorCommission = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault.VendorCommission

                                        If VendorCommission.HasValue = False OrElse VendorCommission.Value = 0 Then

                                            NetAmount += (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum * 0.85)

                                        Else

                                            NetAmount += (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum * ((100 - VendorCommission.Value) / 100))

                                        End If

                                    Else

                                        NetAmount += (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum * 0.85)

                                    End If

                                Next

                            Next

                        Next

                        Estimate.Commission = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0) - Entity.NetCharge.GetValueOrDefault(0)).Sum - NetAmount)

                    Else

                        Estimate.Commission = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0) - Entity.NetCharge.GetValueOrDefault(0)).Sum - MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum)

                    End If

                Else

                    If MediaPlanDetail.IsEstimateGrossAmount Then

                        Estimate.Commission = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0) - Entity.NetCharge.GetValueOrDefault(0)).Sum - (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum * 0.85))

                    Else

                        Estimate.Commission = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0) - Entity.NetCharge.GetValueOrDefault(0)).Sum - MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum)

                    End If

                End If

                Estimates.Add(Estimate)

            Next

            LoadEstimates = Estimates

        End Function
        Private Sub LoadDashboardDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataTable As System.Data.DataTable, ByVal MediaPlanID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal GrossBudgetAmount As Decimal)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim MediaPlanDetailLevelLineDataList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim DateDayCounter As Integer = 0
            Dim MediaPlanDetailDate As Date = Date.MinValue
            Dim MediaType As String = String.Empty
            Dim Estimate As String = String.Empty
            Dim SalesClass As String = String.Empty
            Dim Campaign As String = String.Empty
            Dim Buyer As String = String.Empty
            Dim CampaignEntity As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Campaigns As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EstimateBudgetAmount As Decimal = 0

            Campaigns = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).ToList
            Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

            For Each MediaPlanDetailID In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Select(Function(Entity) Entity.ID).ToList

                MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID, True)

                If MediaPlanDetail IsNot Nothing Then

                    MediaType = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), MediaPlanDetail.SalesClassType)
                    Estimate = MediaPlanDetail.Name
                    SalesClass = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, String.Empty)
                    Campaign = String.Empty
                    Buyer = String.Empty
                    CampaignEntity = Nothing
                    Employee = Nothing
                    EstimateBudgetAmount = MediaPlanDetail.GrossBudgetAmount

                    If MediaPlanDetail.CampaignID.GetValueOrDefault(0) > 0 Then

                        Try

                            CampaignEntity = Campaigns.SingleOrDefault(Function(Entity) Entity.ID = MediaPlanDetail.CampaignID.GetValueOrDefault(0))

                        Catch ex As Exception
                            CampaignEntity = Nothing
                        End Try

                    End If

                    If CampaignEntity IsNot Nothing Then

                        Campaign = CampaignEntity.ToString

                    End If

                    If String.IsNullOrWhiteSpace(MediaPlanDetail.BuyerEmployeeCode) = False Then

                        Try

                            Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = MediaPlanDetail.BuyerEmployeeCode)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                    End If

                    If Employee IsNot Nothing Then

                        Buyer = Employee.ToString

                    End If

                    MediaPlanDetailLevelLineDataList = MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList

                    For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, StartDate, EndDate))

                        MediaPlanDetailDate = StartDate.AddDays(DateDayCounter)

                        If MediaPlanDetailLevelLineDataList.Where(Function(Entity) Entity.StartDate.ToShortDateString = MediaPlanDetailDate.ToShortDateString).Any Then

                            For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDataList.Where(Function(Entity) Entity.StartDate.ToShortDateString = MediaPlanDetailDate.ToShortDateString).ToList

                                DataRow = DataTable.Rows.Add()

                                DataRow(Columns.Estimate.ToString) = Estimate
                                DataRow(Columns.MediaType.ToString) = MediaType
                                DataRow(Columns.SalesClass.ToString) = SalesClass
                                DataRow(Columns.Campaign.ToString) = Campaign
                                DataRow(Columns.Buyer.ToString) = Buyer
                                DataRow(Columns.EstimateBudgetAmount.ToString) = EstimateBudgetAmount
                                DataRow(Columns.EntryDate.ToString) = MediaPlanDetailDate
                                DataRow(Columns.Demo1.ToString) = MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0)
                                DataRow(Columns.Demo2.ToString) = MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0)
                                DataRow(Columns.Units.ToString) = MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0)
                                DataRow(Columns.Impressions.ToString) = MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0)
                                DataRow(Columns.Clicks.ToString) = MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0)
                                DataRow(Columns.Dollars.ToString) = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0)
                                DataRow(Columns.BillAmount.ToString) = MediaPlanDetailLevelLineData.BillAmount.GetValueOrDefault(0)
                                DataRow(Columns.GrossBudgetAmount.ToString) = GrossBudgetAmount

                            Next

                        Else

                            DataRow = DataTable.Rows.Add()

                            DataRow(Columns.Estimate.ToString) = Estimate
                            DataRow(Columns.MediaType.ToString) = MediaType
                            DataRow(Columns.SalesClass.ToString) = SalesClass
                            DataRow(Columns.Campaign.ToString) = Campaign
                            DataRow(Columns.Buyer.ToString) = Buyer
                            DataRow(Columns.EstimateBudgetAmount.ToString) = EstimateBudgetAmount
                            DataRow(Columns.EntryDate.ToString) = MediaPlanDetailDate
                            DataRow(Columns.Demo1.ToString) = 0
                            DataRow(Columns.Demo2.ToString) = 0
                            DataRow(Columns.Units.ToString) = 0
                            DataRow(Columns.Impressions.ToString) = 0
                            DataRow(Columns.Clicks.ToString) = 0
                            DataRow(Columns.Dollars.ToString) = 0
                            DataRow(Columns.BillAmount.ToString) = 0
                            DataRow(Columns.GrossBudgetAmount.ToString) = GrossBudgetAmount

                        End If

                    Next

                End If

            Next

        End Sub
        Private Sub LoadDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal GrossBudgetAmount As Decimal)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DataTable = CreateDashboardDataTable()

                LoadDashboardDataTable(DbContext, DataTable, MediaPlanID, StartDate, EndDate, GrossBudgetAmount)

                LoadDashboardDataSource(DataTable)

            End If

        End Sub
        Private Sub LoadDashboardDataSource(ByVal DataTable As System.Data.DataTable)

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources.Add(DataTable)

                Else

                    DashboardViewerDashboard_Dashboard.Dashboard.DataSources(0).Data = DataTable

                End If

                DashboardViewerDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Function CreateDashboardDataTable() As System.Data.DataTable

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = New System.Data.DataTable

            For Each DataColumnName In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(Columns), False)

                DataColumn = DataTable.Columns.Add(DataColumnName)

                DataColumn.Caption = DataColumn.ColumnName

                If DataColumnName = Columns.Estimate.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.MediaType.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.SalesClass.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.Campaign.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.Buyer.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.EstimateBudgetAmount.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.EntryDate.ToString Then

                    DataColumn.DataType = GetType(Date)

                ElseIf DataColumnName = Columns.Demo1.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.Demo2.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.Units.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.Impressions.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.Clicks.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.Dollars.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.BillAmount.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                ElseIf DataColumnName = Columns.GrossBudgetAmount.ToString Then

                    DataColumn.DataType = GetType(Decimal)

                End If

            Next

            CreateDashboardDataTable = DataTable

        End Function
        Protected Sub AddSubItemImageComboBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)

            RepositoryItemImageComboBox.SmallImages = ImagesCollection

            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ordered", 0, 0))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PartiallyOrdered", 1, 1))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NotOrdered", 2, 2))

            RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

            GridColumn.ColumnEdit = RepositoryItemImageComboBox

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim MasterPlanID As Integer = 0

            ButtonItemEstimate_View.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow
            ButtonItemEstimate_Add.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow
            ButtonItemActions_Add.Enabled = True

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow AndAlso DirectCast(DataGridViewLeftSection_MediaPlans.CurrentView.GetFocusedRow, AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly).IsTemplate Then

                ButtonItemActions_Update.Enabled = _CanUserEditTemplate
                ButtonItemActions_Copy.Enabled = True

            Else

                ButtonItemActions_Update.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow
                ButtonItemActions_Copy.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow

            End If

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow AndAlso DirectCast(DataGridViewLeftSection_MediaPlans.CurrentView.GetFocusedRow, AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly).IsTemplate Then

                ButtonItemEstimate_Actualize.Enabled = False

            ElseIf DataGridViewEstimates_Estimates.HasOnlyOneSelectedRow Then

                ButtonItemEstimate_Actualize.Enabled = {"I", "M", "N", "O"}.Contains(DataGridViewEstimates_Estimates.GetFirstSelectedRowDataBoundItem.SalesClassType)

            End If

            ButtonItemPrint_FlowChart.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow

            ButtonItemActions_Refresh.Enabled = True

            RibbonBarOptions_Dashboard.Visible = (TabControlForm_Estimates.SelectedTab Is TabItemReport_DashboardTab)

            RibbonBarOptions_Documents.Visible = TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab)

            TabControlForm_Estimates.Enabled = DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow()

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MasterPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowCellValue(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.MasterPlanID.ToString)

                If MasterPlanID > 0 Then

                    ButtonItemMasterPlans_View.Enabled = True

                Else

                    If TabControlForm_Estimates.SelectedTab Is TabItemReport_MasterPlansTab Then

                        ButtonItemMasterPlans_View.Enabled = DataGridViewMasterPlans_MasterPlans.HasOnlyOneSelectedRow

                    Else

                        ButtonItemMasterPlans_View.Enabled = False

                    End If

                End If

            Else

                ButtonItemMasterPlans_View.Enabled = False

            End If

        End Sub
        Public Sub RefreshForm()

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            Try

                LoadPlanInformation()

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

        End Sub
        Private Sub ViewEstimate()

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlanDetailID As Integer = 0
            Dim Message As String = Nothing

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    MediaPlanDetailID = DataGridViewEstimates_Estimates.GetFirstSelectedRowBookmarkValue(1)

                    ViewEstimate(MediaPlanID, MediaPlanDetailID)

                End If

            End If

        End Sub
        Private Sub ViewEstimate(MediaPlanID As Integer, MediaPlanDetailID As Integer)

            'objects
            Dim Message As String = Nothing

            If MediaPlanID > 0 AndAlso MediaPlanDetailID > 0 Then

                If CheckForOpenMediaPlan(Me.MdiParent, MediaPlanID, MediaPlanDetailID) = False Then

                    If AdvantageFramework.MediaPlanning.IsEstimateLocked(Session, MediaPlanDetailID, Message) Then

                        AdvantageFramework.WinForm.MessageBox.Show(Message)

                    Else

                        AdvantageFramework.Media.Presentation.MediaPlanEditForm.ShowForm(MediaPlanID, MediaPlanDetailID)

                    End If

                End If

            End If

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim MediaPlanID As Integer = 0
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentManagerControlDocuments_Documents.ClearControl()

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan) With {.MediaPlanID = MediaPlanID})

                    DocumentManagerControlDocuments_Documents.Enabled = DocumentManagerControlDocuments_Documents.LoadControl(Database.Entities.DocumentLevel.AccountReceivableInvoice, DocumentLevelSettings, WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default, True, True, True)

                End If

            End If

            TabItemReport_DocumentsTab.Tag = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaPlanningForm As AdvantageFramework.Media.Presentation.MediaPlanningForm = Nothing

            MediaPlanningForm = New AdvantageFramework.Media.Presentation.MediaPlanningForm

            MediaPlanningForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanningForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated

            If _AlreadyActivated Then

                Call LoadPlanInformation()

            Else

                _AlreadyActivated = True

            End If

        End Sub
        Private Sub MediaPlanningForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewLeftSection_MediaPlans, AdvantageFramework.Database.Entities.GridAdvantageType.MediaPlanningSetup)

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewEstimates_Estimates, AdvantageFramework.Database.Entities.GridAdvantageType.MediaPlanningSetupEstimates)

            End If

        End Sub
        Private Sub MediaPlanningForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            TabControlForm_Estimates.SelectedTab = TabItemReport_EstimatesTab

            DataGridViewLeftSection_MediaPlans.OptionsView.ShowFooter = False
            DataGridViewLeftSection_MediaPlans.OptionsCustomization.AllowQuickHideColumns = True
            DataGridViewLeftSection_MediaPlans.OptionsMenu.EnableColumnMenu = True
            DataGridViewLeftSection_MediaPlans.OptionsCustomization.AllowGroup = False
            DataGridViewLeftSection_MediaPlans.OptionsBehavior.Editable = True

            DataGridViewEstimates_Estimates.OptionsView.ShowFooter = True
            DataGridViewEstimates_Estimates.ItemDescription = "Estimate(s)"
            DataGridViewEstimates_Estimates.SetBookmarkColumnIndex(0)

            DataGridViewEstimates_Estimates.GridControl.ToolTipController = Me.ToolTipController

            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_Update.Image = My.Resources.UpdateImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = My.Resources.CopyImage
            ButtonItemActions_SearchByOrderNumber.Image = AdvantageFramework.My.Resources.ViewImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            ButtonItemEstimate_View.Image = My.Resources.ViewImage
            ButtonItemEstimate_ViewOrderDetails.Image = My.Resources.ViewImage
            ButtonItemEstimate_Add.Image = My.Resources.DetailAddImage
            ButtonItemEstimate_Actualize.Image = My.Resources.UpdateImage

            ButtonItemDashboard_Edit.Image = My.Resources.EditImage

            ButtonItemMasterPlans_Setup.Image = My.Resources.PrintFullReportImage
            ButtonItemMasterPlans_View.Image = My.Resources.PrintSelectedReportImage

            ButtonItemPrint_FlowChart.Image = AdvantageFramework.My.Resources.PrintFullReportImage

            ButtonItemDocuments_Upload.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemDocuments_Download.Image = AdvantageFramework.My.Resources.DownloadDocument
            ButtonItemDocuments_OpenURL.Image = AdvantageFramework.My.Resources.Link

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                    ButtonItemDocuments_Upload.SubItems.Remove(ButtonItemUpload_EmailLink)
                    ButtonItemDocuments_Upload.SplitButton = False

                End If

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            _CanUserEditTemplate = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Methods.Modules.Media_MediaPlanning_Actions_EditTemplate, Me.Session.User)

            ButtonItemEstimate_Actualize.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_DigitalCampaignManager)

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanningForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            If AdvantageFramework.Security.IsMediaToolUser(Me.Session, Me.Session.User.ID) Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning)

                    End Using

                    If Dashboard IsNot Nothing AndAlso Dashboard.Layout IsNot Nothing AndAlso Dashboard.Layout.Length > 0 Then

                        MemoryStream = New System.IO.MemoryStream(Dashboard.Layout)

                        DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                        TabItemReport_DashboardTab.Visible = True

                    Else

                        If My.Resources.MediaPlanDashboard IsNot Nothing AndAlso My.Resources.MediaPlanDashboard.Length > 0 Then

                            MemoryStream = New System.IO.MemoryStream(My.Resources.MediaPlanDashboard)

                            DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                            TabItemReport_DashboardTab.Visible = True

                        Else

                            TabItemReport_DashboardTab.Visible = False

                        End If

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewLeftSection_MediaPlans, Database.Entities.GridAdvantageType.MediaPlanningSetup)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, -1)

                End Using

                AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewEstimates_Estimates, Database.Entities.GridAdvantageType.MediaPlanningSetupEstimates)

                DataGridViewLeftSection_MediaPlans.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                LoadPlanInformation()

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("You must be a Media Tools User to access this module.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim AddedFromMediaPlanTemplate As Boolean = False

            If AdvantageFramework.Media.Presentation.MediaPlanNewDialog.ShowFormDialog(MediaPlanID, AddedFromMediaPlanTemplate) = System.Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                    LoadPlanInformation()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If MediaPlanID <> 0 AndAlso AddedFromMediaPlanTemplate = False Then

                    AdvantageFramework.Media.Presentation.MediaPlanEditForm.ShowForm(MediaPlanID)

                ElseIf MediaPlanID <> 0 AndAlso AddedFromMediaPlanTemplate = True Then

                    DataGridViewLeftSection_MediaPlans.SelectAllRowsByValue(0, MediaPlanID, True)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim LockMessage As String = Nothing

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, MediaPlanID, LockMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show(LockMessage)

                        Else

                            MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                            If MediaPlan IsNot Nothing Then

                                If AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog.ShowFormDialog(MediaPlan) = Windows.Forms.DialogResult.OK Then

                                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                                    Me.ShowWaitForm()

                                    Try

                                        LoadGrid()

                                        LoadPlanInformation()

                                        EnableOrDisableActions()

                                    Catch ex As Exception

                                    End Try

                                    Me.FormAction = WinForm.Presentation.FormActions.None
                                    Me.CloseWaitForm()

                                End If

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

                LoadPlanInformation()

                EnableOrDisableActions()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim NewMediaPlanID As Integer = 0
            Dim Copied As Boolean = False
            Dim MediaPlanDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String) = Nothing
            Dim ContinueCopying As Boolean = True

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    If AdvantageFramework.MediaPlanning.GetMediaPlanEstimatesWithInactiveSalesClassByMediaPlanID(Session, MediaPlanID, 0, MediaPlanDetailIDs) Then

                        If AdvantageFramework.Media.Presentation.MediaPlanCopyDialog.ShowFormDialog(MediaPlanDetailIDs, DictionaryMediaPlanDetailIDs) <> Windows.Forms.DialogResult.OK Then

                            ContinueCopying = False

                        End If

                    End If

                    If ContinueCopying Then

                        Me.ShowWaitForm("Copying...")

                        Try

                            Copied = AdvantageFramework.MediaPlanning.CopyMediaPlan(Me.Session, MediaPlanID, NewMediaPlanID, DictionaryMediaPlanDetailIDs)

                        Catch ex As Exception
                            Copied = False
                        End Try

                        If Copied Then

                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm("Loading...")

                            Try

                                LoadGrid()

                                DataGridViewLeftSection_MediaPlans.SelectRow(NewMediaPlanID)

                                LoadPlanInformation()

                                EnableOrDisableActions()

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.None
                            Me.CloseWaitForm()

                        Else

                            Me.CloseWaitForm()

                            AdvantageFramework.WinForm.MessageBox.Show("Failed copying media plan.  Please contact Software Support.")

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim AllowDelete As Boolean = False
            Dim Locked As Boolean = False
            Dim Message As String = Nothing

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this media plan?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                    If MediaPlanID <> 0 Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, MediaPlanID, Message, True) Then

                                AdvantageFramework.WinForm.MessageBox.Show(Message)
                                Locked = True

                            End If

                        End Using

                        If Not Locked Then

                            If CheckForOpenMediaPlan(Me.MdiParent, MediaPlanID, 0) = False Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                                    If MediaPlan IsNot Nothing Then

                                        If MediaPlan.MediaPlanDetailLevelLineDatas.Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any = False Then

                                            AllowDelete = True

                                        End If

                                    End If

                                End Using

                                If AllowDelete Then

                                    'If MediaPlan.IsApproved = False Then

                                    Me.FormAction = WinForm.Presentation.FormActions.Deleting
                                    Me.ShowWaitForm()

                                    Me.ShowWaitForm("Deleting...")

                                    Try

                                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                            For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).ToList

                                                AdvantageFramework.Database.Procedures.MediaPlanDetail.Delete(DbContext, MediaPlanDetail)

                                            Next

                                            AdvantageFramework.Database.Procedures.MediaPlan.Delete(DbContext, MediaPlan)

                                        End Using

                                    Catch ex As Exception

                                    End Try

                                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                                    Me.ShowWaitForm("Loading...")

                                    Try

                                        LoadGrid()

                                        LoadPlanInformation()

                                        EnableOrDisableActions()

                                    Catch ex As Exception

                                    End Try

                                    Me.FormAction = WinForm.Presentation.FormActions.None
                                    Me.CloseWaitForm()

                                    'Else

                                    '    AdvantageFramework.WinForm.MessageBox.Show("Unapprove this Media Plan before deleting it.")

                                    'End If

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("You cannot delete a plan that has orders generated from it.")

                                End If

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Please close media plan before deleting.")

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_SearchByOrderNumber_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SearchByOrderNumber.Click

            'objects
            Dim OrderNumber As Integer = 0
            Dim OrderNumberSearchResult As AdvantageFramework.MediaPlanning.Classes.OrderNumberSearchResult = Nothing
            Dim Message As String = String.Empty

            If AdvantageFramework.WinForm.Presentation.NumericInputDialog.ShowFormDialog("Order Number Search", "Enter Order Number", Nothing, OrderNumber, Nothing, AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Integer, True) = Windows.Forms.DialogResult.OK Then

                If OrderNumber > 0 Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Try

                            OrderNumberSearchResult = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.OrderNumberSearchResult)(String.Format("EXEC [dbo].[advsp_media_planning_search_by_order_number] {0}", OrderNumber)).FirstOrDefault

                        Catch ex As Exception
                            OrderNumberSearchResult = Nothing
                            Message = "Error trying to find estimate by order number. Please contact software support."
                        End Try

                        If OrderNumberSearchResult Is Nothing Then

                            If String.IsNullOrWhiteSpace(Message) Then

                                Message = "Cannot find a estimate with the order number that was entered."

                            End If

                        End If

                    End Using

                Else

                    Message = "Please enter a valid order number."

                End If

                If OrderNumberSearchResult Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show(Me, Message)

                Else

                    DataGridViewLeftSection_MediaPlans.SelectRow(0, OrderNumberSearchResult.PlanID)

                    If DataGridViewLeftSection_MediaPlans.HasASelectedRow AndAlso DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue(0) = OrderNumberSearchResult.PlanID Then

                        DataGridViewEstimates_Estimates.SelectRow(1, OrderNumberSearchResult.EstimateID)

                    End If

                    If AdvantageFramework.WinForm.MessageBox.Show(Me, "Do you want to open this estimate?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        ViewEstimate(OrderNumberSearchResult.PlanID, OrderNumberSearchResult.EstimateID)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_MediaPlans_RowDoubleClickEvent() Handles DataGridViewLeftSection_MediaPlans.RowDoubleClickEvent

            ViewEstimate()

        End Sub
        Private Sub DataGridViewLeftSection_MediaPlans_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_MediaPlans.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                TabItemReport_DocumentsTab.Tag = False

                If TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab) Then

                    LoadDocumentsTab()

                End If

                LoadPlanInformation()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RepositoryItemIsInactive_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim LockMessage As String = Nothing

            MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

            If MediaPlanID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.NewValue = True Then

                        If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, MediaPlanID, LockMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show(LockMessage)

                            e.Cancel = True

                        Else

                            Try

                                MediaPlan = (From Entity In DbContext.MediaPlans
                                             Where Entity.ID = MediaPlanID
                                             Select Entity).SingleOrDefault

                                If MediaPlan IsNot Nothing Then

                                    MediaPlan.IsInactive = e.NewValue

                                    DbContext.SaveChanges()

                                    DataGridViewLeftSection_MediaPlans.CurrentView.SetRowCellValue(DataGridViewLeftSection_MediaPlans.CurrentView.FocusedRowHandle, AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString, e.NewValue)

                                    DataGridViewLeftSection_MediaPlans.CurrentView.RefreshData()

                                    DataGridViewLeftSection_MediaPlans.GridViewSelectionChanged()

                                Else

                                    e.Cancel = True

                                End If

                            Catch ex As Exception
                                e.Cancel = True
                            End Try

                        End If

                    Else

                        Try

                            MediaPlan = (From Entity In DbContext.MediaPlans
                                         Where Entity.ID = MediaPlanID
                                         Select Entity).SingleOrDefault

                            If MediaPlan IsNot Nothing Then

                                DataGridViewLeftSection_MediaPlans.CurrentView.SetRowCellValue(DataGridViewLeftSection_MediaPlans.CurrentView.FocusedRowHandle, AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.IsInactive.ToString, e.NewValue)

                                DataGridViewLeftSection_MediaPlans.CurrentView.RefreshData()

                                DataGridViewLeftSection_MediaPlans.GridViewSelectionChanged()

                            Else

                                e.Cancel = True

                            End If

                        Catch ex As Exception
                            e.Cancel = True
                        End Try

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewEstimates_Estimates_RowDoubleClickEvent() Handles DataGridViewEstimates_Estimates.RowDoubleClickEvent

            ViewEstimate()

        End Sub
        Private Sub DataGridViewEstimates_Estimates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEstimates_Estimates.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                End Using

                If MediaPlan IsNot Nothing Then

                    MemoryStream = New System.IO.MemoryStream

                    If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                        DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                        DashboardLayout = MemoryStream.ToArray
                        MemoryStream.Flush()
                        MemoryStream.Close()

                        DataTable = CreateDashboardDataTable()

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            LoadDashboardDataTable(DbContext, DataTable, MediaPlan.ID, MediaPlan.StartDate, MediaPlan.EndDate, MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))

                        End Using

                        If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, DataTable, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                            Try

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning)

                                    If Dashboard IsNot Nothing Then

                                        Dashboard.Layout = DashboardLayout

                                        AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                                    Else

                                        Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                                        Dashboard.DbContext = DbContext
                                        Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning
                                        Dashboard.Layout = DashboardLayout

                                        AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                                    End If

                                End Using

                            Catch ex As Exception

                            End Try

                            MemoryStream = New System.IO.MemoryStream

                            MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                            MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                            DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                            MemoryStream.Flush()
                            MemoryStream.Close()

                        End If

                        LoadDashboardDataSource(DataTable)


                    End If

                End If

            End If

        End Sub
        Private Sub TabControlForm_Estimates_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_Estimates.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_Estimates_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Estimates.SelectedTabChanging

            If e.NewTab.Equals(TabItemReport_DocumentsTab) Then

                If e.NewTab.Tag = False Then

                    LoadDocumentsTab()

                End If

            End If

        End Sub
        Private Sub ButtonItemCopy_WithNewCDP_Click(sender As Object, e As EventArgs) Handles ButtonItemCopy_WithNewCDP.Click

            'objects
            Dim SelectedProducts As IEnumerable = Nothing
            Dim SelectedProduct As Object = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim MediaPlanID As Integer = 0
            Dim NewMediaPlanID As Integer = 0
            Dim Copied As Boolean = False
            Dim MediaPlanDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String) = Nothing
            Dim ContinueCopying As Boolean = True

            MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

            If MediaPlanID <> 0 Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Product, True, True, SelectedProducts, RequireClientDivisionToBeActive:=True) = Windows.Forms.DialogResult.OK Then

                    Try

                        SelectedProduct = SelectedProducts.OfType(Of Object).FirstOrDefault

                    Catch ex As Exception
                        SelectedProduct = Nothing
                    End Try

                    If SelectedProduct IsNot Nothing Then

                        If AdvantageFramework.MediaPlanning.GetMediaPlanEstimatesWithInactiveSalesClassByMediaPlanID(Session, MediaPlanID, 0, MediaPlanDetailIDs) Then

                            If AdvantageFramework.Media.Presentation.MediaPlanCopyDialog.ShowFormDialog(MediaPlanDetailIDs, DictionaryMediaPlanDetailIDs) <> Windows.Forms.DialogResult.OK Then

                                ContinueCopying = False

                            End If

                        End If

                        If ContinueCopying Then

                            Me.ShowWaitForm("Copying...")

                            Try

                                ClientCode = SelectedProduct.ClientCode
                                DivisionCode = SelectedProduct.DivisionCode
                                ProductCode = SelectedProduct.Code

                                Copied = AdvantageFramework.MediaPlanning.CopyMediaPlan(Me.Session, MediaPlanID, NewMediaPlanID, DictionaryMediaPlanDetailIDs, ClientCode, DivisionCode, ProductCode)

                            Catch ex As Exception
                                Copied = False
                            End Try

                            If Copied Then

                                Me.FormAction = WinForm.Presentation.FormActions.Loading
                                Me.ShowWaitForm("Loading...")

                                Try

                                    LoadGrid()

                                    DataGridViewLeftSection_MediaPlans.SelectRow(NewMediaPlanID)

                                    LoadPlanInformation()

                                    EnableOrDisableActions()

                                Catch ex As Exception

                                End Try

                                Me.FormAction = WinForm.Presentation.FormActions.None
                                Me.CloseWaitForm()

                            Else

                                Me.CloseWaitForm()

                                AdvantageFramework.WinForm.MessageBox.Show("Failed copying media plan.  Please contact Software Support.")

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemEstimate_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEstimate_View.Click

            ViewEstimate()

        End Sub
        Private Sub ButtonItemEstimate_ViewOrderDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimate_ViewOrderDetails.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlanDetailID As Integer = 0

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    MediaPlanDetailID = DataGridViewEstimates_Estimates.GetFirstSelectedRowBookmarkValue(1)

                    AdvantageFramework.Media.Presentation.MediaPlanEstimateLevelLineDataDialog.ShowFormDialog(MediaPlanID, MediaPlanDetailID)

                End If

            End If

        End Sub
        Private Sub ButtonItemEstimate_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEstimate_Add.Click

            'objects
            Dim MediaPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    MediaPlan = New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, MediaPlanID)

                    If AdvantageFramework.Media.Presentation.MediaPlanDetailEditDialog.ShowFormDialog(MediaPlan, Nothing) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                            LoadPlanInformation()

                            EnableOrDisableActions()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If MediaPlan.MediaPlanEstimate IsNot Nothing Then

                            AdvantageFramework.Media.Presentation.MediaPlanEditForm.ShowForm(MediaPlanID, MediaPlan.MediaPlanEstimate.ID)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemMasterPlans_View_Click(sender As Object, e As EventArgs) Handles ButtonItemMasterPlans_View.Click

            'objects
            Dim MasterPlanID As Integer = 0

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MasterPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowCellValue(AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly.Properties.MasterPlanID.ToString)

                If MasterPlanID = 0 Then

                    If TabControlForm_Estimates.SelectedTab Is TabItemReport_MasterPlansTab AndAlso DataGridViewMasterPlans_MasterPlans.HasOnlyOneSelectedRow Then

                        MasterPlanID = DataGridViewMasterPlans_MasterPlans.GetFirstSelectedRowBookmarkValue()

                    End If

                End If

            End If

            If MasterPlanID > 0 Then

                If AdvantageFramework.Media.Presentation.MediaPlanMasterPlanEditDialog.ShowFormDialog(MasterPlanID) = Windows.Forms.DialogResult.OK Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm("Loading...")

                    Try

                        LoadGrid()

                        LoadPlanInformation()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemMasterPlans_ViewAll_Click(sender As Object, e As EventArgs) Handles ButtonItemMasterPlans_Setup.Click

            AdvantageFramework.Media.Presentation.MediaPlanMasterPlanSetupForm.ShowForm()

        End Sub
        Private Sub DataGridViewMasterPlans_MasterPlans_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewMasterPlans_MasterPlans.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewMasterPlans_MasterPlans_RowDoubleClickEvent() Handles DataGridViewMasterPlans_MasterPlans.RowDoubleClickEvent

            ButtonItemMasterPlans_View.RaiseClick()

        End Sub
        Private Sub ToolTipController_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim CellText As String = String.Empty
            Dim Ordered As Integer = 0

            If e.Info Is Nothing AndAlso e.SelectedControl Is DataGridViewEstimates_Estimates.GridControl Then

                GridHitInfo = DataGridViewEstimates_Estimates.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo IsNot Nothing AndAlso GridHitInfo.InRowCell Then

                    If GridHitInfo.Column.FieldName = "Ordered" Then

                        CellText = DataGridViewEstimates_Estimates.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column)

                        If String.IsNullOrWhiteSpace(CellText) = False AndAlso Integer.TryParse(CellText, Ordered) Then

                            If Ordered = 0 Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Ordered")

                            ElseIf Ordered = 1 Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Partially Ordered")

                            ElseIf Ordered = 2 Then

                                ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString(), "Unordered")

                            End If

                            e.Info = ToolTipControlInfo

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemPrint_FlowChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrint_FlowChart.Click

            'objects
            Dim FlowChart As AdvantageFramework.MediaPlanning.FlowChart.FlowChart = Nothing
            Dim FlowChartBuilder As AdvantageFramework.MediaPlanning.FlowChart.FlowChartBuilder = Nothing
            Dim FileName As String = String.Empty
            Dim FileNameCounter As Integer = 0
            Dim FileNameTemplate As String = String.Empty
            Dim Folder As String = String.Empty
            Dim MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions = Nothing
            Dim MediaPlanReadOnly As AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly = Nothing
            Dim MediaPlanDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing
            Dim IsASP As Boolean = False
            Dim SaveFlowChartToDisk As Boolean = False

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow AndAlso TypeOf DataGridViewLeftSection_MediaPlans.CurrentView.GetFocusedRow Is AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly Then

                MediaPlanReadOnly = DirectCast(DataGridViewLeftSection_MediaPlans.CurrentView.GetFocusedRow, AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly)

            End If

            If MediaPlanReadOnly IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlanDetailsList = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanReadOnly.ID).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                End Using

                If MediaPlanReadOnly IsNot Nothing AndAlso MediaPlanDetailsList IsNot Nothing AndAlso MediaPlanDetailsList.Count > 0 Then

                    If _FlowChartMediaPlanOptions Is Nothing Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            MediaPlanFlowChartOptions = AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.LoadByUserCode(DbContext, Me.Session.UserCode)

                        End Using

                        If MediaPlanFlowChartOptions IsNot Nothing Then

                            _FlowChartMediaPlanOptions = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions(MediaPlanReadOnly, MediaPlanFlowChartOptions)

                        Else

                            _FlowChartMediaPlanOptions = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanOptions(MediaPlanReadOnly)

                        End If

                    Else

                        If _FlowChartMediaPlanOptions.MediaPlanID <> MediaPlanReadOnly.ID Then

                            _FlowChartMediaPlanOptions.MediaPlanID = MediaPlanReadOnly.ID
                            _FlowChartMediaPlanOptions.MediaPlanName = MediaPlanReadOnly.Description
                            _FlowChartMediaPlanOptions.StartDate = MediaPlanReadOnly.StartDate
                            _FlowChartMediaPlanOptions.EndDate = MediaPlanReadOnly.EndDate

                            _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Clear()

                        End If

                    End If

                    If _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Count = 0 Then

                        For Each MediaPlanDetail In MediaPlanDetailsList.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                            _FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Add(New AdvantageFramework.MediaPlanning.FlowChart.FlowChartMediaPlanEstimateOptions(_FlowChartMediaPlanOptions) With {.MediaPlanDetailID = MediaPlanDetail.ID,
                                                                                                                                                                                                                .Estimate = MediaPlanDetail.Name,
                                                                                                                                                                                                                .DisplayValue = _FlowChartMediaPlanOptions.GrandTotalsDisplayValue,
                                                                                                                                                                                                                .PrintDateHeader = True,
                                                                                                                                                                                                                .ShowEstimateRowTotals = True})

                        Next

                    End If

                    If MediaPlanFlowChartOptionsDialog.ShowFormDialog(MediaPlanReadOnly.ID, _FlowChartMediaPlanOptions) = System.Windows.Forms.DialogResult.OK Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If MediaPlanFlowChartOptions Is Nothing Then

                                MediaPlanFlowChartOptions = New AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions

                                MediaPlanFlowChartOptions.DbContext = DbContext
                                MediaPlanFlowChartOptions.UserCode = Me.Session.UserCode

                                _FlowChartMediaPlanOptions.Save(MediaPlanFlowChartOptions)

                                AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.Insert(DbContext, MediaPlanFlowChartOptions)

                            Else

                                _FlowChartMediaPlanOptions.Save(MediaPlanFlowChartOptions)

                                AdvantageFramework.Database.Procedures.MediaPlanFlowChartOptions.Update(DbContext, MediaPlanFlowChartOptions)

                            End If

                            IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                            If IsASP Then

                                Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            End If

                        End Using

                        If IsASP Then

                            Folder = Folder.Trim

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\")) Then

                                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\") & "Reports\"

                                If My.Computer.FileSystem.DirectoryExists(Folder) = False Then

                                    My.Computer.FileSystem.CreateDirectory(Folder)

                                End If

                                SaveFlowChartToDisk = My.Computer.FileSystem.DirectoryExists(Folder)

                            End If

                        Else

                            SaveFlowChartToDisk = AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder)

                        End If

                        If SaveFlowChartToDisk Then

                            FlowChart = New AdvantageFramework.MediaPlanning.FlowChart.FlowChart(Me.Session, _FlowChartMediaPlanOptions)

                            If FlowChart.FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions IsNot Nothing AndAlso
                                    FlowChart.FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions.Any(Function(Entity) Entity.Print = True) Then

                                FlowChartBuilder = New AdvantageFramework.MediaPlanning.FlowChart.FlowChartBuilder()
                                FlowChartBuilder.Construct(FlowChart)

                                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

                                FileName = Folder & AdvantageFramework.FileSystem.CreateValidFileName(MediaPlanReadOnly.Description) & ".xlsx"
                                FileNameTemplate = Folder & AdvantageFramework.FileSystem.CreateValidFileName(MediaPlanReadOnly.Description) & " {0}.xlsx"

                                If My.Computer.FileSystem.FileExists(FileName) Then

                                    FileNameCounter = 0

                                    Do

                                        FileName = String.Format(FileNameTemplate, FileNameCounter)

                                        FileNameCounter += 1

                                    Loop Until My.Computer.FileSystem.FileExists(FileName) = False

                                End If

                                FlowChartBuilder.SaveAsAndOpen(Me.Session, IsASP, FileName)

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("There are no estimates to print.")

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemEstimate_Actualize_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimate_Actualize.Click

            Dim Message As String = String.Empty
            Dim MediaPlanID As Integer = 0
            Dim MediaPlanDetailID As Integer = 0

            If DataGridViewLeftSection_MediaPlans.HasOnlyOneSelectedRow Then

                MediaPlanID = DataGridViewLeftSection_MediaPlans.GetFirstSelectedRowBookmarkValue()

                If MediaPlanID <> 0 Then

                    MediaPlanDetailID = DataGridViewEstimates_Estimates.GetFirstSelectedRowBookmarkValue(1)

                    If MediaPlanDetailID <> 0 Then

                        If CheckForOpenMediaPlan(Me.MdiParent, MediaPlanID, MediaPlanDetailID) = False Then

                            If AdvantageFramework.MediaPlanning.IsEstimateLocked(Session, MediaPlanDetailID, Message) Then

                                AdvantageFramework.WinForm.MessageBox.Show(Message)

                            Else

                                AdvantageFramework.Media.Presentation.MediaPlanActualizeDialog.ShowFormDialog(MediaPlanDetailID)
                                RefreshForm()

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("You currently have this estimate open, please close before accessing.")

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDocuments_Upload_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Upload.Click

            If TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab) Then

                DocumentManagerControlDocuments_Documents.UploadNewDocument(AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan)

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemUpload_EmailLink_Click(sender As Object, e As EventArgs) Handles ButtonItemUpload_EmailLink.Click

            If TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab) Then

                DocumentManagerControlDocuments_Documents.SendASPUploadEmail(AdvantageFramework.Database.Entities.DocumentLevel.MediaPlan)

            End If

        End Sub
        Private Sub ButtonItemDocuments_Download_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_Download.Click

            If TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab) Then

                DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemDocuments_OpenURL_Click(sender As Object, e As EventArgs) Handles ButtonItemDocuments_OpenURL.Click

            If TabControlForm_Estimates.SelectedTab.Equals(TabItemReport_DocumentsTab) Then

                DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
