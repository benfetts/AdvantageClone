Public Class Event_Print_HTML_PB
    Inherits System.Web.UI.Page


    Private ds As New DataSet
    Private ReportType As String = ""
    Private ShowImages As Boolean = True
    Private EnableEmail As Boolean = False
    Private StartDate As String = ""
    Private EndDate As String = ""
    Private OfficeList As String = ""
    Private CDPList As String = ""
    Private ResourceList As String = ""
    Private TrfFncList As String = ""
    Private EmployeeList As String = ""
    Private IncludeTerminatedEmployees As Boolean = False
    Private IncludeInactiveResources As Boolean = False
    'Protected WithEvents DivPageBreak As System.Web.UI.HtmlControls.HtmlGenericControl
    Public Overrides Sub VerifyRenderingInServerForm(control As System.Web.UI.Control)


    End Sub

    Private Sub Event_Print_HTML_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request.QueryString("r") Is Nothing Then
            If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.IE) = True Then
                MiscFN.ResponseRedirect("Event_Print_HTML.aspx?r=1")
            End If
        End If

        Try
            reporttype = Session("EVTRPT_ReportType")
        Catch ex As Exception
            reporttype = "evt_employee"
        End Try
        Try
            ShowImages = CType(Session("EVTRPT_ShowImages"), Boolean)
        Catch ex As Exception
            ShowImages = True
        End Try
        Try
            EnableEmail = CType(Session("EVTRPT_EnableEmail"), Boolean)
        Catch ex As Exception
            EnableEmail = True
        End Try
        Try
            StartDate = Session("EVTRPT_StartDate")
        Catch ex As Exception
            StartDate = Now.Month.ToString() & "/1/" & Now.Year.ToString()
        End Try
        Try
            EndDate = Session("EVTRPT_EndDate")
        Catch ex As Exception
            EndDate = Now.ToShortDateString()
        End Try
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
            ResourceList = Session("EVTRPT_ResourceList")
        Catch ex As Exception
            ResourceList = ""
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
            Me.IncludeInactiveResources = CType(Session("EVTRPT_InclInactiveResources"), Boolean)
        Catch ex As Exception
            Me.IncludeInactiveResources = False
        End Try
        Try
            Me.IncludeTerminatedEmployees = CType(Session("EVTRPT_InclTermintatedEmployees"), Boolean)
        Catch ex As Exception
            Me.IncludeTerminatedEmployees = False
        End Try

        Dim evt As New cEvents
        ds = evt.Event_Report_HTML_DS(Me.ReportType, Me.StartDate, Me.EndDate, Me.OfficeList, Me.CDPList, Me.ResourceList, Me.TrfFncList, Me.EmployeeList, Me.IncludeTerminatedEmployees, Me.IncludeInactiveResources)
        If Not ds Is Nothing Then
            With Me.RptrGrouping
                .DataSource = ds.Tables(0)
                .DataBind()
            End With
        End If

    End Sub

    Private Sub RptrGrouping_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles RptrGrouping.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) And Not ds Is Nothing Then
            Dim RepeaterEvents As New Repeater
            RepeaterEvents = CType(e.Item.FindControl("RptrEvent"), Repeater)
            Dim CurrGroupVal As String = ""

            If Me.ReportType = "evt_employee" Then
                CurrGroupVal = e.Item.DataItem("EMP_CODE")
            ElseIf Me.ReportType = "evt_resource" Then
                CurrGroupVal = e.Item.DataItem("RESOURCE_CODE")
            End If

            If CurrGroupVal <> "" Then
                CType(e.Item.FindControl("LblGroupingTitle"), Label).Text = "Events and Tasks for:  " & e.Item.DataItem("GRP_HEADER").ToString() & ", " & Convert.ToDateTime(StartDate).ToShortDateString() & " - " & Convert.ToDateTime(EndDate).ToShortDateString()
                Dim dt As New DataTable
                dt = ds.Tables(1)
                Dim dv As DataView = New DataView(dt)
                If Me.ReportType = "evt_employee" Then
                    dv.RowFilter = "EMP_CODE = '" & CurrGroupVal & "'"
                ElseIf Me.ReportType = "evt_resource" Then
                    dv.RowFilter = "RESOURCE_CODE = '" & CurrGroupVal & "'"
                End If
                With RepeaterEvents
                    .DataSource = dv.ToTable()
                    .DataBind()
                End With
            End If
            Try
                Dim btn As Button
                If Me.ReportType = "evt_employee" Then
                    btn = CType(e.Item.FindControl("BtnEmail"), Button)
                    btn.Visible = Me.EnableEmail
                ElseIf Me.ReportType = "evt_resource" Then
                    btn = CType(e.Item.FindControl("BtnEmail"), Button)
                    btn.Visible = False
                End If
                If btn.Visible = True Then
                    Dim hfe As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfEmailAddress"), HiddenField)
                    btn.Enabled = AdvantageFramework.Email.IsValidEmailAddress(hfe.Value)
                End If
            Catch ex As Exception
            End Try
            'Try
            '    Dim DivPageBreak As System.Web.UI.HtmlControls.HtmlGenericControl
            '    DivPageBreak = CType(e.Item.FindControl("DivPageBreak"), System.Web.UI.HtmlControls.HtmlGenericControl)
            '    With DivPageBreak.Attributes
            '        .Clear()
            '        .Add("class", "page-break")
            '    End With
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Dim RowSpan As Integer = 6
    Public Sub RptrEvents_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) And Not ds Is Nothing Then
            Dim GridviewEventTasks As New GridView
            GridviewEventTasks = CType(e.Item.FindControl("GvEventTasks"), GridView)

            Dim CurrGroupVal As String = ""
            Dim FilterField As String = ""
            If Me.ReportType = "evt_employee" Then
                CurrGroupVal = e.Item.DataItem("EMP_CODE")
                FilterField = "EMP_CODE"
            ElseIf Me.ReportType = "evt_resource" Then
                CurrGroupVal = e.Item.DataItem("RESOURCE_CODE")
                FilterField = "RESOURCE_CODE"
            End If

            Dim CurrGroupEventId As String = e.Item.DataItem("EVENT_ID")
            Dim dt As New DataTable
            dt = ds.Tables(2)
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = FilterField & " = '" & CurrGroupVal & "' AND EVENT_ID = " & CurrGroupEventId
            With GridviewEventTasks
                .DataSource = dv.ToTable()
                .DataBind()
            End With
            If Me.ReportType = "evt_employee" Then
                GridviewEventTasks.Columns(0).Visible = False
            ElseIf Me.ReportType = "evt_resource" Then
                GridviewEventTasks.Columns(0).Visible = True
            End If

            For Each row As GridViewRow In GridviewEventTasks.Rows
                If row.Cells(3).Text <> "" Then
                    row.Cells(3).Text = CType(LoGlo.FormatDate(row.Cells(3).Text), Date).ToLongDateString
                End If
                If row.Cells(4).Text <> "" Then
                    row.Cells(4).Text = CType(LoGlo.FormatDateTime(row.Cells(4).Text), Date).ToShortTimeString
                End If
                If row.Cells(5).Text <> "" Then
                    row.Cells(5).Text = CType(LoGlo.FormatDateTime(row.Cells(5).Text), Date).ToShortTimeString
                End If
            Next
            'image stuff
            Dim DocId As Integer = 0
            Dim img As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgAdNumber"), System.Web.UI.WebControls.Image)
            If Me.ShowImages = True Then
                Try
                    Dim hf As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfDOCUMENT_ID"), HiddenField)
                    Try
                        If hf.Value.Trim() <> "" Then
                            DocId = CType(hf.Value.Trim(), Integer)
                        Else
                            DocId = 0
                        End If
                    Catch ex As Exception
                        DocId = 0
                    End Try
                    If DocId > 0 Then
                        'set dynamic image
                        img.ImageUrl = "Thumbnail.aspx?docid=" & DocId.ToString() & "&w=100"
                    Else
                        'img.ImageUrl = "~/Images/no_image.gif"
                        img.Visible = False
                    End If
                Catch ex As Exception
                End Try
            Else
                img.Visible = False
            End If

            'set rows and columns

            'make sure html is correctly spanning
            Dim TdAdNumberImage As System.Web.UI.HtmlControls.HtmlTableCell
            TdAdNumberImage = CType(e.Item.FindControl("TdAdNumberImage"), System.Web.UI.HtmlControls.HtmlTableCell)
            TdAdNumberImage.Attributes.Add("rowspan", Me.RowSpan.ToString())
        End If
    End Sub

    Public Sub BtnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim StrHTML As String = ""
            Dim StrEmail As String = ""
            Dim ri As RepeaterItem = CType(CType(sender, Button).Parent.Parent, RepeaterItem)
            Dim de As System.Web.UI.HtmlControls.HtmlGenericControl

            de = CType(ri.FindControl("div_email"), System.Web.UI.HtmlControls.HtmlGenericControl)

            Try

                Dim HfEmail As System.Web.UI.WebControls.HiddenField
                HfEmail = de.FindControl("HfEmailAddress")
                StrEmail = HfEmail.Value

            Catch ex As Exception
                StrEmail = ""
            End Try

            If AdvantageFramework.Email.IsValidEmailAddress(StrEmail) = True Then
                Dim sw As New System.IO.StringWriter
                Dim w As New HtmlTextWriter(sw)
                Dim bool As Boolean

                de.RenderControl(w)
                StrHTML = sw.GetStringBuilder().ToString()
                StrHTML = MiscFN.RemoveInputTag(StrHTML)

                StrHTML = StrHTML.Replace("font-size:X-Small;", "font-size:XX-Small;").Replace("font size=""2""", "font size=""1""")

                Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                bool = ws.SendEmail("", StrEmail, "Schedule ready", StrHTML, "", "", True, 1)

                If bool = False Then

                    'wvMsgBox(ws.getErrMsg)

                End If

            End If
        Catch ex As Exception
        End Try
    End Sub


End Class