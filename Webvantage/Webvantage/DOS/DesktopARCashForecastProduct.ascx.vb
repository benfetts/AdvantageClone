Partial Public Class DesktopARCashForecastProduct
    Inherits Webvantage.BaseDesktopObject

    Private StrClient As String = ""
    Private StrOffice As String = ""
    Private strDivision As String
    Private strProduct As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack = True And Not Me.Page.IsCallback = True Then
            LoadClientDropdownlist()
            LoadOfficeDropdownlist()
            LoadDivisionDropdownlist()
            LoadProductDropdownlist()
            LoadAR()
        End If
        StrClient = Me.ClientDropDownList.SelectedValue
        StrOffice = Me.ddOffice.SelectedValue
        strDivision = Me.DivisionDropDownList.SelectedValue
        strProduct = Me.ProductDropDownList.SelectedValue
        Dim printJS As String = "Javascript:window.open('dtp_arcashforecastproduct.aspx?my=0&client=" & StrClient & "&office=" & StrOffice & "&division=" & strDivision & "&product=" & strProduct & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
        Me.PrintImageButton.Attributes.Add("onclick", printJS)
        Me.butExport.Attributes.Add("onclick", "window.open('dtp_arcashforecastproduct.aspx?export=1&client=" & StrClient & "&office=" & StrOffice & "&division=" & strDivision & "&product=" & strProduct & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
    End Sub

    Private Sub LoadClientDropdownlist()
        Me.ClientDropDownList.Items.Clear()
        Dim cli As String
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.ClientDropDownList.DataSource = oDD.GetClientList(Session("UserCode"))
        Me.ClientDropDownList.DataTextField = "Description"
        Me.ClientDropDownList.DataValueField = "Code"
        Me.ClientDropDownList.DataBind()
        Me.ClientDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", "%"))
    End Sub

    Private Sub LoadOfficeDropdownlist()
        Me.ddOffice.Items.Clear()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", ""))
        End With

    End Sub

    Private Sub LoadDivisionDropdownlist()
        Try
            Dim cli As String

            Me.DivisionDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.DivisionDropDownList
                .DataSource = oDD.GetDivisionList(Session("UserCode"), cli)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "%"))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "ClientAging", "CADivision")
            If taskVar <> "" Then
                Me.DivisionDropDownList.SelectedValue = taskVar
            Else
                Me.DivisionDropDownList.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadProductDropdownlist()
        Try
            Dim cli, div As String

            Me.ProductDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            div = Me.DivisionDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.ProductDropDownList
                .DataSource = oDD.GetProductList(Session("UserCode"), cli, div)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "%"))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "ClientAging", "CAProduct")
            If taskVar <> "" Then
                MiscFN.RadComboBoxSetIndex(Me.ProductDropDownList, taskVar, False)
            Else
                Me.ProductDropDownList.SelectedIndex = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadAR()
        StrClient = Me.ClientDropDownList.SelectedValue
        StrOffice = Me.ddOffice.SelectedValue
        strDivision = Me.DivisionDropDownList.SelectedValue
        strProduct = Me.ProductDropDownList.SelectedValue
        Me.ARForcastRG.Rebind()
    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        LoadDivisionDropdownlist()
        LoadProductDropdownlist()
        LoadAR()
    End Sub

    Private Sub ImgBtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRefresh.Click
        Me.LoadAR()
    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        Me.LoadAR()
    End Sub

    Private Sub DivisionDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DivisionDropDownList.SelectedIndexChanged
        LoadProductDropdownlist()
        Me.LoadAR()
    End Sub

    Private Sub ProductDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductDropDownList.SelectedIndexChanged
        Me.LoadAR()
    End Sub


    Private Sub ARForcastRG_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles ARForcastRG.NeedDataSource
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim myForecasts As New Webvantage.ARFocasts
        Me.ARForcastRG.Columns(5).HeaderText = Date.Now.ToString("MMMM")
        Me.ARForcastRG.Columns(6).HeaderText = Date.Now.AddMonths(1).ToString("MMMM")
        Me.ARForcastRG.Columns(7).HeaderText = Date.Now.AddMonths(2).ToString("MMMM")
        Me.ARForcastRG.Columns(8).HeaderText = Date.Now.AddMonths(3).ToString("MMMM")
        myForecasts = oDO.GetARForecastProduct(CStr(Session("UserCode")), StrClient, StrOffice, strDivision, strProduct)
        Me.ARForcastRG.DataSource = myForecasts
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_ARCashForecastProduct
                .UserCode = Session("UserCode")
                .Name = "AR Cash Forecast (Product)"
                .Description = "AR Cash Forecast (Product)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
