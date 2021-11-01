Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports Telerik.Web.UI
Imports Webvantage.ViewModels
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.Threading
Imports Telerik.Web.UI.Calendar

Partial Public Class Timesheet_CopyFrom
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private TimesheetStartDate As Date = Nothing
    Private CurrEmp As String = ""
    Private _Saved As Boolean = False

    Private DtFunctions As New DataTable
    Private DtProdCat As New DataTable
    Private DtTimeCategories As New DataTable
    Private DtEmployeeDepartments As New DataTable

    Private SunDate As Date
    Private MonDate As Date
    Private TueDate As Date
    Private WedDate As Date
    Private ThuDate As Date
    Private FriDate As Date
    Private SatDate As Date

    Private SunEdit As Boolean
    Private MonEdit As Boolean
    Private TueEdit As Boolean
    Private WedEdit As Boolean
    Private ThuEdit As Boolean
    Private FriEdit As Boolean
    Private SatEdit As Boolean

    Private SunClosedPP As Boolean = False
    Private MonClosedPP As Boolean = False
    Private TueClosedPP As Boolean = False
    Private WedClosedPP As Boolean = False
    Private ThuClosedPP As Boolean = False
    Private FriClosedPP As Boolean = False
    Private SatClosedPP As Boolean = False

    Dim ReloadView As Integer = 0

#End Region

#Region " Properties "

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

    Private ReadOnly Property StartWeekOn As DayOfWeek
        Get
            Try

                Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                Dim c As New cTimeSheet(Session("ConnString"))

                TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                Return TsSettings.StartTimesheetOnDayOfWeek

            Catch ex As Exception
                Return DayOfWeek.Sunday
            End Try
        End Get
    End Property
    Private Property _IncludeHours As Boolean
        Get
            If ViewState("_IncludeHours") IsNot Nothing Then
                Return CType(ViewState("_IncludeHours"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_IncludeHours") = value
        End Set
    End Property

    Public ReadOnly Property TextBox_ClientCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ClientCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_DivisionCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_DivisionCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_ProductCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ProductCode")
        End Get
    End Property

#End Region

#Region " Page Events "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet)
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim ts As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        Me.CurrEmp = Me.CurrentQuerystring.EmployeeCode
        If String.IsNullOrWhiteSpace(Me.CurrEmp) = True Then

            Me.CurrEmp = Session("EmpCode")

        Else

            If oSec.CheckEmployees(Session("UserCode"), CurrEmp) = False Then

                Server.Transfer("NoAccess.aspx")

            End If

        End If

        Try

            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.StartDate) = False Then

                TimesheetStartDate = CType(Me.CurrentQuerystring.StartDate, Date)

            Else

                TimesheetStartDate = CType(Now.Date.ToShortDateString, Date)

            End If

        Catch ex As Exception
            TimesheetStartDate = ts.FirstDayOfWeek(Now)
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.SunDate = TimesheetStartDate
        Me.MonDate = TimesheetStartDate.AddDays(1)
        Me.TueDate = TimesheetStartDate.AddDays(2)
        Me.WedDate = TimesheetStartDate.AddDays(3)
        Me.ThuDate = TimesheetStartDate.AddDays(4)
        Me.FriDate = TimesheetStartDate.AddDays(5)
        Me.SatDate = TimesheetStartDate.AddDays(6)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Try
                Dim cal As RadCalendar
                cal = RadToolCopyTo.FindControl("RadCalendarCopyToSelectedWeek")

                If cal IsNot Nothing Then

                    Dim Today As New RadCalendarDay
                    Today.Date = Me.TimeZoneToday
                    Today.ItemStyle.CssClass = "radcalendar-today"
                    cal.SpecialDays.Add(Today)

                    'cal.SelectedDate = Now.Date

                End If
            Catch ex As Exception
            End Try

            Dim oA As cAgency = New cAgency(CStr(Session("ConnString")))

            Try
                Dim q As New AdvantageFramework.Web.QueryString()
                q = q.FromCurrent()
                If IsNumeric(q.GetValue("v")) Then
                    Me.ReloadView = CType(q.GetValue("v"), Integer)
                End If
            Catch ex As Exception
                Me.ReloadView = 0
            End Try

            If oA.CheckCopyTimeSheet = False And Me.ReloadView = 0 Then 'USER NOT ALLOWED TO COPY FROM TIMESHEET, ONLY PROJECTS.
                Me.SwitchViews(1)
            Else 'show timesheet grid
                Me.SwitchViews(Me.ReloadView)
            End If
            Dim oAppVars As New cAppVars(cAppVars.Application.TIMESHEET)
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo()
            oAppVars.getAllAppVars()


            Dim DayValue As Integer = 0
            Dim SelectedItem As RadComboBoxItem

            If SelectedItem IsNot Nothing Then SelectedItem.Selected = True

            Try
                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                        If Employee.CalendarTimeType = 1 Or Employee.CalendarTimeType = 2 Or Employee.CalendarTimeType = 3 Then

                            If Employee.CalendarTimeEmailAddress Is Nothing Then
                                Me.RadToolCopyTo.OnClientShow = "clientShow"
                            ElseIf Employee.GoogleToken Is Nothing And Employee.CalendarTimeType = 1 Then
                                Me.RadToolCopyTo.OnClientShow = "clientShowGoogle"
                            End If

                        Else

                            Me.RadToolCopyTo.OnClientShow = "clientShow"
                            'ButtonGetTime.Attributes.Add("onclick", "return window.confirm('Must select Calendar Type and related settings before use.  Enter now?');")
                            ButtonGetTime.Attributes.Add("onclick", "clientShow")
                        End If
                    End Using
                End Using
            Catch ex As Exception

            End Try



        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    Try
                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                                If Employee.CalendarTimeType = 1 Or Employee.CalendarTimeType = 2 Or Employee.CalendarTimeType = 3 Then

                                    If Employee.CalendarTimeEmailAddress Is Nothing Then
                                        Me.RadToolCopyTo.OnClientShow = "clientShow"
                                    ElseIf Employee.GoogleToken Is Nothing And Employee.CalendarTimeType = 1 Then
                                        Me.RadToolCopyTo.OnClientShow = "clientShowGoogle"
                                    Else
                                        Me.RadToolCopyTo.OnClientShow = ""
                                    End If

                                Else

                                    Me.RadToolCopyTo.OnClientShow = "clientShow"
                                    'ButtonGetTime.Attributes.Add("onclick", "return window.confirm('Must select Calendar Type and related settings before use.  Enter now?');")
                                    ButtonGetTime.Attributes.Add("onclick", "clientShow")
                                End If
                            End Using
                        End Using
                    Catch ex As Exception

                    End Try
                Case "RefreshMyTemplate"
                    Me.MultiViewCopyFrom.ActiveViewIndex = 0
                    Me.SwitchViews(2)
                    'Dim q As New AdvantageFramework.Web.QueryString()
                    'With q
                    '    .Page = "Timesheet_CopyFrom.aspx"
                    '    .EmpCode = Me.CurrEmp
                    '    .Add("v", "2")
                    '    .Go()
                    'End With
                Case "CalendarTime"
                    Me.OpenWindow("Calendar Time Options", "Maintenance_CalendarTime.aspx", 500, 650, False, False, "RefreshPage")
            End Select
        End If

        If Session("TimesheetTask") = "1" Then
            Session("TimesheetTask") = ""
        End If

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Select Case Me.MultiViewCopyFrom.ActiveViewIndex
            Case 0
                Me.PageTitle = "Copy from my timesheets"
            Case 1
                Me.PageTitle = "Copy from my projects"
            Case 2
                Me.PageTitle = "Copy from my templates"
            Case 3
                Me.PageTitle = "Copy from My Calendar"
        End Select

        Try
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                    If Employee.CalendarTimeType = 1 Or Employee.CalendarTimeType = 2 Or Employee.CalendarTimeType = 3 Then

                        If Employee.CalendarTimeEmailAddress Is Nothing Then
                            Me.RadToolCopyTo.OnClientShow = "clientShow"
                        ElseIf Employee.GoogleToken Is Nothing And Employee.CalendarTimeType = 1 Then
                            Me.RadToolCopyTo.OnClientShow = "clientShowGoogle"
                        End If

                    Else

                        Me.RadToolCopyTo.OnClientShow = "clientShow"

                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        For Each item As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetTemplate.MasterTableView.Items
            Try
                Dim JobIsClosed As Boolean = MiscFN.IntToBool(CType(CType(item.FindControl("HfJobIsClosed"), HiddenField).Value, Integer))
                Dim HasAccessToFunction As Boolean = MiscFN.IntToBool(CType(CType(item.FindControl("HfHasAccessToFunction"), HiddenField).Value, Integer))
                If JobIsClosed = True Or HasAccessToFunction = False Then
                    item.Selected = False
                    Dim chk As New CheckBox
                    chk = CType(item("GridClientSelectColumn1").Controls(0), CheckBox)
                    With chk
                        .Enabled = False
                        .Visible = False
                    End With
                End If
                If JobIsClosed = True Then
                    CType(item.FindControl("ImageProcessControlWarning"), System.Web.UI.WebControls.Image).Visible = True
                End If
                If HasAccessToFunction = False Then
                    CType(item.FindControl("ImageNoAccessToFunction"), System.Web.UI.WebControls.Image).Visible = True
                End If


            Catch ex As Exception
            End Try
        Next

        'If Me.MultiViewCopyFrom.ActiveViewIndex = 3 Then
        '    Try
        '        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        '        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
        '            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

        '            If Employee.CalendarTimeType = 1 Then

        '                If Employee.CalendarTimeEmailAddress Is Nothing And Employee.GoogleToken Is Nothing Then
        '                    Me.RadToolCopyTo.Attributes.Add("OnClientShow", "return confirm('Must select Calendar Type and related settings before use.  Enter now?.');")
        '                    'Me.ShowMessage("Must select Calendar Type and related settings before use.  Enter now Y/N?.")
        '                End If

        '            Else
        '                Me.RadToolCopyTo.Attributes.Add("OnClientShow", "return confirm('Must select Calendar Type and related settings before use.  Enter now?.');")
        '                'Me.ShowMessage("Must select Calendar Type and related settings before use.  Enter now Y/N?.")

        '            End If


        '        End Using
        '    Catch ex As Exception

        '    End Try
        'End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadToolbarCopyFrom_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCopyFrom.ButtonClick
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Select Case e.Item.Value
            Case "MyTemplate"
                Me.SwitchViews(2)
            Case "NewTemplateItem"
                Me.OpenWindow("Add New Timesheet Template Item", "Timesheet_Template_Add.aspx?emp=" & Me.CurrEmp, 650, 600, False, True, "refreshCallBack")
            Case "Refresh"
                Me.RadCalendarCopyToSelectedWeek.SelectedDates.Clear()
                Me.SwitchViews(Me.MultiViewCopyFrom.ActiveViewIndex)
            Case "Delete"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case Me.MultiViewCopyFrom.ActiveViewIndex
                        Case 2

                            Try

                                Dim EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate = Nothing
                                Dim EmployeeTimeTemplateID As Integer = 0

                                For Each Row As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetTemplate.MasterTableView.Items

                                    EmployeeTimeTemplate = Nothing
                                    EmployeeTimeTemplateID = 0

                                    If Row.Selected = True Then

                                        Try

                                            EmployeeTimeTemplateID = Row.GetDataKeyValue("EMP_TIME_TMPLT_ID")

                                            If EmployeeTimeTemplateID > 0 Then

                                                EmployeeTimeTemplate = AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.LoadByID(DbContext, EmployeeTimeTemplateID)

                                            End If
                                            If EmployeeTimeTemplate IsNot Nothing Then

                                                AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.Delete(DbContext, EmployeeTimeTemplate)

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End If

                                Next

                                Me.RadGridTimesheetTemplate.Rebind()

                            Catch ex As Exception
                            End Try

                        Case 3

                            Try

                                Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
                                Dim EmployeetimeStagingID As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing
                                Dim currentRowCount As Integer = 0
                                Dim gridDataItem As Telerik.Web.UI.GridDataItem = Nothing

                                currentRowCount = Me.RadGridTimesheetStaging.MasterTableView.Items().Count

                                For rowIndex As Integer = currentRowCount To 1 Step -1

                                    gridDataItem = Me.RadGridTimesheetStaging.MasterTableView.Items(rowIndex - 1)

                                    If gridDataItem.Selected Then

                                        EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, CType(gridDataItem.GetDataKeyValue("ID"), Integer))
                                        If EmployeeTimeStaging IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                                                EmployeetimeStagingID = New AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

                                                If Employee.CalendarTimeType = 1 Then
                                                    EmployeetimeStagingID.GoogleID = EmployeeTimeStaging.GoogleID
                                                ElseIf Employee.CalendarTimeType = 2 Then
                                                    EmployeetimeStagingID.OutlookID = EmployeeTimeStaging.OutlookID
                                                ElseIf Employee.CalendarTimeType = 3 Then
                                                    EmployeetimeStagingID.OutlookID = EmployeeTimeStaging.OutlookID
                                                End If

                                                EmployeetimeStagingID.GoogleID = EmployeeTimeStaging.GoogleID

                                                'AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.Insert(DbContext, EmployeetimeStagingID)
                                            End If

                                        End If


                                    End If

                                Next

                                Me.RadCalendarCopyToSelectedWeek.SelectedDates.Clear()
                                Me.RadGridTimesheetStaging.Rebind()

                            Catch ex As Exception
                            End Try

                    End Select

                End Using

            Case "UpdateCalendarTimeData"
                Me.UpdateCalendarTimeData(False)
            Case "Staging"
                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                Dim PastDays As Integer = -1
                Dim ErrorMessage As String = ""

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                        AdvantageFramework.Services.CalendarTimeSheetImport.ProcessGoogleCalendarTS(DbContext, DataContext, Agency, Now, Employee, False, PastDays, Nothing, Nothing, False, ErrorMessage)
                    End Using
                End Using
                Me.RadGridTimesheetStaging.Rebind()
            Case "Settings"
                Me.OpenWindow("Calendar Time Options", "Maintenance_CalendarTime.aspx", 500, 650)
        End Select
    End Sub
    Private Sub DropGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropGroupBy.SelectedIndexChanged
        Dim oAppVars As New cAppVars(cAppVars.Application.TIMESHEET)
        oAppVars.getAllAppVars()
        oAppVars.setAppVar("COPY_FROM_TEMPLATE_GROUP_BY", Me.DropGroupBy.SelectedValue.ToString(), "String")
        oAppVars.SaveAllAppVars()
        'Me.SetGrouping()
        Me.RadGridTimesheetTemplate.Rebind()
    End Sub

#Region " My Template Grid"

    'Private Function SaveGridRow(ByRef CurrentGridRow As Telerik.Web.UI.GridDataItem) As Boolean

    '    Try
    '        If Not CurrentGridRow Is Nothing Then
    '            Dim ThisFncCode As String = ""
    '            Dim ThisDpTmCode As String = ""
    '            Dim ThisProdCatCode As String = ""
    '            Dim ThisHours As Decimal = 0.0
    '            Dim ThisDaysToApply As String = ""
    '            Try
    '                ThisDpTmCode = DirectCast(CurrentGridRow.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue
    '            Catch ex As Exception
    '                ThisDpTmCode = ""
    '            End Try
    '            Try
    '                ThisProdCatCode = DirectCast(CurrentGridRow.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox).SelectedValue
    '            Catch ex As Exception
    '                ThisProdCatCode = ""
    '            End Try
    '            Try
    '                ThisHours = DirectCast(CurrentGridRow.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
    '            Catch ex As Exception
    '                ThisHours = 0.0
    '            End Try
    '            Try
    '                ThisDaysToApply = MiscFN.GetWeekString(DirectCast(CurrentGridRow.FindControl("CheckBoxListDays"), CheckBoxList))
    '            Catch ex As Exception
    '                ThisDaysToApply = ""
    '            End Try
    '            Try
    '                ThisFncCode = DirectCast(CurrentGridRow.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedValue
    '            Catch ex As Exception
    '                ThisFncCode = ""
    '            End Try

    '            tt.UpdateTemplateRecord(CType(CurrentGridRow.GetDataKeyValue("EMP_TIME_TMPLT_ID"), Integer), DirectCast(CurrentGridRow.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
    '                                                  ThisFncCode, ThisDpTmCode, ThisProdCatCode, ThisHours, ThisDaysToApply)
    '        End If
    '    Catch ex As Exception
    '    End Try

    'End Function
    Private Sub RadGridTimesheetTemplate_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTimesheetTemplate.ItemCommand
        Dim index As Integer = e.Item.ItemIndex

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing

        Select Case e.CommandName
            Case "SaveRow", "DeleteRow", "AddToTimesheet"
                If index > -1 Then
                    CurrentGridRow = DirectCast(RadGridTimesheetTemplate.Items(index), Telerik.Web.UI.GridDataItem)
                End If
        End Select

        Dim tt As New wvTimeSheet.TimeSheetTemplate()
        Select Case e.CommandName
            Case "SaveAll"
                Try
                    For Each gdi As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetTemplate.MasterTableView.Items
                        Dim ThisFncCode As String = ""
                        Dim ThisDpTmCode As String = ""
                        Dim ThisProdCatCode As String = ""
                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisDpTmCode = DirectCast(gdi.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisDpTmCode = ""
                        End Try
                        Try
                            ThisProdCatCode = DirectCast(gdi.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisProdCatCode = ""
                        End Try
                        Try
                            ThisHours = DirectCast(gdi.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = MiscFN.GetWeekString(DirectCast(gdi.FindControl("CheckBoxListDays"), CheckBoxList))
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Try
                            ThisFncCode = DirectCast(gdi.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        tt.UpdateTemplateRecord(CType(gdi.GetDataKeyValue("EMP_TIME_TMPLT_ID"), Integer), DirectCast(gdi.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
                                                      ThisFncCode, ThisDpTmCode, ThisProdCatCode, ThisHours, ThisDaysToApply)
                    Next
                Catch ex As Exception

                End Try
            Case "SaveRow"
                Try
                    If Not CurrentGridRow Is Nothing Then
                        Dim ThisFncCode As String = ""
                        Dim ThisDpTmCode As String = ""
                        Dim ThisProdCatCode As String = ""
                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisDpTmCode = DirectCast(CurrentGridRow.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisDpTmCode = ""
                        End Try
                        Try
                            ThisProdCatCode = DirectCast(CurrentGridRow.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisProdCatCode = ""
                        End Try
                        Try
                            ThisHours = DirectCast(CurrentGridRow.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = MiscFN.GetWeekString(DirectCast(CurrentGridRow.FindControl("CheckBoxListDays"), CheckBoxList))
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Try
                            ThisFncCode = DirectCast(CurrentGridRow.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        tt.UpdateTemplateRecord(CType(CurrentGridRow.GetDataKeyValue("EMP_TIME_TMPLT_ID"), Integer), DirectCast(CurrentGridRow.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
                                                      ThisFncCode, ThisDpTmCode, ThisProdCatCode, ThisHours, ThisDaysToApply)
                    End If
                Catch ex As Exception

                End Try
            Case "DeleteRow"
                Try
                    If Not CurrentGridRow Is Nothing Then
                        tt.DeleteFromTemplate(CType(CurrentGridRow.GetDataKeyValue("EMP_TIME_TMPLT_ID"), Integer))
                        Me.RadGridTimesheetTemplate.Rebind()
                    End If
                Catch ex As Exception

                End Try
            Case "AddToTimesheet"
                Try
                    If Me.StatusAllowsEdit = False Then Exit Sub
                    Dim s As String = ""
                    If Not CurrentGridRow Is Nothing Then
                        Dim j As Integer = 0
                        Dim jc As Integer = 0
                        Try
                            j = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                        Catch ex As Exception
                            j = 0
                        End Try
                        Try
                            jc = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            jc = 0
                        End Try
                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisHours = DirectCast(CurrentGridRow.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = MiscFN.GetWeekString(DirectCast(CurrentGridRow.FindControl("CheckBoxListDays"), CheckBoxList))
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Dim ThisFncCode As String = ""
                        Try
                            ThisFncCode = DirectCast(CurrentGridRow.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedValue
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        Me.SaveSelectedRowToTimesheet(ThisFncCode, DirectCast(CurrentGridRow.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue,
                                                      j, jc, True,
                                                      DirectCast(CurrentGridRow.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox).SelectedValue,
                                                      DirectCast(CurrentGridRow.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
                                                      ThisHours, ThisDaysToApply, s)
                        If s <> "" Then
                            Me.ShowMessage(s)
                        End If
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Private Sub RadGridTimesheetTemplate_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTimesheetTemplate.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then

            Dim dataItem As Telerik.Web.UI.GridHeaderItem = e.Item
            Dim ts As New cTimeSheet(Session("ConnString"))

            Try
                Dim chk As CheckBox
                chk = CType(dataItem("GridClientSelectColumn1").Controls(0), CheckBox)
                chk.Checked = True
            Catch ex As Exception
            End Try

            ts.GetTimesheetSettings(Session("UserCode"), , , ,
                                 ,
                                 ,
                                 "",
                                 "",
                                 "",
                                 _FuncCatAlias,
                                 "")

        End If

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim JobIsClosed As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("IS_CLOSED"), Integer))
            Dim HasAccessToFunction As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("HAS_ACCESS_TO_FUNCTION"), Integer))
            Try
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim chk As CheckBox
                chk = CType(dataItem("GridClientSelectColumn1").Controls(0), CheckBox)
                If JobIsClosed = True Or HasAccessToFunction = False Then
                    chk.Checked = False
                    chk.Enabled = False
                Else
                    chk.Checked = True
                    chk.Enabled = True
                End If
            Catch ex As Exception
            End Try
            Dim ddl As New Telerik.Web.UI.RadComboBox

            Dim IsTimeCategory As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("IS_TIME_CATEGORY"), Integer))

            ddl = CType(e.Item.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox)

            If IsTimeCategory = True Then

                CType(e.Item.FindControl("DivJobAndComponent"), HtmlControls.HtmlControl).Visible = False

            End If
            With ddl
                If IsTimeCategory = False Then
                    .DataSource = Me.DtFunctions
                Else
                    .DataSource = DtTimeCategories
                End If
                .DataTextField = "DescriptionOnly"
                .DataValueField = "Code"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            End With

            Try
                If IsDBNull(e.Item.DataItem("FNC_CODE")) = False Then
                    MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("FNC_CODE"), False)
                End If
            Catch ex As Exception
            End Try

            If JobIsClosed = True Or HasAccessToFunction = False Then
                ddl.Enabled = False
            End If

            Try

                Dim FuncCatAliasLabel As Label = e.Item.FindControl("LabelFuncCatAlias")

                If FuncCatAliasLabel IsNot Nothing AndAlso String.IsNullOrWhiteSpace(_FuncCatAlias) = False Then

                    FuncCatAliasLabel.Text = _FuncCatAlias
                    FuncCatAliasLabel.ToolTip = "Function/Category"

                End If

            Catch ex As Exception
            End Try

            ddl = CType(e.Item.FindControl("DropDept"), Telerik.Web.UI.RadComboBox)
            With ddl
                .DataSource = Me.DtEmployeeDepartments
                .DataTextField = "Description"
                .DataValueField = "Code"
                .DataBind()
            End With
            Dim HasDefaultDepartment As Boolean = False
            Try
                If ddl.Items.Count <= 1 Then
                    ddl.Enabled = False
                ElseIf ddl.Items.Count > 1 Then
                    For i As Integer = 0 To ddl.Items.Count - 1
                        If ddl.Items(i).Text.IndexOf("*") > -1 Then
                            ddl.Items(i).Selected = True
                            ddl.Items(i).Text = ddl.Items(i).Text.Replace("*", "")
                            HasDefaultDepartment = True
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(e.Item.DataItem("DP_TM_CODE")) = False And HasDefaultDepartment = False Then
                    MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("DP_TM_CODE"), False)
                End If
            Catch ex As Exception
            End Try
            If JobIsClosed = True Or HasAccessToFunction = False Then
                ddl.Enabled = False
            End If

            If CheckProductCategory() = True Then
                Dim ClCode As String = ""
                Dim DivCode As String = ""
                Dim PrdCode As String = ""
                Try
                    If IsDBNull(e.Item.DataItem("CL_CODE")) = False Then
                        ClCode = e.Item.DataItem("CL_CODE")
                    End If
                Catch ex As Exception
                    ClCode = ""
                End Try
                Try
                    If IsDBNull(e.Item.DataItem("DIV_CODE")) = False Then
                        DivCode = e.Item.DataItem("DIV_CODE")
                    End If
                Catch ex As Exception
                    DivCode = ""
                End Try
                Try
                    If IsDBNull(e.Item.DataItem("PRD_CODE")) = False Then
                        PrdCode = e.Item.DataItem("PRD_CODE")
                    End If
                Catch ex As Exception
                    PrdCode = ""
                End Try

                ddl = CType(e.Item.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox)
                With ddl
                    .DataSource = GetProductCategoryDS(ClCode, DivCode, PrdCode)
                    .DataTextField = "DescriptionOnly"
                    .DataValueField = "Code"
                    .DataBind()
                End With
                If IsDBNull(e.Item.DataItem("PROD_CAT_CODE")) = False Then
                    MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("PROD_CAT_CODE"), False)
                End If
                If JobIsClosed = True Or HasAccessToFunction = False Then
                    ddl.Enabled = False
                End If

            End If

            Try
                CType(e.Item.FindControl("ImageButtonDelete"), ImageButton).Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
            Catch ex As Exception
            End Try

            Try
                CType(e.Item.FindControl("ImageButtonAddToTimesheet"), ImageButton).ToolTip = "Click to add this row to current Timesheet"
            Catch ex As Exception
            End Try

            Try
                If IsDBNull(e.Item.DataItem("EMP_HOURS")) = False Then
                    CType(e.Item.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value = CType(e.Item.DataItem("EMP_HOURS"), Decimal)
                End If
            Catch ex As Exception
            End Try


            Try
                If IsDBNull(e.Item.DataItem("APPLY_TO_DAYS")) = False Then
                    MiscFN.SetWeekCheckboxList(CType(e.Item.FindControl("CheckBoxListDays"), CheckBoxList), e.Item.DataItem("APPLY_TO_DAYS"))
                End If
            Catch ex As Exception
            End Try

            If JobIsClosed = True Or HasAccessToFunction = False Then

                Dim Div As HtmlControls.HtmlControl

                Div = e.Item.FindControl("DivSave")
                If Div IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(Div)

                Div = e.Item.FindControl("DivAddToTimesheet")
                If Div IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(Div)

                CType(e.Item.FindControl("TextBoxDefaultComment"), TextBox).Enabled = False
                CType(e.Item.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Enabled = False

            End If

        End If

    End Sub
    Private Sub RadGridTimesheetTemplate_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTimesheetTemplate.NeedDataSource
        Me.SetDropDownListsDatasources()
        Dim tt As New wvTimeSheet.TimeSheetTemplate()
        Me.RadGridTimesheetTemplate.DataSource = tt.GetTemplate(Me.CurrEmp)
        Me.RadGridTimesheetTemplate.MasterTableView.GetColumn("GridTemplateColumnProdCat").Display = CheckProductCategory()

        Me.SetGrouping()

    End Sub
    Private _FuncCatAlias As String = String.Empty
    Private Sub RadGridTimesheetTemplate_PreRender(sender As Object, e As System.EventArgs) Handles RadGridTimesheetTemplate.PreRender

        Dim header As GridHeaderItem = TryCast(RadGridTimesheetTemplate.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
        Dim ts As New cTimeSheet(Session("ConnString"))
        Dim JobAlias As String = String.Empty
        Dim ComponentAlias As String = String.Empty

        ts.GetTimesheetSettings(Session("UserCode"), , , ,
                                 ,
                                 ,
                                 header("GridTemplateColumnProdCat").Text,
                                 JobAlias,
                                 ComponentAlias,
                                 _FuncCatAlias,
                                 "")

        If String.IsNullOrWhiteSpace(_FuncCatAlias) = True Then _FuncCatAlias = "Func/Cat"
        header("GridTemplateColumnJobAndComponent").Text = JobAlias & "<br />" & ComponentAlias

    End Sub

    Public Sub RadComboBoxFunctionCategory_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

    End Sub
    Public Sub RadComboBoxDepartment_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

    End Sub
    Public Sub CheckBoxListDays_SelectedIndexChanged(sender As Object, e As EventArgs)

        Try

            Dim cbl As CheckBoxList = CType(sender, CheckBoxList)

            If cbl IsNot Nothing Then

                Dim cgr As Telerik.Web.UI.GridDataItem = DirectCast(cbl.Parent.Parent, Telerik.Web.UI.GridDataItem)

                If cgr IsNot Nothing Then

                    Dim EmployeeTimeTemplateID As Integer = CType(cgr.GetDataKeyValue("EMP_TIME_TMPLT_ID"), Integer)

                    If EmployeeTimeTemplateID > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate = Nothing

                            EmployeeTimeTemplate = AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.LoadByID(DbContext, EmployeeTimeTemplateID)

                            If EmployeeTimeTemplate IsNot Nothing Then

                                Dim ThisDaysToApply As String = String.Empty
                                Dim GotDays As Boolean = True

                                Try

                                    ThisDaysToApply = MiscFN.GetWeekString(DirectCast(cbl, CheckBoxList))

                                Catch ex As Exception
                                    GotDays = False
                                End Try

                                If GotDays = True Then

                                    EmployeeTimeTemplate.ApplyToDays = ThisDaysToApply

                                    If AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.Update(DbContext, EmployeeTimeTemplate) Then

                                        'Me.RadGridTimesheetTemplate.Rebind()

                                    End If

                                End If

                            End If

                        End Using

                    End If

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " My Timesheet Staging"

    Private Sub RadGridTimesheetStaging_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTimesheetStaging.NeedDataSource

        Dim Department As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing

        Me.SetDropDownListsDatasources()
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            Me.RadGridTimesheetStaging.DataSource = AdvantageFramework.EmployeeCalendarTime.LoadEmployeeTimeStaging(DbContext, Me.CurrEmp).ToList
            'Me.RadGridTimesheetStaging.DataSource = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByEmployeeCode(DbContext, Me.CurrEmp).ToList
            'Me.RadGridTimesheetStaging.DataSource = (From a In AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByEmployeeCode(DbContext, Me.CurrEmp)
            '                                         Join p In Department On a.DepartmentCode Equals p.Code
            '                                         Select New With {.ID = a.ID,
            '                                                         .StartDate = a.StartDate,
            '                                                         .EndDate = a.EndDate,
            '                                                         .StartTime = a.StartTime,
            '                                                         .EndTime = a.EndTime,
            '                                                         .Hours = a.Hours,
            '                                                         .EmployeeCode = a.EmployeeCode,
            '                                                         .OutlookID = a.OutlookID,
            '                                                         .GoogleID = a.GoogleID,
            '                                                         .CalendarID = a.CalendarID,
            '                                                         .Comments = a.Comments,
            '                                                         .JobNumber = a.JobNumber,
            '                                                         .JobComponentNumber = a.JobComponentNumber,
            '                                                         .ClientCode = a.ClientCode,
            '                                                         .DivisionCode = a.DivisionCode,
            '                                                         .ProductCode = a.ProductCode,
            '                                                         .FunctionCode = a.FunctionCode,
            '                                                         .DepartmentCode = a.DepartmentCode,
            '                                                         .DepartmentName = p.Description,
            '                                                         .ProductCategoryCode = a.ProductCategoryCode}).ToList()

            Me.RadGridTimesheetStaging.MasterTableView.GetColumn("GridBoundColumnProductCategory").Display = CheckProductCategory()
        End Using

        Me.SetGrouping()

    End Sub
    Private Sub RadGridTimesheetStaging_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridTimesheetStaging.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then
            Dim dataItem As Telerik.Web.UI.GridHeaderItem = e.Item
            Try
                Dim chk As CheckBox
                chk = CType(dataItem("GridClientSelectColumn1").Controls(0), CheckBox)
                chk.Checked = True
            Catch ex As Exception
            End Try
        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
            'Dim JobIsClosed As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("IS_CLOSED"), Integer))
            'Dim HasAccessToFunction As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("HAS_ACCESS_TO_FUNCTION"), Integer))
            'Try

            '    Dim chk As CheckBox
            '    chk = CType(dataItem("GridClientSelectColumn1").Controls(0), CheckBox)
            '    If JobIsClosed = True Or HasAccessToFunction = False Then
            '        chk.Checked = False
            '        chk.Enabled = False
            '    Else
            '        chk.Checked = True
            '        chk.Enabled = True
            '    End If
            'Catch ex As Exception
            'End Try
            Dim ddl As New Telerik.Web.UI.RadComboBox

            'Dim IsTimeCategory As Boolean = MiscFN.IntToBool(CType(e.Item.DataItem("IS_TIME_CATEGORY"), Integer))
            Dim Tb As TextBox = CType(e.Item.FindControl("TextBox_FunctionCategory"), TextBox)

            'ddl = CType(e.Item.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox)
            'With ddl
            '    If IsTimeCategory = False Then
            '        .DataSource = Me.DtFunctions
            '    Else
            '        .DataSource = DtTimeCategories
            '    End If
            '    .DataTextField = "DescriptionOnly"
            '    .DataValueField = "Code"
            '    .DataBind()
            '    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            'End With
            Dim str As String = dataItem.GetDataKeyValue("FunctionCode")
            If dataItem.GetDataKeyValue("FunctionCode") IsNot Nothing Then
                Try
                    Tb.Text = dataItem.GetDataKeyValue("FunctionCode")
                Catch ex As Exception
                End Try
            Else
                Try
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        Dim emp As AdvantageFramework.Database.Views.Employee = Nothing
                        emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)
                        If emp IsNot Nothing Then
                            If emp.FunctionCode IsNot Nothing And emp.FunctionCode <> "" Then
                                Tb.Text = emp.FunctionCode
                            End If
                        End If
                    End Using
                Catch ex As Exception
                End Try
            End If

            'If JobIsClosed = True Or HasAccessToFunction = False Then
            'ddl.Enabled = False
            'End If

            Tb = CType(e.Item.FindControl("TextBox_JobCode"), TextBox)
            If Tb.Text = "0" Then
                Tb.Text = ""
            End If

            Tb = CType(e.Item.FindControl("TextBox_ComponentCode"), TextBox)
            If Tb.Text = "0" Then
                Tb.Text = ""
            End If


            ddl = CType(e.Item.FindControl("DropDept"), Telerik.Web.UI.RadComboBox)
            With ddl
                .DataSource = Me.DtEmployeeDepartments
                .DataTextField = "Description"
                .DataValueField = "Code"
                .DataBind()
            End With
            Dim HasDefaultDepartment As Boolean = False
            Try
                If ddl.Items.Count <= 1 Then
                    ddl.Enabled = False
                ElseIf ddl.Items.Count > 1 Then
                    For i As Integer = 0 To ddl.Items.Count - 1
                        If ddl.Items(i).Text.IndexOf("*") > -1 Then
                            ddl.Items(i).Selected = True
                            ddl.Items(i).Text = ddl.Items(i).Text.Replace("*", "")
                            HasDefaultDepartment = True
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            Try
                If dataItem.GetDataKeyValue("DepartmentCode") IsNot Nothing Then
                    MiscFN.RadComboBoxSetIndex(ddl, dataItem.GetDataKeyValue("DepartmentCode"), False)
                End If
            Catch ex As Exception
            End Try
            'If JobIsClosed = True Or HasAccessToFunction = False Then
            'ddl.Enabled = False
            'End If

            'Dim label As Label
            'label = CType(e.Item.FindControl("LabelStartDate"), Label)
            'label.Text = CDate(label.Text).ToShortDateString

            Dim required As New cRequired(Session("ConnString"))

            If CheckProductCategory() = True Then
                'Try
                '    If required.ProductCategoryRequired(ClCode) = True Then
                '        Tb = CType(e.Item.FindControl("TextBoxDefaultComment"), TextBox)
                '        Tb.CssClass = "RequiredInput"
                '    End If
                'Catch ex As Exception

                'End Try

                '    Dim ClCode As String = ""
                '    Dim DivCode As String = ""
                '    Dim PrdCode As String = ""
                '    Try
                '        If IsDBNull(e.Item.DataItem("CL_CODE")) = False Then
                '            ClCode = e.Item.DataItem("CL_CODE")
                '        End If
                '    Catch ex As Exception
                '        ClCode = ""
                '    End Try
                '    Try
                '        If IsDBNull(e.Item.DataItem("DIV_CODE")) = False Then
                '            DivCode = e.Item.DataItem("DIV_CODE")
                '        End If
                '    Catch ex As Exception
                '        DivCode = ""
                '    End Try
                '    Try
                '        If IsDBNull(e.Item.DataItem("PRD_CODE")) = False Then
                '            PrdCode = e.Item.DataItem("PRD_CODE")
                '        End If
                '    Catch ex As Exception
                '        PrdCode = ""
                '    End Try

                '    ddl = CType(e.Item.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox)
                '    With ddl
                '        .DataSource = GetProductCategoryDS(ClCode, DivCode, PrdCode)
                '        .DataTextField = "DescriptionOnly"
                '        .DataValueField = "Code"
                '        .DataBind()
                '    End With
                '    If IsDBNull(e.Item.DataItem("PROD_CAT_CODE")) = False Then
                '        MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("PROD_CAT_CODE"), False)
                '    End If
                '    If JobIsClosed = True Or HasAccessToFunction = False Then
                '        ddl.Enabled = False
                '    End If

            End If

            Try
                CType(e.Item.FindControl("ImageButtonDelete"), ImageButton).Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
            Catch ex As Exception
            End Try

            Try
                CType(e.Item.FindControl("ImageButtonAddToTimesheet"), ImageButton).ToolTip = "Click to add this row to current Timesheet"
            Catch ex As Exception
            End Try

            Try
                If IsDBNull(dataItem.GetDataKeyValue("Hours")) = False Then
                    CType(e.Item.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value = CType(dataItem.GetDataKeyValue("Hours"), Decimal)
                End If
            Catch ex As Exception
            End Try

            Try
                If IsDBNull(dataItem.GetDataKeyValue("StartDate")) = False Then
                    CType(e.Item.FindControl("RadDatePickerItemTemplate_StartDate"), Telerik.Web.UI.RadDatePicker).SelectedDate = CType(dataItem.GetDataKeyValue("StartDate"), Date)
                End If
            Catch ex As Exception

            End Try

            Try
                If required.RequiredTimesheetComments = True Then

                    Tb = CType(e.Item.FindControl("TextBoxDefaultComment"), TextBox)
                    Tb.CssClass = "RequiredInput"

                End If
            Catch ex As Exception
            End Try



            'If JobIsClosed = True Or HasAccessToFunction = False Then

            '    Dim Div As HtmlControls.HtmlControl

            '    Div = e.Item.FindControl("DivSave")
            '    If Div IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(Div)

            '    Div = e.Item.FindControl("DivAddToTimesheet")
            '    If Div IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(Div)

            '    'CType(e.Item.FindControl("TextBoxDefaultComment"), TextBox).Enabled = False
            '    'CType(e.Item.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Enabled = False

            'End If

        End If
    End Sub
    Private Sub RadGridTimesheetStaging_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridTimesheetStaging.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing
        Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
        Dim EmployeetimeStagingID As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing

        Select Case e.CommandName
            Case "SaveRow", "DeleteRow", "AddToTimesheet"
                If index > -1 Then
                    CurrentGridRow = DirectCast(RadGridTimesheetStaging.Items(index), Telerik.Web.UI.GridDataItem)
                End If
        End Select

        Select Case e.CommandName
            Case "DeleteRow"
                Try
                    If Not CurrentGridRow Is Nothing Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, CType(CurrentGridRow.GetDataKeyValue("ID"), Integer))
                            If EmployeeTimeStaging IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                                    EmployeetimeStagingID = New AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs
                                    EmployeetimeStagingID.GoogleID = EmployeeTimeStaging.GoogleID

                                    'AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.Insert(DbContext, EmployeetimeStagingID)
                                End If

                            End If

                        End Using
                        Me.RadCalendarCopyToSelectedWeek.SelectedDates.Clear()
                        Me.RadGridTimesheetStaging.Rebind()
                    End If
                Catch ex As Exception

                End Try
            Case "AddToTimesheet"
                Try
                    If Me.StatusAllowsEdit = False Then Exit Sub
                    Dim s As String = ""
                    If Not CurrentGridRow Is Nothing Then
                        Dim j As Integer = 0
                        Dim jc As Integer = 0
                        Try
                            j = DirectCast(CurrentGridRow.FindControl("TextBox_JobCode"), TextBox).Text
                        Catch ex As Exception
                            j = 0
                        End Try
                        Try
                            jc = DirectCast(CurrentGridRow.FindControl("TextBox_ComponentCode"), TextBox).Text
                        Catch ex As Exception
                            jc = 0
                        End Try
                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisHours = DirectCast(CurrentGridRow.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                            Me._IncludeHours = True
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = CType(CurrentGridRow.GetDataKeyValue("StartDate"), DateTime).DayOfWeek
                            If ThisDaysToApply = 0 Then
                                ThisDaysToApply = "Sun"
                            ElseIf ThisDaysToApply = 1 Then
                                ThisDaysToApply = "Mon"
                            ElseIf ThisDaysToApply = 2 Then
                                ThisDaysToApply = "Tue"
                            ElseIf ThisDaysToApply = 3 Then
                                ThisDaysToApply = "Wed"
                            ElseIf ThisDaysToApply = 4 Then
                                ThisDaysToApply = "Thu"
                            ElseIf ThisDaysToApply = 5 Then
                                ThisDaysToApply = "Fri"
                            ElseIf ThisDaysToApply = 6 Then
                                ThisDaysToApply = "Sat"
                            End If
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Dim ThisFncCode As String = ""
                        Try
                            ThisFncCode = DirectCast(CurrentGridRow.FindControl("TextBox_FunctionCategory"), TextBox).Text
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        If ThisFncCode = "" Then
                            Me.ShowMessage("Function Code is required.")
                            Exit Sub
                        End If
                        Me.SaveSelectedRowToTimesheetStaging(ThisFncCode, DirectCast(CurrentGridRow.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue,
                                                      j, jc, True,
                                                      DirectCast(CurrentGridRow.FindControl("TextBox_ProductCategory"), TextBox).Text,
                                                      DirectCast(CurrentGridRow.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
                                                      ThisHours, ThisDaysToApply, s)
                        If s <> "" Then
                            Me.ShowMessage(s)
                        Else
                            If Not CurrentGridRow Is Nothing Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, CType(CurrentGridRow.GetDataKeyValue("ID"), Integer))
                                    If EmployeeTimeStaging IsNot Nothing Then
                                        If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                                            EmployeetimeStagingID = New AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs
                                            EmployeetimeStagingID.GoogleID = EmployeeTimeStaging.GoogleID

                                            AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.Insert(DbContext, EmployeetimeStagingID)
                                        End If
                                    End If

                                End Using

                                Me.RadGridTimesheetStaging.Rebind()

                                Me.RefreshCaller("Timesheet.aspx")

                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
        End Select

    End Sub
    Private Sub RadGridTimesheetStaging_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridTimesheetStaging.ItemCreated
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then

                TextBox = GridDataItem.FindControl("TextBox_ClientCode")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "Client")
                End If

                TextBox = GridDataItem.FindControl("TextBox_DivisionCode")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "Division")
                End If

                TextBox = GridDataItem.FindControl("TextBox_ProductCode")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "Product")
                End If

                TextBox = GridDataItem.FindControl("TextBox_JobCode")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "Job")
                End If

                TextBox = GridDataItem.FindControl("TextBox_ComponentCode")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "JobComponent")
                End If

                TextBox = GridDataItem.FindControl("TextBox_ProductCategory")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "ProductCategory")
                End If

                TextBox = GridDataItem.FindControl("TextBox_FunctionCategory")
                If TextBox IsNot Nothing Then
                    TextBox.Attributes.Add("adv-lookup", "FunctionCategory")
                End If

            End If

        End If
    End Sub
    Private Sub ButtonGetTime_Click(sender As Object, e As EventArgs) Handles ButtonGetTime.Click
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim PastDays As Integer = -13

        Dim startdate As DateTime
        Dim enddate As DateTime

        Dim timeSheet As New cTimeSheet(Session("ConnString"))
        Dim ErrorMessage As String = ""
        Dim port As Integer = 0

        'timeSheet.GetDateRange(Me.RadCalendarCopyToSelectedWeek.SelectedDate, startdate, enddate)
        If Me.RadCalendarCopyToSelectedWeek.SelectedDate.ToShortDateString <> "1/1/0001" Then

            startdate = Me.RadCalendarCopyToSelectedWeek.RangeSelectionStartDate

            If startdate.ToShortDateString <> "" Then
                enddate = Me.RadCalendarCopyToSelectedWeek.RangeSelectionEndDate
            Else
                startdate = Now.Date
                enddate = Now.Date.AddDays(1)
            End If

            If startdate > enddate Then
                startdate = Now.Date
                enddate = Now.Date.AddDays(1)
            End If

            If enddate.ToShortDateString = "12/30/2099" Then
                enddate = startdate
            End If

        Else
            startdate = Now.Date
            enddate = Now.Date.AddDays(1)
        End If

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                If Employee.CalendarTimeType = 1 Or Employee.CalendarTimeType = 2 Or Employee.CalendarTimeType = 3 Then

                    If Employee.CalendarTimeEmailAddress Is Nothing Then
                        Me.ShowMessage("Calendar settings must be entered before this feature will work.")
                        Exit Sub
                    ElseIf Employee.GoogleToken Is Nothing And Employee.CalendarTimeType = 1 Then
                        Me.ShowMessage("Google Services must be enabled before this feature will work.")
                        Exit Sub
                    End If

                Else

                    Me.ShowMessage("Calendar settings must be entered before this feature will work.")
                    Exit Sub

                End If

                If Employee.CalendarTimePort IsNot Nothing Then
                    port = Employee.CalendarTimePort
                End If


                If Employee.CalendarTimeType = 1 Then
                    AdvantageFramework.Services.CalendarTimeSheetImport.ProcessGoogleCalendarTS(DbContext, DataContext, Agency, Now, Employee, False, PastDays, startdate, CDate(enddate.ToShortDateString & " 23:59:59"), Me.CheckBoxOnlyRT.Checked, ErrorMessage)
                ElseIf Employee.CalendarTimeType = 2 Then
                    AdvantageFramework.CalendarImportServices.Outlook.ProcessOutlookExchangeTS(DbContext, DataContext, _Session.UserCode, Employee, False, Agency.StandardHours.GetValueOrDefault(0), PastDays, startdate, CDate(enddate.ToShortDateString & " 23:59:59"), Me.CheckBoxOnlyRT.Checked, ErrorMessage)
                ElseIf Employee.CalendarTimeType = 3 Then
                    AdvantageFramework.CalendarImportServices.CalendarApp.ProcessOutlookTS(Employee.CalendarTimeHost, Employee.CalendarTimeSSL, Employee.CalendarTimeUserName, Employee.CalendarTimePassword, _Session, Employee, Agency.StandardHours.GetValueOrDefault(0), startdate, enddate.AddDays(1), port, ErrorMessage)
                End If

                If ErrorMessage <> "" Then
                    Me.ShowMessage(ErrorMessage)
                    Exit Sub
                End If

                Me.RadCalendarCopyToSelectedWeek.SelectedDates.Clear()

            End Using
        End Using
        Me.RadGridTimesheetStaging.Rebind()
    End Sub


#End Region

#End Region

#Region " Methods "

    Private Sub SetDropDownListsDatasources()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        If Me.DtFunctions.Rows.Count = 0 Then
            Me.DtFunctions = odd.GetFunctionsByEmpCodeDT(CurrEmp)
        End If
        If Me.DtTimeCategories.Rows.Count = 0 Then
            Me.DtTimeCategories = odd.GetCategoriesDT()
        End If
        If Me.DtEmployeeDepartments.Rows.Count = 0 Then
            Me.DtEmployeeDepartments = odd.GetDeptsByEmpCodeWithDefault(Me.CurrEmp)
        End If
    End Sub
    Private Sub SwitchViews(ByVal ViewIndex As Integer)
        Dim oAppVars As New cAppVars(cAppVars.Application.TIMESHEET)
        oAppVars.getAllAppVars()
        MiscFN.RadComboBoxSetIndex(Me.DropGroupBy, oAppVars.getAppVar("COPY_FROM_TEMPLATE_GROUP_BY", "String", ""), False)
        Select Case ViewIndex
            Case 2 'My Template

                Me.PageTitle = "Copy from My Templates"
                Me.RadGridTimesheetTemplate.Rebind()

            Case 3 'My Calendar Time

                Me.PageTitle = "Copy from My Calendars"
                Me.RadGridTimesheetStaging.Rebind()

        End Select

        Me.RadToolbarCopyFrom.FindItemByValue("NewTemplateItem").Visible = ViewIndex = 2
        'Me.RadToolbarCopyFrom.FindItemByValue("Delete").Visible = ViewIndex = 2
        Me.RadToolbarCopyFrom.FindItemByValue("UpdateCalendarTimeData").Visible = ViewIndex = 3
        Me.RadToolbarCopyFrom.FindItemByValue("GetCalendarTime").Visible = ViewIndex = 3
        Me.RadToolbarCopyFrom.FindItemByValue("Settings").Visible = ViewIndex = 3

        Me.MultiViewCopyFrom.ActiveViewIndex = ViewIndex

    End Sub
    Private Function StatusAllowsEdit() As Boolean
        Dim SelectedDate As Date
        Dim SelectedETID As Integer = 0
        Dim SelectedEditStatus As AdvantageFramework.Timesheet.TimesheetEditType
        Dim SelectedClosedPP As Boolean = False
        Dim ReturnValue As Boolean = True

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim msg As String = ""

        SelectedEditStatus = oTS.CheckEditStatus(Me.CurrEmp, SelectedDate)
        SelectedClosedPP = oTS.PostPeriodClosed(SelectedDate)

        Select Case SelectedEditStatus

            Case AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval

                msg = SelectedDate.DayOfWeek.ToString() & " is pending approval and cannot be edited"
                ReturnValue = False

            Case AdvantageFramework.Timesheet.TimesheetEditType.Approved

                msg = SelectedDate.DayOfWeek.ToString() & " is approved and cannot be edited"
                ReturnValue = False

        End Select

        If ReturnValue = False Then
            Me.ShowMessage(msg)
        End If

        Return ReturnValue

    End Function
    Private Sub AddTimeSheet()
        Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
        Dim EmployeetimeStagingID As AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetStaging.MasterTableView.Items
                If Me.StatusAllowsEdit = False Then Exit Sub
                Dim s As String = ""
                If gridDataItem.Selected Then
                    If Not gridDataItem Is Nothing Then
                        Dim j As Integer = 0
                        Dim jc As Integer = 0
                        Try
                            j = DirectCast(gridDataItem.FindControl("TextBox_JobCode"), TextBox).Text
                        Catch ex As Exception
                            j = 0
                        End Try
                        Try
                            jc = DirectCast(gridDataItem.FindControl("TextBox_ComponentCode"), TextBox).Text
                        Catch ex As Exception
                            jc = 0
                        End Try
                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisHours = DirectCast(gridDataItem.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                            Me._IncludeHours = True
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = CType(gridDataItem.GetDataKeyValue("StartDate"), DateTime).DayOfWeek
                            If ThisDaysToApply = 0 Then
                                ThisDaysToApply = "Sun"
                            ElseIf ThisDaysToApply = 1 Then
                                ThisDaysToApply = "Mon"
                            ElseIf ThisDaysToApply = 2 Then
                                ThisDaysToApply = "Tue"
                            ElseIf ThisDaysToApply = 3 Then
                                ThisDaysToApply = "Wed"
                            ElseIf ThisDaysToApply = 4 Then
                                ThisDaysToApply = "Thu"
                            ElseIf ThisDaysToApply = 5 Then
                                ThisDaysToApply = "Fri"
                            ElseIf ThisDaysToApply = 6 Then
                                ThisDaysToApply = "Sat"
                            End If
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Dim ThisFncCode As String = ""
                        Try
                            ThisFncCode = DirectCast(gridDataItem.FindControl("TextBox_FunctionCategory"), TextBox).Text
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        If ThisFncCode = "" Then
                            Me.ShowMessage("Function Code is required.")
                            Exit Sub
                        End If

                        Try
                            Dim required As New cRequired(Session("ConnString"))

                            If DirectCast(gridDataItem.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim() = "" And required.RequiredTimesheetComments = True Then
                                Me.ShowMessage("Comments are required.")
                                Exit Sub
                            End If
                        Catch ex As Exception
                        End Try

                        Me.SaveSelectedRowToTimesheetStaging(ThisFncCode, DirectCast(gridDataItem.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue,
                                                      j, jc, True, CType(gridDataItem.GetDataKeyValue("StartDate"), DateTime),
                                                      DirectCast(gridDataItem.FindControl("TextBox_ProductCategory"), TextBox).Text,
                                                      DirectCast(gridDataItem.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim(),
                                                      ThisHours, ThisDaysToApply, s)
                        If s <> "" Then
                            Me.ShowMessage(s)
                        Else
                            If Not gridDataItem Is Nothing Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, CType(gridDataItem.GetDataKeyValue("ID"), Integer))
                                    If EmployeeTimeStaging IsNot Nothing Then
                                        If AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Delete(DbContext, EmployeeTimeStaging) Then

                                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.CurrEmp)

                                            EmployeetimeStagingID = New AdvantageFramework.Database.Entities.EmployeeTimeStagingIDs

                                            If Employee.CalendarTimeType = 1 Then
                                                EmployeetimeStagingID.GoogleID = EmployeeTimeStaging.GoogleID
                                            ElseIf Employee.CalendarTimeType = 2 Then
                                                EmployeetimeStagingID.OutlookID = EmployeeTimeStaging.OutlookID
                                            ElseIf Employee.CalendarTimeType = 3 Then
                                                EmployeetimeStagingID.OutlookID = EmployeeTimeStaging.OutlookID
                                            End If

                                            AdvantageFramework.Database.Procedures.EmployeeTimeStagingIDs.Insert(DbContext, EmployeetimeStagingID)
                                        End If
                                    End If

                                End Using

                            End If
                        End If
                    End If
                End If
            Next

            Me.RadGridTimesheetStaging.Rebind()

            Me.RefreshCaller("Timesheet.aspx")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdateTimeSheet()

        Dim JobNum As String = ""
        Dim JobCompNum As String = ""
        Dim FuncCat As String = ""
        Dim ProdCat As String = ""
        Dim Dept As String = ""
        Dim HiddenField_HoursMonday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursTuesday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursWednesday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursThursday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursFriday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursSaturday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenField_HoursSunday As System.Web.UI.WebControls.HiddenField = Nothing
        Dim ThisHours As Decimal = 0.0
        Dim ThisDaysToApply As String = ""
        Dim SbError As New System.Text.StringBuilder
        Dim s As String = ""
        Dim chk As CheckBox

        Me.CheckPostPeriod()

        Select Case Me.MultiViewCopyFrom.ActiveViewIndex

            Case 2

                If Me.StatusAllowsEdit = False Then

                    Exit Sub

                End If
                For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetTemplate.MasterTableView.Items

                    chk = CType(CurrentGridRow("GridClientSelectColumn1").Controls(0), CheckBox)

                    If chk.Checked = True Then

                        If CheckProductCategory() = True Then

                            ProdCat = CType(CurrentGridRow.FindControl("DropProdCat"), Telerik.Web.UI.RadComboBox).SelectedValue

                        Else

                            ProdCat = ""

                        End If
                        Try

                            JobNum = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)

                        Catch ex As Exception

                            JobNum = 0

                        End Try
                        Try

                            JobCompNum = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)

                        Catch ex As Exception

                            JobCompNum = 0

                        End Try

                        If CType(CurrentGridRow.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedIndex > 0 Then

                            FuncCat = CType(CurrentGridRow.FindControl("DropFNC_CODE"), Telerik.Web.UI.RadComboBox).SelectedValue

                        Else

                            FuncCat = ""

                        End If

                        Dept = CType(CurrentGridRow.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue

                        Dim Comment As String

                        Comment = CType(CurrentGridRow.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim()


                        Try

                            ThisHours = DirectCast(CurrentGridRow.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value

                        Catch ex As Exception

                            ThisHours = 0.0

                        End Try
                        Try

                            ThisDaysToApply = MiscFN.GetWeekString(DirectCast(CurrentGridRow.FindControl("CheckBoxListDays"), CheckBoxList))

                        Catch ex As Exception

                            ThisDaysToApply = ""

                        End Try

                        Me.SaveSelectedRowToTimesheet(FuncCat, Dept, JobNum, JobCompNum, False, ProdCat, Comment, ThisHours, ThisDaysToApply, s)
                        If s <> "" AndAlso SbError.ToString().Contains(s) = False Then SbError.Append(s)

                    End If
                Next
        End Select

        Dim URL As String = "Timesheet.aspx?dto=0&empcode=" & Me.CurrEmp

        s = SbError.ToString()
        If s.Trim() <> "" Then Me.ShowMessage(s)

        Try

            If Not Request.QueryString("FromWindow") Is Nothing Then

                URL = "Timesheet.aspx?dto=0&FromWindow=" & Request.QueryString("FromWindow").ToString() & "&empcode=" & Me.CurrEmp

            End If
        Catch ex As Exception

        End Try

        Me.CloseThisWindowAndRefreshCaller(URL, True, True)

    End Sub
    Private Sub UpdateCalendarTimeData(ByVal Adding As Boolean)
        Try
            Dim EmployeeTimeStaging As AdvantageFramework.Database.Entities.EmployeeTimeStaging = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim s As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridTimesheetStaging.MasterTableView.Items
                    If Not gridDataItem Is Nothing Then
                        Dim clientcode As String = ""
                        Dim divisioncode As String = ""
                        Dim productcode As String = ""

                        Dim j As Integer = 0
                        Dim jc As Integer = 0
                        Try
                            j = DirectCast(gridDataItem.FindControl("TextBox_JobCode"), TextBox).Text
                        Catch ex As Exception
                            j = 0
                        End Try
                        Try
                            jc = DirectCast(gridDataItem.FindControl("TextBox_ComponentCode"), TextBox).Text
                        Catch ex As Exception
                            jc = 0
                        End Try

                        If j <> 0 Then
                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, j)
                            If Job IsNot Nothing Then
                                clientcode = Job.ClientCode
                                divisioncode = Job.DivisionCode
                                productcode = Job.ProductCode
                            End If
                        End If

                        Dim ThisHours As Decimal = 0.0
                        Dim ThisDaysToApply As String = ""
                        Try
                            ThisHours = DirectCast(gridDataItem.FindControl("RadNumericTextBoxHours"), Telerik.Web.UI.RadNumericTextBox).Value
                            Me._IncludeHours = True
                        Catch ex As Exception
                            ThisHours = 0.0
                        End Try
                        Try
                            ThisDaysToApply = CType(gridDataItem.GetDataKeyValue("StartDate"), DateTime).DayOfWeek
                            If ThisDaysToApply = 0 Then
                                ThisDaysToApply = "Sun"
                            ElseIf ThisDaysToApply = 1 Then
                                ThisDaysToApply = "Mon"
                            ElseIf ThisDaysToApply = 2 Then
                                ThisDaysToApply = "Tue"
                            ElseIf ThisDaysToApply = 3 Then
                                ThisDaysToApply = "Wed"
                            ElseIf ThisDaysToApply = 4 Then
                                ThisDaysToApply = "Thu"
                            ElseIf ThisDaysToApply = 5 Then
                                ThisDaysToApply = "Fri"
                            ElseIf ThisDaysToApply = 6 Then
                                ThisDaysToApply = "Sat"
                            End If
                        Catch ex As Exception
                            ThisDaysToApply = ""
                        End Try
                        Dim ThisFncCode As String = ""
                        Try
                            ThisFncCode = DirectCast(gridDataItem.FindControl("TextBox_FunctionCategory"), TextBox).Text
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        If ThisFncCode = "" Then
                            Me.ShowMessage("Function Code is required.")
                            Exit Sub
                        End If

                        'Try
                        '    Dim required As New cRequired(Session("ConnString"))

                        '    If DirectCast(gridDataItem.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim() = "" And required.RequiredTimesheetComments = True Then
                        '        Me.ShowMessage("Comments are required.")
                        '        Exit Sub
                        '    End If
                        'Catch ex As Exception

                        'End Try

                        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                        If oTS.ValidateInfoCalendarTime(Me.CurrEmp, clientcode, divisioncode, productcode, j, jc, ThisFncCode, DirectCast(gridDataItem.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue, DirectCast(gridDataItem.FindControl("TextBox_ProductCategory"), TextBox).Text, s) = False Then

                            If s.Contains("Job") Then
                                gridDataItem.FindControl("TextBox_JobCode").Focus()
                            ElseIf s.Contains("Component") Then
                                gridDataItem.FindControl("TextBox_ComponentCode").Focus()
                            ElseIf s.Contains("Func") Then
                                gridDataItem.FindControl("TextBox_FunctionCategory").Focus()
                            End If

                        End If

                        If DirectCast(gridDataItem.FindControl("RadDatePickerItemTemplate_StartDate"), Telerik.Web.UI.RadDatePicker).SelectedDate.HasValue = False Then
                            s = s & vbCrLf & "Date is required."
                            gridDataItem.FindControl("RadDatePickerItemTemplate_StartDate").Focus()
                        End If

                        If s <> "" Then
                            _Saved = False
                            Me.ShowMessage(s)
                            Exit Sub
                        End If

                        EmployeeTimeStaging = AdvantageFramework.Database.Procedures.EmployeeTimeStaging.LoadByID(DbContext, CType(gridDataItem.GetDataKeyValue("ID"), Integer))

                        If EmployeeTimeStaging IsNot Nothing Then
                            With EmployeeTimeStaging
                                .ClientCode = clientcode
                                .DivisionCode = divisioncode
                                .ProductCode = productcode
                                .JobNumber = j
                                .JobComponentNumber = jc
                                .FunctionCode = ThisFncCode
                                .DepartmentCode = DirectCast(gridDataItem.FindControl("DropDept"), Telerik.Web.UI.RadComboBox).SelectedValue
                                .Comments = DirectCast(gridDataItem.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim()
                                If CheckProductCategory() = True Then
                                    .ProductCategoryCode = DirectCast(gridDataItem.FindControl("TextBox_ProductCategory"), TextBox).Text
                                End If
                                .Hours = ThisHours
                                .StartDate = DirectCast(gridDataItem.FindControl("RadDatePickerItemTemplate_StartDate"), Telerik.Web.UI.RadDatePicker).SelectedDate
                            End With

                            AdvantageFramework.Database.Procedures.EmployeeTimeStaging.Update(DbContext, EmployeeTimeStaging)

                        End If
                    End If
                Next
                _Saved = True

                If Adding = False Then
                    Me.RadGridTimesheetStaging.Rebind()
                End If


            End Using

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SetGrouping()
        Try
            If DropGroupBy.SelectedIndex > 0 Then
                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse(Me.DropGroupBy.SelectedValue)
                With Me.RadGridTimesheetTemplate
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                End With
            Else
                With Me.RadGridTimesheetTemplate
                    .MasterTableView.GroupByExpressions.Clear()
                End With
            End If
            'Me.RadGridTimesheetTemplate.Rebind()
        Catch ex As Exception
            With Me.RadGridTimesheetTemplate
                .MasterTableView.GroupByExpressions.Clear()
            End With
        End Try
    End Sub
    Private Function CheckProductCategory() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()
    End Function
    Private Sub CheckPostPeriod()
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        SunClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(0))
        MonClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(1))
        TueClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(2))
        WedClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(3))
        ThuClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(4))
        FriClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(5))
        SatClosedPP = False 'oTS.PostPeriodClosed(CDate(CurrDate).AddDays(6))
    End Sub
    Private Function SaveSelectedRowToTimesheet(ByVal RowFuncCat As String, ByVal RowDept As String, ByVal RowJob As Integer, ByVal RowJobComp As Integer, ByVal IsTemplate As Boolean,
                                                Optional ByVal RowProdCat As String = "", Optional ByVal Comment As String = "",
                                                Optional ByVal Hours As Decimal = 0.0, Optional ByVal ApplyToDays As String = "", Optional ByRef ErrorMessage As String = "") As Boolean

        If RowFuncCat = "" Then Return False

        IsTemplate = Me.MultiViewCopyFrom.ActiveViewIndex = 2

        Try

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim ThisJob As Integer = RowJob
            Dim ThisJobComp As Integer = RowJobComp
            Dim ThisFuncCat As String = RowFuncCat
            Dim thisStartDate As Date
            Dim ThisProdCat As String = RowProdCat
            Dim ThisDept As String = RowDept
            Dim ThisHours As Decimal = 0.0
            Dim strError As String = ""

            If wvIsDate(Me.TimesheetStartDate) = True Then

                thisStartDate = wvCDate(Me.TimesheetStartDate)

            Else

                thisStartDate = wvCDate(oTS.FirstDayOfWeek(Now.Date))

            End If

            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""

            If ThisJob > 0 And ThisJobComp > 0 Then

                oTS.GetJobComponentInfo(ThisJob, ThisJobComp, , , , ClCode, DivCode, PrdCode)

            End If

            If oTS.ValidateInfo(Me.CurrEmp, ClCode, DivCode, PrdCode, ThisJob, ThisJobComp, ThisFuncCat, ThisDept, ThisProdCat, ErrorMessage) = False Then

                Exit Function

            End If

            Try

                Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType
                Dim TimeSaved As Boolean = False
                Dim ShowEstimateApprovalMessage As Boolean = False
                Dim EstimateApprovalMessage As String = ""

                Dim AddSun As Boolean = False
                Dim AddMon As Boolean = False
                Dim AddTue As Boolean = False
                Dim AddWed As Boolean = False
                Dim AddThu As Boolean = False
                Dim AddFri As Boolean = False
                Dim AddSat As Boolean = False

                If IsTemplate = True Then


                Else

                    If (Me._IncludeHours) Then

                        Select Case ApplyToDays
                            Case "Mon"
                                AddMon = True
                            Case "Tue"
                                AddTue = True
                            Case "Wed"
                                AddWed = True
                            Case "Thu"
                                AddThu = True
                            Case "Fri"
                                AddFri = True
                            Case "Sat"
                                AddSat = True
                            Case "Sun"
                                AddSun = True
                        End Select

                    Else

                        Select Case Me.StartWeekOn
                            Case DayOfWeek.Saturday
                                AddTue = True
                            Case DayOfWeek.Sunday
                                AddMon = True
                            Case DayOfWeek.Monday
                                AddSun = True
                        End Select


                    End If

                End If

                If AddSun = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.SunDate)
                    SunClosedPP = oTS.PostPeriodClosed(SunDate)
                    If SunClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.SunDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddMon = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.MonDate)
                    MonClosedPP = oTS.PostPeriodClosed(MonDate)
                    If MonClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.MonDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddTue = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.TueDate)
                    TueClosedPP = oTS.PostPeriodClosed(TueDate)
                    If TueClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.TueDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddWed = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.WedDate)
                    WedClosedPP = oTS.PostPeriodClosed(WedDate)
                    If WedClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.WedDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddThu = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.ThuDate)
                    ThuClosedPP = oTS.PostPeriodClosed(ThuDate)
                    If ThuClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.ThuDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddFri = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.FriDate)
                    FriClosedPP = oTS.PostPeriodClosed(FriDate)
                    If FriClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.FriDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddSat = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.SatDate)
                    SatClosedPP = oTS.PostPeriodClosed(SatDate)
                    If SatClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.SatDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If


                If TimeSaved = True Then

                    oTS.DeleteMissingTimeDtl(CurrEmp)
                    TimesheetPage.ProcessMissingTime(CurrEmp, Me.SunDate)

                End If

                If ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(EstimateApprovalMessage) = False Then

                    ErrorMessage &= EstimateApprovalMessage & "\n"

                End If

                Return TimeSaved

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function
    Private Function SaveSelectedRowToTimesheetStaging(ByVal RowFuncCat As String, ByVal RowDept As String, ByVal RowJob As Integer, ByVal RowJobComp As Integer, ByVal IsTemplate As Boolean, ByVal RowDate As DateTime,
                                                Optional ByVal RowProdCat As String = "", Optional ByVal Comment As String = "",
                                                Optional ByVal Hours As Decimal = 0.0, Optional ByVal ApplyToDays As String = "", Optional ByRef ErrorMessage As String = "") As Boolean

        If RowFuncCat = "" Then Return False

        IsTemplate = Me.MultiViewCopyFrom.ActiveViewIndex = 2

        Try

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim ThisJob As Integer = RowJob
            Dim ThisJobComp As Integer = RowJobComp
            Dim ThisFuncCat As String = RowFuncCat
            Dim thisStartDate As Date
            Dim ThisProdCat As String = RowProdCat
            Dim ThisDept As String = RowDept
            Dim ThisHours As Decimal = 0.0
            Dim strError As String = ""

            If wvIsDate(Me.TimesheetStartDate) = True Then

                thisStartDate = wvCDate(Me.TimesheetStartDate)

            Else

                thisStartDate = wvCDate(oTS.FirstDayOfWeek(Now.Date))

            End If

            ThisHours = Hours

            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""

            If ThisJob > 0 And ThisJobComp > 0 Then

                oTS.GetJobComponentInfo(ThisJob, ThisJobComp, , , , ClCode, DivCode, PrdCode)

            End If

            If ThisJob > 0 And ThisJobComp = 0 Then

                ErrorMessage = "Job selected without a Component."
                Exit Function

            End If

            If oTS.ValidateInfo(Me.CurrEmp, ClCode, DivCode, PrdCode, ThisJob, ThisJobComp, ThisFuncCat, ThisDept, ThisProdCat, ErrorMessage) = False Then

                Exit Function

            End If

            Try

                Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType
                Dim TimeSaved As Boolean = False
                Dim ShowEstimateApprovalMessage As Boolean = False
                Dim EstimateApprovalMessage As String = ""

                Dim AddSun As Boolean = False
                Dim AddMon As Boolean = False
                Dim AddTue As Boolean = False
                Dim AddWed As Boolean = False
                Dim AddThu As Boolean = False
                Dim AddFri As Boolean = False
                Dim AddSat As Boolean = False

                If IsTemplate = True Then


                Else

                    If (Me._IncludeHours) Then

                        Select Case ApplyToDays
                            Case "Mon"
                                AddMon = True
                                Me.MonDate = RowDate
                            Case "Tue"
                                AddTue = True
                                Me.TueDate = RowDate
                            Case "Wed"
                                AddWed = True
                                Me.WedDate = RowDate
                            Case "Thu"
                                AddThu = True
                                Me.ThuDate = RowDate
                            Case "Fri"
                                AddFri = True
                                Me.FriDate = RowDate
                            Case "Sat"
                                AddSat = True
                                Me.SatDate = RowDate
                            Case "Sun"
                                AddSun = True
                                Me.SunDate = RowDate
                        End Select

                    Else

                        Select Case Me.StartWeekOn
                            Case DayOfWeek.Saturday
                                AddTue = True
                            Case DayOfWeek.Sunday
                                AddMon = True
                            Case DayOfWeek.Monday
                                AddSun = True
                        End Select


                    End If

                End If

                If AddSun = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.SunDate)
                    SunClosedPP = oTS.PostPeriodClosed(SunDate)
                    If SunClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.SunDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.SunDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddMon = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.MonDate)
                    MonClosedPP = oTS.PostPeriodClosed(MonDate)
                    If MonClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.MonDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.MonDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddTue = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.TueDate)
                    TueClosedPP = oTS.PostPeriodClosed(TueDate)
                    If TueClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.TueDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.TueDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddWed = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.WedDate)
                    WedClosedPP = oTS.PostPeriodClosed(WedDate)
                    If WedClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.WedDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.WedDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddThu = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.ThuDate)
                    ThuClosedPP = oTS.PostPeriodClosed(ThuDate)
                    If ThuClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.ThuDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.ThuDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddFri = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.FriDate)
                    FriClosedPP = oTS.PostPeriodClosed(FriDate)
                    If FriClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.FriDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.FriDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If

                If AddSat = True Then
                    CurrEditStatus = oTS.CheckEditStatus(Me.CurrEmp, Me.SatDate)
                    SatClosedPP = oTS.PostPeriodClosed(SatDate)
                    If SatClosedPP = False And (CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or CurrEditStatus = AdvantageFramework.Timesheet.TimesheetEditType.Denied) Then
                        If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, CurrEmp, Me.SatDate, ThisFuncCat, ThisProdCat, ThisHours, ThisJob, ThisJobComp, ThisDept, CStr(Session("UserCode")), strError, Comment) = False Then
                        Else
                            TimeSaved = True
                        End If
                        If ErrorMessage.Contains(strError) = False AndAlso strError.Contains("|") = False Then ErrorMessage &= strError & "\n"
                    Else
                        If ThisHours > 0 Then
                            ErrorMessage &= Me.SatDate.AddDays(0).DayOfWeek().ToString() & " has already been approved/pending. No time will be added to this day.\n"
                        End If
                    End If
                End If

                If ShowEstimateApprovalMessage = False Then

                    ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(strError, EstimateApprovalMessage)

                End If


                If TimeSaved = True Then

                    oTS.DeleteMissingTimeDtl(CurrEmp)
                    TimesheetPage.ProcessMissingTime(CurrEmp, Me.SunDate)

                End If

                If ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(EstimateApprovalMessage) = False Then

                    ErrorMessage &= EstimateApprovalMessage & "\n"

                End If

                Return TimeSaved

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function
    Private Function GetProductCategoryDS(ByVal Client As String, ByVal Division As String, ByVal Product As String) As DataSet
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Return odd.ddProductCategoryDS(Client, Division, Product)
    End Function
    Private Function ShowNewEntryMessage(ByVal DataKey As String, ByRef Message As String) As Boolean
        Dim ReturnValue As Boolean = False

        Try

            If DataKey.Contains("|") = True Then

                Dim ar() As String

                ar = DataKey.Split("|") '"INSERT_SUCCESS|4129|1|8.000|120.000|0|-15|Warning, your time entry will cause the total hours posted to exceed the approved estimate amount for the function."

                If ar IsNot Nothing AndAlso ar.Length > 7 Then
                    If ar(6) IsNot Nothing AndAlso ar(7) IsNot Nothing Then

                        Select Case CType(ar(6), Integer)
                            Case -15, -16, -17

                                ReturnValue = True
                                Message = ar(7)

                        End Select

                    End If
                End If

            End If

        Catch ex As Exception
        End Try

        Return ReturnValue

    End Function



#End Region

End Class
