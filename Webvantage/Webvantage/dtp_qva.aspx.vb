Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class dtp_qva
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Dim str As String = String.Empty
                    Dim strtype As String = String.Empty
                    Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
                    oAppVars.getAllAppVars()

                    Select Case oAppVars.getAppVar("QvAType", "Boolean")
                        Case "True"
                            strtype = "Time Only"
                        Case "False"
                            strtype = "All"
                    End Select

                    'str = "Client:" & Session("QvACli") & _
                    '        "  Division:" & Session("QvADiv") & _
                    '        "  Product:" & Session("QvAPrd") & _
                    '        "  Threshold:" & Request.QueryString("threshold") & _
                    '        "  Type:" & strtype
                    str = "Client:" & oAppVars.getAppVar("QvACli") & _
                            "  Division:" & oAppVars.getAppVar("QvADiv") & _
                            "  Product:" & oAppVars.getAppVar("QvAPrd") & _
                            "  Threshold:" & Request.QueryString("threshold") & _
                            "  Type:" & strtype

                    Me.lblDescript.Text = str
                    LoadGrid()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridQVA2)


    End Sub
    Private Sub LoadGrid()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim client, division, product, search, strtype, duedate As String
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
        oAppVars.getAllAppVars()

        'client = Session("QvACli")
        'division = Session("QvADiv")
        'product = Session("QvAPrd")
        client = oAppVars.getAppVar("QvACli")
        division = oAppVars.getAppVar("QvADiv")
        product = oAppVars.getAppVar("QvAPrd")
        search = oAppVars.getAppVar("QvASearch")
        strtype = oAppVars.getAppVar("QvAType", "Boolean")
        duedate = oAppVars.getAppVar("QvADueDate")

        If client.ToUpper = "ALL" Then client = ""
        If division.ToUpper = "ALL" Then division = ""
        If product.ToUpper = "ALL" Then product = ""

        If duedate = "True" Then
            Me.RadGridQVA2.MasterTableView.GetColumn("DueDate").Display = True
        Else
            Me.RadGridQVA2.MasterTableView.GetColumn("DueDate").Display = False
        End If

        'Me.repQVA.DataSource = oDO.GetQVA(CStr(Session("EmpCode")), client, division, product, Request.QueryString("timeonly"), Session("UserCode"), search)
        Me.RadGridQVA2.DataSource = oDO.GetQVA(CStr(Session("EmpCode")), client, division, product, strtype, Session("UserCode"), search, "My", "", "", "", "", "", "", "", "")
        'Me.repQVA.DataBind()
        Me.RadGridQVA2.DataBind()

        Dim sort As String
        Dim sort2 As String

        If Not Session("QVADOSortExp") Is Nothing Then
            If Session("QVADOSortExp") <> "" Then
                Dim expr As New GridSortExpression
                sort = Session("QVADOSortExp").ToString
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
                    Me.RadGridQVA2.MasterTableView.SortExpressions.AddSortExpression(expr)
                Next
            End If
        End If


        Me.RadGridQVA2.Rebind()
    End Sub
    Public Shared Sub GetColor(ByVal Quoted As Decimal, ByVal Actual As Decimal, ByRef FlagDiv As HtmlControls.HtmlControl, ByRef FlagImage As WebControls.Image)

        Dim dThresh As Double

        If IsNumeric(HttpContext.Current.Request.QueryString("threshold")) = True Then

            dThresh = CDbl(HttpContext.Current.Request.QueryString("threshold").Trim) * 0.01

            If Quoted > 0 Then

                If Actual > (Quoted * dThresh) Then

                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                Else

                    AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.LightGreen)

                End If

            Else

                AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Amber)

            End If

        Else

            AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.LightGreen)

        End If
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "QVA" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridQVA2, str)
                RadGridQVA2.MasterTableView.ExportToExcel()
            Else
                'Me.RadGridQVA.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQVA2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQVA2.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                Dim FlagImage As Web.UI.WebControls.Image = e.Item.FindControl("ImageFlag")

                GetColor(e.Item.DataItem("Quoted"), e.Item.DataItem("Actual"), FlagColorDiv, FlagImage)

            End If
        Catch ex As Exception

        End Try

    End Sub

End Class