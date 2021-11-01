Imports DayPilot.Web.Ui.Events
Imports DayPilot.Web.Ui.Events.Bubble

Public Class Calendar_Print
    Inherits Webvantage.BaseChildPage
    Public dtThisDate As Date

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim JobNum As Integer
    Dim JobCompNum As Integer
    Dim NonTaskType As String = ""
    Dim view As String = ""
    Dim Duration As Integer = 0
    Dim FromApp As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadCalendar()
        Try
            Dim intDaysInMonth As Integer
            Dim dtFirst As Date
            Dim dtLast As Date
            Dim strEmpCode As String = ""
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
            Dim JCs() As String
            Dim same As Boolean
            Dim nt As Integer

            If Not Session("TaskCalendarSelectedDate") Is Nothing Then
                dtThisDate = CType(Session("TaskCalendarSelectedDate"), Date)
            Else
                dtThisDate = Today.Date
            End If
            ViewState("ThisDate") = dtThisDate

            ' Set Up for navigation links
            intDaysInMonth = dtThisDate.DaysInMonth(dtThisDate.Year, dtThisDate.Month)
            dtFirst = LoGlo.FirstOfMonth(dtThisDate)
            dtLast = LoGlo.LastOfMonth(dtThisDate)

            DayPilotMonthExport.StartDate = dtFirst
            oAppVars.getAllAppVars()

            Dim Dt As New DataTable
            Dim DtMV As New DataTable
            Dim c As New cDayPilot()


            If Request.QueryString("FromApp") = "PS" Then
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         JobNum.ToString,
                                         JobCompNum.ToString,
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))
            ElseIf Request.QueryString("FromApp") = "PSMV" Then
                If Not Session("TrafficScheduleMVJobs") Is Nothing Then
                    If Session("TrafficScheduleMVJobs") <> "" Then
                        JCs = Session("TrafficScheduleMVJobs").ToString.Split("|")
                    End If
                End If

                DtMV = New DataTable("calItems")
                Dim id As DataColumn = New DataColumn("ID")
                Dim empcode As DataColumn = New DataColumn("EMP_CODE")
                Dim empfname As DataColumn = New DataColumn("EMP_FNAME")
                Dim empmi As DataColumn = New DataColumn("EMP_MI")
                Dim emplname As DataColumn = New DataColumn("EMP_LNAME")
                Dim empfmlname As DataColumn = New DataColumn("EMP_FML_NAME")
                Dim empcodefmlname As DataColumn = New DataColumn("EMP_CODE_FML_NAME")
                Dim clcode As DataColumn = New DataColumn("CL_CODE")
                Dim divcode As DataColumn = New DataColumn("DIV_CODE")
                Dim prdcode As DataColumn = New DataColumn("PRD_CODE")
                Dim job As DataColumn = New DataColumn("JOB_NUMBER")
                Dim comp As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                Dim clname As DataColumn = New DataColumn("CL_NAME")
                Dim divname As DataColumn = New DataColumn("DIV_NAME")
                Dim prddesc As DataColumn = New DataColumn("PRD_DESCRIPTION")
                Dim jobdesc As DataColumn = New DataColumn("JOB_DESC")
                Dim jobcompdesc As DataColumn = New DataColumn("JOB_COMP_DESC")
                Dim tasknontaskdisplay As DataColumn = New DataColumn("TASK_NON_TASK_DISPLAY")
                Dim tasknontaskdesc As DataColumn = New DataColumn("TASK_NON_TASK_DESCRIPTION")
                Dim taskstatus As DataColumn = New DataColumn("TASK_STATUS")
                Dim taskseqnbr As DataColumn = New DataColumn("TASK_SEQ_NBR")
                Dim fncode As DataColumn = New DataColumn("FNC_CODE")
                Dim taskdesc As DataColumn = New DataColumn("TASK_DESCRIPTION")
                Dim taskhours As DataColumn = New DataColumn("TASK_HOURS_ALLOWED")
                Dim trfcode As DataColumn = New DataColumn("TRF_CODE")
                Dim trfdesc As DataColumn = New DataColumn("TRF_DESCRIPTION")
                Dim thisday As DataColumn = New DataColumn("THIS_DAY")
                Dim startday As DataColumn = New DataColumn("START_DAY")
                Dim endday As DataColumn = New DataColumn("END_DAY")
                Dim allday As DataColumn = New DataColumn("ALL_DAY")
                Dim numdays As DataColumn = New DataColumn("NUM_DAYS")
                Dim tasktemp As DataColumn = New DataColumn("TASK_TEMP_COMPLETE_DATE")
                Dim sdate As DataColumn = New DataColumn("START_DATE")
                Dim edate As DataColumn = New DataColumn("END_DATE")
                Dim stime As DataColumn = New DataColumn("START_TIME")
                Dim etime As DataColumn = New DataColumn("END_TIME")
                Dim weekviewendtime As DataColumn = New DataColumn("WEEK_VIEW_END_TIME")
                Dim hastime As DataColumn = New DataColumn("HAS_TIME")
                Dim nontaskid As DataColumn = New DataColumn("NON_TASK_ID")
                Dim nontasktype As DataColumn = New DataColumn("NON_TASK_TYPE")
                Dim nontaskhours As DataColumn = New DataColumn("NON_TASK_HOURS")
                Dim nontaskcat As DataColumn = New DataColumn("NON_TASK_CATEGORY")
                Dim isnontask As DataColumn = New DataColumn("IS_NON_TASK")
                Dim weekview As DataColumn = New DataColumn("WEEK_VIEW_ALL_DAY")
                Dim rectype As DataColumn = New DataColumn("REC_TYPE")
                Dim recorder As DataColumn = New DataColumn("REC_ORDER")
                Dim icalid As DataColumn = New DataColumn("ICAL_ID")
                Dim adnbr As DataColumn = New DataColumn("AD_NBR")
                Dim adnbrdesc As DataColumn = New DataColumn("AD_NBR_DESC")
                Dim adnbrcolor As DataColumn = New DataColumn("AD_NBR_COLOR")
                Dim resourcecode As DataColumn = New DataColumn("RESOURCE_CODE")
                Dim resourcedesc As DataColumn = New DataColumn("RESOURCE_DESC")
                Dim priority As DataColumn = New DataColumn("PRIORITY")
                Dim dk As DataColumn = New DataColumn("DATA_KEY")
                Dim jobandcomp As DataColumn = New DataColumn("JOB_AND_COMP")
                Dim taskanddescript As DataColumn = New DataColumn("TASK_AND_DESCRIPT")
                Dim trfanddescript As DataColumn = New DataColumn("TRF_AND_DESCRIPT")
                Dim empcodename As DataColumn = New DataColumn("EMP_CODE_NAME")
                Dim alldayyn As DataColumn = New DataColumn("ALL_DAY_YN")
                Dim adnbranddescript As DataColumn = New DataColumn("AD_NBR_AND_DESCRIPT")
                Dim resourceanddescript As DataColumn = New DataColumn("RESOURCE_AND_DESCRIPT")
                Dim eventanddescript As DataColumn = New DataColumn("EVENT_AND_DESCRIPT")
                Dim customsort As DataColumn = New DataColumn("CUSTOM_SORT")
                Dim empcodehours As DataColumn = New DataColumn("EMP_CODE_HOURS")
                Dim empnamehours As DataColumn = New DataColumn("EMP_NAME_HOURS")
                Dim duetime As DataColumn = New DataColumn("DUE_TIME")
                Dim remind As DataColumn = New DataColumn("REMINDER")
                Dim recurrence As DataColumn = New DataColumn("RECURRENCE")
                Dim recurrenceparent As DataColumn = New DataColumn("RECURRENCE_PARENT")
                Dim cdpcontactid As DataColumn = New DataColumn("CDP_CONTACT_ID")
                Dim contcode As DataColumn = New DataColumn("CONT_CODE")
                Dim contfml As DataColumn = New DataColumn("CONT_FML")

                DtMV.Columns.Add(id)
                DtMV.Columns.Add(empcode)
                DtMV.Columns.Add(empfname)
                DtMV.Columns.Add(empmi)
                DtMV.Columns.Add(emplname)
                DtMV.Columns.Add(empfmlname)
                DtMV.Columns.Add(empcodefmlname)
                DtMV.Columns.Add(clcode)
                DtMV.Columns.Add(divcode)
                DtMV.Columns.Add(prdcode)
                DtMV.Columns.Add(job)
                DtMV.Columns.Add(comp)
                DtMV.Columns.Add(clname)
                DtMV.Columns.Add(divname)
                DtMV.Columns.Add(prddesc)
                DtMV.Columns.Add(jobdesc)
                DtMV.Columns.Add(jobcompdesc)
                DtMV.Columns.Add(tasknontaskdisplay)
                DtMV.Columns.Add(tasknontaskdesc)
                DtMV.Columns.Add(taskstatus)
                DtMV.Columns.Add(taskseqnbr)
                DtMV.Columns.Add(fncode)
                DtMV.Columns.Add(taskdesc)
                DtMV.Columns.Add(taskhours)
                DtMV.Columns.Add(trfcode)
                DtMV.Columns.Add(trfdesc)
                DtMV.Columns.Add(thisday)
                DtMV.Columns.Add(startday)
                DtMV.Columns.Add(endday)
                DtMV.Columns.Add(allday)
                DtMV.Columns.Add(numdays)
                DtMV.Columns.Add(tasktemp)
                DtMV.Columns.Add(sdate)
                DtMV.Columns.Add(edate)
                DtMV.Columns.Add(stime)
                DtMV.Columns.Add(etime)
                DtMV.Columns.Add(weekviewendtime)
                DtMV.Columns.Add(hastime)
                DtMV.Columns.Add(nontaskid)
                DtMV.Columns.Add(nontasktype)
                DtMV.Columns.Add(nontaskhours)
                DtMV.Columns.Add(nontaskcat)
                DtMV.Columns.Add(isnontask)
                DtMV.Columns.Add(weekview)
                DtMV.Columns.Add(rectype)
                DtMV.Columns.Add(recorder)
                DtMV.Columns.Add(icalid)
                DtMV.Columns.Add(adnbr)
                DtMV.Columns.Add(adnbrdesc)
                DtMV.Columns.Add(adnbrcolor)
                DtMV.Columns.Add(resourcecode)
                DtMV.Columns.Add(resourcedesc)
                DtMV.Columns.Add(priority)
                DtMV.Columns.Add(dk)
                DtMV.Columns.Add(jobandcomp)
                DtMV.Columns.Add(taskanddescript)
                DtMV.Columns.Add(trfanddescript)
                DtMV.Columns.Add(empcodename)
                DtMV.Columns.Add(alldayyn)
                DtMV.Columns.Add(adnbranddescript)
                DtMV.Columns.Add(resourceanddescript)
                DtMV.Columns.Add(eventanddescript)
                DtMV.Columns.Add(customsort)
                DtMV.Columns.Add(empcodehours)
                DtMV.Columns.Add(empnamehours)
                DtMV.Columns.Add(duetime)
                DtMV.Columns.Add(remind)
                DtMV.Columns.Add(recurrence)
                DtMV.Columns.Add(recurrenceparent)
                DtMV.Columns.Add(cdpcontactid)
                DtMV.Columns.Add(contcode)
                DtMV.Columns.Add(contfml)

                If JCs.Length > 0 Then
                    For i As Integer = 0 To JCs.Length - 1
                        Dim strJC() As String = JCs(i).Split(",")
                        If strJC(0) <> "" Then
                            Dt = c.GetCalendarData(dtThisDate.Month,
                                     dtThisDate.Year,
                                     CStr(Session("UserCode")),
                                     CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                     "0",
                                     oAppVars.getAppVar("tcal_emp"),
                                     oAppVars.getAppVar("tcal_office"),
                                     strJC(2),
                                     strJC(3),
                                     strJC(4),
                                     strJC(0),
                                     strJC(1),
                                     oAppVars.getAppVar("tcal_roles"),
                                     CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                     oAppVars.getAppVar("tcal_taskstatus"),
                                     CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                     oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                     oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))

                            CreateDT(DtMV, Dt)

                        End If

                    Next
                End If

            Else
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         oAppVars.getAppVar("tcal_jobno"),
                                         oAppVars.getAppVar("tcal_jobcomp"),
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))
            End If

            'Session("MonthView") = Dt
            If Request.QueryString("FromApp") = "PSMV" Then
                DayPilotMonthExport.DataSource = DtMV
            Else
                DayPilotMonthExport.DataSource = Dt
            End If
            DayPilotMonthExport.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function LoadCalendarDT()
        Try
            Dim intDaysInMonth As Integer
            Dim dtFirst As Date
            Dim dtLast As Date
            Dim strEmpCode As String = ""
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
            Dim JCs() As String
            If Not Session("TaskCalendarSelectedDate") Is Nothing Then
                dtThisDate = CType(Session("TaskCalendarSelectedDate"), Date)
            Else
                dtThisDate = Today.Date
            End If
            ViewState("ThisDate") = dtThisDate

            ' Set Up for navigation links
            intDaysInMonth = dtThisDate.DaysInMonth(dtThisDate.Year, dtThisDate.Month)
            dtFirst = LoGlo.FirstOfMonth(dtThisDate)
            dtLast = LoGlo.LastOfMonth(dtThisDate)

            DayPilotMonthExport.StartDate = dtFirst
            oAppVars.getAllAppVars()

            Dim Dt As New DataTable
            Dim DtMV As New DataTable
            Dim c As New cDayPilot()

            If Request.QueryString("FromApp") = "PS" Then
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         JobNum.ToString,
                                         JobCompNum.ToString,
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))
            ElseIf Request.QueryString("FromApp") = "PSMV" Then
                If Not Session("TrafficScheduleMVJobs") Is Nothing Then
                    If Session("TrafficScheduleMVJobs") <> "" Then
                        JCs = Session("TrafficScheduleMVJobs").ToString.Split("|")
                    End If
                End If

                DtMV = New DataTable("calItems")
                Dim id As DataColumn = New DataColumn("ID")
                Dim empcode As DataColumn = New DataColumn("EMP_CODE")
                Dim empfname As DataColumn = New DataColumn("EMP_FNAME")
                Dim empmi As DataColumn = New DataColumn("EMP_MI")
                Dim emplname As DataColumn = New DataColumn("EMP_LNAME")
                Dim empfmlname As DataColumn = New DataColumn("EMP_FML_NAME")
                Dim empcodefmlname As DataColumn = New DataColumn("EMP_CODE_FML_NAME")
                Dim clcode As DataColumn = New DataColumn("CL_CODE")
                Dim divcode As DataColumn = New DataColumn("DIV_CODE")
                Dim prdcode As DataColumn = New DataColumn("PRD_CODE")
                Dim job As DataColumn = New DataColumn("JOB_NUMBER")
                Dim comp As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
                Dim clname As DataColumn = New DataColumn("CL_NAME")
                Dim divname As DataColumn = New DataColumn("DIV_NAME")
                Dim prddesc As DataColumn = New DataColumn("PRD_DESCRIPTION")
                Dim jobdesc As DataColumn = New DataColumn("JOB_DESC")
                Dim jobcompdesc As DataColumn = New DataColumn("JOB_COMP_DESC")
                Dim tasknontaskdisplay As DataColumn = New DataColumn("TASK_NON_TASK_DISPLAY")
                Dim tasknontaskdesc As DataColumn = New DataColumn("TASK_NON_TASK_DESCRIPTION")
                Dim taskstatus As DataColumn = New DataColumn("TASK_STATUS")
                Dim taskseqnbr As DataColumn = New DataColumn("TASK_SEQ_NBR")
                Dim fncode As DataColumn = New DataColumn("FNC_CODE")
                Dim taskdesc As DataColumn = New DataColumn("TASK_DESCRIPTION")
                Dim taskhours As DataColumn = New DataColumn("TASK_HOURS_ALLOWED")
                Dim trfcode As DataColumn = New DataColumn("TRF_CODE")
                Dim trfdesc As DataColumn = New DataColumn("TRF_DESCRIPTION")
                Dim thisday As DataColumn = New DataColumn("THIS_DAY")
                Dim startday As DataColumn = New DataColumn("START_DAY")
                Dim endday As DataColumn = New DataColumn("END_DAY")
                Dim allday As DataColumn = New DataColumn("ALL_DAY")
                Dim numdays As DataColumn = New DataColumn("NUM_DAYS")
                Dim tasktemp As DataColumn = New DataColumn("TASK_TEMP_COMPLETE_DATE")
                Dim sdate As DataColumn = New DataColumn("START_DATE")
                Dim edate As DataColumn = New DataColumn("END_DATE")
                Dim stime As DataColumn = New DataColumn("START_TIME")
                Dim etime As DataColumn = New DataColumn("END_TIME")
                Dim weekviewendtime As DataColumn = New DataColumn("WEEK_VIEW_END_TIME")
                Dim hastime As DataColumn = New DataColumn("HAS_TIME")
                Dim nontaskid As DataColumn = New DataColumn("NON_TASK_ID")
                Dim nontasktype As DataColumn = New DataColumn("NON_TASK_TYPE")
                Dim nontaskhours As DataColumn = New DataColumn("NON_TASK_HOURS")
                Dim nontaskcat As DataColumn = New DataColumn("NON_TASK_CATEGORY")
                Dim isnontask As DataColumn = New DataColumn("IS_NON_TASK")
                Dim weekview As DataColumn = New DataColumn("WEEK_VIEW_ALL_DAY")
                Dim rectype As DataColumn = New DataColumn("REC_TYPE")
                Dim recorder As DataColumn = New DataColumn("REC_ORDER")
                Dim icalid As DataColumn = New DataColumn("ICAL_ID")
                Dim adnbr As DataColumn = New DataColumn("AD_NBR")
                Dim adnbrdesc As DataColumn = New DataColumn("AD_NBR_DESC")
                Dim adnbrcolor As DataColumn = New DataColumn("AD_NBR_COLOR")
                Dim resourcecode As DataColumn = New DataColumn("RESOURCE_CODE")
                Dim resourcedesc As DataColumn = New DataColumn("RESOURCE_DESC")
                Dim priority As DataColumn = New DataColumn("PRIORITY")
                Dim dk As DataColumn = New DataColumn("DATA_KEY")
                Dim jobandcomp As DataColumn = New DataColumn("JOB_AND_COMP")
                Dim taskanddescript As DataColumn = New DataColumn("TASK_AND_DESCRIPT")
                Dim trfanddescript As DataColumn = New DataColumn("TRF_AND_DESCRIPT")
                Dim empcodename As DataColumn = New DataColumn("EMP_CODE_NAME")
                Dim alldayyn As DataColumn = New DataColumn("ALL_DAY_YN")
                Dim adnbranddescript As DataColumn = New DataColumn("AD_NBR_AND_DESCRIPT")
                Dim resourceanddescript As DataColumn = New DataColumn("RESOURCE_AND_DESCRIPT")
                Dim eventanddescript As DataColumn = New DataColumn("EVENT_AND_DESCRIPT")
                Dim customsort As DataColumn = New DataColumn("CUSTOM_SORT")
                Dim empcodehours As DataColumn = New DataColumn("EMP_CODE_HOURS")
                Dim empnamehours As DataColumn = New DataColumn("EMP_NAME_HOURS")
                Dim duetime As DataColumn = New DataColumn("DUE_TIME")
                Dim remind As DataColumn = New DataColumn("REMINDER")
                Dim recurrence As DataColumn = New DataColumn("RECURRENCE")
                Dim recurrenceparent As DataColumn = New DataColumn("RECURRENCE_PARENT")
                Dim cdpcontactid As DataColumn = New DataColumn("CDP_CONTACT_ID")
                Dim contcode As DataColumn = New DataColumn("CONT_CODE")
                Dim contfml As DataColumn = New DataColumn("CONT_FML")

                DtMV.Columns.Add(id)
                DtMV.Columns.Add(empcode)
                DtMV.Columns.Add(empfname)
                DtMV.Columns.Add(empmi)
                DtMV.Columns.Add(emplname)
                DtMV.Columns.Add(empfmlname)
                DtMV.Columns.Add(empcodefmlname)
                DtMV.Columns.Add(clcode)
                DtMV.Columns.Add(divcode)
                DtMV.Columns.Add(prdcode)
                DtMV.Columns.Add(job)
                DtMV.Columns.Add(comp)
                DtMV.Columns.Add(clname)
                DtMV.Columns.Add(divname)
                DtMV.Columns.Add(prddesc)
                DtMV.Columns.Add(jobdesc)
                DtMV.Columns.Add(jobcompdesc)
                DtMV.Columns.Add(tasknontaskdisplay)
                DtMV.Columns.Add(tasknontaskdesc)
                DtMV.Columns.Add(taskstatus)
                DtMV.Columns.Add(taskseqnbr)
                DtMV.Columns.Add(fncode)
                DtMV.Columns.Add(taskdesc)
                DtMV.Columns.Add(taskhours)
                DtMV.Columns.Add(trfcode)
                DtMV.Columns.Add(trfdesc)
                DtMV.Columns.Add(thisday)
                DtMV.Columns.Add(startday)
                DtMV.Columns.Add(endday)
                DtMV.Columns.Add(allday)
                DtMV.Columns.Add(numdays)
                DtMV.Columns.Add(tasktemp)
                DtMV.Columns.Add(sdate)
                DtMV.Columns.Add(edate)
                DtMV.Columns.Add(stime)
                DtMV.Columns.Add(etime)
                DtMV.Columns.Add(weekviewendtime)
                DtMV.Columns.Add(hastime)
                DtMV.Columns.Add(nontaskid)
                DtMV.Columns.Add(nontasktype)
                DtMV.Columns.Add(nontaskhours)
                DtMV.Columns.Add(nontaskcat)
                DtMV.Columns.Add(isnontask)
                DtMV.Columns.Add(weekview)
                DtMV.Columns.Add(rectype)
                DtMV.Columns.Add(recorder)
                DtMV.Columns.Add(icalid)
                DtMV.Columns.Add(adnbr)
                DtMV.Columns.Add(adnbrdesc)
                DtMV.Columns.Add(adnbrcolor)
                DtMV.Columns.Add(resourcecode)
                DtMV.Columns.Add(resourcedesc)
                DtMV.Columns.Add(priority)
                DtMV.Columns.Add(dk)
                DtMV.Columns.Add(jobandcomp)
                DtMV.Columns.Add(taskanddescript)
                DtMV.Columns.Add(trfanddescript)
                DtMV.Columns.Add(empcodename)
                DtMV.Columns.Add(alldayyn)
                DtMV.Columns.Add(adnbranddescript)
                DtMV.Columns.Add(resourceanddescript)
                DtMV.Columns.Add(eventanddescript)
                DtMV.Columns.Add(customsort)
                DtMV.Columns.Add(empcodehours)
                DtMV.Columns.Add(empnamehours)
                DtMV.Columns.Add(duetime)
                DtMV.Columns.Add(remind)
                DtMV.Columns.Add(recurrence)
                DtMV.Columns.Add(recurrenceparent)
                DtMV.Columns.Add(cdpcontactid)
                DtMV.Columns.Add(contcode)
                DtMV.Columns.Add(contfml)

                If JCs.Length > 0 Then
                    For i As Integer = 0 To JCs.Length - 1
                        Dim strJC() As String = JCs(i).Split(",")
                        If strJC(0) <> "" Then
                            Dt = c.GetCalendarData(dtThisDate.Month,
                                     dtThisDate.Year,
                                     CStr(Session("UserCode")),
                                     CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                     "0",
                                     oAppVars.getAppVar("tcal_emp"),
                                     oAppVars.getAppVar("tcal_office"),
                                     strJC(2),
                                     strJC(3),
                                     strJC(4),
                                     strJC(0),
                                     strJC(1),
                                     oAppVars.getAppVar("tcal_roles"),
                                     CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                     oAppVars.getAppVar("tcal_taskstatus"),
                                     CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                     CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                     oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                     oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))

                            CreateDT(DtMV, Dt)

                        End If

                    Next
                End If

            Else
                Dt = c.GetCalendarData(dtThisDate.Month,
                                         dtThisDate.Year,
                                         CStr(Session("UserCode")),
                                         CType(oAppVars.getAppVar("show_client", "Boolean"), Boolean),
                                         "0",
                                         oAppVars.getAppVar("tcal_emp"),
                                         oAppVars.getAppVar("tcal_office"),
                                         oAppVars.getAppVar("tcal_client"),
                                         oAppVars.getAppVar("tcal_div"),
                                         oAppVars.getAppVar("tcal_prod"),
                                         oAppVars.getAppVar("tcal_jobno"),
                                         oAppVars.getAppVar("tcal_jobcomp"),
                                         oAppVars.getAppVar("tcal_roles"),
                                         CInt(oAppVars.getAppVar("tcal_len", "Number")),
                                         oAppVars.getAppVar("tcal_taskstatus"),
                                         CType(oAppVars.getAppVar("tcal_excludetempcomplete", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_duration", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showtasks", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showassignments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showholidays", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_showappointments", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_milestone", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean),
                                         CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean),
                                         oAppVars.getAppVar("tcal_manager"), Nothing, Nothing, CType(oAppVars.getAppVar("tcal_showevent", "Boolean"), Boolean), CType(oAppVars.getAppVar("tcal_showeventtasks", "Boolean"), Boolean), oAppVars.getAppVar("tcal_departs"),
                                         oAppVars.getAppVar("tcal_trafficstatuscode"), Me.IsClientPortal, Session("UserID"), oAppVars.getAppVar("tcal_roles_func"))
            End If

            If Request.QueryString("FromApp") = "PSMV" Then
                Return DtMV
            Else
                Return Dt
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function CreateDT(ByRef dtMV As DataTable, ByVal dt As DataTable)
        Try
            Dim row As DataRow
            Dim add As Boolean = False
            For w As Integer = 0 To dt.Rows.Count - 1
                row = dtMV.NewRow
                row.Item("ID") = dt.Rows(w)("ID")
                row.Item("EMP_CODE") = dt.Rows(w)("EMP_CODE")
                row.Item("EMP_FNAME") = dt.Rows(w)("EMP_FNAME")
                row.Item("EMP_MI") = dt.Rows(w)("EMP_MI")
                row.Item("EMP_LNAME") = dt.Rows(w)("EMP_LNAME")
                row.Item("EMP_FML_NAME") = dt.Rows(w)("EMP_FML_NAME")
                row.Item("EMP_CODE_FML_NAME") = dt.Rows(w)("EMP_FML_NAME")
                row.Item("CL_CODE") = dt.Rows(w)("CL_CODE")
                row.Item("DIV_CODE") = dt.Rows(w)("DIV_CODE")
                row.Item("PRD_CODE") = dt.Rows(w)("PRD_CODE")
                row.Item("JOB_NUMBER") = dt.Rows(w)("JOB_NUMBER")
                row.Item("JOB_COMPONENT_NBR") = dt.Rows(w)("JOB_COMPONENT_NBR")
                row.Item("CL_NAME") = dt.Rows(w)("CL_NAME")
                row.Item("DIV_NAME") = dt.Rows(w)("DIV_NAME")
                row.Item("PRD_DESCRIPTION") = dt.Rows(w)("PRD_DESCRIPTION")
                row.Item("JOB_DESC") = dt.Rows(w)("JOB_DESC")
                row.Item("JOB_COMP_DESC") = dt.Rows(w)("JOB_COMP_DESC")
                row.Item("TASK_NON_TASK_DISPLAY") = dt.Rows(w)("TASK_NON_TASK_DISPLAY")
                row.Item("TASK_NON_TASK_DESCRIPTION") = dt.Rows(w)("TASK_NON_TASK_DESCRIPTION")
                row.Item("TASK_STATUS") = dt.Rows(w)("TASK_STATUS")
                row.Item("TASK_SEQ_NBR") = dt.Rows(w)("TASK_SEQ_NBR")
                row.Item("FNC_CODE") = dt.Rows(w)("FNC_CODE")
                row.Item("TASK_DESCRIPTION") = dt.Rows(w)("TASK_DESCRIPTION")
                row.Item("TASK_HOURS_ALLOWED") = dt.Rows(w)("TASK_HOURS_ALLOWED")
                row.Item("TRF_CODE") = dt.Rows(w)("TRF_CODE")
                row.Item("TRF_DESCRIPTION") = dt.Rows(w)("TRF_DESCRIPTION")
                row.Item("THIS_DAY") = dt.Rows(w)("THIS_DAY")
                row.Item("START_DAY") = dt.Rows(w)("START_DAY")
                row.Item("END_DAY") = dt.Rows(w)("END_DAY")
                row.Item("ALL_DAY") = dt.Rows(w)("ALL_DAY")
                row.Item("NUM_DAYS") = dt.Rows(w)("NUM_DAYS")
                row.Item("TASK_TEMP_COMPLETE_DATE") = dt.Rows(w)("TASK_TEMP_COMPLETE_DATE")
                row.Item("START_DATE") = dt.Rows(w)("START_DATE")
                row.Item("END_DATE") = dt.Rows(w)("END_DATE")
                row.Item("START_TIME") = dt.Rows(w)("START_TIME")
                row.Item("END_TIME") = dt.Rows(w)("END_TIME")
                row.Item("WEEK_VIEW_END_TIME") = dt.Rows(w)("WEEK_VIEW_END_TIME")
                row.Item("HAS_TIME") = dt.Rows(w)("HAS_TIME")
                row.Item("NON_TASK_ID") = dt.Rows(w)("NON_TASK_ID")
                row.Item("NON_TASK_TYPE") = dt.Rows(w)("NON_TASK_TYPE")
                row.Item("NON_TASK_HOURS") = dt.Rows(w)("NON_TASK_HOURS")
                row.Item("NON_TASK_CATEGORY") = dt.Rows(w)("NON_TASK_CATEGORY")
                row.Item("IS_NON_TASK") = dt.Rows(w)("IS_NON_TASK")
                row.Item("WEEK_VIEW_ALL_DAY") = dt.Rows(w)("WEEK_VIEW_ALL_DAY")
                row.Item("REC_TYPE") = dt.Rows(w)("REC_TYPE")
                row.Item("REC_ORDER") = dt.Rows(w)("REC_ORDER")
                row.Item("ICAL_ID") = dt.Rows(w)("ICAL_ID")
                row.Item("AD_NBR") = dt.Rows(w)("AD_NBR")
                row.Item("AD_NBR_DESC") = dt.Rows(w)("AD_NBR_DESC")
                row.Item("AD_NBR_COLOR") = dt.Rows(w)("AD_NBR_COLOR")
                row.Item("RESOURCE_CODE") = dt.Rows(w)("RESOURCE_CODE")
                row.Item("RESOURCE_DESC") = dt.Rows(w)("RESOURCE_DESC")
                row.Item("PRIORITY") = dt.Rows(w)("PRIORITY")
                row.Item("DATA_KEY") = dt.Rows(w)("DATA_KEY")
                row.Item("JOB_AND_COMP") = dt.Rows(w)("JOB_AND_COMP")
                row.Item("TASK_AND_DESCRIPT") = dt.Rows(w)("TASK_AND_DESCRIPT")
                row.Item("TRF_AND_DESCRIPT") = dt.Rows(w)("TRF_AND_DESCRIPT")
                row.Item("EMP_CODE_NAME") = dt.Rows(w)("EMP_CODE_NAME")
                row.Item("ALL_DAY_YN") = dt.Rows(w)("ALL_DAY_YN")
                row.Item("AD_NBR_AND_DESCRIPT") = dt.Rows(w)("AD_NBR_AND_DESCRIPT")
                row.Item("RESOURCE_AND_DESCRIPT") = dt.Rows(w)("RESOURCE_AND_DESCRIPT")
                row.Item("EVENT_AND_DESCRIPT") = dt.Rows(w)("EVENT_AND_DESCRIPT")
                row.Item("CUSTOM_SORT") = dt.Rows(w)("CUSTOM_SORT")
                row.Item("EMP_CODE_HOURS") = dt.Rows(w)("EMP_CODE_HOURS")
                row.Item("EMP_NAME_HOURS") = dt.Rows(w)("EMP_NAME_HOURS")
                row.Item("DUE_TIME") = dt.Rows(w)("DUE_TIME")
                row.Item("REMINDER") = dt.Rows(w)("REMINDER")
                row.Item("RECURRENCE") = dt.Rows(w)("RECURRENCE")
                row.Item("RECURRENCE_PARENT") = dt.Rows(w)("RECURRENCE_PARENT")
                row.Item("CDP_CONTACT_ID") = dt.Rows(w)("CDP_CONTACT_ID")
                row.Item("CONT_CODE") = dt.Rows(w)("CONT_CODE")
                row.Item("CONT_FML") = dt.Rows(w)("CONT_FML")

                If dtMV.Rows.Count > 0 Then
                    For k As Integer = 0 To dtMV.Rows.Count - 1
                        Dim num1 As String = dtMV.Rows(k)("NON_TASK_ID").ToString
                        Dim num2 As String = dt.Rows(w)("NON_TASK_ID").ToString
                        If dt.Rows(w)("NON_TASK_ID").ToString <> "-1" Then
                            If dtMV.Rows(k)("NON_TASK_ID").ToString <> dt.Rows(w)("NON_TASK_ID").ToString Then
                                add = True
                            End If
                        Else
                            add = True
                        End If
                    Next
                    If add = True Then
                        dtMV.Rows.Add(row)
                    End If
                Else
                    dtMV.Rows.Add(row)
                End If

            Next



        Catch ex As Exception

        End Try
    End Function


#Region " Day Pilot"

    Protected Sub DayPilotCalendar1_EventMenuClick(ByVal sender As Object, ByVal e As EventMenuClickEventArgs)

    End Sub

    Protected Sub DayPilotMonth1_EventMove(ByVal sender As Object, ByVal e As EventMoveEventArgs)
        Dim NewStart As DateTime = e.NewStart ' Convert.ToDateTime(e.NewStart.ToShortDateString() & " 12:00:00 AM")
        Dim NewEnd As DateTime = Convert.ToDateTime(e.NewEnd.ToShortDateString() & " 12:00:00 AM")

        Dim ar() As String
        ar = e.Value.Split("|")

        Dim IsNonTask As Integer = 0
        Dim NonTaskType As String = ""
        Dim IsAllDay As Integer = 0
        Dim TaskStatus As String = ""

        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = 0
        Dim NonTaskId As Integer = 0
        Dim EmpCode As String = ""

        IsNonTask = CType(ar(1), Integer)
        NonTaskType = ar(2).ToString().Trim()
        IsAllDay = CType(ar(3), Integer)
        TaskStatus = ar(4).ToString().Trim()

        JobNumber = CType(ar(5), Integer)
        JobComponentNbr = CType(ar(6), Integer)
        SeqNbr = CType(ar(7), Integer)
        NonTaskId = CType(ar(8), Integer)
        EmpCode = ar(9).ToString().Trim()

        Dim d As New cDayPilot
        If IsNonTask = 0 Then 'a real task
            Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))

            If access = 1 Then
                'd.Task_UpdateDates(JobNumber, JobComponentNbr, SeqNbr, NewStart, NewEnd, Session("UserCode"))
            Else
                Me.ShowMessage("You do not have permission to edit tasks")

            End If
        ElseIf IsNonTask = 1 Then 'a holiday or appointment
            Dim m As String = ""
            m = d.NonTask_UpdateDates(NonTaskId, NewStart, NewEnd, False)
            If m <> "" Then
                Me.ShowMessage(m)
            End If
        ElseIf IsNonTask = 2 Then 'an event
            Dim Original_Start As DateTime = e.OldStart
            Dim Original_End As DateTime = e.OldEnd
            Dim New_Start As DateTime = e.NewStart
            Dim New_End As DateTime = e.NewEnd
            Dim EventId As Integer = NonTaskId
            Dim m As String = ""
            m = d.Event_UpdateDates(EventId, New_Start, New_End, False, Session("UserCode"))
            If m <> "" Then
                Me.ShowMessage(m)
            End If
        ElseIf IsNonTask = 3 Then 'an event task
            Dim Original_Start As DateTime = e.OldStart
            Dim Original_End As DateTime = e.OldEnd
            Dim New_Start As DateTime = e.NewStart
            Dim New_End As DateTime = e.NewEnd
            Dim EventTaskId As Integer = NonTaskId
            Dim m As String = ""
            m = d.EventTask_UpdateDates(EventTaskId, New_Start, New_End, False, Session("UserCode"))
            If m <> "" Then
                Me.ShowMessage(m)
            End If
        End If

        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
            MiscFN.ResponseRedirect("Calendar_MonthView.aspx?tab=0")
        Else
            Me.LoadCalendar()
        End If

    End Sub

    ''Array positions for key:
    ' 0 = Internal row id
    ' 1 = Is non task
    ' 2 = non task type
    ' 3 = is all day
    ' 4 = task status, N = normal status
    ' 5 = job number
    ' 6 = job component number
    ' 7 = sequence number
    ' 8 = non-task id/event id
    ' 9 = emp code

    Protected Sub DayPilotMonth1_EventResize(ByVal sender As Object, ByVal e As EventResizeEventArgs)
        Dim NewStart As DateTime = e.NewStart ' Convert.ToDateTime(e.NewStart.ToShortDateString() & " 12:00:00 AM")
        Dim NewEnd As DateTime = Convert.ToDateTime(e.NewEnd.ToShortDateString() & " 12:00:00 AM")
        Dim TempDate As DateTime

        'Dim test As Long = DateDiff(DateInterval.Day, NewStart, NewEnd)
        'If DateDiff(DateInterval.Day, NewStart, NewEnd) < 1 Then
        '    'need to flip?
        '    TempDate = NewStart
        'End If

        Dim ar() As String
        ar = e.Value.Split("|")

        Dim IsNonTask As Integer = 0
        Dim NonTaskType As String = ""
        Dim IsAllDay As Integer = 0
        Dim TaskStatus As String = ""

        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = 0
        Dim NonTaskId As Integer = 0
        Dim EmpCode As String = ""

        IsNonTask = CType(ar(1), Integer)
        NonTaskType = ar(2).ToString().Trim()
        IsAllDay = CType(ar(3), Integer)
        TaskStatus = ar(4).ToString().Trim()

        JobNumber = CType(ar(5), Integer)
        JobComponentNbr = CType(ar(6), Integer)
        SeqNbr = CType(ar(7), Integer)
        NonTaskId = CType(ar(8), Integer)
        EmpCode = ar(9).ToString().Trim()

        Dim d As New cDayPilot
        If IsNonTask = 0 Then 'its a real task
            Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
            If access = 1 Then
                'd.Task_UpdateDates(JobNumber, JobComponentNbr, SeqNbr, NewStart, NewEnd, Session("UserCode"))
            Else
                Me.ShowMessage("You do not have permission to edit tasks")
            End If
        ElseIf IsNonTask = 1 Then
            Dim m As String = ""
            m = d.NonTask_UpdateDates(NonTaskId, NewStart, NewEnd, False)
            If m <> "" Then
                Me.ShowMessage(m)
            End If
        ElseIf IsNonTask = 2 Then 'an event
            'Dim Original_Start As DateTime = e.OldStart
            'Dim Original_End As DateTime = e.OldEnd
            'Dim New_Start As DateTime = e.NewStart
            'Dim New_End As DateTime = e.NewEnd
            'Dim EventId As Integer = NonTaskId
            'Dim m As String = ""
            'm = d.Event_UpdateDates(EventId, New_Start, New_End, False, Session("UserCode"))
            'If m <> "" Then
            '    Me.ScriptManager1.RegisterStartupScript(Me.Page, Me.GetType(), "quickAlert", "alert('" & m & "');", True)
            'End If
        ElseIf IsNonTask = 3 Then 'an event task
            'Dim Original_Start As DateTime = e.OldStart
            'Dim Original_End As DateTime = e.OldEnd
            'Dim New_Start As DateTime = e.NewStart
            'Dim New_End As DateTime = e.NewEnd
            'Dim EventTaskId As Integer = NonTaskId
            'Dim m As String = ""
            'm = d.EventTask_UpdateDates(EventTaskId, New_Start, New_End, False, Session("UserCode"))
            'If m <> "" Then
            '    Me.ScriptManager1.RegisterStartupScript(Me.Page, Me.GetType(), "quickAlert", "alert('" & m & "');", True)
            'End If
        End If

        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
            MiscFN.ResponseRedirect("Calendar_MonthView.aspx?tab=0")
        Else
            Me.LoadCalendar()
        End If


    End Sub

    'Set the day number style.
    Protected Sub DayPilotMonth1_BeforeCellRender(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.Month.BeforeCellRenderEventArgs)
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

        If DayPilotMonthExport.IsExport = False Then

            If e.Start = DateTime.Today Then 'only for today
                Dim HeaderBold As String = ""
                If Me.HfTodayHeaderBold.Value = "True" Then
                    HeaderBold = "style=""font-weight:bold#"""
                End If
                If Me.HfTodayForeColor.Value <> "" Then
                    HeaderBold = HeaderBold.Replace("#", ";color:" & Me.HfTodayForeColor.Value)
                Else
                    HeaderBold = HeaderBold.Replace("#", "")
                End If
                e.HeaderText = String.Format("<span {1} >{0}</span>", e.Start.Day, HeaderBold)
                If Me.HfTodayBackColor.Value <> "" Then
                    e.HeaderBackColor = Me.HfTodayBackColor.Value
                End If
            End If

            'bold selected date
            If Me.HfBoldSelectedDate.Value = "True" Then
                Try
                    If e.Start = CType(Session("TaskCalendarSelectedDate"), Date) And e.Start <> DateTime.Today Then
                        'If e.Start = CType(oAppVars.getAppVarDB("TaskCalendarSelectedDate", "Date"), Date) And e.Start <> DateTime.Today Then
                        e.HeaderText = String.Format("<strong>{0}</strong>", e.Start.Day)
                    End If
                Catch ex As Exception
                End Try
            End If
            'image next to selected date
            Dim StrSelectedDateImage As String = ""
            If Me.HfShowSelectedDateImage.Value = "True" And e.Start = CType(Session("TaskCalendarSelectedDate"), Date) Then
                'If Me.HfShowSelectedDateImage.Value = "True" And e.Start = CType(oAppVars.getAppVar("TaskCalendarSelectedDate", "Date"), Date) Then

                StrSelectedDateImage = "<img border=""0"" height=""12"" src=""Images/square_red.png"" width=""12"" valign=""absmiddle"" alt=""Currently selected date"" />"

                e.HeaderText = StrSelectedDateImage & e.HeaderText

            End If

        Else

            If Me.HfTodayBackColor.Value <> "" Then

                e.HeaderBackColor = Me.HfTodayBackColor.Value

            End If

        End If

        If Me.HfWeekendBackColor.Value <> "" Then
            If e.Start.DayOfWeek = DayOfWeek.Saturday Or e.Start.DayOfWeek = DayOfWeek.Sunday Then
                e.BackgroundColor = Me.HfWeekendBackColor.Value
            End If
        End If
        If Me.HfWeekdayBackColor.Value <> "" Then
            'If e.Start.DayOfWeek = DayOfWeek.Friday Or e.Start.DayOfWeek = DayOfWeek.Monday Or e.Start.DayOfWeek = DayOfWeek.Thursday Or e.Start.DayOfWeek = DayOfWeek.Tuesday Or e.Start.DayOfWeek = DayOfWeek.Wednesday Then
            If e.Start.DayOfWeek <> DayOfWeek.Saturday And e.Start.DayOfWeek <> DayOfWeek.Sunday Then
                e.BackgroundColor = Me.HfWeekdayBackColor.Value
            End If
        End If

    End Sub

    Protected Sub DayPilotMonth1_BeforeHeaderRender(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.Month.BeforeHeaderRenderEventArgs)
        ' 
        ' e.InnerHTML = "test" + e.DayOfWeek; 
        ' e.BackgroundColor = "red"; 
        ' 

    End Sub

    'Protected Sub DayPilotMonth1_TimeRangeSelected(ByVal sender As Object, ByVal e As TimeRangeSelectedEventArgs)
    '    Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

    '    Session("TaskCalendarSelectedDate") = e.Start

    '    DayPilotMonthExport.DataSource = Session("MonthView")
    '    DayPilotMonthExport.DataBind()
    '    DayPilotMonthExport.Update()

    'End Sub

    'Event style and formatting:
    Protected Sub DayPilotMonth1_BeforeEventRender(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.Month.BeforeEventRenderEventArgs)

        'objects
        Dim EventTextPlain As String = ""

        Try
            Dim ar() As String
            ar = e.Value.Split("|")
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)

            Dim IsNonTask As Integer = 0
            Dim NonTaskType As String = ""
            Dim IsAllDay As Integer = 0
            Dim TaskStatus As String = ""

            IsNonTask = CType(ar(1), Integer)
            IsAllDay = CType(ar(3), Integer)
            TaskStatus = ar(4).ToString().Trim()

            'Set the text
            NonTaskType = ar(2).ToString().Trim()
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            Dim s As String = ""

            dt = LoadCalendarDT()

            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim dv As DataView = New DataView(dt)
                    dv.RowFilter = "DATA_KEY = '" & e.Value & "'"
                    dt1 = dv.ToTable()
                    If Not dt1 Is Nothing Then
                        If dt1.Rows.Count > 0 Then
                            Dim dp As New cDayPilot()
                            s = dp.RenderEvents(dt1, IsNonTask, IsAllDay, False)
                        End If
                    End If
                End If
            End If
            e.InnerHTML = s
            EventTextPlain = s.Replace("<strong>", "").Replace("</strong>", "")

            'Set text formatting
            Select Case TaskStatus
                Case "A"
                    e.InnerHTML = String.Format("<span class=""calendarActive"">{0}</span>", e.InnerHTML)
                Case "P"
                    e.InnerHTML = String.Format("<span class=""calendarPending"">{0}</span>", e.InnerHTML)
                Case "N"
                    e.InnerHTML = String.Format("<span class=""calendarNormal"">{0}</span>", e.InnerHTML)
            End Select

            'set icon next to text
            If IsNonTask = 1 Then
                NonTaskType = ar(2).ToString().Trim()
                Select Case NonTaskType
                    Case "H"
                        If Me.HfHolidayBackColor.Value <> "" Then
                            e.BackgroundColor = Me.HfHolidayBackColor.Value
                        End If

                        If DayPilotMonthExport.IsExport = False Then

                            e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/calendar_24px-trans.png"" width=""12"" valign=""absmiddle""/>&nbsp;{0}", e.InnerHTML)

                        Else

                            e.InnerHTML = EventTextPlain

                        End If

                    Case "A"
                        IsAllDay = CType(ar(3), Integer)

                        If IsAllDay = 1 Then
                            If Me.HfAppointmentAllDayBackColor.Value <> "" Then
                                e.BackgroundColor = Me.HfAppointmentAllDayBackColor.Value
                            End If
                        Else
                            If Me.HfAppointmentBackColor.Value <> "" Then
                                e.BackgroundColor = Me.HfAppointmentBackColor.Value
                            End If
                        End If

                        If DayPilotMonthExport.IsExport = False Then

                            e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/clock-trans.png"" width=""12"" valign=""absmiddle""/>&nbsp;{0}", e.InnerHTML)

                        Else

                            e.InnerHTML = EventTextPlain

                        End If

                    Case Else

                        If DayPilotMonthExport.IsExport = False Then

                            e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/clock-trans.png"" width=""12"" valign=""absmiddle""/>&nbsp;{0}", e.InnerHTML)

                        Else

                            e.InnerHTML = EventTextPlain

                        End If

                End Select
            ElseIf IsNonTask = 0 Then 'Real task
                If Me.HfTaskBackColor.Value <> "" Then
                    e.BackgroundColor = Me.HfTaskBackColor.Value
                End If

                If DayPilotMonthExport.IsExport = False Then

                    e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/scroll-trans.png"" width=""12"" />&nbsp;{0}", e.InnerHTML)

                Else

                    e.InnerHTML = EventTextPlain

                End If

            ElseIf IsNonTask = 2 Then 'an event
                If IsDBNull(dt1.Rows(0)("AD_NBR_COLOR")) = False Then
                    If dt1.Rows(0)("AD_NBR_COLOR").ToString().Length = 7 Then
                        e.BackgroundColor = dt1.Rows(0)("AD_NBR_COLOR")
                    End If
                Else
                    If Me.HfDefaultEventColor.Value <> "" Then
                        e.BackgroundColor = Me.HfDefaultEventColor.Value
                    End If
                End If

                If DayPilotMonthExport.IsExport = False Then

                    e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/flash.png"" width=""12"" valign=""absmiddle""/>&nbsp;{0}", e.InnerHTML)

                Else

                    e.InnerHTML = EventTextPlain

                End If

            ElseIf IsNonTask = 3 Then 'an event task
                If Me.HfDefaultEventTaskColor.Value <> "" Then
                    e.BackgroundColor = Me.HfDefaultEventTaskColor.Value
                End If

                If DayPilotMonthExport.IsExport = False Then

                    e.InnerHTML = String.Format("<img border=""0"" height=""12"" src=""Images/flash_purple.png"" width=""12"" valign=""absmiddle""/>&nbsp;{0}", e.InnerHTML)

                Else

                    e.InnerHTML = EventTextPlain

                End If

            End If


            dt1 = Nothing
            dt = Nothing

        Catch ex As Exception
            e.InnerHTML = ex.Message.ToString()
        End Try
    End Sub

    'Info bubble on hover:
    Protected Sub DayPilotBubble1_RenderContent(ByVal sender As Object, ByVal e As RenderEventArgs)


        If TypeOf e Is RenderEventBubbleEventArgs Then
            Dim re As RenderEventBubbleEventArgs = TryCast(e, RenderEventBubbleEventArgs)
            're.Value is my key!
            Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
            oAppVars.getAllAppVars()

            Dim SbDetails As New System.Text.StringBuilder
            Dim ar() As String
            ar = re.Value.Split("|")
            Dim dt As New DataTable
            Dim dt1 As New DataTable
            Dim IsNonTask As Integer = 0
            Dim NonTaskType As String = ""
            Dim IsAllDay As Integer = 0


            IsNonTask = CType(ar(1), Integer)
            NonTaskType = ar(2).ToString().Trim()
            IsAllDay = CType(ar(3), Integer)

            Try
                dt = LoadCalendarDT()
                With SbDetails
                    '.Append("<strong>Details</strong><br />")
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            'filter:
                            Dim dv As DataView = New DataView(dt)
                            dv.RowFilter = "DATA_KEY = '" & re.Value & "'"
                            dt1 = dv.ToTable()
                            If Not dt1 Is Nothing Then
                                If dt1.Rows.Count > 0 Then
                                    'Get data and build:
                                    If IsNonTask = 1 Then
                                        Dim ShowEmpCode As Boolean = False
                                        Dim ShowEmpDescript As Boolean = False
                                        If CType(oAppVars.getAppVar("tcal_haemployeecode", "Boolean"), Boolean) = True And NonTaskType = "A" Then
                                            If IsDBNull(dt1.Rows(0)("EMP_CODE")) = False Then
                                                .Append("<strong>Employee: </strong> ")
                                                .Append(dt1.Rows(0)("EMP_CODE").ToString())
                                                ShowEmpCode = True
                                            End If
                                        End If
                                        If CType(oAppVars.getAppVar("tcal_haemployeedesc", "Boolean"), Boolean) = True And NonTaskType = "A" Then
                                            If ShowEmpCode = True Then
                                                If IsDBNull(dt1.Rows(0)("EMP_FML_NAME")) = False Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("EMP_FML_NAME").ToString())
                                                End If
                                                ShowEmpDescript = True
                                            Else
                                                .Append("<strong>Employee: </strong> ")
                                                .Append(dt1.Rows(0)("EMP_FML_NAME").ToString())
                                            End If

                                        End If
                                        If ShowEmpCode = True Or ShowEmpDescript = True Then
                                            .Append("<br />")
                                        End If

                                        If CType(oAppVars.getAppVar("tcal_hatype", "Boolean"), Boolean) = True Then
                                            If IsDBNull(dt1.Rows(0)("NON_TASK_TYPE")) = False Then
                                                .Append("<strong>Type:</strong> ")
                                                If dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim() = "H" Then
                                                    .Append("Holiday (H)")
                                                ElseIf dt1.Rows(0)("NON_TASK_TYPE").ToString().Trim() = "A" Then
                                                    .Append("Appointment (A)")
                                                End If
                                                .Append("<br />")
                                            End If
                                        End If
                                        'If Session("tcal_hasubject") = True Then
                                        If CType(oAppVars.getAppVar("tcal_hasubject", "Boolean"), Boolean) = True Then
                                            If IsDBNull(dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
                                                .Append("<strong>Subject: </strong> ")
                                                .Append(dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
                                                .Append("<br />")
                                            End If
                                        End If
                                        'If Session("tcal_hatimes") = True And IsAllDay = 0 Then
                                        If CType(oAppVars.getAppVar("tcal_hatimes", "Boolean"), Boolean) = True And IsAllDay = 0 Then
                                            If IsDBNull(dt1.Rows(0)("START_TIME")) = False And IsDBNull(dt1.Rows(0)("END_TIME")) = False Then
                                                .Append("<strong>Time: </strong> ")
                                                If IsDBNull(dt1.Rows(0)("NUM_DAYS")) = False Then
                                                    Dim DayCount As Integer = CType(dt1.Rows(0)("NUM_DAYS"), Integer)
                                                    Dim HasTime As Boolean = False
                                                    If IsDBNull(dt1.Rows(0)("HAS_TIME")) = False Then
                                                        If CType(dt1.Rows(0)("HAS_TIME"), Integer) = 1 Then
                                                            HasTime = True
                                                        End If
                                                    End If
                                                    If HasTime = True Then
                                                        If DayCount > 1 Then
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                                            .Append(" ")
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
                                                            .Append(" - ")
                                                            .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
                                                            .Append(" ")
                                                            .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
                                                        Else 'one day event:
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                                            .Append(" ")
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortTimeString())
                                                            .Append(" - ")
                                                            .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortTimeString())
                                                        End If
                                                    Else
                                                        If DayCount > 1 Then
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                                            .Append(" - ")
                                                            .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
                                                        Else 'one day event:
                                                            .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                                        End If
                                                    End If
                                                End If
                                                .Append("<br />")
                                            End If
                                        End If
                                        'If Session("tcal_hahours") = True Then
                                        If CType(oAppVars.getAppVar("tcal_hahours", "Boolean"), Boolean) = True Then
                                            If IsDBNull(dt1.Rows(0)("NON_TASK_HOURS")) = False Then
                                                .Append("<strong>Hours: </strong> ")
                                                .Append(FormatNumber(dt1.Rows(0)("NON_TASK_HOURS"), 2, True, False, True))
                                                .Append("<br />")
                                            End If
                                        End If
                                        'If Session("tcal_hatimecat") = True Then
                                        If CType(oAppVars.getAppVar("tcal_hatimecat", "Boolean"), Boolean) = True Then
                                            If IsDBNull(dt1.Rows(0)("NON_TASK_CATEGORY")) = False Then
                                                .Append("<strong>Category: </strong> ")
                                                .Append(dt1.Rows(0)("NON_TASK_CATEGORY").ToString())
                                                .Append("<br />")
                                            End If
                                        End If
                                    ElseIf IsNonTask = 0 Then 'Real task!
                                        Dim ShowCliCode As Boolean = False
                                        Dim ShowDivCode As Boolean = False
                                        Dim ShowPrdCode As Boolean = False
                                        Dim ShowJobNum As Boolean = False
                                        Dim ShowJobCompNum As Boolean = False
                                        Dim ShowTaskCode As Boolean = False
                                        Dim ShowEmpCode As Boolean = False
                                        Dim ShowCliDesc As Boolean = False
                                        Dim ShowDivDesc As Boolean = False
                                        Dim ShowPrdDesc As Boolean = False
                                        Dim ShowJobDesc As Boolean = False
                                        Dim ShowJobCompDesc As Boolean = False
                                        Dim ShowTaskDesc As Boolean = False
                                        Dim ShowEmpDesc As Boolean = False

                                        Try
                                            'If Session("tcal_tclientcode") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tclientcode", "Boolean"), Boolean) = True = True Then
                                                If IsDBNull(dt1.Rows(0)("CL_CODE")) = False Then
                                                    .Append("<strong>Client: </strong> ")
                                                    .Append(dt1.Rows(0)("CL_CODE").ToString())
                                                    ShowCliCode = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tclientdesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tclientdesc", "Boolean"), Boolean) = True Then
                                                If ShowCliCode = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("CL_NAME").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("CL_NAME")) = False Then
                                                        .Append("Client: ")
                                                        .Append(dt1.Rows(0)("CL_NAME").ToString())
                                                        ShowCliDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowCliCode = True Or ShowCliDesc = True Then
                                            .Append("<br />")
                                        End If


                                        Try
                                            'If Session("tcal_tdivcode") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tdivcode", "Boolean"), Boolean) = True Then
                                                If IsDBNull(dt1.Rows(0)("DIV_CODE")) = False Then
                                                    .Append("<strong>Division: </strong> ")
                                                    .Append(dt1.Rows(0)("DIV_CODE").ToString())
                                                    ShowDivCode = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tdivdesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tdivdesc", "Boolean"), Boolean) = True Then
                                                If ShowDivCode = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("DIV_NAME").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("DIV_NAME")) = False Then
                                                        .Append("<strong>Division: </strong> ")
                                                        .Append(dt1.Rows(0)("DIV_NAME").ToString())
                                                        ShowDivDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowDivCode = True Or ShowDivDesc = True Then
                                            .Append("<br />")
                                        End If


                                        Try
                                            'If Session("tcal_tprodcode") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tprodcode", "Boolean"), Boolean) = True Then
                                                If IsDBNull(dt1.Rows(0)("PRD_CODE")) = False Then
                                                    .Append("<strong>Product: </strong> ")
                                                    .Append(dt1.Rows(0)("PRD_CODE").ToString())
                                                    ShowPrdCode = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tproddesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tproddesc", "Boolean"), Boolean) = True Then
                                                If ShowPrdCode = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("PRD_DESCRIPTION").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("PRD_DESCRIPTION")) = False Then
                                                        .Append("<strong>Product: </strong> ")
                                                        .Append(dt1.Rows(0)("PRD_DESCRIPTION").ToString())
                                                        ShowPrdDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowPrdCode = True Or ShowPrdDesc = True Then
                                            .Append("<br />")
                                        End If


                                        Try
                                            'If Session("tcal_tjobnum") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tjobnum", "Boolean"), Boolean) = True Then
                                                If IsDBNull(dt1.Rows(0)("JOB_NUMBER")) = False Then
                                                    .Append("<strong>Job: </strong> ")
                                                    .Append(dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
                                                    ShowJobNum = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobdesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tjobdesc", "Boolean"), Boolean) = True Then
                                                If ShowJobNum = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("JOB_DESC").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("JOB_DESC")) = False Then
                                                        .Append("<strong>Job: </strong> ")
                                                        .Append(dt1.Rows(0)("JOB_DESC").ToString())
                                                        ShowJobDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowJobNum = True Or ShowJobDesc = True Then
                                            .Append("<br />")
                                        End If


                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tjobcompnum", "Boolean"), Boolean) = True Then
                                                If IsDBNull(dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                                    .Append("<strong>Component: </strong> ")
                                                    .Append(dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
                                                    ShowJobCompNum = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompdesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_tjobcompdesc", "Boolean"), Boolean) = True Then
                                                If ShowJobCompNum = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("JOB_COMP_DESC").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("JOB_COMP_DESC")) = False Then
                                                        .Append("<strong>Component: </strong> ")
                                                        .Append(dt1.Rows(0)("JOB_COMP_DESC").ToString())
                                                        ShowJobCompDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowJobCompNum = True Or ShowJobCompDesc = True Then
                                            .Append("<br />")
                                        End If


                                        Try
                                            'If Session("tcal_ttaskcode") = True Then
                                            If CType(oAppVars.getAppVar("tcal_ttaskcode", "Boolean"), Boolean) = True Then
                                                If IsDBNull(dt1.Rows(0)("FNC_CODE")) = False Then
                                                    .Append("<strong>Task: </strong> ")
                                                    .Append(dt1.Rows(0)("FNC_CODE").ToString())
                                                    ShowTaskCode = True
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_ttaskdesc") = True Then
                                            If CType(oAppVars.getAppVar("tcal_ttaskdesc", "Boolean"), Boolean) = True Then
                                                If ShowTaskCode = True Then
                                                    .Append(" - ")
                                                    .Append(dt1.Rows(0)("TASK_DESCRIPTION").ToString())
                                                Else
                                                    If IsDBNull(dt1.Rows(0)("TASK_DESCRIPTION")) = False Then
                                                        .Append("<strong>Task: </strong> ")
                                                        .Append(dt1.Rows(0)("TASK_DESCRIPTION").ToString())
                                                        ShowTaskDesc = True
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        If ShowTaskCode = True Or ShowTaskDesc = True Then
                                            .Append("<br />")
                                        End If

                                        Try
                                            If IsDBNull(dt1.Rows(0)("START_TIME")) = False And IsDBNull(dt1.Rows(0)("END_TIME")) = False Then
                                                If IsDBNull(dt1.Rows(0)("NUM_DAYS")) = False Then
                                                    Dim DayCount As Integer = CType(dt1.Rows(0)("NUM_DAYS"), Integer)
                                                    If DayCount > 1 Then
                                                        .Append("<strong>Dates: </strong> ")
                                                        .Append(CType(dt1.Rows(0)("START_TIME"), Date).ToShortDateString())
                                                        .Append(" - ")
                                                        .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
                                                        'Else 'one day event:
                                                        '    .Append(CType(dt1.Rows(0)("END_TIME"), Date).ToShortDateString())
                                                        .Append("<br />")
                                                    End If
                                                End If
                                            End If
                                        Catch ex As Exception
                                        End Try


                                        If CType(oAppVars.getAppVar("tcal_empcodedispl", "Boolean"), Boolean) = True And NonTaskType = "T" Then
                                            ShowEmpCode = True
                                        End If
                                        If CType(oAppVars.getAppVar("tcal_empdescdispl", "Boolean"), Boolean) = True And NonTaskType = "T" Then
                                            ShowEmpDesc = True
                                        End If
                                        If ShowEmpCode = True Or ShowEmpDesc = True Then
                                            .Append("<strong>Employee(s): </strong> ")
                                        End If
                                        If ShowEmpCode = True And ShowEmpDesc = False Then
                                            .Append(dt1.Rows(0)("EMP_CODE").ToString())
                                        ElseIf ShowEmpCode = False And ShowEmpDesc = True Then
                                            .Append(dt1.Rows(0)("EMP_FML_NAME").ToString().Replace(",", "<br />"))
                                        ElseIf ShowEmpCode = True And ShowEmpDesc = True Then
                                            .Append(dt1.Rows(0)("EMP_CODE_FML_NAME").ToString().Replace(",", "<br />"))
                                        End If
                                        If ShowEmpCode = True Or ShowEmpDesc = True Then
                                            .Append("<br />")
                                        End If
                                    ElseIf IsNonTask = 2 Then 'event
                                        Try
                                            'If Session("tcal_tjobnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("JOB_NUMBER")) = False Then
                                                .Append("<strong>Job Number: </strong> ")
                                                .Append(dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                                .Append("<strong>Component Number: </strong> ")
                                                .Append(dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("NON_TASK_ID")) = False Then
                                                .Append("<strong>Event ID: </strong> ")
                                                .Append(dt1.Rows(0)("NON_TASK_ID").ToString().PadLeft(6, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("TASK_NON_TASK_DISPLAY")) = False Then
                                                .Append("<strong>Event Description: </strong> ")
                                                .Append(dt1.Rows(0)("TASK_NON_TASK_DISPLAY").ToString())
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        'Try
                                        '    If IsDBNull(dt1.Rows(0)("START_TIME")) = False And IsDBNull(dt1.Rows(0)("END_TIME")) = False Then
                                        '        '.Append("<strong>Dates: </strong> ")
                                        '        '.Append(CType(dt1.Rows(0)("START_TIME"), Date))
                                        '        '.Append(" - ")
                                        '        '.Append(CType(dt1.Rows(0)("END_TIME"), Date))
                                        '        '.Append("<br />")
                                        '        .Append("<strong>Start: </strong> ")
                                        '        .Append(CType(dt1.Rows(0)("START_TIME"), Date))
                                        '        .Append("<br />")
                                        '        .Append("<strong>End: </strong> ")
                                        '        .Append(CType(dt1.Rows(0)("END_TIME"), Date))
                                        '        .Append("<br />")
                                        '    End If
                                        'Catch ex As Exception
                                        'End Try

                                    ElseIf IsNonTask = 3 Then 'an event task
                                        Try
                                            'If Session("tcal_tjobnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("JOB_NUMBER")) = False Then
                                                .Append("<strong>Job Number: </strong> ")
                                                .Append(dt1.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                                .Append("<strong>Component Number: </strong> ")
                                                .Append(dt1.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("TASK_SEQ_NBR")) = False Then
                                                .Append("<strong>Event ID: </strong> ")
                                                .Append(dt1.Rows(0)("TASK_SEQ_NBR").ToString().PadLeft(6, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("EVENT_AND_DESCRIPT")) = False Then
                                                .Append("<strong>Event Description: </strong> ")
                                                .Append(dt1.Rows(0)("EVENT_AND_DESCRIPT").ToString())
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("NON_TASK_ID")) = False Then
                                                .Append("<strong>Event Task ID: </strong> ")
                                                .Append(dt1.Rows(0)("NON_TASK_ID").ToString().PadLeft(6, "0"))
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        Try
                                            'If Session("tcal_tjobcompnum") = True Then
                                            If IsDBNull(dt1.Rows(0)("TRF_AND_DESCRIPT")) = False Then
                                                .Append("<strong>Task Description: </strong> ")
                                                .Append(dt1.Rows(0)("TRF_AND_DESCRIPT").ToString())
                                                .Append("<br />")
                                            End If
                                            'End If
                                        Catch ex As Exception
                                        End Try
                                        '
                                    End If
                                End If
                            End If
                        Else
                            .Append("[None]")
                        End If
                    End If
                End With
                re.InnerHTML = "<span class=""BlackText"">" & SbDetails.ToString() & "</span>"
            Catch ex As Exception
                re.InnerHTML = "<span class=""BlackText""><strong>ERROR</strong><br />" & ex.Message.ToString() & "</span>"
            End Try
        End If
    End Sub

    Protected Sub DayPilotMonth1_Refresh(ByVal sender As Object, ByVal e As RefreshEventArgs)
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
        Session("TaskCalendarSelectedDate") = e.StartDate
        'oAppVars.setAppVarDB("TaskCalendarSelectedDate", CType(e.StartDate, String), "Date")
        'Me.LoadCalendar()

        'Dim data As String = DirectCast(e.Data, String)
        'DayPilotMonth1.StartDate = e.StartDate
        'DayPilotMonth1.DataSource = Session("MonthView")
        'DayPilotMonth1.DataBind()
        'DayPilotMonth1.Update()

    End Sub

    Protected Sub DayPilotMonth1_EventClick(ByVal sender As Object, ByVal e As DayPilot.Web.Ui.Events.EventClickEventArgs)
        Try

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "  Form Event Handlers "

    Protected Sub Calendar_Print_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim SchedulerBitmapMemoryStream As System.IO.MemoryStream = Nothing

        Try

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If Session("SchedulerTitle") IsNot Nothing Then

                Me.LabelTitle.Text = Session("SchedulerTitle")

            End If

            If Session("SchedulerPlacement") IsNot Nothing Then
                If Session("SchedulerPlacement") = "center" Then
                    Me.trTitle.Align = "center"
                End If
                If Session("SchedulerPlacement") = "right" Then
                    Me.trTitle.Align = "right"
                End If
                If Session("SchedulerPlacement") = "left" Then
                    Me.trTitle.Align = "left"
                End If
            End If
            If Request.QueryString("FromApp") = "PS" Then
                If qs.Get("JobNum") <> "" Then
                    JobNum = qs.Get("JobNum")
                End If
                If qs.Get("JobCompNum") <> "" Then
                    JobCompNum = qs.Get("JobCompNum")
                End If
            ElseIf qs.Get("FromApp") = "PSMV" Then
                view = qs.Get("view")
                NonTaskType = qs.Get("nontasktype")
                Duration = qs.Get("duration")
            End If
            LoadCalendar()
            SchedulerBitmapMemoryStream = DayPilotMonthExport.Export(System.Drawing.Imaging.ImageFormat.Bmp)

        Catch ex As Exception
            Me.LabelTitle.Text = "Calendar Report"
        End Try

        Try

            'If Session("SchedulerBitmapMemoryStream") IsNot Nothing Then

            '    If TypeOf Session("SchedulerBitmapMemoryStream") Is System.IO.MemoryStream Then

            '        SchedulerBitmapMemoryStream = Session("SchedulerBitmapMemoryStream")

            RadBinaryImageScreenShot.DataValue = SchedulerBitmapMemoryStream.ToArray

            '    End If

            'End If

        Catch ex As Exception
            SchedulerBitmapMemoryStream = Nothing
        Finally

            If SchedulerBitmapMemoryStream IsNot Nothing Then

                SchedulerBitmapMemoryStream.Close()
                SchedulerBitmapMemoryStream.Dispose()
                SchedulerBitmapMemoryStream = Nothing

            End If

            'Session("SchedulerBitmapMemoryStream") = Nothing

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "


#End Region

#End Region

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim cScript2 As String
            cScript2 = "<script>window.print();</script>"
            RegisterStartupScript("page55", cScript2)
        Catch ex As Exception

        End Try
    End Sub
End Class
