Imports System.Data.SqlClient
Public Class mediavendorinfo
    Inherits Webvantage.BaseChildPage
    Protected WithEvents dlMediaInfoMag As System.Web.UI.WebControls.DataList
    Protected WithEvents dlMediaInfoNews As System.Web.UI.WebControls.DataList
    Protected WithEvents dlDelivery As System.Web.UI.WebControls.DataList
    Protected WithEvents apnlMediaInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlMediaInfoMag As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlMediaInfoNews As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlDelivery As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlSpecs As System.Web.UI.WebControls.Panel
    Protected WithEvents gvSpecs As System.Web.UI.WebControls.GridView
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnClose As System.Web.UI.WebControls.Button
    Protected WithEvents btnInsert As System.Web.UI.WebControls.Button
    Dim VendorCode As String
    Dim VendorName As String
    Dim MediaType As String
    Dim MediaId As String
    Dim AdSize As String = ""
    Dim dr As SqlDataReader
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
            If Request.QueryString("page") = "jobspecs" Then
                Me.btnCancel.Visible = False
                Me.btnClose.Visible = True
                Me.btnInsert.Visible = True
            Else
                Me.btnCancel.Visible = False
                Me.btnClose.Visible = True
                Me.btnInsert.Visible = False
            End If
            LoadTask()
            'Me.butMarkCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Task as Complete?')==false) return false;")
        End If
        If Me.IsClientPortal = True Then
            Me.btnInsert.Visible = False
        End If
    End Sub
    Private Sub LoadTask()
        VendorCode = Request.Params("VnCode")
        'VendorName = Request.Params("VnName")
        MediaType = Request.Params("Type")
        MediaId = Request.Params("mid")
        AdSize = Request.Params("AdSize")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        If MediaId = "1" Then
            Me.apnlMediaInfo.Visible = True
            Me.btnInsert.Visible = False
            If MediaType = "M" Then
                dlMediaInfoMag.DataSource = oTasks.GetMediaInfo(VendorCode, MediaType)
                dlMediaInfoMag.DataBind()
                Me.apnlMediaInfo.Visible = True
                Me.apnlMediaInfoMag.Visible = True
                Me.apnlMediaInfoNews.Visible = False
            End If
            If MediaType = "N" Then
                dlMediaInfoNews.DataSource = oTasks.GetMediaInfo(VendorCode, MediaType)
                dlMediaInfoNews.DataBind()
                Me.apnlMediaInfo.Visible = True
                Me.apnlMediaInfoMag.Visible = False
                Me.apnlMediaInfoNews.Visible = True
            End If
        Else
            Me.apnlMediaInfo.Visible = False
        End If
        If MediaId = "2" Then
            dr = oTasks.GetMediaDelivery(VendorCode, MediaType)
            dlDelivery.DataSource = oTasks.GetMediaDelivery(VendorCode, MediaType)
            dlDelivery.DataBind()
            Me.apnlDelivery.Visible = True
            If Session("JSaddVen") = 2 Then
                Me.btnInsert.Visible = False
            End If
        Else
            Me.apnlDelivery.Visible = False
        End If
        If MediaId = "3" Then
            If AdSize <> "" Then
                gvSpecs.DataSource = oTasks.GetMediaSpecsByAdSizeGrid(VendorCode, MediaType, AdSize)
            Else
                gvSpecs.DataSource = oTasks.GetMediaSpecs(VendorCode, MediaType)
            End If
            gvSpecs.DataBind()
            Me.apnlSpecs.Visible = True
            Me.btnInsert.Visible = False
        Else
            Me.apnlSpecs.Visible = False
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

    Public lab As System.Web.UI.WebControls.Label
    Private Sub dlDelivery_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlDelivery.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                    e.Item.ItemType = ListItemType.AlternatingItem Then

            lab = CType(e.Item.FindControl("lblShippingAddress"), Label)
            If dr.HasRows = True Then
                Do While dr.Read
                    Dim strAddress As String
                    If dr.IsDBNull(0) = False Then
                        strAddress = strAddress & dr.GetString(0) & "<br />"
                    End If
                    If dr.IsDBNull(1) = False Then
                        strAddress = strAddress & dr.GetString(1) & "<br />"
                    End If
                    If dr.IsDBNull(2) = False Then
                        strAddress = strAddress & dr.GetString(2) & "<br />"
                    End If
                    If dr.IsDBNull(3) = False Then
                        strAddress = strAddress & dr.GetString(3) & ", "
                    End If
                    If dr.IsDBNull(4) = False Then
                        strAddress = strAddress & dr.GetString(4) & " "
                    End If
                    If dr.IsDBNull(5) = False Then
                        strAddress = strAddress & dr.GetString(5) & "<br />"
                    End If
                    lab.Text = strAddress
                Loop
            End If
        End If
        dr.Close()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        MediaId = Request.Params("mid")
        If MediaId = "2" Then
            Dim label As System.Web.UI.WebControls.Label
            If dlDelivery.Items.Count > 0 Then
                label = Me.dlDelivery.Items(0).FindControl("lblGeneralInfo")
                Dim strScript As String
                strScript = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_txtShippingComments').value = '" & label.Text & "';"
                Me.ControlsToSet = strScript.ToString
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")
            End If
            'Dim strScript As String
            'strScript = "<script type=""text/javascript"">"
            'strScript &= "opener.document.forms[0].txtShippingComments.value = '" & label.Text & "';"
            'strScript &= "window.close();</script>"
            'If Not Page.IsStartupScriptRegistered("WebvantageSpec") Then
            '    Page.RegisterStartupScript("WebvantageSpec", strScript)
            'End If

        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Me.CloseThisWindow()
        Dim cScript As String
        cScript = "<script>window.close();</script>"
        RegisterStartupScript("pagemedia", cScript)
    End Sub
End Class
