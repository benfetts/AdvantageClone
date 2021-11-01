Public Class DesktopCashBalance
    Inherits Webvantage.BaseDesktopObject

    Private _DsData As New DataSet
    Private ReadOnly Property DsData() As DataSet
        Get
            If _DsData Is Nothing Or _DsData.Tables.Count = 0 Then
                Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
                _DsData = oDO.GetCashBalance
            End If
            Return _DsData
        End Get
    End Property

    Private Sub RadGridSummary_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSummary.ItemDataBound
        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim griditem As Telerik.Web.UI.GridDataItem
                griditem = e.Item
                Dim amount As Decimal
                Dim debit As Decimal
                Dim credit As Decimal
                If griditem.GetDataKeyValue("CashType").ToString = "Cash Posted Today" Then
                    amount = CDec(griditem.GetDataKeyValue("Amount"))
                    debit = CDec(griditem.GetDataKeyValue("Debit"))
                    credit = CDec(griditem.GetDataKeyValue("Credit"))
                    griditem.Item("colAmount").Text = "DR " & String.Format("{0:#,##0.00}", debit) & "  CR " & String.Format("{0:#,##0.00}", credit) & "  Total " & String.Format("{0:#,##0.00}", amount)
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadGridSummary_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSummary.NeedDataSource
        Me.RadGridSummary.DataSource = Me.DsData.Tables(0)
    End Sub

    Private Sub RadGridBankBalance_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBankBalance.NeedDataSource
        Me.RadGridBankBalance.DataSource = Me.DsData.Tables(1)
    End Sub

    Private Sub ImageButtonRefresh_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefresh.Click

        Me.RadGridSummary.Rebind()
        Me.RadGridBankBalance.Rebind()

    End Sub
End Class