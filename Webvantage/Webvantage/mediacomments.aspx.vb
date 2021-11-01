Public Class mediacomments
    Inherits Webvantage.BaseChildPage
    Protected WithEvents dlMagOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlMagOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlNewsOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlNewsOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlInternetOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlInternetOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlOutOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlOutOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlRadioOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlRadioOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlTVOrderComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlTVOrderLineComment As System.Web.UI.WebControls.DataList
    Protected WithEvents dlRadioTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlTVTask As System.Web.UI.WebControls.DataList
    Protected WithEvents apnlMagazine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlMagOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlMagOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlNewspaper As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlNewsOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlNewsOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlInternet As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlInternetOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlInternetOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlOutdoor As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlOutOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlOutOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadio As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadioOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadioOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadioOrderLineOld As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadioOrderLineNew As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTV As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTVOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTVOrderLine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTVOrderLineOld As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTVOrderLineNew As System.Web.UI.WebControls.Panel
    Dim OrderNumber As Integer
    Dim LineNumber As Integer
    Dim RevNumber As Integer
    Dim MediaType As String
    Dim Com As Integer
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
        
        'Me.PageTitle.InnerText = System.Configuration.ConfigurationManager.AppSettings("AppTitle") & " - Task"
        If Page.IsPostBack = False Then
            LoadTask()
            'Me.butMarkCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Task as Complete?')==false) return false;")
        End If
    End Sub
    Private Sub LoadTask()
        OrderNumber = CInt(Request.Params("OrdNo"))
        LineNumber = CInt(Request.Params("LineNo"))
        RevNumber = CInt(Request.Params("RevNo"))
        MediaType = Request.Params("Type")
        Com = CInt(Request.Params("Com"))

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        If MediaType = "M" Then
            If Com = 1 Then
                dlMagOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType)
                dlMagOrderComment.DataBind()
                Me.apnlMagazine.Visible = True
                Me.apnlMagOrder.Visible = True
                Me.apnlMagOrderLine.Visible = False
            Else
                dlMagOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType)
                dlMagOrderLineComment.DataBind()
                Me.apnlMagazine.Visible = True
                Me.apnlMagOrder.Visible = False
                Me.apnlMagOrderLine.Visible = True
            End If
        End If
        If MediaType = "N" Then
            If Com = 1 Then
                dlNewsOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType)
                dlNewsOrderComment.DataBind()
                Me.apnlNewspaper.Visible = True
                Me.apnlNewsOrder.Visible = True
                Me.apnlNewsOrderLine.Visible = False
            Else
                dlNewsOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType)
                dlNewsOrderLineComment.DataBind()
                Me.apnlNewspaper.Visible = True
                Me.apnlNewsOrder.Visible = False
                Me.apnlNewsOrderLine.Visible = True
            End If
        End If
        If MediaType = "I" Then
            If Com = 1 Then
                dlInternetOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType)
                dlInternetOrderComment.DataBind()
                Me.apnlInternet.Visible = True
                Me.apnlInternetOrder.Visible = True
                Me.apnlInternetOrderLine.Visible = False
            Else
                dlInternetOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType)
                dlInternetOrderLineComment.DataBind()
                Me.apnlInternet.Visible = True
                Me.apnlInternetOrder.Visible = False
                Me.apnlInternetOrderLine.Visible = True
            End If
        End If
        If MediaType = "O" Then
            If Com = 1 Then
                dlOutOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType)
                dlOutOrderComment.DataBind()
                Me.apnlOutdoor.Visible = True
                Me.apnlOutOrder.Visible = True
                Me.apnlOutOrderLine.Visible = False
            Else
                dlOutOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType)
                dlOutOrderLineComment.DataBind()
                Me.apnlOutdoor.Visible = True
                Me.apnlOutOrder.Visible = False
                Me.apnlOutOrderLine.Visible = True
            End If
        End If
        If MediaType = "R" Then
            If Com = 1 Then
                dlRadioOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType, RevNumber)
                dlRadioOrderComment.DataBind()
                Me.apnlRadio.Visible = True
                Me.apnlRadioOrder.Visible = True
                Me.apnlRadioOrderLine.Visible = False
            Else
                dlRadioOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType, RevNumber)
                dlRadioOrderLineComment.DataBind()
                Me.apnlRadio.Visible = True
                Me.apnlRadioOrder.Visible = False
                Me.apnlRadioOrderLine.Visible = True
            End If
        End If
        If MediaType = "T" Then
            If Com = 1 Then
                dlTVOrderComment.DataSource = oTasks.GetCommentsOrderInfo(OrderNumber, MediaType, RevNumber)
                dlTVOrderComment.DataBind()
                Me.apnlTV.Visible = True
                Me.apnlTVOrder.Visible = True
                Me.apnlTVOrderLine.Visible = False
            Else
                dlTVOrderLineComment.DataSource = oTasks.GetCommentsOrderDetail(OrderNumber, LineNumber, MediaType, RevNumber)
                dlTVOrderLineComment.DataBind()
                Me.apnlTV.Visible = True
                Me.apnlTVOrder.Visible = False
                Me.apnlTVOrderLine.Visible = True
            End If
        End If


    End Sub

    Public Function ShowTaskStatus(ByVal TaskStatus As String) As String
        Select Case TaskStatus.ToUpper
            Case "P"
                Return "Projected"
            Case "A"
                Return "Active"
        End Select
    End Function

    Private Sub mediacomments_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

    End Sub
End Class
