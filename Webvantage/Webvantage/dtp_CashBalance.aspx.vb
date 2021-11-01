Public Class dtp_CashBalance
    Inherits Webvantage.BaseChildPage

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

    Private Sub RadGridSummary_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridSummary.NeedDataSource
        Me.RadGridSummary.DataSource = Me.DsData.Tables(0)
    End Sub

    Private Sub RadGridBankBalance_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBankBalance.NeedDataSource
        Me.RadGridBankBalance.DataSource = Me.DsData.Tables(1)
    End Sub

    Private Sub dtp_CashBalance_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub
End Class