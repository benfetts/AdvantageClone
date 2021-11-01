'Imports System.Data
'Imports System.Data.SqlClient
'Imports Webvantage.wvTimeSheet

Public Class Expense_V2
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected WithEvents ImageButton_EmployeeCodeLookup As System.Web.UI.WebControls.ImageButton
    Protected WithEvents RadComboBox_Month As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBox_Year As Telerik.Web.UI.RadComboBox
    Protected WithEvents TextBox_EmployeeCode As System.Web.UI.WebControls.TextBox

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub VendorCheck()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, Me.TextBox_EmployeeCode.Text.Trim) = False Then

                Me.RadToolbarExpense.Items.FindItemByValue("NewExpense").Enabled = False
                Me.ShowMessage("This employee code is not associated with a vendor code.")

            Else

                Me.RadToolbarExpense.Items.FindItemByValue("NewExpense").Enabled = True

            End If

        End Using

    End Sub
    Private Sub LoadMonth()

        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("01"), CStr("01")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("02"), CStr("02")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("03"), CStr("03")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("04"), CStr("04")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("05"), CStr("05")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("06"), CStr("06")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("07"), CStr("07")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("08"), CStr("08")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("09"), CStr("09")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("10"), CStr("10")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("11"), CStr("11")))
        Me.RadComboBox_Month.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("12"), CStr("12")))

        Me.RadComboBox_Month.SelectedValue = Now.ToString("MM")

    End Sub
    Private Sub LoadYear()

        Dim StartYear As Integer = Nothing
        Dim EndYear As Integer = Nothing
        Dim StartMonth As Integer = Nothing
        Dim EndMonth As Integer = Nothing

        AdvantageFramework.ExpenseReports.LoadAvailableDateRange(StartMonth, StartYear, EndMonth, EndYear)

        While StartYear <= EndYear

            Me.RadComboBox_Year.Items.Add(New Telerik.Web.UI.RadComboBoxItem(StartYear.ToString, StartYear.ToString))

            StartYear = StartYear + 1

        End While

        Me.RadComboBox_Year.SelectedValue = Now.Year.ToString

    End Sub
    Private Function ChangeUser() As String

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.TextBox_EmployeeCode.Text.Trim)

            If Employee IsNot Nothing Then

                Me.RadGridExpense.MasterTableView.Caption = "Employee:&nbsp;&nbsp;" & Employee.ToString

            End If

        End Using

    End Function
    Private Sub RefreshData()

        ChangeUser()
        ViewState("EmpCode") = Me.TextBox_EmployeeCode.Text.Trim
        RadGridExpense.Rebind()

    End Sub
    Private Sub CheckEmpStatus()

        'objects
        Dim cTimeSheet As Webvantage.wvTimeSheet.cTimeSheet = Nothing

        cTimeSheet = New Webvantage.wvTimeSheet.cTimeSheet(CStr(Session("ConnString")))

        If cTimeSheet.UserLimited(Session("UserCode")) = True Then

            Me.TextBox_EmployeeCode.Enabled = False
            Me.ImageButton_EmployeeCodeLookup.Visible = False

        End If

    End Sub
    Private Function ValidateEmployee(ByVal IncludeTerminated As Boolean) As Boolean

        'objects
        Dim ValidEmployee As Boolean = False
        Dim EmployeeCode As String = ""
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim Employeeoffice As System.Collections.Generic.List(Of String) = Nothing

        EmployeeCode = Me.TextBox_EmployeeCode.Text

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, _Session.UserCode)
                                Where Entity.Code = EmployeeCode
                                Select Entity).Single

                Catch ex As Exception
                    Employee = Nothing
                End Try

                If Employee IsNot Nothing Then

                    If IncludeTerminated = False Then

                        ValidEmployee = Not Employee.TerminationDate.HasValue

                    Else

                        ValidEmployee = True

                    End If

                    Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList

                    If Employeeoffice.Count > 0 And Employee.Code <> Session("EmpCode") Then

                        If Employeeoffice.Contains(Employee.OfficeCode) Then

                            ValidEmployee = True

                        Else

                            ValidEmployee = False

                        End If

                    End If

                End If





            End Using

        End Using

        ValidateEmployee = ValidEmployee

    End Function

#Region "  Form Event Handlers "

    Private Sub Expense2_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Me.TextBox_EmployeeCode = CType(Me.RadToolbarExpense.Items(1).FindControl("TextBox_EmployeeCode"), System.Web.UI.WebControls.TextBox)
        Me.ImageButton_EmployeeCodeLookup = CType(Me.RadToolbarExpense.Items(2).FindControl("ImageButton_EmployeeCodeLookup"), System.Web.UI.WebControls.ImageButton)
        Me.RadComboBox_Month = CType(Me.RadToolbarExpense.Items(4).FindControl("RadComboBox_Month"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBox_Year = CType(Me.RadToolbarExpense.Items(5).FindControl("RadComboBox_Year"), Telerik.Web.UI.RadComboBox)

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Page.IsPostBack = False Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)

            Me.TextBox_EmployeeCode.Text = Session("EmpCode")

            CheckEmpStatus()
            LoadMonth()
            LoadYear()

            Try

                If Request.QueryString("empcode") <> "" Then

                    Me.TextBox_EmployeeCode.Text = Request.QueryString("empcode")
                    Me.CheckEmployeeAccess(Me.TextBox_EmployeeCode.Text)

                End If

                If Request.QueryString("month") <> "" Then

                    Me.RadComboBox_Month.SelectedValue = Request.QueryString("month")

                End If

                If Request.QueryString("year") <> "" Then

                    Me.RadComboBox_Year.SelectedValue = Request.QueryString("year")

                End If

            Catch ex As Exception

            End Try

            Try

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                If qs.EmployeeCode <> "" Then

                    Me.TextBox_EmployeeCode.Text = qs.EmployeeCode
                    Me.CheckEmployeeAccess(Me.TextBox_EmployeeCode.Text)

                End If

                If qs.Month > 0 Then Me.RadComboBox_Month.SelectedValue = qs.Month.ToString().PadLeft(2, "0")
                If qs.Year > 0 Then Me.RadComboBox_Year.SelectedValue = qs.Year.ToString()

            Catch ex As Exception

            End Try

            Me.ImageButton_EmployeeCodeLookup.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=expempcode&control=" & Me.TextBox_EmployeeCode.ClientID & "&form=explookup');return false;")
            ViewState("EmpCode") = Me.TextBox_EmployeeCode.Text.Trim

            Me.RadToolbarExpense.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        Else

            If Me.HasAccessToEmployee(Me.TextBox_EmployeeCode.Text) = False Then

                Me.ShowMessage("You do not have access to this employee")

                Exit Sub

            End If

        End If

        ChangeUser()
        VendorCheck()

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridExpense_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridExpense.ItemCommand

        Select Case e.CommandName

            Case "ViewDetails"

                Me.OpenWindow("Expense Details", "expense_edit_v2.aspx?invoice=" & e.CommandArgument)

        End Select

    End Sub
    Private Sub RadGridExpense_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridExpense.ItemDataBound

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Classes.ExpenseReport
        Dim SubmittedToEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ApprovedByEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus
        Dim StatusDiv As HtmlControls.HtmlControl
        Dim StatusImage As System.Web.UI.WebControls.Image = Nothing
        Dim PaidDiv As System.Web.UI.HtmlControls.HtmlGenericControl = Nothing
        Dim ImageButtonPaid As System.Web.UI.WebControls.ImageButton = Nothing
        Dim AlternateText As String = Nothing
        Dim ToolTip As String = Nothing
        Dim ImageURL As String = Nothing
        Dim ImageButtonViewEdit As System.Web.UI.WebControls.ImageButton = Nothing
        Dim IsPaid As Boolean = False
        Dim EmployeeCode As String = Nothing
        Dim TooltipInfo As String = Nothing

        EmployeeCode = Me.TextBox_EmployeeCode.Text

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            e.Item.Cells(4).Text = LoGlo.FormatDate(e.Item.Cells(4).Text)

        End If

        For Each GridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpense.MasterTableView.Items

            Try

                ExpenseReport = DirectCast(GridDataItem.DataItem, AdvantageFramework.Database.Classes.ExpenseReport)

            Catch ex As Exception
                ExpenseReport = Nothing
            End Try

            If ExpenseReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport.Status.GetValueOrDefault(0), ExpenseReport.IsSubmitted.GetValueOrDefault(0), ExpenseReport.IsApproved.GetValueOrDefault(0))

                    Select Case ExpenseReportStatus

                        Case AdvantageFramework.ExpenseReports.ExpenseReportStatus.Approved,
                             AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedByApprover,
                             AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedInAccounting

                            AlternateText = "View Expense Report"
                            ToolTip = "View Expense Report"
                            ImageURL = "~/Images/Icons/White/256/magnifying_glass.png"

                        Case Else

                            AlternateText = "Edit Expense Report"
                            ToolTip = "Edit Expense Report"
                            ImageURL = "~/Images/Icons/White/256/edit.png"

                    End Select

                    ImageButtonViewEdit = GridDataItem.FindControl("ImageButtonViewEdit")

                    ImageButtonViewEdit.ImageUrl = ImageURL
                    ImageButtonViewEdit.AlternateText = AlternateText
                    ImageButtonViewEdit.ToolTip = ToolTip

                    StatusImage = CType(GridDataItem.FindControl("StatusImage"), System.Web.UI.WebControls.Image)
                    StatusDiv = CType(GridDataItem.FindControl("DivStatus"), HtmlControls.HtmlControl)

                    If StatusImage IsNot Nothing Then

                        If String.IsNullOrEmpty(ExpenseReport.SubmittedTo) = False Then

                            SubmittedToEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.SubmittedTo)

                        End If

                        If ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByAccounting OrElse
                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByApprover OrElse
                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Approved OrElse
                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedByApprover OrElse
                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedInAccounting Then

                            If String.IsNullOrWhiteSpace(ExpenseReport.ApprovedBy) = False Then

                                ApprovedByEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.ApprovedBy)

                            End If

                        End If

                        TooltipInfo = AdvantageFramework.ExpenseReports.LoadStatusTooltip(DbContext, ExpenseReport)

                        If Not String.IsNullOrWhiteSpace(TooltipInfo) Then

                            DirectCast(GridDataItem.FindControl("LabelStatusInfo"), Label).Text = TooltipInfo

                        Else

                            AdvantageFramework.Web.Presentation.Controls.DivHide(StatusDiv)

                        End If

                    End If

                    PaidDiv = CType(GridDataItem("TemplateColumn1").FindControl("paidDiv"), System.Web.UI.HtmlControls.HtmlGenericControl)
                    ImageButtonPaid = CType(GridDataItem("TemplateColumn1").FindControl("ImageButtonPaid"), System.Web.UI.WebControls.ImageButton)

                    If ExpenseReport.Paid Then

                        ImageButtonPaid.OnClientClick = Me.HookUpOpenWindow("Expense Edit", "Expense_Paid_Detail.aspx?Inv=" & ExpenseReport.InvoiceNumber.ToString & "&Emp=" & EmployeeCode)

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(PaidDiv)

                    End If

                End Using

            End If

        Next

    End Sub
    Private Sub RadGridExpense_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridExpense.NeedDataSource

        'objects
        Dim s As New cSecurity(Session("ConnString"))
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim ExpenseReports As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReport) = Nothing
        Dim ExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem) = Nothing
        Dim EmployeeCode As String = Nothing
        Dim StartDate As Date = Nothing
        Dim EndDate As Date = Nothing

        If Me.HasAccessToEmployee(Me.TextBox_EmployeeCode.Text) = False Then

            Exit Sub

        End If

        If Me.ValidateEmployee(True) = False Then

            Me.TextBox_EmployeeCode.Focus()
            Me.ShowMessage("Access to this employee (" & Me.TextBox_EmployeeCode.Text & ") is not allowed")
            Exit Sub

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EmployeeCode = Me.TextBox_EmployeeCode.Text.Trim
            StartDate = LoGlo.FirstOfMonth(Me.RadComboBox_Year.SelectedValue, Me.RadComboBox_Month.SelectedValue)
            EndDate = LoGlo.LastOfMonth(StartDate)

            Try

                ExpenseReports = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                  Where Entity.EmployeeCode = EmployeeCode AndAlso
                                        Entity.InvoiceDate >= StartDate AndAlso
                                        Entity.InvoiceDate <= EndDate
                                  Select Entity).ToList _
                                  .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)) _
                                  .OrderByDescending(Function(Entity) Entity.InvoiceNumber).ToList

            Catch ex As Exception
                ExpenseReports = New Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReport)
            End Try

            For Each ExpenseReport In ExpenseReports

                Try

                    ExpenseReportItems = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False)
                                          Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReportItem(Entity, ExpenseReport.EmployeeCode, DbContext)).ToList

                Catch ex As Exception
                    ExpenseReportItems = Nothing
                End Try

                Try

                    ExpenseReport.TotalAmount = (From Entity In ExpenseReportItems
                                                 Select Entity.Amount).Sum

                Catch ex As Exception

                End Try

                Try

                    ExpenseReport.TotalBillable = (From Entity In ExpenseReportItems
                                                   Where Entity.NonBillable = False
                                                   Select Entity.Amount).Sum

                Catch ex As Exception

                End Try

                Try

                    ExpenseReport.TotalNonBillable = (From Entity In ExpenseReportItems
                                                      Where Entity.NonBillable = True
                                                      Select Entity.Amount).Sum

                Catch ex As Exception

                End Try

            Next

        End Using

        Try

            RadGridExpense.DataSource = ExpenseReports

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadComboBox_Month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBox_Month.SelectedIndexChanged

        RefreshData()

    End Sub
    Private Sub RadComboBox_Year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBox_Year.SelectedIndexChanged

        RefreshData()

    End Sub
    Private Sub RadToolbarExpense_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarExpense.ButtonClick

        'objects
        Dim EmployeeCode As String = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        EmployeeCode = Me.TextBox_EmployeeCode.Text

        If ValidateEmployee(True) = False Then

            Me.TextBox_EmployeeCode.Focus()
            Me.ShowMessage("Access to this employee (" & EmployeeCode & ") is not allowed")

        Else

            Select Case e.Item.Value

                Case "Refresh"

                    RefreshData()

                Case "NewExpense"

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.TerminationDate.HasValue Then

                                Me.ShowMessage("You cannot create expense reports for terminated employees.")

                            ElseIf AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, Employee.Code) Then

                                Me.OpenWindow("New Expense Report", "Expense_Edit_V2.aspx?invoice=new&empcode=" & Employee.Code)

                            Else

                                RadGridExpense.Rebind()

                            End If

                        Else

                            RadGridExpense.Rebind()

                        End If

                    End Using

                Case "Bookmark"

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                            Dim qs As New AdvantageFramework.Web.QueryString()
                            Dim emp As New cEmployee(Session("ConnString"))

                            qs = qs.FromCurrent()
                            'qs.Month = CType(Me.RadComboBox_Month.SelectedValue, Integer)
                            'qs.Year = CType(Me.RadComboBox_Year.SelectedValue, Integer)
                            qs.EmployeeCode = EmployeeCode
                            qs.IsBookmark = True

                            With b

                                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports
                                .UserCode = Session("UserCode")
                                .Name = "Expense Reports for " & Employee.FirstName & " " & Employee.LastName '& " (" & Microsoft.VisualBasic.MonthName(CType(Me.RadComboBox_Month.SelectedValue, Integer)) & ", " & Me.RadComboBox_Year.SelectedValue.ToString() & ")"
                                .PageURL = qs.ToString(True)

                            End With

                            Dim s As String = ""
                            If BmMethods.SaveBookmark(b, s) = False Then

                                Me.ShowMessage(s)

                            Else

                                Me.RefreshBookmarksDesktopObject()

                            End If

                        End If

                    End Using

            End Select

        End If

    End Sub

    Private Sub TextBox_EmployeeCode_TextChanged(sender As Object, e As EventArgs) Handles TextBox_EmployeeCode.TextChanged
        Try
            RefreshData()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
