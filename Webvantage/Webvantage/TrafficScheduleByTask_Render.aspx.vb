Imports Microsoft.VisualBasic
Imports Webvantage.cGlobals.Globals
Imports System.Drawing

Public Class TrafficScheduleByTask_Render
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
                    Dim ds As DataSet
                    Dim TaskDesc(31) As String
                    Dim TempDesc(31) As String
                    Dim strTaskDesc As String
                    Dim I As Integer
                    Dim CountRow As Integer = 0

                    ''Me.PageTitle.InnerText = System.Configuration.ConfigurationManager.AppSettings("AppTitle")
                    Me.lblDate.Text = Now

                    strTaskDesc = Request.QueryString("taskdesc")

                    If strTaskDesc = "" Then
                        For I = 0 To 30
                            TaskDesc(I) = ""
                        Next
                    Else
                        TempDesc = strTaskDesc.Split(",")
                        For I = 0 To TempDesc.GetUpperBound(0)
                            TaskDesc(I + 1) = TempDesc(I)
                        Next I
                    End If

                    '---------------------------------------------------------------------------------'
                    'ctb, 2006/06/07: created variables for parameters to TrafficScheduleSA so I could'
                    'tell where the error was occurring.                                              '
                    '---------------------------------------------------------------------------------'
                    Dim lcClients As String = Request.QueryString("clients")
                    Dim llCompleteDates As Boolean = CBool(Request.QueryString("completeddates"))
                    Dim llClosed As Boolean = CBool(Request.QueryString("closed"))
                    Dim llOnlyProjected As Boolean = False
                    Dim lcOffices As String = Request.QueryString("Offices")
                    Dim lcStatus As String = Request.QueryString("Status")

                    Dim lcAECodes As String = Request.QueryString("AECodes")
                    Dim lcRlCodes As String = Request.QueryString("Role")
                    Dim llDueDate As Boolean = CBool(Request.QueryString("duedate"))
                    Dim llDueTime As Boolean = CBool(Request.QueryString("duetime"))
                    Dim llOrigDueDate As Boolean = CBool(Request.QueryString("origdue"))
                    Dim llOrigDueDateCompDate As Boolean = CBool(Request.QueryString("origcomp"))
                    Dim llDueDateCompDate As Boolean = CBool(Request.QueryString("duecomp"))
                    Dim llDueDateorCompDate As Boolean = CBool(Request.QueryString("dueorcomp"))
                    Dim llEmpCode As Boolean = CBool(Request.QueryString("chkIncludeEmpAssign"))
                    Dim llPhase As Boolean = CBool(Request.QueryString("CheckBoxPhase"))
                    Dim llChkIncludeTaskDesc As Boolean = CBool(Request.QueryString("ChkIncludeTaskDesc"))
                    Dim llManager As String = Request.QueryString("ddManager")
                    Dim llsort1 As String = Request.Params("sort1")
                    Dim llsort2 As String = Request.Params("sort2")
                    Dim llForJobDueDate As Boolean = CBool(Request.QueryString("forjobduedate"))
                    Dim llForJobStartDate As DateTime
                    Dim llForJobEndDate As DateTime
                    Dim llIncludeClosedStartDate As DateTime
                    Dim llIncludeClosedEndDate As DateTime
                    If Request.Params("forjobstartdate") <> "" Then
                        llForJobStartDate = wvCDate(LoGlo.FormatDate(Request.Params("forjobstartdate")))
                    End If
                    If Request.Params("forjobenddate") <> "" Then
                        llForJobEndDate = wvCDate(LoGlo.FormatDate(Request.Params("forjobenddate")))
                    End If
                    If Request.Params("closedstartdate") <> "" Then
                        llIncludeClosedStartDate = wvCDate(LoGlo.FormatDate(Request.Params("closedstartdate")))
                    End If
                    If Request.Params("closedenddate") <> "" Then
                        llIncludeClosedEndDate = wvCDate(LoGlo.FormatDate(Request.Params("closedenddate")))
                    End If


                    '-------------------------------------------------------------------------------'
                    'st , 2006/04/25: added optional var to this function to handle filter in sproc '
                    'ctb, 2006/06/07: only projected removed from the interface, defaulted as false''
                    'jtg, 2009/09/28: added AE filter param
                    '-------------------------------------------------------------------------------'


                    If Request.QueryString("Format") = "2" Then
                        Dim strURL As New System.Text.StringBuilder
                        strURL.Append("popReportViewer.aspx?Report=CompletedTaskReport")
                        If llOrigDueDateCompDate = True Then
                            strURL.Append("&dateoption=origcomp")
                        ElseIf llDueDateCompDate = True Then
                            strURL.Append("&dateoption=duecomp")
                        End If
                        If CBool(Request.QueryString("excel")) = True Then
                            strURL.Append("&Type=2")
                        Else
                            strURL.Append("&Type=1")
                        End If
                        ds = oReport.TrafficScheduleCompletedSA(lcClients, lcStatus, TaskDesc, llCompleteDates, llClosed, llOnlyProjected, lcOffices, llDueDate, llOrigDueDate, llOrigDueDateCompDate, llDueDateCompDate, llEmpCode, llsort1, llsort2, llForJobDueDate, llForJobStartDate, llForJobEndDate, llIncludeClosedStartDate, llIncludeClosedEndDate, llManager, llDueTime, lcAECodes, Session("UserCode"), Me.IsClientPortal, Session("UserID"))
                        Session("CompletedTaskReportData") = ds.Tables(0)
                        Response.Redirect(strURL.ToString())
                    ElseIf Request.QueryString("Format") = "3" Then
                        ds = oReport.TrafficScheduleSARoles(lcClients, lcStatus, TaskDesc, llCompleteDates, llClosed, llOnlyProjected, lcOffices, llDueDate, llOrigDueDate, llOrigDueDateCompDate, llDueDateCompDate, llEmpCode, llsort1, llsort2, llForJobDueDate, llForJobStartDate, llForJobEndDate, llIncludeClosedStartDate, llIncludeClosedEndDate, llManager, llDueTime, lcAECodes, Session("UserCode"), lcRlCodes, Me.IsClientPortal, Session("UserID"))
                        If ds.Tables(0).Rows.Count = 0 Then
                            Session("nodataTSBT") = "1"
                            If CBool(Request.QueryString("excel")) = True Then
                                Response.Redirect("TrafficScheduleByTask_Settings.aspx")
                            Else
                                Me.CloseThisWindowAndRefreshCaller("TrafficScheduleByTask_Settings.aspx")
                            End If

                            Exit Sub
                        End If

                        ds.Tables(2).Rows.Remove(ds.Tables(2).Rows(0))
                        Dim DtTRF_DESC As New DataTable
                        Try
                            DtTRF_DESC = ds.Tables(3)
                        Catch ex As Exception
                            DtTRF_DESC = Nothing
                        End Try

                        If strTaskDesc <> "" Then
                            Dim parentRow, childRow As DataRow
                            Dim j As Integer
                            Dim newTaskRow As DataRow
                            Dim rowCount As Integer = 0
                            Dim currentRole As String = ""
                            Dim currentEmp As String = ""
                            Dim currentTask As String = ""
                            Dim currentJob As String = ""
                            Dim currentComp As String = ""
                            Dim taskwithEmp As String = ""


                            For w As Integer = 0 To ds.Tables(1).Rows.Count - 1
                                If currentRole <> "" Then
                                    If currentRole = ds.Tables(1).Rows(w)("ROLE_CODE") Then
                                        If currentEmp <> "" Then
                                            If currentEmp = ds.Tables(1).Rows(w)("EMP_CODE") Then
                                                If currentJob <> "" And currentComp <> "" Then
                                                    If currentJob = ds.Tables(1).Rows(w)("JOB_NUMBER") And currentComp = ds.Tables(1).Rows(w)("JOB_COMPONENT_NBR") Then
                                                        If currentTask <> "" Then
                                                            If currentTask = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                For I = 1 To 30
                                                                    If llOrigDueDate = True Then
                                                                        If TaskDesc(I) <> "" Then
                                                                            If TaskDesc(I) = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                                If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = True Then
                                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "," & ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                                Else
                                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "," & "X"
                                                                                End If
                                                                            End If
                                                                        End If
                                                                    End If
                                                                Next I
                                                            Else
                                                                For I = 1 To 30
                                                                    If llOrigDueDate = True Then
                                                                        If TaskDesc(I) <> "" Then
                                                                            If TaskDesc(I) = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                                If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = True Then
                                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "," & ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                                    Else
                                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                                    End If
                                                                                Else
                                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "," & "X"
                                                                                    Else
                                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = "X"
                                                                                    End If
                                                                                End If
                                                                                currentTask = ds.Tables(1).Rows(w)("FNC_CODE")
                                                                            End If
                                                                        End If
                                                                    End If
                                                                Next I
                                                            End If
                                                        Else
                                                            For I = 1 To 30
                                                                If llOrigDueDate = True Then
                                                                    If TaskDesc(I) <> "" Then
                                                                        If TaskDesc(I) = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                            If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = True Then
                                                                                newTaskRow.Item("Task" & I) = ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                            Else
                                                                                newTaskRow.Item("Task" & I) = "X"
                                                                            End If
                                                                            currentTask = ds.Tables(1).Rows(w)("FNC_CODE")
                                                                        End If
                                                                    End If
                                                                End If
                                                            Next I
                                                            ds.Tables(2).Rows.Add(newTaskRow)
                                                            rowCount += 1
                                                        End If
                                                    Else 'Job and comp different than current
                                                        newTaskRow = ds.Tables(2).NewRow
                                                        If IsDBNull(ds.Tables(1).Rows(w)("Manager")) = False Then
                                                            newTaskRow.Item("Manager") = ds.Tables(1).Rows(w)("Manager")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("START_DATE")) = False Then
                                                            newTaskRow.Item("Job Start Date") = ds.Tables(1).Rows(w)("START_DATE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")) = False Then
                                                            newTaskRow.Item("Job Due Date1") = ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = False Then
                                                            newTaskRow.Item("Job Completed Date") = ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("CL_CODE")) = False Then
                                                            newTaskRow.Item("Client Code") = ds.Tables(1).Rows(w)("CL_CODE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("CL_NAME")) = False Then
                                                            newTaskRow.Item("Client") = ds.Tables(1).Rows(w)("CL_NAME")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("DIV_CODE")) = False Then
                                                            newTaskRow.Item("Division Code") = ds.Tables(1).Rows(w)("DIV_CODE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("DIV_NAME")) = False Then
                                                            newTaskRow.Item("Division") = ds.Tables(1).Rows(w)("DIV_NAME")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("PRD_CODE")) = False Then
                                                            newTaskRow.Item("Product Code") = ds.Tables(1).Rows(w)("PRD_CODE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("PRD_DESCRIPTION")) = False Then
                                                            newTaskRow.Item("Product") = ds.Tables(1).Rows(w)("PRD_DESCRIPTION")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("JOB_CLI_REF")) = False Then
                                                            newTaskRow.Item("Client Reference") = ds.Tables(1).Rows(w)("JOB_CLI_REF")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("AE")) = False Then
                                                            newTaskRow.Item("Account Executive") = ds.Tables(1).Rows(w)("AE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("JT_CODE")) = False Then
                                                            newTaskRow.Item("Job Type") = ds.Tables(1).Rows(w)("JT_CODE")
                                                        End If
                                                        If IsDBNull(ds.Tables(1).Rows(w)("JT_DESC")) = False Then
                                                            newTaskRow.Item("Job Type Description") = ds.Tables(1).Rows(w)("JT_DESC")
                                                        End If
                                                        newTaskRow.Item("Job Number") = ds.Tables(1).Rows(w)("JOB_NUMBER")
                                                        newTaskRow.Item("Job") = ds.Tables(1).Rows(w)("JOB_DESC")
                                                        newTaskRow.Item("Comp Number") = ds.Tables(1).Rows(w)("JOB_COMPONENT_NBR")
                                                        newTaskRow.Item("Component") = ds.Tables(1).Rows(w)("JOB_COMP_DESC")
                                                        newTaskRow.Item("Rush") = ds.Tables(1).Rows(w)("RUSH")
                                                        newTaskRow.Item("Job Markup") = ds.Tables(1).Rows(w)("JOB_MARKUP_PCT")
                                                        newTaskRow.Item("Job Non Bill Flag") = ds.Tables(1).Rows(w)("NOBILL_FLAG")
                                                        newTaskRow.Item("Job Due Date2") = ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")
                                                        newTaskRow.Item("Job Status") = ds.Tables(1).Rows(w)("TRF_DESCRIPTION")
                                                        If IsDBNull(ds.Tables(1).Rows(w)("TRF_COMMENTS")) = False Then
                                                            newTaskRow.Item("Traffic Comments") = ds.Tables(1).Rows(w)("TRF_COMMENTS")
                                                        End If

                                                        currentJob = ds.Tables(1).Rows(w)("JOB_NUMBER")
                                                        currentComp = ds.Tables(1).Rows(w)("JOB_COMPONENT_NBR")

                                                        For I = 1 To 30
                                                            If llOrigDueDate = True Then
                                                                If TaskDesc(I) <> "" Then
                                                                    If TaskDesc(I) = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                        If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = True Then
                                                                            newTaskRow.Item("Task" & I) = ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                        Else
                                                                            newTaskRow.Item("Task" & I) = "X"
                                                                        End If
                                                                        currentTask = ds.Tables(1).Rows(w)("FNC_CODE")
                                                                    End If
                                                                End If
                                                            End If
                                                        Next I
                                                        ds.Tables(2).Rows.Add(newTaskRow)
                                                        rowCount += 1
                                                    End If
                                                Else
                                                    newTaskRow = ds.Tables(2).NewRow
                                                    If IsDBNull(ds.Tables(1).Rows(w)("Manager")) = False Then
                                                        newTaskRow.Item("Manager") = ds.Tables(1).Rows(w)("Manager")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("START_DATE")) = False Then
                                                        newTaskRow.Item("Job Start Date") = ds.Tables(1).Rows(w)("START_DATE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")) = False Then
                                                        newTaskRow.Item("Job Due Date1") = ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = False Then
                                                        newTaskRow.Item("Job Completed Date") = ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("CL_CODE")) = False Then
                                                        newTaskRow.Item("Client Code") = ds.Tables(1).Rows(w)("CL_CODE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("CL_NAME")) = False Then
                                                        newTaskRow.Item("Client") = ds.Tables(1).Rows(w)("CL_NAME")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("DIV_CODE")) = False Then
                                                        newTaskRow.Item("Division Code") = ds.Tables(1).Rows(w)("DIV_CODE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("DIV_NAME")) = False Then
                                                        newTaskRow.Item("Division") = ds.Tables(1).Rows(w)("DIV_NAME")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("PRD_CODE")) = False Then
                                                        newTaskRow.Item("Product Code") = ds.Tables(1).Rows(w)("PRD_CODE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("PRD_DESCRIPTION")) = False Then
                                                        newTaskRow.Item("Product") = ds.Tables(1).Rows(w)("PRD_DESCRIPTION")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("JOB_CLI_REF")) = False Then
                                                        newTaskRow.Item("Client Reference") = ds.Tables(1).Rows(w)("JOB_CLI_REF")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("AE")) = False Then
                                                        newTaskRow.Item("Account Executive") = ds.Tables(1).Rows(w)("AE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("JT_CODE")) = False Then
                                                        newTaskRow.Item("Job Type") = ds.Tables(1).Rows(w)("JT_CODE")
                                                    End If
                                                    If IsDBNull(ds.Tables(1).Rows(w)("JT_DESC")) = False Then
                                                        newTaskRow.Item("Job Type Description") = ds.Tables(1).Rows(w)("JT_DESC")
                                                    End If
                                                    newTaskRow.Item("Job Number") = ds.Tables(1).Rows(w)("JOB_NUMBER")
                                                    newTaskRow.Item("Job") = ds.Tables(1).Rows(w)("JOB_DESC")
                                                    newTaskRow.Item("Comp Number") = ds.Tables(1).Rows(w)("JOB_COMPONENT_NBR")
                                                    newTaskRow.Item("Component") = ds.Tables(1).Rows(w)("JOB_COMP_DESC")
                                                    newTaskRow.Item("Rush") = ds.Tables(1).Rows(w)("RUSH")
                                                    newTaskRow.Item("Job Markup") = ds.Tables(1).Rows(w)("JOB_MARKUP_PCT")
                                                    newTaskRow.Item("Job Non Bill Flag") = ds.Tables(1).Rows(w)("NOBILL_FLAG")
                                                    newTaskRow.Item("Job Due Date2") = ds.Tables(1).Rows(w)("JOB_FIRST_USE_DATE")
                                                    newTaskRow.Item("Job Status") = ds.Tables(1).Rows(w)("TRF_DESCRIPTION")
                                                    If IsDBNull(ds.Tables(1).Rows(w)("TRF_COMMENTS")) = False Then
                                                        newTaskRow.Item("Traffic Comments") = ds.Tables(1).Rows(w)("TRF_COMMENTS")
                                                    End If
                                                    currentJob = ds.Tables(1).Rows(w)("JOB_NUMBER")
                                                    currentComp = ds.Tables(1).Rows(w)("JOB_COMPONENT_NBR")
                                                    For I = 1 To 30
                                                        If llOrigDueDate = True Then
                                                            If TaskDesc(I) <> "" Then
                                                                If TaskDesc(I) = ds.Tables(1).Rows(w)("FNC_CODE") Then
                                                                    If IsDBNull(ds.Tables(1).Rows(w)("JOB_COMPLETED_DATE")) = True Then
                                                                        newTaskRow.Item("Task" & I) = ds.Tables(1).Rows(w)("JOB_REVISED_DATE")
                                                                    Else
                                                                        newTaskRow.Item("Task" & I) = "X"
                                                                    End If
                                                                    currentTask = ds.Tables(1).Rows(w)("FNC_CODE")
                                                                End If
                                                            End If
                                                        End If
                                                    Next I
                                                    ds.Tables(2).Rows.Add(newTaskRow)
                                                    rowCount += 1
                                                End If
                                            Else
                                                newTaskRow = ds.Tables(2).NewRow
                                                newTaskRow.Item("Employee") = ds.Tables(1).Rows(w)("EMP_NAME")
                                                currentEmp = ds.Tables(1).Rows(w)("EMP_CODE")
                                                ds.Tables(2).Rows.Add(newTaskRow)
                                                w -= 1
                                                rowCount += 1
                                            End If
                                        Else
                                            newTaskRow = ds.Tables(2).NewRow
                                            newTaskRow.Item("Employee") = ds.Tables(1).Rows(w)("EMP_NAME")
                                            currentEmp = ds.Tables(1).Rows(w)("EMP_CODE")
                                            ds.Tables(2).Rows.Add(newTaskRow)
                                            w -= 1
                                            rowCount += 1
                                        End If
                                    Else
                                        newTaskRow = ds.Tables(2).NewRow
                                        newTaskRow.Item(0) = "emptygrayline"
                                        ds.Tables(2).Rows.Add(newTaskRow)
                                        rowCount += 1
                                        newTaskRow = ds.Tables(2).NewRow
                                        newTaskRow.Item("Role") = ds.Tables(1).Rows(w)("ROLE_DESC")
                                        currentRole = ds.Tables(1).Rows(w)("ROLE_CODE")
                                        ds.Tables(2).Rows.Add(newTaskRow)
                                        currentEmp = ""
                                        currentJob = ""
                                        currentComp = ""
                                        'currentTask = ""
                                        w -= 1
                                        rowCount += 1
                                    End If
                                Else
                                    newTaskRow = ds.Tables(2).NewRow
                                    newTaskRow.Item("Role") = ds.Tables(1).Rows(w)("ROLE_DESC")
                                    currentRole = ds.Tables(1).Rows(w)("ROLE_CODE")
                                    ds.Tables(2).Rows.Add(newTaskRow)
                                    w -= 1
                                    rowCount += 1
                                End If
                            Next
                        End If
                        If strTaskDesc = "" Then
                            If CBool(Request.Params("chkManager")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Manager"))
                            End If
                            If CBool(Request.Params("chkProjectDate")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Start Date"))
                            End If
                            If CBool(Request.Params("chkJobDueDate1")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date1"))
                                If CBool(Request.Params("chkJobDueDate2")) = False Then
                                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date2"))
                                Else
                                    ds.Tables(0).Columns("Job Due Date2").ColumnName = "Job Due Date"
                                End If
                            Else
                                ds.Tables(0).Columns("Job Due Date1").ColumnName = "Job Due Date"
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date2"))
                            End If
                            If CBool(Request.Params("chkClientCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client Code"))
                            End If
                            If CBool(Request.Params("chkClientDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client"))
                            End If
                            If CBool(Request.Params("chkDivisionCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Division Code"))
                            End If
                            If CBool(Request.Params("chkDivisionDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Division"))
                            End If
                            If CBool(Request.Params("chkProductCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Product Code"))
                            End If
                            If CBool(Request.Params("chkProductDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Product"))
                            End If
                            If CBool(Request.Params("chkJobCompNum")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Comp Number"))
                            End If
                            If CBool(Request.Params("chkJobCompDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Component"))
                            End If
                            If CBool(Request.Params("chkClientReference")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client Reference"))
                            End If
                            If CBool(Request.Params("chkAccountExecutive")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Account Executive"))
                            End If
                            If CBool(Request.Params("chkJobType")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Type"))
                            End If
                            If CBool(Request.Params("chkJobTypeDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Type Description"))
                            End If
                            If CBool(Request.Params("chkJobStatus")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Status"))
                            End If
                            If CBool(Request.Params("chkComments")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Traffic Comments"))
                            End If
                            If CBool(Request.Params("chkCompletedDate")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Completed Date"))
                            End If
                            If CBool(Request.Params("chkRush")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Rush"))
                            End If
                            If CBool(Request.Params("chkJobMarkup")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Markup"))
                            End If
                            If CBool(Request.Params("chkJobNonBillFlag")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Non Bill Flag"))
                            End If

                            For I = 1 To 30
                                If TaskDesc(I) <> "" Then
                                    If ds.Tables(0).Columns.Contains(TaskDesc(I)) = False Then
                                        ds.Tables(0).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I)
                                    Else
                                        ds.Tables(0).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I) & " " & CStr(I)
                                    End If
                                Else
                                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Task" & CStr(I)))
                                End If
                            Next I

                            If CBool(Request.QueryString("excel")) = True Then
                                Convert(ds)
                            Else
                                If Request.QueryString("OnlyProjected") <> Nothing Then
                                    If Request.QueryString("OnlyProjected") = "-1" Then
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle") & " (Showing Only Projected)"
                                    Else
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle")
                                    End If
                                End If
                                Me.gridReport.DataSource = ds.Tables(0).DefaultView
                                Me.gridReport.DataBind()
                            End If
                        Else
                            ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("DateTitles"))
                            If CBool(Request.Params("chkManager")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Manager"))
                            End If
                            If CBool(Request.Params("chkProjectDate")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Start Date"))
                            End If
                            If CBool(Request.Params("chkJobDueDate1")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date1"))
                                If CBool(Request.Params("chkJobDueDate2")) = False Then
                                    ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date2"))
                                Else
                                    ds.Tables(2).Columns("Job Due Date2").ColumnName = "Job Due Date"
                                End If
                            Else
                                ds.Tables(2).Columns("Job Due Date1").ColumnName = "Job Due Date"
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date2"))
                            End If
                            If CBool(Request.Params("chkClientCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client Code"))
                            End If
                            If CBool(Request.Params("chkClientDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client"))
                            End If
                            If CBool(Request.Params("chkDivisionCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Division Code"))
                            End If
                            If CBool(Request.Params("chkDivisionDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Division"))
                            End If
                            If CBool(Request.Params("chkProductCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Product Code"))
                            End If
                            If CBool(Request.Params("chkProductDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Product"))
                            End If
                            If CBool(Request.Params("chkJobCompNum")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Comp Number"))
                            End If
                            If CBool(Request.Params("chkJobCompDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Component"))
                            End If
                            If CBool(Request.Params("chkClientReference")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client Reference"))
                            End If
                            If CBool(Request.Params("chkAccountExecutive")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Account Executive"))
                            End If
                            If CBool(Request.Params("chkJobType")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Type"))
                            End If
                            If CBool(Request.Params("chkJobTypeDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Type Description"))
                            End If
                            If CBool(Request.Params("chkJobStatus")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Status"))
                            End If
                            If CBool(Request.Params("chkComments")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Traffic Comments"))
                            End If
                            If CBool(Request.Params("chkCompletedDate")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Completed Date"))
                            End If
                            If CBool(Request.Params("chkRush")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Rush"))
                            End If
                            If CBool(Request.Params("chkJobMarkup")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Markup"))
                            End If
                            If CBool(Request.Params("chkJobNonBillFlag")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Non Bill Flag"))
                            End If

                            For I = 1 To 30
                                If TaskDesc(I) <> "" Then
                                    If llChkIncludeTaskDesc = True Then
                                        'ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))
                                        If ds.Tables(2).Columns.Contains(Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))) = False Then
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))
                                        Else
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I)) & " " & CStr(I)
                                        End If
                                    Else
                                        If ds.Tables(2).Columns.Contains(TaskDesc(I)) = False Then
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I)
                                        Else
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I) & " " & CStr(I)
                                        End If
                                    End If
                                Else
                                    ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Task" & CStr(I)))
                                End If
                            Next I

                            If CBool(Request.QueryString("excel")) = True Then
                                Convert(ds)
                            Else
                                If Request.QueryString("OnlyProjected") <> Nothing Then
                                    If Request.QueryString("OnlyProjected") = "-1" Then
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle") & " (Showing Only Projected)"
                                    Else
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle")
                                    End If
                                End If
                                Me.gridReport.DataSource = ds.Tables(2).DefaultView
                                Me.gridReport.DataBind()
                            End If
                        End If
                    Else
                        ds = oReport.TrafficScheduleSA(lcClients, lcStatus, TaskDesc, llCompleteDates, llClosed, llOnlyProjected, lcOffices, llDueDate, llOrigDueDate, llOrigDueDateCompDate, llDueDateCompDate, llEmpCode, llsort1, llsort2, llForJobDueDate, llForJobStartDate, llForJobEndDate, llIncludeClosedStartDate, llIncludeClosedEndDate, llManager, llDueTime, lcAECodes, Session("UserCode"), lcRlCodes, Me.IsClientPortal, Session("UserID"))
                        'Sort Dataset
                        'ds.Tables(0).DefaultView.Sort = Request.Params("sort1") & ", " & Request.Params("sort2")
                        If ds.Tables(0).Rows.Count = 0 Then
                            Session("nodataTSBT") = "1"
                            If CBool(Request.QueryString("excel")) = True Then
                                Response.Redirect("TrafficScheduleByTask_Settings.aspx")
                            Else
                                Me.CloseThisWindowAndRefreshCaller("TrafficScheduleByTask_Settings.aspx")
                            End If
                            Exit Sub
                        End If
                        ds.Tables(2).Rows.Remove(ds.Tables(2).Rows(0))
                        Dim DtTRF_DESC As New DataTable
                        Try
                            DtTRF_DESC = ds.Tables(3)
                        Catch ex As Exception
                            DtTRF_DESC = Nothing
                        End Try

                        If strTaskDesc <> "" Then
                            Dim parent() As DataColumn
                            Dim child() As DataColumn
                            parent = New DataColumn() {ds.Tables(0).Columns("Job Number"), ds.Tables(0).Columns("Comp Number")}
                            child = New DataColumn() {ds.Tables(1).Columns("JOB_NUMBER"), ds.Tables(1).Columns("JOB_COMPONENT_NBR")}
                            ds.Relations.Add("pcRelation", parent, child)

                            Dim parentRow, childRow As DataRow
                            Dim j As Integer
                            Dim newTaskRow As DataRow
                            Dim rowCount As Integer = 0
                            Dim currentTask As String = ""
                            Dim currentJob As String = ""
                            Dim currentComp As String = ""
                            Dim taskwithEmp As String = ""
                            For Each parentRow In ds.Tables(0).Rows
                                For Each childRow In parentRow.GetChildRows("pcRelation")
                                    If currentTask <> "" Then
                                        If currentTask = childRow("FNC_CODE") Then
                                            For I = 1 To 30
                                                If llCompleteDates = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_COMPLETED_DATE")
                                                        End If
                                                    End If
                                                End If
                                                If llDueDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE")
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & "X"
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                                If llDueTime = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("REVISED_DUE_TIME").ToString.Replace("-", " to ")
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-X-X" ' & childRow("REVISED_DUE_TIME").ToString
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                                If llOrigDueDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_DUE_DATE")
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & "X"
                                                            End If
                                                        End If
                                                    End If

                                                End If
                                                If llOrigDueDateCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_DUE_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                        End If
                                                    End If
                                                End If
                                                If llDueDateCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                        End If
                                                    End If

                                                End If
                                                If llDueDateorCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & If(IsDBNull(childRow("JOB_REVISED_DATE")) = False, CDate(childRow("JOB_REVISED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_REVISED_DATE")).Day.ToString.PadLeft(2, "0"), "")
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE")
                                                                End If
                                                            Else
                                                                If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & If(IsDBNull(childRow("JOB_COMPLETED_DATE")) = False, CDate(childRow("JOB_COMPLETED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_COMPLETED_DATE")).Day.ToString.PadLeft(2, "0"), "") & "boldfont"
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_COMPLETED_DATE")
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                                If llEmpCode = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("EMP_CODE").ToString() & "-" & childRow("SEQ_NBR").ToString
                                                        End If
                                                    End If
                                                End If
                                                If llPhase = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("PHASE_DESC").ToString().Replace("-", ":") & "-" & childRow("SEQ_NBR").ToString
                                                        End If
                                                    End If
                                                End If
                                            Next I
                                        Else
                                            For I = 1 To 30
                                                If llCompleteDates = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_COMPLETED_DATE")
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_COMPLETED_DATE")
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llDueDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE")
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_REVISED_DATE")
                                                                End If
                                                            Else
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & "X"
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = "X"
                                                                End If
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llDueTime = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("REVISED_DUE_TIME").ToString.Replace("-", " to ")
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("REVISED_DUE_TIME").ToString.Replace("-", " to ")
                                                                End If
                                                            Else
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-X-X" ' & childRow("REVISED_DUE_TIME").ToString
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = "X-X" ' & childRow("REVISED_DUE_TIME").ToString
                                                                End If
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llOrigDueDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_DUE_DATE")
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_DUE_DATE")
                                                                End If
                                                            Else
                                                                If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & "X"
                                                                Else
                                                                    ds.Tables(2).Rows(rowCount - 1)("Task" & I) = "X"
                                                                End If
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If

                                                End If
                                                If llOrigDueDateCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_DUE_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_DUE_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llDueDateCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                            Else
                                                                ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If

                                                End If
                                                If llDueDateorCompDate = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                                If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & If(IsDBNull(childRow("JOB_REVISED_DATE")) = False, CDate(childRow("JOB_REVISED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_REVISED_DATE")).Day.ToString.PadLeft(2, "0"), "")
                                                                    Else
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = If(IsDBNull(childRow("JOB_REVISED_DATE")) = False, CDate(childRow("JOB_REVISED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_REVISED_DATE")).Day.ToString.PadLeft(2, "0"), "")
                                                                    End If
                                                                Else
                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_REVISED_DATE")
                                                                    Else
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_REVISED_DATE")
                                                                    End If
                                                                End If
                                                            Else
                                                                If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & If(IsDBNull(childRow("JOB_COMPLETED_DATE")) = False, CDate(childRow("JOB_COMPLETED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_COMPLETED_DATE")).Day.ToString.PadLeft(2, "0"), "") & "boldfont"
                                                                    Else
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = If(IsDBNull(childRow("JOB_COMPLETED_DATE")) = False, CDate(childRow("JOB_COMPLETED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_COMPLETED_DATE")).Day.ToString.PadLeft(2, "0"), "") & "boldfont"
                                                                    End If
                                                                Else
                                                                    If IsDBNull(ds.Tables(2).Rows(rowCount - 1)("Task" & I)) = False Then
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = ds.Tables(2).Rows(rowCount - 1)("Task" & I) & "-" & childRow("JOB_COMPLETED_DATE")
                                                                    Else
                                                                        ds.Tables(2).Rows(rowCount - 1)("Task" & I) = childRow("JOB_COMPLETED_DATE")
                                                                    End If
                                                                End If
                                                            End If
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llEmpCode = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = newTaskRow.Item("Task" & I) & "-" & childRow("EMP_CODE").ToString() & "-" & childRow("SEQ_NBR").ToString
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                                If llPhase = True Then
                                                    If TaskDesc(I) <> "" Then
                                                        If TaskDesc(I) = childRow("FNC_CODE") Then
                                                            ds.Tables(2).Rows(rowCount - 1)("Task" & I) = newTaskRow.Item("Task" & I) & "-" & childRow("PHASE_DESC").ToString().Replace("-", ":") & "-" & childRow("SEQ_NBR").ToString
                                                            currentTask = childRow("FNC_CODE")
                                                        End If
                                                    End If
                                                End If
                                            Next I
                                        End If
                                    Else
                                        newTaskRow = ds.Tables(2).NewRow
                                        newTaskRow.Item("Job Status First") = parentRow("Job Status First")
                                        newTaskRow.Item("Manager") = parentRow("Manager")
                                        newTaskRow.Item("Job Start Date") = parentRow("Job Start Date")
                                        newTaskRow.Item("Job Due Date1") = parentRow("Job Due Date1")
                                        newTaskRow.Item("Job Completed Date") = parentRow("Job Completed Date")
                                        newTaskRow.Item("Client Code") = parentRow("Client Code")
                                        newTaskRow.Item("Client") = parentRow("Client")
                                        newTaskRow.Item("Division Code") = parentRow("Division Code")
                                        newTaskRow.Item("Division") = parentRow("Division")
                                        newTaskRow.Item("Product Code") = parentRow("Product Code")
                                        newTaskRow.Item("Product") = parentRow("Product")
                                        newTaskRow.Item("Job Number") = parentRow("Job Number")
                                        newTaskRow.Item("Job") = parentRow("Job")
                                        newTaskRow.Item("Comp Number") = parentRow("Comp Number")
                                        newTaskRow.Item("Component") = parentRow("Component")
                                        newTaskRow.Item("Client Reference") = parentRow("Client Reference")
                                        newTaskRow.Item("Account Executive") = parentRow("Account Executive")
                                        newTaskRow.Item("Job Type") = parentRow("Job Type")
                                        newTaskRow.Item("Job Type Description") = parentRow("Job Type Description")
                                        newTaskRow.Item("Rush") = parentRow("Rush")
                                        newTaskRow.Item("Job Markup") = parentRow("Job Markup")
                                        newTaskRow.Item("Job Non Bill Flag") = parentRow("Job Non Bill Flag")
                                        newTaskRow.Item("Job Due Date2") = parentRow("Job Due Date2")
                                        newTaskRow.Item("Job Status") = parentRow("Job Status")
                                        newTaskRow.Item("Traffic Comments") = parentRow("Traffic Comments")
                                        For I = 1 To 30
                                            If llCompleteDates = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        newTaskRow.Item("Task" & I) = childRow("JOB_COMPLETED_DATE")
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llDueDate = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                            newTaskRow.Item("Task" & I) = childRow("JOB_REVISED_DATE")
                                                        Else
                                                            newTaskRow.Item("Task" & I) = "X"
                                                        End If
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llDueTime = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                            newTaskRow.Item("Task" & I) = childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("REVISED_DUE_TIME").ToString.Replace("-", " to ")
                                                        Else
                                                            newTaskRow.Item("Task" & I) = "X-X" ' & childRow("REVISED_DUE_TIME").ToString
                                                        End If
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llOrigDueDate = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                            newTaskRow.Item("Task" & I) = childRow("JOB_DUE_DATE")
                                                        Else
                                                            newTaskRow.Item("Task" & I) = "X"
                                                        End If
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If

                                            End If
                                            If llOrigDueDateCompDate = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        newTaskRow.Item("Task" & I) = childRow("JOB_DUE_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llDueDateCompDate = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        newTaskRow.Item("Task" & I) = childRow("JOB_REVISED_DATE").ToString() & "-" & childRow("JOB_COMPLETED_DATE").ToString
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If

                                            End If
                                            If llDueDateorCompDate = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        If IsDBNull(childRow("JOB_COMPLETED_DATE")) = True Then
                                                            If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                newTaskRow.Item("Task" & I) = If(IsDBNull(childRow("JOB_REVISED_DATE")) = False, CDate(childRow("JOB_REVISED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_REVISED_DATE")).Day.ToString.PadLeft(2, "0"), "")
                                                            Else
                                                                newTaskRow.Item("Task" & I) = childRow("JOB_REVISED_DATE")
                                                            End If
                                                        Else
                                                            If CBool(Request.Params("CheckBoxDateFormat")) = True Then
                                                                newTaskRow.Item("Task" & I) = If(IsDBNull(childRow("JOB_COMPLETED_DATE")) = False, CDate(childRow("JOB_COMPLETED_DATE")).Month.ToString & "/" & CDate(childRow("JOB_COMPLETED_DATE")).Day.ToString.PadLeft(2, "0"), "") & "boldfont"
                                                            Else
                                                                newTaskRow.Item("Task" & I) = childRow("JOB_COMPLETED_DATE")
                                                            End If
                                                        End If
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llEmpCode = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        newTaskRow.Item("Task" & I) = newTaskRow.Item("Task" & I) & "-" & childRow("EMP_CODE").ToString() & "-" & childRow("SEQ_NBR").ToString
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                            If llPhase = True Then
                                                If TaskDesc(I) <> "" Then
                                                    If TaskDesc(I) = childRow("FNC_CODE") Then
                                                        newTaskRow.Item("Task" & I) = newTaskRow.Item("Task" & I) & "-" & childRow("PHASE_DESC").ToString().Replace("-", ":") & "-" & childRow("SEQ_NBR").ToString
                                                        currentTask = childRow("FNC_CODE")
                                                    End If
                                                End If
                                            End If
                                        Next I
                                        ds.Tables(2).Rows.Add(newTaskRow)
                                        rowCount += 1
                                    End If

                                Next
                                currentTask = ""
                            Next
                        End If



                        If strTaskDesc = "" Then
                            ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("DateTitles"))
                        ElseIf Request.QueryString("Format") <> "3" Then
                            Dim w As Integer
                            Dim x As Integer
                            Dim str() As String
                            Dim strDate As String = ""
                            Dim strEmps As String = ""
                            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                            If (llOrigDueDateCompDate = True Or llDueDateCompDate = True) And (llEmpCode = True Or llPhase = True) Then
                                If llPhase = True And llEmpCode = True Then
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                Else
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                End If
                                For I = 0 To CountRow - 1
                                    Dim newRow As DataRow = ds.Tables(2).NewRow
                                    Dim newRow2 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow3 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow4 As DataRow = ds.Tables(2).NewRow
                                    If llPhase = True Then
                                        newRow4.Item("DateTitles") = "Phase:"
                                    End If
                                    newRow.Item("DateTitles") = "Completed Date:"
                                    newRow2.Item("DateTitles") = "Employee:"
                                    If llOrigDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Due Date:"
                                    End If
                                    If llDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    For w = 0 To ds.Tables(2).Columns.Count - 1
                                        If InStr(ds.Tables(2).Columns(w).ColumnName, "Task") > 0 Then
                                            If ds.Tables(2).Rows(I)(w).ToString() <> "" Then
                                                str = ds.Tables(2).Rows(I)(w).ToString.Split("-")
                                                Dim num As Integer = str.Length
                                                If llPhase = True And llEmpCode = True Then
                                                    If str.Length > 6 Then
                                                        For x = 0 To str.Length - 1
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                            If str(x + 2).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 2).Trim & "/"
                                                            End If
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 4).Trim & "/"
                                                            x += 5
                                                        Next
                                                        If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                            newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        newRow3.Item(w) = "emptygrayline"
                                                        strDate = ""
                                                    Else
                                                        newRow.Item(w) = str(1).Trim
                                                        If str(2).Trim = "..." Then
                                                            If lcRlCodes <> "..." Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim))
                                                            End If
                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(2).Trim
                                                        End If
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow4.Item(w) = str(4).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                Else
                                                    If str.Length > 4 Then
                                                        For x = 0 To str.Length - 1
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                            If str(x + 2).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 2).Trim & "/"
                                                            End If
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 2).Trim & "/"
                                                            x += 3
                                                        Next
                                                        If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                            newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        newRow3.Item(w) = "emptygrayline"
                                                        strDate = ""
                                                    Else
                                                        newRow.Item(w) = str(1).Trim
                                                        If str(2).Trim = "..." Then
                                                            If lcRlCodes <> "..." Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim))
                                                            End If
                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(2).Trim
                                                        End If
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow4.Item(w) = str(2).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                End If
                                            Else
                                                newRow3.Item(w) = "emptygrayline"
                                            End If
                                        End If
                                    Next
                                    If llPhase = True And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 3)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 4)
                                        I = I + 4
                                    ElseIf llPhase = False And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 3)
                                        I = I + 3
                                    ElseIf llPhase = True And llEmpCode = False Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 3)
                                        I = I + 3
                                    End If
                                Next
                                ds.Tables(2).Columns("DateTitles").ColumnName = "-"
                            ElseIf (llOrigDueDateCompDate = True Or llDueDateCompDate = True) And llEmpCode = False And llPhase = False Then
                                For I = 0 To ((ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count) - 1)
                                    Dim newRow As DataRow = ds.Tables(2).NewRow
                                    Dim newRow2 As DataRow = ds.Tables(2).NewRow
                                    newRow.Item("DateTitles") = "Completed Date:"
                                    If llOrigDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Due Date:"
                                    End If
                                    If llDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    For w = 0 To ds.Tables(2).Columns.Count - 1
                                        If InStr(ds.Tables(2).Columns(w).ColumnName, "Task") > 0 Then
                                            If ds.Tables(2).Rows(I)(w).ToString() <> "" Then
                                                str = ds.Tables(2).Rows(I)(w).ToString.Split("-")
                                                Dim num As Integer = str.Length
                                                If str.Length > 2 Then
                                                    For x = 0 To str.Length - 1
                                                        newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                        strDate = strDate.Trim & str(x).Trim & ","
                                                        x += 1
                                                    Next
                                                    If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                        ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                    End If
                                                    If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                        newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                    End If
                                                    newRow2.Item(w) = "emptygrayline"
                                                    strDate = ""
                                                Else
                                                    newRow.Item(w) = str(1).Trim
                                                    ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                    newRow2.Item(w) = "emptygrayline"
                                                End If
                                            Else
                                                newRow2.Item(w) = "emptygrayline"
                                            End If
                                        End If
                                    Next
                                    ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                    ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                    I = I + 2
                                Next
                                ds.Tables(2).Columns("DateTitles").ColumnName = "-"
                            ElseIf llDueTime = True And (llEmpCode = True Or llPhase = True) Then
                                If llPhase = True And llEmpCode = True Then
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                Else
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                End If
                                For I = 0 To CountRow - 1
                                    Dim newRow As DataRow = ds.Tables(2).NewRow
                                    Dim newRow2 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow3 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow4 As DataRow = ds.Tables(2).NewRow
                                    If llPhase = True Then
                                        newRow4.Item("DateTitles") = "Phase:"
                                    End If
                                    newRow.Item("DateTitles") = "Time Due:"
                                    newRow2.Item("DateTitles") = "Employee:"
                                    If llDueTime = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    For w = 0 To ds.Tables(2).Columns.Count - 1
                                        If InStr(ds.Tables(2).Columns(w).ColumnName, "Task") > 0 Then
                                            If ds.Tables(2).Rows(I)(w).ToString() <> "" Then
                                                str = ds.Tables(2).Rows(I)(w).ToString.Split("-")
                                                Dim num As Integer = str.Length
                                                If llPhase = True And llEmpCode = True Then
                                                    If str.Length > 5 Then
                                                        For x = 0 To str.Length - 1
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                            If str(x + 2).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 2).Trim & "/"
                                                            End If
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 4).Trim & "/"
                                                            x += 5
                                                        Next
                                                        If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                            newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        newRow3.Item(w) = "emptygrayline"
                                                        strDate = ""
                                                    Else
                                                        newRow.Item(w) = str(1).Trim
                                                        If str(2).Trim = "..." Then
                                                            If lcRlCodes <> "" Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim))
                                                            End If

                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(2).Trim
                                                        End If
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow4.Item(w) = str(4).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                Else
                                                    If str.Length > 4 Then
                                                        For x = 0 To str.Length - 1
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                            If str(x + 2).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 3).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 2).Trim & "/"
                                                            End If
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 2).Trim & "/"
                                                            x += 3
                                                        Next
                                                        If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                            newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        newRow3.Item(w) = "emptygrayline"
                                                        strDate = ""
                                                    Else
                                                        newRow.Item(w) = str(1).Trim
                                                        If str(2).Trim = "..." Then
                                                            If lcRlCodes <> "" Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(3).Trim))
                                                            End If

                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(2).Trim
                                                        End If
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow4.Item(w) = str(2).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                End If

                                            Else
                                                newRow3.Item(w) = "emptygrayline"
                                            End If
                                        End If
                                    Next
                                    If llPhase = True And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 3)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 4)
                                        I = I + 4
                                    ElseIf llPhase = False And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 3)
                                        I = I + 3
                                    ElseIf llPhase = True And llEmpCode = False Then
                                        ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 3)
                                        I = I + 3
                                    End If
                                Next
                                ds.Tables(2).Columns("DateTitles").ColumnName = "-"
                            ElseIf llDueTime = True And llEmpCode = False And llPhase = False Then
                                For I = 0 To ((ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count) - 1)
                                    Dim newRow As DataRow = ds.Tables(2).NewRow
                                    Dim newRow2 As DataRow = ds.Tables(2).NewRow
                                    newRow.Item("DateTitles") = "Time Due:"
                                    If llDueTime = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    For w = 0 To ds.Tables(2).Columns.Count - 1
                                        If InStr(ds.Tables(2).Columns(w).ColumnName, "Task") > 0 Then
                                            If ds.Tables(2).Rows(I)(w).ToString() <> "" Then
                                                str = ds.Tables(2).Rows(I)(w).ToString.Split("-")
                                                Dim num As Integer = str.Length
                                                If str.Length > 2 Then
                                                    For x = 0 To str.Length - 1
                                                        newRow.Item(w) = newRow.Item(w) & str(x + 1).Trim & ","
                                                        strDate = strDate.Trim & str(x).Trim & ","
                                                        x += 1
                                                    Next
                                                    If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                        ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                    End If
                                                    If newRow.Item(w).ToString.Length <> 0 And newRow.Item(w).ToString.EndsWith(",") Then
                                                        newRow.Item(w) = newRow.Item(w).ToString.Substring(0, newRow.Item(w).ToString.Length - 1)
                                                    End If
                                                    strDate = ""
                                                Else
                                                    newRow.Item(w) = str(1).Trim
                                                    ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                End If
                                                newRow2.Item(w) = "emptygrayline"
                                            Else
                                                newRow2.Item(w) = "emptygrayline"
                                            End If
                                        End If
                                    Next
                                    ds.Tables(2).Rows.InsertAt(newRow, I + 1)
                                    ds.Tables(2).Rows.InsertAt(newRow2, I + 2)
                                    I = I + 2
                                Next
                                ds.Tables(2).Columns("DateTitles").ColumnName = "-"

                            ElseIf llOrigDueDateCompDate = False And llDueDateCompDate = False And (llEmpCode = True Or llPhase = True) Then
                                If llPhase = True And llEmpCode = True Then
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                Else
                                    CountRow = ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count + ds.Tables(2).Rows.Count
                                End If
                                For I = 0 To CountRow - 1
                                    Dim newRow2 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow3 As DataRow = ds.Tables(2).NewRow
                                    Dim newRow4 As DataRow = ds.Tables(2).NewRow
                                    newRow2.Item("DateTitles") = "Employee:"
                                    If llPhase = True Then
                                        newRow4.Item("DateTitles") = "Phase:"
                                    End If
                                    If llOrigDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Due Date:"
                                    End If
                                    If llDueDateCompDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    If llOrigDueDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Due Date:"
                                    End If
                                    If llDueDate = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Revised Due Date:"
                                    End If
                                    If llCompleteDates = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Completed Date:"
                                    End If
                                    If llDueTime = True Then
                                        ds.Tables(2).Rows(I)("DateTitles") = "Time Due:"
                                    End If
                                    For w = 0 To ds.Tables(2).Columns.Count - 1
                                        If InStr(ds.Tables(2).Columns(w).ColumnName, "Task") > 0 Then
                                            If ds.Tables(2).Rows(I)(w).ToString() <> "" Then
                                                str = ds.Tables(2).Rows(I)(w).ToString.Split("-")
                                                Dim num As Integer = str.Length
                                                If llPhase = True And llEmpCode = True Then
                                                    If str.Length > 5 Then
                                                        For x = 0 To str.Length - 1
                                                            If str(x + 1).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 2).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 2).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 1).Trim & "/"
                                                            End If
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 3).Trim & "/"
                                                            newRow3.Item(w) = "emptygrayline"
                                                            x += 4
                                                        Next
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        strDate = ""
                                                    ElseIf str.Length > 1 Then
                                                        If str(1).Trim = "..." Then
                                                            If lcRlCodes <> "" Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(2).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(2).Trim))
                                                            End If
                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(1).Trim
                                                        End If
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow4.Item(w) = str(3).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                Else
                                                    If str.Length > 3 Then
                                                        For x = 0 To str.Length - 1
                                                            If str(x + 1).Trim = "..." Then
                                                                If lcRlCodes <> "" Then
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 2).Trim), lcRlCodes)
                                                                Else
                                                                    strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(x + 2).Trim))
                                                                End If
                                                                If strEmps <> "" Then
                                                                    newRow2.Item(w) = newRow2.Item(w) & strEmps.Trim & "/"
                                                                End If
                                                            Else
                                                                newRow2.Item(w) = newRow2.Item(w) & str(x + 1).Trim & "/"
                                                            End If
                                                            newRow4.Item(w) = newRow4.Item(w) & str(x + 1).Trim & "/"
                                                            strDate = strDate.Trim & str(x).Trim & ","
                                                            newRow3.Item(w) = "emptygrayline"
                                                            x += 2
                                                        Next
                                                        If strDate.Length <> 0 And strDate.EndsWith(",") Then
                                                            ds.Tables(2).Rows(I)(w) = strDate.Substring(0, strDate.Length - 1)
                                                        End If
                                                        If newRow2.Item(w).ToString.Length <> 0 And (newRow2.Item(w).ToString.EndsWith(",") Or newRow2.Item(w).ToString.EndsWith("/")) Then
                                                            newRow2.Item(w) = newRow2.Item(w).ToString.Substring(0, newRow2.Item(w).ToString.Length - 1)
                                                        End If
                                                        strDate = ""
                                                    ElseIf str.Length > 1 Then
                                                        If str(1).Trim = "..." Then
                                                            If lcRlCodes <> "" Then
                                                                strEmps = oTrafficSchedule.GetTaskEmpListStringByRole(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(2).Trim), lcRlCodes)
                                                            Else
                                                                strEmps = oTrafficSchedule.GetTaskEmpListString(CInt(ds.Tables(2).Rows(I)("Job Number")), CInt(ds.Tables(2).Rows(I)("Comp Number")), CInt(str(2).Trim))
                                                            End If
                                                            If strEmps <> "" Then
                                                                newRow2.Item(w) = strEmps
                                                            End If
                                                        Else
                                                            newRow2.Item(w) = str(1).Trim
                                                        End If
                                                        newRow4.Item(w) = str(1).Trim
                                                        ds.Tables(2).Rows(I)(w) = str(0).Trim
                                                        newRow3.Item(w) = "emptygrayline"
                                                    End If
                                                End If
                                            Else
                                                newRow3.Item(w) = "emptygrayline"
                                            End If
                                        End If
                                    Next
                                    If llPhase = True And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 2)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 3)
                                        I = I + 3
                                    ElseIf llPhase = False And llEmpCode = True Then
                                        ds.Tables(2).Rows.InsertAt(newRow2, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 2)
                                        I = I + 2
                                    ElseIf llPhase = True And llEmpCode = False Then
                                        ds.Tables(2).Rows.InsertAt(newRow4, I + 1)
                                        ds.Tables(2).Rows.InsertAt(newRow3, I + 2)
                                        I = I + 2
                                    End If
                                Next
                                ds.Tables(2).Columns("DateTitles").ColumnName = "-"
                            Else
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("DateTitles"))
                            End If
                        End If
                        If strTaskDesc = "" Then
                            If CBool(Request.Params("chkManager")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Manager"))
                            End If
                            If CBool(Request.Params("chkProjectDate")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Start Date"))
                            End If
                            If CBool(Request.Params("chkJobDueDate1")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date1"))
                                If CBool(Request.Params("chkJobDueDate2")) = False Then
                                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date2"))
                                Else
                                    ds.Tables(0).Columns("Job Due Date2").ColumnName = "Job Due Date"
                                End If
                            Else
                                ds.Tables(0).Columns("Job Due Date1").ColumnName = "Job Due Date"
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Due Date2"))
                            End If
                            If CBool(Request.Params("chkClientCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client Code"))
                            End If
                            If CBool(Request.Params("chkClientDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client"))
                            End If
                            If CBool(Request.Params("chkDivisionCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Division Code"))
                            End If
                            If CBool(Request.Params("chkDivisionDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Division"))
                            End If
                            If CBool(Request.Params("chkProductCode")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Product Code"))
                            End If
                            If CBool(Request.Params("chkProductDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Product"))
                            End If
                            If CBool(Request.Params("chkJobDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job"))
                            End If
                            If CBool(Request.Params("chkJobCompNum")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Comp Number"))
                            End If
                            If CBool(Request.Params("chkJobCompDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Component"))
                            End If
                            If CBool(Request.Params("chkClientReference")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Client Reference"))
                            End If
                            If CBool(Request.Params("chkAccountExecutive")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Account Executive"))
                            End If
                            If CBool(Request.Params("chkJobType")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Type"))
                            End If
                            If CBool(Request.Params("chkJobTypeDesc")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Type Description"))
                            End If
                            If CBool(Request.Params("chkJobStatus")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Status"))
                            End If
                            If CBool(Request.Params("chkJobStatusFirst")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Status First"))
                            Else
                                ds.Tables(0).Columns("Job Status First").ColumnName = "Job Status "
                            End If
                            If CBool(Request.Params("chkComments")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Traffic Comments"))
                            End If
                            If CBool(Request.Params("chkCompletedDate")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Completed Date"))
                            End If
                            If CBool(Request.Params("chkRush")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Rush"))
                            End If
                            If CBool(Request.Params("chkJobMarkup")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Markup"))
                            End If
                            If CBool(Request.Params("chkJobNonBillFlag")) = False Then
                                ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Job Non Bill Flag"))
                            End If

                            For I = 1 To 30
                                If TaskDesc(I) <> "" Then
                                    If ds.Tables(0).Columns.Contains(TaskDesc(I)) = False Then
                                        ds.Tables(0).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I)
                                    Else
                                        ds.Tables(0).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I) & " " & CStr(I)
                                    End If
                                Else
                                    ds.Tables(0).Columns.Remove(ds.Tables(0).Columns("Task" & CStr(I)))
                                End If
                            Next I

                            If CBool(Request.QueryString("excel")) = True Then
                                Convert(ds)
                            Else
                                If Request.QueryString("OnlyProjected") <> Nothing Then
                                    If Request.QueryString("OnlyProjected") = "-1" Then
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle") & " (Showing Only Projected)"
                                    Else
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle")
                                    End If
                                End If
                                Me.gridReport.DataSource = ds.Tables(0).DefaultView
                                Me.gridReport.DataBind()
                            End If
                        Else
                            If CBool(Request.Params("chkManager")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Manager"))
                            End If
                            If CBool(Request.Params("chkProjectDate")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Start Date"))
                            End If
                            If CBool(Request.Params("chkJobDueDate1")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date1"))
                                If CBool(Request.Params("chkJobDueDate2")) = False Then
                                    ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date2"))
                                Else
                                    ds.Tables(2).Columns("Job Due Date2").ColumnName = "Job Due Date"
                                End If
                            Else
                                ds.Tables(2).Columns("Job Due Date1").ColumnName = "Job Due Date"
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Due Date2"))
                            End If
                            If CBool(Request.Params("chkClientCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client Code"))
                            End If
                            If CBool(Request.Params("chkClientDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client"))
                            End If
                            If CBool(Request.Params("chkDivisionCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Division Code"))
                            End If
                            If CBool(Request.Params("chkDivisionDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Division"))
                            End If
                            If CBool(Request.Params("chkProductCode")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Product Code"))
                            End If
                            If CBool(Request.Params("chkProductDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Product"))
                            End If
                            If CBool(Request.Params("chkJobDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job"))
                            End If
                            If CBool(Request.Params("chkJobCompNum")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Comp Number"))
                            End If
                            If CBool(Request.Params("chkJobCompDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Component"))
                            End If
                            If CBool(Request.Params("chkClientReference")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Client Reference"))
                            End If
                            If CBool(Request.Params("chkAccountExecutive")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Account Executive"))
                            End If
                            If CBool(Request.Params("chkJobType")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Type"))
                            End If
                            If CBool(Request.Params("chkJobTypeDesc")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Type Description"))
                            End If
                            If CBool(Request.Params("chkJobStatus")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Status"))
                            End If
                            If CBool(Request.Params("chkJobStatusFirst")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Status First"))
                            Else
                                ds.Tables(2).Columns("Job Status First").ColumnName = "Job Status "
                            End If
                            If CBool(Request.Params("chkComments")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Traffic Comments"))
                            End If
                            If CBool(Request.Params("chkCompletedDate")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Completed Date"))
                            End If
                            If CBool(Request.Params("chkRush")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Rush"))
                            End If
                            If CBool(Request.Params("chkJobMarkup")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Markup"))
                            End If
                            If CBool(Request.Params("chkJobNonBillFlag")) = False Then
                                ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Job Non Bill Flag"))
                            End If

                            For I = 1 To 30
                                If TaskDesc(I) <> "" Then
                                    If llChkIncludeTaskDesc = True Then
                                        'ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))
                                        If ds.Tables(2).Columns.Contains(Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))) = False Then
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I))
                                        Else
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = Me.GetTRF_DESC(DtTRF_DESC, TaskDesc(I)) & " " & CStr(I)
                                        End If
                                    Else
                                        If ds.Tables(2).Columns.Contains(TaskDesc(I)) = False Then
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I)
                                        Else
                                            ds.Tables(2).Columns("Task" & CStr(I)).ColumnName = TaskDesc(I) & " " & CStr(I)
                                        End If
                                    End If
                                Else
                                    ds.Tables(2).Columns.Remove(ds.Tables(2).Columns("Task" & CStr(I)))
                                End If
                            Next I

                            If CBool(Request.QueryString("excel")) = True Then
                                Convert(ds)
                            Else
                                If Request.QueryString("OnlyProjected") <> Nothing Then
                                    If Request.QueryString("OnlyProjected") = "-1" Then
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle") & " (Showing Only Projected)"
                                    Else
                                        Me.lblTitle.Text = Session("TrafficByTaskReportTitle")
                                    End If
                                End If
                                Me.gridReport.DataSource = ds.Tables(2).DefaultView
                                Me.gridReport.DataBind()
                            End If
                        End If
                    End If


                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Function GetTRF_DESC(ByVal Dt As DataTable, ByVal TRF_CODE As String, Optional ByVal TruncateVal As Boolean = True) As String
        Try
            Dim dv As DataView = New DataView(Dt)
            dv.RowFilter = "TRF_CODE = '" & TRF_CODE & "'"
            Dim str As String = ""
            If dv.ToTable().Rows.Count > 0 Then
                If TruncateVal = True Then
                    str = dv.ToTable().Rows(0)("TRF_DESC_SHORT")
                Else
                    str = dv.ToTable().Rows(0)("TRF_DESC")
                End If
            Else
                Return TRF_CODE
            End If
            Try
                Return str
            Catch ex As Exception
                Return TRF_CODE
            End Try
        Catch ex As Exception
            Return TRF_CODE
        End Try
    End Function


    Private Sub Convert(ByVal ds As DataSet)

        Dim Filename As String = ""

        If Request.QueryString("Format") = "3" Then

            Filename = "SchedulebyRole"

        Else

            Filename = "SchedulebyTask"

        End If
        If Session("TrafficByTaskReportTitle") IsNot Nothing Then

            Filename = Session("TrafficByTaskReportTitle")

        End If
        If Request.QueryString("taskdesc") = "" Then

            Me.DeliverGrid(ds.Tables(0), Filename)
            Me.CloseThisWindow()

        Else

            Me.DeliverGrid(ds.Tables(2), Filename)
            Me.CloseThisWindow()

        End If

    End Sub

    Private Sub gridReport_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridReport.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim i As Integer
                Dim j As Integer
                For i = 0 To e.Item.Cells.Count - 1
                    If e.Item.Cells(i).Text.Contains("12:00:00 AM") = True Then
                        e.Item.Cells(i).Text = e.Item.Cells(i).Text.Replace("12:00:00 AM", "")
                    End If
                    If e.Item.Cells(i).Text.Contains("1/1/1900") = True Then
                        e.Item.Cells(i).Text = ""
                    End If
                    If e.Item.Cells(i).Text = "emptygrayline" Then
                        For j = 0 To e.Item.Cells.Count - 1
                            e.Item.Cells(j).Text = ""
                            e.Item.Cells(j).BackColor = Color.LightGray
                            e.Item.Cells(j).Height = 5
                        Next
                    End If
                    'If e.Item.Cells(i).Text.Contains("boldfont") Then
                    '    e.Item.Cells(i).Text = e.Item.Cells(i).Text.Replace("boldfont", "")
                    '    e.Item.Font.Bold = True
                    'End If
                    If e.Item.Cells(i).Text.Contains("NOTIME") Then
                        e.Item.Cells(i).Text = e.Item.Cells(i).Text.Replace("NOTIME", "n/a")
                    End If
                    If e.Item.Cells(i).Text.Trim = "," Then
                        e.Item.Cells(i).Text = ""
                    End If
                    Dim check As Boolean = False
                    If e.Item.Cells(i).Text.Trim.Contains("n/a") = True Then
                        Dim str() As String = e.Item.Cells(i).Text.Split(",")
                        For j = 0 To str.Length - 1
                            If str(j) <> "n/a" Then
                                check = True
                            End If
                        Next
                        If check = False Then
                            e.Item.Cells(i).Text = ""
                        End If
                    End If
                    If e.Item.Cells(i).Text.Trim = "n/a" Then
                        e.Item.Cells(i).Text = ""
                    End If
                    If e.Item.Cells(i).Text.Trim = "/" Then
                        e.Item.Cells(i).Text = ""
                    End If
                    If e.Item.Cells(i).Text.Trim.EndsWith("/") Then
                        e.Item.Cells(i).Text = e.Item.Cells(i).Text.Substring(0, e.Item.Cells(i).Text.Length - 1)
                    End If
                    e.Item.Cells(i).Text = e.Item.Cells(i).Text.Replace(",", ", ")
                    e.Item.Cells(i).Text = e.Item.Cells(i).Text.Replace(" , ", ", ")
                    e.Item.Cells(i).Text.Trim()
                    e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub


End Class
