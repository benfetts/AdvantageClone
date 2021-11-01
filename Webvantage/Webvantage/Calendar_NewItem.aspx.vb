Imports Webvantage.cGlobals
Public Class Calendar_NewItem
    Inherits Webvantage.BaseChildPage

    Dim JobNo As Integer
    Dim JobComp As Integer
    Dim SeqNo As Integer
    Dim starttime As String
    Dim endtime As String
    Public RandomClass As New Random()



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Calendar)

        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    If Page.IsPostBack = False Then
                        If Session("TaskCalendarSelectedDate") Is Nothing Then
                            Session("TaskCalendarSelectedDate") = Date.Today
                        End If
                        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
                        Dim tdate As String
                        If Request.QueryString("thisdate") <> "" Then
                            If Request.QueryString("click") = "day" Then
                                tdate = Request.QueryString("thisdate").Substring(4, 11).Trim
                            Else
                                tdate = Request.QueryString("thisdate")
                            End If

                            If wvIsDate(tdate) Then
                                Me.RadDatePickerStartDate.SelectedDate = CDate(tdate)
                                Me.RadDatePickerEndDate.SelectedDate = CDate(tdate)
                            End If
                        Else
                            Me.RadDatePickerStartDate.SelectedDate = CDate(Session("TaskCalendarSelectedDate"))
                            Me.RadDatePickerEndDate.SelectedDate = CDate(Session("TaskCalendarSelectedDate"))
                        End If
                        Me.chkAppointment.Checked = True
                        timeSelect()
                        Me.radTimePickerStart.SelectedDate = Convert.ToDateTime(starttime)
                        Me.radTimePickerEnd.SelectedDate = Convert.ToDateTime(endtime)
                        If Request.QueryString("TaskNo") = "" Then
                            Me.butSave.Visible = True
                            Me.butUpdate.Visible = False
                            Me.butDelete.Visible = False
                        Else
                            Me.butSave.Visible = False
                            Me.btnExport.Visible = True
                            Me.butUpdate.Visible = True
                            Me.butDelete.Visible = True
                        End If
                        If Not Session("EmpCode") Is Nothing And Session("EmpCode") <> "" And Session("EmpCode") <> "sys" Then
                            Me.ddlEmps.SelectedValue = Session("EmpCode")
                        End If
                        LoadCategories()
                        LoadEmployees()
                        LoadTask()
                        SetSecurity()
                        FillExport()
                    End If
                    If Me.chkAllDay.Checked = True Then
                        Me.radTimePickerStart.SelectedDate = Convert.ToDateTime("12:00:00 AM")
                        starttime = "12:00:00 AM"
                        Me.radTimePickerEnd.SelectedDate = Convert.ToDateTime("11:59:00 PM")
                        endtime = "11:59:00 PM"
                        Me.radTimePickerEnd.Enabled = False
                        Me.radTimePickerStart.Enabled = False

                        ' radTimePickerStart.SelectedDate = "" starttime = "06:30:00 PM"
                        'endtime = "06:30:00 PM"
                    Else
                        Me.radTimePickerEnd.Enabled = True
                        Me.radTimePickerStart.Enabled = True

                    End If
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

    Private Sub LoadCategories()
        Try
            Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
            Dim i As Integer = 0
            Dim other As New Telerik.Web.UI.RadComboBoxItem
            other.Text = "*NONE*"
            other.Value = ""
            Dim none As New Telerik.Web.UI.RadComboBoxItem
            none.Text = ""
            none.Value = "no"
            'Dim dr As SqlClient.SqlDataReader
            'dr = oDropDowns.GetTimeCategories
            Me.ddlCategory.DataSource = oDropDowns.GetTimeCategories
            Me.ddlCategory.DataTextField = "DESCRIPTION"
            Me.ddlCategory.DataValueField = "CATEGORY"
            Me.ddlCategory.DataBind()
            Me.ddlCategory.Items.Insert(0, none)
            Me.ddlCategory.Items.Add(other)
            'Do While dr.Read
            '    Dim str As String = dr.GetString(1)
            '    Me.ddlCategory.Items.Insert(i, New Telerik.Web.UI.RadComboBoxItem(dr.GetString(1), dr.GetString(0)))
            '    i += 1
            'Loop
        Catch ex As Exception
            Response.Write("Error ddcategory!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadEmployees()
        Try
            Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

            Me.ddlEmps.DataSource = oDropDowns.GetEmployees(Session("UserID"))
            Me.ddlEmps.DataTextField = "DESCRIPTION"
            Me.ddlEmps.DataValueField = "CODE"
            Me.ddlEmps.DataBind()
            'Me.ddEmps.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
        Catch ex As Exception
            Response.Write("Error ddemps!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadTask()

        'objects
        Dim AllowUserToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        Try
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetNonTaskData(Request.QueryString("TaskNo"), HttpContext.Current.Session("UserCode"))
            Dim type As String

            While dr.Read
                type = dr.GetString(1)
                If dr.GetString(1) = "H" Then
                    Me.chkHoliday.Checked = True
                    Me.chkAppointment.Checked = False
                    Me.ddlEmps.Enabled = False
                    Me.btnExport.Visible = False
                ElseIf dr.GetString(1) = "A" Then
                    Me.chkAppointment.Checked = True
                    Me.chkHoliday.Checked = False
                    Me.ddlEmps.Enabled = True
                    If CStr(Session("EmpCode")) <> dr.GetString(3) Then
                        Me.ddlEmps.SelectedValue = dr.GetString(3)
                    Else
                        If Not Session("EmpCode") Is Nothing And Session("EmpCode") <> "" And Session("EmpCode") <> "sys" Then
                            Me.ddlEmps.SelectedValue = Session("EmpCode")
                        End If
                    End If
                End If
                Me.txtSubject.Text = dr.GetString(2)
                If dr.GetInt32(4) = 1 Then
                    Me.chkAllDay.Checked = True
                Else
                    Me.chkAllDay.Checked = False
                    Me.radTimePickerStart.SelectedDate = dr.GetDateTime(7)
                    Me.radTimePickerEnd.SelectedDate = dr.GetDateTime(8)
                End If
                Me.RadDatePickerStartDate.SelectedDate = dr.GetDateTime(5).Date
                Me.RadDatePickerEndDate.SelectedDate = dr.GetDateTime(6).Date
                'If dr.IsDBNull(9) = True Then
                '    Me.ddlCategory.SelectedValue = ""
                'Else
                Me.ddlCategory.SelectedValue = dr.GetString(9).Trim
                'End If
            End While

            Try

                UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

                For Each UserGroupSettingValue In UserGroupSettingValues

                    Try

                        If UserGroupSettingValue = True Then

                            AllowUserToViewOtherEmployees = True
                            Exit For

                        End If

                    Catch ex As Exception

                    End Try

                Next

            Catch ex As Exception
                AllowUserToViewOtherEmployees = False
            End Try

            If AllowUserToViewOtherEmployees = False Then
                If type = "H" Then
                    Me.chkHoliday.Enabled = False
                    ddlEmps.Enabled = False
                    Me.butDelete.Visible = False
                    Me.butUpdate.Visible = False
                    'Me.butSave.Visible = False
                End If
                If type = "A" Then
                    Me.butDelete.Visible = True
                    Me.butUpdate.Visible = True
                End If

            End If
            type = ""
            If Me.HasAccessToEmployee(Me.ddlEmps.SelectedValue) = False Then
                Me.btnExport.Enabled = False
                Me.butSave.Enabled = False
                Me.butDelete.Enabled = False
                Me.butUpdate.Enabled = False
            End If
        Catch ex As Exception
            Response.Write("Error with Loading Task: " & ex.Message.ToString())
        End Try
    End Sub

    Private Function GetTaskEmpCode(ByVal TaskId As Integer) As String
        Try
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetNonTaskData(Request.QueryString("TaskNo"), HttpContext.Current.Session("UserCode"))
            While dr.Read
                Return dr.GetString(3)
            End While
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub SetSecurity()

        'objects
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim oAppVars As New cAppVars(cAppVars.Application.CALENDAR)
        Dim AllowGroupToViewOtherEmployees As Boolean = False
        Dim AllowGroupToAddHolidays As Boolean = False

        Try

            UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

            For Each UserGroupSettingValue In UserGroupSettingValues

                Try

                    If UserGroupSettingValue = True Then

                        AllowGroupToViewOtherEmployees = True
                        Exit For

                    End If

                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            AllowGroupToViewOtherEmployees = False
        End Try

        If AllowGroupToViewOtherEmployees = False Then

            ddlEmps.Enabled = False

        End If

        Try

            UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays)

            For Each UserGroupSettingValue In UserGroupSettingValues

                Try

                    If UserGroupSettingValue = True Then

                        AllowGroupToAddHolidays = True
                        Exit For

                    End If

                Catch ex As Exception

                End Try

            Next

        Catch ex As Exception
            AllowGroupToAddHolidays = False
        End Try

        If AllowGroupToAddHolidays = False Then

            Me.chkHoliday.Enabled = False

        End If

    End Sub

    Private Sub butSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSave.Click
        Try
            Dim save As Boolean
            save = Me.saveNonTask
            If save = True Then
                Session("TaskCalendarSelectedDate") = Me.RadDatePickerStartDate.SelectedDate
                Me.btnExport.Visible = True
                Me.butSave.Visible = False
                'Me.butUpdate.Visible = True
                lblConfirm.Visible = True
                lblConfirm.Text = "Save Successful."
                If Not IsNothing(Session("SavedKey")) Then
                    Dim sKey As String = Session("SavedKey").ToString
                    Session("SavedKey") = Nothing
                    'MiscFN.ResponseRedirect("Calendar_NewItem.aspx?TaskNo=" + sKey + "&FromSave=T")
                End If
                '
            Else
                Me.ShowMessage("Save Failed.")
                Exit Sub
            End If
            'Dim cScript As String
            'cScript = "<script language='javascript'> opener.location.href = 'Calendar_MonthView.aspx'; </script>"
            'RegisterStartupScript("parentwindow", cScript)
            'Dim cScript2 As String
            'cScript2 = "<script>window.close();</script>"
            'RegisterStartupScript("page", cScript2)
            Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
        Catch ex As Exception
            Response.Write("Error with Saving Task(Save): " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CreateExport(ByVal bFromExportButton As Boolean)

        'objects
        Dim FileStream As System.IO.FileStream = Nothing
        Dim ICSFileBytes() As Byte = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim FileName As String = ""
        Dim subject As String
        Dim body As String
        Dim taskdate As String
        Dim duration As String
        Dim reminder As String
        Dim allday As Boolean
        Dim time As String = Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString
        subject = Me.txtSubject.Text
        body = Me.txtSubject.Text
        taskdate = Me.RadDatePickerStartDate.SelectedDate & " " & Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString
        duration = CDate(Me.RadDatePickerEndDate.SelectedDate & " " & Me.radTimePickerEnd.SelectedDate.Value.TimeOfDay.ToString()).Subtract(CDate(Me.RadDatePickerStartDate.SelectedDate & " " & Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString())).TotalMinutes.ToString
        reminder = "False"
        allday = Me.chkAllDay.Checked



        If (IsNothing(Session("ExportData")) = False) Then

            Dim oEvent As New iCal.Events.cEvent
            Dim oCal As New iCal.Events.cICalendar

            Dim Export As ExportStructure
            Export = CType(Session("ExportData"), ExportStructure)
            oEvent.UID = Export.UID

            oEvent.SEQUENCE = RandomClass.Next(1, 1000).ToString() '(Now.Ticks / 100).ToString
            oEvent.Description = Export.Description
            oEvent.Title = Export.Description
            oEvent.StartTime = Export.StartTime
            oEvent.EndTime = Export.EndTime
            oEvent.Location = " "
            oEvent.Priority = iCal.Events.PriorityLevel.Normal
            oEvent.Category = Export.Category
            oCal.cEvents.Add(oEvent)
            Select Case Export.Method.ToUpper
                Case "PUBLISH"
                    oCal.METHOD = iCal.Events.METHODS.PUBLISH
                Case "CANCEL"
                    oCal.METHOD = iCal.Events.METHODS.CANCEL
                Case "REQUEST"
                    oCal.METHOD = iCal.Events.METHODS.REQUEST
                Case Else
                    oCal.METHOD = iCal.Events.METHODS.PUBLISH
            End Select

            If bFromExportButton Then

                Response.ContentType = "text/calendar"
                Response.AddHeader("content-disposition", "inline;filename=AdvantageCal.ics")
                Response.BinaryWrite(New System.Text.ASCIIEncoding().GetBytes(oCal.Output))
                Response.End()

            Else

                FileName = My.Application.Info.DirectoryPath & "\" & Now.ToFileTimeUtc.ToString() & ".ics"

                FileStream = New System.IO.FileStream(FileName, System.IO.FileMode.Create, IO.FileAccess.Write)

                ICSFileBytes = New System.Text.ASCIIEncoding().GetBytes(oCal.Output)

                FileStream.Write(ICSFileBytes, 0, ICSFileBytes.Length)

                FileStream.Close()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("EmpCode").ToString())

                        If Agency IsNot Nothing AndAlso Employee IsNot Nothing Then

                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency, Employee, FileName, "Advantage Calender Sync Email", "", 2, 0)

                        End If

                    End Using

                End Using

                If My.Computer.FileSystem.FileExists(FileName) Then

                    My.Computer.FileSystem.DeleteFile(FileName)

                End If

            End If

        End If

    End Sub

    Private Sub FillExport()
        Try
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim MyExport As New ExportStructure
            MyExport.UID = "A|" + oCalendar.InsertKey.ToString
            Session("SavedKey") = oCalendar.InsertKey.ToString
            MyExport.Category = Me.ddlCategory.SelectedItem.ToString
            MyExport.Description = Me.txtSubject.Text
            If Me.chkAllDay.Checked = False Then
                MyExport.StartTime = CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerStart.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Second.ToString
                MyExport.EndTime = CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerEnd.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Second.ToString
            Else
                MyExport.StartTime = Convert.ToDateTime(CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString & " 12:00:00 AM")
                MyExport.EndTime = Convert.ToDateTime(CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString & " 11:59:00 pm") 'Maybe this needs to end with 59seconds but the rest of your codes doesnt. Dan
            End If
            MyExport.Title = Me.txtSubject.Text
            MyExport.Method = "publish"
            Session("ExportData") = MyExport
        Catch ex As Exception
        End Try
    End Sub

    Private Sub butSaveExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSaveExport.Click
        Try
            Dim save As Boolean
            save = Me.saveNonTask

            Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim subject As String
            Dim body As String
            Dim taskdate As String
            Dim duration As String
            Dim reminder As String
            Dim allday As Boolean
            Dim time As String = Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString

            If save = True Then
                Session("TaskCalendarSelectedDate") = Me.RadDatePickerStartDate.SelectedDate
                Me.chkAllDay.Checked = False
                Me.chkHoliday.Checked = False
                Me.chkAppointment.Checked = False
                Me.txtSubject.Text = ""
                Me.radTimePickerStart.SelectedDate = cEmployee.TimeZoneToday
                Me.radTimePickerEnd.SelectedDate = cEmployee.TimeZoneToday
                Me.RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
                Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
            Else
                Me.ShowMessage("Save Failed.")
            End If
            Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
        Catch ex As Exception
            Response.Write("Error with Saving Task(Save/Export): " & ex.Message.ToString())
        End Try
    End Sub

    Private Function saveNonTask()

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))

        If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
            Me.ShowMessage("Invalid Start date")
            Exit Function
        End If
        If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
            Me.ShowMessage("Invalid End date")
            Exit Function
        End If
        If MiscFN.ValidDate(Me.RadDatePickerStartDate, False) = False And Me.chkAllDay.Checked = False Then
            Me.ShowMessage("Invalid Start date")
            Exit Function
        ElseIf Me.chkAllDay.Checked = True Then
            Me.radTimePickerStart.SelectedDate = cEmployee.TimeZoneToday
        End If
        If MiscFN.ValidDate(Me.RadDatePickerEndDate, False) = False And Me.chkAllDay.Checked = False Then
            Me.ShowMessage("Invalid End date")
            Exit Function
        ElseIf Me.chkAllDay.Checked = True Then
            Me.radTimePickerEnd.SelectedDate = cEmployee.TimeZoneToday
        End If
        If Me.chkHoliday.Checked = False And Me.chkAppointment.Checked = False Then
            Me.ShowMessage("Please select a type.")
            Exit Function
        End If
        If Me.ddlCategory.SelectedItem.Value = "no" Then
            Me.ShowMessage("Please select a category.")
            Exit Function
        End If
        If wvCDate(Me.RadDatePickerEndDate.SelectedDate) < wvCDate(Me.RadDatePickerStartDate.SelectedDate) Then
            Me.ShowMessage("End date cannot be less than start date.")
            Exit Function
        End If
        If Me.chkAllDay.Checked = False Then
            If CType(Me.radTimePickerEnd.SelectedDate, Date) < CType(Me.radTimePickerStart.SelectedDate, Date) Then
                Me.ShowMessage("End time cannot be less than start time.")
                Exit Function
            End If
        End If
        If Me.chkHoliday.Checked = True And oCalendar.checkHolidays(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.chkAllDay.Checked) = True Then
            Me.ShowMessage("Holiday already exists for this day")
            Exit Function
        End If
        If oCalendar.checkAppointments(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Me.chkAllDay.Checked = True, Me.ddlEmps.SelectedValue) Then
            If Me.chkAppointment.Checked = True Then
                Me.ShowMessage("WARNING:  Appointment conflicts with existing appointment.")
            Else
                Me.ShowMessage("WARNING:  Holiday conflicts with existing appointments.")
            End If

        End If

        Try
            Dim standardHours As Decimal
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetStandardHours()
            Do While dr.Read
                standardHours = dr.GetDecimal(0)
            Loop
            Dim save As Boolean
            'Dim date1 As DateTime = Me.radTimePickerStart.SelectedDate.ToUniversalTime
            'Dim date2 As DateTime = Me.radTimePickerEnd.SelectedDate.ToLocalTime
            If Me.chkHoliday.Checked = True Then
                save = oCalendar.AddNewTask(Me.chkHoliday.Checked, Me.chkAppointment.Checked, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Nothing, Me.ddlCategory.SelectedValue.ToString(), "", standardHours)
            Else
                save = oCalendar.AddNewTask(Me.chkHoliday.Checked, Me.chkAppointment.Checked, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, ddlEmps.SelectedValue.ToString(), Me.ddlCategory.SelectedValue.ToString(), "", standardHours)
                Dim MyExport As New ExportStructure
                MyExport.UID = "A|" + oCalendar.InsertKey.ToString
                Session("SavedKey") = oCalendar.InsertKey.ToString
                MyExport.Category = Me.ddlCategory.SelectedItem.ToString
                MyExport.Description = Me.txtSubject.Text
                If Me.chkAllDay.Checked = False Then
                    MyExport.StartTime = CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerStart.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Second.ToString
                    MyExport.EndTime = CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerEnd.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Second.ToString
                Else
                    MyExport.StartTime = Convert.ToDateTime(CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString & " 12:00:00 AM")
                    MyExport.EndTime = Convert.ToDateTime(CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString & " 11:59:00 PM") 'Maybe this needs to end with 59seconds but the rest of your codes doesnt. Dan
                End If
                MyExport.Title = Me.txtSubject.Text
                MyExport.Method = "publish"
                Session("ExportData") = MyExport

                'Me.CreateExport(False)

            End If

            If save Then

                'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), oCalendar.InsertKey, chkHoliday.Checked, False)
                Me.CalendarSync(oCalendar.InsertKey, chkHoliday.Checked, False)

            End If

            Return save

        Catch ex As Exception
            Response.Write("Error with Saving Task: " & ex.Message.ToString())
        End Try
    End Function

    'TODO: FIX!!!!!!!!!!
    Private Sub ShowMessageConfirm(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
        Dim strScript As String
        strScript = "<script type=""text/javascript""> var con = confirm('Appointment conflicts with existing appointment.  Would you like to continue?'); document.form[0].lblConfirm.value = con;</script>"
        If Not Page.IsStartupScriptRegistered("JSConfirm") Then
            Page.RegisterStartupScript("JSConfirm", strScript)
        End If
        'Response.Write(strMessage)
    End Sub

    Private Sub chkHoliday_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHoliday.CheckedChanged
        If Me.chkHoliday.Checked = True Then
            Me.ddlEmps.Enabled = False
            Me.chkAllDay.Checked = True
            Me.btnExport.Visible = False
            'Me.ddlCategory.SelectedItem.Text = "Holiday"
        Else
            Me.ddlEmps.Enabled = True
            Me.chkAllDay.Checked = False
        End If
    End Sub

    Private Sub chkAppointment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAppointment.CheckedChanged

        'objects
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim AllowGroupToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        If Me.chkAppointment.Checked = True Then

            Try

                UserGroupSettingValues = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees)

                For Each UserGroupSettingValue In UserGroupSettingValues

                    Try

                        If UserGroupSettingValue = True Then

                            AllowGroupToViewOtherEmployees = True
                            Exit For

                        End If

                    Catch ex As Exception

                    End Try

                Next

            Catch ex As Exception
                AllowGroupToViewOtherEmployees = False
            End Try

            If AllowGroupToViewOtherEmployees = False Then
                ddlEmps.Enabled = False
            Else
                Me.ddlEmps.Enabled = True
            End If
            Me.chkAllDay.Checked = False
            'Me.btnExport.Visible = True
            'Me.ddlCategory.SelectedItem.Text = "Personal"
        End If

    End Sub

    Private Sub butDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butDelete.Click

        'objects
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim SyncWithOutlook As Boolean = False
        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))

        Try
            Dim save As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Request.QueryString("TaskNo"))

                save = oCalendar.DeleteTask(Request.QueryString("TaskNo"))

                If save = True Then

                    If EmployeeNonTask IsNot Nothing Then

                        'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), EmployeeNonTask, (EmployeeNonTask.Type = "H"), True)
                        Session("EmployeeNonTask_CalendarObject") = EmployeeNonTask.ID
                        Me.CalendarSync(EmployeeNonTask.ID, (EmployeeNonTask.Type = "H"), True)

                    End If

                    Session("TaskCalendarSelectedDate") = Me.RadDatePickerStartDate.SelectedDate

                Else

                    Me.ShowMessage("Delete Failed.")

                End If

                'Dim cScript As String
                'cScript = "<script language='javascript'> opener.location.href = 'Calendar_MonthView.aspx'; </script>"
                'RegisterStartupScript("parentwindow", cScript)
                'Dim cScript2 As String
                'cScript2 = "<script>window.close();</script>"
                'RegisterStartupScript("page", cScript2)
                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")

            End Using

        Catch ex As Exception
            Response.Write("Error with Deleting Task: " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub butUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butUpdate.Click

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))

        Try
            If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                Me.ShowMessage("Invalid Start date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                Me.ShowMessage("Invalid End date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerStartDate, False) = False And Me.chkAllDay.Checked = False Then
                Me.ShowMessage("Invalid Start date")
                Exit Sub
            ElseIf Me.chkAllDay.Checked = True Then
                Me.radTimePickerStart.SelectedDate = cEmployee.TimeZoneToday
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate, False) = False And Me.chkAllDay.Checked = False Then
                Me.ShowMessage("Invalid End date")
                Exit Sub
            ElseIf Me.chkAllDay.Checked = True Then
                Me.radTimePickerEnd.SelectedDate = cEmployee.TimeZoneToday
            End If
            If Me.chkHoliday.Checked = False And Me.chkAppointment.Checked = False Then
                Me.ShowMessage("Please select a type.")
                Exit Sub
            End If
            If Me.ddlCategory.SelectedItem.Text = "" Then
                Me.ShowMessage("Please select a category.")
                Exit Sub
            End If
            If wvCDate(Me.RadDatePickerEndDate.SelectedDate) < wvCDate(Me.RadDatePickerStartDate.SelectedDate) Then
                Me.ShowMessage("End date cannot be less than start date.")
                Exit Sub
            End If
            If Me.chkAllDay.Checked = False Then
                Dim ed As DateTime = Me.RadDatePickerEndDate.SelectedDate
                Dim sd As DateTime = Me.RadDatePickerStartDate.SelectedDate
                Dim et As DateTime = Me.radTimePickerEnd.SelectedDate
                Dim st As DateTime = Me.radTimePickerStart.SelectedDate
                If Convert.ToDateTime(ed.Date.ToShortDateString & " " & et.Hour.ToString() & ":" & et.Minute.ToString() & ":" & et.Second.ToString()) < Convert.ToDateTime(sd.Date.ToShortDateString & " " & st.Hour.ToString() & ":" & st.Minute.ToString() & ":" & st.Second.ToString()) Then
                    Me.ShowMessage("End time cannot be less than start time.")
                    Exit Sub
                End If
            End If
            'If Me.chkHoliday.Checked = True And oCalendar.checkHolidays(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.chkAllDay.Checked) = True Then
            '    Me.ShowMessage("Holiday already exists for this day")
            '    Exit Sub
            'End If
            Dim ThisTask As Integer = 0
            Try
                ThisTask = CType(Request.QueryString("TaskNo"), Integer)
            Catch ex As Exception
                ThisTask = 0
            End Try

            If ThisTask > 0 Then
                If Me.HasAccessToEmployee(Me.GetTaskEmpCode(ThisTask)) = False Then
                    Me.ShowMessage("Invalid Employee")
                    Exit Sub
                End If
            End If

            If oCalendar.checkAppointments(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Me.chkAllDay.Checked, Me.ddlEmps.SelectedValue, ThisTask) Then
                If Me.chkAppointment.Checked = True Then
                    Me.ShowMessage("WARNING:  Appointment conflicts with existing appointment.")
                Else
                    Me.ShowMessage("WARNING:  Holiday conflicts with existing appointments.")
                End If
            End If

            Dim standardHours As Decimal
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetStandardHours()
            Do While dr.Read
                standardHours = dr.GetDecimal(0)
            Loop
            Dim save As Boolean
            If Me.chkHoliday.Checked = True Then
                save = oCalendar.UpdateTask(Me.chkHoliday.Checked, Me.chkAppointment.Checked, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Nothing, Me.ddlCategory.SelectedValue.ToString(), "", Request.QueryString("TaskNo"), standardHours)
            Else
                save = oCalendar.UpdateTask(Me.chkHoliday.Checked, Me.chkAppointment.Checked, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, ddlEmps.SelectedValue.ToString(), Me.ddlCategory.SelectedValue.ToString(), "", Request.QueryString("TaskNo"), standardHours)
                Dim MyExport As New ExportStructure
                MyExport.UID = "A|" + Request.QueryString("TaskNo").ToString
                MyExport.Category = Me.ddlCategory.SelectedItem.ToString
                MyExport.Description = Me.txtSubject.Text
                If Me.chkAllDay.Checked = False Then
                    MyExport.StartTime = CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerStart.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Second.ToString
                    MyExport.EndTime = CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerEnd.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Second.ToString
                Else
                    MyExport.StartTime = Convert.ToDateTime(CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString & " 12:00:00 AM")
                    MyExport.EndTime = Convert.ToDateTime(CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString & " 11:59:00 pm") 'Maybe this needs to end with 59seconds but the rest of your codes doesnt. Dan
                End If
                MyExport.Title = Me.txtSubject.Text
                MyExport.Method = "PUBLISH"
                Session("ExportData") = MyExport
                'Me.CreateExport(False)
            End If
            If save = True Then
                Session("TaskCalendarSelectedDate") = Me.RadDatePickerStartDate.SelectedDate
                If Not chkHoliday.Checked = True Then
                    Me.btnExport.Visible = True
                Else
                    Me.btnExport.Visible = False
                End If
                Me.butUpdate.Visible = True
                Me.butDelete.Visible = True
                lblConfirm.Visible = True
                lblConfirm.Text = "Update Successful."

                'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Request.QueryString("TaskNo"), chkHoliday.Checked, False)
                Me.CalendarSync(Request.QueryString("TaskNo"), chkHoliday.Checked, False)

            Else
                Me.ShowMessage("Update Failed.")
            End If


            Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")

            'Dim cScript As String
            'cScript = "<script language='javascript'> opener.location.href = 'Calendar_MonthView.aspx'; </script>"
            'RegisterStartupScript("parentwindow", cScript)
            'Dim cScript2 As String
            'cScript2 = "<script>window.close();</script>"
            'RegisterStartupScript("page", cScript2)
        Catch ex As Exception
            Response.Write("Error with Updating Task: " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub timeSelect()

        starttime = Now.ToString
        endtime = Convert.ToDateTime("07:00:00 AM").ToString

        If Now < Convert.ToDateTime("07:00:00 AM") Then
            starttime = "07:00:00 AM"
            endtime = "07:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("07:00:00 AM") And Now < Convert.ToDateTime("07:30:00 AM") Then
            starttime = "07:00:00 AM"
            endtime = "07:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("07:30:00 AM") And Now < Convert.ToDateTime("08:00:00 AM") Then
            starttime = "07:30:00 AM"
            endtime = "08:00:00 AM"
        End If
        If Now >= Convert.ToDateTime("08:00:00 AM") And Now < Convert.ToDateTime("08:30:00 AM") Then
            starttime = "08:00:00 AM"
            endtime = "08:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("08:30:00 AM") And Now < Convert.ToDateTime("09:00:00 AM") Then
            starttime = "08:30:00 AM"
            endtime = "09:00:00 AM"
        End If
        If Now >= Convert.ToDateTime("09:00:00 AM") And Now < Convert.ToDateTime("09:30:00 AM") Then
            starttime = "09:00:00 AM"
            endtime = "09:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("09:30:00 AM") And Now < Convert.ToDateTime("10:00:00 AM") Then
            starttime = "09:30:00 AM"
            endtime = "10:00:00 AM"
        End If
        If Now >= Convert.ToDateTime("10:00:00 AM") And Now < Convert.ToDateTime("10:30:00 AM") Then
            starttime = "10:00:00 AM"
            endtime = "10:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("10:30:00 AM") And Now < Convert.ToDateTime("11:00:00 AM") Then
            starttime = "10:30:00 AM"
            endtime = "11:00:00 AM"
        End If
        If Now >= Convert.ToDateTime("11:00:00 AM") And Now < Convert.ToDateTime("11:30:00 AM") Then
            starttime = "11:00:00 AM"
            endtime = "11:30:00 AM"
        End If
        If Now >= Convert.ToDateTime("11:30:00 AM") And Now < Convert.ToDateTime("12:00:00 PM") Then
            starttime = "11:30:00 AM"
            endtime = "12:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("12:00:00 PM") And Now < Convert.ToDateTime("12:30:00 PM") Then
            starttime = "12:00:00 PM"
            endtime = "12:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("12:30:00 PM") And Now < Convert.ToDateTime("01:00:00 PM") Then
            starttime = "12:30:00 PM"
            endtime = "01:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("01:00:00 PM") And Now < Convert.ToDateTime("01:30:00 PM") Then
            starttime = "01:00:00 PM"
            endtime = "01:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("01:30:00 PM") And Now < Convert.ToDateTime("02:00:00 PM") Then
            starttime = "01:30:00 PM"
            endtime = "02:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("02:00:00 PM") And Now < Convert.ToDateTime("02:30:00 PM") Then
            starttime = "02:00:00 PM"
            endtime = "02:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("02:30:00 PM") And Now < Convert.ToDateTime("03:00:00 PM") Then
            starttime = "02:30:00 PM"
            endtime = "03:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("03:00:00 PM") And Now < Convert.ToDateTime("03:30:00 PM") Then
            starttime = "03:00:00 PM"
            endtime = "03:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("03:30:00 PM") And Now < Convert.ToDateTime("04:00:00 PM") Then
            starttime = "03:30:00 PM"
            endtime = "04:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("04:00:00 PM") And Now < Convert.ToDateTime("04:30:00 PM") Then
            starttime = "04:00:00 PM"
            endtime = "04:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("04:30:00 PM") And Now < Convert.ToDateTime("05:00:00 PM") Then
            starttime = "04:30:00 PM"
            endtime = "05:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("05:00:00 PM") And Now < Convert.ToDateTime("05:30:00 PM") Then
            starttime = "05:00:00 PM"
            endtime = "05:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("05:30:00 PM") And Now < Convert.ToDateTime("06:00:00 PM") Then
            starttime = "05:30:00 PM"
            endtime = "06:00:00 PM"
        End If
        If Now >= Convert.ToDateTime("06:00:00 PM") And Now < Convert.ToDateTime("06:30:00 PM") Then
            starttime = "06:00:00 PM"
            endtime = "06:30:00 PM"
        End If
        If Now >= Convert.ToDateTime("06:30:00 PM") Then
            starttime = "06:30:00 PM"
            endtime = "06:30:00 PM"
        End If

    End Sub

    Private Sub radTimePickerStart_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles radTimePickerStart.SelectedDateChanged
        If Me.radTimePickerStart.SelectedDate.HasValue = True And Me.radTimePickerEnd.SelectedDate.HasValue = True Then
            If Me.radTimePickerStart.SelectedDate.Value >= Me.radTimePickerEnd.SelectedDate.Value Then
                Me.radTimePickerEnd.SelectedDate = CType(Me.radTimePickerStart.SelectedDate, Date).AddMinutes(30.0)
            End If
        End If
    End Sub

    Private Sub chkAllDay_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllDay.CheckedChanged
        If Me.chkAllDay.Checked = True And wvCDate(Me.RadDatePickerStartDate.SelectedDate) > wvCDate(Me.RadDatePickerEndDate.SelectedDate) Then
            Me.RadDatePickerEndDate.SelectedDate = Me.RadDatePickerStartDate.SelectedDate

        End If
        If Me.chkAllDay.Checked = True Then
            Me.radTimePickerStart.SelectedDate = Convert.ToDateTime("12:00:00 AM")
            Me.radTimePickerEnd.SelectedDate = Convert.ToDateTime("11:59:00 PM")
            Me.radTimePickerEnd.Enabled = False
            Me.radTimePickerStart.Enabled = False


        Else
            Me.radTimePickerEnd.Enabled = True
            Me.radTimePickerStart.Enabled = True

        End If
    End Sub

    Private Sub addCalendarEvent()

        Dim outlookvcs As New System.Text.StringBuilder
        With outlookvcs
            .Append("BEGIN:VCALENDAR" & vbLf)
            .Append("PRODID:-//Microsoft Corporation//Outlook 11.0 MIMEDIR//EN" & vbLf)
            .Append("VERSION:1.0" & vbLf)
            .Append("BEGIN:VEVENT" & vbLf)
            '.Append("DTSTART:" & Replace(Me.RadDatePickerStartDate.SelectedDate, "/", "") & "T" & Replace(Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString(), ":", "") & "Z" & vbLf)
            '.Append("DTEND:" & Replace(Me.RadDatePickerEndDate.SelectedDate, "/", "") & "T" & Replace(Me.radTimePickerEnd.SelectedDate.Value.TimeOfDay.ToString(), ":", "") & "Z" & vbLf)
            .Append("DTSTART:" & str_outlookdate(CDate(Me.RadDatePickerStartDate.SelectedDate)) & "T" & Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString() & "Z" & vbLf)
            .Append("DTEND:" & str_outlookdate(CDate(Me.RadDatePickerEndDate.SelectedDate)) & "T" & Me.radTimePickerEnd.SelectedDate.Value.TimeOfDay.ToString() & "Z" & vbLf)
            .Append("UID:1" & vbLf)
            .Append("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" & Me.txtSubject.Text & "=0A" & vbLf)
            .Append("SUMMARY;ENCODING=QUOTED-PRINTABLE:" & Me.txtSubject.Text & vbLf)
            .Append("PRIORITY:3" & vbLf)
            .Append("END:VEVENT" & vbLf)
            .Append("END:VCALENDAR" & vbLf)
        End With
        Dim str As String = outlookvcs.ToString
        Response.Clear()
        Response.ContentType = "text/calendar"
        Response.AddHeader("content-disposition", "attachment; filename=outlook_calendar_appointment2.ics")
        Response.Write(outlookvcs)
        Response.End()

    End Sub

    Private Sub exportAppointment()
        Try
            Dim outlookvcs As New System.Text.StringBuilder
            Dim subject As String
            Dim content As String
            Dim startdate As DateTime
            Dim enddate As DateTime
            Dim startdate2 As DateTime
            Dim enddate2 As DateTime

            ' SET SUBJECT HEADER
            subject = "TESTING"

            ' SET CONTENT [use '=0D' to make outlook perform a line break]
            content = "There is some content here"

            ' SET DATES
            'startdate = New DateTime(2008, 6, 15, 12, 0, 0)
            'enddate = New DateTime(2008, 6, 15, 19, 30, 0)
            'startdate2 = New DateTime(2008, 6, 16, 12, 0, 0)
            'enddate2 = New DateTime(2008, 6, 16, 19, 30, 0)

            With outlookvcs
                .Append("BEGIN:VCALENDAR" & vbLf)
                .Append("PRODID:-//Microsoft Corporation//Outlook 11.0 MIMEDIR//EN" & vbLf)
                .Append("VERSION:1.0" & vbLf)
                .Append("BEGIN:VEVENT" & vbLf)
                .Append("DTSTART:" & str_outlookdate(CDate(Me.RadDatePickerStartDate.SelectedDate)) & "T" & Me.radTimePickerStart.SelectedDate.Value.TimeOfDay.ToString() & "Z" & vbLf)
                .Append("DTEND:" & str_outlookdate(CDate(Me.RadDatePickerEndDate.SelectedDate)) & "T" & Me.radTimePickerEnd.SelectedDate.Value.TimeOfDay.ToString() & "Z" & vbLf)
                .Append("UID:1" & vbLf)
                .Append("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" & content & "=0A" & vbLf)
                .Append("SUMMARY;ENCODING=QUOTED-PRINTABLE:" & subject & vbLf)
                .Append("PRIORITY:3" & vbLf)
                .Append("END:VEVENT" & vbLf)
                .Append("END:VCALENDAR" & vbLf)
            End With
            Dim str As String = outlookvcs.ToString
            Response.Clear()
            Response.ContentType = "text/calendar"
            Response.AddHeader("content-disposition", "attachment; filename=outlook_calendar_appointment.vcs")
            Response.Write(outlookvcs)
            Response.End()
        Catch ex As Exception

        End Try
    End Sub

    Private Function str_outlookdate(ByVal dat_date As Date) As String
        str_outlookdate = Format(dat_date, "yyyyMMdd")
    End Function

    Private Function str_outlooktime(ByVal dat_time As Date) As String
        str_outlooktime = Format(dat_time, "HHmmss")
    End Function

    Protected Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Me.CreateExport(True)
        Me.CloseThisWindowAndRefreshCaller("")
    End Sub

End Class
