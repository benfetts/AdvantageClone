Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleTaskEmployeesEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _SequenceNumber As Short = Nothing
        Private WithEvents _GridViewSelectedEmployeeWorkloadLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewSelectedEmployeeAssignmentsLevel1Tab2 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewAvailableEmployeeWorkloadLevel1Tab1 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewAvailableEmployeeAssignmentsLevel1Tab2 As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private _WorkLoads As Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload)) = Nothing
        Private _Assignments As Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment)) = Nothing
        Private _LastLoadedStartDate As Date = Nothing
        Private _LastLoadedDueDate As Date = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Private ReadOnly Property JobComponentNumber As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Private ReadOnly Property SequenceNumber As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _SequenceNumber = SequenceNumber

        End Sub
        Private Sub LoadEmployees()

            'objects
            Dim JobComponentTaskEmployees As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing
            Dim SelectedEmployeeCodes As String() = Nothing
            Dim EmployeeCodesMatchingRoles As String() = Nothing
            Dim RoleCodes As String() = Nothing

            ButtonItemOptions_Refresh.Enabled = False

            If _WorkLoads Is Nothing Then

                _WorkLoads = New Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload))

            Else

                _WorkLoads.Clear()

            End If

            If _Assignments Is Nothing Then

                _Assignments = New Generic.Dictionary(Of String, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment))

            Else

                _Assignments.Clear()

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobComponentTaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber).ToList

                DataGridViewRightSection_SelectedEmployees.DataSource = JobComponentTaskEmployees

                Try

                    SelectedEmployeeCodes = (From Entity In JobComponentTaskEmployees
                                             Select Entity.EmployeeCode).ToArray

                Catch ex As Exception
                    SelectedEmployeeCodes = Nothing
                End Try

                If ButtonItemOptions_LimitToTaskRoles.Checked Then

                    Try

                        RoleCodes = DataGridViewRoles_Roles.GetAllRowsBookmarkValues.OfType(Of String)().ToArray

                    Catch ex As Exception
                        RoleCodes = {""}
                    End Try

                    Try

                        EmployeeCodesMatchingRoles = (From Entity In AdvantageFramework.Database.Procedures.EmployeeRole.Load(DbContext)
                                                      Where RoleCodes.Contains(Entity.RoleCode) = True
                                                      Select Entity.EmployeeCode).Distinct.ToArray

                    Catch ex As Exception
                        EmployeeCodesMatchingRoles = {""}
                    End Try

                    DataGridViewLeftSection_AvailableEmployees.DataSource = From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                                            Where SelectedEmployeeCodes.Contains(Entity.Code) = False AndAlso
                                                                                  EmployeeCodesMatchingRoles.Contains(Entity.Code) = True
                                                                            Select Entity

                Else

                    DataGridViewLeftSection_AvailableEmployees.DataSource = From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                                            Where SelectedEmployeeCodes.Contains(Entity.Code) = False
                                                                            Select Entity

                End If

            End Using

            Me.ClearChanged()

            DataGridViewRightSection_SelectedEmployees.CurrentView.BestFitColumns()
            DataGridViewLeftSection_AvailableEmployees.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadAssignmentsDetailView(ByVal MainDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal DetailGridView As AdvantageFramework.WinForm.Presentation.Controls.GridView)

            'objects
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing

            MainDataGridView.CurrentView.BeginUpdate()

            MainDataGridView.GridControl.LevelTree.Nodes.Add("EmployeeAssignmentsLevel1Tab2", DetailGridView)
            DetailGridView.LevelIndent = 1
            DetailGridView.ChildGridLevelName = "EmployeeAssignmentsLevel1Tab2"
            DetailGridView.GridControl = MainDataGridView.GridControl
            DetailGridView.Session = Me.Session
            DetailGridView.ControlType = WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            DetailGridView.ObjectType = GetType(AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment)
            DetailGridView.OptionsDetail.ShowDetailTabs = False
            DetailGridView.OptionsSelection.MultiSelect = False
            DetailGridView.OptionsView.ShowViewCaption = False
            DetailGridView.CreateColumnsBasedOnObjectType()
            DetailGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            DetailGridView.OptionsView.ShowFooter = False

            For Each GridColumn In DetailGridView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                Select Case GridColumn.FieldName

                    Case AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.ClientCode.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.DivisionCode.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.ProductCode.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobNumber.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobDescription.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobComponentNumber.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobComponentDescription.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.TaskDescription.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.TaskStartDate.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobRevisedDate.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobHours.ToString,
                         AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.AdjustedJobHours.ToString

                        GridColumn.Visible = True
                        GridColumn.OptionsColumn.AllowEdit = False

                        If GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.TaskStartDate.ToString Then

                            GridColumn.Caption = "Start"

                        ElseIf GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobRevisedDate.ToString Then

                            GridColumn.Caption = "Due"

                        ElseIf GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobHours.ToString Then

                            SubItemNumericInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemNumericInput(Me.Session, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GridColumn.FieldName, "f2", True, GetType(AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment), Nothing)

                            DetailGridView.GridControl.RepositoryItems.Add(SubItemNumericInput)

                            GridColumn.ColumnEdit = SubItemNumericInput

                            GridColumn.Caption = "Hours"
                            GridColumn.OptionsColumn.AllowEdit = True
                            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            GridColumn.DisplayFormat.FormatString = "f2"

                        ElseIf GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.AdjustedJobHours.ToString Then

                            GridColumn.Caption = "Adjusted Hours"
                            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            GridColumn.DisplayFormat.FormatString = "f2"

                        End If

                    Case Else

                        GridColumn.Visible = False

                End Select

            Next

            MainDataGridView.CurrentView.EndUpdate()

        End Sub
        Private Sub LoadWorkloadDetailView(ByVal MainDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal DetailGridView As AdvantageFramework.WinForm.Presentation.Controls.GridView)

            Dim APViewDeletedInvoices As Boolean = False

            MainDataGridView.CurrentView.BeginUpdate()

            MainDataGridView.GridControl.LevelTree.Nodes.Add("EmployeeWorkloadLevel1Tab1", DetailGridView)
            DetailGridView.OptionsCustomization.AllowSort = False
            DetailGridView.LevelIndent = 1
            DetailGridView.ChildGridLevelName = "EmployeeWorkloadLevel1Tab1"
            DetailGridView.GridControl = MainDataGridView.GridControl
            DetailGridView.Session = Me.Session
            DetailGridView.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            DetailGridView.ObjectType = GetType(AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload)
            DetailGridView.OptionsDetail.ShowDetailTabs = False
            DetailGridView.OptionsSelection.MultiSelect = False
            DetailGridView.OptionsView.ShowViewCaption = False
            DetailGridView.CreateColumnsBasedOnObjectType()
            DetailGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            DetailGridView.OptionsView.ShowFooter = False

            For Each GridColumn In DetailGridView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload.Properties.WorkloadHours.ToString OrElse
                   GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload.Properties.WorkloadType.ToString Then

                    GridColumn.Caption = " "
                    GridColumn.Visible = True

                    If GridColumn.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload.Properties.WorkloadHours.ToString Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "f2"

                    End If

                Else

                    GridColumn.Visible = False

                End If

            Next

            MainDataGridView.CurrentView.EndUpdate()

        End Sub
        Private Function LoadEmployeeData(ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = False
            Dim ResultSet3List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet3) = Nothing
            Dim ResultSet3 As AdvantageFramework.ProjectSchedule.Classes.ResultSet3 = Nothing
            Dim ResultSet6List As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ResultSet6) = Nothing
            Dim EmployeeWorkloadList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload) = Nothing
            Dim EmployeeAssignmentList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment) = Nothing
            Dim EmployeeWorkload As AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload = Nothing
            Dim EmployeeAssignment As AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If AdvantageFramework.ProjectSchedule.LoadEmployeeAvailability(DbContext, EmployeeCode, _LastLoadedStartDate, _LastLoadedDueDate, ProjectSchedule.SummaryLevel.Day, Nothing, Nothing, True, ResultSet3List:=ResultSet3List, ResultSet6List:=ResultSet6List) Then

                        EmployeeAssignmentList = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment)

                        Loaded = True

                        For Each ResultSet6 In ResultSet6List

                            EmployeeAssignment = New AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment

                            EmployeeAssignment.ID = ResultSet6.ID
                            EmployeeAssignment.EmployeeCode = ResultSet6.EmployeeCode
                            EmployeeAssignment.SequenceNumber = ResultSet6.SequenceNumber
                            EmployeeAssignment.ClientCode = ResultSet6.ClientCode
                            EmployeeAssignment.DivisionCode = ResultSet6.DivisionCode
                            EmployeeAssignment.ProductCode = ResultSet6.ProductCode
                            EmployeeAssignment.JobNumber = ResultSet6.JobNumber
                            EmployeeAssignment.JobDescription = ResultSet6.JobDescription
                            EmployeeAssignment.JobComponentNumber = ResultSet6.JobComponentNumber
                            EmployeeAssignment.JobComponentDescription = ResultSet6.JobComponentDescription
                            EmployeeAssignment.TaskDescription = ResultSet6.TaskDescription
                            EmployeeAssignment.TaskStartDate = ResultSet6.TaskStartDate
                            EmployeeAssignment.JobRevisedDate = ResultSet6.JobRevisedDate
                            EmployeeAssignment.JobHours = ResultSet6.JobHours
                            EmployeeAssignment.AdjustedJobHours = ResultSet6.AdjustedJobHours

                            EmployeeAssignmentList.Add(EmployeeAssignment)

                        Next

                    End If

                    EmployeeWorkloadList = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload)

                    If ResultSet3List IsNot Nothing Then

                        ResultSet3 = ResultSet3List.FirstOrDefault

                    End If

                    For Count = 0 To 4

                        EmployeeWorkload = New AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload

                        EmployeeWorkload.WorkloadType = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(AdvantageFramework.ProjectSchedule.WorkloadType), Count))

                        If ResultSet3 IsNot Nothing Then

                            Select Case Count

                                Case ProjectSchedule.WorkloadType.StandardHoursAvailable

                                    EmployeeWorkload.WorkloadHours = ResultSet3.StandardHoursAvailable.GetValueOrDefault(0)

                                Case ProjectSchedule.WorkloadType.AppointmentHours

                                    EmployeeWorkload.WorkloadHours = ResultSet3.HoursAppointments.GetValueOrDefault(0)

                                Case ProjectSchedule.WorkloadType.HoursOff

                                    EmployeeWorkload.WorkloadHours = ResultSet3.HoursUsedNonTask.GetValueOrDefault(0)

                                Case ProjectSchedule.WorkloadType.HoursAssignedToTasks

                                    EmployeeWorkload.WorkloadHours = ResultSet3.HoursAssignedTask.GetValueOrDefault(0)

                                Case ProjectSchedule.WorkloadType.Variance

                                    EmployeeWorkload.WorkloadHours = (ResultSet3.StandardHoursAvailable.GetValueOrDefault(0) -
                                                                      ResultSet3.HoursUsedNonTask.GetValueOrDefault(0) -
                                                                      ResultSet3.HoursAssignedTask.GetValueOrDefault(0) -
                                                                      ResultSet3.HoursAppointments.GetValueOrDefault(0))

                            End Select

                        End If

                        EmployeeWorkloadList.Add(EmployeeWorkload)

                    Next

                    If _Assignments.ContainsKey(EmployeeCode) Then

                        _Assignments(EmployeeCode) = EmployeeAssignmentList

                    Else

                        _Assignments.Add(EmployeeCode, EmployeeAssignmentList)

                    End If

                    If _WorkLoads.ContainsKey(EmployeeCode) Then

                        _WorkLoads(EmployeeCode) = EmployeeWorkloadList

                    Else

                        _WorkLoads.Add(EmployeeCode, EmployeeWorkloadList)

                    End If

                Catch ex As Exception
                    Loaded = False
                End Try

            End Using

            LoadEmployeeData = True

        End Function
        Private Function LoadWorkloadData(ByVal EmployeeCode As String) As IEnumerable

            'objects
            Dim EmployeeWorkloadList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload) = Nothing

            If _WorkLoads.ContainsKey(EmployeeCode) Then

                EmployeeWorkloadList = _WorkLoads(EmployeeCode)

            Else

                If LoadEmployeeData(EmployeeCode) Then

                    EmployeeWorkloadList = _WorkLoads(EmployeeCode)

                End If

            End If

            LoadWorkloadData = EmployeeWorkloadList

        End Function
        Private Function LoadAssignmentData(ByVal EmployeeCode As String) As IEnumerable

            'objects
            Dim EmployeeAssignmentList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment) = Nothing

            If _WorkLoads.ContainsKey(EmployeeCode) Then

                EmployeeAssignmentList = _Assignments(EmployeeCode)

            Else

                If LoadEmployeeData(EmployeeCode) Then

                    EmployeeAssignmentList = _Assignments(EmployeeCode)

                End If

            End If

            LoadAssignmentData = EmployeeAssignmentList

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemOptions_Save.Enabled = Me.UserEntryChanged

        End Sub


#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleTaskEmployeesEditDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEmployeesEditDialog = Nothing

            ProjectScheduleTaskEmployeesEditDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleTaskEmployeesEditDialog(JobNumber, JobComponentNumber, SequenceNumber)

            ShowFormDialog = ProjectScheduleTaskEmployeesEditDialog.ShowDialog()

            JobNumber = ProjectScheduleTaskEmployeesEditDialog.JobNumber
            JobComponentNumber = ProjectScheduleTaskEmployeesEditDialog.JobComponentNumber
            SequenceNumber = ProjectScheduleTaskEmployeesEditDialog.SequenceNumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleTaskEmployeesEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim RoleCodes As String() = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemOptions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemOptions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemOptions_CheckAvailability.Image = AdvantageFramework.My.Resources.CalendarMonthImage
            ButtonItemOptions_LimitToTaskRoles.Image = AdvantageFramework.My.Resources.AlternateEmployeesImage

            DateTimePickerForm_DueDate.ByPassUserEntryChanged = True
            DateTimePickerForm_StartDate.ByPassUserEntryChanged = True

            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, _JobNumber, _JobComponentNumber, _SequenceNumber)

                        If JobComponentTask IsNot Nothing Then

                            DateTimePickerForm_DueDate.ValueObject = JobComponentTask.DueDate
                            DateTimePickerForm_StartDate.ValueObject = JobComponentTask.StartDate

                            _LastLoadedDueDate = DateTimePickerForm_DueDate.Value
                            _LastLoadedStartDate = DateTimePickerForm_StartDate.Value

                            If JobComponentTask.Hours.HasValue Then

                                LabelForm_DefaultHoursPlaceholder.Text = JobComponentTask.Hours.Value.ToString

                            Else

                                LabelForm_DefaultHoursPlaceholder.Text = ""

                            End If

                            LabelForm_TimeDuePlaceholder.Text = JobComponentTask.OriginalDueTime

                            Try

                                RoleCodes = (From Entity In AdvantageFramework.Database.Procedures.TaskRole.LoadByTaskCode(DataContext, JobComponentTask.TaskCode)
                                             Select Entity.RoleCode).ToArray

                            Catch ex As Exception
                                RoleCodes = {""}
                            End Try

                            DataGridViewRoles_Roles.DataSource = From Entity In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                                                                 Where RoleCodes.Contains(Entity.Code)
                                                                 Select Entity

                            DataGridViewRoles_Roles.CurrentView.BestFitColumns()

                            If RoleCodes IsNot Nothing AndAlso RoleCodes.Count > 0 Then

                                ButtonItemOptions_LimitToTaskRoles.Enabled = True
                                ButtonItemOptions_LimitToTaskRoles.Checked = True

                            Else

                                ButtonItemOptions_LimitToTaskRoles.Checked = False
                                ButtonItemOptions_LimitToTaskRoles.Enabled = False

                            End If

                            LoadEmployees()

                            _GridViewSelectedEmployeeWorkloadLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView
                            _GridViewAvailableEmployeeWorkloadLevel1Tab1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView
                            _GridViewSelectedEmployeeAssignmentsLevel1Tab2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView
                            _GridViewAvailableEmployeeAssignmentsLevel1Tab2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView

                            _GridViewSelectedEmployeeWorkloadLevel1Tab1.Name = "_GridViewSelectedEmployeeWorkloadLevel1Tab1"
                            _GridViewAvailableEmployeeWorkloadLevel1Tab1.Name = "_GridViewAvailableEmployeeWorkloadLevel1Tab1"
                            _GridViewSelectedEmployeeAssignmentsLevel1Tab2.Name = "_GridViewSelectedEmployeeAssignmentsLevel1Tab2"
                            _GridViewAvailableEmployeeAssignmentsLevel1Tab2.Name = "_GridViewAvailableEmployeeAssignmentsLevel1Tab2"

                            LoadWorkloadDetailView(DataGridViewRightSection_SelectedEmployees, _GridViewSelectedEmployeeWorkloadLevel1Tab1)
                            LoadWorkloadDetailView(DataGridViewLeftSection_AvailableEmployees, _GridViewAvailableEmployeeWorkloadLevel1Tab1)
                            LoadAssignmentsDetailView(DataGridViewRightSection_SelectedEmployees, _GridViewSelectedEmployeeAssignmentsLevel1Tab2)
                            LoadAssignmentsDetailView(DataGridViewLeftSection_AvailableEmployees, _GridViewAvailableEmployeeAssignmentsLevel1Tab2)

                        Else

                            Loaded = False

                        End If

                    End Using

                End Using

            Else

                Loaded = True

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the employees for the selected task.")
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ProjectScheduleTaskEmployeesEditDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemOptions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProjectScheduleTaskEmployeesEditDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemOptions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemOptions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Save.Click

            'objects
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim Saved As Boolean = True

            If Me.Validator Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each JobComponentTaskEmployee In DataGridViewRightSection_SelectedEmployees.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee)()

                            If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) = False Then

                                Saved = False

                            End If

                        Next

                        For Each EmployeeAssignment In _GridViewAvailableEmployeeAssignmentsLevel1Tab2.GetAllModifiedRows.OfType(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment)()

                            Try

                                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, EmployeeAssignment.JobNumber, EmployeeAssignment.JobComponentNumber, EmployeeAssignment.SequenceNumber, EmployeeAssignment.EmployeeCode)

                            Catch ex As Exception
                                JobComponentTaskEmployee = Nothing
                            End Try

                            If JobComponentTaskEmployee IsNot Nothing Then

                                JobComponentTaskEmployee.Hours = EmployeeAssignment.JobHours

                                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) = False Then

                                    Saved = False

                                End If

                            End If

                        Next

                        For Each EmployeeAssignment In _GridViewSelectedEmployeeAssignmentsLevel1Tab2.GetAllModifiedRows.OfType(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment)()

                            Try

                                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, EmployeeAssignment.JobNumber, EmployeeAssignment.JobComponentNumber, EmployeeAssignment.SequenceNumber, EmployeeAssignment.EmployeeCode)

                            Catch ex As Exception
                                JobComponentTaskEmployee = Nothing
                            End Try

                            If JobComponentTaskEmployee IsNot Nothing Then

                                JobComponentTaskEmployee.Hours = EmployeeAssignment.JobHours

                                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee) = False Then

                                    Saved = False

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception
                    Saved = False
                End Try

                If Saved = False Then

                    AdvantageFramework.Navigation.ShowMessageBox("There was a problem saving. Please contact software support.")

                Else

                    LoadEmployees()

                    Me.ClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_AddEmployee_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddEmployee.Click

            'objects
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim AnyCreated As Boolean = False

            If DataGridViewLeftSection_AvailableEmployees.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each EmployeeCode In DataGridViewLeftSection_AvailableEmployees.GetAllRowsBookmarkValues.OfType(Of String)()

                        JobComponentTaskEmployee = New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                        JobComponentTaskEmployee.JobNumber = _JobNumber
                        JobComponentTaskEmployee.JobComponentNumber = _JobComponentNumber
                        JobComponentTaskEmployee.SequenceNumber = _SequenceNumber
                        JobComponentTaskEmployee.EmployeeCode = EmployeeCode

                        If String.IsNullOrEmpty(LabelForm_DefaultHoursPlaceholder.Text) = False Then

                            JobComponentTaskEmployee.Hours = CDec(LabelForm_DefaultHoursPlaceholder.Text)

                        End If

                        If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, JobComponentTaskEmployee) Then

                            AnyCreated = True

                        End If

                    Next

                End Using

                If AnyCreated Then

                    LoadEmployees()

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select an employee to add.")

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveEmployee_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveEmployee.Click

            'objects
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim AnyDeleted As Boolean = False

            If DataGridViewRightSection_SelectedEmployees.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each RowHandlesAndDataBoundItem In DataGridViewRightSection_SelectedEmployees.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Try

                            JobComponentTaskEmployee = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            JobComponentTaskEmployee = Nothing
                        End Try

                        If JobComponentTaskEmployee IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, JobComponentTaskEmployee) Then

                                AnyDeleted = True

                            End If

                        End If

                    Next

                End Using

                If AnyDeleted Then

                    LoadEmployees()

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select an employee to remove.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemOptions_CheckAvailability_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_CheckAvailability.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()
                
                DataGridViewRightSection_SelectedEmployees.Refresh()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemOptions_LimitToTaskRoles_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOptions_LimitToTaskRoles.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                LoadEmployees()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemOptions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Refresh.Click

            Me.ShowWaitForm()

            _LastLoadedDueDate = DateTimePickerForm_DueDate.Value
            _LastLoadedStartDate = DateTimePickerForm_StartDate.Value

            LoadEmployees()

            Me.CloseWaitForm()

        End Sub
        Private Sub DateTimePickerForm_DueDate_ValueObjectChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_DueDate.ValueObjectChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemOptions_Refresh.Enabled = True

            End If

        End Sub
        Private Sub DateTimePickerForm_StartDate_ValueObjectChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_StartDate.ValueObjectChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemOptions_Refresh.Enabled = True

            End If

        End Sub

#Region "  Selected Employees Grid "

        Private Sub DataGridViewRightSection_SelectedEmployees_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewRightSection_SelectedEmployees.CustomDrawCellEvent

            'objects
            Dim EmployeeWorkload As AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload = Nothing
            Dim EmployeeWorkloadList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload) = Nothing
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim BackColor As System.Drawing.Color = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.Hours.ToString Then

                BackColor = e.Column.AppearanceCell.BackColor

                If ButtonItemOptions_CheckAvailability.Checked Then

                    Try

                        JobComponentTaskEmployee = DataGridViewRightSection_SelectedEmployees.CurrentView.GetRow(e.RowHandle)

                    Catch ex As Exception
                        JobComponentTaskEmployee = Nothing
                    End Try

                    If JobComponentTaskEmployee IsNot Nothing Then

                        If _WorkLoads.ContainsKey(JobComponentTaskEmployee.EmployeeCode) Then

                            EmployeeWorkloadList = _WorkLoads(JobComponentTaskEmployee.EmployeeCode)

                        Else

                            If LoadEmployeeData(JobComponentTaskEmployee.EmployeeCode) Then

                                EmployeeWorkloadList = _WorkLoads(JobComponentTaskEmployee.EmployeeCode)

                            End If

                        End If

                        If EmployeeWorkloadList IsNot Nothing AndAlso EmployeeWorkloadList.Count > 0 Then

                            Try

                                EmployeeWorkload = (From Workload In EmployeeWorkloadList _
                                                    Where Workload.WorkloadType = AdvantageFramework.ProjectSchedule.WorkloadType.Variance.ToString _
                                                    Select Workload).SingleOrDefault

                            Catch ex As Exception
                                EmployeeWorkload = Nothing
                            End Try

                            If EmployeeWorkload IsNot Nothing Then

                                If EmployeeWorkload.WorkloadHours < 0 Then

                                    BackColor = Drawing.Color.LightPink

                                End If

                            End If

                        End If

                    End If

                End If

                e.Appearance.BackColor = BackColor

            End If

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_SelectedEmployees.DataSourceChangedEvent

            If DataGridViewRightSection_SelectedEmployees.Columns.Count > 0 Then

                If DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.TempCompletionDate.ToString) IsNot Nothing Then

                    DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.TempCompletionDate.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString) IsNot Nothing Then

                    DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).OptionsColumn.AllowEdit = False

                    If DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit IsNot Nothing Then

                        If TypeOf DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                            DirectCast(DataGridViewRightSection_SelectedEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DisplayMember = "Name"

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewRightSection_SelectedEmployees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "EmployeeWorkloadLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            'AddHandler BaseView.FocusedRowChanged, AddressOf _GridViewSelectedEmployeeWorkloadLevel1Tab1_FocusedRowChanged
                            'AddHandler BaseView.RowClick, AddressOf _GridViewSelectedEmployeeWorkloadLevel1Tab1_RowClick
                            'AddHandler BaseView.GridControl.FocusedViewChanged, AddressOf GridControlFocusedViewChanged
                            'AddHandler BaseView.SelectionChanged, AddressOf _GridViewVendorInvsoiceDetailsLevel1Tab1_SelectionChanged

                    End Select

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowGetChildListEvent

            'objects
            Dim EmployeeCode As String = Nothing

            Try

                EmployeeCode = DataGridViewRightSection_SelectedEmployees.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString)

            Catch ex As Exception
                EmployeeCode = Nothing
            End Try

            Select Case e.RelationIndex

                Case 0

                    e.ChildList = LoadWorkloadData(EmployeeCode)

                Case 1

                    e.ChildList = LoadAssignmentData(EmployeeCode)

            End Select

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowGetRelationCountEvent

            e.RelationCount = 2

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowGetRelationDisplayCaptionEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewRightSection_SelectedEmployees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Workload"

                    Case 1

                        e.RelationName = RowCount & " Assignment(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Workload"

                    Case 1

                        e.RelationName = " Assignment(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewRightSection_SelectedEmployees.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "EmployeeWorkloadLevel1Tab1"

                Case 1

                    e.RelationName = "EmployeeAssignmentsLevel1Tab2"

            End Select

        End Sub
        Private Sub _GridViewSelectedEmployeeAssignmentsLevel1Tab2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles _GridViewSelectedEmployeeAssignmentsLevel1Tab2.CellValueChanged

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            If e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobHours.ToString Then

                Try

                    BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                Catch ex As Exception
                    BaseView = Nothing
                End Try

                If BaseView IsNot Nothing Then

                    _GridViewSelectedEmployeeAssignmentsLevel1Tab2.AddToModifiedRows(BaseView.GetRow(e.RowHandle))
                    DataGridViewRightSection_SelectedEmployees.SetUserEntryChanged()

                End If

            End If

        End Sub

#End Region

#Region "  Available Employees Grid "

        Private Sub DataGridViewLeftSection_AvailableEmployees_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.CustomDrawCellEvent

            'objects
            Dim EmployeeWorkload As AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload = Nothing
            Dim EmployeeWorkloadList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.EmployeeWorkload) = Nothing
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim BackColor As System.Drawing.Color = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.Hours.ToString Then

                BackColor = e.Column.AppearanceCell.BackColor

                If ButtonItemOptions_CheckAvailability.Checked Then

                    Try

                        JobComponentTaskEmployee = DataGridViewLeftSection_AvailableEmployees.CurrentView.GetRow(e.RowHandle)

                    Catch ex As Exception
                        JobComponentTaskEmployee = Nothing
                    End Try

                    If JobComponentTaskEmployee IsNot Nothing Then

                        If _WorkLoads.ContainsKey(JobComponentTaskEmployee.EmployeeCode) Then

                            EmployeeWorkloadList = _WorkLoads(JobComponentTaskEmployee.EmployeeCode)

                        Else

                            If LoadEmployeeData(JobComponentTaskEmployee.EmployeeCode) Then

                                EmployeeWorkloadList = _WorkLoads(JobComponentTaskEmployee.EmployeeCode)

                            End If

                        End If

                        If EmployeeWorkloadList IsNot Nothing AndAlso EmployeeWorkloadList.Count > 0 Then

                            Try

                                EmployeeWorkload = (From Workload In EmployeeWorkloadList _
                                                    Where Workload.WorkloadType = AdvantageFramework.ProjectSchedule.WorkloadType.Variance.ToString _
                                                    Select Workload).SingleOrDefault

                            Catch ex As Exception
                                EmployeeWorkload = Nothing
                            End Try

                            If EmployeeWorkload IsNot Nothing Then

                                If EmployeeWorkload.WorkloadHours < 0 Then

                                    BackColor = Drawing.Color.IndianRed

                                End If

                            End If

                        End If

                    End If

                End If

                e.Appearance.BackColor = BackColor

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_AvailableEmployees.DataSourceChangedEvent

            If DataGridViewLeftSection_AvailableEmployees.Columns.Count > 0 Then

                If DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.TempCompletionDate.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.TempCompletionDate.ToString).OptionsColumn.AllowEdit = False

                End If

                If DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).OptionsColumn.AllowEdit = False

                    If DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit IsNot Nothing Then

                        If TypeOf DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                            DirectCast(DataGridViewLeftSection_AvailableEmployees.Columns(AdvantageFramework.Database.Entities.JobComponentTaskEmployee.Properties.EmployeeCode.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DisplayMember = "Name"

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowEmptyEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowExpandedEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewLeftSection_AvailableEmployees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.ClearSelection()

                BaseView.SelectRow(BaseView.SourceRowHandle)

                If BaseView.ChildGridLevelName = "EmployeeWorkloadLevel1Tab1" Then

                    Select Case e.RelationIndex

                        Case 0

                            'AddHandler BaseView.FocusedRowChanged, AddressOf _GridViewSelectedEmployeeWorkloadLevel1Tab1_FocusedRowChanged
                            'AddHandler BaseView.RowClick, AddressOf _GridViewSelectedEmployeeWorkloadLevel1Tab1_RowClick
                            'AddHandler BaseView.GridControl.FocusedViewChanged, AddressOf GridControlFocusedViewChanged
                            'AddHandler BaseView.SelectionChanged, AddressOf _GridViewVendorInvsoiceDetailsLevel1Tab1_SelectionChanged

                    End Select

                    If BaseView.RowCount > 0 Then

                        BaseView.SelectRow(0)

                    End If

                End If

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowGetChildListEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowGetChildListEvent

            'objects
            Dim EmployeeCode As String = Nothing

            Try

                EmployeeCode = DataGridViewLeftSection_AvailableEmployees.GetFirstSelectedRowBookmarkValue()

            Catch ex As Exception
                EmployeeCode = Nothing
            End Try

            Select Case e.RelationIndex

                Case 0

                    e.ChildList = LoadWorkloadData(EmployeeCode)

                Case 1

                    e.ChildList = LoadAssignmentData(EmployeeCode)

            End Select

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowGetRelationCountEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowGetRelationCountEvent

            e.RelationCount = 2

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowGetRelationDisplayCaptionEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowGetRelationDisplayCaptionEvent

            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim RowCount As Integer = 0

            BaseView = DataGridViewLeftSection_AvailableEmployees.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                RowCount = BaseView.RowCount

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Workload"

                    Case 1

                        e.RelationName = RowCount & " Assignment(s)"

                End Select

            Else

                Select Case e.RelationIndex

                    Case 0

                        e.RelationName = " Workload"

                    Case 1

                        e.RelationName = " Assignment(s)"

                End Select

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_MasterRowGetRelationNameEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewLeftSection_AvailableEmployees.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "EmployeeWorkloadLevel1Tab1"

                Case 1

                    e.RelationName = "EmployeeAssignmentsLevel1Tab2"

            End Select

        End Sub
        Private Sub _GridViewAvailableEmployeeAssignmentsLevel1Tab2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles _GridViewAvailableEmployeeAssignmentsLevel1Tab2.CellValueChanged

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            If e.Column.FieldName = AdvantageFramework.ProjectSchedule.Classes.EmployeeAssignment.Properties.JobHours.ToString Then

                Try

                    BaseView = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                Catch ex As Exception
                    BaseView = Nothing
                End Try

                If BaseView IsNot Nothing Then

                    _GridViewAvailableEmployeeAssignmentsLevel1Tab2.AddToModifiedRows(BaseView.GetRow(e.RowHandle))
                    DataGridViewLeftSection_AvailableEmployees.SetUserEntryChanged()

                End If

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace