Public Partial Class popReportSelect
    Inherits Webvantage.BaseChildPage

    Public JobNum As String
    Public JobComp As String

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        

        GetQueryStrings()

    End Sub
    Private Sub GetQueryStrings()
        Try
            JobNum = Request.QueryString("job")
            JobComp = Request.QueryString("jobcomp")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub BtnGenReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGenReport.Click
       
        Dim hours As Integer

        If rbReport1.Checked = True Then
            If Me.cbHours.Checked = True Then
                hours = 1
            Else
                hours = 0
            End If
            Dim strURL As String = "popReportViewer.aspx?job=" & JobNum & "&jobcomp=" & JobComp & "&Type=1&Report=TrafficDetailByJob&hours=" & hours.ToString

            ''Response.Redirect(strURL.ToString())

            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            Page.RegisterStartupScript("newpage2", strBuilder.ToString())
        ElseIf rbReport2.Checked = True Then
            Dim strURL As String = "ExcelGantt/TimelinePage.aspx?job=" & JobNum & "&jobcomp=" & JobComp

            ''Response.Redirect(strURL.ToString())

            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            Page.RegisterStartupScript("newpage", strBuilder.ToString())

        ElseIf rbCalendar.Checked = True Then
            Dim strURL As String = "TrafficSchedule_Calendar_Render.aspx?job=" & JobNum & "&jobcomp=" & JobComp

            ''Response.Redirect(strURL.ToString())

            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            Page.RegisterStartupScript("newJobCalendarReport", strBuilder.ToString())

        End If
    End Sub
End Class