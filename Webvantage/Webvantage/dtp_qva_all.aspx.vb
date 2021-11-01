Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class dtp_qva_all
    Inherits Webvantage.BaseChildPage

    Public CurrentPageMode As DesktopQvA.PageMode = DesktopQvA.PageMode.AllQvA

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If Not qs.GetValue("m") Is Nothing AndAlso IsNumeric(qs.GetValue("m")) Then

            Me.CurrentPageMode = CType(CType(Request.QueryString("m"), Integer), DesktopQvA.PageMode)

        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim CurrentDTO As cAppVars.Application

            If Me.CurrentPageMode = DesktopQvA.PageMode.AllQvA Then

                Me.LabelObjectType.Text = "QvA"
                CurrentDTO = cAppVars.Application.ALL_QVA_DTO

            ElseIf Me.CurrentPageMode = DesktopQvA.PageMode.MyQvA Then

                Me.LabelObjectType.Text = "My QvA"
                CurrentDTO = cAppVars.Application.MY_QVA_DTO

            End If

            Dim str As String = String.Empty
            Dim strtype As String = String.Empty
            Dim oAppVars As New cAppVars(CurrentDTO)

            oAppVars.getAllAppVars()

            Select Case oAppVars.getAppVar("Type", "Boolean")
                Case "True"

                    strtype = "Time Only"

                Case "False"

                    strtype = "All"

            End Select

            Me.LabelReportType.Text = str

            LoadGrid()

        Catch ex As Exception

            Throw (ex)

        End Try

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(QVAAllRadGrid2)

    End Sub

    Private Sub LoadGrid()

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim client As String = ""
        Dim division As String = ""
        Dim product As String = ""
        Dim search As String = ""
        Dim strtype As String = ""
        Dim duedate As String = ""
        Dim office As String = ""
        Dim campaign As String = ""
        Dim ae As String = ""
        Dim salesclass As String = ""
        Dim manager As String = ""
        Dim job As String = ""
        Dim comp As String = ""
        Dim group As String = Request.QueryString("group")
        Dim grouptype As String = Request.QueryString("grouptype")

        Dim taskVar As String
        Dim arCDP() As String

        Dim CurrentDTO As cAppVars.Application

        If Me.CurrentPageMode = DesktopQvA.PageMode.AllQvA Then

            CurrentDTO = cAppVars.Application.ALL_QVA_DTO

        ElseIf Me.CurrentPageMode = DesktopQvA.PageMode.MyQvA Then

            CurrentDTO = cAppVars.Application.MY_QVA_DTO

        End If
        Dim oAppVars As New cAppVars(CurrentDTO)
        oAppVars.getAllAppVars()

        taskVar = oAppVars.getAppVar("CLIENT")
        If taskVar <> "" Then
            client = taskVar
            client = MiscFN.RemoveDuplicatesFromString(client, ",")
            client = MiscFN.RemoveTrailingDelimiter(client, ",")
        End If

        taskVar = oAppVars.getAppVar("DIVISION")
        If taskVar <> "" Then
            Try
                arCDP = taskVar.Split(",")
                For x As Integer = 0 To arCDP.Length - 1
                    Dim ar() As String = arCDP(x).Split(":")
                    For y As Integer = 0 To ar.Length - 1
                        client &= ar(0) & ","
                        division &= ar(1) & ","
                    Next
                Next
                client = MiscFN.RemoveDuplicatesFromString(client, ",")
                client = MiscFN.RemoveTrailingDelimiter(client, ",")
                division = MiscFN.RemoveDuplicatesFromString(division, ",")
                division = MiscFN.RemoveTrailingDelimiter(division, ",")
            Catch ex As Exception
            End Try
        End If

        taskVar = oAppVars.getAppVar("PRODUCT")
        If taskVar <> "" Then
            Try
                arCDP = taskVar.Split(",")
                For x As Integer = 0 To arCDP.Length - 1
                    Dim ar() As String = arCDP(x).Split(":")
                    For y As Integer = 0 To ar.Length - 1
                        client &= ar(0) & ","
                        division &= ar(1) & ","
                        product &= ar(2) & ","
                    Next
                Next
                client = MiscFN.RemoveDuplicatesFromString(client, ",")
                client = MiscFN.RemoveTrailingDelimiter(client, ",")
                division = MiscFN.RemoveDuplicatesFromString(division, ",")
                division = MiscFN.RemoveTrailingDelimiter(division, ",")
                product = MiscFN.RemoveDuplicatesFromString(product, ",")
                product = MiscFN.RemoveTrailingDelimiter(product, ",")
            Catch ex As Exception
            End Try
        End If

        taskVar = oAppVars.getAppVar("CAMPAIGN")
        If taskVar <> "" Then
            Try
                arCDP = taskVar.Split(",")
                For x As Integer = 0 To arCDP.Length - 1
                    Dim ar() As String = arCDP(x).Split(":")
                    'For y As Integer = 0 To ar.Length - 1
                    client &= ar(0) & ","
                        division &= ar(1) & ","
                        product &= ar(2) & ","
                        campaign &= ar(4) & ","
                    'Next
                Next
                client = MiscFN.RemoveDuplicatesFromString(client, ",")
                client = MiscFN.RemoveTrailingDelimiter(client, ",")
                division = MiscFN.RemoveDuplicatesFromString(division, ",")
                division = MiscFN.RemoveTrailingDelimiter(division, ",")
                product = MiscFN.RemoveDuplicatesFromString(product, ",")
                product = MiscFN.RemoveTrailingDelimiter(product, ",")
            Catch ex As Exception
            End Try
        End If

        taskVar = oAppVars.getAppVar("JOB")
        If taskVar <> "" Then
            job = taskVar
        End If

        taskVar = oAppVars.getAppVar("COMP")
        If taskVar <> "" Then
            Try
                arCDP = taskVar.Split(",")
                For x As Integer = 0 To arCDP.Length - 1
                    Dim ar() As String = arCDP(x).Split("-")
                    'For y As Integer = 0 To ar.Length - 1
                    job &= ar(0) & ","
                    comp &= ar(1) & ","
                    'Next
                Next
            Catch ex As Exception
            End Try
        End If

        taskVar = oAppVars.getAppVar("OFFICE")
        If taskVar <> "" Then
            office = taskVar
            office = MiscFN.RemoveDuplicatesFromString(office, ",")
            office = MiscFN.RemoveTrailingDelimiter(office, ",")
        End If
        taskVar = oAppVars.getAppVar("AE")
        If taskVar <> "" Then
            ae = taskVar
            ae = MiscFN.RemoveDuplicatesFromString(ae, ",") & ","
            ae = MiscFN.RemoveTrailingDelimiter(ae, ",")
        End If
        taskVar = oAppVars.getAppVar("SC")
        If taskVar <> "" Then
            salesclass = taskVar
            salesclass = MiscFN.RemoveDuplicatesFromString(salesclass, ",")
            salesclass = MiscFN.RemoveTrailingDelimiter(salesclass, ",")
        End If
        taskVar = oAppVars.getAppVar("MANAGER")
        If taskVar <> "" Then
            manager = taskVar
            manager = MiscFN.RemoveDuplicatesFromString(manager, ",")
            manager = MiscFN.RemoveTrailingDelimiter(manager, ",")
        End If

        search = oAppVars.getAppVar("Search")
        strtype = oAppVars.getAppVar("Type", "Boolean")
        duedate = oAppVars.getAppVar("QvADueDate")

        Dim QueryTypeID As String = "All"

        If Me.CurrentPageMode = DesktopQvA.PageMode.MyQvA Then

            QueryTypeID = "My"

            office = ""
            salesclass = ""
            manager = ""
            ae = "" 'CStr(Session("EmpCode"))

        End If

        If office = "ALL" Then office = ""
        If salesclass = "ALL" Then salesclass = ""
        If manager = "ALL" Then manager = ""
        If ae = "ALL" Then ae = ""

        If duedate = "True" Then

            Me.QVAAllRadGrid2.MasterTableView.GetColumn("DueDate").Display = True

        Else

            Me.QVAAllRadGrid2.MasterTableView.GetColumn("DueDate").Display = False

        End If

        Me.QVAAllRadGrid2.DataSource = oDO.GetQVA(ae, client, division, product, strtype, Session("UserCode"), search, QueryTypeID, office, salesclass, manager, job, comp, campaign, group, grouptype)
        Me.QVAAllRadGrid2.DataBind()

        Dim sort As String
        Dim sort2 As String

        If Not Session("DOSortExp") Is Nothing Then
            If Session("DOSortExp") <> "" Then
                Dim expr As New GridSortExpression
                sort = Session("DOSortExp").ToString
                'sort = sort.Substring(0, sort.Length - 1)
                Dim sortexpr2() As String = sort.Split(",")
                For i As Integer = 0 To sortexpr2.Length - 1
                    sortexpr2(i) = sortexpr2(i).Trim
                    Dim sortstr2() As String = sortexpr2(i).Split(" ")
                    expr = New GridSortExpression
                    expr.FieldName = sortstr2(0).Trim
                    If sortstr2(1).Trim = "ASC" Then
                        expr.SortOrder = GridSortOrder.Ascending
                    ElseIf sortstr2(1).Trim = "DESC" Then
                        expr.SortOrder = GridSortOrder.Descending
                    Else
                        expr.SortOrder = GridSortOrder.None
                    End If
                    Me.QVAAllRadGrid2.MasterTableView.SortExpressions.AddSortExpression(expr)
                Next
            End If
        End If

        If Not Session("DOFilterExp") Is Nothing Then
            If Session("DOFilterExp") <> "" Then
                Me.QVAAllRadGrid2.MasterTableView.FilterExpression = Session("DOFilterExp")
            End If
        End If

        Me.QVAAllRadGrid2.Rebind()

    End Sub
    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("group") = "campaign" Then
                Me.QVAAllRadGrid2.MasterTableView.Columns.FindByUniqueName("columnJob").Display = False
            End If

            If Request.QueryString("export") = 1 Then

                Dim str As String = ""

                str = Me.CurrentPageMode.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)

                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.QVAAllRadGrid2, str)

                QVAAllRadGrid2.MasterTableView.ExportToExcel()

            Else

                'Me.QVAAllRadGrid.Visible = False

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QVAAllRadGrid2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles QVAAllRadGrid2.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                Dim FlagImage As Web.UI.WebControls.Image = e.Item.FindControl("ImageFlag")

                dtp_qva.GetColor(e.Item.DataItem("Quoted"), e.Item.DataItem("Actual"), FlagColorDiv, FlagImage)

                Dim str As String = e.Item.Cells(4).Text

                If Request.QueryString("group") = "job" Then

                    e.Item.Cells(5).Text = e.Item.DataItem("Job")

                Else

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class