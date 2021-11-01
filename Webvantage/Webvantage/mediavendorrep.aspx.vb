Public Class mediavendorrep
    Inherits Webvantage.BaseChildPage
    Protected WithEvents dlVendorRep As System.Web.UI.WebControls.DataList
    Protected WithEvents apnlVendorRep As System.Web.UI.WebControls.Panel
    Dim RepNo As Integer
    Dim VendorCode As String
    Dim VendorRepCode As String
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
        
        If Page.IsPostBack = False Then
            LoadTask()
        End If
    End Sub
    Private Sub LoadTask()
        RepNo = CInt(Request.Params("RepNo"))
        VendorCode = Request.Params("Vncode")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        VendorRepCode = Request.Params("Vrcode")
        dlVendorRep.DataSource = oTasks.GetVendorRepInfo(VendorCode, VendorRepCode)
        dlVendorRep.DataBind()
        Me.apnlVendorRep.Visible = True

    End Sub

    Public Function ShowTaskStatus(ByVal TaskStatus As String) As String
        Select Case TaskStatus.ToUpper
            Case "P"
                Return "Projected"
            Case "A"
                Return "Active"
        End Select
    End Function

    Public lab As System.Web.UI.WebControls.Label
    Private Sub dlVendorRep_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlVendorRep.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                     e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblAddress"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            If e.Item.DataItem("VR_ADDRESS1").ToString() = "" And e.Item.DataItem("VR_ADDRESS2").ToString() = "" Then
                lab.Text = ""
            End If
            If e.Item.DataItem("VR_ADDRESS1").ToString() <> "" And e.Item.DataItem("VR_ADDRESS2").ToString() = "" Then
                lab.Text = e.Item.DataItem("VR_ADDRESS1").ToString
            End If
            If e.Item.DataItem("VR_ADDRESS1").ToString() = "" And e.Item.DataItem("VR_ADDRESS2").ToString() <> "" Then
                lab.Text = e.Item.DataItem("VR_ADDRESS2").ToString
            End If

            lab = CType(e.Item.FindControl("lblPhone"), Label)
            If e.Item.DataItem("VR_TELEPHONE").ToString() = "" And e.Item.DataItem("VR_EXTENTION").ToString() = "" Then
                lab.Text = ""
            End If
            If e.Item.DataItem("VR_TELEPHONE").ToString() <> "" And e.Item.DataItem("VR_EXTENTION").ToString() = "" Then
                lab.Text = e.Item.DataItem("VR_TELEPHONE").ToString
            End If

            lab = CType(e.Item.FindControl("lblFax"), Label)
            If e.Item.DataItem("VR_FAX").ToString() = "" And e.Item.DataItem("VR_FAX_EXTENTION").ToString() = "" Then
                lab.Text = ""
            End If
            If e.Item.DataItem("VR_FAX").ToString() <> "" And e.Item.DataItem("VR_FAX_EXTENTION").ToString() = "" Then
                lab.Text = e.Item.DataItem("VR_FAX").ToString
            End If


        End If
    End Sub
End Class
