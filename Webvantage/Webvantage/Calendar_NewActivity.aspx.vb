Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Public Class Calendar_NewActivity
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#Region " Variables "

    Dim JobNo As Integer
    Dim JobComp As Integer
    Dim SeqNo As Integer
    Dim starttime As String
    Dim endtime As String
    Dim calView As String = ""
    Dim FromApp As String = ""
    Public RandomClass As New Random()

    Private Client As String = "amerx"
    Private Division As String = ""
    Private Product As String = ""
    Private key As Integer = -1
    Private state As String = ""

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private currentWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private _Caller As String = ""

#End Region

#Region "  Form Event Handlers "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'If Not Me.IsPostBack And Not Me.IsCallback Then
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Views.DivisionView = Nothing
        Dim Product As AdvantageFramework.Database.Views.ProductView = Nothing

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim m As New DocumentRepository("", True)
            If m.SetRadAsyncUpload(Me.RadUploadAlertDocuments, True, Me.LabelFileSizeLimitMessage.Text) = False Then

                'Me.ShowMessage(Me.LabelFileSizeLimitMessage.Text)
                Me.LabelFileSizeLimitMessage.CssClass = "warning"

            End If

        End If
        'End If
        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent()

        calView = qs.GetValue("calView")
        FromApp = qs.GetValue("FromApp")

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller")

        End If

        If FromApp = "PS" Then
            JobNumber = qs.JobNumber
            JobComponentNbr = qs.JobComponentNumber

            If JobNumber <> 0 Then
                Me.txtJob.Text = JobNumber
            End If
            If JobComponentNbr <> 0 Then
                Me.txtComponent.Text = JobComponentNbr
            End If

            If Request.QueryString("JobNumber") IsNot Nothing And JobNumber = 0 Then
                Me.txtJob.Text = Request.QueryString("JobNumber")
            End If
            If Request.QueryString("JobComponentNbr") IsNot Nothing And JobComponentNbr = 0 Then
                Me.txtComponent.Text = Request.QueryString("JobComponentNbr")
            End If
            LoadJob()
        End If

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Request.QueryString("ClientCode") IsNot Nothing Then

                    txtClient.Text = Request.QueryString("ClientCode")

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, txtClient.Text)

                    If Client IsNot Nothing Then

                        TxtClientDesc.Text = Client.Code & " - " & Client.Name

                    End If

                End If

                If Request.QueryString("DivisionCode") IsNot Nothing Then

                    txtDivision.Text = Request.QueryString("DivisionCode")

                    Division = AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext).Where(Function(Entity) Entity.ClientCode = txtClient.Text AndAlso Entity.DivisionCode = txtDivision.Text).SingleOrDefault()

                    If Division IsNot Nothing Then

                        TxtDivisionDesc.Text = Division.DivisionCode & " - " & Division.DivisionName

                    End If

                End If

                If Request.QueryString("ProductCode") IsNot Nothing Then

                    txtProduct.Text = Request.QueryString("ProductCode")

                    Product = AdvantageFramework.Database.Procedures.ProductView.Load(DbContext).Where(Function(Entity) Entity.ClientCode = txtClient.Text AndAlso Entity.DivisionCode = txtDivision.Text AndAlso Entity.ProductCode = txtProduct.Text).SingleOrDefault()

                    If Product IsNot Nothing Then

                        TxtProductDesc.Text = Product.ProductCode & " - " & Product.ProductDescription

                    End If

                End If

            End Using

        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Calendar)

        Try
            If Request.QueryString("f") = 0 Then
                Session("CalendarNonTaskNo") = Nothing
            End If
            If Not Request.QueryString("TaskNo") Is Nothing Then
                key = Request.QueryString("TaskNo")
            ElseIf Not Session("CalendarNonTaskNo") Is Nothing Then
                key = Session("CalendarNonTaskNo")
            End If
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    If Page.IsPostBack = False Then
                        Me.Title = "Calendar Activity"
                        Me.RadTabStripActivity.Tabs(0).Selected = True
                        Me.DivContacts.Visible = False
                        Me.DivCategory.Visible = False
                        Me.PanelCDP.Visible = False
                        If Session("TaskCalendarSelectedDate") Is Nothing Then
                            Session("TaskCalendarSelectedDate") = Date.Today
                        End If
                        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
                        Dim tdate As String
                        timeSelect()
                        If Request.QueryString("thisdate") <> "" Then
                            If Request.QueryString("click") = "day" Then
                                tdate = Request.QueryString("thisdate").Substring(4, 11).Trim
                            Else
                                tdate = Request.QueryString("thisdate")
                            End If

                            If IsDate(tdate) Then
                                Me.RadDatePickerStartDate.SelectedDate = CDate(tdate)
                                Me.RadDatePickerEndDate.SelectedDate = CDate(tdate)
                                Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(tdate).ToShortDateString & " " & starttime)
                                Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(tdate).ToShortDateString & " " & endtime)
                            End If
                        Else
                            If _Caller = "Desktop_CRMCentral" Or Request.QueryString("f") = 0 Then
                                Me.RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
                                Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
                                Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(Date.Now.ToShortDateString & " " & starttime)
                                Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(Date.Now.ToShortDateString & " " & endtime)
                            Else
                                Me.RadDatePickerStartDate.SelectedDate = CDate(Session("TaskCalendarSelectedDate"))
                                Me.RadDatePickerEndDate.SelectedDate = CDate(Session("TaskCalendarSelectedDate"))
                                Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(Session("TaskCalendarSelectedDate")).ToShortDateString & " " & starttime)
                                Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(Session("TaskCalendarSelectedDate")).ToShortDateString & " " & endtime)
                            End If
                        End If
                        LoadCategories()
                        LoadFunctions()
                        LoadEmployees()
                        LoadContacts()
                        SetupLinks()
                        Dim a As New cAlerts()
                        a.LoadPrioritiesComboBox(Me.RadComboBoxPriority, True)
                        Me.radTimePickerStart.SelectedDate = Convert.ToDateTime(starttime)
                        Me.radTimePickerEnd.SelectedDate = Convert.ToDateTime(endtime)
                        Me.RblAvailableEmployeesFilter.SelectedValue = "none"
                        If key = -1 Then
                            Me.RadToolBarButtonSave.Visible = True
                            Me.RadToolBarButtonUpdate.Visible = False
                            Me.RadToolBarButtonAddTime.Visible = False
                        Else
                            Me.RadToolBarButtonSave.Visible = False
                            Me.RadToolBarButtonUpdate.Visible = True
                            Me.RadToolBarButtonAddTime.Visible = True
                            LoadActivity()
                        End If

                        SetSecurity()
                        FillExport()
                        'If Not Request.QueryString("state") Is Nothing Then
                        '    If Request.QueryString("state") = "occurrence" Then
                        Me.RadTabStripActivity.Tabs(3).Visible = False
                        Me.RadPageViewRecurrence.Visible = False
                        '        Me.RadToolBarButtonEditSeries.Visible = True
                        '    Else
                        Me.RadToolBarButtonEditSeries.Visible = False
                        '    End If
                        'Else
                        '    Me.RadToolBarButtonEditSeries.Visible = False
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try

    End Sub

#End Region

#Region "  Data "

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

            Me.ddlCategory.DataSource = oDropDowns.GetTimeCategories
            Me.ddlCategory.DataTextField = "DESCRIPTION"
            Me.ddlCategory.DataValueField = "CATEGORY"
            Me.ddlCategory.DataBind()
            Me.ddlCategory.Items.Insert(0, none)
            Me.ddlCategory.Items.Add(other)

        Catch ex As Exception
            Response.Write("Error ddcategory!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadFunctions()
        Try
            Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
            Dim i As Integer = 0
            Dim none As New Telerik.Web.UI.RadComboBoxItem
            none.Text = ""
            none.Value = ""

            Me.ddlFunction.DataSource = oDropDowns.GetFunctionsByUserID(Session("ConnString"))
            Me.ddlFunction.DataTextField = "Description"
            Me.ddlFunction.DataValueField = "Code"
            Me.ddlFunction.DataBind()
            Me.ddlFunction.Items.Insert(0, none)

        Catch ex As Exception
            Response.Write("Error ddcategory!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadEmployees()
        Try
            Me.RadListBoxEmps_AvailableEmps.Items.Clear()
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim dr As SqlClient.SqlDataReader
            Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                Case "role"
                    dr = oCalendar.GetNonTaskAvailableEmps(True, "", Me.DropAvailableEmployeesFilter.SelectedValue, "", key, Session("UserCode"))
                Case "alert_group"
                    dr = oCalendar.GetNonTaskAvailableEmps(True, "", "", Me.DropAvailableEmployeesFilter.SelectedValue, key, Session("UserCode"))
                Case "none"
                    If Not Me.IsPostBack And Not Me.IsCallback Then
                        'don't load anything?
                    Else 'it is post/call back
                        dr = oCalendar.GetNonTaskAvailableEmps(True, "", "", "", key, Session("UserCode"))
                    End If
                Case Else
                    dr = oCalendar.GetNonTaskAvailableEmps(True, "", "", "", key, Session("UserCode"))
            End Select
            Me.RadListBoxEmps_AvailableEmps.DataSource = dr
            Me.RadListBoxEmps_AvailableEmps.DataTextField = "FML"
            Me.RadListBoxEmps_AvailableEmps.DataValueField = "EMAIL"
            Me.RadListBoxEmps_AvailableEmps.DataBind()

            Dim rlb As Telerik.Web.UI.RadListBoxItem
            For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_AvailableEmps.Items
                Dim emp() As String = raditem.Value.Split("|")
                If emp(0) = Session("EmpCode") Then
                    rlb = raditem
                End If
            Next
            If Not rlb Is Nothing And key <= 0 Then
                Me.RadListBoxEmps_EmpsInActivity.Items.Clear()
                Me.RadListBoxEmps_EmpsInActivity.Items.Add(rlb)
            Else
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)
                End Using
                rlb = New Telerik.Web.UI.RadListBoxItem(_Session.EmployeeName, employee.Code & "|" & employee.Email)
                Me.RadListBoxEmps_EmpsInActivity.Items.Clear()
                Me.RadListBoxEmps_EmpsInActivity.Items.Add(rlb)
            End If
        Catch ex As Exception
            Response.Write("Error RadListBoxEmps_AvailableEmps!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub LoadContacts()
        Try
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            If Request.QueryString("From") = "jj" Then
                Me.RadGridContacts.DataSource = oDD.GetCDP_ProductContact(Client, Division, Product, "jj")
            Else
                If Division = "" And Product = "" Then
                    Me.RadGridContacts.DataSource = oDD.GetCDP_ClientContact(Client)
                Else
                    Me.RadGridContacts.DataSource = oDD.GetCDP_ProductContactOnly(Client, Division, Product, "")
                End If
            End If
            Me.RadGridContacts.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetupLinks()
        Try
            Me.HlClient.Attributes.Add("onclick", "ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID &
                                      "');ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=calactivity&control=" &
                                      Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." &
                                      Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." &
                                      Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")

            Me.HlDivision.Attributes.Add("onclick", "ClearTB('" & Me.txtProduct.ClientID & "');ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=calactivity&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.HlProduct.Attributes.Add("onclick", "ClearTB('" & Me.txtJob.ClientID & "');ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=calactivity&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Me.HlJob.Attributes.Add("onclick", "ClearTB('" & Me.txtComponent.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=calactivity&type=job&Office=&SalesClass=&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=calactivity&type=jobcompjj&Office=&SalesClass=&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.HlContact.Attributes.Add("onclick", "OpenRadWindowLookup('poplookup_contact.aspx?form=estimate&control=" & Me.TextBoxContact.ClientID & "&type=contacts&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            'Me.hlTask.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=calactivity&type=task&j=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jc=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")

        Catch ex As Exception

        End Try
    End Sub

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

            Me.RadListBoxEmps_AvailableEmps.Enabled = False
            Me.RadListBoxEmps_EmpsInActivity.Enabled = False

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

            Me.RadComboBoxType.Items.Remove(5)

        End If

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
            MyExport.Category = Me.ddlCategory.SelectedItem.Text
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
            .Append("DESCRIPTION;ENCODING=QUOTED-PRINTABLE:" & "" & "=0A" & vbLf)
            .Append("SUMMARY;ENCODING=QUOTED-PRINTABLE:" & "" & vbLf)
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

    Private Sub BindDropAvailableEmployeesFilter()
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            With Me.DropAvailableEmployeesFilter
                Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                    Case "role"
                        .DataSource = d.GetRoles()
                        .DataTextField = "Description"
                        .DataValueField = "Code"
                        .DataBind()
                        .Enabled = True
                    Case "alert_group"
                        .DataSource = d.GetEmailAlertGroups()
                        .DataTextField = "Description"
                        .DataValueField = "Code"
                        .DataBind()
                        .Enabled = True
                    Case "none"
                        .Items.Clear()
                        .Enabled = False
                End Select
            End With
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarActivity_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarActivity.ButtonClick
        Try
            'Objects
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim SyncWithOutlook As Boolean = False
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Select Case e.Item.Value
                Case "Save"
                    key = Me.saveActivity()
                    If key <> -1 And key <> 0 Then
                        Me.LoadActivity()
                        If Me.RadComboBoxType.SelectedValue = "C" Or Me.RadComboBoxType.SelectedValue = "TD" Or Me.RadComboBoxType.SelectedValue = "M" Or Me.RadComboBoxType.SelectedValue = "EL" Then
                            SendAlerts()
                        End If
                        Me.RadToolBarButtonSave.Visible = False
                        Me.RadToolBarButtonUpdate.Visible = True

                        If _Caller = "" Then

                            If Request.QueryString("calView") IsNot Nothing Then
                                Session("PMD_Calendar_View") = Request.QueryString("calView")
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx?calView=" & Request.QueryString("calView"), True)
                            ElseIf calView <> "" Then
                                Session("PMD_Calendar_View") = Request.QueryString("calView")
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx?calView=" & calView, True)
                            Else
                                Session("PMD_Calendar_View") = Nothing
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
                            End If

                        Else

                            If _Caller = "Desktop_CRMCentral" Or _Caller = "Maintenance_ActivitySummary" Then

                                Webvantage.Desktop_CRMCentral.SetGridSelectVariables(Request.QueryString("ClientCode"), Request.QueryString("DivisionCode"), Request.QueryString("ProductCode"))

                            End If

                            Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

                        End If

                    End If
                Case "Update"
                    'Me.updateActivity()
                    If updateActivity() = True Then
                        Me.UpdateAlert()

                        If _Caller = "" Then

                            If Request.QueryString("calView") IsNot Nothing Then
                                Session("PMD_Calendar_View") = Request.QueryString("calView")
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx?calView=" & Request.QueryString("calView"), True)
                            ElseIf calView <> "" Then
                                Session("PMD_Calendar_View") = Request.QueryString("calView")
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx?calView=" & calView, True)
                            Else
                                Session("PMD_Calendar_View") = Nothing
                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")
                            End If

                        Else

                            Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

                        End If

                    End If
                Case "Export"
                    Me.CreateExport(True)
                    Me.CloseThisWindowAndRefreshCaller("")
                Case "Delete"
                    Try
                        Dim save As Boolean

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, key)

                            save = oCalendar.DeleteTask(key)
                            oCalendar.DeleteTaskEmps(key)
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

                            If _Caller = "" Then

                                Me.CloseThisWindowAndRefreshCaller("Calendar_MonthView.aspx")

                            Else

                                Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

                            End If

                        End Using

                    Catch ex As Exception
                        Response.Write("Error with Deleting Task: " & ex.Message.ToString())
                    End Try
                Case "Alert"
                    updateActivity()
                    SendAlerts()
                Case "EditSeries"
                    Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, key)
                        If Not task.RecurrenceParent Is Nothing Then
                            key = task.RecurrenceParent
                        End If
                        ' Me.RadTabStripActivity.Tabs(3).Visible = True
                        'Me.RadPageViewRecurrence.Visible = True
                        LoadActivity()
                        state = "master"
                        Me.RadToolBarButtonEditSeries.Visible = False
                    End Using
                Case "AddTime"
                    Try
                        Dim qs As New AdvantageFramework.Web.QueryString()
                        Dim HasJobNumber As Boolean = False
                        Dim HasJobComponentNumber As Boolean = False
                        'If Me.txtJob.Text <> "" And Me.txtComponent.Text <> "" Then
                        With qs

                            '.Page = "Timesheet_CommentsView.aspx"
                            .Page = "Employee/Timesheet/Entry"
                            .Add("Type", "New")
                            .Add("caller", "Calendar_NewActivity")
                            .Add("single", "1")
                            .Add("Seq", key)


                            .StartDate = Me.RadDatePickerStartDate.SelectedDate


                            If IsNumeric(Me.txtJob.Text) = True Then

                                .JobNumber = Me.txtJob.Text
                                HasJobNumber = True

                                If IsNumeric(Me.txtComponent.Text) = True Then

                                    .JobComponentNumber = Me.txtComponent.Text
                                    HasJobComponentNumber = True

                                Else

                                    .JobComponentNumber = 0

                                End If

                            Else

                                .JobNumber = 0
                                .JobComponentNumber = 0

                            End If

                            Try

                                If HasJobNumber = True AndAlso HasJobComponentNumber = True Then

                                    If String.IsNullOrWhiteSpace(Me.ddlFunction.SelectedValue) = False Then

                                        .FunctionCode = Me.ddlFunction.SelectedValue

                                    End If

                                Else

                                    If String.IsNullOrWhiteSpace(Me.ddlCategory.SelectedValue) = False AndAlso Me.ddlCategory.SelectedValue <> "no" Then

                                        .FunctionCode = Me.ddlCategory.SelectedValue

                                    End If

                                End If

                            Catch ex As Exception
                            End Try

                            .ClientCode = Me.txtClient.Text
                            .DivisionCode = Me.txtDivision.Text
                            .ProductCode = Me.txtProduct.Text

                        End With

                        If HasJobNumber = True AndAlso HasJobComponentNumber = True Then

                            Me.OpenWindow("Add Time", qs.ToString(True), 600, 600)

                        Else

                            Me.OpenWindow("Add Time", qs.ToString(True), 570, 680)

                        End If

                    Catch ex As Exception
                    End Try
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub radTimePickerStart_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles radTimePickerStart.SelectedDateChanged
        Try
            If Me.radTimePickerStart.SelectedDate.HasValue = True And Me.radTimePickerEnd.SelectedDate.HasValue = True Then
                If Me.radTimePickerStart.SelectedTime.Value >= Me.radTimePickerEnd.SelectedTime.Value Then
                    Me.radTimePickerEnd.SelectedDate = CType(Me.radTimePickerStart.SelectedDate, Date).AddMinutes(30.0)
                End If
            End If
            Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString & " " & CDate(Me.radTimePickerStart.SelectedDate).ToShortTimeString)
            Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString & " " & CDate(Me.radTimePickerEnd.SelectedDate).ToShortTimeString)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub radTimePickerEnd_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles radTimePickerEnd.SelectedDateChanged
        Try
            If Me.radTimePickerStart.SelectedDate.HasValue = True And Me.radTimePickerEnd.SelectedDate.HasValue = True Then
                If Me.radTimePickerStart.SelectedTime.Value >= Me.radTimePickerEnd.SelectedTime.Value Then
                    Me.radTimePickerStart.SelectedDate = CType(Me.radTimePickerEnd.SelectedDate, Date).AddMinutes(-30.0)
                End If
            End If
            Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString & " " & CDate(Me.radTimePickerStart.SelectedDate).ToShortTimeString)
            Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString & " " & CDate(Me.radTimePickerEnd.SelectedDate).ToShortTimeString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlCategory_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlCategory.SelectedIndexChanged
        Try
            If ddlCategory.SelectedValue <> "no" Then
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""
                Me.ddlFunction.SelectedValue = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxType_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxType.SelectedIndexChanged
        Try
            If RadComboBoxType.SelectedValue = "H" Then
                Me.chkAllDay.Checked = True
                Me.DivEmployees.Visible = False
                Me.DivContacts.Visible = False
                Me.PanelCDP.Visible = False
                Me.DivAttachments.Visible = False
                'Me.RadToolBarButtonAlert.Enabled = False
            ElseIf RadComboBoxType.SelectedValue = "A" Then
                Me.DivCategory.Visible = True
                Me.PanelCDP.Visible = False
                Me.DivEmployees.Visible = True
                Me.DivAttachments.Visible = False
            Else
                Me.DivCategory.Visible = False
                Me.PanelCDP.Visible = True
                Me.DivEmployees.Visible = True
                Me.DivAttachments.Visible = True
                'Me.RadToolBarButtonAlert.Enabled = True
            End If
        Catch ex As Exception

        End Try
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

    Private Sub DropAvailableEmployeesFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropAvailableEmployeesFilter.SelectedIndexChanged
        Try
            Dim v As New cAppVars(cAppVars.Application.CALENDAR_NEW_ACTIVITY)
            v.getAllAppVars()
            If Me.RblAvailableEmployeesFilter.SelectedValue = "role" Then
                v.setAppVar("EMP_FILTER_ROLE_CODE", Me.DropAvailableEmployeesFilter.SelectedValue, "String")
            ElseIf Me.RblAvailableEmployeesFilter.SelectedValue = "alert_group" Then
                v.setAppVar("EMP_FILTER_EML_GRP_CODE", Me.DropAvailableEmployeesFilter.SelectedValue, "String")
            End If
            v.SaveAllAppVars()
            LoadEmployees()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        Try
            Me.txtClient.Text = ""
            Me.TxtClientDesc.Text = ""
            Me.txtDivision.Text = ""
            Me.TxtDivisionDesc.Text = ""
            Me.txtProduct.Text = ""
            Me.TxtProductDesc.Text = ""
            Me.txtJob.Text = ""
            Me.TxtJobDescription.Text = ""
            Me.txtComponent.Text = ""
            Me.TxtJobCompDescription.Text = ""
            Me.TextBoxContact.Text = ""
            Me.TxtContactDescription.Text = ""

            Me.ddlFunction.SelectedValue = ""
            Me.ddlCategory.SelectedValue = "no"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddlFunction_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlFunction.SelectedIndexChanged
        Try
            If ddlFunction.SelectedValue <> "" Then
                Me.ddlCategory.SelectedValue = "no"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Try
            Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString & " " & Me.radTimePickerStart.SelectedTime.ToString)
            If RadDatePickerStartDate.SelectedDate > RadDatePickerEndDate.SelectedDate Then
                Me.RadDatePickerEndDate.SelectedDate = Me.RadDatePickerStartDate.SelectedDate
                Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString & " " & Me.radTimePickerEnd.SelectedTime.ToString)
            End If
            If RadDatePickerStartDate.SelectedDate <> RadDatePickerEndDate.SelectedDate Then
                Me.chkAllDay.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Try
            Me.RadSchedulerRecurrenceEditor1.EndDate = CDate(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString & " " & Me.radTimePickerEnd.SelectedTime.ToString)
            If RadDatePickerStartDate.SelectedDate > RadDatePickerEndDate.SelectedDate Then
                Me.RadDatePickerStartDate.SelectedDate = Me.RadDatePickerEndDate.SelectedDate
                Me.RadSchedulerRecurrenceEditor1.StartDate = CDate(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString & " " & Me.radTimePickerStart.SelectedTime.ToString)
            End If
            If RadDatePickerStartDate.SelectedDate <> RadDatePickerEndDate.SelectedDate Then
                Me.chkAllDay.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RblAvailableEmployeesFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblAvailableEmployeesFilter.SelectedIndexChanged
        Try
            Dim v As New cAppVars(cAppVars.Application.CALENDAR_NEW_ACTIVITY)
            v.getAllAppVars()
            v.setAppVar("EMP_FILTER", Me.RblAvailableEmployeesFilter.SelectedValue, "String")
            v.SaveAllAppVars()

            Me.BindDropAvailableEmployeesFilter()
            Try
                Dim s As String = ""
                If Me.RblAvailableEmployeesFilter.SelectedIndex > -1 Then
                    Me.BindDropAvailableEmployeesFilter()
                    Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                        Case "role"
                            s = v.getAppVar("EMP_FILTER_ROLE_CODE")
                        Case "alert_group"
                            s = v.getAppVar("EMP_FILTER_EML_GRP_CODE")
                    End Select
                    If s <> "" And Me.DropAvailableEmployeesFilter.Items.Count > 0 Then
                        MiscFN.RadComboBoxSetIndex(Me.DropAvailableEmployeesFilter, s, False)
                    End If
                End If
            Catch ex As Exception
            End Try
            LoadEmployees()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAttachments_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAttachments.NeedDataSource
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Dim Alerts As AdvantageFramework.Database.Entities.Alert = Nothing
                Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByNonTaskID(DbContext, key)
                Dim oAlerts As cAlerts = New cAlerts(CStr(Session("ConnString")))
                Me.RadGridAttachments.DataSource = oAlerts.GetAlertAttachments(Alerts.ID)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridAttachments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAttachments.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim SizeCell As Integer = 4
            Dim Filename As String = Nothing
            Dim Description As String = Nothing

            If Not IsDBNull(e.Item.DataItem("FILENAME")) Then

                Filename = e.Item.DataItem("FILENAME")

            End If

            If Not IsDBNull(e.Item.DataItem("DESCRIPTION")) Then

                Description = e.Item.DataItem("DESCRIPTION")

            End If
            AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton),
                                                                                   DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                   Nothing, Nothing,
                                                                                   Nothing, Nothing,
                                                                                   DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                   Nothing, Nothing, "",
                                                                                   e.Item.Cells(SizeCell).Text,
                                                                                   e.Item.DataItem("DOCUMENT_ID"), e.Item.DataItem("MIME_TYPE"), Filename, e.Item.DataItem("REPOSITORY_FILENAME"), Description, e.Item.DataItem("FILE_SIZE"),
                                                                                   "", "", 0)

            Dim Alerts As AdvantageFramework.Database.Entities.Alert = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByNonTaskID(DbContext, key)
            End Using

            Dim Alert As New Alert(Session("ConnString"))
            Alert.LoadByPrimaryKey(Alerts.ID)
            e.Item.Attributes.Add("DocumentId", e.Item.DataItem("DOCUMENT_ID"))

            Dim by As String = e.Item.Cells(5).Text.Trim
            Dim cp As String = Alert.s_CP_ALERT
            Try
                If by = "&nbsp;" Then
                    Dim oAlerts As New cAlerts(Session("ConnString"))
                    Dim str As String = oAlerts.GetAlertClientContact(CInt(e.Item.Cells(7).Text))
                    e.Item.Cells(5).Text = str
                End If
            Catch ex As Exception
                'Me.LblMSG.Text = ex.Message.Trim
            End Try

        End If
    End Sub

    Private Sub RadGridAttachments_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAttachments.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridAttachments.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName
            Case "Download"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)
            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, CurrentGridDataItem.GetDataKeyValue("ATTACHMENT_ID"))

                        If AlertAttachment IsNot Nothing Then

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                            If Document IsNot Nothing Then

                                Dim DeleteFromRepository As Boolean = False

                                Dim DocumentRepository As DocumentRepository = Nothing

                                DocumentRepository = New DocumentRepository(Session("ConnString"))

                                If Document.FileSystemFileName.StartsWith("d_") Then

                                    DeleteFromRepository = True

                                End If

                                If DeleteFromRepository = True Then

                                    If DocumentRepository.DeleteDocument(Document.ID, Document.FileSystemFileName) Then

                                        If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                            For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                                AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                            Next

                                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                                        End If

                                    End If

                                Else

                                    If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                        For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                            AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                        Next

                                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                                    End If

                                End If

                            End If

                        End If

                    End Using

                    Me.RadGridAttachments.Rebind()

                End If


        End Select

    End Sub

    Private Sub ImageButtonContacts_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonContacts.Click
        Try
            Me.OpenWindow("Contacts", "popContacts.aspx?From=jj&client=" & Me.txtClient.Text & "&division=" & Me.txtDivision.Text & "&product=" & Me.txtProduct.Text & "', '400','1200'", 1200, 400)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtJob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJob.TextChanged
        Try
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If IsNumeric(Me.txtJob.Text) = True Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.txtJob.Text)
                    If Me.txtClient.Text = "" Then
                        Me.txtClient.Text = jobdata.ClientCode
                    End If
                    If Me.txtDivision.Text = "" Then
                        Me.txtDivision.Text = jobdata.DivisionCode
                    End If
                    If Me.txtProduct.Text = "" Then
                        Me.txtProduct.Text = jobdata.ProductCode
                    End If
                    If Me.TxtClientDesc.Text = "" Then
                        Me.TxtClientDesc.Text = jobdata.Client.Name
                    End If
                    If Me.TxtDivisionDesc.Text = "" Then
                        Me.TxtDivisionDesc.Text = jobdata.Division.Name
                    End If
                    If Me.TxtProductDesc.Text = "" Then
                        Me.TxtProductDesc.Text = jobdata.Product.Name
                    End If
                End Using
                Me.SetupLinks()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtComponent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComponent.TextChanged
        Try
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If IsNumeric(Me.txtJob.Text) = True And IsNumeric(Me.txtComponent.Text) = True Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.txtJob.Text)
                    If Me.txtClient.Text = "" Then
                        Me.txtClient.Text = jobdata.ClientCode
                    End If
                    If Me.txtDivision.Text = "" Then
                        Me.txtDivision.Text = jobdata.DivisionCode
                    End If
                    If Me.txtProduct.Text = "" Then
                        Me.txtProduct.Text = jobdata.ProductCode
                    End If
                    If Me.TxtClientDesc.Text = "" Then
                        Me.TxtClientDesc.Text = jobdata.Client.Name
                    End If
                    If Me.TxtDivisionDesc.Text = "" Then
                        Me.TxtDivisionDesc.Text = jobdata.Division.Name
                    End If
                    If Me.TxtProductDesc.Text = "" Then
                        Me.TxtProductDesc.Text = jobdata.Product.Name
                    End If
                End Using
                Me.SetupLinks()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonRefreshLinkDocumentsListBox_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshLinkDocumentsListBox.Click

        Me.LoadLinkableDocuments()

    End Sub

#End Region

#Region "  Functions "

    Private Sub LoadActivity()

        'objects
        Dim AllowUserToViewOtherEmployees As Boolean = False
        Dim UserGroupSettingValues As Generic.List(Of Object) = Nothing

        Try
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim ds As DataSet
            ds = oCalendar.GetNonTaskDataDS(key, HttpContext.Current.Session("UserCode"))

            Dim type As String

            If ds.Tables(0).Rows.Count > 0 Then
                Me.RadComboBoxType.SelectedValue = ds.Tables(0).Rows(0)("TYPE")
                If Me.RadComboBoxType.SelectedValue = "H" Then
                    Me.chkAllDay.Checked = True
                    Me.DivEmployees.Visible = False
                    Me.DivContacts.Visible = False
                    Me.PanelCDP.Visible = False
                    'Me.RadToolBarButtonAlert.Enabled = False
                ElseIf RadComboBoxType.SelectedValue = "A" Then
                    Me.DivCategory.Visible = True
                    Me.PanelCDP.Visible = False
                    Me.DivEmployees.Visible = True
                    Me.DivAttachments.Visible = False
                Else
                    Me.DivCategory.Visible = False
                    Me.PanelCDP.Visible = True
                    Me.DivEmployees.Visible = True
                    Me.DivAttachments.Visible = True
                    'Me.RadToolBarButtonAlert.Enabled = True
                End If
                If ds.Tables(0).Rows(0)("ALL_DAY") = 1 Then
                    Me.chkAllDay.Checked = True
                Else
                    Me.chkAllDay.Checked = False
                    Me.radTimePickerStart.SelectedDate = ds.Tables(0).Rows(0)("START_TIME")
                    Me.radTimePickerEnd.SelectedDate = ds.Tables(0).Rows(0)("END_TIME")
                End If
                Me.RadDatePickerStartDate.SelectedDate = ds.Tables(0).Rows(0)("START_DATE").Date
                Me.RadDatePickerEndDate.SelectedDate = ds.Tables(0).Rows(0)("END_DATE").Date
                Me.ddlCategory.SelectedValue = ds.Tables(0).Rows(0)("CATEGORY").Trim
                If IsDBNull(ds.Tables(0).Rows(0)("FNC_CODE")) = False Then
                    Me.ddlFunction.SelectedValue = ds.Tables(0).Rows(0)("FNC_CODE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("CL_CODE")) = False Then
                    Me.txtClient.Text = ds.Tables(0).Rows(0)("CL_CODE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("DIV_CODE")) = False Then
                    Me.txtDivision.Text = ds.Tables(0).Rows(0)("DIV_CODE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("PRD_CODE")) = False Then
                    Me.txtProduct.Text = ds.Tables(0).Rows(0)("PRD_CODE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("JOB_NUMBER")) = False Then
                    Me.txtJob.Text = ds.Tables(0).Rows(0)("JOB_NUMBER")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.txtComponent.Text = ds.Tables(0).Rows(0)("JOB_COMPONENT_NBR")
                End If
                'If IsDBNull(ds.Tables(0).Rows(0)("TASK_CODE")) = False Then
                '    Me.txtTask.Text = ds.Tables(0).Rows(0)("TASK_CODE")
                'End If
                If IsDBNull(ds.Tables(0).Rows(0)("NON_TASK_DESC")) = False Then
                    Me.txtSubject.Text = ds.Tables(0).Rows(0)("NON_TASK_DESC")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("REMINDER")) = False Then
                    Me.ReminderDropDown.SelectedValue = ds.Tables(0).Rows(0)("REMINDER")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("RECURRENCE")) = False Then
                    Me.RadSchedulerRecurrenceEditor1.RecurrenceRuleText = ds.Tables(0).Rows(0)("RECURRENCE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("PRIORITY")) = False Then
                    Me.RadComboBoxPriority.SelectedValue = ds.Tables(0).Rows(0)("PRIORITY")
                End If
                'If IsDBNull(ds.Tables(0).Rows(0)("NON_EMP_TASK_DESC")) = False Then
                '    Me.RadEditorDescription.Content = ds.Tables(0).Rows(0)("NON_EMP_TASK_DESC")
                'End If
                If IsDBNull(ds.Tables(0).Rows(0)("CL_NAME")) = False Then
                    Me.TxtClientDesc.Text = ds.Tables(0).Rows(0)("CL_NAME")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("DIV_NAME")) = False Then
                    Me.TxtDivisionDesc.Text = ds.Tables(0).Rows(0)("DIV_NAME")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("PRD_DESCRIPTION")) = False Then
                    Me.TxtProductDesc.Text = ds.Tables(0).Rows(0)("PRD_DESCRIPTION")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("JOB_DESC")) = False Then
                    Me.TxtJobDescription.Text = ds.Tables(0).Rows(0)("JOB_DESC")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.TxtJobCompDescription.Text = ds.Tables(0).Rows(0)("JOB_COMP_DESC")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("CDP_CONTACT_ID")) = False Then
                    Me.HfContactCodeID.Value = ds.Tables(0).Rows(0)("CDP_CONTACT_ID")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("CONT_CODE")) = False Then
                    Me.TextBoxContact.Text = ds.Tables(0).Rows(0)("CONT_CODE")
                End If
                If IsDBNull(ds.Tables(0).Rows(0)("CONT_FML")) = False Then
                    Me.TxtContactDescription.Text = ds.Tables(0).Rows(0)("CONT_FML")
                End If

                ' Do we have HTML to show? If so, show it, if Not, shot the plain text.
                Dim BodyText As String = ""
                Dim BodyHTML As String = ""
                Try
                    If IsDBNull(ds.Tables(0).Rows(0)("NON_EMP_TASK_DESC")) = False Then
                        BodyText = ds.Tables(0).Rows(0)("NON_EMP_TASK_DESC").ToString()
                    End If
                Catch ex As Exception
                    BodyText = ""
                End Try
                Try
                    If IsDBNull(ds.Tables(0).Rows(0)("NON_EMP_TASK_HTML")) = False Then
                        BodyHTML = ds.Tables(0).Rows(0)("NON_EMP_TASK_HTML").ToString()
                    End If
                Catch ex As Exception
                    BodyHTML = ""
                End Try

                If BodyHTML = "" Then
                    BodyText = BodyText.Replace(Environment.NewLine, "<br />")
                    Me.RadEditorDescription.Content = BodyText
                Else
                    Me.RadEditorDescription.Html = BodyHTML
                End If
            End If

            If ds.Tables(1).Rows.Count > 0 Then
                Me.RadListBoxEmps_EmpsInActivity.DataSource = ds.Tables(1)
                Me.RadListBoxEmps_EmpsInActivity.DataTextField = "EMP_NAME"
                Me.RadListBoxEmps_EmpsInActivity.DataValueField = "EMP_EMAIL"
                Me.RadListBoxEmps_EmpsInActivity.DataBind()
            End If

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

            End If
            type = ""
            'If Me.HasAccessToEmployee(Me.ddlEmps.SelectedValue) = False Then

            'End If
        Catch ex As Exception
            Response.Write("Error with Loading Task: " & ex.Message.ToString())
        End Try
    End Sub

    Private Function saveActivity()

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim empcount As Integer
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

        If Me.txtSubject.Text = "" Then
            Me.ShowMessage("Subject is required.")
            Exit Function
        End If

        If Me.RadComboBoxType.SelectedValue = "A" Then
            If Me.RadListBoxEmps_EmpsInActivity.Items.Count > 1 Then
                Me.ShowMessage("Please select only one employee for appointment.")
                Exit Function
            End If
        End If

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
        If Me.RadComboBoxType.SelectedValue = "" Then
            Me.ShowMessage("Please select a type.")
            Exit Function
        End If
        If Me.RadComboBoxType.SelectedValue = "A" Then
            If Me.ddlCategory.SelectedItem.Value = "no" Then
                Me.ShowMessage("Please select a category.")
                Exit Function
            End If
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
        If Me.RadComboBoxType.SelectedValue = "H" And oCalendar.checkHolidays(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.chkAllDay.Checked) = True Then
            Me.ShowMessage("Holiday already exists for this day")
            Exit Function
        End If
        If oCalendar.checkAppointments(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Me.chkAllDay.Checked = True, "") Then
            If Me.RadComboBoxType.SelectedValue = "A" Then
                Me.ShowMessage("WARNING:  Appointment conflicts with existing appointment.")
            Else
                Me.ShowMessage("WARNING:  Holiday conflicts with existing appointments.")
            End If

        End If

        If Me.txtClient.Text <> "" Then
            If Me.txtDivision.Text = "" Then
                Me.ShowMessage("Please select a Division.")
                Exit Function
            End If
            If Me.txtProduct.Text = "" Then
                Me.ShowMessage("Please select a Product.")
                Exit Function
            End If
        End If
        If Me.txtClient.Text <> "" Then
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                Me.ShowMessage("Client invalid")
                Exit Function
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                Me.ShowMessage("Access to this Client is denied")
                Exit Function
            End If
        End If
        If Me.txtDivision.Text <> "" Then
            If Me.txtClient.Text = "" Then
                Me.ShowMessage("Please select a Client.")
                Exit Function
            End If
            If Me.txtProduct.Text = "" Then
                Me.ShowMessage("Please select a Product.")
                Exit Function
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                Me.ShowMessage("Client, Division invalid")
                Exit Function
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                Me.ShowMessage("Access to this Division is denied")
                Exit Function
            End If
        End If
        If Me.txtProduct.Text <> "" Then
            If Me.txtClient.Text = "" Then
                Me.ShowMessage("Please select a Client.")
                Exit Function
            End If
            If Me.txtDivision.Text = "" Then
                Me.ShowMessage("Please select a Division.")
                Exit Function
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                Me.ShowMessage("Invalid Client, Division, Product")
                Exit Function
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                Me.ShowMessage("Access to this product is denied")
                Exit Function
            End If
        End If
        If Me.txtJob.Text.Trim <> "" Then
            If IsNumeric(Me.txtJob.Text.Trim) = False Then
                Me.ShowMessage("Job invalid")
                Return False
            End If
            If Me.txtComponent.Text = "" Then
                Me.ShowMessage("Please select a Component.")
                Return False
            End If
            If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                Me.ShowMessage("Job does not exist")
                Return False
            End If
            If myVal.ValidateJobIsViewable(Session("Usercode"), Me.txtJob.Text.Trim) = False Then
                Me.ShowMessage("Access to this Job is denied")
                Return False
            End If
        End If
        If Me.txtComponent.Text <> "" Then
            If IsNumeric(Me.txtComponent.Text.Trim) = False Then
                Me.ShowMessage("Component invalid")
                Return False
            End If
            If Me.txtJob.Text = "" Then
                Me.ShowMessage("Please select a Job.")
                Return False
            End If
            If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                Me.ShowMessage("Component invalid")
                Return False
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtComponent.Text.Trim) = False Then
                Me.ShowMessage("Access to this job/component is denied")
                Return False
            End If
        End If

        Dim cdpid As Integer = 0
        Dim job As Integer = 0
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        If Me.txtJob.Text <> "" Then
            job = CInt(Me.txtJob.Text)
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, job)
                If Me.txtClient.Text = "" Then
                    Me.txtClient.Text = jobdata.ClientCode
                End If
                If Me.txtDivision.Text = "" Then
                    Me.txtDivision.Text = jobdata.DivisionCode
                End If
                If Me.txtProduct.Text = "" Then
                    Me.txtProduct.Text = jobdata.ProductCode
                End If
            End Using
        End If

        If Me.TextBoxContact.Text <> "" Then
            cdpid = oEstimating.GetContactCodeID(Me.TextBoxContact.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
            If cdpid.ToString <> Me.HfContactCodeID.Value Then
                Me.HfContactCodeID.Value = cdpid.ToString
                If myVal.ValidateCDPContactEst(Me.HfContactCodeID.Value, Session("UserCode")) = False Then
                    Me.ShowMessage("Please enter a valid contact.")
                    Return False
                End If
            End If
        Else
            Me.HfContactCodeID.Value = ""
        End If

        If RadListBoxEmps_EmpsInActivity.Items.Count = 0 Then
            Me.ShowMessage("Please Assign Employee to this activity.")
            Return False
        End If

        If Me.HfContactCodeID.Value <> "" Then
            cdpid = CInt(Me.HfContactCodeID.Value)
        End If

        Try

            Dim Employee As String = ""
            Dim standardHours As Decimal
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetStandardHours()
            Do While dr.Read
                standardHours = dr.GetDecimal(0)
            Loop

            Employee = RadListBoxEmps_EmpsInActivity.Items(0).Value.Split("|").First

            Dim comp As Integer = 0
            Dim remind As String = ""
            Dim oCount As Integer = 0
            Dim duration As Integer = 0
            Dim time As Decimal = 0
            Dim master As Integer = -1

            If Me.txtComponent.Text <> "" Then
                comp = CInt(Me.txtComponent.Text)
            End If

            If Me.RadComboBoxType.SelectedValue = "C" Or Me.RadComboBoxType.SelectedValue = "M" Or Me.RadComboBoxType.SelectedValue = "TD" Or Me.RadComboBoxType.SelectedValue = "EL" Then
                Me.ddlCategory.SelectedValue = "no"
            End If

            If Me.ReminderDropDown.SelectedValue <> "" Then
                remind = Me.ReminderDropDown.SelectedValue
            End If
            If Me.RadComboBoxType.SelectedValue = "H" Then
                key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, "", "", "", 0, 0, 2, 0, "", "", "", Me.ddlFunction.SelectedValue, 0, 0, "")
            Else
                If RadSchedulerRecurrenceEditor1.RecurrenceRuleText IsNot Nothing AndAlso RadSchedulerRecurrenceEditor1.RecurrenceRuleText <> "" Then
                    For Each occurence As DateTime In Me.RadSchedulerRecurrenceEditor1.RecurrenceRule.Occurrences
                        If oCount >= 1 Then
                            If Me.chkAllDay.Checked = True Then
                                key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, occurence.Date, occurence.AddDays(duration).Date, Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, "", "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, master, cdpid, Me.RadEditorDescription.Html)
                                If key <> -1 Then
                                    For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                        Dim emp() As String = raditem.Value.Split("|")
                                        oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                    Next
                                    Session("CalendarNonTaskNo") = key
                                Else
                                    Session("CalendarNonTaskNo") = Nothing
                                End If
                            Else
                                key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, occurence.Date, occurence.AddDays(duration).Date, occurence, occurence.AddMinutes(time), Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, "", "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, master, cdpid, Me.RadEditorDescription.Html)
                                If key <> -1 Then
                                    For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                        Dim emp() As String = raditem.Value.Split("|")
                                        oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                    Next
                                    Session("CalendarNonTaskNo") = key
                                Else
                                    Session("CalendarNonTaskNo") = Nothing
                                End If
                            End If
                        Else
                            key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, Me.RadSchedulerRecurrenceEditor1.RecurrenceRuleText, "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, 0, cdpid, Me.RadEditorDescription.Html)
                            If key <> -1 Then
                                For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                    Dim emp() As String = raditem.Value.Split("|")
                                    oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                Next
                                Session("CalendarNonTaskNo") = key
                            Else
                                Session("CalendarNonTaskNo") = Nothing
                            End If
                            If Me.chkAllDay.Checked = True Then
                                duration = (CDate(Me.RadDatePickerEndDate.SelectedDate) - CDate(Me.RadDatePickerStartDate.SelectedDate)).Days
                            Else
                                duration = (CDate(Me.RadDatePickerEndDate.SelectedDate) - CDate(Me.RadDatePickerStartDate.SelectedDate)).Days
                                time = (CDate(Me.radTimePickerEnd.SelectedDate) - CDate(Me.radTimePickerStart.SelectedDate)).TotalMinutes
                            End If
                            master = key
                            oCount += 1
                        End If
                    Next
                Else
                    key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Employee, Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, "", "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, 0, cdpid, Me.RadEditorDescription.Html)
                    If key <> -1 Then
                        For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                            Dim emp() As String = raditem.Value.Split("|")
                            oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                        Next
                        Session("CalendarNonTaskNo") = key
                    Else
                        Session("CalendarNonTaskNo") = Nothing
                    End If
                End If
                Dim MyExport As New ExportStructure
                MyExport.UID = "A|" + oCalendar.InsertKey.ToString
                Session("SavedKey") = oCalendar.InsertKey.ToString
                MyExport.Category = Me.ddlCategory.SelectedItem.Text
                MyExport.Description = ""
                If Me.chkAllDay.Checked = False Then
                    MyExport.StartTime = CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerStart.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Second.ToString
                    MyExport.EndTime = CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerEnd.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Second.ToString
                Else
                    MyExport.StartTime = Convert.ToDateTime(CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString & " 12:00:00 AM")
                    MyExport.EndTime = Convert.ToDateTime(CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString & " 11:59:00 PM") 'Maybe this needs to end with 59seconds but the rest of your codes doesnt. Dan
                End If
                MyExport.Title = ""
                MyExport.Method = "publish"
                Session("ExportData") = MyExport

                'Me.CreateExport(False)

            End If

            If key <> -1 Then

                Try

                    'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), key, (Me.RadComboBoxType.SelectedValue = "H"), False)
                    Me.CalendarSync(key, (Me.RadComboBoxType.SelectedValue = "H"), False)

                Catch ex As Exception

                End Try

            End If

            Return key

        Catch ex As Exception
            Response.Write("Error with Saving Task: " & ex.Message.ToString())
        End Try
    End Function

    Private Function updateActivity()

        Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Try
            If Me.txtSubject.Text = "" Then
                Me.ShowMessage("Subject is required.")
                Exit Function
            End If
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
            If Me.RadComboBoxType.SelectedValue = "" Then
                Me.ShowMessage("Please select a type.")
                Exit Function
            End If
            If Me.RadComboBoxType.SelectedValue = "A" Then
                If Me.ddlCategory.SelectedItem.Text = "no" Or Me.ddlCategory.SelectedItem.Text = "" Then
                    Me.ShowMessage("Please select a category.")
                    Exit Function
                End If
            End If
            If wvCDate(Me.RadDatePickerEndDate.SelectedDate) < wvCDate(Me.RadDatePickerStartDate.SelectedDate) Then
                Me.ShowMessage("End date cannot be less than start date.")
                Exit Function
            End If
            If Me.chkAllDay.Checked = False Then
                Dim ed As DateTime = Me.RadDatePickerEndDate.SelectedDate
                Dim sd As DateTime = Me.RadDatePickerStartDate.SelectedDate
                Dim et As DateTime = Me.radTimePickerEnd.SelectedDate
                Dim st As DateTime = Me.radTimePickerStart.SelectedDate
                If Convert.ToDateTime(ed.Date.ToShortDateString & " " & et.Hour.ToString() & ":" & et.Minute.ToString() & ":" & et.Second.ToString()) < Convert.ToDateTime(sd.Date.ToShortDateString & " " & st.Hour.ToString() & ":" & st.Minute.ToString() & ":" & st.Second.ToString()) Then
                    Me.ShowMessage("End time cannot be less than start time.")
                    Exit Function
                End If
            End If
            Dim ThisTask As Integer = 0
            Try
                ThisTask = key
            Catch ex As Exception
                ThisTask = 0
            End Try

            If ThisTask > 0 Then
                If Me.HasAccessToEmployee(Me.GetTaskEmpCode(ThisTask)) = False Then
                    Me.ShowMessage("Invalid Employee")
                    Exit Function
                End If
            End If

            If oCalendar.checkAppointments(Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Me.chkAllDay.Checked, "", ThisTask) Then
                If Me.RadComboBoxType.SelectedValue = "A" Then
                    Me.ShowMessage("WARNING:  Appointment conflicts with existing appointment.")
                Else
                    Me.ShowMessage("WARNING:  Holiday conflicts with existing appointments.")
                End If
            End If



            If Me.txtClient.Text <> "" Then
                If Me.txtDivision.Text = "" Then
                    Me.ShowMessage("Please select a Division.")
                    Exit Function
                End If
                If Me.txtProduct.Text = "" Then
                    Me.ShowMessage("Please select a Product.")
                    Exit Function
                End If
            End If
            If Me.txtClient.Text <> "" Then
                If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                    Me.ShowMessage("Client invalid")
                    Exit Function
                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                    Me.ShowMessage("Access to this Client is denied")
                    Exit Function
                End If
            End If
            If Me.txtDivision.Text <> "" Then
                If Me.txtClient.Text = "" Then
                    Me.ShowMessage("Please select a Client.")
                    Exit Function
                End If
                If Me.txtProduct.Text = "" Then
                    Me.ShowMessage("Please select a Product.")
                    Exit Function
                End If
                If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                    Me.ShowMessage("Client, Division invalid")
                    Exit Function
                End If
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                    Me.ShowMessage("Access to this Division is denied")
                    Exit Function
                End If
            End If
            If Me.txtProduct.Text <> "" Then
                If Me.txtClient.Text = "" Then
                    Me.ShowMessage("Please select a Client.")
                    Exit Function
                End If
                If Me.txtDivision.Text = "" Then
                    Me.ShowMessage("Please select a Division.")
                    Exit Function
                End If
                If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                    Me.ShowMessage("Invalid Client, Division, Product")
                    Exit Function
                End If
                If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                    Me.ShowMessage("Access to this product is denied")
                    Exit Function
                End If
            End If
            If Me.txtJob.Text.Trim <> "" Then
                If IsNumeric(Me.txtJob.Text.Trim) = False Then
                    Me.ShowMessage("Job invalid")
                    Return False
                End If
                If Me.txtComponent.Text = "" Then
                    Me.ShowMessage("Please select a Component.")
                    Return False
                End If
                If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                    Me.ShowMessage("Job does not exist")
                    Return False
                End If
                If myVal.ValidateJobIsViewable(Session("Usercode"), Me.txtJob.Text.Trim) = False Then
                    Me.ShowMessage("Access to this Job is denied")
                    Return False
                End If
            End If
            If Me.txtComponent.Text <> "" Then
                If IsNumeric(Me.txtComponent.Text.Trim) = False Then
                    Me.ShowMessage("Component invalid")
                    Return False
                End If
                If Me.txtJob.Text = "" Then
                    Me.ShowMessage("Please select a Job.")
                    Return False
                End If
                If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                    Me.ShowMessage("Component invalid")
                    Return False
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtComponent.Text.Trim) = False Then
                    Me.ShowMessage("Access to this job/component is denied")
                    Return False
                End If
            End If

            Dim cdpid As Integer = 0
            If Me.TextBoxContact.Text <> "" Then
                cdpid = oEstimating.GetContactCodeID(Me.TextBoxContact.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                If cdpid.ToString <> Me.HfContactCodeID.Value Then
                    Me.HfContactCodeID.Value = cdpid.ToString
                    If myVal.ValidateCDPContactEst(Me.HfContactCodeID.Value, Session("UserCode")) = False Then
                        Me.ShowMessage("Please enter a valid contact.")
                        Return False
                    End If
                End If
            Else
                Me.HfContactCodeID.Value = ""
            End If

            If Me.HfContactCodeID.Value <> "" Then
                cdpid = CInt(Me.HfContactCodeID.Value)
            End If

            Dim Employee As String = ""
            Dim standardHours As Decimal
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetStandardHours()
            Do While dr.Read
                standardHours = dr.GetDecimal(0)
            Loop

            If Me.RadComboBoxType.SelectedValue <> "H" Then
                If RadListBoxEmps_EmpsInActivity.Items.Count = 0 Then
                    Me.ShowMessage("Please Assign Employee to this activity.")
                    Return False
                Else
                    Employee = RadListBoxEmps_EmpsInActivity.Items(0).Value.Split("|").First
                End If
            End If

            Dim save As Boolean = False
            Dim job As Integer = 0
            Dim comp As Integer = 0
            Dim remind As String = ""
            Dim days As Integer
            Dim duration As Integer = 0
            Dim time As Decimal = 0
            Dim oCount As Integer = 0
            Dim task As AdvantageFramework.Database.Entities.EmployeeNonTask
            Dim tasklist As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeNonTask) = Nothing
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.txtJob.Text <> "" Then
                job = CInt(Me.txtJob.Text)
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, job)
                    If Me.txtClient.Text = "" Then
                        Me.txtClient.Text = jobdata.ClientCode
                    End If
                    If Me.txtDivision.Text = "" Then
                        Me.txtDivision.Text = jobdata.DivisionCode
                    End If
                    If Me.txtProduct.Text = "" Then
                        Me.txtProduct.Text = jobdata.ProductCode
                    End If
                End Using
            End If
            If Me.txtComponent.Text <> "" Then
                comp = CInt(Me.txtComponent.Text)
            End If
            If Me.RadComboBoxType.SelectedValue = "C" Or Me.RadComboBoxType.SelectedValue = "M" Or Me.RadComboBoxType.SelectedValue = "TD" Or Me.RadComboBoxType.SelectedValue = "EL" Then
                Me.ddlCategory.SelectedValue = "no"
            End If
            If Me.ReminderDropDown.SelectedValue <> "" Then
                remind = Me.ReminderDropDown.SelectedValue
            End If

            If Me.RadComboBoxType.SelectedValue = "H" Then
                save = oCalendar.UpdateActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", ThisTask, standardHours, "", "", "", 0, 0, 2, 0, "", "", "", Me.ddlFunction.SelectedValue, 0, 0, "")
            Else
                If Not Request.QueryString("state") Is Nothing Then
                    If Request.QueryString("state") = "occurrence" And state <> "master" Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, ThisTask)
                        End Using
                        If task.Recurrence <> "" Then
                            save = oCalendar.UpdateActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", ThisTask, standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, task.Recurrence, "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, 0, cdpid, Me.RadEditorDescription.Html)
                        Else
                            save = oCalendar.UpdateActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", ThisTask, standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, Me.RadSchedulerRecurrenceEditor1.RecurrenceRuleText, "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, task.RecurrenceParent, cdpid, Me.RadEditorDescription.Html)
                        End If
                        If save = True Then
                            oCalendar.DeleteTaskEmps(ThisTask)
                            For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                Dim emp() As String = raditem.Value.Split("|")
                                oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                            Next
                        End If
                    End If
                    If Request.QueryString("state") = "master" Or state = "master" Then
                        save = oCalendar.UpdateActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", ThisTask, standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, Me.RadSchedulerRecurrenceEditor1.RecurrenceRuleText, "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, 0, cdpid, Me.RadEditorDescription.Html)
                        If save = True Then
                            oCalendar.DeleteTaskEmps(ThisTask)
                            For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                Dim emp() As String = raditem.Value.Split("|")
                                oCalendar.AddNewActivityEmp(ThisTask, emp(0), emp(1))
                            Next
                        End If
                        If Me.chkAllDay.Checked = True Then
                            duration = (CDate(Me.RadDatePickerEndDate.SelectedDate) - CDate(Me.RadDatePickerStartDate.SelectedDate)).Days
                        Else
                            duration = (CDate(Me.RadDatePickerEndDate.SelectedDate) - CDate(Me.RadDatePickerStartDate.SelectedDate)).Days
                            time = (CDate(Me.radTimePickerEnd.SelectedDate) - CDate(Me.radTimePickerStart.SelectedDate)).TotalMinutes
                        End If
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            task = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, ThisTask)
                            tasklist = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByRecurrenceParentID(DbContext, task.ID).ToList
                            For Each task In tasklist
                                AdvantageFramework.Database.Procedures.EmployeeNonTask.DeleteByNonTaskId(DbContext, task.ID)
                            Next
                            If RadSchedulerRecurrenceEditor1.RecurrenceRuleText <> "" Then
                                For Each occurence As DateTime In Me.RadSchedulerRecurrenceEditor1.RecurrenceRule.Occurrences
                                    If oCount >= 1 Then
                                        If Me.chkAllDay.Checked = True Then
                                            key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, occurence.Date, occurence.AddDays(duration).Date, Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, "", "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, ThisTask, cdpid, Me.RadEditorDescription.Html)
                                            If key <> -1 Then
                                                For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                                    Dim emp() As String = raditem.Value.Split("|")
                                                    oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                                Next
                                                Session("CalendarNonTaskNo") = key
                                            Else
                                                Session("CalendarNonTaskNo") = Nothing
                                            End If
                                        Else
                                            key = oCalendar.AddNewActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, occurence.Date, occurence.AddDays(duration).Date, occurence, occurence.AddMinutes(time), Session("EmpCode"), Me.ddlCategory.SelectedValue.ToString(), "", standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, "", "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, ThisTask, cdpid, Me.RadEditorDescription.Html)
                                            If key <> -1 Then
                                                For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                                                    Dim emp() As String = raditem.Value.Split("|")
                                                    oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                                                Next
                                                Session("CalendarNonTaskNo") = key
                                            Else
                                                Session("CalendarNonTaskNo") = Nothing
                                            End If
                                        End If
                                    Else
                                        oCount += 1
                                    End If
                                Next
                            End If
                        End Using
                    End If
                Else
                    save = oCalendar.UpdateActivity(Me.RadComboBoxType.SelectedValue, Me.txtSubject.Text, Me.chkAllDay.Checked, Convert.ToDateTime(wvCDate(Me.RadDatePickerStartDate.SelectedDate)), Convert.ToDateTime(wvCDate(Me.RadDatePickerEndDate.SelectedDate)), Me.radTimePickerStart.SelectedDate, Me.radTimePickerEnd.SelectedDate, Employee, Me.ddlCategory.SelectedValue.ToString(), "", ThisTask, standardHours, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, job, comp, Me.RadComboBoxPriority.SelectedValue, remind, Me.RadSchedulerRecurrenceEditor1.RecurrenceRuleText, "", Me.RadEditorDescription.Text, Me.ddlFunction.SelectedValue, 0, cdpid, Me.RadEditorDescription.Html)
                    If save = True Then
                        oCalendar.DeleteTaskEmps(ThisTask)
                        For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                            Dim emp() As String = raditem.Value.Split("|")
                            oCalendar.AddNewActivityEmp(key, emp(0), emp(1))
                        Next
                    End If
                End If
                Dim MyExport As New ExportStructure
                MyExport.UID = "A|" + ThisTask.ToString
                MyExport.Category = Me.ddlCategory.SelectedItem.Text
                MyExport.Description = ""
                If Me.chkAllDay.Checked = False Then
                    MyExport.StartTime = CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerStart.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerStart.SelectedDate.ToString()).Second.ToString
                    MyExport.EndTime = CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString.ToString() & " " & CDate(radTimePickerEnd.SelectedDate.ToString()).Hour.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Minute.ToString() & ":" & CDate(radTimePickerEnd.SelectedDate.ToString()).Second.ToString
                Else
                    MyExport.StartTime = Convert.ToDateTime(CDate(Me.RadDatePickerStartDate.SelectedDate).Date.ToShortDateString & " 12:00:00 AM")
                    MyExport.EndTime = Convert.ToDateTime(CDate(Me.RadDatePickerEndDate.SelectedDate).Date.ToShortDateString & " 11:59:00 pm") 'Maybe this needs to end with 59seconds but the rest of your codes doesnt. Dan
                End If
                MyExport.Title = ""
                MyExport.Method = "PUBLISH"
                Session("ExportData") = MyExport
                'Me.CreateExport(False)
            End If
            If save = True Then
                Session("TaskCalendarSelectedDate") = Me.RadDatePickerStartDate.SelectedDate
                If Me.RadComboBoxType.SelectedValue <> "H" Then
                    Me.RadToolBarButtonExport.Visible = True
                Else
                    Me.RadToolBarButtonExport.Visible = False
                End If
                Me.RadToolBarButtonUpdate.Visible = True
                Me.RadToolBarButtonDelete.Visible = True
                'lblConfirm.Visible = True
                'lblConfirm.Text = "Update Successful."
                If Me.RadComboBoxType.SelectedValue = "H" Then
                    'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), key, True, False)
                    Me.CalendarSync(key, True, False)

                Else
                    'AdvantageFramework.Calendar.Sync(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), key, False, False)
                    Me.CalendarSync(key, False, False)

                End If

            Else
                Me.ShowMessage("Update Failed.")
            End If

            Return save
        Catch ex As Exception
            Response.Write("Error with Updating Task: " & ex.Message.ToString())
        End Try
    End Function

    Private Function GetTaskEmpCode(ByVal TaskId As Integer) As String
        Try
            Dim oCalendar As TaskCalendar.cCalendar = New TaskCalendar.cCalendar(CStr(Session("ConnString")))
            Dim dr As SqlClient.SqlDataReader
            dr = oCalendar.GetNonTaskData(TaskId, HttpContext.Current.Session("UserCode"))
            While dr.Read
                Return dr.GetString(3)
            End While
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function str_outlookdate(ByVal dat_date As Date) As String
        str_outlookdate = Format(dat_date, "yyyyMMdd")
    End Function

    Private Function str_outlooktime(ByVal dat_time As Date) As String
        str_outlooktime = Format(dat_time, "HHmmss")
    End Function

    Public Shared Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Private Sub SendAlerts()
        Try
            Dim Alert As New Alert(Session("ConnString"))
            Dim NowDate As Date = Now
            Dim DateDate As Date
            Dim url, ApprNotes As String
            Dim RowCount As Integer = Me.RadListBoxEmps_EmpsInActivity.Items.Count
            Dim MarkValue As String
            Dim checked As Boolean
            Dim idx As Integer = 0
            Dim empCode, empName, DateStr, status, invnbr, empEmail As String
            Dim count As Integer = 1
            Dim level As String = ""
            Dim i As Integer

            url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath

            Dim job As Integer = 0
            Dim comp As Integer = 0
            If Me.txtJob.Text <> "" Then
                job = CInt(Me.txtJob.Text)
            End If
            If Me.txtComponent.Text <> "" Then
                comp = CInt(Me.txtComponent.Text)
            End If

            If job <> 0 And comp <> 0 Then
                level = "JC"
            ElseIf Me.txtProduct.Text <> "" Then
                level = "PR"
            End If

            Dim strDate As System.Text.StringBuilder = New System.Text.StringBuilder
            strDate.Append("Start Date: ")
            strDate.Append(CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString)
            strDate.Append("<br/>")
            If Me.chkAllDay.Checked = False Then
                strDate.Append("Start Time: ")
                strDate.Append(Me.radTimePickerStart.SelectedTime)
                strDate.Append("<br/>")
            End If
            strDate.Append("End Date: ")
            strDate.Append(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString)
            strDate.Append("<br/>")
            If Me.chkAllDay.Checked = False Then
                strDate.Append("End Time: ")
                strDate.Append(Me.radTimePickerEnd.SelectedTime)
                strDate.Append("<br/>")
            End If

            Dim AlertNew As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertRcpt As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                AlertNew = New AdvantageFramework.Database.Entities.Alert
                With AlertNew
                    .AlertTypeID = 10
                    If Me.RadComboBoxType.SelectedValue = "C" Then
                        .AlertCategoryID = 55
                    ElseIf Me.RadComboBoxType.SelectedValue = "M" Then
                        .AlertCategoryID = 56
                    ElseIf Me.RadComboBoxType.SelectedValue = "TD" Then
                        .AlertCategoryID = 57
                    ElseIf Me.RadComboBoxType.SelectedValue = "EL" Then
                        .AlertCategoryID = 72
                    End If
                    .Subject = Me.txtSubject.Text
                    .Body = Me.RadEditorDescription.Text & "<br/>" & strDate.ToString
                    .EmailBody = Me.RadEditorDescription.Html & "<br/>" & strDate.ToString
                    .GeneratedDate = NowDate
                    .PriorityLevel = Me.RadComboBoxPriority.SelectedValue
                    .EmployeeCode = Session("EmpCode")
                    .AlertLevel = level
                    .UserCode = Session("UserCode")
                    .ClientCode = Me.txtClient.Text
                    .DivisionCode = Me.txtDivision.Text
                    .ProductCode = Me.txtProduct.Text
                    .JobNumber = job
                    .JobComponentNumber = comp
                    .StartDate = Me.RadDatePickerStartDate.SelectedDate
                    .DueDate = Me.RadDatePickerEndDate.SelectedDate
                    If Not Request.QueryString("TaskNo") Is Nothing Then
                        .NonTaskID = Request.QueryString("TaskNo")
                    Else
                        .NonTaskID = key
                    End If
                End With

                'If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertNew) Then
                AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertNew)
                'End If

                For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                    Dim emp() As String = raditem.Value.Split("|")
                    empCode = emp(0)
                    empEmail = emp(1)
                    AlertRcpt = New AdvantageFramework.Database.Entities.AlertRecipient
                    With AlertRcpt
                        .AlertID = AlertNew.ID
                        .ID = count
                        .EmployeeCode = empCode
                        .EmployeeEmail = empEmail
                    End With
                    'If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRcpt) Then
                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRcpt)
                    'End If
                    count += 1
                Next

                Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
                'Dim AppIsOnASP As Boolean = oApp.IsASPClient
                Dim HasOverSizedFile As Boolean = False
                Dim Repository As New DocumentRepository(CStr(Session("ConnString")))
                Dim Document As New Document(CStr(Session("ConnString")))
                Dim HasMultipleUploads As Boolean = False

                HasMultipleUploads = Me.RadUploadAlertDocuments.UploadedFiles.Count > 1

                '//////////////////
                Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext
                If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then 'And IsNTAUTH = False Then
                    If IsNTAuth = True Then
                        currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                        impersonationContext1 = currentWindowsIdentity.Impersonate()
                    End If
                    Dim doc As New DocumentRepository("", True)
                    If IsNTAuth = True Then
                        impersonationContext1.Undo()
                    End If
                    For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1
                        Dim realFilename As String = Me.RadUploadAlertDocuments.UploadedFiles(i).GetName
                        Dim MIMEType As String = "" 'Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                        If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then
                            MIMEType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                        Else
                            MIMEType = ""
                        End If
                        Dim FileLength As Integer = Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Length
                        Dim ThisFC As New DocumentRepository.FileCompare
                        ThisFC.FileByteLength = CType(FileLength, Long)
                        If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = True AndAlso
                            doc.IsOverFileSizeLimit(ThisFC) = False Then
                            If FileLength > 0 Then
                                Dim FileBytes(FileLength - 1) As Byte
                                Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                Dim UsePrefix As String = "a_"
                                If Me.ChkUploadToRepository.Checked = True Then
                                    UsePrefix = "d_"
                                Else
                                    UsePrefix = "a_"
                                End If

                                Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", UsePrefix)
                                If IsNTAuth = True And HasMultipleUploads = True Then
                                    currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                    impersonationContext1 = currentWindowsIdentity.Impersonate()
                                End If
                                Dim DocumentId As Integer = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")

                                If Me.ChkUploadToRepository.Checked = True Then 'adds additional record to job doc table/job comp doc table so that doc shows up in the alert as well as the repository
                                    Try
                                        Select Case level
                                            Case "JC"
                                                If job > 0 And comp > 0 Then
                                                    Dim DocumentJC As New JobComponentDocuments(CStr(Session("ConnString")))
                                                    DocumentId = DocumentJC.Add(job, comp, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2)
                                                End If
                                            Case "PR"
                                                If Me.txtProduct.Text <> "" Then
                                                    Dim DocumentPR As New ProductDocuments(CStr(Session("ConnString")))
                                                    DocumentId = DocumentPR.Add(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2)
                                                End If
                                        End Select
                                    Catch ex As Exception
                                        'ErrorMessage = ex.Message.ToString()
                                    End Try
                                End If

                                AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment
                                If IsClientPortal = True Then
                                    With AlertAttachment
                                        AlertAttachment.AlertID = AlertNew.ID
                                        AlertAttachment.DocumentID = DocumentId
                                        AlertAttachment.GeneratedDate = Date.Now
                                        AlertAttachment.UserCode = ""
                                        AlertAttachment.HasEmailBeenSent = False
                                        AlertAttachment.ClientContactID = Session("UserID")
                                    End With
                                Else
                                    With AlertAttachment
                                        AlertAttachment.AlertID = AlertNew.ID
                                        AlertAttachment.DocumentID = DocumentId
                                        AlertAttachment.GeneratedDate = Date.Now
                                        AlertAttachment.UserCode = Session("UserCode")
                                        AlertAttachment.HasEmailBeenSent = False
                                        AlertAttachment.ClientContactID = Nothing
                                    End With
                                End If

                                AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)


                                If IsNTAuth = True And HasMultipleUploads = True Then
                                    impersonationContext1.Undo()
                                End If

                            End If
                        Else
                            HasOverSizedFile = True
                        End If
                    Next
                    If HasOverSizedFile = True Then
                        '''Me.ShowMessage("Files that exceeded the file size limit were excluded")
                    End If
                End If

                Try
                    If IsNTAuth = True Then
                        currentWindowsIdentity1 = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                        impersonationContext1 = Me.currentWindowsIdentity.Impersonate()
                    End If
                Catch ex As Exception
                End Try


                '/////////////////
                For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.Items
                    If item.Selected = True Then
                        AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment
                        If IsClientPortal = True Then
                            With AlertAttachment
                                AlertAttachment.AlertID = AlertNew.ID
                                AlertAttachment.DocumentID = item.Value
                                AlertAttachment.GeneratedDate = Date.Now
                                AlertAttachment.UserCode = ""
                                AlertAttachment.HasEmailBeenSent = False
                                AlertAttachment.ClientContactID = Session("UserID")
                            End With
                        Else
                            With AlertAttachment
                                AlertAttachment.AlertID = AlertNew.ID
                                AlertAttachment.DocumentID = item.Value
                                AlertAttachment.GeneratedDate = Date.Now
                                AlertAttachment.UserCode = Session("UserCode")
                                AlertAttachment.HasEmailBeenSent = False
                                AlertAttachment.ClientContactID = Nothing
                            End With
                        End If

                        AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                    End If
                Next

                SendEmailAlert(AlertNew.ID)

            End Using


        Catch ex As Exception

        End Try

    End Sub

    Private Sub UpdateAlert()
        Try
            Dim NowDate As Date = Now
            Dim DateDate As Date
            Dim url, ApprNotes As String
            Dim RowCount As Integer = Me.RadListBoxEmps_EmpsInActivity.Items.Count
            Dim MarkValue As String
            Dim checked As Boolean
            Dim idx As Integer = 0
            Dim empCode, empName, DateStr, status, invnbr, empEmail As String
            Dim count As Integer = 1
            Dim level As String = ""
            Dim i As Integer

            url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath

            Dim job As Integer = 0
            Dim comp As Integer = 0
            If Me.txtJob.Text <> "" Then
                job = CInt(Me.txtJob.Text)
            End If
            If Me.txtComponent.Text <> "" Then
                comp = CInt(Me.txtComponent.Text)
            End If

            If job <> 0 And comp <> 0 Then
                level = "JC"
            ElseIf Me.txtProduct.Text <> "" Then
                level = "PR"
            End If

            Dim strDate As System.Text.StringBuilder = New System.Text.StringBuilder
            strDate.Append("Start Date: ")
            strDate.Append(CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString)
            strDate.Append("<br/>")
            If Me.chkAllDay.Checked = False Then
                strDate.Append("Start Time: ")
                strDate.Append(Me.radTimePickerStart.SelectedTime)
                strDate.Append("<br/>")
            End If
            strDate.Append("End Date: ")
            strDate.Append(CDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString)
            strDate.Append("<br/>")
            If Me.chkAllDay.Checked = False Then
                strDate.Append("End Time: ")
                strDate.Append(Me.radTimePickerEnd.SelectedTime)
                strDate.Append("<br/>")
            End If

            Dim Alerts As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertRcpt As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRcptDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Try
                    Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByNonTaskID(DbContext, key)
                Catch ex As Exception
                    Alerts = Nothing
                End Try

                If Not Alerts Is Nothing Then
                    With Alerts
                        .AlertTypeID = 10
                        If Me.RadComboBoxType.SelectedValue = "C" Then
                            .AlertCategoryID = 55
                        ElseIf Me.RadComboBoxType.SelectedValue = "M" Then
                            .AlertCategoryID = 56
                        ElseIf Me.RadComboBoxType.SelectedValue = "TD" Then
                            .AlertCategoryID = 57
                        ElseIf Me.RadComboBoxType.SelectedValue = "EL" Then
                            .AlertCategoryID = 78
                        End If
                        .Subject = Me.txtSubject.Text
                        .Body = Me.RadEditorDescription.Text & "<br/>" & strDate.ToString
                        .EmailBody = Me.RadEditorDescription.Text & "<br/>" & strDate.ToString
                        .PriorityLevel = Me.RadComboBoxPriority.SelectedValue
                        .EmployeeCode = Session("EmpCode")
                        .AlertLevel = level
                        .UserCode = Session("UserCode")
                        .ClientCode = Me.txtClient.Text
                        .DivisionCode = Me.txtDivision.Text
                        .ProductCode = Me.txtProduct.Text
                        .JobNumber = job
                        .JobComponentNumber = comp
                        .DueDate = Me.RadDatePickerEndDate.SelectedDate
                    End With

                    If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alerts) Then
                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alerts)
                    End If

                    For Each raditem As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxEmps_EmpsInActivity.Items
                        Dim emp() As String = raditem.Value.Split("|")
                        empCode = emp(0)
                        empEmail = emp(1)
                        Try
                            AlertRcpt = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(DbContext, Alerts.ID, empCode)
                        Catch ex As Exception
                            AlertRcpt = Nothing
                        End Try
                        Try
                            AlertRcptDismissed = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertIDAndEmployeeCode(DbContext, Alerts.ID, empCode)
                        Catch ex As Exception
                            AlertRcptDismissed = Nothing
                        End Try
                        If Not AlertRcptDismissed Is Nothing Then
                            AlertRcpt = New AdvantageFramework.Database.Entities.AlertRecipient
                            With AlertRcpt
                                .AlertID = Alerts.ID
                                .ID = count
                                .EmployeeCode = empCode
                                .EmployeeEmail = empEmail
                            End With
                            AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, AlertRcptDismissed)
                        ElseIf Not AlertRcpt Is Nothing Then
                            With AlertRcpt
                                .HasBeenRead = Nothing
                                .ProcessedDate = Nothing
                                .IsNewAlert = Nothing
                            End With
                            If AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRcpt) Then
                                AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRcpt)
                            End If
                        Else
                            Dim MaxAlertRecipientID As Integer = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alerts.ID).Max(Function(AlertRecipient) AlertRecipient.ID)
                            AlertRcpt = New AdvantageFramework.Database.Entities.AlertRecipient
                            With AlertRcpt
                                .AlertID = Alerts.ID
                                .ID = MaxAlertRecipientID + 1
                                .EmployeeCode = empCode
                                .EmployeeEmail = empEmail
                            End With
                            'If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRcpt) Then
                            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRcpt)
                            'End If
                        End If
                        count += 1
                    Next

                    Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
                    'Dim AppIsOnASP As Boolean = oApp.IsASPClient
                    Dim HasOverSizedFile As Boolean = False
                    Dim Repository As New DocumentRepository(CStr(Session("ConnString")))
                    Dim Document As New Document(CStr(Session("ConnString")))
                    Dim HasMultipleUploads As Boolean = False

                    HasMultipleUploads = Me.RadUploadAlertDocuments.UploadedFiles.Count > 1

                    '//////////////////
                    Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                    Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext
                    If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then 'And IsNTAUTH = False Then
                        If IsNTAuth = True Then
                            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext1 = currentWindowsIdentity.Impersonate()
                        End If
                        Dim doc As New DocumentRepository("", True)
                        If IsNTAuth = True Then
                            impersonationContext1.Undo()
                        End If
                        For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1
                            Dim realFilename As String = Me.RadUploadAlertDocuments.UploadedFiles(i).GetName
                            Dim MIMEType As String = "" 'Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                            If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then
                                MIMEType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                            Else
                                MIMEType = ""
                            End If
                            Dim FileLength As Integer = Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Length
                            Dim ThisFC As New DocumentRepository.FileCompare
                            ThisFC.FileByteLength = CType(FileLength, Long)
                            If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = True AndAlso
                                doc.IsOverFileSizeLimit(ThisFC) = False Then
                                If FileLength > 0 Then
                                    Dim FileBytes(FileLength - 1) As Byte
                                    Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                    Dim UsePrefix As String = "a_"
                                    If Me.ChkUploadToRepository.Checked = True Then
                                        UsePrefix = "d_"
                                    Else
                                        UsePrefix = "a_"
                                    End If

                                    Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", UsePrefix)
                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext1 = currentWindowsIdentity.Impersonate()
                                    End If
                                    Dim DocumentId As Integer = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")

                                    If Me.ChkUploadToRepository.Checked = True Then 'adds additional record to job doc table/job comp doc table so that doc shows up in the alert as well as the repository
                                        Try
                                            Select Case level
                                                Case "JC"
                                                    If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                                                        Dim DocumentJC As New JobComponentDocuments(CStr(Session("ConnString")))
                                                        DocumentId = DocumentJC.Add(job, comp, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2)
                                                    End If
                                                Case "PR"
                                                    If Me.txtProduct.Text <> "" Then
                                                        Dim DocumentPR As New ProductDocuments(CStr(Session("ConnString")))
                                                        DocumentId = DocumentPR.Add(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2)
                                                    End If
                                            End Select
                                        Catch ex As Exception
                                            'ErrorMessage = ex.Message.ToString()
                                        End Try
                                    End If

                                    AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment
                                    If IsClientPortal = True Then
                                        With AlertAttachment
                                            AlertAttachment.AlertID = Alerts.ID
                                            AlertAttachment.DocumentID = DocumentId
                                            AlertAttachment.GeneratedDate = Date.Now
                                            AlertAttachment.UserCode = ""
                                            AlertAttachment.HasEmailBeenSent = False
                                            AlertAttachment.ClientContactID = Session("UserID")
                                        End With
                                    Else
                                        With AlertAttachment
                                            AlertAttachment.AlertID = Alerts.ID
                                            AlertAttachment.DocumentID = DocumentId
                                            AlertAttachment.GeneratedDate = Date.Now
                                            AlertAttachment.UserCode = Session("UserCode")
                                            AlertAttachment.HasEmailBeenSent = False
                                            AlertAttachment.ClientContactID = Nothing
                                        End With
                                    End If

                                    AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)


                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        impersonationContext1.Undo()
                                    End If

                                End If
                            Else
                                HasOverSizedFile = True
                            End If
                        Next
                        If HasOverSizedFile = True Then
                            '''Me.ShowMessage("Files that exceeded the file size limit were excluded")
                        End If
                    End If

                    Try
                        If IsNTAuth = True Then
                            currentWindowsIdentity1 = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext1 = Me.currentWindowsIdentity.Impersonate()
                        End If
                    Catch ex As Exception
                    End Try


                    '/////////////////
                    For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.Items
                        If item.Selected = True Then
                            AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment
                            If IsClientPortal = True Then
                                With AlertAttachment
                                    AlertAttachment.AlertID = Alerts.ID
                                    AlertAttachment.DocumentID = item.Value
                                    AlertAttachment.GeneratedDate = Date.Now
                                    AlertAttachment.UserCode = ""
                                    AlertAttachment.HasEmailBeenSent = False
                                    AlertAttachment.ClientContactID = Session("UserID")
                                End With
                            Else
                                With AlertAttachment
                                    AlertAttachment.AlertID = Alerts.ID
                                    AlertAttachment.DocumentID = item.Value
                                    AlertAttachment.GeneratedDate = Date.Now
                                    AlertAttachment.UserCode = Session("UserCode")
                                    AlertAttachment.HasEmailBeenSent = False
                                    AlertAttachment.ClientContactID = Nothing
                                End With
                            End If

                            AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                        End If
                    Next

                    SendEmailAlert(Alerts.ID, True)
                End If

            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Function LoadJob()
        Try
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            Dim jobcompdata As AdvantageFramework.Database.Entities.JobComponent = Nothing
            If IsNumeric(Me.txtJob.Text) = True And IsNumeric(Me.txtComponent.Text) = True Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.txtJob.Text)
                    jobcompdata = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.txtJob.Text, Me.txtComponent.Text)
                    If Me.txtClient.Text = "" Then
                        Me.txtClient.Text = jobdata.ClientCode
                    End If
                    If Me.txtDivision.Text = "" Then
                        Me.txtDivision.Text = jobdata.DivisionCode
                    End If
                    If Me.txtProduct.Text = "" Then
                        Me.txtProduct.Text = jobdata.ProductCode
                    End If
                    If Me.TxtClientDesc.Text = "" Then
                        Me.TxtClientDesc.Text = jobdata.Client.Name
                    End If
                    If Me.TxtDivisionDesc.Text = "" Then
                        Me.TxtDivisionDesc.Text = jobdata.Division.Name
                    End If
                    If Me.TxtProductDesc.Text = "" Then
                        Me.TxtProductDesc.Text = jobdata.Product.Name
                    End If
                    If Me.TxtJobDescription.Text = "" Then
                        Me.TxtJobDescription.Text = jobdata.Description
                    End If
                    If Me.TxtJobCompDescription.Text = "" Then
                        Me.TxtJobCompDescription.Text = jobcompdata.Description
                    End If
                End Using
                Me.SetupLinks()
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function SendEmailAlert(ByVal AlertID As Integer, Optional ByVal update As Boolean = False) As Boolean


        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID

                If update = True Then

                    .Subject = "[Update Alert]"

                Else

                    .Subject = "[New Alert]"

                End If

                .AppName = "Calendar Activity"
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Alert Email not Sent.  " & ex.Message.ToString())
            SendEmailAlert = False

        End Try
    End Function

    Private Function getHoursOverDuration(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal EmpCode As String)
        Dim oSQL As SqlHelper
        Dim dt As DataTable
        Dim dr As SqlDataReader
        Dim arParams(4) As SqlParameter

        Dim parameteruserid As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameteruserid.Value = ""
        arParams(0) = parameteruserid

        Dim parameterempcode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterempcode.Value = EmpCode
        arParams(1) = parameterempcode

        Dim parameterdepts As New SqlParameter("@DeptCodes", SqlDbType.VarChar, 4000)
        parameterdepts.Value = DBNull.Value
        arParams(2) = parameterdepts

        Dim parameterRole As New SqlParameter("@ROLES", SqlDbType.VarChar, 8000)
        parameterRole.Value = ""
        arParams(3) = parameterRole

        Try
            dr = oSQL.ExecuteReader(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_calendar_workload_hours", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTasks Routine:GetWorkload2", Err.Description)
        End Try

        Dim totalhours As Decimal
        Dim i As Integer
        Dim mon As Integer
        Dim tue As Integer
        Dim wed As Integer
        Dim thu As Integer
        Dim fri As Integer
        Dim sat As Integer
        Dim sun As Integer
        Dim time As Integer
        Dim ts As TimeSpan = EndDate.Subtract(StartDate)
        time = ts.Days

        For i = 0 To time
            If StartDate <= EndDate Then
                If StartDate.DayOfWeek = DayOfWeek.Monday Then
                    mon += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Tuesday Then
                    tue += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Wednesday Then
                    wed += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Thursday Then
                    thu += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Friday Then
                    fri += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Saturday Then
                    sat += 1
                    StartDate = StartDate.AddDays(1)
                ElseIf StartDate.DayOfWeek = DayOfWeek.Sunday Then
                    sun += 1
                    StartDate = StartDate.AddDays(1)
                End If
            Else
                Exit For
            End If
        Next

        Do While dr.Read
            If dr.GetDecimal(1) <> 0 Then
                totalhours += dr.GetDecimal(1) * mon
            End If
            If dr.GetDecimal(2) <> 0 Then
                totalhours += dr.GetDecimal(2) * tue
            End If
            If dr.GetDecimal(3) <> 0 Then
                totalhours += dr.GetDecimal(3) * wed
            End If
            If dr.GetDecimal(4) <> 0 Then
                totalhours += dr.GetDecimal(4) * thu
            End If
            If dr.GetDecimal(5) <> 0 Then
                totalhours += dr.GetDecimal(5) * fri
            End If
            If dr.GetDecimal(6) <> 0 Then
                totalhours += dr.GetDecimal(6) * sat
            End If
            If dr.GetDecimal(7) <> 0 Then
                totalhours += dr.GetDecimal(7) * sun
            End If
        Loop

        Return totalhours

    End Function

    Private Sub LoadLinkableDocuments()

        Me.RadListBoxLinkableDocuments.Items.Clear()
        Dim job As Integer = 0
        Dim comp As Integer = 0
        Dim level As String = ""

        Try
            If Me.txtJob.Text <> "" Then
                job = CInt(Me.txtJob.Text)
            End If
            If Me.txtComponent.Text <> "" Then
                comp = CInt(Me.txtComponent.Text)
            End If

            If job <> 0 And comp <> 0 Then
                level = "JC"
            ElseIf Me.txtProduct.Text <> "" Then
                level = "PR"
            End If
            Select Case level
                Case "PR"
                    Dim ProductDocs As New vCurrentProductDocuments(Session("ConnString"))
                    ProductDocs.Where.PRD_CODE.Value = Me.txtProduct.Text 'Me.ProductAutoSuggestBox.SelectedValue
                    ProductDocs.Query.Load()
                    Do Until ProductDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(ProductDocs.FILENAME & " " & ProductDocs.USER_NAME & " " & ProductDocs.UPLOADED_DATE, ProductDocs.DOCUMENT_ID))
                        ProductDocs.MoveNext()
                    Loop
                Case "JC"
                    Dim JobComponentDocs As New vCurrentJobComponentDocuments(Session("ConnString"))
                    JobComponentDocs.Where.JOB_NUMBER.Value = Me.txtJob.Text ' Me.JobAutoSuggestBox.SelectedValue
                    JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me.txtComponent.Text 'Me.ComponentAutoSuggestBox.SelectedValue
                    JobComponentDocs.Query.Load()
                    Do Until JobComponentDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                        JobComponentDocs.MoveNext()
                    Loop
            End Select

        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
