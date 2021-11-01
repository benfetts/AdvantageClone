Namespace AccountReceivable

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub FillAccountReceivableEntityFromAccountReceivableImportStaging(ByRef AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable,
                                                                                  ByVal AccountReceivableImportStaging As AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging,
                                                                                  ByVal CreateDate As Date, ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate)


            AccountReceivable.ClientCode = AccountReceivableImportStaging.ClientCode
            AccountReceivable.DivisionCode = AccountReceivableImportStaging.DivisionCode
            AccountReceivable.ProductCode = AccountReceivableImportStaging.ProductCode
            AccountReceivable.OfficeCode = AccountReceivableImportStaging.OfficeCode

            AccountReceivable.InvoiceDate = AccountReceivableImportStaging.InvoiceDate
            AccountReceivable.Description = AccountReceivableImportStaging.ImportARInvoiceNumber

            AccountReceivable.GLACodeAR = AccountReceivableImportStaging.GLACodeAR
            AccountReceivable.InvoiceAmount = AccountReceivableImportStaging.InvoiceAmount

            AccountReceivable.GLACodeCity = AccountReceivableImportStaging.GLACodeCity
            AccountReceivable.CityAmount = AccountReceivableImportStaging.CityAmount

            AccountReceivable.CostOfSalesGLACode = AccountReceivableImportStaging.GLACodeCOS
            AccountReceivable.CostOfSalesAmount = AccountReceivableImportStaging.CostOfSalesAmount

            AccountReceivable.GLACodeCounty = AccountReceivableImportStaging.GLACodeCounty
            AccountReceivable.CountyAmount = AccountReceivableImportStaging.CountyAmount

            AccountReceivable.GLACodeOffset = AccountReceivableImportStaging.GLACodeOffset
            AccountReceivable.OffsetAmount = AccountReceivableImportStaging.OffsetAmount

            AccountReceivable.GLACodeSales = AccountReceivableImportStaging.GLACodeSales
            AccountReceivable.SaleAmount = AccountReceivableImportStaging.SaleAmount

            AccountReceivable.GLACodeState = AccountReceivableImportStaging.GLACodeState
            AccountReceivable.StateAmount = AccountReceivableImportStaging.StateAmount

            If ImportTemplate IsNot Nothing AndAlso ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom Then

                AccountReceivable.SalesClassCode = Nothing

            Else

                AccountReceivable.SalesClassCode = AccountReceivableImportStaging.SalesClassCode

            End If

            AccountReceivable.ProductPONumber = AccountReceivableImportStaging.ClientPO

            AccountReceivable.IsManualInvoice = 1

            AccountReceivable.CreateDate = CreateDate
            AccountReceivable.AdvanceAmount = 0
            AccountReceivable.RecordType = AccountReceivableImportStaging.RecordType
            AccountReceivable.IsImportedInvoice = 1
            AccountReceivable.BatchName = AccountReceivableImportStaging.AccountReceivableImportStaging.BatchName

            If AccountReceivable.RecordType = "P" Then

                AccountReceivable.InvoiceType = 1

            ElseIf AccountReceivable.RecordType = "I" OrElse AccountReceivable.RecordType = "M" OrElse AccountReceivable.RecordType = "N" OrElse
                    AccountReceivable.RecordType = "O" OrElse AccountReceivable.RecordType = "R" OrElse AccountReceivable.RecordType = "T" Then

                AccountReceivable.InvoiceType = 2

            End If

            AccountReceivable.DueDate = AccountReceivableImportStaging.DueDate

        End Sub
        Public Sub CreateARGeneralLedgerEntries(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal GLSourceCode As String,
                                                 ByRef AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable,
                                                ByVal BatchDate As Date,
                                                ByVal AddingFromImport As Boolean)

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim GLDescription As String = Nothing

            If AddingFromImport Then

                GLDescription = "A/R Import Invoice Number: " & AccountReceivable.Description

            Else

                GLDescription = ""

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountReceivable.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                Throw New Exception("Failed trying to save data to General Ledger.")

            End If

            AccountReceivable.GLTransaction = GeneralLedger.Transaction

            If AccountReceivable.GLACodeAR IsNot Nothing AndAlso AccountReceivable.InvoiceAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeAR,
                        AccountReceivable.InvoiceAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberAR = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeSales IsNot Nothing AndAlso AccountReceivable.SaleAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeSales,
                        -AccountReceivable.SaleAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberSales = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeDeferredSales IsNot Nothing AndAlso AccountReceivable.DeferredSaleAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeDeferredSales,
                        -AccountReceivable.DeferredSaleAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberDeferredSales = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.CostOfSalesGLACode IsNot Nothing AndAlso AccountReceivable.CostOfSalesAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.CostOfSalesGLACode,
                        AccountReceivable.CostOfSalesAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberCOS = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeOffset IsNot Nothing AndAlso AccountReceivable.OffsetAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeOffset,
                        -AccountReceivable.OffsetAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberOffset = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeState IsNot Nothing AndAlso AccountReceivable.StateAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeState,
                        -AccountReceivable.StateAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberState = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeCounty IsNot Nothing AndAlso AccountReceivable.CountyAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeCounty,
                        -AccountReceivable.CountyAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberCounty = GeneralLedgerDetail.SequenceNumber

            End If

            If AccountReceivable.GLACodeCity IsNot Nothing AndAlso AccountReceivable.CityAmount.GetValueOrDefault(0) <> 0 Then

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, AccountReceivable.GLTransaction, AccountReceivable.GLACodeCity,
                        -AccountReceivable.CityAmount, GLDescription, GLSourceCode, AccountReceivable.ClientCode, AccountReceivable.DivisionCode, AccountReceivable.ProductCode) = False Then

                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                End If

                AccountReceivable.GLSequenceNumberCity = GeneralLedgerDetail.SequenceNumber

            End If

        End Sub
        Public Function CreateAccountsReceivableFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal AccountReceivableImportStagings As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging),
                                                           ByVal PostPeriodCode As String,
                                                           ByVal BatchDate As Date) As Boolean

            'objects
            Dim Created As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim GLSourceCode As String = Nothing
            Dim IsBalanced As Integer = 0
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            'Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing
            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim Offices As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing
            Dim DistinctARDescriptions As Generic.List(Of String) = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            Try

                DbContext.Configuration.AutoDetectChangesEnabled = False

                Clients = GetActiveClients(DbContext)
                Divisions = GetActiveDivisions(DbContext)
                Products = GetActiveProducts(DbContext)
                GeneralLedgerAccounts = GetActiveGeneralLedgerAccounts(DbContext)
                'GeneralLedgerOfficeCrossReferences = GetGeneralLedgerOfficeCrossReferences(DbContext)
                SalesClasses = GetActiveSalesClasses(DbContext)
                Offices = GetActiveOffices(DbContext)
                DistinctARDescriptions = GetDistinctARDescriptions(DbContext)

                GLSourceCode = "MI"

                If AccountReceivableImportStagings IsNot Nothing AndAlso AccountReceivableImportStagings.Count > 0 Then

                    If AccountReceivableImportStagings.FirstOrDefault.AccountReceivableImportStaging.ImportTemplateID.HasValue Then

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, AccountReceivableImportStagings.FirstOrDefault.AccountReceivableImportStaging.ImportTemplateID)

                    End If

                End If

                For Each AccountReceivableImportStaging In AccountReceivableImportStagings

                    If PropertyDescriptors Is Nothing Then

                        PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(AccountReceivableImportStaging).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                    End If

                    IsValid = True

                    AccountReceivableImportStaging.DbContext = DbContext

                    AccountReceivableImportStaging.PropertyDescriptors = PropertyDescriptors
                    AccountReceivableImportStaging.Clients = Clients
                    AccountReceivableImportStaging.Divisions = Divisions
                    AccountReceivableImportStaging.Products = Products
                    AccountReceivableImportStaging.GeneralLedgerAccounts = GeneralLedgerAccounts
                    'AccountReceivableImportStaging.GeneralLedgerOfficeCrossReferences = GeneralLedgerOfficeCrossReferences
                    AccountReceivableImportStaging.SalesClasses = SalesClasses
                    AccountReceivableImportStaging.Offices = Offices
                    AccountReceivableImportStaging.DistinctARDescriptions = DistinctARDescriptions
                    AccountReceivableImportStaging.SetRequiredFields()

                    If AccountReceivableImportStaging.IsOnHold = False Then

                        AccountReceivableImportStaging.CustomValidateEntity(IsValid)

                        If IsValid Then

                            Try

                                AccountReceivable = New AdvantageFramework.Database.Entities.AccountReceivable

                                DbContext.Database.Connection.Open()

                                DbTransaction = DbContext.Database.BeginTransaction

                                AccountReceivable.DbContext = DbContext
                                AccountReceivable.Type = "IN"
                                AccountReceivable.PostPeriodCode = PostPeriodCode
                                AccountReceivable.UserCode = DbContext.UserCode

                                FillAccountReceivableEntityFromAccountReceivableImportStaging(AccountReceivable, AccountReceivableImportStaging, BatchDate, ImportTemplate)

                                CreateARGeneralLedgerEntries(DbContext, GLSourceCode, AccountReceivable, BatchDate, True)

                                If AdvantageFramework.Database.Procedures.AccountReceivable.Insert(DbContext, AccountReceivable) = False Then

                                    Throw New Exception("Insert to ACCT REC failed.")

                                End If

                                IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ar_invoice_balanced] {0},{1},'{2}',{3}", AccountReceivable.InvoiceNumber, AccountReceivable.SequenceNumber, AccountReceivable.Type, AccountReceivable.GLTransaction)).FirstOrDefault

                                If IsBalanced = 1 Then

                                    If AdvantageFramework.Database.Procedures.AccountReceivableImportStaging.Delete(DbContext, AccountReceivableImportStaging.AccountReceivableImportStaging) Then

                                        DbTransaction.Commit()

                                    Else

                                        Throw New Exception("Cannot save.  Failed to delete staging record.")

                                    End If

                                Else

                                    Throw New Exception("Cannot save.  AR out of balance.")

                                End If

                            Catch ex As Exception

                                DbTransaction.Rollback()
                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                ErrorMessage += vbCrLf & ex.Message

                                Throw ex

                            Finally

                                If DbContext.Database.Connection.State = ConnectionState.Open Then

                                    DbContext.Database.Connection.Close()

                                End If

                            End Try

                        Else

                            Created = False

                        End If

                    End If

                Next

            Catch ex As Exception
                Created = False
            Finally
                DbContext.Configuration.AutoDetectChangesEnabled = True
            End Try

            CreateAccountsReceivableFromImport = Created

        End Function
        Public Sub ValidateAllEntities(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ImportAccountReceivableStagingList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging))

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            'Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing
            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim Offices As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing
            Dim DistinctARDescriptions As Generic.List(Of String) = Nothing
            Dim IsValid As Boolean = True

            Clients = GetActiveClients(DbContext)
            Divisions = GetActiveDivisions(DbContext)
            Products = GetActiveProducts(DbContext)
            GeneralLedgerAccounts = GetActiveGeneralLedgerAccounts(DbContext)
            'GeneralLedgerOfficeCrossReferences = GetGeneralLedgerOfficeCrossReferences(DbContext)
            SalesClasses = GetActiveSalesClasses(DbContext)
            DistinctARDescriptions = GetDistinctARDescriptions(DbContext)
            Offices = GetActiveOffices(DbContext)

            For Each ImportAccountReceivableStaging In ImportAccountReceivableStagingList

                If PropertyDescriptors Is Nothing Then

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(ImportAccountReceivableStaging).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                End If

                ImportAccountReceivableStaging.DbContext = DbContext
                ImportAccountReceivableStaging.PropertyDescriptors = PropertyDescriptors
                ImportAccountReceivableStaging.Clients = Clients
                ImportAccountReceivableStaging.Divisions = Divisions
                ImportAccountReceivableStaging.Products = Products
                ImportAccountReceivableStaging.GeneralLedgerAccounts = GeneralLedgerAccounts
                'ImportAccountReceivableStaging.GeneralLedgerOfficeCrossReferences = GeneralLedgerOfficeCrossReferences
                ImportAccountReceivableStaging.SalesClasses = SalesClasses
                ImportAccountReceivableStaging.Offices = Offices
                ImportAccountReceivableStaging.DistinctARDescriptions = DistinctARDescriptions
                ImportAccountReceivableStaging.SetRequiredFields()

                ImportAccountReceivableStaging.EntityError = ImportAccountReceivableStaging.CustomValidateEntity(IsValid)

            Next

        End Sub
        Public Function GetActiveClients(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Core.Client)

            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing

            Clients = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)
                       Where Entity.IsActive = 1
                       Select Entity).ToList

            GetActiveClients = Clients

        End Function
        Public Function GetActiveDivisions(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Core.Division)

            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing

            Divisions = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                         Where Entity.IsActive = 1
                         Select Entity).ToList

            GetActiveDivisions = Divisions

        End Function
        Public Function GetActiveProducts(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Core.Product)

            Dim Products As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing

            Products = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                        Where Entity.IsActive = 1
                        Select Entity).ToList

            GetActiveProducts = Products

        End Function
        Public Function GetActiveGeneralLedgerAccounts(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing

            GeneralLedgerAccounts = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext)
                                     Where Entity.Active = "A"
                                     Select Entity).ToList

            GetActiveGeneralLedgerAccounts = GeneralLedgerAccounts

        End Function
        Public Function GetGeneralLedgerOfficeCrossReferences(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference)

            Dim GeneralLedgerOfficeCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing

            GeneralLedgerOfficeCrossReferences = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Load(DbContext)
                                                  Select Entity).ToList

            GetGeneralLedgerOfficeCrossReferences = GeneralLedgerOfficeCrossReferences

        End Function
        Public Function GetActiveSalesClasses(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

            SalesClasses = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                            Select Entity).ToList

            GetActiveSalesClasses = SalesClasses

        End Function
        Public Function GetActiveSalesClassesByRecordType(ByVal ActiveSalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass), ByVal RecordType As String) As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            'objects
            Dim SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim SalesClassTypeCodes As Generic.List(Of String) = Nothing

            SalesClassTypeCodes = New Generic.List(Of String)

            If RecordType = "M" Then

                SalesClassTypeCodes.AddRange({"I", "M", "N", "O", "R", "T"})

                SalesClasses = (From Entity In ActiveSalesClasses
                                Where SalesClassTypeCodes.Contains(Entity.SalesClassTypeCode) OrElse
                                      Entity.SalesClassTypeCode Is Nothing
                                Select Entity).ToList

            ElseIf RecordType = "P" Then

                SalesClasses = (From Entity In ActiveSalesClasses
                                Where Entity.SalesClassTypeCode = "P" OrElse
                                      Entity.SalesClassTypeCode Is Nothing
                                Select Entity).ToList

            Else

                SalesClasses = (From Entity In ActiveSalesClasses
                                Select Entity).ToList

            End If

            GetActiveSalesClassesByRecordType = SalesClasses

        End Function
        Public Function GetOfficesByEmployee(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Core.Office)

            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim EmployeeOffices As IEnumerable(Of String) = Nothing
            Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Session.UserCode)

                    EmployeeOffices = (From Entity In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode)
                                       Select Entity.OfficeCode).ToList

                    If EmployeeOffices.Count = 0 Then

                        OfficeList = AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext).ToList

                    Else

                        OfficeList = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                                      Where EmployeeOffices.Contains(Entity.Code)
                                      Select Entity).ToList

                    End If

                End Using

            End Using

            GetOfficesByEmployee = OfficeList

        End Function
        Public Function GetActiveOffices(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Core.Office)

            'objects
            Dim Offices As Generic.List(Of AdvantageFramework.Database.Core.Office) = Nothing

            Offices = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                       Where Entity.IsInactive Is Nothing OrElse
                               Entity.IsInactive = 0
                       Select Entity).ToList

            GetActiveOffices = Offices

        End Function
        Public Function GetDistinctARDescriptions(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of String)

            'objects
            Dim ARDescriptions As Generic.List(Of String) = Nothing

            ARDescriptions = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                              Where Entity.IsManualInvoice = 1 AndAlso
                                    Entity.IsImportedInvoice = 1
                              Select Entity.Description).Distinct.ToList

            GetDistinctARDescriptions = ARDescriptions

        End Function

#End Region

    End Module

End Namespace
