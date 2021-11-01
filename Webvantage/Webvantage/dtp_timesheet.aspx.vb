Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Public Class dtp_timesheet
    Inherits Webvantage.BaseChildPage
    Private dtSunday As Date
    Private dtMonday As Date
    Private dtTuesday As Date
    Private dtWednesday As Date
    Private dtThursday As Date
    Private dtFriday As Date
    Private dtSaturday As Date
    Protected WithEvents hypTuesday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypWednesday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypThursday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypFriday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSaturday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSunday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMonday As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblSunday As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonday As System.Web.UI.WebControls.Label
    Protected WithEvents lblTuesday As System.Web.UI.WebControls.Label
    Protected WithEvents lblWednesday As System.Web.UI.WebControls.Label
    Protected WithEvents lblThursday As System.Web.UI.WebControls.Label
    Protected WithEvents lblFriday As System.Web.UI.WebControls.Label
    Protected WithEvents lblSaturday As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalHours As System.Web.UI.WebControls.Label
    Protected WithEvents LBtnMissingTime As Global.System.Web.UI.WebControls.Label
    Private TotalWeekHours As Decimal

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Me.AllowFloat = True
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadTimesheets()
                    setMissingTimeLabel()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub LoadTimesheets()
        Dim dr As SqlDataReader
        Dim oDesktop As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        Dim ts As New wvTimeSheet.cTimeSheet(_Session.ConnectionString)

        dtSunday = ts.FirstDayOfWeek(Today.Date)
        dtMonday = dtSunday.AddDays(1)
        dtTuesday = dtSunday.AddDays(2)
        dtWednesday = dtSunday.AddDays(3)
        dtThursday = dtSunday.AddDays(4)
        dtFriday = dtSunday.AddDays(5)
        dtSaturday = dtSunday.AddDays(6)

        ''Me.hypSunday.Text = dtSunday.ToLongDateString
        ''Me.hypMonday.Text = dtMonday.ToLongDateString
        ''Me.hypTuesday.Text = dtTuesday.ToLongDateString
        ''Me.hypWednesday.Text = dtWednesday.ToLongDateString
        ''Me.hypThursday.Text = dtThursday.ToLongDateString
        ''Me.hypFriday.Text = dtFriday.ToLongDateString
        ''Me.hypSaturday.Text = dtSaturday.ToLongDateString

        ''dr = oDesktop.GetTimeSheets(Session("EmpCode"))
        ''Do While dr.Read
        ''    Me.lblSunday.Text = CStr(dr("Sunday"))
        ''    Me.lblMonday.Text = CStr(dr("Monday"))
        ''    Me.lblTuesday.Text = CStr(dr("Tuesday"))
        ''    Me.lblWednesday.Text = CStr(dr("Wednesday"))
        ''    Me.lblThursday.Text = CStr(dr("Thursday"))
        ''    Me.lblFriday.Text = CStr(dr("Friday"))
        ''    Me.lblSaturday.Text = CStr(dr("Saturday"))
        ''    Me.lblTotalHours.Text = CStr(dr("TotalHours"))
        ''Loop
        ''dr.Close()

        Dim dt As New DataTable
        dt = oDesktop.GetTimesheetDTO(Session("EmpCode"))
        Dim Sum As Decimal = 0.0
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                Sum += CType(dt.Rows(i)("Hours"), Decimal)

                Select Case i
                    Case 0
                        Me.hypSunday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblSunday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 1
                        Me.hypMonday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblMonday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 2
                        Me.hypTuesday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblTuesday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 3
                        Me.hypWednesday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblWednesday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 4
                        Me.hypThursday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblThursday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 5
                        Me.hypFriday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblFriday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                    Case 6
                        Me.hypSaturday.Text = CType(dt.Rows(i)("DayDisplay"), Date).ToShortDateString()
                        Me.lblSaturday.Text = FormatNumber(CType(dt.Rows(i)("Hours"), Decimal), 2)
                End Select

            Next

        End If

        Me.lblTotalHours.Text = FormatNumber(Sum, 2)

        dt = Nothing

    End Sub

    Private Sub setMissingTimeLabel()
        Try
            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            Dim MTText As String = oTS.setMissingTimeLabel(Session("UserCode").ToString())

            If MTText <> "" Then
                Me.LBtnMissingTime.Text = MTText
            Else
                Me.LBtnMissingTime.Text = ""
                Me.LBtnMissingTime.Visible = False
            End If

        Catch ex As Exception
            Err.Raise(Err.Number, "Error setMissingTimeLabel!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        End Try
    End Sub

End Class
