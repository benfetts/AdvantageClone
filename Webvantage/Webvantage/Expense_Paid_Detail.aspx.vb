Imports System.Data.SqlClient

Partial Public Class expense_paid_detail
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then

            loadgrid()

        End If

    End Sub

    Private Function loadgrid()
        Dim inv_nbr As Long
        Dim emp As String
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim ds As DataSet

        inv_nbr = CType(Request.QueryString("Inv"), Long)
        emp = Request.QueryString("Emp")
        ds = oExpense.GetInvoiceDetail(emp, inv_nbr)

        Me.RadGrid1.DataSource = ds
        Me.RadGrid1.DataBind()

        'Me.tbemployee.Text = emp
        'Me.tbinvnbr.Text = CType(inv_nbr, String)
        Me.lblemp.Text = emp
        Me.lblinv.Text = CType(inv_nbr, String)

    End Function

End Class