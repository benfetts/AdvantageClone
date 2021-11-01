Imports Ionic.Zip
Imports System.IO
Imports System.Threading

Public Class TrafficSchedule_Print
    Inherits Webvantage.BasePrintSendPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Public PageMode As Integer = 0     '0 = single view report (popup on ps)   1= multiview report (schedule_filter.aspx)   2 = multiview filter (popup from ps screens)
    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public Count As Integer = 0
    Private IsSingleView As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        'validate here:
        If Me.InputIsValid = False Then Exit Sub


        'create go to string
        'create querystring and redirect:
        Dim GoToPage As String = ""

        Dim OfficeCode As String = ""
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
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
        Dim TasksFilterValue As String = Me.RadComboBoxPhaseFilter.SelectedValue
        Dim MileStonesOnly As Boolean = False
        Dim TrafficStatusCode As String = ""

        If TasksFilterValue = "0" Then
            TasksFilterValue = "is_null"
        End If

        ClientCode = Me.txtClient.Text.Trim()
        DivisionCode = Me.txtDivision.Text.Trim()
        ProductCode = Me.txtProduct.Text.Trim()
        If IsNumeric(Me.txtJob.Text.Trim()) = True Then
            JobNumber = CType(Me.txtJob.Text.Trim(), Integer)
        End If
        If IsNumeric(Me.txtComponent.Text.Trim()) = True Then
            JobComponentNbr = CType(Me.txtComponent.Text.Trim(), Integer)
        End If
        EmpCode = Me.TxtEmployee.Text.Trim()
        TaskCode = Me.TxtTaskCode.Text.Trim()
        AccountExecCode = Me.TxtAccountExecutive.Text.Trim()
        RoleCode = Me.TxtRole.Text.Trim()
        ManagerCode = Me.TxtManager.Text.Trim()
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff) = True Then
            CutOffDate = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()
        End If
        IncludeCompletedTasks = Me.CheckBoxIncludeCompletedTasks.Checked
        IncludeOnlyPendingTasks = Me.CheckBoxOnlyPendingTasks.Checked
        ExcludeProjectedTasks = Me.CheckBoxExcludeProjectedTasks.Checked
        IncludeCompletedSchedules = Me.CheckBoxIncludeCompletedSchedules.Checked
        MileStonesOnly = Me.CheckBoxMilestonesOnly2.Checked
        TrafficStatusCode = Me.TxtTrafficStatusCode.Text.Trim()
        Campaign = Me.TxtCampaign.Text.Trim()

        Dim SbQS As New System.Text.StringBuilder()
        With SbQS
            .Append("o=")
            .Append(ClientCode)
            .Append("c=")
            .Append(ClientCode)
            .Append("&")
            .Append("d=")
            .Append(DivisionCode)
            .Append("&")
            .Append("p=")
            .Append(ProductCode)
            .Append("&")
            .Append("j=")
            .Append(JobNumber)
            .Append("&")
            .Append("jc=")
            .Append(JobComponentNbr)
            .Append("&")
            .Append("emp=")
            .Append(EmpCode)
            .Append("&")
            .Append("mgr=")
            .Append(ManagerCode)
            .Append("&")
            .Append("tsk=")
            .Append(TaskCode)
            .Append("&")
            .Append("ae=")
            .Append(AccountExecCode)
            .Append("&")
            .Append("rl=")
            .Append(RoleCode)
            .Append("&")
            .Append("cod=")
            .Append(CutOffDate)
            .Append("&")
            .Append("ci=")
            .Append(Campaign)
            .Append("&")
            .Append("ict=")
            .Append(IncludeCompletedTasks.ToString())
            .Append("&")
            .Append("pnd=")
            .Append(IncludeOnlyPendingTasks.ToString())
            .Append("&")
            .Append("prj=")
            .Append(ExcludeProjectedTasks.ToString())
            .Append("&")
            .Append("ics=")
            .Append(IncludeCompletedSchedules.ToString())
            .Append("&")
            .Append("pf=")
            .Append(TasksFilterValue)
            .Append("&")
            .Append("mso=")
            .Append(MileStonesOnly)
            .Append("&")
            .Append("ts=")
            .Append(TrafficStatusCode)


        End With

        'select
        Select Case Me.RadComboBoxReportName.SelectedValue.ToString()
            Case "001", "002", "003", "004", "006"
                If JobNumber = 0 Or JobComponentNbr = 0 Then
                    QuickMSG("There is a problem")
                    Exit Sub
                End If
        End Select
        Select Case Me.RadComboBoxReportName.SelectedValue.ToString()
            Case "001"  '001 - Schedule Detail by Job
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=0")
            Case "002"  '002 - Schedule Detail by Job including Employee Hours
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=1")
            Case "003"  '003 - Schedule Detail by Job - Employee and Client Contact

            Case "004"  '004 - Single Job Gantt Report
                MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?j=" & Me.JobNumber & "&jc=" & JobComponentNbr)
            Case "005"  '005 - Multi Job Gantt Report
                MiscFN.ResponseRedirect("ExcelPert/PertPageExcel.aspx?" & SbQS.ToString())
            Case "006"  '006 - Calendar by Job
                MiscFN.ResponseRedirect("TrafficSchedule_Calendar_Render.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr)
            Case "007"  '006 - Schedule Detail Dates and Resources
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob2&hours=0")
        End Select

        Select Case Me.PageMode
            Case 0 'Reports
            Case 1 'Multiview
        End Select

    End Sub
    Private Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Me.HideAll(True)
        'Me.RadComboBoxReportName.SelectedIndex = 0
    End Sub

    Private Sub RadComboBoxReportName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxReportName.SelectedIndexChanged

        Me.SetPage()

        Select Case Me.RadListBoxReportName.SelectedValue
            Case "001"  '001 - Schedule Detail by Job
                'Me.SetPopupSize(False)
            Case "002"  '002 - Schedule Detail by Job including Employee Hours
                'Me.SetPopupSize(False)
            Case "003"  '003 - Schedule Detail by Job - Employee and Client Contact

            Case "004"  '004 - Single Job Gantt Report
                'Me.SetPopupSize(False)
                Me.CheckBoxShowPhases.Enabled = False
                Me.CheckBoxShowResources.Enabled = False
            Case "005"  '005 - Multi Job Gantt Report
                'Me.SetPopupSize(True)
                Me.CheckBoxShowPhases.Enabled = False
                Me.CheckBoxShowResources.Enabled = False
            Case "006"  '006 - Calendar by Job
                'Me.SetPopupSize(False)
            Case "008"
                Me.CheckBoxShowPhases.Enabled = False
                Me.CheckBoxShowResources.Enabled = False
        End Select

    End Sub
    Private Sub RadListBoxReportName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListBoxReportName.SelectedIndexChanged
        Try
            Me.SetPage()
            Me.SetPageByReport()

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                .setAppVar("Report", Me.RadListBoxReportName.SelectedValue)
                .SaveAllAppVars()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadToolBarProjectSchedulePrintOptions_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarProjectSchedulePrintOptions.ButtonClick

        Select Case e.Item.Value
            Case "Print"

                If Me.PageMode = 1 Then
                    Me.PrintMV()
                Else
                    Me.Print()
                End If


            Case "SendAlert"

                Me.SendAlert()

            Case "SendAssignment"

                Me.SendAlert(False, True)

            Case "SendEmail"

                Me.SendAlert(True, False)

            Case "Clear"

                Me.HideAll(True)

        End Select

    End Sub
    Private Sub RadComboBoxLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLocation.SelectedIndexChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            With oAppVars
                .setAppVar("Location", RadComboBoxLocation.SelectedValue.ToString)
                .SaveAllAppVars()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxMilestonesOnly1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMilestonesOnly1.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxMilestonesOnly1", Me.CheckBoxMilestonesOnly1.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxExcludeTaskComment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExcludeTaskComment.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxExcludeTaskComment", Me.CheckBoxExcludeTaskComment.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxShowPhases_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxShowPhases.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxShowPhases", Me.CheckBoxShowPhases.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxShowResources_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxShowResources.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxShowResources", Me.CheckBoxShowResources.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxMilestonesOnly2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMilestonesOnly2.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxMilestonesOnly2", Me.CheckBoxMilestonesOnly2.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxExcludeTimeDue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxExcludeTimeDue.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxExcludeTimeDue", Me.CheckBoxExcludeTimeDue.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxExcludeMilestone_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxExcludeMilestone.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxExcludeMilestone", Me.CheckBoxExcludeMilestone.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxExcludeProjectedTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxExcludeProjectedTasks.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxExcludeProjectedTasks", Me.CheckBoxExcludeProjectedTasks.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxIncludeCompletedSchedules_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeCompletedSchedules.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxIncludeCompletedSchedules", Me.CheckBoxIncludeCompletedSchedules.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxIncludeCompletedTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeCompletedTasks.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxIncludeCompletedTasks", Me.CheckBoxIncludeCompletedTasks.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckBoxOnlyPendingTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOnlyPendingTasks.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxOnlyPendingTasks", Me.CheckBoxOnlyPendingTasks.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try

    End Sub

    Private Sub CheckBoxCompletedTasks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCompletedTasks.CheckedChanged

        Try

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            With oAppVars

                .setAppVar("CheckBoxCompletedTasks", Me.CheckBoxCompletedTasks.Checked)
                .SaveAllAppVars()

            End With

        Catch ex As Exception
        End Try
    End Sub

#End Region
#Region " Page "

    Private Sub TrafficSchedule_Print_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.SetQSVars()

    End Sub
    Protected Sub TrafficSchedule_Print_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

        If PageMode = 0 Then

            Me.IsSingleView = True
            Me.RadToolBarButtonClear.Visible = False
            Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("RadToolBarButtonClearSeparator").Visible = False

        ElseIf Me.PageMode = 1 Then

            Me.Title = "Print Project Schedule"

        End If

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.LoadLookups()
            FillLocationDropDown()
            Me.HideAll(True)

            Select Case Me.PageMode
                Case 0, 1 '     "report mode"

                    Me.TrSelectReport.Visible = True
                    Me.TrSelectPageType.Visible = False

                Case 2

                    Me.TrSelectReport.Visible = False
                    Me.TrSelectPageType.Visible = True

            End Select

            'If IsSingleView = True Then
            '    Me.TrSelectPageType.Visible = False
            '    Me.TrSelectReport.Visible = False
            'End If

            Me.TrFilterHeader.Visible = False

            If Me.PageMode = 0 Then

                Me.BtnClear.Visible = False
                Me.BtnClose.Visible = False
                Me.RadToolBarButtonClear.Visible = False
                Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("RadToolBarButtonClearSeparator").Visible = False

            ElseIf Me.PageMode = 1 Then

                Me.BtnClear.Visible = False
                Me.BtnClose.Visible = False
                Me.TrHeaderInfo.Visible = False
                Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("SendAlert").Visible = False
                Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("SendAssignment").Visible = False
                Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("SendEmail").Visible = False
                Me.Title = "Print Project Schedule"

            ElseIf Me.PageMode = 2 Then

                Me.BtnClear.Visible = False
                Me.BtnClose.Visible = False
                Me.RadToolBarButtonClear.Visible = False
                Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("RadToolBarButtonClearSeparator").Visible = False

            End If

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()

            Try

                Me.CheckBoxMilestonesOnly1.Checked = oAppVars.getAppVar("CheckBoxMilestonesOnly1", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxExcludeTaskComment.Checked = oAppVars.getAppVar("CheckBoxExcludeTaskComment", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxShowPhases.Checked = oAppVars.getAppVar("CheckBoxShowPhases", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxShowResources.Checked = oAppVars.getAppVar("CheckBoxShowResources", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxMilestonesOnly2.Checked = oAppVars.getAppVar("CheckBoxMilestonesOnly2", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxExcludeTimeDue.Checked = oAppVars.getAppVar("CheckBoxExcludeTimeDue", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxExcludeMilestone.Checked = oAppVars.getAppVar("CheckBoxExcludeMilestone", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxExcludeProjectedTasks.Checked = oAppVars.getAppVar("CheckBoxExcludeProjectedTasks", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxIncludeCompletedSchedules.Checked = oAppVars.getAppVar("CheckBoxIncludeCompletedSchedules", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxIncludeCompletedTasks.Checked = oAppVars.getAppVar("CheckBoxIncludeCompletedTasks", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxOnlyPendingTasks.Checked = oAppVars.getAppVar("CheckBoxOnlyPendingTasks", "boolean", "false").ToLower = "true"

            Catch ex As Exception
            End Try
            Try

                Me.CheckBoxCompletedTasks.Checked = oAppVars.getAppVar("CheckBoxCompletedTasks", "boolean", "true").ToLower = "true"

            Catch ex As Exception
                Me.CheckBoxCompletedTasks.Checked = True
            End Try

        End If
        If Me.IsClientPortal = True Then

            Me.RadToolBarProjectSchedulePrintOptions.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub
    Private Sub TrafficSchedule_Print_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.CurrentPageMode
            Case BasePrintSendPage.PageMode.Print

                If Me.PageMode = 1 Then
                    Me.PrintMV()
                Else
                    Me.Print()
                End If
                Me.CloseThisWindow()

            Case BasePrintSendPage.PageMode.SendAlert

                Me.SendAlert()

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case BasePrintSendPage.PageMode.SendAssignment

                Me.SendAlert(False, True)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case BasePrintSendPage.PageMode.SendEmail

                Me.SendAlert(True, False)

                If Request.QueryString("Content") = "1" Then
                    Me.CloseThisWindowNew()
                Else
                    Me.CloseThisWindow()
                End If

            Case Else

        End Select

    End Sub

#End Region

    Private Sub SetQSVars()
        Try
            If Not Request.QueryString("pm") Is Nothing Then
                If IsNumeric(Request.QueryString("pm")) = True Then
                    Me.PageMode = CType(Request.QueryString("pm"), Integer)
                End If
            End If
        Catch ex As Exception
            Me.PageMode = 0
        End Try
        Try
            If Not Request.QueryString("j") Is Nothing Then
                If IsNumeric(Request.QueryString("j")) = True Then
                    Me.JobNumber = CType(Request.QueryString("j"), Integer)
                End If
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then
                If IsNumeric(Request.QueryString("jc")) = True Then
                    Me.JobComponentNbr = CType(Request.QueryString("jc"), Integer)
                End If
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("count") Is Nothing Then
                If IsNumeric(Request.QueryString("count")) = True Then
                    Me.Count = CType(Request.QueryString("count"), Integer)
                End If
            End If
        Catch ex As Exception
            Me.Count = 0
        End Try

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNumber = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobComponentNbr = qs.JobComponentNumber
        If qs.GetValue("pm") <> "" Then Me.PageMode = qs.GetValue("pm")

        If PageMode = 0 Then

            Dim ojob As New Job(Session("ConnString"))
            ojob.GetJob(Me.JobNumber, Me.JobComponentNbr)

            Me.LabelClient.Text = ojob.CL_CODE & " - " & ojob.ClientDesc
            Me.LabelDivision.Text = ojob.DIV_CODE & " - " & ojob.DivisionDesc
            Me.LabelProduct.Text = ojob.PRD_CODE & " - " & ojob.ProductDesc
            Me.LabelJobNumber.Text = Me.JobNumber.ToString().PadLeft(6, "0")
            Me.LabelJobComponentNumber.Text = Me.JobComponentNbr.ToString().PadLeft(2, "0")
            Me.LabelJobDescription.Text = ojob.JOB_DESC
            Me.LabelJobComponentDescription.Text = ojob.JobComponent.JOB_COMP_DESC

        End If
    End Sub
    Private Sub SetPage()
        Me.HideAll(True)
        If Me.TrSelectReport.Visible = True Then
            If Me.IsSingleView = True Then
                With Me.txtJob
                    .Visible = True
                    .Text = Me.JobNumber.ToString()
                    .ReadOnly = True
                End With
                With Me.txtComponent
                    .Visible = True
                    .Text = Me.JobComponentNbr.ToString()
                    .ReadOnly = True
                End With
            Else
                'Select Case Me.RadListBoxReportName.SelectedIndex
                '    Case 0, 1, 2, 3, 4
                '        Me.TrFilterHeader.Visible = True
                '        'Me.TrOffice.Visible = True
                '        Me.TrClient.Visible = True
                '        Me.TrDivision.Visible = True
                '        Me.TrProduct.Visible = True
                '        Me.TrJobNumber.Visible = True
                '        Me.TrJobComponentNbr.Visible = True
                '        Me.txtJob.CssClass = "RequiredInput"
                '        Me.txtComponent.CssClass = "RequiredInput"
                '        Exit Sub
                '    Case 5
                '        Me.TrFilterHeader.Visible = True
                '        'Me.TrOffice.Visible = True
                '        Me.TrClient.Visible = True
                '        Me.TrDivision.Visible = True
                '        Me.TrProduct.Visible = True
                '        Me.TrCampaign.Visible = True
                '        Me.TrAccountExecutive.Visible = True
                '        Me.TrManager.Visible = True
                '        Me.TrJobNumber.Visible = True
                '        Me.TrJobComponentNbr.Visible = True
                '        'Me.TrStartEnd.Visible = True
                '        Me.TrIncludeCompletedSchedules.Visible = True
                '        Me.TrTrafficStatus.Visible = True

                '        Me.TrPhaseFilter.Visible = True
                '        Me.TrDateCutoff.Visible = True
                '        Me.TrExcludeProjectedTasks.Visible = True
                '        Me.TrIncludeCompletedTasks.Visible = True
                '        Me.TrMilestonesOnly.Visible = True
                '        Me.txtJob.BackColor = Drawing.Color.White
                '        Me.txtComponent.BackColor = Drawing.Color.White
                'End Select
            End If
        End If

    End Sub
    Private Sub LoadLookups()

        Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=psro&type=client&control=" & Me.txtClient.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=psro&type=division&control=" & Me.txtDivision.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=psro&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")

        Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=psro&type=jobschedule&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
        Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=psro&type=jobcompschedule&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")

        Me.HlEmployee.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtEmployee.ClientID & "&type=empcode');return false;")
        Me.HlAccountExecutive.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtAccountExecutive.ClientID & "&type=empcode&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
        Me.HlTask.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtTaskCode.ClientID & "&type=task');return false;")
        Me.HlRole.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtRole.ClientID & "&type=roles');return false;")
        Me.HlManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtManager.ClientID & "&type=managers');return false;")
        Me.HlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=psro&control=" & Me.TxtCampaign.ClientID & "&type=campaignfilter&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
        Me.HlTrafficStatus.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&fromform=schedulenew&control=" & Me.TxtTrafficStatusCode.ClientID & "&type=statuscodes');return false;")

        Dim d As New cDropDowns(Session("ConnString"))
        With Me.RadComboBoxPhaseFilter
            .DataSource = d.GetTrafficPhasesAll
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With

        Me.LoadReportNames()

    End Sub
    Private Sub FillLocationDropDown()
        Me.RadComboBoxLocation.Items.Clear()
        Dim oReports As cReports = New cReports(CStr(Session("ConnString")))
        Me.RadComboBoxLocation.DataSource = oReports.GetLocationPO
        Me.RadComboBoxLocation.DataTextField = "ID"
        Me.RadComboBoxLocation.DataValueField = "LOGO_PATH"
        Me.RadComboBoxLocation.DataBind()
        Me.RadComboBoxLocation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))

        Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
        oAppVars.getAllAppVars()
        Dim s As String = ""
        Dim ar() As String
        s = oAppVars.getAppVar("Location")
        Me.RadComboBoxLocation.SelectedValue = s
    End Sub
    Private Sub SetReportSingleView()

    End Sub
    Private Sub HideAll(ByVal ResetForm As Boolean)
        If ResetForm = True Then
            Me.TxtOffice.Text = ""
            Me.txtClient.Text = ""
            Me.txtDivision.Text = ""
            Me.txtProduct.Text = ""
            Me.txtJob.Text = ""
            Me.txtComponent.Text = ""
            Me.TxtCampaign.Text = ""
            Me.TxtManager.Text = ""
            Me.TxtAccountExecutive.Text = ""
            If Me.RadComboBoxPhaseFilter.Items.Count > 0 Then
                Me.RadComboBoxPhaseFilter.SelectedIndex = 0
            End If
            Me.CheckBoxIncludeCompletedSchedules.Checked = True
            Me.CheckBoxExcludeProjectedTasks.Checked = False
            Me.CheckBoxIncludeCompletedTasks.Checked = True
            Me.CheckBoxMilestonesOnly2.Checked = False
        End If

        'Me.TrSelectPageType.Visible = False
        'Me.TrSelectReport.Visible = False
        Me.TrOffice.Visible = False
        Me.TrClient.Visible = False
        Me.TrDivision.Visible = False
        Me.TrProduct.Visible = False
        Me.TrJobNumber.Visible = False
        Me.TrJobComponentNbr.Visible = False
        Me.TrCampaign.Visible = False
        Me.TrManager.Visible = False
        Me.TrAccountExecutive.Visible = False
        Me.TrStartEnd.Visible = False
        Me.TrIncludeCompletedSchedules.Visible = False
        Me.TrTrafficStatus.Visible = False
        Me.TrFilterHeader.Visible = False
        Me.TrPhaseFilter.Visible = False
        Me.TrRole.Visible = False
        Me.TrTask.Visible = False
        Me.TrEmployee.Visible = False
        Me.TrDateCutoff.Visible = False
        Me.TrOnlyPendingTasks.Visible = False
        Me.TrExcludeProjectedTasks.Visible = False
        Me.TrIncludeCompletedTasks.Visible = False
        Me.TrMilestonesOnly.Visible = False

        'Dim i As Integer
        'If Me.RadListBoxReportName.Items.Count > 0 Then
        '    For i = 0 To RadListBoxReportName.Items.Count - 1
        '        If Me.RadListBoxReportName.Items(i).Selected = True Then
        '            Me.RadListBoxReportName.Items(i).Selected = False
        '        End If
        '    Next
        'End If
    End Sub
    Private Sub SetPopupSize(ByVal ExpandIt As Boolean)
        Dim w As Integer = 475
        Dim h As Integer = 130
        If ExpandIt = True Then
            h = 600
        End If
        Dim StrScript As String = "<script language=""javascript"" type=""text/javascript"">window.resizeTo(" & w.ToString() & ", " & h.ToString() & ");</script>"
        Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "ExpandShrink", StrScript)
    End Sub
    Private Function InputIsValid() As Boolean

        If Me.txtJob.Text.Trim() <> "" Then
            If IsNumeric(Me.txtJob.Text) = False Then
                QuickMSG("Job Number is required.")
                Return False
            End If
        End If
        If Me.txtComponent.Text.Trim() <> "" Then
            If IsNumeric(Me.txtComponent.Text) = False Then
                QuickMSG("Job Component Number is required.")
                Return False
            End If
        End If

        If Me.txtProduct.Text <> "" And (Me.txtClient.Text = "" Or Me.txtDivision.Text = "") Then
            QuickMSG("Cannot filter by product without both client code and division code.")
            Return False
        End If
        If Me.txtDivision.Text <> "" And Me.txtClient.Text = "" Then
            QuickMSG("Cannot filter by division without a client code.")
            Return False
        End If

        'validate:
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        If Me.txtClient.Text <> "" Then
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                QuickMSG("Invalid Client!")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                QuickMSG("Access to this client is denied.")
                Exit Function
            End If
        End If
        If Me.txtDivision.Text <> "" Then
            If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Then
                QuickMSG("Please enter a client and division code when filtering at the division level.")
                Return False
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                QuickMSG("Invalid Client, Division!")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                QuickMSG("Access to this division is denied.")
                Return False
            End If
        End If
        If Me.txtProduct.Text <> "" Then
            If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Or Me.txtProduct.Text = "" Then
                QuickMSG("Please enter a client, division, and product code when filtering at the product level.")
                Return False
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                QuickMSG("Invalid Client, Division, Product!")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                QuickMSG("Access to this product is denied.")
                Return False
            End If
        End If
        If Me.txtComponent.Text <> "" Then
            If Me.txtJob.Text = "" Or Me.txtComponent.Text = "" Then
                QuickMSG("Please enter a job and job component number when filtering at the component level.")
                Return False
            End If
            If IsNumeric(Me.txtJob.Text.Trim) = False Or IsNumeric(Me.txtComponent.Text.Trim) = False Then
                QuickMSG("Invalid job/comp number.")
                Return False
            End If
            If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                QuickMSG("This is not a valid job/component!")
                Return False
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtComponent.Text.Trim) = False Then
                QuickMSG("Access to this job/component is denied.")
                Return False
            End If
        End If
        If Me.TxtCampaign.Text <> "" Then
            If Me.txtClient.Text.Trim = "" Or Me.TxtCampaign.Text.Trim = "" Then
                QuickMSG("Please fill in Client, Division, Product, and Campaign codes!")
                Return False
            End If
            If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                QuickMSG("Invalid Campaign!")
                Return False
            End If
            If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                QuickMSG("Access to this campaign is denied.")
                Return False
            End If
        End If
        If Me.TxtEmployee.Text <> "" Then
            If myVal.ValidateEmpCode(Me.TxtEmployee.Text) = False Then
                QuickMSG("Invalid Employee!")
                Return False
            End If
        End If
        If Me.TxtTaskCode.Text <> "" Then
            If myVal.ValidateTaskCode(Me.TxtTaskCode.Text) = False Then
                QuickMSG("Invalid Task!")
                Return False
            End If
        End If
        If Me.TxtAccountExecutive.Text <> "" Then
            If myVal.ValidateEmpCode(Me.TxtAccountExecutive.Text) = False Then
                QuickMSG("Invalid employee selected as Account Executive!")
                Return False
            End If
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
                Return False
            End If
        End If
        If Me.TxtRole.Text <> "" Then
            If myVal.ValidateRoleCode(Me.TxtRole.Text) = False Then
                QuickMSG("Invalid Role!")
                Return False
            End If
        End If
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
            QuickMSG("Invalid Date Cutoff!")
            Return False
        End If
        If Me.TxtTrafficStatusCode.Text.Trim() <> "" Then
            If myVal.ValidateTrafficStatus(Me.TxtTrafficStatusCode.Text, True) = False Then
                QuickMSG("Invalid Project Schedule Status.")
                Return False
            End If
        End If

        Return True

    End Function
    Private Sub QuickMSG(ByVal StrMSG As String)
        Try
            Dim strScript As String
            strScript = "<script type=""text/javascript"">alert ('" & StrMSG & "');</script>"
            If Not Page.ClientScript.IsStartupScriptRegistered("JSAlert") Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "JSAlert", strScript)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadReportNames()
        With Me.RadListBoxReportName.Items
            .Clear()
            .Insert(0, New Telerik.Web.UI.RadListBoxItem("001 - Schedule Detail by Job with Start Date and Due Date", "001"))
            .Insert(1, New Telerik.Web.UI.RadListBoxItem("002 - Schedule Detail by Job with Hours Allowed", "002"))
            .Insert(2, New Telerik.Web.UI.RadListBoxItem("003 - Schedule Detail by Job with Due Date Only", "003"))
            If Me.PageMode <> 0 Then
                .Insert(3, New Telerik.Web.UI.RadListBoxItem("004 - Gantt Report - Multiple Jobs", "004"))
                .Insert(4, New Telerik.Web.UI.RadListBoxItem("006 - Schedule Detail by Job with Dates and Resources", "007"))
                .Insert(5, New Telerik.Web.UI.RadListBoxItem("007 - Gantt Report - Multiple Jobs By Day", "008"))
                .Insert(6, New Telerik.Web.UI.RadListBoxItem("008 - Schedule Detail by Job with Assignments", "009"))
                .Insert(7, New Telerik.Web.UI.RadListBoxItem("009 - Schedule Detail by Job with Days", "010"))
            Else
                .Insert(3, New Telerik.Web.UI.RadListBoxItem("004 - Gantt Report - Single Job", "004"))
                .Insert(4, New Telerik.Web.UI.RadListBoxItem("005 - Calendar Report", "005"))
                .Insert(5, New Telerik.Web.UI.RadListBoxItem("006 - Schedule Detail by Job with Dates and Resources", "007"))
                .Insert(6, New Telerik.Web.UI.RadListBoxItem("007 - Gantt Report - Single Job By Day", "008"))
                .Insert(7, New Telerik.Web.UI.RadListBoxItem("008 - Schedule Detail by Job with Assignments", "009"))
                .Insert(8, New Telerik.Web.UI.RadListBoxItem("009 - Schedule Detail by Job with Days", "010"))
            End If
        End With

        Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
        oAppVars.getAllAppVars()
        Dim s As String = ""
        s = oAppVars.getAppVar("Report")
        Dim rlitem As Telerik.Web.UI.RadListBoxItem = Me.RadListBoxReportName.FindItemByValue(s)
        If Not rlitem Is Nothing Then
            Me.RadListBoxReportName.SelectedValue = s
            Me.SetPageByReport()
        End If
    End Sub
    Private Sub SetPageByReport()
        Try
            Select Case Me.RadListBoxReportName.SelectedValue
                Case "001"  '001 - Schedule Detail by Job
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = True
                    Me.CheckBoxExcludeMilestone.Enabled = True
                    Me.CheckBoxExcludeTimeDue.Enabled = True
                Case "002"  '002 - Schedule Detail by Job including Employee Hours
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = True
                    Me.CheckBoxExcludeMilestone.Enabled = True
                    Me.CheckBoxExcludeTimeDue.Enabled = True
                Case "003"  '003 - Schedule Detail by Job - Employee and Client Contact
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = True
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False

                Case "004"  '004 - Single Job Gantt Report
                    'Me.SetPopupSize(False)
                    Me.CheckBoxShowPhases.Enabled = False
                    Me.CheckBoxShowResources.Enabled = False
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False
                Case "005"  '005 - Multi Job Gantt Report
                    'Me.SetPopupSize(True)
                    Me.CheckBoxShowPhases.Enabled = False
                    Me.CheckBoxShowResources.Enabled = False
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False
                Case "006"  '006 - Calendar by Job
                    Me.CheckBoxShowPhases.Enabled = False
                    Me.CheckBoxShowResources.Enabled = False
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False
                Case "007"  '006 - Calendar by Job
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = True
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False
                Case "008"
                    Me.CheckBoxShowPhases.Enabled = False
                    Me.CheckBoxShowResources.Enabled = False
                    Me.CheckBoxExcludeMilestone.Enabled = False
                    Me.CheckBoxExcludeTimeDue.Enabled = False
                Case "009"
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = True
                    Me.CheckBoxExcludeMilestone.Enabled = True
                    Me.CheckBoxExcludeTimeDue.Enabled = True
                Case "010"
                    Me.CheckBoxShowPhases.Enabled = True
                    Me.CheckBoxShowResources.Enabled = False
                    Me.CheckBoxExcludeMilestone.Enabled = True
                    Me.CheckBoxExcludeTimeDue.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Print()
        Dim strsort As String
        Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
        oAppVars.getAllAppVars()
        strsort = oAppVars.getAppVar("GridSort", "String")

        'validate here:
        If Me.InputIsValid = False Then Exit Sub

        If Me.RadListBoxReportName.SelectedValue = "" Then
            Me.RadListBoxReportName.SelectedValue = "001"
            'Me.QuickMSG("Please select a project schedule report to print.")
            'Exit Sub
        End If

        'create go to string
        'create querystring and redirect:
        Dim GoToPage As String = ""

        Dim OfficeCode As String = ""
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
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
        Dim TasksFilterValue As String = Me.RadComboBoxPhaseFilter.SelectedValue
        Dim MileStonesOnly As Boolean = False
        Dim TrafficStatusCode As String = ""

        If TasksFilterValue = "0" Then
            TasksFilterValue = "is_null"
        End If

        ClientCode = Me.txtClient.Text.Trim()
        DivisionCode = Me.txtDivision.Text.Trim()
        ProductCode = Me.txtProduct.Text.Trim()
        If IsNumeric(Me.txtJob.Text.Trim()) = True Then
            JobNumber = CType(Me.txtJob.Text.Trim(), Integer)
        End If
        If IsNumeric(Me.txtComponent.Text.Trim()) = True Then
            JobComponentNbr = CType(Me.txtComponent.Text.Trim(), Integer)
        End If
        EmpCode = Me.TxtEmployee.Text.Trim()
        TaskCode = Me.TxtTaskCode.Text.Trim()
        AccountExecCode = Me.TxtAccountExecutive.Text.Trim()
        RoleCode = Me.TxtRole.Text.Trim()
        ManagerCode = Me.TxtManager.Text.Trim()
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
            CutOffDate = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()
        End If
        IncludeCompletedTasks = Me.CheckBoxIncludeCompletedTasks.Checked
        IncludeOnlyPendingTasks = Me.CheckBoxOnlyPendingTasks.Checked
        ExcludeProjectedTasks = Me.CheckBoxExcludeProjectedTasks.Checked
        IncludeCompletedSchedules = Me.CheckBoxIncludeCompletedSchedules.Checked
        MileStonesOnly = Me.CheckBoxMilestonesOnly2.Checked
        TrafficStatusCode = Me.TxtTrafficStatusCode.Text.Trim()
        Campaign = Me.TxtCampaign.Text.Trim()

        Dim SbQS As New System.Text.StringBuilder()
        With SbQS
            .Append("o=")
            .Append(OfficeCode)
            .Append("&")
            .Append("c=")
            .Append(ClientCode)
            .Append("&")
            .Append("d=")
            .Append(DivisionCode)
            .Append("&")
            .Append("p=")
            .Append(ProductCode)
            .Append("&")
            .Append("j=")
            .Append(JobNumber)
            .Append("&")
            .Append("jc=")
            .Append(JobComponentNbr)
            .Append("&")
            .Append("emp=")
            .Append(EmpCode)
            .Append("&")
            .Append("mgr=")
            .Append(ManagerCode)
            .Append("&")
            .Append("tsk=")
            .Append(TaskCode)
            .Append("&")
            .Append("ae=")
            .Append(AccountExecCode)
            .Append("&")
            .Append("rl=")
            .Append(RoleCode)
            .Append("&")
            .Append("cod=")
            .Append(CutOffDate)
            .Append("&")
            .Append("ci=")
            .Append(Campaign)
            .Append("&")
            .Append("ict=")
            .Append(IncludeCompletedTasks.ToString())
            .Append("&")
            .Append("pnd=")
            .Append(IncludeOnlyPendingTasks.ToString())
            .Append("&")
            .Append("prj=")
            .Append(ExcludeProjectedTasks.ToString())
            .Append("&")
            .Append("ics=")
            .Append(IncludeCompletedSchedules.ToString())
            .Append("&")
            .Append("pf=")
            .Append(TasksFilterValue)
            .Append("&")
            .Append("mso=")
            .Append(MileStonesOnly)
            .Append("&")
            .Append("ts=")
            .Append(TrafficStatusCode)


        End With
        Dim ar() As String
        Try
            If Me.RadComboBoxLocation.SelectedItem.Text = "[None]" Then
                Session("PSLogoLocation") = ""
                Session("PSLogoLocationID") = "None"
            Else
                ar = RadComboBoxLocation.SelectedValue.ToString.Split("|")
                Session("PSLogoLocation") = ar(1)
                Session("PSLogoLocationID") = ar(0)
            End If

        Catch ex As Exception
            Session("PSLogoLocation") = ""
        End Try

        'select
        Select Case Me.RadListBoxReportName.SelectedValue.ToString()
            Case "001", "002", "003", "004", "005", "007", "008", "009"
                If JobNumber = 0 Or JobComponentNbr = 0 Then
                    QuickMSG("Job Number and Component are needed.")
                    Exit Sub
                End If
        End Select
        Select Case Me.RadListBoxReportName.SelectedValue.ToString()
            Case "001"  '001 - Schedule Detail by Job with Start Date and Due Date
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&exms=" & Me.CheckBoxExcludeMilestone.Checked & "&timedue=" & Me.CheckBoxExcludeTimeDue.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "002"  '002 - Schedule Detail by Job with Hours Allowed
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=1&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&exms=" & Me.CheckBoxExcludeMilestone.Checked & "&timedue=" & Me.CheckBoxExcludeTimeDue.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "003"  '003 - Schedule Detail by Job with Due Date Only
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJobDueDate&hours=0&due=1&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "004"  '004 - Single Job Gantt Report
                MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?j=" & Me.JobNumber & "&jc=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "005"  '005 - Calendar by Job
                MiscFN.ResponseRedirect("TrafficSchedule_Calendar_Render.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&loc=" & Session("PSLogoLocationID") & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "006"  '006 - Multi Job Gantt Report
                MiscFN.ResponseRedirect("ExcelPert/PertPageExcel.aspx?" & SbQS.ToString())
            Case "007"  '001 - Schedule Detail by Job including dates and resources
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob2&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "008"  '004 - Single Job Gantt Report
                MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?rpt=day&j=" & Me.JobNumber & "&jc=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "009"  '009 - Schedule Detail by Job with Start Date and Due Date
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob3&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&exms=" & Me.CheckBoxExcludeMilestone.Checked & "&timedue=" & Me.CheckBoxExcludeTimeDue.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
            Case "010"  '010 - Schedule Detail by Job with Days
                MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJobDays&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&exms=" & Me.CheckBoxExcludeMilestone.Checked & "&timedue=" & Me.CheckBoxExcludeTimeDue.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
        End Select

        Select Case Me.PageMode
            Case 0 'Reports
            Case 1 'Multiview
        End Select

    End Sub
    Private Sub PrintMV()
        Try
            Dim filename As String
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Select Case Count
                Case 0
                    'Me.ShowMessage("No file(s) selected.")
                Case 1
                    'Dim strURL As String = "popReportViewer.aspx?job=" & Me.JobNumber & "&jobcomp=" & Me.JobComponentNbr & "&ms=False&Type=1&Report=TrafficDetailByJob"
                    'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                    'strBuilder.Append("<script language='javascript'>")
                    'strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                    'strBuilder.Append("</")
                    'strBuilder.Append("script>")
                    'Page.RegisterStartupScript("newpage", strBuilder.ToString())
                Case Is > 1
                    Try
                        Dim outputStream As New System.IO.MemoryStream
                        Dim strfiles As String

                        'Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
                        'RepositorySecuritySettings.LoadAll()
                        'Dim ThisUserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
                        'Dim ThisUserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

                        'Dim ThisUserPassword As String = AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
                        'Dim ThisPath = RepositorySecuritySettings.DOC_REPOSITORY_PATH

                        'Dim impersonateUser As Boolean = False
                        'Dim AliasAccount As AliasAccount
                        'impersonateUser = ThisUserName <> ""

                        Dim ar() As String
                        Try
                            If Me.RadComboBoxLocation.SelectedItem.Text = "[None]" Then
                                Session("PSLogoLocation") = ""
                                Session("PSLogoLocationID") = "None"
                            Else
                                ar = RadComboBoxLocation.SelectedValue.ToString.Split("|")
                                Session("PSLogoLocation") = ar(1)
                                Session("PSLogoLocationID") = ar(0)
                            End If

                        Catch ex As Exception
                            Session("PSLogoLocation") = ""
                        End Try

                        'If Request.QueryString("jcs") <> "" Then
                        '    Session("TrafficScheduleMVJobs") = Request.QueryString("jcs")
                        'End If

                        If Me.RadListBoxReportName.SelectedValue.ToString() = "004" Then
                            MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?From=psmv&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
                        ElseIf Me.RadListBoxReportName.SelectedValue.ToString() = "008" Then
                            MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?rpt=day&From=psmv&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
                        Else
                            'If impersonateUser = True Then
                            '    AliasAccount.BeginImpersonation(ThisUserName, ThisUserDomain, ThisUserPassword)
                            'End If

                            Dim zip As New ZipFile

                            Dim jc() As String = Session("TrafficScheduleMVJobs").Split("|")
                            For i As Integer = 0 To jc.Length - 1
                                Dim jobc As String
                                jobc = jc(i)
                                If jobc <> "" Then
                                    Dim jobcomp() As String = jobc.Split(",")

                                    filename = Me.OutputReportFile(jobcomp(0), jobcomp(1))

                                    Dim f As New IO.FileInfo(StrFilePrefix & filename)
                                    If f.Exists Then
                                        zip.AddFile(StrFilePrefix & filename, "")
                                        strfiles &= filename & "|"
                                    End If
                                End If
                            Next

                            zip.Save(Response.OutputStream)

                            Dim str() As String = strfiles.Split("|")
                            For x As Integer = 0 To str.Length - 1
                                If str(x) <> "" Then
                                    Try
                                        My.Computer.FileSystem.DeleteFile(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                    Try
                                        Kill(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                End If
                            Next

                            'If impersonateUser = True Then
                            '    AliasAccount.EndImpersonation()
                            'End If

                            Response.AddHeader("Content-Disposition", "filename=Webvantage_Project_Schedules__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                            Response.ContentType = "application/zip"
                            'Response.End()
                        End If


                    Catch ex As Exception

                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Function OutputReportFile(ByVal job As String, ByVal comp As String) As String
        Dim StrFileName As String = ""
        'Dim StrImagePath As String = Request.PhysicalApplicationPath & "\Images\logo_print.gif"
        Dim r As cReports = New cReports(Session("ConnString"))
        Dim StrFilePrefix As String = Request.PhysicalApplicationPath.Trim & "TEMP\"
        Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
        Dim StrFileType As String = ".PDF"
        StrFileName = "Project_Schedule_" & job & "_" & comp & StrFileDate & StrFileType

        Dim rpt As New popReportViewer
        Try
            Dim ThisOptions As String

            Select Case Me.RadListBoxReportName.SelectedValue.ToString()
                Case "001"  '001 - Schedule Detail by Job with Start Date and Due Date
                    ThisOptions = job & "|" & comp & "|0|" & Me.CheckBoxMilestonesOnly1.Checked & "|0|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                    ' MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
                Case "002"  '002 - Schedule Detail by Job with Hours Allowed
                    ThisOptions = job & "|" & comp & "|1|" & Me.CheckBoxMilestonesOnly1.Checked & "|0|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                    'MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob&hours=1&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
                Case "003"  '003 - Schedule Detail by Job with Due Date Only
                    ThisOptions = job & "|" & comp & "|0|" & Me.CheckBoxMilestonesOnly1.Checked & "|1|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions)
                    'MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJobDueDate&hours=0&due=1&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
                Case "004"  '004 - Single Job Gantt Report
                    MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?j=" & job & "&jc=" & comp & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked)
                Case "005"  '005 - Calendar by Job
                    'MiscFN.ResponseRedirect("TrafficSchedule_Calendar_Render.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&loc=" & Session("PSLogoLocationID"))
                Case "006"  '006 - Multi Job Gantt Report
                    'MiscFN.ResponseRedirect("ExcelPert/PertPageExcel.aspx?" & SbQS.ToString())
                Case "007"  '001 - Schedule Detail by Job including dates and resources
                    ThisOptions = job & "|" & comp & "|0|" & Me.CheckBoxMilestonesOnly1.Checked & "|0|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions)
                    'MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob2&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
                Case "008"  '004 - Single Job Gantt Report
                    'MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?rpt=day&j=" & Me.JobNumber & "&jc=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked)
                Case "009"  '001 - Schedule Detail by Job with Start Date and Due Date
                    ThisOptions = job & "|" & comp & "|0|" & Me.CheckBoxMilestonesOnly1.Checked & "|0|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob3", "", "", "", "", "", 1, "", ThisOptions)
                    'MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob3&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
                Case "010"  '001 - Schedule Detail by Job with Start Date and Due Date
                    ThisOptions = job & "|" & comp & "|0|" & Me.CheckBoxMilestonesOnly1.Checked & "|0|" & Me.CheckBoxExcludeTaskComment.Checked & "||" & Me.CheckBoxShowPhases.Checked & "|" & Me.CheckBoxShowResources.Checked & "|" & Me.CheckBoxCompletedTasks.Checked
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJobDays", "", "", "", "", "", 1, "", ThisOptions)
                    'MiscFN.ResponseRedirect("popReportViewer.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr & "&Type=1&Report=TrafficDetailByJob3&hours=0&due=0&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked)
            End Select


        Catch ex As Exception
            StrFileName = ""
        End Try
        Return StrFileName
    End Function
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)
        Dim strsort As String
        Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
        oAppVars.getAllAppVars()
        strsort = oAppVars.getAppVar("GridSort", "String")

        'validate here:
        If Me.InputIsValid = False Then Exit Sub

        If Me.RadListBoxReportName.SelectedValue = "" Then
            Me.RadListBoxReportName.SelectedValue = "001"
            'Me.QuickMSG("Please select a project schedule report to print.")
            'Exit Sub
        End If
        'create go to string
        'create querystring and redirect:
        Dim GoToPage As String = ""

        Dim OfficeCode As String = ""
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
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
        Dim TasksFilterValue As String = Me.RadComboBoxPhaseFilter.SelectedValue
        Dim MileStonesOnly As Boolean = False
        Dim TrafficStatusCode As String = ""
        Dim ExcludeTaskComment As Boolean = False

        If TasksFilterValue = "0" Then
            TasksFilterValue = "is_null"
        End If

        ClientCode = Me.txtClient.Text.Trim()
        DivisionCode = Me.txtDivision.Text.Trim()
        ProductCode = Me.txtProduct.Text.Trim()
        If IsNumeric(Me.txtJob.Text.Trim()) = True Then
            JobNumber = CType(Me.txtJob.Text.Trim(), Integer)
        End If
        If IsNumeric(Me.txtComponent.Text.Trim()) = True Then
            JobComponentNbr = CType(Me.txtComponent.Text.Trim(), Integer)
        End If
        EmpCode = Me.TxtEmployee.Text.Trim()
        TaskCode = Me.TxtTaskCode.Text.Trim()
        AccountExecCode = Me.TxtAccountExecutive.Text.Trim()
        RoleCode = Me.TxtRole.Text.Trim()
        ManagerCode = Me.TxtManager.Text.Trim()
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
            CutOffDate = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()
        End If
        IncludeCompletedTasks = Me.CheckBoxIncludeCompletedTasks.Checked
        IncludeOnlyPendingTasks = Me.CheckBoxOnlyPendingTasks.Checked
        ExcludeProjectedTasks = Me.CheckBoxExcludeProjectedTasks.Checked
        IncludeCompletedSchedules = Me.CheckBoxIncludeCompletedSchedules.Checked
        MileStonesOnly = Me.CheckBoxMilestonesOnly2.Checked
        TrafficStatusCode = Me.TxtTrafficStatusCode.Text.Trim()
        Campaign = Me.TxtCampaign.Text.Trim()
        ExcludeTaskComment = Me.CheckBoxExcludeTaskComment.Checked

        Dim SbQS As New System.Text.StringBuilder()
        With SbQS
            .Append("o=")
            .Append(OfficeCode)
            .Append("&")
            .Append("cli")
            .Append(ClientCode)
            .Append("&")
            .Append("div=")
            .Append(DivisionCode)
            .Append("&")
            .Append("prd=")
            .Append(ProductCode)
            .Append("&")
            .Append("j=")
            .Append(JobNumber)
            .Append("&")
            .Append("jc=")
            .Append(JobComponentNbr)
            .Append("&")
            .Append("emp=")
            .Append(EmpCode)
            .Append("&")
            .Append("mgr=")
            .Append(ManagerCode)
            .Append("&")
            .Append("tsk=")
            .Append(TaskCode)
            .Append("&")
            .Append("ae=")
            .Append(AccountExecCode)
            .Append("&")
            .Append("rl=")
            .Append(RoleCode)
            .Append("&")
            .Append("cod=")
            .Append(CutOffDate)
            .Append("&")
            .Append("ci=")
            .Append(Campaign)
            .Append("&")
            .Append("ict=")
            .Append(IncludeCompletedTasks.ToString())
            .Append("&")
            .Append("pnd=")
            .Append(IncludeOnlyPendingTasks.ToString())
            .Append("&")
            .Append("prj=")
            .Append(ExcludeProjectedTasks.ToString())
            .Append("&")
            .Append("ics=")
            .Append(IncludeCompletedSchedules.ToString())
            .Append("&")
            .Append("pf=")
            .Append(TasksFilterValue)
            .Append("&")
            .Append("mso=")
            .Append(MileStonesOnly)
            .Append("&")
            .Append("ts=")
            .Append(TrafficStatusCode)
            .Append("&")
            .Append("excludeTC=")
            .Append(ExcludeTaskComment)

        End With

        Dim strURL As String '= "Alert_New.aspx?pagetype=jt" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobJacket)
        Dim ar() As String
        Try
            If Me.RadComboBoxLocation.SelectedItem.Text = "[None]" Then
                Session("PSLogoLocation") = ""
                Session("PSLogoLocationID") = "None"
            Else
                ar = RadComboBoxLocation.SelectedValue.ToString.Split("|")
                Session("PSLogoLocation") = ar(1)
                Session("PSLogoLocationID") = ar(0)
            End If
        Catch ex As Exception
            Session("PSLogoLocation") = ""
        End Try
        'select
        Select Case Me.RadListBoxReportName.SelectedValue.ToString()
            Case "001", "002", "003", "004", "005", "007", "009", "010"
                If JobNumber = 0 Or JobComponentNbr = 0 Then
                    QuickMSG("Job Number and Component are needed")
                    Exit Sub
                End If
        End Select
        Dim EmailSwitch As String = ""
        If AsEmail = True Then

            EmailSwitch = "eml=1&"

        Else

            EmailSwitch = "eml=0&"

        End If
        If IsAssignment = True Then 'assignment switch overrides email switch

            EmailSwitch = "eml=0&assn=1&"

        End If
        Select Case Me.RadListBoxReportName.SelectedValue.ToString()
            Case "001"  '001 - Schedule Detail by Job
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=0&due=0&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=job&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
            Case "002"  '002 - Schedule Detail by Job including Employee Hours
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=1&due=0&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=job&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
            Case "003"  '003 - Schedule Detail by Job - Employee and Client Contact
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=0&due=1&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=duedate&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
            Case "004"  '004 - Single Job Gantt Report
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psgf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=calgantt&completed=" & Me.CheckBoxCompletedTasks.Checked
                'MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?j=" & Me.JobNumber & "&jc=" & JobComponentNbr)                           
            Case "005"  '005 - Calendar by Job
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psgf&form=calx&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=calgantt&completed=" & Me.CheckBoxCompletedTasks.Checked
                'MiscFN.ResponseRedirect("TrafficSchedule_Calendar_Render.aspx?job=" & JobNumber & "&jobcomp=" & JobComponentNbr)
            Case "006"  '006 - Multi Job Gantt Report
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psgf&form=mulx&from=sfuc&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&" & SbQS.ToString() & "&rpt=calganttcompleted=" & Me.CheckBoxCompletedTasks.Checked
                'MiscFN.ResponseRedirect("ExcelPert/PertPageExcel.aspx?" & SbQS.ToString())
            Case "007"  '001 - Schedule Detail by Job including dates and resources
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=0&due=0&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=dateres&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
            Case "008"  '004 - Single Job Gantt Report
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psgf&form=day&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=calgantt&completed=" & Me.CheckBoxCompletedTasks.Checked
                'MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?rpt=day&j=" & Me.JobNumber & "&jc=" & JobComponentNbr & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked)
            Case "009"  '001 - Schedule Detail by Job with Assignments
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=0&due=0&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=job3&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
            Case "010"  '001 - Schedule Detail by Job with Days
                strURL = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=sfuc&pagetype=psf&from=sfuc" & "&j=" & JobNumber & "&jc=" & JobComponentNbr & "&hours=0&due=0&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.ProjectSchedule) & "&ms=" & Me.CheckBoxMilestonesOnly1.Checked & "&rpt=jobDays&excludeTC=" & Me.CheckBoxExcludeTaskComment.Checked & "&sort=" & strsort & "&phase=" & Me.CheckBoxShowPhases.Checked & "&reso=" & Me.CheckBoxShowResources.Checked & "&completed=" & Me.CheckBoxCompletedTasks.Checked
        End Select

        If IsAssignment = True Then

            strURL = strURL.Replace("&caller=sfuc", "&caller=SchedulePrint")
            strURL = strURL.Replace("Alert_New.aspx", "Desktop_NewAssignment")
            Me.OpenWindow("New Assignment", strURL)

        Else

            Me.OpenWindow("New Alert", strURL)

        End If


        Select Case Me.PageMode
            Case 0 'Reports
            Case 1 'Multiview
        End Select

        'Case "Back"
        '    Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
        '    With sbScript
        '        .Append("<script type=""text/javascript"">")
        '        .Append("window.close();</script>")
        '    End With
        '    Try
        '        If Not Page.IsStartupScriptRegistered("PSHidePopup") Then
        '            Dim str As String = sbScript.ToString
        '            Page.RegisterStartupScript("PSHidePopup", str)
        '        End If
        '    Catch ex As Exception
        '        Me.ShowMessage("Error! " & ex.Message.ToString())
        '    End Try

    End Sub



#End Region

End Class
