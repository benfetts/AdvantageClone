Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class DirectTime_Settings
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PageTitle = "Direct Time"
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Reports_DirectTimeRTP)

        If Request("__EVENTTARGET") = "SelectTab" Then
            If Request("__EVENTARGUMENT") <> "" Then
                SelectTab(CInt(Request("__EVENTARGUMENT")))

            End If
        Else
            If Page.IsPostBack = True Then
                If Me.txtCurrentTab.Text <> "" Then
                    SelectTab(CInt(Me.txtCurrentTab.Text))
                End If
            End If
        End If


        If Page.IsPostBack = False Then

            'SelectTab(1)
            InitSelection()
            InitDisplay()
            InitFilter()
            LoadSettings()
            Me.TabSel.Selected = True
            Me.pnlSelection.Visible = True
            Me.pnlFilter.Visible = False
            Me.pnlDisplay.Visible = False
            Me.pnlSort.Visible = False
            'LoadTabs("ChildPage.Master")
        Else

        End If
        If Me.txtCDPCompareString.Text <> CreateCompareString() Then
            ChangeFilterSettings()
            Me.txtCDPCompareString.Text = CreateCompareString()
        End If

        If Me.chkSaveSettings.Checked = True Then
            SaveSettings()
        End If

    End Sub
    Public Sub SelectTab(ByVal ThisTab As Integer)
    End Sub
    Private Sub InitSelection()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))


        Me.optCDP.Items(0).Selected = True
        Me.pnlClient.Visible = False
        Me.pnlDivision.Visible = False
        Me.pnlProduct.Visible = False


        Me.lstClient.DataSource = oDD.GetClientList(Session("UserCode"))
        Me.lstClient.DataTextField = "Description"
        Me.lstClient.DataValueField = "Code"
        Me.lstClient.DataBind()
        Me.lstDivision.DataSource = oDD.GetDivisionsAll(Session("UserCode"))
        Me.lstDivision.DataTextField = "Description"
        Me.lstDivision.DataValueField = "Code"
        Me.lstDivision.DataBind()
        Me.lstProduct.DataSource = oDD.GetProductsAll(Session("UserCode"))
        Me.lstProduct.DataTextField = "Description"
        Me.lstProduct.DataValueField = "Code"
        Me.lstProduct.DataBind()

    End Sub
    Private Sub InitFilter()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        'Date Range
        Me.RadDatePickerStartDate.SelectedDate = LoGlo.FirstOfMonth()
        Me.RadDatePickerEndDate.SelectedDate = LoGlo.LastOfMonth()

        'Functions
        Me.lstFunctions.DataSource = oDD.GetFunctionsByUserID(Session("UserID"))
        Me.lstFunctions.DataTextField = "Description"
        Me.lstFunctions.DataValueField = "Code"
        Me.lstFunctions.DataBind()

        'Employee
        Me.lstEmployee.DataSource = oDD.GetEmployees(CStr(Session("UserCode")), Me.CheckboxShowTerminatedEmployees.Checked)
        Me.lstEmployee.DataTextField = "Description"
        Me.lstEmployee.DataValueField = "Code"
        Me.lstEmployee.DataBind()

    End Sub
    Private Sub ChangeFilterSettings()
        Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
        Dim ds As DataSet
        Dim JobSQL As String
        Dim strWhereClient As String
        Dim strWhereDivision As String
        Dim strWhereProduct As String
        Dim strsplit As String() = Nothing
        Dim ThisItem As RadListBoxItem
        Dim PCSQL As String
        Dim FirstPass As Boolean

        'Product Category
        PCSQL = "SELECT PROD_CAT_CODE as Code, PROD_CAT_CODE + ' - ' + PROD_CAT_DESC as Description FROM PRODUCT_CATEGORY"

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
        End Select
        PCSQL &= " Where (INACTIVE_FLAG = 0 or INACTIVE_FLAG IS NULL) "
        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                PCSQL &= " AND " & strWhereClient
                If strWhereDivision <> "" Then
                    PCSQL &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        PCSQL &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If


        ds = oReport.GetDSfromSQL(PCSQL)
        Me.lstProdCat.DataSource = ds
        Me.lstProdCat.DataValueField = "Code"
        Me.lstProdCat.DataTextField = "Description"
        Me.lstProdCat.DataBind()


        'Jobs
        JobSQL = "	SELECT DISTINCT JOB_LOG.JOB_NUMBER as Code, str(JOB_LOG.JOB_NUMBER) + ' - ' + isnull(JOB_LOG.JOB_DESC, '') as Description FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER "
        strWhereClient = ""
        strWhereDivision = ""
        strWhereProduct = ""

        Dim sy As New cSecurity(Session("ConnString"))
        Try
            If sy.UserHasOfficeRestrictions(Session("EmpCode")) = True Then
                JobSQL &= " INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & Session("EmpCode") & "' "
            End If
            If sy.HasClientRestrictions(Session("UserCode")) = True Then
                JobSQL &= " INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE "
            End If
        Catch ex As Exception
        End Try

        Select Case Me.optCDP.SelectedValue
            Case "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    strWhereClient = "JOB_LOG.[CL_CODE] IN ("
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
                    strWhereClient = "JOB_LOG.[CL_CODE] IN ("
                    'Another misspelling that has always existed in previouse 1.x version of webv
                    'strWhereDivision = "[DIV_CODEe] IN ("
                    strWhereDivision = "JOB_LOG.[DIV_CODE] IN ("
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
                    strWhereClient = "JOB_LOG.[CL_CODE] IN ("
                    strWhereDivision = "JOB_LOG.[DIV_CODE] IN ("
                    strWhereProduct = "JOB_LOG.[PRD_CODE] IN ("
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
        End Select

        If CheckboxShowClosedJobs.Checked = True Then
            JobSQL &= " Where (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (0)) "
        Else
            JobSQL &= " Where (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (0,6,12)) "
        End If

        If sy.HasClientRestrictions(Session("UserCode")) = True Then
            JobSQL &= " AND SEC_CLIENT.USER_ID = '" & Session("UserCode") & "' AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) "
        End If

        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                JobSQL &= " AND " & strWhereClient
                If strWhereDivision <> "" Then
                    JobSQL &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        JobSQL &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If

        ds = oReport.GetDSfromSQL(JobSQL & " Order By JOB_LOG.JOB_NUMBER DESC")
        Me.lstJobNumber.DataSource = ds
        Me.lstJobNumber.DataValueField = "Code"
        Me.lstJobNumber.DataTextField = "Description"
        Me.lstJobNumber.DataBind()

    End Sub
    Private Function CreateCompareString() As String
        Dim ThisItem As RadListBoxItem
        Dim ReturnString As String
        Select Case Me.optCDP.SelectedValue
            Case "a"
                ReturnString = "a"
            Case "c"
                ReturnString = "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    For Each ThisItem In Me.lstClient.Items
                        If ThisItem.Selected = True Then
                            ReturnString &= ThisItem.Value
                        End If
                    Next
                End If
            Case "d"
                ReturnString = "d"
                If Not Me.lstDivision.SelectedItem Is Nothing Then
                    For Each ThisItem In Me.lstDivision.Items
                        If ThisItem.Selected = True Then
                            ReturnString &= ThisItem.Value
                        End If
                    Next

                End If

            Case "p"
                ReturnString = "p"
                If Not Me.lstProduct.SelectedItem Is Nothing Then
                    For Each ThisItem In Me.lstProduct.Items
                        If ThisItem.Selected = True Then
                            ReturnString &= ThisItem.Value
                        End If
                    Next
                End If
        End Select

        Return ReturnString

    End Function
    Private Sub InitDisplay()
        Dim ds As New DataSet

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory() & "DirectTime_Fields.xml", XmlReadMode.Auto)

        Me.RadListBoxDisplayAvailableFields.DataSource = ds.Tables(0).DefaultView
        Me.RadListBoxDisplayAvailableFields.DataTextField = "Description"
        Me.RadListBoxDisplayAvailableFields.DataValueField = "Name"
        Me.RadListBoxDisplayAvailableFields.DataBind()

    End Sub
    Private Sub optCDP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCDP.SelectedIndexChanged
        Select Case Me.optCDP.SelectedValue
            Case "a"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
            Case "c"
                Me.pnlClient.Visible = True
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = False
                Me.lstDivision.ClearSelection()
                Me.lstProduct.ClearSelection()
            Case "d"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = True
                Me.pnlProduct.Visible = False
                Me.lstClient.ClearSelection()
                Me.lstProduct.ClearSelection()
            Case "p"
                Me.pnlClient.Visible = False
                Me.pnlDivision.Visible = False
                Me.pnlProduct.Visible = True
                Me.lstClient.ClearSelection()
                Me.lstDivision.ClearSelection()
        End Select

    End Sub

#Region " Display Listboxes "

    Private Sub RadListBoxDisplayAvailableFields_Transferred(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxTransferredEventArgs) Handles RadListBoxDisplayAvailableFields.Transferred

        If e.SourceListBox.ID = Me.RadListBoxDisplayAvailableFields.ID And e.DestinationListBox.ID = Me.RadListBoxDisplayFieldsToDisplay.ID Then
            For Each item As Telerik.Web.UI.RadListBoxItem In e.Items
                Me.AddToRadListBoxSortAvailableFields(item)
            Next
        ElseIf e.SourceListBox.ID = Me.RadListBoxDisplayFieldsToDisplay.ID And e.DestinationListBox.ID = Me.RadListBoxDisplayAvailableFields.ID Then
            For Each item As Telerik.Web.UI.RadListBoxItem In e.Items
                Me.RemoveFromSorting(item)
                If Me.RadListBoxDisplayAvailableFields.FindItemByValue(item.Value) Is Nothing Then
                    Me.RadListBoxDisplayAvailableFields.Items.Add(item)
                End If
                If Not Me.RadListBoxDisplayFieldsToDisplay.FindItemByValue(item.Value) Is Nothing Then
                    Me.RadListBoxDisplayFieldsToDisplay.Items.Remove(item)
                End If
            Next
        End If

        If Me.chkSaveSettings.Checked = True Then
            SaveSettings()
        End If

    End Sub

#End Region

    'If Removing from "Fields to Display"
    Private Sub RemoveFromSorting(ByVal thisitem As RadListBoxItem)

        Dim RItem As RadListBoxItem

        'If it is in the available SORT fields, add 
        RItem = Me.RadListBoxSortAvailableFields.FindItemByValue(thisitem.Value)
        If Not RItem Is Nothing Then
            Me.RadListBoxSortAvailableFields.Items.Remove(RItem)
        End If

        RItem = Me.RadListBoxSortFieldsToSort.FindItemByValue(thisitem.Value)
        If Not RItem Is Nothing Then
            Me.RadListBoxSortFieldsToSort.Items.Remove(RItem)
        End If

    End Sub

    Private Sub AddToRadListBoxSortAvailableFields(ByVal ThisItem As RadListBoxItem)
        Me.RadListBoxSortAvailableFields.Items.Add(ThisItem)
    End Sub

    Private Sub butExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExport.Click
        Dim dtStart As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("3/31/1974 12:00:00 AM"))
        Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("6/6/2079 11:59:59 PM"))

        If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
            dtStart = Me.RadDatePickerStartDate.SelectedDate
        Else
            Me.ShowMessage("Invalid Start Date")
        End If
        If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
            dtEnd = Me.RadDatePickerEndDate.SelectedDate
        Else
            Me.ShowMessage("Invalid End Date")
        End If

        If Me.RadListBoxDisplayFieldsToDisplay.Items.Count = 0 Then
            Me.ShowMessage("Please choose fields to display")
            Exit Sub
        End If

        If Me.chkSaveSettings.Checked = True Then
            SaveSettings()
        End If

        Session("employeetimexl") = CreateSQL()

        Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
        Dim ds As DataSet
        ds = oReport.GetDSfromSQLDT(Session("employeetimexl"), dtStart, dtEnd)
        If ds.Tables(0).Rows.Count > 65536 Then
            Me.ShowMessage("Dataset is too large to export to excel")
            Exit Sub
        End If

        If ds.Tables(0).Rows.Count = 0 Then
            Me.ShowMessage("No records to display.")
            Exit Sub
        End If

        'MiscFN.ResponseRedirect("DirectTime_Render.aspx?sd=" & dtStart & "&ed=" & dtEnd)
        Dim Filename As String = "DIRECT_TIME_" & Session("EmpCode") & "_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)
        Filename = Filename.ToUpper()

        Session("directtimereport") = Me.RadComboBoxFormat.SelectedValue

        Me.DeliverGrid(ds.Tables(0), Filename)

    End Sub

    Private Function CreateSQL() As String
        Dim oSec As cSecurity = New cSecurity(CStr(Session("ConnString")))
        Dim strSQL As String
        Dim strWhereClient As String
        Dim strWhereDivision As String
        Dim strWhereProduct As String
        Dim ThisItem As RadListBoxItem
        Dim FirstPass As Boolean = False
        Dim strsplit As String() = Nothing

        strSQL = "Select "

        '****************************************************************************************
        '                          Field Selection
        '****************************************************************************************
        FirstPass = True
        For Each ThisItem In Me.RadListBoxDisplayFieldsToDisplay.Items
            Select Case ThisItem.Text
                Case "Hours", "Amount", "Mark Up/Down", "Resale Tax", "Total Amount", "Total Amount w/ Tax"
                    If FirstPass = True Then
                        strSQL &= "SUM([" & ThisItem.Text & "]) as [" & ThisItem.Text & "]"
                        FirstPass = False
                    Else
                        strSQL &= ", SUM([" & ThisItem.Text & "]) as [" & ThisItem.Text & "]"
                    End If
                Case "Date"
                    If FirstPass = True Then
                        strSQL &= "[" & ThisItem.Text & "] as Date"
                        FirstPass = False
                    Else
                        strSQL &= ", [" & ThisItem.Text & "] as Date"
                    End If
                Case Else
                    If FirstPass = True Then
                        strSQL &= "[" & ThisItem.Text & "]"
                        FirstPass = False
                    Else
                        strSQL &= ", [" & ThisItem.Text & "]"
                    End If
            End Select

        Next

        '****************************************************************************************
        '                          Tables
        '****************************************************************************************
        strSQL &= " FROM WV_TIMESHEET_REPORT "

        If oSec.HasClientRestrictions(Session("UserCode")) = True Then
            strSQL &= " INNER Join SEC_CLIENT ON WV_TIMESHEET_REPORT.[Client Code] = SEC_CLIENT.CL_CODE AND WV_TIMESHEET_REPORT.[Division Code] = SEC_CLIENT.DIV_CODE AND WV_TIMESHEET_REPORT.[Product Code] = SEC_CLIENT.PRD_CODE "
        End If
        If oSec.HasEmployeeRestrictions(Session("UserCode")) = True Then
            strSQL &= " Inner Join SEC_EMP ON WV_TIMESHEET_REPORT.[Employee Code] = SEC_EMP.EMP_CODE "
        End If
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList.Count > 0 Then
                strSQL &= " INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = WV_TIMESHEET_REPORT.[Job Office] AND EMP_OFFICE.EMP_CODE = '" & _Session.User.EmployeeCode & "'"
            End If
        End Using


        '****************************************************************************************
        '                          Date Range
        '****************************************************************************************
        strSQL &= " Where 1 = 1 AND [Hours] <> 0 AND (Date >= CAST(@Startdate AS VARCHAR) AND Date <= CAST (@Enddate AS VARCHAR)) "

        If oSec.HasClientRestrictions(Session("UserCode")) = True Then
            strSQL &= " AND SEC_CLIENT.USER_ID = '" & Session("UserCode") & "' AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) "
        End If
        If oSec.HasEmployeeRestrictions(Session("UserCode")) = True Then
            strSQL &= " AND SEC_EMP.USER_ID = '" & Session("UserCode") & "' "
        End If
        '****************************************************************************************
        '                          Client Division Product
        '****************************************************************************************
        Select Case Me.optCDP.SelectedValue
            Case "a"

            Case "c"
                If Not Me.lstClient.SelectedItem Is Nothing Then
                    strWhereClient = "[Client Code] IN ("
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
                    strWhereClient = "[Client Code] IN ("
                    strWhereDivision = "[Division Code] IN ("
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
                    strWhereClient = "[Client Code] IN ("
                    strWhereDivision = "[Division Code] IN ("
                    strWhereProduct = "[Product Code] IN ("
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
        End Select
        If strWhereClient <> "" Or strWhereDivision <> "" Or strWhereProduct <> "" Then
            If strWhereClient <> "" Then
                strSQL &= " AND " & strWhereClient
                If strWhereDivision <> "" Then
                    strSQL &= " AND " & strWhereDivision
                    If strWhereProduct <> "" Then
                        strSQL &= " AND " & strWhereProduct
                    End If
                End If
            End If
        End If

        '****************************************************************************************
        '                                Functions
        '****************************************************************************************
        If Not Me.lstFunctions.SelectedItem Is Nothing Then
            strSQL &= " AND [Function Code] IN ("
            FirstPass = True
            For Each ThisItem In Me.lstFunctions.Items
                If ThisItem.Selected = True Then
                    If FirstPass = True Then
                        strSQL &= "'" & ThisItem.Value & "'"
                        FirstPass = False
                    Else
                        strSQL &= ",'" & ThisItem.Value & "'"
                    End If
                End If
            Next
            strSQL &= ") "
        End If

        '****************************************************************************************
        '                                Employee
        '****************************************************************************************
        If Not Me.lstEmployee.SelectedItem Is Nothing Then
            strSQL &= " AND [Employee Code] IN ("
            FirstPass = True
            For Each ThisItem In Me.lstEmployee.Items
                If ThisItem.Selected = True Then
                    If FirstPass = True Then
                        strSQL &= "'" & ThisItem.Value & "'"
                        FirstPass = False
                    Else
                        strSQL &= ",'" & ThisItem.Value & "'"
                    End If
                End If
            Next
            strSQL &= ") "
        End If

        '****************************************************************************************
        '                                Job Number
        '****************************************************************************************
        If Not Me.lstJobNumber.SelectedItem Is Nothing Then
            strSQL &= " AND [Job Number] IN ("
            FirstPass = True
            For Each ThisItem In Me.lstJobNumber.Items
                If ThisItem.Selected = True Then
                    If FirstPass = True Then
                        strSQL &= "'" & ThisItem.Value & "'"
                        FirstPass = False
                    Else
                        strSQL &= ",'" & ThisItem.Value & "'"
                    End If
                End If
            Next
            strSQL &= ") "
        End If

        '****************************************************************************************
        '                                Product Category
        '****************************************************************************************
        If Not Me.lstProdCat.SelectedItem Is Nothing Then
            strSQL &= " AND [Product category Code] IN ("
            FirstPass = True
            For Each ThisItem In Me.lstProdCat.Items
                If ThisItem.Selected = True Then
                    If FirstPass = True Then
                        strSQL &= "'" & ThisItem.Value & "'"
                        FirstPass = False
                    Else
                        strSQL &= ",'" & ThisItem.Value & "'"
                    End If
                End If
            Next
            strSQL &= ") "
        End If

        '****************************************************************************************
        '                               Billable, Billed
        '****************************************************************************************
        Select Case Me.ddBillable.SelectedValue
            Case "b"
                strSQL &= " AND [Non Billable Flag] = 0"
            Case "n"
                strSQL &= " AND [Non Billable Flag] = 1"
        End Select
        Select Case Me.ddBilled.SelectedValue
            Case "b"
                strSQL &= " AND [Billed Flag] = 1"
            Case "n"
                strSQL &= " AND [Billed Flag] = 0"
        End Select


        '****************************************************************************************
        '                                Group By
        '****************************************************************************************

        FirstPass = True
        For Each ThisItem In Me.RadListBoxDisplayFieldsToDisplay.Items
            If (ThisItem.Text = "Hours" Or
                ThisItem.Text = "Amount" Or
                ThisItem.Text = "Mark Up/Down" Or
                ThisItem.Text = "Resale Tax" Or
                ThisItem.Text = "Total Amount" Or
                ThisItem.Text = "Total Amount w/ Tax") Then

            Else
                If FirstPass = True Then
                    strSQL &= " Group By "
                    strSQL &= "[" & ThisItem.Text & "]"
                    FirstPass = False
                Else
                    strSQL &= ", [" & ThisItem.Text & "]"
                End If
            End If
        Next
        '****************************************************************************************
        '                                Sorting
        '****************************************************************************************
        If Me.RadListBoxSortFieldsToSort.Items.Count > 0 Then
            strSQL &= " Order By "
            FirstPass = True
            For Each ThisItem In Me.RadListBoxSortFieldsToSort.Items
                If FirstPass = True Then
                    strSQL &= "[" & ThisItem.Text & "]"
                    FirstPass = False
                Else
                    strSQL &= ", [" & ThisItem.Text & "]"
                End If
            Next
        End If

        strSQL = strSQL.Replace("Group By  Order By", " Order By ")
        Return strSQL

    End Function

    Private Sub SaveSettings()
        Dim ThisItem As RadListBoxItem
        Dim ds As New DataSet
        Dim DR As DataRow

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory() & "DirectTime_Fields.xml", XmlReadMode.Auto)

        For Each DR In ds.Tables(0).Rows
            ThisItem = Nothing
            ThisItem = Me.RadListBoxDisplayFieldsToDisplay.FindItemByText(DR.Item("Description"))
            If ThisItem Is Nothing Then
                Response.Cookies("rptemployeetimedisplay")(DR.Item("Description")) = False
            Else
                Response.Cookies("rptemployeetimedisplay")(DR.Item("Description")) = True
                Response.Cookies("rptemployeetimedisplayorder")(DR.Item("Description")) = Me.RadListBoxDisplayFieldsToDisplay.FindItemByText(DR.Item("Description")).Index
            End If
            ThisItem = Me.RadListBoxSortFieldsToSort.FindItemByText(DR.Item("Description"))
            If ThisItem Is Nothing Then
                Response.Cookies("rptemployeetimesort")(DR.Item("Description")) = False
            Else
                Response.Cookies("rptemployeetimesort")(DR.Item("Description")) = True
            End If
        Next
        Response.Cookies("rptemployeetimedate")("startdate") = wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
        Response.Cookies("rptemployeetimedate")("enddate") = wvCDate(Me.RadDatePickerEndDate.SelectedDate).ToShortDateString
        Response.Cookies("rptemployeetimedisplay").Expires = Date.Now.AddDays(30)
        Response.Cookies("rptemployeetimesort").Expires = Date.Now.AddDays(30)
        Response.Cookies("rptemployeetimedate").Expires = Date.Now.AddDays(30)

    End Sub

    Private Sub LoadSettings()
        Dim ThisItem As RadListBoxItem
        Dim ds As New DataSet
        Dim DR As DataRow

        ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory() & "DirectTime_Fields.xml", XmlReadMode.Auto)
        Try
            For Each DR In ds.Tables(0).Rows
                If Request.Cookies("rptemployeetimedisplay")(DR.Item("Description")) = True Then
                    ThisItem = Me.RadListBoxDisplayAvailableFields.FindItemByText(DR.Item("Description"))
                    Me.RadListBoxDisplayFieldsToDisplay.Items.Add(ThisItem)
                    If Request.Cookies("rptemployeetimesort")(DR.Item("Description")) = True Then
                        Me.RadListBoxSortFieldsToSort.Items.Add(New RadListBoxItem(ThisItem.Text, ThisItem.Value))
                    Else
                        Me.RadListBoxSortAvailableFields.Items.Add(New RadListBoxItem(ThisItem.Text, ThisItem.Value))
                    End If
                End If
            Next
            Me.SortListBox(Me.RadListBoxDisplayFieldsToDisplay)
            Me.RadDatePickerStartDate.SelectedDate = wvCDate(Request.Cookies("rptemployeetimedate")("startdate")).ToShortDateString
            Me.RadDatePickerEndDate.SelectedDate = wvCDate(Request.Cookies("rptemployeetimedate")("enddate")).ToShortDateString
        Catch
        End Try

    End Sub

    Public Sub SortListBox(ByRef ThisListBox As Telerik.Web.UI.RadListBox)
        Try
            Dim OrderedList As New Telerik.Web.UI.RadListBoxItemCollection(ThisListBox)
            Dim ThisItem As RadListBoxItem
            Dim ds As New DataSet
            Dim DR As DataRow
            Dim order As Integer

            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory() & "DirectTime_Fields.xml", XmlReadMode.Auto)

            For Each DR In ds.Tables(0).Rows
                If Request.Cookies("rptemployeetimedisplay")(DR.Item("Description")) = True Then
                    ThisItem = Me.RadListBoxDisplayFieldsToDisplay.FindItemByText(DR.Item("Description"))
                    If Not Request.Cookies("rptemployeetimedisplayorder")(DR.Item("Description")) Is Nothing Then
                        order = Request.Cookies("rptemployeetimedisplayorder")(DR.Item("Description"))
                    End If
                    If order < OrderedList.Count Then
                        OrderedList.Insert(order, ThisItem)
                    Else
                        OrderedList.Add(ThisItem)
                    End If
                End If
            Next

            ThisListBox.Items.Clear()
            For Each ThisItem In OrderedList
                ThisListBox.Items.Add(ThisItem)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSaveSettings_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSaveSettings.CheckedChanged
        If Me.chkSaveSettings.Checked = True Then
            SaveSettings()
        End If
    End Sub

    Private Sub CheckboxShowClosedJobs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxShowClosedJobs.CheckedChanged
        Try
            Me.ChangeFilterSettings()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckboxShowTerminatedEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxShowTerminatedEmployees.CheckedChanged
        Try
            'Employee
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Me.lstEmployee.DataSource = oDD.GetEmployees(CStr(Session("UserCode")), Me.CheckboxShowTerminatedEmployees.Checked)
            Me.lstEmployee.DataTextField = "Description"
            Me.lstEmployee.DataValueField = "Code"
            Me.lstEmployee.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class
