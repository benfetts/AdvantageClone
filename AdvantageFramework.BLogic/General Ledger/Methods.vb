Namespace GeneralLedger

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum BalanceTypes As Short
            Credit = 0
            Debit = 1
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function InsertGeneralLedger(ByRef GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PostPeriodCode As String,
                                            ByVal UserCode As String, ByVal Description As String, ByVal GLSourceCode As String, ByVal BatchDate As Nullable(Of Date),
                                            Optional GLDate As Nullable(Of Date) = Nothing) As Boolean

            'objects
            Dim GeneralLedgerInserted As Boolean = False

            Try

                GeneralLedger = New AdvantageFramework.Database.Entities.GeneralLedger
                GeneralLedger.DbContext = DbContext

                If GLDate.HasValue Then

                    GeneralLedger.EnteredDate = GLDate.Value.ToShortDateString
                    GeneralLedger.ModifiedDate = GLDate.Value.ToShortDateString

                Else

                    GeneralLedger.EnteredDate = Now.ToShortDateString
                    GeneralLedger.ModifiedDate = Now.ToShortDateString

                End If

                GeneralLedger.CreateDate = Now

                GeneralLedger.PostPeriodCode = PostPeriodCode
                GeneralLedger.UserCode = UserCode
                GeneralLedger.Description = Mid(Description, 1, 100)
                GeneralLedger.GLSourceCode = GLSourceCode
                GeneralLedger.BatchDate = BatchDate

                GeneralLedgerInserted = AdvantageFramework.Database.Procedures.GeneralLedger.Insert(DbContext, GeneralLedger)

            Catch ex As Exception
                GeneralLedgerInserted = False
            Finally
                InsertGeneralLedger = GeneralLedgerInserted
            End Try

        End Function
        Public Function InsertGeneralLedgerDetail(ByRef GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal GLTransaction As Integer, ByVal GLACode As String, ByVal CreditAmount As Double, ByVal Remark As String, ByVal GLSourceCode As String,
                                                  Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As Boolean

            'objects
            Dim GeneralLedgerDetailInserted As Boolean = False

            Try

                GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail
                GeneralLedgerDetail.DbContext = DbContext
                GeneralLedgerDetail.GLTransaction = GLTransaction
                GeneralLedgerDetail.GLACode = GLACode
                GeneralLedgerDetail.CreditAmount = CreditAmount
                GeneralLedgerDetail.DebitAmount = CreditAmount
                GeneralLedgerDetail.Remark = Mid(Remark, 1, 150)
                GeneralLedgerDetail.GLSourceCode = GLSourceCode
                GeneralLedgerDetail.ClientCode = If(Not String.IsNullOrWhiteSpace(ClientCode), ClientCode, Nothing)
                GeneralLedgerDetail.DivisionCode = If(Not String.IsNullOrWhiteSpace(DivisionCode), DivisionCode, Nothing)
                GeneralLedgerDetail.ProductCode = If(Not String.IsNullOrWhiteSpace(ProductCode), ProductCode, Nothing)
                GeneralLedgerDetailInserted = AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Insert(DbContext, GeneralLedgerDetail)

            Catch ex As Exception
                GeneralLedgerDetailInserted = False
            Finally
                InsertGeneralLedgerDetail = GeneralLedgerDetailInserted
            End Try

        End Function
        Public Sub CreateIntercompanyTransactions(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLACode1 As String, ByVal GLACode2 As String,
                                                  ByVal GLTransaction As Integer, ByVal Amount As Double, ByVal Remark As String, ByVal GLSourceCode As String,
                                                  ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                                  Optional ByRef DueFromGLACode As String = Nothing, Optional ByRef DueToGLACode As String = Nothing,
                                                  Optional ByRef DueFromSequenceNumber As Nullable(Of Short) = Nothing, Optional ByRef DueToSequenceNumber As Nullable(Of Short) = Nothing)

            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim InterCompanyCode As String = Nothing
            Dim OfficeCode As String = Nothing

            If OfficeDiffers(DbContext, GLACode1, GLACode2, InterCompanyCode, OfficeCode) Then

                Try

                    OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, OfficeCode)
                                          Where Entity.Code = InterCompanyCode
                                          Select Entity).SingleOrDefault

                Catch ex As Exception
                    Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                End Try

                If OfficeInterCompany Is Nothing Then

                    Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")

                End If

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                        Amount, Remark, GLSourceCode, ClientCode, DivisionCode, ProductCode) = False Then

                    Throw New Exception("Failed to insert into general ledger detail table.")

                End If

                DueFromSequenceNumber = GeneralLedgerDetail.SequenceNumber

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                        -Amount, Remark, GLSourceCode, ClientCode, DivisionCode, ProductCode) = False Then

                    Throw New Exception("Failed to insert into general ledger detail table.")

                End If

                DueToSequenceNumber = GeneralLedgerDetail.SequenceNumber

                DueFromGLACode = OfficeInterCompany.DueFromGLACode
                DueToGLACode = OfficeInterCompany.DueToGLACode

            End If

        End Sub
        Public Sub ReverseInterCompanyTransaction(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal GLTransaction As Integer, ByVal Amount As Double, ByVal Remark As String, ByVal GLSourceCode As String,
                                                  ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                                  ByVal DueFromGLACode As String, ByVal DueToGLACode As String,
                                                  ByRef DueFromSequenceNumber As Nullable(Of Short), ByRef DueToSequenceNumber As Nullable(Of Short))

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, DueFromGLACode,
                    Amount, Remark, GLSourceCode, ClientCode, DivisionCode, ProductCode) = False Then

                Throw New Exception("Problem inserting General Ledger Detail.")

            End If

            DueFromSequenceNumber = GeneralLedgerDetail.SequenceNumber

            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, DueToGLACode,
                    -Amount, Remark, GLSourceCode, ClientCode, DivisionCode, ProductCode) = False Then

                Throw New Exception("Problem inserting General Ledger Detail.")

            End If

            DueToSequenceNumber = GeneralLedgerDetail.SequenceNumber

        End Sub
        Public Function SubstituteOfficeDepartmentSegments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal GeneralLedgerAccountCode As String, ByVal OfficeCode As String, ByVal DepartmentTeamCode As String) As AdvantageFramework.Database.Entities.GeneralLedgerAccount

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountNew As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerAccountCode)
            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, OfficeCode)
            GeneralLedgerDepartmentTeamCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.LoadByDepartmentTeamCode(DbContext, DepartmentTeamCode)

            If GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference IsNot Nothing Then

                If GeneralLedgerDepartmentTeamCrossReference IsNot Nothing Then

                    GeneralLedgerAccountNew = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                               Where GL.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code AndAlso
                                                     GL.DepartmentCode = GeneralLedgerDepartmentTeamCrossReference.Code AndAlso
                                                     GL.BaseCode = GeneralLedgerAccount.BaseCode AndAlso
                                                     (GeneralLedgerAccount.OtherCode Is Nothing OrElse GL.OtherCode = GeneralLedgerAccount.OtherCode)
                                               Select GL).SingleOrDefault

                Else

                    GeneralLedgerAccountNew = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                               Where GL.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code AndAlso
                                                     GL.DepartmentCode = GeneralLedgerAccount.DepartmentCode AndAlso
                                                     GL.BaseCode = GeneralLedgerAccount.BaseCode AndAlso
                                                     (GeneralLedgerAccount.OtherCode Is Nothing OrElse GL.OtherCode = GeneralLedgerAccount.OtherCode)
                                               Select GL).SingleOrDefault

                End If

            End If

            SubstituteOfficeDepartmentSegments = GeneralLedgerAccountNew

        End Function
        Public Function GetGeneralLedgerConfigDelimiter(ByVal SegmentAfter As Nullable(Of Long)) As String

            Dim Delimiter As String = Nothing

            If SegmentAfter.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentAfter.Hyphen Then

                Delimiter = "-"

            ElseIf SegmentAfter.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentAfter.Period Then

                Delimiter = "."

            End If

            GetGeneralLedgerConfigDelimiter = Delimiter

        End Function
        Public Function GetGeneralLedgerConfigMaxLengthBySegmentType(ByVal Session As AdvantageFramework.Security.Session, ByVal SegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType) As Long

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

            End Using

            If GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = SegmentType AndAlso GeneralLedgerConfig.Segment1Format IsNot Nothing Then

                GetGeneralLedgerConfigMaxLengthBySegmentType = GeneralLedgerConfig.Segment1Format.Length

            ElseIf GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = SegmentType AndAlso GeneralLedgerConfig.Segment2Format IsNot Nothing Then

                GetGeneralLedgerConfigMaxLengthBySegmentType = GeneralLedgerConfig.Segment2Format.Length

            ElseIf GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = SegmentType AndAlso GeneralLedgerConfig.Segment3Format IsNot Nothing Then

                GetGeneralLedgerConfigMaxLengthBySegmentType = GeneralLedgerConfig.Segment3Format.Length

            ElseIf GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = SegmentType AndAlso GeneralLedgerConfig.Segment4Format IsNot Nothing Then

                GetGeneralLedgerConfigMaxLengthBySegmentType = GeneralLedgerConfig.Segment4Format.Length

            Else

                GetGeneralLedgerConfigMaxLengthBySegmentType = 0

            End If

        End Function
        Public Function GeneralLedgerConfigRequiresSegment(ByVal Session As AdvantageFramework.Security.Session,
                                                           ByVal SegmentType As AdvantageFramework.Database.Entities.GeneralLedgerConfigSegmentType,
                                                           ByRef SegmentFormat As String) As Boolean

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim SeqmentRequired As Boolean = False

            SegmentFormat = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                If GeneralLedgerConfig.Segment1Format IsNot Nothing AndAlso GeneralLedgerConfig.Segment1Type.GetValueOrDefault(0) = SegmentType Then

                    SeqmentRequired = True
                    SegmentFormat = GeneralLedgerConfig.Segment1Format

                ElseIf GeneralLedgerConfig.Segment2Format IsNot Nothing AndAlso GeneralLedgerConfig.Segment2Type.GetValueOrDefault(0) = SegmentType Then

                    SeqmentRequired = True
                    SegmentFormat = GeneralLedgerConfig.Segment2Format

                ElseIf GeneralLedgerConfig.Segment3Format IsNot Nothing AndAlso GeneralLedgerConfig.Segment3Type.GetValueOrDefault(0) = SegmentType Then

                    SeqmentRequired = True
                    SegmentFormat = GeneralLedgerConfig.Segment3Format

                ElseIf GeneralLedgerConfig.Segment4Format IsNot Nothing AndAlso GeneralLedgerConfig.Segment4Type.GetValueOrDefault(0) = SegmentType Then

                    SeqmentRequired = True
                    SegmentFormat = GeneralLedgerConfig.Segment4Format

                End If

                GeneralLedgerConfigRequiresSegment = SeqmentRequired

            End Using

        End Function
        Public Function SubstituteOfficeSegment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal GeneralLedgerAccountCode As String,
                                                ByVal OfficeSegment As String) As AdvantageFramework.Database.Entities.GeneralLedgerAccount

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountNew As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerAccountCode)

            If GeneralLedgerAccount IsNot Nothing Then

                GeneralLedgerAccountNew = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                           Where GL.GeneralLedgerOfficeCrossReferenceCode = OfficeSegment AndAlso
                                                 GL.BaseCode = GeneralLedgerAccount.BaseCode AndAlso
                                                 (GeneralLedgerAccount.DepartmentCode Is Nothing OrElse GL.DepartmentCode = GeneralLedgerAccount.DepartmentCode) AndAlso
                                                 (GeneralLedgerAccount.OtherCode Is Nothing OrElse GL.OtherCode = GeneralLedgerAccount.OtherCode)
                                           Select GL).SingleOrDefault

            End If

            SubstituteOfficeSegment = GeneralLedgerAccountNew

        End Function
        Public Sub ReplaceOfficeSegment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByRef GeneralLedgerAccountCode As String,
                                        ByVal OfficeSegment As String)

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountNew As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerAccountCode)

            If GeneralLedgerAccount IsNot Nothing Then

                GeneralLedgerAccountNew = (From GL In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                           Where GL.GeneralLedgerOfficeCrossReferenceCode = OfficeSegment AndAlso
                                                 GL.BaseCode = GeneralLedgerAccount.BaseCode AndAlso
                                                 (GeneralLedgerAccount.DepartmentCode Is Nothing OrElse GL.DepartmentCode = GeneralLedgerAccount.DepartmentCode) AndAlso
                                                 (GeneralLedgerAccount.OtherCode Is Nothing OrElse GL.OtherCode = GeneralLedgerAccount.OtherCode)
                                           Select GL).SingleOrDefault

                If GeneralLedgerAccountNew IsNot Nothing Then

                    GeneralLedgerAccountCode = GeneralLedgerAccountNew.Code

                End If

            End If

        End Sub
        Public Function OfficeDiffers(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLACode1 As String, ByVal GLACode2 As String,
                                      ByRef OfficeCode1 As String, ByRef OfficeCode2 As String) As Boolean

            Dim IsDifferentOffice As Boolean = False
            Dim GeneralLedgerAccount1 As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccount2 As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            GeneralLedgerAccount1 = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode1)
            GeneralLedgerAccount2 = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode2)

            If GeneralLedgerAccount1 IsNot Nothing AndAlso GeneralLedgerAccount2 IsNot Nothing AndAlso
                    String.IsNullOrWhiteSpace(GeneralLedgerAccount1.GeneralLedgerOfficeCrossReferenceCode) = False AndAlso String.IsNullOrWhiteSpace(GeneralLedgerAccount2.GeneralLedgerOfficeCrossReferenceCode) = False Then

                If GeneralLedgerAccount1.GeneralLedgerOfficeCrossReferenceCode <> GeneralLedgerAccount2.GeneralLedgerOfficeCrossReferenceCode Then

                    IsDifferentOffice = True

                    OfficeCode1 = GeneralLedgerAccount1.GeneralLedgerOfficeCrossReference.OfficeCode
                    OfficeCode2 = GeneralLedgerAccount2.GeneralLedgerOfficeCrossReference.OfficeCode

                End If

            End If

            OfficeDiffers = IsDifferentOffice

        End Function

#Region "  Import Journal Entry "

        Public Sub JournalEntryAddEntityToList(DbContext As AdvantageFramework.Database.DbContext,
                                               ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry,
                                               ByRef ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry),
                                               ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes)

            Dim ImportJournalEntryHeader As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader = Nothing
            Dim GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext).ToList

            ImportJournalEntryHeader = New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader(ImportJournalEntry, ImportTemplateType, GeneralLedgerAccounts)

            If ImportJournalEntry.ImportJournalEntryDetails.Any Then

                For Each ImportJournalEntryDetail In ImportJournalEntry.ImportJournalEntryDetails

                    ImportJournalEntryList.Add(New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry(ImportJournalEntryHeader, New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail(ImportJournalEntryDetail, GeneralLedgerAccounts)))

                Next

            End If

        End Sub
        Public Sub ValidateAllEntities(DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session,
                                       ByRef ImportJournalEntryList As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry))

            Dim HeaderIDs As IEnumerable(Of Integer) = Nothing
            Dim ImportJournalEntryHeader As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader = Nothing
            Dim IsValid As Boolean = True
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim GeneralLedgerSourceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource) = Nothing

            If ImportJournalEntryList IsNot Nothing AndAlso ImportJournalEntryList.Count > 0 Then

                HeaderIDs = (From Entity In ImportJournalEntryList
                             Select Entity.ID).Distinct.ToList

                PostPeriodList = AdvantageFramework.GeneralLedger.GetValidPostPeriods(DbContext)

                GeneralLedgerSourceList = AdvantageFramework.GeneralLedger.GetValidGeneralLedgerSources(DbContext, ImportJournalEntryList.First.ImportTemplateType)

                For Each HeaderID In HeaderIDs

                    ImportJournalEntryHeader = ImportJournalEntryList.Where(Function(IJE) IJE.ID = HeaderID).FirstOrDefault.ImportJournalEntryHeader

                    ImportJournalEntryHeader.DbContext = DbContext
                    ImportJournalEntryHeader.PostPeriodList = PostPeriodList
                    ImportJournalEntryHeader.GeneralLedgerSourceList = GeneralLedgerSourceList

                    ImportJournalEntryHeader.ValidateEntity(IsValid)

                Next

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList
                    GeneralLedgerAccountList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session).ToList
                    ClientList = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList
                    DivisionList = AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList
                    ProductList = AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext).ToList

                    For Each IJE In ImportJournalEntryList

                        IsValid = True

                        IJE.ImportJournalEntryDetail.DbContext = DbContext
                        IJE.ImportJournalEntryDetail.PropertyDescriptors = PropertyDescriptors
                        IJE.ImportJournalEntryDetail.GeneralLedgerAccountList = GeneralLedgerAccountList
                        IJE.ImportJournalEntryDetail.ClientList = ClientList
                        IJE.ImportJournalEntryDetail.DivisionList = DivisionList
                        IJE.ImportJournalEntryDetail.ProductList = ProductList

                        IJE.ImportJournalEntryDetail.ValidateEntity(IsValid)

                    Next

                End Using

                For Each IJE In ImportJournalEntryList

                    IJE.RefreshErrorHashtable()

                Next

            End If

        End Sub
        Public Function GetValidPostPeriods(DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)

            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveOrFutureGLPostPeriods(DbContext).ToList

            GetValidPostPeriods = PostPeriods

        End Function
        Public Function GetValidGeneralLedgerSources(DbContext As AdvantageFramework.Database.DbContext, ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource)

            Dim GLSourceCodes As IEnumerable(Of String) = Nothing
            Dim GeneralLedgerSources As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource) = Nothing

            If ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default Then

                GLSourceCodes = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.GLSourceStandard))
                                 Select Entity.Code).ToArray

            ElseIf ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE Then

                GLSourceCodes = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.GLSourceMOGLIFACE))
                                 Select Entity.Code).ToArray

            End If

            GeneralLedgerSources = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerSource.Load(DbContext)
                                    Where GLSourceCodes.Contains(Entity.Code)
                                    Select Entity).ToList

            GetValidGeneralLedgerSources = GeneralLedgerSources

        End Function

#End Region

#Region "  General Ledger Mapping Export "

        Public Function SyncMappingExportAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecordSourceID As Integer) As Boolean

            'objects
            Dim Synced As Boolean = False
            Dim RecordSourceIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                RecordSourceIDSqlParameter = New System.Data.SqlClient.SqlParameter("@RECORD_SOURCE_ID", SqlDbType.Int) With {.Value = RecordSourceID}

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_gl_xref_export_sync] @RECORD_SOURCE_ID", RecordSourceIDSqlParameter)

                Synced = True

            Catch ex As Exception
                Synced = False
            End Try

            SyncMappingExportAccounts = Synced

        End Function

#End Region

#Region "  General Ledger Reports "

        Public Function LoadGeneralLedgerReportsOffices(ByVal Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext) As Generic.Dictionary(Of String, AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference)

            'objects
            Dim Codes As Generic.List(Of String) = Nothing
            Dim GeneralLedgerOfficeCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing

            If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Any Then

                GeneralLedgerOfficeCrossReferenceList = (From EmpOffice In AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Session)
                                                         Join GlOffice In AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadOrderByOffice(DbContext).Include("Office") On EmpOffice.Code Equals GlOffice.OfficeCode
                                                         Select GlOffice).ToList

                Codes = GeneralLedgerOfficeCrossReferenceList.Select(Function(glx) glx.Code).ToList

            Else

                Codes = (From Item In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                         Select Item.GeneralLedgerOfficeCrossReferenceCode).Distinct.ToList

                GeneralLedgerOfficeCrossReferenceList = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadOrderByOffice(DbContext).Include("Office").ToList

            End If

            Return (From Code In Codes
                    Group Join Item In GeneralLedgerOfficeCrossReferenceList On Code Equals Item.Code Into Group
                    From GlxOff In Group.DefaultIfEmpty
                    Select New With {.Code = Code,
                                     .CrossReference = GlxOff}).ToDictionary(Function(g) g.Code, Function(g) g.CrossReference)

        End Function
        Public Function LoadGeneralLedgerReportsDepartments(ByVal DbContext) As Generic.Dictionary(Of String, AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference)

            'objects
            Dim Codes As Generic.List(Of String) = Nothing
            Dim GeneralLedgerDepartmentTeamCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDepartmentTeamCrossReference) = Nothing

            Codes = (From Item In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                     Select Item.DepartmentCode).Distinct.ToList

            GeneralLedgerDepartmentTeamCrossReferenceList = (From Item In AdvantageFramework.Database.Procedures.GeneralLedgerDepartmentTeamCrossReference.Load(DbContext).Include("DepartmentTeam")
                                                             Select Item).ToList

            Return (From Code In Codes
                    Group Join Item In GeneralLedgerDepartmentTeamCrossReferenceList On Code Equals Item.Code Into Group
                    From GlxDept In Group.DefaultIfEmpty
                    Select New With {.Code = Code,
                                     .CrossReference = GlxDept}).ToDictionary(Function(g) g.Code, Function(g) g.CrossReference)

        End Function

#End Region

#End Region

    End Module

End Namespace