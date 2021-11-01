Module RunMSAccess

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Sub Main(args() As String)

        'objects
        Dim Session As AdvantageFramework.Security.Session = Nothing
        Dim FileName As String = String.Empty
        Dim Server As String = String.Empty
        Dim Database As String = String.Empty
        Dim UserName As String = String.Empty
        Dim Password As String = String.Empty
        Dim UseWindowsAuth As Boolean = False
        Dim UserCode As String = String.Empty
        Dim AgencyReportFolder As String = String.Empty
        Dim AgencyReportTempFolder As String = String.Empty
        Dim AccessReportPath As String = String.Empty
        Dim AccessReportTempPath As String = String.Empty
        Dim ComboCustomFormatName As String = String.Empty
        Dim IsMedia As Boolean = False
        Dim ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec = Nothing
        Dim ARInvoiceString As String = String.Empty
        Dim ARInvoiceParts() As String = Nothing
        Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        'Debugger.Launch()

        If args IsNot Nothing AndAlso args.Count > 0 Then

            Try

                Server = args(0)
                Database = args(1)
                UserName = args(2)
                Password = args(3)
                UseWindowsAuth = args(4)
                UserCode = args(5)
                FileName = args(6)
                ComboCustomFormatName = args(7)
                IsMedia = args(8)
                ARInvoiceString = args(9)

                ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfiles.SingleOrDefault(Function(Entity) Entity.ServerName = Server AndAlso Entity.DatabaseName = Database)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Methods.Application.Advantage, Server, Database, UseWindowsAuth, UserName, Password, UserCode, 0, AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName, ConnectionDatabaseProfile.DatabaseName, False, ConnectionDatabaseProfile.UserName, AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)))

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    AgencyReportFolder = AdvantageFramework.Database.Procedures.Agency.LoadReportPath(DbContext)
                    AgencyReportTempFolder = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                    Try

                        AccessReportPath = LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessRptPath)

                    Catch ex As Exception
                        AccessReportPath = Nothing
                    End Try

                    If String.IsNullOrWhiteSpace(AccessReportPath) = False Then

                        AgencyReportFolder = AccessReportPath

                    End If

                    Try

                        AccessReportTempPath = LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                    Catch ex As Exception
                        AccessReportTempPath = Nothing
                    End Try

                    If String.IsNullOrWhiteSpace(AccessReportTempPath) = False Then

                        AgencyReportTempFolder = AccessReportTempPath

                    End If

                    If IsMedia Then

                        ReportRuntimeSpec = AdvantageFramework.Database.Procedures.ReportRuntimeSpec.LoadByUserCode(DbContext, Session.UserCode).Where(Function(Entity) Entity.ReportType = "MI").FirstOrDefault

                    Else

                        ReportRuntimeSpec = AdvantageFramework.Database.Procedures.ReportRuntimeSpec.LoadByUserCode(DbContext, Session.UserCode).Where(Function(Entity) Entity.ReportType = "PI").FirstOrDefault

                    End If

                    AccountReceivableInvoices = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

                    If String.IsNullOrWhiteSpace(ARInvoiceString) = False Then

                        For Each ARInvoice In Split(ARInvoiceString, "|")

                            ARInvoiceParts = Split(ARInvoice, ",")

                            AccountReceivableInvoices.Add(New AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice With {.InvoiceNumber = ARInvoiceParts(0),
                                                                                                                                        .RecordType = ARInvoiceParts(1),
                                                                                                                                        .ClientCode = ARInvoiceParts(2)})

                        Next

                    End If

                End Using

            Catch ex As Exception
                Session = Nothing
            End Try

        End If

        If Session IsNot Nothing Then

            RunCustomReports(Session, FileName, AgencyReportFolder, AgencyReportTempFolder, ComboCustomFormatName, ReportRuntimeSpec, AccountReceivableInvoices)

        End If

    End Sub
    Private Sub RunCustomReports(Session As AdvantageFramework.Security.Session, FileName As String,
                                 AgencyReportFolder As String, AgencyReportTempFolder As String, ComboCustomFormatName As String,
                                 ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec,
                                 AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice))

        'objects
        Dim FileInfo As System.IO.FileInfo = Nothing
        Dim OleDbConnection As System.Data.OleDb.OleDbConnection = Nothing
        Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim MSAccessEXE As String = ""
        Dim ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing

        Console.WriteLine("Generating Reports... DO NOT CLOSE THIS WINDOW... Please wait...")

        Try

            FileInfo = My.Computer.FileSystem.GetFileInfo(FileName)

        Catch ex As Exception
            FileInfo = Nothing
        End Try

        If FileInfo IsNot Nothing Then

            FileInfo.IsReadOnly = False

            OleDbConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source=" & FileName & ";")

            OleDbConnection.Open()

            If DeleteRuntimeSpecRows(OleDbConnection) Then

                If InsertRuntimeSpecRows(OleDbConnection, Session, AgencyReportFolder, AgencyReportTempFolder, ReportRuntimeSpec) Then

                    If String.IsNullOrWhiteSpace(ComboCustomFormatName) = False AndAlso AccountReceivableInvoices IsNot Nothing Then

                        InsertRuntimeInvoiceNumbers(OleDbConnection, AccountReceivableInvoices)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            DbContext.Database.Connection.Open()

                            If DbContext.ComboInvoiceDefaults.Count = 0 Then

                                ComboInvoiceDefault = New AdvantageFramework.Database.Entities.ComboInvoiceDefault

                                ComboInvoiceDefault.ClientOrDefault = 1
                                ComboInvoiceDefault.AddressBlockType = 1
                                ComboInvoiceDefault.ApplyExchangeRate = 0
                                ComboInvoiceDefault.ExchangeRateAmount = 1
                                ComboInvoiceDefault.CustomFormatName = ComboCustomFormatName

                                AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Insert(DbContext, ComboInvoiceDefault)

                            Else

                                ComboInvoiceDefault = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).FirstOrDefault

                                If ComboInvoiceDefault IsNot Nothing Then

                                    ComboInvoiceDefault.ClientOrDefault = 1
                                    ComboInvoiceDefault.AddressBlockType = 1
                                    ComboInvoiceDefault.ApplyExchangeRate = 0
                                    ComboInvoiceDefault.ExchangeRateAmount = 1
                                    ComboInvoiceDefault.CustomFormatName = ComboCustomFormatName

                                    AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Update(DbContext, ComboInvoiceDefault)

                                End If

                            End If

                        End Using

                    End If

                    OleDbConnection.Close()

                    If String.IsNullOrWhiteSpace(FileName) = False AndAlso My.Computer.FileSystem.FileExists(FileName) Then

                        Try

                            MSAccessEXE = LoadMicrosoftAccessEXEPath()

                        Catch ex As Exception
                            MSAccessEXE = ""
                        End Try

                        If String.IsNullOrWhiteSpace(MSAccessEXE) = False Then

                            MSAccessEXE = AppendTrailingCharacter(MSAccessEXE, "\")

                            System.Diagnostics.Process.Start(MSAccessEXE & "MSACCESS.EXE", """" & FileName & """ /Runtime")

                        End If

                    End If

                End If

            End If

        End If

    End Sub
    Private Function DeleteRuntimeSpecRows(OleDbConnection As System.Data.OleDb.OleDbConnection) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowsDeleted As Boolean = False

        SQLString = "DELETE FROM InvoiceRuntimeSpecs"

        OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

        Try

            OleDbCommand.ExecuteNonQuery()

            RowsDeleted = True

        Catch ex As Exception
            RowsDeleted = False
        End Try

        DeleteRuntimeSpecRows = RowsDeleted

    End Function
    Private Function InsertRuntimeSpecRows(OleDbConnection As System.Data.OleDb.OleDbConnection, Session As AdvantageFramework.Security.Session, AgencyReportFolder As String,
                                           AgencyReportTempFolder As String, ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowInserted As Boolean = False

        If OleDbConnection.DataSource.Contains("armediaobj_cusrpts.accdb") Then

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([AdvanDSN], [USER_ID], [INVOICE_DATE], [InvDateSQL], [INVOICE_PRINT_DATE], " &
                                                         "[INVOICE_MEMO_OPT], [ADDRESS_OPT], [PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH]) " &
                        "VALUES (""ODBC;DSN=" & Session.DatabaseName & ";UID=" & Session.SQLUserName & ";PWD=" & Session.SQLPassword & ";APP=Advantage"", """ & Session.UserCode & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, " &
                                                         "1, 3, 2, 0, 1, """ & AgencyReportFolder & """)"

        ElseIf OleDbConnection.DataSource.Contains("ARComboObj_CusRpts.accdb") Then

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([LINK_ID], [ADVAN_DSN], [USER_ID], [INVOICE_DATE], " &
                                                         "[InvDateSQL], [INVOICE_PRINT_DATE], [INVOICE_MEMO_OPT], [ADDRESS_OPT], " &
                                                         "[PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH], " &
                                                         "[ACCESS_TMP_PATH], [SUBJECT], [BODY], [CC_ME]) " &
                        "VALUES (" & ReportRuntimeSpec.LinkID & ", """ & ReportRuntimeSpec.AccessConnectionString & """, """ & ReportRuntimeSpec.UserCode & """, """ & ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, """ &
                                     ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, """ & ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, " & ReportRuntimeSpec.MemoOption.GetValueOrDefault(1) & ", " & ReportRuntimeSpec.AddressOption & ", " &
                                     ReportRuntimeSpec.PrintOption & ", " & ReportRuntimeSpec.IsDraft & ", " & ReportRuntimeSpec.IsOneTime & ", """ & ReportRuntimeSpec.AccessReportPath & """, """ &
                                     ReportRuntimeSpec.AccessReportTemporaryPath & """, """ & ReportRuntimeSpec.EmailSubject & """, """ & ReportRuntimeSpec.EmailBody & """, " & ReportRuntimeSpec.EmailCC.GetValueOrDefault(0) & ")"

        Else

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([AdvanDSN], [USER_ID], [InvoiceDate], [InvDateSQL], [InvoicePrintDate], [InvoiceMemoOpt], [AddressOpt], [NameOverideOpt], [FunctionOpt], [PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH]) " &
                        "VALUES (""ODBC;DSN=" & Session.DatabaseName & ";UID=" & Session.SQLUserName & ";PWD=" & Session.SQLPassword & ";APP=Advantage"", """ & Session.UserCode & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, 1, 3, NULL, 1, 2, 0, 1, """ & AgencyReportFolder & """)"

        End If

        OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

        If OleDbCommand.ExecuteNonQuery > 0 Then

            RowInserted = True

        End If

        InsertRuntimeSpecRows = RowInserted

    End Function
    Private Function InsertRuntimeInvoiceNumbers(OleDbConnection As System.Data.OleDb.OleDbConnection, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowInserted As Boolean = True

        For Each AccountReceivableInvoice In AccountReceivableInvoices

            SQLString = "INSERT INTO SelARInv ([AR_INV_NBR], [ORDER_TYPE], [CL_CODE]) " &
                        "VALUES (" & AccountReceivableInvoice.InvoiceNumber & ", """ & AccountReceivableInvoice.RecordType & """, """ & AccountReceivableInvoice.ClientCode & """)"

            OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

            If OleDbCommand.ExecuteNonQuery = 0 Then

                RowInserted = False

            End If

        Next

        InsertRuntimeInvoiceNumbers = RowInserted

    End Function
    Private Function LoadMicrosoftAccessEXEPath() As String

        'objects
        Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim AccessEXEPath As String = ""

        Try

            If System.Environment.Is64BitOperatingSystem Then

                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", False)

            Else

                RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\MSACCESS.EXE", False)

            End If

        Catch ex As Exception
            RegistryKey = Nothing
        End Try

        If RegistryKey IsNot Nothing Then

            Try

                AccessEXEPath = RegistryKey.GetValue("Path")

            Catch ex As Exception
                AccessEXEPath = ""
            End Try

        End If

        LoadMicrosoftAccessEXEPath = AccessEXEPath

    End Function
    Private Function AppendTrailingCharacter(ByVal InitialString As String, ByRef AppendCharacter As String) As String

        If InitialString.Length > 0 Then

            If InitialString.Substring(InitialString.Length - 1) <> AppendCharacter Then

                InitialString += AppendCharacter

            End If

        End If

        AppendTrailingCharacter = InitialString

    End Function
    Private Function LoadMachineAccessSettings(ByVal LocalMachineAccess As AdvantageFramework.Agency.LocalMachineAccess) As String

        'objects
        Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim AgencyAccessValue As String = ""
        Dim RegistryAttribute As AdvantageFramework.Registry.Attributes.RegistryAttribute = Nothing

        If System.Environment.Is64BitOperatingSystem Then

            RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Advantage", False)

        Else

            RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Advantage", False)

        End If

        If RegistryKey IsNot Nothing Then

            RegistryAttribute = System.Attribute.GetCustomAttribute(LocalMachineAccess.GetType().GetField(LocalMachineAccess.ToString), GetType(AdvantageFramework.Registry.Attributes.RegistryAttribute))

            If RegistryAttribute IsNot Nothing Then

                If RegistryKey IsNot Nothing Then

                    AgencyAccessValue = RegistryKey.GetValue(RegistryAttribute.Key, RegistryAttribute.Default)

                Else

                    AgencyAccessValue = RegistryAttribute.Default

                End If

            End If

        End If

        LoadMachineAccessSettings = AgencyAccessValue

    End Function

#End Region

End Module
