Imports System
Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Web

Namespace ExpenseReports

    <HideModuleName()>
    Public Module Methods

#Region " Constants "


#End Region

#Region " Enum "

        Public Enum ExpenseReportStatus As Short

            Open = 0
            Pending = 1
            Approved = 2
            PendingApproval = 3
            DeniedByApprover = 4
            ApprovedByApprover = 5
            ApprovedInAccounting = 6
            PendingApprovalInAccounting = 7
            DeniedByAccounting = 8

        End Enum
        Public Enum ApprovedFlag As Short

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Pending")>
            Pending = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Denied")>
            Denied = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Approved")>
            Approved = 2

        End Enum
        Public Enum ApprovalURLType As Short

            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "View")>
            View = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Approve")>
            Approve = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Deny")>
            Deny = 2

        End Enum

#End Region

#Region " Variables "

        'Private _ExcludedJobProcessControlNumbers As Integer() = {2, 5, 6, 7, 10, 11, 12}
        Private _AllowedJobProcessControlNumbers As Integer() = {1, 3, 4, 8, 9, 13}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ValidateExpenseFunction(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal FunctionCode As String,
                                             ByRef ErrorMessage As String) As Boolean

            Dim IsValid = True

            If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                Dim ExpenseFunction As AdvantageFramework.Database.Entities.Function

                ExpenseFunction = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode)

                If ExpenseFunction Is Nothing Then

                    ErrorMessage = "Invalid function."
                    IsValid = False

                Else

                    If ExpenseFunction.EmployeeExpenseFlag IsNot Nothing AndAlso
                                        ExpenseFunction.EmployeeExpenseFlag = 1 Then

                        If ExpenseFunction.IsInactive IsNot Nothing AndAlso
                                            ExpenseFunction.IsInactive = 1 Then

                            ErrorMessage = "Function is inactive."
                            IsValid = False

                        End If

                    Else

                        ErrorMessage = "Not an expense function."
                        IsValid = False

                    End If

                End If

            End If

            Return IsValid

        End Function
        Public Function LoadExpenseReportStatus(ByVal Status As Integer, ByVal IsSubmitted As Integer, ByVal IsApproved As Integer) As AdvantageFramework.ExpenseReports.ExpenseReportStatus

            'objects
            Dim ExpenseReportStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing

            Select Case Status

                Case 0

                    ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Open

                Case 1

                    If IsSubmitted = 0 Then

                        ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Pending

                    Else

                        If IsApproved = 0 Then

                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.PendingApproval

                        ElseIf IsApproved = 1 Then

                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByApprover

                        Else

                            ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedByApprover

                        End If

                    End If

                Case 2

                    If IsApproved = 0 Then

                        ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Approved

                    Else

                        ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.ApprovedInAccounting

                    End If

                Case 4

                    ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.PendingApprovalInAccounting

                Case 5

                    ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.DeniedByAccounting

            End Select

            LoadExpenseReportStatus = ExpenseReportStatus

        End Function
        Public Function LoadExpenseReportStatus(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As AdvantageFramework.ExpenseReports.ExpenseReportStatus

            LoadExpenseReportStatus = LoadExpenseReportStatus(ExpenseReport.Status.GetValueOrDefault(0), ExpenseReport.IsSubmitted.GetValueOrDefault(0), ExpenseReport.IsApproved.GetValueOrDefault(0))

        End Function
        Public Function CalculateLineItemAmount(ByVal ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem) As Decimal

            'objects
            Dim Amount As Decimal = 0

            If ExpenseReportItem.Quantity IsNot Nothing AndAlso ExpenseReportItem.Rate IsNot Nothing Then

                Amount = CDec(ExpenseReportItem.Quantity * ExpenseReportItem.Rate)

            End If

            CalculateLineItemAmount = Amount

        End Function
        Public Sub CalculateExpenseReportDetailsTotals(ByVal ExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem), ByRef TotalAmount As Decimal, ByRef TotalCreditCard As Decimal, ByRef TotalDue As Decimal)

            Try

                TotalAmount = (From ExpenseReportItem In ExpenseReportItems
                               Select ExpenseReportItem.Amount).Sum

                TotalCreditCard = (From ExpenseReportItem In ExpenseReportItems
                                   Where ExpenseReportItem.CreditCardFlag.GetValueOrDefault(False) = True
                                   Select ExpenseReportItem.Amount).Sum

                TotalDue = TotalAmount - TotalCreditCard

            Catch ex As Exception

                TotalAmount = 0
                TotalCreditCard = 0
                TotalDue = 0

            End Try

        End Sub
        Public Sub CalculateExpenseReportDetailsTotals(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceNumber As Integer, ByRef TotalAmount As Decimal, ByRef TotalCreditCard As Decimal, ByRef TotalDue As Decimal)

            'objects
            Dim ExpenseReportItems As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem) = Nothing

            Try

                ExpenseReportItems = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False)
                                      Select Entity).ToList.Select(Function(Entity) New AdvantageFramework.Database.Classes.ExpenseReportItem(Entity, "", DbContext)).ToList

                CalculateExpenseReportDetailsTotals(ExpenseReportItems, TotalAmount, TotalCreditCard, TotalDue)

            Catch ex As Exception

                TotalAmount = 0
                TotalCreditCard = 0
                TotalDue = 0

            End Try

        End Sub
        Public Function CalculateNonBillableAmount(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceNumber As Integer) As Decimal

            Dim NonBillTotal As Decimal = Nothing
            Dim ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing

            Try

                ExpenseReportDetails = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, InvoiceNumber, False).ToList

                For Each ExpenseReportDetail In ExpenseReportDetails

                    If Convert.ToBoolean(AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, ExpenseReportDetail.FunctionCode).NonBillableFlag.GetValueOrDefault(0)) Then

                        NonBillTotal += ExpenseReportDetail.Amount

                    End If

                Next

            Catch ex As Exception
                NonBillTotal = Nothing
            Finally
                CalculateNonBillableAmount = NonBillTotal
            End Try

        End Function
        Public Sub LoadExpenseReportTotals(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ExpenseReport As AdvantageFramework.Database.Classes.ExpenseReport)

            Dim TotalAmount As Decimal = Nothing
            Dim BillableTotal As Decimal = Nothing
            Dim NonBillTotal As Decimal = Nothing
            Dim ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail) = Nothing
            Dim ExpenseReportItemList As Generic.List(Of AdvantageFramework.Database.Classes.ExpenseReportItem) = Nothing
            Dim EmployeeCode As String = Nothing

            Try

                ExpenseReportDetails = AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False).ToList

                If ExpenseReportDetails IsNot Nothing Then

                    EmployeeCode = ExpenseReport.EmployeeCode

                    ExpenseReportItemList = ExpenseReportDetails.Select(Function(ExpenseReportDetail) New AdvantageFramework.Database.Classes.ExpenseReportItem(ExpenseReportDetail, EmployeeCode, DbContext)).ToList

                    For Each ExpenseReportItem In ExpenseReportItemList

                        If ExpenseReportItem.NonBillable = False Then

                            BillableTotal = BillableTotal + ExpenseReportItem.Amount.GetValueOrDefault(0)

                        Else

                            NonBillTotal = NonBillTotal + ExpenseReportItem.Amount.GetValueOrDefault(0)

                        End If

                    Next

                End If

                TotalAmount = BillableTotal + NonBillTotal

            Catch ex As Exception
                NonBillTotal = Nothing
                BillableTotal = Nothing
                TotalAmount = Nothing
            End Try

            ExpenseReport.TotalAmount = TotalAmount
            ExpenseReport.TotalBillable = BillableTotal
            ExpenseReport.TotalNonBillable = NonBillTotal

        End Sub
        Public Function LoadBillingRate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionCode As String,
                                             Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                             Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber As String = Nothing,
                                             Optional ByVal JobComponentNumber As String = Nothing, Optional ByVal SalesClassCode As String = Nothing,
                                             Optional ByVal EmployeeCode As String = Nothing, Optional ByVal EffectiveDate As Nullable(Of System.DateTime) = Nothing,
                                             Optional ByVal EmpTitleID As Nullable(Of System.Int32) = Nothing) As AdvantageFramework.Database.Classes.BillingRate

            'objects
            Dim ExecuteStatement As String = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim FunctionType As String = Nothing

            Try

                FunctionType = (From [Function] In DbContext.GetQuery(Of Database.Entities.Function)
                                Where [Function].Code = FunctionCode
                                Select [Function].Type).SingleOrDefault

            Catch ex As Exception
                FunctionType = Nothing
            End Try

            If EffectiveDate.HasValue Then

                If EffectiveDate.Value = Date.MinValue Then

                    EffectiveDate = Nothing

                End If

            End If

            Try

                ExecuteStatement = String.Format("SELECT * FROM dbo.advtf_get_billing_rate({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                                 If(EmployeeCode IsNot Nothing, "'" & EmployeeCode & "'", "NULL"),
                                                 If(EffectiveDate IsNot Nothing, "'" & EffectiveDate.Value.ToString("MM/dd/yyyy") & "'", "NULL"),
                                                 If(FunctionCode IsNot Nothing, "'" & FunctionCode & "'", "NULL"),
                                                 If(ClientCode IsNot Nothing, "'" & ClientCode & "'", "NULL"),
                                                 If(DivisionCode IsNot Nothing, "'" & DivisionCode & "'", "NULL"),
                                                 If(ProductCode IsNot Nothing, "'" & ProductCode & "'", "NULL"),
                                                 If(SalesClassCode IsNot Nothing, "'" & SalesClassCode & "'", "NULL"),
                                                 If(FunctionType IsNot Nothing, "'" & FunctionType & "'", "NULL"),
                                                 If(JobNumber <> Nothing, JobNumber, "NULL"),
                                                 If(JobComponentNumber <> Nothing, JobComponentNumber, "NULL"),
                                                 If(EmpTitleID IsNot Nothing, EmpTitleID, "NULL"))

                BillingRate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingRate)(ExecuteStatement).FirstOrDefault

            Catch ex As Exception
                BillingRate = Nothing
            End Try

            LoadBillingRate = BillingRate

        End Function
        Public Function LoadBillingRateByItem(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportItem As AdvantageFramework.Database.Classes.ExpenseReportItem) As AdvantageFramework.Database.Classes.BillingRate

            ' objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            If ExpenseReportItem.FunctionCode IsNot Nothing Then

                BillingRate = LoadBillingRate(DbContext, ExpenseReportItem.FunctionCode, ExpenseReportItem.ClientCode, ExpenseReportItem.DivisionCode, ExpenseReportItem.ProductCode,
                                              ExpenseReportItem.JobNumber.ToString, ExpenseReportItem.JobComponentNumber.ToString, Nothing, Nothing, ExpenseReportItem.ItemDate)

            End If

            LoadBillingRateByItem = BillingRate

        End Function
        Public Function LoadBillingRateByItem(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail) As AdvantageFramework.Database.Classes.BillingRate

            ' objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing

            If ExpenseReportDetail.FunctionCode IsNot Nothing Then

                BillingRate = LoadBillingRate(DbContext, ExpenseReportDetail.FunctionCode, ExpenseReportDetail.ClientCode, ExpenseReportDetail.DivisionCode, ExpenseReportDetail.ProductCode,
                                              ExpenseReportDetail.JobNumber.ToString, ExpenseReportDetail.JobComponentNumber.ToString, Nothing, Nothing, ExpenseReportDetail.ItemDate)

            End If

            LoadBillingRateByItem = BillingRate

        End Function
        Private Function IsApproved(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            'objects
            Dim Approved As Boolean = False

            Try

                Select Case LoadExpenseReportStatus(ExpenseReport)

                    Case ExpenseReportStatus.Approved, ExpenseReportStatus.ApprovedByApprover, ExpenseReportStatus.ApprovedInAccounting

                        Approved = True

                    Case Else

                        Approved = False

                End Select

            Catch ex As Exception
                Approved = False
            Finally
                IsApproved = Approved
            End Try

        End Function
        Public Function SubmitExpenseReport(ByVal Session As AdvantageFramework.Security.Session,
                                            ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport,
                                            ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                            ByVal IncludeReceiptsInEmailAndAlert As Boolean, ByRef ErrorText As String,
                                            Optional ByVal SendEmail As Boolean = True, Optional ByRef AlertID As Integer = 0,
                                            Optional ByVal SubmitDirectToAP As Boolean = False) As Boolean

            'objects
            Dim Submitted As Boolean = False
            Dim OkToSubmit As Boolean = True
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim SystemGeneratedExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If Employee IsNot Nothing AndAlso ExpenseReport IsNot Nothing Then

                        If IsApproved(ExpenseReport) Then

                            ErrorText = "Expense report has already been approved and cannot be modified."
                            OkToSubmit = False

                        ElseIf CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) AndAlso ExpenseReport.SubmittedTo = "" AndAlso
                               (Employee.SupervisorEmployeeCode Is Nothing OrElse Employee.SupervisorEmployeeCode.Trim = "") AndAlso
                               (Employee.AlternateApproverCode Is Nothing OrElse Employee.AlternateApproverCode.Trim = "") Then

                            ErrorText = "Approval is required, but no supervisor or alternate approver is on file."
                            OkToSubmit = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False)
                                Select Entity).Any = False Then

                            ErrorText = "Please add an Expense Line Item before submitting."
                            OkToSubmit = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False)
                                Where Entity.Amount Is Nothing OrElse Entity.Amount = 0
                                Select Entity).Any Then

                            ErrorText = "Please enter an amount for all line items."
                            OkToSubmit = False

                        End If

                        If OkToSubmit Then

                            ExpenseReport.Status = ExpenseReportStatus.Pending
                            ExpenseReport.IsSubmitted = CShort(1)

                            If CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) Then

                                If SubmitDirectToAP Then

                                    ExpenseReport.IsApproved = CShort(2)
                                    ExpenseReport.ApprovedBy = ExpenseReport.SubmittedTo
                                    ExpenseReport.ApprovedDate = System.DateTime.Now

                                Else

                                    ExpenseReport.IsApproved = CShort(0)

                                    If CreateExpenseApprovalAlert(DbContext, ExpenseReport, Employee, Alert, IncludeReceiptsInEmailAndAlert) = True AndAlso SendEmail = True Then

                                        AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session,
                                                                                              Alert,
                                                                                              Subject:=Alert.Subject,
                                                                                              AppName:="Expense",
                                                                                              ErrorMessage:=ErrorText)

                                    End If

                                    If Alert IsNot Nothing Then AlertID = Alert.ID

                                End If

                            Else

                                ExpenseReport.Status = ExpenseReportStatus.Pending
                                ExpenseReport.IsApproved = CShort(0)

                            End If

                            If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) Then

                                If (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False)
                                    Where Entity.CreditCardFlag = True
                                    Select Entity).Any Then

                                    SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@InvoiceNBR", SqlDbType.Int)
                                    SqlParameterInvoiceNumber.Value = ExpenseReport.InvoiceNumber

                                    If DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[usp_wv_exp_insert_credit_line] @InvoiceNBR;", SqlParameterInvoiceNumber).FirstOrDefault = 1 Then

                                        Submitted = True

                                    End If

                                Else

                                    Submitted = True

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                Submitted = False
                ErrorText = "There was an error submitting the expense report. Please contact support."
            Finally
                SubmitExpenseReport = Submitted
            End Try

        End Function
        Public Function SubmitExpenseReport(ByVal Session As AdvantageFramework.Security.Session, ByVal InvoiceNumber As Integer,
                                            ByVal IncludeReceiptsInEmailAndAlert As Boolean, ByRef ErrorText As String, Optional ByVal SubmitDirectToAP As Boolean = False) As Boolean

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                End If

                SubmitExpenseReport = SubmitExpenseReport(Session, ExpenseReport, Employee, IncludeReceiptsInEmailAndAlert, ErrorText, SubmitDirectToAP:=SubmitDirectToAP)

            End Using

        End Function
        Public Function UnSubmitExpenseReport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport,
                                              ByRef ErrorText As String) As Boolean

            'objects
            Dim UnSubmitted As Boolean = False
            Dim OkToUnSubmit As Boolean = True
            Dim CreditLineExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim SqlParameterInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing

            Try

                If IsApproved(ExpenseReport) Then

                    ErrorText = "Expense report has already been approved and cannot be modified."
                    OkToUnSubmit = False

                End If

                If OkToUnSubmit Then

                    If ExpenseReport.Status <> 5 Then

                        ExpenseReport.SubmittedTo = Nothing

                    End If

                    ExpenseReport.Status = ExpenseReportStatus.Open
                    ExpenseReport.IsApproved = CShort(0)
                    ExpenseReport.IsSubmitted = CShort(0)

                    UnSubmitted = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport)

                    If UnSubmitted Then

                        SqlParameterInvoiceNumber = New System.Data.SqlClient.SqlParameter("@InvoiceNBR", SqlDbType.Int)
                        SqlParameterInvoiceNumber.Value = ExpenseReport.InvoiceNumber

                        DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_exp_delete_credit_line @InvoiceNBR", SqlParameterInvoiceNumber)

                    End If

                End If

            Catch ex As Exception
                UnSubmitted = False
                ErrorText = "Failed trying to unsubmit. Please contact software support."
            Finally
                UnSubmitExpenseReport = UnSubmitted
            End Try

        End Function
        Public Function CreateExpenseReportsFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCreditCardStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging)) As Boolean

            Dim Imported As Boolean = True
            Dim EmployeeCodes As String() = Nothing
            Dim EmployeeCode As String = Nothing
            Dim EmployeeImportCreditCardStagings As Generic.List(Of AdvantageFramework.Database.Entities.ImportCreditCardStaging) = Nothing
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReportDates() As Date = Nothing
            Dim ExpenseReportDate As Date = Nothing

            Try

                EmployeeCodes = ImportCreditCardStagings.Select(Function(ImpCreditCardStaging) ImpCreditCardStaging.EmployeeCode).Distinct.ToArray

                For Each EmployeeCode In EmployeeCodes

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        Try

                            ExpenseReportDates = (From Entity In ImportCreditCardStagings
                                                  Where Entity.EmployeeCode = EmployeeCode
                                                  Select [ExpRptDate] = Entity.ExpenseReportDate.Value Distinct
                                                  Order By ExpRptDate Ascending).ToArray

                        Catch ex As Exception
                            ExpenseReportDates = Nothing
                        End Try

                        For Each ExpenseReportDate In ExpenseReportDates

                            Try

                                EmployeeImportCreditCardStagings = (From Entity In ImportCreditCardStagings
                                                                    Where Entity.EmployeeCode = EmployeeCode AndAlso
                                                                          Entity.ExpenseReportDate = ExpenseReportDate
                                                                    Select Entity).ToList

                            Catch ex As Exception
                                EmployeeImportCreditCardStagings = Nothing
                            End Try

                            If EmployeeImportCreditCardStagings IsNot Nothing AndAlso EmployeeImportCreditCardStagings.Count > 0 Then

                                ImportCreditCardStaging = EmployeeImportCreditCardStagings.FirstOrDefault

                                ExpenseReport = New AdvantageFramework.Database.Entities.ExpenseReport

                                ExpenseReport.DbContext = DbContext
                                ExpenseReport.IsSubmitted = 0
                                ExpenseReport.IsApproved = 0
                                ExpenseReport.Status = 0
                                ExpenseReport.EmployeeCode = EmployeeCode
                                ExpenseReport.VendorCode = Employee.EmployeeVendorCode
                                ExpenseReport.InvoiceDate = ImportCreditCardStaging.ExpenseReportDate
                                ExpenseReport.Description = ImportCreditCardStaging.ExpenseReportDescription
                                ExpenseReport.Details = ImportCreditCardStaging.ExpenseReportDetail

                                If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) Then

                                    For Each ImportCreditCardStaging In EmployeeImportCreditCardStagings

                                        ExpenseReportDetail = New AdvantageFramework.Database.Entities.ExpenseReportDetail

                                        ExpenseReportDetail.DbContext = DbContext
                                        ExpenseReportDetail.InvoiceNumber = ExpenseReport.InvoiceNumber

                                        Try

                                            ExpenseReportDetail.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False)
                                                                              Select Entity.LineNumber).Max + 1

                                        Catch ex As Exception
                                            ExpenseReportDetail.LineNumber = 1
                                        End Try

                                        ExpenseReportDetail.ItemDate = ImportCreditCardStaging.ItemDate
                                        ExpenseReportDetail.Description = ImportCreditCardStaging.ItemDescription
                                        ExpenseReportDetail.CreditCardFlag = ImportCreditCardStaging.CreditCardFlag
                                        ExpenseReportDetail.ClientCode = ImportCreditCardStaging.ClientCode
                                        ExpenseReportDetail.DivisionCode = ImportCreditCardStaging.DivisionCode
                                        ExpenseReportDetail.ProductCode = ImportCreditCardStaging.ProductCode

                                        If ImportCreditCardStaging.JobNumber.HasValue Then

                                            ExpenseReportDetail.JobNumber = ImportCreditCardStaging.JobNumber

                                            If ImportCreditCardStaging.JobComponentID.HasValue Then

                                                Try

                                                    ExpenseReportDetail.JobComponentNumber = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, ImportCreditCardStaging.JobComponentID).Number

                                                Catch ex As Exception
                                                    ExpenseReportDetail.JobComponentNumber = Nothing
                                                End Try

                                            End If

                                        End If

                                        If ExpenseReportDetail.JobNumber.HasValue = False OrElse ExpenseReportDetail.JobComponentNumber.HasValue = False Then

                                            ExpenseReportDetail.JobNumber = Nothing
                                            ExpenseReportDetail.JobComponentNumber = Nothing

                                        End If

                                        ExpenseReportDetail.FunctionCode = ImportCreditCardStaging.FunctionCode
                                        ExpenseReportDetail.Quantity = ImportCreditCardStaging.Quantity
                                        ExpenseReportDetail.Rate = ImportCreditCardStaging.Rate
                                        ExpenseReportDetail.Amount = ImportCreditCardStaging.Amount
                                        ExpenseReportDetail.CreatedBy = DbContext.UserCode
                                        ExpenseReportDetail.IsImported = True

                                        If ImportCreditCardStaging.CreditCardFlag Then

                                            ExpenseReportDetail.PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.CorporateCreditCard

                                        Else

                                            ExpenseReportDetail.PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash

                                        End If

                                        If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseReportDetail) Then

                                            AdvantageFramework.Database.Procedures.ImportCreditCardStaging.Delete(DbContext, ImportCreditCardStaging)

                                        Else

                                            Imported = False

                                        End If

                                    Next

                                Else

                                    Imported = False

                                End If

                            End If

                        Next

                    Else

                        Imported = False

                    End If

                Next

            Catch ex As Exception
                Imported = False
            Finally
                CreateExpenseReportsFromImport = Imported
            End Try

        End Function
        Public Function HasExpenseReportBeenPaid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal InvoiceNumber As Integer) As Boolean

            'objects
            Dim QueryString As String = ""
            Dim Paid As Boolean = False

            Try

                QueryString = String.Format("SELECT count(*) " &
                                            "FROM AP_PMT_HIST APH " &
                                            "WHERE APH.AP_ID IN " &
                                                 "( SELECT DISTINCT AH.AP_ID " &
                                                 "FROM AP_HEADER AH, EXPENSE_HEADER EH " &
                                                 "WHERE AH.VN_FRL_EMP_CODE = EH.VN_CODE " &
                                                 "AND AH.AP_INV_VCHR = cast(EH.INV_NBR AS varchar(20)) " &
                                                 "AND EH.EMP_CODE = '{0}' " &
                                                 "AND EH.INV_NBR = {1} ) " &
                                            "GROUP BY APH.AP_ID, AP_CHK_NBR " &
                                            "HAVING SUM(APH.AP_CHK_AMT) > 0 ",
                                            EmployeeCode, InvoiceNumber)


                If DbContext.Database.SqlQuery(Of Integer)(QueryString).FirstOrDefault > 0 Then

                    Paid = True

                End If

            Catch ex As Exception
                Paid = False
            Finally
                HasExpenseReportBeenPaid = Paid
            End Try

        End Function

        Public Function CopyExpenseReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef InvoiceNumber As Integer, ByVal EmployeeCode As String,
                                          ByVal ReportDate As System.DateTime, ByVal Description As String, ByVal Details As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim DuplicateExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim DuplicateExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim VendorCode As String = Nothing

            Try

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    If String.IsNullOrEmpty(EmployeeCode) = False Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            VendorCode = Employee.EmployeeVendorCode

                        End If

                    Else

                        EmployeeCode = ExpenseReport.EmployeeCode
                        VendorCode = ExpenseReport.VendorCode

                    End If

                    If String.IsNullOrEmpty(VendorCode) Then

                        ErrorText = "Please select a valid employee."

                    Else

                        DuplicateExpenseReport = ExpenseReport.DuplicateEntity()

                        DuplicateExpenseReport.DbContext = DbContext
                        DuplicateExpenseReport.EmployeeCode = EmployeeCode
                        DuplicateExpenseReport.Description = Description
                        DuplicateExpenseReport.Details = Details
                        DuplicateExpenseReport.VendorCode = VendorCode
                        DuplicateExpenseReport.InvoiceDate = ReportDate
                        DuplicateExpenseReport.Status = 0
                        DuplicateExpenseReport.IsApproved = 0
                        DuplicateExpenseReport.IsSubmitted = 0

                        DuplicateExpenseReport.DateFrom = Nothing
                        DuplicateExpenseReport.DateTo = Nothing
                        DuplicateExpenseReport.InvoiceAmount = Nothing
                        DuplicateExpenseReport.ApprovedBy = Nothing
                        DuplicateExpenseReport.ApprovedDate = Nothing
                        DuplicateExpenseReport.ApproverNotes = Nothing
                        DuplicateExpenseReport.ModifiedBy = Nothing
                        DuplicateExpenseReport.ModifiedDate = Nothing
                        DuplicateExpenseReport.SubmittedTo = Nothing

                        If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, DuplicateExpenseReport) Then

                            InvoiceNumber = DuplicateExpenseReport.InvoiceNumber

                            Copied = True

                            For Each ExpenseReportDetail In AdvantageFramework.Database.Procedures.ExpenseReportDetail.LoadByInvoiceNumber(DbContext, ExpenseReport.InvoiceNumber, False).ToList

                                Try

                                    DuplicateExpenseReportDetail = ExpenseReportDetail.DuplicateEntity()

                                    DuplicateExpenseReportDetail.DbContext = DbContext
                                    DuplicateExpenseReportDetail.InvoiceNumber = DuplicateExpenseReport.InvoiceNumber

                                    DuplicateExpenseReportDetail.ModifiedBy = Nothing
                                    DuplicateExpenseReportDetail.ModifiedDate = Nothing
                                    DuplicateExpenseReportDetail.APComment = Nothing
                                    DuplicateExpenseReportDetail.ID = Nothing

                                    If DuplicateExpenseReportDetail.JobNumber.HasValue Then

                                        If DuplicateExpenseReportDetail.JobNumber <= 0 Then

                                            DuplicateExpenseReportDetail.JobNumber = Nothing
                                            DuplicateExpenseReportDetail.JobComponentNumber = Nothing

                                        End If

                                    ElseIf DuplicateExpenseReportDetail.JobComponentNumber.HasValue Then

                                        If DuplicateExpenseReportDetail.JobComponentNumber <= 0 Then

                                            DuplicateExpenseReportDetail.JobNumber = Nothing
                                            DuplicateExpenseReportDetail.JobComponentNumber = Nothing

                                        End If

                                    End If

                                    If DuplicateExpenseReportDetail.PaymentType.HasValue = False Then

                                        If ExpenseReportDetail.PaymentType.HasValue Then

                                            DuplicateExpenseReportDetail.PaymentType = ExpenseReportDetail.PaymentType

                                        ElseIf ExpenseReportDetail.CreditCardFlag.GetValueOrDefault(False) = True Then

                                            DuplicateExpenseReportDetail.PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.CorporateCreditCard

                                        Else

                                            DuplicateExpenseReportDetail.PaymentType = AdvantageFramework.Database.Entities.ExpenseItemPaymentType.Cash

                                        End If

                                    End If

                                    AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, DuplicateExpenseReportDetail)

                                Catch ex As Exception

                                End Try

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally

                If Copied = False AndAlso ErrorText = "" Then

                    ErrorText = "There was a problem copying the expense report."

                End If

                CopyExpenseReport = Copied

            End Try

        End Function
        Public Function LoadExpenseEmployees(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal IncludeTerminated As Boolean) As IEnumerable(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim LimitEmployeeToSelf As Boolean = False
            Dim Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Try

                Try

                    If (From UserSetting In AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserID(SecurityDbContext, Session.User.ID).ToList
                        Where UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.SI_DO_OWN_TS.ToString AndAlso
                              UserSetting.StringValue IsNot Nothing AndAlso
                              UserSetting.StringValue = "Y"
                        Select UserSetting).Any Then

                        LimitEmployeeToSelf = True

                    End If

                Catch ex As Exception
                    LimitEmployeeToSelf = False
                End Try

                Employees = From Emp In AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, True)
                            Join EmpVen In AdvantageFramework.Database.Procedures.Vendor.LoadEmployeeVendors(DbContext) On Emp.EmployeeVendorCode Equals EmpVen.Code
                            Where EmpVen.ActiveFlag = 1 AndAlso
                                   Emp.Code = If(LimitEmployeeToSelf, Session.User.EmployeeCode, Emp.Code) AndAlso
                                   True = If(IncludeTerminated, True, Emp.TerminationDate Is Nothing)
                            Select Emp

            Catch ex As Exception
                Employees = Nothing
            Finally
                LoadExpenseEmployees = Employees
            End Try

        End Function
        Public Function LoadExpenseEmployees(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal UserCode As String, ByVal IncludeTerminated As Boolean) As IEnumerable(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

            LoadExpenseEmployees = LoadExpenseEmployees(Session, SecurityDbContext, DbContext, UserCode, IncludeTerminated)

        End Function
        Public Function IsEmployeeVendor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, Optional ByRef VendorCode As String = Nothing) As Boolean

            'objects
            Dim IsVendor As Boolean = False
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                Vendor = (From Ven In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                          Join Emp In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext) On Emp.EmployeeVendorCode Equals Ven.Code
                          Where Emp.Code = EmployeeCode
                          Select Ven).SingleOrDefault

                If Vendor IsNot Nothing Then

                    VendorCode = Vendor.Code
                    IsVendor = True

                End If

            Catch ex As Exception
                IsVendor = False
            Finally
                IsEmployeeVendor = IsVendor
            End Try

        End Function
        Public Function LoadAvailableApprovers(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal EmployeeCode As String) As IEnumerable(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ModuleCode As String = AdvantageFramework.Security.Modules.Employee_ExpenseApproval.ToString
            Dim Approvers As IEnumerable(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim ExpenseApproverCode As String = ""
            Dim SupervisorApproverCode As String = ""
            Dim EmployeeCodeToNotAllow As String = ""

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    Try

                        EmployeeCodes = AdvantageFramework.Security.Database.Procedures.UserPermissionView.Load(SecurityDbContext).Where(Function(Entity) Entity.ModuleCode = ModuleCode AndAlso Entity.IsBlocked = False).Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList

                    Catch ex As Exception

                    End Try

                    ExpenseApproverCode = Employee.AlternateApproverCode

                    If ExpenseApproverCode = Employee.Code Then

                        EmployeeCodeToNotAllow = ""

                    Else

                        EmployeeCodeToNotAllow = Employee.Code

                    End If

                    If Employee.SupervisorEmployeeCode <> Employee.Code Then

                        SupervisorApproverCode = Employee.SupervisorEmployeeCode 'only allow employee to approve self when Alternate Approver is set to self

                    End If

                    Approvers = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(Session, DbContext)
                                 Where EmployeeCodes.Contains(Entity.Code) AndAlso
                                       Entity.Code <> EmployeeCodeToNotAllow
                                 Select Entity).ToList

                    If Not Approvers.Any(Function(e) e.Code = ExpenseApproverCode OrElse e.Code = SupervisorApproverCode) Then

                        Approvers = Approvers.Union((From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                     Where EmployeeCodes.Contains(Item.Code) AndAlso
                                                           (Item.Code = ExpenseApproverCode OrElse
                                                            Item.Code = SupervisorApproverCode) AndAlso
                                                            Item.Code <> EmployeeCodeToNotAllow
                                                     Select Item).ToList).GroupBy(Function(e) e.Code).Select(Function(g) g.First).ToList

                    End If

                End If

            Catch ex As Exception
                Approvers = Nothing
            Finally
                LoadAvailableApprovers = Approvers
            End Try

        End Function
        Public Sub LoadAvailableDateRange(ByRef StartMonth As Integer, ByRef StartYear As Integer, ByRef EndMonth As Integer, ByRef EndYear As Integer)

            'objects
            Dim CurrentDateTime As System.DateTime = Nothing

            CurrentDateTime = System.DateTime.Now

            StartMonth = 1
            StartYear = CurrentDateTime.Year - 5

            EndMonth = 12
            EndYear = CurrentDateTime.Year + 5

        End Sub
        Public Function LoadMinimumReportDate() As Date

            'objects
            Dim StartMonth As Integer = Nothing
            Dim EndMonth As Integer = Nothing
            Dim StartYear As Integer = Nothing
            Dim EndYear As Integer = Nothing
            Dim MinimumDate As Date = Nothing

            LoadAvailableDateRange(StartMonth, StartYear, EndMonth, EndYear)

            MinimumDate = New Date(StartYear, StartMonth, 1)

            LoadMinimumReportDate = MinimumDate

        End Function
        Public Function LoadMaximumReportDate() As Date

            'objects
            Dim StartMonth As Integer = Nothing
            Dim EndMonth As Integer = Nothing
            Dim StartYear As Integer = Nothing
            Dim EndYear As Integer = Nothing
            Dim MaximumDate As Date = Nothing

            LoadAvailableDateRange(StartMonth, StartYear, EndMonth, EndYear)

            MaximumDate = New Date(EndYear, EndMonth, System.DateTime.DaysInMonth(EndYear, EndMonth))

            LoadMaximumReportDate = MaximumDate

        End Function
        Public Function CheckIfJobIsValid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As Boolean

            CheckIfJobIsValid = CheckIfJobComponentIsValid(DbContext, JobNumber, 0) '0 = all comps

        End Function
        Public Function CheckIfJobComponentIsValid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Boolean

            'objects
            Dim JobIsValid As Boolean = False
            Dim AllowedJobProcessControlNumbers As Integer() = Nothing
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing

            AllowedJobProcessControlNumbers = GetAllowedProcessControlNumbers()

            Try

                If (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                    Where Entity.JobNumber = JobNumber AndAlso
                          Entity.IsOpen = 1 AndAlso
                          Entity.JobComponentNumber = If(JobComponentNumber > 0, JobComponentNumber, Entity.JobComponentNumber) AndAlso
                          AllowedJobProcessControlNumbers.Contains(Entity.JobProcessControl) = True
                    Select Entity).Any Then

                    JobIsValid = True

                End If

            Catch ex As Exception
                JobIsValid = False
            Finally
                CheckIfJobComponentIsValid = JobIsValid
            End Try

        End Function
        Private Function GetAllowedProcessControlNumbers() As Integer()

            GetAllowedProcessControlNumbers = _AllowedJobProcessControlNumbers

        End Function
        Public Function LoadAvailableJobComponents(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                   Optional ByVal JobNumber As Integer = Nothing, Optional ByVal ClientCode As String = Nothing,
                                                   Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)

            Try

                LoadAvailableJobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, DbContext.UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, True, _AllowedJobProcessControlNumbers).ToList

            Catch ex As Exception
                LoadAvailableJobComponents = Nothing
            End Try

        End Function
        Public Sub DenyExpenseReportsInAccounting(ByVal Session As AdvantageFramework.Security.Session,
                                                  ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ExpenseSummaryList As Generic.List(Of AdvantageFramework.Database.Views.ExpenseSummary),
                                                  ByRef ErrorMessage As String)

            'objects
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim ErrorText As String = Nothing

            For Each ExpenseSummary In ExpenseSummaryList

                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, ExpenseSummary.InvoiceNumber)

                If ExpenseReport IsNot Nothing Then

                    ExpenseReport.IsApproved = 1
                    ExpenseReport.Status = 5
                    ExpenseReport.ApproverNotes = ExpenseSummary.ApproverNotes
                    ExpenseReport.ApprovedBy = Session.User.EmployeeCode
                    ExpenseReport.ApprovedDate = System.DateTime.Now

                    If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        ' send alerts
                        If CreateExpenseDeniedInAccountingAlert(DbContext, ExpenseReport, Employee, Alert) Then

                            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session,
                                                                                  Alert,
                                                                                  Subject:=Alert.Subject,
                                                                                  AppName:="Expense",
                                                                                  ErrorMessage:=ErrorText)

                            ErrorMessage &= ErrorText & vbNewLine

                        End If

                    End If

                End If

            Next

        End Sub
        Public Function ExpenseReportApprovedInAccounting(ByVal Session As AdvantageFramework.Security.Session,
                                                          ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            Dim Processed As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Sent As Boolean = False
            Dim ErrorText As String = String.Empty

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                If Employee IsNot Nothing Then

                    If CreateExpenseApprovedInAccountingAlert(DbContext, ExpenseReport, Employee, Alert) = True Then

                        Processed = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session,
                                                                                          Alert,
                                                                                          Subject:=Alert.Subject,
                                                                                          AppName:="Expense",
                                                                                          ErrorMessage:=ErrorText)

                    End If

                End If

            Catch ex As Exception
                Processed = False
            End Try

            Return Processed

        End Function
        Public Function LoadStatusTooltip(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As String

            LoadStatusTooltip = LoadStatusTooltip(DbContext, ExpenseReport.EmployeeCode, ExpenseReport.SubmittedTo, ExpenseReport.ApprovedBy, ExpenseReport.Status.GetValueOrDefault(0), ExpenseReport.IsSubmitted.GetValueOrDefault(0), ExpenseReport.IsApproved.GetValueOrDefault(0), ExpenseReport.ApproverNotes)

        End Function
        Public Function LoadStatusTooltip(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal ExpenseReport As AdvantageFramework.Database.Classes.ExpenseReport) As String

            LoadStatusTooltip = LoadStatusTooltip(DbContext, ExpenseReport.EmployeeCode, ExpenseReport.SubmittedTo, ExpenseReport.ApprovedBy, ExpenseReport.Status.GetValueOrDefault(0), ExpenseReport.IsSubmitted.GetValueOrDefault(0), ExpenseReport.IsApproved.GetValueOrDefault(0), ExpenseReport.ApproverNotes)

        End Function
        Private Function LoadStatusTooltip(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal EmployeeCode As String, ByVal SubmittedToEmployeeCode As String, ByVal ApprovedByEmployeeCode As String,
                                          ByVal Status As Integer, ByVal IsSubmitted As Integer, ByVal IsApproved As Integer, ByVal ApproverNotes As String) As String

            'objects
            Dim Tooltip As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim SubmittedTo As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ApprovedBy As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ReportStatus As ExpenseReportStatus = Nothing

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Not String.IsNullOrWhiteSpace(Employee.SupervisorEmployeeCode) Then

                Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

            End If

            If Not String.IsNullOrWhiteSpace(SubmittedToEmployeeCode) Then

                SubmittedTo = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SubmittedToEmployeeCode)

            End If

            If Not String.IsNullOrWhiteSpace(ApprovedByEmployeeCode) Then

                ApprovedBy = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ApprovedByEmployeeCode)

            End If

            ReportStatus = LoadExpenseReportStatus(Status, IsSubmitted, IsApproved)

            If CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0)) Then

                Select Case ReportStatus

                    Case ExpenseReportStatus.Pending,
                         ExpenseReportStatus.PendingApproval

                        Tooltip = "Pending Approval by Supervisor"

                        If SubmittedTo IsNot Nothing Then

                            Tooltip &= ", " & SubmittedTo.ToString

                        ElseIf Supervisor IsNot Nothing Then ' handles old expense reports prior to SubmittedTo

                            Tooltip &= ", " & Supervisor.ToString

                        End If

                    Case ExpenseReportStatus.DeniedByApprover

                        Tooltip = "Denied by Supervisor"

                        If SubmittedTo IsNot Nothing Then

                            Tooltip &= ", " & SubmittedTo.ToString

                        End If

                    Case ExpenseReportStatus.Approved,
                         ExpenseReportStatus.ApprovedByApprover,
                         ExpenseReportStatus.ApprovedInAccounting,
                         ExpenseReportStatus.PendingApprovalInAccounting,
                         ExpenseReportStatus.DeniedByAccounting

                        If ReportStatus = ExpenseReportStatus.DeniedByAccounting Then

                            Tooltip = "Denied by Accounting"

                            If SubmittedTo IsNot Nothing Then ' SubmittedTo = Null on old expense reports. AP User is not stored. Only stored on new expense reports where SubmittedTo = the actual approver.

                                If ApprovedBy IsNot Nothing Then

                                    Tooltip &= ", " & ApprovedBy.ToString

                                End If

                            End If

                            'Tooltip &= ".<br/>"
                            Tooltip &= "." & vbCrLf

                            Tooltip &= "Comments:" & ApproverNotes & vbCrLf

                        ElseIf ReportStatus = ExpenseReportStatus.ApprovedInAccounting Then

                            Tooltip = "Approved by Accounting"

                            If SubmittedTo IsNot Nothing Then ' SubmittedTo = Null on old expense reports. AP User is not stored. Only stored on new expense reports where SubmittedTo = the actual approver.

                                If ApprovedBy IsNot Nothing Then

                                    Tooltip &= ", " & ApprovedBy.ToString

                                End If

                            End If

                            Tooltip &= ". "

                        End If

                        Tooltip &= "Approved by Supervisor"

                        If SubmittedTo IsNot Nothing Then

                            Tooltip &= ", " & SubmittedTo.ToString

                        ElseIf ApprovedBy IsNot Nothing Then ' SubmittedTo = null on old expense reports. ApprovedBy = approver on old expense reports

                            Tooltip &= ", " & ApprovedBy.ToString

                        End If

                        Tooltip &= ". "

                        If ReportStatus <> ExpenseReportStatus.ApprovedInAccounting AndAlso ReportStatus <> ExpenseReportStatus.DeniedByAccounting Then

                            Tooltip &= "Pending Approval by Accounting."

                        End If

                End Select

            Else

                Select Case ReportStatus

                    'Case ExpenseReportStatus.Open
                    Case ExpenseReportStatus.Pending,
                         ExpenseReportStatus.PendingApproval,
                         ExpenseReportStatus.PendingApprovalInAccounting

                        Tooltip = "Pending Approval by Accounting"

                    Case ExpenseReportStatus.Approved,
                         ExpenseReportStatus.ApprovedByApprover,
                         ExpenseReportStatus.ApprovedInAccounting

                        Tooltip = "Approved by Accounting"

                        If ApprovedBy IsNot Nothing Then

                            Tooltip &= ", " & ApprovedBy.ToString

                        End If

                    Case ExpenseReportStatus.DeniedByApprover,
                         ExpenseReportStatus.DeniedByAccounting

                        Tooltip = "Denied by Accounting"

                        If ApprovedBy IsNot Nothing Then

                            Tooltip &= ", " & ApprovedBy.ToString

                        End If

                        Tooltip &= ".<br/>"

                        Tooltip &= "<b>Comments:</b>" & ApproverNotes & "<br/>"

                End Select

            End If

            Return Tooltip

        End Function

#End Region

#Region " Expense Approvals"

#Region " Constants "

        Private Const KeyLength As Short = 5

#End Region

#Region " Enum "

        'Not the same as actual status
        Public Enum EmailAlertType

            Approved
            Denied

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ApproveInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal InvoiceNumber As Integer,
                                       ByVal ApproverEmployeeCode As String,
                                       ByVal ApprovalComments As String,
                                       ByRef ErrorMessage As String) As Boolean

            Dim Approved As Boolean = False
            Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

            If ExpenseHeader IsNot Nothing Then

                If ExpenseHeader.IsApproved IsNot Nothing AndAlso ExpenseHeader.IsApproved = 2 Then

                    ErrorMessage = "This report has already been approved."

                Else

                    If String.IsNullOrWhiteSpace(ApprovalComments) = False Then

                        ExpenseHeader.ApproverNotes = ApprovalComments

                    End If

                    ExpenseHeader.IsApproved = 2
                    ExpenseHeader.ApprovedBy = ApproverEmployeeCode
                    ExpenseHeader.ApprovedDate = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, ApproverEmployeeCode)

                    Approved = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseHeader)

                End If

            Else

                ErrorMessage = "Could not get report."

            End If

            Return Approved

        End Function
        Public Function DenyInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal InvoiceNumber As Integer,
                                    ByVal ApproverEmployeeCode As String,
                                    ByVal ApprovalComments As String,
                                    ByRef ErrorMessage As String) As Boolean

            Dim Denied As Boolean = False
            Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

            If ExpenseHeader IsNot Nothing Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseHeader.EmployeeCode)

                If ExpenseHeader.IsApproved IsNot Nothing AndAlso ExpenseHeader.IsApproved = 1 Then

                    ErrorMessage = "This report has already been denied."

                Else

                    If String.IsNullOrWhiteSpace(ApprovalComments) = False Then

                        ExpenseHeader.ApproverNotes = ApprovalComments

                    End If

                    ExpenseHeader.IsApproved = 1
                    ExpenseHeader.ApprovedBy = String.Empty
                    ExpenseHeader.ApprovedDate = Nothing

                    Denied = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseHeader)

                    If Denied = True Then

                        'Try

                        '    Dim ApproverUserCode As String = String.Empty
                        '    Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                        '    Dim SQL As String = "SELECT TOP 1 USER_CODE FROM SEC_USER SU WITH(NOLOCK) WHERE SU.EMP_CODE = '{0}' ORDER BY SEC_USER_ID DESC;"
                        '    Dim WebvantageURL As String = String.Empty
                        '    Dim ErrorText As String = String.Empty

                        '    ApproverUserCode = DbContext.Database.SqlQuery(Of String)(String.Format(SQL, ApproverEmployeeCode)).SingleOrDefault
                        '    WebvantageURL = DbContext.Database.SqlQuery(Of String)("SELECT WEBVANTAGE_URL FROM AGENCY WITH(NOLOCK);").SingleOrDefault

                        '    If WebvantageURL.EndsWith("/") = False Then

                        '        WebvantageURL &= "/"

                        '    End If

                        '    FxAlert.AlertTypeID = 3
                        '    FxAlert.AlertCategoryID = 46
                        '    FxAlert.Subject = "Expense Report Approval Updated! (" & CType(ExpenseHeader.InvoiceDate, Date).ToShortDateString & ") - Status: " & "Denied"
                        '    FxAlert.Body = "<a href='" & WebvantageURL & "Expense_Edit.aspx?invoice=" & ExpenseHeader.InvoiceNumber & " '> Link to Expense Report for " &
                        '                   Employee.ToString & " (" & CType(ExpenseHeader.InvoiceDate, Date).ToString("d") & ").</a><br /><br />" & ApprovalComments
                        '    FxAlert.EmailBody = FxAlert.Body
                        '    FxAlert.GeneratedDate = Now
                        '    FxAlert.LastUpdated = FxAlert.GeneratedDate
                        '    FxAlert.PriorityLevel = 3
                        '    FxAlert.EmployeeCode = ApproverEmployeeCode
                        '    FxAlert.UserCode = ApproverUserCode

                        '    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        '        Dim Recipient As New AdvantageFramework.Database.Entities.AlertRecipient

                        '        Recipient.AlertID = FxAlert.ID
                        '        Recipient.EmployeeCode = Employee.Code
                        '        Recipient.EmployeeEmail = Employee.Email

                        '        If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient) = True Then

                        '            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, FxAlert, "[New Alert] ", Nothing, Nothing, "Expense", ErrorMessage:=ErrorText)


                        '        End If

                        '    End If

                        'Catch ex As Exception

                        'End Try

                    End If

                End If

            Else

                ErrorMessage = "Could not get report."

            End If

            Return Denied

        End Function
        Public Function PendInvoice(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal InvoiceNumber As Integer,
                                    ByVal ApproverEmployeeCode As String,
                                    ByVal ApprovalComments As String) As Boolean

            Dim Denied As Boolean = False
            Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

            If ExpenseHeader IsNot Nothing Then

                If String.IsNullOrWhiteSpace(ApprovalComments) = False Then

                    ExpenseHeader.ApproverNotes = ApprovalComments

                End If

                ExpenseHeader.IsApproved = 0
                ExpenseHeader.ApprovedBy = String.Empty
                ExpenseHeader.ApprovedDate = Nothing

                Denied = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseHeader)

            End If

            Return Denied

        End Function

#Region " Email/URL "

        '1.	Email: Expense Approval Response back to Employee FROM Accounting (Advantage)
        Private Function CreateExpenseApprovedInAccountingAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport,
                                                                ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                                ByRef Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Return CreateExpenseAccountingAlert(DbContext, ExpenseReport, Employee, Alert, False)

        End Function
        Private Function CreateExpenseDeniedInAccountingAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport,
                                                              ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                              ByRef Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Return CreateExpenseAccountingAlert(DbContext, ExpenseReport, Employee, Alert, True)

        End Function
        Private Function CreateExpenseAccountingAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport,
                                                      ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                      ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                                      ByVal DeniedInAccounting As Boolean) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim GeneratedDate As Date = Nothing
            Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True, True)
            Dim SubjectTemplate As String = "Expense Approval Updated! Report Date: {0} - {1}" 'Invoicde date and status text

            Try

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Approvals")
                    AlertCategory = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, AlertType.ID)
                                     Where Entity.Description = "Expense Report Approval Response"
                                     Select Entity).FirstOrDefault
                    Alert.AlertTypeID = AlertType.ID
                    Alert.AlertCategoryID = AlertCategory.ID
                    Alert.GeneratedDate = System.DateTime.Now
                    Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.High
                    Alert.EmployeeCode = Employee.Code
                    Alert.AlertLevel = ""
                    Alert.UserCode = DbContext.UserCode
                    Alert.DbContext = DbContext


                    If DeniedInAccounting = True Then

                        Alert.Subject = String.Format(SubjectTemplate, CType(ExpenseReport.InvoiceDate, Date).ToShortDateString, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.ExpenseReports.ExpenseReportStatus.DeniedByAccounting.ToString))
                        AddEmailHeader(EmailBody, ExpenseReport,
                                       AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.ExpenseReports.ExpenseReportStatus.DeniedByAccounting.ToString))
                        EmailBody.AddKeyValueRowNoCell("Denied By", ExpenseReport.ApprovedBy)
                        EmailBody.AddKeyValueRowNoCell("Comments", ExpenseReport.ApproverNotes)

                    Else

                        Alert.Subject = String.Format(SubjectTemplate, CType(ExpenseReport.InvoiceDate, Date).ToShortDateString, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedInAccounting.ToString))
                        AddEmailHeader(EmailBody, ExpenseReport,
                                       AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.ExpenseReports.ExpenseReportStatus.ApprovedInAccounting.ToString))

                    End If

                    Alert.Body = EmailBody.ToString
                    Alert.EmailBody = Alert.Body

                    'Alert.EmailBody = Alert.Body & "<a href=""" & AdvantageFramework.Web.BuildDeepLink(Agency, Web.DeepLinkType.External, "Expense_Edit_V2.aspx?invoice=" & ExpenseReport.InvoiceNumber) & """>Click here to navigate to the Expense Report</a>"

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        Created = True

                        If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(Employee) Then

                            AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                            AlertRecipient.AlertID = Alert.ID
                            AlertRecipient.EmployeeCode = Employee.Code
                            AlertRecipient.EmployeeEmail = Employee.Email

                            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                        End If

                        If DeniedInAccounting = True Then

                            Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.SubmittedTo)

                            If Supervisor IsNot Nothing Then

                                If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(Supervisor) Then

                                    AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                    AlertRecipient.AlertID = Alert.ID
                                    AlertRecipient.EmployeeCode = ExpenseReport.SubmittedTo
                                    AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(DbContext, ExpenseReport.SubmittedTo, True, False)

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateExpenseAccountingAlert = Created
            End Try

        End Function

        '2.	Email: Expense Approval Request to Supervisor (from employee)
        Private Function CreateExpenseApprovalAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport,
                                                    ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                    ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                                    ByVal IncludeReceiptsInEmailAndAlert As Boolean) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim GeneratedDate As Date = Nothing
            Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True, True)
            Dim ExpenseDetailList As Generic.List(Of ExpenseItemViewModel) = Nothing

            Try

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Approvals")
                    AlertCategory = (From Entity In AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeID(DbContext, AlertType.ID)
                                     Where Entity.Description = "Expense Report Approval Request"
                                     Select Entity).FirstOrDefault


                    Alert.AlertTypeID = AlertType.ID
                    Alert.AlertCategoryID = AlertCategory.ID
                    Alert.GeneratedDate = System.DateTime.Now
                    Alert.LastUpdated = Alert.GeneratedDate
                    Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.High
                    Alert.AlertLevel = ""
                    Alert.EmployeeCode = Employee.Code
                    Alert.UserCode = DbContext.UserCode
                    Alert.DbContext = DbContext

                    Alert.Subject = String.Format("Expense Approval Request for {0}, Report Date: {1}",
                                                  Employee.ToString, CType(ExpenseReportEntity.InvoiceDate, Date).ToShortDateString)

                    'Links
                    EmailBody.AddCustomRow(EmailBody.ExpenseApprovalModuleLink(DbContext, ExpenseReportEntity.EmployeeCode, Web.Methods.DeepLinkType.External))
                    EmailBody.AddHyperlinkRow(GenerateExpenseApprovalURL(DbContext, ExpenseReportEntity.InvoiceNumber,
                                                                         ExpenseReportEntity.SubmittedTo, DbContext.UserCode),
                                                                         "Click here to view the Expense Report from any device, outside of Webvantage.")

                    'Header
                    AddEmailHeader(EmailBody, ExpenseReportEntity, "")

                    'Details grid
                    ExpenseDetailList = DbContext.Database.SqlQuery(Of ExpenseItemViewModel)(String.Format("EXEC [dbo].[usp_wv_get_super_appr_expense_dtl] {0};", ExpenseReportEntity.InvoiceNumber)).ToList

                    If ExpenseDetailList IsNot Nothing AndAlso ExpenseDetailList.Count > 0 Then

                        Try

                            Dim AmountDisplay As Decimal = 0.0

                            AmountDisplay = (From Entity In ExpenseDetailList
                                             Select Entity.Amount).Sum

                            EmailBody.AddKeyValueRowNoCell("Total Expense", AmountDisplay)

                        Catch ex As Exception
                        End Try
                        Try

                            Dim PayableDisplay As Decimal = 0.0

                            PayableDisplay = (From Entity In ExpenseDetailList
                                              Select Entity.Payable).Sum

                            EmailBody.AddKeyValueRowNoCell("Total Payable", PayableDisplay)
                        Catch ex As Exception
                        End Try

                        EmailBody.CustomTableRowStart({"Date", "C/D/P", "Job", "Function/Category", "Quantity", "Rate", "Amount", "CC", "Payable", "Description"})

                        For Each ExpenseDetail As ExpenseItemViewModel In ExpenseDetailList

                            EmailBody.CustomTableRow({ExpenseDetail.ItemDateDisplay,
                                                      ExpenseDetail.CDPDisplay,
                                                      ExpenseDetail.JobDisplay,
                                                      ExpenseDetail.FunctionDescription,
                                                      ExpenseDetail.Quantity,
                                                      ExpenseDetail.Rate,
                                                      ExpenseDetail.Amount,
                                                      ExpenseDetail.IsCcYN,
                                                      ExpenseDetail.Payable,
                                                      ExpenseDetail.Description}, False)


                        Next

                        EmailBody.CustomTableEnd()

                    End If

                    EmailBody.Finish()

                    Alert.EmailBody = EmailBody.ToString(Alert.ID)
                    Alert.Body = Alert.EmailBody

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReportEntity.SubmittedTo)

                        If Supervisor IsNot Nothing Then

                            If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(Supervisor) Then

                                AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                AlertRecipient.AlertID = Alert.ID
                                AlertRecipient.EmployeeCode = ExpenseReportEntity.SubmittedTo
                                AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(DbContext, ExpenseReportEntity.SubmittedTo, True, False)

                                Created = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                            End If

                        End If
                        If IncludeReceiptsInEmailAndAlert = True Then

                            GeneratedDate = System.DateTime.Now

                            For Each ExpenseDocument In AdvantageFramework.Database.Procedures.ExpenseReportDocument.LoadByInvoiceNumber(DbContext, ExpenseReportEntity.InvoiceNumber).ToList

                                Try

                                    AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                    AlertAttachment.AlertID = Alert.ID
                                    AlertAttachment.DocumentID = ExpenseDocument.DocumentID
                                    AlertAttachment.UserCode = DbContext.UserCode
                                    AlertAttachment.HasEmailBeenSent = False
                                    AlertAttachment.GeneratedDate = GeneratedDate
                                    AlertAttachment.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                Catch ex As Exception

                                End Try

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateExpenseApprovalAlert = Created
            End Try

        End Function

        '3.	Email: Expense Approval Response back to Employee FROM Supervisor
        '   This is the one that goes back to the employee that submitted the ER from Supervisor
        Public Function CreateAlertAndSendEmail(ByVal Session As AdvantageFramework.Security.Session,
                                                ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal InvoiceNumber As Integer,
                                                ByVal ApproverEmployeeCode As String,
                                                ByVal ApprovalComments As String,
                                                ByVal SendType As EmailAlertType,
                                                ByRef ErrorMessage As String) As Boolean

            Dim Sent As Boolean = False

            Try

                Dim ApproverUserCode As String = String.Empty
                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                Dim SQL As String = "SELECT TOP 1 USER_CODE FROM SEC_USER SU WITH(NOLOCK) WHERE SU.EMP_CODE = '{0}' ORDER BY SEC_USER_ID DESC;"
                Dim ErrorText As String = String.Empty
                Dim ExpenseHeader As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim CurrentStatus As AdvantageFramework.ExpenseReports.ExpenseReportStatus = Nothing
                Dim StatusDisplay As String = String.Empty

                ExpenseHeader = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)
                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseHeader.EmployeeCode)

                If ExpenseHeader IsNot Nothing AndAlso Employee IsNot Nothing Then

                    ApproverUserCode = DbContext.Database.SqlQuery(Of String)(String.Format(SQL, ApproverEmployeeCode)).SingleOrDefault

                    If SendType = EmailAlertType.Approved Then 'Change later

                        ApprovalComments = ""
                        ExpenseHeader.ApproverNotes = String.Empty
                        AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseHeader)

                    End If

                    CurrentStatus = AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseHeader)

                    Try

                        If String.IsNullOrWhiteSpace(CurrentStatus.ToString) = False Then

                            StatusDisplay = AdvantageFramework.StringUtilities.GetNameAsWords(CurrentStatus.ToString)

                        Else

                            StatusDisplay = SendType.ToString

                        End If

                    Catch ex As Exception
                        StatusDisplay = SendType.ToString
                    End Try

                    Dim HtmlEmail As New AdvantageFramework.Email.Classes.HtmlEmail(True)

                    AddEmailHeader(HtmlEmail, ExpenseHeader, StatusDisplay)

                    HtmlEmail.Finish()

                    FxAlert.AlertTypeID = 3
                    FxAlert.AlertCategoryID = 46
                    FxAlert.GeneratedDate = System.DateTime.Now
                    FxAlert.LastUpdated = FxAlert.GeneratedDate
                    FxAlert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.High
                    FxAlert.AlertLevel = ""
                    FxAlert.EmployeeCode = ApproverEmployeeCode
                    FxAlert.UserCode = ApproverUserCode
                    FxAlert.DbContext = DbContext

                    FxAlert.Subject = String.Format("Expense Approval Updated! Report Date: {0} - {1} ",
                                                    CType(ExpenseHeader.InvoiceDate, Date).ToShortDateString,
                                                    StatusDisplay)
                    FxAlert.Body = "Status: " & SendType.ToString
                    FxAlert.EmailBody = FxAlert.Body

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        FxAlert.Body = HtmlEmail.ToString(FxAlert.ID)
                        FxAlert.EmailBody = FxAlert.Body

                        If AdvantageFramework.Database.Procedures.Alert.Update(DbContext, FxAlert) = True Then

                            Dim Recipient As New AdvantageFramework.Database.Entities.AlertRecipient

                            Recipient.AlertID = FxAlert.ID
                            Recipient.EmployeeCode = Employee.Code
                            Recipient.EmployeeEmail = Employee.Email

                            If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient) = True Then

                                Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session,
                                                                                             FxAlert,
                                                                                             Subject:=FxAlert.Subject,
                                                                                             AppName:="SupervisorApproval",
                                                                                             SupervisorApprovalComment:=ApprovalComments,
                                                                                             ErrorMessage:=ErrorText)


                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
            End Try

            Return Sent

        End Function

        Private Function AddEmailHeader(ByRef EmailBody As AdvantageFramework.Email.Classes.HtmlEmail,
                                        ByVal ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport,
                                        ByVal StatusText As String) As Boolean

            Dim Built As Boolean = True

            Try

                'EmailBody.AddHeaderRow(If(String.IsNullOrWhiteSpace(ExpenseReportEntity.Details) = True, ExpenseReportEntity.Details, ExpenseReportEntity.Description))

                EmailBody.AddKeyValueRowNoCell("Expense Report #", ExpenseReportEntity.InvoiceNumber)

                If ExpenseReportEntity.InvoiceDate IsNot Nothing Then

                    EmailBody.AddKeyValueRowNoCell("Report Date", CType(ExpenseReportEntity.InvoiceDate, Date).ToShortDateString)

                End If
                If ExpenseReportEntity.CreatedDate IsNot Nothing Then

                    EmailBody.AddKeyValueRowNoCell("Create Date", CType(ExpenseReportEntity.CreatedDate, Date).ToShortDateString)

                End If
                If String.IsNullOrWhiteSpace(StatusText) = False Then

                    EmailBody.AddKeyValueRowNoCell("Status", StatusText)

                End If
                If String.IsNullOrWhiteSpace(ExpenseReportEntity.Description) = False Then

                    EmailBody.AddKeyValueRowNoCell("Description", ExpenseReportEntity.Description)

                End If
                If String.IsNullOrWhiteSpace(ExpenseReportEntity.Details) = False Then

                    EmailBody.AddKeyValueRowNoCell("Detail", ExpenseReportEntity.Details)

                End If

            Catch ex As Exception
                Built = False
            End Try

            Return Built

        End Function
        Private Function AddApproveDenyButtons(ByRef EmailBody As AdvantageFramework.Email.Classes.HtmlEmail,
                                               ByVal ExpenseReportEntity As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            'EmailBody.AddCustomRow("Don't need to see it?")

            'Dim ButtonsTest As String = String.Empty

            'ButtonsTest = "<table><tr><td>"

            'ButtonsTest &= EmailBody.EmailButton(GenerateApproveURL(DbContext, ExpenseReportEntity.InvoiceNumber, ExpenseReportEntity.SubmittedTo, DbContext.UserCode),
            '                                   "Approve", "Approve with one click.  Does not require sign in.", Email.Classes.HtmlEmail.EmailButtonType.Success)

            'ButtonsTest &= "</td><td>"

            'ButtonsTest &= EmailBody.EmailButton(GenerateDenyURL(DbContext, ExpenseReportEntity.InvoiceNumber, ExpenseReportEntity.SubmittedTo, DbContext.UserCode),
            '                                   "Deny", "Deny with one click.  Does not require sign in.", Email.Classes.HtmlEmail.EmailButtonType.Danger)

            'ButtonsTest &= "</td></tr></table>"

            'EmailBody.AddCustomRow(ButtonsTest)

            Return False

        End Function


        Public Function GenerateExpenseApprovalURL(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal InvoiceNumber As Integer,
                                                   ByVal ApproverEmployeeCode As String,
                                                   ByVal UserCode As String) As String

            Return GenerateURL(DbContext, InvoiceNumber, ApproverEmployeeCode, UserCode, ApprovalURLType.View)

        End Function
        Public Function GenerateApproveURL(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal InvoiceNumber As Integer,
                                           ByVal ApproverEmployeeCode As String,
                                           ByVal UserCode As String) As String

            Return GenerateURL(DbContext, InvoiceNumber, ApproverEmployeeCode, UserCode, ApprovalURLType.Approve)

        End Function
        Public Function GenerateDenyURL(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal InvoiceNumber As Integer,
                                        ByVal ApproverEmployeeCode As String,
                                        ByVal UserCode As String) As String

            Return GenerateURL(DbContext, InvoiceNumber, ApproverEmployeeCode, UserCode, ApprovalURLType.Deny)

        End Function

        Public Function GenerateURL(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal InvoiceNumber As Integer,
                                    ByVal ApproverEmployeeCode As String,
                                    ByVal UserCode As String,
                                    ByVal UrlType As ApprovalURLType) As String

            Dim URL As New Text.StringBuilder
            Dim QueryString As New Text.StringBuilder
            Dim WebvantageURL As String = String.Empty
            Dim UserKey As String = String.Empty

            Try

                UserKey = RandomStringKey()

                WebvantageURL = DbContext.Database.SqlQuery(Of String)("SELECT WEBVANTAGE_URL FROM AGENCY WITH(NOLOCK);").SingleOrDefault

                If String.IsNullOrWhiteSpace(WebvantageURL) = False Then

                    If WebvantageURL.EndsWith("/") = True Then WebvantageURL = WebvantageURL.Substring(0, WebvantageURL.Length - 1)

                    If WebvantageURL.ToLower.StartsWith("http://") = False AndAlso WebvantageURL.ToLower.StartsWith("https://") = False Then

                        WebvantageURL = "http://" & WebvantageURL

                    End If

                    URL.Append(WebvantageURL)
                    URL.Append("/Employee/ExpenseApproval/")

                    Select Case UrlType
                        Case ApprovalURLType.Approve

                            URL.Append("Approve")

                        Case ApprovalURLType.Deny

                            URL.Append("Deny")

                        Case Else

                            URL.Append("Invoice")

                    End Select

                    URL.Append("?x=")

                    QueryString.Append("p=")
                    QueryString.Append(Now.Second * Now.Hour)
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append("thisIsFake")
                    QueryString.Append(Now.Year.ToString)

                    QueryString.Append("&a=")
                    QueryString.Append(ApproverEmployeeCode)

                    QueryString.Append("&r=")
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&k=")
                    QueryString.Append(DbContext.Database.Connection.Database)

                    QueryString.Append("&e=")
                    QueryString.Append(UserCode)

                    QueryString.Append("&rt=")
                    QueryString.Append(InvoiceNumber)

                    QueryString.Append("&ra=")
                    QueryString.Append(Now.Day.ToString)
                    QueryString.Append("faketyFakeFakeFake")
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&n=")
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append("ThisIsABunchOfFakeInfo")
                    QueryString.Append(Now.Minute.ToString)
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&jks=")
                    QueryString.Append(DateTime.Now.ToString)
                    QueryString.Append("&loie=")
                    QueryString.Append(UserKey)

                    QueryString.Append("&tran=")
                    QueryString.Append(Now.Minute.ToString)
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append(Now.Day.ToString)
                    QueryString.Append(Now.Year.ToString)
                    QueryString.Append(Now.Hour)
                    QueryString.Append("ThisIsTheLastBitToEndIt")

                    URL.Append(AdvantageFramework.Security.Encryption.Encrypt(QueryString.ToString))

                End If

            Catch ex As Exception
            End Try

            Return URL.ToString

        End Function
        Public Function ExpenseApprovalOptionsFromQueryString(ByVal QueryString As String,
                                                              ByRef InvoiceNumber As Integer,
                                                              ByRef ApproverEmployeeCode As String,
                                                              ByRef UserCode As String,
                                                              ByRef SentDateTime As DateTime?,
                                                              ByRef UserKey As String,
                                                              ByRef DatabaseName As String,
                                                              ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True
            InvoiceNumber = 0

            Try

                If String.IsNullOrWhiteSpace(QueryString) = False Then

                    QueryString = AdvantageFramework.Security.Encryption.Decrypt(QueryString)

                    Dim Values As NameValueCollection = HttpUtility.ParseQueryString(QueryString)

                    If Values IsNot Nothing AndAlso Values.AllKeys.Count > 0 Then

                        For Each Value As String In Values.AllKeys

                            Select Case Value
                                Case "rt"

                                    If IsNumeric(Values(Value)) = True Then

                                        InvoiceNumber = Values(Value)

                                    End If

                                Case "e"

                                    UserCode = Values(Value)

                                Case "k"

                                    DatabaseName = Values(Value)

                                Case "a"

                                    ApproverEmployeeCode = Values(Value)

                                Case "loie"

                                    UserKey = Values(Value)

                                Case "jks"

                                    Try

                                        SentDateTime = CType(Values(Value), DateTime)

                                    Catch ex As Exception
                                        SentDateTime = Nothing
                                    End Try

                            End Select

                        Next

                    End If

                End If

            Catch ex As Exception
                Success = False
                If String.IsNullOrWhiteSpace(ex.Message) = False Then
                    ErrorMessage = ex.Message
                End If
                If ex.InnerException IsNot Nothing Then
                    If String.IsNullOrWhiteSpace(ex.InnerException.Message) = False Then
                        ErrorMessage &= "  ::  INNER ::  " & ex.InnerException.Message
                    End If
                End If
            End Try

            Return Success

            'Dim P As New AdvantageFramework.Classes.UserAccount.Password

            'If String.IsNullOrWhiteSpace(QueryString) = False Then

            '    QueryString = Decrypt(QueryString)

            '    Dim Values As NameValueCollection = HttpUtility.ParseQueryString(QueryString)

            '    If Values IsNot Nothing AndAlso Values.AllKeys.Count > 0 Then

            '        For Each Value As String In Values.AllKeys

            '            Select Case Value
            '                Case "rt"

            '                    P.ServerName = Values(Value)

            '                Case "e"

            '                    P.DatabaseName = Values(Value)

            '                Case "a"

            '                    P.UserCode = Values(Value)

            '                Case "loie"

            '                    P.Key = Values(Value)

            '                Case "jks"

            '                    Try

            '                        P.SentDateTime = CType(Values(Value), DateTime)

            '                    Catch ex As Exception
            '                        P.SentDateTime = Nothing
            '                    End Try

            '            End Select

            '        Next

            '    End If

            'End If

            'If String.IsNullOrWhiteSpace(P.ServerName) = False AndAlso
            '        String.IsNullOrWhiteSpace(P.DatabaseName) = False AndAlso
            '        String.IsNullOrWhiteSpace(P.UserCode) = False AndAlso
            '        String.IsNullOrWhiteSpace(P.Key) = False AndAlso
            '        (P.SentDateTime IsNot Nothing AndAlso IsDate(P.SentDateTime)) Then

            '    P.IsValid = True

            'Else

            '    P.IsValid = False

            'End If

            'Return P

        End Function

        Public Function RandomStringKey() As String

            Dim Rand As New Random
            Dim Key As New Text.StringBuilder
            Dim s As String = String.Empty

            For i As Int32 = 0 To KeyLength - 1

                Key.Append(Chr(Rand.Next(65, 90)))

            Next

            s = Key.ToString.ToUpper

            If s.Length > 5 Then

                s = s.Substring(0, 5)

            End If

            Return Key.ToString.ToUpper

        End Function
        'Public Function Encrypt(ByVal Value As String) As String

        '    Return AdvantageFramework.StringUtilities.RijndaelSimpleEncrypt(Value) & "X"

        'End Function
        'Public Function Decrypt(ByVal Value As String) As String

        '    Return AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(Value.Substring(0, Value.Length - 1))

        'End Function

#End Region

#End Region

#End Region

#Region " TEMP "

        <Serializable()>
        Public Class ExpenseItemViewModel

#Region " Constants "



#End Region

#Region " Enum "

            Public Enum Properties

                ID
                LineNumber
                ItemDate
                ItemDateDisplay
                CDPDisplay
                JobDisplay
                FunctionDescription
                Quantity
                Rate
                Amount
                IsCcYN
                Payable
                Description
                FunctionCode
                JobNumber
                JobComponentNumber

            End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property ID As Integer = 0
            Public Property LineNumber As Integer = 0
            Public Property ItemDate As Nullable(Of Date) = Nothing
            Public Property CDPDisplay As String = String.Empty
            Public Property JobDisplay As String = String.Empty
            Public Property FunctionDescription As String = String.Empty
            Public Property Quantity As Nullable(Of Integer) = Nothing
            Public Property Rate As Nullable(Of Decimal) = Nothing
            Public Property Amount As Nullable(Of Decimal) = Nothing
            Public Property IsCcYN As String = String.Empty
            Public Property Payable As Nullable(Of Decimal) = Nothing
            Public Property Description As String = String.Empty
            Public Property FunctionCode As String = String.Empty
            Public Property JobNumber As Nullable(Of Integer) = Nothing
            Public Property JobComponentNumber As Nullable(Of Short) = Nothing

            'Public Property CreditCardFlag As Nullable(Of Boolean) = Nothing
            'Public Property ClientCode As String = String.Empty
            'Public Property DivisionCode As String = String.Empty
            'Public Property ProductCode As String = String.Empty
            'Public Property CreditCardAmount As Nullable(Of Decimal) = Nothing
            'Public Property APComment As String = String.Empty
            'Public Property CreatedBy As String = String.Empty
            'Public Property ModifiedBy As String = String.Empty
            'Public Property ModifiedDate As Nullable(Of Date) = Nothing
            'Public Property PaymentType As Nullable(Of Short) = Nothing
            'Public Property IsImported As Boolean = False
            'Public Property NonBillableYN As String = String.Empty

            Public ReadOnly Property ItemDateDisplay As String
                Get

                    If ItemDate IsNot Nothing AndAlso IsDate(ItemDate) Then

                        Return CType(ItemDate, Date).ToShortDateString

                    Else

                        Return ""

                    End If

                End Get
            End Property


#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class

#End Region

    End Module

End Namespace
