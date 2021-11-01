Public Class dtp_clientaging
    Inherits Webvantage.BaseChildPage

    Private IsMy As Boolean = False

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Request.QueryString("my") Is Nothing Then
                If CType(Request.QueryString("my"), Integer) = 1 Then
                    IsMy = True
                Else
                    IsMy = False
                End If
            End If
        Catch ex As Exception
            IsMy = False
        End Try
        If IsMy = True Then
            Me.Page.Title = "My Client Aging"
            Me.lblTitle.Text = "My Client Aging"
        Else
            Me.Page.Title = "Client Aging"
            Me.lblTitle.Text = "Client Aging"
        End If
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadGraph(Request.QueryString("Client"), Request.QueryString("office"), Request.QueryString("division"), Request.QueryString("product"), Request.QueryString("from"), Request.QueryString("cat"))
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Dim DtGraphData As New DataTable
    Private Sub LoadGraph(ByVal strClient As String, ByVal strOffice As String, ByVal strDivision As String, ByVal strProduct As String, ByVal fromDO As String, ByVal cats As String)

        Dim ShowMy As Boolean = False
        If fromDO = "mca" Then ShowMy = True

        Me.lblTitle.Text = "Client Aging"
        If strClient = "" And strOffice = "" And strDivision = "" And strProduct = "" Then
            Me.lblClient.Text = "All Offices/Clients/Divisions/Products"
        End If
        If strOffice <> "" Then
            Me.lblClient.Text = "Office:  " & strOffice & "&nbsp;&nbsp;"
        End If
        If strClient <> "" Then
            Me.lblClient.Text = Me.lblClient.Text & "Client:  " & strClient & "&nbsp;&nbsp;"
        End If
        If strDivision <> "" Then
            Me.lblClient.Text = Me.lblClient.Text & "Division:  " & strDivision & "&nbsp;&nbsp;"
        End If
        If strProduct <> "" Then
            Me.lblClient.Text = Me.lblClient.Text & "Product:  " & strProduct & "&nbsp;&nbsp;"
        End If

        Me.lblDate.Text = Now.ToShortDateString

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        DtGraphData = oDO.GetInvoiceARBalanceGraph(CStr(Session("UserCode")), strClient.Trim, strOffice.Trim, strDivision.Trim, strProduct.Trim, ShowMy, cats)

        oDO = Nothing

        CreateChart()

    End Sub

    Private Sub CreateChart()

        'objects
        Dim IsMyClientAging As Boolean = False

        If Request.QueryString("from") = "mca" Then

            IsMyClientAging = True

        End If

        cCharting.GetChart_ClientAging(RadHtmlChartClientAging, DtGraphData, "", False, ShowMyClientAging:=IsMyClientAging)

    End Sub

End Class