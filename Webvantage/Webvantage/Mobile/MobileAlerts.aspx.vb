Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Drawing

Partial Public Class MobileAlerts
    Inherits MobileBase
    Public sRestrictBrowser() As String

    Private Sub MobileAlerts_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsNumeric(ddCount.SelectedValue) Then
            ddCount.SelectedIndex = 0
        End If
        If Not IsPostBack() Then
            sRestrictBrowser = Split(System.Configuration.ConfigurationManager.AppSettings("RestrictMobile").ToString(), ",")
            If Not IsNothing(Session("AlertsToDisplay")) Then
                Me.ddCount.SelectedValue = Session("AlertsToDisplay")
            End If
        End If


        LoadAlerts()
        HideColumns()
    End Sub
    Private Sub LoadAlerts()
        Dim MyAlerts As New vMyAlerts(Session("ConnString"))
        Try
            MyAlerts.Where.EMP_CODE.Value = Session("EmpCode")

            MyAlerts.Query.AddOrderBy(MyAlerts.ColumnNames.GENERATED, MyGeneration.dOOdads.WhereParameter.Dir.DESC)
            MyAlerts.Where.PROCESSED.Operator = MyGeneration.dOOdads.WhereParameter.Operand.IsNull
            MyAlerts.Query.Load()
        Catch x As Exception

        End Try
        Dim oDataView As New DataView
        Dim iCount As Integer = MyAlerts.DefaultView.Count
        Dim iAlertCount As Integer
        iAlertCount = CInt(ddCount.SelectedValue)
        If iCount >= iAlertCount Then
            oDataView = SelectTopFrom(MyAlerts.DefaultView, iAlertCount - 1)
        Else
            oDataView = SelectTopFrom(MyAlerts.DefaultView, MyAlerts.DefaultView.Count - 1)
        End If

        gvAlerts.DataSource = oDataView
        gvAlerts.DataBind()

    End Sub

    Private Function SelectTopFrom(ByVal dv As DataView, ByVal iCount As Integer) As DataView
        Dim oDataTable As DataTable = CreateTable(dv)
        Dim oDataTable2 As New DataTable
        oDataTable2 = oDataTable.Clone

        For i As Integer = 0 To iCount
            oDataTable2.ImportRow(oDataTable.Rows(i))
        Next
        Dim oDataView As New DataView(oDataTable2)
        Return oDataView

    End Function
    Public Function CreateTable(ByVal obDataView As DataView) As DataTable
        If obDataView Is Nothing Then
            Throw New ArgumentNullException("DataView", "Invalid DataView object specified")
        End If

        Dim obNewDt As DataTable = obDataView.Table.Clone()
        Dim idx As Integer = 0
        Dim strColNames As String() = New String(obNewDt.Columns.Count - 1) {}
        'For Each col As DataColumn In obNewDt.Columns
        '    '    strColNames(System.Math.Max(System.Threading.Interlocked.Increment(idx), idx - 1)) = col.ColumnName
        '    strColNames(idx) = col.ColumnName
        'Next

        For i As Integer = 0 To obNewDt.Columns.Count - 1
            strColNames(i) = obNewDt.Columns(i).ColumnName
        Next

        Dim viewEnumerator As IEnumerator = obDataView.GetEnumerator()
        While viewEnumerator.MoveNext()
            Dim drv As DataRowView = DirectCast(viewEnumerator.Current, DataRowView)
            Dim dr As DataRow = obNewDt.NewRow()
            Try
                For Each strName As String In strColNames
                    dr(strName) = drv(strName)
                Next
            Catch ex As Exception

            End Try
            obNewDt.Rows.Add(dr)
        End While

        Return obNewDt
    End Function

    'Private Sub gvAlerts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAlerts.RowCommand
    '    Select Case e.CommandName
    '        Case "View"
    '            MiscFN.ResponseRedirect("~/Mobile/MobileAlertView.aspx?Alert=" & e.CommandArgument)
    '    End Select
    'End Sub
    Private Sub HideColumns()
        If (Not IsNothing(Request.Headers("User-Agent"))) Then
            If Not IsNothing(sRestrictBrowser) Then
                For i As Integer = 0 To sRestrictBrowser.GetUpperBound(0)
                    If Request.Headers("User-Agent").Contains(sRestrictBrowser(i).ToString()) Then
                        Me.gvAlerts.Columns(0).Visible = False
                        gvAlerts.Columns(1).Visible = False
                        gvAlerts.Columns(3).Visible = False
                        Me.btnRefreshList.Visible = True
                    End If
                Next
            End If
        End If



    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAlerts.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                Dim PriorityImage As System.Web.UI.WebControls.Image = e.Row.Cells(1).FindControl("PriorityImage")
                Select Case e.Row.DataItem("PRIORITY")
                    Case 1
                        PriorityImage.ImageUrl = "~/Images/bang.png"
                        e.Row.ForeColor = Color.Red
                    Case 3
                        PriorityImage.ImageUrl = "~/images/low.png"

                    Case Else
                        PriorityImage.ImageUrl = "~/images/spacer.gif"
                End Select
                Dim ViewHyperlink As System.Web.UI.WebControls.HyperLink = e.Row.Cells(0).FindControl("ViewHyperlink")
                ViewHyperlink.NavigateUrl = "~/Mobile/MobileAlertView.aspx?alert=" & e.Row.DataItem("ALERT_ID")
                ViewHyperlink.ImageUrl = "~/images/view-trans.png"

                Dim hlView As System.Web.UI.WebControls.HyperLink = e.Row.Cells(2).FindControl("hlView")
                hlView.Text = e.Row.DataItem("Subject").ToString
                hlView.NavigateUrl = "~/Mobile/MobileAlertView.aspx?alert=" & e.Row.DataItem("ALERT_ID")

                If IsDBNull(e.Row.DataItem("READ_ALERT")) Then
                    e.Row.Font.Bold = True
                Else
                    e.Row.Font.Bold = False
                End If
            Case Else

        End Select
        'Select Case e.Item.ItemType
        '    Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
        '        Dim ra As String = e.Item.Cells(7).Text
        '        If ra = "&nbsp;" Then
        '            e.Item.Font.Bold = True
        '        Else
        '            e.Item.Font.Bold = False
        '        End If
        '        Dim PriorityImage As System.Web.UI.WebControls.Image = e.Item.Cells(1).FindControl("PriorityImage")
        '        Select Case e.Item.DataItem("PRIORITY")
        '            Case 1
        '                PriorityImage.ImageUrl = "~/images/bang.png"
        '                e.Item.ForeColor = Color.Red

        '            Case 3
        '                PriorityImage.ImageUrl = "~/images/low.png"
        '            Case Else
        '                PriorityImage.ImageUrl = "~/images/spacer.gif"
        '        End Select

        '        Dim ViewHyperlink As System.Web.UI.WebControls.HyperLink = e.Item.Cells(0).FindControl("ViewHyperlink")
        '        ViewHyperlink.NavigateUrl = "~/Alertview.aspx?alert=" & e.Item.DataItem("ALERT_ID")


        '        Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.Cells(3).FindControl("ViewLinkButton")
        '        ViewLinkButton.Text = e.Item.DataItem("Subject")
        '        ViewLinkButton.CommandArgument = e.Item.DataItem("ALERT_ID")
        '        ViewLinkButton.CommandName = "View"

        '    Case Telerik.Web.UI.GridItemType.GroupHeader

    End Sub

    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/default.aspx")
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub


    Private Sub ddCount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddCount.SelectedIndexChanged
        Session("AlertsToDisplay") = ddCount.SelectedValue
    End Sub

    'Protected Sub btnRefreshList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefreshList.Click
    '    ddCount_SelectedIndexChanged(Me, Nothing)
    'End Sub


End Class