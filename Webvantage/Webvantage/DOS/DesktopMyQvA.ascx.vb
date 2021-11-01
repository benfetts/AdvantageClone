Partial Public Class DesktopMyQvA
    Inherits Webvantage.BaseDesktopObject

    Public strTimeOnly As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim printJS As String
        Dim taskVar As String

        strTimeOnly = Me.ddType.SelectedValue

        If Not Me.IsPostBack Then
            Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
            oAppVars.getAllAppVars()
            'Session("QvACli") = "ALL"
            'Session("QvADiv") = "ALL"
            'Session("QvAPrd") = "ALL"
            oAppVars.setAppVar("QvACli", "ALL")
            oAppVars.setAppVar("QvADiv", "ALL")
            oAppVars.setAppVar("QvAPrd", "ALL")
            oAppVars.SaveAllAppVars()
            taskVar = oAppVars.getAppVar("QvAType", "Boolean")
            If taskVar <> "" Then
                Me.ddType.SelectedValue = taskVar
            End If
            Double.TryParse(oAppVars.getAppVar("QvAThreshold", "", "100"), Me.RadNumericTextBoxThreshold.Value)
            Me.txtSearch.Text = oAppVars.getAppVar("QvASearch")

            Try
                taskVar = oAppVars.getAppVar("QvAExcludeCA")
                If taskVar <> "" Then
                    Me.cbExcludeClientApproval.Checked = taskVar
                End If
                taskVar = oAppVars.getAppVar("QvAExcludeIA")
                If taskVar <> "" Then
                    Me.cbExcludeInternalApproval.Checked = taskVar
                End If
                taskVar = oAppVars.getAppVar("QvAAllProcessing")
                If taskVar <> "" Then
                    Me.cbAllProcessing.Checked = taskVar
                End If
            Catch ex As Exception

            End Try

            printJS = "Javascript:window.open('dtp_qva.aspx?threshold=" & Me.RadNumericTextBoxThreshold.Value.GetValueOrDefault(100) & "&timeonly=" & Me.ddType.SelectedValue & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1050,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
            Me.butPrint.Attributes.Add("onclick", printJS)
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_qva.aspx?threshold=" & Me.RadNumericTextBoxThreshold.Value.GetValueOrDefault(100) & "&timeonly=" & Me.ddType.SelectedValue & "&export=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")

            LoadClientDropdownlist()

            LoadGrid()
            'Defect #143
            'Me.QVARadGrid.Skin = Webvantage.MiscFN.SetRadGridSkin

            'With txtThreshold.Attributes
            '    .Add("onkeyup", "javascript:IsInteger('this.value');")
            '    .Add("onblur", "javascript:IsInteger('this.value');")
            'End With
            If Me.RadNumericTextBoxThreshold.Value > 100 Then

                Me.RadNumericTextBoxThreshold.Value = 100

            ElseIf Me.RadNumericTextBoxThreshold.Value < 0 Then

                Me.RadNumericTextBoxThreshold.Value = 0

            End If

        End If

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridQVA)


    End Sub

    Private Sub LoadClientDropdownlist()

        Me.ClientDropDownList.Items.Clear()
        Dim cli As String
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.ClientDropDownList.DataSource = oDD.GetClientListAE(Session("UserCode"), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA)

        Me.ClientDropDownList.DataTextField = "Description"
        Me.ClientDropDownList.DataValueField = "Code"
        Me.ClientDropDownList.DataBind()
        Me.ClientDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", "ALL"))
        Me.DivisionDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "ALL"))
        Me.ProductDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "ALL"))

        'Dim Security As New SEC_CLIENT(Session("ConnString"))
        'Security.Where.USER_ID.Value = Session("UserCode")
        'Dim clients As New CLIENT(Session("ConnString"))

        'If Security.Query.Load Then
        '    cli = ""
        '    Do Until Security.EOF
        '        If cli <> Security.CL_CODE Then

        '            clients = New CLIENT(Session("ConnString"))
        '            clients.Where.CL_CODE.Value = Security.CL_CODE
        '            clients.Where.ACTIVE_FLAG.Value = 1
        '            cli = Security.CL_CODE
        '            clients.Query.Load()
        '            Do Until clients.EOF
        '                Me.ClientDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(clients.CL_CODE & " - " & clients.CL_NAME, clients.CL_CODE))

        '                clients.MoveNext()
        '            Loop
        '        End If

        '        Security.MoveNext()
        '    Loop

        'Else
        '    clients.Where.ACTIVE_FLAG.Value = 1
        '    clients.Query.Load()
        '    Do Until clients.EOF
        '        Me.ClientDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(clients.CL_CODE & " - " & clients.CL_NAME, clients.CL_CODE))

        '        clients.MoveNext()
        '    Loop
        'End If
    End Sub
    Private Sub LoadDivisionDDL()
        Dim cli As String

        Me.DivisionDropDownList.Items.Clear()

        cli = Me.ClientDropDownList.SelectedValue
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.DivisionDropDownList
            .DataSource = oDD.GetDivisionListAE(Session("UserCode"), cli, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA)
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", "ALL"))
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub LoadProductDDL()
        Dim cli, div As String

        Me.ProductDropDownList.Items.Clear()

        cli = Me.ClientDropDownList.SelectedValue
        div = Me.DivisionDropDownList.SelectedValue
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ProductDropDownList
            .DataSource = oDD.GetProductListAE(Session("UserCode"), cli, div, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA)
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", "ALL"))
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub LoadGrid()
        Try
            'Me.QVARadGrid.Rebind()
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim client, division, product As String
            Dim group As String = ""
            Dim grouptype As String = ""

            client = Me.ClientDropDownList.SelectedValue
            division = Me.DivisionDropDownList.SelectedValue
            product = Me.ProductDropDownList.SelectedValue

            If client.ToUpper = "ALL" Then client = ""
            If division.ToUpper = "ALL" Then division = ""
            If product.ToUpper = "ALL" Then product = ""

            Me.RadGridQVA.DataSource = oDO.GetQVA(CStr(Session("EmpCode")), client, division, product, Me.ddType.SelectedValue, Session("UserCode"), Me.txtSearch.Text, "My", "", "", "", "", "", "", group, grouptype)

            Me.RadGridQVA.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetColor(ByRef Div As HtmlControls.HtmlControl, ByVal Quoted As Decimal, ByVal Actual As Decimal)

        Dim dThresh As Double = 0

        If Me.RadNumericTextBoxThreshold.Value.HasValue Then

            dThresh = Me.RadNumericTextBoxThreshold.Value

        End If

        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Div, dThresh, Quoted, Actual)

    End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Me.LblMSG.Text = ""

        If Me.RadNumericTextBoxThreshold.Value.HasValue = False Then

            Me.LblMSG.Text = "Invalid threshold"

        Else

            Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
            oAppVars.setAppVarDB("QvAThreshold", Me.RadNumericTextBoxThreshold.Value.ToString())
            oAppVars.setAppVarDB("QvASearch", Me.txtSearch.Text)
            LoadGrid()
        End If
    End Sub

    Private Sub ClientDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ClientDropDownList.SelectedIndexChanged
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)

        If Me.ClientDropDownList.SelectedValue.ToUpper = "ALL" Then
            Me.DivisionDropDownList.SelectedIndex = 0
            Me.ProductDropDownList.SelectedIndex = 0
            Me.DivisionDropDownList.Enabled = False
            Me.ProductDropDownList.Enabled = False
        Else
            Me.DivisionDropDownList.Enabled = True
            LoadDivisionDDL()
            Me.ProductDropDownList.Enabled = False
            Me.LoadProductDDL()
        End If

        'Session("QvACli") = Me.ClientDropDownList.SelectedValue
        'Session("QvADiv") = "ALL"
        'Session("QvAPrd") = "ALL"
        oAppVars.setAppVarDB("QvACli", Me.ClientDropDownList.SelectedValue)
        oAppVars.setAppVarDB("QvADiv", "ALL")
        oAppVars.setAppVarDB("QvAPrd", "ALL")
        LoadGrid()
    End Sub
    Private Sub DivisionDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DivisionDropDownList.SelectedIndexChanged
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)

        If Me.DivisionDropDownList.SelectedValue.ToUpper = "ALL" Then
            Me.ProductDropDownList.SelectedIndex = 0
            Me.ProductDropDownList.Enabled = False
        Else
            Me.ProductDropDownList.Enabled = True
            LoadProductDDL()
        End If

        'Session("QvADiv") = Me.DivisionDropDownList.SelectedValue
        'Session("QvAPrd") = "ALL"
        oAppVars.setAppVarDB("QvADiv", Me.DivisionDropDownList.SelectedValue)
        oAppVars.setAppVarDB("QvAPrd", "ALL")
        LoadGrid()
    End Sub
    Private Sub ProductDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProductDropDownList.SelectedIndexChanged
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)

        'Session("QvAPrd") = Me.ProductDropDownList.SelectedValue
        oAppVars.setAppVarDB("QvAPrd", Me.ProductDropDownList.SelectedValue)
        LoadGrid()
    End Sub

    Private Sub ddType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddType.SelectedIndexChanged
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
        oAppVars.setAppVarDB("QvAType", Me.ddType.SelectedValue, "Boolean")
        LoadGrid()
    End Sub
    Private Sub imgbtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSearch.Click
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
        oAppVars.setAppVarDB("QvASearch", Me.txtSearch.Text)
        Me.RadGridQVA.MasterTableView.CurrentPageIndex = 0
        LoadGrid()
    End Sub

    Private Sub cbExcludeClientApproval_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbExcludeClientApproval.CheckedChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
            oAppVars.setAppVarDB("QvAExcludeCA", Me.cbExcludeClientApproval.Checked)
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbExcludeInternalApproval_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbExcludeInternalApproval.CheckedChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
            oAppVars.setAppVarDB("QvAExcludeIA", Me.cbExcludeInternalApproval.Checked)
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbAllProcessing_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAllProcessing.CheckedChanged
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
            oAppVars.setAppVarDB("QvAAllProcessing", Me.cbAllProcessing.Checked)
            LoadGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQVA_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridQVA.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim ar() As String
        Dim commandParm As String

        Select Case e.CommandName
            Case "Detail"

            Case "ViewJob"

        End Select
    End Sub
    Private Sub RadGridQVA_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQVA.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                GetColor(FlagColorDiv, e.Item.DataItem("Quoted"), e.Item.DataItem("Actual"))

                Dim ViewImage As WebControls.ImageButton = e.Item.Cells(0).FindControl("ImageButtonViewDetails")
                ViewImage.Attributes.Add("onclick", "OpenRadWindow('QvA for Job/Comp:  " & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value.ToString().PadLeft(6, "0") & "/" & CType(e.Item.FindControl("HfJobCompNumber"), HiddenField).Value.ToString().PadLeft(2, "0") & "', 'QuoteVsActualSummaryPopup.aspx?JobNo=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value & "&JobComp=" & CType(e.Item.FindControl("HfJobCompNumber"), HiddenField).Value & "',0,0);return false;")

                Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.Cells(2).FindControl("ViewLinkButton")
                ViewLinkButton.Text = e.Item.DataItem("JobAndComp")
                ViewLinkButton.Attributes.Add("onclick", "OpenRadWindow('','Content.aspx?PageMode=Edit&JobNum=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value & "&JobCompNum=" & CType(e.Item.FindControl("HfJobCompNumber"), HiddenField).Value & "&NewComp=0',0,0)")

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridQVA_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQVA.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim client, division, product As String

            client = Me.ClientDropDownList.SelectedValue
            division = Me.DivisionDropDownList.SelectedValue
            product = Me.ProductDropDownList.SelectedValue

            If client.ToUpper = "ALL" Then client = ""
            If division.ToUpper = "ALL" Then division = ""
            If product.ToUpper = "ALL" Then product = ""

            Me.RadGridQVA.DataSource = oDO.GetQVA(CStr(Session("EmpCode")), client, division, product, Me.ddType.SelectedValue, Session("UserCode"), Me.txtSearch.Text, "My", "", "", "", "", "", "", "", "")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQVA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridQVA.PreRender
        Session("QVADOSortExp") = Me.RadGridQVA.MasterTableView.SortExpressions.GetSortString
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_MyQVA
                .UserCode = Session("UserCode")
                .Name = "QvA (My)"
                .Description = "QvA (My)"
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
