Imports DayPilot.Web.Ui.Events.Bubble
Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports Webvantage.TaskCalendar

Partial Public Class MediaCalendar_Day
    Inherits Webvantage.BaseChildPage
    Dim dtThisDate As Date

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim c As New cDayPilot
            c.LoadMediaTabs(Me.RadTabStrip)
            If Page.IsPostBack = False Then
                LoadCalendar()
                LoadTasks()
            End If
        Catch ex As Exception
            Me.ShowMessage("err pageload: " & ex.Message.ToString())
        End Try
    End Sub

    Public Function SetClass(ByVal Value As String, ByVal lineCancelled As String) As String

        Dim lcClass As String

        If Value = "1/1/1900 12:00:00 AM" Then
            If lineCancelled = "1" Then
                lcClass = "taskcalcancelled"
            Else
                lcClass = "taskcalnormal"
            End If
        Else
            lcClass = "taskcalpending"
        End If

        Return lcClass
    End Function

    Public Function SetColor(ByVal RecType As String) As String
        Select Case RecType
            Case "M"
                Return ColorTranslator.ToHtml(Me.TbMagazine.BackColor)
            Case "N"
                Return ColorTranslator.ToHtml(Me.TbNewspaper.BackColor)
            Case "I"
                Return ColorTranslator.ToHtml(Me.TbInternet.BackColor)
            Case "O"
                Return ColorTranslator.ToHtml(Me.TbOutdoor.BackColor)
            Case "R"
                Return ColorTranslator.ToHtml(Me.TbRadio.BackColor)
            Case "T"
                Return ColorTranslator.ToHtml(Me.TbTelevision.BackColor)
            Case Else
                Return "#FFFFFF"
        End Select
    End Function

    Private Sub LoadTasks()

        Dim MonthDT As New DataTable
        Try
            If Session("MediaMonthView") Is Nothing Then
                MiscFN.ResponseRedirect("MediaCalendar.aspx")
            Else
                MonthDT = CType(Session("MediaMonthView"), DataTable)
            End If
        Catch ex As Exception
            MiscFN.ResponseRedirect("MediaCalendar.aspx")
        End Try


        Dim ThisDate As Date
        ThisDate = Session("MediaCalendarSelectedDate")

        Try
            If Not MonthDT Is Nothing Then
                If MonthDT.Rows.Count > 0 Then
                    Dim DvMediaDay As DataView = New DataView(MonthDT)

                    DvMediaDay.RowFilter = "DISPLAY_START_DATE = '" & ThisDate.ToString() & "'"
                    With Me.repMediaDay
                        .DataSource = DvMediaDay
                        .DataBind()
                    End With

                End If
            End If
        Catch ex As Exception
        End Try
        Me.PageTitle = ThisDate.ToLongDateString()

    End Sub

    Private Sub LoadCalendar()
        Dim c As New cDayPilot
        Dim DtCalendar As New DataTable

        Dim intDaysInMonth As Integer
        Dim dtFirst As Date
        Dim dtLast As Date
        Dim strEmpCode As String = ""
        ''Me.MonthViewCalendar.VisibleDate = dtThisDate
        'mediacalendar = New ClientMediaCalendar(CStr(Session("Connstring")))
        Try
            dtThisDate = Session("MediaCalendarSelectedDate")
        Catch ex As Exception
            dtThisDate = Now.Date
        End Try
        ViewState("ThisDate") = dtThisDate

        ' Set Up for navigation links
        intDaysInMonth = dtThisDate.DaysInMonth(dtThisDate.Year, dtThisDate.Month)
        'dtFirst = CDate(CStr(dtThisDate.Month) & "/" & CStr(1) & "/" & CStr(dtThisDate.Year))
        'dtLast = CDate(CStr(dtThisDate.Month) & "/" & CStr(intDaysInMonth) & "/" & CStr(dtThisDate.Year))
        dtFirst = LoGlo.FirstOfMonth(dtThisDate)
        dtLast = LoGlo.LastOfMonth(dtThisDate)
        If Not Session("MediaCalType") Is Nothing Then

            If Session("MediaCalType") = "Traffic" Then
                DtCalendar = c.GetMediaCalendarDisplay(Session("MediaCalType"), dtThisDate.Month, _
                                                                  dtThisDate.Year, _
                                                                  CStr(Session("UserCode")), _
                                                                  Session("mtfSClient"), _
                                                                  Session("mtfSDivision"), _
                                                                  Session("mtfSProduct"), _
                                                                  Session("mtfSMediaType"), _
                                                                  Session("mtfSCampaign"), _
                                                                  Session("mtfSClientPO"), _
                                                                  Session("mtfSVendor"), _
                                                                  Session("mtfSBuyer"), _
                                                                  Session("mtfIMagazine"), _
                                                                  Session("mtfINewspaper"), _
                                                                  Session("mtfIInternet"), _
                                                                  Session("mtfIOutOfHome"), _
                                                                  Session("mtfITelevision"), _
                                                                  Session("mtfIRadio"), _
                                                                  Session("mtfIAcceptedOrders"), _
                                                                  Session("mtfICancelledOrders"), _
                                                                  Session("mtfDClient"), _
                                                                  Session("mtfDDivision"), _
                                                                  Session("mtfDProduct"), _
                                                                  Session("mtfDType"), _
                                                                  Session("mtfDMediaType"), _
                                                                  Session("mtfDInsertionLine"), _
                                                                  Session("mtfDVendorCode"), _
                                                                  Session("mtfDVendorName"), _
                                                                  Session("mtfDJobComp"), _
                                                                  Session("mtfDCampaignCode"), _
                                                                  Session("mtfDCampaignName"), _
                                                                  Session("mtfDMarketCode"), _
                                                                  Session("mtfDMarketName"), _
                                                                  Session("mtfDAdSizeLength"), _
                                                                  Session("mtfDHeadlineProg"), _
                                                                  Session("mtfDExtMatDate"), _
                                                                  Session("mtfDCloseDate"), _
                                                                  Session("mtfDExtCloseDate"), _
                                                                  Session("mtfDRunDate"), _
                                                                  Session("mtfDBillingAmount"), _
                                                                  Session("mtfDSpots"), _
                                                                  Session("mtfDBMatDueDate"), _
                                                                  Session("mtfDBExtMatDueDate"), _
                                                                  Session("mtfDBCloseDate"), _
                                                                  Session("mtfDBExtCloseDate"), _
                                                                  Session("mtfDBRunInsertionDate"), False, _
                                                                  Session("MediaCalPrint"), _
                                                                  Session("mtfSOffice"))
            ElseIf Session("MediaCalType") = "Schedule" Then
                DtCalendar = c.GetMediaCalendarDisplay(Session("MediaCalType"), dtThisDate.Month, _
                                                                  dtThisDate.Year, _
                                                                  CStr(Session("UserCode")), _
                                                                  Session("msfSClient"), _
                                                                  Session("msfSDivision"), _
                                                                  Session("msfSProduct"), _
                                                                  Session("msfSMediaType"), _
                                                                  Session("msfSCampaign"), _
                                                                  Session("msfSClientPO"), _
                                                                  Session("msfSVendor"), _
                                                                  Session("msfSBuyer"), _
                                                                  Session("msfIMagazine"), _
                                                                  Session("msfINewspaper"), _
                                                                  Session("msfIInternet"), _
                                                                  Session("msfIOutOfHome"), _
                                                                  Session("msfITelevision"), _
                                                                  Session("msfIRadio"), _
                                                                  Session("msfIAcceptedOrders"), _
                                                                  Session("msfICancelledOrders"), _
                                                                  Session("msfDClient"), _
                                                                  Session("msfDDivision"), _
                                                                  Session("msfDProduct"), _
                                                                  Session("msfDType"), _
                                                                  Session("msfDMediaType"), _
                                                                  Session("msfDInsertionLine"), _
                                                                  Session("msfDVendorCode"), _
                                                                  Session("msfDVendorName"), _
                                                                  Session("msfDJobComp"), _
                                                                  Session("msfDCampaignCode"), _
                                                                  Session("msfDCampaignName"), _
                                                                  Session("msfDMarketCode"), _
                                                                  Session("msfDMarketName"), _
                                                                  Session("msfDAdSizeLength"), _
                                                                  Session("msfDHeadlineProg"), _
                                                                  Session("msfDExtMatDate"), _
                                                                  Session("msfDCloseDate"), _
                                                                  Session("msfDExtCloseDate"), _
                                                                  Session("msfDRunDate"), _
                                                                  Session("msfDBillingAmount"), _
                                                                  Session("msfDSpots"), _
                                                                  Session("msfDBMatDueDate"), _
                                                                  Session("msfDBExtMatDueDate"), _
                                                                  Session("msfDBCloseDate"), _
                                                                  Session("msfDBExtCloseDate"), _
                                                                  Session("msfDBRunInsertionDate"), _
                                                                  Session("msfDBDisplayFlight"), _
                                                                  Session("MediaCalPrint"), _
                                                                  Session("msfSOffice"))
            Else
                DtCalendar = c.GetMediaCalendarDisplay(Session("MediaCalType"), dtThisDate.Month, _
                                                                  dtThisDate.Year, _
                                                                  CStr(Session("UserCode")), _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  "", _
                                                                  True, _
                                                                  True, _
                                                                  True, _
                                                                  True, _
                                                                  True, _
                                                                  True, _
                                                                  False, _
                                                                  True, _
                                                                  True, _
                                                                  False, _
                                                                  False, _
                                                                  True, _
                                                                  False, _
                                                                  True, _
                                                                  True, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  True, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  False, _
                                                                  "")
            End If
        Else
            DtCalendar = c.GetMediaCalendarDisplay("", dtThisDate.Month, dtThisDate.Year, CStr(Session("UserCode")), "", "", "", "", "", "", "", "", True, True, True, True, True, True, False, True, True, False, False, True, False, True, True, False, False, False, False, False, False, False, False, False, False, False, False, False, False, True, False, False, False, False, False, False, "")
        End If

        Session("MediaMonthView") = DtCalendar

    End Sub

End Class