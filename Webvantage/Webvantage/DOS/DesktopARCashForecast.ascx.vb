Public Class DesktopARCashForecast
    Inherits Webvantage.BaseDesktopObject

    Private StrClient As String = ""
    Private StrOffice As String = ""
    Private _LoadingDatasource As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            LoadClientDropdownlist()
            LoadOfficeDropdownlist()
            Me.RadGridDesktopARForecast.Rebind()
        End If
        Try
            StrClient = Me.ClientDropDownList.SelectedValue
        Catch ex As Exception
            StrClient = ""
        End Try
        Try
            StrOffice = Me.ddOffice.SelectedValue
        Catch ex As Exception
            StrOffice = ""
        End Try

        If Session("DesktopObjectBookmark") = "acct" Then
            Me.ImageButtonBookmark.Visible = False
            Session("DesktopObjectBookmark") = ""
        End If

        Dim printJS As String = "Javascript:window.open('dtp_arcashforecast.aspx?client=" & StrClient & "&office=" & StrOffice & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
        Me.PrintImageButton.Attributes.Add("onclick", printJS)
        Me.butExport.Attributes.Add("onclick", "window.open('dtp_arcashforecast.aspx?export=1&client=" & StrClient & "&office=" & StrOffice & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
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

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        Me.RadGridDesktopARForecast.Rebind()
    End Sub

    Private Sub ImgBtnRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnRefresh.Click
        Me.RadGridDesktopARForecast.Rebind()
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        Me.RadGridDesktopARForecast.Rebind()
    End Sub

    Private Sub RadGridDesktopARForecast_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDesktopARForecast.NeedDataSource
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim myForecasts As New Webvantage.ARFocasts
        _LoadingDatasource = True
        Me.RadGridDesktopARForecast.Columns(3).HeaderText = Date.Now.ToString("MMMM")
        Me.RadGridDesktopARForecast.Columns(4).HeaderText = Date.Now.AddMonths(1).ToString("MMMM")
        Me.RadGridDesktopARForecast.Columns(5).HeaderText = Date.Now.AddMonths(2).ToString("MMMM")
        Me.RadGridDesktopARForecast.Columns(6).HeaderText = Date.Now.AddMonths(3).ToString("MMMM")
        Try
            StrClient = Me.ClientDropDownList.SelectedValue
        Catch ex As Exception
            StrClient = ""
        End Try
        Try
            StrOffice = Me.ddOffice.SelectedValue
        Catch ex As Exception
            StrOffice = ""
        End Try
        myForecasts = oDO.GetARForecast(CStr(Session("UserCode")), StrClient, StrOffice)
        Me.RadGridDesktopARForecast.DataSource = myForecasts
        Me.RadGridDesktopARForecast.CurrentPageIndex = Me.CurrentGridPageIndex
        Me.RadGridDesktopARForecast.PageSize = MiscFN.LoadPageSize(Me.RadGridDesktopARForecast.ID)
        _LoadingDatasource = False
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridDesktopARForecast_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridDesktopARForecast.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridDesktopARForecast.Rebind()

    End Sub

    Private Sub RadGridDesktopARForecast_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridDesktopARForecast.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridDesktopARForecast.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_ARCashForecast
                .UserCode = Session("UserCode")
                .Name = "AR Cash Forecast (All)"
                .Description = "AR Cash Forecast (All)"
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
