Public Class TrafficSchedule_Filter
    Inherits Webvantage.BaseChildPage

    Private SwitchToView As String = ""
    'multi or worksheet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'MiscFN.AddCalendarIcon(Me.TxtDateCutoff, Me.LitDateCutoff)
        Try
            If Not Request.QueryString("View") = Nothing Then
                SwitchToView = Request.QueryString("View")
            End If
            If Not Me.IsPostBack And Not Me.IsCallback Then
                LoadLookups()
                SetQSVars()
                '''If SwitchToView = "multi" Then
                '''    Me.MultiOptions.Visible = True
                '''Else
                Me.MultiOptions.Visible = False
                '''End If
                If SwitchToView = "single" Then
                    Me.TblSchedHead.Visible = False
                End If
                Dim oReports As New cReports(Session("ConnString"))
                Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
                If str <> "" Or Not str Is Nothing Then
                    Me.HlManager.Text = "<span class=""labellink"">" & str & ":</span>"
                End If
            End If
            'Me.TxtClientCode.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilter&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilter&type=division&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilter&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

        Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=schedulefilter&type=jobschedule&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
        Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=schedulefilter&type=jobcompschedule&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

        Me.HlEmployee.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtEmployee.ClientID & "&type=empcode');return false;")
        Me.HlAccountExecutive.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtAccountExecutive.ClientID & "&type=empcode&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=&jobcomp=');return false;")
        Me.HlTask.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtTaskCode.ClientID & "&type=task&name=CopyScheduleWindow');return false;")
        Me.HlRole.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtRole.ClientID & "&type=roles');return false;")
        Me.HlManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtManager.ClientID & "&type=managers');return false;")
        Me.HlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtCampaign.ClientID & "&type=campaignfilter&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=&jobcomp=');return false;")

        Dim d As New cDropDowns(Session("ConnString"))
        With Me.DropPhaseFilter
            .DataSource = d.GetTrafficPhasesAll
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With

    End Sub

    Private Sub BtnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFilter.Click
        Try
            Dim RemoveFilterForSingleView As Boolean = False
            'Make sure we filter on something:
            If Me.TxtClientCode.Text = "" And Me.TxtDivisionCode.Text = "" _
            And Me.TxtProductCode.Text = "" And Me.TxtJobNum.Text = "" _
            And Me.TxtJobCompNum.Text = "" And Me.TxtEmployee.Text = "" And Me.TxtCampaign.Text = "" _
            And Me.TxtEmployee.Text = "" And Me.TxtTaskCode.Text = "" And Me.TxtAccountExecutive.Text = "" _
            And Me.TxtManager.Text = "" And Me.TxtRole.Text = "" And Me.RadDatePickerDateCutoff.SelectedDate = Nothing _
            And Me.ChkOnlyPendingTasks.Checked = False And Me.DropPhaseFilter.SelectedIndex = 0 Then 'nothing has been selected for filter
                Select Case SwitchToView
                    Case "multi", "worksheet"
                        QuickMSG("Please choose at least one filter.")
                        Exit Sub
                    Case "single"
                        RemoveFilterForSingleView = True
                End Select
            ElseIf Me.TxtClientCode.Text = "" And Me.TxtDivisionCode.Text = "" _
                And Me.TxtProductCode.Text = "" And Me.TxtJobNum.Text = "" _
                And Me.TxtJobCompNum.Text = "" And Me.TxtEmployee.Text = "" And Me.TxtCampaign.Text = "" _
                And Me.TxtEmployee.Text = "" And Me.TxtTaskCode.Text = "" And Me.TxtAccountExecutive.Text = "" _
                And Me.TxtManager.Text = "" And Me.TxtRole.Text = "" And Me.RadDatePickerDateCutoff.SelectedDate = Nothing _
                And Me.ChkOnlyPendingTasks.Checked = False And Me.DropPhaseFilter.SelectedIndex > 0 And SwitchToView <> "single" Then 'only phase selected...
                QuickMSG("Please choose more than just the phase filter.")
                Exit Sub
            End If
            If Me.TxtProductCode.Text <> "" And (Me.TxtClientCode.Text = "" Or Me.TxtDivisionCode.Text = "") Then
                QuickMSG("Cannot filter by product without both client code and division code.")
                Exit Sub
            End If
            If Me.TxtDivisionCode.Text <> "" And Me.TxtClientCode.Text = "" Then
                QuickMSG("Cannot filter by division without a client code.")
                Exit Sub
            End If


            'validate:

            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            If Me.TxtClientCode.Text <> "" Then
                If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then
                    QuickMSG("Invalid Client!")
                    Exit Sub
                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then
                    QuickMSG("Access to this client is denied.")
                    Exit Sub
                End If
            End If
            If Me.TxtDivisionCode.Text <> "" Then
                If Me.TxtClientCode.Text = "" Or Me.TxtDivisionCode.Text = "" Then
                    QuickMSG("Please enter a client and division code when filtering at the division level.")
                    Exit Sub
                End If
                If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then
                    QuickMSG("Invalid Client, Division!")
                    Exit Sub
                End If
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then
                    QuickMSG("Access to this division is denied.")
                    Exit Sub
                End If
            End If
            If Me.TxtProductCode.Text <> "" Then
                If Me.TxtClientCode.Text = "" Or Me.TxtDivisionCode.Text = "" Or Me.TxtProductCode.Text = "" Then
                    QuickMSG("Please enter a client, division, and product code when filtering at the product level.")
                    Exit Sub
                End If
                If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then
                    QuickMSG("Invalid Client, Division, Product!")
                    Exit Sub
                End If
                If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then
                    QuickMSG("Access to this product is denied.")
                    Exit Sub
                End If
            End If
            If Me.TxtJobCompNum.Text <> "" Then
                If Me.TxtJobNum.Text = "" Or Me.TxtJobCompNum.Text = "" Then
                    QuickMSG("Please enter a job and job component number when filtering at the component level.")
                    Exit Sub
                End If
                If IsNumeric(Me.TxtJobNum.Text.Trim) = False Or IsNumeric(Me.TxtJobCompNum.Text.Trim) = False Then
                    QuickMSG("Invalid job/comp number.")
                    Exit Sub
                End If
                If myVal.ValidateJobCompNumber(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then
                    QuickMSG("This is not a valid job/component!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.TxtJobNum.Text.Trim, Me.TxtJobCompNum.Text.Trim) = False Then
                    QuickMSG("Access to this job/component is denied.")
                    Exit Sub
                End If
            End If
            If Me.TxtCampaign.Text <> "" Then
                If Me.TxtClientCode.Text.Trim = "" Or Me.TxtCampaign.Text.Trim = "" Then
                    QuickMSG("Please fill in Client, Division, Product, and Campaign codes!")
                    Exit Sub
                End If
                If myVal.ValidateCampaignFilter(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                    QuickMSG("Invalid Campaign!")
                    Exit Sub
                End If
                If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                    QuickMSG("Access to this campaign is denied.")
                    Exit Sub
                End If
            End If
            If Me.TxtEmployee.Text <> "" Then
                If myVal.ValidateEmpCode(Me.TxtEmployee.Text) = False Then
                    QuickMSG("Invalid Employee!")
                    Exit Sub
                End If
            End If
            If Me.TxtTaskCode.Text <> "" Then
                If myVal.ValidateTaskCode(Me.TxtTaskCode.Text) = False Then
                    QuickMSG("Invalid Task!")
                    Exit Sub
                End If
            End If
            If Me.TxtAccountExecutive.Text <> "" Then
                If myVal.ValidateEmpCode(Me.TxtAccountExecutive.Text) = False Then
                    QuickMSG("Invalid employee selected as Account Executive!")
                    Exit Sub
                End If
                'If Me.TxtClientCode.Text.Trim = "" And Me.TxtDivisionCode.Text = "" And Me.TxtProductCode.Text <> "" Then
                '    QuickMSG("Cannot filter Account Executive on product without a client and division!")
                '    Exit Sub
                'End If
                'If Me.TxtClientCode.Text.Trim = "" And Me.TxtDivisionCode.Text <> "" And Me.TxtProductCode.Text = "" Then
                '    QuickMSG("Cannot filter Account Executive on division without a client!")
                '    Exit Sub
                'End If
                'If Me.TxtClientCode.Text.Trim = "" And Me.TxtDivisionCode.Text <> "" And Me.TxtProductCode.Text <> "" Then
                '    QuickMSG("Cannot filter Account Executive on division and product without a client!")
                '    Exit Sub
                'End If
                'If myVal.ValidateAccountExecutive(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtAccountExecutive.Text) = False Then
                '    QuickMSG("Invalid Account Executive!")
                '    Exit Sub
                'End If
            End If
            If Me.TxtManager.Text <> "" Then
                Dim dr As SqlClient.SqlDataReader
                Dim valid As Boolean = False
                dr = oDD.GetManagers(CStr(Session("UserCode")))
                If dr.HasRows = True Then
                    Do While dr.Read
                        If dr.GetString(1) = Me.TxtManager.Text Then
                            valid = True
                        End If
                    Loop
                End If
                dr.Close()
                If valid = False Then
                    QuickMSG("Invalid Manager!")
                    Exit Sub
                End If
            End If
            If Me.TxtRole.Text <> "" Then
                If myVal.ValidateRoleCode(Me.TxtRole.Text) = False Then
                    QuickMSG("Invalid Role!")
                    Exit Sub
                End If
            End If
            If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
                QuickMSG("Invalid Date Cutoff!")
                Exit Sub
            End If
            'create querystring and redirect:
            Dim GoToPage As String = ""

            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobNumber As Integer = 0
            Dim JobCompNumber As Integer = 0
            Dim EmpCode As String = ""
            Dim ManagerCode As String = ""
            Dim TaskCode As String = ""
            Dim AccountExecCode As String = ""
            Dim RoleCode As String = ""
            Dim CutOffDate As String = ""
            Dim Campaign As String = ""

            Dim IncludeCompletedTasks As Boolean = True
            Dim IncludeOnlyPendingTasks As Boolean = False
            Dim ExcludeProjectedTasks As Boolean = False
            Dim IncludeCompletedSchedules As Boolean = True
            Dim TasksFilterValue As String = Me.DropPhaseFilter.SelectedValue

            If TasksFilterValue = "0" Then
                TasksFilterValue = "is_null"
            End If

            Dim sbQueryString As New System.Text.StringBuilder

            ClientCode = Me.TxtClientCode.Text
            DivisionCode = Me.TxtDivisionCode.Text
            ProductCode = Me.TxtProductCode.Text
            If IsNumeric(Me.TxtJobNum.Text) = True Then
                JobNumber = CType(Me.TxtJobNum.Text, Integer)
            End If
            If IsNumeric(Me.TxtJobCompNum.Text) = True Then
                JobCompNumber = CType(Me.TxtJobCompNum.Text, Integer)
            End If
            EmpCode = Me.TxtEmployee.Text
            TaskCode = Me.TxtTaskCode.Text
            AccountExecCode = Me.TxtAccountExecutive.Text
            RoleCode = Me.TxtRole.Text
            ManagerCode = Me.TxtManager.Text

            If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = True Then
                If Not Me.RadDatePickerDateCutoff.SelectedDate Is Nothing Then
                    CutOffDate = cGlobals.wvCDate(Me.RadDatePickerDateCutoff.SelectedDate).ToShortDateString
                End If
            End If

            IncludeCompletedTasks = Me.ChkIncludeCompletedTasks.Checked
            IncludeOnlyPendingTasks = Me.ChkOnlyPendingTasks.Checked
            ExcludeProjectedTasks = Me.ChkExcludeProjectedTasks.Checked
            IncludeCompletedSchedules = Me.ChkIncludeCompletedSchedules.Checked
            Campaign = Me.TxtCampaign.Text

            With sbQueryString
                .Append("Cli=")
                .Append(ClientCode)
                .Append("&")
                .Append("Div=")
                .Append(DivisionCode)
                .Append("&")
                .Append("Prod=")
                .Append(ProductCode)
                If SwitchToView <> "single" Then
                    .Append("&")
                    .Append("Job=")
                    .Append(JobNumber)
                    .Append("&")
                    .Append("JobComp=")
                    .Append(JobCompNumber)
                End If
                .Append("&")
                .Append("Emp=")
                .Append(EmpCode)
                .Append("&")
                .Append("Mgr=")
                .Append(ManagerCode)
                .Append("&")
                .Append("Task=")
                .Append(TaskCode)
                .Append("&")
                .Append("AE=")
                .Append(AccountExecCode)
                .Append("&")
                .Append("Role=")
                .Append(RoleCode)
                .Append("&")
                .Append("Cut=")
                .Append(CutOffDate)
                .Append("&")
                .Append("Camp=")
                .Append(Campaign)
                .Append("&")
                .Append("Comp=")
                .Append(IncludeCompletedTasks.ToString())
                .Append("&")
                .Append("Pend=")
                .Append(IncludeOnlyPendingTasks.ToString())
                .Append("&")
                .Append("Proj=")
                .Append(ExcludeProjectedTasks.ToString())
                .Append("&")
                .Append("CS=")
                .Append(IncludeCompletedSchedules.ToString())
                .Append("&")
                .Append("P=")
                .Append(TasksFilterValue)

                If SwitchToView = "multi" Then
                    .Append("&")
                    .Append("EH=")
                    .Append(Me.ChkEditHeaders.Checked.ToString())
                    .Append("&")
                    .Append("EG=")
                    .Append(Me.ChkEditGrids.Checked.ToString())
                End If
            End With

            Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            oAppVars.getAllAppVars()
            oAppVars.setAppVar("IncludeCompleted", Me.ChkIncludeCompletedTasks.Checked, "Boolean")
            oAppVars.SaveAllAppVars()

            If SwitchToView = "multi" Then
                GoToPage = "TrafficSchedule_Multiview.aspx?"
            ElseIf SwitchToView = "worksheet" Then
                GoToPage = "TrafficSchedule_WorkSheetview.aspx?"
            ElseIf SwitchToView = "single" Then
                Dim j As Integer = 0
                Dim c As Integer = 0
                Try
                    j = CType(Request.QueryString("JobNum"), Integer)
                Catch ex As Exception
                    j = 0
                End Try
                Try
                    c = CType(Request.QueryString("JobCompNum"), Integer)
                Catch ex As Exception
                    c = 0
                End Try
                If j > 0 And c > 0 And RemoveFilterForSingleView = False Then
                    Session("PS_Ignore_Filter") = "0"
                    'GoToPage = "TrafficSchedule.aspx?R=1&JobNum=" & j & "&JobComp=" & c & "&"
                    GoToPage = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & j & "/" & c & "?R=1&"
                ElseIf j > 0 And c > 0 And RemoveFilterForSingleView = True Then
                    Session("PS_Ignore_Filter") = "0"
                    'GoToPage = "TrafficSchedule.aspx?R=1&JobNum=" & j & "&JobComp=" & c
                    GoToPage = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & j & "/" & c & "?R=1"
                Else
                    GoToPage = ""
                End If
            End If

            If GoToPage <> "" Then
                Me.CloseThisWindowAndRefreshCallerAdvanced(GoToPage, "", If(RemoveFilterForSingleView = False, sbQueryString.ToString, ""), True)
            End If

        Catch ex1 As ArithmeticException
            Me.lblMSG.Text = "This number not allowed."
        Catch ex As Exception
            Me.lblMSG.Text = "Error collecting filter data.<br />" & ex.Message.ToString()
        End Try
    End Sub
    Private Sub QuickMSG(ByVal TheMSG As String)
        Me.lblMSG.Text = TheMSG
    End Sub

    Private Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Select Case SwitchToView
            Case "multi", "worksheet"
                Me.ClearForm()
            Case "single"
                Dim j As Integer = 0
                Dim c As Integer = 0
                Dim GoToPage As String = ""
                Try
                    j = CType(Request.QueryString("JobNum"), Integer)
                Catch ex As Exception
                    j = 0
                End Try
                Try
                    c = CType(Request.QueryString("JobCompNum"), Integer)
                Catch ex As Exception
                    c = 0
                End Try
                If j > 0 And c > 0 Then
                    Session("PS_Ignore_Filter") = "0"
                    GoToPage = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & j & "/" & c & "?R=1"
                    Me.CloseThisWindowAndRefreshCaller(GoToPage, True)
                    'Me.LitScript.Text = "<script>RedirectParentPage('" & GoToPage & "');</" + "script>"
                Else
                    Me.ClearForm()
                End If
        End Select
    End Sub

    Private Sub ClearForm()
        Me.TxtClientCode.Text = ""
        Me.TxtDivisionCode.Text = ""
        Me.TxtProductCode.Text = ""
        Me.TxtJobNum.Text = ""
        Me.TxtJobCompNum.Text = ""
        Me.TxtCampaign.Text = ""
        Me.TxtEmployee.Text = ""
        Me.TxtTaskCode.Text = ""
        Me.TxtAccountExecutive.Text = ""
        Me.TxtManager.Text = ""
        Me.TxtRole.Text = ""
        Me.RadDatePickerDateCutoff.SelectedDate = Nothing
        Me.ChkExcludeProjectedTasks.Checked = False
        Me.ChkIncludeCompletedTasks.Checked = False
        Me.ChkOnlyPendingTasks.Checked = False
        Me.lblMSG.Text = ""
        If Me.DropPhaseFilter.Items.Count > 0 Then
            Me.DropPhaseFilter.SelectedIndex = 0
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            If Not Request.QueryString("P") = Nothing Then
                Me.DropPhaseFilter.SelectedValue = Request.QueryString("P").ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Role") = Nothing Then
                Me.TxtRole.Text = Request.QueryString("Role").ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Task") = Nothing Then
                Me.TxtTaskCode.Text = Request.QueryString("Task").ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Emp") = Nothing Then
                Me.TxtEmployee.Text = Request.QueryString("Emp").ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Cut") = Nothing Then
                Me.RadDatePickerDateCutoff.SelectedDate = Request.QueryString("Cut").ToString()
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Pend") = Nothing Then
                Me.ChkOnlyPendingTasks.Checked = CType(Request.QueryString("Pend").ToString(), Boolean)
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Proj") = Nothing Then
                Me.ChkExcludeProjectedTasks.Checked = CType(Request.QueryString("Proj").ToString(), Boolean)
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("Comp") = Nothing Then
                Me.ChkIncludeCompletedTasks.Checked = CType(Request.QueryString("Comp").ToString(), Boolean)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class