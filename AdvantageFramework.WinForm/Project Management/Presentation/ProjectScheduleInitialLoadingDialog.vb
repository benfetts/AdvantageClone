Namespace ProjectManagement.Presentation

    Public Class ProjectScheduleInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum PODetailCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Client/Division/Product")>
            ClientDivisionProduct = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Job/Job Comp")>
            JobAndComponent = 5
        End Enum

#End Region

#Region " Variables "

        Private _PhaseID As Integer? = Nothing
        Private _RoleCode As String = Nothing
        Private _TaskCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _DateCutoff As System.DateTime? = Nothing
        Private _OnlyPendingTasks As Boolean? = Nothing
        Private _ExcludeProjectedTasks As Boolean? = Nothing
        Private _IncludeCompletedTasks As Boolean? = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property PhaseID As Integer?
            Get
                PhaseID = _PhaseID
            End Get
        End Property
        Public ReadOnly Property RoleCode As String
            Get
                RoleCode = _RoleCode
            End Get
        End Property
        Public ReadOnly Property TaskCode As String
            Get
                TaskCode = _TaskCode
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property DateCutoff As Date?
            Get
                DateCutoff = _DateCutoff
            End Get
        End Property
        Public ReadOnly Property OnlyPendingTasks As Boolean?
            Get
                OnlyPendingTasks = _OnlyPendingTasks
            End Get
        End Property
        Public ReadOnly Property ExcludeProjectedTasks As Boolean?
            Get
                ExcludeProjectedTasks = _ExcludeProjectedTasks
            End Get
        End Property
        Public ReadOnly Property IncludeCompletedTasks As Boolean?
            Get
                IncludeCompletedTasks = _IncludeCompletedTasks
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef PhaseID As Integer?, ByRef RoleCode As String, ByRef TaskCode As String, _
                        ByRef EmployeeCode As String, ByRef DateCutoff As Date?, ByRef OnlyPendingTasks As Boolean?, _
                        ByRef ExcludeProjectedTasks As Boolean?, ByRef IncludeCompletedTasks As Boolean?)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            _PhaseID = PhaseID
            _RoleCode = RoleCode
            _TaskCode = TaskCode
            _EmployeeCode = EmployeeCode
            _DateCutoff = DateCutoff
            _OnlyPendingTasks = OnlyPendingTasks
            _ExcludeProjectedTasks = ExcludeProjectedTasks
            _IncludeCompletedTasks = IncludeCompletedTasks

            ' Add any initialization after the InitializeComponent() call.
            SearchableComboBoxForm_Role.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Task.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Employee.ByPassUserEntryChanged = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef PhaseID As Integer?, ByRef RoleCode As String, ByRef TaskCode As String, _
                                              ByRef EmployeeCode As String, ByRef DateCutoff As Date?, ByRef OnlyPendingTasks As Boolean?, _
                                              ByRef ExcludeProjectedTasks As Boolean?, ByRef IncludeCompletedTasks As Boolean?) As Windows.Forms.DialogResult

            'objects
            Dim ProjectScheduleInitialLoadingDialog As AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleInitialLoadingDialog = Nothing

            ProjectScheduleInitialLoadingDialog = New AdvantageFramework.ProjectManagement.Presentation.ProjectScheduleInitialLoadingDialog(PhaseID, RoleCode, TaskCode, _
                                                                                                                                            EmployeeCode, DateCutoff, OnlyPendingTasks, _
                                                                                                                                            ExcludeProjectedTasks, IncludeCompletedTasks)

            ShowFormDialog = ProjectScheduleInitialLoadingDialog.ShowDialog()

            PhaseID = ProjectScheduleInitialLoadingDialog.PhaseID
            RoleCode = ProjectScheduleInitialLoadingDialog.RoleCode
            TaskCode = ProjectScheduleInitialLoadingDialog.TaskCode
            EmployeeCode = ProjectScheduleInitialLoadingDialog.EmployeeCode
            DateCutoff = ProjectScheduleInitialLoadingDialog.DateCutoff
            OnlyPendingTasks = ProjectScheduleInitialLoadingDialog.OnlyPendingTasks
            ExcludeProjectedTasks = ProjectScheduleInitialLoadingDialog.ExcludeProjectedTasks
            IncludeCompletedTasks = ProjectScheduleInitialLoadingDialog.IncludeCompletedTasks

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProjectScheduleInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim PhaseList As Generic.Dictionary(Of Integer, String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    PhaseList = New Generic.Dictionary(Of Integer, String)

                    PhaseList.Add(0, "[No Phase]")

                    For Each Phase In (From Entity In AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)
                                       Select Entity.ID, Entity.Description).ToList

                        PhaseList.Add(Phase.ID, Phase.Description)

                    Next

                    SearchableComboBoxForm_Phase.DataSource = (From Entity In PhaseList
                                                               Order By Entity.Key Ascending
                                                               Select [ID] = Entity.Key,
                                                                      [Description] = Entity.Value).ToList

                    SearchableComboBoxForm_Role.DataSource = AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                    SearchableComboBoxForm_Task.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                    SearchableComboBoxForm_Employee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, Me.Session.UserCode)
                    DateTimePickerForm_DateCutoff.ValueObject = Nothing
                    CheckBoxForm_ExcludeProjectedTasks.Checked = False
                    CheckBoxForm_IncludeCompletedTasks.Checked = False
                    CheckBoxForm_OnlyPendingTasks.Checked = False

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim PONumbers As Integer() = Nothing
            Dim QueryString As String = ""

            If Me.Validator Then

                If SearchableComboBoxForm_Phase.HasASelectedValue Then

                    _PhaseID = SearchableComboBoxForm_Phase.GetSelectedValue

                    If _PhaseID = 0 Then

                        _PhaseID = -1

                    End If

                End If
                
                If SearchableComboBoxForm_Role.HasASelectedValue Then

                    _RoleCode = SearchableComboBoxForm_Role.GetSelectedValue

                Else

                    _RoleCode = Nothing

                End If

                If SearchableComboBoxForm_Employee.HasASelectedValue Then

                    _EmployeeCode = SearchableComboBoxForm_Employee.GetSelectedValue

                Else

                    _EmployeeCode = Nothing

                End If

                If SearchableComboBoxForm_Task.HasASelectedValue Then

                    _TaskCode = SearchableComboBoxForm_Task.GetSelectedValue

                Else

                    _TaskCode = Nothing

                End If

                If DateTimePickerForm_DateCutoff.ValueObject IsNot Nothing Then

                    _DateCutoff = DateTimePickerForm_DateCutoff.Value

                Else

                    _DateCutoff = Nothing

                End If

                _ExcludeProjectedTasks = CheckBoxForm_ExcludeProjectedTasks.Checked
                _IncludeCompletedTasks = CheckBoxForm_IncludeCompletedTasks.Checked
                _OnlyPendingTasks = CheckBoxForm_OnlyPendingTasks.Checked

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace