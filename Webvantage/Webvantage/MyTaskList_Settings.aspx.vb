Imports Webvantage.cGlobals.Globals

Public Class MyTaskList_Settings
    Inherits Webvantage.BaseChildPage

    Private intDiv As Integer
    Private intClient As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_MyTaskListRTP)
        'header.SubMenu = SubMenu.Production
        If Me.IsPostBack = True Then

        Else
            Me.RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
            Me.RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday
            LoadClientList()
            LoadDivList()
            LoadProdList()
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
            'If Not Request.Cookies("TaskList") Is Nothing Then
            LoadSettings()
            'end If

            If Me.IsClientPortal = True Then
                Me.ddClientList.FindItemByValue(Session("CL_CODE")).Selected = True
                Me.ddClientList.Enabled = False
                LoadDivList(Session("CL_CODE"))
            End If

        End If

    End Sub

    Private Sub LoadClientList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddClientList.DataSource = oDropDowns.GetClientList(Session("UserCode"))
        Me.ddClientList.DataTextField = "Description"
        Me.ddClientList.DataValueField = "Code"
        Me.ddClientList.DataBind()
        Me.ddClientList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Clients", ""))
        If Len(intClient) > 0 Then
            Me.ddClientList.Items(intClient).Selected = True
        End If

    End Sub

    Private Overloads Sub LoadDivList(ByVal strClient As String)
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        If Me.IsClientPortal = True Then
            Me.ddDivList.DataSource = oDropDowns.GetDivisionListCP(Session("UserID"), strClient)
        Else
            Me.ddDivList.DataSource = oDropDowns.GetDivisionList(Session("UserCode"), strClient)
        End If
        Me.ddDivList.DataTextField = "Description"
        Me.ddDivList.DataValueField = "Code"
        Me.ddDivList.DataBind()
        Me.ddDivList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", ""))
        If Len(intDiv) > 0 Then
            Me.ddDivList.Items(intDiv).Selected = True
        End If
    End Sub

    Private Overloads Sub LoadDivList()
        Me.ddDivList.Items.Clear()
        Me.ddDivList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Divisions", ""))
    End Sub

    Private Overloads Sub LoadProdList(ByVal strClient As String, ByVal strDiv As String)
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        If Me.IsClientPortal = True Then
            Me.ddProductList.DataSource = oDropDowns.GetProductListCP(Session("UserID"), strClient, strDiv)
        Else
            Me.ddProductList.DataSource = oDropDowns.GetProductList(Session("UserCode"), strClient, strDiv)
        End If
        Me.ddProductList.DataTextField = "Description"
        Me.ddProductList.DataValueField = "Code"
        Me.ddProductList.DataBind()
        Me.ddProductList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", ""))
    End Sub

    Private Overloads Sub LoadProdList()
        Me.ddProductList.Items.Clear()
        Me.ddProductList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Products", ""))
    End Sub

    Private Sub SaveSettings()
        'Report Options
        Dim oAppVars As New cAppVars(cAppVars.Application.MY_TASK_LIST_RPT, Session("UserCode"))
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

            .setAppVar("Client", Me.ddClientList.SelectedItem.Value)
            .setAppVar("ClientIndex", Me.ddClientList.SelectedIndex)
            .setAppVar("Division", Me.ddDivList.SelectedItem.Value)
            .setAppVar("DivisionIndex", Me.ddDivList.SelectedIndex)
            .setAppVar("Product", Me.ddProductList.SelectedItem.Value)
            .setAppVar("ProductIndex", Me.ddProductList.SelectedIndex)
            .setAppVar("Completed", Me.chkCompleted.Checked)
            .setAppVar("DateRange", Me.rbDateRange.Checked)

            .setAppVar("PastDue", Me.rbPastDue.Text)
            .setAppVar("Sortcdp", Me.rbCDP.Checked)
            .setAppVar("SortDate", Me.rbDueDate.Checked)
            .setAppVar("SortTask", Me.rbTask.Checked)

            .setAppVar(Me.chkSubHeadings.ID, Me.chkSubHeadings.Checked)
            .setAppVar(Me.chkClient.ID, Me.chkClient.Checked)
            .setAppVar(Me.chkDivision.ID, Me.chkDivision.Checked)
            .setAppVar(Me.chkProduct.ID, Me.chkProduct.Checked)
            .setAppVar(Me.chkJob.ID, Me.chkJob.Checked)
            .setAppVar(Me.chkComponent.ID, Me.chkComponent.Checked)
            .setAppVar(Me.chkTask.ID, Me.chkTask.Checked)
            .setAppVar(Me.chkHrsAllowed.ID, Me.chkHrsAllowed.Checked)
            .setAppVar(Me.chkDueDate.ID, Me.chkDueDate.Checked)
            .setAppVar(Me.chkRevDueDate.ID, Me.chkRevDueDate.Checked)
            .setAppVar(Me.chkTimeDue.ID, Me.chkTimeDue.Checked)
            .setAppVar(Me.chkComments.ID, Me.chkComments.Checked)
            .setAppVar(Me.chkClient.ID & "E", Me.chkClient.Enabled)
            .setAppVar(Me.chkDivision.ID & "E", Me.chkDivision.Enabled)
            .setAppVar(Me.chkProduct.ID & "E", Me.chkProduct.Enabled)
            .setAppVar(Me.chkDueDate.ID & "E", Me.chkDueDate.Enabled)
            .SaveAllAppVars()
        End With
        'Response.Cookies("TaskList").Expires = Now.AddYears(1)
        'Response.Cookies("TaskList")("Client") = Me.ddClientList.SelectedItem.Value
        'Response.Cookies("TaskList")("ClientIndex") = Me.ddClientList.SelectedIndex
        'Response.Cookies("TaskList")("Division") = Me.ddDivList.SelectedItem.Value
        'Response.Cookies("TaskList")("DivisionIndex") = Me.ddDivList.SelectedIndex
        'Response.Cookies("TaskList")("Product") = Me.ddProductList.SelectedItem.Value
        'Response.Cookies("TaskList")("ProductIndex") = Me.ddProductList.SelectedIndex
        'Response.Cookies("TaskList")("Completed") = Me.chkCompleted.Checked
        ''Date Options
        'Response.Cookies("TaskList")("DateRange") = Me.rbDateRange.Checked

        'If Me.RadDatePickerStartDate.SelectedDate <> "" Then
        '    Response.Cookies("TaskList")("StartDate") = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        'Else
        '    Response.Cookies("TaskList")("StartDate") = ""
        'End If
        'If Me.RadDatePickerEndDate.SelectedDate <> "" Then
        '    Response.Cookies("TaskList")("EndDate") = wvCDate(Me.RadDatePickerEndDate.SelectedDate)
        'Else
        '    Response.Cookies("TaskList")("EndDate") = ""
        'End If

        'Response.Cookies("TaskList")("PastDue") = Me.rbPastDue.Text
        ''Sort Options
        'Response.Cookies("TaskList")("Sortcdp") = Me.rbCDP.Checked
        'Response.Cookies("TaskList")("SortDate") = Me.rbDueDate.Checked
        'Response.Cookies("TaskList")("SortTask") = Me.rbTask.Checked
        'Response.Cookies("TaskList")(Me.chkSubHeadings.ID) = Me.chkSubHeadings.Checked
        ''Show Fields
        'Response.Cookies("TaskList")(Me.chkClient.ID) = Me.chkClient.Checked
        'Response.Cookies("TaskList")(Me.chkDivision.ID) = Me.chkDivision.Checked
        'Response.Cookies("TaskList")(Me.chkProduct.ID) = Me.chkProduct.Checked
        'Response.Cookies("TaskList")(Me.chkJob.ID) = Me.chkJob.Checked
        'Response.Cookies("TaskList")(Me.chkComponent.ID) = Me.chkComponent.Checked
        'Response.Cookies("TaskList")(Me.chkTask.ID) = Me.chkTask.Checked
        'Response.Cookies("TaskList")(Me.chkHrsAllowed.ID) = Me.chkHrsAllowed.Checked
        'Response.Cookies("TaskList")(Me.chkDueDate.ID) = Me.chkDueDate.Checked
        'Response.Cookies("TaskList")(Me.chkRevDueDate.ID) = Me.chkRevDueDate.Checked
        'Response.Cookies("TaskList")(Me.chkTimeDue.ID) = Me.chkTimeDue.Checked
        'Response.Cookies("TaskList")(Me.chkComments.ID) = Me.chkComments.Checked
        'Response.Cookies("TaskList")(Me.chkClient.ID & "E") = Me.chkClient.Enabled
        'Response.Cookies("TaskList")(Me.chkDivision.ID & "E") = Me.chkDivision.Enabled
        'Response.Cookies("TaskList")(Me.chkProduct.ID & "E") = Me.chkProduct.Enabled
        'Response.Cookies("TaskList")(Me.chkDueDate.ID & "E") = Me.chkDueDate.Enabled

    End Sub

    Private Sub LoadSettings()

        Dim oAppVars As New cAppVars(cAppVars.Application.MY_TASK_LIST_RPT, Session("UserCode"))
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
        's = oAppVars.getAppVar("Client")
        'If s <> "" Then
        '    Me.chkClient.Checked = s
        'End If
        's = oAppVars.getAppVar("ClientIndex")
        'If s <> "" Then
        '    Me.chkClientName.Checked = s
        'End If
        's = oAppVars.getAppVar("Division")
        'If s <> "" Then
        '    Me.chkDivision.Checked = s
        'End If
        's = oAppVars.getAppVar("DivisionIndex")
        'If s <> "" Then
        '    Me.chkDivisionName.Checked = s
        'End If
        's = oAppVars.getAppVar("Product")
        'If s <> "" Then
        '    Me.chkProduct.Checked = s
        'End If
        's = oAppVars.getAppVar("ProductIndex")
        'If s <> "" Then
        '    Me.chkProductName.Checked = s
        'End If
        s = oAppVars.getAppVar("Completed")
        If s <> "" Then
            Me.chkCompleted.Checked = s
        End If
        s = oAppVars.getAppVar("DateRange")
        If s <> "" Then
            Me.rbDateRange.Checked = s
        End If
        s = oAppVars.getAppVar("PastDue")
        If s <> "" Then
            Me.rbPastDue.Text = s
        End If
        s = oAppVars.getAppVar("Sortcdp")
        If s <> "" Then
            Me.rbCDP.Checked = s
        End If
        s = oAppVars.getAppVar("SortDate")
        If s <> "" Then
            Me.rbDueDate.Checked = s
        End If
        s = oAppVars.getAppVar("SortTask")
        If s <> "" Then
            Me.rbTask.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkSubHeadings.ID)
        If s <> "" Then
            Me.chkSubHeadings.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkClient.ID)
        If s <> "" Then
            Me.chkClient.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkDivision.ID)
        If s <> "" Then
            Me.chkDivision.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkProduct.ID)
        If s <> "" Then
            Me.chkProduct.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkJob.ID)
        If s <> "" Then
            Me.chkJob.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkComponent.ID)
        If s <> "" Then
            Me.chkComponent.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkTask.ID)
        If s <> "" Then
            Me.chkTask.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkHrsAllowed.ID)
        If s <> "" Then
            Me.chkHrsAllowed.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkDueDate.ID)
        If s <> "" Then
            Me.chkDueDate.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkRevDueDate.ID)
        If s <> "" Then
            Me.chkRevDueDate.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkTimeDue.ID)
        If s <> "" Then
            Me.chkTimeDue.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkComments.ID)
        If s <> "" Then
            Me.chkComments.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkClient.ID & "E")
        If s <> "" Then
            Me.chkClient.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkDivision.ID & "E")
        If s <> "" Then
            Me.chkDivision.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkProduct.ID & "E")
        If s <> "" Then
            Me.chkProduct.Checked = s
        End If
        s = oAppVars.getAppVar(Me.chkDueDate.ID & "E")
        If s <> "" Then
            Me.chkDueDate.Checked = s
        End If

        
        'Me.chkCompleted.Checked = Request.Cookies("TaskList")("Completed")
        'Date Options 
        'Me.rbDateRange.Checked = Request.Cookies("TaskList")("DateRange")

        'If Request.Cookies("TaskList")("StartDate") <> "" Then
        '    Me.RadDatePickerStartDate.SelectedDate = Request.Cookies("TaskList")("StartDate")
        'End If
        'If Request.Cookies("TaskList")("EndDate") <> "" Then
        '    Me.RadDatePickerEndDate.SelectedDate = Request.Cookies("TaskList")("EndDate")
        'End If

        'Me.rbPastDue.Text = Request.Cookies("TaskList")("PastDue")

        'Sort Options
        'Me.rbCDP.Checked = Request.Cookies("TaskList")("Sortcdp")
        'Me.rbDueDate.Checked = Request.Cookies("TaskList")("SortDate")
        'Me.rbTask.Checked = Request.Cookies("TaskList")("SortTask")
        'Me.chkSubHeadings.Checked = Request.Cookies("TaskList")(Me.chkSubHeadings.ID)
        'Show Fields
        'Me.chkClient.Checked = Request.Cookies("TaskList")(Me.chkClient.ID)
        'Me.chkDivision.Checked = Request.Cookies("TaskList")(Me.chkDivision.ID)
        'Me.chkProduct.Checked = Request.Cookies("TaskList")(Me.chkProduct.ID)
        'Me.chkJob.Checked = Request.Cookies("TaskList")(Me.chkJob.ID)
        'Me.chkComponent.Checked = Request.Cookies("TaskList")(Me.chkComponent.ID)
        'Me.chkTask.Checked = Request.Cookies("TaskList")(Me.chkTask.ID)
        'Me.chkHrsAllowed.Checked = Request.Cookies("TaskList")(Me.chkHrsAllowed.ID)
        'Me.chkDueDate.Checked = Request.Cookies("TaskList")(Me.chkDueDate.ID)
        'Me.chkRevDueDate.Checked = Request.Cookies("TaskList")(Me.chkRevDueDate.ID)
        'Me.chkTimeDue.Checked = Request.Cookies("TaskList")(Me.chkTimeDue.ID)
        'Me.chkComments.Checked = Request.Cookies("TaskList")(Me.chkComments.ID)
        'Me.chkClient.Enabled = Request.Cookies("TaskList")(Me.chkClient.ID & "E")
        'Me.chkDivision.Enabled = Request.Cookies("TaskList")(Me.chkDivision.ID & "E")
        'Me.chkProduct.Enabled = Request.Cookies("TaskList")(Me.chkProduct.ID & "E")
        'Me.chkDueDate.Enabled = Request.Cookies("TaskList")(Me.chkDueDate.ID & "E")
    End Sub

    Private Sub rbDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDateRange.CheckedChanged
        If Me.rbDateRange.Checked = True Then
            Me.RadDatePickerStartDate.Enabled = True
            Me.RadDatePickerEndDate.Enabled = True
        End If
    End Sub

    Private Sub rbPastDue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPastDue.CheckedChanged
        If Me.rbPastDue.Checked = True Then
            Me.RadDatePickerStartDate.Enabled = False
            Me.RadDatePickerEndDate.Enabled = False
        End If
    End Sub

    Private Sub rbCDP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCDP.CheckedChanged, rbDueDate.CheckedChanged, rbTask.CheckedChanged, chkSubHeadings.CheckedChanged
        CheckChanged()
    End Sub

    Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim strURL As String
        Dim dtStart As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("3/31/1974 12:00:00 AM"))
        Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("6/6/2079 11:59:59 PM"))
        Try
            If Me.rbPastDue.Checked = False Then
                If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                    Me.ShowMessage("Invalid Start date")
                    Exit Sub
                Else
                    dtStart = Me.RadDatePickerStartDate.SelectedDate
                End If
                If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                    Me.ShowMessage("Invalid End date")
                    Exit Sub
                Else
                    dtEnd = Me.RadDatePickerEndDate.SelectedDate
                End If
                If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                    Me.lblError.Text = "End Date must be greater than Start Date"
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Me.ShowMessage("Error validating date: " & ex.Message.ToString())
        End Try

        Try
            If Me.chkSaveSettings.Checked = True Then
                SaveSettings()
            End If
        Catch ex As Exception
            Me.ShowMessage("Error with SaveSettings: " & ex.Message.ToString())
        End Try

        Try
            If Me.rbCDP.Checked = True Then
                strURL = "popReportViewer.aspx?Report=tasklist"
                strURL = strURL & "&SortOrder=1"
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
            ElseIf Me.rbDueDate.Checked = True Then
                strURL = "popReportViewer.aspx?Report=tasklistduedate"
                strURL = strURL & "&SortOrder=2"
                strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
                strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
                strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
                strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
            Else
                strURL = "popReportViewer.aspx?Report=tasklisttask"
                strURL = strURL & "&SortOrder=3"
                strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
                strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
                strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
                strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
                strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
            End If


            strURL &= "&UserID=" & Session("UserCode")
            strURL &= "&EmpCode=" & Session("EmpCode")
            If IsClientPortal = True Then
                strURL &= "&EmpName=" & Session("ContactName")
            Else
                strURL &= "&EmpName=" & Session("EmployeeName")
            End If
            Dim strClientList As String = Trim(Me.ddClientList.SelectedItem.Value)
            If strClientList = "" Then
                strClientList = "%"
            End If
            strURL &= "&ClientCode=" & strClientList
            Dim strDivList As String = Trim(Me.ddDivList.SelectedItem.Value)
            If strDivList = "" Then
                strDivList = "%"
            End If
            strURL &= "&DivCode=" & strDivList
            Dim strProdList As String = Trim(Me.ddProductList.SelectedItem.Value)
            If strProdList = "" Then
                strProdList = "%"
            End If
            strURL &= "&ProdCode=" & strProdList
            strURL &= "&JobNumber=%"
            If Me.chkCompleted.Checked = True Then
                strURL &= "&Completed=" & dtStart.ToShortDateString()
                strURL &= "&chkCompleted=False"
            Else
                strURL &= "&Completed=" & Now.AddYears(1).Date
                strURL &= "&chkCompleted=True"
            End If
            If Me.rbDateRange.Checked = True Then
                strURL &= "&StartDate=" & dtStart.ToShortDateString()
                strURL &= "&EndDate=" & dtEnd.ToShortDateString()
                'strURL &= "&StartDate=" & Me.RadDatePickerStartDate.SelectedDate
                'strURL &= "&EndDate=" & Me.RadDatePickerEndDate.SelectedDate
            Else
                'strURL &= "&PastDue=1"
                strURL &= "&StartDate=" & Now.AddYears(-5).ToShortDateString()
                strURL &= "&EndDate=" & Now.ToShortDateString
            End If
            strURL &= "&" & Me.chkComponent.ID & "=" & GetChecked(Me.chkComponent.Checked)
            'strURL &= "&" & Me.chkTask.ID & "=" & CInt(Me.chkTask.Checked)
            strURL &= "&" & Me.chkHrsAllowed.ID & "=" & GetChecked(Me.chkHrsAllowed.Checked)
            strURL &= "&" & Me.chkDueDate.ID & "=" & GetChecked(Me.chkDueDate.Checked)
            strURL &= "&" & Me.chkComments.ID & "=" & GetChecked(Me.chkComments.Checked)
            strURL &= "&" & Me.chkTimeDue.ID & "=" & GetChecked(Me.chkTimeDue.Checked)
            If Session("UserID") Is Nothing Then
                strURL &= "&CPID=0"
            Else
                strURL &= "&CPID=" & Session("UserID")
            End If
            strURL &= "&CP=" & Me.IsClientPortal
            Dim ddl As Telerik.Web.UI.RadComboBox
            ddl = reporttype.FindControl("RadComboBoxReportType")
            strURL &= "&Type=" & ddl.SelectedValue
            Response.Redirect(strURL)

            'Original Code for Reporting Services
            'If Me.rbCDP.Checked = True Then
            '    strURL = strReportServer & "?/Reports/tasklist&ConnString=" & (Encrypt(Session("ConnString")))
            '    strURL = strURL & "&SortOrder=1"
            '    strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
            'ElseIf Me.rbDueDate.Checked = True Then
            '    strURL = strReportServer & "?/Reports/tasklistduedate&ConnString=" & (Encrypt(Session("ConnString")))
            '    strURL = strURL & "&SortOrder=2"
            '    strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
            '    strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
            '    strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
            '    strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
            'Else
            '    strURL = strReportServer & "?/Reports/tasklisttask&ConnString=" & (Encrypt(Session("ConnString")))
            '    strURL = strURL & "&SortOrder=3"
            '    strURL &= "&" & Me.chkClient.ID & "=" & GetChecked(Me.chkClient.Checked)
            '    strURL &= "&" & Me.chkDivision.ID & "=" & GetChecked(Me.chkDivision.Checked)
            '    strURL &= "&" & Me.chkProduct.ID & "=" & GetChecked(Me.chkProduct.Checked)
            '    strURL &= "&" & Me.chkJob.ID & "=" & GetChecked(Me.chkJob.Checked)
            '    strURL &= "&" & Me.chkRevDueDate.ID & "=" & GetChecked(Me.chkRevDueDate.Checked)
            'End If


            'strURL &= "&UserID=" & Session("UserCode")
            'strURL &= "&EmpCode=" & Session("EmpCode")
            'strURL &= "&EmpName=" & Session("EmployeeName")
            'Dim strClientList As String = Trim(Me.ddClientList.SelectedItem.Value)
            'If strClientList = "" Then
            '    strClientList = "%"
            'End If
            'strURL &= "&ClientCode=" & strClientList
            'Dim strDivList As String = Trim(Me.ddDivList.SelectedItem.Value)
            'If strDivList = "" Then
            '    strDivList = "%"
            'End If
            'strURL &= "&DivCode=" & strDivList
            'Dim strProdList As String = Trim(Me.ddProductList.SelectedItem.Value)
            'If strProdList = "" Then
            '    strProdList = "%"
            'End If
            'strURL &= "&ProdCode=" & strProdList
            'strURL &= "&JobNumber=%"
            'If Me.chkCompleted.Checked = True Then
            '    strURL &= "&Completed=" & Me.RadDatePickerStartDate.SelectedDate
            '    strURL &= "&chkCompleted=False"
            'Else
            '    strURL &= "&Completed=" & Now.AddYears(1).Date
            '    strURL &= "&chkCompleted=True"
            'End If
            'If Me.rbDateRange.Checked = True Then
            '    'strURL &= "&StartDate=" & wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
            '    'strURL &= "&EndDate=" & wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString
            '    strURL &= "&StartDate=" & Me.RadDatePickerStartDate.SelectedDate
            '    strURL &= "&EndDate=" & Me.RadDatePickerEndDate.SelectedDate
            'Else
            '    'strURL &= "&PastDue=1"
            '    strURL &= "&StartDate=" & Now.AddYears(-5).ToShortDateString
            '    strURL &= "&EndDate=" & Now.ToShortDateString
            'End If
            'strURL &= "&" & Me.chkComponent.ID & "=" & GetChecked(Me.chkComponent.Checked)
            ''strURL &= "&" & Me.chkTask.ID & "=" & CInt(Me.chkTask.Checked)
            'strURL &= "&" & Me.chkHrsAllowed.ID & "=" & GetChecked(Me.chkHrsAllowed.Checked)
            'strURL &= "&" & Me.chkDueDate.ID & "=" & GetChecked(Me.chkDueDate.Checked)
            'strURL &= "&" & Me.chkComments.ID & "=" & GetChecked(Me.chkComments.Checked)
            'strURL &= "&rs:Command=Render&rc:Toolbar=True&rc:Parameters=False"
            ''this parameter is passed from the reporttype user control
            'If reporttype.strReportSelect <> "Reporting Services" Then
            '    strURL &= reporttype.strReportSelect
            'End If

        Catch ex As Exception
            Me.ShowMessage("Error setting strURL : " & ex.Message.ToString())
        End Try



        'make open new browser
        'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', '', 'scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
        'strBuilder.Append("</")
        'strBuilder.Append("script>")
        'RegisterStartupScript("newpage", strBuilder.ToString())

    End Sub

    Private Sub CheckChanged()
        If Me.rbCDP.Checked = True Then
            Me.chkClient.Checked = True
            Me.chkProduct.Checked = True
            Me.chkDivision.Checked = True
            Me.chkJob.Checked = True
            Me.chkClient.Enabled = False
            Me.chkProduct.Enabled = False
            Me.chkDivision.Enabled = False
            Me.chkJob.Enabled = False
        Else
            Me.chkClient.Enabled = True
            Me.chkProduct.Enabled = True
            Me.chkDivision.Enabled = True
            Me.chkJob.Enabled = True
        End If
        If Me.rbDueDate.Checked = True Then 'And Me.chkSubHeadings.Checked = True Then
            Me.chkRevDueDate.Checked = True
            Me.chkRevDueDate.Enabled = False
        Else
            Me.chkRevDueDate.Enabled = True
        End If
    End Sub

    Private Sub ddClientList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddClientList.SelectedIndexChanged
        intClient = Me.ddClientList.SelectedIndex
        If intClient > 0 Then
            LoadDivList(Me.ddClientList.SelectedItem.Value)
            LoadProdList()
        Else
            LoadDivList()
            LoadProdList()
        End If
    End Sub

    Private Sub ddDivList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddDivList.SelectedIndexChanged

        If Me.IsClientPortal = True Then
            LoadProdList(Me.ddClientList.SelectedItem.Value, Me.ddDivList.SelectedItem.Value)
        Else
            intDiv = Me.ddDivList.SelectedIndex
            If intDiv > 0 Then
                LoadProdList(Me.ddClientList.SelectedItem.Value, Me.ddDivList.SelectedItem.Value)
            Else
                LoadProdList()
            End If
        End If
        
    End Sub

    Public Function GetChecked(ByVal blnChecked As Boolean) As String
        If blnChecked = True Then
            Return False
        Else
            Return True
        End If
    End Function

End Class