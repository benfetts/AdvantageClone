Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

Partial Public Class Expense_Edit_V2
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim _pers As PageStatePersister
    Public mstatusCalc As ExpenseStatusCalculated
    Private _InvoiceNumber As Integer = 0
    Public _ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing
    Public _WebvantageExpenseStatus As Webvantage.ExpenseStatus = Nothing
    Private Property CurrentGridPageIndex As Integer = 0

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadExpense()

        LoadExpenseReport()
        LoadExpenseItems()

    End Sub
    Private Sub LoadExpenseReport()

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim SubmittedToEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ApprovedByEmployee As AdvantageFramework.Database.Views.Employee = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    CheckEmployeeAccess(ExpenseReport.EmployeeCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                    _ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)

                    If _ExpenseReportStatus <> AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                        RadGridExpenseItems.MasterTableView.GetColumn("GridTemplateColumnSave").Visible = False
                        RadGridExpenseItems.MasterTableView.GetColumn("GridTemplateColumnCopy").Visible = False
                        RadGridExpenseItems.MasterTableView.GetColumn("GridTemplateColumnDelete").Visible = False

                    End If

                    If String.IsNullOrEmpty(ExpenseReport.SubmittedTo) = False Then

                        SubmittedToEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.SubmittedTo)

                    End If

                    If _ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByAccounting OrElse
                        _ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByApprover OrElse
                        _ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Approved OrElse
                        _ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedByApprover OrElse
                        _ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedInAccounting Then

                        If String.IsNullOrWhiteSpace(ExpenseReport.ApprovedBy) = False Then

                            ApprovedByEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.ApprovedBy)

                        End If

                    End If

                    LabelStatusInfo.Text = AdvantageFramework.ExpenseReports.LoadStatusTooltip(DbContext, ExpenseReport)

                    If Not String.IsNullOrWhiteSpace(LabelStatusInfo.Text) Then

                        Image_Status.Visible = True
                        Image_Status.ImageUrl = "Images/information-trans.png"

                    Else

                        Image_Status.Visible = False

                    End If

                    Label_Approval.Text = AdvantageFramework.StringUtilities.GetNameAsWords(_ExpenseReportStatus.ToString)
                    Label_InvoiceNumber.Text = ExpenseReport.InvoiceNumber
                    Label_EmployeeCode.Text = ExpenseReport.EmployeeCode
                    Label_EmployeeName.Text = Employee.ToString
                    Label_Status.Text = AdvantageFramework.StringUtilities.GetNameAsWords(_ExpenseReportStatus.ToString)
                    Label_VendorCode.Text = ExpenseReport.VendorCode
                    RadTextBox_ExpenseDetailDescription.Text = ExpenseReport.Details
                    TextBox_ExpenseDescription.Text = ExpenseReport.Description

                    If ExpenseReport.InvoiceDate.HasValue Then

                        RadDatePickerReportDate.SelectedDate = LoGlo.FormatDate(ExpenseReport.InvoiceDate)

                    End If

                    If ExpenseReport.CreatedDate.HasValue Then

                        Label_CreatedDate.Text = LoGlo.FormatDate(ExpenseReport.CreatedDate.Value)

                    End If

                    Try

                        RadToolbarExpenseEdit.FindItemByValue("Bookmark").Visible = ExpenseReport.InvoiceNumber > 0

                    Catch ex As Exception

                    End Try

                    Session("ExpRptEmpTerm_" & ExpenseReport.InvoiceNumber.ToString) = If(Employee.TerminationDate.HasValue, 1, 0)

                    If AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, ExpenseReport.EmployeeCode) = False Then

                        Me.ShowMessage("This employee code is not associated with a vendor code")
                        Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False

                    End If

                End If

            End Using

            'RadGridExpenseItems.Rebind()

        Catch ex As Exception

            If Not Request.QueryString("bm") Is Nothing Then

                If Request.QueryString("bm") = "1" Then

                    Me.ShowMessage("Expense is no longer available. Please delete your bookmark.")
                    Me.CloseThisWindow()

                End If

            End If

        End Try

        EnableOrDisableActions()

    End Sub
    Private Sub LoadExpenseItems()

        RadGridExpenseItems.Rebind()

    End Sub
    Private Sub LoadEntity(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport)

        If ExpenseReport IsNot Nothing Then

            ExpenseReport.Description = TextBox_ExpenseDescription.Text
            ExpenseReport.Details = RadTextBox_ExpenseDetailDescription.Text
            ExpenseReport.InvoiceDate = RadDatePickerReportDate.SelectedDate
            ExpenseReport.EmployeeCode = Label_EmployeeCode.Text
            ExpenseReport.VendorCode = Label_VendorCode.Text

        End If

    End Sub
    Private Function LoadDetailEntity(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail,
                                      ByVal GridItem As Telerik.Web.UI.GridItem, ByVal IsNew As Boolean) As Boolean

        'objects
        Dim ItemDatePicker As Telerik.Web.UI.RadDatePicker = Nothing
        Dim ItemDescriptionTextBox As Telerik.Web.UI.RadTextBox = Nothing
        Dim ClientTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim DivisionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim ProductTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim JobNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim JobComponentNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim QuantityRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim PaymentTypeCombobox As Telerik.Web.UI.RadComboBox = Nothing
        Dim NonBillableDiv As HtmlControls.HtmlControl = Nothing
        Dim DocumentsDiv As HtmlControls.HtmlControl = Nothing
        Dim SaveImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CopyImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CancelImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim AddItemImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim JobDescriptionLabel As System.Web.UI.WebControls.Label = Nothing
        Dim JobCompDescriptionLabel As System.Web.UI.WebControls.Label = Nothing
        Dim Loaded As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim FunctionCode As String = String.Empty

        If ExpenseReportDetail IsNot Nothing AndAlso GridItem IsNot Nothing Then

            LoadGridItemControls(GridItem, ItemDatePicker, ItemDescriptionTextBox, ClientTextbox, DivisionTextbox, ProductTextbox, JobNumericTextbox,
                                 JobComponentNumericTextbox, FunctionTextbox, QuantityRadNumericTextBox, RateRadNumericTextBox, AmountRadNumericTextBox, PaymentTypeCombobox,
                                 NonBillableDiv, DocumentsDiv, SaveImageButton, CopyImageButton, DeleteImageButton,
                                 CancelImageButton, AddItemImageButton, JobDescriptionLabel, JobCompDescriptionLabel)

            ExpenseReportDetail.ItemDate = ItemDatePicker.SelectedDate
            ExpenseReportDetail.Description = ItemDescriptionTextBox.Text.Trim

            ExpenseReportDetail.ClientCode = ClientTextbox.Text.Trim
            ExpenseReportDetail.DivisionCode = DivisionTextbox.Text.Trim
            ExpenseReportDetail.ProductCode = ProductTextbox.Text.Trim

            If IsNew = False Then

                If ExpenseReportDetail.JobNumber.GetValueOrDefault(0) <> JobNumericTextbox.Value.GetValueOrDefault(0) OrElse
                    ExpenseReportDetail.JobComponentNumber.GetValueOrDefault(0) <> JobComponentNumericTextbox.Value.GetValueOrDefault(0) Then

                    IsNew = True

                End If

            End If

            ExpenseReportDetail.JobNumber = JobNumericTextbox.Value

            If (JobNumericTextbox.Value.GetValueOrDefault(0) <= 0) Then

                JobDescriptionLabel.Text = ""

            End If

            If JobComponentNumericTextbox.Value.GetValueOrDefault(0) > 0 Then

                ExpenseReportDetail.JobComponentNumber = CShort(JobComponentNumericTextbox.Value.GetValueOrDefault(0))

            Else

                JobCompDescriptionLabel.Text = ""
                ExpenseReportDetail.JobComponentNumber = Nothing

            End If

            FunctionCode = FunctionTextbox.Text.Trim()

            If IsNew = True Then

                If AdvantageFramework.ExpenseReports.ValidateExpenseFunction(DbContext, FunctionTextbox.Text.Trim, ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)
                    Return False

                End If

            Else

                If ExpenseReportDetail.FunctionCode <> FunctionCode Then

                    If AdvantageFramework.ExpenseReports.ValidateExpenseFunction(DbContext, FunctionTextbox.Text.Trim, ErrorMessage) = False Then

                        Me.ShowMessage(ErrorMessage)
                        Return False

                    End If

                End If

            End If

            ExpenseReportDetail.FunctionCode = FunctionCode
            ExpenseReportDetail.Quantity = QuantityRadNumericTextBox.Value
            ExpenseReportDetail.Rate = RateRadNumericTextBox.Value
            ExpenseReportDetail.Amount = AmountRadNumericTextBox.Value
            ExpenseReportDetail.PaymentType = GetComboBoxValue(PaymentTypeCombobox, GetType(System.Int16))

            If ExpenseReportDetail.PaymentType.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.CorporateCreditCard Then

                ExpenseReportDetail.CreditCardFlag = True

            Else

                ExpenseReportDetail.CreditCardFlag = False

            End If
            If IsNew Then

                Loaded = ValidateComponent(ExpenseReportDetail, IsNew)

            Else

                Loaded = True

            End If

        End If

        Return Loaded

    End Function
    Private Sub EnableOrDisableActions()

        'objects
        Dim EmployeeTerminated As Boolean = False

        Try

            EmployeeTerminated = CBool(Session("ExpRptEmpTerm_" & _InvoiceNumber.ToString))

        Catch ex As Exception
            EmployeeTerminated = False
        End Try

        If EmployeeTerminated Then

            RadTextBox_ExpenseDetailDescription.Enabled = False
            RadTextBox_ExpenseDetailDescription.ReadOnly = True
            TextBox_ExpenseDescription.Enabled = False
            TextBox_ExpenseDescription.ReadOnly = True
            RadDatePickerReportDate.Enabled = False
            RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
            RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
            RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
            RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
            RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = False
            RadToolbarExpenseEdit.FindItemByValue("Copy").Enabled = False

        Else

            Select Case _ExpenseReportStatus

                Case AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open

                    RadTextBox_ExpenseDetailDescription.Enabled = True
                    RadTextBox_ExpenseDetailDescription.ReadOnly = False
                    TextBox_ExpenseDescription.Enabled = True
                    TextBox_ExpenseDescription.ReadOnly = False
                    RadDatePickerReportDate.Enabled = True
                    RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = True
                    RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = True
                    RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = Me.IsVendorAssociated
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = True

                Case AdvantageFramework.ExpenseReports.ExpenseReportStatus.Pending,
                     AdvantageFramework.ExpenseReports.ExpenseReportStatus.PendingApproval,
                     AdvantageFramework.ExpenseReports.ExpenseReportStatus.DeniedByApprover,
                     AdvantageFramework.ExpenseReports.ExpenseReportStatus.DeniedByAccounting

                    RadTextBox_ExpenseDetailDescription.Enabled = False
                    RadTextBox_ExpenseDetailDescription.ReadOnly = True
                    TextBox_ExpenseDescription.Enabled = False
                    TextBox_ExpenseDescription.ReadOnly = True
                    RadDatePickerReportDate.Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Submit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = True
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Enabled = Me.IsVendorAssociated
                    RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = False

                Case AdvantageFramework.ExpenseReports.ExpenseReportStatus.Approved,
                     AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedByApprover,
                     AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedInAccounting

                    RadTextBox_ExpenseDetailDescription.Enabled = False
                    RadTextBox_ExpenseDetailDescription.ReadOnly = True
                    TextBox_ExpenseDescription.Enabled = False
                    TextBox_ExpenseDescription.ReadOnly = True
                    RadDatePickerReportDate.Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Submit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = False

                Case AdvantageFramework.ExpenseReports.ExpenseReportStatus.PendingApprovalInAccounting

                    RadTextBox_ExpenseDetailDescription.Enabled = False
                    RadTextBox_ExpenseDetailDescription.ReadOnly = True
                    TextBox_ExpenseDescription.Enabled = False
                    TextBox_ExpenseDescription.ReadOnly = True
                    RadDatePickerReportDate.Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Submit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
                    RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Enabled = False
                    RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = False

            End Select

        End If

    End Sub
    Private Function DeleteExpenseItem(ByVal ExpenseDetailID As Integer) As Boolean

        'objects
        Dim CanDelete As Boolean = True
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim Deleted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If IsNumeric(Me.Label_InvoiceNumber.Text) Then

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        _ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)

                        If _ExpenseReportStatus <> AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                            Me.ShowMessage("Can only delete open Expense Reports line items.")

                            CanDelete = False

                            Deleted = True

                        End If

                    End If

                    If CanDelete Then

                        ExpenseReportDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, ExpenseDetailID)

                        If ExpenseReportDetail IsNot Nothing Then

                            'If ExpenseReportDetail.IsImported Then

                            '    If ExpenseReportDetail.CreatedBy.ToUpper = _Session.UserCode.ToUpper Then

                            '        Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Delete(DbContext, ExpenseReportDetail)

                            '    Else

                            '        If Not AdvantageFramework.Security.CanUserCustom2InModule(_Session, AdvantageFramework.Security.Modules.Employee_ExpenseReports) Then

                            '            Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Delete(DbContext, ExpenseReportDetail)

                            '        Else

                            '            Me.ShowMessage("Security settings prevent you from deleting imported expense report line items.")

                            '            Deleted = True

                            '        End If

                            '    End If

                            'Else

                            Deleted = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Delete(DbContext, ExpenseReportDetail)

                            'End If

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            Deleted = False
        End Try

        DeleteExpenseItem = Deleted

    End Function

    Private Function LoadExpenseReportDetailByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ExpenseReportDetail

        LoadExpenseReportDetailByID = (From ExpenseReportDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)
                                       Where ExpenseReportDetail.ID = ID
                                       Select ExpenseReportDetail).SingleOrDefault

    End Function

    Private Function SaveExpenseItem(ByVal ExpenseDetailID As Integer, ByVal GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        Dim Saved As Boolean = False
        Dim ErrorText As String = Nothing

        Try

            If GridDataItem IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        ExpenseReportDetail = LoadExpenseReportDetailByID(DbContext, ExpenseDetailID)

                    Catch ex As Exception
                        ShowGridItemValidation(GridDataItem, ex.Message)
                    End Try

                    If ExpenseReportDetail IsNot Nothing Then

                        If LoadDetailEntity(DbContext, ExpenseReportDetail, GridDataItem, False) Then

                            Saved = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Update(DbContext, ExpenseReportDetail, ErrorText)

                            ShowGridItemValidation(GridDataItem, ErrorText)

                            'Else

                            '    ShowGridItemValidation(GridDataItem, "ERROR : LoadDetailEntity failed")

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            Saved = False
        End Try

        SaveExpenseItem = Saved

    End Function
    Private Function ValidateComponent(ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail, ByVal IsNewOrChanging As Boolean) As Boolean

        'objects
        Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
        Dim IsValid As Boolean = True

        If ExpenseReportDetail.JobNumber.HasValue AndAlso ExpenseReportDetail.JobComponentNumber.HasValue Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, ExpenseReportDetail.JobNumber, ExpenseReportDetail.JobComponentNumber)

                If JobComponentView IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, JobComponentView.JobNumber) = False AndAlso
                       AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode) = False Then

                        IsValid = False

                    End If

                    If IsValid = True Then

                        If IsNewOrChanging = True Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If (From Item In AdvantageFramework.ExpenseReports.LoadAvailableJobComponents(DbContext, SecurityDbContext, ExpenseReportDetail.JobNumber, ExpenseReportDetail.ClientCode, ExpenseReportDetail.DivisionCode, ExpenseReportDetail.ProductCode)
                                    Where Item.JobComponentNumber = ExpenseReportDetail.JobComponentNumber
                                    Select Item).Any = False Then

                                    IsValid = False

                                End If

                            End Using

                        End If

                    End If

                Else

                    IsValid = False

                End If

            End Using

            If IsValid = False Then

                Me.ShowMessage("Access to this job is denied.\n")

            End If

        End If

        ValidateComponent = IsValid

    End Function
    Private Function CopyExpenseItem(ByVal ExpenseDetailID As Integer) As Boolean

        'objects
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim DuplicateExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim Copied As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReportDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, ExpenseDetailID)

                DuplicateExpenseReportDetail = ExpenseReportDetail.DuplicateEntity()

                If DuplicateExpenseReportDetail IsNot Nothing Then

                    DuplicateExpenseReportDetail.DbContext = DbContext

                    Try

                        DuplicateExpenseReportDetail.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, DuplicateExpenseReportDetail.InvoiceNumber, False)
                                                                   Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        DuplicateExpenseReportDetail.LineNumber = DuplicateExpenseReportDetail.LineNumber
                    End Try

                    Copied = AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, DuplicateExpenseReportDetail)

                End If

            End Using

        Catch ex As Exception
            Copied = False
        End Try

        CopyExpenseItem = Copied

    End Function
    Protected Sub SelectSingleItemDataSource(ByVal RadComboBox As Telerik.Web.UI.RadComboBox, ByVal HasExtraComboItem As Boolean)

        Try

            If HasExtraComboItem Then

                If RadComboBox.Items.Count = 2 Then

                    RadComboBox.SelectedIndex = 1

                End If

            Else

                If RadComboBox.Items.Count = 1 Then

                    RadComboBox.SelectedIndex = 0

                End If

            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Sub NewExpense()

        'objects
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim EmployeeCode As String = Nothing
        Dim HasVendor As Boolean = False
        Dim VendorCode As String = Nothing

        Me.PageTitle = "New Expense Report"

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EmployeeCode = Request.QueryString("empcode")

            If String.IsNullOrWhiteSpace(EmployeeCode) Then

                Me.Label_EmployeeCode.Text = Session("EmpCode").ToString()
                Me.Label_EmployeeName.Text = Session("EmployeeName").ToString()

            Else

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    Me.Label_EmployeeCode.Text = Employee.Code
                    Me.Label_EmployeeName.Text = Employee.ToString

                Else

                    Me.Label_EmployeeCode.Text = Session("EmpCode").ToString()
                    Me.Label_EmployeeName.Text = Session("EmployeeName").ToString()

                End If

            End If

            Me.CheckEmployeeAccess(Me.Label_EmployeeCode.Text)

            If AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, Label_EmployeeCode.Text, VendorCode) Then

                HasVendor = True
                Me.Label_VendorCode.Text = VendorCode

            End If

        End Using

        If HasVendor = False Then

            Me.ShowMessage("This employee code is not associated with a vendor code")
            Me.CloseThisWindow()

        End If

        Me.Label_Status.Text = "New"
        Me.Label_InvoiceNumber.Text = "TBD"

        Me.RadDatePickerReportDate.SelectedDate = cEmployee.TimeZoneToday

        Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
        Me.RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False

        EnableOrDisableActions()
        EnableButtons("new", HasVendor)

    End Sub
    Private Sub ClearGridRow(ByVal GridItem As Telerik.Web.UI.GridItem)

        If GridItem IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DirectCast(GridItem.FindControl("RadDatePickerItemTemplate_ItemDate"), Telerik.Web.UI.RadDatePicker).SelectedDate = Nothing
                        DirectCast(GridItem.FindControl("RadTextBox_ItemDescription"), Telerik.Web.UI.RadTextBox).Text = ""
                        DirectCast(GridItem.FindControl("RadNumericTextBoxQuantity"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                        DirectCast(GridItem.FindControl("RadNumericTextBoxRate"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                        DirectCast(GridItem.FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing

                        DirectCast(GridItem.FindControl("TextBoxClient"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TextBoxDivision"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("TextBoxProduct"), System.Web.UI.WebControls.TextBox).Text = ""
                        DirectCast(GridItem.FindControl("RadNumericTextBoxJob"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                        DirectCast(GridItem.FindControl("RadNumericTextBoxJobComponent"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                        DirectCast(GridItem.FindControl("TextBoxFunction"), System.Web.UI.WebControls.TextBox).Text = ""

                    Catch ex As Exception

                    End Try

                End Using

            End Using

            SetupGridItem(GridItem, Nothing)

        End If

    End Sub
    Private Sub SetupGridItem(ByVal GridItem As Telerik.Web.UI.GridItem, Optional ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing)

        'objects
        Dim ItemDatePicker As Telerik.Web.UI.RadDatePicker = Nothing
        Dim ItemDescriptionTextbox As Telerik.Web.UI.RadTextBox = Nothing
        Dim ClientTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim DivisionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim ProductTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim JobNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim JobComponentNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim QuantityRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim PaymentTypeCombobox As Telerik.Web.UI.RadComboBox = Nothing
        Dim NonBillableDiv As HtmlControls.HtmlControl = Nothing
        Dim DocumentsDiv As HtmlControls.HtmlControl = Nothing
        Dim SaveImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CopyImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CancelImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim AddItemImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim JobDescriptionLabel As System.Web.UI.WebControls.Label = Nothing
        Dim JobCompDescriptionLabel As System.Web.UI.WebControls.Label = Nothing
        Dim IsNewItemRow As Boolean = False
        Dim NonBillable As Boolean = False
        Dim PreselectJavascriptFunction As String = Nothing
        Dim BasePreselectJavascriptFunction As String = Nothing
        Dim MultiplyJavascriptFunction As String = Nothing
        Dim SelectDateJavascriptFunction As String = Nothing
        Dim SelectPaymentTypeJavascriptFunction As String = Nothing
        Dim CanEdit As Boolean = True
        Dim HasDocuments As Boolean = False
        Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
        Dim CanEditAmounts As Boolean = True

        If GridItem IsNot Nothing Then

            Try

                If TypeOf GridItem Is Telerik.Web.UI.GridDataInsertItem Then

                    IsNewItemRow = True

                End If

                If _ExpenseReportStatus <> AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                    CanEdit = False

                ElseIf ExpenseReportDetail IsNot Nothing AndAlso ExpenseReportDetail.IsImported Then

                    If ExpenseReportDetail.CreatedBy.ToUpper <> _Session.UserCode.ToUpper Then

                        If AdvantageFramework.Security.CanUserCustom2InModule(_Session, AdvantageFramework.Security.Modules.Employee_ExpenseReports) Then

                            CanEditAmounts = False

                        End If

                    End If

                End If

                If GridItem.Visible Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            LoadGridItemControls(GridItem, ItemDatePicker, ItemDescriptionTextbox, ClientTextbox, DivisionTextbox, ProductTextbox, JobNumericTextbox,
                                                 JobComponentNumericTextbox, FunctionTextbox, QuantityRadNumericTextBox, RateRadNumericTextBox, AmountRadNumericTextBox,
                                                 PaymentTypeCombobox, NonBillableDiv, DocumentsDiv, SaveImageButton, CopyImageButton, DeleteImageButton,
                                                 CancelImageButton, AddItemImageButton, JobDescriptionLabel, JobCompDescriptionLabel)

                            If IsNewItemRow Then

                                AdvantageFramework.Web.Presentation.Controls.DivHide(NonBillableDiv)

                            ElseIf ExpenseReportDetail IsNot Nothing Then

                                If ExpenseReportDetail.JobNumber.GetValueOrDefault(0) > 0 AndAlso ExpenseReportDetail.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                                    Try

                                        NonBillable = CBool(AdvantageFramework.ExpenseReports.LoadBillingRateByItem(DbContext, ExpenseReportDetail).NOBILL_FLAG.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        NonBillable = False
                                    End Try

                                    If NonBillable = False Then AdvantageFramework.Web.Presentation.Controls.DivHide(NonBillableDiv)

                                Else

                                    AdvantageFramework.Web.Presentation.Controls.DivHide(NonBillableDiv)

                                End If

                                Try

                                    HasDocuments = (From Entity In AdvantageFramework.Database.Procedures.ExpenseDetailDocument.LoadByExpenseDetailID(DbContext, ExpenseReportDetail.ID)
                                                    Select Entity).Any

                                Catch ex As Exception
                                    HasDocuments = False
                                End Try

                                If HasDocuments = False Then AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsDiv)

                                If ExpenseReportDetail.ItemDate.HasValue Then

                                    ItemDatePicker.DbSelectedDate = ExpenseReportDetail.ItemDate.Value

                                End If

                            End If

                            If ClientTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    ClientTextbox.Text = ExpenseReportDetail.ClientCode

                                End If

                            End If

                            If DivisionTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    DivisionTextbox.Text = ExpenseReportDetail.DivisionCode

                                End If

                            End If

                            If ProductTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    ProductTextbox.Text = ExpenseReportDetail.ProductCode

                                End If

                            End If

                            If JobNumericTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    If ExpenseReportDetail.JobNumber.HasValue Then

                                        JobNumericTextbox.Value = ExpenseReportDetail.JobNumber

                                    End If

                                End If

                            End If

                            If JobComponentNumericTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    If ExpenseReportDetail.JobComponentNumber.HasValue Then

                                        JobComponentNumericTextbox.Value = ExpenseReportDetail.JobComponentNumber

                                    End If

                                End If

                            End If

                            If ExpenseReportDetail IsNot Nothing Then

                                If ExpenseReportDetail.JobNumber.HasValue AndAlso ExpenseReportDetail.JobComponentNumber.HasValue Then

                                    JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, ExpenseReportDetail.JobNumber, ExpenseReportDetail.JobComponentNumber)

                                    If JobComponentView IsNot Nothing Then

                                        JobDescriptionLabel.Text = JobComponentView.JobDescription
                                        JobCompDescriptionLabel.Text = JobComponentView.JobComponentDescription

                                    End If

                                End If

                            End If

                            If FunctionTextbox IsNot Nothing Then

                                If ExpenseReportDetail IsNot Nothing Then

                                    FunctionTextbox.Text = ExpenseReportDetail.FunctionCode

                                End If

                            End If

                            If PaymentTypeCombobox IsNot Nothing Then

                                PaymentTypeCombobox.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.ExpenseItemPaymentType), False)
                                PaymentTypeCombobox.DataBind()

                                If ExpenseReportDetail IsNot Nothing Then

                                    If ExpenseReportDetail.PaymentType.HasValue Then

                                        PaymentTypeCombobox.SelectedValue = ExpenseReportDetail.PaymentType

                                    ElseIf ExpenseReportDetail.CreditCardFlag.GetValueOrDefault(False) = True Then

                                        PaymentTypeCombobox.SelectedValue = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.CorporateCreditCard

                                    Else

                                        PaymentTypeCombobox.SelectedValue = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash

                                    End If

                                Else

                                    Dim appVars = New Webvantage.cAppVars(cAppVars.Application.EXPENSE_REPORT, _Session.UserCode, _Session.User.EmployeeCode)
                                    Dim DefaultPaymentType As Short? = Nothing
                                    appVars.getAllAppVars()

                                    Try

                                        DefaultPaymentType = CShort(appVars.getAppVar("DefaultPaymentType"))

                                    Catch ex As Exception
                                        DefaultPaymentType = Nothing
                                    End Try

                                    If DefaultPaymentType.HasValue Then

                                        PaymentTypeCombobox.SelectedValue = DefaultPaymentType

                                    End If

                                End If

                            End If

                            For Each Control In GridItem.Controls

                                If TypeOf Control Is Telerik.Web.UI.RadTextBox Then

                                    DirectCast(Control, Telerik.Web.UI.RadTextBox).ClientEvents.OnValueChanged = ""

                                End If

                            Next

                            MultiplyJavascriptFunction = "Javascript:{0}('" & QuantityRadNumericTextBox.ClientID & "','" & RateRadNumericTextBox.ClientID & "','" & AmountRadNumericTextBox.ClientID & "');"

                            If ExpenseReportDetail Is Nothing Then ' JAVASCRIPT FOR NEW ITEM ROW ONLY!!

                                SelectPaymentTypeJavascriptFunction = "SetDefaultPaymentType('" & PaymentTypeCombobox.ClientID & "', '" & AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash & "'); "
                                SelectDateJavascriptFunction = "SetDefaultItemDate('" & ItemDatePicker.ClientID & "', '" & cEmployee.TimeZoneToday.ToString & "'); "

                                BasePreselectJavascriptFunction = SelectPaymentTypeJavascriptFunction & SelectDateJavascriptFunction

                                PreselectJavascriptFunction = "function(sender, eventArgs){ " & BasePreselectJavascriptFunction & "}"

                                ItemDatePicker.ClientEvents.OnDateSelected = PreselectJavascriptFunction.Replace(SelectDateJavascriptFunction, "")
                                ItemDescriptionTextbox.ClientEvents.OnValueChanged = PreselectJavascriptFunction

                                ' events for c/d/p/j/c/f

                                MultiplyJavascriptFunction &= BasePreselectJavascriptFunction

                            End If

                        End Using

                    End Using

                    If CanEdit = False Then

                        ItemDatePicker.Enabled = False
                        ItemDescriptionTextbox.Enabled = False
                        ClientTextbox.Enabled = False
                        DivisionTextbox.Enabled = False
                        ProductTextbox.Enabled = False
                        JobNumericTextbox.Enabled = False
                        JobDescriptionLabel.Enabled = False
                        JobComponentNumericTextbox.Enabled = False
                        JobCompDescriptionLabel.Enabled = False
                        FunctionTextbox.Enabled = False
                        QuantityRadNumericTextBox.Enabled = False
                        RateRadNumericTextBox.Enabled = False
                        AmountRadNumericTextBox.Enabled = False
                        PaymentTypeCombobox.Enabled = False
                        SaveImageButton.Enabled = False
                        CopyImageButton.Enabled = False
                        DeleteImageButton.Enabled = False

                        SaveImageButton.CssClass = "DisabledImageButton"
                        CopyImageButton.CssClass = "DisabledImageButton"
                        DeleteImageButton.CssClass = "DisabledImageButton"

                        Try

                            ClientTextbox.Attributes.Remove("adv-lookup")
                            DivisionTextbox.Attributes.Remove("adv-lookup")
                            ProductTextbox.Attributes.Remove("adv-lookup")
                            JobNumericTextbox.Attributes.Remove("adv-lookup")
                            JobComponentNumericTextbox.Attributes.Remove("adv-lookup")
                            FunctionTextbox.Attributes.Remove("adv-lookup")

                        Catch ex As Exception

                        End Try

                        SaveImageButton.Style(System.Web.UI.HtmlTextWriterStyle.Cursor) = "default"
                        CopyImageButton.Style(System.Web.UI.HtmlTextWriterStyle.Cursor) = "default"
                        DeleteImageButton.Style(System.Web.UI.HtmlTextWriterStyle.Cursor) = "default"

                        RadContextMenuGridItem.FindItemByValue("CopyItem").Enabled = False
                        RadContextMenuGridItem.FindItemByValue("DeleteItem").Enabled = False

                    ElseIf CanEditAmounts = False Then

                        QuantityRadNumericTextBox.Enabled = False
                        RateRadNumericTextBox.Enabled = False
                        AmountRadNumericTextBox.Enabled = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub LoadBillingRate(ByVal GridItem As Telerik.Web.UI.GridItem)

        'objects
        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing
        Dim JobNumber As String = Nothing
        Dim JobComponentNumber As String = Nothing
        Dim FunctionCode As String = Nothing
        Dim RadNumericTextBoxRate As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RadNumericTextBoxAmount As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RadNumericTextBoxQuantity As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RadDatePicker_ItemDate As Telerik.Web.UI.RadDatePicker = Nothing
        Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
        Dim Quantity As Decimal? = Nothing
        Dim Rate As Decimal? = Nothing
        Dim Amount As Decimal? = Nothing

        If GridItem IsNot Nothing Then

            FunctionCode = DirectCast(GridItem.FindControl("RadComboboxItemTemplate_Function"), Telerik.Web.UI.RadComboBox).SelectedValue

            If String.IsNullOrEmpty(FunctionCode) = False Then

                ClientCode = DirectCast(GridItem.FindControl("TextBoxClient"), System.Web.UI.WebControls.TextBox).Text
                DivisionCode = DirectCast(GridItem.FindControl("TextBoxDivision"), System.Web.UI.WebControls.TextBox).Text
                ProductCode = DirectCast(GridItem.FindControl("TextBoxProduct"), System.Web.UI.WebControls.TextBox).Text
                JobNumber = DirectCast(GridItem.FindControl("RadNumericTextBoxJob"), Telerik.Web.UI.RadNumericTextBox).Value
                JobComponentNumber = DirectCast(GridItem.FindControl("RadNumericTextBoxJobComponent"), Telerik.Web.UI.RadNumericTextBox).Text

                RadNumericTextBoxRate = DirectCast(GridItem.FindControl("RadNumericTextBoxRate"), Telerik.Web.UI.RadNumericTextBox)
                RadNumericTextBoxAmount = DirectCast(GridItem.FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox)
                RadNumericTextBoxQuantity = DirectCast(GridItem.FindControl("RadNumericTextBoxQuantity"), Telerik.Web.UI.RadNumericTextBox)
                RadDatePicker_ItemDate = DirectCast(GridItem.FindControl("RadDatePickerItemTemplate_ItemDate"), Telerik.Web.UI.RadDatePicker)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, Nothing, Nothing, RadDatePicker_ItemDate.SelectedDate)

                    If BillingRate IsNot Nothing Then

                        Try

                            Rate = BillingRate.BILLING_RATE
                            Quantity = RadNumericTextBoxQuantity.Value
                            Amount = RadNumericTextBoxAmount.Value

                            If Quantity Is Nothing OrElse Quantity.GetValueOrDefault(0) = 0 Then

                                Quantity = Nothing

                            End If

                            If (Rate Is Nothing OrElse Rate.GetValueOrDefault(0) = 0) Then

                                Rate = Nothing

                            End If

                            AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(Quantity, Rate, Amount, AdvantageFramework.BillingSystem.QtyRateAmount.Rate)

                            RadNumericTextBoxAmount.Value = Amount
                            RadNumericTextBoxQuantity.Value = Quantity
                            RadNumericTextBoxRate.Value = Rate

                        Catch ex As Exception

                        End Try

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub EnableButtons(ByVal Status As String, ByVal IsVendorAssociated As Boolean)

        'objects
        Dim InvoiceNumber As String = Nothing
        Dim LineItemCount As Integer = Nothing

        Select Case Status

            Case "new"

                Me.RadToolbarExpenseEdit.FindItemByValue("Copy").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = IsVendorAssociated
                Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Print").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("ViewDocs").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("ViewAllDocs").Enabled = False

            Case "open"

                InvoiceNumber = Request.QueryString("invoice")

                If InvoiceNumber = "new" Then

                    LineItemCount = 0

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            LineItemCount = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False)
                                             Select Entity).Count

                        Catch ex As Exception
                            LineItemCount = 0
                        End Try

                    End Using

                End If

                Me.RadToolbarExpenseEdit.FindItemByValue("Copy").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = IsVendorAssociated
                Me.RadToolbarExpenseEdit.FindItemByValue("Print").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Upload").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("ViewDocs").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("ViewAllDocs").Enabled = True

            Case "pending"

                Me.RadToolbarExpenseEdit.FindItemByValue("Copy").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Print").Enabled = True

            Case "approved"

                Me.RadToolbarExpenseEdit.FindItemByValue("Copy").Enabled = True
                Me.RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Print").Enabled = True

            Case "adding"

                Me.RadToolbarExpenseEdit.FindItemByValue("Delete").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Save").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = False
                Me.RadToolbarExpenseEdit.FindItemByValue("Print").Enabled = False

        End Select

    End Sub
    Private Function IsApproved(ByVal InvoiceNumber As Integer) As Boolean

        'objects
        Dim cExpense As Webvantage.cExpense = Nothing
        Dim ExpenseHeader As Webvantage.ExpenseHeader = Nothing
        Dim Approved As Boolean = False

        Try

            cExpense = New Webvantage.cExpense(Session("ConnString"))

            ExpenseHeader = cExpense.GetExpenseHeader(InvoiceNumber, False)

            Select Case ExpenseHeader.STATUS_CALC

                Case ExpenseStatusCalculated.Approved,
                    ExpenseStatusCalculated.ApprovedSuper,
                    ExpenseStatusCalculated.ApprovedAcct

                    Approved = True

                Case Else

                    Approved = False

            End Select

        Catch ex As Exception
            Approved = False
            Me.ShowMessage(ex.Message.ToString())
        Finally
            IsApproved = Approved
        End Try

    End Function
    Private Function IsVendorAssociated() As Boolean

        If Me.Label_VendorCode.Text.Trim = "" Then

            IsVendorAssociated = False

        Else

            IsVendorAssociated = True

        End If

        Return IsVendorAssociated

    End Function
    Private Function GetComboBoxValue(ByVal RadComboBox As Telerik.Web.UI.RadComboBox, ByVal ValueType As System.Type) As Object

        'objects
        Dim Value As Object = Nothing

        Try

            Value = RadComboBox.SelectedValue

            If String.IsNullOrEmpty(Value) Then

                Value = Nothing

            Else

                Value = Convert.ChangeType(Value, ValueType)

            End If

        Catch ex As Exception
            Value = Nothing
        Finally
            GetComboBoxValue = Value
        End Try

    End Function
    Private Sub LoadGridItemControls(ByVal GridItem As Telerik.Web.UI.GridItem, Optional ByRef ItemDatePicker As Telerik.Web.UI.RadDatePicker = Nothing,
                                     Optional ByRef DescriptionTextbox As Telerik.Web.UI.RadTextBox = Nothing, Optional ByRef ClientTextbox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef DivisionTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef ProductTextbox As System.Web.UI.WebControls.TextBox = Nothing,
                                     Optional ByRef JobNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef JobComponentNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing, Optional ByRef QuantityRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef RateRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing, Optional ByRef AmountRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing,
                                     Optional ByRef PaymentTypeCombobox As Telerik.Web.UI.RadComboBox = Nothing, Optional ByRef NonBillableDiv As HtmlControls.HtmlControl = Nothing,
                                     Optional ByRef DocumentsDiv As HtmlControls.HtmlControl = Nothing, Optional ByRef SaveImageButton As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef CopyImageButton As System.Web.UI.WebControls.ImageButton = Nothing, Optional ByRef DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef CancelImageButton As System.Web.UI.WebControls.ImageButton = Nothing, Optional ByRef AddItemImageButton As System.Web.UI.WebControls.ImageButton = Nothing,
                                     Optional ByRef JobDescriptionLabel As System.Web.UI.WebControls.Label = Nothing, Optional ByRef JobCompDescriptionLabel As System.Web.UI.WebControls.Label = Nothing)

        If GridItem IsNot Nothing Then

            Try

                ItemDatePicker = GridItem.FindControl("RadDatePickerItemTemplate_ItemDate")
                DescriptionTextbox = GridItem.FindControl("RadTextBox_ItemDescription")
                ClientTextbox = GridItem.FindControl("TextBoxClient")
                DivisionTextbox = GridItem.FindControl("TextBoxDivision")
                ProductTextbox = GridItem.FindControl("TextBoxProduct")
                JobNumericTextBox = GridItem.FindControl("RadNumericTextBoxJob")
                JobComponentNumericTextBox = GridItem.FindControl("RadNumericTextBoxJobComponent")
                FunctionTextbox = GridItem.FindControl("TextBoxFunction")
                QuantityRadNumericTextBox = GridItem.FindControl("RadNumericTextBoxQuantity")
                RateRadNumericTextBox = GridItem.FindControl("RadNumericTextBoxRate")
                AmountRadNumericTextBox = GridItem.FindControl("RadNumericTextBoxAmount")
                PaymentTypeCombobox = GridItem.FindControl("RadComboboxItemTemplate_PaymentType")
                NonBillableDiv = GridItem.FindControl("DivFlagColor")
                DocumentsDiv = GridItem.FindControl("DivDocuments")
                SaveImageButton = GridItem.FindControl("ImageButton_SaveExpenseItem")
                CopyImageButton = GridItem.FindControl("ImageButton_CopyExpenseItem")
                DeleteImageButton = GridItem.FindControl("ImageButton_DeleteExpenseItem")
                CancelImageButton = GridItem.FindControl("ImageButton_CancelExpenseItem")
                AddItemImageButton = GridItem.FindControl("ImageButton_AddExpenseItem")
                JobDescriptionLabel = GridItem.FindControl("Label_JobDescription")
                JobCompDescriptionLabel = GridItem.FindControl("Label_JobCompDescription")

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Function SelectSingleDivision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientCode As String, ByRef DivisionCode As String) As Boolean

        'objects
        Dim SelectSingle As Boolean = False

        Try

            DivisionCode = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                            Where Entity.IsActive = 1 AndAlso
                                  Entity.ClientCode = ClientCode
                            Select Entity.Code).Single

        Catch ex As Exception
            DivisionCode = ""
        End Try

        If String.IsNullOrEmpty(DivisionCode) = False Then

            SelectSingle = True

        End If

        SelectSingleDivision = SelectSingle

    End Function
    Private Function SelectSingleProduct(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByRef ProductCode As String) As Boolean

        'objects
        Dim SelectSingle As Boolean = False

        Try

            ProductCode = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, True)
                           Where Entity.IsActive = 1 AndAlso
                                 Entity.ClientCode = ClientCode AndAlso
                                 Entity.DivisionCode = DivisionCode
                           Select Entity.Code).Single

        Catch ex As Exception
            ProductCode = ""
        End Try

        If String.IsNullOrEmpty(ProductCode) = False Then

            SelectSingle = True

        End If

        SelectSingleProduct = SelectSingle

    End Function
    Private Function SelectSingleJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByRef JobNumber As Integer) As Boolean

        'objects
        Dim SelectSingle As Boolean = False
        Dim AllowedJobProcessControlNumbers As Integer() = Nothing

        AllowedJobProcessControlNumbers = New Integer() {1, 3, 4, 8, 9, 13}

        Try

            JobNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, Nothing, True, AllowedJobProcessControlNumbers)
                         Select [JN] = Entity.JobNumber).Distinct.Single

        Catch ex As Exception
            JobNumber = 0
        End Try

        If JobNumber > 0 Then

            SelectSingle = True

        End If

        SelectSingleJob = SelectSingle

    End Function
    Private Function SelectSingleJobComp(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal JobNumber As Integer, ByRef JobCompNumber As Short) As Boolean

        'objects
        Dim SelectSingle As Boolean = False
        Dim AllowedJobProcessControlNumbers As Integer() = Nothing

        AllowedJobProcessControlNumbers = New Integer() {1, 3, 4, 8, 9, 13}

        Try

            JobCompNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, Nothing, Nothing, Nothing, JobNumber, True, AllowedJobProcessControlNumbers)
                             Select [JN] = Entity.JobComponentNumber).Single

        Catch ex As Exception
            JobCompNumber = 0
        End Try

        If JobCompNumber > 0 Then

            SelectSingle = True

        End If

        SelectSingleJobComp = SelectSingle

    End Function
    Private Sub ShowGridItemValidation(ByVal GridDataItem As Telerik.Web.UI.GridDataItem, ErrorText As String)

        GridDataItem.DetailTemplateItemDataCell.Visible = Not String.IsNullOrWhiteSpace(ErrorText)
        GridDataItem.DetailTemplateItemDataCell.CssClass = "error-message"
        GridDataItem.DetailTemplateItemDataCell.Text = ErrorText

    End Sub

#Region "  Form Event Handlers "

    Private Sub Page_Init2(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HiddenFieldSecMod.Value = AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.Employee_ExpenseReports)

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts, False))
        RadToolbarButtonUpload.Enabled = HasAccessToDocuments
        RadToolbarButtonViewDocs.Enabled = HasAccessToDocuments
        RadToolbarButtonViewAllDocs.Enabled = HasAccessToDocuments

        Try

            If Request.QueryString("invoice") Is Nothing Then

                _InvoiceNumber = 0

            Else

                If IsNumeric(Request.QueryString("invoice")) = True Then

                    _InvoiceNumber = CInt(Request.QueryString("invoice"))

                Else

                    _InvoiceNumber = 0

                End If

            End If

        Catch ex As Exception
            _InvoiceNumber = 0
        End Try

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load ', MyBase.Load, Me.Load

        'objects
        Dim URL As String = Nothing
        Dim MinDate As Date = Nothing
        Dim MaxDate As Date = Nothing

        MinDate = AdvantageFramework.ExpenseReports.LoadMinimumReportDate()
        MaxDate = AdvantageFramework.ExpenseReports.LoadMaximumReportDate

        Me.HiddenFieldMinDate.Value = MinDate
        Me.HiddenFieldMaxDate.Value = MaxDate

        Me.RadGridExpenseItems.Visible = True
        Me.RadScriptManagerParent.Page = Me.Page

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)

            Me.RadToolbarExpenseEdit.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            Try

                If _InvoiceNumber > 0 Then

                    LoadExpenseReport()

                Else

                    NewExpense()

                    Me.RadToolbarExpenseEdit.FindItemByValue("Bookmark").Visible = False

                End If

            Catch ex As Exception

            End Try

        Else

            Try

                If IsNumeric(Me.Label_InvoiceNumber.Text) = True And _InvoiceNumber = 0 Then

                    _InvoiceNumber = CType(Me.Label_InvoiceNumber.Text, Integer)

                End If

            Catch ex As Exception
                _InvoiceNumber = 0
            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

#Region "  Toolbar Commands "

    Private Sub Delete_Click()

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim CanDelete As Boolean = True

        If IsNumeric(Me.Label_InvoiceNumber.Text) Then

            If IsApproved(CType(Me.Label_InvoiceNumber.Text.Trim, Integer)) = True Then

                Me.ShowMessage("Expense report has already been approved and cannot be deleted.")

                LoadExpense()

                CanDelete = False

            ElseIf _WebvantageExpenseStatus <> ExpenseStatus.Open Then

                Me.ShowMessage("Can only delete open Expense Reports")

                CanDelete = False

            End If

        End If

        If CanDelete Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.ExpenseReport.Delete(DbContext, ExpenseReport) = False Then

                        Me.ShowMessage("Could not delete Expense Report")

                    Else

                        Cancel_Click()

                    End If

                End If

            End Using

        End If

    End Sub
    Private Sub Submit_Click()

        'objects
        Dim OkToSubmit As Boolean = True
        Dim ErrorText As String = ""
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim RequiresApproval As Boolean = False
        Dim SubmitDirectToAP As Boolean = False

        If IsNumeric(Me.Label_InvoiceNumber.Text) Then

            If IsApproved(CType(Me.Label_InvoiceNumber.Text.Trim, Integer)) = True Then

                ErrorText = "Expense report has already been approved and cannot be modified."

                OkToSubmit = False

                LoadExpense()

            End If

        End If

        If RadGridExpenseItems.MasterTableView.Items.Count = 0 Then

            ErrorText = "Please add an Expense Line Item before submitting."

            OkToSubmit = False

        End If

        If OkToSubmit Then

            Save_Click()

            If Session("lcSavedOK") = "Yes" Or Session("lcSavedOK") = Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Not String.IsNullOrWhiteSpace(AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber).SubmittedTo) Then

                        SubmitDirectToAP = True

                    End If

                End Using

                If SubmitDirectToAP OrElse superApprNeeded() = False Then

                    If AdvantageFramework.ExpenseReports.SubmitExpenseReport(_Session, _InvoiceNumber, False, ErrorText, SubmitDirectToAP:=SubmitDirectToAP) Then

                        LoadExpense()

                    End If

                Else

                    QueryString = New AdvantageFramework.Web.QueryString

                    QueryString = QueryString.FromCurrent()
                    QueryString.ExpenseID = _InvoiceNumber

                    QueryString.Page = "Expense_SubmitOptions.aspx"

                    Me.OpenWindow("Submit Expense Report Options", QueryString.ToString(True), 245, 475, False, True)

                End If

            End If

        End If

        If String.IsNullOrEmpty(ErrorText) = False Then

            Me.ShowMessage(ErrorText)

        End If

    End Sub
    Private Sub UnSubmit_Click()

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim ErrorText As String = Nothing

        If IsNumeric(Me.Label_InvoiceNumber.Text) Then

            If IsApproved(CType(Me.Label_InvoiceNumber.Text.Trim, Integer)) = True Then

                Me.ShowMessage("Expense report has already been approved and cannot be modified.")
                LoadExpense()
                Exit Sub

            End If

        End If
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim blnReturn As Boolean

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

            If ExpenseReport IsNot Nothing Then

                If AdvantageFramework.ExpenseReports.UnSubmitExpenseReport(DbContext, ExpenseReport, ErrorText) = False Then

                    Me.ShowMessage(ErrorText)
                    Exit Sub
                End If

            End If

        End Using

        Me.RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
        Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Visible = True
        Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = Me.IsVendorAssociated

        ResponseRedirect(Request.Url.PathAndQuery)

    End Sub
    Private Sub Copy_Click()

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        QueryString.ExpenseID = _InvoiceNumber

        QueryString.Page = "Expense_CopyExpenseReport.aspx"

        Me.OpenWindow("Copy Expense Report", QueryString.ToString(True), 275, 675, False, True)

    End Sub
    Private Sub Save_Click()

        'objects
        Dim InvoiceNumber As Integer = Nothing
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing
        Dim ErrorText As String = Nothing
        Dim DetailErrorText As String = ""
        Dim SessionText As String = Nothing
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _InvoiceNumber <> Nothing Then

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)

                        If ExpenseReportStatus <> AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                            ErrorText = "This Expense Report cannot be modified."

                        Else

                            LoadEntity(ExpenseReport)

                            If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) Then

                                Saved = True

                                For Each GridDataItem In RadGridExpenseItems.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                                    Try

                                        ExpenseReportDetail = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID").ToString)

                                        If ExpenseReportDetail IsNot Nothing Then

                                            If LoadDetailEntity(DbContext, ExpenseReportDetail, GridDataItem, False) Then

                                                DetailErrorText = ""

                                                If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Update(DbContext, ExpenseReportDetail, DetailErrorText) = False Then

                                                    Saved = False
                                                    DbContext.UndoChanges(ExpenseReportDetail)

                                                End If

                                                ShowGridItemValidation(GridDataItem, DetailErrorText)

                                            End If

                                        End If

                                    Catch ex As Exception
                                        ErrorText = "One or more expense items failed to save."
                                        Saved = False
                                    End Try

                                Next

                            End If

                        End If

                    End If

                Else

                    ExpenseReport = New AdvantageFramework.Database.Entities.ExpenseReport

                    LoadEntity(ExpenseReport)

                    ExpenseReport.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) Then

                        Saved = True
                        _InvoiceNumber = ExpenseReport.InvoiceNumber
                        Label_InvoiceNumber.Text = InvoiceNumber
                        EnableButtons("open", Me.IsVendorAssociated)

                    End If

                End If

            End Using

        Catch ex As Exception
            Saved = False
            ErrorText = "Saving Failed!"
        End Try

        If Saved = False Then

            Session("lcSavedOK") = "No"

            If ErrorText <> "" Then

                Me.ShowMessage(ErrorText)

            End If

        Else

            Session("lcSavedOK") = "Yes"
            LoadExpense()
            EnableOrDisableActions()

            If Request.QueryString("invoice") Is Nothing Then
                Me.CloseThisWindowAndOpenNewWindow("Expense_Edit_v2.aspx?invoice=" + _InvoiceNumber.ToString, True)
            End If

        End If

    End Sub
    Private Sub Bookmark_Click()

        'objects
        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ErrorMessage As String = ""

        If IsNumeric(Me.Label_InvoiceNumber.Text = True) = True Then

            Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)
            QueryString = New AdvantageFramework.Web.QueryString()

            QueryString.Add("invoice", Label_InvoiceNumber.Text)

            If Label_EmployeeCode.Text.Trim <> "" Then

                QueryString.Add("empcode", Label_EmployeeCode.Text)

            End If

            QueryString.Page = "Expense_Edit_v2.aspx"

            Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports

            Bookmark.UserCode = _Session.UserCode

            Bookmark.Name = TextBox_ExpenseDescription.Text

            Bookmark.PageURL = QueryString.ToString(True)

            Dim s As String = ""

            If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

                Me.ShowMessage(ErrorMessage)

            Else

                Me.RefreshBookmarksDesktopObject()

            End If

        Else

            Me.ShowMessage("Cannot create bookmark from new entry.")

        End If

    End Sub
    Private Sub Cancel_Click()

        If Me.RadDatePickerReportDate.SelectedDate IsNot Nothing Then

            Me.CloseThisWindowAndOpenNewWindow("Expense_V2.aspx?empcode=" & Me.Label_EmployeeCode.Text & "&month=" & Me.RadDatePickerReportDate.SelectedDate.Value.Month.ToString("MM") & "&year=" & Me.RadDatePickerReportDate.SelectedDate.Value.Year.ToString())

        Else

            Me.CloseThisWindowAndOpenNewWindow("Expense_V2.aspx?empcode=" & Me.Label_EmployeeCode.Text)

        End If

    End Sub
    Private Sub ViewDocs(Optional ByVal ExpenseDetailID As Integer = Nothing)

        'objects
        Dim InvoiceNumber As String = Nothing
        Dim URL As String = Nothing

        InvoiceNumber = Me.Label_InvoiceNumber.Text

        URL = "Documents_List.aspx?DocPopupType=expense&invNbr=" & InvoiceNumber

        If ExpenseDetailID <> Nothing Then

            URL &= "&ItemID=" & ExpenseDetailID.ToString

        End If

        Me.OpenWindow("Download Receipts", URL, 365, 860)

    End Sub
    Private Sub Upload()

        If Me.Label_InvoiceNumber.Text <> "TBD" Then

            Session("DocCaption") = "Invoice Number: " & Me.Label_InvoiceNumber.Text

            Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename.ToLower & "&Level=EX&FK=&Value=" & Me.Label_InvoiceNumber.Text, 500, 550)

        End If

    End Sub
    Private Sub ViewAllDocs()
        Try
            'objects
            Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object) = Nothing
            Dim DataSource As Object = Nothing
            Dim URL As String = Nothing
            Dim InvoiceNumber As Integer = Nothing

            InvoiceNumber = CInt(Me.Label_InvoiceNumber.Text)

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


        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub RadToolbarExpenseEdit_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarExpenseEdit.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                Save_Click()

            Case "Copy"

                Copy_Click()

            Case "Delete"

                Delete_Click()

            Case "Submit"

                Submit_Click()

            Case "Unsubmit"

                UnSubmit_Click()

            Case "Print"

                Me.OpenWindow("Print Expense Report", "Expense_Print.aspx?InvoiceNumber=" & _InvoiceNumber.ToString, 350, 450, False, True)

            Case "Cancel"

                Cancel_Click()

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

            Case "ViewAllDocs"

                ViewAllDocs()

            Case "Bookmark"

                Bookmark_Click()

            Case "Refresh"

                MiscFN.ResponseRedirect("expense_edit_v2.aspx?invoice=" & _InvoiceNumber)

            Case "DeleteSelectedRows"
                Dim count As Integer = 0
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseItems.MasterTableView.Items
                    If gridDataItem.Selected Then
                        If DeleteExpenseItem(gridDataItem.GetDataKeyValue("ID")) = False Then
                            Me.ShowMessage("Deletion of expense item failed.")
                            Exit Sub
                        End If
                        count += 1
                    End If
                Next
                If count = 0 Then
                    Me.ShowMessage("No rows were selected for deletion.")
                End If
                LoadExpenseItems()

        End Select

    End Sub
    Private Sub RadGridExpenseItems_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridExpenseItems.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        Dim Reload As Boolean = False
        Dim Command As String = Nothing
        Dim CommandArgument As String = Nothing
        Dim ErrorText As String = Nothing
        Dim AppVars As Webvantage.cAppVars = Nothing

        If e.Item IsNot Nothing Then

            If e.CommandName = "Page" Then

                MiscFN.SavePageSize(RadGridExpenseItems.ID, RadGridExpenseItems.PageSize)
                Exit Sub

            End If

        End If

        Command = e.CommandName.ToString.ToUpper
        CommandArgument = e.CommandArgument.ToString

        Try

            GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

        Catch ex As Exception
            GridDataItem = Nothing
        End Try

        Select Case Command

            Case "DELETE"

                If DeleteExpenseItem(CommandArgument) = False Then

                    ErrorText = "Deletion of expense item failed."

                Else

                    Reload = True

                End If

            Case "SAVE", "COPY"

                If GridDataItem IsNot Nothing Then

                    If SaveExpenseItem(CommandArgument, GridDataItem) Then

                        If Command = "COPY" Then

                            If CopyExpenseItem(CommandArgument) = False Then

                                ErrorText = "Copying of expense item failed."

                            Else

                                Reload = True

                            End If

                        Else

                            Reload = True

                        End If

                    End If

                End If

            Case "ADDITEM"

                If GridDataItem IsNot Nothing Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ExpenseReportDetail = New AdvantageFramework.Database.Entities.ExpenseReportDetail

                            If LoadDetailEntity(DbContext, ExpenseReportDetail, GridDataItem, True) = True Then

                                If ExpenseReportDetail.JobNumber IsNot Nothing Then

                                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ExpenseReportDetail.JobNumber)

                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, ExpenseReportDetail.JobNumber) = False AndAlso
                                    AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then

                                        Me.ShowMessage("Access to this job is denied.\n")
                                        Exit Sub

                                    End If

                                End If

                                If String.IsNullOrWhiteSpace(ExpenseReportDetail.FunctionCode) = False Then

                                    Dim ExpenseFunction As AdvantageFramework.Database.Entities.Function

                                    ExpenseFunction = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, ExpenseReportDetail.FunctionCode)

                                    If ExpenseFunction Is Nothing Then

                                        Me.ShowMessage("Invalid function.")
                                        Exit Sub

                                    Else

                                        If ExpenseFunction.EmployeeExpenseFlag IsNot Nothing AndAlso
                                        ExpenseFunction.EmployeeExpenseFlag = 1 Then

                                            If ExpenseFunction.IsInactive IsNot Nothing AndAlso
                                            ExpenseFunction.IsInactive = 1 Then

                                                Me.ShowMessage("Function inactive.")
                                                Exit Sub

                                            End If

                                        Else

                                            Me.ShowMessage("Not an expense function.")
                                            Exit Sub

                                        End If

                                    End If

                                End If

                                ExpenseReportDetail.DbContext = DbContext
                                ExpenseReportDetail.InvoiceNumber = _InvoiceNumber
                                ExpenseReportDetail.CreatedBy = _Session.UserCode

                                Try

                                    ExpenseReportDetail.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False)
                                                                      Select Entity.LineNumber).Max + 1

                                Catch ex As Exception
                                    ExpenseReportDetail.LineNumber = 1
                                End Try

                                If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseReportDetail) Then

                                    Reload = True

                                    AppVars = New cAppVars(cAppVars.Application.EXPENSE_REPORT, _Session.UserCode, _Session.User.EmployeeCode)
                                    AppVars.getAllAppVars()
                                    AppVars.setAppVarDB("DefaultPaymentType", ExpenseReportDetail.PaymentType.GetValueOrDefault(0).ToString, "Number")

                                End If

                            End If

                        End Using

                    Catch ex As Exception
                        ErrorText = "Adding expense item failed."
                    End Try

                End If

            Case "CANCELITEM"

                ClearGridRow(e.Item)

            Case "DOCUMENTS"

                ViewDocs(CInt(CommandArgument))

        End Select

        If ErrorText <> "" Then

            Me.ShowMessage(ErrorText)

        End If

        If Reload Then

            LoadExpenseItems()

        End If

    End Sub

    Private Sub RadGridExpenseItems_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridExpenseItems.ItemCreated

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ItemDatePicker As Telerik.Web.UI.RadDatePicker = Nothing
        Dim ItemDescriptionTextbox As Telerik.Web.UI.RadTextBox = Nothing
        Dim ClientTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim DivisionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim ProductTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim JobNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim JobComponentNumericTextbox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim FunctionTextbox As System.Web.UI.WebControls.TextBox = Nothing
        Dim QuantityRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim RateRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim AmountRadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim PaymentTypeCombobox As Telerik.Web.UI.RadComboBox = Nothing
        Dim NonBillableDiv As HtmlControls.HtmlControl = Nothing
        Dim DocumentsDiv As HtmlControls.HtmlControl = Nothing
        Dim SaveImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CopyImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CancelImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim AddItemImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim JobDescriptionLabel As System.Web.UI.WebControls.Label = Nothing
        Dim JobCompDescriptionLabel As System.Web.UI.WebControls.Label = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

                GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)


                LoadGridItemControls(GridDataItem, ItemDatePicker, ItemDescriptionTextbox, ClientTextbox, DivisionTextbox, ProductTextbox, JobNumericTextbox,
                                     JobComponentNumericTextbox, FunctionTextbox, QuantityRadNumericTextBox, RateRadNumericTextBox, AmountRadNumericTextBox,
                                     PaymentTypeCombobox, NonBillableDiv, DocumentsDiv, SaveImageButton, CopyImageButton, DeleteImageButton,
                                     CancelImageButton, AddItemImageButton, JobDescriptionLabel, JobCompDescriptionLabel)

                GridDataItem.DetailTemplateItemDataCell.Visible = False

                ClientTextbox.Attributes.Add("adv-lookup", "Client")
                DivisionTextbox.Attributes.Add("adv-lookup", "Division")
                ProductTextbox.Attributes.Add("adv-lookup", "Product")
                JobNumericTextbox.Attributes.Add("adv-lookup", "Job")
                JobComponentNumericTextbox.Attributes.Add("adv-lookup", "JobComponent")
                FunctionTextbox.Attributes.Add("adv-lookup", "Function")
                'QuantityRadNumericTextBox.Attributes.Add("adv-calc", "Quantity")
                'RateRadNumericTextBox.Attributes.Add("adv-calc", "Rate")
                'AmountRadNumericTextBox.Attributes.Add("adv-calc", "Amount")

                If DeleteImageButton IsNot Nothing Then

                    DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this Expense Item?');")

                End If

            End If

        End If

    End Sub
    Private Sub RadGridExpenseItems_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridExpenseItems.ItemDataBound

        'objects
        Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim StringBuilderValues As System.Text.StringBuilder = Nothing
        Dim TotalAmount As Decimal = Nothing
        Dim TotalCreditCard As Decimal = Nothing
        Dim TotalDue As Decimal = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse
           e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem OrElse
           e.Item.ItemType = Telerik.Web.UI.GridItemType.EditItem Then

            If e.Item.ItemType <> Telerik.Web.UI.GridItemType.EditItem Then

                Try

                    ExpenseReportDetail = DirectCast(e.Item.DataItem, AdvantageFramework.Database.Entities.ExpenseReportDetail)

                Catch ex As Exception
                    ExpenseReportDetail = Nothing
                End Try

            End If

            SetupGridItem(e.Item, ExpenseReportDetail)

        ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.Footer Then

            Try

                _InvoiceNumber = CInt(Request.QueryString("invoice"))

            Catch ex As Exception
                _InvoiceNumber = 0
            End Try

            Try

                If IsNumeric(Me.Label_InvoiceNumber.Text) = True AndAlso _InvoiceNumber = 0 Then

                    _InvoiceNumber = CInt(Me.Label_InvoiceNumber.Text)

                End If

            Catch ex As Exception
                _InvoiceNumber = 0
            End Try

            StringBuilder = New System.Text.StringBuilder

            StringBuilder.Append("<div name=""DivExpenseHdr"" id=""DivExpenseHdr"" class=""RightAlign"" style=""width:100%"">")
            StringBuilder.Append("<strong>Total Expenses:</strong><br />")
            StringBuilder.Append("</div>")
            StringBuilder.Append("<div name=""DivCCAmtHdr"" id=""DivCCAmtHdr"" class=""RightAlign"" style=""width:100%"">")
            StringBuilder.Append("<strong>Less Credit Card:</strong><br />")
            StringBuilder.Append("</div>")
            StringBuilder.Append("<div name=""DivTotalDueHdr"" id=""DivTotalDueHdr"" class=""RightAlign"" style=""width:100%"">")
            StringBuilder.Append("<strong>Total Due:</strong>")
            StringBuilder.Append("</div>")

            StringBuilderValues = New System.Text.StringBuilder

            If _InvoiceNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageFramework.ExpenseReports.CalculateExpenseReportDetailsTotals(DbContext, _InvoiceNumber, TotalAmount, TotalCreditCard, TotalDue)

                    StringBuilderValues.Append("<div name=""DivExpense"" id=""DivExpense"">")
                    StringBuilderValues.Append(TotalAmount.ToString("#,##0.00"))
                    StringBuilderValues.Append("</div>")

                    StringBuilderValues.Append("<div name=""DivCCAmt"" id=""DivCCAmt"">")
                    StringBuilderValues.Append(TotalCreditCard.ToString("#,##0.00"))
                    StringBuilderValues.Append("</div>")

                    StringBuilderValues.Append("<div name=""DivTotalDue"" id=""DivTotalDue"">")
                    StringBuilderValues.Append(TotalDue.ToString("#,##0.00"))
                    StringBuilderValues.Append("</div>")

                End Using

            Else

                StringBuilderValues.Append("<div name=""DivExpenseVal"" id=""DivExpenseVal"">")
                StringBuilderValues.Append("0.00")
                StringBuilderValues.Append("</div>")

                StringBuilderValues.Append("<div name=""DivCCAmValt"" id=""DivCCAmtVal"">")
                StringBuilderValues.Append("0.00")
                StringBuilderValues.Append("</div>")

                StringBuilderValues.Append("<div name=""DivTotalDueVal"" id=""DivTotalDueVal"">")
                StringBuilderValues.Append("0.00")
                StringBuilderValues.Append("</div>")

            End If

            GridFooterItem = DirectCast(e.Item, Telerik.Web.UI.GridFooterItem)

            GridFooterItem("GridTemplateColumn_Rate").Style("Display") = "none"

            With GridFooterItem("GridTemplateColumn_Quantity")
                .VerticalAlign = VerticalAlign.Top
                .HorizontalAlign = HorizontalAlign.Right
                .Text = StringBuilder.ToString()
                .ColumnSpan = 2
            End With

            With GridFooterItem("GridTemplateColumn_Amount")
                .VerticalAlign = VerticalAlign.Top
                .HorizontalAlign = HorizontalAlign.Right
                .Text = StringBuilderValues.ToString()
            End With

        End If

    End Sub
    Protected Sub RadGridExpenseItems_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs)

        'objects
        Dim CanInsertNewItems As Boolean = False
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

            Catch ex As Exception
                ExpenseReport = Nothing
            End Try

            If ExpenseReport IsNot Nothing Then

                _ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)

                If _ExpenseReportStatus = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then

                    CanInsertNewItems = True

                End If

                RadGridExpenseItems.DataSource = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, _InvoiceNumber, False).OrderBy(Function(ExpDtl) ExpDtl.LineNumber).ToList

            Else

                _ExpenseReportStatus = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open

                RadGridExpenseItems.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)

                CanInsertNewItems = False

            End If

            RadGridExpenseItems.MasterTableView.IsItemInserted = CanInsertNewItems

            RadGridExpenseItems.CurrentPageIndex = CurrentGridPageIndex
            RadGridExpenseItems.PageSize = MiscFN.LoadPageSize(RadGridExpenseItems.ID)

        End Using

    End Sub
    Private Sub RadGridExpenseItems_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridExpenseItems.PageIndexChanged


        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
        Dim ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _InvoiceNumber <> Nothing Then

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport)
                End If

            End If
        End Using

        If ExpenseReportStatus = AdvantageFramework.ExpenseReports.ExpenseReportStatus.Open Then
            Save_Click()
        End If

        CurrentGridPageIndex = e.NewPageIndex
        RadGridExpenseItems.Rebind()

    End Sub
    Private Sub RadGridExpenseItems_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridExpenseItems.PageSizeChanged

        MiscFN.SavePageSize(RadGridExpenseItems.ID, e.NewPageSize)

    End Sub
    Private Sub SetFocusOnComboBox(ByVal ClientID As String)

        If String.IsNullOrEmpty(ClientID) = False Then

            Me.RadScriptManagerParent.SetFocus(ClientID & "_Input")

        End If

    End Sub

    Protected Sub RadContextMenuGridItem_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ErrorText As String = Nothing
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim Reload As Boolean = False

        GridDataItem = RadGridExpenseItems.Items.OfType(Of Telerik.Web.UI.GridDataItem).Where(Function(i) i.ItemIndexHierarchical = HiddenFieldSelectedRow.Value).FirstOrDefault

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        If GridDataItem IsNot Nothing Then

            Select Case e.Item.Value
                Case "DeleteItem"

                    If RadGridExpenseItems.MasterTableView.GetSelectedItems.Length > 1 Then

                        For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseItems.MasterTableView.Items
                            If gridItem.Selected = True Then
                                If DeleteExpenseItem(gridItem.GetDataKeyValue("ID")) = False Then

                                    ErrorText = "Deletion of expense item failed."

                                Else

                                    Reload = True

                                End If
                            End If
                        Next
                    Else

                        If DeleteExpenseItem(GridDataItem.GetDataKeyValue("ID")) = False Then

                            ErrorText = "Deletion of expense item failed."

                        Else

                            Reload = True

                        End If

                    End If



                Case "CopyItem"

                    If RadGridExpenseItems.MasterTableView.GetSelectedItems.Length > 1 Then

                        For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridExpenseItems.MasterTableView.Items
                            If gridItem.Selected = True Then
                                If SaveExpenseItem(gridItem.GetDataKeyValue("ID"), GridDataItem) Then
                                    If CopyExpenseItem(gridItem.GetDataKeyValue("ID")) = False Then

                                        ErrorText = "Copying of expense item failed."

                                    Else

                                        Reload = True

                                    End If
                                End If
                            End If
                        Next

                    Else

                        If SaveExpenseItem(GridDataItem.GetDataKeyValue("ID"), GridDataItem) Then

                            If CopyExpenseItem(GridDataItem.GetDataKeyValue("ID")) = False Then

                                ErrorText = "Copying of expense item failed."

                            Else

                                Reload = True

                            End If

                        Else

                            ErrorText = "Saving of expense item failed."

                        End If

                    End If

            End Select

            If Reload = True Then

                LoadExpenseItems()

            End If



        End If

    End Sub
#End Region

#End Region

#Region " Dirty Code "

    Private Function ValidateLine(ByVal ExpDetailID As Integer,
                                    ByVal ItemDate As Date,
                                    ByVal ClientCode As String,
                                    ByVal DivisionCode As String,
                                    ByVal ProductCode As String,
                                    ByVal Job As String,
                                    ByVal JobComp As String,
                                    ByVal FunctCat As String,
                                    ByVal Qty As String,
                                    ByVal Rate As String,
                                    ByVal Amount As String,
                                    ByVal CreditCard As Boolean,
                                    ByVal ItemDesc As String) As ExpenseDetail
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim ThisExpenseDetail As ExpenseDetail = New ExpenseDetail
        Dim ThisJob As Integer
        Dim ThisJobComp As Integer
        Dim ThisClient As String
        Dim ThisDiv As String
        Dim ThisProd As String

        'Expense Header ID
        ThisExpenseDetail.INV_NBR = Me.Label_InvoiceNumber.Text
        ThisExpenseDetail.EXPDETAILID = ExpDetailID

        ThisExpenseDetail.ITEM_DATE = wvCDate(ItemDate)

        Dim dtStart As DateTime = LoGlo.FormatDateTime(Convert.ToDateTime("3/31/1974 12:00:00 AM"))
        Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("6/6/2079 11:59:59 PM"))
        If ThisExpenseDetail.ITEM_DATE < dtStart Or ThisExpenseDetail.ITEM_DATE > dtEnd Then
            Me.ShowMessage("Date invalid")
            Exit Function
        End If

        'Modified by Sam Tran on 2006/05/17
        '	not touching the below, running another if
        'If Not Job Is Nothing Or Job.Length > 0 Or Job <> String.Empty Or Job <> "" Then
        'If JobComp.Length = 0 Or JobComp Is Nothing Or JobComp = String.Empty Or JobComp = "" Then
        'Me.ShowMessage("You specified a job without specifying a job component!<BR />Please either supply a job component, or remove the job number!")
        'Exit Function
        'End If
        'End If


        'Get Client, Division and Product of only Job and Job Comp is given
        If Job = "" Then
            'ThisJob = Nothing
        Else
            If IsNumeric(Job) Then
                ThisJob = CInt(Job)
            Else
                'ThisJob = Nothing
            End If
        End If

        If JobComp = "" Then
            'ThisJobComp = Nothing
        Else
            If IsNumeric(JobComp) Then
                ThisJobComp = CInt(JobComp)
            Else
                'ThisJobComp = Nothing
            End If
        End If
        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.IsJobExpensible(ThisJob, ThisJobComp) = False Then
                Me.ShowMessage("Job/comp process control does not allow access")
                Exit Function
            End If

            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                Me.ShowMessage("Invalid Job and Job Component")
                Exit Function
            End If
            'Modified by Sam Tran on 2006/05/17
            '	  added the elsif
            'ElseIf ThisJob > 0 And ThisJobComp <= 0 Then
            'Me.ShowMessage("You specified a job without specifying a job component!<BR />Please either supply a job component, or remove the job number!")
            'Exit Function
        End If

        If ThisClient <> "" Then
            If oValidation.ValidateCDP(ThisClient, "", "", True) = False Then
                Me.ShowMessage("Invalid client.")
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), ThisClient, "", "") = False Then
                Me.ShowMessage("Access to client is denied.")
                Exit Function
            End If
        End If
        If ThisDiv <> "" Then
            If oValidation.ValidateCDP(ThisClient, ThisDiv, "", True) = False Then
                Me.ShowMessage("Invalid division.")
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), ThisClient, ThisDiv, "") = False Then
                Me.ShowMessage("Access to client is denied.")
                Exit Function
            End If
        End If
        If ThisProd <> "" Then
            If oValidation.ValidateCDP(ThisClient, ThisDiv, ThisProd, True) = False Then
                Me.ShowMessage("Invalid product.")
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), ThisClient, ThisDiv, ThisProd) = False Then
                Me.ShowMessage("Access to client is denied.")
                Exit Function
            End If
        End If
        ThisExpenseDetail.CL_CODE = ThisClient
        ThisExpenseDetail.DIV_CODE = ThisDiv
        ThisExpenseDetail.PRD_CODE = ThisProd
        ThisExpenseDetail.JOB_NBR = ThisJob
        ThisExpenseDetail.JOB_COMP_NBR = ThisJobComp

        'Check Function
        If FunctCat = "" Then
            Me.ShowMessage("Function is a required field.")
            Exit Function
        End If
        If oValidation.ValidateFunctionCategoryAll(Me.Label_EmployeeCode.Text.Trim, FunctCat, "V", False) = False Then
            Me.ShowMessage(FunctCat & " is an invalid function.")
            Exit Function
        Else
            ThisExpenseDetail.FNC_CODE = FunctCat
        End If

        'Qty
        If Qty <> "" And Qty <> String.Empty Then
            If IsNumeric(Qty) = False Then
                Me.ShowMessage(Qty & " is not a numeric quantity.")
                Exit Function
            Else
                ThisExpenseDetail.QTY = CInt(Qty)
            End If
        End If

        'Check Rate
        If Rate <> "" Then
            If IsNumeric(Rate) = False Then
                Me.ShowMessage(Rate & " is not a numeric rate.")
                Exit Function
            Else
                ThisExpenseDetail.RATE = CDec(Rate)
            End If
        End If

        'Check Amount
        If Amount = "" Then
            Me.ShowMessage("You need to enter an Amount.")
            Exit Function
        Else
            If IsNumeric(Amount) = False Then
                Me.ShowMessage(Amount & " is not a numeric amount.")
                Exit Function
            Else
                ThisExpenseDetail.AMOUNT = CDec(Amount)
            End If
        End If

        'Check Description
        If ItemDesc = "" Then
            Me.ShowMessage("You need to enter a Description.")
            Exit Function
        Else
            ThisExpenseDetail.ITEM_DESC = ItemDesc
        End If

        ThisExpenseDetail.CC_FLAG = CreditCard
        ThisExpenseDetail.CREATE_USER_ID = Session("UserCode")
        '---------------------------------------------------------------------------------
        'CTB: 06/06/2006 - Date was storing as a date only when date and time were needed.
        '---------------------------------------------------------------------------------
        ThisExpenseDetail.MOD_DATE = DateTime.Now.ToString
        ThisExpenseDetail.MOD_USER_ID = Session("UserCode")

        Return ThisExpenseDetail

    End Function
    Private Sub CallJavaScript(ByVal pScript As String)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">"
        strScript &= pScript & "</script>"
        If Not Page.IsStartupScriptRegistered("Webvantage") Then
            Page.RegisterStartupScript("Webvantage", strScript)
        End If
    End Sub
    Private Function SetApproval(ByVal InvNbr As String, ByVal ThisDate As String)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
            Dim NowDate As Date = Now
            Dim url As String = String.Empty
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = String.Empty

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath

                WebvantageURL = Agency.WebvantageURL

                'If Not [String].IsNullOrWhiteSpace(Agency.WebvantageURL) Then

                '    WebvantageURL = New UriBuilder(Agency.WebvantageURL).ToString

                'Else

                '    WebvantageURL = url

                'End If
                If WebvantageURL.EndsWith("/") = False Then

                    WebvantageURL = WebvantageURL & "/"

                End If
                With FxAlert

                    .AlertTypeID = 3
                    .AlertCategoryID = 45
                    .Subject = "Expense Report Approval Request for " & GetEmpFullName(Me.Label_EmployeeCode.Text) & " for Invoice " & InvNbr
                    .Body = "<a href='" & WebvantageURL & "SupervisorApproval_Expense.aspx?sedate=" & ThisDate & "&empcode=" & Me.Label_EmployeeCode.Text & " '> Click here to navigate to Expense Approval.</a>"
                    .GeneratedDate = NowDate
                    .LastUpdated = NowDate
                    .PriorityLevel = 2
                    .EmployeeCode = Me.Label_EmployeeCode.Text
                    .UserCode = Session("UserCode")

                End With

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Session("ConnString"))
                    Alert.LoadByPrimaryKey(FxAlert.ID)
                    Alert.AddAlertRecipient(GetEmpSuper(Me.Label_EmployeeCode.Text))

                    SendEmailAlert(FxAlert.ID)

                Else

                    Me.ShowMessage("Alert failed to save")

                End If

            End If

        End Using

    End Function
    Private Function SendEmailAlert(ByVal AlertID As Integer) As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .AppName = "Expense"
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
    Private Function GetSendAlertSuper() As Boolean
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As Integer

        If GetEmpSuper(Me.Label_EmployeeCode.Text) <> "" Then
            SQL_STR = "SELECT ISNULL(EXP_APPR_REQ, 0) FROM EMPLOYEE WHERE EMP_CODE = '" & Me.Label_EmployeeCode.Text & "'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
                dr.Read()
                value = dr.GetInt16(0)
                If value = 1 Then
                    Return True
                Else
                    Return False
                End If

            Catch
                Err.Raise(Err.Number, "Class:Expense_Edit.aspx Routine:GetSendAlertSuper", Err.Description)
            End Try
        Else
            Return False
        End If

    End Function
    Private Function superApprNeeded() As Boolean
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As Integer

        SQL_STR = "SELECT ISNULL(EXP_APPR_REQ, 0) FROM EMPLOYEE WHERE EMP_CODE = '" & Me.Label_EmployeeCode.Text & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetInt16(0)
            If value = 1 Then
                Return True
            Else
                Return False
            End If

        Catch
            Err.Raise(Err.Number, "Class:Expense_Edit.aspx Routine:superApprNeeded", Err.Description)
        End Try


    End Function
    Private Function GetEmpSuper(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String

        SQL_STR = "SELECT CASE WHEN EXP_RPT_APPROVER IS NOT NULL THEN EXP_RPT_APPROVER ELSE ISNULL(SUPERVISOR_CODE,'') END FROM EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)

            Return value

        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        End Try
    End Function
    Private Function GetEmpFullName(ByVal emp_code As String) As String
        Dim SQL_STR As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim value As String

        SQL_STR = "SELECT ISNULL(EMP_FML,'') FROM V_ACTIVE_EMPLOYEE WHERE EMP_CODE = '" & emp_code & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STR)
            dr.Read()
            value = dr.GetString(0)

            Return value

        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
        End Try
    End Function
    Public Function SetText(Optional ByVal ShowOpposite As Boolean = False) As Boolean

        'objects
        Dim Text As Boolean = False

        Select Case _WebvantageExpenseStatus

            Case ExpenseStatus.Open

                If ShowOpposite = False Then

                    Text = True

                Else

                    Text = False

                End If

            Case ExpenseStatus.Pending

                If ShowOpposite = False Then

                    Text = False

                Else

                    Text = True

                End If

            Case ExpenseStatus.Approved

                If ShowOpposite = False Then

                    Text = False

                Else

                    Text = True

                End If

        End Select

        SetText = Text

    End Function
    Public Function SetLabel() As Boolean

        'objects 
        Dim Label As Boolean = False

        Select Case _WebvantageExpenseStatus

            Case ExpenseStatus.Open

                Label = False

            Case ExpenseStatus.Pending

                Label = True

            Case ExpenseStatus.Approved

                Label = True

        End Select

        SetLabel = Label

    End Function
    Public Function NoZero(ByVal Value As Integer) As String

        'objects
        Dim ReturnValue As String = ""

        If Value > 0 Then

            ReturnValue = Value.ToString

        Else

            ReturnValue = ""

        End If

        NoZero = ReturnValue

    End Function
    'Private Sub SetTotals(ByVal Invoice As Integer)

    '    'If Invoice > 0 Then
    '    '    Dim oExpense As cExpense = New cExpense(Session("ConnString"))
    '    '    Dim dr As SqlDataReader
    '    '    Dim str As String
    '    '    Dim nbr As Decimal
    '    '    dr = oExpense.GetExpenseTotals(Invoice)

    '    '    If dr.HasRows Then
    '    '        Do While dr.Read
    '    '            'Me.lblTotalExpense.Text = CStr(dr("EXPENSE_AMOUNT"))
    '    '            nbr = dr("EXPENSE_AMOUNT")
    '    '            Me.lblTotalExpense.Text = nbr.ToString("#,##0.00")

    '    '            'Me.lblCreditCard.Text = CStr(dr("CC_AMT_TOTAL"))
    '    '            nbr = dr("CC_AMT_TOTAL")
    '    '            Me.lblCreditCard.Text = nbr.ToString("#,##0.00")

    '    '            'Me.lblTotalDue.Text = CStr(dr("TOTAL_EXPENSE"))
    '    '            nbr = dr("TOTAL_EXPENSE")
    '    '            Me.lblTotalDue.Text = nbr.ToString("#,##0.00")
    '    '        Loop
    '    '    End If

    '    '    dr.Close()
    '    '    dr = Nothing
    '    'Else
    '    '    Me.lblTotalExpense.Text = "0.00"
    '    '    Me.lblCreditCard.Text = "0.00"
    '    '    Me.lblTotalDue.Text = "0.00"
    '    'End If

    'End Sub

#End Region

End Class
