Public Class NewER
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim EmployeeCode As String = Request.QueryString("empcode")
        Response.Redirect("Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" & EmployeeCode)

    End Sub

End Class
