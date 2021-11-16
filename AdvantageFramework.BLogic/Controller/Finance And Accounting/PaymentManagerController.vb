Namespace Controller.FinanceAndAccounting

    Public Class PaymentManagerController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

        Public Shared ReadOnly Property APCDPInfoSQLStatement As String = "SELECT 
	                                                                            TOP 1 LEFT(CL_CODE + SPACE(6),6) + LEFT(DIV_CODE + SPACE(6),6) + LEFT(PRD_CODE + SPACE(6),6)
                                                                            FROM 
	                                                                            (SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'I' 'SRC' 
	                                                                             FROM AP_INTERNET A JOIN INTERNET_HEADER B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'N' 'SRC' 
	                                                                             FROM AP_NEWSPAPER A JOIN NEWSPAPER_HEADER B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'M' 'SRC' 
	                                                                             FROM AP_MAGAZINE A JOIN MAGAZINE_HEADER B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'O' 'SRC' 
	                                                                             FROM AP_OUTDOOR A JOIN OUTDOOR_HEADER B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'R' 'SRC' 
	                                                                             FROM AP_RADIO A JOIN RADIO_HDR B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'T' 'SRC' 
	                                                                             FROM AP_TV A JOIN TV_HDR B ON A.ORDER_NBR = B.ORDER_NBR WHERE AP_ID = {0}
	                                                                             UNION
	                                                                             SELECT A.CREATE_DATE, B.CL_CODE, B.DIV_CODE, B.PRD_CODE, 'P' 'SRC' 
	                                                                             FROM AP_PRODUCTION A JOIN JOB_LOG B ON A.JOB_NUMBER = B.JOB_NUMBER WHERE AP_ID = {0} AND MODIFY_DELETE IS NULL
	                                                                            ) A
                                                                            ORDER BY CREATE_DATE"
        Public Shared ReadOnly Property APCheckInfoSQLStatement As String = "SELECT 
	                                                                            APCheckNumber = AP_PMT_HIST.AP_CHK_NBR,   
                                                                                APCheckDate = AP_PMT_HIST.AP_CHK_DATE,   
                                                                                APCheckAmount = AP_PMT_HIST.AP_CHK_AMT,   
                                                                                APDiscountAmount = COALESCE(AP_PMT_HIST.AP_DISC_AMT, 0.00),   
	                                                                            APGLTransaction = COALESCE(AP_PMT_HIST.GLEXACT, 0),
                                                                                PayToVendorCode = COALESCE(CHECK_REGISTER.PAY_TO_CODE, ''),   
                                                                                EmailDate = CHECK_REGISTER.EMAIL_DATE,   
                                                                                ExportDate = CHECK_REGISTER.EXPORT_DATE,   
                                                                                EFileDate = CHECK_REGISTER.EFILE_DATE,   
                                                                                APInvoiceNumber = AP_HEADER.AP_INV_VCHR,   
                                                                                APInvoiceDate = AP_HEADER.AP_INV_DATE,   
                                                                                APInvoiceAmount = AP_HEADER.AP_INV_AMT,   
	                                                                            APGrossAmount = COALESCE(AP_HEADER.AP_INV_AMT, 0.00) + COALESCE(AP_HEADER.AP_SHIPPING, 0.00) + COALESCE(AP_HEADER.AP_SALES_TAX, 0.00),
	                                                                            APPaidDate = AP_HEADER.AP_DATE_PAY,
                                                                                VendorName = COALESCE(VENDOR.VN_NAME, ''),   
                                                                                VendorFaxNumber = COALESCE(VENDOR.VN_FAX_NUMBER, ''),   
                                                                                VendorEmail = COALESCE(VENDOR.VN_EMAIL, ''),   
                                                                                CheckAmount = CHECK_REGISTER.CHECK_AMT,   
                                                                                DiscountAmount = CHECK_REGISTER.DISC_AMT,   
                                                                                PostPeriodCode = CHECK_REGISTER.POST_PERIOD,
	                                                                            CheckRunID = CHECK_REGISTER.CHECK_RUN_ID,
	                                                                            BankCode = CHECK_REGISTER.BK_CODE,
	                                                                            APInvoiceDescription = AP_HEADER.AP_DESC,
	                                                                            VendorPaymentManagerEmailAddress = COALESCE(VENDOR.PYMT_MGR_EMAIL, ''),
	                                                                            APID = AP_HEADER.AP_ID, 
	                                                                            CheckNumber = CHECK_REGISTER.CHECK_NBR
                                                                            FROM 
	                                                                            CHECK_REGISTER,   
                                                                                AP_PMT_HIST,   
                                                                                AP_HEADER,   
                                                                                VENDOR  
                                                                            WHERE 
	                                                                            (CHECK_REGISTER.BK_CODE = AP_PMT_HIST.BK_CODE) AND  
                                                                                (CHECK_REGISTER.CHECK_NBR = AP_PMT_HIST.AP_CHK_NBR) AND  
                                                                                (CHECK_REGISTER.PAY_TO_CODE = VENDOR.VN_CODE) AND  
                                                                                (AP_HEADER.AP_ID = AP_PMT_HIST.AP_ID) AND  
                                                                                (AP_HEADER.AP_SEQ = AP_PMT_HIST.AP_SEQ) AND  
                                                                                (CHECK_REGISTER.CHECK_RUN_ID = '{1}') AND  
                                                                                (CHECK_REGISTER.VOID_FLAG = 0 OR CHECK_REGISTER.VOID_FLAG IS NULL) AND  
                                                                                (CHECK_REGISTER.BK_CODE = '{0}')  
                                                                            ORDER BY 
	                                                                            CHECK_REGISTER.PAY_TO_CODE ASC, 
	                                                                            AP_PMT_HIST.AP_CHK_NBR ASC"


#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

#Region " Public "

        Public Function Load(BankCode As String, CheckRunID As String) As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel

            Dim ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel = Nothing

            ViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel

            ViewModel.BankCode = BankCode
            ViewModel.CheckRunID = CheckRunID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Try

                    ViewModel.Bank = DbContext.Banks.Find(BankCode)

                Catch ex As Exception
                    ViewModel.Bank = Nothing
                End Try

                Try

                    ViewModel.AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                Catch ex As Exception
                    ViewModel.AgencyImportPath = String.Empty
                End Try

            End Using

            Load = ViewModel

        End Function
        Public Function ProcessExportFile(ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel, ByRef ErrorMessage As String) As Boolean

            Dim ProcessedExportFile As Boolean = False
            Dim PaymentManagerReports As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport) = Nothing

            Try

                Select Case ViewModel.Bank.PaymentManagerType

                    Case "FAST", "ANCH"

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Try

                                PaymentManagerReports = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport)(String.Format(AdvantageFramework.Controller.FinanceAndAccounting.PaymentManagerController.APCheckInfoSQLStatement, ViewModel.BankCode, ViewModel.CheckRunID)).ToList

                            Catch ex As Exception
                                PaymentManagerReports = Nothing
                            End Try

                        End Using

                    Case Else


                End Select

                Select Case ViewModel.Bank.PaymentManagerType

                    Case "ABT"
                    Case "ACHG"
                    Case "ACHR"
                    Case "ACOM"
                    Case "ADPE"
                    Case "AMEX"
                    Case "ANCH", "FAST"

                        ProcessedExportFile = ProcessFASTExportFile(ViewModel, PaymentManagerReports, ErrorMessage)

                    Case "AOC"
                    Case "ARP"
                    Case "BNZ"
                    Case "BOAC"
                    Case "BOAP"
                    Case "BOAR"
                    Case "CHA2"
                    Case "CHAS"
                    Case "CIBC"
                    Case "CITD"
                    Case "COMD"
                    Case "CPA"
                    Case "CSI"
                    Case "CSI2"
                    Case "CSI3"
                    Case "EPP"
                    Case "EXAP"

                    Case "HSBC"
                    Case "KEY"
                    Case "MINI"
                    Case "NVP"
                    Case "PAC"
                    Case "PAC2"
                    Case "PMX"
                    Case "PNC"
                    Case "PPE"
                    Case "PPS"
                    Case "REG"
                    Case "SBPP"
                    Case "TCHK"
                    Case "USB"
                    Case "USB2"
                    Case "WFB"
                    Case "WFBF"
                    Case "WFBP"
                    Case "WFPV"
                    Case "WTB"

                    Case Else

                        ErrorMessage = "No Export Type selected in Bank Maintenance"

                        ProcessedExportFile = False

                End Select

            Catch ex As Exception

            End Try

            ProcessExportFile = ProcessedExportFile

        End Function
        Public Function TransmitExportFile(ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel, ByRef ErrorMessage As String) As Boolean

            Dim ExportFileUploaded As Boolean = False
            Dim IsFTPValidationSuccessful As Boolean = False
            Dim BankExportFile As String

            Try

                If ViewModel.Bank.PaymentManagerFTPSSL Then

                    If ViewModel.Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                        IsFTPValidationSuccessful = AdvantageFramework.FTP.SSHFTPValidation(ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort, ViewModel.Bank.PaymentManagerFTPUsername,
                                                                                            ViewModel.Bank.PaymentManagerFTPPrivateKey, "", ErrorMessage)

                    Else

                        IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(ViewModel.Bank.PaymentManagerFTPSSL, ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort,
                                                                                         ViewModel.Bank.PaymentManagerFTPUsername, ViewModel.Bank.PaymentManagerFTPPassword, ViewModel.Bank.PaymentManagerFTPSSLMode, ErrorMessage)

                    End If

                Else

                    IsFTPValidationSuccessful = AdvantageFramework.FTP.FTPValidation(ViewModel.Bank.PaymentManagerFTPSSL, ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort,
                                                                                     ViewModel.Bank.PaymentManagerFTPUsername, ViewModel.Bank.PaymentManagerFTPPassword, ViewModel.Bank.PaymentManagerFTPSSLMode, ErrorMessage)

                End If

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    If IsFTPValidationSuccessful Then

                        BankExportFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ViewModel.Bank.PaymentManagerFTPExportFolder, "\") &
                                        ViewModel.BankExportFile

                        If ViewModel.Bank.PaymentManagerFTPSSL Then

                            If ViewModel.Bank.PaymentManagerFTPPrivateKey IsNot Nothing Then

                                ExportFileUploaded = AdvantageFramework.FTP.UploadToSSHFTP(ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort, ViewModel.Bank.PaymentManagerFTPUsername,
                                                                                           ViewModel.Bank.PaymentManagerFTPPrivateKey, "", ViewModel.Bank.PaymentManagerFTPFolder, BankExportFile, ErrorMessage)

                            Else

                                ExportFileUploaded = AdvantageFramework.FTP.UploadToFTP(ViewModel.Bank.PaymentManagerFTPSSL, ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort, ViewModel.Bank.PaymentManagerFTPFolder,
                                                                                        ViewModel.Bank.PaymentManagerFTPUsername, ViewModel.Bank.PaymentManagerFTPPassword, ViewModel.Bank.PaymentManagerFTPSSLMode, BankExportFile, ErrorMessage)

                            End If

                        Else

                            ExportFileUploaded = AdvantageFramework.FTP.UploadToFTP(ViewModel.Bank.PaymentManagerFTPSSL, ViewModel.Bank.PaymentManagerFTPAddress, ViewModel.Bank.PaymentManagerFTPPort, ViewModel.Bank.PaymentManagerFTPFolder,
                                                                                    ViewModel.Bank.PaymentManagerFTPUsername, ViewModel.Bank.PaymentManagerFTPPassword, ViewModel.Bank.PaymentManagerFTPSSLMode, BankExportFile, ErrorMessage)

                        End If

                    End If

                Else

                    ErrorMessage = "Failed creating export file." & System.Environment.NewLine & System.Environment.NewLine & (ErrorMessage)

                End If

            Catch ex As Exception
                ErrorMessage = "Failed creating export file." & System.Environment.NewLine & System.Environment.NewLine & (ex.Message) 'AdvantageFramework.ClassUtilities.GetAllExceptionMessages(ex)
            End Try

            TransmitExportFile = ExportFileUploaded

        End Function
        Private Function ProcessFASTExportFile(ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.PaymentManagerViewModel,
                                               PaymentManagerReports As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport),
                                               ByRef ErrorMessage As String) As Boolean

            Dim ProcessedExportFile As Boolean = False
            Dim ExportDirectory As String = String.Empty
            Dim ExportFile As String = String.Empty
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim VendorCodes As Generic.List(Of String) = Nothing
            Dim ProcessingErrorMessage As String = String.Empty
            Dim PaymentManagerNumber As String = String.Empty
            Dim CDPCode As String = String.Empty
            Dim VendorPaymentManagerReports As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport) = Nothing
            Dim VendorInvoiceTotal As Decimal = 0
            Dim LineTotal As Integer = 0
            Dim InvoiceTotal As Decimal = 0
            Dim RunDate As Date = Now

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    StringBuilder = New System.Text.StringBuilder()

                    Try

                        PaymentManagerNumber = AdvantageFramework.Database.Procedures.AssignNumber.GetNextNumber(DbContext, "PYMT_MGR_NBR").ToString

                    Catch ex As Exception

                        PaymentManagerNumber = "-1"

                        ProcessingErrorMessage = (ex.Message) 'AdvantageFramework.ClassUtilities.GetAllExceptionMessages(ex)

                    End Try

                    If PaymentManagerNumber = "-1" Then

                        Throw New Exception(ProcessingErrorMessage)

                    End If

                    If String.IsNullOrWhiteSpace(ViewModel.Bank.PaymentManagerID) OrElse String.IsNullOrWhiteSpace(ViewModel.Bank.PaymentManagerDirectory) Then

                        Throw New Exception("Unable to obtain Payment Manager data for bank code " & ViewModel.Bank.Code & ".")

                    End If

                    If IsNumeric(ViewModel.Bank.PaymentManagerID) = False OrElse ViewModel.Bank.PaymentManagerID.Length > 7 Then

                        Throw New Exception("The Bank Customer ID must be numeric with no more than 7 digits. Please correct and try again.")

                    End If

                    If My.Computer.FileSystem.DirectoryExists(ViewModel.Bank.PaymentManagerDirectory) = False Then

                        Throw New Exception("The File Output Directory (" & ViewModel.Bank.PaymentManagerDirectory & ") for bank code '" & ViewModel.Bank.Code & "' does not exist.")

                    End If

                    ExportDirectory = ViewModel.Bank.PaymentManagerDirectory

                    If Right(ExportDirectory, 1) <> "\" Then
                        ExportDirectory += "\"
                    End If

                    ExportFile = ViewModel.Bank.PaymentManagerType & "_" & PaymentManagerNumber & "_" & Now.ToString("HHmmss") & Now.ToString("MMddyyyy")

                    If ViewModel.Bank.PaymentManagerType = "FAST" Then

                        ExportFile &= ".txt"

                    End If

                    'File header line
                    StringBuilder.Append("FH")
                    StringBuilder.Append("0001")
                    StringBuilder.Append("6472")
                    StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(ViewModel.Bank.PaymentManagerID, 7, "0", True, True))
                    StringBuilder.Append(RunDate.ToString("MMddyyyy"))
                    StringBuilder.Append(RunDate.ToString("HHmmss"))
                    StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(PaymentManagerNumber, 6, "0", True, True))
                    StringBuilder.Append("0003")

                    StringBuilder.AppendLine()
                    LineTotal += 1

                    Try

                        VendorCodes = PaymentManagerReports.Select(Function(Entity) Entity.PayToVendorCode).Distinct.ToList

                    Catch ex As Exception
                        VendorCodes = New Generic.List(Of String)
                    End Try

                    For Each VendorCode In VendorCodes

                        StringBuilder.Append("MH")
                        StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(VendorCode, 50, " ", False, True))
                        StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 30, " ", False, True))
                        StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 500, " ", False, True))

                        StringBuilder.AppendLine()
                        LineTotal += 1

                        Try

                            VendorPaymentManagerReports = PaymentManagerReports.Where(Function(Entity) Entity.PayToVendorCode = VendorCode).ToList

                        Catch ex As Exception
                            VendorPaymentManagerReports = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.PaymentManagerReport)
                        End Try

                        For Each PaymentManagerReport In VendorPaymentManagerReports

                            StringBuilder.Append("IR")
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(PaymentManagerReport.APInvoiceNumber, 50, " ", False, True))
                            StringBuilder.Append(PaymentManagerReport.APInvoiceDate.ToString("MMddyyyy"))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(PaymentManagerReport.APCheckNumber, 50, " ", False, True))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(PaymentManagerReport.APCheckNumber, 50, " ", False, True))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(PaymentManagerReport.APCheckAmount.Value.ToString("###.00").Replace("-", "").Replace(".", ""), 14, "0", True, True))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 10, " ", False, True))

                            If PaymentManagerReport.APCheckAmount.GetValueOrDefault(0) > 0 Then

                                StringBuilder.Append("D")

                            Else

                                StringBuilder.Append("C")

                            End If

                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 8, " ", False, True))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 500, " ", False, True))
                            StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter("", 500, " ", False, True))

                            Try

                                CDPCode = DbContext.Database.SqlQuery(Of String)(String.Format(APCDPInfoSQLStatement, PaymentManagerReport.APID)).FirstOrDefault

                            Catch ex As Exception
                                CDPCode = String.Empty
                            End Try

                            StringBuilder.Append(CDPCode)

                            StringBuilder.AppendLine()
                            LineTotal += 1

                        Next

                        StringBuilder.Append("MT")
                        StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(VendorPaymentManagerReports.Count, 6, "0", True, True))

                        Try

                            VendorInvoiceTotal = VendorPaymentManagerReports.Sum(Function(Entity) Entity.APCheckAmount.Value)

                        Catch ex As Exception
                            VendorInvoiceTotal = 0
                        End Try

                        StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(VendorInvoiceTotal.ToString("###.00").Replace("-", "").Replace(".", ""), 14, "0", True, True))

                        If VendorInvoiceTotal > 0 Then

                            StringBuilder.Append("D")

                        Else

                            StringBuilder.Append("C")

                        End If

                        StringBuilder.AppendLine()
                        LineTotal += 1

                    Next

                    'File trailer line
                    StringBuilder.Append("TR")
                    StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(LineTotal + 1, 6, "0", True, True))

                    Try

                        InvoiceTotal = PaymentManagerReports.Sum(Function(Entity) Entity.APCheckAmount.Value)

                    Catch ex As Exception
                        InvoiceTotal = 0
                    End Try

                    StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(InvoiceTotal.ToString("###.00").Replace("-", "").Replace(".", ""), 14, "0", True, True))

                    If InvoiceTotal > 0 Then

                        StringBuilder.Append("D")

                    Else

                        StringBuilder.Append("C")

                    End If

                    StringBuilder.Append(AdvantageFramework.StringUtilities.PadWithCharacter(VendorCodes.Count, 6, "0", True, True))

                    StringBuilder.AppendLine()

                    My.Computer.FileSystem.WriteAllText(ExportDirectory + ExportFile, StringBuilder.ToString, False)

                    ViewModel.BankExportFile = ExportFile

                    ProcessedExportFile = True

                End Using

            Catch ex As Exception

                ProcessedExportFile = False

                ErrorMessage = "Failed creating export file." & System.Environment.NewLine & System.Environment.NewLine & (ex.Message) 'AdvantageFramework.ClassUtilities.GetAllExceptionMessages(ex)

                'If ex.InnerException IsNot Nothing Then

                '    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                '    If ex.InnerException.InnerException IsNot Nothing Then

                '        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                '    End If

                'End If

            End Try

            ProcessFASTExportFile = ProcessedExportFile

        End Function

#End Region

#End Region

    End Class

End Namespace
