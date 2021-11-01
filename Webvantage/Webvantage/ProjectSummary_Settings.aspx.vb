Imports Webvantage.cGlobals.Globals
Imports System.Drawing

Partial Public Class ProjectSummary_Settings
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Summary Report"
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_ProjectSummaryRTP)
        lbl_msg.Text = ""
        Dim oReports As New cReports(Session("ConnString"))
        If Page.IsPostBack = False Then
            'If Not Request.QueryString("nodata") Is Nothing Then
            '    lbl_msg.Text = "No Data Found For Selected Inputs"
            'End If
            InitSelection()
            LoadOfficeList()
            LoadTrafficStatus()
            LoadManagers()
            LoadAEListbox()
            LoadSalesClass()
            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.lblManager.Text = str & ":"
            End If
            Me.pnlClient.Visible = False
            Me.pnlDivision.Visible = False
            Me.pnlProduct.Visible = False
            Me.lstClient.ClearSelection()
            Me.lstDivision.ClearSelection()
            Me.lstProduct.ClearSelection()
            'If Not Request.Cookies("sumrepbyclient") Is Nothing Then
            LoadSettings()
            'End If
            If Me.IsClientPortal = True Then
                Me.optCDP.Items.RemoveAt(1)
                Me.PanelOffice.Visible = False
            End If
        Else

        End If
    End Sub
    Private Sub LoadOfficeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.lbOffices.DataSource = oDropDowns.GetOfficesEmp(Session("UserCode"))
        Me.lbOffices.DataTextField = "Description"
        Me.lbOffices.DataValueField = "Code"
        Me.lbOffices.DataBind()
        Me.lbOffices.SelectionMode = ListSelectionMode.Multiple
        Me.lbOffices.Enabled = False
        'Me.lbOffices.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))

    End Sub
    Private Sub LoadTrafficStatus()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("Connstring"))
        Me.lbStatus.DataSource = oDropDowns.GetTrafficCodes()
        Me.lbStatus.DataTextField = "Description"
        Me.lbStatus.DataValueField = "Code"
        Me.lbStatus.DataBind()
        Me.lbStatus.SelectionMode = ListSelectionMode.Multiple
        Me.lbStatus.Enabled = False
    End Sub
    Private Sub LoadManagers()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.ddManager
            .DataSource = odd.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

    End Sub
    Private Sub LoadAEListbox()
        Dim ocPV As cProjectViewpoint = New cProjectViewpoint(CStr(Session("ConnString")))

        Me.lstAEs.ClearSelection()
        With Me.lstAEs
            .DataSource = ocPV.GetAEList("", "", "", CStr(Session("UserCode")))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Enabled = False
        End With
    End Sub
    Private Sub LoadSalesClass()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.lstSalesClass.ClearSelection()
        With Me.lstSalesClass
            .DataSource = odd.GetSalesClass()
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Enabled = False
        End With

    End Sub

    Private Sub InitSelection()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))


        Me.optCDP.Items(0).Selected = True
        Me.pnlClient.Visible = False
        Me.pnlDivision.Visible = False
        Me.pnlProduct.Visible = False
        Me.RadDatePickerStartDate.Enabled = False
        Me.RadDatePickerEndDate.Enabled = False

        Me.lstClient.DataSource = oDD.GetClientList(Session("UserCode"))
        Me.lstClient.DataTextField = "Description"
        Me.lstClient.DataValueField = "Code"
        Me.lstClient.DataBind()

        If Me.IsClientPortal = True Then
            Me.lstDivision.DataSource = oDD.GetDivisionsAllCP(Session("UserID"))
            Me.lstProduct.DataSource = oDD.GetProductsAllCP(Session("UserID"))
        Else
            Me.lstDivision.DataSource = oDD.GetDivisionsAll(Session("UserCode"))
            Me.lstProduct.DataSource = oDD.GetProductsAll(Session("UserCode"))
        End If
        Me.lstDivision.DataTextField = "Description"
        Me.lstDivision.DataValueField = "Code"
        Me.lstDivision.DataBind()

        Me.lstProduct.DataTextField = "Description"
        Me.lstProduct.DataValueField = "Code"
        Me.lstProduct.DataBind()

    End Sub
    Private Function MakeSql() As String
        Dim ds As DataSet
        Dim strWhereStatus As String = ""
        Dim strWhereClient As String
        Dim strWhereDivision As String
        Dim strWhereProduct As String
        Dim strWhereManager As String
        Dim strWhereSalesClass As String = ""
        Dim strsplit As String() = Nothing
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim strWhereOffice As String = ""
        Dim FirstPass As Boolean
        Dim SumRepSql As String = ""


        'SumRepSql = "SELECT PROD_CAT_CODE as Code, PROD_CAT_CODE + ' - ' + PROD_CAT_DESC as Description FROM PRODUCT_CATEGORY"

        Select Case Me.optCDP.SelectedValue
            Case "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstClient.Items
                        If ThisItem.Selected = True Then
                            If FirstPass = True Then
                                strWhereClient &= "'" & ThisItem.Value & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & ThisItem.Value & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                End If
            Case "d"
                If Not Me.lstDivision.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    'this miss-spelling has been in webv since the beginning and never caught by QA
                    'strWhereDivision = "[DIV_CODEe] IN ("
                    strWhereDivision = "[DIV_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstDivision.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                End If

            Case "p"
                If Not Me.lstProduct.SelectedItem Is Nothing Then
                    strWhereClient = "[CL_CODE] IN ("
                    strWhereDivision = "[DIV_CODE] IN ("
                    strWhereProduct = "[PRD_CODE] IN ("
                    FirstPass = True
                    For Each ThisItem In Me.lstProduct.Items
                        If ThisItem.Selected = True Then
                            strsplit = ThisItem.Value.Split(":")
                            If FirstPass = True Then
                                strWhereClient &= "'" & strsplit(0) & "'"
                                strWhereDivision &= "'" & strsplit(1) & "'"
                                strWhereProduct &= "'" & strsplit(2) & "'"
                                FirstPass = False
                            Else
                                strWhereClient &= ",'" & strsplit(0) & "'"
                                strWhereDivision &= ",'" & strsplit(1) & "'"
                                strWhereProduct &= ",'" & strsplit(2) & "'"
                            End If
                        End If
                    Next
                    strWhereClient &= ")"
                    strWhereDivision &= ")"
                    strWhereProduct &= ")"
                End If
            Case Else
                If Me.IsClientPortal = True Then
                    strWhereClient = "[CL_CODE] IN ('" & Session("CL_CODE") & "')"
                End If
        End Select
        FirstPass = True
        For Each ThisItem In Me.lbStatus.Items
            If ThisItem.Selected = True Then
                If FirstPass = True Then
                    strWhereStatus &= "'" & ThisItem.Value & "'"
                    FirstPass = False
                Else
                    strWhereStatus &= ",'" & ThisItem.Value & "'"
                End If
            End If
        Next
        If strWhereStatus.Trim <> "" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql = " AND [TRF_CODE] IN(" & strWhereStatus & ")"
            Else
                SumRepSql = "[TRF_CODE] IN(" & strWhereStatus & ")"
            End If
        End If
        FirstPass = True
        For Each ThisItem In Me.lbOffices.Items
            If ThisItem.Selected = True Then
                If FirstPass = True Then
                    strWhereOffice &= "'" & ThisItem.Value & "'"
                    FirstPass = False
                Else
                    strWhereOffice &= ",'" & ThisItem.Value & "'"
                End If
            End If
        Next
        If strWhereOffice.Trim <> "" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql &= " AND [OFFICE_CODE] IN(" & strWhereOffice & ")"
            Else
                SumRepSql &= "[OFFICE_CODE] IN(" & strWhereOffice & ")"
            End If
        End If
        FirstPass = True
        For Each ThisItem In Me.lstSalesClass.Items
            If ThisItem.Selected = True Then
                If FirstPass = True Then
                    strWhereSalesClass &= "'" & ThisItem.Value & "'"
                    FirstPass = False
                Else
                    strWhereSalesClass &= ",'" & ThisItem.Value & "'"
                End If
            End If
        Next
        If strWhereSalesClass.Trim <> "" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql &= " AND [SC_CODE] IN(" & strWhereSalesClass & ")"
            Else
                SumRepSql &= "[SC_CODE] IN(" & strWhereSalesClass & ")"
            End If
        End If

        If Me.ddManager.SelectedValue <> "All" Then
            If SumRepSql.Trim <> "" Then
                SumRepSql &= " AND [MGR_EMP_CODE] IN('" & Me.ddManager.SelectedValue & "')"
            Else
                SumRepSql &= "[MGR_EMP_CODE] IN('" & Me.ddManager.SelectedValue & "')"
            End If
        End If

        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                If strWhereOffice <> "" Or strWhereStatus <> "" Or strWhereSalesClass <> "" Or Me.ddManager.SelectedValue <> "All" Then
                    SumRepSql &= " AND " & strWhereClient
                Else
                    SumRepSql &= strWhereClient
                End If
                If strWhereDivision <> "" Then
                    SumRepSql &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        SumRepSql &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If



        Return SumRepSql
    End Function

    Private Sub optCDP_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optCDP.SelectedIndexChanged
        Select Case Me.optCDP.SelectedValue
            Case "a"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.optCDP.Focus()
            Case "c"
                Me.pnlClient.Visible = True
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.lstClient.Focus()
            Case "d"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = True
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstProduct.ClearSelection()
                Me.lstDivision.Focus()
            Case "p"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = True
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
                Me.lstProduct.Focus()
        End Select
        'ChangeFilterSettings()
    End Sub
    Private Sub rdlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlStatus.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlStatus.Items(0).Selected = True Then
            For i = 0 To Me.lbStatus.Items.Count - 1
                If Me.lbStatus.Items(i).Selected = True Then
                    Me.lbStatus.Items(i).Selected = False
                End If
            Next
            lbStatus.Enabled = False
            rdlStatus.Focus()
        Else
            lbStatus.Enabled = True
            lbStatus.Focus()
        End If
    End Sub

    Private Sub rblOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblOffices.SelectedIndexChanged
        Dim i As Integer
        If Me.rblOffices.Items(0).Selected = True Then
            For i = 0 To Me.lbOffices.Items.Count - 1
                If Me.lbOffices.Items(i).Selected = True Then
                    Me.lbOffices.Items(i).Selected = False
                End If
            Next
            lbOffices.Enabled = False
            rblOffices.Focus()
        Else
            lbOffices.Enabled = True
            lbOffices.Focus()
        End If
    End Sub

    Protected Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim strURL As String
        Dim I As Integer
        Dim strFilter As String
        Try
            If rdlDueDate.Items(1).Selected Then
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                    Me.ShowMessage("Invalid Start Date")
                    Exit Sub
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
                    Me.ShowMessage("Invalid Start Date")
                    Exit Sub
                End If
            End If
            If rdlDueDate.Items(0).Selected Then
                Me.RadDatePickerStartDate.SelectedDate = CType(LoGlo.FormatDate("01/01/1950"), Date)
                Me.RadDatePickerEndDate.SelectedDate = CType(LoGlo.FormatDate("01/01/2050"), Date)
            End If
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = False Then
                Me.ShowMessage("Invalid Start Date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid Start Date")
                Exit Sub
            End If
            If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                Me.ShowMessage("Invalid date range")
                Exit Sub
            End If
        Catch ex As Exception
            Me.ShowMessage("Error validating date: " & ex.Message.ToString())

        End Try
        strFilter = MakeSql()



        Dim AEParm As String
        'AEParm = "&AECodes="
        If Me.rdlAE.Items(1).Selected = True Then
            For I = 0 To Me.lstAEs.Items.Count - 1
                If Me.lstAEs.Items(I).Selected = True Then
                    AEParm &= Me.lstAEs.Items(I).Value & ","
                End If
            Next I
            AEParm = AEParm.Substring(0, AEParm.Length - 1)
        Else
            AEParm &= "%"
        End If

        Dim oReports As New cReports(Session("ConnString"))
        Dim dt As DataTable
        'If Me.RadDatePickerStartDate.SelectedDate = "" And Me.RadDatePickerEndDate.SelectedDate = "" Then
        '    dt = oReports.GetSumRepByClient(Session("UserCode"), LoGlo.FormatDate("01/01/1950"), LoGlo.FormatDate("01/01/2050"), Me.cbIncludeCompSchedules.Checked, AEParm)
        'Else
        dt = oReports.GetSumRepByClient(Session("UserCode"), wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString, wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString, Me.cbIncludeCompSchedules.Checked, AEParm, Me.IsClientPortal, Session("UserID"))
        'End If
        Dim MainDView As DataView
        MainDView = New DataView(dt)
        MainDView.RowFilter = strFilter
        If MainDView.Count = 0 Then
            Me.lbl_msg.Text = "No Data Found For Selected Inputs"
            Exit Sub
        End If

        Try
            If Me.chkSaveSettings.Checked = True Then
                SaveSettings()
            End If

        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

        If Me.rbCSCJDD.Checked = True Then
            strURL = "popReportViewer.aspx?Report=SumRepByClientSalesClass"
        Else
            strURL = "popReportViewer.aspx?Report=SumRepByClient"
        End If
        strURL &= "&UserID=" & Session("UserCode")
        'strURL &= "&Filter=" & Me.Me.Sanitize(strFilter)
        Session("ProjectSummaryRPT") = strFilter
        ' If rdlDueDate.Items(1).Selected Then
        strURL &= "&StartDate=" & wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
        strURL &= "&EndDate=" & wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString
        'Else
        '    strURL &= "&StartDate=" & "01/01/1950"
        '    strURL &= "&EndDate=" & "01/01/2050"
        'End If

        strURL &= "&division=" & Me.chkDivision.Checked
        strURL &= "&product=" & Me.chkProduct.Checked
        strURL &= "&AE=" & Me.chkAE.Checked
        strURL &= "&jobdesc=" & Me.chkJobDesc.Checked
        strURL &= "&component=" & Me.chkComponent.Checked
        strURL &= "&jobcompdesc=" & Me.chkJobCompDesc.Checked
        strURL &= "&jobqty=" & Me.chkJobQuantity.Checked
        strURL &= "&jtype=" & Me.chkType.Checked
        strURL &= "&typedesc=" & Me.chkTypeDesc.Checked
        strURL &= "&status=" & Me.chkStatus.Checked
        strURL &= "&ref=" & Me.chkRef.Checked
        strURL &= "&sdate=" & Me.chkSDate.Checked
        strURL &= "&duedate=" & Me.chkDueDate.Checked
        strURL &= "&comments=" & Me.chkComments.Checked
        strURL &= "&ndue=" & Me.chkndue.Checked
        strURL &= "&nduedate=" & Me.chknduedate.Checked
        strURL &= "&nduecom=" & Me.chkntaskcomm.Checked
        strURL &= "&estimate=" & Me.chkest.Checked
        strURL &= "&estaprv=" & Me.chkestaprv.Checked
        strURL &= "&title=" & Me.txtReportTitle.Text
        strURL &= "&includeCS=" & Me.cbIncludeCompSchedules.Checked
        strURL &= "&AECodes=" & AEParm
        Dim ddl As Telerik.Web.UI.RadComboBox
        ddl = reporttype.FindControl("RadComboBoxReportType")
        strURL &= "&Type=" & ddl.SelectedValue
        Response.Redirect(strURL)


    End Sub
    Private Sub SaveSettings()
        'Report Options
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SUM_RPT, Session("UserCode"))

            oAppVars.getAllAppVars()
            With oAppVars
                If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                    .setAppVar("StartDate", Me.RadDatePickerStartDate.SelectedDate)
                Else
                    .setAppVar("StartDate", "")
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                    .setAppVar("EndDate", Me.RadDatePickerEndDate.SelectedDate)
                Else
                    .setAppVar("EndDate", "")
                End If

                .setAppVar("division", Me.chkDivision.Checked)
                .setAppVar("product", Me.chkProduct.Checked)
                .setAppVar("AE", Me.chkAE.Checked)
                .setAppVar("jobdesc", Me.chkJobDesc.Checked)
                .setAppVar("component", Me.chkComponent.Checked)
                .setAppVar("jobcompdesc", Me.chkJobCompDesc.Checked)
                .setAppVar("jobqty", Me.chkJobQuantity.Checked)
                .setAppVar("type", Me.chkType.Checked)
                .setAppVar("typedesc", Me.chkTypeDesc.Checked)
                .setAppVar("status", Me.chkStatus.Checked)
                .setAppVar("ref", Me.chkRef.Checked)
                .setAppVar("sdate", Me.chkSDate.Checked)
                .setAppVar("duedate", Me.chkDueDate.Checked)
                .setAppVar("comments", Me.chkComments.Checked)
                .setAppVar("ndue", Me.chkndue.Checked)
                .setAppVar("nduedate", Me.chknduedate.Checked)
                .setAppVar("nduecom", Me.chkntaskcomm.Checked)
                .setAppVar("estimate", Me.chkest.Checked)
                .setAppVar("estaprv", Me.chkestaprv.Checked)
                .setAppVar("title", Me.txtReportTitle.Text)
                .setAppVar("IncludeCS", Me.cbIncludeCompSchedules.Checked)
                .SaveAllAppVars()
            End With
            'Response.Cookies("sumrepbyclient").Expires = Now.AddYears(1)

            'Response.Cookies("sumrepbyclient")("division") = Me.chkDivision.Checked

            'If Me.RadDatePickerStartDate.SelectedDate <> "" AndAlso Me.RadDatePickerStartDate.SelectedDate <> "01/01/1950" Then
            '    Response.Cookies("sumrepbyclient")("StartDate") = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
            'Else
            '    Response.Cookies("sumrepbyclient")("StartDate") = ""
            'End If
            'If Me.RadDatePickerEndDate.SelectedDate <> "" AndAlso Me.RadDatePickerEndDate.SelectedDate <> "01/01/2050" Then
            '    Response.Cookies("sumrepbyclient")("EndDate") = wvCDate(Me.RadDatePickerEndDate.SelectedDate)
            'Else
            '    Response.Cookies("sumrepbyclient")("EndDate") = ""
            'End If

            'Response.Cookies("sumrepbyclient")("product") = Me.chkProduct.Text
            'Response.Cookies("sumrepbyclient")("AE") = Me.chkAE.Checked
            'Response.Cookies("sumrepbyclient")("jobdesc") = Me.chkJobDesc.Checked
            'Response.Cookies("sumrepbyclient")("component") = Me.chkComponent.Checked
            'Response.Cookies("sumrepbyclient")("jobcompdesc") = Me.chkJobCompDesc.Checked
            'Response.Cookies("sumrepbyclient")("type") = Me.chkType.Checked
            'Response.Cookies("sumrepbyclient")("typedesc") = Me.chkTypeDesc.Checked
            'Response.Cookies("sumrepbyclient")("status") = Me.chkStatus.Checked
            'Response.Cookies("sumrepbyclient")("ref") = Me.chkRef.Checked
            'Response.Cookies("sumrepbyclient")("sdate") = Me.chkSDate.Checked
            'Response.Cookies("sumrepbyclient")("duedate") = Me.chkDueDate.Checked
            'Response.Cookies("sumrepbyclient")("comments") = Me.chkComments.Checked
            'Response.Cookies("sumrepbyclient")("ndue") = Me.chkndue.Checked
            'Response.Cookies("sumrepbyclient")("nduedate") = Me.chknduedate.Checked
            'Response.Cookies("TaskList")(Me.chkDueDate.ID) = Me.chkDueDate.Checked
            'Response.Cookies("sumrepbyclient")("nduecom") = Me.chkntaskcomm.Checked
            'Response.Cookies("sumrepbyclient")("estimate") = Me.chkest.Checked
            'Response.Cookies("sumrepbyclient")("estaprv") = Me.chkestaprv.Checked
            'Response.Cookies("sumrepbyclient")("title") = Me.txtReportTitle.Text
            'Response.Cookies("sumrepbyclient")("IncludeCS") = Me.cbIncludeCompSchedules.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadSettings()

        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SUM_RPT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("StartDate")
            If s <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("EndDate")
            If s <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
            End If
            s = oAppVars.getAppVar("division")
            If s <> "" Then
                Me.chkDivision.Checked = s
            End If
            s = oAppVars.getAppVar("product")
            If s <> "" Then
                Me.chkProduct.Checked = s
            End If
            s = oAppVars.getAppVar("AE")
            If s <> "" Then
                Me.chkAE.Checked = s
            End If
            s = oAppVars.getAppVar("jobdesc")
            If s <> "" Then
                Me.chkJobDesc.Checked = s
            End If
            s = oAppVars.getAppVar("component")
            If s <> "" Then
                Me.chkComponent.Checked = s
            End If
            s = oAppVars.getAppVar("jobcompdesc")
            If s <> "" Then
                Me.chkJobCompDesc.Checked = s
            End If
            s = oAppVars.getAppVar("jobqty")
            If s <> "" Then
                Me.chkJobQuantity.Checked = s
            End If
            s = oAppVars.getAppVar("type")
            If s <> "" Then
                Me.chkType.Checked = s
            End If
            s = oAppVars.getAppVar("typedesc")
            If s <> "" Then
                Me.chkTypeDesc.Checked = s
            End If
            s = oAppVars.getAppVar("status")
            If s <> "" Then
                Me.chkStatus.Checked = s
            End If
            s = oAppVars.getAppVar("ref")
            If s <> "" Then
                Me.chkRef.Checked = s
            End If
            s = oAppVars.getAppVar("sdate")
            If s <> "" Then
                Me.chkSDate.Checked = s
            End If
            s = oAppVars.getAppVar("duedate")
            If s <> "" Then
                Me.chkDueDate.Checked = s
            End If
            s = oAppVars.getAppVar("comments")
            If s <> "" Then
                Me.chkComments.Checked = s
            End If
            s = oAppVars.getAppVar("ndue")
            If s <> "" Then
                Me.chkndue.Checked = s
            End If
            s = oAppVars.getAppVar("nduedate")
            If s <> "" Then
                Me.chknduedate.Checked = s
            End If
            s = oAppVars.getAppVar("nduecom")
            If s <> "" Then
                Me.chkntaskcomm.Checked = s
            End If
            s = oAppVars.getAppVar("estimate")
            If s <> "" Then
                Me.chkest.Checked = s
            End If
            s = oAppVars.getAppVar("estaprv")
            If s <> "" Then
                Me.chkestaprv.Checked = s
            End If
            s = oAppVars.getAppVar("title")
            If s <> "" Then
                Me.txtReportTitle.Text = s
            End If
            s = oAppVars.getAppVar("IncludeCS")
            If s <> "" Then
                Me.cbIncludeCompSchedules.Checked = s
            End If
            'If Request.Cookies("sumrepbyclient")("StartDate") <> "" Then
            '    Me.RadDatePickerStartDate.SelectedDate = Request.Cookies("sumrepbyclient")("StartDate")
            'End If
            'If Request.Cookies("sumrepbyclient")("EndDate") <> "" Then
            '    Me.RadDatePickerEndDate.SelectedDate = Request.Cookies("sumrepbyclient")("EndDate")
            'End If

            ' Me.chkProduct.Text = Request.Cookies("sumrepbyclient")("product")
            'Me.chkAE.Checked = Request.Cookies("sumrepbyclient")("AE")
            'Me.chkJobDesc.Checked = Request.Cookies("sumrepbyclient")("jobdesc")
            'Me.chkComponent.Checked = Request.Cookies("sumrepbyclient")("component")
            'Me.chkJobCompDesc.Checked = Request.Cookies("sumrepbyclient")("jobcompdesc")
            'Me.chkType.Checked = Request.Cookies("sumrepbyclient")("type")
            'Me.chkTypeDesc.Checked = Request.Cookies("sumrepbyclient")("typedesc")
            'Me.chkStatus.Checked = Request.Cookies("sumrepbyclient")("status")
            'Me.chkRef.Checked = Request.Cookies("sumrepbyclient")("ref")
            'Me.chkSDate.Checked = Request.Cookies("sumrepbyclient")("sdate")
            'Me.chkDueDate.Checked = Request.Cookies("sumrepbyclient")("duedate")
            'Me.chkComments.Checked = Request.Cookies("sumrepbyclient")("comments")
            'Me.chkndue.Checked = Request.Cookies("sumrepbyclient")("ndue")
            'Me.chknduedate.Checked = Request.Cookies("sumrepbyclient")("nduedate")
            'Me.chkntaskcomm.Checked = Request.Cookies("sumrepbyclient")("nduecom")
            'Me.chkest.Checked = Request.Cookies("sumrepbyclient")("estimate")
            'Me.chkestaprv.Checked = Request.Cookies("sumrepbyclient")("estaprv")
            'Me.txtReportTitle.Text = Request.Cookies("sumrepbyclient")("title")
            'If Request.Cookies("sumrepbyclient")("IncludeCS") <> "" Then
            '    Me.cbIncludeCompSchedules.Checked = Request.Cookies("sumrepbyclient")("IncludeCS")
            'End If
        Catch ex As Exception
            Me.lbl_msg.Text = "Error in loading settings"
        End Try

    End Sub

    Protected Sub rdlDueDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdlDueDate.SelectedIndexChanged
        If rdlDueDate.Items(0).Selected Then
            Me.RadDatePickerStartDate.SelectedDate = Nothing
            Me.RadDatePickerEndDate.SelectedDate = Nothing

            Me.RadDatePickerStartDate.Enabled = False
            Me.RadDatePickerEndDate.Enabled = False

            Me.RadDatePickerStartDate.DateInput.CssClass = Nothing
            Me.RadDatePickerEndDate.DateInput.CssClass = Nothing
            Me.rdlDueDate.Focus()
        Else
            Dim oAppVars As cAppVars
            If Me.IsClientPortal = True Then
                oAppVars = New cAppVars(cAppVars.Application.PROJECT_SUM_RPT, Session("UserID"))
            Else
                oAppVars = New cAppVars(cAppVars.Application.PROJECT_SUM_RPT, Session("UserCode"))
            End If
            oAppVars.getAllAppVars()
            Dim s As String = ""
            s = oAppVars.getAppVar("StartDate")
            If s <> "" Then
                Me.RadDatePickerStartDate.SelectedDate = CType(s, Date)
            Else
                Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth
            End If
            s = oAppVars.getAppVar("EndDate")
            If s <> "" Then
                Me.RadDatePickerEndDate.SelectedDate = CType(s, Date)
            Else
                Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth
            End If

            Me.RadDatePickerStartDate.Enabled = True
            Me.RadDatePickerEndDate.Enabled = True

            Me.RadDatePickerStartDate.DateInput.CssClass = "RequiredInput"
            Me.RadDatePickerEndDate.DateInput.CssClass = "RequiredInput"

            Me.RadDatePickerStartDate.DateInput.Focus()
        End If
    End Sub

    Private Sub rdlAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlAE.SelectedIndexChanged
        Dim i As Integer

        If Me.rdlAE.Items(0).Selected = True Then
            For i = 0 To Me.lstAEs.Items.Count - 1
                If Me.lstAEs.Items(i).Selected = True Then
                    Me.lstAEs.Items(i).Selected = False
                End If
            Next
            Me.lstAEs.Enabled = False
        Else
            Me.lstAEs.Enabled = True
        End If
    End Sub

    Private Sub rblSalesClass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblSalesClass.SelectedIndexChanged
        Dim i As Integer
        If Me.rblSalesClass.Items(0).Selected = True Then
            For i = 0 To Me.lstSalesClass.Items.Count - 1
                If Me.lstSalesClass.Items(i).Selected = True Then
                    Me.lstSalesClass.Items(i).Selected = False
                End If
            Next
            lstSalesClass.Enabled = False
            rblSalesClass.Focus()
        Else
            lstSalesClass.Enabled = True
            lstSalesClass.Focus()
        End If
    End Sub
End Class