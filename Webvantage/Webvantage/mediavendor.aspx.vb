Public Class mediavendor
    Inherits Webvantage.BaseChildPage
    Protected WithEvents lbMediaInfo As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbMediaDelivery As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbMediaSpecs As System.Web.UI.WebControls.LinkButton
    Protected WithEvents apnlVendor As System.Web.UI.WebControls.Panel
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnClose As System.Web.UI.WebControls.Button
    Protected WithEvents LitScript As System.Web.UI.WebControls.Literal
    Dim VendorCode As String
    Dim VendorName As String
    Dim MediaType As String
    Protected PageTitle As System.Web.UI.HtmlControls.HtmlGenericControl
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        Me.AllowFloat = True
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

        VendorCode = Request.QueryString("VnCode")
        MediaType = Request.QueryString("Type")
        If MediaType = "I" Or MediaType = "O" Then
            Me.lbMediaInfo.Visible = False
        End If
        If MediaType = "R" Or MediaType = "T" Then
            Me.lbMediaInfo.Visible = False
            Me.lbMediaSpecs.Visible = False
        End If
        If Request.QueryString("page") = "jobspecs" Then
            Me.btnCancel.Visible = False
            Me.btnClose.Visible = False
        Else
            Me.btnCancel.Visible = False
            Me.btnClose.Visible = True
        End If
        Dim CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
        Me.btnCancel.Attributes.Add("onclick", CancelScript)

    End Sub
   
    Private Sub lbMediaInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMediaInfo.Click
        Try
            Dim strURL As String = "mediavendorinfo.aspx?mid=1&VnCode=" & VendorCode & "&Type=" & MediaType
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            'Page.RegisterClientScriptBlock("newpage", strBuilder.ToString())
            Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'Me.OpenWindow("", strURL, 400, 435)
        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try
    End Sub

    Private Sub lbMediaDelivery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMediaDelivery.Click
        Try
            Dim strURL As String = "mediavendorinfo.aspx?mid=2&VnCode=" & VendorCode & "&Type=" & MediaType
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            'Page.RegisterClientScriptBlock("newpage", strBuilder.ToString())
            Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'Me.OpenWindow("", strURL, 400, 435)
        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try
    End Sub

    Private Sub lbMediaSpecs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMediaSpecs.Click
        Try
            Dim strURL As String = "mediavendorinfo.aspx?mid=3&VnCode=" & VendorCode & "&Type=" & MediaType
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            strBuilder.Append("<script language='javascript'>")
            strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
            strBuilder.Append("</")
            strBuilder.Append("script>")
            'Page.RegisterClientScriptBlock("newpage", strBuilder.ToString())
            Page.RegisterStartupScript("newpage", strBuilder.ToString())
            'Me.OpenWindow("", strURL, 400, 435)
        Catch ex As Exception
            Me.ShowMessage("err opening print data window")
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim cScript As String
        cScript = "<script>window.close();</script>"
        RegisterStartupScript("pagemedia", cScript)
    End Sub

End Class
