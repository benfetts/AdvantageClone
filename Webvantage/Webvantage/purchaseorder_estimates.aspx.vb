Imports System.Data.SqlClient
Partial Public Class purchaseorder_estimates
    Inherits Webvantage.BaseChildPage
    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Dim dTotal(20) As Decimal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not Request.QueryString("po_number") Is Nothing Then

                Purchaseorder_base_info1.PO_Number = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number").Trim())
                Purchaseorder_base_info1.RetrievePOHeader()

                Dim ix As Integer
                For ix = 0 To 19 Step 1
                    dTotal(ix) = 0
                Next

                RetrieveEstimateLines()
                Try
                    Me.RadTabStripPOEstimates.SelectedIndex = 2
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Sub RetrieveEstimateLines()
        Dim dr As SqlDataReader

        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
        dr = POHeader.LoadAll_PO_Estimate_Details(3, Me.Purchaseorder_base_info1.PO_Number, "")

        Me.gvEstimateItems.DataSource = dr
        Me.gvEstimateItems.DataBind()

    End Sub
    Public Function GetColumnAmount(ByVal Column_Id As Integer, ByVal Amount As String) As String
        Try
            Me.dTotal(Column_Id) = Me.dTotal(Column_Id) + Decimal.Parse(Amount)
        Catch ex As Exception
        End Try

        Return Amount
    End Function
    Function GetColumnTotal(ByVal Column_Id As Integer) As String
        Return Me.dTotal(Column_Id).ToString
    End Function

    Private Sub RadTabStripPOEstimates_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripPOEstimates.TabClick

        Dim ThisPO As String = ""
        ThisPO = AdvantageFramework.Security.Encryption.EncryptPO(Me.Purchaseorder_base_info1.PO_Number.ToString().Trim())
        Select Case Me.RadTabStripPOEstimates.SelectedTab.Index
            Case 0
                Server.Transfer("purchaseorder_funct_summ.aspx?po_number=" & ThisPO)
            Case 1
                Server.Transfer("purchaseorder_ap_summ.aspx?po_number=" & ThisPO)
        End Select
    End Sub
End Class
