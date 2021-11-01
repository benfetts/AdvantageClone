Namespace WinForm.Presentation.Controls

    Public Class MediaPlanMasterPlanControl

        Public Event EnableOrDisableActionsEvent()
        Public Event EnableOrDisableAddColumnHeadersEvent()
        Public Event MediaPlanMasterPlanChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum Columns
            [Client]
            [Plan]
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

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _MediaPlanMasterPlanID As Integer = 0
        Private _AddColumnsHeadersToAllEstimatesEnabled As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property AddColumnsHeadersToAllEstimatesEnabled As Boolean
            Get
                AddColumnsHeadersToAllEstimatesEnabled = _AddColumnsHeadersToAllEstimatesEnabled
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TabControlControl_MasterPlanDetails.SelectedTab = TabItemMasterPlanDetails_PlansTab

                            DataGridViewEstimates_Estimates.OptionsView.ShowFooter = True
                            DataGridViewEstimates_Estimates.ItemDescription = "Estimate(s)"
                            DataGridViewEstimates_Estimates.SetBookmarkColumnIndex(0)

                            TextBoxTopSection_Description.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanMasterPlan.Properties.Description)
                            TextBoxTopSection_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanMasterPlan.Properties.Comment)

                        End Using

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning_MasterPlans)

                            End Using

                            If Dashboard IsNot Nothing AndAlso Dashboard.Layout IsNot Nothing AndAlso Dashboard.Layout.Length > 0 Then

                                MemoryStream = New System.IO.MemoryStream(Dashboard.Layout)

                                DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                                TabItemMasterPlanDetails_DashboardTab.Visible = True

                            Else

                                If My.Resources.MediaPlanDashboard IsNot Nothing AndAlso My.Resources.MediaPlanDashboard.Length > 0 Then

                                    MemoryStream = New System.IO.MemoryStream(My.Resources.MediaPlanDashboard)

                                    DashboardViewerDashboard_Dashboard.LoadDashboard(MemoryStream)

                                    TabItemMasterPlanDetails_DashboardTab.Visible = True

                                Else

                                    TabItemMasterPlanDetails_DashboardTab.Visible = False

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan)

            If MediaPlanMasterPlan IsNot Nothing Then

                MediaPlanMasterPlan.Description = TextBoxTopSection_Description.Text
                MediaPlanMasterPlan.Comment = TextBoxTopSection_Comment.Text

            End If

        End Sub
        Private Sub LoadMasterPlanDetails(DbContext As AdvantageFramework.Database.DbContext, MediaPlanMasterPlanID As Integer)

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail) = Nothing
            Dim AvailableMediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim SelectedMediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim MediaPlanIDs() As Integer = Nothing

			MediaPlanMasterPlanDetails = AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.LoadByMediaPlanMasterPlanID(DbContext, MediaPlanMasterPlanID).Include("MediaPlan").Include("MediaPlan.MediaPlanDetails").Include("MediaPlan.Client").Include("MediaPlan.Division").Include("MediaPlan.Product").ToList
			SelectedMediaPlanMasterPlanDetails = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)
            AvailableMediaPlanMasterPlanDetails = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)

            For Each MediaPlanMasterPlanDetail In MediaPlanMasterPlanDetails

                SelectedMediaPlanMasterPlanDetails.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail(MediaPlanMasterPlanDetail, MediaPlanMasterPlanDetail.MediaPlan))

            Next

            MediaPlanIDs = MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlanID).ToArray

			For Each MediaPlan In AdvantageFramework.Database.Procedures.MediaPlan.Load(DbContext).Include("MediaPlanDetails").Include("Client").Include("Division").Include("Product").Where(Function(Entity) MediaPlanIDs.Contains(Entity.ID) = False).ToList

				AvailableMediaPlanMasterPlanDetails.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail(MediaPlan))

			Next

			DataGridViewPlansLeft_MediaPlans.DataSource = AvailableMediaPlanMasterPlanDetails
            DataGridViewPlansRight_SelectedMediaPlans.DataSource = SelectedMediaPlanMasterPlanDetails

            LoadMediaPlanMasterPlanDetails()

        End Sub
        Private Sub LoadMediaPlanMasterPlanDetails()

            'objects
            Dim MediaPlanIDs As Generic.List(Of Integer) = Nothing
            Dim MediaPlanID As Integer = 0

            MediaPlanIDs = DataGridViewPlansRight_SelectedMediaPlans.GetAllRowsCellValues(1).OfType(Of Integer).ToList

            If MediaPlanIDs.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, MediaPlanIDs)

                    If TabItemMasterPlanDetails_DashboardTab.Visible Then

                        LoadDashboard(DbContext, MediaPlanIDs)

                    End If

                End Using

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, MediaPlanIDs)

                    If TabItemMasterPlanDetails_DashboardTab.Visible Then

                        LoadDashboardDataSource(CreateDashboardDataTable)

                    End If

                End Using

            End If

            If DataGridViewEstimates_Estimates.Columns("PartialOrdered") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("PartialOrdered").Visible = False

            End If

            If DataGridViewEstimates_Estimates.Columns("FullOrdered") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("FullOrdered").Visible = False

            End If

            If DataGridViewEstimates_Estimates.Columns("Ordered") IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewEstimates_Estimates, DataGridViewEstimates_Estimates.Columns("Ordered"))

            End If

            If DataGridViewEstimates_Estimates.Columns("DollarsAmount") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("DollarsAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("DollarsAmount").DisplayFormat.Format)

            End If

            If DataGridViewEstimates_Estimates.Columns("BillableAmount") IsNot Nothing Then

                DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.FormatString = "c2"

                DataGridViewEstimates_Estimates.Columns("BillableAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewEstimates_Estimates.Columns("BillableAmount").DisplayFormat.Format)

            End If

            DataGridViewEstimates_Estimates.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadEstimates(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanIDs As Generic.List(Of Integer)) As IEnumerable

            'objects
            Dim MediaPlanDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing

            MediaPlanDetailsList = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("MediaPlan").Include("MediaPlan.Client").Include("MediaPlanDetailLevelLineDatas").Include("MediaPlanDetailChangeLogs").
                                                                                          Where(Function(Entity) MediaPlanIDs.Contains(Entity.MediaPlanID) = True).
                                                                                          OrderBy(Function(Entity) Entity.MediaPlan.Client.Name).ThenBy(Function(Entity) Entity.MediaPlan.Description).ThenBy(Function(Entity) Entity.OrderNumber).ToList

            LoadEstimates = (From MediaPlanDetail In MediaPlanDetailsList
                             Join Product In DbContext.ProductViews On Product.ClientCode Equals MediaPlanDetail.MediaPlan.ClientCode And Product.DivisionCode Equals MediaPlanDetail.MediaPlan.DivisionCode And Product.ProductCode Equals MediaPlanDetail.MediaPlan.ProductCode
                             Select New With {.[ClientName] = MediaPlanDetail.MediaPlan.Client.Name,
                                              .[DivisionName] = Product.DivisionName,
                                              .[ProductName] = Product.ProductDescription,
                                              .[Plan] = MediaPlanDetail.MediaPlan.Description,
                                              .[EstimateID] = MediaPlanDetail.ID,
                                              .[Estimate] = MediaPlanDetail.Name,
                                              .[StartDate] = MediaPlanDetail.MediaPlan.StartDate,
                                              .[EndDate] = MediaPlanDetail.MediaPlan.EndDate,
                                              .[FullOrdered] = (MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Count = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Count) AndAlso MediaPlanDetail.MediaPlanDetailLevelLineDatas.Count > 0,
                                              .[PartialOrdered] = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.OrderID IsNot Nothing AndAlso Entity.OrderLineID IsNot Nothing AndAlso (Entity.OrderNumber IsNot Nothing OrElse Entity.OrderLineNumber IsNot Nothing)).Any,
                                              .[Ordered] = If(.FullOrdered, 0, (If(.PartialOrdered, 1, 2))),
                                              .[DollarsAmount] = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.Dollars.GetValueOrDefault(0)).Sum,
                                              .[BillableAmount] = MediaPlanDetail.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum}).ToList

        End Function
        Private Sub LoadDashboardDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataTable As System.Data.DataTable, ByVal MediaPlanIDs As Generic.List(Of Integer))

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
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim GrossBudgetAmount As Decimal = 0
            Dim Plan As String = String.Empty
            Dim Client As String = String.Empty
            Dim Campaign As String = String.Empty
            Dim Buyer As String = String.Empty
            Dim CampaignEntity As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Campaigns As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EstimateBudgetAmount As Decimal = 0

            Campaigns = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).ToList
            Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

            For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("MediaPlan").Include("MediaPlan.Client").Include("MediaPlanDetailLevelLineDatas").
                                                                                               Where(Function(Entity) MediaPlanIDs.Contains(Entity.MediaPlanID) = True)

                MediaType = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), MediaPlanDetail.SalesClassType)
                Estimate = MediaPlanDetail.Name
                SalesClass = MediaPlanDetail.SalesClass.ToString
                StartDate = MediaPlanDetail.MediaPlan.StartDate
                EndDate = MediaPlanDetail.MediaPlan.EndDate
                GrossBudgetAmount = MediaPlanDetail.MediaPlan.GrossBudgetAmount.GetValueOrDefault(0)
                Client = MediaPlanDetail.MediaPlan.Client.Name
                Plan = MediaPlanDetail.MediaPlan.Description
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

                            DataRow(Columns.Client.ToString) = Client
                            DataRow(Columns.Plan.ToString) = Plan
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
                            DataRow(Columns.BillAmount.ToString) = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0)
                            DataRow(Columns.GrossBudgetAmount.ToString) = GrossBudgetAmount

                        Next

                    Else

                        DataRow = DataTable.Rows.Add()

                        DataRow(Columns.Client.ToString) = Client
                        DataRow(Columns.Plan.ToString) = Plan
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

            Next

        End Sub
        Private Sub LoadDashboard(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanIDs As Generic.List(Of Integer))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DataTable = CreateDashboardDataTable()

                LoadDashboardDataTable(DbContext, DataTable, MediaPlanIDs)

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

                If DataColumnName = Columns.Client.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.Plan.ToString Then

                    DataColumn.DataType = GetType(String)

                ElseIf DataColumnName = Columns.Estimate.ToString Then

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

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallGreenSemiCircleImage)
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

            RaiseEvent EnableOrDisableActionsEvent()

            EnableOrDisableAddColumnHeaders()

        End Sub
        Private Sub EnableOrDisableDetailActions()

            ButtonPlansRight_AddAllPlans.Enabled = DataGridViewPlansLeft_MediaPlans.HasRows
            ButtonPlansRight_AddPlan.Enabled = DataGridViewPlansLeft_MediaPlans.HasASelectedRow
            ButtonPlansRight_RemoveAllPlans.Enabled = DataGridViewPlansRight_SelectedMediaPlans.HasRows
            ButtonPlansRight_RemovePlan.Enabled = DataGridViewPlansRight_SelectedMediaPlans.HasASelectedRow

            EnableOrDisableAddColumnHeaders()

        End Sub
        Private Sub EnableOrDisableAddColumnHeaders()

            'objects
            Dim Enabled As Boolean = False
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing

            If DataGridViewPlansRight_SelectedMediaPlans.HasRows Then

                Try

                    MediaPlanMasterPlanDetails = DataGridViewPlansRight_SelectedMediaPlans.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                Catch ex As Exception
                    MediaPlanMasterPlanDetails = Nothing
                End Try

                If MediaPlanMasterPlanDetails IsNot Nothing Then

                    Enabled = MediaPlanMasterPlanDetails.All(Function(Entity) Entity.SyncDetailSettings = True)

                End If

            End If

            _AddColumnsHeadersToAllEstimatesEnabled = Enabled

            RaiseEvent EnableOrDisableAddColumnHeadersEvent()

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal MediaPlanMasterPlanID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing

            _MediaPlanMasterPlanID = MediaPlanMasterPlanID

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _MediaPlanMasterPlanID <> 0 Then

                    MediaPlanMasterPlan = AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.LoadByMediaPlanMasterPlanID(DbContext, _MediaPlanMasterPlanID)

                    If MediaPlanMasterPlan IsNot Nothing Then

                        TextBoxTopSection_Description.Text = MediaPlanMasterPlan.Description
                        TextBoxTopSection_Comment.Text = MediaPlanMasterPlan.Comment

                        LoadMasterPlanDetails(DbContext, _MediaPlanMasterPlanID)

                    Else

                        Loaded = False

                    End If

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean, ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.MediaPlanMasterPlan

            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing

            Try

                If IsNew Then

                    MediaPlanMasterPlan = New AdvantageFramework.Database.Entities.MediaPlanMasterPlan

                    LoadEntity(MediaPlanMasterPlan)

                Else

                    MediaPlanMasterPlan = AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.LoadByMediaPlanMasterPlanID(DbContext, _MediaPlanMasterPlanID)

                    If MediaPlanMasterPlan IsNot Nothing Then

                        LoadEntity(MediaPlanMasterPlan)

                    End If


                End If

            Catch ex As Exception
                Location = Nothing
            End Try

            FillObject = MediaPlanMasterPlan

        End Function
        Public Sub ClearControl()

            TextBoxTopSection_Description.Text = ""
            TextBoxTopSection_Comment.Text = ""

            DataGridViewPlansLeft_MediaPlans.DataSource = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)
            DataGridViewPlansRight_SelectedMediaPlans.DataSource = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewEstimates_Estimates.DataSource = LoadEstimates(DbContext, New Generic.List(Of Integer)({-1}))

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaPlanMasterPlan = Me.FillObject(False, DbContext)

                    If MediaPlanMasterPlan IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Update(DbContext, MediaPlanMasterPlan) Then

                            For Each MPMPD In DataGridViewPlansLeft_MediaPlans.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                                If MPMPD.MediaPlanMasterPlanDetailID > 0 Then

                                    If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.DeleteByMediaPlanMasterPlanDetailID(DbContext, MPMPD.MediaPlanMasterPlanDetailID) = False Then

                                        Saved = False
                                        Exit For

                                    End If

                                End If

                            Next

                            If Saved Then

                                For Each MPMPD In DataGridViewPlansRight_SelectedMediaPlans.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                                    If MPMPD.MediaPlanMasterPlanDetailID = 0 Then

                                        MediaPlanMasterPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail

                                        MediaPlanMasterPlanDetail.DbContext = DbContext
                                        MediaPlanMasterPlanDetail.MediaPlanMasterPlanID = MediaPlanMasterPlan.ID
                                        MediaPlanMasterPlanDetail.MediaPlanID = MPMPD.MediaPlanID

                                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.Insert(DbContext, MediaPlanMasterPlanDetail) = False Then

                                            Saved = False
                                            Exit For

                                        End If

                                    End If

                                Next

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                Saved = False
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Sub Insert(ByRef MediaPlanMasterPlanID As Integer)

            'objects
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaPlanMasterPlan = Me.FillObject(True, DbContext)

                    If MediaPlanMasterPlan IsNot Nothing Then

                        MediaPlanMasterPlan.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Insert(DbContext, MediaPlanMasterPlan) Then

                            MediaPlanMasterPlanID = MediaPlanMasterPlan.ID

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Delete()

            'objects
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaPlanMasterPlan = Me.FillObject(False, DbContext)

                    If MediaPlanMasterPlan IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Delete(DbContext, MediaPlanMasterPlan) = False Then

                            ErrorMessage = "The master plan is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub EditDashboard()

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim MediaPlanID As Integer = 0
            Dim MediaPlanIDs As Generic.List(Of Integer) = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing
            Dim DashboadChanged As Boolean = False

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerDashboard_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                DashboardLayout = MemoryStream.ToArray
                MemoryStream.Flush()
                MemoryStream.Close()

                DataTable = CreateDashboardDataTable()

                MediaPlanIDs = DataGridViewPlansRight_SelectedMediaPlans.GetAllRowsCellValues(1).OfType(Of Integer).ToList

                If MediaPlanIDs.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LoadDashboardDataTable(DbContext, DataTable, MediaPlanIDs)

                    End Using

                End If

                If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(_Session, DataTable, DashboardLayout, DashboadChanged) = Windows.Forms.DialogResult.OK Then

                    If DashboadChanged Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning_MasterPlans)

                                If Dashboard IsNot Nothing Then

                                    Dashboard.Layout = DashboardLayout

                                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                                Else

                                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                                    Dashboard.DbContext = DbContext
                                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.MediaPlanning_MasterPlans
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

                End If

                LoadDashboardDataSource(DataTable)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub MediaPlanMasterPlanControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewPlansLeft_MediaPlans.DataSource = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)
            DataGridViewPlansRight_SelectedMediaPlans.DataSource = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail)

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewPlansLeft_MediaPlans_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPlansLeft_MediaPlans.SelectionChangedEvent

            EnableOrDisableDetailActions()

        End Sub
        Private Sub DataGridViewPlansRight_SelectedMediaPlans_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPlansRight_SelectedMediaPlans.SelectionChangedEvent

            EnableOrDisableDetailActions()

        End Sub
        Private Sub ButtonPlansRight_AddAllPlans_Click(sender As Object, e As EventArgs) Handles ButtonPlansRight_AddAllPlans.Click

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim Saved As Boolean = False
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing

            If DataGridViewPlansLeft_MediaPlans.HasRows Then

                If _MediaPlanMasterPlanID > 0 Then

                    Try

                        MediaPlanMasterPlanDetails = DataGridViewPlansLeft_MediaPlans.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                    Catch ex As Exception
                        MediaPlanMasterPlanDetails = Nothing
                    End Try

                    If MediaPlanMasterPlanDetails IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each MPMPD In MediaPlanMasterPlanDetails

                                MediaPlanMasterPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail

                                MediaPlanMasterPlanDetail.DbContext = DbContext

                                MediaPlanMasterPlanDetail.MediaPlanMasterPlanID = _MediaPlanMasterPlanID
                                MediaPlanMasterPlanDetail.MediaPlanID = MPMPD.MediaPlanID

                                DbContext.MediaPlanMasterPlanDetails.Add(MediaPlanMasterPlanDetail)

                            Next

                            Try

                                DbContext.SaveChanges()

                                Saved = True

                            Catch ex As Exception
                                Saved = False
                            End Try

                            If Saved Then

                                LoadMasterPlanDetails(DbContext, _MediaPlanMasterPlanID)

                                RaiseEvent MediaPlanMasterPlanChangedEvent()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonPlansRight_AddPlan_Click(sender As Object, e As EventArgs) Handles ButtonPlansRight_AddPlan.Click

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim Saved As Boolean = False
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing

            If DataGridViewPlansLeft_MediaPlans.HasASelectedRow Then

                If _MediaPlanMasterPlanID > 0 Then

                    Try

                        MediaPlanMasterPlanDetails = DataGridViewPlansLeft_MediaPlans.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                    Catch ex As Exception
                        MediaPlanMasterPlanDetails = Nothing
                    End Try

                    If MediaPlanMasterPlanDetails IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each MPMPD In MediaPlanMasterPlanDetails

                                MediaPlanMasterPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail

                                MediaPlanMasterPlanDetail.DbContext = DbContext

                                MediaPlanMasterPlanDetail.MediaPlanMasterPlanID = _MediaPlanMasterPlanID
                                MediaPlanMasterPlanDetail.MediaPlanID = MPMPD.MediaPlanID

                                DbContext.MediaPlanMasterPlanDetails.Add(MediaPlanMasterPlanDetail)

                            Next

                            Try

                                DbContext.SaveChanges()

                                Saved = True

                            Catch ex As Exception
                                Saved = False
                            End Try

                            If Saved Then

                                LoadMasterPlanDetails(DbContext, _MediaPlanMasterPlanID)

                                RaiseEvent MediaPlanMasterPlanChangedEvent()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonPlansRight_RemoveAllPlans_Click(sender As Object, e As EventArgs) Handles ButtonPlansRight_RemoveAllPlans.Click

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim Saved As Boolean = False
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If DataGridViewPlansRight_SelectedMediaPlans.HasRows Then

                If _MediaPlanMasterPlanID > 0 Then

                    Try

                        MediaPlanMasterPlanDetails = DataGridViewPlansRight_SelectedMediaPlans.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                    Catch ex As Exception
                        MediaPlanMasterPlanDetails = Nothing
                    End Try

                    If MediaPlanMasterPlanDetails IsNot Nothing Then

                        Saved = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            For Each MPMPD In MediaPlanMasterPlanDetails

                                If MPMPD.MediaPlanMasterPlanDetailID > 0 Then

                                    If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.DeleteByMediaPlanMasterPlanDetailID(DbContext, MPMPD.MediaPlanMasterPlanDetailID) = False Then

                                        Saved = False

                                    End If

                                End If

                            Next

                            If Saved Then

                                DbTransaction.Commit()

                                DbContext.Database.Connection.Close()

                                LoadMasterPlanDetails(DbContext, _MediaPlanMasterPlanID)

                                RaiseEvent MediaPlanMasterPlanChangedEvent()

                            Else

                                DbTransaction.Rollback()

                                DbContext.Database.Connection.Close()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonPlansRight_RemovePlan_Click(sender As Object, e As EventArgs) Handles ButtonPlansRight_RemovePlan.Click

            'objects
            Dim MediaPlanMasterPlanDetails As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail) = Nothing
            Dim Saved As Boolean = False
            Dim MediaPlanMasterPlanDetail As AdvantageFramework.Database.Entities.MediaPlanMasterPlanDetail = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If DataGridViewPlansRight_SelectedMediaPlans.HasASelectedRow Then

                If _MediaPlanMasterPlanID > 0 Then

                    Try

                        MediaPlanMasterPlanDetails = DataGridViewPlansRight_SelectedMediaPlans.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanMasterPlanDetail).ToList

                    Catch ex As Exception
                        MediaPlanMasterPlanDetails = Nothing
                    End Try

                    If MediaPlanMasterPlanDetails IsNot Nothing Then

                        Saved = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            For Each MPMPD In MediaPlanMasterPlanDetails

                                If MPMPD.MediaPlanMasterPlanDetailID > 0 Then

                                    If AdvantageFramework.Database.Procedures.MediaPlanMasterPlanDetail.DeleteByMediaPlanMasterPlanDetailID(DbContext, MPMPD.MediaPlanMasterPlanDetailID) = False Then

                                        Saved = False

                                    End If

                                End If

                            Next

                            If Saved Then

                                DbTransaction.Commit()

                                DbContext.Database.Connection.Close()

                                LoadMasterPlanDetails(DbContext, _MediaPlanMasterPlanID)

                                RaiseEvent MediaPlanMasterPlanChangedEvent()

                            Else

                                DbTransaction.Rollback()

                                DbContext.Database.Connection.Close()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub TabControlControl_MasterPlanDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_MasterPlanDetails.SelectedTabChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
