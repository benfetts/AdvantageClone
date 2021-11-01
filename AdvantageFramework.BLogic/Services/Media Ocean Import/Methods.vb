Namespace Services.MediaOceanImport

    <HideModuleName()> _
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "

        '#If DEBUG Then
        '        Private Const _22SQUARED = "main"
        '#Else
        Private Const _22SQUARED = "22s"
        '#End If

#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "RunAt", "01/01/2001 01:00 AM")>
            RunAt
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "FTPAddress", "")>
            FTPAddress
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "FTPUser", "")>
            FTPUser
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "FTPPassword", "")>
            FTPPassword
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "LocalFolder", "")>
            LocalFolder
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "EmployeeCode", "")>
            EmployeeCode
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Media Ocean Import\", "ImportType", "")>
            ImportType
        End Enum

        Public Enum CustomCommand As Integer
            LoadSettings = 128
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing
        Private _SelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Function GeneralLedgerDetailInBalance(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Transaction As Integer) As Boolean

            Dim Total As Double = -1

            If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.GLENTTRL (NOLOCK) WHERE GLETXACT={0}", Transaction)).FirstOrDefault = 0 Then

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.GLENTHDR WHERE GLEHXACT={0}", Transaction))

                Return True

            Else

                Total = DbContext.Database.SqlQuery(Of Double)(String.Format("SELECT ROUND(SUM(GLETAMT), 2) FROM dbo.GLENTTRL (NOLOCK) WHERE GLETXACT={0}", Transaction)).FirstOrDefault

                If Total = 0 Then

                    Return True

                Else

                    Return False

                End If

            End If

        End Function
        Private Sub InsertClientCrossReference(ByVal SourceClientCode As String, ByVal SourceProductCode As String)

            Using DbContext As New AdvantageFramework.Database.DbContext(_SelectedDatabaseProfile.ConnectionString, _SelectedDatabaseProfile.DatabaseUserName)

                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.CLIENT_XREF (SOURCE_CL_CODE, SOURCE_PRD_CODE, RECORD_SOURCE_ID) VALUES ('{0}', '{1}', {2})", SourceClientCode, SourceProductCode, CInt(AdvantageFramework.Database.Entities.SystemRecordSources.MediaOcean)))

            End Using

        End Sub
        Private Sub InsertGeneralLedgerCrossReference(ByVal GeneralLedgerSourceCode As String)

            Using DbContext As New AdvantageFramework.Database.DbContext(_SelectedDatabaseProfile.ConnectionString, _SelectedDatabaseProfile.DatabaseUserName)

                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT dbo.GLACCOUNT_XREF (SOURCE_GLACODE, RECORD_SOURCE_ID) VALUES ('{0}', {1})", GeneralLedgerSourceCode, CInt(AdvantageFramework.Database.Entities.SystemRecordSources.MediaOcean)))

            End Using

        End Sub
        Private Function InsertGeneralLedger(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SourcePostPeriod As String,
                                             ByVal VRorCR As String, ByVal UserCode As String) As Integer

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing

            GeneralLedger = New AdvantageFramework.Database.Entities.GeneralLedger

            GeneralLedger.EnteredDate = Now.ToShortDateString
            GeneralLedger.ModifiedDate = Now.ToShortDateString
            GeneralLedger.PostPeriodCode = SourcePostPeriod
            GeneralLedger.UserCode = UserCode
            GeneralLedger.Description = "Media Ocean " & VRorCR & " detail, " & Now.ToShortDateString
            GeneralLedger.GLSourceCode = "IJ"
            GeneralLedger.CreateDate = Now

            If AdvantageFramework.Database.Procedures.GeneralLedger.Insert(DbContext, GeneralLedger) = False Then

                WriteToEventLog("Media Ocean Import failed to insert in GLENTHDR table.")

                Throw New Exception("Media Ocean Import failed to insert in GLENTHDR table.")

            End If

            InsertGeneralLedger = GeneralLedger.Transaction

        End Function
        Private Function IsPostPeriodValid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodCode As String, ARorGL As String) As Boolean

            Dim IsValid As Boolean = True
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, PostPeriodCode)

            If PostPeriod Is Nothing OrElse
                (ARorGL = "AR" AndAlso PostPeriod.ARStatus = "X") OrElse
                (ARorGL = "GL" AndAlso PostPeriod.GLStatus = "X") Then

                IsValid = False

            End If

            IsPostPeriodValid = IsValid

        End Function
        Private Sub ProcessFile(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal LocalFolder As String, ByVal Filename As String, ByVal UserCode As String,
                                ByVal FTPAddress As String, ByVal FTPUser As String, ByVal FTPPassword As String, ByVal EmployeeCode As String, ByVal BatchName As String,
                                ByVal FTPPort As Integer)

            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim TextLine As String = Nothing
            Dim CurrentSection As String = Nothing
            Dim InvoiceNumber As String = Nothing
            Dim InvoiceAmount As Decimal = 0
            Dim SJInvoiceAmounts As Collection = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim PostPeriodCode As String = Nothing
            Dim CurrentGeneralLedgerTransaction As Integer = -1

            _SelectedDatabaseProfile = DatabaseProfile

            If System.IO.File.Exists(LocalFolder & Filename) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Try

                            StreamReader = New System.IO.StreamReader(LocalFolder & Filename)

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            Do While StreamReader.Peek() <> -1

                                TextLine = StreamReader.ReadLine()

                                Select Case TextLine.Substring(7, 3).Trim

                                    Case "SJ"

                                        CurrentSection = "SJ"
                                        PostPeriodCode = "20" & TextLine.Substring(23, 4)

                                        If Not IsPostPeriodValid(DbContext, PostPeriodCode, "AR") Then

                                            AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(DatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.AccountsReceivablePostPeriodClosedOrNotSetup, "Post Period: " & PostPeriodCode & " does not exist or AR is closed.")
                                            Throw New Exception("Post Period: " & PostPeriodCode & " does not exist or AR is closed.")

                                        End If

                                    Case "SJM"

                                        CurrentSection = "SJM"
                                        PostPeriodCode = "20" & TextLine.Substring(23, 4)

                                        If Not IsPostPeriodValid(DbContext, PostPeriodCode, "AR") Then

                                            AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(DatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.AccountsReceivablePostPeriodClosedOrNotSetup, "Post Period: " & PostPeriodCode & " does not exist or AR is closed.")
                                            Throw New Exception("Post Period: " & PostPeriodCode & " does not exist or AR is closed.")

                                        End If

                                    Case "VR"

                                        CurrentSection = "VR"
                                        PostPeriodCode = "20" & TextLine.Substring(23, 4)

                                        If Not IsPostPeriodValid(DbContext, PostPeriodCode, "GL") Then

                                            AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(DatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.GeneralLedgerPostPeriodClosedOrNotSetup, "Post Period: " & PostPeriodCode & " does not exist or GL is closed.")
                                            Throw New Exception("Post Period: " & PostPeriodCode & " does not exist or GL is closed.")

                                        End If

                                        If CurrentGeneralLedgerTransaction = -1 Then

                                            CurrentGeneralLedgerTransaction = InsertGeneralLedger(DbContext, PostPeriodCode, CurrentSection, UserCode)

                                        ElseIf GeneralLedgerDetailInBalance(DbContext, CurrentGeneralLedgerTransaction) = False Then

                                            WriteToEventLog("Journal Entries out of balance for file: " & Filename & ".")

                                            Throw New Exception("Journal Entries out of balance for file: " & Filename & ".")

                                        Else

                                            CurrentGeneralLedgerTransaction = InsertGeneralLedger(DbContext, PostPeriodCode, CurrentSection, UserCode)

                                        End If

                                    Case "CD"

                                        CurrentSection = "CD"
                                        PostPeriodCode = "20" & TextLine.Substring(23, 4)

                                        If Not IsPostPeriodValid(DbContext, PostPeriodCode, "GL") Then

                                            AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(DatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.GeneralLedgerPostPeriodClosedOrNotSetup, "Post Period: " & PostPeriodCode & " does not exist or GL is closed.")
                                            Throw New Exception("Post Period: " & PostPeriodCode & " does not exist or GL is closed.")

                                        End If

                                        If CurrentGeneralLedgerTransaction = -1 Then

                                            CurrentGeneralLedgerTransaction = InsertGeneralLedger(DbContext, PostPeriodCode, CurrentSection, UserCode)

                                        ElseIf GeneralLedgerDetailInBalance(DbContext, CurrentGeneralLedgerTransaction) = False Then

                                            WriteToEventLog("Journal Entries out of balance for file: " & Filename & ".")

                                            Throw New Exception("Journal Entries out of balance for file: " & Filename & ".")

                                        Else

                                            CurrentGeneralLedgerTransaction = InsertGeneralLedger(DbContext, PostPeriodCode, CurrentSection, UserCode)

                                        End If

                                    Case Else

                                        If CurrentSection = "SJ" Then

                                            InvoiceNumber = TextLine.Substring(58, 16).Trim

                                            If InvoiceNumber <> "" Then

                                                If SJInvoiceAmounts Is Nothing Then

                                                    SJInvoiceAmounts = New Collection

                                                End If

                                                InvoiceAmount = TextLine.Substring(95, 14).Trim

                                                If TextLine.Substring(109, 1) = "-" Then

                                                    SJInvoiceAmounts.Add(-InvoiceAmount, InvoiceNumber)

                                                Else

                                                    SJInvoiceAmounts.Add(InvoiceAmount, InvoiceNumber)

                                                End If

                                            End If

                                        ElseIf CurrentSection = "SJM" Then

                                            If TextLine.Chars(4) = "-" AndAlso TextLine.Chars(7) = "-" Then

                                                ProcessSJM(DbContext, Filename, TextLine, SJInvoiceAmounts, SecurityDbContext, EmployeeCode, BatchName)

                                            End If

                                        ElseIf CurrentSection = "VR" Then

                                            If TextLine.Chars(4) = "-" AndAlso TextLine.Chars(7) = "-" Then

                                                ProcessVRorCD(DbContext, TextLine, CurrentSection, SecurityDbContext, EmployeeCode, CurrentGeneralLedgerTransaction, Filename)

                                            End If

                                        ElseIf CurrentSection = "CD" Then

                                            If TextLine.Chars(4) = "-" AndAlso TextLine.Chars(7) = "-" Then

                                                ProcessVRorCD(DbContext, TextLine, CurrentSection, SecurityDbContext, EmployeeCode, CurrentGeneralLedgerTransaction, Filename)

                                            End If

                                        End If

                                End Select

                            Loop

                            StreamReader.Close()

                            If CurrentGeneralLedgerTransaction <> -1 Then

                                If GeneralLedgerDetailInBalance(DbContext, CurrentGeneralLedgerTransaction) = False Then

                                    WriteToEventLog("Journal Entries out of balance for file: " & Filename & ".")

                                    Throw New Exception("Journal Entries out of balance for file: " & Filename & ".")

                                End If

                            End If

                            If Mid(FTPAddress, 1, 4).ToUpper = "FTP:" Then

                                If Not AdvantageFramework.FTP.RenameFileOnServer(FTPAddress, FTPUser, FTPPassword, False, Filename, Filename.Replace(".txt", ".old")) Then

                                    Throw New Exception("Failed to rename file '" & Filename & "' on FTP.")

                                End If

                            Else

                                If Not AdvantageFramework.FTP.RenameFileOnSFTPServer(FTPAddress, FTPPort, FTPUser, FTPPassword, Filename, Filename.Replace(".txt", ".old")) Then

                                    Throw New Exception("Failed to rename file '" & Filename & "' on FTP.")

                                End If

                            End If

                            Try

                                System.IO.File.Move(LocalFolder & Filename, LocalFolder & Filename.Replace(".txt", ".old"))

                                DbTransaction.Commit()

                            Catch ex As Exception
                                Throw ex
                            End Try

                        Catch ex As Exception

                            WriteToEventLog("Media Ocean Import: ProcessFile: " & ex.Message)

                            DbTransaction.Rollback()

                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                            StreamReader.Close()

                        End Try

                    End Using

                End Using

            End If

        End Sub
        Private Sub ProcessSJM(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Filename As String, ByVal TextLine As String, ByVal SJInvoiceAmounts As Collection,
                               ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal EmployeeCode As String, ByVal BatchName As String)

            Dim AccountReceivableImportStaging As AdvantageFramework.Database.Entities.AccountReceivableImportStaging = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim InvoiceAmount As Decimal = 0
            Dim InvoiceNumber As String = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim MediaTypeField As String = Nothing
            Dim InvoiceDate As String = Nothing
            Dim ImportARInvoiceNumber As String = Nothing

            ClientCrossReference = AdvantageFramework.Database.Procedures.ClientCrossReference.LoadBySourceClientCodeAndSourceProductCodeAndRecordSourceID(DbContext, TextLine.Substring(25, 4), TextLine.Substring(30, 4), Database.Entities.SystemRecordSources.MediaOcean)

            If ClientCrossReference Is Nothing OrElse ClientCrossReference.ClientCode Is Nothing OrElse ClientCrossReference.ClientCode = "" OrElse
                ClientCrossReference.DivisionCode Is Nothing OrElse ClientCrossReference.DivisionCode = "" OrElse
                ClientCrossReference.ProductCode Is Nothing OrElse ClientCrossReference.ProductCode = "" Then

                If ClientCrossReference Is Nothing Then

                    InsertClientCrossReference(TextLine.Substring(25, 4), TextLine.Substring(30, 4))

                End If

                AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(_SelectedDatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.ClientMappingNotSetup, "Media Ocean Import cannot find associated Client/Division/Product in Advantage for Source Client/Product '" & TextLine.Substring(25, 4) & "/" & TextLine.Substring(30, 4) & "'.")

                WriteToEventLog("Media Ocean Import cannot find associated Client/Division/Product in Advantage for Source Client/Product '" & TextLine.Substring(25, 4) & "/" & TextLine.Substring(30, 4) & "'.")

                Throw New Exception("Media Ocean Import cannot find associated Client/Division/Product in Advantage.")

            Else

                InvoiceAmount = TextLine.Substring(95, 14)

                If InvoiceAmount <> 0 Then

                    AccountReceivableImportStaging = New AdvantageFramework.Database.Entities.AccountReceivableImportStaging

                    AccountReceivableImportStaging.BatchName = BatchName

                    If TextLine.Substring(109, 1) = "-" Then

                        AccountReceivableImportStaging.InvoiceAmount = -InvoiceAmount

                    Else

                        AccountReceivableImportStaging.InvoiceAmount = InvoiceAmount

                    End If

                    AccountReceivableImportStaging.SaleAmount = AccountReceivableImportStaging.InvoiceAmount

                    InvoiceNumber = TextLine.Substring(58, 16).Trim

                    If InvoiceNumber <> "" AndAlso SJInvoiceAmounts IsNot Nothing AndAlso SJInvoiceAmounts.Contains(InvoiceNumber) Then

                        AccountReceivableImportStaging.CostOfSalesAmount = AccountReceivableImportStaging.InvoiceAmount + SJInvoiceAmounts.Item(InvoiceNumber)
                        AccountReceivableImportStaging.OffsetAmount = AccountReceivableImportStaging.CostOfSalesAmount

                    Else

                        AccountReceivableImportStaging.CostOfSalesAmount = AccountReceivableImportStaging.InvoiceAmount
                        AccountReceivableImportStaging.OffsetAmount = AccountReceivableImportStaging.CostOfSalesAmount

                    End If

                    ImportARInvoiceNumber = TextLine.Substring(44, 30)

                    AccountReceivableImportStaging.ImportARInvoiceNumber = Mid(ImportARInvoiceNumber, 15, 6) & Space(1) & Mid(ImportARInvoiceNumber, 11, 4) & Space(1) & Mid(ImportARInvoiceNumber, 1, 5)
                    AccountReceivableImportStaging.AdvanARType = "IN"

                    AccountReceivableImportStaging.ClientCode = ClientCrossReference.ClientCode
                    AccountReceivableImportStaging.DivisionCode = ClientCrossReference.DivisionCode
                    AccountReceivableImportStaging.ProductCode = ClientCrossReference.ProductCode

                    AccountReceivableImportStaging.OfficeCode = _22SQUARED

                    If TextLine.Substring(111, 8).Trim <> "" Then

                        AccountReceivableImportStaging.InvoiceDate = Mid(TextLine.Substring(111, 8), 5, 2) & "/" & Mid(TextLine.Substring(111, 8), 7, 2) & "/" & Mid(TextLine.Substring(111, 8), 3, 2)

                    Else

                        InvoiceDate = Filename.Substring(9, 6)
                        InvoiceDate = InvoiceDate.Substring(2, 2) & "/" & InvoiceDate.Substring(4, 2) & "/" & InvoiceDate.Substring(0, 2)

                        AccountReceivableImportStaging.InvoiceDate = InvoiceDate

                    End If

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, _22SQUARED)

                    If Office IsNot Nothing Then

                        AccountReceivableImportStaging.GLACodeAR = Office.AccountsReceivableGLACode

                    Else

                        WriteToEventLog("Media Ocean Import failed to find office '" & _22SQUARED & "'.")

                        Throw New Exception("Cannot find Office '" & _22SQUARED & "'.")

                    End If

                    MediaTypeField = TextLine.Substring(54, 2)

                    OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, MediaTypeField, _22SQUARED)

                    If OfficeSalesClassAccount IsNot Nothing Then

                        AccountReceivableImportStaging.GLACodeSales = OfficeSalesClassAccount.MediaSalesGLACode
                        AccountReceivableImportStaging.GLACodeCOS = OfficeSalesClassAccount.MediaCostOfSalesGLACode

                        AccountReceivableImportStaging.GLACodeOffset = Office.MediaAccruedAccountsPayableGLACode

                        AccountReceivableImportStaging.SalesClassCode = MediaTypeField

                    Else

                        AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(_SelectedDatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.MissingSalesClassCode, "Media Ocean Import failed to find MediaType '" & MediaTypeField & "' in Office Sales Class Account table for office '" & _22SQUARED & "'.")

                        WriteToEventLog("Media Ocean Import failed to find MediaType '" & MediaTypeField & "' in Office Sales Class Account table for office '" & _22SQUARED & "'.")

                        Throw New Exception("Media Ocean Import failed to find MediaType '" & MediaTypeField & "' in Office Sales Class Account table for office '" & _22SQUARED & "'.")

                    End If

                    AccountReceivableImportStaging.RecordType = "M"

                    If AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Insert(DbContext, AccountReceivableImportStaging) = False Then

                        WriteToEventLog("Media Ocean Import failed to insert in IMP_ACCT_REC table.")

                        Throw New Exception("Media Ocean Import failed to insert in IMP_ACCT_REC table.")

                    End If

                End If

            End If

        End Sub
        Private Sub ProcessVRorCD(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TextLine As String, ByVal VRorCR As String,
                                  ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal EmployeeCode As String, ByVal GLTransaction As Integer, ByVal Filename As String)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing
            Dim TransactionAmount As Double = 0

            If GLTransaction = -1 Then

                WriteToEventLog("Failed to find " & VRorCR & " header record in file '" & Filename & "'.")

                Throw New Exception("Failed to find " & VRorCR & " header record in file '" & Filename & "'.")

            End If

            TransactionAmount = TextLine.Substring(95, 14)

            If TransactionAmount <> 0 Then

                TransactionAmount = CDbl(FormatNumber(TextLine.Substring(109, 1).Trim & TextLine.Substring(95, 14).Trim, 2))

                GeneralLedgerCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadBySourceGLACodeAndRecordSourceID(DbContext, TextLine.Substring(13, 5), Database.Entities.SystemRecordSources.MediaOcean)

                If GeneralLedgerCrossReference Is Nothing OrElse GeneralLedgerCrossReference.GLACode Is Nothing OrElse GeneralLedgerCrossReference.GLACode = "" Then

                    If GeneralLedgerCrossReference Is Nothing Then

                        InsertGeneralLedgerCrossReference(TextLine.Substring(13, 5))

                    End If

                    AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(_SelectedDatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.GeneralLedgerMappingNotSetup, "Media Ocean Import cannot find associated GLAccount in Advantage for Source Acct '" & TextLine.Substring(13, 5) & "'.")

                    WriteToEventLog("Media Ocean Import cannot find associated GLAccount in Advantage for Source Acct '" & TextLine.Substring(13, 5) & "'.")

                    Throw New Exception("Media Ocean Import cannot find associated GLAccount in Advantage.")

                Else

                    GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail

                    GeneralLedgerDetail.GLTransaction = GLTransaction
                    GeneralLedgerDetail.GLACode = GeneralLedgerCrossReference.GLACode
                    GeneralLedgerDetail.CreditAmount = TransactionAmount
                    GeneralLedgerDetail.DebitAmount = TransactionAmount
                    GeneralLedgerDetail.Remark = "Media Ocean " & VRorCR & " detail " & Now.ToShortDateString
                    GeneralLedgerDetail.GLSourceCode = "IJ"

                    If AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Insert(DbContext, GeneralLedgerDetail) = False Then

                        WriteToEventLog("Media Ocean Import failed to insert in GLENTTRL table.")

                        Throw New Exception("Media Ocean Import failed to insert in GLENTTRL table.")

                    End If

                End If

            End If

        End Sub
        Private Sub ProcessDefaultImportType(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                             FTPAddress As String, FTPUser As String, FTPPassword As String, LocalFolder As String, EmployeeCode As String)

            Dim FTPPort As Integer = 22
            Dim ImportFilesList As Generic.List(Of String) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim ErrorMessage As String = Nothing
            Dim BatchName As String = Nothing
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SftpItemCollection As Rebex.Net.SftpItemCollection = Nothing

            If LocalFolder.EndsWith("\") = False Then

                LocalFolder = LocalFolder & "\"

            End If

            WriteToEventLog("Validating Employee/User...")

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee Is Nothing OrElse Employee.TerminationDate IsNot Nothing OrElse Employee.Email Is Nothing OrElse Employee.Email = "" Then

                Throw New Exception("Employee does not exist, or has been terminated or does not have email address.  EmployeeCode (" & EmployeeCode & ")")

            End If

            User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, EmployeeCode)

            If User Is Nothing Then

                Throw New Exception("User does not exist for EmployeeCode: " & EmployeeCode)

            End If

            BatchName = "MediaOcean_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

            WriteToEventLog("Checking FTP for list of files...")

            If Mid(FTPAddress, 1, 4).ToUpper = "FTP:" Then

                If AdvantageFramework.FTP.ValidateFTP(FTPAddress, FTPUser, FTPPassword, False, ErrorMessage) = False Then

                    AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(_SelectedDatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.CannotConnectToFTP, ErrorMessage)
                    Throw New Exception("Cannot Connect to FTP: " & ErrorMessage)

                End If

                ImportFilesList = AdvantageFramework.FTP.GetFilesInDirectory(FTPAddress, FTPUser, FTPPassword, False)

                For Each FileName In ImportFilesList

                    If FileName.ToUpper.StartsWith("EDETRANS") AndAlso FileName.ToUpper.EndsWith(".TXT") Then

                        If System.IO.File.Exists(LocalFolder & FileName) = True Then

                            WriteToEventLog("Processing file (" & FileName & ") ...")

                            ProcessFile(DatabaseProfile, LocalFolder, FileName, User.UserCode, FTPAddress, FTPUser, FTPPassword, EmployeeCode, BatchName, 0)

                        Else

                            WriteToEventLog("Downloading file (" & FileName & ") to " & LocalFolder & "...")

                            If AdvantageFramework.FTP.DownloadFile(FTPAddress, FTPUser, FTPPassword, False, FileName, LocalFolder & FileName) Then

                                WriteToEventLog("Processing file (" & FileName & ") ...")

                                ProcessFile(DatabaseProfile, LocalFolder, FileName, User.UserCode, FTPAddress, FTPUser, FTPPassword, EmployeeCode, BatchName, 0)

                            End If

                        End If

                    End If

                Next

            Else

                FTPAddress = Replace(FTPAddress.ToUpper, "SFTP://", "")

                Try

                    SFTP = New Rebex.Net.Sftp

                    SFTP.Timeout = 30000

                    SFTP.Connect(FTPAddress, FTPPort)

                    If SFTP.IsConnected Then

                        SFTP.Login(FTPUser, FTPPassword)

                    End If

                Catch ex As Exception

                    If SFTP IsNot Nothing Then

                        SFTP.Dispose()

                    End If

                    SFTP = Nothing

                End Try

                If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                    Try

                        SftpItemCollection = SFTP.GetList()

                        For Each RebexItem In SftpItemCollection

                            If RebexItem.IsFile Then

                                If RebexItem.Name.ToUpper.StartsWith("EDETRANS") AndAlso RebexItem.Name.ToUpper.EndsWith(".TXT") Then

                                    If System.IO.File.Exists(LocalFolder & RebexItem.Name) = True Then

                                        WriteToEventLog("Processing file (" & RebexItem.Name & ") ...")

                                        ProcessFile(DatabaseProfile, LocalFolder, RebexItem.Name, User.UserCode, FTPAddress, FTPUser, FTPPassword, EmployeeCode, BatchName, FTPPort)

                                    Else

                                        WriteToEventLog("Downloading file (" & RebexItem.Name & ") to " & LocalFolder & "...")

                                        SFTP.Download(RebexItem.Path, LocalFolder)

                                        WriteToEventLog("Processing file (" & RebexItem.Name & ") ...")

                                        ProcessFile(DatabaseProfile, LocalFolder, RebexItem.Name, User.UserCode, FTPAddress, FTPUser, FTPPassword, EmployeeCode, BatchName, FTPPort)

                                    End If

                                End If

                            End If

                        Next

                    Catch ex As Exception
                        Throw New Exception("Problem downloading files from SFTP: " & ex.Message)
                    End Try

                Else

                    AdvantageFramework.AlertSystem.CreateAlertForMediaOceanValidationIssue(_SelectedDatabaseProfile, SecurityDbContext, EmployeeCode, AlertSystem.ImportValidationFailureType.CannotConnectToFTP, ErrorMessage)
                    Throw New Exception("Cannot Connect to FTP: " & ErrorMessage)

                End If

            End If

        End Sub
        Public Sub ProcessDatabase(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim FTPAddress As String = Nothing
            Dim FTPUser As String = Nothing
            Dim FTPPassword As String = Nothing
            Dim LocalFolder As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim ImportType As Short = 0

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Media Ocean Import connecting to database --> " & DatabaseProfile.DatabaseName)

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                                WriteToEventLog("Media Ocean Import load service settings --> " & DatabaseProfile.DatabaseName)

                                AdvantageFramework.Services.MediaOceanImport.LoadServiceSettings(DataContext, FTPAddress, FTPUser, FTPPassword, LocalFolder, EmployeeCode, ImportType)

                                If System.IO.Directory.Exists(LocalFolder) Then

                                    If ImportType = 1 Then

                                        ProcessDefaultImportType(DbContext, SecurityDbContext, DatabaseProfile, FTPAddress, FTPUser, FTPPassword, LocalFolder, EmployeeCode)

                                    ElseIf ImportType = 2 Then

                                        ProcessGLIFaceImportType(DbContext, SecurityDbContext, DatabaseProfile, FTPAddress, FTPUser, FTPPassword, LocalFolder, EmployeeCode)

                                    End If

                                Else

                                    WriteToEventLog("Media Ocean Import folder " & LocalFolder & " does not exist! --> " & DatabaseProfile.DatabaseName)

                                End If

                            End Using

                        End Using

                    End Using

                End If

            Catch ex As Exception
                WriteToEventLog(ex.Message)
            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
            Dim RunAt As Date = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing Then

                            If AdvantageService.Enabled Then

                                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.RunAt), RunAt)

                                If RunAt = CDate("01/01/2001 01:00 AM") Then

                                    RunAt = Now.ToShortDateString & " " & RunAt.ToShortTimeString

                                End If

                                If DateDiff(DateInterval.Minute, RunAt, Now) >= 0 Then

                                    RunAt = Now.AddDays(1).ToShortDateString & " " & RunAt.ToShortTimeString

                                    SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.RunAt, RunAt)

                                    ServiceIsReadyToRun = True

                                End If

                            End If

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message)
                End Try

                WriteToEventLog("Running")

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Media Ocean Import Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Media Ocean Import Source", "Media Ocean Import Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Media Ocean Import Log", My.Computer.Name, "Media Ocean Import Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSetting(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaOceanImport.RegistrySetting) As AdvantageFramework.Database.Entities.AdvantageServiceSetting

            'objects
            Dim AdvantageServiceSetting As AdvantageFramework.Database.Entities.AdvantageServiceSetting = Nothing

            Try

                AdvantageServiceSetting = AdvantageFramework.Services.LoadAdvantageServiceSetting(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                AdvantageServiceSetting = Nothing
            End Try

            LoadAdvantageServiceSetting = AdvantageServiceSetting

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaOceanImport.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.MediaOceanImport.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef RunAt As Date)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                DateTime.TryParse(LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.RunAt), RunAt)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal RunAt As DateTime)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.RunAt, RunAt)

            End If

        End Sub
        Public Sub LoadServiceSettings(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByRef FTPAddress As String, ByRef FTPUser As String, ByRef FTPPassword As String, ByRef LocalFolder As String, ByRef EmployeeCode As String,
                                       ByRef ImportType As Short)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                FTPAddress = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPAddress)

                FTPUser = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPUser)

                FTPPassword = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPPassword)

                LocalFolder = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.LocalFolder)

                EmployeeCode = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.EmployeeCode)

                ImportType = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.ImportType)

            End If

        End Sub
        Public Sub SaveServiceSettings(ByVal DataContext As AdvantageFramework.Database.DataContext,
                                       ByRef FTPAddress As String, ByRef FTPUser As String, ByRef FTPPassword As String, ByRef LocalFolder As String, ByRef EmployeeCode As String,
                                       ByRef ImportType As Short)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPAddress, FTPAddress)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPUser, FTPUser)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.FTPPassword, FTPPassword)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.LocalFolder, LocalFolder)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.EmployeeCode, EmployeeCode)
                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.MediaOceanImport.RegistrySetting.ImportType, ImportType)

            End If

        End Sub
        Public Sub WriteToEventLog(Message As String)

            Try

                SyncLock _EventLog

                    _EventLog.WriteEntry(Message)

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                SyncLock _EventLog

                    _EventLog.Clear()

                End SyncLock

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Employees = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                         Where Employee.Email IsNot Nothing AndAlso
                               Employee.Email <> ""
                         Select Employee).ToList

            LoadEmployees = Employees

        End Function
        Private Sub ProcessGLIFaceImportType(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                             FTPAddress As String, FTPUser As String, FTPPassword As String, LocalFolder As String, EmployeeCode As String)

            Dim FTPPort As Integer = 22
            Dim ImportFilesList As Generic.List(Of String) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim ErrorMessage As String = Nothing
            Dim SFTP As Rebex.Net.Sftp = Nothing
            Dim SftpItemCollection As Rebex.Net.SftpItemCollection = Nothing
            Dim Gzip As Rebex.IO.Compression.Gzip = Nothing

            If LocalFolder.EndsWith("\") = False Then

                LocalFolder = LocalFolder & "\"

            End If

            If System.IO.File.Exists(LocalFolder & "gl_iface.txt.gz") Then

                System.IO.File.Delete(LocalFolder & "gl_iface.txt.gz")

            End If

            WriteToEventLog("Validating Employee/User...")

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee Is Nothing OrElse Employee.TerminationDate IsNot Nothing OrElse Employee.Email Is Nothing OrElse Employee.Email = "" Then

                Throw New Exception("Employee does not exist, or has been terminated or does not have email address.  EmployeeCode (" & EmployeeCode & ")")

            End If

            User = AdvantageFramework.Security.Database.Procedures.User.LoadFirstUserByEmployeeCode(SecurityDbContext, EmployeeCode)

            If User Is Nothing Then

                Throw New Exception("User does not exist for EmployeeCode: " & EmployeeCode)

            End If

            WriteToEventLog("Checking FTP for list of files...")

            If Mid(FTPAddress, 1, 4).ToUpper = "FTP:" Then

                If AdvantageFramework.FTP.ValidateFTP(FTPAddress, FTPUser, FTPPassword, False, ErrorMessage) = False Then

                    Throw New Exception("Cannot Connect to FTP: " & ErrorMessage)

                End If

                ImportFilesList = AdvantageFramework.FTP.GetFilesInDirectory(FTPAddress, FTPUser, FTPPassword, False)

                For Each FileName In ImportFilesList

                    If FileName.ToUpper.StartsWith("GL_IFACE") AndAlso FileName.ToUpper.EndsWith(".GZ") Then

                        WriteToEventLog("Downloading file (" & FileName & ") to " & LocalFolder & "...")

                        If AdvantageFramework.FTP.DownloadFile(FTPAddress, FTPUser, FTPPassword, False, FileName, LocalFolder & FileName) Then

                            WriteToEventLog("Extracting from zip file (" & FileName & ") ...")

                            Gzip = New Rebex.IO.Compression.Gzip()

                            Gzip.Decompress(LocalFolder & FileName, LocalFolder)

                            WriteToEventLog("Processing file (" & FileName & ") ...")

                            ProcessGLIFaceFile(DatabaseProfile, LocalFolder, Employee)

                        End If

                    End If

                Next

            Else

                FTPAddress = Replace(FTPAddress.ToUpper, "SFTP://", "")

                Try

                    SFTP = New Rebex.Net.Sftp

                    SFTP.Timeout = 30000

                    SFTP.Connect(FTPAddress, FTPPort)

                    If SFTP.IsConnected Then

                        SFTP.Login(FTPUser, FTPPassword)

                    End If

                Catch ex As Exception

                    If SFTP IsNot Nothing Then

                        SFTP.Dispose()

                    End If

                    SFTP = Nothing

                End Try

                If SFTP IsNot Nothing AndAlso SFTP.IsAuthenticated Then

                    Try

                        SftpItemCollection = SFTP.GetList()

                        For Each RebexItem In SftpItemCollection

                            If RebexItem.IsFile Then

                                If RebexItem.Name.ToUpper.StartsWith("GL_IFACE") AndAlso RebexItem.Name.ToUpper.EndsWith(".GZ") Then

                                    WriteToEventLog("Downloading file (" & RebexItem.Name & ") to " & LocalFolder & "...")

                                    SFTP.Download(RebexItem.Path, LocalFolder)

                                    WriteToEventLog("Extracting from zip file (" & RebexItem.Name & ") ...")

                                    Gzip = New Rebex.IO.Compression.Gzip()

                                    Gzip.Decompress(LocalFolder & RebexItem.Name, LocalFolder)

                                    WriteToEventLog("Processing file (" & RebexItem.Name & ") ...")

                                    ProcessGLIFaceFile(DatabaseProfile, LocalFolder, Employee)

                                End If

                            End If

                        Next

                    Catch ex As Exception
                        Throw New Exception("Problem downloading files from SFTP: " & ex.Message)
                    End Try

                Else

                    Throw New Exception("Cannot Connect to FTP: " & ErrorMessage)

                End If

            End If

        End Sub
        Private Function ProcessGLIFaceFile(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ByVal LocalFolder As String, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim TextLine As String = Nothing
            Dim StringArray As String() = Nothing
            Dim TransNum As Decimal = 0
            Dim SeqNum As Decimal = 0
            Dim ExternalGLIFace As AdvantageFramework.Database.Entities.ExternalGLIFace = Nothing
            Dim ExternalGLIFaceList As Generic.List(Of AdvantageFramework.Database.Entities.ExternalGLIFace) = Nothing
            Dim Saved As Boolean = True
            Dim MaxTransNum As Decimal = 0
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim BatchName As String = Nothing
            Dim Processed As Boolean = False
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim ErrorMessage As String = ""

            _SelectedDatabaseProfile = DatabaseProfile

            If System.IO.Directory.Exists(LocalFolder) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        Try

                            For Each File In System.IO.Directory.GetFiles(LocalFolder)

                                If File.ToUpper.EndsWith(".TXT") Then

                                    MaxTransNum = 467649

                                    StreamReader = New System.IO.StreamReader(File)

                                    DbContext.Database.Connection.Open()

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    ExternalGLIFaceList = New Generic.List(Of AdvantageFramework.Database.Entities.ExternalGLIFace)

                                    Do While StreamReader.Peek() <> -1

                                        TextLine = StreamReader.ReadLine()

                                        StringArray = TextLine.Split(Chr(9))

                                        If StringArray.Length = 32 AndAlso StringArray(0).Trim.ToUpper <> "TRANS_NUM" AndAlso CDec(StringArray(0) >= MaxTransNum) Then

                                            TransNum = CDec(StringArray(0))
                                            SeqNum = CDec(StringArray(1))

                                            If Not DbContext.ExternalGLIFaces.Where(Function(EG) EG.TransNum = TransNum AndAlso EG.SeqNum = SeqNum).Any Then

                                                ExternalGLIFace = New AdvantageFramework.Database.Entities.ExternalGLIFace

                                                With ExternalGLIFace
                                                    .TransNum = TransNum
                                                    .SeqNum = SeqNum
                                                    .PostedSW = StringArray(2).Trim
                                                    .CompNum = CType(StringArray(3), Decimal?)
                                                    .LocID = StringArray(4).Trim
                                                    .PostingJL = StringArray(5).Trim
                                                    .JournalNum = CType(StringArray(6), Decimal?)
                                                    .TransCDate = CType(StringArray(7), Date?)
                                                    .CreateCDate = CType(StringArray(8), Date?)
                                                    .CreateUserID = StringArray(9).Trim
                                                    .FiscalYear = CType(StringArray(10), Decimal?)
                                                    .FiscalPD = CType(StringArray(11), Decimal?)
                                                    .Source = StringArray(12).Trim
                                                    .MediaType = StringArray(13).Trim
                                                    .MediaID = StringArray(14).Trim
                                                    .ClientInvoiceNum = StringArray(15).Trim
                                                    .VendorInvoiceNum = StringArray(16).Trim
                                                    .VendorID = StringArray(17).Trim
                                                    .VendorName = StringArray(18).Trim
                                                    .NetType = StringArray(19).Trim
                                                    .ClientID = StringArray(20).Trim
                                                    .DivisionID = StringArray(21).Trim
                                                    .EmployeeID = StringArray(22).Trim
                                                    .EmployeeName = StringArray(23).Trim
                                                    .GLOrgID = StringArray(24).Trim
                                                    .GLAcctID = StringArray(25).Trim
                                                    .GLProjID = StringArray(26).Trim
                                                    .Reference = StringArray(27).Trim
                                                    .AccountDescription = StringArray(28).Trim
                                                    .DebitAmount = CType(StringArray(29), Decimal?)
                                                    .CreditAmount = CType(StringArray(30), Decimal?)
                                                    .DtReserved4 = StringArray(31).Trim
                                                    '.PostedSW = AdvantageFramework.Importing.ScrubFileData(StringArray(2), GetType(System.String), True, 1, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.CompNum = AdvantageFramework.Importing.ScrubFileData(StringArray(3), GetType(System.Decimal), True, 0, 3, 0, "", Importing.FileTypes.Fixed)
                                                    '.LocID = AdvantageFramework.Importing.ScrubFileData(StringArray(4), GetType(System.String), True, 3, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.PostingJL = AdvantageFramework.Importing.ScrubFileData(StringArray(5), GetType(System.String), True, 3, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.JournalNum = AdvantageFramework.Importing.ScrubFileData(StringArray(6), GetType(System.Decimal), True, 0, 8, 0, "", Importing.FileTypes.Fixed)
                                                    '.TransCDate = AdvantageFramework.Importing.ScrubFileData(StringArray(7), GetType(System.DateTime), True, 0, 0, 0, "DMY", Importing.FileTypes.Fixed)
                                                    '.CreateCDate = AdvantageFramework.Importing.ScrubFileData(StringArray(8), GetType(System.DateTime), True, 0, 0, 0, "DMY", Importing.FileTypes.Fixed)
                                                    '.CreateUserID = AdvantageFramework.Importing.ScrubFileData(StringArray(9), GetType(System.String), True, 8, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.FiscalYear = AdvantageFramework.Importing.ScrubFileData(StringArray(10), GetType(System.Decimal), True, 0, 4, 0, "", Importing.FileTypes.Fixed)
                                                    '.FiscalPD = AdvantageFramework.Importing.ScrubFileData(StringArray(11), GetType(System.Decimal), True, 0, 2, 0, "", Importing.FileTypes.Fixed)
                                                    '.Source = AdvantageFramework.Importing.ScrubFileData(StringArray(12), GetType(System.String), True, 2, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.MediaType = AdvantageFramework.Importing.ScrubFileData(StringArray(13), GetType(System.String), True, 3, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.MediaID = AdvantageFramework.Importing.ScrubFileData(StringArray(14), GetType(System.String), True, 12, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.ClientInvoiceNum = AdvantageFramework.Importing.ScrubFileData(StringArray(15), GetType(System.String), True, 11, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.VendorInvoiceNum = AdvantageFramework.Importing.ScrubFileData(StringArray(16), GetType(System.String), True, 15, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.VendorID = AdvantageFramework.Importing.ScrubFileData(StringArray(17), GetType(System.String), True, 6, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.VendorName = AdvantageFramework.Importing.ScrubFileData(StringArray(18), GetType(System.String), True, 30, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.NetType = AdvantageFramework.Importing.ScrubFileData(StringArray(19), GetType(System.String), True, 1, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.ClientID = AdvantageFramework.Importing.ScrubFileData(StringArray(20), GetType(System.String), True, 4, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.DivisionID = AdvantageFramework.Importing.ScrubFileData(StringArray(21), GetType(System.String), True, 4, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.EmployeeID = AdvantageFramework.Importing.ScrubFileData(StringArray(22), GetType(System.String), True, 5, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.EmployeeName = AdvantageFramework.Importing.ScrubFileData(StringArray(23), GetType(System.String), True, 30, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.GLOrgID = AdvantageFramework.Importing.ScrubFileData(StringArray(24), GetType(System.String), True, 12, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.GLAcctID = AdvantageFramework.Importing.ScrubFileData(StringArray(25), GetType(System.String), True, 12, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.GLProjID = AdvantageFramework.Importing.ScrubFileData(StringArray(26), GetType(System.String), True, 12, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.Reference = AdvantageFramework.Importing.ScrubFileData(StringArray(27), GetType(System.String), True, 30, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.AccountDescription = AdvantageFramework.Importing.ScrubFileData(StringArray(28), GetType(System.String), True, 30, 0, 0, "", Importing.FileTypes.Fixed)
                                                    '.DebitAmount = AdvantageFramework.Importing.ScrubFileData(StringArray(29), GetType(System.Decimal), True, 0, 11, 2, "", Importing.FileTypes.Fixed)
                                                    '.CreditAmount = AdvantageFramework.Importing.ScrubFileData(StringArray(30), GetType(System.Decimal), True, 0, 11, 2, "", Importing.FileTypes.Fixed)
                                                    '.DtReserved4 = AdvantageFramework.Importing.ScrubFileData(StringArray(31), GetType(System.String), True, 732, 0, 0, "", Importing.FileTypes.Fixed)
                                                End With

                                                ExternalGLIFaceList.Add(ExternalGLIFace)

                                            End If

                                        End If

                                    Loop

                                    DbContext.ExternalGLIFaces.AddRange(ExternalGLIFaceList)

                                    DbContext.SaveChanges()

                                    DbTransaction.Commit()

                                End If

                            Next

                        Catch ex As Exception

                            WriteToEventLog("Media Ocean Import: ProcessGLIFaceFile: " & ex.Message)

                            DbTransaction.Rollback()

                            Saved = False

                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                            If StreamReader IsNot Nothing Then

                                StreamReader.Close()

                            End If

                        End Try

                        If Saved Then

                            ImportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE)
                                              Where Entity.Name = "MOGLIFACE"
                                              Select Entity).FirstOrDefault

                            If ImportTemplate IsNot Nothing Then

                                BatchName = AdvantageFramework.Importing.CreateBatchName(ImportTemplate.Name)

                                If StageExternalGLIFace(DbContext, MaxTransNum, ImportTemplate, BatchName) Then

                                    If Not DirectPostJE(DbContext, BatchName) Then

                                        If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, "MO GLIFACE Out of balance", "At least one or more validation errors have occurred in the attempt to direct post batch '" & BatchName & "'.", 3, SendingEmailStatus, ErrorMessage:=ErrorMessage) = False Then

                                            WriteToEventLog("Media Ocean Import: ProcessGLIFaceFile: Failed to send email.")

                                        End If

                                    End If

                                End If

                            Else

                                WriteToEventLog("Media Ocean Import: ProcessGLIFaceFile: Cannot find import template named 'MOGLIFACE'")

                            End If

                        End If

                    End Using

                End Using

            End If

            ProcessGLIFaceFile = Processed

        End Function
        Private Function StageExternalGLIFace(DbContext As AdvantageFramework.Database.DbContext, MaxTransNum As Decimal, ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                              BatchName As String) As Boolean

            Dim Staged As Boolean = True
            Dim ImportJournalEntries As Generic.List(Of AdvantageFramework.Database.Entities.ImportJournalEntry) = Nothing
            Dim PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim ExternalGLIFaceList As Generic.List(Of AdvantageFramework.Database.Entities.ExternalGLIFace) = Nothing
            Dim ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
            Dim ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail = Nothing
            Dim ExistingImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim GeneralLedgerCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerCrossReference = Nothing

            ImportJournalEntries = New Generic.List(Of AdvantageFramework.Database.Entities.ImportJournalEntry)

            PostPeriodList = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

            Try

                DbContext.Database.Connection.Open()

                DbContext.Configuration.AutoDetectChangesEnabled = False

                ExternalGLIFaceList = DbContext.ExternalGLIFaces.Where(Function(E) E.TransNum >= MaxTransNum).ToList

                For Each ExternalGLIFace In ExternalGLIFaceList

                    ImportJournalEntry = New AdvantageFramework.Database.Entities.ImportJournalEntry

                    ImportJournalEntry.ImportTemplateID = ImportTemplate.ID
                    ImportJournalEntry.TransactionID = CStr(ExternalGLIFace.JournalNum) & ExternalGLIFace.LocID

                    Try

                        ExistingImportJournalEntry = ImportJournalEntries.Where(Function(JE) JE.TransactionID = ImportJournalEntry.TransactionID).FirstOrDefault

                    Catch ex As Exception
                        ExistingImportJournalEntry = Nothing
                    End Try

                    If ExistingImportJournalEntry Is Nothing Then

                        ImportJournalEntry.DbContext = DbContext
                        ImportJournalEntry.BatchName = BatchName
                        ImportJournalEntry.Description = Mid("MO GLIFACE " & Trim(ExternalGLIFace.PostingJL & " " & ExternalGLIFace.Reference), 1, 100)
                        ImportJournalEntry.TransactionDate = ExternalGLIFace.TransCDate

                        If ExternalGLIFace.FiscalYear.HasValue AndAlso ExternalGLIFace.FiscalPD.HasValue Then

                            PostPeriod = PostPeriodList.Where(Function(PP) PP.Year = ExternalGLIFace.FiscalYear.Value AndAlso PP.Month = ExternalGLIFace.FiscalPD.Value).FirstOrDefault

                            If PostPeriod IsNot Nothing Then

                                ImportJournalEntry.PostPeriodCode = PostPeriod.Code

                            End If

                        End If

                        Select Case ExternalGLIFace.Source

                            Case "CA"

                                ImportJournalEntry.GLSource = "01"

                            Case "DG"

                                ImportJournalEntry.GLSource = "02"

                            Case "PM"

                                ImportJournalEntry.GLSource = "03"

                            Case "PR"

                                ImportJournalEntry.GLSource = "04"

                            Case "SP"

                                ImportJournalEntry.GLSource = "05"

                        End Select

                        ImportJournalEntries.Add(ImportJournalEntry)

                    Else

                        ImportJournalEntry = ExistingImportJournalEntry

                        If ImportJournalEntry.DbContext Is Nothing Then

                            DbContext.TryAttach(ImportJournalEntry)

                        End If

                    End If

                    ImportJournalEntryDetail = New AdvantageFramework.Database.Entities.ImportJournalEntryDetail

                    ImportJournalEntryDetail.DbContext = DbContext
                    ImportJournalEntryDetail.IDSeq = CStr(ExternalGLIFace.TransNum) & Space(1) & CStr(ExternalGLIFace.SeqNum)
                    ImportJournalEntryDetail.GLAccount = ExternalGLIFace.GLOrgID
                    ImportJournalEntryDetail.Amount = If(ExternalGLIFace.CreditAmount.GetValueOrDefault(0) <> 0, -ExternalGLIFace.CreditAmount.GetValueOrDefault(0), ExternalGLIFace.DebitAmount.GetValueOrDefault(0))
                    ImportJournalEntryDetail.Remark = Mid(Trim(ExternalGLIFace.PostingJL & Space(1) & ExternalGLIFace.Reference), 1, 150)
                    ImportJournalEntryDetail.ClientCode = ExternalGLIFace.ClientID
                    ImportJournalEntryDetail.DivisionCode = ExternalGLIFace.DivisionID
                    ImportJournalEntryDetail.ExternalID = ExternalGLIFace.ID

                    ImportJournalEntryDetail.ClearBlankValues()

                    If ImportTemplate.RecordSourceID.HasValue Then

                        Try

                            ClientCrossReference = (From CCR In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                    Where (CCR.SourceClientCode = ImportJournalEntryDetail.ClientCode OrElse
                                                           (CCR.SourceClientCode Is Nothing AndAlso ImportJournalEntryDetail.ClientCode Is Nothing)) AndAlso
                                                          (CCR.SourceDivisionCode = ImportJournalEntryDetail.DivisionCode OrElse
                                                           (CCR.SourceDivisionCode Is Nothing AndAlso ImportJournalEntryDetail.DivisionCode Is Nothing)) AndAlso
                                                          (CCR.SourceProductCode = ImportJournalEntryDetail.ProductCode OrElse
                                                           (CCR.SourceProductCode Is Nothing AndAlso ImportJournalEntryDetail.ProductCode Is Nothing))
                                                    Select CCR).SingleOrDefault

                        Catch ex As Exception
                            ClientCrossReference = Nothing
                        End Try

                        If ClientCrossReference IsNot Nothing Then

                            ImportJournalEntryDetail.ClientCode = ClientCrossReference.ClientCode
                            ImportJournalEntryDetail.DivisionCode = ClientCrossReference.DivisionCode
                            ImportJournalEntryDetail.ProductCode = ClientCrossReference.ProductCode

                        End If

                        Try

                            GeneralLedgerCrossReference = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerCrossReference.LoadByRecordSourceID(DbContext, ImportTemplate.RecordSourceID.Value)
                                                           Where Entity.SourceGLACode = ImportJournalEntryDetail.GLAccount
                                                           Select Entity).SingleOrDefault

                        Catch ex As Exception
                            GeneralLedgerCrossReference = Nothing
                        End Try

                        If GeneralLedgerCrossReference IsNot Nothing Then

                            ImportJournalEntryDetail.GLAccount = GeneralLedgerCrossReference.GLACode

                        End If

                    End If

                    ImportJournalEntry.ImportJournalEntryDetails.Add(ImportJournalEntryDetail)

                Next

                DbContext.ImportJournalEntrys.AddRange(ImportJournalEntries)

                DbContext.SaveChanges()

            Catch ex As Exception

                Staged = False

                WriteToEventLog("Media Ocean Import: StageExternalGLIFace: " & ex.Message)

            Finally

                If DbContext.Database.Connection.State = ConnectionState.Open Then

                    DbContext.Database.Connection.Close()

                End If

                DbContext.Configuration.AutoDetectChangesEnabled = True

            End Try

            StageExternalGLIFace = Staged

        End Function
        Private Function DirectPostJE(DbContext As AdvantageFramework.Database.DbContext, BatchName As String) As Boolean

            Dim ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry) = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim ImportJournalEntryHeaderList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader) = Nothing
            Dim HeaderIDs As Generic.List(Of Integer) = Nothing
            Dim NoErrorIDs As Generic.List(Of Integer) = Nothing
            Dim Imported As Boolean = True
            Dim ImportJournalEntryDetails As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail) = Nothing
            Dim Posted As Boolean = True

            ImportJournalEntryList = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry)

            For Each ImportJournalEntry In AdvantageFramework.Database.Procedures.ImportJournalEntry.LoadByBatchName(DbContext, BatchName).ToList

                AdvantageFramework.GeneralLedger.JournalEntryAddEntityToList(DbContext, ImportJournalEntry, ImportJournalEntryList, AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE)

            Next

            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

            AdvantageFramework.GeneralLedger.ValidateAllEntities(DbContext, Session, ImportJournalEntryList)

            If ImportJournalEntryList.Where(Function(IJE) IJE.HasError OrElse (IJE.ImportJournalEntryDetail IsNot Nothing AndAlso IJE.ImportJournalEntryDetail.HasError)).Any Then

                Posted = False

            End If

            NoErrorIDs = New Generic.List(Of Integer)

            HeaderIDs = (From Entity In ImportJournalEntryList
                         Where Entity.HasError = False
                         Select Entity.ImportJournalEntryHeader.ID).Distinct.ToList

            ImportJournalEntryDetails = (From Entity In ImportJournalEntryList
                                         Where HeaderIDs.Contains(Entity.ID)
                                         Select Entity.ImportJournalEntryDetail).ToList

            For Each HeaderID In HeaderIDs

                If ImportJournalEntryList.Where(Function(Det) Det.ID = HeaderID AndAlso Det.HasError = True).Any = False Then

                    NoErrorIDs.Add(HeaderID)

                End If

            Next

            If NoErrorIDs IsNot Nothing AndAlso NoErrorIDs.Count > 0 Then

                Imported = AdvantageFramework.Importing.CreateJERecordsFromImport(DbContext, ImportJournalEntryList.Where(Function(IJE) NoErrorIDs.Contains(IJE.ID)).ToList, True)

            End If

            DirectPostJE = Posted AndAlso Imported

        End Function

#End Region

    End Module

End Namespace

