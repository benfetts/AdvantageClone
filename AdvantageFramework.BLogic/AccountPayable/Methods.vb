Namespace AccountPayable

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MediaType
            Print = 0
            Internet = 1
            OutOfHome = 2
            Radio = 3
            TV = 4
        End Enum

        Public Enum InvoiceDetailCriteria
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Purchase Order")>
            PONumber = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Job Number")>
            JobNumber = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Expense Account")>
            GLACode = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Approval Status")>
            ApprovalStatus = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Order Number")>
            OrderNumber = 4
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub AddNonClient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef GLTransaction As Integer, ByVal GLACode As String, ByVal CreditAmount As Double,
                                ByVal Remark As String, ByVal GLSourceCode As String, ByVal PODetailLineNumber As Nullable(Of Short), ByVal PONumber As Nullable(Of Integer),
                                ByVal UserCode As String, ByVal AccountPayableGLDistributionOfficeCode As String, ByVal Comment As String,
                                ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String, ByVal BatchDate As Nullable(Of Date),
                                ByVal ExpenseReportDetailID As Nullable(Of Integer))

            Dim AccountPayableGLDistribution As AdvantageFramework.Database.Entities.AccountPayableGLDistribution = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing

            If CreditAmount <> 0 Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                    Throw New Exception("Problem inserting into General Ledger Detail.")

                End If

                AccountPayableGLDistribution = New AdvantageFramework.Database.Entities.AccountPayableGLDistribution
                AccountPayableGLDistribution.DbContext = DbContext
                AccountPayableGLDistribution.AccountPayableID = AccountPayable.ID
                AccountPayableGLDistribution.AccountPayableSequenceNumber = 0
                AccountPayableGLDistribution.GLACode = GLACode
                AccountPayableGLDistribution.Amount = CreditAmount
                AccountPayableGLDistribution.PODetailLineNumber = PODetailLineNumber
                AccountPayableGLDistribution.GLTransaction = GLTransaction
                AccountPayableGLDistribution.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber
                AccountPayableGLDistribution.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableGLDistribution.PONumber = PONumber
                AccountPayableGLDistribution.Comment = Comment
                AccountPayableGLDistribution.OfficeCode = AccountPayableGLDistributionOfficeCode
                AccountPayableGLDistribution.CreateDate = Now.ToString
                AccountPayableGLDistribution.CreatedBy = UserCode
                AccountPayableGLDistribution.ExpenseReportDetailID = ExpenseReportDetailID

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If AdvantageFramework.GeneralLedger.OfficeDiffers(DbContext, AccountPayable.GLACode, AccountPayableGLDistribution.GLACode, AccountPayable.OfficeCode, AccountPayableGLDistribution.OfficeCode) Then

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = AccountPayableGLDistribution.OfficeCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            AccountPayableGLDistribution.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                            AccountPayableGLDistribution.GLACodeDueTo = OfficeInterCompany.DueToGLACode

                            'Detail DueFrom
                            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode, CreditAmount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting into General Ledger Detail.")

                            End If

                            AccountPayableGLDistribution.GLSequenceNumberDueFrom = GeneralLedgerDetail.SequenceNumber

                            'Detail DueTo
                            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode, CreditAmount * -1, Remark, GLSourceCode) = False Then

                                Throw New Exception("Problem inserting into General Ledger Detail.")

                            End If

                            AccountPayableGLDistribution.GLSequenceNumberDueTo = GeneralLedgerDetail.SequenceNumber

                        End If

                    End If

                End If

                If AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.Insert(DbContext, AccountPayableGLDistribution) = False Then

                    Throw New Exception("Problem inserting into AP General Ledger Distribution.")

                End If

            End If

        End Sub
        Public Function FormatInvoice(ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable) As String

            Dim ReturnString As String = Nothing

            If String.IsNullOrWhiteSpace(AccountPayable.InvoiceDescription) Then

                ReturnString = AccountPayable.InvoiceNumber

            Else

                ReturnString = AccountPayable.InvoiceNumber & " " & AccountPayable.InvoiceDescription

            End If

            FormatInvoice = ReturnString

        End Function
        Public Function GetAccountPayableGeneralLedgerDatasource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerOfficeCrossReferenceCode As String,
                                                                 Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            If GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                GetAccountPayableGeneralLedgerDatasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session, True, True).Include("GeneralLedgerOfficeCrossReference")
                                                            Where Entity.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReferenceCode AndAlso
                                                                  Entity.Type = "5").ToList

            Else

                GetAccountPayableGeneralLedgerDatasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session, True, True).Include("GeneralLedgerOfficeCrossReference")
                                                            Where Entity.Type = "5").ToList

            End If

        End Function
        Public Function GetAllAccountPayableList(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing

            If AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(DbContext) Then

                AccountPayableList = (From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext)
                                      Where AccountPayable.Deleted = 1
                                      Group AccountPayable By AccountPayable.ID Into Group
                                      Select New With {.ID = ID,
                                                       .SequenceNumber = Group.Max(Function(AccountPayable) AccountPayable.SequenceNumber) - 1}).SelectMany(Function(AEntity) From AccountPayable In DbContext.AccountPayables
                                                                                                                                                                              Where AccountPayable.ID = AEntity.ID AndAlso
                                                                                                                                                                                    AccountPayable.SequenceNumber = AEntity.SequenceNumber
                                                                                                                                                                              Select AccountPayable).ToList

            Else

                AccountPayableList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            End If

            AccountPayableList.AddRange(From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext)
                                        Where (AccountPayable.IsArchived Is Nothing OrElse
                                                AccountPayable.IsArchived = 0) AndAlso
                                                AccountPayable.Modified Is Nothing AndAlso
                                                AccountPayable.Deleted Is Nothing
                                        Select AccountPayable)

            GetAllAccountPayableList = AccountPayableList

        End Function
        Public Function GetAllAccountPayableListByVendor(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing

            If AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(DbContext) Then

                AccountPayableList = (From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendor(DbContext, VendorCode)
                                      Where AccountPayable.Deleted = 1
                                      Group AccountPayable By AccountPayable.ID Into Group
                                      Select New With {.ID = ID,
                                                       .SequenceNumber = Group.Max(Function(AccountPayable) AccountPayable.SequenceNumber) - 1}).SelectMany(Function(AEntity) From AccountPayable In DbContext.AccountPayables
                                                                                                                                                                              Where AccountPayable.ID = AEntity.ID AndAlso
                                                                                                                                                                                    AccountPayable.SequenceNumber = AEntity.SequenceNumber
                                                                                                                                                                              Select AccountPayable).ToList

            Else

                AccountPayableList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable)

            End If

            AccountPayableList.AddRange(From AccountPayable In AdvantageFramework.Database.Procedures.AccountPayable.LoadByVendor(DbContext, VendorCode)
                                        Where (AccountPayable.IsArchived Is Nothing OrElse
                                                AccountPayable.IsArchived = 0) AndAlso
                                                AccountPayable.Modified Is Nothing AndAlso
                                                AccountPayable.Deleted Is Nothing
                                        Select AccountPayable)

            GetAllAccountPayableListByVendor = AccountPayableList

        End Function
        Public Function GetAvailableProductionJobs(DbContext As AdvantageFramework.Database.DbContext, UserCode As String,
                                                   OfficeCode As String, ClientCode As String, DivisionCode As String,
                                                   ProductCode As String, Optional IncludeClosedJobs As Boolean = False) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs)

            GetAvailableProductionJobs = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs) _
                                            (String.Format("exec advsp_ap_available_production_jobs {0}, {1}, {2}, {3}, {4}, {5}",
                                                           If(UserCode IsNot Nothing, "'" & UserCode & "'", "NULL"),
                                                           If(OfficeCode IsNot Nothing, "'" & OfficeCode & "'", "NULL"),
                                                           If(ClientCode IsNot Nothing, "'" & ClientCode & "'", "NULL"),
                                                           If(DivisionCode IsNot Nothing, "'" & DivisionCode & "'", "NULL"),
                                                           If(ProductCode IsNot Nothing, "'" & ProductCode & "'", "NULL"),
                                                           If(IncludeClosedJobs, 1, 0))).ToList

        End Function
        Public Function GetGeneralLedgerAccountDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerCode As String) As String

            'objects
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountCode As String = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GeneralLedgerCode)

            If GeneralLedgerAccount IsNot Nothing Then

                GeneralLedgerAccountCode = GeneralLedgerAccount.Description

            End If

            GetGeneralLedgerAccountDescription = GeneralLedgerAccountCode

        End Function
        Public Function GetJobComponentsByJob(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            Dim JobProcessNumberList As Generic.List(Of Short) = Nothing

            JobProcessNumberList = New Generic.List(Of Short)
            JobProcessNumberList.AddRange({1, 3, 4, 8, 9, 13})

            GetJobComponentsByJob = (From JobComponent In DbContext.JobComponents
                                     Where JobComponent.JobNumber = JobNumber AndAlso
                                           JobComponent.Job.SalesClassCode IsNot Nothing AndAlso
                                           JobProcessNumberList.Contains(JobComponent.JobProcessNumber)
                                     Select JobComponent).ToList

        End Function
        Public Function GetOpenJobComponentsForJobs(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            Dim JobProcessNumberList As Generic.List(Of Short) = Nothing

            JobProcessNumberList = New Generic.List(Of Short)
            JobProcessNumberList.AddRange({1, 3, 4, 8, 9, 13})

            GetOpenJobComponentsForJobs = (From JobComponent In DbContext.JobComponents
                                           Where JobComponent.Job.SalesClassCode IsNot Nothing AndAlso
                                                 JobProcessNumberList.Contains(JobComponent.JobProcessNumber)
                                           Select JobComponent).ToList

        End Function
        Public Function GetOpenPurchaseOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              UserCode As String,
                                              Optional ByVal VendorCode As String = Nothing,
                                              Optional ByVal IncludeJobProcessControl As Boolean = True,
                                              Optional ByVal IncludeCompletedPOs As Boolean = False) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders)

            Dim AccountPayableProductionPurchaseOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders) = Nothing

            AccountPayableProductionPurchaseOrdersList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders) _
                                                            (String.Format("exec advsp_ap_production_purchase_orders {0}, {1}, '{2}', {3}",
                                                                           If(VendorCode IsNot Nothing, "'" & VendorCode & "'", "NULL"),
                                                                           If(IncludeJobProcessControl, 1, 0),
                                                                           UserCode,
                                                                           If(IncludeCompletedPOs, 1, 0), UserCode)).ToList

            GetOpenPurchaseOrders = AccountPayableProductionPurchaseOrdersList

        End Function
        Public Function GetNonClientGLAccountList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session,
                                                  ByVal AccountPayableOfficeCode As String, ByVal NonClientOfficeCode As String,
                                                  Optional ByVal IsCustomNonClientOnlyImportTemplate As Boolean = False,
                                                  Optional ByVal CustomOfficeCode As String = Nothing) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Dim AllowCostOfSaleEntry As Boolean = False
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GLAOfficeXREFCode As String = Nothing
            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(DbContext)

            If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) Then

                GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, AccountPayableOfficeCode)

                If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    GLAOfficeXREFCode = GeneralLedgerOfficeCrossReference.Code

                    GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                                Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode
                                                Select Entity).ToList

                Else

                    GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                                Select Entity).ToList

                End If

            ElseIf AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                If NonClientOfficeCode IsNot Nothing AndAlso NonClientOfficeCode <> "" Then

                    Try

                        GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, NonClientOfficeCode).Code

                    Catch ex As Exception
                        GLAOfficeXREFCode = Nothing
                    End Try

                    If GLAOfficeXREFCode IsNot Nothing Then

                        GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                                    Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode
                                                    Select Entity).ToList

                    Else

                        GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                                    Select Entity).ToList

                    End If

                Else

                    GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                                Select Entity).ToList

                End If

            Else

                GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                            Select Entity).ToList

            End If

            If IsCustomNonClientOnlyImportTemplate Then

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, CustomOfficeCode)

                If Office IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Office.MediaAccruedAccountsPayableGLACode) = False Then

                    GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Office.MediaAccruedAccountsPayableGLACode)

                    If GeneralLedgerAccount IsNot Nothing Then

                        GeneralLedgerAccountList.Add(GeneralLedgerAccount)

                    End If

                End If

            End If

            GetNonClientGLAccountList = GeneralLedgerAccountList.OrderBy(Function(GLA) GLA.Code).ToList

        End Function
        Public Function GetProductionGLAccountList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String,
                                                   Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Dim AllowCostOfSaleEntry As Boolean = False

            AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(DbContext)

            GetProductionGLAccountList = GetProductionGLAccountList(DbContext, OfficeCode, AllowCostOfSaleEntry, Session)

        End Function
        Public Function GetProductionGLAccountList(DbContext As AdvantageFramework.Database.DbContext, OfficeCode As String, AllowCostOfSaleEntry As Boolean,
                                                   Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

            Dim IsAPLimitByOfficeEnabled As Boolean = False
            Dim GLAOfficeXREFCode As String = Nothing
            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

            If IsAPLimitByOfficeEnabled Then

                Try

                    GLAOfficeXREFCode = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, OfficeCode).Code

                Catch ex As Exception
                    GLAOfficeXREFCode = Nothing
                End Try

            End If

            If IsAPLimitByOfficeEnabled AndAlso GLAOfficeXREFCode IsNot Nothing Then

                GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                            Where Entity.GeneralLedgerOfficeCrossReferenceCode = GLAOfficeXREFCode
                                            Select Entity).ToList()

            Else

                GeneralLedgerAccountList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, Session, True, False, AllowCostOfSaleEntry)
                                            Select Entity).ToList()

            End If

            GetProductionGLAccountList = GeneralLedgerAccountList

        End Function
        Public Function GetPurchaseOrderLineNumbers(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal PONumber As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail)

            GetPurchaseOrderLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Load(DbContext).Include("[Function]")
                                           Where Entity.PurchaseOrderNumber = PONumber AndAlso
                                                 Entity.Job IsNot Nothing AndAlso
                                                 Entity.JobComponent IsNot Nothing AndAlso
                                                 (Entity.IsComplete Is Nothing OrElse
                                                  Entity.IsComplete = 0)
                                           Select Entity).ToList

        End Function
        Public Function GetAvailableInternetOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                                   ByVal DivisionCode As String, ByVal ProductCode As String, ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode

            GetAvailableInternetOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders) _
                                            ("exec advsp_ap_available_internet_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @batch_name, @source_code, @order_id, @user_code",
                                            SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterBatchName,
                                            SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode).ToList

        End Function
        Public Function GetAvailableMagazineOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                                   ByVal DivisionCode As String, ByVal ProductCode As String, ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode

            GetAvailableMagazineOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders) _
                                            ("exec advsp_ap_available_magazine_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @batch_name, @source_code, @order_id, @user_code",
                                            SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterBatchName,
                                            SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode).ToList

        End Function
        Public Function GetAvailableNewspaperOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                                    ByVal DivisionCode As String, ByVal ProductCode As String, ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode

            GetAvailableNewspaperOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders) _
                                            ("exec advsp_ap_available_newspaper_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @batch_name, @source_code, @order_id, @user_code",
                                            SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterBatchName,
                                            SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode).ToList

        End Function
        Public Function GetAvailableOutOfHomeOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                                    ByVal DivisionCode As String, ByVal ProductCode As String, ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode

            GetAvailableOutOfHomeOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders) _
                                            ("exec advsp_ap_available_outofhome_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @batch_name, @source_code, @order_id, @user_code",
                                            SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterBatchName,
                                            SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode).ToList

        End Function
        Public Function GetAvailableRadioOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                                ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MonthName As String,
                                                ByVal Year As Nullable(Of Short), ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer),
                                                CalendarDate As Nullable(Of Date)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCalendarDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterMonth = New System.Data.SqlClient.SqlParameter("@month", SqlDbType.VarChar)
            SqlParameterYear = New System.Data.SqlClient.SqlParameter("@year", SqlDbType.SmallInt)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterCalendarDate = New System.Data.SqlClient.SqlParameter("@calendar_date", SqlDbType.Date)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterMonth.Value = If(String.IsNullOrEmpty(MonthName), System.DBNull.Value, MonthName)
            SqlParameterYear.Value = If(Year.HasValue, Year, System.DBNull.Value)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode
            SqlParameterCalendarDate.Value = If(CalendarDate.HasValue, CalendarDate.Value, System.DBNull.Value)

            GetAvailableRadioOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) _
                                        ("exec advsp_ap_available_radio_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @month, @year, @batch_name, @source_code, @order_id, @user_code, @calendar_date",
                                        SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterMonth, SqlParameterYear,
                                        SqlParameterBatchName, SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode, SqlParameterCalendarDate).ToList

        End Function
        Public Function GetAvailableTVOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AllowVendorNotOnOrder As Boolean, ByVal VendorCode As String, ByVal OfficeCode As String, ByVal ClientCode As String,
                                             ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MonthName As String,
                                             ByVal Year As Nullable(Of Short), ByVal BatchName As String, ByVal SourceCode As String, ByVal OrderID As Nullable(Of Integer),
                                             CalendarDate As Nullable(Of Date)) As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders)

            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCalendarDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
            SqlParameterMonth = New System.Data.SqlClient.SqlParameter("@month", SqlDbType.VarChar)
            SqlParameterYear = New System.Data.SqlClient.SqlParameter("@year", SqlDbType.SmallInt)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
            SqlParameterSourceCode = New System.Data.SqlClient.SqlParameter("@source_code", SqlDbType.VarChar)
            SqlParameterOrderID = New System.Data.SqlClient.SqlParameter("@order_id", SqlDbType.Int)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterCalendarDate = New System.Data.SqlClient.SqlParameter("@calendar_date", SqlDbType.Date)

            SqlParameterVendorCode.Value = If(AllowVendorNotOnOrder, System.DBNull.Value, VendorCode)
            SqlParameterOfficeCode.Value = If(String.IsNullOrEmpty(OfficeCode), System.DBNull.Value, OfficeCode)
            SqlParameterClientCode.Value = If(String.IsNullOrEmpty(ClientCode), System.DBNull.Value, ClientCode)
            SqlParameterDivisionCode.Value = If(String.IsNullOrEmpty(DivisionCode), System.DBNull.Value, DivisionCode)
            SqlParameterProductCode.Value = If(String.IsNullOrEmpty(ProductCode), System.DBNull.Value, ProductCode)
            SqlParameterMonth.Value = If(String.IsNullOrEmpty(MonthName), System.DBNull.Value, MonthName)
            SqlParameterYear.Value = If(Year.HasValue, Year, System.DBNull.Value)
            SqlParameterBatchName.Value = If(String.IsNullOrEmpty(BatchName), System.DBNull.Value, BatchName)
            SqlParameterSourceCode.Value = If(String.IsNullOrEmpty(SourceCode), System.DBNull.Value, SourceCode)
            SqlParameterOrderID.Value = If(OrderID.HasValue, OrderID, System.DBNull.Value)
            SqlParameterUserCode.Value = DbContext.UserCode
            SqlParameterCalendarDate.Value = If(CalendarDate.HasValue, CalendarDate.Value, System.DBNull.Value)

            GetAvailableTVOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) _
                                     ("exec advsp_ap_available_tv_orders @vn_code, @office_code, @cl_code, @div_code, @prd_code, @month, @year, @batch_name, @source_code, @order_id, @user_code, @calendar_date",
                                     SqlParameterVendorCode, SqlParameterOfficeCode, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterMonth, SqlParameterYear,
                                     SqlParameterBatchName, SqlParameterSourceCode, SqlParameterOrderID, SqlParameterUserCode, SqlParameterCalendarDate).ToList

        End Function
        Public Function GrossToNet(ByVal GrossValue As Decimal, ByVal CommissionPercent As Decimal) As Decimal

            Dim NewValue As Decimal = 0

            If GrossValue = 0 Then

                NewValue = 0

            Else

                NewValue = GrossValue - (GrossValue * CommissionPercent / 100)

            End If

            GrossToNet = Format(NewValue, "#0.00")

        End Function
        Public Sub CalculateNetAndCommission(ByVal GrossValue As Decimal, ByVal CommissionPercent As Decimal, ByRef NetAmount As Decimal, ByRef CommissionAmount As Decimal)

            If GrossValue = 0 Then

                CommissionAmount = 0

                NetAmount = 0

            Else

                CommissionAmount = Format(GrossValue * CommissionPercent / 100, "#0.00")

                NetAmount = Format(GrossValue - CommissionAmount, "#0.00")

            End If

        End Sub
        Public Sub CalculateGrossAndCommission(ByVal NetValue As Decimal, ByVal Discount As Decimal, ByVal MarkupPercent As Decimal, ByRef GrossAmount As Decimal, ByRef CommissionAmount As Decimal)

            If NetValue = 0 Then

                CommissionAmount = 0

                GrossAmount = 0

            Else

                CommissionAmount = Format(NetValue * MarkupPercent / 100, "#0.00")

                GrossAmount = Format(NetValue + CommissionAmount, "#0.00")

            End If

        End Sub
        Public Function NetToGross(ByVal NetValue As Decimal, ByVal CommissionPercent As Decimal) As Decimal

            Dim NewValue As Decimal = 0

            If NetValue = 0 Then

                NewValue = 0

            Else

                NewValue = (NetValue / (CDec(1) - CommissionPercent / 100))

            End If

            NetToGross = Format(NewValue, "#0.00")

        End Function
        Public Function SaveMediaApproval(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableID As Integer, ByVal OrderNumber As Integer,
                                          ByVal LineNumber As Short, ByVal Source As String, ByVal Status As Nullable(Of Short), ByVal UserCode As String, ByVal Comments As String,
                                          Optional ByVal ApplicationSource As String = "AP") As Boolean

            Dim Saved As Boolean = False
            Dim AccountPayableMediaApproval As AdvantageFramework.Database.Entities.AccountPayableMediaApproval = Nothing

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_MEDIA_APPROVAL SET ACTIVE_REV=NULL WHERE AP_ID={0} AND ORDER_NBR={1} AND LINE_NBR={2}", AccountPayableID, OrderNumber, LineNumber))

                AccountPayableMediaApproval = New AdvantageFramework.Database.Entities.AccountPayableMediaApproval

                AccountPayableMediaApproval.AccountPayableID = AccountPayableID
                AccountPayableMediaApproval.OrderNumber = OrderNumber
                AccountPayableMediaApproval.LineNumber = LineNumber
                AccountPayableMediaApproval.Source = Source
                AccountPayableMediaApproval.Status = Status
                AccountPayableMediaApproval.IsActiveRevision = 1
                AccountPayableMediaApproval.UserCode = UserCode
                AccountPayableMediaApproval.RevisionDate = Now
                AccountPayableMediaApproval.Comments = Comments
                AccountPayableMediaApproval.ApplicationSource = ApplicationSource

                Saved = AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.Insert(DbContext, AccountPayableMediaApproval)

            Catch ex As Exception
                Saved = False
            Finally
                SaveMediaApproval = Saved
            End Try

        End Function
        Public Sub ModifyPaymentHoldForApprovedInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal ApproveInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice))

            'objects
            Dim AccountPayableMediaApprovals As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableMediaApproval) = Nothing
            Dim AllLinesApproved As Boolean = True
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            Try

                For Each AccountPayableID In ApproveInvoices.Select(Function(inv) inv.AccountPayableID).Distinct.ToList

                    AccountPayable = (From Item In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableID)
                                      Order By Item.SequenceNumber Descending
                                      Select Item).FirstOrDefault

                    If AccountPayable IsNot Nothing Then

                        AllLinesApproved = True

                        AccountPayableMediaApprovals = AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.LoadByAccountPayableID(DbContext, AccountPayableID).Where(Function(appr) appr.IsActiveRevision = 1).ToList

                        For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.OrderNumber, .LineNumber = dtl.OrderLineNumber}).ToList

                            If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                    AllLinesApproved = False

                                End If

                            End If

                        Next

                        If AllLinesApproved Then

                            For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.OrderNumber, .LineNumber = dtl.OrderLineNumber}).ToList

                                If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                    If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                        AllLinesApproved = False

                                    End If

                                End If

                            Next

                        End If

                        If AllLinesApproved Then

                            For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.OrderNumber, .LineNumber = dtl.OrderLineNumber}).ToList

                                If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                    If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                        AllLinesApproved = False

                                    End If

                                End If

                            Next

                        End If

                        If AllLinesApproved Then

                            For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.OrderNumber, .LineNumber = dtl.OrderLineNumber}).ToList

                                If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                    If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                        AllLinesApproved = False

                                    End If

                                End If

                            Next

                        End If

                        If AllLinesApproved Then

                            For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.OutdoorOrderNumber, .LineNumber = dtl.OutdoorDetailLineNumber}).ToList

                                If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                    If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                        AllLinesApproved = False

                                    End If

                                End If

                            Next

                        End If

                        If AllLinesApproved Then

                            For Each OrderAndLineNumber In AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByAccountPayableID(DbContext, AccountPayableID).Select(Function(dtl) New With {.OrderNumber = dtl.InternetOrderNumber, .LineNumber = dtl.InternetDetailLineNumber}).ToList

                                If AccountPayableMediaApprovals.Any(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber) Then

                                    If AccountPayableMediaApprovals.Where(Function(appr) appr.OrderNumber = OrderAndLineNumber.OrderNumber AndAlso appr.LineNumber = OrderAndLineNumber.LineNumber AndAlso (appr.Status.HasValue = False OrElse appr.Status = AdvantageFramework.Database.Entities.MediaApprovalStatus.Approved)).Any = False Then

                                        AllLinesApproved = False

                                    End If

                                End If

                            Next

                        End If

                    End If

                    If AllLinesApproved Then

                        AccountPayable.IsOnHold = 0

                    Else

                        AccountPayable.IsOnHold = 1

                    End If

                    AdvantageFramework.Database.Procedures.AccountPayable.Update(DbContext, AccountPayable, True)

                Next

            Catch ex As Exception

            End Try

        End Sub
        Public Function SendMediaApprovalAlerts(ByVal Session As AdvantageFramework.Security.Session,
                                                ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal ApproveInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice),
                                                ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim AccountPayableMediaApprovals As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableMediaApproval) = Nothing
            Dim EmployeeCode As String = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim DefaultAlertGroupCode As String = Nothing
            Dim AlertGroupEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Try

                If AdvantageFramework.Agency.GetOptionAPMediaApprovalAlertAP(DbContext) Then

                    AccountPayableMediaApprovals = (From MediaAppr In AdvantageFramework.Database.Procedures.AccountPayableMediaApproval.Load(DbContext)
                                                    Where MediaAppr.ApplicationSource = "AP"
                                                    Order By MediaAppr.Revision Descending
                                                    Group By MediaAppr.AccountPayableID, MediaAppr.OrderNumber, MediaAppr.LineNumber Into ApGrp = Group
                                                    Select ApGrp).ToList.Select(Function(grp) grp.First).ToList

                    AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, 69) 'Media Invoice Approval Request
                    DefaultAlertGroupCode = AdvantageFramework.Agency.GetOptionAPDefaultAlertGroup(DbContext)

                    If Not String.IsNullOrWhiteSpace(DefaultAlertGroupCode) Then

                        AlertGroupEmployees = (From Item In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, DefaultAlertGroupCode)
                                               Join Emp In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext) On Item.EmployeeCode Equals Emp.Code
                                               Select Emp).ToList

                    End If

                    If AdvantageFramework.Agency.GetOptionAPMediaApprovalAlertAPUser(DbContext) = 1 Then

                        If AlertGroupEmployees IsNot Nothing AndAlso AlertGroupEmployees.Count > 0 Then

                            For Each AccountPayableMediaApproval In AccountPayableMediaApprovals

                                AccountPayableMediaApproval.UserCode = "" ' this will force send to alert group

                            Next

                        End If

                    End If

                    For Each ApprovalGroup In (From ApprInv In ApproveInvoices
                                               Group Join MediaApproval In AccountPayableMediaApprovals On ApprInv.AccountPayableID Equals MediaApproval.AccountPayableID And ApprInv.OrderNumber Equals MediaApproval.OrderNumber And ApprInv.LineNumber Equals MediaApproval.LineNumber Into Group
                                               From apprGrp In Group.DefaultIfEmpty
                                               Select New AdvantageFramework.MediaManager.Classes.UserApproveInvoices With {.UserCode = If(apprGrp IsNot Nothing, apprGrp.UserCode, ""), .ApproveInvoice = ApprInv}).GroupBy(Function(g) g.UserCode).ToList

                        Employees = New List(Of Database.Views.Employee)

                        If Not String.IsNullOrWhiteSpace(ApprovalGroup.Key) Then

                            EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT EMP_CODE FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", ApprovalGroup.Key)).SingleOrDefault

                            If Not String.IsNullOrWhiteSpace(EmployeeCode) Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                If Employee IsNot Nothing Then

                                    Employees.Add(Employee)

                                End If

                            End If

                        End If

                        If Employees Is Nothing OrElse Employees.Count = 0 Then

                            Employees = AlertGroupEmployees

                        End If

                        If Employees IsNot Nothing AndAlso Employees.Count > 0 Then

                            Alert = New Database.Entities.Alert

                            Alert.AlertTypeID = AlertCategory.AlertTypeID
                            Alert.AlertCategoryID = AlertCategory.ID
                            Alert.Subject = "Media invoices have been approved by " & AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, DbContext.UserCode).ToString & "."

                            Alert.EmailBody = "For Vendors: " & String.Join(", ", DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DISTINCT V.VN_NAME FROM dbo.AP_HEADER A INNER JOIN dbo.VENDOR V ON A.VN_FRL_EMP_CODE = V.VN_CODE WHERE A.AP_ID IN ({0}) ORDER BY V.VN_NAME", String.Join(", ", ApprovalGroup.Select(Function(ag) ag.ApproveInvoice.AccountPayableID).Distinct.ToList))))

                            For Each G In (From AP In (From Entity In ApprovalGroup
                                                       Where Entity.UserCode = ApprovalGroup.Key
                                                       Select Entity.ApproveInvoice)
                                           Select AP.OrderNumber, AP.InvoiceNumber).Distinct.ToList

                                Alert.EmailBody += vbCrLf & "Order Number: " & G.OrderNumber & ", Invoice Number: " & G.InvoiceNumber

                            Next

                            Alert.Body = Alert.EmailBody
                            Alert.GeneratedDate = System.DateTime.Now
                            Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.Normal
                            Alert.EmployeeCode = Session.User.EmployeeCode
                            Alert.AlertLevel = ""
                            Alert.UserCode = DbContext.UserCode
                            Alert.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                For Each Employee In Employees

                                    AdvantageFramework.AlertSystem.CreateAlertRecipient(DbContext, Employee, Alert, True)

                                Next

                                AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert] ", Nothing, Nothing, "APVendorMediaInvoiceApproval", "")

                            End If

                        Else

                            ErrorMessage = "Unable to send alert for 1 or more invoices."

                        End If

                    Next

                    Saved = True

                End If

            Catch ex As Exception
                Saved = False
            Finally
                SendMediaApprovalAlerts = Saved
            End Try

        End Function
        Private Function CreateAccountPayable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable,
                                              ByVal PostPeriodCode As String) As AdvantageFramework.Database.Entities.AccountPayable

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            Try

                AccountPayable = New AdvantageFramework.Database.Entities.AccountPayable
                AccountPayable.DbContext = DbContext

                AccountPayable.Type = "V"

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportAccountPayable.VendorCode)

                AccountPayable.VendorCode = ImportAccountPayable.VendorCode
                AccountPayable.InvoiceNumber = ImportAccountPayable.InvoiceNumber
                AccountPayable.CreatedDate = Now

                AccountPayable.Is1099Invoice = Vendor.Vendor1099Flag.GetValueOrDefault(0)

                AccountPayable.IsOnHold = 0

                AccountPayable.InvoiceDescription = If(ImportAccountPayable.InvoiceDescription Is Nothing, "", ImportAccountPayable.InvoiceDescription)

                AccountPayable.OfficeCode = ImportAccountPayable.OfficeCode

                AccountPayable.VendorTermCode = Vendor.VendorTermCode

                AccountPayable.GLACode = ImportAccountPayable.GLAccount

                AccountPayable.PostPeriodCode = PostPeriodCode

                AccountPayable.InvoiceDate = ImportAccountPayable.InvoiceDate

                If Vendor.VendorTermCode IsNot Nothing Then

                    VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(DbContext, Vendor.VendorTermCode)

                    AccountPayable.PaidDate = DateAdd(DateInterval.Day, CDbl(VendorTerm.DaysToPay), AccountPayable.InvoiceDate)

                End If

                AccountPayable.CreatedByUserCode = DbContext.UserCode

                AccountPayable.BatchName = ImportAccountPayable.BatchName

                AccountPayable.InvoiceAmount = ImportAccountPayable.InvoiceTotalNet.GetValueOrDefault(0)
                AccountPayable.ShippingAmount = 0
                AccountPayable.SalesTaxAmount = ImportAccountPayable.InvoiceTotalTax.GetValueOrDefault(0)
                AccountPayable.DiscountPercentage = 0

                SetCurrencyColumnValues(DbContext, Vendor, AccountPayable)

            Catch ex As Exception
                AccountPayable = Nothing
            Finally
                CreateAccountPayable = AccountPayable
            End Try

        End Function
        Private Sub InsertInternet(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                   ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableInternetDistributionDetail In AccountPayableInternetDistributionDetailList

                AddInternet(DbContext, AccountPayableInternetDistributionDetail, AccountPayableInternetDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode, False)

            Next

        End Sub
        Private Sub InsertMagazine(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                   ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableMagazineDistributionDetail In AccountPayableMagazineDistributionDetailList

                AddMagazine(DbContext, AccountPayableMagazineDistributionDetail, AccountPayableMagazineDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertNewspaper(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                    ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableNewspaperDistributionDetail In AccountPayableNewspaperDistributionDetailList

                AddNewspaper(DbContext, AccountPayableNewspaperDistributionDetail, AccountPayableNewspaperDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Private Sub InsertNonClient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                    ByVal AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail), ByVal GLSourceCode As String,
                                    ByVal UpdatePurchaseOrderStatus As Boolean)

            Dim Remark As String = Nothing
            Dim POComplete As Short = 0

            For Each AccountPayableGLDistributionDetail In AccountPayableGLDistributionDetailList

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " " & AccountPayableGLDistributionDetail.Comment
                AdvantageFramework.AccountPayable.AddNonClient(DbContext, GLTransaction, AccountPayableGLDistributionDetail.GLACode, AccountPayableGLDistributionDetail.Amount, Remark, GLSourceCode, AccountPayableGLDistributionDetail.PODetailLineNumber, AccountPayableGLDistributionDetail.PONumber, DbContext.UserCode, AccountPayableGLDistributionDetail.OfficeCode, AccountPayableGLDistributionDetail.Comment, AccountPayable, VendorName, Nothing, AccountPayableGLDistributionDetail.AccountPayableGLDistribution.ExpenseReportDetailID)

                If UpdatePurchaseOrderStatus AndAlso AccountPayableGLDistributionDetail.PONumber IsNot Nothing AndAlso AccountPayableGLDistributionDetail.PODetailLineNumber IsNot Nothing Then

                    POComplete = 0

                    If (From Entity In AccountPayableGLDistributionDetailList
                        Where Entity.PONumber = AccountPayableGLDistributionDetail.PONumber AndAlso
                              Entity.PODetailLineNumber = AccountPayableGLDistributionDetail.PODetailLineNumber AndAlso
                              Entity.POComplete = 1
                        Select Entity).Any Then

                        POComplete = 1

                    End If

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.UpdateIsCompleteAndParentPO(DbContext, AccountPayableGLDistributionDetail.PONumber, AccountPayableGLDistributionDetail.PODetailLineNumber, POComplete) = False Then

                        Throw New Exception("Failed to update purchase order.")

                    End If

                End If

            Next

        End Sub
        Private Sub InsertOutOfHome(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                    ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail), ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableOutOfHomeDistributionDetail In AccountPayableOutOfHomeDistributionDetailList

                AddOutOfHome(DbContext, AccountPayableOutOfHomeDistributionDetail, AccountPayableOutOfHomeDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

        End Sub
        Public Sub InsertProduction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                    ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail), ByVal GLSourceCode As String,
                                    ByVal UpdatePurchaseOrderStatus As Boolean)

            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing
            Dim JobComponent As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing
            Dim Remark As String = Nothing
            Dim AgencyInvoiceTaxFlag As Boolean = False
            Dim POComplete As Short = 0

            JobComponent = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            AgencyInvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

            For Each AccountPayableProductionDistributionDetail In AccountPayableProductionDistributionDetailList

                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Job: " & AccountPayableProductionDistributionDetail.JobNumber.ToString.PadLeft(6, "0") & "-" & AccountPayableProductionDistributionDetail.JobComponentNumber.ToString.PadLeft(3, "0") & " [PR]"

                AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableProductionDistributionDetail.AccountPayableProduction.IsWriteOff = 0

                AddProduction(DbContext, AccountPayableProductionDistributionDetail, AccountPayableProductionDistributionDetailList, AccountPayableProductionDistributionDetail.AccountPayableProduction, GLTransaction, Remark, AccountPayable,
                              JobComponent, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, False, AgencyInvoiceTaxFlag, GLSourceCode, Nothing, True)

                If AccountPayableProductionDistributionDetail.Comment IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.Comment <> "" AndAlso AccountPayableProductionDistributionDetail.AccountPayableProduction.LineNumber <> 0 Then

                    AccountPayableProductionComment = New AdvantageFramework.Database.Entities.AccountPayableProductionComment
                    AccountPayableProductionComment.DbContext = DbContext
                    AccountPayableProductionComment.AccountPayableID = AccountPayable.ID
                    AccountPayableProductionComment.LineNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.LineNumber
                    AccountPayableProductionComment.JobNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.JobNumber
                    AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.JobComponentNumber
                    AccountPayableProductionComment.FunctionCode = AccountPayableProductionDistributionDetail.AccountPayableProduction.FunctionCode
                    AccountPayableProductionComment.Comment = AccountPayableProductionDistributionDetail.Comment
                    If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Insert(DbContext, AccountPayableProductionComment) = False Then

                        Throw New Exception("Failed to insert AP Production Comment.")

                    End If

                End If

                If UpdatePurchaseOrderStatus AndAlso AccountPayableProductionDistributionDetail.PONumber IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.PODetailLineNumber IsNot Nothing Then

                    POComplete = 0

                    If (From Entity In AccountPayableProductionDistributionDetailList
                        Where Entity.PONumber = AccountPayableProductionDistributionDetail.PONumber AndAlso
                              Entity.PODetailLineNumber = AccountPayableProductionDistributionDetail.PODetailLineNumber AndAlso
                              Entity.POComplete = 1
                        Select Entity).Any Then

                        POComplete = 1

                    End If

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.UpdateIsCompleteAndParentPO(DbContext, AccountPayableProductionDistributionDetail.PONumber, AccountPayableProductionDistributionDetail.PODetailLineNumber, POComplete) = False Then

                        Throw New Exception("Failed to update purchase order.")

                    End If

                End If

            Next

        End Sub
        Private Sub InsertRadio(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail),
                                ByVal AccountPayableRadioBroadcastDetailList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail),
                                ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableRadioDistributionDetail In AccountPayableRadioDistributionDetailList

                AddRadio(DbContext, AccountPayableRadioDistributionDetail, AccountPayableRadioDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

            For Each AccountPayableRadioBroadcastDetail In AccountPayableRadioBroadcastDetailList

                AddRadioDetail(DbContext, AccountPayableRadioBroadcastDetail, AccountPayable)

            Next

        End Sub
        Private Sub InsertTV(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                             ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail),
                             ByVal AccountPayableTVBroadcastDetailList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail),
                             ByVal GLSourceCode As String)

            Dim Orders As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing

            Orders = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            For Each AccountPayableTVDistributionDetail In AccountPayableTVDistributionDetailList

                AddTV(DbContext, AccountPayableTVDistributionDetail, AccountPayableTVDistributionDetailList, GLTransaction, AccountPayable, Orders, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLSourceCode)

            Next

            For Each AccountPayableTVBroadcastDetail In AccountPayableTVBroadcastDetailList

                AddTVDetail(DbContext, AccountPayableTVBroadcastDetail, AccountPayable)

            Next

        End Sub
        Public Function CreateAccountPayable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                             ByVal AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail),
                                             ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail),
                                             ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail),
                                             ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail),
                                             ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail),
                                             ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail),
                                             ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail),
                                             ByVal RadioBroadcastOrderDetailViewList As Generic.List(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView),
                                             ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail),
                                             ByVal TVBroadcastOrderDetailViewList As Generic.List(Of AdvantageFramework.Database.Views.BroadcastOrderDetailView),
                                             ByVal GLSourceCode As String, ByVal BatchDate As Date, ByRef VendorCode As String, ByRef AccountPayableID As Integer, ByRef SequenceNumber As Short,
                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsBalanced As Integer = -1

            If AccountPayable IsNot Nothing Then

                VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayable.VendorCode).Name

                Try

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    AccountPayable.DbContext = DbContext

                    GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                    If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                        Throw New Exception("Failed trying to save data to General Ledger.")

                    End If

                    CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable)
                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                        Throw New Exception("Failed trying to save data to General Ledger Detail.")

                    End If

                    AccountPayable.GLTransaction = GeneralLedger.Transaction
                    AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                    If AdvantageFramework.Database.Procedures.AccountPayable.Insert(DbContext, AccountPayable) = False Then

                        Throw New Exception("Insert to AP Header failed.")

                    End If

                    InsertNonClient(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, True)

                    InsertProduction(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, True)

                    InsertMagazine(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableMagazineDistributionDetailList, GLSourceCode)

                    InsertNewspaper(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableNewspaperDistributionDetailList, GLSourceCode)

                    InsertInternet(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableInternetDistributionDetailList, GLSourceCode)

                    InsertOutOfHome(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableOutOfHomeDistributionDetailList, GLSourceCode)

                    InsertRadio(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableRadioDistributionDetailList, RadioBroadcastOrderDetailViewList.Select(Function(v) v.GetAccountPayableRadioBroadcastDetail(DbContext)).ToList, GLSourceCode)

                    InsertTV(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableTVDistributionDetailList, TVBroadcastOrderDetailViewList.Select(Function(v) v.GetAccountPayableTVBroadcastDetail(DbContext)).ToList, GLSourceCode)

                    IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                    If IsBalanced = 1 Then

                        DbTransaction.Commit()

                    Else

                        Throw New Exception("Cannot save.  Invoice out of balance.")

                    End If

                    VendorCode = AccountPayable.VendorCode
                    AccountPayableID = AccountPayable.ID
                    SequenceNumber = AccountPayable.SequenceNumber

                    Created = True

                Catch ex As Exception
                    DbTransaction.Rollback()
                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    ErrorMessage += vbCrLf & ex.Message
                    'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                Finally

                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                        DbContext.Database.Connection.Close()

                    End If

                End Try

            End If

            CreateAccountPayable = Created

        End Function
        Public Sub AddInternet(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableInternetDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail,
                               ByVal AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail),
                               ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                               ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                               ByVal VendorName As String, ByVal GLSourceCode As String, ByVal PostPeriodChanged As Boolean, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableInternet As AdvantageFramework.Database.Entities.AccountPayableInternet = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableInternetDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableInternetDistributionDetail.Impressions.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableInternetDistributionDetail.NetAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableInternetDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableInternetDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(AccountPayableInternetDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableInternetDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableInternetDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableInternetDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableInternetDistributionDetail.InternetOrderNumber,
                                                                           AccountPayableInternetDistributionDetail.InternetDetailLineNumber, "I", AccountPayableInternetDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableInternetDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableInternetDistributionDetail.AccountPayableInternet.IsEntityBeingAdded() Then

                    AccountPayableInternet = AccountPayableInternetDistributionDetail.AccountPayableInternet

                Else

                    AccountPayableInternet = AccountPayableInternetDistributionDetail.AccountPayableInternet.Copy()

                End If

                If Orders.Contains(AccountPayableInternetDistributionDetail.InternetOrderNumber) = False Then

                    Amount = AccountPayableInternetDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                                 Entity.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber) _
                                                                         .Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber) _
                                            .Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableInternetDistributionDetail.InternetOrderNumber.ToString.PadLeft(6, "0") & " [IN]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableInternetDistributionDetail.AccountPayableInternet.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableInternetDistributionDetail.ClientCode, AccountPayableInternetDistributionDetail.DivisionCode,
                           AccountPayableInternetDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableInternetDistributionDetail.InternetOrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableInternetDistributionDetail.OfficeCode) = False AndAlso AccountPayableInternetDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableInternetDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableInternetDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount)

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                                        .Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableInternet.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableInternet.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableInternet.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableInternet.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableInternet.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableInternet.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableInternet.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableInternet.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableInternet.DbContext = DbContext
                AccountPayableInternet.AccountPayableID = AccountPayable.ID
                AccountPayableInternet.AccountPayableSequenceNumber = 0
                AccountPayableInternet.GLTransaction = GLTransaction
                AccountPayableInternet.GLSequenceNumber = Orders.Item(AccountPayableInternetDistributionDetail.InternetOrderNumber.ToString)
                AccountPayableInternet.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableInternet.CreateDate = Now.ToString
                AccountPayableInternet.CreatedBy = DbContext.UserCode

                AccountPayableInternet.InternetOrderNumber = AccountPayableInternetDistributionDetail.InternetOrderNumber
                AccountPayableInternet.InternetDetailLineNumber = AccountPayableInternetDistributionDetail.InternetDetailLineNumber

                AccountPayableInternet.DiscountAmount = Math.Abs(AccountPayableInternet.DiscountAmount.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableInternet.Insert(DbContext, AccountPayableInternet) = False Then

                    Throw New Exception("Failed to insert AP Internet.")

                End If

            End If

        End Sub
        Public Sub AddMagazine(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableMagazineDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail,
                               ByVal AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail),
                               ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                               ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                               ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableMagazine As AdvantageFramework.Database.Entities.AccountPayableMagazine = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableMagazineDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableMagazineDistributionDetail.NetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableMagazineDistributionDetail.BleedNetAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableMagazineDistributionDetail.PositionNetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableMagazineDistributionDetail.PremiumNetAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableMagazineDistributionDetail.ColorNetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableMagazineDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso AccountPayableMagazineDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso
                    String.IsNullOrWhiteSpace(AccountPayableMagazineDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableMagazineDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableMagazineDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableMagazineDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableMagazineDistributionDetail.OrderNumber,
                                                                           AccountPayableMagazineDistributionDetail.OrderLineNumber, "M", AccountPayableMagazineDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableMagazineDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableMagazineDistributionDetail.AccountPayableMagazine.IsEntityBeingAdded() Then

                    AccountPayableMagazine = AccountPayableMagazineDistributionDetail.AccountPayableMagazine

                Else

                    AccountPayableMagazine = AccountPayableMagazineDistributionDetail.AccountPayableMagazine.Copy()

                End If

                If Orders.Contains(AccountPayableMagazineDistributionDetail.OrderNumber) = False Then

                    Amount = AccountPayableMagazineDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                Entity.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber) _
                                            .Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableMagazineDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [MA]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableMagazineDistributionDetail.AccountPayableMagazine.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableMagazineDistributionDetail.ClientCode, AccountPayableMagazineDistributionDetail.DivisionCode,
                           AccountPayableMagazineDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableMagazineDistributionDetail.OrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableMagazineDistributionDetail.OfficeCode) = False AndAlso AccountPayableMagazineDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableMagazineDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableMagazineDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableMagazine.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableMagazine.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableMagazine.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableMagazine.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableMagazine.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableMagazine.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableMagazine.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableMagazine.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableMagazine.DbContext = DbContext
                AccountPayableMagazine.AccountPayableID = AccountPayable.ID
                AccountPayableMagazine.AccountPayableSequenceNumber = 0
                AccountPayableMagazine.GLTransaction = GLTransaction
                AccountPayableMagazine.GLSequenceNumber = Orders.Item(AccountPayableMagazineDistributionDetail.OrderNumber.ToString)
                AccountPayableMagazine.PostPeriodCode = AccountPayable.PostPeriodCode

                AccountPayableMagazine.OrderNumber = AccountPayableMagazineDistributionDetail.OrderNumber
                AccountPayableMagazine.OrderLineNumber = AccountPayableMagazineDistributionDetail.OrderLineNumber

                AccountPayableMagazine.CreateDate = Now.ToString
                AccountPayableMagazine.CreatedBy = DbContext.UserCode

                AccountPayableMagazine.DiscountLN = Math.Abs(AccountPayableMagazine.DiscountLN.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableMagazine.Insert(DbContext, AccountPayableMagazine) = False Then

                    Throw New Exception("Failed to insert AP Magazine.")

                End If

            End If

        End Sub
        Public Sub AddNewspaper(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableNewspaperDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail,
                                ByVal AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail),
                                ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                                ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableNewspaper As AdvantageFramework.Database.Entities.AccountPayableNewspaper = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableNewspaperDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableNewspaperDistributionDetail.NetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableNewspaperDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso AccountPayableNewspaperDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableNewspaperDistributionDetail.PrintLines.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(AccountPayableNewspaperDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableNewspaperDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableNewspaperDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableNewspaperDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableNewspaperDistributionDetail.OrderNumber,
                                                                           AccountPayableNewspaperDistributionDetail.OrderLineNumber, "N", AccountPayableNewspaperDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableNewspaperDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.IsEntityBeingAdded() Then

                    AccountPayableNewspaper = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper

                Else

                    AccountPayableNewspaper = AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.Copy()

                End If

                If Orders.Contains(AccountPayableNewspaperDistributionDetail.OrderNumber) = False Then

                    Amount = AccountPayableNewspaperDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                                  Entity.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber) _
                                            .Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableNewspaperDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [NP]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableNewspaperDistributionDetail.AccountPayableNewspaper.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableNewspaperDistributionDetail.ClientCode, AccountPayableNewspaperDistributionDetail.DivisionCode,
                           AccountPayableNewspaperDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableNewspaperDistributionDetail.OrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableNewspaperDistributionDetail.OfficeCode) = False AndAlso AccountPayableNewspaperDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableNewspaperDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableNewspaperDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableNewspaper.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableNewspaper.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableNewspaper.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableNewspaper.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableNewspaper.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableNewspaper.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableNewspaper.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableNewspaper.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableNewspaper.DbContext = DbContext
                AccountPayableNewspaper.AccountPayableID = AccountPayable.ID
                AccountPayableNewspaper.AccountPayableSequenceNumber = 0
                AccountPayableNewspaper.GLTransaction = GLTransaction
                AccountPayableNewspaper.GLSequenceNumber = Orders.Item(AccountPayableNewspaperDistributionDetail.OrderNumber.ToString)
                AccountPayableNewspaper.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableNewspaper.CreateDate = Now.ToString
                AccountPayableNewspaper.CreatedBy = DbContext.UserCode

                AccountPayableNewspaper.OrderNumber = AccountPayableNewspaperDistributionDetail.OrderNumber
                AccountPayableNewspaper.OrderLineNumber = AccountPayableNewspaperDistributionDetail.OrderLineNumber

                AccountPayableNewspaper.DiscountLN = Math.Abs(AccountPayableNewspaper.DiscountLN.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableNewspaper.Insert(DbContext, AccountPayableNewspaper) = False Then

                    Throw New Exception("Failed to insert AP Newspaper.")

                End If

            End If

        End Sub
        Public Sub AddOutOfHome(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableOutOfHomeDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail,
                                ByVal AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail),
                                ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                                ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableOutOfHome As AdvantageFramework.Database.Entities.AccountPayableOutOfHome = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableOutOfHomeDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableOutOfHomeDistributionDetail.NetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableOutOfHomeDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso AccountPayableOutOfHomeDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso
                    String.IsNullOrWhiteSpace(AccountPayableOutOfHomeDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber,
                                                                           AccountPayableOutOfHomeDistributionDetail.OutdoorDetailLineNumber, "O", AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableOutOfHomeDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.IsEntityBeingAdded() Then

                    AccountPayableOutOfHome = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome

                Else

                    AccountPayableOutOfHome = AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.Copy()

                End If

                If Orders.Contains(AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) = False Then

                    Amount = AccountPayableOutOfHomeDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                                  Entity.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) _
                                                                          .Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber) _
                                            .Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber.ToString.PadLeft(6, "0") & " [OD]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableOutOfHomeDistributionDetail.AccountPayableOutOfHome.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableOutOfHomeDistributionDetail.ClientCode, AccountPayableOutOfHomeDistributionDetail.DivisionCode,
                           AccountPayableOutOfHomeDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableOutOfHome.OfficeCode) = False AndAlso AccountPayableOutOfHome.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableOutOfHomeDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableOutOfHomeDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                                        .Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode) _
                                                        .Sum(Function(Entity) Entity.NetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableOutOfHome.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableOutOfHome.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableOutOfHome.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableOutOfHome.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableOutOfHome.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableOutOfHome.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableOutOfHome.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableOutOfHome.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableOutOfHome.DbContext = DbContext
                AccountPayableOutOfHome.AccountPayableID = AccountPayable.ID
                AccountPayableOutOfHome.AccountPayableSequenceNumber = 0
                AccountPayableOutOfHome.GLTransaction = GLTransaction
                AccountPayableOutOfHome.GLSequenceNumber = Orders.Item(AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber.ToString)
                AccountPayableOutOfHome.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableOutOfHome.CreateDate = Now.ToString
                AccountPayableOutOfHome.CreatedBy = DbContext.UserCode

                AccountPayableOutOfHome.OutdoorOrderNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorOrderNumber
                AccountPayableOutOfHome.OutdoorDetailLineNumber = AccountPayableOutOfHomeDistributionDetail.OutdoorDetailLineNumber

                AccountPayableOutOfHome.DiscountAmount = Math.Abs(AccountPayableOutOfHome.DiscountAmount.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.Insert(DbContext, AccountPayableOutOfHome) = False Then

                    Throw New Exception("Failed to insert AP Outdoor.")

                End If

            End If

        End Sub
        Public Sub AddProduction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail,
                                 ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail),
                                 ByRef AccountPayableProductionNew As AdvantageFramework.Database.Entities.AccountPayableProduction,
                                 ByRef GLTransaction As Integer, ByVal Remark As String, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                 ByRef JobComponent As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                                 ByVal VendorName As String, ByVal PostPeriodChanged As Boolean, ByVal AgencyInvoiceTaxFlag As Boolean, ByVal GLSourceCode As String,
                                 ByVal BatchDate As Nullable(Of Date), GetABFlagFromJobComponent As Boolean)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim JobComponentEntity As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If Not (AccountPayableProductionDistributionDetail.Disbursed.GetValueOrDefault(0) = 0 AndAlso AccountPayableProductionDistributionDetail.Quantity.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableProductionDistributionDetail.ExtendedNonResaleTax.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableProductionDistributionDetail.ResaleTax = 0) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If JobComponent.Contains(AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" &
                                     AccountPayableProductionDistributionDetail.GLACode) = False Then

                    Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                                   Entity.JobNumber = AccountPayableProductionDistributionDetail.JobNumber AndAlso
                                                                                                   Entity.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber AndAlso
                                                                                                   Entity.GLACode = AccountPayableProductionDistributionDetail.GLACode).Sum(Function(Entity) Entity.Disbursed.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.JobNumber = AccountPayableProductionDistributionDetail.JobNumber AndAlso
                                                                    Entity.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber AndAlso
                                                                    Entity.GLACode = AccountPayableProductionDistributionDetail.GLACode) _
                                            .Sum(Function(Entity) Entity.ExtendedAmount.GetValueOrDefault(0) + Entity.ExtendedNonResaleTax.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableProductionDistributionDetail.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableProductionDistributionDetail.ClientCode, AccountPayableProductionDistributionDetail.DivisionCode,
                           AccountPayableProductionDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    JobComponent.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" &
                                     AccountPayableProductionDistributionDetail.GLACode)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If AdvantageFramework.GeneralLedger.OfficeDiffers(DbContext, AccountPayable.GLACode, AccountPayableProductionDistributionDetail.GLACode, AccountPayable.OfficeCode, AccountPayableProductionDistributionDetail.OfficeCode) Then

                        OfficeInterCompanyCode = AccountPayableProductionDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.Disbursed.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                                        .Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode) _
                                                        .Sum(Function(Entity) Entity.ExtendedAmount.GetValueOrDefault(0) + Entity.ExtendedNonResaleTax.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableProductionNew.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableProductionNew.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableProductionNew.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableProductionNew.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableProductionNew.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableProductionNew.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableProductionNew.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableProductionNew.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableProductionNew.DbContext = DbContext
                AccountPayableProductionNew.AccountPayableID = AccountPayable.ID
                AccountPayableProductionNew.AccountPayableSequenceNumber = 0
                AccountPayableProductionNew.LineNumber = 0
                AccountPayableProductionNew.GLTransaction = GLTransaction
                AccountPayableProductionNew.GLSequenceNumber = JobComponent.Item(AccountPayableProductionDistributionDetail.JobNumber & "|" & AccountPayableProductionDistributionDetail.JobComponentNumber & "|" &
                                                                                 AccountPayableProductionDistributionDetail.GLACode)

                AccountPayableProductionNew.JobNumber = AccountPayableProductionDistributionDetail.JobNumber
                AccountPayableProductionNew.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber
                AccountPayableProductionNew.LineTotal = AccountPayableProductionDistributionDetail.LineTotal
                AccountPayableProductionNew.CreateDate = Now.ToString
                AccountPayableProductionNew.CreatedBy = DbContext.UserCode

                If GetABFlagFromJobComponent Then

                    JobComponentEntity = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, AccountPayableProductionDistributionDetail.JobNumber, AccountPayableProductionDistributionDetail.JobComponentNumber)

                    If JobComponentEntity Is Nothing Then

                        Throw New Exception("Cannot find job component.")

                    End If

                    AccountPayableProductionNew.IsAdvanceBilling = If(JobComponentEntity.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)

                End If

                If AgencyInvoiceTaxFlag Then

                    SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, AccountPayableProductionNew.SalesTaxCode)

                    If SalesTax IsNot Nothing AndAlso SalesTax.Resale.GetValueOrDefault(0) = 1 Then

                        AccountPayableProductionNew.SalesTaxCode = Nothing

                        AccountPayableProductionNew.LineTotal = AccountPayableProductionNew.LineTotal -
                                                                AccountPayableProductionNew.ExtendedStateResale.GetValueOrDefault(0) -
                                                                AccountPayableProductionNew.ExtendedCountyResale.GetValueOrDefault(0) -
                                                                AccountPayableProductionNew.ExtendedCityResale.GetValueOrDefault(0)

                        AccountPayableProductionNew.IsResaleTax = 0
                        AccountPayableProductionNew.ExtendedStateResale = 0
                        AccountPayableProductionNew.ExtendedCountyResale = 0
                        AccountPayableProductionNew.ExtendedCityResale = 0

                        AccountPayableProductionNew.CityTaxPercent = 0
                        AccountPayableProductionNew.CountyTaxPercent = 0
                        AccountPayableProductionNew.StateTaxPercent = 0

                    End If

                End If

                AccountPayableProductionNew.AccountReceivableInvoiceNumber = Nothing
                AccountPayableProductionNew.AccountReceivableInvoiceSequenceNumber = Nothing
                AccountPayableProductionNew.AccountReceivableType = Nothing
                AccountPayableProductionNew.GLTransactionBill = Nothing
                AccountPayableProductionNew.GLSequenceNumberSales = Nothing
                AccountPayableProductionNew.GLSequenceNumberCOS = Nothing
                AccountPayableProductionNew.GLSequenceNumberState = Nothing
                AccountPayableProductionNew.GLSequenceNumberCounty = Nothing
                AccountPayableProductionNew.GLSequenceNumberCity = Nothing
                AccountPayableProductionNew.GLSequenceNumberWIP = Nothing
                AccountPayableProductionNew.GLACodeSales = Nothing
                AccountPayableProductionNew.GLACodeCOS = Nothing
                AccountPayableProductionNew.GLACodeState = Nothing
                AccountPayableProductionNew.GLACodeCounty = Nothing
                AccountPayableProductionNew.GLACodeCity = Nothing

                If AdvantageFramework.Database.Procedures.AccountPayableProduction.Insert(DbContext, AccountPayableProductionNew) = False Then

                    Throw New Exception("Failed to insert AP Production.")

                End If

            End If

        End Sub
        Public Sub AddRadio(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableRadioDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail,
                            ByVal AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail),
                            ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                            ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                            ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableRadio As AdvantageFramework.Database.Entities.AccountPayableRadio = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableRadioDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableRadioDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableRadioDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso AccountPayableRadioDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableRadioDistributionDetail.TotalSpots.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(AccountPayableRadioDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableRadioDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableRadioDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableRadioDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableRadioDistributionDetail.OrderNumber,
                                                                           AccountPayableRadioDistributionDetail.OrderLineNumber, "R", AccountPayableRadioDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableRadioDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableRadioDistributionDetail.AccountPayableRadio.IsEntityBeingAdded() Then

                    AccountPayableRadio = AccountPayableRadioDistributionDetail.AccountPayableRadio

                Else

                    AccountPayableRadio = AccountPayableRadioDistributionDetail.AccountPayableRadio.Copy()

                End If

                If Orders.Contains(AccountPayableRadioDistributionDetail.OrderNumber) = False Then

                    Amount = AccountPayableRadioDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                              Entity.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber) _
                                            .Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableRadioDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [RA]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableRadioDistributionDetail.AccountPayableRadio.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableRadioDistributionDetail.ClientCode, AccountPayableRadioDistributionDetail.DivisionCode,
                           AccountPayableRadioDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableRadioDistributionDetail.OrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableRadioDistributionDetail.OfficeCode) = False AndAlso AccountPayableRadioDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableRadioDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableRadioDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                                        .Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode) _
                                                        .Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableRadio.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableRadio.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableRadio.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableRadio.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableRadio.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableRadio.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableRadio.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableRadio.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableRadio.DbContext = DbContext
                AccountPayableRadio.AccountPayableID = AccountPayable.ID
                AccountPayableRadio.AccountPayableSequenceNumber = 0
                AccountPayableRadio.GLTransaction = GLTransaction
                AccountPayableRadio.GLSequenceNumber = Orders.Item(AccountPayableRadioDistributionDetail.OrderNumber.ToString)
                AccountPayableRadio.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableRadio.CreateDate = Now.ToString
                AccountPayableRadio.CreatedBy = DbContext.UserCode

                If AccountPayableRadio.RewriteFlag = 0 Then

                    AccountPayableRadio.TotalSpots = 0

                End If

                AccountPayableRadio.OrderNumber = AccountPayableRadioDistributionDetail.OrderNumber

                AccountPayableRadio.DiscountAmount = Math.Abs(AccountPayableRadio.DiscountAmount.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableRadio.Insert(DbContext, AccountPayableRadio) = False Then

                    Throw New Exception("Failed to insert AP Radio.")

                End If

            End If

        End Sub
        Public Sub AddRadioDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                  ByVal AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail,
                                  ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            AccountPayableRadioBroadcastDetail.AccountPayableID = AccountPayable.ID
            AccountPayableRadioBroadcastDetail.AccountPayableSequenceNumber = AccountPayable.SequenceNumber

            If AccountPayableRadioBroadcastDetail.IsEntityBeingAdded() = False Then

                AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Update(DbContext, AccountPayableRadioBroadcastDetail)

            Else

                AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.Insert(DbContext, AccountPayableRadioBroadcastDetail)

            End If

        End Sub
        Public Sub AddTV(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableTVDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail,
                         ByVal AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail),
                         ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                         ByRef Orders As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                         ByVal VendorName As String, ByVal GLSourceCode As String, Optional ByVal PostPeriodChanged As Boolean = False, Optional ByVal BatchDate As Nullable(Of Date) = Nothing)

            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyCode As String = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim AccountPayableTV As AdvantageFramework.Database.Entities.AccountPayableTV = Nothing
            Dim Remark As String = Nothing

            If Not (AccountPayableTVDistributionDetail.DisbursedAmount.GetValueOrDefault(0) = 0 AndAlso AccountPayableTVDistributionDetail.ExtendedNetAmount.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableTVDistributionDetail.NetCharges.GetValueOrDefault(0) = 0 AndAlso AccountPayableTVDistributionDetail.VendorTax.GetValueOrDefault(0) = 0 AndAlso
                    AccountPayableTVDistributionDetail.TotalSpots.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(AccountPayableTVDistributionDetail.NewApprovalComments)) Then

                If GLTransaction = -1 Then

                    GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, DbContext.UserCode, GLSourceCode, BatchDate)

                End If

                If AccountPayableTVDistributionDetail.NewApprovalStatus IsNot Nothing Then

                    If AccountPayableTVDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.None Then

                        AccountPayableTVDistributionDetail.NewApprovalStatus = Nothing

                    End If

                    If AdvantageFramework.AccountPayable.SaveMediaApproval(DbContext, AccountPayable.ID, AccountPayableTVDistributionDetail.OrderNumber,
                                                                           AccountPayableTVDistributionDetail.OrderLineNumber, "T", AccountPayableTVDistributionDetail.NewApprovalStatus,
                                                                           DbContext.UserCode, AccountPayableTVDistributionDetail.NewApprovalComments) = False Then

                        Throw New Exception("Failed to insert AP Media Approval.")

                    End If

                End If

                If AccountPayableTVDistributionDetail.AccountPayableTV.IsEntityBeingAdded() Then

                    AccountPayableTV = AccountPayableTVDistributionDetail.AccountPayableTV

                Else

                    AccountPayableTV = AccountPayableTVDistributionDetail.AccountPayableTV.Copy()

                End If

                If Orders.Contains(AccountPayableTVDistributionDetail.OrderNumber) = False Then

                    Amount = AccountPayableTVDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                           Entity.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                    If Not PostPeriodChanged Then

                        Try

                            OldAmount = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                            .Where(Function(Entity) Entity.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber) _
                                            .Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                        Catch ex As Exception
                            OldAmount = 0
                        End Try

                        Amount = Amount - OldAmount

                    End If

                    Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable) & ", Order: " & AccountPayableTVDistributionDetail.OrderNumber.ToString.PadLeft(6, "0") & " [TV]"

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableTVDistributionDetail.AccountPayableTV.GLACode,
                           Amount, Remark, GLSourceCode, AccountPayableTVDistributionDetail.ClientCode, AccountPayableTVDistributionDetail.DivisionCode,
                           AccountPayableTVDistributionDetail.ProductCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    Orders.Add(GeneralLedgerDetail.SequenceNumber, AccountPayableTVDistributionDetail.OrderNumber)

                End If

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(AccountPayable.OfficeCode) = False AndAlso String.IsNullOrWhiteSpace(AccountPayableTVDistributionDetail.OfficeCode) = False AndAlso AccountPayableTVDistributionDetail.OfficeCode <> AccountPayable.OfficeCode Then

                        OfficeInterCompanyCode = AccountPayableTVDistributionDetail.OfficeCode

                        Try

                            OfficeInterCompany = (From Entity In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, AccountPayable.OfficeCode)
                                                  Where Entity.Code = OfficeInterCompanyCode
                                                  Select Entity).SingleOrDefault

                        Catch ex As Exception
                            Throw New Exception("Error gathering inter-company account code information.  Please make sure all intercompany information has been set up in Office Maintenance.")
                        End Try

                        If OfficeInterCompany IsNot Nothing Then

                            If OfficeCodeList.Contains(OfficeInterCompanyCode) = False Then

                                OfficeCodeList.Add(OfficeInterCompanyCode)

                                Amount = AccountPayableTVDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.DisbursedAmount.GetValueOrDefault(0))

                                If Not PostPeriodChanged Then

                                    Try

                                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableTV.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).ToList _
                                                        .Where(Function(Entity) Entity.OfficeCode = OfficeInterCompanyCode) _
                                                        .Sum(Function(Entity) Entity.ExtendedNetAmount.GetValueOrDefault(0) + Entity.DiscountAmount.GetValueOrDefault(0) + Entity.NetCharges.GetValueOrDefault(0) + Entity.VendorTax.GetValueOrDefault(0))

                                    Catch ex As Exception
                                        OldAmount = 0
                                    End Try

                                    Amount = Amount - OldAmount

                                End If

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueFromGLACode,
                                        Amount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableTV.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableTV.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, OfficeInterCompany.DueToGLACode,
                                        Amount * -1, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Problem inserting General Ledger Detail.")

                                End If

                                DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, OfficeInterCompanyCode)

                                AccountPayableTV.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableTV.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            Else

                                AccountPayableTV.GLACodeDueFrom = OfficeInterCompany.DueFromGLACode
                                AccountPayableTV.GLSequenceNumberDueFrom = DueFromSeqNo.Item(OfficeInterCompanyCode)

                                AccountPayableTV.GLACodeDueTo = OfficeInterCompany.DueToGLACode
                                AccountPayableTV.GLSequenceNumberDueTo = DueToSeqNo.Item(OfficeInterCompanyCode)

                            End If

                        End If

                    End If

                End If

                AccountPayableTV.DbContext = DbContext
                AccountPayableTV.AccountPayableID = AccountPayable.ID
                AccountPayableTV.AccountPayableSequenceNumber = 0
                AccountPayableTV.GLTransaction = GLTransaction
                AccountPayableTV.GLSequenceNumber = Orders.Item(AccountPayableTVDistributionDetail.OrderNumber.ToString)
                AccountPayableTV.PostPeriodCode = AccountPayable.PostPeriodCode
                AccountPayableTV.CreateDate = Now.ToString
                AccountPayableTV.CreatedBy = DbContext.UserCode

                If AccountPayableTV.RewriteFlag = 0 Then

                    AccountPayableTV.TotalSpots = 0

                End If

                AccountPayableTV.OrderNumber = AccountPayableTVDistributionDetail.OrderNumber

                AccountPayableTV.DiscountAmount = Math.Abs(AccountPayableTV.DiscountAmount.GetValueOrDefault(0)) * -1

                If AdvantageFramework.Database.Procedures.AccountPayableTV.Insert(DbContext, AccountPayableTV) = False Then

                    Throw New Exception("Failed to insert AP TV.")

                End If

            End If

        End Sub
        Public Sub AddTVDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail,
                               ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            AccountPayableTVBroadcastDetail.AccountPayableID = AccountPayable.ID
            AccountPayableTVBroadcastDetail.AccountPayableSequenceNumber = AccountPayable.SequenceNumber

            If AccountPayableTVBroadcastDetail.IsEntityBeingAdded() = False Then

                AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Update(DbContext, AccountPayableTVBroadcastDetail)

            Else

                AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.Insert(DbContext, AccountPayableTVBroadcastDetail)

            End If

        End Sub
        Public Function CreateInvoicesFromImport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                 ByVal ImportAccountPayables As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable),
                                                 ByVal PostPeriodCode As String,
                                                 Session As AdvantageFramework.Security.Session) As Boolean

            Dim Imported As Boolean = True
            Dim ImportIDs As Generic.List(Of Integer) = Nothing
            Dim ImportID As Integer = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim GLSourceCode As String = "IA"
            Dim BatchDate As Date = Now
            Dim ImportAccountPayableEntity As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportAccountPayableList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
            Dim ImportAccountPayableJob As AdvantageFramework.Database.Entities.ImportAccountPayableJob = Nothing
            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing
            Dim AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) = Nothing
            Dim AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail) = Nothing
            Dim AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail) = Nothing
            Dim AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail) = Nothing
            Dim AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail) = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail) = Nothing
            Dim AccountPayableRadioBroadcastDetailList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail) = Nothing
            Dim AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail) = Nothing
            Dim AccountPayableTVBroadcastDetailList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail) = Nothing
            Dim ImportAccountPayableBroadcastDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ImportAccountPayableBroadcastDetail) = Nothing
            Dim AccountPayableDocument As AdvantageFramework.Database.Entities.AccountPayableDocument = Nothing
            Dim AccountPayableDocuments As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableDocument) = Nothing
            Dim ImportDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ImportDocument) = Nothing
            Dim PercentThreshold As Decimal? = Nothing
            Dim ForcePending As Boolean = False
            Dim HasPending As Boolean = False
            Dim AccountPayableMediaImportAlerts As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMediaImportAlert) = Nothing
            Dim AllAccountPayableMediaImportAlerts As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMediaImportAlert) = Nothing
            Dim AccountPayableMediaImportAlert As AdvantageFramework.AccountPayable.Classes.AccountPayableMediaImportAlert = Nothing
            Dim MediaImportAlertBuyer As Boolean = False
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            Try

                DbContext.Configuration.AutoDetectChangesEnabled = False

                ImportIDs = ImportAccountPayables.Select(Function(IAP) IAP.ID).Distinct.ToList()

                AccountPayableDocuments = New List(Of Database.Entities.AccountPayableDocument)

                MediaImportAlertBuyer = AdvantageFramework.Agency.GetOptionAPMediaImportAlertBuyer(DbContext)
                AllAccountPayableMediaImportAlerts = New List(Of Classes.AccountPayableMediaImportAlert)

                For Each ImportID In ImportIDs

                    HasPending = False
                    AccountPayableGLDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail)
                    AccountPayableInternetDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail)
                    AccountPayableMagazineDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail)
                    AccountPayableNewspaperDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail)
                    AccountPayableOutOfHomeDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail)
                    AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)
                    AccountPayableRadioDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail)
                    AccountPayableRadioBroadcastDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail)
                    AccountPayableTVDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail)
                    AccountPayableTVBroadcastDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail)

                    AccountPayableMediaImportAlerts = New List(Of Classes.AccountPayableMediaImportAlert)

                    ImportAccountPayable = ImportAccountPayables.Where(Function(IAP) IAP.ID = ImportID).FirstOrDefault

                    AccountPayable = CreateAccountPayable(DbContext, ImportAccountPayable, PostPeriodCode)

                    If AccountPayable IsNot Nothing Then

                        ImportAccountPayableList = ImportAccountPayables.Where(Function(IAP) IAP.ID = ImportID).ToList

                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.ImportTemplateID)

                        If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast AndAlso
                                        Not String.IsNullOrWhiteSpace(ImportAccountPayable.StateTaxGLAccount) AndAlso ImportAccountPayable.StateTaxAmount.GetValueOrDefault(0) <> 0 Then

                            ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
                            ImportAccountPayableGL.DbContext = DbContext

                            ImportAccountPayableGL.GLNetAmount = ImportAccountPayable.StateTaxAmount
                            ImportAccountPayableGL.GLACode = ImportAccountPayable.StateTaxGLAccount
                            ImportAccountPayableGL.OfficeCodeDetail = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.GetOfficeCodeByGLACode(DbContext, ImportAccountPayableGL.GLACode)

                            AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail(ImportAccountPayableGL, DbContext))

                        End If

                        If ImportTemplate.Type = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast AndAlso
                                        Not String.IsNullOrWhiteSpace(ImportAccountPayable.CityTaxGLAccount) AndAlso ImportAccountPayable.CityTaxAmount.GetValueOrDefault(0) <> 0 Then

                            ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
                            ImportAccountPayableGL.DbContext = DbContext

                            ImportAccountPayableGL.GLNetAmount = ImportAccountPayable.CityTaxAmount
                            ImportAccountPayableGL.GLACode = ImportAccountPayable.CityTaxGLAccount
                            ImportAccountPayableGL.OfficeCodeDetail = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.GetOfficeCodeByGLACode(DbContext, ImportAccountPayableGL.GLACode)

                            AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail(ImportAccountPayableGL, DbContext))

                        End If

                        For Each ImportAccountPayable In ImportAccountPayableList

                            If TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableGL Then

                                ImportAccountPayableGL = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableGL)
                                AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail(ImportAccountPayableGL, DbContext))

                            ElseIf TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableJob Then

                                ImportAccountPayableJob = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableJob)
                                AccountPayableProductionDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, ImportAccountPayableJob, Session))

                            ElseIf TypeOf (ImportAccountPayable.GetDetail) Is AdvantageFramework.Database.Entities.ImportAccountPayableMedia Then

                                ImportAccountPayableMedia = CType(ImportAccountPayable.GetDetail, AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

                                Select Case ImportAccountPayableMedia.MediaType

                                    Case "I"

                                        AccountPayableInternetDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail(DbContext, ImportAccountPayableMedia))

                                    Case "M"

                                        AccountPayableMagazineDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail(DbContext, ImportAccountPayableMedia))

                                    Case "N"

                                        AccountPayableNewspaperDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail(DbContext, ImportAccountPayableMedia))

                                    Case "O"

                                        AccountPayableOutOfHomeDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail(DbContext, ImportAccountPayableMedia))

                                    Case "R"

                                        AccountPayableRadioDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail(DbContext, ImportAccountPayableMedia))
                                        ImportAccountPayableBroadcastDetailList = DbContext.ImportAccountPayableBroadcastDetails.Where(Function(d) d.ImportAccountPayableMediaID = ImportAccountPayableMedia.ID).ToList

                                        If ImportAccountPayableBroadcastDetailList IsNot Nothing AndAlso ImportAccountPayableBroadcastDetailList.Count > 0 Then

                                            AccountPayableRadioBroadcastDetailList.AddRange((From Item In ImportAccountPayableBroadcastDetailList
                                                                                             Select New AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail With {
                                                                                                .OrderNumber = AccountPayableRadioDistributionDetailList.Last.OrderNumber,
                                                                                                .OrderLineNumber = AccountPayableRadioDistributionDetailList.Last.OrderLineNumber,
                                                                                                .RunDate = Item.RunDate,
                                                                                                .DayOfWeek = Item.DayOfWeek,
                                                                                                .TimeOfDay = Item.TimeOfDay,
                                                                                                .Length = Item.Length,
                                                                                                .AdNumber = Item.AdNumber,
                                                                                                .NetRate = Item.NetRate,
                                                                                                .GrossRate = Item.GrossRate,
                                                                                                .Piggyback = Item.Piggyback,
                                                                                                .ProgramName = Item.ProgramName,
                                                                                                .NetworkID = Item.NetworkID,
                                                                                                .PackageCode = Item.PackageCode
                                                                                             }).ToList)

                                        End If

                                    Case "T"

                                        AccountPayableTVDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail(DbContext, ImportAccountPayableMedia))
                                        ImportAccountPayableBroadcastDetailList = DbContext.ImportAccountPayableBroadcastDetails.Where(Function(d) d.ImportAccountPayableMediaID = ImportAccountPayableMedia.ID).ToList

                                        If ImportAccountPayableBroadcastDetailList IsNot Nothing AndAlso ImportAccountPayableBroadcastDetailList.Count > 0 Then

                                            AccountPayableTVBroadcastDetailList.AddRange((From Item In ImportAccountPayableBroadcastDetailList
                                                                                          Select New AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail With {
                                                                                                .OrderNumber = AccountPayableTVDistributionDetailList.Last.OrderNumber,
                                                                                                .OrderLineNumber = AccountPayableTVDistributionDetailList.Last.OrderLineNumber,
                                                                                                .RunDate = Item.RunDate,
                                                                                                .DayOfWeek = Item.DayOfWeek,
                                                                                                .TimeOfDay = Item.TimeOfDay,
                                                                                                .Length = Item.Length,
                                                                                                .AdNumber = Item.AdNumber,
                                                                                                .NetRate = Item.NetRate,
                                                                                                .GrossRate = Item.GrossRate,
                                                                                                .Piggyback = Item.Piggyback,
                                                                                                .ProgramName = Item.ProgramName,
                                                                                                .NetworkID = Item.NetworkID,
                                                                                                .PackageCode = Item.PackageCode
                                                                                             }).ToList)

                                        End If

                                End Select

                            End If

                        Next

                        For Each ImportTemplateID In ImportAccountPayableList.Select(Function(i) i.GetImportAccountPayableHeader.ImportTemplateID).ToArray

                            ImportDocuments = AdvantageFramework.Database.Procedures.ImportDocument.LoadByImportIDAndTemplateID(DataContext, ImportID, ImportTemplateID).ToList

                            If ImportDocuments IsNot Nothing AndAlso ImportDocuments.Count > 0 Then

                                For Each ImportDocument In ImportDocuments

                                    If Not AccountPayableDocuments.Any(Function(d) d.AccountPayableID = AccountPayable.ID AndAlso d.DocumentID = ImportDocument.DocumentID) Then

                                        AccountPayableDocuments.Add(New Database.Entities.AccountPayableDocument With {.DocumentID = ImportDocument.DocumentID})

                                    End If

                                Next

                            End If

                        Next

                        If IsActivateApprovals(DbContext) Then

                            If AccountPayableInternetDistributionDetailList IsNot Nothing AndAlso AccountPayableInternetDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.Internet)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_INT))

                                For Each AccountPayableInternetDistributionDetail In AccountPayableInternetDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableInternetDistributionDetail.PreviouslyPosted + AccountPayableInternetDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableInternetDistributionDetail.OrderNetAmount) Then

                                        AccountPayableInternetDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                            If AccountPayableMagazineDistributionDetailList IsNot Nothing AndAlso AccountPayableMagazineDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.Print)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_PRI))

                                For Each AccountPayableMagazineDistributionDetail In AccountPayableMagazineDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableMagazineDistributionDetail.PreviouslyPosted + AccountPayableMagazineDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableMagazineDistributionDetail.OrderNetAmount) Then

                                        AccountPayableMagazineDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                            If AccountPayableNewspaperDistributionDetailList IsNot Nothing AndAlso AccountPayableNewspaperDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.Print)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_PRI))

                                For Each AccountPayableNewspaperDistributionDetail In AccountPayableNewspaperDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableNewspaperDistributionDetail.PreviouslyPosted + AccountPayableNewspaperDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableNewspaperDistributionDetail.OrderNetAmount) Then

                                        AccountPayableNewspaperDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                            If AccountPayableOutOfHomeDistributionDetailList IsNot Nothing AndAlso AccountPayableOutOfHomeDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.OutOfHome)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_OUT))

                                For Each AccountPayableOutOfHomeDistributionDetail In AccountPayableOutOfHomeDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableOutOfHomeDistributionDetail.PreviouslyPosted + AccountPayableOutOfHomeDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableOutOfHomeDistributionDetail.OrderNetAmount) Then

                                        AccountPayableOutOfHomeDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                            If AccountPayableRadioDistributionDetailList IsNot Nothing AndAlso AccountPayableRadioDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.Radio)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_RAD))

                                For Each AccountPayableRadioDistributionDetail In AccountPayableRadioDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableRadioDistributionDetail.PreviouslyPosted + AccountPayableRadioDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableRadioDistributionDetail.OrderNetAmount) Then

                                        AccountPayableRadioDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                            If AccountPayableTVDistributionDetailList IsNot Nothing AndAlso AccountPayableTVDistributionDetailList.Count > 0 Then

                                PercentThreshold = GetPercentThresholdByMedia(DbContext, MediaType.TV)
                                ForcePending = CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PENDING_TV))

                                For Each AccountPayableTVDistributionDetail In AccountPayableTVDistributionDetailList

                                    If ForcePending OrElse CheckRequiesApprovalByThreshold(PercentThreshold, AccountPayableTVDistributionDetail.PreviouslyPosted + AccountPayableTVDistributionDetail.DisbursedAmount.GetValueOrDefault(0), AccountPayableTVDistributionDetail.OrderNetAmount) Then

                                        AccountPayableTVDistributionDetail.NewApprovalStatus = AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly.PendingApproval
                                        HasPending = True

                                    End If

                                Next

                            End If

                        End If

                        If HasPending Then

                            If CBool(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.IMP_PAYMENT_HOLD)) Then

                                AccountPayable.IsOnHold = 1

                            End If

                        End If

                        VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayable.VendorCode).Name

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            AccountPayable.DbContext = DbContext

                            GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger.")

                            End If

                            CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable)
                            If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                                Throw New Exception("Failed trying to save data to General Ledger Detail.")

                            End If

                            AccountPayable.GLTransaction = GeneralLedger.Transaction
                            AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                            If AdvantageFramework.Database.Procedures.AccountPayable.Insert(DbContext, AccountPayable) = False Then

                                Throw New Exception("Insert to AP Header failed.")

                            End If

                            InsertNonClient(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, False)

                            For Each AccountPayableProductionDistributionDetail In AccountPayableProductionDistributionDetailList.Where(Function(APD) APD.PONumber.HasValue AndAlso APD.PODetailLineNumber.HasValue).Select(Function(APD) APD).ToList

                                'DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER SET PO_COMPLETE = 1 WHERE PO_NUMBER = {0}", PONumber))
                                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER_DET SET PO_COMPLETE = 1 WHERE PO_NUMBER = {0} AND LINE_NUMBER = {1}", AccountPayableProductionDistributionDetail.PONumber.Value, AccountPayableProductionDistributionDetail.PODetailLineNumber.Value))

                            Next

                            InsertProduction(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, False)

                            InsertMagazine(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableMagazineDistributionDetailList, GLSourceCode)

                            InsertNewspaper(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableNewspaperDistributionDetailList, GLSourceCode)

                            InsertInternet(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableInternetDistributionDetailList, GLSourceCode)

                            InsertOutOfHome(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableOutOfHomeDistributionDetailList, GLSourceCode)

                            InsertRadio(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableRadioDistributionDetailList, AccountPayableRadioBroadcastDetailList, GLSourceCode)

                            InsertTV(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableTVDistributionDetailList, AccountPayableTVBroadcastDetailList, GLSourceCode)

                            If MediaImportAlertBuyer Then

                                If AccountPayableMagazineDistributionDetailList IsNot Nothing AndAlso AccountPayableMagazineDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableMagazineDistributionDetailList.Where(Function(dist) dist.OrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.OrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.MAGAZINE_HEADER WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                If AccountPayableMagazineDistributionDetailList IsNot Nothing AndAlso AccountPayableMagazineDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableMagazineDistributionDetailList.Where(Function(dist) dist.OrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.OrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.NEWSPAPER_HEADER WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                If AccountPayableInternetDistributionDetailList IsNot Nothing AndAlso AccountPayableInternetDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableInternetDistributionDetailList.Where(Function(dist) dist.InternetOrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.InternetOrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.INTERNET_HEADER WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                If AccountPayableOutOfHomeDistributionDetailList IsNot Nothing AndAlso AccountPayableOutOfHomeDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableOutOfHomeDistributionDetailList.Where(Function(dist) dist.OutdoorOrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.OutdoorOrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.OUTDOOR_HEADER WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                If AccountPayableRadioDistributionDetailList IsNot Nothing AndAlso AccountPayableRadioDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableRadioDistributionDetailList.Where(Function(dist) dist.OrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.OrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.RADIO_HDR WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                If AccountPayableTVDistributionDetailList IsNot Nothing AndAlso AccountPayableTVDistributionDetailList.Count > 0 Then

                                    For Each OrderNumber In AccountPayableTVDistributionDetailList.Where(Function(dist) dist.OrderNumber.GetValueOrDefault(0) > 0).Select(Function(dist) dist.OrderNumber.GetValueOrDefault(0)).Distinct.ToList

                                        AccountPayableMediaImportAlert = New Classes.AccountPayableMediaImportAlert

                                        AccountPayableMediaImportAlert.InvoiceNumber = AccountPayable.InvoiceNumber
                                        AccountPayableMediaImportAlert.VendorCode = AccountPayable.VendorCode
                                        AccountPayableMediaImportAlert.VendorName = VendorName
                                        AccountPayableMediaImportAlert.OrderNumber = OrderNumber
                                        AccountPayableMediaImportAlert.EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT BUYER_EMP_CODE FROM dbo.TV_HDR WHERE ORDER_NBR = {0}", OrderNumber)).SingleOrDefault

                                        AccountPayableMediaImportAlerts.Add(AccountPayableMediaImportAlert)

                                    Next

                                End If

                                AccountPayableMediaImportAlerts = AccountPayableMediaImportAlerts.Where(Function(alrt) Not String.IsNullOrWhiteSpace(alrt.EmployeeCode)).ToList

                            End If

                            If AccountPayableDocuments IsNot Nothing AndAlso AccountPayableDocuments.Count > 0 Then

                                For Each AccountPayableDocument In AccountPayableDocuments

                                    AccountPayableDocument.DataContext = DataContext
                                    AccountPayableDocument.AccountPayableID = AccountPayable.ID

                                    AdvantageFramework.Database.Procedures.AccountPayableDocument.Insert(DataContext, AccountPayableDocument)

                                Next

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMPORT_DOCUMENTS WHERE DOCUMENT_ID IN ({0})", String.Join(",", AccountPayableDocuments.Select(Function(d) d.DocumentID).ToArray)))

                            End If

                            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                            If IsBalanced = 1 Then

                                ImportAccountPayableEntity = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByID(DbContext, ImportAccountPayable.ID)

                                AdvantageFramework.Database.Procedures.ImportAccountPayable.Delete(DbContext, ImportAccountPayableEntity)

                                DbTransaction.Commit()

                                AllAccountPayableMediaImportAlerts.AddRange(AccountPayableMediaImportAlerts)

                            Else

                                Throw New Exception("Cannot save.  Invoice out of balance.")

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            Imported = False
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                            'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        Imported = False

                    End If

                    If ErrorMessage <> "" Then

                        Throw New System.Exception(ErrorMessage)

                    End If

                Next

                If AllAccountPayableMediaImportAlerts.Count > 0 Then

                    CreateBuyerAlertsForImportedInvoices(Session, DbContext, AllAccountPayableMediaImportAlerts, "")

                End If

            Catch ex As Exception
                Imported = False
            Finally
                CreateInvoicesFromImport = Imported
                DbContext.Configuration.AutoDetectChangesEnabled = True
            End Try

        End Function
        Public Function CreateInvoicesFromExpenseReportImport(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                              ByVal AccountPayableExpenseReportItems As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem),
                                                              ByVal PostPeriodCode As String,
                                                              ByVal Session As AdvantageFramework.Security.Session,
                                                              ByRef ErrorMessage As String) As Boolean

            Dim Imported As Boolean = True
            Dim InvoiceNumbers As Generic.List(Of Integer) = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim VendorName As String = Nothing
            Dim GLDescription As String = Nothing
            Dim CreditAmount As Decimal = Nothing
            Dim Remark As String = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsBalanced As Integer = -1
            Dim GLSourceCode As String = Nothing
            Dim BatchDate As Date = Nothing
            Dim AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem = Nothing
            Dim AccountPayableGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail) = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem) = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim Approved As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport) = Nothing

            Try

                BatchDate = Now
                GLSourceCode = "XR"
                Approved = New List(Of Database.Entities.ExpenseReport)

                InvoiceNumbers = AccountPayableExpenseReportItems.Select(Function(Entity) Entity.InvoiceNumber).Distinct.ToList()

                For Each InvoiceNumber In InvoiceNumbers

                    AccountPayableGLDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail)
                    AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)

                    AccountPayableExpenseReportItem = AccountPayableExpenseReportItems.Where(Function(Entity) Entity.InvoiceNumber = InvoiceNumber).FirstOrDefault

                    If AccountPayableExpenseReportItem.Delete Then

                        ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                        If ExpenseReport IsNot Nothing AndAlso ExpenseReport.Status <> 4 Then

                            ErrorMessage = "Invoice Number " & InvoiceNumber & " has been altered by another user."

                        ElseIf ExpenseReport IsNot Nothing Then

                            ExpenseReport.Status = 2
                            ExpenseReport.BatchDate = BatchDate
                            ExpenseReport.ModifiedBy = Session.UserCode

                            DbContext.UpdateObject(ExpenseReport)
                            DbContext.SaveChanges()

                        ElseIf ExpenseReport Is Nothing Then

                            ErrorMessage = "Invoice Number " & InvoiceNumber & " not found in database."

                        End If

                    Else

                        AccountPayable = CreateAccountPayable(DbContext, AccountPayableExpenseReportItem, PostPeriodCode)

                        If AccountPayable IsNot Nothing Then

                            AccountPayableExpenseReportItemList = AccountPayableExpenseReportItems.Where(Function(Entity) Entity.InvoiceNumber = InvoiceNumber).ToList

                            For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                                If AccountPayableExpenseReportItem.JobNumber.GetValueOrDefault(0) <> 0 Then

                                    AccountPayableProductionDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, AccountPayableExpenseReportItem, Session))

                                Else

                                    AccountPayableGLDistributionDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayableGLDistributionDetail(AccountPayableExpenseReportItem, DbContext))

                                End If

                            Next

                            VendorName = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayable.VendorCode).Name

                            Try

                                DbContext.Database.Connection.Open()

                                DbTransaction = DbContext.Database.BeginTransaction

                                AccountPayable.DbContext = DbContext

                                GLDescription = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber
                                If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, BatchDate) = False Then

                                    Throw New Exception("Failed trying to save data to General Ledger.")

                                End If

                                CreditAmount = (AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount + AccountPayable.SalesTaxAmount) * -1
                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & FormatInvoice(AccountPayable)
                                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GeneralLedger.Transaction, AccountPayable.GLACode, CreditAmount, Remark, GLSourceCode) = False Then

                                    Throw New Exception("Failed trying to save data to General Ledger Detail.")

                                End If

                                AccountPayable.GLTransaction = GeneralLedger.Transaction
                                AccountPayable.GLSequenceNumber = GeneralLedgerDetail.SequenceNumber

                                If AdvantageFramework.Database.Procedures.AccountPayable.Insert(DbContext, AccountPayable) = False Then

                                    Throw New Exception("Insert to AP Header failed.")

                                End If

                                InsertNonClient(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableGLDistributionDetailList, GLSourceCode, False)

                                InsertProduction(DbContext, GeneralLedger.Transaction, AccountPayable, VendorName, AccountPayableProductionDistributionDetailList, GLSourceCode, False)

                                IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayable.ID, GeneralLedger.Transaction)).FirstOrDefault

                                If IsBalanced = 1 Then

                                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, InvoiceNumber)

                                    If ExpenseReport IsNot Nothing AndAlso ExpenseReport.Status <> 4 Then

                                        Throw New Exception("Invoice Number " & InvoiceNumber & " has been altered by another user.")

                                    ElseIf ExpenseReport IsNot Nothing Then

                                        ExpenseReport.Status = 2
                                        ExpenseReport.ApprovedBy = Session.User.EmployeeCode
                                        ExpenseReport.ApprovedDate = System.DateTime.Now
                                        DbContext.UpdateObject(ExpenseReport)
                                        DbContext.SaveChanges()

                                        'AdvantageFramework.ExpenseReports.ExpenseReportApprovedInAccounting(Session, DbContext, ExpenseReport)
                                        Approved.Add(ExpenseReport)

                                    ElseIf ExpenseReport Is Nothing Then

                                        Throw New Exception("Invoice Number " & InvoiceNumber & " not found in database.")

                                    End If

                                    DbTransaction.Commit()

                                Else

                                    Throw New Exception("Cannot save.  Invoice out of balance.")

                                End If

                            Catch ex As Exception
                                DbTransaction.Rollback()
                                Imported = False
                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                ErrorMessage += vbCrLf & ex.Message
                                'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                            Finally

                                If DbContext.Database.Connection.State = ConnectionState.Open Then

                                    DbContext.Database.Connection.Close()

                                End If

                            End Try

                        Else

                            Imported = False

                        End If

                    End If

                    If ErrorMessage <> "" Then

                        Throw New System.Exception(ErrorMessage)

                    End If

                Next
                Try

                    If Approved IsNot Nothing AndAlso Approved.Count > 0 Then

                        For Each ExpenseToEmail As AdvantageFramework.Database.Entities.ExpenseReport In Approved.Distinct.ToList

                            AdvantageFramework.ExpenseReports.ExpenseReportApprovedInAccounting(Session, DbContext, ExpenseToEmail)

                        Next

                    End If

                Catch ex As Exception
                End Try

            Catch ex As Exception
                Imported = False
            Finally
                CreateInvoicesFromExpenseReportImport = Imported
            End Try

        End Function
        Private Function CreateAccountPayable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AccountPayableExpenseReportItem As AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem,
                                              ByVal PostPeriodCode As String) As AdvantageFramework.Database.Entities.AccountPayable

            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            Try

                AccountPayable = New AdvantageFramework.Database.Entities.AccountPayable
                AccountPayable.DbContext = DbContext

                AccountPayable.Type = "V"

                AccountPayable.InvoiceDate = AccountPayableExpenseReportItem.InvoiceDate
                AccountPayable.VendorCode = AccountPayableExpenseReportItem.VendorCode
                AccountPayable.InvoiceNumber = AccountPayableExpenseReportItem.InvoiceNumber
                AccountPayable.CreatedDate = Now

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayableExpenseReportItem.VendorCode)

                If Vendor IsNot Nothing Then

                    AccountPayable.Is1099Invoice = Vendor.Vendor1099Flag.GetValueOrDefault(0)

                    AccountPayable.VendorTermCode = Vendor.VendorTermCode

                    AccountPayable.GLACode = Vendor.DefaultAPAccount

                    If Vendor.GeneralLedgerAccount IsNot Nothing AndAlso Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                        AccountPayable.OfficeCode = Vendor.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                    End If

                    If Vendor.VendorTermCode IsNot Nothing Then

                        VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(DbContext, Vendor.VendorTermCode)

                        If VendorTerm IsNot Nothing Then

                            AccountPayable.PaidDate = DateAdd(DateInterval.Day, CDbl(VendorTerm.DaysToPay), AccountPayable.InvoiceDate)

                        End If

                    End If

                End If

                AccountPayable.IsOnHold = 0

                AccountPayable.InvoiceDescription = If(AccountPayableExpenseReportItem.InvoiceDescription Is Nothing, "", AccountPayableExpenseReportItem.InvoiceDescription)

                AccountPayable.PostPeriodCode = PostPeriodCode

                AccountPayable.CreatedByUserCode = DbContext.UserCode

                AccountPayable.InvoiceAmount = AccountPayableExpenseReportItem.InvoiceTotalNet
                AccountPayable.ShippingAmount = 0
                AccountPayable.SalesTaxAmount = 0
                AccountPayable.DiscountPercentage = 0

                SetCurrencyColumnValues(DbContext, Vendor, AccountPayable)

            Catch ex As Exception
                AccountPayable = Nothing
            Finally
                CreateAccountPayable = AccountPayable
            End Try

        End Function
        Private Function WriteGLHeader(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                       ByVal VendorName As String, ByVal UserCode As String, ByVal GLSourceCode As String, ByVal BatchDate As Date) As Integer

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim Description As String = Nothing

            Description = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber & "-MODIFY"

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, UserCode, Description, GLSourceCode, BatchDate) = False Then

                Throw New Exception("Problem inserting General Ledger.")

            End If

            WriteGLHeader = GeneralLedger.Transaction

        End Function
        Public Sub ValidateAllImportJobs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ImportAccountPayableJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJob),
                                         ByRef IsValid As Boolean, ByRef ErrorString As String)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim AccountPayableProductionPurchaseOrders As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders) = Nothing
            Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing
            Dim AccountPayableAvailableProductionJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim Functions As IEnumerable = Nothing
            Dim ErrorText As String = ""
            Dim SubItemIsValid As Boolean = True

            If PropertyDescriptors Is Nothing AndAlso ImportAccountPayableJobs.Any Then

                AccountPayableProductionPurchaseOrders = AdvantageFramework.AccountPayable.GetOpenPurchaseOrders(DbContext, DbContext.UserCode)
                PurchaseOrderDetails = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadAllIncomplete(DbContext).ToList
                AccountPayableAvailableProductionJobs = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, Nothing, Nothing, Nothing, Nothing)
                JobComponents = AdvantageFramework.AccountPayable.GetOpenJobComponentsForJobs(DbContext)
                Functions = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "V")

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(ImportAccountPayableJobs.First).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each ImportAccountPayableJob In ImportAccountPayableJobs

                    ImportAccountPayableJob.DbContext = DbContext
                    ImportAccountPayableJob.PropertyDescriptors = PropertyDescriptors
                    ImportAccountPayableJob.AccountPayableProductionPurchaseOrders = AccountPayableProductionPurchaseOrders
                    ImportAccountPayableJob.PurchaseOrderDetails = PurchaseOrderDetails
                    ImportAccountPayableJob.AccountPayableAvailableProductionJobs = AccountPayableAvailableProductionJobs
                    ImportAccountPayableJob.JobComponents = JobComponents
                    ImportAccountPayableJob.Functions = Functions

                    ErrorText = ImportAccountPayableJob.CustomValidateEntity(SubItemIsValid)

                    If SubItemIsValid = False Then

                        IsValid = False

                        ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                    End If

                    ImportAccountPayableJob.PropertyDescriptors = Nothing
                    ImportAccountPayableJob.AccountPayableProductionPurchaseOrders = Nothing
                    ImportAccountPayableJob.PurchaseOrderDetails = Nothing
                    ImportAccountPayableJob.AccountPayableAvailableProductionJobs = Nothing
                    ImportAccountPayableJob.JobComponents = Nothing
                    ImportAccountPayableJob.Functions = Nothing

                Next

                AccountPayableProductionPurchaseOrders = Nothing
                PurchaseOrderDetails = Nothing
                AccountPayableAvailableProductionJobs = Nothing
                JobComponents = Nothing
                Functions = Nothing
                PropertyDescriptors = Nothing

            End If

        End Sub
        Public Sub ValidateAccountPayableExpenseReportItemList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef AccountPayableExpenseReportItemList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableExpenseReportItem),
                                                               Session As AdvantageFramework.Security.Session)

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim AccountPayableAvailableProductionJobs As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim Functions As Generic.List(Of AdvantageFramework.Database.Entities.Function) = Nothing
            Dim NonClientGLAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim ProductionGLAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim IsAPLimitByOfficeEnabled As Boolean = False
            Dim VendorGL As Dictionary(Of String, AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim IsValid As Boolean = True

            AccountPayableAvailableProductionJobs = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, Nothing, Nothing, Nothing, Nothing)
            JobComponents = AdvantageFramework.AccountPayable.GetOpenJobComponentsForJobs(DbContext)
            Functions = AdvantageFramework.Database.Procedures.Function.LoadAllActiveVendorFunctions(DbContext).ToList
            NonClientGLAccountList = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Session, Nothing, Nothing)
            ProductionGLAccountList = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, Nothing, Session)
            IsAPLimitByOfficeEnabled = AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext)

            If PropertyDescriptors Is Nothing AndAlso AccountPayableExpenseReportItemList.Any Then

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(AccountPayableExpenseReportItemList.First).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            VendorGL = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToDictionary(Function(V) V.Code, Function(V) V.GeneralLedgerAccount)

            For Each AccountPayableExpenseReportItem In AccountPayableExpenseReportItemList

                AccountPayableExpenseReportItem.DbContext = DbContext
                AccountPayableExpenseReportItem.PropertyDescriptors = PropertyDescriptors
                AccountPayableExpenseReportItem.AccountPayableAvailableProductionJobs = AccountPayableAvailableProductionJobs
                AccountPayableExpenseReportItem.JobComponents = JobComponents
                AccountPayableExpenseReportItem.Functions = Functions
                AccountPayableExpenseReportItem.NonClientGLAccountList = NonClientGLAccountList
                AccountPayableExpenseReportItem.ProductionGLAccountList = ProductionGLAccountList
                AccountPayableExpenseReportItem.IsAPLimitByOfficeEnabled = IsAPLimitByOfficeEnabled

                If VendorGL.ContainsKey(AccountPayableExpenseReportItem.VendorCode) = True AndAlso VendorGL.Item(AccountPayableExpenseReportItem.VendorCode).GeneralLedgerOfficeCrossReference IsNot Nothing Then

                    AccountPayableExpenseReportItem.APHeaderOfficeCode = VendorGL.Item(AccountPayableExpenseReportItem.VendorCode).GeneralLedgerOfficeCrossReference.OfficeCode

                End If

                AccountPayableExpenseReportItem.SetRequiredFields()

                AccountPayableExpenseReportItem.EntityError = AccountPayableExpenseReportItem.CustomValidateEntity(IsValid)

            Next

        End Sub
        Public Sub ValidateAllImportMedias(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ImportAccountPayableMedias As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableMedia),
                                           ByRef IsValid As Boolean, ByRef ErrorString As String, ByVal BatchName As String)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim AllowVendorNotOnOrder As Boolean = False
            Dim AccountPayableAvailableInternetOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders) = Nothing
            Dim AccountPayableAvailableMagazineOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders) = Nothing
            Dim AccountPayableAvailableNewspaperOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders) = Nothing
            Dim AccountPayableAvailableOutOfHomeOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders) = Nothing
            Dim AccountPayableAvailableRadioOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders) = Nothing
            Dim AccountPayableAvailableTVOrdersList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders) = Nothing
            Dim ErrorText As String = ""
            Dim SubItemIsValid As Boolean = True
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim OrderBatchName As String = Nothing

            If PropertyDescriptors Is Nothing AndAlso ImportAccountPayableMedias.Any Then

                AllowVendorNotOnOrder = AdvantageFramework.Agency.GetOptionAPAllowOrderNotMatchingVendor(DbContext)

                OrderBatchName = BatchName

                ImportAccountPayable = AdvantageFramework.Database.Procedures.ImportAccountPayable.LoadByBatchName(DbContext, BatchName).FirstOrDefault

                If ImportAccountPayable IsNot Nothing Then

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportAccountPayable.ImportTemplateID)

                    If ImportTemplate IsNot Nothing AndAlso ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                        OrderBatchName = Nothing

                    End If

                End If

                AccountPayableAvailableInternetOrdersList = AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing)
                AccountPayableAvailableMagazineOrdersList = AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing)
                AccountPayableAvailableNewspaperOrdersList = AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing)
                AccountPayableAvailableOutOfHomeOrdersList = AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing)
                AccountPayableAvailableRadioOrdersList = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing, Nothing)
                AccountPayableAvailableTVOrdersList = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, True, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, OrderBatchName, Nothing, Nothing, Nothing)

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(ImportAccountPayableMedias.First).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each ImportAccountPayableMedia In ImportAccountPayableMedias

                    ImportAccountPayableMedia.DbContext = DbContext
                    ImportAccountPayableMedia.PropertyDescriptors = PropertyDescriptors
                    ImportAccountPayableMedia.AllowVendorNotOnOrder = AllowVendorNotOnOrder
                    ImportAccountPayableMedia.AccountPayableAvailableInternetOrdersList = AccountPayableAvailableInternetOrdersList
                    ImportAccountPayableMedia.AccountPayableAvailableMagazineOrdersList = AccountPayableAvailableMagazineOrdersList
                    ImportAccountPayableMedia.AccountPayableAvailableNewspaperOrdersList = AccountPayableAvailableNewspaperOrdersList
                    ImportAccountPayableMedia.AccountPayableAvailableOutOfHomeOrdersList = AccountPayableAvailableOutOfHomeOrdersList
                    ImportAccountPayableMedia.AccountPayableAvailableRadioOrdersList = AccountPayableAvailableRadioOrdersList
                    ImportAccountPayableMedia.AccountPayableAvailableTVOrdersList = AccountPayableAvailableTVOrdersList

                    ErrorText = ImportAccountPayableMedia.CustomValidateEntity(SubItemIsValid)

                    If SubItemIsValid = False Then

                        IsValid = False

                        ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                    End If

                    ImportAccountPayableMedia.PropertyDescriptors = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableInternetOrdersList = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableMagazineOrdersList = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableNewspaperOrdersList = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableOutOfHomeOrdersList = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableRadioOrdersList = Nothing
                    ImportAccountPayableMedia.AccountPayableAvailableTVOrdersList = Nothing

                Next

                PropertyDescriptors = Nothing
                AccountPayableAvailableInternetOrdersList = Nothing
                AccountPayableAvailableMagazineOrdersList = Nothing
                AccountPayableAvailableNewspaperOrdersList = Nothing
                AccountPayableAvailableOutOfHomeOrdersList = Nothing
                AccountPayableAvailableRadioOrdersList = Nothing
                AccountPayableAvailableTVOrdersList = Nothing

            End If

        End Sub
        Public Function ReverseProduction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsDeleted As Boolean, ByVal AccountPayableProductionOld As AdvantageFramework.Database.Entities.AccountPayableProduction,
                                          ByVal GLTransaction As Integer, ByVal Remark As String, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByRef JobComponent As Collection,
                                          ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail),
                                          ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection, ByVal IsFullAPDelete As Boolean,
                                          ByVal PostPeriodCode As String, ByVal PostPeriodChanged As Boolean, ByVal GLSourceCode As String, ByVal IsWriteOff As Boolean) As Short

            'objects
            Dim GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
            Dim DuplicateAccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim Amount As Decimal = Nothing
            Dim OldAmount As Decimal = Nothing
            Dim JobComponentKey As String = Nothing
            Dim InterCompanyKey As String = Nothing
            Dim AccountPayableProductionCommentOld As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing
            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing

            If PostPeriodChanged Then

                JobComponentKey = "Reversal" & AccountPayableProductionOld.JobNumber & "|" & AccountPayableProductionOld.JobComponentNumber & "|" & AccountPayableProductionOld.GLACode

            Else

                JobComponentKey = AccountPayableProductionOld.JobNumber & "|" & AccountPayableProductionOld.JobComponentNumber & "|" & AccountPayableProductionOld.GLACode

            End If

            If JobComponent.Contains(JobComponentKey) = False Then

                Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.IsDeleted = False AndAlso
                                                                                               Entity.JobNumber = AccountPayableProductionOld.JobNumber AndAlso
                                                                                               Entity.JobComponentNumber = AccountPayableProductionOld.JobComponentNumber AndAlso
                                                                                               Entity.GLACode = AccountPayableProductionOld.GLACode).Sum(Function(Entity) Entity.Disbursed.GetValueOrDefault(0))

                Try

                    OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID) _
                                    .Where(Function(Entity) Entity.JobNumber = AccountPayableProductionOld.JobNumber AndAlso
                                                            Entity.JobComponentNumber = AccountPayableProductionOld.JobComponentNumber AndAlso
                                                            Entity.GLACode = AccountPayableProductionOld.GLACode).ToList _
                                    .Sum(Function(Entity) Entity.ExtendedAmount.GetValueOrDefault(0) + Entity.ExtendedNonResaleTax.GetValueOrDefault(0))

                Catch ex As Exception
                    OldAmount = 0
                End Try

                If IsFullAPDelete OrElse PostPeriodChanged Then

                    Amount = OldAmount * -1

                Else

                    Amount = Amount - OldAmount

                End If

                If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, AccountPayableProductionOld.GLACode,
                       Amount, Remark, GLSourceCode, AccountPayableProductionOld.Job.ClientCode, AccountPayableProductionOld.Job.DivisionCode,
                       AccountPayableProductionOld.Job.ProductCode) = False Then

                    Throw New Exception("Problem inserting General Ledger Detail.")

                End If

                JobComponent.Add(GeneralLedgerDetail.SequenceNumber, JobComponentKey)

            End If

            'debit AP_PRODUCTION
            DuplicateAccountPayableProduction = New AdvantageFramework.Database.Entities.AccountPayableProduction
            DuplicateAccountPayableProduction.DbContext = DbContext

            DuplicateAccountPayableProduction = AccountPayableProductionOld.Copy()

            DuplicateAccountPayableProduction.AccountPayableID = AccountPayable.ID
            DuplicateAccountPayableProduction.AccountPayableSequenceNumber = 0
            DuplicateAccountPayableProduction.GLTransaction = GLTransaction
            DuplicateAccountPayableProduction.GLSequenceNumber = JobComponent.Item(JobComponentKey)
            DuplicateAccountPayableProduction.Quantity = If(DuplicateAccountPayableProduction.Quantity IsNot Nothing, DuplicateAccountPayableProduction.Quantity * -1, Nothing)
            DuplicateAccountPayableProduction.ExtendedAmount = DuplicateAccountPayableProduction.ExtendedAmount * -1
            DuplicateAccountPayableProduction.ExtendedMarkupAmount = DuplicateAccountPayableProduction.ExtendedMarkupAmount * -1
            DuplicateAccountPayableProduction.ExtendedNonResaleTax = DuplicateAccountPayableProduction.ExtendedNonResaleTax * -1

            DuplicateAccountPayableProduction.LineTotal = DuplicateAccountPayableProduction.LineTotal * -1
            DuplicateAccountPayableProduction.ExtendedStateResale = DuplicateAccountPayableProduction.ExtendedStateResale * -1
            DuplicateAccountPayableProduction.ExtendedCountyResale = DuplicateAccountPayableProduction.ExtendedCountyResale * -1
            DuplicateAccountPayableProduction.ExtendedCityResale = DuplicateAccountPayableProduction.ExtendedCityResale * -1

            DuplicateAccountPayableProduction.ModifyDelete = 1
            DuplicateAccountPayableProduction.ModifiedBy = DbContext.UserCode
            DuplicateAccountPayableProduction.ModifyDate = Now
            DuplicateAccountPayableProduction.IsDeleted = Nothing
            DuplicateAccountPayableProduction.PostPeriodCode = PostPeriodCode
            DuplicateAccountPayableProduction.CreateDate = Now
            DuplicateAccountPayableProduction.CreatedBy = DbContext.UserCode

            If AccountPayableProductionOld.AccountReceivableInvoiceNumber.HasValue Then

                DuplicateAccountPayableProduction.IsBilledReversal = True

            End If

            If IsWriteOff Then

                DuplicateAccountPayableProduction.TransferAdjustmentUserCode = DbContext.UserCode
                DuplicateAccountPayableProduction.TransferAdjustmentDate = Now

            End If

            If DuplicateAccountPayableProduction.GLSequenceNumberDueFrom IsNot Nothing AndAlso DuplicateAccountPayableProduction.GLSequenceNumberDueFrom <> 0 Then

                If PostPeriodChanged Then

                    InterCompanyKey = "Reversal" & DuplicateAccountPayableProduction.OfficeCode

                Else

                    InterCompanyKey = DuplicateAccountPayableProduction.OfficeCode

                End If

                If OfficeCodeList.Contains(InterCompanyKey) = False Then

                    OfficeCodeList.Add(InterCompanyKey)

                    Amount = AccountPayableProductionDistributionDetailList.Where(Function(Entity) Entity.OfficeCode = DuplicateAccountPayableProduction.OfficeCode AndAlso Entity.IsDeleted = False).Sum(Function(Entity) Entity.Disbursed.GetValueOrDefault(0))

                    Try

                        OldAmount = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayable.ID).Where(Function(Entity) Entity.OfficeCode = DuplicateAccountPayableProduction.OfficeCode).ToList.Sum(Function(Entity) Entity.ExtendedAmount.GetValueOrDefault(0) + Entity.ExtendedNonResaleTax.GetValueOrDefault(0))

                    Catch ex As Exception
                        OldAmount = 0
                    End Try

                    If IsFullAPDelete OrElse PostPeriodChanged Then

                        If PostPeriodChanged Then

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & AccountPayable.Vendor.Name & ", Inv: " & AccountPayable.InvoiceNumber & " - POST PERIOD MODIFY [IC]"
                            Amount = OldAmount * -1

                        ElseIf IsFullAPDelete Then

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & AccountPayable.Vendor.Name & ", Inv: " & AccountPayable.InvoiceNumber & " - DELETE [IC]"
                            Amount = OldAmount * -1

                        End If

                    Else

                        Remark = "Vendor:" & AccountPayable.VendorCode & "-" & AccountPayable.Vendor.Name & ", Inv: " & AccountPayable.InvoiceNumber & " [IC]"
                        Amount = Amount - OldAmount

                    End If

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, DuplicateAccountPayableProduction.GLACodeDueFrom,
                                    Amount, Remark, GLSourceCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    DueFromSeqNo.Add(GeneralLedgerDetail.SequenceNumber, InterCompanyKey)

                    DuplicateAccountPayableProduction.GLACodeDueFrom = DuplicateAccountPayableProduction.GLACodeDueFrom
                    DuplicateAccountPayableProduction.GLSequenceNumberDueFrom = DueFromSeqNo.Item(InterCompanyKey)

                    If AdvantageFramework.GeneralLedger.InsertGeneralLedgerDetail(GeneralLedgerDetail, DbContext, GLTransaction, DuplicateAccountPayableProduction.GLACodeDueTo,
                                    Amount * -1, Remark, GLSourceCode) = False Then

                        Throw New Exception("Problem inserting General Ledger Detail.")

                    End If

                    DueToSeqNo.Add(GeneralLedgerDetail.SequenceNumber, InterCompanyKey)

                    DuplicateAccountPayableProduction.GLACodeDueTo = DuplicateAccountPayableProduction.GLACodeDueTo
                    DuplicateAccountPayableProduction.GLSequenceNumberDueTo = DueToSeqNo.Item(InterCompanyKey)

                Else

                    DuplicateAccountPayableProduction.GLACodeDueFrom = DuplicateAccountPayableProduction.GLACodeDueFrom
                    DuplicateAccountPayableProduction.GLSequenceNumberDueFrom = DueFromSeqNo.Item(InterCompanyKey)

                    DuplicateAccountPayableProduction.GLACodeDueTo = DuplicateAccountPayableProduction.GLACodeDueTo
                    DuplicateAccountPayableProduction.GLSequenceNumberDueTo = DueToSeqNo.Item(InterCompanyKey)

                End If

            End If

            If IsDeleted Then

                If DuplicateAccountPayableProduction.PONumber IsNot Nothing AndAlso DuplicateAccountPayableProduction.PODetailLineNumber IsNot Nothing Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER SET PO_COMPLETE=NULL WHERE PO_NUMBER={0}", DuplicateAccountPayableProduction.PONumber))
                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER_DET SET PO_COMPLETE=NULL WHERE PO_NUMBER={0}", DuplicateAccountPayableProduction.PONumber))

                End If

            End If

            DuplicateAccountPayableProduction.AccountReceivableInvoiceNumber = Nothing
            DuplicateAccountPayableProduction.AccountReceivableInvoiceSequenceNumber = Nothing
            DuplicateAccountPayableProduction.AccountReceivableType = Nothing
            DuplicateAccountPayableProduction.GLTransactionBill = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberSales = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberCOS = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberState = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberCounty = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberCity = Nothing
            DuplicateAccountPayableProduction.GLSequenceNumberWIP = Nothing
            DuplicateAccountPayableProduction.GLACodeSales = Nothing
            DuplicateAccountPayableProduction.GLACodeCOS = Nothing
            DuplicateAccountPayableProduction.GLACodeState = Nothing
            DuplicateAccountPayableProduction.GLACodeCounty = Nothing
            DuplicateAccountPayableProduction.GLACodeCity = Nothing

            If AdvantageFramework.Database.Procedures.AccountPayableProduction.InsertWithoutValidate(DbContext, DuplicateAccountPayableProduction) = False Then

                Throw New Exception("Problem inserting AP Production.")

            End If

            AccountPayableProductionCommentOld = AdvantageFramework.Database.Procedures.AccountPayableProductionComment.LoadByAccountPayableIDLineNumber(DbContext, AccountPayable.ID, AccountPayableProductionOld.LineNumber)

            If AccountPayableProductionCommentOld IsNot Nothing Then

                AccountPayableProductionComment = New AdvantageFramework.Database.Entities.AccountPayableProductionComment
                AccountPayableProductionComment.DbContext = DbContext
                AccountPayableProductionComment.AccountPayableID = AccountPayableProductionCommentOld.AccountPayableID
                AccountPayableProductionComment.LineNumber = DuplicateAccountPayableProduction.LineNumber
                AccountPayableProductionComment.JobNumber = AccountPayableProductionCommentOld.JobNumber
                AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionCommentOld.JobComponentNumber
                AccountPayableProductionComment.FunctionCode = AccountPayableProductionCommentOld.FunctionCode
                AccountPayableProductionComment.Comment = AccountPayableProductionCommentOld.Comment

                If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Insert(DbContext, AccountPayableProductionComment) = False Then

                    Throw New Exception("Failed to Insert AP Prod Comment.")

                End If

            End If

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_PRODUCTION SET MODIFY_DELETE=1, MODIFIED_BY='{2}', MODIFY_DATE=getdate() WHERE AP_ID={0} AND AP_SEQ=0 AND LINE_NUMBER={1}", AccountPayable.ID, AccountPayableProductionOld.LineNumber, DbContext.UserCode))

            ReverseProduction = DuplicateAccountPayableProduction.LineNumber

        End Function
        Public Function IsDateOutsidePostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ValidationDate As Date, ByVal PostPeriodCode As String) As Boolean

            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim IsDateOutsideRange As Boolean = True

            PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, PostPeriodCode)

            If PostPeriod IsNot Nothing AndAlso PostPeriod.StartDate.HasValue AndAlso PostPeriod.EndDate.HasValue Then

                If Math.Abs(DateDiff(DateInterval.Month, ValidationDate, PostPeriod.StartDate.Value)) <= 1 OrElse Math.Abs(DateDiff(DateInterval.Month, ValidationDate, PostPeriod.EndDate.Value)) <= 1 Then

                    IsDateOutsideRange = False

                End If

            End If

            IsDateOutsidePostPeriod = IsDateOutsideRange

        End Function
        Private Function IsProductionRowDirty(ByVal AccountPayableProductionOld As AdvantageFramework.Database.Entities.AccountPayableProduction,
                                              ByVal AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) As Boolean

            Dim IsDirty As Boolean = False

            If AccountPayableProductionOld.JobNumber <> AccountPayableProductionDistributionDetail.JobNumber.GetValueOrDefault(0) OrElse
                    AccountPayableProductionOld.JobComponentNumber <> AccountPayableProductionDistributionDetail.JobComponentNumber.GetValueOrDefault(0) OrElse
                    AccountPayableProductionOld.FunctionCode <> AccountPayableProductionDistributionDetail.FunctionCode OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.Quantity, AccountPayableProductionDistributionDetail.Quantity) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.Rate, AccountPayableProductionDistributionDetail.Rate) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.ExtendedAmount, AccountPayableProductionDistributionDetail.ExtendedAmount) OrElse
                    AccountPayableProductionOld.SalesTaxCode <> AccountPayableProductionDistributionDetail.SalesTaxCode OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.CommissionPercent, AccountPayableProductionDistributionDetail.CommissionPercent) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.ExtendedMarkupAmount, AccountPayableProductionDistributionDetail.ExtendedMarkupAmount) OrElse
                    AccountPayableProductionOld.OfficeCode <> AccountPayableProductionDistributionDetail.OfficeCode OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.PONumber, AccountPayableProductionDistributionDetail.PONumber) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.PODetailLineNumber, AccountPayableProductionDistributionDetail.PODetailLineNumber) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.IsPOComplete, AccountPayableProductionDistributionDetail.POComplete) OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.IsResaleTax, AccountPayableProductionDistributionDetail.IsResaleTax) OrElse
                    AccountPayableProductionOld.GLACode <> AccountPayableProductionDistributionDetail.GLACode OrElse
                    Not Nullable.Equals(AccountPayableProductionOld.ExtendedNonResaleTax, AccountPayableProductionDistributionDetail.ExtendedNonResaleTax) Then

                IsDirty = True

            End If

            IsProductionRowDirty = IsDirty

        End Function
        Public Function WriteGLHeader(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable, ByVal VendorName As String,
                                      ByVal PostPeriodChanged As Boolean, ByVal OfficeChanged As Boolean, GLSourceCode As String, ByVal BatchDate As Nullable(Of Date)) As Integer

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim Description As String = Nothing

            Description = "VN:" & AccountPayable.VendorCode & "-" & VendorName & ",Inv:" & AccountPayable.InvoiceNumber

            If PostPeriodChanged Then

                Description += "-PPMOD"

            End If

            If OfficeChanged Then

                Description += "-OFFMOD"

            End If

            If Not PostPeriodChanged AndAlso Not OfficeChanged Then

                Description += "-MODIFY"

            End If

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayable.PostPeriodCode, DbContext.UserCode, Description, GLSourceCode, BatchDate) = False Then

                Throw New Exception("Problem inserting General Ledger.")

            End If

            WriteGLHeader = GeneralLedger.Transaction

        End Function
        Public Sub SaveProduction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef GLTransaction As Integer, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                                  ByVal VendorName As String, ByVal PostPeriodChanged As Boolean, ByVal GLReversalTransaction As Integer,
                                  ByVal AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail),
                                  ByRef JobComponent As Collection, ByRef OfficeCodeList As Generic.List(Of String), ByRef DueFromSeqNo As Collection, ByRef DueToSeqNo As Collection,
                                  ByVal AgencyInvoiceTaxFlag As Boolean, ByVal GLSourceCode As String, ByVal BatchDate As Nullable(Of Date),
                                  Optional ByVal OverrideRemark As String = Nothing, Optional ByVal ReversalPostPeriodCode As String = Nothing, Optional ByVal IsWriteoff As Boolean = False)

            Dim LineNumber As Short = Nothing
            Dim Remark As String = Nothing
            Dim AccountPayableProductionOld As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim AccountPayableProductionNew As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim AccountPayableProductionComment As AdvantageFramework.Database.Entities.AccountPayableProductionComment = Nothing
            Dim POComplete As Short = 0

            For Each AccountPayableProductionDistributionDetail In AccountPayableProductionDistributionDetailList

                LineNumber = AccountPayableProductionDistributionDetail.LineNumber

                If AccountPayableProductionDistributionDetail.AccountPayableProduction.IsEntityBeingAdded() Then 'new rows added to Production

                    If OverrideRemark IsNot Nothing Then

                        Remark = OverrideRemark

                    Else

                        Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AdvantageFramework.AccountPayable.FormatInvoice(AccountPayable) & ", Job: " & AccountPayableProductionDistributionDetail.JobNumber.ToString.PadLeft(6, "0") & "-" & AccountPayableProductionDistributionDetail.JobComponentNumber.ToString.PadLeft(3, "0") & " - MODIFY [PR]"

                        AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = AccountPayable.PostPeriodCode
                        AccountPayableProductionDistributionDetail.AccountPayableProduction.IsWriteOff = 0

                    End If

                    AdvantageFramework.AccountPayable.AddProduction(DbContext, AccountPayableProductionDistributionDetail, AccountPayableProductionDistributionDetailList, AccountPayableProductionDistributionDetail.AccountPayableProduction, GLTransaction, Remark, AccountPayable, JobComponent, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, False, AgencyInvoiceTaxFlag, GLSourceCode, BatchDate, True)

                    LineNumber = AccountPayableProductionDistributionDetail.AccountPayableProduction.LineNumber

                Else

                    Try

                        AccountPayableProductionOld = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                                       Where Entity.AccountPayableID = AccountPayable.ID AndAlso
                                                             Entity.LineNumber = AccountPayableProductionDistributionDetail.LineNumber AndAlso
                                                             (Entity.ModifyDelete Is Nothing OrElse
                                                              Entity.ModifyDelete = 0)
                                                       Select Entity).SingleOrDefault

                    Catch ex As Exception
                        Throw New Exception("Error gathering AP_PRODUCTION row.")
                    End Try

                    If AccountPayableProductionDistributionDetail.IsDeleted OrElse PostPeriodChanged OrElse IsProductionRowDirty(AccountPayableProductionOld, AccountPayableProductionDistributionDetail) Then

                        If GLTransaction = -1 Then

                            GLTransaction = WriteGLHeader(DbContext, AccountPayable, VendorName, False, False, GLSourceCode, BatchDate)

                        End If

                        If OverrideRemark IsNot Nothing Then

                            Remark = OverrideRemark

                        Else

                            Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AdvantageFramework.AccountPayable.FormatInvoice(AccountPayable) & ", Job: " & AccountPayableProductionOld.JobNumber.ToString.PadLeft(6, "0") & "-" & AccountPayableProductionOld.JobComponentNumber.ToString.PadLeft(3, "0") & " - MODIFY [PR]"

                        End If

                        If Not PostPeriodChanged Then

                            LineNumber = AdvantageFramework.AccountPayable.ReverseProduction(DbContext, AccountPayableProductionDistributionDetail.IsDeleted, AccountPayableProductionOld, GLTransaction, Remark, AccountPayable, JobComponent, AccountPayableProductionDistributionDetailList, OfficeCodeList, DueFromSeqNo, DueToSeqNo, False, If(ReversalPostPeriodCode Is Nothing, AccountPayable.PostPeriodCode, ReversalPostPeriodCode), False, GLSourceCode, IsWriteoff)

                        Else

                            LineNumber = AdvantageFramework.AccountPayable.ReverseProduction(DbContext, False, AccountPayableProductionOld, GLReversalTransaction, Remark, AccountPayable, JobComponent, AccountPayableProductionDistributionDetailList, OfficeCodeList, DueFromSeqNo, DueToSeqNo, False, If(ReversalPostPeriodCode Is Nothing, AccountPayableProductionOld.PostPeriodCode, ReversalPostPeriodCode), PostPeriodChanged, GLSourceCode, IsWriteoff)

                        End If

                        If Not AccountPayableProductionDistributionDetail.IsDeleted Then

                            AccountPayableProductionNew = New AdvantageFramework.Database.Entities.AccountPayableProduction

                            AccountPayableProductionNew = AccountPayableProductionDistributionDetail.AccountPayableProduction.Copy()

                            If OverrideRemark IsNot Nothing Then

                                Remark = OverrideRemark

                            Else

                                Remark = "Vendor:" & AccountPayable.VendorCode & "-" & VendorName & ", Inv: " & AdvantageFramework.AccountPayable.FormatInvoice(AccountPayable) & ", Job: " & AccountPayableProductionDistributionDetail.JobNumber.ToString.PadLeft(6, "0") & "-" & AccountPayableProductionDistributionDetail.JobComponentNumber.ToString.PadLeft(3, "0") & " - MODIFY [PR]"

                                AccountPayableProductionNew.PostPeriodCode = AccountPayable.PostPeriodCode
                                AccountPayableProductionNew.IsWriteOff = 0

                            End If

                            AdvantageFramework.AccountPayable.AddProduction(DbContext, AccountPayableProductionDistributionDetail, AccountPayableProductionDistributionDetailList, AccountPayableProductionNew, GLTransaction, Remark, AccountPayable, JobComponent, OfficeCodeList, DueFromSeqNo, DueToSeqNo, VendorName, GLReversalTransaction <> -1, AgencyInvoiceTaxFlag, GLSourceCode, Nothing, False)

                            LineNumber = AccountPayableProductionNew.LineNumber

                        End If

                    End If

                End If

                AccountPayableProductionComment = AdvantageFramework.Database.Procedures.AccountPayableProductionComment.LoadByAccountPayableIDLineNumber(DbContext, AccountPayable.ID, LineNumber)

                If AccountPayableProductionComment Is Nothing AndAlso String.IsNullOrEmpty(AccountPayableProductionDistributionDetail.Comment) = False Then

                    AccountPayableProductionComment = New AdvantageFramework.Database.Entities.AccountPayableProductionComment
                    AccountPayableProductionComment.DbContext = DbContext
                    AccountPayableProductionComment.AccountPayableID = AccountPayable.ID
                    AccountPayableProductionComment.LineNumber = LineNumber
                    AccountPayableProductionComment.JobNumber = AccountPayableProductionDistributionDetail.JobNumber
                    AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber
                    AccountPayableProductionComment.FunctionCode = AccountPayableProductionDistributionDetail.FunctionCode
                    AccountPayableProductionComment.Comment = AccountPayableProductionDistributionDetail.Comment

                    If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Insert(DbContext, AccountPayableProductionComment) = False Then

                        Throw New Exception("Failed to Insert AP Prod Comment.")

                    End If

                Else

                    If AccountPayableProductionComment IsNot Nothing Then

                        AccountPayableProductionComment.JobNumber = AccountPayableProductionDistributionDetail.JobNumber
                        AccountPayableProductionComment.JobComponentNumber = AccountPayableProductionDistributionDetail.JobComponentNumber
                        AccountPayableProductionComment.FunctionCode = AccountPayableProductionDistributionDetail.FunctionCode
                        AccountPayableProductionComment.Comment = AccountPayableProductionDistributionDetail.Comment

                        If AdvantageFramework.Database.Procedures.AccountPayableProductionComment.Update(DbContext, AccountPayableProductionComment) = False Then

                            Throw New Exception("Failed to Update AP Prod Comment.")

                        End If

                    End If

                End If

                If AccountPayableProductionDistributionDetail.PONumber IsNot Nothing AndAlso AccountPayableProductionDistributionDetail.PODetailLineNumber IsNot Nothing Then

                    POComplete = 0

                    If (From Entity In AccountPayableProductionDistributionDetailList
                        Where Entity.PONumber = AccountPayableProductionDistributionDetail.PONumber AndAlso
                              Entity.PODetailLineNumber = AccountPayableProductionDistributionDetail.PODetailLineNumber AndAlso
                              Entity.IsDeleted = False AndAlso
                              Entity.POComplete = 1).Any Then

                        POComplete = 1

                    End If

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.UpdateIsCompleteAndParentPO(DbContext, AccountPayableProductionDistributionDetail.PONumber, AccountPayableProductionDistributionDetail.PODetailLineNumber, POComplete) = False Then

                        Throw New Exception("Failed to update purchase order.")

                    End If

                End If

            Next

        End Sub
        Public Function LoadChecksWritten(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal APID As Integer) As IEnumerable(Of Object)

            Dim ChecksWrittenList As IEnumerable(Of Object) = Nothing

            ChecksWrittenList = (From Entity In AdvantageFramework.Database.Procedures.AccountPayablePayment.Load(DbContext).Include("CheckRegister")
                                 Where Entity.AccountPayableID = APID
                                 Select Entity.CheckNumber,
                                        [DatePosted] = Entity.CheckDate,
                                        [Status] = If(Entity.CheckRegister IsNot Nothing, If(Entity.CheckRegister.IsVoid = 1, "Voided", If(Entity.CheckRegister.IsCleared = 1, "Cleared", "")), ""),
                                        Entity.BankCode,
                                        Entity.AccountPayableID).Distinct.ToList

            LoadChecksWritten = ChecksWrittenList

        End Function
        Public Function GetCurrencyRate(DbContext As AdvantageFramework.Database.DbContext, CurrencyCodeHome As String, APCurrencyCode As String) As Decimal

            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim CurrencyRate As Decimal = 1

            If CurrencyCodeHome <> APCurrencyCode Then

                Currency = AdvantageFramework.Database.Procedures.Currency.LoadByCurrencyCode(DbContext, APCurrencyCode)

                If Currency IsNot Nothing AndAlso Currency.IsInactive.GetValueOrDefault(0) = 0 Then

                    CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, APCurrencyCode, CurrencyCodeHome)

                    If CurrencyDetail IsNot Nothing Then

                        CurrencyRate = CurrencyDetail.ExchangeRate

                    End If

                End If

            End If

            GetCurrencyRate = CurrencyRate

        End Function
        Private Sub SetCurrencyColumnValues(DbContext As AdvantageFramework.Database.DbContext, Vendor As AdvantageFramework.Database.Entities.Vendor, AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            Dim CurrencyCodeHome As String = Nothing
            'Dim HomeCurrencyAmount As Decimal = Nothing

            If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                'If Not String.IsNullOrWhiteSpace(Vendor.CurrencyCode) Then

                '    AccountPayable.CurrencyCode = Vendor.CurrencyCode

                'Else

                AccountPayable.CurrencyCode = Nothing

                'End If

                AccountPayable.CurrencyRate = Nothing

                'HomeCurrencyAmount = FormatNumber((AccountPayable.InvoiceAmount + AccountPayable.SalesTaxAmount.Value) * AccountPayable.CurrencyRate.Value, 2)

                AccountPayable.ExchangeAmount = 0
                AccountPayable.DoNotApplyCurrencyRequirement = True

            End If

        End Sub
        Public Function GetVendorInvoiceDetail(Session As AdvantageFramework.Security.Session,
                                               Criteria As Short, StringValue As String, IntValue As Integer) As Generic.List(Of AdvantageFramework.Database.Classes.VendorInvoiceDetail)

            Dim SqlParameterCriteria As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStringValue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIntValue As System.Data.SqlClient.SqlParameter = Nothing
            Dim VendorInvoiceDetails As Generic.List(Of AdvantageFramework.Database.Classes.VendorInvoiceDetail) = Nothing

            SqlParameterCriteria = New System.Data.SqlClient.SqlParameter("@CRITERIA", SqlDbType.SmallInt)
            SqlParameterStringValue = New System.Data.SqlClient.SqlParameter("@STRING_VALUE", SqlDbType.VarChar)
            SqlParameterIntValue = New System.Data.SqlClient.SqlParameter("@INT_VALUE", SqlDbType.Int)

            SqlParameterCriteria.Value = Criteria
            SqlParameterStringValue.Value = StringValue
            SqlParameterIntValue.Value = IntValue

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                VendorInvoiceDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.VendorInvoiceDetail) _
                                            ("exec advsp_ap_vendor_invoice_detail @CRITERIA, @STRING_VALUE, @INT_VALUE", SqlParameterCriteria, SqlParameterStringValue, SqlParameterIntValue).ToList

            End Using

            GetVendorInvoiceDetail = (From Entity In VendorInvoiceDetails
                                      Where ((Session.HasLimitedOfficeCodes AndAlso
                                              Session.AccessibleOfficeCodes.Contains(Entity.VendorOfficeCode)) OrElse
                                            (Not Session.HasLimitedOfficeCodes))
                                      Select Entity).OrderBy(Function(Entity) Entity.VendorCode).ToList

        End Function
        Public Function IsActivateApprovals(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Return AdvantageFramework.Database.Procedures.Agency.ActivateApprovals(DbContext)

        End Function
        Public Function RequiresMediaApproval(ByVal Session As AdvantageFramework.Security.Session, ByVal Media As AdvantageFramework.AccountPayable.MediaType, ByVal TotalDisbursed As Decimal, ByVal OrderNetAmount As Decimal) As Boolean

            'objects
            Dim RequiresApproval As Boolean = False
            Dim PercentThreshold As Nullable(Of Decimal) = Nothing

            If OrderNetAmount <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If IsActivateApprovals(DbContext) Then

                        RequiresApproval = CheckRequiresApprovalByThreshold(DbContext, Media, TotalDisbursed, OrderNetAmount)

                    End If

                End Using

            End If

            RequiresMediaApproval = RequiresApproval

        End Function
        Public Function CheckRequiresApprovalByThreshold(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Media As AdvantageFramework.AccountPayable.MediaType, ByVal TotalDisbursed As Decimal, ByVal OrderNetAmount As Decimal) As Boolean

            'objects
            Dim RequiresApproval As Boolean = False
            Dim PercentThreshold As Nullable(Of Decimal) = Nothing

            If OrderNetAmount <> 0 Then

                PercentThreshold = GetPercentThresholdByMedia(DbContext, Media)

                RequiresApproval = CheckRequiesApprovalByThreshold(PercentThreshold, TotalDisbursed, OrderNetAmount)

            End If

            CheckRequiresApprovalByThreshold = RequiresApproval

        End Function
        Public Function CheckRequiesApprovalByThreshold(ByVal PercentThreshold As Decimal?, ByVal TotalDisbursed As Decimal, ByVal OrderNetAmount As Decimal) As Boolean

            'objects
            Dim RequiresApproval As Boolean = False

            If OrderNetAmount <> 0 Then

                If PercentThreshold.HasValue Then

                    If PercentThreshold = 0 AndAlso TotalDisbursed <> OrderNetAmount Then

                        RequiresApproval = True

                    ElseIf (TotalDisbursed - OrderNetAmount) / OrderNetAmount > PercentThreshold / 100 Then

                        RequiresApproval = True

                    End If

                End If

            End If

            CheckRequiesApprovalByThreshold = RequiresApproval

        End Function
        Public Function GetPercentThresholdByMedia(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Media As AdvantageFramework.AccountPayable.MediaType) As Nullable(Of Decimal)

            'objects
            Dim PercentThreshold As Nullable(Of Decimal) = Nothing

            Select Case Media

                Case AdvantageFramework.AccountPayable.MediaType.Print

                    PercentThreshold = AdvantageFramework.Database.Procedures.Agency.PrintMediaPercent(DbContext)

                Case AdvantageFramework.AccountPayable.MediaType.Internet

                    PercentThreshold = AdvantageFramework.Database.Procedures.Agency.InternetPercent(DbContext)

                Case AdvantageFramework.AccountPayable.MediaType.OutOfHome

                    PercentThreshold = AdvantageFramework.Database.Procedures.Agency.OutOfHomePercent(DbContext)

                Case AdvantageFramework.AccountPayable.MediaType.Radio

                    PercentThreshold = AdvantageFramework.Database.Procedures.Agency.RadioPercent(DbContext)

                Case AdvantageFramework.AccountPayable.MediaType.TV

                    PercentThreshold = AdvantageFramework.Database.Procedures.Agency.TelevisionPercent(DbContext)

            End Select

            GetPercentThresholdByMedia = PercentThreshold

        End Function
        Public Sub CreateBuyerAlertsForImportedInvoices(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal AccountPayableMediaImportAlerts As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMediaImportAlert),
                                                         ByRef ErrorMessage As String)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing

            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, 68) 'Media Invoice Approval Request

            For Each EmployeeAlertGroup In AccountPayableMediaImportAlerts.GroupBy(Function(alrt) alrt.EmployeeCode).ToList

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeAlertGroup.First.EmployeeCode)

                If Employee IsNot Nothing Then

                    Alert = New Database.Entities.Alert

                    Alert.AlertTypeID = AlertCategory.AlertTypeID
                    Alert.AlertCategoryID = AlertCategory.ID
                    Alert.Subject = "Media invoices are available for approval."

                    Alert.EmailBody = "For Vendors: " & String.Join(", ", EmployeeAlertGroup.GroupBy(Function(alrt) alrt.VendorCode).Select(Function(alrt) alrt.First.VendorName).ToList)

                    'For Each VendorInvoiceAlertGroup In EmployeeAlertGroup.OrderBy(Function(alrt) alrt.VendorCode).GroupBy(Function(alrt) alrt.VendorCode).ToList

                    '    Alert.EmailBody &= "<b>Vendor:</b> " & VendorInvoiceAlertGroup.First.VendorCode & " - " & VendorInvoiceAlertGroup.First.VendorName & "<br/><b>Invoice:</b> " & VendorInvoiceAlertGroup.First.InvoiceNumber & "<br/><b>Orders:</b> " & String.Join(", ", VendorInvoiceAlertGroup.Select(Function(grp) grp.OrderNumber).Distinct.ToList) & "<br/><br/>"

                    'Next

                    Alert.Body = Alert.EmailBody
                    Alert.GeneratedDate = System.DateTime.Now
                    Alert.PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.Normal
                    Alert.EmployeeCode = Employee.Code
                    Alert.AlertLevel = ""
                    Alert.UserCode = DbContext.UserCode
                    Alert.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        AdvantageFramework.AlertSystem.CreateAlertRecipient(DbContext, Employee, Alert, True)

                        AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert] ", Nothing, Nothing, "APVendorMediaInvoiceApproval", ErrorMessage)

                    End If

                End If

            Next

        End Sub

#End Region

    End Module

End Namespace
