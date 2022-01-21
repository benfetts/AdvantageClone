Namespace Exporting

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const JOB_INFO_TO_FTP_1 As String = "Export Job Info To FTP"
        Public Const AP_GENERIC_1 As String = "GENERIC 1"
        Public Const PO_CUSTOM_1 As String = "CUSTOM 1"
        Public Const AP_CUSTOM_1 As String = "CUSTOM 1"

#End Region

#Region " Enum "

        Public Enum FileTypes As Short
            CSV = 1
            Fixed = 2
        End Enum

        Public Enum ExportTypes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Media Plan Data")>
            MediaPlanData = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "GL Detail")>
            GeneralLedgerDetail = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Account Payable")>
            AccountPayable = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Job")>
            Job = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Time")>
            Time = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Archived Jobs")>
            ArchivedJobs = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Purchase Order")>
            PurchaseOrder = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "General Ledger Mapping Export")>
            GeneralLedgerMappingExport = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "YayPay Invoice Details")>
            YayPayInvoiceDetails = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "YayPay Invoice Transaction Allocations")>
            YayPayInvoiceTransactionAllocations = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("11", "YayPay Invoice With Payments")>
            YayPayInvoiceWithPayments = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("12", "YayPay Invoice Transactions")>
            YayPayInvoiceTransactions = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "YayPay Invoice Customers")>
            YayPayInvoiceCustomers = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("13", "YayPay Invoice Contacts")>
            YayPayInvoiceContacts = 14
        End Enum

        Public Enum DataColumnExtendedProperties
            Start
            Length
            Position
            PropertyDescriptor
            Precision
            Scale
        End Enum

        Public Enum MediaPlanOrderGroupings As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Full Flight")>
            FullFlight = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "By Day")>
            ByDay = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "By Week")>
            ByWeek = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "By Month")>
            ByMonth = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "By Quarter")>
            ByQuarter = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Period")>
            Period = 6
        End Enum

        Public Enum Form1099
            MISC = 1
            NEC = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CopyExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportTemplateID As Integer, ByRef NewExportTemplateID As Integer, ByVal NewExportTemplateName As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
            Dim NewExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim NewExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If DbContext.Database.Connection.State = ConnectionState.Closed Then

                DbContext.Database.Connection.Open()

            End If

            DbTransaction = DbContext.Database.BeginTransaction

            Try

                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID)

                If ExportTemplate IsNot Nothing Then

                    NewExportTemplate = New AdvantageFramework.Database.Entities.ExportTemplate

                    NewExportTemplate.DbContext = DbContext
                    NewExportTemplate.Type = ExportTemplate.Type
                    NewExportTemplate.Name = NewExportTemplateName
                    NewExportTemplate.FileType = ExportTemplate.FileType
                    NewExportTemplate.CreatedByUserCode = DbContext.UserCode
                    NewExportTemplate.CreatedDate = Now
                    NewExportTemplate.Delimiter = ExportTemplate.Delimiter

                    If AdvantageFramework.Database.Procedures.ExportTemplate.Insert(DbContext, NewExportTemplate) Then

                        Copied = True

                        For Each ExportTemplateDetail In ExportTemplate.ExportTemplateDetails.ToList

                            NewExportTemplateDetail = New AdvantageFramework.Database.Entities.ExportTemplateDetail

                            NewExportTemplateDetail.DbContext = DbContext
                            NewExportTemplateDetail.ExportTemplateID = NewExportTemplate.ID
                            NewExportTemplateDetail.FieldName = ExportTemplateDetail.FieldName
                            NewExportTemplateDetail.Start = ExportTemplateDetail.Start
                            NewExportTemplateDetail.Length = ExportTemplateDetail.Length
                            NewExportTemplateDetail.Position = ExportTemplateDetail.Position
                            NewExportTemplateDetail.CreatedByUserCode = DbContext.UserCode
                            NewExportTemplateDetail.CreatedDate = Now

                            If AdvantageFramework.Database.Procedures.ExportTemplateDetail.Insert(DbContext, NewExportTemplateDetail) = False Then

                                Copied = False
                                Exit For

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                Copied = False
            End Try

            Try

                If Copied Then

                    DbTransaction.Commit()

                Else

                    DbTransaction.Rollback()

                End If

            Catch ex As Exception
                Copied = False
            End Try

            If Copied Then

                NewExportTemplateID = NewExportTemplate.ID

            End If

            DbContext.Database.Connection.Close()

            CopyExportTemplate = Copied

        End Function
		Public Function CreateDataFilterByExportTemplateType(Session As AdvantageFramework.Security.Session,
															 ExportType As ExportTypes,
															 Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As AdvantageFramework.Exporting.Interfaces.IExportDataFilter

			'objects
			Dim DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter = Nothing

			Select Case ExportType

                Case ExportTypes.YayPayInvoiceDetails

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceDetail

                Case ExportTypes.YayPayInvoiceTransactionAllocations

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAllocation

                Case ExportTypes.YayPayInvoiceWithPayments

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPayments

                Case ExportTypes.YayPayInvoiceTransactions

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransaction

                Case ExportTypes.YayPayInvoiceCustomers

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceCustomer

                Case ExportTypes.YayPayInvoiceContacts

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceContact

                Case ExportTypes.MediaPlanData

					DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData

				Case ExportTypes.GeneralLedgerDetail

					DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerDetail(Session)

				Case ExportTypes.AccountPayable

					If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

						DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand

					ElseIf ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_CUSTOM_1 Then

						DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.AccountPayableCustom1

					Else

						DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.AccountPayable

					End If

				Case ExportTypes.PurchaseOrder

					If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = PO_CUSTOM_1 Then

						DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrderCustom1

					Else

						DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.PurchaseOrder

					End If

				Case ExportTypes.Job

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = JOB_INFO_TO_FTP_1 Then

                        DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.JobInfoToFTP

                    Else

                        DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.JobInfoToFTP

                    End If

                Case ExportTypes.GeneralLedgerMappingExport

                    DataFilter = New AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerMappingExport

            End Select

			CreateDataFilterByExportTemplateType = DataFilter

		End Function
		Public Function CreateExportFileByExportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ExportType As ExportTypes,
                                                         ByVal ExportTemplateID As Integer, ByVal Folder As String,
                                                         ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                         ByVal DataTable As System.Data.DataTable,
                                                         ByRef FullFileName As String) As Boolean

            'objects
            Dim ExportFileCreated As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ExportFileCreated = CreateExportFileByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplateID, Folder, DataFilter, DataTable, FullFileName)

                    End Using

                End Using

            Catch ex As Exception
                ExportFileCreated = False
            End Try

            CreateExportFileByExportTemplate = ExportFileCreated

        End Function
        Public Function CreateExportFileByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                         ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer,
                                                         ByVal Folder As String, ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                         ByVal DataTable As System.Data.DataTable,
                                                         ByRef FullFileName As String) As Boolean

            'objects
            Dim ExportFileCreated As Boolean = False
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing
            Dim ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail) = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Data As String = ""
            Dim LineData As String = ""
            Dim FileName As String = ""
            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
            Dim FileType As AdvantageFramework.Exporting.FileTypes = FileTypes.CSV
            Dim SplitHeaderTextByWords As Boolean = True

            Try

                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID)

                If ExportTemplate IsNot Nothing Then

                    ExportTemplateDetails = AdvantageFramework.Database.Procedures.ExportTemplateDetail.LoadByExportTemplateID(DbContext, ExportTemplate.ID).ToList
                    FileType = ExportTemplate.FileType

                End If

                If My.Computer.FileSystem.DirectoryExists(Folder) Then

                    If DataTable Is Nothing Then

                        If CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplate, DataFilter, DataTable) = False Then

                            DataTable = Nothing

                        End If

                    End If

                    If DataTable IsNot Nothing Then

						If ExportTemplate IsNot Nothing Then

                            If ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.PurchaseOrder AndAlso ExportTemplate.IsSystemTemplate = True AndAlso ExportTemplate.Name.ToUpper = PO_CUSTOM_1 Then

                                FileName = "PurchaseOrderCustom1_" & Now.ToString("yyyyMMddHHmmss") & "_" & DbContext.UserCode

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.AccountPayable AndAlso ExportTemplate.IsSystemTemplate = True AndAlso ExportTemplate.Name.ToUpper = AP_CUSTOM_1 Then

                                FileName = "AccountPayableCustom1_" & Now.ToString("yyyyMMddHHmmss") & "_" & DbContext.UserCode

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "invoiceLines"

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "transactionAllocations"

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "invoice"

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "transaction"

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "customer"

                            ElseIf ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts AndAlso ExportTemplate.IsSystemTemplate = True Then

                                FileName = "contact"

                            Else

								If My.Application.Culture.DateTimeFormat.ShortDatePattern.ToUpper.StartsWith("M") Then

									FileName = ExportTemplate.Name & "_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

								ElseIf My.Application.Culture.DateTimeFormat.ShortDatePattern.ToUpper.StartsWith("D") Then

									FileName = ExportTemplate.Name & "_" & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

								End If

							End If

						Else

							If My.Application.Culture.DateTimeFormat.ShortDatePattern.ToUpper.StartsWith("M") Then

								FileName = ExportType.ToString & "_" & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

							ElseIf My.Application.Culture.DateTimeFormat.ShortDatePattern.ToUpper.StartsWith("D") Then

								FileName = ExportType.ToString & "_" & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

							End If

						End If

                        FullFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & FileName

                        ExportFields = LoadExportFields(DbContext, ExportType, ExportTemplateDetails)

                        StringBuilder = New System.Text.StringBuilder

                        If FileType = AdvantageFramework.Exporting.FileTypes.CSV Then

                            FullFileName = FullFileName & ".csv"

                            ExportFields = ExportFields.OrderBy(Function(Entity) Entity.Position).ToList

                            If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Type = Exporting.ExportTypes.AccountPayable AndAlso ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                                StringBuilder.Append(CreateAnswersOnDemandFile(DataTable, ExportFields))

                            Else

                                If (ExportTemplate IsNot Nothing AndAlso ExportTemplate.IncludeColumnHeaders) OrElse ExportTemplate Is Nothing Then

                                    LineData = Nothing

                                    If ExportTemplate IsNot Nothing Then

                                        If (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                                (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                                (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                                (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                                (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                                (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts AndAlso ExportTemplate.IsSystemTemplate = True) Then

                                            SplitHeaderTextByWords = False

                                        End If

                                    End If

                                    For Each ExportField In ExportFields

                                        Data = ""

                                        If SplitHeaderTextByWords Then

                                            Data = AdvantageFramework.StringUtilities.GetNameAsWords(ExportField.FieldName)

                                        Else

                                            Data = ExportField.FieldName

                                        End If

                                        If Data.Contains(",") OrElse Data.Contains("""") Then

                                            Data = """" & Data.Replace("""", """""") & """"

                                        End If

                                        If LineData Is Nothing Then

                                            LineData = Data

                                        Else

                                            LineData = LineData & "," & Data

                                        End If

                                    Next

                                    StringBuilder.AppendLine(LineData)

                                End If


                                If ExportTemplate IsNot Nothing AndAlso ((ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceDetails AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                        (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactionAllocations AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                        (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                        (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                        (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceCustomers AndAlso ExportTemplate.IsSystemTemplate = True) OrElse
                                        (ExportTemplate.Type = AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceContacts AndAlso ExportTemplate.IsSystemTemplate = True)) Then

                                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                        LineData = Nothing

                                        For Each ExportField In ExportFields

                                            Data = ""

                                            If DataTable.Columns(ExportField.FieldName).DataType Is GetType(Date) Then

                                                Data = CDate(DataRow(ExportField.FieldName)).ToString("s")

                                            Else

                                                Data = GetRowData(DataRow(ExportField.FieldName))

                                            End If

                                            If Data.Contains(",") OrElse Data.Contains("""") Then

                                                Data = """" & Data.Replace("""", """""") & """"

                                            End If

                                            If LineData Is Nothing Then

                                                LineData = Data

                                            Else

                                                LineData = LineData & "," & Data

                                            End If

                                        Next

                                        StringBuilder.AppendLine(LineData)

                                    Next

                                Else

                                    For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                        LineData = Nothing

                                        For Each ExportField In ExportFields

                                            Data = ""

                                            Data = GetRowData(DataRow(ExportField.FieldName))

                                            If Data.Contains(",") OrElse Data.Contains("""") Then

                                                Data = """" & Data.Replace("""", """""") & """"

                                            End If

                                            If ExportType = ExportTypes.GeneralLedgerDetail And (Data.Contains(vbCrLf) Or Data.Contains(vbLf)) Then

                                                Data = Data.Replace(vbCrLf, "").Replace(vbLf, "")

                                            End If

                                            If LineData Is Nothing Then

                                                LineData = Data

                                            Else

                                                LineData = LineData & "," & Data

                                            End If

                                        Next

                                        StringBuilder.AppendLine(LineData)

                                    Next

                                End If

                            End If

                        ElseIf FileType = AdvantageFramework.Exporting.FileTypes.Fixed Then

                            FullFileName = FullFileName & ".txt"

                            ExportTemplateDetails = ExportTemplateDetails.Where(Function(Entity) Entity.Start.HasValue AndAlso Entity.Length.HasValue AndAlso Entity.Length.Value > 0).OrderBy(Function(Entity) Entity.Start).ToList

                            If ExportTemplate IsNot Nothing AndAlso ExportTemplate.IncludeColumnHeaders Then

                                LineData = ""

                                For Each ExportField In ExportFields

                                    Data = ""

                                    Data = AdvantageFramework.StringUtilities.GetNameAsWords(ExportField.FieldName)

                                    If LineData.Length <> ExportField.Start.GetValueOrDefault(0) - 1 Then

                                        LineData = AdvantageFramework.StringUtilities.PadWithCharacter(LineData, ExportField.Start.GetValueOrDefault(0))

                                    End If

                                    LineData &= AdvantageFramework.StringUtilities.PadWithCharacter(Data, ExportField.Length.GetValueOrDefault(0))

                                Next

                                StringBuilder.AppendLine(LineData)

                            End If

                            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                LineData = ""

                                For Each ExportField In ExportFields

                                    Data = ""

                                    Data = GetRowData(DataRow(ExportField.FieldName))

                                    If LineData.Length <> ExportField.Start.GetValueOrDefault(0) - 1 Then

                                        LineData = AdvantageFramework.StringUtilities.PadWithCharacter(LineData, ExportField.Start.GetValueOrDefault(0))

                                    End If

                                    LineData &= AdvantageFramework.StringUtilities.PadWithCharacter(Data, ExportField.Length.GetValueOrDefault(0))

                                Next

                                StringBuilder.AppendLine(LineData)

                            Next

                        End If

                        Try

                            My.Computer.FileSystem.WriteAllText(FullFileName, StringBuilder.ToString, False)

                        Catch ex As Exception

                        End Try

                        ExportFileCreated = My.Computer.FileSystem.FileExists(FullFileName)

                    End If

                End If

            Catch ex As Exception
                ExportFileCreated = False
            End Try

            CreateExportFileByExportTemplate = ExportFileCreated

        End Function
        Public Function CreateExportDataSourceByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                               ByVal ExportType As ExportTypes,
                                                               ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate,
                                                               ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                               ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DataSourceCreated As Boolean = False

            Try

                If ExportTemplate IsNot Nothing Then

                    DataTable = CreateDataTableFromTemplate(DbContext, ExportType, ExportTemplate.ExportTemplateDetails.ToList)

                Else

                    DataTable = CreateDataTableFromTemplate(DbContext, ExportType, Nothing)

                End If

                DataTable.BeginLoadData()

                Try

                    For Each EntityItem In LoadEntityDataSourceByExportTemplateType(DbContext, SecurityDbContext, ExportType, DataFilter, ExportTemplate)

                        InsertRowIntoDataTableFromEntity(DataTable, EntityItem)

                    Next

                    DataSourceCreated = True

                Catch ex As Exception

                End Try

                DataTable.EndLoadData()

            Catch ex As Exception
                DataSourceCreated = False
            Finally
                CreateExportDataSourceByExportTemplate = DataSourceCreated
            End Try

        End Function
        Public Function CreateExportDataSourceByExportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                               ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer,
                                                               ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                               ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DataSourceCreated As Boolean = False

            Try

                DataSourceCreated = CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID), DataFilter, DataTable)

            Catch ex As Exception
                DataSourceCreated = False
            Finally
                CreateExportDataSourceByExportTemplate = DataSourceCreated
            End Try

        End Function
        Public Function CreateExportDataSourceByExportTemplate(ByVal Session As AdvantageFramework.Security.Session, ByVal ExportType As ExportTypes, ByVal ExportTemplateID As Integer, ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter, ByRef DataTable As System.Data.DataTable) As Boolean

            'objects
            Dim DataSourceCreated As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DataSourceCreated = CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, ExportType, ExportTemplateID, DataFilter, DataTable)

                    End Using

                End Using

                DataSourceCreated = True

            Catch ex As Exception
                DataSourceCreated = False
            Finally
                CreateExportDataSourceByExportTemplate = DataSourceCreated
            End Try

        End Function
        Public Function LoadClassTypeByExportTemplateType(ByVal ExportType As ExportTypes,
                                                          Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As System.Type

            'objects
            Dim ClassType As System.Type = Nothing

            Select Case ExportType

                Case ExportTypes.YayPayInvoiceDetails

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceDetail)

                Case ExportTypes.YayPayInvoiceTransactionAllocations

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransactionAllocation)

                Case ExportTypes.YayPayInvoiceWithPayments

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceWithPayments)

                Case ExportTypes.YayPayInvoiceTransactions

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransaction)

                Case ExportTypes.YayPayInvoiceCustomers

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceCustomer)

                Case ExportTypes.YayPayInvoiceContacts

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceContact)

                Case ExportTypes.MediaPlanData

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

                Case ExportTypes.GeneralLedgerDetail

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail)

                Case ExportTypes.AccountPayable

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand)

                    ElseIf ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_CUSTOM_1 Then

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1)

                    Else

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayable)

                    End If

                Case ExportTypes.PurchaseOrder

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = PO_CUSTOM_1 Then

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.PurchaseOrderCustom1)

                    Else

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.PurchaseOrder)

                    End If

                Case ExportTypes.Job

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = JOB_INFO_TO_FTP_1 Then

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)

                    Else

                        ClassType = GetType(AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)

                    End If

                Case ExportTypes.GeneralLedgerMappingExport

                    ClassType = GetType(AdvantageFramework.Exporting.DataClasses.GeneralLedgerMappingExport)

            End Select

            LoadClassTypeByExportTemplateType = ClassType

        End Function
        Public Function DoesExportTypeHaveAutoFillOption(ByVal ExportType As ExportTypes) As Boolean

            'objects
            Dim HasAutoFillOption As Boolean = False
            Dim ClassType As System.Type = Nothing

            ClassType = LoadClassTypeByExportTemplateType(ExportType, Nothing)

            Try

                HasAutoFillOption = (From EntityAttribute In System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).Select(Function(PD) PD.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault).ToList
                                     Where EntityAttribute.IsReadOnlyColumn = False
                                     Select EntityAttribute).Any

            Catch ex As Exception
                HasAutoFillOption = False
            End Try

            DoesExportTypeHaveAutoFillOption = HasAutoFillOption

        End Function
        Public Function LoadEntityTypeByExportTemplateType(ByVal ExportType As ExportTypes,
                                                           Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As System.Type

            'objects
            Dim EntityType As System.Type = Nothing

            Select Case ExportType

                Case ExportTypes.YayPayInvoiceDetails

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceDetail)

                Case ExportTypes.YayPayInvoiceTransactionAllocations

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransactionAllocation)

                Case ExportTypes.YayPayInvoiceWithPayments

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceWithPayments)

                Case ExportTypes.YayPayInvoiceTransactions

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransaction)

                Case ExportTypes.YayPayInvoiceCustomers

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceCustomer)

                Case ExportTypes.YayPayInvoiceContacts

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.YayPayInvoiceContact)

                Case ExportTypes.MediaPlanData

                    EntityType = GetType(AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

                Case ExportTypes.GeneralLedgerDetail

                    EntityType = Nothing

                Case ExportTypes.AccountPayable

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand)

                    ElseIf ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_CUSTOM_1 Then

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1)

                    Else

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.AccountPayable)

                    End If

                Case ExportTypes.PurchaseOrder

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = PO_CUSTOM_1 Then

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.PurchaseOrderCustom1)

                    Else

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.PurchaseOrder)

                    End If

                Case ExportTypes.Job

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = JOB_INFO_TO_FTP_1 Then

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)

                    Else

                        EntityType = GetType(AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)

                    End If

            End Select

            LoadEntityTypeByExportTemplateType = EntityType

        End Function
        Public Function LoadPropertiesByExportTemplateType(ByVal ExportType As ExportTypes,
                                                           Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As Generic.List(Of System.ComponentModel.PropertyDescriptor)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(LoadClassTypeByExportTemplateType(ExportType, ExportTemplate)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

            For Each PropertyDescriptor In PropertyDescriptors.ToList

                If PropertyDescriptor.PropertyType Is GetType(System.Guid) Then

                    PropertyDescriptors.Remove(PropertyDescriptor)

                ElseIf PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).Any(Function(EA) EA.ShowColumnInGrid = False) OrElse
                        PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.BrowsableAttribute).Any(Function(BA) BA.Browsable = False) Then

                    If Not (ExportType = ExportTypes.MediaPlanData AndAlso (PropertyDescriptor.Name = AdvantageFramework.Exporting.DataClasses.MediaPlanningData.Properties.MediaPlanDetailLevelLineDataID.ToString OrElse
                                                                            PropertyDescriptor.Name = AdvantageFramework.Exporting.DataClasses.MediaPlanningData.Properties.RowIndex.ToString)) Then

                        PropertyDescriptors.Remove(PropertyDescriptor)

                    End If

                End If

            Next

            LoadPropertiesByExportTemplateType = PropertyDescriptors

        End Function
        Public Function LoadFieldNamesByExportTemplateType(ByVal ExportType As ExportTypes,
                                                           Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As Generic.List(Of String)

            'objects
            Dim FieldNames As Generic.List(Of String) = Nothing

            FieldNames = LoadPropertiesByExportTemplateType(ExportType, ExportTemplate).Select(Function(PropertyDescriptor) PropertyDescriptor.Name).ToList

            LoadFieldNamesByExportTemplateType = FieldNames

        End Function
        Private Function LoadEntityDataSourceByExportTemplateType(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                  ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                  ByVal ExportType As ExportTypes,
                                                                  ByVal DataFilter As AdvantageFramework.Exporting.Interfaces.IExportDataFilter,
                                                                  Optional ByVal ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing) As IEnumerable

            'objects
            Dim DataSource As IEnumerable = Nothing
            Dim AccountPayableAnswersOnDemand As AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand = Nothing
            Dim AccountPayable As AdvantageFramework.Exporting.DataFilterClasses.AccountPayable = Nothing
            Dim SqlParameterDateStart As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateEnd As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectByEntryOrInvoiceDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRecordSourceID As System.Data.SqlClient.SqlParameter = Nothing

            Select Case ExportType

                Case ExportTypes.YayPayInvoiceDetails

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceDetail)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.YayPayInvoiceTransactionAllocations

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransactionAllocation)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.YayPayInvoiceWithPayments

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceWithPayments)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.YayPayInvoiceTransactions

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceTransaction)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.YayPayInvoiceCustomers

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceCustomer)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.YayPayInvoiceContacts

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.YayPayInvoiceContact)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.MediaPlanData

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.GeneralLedgerDetail

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.GeneralLedgerDetail)(DataFilter.EntityFilterString).ToList

                Case ExportTypes.AccountPayable

                    SqlParameterDateStart = New System.Data.SqlClient.SqlParameter("@DATE_START", SqlDbType.SmallDateTime)
                    SqlParameterDateEnd = New System.Data.SqlClient.SqlParameter("@DATE_END", SqlDbType.SmallDateTime)
                    SqlParameterSelectByEntryOrInvoiceDate = New System.Data.SqlClient.SqlParameter("@ENTRY_OR_INVOICE_DATE", SqlDbType.SmallInt)

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_GENERIC_1 Then

                        AccountPayableAnswersOnDemand = DirectCast(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.AccountPayableAnswersOnDemand)

                        SqlParameterSelectByEntryOrInvoiceDate.Value = AccountPayableAnswersOnDemand.SelectByEntryOrInvoiceDate
                        SqlParameterDateStart.Value = AccountPayableAnswersOnDemand.DateStart.Value
                        SqlParameterDateEnd.Value = AccountPayableAnswersOnDemand.DateEnd.Value

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand)(DataFilter.EntityFilterString, SqlParameterDateStart, SqlParameterDateEnd, SqlParameterSelectByEntryOrInvoiceDate).ToList

                    ElseIf ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = AP_CUSTOM_1 Then

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.AccountPayableCustom1)(DataFilter.EntityFilterString).ToList

                    Else

                        AccountPayable = DirectCast(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.AccountPayable)

                        SqlParameterSelectByEntryOrInvoiceDate.Value = AccountPayable.SelectByEntryOrInvoiceDate
                        SqlParameterDateStart.Value = AccountPayable.DateStart.Value
                        SqlParameterDateEnd.Value = AccountPayable.DateEnd.Value

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.AccountPayable)(DataFilter.EntityFilterString, SqlParameterDateStart, SqlParameterDateEnd, SqlParameterSelectByEntryOrInvoiceDate).ToList

                    End If

                Case ExportTypes.PurchaseOrder

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = PO_CUSTOM_1 Then

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.PurchaseOrderCustom1)(DataFilter.EntityFilterString).ToList

                    Else

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.PurchaseOrder)(DataFilter.EntityFilterString).ToList

                    End If

                Case ExportTypes.Job

                    If ExportTemplate IsNot Nothing AndAlso ExportTemplate.Name.ToUpper = JOB_INFO_TO_FTP_1 Then

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)(DataFilter.EntityFilterString).ToList

                    Else

                        DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.JobInfoToFTP)(DataFilter.EntityFilterString).ToList

                    End If

                Case ExportTypes.GeneralLedgerMappingExport

                    SqlParameterRecordSourceID = New System.Data.SqlClient.SqlParameter("@RECORD_SOURCE_ID", SqlDbType.Int)

                    With DirectCast(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.GeneralLedgerMappingExport)

                        SqlParameterRecordSourceID.Value = .RecordSourceID

                    End With

                    DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Exporting.DataClasses.GeneralLedgerMappingExport)(DataFilter.EntityFilterString, SqlParameterRecordSourceID).ToList

            End Select

            LoadEntityDataSourceByExportTemplateType = DataSource

        End Function
        Public Function InsertRowIntoDataTableFromEntity(ByVal DataTable As System.Data.DataTable,
                                                         ByVal Entity As Object) As Boolean

            'objects
            Dim RowInserted As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As Object = Nothing

            Try

                DataRow = DataTable.NewRow

                For Each DataColumn In DataTable.Columns

                    Try

                        PropertyDescriptor = DataColumn.ExtendedProperties(DataColumnExtendedProperties.PropertyDescriptor.ToString)

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            PropertyValue = PropertyDescriptor.GetValue(Entity)

                        Catch ex As Exception
                            PropertyValue = Nothing
                        End Try

                        DataRow(DataColumn) = If(PropertyValue Is Nothing, System.DBNull.Value, PropertyValue)

                    End If

                Next

                DataTable.Rows.Add(DataRow)

                RowInserted = True

            Catch ex As Exception
                RowInserted = False
            End Try

            InsertRowIntoDataTableFromEntity = RowInserted

        End Function
        Private Function LoadExportFields(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportType As ExportTypes,
                                          Optional ByVal ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail) = Nothing,
                                          Optional ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing) As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)

            'objects
            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing

            ExportFields = New Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)

            If PropertyDescriptorsList Is Nothing Then

                Try

                    PropertyDescriptorsList = LoadPropertiesByExportTemplateType(ExportType, Nothing)

                Catch ex As Exception

                End Try

            End If

            If ExportTemplateDetails Is Nothing Then

                For Each PropertyDescriptor In PropertyDescriptorsList

                    ExportFields.Add(New AdvantageFramework.Exporting.Classes.ExportField(PropertyDescriptor.Name, ExportFields.Count))

                Next

            Else

                For Each ExportTemplateDetail In ExportTemplateDetails.OrderBy(Function(Entity) Entity.Position).ToList

                    Try

                        PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PD) PD.Name = ExportTemplateDetail.FieldName)

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    ExportFields.Add(New AdvantageFramework.Exporting.Classes.ExportField(ExportTemplateDetail, PropertyDescriptor))

                Next

            End If

            LoadExportFields = ExportFields

        End Function
        Public Function CreateDataTableFromTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportType As ExportTypes,
                                                    ByVal ExportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplateDetail)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim MaxLength As Long = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim EntityObjectType As System.Type = Nothing
            Dim ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing

            Try

                EntityObjectType = LoadEntityTypeByExportTemplateType(ExportType, If(ExportTemplateDetails IsNot Nothing, If(ExportTemplateDetails.FirstOrDefault IsNot Nothing, ExportTemplateDetails.FirstOrDefault.ExportTemplate, Nothing), Nothing))

                Try

                    PropertyDescriptorsList = LoadPropertiesByExportTemplateType(ExportType, If(ExportTemplateDetails IsNot Nothing, If(ExportTemplateDetails.FirstOrDefault IsNot Nothing, ExportTemplateDetails.FirstOrDefault.ExportTemplate, Nothing), Nothing))

                Catch ex As Exception

                End Try

                If PropertyDescriptorsList IsNot Nothing Then

                    ExportFields = LoadExportFields(DbContext, ExportType, ExportTemplateDetails, PropertyDescriptorsList)

                    DataTable = New System.Data.DataTable

                    For Each ExportField In ExportFields.OrderBy(Function(Entity) Entity.Position)

                        MaxLength = -1

                        Try

                            PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name = ExportField.FieldName)

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            DataColumn = DataTable.Columns.Add(PropertyDescriptor.Name)

                            If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                                DataColumn.AllowDBNull = True
                                DataColumn.DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                            Else

                                DataColumn.DataType = PropertyDescriptor.PropertyType

                            End If

                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Precision.ToString, -1)
                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Scale.ToString, -1)

                            If DataColumn.DataType Is GetType(String) Then

                                MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                                If MaxLength = 0 Then

                                    MaxLength = -1

                                End If

                                DataColumn.MaxLength = MaxLength

                            ElseIf DataColumn.DataType Is GetType(Decimal) Then

                                Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)
                                Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                                DataColumn.ExtendedProperties(DataColumnExtendedProperties.Precision.ToString) = Precision
                                DataColumn.ExtendedProperties(DataColumnExtendedProperties.Scale.ToString) = Scale

                            End If

                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Start.ToString, ExportField.Start.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Length.ToString, ExportField.Length.GetValueOrDefault(0))
                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.Position.ToString, ExportField.Position)
                            DataColumn.ExtendedProperties.Add(DataColumnExtendedProperties.PropertyDescriptor.ToString, PropertyDescriptor)

                        End If

                    Next

                End If

            Catch ex As Exception
                DataTable = Nothing
            End Try

            CreateDataTableFromTemplate = DataTable

        End Function
        Private Function GetRowData(ByVal RowData As Object) As String

            'objects
            Dim NewRowData As String = ""

            Try

                If TypeOf RowData Is System.DBNull Then

                    NewRowData = ""

                Else

                    NewRowData = RowData

                End If

            Catch ex As Exception
                NewRowData = ""
            End Try

            GetRowData = NewRowData

        End Function
        Public Function LoadPreDefinedLength(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor) As Integer

            'objects
            Dim PreDefinedLength As Long = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim DataType As System.Type = Nothing
            Dim MaxLengthAttribute As System.ComponentModel.DataAnnotations.MaxLengthAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                If Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType) IsNot Nothing Then

                    DataType = Nullable.GetUnderlyingType(PropertyDescriptor.PropertyType)

                Else

                    DataType = PropertyDescriptor.PropertyType

                End If

                If DataType Is GetType(String) Then

                    PreDefinedLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(PropertyDescriptor)

                    MaxLengthAttribute = PropertyDescriptor.Attributes.OfType(Of System.ComponentModel.DataAnnotations.MaxLengthAttribute).SingleOrDefault

                    If MaxLengthAttribute IsNot Nothing Then

                        PreDefinedLength = MaxLengthAttribute.Length

                    End If

                ElseIf DataType Is GetType(Decimal) Then

                    Precision = AdvantageFramework.BaseClasses.Entity.LoadPropertyPrecision(PropertyDescriptor)
                    Scale = AdvantageFramework.BaseClasses.Entity.LoadPropertyScale(PropertyDescriptor)

                    If Precision <> 0 OrElse Scale <> 0 Then

                        PreDefinedLength = Precision + Scale + 1

                    Else

                        PreDefinedLength = 29

                    End If

                ElseIf DataType Is GetType(Double) Then

                    PreDefinedLength = 16

                ElseIf DataType Is GetType(Integer) Then

                    PreDefinedLength = 10

                ElseIf DataType Is GetType(Short) Then

                    PreDefinedLength = 5

                ElseIf DataType Is GetType(Byte) Then

                    PreDefinedLength = 3

                ElseIf DataType Is GetType(Long) Then

                    PreDefinedLength = 20

                ElseIf DataType Is GetType(Single) Then

                    PreDefinedLength = 7

                ElseIf DataType Is GetType(Date) Or DataType Is GetType(DateTime) Then

                    PreDefinedLength = 20

                End If

            End If

            If PreDefinedLength = 0 Then

                PreDefinedLength = 100

            End If

            LoadPreDefinedLength = PreDefinedLength

        End Function
        Public Function ConvertExportDataSourceToIEnumerable(Of ExportDataType)(ByVal ExportType As ExportTypes, ByVal ExportDataSource As System.Data.DataTable) As Generic.List(Of ExportDataType)

            'objects
            Dim DataSource As IEnumerable = Nothing

            DataSource = ConvertExportDataSourceToIEnumerable(Of ExportDataType)(ExportType, ExportDataSource.Rows.OfType(Of System.Data.DataRow).ToArray)

            ConvertExportDataSourceToIEnumerable = DataSource

        End Function
        Public Function ConvertExportDataSourceToIEnumerable(Of ExportDataType)(ByVal ExportType As ExportTypes, ByVal ExportDataSourceRows() As System.Data.DataRow) As Generic.List(Of ExportDataType)

            'objects
            Dim Item As Object = Nothing
            Dim DataSource As Generic.List(Of ExportDataType) = Nothing
            Dim ClassType As System.Type = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            ClassType = LoadClassTypeByExportTemplateType(ExportType, Nothing)

            DataSource = New Generic.List(Of ExportDataType)

            For Each DataRow In ExportDataSourceRows

                If ClassType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                    Item = System.Activator.CreateInstance(ClassType, False)

                    For Each DataColumn In DataRow.Table.Columns.OfType(Of System.Data.DataColumn)()

                        PropertyDescriptor = Nothing

                        Try

                            PropertyDescriptor = DataColumn.ExtendedProperties(DataColumnExtendedProperties.PropertyDescriptor.ToString)

                        Catch ex As Exception
                            PropertyDescriptor = Nothing
                        End Try

                        If PropertyDescriptor IsNot Nothing Then

                            PropertyDescriptor.SetValue(Item, GetObjectData(DataRow(DataColumn)))

                        End If

                    Next

                    DataSource.Add(Item)

                End If

            Next

            ConvertExportDataSourceToIEnumerable = DataSource

        End Function
        Private Function GetObjectData(ByVal RowData As Object) As Object

            'objects
            Dim ObjectData As Object = Nothing

            Try

                If TypeOf RowData Is System.DBNull Then

                    ObjectData = Nothing

                Else

                    ObjectData = RowData

                End If

            Catch ex As Exception
                ObjectData = Nothing
            End Try

            GetObjectData = ObjectData

        End Function
        Private Function CreateAnswersOnDemandFile(ByVal DataTable As System.Data.DataTable, ByVal ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)) As String

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Data As String = Nothing
            Dim LineData As String = Nothing
            Dim LastAccountPayableID As Integer = 0

            StringBuilder = New System.Text.StringBuilder

            ExportFields = ExportFields.Where(Function(Entity) Entity.Position >= 0).OrderBy(Function(Entity) Entity.Position).ToList

            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                If LastAccountPayableID = 0 OrElse LastAccountPayableID <> DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.AccountPayableID.ToString) Then

                    LastAccountPayableID = DataRow(AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.AccountPayableID.ToString)

                    LineData = ""

                    For Each ExportField In ExportFields.Where(Function(Field) Field.FieldName <> AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DetailRecordIdentifier.ToString AndAlso
                                                                               Field.FieldName <> AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString AndAlso
                                                                               Field.FieldName <> AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.NegativeDistributedAmount.ToString AndAlso
                                                                               Field.FieldName <> AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.PositiveDistributedAmount.ToString AndAlso
                                                                               Field.FieldName <> AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.SignIndicator.ToString)

                        Data = ""

                        If ExportField.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.InvoiceDate.ToString OrElse
                                ExportField.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DueDate.ToString Then

                            Data = CDate(GetRowData(DataRow(ExportField.FieldName))).ToString("MM/dd/yyyy")

                        Else

                            Data = GetRowData(DataRow(ExportField.FieldName))

                        End If

                        If Data.Contains(",") OrElse Data.Contains("""") Then

                            Data = """" & Data.Replace("""", """""") & """"

                        End If

                        If LineData = "" Then

                            LineData = Data

                        Else

                            LineData = LineData & "," & Data

                        End If

                    Next

                    StringBuilder.AppendLine(LineData)

                End If

                LineData = ""

                For Each ExportField In ExportFields.Where(Function(Field) Field.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DetailRecordIdentifier.ToString OrElse
                                                                           Field.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.DistributedGLAccount.ToString OrElse
                                                                           Field.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.NegativeDistributedAmount.ToString OrElse
                                                                           Field.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.PositiveDistributedAmount.ToString OrElse
                                                                           Field.FieldName = AdvantageFramework.Exporting.DataClasses.AccountPayableAnswersOnDemand.Properties.SignIndicator.ToString)

                    Data = ""

                    Data = GetRowData(DataRow(ExportField.FieldName))

                    If Data.Contains(",") OrElse Data.Contains("""") Then

                        Data = """" & Data.Replace("""", """""") & """"

                    End If

                    If LineData = "" Then

                        LineData = Data

                    Else

                        LineData = LineData & "," & Data

                    End If

                Next

                StringBuilder.AppendLine(LineData)

            Next

            CreateAnswersOnDemandFile = StringBuilder.ToString

        End Function

#Region " IRS 1099 File"

        Public Sub CreateIRS1099File(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PaymentYear As String, ByVal IsLastFiling As Boolean, ByVal IsTestFile As Boolean,
                                     ByVal EmployeeCode As String, ByVal FederalTaxID As String, ByVal IRSTCC As String, ByVal CombinedFederalStateFiler As Boolean,
                                     ByVal IsCorrectionFile As Boolean, ByVal OutputPath As String, ByVal IRS1099ProcessingList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing),
                                     ByVal FormType As AdvantageFramework.Exporting.Form1099)

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim FullFileName As String = Nothing
            Dim RecordSequence As Integer = 1
            Dim FileData As Text.StringBuilder = Nothing
            Dim RecordsForState As Integer = 0
            Dim Total1 As Long = 0
            Dim Total2 As Long = 0
            Dim Total3 As Long = 0
            Dim Total6 As Long = 0
            'Dim Total7 As Long = 0
            Dim TotalC As Long = 0
            Dim CompanyName As String = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim IRS1099FederalStateCodeList As Generic.List(Of AdvantageFramework.Database.Entities.IRS1099FederalStateCode) = Nothing
            Dim StateID As String = ""

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency Is Nothing Then

                Throw New Exception("Agency is not setup.")

            Else

                If String.IsNullOrEmpty(Agency.Name) OrElse String.IsNullOrEmpty(Agency.Address) OrElse String.IsNullOrEmpty(Agency.City) OrElse
                        String.IsNullOrEmpty(Agency.State) OrElse String.IsNullOrEmpty(Agency.Zip) Then

                    Throw New Exception("One or more of Agency Name, Address, City, State, Zip is missing.")

                End If

            End If

            CompanyName = Agency.Name

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_COMPANYNAME.ToString)

                If Setting IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(Setting.Value) = False Then

                        CompanyName = Setting.Value

                    End If

                End If

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_STATE_ID.ToString)

                If Setting IsNot Nothing Then

                    StateID = Mid(Setting.Value, 1, 15)

                End If

            End Using

            IRS1099FederalStateCodeList = AdvantageFramework.Database.Procedures.IRS1099FederalStateCode.Load(DbContext).ToList

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee Is Nothing Then

                Throw New Exception("Employee is not found.")

            Else

                If String.IsNullOrEmpty(Employee.WorkPhoneNumber) Then

                    Throw New Exception("Employee work telephone number is missing.")

                End If

            End If

            FileData = New Text.StringBuilder("")

            FileData.Append(CreateTRecord(PaymentYear, IsTestFile, IRS1099ProcessingList.Count, EmployeeCode, Agency, FederalTaxID, IRSTCC, Employee, CompanyName))
            RecordSequence += 1

            FileData.Append(CreateARecord(PaymentYear, IsLastFiling, Agency, RecordSequence, FederalTaxID, IRSTCC, CombinedFederalStateFiler, CompanyName, FormType))
            RecordSequence += 1

            For Each IRS1099Processing In IRS1099ProcessingList

                FileData.Append(CreateBRecord(PaymentYear, IsCorrectionFile, IRS1099Processing, RecordSequence, CombinedFederalStateFiler, IRS1099FederalStateCodeList, StateID, FormType))
                RecordSequence += 1

            Next

            FileData.Append(CreateCRecord(IRS1099ProcessingList.Count, RecordSequence, IRS1099ProcessingList, FormType))
            RecordSequence += 1

            If CombinedFederalStateFiler Then

                For Each IRS1099FederalStateCode In IRS1099FederalStateCodeList

                    RecordsForState = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode).Count

                    If RecordsForState <> 0 Then

                        Total1 = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.Rent).Sum(Function(EN) EN.TotalAmountPaid) * 100
                        Total2 = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.Royalties).Sum(Function(EN) EN.TotalAmountPaid) * 100
                        Total3 = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome).Sum(Function(EN) EN.TotalAmountPaid) * 100
                        Total6 = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare).Sum(Function(EN) EN.TotalAmountPaid) * 100
                        'Total7 = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation).Sum(Function(EN) EN.TotalAmountPaid) * 100
                        TotalC = IRS1099ProcessingList.Where(Function(EN) EN.PayToState = IRS1099FederalStateCode.StateCode AndAlso EN.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney).Sum(Function(EN) EN.TotalAmountPaid) * 100

                        FileData.Append(CreateKRecord(RecordsForState, RecordSequence, IRS1099FederalStateCode.FederalStateCode, Total1, Total2, Total3, Total6, "", TotalC))
                        RecordSequence += 1

                    End If

                Next

            End If

            FileData.Append(CreateFRecord(1, IRS1099ProcessingList.Count, RecordSequence))

            If FormType = Form1099.MISC Then

                FullFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(OutputPath, "\") & "1099MISC.txt"

            ElseIf FormType = Form1099.NEC Then

                FullFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(OutputPath, "\") & "1099NEC.txt"

            End If

            Try

                My.Computer.FileSystem.WriteAllText(FullFileName, FileData.ToString, False)

                AdvantageFramework.Navigation.ShowMessageBox(FullFileName & " created successfully.")

            Catch ex As Exception

                Throw New Exception("Problem creating file " & FullFileName)

            End Try

        End Sub
        Private Function CreateTRecord(ByVal PaymentYear As String, IsTestFile As Boolean,
                                       ByVal BRecordCount As Integer, EmployeeCode As String, Agency As AdvantageFramework.Database.Entities.Agency,
                                       ByVal FederalTaxID As String, IRSTCC As String, ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                       ByVal CompanyName As String) As String

            Dim ReturnValue As Text.StringBuilder = Nothing
            Dim Phone As String = Nothing

            ReturnValue = New Text.StringBuilder("T")

            ReturnValue.Append(PaymentYear)
            ReturnValue.Append(" ")
            ReturnValue.Append(FederalTaxID.ToUpper)
            ReturnValue.Append(IRSTCC.ToUpper)
            ReturnValue.Append(Space(7))
            ReturnValue.Append(If(IsTestFile, "T", " "))
            ReturnValue.Append(Space(1)) 'foreign entity indicator
            ReturnValue.Append(CompanyName.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Space(40))
            ReturnValue.Append(CompanyName.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Space(40))
            ReturnValue.Append(Agency.Address.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Agency.City.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Mid(Agency.State.ToString.ToUpper.Trim, 1, 2))
            ReturnValue.Append(Mid(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Agency.Zip.ToString.ToUpper), 1, 9).PadRight(9, " "))
            ReturnValue.Append(Space(15))
            ReturnValue.Append(BRecordCount.ToString.PadLeft(8, "0"))
            ReturnValue.Append(Mid(Employee.ToString.ToUpper, 1, 40).PadRight(40, " "))

            If String.IsNullOrEmpty(Employee.WorkPhoneNumberExtension) Then

                ReturnValue.Append(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.WorkPhoneNumber.ToString.ToUpper).PadRight(15, " "))

            Else

                ReturnValue.Append(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Employee.WorkPhoneNumber.ToString.ToUpper & Employee.WorkPhoneNumberExtension.ToString.ToUpper).PadRight(15, " "))

            End If

            If Not String.IsNullOrEmpty(Employee.Email) Then

                ReturnValue.Append(Employee.Email.ToString.ToUpper.PadRight(50, " "))

            Else

                ReturnValue.Append(Space(50))

            End If

            ReturnValue.Append(Space(91))
            ReturnValue.Append("00000001")
            ReturnValue.Append(Space(10))
            ReturnValue.Append("V")
            ReturnValue.Append("ADVANTAGE SOFTWARE".PadRight(40, " "))
            ReturnValue.Append("119 BACKSTRETCH LANE".PadRight(40, " "))
            ReturnValue.Append("MOORESVILLE".PadRight(40, " "))
            ReturnValue.Append("NC")
            ReturnValue.Append("28117".PadRight(9, " "))
            ReturnValue.Append("PROGRAMMING DEPARTMENT".PadRight(40, " "))
            ReturnValue.Append("7046629980".PadRight(15, " "))
            ReturnValue.Append(Space(35))
            ReturnValue.Append(Space(1))
            ReturnValue.Append(Space(8))
            ReturnValue.Append(vbCrLf)

            CreateTRecord = ReturnValue.ToString

        End Function
        Private Function CreateARecord(ByVal PaymentYear As String, ByVal IsLastFiling As Boolean, ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                       ByVal RecordSequence As Integer, ByVal FederalTaxID As String, ByVal IRSTCC As String, ByVal CombinedFederalStateFiler As Boolean,
                                       ByVal CompanyName As String, ByVal Form As AdvantageFramework.Exporting.Form1099) As String

            Dim ReturnValue As Text.StringBuilder = Nothing

            ReturnValue = New Text.StringBuilder("A")                       '1

            ReturnValue.Append(PaymentYear)                                 '2-5
            ReturnValue.Append(If(CombinedFederalStateFiler, "1", " "))     '6
            ReturnValue.Append(Space(5))                                    '7-11
            ReturnValue.Append(FederalTaxID)                                '12-20
            ReturnValue.Append(Space(4))                                    '21-24
            ReturnValue.Append(If(IsLastFiling, "1", " "))                  '25

            If Form = Form1099.MISC Then

                ReturnValue.Append("A ")                                    '26-27

            ElseIf Form = Form1099.NEC Then

                ReturnValue.Append("NE")                                    '26-27

            End If

            'hard-coded types based on possible vendor category
            If Form = Form1099.MISC Then

                ReturnValue.Append("1236C".ToString.PadRight(18, " "))      '28-45

            ElseIf Form = Form1099.NEC Then

                ReturnValue.Append("1".ToString.PadRight(18, " "))          '28-45

            End If

            ReturnValue.Append(Space(6)) '46-51
            ReturnValue.Append(Space(1))
            ReturnValue.Append(CompanyName.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Space(40))
            ReturnValue.Append("0") '133
            ReturnValue.Append(Agency.Address.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Agency.City.ToString.ToUpper.PadRight(40, " "))
            ReturnValue.Append(Mid(Agency.State.ToString.ToUpper.Trim, 1, 2))
            ReturnValue.Append(Mid(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(Agency.Zip.ToString.ToUpper), 1, 9).PadRight(9, " "))
            ReturnValue.Append(Space(15)) '225-239
            ReturnValue.Append(Space(260))
            ReturnValue.Append(RecordSequence.ToString.PadLeft(8, "0"))
            ReturnValue.Append(Space(241))
            ReturnValue.Append(vbCrLf)

            CreateARecord = ReturnValue.ToString

        End Function
        Private Function CreateBRecord(ByVal PaymentYear As String, ByVal IsCorrectionFile As Boolean, ByVal IRS1099Processing As AdvantageFramework.AccountPayable.Classes.IRS1099Processing,
                                       ByVal RecordSequence As Integer, ByVal CombinedFederalStateFiler As Boolean,
                                       IRS1099FederalStateCodeList As Generic.List(Of AdvantageFramework.Database.Entities.IRS1099FederalStateCode), StateID As String,
                                       ByVal Form As AdvantageFramework.Exporting.Form1099) As String

            Dim ReturnValue As Text.StringBuilder = Nothing
            Dim VendorStateCode As String = Nothing
            Dim PaymentAmount1 As Long = 0
            Dim PaymentAmount2 As Long = 0
            Dim PaymentAmount3 As Long = 0
            Dim PaymentAmount6 As Long = 0
            Dim PaymentAmount7 As Long = 0
            Dim PaymentAmountC As Long = 0
            Dim CombinedFederalStateCode As String = Nothing

            ReturnValue = New Text.StringBuilder("B")

            ReturnValue.Append(PaymentYear)
            ReturnValue.Append(If(IsCorrectionFile, "G", " ")) ' corrected return indicator
            ReturnValue.Append(Space(4)) '7-10
            ReturnValue.Append(Space(1))
            ReturnValue.Append(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(IRS1099Processing.FederalTaxID.ToUpper)) '12-20
            ReturnValue.Append(Space(20))
            ReturnValue.Append(Space(4))
            ReturnValue.Append(Space(10)) '45-54

            If Form = Form1099.NEC Then

                PaymentAmount1 = IRS1099Processing.TotalAmountPaid * 100

            ElseIf Form = Form1099.MISC Then

                Select Case IRS1099Processing.Vendor1099Category

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation

                        PaymentAmount7 = IRS1099Processing.TotalAmountPaid * 100

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome

                        PaymentAmount3 = IRS1099Processing.TotalAmountPaid * 100

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Rent

                        PaymentAmount1 = IRS1099Processing.TotalAmountPaid * 100

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Royalties

                        PaymentAmount2 = IRS1099Processing.TotalAmountPaid * 100

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney

                        PaymentAmountC = IRS1099Processing.TotalAmountPaid * 100

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare

                        PaymentAmount6 = IRS1099Processing.TotalAmountPaid * 100

                    Case Else

                        PaymentAmount7 = IRS1099Processing.TotalAmountPaid * 100

                End Select

            End If

            ReturnValue.Append(PaymentAmount1.ToString.PadLeft(12, "0")) '55-66
            ReturnValue.Append(PaymentAmount2.ToString.PadLeft(12, "0")) '67-78
            ReturnValue.Append(PaymentAmount3.ToString.PadLeft(12, "0")) '79-90
            ReturnValue.Append("000000000000") '4 91-102
            ReturnValue.Append("000000000000") '5 103-114
            ReturnValue.Append(PaymentAmount6.ToString.PadLeft(12, "0")) '115-126
            ReturnValue.Append(PaymentAmount7.ToString.PadLeft(12, "0")) '127-138
            ReturnValue.Append("000000000000") '8 139-150
            ReturnValue.Append("000000000000") '9 151-162
            ReturnValue.Append("000000000000") 'A 163-174
            ReturnValue.Append("000000000000") 'B 175-186
            ReturnValue.Append(PaymentAmountC.ToString.PadLeft(12, "0")) '187-198
            ReturnValue.Append("000000000000") 'D 199-210
            ReturnValue.Append("000000000000") 'E 211-222
            ReturnValue.Append("000000000000") 'F 223-234
            ReturnValue.Append("000000000000") 'G 235-246
            ReturnValue.Append("000000000000") 'H 247-258
            ReturnValue.Append("000000000000") 'J 259-270
            ReturnValue.Append(Space(16)) 'blank 271-286
            ReturnValue.Append(Space(1)) 'foreign country indicator 287
            ReturnValue.Append(IRS1099Processing.PayToName.ToString.ToUpper.PadRight(40, " ")) '288-327
            ReturnValue.Append(Space(40)) '328-367
            ReturnValue.Append(IRS1099Processing.PayToAddress.ToString.ToUpper.PadRight(40, " ")) '368-407
            ReturnValue.Append(Space(40)) '408-447 Blank
            ReturnValue.Append(IRS1099Processing.PayToCity.ToString.ToUpper.PadRight(40, " ")) '448-487

            VendorStateCode = IRS1099Processing.PayToState.ToString.ToUpper.PadRight(2, " ")

            ReturnValue.Append(VendorStateCode) '488-489

            ReturnValue.Append(Replace(IRS1099Processing.PayToZipCode.ToString.ToUpper, "-", "").PadRight(9, " ")) '490-498
            ReturnValue.Append(Space(1))
            ReturnValue.Append(RecordSequence.ToString.PadLeft(8, "0")) '500-507
            ReturnValue.Append(Space(36)) '508-543

            If CombinedFederalStateFiler Then

                Try

                    CombinedFederalStateCode = IRS1099FederalStateCodeList.Where(Function(FSC) FSC.StateCode = VendorStateCode).FirstOrDefault.FederalStateCode

                Catch ex As Exception
                    CombinedFederalStateCode = Nothing
                End Try

            End If

            If Form = Form1099.MISC Then '544-750 

                ReturnValue.Append(Space(1)) '544 second TIN notice
                ReturnValue.Append(Space(2)) '545-546 blank
                ReturnValue.Append(Space(1)) '547 direct sales indicator
                ReturnValue.Append(Space(1)) '548 FATCA filing indicator
                ReturnValue.Append(Space(114)) '549-662 blank
                ReturnValue.Append(Space(60)) '663-722 blank
                ReturnValue.Append("000000000000") '723-734
                ReturnValue.Append("000000000000") '735-746

                If CombinedFederalStateCode IsNot Nothing Then

                    ReturnValue.Append(CombinedFederalStateCode.ToUpper.PadLeft(2, "0")) '747-748 

                Else

                    ReturnValue.Append(Space(2)) '747-748 

                End If

            ElseIf Form = Form1099.NEC Then

                ReturnValue.Append(Space(1)) '544 second TIN notice
                ReturnValue.Append(Space(2)) '545-546 blank
                ReturnValue.Append(Space(1)) '547 direct sales indicator
                ReturnValue.Append(Space(175)) '548-722 blank 'IRS spec is wrong it says 173 spaces!
                ReturnValue.Append("000000000000") '723-734
                ReturnValue.Append("000000000000") '735-746

                If CombinedFederalStateCode IsNot Nothing Then

                    ReturnValue.Append(CombinedFederalStateCode.ToUpper.PadLeft(2, "0")) '747-748 

                ElseIf StateID.StartsWith("036") Then

                    ReturnValue.Append("55") '747-748 

                Else

                    ReturnValue.Append(Space(2)) '747-748 

                End If

            End If

            ReturnValue.Append(vbCrLf) '749-750 blank or CRLF

            CreateBRecord = ReturnValue.ToString

        End Function
        Private Function CreateCRecord(ByVal NumberOfBRecords As Integer, ByVal RecordSequence As Integer, ByVal IRS1099ProcessingList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099Processing),
                                       ByVal Form As AdvantageFramework.Exporting.Form1099) As String

            Dim ReturnValue As Text.StringBuilder = Nothing
            Dim PaymentAmount1 As Long = 0
            Dim PaymentAmount2 As Long = 0
            Dim PaymentAmount3 As Long = 0
            Dim PaymentAmount6 As Long = 0
            Dim PaymentAmount7 As Long = 0
            Dim PaymentAmountC As Long = 0
            Const EighteenZeros = "000000000000000000"

            ReturnValue = New Text.StringBuilder("C")

            ReturnValue.Append(NumberOfBRecords.ToString.PadLeft(8, "0"))
            ReturnValue.Append(Space(6)) '10-15 blank

            If Form = Form1099.NEC Then

                PaymentAmount1 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation).Sum(Function(E) E.TotalAmountPaid) * 100

            ElseIf Form = Form1099.MISC Then

                PaymentAmount1 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.Rent).Sum(Function(E) E.TotalAmountPaid) * 100
                PaymentAmount2 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.Royalties).Sum(Function(E) E.TotalAmountPaid) * 100
                PaymentAmount3 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome).Sum(Function(E) E.TotalAmountPaid) * 100
                PaymentAmount6 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare).Sum(Function(E) E.TotalAmountPaid) * 100
                PaymentAmount7 = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation).Sum(Function(E) E.TotalAmountPaid) * 100
                PaymentAmountC = IRS1099ProcessingList.Where(Function(E) E.Vendor1099Category = AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney).Sum(Function(E) E.TotalAmountPaid) * 100

            End If

            ReturnValue.Append(PaymentAmount1.ToString.PadLeft(18, "0")) '16-33
            ReturnValue.Append(PaymentAmount2.ToString.PadLeft(18, "0")) '34-51
            ReturnValue.Append(PaymentAmount3.ToString.PadLeft(18, "0")) '52-69
            ReturnValue.Append(EighteenZeros) '70-87
            ReturnValue.Append(EighteenZeros) '88-105
            ReturnValue.Append(PaymentAmount6.ToString.PadLeft(18, "0")) '106-123
            ReturnValue.Append(PaymentAmount7.ToString.PadLeft(18, "0")) '124-141
            ReturnValue.Append(EighteenZeros) '142-159
            ReturnValue.Append(EighteenZeros) '160-177
            ReturnValue.Append(EighteenZeros) '178-195
            ReturnValue.Append(EighteenZeros) '196-213
            ReturnValue.Append(PaymentAmountC.ToString.PadLeft(18, "0")) '214-231
            ReturnValue.Append(EighteenZeros) '232-249
            ReturnValue.Append(EighteenZeros) '250-267
            ReturnValue.Append(EighteenZeros) '268-285
            ReturnValue.Append(EighteenZeros) '286-303
            ReturnValue.Append(EighteenZeros) '304-321
            ReturnValue.Append(EighteenZeros) '322-339

            ReturnValue.Append(Space(160)) '340-499
            ReturnValue.Append(RecordSequence.ToString.PadLeft(8, "0")) '500-507
            ReturnValue.Append(Space(241)) '508-748
            ReturnValue.Append(vbCrLf) '749-750

            CreateCRecord = ReturnValue.ToString

        End Function
        Private Function CreateKRecord(ByVal NumberOfBRecordsForThisState As Integer, ByVal RecordSequence As Integer, ByVal IRSStateCode As Short, ByVal Total1 As String,
                                       ByVal Total2 As String, ByVal Total3 As String, ByVal Total6 As String, ByVal Total7 As String, ByVal TotalC As String) As String

            Dim ReturnValue As Text.StringBuilder = Nothing
            Const EighteenZeros = "000000000000000000"

            ReturnValue = New Text.StringBuilder("K")

            ReturnValue.Append(NumberOfBRecordsForThisState.ToString.PadLeft(8, "0"))
            ReturnValue.Append(Space(6)) '10-15 blank

            ReturnValue.Append(Total1.PadLeft(18, "0")) '16-33
            ReturnValue.Append(Total2.PadLeft(18, "0")) '34-51
            ReturnValue.Append(Total3.PadLeft(18, "0")) '52-69
            ReturnValue.Append(EighteenZeros) '70-87
            ReturnValue.Append(EighteenZeros) '88-105
            ReturnValue.Append(Total6.PadLeft(18, "0")) '106-123
            ReturnValue.Append(Total7.PadLeft(18, "0")) '124-141
            ReturnValue.Append(EighteenZeros) '142-159
            ReturnValue.Append(EighteenZeros) '160-177
            ReturnValue.Append(EighteenZeros) '178-195
            ReturnValue.Append(EighteenZeros) '196-213
            ReturnValue.Append(TotalC.PadLeft(18, "0")) '214-231
            ReturnValue.Append(EighteenZeros) '232-249
            ReturnValue.Append(EighteenZeros) '250-267
            ReturnValue.Append(EighteenZeros) '268-285
            ReturnValue.Append(EighteenZeros) '286-303
            ReturnValue.Append(EighteenZeros) '304-321
            ReturnValue.Append(EighteenZeros) '322-339

            ReturnValue.Append(Space(160)) '340-499
            ReturnValue.Append(RecordSequence.ToString.PadLeft(8, "0")) '500-507
            ReturnValue.Append(Space(199)) '508-706
            ReturnValue.Append(Space(18)) '707-724 state income tax
            ReturnValue.Append(Space(18)) '725-742 local income tax
            ReturnValue.Append(Space(4)) '743-746 blank
            ReturnValue.Append(IRSStateCode.ToString.PadLeft(2, "0")) ' combined federal/state code Part A Sec 10 Table 3

            ReturnValue.Append(vbCrLf) '749-750

            CreateKRecord = ReturnValue.ToString

        End Function
        Private Function CreateFRecord(ByVal NumberOfARecords As Integer, ByVal NumberOfBRecords As Integer, ByVal RecordSequence As Integer) As String

            Dim ReturnValue As Text.StringBuilder = Nothing

            ReturnValue = New Text.StringBuilder("F")

            ReturnValue.Append(NumberOfARecords.ToString.PadLeft(8, "0")) '2-9
            ReturnValue.Append("000000000000000000000") '10-30
            ReturnValue.Append(Space(19)) '31-49 blank
            ReturnValue.Append(NumberOfBRecords.ToString.PadLeft(8, "0")) '50-57
            ReturnValue.Append(Space(442)) '58-499
            ReturnValue.Append(RecordSequence.ToString.PadLeft(8, "0")) '500-507
            ReturnValue.Append(Space(241)) '508-748 blank
            ReturnValue.Append(vbCrLf) '749-750

            CreateFRecord = ReturnValue.ToString

        End Function

#End Region

#End Region

    End Module

End Namespace
