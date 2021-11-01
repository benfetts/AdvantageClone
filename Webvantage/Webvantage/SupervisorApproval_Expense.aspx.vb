Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Telerik.Web.UI
Imports Webvantage.cGlobals

Partial Public Class SupervisorApproval_Expense
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Protected WithEvents DropMarkAllINSTR As Telerik.Web.UI.RadComboBox

#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False
        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts, False))

        Try

            RadGridExpenseApproval.Columns.FindByUniqueName("DocumentLink").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("bm") Is Nothing Then
            Me.PageTitle = "Expense Approval"
        End If

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseApproval)

        Me.DropMarkAllINSTR = CType(Me.RadToolbarSuperAppr.FindItemByValue("RadToolbarButtonDropMarkAllINSTR").FindControl("DropMarkAllINSTR"), Telerik.Web.UI.RadComboBox)

        If Not Me.IsPostBack Then

            If Request.QueryString("sedate") <> "" Then
                Dim startEndDate As Date
                startEndDate = CType(Request.QueryString("sedate"), Date)
                Me.RadDatePickerStartDate.SelectedDate = startEndDate.AddDays(-60)
                Me.RadDatePickerEndDate.SelectedDate = startEndDate.AddDays(30)
            Else
                Dim startDate, endDate As String
                Dim oAppVars As New cAppVars(cAppVars.Application.SUPR_APPR_EXP)
                oAppVars.getAllAppVars()
                If oAppVars.getAppVar("StartDate") <> "" Then
                    startDate = CDate(LoGlo.FormatDate(oAppVars.getAppVar("StartDate")))
                End If
                If oAppVars.getAppVar("EndDate") <> "" Then
                    endDate = CDate(LoGlo.FormatDate(oAppVars.getAppVar("EndDate")))
                End If
                If startDate <> "" Then
                    Me.RadDatePickerStartDate.SelectedDate = startDate
                    Me.RadDatePickerEndDate.SelectedDate = endDate
                End If
            End If

            Session("STARTDATE_SuperApprExp") = Me.RadDatePickerStartDate.SelectedDate
            Session("ENDDATE_SuperApprExp") = Me.RadDatePickerEndDate.SelectedDate

            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            With Me.ddEmployee
                .DataSource = oDD.GetEmployeesBySupervisor(Session("UserCode"), Session("EmpCode"), "exp")
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
            End With

            Dim empCode As String
            empCode = Request.QueryString("empcode")
            If empCode <> "" Then
                ddEmployee.Text = empCode
            End If

            If empCode <> "" And Request.QueryString("sedate") <> "" Then
                RadGridExpenseApproval.Rebind()
            End If

            Me.RadDatePickerStartDate.DateInput.Focus()


        Else
            Select Case Me.EventArgument
                Case "Search"
                    RadGridExpenseApproval.Rebind()
                Case "Save"
                    SaveGrid()
            End Select
        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ChkApproved_CheckedChanged(sender As Object, e As EventArgs) Handles ChkApproved.CheckedChanged

        Me.Search()

    End Sub
    Private Sub ChkDenied_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDenied.CheckedChanged

        Me.Search()

    End Sub
    Private Sub ChkPending_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPending.CheckedChanged

        Me.Search()

    End Sub
    Private Sub ddEmployee_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddEmployee.SelectedIndexChanged

        Me.Search()

    End Sub
    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged

        Me.Search()

    End Sub
    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        Me.Search()

    End Sub

    Private Sub RadGridExpenseApproval_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridExpenseApproval.DetailTableDataBind
        Try
            Dim dataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)
            Dim oSQL As SqlHelper
            Dim dt As DataTable
            Dim arParams(0) As SqlParameter
            Dim INV_NBR As Integer = dataItem.GetDataKeyValue("INV_NBR")

            Dim parameterETID As New SqlParameter("@INV_NBR", SqlDbType.Int)
            parameterETID.Value = INV_NBR
            arParams(0) = parameterETID

            Try
                dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_get_super_appr_expense_dtl", "", arParams)
            Catch
                Err.Raise(Err.Number, "Class:SupervisorApproval Routine:RadGridExpenseApproval_DetailTableDataBind", Err.Description)
            End Try

            e.DetailTableView.DataSource = dt

        Catch ex As Exception

        End Try


    End Sub
    Private Sub RadGridExpenseApproval_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridExpenseApproval.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Try
            Select Case e.CommandName
                Case "ShowComments"
                    Dim strURL As String = "popcomments.aspx?Type=SuperApprExpense&ID=" & e.CommandArgument
                    Me.OpenWindow("", strURL)
                Case "ShowDocs"
                    Dim DocCount As Int16 = getInvDocCount(e.CommandArgument)
                    If DocCount > 0 Then
                        ViewDocs(e.CommandArgument.ToString())
                    End If
                Case "ViewDocs"
                    Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
                    Dim ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object) = Nothing
                    Dim DataSource As Object = Nothing
                    Dim URL As String = Nothing
                    Dim InvoiceNumber As Integer = Nothing

                    InvoiceNumber = e.CommandArgument

                    ParameterDictionary = New System.Collections.Generic.Dictionary(Of String, Object)

                    ParameterDictionary.Add("InvoiceNumbers", {InvoiceNumber})
                    ParameterDictionary.Add("PrintApproverName", False)
                    ParameterDictionary.Add("ExcludeEmployeeSignature", False)
                    ParameterDictionary.Add("IncludeReceipts", True)
                    ParameterDictionary.Add("IncludeReport", False)

                    Session("Report_ParameterDictionary") = ParameterDictionary

                    Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport

                    URL = "Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & ""

                    Me.OpenWindow("", URL)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridExpenseApproval_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridExpenseApproval.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            'Header level rows
            Try
                Dim DDStatus As Telerik.Web.UI.RadComboBox = DirectCast(e.Item.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                Dim LabelPendingInAccounting As System.Web.UI.WebControls.Label = DirectCast(e.Item.FindControl("LabelPendingInAccounting"), System.Web.UI.WebControls.Label)
                Dim TBapprNotes As System.Web.UI.WebControls.TextBox = DirectCast(e.Item.FindControl("TxtAPPR_NOTES"), TextBox)
                Dim status As Integer = e.Item.DataItem("STATUS")
                Dim approved As Int16 = e.Item.DataItem("APPROVED_FLAG")
                Dim DocCount As Int16 = e.Item.DataItem("DOC_COUNT")

                If status = 4 Then 'pending approval in accounting

                    DDStatus.Visible = False
                    LabelPendingInAccounting.Visible = True

                ElseIf status = 2 And approved = 2 Then 'Already approved by accounting, disable edit
                    DDStatus.Enabled = False
                    TBapprNotes.Enabled = False
                Else
                    MiscFN.RadComboBoxSetIndex(DDStatus, approved, False)
                    MiscFN.LimitTextbox(TBapprNotes, 254)
                    'MiscFN.RadComboBoxSetIndex(CType(e.Item.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox), e.Item.DataItem("APPROVED_FLAG"), False)
                    'MiscFN.LimitTextbox(CType(e.Item.FindControl("TxtAPPR_NOTES"), TextBox), 254)
                End If

                Dim DocumentsDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDocuments")
                Dim ViewDocumentsDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivViewDocuments")
                If DocCount = 0 Then

                    AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsDiv)
                    AdvantageFramework.Web.Presentation.Controls.DivHide(ViewDocumentsDiv)

                End If


                e.Item.Cells(5).Text = LoGlo.FormatDate(e.Item.Cells(5).Text)
            Catch ex As Exception
            End Try

            'Detail level rows
            Try
                'Credit Card 
                'Dim cb As CheckBox = DirectCast(e.Item.FindControl("CCFLAG"), CheckBox)
                'cb.Checked = True   'e.Item.DataItem("CC_FLAG")
                Dim cc As Boolean = e.Item.DataItem("CC_FLAG")

                'Dim myCC As System.Web.UI.WebControls.Image
                '    Dim myCCSpacer As System.Web.UI.WebControls.Image

                'myCC = e.Item.FindControl("CC")
                'myCCSpacer = e.Item.FindControl("ImgSpacerCC")

                'If cc = True Then
                '    myCC.Visible = True
                '    myCCSpacer.Visible = False
                'Else
                '    myCC.Visible = False
                '    myCCSpacer.Visible = True
                'End If


                'NonBillable
                'Dim myCCBillable As System.Web.UI.WebControls.Image
                'Dim myCCBillableSpacer As System.Web.UI.WebControls.Image
                Dim myemp As String = ""
                Dim myfnc As String
                Dim mycl As String
                Dim mydiv As String
                Dim myprd As String
                Dim myjob As String
                Dim mycomp As String
                Dim myjob_int, mycomp_int As Integer

                'myCCBillable = e.Item.FindControl("CCBillable")
                'myCCBillableSpacer = e.Item.FindControl("ImgSpacerNonBillable")
                myfnc = e.Item.DataItem("FNC_CODE")
                myjob = e.Item.DataItem("JOB_NBR")
                mycomp = e.Item.DataItem("JOB_COMP_NBR")

                If myjob.Length > 0 Then
                    myjob_int = CType(myjob, Integer)
                    mycomp_int = CType(mycomp, Integer)
                Else
                    myjob_int = 0
                    mycomp_int = 0
                End If

                Dim oJobFunctions As cJobFunctions = New cJobFunctions(Session("ConnString"))
                oJobFunctions.GetCliDivProdFromJob(myjob_int, mycomp_int, mycl, mydiv, myprd)

                Dim isBillable As Boolean = oJobFunctions.IsJobBillable(myemp, myfnc, mycl, mydiv, myprd, myjob_int, mycomp_int)
                Dim CCBillableDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCCBillable")
                If isBillable = True Then

                    'myCCBillable.Visible = False
                    'myCCBillableSpacer.Visible = True
                    AdvantageFramework.Web.Presentation.Controls.DivHide(CCBillableDiv)

                Else

                    'myCCBillable.Visible = True
                    'myCCBillableSpacer.Visible = False

                End If

                e.Item.Cells(2).Text = LoGlo.FormatDate(e.Item.Cells(2).Text)

            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub RadGridExpenseApproval_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridExpenseApproval.NeedDataSource
        Try
            If validateData() = 1 Then
                Dim oSQL As SqlHelper
                Dim dt As DataTable
                Dim arParams(7) As SqlParameter
                Dim checked As Boolean
                Dim emp As String = ""

                Dim parmeterUserID As New SqlParameter("@user_id", SqlDbType.VarChar, 100)
                parmeterUserID.Value = Session("UserCode")
                arParams(0) = parmeterUserID

                Dim parmetersuperCode As New SqlParameter("@superCode", SqlDbType.VarChar, 6)
                parmetersuperCode.Value = Session("EmpCode")
                arParams(1) = parmetersuperCode

                Dim parameterEmpCode As New SqlParameter("@emp_code", SqlDbType.VarChar, 6)
                emp = Me.ddEmployee.SelectedValue
                If emp = "All" Then
                    emp = ""
                End If
                parameterEmpCode.Value = emp
                arParams(2) = parameterEmpCode

                Dim parameterStart As New SqlParameter("@start_date", SqlDbType.SmallDateTime)
                parameterStart.Value = Me.RadDatePickerStartDate.SelectedDate
                arParams(3) = parameterStart

                Dim parameterEnd As New SqlParameter("@end_date", SqlDbType.SmallDateTime)
                parameterEnd.Value = Me.RadDatePickerEndDate.SelectedDate
                arParams(4) = parameterEnd

                Dim parameterPending As New SqlParameter("@PENDING", SqlDbType.Int)
                If Me.ChkPending.Checked = True Then
                    parameterPending.Value = 1
                Else
                    parameterPending.Value = 0
                End If
                arParams(5) = parameterPending

                Dim parameterDenied As New SqlParameter("@DENIED", SqlDbType.Int)
                If Me.ChkDenied.Checked = True Then
                    parameterDenied.Value = 1
                Else
                    parameterDenied.Value = 0
                End If
                arParams(6) = parameterDenied

                Dim parameterApproved As New SqlParameter("@APPROVED", SqlDbType.Int)
                If Me.ChkApproved.Checked = True Then
                    parameterApproved.Value = 1
                Else
                    parameterApproved.Value = 0
                End If
                arParams(7) = parameterApproved


                Try
                    dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_get_super_appr_expense_hdr", "", arParams)
                Catch
                    Err.Raise(Err.Number, "Class:SupervisorApprovalExpense Routine:LoadGrid", Err.Description)
                End Try


                Me.RadGridExpenseApproval.DataSource = dt

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadToolbarSuperAppr_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSuperAppr.ButtonClick
        Select Case e.Item.Value
            Case "Search"
                Me.Search()
            Case "Save"
                SaveGrid()
                RadGridExpenseApproval.Rebind()

                Dim tlbrButton As Telerik.Web.UI.RadToolBarButton = CType(Me.RadToolbarSuperAppr.FindItemByValue("Expand"), Telerik.Web.UI.RadToolBarButton)
                tlbrButton.Text = "Expand"
                tlbrButton.ToolTip = "Expand"

            Case "Alert"
                SendAlerts()

            Case "MarkAll" 'Approved/Pending/Denied
                MarkAll()

            Case "MarkChecked"
                MarkChecked()

            Case "Print"

            Case "Expand"
                Dim expanded As Boolean
                Dim tlbrButton As Telerik.Web.UI.RadToolBarButton = CType(Me.RadToolbarSuperAppr.FindItemByValue("Expand"), Telerik.Web.UI.RadToolBarButton)

                If tlbrButton.Text = "Expand" Then
                    tlbrButton.Text = "Collapse"
                    tlbrButton.ToolTip = "Collapse"
                    expanded = True
                Else
                    tlbrButton.Text = "Expand"
                    tlbrButton.ToolTip = "Expand"
                    expanded = False
                End If

                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseApproval.MasterTableView.Items
                    gridDataItem.Expanded = expanded
                Next
            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "SupervisorApproval_Expense.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseApproval
                    .UserCode = Session("UserCode")
                    .Name = "Expense Approval"
                    .Description = "Expense Approval"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If
        End Select

    End Sub

#End Region

#Region " Methods "

    Private Function getInvDocCount(ByVal invNbr As Integer) As Integer
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim ct As Integer

        SQL_STRING = " SELECT  COUNT(*) FROM EXPENSE_DOCS WHERE INV_NBR = " + CStr(invNbr)

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:SuperApprExpense.ascx Routine:getInvDocCount", Err.Description)
        End Try

        ct = 0
        If dr.HasRows Then
            dr.Read()
            ct = dr.GetInt32(0)
        End If

        Return ct
    End Function
    Private Sub MarkAll()
        Dim RowCount As Integer = Me.RadGridExpenseApproval.MasterTableView.Items.Count
        Dim MarkValue As String
        Dim checked As Boolean

        MarkValue = DropMarkAllINSTR.SelectedValue

        For i As Integer = 0 To RowCount - 1
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridExpenseApproval.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

            If CurrentGridRow.ItemType = GridItemType.Item Or CurrentGridRow.ItemType = GridItemType.AlternatingItem Then

                Try

                    Dim status As Integer = CType(CurrentGridRow.GetDataKeyValue("STATUS"), Integer)
                    Dim approved As Int16 = CType(CurrentGridRow.GetDataKeyValue("APPROVED_FLAG"), Int16)

                    If status = 4 Then
                        'pending approval in accounting, do nothing
                    ElseIf status = 2 And approved = 2 Then
                        'Approved by accounting, do nothing
                    Else
                        Dim dropdwn As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                        dropdwn.SelectedValue = MarkValue
                    End If

                Catch ex As Exception

                End Try

            End If


        Next
    End Sub
    Private Sub MarkChecked()
        Dim MarkValue As String
        Dim checked As Boolean
        Dim idx As Integer = 0

        MarkValue = DropMarkAllINSTR.SelectedValue

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseApproval.MasterTableView.Items

            If gridDataItem.ItemType = GridItemType.Item Or gridDataItem.ItemType = GridItemType.AlternatingItem Then

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridExpenseApproval.MasterTableView.Items(idx), Telerik.Web.UI.GridDataItem)

                Dim status As Integer = CType(CurrentGridRow.GetDataKeyValue("STATUS"), Integer)
                Dim approved As Int16 = CType(CurrentGridRow.GetDataKeyValue("APPROVED_FLAG"), Int16)

                If status = 4 Then
                    'pending approval in accounting, do nothing
                ElseIf status = 2 And approved = 2 Then
                    'Approved by accounting, do nothing
                Else
                    Dim chkbx As CheckBox = CType(gridDataItem("ColumnSelect").Controls(0), CheckBox)

                    If chkbx.Checked Then
                        Dim dropdwn As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                        dropdwn.SelectedValue = MarkValue
                    End If

                End If

                idx += 1

            End If


        Next

    End Sub
    Private Sub SaveGrid(Optional ByVal RebindGrid As Boolean = True, Optional ByVal SaveUserRows As Boolean = True)

        Dim INV_NBR, appr_flag As Integer
        Dim ApprNotes, status As String
        Dim sql As String
        Dim RowCount As Integer = Me.RadGridExpenseApproval.MasterTableView.Items.Count

        If RowCount > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

                For i As Integer = 0 To RowCount - 1

                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridExpenseApproval.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

                    If CurrentGridRow IsNot Nothing Then

                        Dim ddstatus As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                        ExpenseHeader = Nothing

                        'status - 0-Pending, 1-Denied, 2-Approved
                        If ddstatus IsNot Nothing Then status = ddstatus.SelectedValue

                        If IsNumeric(status) = True Then appr_flag = CInt(status)

                        Try

                            INV_NBR = CType(CurrentGridRow.GetDataKeyValue("INV_NBR"), Integer)

                        Catch ex As Exception
                            INV_NBR = -1
                        End Try

                        If INV_NBR > 0 Then

                            Try

                                ApprNotes = DirectCast(CurrentGridRow.FindControl("TxtAPPR_NOTES"), TextBox).Text

                            Catch ex As Exception
                            End Try

                            ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, INV_NBR)

                            If ExpenseHeader IsNot Nothing Then

                                ExpenseHeader.ApproverNotes = ApprNotes
                                ExpenseHeader.IsApproved = appr_flag

                                If appr_flag = 2 Then

                                    ExpenseHeader.ApprovedBy = Session("EmpCode")
                                    ExpenseHeader.ApprovedDate = cEmployee.TimeZoneToday

                                Else

                                    ExpenseHeader.ApprovedBy = String.Empty
                                    ExpenseHeader.ApprovedDate = Nothing

                                End If

                                AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseHeader)

                            End If

                        End If

                    End If

                Next

            End Using

        End If

    End Sub
    Private Sub Search()

        Me.RadGridExpenseApproval.Rebind()

        Try

            Dim tlbrButton As Telerik.Web.UI.RadToolBarButton = CType(Me.RadToolbarSuperAppr.FindItemByValue("Expand"), Telerik.Web.UI.RadToolBarButton)
            tlbrButton.Text = "Expand"
            tlbrButton.ToolTip = "Expand"

        Catch ex As Exception
        End Try

    End Sub
    Private Sub SendAlerts()
        'Dim Alert As New Alert(Session("ConnString"))
        Dim NowDate As Date = Now
        Dim DateDate As Date
        Dim url, ApprNotes As String
        Dim RowCount As Integer = Me.RadGridExpenseApproval.MasterTableView.Items.Count
        Dim MarkValue As String
        Dim checked As Boolean
        Dim idx As Integer = 0
        Dim empCode, empName, DateStr, status, invnbr As String

        SaveGrid()

        url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseApproval.MasterTableView.Items

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridExpenseApproval.MasterTableView.Items(idx), Telerik.Web.UI.GridDataItem)
                Dim chkbx As CheckBox = CType(gridDataItem("ColumnSelect").Controls(0), CheckBox)

                If chkbx.Checked Then

                    Dim FxAlert As New AdvantageFramework.Database.Entities.Alert

                    invnbr = CurrentGridRow("INV_NBR").Text
                    empCode = gridDataItem.GetDataKeyValue("EMP_CODE")
                    empName = CurrentGridRow("EMPLOYEE").Text
                    ApprNotes = DirectCast(CurrentGridRow.FindControl("TxtAPPR_NOTES"), TextBox).Text
                    DateStr = CurrentGridRow("INV_DATE").Text
                    DateDate = CType(DateStr, Date)

                    Dim dropdwn As Telerik.Web.UI.RadComboBox = DirectCast(CurrentGridRow.FindControl("DDSTATUS"), Telerik.Web.UI.RadComboBox)
                    status = dropdwn.SelectedValue
                    Select Case status
                        Case "2"
                            status = "Approved"
                        Case "0"
                            status = "Pending"
                        Case "1"
                            status = "Denied"
                    End Select

                    With FxAlert

                        .AlertTypeID = 3
                        .AlertCategoryID = 46
                        .Subject = "Expense Report Approval Updated! (" & DateStr & ") - Status: " & status
                        .Body = "<a href='" & url & "/Expense_Edit.aspx?invoice=" & invnbr & " '> Link to Expense Report for " & empName & " (" & DateDate.ToString("d") & ").</a><br /><br />" & ApprNotes
                        .EmailBody = .Body
                        .GeneratedDate = NowDate
                        .LastUpdated = .GeneratedDate
                        .PriorityLevel = 3
                        .EmployeeCode = Session("EmpCode")
                        .UserCode = Session("UserCode")

                    End With

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        Dim Alert As New Alert(Session("ConnString"))
                        Alert.LoadByPrimaryKey(FxAlert.ID)
                        Alert.AddAlertRecipient(empCode)
                        SendEmailAlert(Alert.ALERT_ID, ApprNotes)

                    Else

                        Me.ShowMessage("Alert failed to save")

                    End If


                End If

                idx += 1

            Next

        End Using

    End Sub
    Private Function SendEmailAlert(ByVal AlertID As Integer, Optional ByVal comment As String = "") As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"), _
                                              HttpContext.Current.Session("UserCode"), _
                                              Me._Session, _
                                              HttpContext.Current.Session("WebvantageURL"), _
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .AppName = "SupervisorApproval"
                .SupervisorApprovalComment = comment
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Alert Email not Sent.  " & ex.Message.ToString())
            SendEmailAlert = False

        End Try
    End Function
    Private Function validateData() As Integer
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Dim startDateStr, endDateStr As String
        Dim startDate, endDate As DateTime

        If Me.ChkApproved.Checked = False And Me.ChkPending.Checked = False And Me.ChkDenied.Checked = False Then
            Me.ShowMessage("Please select at least 1 Approval Status.")
            Return -1
        End If

        Try
            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True Then
                startDateStr = Me.RadDatePickerEndDate.SelectedDate
            Else
                startDateStr = ""
            End If
        Catch ex As Exception
            startDateStr = ""
        End Try

        Try
            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                endDateStr = Me.RadDatePickerEndDate.SelectedDate
            Else
                endDateStr = ""
            End If
        Catch ex As Exception
            endDateStr = ""
        End Try

        If startDateStr.Length > 0 Then
            If startDateStr = Nothing Or startDateStr = "" Or cGlobals.wvIsDate(startDateStr) = False Then
                Me.ShowMessage("Please enter valid Start Date.")
                Return -1
            Else
                startDate = wvCDate(startDateStr)
            End If

            If endDateStr = Nothing Or endDateStr = "" Or cGlobals.wvIsDate(endDateStr) = False Then
                Me.ShowMessage("Please enter valid End Date.")
                Return -1
            Else
                endDate = wvCDate(endDateStr)
            End If

            Dim dtStart As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("1/1/1900 12:00:00 AM"))
            Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("12/31/2100 11:59:59 PM"))

            If startDate < dtStart Or startDate > dtEnd Then
                Me.ShowMessage("Start Date is invalid.")
                Return -1
            End If
            If endDate < dtStart Or endDate > dtEnd Then
                Me.ShowMessage("End Date is invalid.")
                Return -1
            End If

            If startDate > endDate Then
                Me.ShowMessage("End Date must be greater than Start Date")
                Me.RadDatePickerStartDate.SelectedDate = Session("STARTDATE_SuperApprExp")
                Me.RadDatePickerEndDate.SelectedDate = Session("ENDDATE_SuperApprExp")
                Return -1
            End If

            Session("STARTDATE_SuperApprExp") = startDate
            Session("ENDDATE_SuperApprExp") = endDate

            'Save Start/End date range to DB
            Dim oAppVars As New cAppVars(cAppVars.Application.SUPR_APPR_EXP)
            startDate = Me.RadDatePickerStartDate.SelectedDate
            endDate = Me.RadDatePickerEndDate.SelectedDate
            oAppVars.setAppVarDB("StartDate", startDate)
            oAppVars.setAppVarDB("EndDate", endDate)
        End If

        Return 1

    End Function
    Private Sub ViewDocs(ByVal inv As String)
        Dim strURL As String
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

        strURL = "Documents_List.aspx?invNbr=" & inv & "&DocPopupType=expense"
        Me.OpenWindow("Receipts", strURL, 900, 300, False)
        'strBuilder.Append("<script language='javascript'>")
        'strBuilder.Append("window.open('" & strURL & "', 'ViewReceipts', 'screenX=150,left=150,screenY=150,top=150,width=900,height=300,scrollbars=yes,resizable=yes,menubar=no,maximazable=no')")
        'strBuilder.Append("</script>")
        'Dim str2 As String = strBuilder.ToString
        'Page.RegisterStartupScript("SuperApprExDocs", strBuilder.ToString())

    End Sub

#End Region

End Class
