Imports System.Data.SqlClient

Partial Public Class purchaseOrderbyJobCompPopup
    Inherits Webvantage.BaseChildPage

    Private _JobNumber As Integer = 0
    Private _JobComponentNbr As Integer = 0
    Private _IsJobDashBoard As Boolean = False

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me._JobNumber = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me._JobComponentNbr = qs.JobComponentNumber
        If qs.IsJobDashboard = True Then

            _IsJobDashBoard = True

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LoadHeader()
            LoadGrid()

        End If

    End Sub

    Private Function LoadHeader()

        If _IsJobDashBoard = False Then

            Me.lblTitle.Text = "Purchase Orders for Job/Comp " & Me._JobNumber.ToString.PadLeft(6, "0") & "/" & Me._JobComponentNbr.ToString.PadLeft(2, "0")

        Else

            Me.lblTitle.Visible = False

        End If

    End Function

    Private Function LoadGrid() As DataTable

        Try

            Dim SQL_STRING As String
            Dim oSQL As SqlHelper
            Dim arParams(2) As SqlParameter

            Dim paramJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            paramJOB_NUMBER.Value = Me._JobNumber
            arParams(0) = paramJOB_NUMBER

            Dim paramJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            paramJOB_COMPONENT_NBR.Value = Me._JobComponentNbr
            arParams(1) = paramJOB_COMPONENT_NBR

            Try
                Return oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "proc_WV_PO_GetByJobComp", "DtPO", arParams)
            Catch
                Return Nothing
            End Try

        Catch ex As Exception
        End Try
    End Function

    Private Sub POGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles POGrid.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Try
            Select Case e.CommandName
                Case "ViewPO"

                    Dim strURL As String
                    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                    strURL = "purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(e.CommandArgument) & "&pagemode=edit"

                    Dim dataitem As Telerik.Web.UI.GridDataItem = e.Item

                    Me.OpenWindow("PO " + dataitem.GetDataKeyValue("PO_NUMBER_DISPLAY") + " - " + dataitem.GetDataKeyValue("PO_DESCRIPTION").ToString.Replace("'", "\'"), strURL)

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub POGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles POGrid.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("ViewLinkButton")

            If IsNumeric(e.Item.DataItem("PO_NUMBER_DISPLAY")) = True Then

                ViewLinkButton.Text = e.Item.DataItem("PO_NUMBER_DISPLAY").ToString.PadLeft(8, "0")

            Else

                ViewLinkButton.Text = e.Item.DataItem("PO_NUMBER_DISPLAY")

            End If

            ViewLinkButton.CommandArgument = e.Item.DataItem("PO_NUMBER")
            ViewLinkButton.CommandName = "ViewPO"

        End If
    End Sub

    Private Sub POGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles POGrid.NeedDataSource
        Me.POGrid.DataSource = Me.LoadGrid()
    End Sub

End Class
