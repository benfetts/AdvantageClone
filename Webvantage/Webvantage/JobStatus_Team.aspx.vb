Imports Telerik.Web.UI

Public Class JobStatus_Team
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum LoadType

        AlertGroup = 0
        Manager = 1
        ScheduleAssignments = 2
        ScheduleTaskAssignments = 3
        AccountExecutive = 4

    End Enum
    Public Enum ManagerType

        AccountExecutive
        Manager

    End Enum

#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _ContentControlEmployee_Card As Webvantage.Employee_Card
    Private _EmployeeList As New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple)
    Private _JobTeam As New Generic.List(Of AdvantageFramework.Database.Classes.JobTeamEmployee)

#End Region

#Region " Properties "

    Private Property _LoadType As LoadType
        Get
            If ViewState("_LoadType") Is Nothing Then ViewState("_LoadType") = CType(LoadType.AlertGroup, Integer)
            Return CType(CType(ViewState("_LoadType"), Integer), LoadType)
        End Get
        Set(value As LoadType)
            ViewState("_LoadType") = CType(value, Integer).ToString()
        End Set
    End Property

    Private Property HasSchedule As Boolean

#End Region

#Region " Methods "

#Region " Main "

#Region " Page "

    Private Sub JobStatus_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNumber = qs.JobComponentNumber

        Me.LoadData()

    End Sub
    Private Sub JobStatus_Team_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.SetScheduleButtons()
            Me.LabelInstructionsForDummies.Text = ""
            Me.DivTaskEmployeeFilterRadComboBox.Visible = False

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub CompleteCancel()

        Me.LabelInstructionsForDummies.Text = ""
        Me.SetEditButtons(False)
        Me.LoadData()
        Me.MultiViewContent.SetActiveView(Me.ViewEmployeeCards)

    End Sub
    Private Sub ImageButtonCancel_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonCancel.Click

        Me.CompleteCancel()

    End Sub
    Private Sub ImageButtonEdit_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonEdit.Click

        SetEditButtons(True)

        Dim emp As New AdvantageFramework.Database.Views.Employee

        Select Case Me._LoadType
            Case LoadType.Manager

                Me.LoadEmployeeList("", False, True)

                Me.MultiViewContent.SetActiveView(Me.ViewEditManagers)

                Me.RadListBoxEditManagersEmployees.Items.Clear()
                Me.RadListBoxEditManagersEmployees.DataSource = _EmployeeList
                Me.RadListBoxEditManagersEmployees.DataValueField = "Code"
                Me.RadListBoxEditManagersEmployees.DataTextField = "FullName"
                Me.RadListBoxEditManagersEmployees.DataBind()

                Me.LabelInstructionsForDummies.Text = "Drag a name from the list on the left to the image in the card on the right"

            Case LoadType.AccountExecutive

                Me.LoadEmployeeList("", True, True)

                Me.MultiViewContent.SetActiveView(Me.ViewEditAccountExecutive)

                Me.RadListBoxAccountExecutives.Items.Clear()
                Me.RadListBoxAccountExecutives.DataSource = _EmployeeList
                Me.RadListBoxAccountExecutives.DataValueField = "Code"
                Me.RadListBoxAccountExecutives.DataTextField = "FullName"
                Me.RadListBoxAccountExecutives.DataBind()

                Me.LabelInstructionsForDummies.Text = "Drag a name from the list on the left to the image in the card on the right"

            Case LoadType.ScheduleAssignments

                Me.LoadEmployeeList("", False, True)

                Me.MultiViewContent.SetActiveView(Me.ViewEditScheduleAssignments)

                Me.RadListBoxEditScheduleAssignmentsEmployees.Items.Clear()
                Me.RadListBoxEditScheduleAssignmentsEmployees.DataSource = _EmployeeList
                Me.RadListBoxEditScheduleAssignmentsEmployees.DataValueField = "Code"
                Me.RadListBoxEditScheduleAssignmentsEmployees.DataTextField = "FullName"
                Me.RadListBoxEditScheduleAssignmentsEmployees.DataBind()

                Me.LabelInstructionsForDummies.Text = "Drag a name from the list on the left to the image in the cards on the right"

            Case LoadType.ScheduleTaskAssignments

                Me.MultiViewContent.SetActiveView(Me.ViewEditScheduleTasks)

                Me.RadListBoxEditScheduleTasksEmployees.Items.Clear()

                Me.RadListBoxEditScheduleTasksTaskList.Items.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim TaskList As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTask) = Nothing

                    TaskList = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber).ToList()

                    If TaskList IsNot Nothing Then

                        Me.RadListBoxEditScheduleTasksTaskList.DataSource = TaskList
                        Me.RadListBoxEditScheduleTasksTaskList.DataValueField = "SequenceNumber"
                        Me.RadListBoxEditScheduleTasksTaskList.DataTextField = "Description"
                        Me.RadListBoxEditScheduleTasksTaskList.DataBind()

                    End If

                End Using

                Me.LabelInstructionsForDummies.Text = "Select a task on the left and then click names on the right to include that employee on the task"

        End Select

        LoadEditData()

    End Sub
    Private Sub ImageButtonSaveAlertGroup_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSaveAlertGroup.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent
            JobComponent = Nothing

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

            If JobComponent IsNot Nothing Then

                If Me.RadComboBoxAlertGroup.SelectedIndex = 0 Then

                    JobComponent.AlertGroupCode = Nothing

                Else

                    JobComponent.AlertGroupCode = Me.RadComboBoxAlertGroup.SelectedItem.Value

                End If

                If AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent) = True Then

                    Me.LoadData()

                Else

                    Me.ShowMessage("Error")

                End If

            End If

        End Using

    End Sub
    Private Sub RadToolBarTeam_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTeam.ButtonClick

        Me.LabelInstructionsForDummies.Text = ""

        Select Case e.Item.Value
            Case LoadType.AlertGroup.ToString()

                Me._LoadType = LoadType.AlertGroup

            Case LoadType.Manager.ToString()

                Me._LoadType = LoadType.Manager

                Me.ImageButtonEdit.ToolTip = "Click to edit " & Me.RadToolBarTeam.FindItemByValue("Manager").Text
                Me.ImageButtonCancel.ToolTip = "Click when you are done editing " & Me.RadToolBarTeam.FindItemByValue("Manager").Text

            Case LoadType.ScheduleAssignments.ToString()

                Me._LoadType = LoadType.ScheduleAssignments

                Me.ImageButtonEdit.ToolTip = "Click to edit schedule assignments"
                Me.ImageButtonCancel.ToolTip = "Click when you are done editing schedule assignments"

            Case LoadType.ScheduleTaskAssignments.ToString()

                Me._LoadType = LoadType.ScheduleTaskAssignments

                Me.ImageButtonEdit.ToolTip = "Click to edit task assignments"
                Me.ImageButtonCancel.ToolTip = "Click when you are done editing task assignments"

                Me.RadioButtonListTaskEmployeeFilter.SelectedIndex = 0

                Me.DivTaskEmployeeFilterRadComboBox.Visible = False

            Case LoadType.AccountExecutive.ToString()

                Me._LoadType = LoadType.AccountExecutive

                Me.ImageButtonEdit.ToolTip = "Click to edit " & Me.RadToolBarTeam.FindItemByValue("AccountExecutive").Text
                Me.ImageButtonCancel.ToolTip = "Click when you are done editing " & Me.RadToolBarTeam.FindItemByValue("AccountExecutive").Text

        End Select

        Me.LoadData()

    End Sub

#End Region

    Private Sub LoadData()

        Me.MultiViewContent.SetActiveView(ViewEmployeeCards)

        Me.PlaceHolderEmployees.Controls.Clear()

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            _JobTeam = Nothing
            _JobTeam = AdvantageFramework.Database.Procedures.JobTeam.LoadByJobAndComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber, CType(Me._LoadType, Integer)).ToList()

            If _JobTeam IsNot Nothing Then

                For Each TeamMember As AdvantageFramework.Database.Classes.JobTeamEmployee In _JobTeam

                    Me._ContentControlEmployee_Card = CType(LoadControl("Employee_Card.ascx"), Webvantage.Employee_Card)

                    Me._ContentControlEmployee_Card.TeamType = Me._LoadType
                    If TeamMember.EmployeeCode IsNot Nothing Then Me._ContentControlEmployee_Card.EmployeeCode = TeamMember.EmployeeCode
                    If TeamMember.Title IsNot Nothing Then Me._ContentControlEmployee_Card.EmployeeTitle = TeamMember.Title
                    If TeamMember.DisplayName IsNot Nothing Then Me._ContentControlEmployee_Card.EmployeeName = TeamMember.DisplayName
                    If TeamMember.BinaryImage IsNot Nothing Then Me._ContentControlEmployee_Card.EmployeePicture = TeamMember.BinaryImage
                    If TeamMember.TaskCount <> Nothing Then Me._ContentControlEmployee_Card.TaskCount = TeamMember.TaskCount
                    If TeamMember.TotalHours <> Nothing Then Me._ContentControlEmployee_Card.TotalHours = TeamMember.TotalHours
                    If TeamMember.ActualHours <> Nothing Then Me._ContentControlEmployee_Card.ActualHours = TeamMember.ActualHours
                    If TeamMember.EmailGroupCode IsNot Nothing Then Me._ContentControlEmployee_Card.EmailGroupCode = TeamMember.EmailGroupCode
                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me._ContentControlEmployee_Card.TrafficColumnCode = TeamMember.TrafficColumnCode
                    If TeamMember.ManagerType IsNot Nothing Then Me._ContentControlEmployee_Card.ManagerType = TeamMember.ManagerType

                    Me._ContentControlEmployee_Card.JobNumber = Me._JobNumber
                    Me._ContentControlEmployee_Card.JobComponentNumber = Me._JobComponentNumber

                    'Select Case Me._LoadType
                    '    Case LoadType.AlertGroup

                    '    Case LoadType.Managers

                    '    Case LoadType.ScheduleAssignments

                    '    Case LoadType.ScheduleTaskAssignments

                    'End Select

                    Me._ContentControlEmployee_Card.LoadData()
                    Me.PlaceHolderEmployees.Controls.Add(Me._ContentControlEmployee_Card)

                Next

            End If

            Select Case Me._LoadType
                Case LoadType.AlertGroup

                    Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
                    AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList()

                    If AlertGroups IsNot Nothing Then

                        Me.RadComboBoxAlertGroup.DataSource = AlertGroups
                        Me.RadComboBoxAlertGroup.DataTextField = "Code"
                        Me.RadComboBoxAlertGroup.DataValueField = "Code"
                        Me.RadComboBoxAlertGroup.DataBind()
                        Me.RadComboBoxAlertGroup.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[No Alert Group]", "none"))

                        Dim CurrentTeamCode As String = ""
                        Try

                            CurrentTeamCode = (From JC In DbContext.JobComponents
                                               Where JC.JobNumber = Me._JobNumber _
                                               AndAlso JC.Number = Me._JobComponentNumber
                                               Select JC.AlertGroupCode).FirstOrDefault()

                        Catch ex As Exception

                            CurrentTeamCode = ""

                        End Try

                        If CurrentTeamCode <> "" Then MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAlertGroup, CurrentTeamCode, False, True)

                    End If

                    Me.MultiViewEdit.SetActiveView(Me.ViewEditAlertGroupButtons)

                Case Else

                    Me.MultiViewEdit.SetActiveView(Me.ViewEditButtons)
                    SetEditButtons(False)

            End Select

            AdvantageFramework.ProjectManagement.LoadJobTemplateLabelsByJobComponent(DbContext, Me._JobNumber, Me._JobComponentNumber,
                                                                                     Nothing, Nothing, Nothing, Nothing, Me.RadToolBarTeam.FindItemByValue("AccountExecutive").Text, Nothing, Nothing, Nothing)

        End Using

    End Sub
    Private Sub LoadEditData()

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            _JobTeam = Nothing
            _JobTeam = AdvantageFramework.Database.Procedures.JobTeam.LoadByJobAndComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber, CType(Me._LoadType, Integer)).ToList()

            If _JobTeam IsNot Nothing Then

                Select Case Me._LoadType
                    Case LoadType.Manager

                        For Each TeamMember As AdvantageFramework.Database.Classes.JobTeamEmployee In _JobTeam

                            If CType(CType(TeamMember.ManagerType, Integer), ManagerType) = ManagerType.Manager Then

                                If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardManager.EmployeeCode = TeamMember.EmployeeCode
                                If TeamMember.Title IsNot Nothing Then Me.Employee_CardManager.EmployeeTitle = TeamMember.Title
                                If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardManager.EmployeeName = TeamMember.DisplayName
                                If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardManager.EmployeePicture = TeamMember.BinaryImage
                                If TeamMember.TaskCount <> Nothing Then Me.Employee_CardManager.TaskCount = TeamMember.TaskCount
                                If TeamMember.TotalHours <> Nothing Then Me.Employee_CardManager.TotalHours = TeamMember.TotalHours
                                If TeamMember.ActualHours <> Nothing Then Me.Employee_CardManager.ActualHours = TeamMember.ActualHours
                                If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardManager.EmailGroupCode = TeamMember.EmailGroupCode
                                If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardManager.TrafficColumnCode = TeamMember.TrafficColumnCode
                                If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardManager.ManagerType = TeamMember.ManagerType

                            End If

                        Next

                    Case LoadType.AccountExecutive

                        For Each TeamMember As AdvantageFramework.Database.Classes.JobTeamEmployee In _JobTeam

                            If CType(CType(TeamMember.ManagerType, Integer), ManagerType) = ManagerType.AccountExecutive Then

                                If TeamMember.EmployeeCode IsNot Nothing Then Me.EmployeeCardAccountExecutive.EmployeeCode = TeamMember.EmployeeCode
                                If TeamMember.Title IsNot Nothing Then Me.EmployeeCardAccountExecutive.EmployeeTitle = TeamMember.Title
                                If TeamMember.DisplayName IsNot Nothing Then Me.EmployeeCardAccountExecutive.EmployeeName = TeamMember.DisplayName
                                If TeamMember.BinaryImage IsNot Nothing Then Me.EmployeeCardAccountExecutive.EmployeePicture = TeamMember.BinaryImage
                                If TeamMember.TaskCount <> Nothing Then Me.EmployeeCardAccountExecutive.TaskCount = TeamMember.TaskCount
                                If TeamMember.TotalHours <> Nothing Then Me.EmployeeCardAccountExecutive.TotalHours = TeamMember.TotalHours
                                If TeamMember.ActualHours <> Nothing Then Me.EmployeeCardAccountExecutive.ActualHours = TeamMember.ActualHours
                                If TeamMember.EmailGroupCode IsNot Nothing Then Me.EmployeeCardAccountExecutive.EmailGroupCode = TeamMember.EmailGroupCode
                                If TeamMember.TrafficColumnCode IsNot Nothing Then Me.EmployeeCardAccountExecutive.TrafficColumnCode = TeamMember.TrafficColumnCode
                                If TeamMember.ManagerType IsNot Nothing Then Me.EmployeeCardAccountExecutive.ManagerType = TeamMember.ManagerType

                            End If

                        Next

                    Case LoadType.ScheduleAssignments

                        Dim SaveText As String = "Drag an employee name from the list on the left onto this icon to set the employee as the "
                        Dim RemoveText As String = "Remove current "

                        For Each TeamMember As AdvantageFramework.Database.Classes.JobTeamEmployee In _JobTeam

                            Select Case TeamMember.TrafficColumnCode
                                Case "TR_1"

                                    If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardAssignment1.EmployeeCode = TeamMember.EmployeeCode

                                    If TeamMember.Title Is Nothing Then TeamMember.Title = "Assignment 1"
                                    Me.ImageButtonAssignment1Remove.ToolTip = RemoveText & TeamMember.Title
                                    Me.ImageButtonAssignment1Save.ToolTip = SaveText & TeamMember.Title
                                    Me.Employee_CardAssignment1.EmployeeTitle = TeamMember.Title

                                    If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardAssignment1.EmployeeName = TeamMember.DisplayName
                                    If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardAssignment1.EmployeePicture = TeamMember.BinaryImage
                                    If TeamMember.TaskCount <> Nothing Then Me.Employee_CardAssignment1.TaskCount = TeamMember.TaskCount
                                    If TeamMember.TotalHours <> Nothing Then Me.Employee_CardAssignment1.TotalHours = TeamMember.TotalHours
                                    If TeamMember.ActualHours <> Nothing Then Me.Employee_CardAssignment1.ActualHours = TeamMember.ActualHours
                                    If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardAssignment1.EmailGroupCode = TeamMember.EmailGroupCode
                                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardAssignment1.TrafficColumnCode = TeamMember.TrafficColumnCode
                                    If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardAssignment1.ManagerType = TeamMember.ManagerType

                                Case "TR_2"

                                    If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardAssignment2.EmployeeCode = TeamMember.EmployeeCode

                                    If TeamMember.Title Is Nothing Then TeamMember.Title = "Assignment 2"
                                    Me.ImageButtonAssignment2Remove.ToolTip = RemoveText & TeamMember.Title
                                    Me.ImageButtonAssignment2Save.ToolTip = SaveText & TeamMember.Title
                                    Me.Employee_CardAssignment2.EmployeeTitle = TeamMember.Title

                                    If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardAssignment2.EmployeeName = TeamMember.DisplayName
                                    If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardAssignment2.EmployeePicture = TeamMember.BinaryImage
                                    If TeamMember.TaskCount <> Nothing Then Me.Employee_CardAssignment2.TaskCount = TeamMember.TaskCount
                                    If TeamMember.TotalHours <> Nothing Then Me.Employee_CardAssignment2.TotalHours = TeamMember.TotalHours
                                    If TeamMember.ActualHours <> Nothing Then Me.Employee_CardAssignment2.ActualHours = TeamMember.ActualHours
                                    If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardAssignment2.EmailGroupCode = TeamMember.EmailGroupCode
                                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardAssignment2.TrafficColumnCode = TeamMember.TrafficColumnCode
                                    If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardAssignment2.ManagerType = TeamMember.ManagerType

                                Case "TR_3"

                                    If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardAssignment3.EmployeeCode = TeamMember.EmployeeCode

                                    If TeamMember.Title Is Nothing Then TeamMember.Title = "Assignment 3"
                                    Me.ImageButtonAssignment3Remove.ToolTip = RemoveText & TeamMember.Title
                                    Me.ImageButtonAssignment3Save.ToolTip = SaveText & TeamMember.Title
                                    Me.Employee_CardAssignment3.EmployeeTitle = TeamMember.Title

                                    If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardAssignment3.EmployeeName = TeamMember.DisplayName
                                    If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardAssignment3.EmployeePicture = TeamMember.BinaryImage
                                    If TeamMember.TaskCount <> Nothing Then Me.Employee_CardAssignment3.TaskCount = TeamMember.TaskCount
                                    If TeamMember.TotalHours <> Nothing Then Me.Employee_CardAssignment3.TotalHours = TeamMember.TotalHours
                                    If TeamMember.ActualHours <> Nothing Then Me.Employee_CardAssignment3.ActualHours = TeamMember.ActualHours
                                    If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardAssignment3.EmailGroupCode = TeamMember.EmailGroupCode
                                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardAssignment3.TrafficColumnCode = TeamMember.TrafficColumnCode
                                    If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardAssignment3.ManagerType = TeamMember.ManagerType

                                Case "TR_4"

                                    If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardAssignment4.EmployeeCode = TeamMember.EmployeeCode

                                    If TeamMember.Title Is Nothing Then TeamMember.Title = "Assignment 4"
                                    Me.ImageButtonAssignment4Remove.ToolTip = RemoveText & TeamMember.Title
                                    Me.ImageButtonAssignment4Save.ToolTip = SaveText & TeamMember.Title
                                    Me.Employee_CardAssignment4.EmployeeTitle = TeamMember.Title

                                    If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardAssignment4.EmployeeName = TeamMember.DisplayName
                                    If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardAssignment4.EmployeePicture = TeamMember.BinaryImage
                                    If TeamMember.TaskCount <> Nothing Then Me.Employee_CardAssignment4.TaskCount = TeamMember.TaskCount
                                    If TeamMember.TotalHours <> Nothing Then Me.Employee_CardAssignment4.TotalHours = TeamMember.TotalHours
                                    If TeamMember.ActualHours <> Nothing Then Me.Employee_CardAssignment4.ActualHours = TeamMember.ActualHours
                                    If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardAssignment4.EmailGroupCode = TeamMember.EmailGroupCode
                                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardAssignment4.TrafficColumnCode = TeamMember.TrafficColumnCode
                                    If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardAssignment4.ManagerType = TeamMember.ManagerType

                                Case "TR_5"

                                    If TeamMember.EmployeeCode IsNot Nothing Then Me.Employee_CardAssignment5.EmployeeCode = TeamMember.EmployeeCode

                                    If TeamMember.Title Is Nothing Then TeamMember.Title = "Assignment 5"
                                    Me.ImageButtonAssignment5Remove.ToolTip = RemoveText & TeamMember.Title
                                    Me.ImageButtonAssignment5Save.ToolTip = SaveText & TeamMember.Title
                                    Me.Employee_CardAssignment5.EmployeeTitle = TeamMember.Title

                                    If TeamMember.DisplayName IsNot Nothing Then Me.Employee_CardAssignment5.EmployeeName = TeamMember.DisplayName
                                    If TeamMember.BinaryImage IsNot Nothing Then Me.Employee_CardAssignment5.EmployeePicture = TeamMember.BinaryImage
                                    If TeamMember.TaskCount <> Nothing Then Me.Employee_CardAssignment5.TaskCount = TeamMember.TaskCount
                                    If TeamMember.TotalHours <> Nothing Then Me.Employee_CardAssignment5.TotalHours = TeamMember.TotalHours
                                    If TeamMember.ActualHours <> Nothing Then Me.Employee_CardAssignment5.ActualHours = TeamMember.ActualHours
                                    If TeamMember.EmailGroupCode IsNot Nothing Then Me.Employee_CardAssignment5.EmailGroupCode = TeamMember.EmailGroupCode
                                    If TeamMember.TrafficColumnCode IsNot Nothing Then Me.Employee_CardAssignment5.TrafficColumnCode = TeamMember.TrafficColumnCode
                                    If TeamMember.ManagerType IsNot Nothing Then Me.Employee_CardAssignment5.ManagerType = TeamMember.ManagerType

                            End Select

                        Next

                End Select

            End If

        End Using

    End Sub

    Private Sub LoadEmployeeList(ByVal DepartmentTeamCode As String, ByVal IsLookingUpAccountExecutive As Boolean, ByVal OnlyShowActive As Boolean)

        Me._EmployeeList = LoadEmployeeSimple(_Session, "", DepartmentTeamCode, "", Me._JobNumber, Me._JobComponentNumber, -1, IsLookingUpAccountExecutive, False, False, OnlyShowActive)
        If Me._EmployeeList Is Nothing Then Me._EmployeeList = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple)

    End Sub
    Private Function LoadSimpleEmployee(ByVal EmployeeCode As String, ByVal OnlyShowActive As Boolean) As AdvantageFramework.Database.Entities.EmployeeSimple

        LoadSimpleEmployee = LoadEmployeeSimple(_Session, EmployeeCode, "", "", Me._JobNumber, Me._JobComponentNumber, -1, False, False, False, OnlyShowActive).SingleOrDefault

    End Function
    Private Function LoadEmployeeSimple(ByVal Session As AdvantageFramework.Security.Session,
                                        ByVal EmployeeCode As String,
                                        ByVal DepartmentTeamCode As String,
                                        ByVal EmailGroupCode As String,
                                        ByVal JobNumber As Integer,
                                        ByVal JobComponentNumber As Short,
                                        ByVal TaskSequenceNumber As Short,
                                        ByVal IsLookingUpAccountExecutive As Boolean,
                                        ByVal FilterByTaskRoles As Boolean,
                                        ByVal FilterByJobEmailGroup As Boolean,
                                        ByVal OnlyShowActive As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple)

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 10)
                Dim SqlParameterEmployeeCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterDepartmentTeamCode As New System.Data.SqlClient.SqlParameter("@DP_TM_CODE", SqlDbType.VarChar, 6)
                Dim SqlParameterEmailGroupCode As New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)
                Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                Dim SqlParameterTaskSequenceNumber As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                Dim SqlParameterIsLookingUpAccountExecutive As New System.Data.SqlClient.SqlParameter("@IS_AE", SqlDbType.Bit)
                Dim SqlParameterFilterByTaskRoles As New System.Data.SqlClient.SqlParameter("@IS_ROLE", SqlDbType.Bit)
                Dim SqlParameterFilterByJobEmailGroup As New System.Data.SqlClient.SqlParameter("@IS_EMAIL_GROUP", SqlDbType.Bit)
                Dim SqlParameterOnlyShowActive As New System.Data.SqlClient.SqlParameter("@ONLY_ACTIVE", SqlDbType.Bit)

                SqlParameterUserCode.Value = _Session.UserCode
                If EmployeeCode = "" Then

                    SqlParameterEmployeeCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmployeeCode.Value = EmployeeCode

                End If
                If DepartmentTeamCode = "" Then

                    SqlParameterDepartmentTeamCode.Value = System.DBNull.Value

                Else

                    SqlParameterDepartmentTeamCode.Value = DepartmentTeamCode

                End If
                If EmailGroupCode = "" Then

                    SqlParameterEmailGroupCode.Value = System.DBNull.Value

                Else

                    SqlParameterEmailGroupCode.Value = EmailGroupCode

                End If
                If JobNumber = 0 Then

                    SqlParameterJobNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobNumber.Value = JobNumber

                End If
                If JobComponentNumber = 0 Then

                    SqlParameterJobComponentNumber.Value = System.DBNull.Value

                Else

                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                End If
                If TaskSequenceNumber = -1 Then

                    SqlParameterTaskSequenceNumber.Value = System.DBNull.Value

                Else

                    SqlParameterTaskSequenceNumber.Value = TaskSequenceNumber

                End If

                SqlParameterIsLookingUpAccountExecutive.Value = IsLookingUpAccountExecutive
                SqlParameterFilterByTaskRoles.Value = FilterByTaskRoles
                SqlParameterFilterByJobEmailGroup.Value = FilterByJobEmailGroup
                SqlParameterOnlyShowActive.Value = OnlyShowActive

                LoadEmployeeSimple = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.EmployeeSimple)("EXEC advsp_load_employee_simple @USER_CODE, @EMP_CODE, @DP_TM_CODE, @EMAIL_GR_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @SEQ_NBR, @IS_AE, @IS_ROLE, @IS_EMAIL_GROUP, @ONLY_ACTIVE",
                                                                                                                         SqlParameterUserCode,
                                                                                                                         SqlParameterEmployeeCode,
                                                                                                                         SqlParameterDepartmentTeamCode,
                                                                                                                         SqlParameterEmailGroupCode,
                                                                                                                         SqlParameterJobNumber,
                                                                                                                         SqlParameterJobComponentNumber,
                                                                                                                         SqlParameterTaskSequenceNumber,
                                                                                                                         SqlParameterIsLookingUpAccountExecutive,
                                                                                                                         SqlParameterFilterByTaskRoles,
                                                                                                                         SqlParameterFilterByJobEmailGroup,
                                                                                                                         SqlParameterOnlyShowActive).ToList

            End Using

        Catch ex As Exception

            Return Nothing

        End Try

    End Function

    Private Sub SetEditButtons(ByVal IsEdit As Boolean)

        Me.ImageButtonEdit.Visible = Not IsEdit
        Me.ImageButtonCancel.Visible = IsEdit

    End Sub

    Private Sub SetScheduleButtons()
        Dim Schedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim x As Integer = Schedule.CheckExistsClosed(Me._JobNumber, Me._JobComponentNumber)
        Select Case x
            Case 0, -2

                Me.HasSchedule = True

            Case -1

                Me.HasSchedule = False

        End Select

        Me.RadToolBarTeam.FindItemByValue("Manager").Visible = Me.HasSchedule
        Me.RadToolBarTeam.FindItemByValue("ScheduleAssignments").Visible = Me.HasSchedule
        Me.RadToolBarTeam.FindItemByValue("ScheduleTaskAssignments").Visible = Me.HasSchedule
        Me.ImageButtonCancel.ToolTip = "Click when you are done editing"
        Me.ImageButtonSaveAlertGroup.ToolTip = "Click to save selected alert group"
        Me.DivScheduleManager.Visible = Me.HasSchedule
        Me.RadToolBarTeam.FindItemByValue("Manager").Text = Schedule.GetManagerLabel()

    End Sub

#End Region

#Region " Managers "

#Region " Controls "

    Private Sub ImageButtonManagerRemove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonManagerRemove.Click
        Me.RemoveManager()
    End Sub
    Private Sub ImageButtonManagerSave_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonManagerSave.Click

        Me.SaveManager()
        Me.CompleteCancel()

    End Sub
    Private Sub RadListBoxEditManagersEmployees_Dropped(sender As Object, e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxEditManagersEmployees.Dropped

        Me.SaveManager()

    End Sub

#End Region

#Region " Methods "

    Private Sub LoadManagerList()

        Me.LoadEmployeeList("", False, True)

    End Sub
    Private Sub RemoveManager()

        SaveManager(True)

    End Sub
    Private Sub SaveManager(Optional ByVal Remove As Boolean = False)

        If (Remove = False AndAlso Me.RadListBoxEditManagersEmployees.SelectedItem IsNot Nothing) OrElse Remove = True Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic = Nothing
                Dim ManagerColumn As String = String.Empty

                Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

                Try

                    ManagerColumn = DbContext.Database.SqlQuery(Of String)("SELECT UPPER(RTRIM(LTRIM(CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, '') AS VARCHAR(20))))) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL';").SingleOrDefault

                Catch ex As Exception
                    ManagerColumn = String.Empty
                End Try

                If Schedule IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ManagerColumn) = False Then

                    If Remove = True Then

                        Select Case ManagerColumn.ToUpper
                            Case "TR_TITLE1"

                                Schedule.Assign1 = Nothing

                            Case "TR_TITLE2"

                                Schedule.Assign2 = Nothing

                            Case "TR_TITLE3"

                                Schedule.Assign3 = Nothing

                            Case "TR_TITLE4"

                                Schedule.Assign4 = Nothing

                            Case "TR_TITLE5"

                                Schedule.Assign5 = Nothing

                        End Select

                    Else

                        Select Case ManagerColumn.ToUpper
                            Case "TR_TITLE1"

                                Schedule.Assign1 = Me.RadListBoxEditManagersEmployees.SelectedItem.Value

                            Case "TR_TITLE2"

                                Schedule.Assign2 = Me.RadListBoxEditManagersEmployees.SelectedItem.Value

                            Case "TR_TITLE3"

                                Schedule.Assign3 = Me.RadListBoxEditManagersEmployees.SelectedItem.Value

                            Case "TR_TITLE4"

                                Schedule.Assign4 = Me.RadListBoxEditManagersEmployees.SelectedItem.Value

                            Case "TR_TITLE5"

                                Schedule.Assign5 = Me.RadListBoxEditManagersEmployees.SelectedItem.Value

                        End Select

                    End If

                    AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, Schedule)

                End If

            End Using

        End If

        Me._LoadType = LoadType.Manager
        Me.LoadEditData()

    End Sub

#End Region

#End Region

#Region " Account Executive "

#Region " Controls "

    Private Sub ImageButtonAccountExecutiveRemove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAccountExecutiveRemove.Click

        Me.RemoveAccountExecutive()

    End Sub
    Private Sub ImageButtonAccountExecutiveSave_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAccountExecutiveSave.Click

        Me.SaveAccountExecutive()
        Me.CompleteCancel()

    End Sub
    Private Sub RadListBoxAccountExecutives_Dropped(sender As Object, e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxAccountExecutives.Dropped

        Me.SaveAccountExecutive()

    End Sub

#End Region
#Region " Methods "

    Private Sub LoadAccountExecutiveList()

        Me.LoadEmployeeList("", True, True)

    End Sub
    Private Sub RemoveAccountExecutive()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing

            jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

            If jc IsNot Nothing Then

                jc.AccountExecutiveEmployeeCode = Nothing
                AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, jc)

            End If

        End Using

        Me._LoadType = LoadType.AccountExecutive
        Me.LoadEditData()

    End Sub
    Private Sub SaveAccountExecutive()

        If Me.RadListBoxAccountExecutives.SelectedItem IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing

                jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

                If jc IsNot Nothing Then

                    jc.AccountExecutiveEmployeeCode = Me.RadListBoxAccountExecutives.SelectedItem.Value
                    AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, jc)

                    Dim SessionKeyJobNumber As String = "GetJobInfo" & _JobNumber.ToString().PadLeft(6, "0")
                    Dim SessionKeyJobComponentNbr As String = "GetJobComponentInfo" & _JobNumber.ToString().PadLeft(6, "0") & _JobComponentNumber.ToString.PadLeft(2, "0")
                    HttpContext.Current.Session(SessionKeyJobNumber) = Nothing
                    HttpContext.Current.Session(SessionKeyJobComponentNbr) = Nothing

                End If

            End Using

        End If

        Me._LoadType = LoadType.AccountExecutive
        Me.LoadEditData()

    End Sub

#End Region

#End Region

#Region " Schedule Assignments "

#Region " Controls "

    Private Sub ImageButtonAssignment1Remove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment1Remove.Click
        Me.RemoveAssignment(1)
    End Sub
    Private Sub ImageButtonAssignment2Remove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment2Remove.Click
        Me.RemoveAssignment(2)
    End Sub
    Private Sub ImageButtonAssignment3Remove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment3Remove.Click
        Me.RemoveAssignment(3)
    End Sub
    Private Sub ImageButtonAssignment4Remove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment4Remove.Click
        Me.RemoveAssignment(4)
    End Sub
    Private Sub ImageButtonAssignment5Remove_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment5Remove.Click
        Me.RemoveAssignment(5)
    End Sub
    Private Sub ImageButtonAssignment1Save_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment1Save.Click
        Me.SaveAssignment(1)
    End Sub
    Private Sub ImageButtonAssignment2Save_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment2Save.Click
        Me.SaveAssignment(2)
    End Sub
    Private Sub ImageButtonAssignment3Save_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment3Save.Click
        Me.SaveAssignment(3)
    End Sub
    Private Sub ImageButtonAssignment4Save_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment4Save.Click
        Me.SaveAssignment(4)
    End Sub
    Private Sub ImageButtonAssignment5Save_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAssignment5Save.Click
        Me.SaveAssignment(5)
    End Sub
    Private Sub RadListBoxEditScheduleAssignmentsEmployees_Dropped(sender As Object, e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxEditScheduleAssignmentsEmployees.Dropped

        Dim DroppedOnID As String = e.HtmlElementID

        If DroppedOnID.ToLower().Contains("assignment1") = True Then
            Me.SaveAssignment(1)
        ElseIf DroppedOnID.ToLower().Contains("assignment2") = True Then
            Me.SaveAssignment(2)
        ElseIf DroppedOnID.ToLower().Contains("assignment3") = True Then
            Me.SaveAssignment(3)
        ElseIf DroppedOnID.ToLower().Contains("assignment4") = True Then
            Me.SaveAssignment(4)
        ElseIf DroppedOnID.ToLower().Contains("assignment5") = True Then
            Me.SaveAssignment(5)
        End If

    End Sub

#End Region
#Region " Methods "

    Private Sub SaveAssignment(ByVal AssignmentNumber As Short)

        If Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim jt As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                jt = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

                If jt IsNot Nothing Then

                    Select Case AssignmentNumber
                        Case 1
                            jt.Assign1 = Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem.Value
                        Case 2
                            jt.Assign2 = Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem.Value
                        Case 3
                            jt.Assign3 = Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem.Value
                        Case 4
                            jt.Assign4 = Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem.Value
                        Case 5
                            jt.Assign5 = Me.RadListBoxEditScheduleAssignmentsEmployees.SelectedItem.Value
                    End Select

                    AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, jt)

                End If

            End Using

            Me._LoadType = LoadType.ScheduleAssignments
            Me.LoadEditData()

        End If

    End Sub
    Private Sub RemoveAssignment(ByVal AssignmentNumber As Short)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim jt As AdvantageFramework.Database.Entities.JobTraffic = Nothing

            jt = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber)

            If jt IsNot Nothing Then

                Select Case AssignmentNumber
                    Case 1
                        jt.Assign1 = Nothing
                    Case 2
                        jt.Assign2 = Nothing
                    Case 3
                        jt.Assign3 = Nothing
                    Case 4
                        jt.Assign4 = Nothing
                    Case 5
                        jt.Assign5 = Nothing
                End Select

                AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, jt)

            End If

        End Using

        Me._LoadType = LoadType.ScheduleAssignments
        Me.LoadEditData()

    End Sub

#End Region

#End Region

#Region " Task Assignments "

#Region " Controls "

    Private Sub RadioButtonListTaskEmployeeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListTaskEmployeeFilter.SelectedIndexChanged

        If Me.RadioButtonListTaskEmployeeFilter.SelectedItem.Value <> "department" Then

            Me.DivTaskEmployeeFilterRadComboBox.Visible = False
            Me.LoadTaskEmployees()

        Else

            Me.DivTaskEmployeeFilterRadComboBox.Visible = True

            Me.RadComboBoxTaskEmployeeFilter.Items.Clear()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadComboBoxTaskEmployeeFilter.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                Me.RadComboBoxTaskEmployeeFilter.DataValueField = "Code"
                Me.RadComboBoxTaskEmployeeFilter.DataTextField = "Description"
                Me.RadComboBoxTaskEmployeeFilter.DataBind()
                Me.RadComboBoxTaskEmployeeFilter.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            End Using

        End If

    End Sub
    Private Sub RadComboBoxTaskEmployeeFilter_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTaskEmployeeFilter.SelectedIndexChanged

        Select Case Me.RadioButtonListTaskEmployeeFilter.SelectedItem.Value
            Case "department"

                Me.LoadTaskEmployees()

        End Select
    End Sub

    Private Sub RadListBoxEditScheduleTasksEmployees_ItemCheck(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxEditScheduleTasksEmployees.ItemCheck

        Me.SelectTaskEmployee(e.Item)

    End Sub
    Private Sub RadListBoxEditScheduleTasksEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxEditScheduleTasksEmployees.SelectedIndexChanged

        Dim ListItem As Telerik.Web.UI.RadListBoxItem
        ListItem = Me.RadListBoxEditScheduleTasksEmployees.SelectedItem

        If ListItem IsNot Nothing Then

            ListItem.Checked = Not ListItem.Checked
            Me.SelectTaskEmployee(ListItem)

        End If

    End Sub

    Private Sub RadListBoxEditScheduleTasksTaskList_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxEditScheduleTasksTaskList.ItemDataBound

        Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = e.Item.DataItem

        If Task IsNot Nothing Then

            'Dim StatusCodeDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivStatusCode")

            'If StatusCodeDiv IsNot Nothing AndAlso Task.StatusCode IsNot Nothing Then

            '    Select Case Task.StatusCode.Trim().ToUpper()
            '        Case "P"
            '            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StatusCodeDiv, "task-priority-pending")
            '        Case "A"
            '            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StatusCodeDiv, "task-priority-active")
            '        Case "H"
            '            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StatusCodeDiv, "alert-priority-high")
            '        Case "L"
            '            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StatusCodeDiv, "alert-priority-low")
            '        Case Else
            '            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(StatusCodeDiv, "background-color-sidebar")
            '    End Select

            'End If
            Dim PriorityColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivPriorityColor")
            Dim PriorityImage As Web.UI.WebControls.Image = e.Item.FindControl("ImagePriority")

            If PriorityColorDiv IsNot Nothing AndAlso PriorityImage IsNot Nothing Then

                PriorityImage.ToolTip = ""

                Try

                    If String.IsNullOrWhiteSpace(Task.StatusCode) = False Then

                        Select Case Task.StatusCode.Trim().ToUpper()
                            Case "H"
                                PriorityImage.ToolTip = "High Priority"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
                            Case "L"
                                PriorityImage.ToolTip = "Low Priority"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
                            Case "A"
                                PriorityImage.ToolTip = "Active"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-active")
                            Case "P"
                                PriorityImage.ToolTip = "Projected"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-pending")
                        End Select

                    End If

                Catch ex As Exception

                    PriorityImage.ToolTip = "Projected"
                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "task-priority-pending")

                End Try

            End If

            If Task.Description IsNot Nothing Then

                Dim DescriptionLabel As Label = e.Item.FindControl("LabelDescription")
                If DescriptionLabel IsNot Nothing Then

                    DescriptionLabel.Text = Task.Description

                End If

            Else

                Dim DescriptionDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDescription")
                If DescriptionDiv IsNot Nothing Then

                    AdvantageFramework.Web.Presentation.Controls.DivHide(DescriptionDiv)

                End If

            End If

            Dim StartDueLabel As Label = e.Item.FindControl("LabelStartDue")

            If StartDueLabel IsNot Nothing Then

                If Task.StartDate Is Nothing AndAlso Task.DueDate Is Nothing Then

                    Dim StartDueDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivStartDue")
                    If StartDueDiv IsNot Nothing Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(StartDueDiv)

                    End If

                ElseIf Task.StartDate Is Nothing AndAlso Task.DueDate IsNot Nothing Then

                    StartDueLabel.Text = "Due: " & CType(Task.DueDate, Date).ToShortDateString()

                ElseIf Task.StartDate IsNot Nothing AndAlso Task.DueDate Is Nothing Then

                    StartDueLabel.Text = "Start: " & CType(Task.StartDate, Date).ToShortDateString()

                ElseIf Task.StartDate IsNot Nothing AndAlso Task.DueDate IsNot Nothing Then

                    StartDueLabel.Text = "Start: " & CType(Task.StartDate, Date).ToShortDateString() & ", Due: " & CType(Task.StartDate, Date).ToShortDateString()

                End If

                StartDueLabel.ToolTip = StartDueLabel.Text

                If Task.DueDate IsNot Nothing Then

                    If CType(Task.DueDate, Date) = Today.Date Then

                        StartDueLabel.CssClass = "task-due-today"
                        StartDueLabel.ToolTip = "Task due today"

                    ElseIf CType(Task.DueDate, Date) < Today.Date Then

                        StartDueLabel.CssClass = "task-due-overdue"
                        StartDueLabel.ToolTip = "Task overdue"

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub RadListBoxEditScheduleTasksTaskList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxEditScheduleTasksTaskList.SelectedIndexChanged

        Me.LoadTaskEmployees()

    End Sub

#End Region
#Region " Methods "

    Private Sub LoadTaskEmployees()

        'Me.LoadEmployeeList("", False, True)
        Me.RadListBoxEditScheduleTasksEmployees.Items.Clear()

        If Me.RadListBoxEditScheduleTasksTaskList.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value) Then

            Select Case Me.RadioButtonListTaskEmployeeFilter.SelectedValue
                Case "role"

                    Me._EmployeeList = LoadEmployeeSimple(Me._Session, "", "", "", Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value, False, True, False, True)

                Case "alert_group"

                    Me._EmployeeList = LoadEmployeeSimple(Me._Session, "", "", "", Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value, False, False, True, True)

                Case "department"

                    If Me.RadComboBoxTaskEmployeeFilter.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxTaskEmployeeFilter.SelectedIndex > 0 Then

                        Me._EmployeeList = LoadEmployeeSimple(Me._Session, "", Me.RadComboBoxTaskEmployeeFilter.SelectedItem.Value, "", Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value, False, False, False, True)

                    End If

                Case "all"

                    Me._EmployeeList = LoadEmployeeSimple(Me._Session, "", "", "", 0, 0, -1, False, False, False, True)

            End Select

            If Me._EmployeeList Is Nothing Then Me._EmployeeList = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeSimple)

            Me.RadListBoxEditScheduleTasksEmployees.DataSource = _EmployeeList
            Me.RadListBoxEditScheduleTasksEmployees.DataValueField = "Code"
            Me.RadListBoxEditScheduleTasksEmployees.DataTextField = "FullName"
            Me.RadListBoxEditScheduleTasksEmployees.DataBind()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim TaskEmployees As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee) = Nothing

                TaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext, Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value).ToList()

                If TaskEmployees IsNot Nothing Then

                    Dim EmployeeInList As Telerik.Web.UI.RadListBoxItem

                    For Each TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee In TaskEmployees

                        EmployeeInList = Me.RadListBoxEditScheduleTasksEmployees.FindItemByValue(TaskEmployee.EmployeeCode)

                        If EmployeeInList IsNot Nothing Then

                            EmployeeInList.Selected = True
                            EmployeeInList.Checked = True

                        End If

                    Next

                End If

            End Using

        End If

    End Sub
    Private Sub SelectTaskEmployee(ByRef ListItem As Telerik.Web.UI.RadListBoxItem)
        If Me.RadListBoxEditScheduleTasksTaskList.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value) Then

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                If ListItem.Checked = True Then

                    'add
                    TaskEmployee = New AdvantageFramework.Database.Entities.JobComponentTaskEmployee

                    TaskEmployee.JobNumber = Me._JobNumber
                    TaskEmployee.JobComponentNumber = Me._JobComponentNumber
                    TaskEmployee.SequenceNumber = Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value
                    TaskEmployee.EmployeeCode = ListItem.Value

                    Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = ListItem.DataItem

                    If Task Is Nothing Then

                        Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value)

                    End If
                    If Task IsNot Nothing Then

                        TaskEmployee.Hours = Task.Hours

                    End If

                    If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, TaskEmployee) = False Then

                        Me.ShowMessage("Error adding new employee to task")

                    Else

                        Me.LoadTaskEmployees()

                    End If

                Else

                    'delete
                    TaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Me._JobNumber, Me._JobComponentNumber, Me.RadListBoxEditScheduleTasksTaskList.SelectedItem.Value, ListItem.Value)

                    If TaskEmployee IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, TaskEmployee) = False Then

                            Me.ShowMessage("Error removing employee from task")

                        Else

                            Me.LoadTaskEmployees()

                        End If

                    End If

                End If

            End Using

        End If

    End Sub


#End Region

#End Region

#End Region

End Class

' ''REFACTOR!
''Public Function LoadByJobAndComponentNumber(ByRef DbContext As AdvantageFramework.Database.DbContext, _
''                                            ByVal Type As LoadType, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of TeamMember)

''    Dim TeamMembers As New Generic.List(Of TeamMember)

''    Dim SqlParameterTeamType As New System.Data.SqlClient.SqlParameter("@TEAM_TYPE", SqlDbType.SmallInt)
''    Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
''    Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)

''    SqlParameterTeamType.Value = CType(Type, Integer)
''    SqlParameterJobNumber.Value = JobNumber
''    SqlParameterJobComponentNumber.Value = JobComponentNumber

''    TeamMembers = DbContext.Database.SqlQuery(Of TeamMember)("EXEC advsp_job_team_load @TEAM_TYPE, @JOB_NUMBER, @JOB_COMPONENT_NBR;", _
''                                                                 SqlParameterTeamType, _
''                                                                 SqlParameterJobNumber, _
''                                                                 SqlParameterJobComponentNumber).ToList()

''    If TeamMembers Is Nothing Then TeamMembers = New Generic.List(Of TeamMember)

''    LoadByJobAndComponentNumber = TeamMembers

''End Function

' ''REFACTOR!
''<Serializable()> _
''Public Class TeamMember

''    Public TeamTypeID As Nullable(Of Short) = Nothing
''    Public EmployeeCode As String = String.Empty
''    Public Title As String = String.Empty
''    Public FirstName As String = String.Empty
''    Public LastName As String = String.Empty
''    Public MiddleInitial As String = String.Empty
''    Public BinaryImage As Byte() = Nothing
''    Public Nickname As String = String.Empty
''    Public TaskCount As Integer = 0
''    Public TotalHours As Decimal = 0
''    Public ActualHours As Decimal = 0
''    Public DisplayName As String = String.Empty
''    Public EmailGroupCode As String = String.Empty
''    Public TrafficColumnCode As String = String.Empty
''    Public ManagerType As String = String.Empty

''    Sub New()

''    End Sub

''End Class
