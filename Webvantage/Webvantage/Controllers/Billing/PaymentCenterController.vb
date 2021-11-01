Imports System.Web.Mvc
Imports System.Collections.Generic
Imports System.Web.Routing
Imports System.Drawing
Imports System.Data.SqlClient

Namespace Controllers.Billing

    <Serializable()>
    Public Class PaymentCenterController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Billing/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _Controller As AdvantageFramework.Controller.Billing.PaymentCenterController
#End Region

#Region " Properties "
#End Region

#Region " Methods "
        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            '   _Controller = New AdvantageFramework.Controller.Billing.PaymentCenterController(Me.SecuritySession)

        End Sub
#End Region

#Region " MVC Views "

        <HttpGet>
        Public Function Index() As ActionResult

            Return View()

        End Function

        <HttpGet>
        Public Function CreateBatch(Optional BatchId As String = "", Optional PaymentModule As String = "") As ActionResult

            If BatchId IsNot "" Then
                ViewBag.BatchId = BatchId
                ViewBag.PaymentModule = PaymentModule
            Else
                ViewBag.BatchId = 0
                ViewBag.PaymentModule = ""
            End If

            Return View()

        End Function

        <HttpGet>
        Public Function OpenBatch(BatchId As String, PaymentModule As String) As ActionResult

            Return RedirectToAction("CreateBatch", New With {.BatchId = BatchId, .PaymentModule = PaymentModule})

        End Function

        <HttpGet>
        Public Function _ViewBatchSummary(BatchId As Integer) As ActionResult

            ViewBag.BatchId = BatchId

            Return PartialView()

        End Function

        <HttpGet>
        Public Function _LockedInvoiceSummary() As ActionResult
            Dim InvoiceInUse As AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse = Nothing
            InvoiceInUse = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse

            InvoiceInUse.InvoiceNumber = "ME INVOICE"

            ViewBag.InvoiceInUse = InvoiceInUse

            Return PartialView()

        End Function

        <HttpGet>
        Public Function _CreateBatchFilter() As ActionResult

            Return PartialView()

        End Function

        <HttpGet>
        Public Function _CreateBatchGrid() As ActionResult

            Return PartialView()

        End Function

        Public Function _PaymentManager() As ActionResult
            'ViewBag.CurrentUser = Me.SecuritySession.User.EmployeeCode
            ViewBag.CurrentUser = Session("UserCode")

            Return PartialView()

        End Function

        <HttpGet>
        Public Function _PaymentManagerAddNew() As ActionResult

            Return PartialView()

        End Function

        Public Function _PaymentsDashboard() As ActionResult

            Return PartialView()

        End Function

        Public Function _VirtualCardManager() As ActionResult

            Return PartialView()

        End Function

        Public Function _OutstandingPayments() As ActionResult

            Return PartialView()

        End Function

        Public Function _CompletedPayments() As ActionResult

            Return PartialView()

        End Function
#End Region

#Region " API "
        <HttpGet>
        Public Function GetVendorSummary(BatchId As Integer) As JsonResult
            Dim BatchSummary As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorSummary) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing

            BatchSummary = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorSummary)

            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
            pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                pUserCode.Value = Session("UserCode")
                pBatchId.Value = BatchId

                BatchSummary = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorSummary)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetVendorSummary] @USER_ID, @BATCH_ID;",
                                        pUserCode,
                                        pBatchId).ToList

            End Using

            Return MaxJson(BatchSummary, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetExistingBatchDetail(BatchId As Integer, PaymentModule As String) As JsonResult
            Dim BatchDetails As AdvantageFramework.PaymentCenter.Classes.PaymentCenterExistingBatchDetail = Nothing
            Dim BatchHeader As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader = Nothing
            Dim Accounts As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail) = Nothing
            Dim Vendors As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail) = Nothing
            Dim Clients As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail) = Nothing

            BatchHeader = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader
            BatchHeader = GetBatchHeaderDetail(BatchId, PaymentModule)

            Accounts = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail)
            Accounts = GetBatchAccountDetails(BatchId, PaymentModule)

            Vendors = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail)
            Vendors = GetBatchVendorDetails(BatchId, PaymentModule)

            Clients = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail)
            Clients = GetBatchClientDetails(BatchId, PaymentModule)

            BatchDetails = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterExistingBatchDetail
            BatchDetails.BatchHeader = BatchHeader
            BatchDetails.Accounts = Accounts
            BatchDetails.Vendors = Vendors
            BatchDetails.Clients = Clients

            Return Json(BatchDetails, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetBatchHeaderDetail(BatchId As Integer, PaymentModule As String) As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader
            Dim BatchHeader As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentModule As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    BatchHeader = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader

                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                    pPaymentModule = New System.Data.SqlClient.SqlParameter("@PAYMENT_MODULE", SqlDbType.VarChar, 2)

                    pUserCode.Value = Session("UserCode")
                    pBatchId.Value = BatchId
                    pPaymentModule.Value = PaymentModule

                    BatchHeader = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetBatchHeader] @USER_ID, @BATCH_ID, @PAYMENT_MODULE;",
                                        pUserCode,
                                        pBatchId,
                                        pPaymentModule
                                    ).FirstOrDefault

                End Using

            Catch ex As Exception

            End Try


            'Return MaxJson(BatchHeader, JsonRequestBehavior.AllowGet)
            Return BatchHeader
        End Function

        '<HttpGet>
        'Public Function GetBatchInvoiceDetails(BatchId As Integer) As JsonResult
        '    Dim Invoices As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail) = Nothing

        '    Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing

        '    Try

        '        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

        '            Invoices = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail)

        '            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
        '            pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)

        '            pUserCode.Value = Session("UserCode")
        '            pBatchId.Value = BatchId

        '            Invoices = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail)(
        '                        "EXEC [dbo].[usp_wv_PaymentCenterGetBatchInvoiceDetails] @USER_ID, @BATCH_ID;",
        '                            pUserCode,
        '                            pBatchId
        '                        ).ToList

        '        End Using

        '    Catch ex As Exception

        '    End Try


        '    Return MaxJson(Invoices, JsonRequestBehavior.AllowGet)
        'End Function

        <HttpGet>
        Public Function GetCompletedBatchCheckDetails(BatchId As Integer) As JsonResult
            Dim Checks As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterCompletedBatchCheckDetails) = Nothing

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    Checks = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterCompletedBatchCheckDetails)

                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)

                    pBatchId.Value = BatchId

                    Checks = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterCompletedBatchCheckDetails)(
                                "EXEC [dbo].[usp_wv_PaymentCenterGetCompletedBatchCheckDetails] @BATCH_ID;",
                                    pBatchId
                                ).ToList

                End Using

            Catch ex As Exception

            End Try


            Return MaxJson(Checks, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetBatchAccountDetails(BatchId As Integer, PaymentModule As String) As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail)
            'Public Function GetBatchAccountDetails(BatchId As Integer) As JsonResult
            Dim Accounts As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentModule As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    Accounts = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail)

                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                    pPaymentModule = New System.Data.SqlClient.SqlParameter("@PAYMENT_MODULE", SqlDbType.VarChar, 2)

                    pUserCode.Value = Session("UserCode")
                    pBatchId.Value = BatchId
                    pPaymentModule.Value = PaymentModule

                    Accounts = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail)(
                                "EXEC [dbo].[usp_wv_PaymentCenterGetBatchAccountDetails] @USER_ID, @BATCH_ID, @PAYMENT_MODULE;",
                                    pUserCode,
                                    pBatchId,
                                    pPaymentModule
                                ).ToList

                End Using

            Catch ex As Exception

            End Try


            'Return MaxJson(Accounts, JsonRequestBehavior.AllowGet)
            Return Accounts
        End Function

        <HttpGet>
        Public Function GetBatchVendorDetails(BatchId As Integer, PaymentModule As String) As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail)
            'Public Function GetBatchVendorDetails(BatchId As Integer) As JsonResult
            Dim Vendors As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentModule As System.Data.SqlClient.SqlParameter = Nothing


            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    Vendors = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail)

                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                    pPaymentModule = New System.Data.SqlClient.SqlParameter("@PAYMENT_MODULE", SqlDbType.VarChar, 2)

                    pUserCode.Value = Session("UserCode")
                    pBatchId.Value = BatchId
                    pPaymentModule.Value = PaymentModule

                    Vendors = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail)(
                                "EXEC [dbo].[usp_wv_PaymentCenterGetBatchVendorDetails] @USER_ID, @BATCH_ID, @PAYMENT_MODULE;",
                                    pUserCode,
                                    pBatchId,
                                    pPaymentModule
                                ).ToList

                End Using

            Catch ex As Exception

            End Try


            'Return MaxJson(Vendors, JsonRequestBehavior.AllowGet)
            Return Vendors
        End Function

        <HttpGet>
        Public Function GetBatchClientDetails(BatchId As Integer, PaymentModule As String) As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail)
            'Public Function GetBatchClientDetails(BatchId As Integer) As JsonResult
            Dim Clients As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentModule As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    Clients = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail)

                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                    pPaymentModule = New System.Data.SqlClient.SqlParameter("@PAYMENT_MODULE", SqlDbType.VarChar, 2)

                    pUserCode.Value = Session("UserCode")
                    pBatchId.Value = BatchId
                    pPaymentModule.Value = PaymentModule

                    Clients = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail)(
                                "EXEC [dbo].[usp_wv_PaymentCenterGetBatchClientDetails] @USER_ID, @BATCH_ID, @PAYMENT_MODULE;",
                                    pUserCode,
                                    pBatchId,
                                    pPaymentModule
                                ).ToList

                End Using

            Catch ex As Exception

            End Try


            'Return MaxJson(Clients, JsonRequestBehavior.AllowGet)
            Return Clients
        End Function

        <HttpGet>
        Public Function GetInvoiceData(InvoiceFilter As AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceFilter) As JsonResult

            Dim Invoices As Generic.List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail) = Nothing
            Dim ErrorMessage As String = String.Empty

            If InvoiceFilter.BankCode IsNot Nothing Then
                Try
                    If InvoiceFilter IsNot Nothing Then

                        If InvoiceFilter.BatchStatus Is Nothing Then
                            InvoiceFilter.BatchStatus = ""
                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                            Dim BatchStatusSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim BatchIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim UserIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim BankCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim APAccountCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim VendorCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim ClientCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim DateToPayCutoffSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim CheckDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim PaidByClientSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim ProductionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim GLDistSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim TelevisionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim RadioSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim NewspaperSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim MagazineSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim InternetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                            Dim OutdoorSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                            BatchStatusSqlParameter = New System.Data.SqlClient.SqlParameter("@BATCH_STATUS", SqlDbType.VarChar, 1)
                            BatchIDSqlParameter = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                            UserIDSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                            BankCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@BK_CODE", SqlDbType.VarChar, 4)
                            APAccountCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@GLACCTCODES", SqlDbType.VarChar, 600)
                            VendorCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@VENDORS", SqlDbType.VarChar, 120)
                            ClientCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CLIENTS", SqlDbType.VarChar, 120)
                            DateToPayCutoffSqlParameter = New System.Data.SqlClient.SqlParameter("@DT_TO_PAY_CUTOFF", SqlDbType.SmallDateTime)
                            CheckDateSqlParameter = New System.Data.SqlClient.SqlParameter("@CHECK_DATE", SqlDbType.SmallDateTime)
                            PaidByClientSqlParameter = New System.Data.SqlClient.SqlParameter("@PAID_BY_CLIENT", SqlDbType.Bit)
                            ProductionSqlParameter = New System.Data.SqlClient.SqlParameter("@PRODUCTION", SqlDbType.Bit)
                            GLDistSqlParameter = New System.Data.SqlClient.SqlParameter("@GLDIST", SqlDbType.Bit)
                            TelevisionSqlParameter = New System.Data.SqlClient.SqlParameter("@TELEVISION", SqlDbType.Bit)
                            RadioSqlParameter = New System.Data.SqlClient.SqlParameter("@RADIO", SqlDbType.Bit)
                            NewspaperSqlParameter = New System.Data.SqlClient.SqlParameter("@NEWSPAPER", SqlDbType.Bit)
                            MagazineSqlParameter = New System.Data.SqlClient.SqlParameter("@MAGAZINE", SqlDbType.Bit)
                            InternetSqlParameter = New System.Data.SqlClient.SqlParameter("@INTERNET", SqlDbType.Bit)
                            OutdoorSqlParameter = New System.Data.SqlClient.SqlParameter("@OUTDOOR", SqlDbType.Bit)

                            'If(String.IsNullOrWhiteSpace(InvoiceFilter.SearchCriteria) = False, InvoiceFilter.SearchCriteria, System.DBNull.Value)

                            BatchStatusSqlParameter.Value = InvoiceFilter.BatchStatus
                            BatchIDSqlParameter.Value = InvoiceFilter.BatchId
                            UserIDSqlParameter.Value = Session("UserCode")
                            BankCodeSqlParameter.Value = InvoiceFilter.BankCode
                            APAccountCodeSqlParameter.Value = InvoiceFilter.APAccountCode
                            VendorCodeSqlParameter.Value = InvoiceFilter.VendorCode
                            ClientCodeSqlParameter.Value = IIf(InvoiceFilter.ClientCode IsNot Nothing, InvoiceFilter.ClientCode, "ALL")
                            DateToPayCutoffSqlParameter.Value = InvoiceFilter.DateToPayCutoff
                            CheckDateSqlParameter.Value = InvoiceFilter.CheckDate
                            PaidByClientSqlParameter.Value = InvoiceFilter.PaidByClient
                            ProductionSqlParameter.Value = InvoiceFilter.Production
                            GLDistSqlParameter.Value = InvoiceFilter.GLDist
                            TelevisionSqlParameter.Value = InvoiceFilter.Television
                            RadioSqlParameter.Value = InvoiceFilter.Radio
                            NewspaperSqlParameter.Value = InvoiceFilter.Newspaper
                            MagazineSqlParameter.Value = InvoiceFilter.Magazine
                            InternetSqlParameter.Value = InvoiceFilter.Internet
                            OutdoorSqlParameter.Value = InvoiceFilter.Outdoor

                            Invoices = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail)(
                                "EXEC [dbo].[usp_wv_PaymentCenterGetInvoices] @BATCH_STATUS, @BATCH_ID, @USER_ID,@BK_CODE,@GLACCTCODES,@VENDORS,@CLIENTS,@DT_TO_PAY_CUTOFF,@CHECK_DATE,@PAID_BY_CLIENT,@PRODUCTION,@GLDIST,
                                @TELEVISION,@RADIO,@NEWSPAPER,@MAGAZINE,@INTERNET,@OUTDOOR;",
                                BatchStatusSqlParameter,
                                BatchIDSqlParameter,
                                UserIDSqlParameter,
                                BankCodeSqlParameter,
                                APAccountCodeSqlParameter,
                                VendorCodeSqlParameter,
                                ClientCodeSqlParameter,
                                DateToPayCutoffSqlParameter,
                                CheckDateSqlParameter,
                                PaidByClientSqlParameter,
                                ProductionSqlParameter,
                                GLDistSqlParameter,
                                TelevisionSqlParameter,
                                RadioSqlParameter,
                                NewspaperSqlParameter,
                                MagazineSqlParameter,
                                InternetSqlParameter,
                                OutdoorSqlParameter
                                ).ToList
                        End Using

                    Else

                        ErrorMessage = "No input object."

                    End If

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                    Invoices = Nothing
                End Try

            End If


            If Invoices Is Nothing Then Invoices = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceDetail)

            Return Json(Invoices, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function CheckForOpenBank() As JsonResult
            'objects
            Dim Banks As Generic.List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail) = Nothing
            Dim OpenBankAvailable As Boolean = False

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                pUserCode.Value = Session("UserCode")

                Try

                    Banks = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetBanks] @USER_ID;",
                                        pUserCode).ToList

                    For Each Bank As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail In Banks
                        If Bank.OpenBatchFlag = 0 Then
                            OpenBankAvailable = True
                            Exit For
                        End If
                    Next

                Catch ex As Exception

                End Try
            End Using

            Return Json(OpenBankAvailable, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function CheckForOpenInvoices(BatchId As Integer, Invoices As List(Of String)) As JsonResult
            'objects
            Dim Response As String = String.Empty
            Dim InvoicesInUse As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse) = Nothing
            Dim InvoiceInUse As AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse = Nothing

            InvoicesInUse = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse)

            Dim pInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                For Each InvoiceNumber As String In Invoices
                    pInvoiceNumber = New System.Data.SqlClient.SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar, 20)
                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)

                    pInvoiceNumber.Value = InvoiceNumber
                    pBatchId.Value = BatchId

                    InvoiceInUse = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceInUse)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetOpenInvoiceDetails] @INVOICE_NUMBER, @BATCH_ID;",
                                        pInvoiceNumber,
                                        pBatchId
                                    ).FirstOrDefault

                    If InvoiceInUse IsNot Nothing Then
                        InvoicesInUse.Add(InvoiceInUse)
                    End If

                Next

            End Using

            Return Json(InvoicesInUse, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetBanks() As JsonResult
            'objects
            Dim Banks As Generic.List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                pUserCode.Value = Session("UserCode")

                Try

                    Banks = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetBanks] @USER_ID;",
                                        pUserCode).ToList

                Catch ex As Exception

                End Try
            End Using

            Return Json(Banks, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetBankDetail(BankCode As String) As JsonResult

            Dim BankDetail As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail = Nothing
            Dim pBankCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    pBankCode = New System.Data.SqlClient.SqlParameter("@BANK_CODE", SqlDbType.VarChar, 4)

                    pBankCode.Value = BankCode

                    BankDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBankDetail)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetBankDetail] @BANK_CODE;",
                                        pBankCode
                                    ).FirstOrDefault

                End Using

            Catch ex As Exception

            End Try

            Return MaxJson(BankDetail, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetBatchHeaders(BatchFilter As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchFilter) As JsonResult

            Dim BatchHeaders As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader) = Nothing
            Dim pBatchOwner As System.Data.SqlClient.SqlParameter = Nothing
            Dim pStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pStatus As System.Data.SqlClient.SqlParameter = Nothing

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    pBatchOwner = New System.Data.SqlClient.SqlParameter("@BATCH_OWNER", SqlDbType.VarChar, 6)
                    pStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                    pEndDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                    pStatus = New System.Data.SqlClient.SqlParameter("@STATUS", SqlDbType.VarChar, 25)

                    pBatchOwner.Value = IIf(BatchFilter.BatchOwner Is Nothing, DBNull.Value, BatchFilter.BatchOwner)
                    pStartDate.Value = IIf(BatchFilter.StartDate Is Nothing, DBNull.Value, BatchFilter.StartDate)
                    pEndDate.Value = IIf(BatchFilter.EndDate Is Nothing, DBNull.Value, BatchFilter.EndDate)
                    pStatus.Value = IIf(BatchFilter.Status Is Nothing, DBNull.Value, BatchFilter.Status)

                    BatchHeaders = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetBatches] @BATCH_OWNER, @START_DATE, @END_DATE, @STATUS;",
                                        pBatchOwner,
                                        pStartDate,
                                        pEndDate,
                                        pStatus
                                    ).ToList

                End Using

            Catch ex As Exception

            End Try

            Return MaxJson(BatchHeaders, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetPostingPeriods() As JsonResult
            'objects
            Dim PostingPeriods As Generic.List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPostingPeriodDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                PostingPeriods = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPostingPeriodDetail)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetPostingPeriods];"
                                    ).ToList

            End Using

            Return Json(PostingPeriods, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetAccountsPayableAccounts() As JsonResult
            Dim APDetail As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayableDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try

                    APDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayableDetail)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetAccounts];").ToList

                Catch ex As Exception

                End Try
            End Using

            Return Json(APDetail, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetPaymentTypes() As JsonResult
            Dim PaymentTypes As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try

                    PaymentTypes = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetPaymentTypes];").ToList

                Catch ex As Exception

                End Try
            End Using

            Return Json(PaymentTypes, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetClients(InvoiceFilter As AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceFilter) As JsonResult
            'NS - currently the "Selection Criteria 2" of the existing check writing module doesn't filter clients 
            'NS - based on previous selections (APAccountCode and VendorCode), should/can it?
            Dim ClientDetail As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Try

                    ClientDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetClients];").ToList

                Catch ex As Exception

                End Try
            End Using

            Return MaxJson(ClientDetail, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetVendorsByAPAccount(BankCode As String, APAccountcode As String, VCCStatus As Integer, DefaultBank As Integer) As JsonResult
            'NS - There is an option for 'Default Bank' in the current check writing module.
            'NS - It looks like it overrides the selected BankCode when selected (doesn't make sense, clarify with EC)
            Dim VendorDetail As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail) = Nothing

            Dim pBankCode As Data.SqlClient.SqlParameter = Nothing
            Dim pAPAccountCode As Data.SqlClient.SqlParameter = Nothing
            Dim pDefaultBank As Data.SqlClient.SqlParameter = Nothing
            Dim pVCCStatus As Data.SqlClient.SqlParameter = Nothing

            pBankCode = New System.Data.SqlClient.SqlParameter("@BANK_CODE", SqlDbType.VarChar, 4)
            pAPAccountCode = New SqlParameter("@AP_ACCOUNT_CODE", SqlDbType.VarChar, 30)
            pVCCStatus = New SqlParameter("@VCC_STATUS", SqlDbType.Int)
            pDefaultBank = New SqlParameter("@DEFAULT_BANK", SqlDbType.Int)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                pBankCode.Value = IIf(BankCode Is Nothing, "ALL", BankCode)
                pAPAccountCode.Value = IIf(APAccountcode Is Nothing, "ALL", APAccountcode)
                pVCCStatus.Value = VCCStatus
                pDefaultBank.Value = DefaultBank

                Try

                    VendorDetail = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetVendors] @BANK_CODE, @AP_ACCOUNT_CODE, @VCC_STATUS, @DEFAULT_BANK;",
                        pBankCode,
                        pAPAccountCode,
                        pVCCStatus,
                        pDefaultBank
                    ).ToList

                Catch ex As Exception

                End Try
            End Using

            Return MaxJson(VendorDetail, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetChartData(ChartId As Integer) As JsonResult
            'temporary hard coding for dashboard data
            'once the metrics have been nailed down for the dashboards

            Dim DataDetails As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData) = Nothing
            Dim DataDetail As AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData = Nothing

            'Spend By Payment Type
            If ChartId = 0 Then
                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "In-House Check"
                DataDetail.Count = 15
                DataDetail.Amount = 223298

                DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Manual Check"
                DataDetail.Count = 7
                DataDetail.Amount = 82843

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "VCC"
                DataDetail.Count = 4
                DataDetail.Amount = 12256

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Check"
                DataDetail.Count = 12
                DataDetail.Amount = 193753

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "ACH"
                DataDetail.Count = 8
                DataDetail.Amount = 31246

                DataDetails.Add(DataDetail)
            End If

            'Open Payables by Type
            If ChartId = 1 Then
                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Media"
                DataDetail.Count = 15
                DataDetail.Amount = 223298

                DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Non-Client"
                DataDetail.Count = 7
                DataDetail.Amount = 82843

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Production"
                DataDetail.Count = 4
                DataDetail.Amount = 12256

                DataDetails.Add(DataDetail)
            End If

            'Open Payables by Type - Pie Chart
            If ChartId = 2 Then
                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Media"
                DataDetail.Count = 22
                DataDetail.Amount = 63330

                DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Non-Client"
                DataDetail.Count = 8
                DataDetail.Amount = 25846

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Production"
                DataDetail.Count = 15
                DataDetail.Amount = 47652

                DataDetails.Add(DataDetail)
            End If

            'Open Payables by Type - Grid Detail
            If ChartId = 3 Then
                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Centro"
                DataDetail.SubCategory = "Media"
                DataDetail.Count = 1
                DataDetail.Amount = 19164

                DataDetails = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData)
                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Excellent Printing Company"
                DataDetail.SubCategory = "Production"
                DataDetail.Count = 3
                DataDetail.Amount = 47652

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Facebook"
                DataDetail.SubCategory = "Media"
                DataDetail.Count = 2
                DataDetail.Amount = 21254

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Federal Express, Corp"
                DataDetail.SubCategory = "Non-Client"
                DataDetail.Count = 1
                DataDetail.Amount = 25846

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "KABC Radio"
                DataDetail.SubCategory = "Media"
                DataDetail.Count = 1
                DataDetail.Amount = 8653

                DataDetails.Add(DataDetail)

                DataDetail = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterDashboardDetailData()
                DataDetail.Category = "Simpli.Fi"
                DataDetail.SubCategory = "Media"
                DataDetail.Count = 1
                DataDetail.Amount = 14259

                DataDetails.Add(DataDetail)
            End If

            Return MaxJson(DataDetails, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function ClientExistsForInvoice(InvoiceType As String, ApId As Integer, ClientCode As String) As Integer
            Dim ClientExists As Integer

            Dim pInvoiceType As System.Data.SqlClient.SqlParameter = Nothing
            Dim pApId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pClientCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                    pInvoiceType = New System.Data.SqlClient.SqlParameter("@INVOICE_TYPE", SqlDbType.VarChar, 50)
                    pApId = New System.Data.SqlClient.SqlParameter("@AP_ID", SqlDbType.Int)
                    pClientCode = New System.Data.SqlClient.SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 6)

                    pInvoiceType.Value = InvoiceType
                    pApId.Value = ApId
                    pClientCode.Value = ClientCode

                    ClientExists = DbContext.Database.SqlQuery(Of Integer)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterClientExistsForInvoice] @INVOICE_TYPE, @AP_ID, @CLIENT_CODE;",
                                        pInvoiceType,
                                        pApId,
                                        pClientCode
                                    ).FirstOrDefault

                End Using

            Catch ex As Exception

            End Try

            Return ClientExists
        End Function
        <HttpPost>
        Public Function ProcessGridColumnReorder(ByVal GridName As String, ByVal GridColumns As List(Of AdvantageFramework.PaymentCenter.Classes.GridColumnUpdates)) _
                                                 As JsonResult
            'Objects
            Dim Saved As Boolean = False
            Dim Message As String = Nothing
            Dim ErrorMessage As String = Nothing

            Dim pGridName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnID As System.Data.SqlClient.SqlParameter = Nothing
            Dim pColumnName As System.Data.SqlClient.SqlParameter = Nothing

            If GridColumns IsNot Nothing Then

                For Each Item As AdvantageFramework.PaymentCenter.Classes.GridColumnUpdates In GridColumns

                    Try

                        Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                            Dim mycommand As New SqlCommand()
                            With mycommand
                                .CommandType = CommandType.StoredProcedure
                                .CommandText = "usp_wv_PaymentCenterUpdateColumnOrderSettings"
                                .Connection = myconn
                            End With

                            pGridName = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                            pColumnID = New System.Data.SqlClient.SqlParameter("@NEW_COLUMN_ORDER_ID", SqlDbType.Int)
                            pColumnName = New System.Data.SqlClient.SqlParameter("@COLUMN_NAME", SqlDbType.VarChar, 100)

                            pGridName.Value = GridName
                            pUserCode.Value = Session("UserCode")
                            pColumnID.Value = Item.ColumnID
                            pColumnName.Value = Item.ColumnName

                            mycommand.Parameters.Add(pGridName)
                            mycommand.Parameters.Add(pUserCode)
                            mycommand.Parameters.Add(pColumnID)
                            mycommand.Parameters.Add(pColumnName)

                            myconn.Open()

                            mycommand.ExecuteNonQuery()

                        End Using

                    Catch ex As Exception

                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Saved = False

                    End Try

                Next

                ErrorMessage = ""
                Saved = True
            End If

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function
        <HttpPost>
        Public Function DeleteExistingBatch(ByVal BatchId As Integer)

            Dim Deleted As Boolean = True
            Dim ErrorMessage As String = String.Empty

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))
                    Deleted = DeleteBatch(DbContext, BatchId)
                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            Return MaxJson(New With {.Success = Deleted, .ErrorMessage = ErrorMessage})

        End Function

        <HttpPost>
        Public Function PostBatch(BatchId As Integer) As JsonResult
            Dim APPaymentHistory As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayablePaymentHistory) = Nothing
            Dim BaseCheckNumbers As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes) = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing

            Dim PrevGLAccountCode As String = Nothing
            Dim GLAPSequence As Integer

            Dim Save As Boolean = False
            Dim GlIdUpdated As Boolean = False
            Dim GLId As Integer

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))
                    GLId = InsertGLEntries(DbContext, Session("UserCode"), BatchId, "CC")

                    APPaymentHistory = New List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayablePaymentHistory)

                    pUserCode = New SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                    pBatchId = New SqlParameter("@BATCH_ID", SqlDbType.Int)

                    pUserCode.Value = Session("UserCode")
                    pBatchId.Value = BatchId

                    APPaymentHistory = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayablePaymentHistory)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetAPHistBase] @USER_CODE, @BATCH_ID;",
                                        pUserCode,
                                        pBatchId
                                    ).ToList

                    'Populate the BaseCheckNumbers by PaymentType
                    BaseCheckNumbers = GetBaseCheckNumbersByPaymentType(APPaymentHistory(0).BankCode)

                    If APPaymentHistory IsNot Nothing Then

                        GLAPSequence = 2
                        '2 is the base for the GL AP Sequence number, 1 is reservied for the GLCashSequence
                        'the GLAPSequence increments when the GLAPAccountCode Changes for a batch

                        PrevGLAccountCode = APPaymentHistory(0).GLAccountCode

                        For Index As Integer = 0 To APPaymentHistory.Count - 1

                            APPaymentHistory(Index).GLId = GLId
                            APPaymentHistory(Index).GLCashSequence = 1 'the GLCash Account will always be 1 since a batch can only include one funding account.

                            APPaymentHistory(Index).APCheckNumber = GetCheckNumberByPaymentType(APPaymentHistory(Index).PaymentType, BaseCheckNumbers)

                            If APPaymentHistory(Index).GLAccountCode = PrevGLAccountCode Then
                                APPaymentHistory(Index).GLAPSequence = GLAPSequence
                            Else
                                GLAPSequence = GLAPSequence + 1
                                APPaymentHistory(Index).GLAPSequence = GLAPSequence
                            End If

                            APPaymentHistory(Index).CreateDate = APPaymentHistory(Index).APCheckDate
                            APPaymentHistory(Index).UserId = Session("UserCode")

                            PrevGLAccountCode = APPaymentHistory(Index).GLAccountCode

                        Next

                        'error handling and rollbacks for ledger entries etc. needed.
                        Save = InsertAPPaymentHistoryEntries(DbContext, APPaymentHistory)
                        Save = InsertCheckRegisterEntries(DbContext, BatchId, GLId)

                        GLIdUpdated = DbContext.Database.SqlQuery(Of Integer)(String.Format("UPDATE IDS SET IDSXACT = {0} WHERE IDSTABLE = 'GLENTHDR';", GLId)).FirstOrDefault
                    End If

                End Using

            Catch ex As Exception

                'Saved = False
                'ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

            End Try

            Return MaxJson(APPaymentHistory, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Public Function CreateNewBatch(ByVal BatchHeader As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader,
                                  ByVal Invoices As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceHeader),
                                  ByVal Clients As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail),
                                  ByVal Accounts As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail),
                                  ByVal Vendors As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail),
                                  ByVal BatchHeaderOnly As Boolean) As JsonResult

            Dim BatchId As Integer
            Dim Saved As Boolean = True
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim BatchResponse As AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader = Nothing

            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchStatus As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBankCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPayCutoffDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPostingPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaOOH As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim pMediaTelevision As System.Data.SqlClient.SqlParameter = Nothing
            Dim pNonClientSelect As System.Data.SqlClient.SqlParameter = Nothing
            Dim pProductionSelect As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAllInvoicesSelect As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaidByClientSelect As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))
                    BatchResponse = New AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader

                    If BatchHeader.BatchId IsNot Nothing Then
                        'This is an update to an existing batch, delete batch and recreate with newly posted information
                        Deleted = DeleteBatch(DbContext, BatchHeader.BatchId)
                    Else
                        Deleted = True
                    End If

                    If BatchHeader.BatchId IsNot Nothing And Deleted = False Then
                        Saved = False
                        ErrorMessage = "Unable to delete existing batch information, please contact support."

                        Return MaxJson(New With {.Success = Saved, .BatchId = BatchResponse.BatchId, .BatchStatus = BatchResponse.BatchStatus,
                           .BatchName = BatchResponse.BatchName, .BatchStatusDescription = BatchResponse.BatchStatusDescription, .ErrorMessage = ErrorMessage})
                    End If

                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar, 6)
                    pBatchStatus = New System.Data.SqlClient.SqlParameter("@BATCH_STATUS", SqlDbType.VarChar, 1)
                    pBankCode = New System.Data.SqlClient.SqlParameter("@BANK_CODE", SqlDbType.VarChar, 4)
                    pPaymentDate = New System.Data.SqlClient.SqlParameter("@PAYMENT_DATE", SqlDbType.SmallDateTime)
                    pPayCutoffDate = New System.Data.SqlClient.SqlParameter("@PAY_CUTOFF_DATE", SqlDbType.SmallDateTime)
                    pPostingPeriod = New System.Data.SqlClient.SqlParameter("@POSTING_PERIOD", SqlDbType.VarChar, 6)
                    pMediaInternet = New System.Data.SqlClient.SqlParameter("@MEDIA_INTERNET", SqlDbType.Bit)
                    pMediaMagazine = New System.Data.SqlClient.SqlParameter("@MEDIA_MAGAZINE", SqlDbType.Bit)
                    pMediaNewspaper = New System.Data.SqlClient.SqlParameter("@MEDIA_NEWSPAPER", SqlDbType.Bit)
                    pMediaOOH = New System.Data.SqlClient.SqlParameter("@MEDIA_OOH", SqlDbType.Bit)
                    pMediaRadio = New System.Data.SqlClient.SqlParameter("@MEDIA_RADIO", SqlDbType.Bit)
                    pMediaTelevision = New System.Data.SqlClient.SqlParameter("@MEDIA_TELEVISION", SqlDbType.Bit)
                    pNonClientSelect = New System.Data.SqlClient.SqlParameter("@NON_CLIENT_SELECT", SqlDbType.Bit)
                    pProductionSelect = New System.Data.SqlClient.SqlParameter("@PRODUCTION_SELECT", SqlDbType.Bit)
                    pAllInvoicesSelect = New System.Data.SqlClient.SqlParameter("@ALL_INVOICES_SELECT", SqlDbType.Bit)
                    pPaidByClientSelect = New System.Data.SqlClient.SqlParameter("@PAID_BY_CLIENT_SELECT", SqlDbType.Bit)

                    pUserCode.Value = Session("UserCode")
                    pBatchStatus.Value = BatchHeader.BatchStatus
                    pBankCode.Value = BatchHeader.BankCode
                    pPaymentDate.Value = BatchHeader.PaymentDate
                    pPayCutoffDate.Value = BatchHeader.PayCutoffDate
                    pPostingPeriod.Value = BatchHeader.PostingPeriod
                    pMediaInternet.Value = BatchHeader.MediaInternet
                    pMediaMagazine.Value = BatchHeader.MediaMagazine
                    pMediaNewspaper.Value = BatchHeader.MediaNewspaper
                    pMediaOOH.Value = BatchHeader.MediaOOH
                    pMediaRadio.Value = BatchHeader.MediaRadio
                    pMediaTelevision.Value = BatchHeader.MediaTelevision
                    pNonClientSelect.Value = BatchHeader.NonClientItems
                    pProductionSelect.Value = BatchHeader.ProductionItems
                    pAllInvoicesSelect.Value = BatchHeader.AllInvoicesSelect
                    pPaidByClientSelect.Value = BatchHeader.PaidByClientSelect

                    BatchResponse = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterBatchHeader)(
"EXEC [dbo].[usp_wv_PaymentCenterAddBatchHeader] @USER_ID, @BATCH_STATUS, @BANK_CODE, @PAYMENT_DATE, @PAY_CUTOFF_DATE, @POSTING_PERIOD, @MEDIA_INTERNET, @MEDIA_MAGAZINE,
@MEDIA_NEWSPAPER, @MEDIA_OOH, @MEDIA_RADIO, @MEDIA_TELEVISION, @NON_CLIENT_SELECT, @PRODUCTION_SELECT, @ALL_INVOICES_SELECT, @PAID_BY_CLIENT_SELECT;",
                        pUserCode,
                        pBatchStatus,
                        pBankCode,
                        pPaymentDate,
                        pPayCutoffDate,
                        pPostingPeriod,
                        pMediaInternet,
                        pMediaMagazine,
                        pMediaNewspaper,
                        pMediaOOH,
                        pMediaRadio,
                        pMediaTelevision,
                        pNonClientSelect,
                        pProductionSelect,
                        pAllInvoicesSelect,
                        pPaidByClientSelect
                    ).FirstOrDefault

                    If BatchHeaderOnly = False Then
                        'INSERT BATCH INVOICEs SELECTED RECORDS
                        For Each Item As AdvantageFramework.PaymentCenter.Classes.PaymentCenterInvoiceHeader In Invoices

                            Try

                                InsertBatchInvoiceRecord(DbContext, BatchResponse.BatchId, Item.InvoiceNumber, Item.PayMethod, Item.InvoiceType, Item.APId, Item.ApprovedAmount, Item.DiscApprovedAmount)

                            Catch ex As Exception

                                Saved = False
                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                            End Try

                        Next
                    End If

                    'INSERT ACCOUNT CODEs SELECTED RECORDS
                    If Accounts IsNot Nothing Then

                        For Each Item As AdvantageFramework.PaymentCenter.Classes.PaymentCenterGLAccountDetail In Accounts

                            Try

                                InsertBatchAccountRecord(DbContext, BatchResponse.BatchId, Item.GLCode)

                            Catch ex As Exception

                                Saved = False
                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                            End Try

                        Next

                    End If

                    'INSERT VENDOR CODEs SELECTED RECORDS
                    If Vendors IsNot Nothing Then


                        For Each Item As AdvantageFramework.PaymentCenter.Classes.PaymentCenterVendorDetail In Vendors

                            Try

                                InsertBatchVendorRecord(DbContext, BatchResponse.BatchId, Item.Code)

                            Catch ex As Exception

                                Saved = False
                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                            End Try

                        Next

                    End If


                    If BatchHeaderOnly Then
                        'This is a batch header save only, save client codes selected in header
                        If Clients IsNot Nothing Then

                            Try
                                For Each Item As AdvantageFramework.PaymentCenter.Classes.PaymentCenterClientDetail In Clients
                                    InsertBatchClientRecord(DbContext, BatchResponse.BatchId, Item.Code)
                                Next
                            Catch ex As Exception
                                Saved = False
                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            End Try

                        End If

                    Else
                        'INSERT CLIENT CODEs SELECTED RECORDS
                        'save client codes based on invoice data
                        Try

                            CreateBatchClientRecords(DbContext, BatchResponse.BatchId)

                        Catch ex As Exception

                            Saved = False
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                        End Try
                    End If

                End Using

            Catch ex As Exception

                Throw ex

            End Try


            Return MaxJson(New With {.Success = Saved, .BatchId = BatchResponse.BatchId, .BatchStatus = BatchResponse.BatchStatus,
                           .BatchName = BatchResponse.BatchName, .BatchStatusDescription = BatchResponse.BatchStatusDescription, .ErrorMessage = ErrorMessage})

        End Function

        <HttpPost>
        Public Function SaveColumnSetting(ByVal GridName As String, ByVal Column As String, ShowHide As Boolean) As JsonResult

            Dim save As Boolean = True
            Dim colName As String = ""

            Try
                Select Case Column
                    Case "Pay"
                        colName = "Pay"
                    Case "PayMethod"
                        colName = "PayMethod"
                    Case "PayToVendorCode"
                        colName = "PayToVendorCode"
                    Case "PayToVendorName"
                        colName = "PayToVendorName"
                    Case "InvoiceNumber"
                        colName = "InvoiceNumber"
                    Case "InvoiceType"
                        colName = "InvoiceType"
                    Case "DateToPay"
                        colName = "DateToPay"
                    Case "BalanceToPay"
                        colName = "BalanceToPay"
                    Case "ApprovedAmount"
                        colName = "ApprovedAmount"
                    Case "GLAccount"
                        colName = "GLAccount"
                    Case "VendorCode"
                        colName = "VendorCode"
                    Case "VendorName"
                        colName = "VendorName"
                    Case "InvoiceDescription"
                        colName = "InvoiceDescription"
                    Case "InvoiceDate"
                        colName = "InvoiceDate"
                    Case "InvoiceTotal"
                        colName = "InvoiceTotal"
                    Case "InvoiceBalance"
                        colName = "InvoiceBalance"
                    Case "DiscountPercentage"
                        colName = "DiscountPercentage"
                    Case "DiscountAvailable"
                        colName = "DiscountAvailable"
                    Case "DiscountApproved"
                        colName = "DiscountApproved"
                    Case "WithholdingTax"
                        colName = "WithholdingTax"
                    Case "PaidPreviously"
                        colName = "PaidPreviously"
                    Case "NonBillableAmount"
                        colName = "NonBillableAmount"
                    Case "BillableAmount"
                        colName = "BillableAmount"
                    Case "DirectBillAmount"
                        colName = "DirectBillAmount"
                    Case "ProdAdvanceBalance"
                        colName = "ProdAdvanceBalance"
                    Case "CashReceived"
                        colName = "CashReceived"
                    Case "TotalQualified"
                        colName = "TotalQualified"
                End Select

                AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), Session("UserCode"), GridName, colName, ShowHide)
            Catch ex As Exception
                save = False
            End Try


            Return MaxJson(New With {.Success = save})

        End Function

        <HttpGet>
        Public Function IsEmailAddressValid(Email As String) As Integer
            Dim Valid As Integer

            Valid = Convert.ToInt32(AdvantageFramework.StringUtilities.IsValidEmailAddress(Email))

            Return Valid
        End Function

        <HttpPost>
        Public Function SaveEmailAddress(ByVal VendorCode As String, ByVal EmailAddress As String, ByVal EmailAddressType As String) As JsonResult

            Dim Response As Integer
            Dim Saved As Boolean = False

            Dim pVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pEmailAddress As System.Data.SqlClient.SqlParameter = Nothing
            Dim pEmailAddressType As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))

                pEmailAddressType = New System.Data.SqlClient.SqlParameter("@EMAIL_ADDRESS_TYPE", SqlDbType.VarChar, 25)
                pVendorCode = New System.Data.SqlClient.SqlParameter("@VENDOR_CODE", SqlDbType.VarChar, 6)
                pEmailAddress = New System.Data.SqlClient.SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50)

                pVendorCode.Value = VendorCode
                pEmailAddress.Value = EmailAddress
                pEmailAddressType.Value = EmailAddressType

                Response = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterUpdateVendorEmail] @EMAIL_ADDRESS_TYPE, @VENDOR_CODE, @EMAIL_ADDRESS;",
                    pEmailAddressType,
                    pVendorCode,
                    pEmailAddress)

                If Response > 0 Then
                    Saved = True
                Else
                    Saved = False
                End If

            End Using

            Return MaxJson(New With {.Success = Saved})

        End Function
        <HttpGet>
        Public Function GetGridColumnSettings(GridName As String) As JsonResult

            Dim UserColumn As New List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridColumnSetting)

            Dim pGridName As Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As Data.SqlClient.SqlParameter = Nothing

            pGridName = New SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
            pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                pGridName.Value = GridName
                pUserCode.Value = Session("UserCode")

                Try

                    UserColumn = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridColumnSetting)(
                    "EXEC [dbo].[usp_wv_PaymentCenterGetColumnSettings] @GRID_NAME, @USER_CODE;",
                        pUserCode,
                        pGridName
                    ).ToList

                Catch ex As Exception

                End Try
            End Using

            Return MaxJson(UserColumn, JsonRequestBehavior.AllowGet)

        End Function
        '
#End Region

#Region " Private "
        Private Function InsertGLEntries(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, BatchId As Integer, PostSource As String)
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPostSource As System.Data.SqlClient.SqlParameter = Nothing

            Dim GLId As Integer

            Try

                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pPostSource = New System.Data.SqlClient.SqlParameter("@POST_SOURCE", SqlDbType.VarChar, 10)

                pUserCode.Value = Session("UserCode")
                pBatchId.Value = BatchId
                pPostSource.Value = PostSource

                GLId = DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[usp_wv_PaymentCenterPostBatchToGL] @USER_CODE, @BATCH_ID, @POST_SOURCE;",
                                pUserCode,
                                pBatchId,
                                pPostSource).FirstOrDefault

            Catch ex As Exception

                Throw ex

            End Try

            Return GLId
        End Function
        Private Function InsertCheckRegisterEntries(DbContext As AdvantageFramework.Database.DbContext, BatchId As String, GLId As Integer) As Boolean
            Dim pGLId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim Result As Integer

            Try

                pGLId = New System.Data.SqlClient.SqlParameter("@GL_ID", SqlDbType.Int)
                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

                pGLId.Value = GLId
                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")

                Result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterInsertCheckRegister] @GL_ID, @BATCH_ID, 
                                @USER_CODE;",
                                pGLId,
                                pBatchId,
                                pUserCode)

            Catch ex As Exception

                Throw ex

            End Try

        End Function
        Private Function InsertAPPaymentHistoryEntries(DbContext As AdvantageFramework.Database.DbContext,
                                                       APPaymentHistory As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayablePaymentHistory)) As Boolean
            Dim pAPId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPSequence As System.Data.SqlClient.SqlParameter = Nothing
            Dim pBankCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPCheckNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pCheckSequence As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPCheckDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPDiscountAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPCashAccount As System.Data.SqlClient.SqlParameter = Nothing
            Dim pGLAccountCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pGLId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pGLCashSequence As System.Data.SqlClient.SqlParameter = Nothing
            Dim pGLAPSequence As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPostingPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim pCreateDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pVendorTaxableAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim pVendorServiceTaxAmount As System.Data.SqlClient.SqlParameter = Nothing

            Dim Result As Integer

            Try

                pAPId = New System.Data.SqlClient.SqlParameter("@AP_ID", SqlDbType.Int)
                pAPSequence = New System.Data.SqlClient.SqlParameter("@AP_SEQ", SqlDbType.Int)
                pBankCode = New System.Data.SqlClient.SqlParameter("@BK_CODE", SqlDbType.VarChar, 4)
                pAPCheckNumber = New System.Data.SqlClient.SqlParameter("@AP_CHK_NBR", SqlDbType.Int)
                pCheckSequence = New System.Data.SqlClient.SqlParameter("@CHK_SEQ", SqlDbType.Int)
                pAPCheckDate = New System.Data.SqlClient.SqlParameter("@AP_CHK_DATE", SqlDbType.Date)
                pAPAmount = New System.Data.SqlClient.SqlParameter("@AP_CHK_AMT", SqlDbType.Decimal)
                pAPDiscountAmount = New System.Data.SqlClient.SqlParameter("@AP_DISC_AMT", SqlDbType.Decimal)
                pAPCashAccount = New System.Data.SqlClient.SqlParameter("@GLACODE_CASH", SqlDbType.VarChar, 30)
                pGLAccountCode = New System.Data.SqlClient.SqlParameter("@GLACODE_AP", SqlDbType.VarChar, 30)
                pGLId = New System.Data.SqlClient.SqlParameter("@GLEXACT", SqlDbType.Int)
                pGLCashSequence = New System.Data.SqlClient.SqlParameter("@GLESEQ_CASH", SqlDbType.Int)
                pGLAPSequence = New System.Data.SqlClient.SqlParameter("@GLESEQ_AP", SqlDbType.Int)
                pPostingPeriod = New System.Data.SqlClient.SqlParameter("@POST_PERIOD", SqlDbType.VarChar, 6)
                pCreateDate = New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.Date)
                pUserId = New System.Data.SqlClient.SqlParameter("@USERID", SqlDbType.VarChar, 100)
                pVendorTaxableAmount = New System.Data.SqlClient.SqlParameter("@VENDOR_TAXABLE_AMOUNT", SqlDbType.Decimal)
                pVendorServiceTaxAmount = New System.Data.SqlClient.SqlParameter("@VENDOR_SERVICE_TAX", SqlDbType.Decimal)

                For Each Item As AdvantageFramework.PaymentCenter.Classes.PaymentCenterAccountsPayablePaymentHistory In APPaymentHistory
                    pAPId.Value = Item.APId
                    pAPSequence.Value = Item.APSequence
                    pBankCode.Value = Item.BankCode
                    pAPCheckNumber.Value = Item.APCheckNumber
                    pCheckSequence.Value = Item.CheckSequence
                    pAPCheckDate.Value = Item.APCheckDate
                    pAPAmount.Value = Item.APAmount
                    pAPDiscountAmount.Value = Item.APDiscountAmount
                    pAPCashAccount.Value = Item.APCashAccount
                    pGLAccountCode.Value = Item.GLAccountCode
                    pGLId.Value = Item.GLId
                    pGLCashSequence.Value = Item.GLCashSequence
                    pGLAPSequence.Value = Item.GLAPSequence
                    pPostingPeriod.Value = Item.PostingPeriod
                    pCreateDate.Value = Item.CreateDate
                    pUserId.Value = Item.UserId
                    pVendorTaxableAmount.Value = Item.VendorTaxableAmount
                    pVendorServiceTaxAmount.Value = Item.VendorServiceTaxAmount

                    Result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterInsertAPPaymentHistory] @AP_ID, @AP_SEQ, 
                                @BK_CODE, @AP_CHK_NBR, @CHK_SEQ, @AP_CHK_DATE, @AP_CHK_AMT, @AP_DISC_AMT, @GLACODE_CASH, @GLACODE_AP, 
                                @GLEXACT, @GLESEQ_CASH, @GLESEQ_AP, @POST_PERIOD, @CREATE_DATE, @USERID, @VENDOR_TAXABLE_AMOUNT, @VENDOR_SERVICE_TAX;",
                                pAPId,
                                pAPSequence,
                                pBankCode,
                                pAPCheckNumber,
                                pCheckSequence,
                                pAPCheckDate,
                                pAPAmount,
                                pAPDiscountAmount,
                                pAPCashAccount,
                                pGLAccountCode,
                                pGLId,
                                pGLCashSequence,
                                pGLAPSequence,
                                pPostingPeriod,
                                pCreateDate,
                                pUserId,
                                pVendorTaxableAmount,
                                pVendorServiceTaxAmount)
                Next

            Catch ex As Exception

                Throw ex

            End Try

        End Function

        Private Function GetCheckNumberByPaymentType(PaymentType As String, ByRef BaseCheckNumbers As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes)) As Integer
            Dim CheckNumber As Integer
            Dim Index As Integer

            Index = BaseCheckNumbers.FindIndex(Function(PayType) PayType.Code = PaymentType)

            CheckNumber = BaseCheckNumbers(Index).BaseCheckNumber
            BaseCheckNumbers(Index).BaseCheckNumber = BaseCheckNumbers(Index).BaseCheckNumber + 1

            Return CheckNumber

        End Function

        Private Function GetBaseCheckNumbersByPaymentType(BankCode As String) As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes)
            Dim BaseCheckNumbers As List(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes) = Nothing

            Dim pBankCode As System.Data.SqlClient.SqlParameter = Nothing

            pBankCode = New SqlParameter("@BANK_CODE", SqlDbType.VarChar, 4)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Session("UserCode"))
                    pBankCode.Value = BankCode

                    BaseCheckNumbers = DbContext.Database.SqlQuery(Of AdvantageFramework.PaymentCenter.Classes.PaymentCenterPaymentTypes)(
                                    "EXEC [dbo].[usp_wv_PaymentCenterGetBaseCheckNumbersByPaymentType] @BANK_CODE;",
                                        pBankCode
                                    ).ToList

                    If BaseCheckNumbers IsNot Nothing Then
                        Return BaseCheckNumbers
                    End If

                End Using
            Catch ex As Exception

                'Saved = False
                'ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

            End Try
        End Function

        Private Function CreateBatchClientRecords(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String)

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim result As Integer

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")

                result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterCreateBatchClient] @BATCH_ID, @USER_CODE;",
                                                              pBatchId, pUserCode)

            Catch ex As Exception

                Throw ex

            End Try
        End Function

        Private Function DeleteBatch(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String) As Boolean

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim Result As Integer
            Dim Deleted As Boolean = False

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")

                Result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterDeleteBatch] @BATCH_ID, @USER_CODE;",
                                                              pBatchId, pUserCode)

                If Result > 1 Then
                    Deleted = True
                Else
                    Deleted = False
                End If

            Catch ex As Exception

                Throw ex

            End Try

            Return Deleted
        End Function

        Private Function InsertBatchVendorRecord(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String, ByVal VendorCode As String)

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pVendorCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim result As Integer

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                pVendorCode = New System.Data.SqlClient.SqlParameter("@VENDOR_CODE", SqlDbType.VarChar, 20)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")
                pVendorCode.Value = VendorCode

                result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterCreateBatchVendor] @BATCH_ID, @USER_CODE, 
                    @VENDOR_CODE;", pBatchId, pUserCode, pVendorCode)


            Catch ex As Exception

                Throw ex

            End Try
        End Function

        Private Function InsertBatchAccountRecord(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String, ByVal GLCode As String)

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pGLCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim result As Integer

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                pGLCode = New System.Data.SqlClient.SqlParameter("@GL_CODE", SqlDbType.VarChar, 20)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")
                pGLCode.Value = GLCode

                result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterCreateBatchAccount] @BATCH_ID, @USER_CODE, 
                    @GL_CODE;", pBatchId, pUserCode, pGLCode)


            Catch ex As Exception

                Throw ex

            End Try
        End Function

        Private Function InsertBatchClientRecord(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String, ByVal ClientCode As String)

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pClientCode As System.Data.SqlClient.SqlParameter = Nothing

            Dim result As Integer

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                pClientCode = New System.Data.SqlClient.SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 6)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")
                pClientCode.Value = ClientCode

                result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterCreateBatchClientRecord] @BATCH_ID, @USER_CODE, 
                    @CLIENT_CODE;", pBatchId, pUserCode, pClientCode)


            Catch ex As Exception

                Throw ex

            End Try
        End Function

        Private Function InsertBatchInvoiceRecord(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchId As String,
                                                    ByVal InvoiceNumber As String, ByVal PaymentTypeCode As String, ByVal InvoiceType As String,
                                                    ByVal APId As Integer, ByVal ApprovedAmount As Decimal, ByVal DiscApprovedAmount As Decimal)

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pInvoiceNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim pPaymentTypeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pInvoiceType As System.Data.SqlClient.SqlParameter = Nothing
            Dim pAPId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pApprovedAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim pDiscApprovedAmount As System.Data.SqlClient.SqlParameter = Nothing

            Dim result As Integer

            Try

                pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                pAPId = New System.Data.SqlClient.SqlParameter("@AP_ID", SqlDbType.Int)
                pInvoiceNumber = New System.Data.SqlClient.SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar, 20)
                pPaymentTypeCode = New System.Data.SqlClient.SqlParameter("@PAYMENT_TYPE_CODE", SqlDbType.VarChar, 10)
                pInvoiceType = New System.Data.SqlClient.SqlParameter("@INVOICE_TYPE", SqlDbType.VarChar, 50)
                pApprovedAmount = New System.Data.SqlClient.SqlParameter("@APPROVED_AMOUNT", SqlDbType.Decimal)
                pDiscApprovedAmount = New System.Data.SqlClient.SqlParameter("@DISC_APPROVED_AMOUNT", SqlDbType.Decimal)

                pBatchId.Value = BatchId
                pUserCode.Value = Session("UserCode")
                pAPId.Value = APId
                pInvoiceNumber.Value = InvoiceNumber
                pPaymentTypeCode.Value = PaymentTypeCode
                pInvoiceType.Value = InvoiceType
                pApprovedAmount.Value = ApprovedAmount
                pDiscApprovedAmount.Value = DiscApprovedAmount

                result = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_PaymentCenterCreateBatchInvoice] @BATCH_ID, @USER_CODE, 
                     @AP_ID, @INVOICE_NUMBER, @PAYMENT_TYPE_CODE, @INVOICE_TYPE, @APPROVED_AMOUNT, @DISC_APPROVED_AMOUNT;", pBatchId, pUserCode, pAPId, pInvoiceNumber, pPaymentTypeCode,
                                                                                  pInvoiceType, pApprovedAmount, pDiscApprovedAmount)


            Catch ex As Exception

                Throw ex

            End Try
        End Function

        <HttpPost>
        Public Function UpdateBatchHeader(ByVal BatchId As Integer, ByVal FieldName As String, ByVal FieldValue As String) As JsonResult
            'Objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = Nothing

            Dim pBatchId As System.Data.SqlClient.SqlParameter = Nothing
            Dim pUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim pFieldName As System.Data.SqlClient.SqlParameter = Nothing
            Dim pFieldValue As System.Data.SqlClient.SqlParameter = Nothing

            Try

                Using myconn As New SqlConnection(Me.SecuritySession.ConnectionString)

                    Dim mycommand As New SqlCommand()
                    With mycommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_PaymentCenterUpdateBatchHeader"
                        .Connection = myconn
                    End With

                    pBatchId = New System.Data.SqlClient.SqlParameter("@BATCH_ID", SqlDbType.Int)
                    pUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)
                    pFieldName = New System.Data.SqlClient.SqlParameter("@FIELD_NAME", SqlDbType.VarChar, 255)
                    pFieldValue = New System.Data.SqlClient.SqlParameter("@FIELD_VALUE", SqlDbType.VarChar, 255)

                    pBatchId.Value = BatchId
                    pUserCode.Value = Session("UserCode")
                    pFieldName.Value = FieldName
                    pFieldValue.Value = FieldValue

                    mycommand.Parameters.Add(pBatchId)
                    mycommand.Parameters.Add(pUserCode)
                    mycommand.Parameters.Add(pFieldName)
                    mycommand.Parameters.Add(pFieldValue)

                    myconn.Open()

                    mycommand.ExecuteNonQuery()

                End Using

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Saved = False

            End Try

            ErrorMessage = ""
            Saved = True

            Return MaxJson(New With {.Success = Saved, .Message = ErrorMessage})
        End Function

#End Region

    End Class

End Namespace



