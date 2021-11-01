Imports System.Web.Mvc
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports Webvantage.ViewModels.LookupObjects
Imports System.Web.Routing
Imports AdvantageFramework.ViewModels.Employee
Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports AdvantageFramework
Imports Ionic.Zip
Imports System.IO
Imports AdvantageFramework.FileSystem.Methods

Namespace Controllers.Employee

    Public Class ExpenseReportsController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Employee/ExpenseReports/"


        Public Const GridName As String = "ExpenseReportGrid"

        Public Const ColQuantity_Rate As String = "Quantity_Rate"
        Public Const ColClient As String = "Client"
        Public Const ColDivision As String = "Division"
        Public Const ColProduct As String = "Product"
        Public Const ColJob_Component As String = "Job_Component"





#End Region

#Region " Variables "

        Private _ControllerExpenseReports As AdvantageFramework.Controller.Employee.ExpenseReportSetupController = Nothing

#End Region

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _ControllerExpenseReports = New AdvantageFramework.Controller.Employee.ExpenseReportSetupController(Me.SecuritySession)

        End Sub

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Employee_ExpenseReports")>
        Public Function Index(EmpCode As String) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/employee/expense-reports/expense-reports"

            If (Not EmpCode = "") Then

                AureliaModel.Parameters.Add("EmployeeCode", EmpCode)

            End If

            Return Aurelia(AureliaModel)

        End Function
#Region " MVC Views "


        Public Function NewExpenseReport(EmpCode As String, invoice As String) As ActionResult

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeFullName As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim HasVendor As Boolean = False
            Dim VendorCode As String = Nothing
            Dim ExpenseReportEmployee As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing

            'Dim ExpenseReportHeader As AdvantageFramework.ViewModels.Employee.ExpenseReportHeader = New ExpenseReportHeader()

            'Me.PageTitle = "New Expense Report"

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If Request.QueryString("empcode") <> "" Then
                    EmployeeCode = Request.QueryString("empcode")
                Else
                    If invoice <> "" And invoice <> Nothing And invoice <> "new" Then

                        Try
                            'Get the expense report
                            ExpenseReportEmployee = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                                     Where Entity.InvoiceNumber = invoice
                                                     Order By Entity.InvoiceNumber Descending
                                                     Select Entity).ToList _
                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList _
                                        .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReport.FromClass(Entity)).ToList.FirstOrDefault()


                        Catch ex As Exception
                            ExpenseReportEmployee = New AdvantageFramework.DTO.Employee.ExpenseReport
                        End Try

                    End If
                    If ExpenseReportEmployee IsNot Nothing Then
                        EmployeeCode = ExpenseReportEmployee.EmployeeCode
                    Else
                        EmployeeCode = Me.SecuritySession.User.EmployeeCode
                    End If

                End If

                If String.IsNullOrWhiteSpace(EmployeeCode) Then

                    'Me.Label_EmployeeCode.Text = Session("EmpCode").ToString()
                    'Me.Label_EmployeeName.Text = Session("EmployeeName").ToString()

                Else

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        'EmployeeCode = Employee.Code
                        EmployeeFullName = Employee.FirstName + " " + Employee.MiddleInitial + " " + Employee.LastName
                        VendorCode = Employee.EmployeeVendorCode
                    Else

                    End If

                End If


            End Using

            If HasVendor = False Then

                'Me.ShowMessage("This employee code is not associated with a vendor code")
                'Me.CloseThisWindow()

            End If

            'get expense report
            Dim ExpenseReport As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing
            Dim ExpenseReportGetStatus As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = Nothing
            Dim LabelStatusInfo As String
            Dim Image_Status As String = "display: none;"
            Dim CanAdd As Boolean = False
            Dim CanUpdate As Boolean = False
            Dim CanPrint As Boolean = False
            Dim Custom1 As Boolean = False
            Dim Custom2 As Boolean = False


            If invoice <> "" And invoice <> Nothing And invoice <> "new" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        If (invoice = 0) Then
                            Throw New System.Exception("Invalid parameters")
                        End If

                        'Get the expense report
                        ExpenseReport = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                         Where Entity.InvoiceNumber = invoice
                                         Order By Entity.InvoiceNumber Descending
                                         Select Entity).ToList _
                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList _
                                        .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReport.FromClass(Entity)).ToList.FirstOrDefault()


                    Catch ex As Exception
                        ExpenseReport = New AdvantageFramework.DTO.Employee.ExpenseReport
                    End Try
                End Using

                'get details
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try
                        ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, invoice, False)
                                             Order By Entity.LineNumber
                                             Select Entity).ToList _
                                         .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).ToList
                    Catch ex As Exception
                        ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
                    End Try

                End Using

                'Temp Check how many lines
                Dim LineItemCount As Integer = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        LineItemCount = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, invoice, False)
                                         Select Entity).Count

                    Catch ex As Exception
                        LineItemCount = 0
                    End Try

                End Using

                'End temp check how many lines

                'Check Status
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    ExpenseReportGetStatus = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, invoice)

                    If ExpenseReportGetStatus IsNot Nothing Then

                        ExpenseReportStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReportGetStatus)
                        If ExpenseReport.Status Is Nothing Then
                            ExpenseReport.Status = 0
                        End If
                        If ExpenseReport.IsSubmitted Is Nothing Then
                            ExpenseReport.IsSubmitted = 0
                        End If
                        If ExpenseReport.IsApproved Is Nothing Then
                            ExpenseReport.IsApproved = 0
                        End If
                        'ExpenseReport.Status = ExpenseReportStatus
                        ExpenseReport.CreatedBy = ExpenseReportGetStatus.CreatedBy


                        LabelStatusInfo = AdvantageFramework.ExpenseReports.LoadStatusTooltip(DbContext, ExpenseReportGetStatus)

                        If Not String.IsNullOrWhiteSpace(LabelStatusInfo) Then

                            Image_Status = "visibility: visible; margin-left:2px;margin-right:2px;"
                            'Image_Status.ImageUrl = "Images/information-trans.png"

                        Else

                            Image_Status = "display: none;"

                        End If
                    End If


                End Using


            Else
                ExpenseReport = New DTO.Employee.ExpenseReport
                ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
            End If

            LoadExpenseReportSecurity(CanAdd, CanUpdate, CanPrint, Custom1, Custom2)

            ViewBag.ExpenseReportHeader = ExpenseReport
            'If ExpenseReport.InvoiceDate Is Nothing Then
            '    ExpenseReport.InvoiceDate = Date.Now
            'End If
            ViewBag.ExpenseReportDetails = ExpenseReportList
            ViewBag.EmployeeJson = GetEmployee(EmployeeCode)
            ViewBag.EmployeeCode = EmployeeCode
            ViewBag.UserCode = Me.SecuritySession.UserCode
            ViewBag.EmployeeFullName = EmployeeFullName
            ViewBag.FunctionCodes = GetFunctionCodes()
            'ViewBag.Clients = GetClients()
            ViewBag.PaymentTypes = GetPaymentTypes()
            ViewBag.Jobs = GetAllJobs()
            ViewBag.ColumnSettings = GetGridColumnSettings()

            If invoice <> "" And invoice <> Nothing And invoice <> "new" Then
                ViewBag.UploadedImages = GetReceiptsList(invoice)
                ViewBag.PageTitle = "EX " & invoice & " - " & ExpenseReport.Description
            Else
                ViewBag.UploadedImages = GetReceiptsList(Nothing)
                ViewBag.PageTitle = "New Expense Report"
            End If

            ViewBag.LabelStatusInfo = LabelStatusInfo
            ViewBag.Image_Status = Image_Status
            'ViewBag.ReportDetails = ReportDetails
            ViewBag.CanAdd = CanAdd
            ViewBag.CanUpdate = CanUpdate
            ViewBag.CanPrint = CanPrint
            ViewBag.Custom1 = Custom1
            ViewBag.Custom2 = Custom2

            ViewBag.PageSize = GetExpenseReportPageSize()
            ViewBag.DefaultPaymentType = GetDefaultPaymentType()
            ViewBag.HasDocuments = GetHasDocuments(ExpenseReport.InvoiceNumber)
            ViewBag.ReceiptCount = GetReceiptCount(ExpenseReport.InvoiceNumber)

            Return View()

        End Function

        Public Function ExpenseReportSubmit(ByVal InvoiceNumber As Integer) As ActionResult

            'objects
            'Dim QueryString As New AdvantageFramework.Web.QueryString()
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim AltApprover As AdvantageFramework.Database.Views.Employee = Nothing
            Dim MainApprover As AdvantageFramework.Database.Views.Employee = Nothing

            'Dim InvoiceNumber As Integer
            Dim ExpenseEmployee As String = String.Empty
            Dim Supervisor As String = String.Empty
            Dim SupervisorCode As String = String.Empty
            Dim AlternateApprover As String = String.Empty
            Dim Employees As IEnumerable
            Dim SelectedEmployee As String = ""

            'Dim responseObj As New AdvantageFramework.ViewModels.Employee.ExpenseReportSubmitOptions
            'responseObj.InvoiceNumber = InvoiceNumber

            'QueryString = QueryString.FromCurrent()
            ' Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))
            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) = False Then
                                'Submit(False)
                            Else

                                'Button_Submit.CommandArgument = "1"

                                'Label_ExpenseEmployee.Text = Employee.ToString
                                ExpenseEmployee = Employee.ToString

                                'RadComboBox_Employees.DataSource = (From Entity In AdvantageFramework.ExpenseReports.LoadAvailableApprovers(_Session, DbContext, SecurityDbContext, Employee.Code)
                                'Select Case Entity.Code,
                                '[Name] = Entity.ToString).ToList

                                'RadComboBox_Employees.DataBind()

                                'RadComboBox_Employees.SelectedValue = Nothing
                                Dim myList As IEnumerable
                                myList = (From Entity In AdvantageFramework.ExpenseReports.LoadAvailableApprovers(Me.SecuritySession, DbContext, SecurityDbContext, Employee.Code)
                                          Select New With {.Code = Entity.Code, .Name = Entity.FirstName & " " & Entity.LastName}).ToList

                                Employees = myList
                                'Jobs = (From Item In _ControllerExpenseReports.LoadAllJobs()
                                '                    Order By Item.ClientCode
                                '                    Select New With {.ClientCode = Item.ClientCode,
                                '     .ClientName = Item.ClientName,
                                '     .JobDescription = Item.JobDescription,

                                '     .Number = Item.JobNumber,
                                '     .Description = PadJobNumber(Item.JobNumber) + "/" +
                                '        PadJobComponentNumber(Item.JobComponentNumber) + " - " +
                                '        Item.JobComponentDescription}).ToList



                                Try

                                    If String.IsNullOrWhiteSpace(Employee.AlternateApproverCode) = False Then

                                        AltApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.AlternateApproverCode)

                                        If AltApprover IsNot Nothing Then

                                            AlternateApprover = AltApprover.ToString
                                            'Label_AlternateApprover.Text = AltApprover.ToString

                                            If AltApprover.TerminationDate.HasValue = False Then

                                                'RadComboBox_Employees.SelectedValue = Employee.AlternateApproverCode

                                                SelectedEmployee = Employee.AlternateApproverCode
                                                SupervisorCode = Employee.AlternateApproverCode
                                            End If

                                        Else

                                            'Label_AlternateApprover.Text = ""
                                            AlternateApprover = ""

                                        End If

                                    End If

                                Catch ex As Exception
                                    'Label_AlternateApprover.Text = ""
                                    AlternateApprover = ""
                                End Try

                                Try

                                    If String.IsNullOrWhiteSpace(Employee.SupervisorEmployeeCode) = False Then

                                        MainApprover = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                                        If MainApprover IsNot Nothing Then
                                            Supervisor = MainApprover.ToString
                                            'SupervisorCode = Employee.SupervisorEmployeeCode
                                            'Label_Supervisor.Text = MainApprover.ToString

                                            If SelectedEmployee = "" Then

                                                If MainApprover.TerminationDate.HasValue = False Then

                                                    'RadComboBox_Employees.SelectedValue = Employee.SupervisorEmployeeCode
                                                    SelectedEmployee = Employee.SupervisorEmployeeCode
                                                    SupervisorCode = Employee.SupervisorEmployeeCode
                                                End If

                                            End If

                                        Else

                                            'Label_Supervisor.Text = ""
                                            Supervisor = ""
                                        End If

                                    End If

                                Catch ex As Exception
                                    'Label_Supervisor.Text = ""
                                    Supervisor = ""
                                End Try

                            End If

                        End If

                    End If

                End Using

            End Using


            ViewBag.InvoiceNumber = InvoiceNumber
            ViewBag.ExpenseEmployee = ExpenseEmployee
            ViewBag.Supervisor = Supervisor
            ViewBag.AlternateApprover = AlternateApprover
            ViewBag.Employees = Employees
            ViewBag.SelectedEmployee = SelectedEmployee
            ViewBag.SupervisorCode = SupervisorCode


            Return View()


        End Function

        Public Function ExpenseReportCopy(ByVal InvoiceNumber As Integer) As ActionResult

            Dim listEmployee As IEnumerable

            Dim QueryString As New AdvantageFramework.Web.QueryString()
            QueryString = QueryString.FromCurrent()


            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    listEmployee = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(Me.SecuritySession, DbContext, SecurityDbContext, False).ToList
                                    Select Entity.Code, [Name] = Entity.ToString).ToList

                    'RadCombobox_Employee.DataBind()
                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                    Try
                        ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False)
                                             Order By Entity.LineNumber
                                             Select Entity).ToList _
                                         .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).ToList
                    Catch ex As Exception
                        ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
                    End Try

                End Using

            End Using

            If ExpenseReport IsNot Nothing Then

                ViewBag.EmployeeList = listEmployee
                ViewBag.InvoiceNumber = ExpenseReport.InvoiceNumber
                ViewBag.EmployeeSelectedValue = ExpenseReport.EmployeeCode
                ViewBag.ReportDate = ExpenseReport.InvoiceDate
                ViewBag.Description = ExpenseReport.Description
                If ExpenseReport.Details IsNot Nothing Then
                    ViewBag.Details = ExpenseReport.Details
                Else
                    ViewBag.Details = ""
                End If

            End If

            Return View()


        End Function

        Public Function ExpenseReportPrint(ByVal InvoiceNumber As Integer) As ActionResult

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            'Me.Title = "Expense Report"

            CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)

            If InvoiceNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                End Using

            End If

            If ExpenseReport Is Nothing Then
                'Me.ShowMessage("Error printing expense report!")
                'Me.CloseThisWindow()
                'Return
            End If

            ViewBag.InvoiceNumber = ExpenseReport.InvoiceNumber

            Return View()
        End Function

        Public Function ExpenseReportImport(ByVal InvoiceNumber As Integer, ByVal EmpCode As String)

            Dim EmployeeCode As String = Nothing
            Dim ExpenseReport As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing

            If String.IsNullOrWhiteSpace(EmpCode) = False Then
                EmployeeCode = EmpCode
            Else
                EmployeeCode = Me.SecuritySession.User.EmployeeCode
            End If


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    'If (InvoiceNumber = 0) Then
                    '    Throw New System.Exception("Invalid parameters")
                    'End If

                    'Get the expense report
                    If (InvoiceNumber > 0) Then
                        ExpenseReport = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                         Where Entity.InvoiceNumber = InvoiceNumber
                                         Order By Entity.InvoiceNumber Descending
                                         Select Entity).ToList _
                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList _
                                        .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReport.FromClass(Entity)).ToList.FirstOrDefault()


                    End If

                Catch ex As Exception
                    ExpenseReport = New AdvantageFramework.DTO.Employee.ExpenseReport
                End Try
            End Using


            ViewBag.InvoiceNumber = InvoiceNumber
            ViewBag.EmployeeJson = GetEmployee(EmployeeCode)
            ViewBag.FunctionCodes = GetFunctionCodes()
            ViewBag.PaymentTypes = GetPaymentTypes()
            ViewBag.Jobs = GetAllJobs()
            If ExpenseReport IsNot Nothing Then
                ViewBag.Description = ExpenseReport.Description
                ViewBag.InvoiceDate = CDate(ExpenseReport.InvoiceDate).ToShortDateString
            End If
            ViewBag.ImportTemplates = GetImportTemplates(EmployeeCode)
            ViewBag.DefaultPaymentType = GetDefaultPaymentType()


            Return View()

        End Function


        Public Function UploadReceipts(ByVal InvoiceNumber As Integer, ByVal EmpCode As String, ByVal Status As Integer)

            Dim EmployeeCode As String = Nothing
            Dim CanAdd As Boolean = False
            Dim CanUpdate As Boolean = False
            Dim CanPrint As Boolean = False
            Dim Custom1 As Boolean = False
            Dim Custom2 As Boolean = False
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = Nothing

            If String.IsNullOrWhiteSpace(EmpCode) = False Then
                EmployeeCode = EmpCode
            Else
                EmployeeCode = Me.SecuritySession.User.EmployeeCode
            End If



            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try
                    ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False)
                                         Order By Entity.LineNumber
                                         Select Entity).ToList _
                                         .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).ToList
                Catch ex As Exception
                    ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
                End Try

            End Using

            LoadExpenseReportSecurity(CanAdd, CanUpdate, CanPrint, Custom1, Custom2)

            ViewBag.InvoiceNumber = InvoiceNumber
            ViewBag.Status = Status
            ViewBag.UserCode = Me.SecuritySession.UserCode
            ViewBag.EmployeeJson = GetEmployee(EmployeeCode)
            ViewBag.FunctionCodes = GetFunctionCodes()
            ViewBag.PaymentTypes = GetPaymentTypes()
            ViewBag.Jobs = GetAllJobs()
            ViewBag.AppVars = GetUploaderButtonStates()
            ViewBag.PrintSettings = GetPrintSettings()

            ViewBag.UploadedImages = GetReceiptsList(InvoiceNumber)
            ViewBag.UnassignedImages = GetReceiptsListUnassigned(EmployeeCode)
            ViewBag.ExpenseReportDetails = ExpenseReportList
            ViewBag.CanAdd = CanAdd
            ViewBag.CanUpdate = CanUpdate
            ViewBag.CanPrint = CanPrint
            ViewBag.Custom1 = Custom1
            ViewBag.Custom2 = Custom2
            ViewBag.DefaultPaymentType = GetDefaultPaymentType()


            Return View()

        End Function

        Public Function ExpenseReportReceipts(ByVal InvoiceNumber As Integer, ByVal EmpCode As String)

            Dim EmployeeCode As String = Nothing


            If String.IsNullOrWhiteSpace(EmpCode) = False Then
                EmployeeCode = EmpCode
            Else
                EmployeeCode = Me.SecuritySession.User.EmployeeCode
            End If



            ViewBag.InvoiceNumber = InvoiceNumber
            ViewBag.EmployeeJson = GetEmployee(EmployeeCode)
            'ViewBag.FunctionCodes = GetFunctionCodes()
            'ViewBag.PaymentTypes = GetPaymentTypes()
            'ViewBag.Jobs = GetAllJobs()

            ViewBag.UploadedImages = GetReceiptsList(InvoiceNumber)


            Return View()

        End Function

#End Region





#Region " API "

#Region " Public "

        'Public Function GetReportDetails(ByVal InvoiceNumber As String) As JsonResult

        '    Dim inum = InvoiceNumber

        '    Dim ReportDetails As List(Of AdvantageFramework.ViewModels.Employee.ExpenseReportDetail) = New List(Of AdvantageFramework.ViewModels.Employee.ExpenseReportDetail)

        '    Dim rd As AdvantageFramework.ViewModels.Employee.ExpenseReportDetail = New AdvantageFramework.ViewModels.Employee.ExpenseReportDetail
        '    rd.Date = DateTime.Now
        '    rd.Description = "Test description"
        '    rd.Client = "client"
        '    rd.Division = "dev"
        '    rd.Product = "product"

        '    ReportDetails.Add(rd)
        '    rd.Client = "another client"
        '    ReportDetails.Add(rd)

        '    Return Json(ReportDetails, Mvc.JsonRequestBehavior.AllowGet)
        'End Function

        Public Function InitExpenseEdit(ByVal InvoiceNumber As Integer) As JsonResult

            'objects
            Dim Functions As IEnumerable = Nothing
            Dim PaymentTypes As IEnumerable = Nothing

            Functions = (From Item In _ControllerExpenseReports.LoadFunctionCodes
                         Order By Item.Description Ascending
                         Select New With {.value = Item.Code,
                                          .text = Item.Description,
                                          .BillingRate = Item.BillingRate,
                                          .NonBillableFlag = Item.NonBillableFlag}).ToList

            PaymentTypes = (From Item In _ControllerExpenseReports.GetPaymentTypes()
                            Order By Item.Description Ascending
                            Select New With {.value = Item.Value,
                                             .text = Item.Description}).ToList.ToList

            Return Json(New With {.Functions = Functions, .PaymentTypes = PaymentTypes}, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReport(InvoiceNumber As Integer) As JsonResult

            'objects
            Dim ExpenseReportList As AdvantageFramework.DTO.Employee.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    If (InvoiceNumber = 0) Then
                        Throw New System.Exception("Invalid parameters")
                    End If

                    'Get the expense report
                    ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                         Where Entity.InvoiceNumber = InvoiceNumber
                                         Order By Entity.InvoiceNumber Descending
                                         Select Entity).ToList _
                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList _
                                        .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReport.FromClass(Entity)).ToList.FirstOrDefault()


                Catch ex As Exception
                    ExpenseReportList = New AdvantageFramework.DTO.Employee.ExpenseReport
                End Try

            End Using

            Return Json(ExpenseReportList, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReports(ByVal EmployeeCode As String, ByVal ShowOpen As Boolean,
                                          ByVal ShowPending As Boolean, ByVal ShowDenied As Boolean,
                                          ByVal ShowApproved As Boolean, ByVal ClientCode As String,
                                          ByVal FunctionCode As String, ByVal JobCode As Integer,
                                          ByVal StartDate As DateTime?, ByVal EndDate As DateTime?,
                                          ByVal ItemDate As DateTime?, ByVal DescriptionSearch As String,
                                          ByVal ExcludePaid As Boolean, ByVal ExcludeUnpaid As Boolean) As JsonResult

            'objects
            Dim ExpenseReportList As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@EmployeeCode", EmployeeCode))
                arParams.Add(New SqlParameter("@ShowOpen", If(ShowOpen = True, 1, 0)))
                arParams.Add(New SqlParameter("@ShowPending", If(ShowPending = True, 1, 0)))
                arParams.Add(New SqlParameter("@ShowApproved", If(ShowApproved = True, 1, 0)))
                arParams.Add(New SqlParameter("@ShowDenied", If(ShowDenied = True, 1, 0)))
                arParams.Add(New SqlParameter("@ExcludePaid", If(ExcludePaid = True, 1, 0)))
                arParams.Add(New SqlParameter("@ExcludeUnpaid", If(ExcludeUnpaid = True, 1, 0)))

                Dim StartDateParameter As SqlParameter = New SqlParameter("@StartDate", SqlDbType.Date)
                StartDateParameter.IsNullable = True
                StartDateParameter.Value = If(StartDate Is Nothing, DBNull.Value, StartDate)
                arParams.Add(StartDateParameter)

                Dim EndDateParameter As SqlParameter = New SqlParameter("@EndDate", SqlDbType.Date)
                EndDateParameter.IsNullable = True
                EndDateParameter.Value = If(EndDate Is Nothing, DBNull.Value, EndDate)
                arParams.Add(EndDateParameter)

                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@JobCode", JobCode))
                arParams.Add(New SqlParameter("@FunctionCode", FunctionCode))
                arParams.Add(New SqlParameter("@DescriptionSearch", DescriptionSearch))

                Dim ItemDateParameter As SqlParameter = New SqlParameter("@ItemDate", SqlDbType.Date)
                ItemDateParameter.IsNullable = True
                ItemDateParameter.Value = If(ItemDate Is Nothing, DBNull.Value, ItemDate)
                arParams.Add(ItemDateParameter)

                ExpenseReportList = (From Item In DbContext.Database.SqlQuery(Of ExpenseReportHeaderDTO)("EXEC usp_wv_GetExpneseReports @UserID, @EmployeeCode, @ShowOpen, @ShowPending, @ShowApproved, @ShowDenied, @StartDate, @EndDate, @ClientCode, @JobCode, @FunctionCode, @DescriptionSearch, @ItemDate,@ExcludePaid,@ExcludeUnpaid", arParams.ToArray)
                                     Select New With {.InvoiceNumber = Item.InvoiceNumber,
                                         .ReportDate = Item.InvoiceDate.AddHours(-Offset),
                                         .CreatedDate = If(Item.CreatedDate IsNot Nothing, Item.CreatedDate.Value.AddHours(-Offset), Item.CreatedDate),
                                         .Description = Item.Description,
                                         .Status = Item.StatusCode,
                                         .TotalNonBillable = Item.TotalNonBillable,
                                         .TotalBillable = Item.TotalBillable,
                                         .TotalAmount = Item.TotalAmount,
                                         .Paid = Item.Paid,
                                         .ApprovedBy = Item.ApprovedBy,
                                         .ApprovedDate = If(Item.ApprovedDate IsNot Nothing, Item.ApprovedDate.Value.AddHours(-Offset), Item.ApprovedDate),
                                         .HasDocuments = Item.HasDocuments,
                                         .AttachmentCount = Item.AttachmentCount
                                                       }).ToList

            End Using

            Return Json(ExpenseReportList, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function GetExpenseReportsSample(ByVal Count As Integer?) As JsonResult

            'objects
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReport) = Nothing


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    If Count.GetValueOrDefault(0) <= 0 Then

                        Count = 5

                    End If

                    ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                         Order By Entity.InvoiceNumber Descending
                                         Select Entity).Take(Count).ToList _
                                        .Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReport(Entity, DbContext)).ToList _
                                        .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReport.FromClass(Entity)).ToList

                Catch ex As Exception
                    ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReport)
                End Try

                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)
                For Each _ExpenseReport In ExpenseReportList
                    If _ExpenseReport.ApprovedDate IsNot Nothing Then
                        _ExpenseReport.ApprovedDate = _ExpenseReport.ApprovedDate.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.BatchDate IsNot Nothing Then
                        _ExpenseReport.BatchDate = _ExpenseReport.BatchDate.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.CreatedDate IsNot Nothing Then
                        _ExpenseReport.CreatedDate = _ExpenseReport.CreatedDate.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.DateFrom IsNot Nothing Then
                        _ExpenseReport.DateFrom = _ExpenseReport.DateFrom.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.DateTo IsNot Nothing Then
                        _ExpenseReport.DateTo = _ExpenseReport.DateTo.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.InvoiceDate IsNot Nothing Then
                        _ExpenseReport.InvoiceDate = _ExpenseReport.InvoiceDate.Value.AddHours(-Offset)
                    End If
                    If _ExpenseReport.ModifiedDate IsNot Nothing Then
                        _ExpenseReport.ModifiedDate = _ExpenseReport.ModifiedDate.Value.AddHours(-Offset)
                    End If
                Next

            End Using

            Return Json(ExpenseReportList, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReportDetails(InvoiceNumber As Integer) As JsonResult

            'objects
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try
                    ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber.ToString(), False)
                                         Order By Entity.LineNumber
                                         Select Entity).ToList _
                                         .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).ToList


                Catch ex As Exception
                    ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
                End Try

                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)
                For Each _ExpenseReport In ExpenseReportList
                    If _ExpenseReport.ItemDate IsNot Nothing Then
                        _ExpenseReport.ItemDate = _ExpenseReport.ItemDate.Value.AddHours(-Offset)
                    End If
                Next

            End Using

            Return Json(ExpenseReportList, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReportDetail(ID As Integer) As JsonResult

            'objects
            Dim ExpenseReport As AdvantageFramework.DTO.Employee.ExpenseReportDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try


                    ExpenseReport = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.Load(DbContext, False)
                                     Where Entity.ID = ID
                                     Select Entity).ToList _
                                     .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).FirstOrDefault


                Catch ex As Exception
                    ExpenseReport = New AdvantageFramework.DTO.Employee.ExpenseReportDetail
                End Try

                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)
                If ExpenseReport.ItemDate IsNot Nothing Then
                    ExpenseReport.ItemDate = ExpenseReport.ItemDate.Value.AddHours(-Offset)
                End If


            End Using

            Return Json(ExpenseReport, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetEmployee(Code As String) As JsonResult

            'objects
            Dim Employee As Object = Nothing
            Dim EmployeeEntity As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    EmployeeEntity = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                      Order By Entity.FirstName, Entity.LastName Descending
                                      Where Entity.Code = Code
                                      Select Entity).FirstOrDefault

                Catch ex As Exception
                    EmployeeEntity = New AdvantageFramework.Database.Views.Employee
                End Try

                Employee = (New With {.Code = EmployeeEntity.Code,
                                      .Name = EmployeeEntity.FirstName + " " + EmployeeEntity.MiddleInitial + " " + EmployeeEntity.LastName,
                                      .TerminationDate = EmployeeEntity.TerminationDate,
                                      .VendorCode = EmployeeEntity.EmployeeVendorCode
                                })

            End Using

            Return Json(Employee, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetEmployeeDefault() As JsonResult

            'objects
            Dim EmployeeCode As String = Me.SecuritySession.User.EmployeeCode
            Return Json(EmployeeCode, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetEmployees() As JsonResult

            'objects
            Dim Employees As IEnumerable = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    EmployeeList = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                    Order By Entity.FirstName, Entity.LastName Descending
                                    Select Entity).ToList

                Catch ex As Exception
                    EmployeeList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                End Try

                Employees = (From Item In EmployeeList
                             Select New With {.Code = Item.Code,
                                              .Name = Item.FirstName + " " + Item.MiddleInitial + " " + Item.LastName,
                                              .TerminationDate = Item.TerminationDate
                                }).ToList

            End Using

            Return Json(Employees, JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpPost>
        Public Function CreateExpenseReports(ByVal ExpenseReports As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReport), ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _ControllerExpenseReports.Add(ExpenseReports.ToList)

            If ExpenseReportDetails IsNot Nothing Then

                If ExpenseReports(0).InvoiceNumber > 0 Then

                    For x = 0 To ExpenseReportDetails.Count - 1 Step +1

                        ExpenseReportDetails(x).InvoiceNumber = ExpenseReports(0).InvoiceNumber

                    Next

                End If

                Created = CreateExpenseReportDetailsNew(ExpenseReportDetails, False)

            End If

            Return Json(ExpenseReports.ToList)

        End Function

        <Mvc.HttpPost>
        Public Function CreateExpenseReportDetails(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail), ByVal isImported As Boolean) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _ControllerExpenseReports.AddDetails(ExpenseReportDetails.ToList, isImported)

            Return Json(Created)

        End Function

        Public Function CreateExpenseReportDetailsNew(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail), ByVal isImported As Boolean) As Boolean

            'objects
            Dim Created As Boolean = False

            Created = _ControllerExpenseReports.AddDetails(ExpenseReportDetails.ToList, isImported)

            Return Created

        End Function


        <Mvc.HttpPost>
        Public Function CreateExpenseReportDetailsWithList(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail), ByVal isImported As Boolean) As Mvc.JsonResult

            'objects
            Dim Created As Boolean = False
            Dim ExpenseReportList As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail) = Nothing

            Dim InvoiceNumber As Integer

            InvoiceNumber = ExpenseReportDetails(0).InvoiceNumber
            Created = _ControllerExpenseReports.AddDetails(ExpenseReportDetails.ToList, isImported)

            If Created = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try
                        ExpenseReportList = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber.ToString(), False)
                                             Order By Entity.LineNumber
                                             Select Entity).ToList _
                                         .Select(Function(Entity) AdvantageFramework.DTO.Employee.ExpenseReportDetail.FromEntity(Entity, DbContext)).ToList

                    Catch ex As Exception
                        ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
                    End Try

                End Using

            Else
                ExpenseReportList = New Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)
            End If

            Return Json(ExpenseReportList, JsonRequestBehavior.AllowGet)

        End Function



        <Mvc.HttpPost>
        Public Function UpdateExpenseReports(ByVal ExpenseReports As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReport)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _ControllerExpenseReports.Save(ExpenseReports.ToList)

            Return Json(Updated)

        End Function

        <Mvc.HttpPost>
        Public Function UpdateExpenseReportDetails(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)) As Mvc.JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _ControllerExpenseReports.SaveDetails(ExpenseReportDetails.ToList)

            Return Json(Updated)

        End Function

        <Mvc.HttpPost>
        Public Function DeleteExpenseReports(ByVal ExpenseReports As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReport)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _ControllerExpenseReports.Delete(ExpenseReports.ToList)

            Return Json(Deleted)

        End Function

        <Mvc.HttpPost>
        Public Function DeleteExpenseReportDetails(ByVal ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _ControllerExpenseReports.DeleteDetails(ExpenseReportDetails.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpPost>
        Public Function DeleteExpenseReportDetailsByIDs(ByVal ExpenseReportDetails As IEnumerable(Of Integer)) As Mvc.JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _ControllerExpenseReports.DeleteDetailsByID(ExpenseReportDetails.ToList)

            Return Json(Deleted)

        End Function
        <Mvc.HttpGet>
        Public Function AddBookmark(Code As String, Month As Integer, Year As Integer) As Boolean

            Dim Employee As AdvantageFramework.Database.Views.Employee

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Code)

                If Employee IsNot Nothing Then

                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    Dim emp As New cEmployee(Session("ConnString"))

                    qs = qs.FromString("Employee_ExpenseReports")
                    qs.Month = Month
                    qs.Year = Year
                    qs.EmployeeCode = Code
                    qs.IsBookmark = True

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports
                        .UserCode = Me.SecuritySession.UserCode
                        .Name = "Expense Reports for " & Employee.FirstName & " " & Employee.LastName & " (" & Microsoft.VisualBasic.MonthName(Month) & ", " & Year & ")"
                        .PageURL = qs.ToString(True)

                    End With

                    Dim s As String = ""

                    AddBookmark = BmMethods.SaveBookmark(b, s)

                End If

            End Using

        End Function

        <Mvc.HttpGet>
        Public Function AddInvoiceBookmark(Code As String, InvoiceNumber As Integer, Description As String) As Mvc.JsonResult


            Dim Employee As AdvantageFramework.Database.Views.Employee

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Code)

                If Employee IsNot Nothing Then

                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    Dim emp As New cEmployee(Session("ConnString"))
                    Dim url As String = ""

                    qs.Add("invoice", InvoiceNumber)
                    qs.Add("empcode", Code)
                    qs.Page = "Employee/ExpenseReports/NewExpenseReport"

                    'url = String.Format("Employee/ExpenseReports/NewExpenseReport?invoice={0}&empcode={1}", InvoiceNumber, Code)
                    'qs = qs.FromString(url)
                    qs.IsBookmark = True

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports
                        .UserCode = Me.SecuritySession.UserCode
                        .Name = Description
                        .PageURL = qs.ToString(True)

                    End With

                    Dim s As String = ""

                    Dim result As Boolean = BmMethods.SaveBookmark(b, s)
                    If result = True Then
                        Return Json("True", JsonRequestBehavior.AllowGet)
                    Else
                        Return Json(s, JsonRequestBehavior.AllowGet)
                    End If

                End If
                Return Json("Employee not found", JsonRequestBehavior.AllowGet)

            End Using


        End Function


        <Mvc.HttpGet>
        Public Function GetFunctionCodes() As Mvc.JsonResult

            'objects
            Dim FunctionCodes As IEnumerable = Nothing

            FunctionCodes = (From Item In _ControllerExpenseReports.LoadFunctionCodes
                             Order By Item.Code Ascending
                             Select New With {.Code = Item.Code,
                                              .Description = Item.Description,
                                              .BillingRate = Item.BillingRate,
                                              .NonBillableFlag = Item.NonBillableFlag}).ToList

            Return Json(FunctionCodes, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetBillingRate(functionCode As String, clientCode As String, divisionCode As String, productCode As String, jobNumber As String, jobcomponentNumber As String, itemDate As Date) As JsonResult

            'objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, functionCode, clientCode, divisionCode, productCode, jobNumber, jobcomponentNumber, Nothing, Nothing, itemDate)
            End Using

            Return Json(BillingRate.BILLING_RATE, JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetClients() As Mvc.JsonResult

            'objects
            Dim Clients As IEnumerable = Nothing

            Clients = (From Item In _ControllerExpenseReports.LoadClients
                       Order By Item.Code Ascending
                       Select New With {.Code = Item.Code,
                                        .Name = Item.Name}).ToList

            Return Json(Clients, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetJobs(ClientCode As String) As Mvc.JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Jobs = (From Item In _ControllerExpenseReports.LoadJobs(ClientCode)
                    Order By Item.JobDescription Ascending
                    Select New With {.Number = Item.JobNumber,
                                     .Description = PadJobNumber(Item.JobNumber) + "/" +
                                        PadJobComponentNumber(Item.JobComponentNumber) + " - " +
                                        Item.JobComponentDescription,
                                     .JobComponentNumber = Item.JobComponentNumber,
                                     .JobComponentDescription = Item.JobComponentDescription,
                                     .ProductCode = Item.ProductCode,
                                     .DivisionCode = Item.DivisionCode}).ToList

            Return Json(Jobs, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetJobsAllData(ClientCode As String) As Mvc.JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Jobs = (From Item In _ControllerExpenseReports.LoadJobs(ClientCode)
                    Order By Item.JobDescription Ascending
                    Select New With {.Number = Item.JobNumber,
                                     .Description = PadJobNumber(Item.JobNumber) + "/" +
                                        PadJobComponentNumber(Item.JobComponentNumber) + " - " +
                                        Item.JobComponentDescription,
                                     .JobDescription = Item.JobDescription,
                                     .JobComponentNumber = Item.JobComponentNumber,
                                     .JobComponentDescription = Item.JobComponentDescription,
                                     .ProductCode = Item.ProductCode,
                                     .ProductName = Item.ProductName,
                                     .DivisionCode = Item.DivisionCode,
                                     .DivisionName = Item.DivisionName}).ToList

            Return Json(Jobs, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetAllJobs() As Mvc.JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Jobs = (From Item In _ControllerExpenseReports.LoadAllJobs()
                    Order By Item.JobNumber Descending
                    Select New With {.ClientCode = Item.ClientCode,
                                     .ClientName = Item.ClientName,
                                     .JobDescription = Item.JobDescription,
                                     .JobComponentNumber = Item.JobComponentNumber,
                                     .JobComponentDescription = Item.JobComponentDescription,
                                     .ProductCode = Item.ProductCode,
                                     .ProductName = Item.ProductName,
                                     .DivisionCode = Item.DivisionCode,
                                     .DivisionName = Item.DivisionName,
                                     .Number = Item.JobNumber,
                                     .Description = PadJobNumber(Item.JobNumber) + "/" +
                                        PadJobComponentNumber(Item.JobComponentNumber) + " - " +
                                        Item.JobComponentDescription}).ToList


            Return Json(Jobs, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetUploaderButtonStates() As JsonResult
            Dim AppVars As New cAppVars(cAppVars.Application.EXPENSE_REPORT)

            Dim ButtonStates As New List(Of Tuple(Of String, String))
            Try

                AppVars.getAllAppVars()


                If AppVars.HasAppVar("includeRowsWithReceipts") = True Then
                    ButtonStates.Add(Tuple.Create("includeRowsWithReceipts", AppVars.getAppVar("includeRowsWithReceipts").ToString))

                Else
                    ButtonStates.Add(Tuple.Create("includeRowsWithReceipts", "false"))
                End If

                If AppVars.HasAppVar("showThumbnail") = True Then
                    ButtonStates.Add(Tuple.Create("showThumbnail", AppVars.getAppVar("showThumbnail").ToString))
                Else
                    ButtonStates.Add(Tuple.Create("showThumbnail", "false"))
                End If

                If AppVars.HasAppVar("hideReceiptsApplied") = True Then
                    ButtonStates.Add(Tuple.Create("hideReceiptsApplied", AppVars.getAppVar("hideReceiptsApplied").ToString))
                Else
                    ButtonStates.Add(Tuple.Create("hideReceiptsApplied", "false"))
                End If


                Return Json(ButtonStates, JsonRequestBehavior.AllowGet)




            Catch ex As Exception

            End Try


        End Function

        <HttpGet>
        Public Function SaveUploaderButtonStates(ByVal includeRowsWithReceipts As String, ByVal showThumbnail As String, ByVal hideReceiptsApplied As String) As JsonResult
            Dim Saved As Boolean = True

            Try
                Dim AppVars As New cAppVars(cAppVars.Application.EXPENSE_REPORT)
                AppVars.getAllAppVars()


                AppVars.setAppVar("includeRowsWithReceipts", includeRowsWithReceipts, "Boolean")



                AppVars.setAppVar("showThumbnail", showThumbnail, "Boolean")



                AppVars.setAppVar("hideReceiptsApplied", hideReceiptsApplied, "Boolean")

                AppVars.SaveAllAppVars()

            Catch ex As Exception
                Saved = False
            End Try
            Return Json(Saved, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReportPageSize() As Integer

            Dim gridPageSize As Integer = MiscFN.LoadPageSize("ExpenseReportGrid")

            Return gridPageSize

        End Function

        <HttpGet>
        Public Function GetDefaultPaymentType() As Integer

            Dim DefaultPaymentType As Integer

            Dim appVars = New Webvantage.cAppVars(cAppVars.Application.EXPENSE_REPORT, Session("UserCode"))
            appVars.getAllAppVars()

            Try

                DefaultPaymentType = CShort(appVars.getAppVar("DefaultPaymentType"))

                If DefaultPaymentType = 2 Then
                    DefaultPaymentType = 1
                End If

            Catch ex As Exception
                DefaultPaymentType = Nothing
            End Try

            Return DefaultPaymentType

        End Function

        <HttpGet>
        Public Function GetHasDocuments(ByVal InvoiceNumbmer As String) As Boolean

            Dim HasDocuments As Boolean = False

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    HasDocuments = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByInvoiceNumber(DbContext, InvoiceNumbmer)
                                    Select Entity).Any
                End Using

            Catch ex As Exception
                HasDocuments = False
            End Try

            Return HasDocuments

        End Function


        <HttpGet>
        Public Function GetReceiptCount(ByVal InvoiceNumbmer As String) As Integer

            Dim ReceiptCount As Integer = False

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    ReceiptCount = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByInvoiceNumber(DbContext, InvoiceNumbmer)
                                    Select Entity).Count
                End Using

            Catch ex As Exception
                ReceiptCount = 0
            End Try

            Return ReceiptCount
        End Function

        <Mvc.HttpPost>
        Public Function SaveDefaultPaymentType(ByVal DefaultPaymentType As Integer) As Mvc.JsonResult

            Dim Saved As Boolean = True

            Dim AppVars As Webvantage.cAppVars = Nothing

            Try
                AppVars = New cAppVars(cAppVars.Application.EXPENSE_REPORT, Session("UserCode"))
                AppVars.getAllAppVars()
                AppVars.setAppVarDB("DefaultPaymentType", DefaultPaymentType, "Number")

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

            Return Json(Saved)

        End Function

        <HttpGet>
        Public Function GetExpenseReportPageSizeGet() As Mvc.JsonResult

            Dim gridPageSize As Integer = MiscFN.LoadPageSize("ExpenseReportGrid")

            Return Json(gridPageSize, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpPost>
        Public Function SaveGridPageSize(ByVal pageSize As Integer) As Mvc.JsonResult

            Dim Saved As Boolean = True

            Try
                Saved = MiscFN.SavePageSize("ExpenseReportGrid", pageSize)

            Catch ex As Exception
                Saved = False
            End Try
            Return Json(Saved)

        End Function

        <HttpGet>
        Public Function GetPrintSettings() As JsonResult
            Dim AppVars As New cAppVars(cAppVars.Application.EXPENSE_REPORT)

            Dim ButtonStates As New List(Of Tuple(Of String, String))
            Try

                AppVars.getAllAppVars()


                If AppVars.HasAppVar("PrintSupervisorBelowSignature") = True Then
                    ButtonStates.Add(Tuple.Create("PrintSupervisorBelowSignature", AppVars.getAppVar("PrintSupervisorBelowSignature").ToString))

                Else
                    ButtonStates.Add(Tuple.Create("PrintSupervisorBelowSignature", "false"))
                End If

                If AppVars.HasAppVar("ExcludeEmployeeSignature") = True Then
                    ButtonStates.Add(Tuple.Create("ExcludeEmployeeSignature", AppVars.getAppVar("ExcludeEmployeeSignature").ToString))
                Else
                    ButtonStates.Add(Tuple.Create("ExcludeEmployeeSignature", "false"))
                End If

                If AppVars.HasAppVar("ExcludeSupervisorSignature") = True Then
                    ButtonStates.Add(Tuple.Create("ExcludeSupervisorSignature", AppVars.getAppVar("ExcludeSupervisorSignature").ToString))
                Else
                    ButtonStates.Add(Tuple.Create("ExcludeSupervisorSignature", "false"))
                End If

                If AppVars.HasAppVar("IncludeReceipts") = True Then
                    ButtonStates.Add(Tuple.Create("IncludeReceipts", AppVars.getAppVar("IncludeReceipts").ToString))
                Else
                    ButtonStates.Add(Tuple.Create("IncludeReceipts", "false"))
                End If


                Return Json(ButtonStates, JsonRequestBehavior.AllowGet)




            Catch ex As Exception

            End Try


        End Function

        <Mvc.HttpPost>
        Public Function SavePrintSettings(ByVal PrintSupervisorBelowSignature As String, ByVal ExcludeEmployeeSignature As String, ByVal ExcludeSupervisorSignature As String, ByVal IncludeReceipts As String) As Mvc.JsonResult
            Dim Saved As Boolean = True

            Try
                Dim AppVars As New cAppVars(cAppVars.Application.EXPENSE_REPORT)
                AppVars.getAllAppVars()


                AppVars.setAppVar("PrintSupervisorBelowSignature", PrintSupervisorBelowSignature, "Boolean")



                AppVars.setAppVar("ExcludeEmployeeSignature", ExcludeEmployeeSignature, "Boolean")



                AppVars.setAppVar("ExcludeSupervisorSignature", ExcludeSupervisorSignature, "Boolean")



                AppVars.setAppVar("IncludeReceipts", IncludeReceipts, "Boolean")

                AppVars.SaveAllAppVars()

            Catch ex As Exception
                Saved = False
            End Try
            Return Json(Saved)

        End Function

        <Mvc.HttpGet>
        Public Function GetJobComponents(JobNumber As Integer) As Mvc.JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing

            JobComponents = (From Item In _ControllerExpenseReports.LoadJobComponents(JobNumber)
                             Order By Item.Description Ascending
                             Select New With {.ID = Item.ID,
                                        .Description = Item.Description}).ToList

            Return Json(JobComponents, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetDivisions(ClientCode As String) As Mvc.JsonResult

            'objects
            Dim Divisions As IEnumerable = Nothing

            Divisions = (From Item In _ControllerExpenseReports.LoadDivisions(ClientCode)
                         Order By Item.Name Ascending
                         Select New With {.Code = Item.Code,
                                        .Name = Item.Name}).ToList

            Return Json(Divisions, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetProducts(ClientCode As String, DivisionCode As String) As Mvc.JsonResult

            'objects
            Dim Clients As IEnumerable = Nothing

            Clients = (From Item In _ControllerExpenseReports.LoadProducts(ClientCode, DivisionCode)
                       Order By Item.Name Ascending
                       Select New With {.Code = Item.Code,
                                        .Name = Item.Name}).ToList

            Return Json(Clients, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function GetPaymentTypes() As Mvc.JsonResult

            'objects
            Dim PaymentTypes As IEnumerable = Nothing

            'get the list of payment types
            PaymentTypes = _ControllerExpenseReports.GetPaymentTypes()


            Return Json(PaymentTypes, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchExpenseEmployees(Optional ShowTerminatedEmployees As Boolean = False) As JsonResult
            Dim ExpenseEmployees As IEnumerable

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    ExpenseEmployees = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(Me.SecuritySession, DbContext, SecurityDbContext, ShowTerminatedEmployees)
                                        Select New With {.Code = Entity.Code,
                                                         .Name = Entity.FirstName + If(String.IsNullOrWhiteSpace(Entity.MiddleInitial), "", " " + Entity.MiddleInitial + ".") + " " + Entity.LastName + " (" + Entity.Code + ")"}).ToList


                End Using
            End Using


            Return Json(ExpenseEmployees, Mvc.JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Public Function BookMarkPage(ByVal Employee As String,
                                     ByVal FromDate As Date?,
                                     ByVal ToDate As Date?,
                                     ByVal Client As String,
                                     ByVal JobNumber As Integer?,
                                     ByVal FunctionCode As String,
                                     ByVal Description As String,
                                     ByVal ItemDate As Date?
                                     ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                .EmployeeCode = Employee
                .ClientCode = Client
                If JobNumber IsNot Nothing Then
                    .JobNumber = JobNumber
                End If
                .FunctionCode = FunctionCode
                .Add("desc", Description)
                If FromDate IsNot Nothing Then
                    .Add("fromdate", FromDate.Value.ToShortDateString)
                End If
                If ToDate IsNot Nothing Then
                    .Add("todate", ToDate.Value.ToShortDateString)
                End If
                If ItemDate IsNot Nothing Then
                    .Add("itemdate", ItemDate.Value.ToShortDateString)
                End If
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Employee_ExpenseReports
                .UserCode = Session("UserCode")
                .Name = "Expense Report Search"
                .PageURL = "modules/employee/expense-reports/expense-search-two" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <Mvc.HttpGet>
        Public Function SubmitExpenseReport(ByVal InvoiceNumber As Integer, ByVal EmployeeCode As String) As Mvc.JsonResult

            'objects
            Dim OkToSubmit As Boolean = True
            Dim ErrorText As String = ""
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
            Dim RequiresApproval As Boolean = False
            Dim SubmitDirectToAP As Boolean = False

            If IsNumeric(InvoiceNumber And InvoiceNumber > 0) Then
                If IsApproved(InvoiceNumber) = True Then
                    ErrorText = "Expense report has already been approved and cannot be modified."
                    OkToSubmit = False
                    'LoadExpense()
                End If
            End If

            'If RadGridExpenseItems.MasterTableView.Items.Count = 0 Then
            '    ErrorText = "Please add an Expense Line Item before submitting."
            '    OkToSubmit = False
            'End If

            If OkToSubmit Then

                'Save_Click()

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    If Not String.IsNullOrWhiteSpace(AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber).SubmittedTo) Then
                        SubmitDirectToAP = True
                    End If
                End Using

                If SubmitDirectToAP OrElse superApprNeeded(EmployeeCode) = False Then

                    If AdvantageFramework.ExpenseReports.SubmitExpenseReport(Me.SecuritySession, InvoiceNumber, False, ErrorText, SubmitDirectToAP:=SubmitDirectToAP) Then
                        'LoadExpense()
                        ErrorText = "ok"
                    Else


                    End If

                Else

                    'QueryString = New AdvantageFramework.Web.QueryString
                    'QueryString = QueryString.FromCurrent()
                    'QueryString.ExpenseId = InvoiceNumber
                    'QueryString.Page = "Expense_SubmitOptions.aspx"
                    'Me.OpenWindow("Submit Expense Report Options", QueryString.ToString(True), 245, 475, False, True)

                    ErrorText = "submit_options"

                End If


            End If


            'If String.IsNullOrEmpty(ErrorText) = False Then
            '    'Me.ShowMessage(ErrorText)
            'End If


            Return Json(ErrorText, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpGet>
        Public Function SubmitExpenseReportOptions(ByVal InvoiceNumber As Integer, ByVal ApprovalRequired As Boolean, ByVal IncludeReceiptsInEmailAndAlert As Boolean, ByVal SubmittedToEmployeeCode As String) As Mvc.JsonResult

            'objects
            'Dim SubmittedToEmployeeCode As String = Nothing
            Dim OkToSubmit As Boolean = True
            Dim ErrorMessage As String = ""
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            'Dim IncludeReceiptsInEmailAndAlert As Boolean = False
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
            Dim CloseWindow As Boolean = False

            If ApprovalRequired Then
                'IncludeReceiptsInEmailAndAlert = CheckBox_IncludeReceiptsInEmailAndAlert.Checked
                'SubmittedToEmployeeCode = RadComboBox_Employees.SelectedValue
                If SubmittedToEmployeeCode.Trim = "" Then
                    ErrorMessage = "Please selected an approver."
                    OkToSubmit = False
                End If
            End If

            If OkToSubmit Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                    If ExpenseReport IsNot Nothing Then

                        ExpenseReport.SubmittedTo = SubmittedToEmployeeCode

                        If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                            Dim AlertId As Integer = 0
                            If AdvantageFramework.ExpenseReports.SubmitExpenseReport(Me.SecuritySession, ExpenseReport, Employee, IncludeReceiptsInEmailAndAlert, ErrorMessage, False, AlertId) = True Then

                                Dim eso As New EmailSessionObject(Session("ConnString"),
                                                 Session("UserCode"),
                                                 Me.SecuritySession,
                                                 Session("WebvantageURL"),
                                                 Session("ClientPortalURL"))

                                With eso

                                    .AlertId = AlertId
                                    .Subject = "[New Alert]"
                                    .AppName = "Expense"
                                    '.SessionID = Me.SecuritySession.sess SessionID.ToString()
                                    '.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                    .Send()

                                End With

                                'Me.CheckForAsyncMessage()
                                'CloseWindow = True
                                'QueryString = New AdvantageFramework.Web.QueryString()
                                'QueryString.Page = "Expense_Edit_V2.aspx"
                                'QueryString.Add("invoice", ExpenseReport.InvoiceNumber)

                            End If

                        End If

                    End If

                End Using

            End If

            Return Json(ErrorMessage, Mvc.JsonRequestBehavior.AllowGet)
        End Function

        <Mvc.HttpGet>
        Public Function UnSubmitExpenseReport(ByVal InvoiceNumber As Integer) As Mvc.JsonResult

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ErrorText As String = Nothing

            If IsNumeric(InvoiceNumber) And InvoiceNumber > 0 Then

                If IsApproved(InvoiceNumber) = True Then
                    'Me.ShowMessage("Expense report has already been approved and cannot be modified.")
                    'LoadExpense()
                    'Exit Sub
                    Return Json("Expense report has already been approved and cannot be modified.", Mvc.JsonRequestBehavior.AllowGet)
                End If

            End If
            Dim oExpense As cExpense = New cExpense(Session("ConnString"))
            Dim blnReturn As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    If AdvantageFramework.ExpenseReports.UnSubmitExpenseReport(DbContext, ExpenseReport, ErrorText) = False Then
                        Err()
                        'Me.ShowMessage(ErrorText)
                        'Exit Sub
                        Return Json(ErrorText, Mvc.JsonRequestBehavior.AllowGet)
                    End If

                End If

            End Using

            'Me.RadToolbarExpenseEdit.FindItemByValue("Unsubmit").Visible = False
            'Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Visible = True
            'Me.RadToolbarExpenseEdit.FindItemByValue("Submit").Enabled = Me.IsVendorAssociated
            'ResponseRedirect(Request.Url.PathAndQuery)

        End Function

        <Mvc.HttpGet>
        Public Function GetEmployeesForDropDown() As Mvc.JsonResult

            Dim list As IEnumerable
            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    list = (From Entity In AdvantageFramework.ExpenseReports.LoadExpenseEmployees(Me.SecuritySession, DbContext, SecurityDbContext, False).ToList
                            Select Entity.Code, [Name] = Entity.ToString).ToList

                End Using

            End Using

            Return Json(list, Mvc.JsonRequestBehavior.AllowGet)
        End Function



        <Mvc.HttpGet>
        Public Function CopyExpenseReport(ByVal InvoiceNumber As Integer, ByVal EmployeeCode As String, ByVal ReportDate As System.DateTime, ByVal Description As String, ByVal Details As String) As Mvc.JsonResult

            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim DuplicateExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim DuplicateExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Copied As Boolean = False
            Dim ErrorText As String = Nothing
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing


            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                'Details = RadTextBox_Details.Text
                'ReportDate = RadDatePicker_ReportDate.SelectedDate

                If AdvantageFramework.ExpenseReports.CopyExpenseReport(DbContext, InvoiceNumber, EmployeeCode, ReportDate, Description, Details, ErrorText) Then

                    'QueryString = New AdvantageFramework.Web.QueryString
                    'QueryString.Page = "expense_edit_v2.aspx"
                    'QueryString.Add("invoice", _InvoiceNumber)
                    'Me.CloseThisWindowAndRefreshCaller(QueryString.ToString(True), True)
                    'Me.OpenWindow(QueryString, "Expense report")
                    'Me.CloseThisWindow()

                    Return Json(InvoiceNumber, Mvc.JsonRequestBehavior.AllowGet)

                Else

                    'Me.ShowMessage(ErrorText)
                    Return Json(ErrorText, Mvc.JsonRequestBehavior.AllowGet)
                End If

            End Using




        End Function

        <Mvc.HttpGet>
        Public Function PrintExpenseReport(ByVal InvoiceNumber As Integer, ByVal PrintSupervisorName As Boolean, ByVal ExcludeEmployeeSignature As Boolean, ByVal IncludeReceipts As Boolean, ByVal IncludeReport As Boolean, ByVal ExcludeSupervisorSignature As Boolean) As Mvc.JsonResult

            'objects
            Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object) = Nothing
            Dim DataSource As Object = Nothing
            Dim URL As String = Nothing

            If InvoiceNumber > 0 Then

                ParameterDictionary = New System.Collections.Generic.Dictionary(Of String, Object)

                ParameterDictionary.Add("InvoiceNumbers", {InvoiceNumber})
                ParameterDictionary.Add("PrintApproverName", PrintSupervisorName)
                ParameterDictionary.Add("ExcludeEmployeeSignature", ExcludeEmployeeSignature)
                ParameterDictionary.Add("IncludeReceipts", IncludeReceipts)
                ParameterDictionary.Add("IncludeReport", IncludeReport)
                ParameterDictionary.Add("ExcludeSupervisorSignature", ExcludeSupervisorSignature)

                Session("Report_ParameterDictionary") = ParameterDictionary

                Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport

                URL = "Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & ""

                'CloseThisWindowAndOpenNewWindow(URL)
                Return Json(URL, Mvc.JsonRequestBehavior.AllowGet)
            End If

            Return Json("Invalid invoice number", Mvc.JsonRequestBehavior.AllowGet)

        End Function



        <Mvc.HttpGet>
        Public Function GetGridColumnSettings()

            Dim UserColumn As New List(Of String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                'UserColumn = AdvantageFramework.Web.Presentation.Controls.getusGetUserColumnList(Session("ConnString"), GridName, Session("UserCode"))

                UserColumn = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT GRID_COLUMN.NAME FROM GRID WITH(NOLOCK) INNER JOIN GRID_COLUMN WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN.GRID_ID " &
                                                                                          "INNER JOIN GRID_COLUMN_SETTING WITH(NOLOCK) ON GRID.GRID_ID = GRID_COLUMN_SETTING.GRID_ID AND GRID_COLUMN.GRID_COLUMN_ID = GRID_COLUMN_SETTING.GRID_COLUMN_ID " &
                                                                                          "WHERE (GRID_COLUMN_SETTING.IS_VISIBLE = 0) AND (GRID.NAME = '{0}') AND (GRID_COLUMN_SETTING.USER_CODE = '{1}');", GridName, Session("UserCode"))).ToList()


            End Using

            Return UserColumn

        End Function

        <Mvc.HttpPost>
        Public Function SaveGridColumnSettings(ByVal UserColumn As ColumnShow)
            Select Case UserColumn.Column
                Case "Client"
                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, ColClient, UserColumn.Show)
                Case "Division"
                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, ColDivision, UserColumn.Show)
                Case "Product"
                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, ColProduct, UserColumn.Show)
                Case "Job", "Component"
                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, ColJob_Component, UserColumn.Show)
                Case "Quantity"
                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, ColQuantity_Rate, UserColumn.Show)
            End Select
        End Function


        <Mvc.HttpGet>
        Public Function GetImportTemplates(ByVal Employee As String) As Mvc.JsonResult

            Dim LoadByImportType As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportTemplate) = Nothing

            Dim ImportType_1 As Short = AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard
            Dim ImportType_2 As Short = AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard
            Dim ImportTemplateList As Generic.List(Of ImportTemplateViewModel) = New List(Of ImportTemplateViewModel)

            'Dim ImportTemplateViewModel As 
            Dim user As String = Session("UserCode")

            Dim suser As AdvantageFramework.Security.Database.Entities.User

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                suser = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, Employee)

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                LoadByImportType = From ImportTemplate In DbContext.GetQuery(Of Database.Entities.ImportTemplate)
                                   Where (ImportTemplate.Type = 1 Or ImportTemplate.Type = 2) 'And ImportTemplate.CreatedBy = user
                                   Select ImportTemplate

                For Each template In LoadByImportType
                    Dim item = New ImportTemplateViewModel
                    item.Id = template.ID
                    item.Name = template.Name

                    ImportTemplateList.Add(item)

                Next


            End Using

            Return Json(ImportTemplateList, Mvc.JsonRequestBehavior.AllowGet)
            'ImportTemplateList = (From ImportTemplate In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, CShort(ImportTemplateType))
            'Select Case ImportTemplate).OrderByDescending(Function(ImportTemplate) ImportTemplate.IsSystemTemplate).ThenBy(Function(ImportTemplate) ImportTemplate.Name).ToList

        End Function

        <Mvc.HttpGet>
        Public Function GetImportTemplateDetails(ByVal ImportTemplateID As Short) As Mvc.JsonResult

            Dim ImportTemplateDetail As ImportTemplateDetailViewModel = Nothing
            Dim ImportTemplateDetails As Generic.List(Of ImportTemplateDetailViewModel) = New List(Of ImportTemplateDetailViewModel)

            'Dim ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail) = Nothing
            'Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, ImportTemplateID).ToList

                    ImportTemplateDetail = New ImportTemplateDetailViewModel

                    ImportTemplateDetail.FieldName = ImpTempDtl.FieldName
                    ImportTemplateDetail.CSVPosition = ImpTempDtl.CSVPosition
                    ImportTemplateDetail.ID = ImpTempDtl.ID
                    ImportTemplateDetail.TemplateID = ImpTempDtl.TemplateID
                    ImportTemplateDetail.DateFormat = ImpTempDtl.DateFormat

                    ImportTemplateDetails.Add(ImportTemplateDetail)

                Next

            End Using

            Return Json(ImportTemplateDetails, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetExpenseReportSecurity() As JsonResult

            'objects
            Dim CanAdd As Boolean = False
            Dim CanUpdate As Boolean = False
            Dim CanPrint As Boolean = False
            Dim Custom1 As Boolean = False
            Dim Custom2 As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    LoadExpenseReportSecurity(CanAdd, CanUpdate, CanPrint, Custom1, Custom2)

                Catch ex As Exception

                End Try

            End Using

            Return Json(CanAdd, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function IsEmployeeVendor(ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim HasVendor As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VendorCode As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    If AdvantageFramework.ExpenseReports.IsEmployeeVendor(DbContext, EmployeeCode, VendorCode) Then

                        HasVendor = True

                    End If

                Catch ex As Exception

                End Try

            End Using

            Return Json(HasVendor, JsonRequestBehavior.AllowGet)

        End Function

        <Mvc.HttpPost>
        Public Function SaveImportTemplate(ByVal Employee As String, ByVal TemplateName As String, ByVal ImportDetailList As IEnumerable(Of ImportTemplateDetailViewModel)) As Mvc.JsonResult

            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))


                    ImportTemplate = New Database.Entities.ImportTemplate

                    ImportTemplate.DbContext = DbContext
                    ImportTemplate.Name = TemplateName
                    ImportTemplate.DefaultDirectory = ""
                    ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard
                    ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV


                    If InsertImportTemplate(DbContext, ImportTemplate, Employee) Then

                        For Each ImportDetail In ImportDetailList

                            ImportTemplateDetail = New Database.Entities.ImportTemplateDetail

                            ImportTemplateDetail.CSVPosition = ImportDetail.CSVPosition
                            ImportTemplateDetail.FieldName = ImportDetail.FieldName
                            ImportTemplateDetail.DateFormat = ImportDetail.DateFormat
                            ImportTemplateDetail.TemplateID = ImportTemplate.ID

                            AdvantageFramework.Database.Procedures.ImportTemplateDetail.Insert(DbContext, ImportTemplateDetail)

                        Next

                    Else

                        Return Json("Not saved")

                    End If

                End Using
            Catch ex As Exception

                'Dim t As String = ex.Message
                Return Json(ex.Message)
            End Try

            Return Json("Ok")


        End Function





#End Region

#Region " Private "

        Private Function PadJobNumber(JobNumber As String)

            PadJobNumber = JobNumber.PadLeft(6, "0")

        End Function

        Private Function PadJobComponentNumber(JobComponentNumber As String)

            PadJobComponentNumber = JobComponentNumber.PadLeft(3, "0")

        End Function

        Private Function IsPending(ByVal InvoiceNumber As Integer) As Boolean

            'objects
            Dim cExpense As Webvantage.cExpense = Nothing
            Dim ExpenseHeader As Webvantage.ExpenseHeader = Nothing
            Dim Pending As Boolean = False

            Try

                cExpense = New Webvantage.cExpense(Session("ConnString"))

                ExpenseHeader = cExpense.GetExpenseHeader(InvoiceNumber, False)

                Select Case ExpenseHeader.STATUS_CALC

                    Case ExpenseStatusCalculated.Pending,
                    ExpenseStatusCalculated.PendingAcct,
                    ExpenseStatusCalculated.PendingSuper

                        Pending = True

                    Case Else

                        Pending = False

                End Select

            Catch ex As Exception
                Pending = False
                'Me.ShowMessage(ex.Message.ToString())
            Finally
                IsPending = Pending
            End Try

        End Function

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
                'Me.ShowMessage(ex.Message.ToString())
            Finally
                IsApproved = Approved
            End Try

        End Function

        Private Function superApprNeeded(ByVal EmployeeCode As String) As Boolean
            Dim SQL_STR As String
            Dim oSQL As SqlHelper
            Dim dr As SqlDataReader
            Dim value As Integer

            SQL_STR = "SELECT ISNULL(EXP_APPR_REQ, 0) FROM EMPLOYEE WHERE EMP_CODE = '" & EmployeeCode & "'"

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

        Public Overloads Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

            Dim ModuleAccess As Integer = 1

            'ModuleAccess = CheckModuleAccess([Module].ToString, TransferToNoAccessPage)

            Return ModuleAccess

        End Function


        Private Function InsertImportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate, ByVal Employee As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ImportTemplate.CreatedBy = Employee
                ImportTemplate.CreatedDate = System.DateTime.Now

                DbContext.ImportTemplates.Add(ImportTemplate)

                ErrorText = ImportTemplate.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.ADV_SERVICE_IMPORT (TEMPLATE_ID) VALUES ({0})", ImportTemplate.ID))

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                InsertImportTemplate = Inserted
            End Try

        End Function

        Private Sub LoadExpenseReportSecurity(ByRef CanAdd As Boolean, ByRef CanUpdate As Boolean, ByRef CanPrint As Boolean, ByRef Custom1 As Boolean, ByRef Custom2 As Boolean)

            Try

                Dim UseScheduleSecurity As Boolean = False
                Dim KeyName As String = "EXSec"

                If HttpContext.Session(KeyName) IsNot Nothing Then

                    CanAdd = CType(HttpContext.Session(KeyName & "CanAdd"), Boolean)
                    CanUpdate = CType(HttpContext.Session(KeyName & "CanUpdate"), Boolean)
                    CanPrint = CType(HttpContext.Session(KeyName & "CanPrint"), Boolean)
                    Custom1 = CType(HttpContext.Session(KeyName & "Custom1"), Boolean)
                    Custom2 = CType(HttpContext.Session(KeyName & "Custom2"), Boolean)

                Else

                    Dim SecurityModule As AdvantageFramework.Security.Modules = AdvantageFramework.Security.Methods.Modules.Employee_ExpenseReports

                    CanAdd = AdvantageFramework.Security.CanUserAddInModule(Me.SecuritySession, SecurityModule)
                    CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule)
                    CanPrint = AdvantageFramework.Security.CanUserPrintInModule(Me.SecuritySession, SecurityModule)
                    Custom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.SecuritySession, SecurityModule)
                    Custom2 = AdvantageFramework.Security.CanUserCustom2InModule(Me.SecuritySession, SecurityModule)

                    HttpContext.Session(KeyName & "CanAdd") = CanAdd
                    HttpContext.Session(KeyName & "CanUpdate") = CanUpdate
                    HttpContext.Session(KeyName & "CanPrint") = CanPrint
                    HttpContext.Session(KeyName & "Custom1") = Custom1
                    HttpContext.Session(KeyName & "Custom2") = Custom2

                End If

            Catch ex As Exception
            End Try

        End Sub
        <Mvc.HttpPost>
        Public Function UploadReceipts(ByVal AsyncDocuments As IEnumerable(Of HttpPostedFileBase),
                                       ByVal InvoiceNumber As Integer,
                                       ByVal ExpenseDetailID? As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim DocumentID As Integer = 0
            Dim DocumentManagerFilename As String
            Dim FileUploadedSuccessfully As Boolean = True
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim MimeType As String = String.Empty
            Dim FullDirectory As String = HttpContext.Request.PhysicalApplicationPath & "TEMP\"
            Dim Key As String = String.Empty
            Dim IsValid As Boolean = True
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Documents As New Generic.List(Of AdvantageFramework.Database.Entities.Document)
            Dim LinkDocumentToInvoice As Boolean = False
            Dim EmployeeCode As String = String.Empty
            Dim ThumbnailUpdated As Boolean = False
            Dim ExpenseDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseDetailDocument As AdvantageFramework.Database.Entities.ExpenseDetailDocument = Nothing
            Dim FileLength As Integer = 0
            Dim Filename = String.Empty
            Dim FileBytes() As Byte = Nothing
            Dim Stream As MemoryStream = Nothing
            Dim Description As String = String.Format("Expense receipt for invoice: {0}", InvoiceNumber)
            Dim Keywords As String = String.Empty

            If IsApproved(InvoiceNumber) = True Or IsPending(InvoiceNumber) = True Then
                Return MaxJson("Expense report has already been approved and cannot be modified.")
            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        For i As Integer = 0 To (AsyncDocuments.Count() - 1)

                            ExpenseDocument = Nothing
                            ExpenseDetailDocument = Nothing
                            Stream = Nothing

                            Stream = New MemoryStream
                            FileLength = AsyncDocuments.ElementAt(i).InputStream.Length
                            Filename = AsyncDocuments.ElementAt(i).FileName
                            MimeType = AsyncDocuments.ElementAt(i).ContentType

                            AsyncDocuments.ElementAt(i).InputStream.CopyTo(Stream)

                            FileBytes = Stream.ToArray()

                            Try

                                If AsyncDocuments.ElementAt(i) IsNot Nothing Then

                                    If FileLength > 0 Then

                                        If FileTypeIsValid(AsyncDocuments.ElementAt(i)) = True Then

                                            Key = Guid.NewGuid.ToString

                                            If System.IO.Directory.Exists(FullDirectory) = True Then

                                                AdvantageFramework.FileSystem.CheckFileForRepositoryConstraints(DbContext, FileLength, IsValid, ErrorMessage)

                                                If IsValid Then

                                                    Try

                                                        If AdvantageFramework.FileSystem.Add(Agency, FullDirectory & "\" & Filename,
                                                                                         Description, Keywords, Me.SecuritySession.UserCode, "", "",
                                                                                         DocumentSource.Default,
                                                                                         FileName:=DocumentManagerFilename,
                                                                                         byteFile:=FileBytes) Then

                                                            FileUploadedSuccessfully = True

                                                        Else

                                                            ErrorMessage = "Saving file to document repository failed."

                                                        End If

                                                    Catch ex As Exception
                                                        FileUploadedSuccessfully = False
                                                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                                    End Try

                                                    If FileUploadedSuccessfully = True AndAlso String.IsNullOrWhiteSpace(DocumentManagerFilename) = False Then

                                                        Document = New Database.Entities.Document

                                                        Document.FileSystemFileName = DocumentManagerFilename
                                                        Document.FileName = Filename
                                                        Document.Description = Description
                                                        Document.Keywords = Keywords
                                                        Document.MIMEType = MimeType
                                                        Document.UploadedDate = Now
                                                        Document.UserCode = Me.SecuritySession.UserCode
                                                        Document.FileSize = FileLength
                                                        Document.IsPrivate = Nothing
                                                        Document.DocumentTypeID = 2 'file

                                                        Try

                                                            Document.ID = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext)
                                                                           Select Entity.ID).Max + 1

                                                        Catch ex As Exception
                                                            Document.ID = 1
                                                        End Try
                                                        Try

                                                            If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                                DocumentID = Document.ID
                                                                Documents.Add(Document)

                                                            End If

                                                        Catch ex As Exception
                                                            FileUploadedSuccessfully = False
                                                            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                                        End Try

                                                    End If

                                                End If

                                            Else

                                                ErrorMessage = "Did not find file in temp directory."

                                            End If

                                        Else

                                            ErrorMessage = "Invalid file type."

                                        End If

                                    Else

                                        ErrorMessage = "No file content."

                                    End If

                                Else

                                    ErrorMessage = "No file."

                                End If

                            Catch ex As Exception
                                FileUploadedSuccessfully = False
                                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                            End Try
                            If FileUploadedSuccessfully = True Then

                                Try

                                    ExpenseDocument = New Database.Entities.ExpenseReportDocument
                                    ExpenseDocument.DocumentID = DocumentID
                                    ExpenseDocument.InvoiceNumber = InvoiceNumber

                                    AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpenseDocument)

                                    If ExpenseDetailID IsNot Nothing AndAlso ExpenseDetailID > 0 Then

                                        ExpenseDetailDocument = New AdvantageFramework.Database.Entities.ExpenseDetailDocument
                                        ExpenseDetailDocument.DocumentID = DocumentID
                                        ExpenseDetailDocument.ExpenseDetailID = ExpenseDetailID

                                        AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Insert(DbContext, ExpenseDetailDocument)

                                    End If

                                Catch ex As Exception
                                    ErrorMessage = AsyncDocuments.ElementAt(i).FileName & " - failed adding file to database."
                                End Try

                                'Thumbnail creation for images only
                                If MimeType.ToLower.Contains("image") = True Then

                                    Try

                                        Try

                                            If Agency Is Nothing Then

                                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                            End If

                                        Catch ex As Exception
                                            Agency = Nothing
                                        End Try
                                        If Agency IsNot Nothing Then

                                            AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, DocumentID, Nothing)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                End If

                            Else

                            End If

                        Next

                    End Using

                End Using

                Return MaxJson(ErrorMessage)

            End If

        End Function

        <Http.HttpGet>
        Public Function GetReceiptsList(ByVal InvoiceNumber As Integer) As Mvc.JsonResult

            If InvoiceNumber = 0 Or InvoiceNumber = Nothing Then

                Return Json(New List(Of UpladedImageThumbnailViewModel), Mvc.JsonRequestBehavior.AllowGet)

            End If
            Dim newDocument As New Document(Session("ConnString"))
            Dim ExpenseDocument As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim dt As DataTable
            Dim UploadedImage As UpladedImageThumbnailViewModel = Nothing
            Dim ReportImagesList As Generic.List(Of UpladedImageThumbnailViewModel) = New List(Of UpladedImageThumbnailViewModel)
            Dim RowIds As Generic.List(Of GridRowID)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try
                    RowIds = DbContext.Database.SqlQuery(Of GridRowID)(String.Format("SELECT distinct EXPENSE_DETAIL_DOCS.DOCUMENT_ID, EXPENSE_DETAIL_DOCS.EXPDETAILID " &
                                                                                    "FROM EXPENSE_DETAIL INNER JOIN " &
                                                                                    "EXPENSE_DETAIL_DOCS ON EXPENSE_DETAIL.EXPDETAILID = EXPENSE_DETAIL_DOCS.EXPDETAILID INNER JOIN " &
                                                                                    "EXPENSE_DOCS ON EXPENSE_DETAIL.INV_NBR = EXPENSE_DOCS.INV_NBR " &
                                                                                    "where EXPENSE_DOCS.INV_NBR={0}", InvoiceNumber)).ToList()
                Catch ex As Exception
                    RowIds = Nothing
                End Try

            End Using




            dt = newDocument.GetCurrentExpenseDocument(InvoiceNumber, "", "", 0, 1)
            'dt.Columns.Add(New DataColumn("TB64", System.Type.GetType("System.String")))

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                For Each dr As DataRow In dt.Rows

                    UploadedImage = New UpladedImageThumbnailViewModel

                    Dim FileBytes As Byte()
                    Dim MimeType As String

                    Try

                        FileBytes = dr.Item("THUMBNAIL")

                    Catch ex As Exception
                        FileBytes = Nothing
                    End Try

                    MimeType = dr.Item("MIME_TYPE")

                    If FileBytes Is Nothing Then

                        If MimeType.ToLower.Contains("image") = True Then

                            Dim ThumbnailUpdated As Boolean = False

                            Try

                                If Agency Is Nothing Then

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                End If

                            Catch ex As Exception
                                Agency = Nothing
                            End Try

                            If Agency IsNot Nothing Then

                                Dim saved As Boolean = False

                                saved = AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, dr.Item("DOCUMENT_ID"), Nothing)

                                If saved Then

                                    ExpenseDocument = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, dr.Item("DOCUMENT_ID"))

                                    If ExpenseDocument IsNot Nothing Then

                                        FileBytes = ExpenseDocument.Thumbnail

                                    End If

                                End If

                            End If


                        End If

                    End If

                    'dr.Item("TB64") = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))

                    Try

                        UploadedImage.Filename = dr.Item("FILENAME") '.ToString.Replace("-", "_")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.InvoiceNumber = dr.Item("INV_NBR")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.Description = dr.Item("DESCRIPTION")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.DocumentId = dr.Item("DOCUMENT_ID")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.ExpenceDescription = dr.Item("EXP_DESC")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.Mimetype = dr.Item("MIME_TYPE")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.RepositoryFilename = dr.Item("REPOSITORY_FILENAME")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.UploadedDate = dr.Item("UPLOADED_DATE")

                    Catch ex As Exception
                    End Try
                    If (UploadedImage.Filename.ToLower.EndsWith(".csv")) Then

                        UploadedImage.extension = "CSV"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".doc") Or UploadedImage.Filename.ToLower.EndsWith(".docx")) Then

                        UploadedImage.extension = "DOC"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".pdf")) Then

                        UploadedImage.extension = "PDF"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".ppt") Or UploadedImage.Filename.ToLower.EndsWith(".pptx")) Then

                        UploadedImage.extension = "PPT"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".txt")) Then

                        UploadedImage.extension = "TXT"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".xls") Or UploadedImage.Filename.ToLower.EndsWith(".xlsx")) Then

                        UploadedImage.extension = "XLS"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".zip")) Then

                        UploadedImage.extension = "ZIP"

                    End If
                    If FileBytes IsNot Nothing Then

                        UploadedImage.ThumbnailData = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))

                    Else

                        UploadedImage.ThumbnailData = Nothing

                    End If
                    For Each gr As GridRowID In RowIds

                        If gr.DOCUMENT_ID = UploadedImage.DocumentId Then

                            UploadedImage.RowId = gr.EXPDETAILID

                            UploadedImage.Rows.Add(gr.EXPDETAILID)

                        End If

                    Next

                    ReportImagesList.Add(UploadedImage)

                    dr.AcceptChanges()

                Next

            End Using

            'dt.Columns.Remove("THUMBNAIL")
            ' Dim JsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(dt)
            'Return Json(GetJson(dt), Mvc.JsonRequestBehavior.AllowGet)
            Return Json(ReportImagesList, Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <Http.HttpGet>
        Public Function GetReceiptsListUnassigned(ByVal EmployeeCode As String) As Mvc.JsonResult

            If EmployeeCode = "" Or EmployeeCode = Nothing Then

                Return Json(New List(Of UpladedImageThumbnailViewModel), Mvc.JsonRequestBehavior.AllowGet)

            End If
            Dim newDocument As New Document(Session("ConnString"))
            Dim ExpenseDocumentUnassigned As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ExpenseDocument As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim dt As DataTable
            Dim UploadedImage As UpladedImageThumbnailViewModel = Nothing
            Dim ReportImagesList As Generic.List(Of UpladedImageThumbnailViewModel) = New List(Of UpladedImageThumbnailViewModel)

            Dim ExpenseDocumentsUnassigned As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try
                    ExpenseDocumentsUnassigned = AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                Catch ex As Exception
                    ExpenseDocumentsUnassigned = Nothing
                End Try

                For Each doc As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned In ExpenseDocumentsUnassigned

                    ExpenseDocumentUnassigned = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, doc.DocumentID)

                    UploadedImage = New UpladedImageThumbnailViewModel

                    Dim FileBytes As Byte()
                    Dim MimeType As String

                    Try

                        FileBytes = ExpenseDocumentUnassigned.Thumbnail ' dr.Item("THUMBNAIL")

                    Catch ex As Exception
                        FileBytes = Nothing
                    End Try

                    MimeType = ExpenseDocumentUnassigned.MIMEType ' dr.Item("MIME_TYPE")

                    If FileBytes Is Nothing Then

                        If MimeType.ToLower.Contains("image") = True Then

                            Dim ThumbnailUpdated As Boolean = False

                            Try

                                If Agency Is Nothing Then

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                End If

                            Catch ex As Exception
                                Agency = Nothing
                            End Try

                            If Agency IsNot Nothing Then

                                Dim saved As Boolean = False

                                saved = AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, ExpenseDocumentUnassigned.ID, Nothing)

                                If saved Then

                                    ExpenseDocument = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, ExpenseDocumentUnassigned.ID)

                                    If ExpenseDocument IsNot Nothing Then

                                        FileBytes = ExpenseDocument.Thumbnail

                                    End If

                                End If

                            End If


                        End If

                    End If

                    'dr.Item("TB64") = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))

                    Try

                        UploadedImage.Filename = ExpenseDocumentUnassigned.FileName ' dr.Item("FILENAME") '.ToString.Replace("-", "_")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.InvoiceNumber = Nothing ' dr.Item("INV_NBR")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.Description = ExpenseDocumentUnassigned.Description ' dr.Item("DESCRIPTION")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.DocumentId = ExpenseDocumentUnassigned.ID ' dr.Item("DOCUMENT_ID")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.ExpenceDescription = "" ' dr.Item("EXP_DESC")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.Mimetype = ExpenseDocumentUnassigned.MIMEType ' dr.Item("MIME_TYPE")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.RepositoryFilename = ExpenseDocumentUnassigned.FileSystemFileName '  dr.Item("REPOSITORY_FILENAME")

                    Catch ex As Exception
                    End Try
                    Try

                        UploadedImage.UploadedDate = ExpenseDocumentUnassigned.UploadedDate ' dr.Item("UPLOADED_DATE")

                    Catch ex As Exception
                    End Try
                    If (UploadedImage.Filename.ToLower.EndsWith(".csv")) Then

                        UploadedImage.extension = "CSV"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".doc") Or UploadedImage.Filename.ToLower.EndsWith(".docx")) Then

                        UploadedImage.extension = "DOC"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".pdf")) Then

                        UploadedImage.extension = "PDF"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".ppt") Or UploadedImage.Filename.ToLower.EndsWith(".pptx")) Then

                        UploadedImage.extension = "PPT"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".txt")) Then

                        UploadedImage.extension = "TXT"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".xls") Or UploadedImage.Filename.ToLower.EndsWith(".xlsx")) Then

                        UploadedImage.extension = "XLS"

                    End If
                    If (UploadedImage.Filename.ToLower.EndsWith(".zip")) Then

                        UploadedImage.extension = "ZIP"

                    End If
                    If FileBytes IsNot Nothing Then

                        UploadedImage.ThumbnailData = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))

                    Else

                        UploadedImage.ThumbnailData = Nothing

                    End If
                    'For Each gr As GridRowID In RowIds

                    '    If gr.DOCUMENT_ID = UploadedImage.DocumentId Then

                    '        UploadedImage.RowId = gr.EXPDETAILID

                    '        UploadedImage.Rows.Add(gr.EXPDETAILID)

                    '    End If

                    'Next

                    ReportImagesList.Add(UploadedImage)

                    'dr.AcceptChanges()

                Next

            End Using

            Return Json(ReportImagesList, Mvc.JsonRequestBehavior.AllowGet)

        End Function


        <Http.HttpGet>
        Public Function ReceiptGrid(ByVal InvoiceNumber As Integer) As Mvc.JsonResult
            Dim RowIds As Generic.List(Of GridRowID)
            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try
                    RowIds = DbContext.Database.SqlQuery(Of GridRowID)(String.Format("SELECT distinct EXPENSE_DETAIL_DOCS.DOCUMENT_ID, EXPENSE_DETAIL_DOCS.EXPDETAILID " &
                                                                                    "FROM EXPENSE_DETAIL INNER JOIN " &
                                                                                    "EXPENSE_DETAIL_DOCS ON EXPENSE_DETAIL.EXPDETAILID = EXPENSE_DETAIL_DOCS.EXPDETAILID INNER JOIN " &
                                                                                    "EXPENSE_DOCS ON EXPENSE_DETAIL.INV_NBR = EXPENSE_DOCS.INV_NBR " &
                                                                                    "where EXPENSE_DOCS.INV_NBR={0}", InvoiceNumber)).ToList()
                Catch ex As Exception
                    RowIds = Nothing
                End Try

            End Using

            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(RowIds), Mvc.JsonRequestBehavior.AllowGet)

        End Function



        <Http.HttpGet>
        Public Function ReceiptList(ByVal InvoiceNumber As Integer) As Mvc.JsonResult

            Dim newDocument As New Document(Session("ConnString"))
            Dim dt As DataTable
            dt = newDocument.GetCurrentExpenseDocument(InvoiceNumber, "", "", 1, 1)

            dt.Columns.Add(New DataColumn("TB64", System.Type.GetType("System.String")))

            For Each dr As DataRow In dt.Rows
                Dim FileBytes As Byte()
                Dim MimeType As String
                FileBytes = dr.Item("THUMBNAIL")
                MimeType = dr.Item("MIME_TYPE")

                dr.Item("TB64") = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(FileBytes))
                dr.AcceptChanges()
            Next

            dt.Columns.Remove("THUMBNAIL")




            ' Dim JsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(dt)

            'Return Json(GetJson(dt), Mvc.JsonRequestBehavior.AllowGet)
            Return Json(Newtonsoft.Json.JsonConvert.SerializeObject(dt), Mvc.JsonRequestBehavior.AllowGet)

        End Function




        <Http.HttpGet>
        Public Function DownloadReceipt(ByVal DocumentID As Integer, ByVal InvoiceNumber As Integer?) As FileContentResult

            If InvoiceNumber Is Nothing Then

                Dim Document As New Document(Session("ConnString"))
                Document.LoadByPrimaryKey(DocumentID)
                Dim DocumentRepository As New DocumentRepository(Session("ConnString"))
                Dim RealFilename As String = Document.FILENAME  ' Filename
                Dim ErrorMessage As String = ""

                Dim MimeType As String = ""
                Try

                    MimeType = Document.MIME_TYPE

                Catch ex As Exception

                    MimeType = String.Empty

                End Try

                Try

                    Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentID)
                    'If FileBytes.Length > 0 Then
                    Response.AddHeader("Content-Length", Document.s_FILE_SIZE)
                    Return File(FileBytes, MimeType, RealFilename)
                    'Else
                    ' Return Nothing
                    'End If


                Catch ex As Exception

                End Try

            Else
                Dim newDocument As New Document(Session("ConnString"))
                Dim GridItem As Telerik.Web.UI.GridItem
                Dim outputStream As New System.IO.MemoryStream

                Dim zip As New ZipFile

                Dim dt As DataTable

                Dim DtRecs As New DataTable
                Dim rep As New DocumentRepository(CStr(Session("ConnString")))
                Dim RealFilename As String
                Dim MimeType As String = ""




                Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
                COL_DOC_ID.DataType = GetType(Int32)

                Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
                COL_MIME_TYPE.DataType = GetType(String)

                Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
                COL_FILENAME.DataType = GetType(String)

                Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
                COL_REPOSITORY_FILENAME.DataType = GetType(String)

                Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
                COL_UPLOADED_DATE.DataType = GetType(DateTime)

                With DtRecs.Columns
                    .Add(COL_DOC_ID)
                    .Add(COL_FILENAME)
                    .Add(COL_REPOSITORY_FILENAME)
                    .Add(COL_UPLOADED_DATE)
                End With


                dt = newDocument.GetCurrentExpenseDocument(InvoiceNumber, "", "", 1, 1)

                For Each dr As DataRow In dt.Rows
                    Dim r As DataRow
                    r = DtRecs.NewRow()
                    r("DocId") = dr("Document_Id")
                    r("Filename") = dr("FILENAME").ToString()
                    r("RepositoryFilename") = dr("REPOSITORY_FILENAME").ToString()
                    r("UploadedDate") = CType(dr("UPLOADED_DATE"), DateTime)
                    DtRecs.Rows.Add(r)

                Next

                If Not DtRecs Is Nothing Then
                    If DtRecs.Rows.Count > 0 Then
                        rep.GetDocuments(DtRecs, zip)
                        RealFilename = "Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip"
                        MimeType = "application/x-zip-compressed"

                        zip.Save(outputStream)
                        Dim FileBytes() As Byte = outputStream.ToArray

                        Return File(FileBytes, MimeType, RealFilename)

                    End If
                End If


            End If

        End Function

        <Http.HttpGet>
        Public Function CopyReceipt(ByVal DocumentID As Integer, ByVal InvoiceNumber As Integer) As Mvc.JsonResult



            Dim newDocumentID As Integer = 0
            Dim newDocument As New Document(Me.SecuritySession.ConnectionString)
            Dim FileUploadedSuccessfully As Boolean = True
            Dim Document As New Document(Session("ConnString"))
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Document.LoadByPrimaryKey(DocumentID)

            Dim DocumentManagerFilename As String
            Dim DocumentRepository As New DocumentRepository(Session("ConnString"))
            Dim RealFilename As String = Document.FILENAME  ' Filename
            Dim SplitFileName As String()
            Dim strErr As String = Nothing
            Dim timeFormat As String = "yyyy_MM_dd_HH_mm_ss"



            SplitFileName = RealFilename.Split(".")
            Dim SPF As Integer = UBound(SplitFileName)

            If SPF = 1 Then
                SplitFileName(0) = SplitFileName(0) & Date.Now.ToString(timeFormat)
                RealFilename = SplitFileName(0) & "." & SplitFileName(1)
            Else
                RealFilename = Nothing
                For tcount = 0 To (SPF - 1)
                    RealFilename = RealFilename & SplitFileName(tcount) & "."

                Next
                RealFilename = RealFilename & Date.Now.ToString(timeFormat) & "." & SplitFileName(SPF)
            End If


            Dim MimeType As String = ""
            Try

                MimeType = Document.MIME_TYPE

            Catch ex As Exception

                MimeType = String.Empty

            End Try


            Dim FileBytes() As Byte = DocumentRepository.GetDocument(DocumentID)

            Try
                DocumentManagerFilename = DocumentRepository.AddDocument(RealFilename, FileBytes, RealFilename, "", Session("EmployeeName"), "Expense Invoice", "no", "d_")
            Catch ex As Exception
                FileUploadedSuccessfully = False
                strErr = "Error saving actual file."
            End Try


            Try
                newDocumentID = newDocument.Add(RealFilename, MimeType, DocumentManagerFilename, Document.s_FILE_SIZE, Session("UserCode"), RealFilename, "", 0, 3)

                Dim LinkDocumentToInvoice As Boolean = newDocument.AddExpenseDocument(newDocumentID, InvoiceNumber)

            Catch ex As Exception

            End Try

            Try



                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    Dim ThumbnailUpdated As Boolean = False
                    Try
                        If Agency Is Nothing Then

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        End If
                    Catch ex As Exception
                        Agency = Nothing
                    End Try

                    If Agency IsNot Nothing Then

                        AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(DbContext, Agency, newDocumentID, Nothing)

                    End If

                End Using



            Catch ex As Exception
            End Try


        End Function

        Public Function DeleteReceipt(ByVal DocumentID As Integer) As Mvc.JsonResult

            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            If AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName, ErrorMessage) = True Then

                                Try

                                    If AdvantageFramework.Database.Procedures.ExpenseReportDocument.Delete(DbContext, Document.ID) Then

                                        Try

                                            If AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document) = True Then

                                                Deleted = True

                                            End If

                                        Catch ex As Exception
                                            Deleted = False
                                            ErrorMessage = "Could not delete document database record.  " & AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                        End Try

                                    End If

                                Catch ex As Exception
                                    Deleted = False
                                    ErrorMessage = "Could not delete expense document database record.  " & AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                End Try

                            Else

                                Deleted = False
                                ErrorMessage = "Could not delete document from repository.  " & ErrorMessage

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Success = Deleted,
                                     .Message = ErrorMessage})

        End Function

        Public Function DeleteReceiptUnassigned(ByVal DocumentID As Integer) As Mvc.JsonResult

            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            If AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName, ErrorMessage) = True Then

                                Try

                                    If AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.Delete(DbContext, Document.ID) Then

                                        Try

                                            If AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document) = True Then

                                                Deleted = True

                                            End If

                                        Catch ex As Exception
                                            Deleted = False
                                            ErrorMessage = "Could not delete document database record.  " & AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                        End Try

                                    End If

                                Catch ex As Exception
                                    Deleted = False
                                    ErrorMessage = "Could not delete expense document database record.  " & AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                End Try

                            Else

                                Deleted = False
                                ErrorMessage = "Could not delete document from repository.  " & ErrorMessage

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Success = Deleted,
                                     .Message = ErrorMessage})

        End Function


        <Http.HttpGet>
        Public Function ReceiptToGrid(ByVal DocumentID As Integer, ByVal RowNumber As Integer, ByVal InvoiceNumber As Integer) As Mvc.JsonResult

            Dim Inserted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Dim ExpenseDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
                ExpenseDocument = AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByDocumentID(DbContext, DocumentID)

                If ExpenseDocument Is Nothing Then
                    Dim ExpDocument = New AdvantageFramework.Database.Entities.ExpenseReportDocument
                    ExpDocument.DocumentID = DocumentID
                    ExpDocument.InvoiceNumber = InvoiceNumber

                    Try
                        AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpDocument)
                    Catch ex As Exception
                        Inserted = False
                    End Try

                    If Inserted = True Then
                        Dim ExpenseDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned = Nothing
                        ExpenseDocumentUnassigned = AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.LoadByDocumentID(DbContext, DocumentID)

                        If ExpenseDocumentUnassigned IsNot Nothing Then
                            AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.Delete(DbContext, ExpenseDocumentUnassigned)
                        End If

                    End If

                End If

                Dim ExpenseDetailDocument = New AdvantageFramework.Database.Entities.ExpenseDetailDocument
                ExpenseDetailDocument.DocumentID = DocumentID
                ExpenseDetailDocument.ExpenseDetailID = RowNumber

                Try
                    AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Insert(DbContext, ExpenseDetailDocument)
                Catch ex As Exception
                    Inserted = False
                End Try

            End Using

            Return Json(Inserted, Mvc.JsonRequestBehavior.AllowGet)

        End Function


        <Http.HttpGet>
        Public Function RemoveReceiptFromGrid(ByVal DocumentID As Integer, ByVal RowNumber As Integer) As Mvc.JsonResult

            Dim Removed As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try
                    AdvantageFramework.Database.Procedures.ExpenseDetailDocument.Delete(DbContext, DocumentID, RowNumber)
                Catch ex As Exception
                    Removed = False
                End Try

            End Using

            Return Json(Removed, Mvc.JsonRequestBehavior.AllowGet)

        End Function


        Private Function FileTypeIsValid(ByVal File As HttpPostedFileBase) As Boolean

            Dim IsValid As Boolean = True
            Dim BlackList As Generic.List(Of String)

            BlackList = AdvantageFramework.DocumentManager.BlackListedFileTypes

            If BlackList.Contains(Path.GetExtension(File.FileName)) = True Then

                IsValid = False

            End If

            Return IsValid

        End Function


#End Region

#End Region


    End Class


    Public Class ColumnShow
        Public Property Column As String
        Public Property Show As Boolean
    End Class



    Public Class GridRowID

        Public Property DOCUMENT_ID As Integer = 0
        Public Property EXPDETAILID As Integer = 0

    End Class


End Namespace

