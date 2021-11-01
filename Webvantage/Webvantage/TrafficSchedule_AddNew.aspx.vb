Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Partial Public Class TrafficSchedule_AddNew
    Inherits Webvantage.BaseChildPage

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private CurrJobNum As Integer = 0
    Private CurrJobCompNum As Integer = 0
    Private CurrClient As String = String.Empty
    Private CurrDivision As String = String.Empty
    Private CurrProduct As String = String.Empty
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private IsValidJobAndComp As Boolean = False
    Private Msg1 As String = ""
    Private DtJobAndComp As New DataTable

#Region " Page "

    Private Sub TrafficSchedule_AddNew_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent

        'Me.IsLoadedIntoDashboard = qs.IsJobDashboard

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
        Me.PageTitle = "New Project Schedule"

        If Not Page.IsPostBack And Not Me.IsCallback Then

            IsValidJobAndComp = SetJobAndComp()
            ShowForm()
            LoadLookups()

            Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Me.TxtTrafficStatusCode.Text = a.GetValue(AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS, "")

            If Me.TxtTrafficStatusCode.Text <> "" Then

                Dim v As New cValidations(Session("ConnString"))
                If v.ValidateTrafficStatus(Me.TxtTrafficStatusCode.Text) = False Then

                    Me.TxtTrafficStatusCode.Text = ""

                End If

            End If

            Me.PnlCopySchedule.Visible = False

            Me.RadComboBoxTemplate.Items.Clear()
            Me.RadComboBoxTemplate.Items.Add(New Telerik.Web.UI.RadComboBoxItem(("[None]"), ""))

            Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                Dim ProjectTemplates As New Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficTemplate)
                ProjectTemplates = AdvantageFramework.Database.Procedures.JobTrafficTemplate.LoadAllActive(DbContext).ToList()

                If Not ProjectTemplates Is Nothing Then

                    For Each ProjectTemplate As AdvantageFramework.Database.Entities.JobTrafficTemplate In ProjectTemplates

                        Me.RadComboBoxTemplate.Items.Add(New Telerik.Web.UI.RadComboBoxItem(ProjectTemplate.Name, ProjectTemplate.VersionID))

                    Next

                End If

            End Using

            For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.CopyOptions))

                CheckboxListCopyOptions.Items.Add(New System.Web.UI.WebControls.ListItem(EnumObject.Description, EnumObject.Code))

            Next

            CheckRequirements(False)

        End If

    End Sub

#End Region

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Me.CloseThisWindow()

    End Sub
    Private Sub BtnCreateSchedule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreateSchedule.Click

        Dim ErrMSG As String = ""
        Dim ThisJobNum As Integer = 0
        Dim ThisJobCompNum As Integer = 0
        Dim ThisStartDate As String = ""
        Dim ThisDueDate As String = ""
        Dim ThisTrafficCode As String = ""
        Dim ThisPresetCode As String = ""

        If IsNumeric(Me.TxtJobNum.Text) = False Then

            ErrMSG &= "Please enter a valid job number.\n"

        Else

            Try

                ThisJobNum = CType(Me.TxtJobNum.Text, Integer)

            Catch ex As Exception

                ThisJobNum = 0

            End Try

        End If
        If IsNumeric(Me.TxtJobCompNum.Text) = False Then

            ErrMSG &= "Please enter a valid component number.\n"

        Else

            Try

                ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)

            Catch ex As Exception

                ThisJobCompNum = 0

            End Try

        End If

        ThisTrafficCode = Me.TxtTrafficStatusCode.Text.Trim

        Dim boolHasDateErrMsg As Boolean = False

        'Some basic job validation:
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        If ThisJobNum > 0 And ThisJobCompNum > 0 Then

            If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then

                ErrMSG &= "Access to this job/comp is denied.\n"

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ThisJobNum)
                If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, ThisJobNum) = False AndAlso
                    AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                    ErrMSG &= "Access to this job/comp is denied.\n"
                End If
            End Using

        End If
        If myVal.ValidateTrafficStatus(Me.TxtTrafficStatusCode.Text) = False Then

            ErrMSG &= "Invalid Project Schedule Status."
            Me.TxtTrafficStatusCode.Focus()

        End If

        If CheckRequirements(True) = False Then

            Exit Sub

        End If

        If Me.TextBoxTrafficManager.Text.Trim() <> "" Then

            If myVal.ValidateEmpCodetd(Me.TextBoxTrafficManager.Text.Trim()) = False Then

                Me.ShowMessage("Invalid " & Me.HyperLinkTrafficManager.Text & " code.")
                Exit Sub

            End If

        End If

        If ErrMSG <> "" Then

            Me.ShowMessage(ErrMSG)
            Exit Sub

        End If

        If ThisJobNum > 0 And ThisJobCompNum > 0 Then

            Try

                If ThisStartDate.Trim = "" And ThisDueDate.Trim = "" Then

                    Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
                    Dim dt As New DataTable

                    dt = s.GetBaseJobAndCompInfoDT(ThisJobNum, ThisJobCompNum)

                    If dt.Rows.Count > 0 Then

                        If IsDBNull(dt.Rows(0)("START_DATE")) = False Then

                            ThisStartDate = dt.Rows(0)("START_DATE")

                        Else

                            ThisStartDate = ""

                        End If
                        If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then

                            ThisDueDate = dt.Rows(0)("JOB_FIRST_USE_DATE")

                        Else

                            ThisDueDate = ""

                        End If

                    End If

                End If

            Catch ex As Exception
            End Try

            Try

                Dim r As String = ""
                Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))

                r = s.AddNewSchedule(ThisJobNum, ThisJobCompNum, ThisPresetCode, ThisTrafficCode, ThisStartDate, ThisDueDate, _Session.UserCode, Me.TextBoxTrafficManager.Text.Trim())

                If r = "" Then

                    If Me.RadComboBoxTemplate.SelectedIndex > 0 Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            Dim Sched As AdvantageFramework.Database.Entities.JobTraffic
                            Sched = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, ThisJobNum, ThisJobCompNum)

                            If Not Sched Is Nothing Then

                                If AdvantageFramework.Database.Procedures.JobTrafficVersion.Apply(DbContext, Me.RadComboBoxTemplate.SelectedValue,
                                                                                                  ThisJobNum, ThisJobCompNum, "Schedule created from Template",
                                                                                                  _Session.UserCode) = True Then

                                    'Sched.TrafficPresetCode = ThisPresetCode
                                    Sched.TrafficCode = ThisTrafficCode
                                    Sched.ManagerEmployeeCode = Me.TextBoxTrafficManager.Text.Trim()

                                    AdvantageFramework.Database.Procedures.JobTraffic.Update(DbContext, Sched)

                                End If

                            End If

                        End Using

                    End If

                    Try

                        Session("CheckExistsClosed" & Me.TxtJobNum.Text & Me.TxtJobCompNum.Text) = Nothing

                    Catch ex As Exception

                    End Try

                    If Me.CurrentQuerystring.IsJobDashboard = True Then

                        MiscFN.ResponseRedirect(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & ThisJobNum & "/" & ThisJobCompNum & "?R=1&JT=1", True)

                    Else

                        'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx?R=1&JT=1&JobNum=" & ThisJobNum & "&JobComp=" & ThisJobCompNum, True, True)
                        Dim qs As New AdvantageFramework.Web.QueryString

                        qs.Page = "Content.aspx"
                        qs.JobNumber = ThisJobNum
                        qs.JobComponentNumber = ThisJobCompNum
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                        Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True), True)

                    End If

                Else

                    Me.ShowMessage(r)

                End If

            Catch ex As Exception

                Me.ShowMessage("Error creating new schedule.")

            End Try

        End If

    End Sub
    Private Sub btnCopyPS_Click(sender As Object, e As System.EventArgs) Handles btnCopyPS.Click
        Try
            Dim ErrMSG As String = ""
            Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
            Dim oJobs As Job = New Job(CStr(Session("ConnString")))
            Dim ThisJobNum As Integer = 0
            Dim ThisJobCompNum As Integer = 0
            Dim IncludeStartDate As Boolean = False
            Dim IncludeDueDate As Boolean = False
            Dim IncludeTaskEmployees As Boolean = False
            Dim IncludeTaskComment As Boolean = False
            Dim IncludeDueDateComment As Boolean = False

            oJobs.GetJob(CurrJobNum, 1)
            CurrClient = oJobs.CL_CODE
            CurrDivision = oJobs.DIV_CODE
            CurrProduct = oJobs.PRD_CODE
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

            If IsNumeric(Me.TxtJobNum.Text) = False Then
                ErrMSG &= "Invalid job number.\n"
            Else
                Try
                    ThisJobNum = CType(Me.TxtJobNum.Text, Integer)
                Catch ex As Exception
                    ThisJobNum = 0
                End Try
            End If
            If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                ErrMSG &= "Invalid component number.\n"
            Else
                Try
                    ThisJobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
                Catch ex As Exception
                    ThisJobCompNum = 0
                End Try
            End If
            If ThisJobNum > 0 And ThisJobCompNum > 0 Then
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJobNum, ThisJobCompNum) = False Then
                    ErrMSG &= "Access to this job/comp is denied.\n"
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ThisJobNum)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, ThisJobNum) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        ErrMSG &= "Access to this job/comp is denied.\n"
                    End If
                End Using
            End If

            If IsNumeric(Me.TxtJobSource.Text) = False Then
                ErrMSG &= "Invalid job number for copy.\n"
            End If
            If IsNumeric(Me.TxtJobCompSource.Text) = False Then
                ErrMSG &= "Invalid component number for copy.\n"
            End If

            If Me.TxtJobSource.Text <> "" Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.TxtJobSource.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, Me.TxtJobSource.Text) = False AndAlso
                            AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        ErrMSG &= "This is not a valid job for copying."
                    End If
                End Using
            End If

            If myVal.ValidateTrafficStatus(Me.TxtTrafficStatusCode.Text) = False Then
                ErrMSG &= "Invalid Project Schedule Status."
                Me.TxtTrafficStatusCode.Focus()
            End If

            If ErrMSG <> "" Then
                Me.ShowMessage(ErrMSG)
                Exit Sub
            End If

            Dim save As Boolean = False

            GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment)

            save = oJob.CopyProjectSchedule(Me.TxtJobSource.Text, Me.TxtJobCompSource.Text, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, Me.TxtTrafficStatusCode.Text,
                                            IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, "", False, False)

            If save = False Then

                Me.ShowMessage("Error saving project schedule.")
                Exit Sub

            Else
                Try

                    Session("CheckExistsClosed" & Me.TxtJobNum.Text & Me.TxtJobCompNum.Text) = Nothing

                Catch ex As Exception
                End Try
                If Me.CurrentQuerystring.IsJobDashboard = True Then

                    MiscFN.ResponseRedirect(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & ThisJobNum & "/" & ThisJobCompNum & "?R=1&JT=1", True)

                Else

                    Dim qs As New AdvantageFramework.Web.QueryString

                    qs.Page = "Content.aspx"
                    qs.JobNumber = ThisJobNum
                    qs.JobComponentNumber = ThisJobCompNum
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                    Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbShowClosed_CheckedChanged(sender As Object, e As System.EventArgs) Handles cbShowClosed.CheckedChanged
        Try
            Me.LoadLookups()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CheckBoxShowCopyFromExistingSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowCopyFromExistingSchedule.CheckedChanged

        Me.PnlCopySchedule.Visible = Me.CheckBoxShowCopyFromExistingSchedule.Checked

    End Sub
    Private Sub ImgBtnGetPresetData_AddNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnGetPresetData_AddNew.Click
        If IsNumeric(Me.TxtJobNum.Text) = True And IsNumeric(Me.TxtJobCompNum.Text) = True Then
            Me.JobNum = CType(Me.TxtJobNum.Text, Integer)
            Me.JobCompNum = CType(Me.TxtJobCompNum.Text, Integer)
            Me.ShowForm()
        End If
    End Sub

    Private Sub GetCopyOptions(ByRef IncludeStartDate As Boolean, ByRef IncludeDueDate As Boolean, ByRef IncludeTaskEmployees As Boolean, ByRef IncludeTaskComment As Boolean, ByRef IncludeDueDateComment As Boolean)

        For Each ListItem In Me.CheckBoxListCopyOptions.Items.OfType(Of System.Web.UI.WebControls.ListItem)()

            Select Case ListItem.Value

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeStartDate.ToString

                    IncludeStartDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDate.ToString

                    IncludeDueDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskEmployees.ToString

                    IncludeTaskEmployees = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskComment.ToString

                    IncludeTaskComment = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDateComment.ToString

                    IncludeDueDateComment = ListItem.Selected

            End Select

        Next

    End Sub
    Private Function SetJobAndComp() As Boolean
        Try
            If Not Request.QueryString("c") = Nothing Then
                Me.Client = Request.QueryString("c").ToString()
            End If
        Catch ex As Exception
            Me.Client = ""
        End Try
        Try
            If Not Request.QueryString("d") = Nothing Then
                Me.Division = Request.QueryString("d").ToString()
            End If
        Catch ex As Exception
            Me.Division = ""
        End Try
        Try
            If Not Request.QueryString("p") = Nothing Then
                Me.Product = Request.QueryString("p").ToString()
            End If
        Catch ex As Exception
            Me.Product = ""
        End Try
        Try
            If IsNumeric(Request.QueryString("j")) = True Then
                JobNum = CType(Request.QueryString("j"), Integer)
            Else
                JobNum = 0
            End If
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("jc")) = True Then
                JobCompNum = CType(Request.QueryString("jc"), Integer)
            Else
                JobCompNum = 0
            End If
        Catch ex As Exception
            JobCompNum = 0
        End Try

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.ClientCode <> "" Then Me.Client = qs.ClientCode
        If qs.DivisionCode <> "" Then Me.Division = qs.DivisionCode
        If qs.ProductCode <> "" Then Me.Product = qs.ProductCode
        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber

        Me.TxtClientCode.Text = Me.Client
        Me.TxtDivisionCode.Text = Me.Division
        Me.TxtProductCode.Text = Me.Product

        If JobNum > 0 And JobCompNum > 0 Then
            Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            'Return Not s.HasHeader(JobNum, JobCompNum)
            Dim i As Integer = s.CheckExistsClosed(JobNum, JobCompNum)
            If i = -2 Then
                Me.LblMSG.Text = "Schedule is completed and cannot be viewed."
                Me.PnlAddNewSchedule.Visible = False
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If

    End Function
    Private Sub ShowForm()
        'Me.PnlAddNewSchedule.Visible = IsValidJobAndComp
        'Me.PnlDontAddNewSchedule.Visible = Not IsValidJobAndComp
        'If IsValidJobAndComp = True Then
        'Else
        '    LblMSG.Text = "Invalid job/comp."
        'End If
        If JobNum > 0 And JobCompNum > 0 Then
            Me.TxtJobNum.Text = JobNum
            Me.TxtJobCompNum.Text = JobCompNum
            Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            DtJobAndComp = s.GetBaseJobAndCompInfoDT(JobNum, JobCompNum)
            If DtJobAndComp.Rows.Count > 0 Then
                If IsDBNull(DtJobAndComp.Rows(0)("CL_CODE")) = False Then
                    Me.TxtClientCode.Text = DtJobAndComp.Rows(0)("CL_CODE")
                Else
                    Me.TxtClientCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("DIV_CODE")) = False Then
                    Me.TxtDivisionCode.Text = DtJobAndComp.Rows(0)("DIV_CODE")
                Else
                    Me.TxtDivisionCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("PRD_CODE")) = False Then
                    Me.TxtProductCode.Text = DtJobAndComp.Rows(0)("PRD_CODE")
                Else
                    Me.TxtProductCode.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("JOB_DESC")) = False Then
                    Me.TxtJobDescription.Text = DtJobAndComp.Rows(0)("JOB_DESC")
                Else
                    Me.TxtJobDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.TxtJobCompDescription.Text = DtJobAndComp.Rows(0)("JOB_COMP_DESC")
                Else
                    Me.TxtJobCompDescription.Text = ""
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("START_DATE")) = False Then
                    Me.RadDatePickerStartDate.SelectedDate = CType(DtJobAndComp.Rows(0)("START_DATE"), Date)
                End If
                If IsDBNull(DtJobAndComp.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                    Me.RadDatePickerDueDate.SelectedDate = CType(DtJobAndComp.Rows(0)("JOB_FIRST_USE_DATE"), Date)
                End If

            End If
            Me.TxtTrafficStatusCode.Focus()
        Else
            Me.TxtJobNum.Focus()
        End If
    End Sub
    Private Sub LoadLookups()

        Me.HlClient.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientCode.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionCode.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedule&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

        Me.HlJob.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobNum.ClientID & "');clearjob();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobschedulenew&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
        Me.HlComponent.Attributes.Add("onclick", "FocusTB('" & Me.TxtJobCompNum.ClientID & "');clearcomp();OpenRadWindowLookup('LookUp.aspx?form=schedulenew&type=jobcompschedulenew&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlTrafficStatus.Attributes.Add("onclick", "FocusTB('" & Me.TxtTrafficStatusCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedulenew&control=" & Me.TxtTrafficStatusCode.ClientID & "&type=statuscodes');return false;")

        Me.HlClientSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
        Me.HlDivisionSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")

        Me.HlProductSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

        'Me.HlJobTypeSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobtype&control=" & Me.TxtJobTypeSource.ClientID & "&type=jobtype');return false;")
        'Me.hlStatusCopy.Attributes.Add("onclick", "FocusTB('" & Me.txtStatusCopy.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=statuscodes&control=" & Me.txtStatusCopy.ClientID & "&type=statuscodes');return false;")
        If Me.cbShowClosed.Checked = True Then
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopyps&type=jobcopy&checked=1&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")
            Me.HlJobCompSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopycompps&type=jobcopycompps&checked=1&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobSource.ClientID & ".value);return false;")
        Else
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopyps&type=jobcopy&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")
            Me.HlJobCompSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopycompps&type=jobcopycompps&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobSource.ClientID & ".value);return false;")
        End If

        Dim s As New cSchedule()

        Me.HyperLinkTrafficManager.Text = s.GetManagerLabel() & ":"
        Me.RequiredfieldvalidatorTrafficManager.ErrorMessage = s.GetManagerLabel() & " is required."
        'Me.HyperLinkCopyTrafficManager.Text = s.GetManagerLabel() & ":"

        Me.HyperLinkTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxTrafficManager.ClientID.ToString() & "');return false;")
        'Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxCopyTrafficManager.ClientID.ToString() & "');return false;")

    End Sub
    Private Function CheckRequirements(ByVal IsSaving As Boolean) As Boolean

        Dim HasRequirements As Boolean = True

        Try

            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False
            Dim IsManagerRequired As Boolean = False

            Dim val As String = JobTemplate_New.IsRequiredWebMethod("", "")

            Dim ar() As String

            ar = val.Split("|")

            IsCampaignRequired = ar(0).ToString() = "true"
            IsJobTypeRequired = ar(1).ToString() = "true"
            IsManagerRequired = ar(2).ToString() = "true"

            If IsManagerRequired = True Then

                If IsSaving = True AndAlso String.IsNullOrWhiteSpace(Me.TextBoxTrafficManager.Text) = True Then

                    Me.TextBoxTrafficManager.CssClass = "required-missing"
                    HasRequirements = False
                    Dim s As New cSchedule()
                    Me.ShowMessage(s.GetManagerLabel & " is required")

                Else

                    Me.TextBoxTrafficManager.CssClass = "RequiredInput"

                End If

            Else

                Me.TextBoxTrafficManager.CssClass = Nothing

            End If

            RequiredfieldvalidatorTrafficManager.Enabled = IsManagerRequired

            Return HasRequirements

        Catch ex As Exception
        End Try

    End Function

End Class
