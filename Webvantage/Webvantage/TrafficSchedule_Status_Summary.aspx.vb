Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports System.Drawing

Public Class TrafficSchedule_Status_Summary
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private HoursType As String = ""
    Private export As Integer = 0
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Request.QueryString("JobNum")) Then
                Me.JobNumber = CType(Request.QueryString("JobNum"), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("JobComp")) Then
                Me.JobComponentNbr = CType(Request.QueryString("JobComp"), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        If Not Me.IsPostBack Then
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_SUM)
            oAppVars.getAllAppVars()

            Me.Title = "Risk Analysis Summary"

            Dim s As String = ""
            s = oAppVars.getAppVar("SummaryEA")
            If s <> "" Then
                If s = "ETF" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Value = "ETF" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.RadGridSummary.Columns(11).Visible = False
                    Me.RadGridSummary.Columns(20).Visible = False
                ElseIf s = "Allowed" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Value = "Allowed" Then
                            rtb.Checked = True
                        End If
                    Next
                    Me.RadGridSummary.Columns(10).Visible = False
                    Me.RadGridSummary.Columns(19).Visible = False
                End If
            Else
                Me.RadGridSummary.Columns(10).Visible = False
                Me.RadGridSummary.Columns(19).Visible = False
            End If
            s = oAppVars.getAppVar("SummaryQP")
            If s <> "" Then
                If s = "Quoted" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Value = "Quoted" Then
                            rtb.Checked = True
                        End If
                    Next
                    HoursType = "Quoted"
                ElseIf s = "Planned" Then
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Value = "Planned" Then
                            rtb.Checked = True
                        End If
                    Next
                    HoursType = "Planned"
                End If
            Else
                HoursType = "Quoted"
            End If
        End If
    End Sub

#Region " RadGrid "

    Private Sub RadGridSummary_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSummary.ItemCommand
        Try
            Dim RedirectURL As String = ""
            Dim di As GridDataItem = e.Item
            Dim j As Integer = di.GetDataKeyValue("JOB_NUMBER")
            Dim c As Integer = di.GetDataKeyValue("JOB_COMPONENT_NBR")
            Select Case e.CommandName
                Case "SingleView"
                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Content.aspx"
                    qs.JobNumber = j
                    qs.JobComponentNumber = c
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    'RedirectURL = "ProjectSchedule/Index/" & j & "/" & c & "?R=1"
                    Me.OpenWindow("Project Schedule - Single View", qs.ToString(True))
                Case "RiskAnalysis"
                    Dim burn As String
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            burn = rtb.Value
                        End If
                    Next
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    With qs

                        .Page = "TrafficSchedule_Status_Graph.aspx"
                        .JobNumber = j
                        .JobComponentNumber = c
                        .Add("From", "ras")
                        .Add("burn", burn)

                    End With

                    'RedirectURL = "TrafficSchedule_Status_Graph.aspx?From=ras&JobNum=" & j & "&JobComp=" & c & "&burn=" & burn
                    Me.OpenWindow("Risk Analysis", qs.ToString(True))

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSummary_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSummary.ItemDataBound
        Try
            Dim adjustedhours As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AdjustedHours"), RadToolBarButton).Checked
            Dim adjusteddollars As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AdjustedDollars"), RadToolBarButton).Checked
            Dim allhours As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AllHours"), RadToolBarButton).Checked
            Dim alldollars As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AllDollars"), RadToolBarButton).Checked
            If HoursType = "" Then
                HoursType = "Quoted"
            End If
            If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
                Dim di As GridDataItem = e.Item
                If e.Item.Cells(5).Text <> "" Then
                    e.Item.Cells(5).Text = di.DataItem("JOB_NUMBER").ToString.PadLeft(6, "0") & "-" & di.DataItem("JOB_COMPONENT_NBR").ToString.PadLeft(2, "0") & " " & e.Item.Cells(5).Text
                End If

                'Start Date
                If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
                    e.Item.Cells(8).Text = CDate(e.Item.Cells(8).Text).ToShortDateString
                End If
                'End Date
                If e.Item.Cells(9).Text <> "" And e.Item.Cells(9).Text <> "&nbsp;" Then
                    e.Item.Cells(9).Text = CDate(e.Item.Cells(9).Text).ToShortDateString
                End If

                'Adjusted Hours
                If Me.RadGridSummary.Columns(11).Visible = False Then
                    If HoursType = "Quoted" Then
                        e.Item.Cells(14).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(11).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                        e.Item.Cells(23).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(20).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                    ElseIf HoursType = "Planned" Then
                        e.Item.Cells(14).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(12).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                        e.Item.Cells(23).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(21).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                    End If
                    '% Complete(Adj) - Hours
                    If e.Item.Cells(14).Text <> "0.00" And e.Item.Cells(14).Text <> "" And e.Item.Cells(14).Text <> "&nbsp;" Then
                        e.Item.Cells(16).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(14).Text)) * 100)
                    Else
                        e.Item.Cells(16).Text = "0.00"
                    End If
                    If e.Item.Cells(16).Text <> "0.00" Then
                        If CDec(e.Item.Cells(16).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(16).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(16).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(16).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(16).CssClass = "standard-light-green"
                            End If

                        End If
                    End If
                    '% Complete(All) - Hours
                    If HoursType = "Quoted" Then
                        If e.Item.Cells(11).Text <> "0.00" And e.Item.Cells(11).Text <> "" And e.Item.Cells(11).Text <> "&nbsp;" Then
                            e.Item.Cells(17).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(11).Text)) * 100)
                        Else
                            e.Item.Cells(17).Text = "0.00"
                        End If
                    ElseIf HoursType = "Planned" Then
                        If e.Item.Cells(12).Text <> "0.00" And e.Item.Cells(12).Text <> "" And e.Item.Cells(12).Text <> "&nbsp;" Then
                            e.Item.Cells(17).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(12).Text)) * 100)
                        Else
                            e.Item.Cells(17).Text = "0.00"
                        End If
                    End If

                    If e.Item.Cells(17).Text <> "0.00" Then
                        If CDec(e.Item.Cells(17).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(17).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(17).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(17).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(17).CssClass = "standard-light-green"
                            End If
                        End If
                    End If

                    '% Complete(Adj) - Amt
                    If e.Item.Cells(23).Text <> "0.00" And e.Item.Cells(23).Text <> "" And e.Item.Cells(23).Text <> "&nbsp;" Then
                        e.Item.Cells(25).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(23).Text)) * 100)
                    Else
                        e.Item.Cells(25).Text = "0.00"
                    End If
                    If e.Item.Cells(25).Text <> "0.00" Then
                        If CDec(e.Item.Cells(25).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(25).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(25).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(25).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(25).CssClass = "standard-light-green"
                            End If
                        End If
                    End If
                    '% Complete(All) - Amt
                    If HoursType = "Quoted" Then
                        If e.Item.Cells(20).Text <> "0.00" And e.Item.Cells(20).Text <> "" And e.Item.Cells(20).Text <> "&nbsp;" Then
                            e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(20).Text)) * 100)
                        Else
                            e.Item.Cells(26).Text = "0.00"
                        End If
                    ElseIf HoursType = "Planned" Then
                        If e.Item.Cells(21).Text <> "0.00" And e.Item.Cells(21).Text <> "" And e.Item.Cells(21).Text <> "&nbsp;" Then
                            e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(21).Text)) * 100)
                        Else
                            e.Item.Cells(26).Text = "0.00"
                        End If
                    End If
                    If e.Item.Cells(26).Text <> "0.00" Then
                        If CDec(e.Item.Cells(26).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(26).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(26).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(26).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(26).CssClass = "standard-light-green"
                            End If
                        End If
                    End If
                Else
                    If HoursType = "Quoted" Then
                        e.Item.Cells(14).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(11).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                        e.Item.Cells(23).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(20).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                    ElseIf HoursType = "Planned" Then
                        e.Item.Cells(14).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(13).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                        e.Item.Cells(23).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(22).Text) * (CDec(e.Item.Cells(10).Text) / 100)))
                    End If
                    '% Complete(Adj) - Hours
                    If e.Item.Cells(14).Text <> "0.00" And e.Item.Cells(14).Text <> "" And e.Item.Cells(14).Text <> "&nbsp;" Then
                        e.Item.Cells(16).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(14).Text)) * 100)
                    Else
                        e.Item.Cells(16).Text = "0.00"
                    End If
                    If e.Item.Cells(16).Text <> "0.00" Then
                        If CDec(e.Item.Cells(16).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(16).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(16).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(16).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(16).CssClass = "standard-light-green"
                            End If
                        End If
                    End If
                    '% Complete(All) - Hours
                    If HoursType = "Quoted" Then
                        If e.Item.Cells(11).Text <> "0.00" And e.Item.Cells(11).Text <> "" And e.Item.Cells(11).Text <> "&nbsp;" Then
                            e.Item.Cells(17).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(11).Text)) * 100)
                        Else
                            e.Item.Cells(17).Text = "0.00"
                        End If
                    ElseIf HoursType = "Planned" Then
                        If e.Item.Cells(13).Text <> "0.00" And e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then
                            e.Item.Cells(17).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(15).Text) / CDec(e.Item.Cells(13).Text)) * 100)
                        Else
                            e.Item.Cells(17).Text = "0.00"
                        End If
                    End If
                    If e.Item.Cells(17).Text <> "0.00" Then
                        If CDec(e.Item.Cells(17).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(17).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(17).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(17).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(17).CssClass = "standard-light-green"
                            End If
                        End If
                    End If

                    '% Complete(Adj) - Amt
                    If e.Item.Cells(23).Text <> "0.00" And e.Item.Cells(23).Text <> "" And e.Item.Cells(23).Text <> "&nbsp;" Then
                        e.Item.Cells(25).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(23).Text)) * 100)
                    Else
                        e.Item.Cells(25).Text = "0.00"
                    End If
                    If e.Item.Cells(25).Text <> "0.00" Then
                        If CDec(e.Item.Cells(25).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(25).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(25).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(25).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(25).CssClass = "standard-light-green"
                            End If
                        End If
                    End If
                    '% Complete(All) - Amt
                    If HoursType = "Quoted" Then
                        If e.Item.Cells(20).Text <> "0.00" And e.Item.Cells(20).Text <> "" And e.Item.Cells(20).Text <> "&nbsp;" Then
                            e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(20).Text)) * 100)
                        Else
                            e.Item.Cells(26).Text = "0.00"
                        End If
                    ElseIf HoursType = "Planned" Then
                        If e.Item.Cells(22).Text <> "0.00" And e.Item.Cells(22).Text <> "" And e.Item.Cells(22).Text <> "&nbsp;" Then
                            e.Item.Cells(26).Text = String.Format("{0:#,##0.00}", (CDec(e.Item.Cells(24).Text) / CDec(e.Item.Cells(22).Text)) * 100)
                        Else
                            e.Item.Cells(26).Text = "0.00"
                        End If
                    End If

                    If e.Item.Cells(26).Text <> "0.00" Then
                        If CDec(e.Item.Cells(26).Text) > 100 Then
                            If export = 1 Then
                                e.Item.Cells(26).BackColor = ColorTranslator.FromHtml("#EEACB9")
                            Else
                                e.Item.Cells(26).CssClass = "standard-pink"
                            End If
                        Else
                            If export = 1 Then
                                e.Item.Cells(26).BackColor = ColorTranslator.FromHtml("#99C3B8")
                            Else
                                e.Item.Cells(26).CssClass = "standard-light-green"
                            End If
                        End If
                    End If
                End If

                If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                    For i As Integer = 9 To e.Item.Cells.Count - 1
                        If IsNumeric(e.Item.Cells(i).Text) = True Then
                            e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDec(e.Item.Cells(i).Text))
                        End If
                    Next
                End If

                If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                    For i As Integer = 11 To 15
                        If IsNumeric(e.Item.Cells(i).Text) = True Then
                            If export = 1 Then
                                e.Item.Cells(i).BackColor = ColorTranslator.FromHtml("#F5C7A1")
                            Else
                                e.Item.Cells(i).CssClass = "standard-light-orange"
                            End If
                        End If
                    Next
                End If

                If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                    For i As Integer = 20 To 24
                        If IsNumeric(e.Item.Cells(i).Text) = True Then
                            If export = 1 Then
                                e.Item.Cells(i).BackColor = ColorTranslator.FromHtml("#78A1CA")
                            Else
                                e.Item.Cells(i).CssClass = "standard-light-blue"
                            End If
                        End If
                    Next
                End If


            End If
            'If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            '    Dim j As Integer = e.Item.Cells(18).Text
            '    Dim c As Integer = e.Item.Cells(19).Text
            '    Dim burn As String
            '    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
            '        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
            '            burn = rtb.Value
            '        End If
            '    Next
            '    Dim js As String = "OpenRadWindow('Risk Analysis','" & "TrafficSchedule_Status_Graph.aspx?From=ras&JobNum=" & j & "&JobComp=" & c & "&burn=" & burn & "',0,0);return false;"
            '    e.Item.Attributes.Add("onclick", js)
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSummary_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGridSummary.SortCommand
        Try
            For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                    HoursType = rtb.Value
                End If
            Next
            Me.RadGridSummary.Rebind()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridSummary_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSummary.NeedDataSource
        Try
            Dim proj As New cSchedule(Session("ConnString"), Session("UserCode"))

            If Request.QueryString("jcs") <> "" Then
                Session("TrafficScheduleMVJobs") = Request.QueryString("jcs")
            End If

            Dim JC() As String = Session("TrafficScheduleMVJobs").ToString.Split("|")
            Dim jobs As String
            Dim comps As String
            For i As Integer = 0 To JC.Length - 1
                Dim j() As String = JC(i).Split(",")
                If j(0) <> "" Then
                    jobs &= j(0) & ","
                    comps &= j(1) & ","
                End If
            Next
            Dim ds As DataSet = proj.GetScheduleStatusSummary(jobs, comps)
            Me.RadGridSummary.DataSource = ds
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSummary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridSummary.SelectedIndexChanged
        Try
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridSummary.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    gridDataItem.Selected = False
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridSummary_PreRender(sender As Object, e As EventArgs) Handles RadGridSummary.PreRender
        Try
            Dim adjustedhours As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AdjustedHours"), RadToolBarButton).Checked
            Dim adjusteddollars As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AdjustedDollars"), RadToolBarButton).Checked
            Dim allhours As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AllHours"), RadToolBarButton).Checked
            Dim alldollars As Boolean = CType(Me.RadToolbarSummary.FindItemByValue("AllDollars"), RadToolBarButton).Checked

            For Each item As GridDataItem In RadGridSummary.Items
                If adjustedhours = True Then
                    If item.Cells(16).BackColor <> ColorTranslator.FromHtml("#ECBBBB") And item.Cells(16).CssClass <> "standard-pink" Then
                        item.Visible = False
                    End If
                End If
                If allhours = True Then
                    If item.Cells(17).BackColor <> ColorTranslator.FromHtml("#ECBBBB") And item.Cells(17).CssClass <> "standard-pink" Then
                        item.Visible = False
                    End If
                End If
                If adjusteddollars = True Then
                    If item.Cells(25).BackColor <> ColorTranslator.FromHtml("#ECBBBB") And item.Cells(25).CssClass <> "standard-pink" Then
                        item.Visible = False
                    End If
                End If
                If alldollars = True Then
                    If item.Cells(26).BackColor <> ColorTranslator.FromHtml("#ECBBBB") And item.Cells(26).CssClass <> "standard-pink" Then
                        item.Visible = False
                    End If
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls "

    Private Sub RadToolbarSummary_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSummary.ButtonClick
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.RISK_ANAL_SUM)
            oAppVars.getAllAppVars()
            Select Case e.Item.Value
                Case "ETF"
                    Me.RadGridSummary.Columns(11).Visible = False
                    Me.RadGridSummary.Columns(20).Visible = False
                    Me.RadGridSummary.Columns(10).Visible = True
                    Me.RadGridSummary.Columns(19).Visible = True
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next
                    oAppVars.setAppVarDB("SummaryEA", "ETF")
                Case "Allowed"
                    Me.RadGridSummary.Columns(10).Visible = False
                    Me.RadGridSummary.Columns(11).Visible = True
                    Me.RadGridSummary.Columns(20).Visible = True
                    Me.RadGridSummary.Columns(19).Visible = False
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next
                    oAppVars.setAppVarDB("SummaryEA", "Allowed")
                Case "Quoted"
                    HoursType = "Quoted"
                    oAppVars.setAppVarDB("SummaryQP", "Quoted")
                Case "Planned"
                    HoursType = "Planned"
                    oAppVars.setAppVarDB("SummaryQP", "Planned")
                Case "Export"
                    Dim s As String = ""
                    s = oAppVars.getAppVar("SummaryEA")
                    If s <> "" Then
                        If s = "ETF" Then
                            Me.RadGridSummary.Columns(11).Visible = False
                            Me.RadGridSummary.Columns(20).Visible = False
                        ElseIf s = "Allowed" Then
                            Me.RadGridSummary.Columns(10).Visible = False
                            Me.RadGridSummary.Columns(19).Visible = False
                        End If
                    Else
                        Me.RadGridSummary.Columns(10).Visible = False
                        Me.RadGridSummary.Columns(19).Visible = False
                    End If
                    s = oAppVars.getAppVar("SummaryQP")
                    If s <> "" Then
                        If s = "Quoted" Then
                            HoursType = "Quoted"
                        ElseIf s = "Planned" Then
                            HoursType = "Planned"
                        End If
                    Else
                        HoursType = "Quoted"
                    End If
                    export = 1
                Case "AdjustedHours"
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next
                Case "AllHours"
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next
                Case "AdjustedDollars"
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next
                Case "AllDollars"
                    For Each rtb As RadToolBarButton In Me.RadToolbarSummary.Items
                        If rtb.Checked = True And (rtb.Text = "Quoted" Or rtb.Text = "Planned") Then
                            HoursType = rtb.Value
                        End If
                    Next

            End Select
            RadGridSummary.Rebind()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub TrafficSchedule_Status_Summary_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If export = 1 Then
                Dim str As String = ""
                Me.RadGridSummary.Columns(0).Visible = False
                Me.RadGridSummary.Columns(1).Visible = False
                str = "Risk_Analysis" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridSummary, str)
                RadGridSummary.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception

        End Try
    End Sub

    

End Class
