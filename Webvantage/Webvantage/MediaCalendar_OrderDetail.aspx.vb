Imports System.Drawing

Public Class MediaCalendar_OrderDetail
    Inherits Webvantage.BaseChildPage
    Protected WithEvents dlMagTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlNewsTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlInternetTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlOutTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlRadioTask As System.Web.UI.WebControls.DataList
    Protected WithEvents dlTVTask As System.Web.UI.WebControls.DataList
    Protected WithEvents apnlMagazine As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlNewspaper As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlInternet As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlOutdoor As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadio As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTV As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlMagazineDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlNewspaperDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlInternetDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlOutdoorDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlRadioDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents apnlTVDoc As System.Web.UI.WebControls.Panel
    Protected WithEvents lblRevision As System.Web.UI.WebControls.Label
    Protected WithEvents butMarkCompleted As System.Web.UI.WebControls.Button
    Protected WithEvents butMarkNotCompleted As System.Web.UI.WebControls.Button
    Protected WithEvents ButtonCancel As System.Web.UI.WebControls.Button
    Protected WithEvents ImageButtonDocumentsMagazine As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButtonDocumentsNewspaper As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButtonDocumentsInternet As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButtonDocumentsOutdoor As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButtonDocumentsRadio As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButtonDocumentsTV As System.Web.UI.WebControls.ImageButton
    Protected WithEvents divDocumentsMagazine As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divDocumentsNewspaper As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divDocumentsInternet As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divDocumentsOutdoor As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divDocumentsRadio As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents divDocumentsTV As System.Web.UI.HtmlControls.HtmlGenericControl
    Dim OrderNumber As Integer
    Dim LineNumber As Integer
    Dim RevNumber As Integer
    Dim MediaType As String
    Dim MediaYear As String
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
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_MediaCalendar)

        If Page.IsPostBack = False Then
            LoadTask()
            Me.butMarkCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Order as Complete?')==false) return false;")
            Me.butMarkNotCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Order as not Complete?')==false) return false;")

        End If

        If Me.IsClientPortal = True Then
            Me.butMarkCompleted.Visible = False
            Me.butMarkNotCompleted.Visible = False
        End If

    End Sub
    Private Sub LoadTask()
        OrderNumber = CInt(Request.Params("OrdNo"))
        LineNumber = CInt(Request.Params("LineNo"))
        RevNumber = CInt(Request.Params("RevNo"))
        MediaType = Request.Params("MediaType")
        MediaYear = Request.QueryString("Year")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If MediaType = "M" Then
                dlMagTask.DataSource = oTasks.GetMediaMagTask(OrderNumber, LineNumber, RevNumber)
                dlMagTask.DataBind()
                Me.apnlMagazine.Visible = True
            End If
            If MediaType = "N" Then
                dlNewsTask.DataSource = oTasks.GetMediaNewsTask(OrderNumber, LineNumber, RevNumber)
                dlNewsTask.DataBind()
                Me.apnlNewspaper.Visible = True
            End If
            If MediaType = "I" Then
                dlInternetTask.DataSource = oTasks.GetMediaInternetTask(OrderNumber, LineNumber, RevNumber)
                dlInternetTask.DataBind()
                Me.apnlInternet.Visible = True
            End If
            If MediaType = "O" Then
                dlOutTask.DataSource = oTasks.GetMediaOutTask(OrderNumber, LineNumber, RevNumber)
                dlOutTask.DataBind()
                Me.apnlOutdoor.Visible = True
            End If
            If MediaType = "R" Then
                dlRadioTask.DataSource = oTasks.GetMediaRadioTask(OrderNumber, LineNumber, RevNumber, CInt(MediaYear))
                dlRadioTask.DataBind()
                Me.apnlRadio.Visible = True
            End If
            If MediaType = "T" Then
                dlTVTask.DataSource = oTasks.GetMediaTVTask(OrderNumber, LineNumber, RevNumber, CInt(MediaYear))
                dlTVTask.DataBind()
                Me.apnlTV.Visible = True
            End If

        End Using


    End Sub

    Private Sub butMarkCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMarkCompleted.Click
        OrderNumber = CInt(Request.Params("OrdNo"))
        LineNumber = CInt(Request.Params("LineNo"))
        RevNumber = CInt(Request.Params("RevNo"))
        MediaType = Request.Params("MediaType")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))


        If oTasks.MarkCompletedMedia(OrderNumber, LineNumber, RevNumber, MediaType, Today.Date) = True Then
        End If

        'LoadTask()

        Me.CloseThisWindowAndRefreshCaller("MediaCalendar.aspx")

    End Sub

    Private Sub butMarkNotCompleted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butMarkNotCompleted.Click
        OrderNumber = CInt(Request.Params("OrdNo"))
        LineNumber = CInt(Request.Params("LineNo"))
        RevNumber = CInt(Request.Params("RevNo"))
        MediaType = Request.Params("MediaType")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        If oTasks.MarkCompletedMedia(OrderNumber, LineNumber, RevNumber, MediaType, "") = True Then
        End If

        'LoadTask()

        Me.CloseThisWindowAndRefreshCaller("MediaCalendar.aspx")
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
    Public imgBtn As System.Web.UI.WebControls.ImageButton
    Public pnldoc As System.Web.UI.WebControls.Panel
    Public docdiv As System.Web.UI.HtmlControls.HtmlGenericControl


    Private Sub dlMagTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlMagTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                     e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text = "M" Then
                lab.Text = "M|Magazine"
            End If
            lab = CType(e.Item.FindControl("lblMarket"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If

            lab = CType(e.Item.FindControl("lblInsertDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If

            lab = CType(e.Item.FindControl("lblAdNumber"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If

            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If

            lab = CType(e.Item.FindControl("lblAccepted"), Label)
            If lab.Text <> "" Then
                If lab.Text = "1" Then
                    lab.Text = "Y"
                Else
                    lab.Text = "N"
                End If
            Else
                lab.Text = "N"
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsMagazine"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsMagazine"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsMagazine As Generic.List(Of AdvantageFramework.Database.Entities.MagazineDocument) = Nothing

                If MediaType = "M" Then

                    documentsMagazine = AdvantageFramework.Database.Procedures.MagazineDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsMagazine IsNot Nothing Then
                        If documentsMagazine.Count > 0 Then
                            imgBtn.ToolTip = documentsMagazine.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using
        End If
    End Sub

    Private Sub dlNewsTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlNewsTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                             e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text = "N" Then
                lab.Text = "N|Newspaper"
            End If
            lab = CType(e.Item.FindControl("lblMarket"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblAdNumber"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblAdSize"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If

            lab = CType(e.Item.FindControl("lblInsertDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If
            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If
            lab = CType(e.Item.FindControl("lblAccepted"), Label)
            If lab.Text <> "" Then
                If lab.Text = "1" Then
                    lab.Text = "Y"
                Else
                    lab.Text = "N"
                End If
            Else
                lab.Text = "N"
            End If
            lab = CType(e.Item.FindControl("lblCostType"), Label)
            If lab.Text = "CPM" Then
                lab = CType(e.Item.FindControl("lblQtyCirculation"), Label)
                lab.Text = String.Format("{0:#,##0}", CDbl(lab.Text))
                lab.Visible = True
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsNewspaper"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsNewspaper"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsNewspaper As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperDocument) = Nothing

                If MediaType = "N" Then

                    documentsNewspaper = AdvantageFramework.Database.Procedures.NewspaperDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsNewspaper IsNot Nothing Then
                        If documentsNewspaper.Count > 0 Then
                            imgBtn.ToolTip = documentsNewspaper.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using
        End If

    End Sub

    Private Sub dlOutTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlOutTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                                     e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblMType"), Label)
            If lab.Text = "O" Then
                lab.Text = "O|Outdoor"
            End If
            lab = CType(e.Item.FindControl("lblMarket"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblSize"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblAdNumber"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblInsertDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblEndDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If
            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If
            lab = CType(e.Item.FindControl("lblAccepted"), Label)
            If lab.Text <> "" Then
                If lab.Text = "1" Then
                    lab.Text = "Y"
                Else
                    lab.Text = "N"
                End If
            Else
                lab.Text = "N"
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsOutdoor"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsOutdoor"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsOutdoor As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeDocument) = Nothing

                If MediaType = "O" Then

                    documentsOutdoor = AdvantageFramework.Database.Procedures.OutOfHomeDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsOutdoor IsNot Nothing Then
                        If documentsOutdoor.Count > 0 Then
                            imgBtn.ToolTip = documentsOutdoor.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using
        End If
    End Sub

    Private Sub dlInternetTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlInternetTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                                             e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblMType"), Label)
            If lab.Text = "I" Then
                lab.Text = "I|Internet"
            End If
            lab = CType(e.Item.FindControl("lblMarket"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblAdNumber"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblGuaranteedImpressions"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblInsertDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblEndDate"), Label)
            If lab.Text <> "" Then
                Dim dt As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If
            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If
            lab = CType(e.Item.FindControl("lblAccepted"), Label)
            If lab.Text <> "" Then
                If lab.Text = "1" Then
                    lab.Text = "Y"
                Else
                    lab.Text = "N"
                End If
            Else
                lab.Text = "N"
            End If
            lab = CType(e.Item.FindControl("lblCostType"), Label)
            If lab.Text = "CPM" Then
                lab = CType(e.Item.FindControl("lblGuaranteedImpressions"), Label)
                lab.Text = String.Format("{0:#,##0.}", CDbl(lab.Text))
                lab.Visible = True
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsInternet"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsInternet"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsInternet As Generic.List(Of AdvantageFramework.Database.Entities.InternetDocument) = Nothing

                If MediaType = "I" Then

                    documentsInternet = AdvantageFramework.Database.Procedures.InternetDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsInternet IsNot Nothing Then
                        If documentsInternet.Count > 0 Then
                            imgBtn.ToolTip = documentsInternet.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using
        End If
    End Sub

    Private Sub dlRadioTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlRadioTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                             e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text = "R" Then
                lab.Text = "R|Radio"
            End If
            lab = CType(e.Item.FindControl("lblFlight"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If

            lab = CType(e.Item.FindControl("lblStartDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If
            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsRadio"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsRadio"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsRadio As Generic.List(Of AdvantageFramework.Database.Entities.RadioDocument) = Nothing

                If MediaType = "R" Then

                    documentsRadio = AdvantageFramework.Database.Procedures.RadioDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsRadio IsNot Nothing Then
                        If documentsRadio.Count > 0 Then
                            imgBtn.ToolTip = documentsRadio.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using
        End If
    End Sub

    Private Sub dlTVTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlTVTask.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or _
                                     e.Item.ItemType = ListItemType.AlternatingItem Then
            lab = CType(e.Item.FindControl("lblClient"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblDivision"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblProduct"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblOrder"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblCampaign"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblType"), Label)
            If lab.Text = "R" Then
                lab.Text = "R|Radio"
            End If
            lab = CType(e.Item.FindControl("lblFlight"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendor"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep1"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblVendorRep2"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJob"), Label)
            If lab.Text = "|" Then
                lab.Text = ""
            End If
            lab = CType(e.Item.FindControl("lblJobComp"), Label)
            If lab.Text.Trim = "|" Then
                lab.Text = ""
            End If

            lab = CType(e.Item.FindControl("lblStartDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt2 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt2.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtCloseDate"), Label)
            If lab.Text <> "" Then
                Dim dt3 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt3.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt4 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt4.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblExtMaterialDate"), Label)
            If lab.Text <> "" Then
                Dim dt5 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt5.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblOrderDate"), Label)
            If lab.Text <> "" Then
                Dim dt6 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt6.ToShortDateString
            End If
            lab = CType(e.Item.FindControl("lblCompletedDate"), Label)
            If lab.Text <> "" Then
                Dim dt7 As DateTime = Convert.ToDateTime(lab.Text)
                lab.Text = dt7.ToShortDateString()
                Me.butMarkNotCompleted.Visible = True
                Me.butMarkCompleted.Visible = False
            Else
                Me.butMarkNotCompleted.Visible = False
                Me.butMarkCompleted.Visible = True
            End If
            lab = CType(e.Item.FindControl("lblLine"), Label)
            If lab.Text <> "" And e.Item.DataItem("LINE_CANCELLED").ToString() <> "" Then
                Dim cancel As Integer = e.Item.DataItem("LINE_CANCELLED")
                If cancel = 1 Then
                    lab.ForeColor = Color.Red
                    lab.Text = lab.Text & " (CANCELLED)"
                    lab = CType(e.Item.FindControl("lblBillingAmount"), Label)
                    lab.Text = "0.00"
                End If
            End If

            imgBtn = CType(e.Item.FindControl("ImageButtonDocumentsTV"), ImageButton)
            docdiv = CType(e.Item.FindControl("divDocumentsTV"), HtmlControls.HtmlGenericControl)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim documentsTelevision As Generic.List(Of AdvantageFramework.Database.Entities.TVDocument) = Nothing

                If MediaType = "T" Then

                    documentsTelevision = AdvantageFramework.Database.Procedures.TVDocument.LoadByOrderID(DbContext, OrderNumber).ToList
                    If documentsTelevision IsNot Nothing Then
                        If documentsTelevision.Count > 0 Then
                            imgBtn.ToolTip = documentsTelevision.Count.ToString & " Order Documents"
                        Else
                            imgBtn.Visible = False
                            docdiv.Visible = False
                        End If
                    End If

                End If

            End Using


        End If
    End Sub


    Private Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Try
            Me.CloseThisWindowAndRefreshCaller("MediaCalendar.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ImageButtonDocs_Click(sender As Object, e As ImageClickEventArgs)
        Try
            Dim documentsMagazine As Generic.List(Of AdvantageFramework.Database.Entities.MagazineDocument) = Nothing
            Dim documentsNewspaper As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperDocument) = Nothing
            Dim documentsOutofHome As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeDocument) = Nothing
            Dim documentsInternet As Generic.List(Of AdvantageFramework.Database.Entities.InternetDocument) = Nothing
            Dim documentsRadio As Generic.List(Of AdvantageFramework.Database.Entities.RadioDocument) = Nothing
            Dim documentsTelevision As Generic.List(Of AdvantageFramework.Database.Entities.TVDocument) = Nothing

            Dim DtRecs As New DataTable
            Dim zip As New Ionic.Zip.ZipFile

            Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
            COL_DOC_ID.DataType = GetType(Int32)

            Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
            COL_MIME_TYPE.DataType = GetType(String)

            Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
            COL_FILENAME.DataType = GetType(String)

            Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
            COL_REPOSITORY_FILENAME.DataType = GetType(String)

            Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
            COL_UPLOADED_DATE.DataType = GetType(DateTime)

            With DtRecs.Columns

                .Add(COL_DOC_ID)
                .Add(COL_FILENAME)
                .Add(COL_REPOSITORY_FILENAME)
                .Add(COL_UPLOADED_DATE)

            End With

            OrderNumber = CInt(Request.Params("OrdNo"))
            LineNumber = CInt(Request.Params("LineNo"))
            RevNumber = CInt(Request.Params("RevNo"))
            MediaType = Request.Params("MediaType")
            MediaYear = Request.QueryString("Year")

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If MediaType = "M" Then
                    documentsMagazine = AdvantageFramework.Database.Procedures.MagazineDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsMagazine IsNot Nothing Then
                        Select Case documentsMagazine.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsMagazine.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsMagazine
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If
                If MediaType = "N" Then
                    documentsNewspaper = AdvantageFramework.Database.Procedures.NewspaperDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsNewspaper IsNot Nothing Then
                        Select Case documentsNewspaper.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsNewspaper.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsNewspaper
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If
                If MediaType = "I" Then
                    documentsInternet = AdvantageFramework.Database.Procedures.InternetDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsInternet IsNot Nothing Then
                        Select Case documentsInternet.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsInternet.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsInternet
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If
                If MediaType = "O" Then
                    documentsOutofHome = AdvantageFramework.Database.Procedures.OutOfHomeDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsOutofHome IsNot Nothing Then
                        Select Case documentsOutofHome.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsOutofHome.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsOutofHome
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If
                If MediaType = "R" Then
                    documentsRadio = AdvantageFramework.Database.Procedures.RadioDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsRadio IsNot Nothing Then
                        Select Case documentsRadio.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsRadio.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsRadio
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If
                If MediaType = "T" Then
                    documentsTelevision = AdvantageFramework.Database.Procedures.TVDocument.LoadByOrderID(DbContext, OrderNumber).ToList

                    If documentsTelevision IsNot Nothing Then
                        Select Case documentsTelevision.Count
                            Case 0
                                Me.ShowMessage("No file(s)")
                            Case 1
                                Dim DocumentId As Integer = documentsTelevision.Item(0).DocumentID
                                Me.DeliverFile(DocumentId)
                            Case > 1
                                For Each magazineDoc In documentsTelevision
                                    Dim DocumentId As Integer = magazineDoc.DocumentID
                                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentId)

                                    If Document IsNot Nothing Then

                                        Dim r As DataRow

                                        r = DtRecs.NewRow()

                                        r("DocId") = Document.ID
                                        r("Filename") = Document.FileName
                                        r("RepositoryFilename") = Document.FileSystemFileName
                                        r("UploadedDate") = Document.UploadedDate

                                        DtRecs.Rows.Add(r)

                                    End If

                                Next

                                If Not DtRecs Is Nothing Then

                                    If DtRecs.Rows.Count > 0 Then

                                        Dim rep As New DocumentRepository(_Session.ConnectionString)
                                        rep.GetDocuments(DtRecs, zip)
                                    End If

                                End If

                                zip.Save(Response.OutputStream)

                                With Response

                                    .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                                    .ContentType = "application/zip"
                                    .End()

                                End With

                        End Select
                    End If

                End If

            End Using






        Catch ex As Exception

        End Try
    End Sub
End Class
