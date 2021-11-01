Imports System.IO
Imports System.Drawing

'Imports GemBox
'Imports GemBox.Spreadsheet

Partial Public Class Resources_RptExcel
    Inherits System.Web.UI.Page

    Private StructData As New ResourceExcelReportData
    Private IdxResourceHeaderRow As Integer = 1
    Private IdxFirstDynamicColumn As Integer = 0

    Private SDate As DateTime = Nothing
    Private EDate As DateTime = Nothing

    Private OfficeList As String = ""
    Private CDPList As String = ""
    Private TrfFncList As String = ""
    Private EmployeeList As String = ""
    Private ResourceTypeList As String = ""
    Private ResourceList As String = ""

    Private ColorNoEventType As System.Drawing.Color
    Private ColorStatic As System.Drawing.Color
    Private ColorFlex As System.Drawing.Color
    Private ColorPreEmptable As System.Drawing.Color
    Private ColorHold As System.Drawing.Color

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            SDate = CType(Session("EVTRPT_StartDate"), DateTime)
        Catch ex As Exception
            SDate = Nothing 'Convert.ToDateTime(Now.Month.ToString() & "/1/" & Now.Year.ToString())
        End Try
        Try
            EDate = CType(Session("EVTRPT_EndDate"), DateTime)
        Catch ex As Exception
            EDate = Nothing 'Now.ToShortDateString()
        End Try
        If SDate = Nothing Then
            Try
                If Not Request.QueryString("s") Is Nothing Then
                    Me.SDate = CType(Request.QueryString("s"), DateTime)
                Else
                    Me.SDate = DateAdd(DateInterval.Day, -15, Now)
                End If
            Catch ex As Exception
                Me.SDate = DateAdd(DateInterval.Day, -15, Now)
            End Try
        End If
        If EDate = Nothing Then
            Try
                If Not Request.QueryString("e") Is Nothing Then
                    Me.EDate = CType(Request.QueryString("e"), DateTime)
                Else
                    Me.EDate = DateAdd(DateInterval.Day, 15, Now)
                End If
            Catch ex As Exception
                Me.EDate = DateAdd(DateInterval.Day, 15, Now)
            End Try
        End If
        Try
            OfficeList = Session("EVTRPT_OfficeList")
        Catch ex As Exception
            OfficeList = ""
        End Try
        Try
            CDPList = Session("EVTRPT_CDPList")
        Catch ex As Exception
            CDPList = ""
        End Try
        Try
            TrfFncList = Session("EVTRPT_TrfFncList")
        Catch ex As Exception
            TrfFncList = ""
        End Try
        Try
            EmployeeList = Session("EVTRPT_EmployeeList")
        Catch ex As Exception
            EmployeeList = ""
        End Try
        Try
            ResourceTypeList = Session("EVTRPT_ResourceTypes")
        Catch ex As Exception
            ResourceTypeList = ""
        End Try
        Try
            ResourceList = Session("EVTRPT_ResourceList")
        Catch ex As Exception
            ResourceList = ""
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim sd As DateTime = CType(Me.SDate, DateTime)
            Dim ed As DateTime = CType(Me.EDate, DateTime)
            Dim r As New cResources()

            Try
                Dim dt As New DataTable
                dt = r.EventTypeColors(False)
                If dt.Rows.Count > 0 Then

                    Me.ColorNoEventType = ColorTranslator.FromHtml(dt.Rows(0)("NO_EVENT_TYPE_COLOR").ToString())
                    Me.ColorStatic = ColorTranslator.FromHtml(dt.Rows(0)("STATIC_COLOR").ToString())
                    Me.ColorFlex = ColorTranslator.FromHtml(dt.Rows(0)("FLEX_COLOR").ToString())
                    Me.ColorPreEmptable = ColorTranslator.FromHtml(dt.Rows(0)("PRE_EMPTABLE_COLOR").ToString())
                    Me.ColorHold = ColorTranslator.FromHtml(dt.Rows(0)("HOLD_COLOR").ToString())

                End If
            Catch ex As Exception
            End Try

            Me.IdxFirstDynamicColumn = r.ColIdxStartOfDynamicColumns
            Me.StructData = r.GetReport(sd, ed, TimeIncrement.HalfHour, Me.ResourceTypeList, Me.ResourceList, Me.OfficeList, Me.CDPList, Me.TrfFncList, Me.EmployeeList)

            Try
                If StructData.GridData.Rows.Count > 0 Then
                    With Me.GridView1
                        .DataSource = StructData.GridData
                        .DataBind()
                    End With
                End If
            Catch ex As Exception
            End Try

            'With Me.GridView2
            '    .DataSource = StructData.GridData
            '    .DataBind()
            'End With

            'EXPORT
            '============================================================================
            With Response
                .Clear()
                .AddHeader("content-disposition", "attachment;filename=ResourceReport" & AdvantageFramework.StringUtilities.GUID_Date() & ".xls")
                .Charset = ""
                .Cache.SetCacheability(HttpCacheability.NoCache)
                .ContentType = "application/excel"
            End With
            Dim sw As New StringWriter
            Dim hw As New HtmlTextWriter(sw)
            Me.GridView1.RenderControl(hw)
            With Response
                .Write(sw.ToString())
                .End()
                .Redirect("Resources_Report.aspx")
            End With
            '============================================================================

        End If
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim i As Integer = 0
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow
                'right align everything before the dynamic columns
                For i = 0 To Me.IdxFirstDynamicColumn - 1

                    With e.Row.Cells(i)

                        .Width = Unit.Pixel(CType(Me.HfDateTimeCellsWidth.Value, Integer))
                        .VerticalAlign = VerticalAlign.Middle
                        .HorizontalAlign = HorizontalAlign.Right

                    End With

                Next

                'center align all cells of dynamic columns
                For i = Me.IdxFirstDynamicColumn To e.Row.Cells.Count - 1
                    With e.Row.Cells(i)
                        .Width = Unit.Pixel(CType(Me.HfDataCellsWidth.Value, Integer))
                        .VerticalAlign = VerticalAlign.Middle
                        .HorizontalAlign = HorizontalAlign.Center
                        Dim key As String = e.Row.Cells(i).Text.ToString()
                        If key.IndexOf("##") > -1 Then
                            key = key.Replace("##", "")
                            Dim ar() As String
                            ar = key.Split("|")
                            Dim CurrEventTypeId As Integer = CType(ar(0), Integer)
                            Dim CurrJobLogUdv1 As String = ar(1).ToString()
                            Select Case CurrEventTypeId
                                Case 0 'none
                                    If Me.ColorNoEventType = Nothing Then
                                        e.Row.Cells(i).BackColor = Drawing.Color.White
                                    Else
                                        e.Row.Cells(i).BackColor = Me.ColorNoEventType
                                    End If
                                Case 1 'static
                                    If Me.ColorStatic = Nothing Then
                                        e.Row.Cells(i).BackColor = Drawing.Color.Red
                                    Else
                                        e.Row.Cells(i).BackColor = Me.ColorStatic
                                    End If
                                Case 2 'flex
                                    If Me.ColorFlex = Nothing Then
                                        e.Row.Cells(i).BackColor = Drawing.Color.Green
                                    Else
                                        e.Row.Cells(i).BackColor = Me.ColorFlex
                                    End If
                                Case 3 'pre-emptable
                                    If Me.ColorPreEmptable = Nothing Then
                                        e.Row.Cells(i).BackColor = Drawing.Color.Blue
                                    Else
                                        e.Row.Cells(i).BackColor = Me.ColorPreEmptable
                                    End If
                                Case 4 'HOLD
                                    If Me.ColorHold = Nothing Then
                                        e.Row.Cells(i).BackColor = Drawing.Color.Yellow
                                    Else
                                        e.Row.Cells(i).BackColor = Me.ColorHold
                                    End If
                            End Select

                            If CurrJobLogUdv1.Trim() <> "" Then
                                If CurrJobLogUdv1.Trim().Length > 6 Then
                                    e.Row.Cells(i).Text = CurrJobLogUdv1.Trim().Substring(0, 6)
                                Else
                                    e.Row.Cells(i).Text = CurrJobLogUdv1.Trim()
                                End If
                            Else
                                e.Row.Cells(i).Text = "X"
                            End If


                        End If

                    End With
                Next

                'set style for the resource name row
                If e.Row.RowIndex = 0 Or e.Row.RowIndex = 1 Then
                    For i = 0 To e.Row.Cells.Count - 1
                        With e.Row.Cells(i)
                            .CssClass = "header2"
                            .Attributes.Add("style", Me.HfHeader2.Value)
                        End With
                    Next
                End If

                'Index column
                With e.Row.Cells(0)
                    .Text = "&nbsp;"
                    '.CssClass = "header2"
                    .Width = Unit.Pixel(0)
                End With

            Case DataControlRowType.Footer
                'Add the merged header row for the Resource Type
                Dim grow As New GridViewRow(1, -1, DataControlRowType.DataRow, DataControlRowState.Normal)
                For i = 0 To Me.IdxFirstDynamicColumn - 1 'cells before dynamic cells
                    Dim gcell As New TableCell()
                    With gcell
                        If i = IdxFirstDynamicColumn - 1 Then
                            .Text = "&nbsp;" '"Resource Type"
                        Else
                            .Text = "&nbsp;"
                        End If
                        .VerticalAlign = VerticalAlign.Middle
                        .HorizontalAlign = HorizontalAlign.Center
                        .CssClass = "header1"
                        .Attributes.Add("style", Me.HfHeader1.Value)
                    End With
                    grow.Cells.Add(gcell)

                Next
                For j As Integer = 0 To Me.StructData.ColumnData.Rows.Count - 1
                    Dim dcell As New TableCell()
                    With dcell
                        .Text = Me.StructData.ColumnData.Rows(j)("RESOURCE_TYPE_DESC").ToString()
                        .VerticalAlign = VerticalAlign.Middle
                        .HorizontalAlign = HorizontalAlign.Center
                        .CssClass = "header1"
                        .Attributes.Add("style", Me.HfHeader1.Value)
                        .ColumnSpan = CType(Me.StructData.ColumnData.Rows(j)("CT"), Integer)
                    End With
                    grow.Cells.Add(dcell)
                Next
                Dim str As String = e.Row.Parent.GetType().ToString()
                Dim str2 As String
                Dim tbl As Table = CType(e.Row.Parent, Table)
                tbl.Rows.AddAt(1, grow)

        End Select
    End Sub

    Private Sub Resources_RptExcel_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        '''EXPORT alt?
        '''============================================================================
        ''Response.Clear()
        ''Response.Buffer = True
        ''Response.ContentType = "application/vnd.ms-excel"
        ''Response.AddHeader("content-disposition", "attachment;filename=ResourceReport" & AdvantageFramework.StringUtilities.GUID_Date() & ".xls")
        ''Response.Charset = ""
        ''Me.EnableViewState = False
        '''============================================================================

        'Session("EVTRPT_OfficeList") = Nothing
        'Session("EVTRPT_CDPList") = Nothing
        'Session("EVTRPT_TrfFncList") = Nothing
        'Session("EVTRPT_EmployeeList") = Nothing
        'Session("EVTRPT_ResourceTypes") = Nothing
        'Session("EVTRPT_ResourceList") = Nothing

    End Sub
End Class