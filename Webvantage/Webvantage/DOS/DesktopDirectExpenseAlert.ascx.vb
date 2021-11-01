Imports System.Data.SqlClient
Imports Webvantage.MiscFN

Partial Public Class DesktopDirectExpenseAlert
    Inherits Webvantage.BaseDesktopObject
    Dim agy_setting As Int16

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts, False))

        Try

            DirectExpRadGrid.Columns.FindByUniqueName("GridTemplateColumnDocuments").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.RadGrid1.Skin = MiscFN.SetRadGridSkin()
        If Not Page.IsPostBack Then
            'Check Agency Maintenance Setting
            agy_setting = getAgencySetting()
            If agy_setting <> 1 Then
                'Do not display data
                Me.DivObject.Visible = False
                Exit Sub
            Else
                LoadDropDowns()
                GetCurrentPP()
                LoadGrid(True)
            End If

            If Session("DesktopObjectBookmark") = "acct" Then
                Me.ImageButtonBookmark.Visible = False
                Session("DesktopObjectBookmark") = ""
            End If

        End If
    End Sub

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDesktop As New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDesktop.GetAgencySetting("DIRECT_EXPENSE_ON")
        Return AgySetting
    End Function

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddPPBegin
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddPPEnd
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With
        Session("OFFICE_DEA") = ""

    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        currentPeriod = oDO.getEndPeriod()
        'firstPeriod = oDO.getStartPeriod()

        Me.ddPPBegin.SelectedValue = currentPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_DEA") = currentPeriod
        Session("PPEND_DEA") = currentPeriod

    End Function

    Private Sub LoadGrid(ByVal ab_bind As Boolean)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String
        Dim amount As String
        Dim amount_dec As Decimal

        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CAST(AGY_SETTINGS_VALUE AS DECIMAL(15,2)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DIRECT_EXP_ALERT_AMT'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_directExpenseAlert Routine:LoadGrid", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            If IsDBNull(dr.GetDecimal(0)) Then
                Me.ShowMessage("Please set direct expense alert amount")
                Exit Sub
            Else
                amount_dec = dr.GetDecimal(0)
            End If

        End If

        startPP = Me.ddPPBegin.SelectedValue
        If startPP Is Nothing Or startPP = "" Then
            GetCurrentPP()
            startPP = Me.ddPPBegin.SelectedValue
        End If
        endPP = Me.ddPPEnd.SelectedValue
        Office = Me.ddOffice.SelectedValue

        If startPP > endPP Then
            Me.ShowMessage("Please enter valid Periods.")
            Me.ddPPBegin.SelectedValue = CStr(Session("PPBEGIN_DEA"))
            Me.ddPPEnd.SelectedValue = CStr(Session("PPEND_DEA"))
            Exit Sub
        End If

        Session("PPBEGIN_DEA") = startPP
        Session("PPEND_DEA") = endPP
        Session("Amount") = CStr(amount_dec)
        amount = CStr(Session("Amount"))

        If Office = "All" Then
            Office = ""
        End If

        Session("OFFICE_DEA") = Office

        'Me.RadGrid1.DataSource = oDO.GetDirectExpense(startPP, endPP, Office, amount, Session("UserCode"), "")
        Me.DirectExpRadGrid.DataSource = oDO.GetDirectExpense(startPP, endPP, Office, amount, Session("UserCode"), "")
        If ab_bind Then
            Me.DirectExpRadGrid.DataBind()
        End If

    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim image As String

        image = butRefresh.ImageUrl
        If image <> "~/Images/lock16.png" Then
            LoadGrid(True)
        End If
    End Sub

    Private Sub DirectExpRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles DirectExpRadGrid.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim DivViewIcon As HtmlControls.HtmlControl = CType(e.Item.FindControl("DivViewIcon"), HtmlControls.HtmlControl)
            DivViewIcon.Attributes.Add("onclick", "window.open('DirectExpenseAlert_Detail.aspx?Inv=" & e.Item.DataItem("AP_INV_VCHR") & "&Code=" & e.Item.DataItem("VN_FRL_EMP_CODE") & "&Name=" & e.Item.DataItem("VN_NAME") & " ', 'PopLookup','screenX=50,left=50,screenY=150,top=150,width=1200,height=400,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")

            Dim DocumentsLinkButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonDocuments"), ImageButton)
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

            If Not DocumentsLinkButton Is Nothing Then

                Dim qs As New AdvantageFramework.Web.QueryString()
                With qs

                    .Page = "Documents_List2.aspx"
                    .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice
                    .APID = CurrentGridRow.GetDataKeyValue("AP_ID")
                    .APInvoice = CurrentGridRow.GetDataKeyValue("AP_INV_VCHR")
                    .VendorCode = CurrentGridRow.GetDataKeyValue("VN_FRL_EMP_CODE")

                End With

                With DocumentsLinkButton

                    .Attributes.Remove("onclick")
                    .Attributes.Add("onclick", Me.HookUpOpenWindow("Invoice Documents", qs.ToString(True)))

                End With

            End If

        End If
    End Sub

    Private Sub DirectExpRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles DirectExpRadGrid.NeedDataSource
        LoadGrid(False)
    End Sub

    Private Sub DirectExpRadGrid_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles DirectExpRadGrid.SortCommand
        LoadGrid(True)
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged
        LoadGrid(True)
    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        LoadGrid(True)
    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        LoadGrid(True)
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_DirectExpenseAlert
                .UserCode = Session("UserCode")
                .Name = "Direct Expense Alert (All)"
                .Description = "Direct Expense Alert (All)"
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
