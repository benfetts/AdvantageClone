Namespace WinForm.Presentation.Controls

    Public Class JobComponentTaskControl

        Public Event SelectedTabChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _LoadingData As Boolean = False
        Private _ShowQuotedHours As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property IsDetailsTabSelected As Boolean
            Get
                IsDetailsTabSelected = If(TabControlControl_TaskDetails.SelectedTab Is TabItemTaskDetails_DetailsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsSettingsTabSelected As Boolean
            Get
                IsSettingsTabSelected = If(TabControlControl_TaskDetails.SelectedTab Is TabItemTaskDetails_SettingsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsEmployeesTabSelected As Boolean
            Get
                IsEmployeesTabSelected = If(TabControlControl_TaskDetails.SelectedTab Is TabItemTaskDetails_EmployeesTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsClientContactsTabSelected As Boolean
            Get
                IsClientContactsTabSelected = If(TabControlControl_TaskDetails.SelectedTab Is TabItemTaskDetails_ClientContactsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsCommentsTabSelected As Boolean
            Get
                IsCommentsTabSelected = If(TabControlControl_TaskDetails.SelectedTab Is TabItemTaskDetails_CommentsTab, True, False)
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

                                'general info
                                SearchableComboBoxGeneralInfo_Client.DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                                  Where Entity.IsActive = 1
                                                                                  Select Entity

                                SearchableComboBoxGeneralInfo_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                               Where Entity.IsOpen = 1
                                                                               Select Entity
                                                                               Order By Entity.Number Descending

                                SearchableComboBoxGeneralInfo_AccountExecutive.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                                SearchableComboBoxGeneralInfo_JobStatus.DataSource = AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)

                                'details tab
                                SearchableComboBoxDetails_Phase.DataSource = AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                SearchableComboBoxDetails_Task.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                SearchableComboBoxDetails_Task.Properties.DisplayMember = SearchableComboBoxDetails_Task.Properties.ValueMember
                                SearchableComboBoxDetails_TaskStatus.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                                                                   Select [Code] = Entity.Code,
                                                                                          [Description] = Entity.Description).ToList

                                'settings tab
                                SearchableComboBoxSettings_EstimateFunction.DataSource = From Entity In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                                                                         Where Entity.Type = "E"
                                                                                         Select Entity

                                SearchableComboBoxDetails_Phase.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.PhaseID)
                                SearchableComboBoxDetails_Task.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.TaskCode)
                                SearchableComboBoxDetails_TaskStatus.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.StatusCode)
                                DateTimePickerDetails_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.StartDate)
                                DateTimePickerDetails_DueDate.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.DueDate)
                                DateTimePickerDetails_CompletedDate.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.CompletedDate)
                                TextBoxDetails_TaskDescription.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.Description)
                                TextBoxTaskComments_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.Comment)
                                TextBoxDueDateComments_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.DueDateComment)
                                TextBoxRevisedDueDateComments_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.OriginalDueDateComment)
                                DateTimePickerDetails_TempComplete.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.TempCompletionDate)
                                TextBoxDetails_TimeDue.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.DueTime)

                                NumericInputSettings_Order.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.OrderNumber)
                                NumericInputSettings_DaysDuration.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.Days)
                                NumericInputSettings_DefaultHoursAllowed.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.Hours)
                                SearchableComboBoxSettings_EstimateFunction.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.FuctionCode)
                                DateTimePickerSettings_OriginalDueDate.SetPropertySettings(AdvantageFramework.Database.Entities.JobComponentTask.Properties.OriginalDueDate)

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.JobComponentTask

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            Try

                If IsNew Then

                    JobComponentTask = New AdvantageFramework.Database.Entities.JobComponentTask

                    LoadEntity(JobComponentTask)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber)

                        If JobComponentTask IsNot Nothing Then

                            LoadEntity(JobComponentTask)

                        End If

                    End Using

                End If

            Catch ex As Exception
                JobComponentTask = Nothing
            End Try

            FillObject = JobComponentTask

        End Function
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_TaskDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_TaskDetails.SelectedTab

                End If

                If TabItem.Tag = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber)

                    End Using

                    If JobComponentTask IsNot Nothing Then

                        If TabItem Is TabItemTaskDetails_DetailsTab Then

                            LoadDetailsTab(JobComponentTask)

                        End If

                        If TabItem Is TabItemTaskDetails_SettingsTab Then

                            LoadSettingsTab(JobComponentTask)

                        End If

                        If TabItem Is TabItemTaskDetails_EmployeesTab Then

                            LoadEmployeesTab(JobComponentTask)

                        End If

                        If TabItem Is TabItemTaskDetails_ClientContactsTab Then

                            LoadClientContactsTab(JobComponentTask)

                        End If

                        If TabItem Is TabItemTaskDetails_CommentsTab Then

                            LoadCommentsTab(JobComponentTask)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LoadDetailsTab(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            If JobComponentTask IsNot Nothing Then

                SearchableComboBoxDetails_Phase.SelectedValue = JobComponentTask.PhaseID
                SearchableComboBoxDetails_Task.SelectedValue = JobComponentTask.TaskCode
                TextBoxDetails_TaskDescription.Text = JobComponentTask.Description
                SearchableComboBoxDetails_TaskStatus.SelectedValue = JobComponentTask.StatusCode
                DateTimePickerDetails_StartDate.ValueObject = JobComponentTask.StartDate
                DateTimePickerDetails_DueDate.ValueObject = JobComponentTask.DueDate
                DateTimePickerDetails_CompletedDate.ValueObject = JobComponentTask.CompletedDate
                DateTimePickerDetails_TempComplete.ValueObject = JobComponentTask.TempCompletionDate
                TextBoxDetails_TimeDue.Text = JobComponentTask.DueTime

                TextBoxTaskComments_Comments.Text = JobComponentTask.Comment
                TextBoxDueDateComments_Comments.Text = JobComponentTask.DueDateComment
                TextBoxRevisedDueDateComments_Comments.Text = JobComponentTask.OriginalDueDateComment

                TabItemTaskDetails_DetailsTab.Tag = True

            End If

        End Sub
        Private Sub LoadSettingsTab(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            If JobComponentTask IsNot Nothing Then

                NumericInputSettings_Order.EditValue = JobComponentTask.OrderNumber
                NumericInputSettings_DaysDuration.EditValue = JobComponentTask.Days
                NumericInputSettings_DefaultHoursAllowed.EditValue = JobComponentTask.Hours
                CheckBoxSettings_Milestone.Checked = Convert.ToBoolean(JobComponentTask.IsMilestone.GetValueOrDefault(0))
                SearchableComboBoxSettings_EstimateFunction.SelectedValue = JobComponentTask.FuctionCode
                DateTimePickerSettings_OriginalDueDate.ValueObject = JobComponentTask.OriginalDueDate
                CheckBoxSettings_Locked.Checked = Convert.ToBoolean(JobComponentTask.IsDueDateLocked.GetValueOrDefault(0))

                TabItemTaskDetails_SettingsTab.Tag = True

            End If

        End Sub
        Private Sub LoadEmployeesTab(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            If JobComponentTask IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewEmployees_Employees.DataSource = (From Entity In AdvantageFramework.ProjectSchedule.LoadTaskEmployees(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber, JobComponentTask.FuctionCode)
                                                                  Order By Entity.EmployeeCode
                                                                  Select Entity).ToList

                End Using

                DataGridViewEmployees_Employees.CurrentView.BestFitColumns()

                TabItemTaskDetails_EmployeesTab.Tag = True

            End If

        End Sub
        Private Sub LoadClientContactsTab(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            'objects
            Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
            Dim SelectedClientContactCodes As Generic.List(Of String) = Nothing
            Dim ClientCode As String = Nothing

            If JobComponentTask IsNot Nothing Then

                ClientCode = CStr(SearchableComboBoxGeneralInfo_Client.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode)
                                      Where Entity.ScheduleUser = 1
                                      Select Entity).ToList

                    SelectedClientContactCodes = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(DbContext, JobComponentTask.JobNumber, JobComponentTask.JobComponentNumber, JobComponentTask.SequenceNumber).Include("ClientContact")
                                                  Select Entity.ClientContact.ContactCode).ToList

                End Using

                Try

                    MultiSelectControlClientContacts_ClientContacts.ClearControl()
                    MultiSelectControlClientContacts_ClientContacts.LoadControl(ClientContacts, SelectedClientContactCodes)

                Catch ex As Exception

                End Try

                TabItemTaskDetails_ClientContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadCommentsTab(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            If JobComponentTask IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)



                End Using

                TabItemTaskDetails_ClientContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask)

            If SearchableComboBoxDetails_Phase.HasASelectedValue Then

                JobComponentTask.PhaseID = SearchableComboBoxDetails_Phase.GetSelectedValue

            Else

                JobComponentTask.PhaseID = Nothing

            End If



        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Sub LoadDivisionLookup()

            'objects
            Dim ClientCode As String = Nothing

            If SearchableComboBoxGeneralInfo_Client.HasASelectedValue Then

                ClientCode = CStr(SearchableComboBoxGeneralInfo_Client.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxGeneralInfo_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                            Where Entity.ClientCode = ClientCode AndAlso
                                                                                     Entity.IsActive = 1
                                                                            Select Entity

                    End Using

                End Using

            Else

                SearchableComboBoxGeneralInfo_Division.DataSource = Nothing
                SearchableComboBoxGeneralInfo_Division.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadProductLookup()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If SearchableComboBoxGeneralInfo_Client.HasASelectedValue AndAlso SearchableComboBoxGeneralInfo_Division.HasASelectedValue Then

                ClientCode = CStr(SearchableComboBoxGeneralInfo_Client.GetSelectedValue)
                DivisionCode = CStr(SearchableComboBoxGeneralInfo_Division.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxGeneralInfo_Product.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, True)
                                                                            Where Entity.ClientCode = ClientCode AndAlso
                                                                                  Entity.DivisionCode = DivisionCode
                                                                            Select Entity).ToList

                    End Using

                End Using

            Else

                SearchableComboBoxGeneralInfo_Product.DataSource = Nothing
                SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadJobLookup()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If SearchableComboBoxGeneralInfo_Client.HasASelectedValue Then

                        ClientCode = CStr(SearchableComboBoxGeneralInfo_Client.GetSelectedValue)

                        If SearchableComboBoxGeneralInfo_Division.HasASelectedValue Then

                            DivisionCode = CStr(SearchableComboBoxGeneralInfo_Division.GetSelectedValue)

                            If SearchableComboBoxGeneralInfo_Product.HasASelectedValue Then

                                ProductCode = CStr(SearchableComboBoxGeneralInfo_Product.GetSelectedValue)

                                SearchableComboBoxGeneralInfo_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                               Where Entity.ClientCode = ClientCode AndAlso
                                                                                        Entity.DivisionCode = DivisionCode AndAlso
                                                                                        Entity.ProductCode = ProductCode AndAlso
                                                                                        Entity.IsOpen = 1
                                                                               Select Entity
                                                                               Order By Entity.Number Descending

                            Else

                                SearchableComboBoxGeneralInfo_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                               Where Entity.ClientCode = ClientCode AndAlso
                                                                                        Entity.DivisionCode = DivisionCode AndAlso
                                                                                        Entity.IsOpen = 1
                                                                               Select Entity
                                                                               Order By Entity.Number Descending
                            End If

                        Else

                            SearchableComboBoxGeneralInfo_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                           Where Entity.ClientCode = ClientCode AndAlso
                                                                                    Entity.IsOpen = 1
                                                                           Select Entity
                                                                           Order By Entity.Number Descending

                        End If

                    Else

                        SearchableComboBoxGeneralInfo_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                       Where Entity.IsOpen = 1
                                                                       Select Entity
                                                                       Order By Entity.Number Descending

                    End If

                    SearchableComboBoxGeneralInfo_Job.SelectSingleItemDataSource()

                End Using

            End Using

        End Sub
        Private Sub LoadJobComponentLookup()

            'objects
            Dim JobNumber As Integer = Nothing

            If SearchableComboBoxGeneralInfo_Job.HasASelectedValue Then

                JobNumber = CInt(SearchableComboBoxGeneralInfo_Job.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxGeneralInfo_Component.DataSource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, True)
                                                                             Where Entity.JobNumber = JobNumber
                                                                             Select Entity

                    End Using

                End Using

            Else

                SearchableComboBoxGeneralInfo_Component.DataSource = Nothing
                SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadAccountExecutiveLookup()

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobCompNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If SearchableComboBoxGeneralInfo_Job.HasASelectedValue AndAlso SearchableComboBoxGeneralInfo_Component.HasASelectedValue Then

                JobNumber = CInt(SearchableComboBoxGeneralInfo_Job.GetSelectedValue)
                JobCompNumber = CShort(SearchableComboBoxGeneralInfo_Component.GetSelectedValue)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobCompNumber)

                    If JobComponent IsNot Nothing Then

                        SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = JobComponent.AccountExecutiveEmployeeCode

                    End If

                End Using

            Else

                SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing

            End If

        End Sub
        Private Sub LoadJobTrafficDetails(ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic)

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If JobTraffic IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobTraffic.JobNumber)
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTraffic.JobNumber, JobTraffic.JobComponentNumber)

                    SearchableComboBoxGeneralInfo_Client.SelectedValue = Job.ClientCode

                    LoadDivisionLookup()

                    SearchableComboBoxGeneralInfo_Division.SelectedValue = Job.DivisionCode

                    LoadProductLookup()

                    SearchableComboBoxGeneralInfo_Product.SelectedValue = Job.ProductCode

                    LoadJobLookup()

                    SearchableComboBoxGeneralInfo_Job.SelectedValue = Job.Number

                    LoadJobComponentLookup()

                    SearchableComboBoxGeneralInfo_Component.SelectedValue = JobComponent.Number

                    LoadAccountExecutiveLookup()

                    SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = JobComponent.AccountExecutiveEmployeeCode

                    SearchableComboBoxGeneralInfo_JobStatus.SelectedValue = JobTraffic.TrafficCode

                    'DateTimePickerGeneralInfo_JobDueDate.ValueObject = 
                    'DateTimePickerGeneralInfo_JobStartDate.ValueObject = 

                End Using

            End If

        End Sub
        Private Sub ModifyEmployeeTaskColumns()

            Dim VisibleIndex As Integer = 0

            If DataGridViewEmployees_Employees.Columns.Count > 0 Then

                For Each GridColumn In DataGridViewEmployees_Employees.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    GridColumn.VisibleIndex = -1
                    GridColumn.Visible = False

                Next

                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.EmployeeCode.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.EmployeeName.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.QuotedHours.ToString, _ShowQuotedHours, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.HoursAllowed.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.HoursPosted.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.PercentComplete.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.ActualPercentComplete.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.TempCompleteDate.ToString, True, VisibleIndex)
                HideOrShowEmployeeTaskColumns(AdvantageFramework.ProjectSchedule.Classes.TaskEmployee.Properties.CompletedComments.ToString, True, VisibleIndex)

            End If

        End Sub
        Private Sub HideOrShowEmployeeTaskColumns(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewEmployees_Employees.Columns(FieldName) IsNot Nothing Then

                If Visible Then

                    DataGridViewEmployees_Employees.Columns(FieldName).VisibleIndex = VisibleIndex
                    DataGridViewEmployees_Employees.Columns(FieldName).Visible = True

                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewEmployees_Employees.Columns(FieldName).VisibleIndex = -1
                    DataGridViewEmployees_Employees.Columns(FieldName).Visible = False

                End If

            End If

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponentTask = Me.FillObject(False)

                    If JobComponentTask IsNot Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.JobComponentTask.Update(DbContext, JobComponentTask)

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
        Public Function Delete() As Boolean

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponentTask = Me.FillObject(False)

                    If JobComponentTask IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.JobComponentTask.Delete(DbContext, JobComponentTask)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "Error deleting task!"

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef JobNumber As String, ByRef JobComponentNumber As String, ByRef SequenceNumber As Short) As Boolean

            'objects
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponentTask = Me.FillObject(True)

                    If JobComponentTask IsNot Nothing Then

                        JobComponentTask.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.JobComponentTask.Insert(DbContext, JobComponentTask)

                        If Inserted Then

                            JobNumber = JobComponentTask.JobNumber
                            JobComponentNumber = JobComponentTask.JobComponentNumber
                            SequenceNumber = JobComponentTask.SequenceNumber

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            _LoadingData = True

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _SequenceNumber = SequenceNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)

                    If JobTraffic IsNot Nothing Then

                        LoadJobTrafficDetails(JobTraffic)

                        If _SequenceNumber > -1 Then

                            JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber)

                            If JobComponentTask IsNot Nothing Then

                                LoadEntityDetails(Nothing)

                            Else

                                Loaded = False

                            End If

                        End If

                    Else

                        Loaded = False

                    End If

                Else

                    Loaded = False

                End If

            End Using

            EnableOrDisableActions()

            _LoadingData = False

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            'general info 
            SearchableComboBoxGeneralInfo_Client.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_Division.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_Job.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing
            SearchableComboBoxGeneralInfo_JobStatus.SelectedValue = Nothing
            DateTimePickerGeneralInfo_JobDueDate.ValueObject = Nothing
            DateTimePickerGeneralInfo_JobStartDate.ValueObject = Nothing

            'details tab
            SearchableComboBoxDetails_Phase.SelectedValue = Nothing
            SearchableComboBoxDetails_Task.SelectedValue = Nothing
            TextBoxDetails_TaskDescription.Text = Nothing
            SearchableComboBoxDetails_TaskStatus.SelectedValue = Nothing
            DateTimePickerDetails_StartDate.ValueObject = Nothing
            DateTimePickerDetails_DueDate.ValueObject = Nothing
            DateTimePickerDetails_CompletedDate.ValueObject = Nothing
            DateTimePickerDetails_TempComplete.ValueObject = Nothing
            TextBoxDetails_TimeDue.Text = Nothing
            TextBoxTaskComments_Comments.Text = Nothing
            TextBoxDueDateComments_Comments.Text = Nothing
            TextBoxRevisedDueDateComments_Comments.Text = Nothing

            'settings tab
            NumericInputSettings_Order.EditValue = Nothing
            NumericInputSettings_DaysDuration.EditValue = Nothing
            NumericInputSettings_DefaultHoursAllowed.EditValue = Nothing
            CheckBoxSettings_Milestone.Checked = False
            SearchableComboBoxSettings_EstimateFunction.SelectedValue = Nothing
            DateTimePickerSettings_OriginalDueDate.ValueObject = Nothing
            CheckBoxSettings_Locked.Checked = False

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub AddEmployees()

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then

                If AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEmployeesEditDialog.ShowFormDialog(_JobNumber, _JobComponentNumber, _SequenceNumber) = Windows.Forms.DialogResult.OK Then

                    TabItemTaskDetails_EmployeesTab.Tag = False
                    LoadEntityDetails(TabItemTaskDetails_EmployeesTab)

                End If

            End If

        End Sub
        Public Sub Print()

            AdvantageFramework.Navigation.ShowMessageBox("To do!")

        End Sub
        Public Sub AddAssignment()

            AdvantageFramework.Navigation.ShowMessageBox("To do!")

        End Sub
        Public Sub AddTimeToTask()

            AdvantageFramework.Navigation.ShowMessageBox("To do!")

        End Sub
        Public Sub MarkCompleted()

            AdvantageFramework.Navigation.ShowMessageBox("To do!")

        End Sub
        Public Sub CreateAlert()

            AdvantageFramework.Navigation.ShowMessageBox("To do!")

        End Sub
        Public Sub HideOrShowQuotedHours(ByVal Show As Boolean)

            _ShowQuotedHours = Show

            ModifyEmployeeTaskColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub JobComponentTaskControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_TaskDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_TaskDetails.SelectedTabChanged

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub TabControlControl_TaskDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_TaskDetails.SelectedTabChanging

            LoadEntityDetails(e.NewTab)

            _SelectedTab = e.NewTab

        End Sub

#Region "  General Info "

        Private Sub SearchableComboBoxGeneralInfo_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_Client.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing

            If _Session IsNot Nothing Then

                If _LoadingData = False Then

                    _LoadingData = True

                    SearchableComboBoxGeneralInfo_Division.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Job.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing

                    LoadDivisionLookup()

                    If SearchableComboBoxGeneralInfo_Division.SelectSingleItemDataSource() Then

                        LoadProductLookup()

                        SearchableComboBoxGeneralInfo_Product.SelectSingleItemDataSource()

                    Else

                        SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing

                    End If

                    LoadJobLookup()

                    If SearchableComboBoxGeneralInfo_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxGeneralInfo_Component.SelectSingleItemDataSource() Then

                            LoadAccountExecutiveLookup()

                        End If

                    End If

                    _LoadingData = False

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_Division.EditValueChanged

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If _Session IsNot Nothing Then

                If _LoadingData = False Then

                    _LoadingData = True

                    SearchableComboBoxGeneralInfo_Product.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Job.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing

                    LoadProductLookup()

                    SearchableComboBoxGeneralInfo_Product.SelectSingleItemDataSource()

                    LoadJobLookup()

                    If SearchableComboBoxGeneralInfo_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxGeneralInfo_Component.SelectSingleItemDataSource() Then

                            LoadAccountExecutiveLookup()

                        End If

                    End If

                    EnableOrDisableActions()

                    _LoadingData = False

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_Product.EditValueChanged

            If _Session IsNot Nothing Then

                If _LoadingData = False Then

                    _LoadingData = True

                    SearchableComboBoxGeneralInfo_Job.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing

                    LoadJobLookup()

                    If SearchableComboBoxGeneralInfo_Job.SelectSingleItemDataSource() Then

                        LoadJobComponentLookup()

                        If SearchableComboBoxGeneralInfo_Component.SelectSingleItemDataSource() Then

                            LoadAccountExecutiveLookup()

                        End If

                    End If

                    _LoadingData = False

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_Job.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing

            If _Session IsNot Nothing Then

                If _LoadingData = False Then

                    _LoadingData = True

                    SearchableComboBoxGeneralInfo_Component.SelectedValue = Nothing
                    SearchableComboBoxGeneralInfo_AccountExecutive.SelectedValue = Nothing

                    LoadJobComponentLookup()

                    If SearchableComboBoxGeneralInfo_Component.SelectSingleItemDataSource() Then

                        LoadAccountExecutiveLookup()

                    End If

                    _LoadingData = False

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralInfo_Component_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralInfo_Component.EditValueChanged

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobCompNumber As Short = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If _Session IsNot Nothing Then

                If _LoadingData = False Then

                    _LoadingData = True

                    LoadAccountExecutiveLookup()

                    _LoadingData = False

                    EnableOrDisableActions()

                End If

            End If

        End Sub

#End Region

#Region "  Details Tab "

        Private Sub SearchableComboBoxDetails_Task_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxDetails_Task.EditValueChanged

            'objects
            Dim TaskCode As String = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

            If _LoadingData = False Then

                _LoadingData = True

                TextBoxDetails_TaskDescription.Text = Nothing

                If SearchableComboBoxDetails_Task.HasASelectedValue Then

                    TaskCode = CStr(SearchableComboBoxDetails_Task.GetSelectedValue)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, TaskCode)

                        If Task IsNot Nothing Then

                            TextBoxDetails_TaskDescription.Text = Task.Description

                        End If

                    End Using

                End If

                _LoadingData = False

            End If

        End Sub
        Private Sub TextBoxDetails_TaskDescription_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDetails_TaskDescription.TextChanged

            'objects
            Dim TaskDescription As String = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

            If _LoadingData = False Then

                _LoadingData = True

                SearchableComboBoxDetails_Task.SelectedValue = Nothing

                If String.IsNullOrEmpty(TextBoxDetails_TaskDescription.Text) = False Then

                    TaskDescription = TextBoxDetails_TaskDescription.Text

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            Task = (From Entity In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                                    Where Entity.Description = TaskDescription
                                    Select Entity).FirstOrDefault

                        Catch ex As Exception
                            Task = Nothing
                        End Try

                        If Task IsNot Nothing Then

                            SearchableComboBoxDetails_Task.SelectedValue = Task.Code

                        End If

                    End Using

                End If

                _LoadingData = False

            End If

        End Sub

#End Region

#Region "  Client Contacts Tab "

        Private Sub MultiSelectControlClientContacts_ClientContacts_ObjectAddedEvent(ObjectAdded As Object) Handles MultiSelectControlClientContacts_ClientContacts.ObjectAddedEvent

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact = Nothing
            Dim Added As Boolean = False

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then

                If ObjectAdded IsNot Nothing Then

                    Try

                        ClientContact = DirectCast(ObjectAdded, AdvantageFramework.Database.Entities.ClientContact)

                    Catch ex As Exception
                        ClientContact = Nothing
                    End Try

                    If ClientContact IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            JobComponentTaskClientContact = New AdvantageFramework.Database.Entities.JobComponentTaskClientContact

                            JobComponentTaskClientContact.DbContext = ObjectAdded
                            JobComponentTaskClientContact.JobNumber = _JobNumber
                            JobComponentTaskClientContact.JobComponentNumber = _JobComponentNumber
                            JobComponentTaskClientContact.SequenceNumber = _SequenceNumber
                            JobComponentTaskClientContact.ClientContactID = ClientContact.ContactID

                            Added = AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Insert(ObjectAdded, JobComponentTaskClientContact)

                        End Using

                    End If

                    If Added = False Then

                        TabItemTaskDetails_ClientContactsTab.Tag = Nothing
                        LoadEntityDetails(TabItemTaskDetails_ClientContactsTab)

                    End If

                End If

            End If

        End Sub
        Private Sub MultiSelectControlClientContacts_ClientContacts_ObjectRemovedEvent(ObjectAdded As Object) Handles MultiSelectControlClientContacts_ClientContacts.ObjectRemovedEvent

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim JobComponentTaskClientContact As AdvantageFramework.Database.Entities.JobComponentTaskClientContact = Nothing
            Dim Deleted As Boolean = False

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then

                If ObjectAdded IsNot Nothing Then

                    Try

                        ClientContact = DirectCast(ObjectAdded, AdvantageFramework.Database.Entities.ClientContact)

                    Catch ex As Exception
                        ClientContact = Nothing
                    End Try

                    If ClientContact IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                JobComponentTaskClientContact = (From Entity In AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.LoadByJobCompAndSequence(ObjectAdded, _JobNumber, _JobComponentNumber, _SequenceNumber)
                                                                 Where Entity.ClientContactID = ClientContact.ContactID
                                                                 Select Entity).SingleOrDefault

                            Catch ex As Exception
                                JobComponentTaskClientContact = Nothing
                            End Try

                            If JobComponentTaskClientContact IsNot Nothing Then

                                Deleted = AdvantageFramework.Database.Procedures.JobComponentTaskClientContact.Delete(ObjectAdded, JobComponentTaskClientContact)

                            End If

                        End Using

                    End If

                    If Deleted = False Then

                        TabItemTaskDetails_ClientContactsTab.Tag = Nothing
                        LoadEntityDetails(TabItemTaskDetails_ClientContactsTab)

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  Employees Tab "

        Private Sub DataGridViewEmployees_Employees_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewEmployees_Employees.DataSourceChangedEvent

            If DataGridViewEmployees_Employees.Columns.Count > 0 Then



            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
