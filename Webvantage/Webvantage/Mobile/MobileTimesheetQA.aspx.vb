Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class MobileTimesheetQA
    Inherits MobileBase
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private SeqNum As Integer = 0
    Private TaskEmp As String = ""
    Private DefFunction As String = ""
    Private DefEmpFunction As String = ""
    Private DefDept As String = ""
    Private DtDepartments As New DataTable
    Private DtFunctions As New DataTable
    Private CommentsRequired As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            SeqNum = CType(Request.QueryString("Seq"), Integer)
        Catch ex As Exception
            SeqNum = -1
        End Try
        Try
            TaskEmp = Request.QueryString("TaskEmp")
        Catch ex As Exception
            TaskEmp = ""
        End Try

        Dim oReq As New cRequired(Session("ConnString"))
        CommentsRequired = oReq.RequiredTimesheetComments
        If CommentsRequired = True Then
            Me.TxtComments.CssClass = "RequiredInput"
        End If

        If Not Me.IsPostBack Then
            'MiscFN.AddCalendarToTB(Me.TxtDate, True)
            If JobNum > 0 And JobComp > 0 And SeqNum > -1 And TaskEmp <> "" Then
                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                Dim dt As New DataTable
                dt = oTS.GetQuickAddHeader(JobNum, JobComp, SeqNum, TaskEmp)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        Client = dt.Rows(0)("CL_CODE")
                        HfClient.Value = Client
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                        Division = dt.Rows(0)("DIV_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                        Product = dt.Rows(0)("PRD_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("THE_CLIENT")) = False Then
                        Me.LblClient.Text = dt.Rows(0)("THE_CLIENT")
                    End If
                    If IsDBNull(dt.Rows(0)("THE_DIVISION")) = False Then
                        Me.LblDivision.Text = dt.Rows(0)("THE_DIVISION")
                    End If
                    If IsDBNull(dt.Rows(0)("THE_PRODUCT")) = False Then
                        Me.LblProduct.Text = dt.Rows(0)("THE_PRODUCT")
                    End If
                    If IsDBNull(dt.Rows(0)("THE_JOB")) = False Then
                        Me.LblJob.Text = dt.Rows(0)("THE_JOB")
                    End If
                    If IsDBNull(dt.Rows(0)("THE_JOB_COMPONENT")) = False Then
                        Me.LblJobComp.Text = dt.Rows(0)("THE_JOB_COMPONENT")
                    End If
                    If IsDBNull(dt.Rows(0)("FNC_COMMENTS")) = False Then
                        Me.LblTaskComment.Text = dt.Rows(0)("FNC_COMMENTS")
                    End If

                    Dim TaskDisplay As String = ""
                    If IsDBNull(dt.Rows(0)("FNC_CODE")) = False Then
                        TaskDisplay = dt.Rows(0)("FNC_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("TASK_DESCRIPTION")) = False Then
                        TaskDisplay &= " - " & dt.Rows(0)("TASK_DESCRIPTION")
                    End If
                    Me.LblTask.Text = TaskDisplay
                    If IsDBNull(dt.Rows(0)("FNC_EST")) = False Then
                        Me.DefFunction = dt.Rows(0)("FNC_EST")
                    End If
                    If IsDBNull(dt.Rows(0)("EMP_DEF_FNC_CODE")) = False Then
                        Me.DefEmpFunction = dt.Rows(0)("EMP_DEF_FNC_CODE")
                    End If

                    If IsDBNull(dt.Rows(0)("DP_TM_CODE")) = False Then
                        Me.DefDept = dt.Rows(0)("DP_TM_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("TEMP_COMP_DATE")) = False Then
                        If cGlobals.wvIsDate(dt.Rows(0)("TEMP_COMP_DATE")) Then
                            Me.ChkMarkCompleted.Checked = True
                            Me.HfAlreadyMarked.Value = "True"
                        Else
                            Me.ChkMarkCompleted.Checked = False
                            Me.HfAlreadyMarked.Value = "False"
                        End If
                    Else
                        Me.ChkMarkCompleted.Checked = False
                        Me.HfAlreadyMarked.Value = "False"
                    End If
                    'Bind drops
                    LoadFunctionsDS()
                    LoadDeptDS()
                    With Me.DropFunction
                        .DataSource = DtFunctions
                        .DataTextField = "description"
                        .DataValueField = "code"
                        .DataBind()
                    End With
                    With Me.DropDepartment
                        .DataSource = DtDepartments
                        .DataTextField = "description"
                        .DataValueField = "code"
                        .DataBind()
                    End With
                    If ProductCategoryIsVisible() = True Then
                        Me.ProdCatRow.Visible = True
                        If RequiredProductCategory(Client) = True Then
                            Me.DropProdCat.CssClass = "RequiredInput"
                        End If
                        'bind DropProdCat
                        Dim d As New cDropDowns(Session("ConnString"))
                        With Me.DropProdCat
                            .DataSource = d.ddProductCategory(Client, Division, Product)
                            .DataTextField = "Description"
                            .DataValueField = "Code"
                            .DataBind()
                            .Items.Insert(0, "[None]")
                        End With
                    Else
                        Me.ProdCatRow.Visible = False
                    End If
                    'get task comment too:
                    Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
                    Me.TxtCompletedComments.Text = t.GetTaskComment(JobNum, JobComp, SeqNum, TaskEmp)
                    'Set Default
                    'Change per Ellen per Client Request when comming from as task. 2009/05/27 
                    'Works the same as timesheet from my projects.
                    If Me.DefFunction <> "" Then
                        ''''TODO: MiscFN.SetDDLIndex(Me.DropFunction, Me.DefFunction, False)
                    End If
                    If Me.DefEmpFunction <> "" And Me.DefFunction = "" Then
                        ''''TODO: MiscFN.SetDDLIndex(Me.DropFunction, Me.DefEmpFunction, False)
                    End If

                    'If Me.DefEmpFunction <> "" Then
                    '    MiscFN.SetDDLIndex(Me.DropFunction, Me.DefEmpFunction, False)
                    'End If
                    'If Me.DefEmpFunction = "" And Me.DefFunction <> "" Then
                    '    MiscFN.SetDDLIndex(Me.DropFunction, Me.DefFunction, False)
                    'End If
                    ''''TODO: MiscFN.SetDDLIndex(Me.DropDepartment, Me.DefDept, False)
                Else
                    'No header record, close the window?
                    'Dim cScript2 As String
                    'cScript2 = "<script>window.close();alert('Error getting task.');</script>"
                    'RegisterStartupScript("page55", cScript2)
                    MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Protected Sub lbCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbCancel.Click
        MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
        Exit Sub
    End Sub
    Private Sub LoadDeptDS()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        DtDepartments = odd.GetDeptDatatable(Session("EmpCode"), True)
    End Sub

    Private Sub LoadFunctionsDS()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.DtFunctions = odd.GetFunctionsByEmpCodeDT(Session("EmpCode"))
    End Sub

    Private Function ProductCategoryIsVisible() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()
    End Function

    Private Function RequiredProductCategory(ByVal ClientCode As String) As Boolean
        Dim oReq As cRequired = New cRequired(CStr(Session("ConnString")))
        Return oReq.ProductCategoryRequired(ClientCode)
    End Function

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If cGlobals.wvIsDate(Me.TxtDate.Text) = False Then
            'Me.LblMSG.Text = "Invalid date."
            Me.LblMSG.Text = "Invalid date."
            Exit Sub
        End If
        If IsNumeric(Me.TxtHours.Text) = False Then
            Me.LblMSG.Text = "Invalid hours."
            Exit Sub
        End If
        If CType(Me.TxtHours.Text, Decimal) > 24 Then
            Me.LblMSG.Text = "Invalid hours."
            Exit Sub
        End If

        Try
            TaskEmp = Request.QueryString("TaskEmp")
        Catch ex As Exception
            TaskEmp = ""
        End Try

        Dim ThisEmp As String = TaskEmp

        Dim ThisDate As Date = cGlobals.wvCDate(Me.TxtDate.Text)
        Dim ThisHours As Decimal = CType(Me.TxtHours.Text, Decimal)

        'job validation
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))


        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If myVal.ValidateJobIsOpen(JobNum, JobComp) = False Then
            Me.LblMSG.Text = "This job/comp is closed."
            Exit Sub
        End If
        If Me.Client <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Client, "", "") = False Then
                Me.LblMSG.Text = "Access to this client is denied."
                Exit Sub
            End If
        End If
        If Me.Client <> "" And Me.Division <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Client, Division, "") = False Then
                Me.LblMSG.Text = "Access to this division is denied."
                Exit Sub
            End If
        End If
        If Me.Client <> "" And Me.Division <> "" And Me.Product <> "" Then
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Client, Division, Product) = False Then
                Me.LblMSG.Text = "Access to this product is denied."
                Exit Sub
            End If
        End If
        'If myVal.ValidateJobCompIsEditable(Me.JobNum, Me.JobComp) = False Then
        '    Me.LblMSG.Text = "Job/comp process control does not allow access."
        '    Exit Sub
        'End If
        If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.JobNum, Me.JobComp) = False Then
            Me.LblMSG.Text = "Access to this job/comp is denied."
            Exit Sub
        End If
        If myVal.ValidateJobCompIsEditable(Me.JobNum, Me.JobComp) = False Then
            Me.LblMSG.Text = "Job/comp process control does not allow access."
            Exit Sub
        End If


        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim CurrDefaultFN As String = oTS.GetDefaultFunction(TaskEmp)
        If Me.DropFunction.SelectedValue = CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(TaskEmp, CurrDefaultFN) = False Then
                Me.LblMSG.Text = "This employee does not have access to his/her own default function."
                Exit Sub
            End If
        End If
        If Me.JobNum <> 0 And Me.JobComp <> 0 And Me.DropFunction.SelectedValue <> CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(TaskEmp, Me.DropFunction.SelectedValue) = False Then
                Me.LblMSG.Text = Me.DropFunction.SelectedValue & " is an invalid function."
                Exit Sub
            End If
        End If

        If oTS.CheckApprovalStatus(ThisEmp, ThisDate) = True Then
            Me.LblMSG.Text = "Status for this day is approved/pending."
            Exit Sub
        End If
        If oTS.PostPeriodClosed(ThisDate) = True Then
            Me.LblMSG.Text = "This day is in a closed posting period."
            Exit Sub
        End If
        If CommentsRequired = True And Me.TxtComments.Text.Length = 0 Then
            Me.LblMSG.Text = "Comment is required."
            Exit Sub
        End If

        Dim ThisDept As String = ""
        ThisDept = Me.DropDepartment.SelectedValue

        If myVal.ValidateDeptTeam(ThisDept) = False Then

            Me.DropDepartment.Focus()
            Me.LblMSG.Text = "Invalid Department."
            Exit Sub

        End If

        Dim StrProdCat As String = ""
        If Me.ProdCatRow.Visible = True Then
            If Me.RequiredProductCategory(Me.HfClient.Value) = True Then
                If Me.DropProdCat.SelectedIndex = 0 Then
                    Me.LblMSG.Text = "Product/Category is required."
                    Exit Sub
                Else
                    StrProdCat = Me.DropProdCat.SelectedValue
                End If
            Else
                If Me.DropProdCat.SelectedIndex = 0 Then
                    StrProdCat = ""
                Else
                    StrProdCat = Me.DropProdCat.SelectedValue
                End If
            End If
        Else
            StrProdCat = ""
        End If

        Try
            Dim ErrStr As String
            ' Dim TimesheetMethods As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
            Dim et As Integer = 0
            Dim etd As Integer = 0
            AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, ThisEmp, ThisDate, Me.DropFunction.SelectedValue, StrProdCat, ThisHours, JobNum, JobComp, Me.DropDepartment.SelectedValue, _
                         Session("UserCode"), ErrStr, Me.TxtComments.Text, et, etd, True)

            Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
            'If Me.ChkMarkCompleted.Checked = True And Me.HfAlreadyMarked.Value = "False" Then 'AND statement TO make sure we don't re-update date
            '    t.MarkCompleted(JobNum, JobComp, SeqNum, ThisEmp, Today.Date)
            'Else
            '    t.MarkNotCompleted(JobNum, JobComp, SeqNum, ThisEmp)
            'End If
            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.ChkMarkCompleted.Checked = True And Me.HfAlreadyMarked.Value = "False" Then

                        AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, ThisEmp, CType(Now, DateTime))

                    Else

                        AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, ThisEmp, Nothing)

                    End If

                End Using

            End Using
            'comment always re-updated?
            t.SaveTaskComment(JobNum, JobComp, SeqNum, ThisEmp, Me.TxtCompletedComments.Text)

            If Session("TimesheetTaskQuickAdd") = "1" Then
                Session("TimesheetTaskQuickAdd") = ""
                Session("TimesheetTask") = "1"
            Else
                Session("TimesheetTask") = ""
            End If
            MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
            Exit Sub
            'If Session("TimesheetTask") <> "1" Then
            '    Dim cScript As String
            '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
            '    RegisterStartupScript("parentwindow", cScript)
            'End If

            'Dim cScript2 As String
            'cScript2 = "<script>window.close();</script>"
            'RegisterStartupScript("page55", cScript2)

        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString
        End Try
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileTasks.aspx")
        Exit Sub
    End Sub
    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub
End Class
