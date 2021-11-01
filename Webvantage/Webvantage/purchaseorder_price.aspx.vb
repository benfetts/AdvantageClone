Imports System.Data.SqlClient

Partial Public Class purchaseorder_price
    Inherits Webvantage.BaseChildPage

    Private _JobType As String = ""
    Private _VendorCode As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Request.QueryString("job_type") Is Nothing Then

            _JobType = Request.QueryString("job_type").Trim()

        End If
        If Not Request.QueryString("vn_code") Is Nothing Then

            _VendorCode = Request.QueryString("vn_code").Trim()

        End If
        If Not Page.IsPostBack Then

            If Not Request.QueryString("qty") Is Nothing AndAlso IsNumeric(Request.QueryString("qty")) Then

                RadNumericTextBoxQuantity.Value = CType(Request.QueryString("qty"), Decimal)

                If RadNumericTextBoxQuantity.Value Is Nothing OrElse RadNumericTextBoxQuantity.Value = 0 Then

                    RadNumericTextBoxQuantity.Value = 1

                End If

            End If
            Try

                Me.OpenerRadWindowName = Request.QueryString("opener")

            Catch ex As Exception

                Me.OpenerRadWindowName = ""

            End Try

        End If

    End Sub

    Private Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Try
            Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        Try

            Dim sb As New System.Text.StringBuilder
            With sb

                .Append("CallingWindowContent.$find($(CallingWindowContent.document).find('[adv-calc=Rate]')[0].id).set_value(" & Me.RadNumericTextBoxRate.Text.ToString & ");")
                .Append("CallingWindowContent.$find($(CallingWindowContent.document).find('[adv-calc=Quantity]')[0].id).set_value(" & RadNumericTextBoxQuantity.Text.ToString() & ");")
            End With
            Me.ControlsToSet = sb.ToString
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dl_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dl_filter.SelectedIndexChanged

        Select Case Me.dl_filter.SelectedValue.Trim

            Case Else
                Me.radGridVendorList.Rebind()

        End Select

    End Sub
    Private Sub radGridVendorList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles radGridVendorList.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "Select"

                Dim qty As Decimal = 0
                Dim rate As Decimal = 0
                Dim total As Decimal = 0

                rate = CType(e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("VN_PRICING_RATE"), Decimal)

                If Not RadNumericTextBoxQuantity.Value Is Nothing Then

                    qty = CType(RadNumericTextBoxQuantity.Value, Decimal)

                End If

                Me.RadNumericTextBoxRate.Value = rate
                Me.RadNumericTextBoxAmount.Value = (rate * qty)

        End Select
    End Sub
    Private Sub radGridVendorList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridVendorList.NeedDataSource
        Try
            Dim PO As wPurchaseOrder.cPurchaseOrder = New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Me.radGridVendorList.DataSource = PO.LoadAll_PO_VendorPrices_SelectedVendor(Int32.Parse(dl_filter.SelectedValue), _VendorCode, _JobType, "", "")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadNumericTextBoxQuantity_TextChanged(sender As Object, e As EventArgs) Handles RadNumericTextBoxQuantity.TextChanged

        Me.CalcTotal()

    End Sub

    Private Sub RetrievePriceList()

        Dim PO As wPurchaseOrder.cPurchaseOrder = New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        Dim dr2 As SqlDataReader

        If Not dr2 Is Nothing AndAlso dr2.HasRows = True Then

            Me.radGridVendorList.Visible = True
            Me.radGridVendorList.DataSource = dr2
            Me.radGridVendorList.DataBind()

        Else

            Me.radGridVendorList.Visible = False

        End If

    End Sub
    Private Sub CalcTotal()

        Try

            Dim qty As Decimal = 0
            Dim rate As Decimal = 0

            If IsNumeric(Me.RadNumericTextBoxQuantity.Value) = True Then

                qty = CDec(Me.RadNumericTextBoxQuantity.Value)

            End If

            If RadNumericTextBoxRate.Value.HasValue Then

                rate = CDec(RadNumericTextBoxRate.Value)

            End If

            Me.RadNumericTextBoxAmount.Value = (qty * rate)

        Catch ex As Exception

        End Try

    End Sub

End Class