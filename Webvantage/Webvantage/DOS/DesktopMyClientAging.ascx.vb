Imports cCharting
Imports InfoSoftGlobal
Imports Telerik.Charting
Imports System.Drawing

Public Class DesktopMyClientAging
    Inherits Webvantage.BaseDesktopObject

    Public strClient As String = ""
    Public strOffice As String = ""
    Public strDivision As String = ""
    Public strProduct As String = ""

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If Page.IsPostBack = False Then
                LoadClientDropdownlist()
                LoadDivisionDropdownlist()
                LoadProductDropdownlist()
                LoadOfficeDropdownlist()
                LoadInvoiceCategory()
                LoadSelections()
            End If
            strClient = Me.ClientDropDownList.SelectedValue
            strOffice = Me.ddOffice.SelectedValue
            strDivision = Me.DivisionDropDownList.SelectedValue
            strProduct = Me.ProductDropDownList.SelectedValue
            Dim cats As String = ""
            For i As Integer = 0 To Me.lbInvoiceCat.Items.Count - 1
                If Me.lbInvoiceCat.Items(i).Selected = True Then
                    cats &= Me.lbInvoiceCat.Items(i).Value & ","
                End If
            Next
            If cats <> "" Then
                cats = MiscFN.RemoveTrailingDelimiter(cats, ",")
            End If
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_clientaging.aspx?my=1&export=1&client=" & strClient & "&office=" & strOffice & "&division=" & strDivision & "&product=" & strProduct & "&from=mca&cat=" & cats & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
            Me.butPrint.Attributes.Add("onclick", "window.open('dtp_clientaging.aspx?my=1&client=" & strClient & "&office=" & strOffice & "&division=" & strDivision & "&product=" & strProduct & "&from=mca&cat=" & cats & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=700,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")

            LoadGraph()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadClientDropdownlist()
        Try
            Me.ClientDropDownList.Items.Clear()

            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.ClientDropDownList
                .DataSource = oDD.GetClientListAE(Session("UserCode"), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyClientAging)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", ""))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAClient")
            If taskVar <> "" Then
                Me.ClientDropDownList.SelectedValue = taskVar
            Else
                Me.ClientDropDownList.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub LoadDivisionDropdownlist()
        Try
            Dim cli As String

            Me.DivisionDropDownList.Items.Clear()

            cli = Me.ClientDropDownList.SelectedValue
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

            With Me.DivisionDropDownList
                .DataSource = oDD.GetDivisionListAE(Session("UserCode"), cli, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyClientAging)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", ""))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CADivision")
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
                .DataSource = oDD.GetProductListAE(Session("UserCode"), cli, div, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyClientAging)
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", ""))
                .SelectedIndex = 0
            End With

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAProduct")
            If taskVar <> "" Then
                Me.ProductDropDownList.SelectedValue = taskVar
            Else
                Me.ProductDropDownList.SelectedValue = ""
            End If

        Catch ex As Exception

        End Try
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

    Private Sub LoadInvoiceCategory()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("Connstring"))
        Me.lbInvoiceCat.DataSource = oDropDowns.GetInvoiceCategories
        Me.lbInvoiceCat.DataTextField = "Description"
        Me.lbInvoiceCat.DataValueField = "Code"
        Me.lbInvoiceCat.DataBind()
        Me.lbInvoiceCat.SelectionMode = ListSelectionMode.Multiple
    End Sub

    Dim DtGraphData As New DataTable
    Private Sub LoadGraph()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim cats As String = ""
        For i As Integer = 0 To Me.lbInvoiceCat.Items.Count - 1
            If Me.lbInvoiceCat.Items(i).Selected = True Then
                cats &= Me.lbInvoiceCat.Items(i).Value & ","
            End If
        Next
        If cats <> "" Then
            cats = MiscFN.RemoveTrailingDelimiter(cats, ",")
        End If
        DtGraphData = oDO.GetInvoiceARBalanceGraph(CStr(Session("UserCode")), strClient, strOffice, strDivision, strProduct, True, cats)
        oDO = Nothing

        CreateChart()

    End Sub

    Private Sub CreateChart()

        'objects
        Dim cats As String = ""

        For Each RadListBoxItem In Me.lbInvoiceCat.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

            If RadListBoxItem.Selected = True Then

                cats &= RadListBoxItem.Value & ","

            End If

        Next

        If cats <> "" Then

            cats = MiscFN.RemoveTrailingDelimiter(cats, ",")

        End If

        cCharting.GetChart_ClientAging(RadHtmlChartClientAging, DtGraphData, "", False, strClient, strOffice, strDivision, strProduct, True, cats)

    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "MyClientAging", "CAClient", "", Me.ClientDropDownList.SelectedValue)
        LoadDivisionDropdownlist()
        LoadProductDropdownlist()
        otask.setAppVars(Session("UserCode"), "MyClientAging", "CADivision", "", Me.DivisionDropDownList.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyClientAging", "CAProduct", "", Me.ProductDropDownList.SelectedValue)
        LoadGraph()
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "MyClientAging", "CAOffice", "", Me.ddOffice.SelectedValue)
        LoadGraph()
    End Sub

    Private Sub butrefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butrefresh.Click
        Try
            Me.lblMsg.Text = ""
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            If IsNumeric(Me.txtGroup1.Text) = False Then
                Me.lblMsg.Text = "Invalid Group 1"
                Exit Sub
            End If
            If IsNumeric(Me.txtGroup2.Text) = False Then
                Me.lblMsg.Text = "Invalid Group 2"
                Exit Sub
            End If
            If IsNumeric(Me.txtGroup3.Text) = False Then
                Me.lblMsg.Text = "Invalid Group 3"
                Exit Sub
            End If
            If IsNumeric(Me.txtGroup4.Text) = False Then
                Me.lblMsg.Text = "Invalid Group 4"
                Exit Sub
            End If

            If Me.txtGroup1.Text <> "" Then
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup1", "", Me.txtGroup1.Text)
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup1", "", "30")
            End If
            If Me.txtGroup2.Text <> "" Then
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup2", "", Me.txtGroup2.Text)
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup2", "", "60")
            End If
            If Me.txtGroup3.Text <> "" Then
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup3", "", Me.txtGroup3.Text)
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup3", "", "90")
            End If
            If Me.txtGroup4.Text <> "" Then
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup4", "", Me.txtGroup4.Text)
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup4", "", "120")
            End If

            otask.setAppVars(Session("UserCode"), "MyClientAging", "CAIncludeOver", "", Me.cbIncludeOver.Checked)



            LoadSelections()
            LoadGraph()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadSelections()
        Try

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAOffice")
            If taskVar <> "" Then
                Me.ddOffice.SelectedValue = taskVar
            Else
                Me.ddOffice.SelectedValue = ""
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAGroup1")
            If taskVar <> "" Then
                Me.txtGroup1.Text = taskVar
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup1", "", "30")
                Me.txtGroup1.Text = "30"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAGroup2")
            If taskVar <> "" Then
                Me.txtGroup2.Text = taskVar
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup2", "", "60")
                Me.txtGroup2.Text = "60"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAGroup3")
            If taskVar <> "" Then
                Me.txtGroup3.Text = taskVar
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup3", "", "90")
                Me.txtGroup3.Text = "90"
            End If

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAGroup4")
            If taskVar <> "" Then
                Me.txtGroup4.Text = taskVar
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAGroup4", "", "120")
                Me.txtGroup4.Text = "120"
            End If
            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAIncludeOver")
            If taskVar <> "" Then
                Me.cbIncludeOver.Checked = otask.getAppVars(Session("UserCode"), "MyClientAging", "CAIncludeOver")
            Else
                otask.setAppVars(Session("UserCode"), "MyClientAging", "CAIncludeOver", "", Me.cbIncludeOver.Checked)
                Me.cbIncludeOver.Checked = False
            End If
            Me.cbIncludeOver.Text = "Include Over " & Me.txtGroup4.Text & " Only"

            taskVar = otask.getAppVars(Session("UserCode"), "MyClientAging", "InvoiceCat")
            If taskVar <> "" Then
                Dim cats() As String = taskVar.Split(",")
                For i As Integer = 0 To Me.lbInvoiceCat.Items.Count - 1
                    For j As Integer = 0 To cats.Length - 1
                        If Me.lbInvoiceCat.Items(i).Value = cats(j) Then
                            Me.lbInvoiceCat.Items(i).Selected = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DivisionDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DivisionDropDownList.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "MyClientAging", "CADivision", "", Me.DivisionDropDownList.SelectedValue)
        LoadProductDropdownlist()
        otask.setAppVars(Session("UserCode"), "MyClientAging", "CAProduct", "", Me.ProductDropDownList.SelectedValue)
        LoadGraph()
    End Sub

    Private Sub ProductDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductDropDownList.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "MyClientAging", "CAProduct", "", Me.ProductDropDownList.SelectedValue)
        LoadGraph()
    End Sub

    Private Sub lbInvoiceCat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbInvoiceCat.SelectedIndexChanged
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim cats As String
            For i As Integer = 0 To Me.lbInvoiceCat.Items.Count - 1
                If Me.lbInvoiceCat.Items(i).Selected = True Then
                    cats &= Me.lbInvoiceCat.Items(i).Value & ","
                End If
            Next
            If cats <> "" Then
                cats = MiscFN.RemoveTrailingDelimiter(cats, ",")
            End If
            otask.setAppVars(Session("UserCode"), "MyClientAging", "InvoiceCat", "", cats)
            LoadGraph()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_MyClientAging
                .UserCode = Session("UserCode")
                .Name = "Client Aging (My)"
                .Description = "Client Aging (My)"
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
