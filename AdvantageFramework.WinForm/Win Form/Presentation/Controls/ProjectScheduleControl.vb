Namespace WinForm.Presentation.Controls

    Public Class ProjectScheduleControl

        Public Event SelectedTabChangedEvent()
        Public Event SelectedDetailChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _JobTrafficID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobCompNumber As Short = Nothing
        Private _IsCopy As Boolean = False
        Private _JobInformationLoading As Boolean = False
        Private _HasApprovedEstimate As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = TabControlControl_ProjectScheduleDetails.SelectedTab
            End Get
        End Property
        Public ReadOnly Property TasksDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                TasksDataGridView = DataGridViewControl_Details
            End Get
        End Property
        Public ReadOnly Property CanDeleteSelectedTask As Boolean
            Get

                'objects
                Dim CanDelete As Boolean = False

                If DataGridViewControl_Details.HasASelectedRow Then

                    If (From Entity In DataGridViewControl_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)()
                        Where Entity.HasAssignment <> 1
                        Select Entity).Any Then

                        CanDelete = True

                    End If

                End If

                CanDeleteSelectedTask = CanDelete

            End Get
        End Property
        Public ReadOnly Property HasEmployeesAssigned As Boolean
            Get

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        HasEmployeesAssigned = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Load(DbContext)
                                                Where Entity.JobNumber = _JobNumber AndAlso
                                                      Entity.JobComponentNumber = _JobCompNumber
                                                Select Entity).Any

                    End Using

                Catch ex As Exception
                    HasEmployeesAssigned = False
                End Try

            End Get
        End Property
        Public ReadOnly Property HasApprovedEstimate As Boolean
            Get
                HasApprovedEstimate = _HasApprovedEstimate
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
            Dim Settings As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim ScheduleAssignment As AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment = Nothing
            Dim ScheduleAssignmentList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment) = Nothing
            Dim TrafficManagerSetting As AdvantageFramework.Database.Entities.Setting = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DataGridViewAssignments_Assignments.AllowExtraItemsInGridLookupEdits = False
                                DataGridViewAssignments_Assignments.OptionsView.ShowViewCaption = False

                                DataGridViewControl_Details.AllowExtraItemsInGridLookupEdits = False

                                SearchableComboBoxJobInformation_AccountExecutive.Properties.ReadOnly = True

                                TabControlControl_ProjectScheduleDetails.SelectedTab = TabItemProjectScheduleDetails_JobInformationTab

                                SearchableComboBoxJobInformation_Client.AddInactiveItemsOnSelectedValue = True
                                SearchableComboBoxJobInformation_Division.AddInactiveItemsOnSelectedValue = True
                                SearchableComboBoxJobInformation_Product.AddInactiveItemsOnSelectedValue = True
                                SearchableComboBoxJobInformation_Job.AddInactiveItemsOnSelectedValue = True
                                SearchableComboBoxJobInformation_Component.AddInactiveItemsOnSelectedValue = True

                                SearchableComboBoxJobInformation_Client.DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                                     Where Entity.IsActive = 1
                                                                                     Select Entity

                                SearchableComboBoxJobInformation_AccountExecutive.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                                SearchableComboBoxTaskDetails_TrafficStatus.DataSource = AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)

                                DataGridViewJobsThatPrecede_AvailableJobs.ItemDescription = "Available Job(s)"
                                DataGridViewJobsThatPrecede_Jobs.ItemDescription = "Job(s) that precede this job"
                                DataGridViewJobsThatFollow_Jobs.ItemDescription = "Job(s) that follow this job"

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    ScheduleAssignmentList = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment)

                                    Settings = AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, 0, 2).ToList

                                    Try

                                        TrafficManagerSetting = (From Setting In Settings
                                                                 Where Setting.Code = AdvantageFramework.Agency.Settings.TRAFFIC_MGR_COL.ToString
                                                                 Select Setting).SingleOrDefault

                                    Catch ex As Exception
                                        TrafficManagerSetting = Nothing
                                    End Try

                                    For Each Setting In Settings

                                        If Setting.Code.Contains("TR_TITLE") Then

                                            ScheduleAssignment = New AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment
                                            ScheduleAssignment.Key = Setting.Code
                                            ScheduleAssignment.Title = CStr(Setting.Value)

                                            If TrafficManagerSetting IsNot Nothing AndAlso String.IsNullOrEmpty(TrafficManagerSetting.Value) = False Then

                                                If CStr(TrafficManagerSetting.Value) = Setting.Code Then

                                                    ScheduleAssignment.IsManager = True

                                                End If

                                            End If

                                            ScheduleAssignmentList.Add(ScheduleAssignment)

                                        End If

                                    Next

                                    DataGridViewAssignments_Assignments.DataSource = ScheduleAssignmentList
                                    DataGridViewAssignments_Assignments.CurrentView.BestFitColumns()

                                    DateTimePickerOtherInformation_Shipped.ValueObject = Nothing
                                    DateTimePickerOtherInformation_Delivered.ValueObject = Nothing
                                    DateTimePickerTaskDetails_StartDate.ValueObject = Nothing
                                    DateTimePickerTaskDetails_DueDate.ValueObject = Nothing
                                    DateTimePickerTaskDetails_CompletedDate.ValueObject = Nothing

                                End Using

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                SaveJobInformationTab(JobTraffic)
                SaveCommentsTab(JobTraffic)
                SaveOtherInformationTab(JobTraffic)
                SaveAssignmentsTab(JobTraffic)
                SaveRelatedJobsTab(JobTraffic)
                SaveTaskDetailsTab(JobTraffic)

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim DivisionEnabled As Boolean = False
            Dim ProductEnabled As Boolean = False
            Dim ComponentEnabled As Boolean = False

            ButtonRightSection_AddJob.Enabled = DataGridViewJobsThatPrecede_AvailableJobs.HasASelectedRow
            ButtonRightSection_RemoveJob.Enabled = DataGridViewJobsThatPrecede_Jobs.HasASelectedRow

            If SearchableComboBoxJobInformation_Client.HasASelectedValue Then

                DivisionEnabled = True

                If SearchableComboBoxJobInformation_Division.HasASelectedValue Then

                    ProductEnabled = True

                End If

            End If

            If SearchableComboBoxJobInformation_Job.HasASelectedValue Then

                ComponentEnabled = True

            End If

            SearchableComboBoxJobInformation_Division.Enabled = DivisionEnabled
            SearchableComboBoxJobInformation_Product.Enabled = ProductEnabled
            SearchableComboBoxJobInformation_Component.Enabled = ComponentEnabled

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.JobTraffic

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                DataGridViewAssignments_Assignments.CurrentView.CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If IsNew Then

                        JobTraffic = New AdvantageFramework.Database.Entities.JobTraffic

                        LoadEntity(JobTraffic)

                    Else

                        JobTraffic = LoadJobTraffic()

                        If JobTraffic IsNot Nothing Then

                            LoadEntity(JobTraffic)

                        End If

                    End If

                End Using

            Catch ex As Exception
                JobTraffic = Nothing
            End Try

            FillObject = JobTraffic

        End Function
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            If TabItem Is Nothing Then

                For Each TabItem In TabControlControl_ProjectScheduleDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    If TabItem IsNot TabItemProjectScheduleDetails_JobInformationTab Then

                        TabItem.Tag = False

                    End If

                Next

                TabItem = TabControlControl_ProjectScheduleDetails.SelectedTab

            End If

            If TabItem.Tag = False Then

                If TabItem Is TabItemProjectScheduleDetails_RelatedJobsTab Then

                    LoadRelatedJobsTab()

                Else

                    JobTraffic = LoadJobTraffic()

                    If JobTraffic IsNot Nothing Then

                        If TabItemProjectScheduleDetails_CommentsTab.Tag = False Then

                            LoadCommentsTab(JobTraffic)

                        End If

                        If TabItemProjectScheduleDetails_OtherInformationTab.Tag = False Then

                            LoadOtherInformationTab(JobTraffic)

                        End If

                        If TabItemProjectScheduleDetails_AssignmentsTab.Tag = False Then

                            LoadAssignmentsTab(JobTraffic)

                        End If

                        If TabItemProjectScheduleDetails_TaskDetailsTab.Tag = False Then

                            LoadTaskDetailsTab(JobTraffic)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Function LoadJobTraffic() As AdvantageFramework.Database.Entities.JobTraffic

            'objects
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByID(DbContext, _JobTrafficID)

                End Using

            Catch ex As Exception
                JobTraffic = Nothing
            End Try

            LoadJobTraffic = JobTraffic

        End Function
        Private Function LoadJob() As AdvantageFramework.Database.Entities.Job

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _JobNumber)

                End Using

            Catch ex As Exception
                Job = Nothing
            End Try

            LoadJob = Job

        End Function
        Private Sub LoadJobInformation(ByVal Job As AdvantageFramework.Database.Entities.Job)

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If Job IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SearchableComboBoxJobInformation_Client.SelectedValue = Job.ClientCode

                    LoadDivisionLookup()

                    SearchableComboBoxJobInformation_Division.SelectedValue = Job.DivisionCode

                    If SearchableComboBoxJobInformation_Division.HasASelectedValue = False Then

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Job.ClientCode, Job.DivisionCode)

                        If Division IsNot Nothing Then

                            SearchableComboBoxJobInformation_Division.AddComboItemToExistingDataSource(Division.ToString, Division.Code, False)

                            SearchableComboBoxJobInformation_Division.SelectedValue = Division.Code

                        End If

                    End If

                    LoadProductLookup()

                    SearchableComboBoxJobInformation_Product.SelectedValue = Job.ProductCode

                    If SearchableComboBoxJobInformation_Product.HasASelectedValue = False Then

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Job.ClientCode, Job.DivisionCode, Job.ProductCode)

                        If Product IsNot Nothing Then

                            SearchableComboBoxJobInformation_Product.AddComboItemToExistingDataSource(Product.ToString, Product.Code, False)

                            SearchableComboBoxJobInformation_Product.SelectedValue = Division.Code

                        End If

                    End If

                    LoadJobLookup()

                    SearchableComboBoxJobInformation_Job.SelectedValue = Job.Number

                    LoadJobComponentLookup()

                End Using

                TabItemProjectScheduleDetails_JobInformationTab.Tag = True

            End If

        End Sub
        Private Sub LoadJobComponentInformation()

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If SearchableComboBoxJobInformation_Component.HasASelectedValue Then

                JobNumber = SearchableComboBoxJobInformation_Job.GetSelectedValue
                JobComponentNumber = SearchableComboBoxJobInformation_Component.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        LoadComponentInformation(JobComponent)

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadComponentInformation(ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent)

            If JobComponent IsNot Nothing Then

                SearchableComboBoxJobInformation_Component.SelectedValue = JobComponent.Number

                If SearchableComboBoxJobInformation_Component.HasASelectedValue = False Then

                    SearchableComboBoxJobInformation_Component.AddComboItemToExistingDataSource(JobComponent.ToString(False, True), JobComponent.Number, False)

                    SearchableComboBoxJobInformation_Component.SelectedValue = JobComponent.Number

                End If

                SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = JobComponent.AccountExecutiveEmployeeCode
                DateTimePickerTaskDetails_DueDate.ValueObject = JobComponent.DueDate
                DateTimePickerTaskDetails_StartDate.ValueObject = JobComponent.StartDate

                If JobComponent.TrafficScheduleBy.GetValueOrDefault(1) = AdvantageFramework.Database.Entities.TrafficScheduleBy.StartDate Then

                    RadioButtonControlTaskDetails_StartDate.Checked = True

                Else

                    RadioButtonControlTaskDetails_DueDate.Checked = True

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _HasApprovedEstimate = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                            Where Entity.JobNumber = JobComponent.JobNumber AndAlso
                                                  Entity.JobComponentNumber = JobComponent.Number
                                            Select Entity).Any

                End Using

            End If

        End Sub
        Private Sub LoadCommentsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                TextBoxComments_Comments.Text = JobTraffic.TrafficComments

                TabItemProjectScheduleDetails_CommentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadOtherInformationTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                DateTimePickerOtherInformation_Shipped.ValueObject = JobTraffic.DateShipped
                DateTimePickerOtherInformation_Delivered.ValueObject = JobTraffic.DateDelivered
                TextBoxOtherInformation_ReceivedBy.Text = JobTraffic.ReceivedBy
                TextBoxOtherInformation_Reference.Text = JobTraffic.Reference

                TabItemProjectScheduleDetails_OtherInformationTab.Tag = True

            End If

        End Sub
        Private Sub LoadAssignmentsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            'objects
            Dim ScheduleAssignment As AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeCode As String = ""

            If JobTraffic IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each ScheduleAssignment In DataGridViewAssignments_Assignments.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment)()

                        Select Case ScheduleAssignment.Key

                            Case AdvantageFramework.Agency.Settings.TR_TITLE1.ToString

                                EmployeeCode = JobTraffic.Assign1

                            Case AdvantageFramework.Agency.Settings.TR_TITLE2.ToString

                                EmployeeCode = JobTraffic.Assign2

                            Case AdvantageFramework.Agency.Settings.TR_TITLE3.ToString

                                EmployeeCode = JobTraffic.Assign3

                            Case AdvantageFramework.Agency.Settings.TR_TITLE4.ToString

                                EmployeeCode = JobTraffic.Assign4

                            Case AdvantageFramework.Agency.Settings.TR_TITLE5.ToString

                                EmployeeCode = JobTraffic.Assign5

                        End Select

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            ScheduleAssignment.EmployeeCode = Employee.Code
                            ScheduleAssignment.EmployeeName = Employee.ToString

                        End If

                    Next

                End Using

                TabItemProjectScheduleDetails_AssignmentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadRelatedJobsTab()

            'objects
            Dim JobTrafficPredecessors As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            Dim AvailableJobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            AdvantageFramework.WinForm.Presentation.ShowWaitForm()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(DbContext).ToList

                Try

                    JobTrafficPredecessors = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobCompNumber).ToList

                Catch ex As Exception
                    JobTrafficPredecessors = Nothing
                End Try

                If JobTrafficPredecessors IsNot Nothing AndAlso JobTrafficPredecessors.Count > 0 Then

                    DataGridViewJobsThatPrecede_Jobs.DataSource = From Entity In JobComponents
                                                                  Where JobTrafficPredecessors.Where(Function(Pred) Pred.JobPredecessor = Entity.JobNumber AndAlso Pred.JobComponentPredecessor = Entity.JobComponentNumber).Any = True
                                                                  Select Entity

                    DataGridViewJobsThatPrecede_AvailableJobs.DataSource = From Entity In JobComponents
                                                                           Where JobTrafficPredecessors.Where(Function(Pred) Pred.JobPredecessor = Entity.JobNumber AndAlso Pred.JobComponentPredecessor = Entity.JobComponentNumber).Any = False
                                                                           Select Entity

                Else

                    DataGridViewJobsThatPrecede_AvailableJobs.DataSource = JobComponents
                    DataGridViewJobsThatPrecede_Jobs.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)

                End If

                DataGridViewJobsThatPrecede_AvailableJobs.CurrentView.BestFitColumns()
                DataGridViewJobsThatPrecede_Jobs.CurrentView.BestFitColumns()

                Try

                    JobTrafficPredecessors = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, _JobNumber, _JobCompNumber).ToList

                Catch ex As Exception
                    JobTrafficPredecessors = Nothing
                End Try

                If JobTrafficPredecessors IsNot Nothing AndAlso JobTrafficPredecessors.Count > 0 Then

                    DataGridViewJobsThatFollow_Jobs.DataSource = From Entity In JobComponents
                                                                 Where JobTrafficPredecessors.Where(Function(Pred) Pred.JobNumber = Entity.JobNumber AndAlso Pred.JobComponentNumber = Entity.JobComponentNumber).Any = True
                                                                 Select Entity

                Else

                    DataGridViewJobsThatFollow_Jobs.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)

                End If

                DataGridViewJobsThatFollow_Jobs.CurrentView.BestFitColumns()

                TabItemProjectScheduleDetails_RelatedJobsTab.Tag = True

            End Using

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub
        Private Sub LoadTaskDetailsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                SearchableComboBoxTaskDetails_TrafficStatus.SelectedValue = JobTraffic.TrafficCode
                DateTimePickerTaskDetails_CompletedDate.ValueObject = JobTraffic.CompletedDate
                NumericInputTaskDetails_GutComplete.EditValue = JobTraffic.PercentComplete

                TabItemProjectScheduleDetails_TaskDetailsTab.Tag = True

            End If

        End Sub
        Private Sub LoadScheduleTasks()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewControl_Details.DataSource = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, _JobNumber, _JobCompNumber, "", _Session.UserCode).OrderBy(Function(Task) Task.JobOrder).ToList

            End Using

            DataGridViewControl_Details.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDivisionLookup()

            'objects
            Dim ClientCode As String = Nothing

            If SearchableComboBoxJobInformation_Client.HasASelectedValue Then

                ClientCode = CStr(SearchableComboBoxJobInformation_Client.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxJobInformation_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                               Where Entity.ClientCode = ClientCode AndAlso
                                                                                     Entity.IsActive = 1
                                                                               Select Entity

                    End Using

                End Using

            Else

                SearchableComboBoxJobInformation_Division.DataSource = Nothing
                SearchableComboBoxJobInformation_Division.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadProductLookup()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If SearchableComboBoxJobInformation_Client.HasASelectedValue AndAlso SearchableComboBoxJobInformation_Division.HasASelectedValue Then

                ClientCode = CStr(SearchableComboBoxJobInformation_Client.GetSelectedValue)
                DivisionCode = CStr(SearchableComboBoxJobInformation_Division.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxJobInformation_Product.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, True)
                                                                               Where Entity.ClientCode = ClientCode AndAlso
                                                                                     Entity.DivisionCode = DivisionCode
                                                                               Select Entity).ToList

                    End Using

                End Using

            Else

                SearchableComboBoxJobInformation_Product.DataSource = Nothing
                SearchableComboBoxJobInformation_Product.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadJobLookup()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumbersWithoutSchedule As Integer() = {-1}
            Dim IsNew As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _JobTrafficID <= 0 OrElse _IsCopy Then

                        IsNew = True

                        Try

                            JobNumbersWithoutSchedule = DbContext.Database.SqlQuery(Of Integer)(" SELECT JOB_COMPONENT.JOB_NUMBER FROM dbo.JOB_COMPONENT " &
                                                                                                    " LEFT OUTER JOIN dbo.JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND " &
                                                                                                    "                                    JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR " &
                                                                                                    " WHERE JOB_TRAFFIC.JOB_NUMBER IS NULL AND " &
                                                                                                    "	    JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN(6, 12)").ToArray

                        Catch ex As Exception
                            JobNumbersWithoutSchedule = {-1}
                        End Try

                    End If

                    If SearchableComboBoxJobInformation_Client.HasASelectedValue Then

                        ClientCode = CStr(SearchableComboBoxJobInformation_Client.GetSelectedValue)

                        If SearchableComboBoxJobInformation_Division.HasASelectedValue Then

                            DivisionCode = CStr(SearchableComboBoxJobInformation_Division.GetSelectedValue)

                            If SearchableComboBoxJobInformation_Product.HasASelectedValue Then

                                ProductCode = CStr(SearchableComboBoxJobInformation_Product.GetSelectedValue)

                                SearchableComboBoxJobInformation_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                                  Where Entity.ClientCode = ClientCode AndAlso
                                                                                        Entity.DivisionCode = DivisionCode AndAlso
                                                                                        Entity.ProductCode = ProductCode AndAlso
                                                                                        Entity.IsOpen = 1 AndAlso
                                                                                        JobNumbersWithoutSchedule.Contains(Entity.Number) = IsNew
                                                                                  Select Entity
                                                                                  Order By Entity.Number Descending

                            Else

                                SearchableComboBoxJobInformation_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                                  Where Entity.ClientCode = ClientCode AndAlso
                                                                                        Entity.DivisionCode = DivisionCode AndAlso
                                                                                        Entity.IsOpen = 1 AndAlso
                                                                                        JobNumbersWithoutSchedule.Contains(Entity.Number) = IsNew
                                                                                  Select Entity
                                                                                  Order By Entity.Number Descending
                            End If

                        Else

                            SearchableComboBoxJobInformation_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                              Where Entity.ClientCode = ClientCode AndAlso
                                                                                    Entity.IsOpen = 1 AndAlso
                                                                                        JobNumbersWithoutSchedule.Contains(Entity.Number) = IsNew
                                                                              Select Entity
                                                                              Order By Entity.Number Descending

                        End If

                    Else

                        SearchableComboBoxJobInformation_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                          Where Entity.IsOpen = 1 AndAlso
                                                                                JobNumbersWithoutSchedule.Contains(Entity.Number) = IsNew
                                                                          Select Entity
                                                                          Order By Entity.Number Descending

                    End If

                    SearchableComboBoxJobInformation_Job.SelectSingleItemDataSource()

                End Using

            End Using

        End Sub
        Private Sub LoadJobComponentLookup()

            'objects
            Dim JobNumber As Integer = Nothing
            Dim IsNew As Boolean = False
            Dim JobComponentIDsWithoutSchedule As Integer() = {-1}

            If SearchableComboBoxJobInformation_Job.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _JobTrafficID <= 0 OrElse _IsCopy Then

                            IsNew = True

                            Try

                                JobComponentIDsWithoutSchedule = DbContext.Database.SqlQuery(Of Integer)(" SELECT JOB_COMPONENT.ROWID FROM dbo.JOB_COMPONENT " &
                                                                                                             " LEFT OUTER JOIN dbo.JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND " &
                                                                                                             "                                    JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR " &
                                                                                                             " WHERE JOB_TRAFFIC.JOB_NUMBER IS NULL AND " &
                                                                                                             "	     JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN(6, 12)").ToArray

                            Catch ex As Exception
                                JobComponentIDsWithoutSchedule = {-1}
                            End Try

                        End If

                        JobNumber = CInt(SearchableComboBoxJobInformation_Job.GetSelectedValue)

                        SearchableComboBoxJobInformation_Component.DataSource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, True)
                                                                                Where Entity.JobNumber = JobNumber AndAlso
                                                                                      JobComponentIDsWithoutSchedule.Contains(Entity.ID) = IsNew
                                                                                Select Entity

                    End Using

                End Using

            Else

                SearchableComboBoxJobInformation_Component.DataSource = Nothing
                SearchableComboBoxJobInformation_Component.SelectedValue = Nothing

            End If

        End Sub
        Private Function LoadTaskSelectionDialog(ByVal FormType As ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes) As Boolean

            'objects
            Dim Loaded As Boolean = False

            Try

                If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.ShowFormDialog(FormType, _JobNumber, _JobCompNumber, DateTimePickerTaskDetails_DueDate.ValueObject) = Windows.Forms.DialogResult.OK Then

                    LoadScheduleTasks()

                    Loaded = True

                End If

            Catch ex As Exception

            End Try

            LoadTaskSelectionDialog = Loaded

        End Function
        Private Sub ModifyColumnVisibility()

            'objects
            Dim VisibleIndex As Integer = 0
            Dim TrafficScheduleUserColumnList As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn) = Nothing

            If DataGridViewControl_Details.Columns.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each GridColumn In DataGridViewControl_Details.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                        GridColumn.Visible = False
                        GridColumn.VisibleIndex = -1

                    Next

                    TrafficScheduleUserColumnList = AdvantageFramework.Database.Procedures.TrafficScheduleUserColumnComplexType.Load(DbContext, _Session.User.EmployeeCode, True, True, False).ToList()

                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ID.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobNumber.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobComponentNumber.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TrafficPhaseID.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PhaseDescription.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Milestone.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobOrder.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Predecessor.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDays.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStartDate.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateLock.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueTime.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TemporaryCompleteDate.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobHours.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DispersedHours.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PostedHours.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PercentComplete.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EmployeeCode.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ClientContact.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EstimateFunction.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.FunctionComments.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateComments.ToString, TrafficScheduleUserColumnList, VisibleIndex)
                    ModifyColumn(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisionDateComments.ToString, TrafficScheduleUserColumnList, VisibleIndex)

                    DataGridViewControl_Details.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub ModifyColumn(ByVal Fieldname As String, ByVal TrafficScheduleUserColumnList As Generic.List(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn), ByRef VisibleIndex As Integer)

            'objects
            Dim IsVisible As Boolean = False
            Dim TrafficScheduleUserColumn As AdvantageFramework.Database.Classes.TrafficScheduleUserColumn = Nothing

            If DataGridViewControl_Details.Columns(Fieldname) IsNot Nothing Then


                Try

                    TrafficScheduleUserColumn = (From Entity In TrafficScheduleUserColumnList
                                                 Where Entity.ColumnName = AdvantageFramework.ProjectSchedule.GetUserColumnNameByFieldName(Fieldname)
                                                 Select Entity).SingleOrDefault

                Catch ex As Exception
                    TrafficScheduleUserColumn = Nothing
                End Try

                If TrafficScheduleUserColumn IsNot Nothing AndAlso CBool(TrafficScheduleUserColumn.ShowOnGrid) = True Then

                    DataGridViewControl_Details.Columns(Fieldname).Caption = TrafficScheduleUserColumn.HeaderText
                    DataGridViewControl_Details.Columns(Fieldname).VisibleIndex = VisibleIndex
                    DataGridViewControl_Details.Columns(Fieldname).Visible = True

                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewControl_Details.Columns(Fieldname).VisibleIndex = -1
                    DataGridViewControl_Details.Columns(Fieldname).Visible = False

                End If

            End If

        End Sub
        Private Sub HideOrShowGridColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewControl_Details.Columns(FieldName) IsNot Nothing Then

                If Visible Then

                    DataGridViewControl_Details.Columns(FieldName).VisibleIndex = VisibleIndex
                    DataGridViewControl_Details.Columns(FieldName).Visible = False

                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewControl_Details.Columns(FieldName).VisibleIndex = -1
                    DataGridViewControl_Details.Columns(FieldName).Visible = False

                End If

            End If

        End Sub
        Private Sub SaveJobInformationTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                JobTraffic.JobNumber = SearchableComboBoxJobInformation_Job.GetSelectedValue
                JobTraffic.JobComponentNumber = SearchableComboBoxJobInformation_Component.GetSelectedValue

            End If

        End Sub
        Private Sub SaveCommentsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                JobTraffic.TrafficComments = TextBoxComments_Comments.Text

            End If

        End Sub
        Private Sub SaveOtherInformationTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                JobTraffic.DateShipped = DateTimePickerOtherInformation_Shipped.ValueObject
                JobTraffic.DateDelivered = DateTimePickerOtherInformation_Delivered.ValueObject
                JobTraffic.ReceivedBy = TextBoxOtherInformation_ReceivedBy.Text
                JobTraffic.Reference = TextBoxOtherInformation_Reference.Text

            End If

        End Sub
        Private Sub SaveAssignmentsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                For Each ScheduleAssignment In DataGridViewAssignments_Assignments.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment)()

                    Select Case ScheduleAssignment.Key

                        Case AdvantageFramework.Agency.Settings.TR_TITLE1.ToString

                            JobTraffic.Assign1 = ScheduleAssignment.EmployeeCode

                        Case AdvantageFramework.Agency.Settings.TR_TITLE2.ToString

                            JobTraffic.Assign2 = ScheduleAssignment.EmployeeCode

                        Case AdvantageFramework.Agency.Settings.TR_TITLE3.ToString

                            JobTraffic.Assign3 = ScheduleAssignment.EmployeeCode

                        Case AdvantageFramework.Agency.Settings.TR_TITLE4.ToString

                            JobTraffic.Assign4 = ScheduleAssignment.EmployeeCode

                        Case AdvantageFramework.Agency.Settings.TR_TITLE5.ToString

                            JobTraffic.Assign5 = ScheduleAssignment.EmployeeCode

                    End Select

                Next

            End If

        End Sub
        Private Sub SaveRelatedJobsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                'auto save!

            End If

        End Sub
        Private Sub SaveTaskDetailsTab(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            If JobTraffic IsNot Nothing Then

                JobTraffic.TrafficCode = SearchableComboBoxTaskDetails_TrafficStatus.SelectedValue
                JobTraffic.CompletedDate = DateTimePickerTaskDetails_CompletedDate.ValueObject

                If NumericInputTaskDetails_GutComplete.EditValue <> 0 Then

                    JobTraffic.PercentComplete = CDec(NumericInputTaskDetails_GutComplete.EditValue)

                Else

                    JobTraffic.PercentComplete = Nothing

                End If

            End If

        End Sub
        Private Sub SetAutoFillJobInformation(ByVal AutoFillMode As Boolean)

            SearchableComboBoxJobInformation_Client.AutoFillMode = AutoFillMode
            SearchableComboBoxJobInformation_Division.AutoFillMode = AutoFillMode
            SearchableComboBoxJobInformation_Product.AutoFillMode = AutoFillMode
            SearchableComboBoxJobInformation_Job.AutoFillMode = AutoFillMode
            SearchableComboBoxJobInformation_Component.AutoFillMode = AutoFillMode
            SearchableComboBoxJobInformation_AccountExecutive.AutoFillMode = AutoFillMode

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim ProjectSchedule As Object = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ProjectSchedule = Me.FillObject(False)

                    If ProjectSchedule IsNot Nothing Then

                        'Saved = AdvantageFramework.Database.Procedures.ProjectSchedule.Update(DbContext, ProjectSchedule)

                    End If

                End Using

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Sub CheckSpelling()

            If TabControlControl_ProjectScheduleDetails.SelectedTab Is TabItemProjectScheduleDetails_CommentsTab Then

                TextBoxComments_Comments.CheckSpelling()

            End If

        End Sub
        Public Function Copy(ByRef JobTrafficID As Integer, ByVal CopyDates As Boolean) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                JobTraffic = FillObject(True)

                If JobTraffic IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Copied = AdvantageFramework.ProjectSchedule.CopyProjectSchedule(DbContext, _JobTrafficID, JobTraffic, CopyDates)

                    End Using

                End If

            Catch ex As Exception
                Copied = False
            Finally
                Copy = Copied
            End Try
        End Function
        Public Function Insert(ByRef JobTrafficID As Integer) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            Try

                JobTraffic = FillObject(True)

                If JobTraffic IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Inserted = AdvantageFramework.Database.Procedures.JobTraffic.Insert(DbContext, JobTraffic)

                    End Using

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function LoadControl(ByVal JobTrafficID As Integer, ByVal IsCopy As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            _JobTrafficID = JobTrafficID
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobTrafficID > 0 Then

                    JobTraffic = LoadJobTraffic()

                    If JobTraffic IsNot Nothing Then

                        _JobNumber = JobTraffic.JobNumber
                        _JobCompNumber = JobTraffic.JobComponentNumber

                        If _IsCopy = False Then

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTraffic.JobNumber)
                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                            SetAutoFillJobInformation(True)

                            LoadJobInformation(Job)

                            LoadComponentInformation(JobComponent)

                            SetAutoFillJobInformation(False)

                            SearchableComboBoxJobInformation_Client.Properties.ReadOnly = True
                            SearchableComboBoxJobInformation_Division.Properties.ReadOnly = True
                            SearchableComboBoxJobInformation_Product.Properties.ReadOnly = True
                            SearchableComboBoxJobInformation_Job.Properties.ReadOnly = True
                            SearchableComboBoxJobInformation_Component.Properties.ReadOnly = True
                            DataGridViewControl_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                            TabItemProjectScheduleDetails_RelatedJobsTab.Visible = True

                        Else

                            SetAutoFillJobInformation(True)

                            LoadJobLookup()

                            SetAutoFillJobInformation(False)

                            SearchableComboBoxJobInformation_Client.Properties.ReadOnly = False
                            SearchableComboBoxJobInformation_Division.Properties.ReadOnly = False
                            SearchableComboBoxJobInformation_Product.Properties.ReadOnly = False
                            SearchableComboBoxJobInformation_Job.Properties.ReadOnly = False
                            SearchableComboBoxJobInformation_Component.Properties.ReadOnly = False
                            DataGridViewControl_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                            TabItemProjectScheduleDetails_RelatedJobsTab.Visible = False

                        End If

                        LoadEntityDetails(Nothing)

                        LoadScheduleTasks()

                    Else

                        Loaded = False

                    End If

                Else

                    SetAutoFillJobInformation(True)

                    LoadJobLookup()

                    SetAutoFillJobInformation(False)

                    DataGridViewControl_Details.Visible = False
                    ExpandableSplitterControlControl_TopBottom.Visible = False
                    ExpandablePanelControl_General.Dock = Windows.Forms.DockStyle.Fill

                    TabItemProjectScheduleDetails_RelatedJobsTab.Visible = False

                    SearchableComboBoxJobInformation_Client.Properties.ReadOnly = False
                    SearchableComboBoxJobInformation_Division.Properties.ReadOnly = False
                    SearchableComboBoxJobInformation_Product.Properties.ReadOnly = False
                    SearchableComboBoxJobInformation_Job.Properties.ReadOnly = False
                    SearchableComboBoxJobInformation_Component.Properties.ReadOnly = False

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _HasApprovedEstimate = False

            'job information tab
            SearchableComboBoxJobInformation_Client.SelectedValue = Nothing
            SearchableComboBoxJobInformation_Division.SelectedValue = Nothing
            SearchableComboBoxJobInformation_Product.SelectedValue = Nothing
            SearchableComboBoxJobInformation_Job.SelectedValue = Nothing
            SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
            SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing

            SearchableComboBoxJobInformation_Client.RemoveAddedItemsFromDataSource()
            SearchableComboBoxJobInformation_Division.RemoveAddedItemsFromDataSource()
            SearchableComboBoxJobInformation_Product.RemoveAddedItemsFromDataSource()
            SearchableComboBoxJobInformation_Job.RemoveAddedItemsFromDataSource()
            SearchableComboBoxJobInformation_Component.RemoveAddedItemsFromDataSource()

            'comments tab
            TextBoxComments_Comments.Text = Nothing

            'other information tab
            DateTimePickerOtherInformation_Shipped.ValueObject = Nothing
            DateTimePickerOtherInformation_Delivered.ValueObject = Nothing
            TextBoxOtherInformation_ReceivedBy.Text = Nothing
            TextBoxOtherInformation_Reference.Text = Nothing

            'assignments tab
            For Each ScheduleAssignment In DataGridViewAssignments_Assignments.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment)()

                ScheduleAssignment.EmployeeCode = Nothing
                ScheduleAssignment.EmployeeName = Nothing

            Next

            DataGridViewAssignments_Assignments.CurrentView.RefreshData()

            'related jobs tab
            DataGridViewJobsThatFollow_Jobs.DataSource = Nothing
            DataGridViewJobsThatPrecede_AvailableJobs.DataSource = Nothing
            DataGridViewJobsThatPrecede_Jobs.DataSource = Nothing

            'task details tab
            RadioButtonControlTaskDetails_DueDate.Checked = False
            RadioButtonControlTaskDetails_StartDate.Checked = True
            DateTimePickerTaskDetails_StartDate.ValueObject = Nothing
            DateTimePickerTaskDetails_DueDate.ValueObject = Nothing
            DateTimePickerTaskDetails_CompletedDate.ValueObject = Nothing
            SearchableComboBoxTaskDetails_TrafficStatus.SelectedValue = Nothing

            'grid
            DataGridViewControl_Details.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub PickEmployeesForTask()

            'objects
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing

            If DataGridViewControl_Details.HasOnlyOneSelectedRow Then

                Try

                    ScheduleTask = DataGridViewControl_Details.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ScheduleTask = Nothing
                End Try

                If ScheduleTask IsNot Nothing Then

                    If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEmployeesEditDialog.ShowFormDialog(ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber) = Windows.Forms.DialogResult.OK Then



                    End If

                End If

            End If

        End Sub
        Public Function DeleteSelectedTasks() As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If DataGridViewControl_Details.HasASelectedRow Then

                    DataGridViewControl_Details.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each ScheduleTask In DataGridViewControl_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask).ToList

                                    If ScheduleTask IsNot Nothing AndAlso ScheduleTask.HasAssignment <> 1 Then

                                        If AdvantageFramework.Database.Procedures.JobComponentTask.Delete(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber) Then

                                            Deleted = True

                                            DataGridViewControl_Details.CurrentView.DeleteFromDataSource(ScheduleTask)

                                        End If

                                    End If

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            Catch ex As Exception

            End Try

            DeleteSelectedTasks = Deleted

        End Function
        Public Function AddTasks() As Boolean

            AddTasks = LoadTaskSelectionDialog(ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes.Tasks)

        End Function
        Public Function AddTasksByTemplate() As Boolean

            AddTasksByTemplate = LoadTaskSelectionDialog(ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes.Templates)

        End Function
        Public Function AddTasksByEstimate() As Boolean

            AddTasksByEstimate = LoadTaskSelectionDialog(ProjectManagement.Presentation.ProjectScheduleTaskSelectionDialog.FormTypes.Estimates)

        End Function
        Public Function ApplyTeam(ByVal ByFunction As Boolean) As Boolean

            'objects
            Dim Applied As Boolean = False

            Try

                If _JobNumber > 0 AndAlso _JobCompNumber > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Applied = AdvantageFramework.ProjectSchedule.ApplyTeam(DbContext, ByFunction, _JobNumber, _JobCompNumber)

                    End Using

                End If

            Catch ex As Exception
                Applied = False
            Finally
                ApplyTeam = Applied
            End Try

        End Function
        Public Function MarkTempComplete() As Boolean

            'objects
            Dim Marked As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                If _JobNumber > 0 AndAlso _JobCompNumber > 0 Then

                    AdvantageFramework.ProjectSchedule.MarkTempComplete(_Session, _JobNumber, _JobCompNumber, ErrorMessage)

                    If String.IsNullOrEmpty(ErrorMessage) = False Then

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

                    End If

                End If

            Catch ex As Exception
                Marked = False
            Finally
                MarkTempComplete = Marked
            End Try

        End Function
        Public Function FindAndReplaceInTasks() As Boolean

            'objects
            Dim FindAndReplaced As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                If _JobNumber > 0 AndAlso _JobCompNumber > 0 Then

                    If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleFindAndReplaceDialog.ShowFormDialog({_JobTrafficID}) = Windows.Forms.DialogResult.OK Then



                    End If

                End If

            Catch ex As Exception
                FindAndReplaced = False
            Finally
                FindAndReplaceInTasks = FindAndReplaced
            End Try

        End Function
        Public Function MoveTask(ByVal MoveUp As Boolean) As Boolean

            'objects
            Dim Moved As Boolean = False
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing

            Try

                If DataGridViewControl_Details.HasOnlyOneSelectedRow Then

                    Try

                        ScheduleTask = DirectCast(DataGridViewControl_Details.GetFirstSelectedRowDataBoundItem, AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

                    Catch ex As Exception
                        ScheduleTask = Nothing
                    End Try

                    If ScheduleTask IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Moved = AdvantageFramework.ProjectSchedule.MoveTask(DbContext, MoveUp, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                        End Using

                    End If

                End If

            Catch ex As Exception
                Moved = False
            Finally
                MoveTask = Moved
            End Try

        End Function
        Public Sub OpenSettings()

            If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleSettingsDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                ModifyColumnVisibility()

            End If

        End Sub
        Public Sub OpenTaskDetailDialog()

            'objects
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing

            Try

                If _JobNumber > 0 AndAlso _JobCompNumber > 0 Then

                    If DataGridViewControl_Details.HasOnlyOneSelectedRow Then

                        ScheduleTask = DataGridViewControl_Details.GetFirstSelectedRowDataBoundItem

                        If ScheduleTask IsNot Nothing Then

                            If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEditDialog.ShowFormDialog(_JobNumber, _JobCompNumber, ScheduleTask.SequenceNumber) = Windows.Forms.DialogResult.OK Then



                            End If

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function ClearEmployeeAssignments() As Boolean

            'objects
            Dim Cleared As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                If _JobNumber > 0 AndAlso _JobCompNumber > 0 Then

                    If Me.HasEmployeesAssigned Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to clear all assignments?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Cleared = AdvantageFramework.ProjectSchedule.ClearEmployeeAssignments(Nothing, _JobNumber, _JobCompNumber)

                            End Using

                        End If

                    Else

                        ErrorMessage = "There are no employees assigned to project schedule tasks."

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem clearing employee assignments. Please contact software support."
                Cleared = False
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            ClearEmployeeAssignments = Cleared

        End Function
        Public Function CalculateDueDates() As Boolean

            'objects
            Dim ContinueCalculate As Boolean = True
            Dim Calculated As Boolean = False
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
            Dim Predecessor As Integer = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ResultType As Short = Nothing
            Dim ReturnValue As Integer = Nothing

            Try

                If DataGridViewControl_Details.HasRows Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobCompNumber).Any Then

                            If AdvantageFramework.Navigation.ShowMessageBox("This job is a predecessor. All jobs associated with this job will be calculated. Are you sure you want to calculate?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                                ContinueCalculate = False

                            End If

                        End If

                        If ContinueCalculate Then

                            JobTraffic = Me.FillObject(False)

                            If JobTraffic IsNot Nothing Then

                                Predecessor = JobTraffic.ScheduleCalculation.GetValueOrDefault(-1)

                                If Predecessor < 0 Then

                                    For Each TrafficScheduleUserColumnComplexType In AdvantageFramework.Database.Procedures.TrafficScheduleUserColumnComplexType.Load(DbContext, _Session.User.EmployeeCode, False, False, False).ToList

                                        If TrafficScheduleUserColumnComplexType.ColumnName = "colPREDECESSORS_TEXT" AndAlso CBool(TrafficScheduleUserColumnComplexType.ShowOnGrid) = True Then

                                            Predecessor = 1

                                        End If

                                    Next

                                End If

                                If Predecessor = 1 Then

                                    AdvantageFramework.ProjectSchedule.CalculateDueDatesPredecessor(DbContext, _JobNumber, _JobCompNumber, 1, ReturnValue)

                                Else

                                    AdvantageFramework.ProjectSchedule.CalculateDueDates(DbContext, _JobNumber, _JobCompNumber, 0, ReturnValue)

                                End If

                                If ReturnValue < 0 Then

                                    Select Case ReturnValue

                                        Case -1

                                            ErrorMessage = "Could not get start date."

                                        Case -2

                                            ErrorMessage = "Schedule is not feasible for calculation."

                                    End Select

                                Else

                                    Calculated = True

                                End If

                                If Calculated Then

                                    If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobCompNumber).Any Then

                                        AdvantageFramework.ProjectSchedule.CalculateJobPredecessor(DbContext, _JobNumber, _JobCompNumber, 0, _Session.User.EmployeeCode, ReturnValue)

                                    End If

                                    AdvantageFramework.ProjectSchedule.UpdateTaskAlertsDueDate(DbContext, _JobNumber, _JobCompNumber)

                                End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Calculated = False
                ErrorMessage = "There was a problem calculating due dates. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            CalculateDueDates = Calculated

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub ProjectScheduleControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_ProjectScheduleDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_ProjectScheduleDetails.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                If AdvantageFramework.WinForm.Presentation.Controls.GetFormAction(Me.FindForm) = FormActions.None Then

                    AdvantageFramework.WinForm.Presentation.Controls.SetSuspendedForLoading(Me, True)

                    LoadEntityDetails(e.NewTab)

                    AdvantageFramework.WinForm.Presentation.Controls.SetSuspendedForLoading(Me, False)

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_Details.CellValueChangedEvent

            'objects
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
            Dim TaskDescription As String = ""
            Dim TaskCode As String = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact = Nothing
            Dim CurrentEmployeeCodes As String() = Nothing
            Dim NewEmployeeCodes As String() = Nothing
            Dim CurrentContactIDs As Integer() = Nothing
            Dim NewContactIDs As Integer() = Nothing
            Dim NewContactCodes As String() = Nothing
            Dim ClientCode As String = Nothing

            Try

                ScheduleTask = DataGridViewControl_Details.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                ScheduleTask = Nothing
            End Try

            If ScheduleTask IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString Then

                    If e.Value IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, e.Value)

                            If Task IsNot Nothing Then

                                TaskDescription = Task.Description

                            End If

                        End Using

                    End If

                    ScheduleTask.TaskDescription = TaskDescription
                    DataGridViewControl_Details.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString Then

                    If e.Value IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                Task = (From Entity In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                        Where Entity.Description = e.Value
                                        Select Entity).FirstOrDefault

                            Catch ex As Exception
                                Task = Nothing
                            End Try

                            If Task IsNot Nothing Then

                                TaskCode = Task.Code

                            End If

                        End Using

                    End If

                    ScheduleTask.TaskCode = TaskCode
                    DataGridViewControl_Details.CurrentView.RefreshData()

                ElseIf e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EmployeeCode.ToString Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            CurrentEmployeeCodes = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)
                                                    Select Entity.EmployeeCode).ToArray

                        Catch ex As Exception
                            CurrentEmployeeCodes = {""}
                        End Try

                        Try

                            NewEmployeeCodes = e.Value.ToString.Replace(" ", "").Split(",")

                        Catch ex As Exception
                            NewEmployeeCodes = {""}
                        End Try

                        For Each NewEmployeeCode In NewEmployeeCodes

                            If CurrentEmployeeCodes.Contains(NewEmployeeCode) = False Then

                                If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, NewEmployeeCode) IsNot Nothing Then

                                    JobComponentTaskEmployee = New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                                    JobComponentTaskEmployee.DbContext = DbContext
                                    JobComponentTaskEmployee.EmployeeCode = NewEmployeeCode
                                    JobComponentTaskEmployee.JobNumber = ScheduleTask.JobNumber
                                    JobComponentTaskEmployee.JobComponentNumber = ScheduleTask.JobComponentNumber
                                    JobComponentTaskEmployee.SequenceNumber = ScheduleTask.SequenceNumber
                                    JobComponentTaskEmployee.Hours = ScheduleTask.JobHours

                                    AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, JobComponentTaskEmployee)

                                End If

                            End If

                            JobComponentTaskEmployee = Nothing

                        Next

                        For Each CurrentEmployeeCode In CurrentEmployeeCodes

                            If NewEmployeeCodes.Contains(CurrentEmployeeCode) = False Then

                                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber, CurrentEmployeeCode)

                                If JobComponentTaskEmployee IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, JobComponentTaskEmployee)

                                End If

                            End If

                            JobComponentTaskEmployee = Nothing

                        Next

                    End Using

                ElseIf e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ClientContact.ToString Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            CurrentContactIDs = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)
                                                 Select Entity.ClientContactID).ToArray

                        Catch ex As Exception
                            CurrentContactIDs = {-1}
                        End Try

                        Try

                            NewContactCodes = e.Value.ToString.Replace(" ", "").Split(",")

                        Catch ex As Exception
                            NewContactCodes = {""}
                        End Try

                        ClientCode = SearchableComboBoxJobInformation_Client.GetSelectedValue

                        Try

                            NewContactIDs = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode)
                                             Where NewContactCodes.Contains(Entity.ContactCode)
                                             Select Entity.ContactID).ToArray

                        Catch ex As Exception
                            NewContactIDs = {-1}
                        End Try

                        For Each NewContactID In NewContactIDs

                            If CurrentContactIDs.Contains(NewContactID) = False Then

                                JobComponentTaskClientContact = New AdvantageFramework.Database.Entities.JobComponentTaskClientContact
                                JobComponentTaskClientContact.DbContext = DbContext
                                JobComponentTaskClientContact.JobNumber = ScheduleTask.JobNumber
                                JobComponentTaskClientContact.JobComponentNumber = ScheduleTask.JobComponentNumber
                                JobComponentTaskClientContact.SequenceNumber = ScheduleTask.SequenceNumber
                                JobComponentTaskClientContact.ClientContactID = NewContactID

                                AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Insert(DbContext, JobComponentTaskClientContact)

                            End If

                            JobComponentTaskClientContact = Nothing

                        Next

                        For Each CurrentContactID In CurrentContactIDs

                            If NewContactIDs.Contains(CurrentContactID) = False Then

                                Try

                                    JobComponentTaskClientContact = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)
                                                                     Where Entity.ClientContactID = CurrentContactID
                                                                     Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    JobComponentTaskClientContact = Nothing
                                End Try

                                If JobComponentTaskClientContact IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Delete(DbContext, JobComponentTaskClientContact)

                                End If

                            End If

                            JobComponentTaskClientContact = Nothing

                        Next

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_Details_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewControl_Details.CustomDrawCellEvent

            'objects
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim BackColor As System.Drawing.Color = Nothing
            Dim GridCellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = Nothing

            If e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString Then

                Try

                    ScheduleTask = DataGridViewControl_Details.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    ScheduleTask = Nothing
                End Try

                If ScheduleTask IsNot Nothing Then

                    If ScheduleTask.JobRevisedDate.HasValue = True Then

                        If ScheduleTask.JobCompletedDate.HasValue = False Then

                            If ScheduleTask.JobRevisedDate.Value > System.DateTime.Today AndAlso ScheduleTask.JobRevisedDate.Value < System.DateTime.Today.AddDays(8) Then

                                e.Appearance.BackColor = Drawing.Color.Yellow
                                e.Appearance.Options.UseBackColor = True

                            End If

                            If ScheduleTask.JobRevisedDate.Value.DayOfWeek = DayOfWeek.Saturday OrElse ScheduleTask.JobRevisedDate.Value.DayOfWeek = DayOfWeek.Sunday Then

                                e.Appearance.BackColor = Drawing.Color.LightGray
                                e.Appearance.Options.UseBackColor = True

                            End If

                            If ScheduleTask.JobRevisedDate.Value = System.DateTime.Today Then

                                e.Appearance.BackColor = Drawing.Color.Orange
                                e.Appearance.Options.UseBackColor = True

                            End If

                            If ScheduleTask.JobRevisedDate.Value < System.DateTime.Today Then

                                e.Appearance.BackColor = Drawing.Color.LightPink
                                e.Appearance.Options.UseBackColor = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Details.DataSourceChangedEvent

            If DataGridViewControl_Details.Columns.Count > 0 Then

                If DataGridViewControl_Details.Columns(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString) IsNot Nothing Then

                    If TypeOf DataGridViewControl_Details.Columns(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString).ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        DirectCast(DataGridViewControl_Details.Columns(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DisplayMember = "Code"

                    End If

                End If

                ModifyColumnVisibility()

            End If

            DataGridViewControl_Details.CurrentView.GridControl.ToolTipController = ToolTipControllerControl_ToolTips

        End Sub
        Private Sub DataGridViewControl_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_Details.QueryPopupNeedDatasourceEvent

            'objects
            Dim ClientCode As String = Nothing

            If FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ClientContact.ToString Then

                ClientCode = SearchableComboBoxJobInformation_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OverrideDefaultDatasource = True

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext).Include("Client")
                                  Where Entity.ClientCode = ClientCode AndAlso
                                        Entity.ScheduleUser = 1
                                  Select Entity).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewControl_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Details.SelectionChangedEvent

            RaiseEvent SelectedDetailChangedEvent()

        End Sub
        Private Sub DataGridViewControl_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewControl_Details.ShowingEditorEvent

            If _IsCopy Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewControl_Details_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Details.ShownEditorEvent

            If DataGridViewControl_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString Then

                If DataGridViewControl_Details.CurrentView.ActiveEditor IsNot Nothing Then

                    AddHandler DataGridViewControl_Details.CurrentView.ActiveEditor.ToolTipController.GetActiveObjectInfo, AddressOf ToolTipControllerControl_ToolTips_GetActiveObjectInfo

                End If

            End If

        End Sub
        Private Sub ToolTipControllerControl_ToolTips_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipControllerControl_ToolTips.GetActiveObjectInfo

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
            Dim ToolTipText As String = Nothing
            Dim RowHandle As Integer = -1

            If e.Info Is Nothing Then

                If e.SelectedControl Is DataGridViewControl_Details.CurrentView.GridControl Then

                    GridHitInfo = DataGridViewControl_Details.CurrentView.CalcHitInfo(e.ControlMousePosition)

                    If GridHitInfo IsNot Nothing AndAlso GridHitInfo.Column IsNot Nothing Then

                        If GridHitInfo.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString Then

                            RowHandle = GridHitInfo.RowHandle

                        End If

                    End If

                ElseIf TypeOf e.SelectedControl Is DevExpress.XtraEditors.DateEdit Then

                    RowHandle = DataGridViewControl_Details.CurrentView.FocusedRowHandle

                End If

                If RowHandle >= 0 Then

                    Try

                        ScheduleTask = DataGridViewControl_Details.CurrentView.GetRow(RowHandle)

                    Catch ex As Exception
                        ScheduleTask = Nothing
                    End Try

                    If ScheduleTask IsNot Nothing Then

                        If ScheduleTask.JobRevisedDate.HasValue = True Then

                            If ScheduleTask.JobCompletedDate.HasValue = False Then

                                If ScheduleTask.JobRevisedDate.Value > System.DateTime.Today AndAlso ScheduleTask.JobRevisedDate.Value < System.DateTime.Today.AddDays(8) Then

                                    ToolTipText = "Task is due this week!"

                                End If

                                If ScheduleTask.JobRevisedDate.Value.DayOfWeek = DayOfWeek.Saturday OrElse ScheduleTask.JobRevisedDate.Value.DayOfWeek = DayOfWeek.Sunday Then

                                    ToolTipText = "Due date is on a weekend!"

                                End If

                                If ScheduleTask.JobRevisedDate.Value = System.DateTime.Today Then

                                    ToolTipText = "Task is due today!"

                                End If

                                If ScheduleTask.JobRevisedDate.Value < System.DateTime.Today Then

                                    ToolTipText = "Task is overdue!"

                                End If

                                If String.IsNullOrEmpty(ToolTipText) = False Then

                                    e.Info = New DevExpress.Utils.ToolTipControlInfo(RowHandle.ToString & " - " & "JobRevisedDate", ToolTipText)
                                    e.Info.ImmediateToolTip = True

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub

#Region "   Related Jobs Tab "

        Private Sub DataGridViewJobsThatPrecede_AvailableJobs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewJobsThatPrecede_AvailableJobs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewJobsThatPrecede_Jobs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewJobsThatPrecede_Jobs.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonRightSection_AddJob_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddJob.Click

            'objects
            Dim JobTrafficPredecessors As AdvantageFramework.Database.Entities.JobTrafficPredecessors = Nothing

            If DataGridViewJobsThatPrecede_AvailableJobs.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedRowHandle In DataGridViewJobsThatPrecede_AvailableJobs.CurrentView.GetSelectedRows

                        JobTrafficPredecessors = New AdvantageFramework.Database.Entities.JobTrafficPredecessors
                        JobTrafficPredecessors.DbContext = DbContext
                        JobTrafficPredecessors.JobNumber = _JobNumber
                        JobTrafficPredecessors.JobComponentNumber = _JobCompNumber
                        JobTrafficPredecessors.JobPredecessor = CInt(DataGridViewJobsThatPrecede_AvailableJobs.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobNumber.ToString))
                        JobTrafficPredecessors.JobComponentPredecessor = CShort(DataGridViewJobsThatPrecede_AvailableJobs.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobComponentNumber.ToString))

                        AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Insert(DbContext, JobTrafficPredecessors)

                    Next

                End Using

                LoadRelatedJobsTab()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveJob_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveJob.Click

            'objects
            Dim JobTrafficPredecessors As AdvantageFramework.Database.Entities.JobTrafficPredecessors = Nothing
            Dim JobPredecessorNumber As Integer = Nothing
            Dim JobComponentPredecessorNumber As Short = Nothing

            If DataGridViewJobsThatPrecede_Jobs.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedRowHandle In DataGridViewJobsThatPrecede_Jobs.CurrentView.GetSelectedRows

                        JobPredecessorNumber = CInt(DataGridViewJobsThatPrecede_Jobs.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobNumber.ToString))
                        JobComponentPredecessorNumber = CShort(DataGridViewJobsThatPrecede_Jobs.CurrentView.GetRowCellValue(SelectedRowHandle, AdvantageFramework.Database.Views.JobComponentView.Properties.JobComponentNumber.ToString))

                        Try

                            JobTrafficPredecessors = (From Entity In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobCompNumber)
                                                      Where Entity.JobPredecessor = JobPredecessorNumber AndAlso
                                                            Entity.JobComponentPredecessor = JobComponentPredecessorNumber
                                                      Select Entity).SingleOrDefault

                        Catch ex As Exception
                            JobTrafficPredecessors = Nothing
                        End Try

                        If JobTrafficPredecessors IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(DbContext, JobTrafficPredecessors)

                        End If

                    Next

                End Using

                LoadRelatedJobsTab()

            End If

        End Sub

#End Region

#Region "   Job Information Tab "

        Private Sub SearchableComboBoxJobInformation_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxJobInformation_Client.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing

            If _Session IsNot Nothing Then

                If SearchableComboBoxJobInformation_Client.AutoFillMode = False Then

                    SetAutoFillJobInformation(True)

                    SearchableComboBoxJobInformation_Division.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Product.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Job.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing

                    LoadDivisionLookup()

                    If SearchableComboBoxJobInformation_Division.SelectSingleItemDataSource() Then

                        LoadProductLookup()

                        SearchableComboBoxJobInformation_Product.SelectSingleItemDataSource()

                    Else

                        SearchableComboBoxJobInformation_Product.SelectedValue = Nothing

                    End If

                    LoadJobLookup()

                    If SearchableComboBoxJobInformation_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxJobInformation_Component.SelectSingleItemDataSource() Then

                            LoadJobComponentInformation()

                        End If

                    End If

                    SetAutoFillJobInformation(False)

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxJobInformation_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxJobInformation_Division.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If _Session IsNot Nothing Then

                If SearchableComboBoxJobInformation_Division.AutoFillMode = False Then

                    SetAutoFillJobInformation(True)

                    SearchableComboBoxJobInformation_Product.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Job.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing

                    LoadProductLookup()

                    SearchableComboBoxJobInformation_Product.SelectSingleItemDataSource()

                    LoadJobLookup()

                    If SearchableComboBoxJobInformation_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxJobInformation_Component.SelectSingleItemDataSource() Then

                            LoadJobComponentInformation()

                        End If

                    End If

                    SetAutoFillJobInformation(False)

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxJobInformation_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxJobInformation_Product.EditValueChanged

            If _Session IsNot Nothing Then

                If SearchableComboBoxJobInformation_Product.AutoFillMode = False Then

                    SetAutoFillJobInformation(True)

                    SearchableComboBoxJobInformation_Job.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing

                    LoadJobLookup()

                    If SearchableComboBoxJobInformation_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxJobInformation_Component.SelectSingleItemDataSource() Then

                            LoadJobComponentInformation()

                        End If

                    End If

                    SetAutoFillJobInformation(False)

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxJobInformation_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxJobInformation_Job.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            If _Session IsNot Nothing Then

                If SearchableComboBoxJobInformation_Job.AutoFillMode = False Then

                    SetAutoFillJobInformation(True)

                    If SearchableComboBoxJobInformation_Job.HasASelectedValue Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            JobNumber = SearchableComboBoxJobInformation_Job.GetSelectedValue

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                            If Job IsNot Nothing Then

                                LoadJobInformation(Job)

                            End If

                        End Using

                    End If

                    SearchableComboBoxJobInformation_Component.SelectedValue = Nothing
                    SearchableComboBoxJobInformation_AccountExecutive.SelectedValue = Nothing

                    LoadJobComponentLookup()

                    If SearchableComboBoxJobInformation_Component.SelectSingleItemDataSource() Then

                        LoadJobComponentInformation()

                    End If

                    SetAutoFillJobInformation(False)

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxJobInformation_Component_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxJobInformation_Component.EditValueChanged

            'objects
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing

            If _Session IsNot Nothing Then

                If SearchableComboBoxJobInformation_Component.AutoFillMode = False Then

                    SetAutoFillJobInformation(True)

                    LoadJobComponentInformation()

                    SetAutoFillJobInformation(False)

                    EnableOrDisableActions()

                End If

            End If

        End Sub

#End Region

#Region "   Assignments Tab "

        Private Sub DataGridViewAssignments_Assignments_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewAssignments_Assignments.DataSourceChangedEvent

            If DataGridViewAssignments_Assignments.Columns.Count > 0 Then

                If DataGridViewAssignments_Assignments.Columns(AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment.Properties.Title.ToString) IsNot Nothing Then

                    DataGridViewAssignments_Assignments.Columns(AdvantageFramework.ProjectSchedule.Classes.ScheduleAssignment.Properties.Title.ToString).OptionsColumn.AllowFocus = False

                End If

            End If

        End Sub


#End Region

#End Region

#End Region

    End Class

End Namespace
