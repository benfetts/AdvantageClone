
Partial Public Class DirectExpenseAlert_Detail
    Inherits Webvantage.BaseChildPage

    Public PPStart, PPEnd, Inv, vCode, vDesc As String

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            LoadGrid(True)
        End If

    End Sub

    Private Sub LoadGrid(ByVal ab_bind As Boolean)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        PPStart = Session("PPBEGIN_DEA")
        PPEnd = Session("PPEND_DEA")
        Inv = CStr(Request.Params("Inv"))
        vCode = CStr(Request.Params("Code")) 'Session("GLACODE")
        vDesc = CStr(Request.Params("Name")) 'Session("GLADESC")

        Me.lblVendorCode.Text = vCode
        Me.lblVendorName.Text = vDesc
        Me.lblInvNbr.Text = Inv

        Me.RadGrid1.DataSource = oDO.GetDirectExpenseDet(PPStart, PPEnd, Inv)
        If ab_bind Then
            Me.RadGrid1.DataBind()
        End If

    End Sub

    Private Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        LoadGrid(False)
    End Sub
End Class