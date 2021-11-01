Namespace IncomeOnly

    <HideModuleName()>
    Public Module Methods

        Public Event GeneratingFeeProgressUpdateEvent(ByVal ProgressValue As Integer)
        Public Event SetupGeneratingFeeProgressEvent(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)
        Public Event IncomeOnlyCreatedEvent(ByVal IncomeOnlyID As Integer)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AllowedProcessContols As Integer() = {1, 8, 9, 10, 11}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadOrders(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   Optional ByVal ClientCode As String = Nothing,
                                   Optional ByVal DivisionCode As String = Nothing,
                                   Optional ByVal ProductCode As String = Nothing,
                                   Optional ByVal JobNumber As Integer = 0,
                                   Optional ByVal ComponentNumber As Short = 0) As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order)

            'objects
            Dim Orders As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order) = Nothing
            Dim ClientCodeString As String = "NULL"
            Dim DivisionCodeString As String = "NULL"
            Dim ProductCodeString As String = "NULL"
            Dim JobNumberString As String = "NULL"
            Dim ComponentNumberString As String = "NULL"

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                ClientCodeString = "'" & ClientCode & "'"

            End If

            If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                DivisionCodeString = "'" & DivisionCode & "'"

            End If

            If String.IsNullOrWhiteSpace(ProductCode) = False Then

                ProductCodeString = "'" & ProductCode & "'"

            End If

            If JobNumber <> 0 Then

                JobNumberString = CStr(JobNumber)

            End If

            If ComponentNumber <> 0 Then

                ComponentNumberString = CStr(ComponentNumber)

            End If

            Try

                Orders = DbContext.Database.SqlQuery(Of AdvantageFramework.IncomeOnly.Classes.Order)(String.Format("EXEC [dbo].[advsp_income_only_load_orders] {0}, {1}, {2}, {3}, {4}", ClientCodeString, DivisionCodeString, ProductCodeString, JobNumberString, ComponentNumberString)).ToList

            Catch ex As Exception
                Orders = Nothing
            End Try

            If Orders Is Nothing Then

                Orders = New Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order)

            End If

            LoadOrders = Orders

        End Function
        Public Function LoadContracts(ByVal DbContext As AdvantageFramework.Database.DbContext, Optional ByVal ServiceFeeContractID As Integer = 0,
                                      Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                      Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber As Integer = 0,
                                      Optional ByVal JobComponentNumber As Integer = 0) As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract)

            Try

                LoadContracts = (From Entity In AdvantageFramework.Database.Procedures.ServiceFeeContractComplex.Load(DbContext, DbContext.UserCode, ServiceFeeContractID, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber)
                                 Select New AdvantageFramework.IncomeOnly.Classes.JobComponentServiceFeeContract(Entity)).ToList

            Catch ex As Exception
                LoadContracts = Nothing
            End Try

        End Function
        Public Function DeleteContract(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContractID As Integer) As Boolean

            DeleteContract = False

        End Function
        Public Function Search(ByVal DbContext As AdvantageFramework.Database.DbContext, Optional ByVal ClientCode As String = Nothing,
                               Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                               Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNumber As Integer = 0,
                               Optional ByVal ShowDeleted As Boolean = False, Optional ByVal IDs As Integer() = Nothing) As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            'objects
            Dim IDString As String = Nothing
            Dim SQLString As String = Nothing
            Dim ClientCodeSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DivisionCodeSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProductCodeSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumberSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobCompNumberSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowDeletedSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IDListSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserIDSQLParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SQLParameters() As System.Data.SqlClient.SqlParameter = Nothing

            Try

                If IDs IsNot Nothing AndAlso IDs.Count > 0 Then

                    IDString = String.Join(",", IDs)

                End If

                UserIDSQLParameter = New System.Data.SqlClient.SqlParameter("USER_ID", System.Data.SqlDbType.VarChar) With {.Value = DbContext.UserCode}
                ClientCodeSQLParameter = New System.Data.SqlClient.SqlParameter("CL_CODE", System.Data.SqlDbType.VarChar) With {.Value = System.DBNull.Value}
                DivisionCodeSQLParameter = New System.Data.SqlClient.SqlParameter("DIV_CODE", System.Data.SqlDbType.VarChar) With {.Value = System.DBNull.Value}
                ProductCodeSQLParameter = New System.Data.SqlClient.SqlParameter("PRD_CODE", System.Data.SqlDbType.VarChar) With {.Value = System.DBNull.Value}
                JobNumberSQLParameter = New System.Data.SqlClient.SqlParameter("JOB_NUMBER", System.Data.SqlDbType.Int) With {.Value = JobNumber}
                JobCompNumberSQLParameter = New System.Data.SqlClient.SqlParameter("JOB_COMP_NBR", System.Data.SqlDbType.SmallInt) With {.Value = JobComponentNumber}
                ShowDeletedSQLParameter = New System.Data.SqlClient.SqlParameter("SHOW_DELETED", System.Data.SqlDbType.Bit) With {.Value = ShowDeleted}
                IDListSQLParameter = New System.Data.SqlClient.SqlParameter("ID_LIST", System.Data.SqlDbType.VarChar) With {.Value = System.DBNull.Value}

                If String.IsNullOrWhiteSpace(ClientCode) = False Then

                    ClientCodeSQLParameter.Value = ClientCode

                End If

                If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                    DivisionCodeSQLParameter.Value = DivisionCode

                End If

                If String.IsNullOrWhiteSpace(ProductCode) = False Then

                    ProductCodeSQLParameter.Value = ProductCode

                End If

                If String.IsNullOrWhiteSpace(IDString) = False Then

                    IDListSQLParameter.Value = IDString

                End If

                SQLParameters = {ClientCodeSQLParameter, DivisionCodeSQLParameter, ProductCodeSQLParameter, JobNumberSQLParameter,
                                 JobCompNumberSQLParameter, ShowDeletedSQLParameter, IDListSQLParameter, UserIDSQLParameter}

                Search = DbContext.Database.SqlQuery(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)("EXEC [dbo].[advsp_income_only_load] @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @JOB_COMP_NBR, @SHOW_DELETED, @ID_LIST, @USER_ID", SQLParameters)

            Catch ex As Exception
                Search = Nothing
            End Try

        End Function
        Public Sub LoadBillingRate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ApplyTaxUponBilling As Boolean,
                                   ByVal FunctionCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                   ByVal JobNumber As Integer?, ByVal JobComponentNumber As Integer?, ByVal SalesClassCode As String, ByVal InvoiceDate As Date,
                                   ByRef Rate As Decimal?, ByRef CommissionPercent As Decimal?, ByRef TaxCommission As Short?, ByRef TaxCommissionOnly As Short?,
                                   ByRef TaxCode As String, ByRef NonBillable As Short?)

            'objects
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim JobNbr As String = Nothing
            Dim JobCompNbr As String = Nothing

            If JobNumber IsNot Nothing AndAlso JobNumber.GetValueOrDefault(0) > 0 Then

                JobNbr = CStr(JobNumber)

            End If

            If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber.GetValueOrDefault(0) > 0 Then

                JobCompNbr = CStr(JobComponentNumber)

            End If

            BillingRate = AdvantageFramework.PurchaseOrders.LoadBillingRate(DbContext, FunctionCode, ClientCode, DivisionCode, ProductCode, JobNbr, JobCompNbr, SalesClassCode, Nothing, InvoiceDate)

            If BillingRate IsNot Nothing Then

                Rate = BillingRate.BILLING_RATE
                NonBillable = BillingRate.NOBILL_FLAG
                CommissionPercent = BillingRate.COMM

                If ApplyTaxUponBilling = False Then

                    TaxCode = BillingRate.TAX_CODE
                    TaxCommission = BillingRate.TAX_COMM
                    TaxCommissionOnly = BillingRate.TAX_COMM_ONLY

                Else

                    TaxCode = Nothing
                    TaxCommission = 0
                    TaxCommissionOnly = 0

                End If

            End If

        End Sub
        Public Sub LoadSalesTax(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ApplyTaxUponBilling As Boolean, ByVal TaxCode As String, ByRef TaxResale As Short?, ByRef TaxCityPercent As Decimal?, ByRef TaxCountyPercent As Decimal?, ByRef TaxStatePercent As Decimal?)

            'objects
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If ApplyTaxUponBilling = False Then

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, TaxCode)

            End If

            If SalesTax IsNot Nothing Then

                TaxResale = SalesTax.Resale
                TaxCityPercent = SalesTax.CityPercent
                TaxCountyPercent = SalesTax.CountyPercent
                TaxStatePercent = SalesTax.StatePercent

            Else

                TaxResale = 0
                TaxCityPercent = 0
                TaxCountyPercent = 0
                TaxStatePercent = 0

            End If

        End Sub
        Public Function CreateFromServiceFee(ByVal Session As AdvantageFramework.Security.Session, ByVal JobServiceFeeID As Integer, ByVal InvoiceDates As Date(), Optional ByRef NumberCreated As Integer = 0) As Boolean

            'objects
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim ExistingFees As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly) = Nothing
            Dim ItemPrefix As String = ""
            Dim ReferenceNumber As String = ""
            Dim ApplyTaxUponBilling As Boolean = False
            Dim DepartmentTeamCode As String = Nothing
            Dim Created As Boolean = False
            Dim AdvanceBillFlag As Short? = Nothing
            Dim Counter As Integer = 0

            Try

                InvoiceDates = InvoiceDates.Select(Function(InvDate) InvDate.Date).ToArray

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, JobServiceFeeID)

                    If JobServiceFee IsNot Nothing Then

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobServiceFee.JobNumber)

                        DepartmentTeamCode = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, JobServiceFee.FunctionCode).DepartmentTeamCode

                        AdvanceBillFlag = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber).IsAdvanceBilling.GetValueOrDefault(0)

                        ApplyTaxUponBilling = LoadApplyTaxUponBilling(DbContext)

                        ItemPrefix = String.Format("{0}-{1}-", AdvantageFramework.StringUtilities.PadWithCharacter(JobServiceFee.JobNumber.ToString, 6, "0", True),
                                                               AdvantageFramework.StringUtilities.PadWithCharacter(JobServiceFee.JobComponentNumber.ToString, 3, "0", True))

                        ExistingFees = (From Entity In Search(DbContext, Job.ClientCode, Job.DivisionCode, Job.ProductCode, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber, False, Nothing)
                                        Where Entity.JobServiceFeeID = JobServiceFeeID
                                        Select Entity).ToList

                        RaiseEvent SetupGeneratingFeeProgressEvent(0, InvoiceDates.Count, 0)

                        For Each InvoiceDate In InvoiceDates

                            If (From Entity In ExistingFees
                                Where Entity.InvoiceDate = InvoiceDate
                                Select Entity).Any = False Then

                                ReferenceNumber = String.Format("{0}{1}", ItemPrefix, InvoiceDate.ToString("yyyyMMdd"))

                                IncomeOnly = New AdvantageFramework.Database.Entities.IncomeOnly

                                IncomeOnly.ReferenceNumber = ReferenceNumber
                                IncomeOnly.JobNumber = JobServiceFee.JobNumber
                                IncomeOnly.JobComponentNumber = JobServiceFee.JobComponentNumber
                                IncomeOnly.FunctionCode = JobServiceFee.FunctionCode
                                IncomeOnly.InvoiceDate = InvoiceDate
                                IncomeOnly.Amount = JobServiceFee.FeeAmount
                                IncomeOnly.Quantity = JobServiceFee.Quantity
                                IncomeOnly.Rate = JobServiceFee.Rate
                                IncomeOnly.Description = JobServiceFee.Description
                                IncomeOnly.CommissionPercent = 0
                                IncomeOnly.TaxCode = Nothing
                                IncomeOnly.BillHoldFlag = Nothing
                                IncomeOnly.ARInvoiceNumber = Nothing
                                IncomeOnly.ARInvoiceSequence = Nothing
                                IncomeOnly.ARType = Nothing
                                IncomeOnly.BillingUser = Nothing
                                IncomeOnly.TaxStatePercent = 0
                                IncomeOnly.TaxCountyPercent = 0
                                IncomeOnly.TaxCityPercent = 0
                                IncomeOnly.TaxCommission = 0
                                IncomeOnly.TaxCommissionOnly = 0
                                IncomeOnly.TaxResale = 0
                                IncomeOnly.AdjusterComments = Nothing
                                IncomeOnly.GeneralLedgerBilling = Nothing
                                IncomeOnly.GeneralLedgerSales = Nothing
                                IncomeOnly.GeneralLedgerState = Nothing
                                IncomeOnly.GeneralLedgerCounty = Nothing
                                IncomeOnly.GeneralLedgerCity = Nothing
                                IncomeOnly.GeneralLedgerAccountSales = Nothing
                                IncomeOnly.GeneralLedgerAccountState = Nothing
                                IncomeOnly.GeneralLedgerAccountCounty = Nothing
                                IncomeOnly.GeneralLedgerAccountCity = Nothing
                                IncomeOnly.AdvanceBillFlag = AdvanceBillFlag
                                IncomeOnly.DepartmentTeamCode = DepartmentTeamCode
                                IncomeOnly.ExtendedMarkupAmount = 0
                                IncomeOnly.ExtendedStateResale = 0
                                IncomeOnly.ExtendedCountyResale = 0
                                IncomeOnly.ExtendedCityResale = 0
                                IncomeOnly.Quantity = JobServiceFee.Quantity
                                IncomeOnly.Rate = JobServiceFee.Rate
                                IncomeOnly.LineTotal = JobServiceFee.FeeAmount
                                IncomeOnly.NonBillable = 0
                                IncomeOnly.IsModified = Nothing
                                IncomeOnly.ModifiedBy = DbContext.UserCode
                                IncomeOnly.ModifiedDate = System.DateTime.Today
                                IncomeOnly.DeleteFlag = Nothing
                                IncomeOnly.DeletedBy = Nothing
                                IncomeOnly.DeletedDate = Nothing
                                IncomeOnly.PostPeriod = Nothing
                                IncomeOnly.AdvanceBillID = Nothing
                                IncomeOnly.Comment = JobServiceFee.ClientComment
                                IncomeOnly.CampaignUpdatedInvoiceDate = Nothing
                                IncomeOnly.CampaignUpdatedPostPeriod = Nothing
                                IncomeOnly.TransferFromJob = Nothing
                                IncomeOnly.TransferFromJobComponent = Nothing
                                IncomeOnly.TransferFromFunction = Nothing
                                IncomeOnly.TransferFromIncomeOnlyID = Nothing
                                IncomeOnly.TransferFromSequenceNumber = Nothing
                                IncomeOnly.TransferAdjustedUser = Nothing
                                IncomeOnly.TransferAdjustedDate = Nothing
                                IncomeOnly.FeeInvoice = 1
                                IncomeOnly.IsArchived = Nothing
                                IncomeOnly.BillingApprovalID = Nothing
                                IncomeOnly.BillingCommandCenterID = Nothing
                                IncomeOnly.JobServiceFeeID = JobServiceFee.ID

                                LoadBillingRate(DbContext, ApplyTaxUponBilling, JobServiceFee.FunctionCode, Job.ClientCode, Job.DivisionCode, Job.ProductCode, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber,
                                                Job.SalesClassCode, IncomeOnly.InvoiceDate, 0, IncomeOnly.CommissionPercent, IncomeOnly.TaxCommission, IncomeOnly.TaxCommissionOnly, IncomeOnly.TaxCode, IncomeOnly.NonBillable)

                                LoadSalesTax(DbContext, ApplyTaxUponBilling, IncomeOnly.TaxCode, IncomeOnly.TaxResale, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent)

                                CalculateCommission(IncomeOnly.Amount, IncomeOnly.CommissionPercent, IncomeOnly.ExtendedMarkupAmount, True)
                                CalculateTaxes(ApplyTaxUponBilling, IncomeOnly.Amount, IncomeOnly.ExtendedMarkupAmount, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent,
                                               CBool(IncomeOnly.TaxCommission.GetValueOrDefault(0)), CBool(IncomeOnly.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnly.ExtendedCityResale, IncomeOnly.ExtendedCountyResale, IncomeOnly.ExtendedStateResale)

                                IncomeOnly.LineTotal = Math.Round(IncomeOnly.Amount.GetValueOrDefault(0) +
                                                                  IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0) +
                                                                  IncomeOnly.ExtendedCityResale.GetValueOrDefault(0) +
                                                                  IncomeOnly.ExtendedCountyResale.GetValueOrDefault(0) +
                                                                  IncomeOnly.ExtendedStateResale.GetValueOrDefault(0),
                                                                  2, MidpointRounding.AwayFromZero)

                                Try

                                    IncomeOnly.ID = (From Entity In AdvantageFramework.Database.Procedures.IncomeOnly.Load(DbContext)
                                                     Select Entity.ID).Max + 1

                                Catch ex As Exception
                                    IncomeOnly.ID = 1
                                End Try

                                IncomeOnly.SequenceNumber = 0

                                DbContext.IncomeOnlys.Add(IncomeOnly)

                                Try

                                    DbContext.SaveChanges()

                                    NumberCreated = NumberCreated + 1

                                    RaiseEvent IncomeOnlyCreatedEvent(IncomeOnly.ID)

                                Catch ex As Exception

                                End Try

                                AdvantageFramework.Database.Procedures.AssignNumber.SetNextNumber(DbContext, "IO_ID", IncomeOnly.ID)

                            End If

                            Counter = Counter + 1

                            RaiseEvent GeneratingFeeProgressUpdateEvent(Counter)

                        Next

                        Created = True

                    End If

                End Using

            Catch ex As Exception
                Created = False
            Finally
                CreateFromServiceFee = Created
            End Try

        End Function
        Public Function LoadApplyTaxUponBilling(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadApplyTaxUponBilling = LoadApplyTaxUponBilling(DbContext)

            End Using

        End Function
        Public Function LoadApplyTaxUponBilling(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            ' determines whether to calculate now or when billing is done
            LoadApplyTaxUponBilling = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).InvoiceTaxFlag

        End Function
        Public Sub CalculateTaxes(ByVal ApplyTaxUponBilling As Boolean, ByVal Amount As Decimal?, ByVal MarkupAmount As Decimal?, ByVal CityTaxPercent As Decimal?, ByVal CountyTaxPercent As Decimal?, ByVal StateTaxPercent As Decimal?,
                                     ByVal TaxCommission As Boolean?, ByVal TaxCommissionOnly As Boolean?, ByRef CityTaxAmount As Decimal?, ByRef CountyTaxAmount As Decimal?, ByRef StateTaxAmount As Decimal?)

            'objects
            Dim TaxableAmount As Decimal = Nothing

            If ApplyTaxUponBilling = False Then

                If TaxCommission.GetValueOrDefault(False) Then

                    If TaxCommissionOnly.GetValueOrDefault(False) Then

                        TaxableAmount = MarkupAmount.GetValueOrDefault(0)

                    Else

                        TaxableAmount = Amount.GetValueOrDefault(0) + MarkupAmount.GetValueOrDefault(0)

                    End If

                Else

                    TaxableAmount = Amount.GetValueOrDefault(0)

                End If

                CityTaxAmount = Math.Round(TaxableAmount * (CityTaxPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)
                CountyTaxAmount = Math.Round(TaxableAmount * (CountyTaxPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)
                StateTaxAmount = Math.Round(TaxableAmount * (StateTaxPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

            Else

                CityTaxAmount = 0
                CountyTaxAmount = 0
                StateTaxAmount = 0

            End If

        End Sub
        Public Sub CalculateCommission(ByVal Amount As Decimal?, ByRef CommissionPercent As Decimal?, ByRef MarkupAmount As Decimal?, ByVal PercentChanged As Boolean)

            'objects
            Dim Calculate As Boolean = True

            If Amount.GetValueOrDefault(0) <> 0 Then

                If CommissionPercent.GetValueOrDefault(0) <> 0 AndAlso MarkupAmount.GetValueOrDefault(0) <> 0 Then

                    If Math.Round((MarkupAmount.GetValueOrDefault(0) / Amount.GetValueOrDefault(0)) * 100, 3, MidpointRounding.AwayFromZero) = Math.Round(CommissionPercent.GetValueOrDefault(0), 3, MidpointRounding.AwayFromZero) Then

                        Calculate = False

                    End If

                End If

                If Calculate Then

                    If PercentChanged Then

                        MarkupAmount = Math.Round(Amount.GetValueOrDefault(0) * (CommissionPercent.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

                    Else

                        CommissionPercent = Math.Round((MarkupAmount.GetValueOrDefault(0) / Amount.GetValueOrDefault(0)) * 100, 3, MidpointRounding.AwayFromZero)

                    End If

                End If

            Else

                If PercentChanged Then

                    MarkupAmount = 0

                Else

                    CommissionPercent = 0

                End If

            End If

        End Sub
        Public Function LoadJobComponentList(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String, Optional ByVal ComponentsWithRecordsOnly As Boolean = False) As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)

            Try

                LoadJobComponentList = DbContext.Database.SqlQuery(Of AdvantageFramework.IncomeOnly.Classes.JobComponent)(String.Format("EXEC [dbo].[advsp_income_only_load_job_comp_select_list] '{0}', {1}", UserCode, If(ComponentsWithRecordsOnly, 1, 0))).ToList

            Catch ex As Exception
                LoadJobComponentList = Nothing
            End Try

        End Function
        Public Function LoadAvailableJobs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal UserCode As String, Optional ByVal ClientCode As String = Nothing,
                                          Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                                          Optional ByVal JobNumber As Integer = Nothing) As IEnumerable(Of AdvantageFramework.Database.Views.JobView)

            LoadAvailableJobs = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, False, _AllowedProcessContols)
                                 Select [JobNbr] = Entity.JobNumber,
                                        Entity.JobDescription,
                                        [OfficeCode] = Entity.OfficeCode,
                                        [OfficeName] = Entity.OfficeName,
                                        [ClCode] = Entity.ClientCode,
                                        [ClName] = Entity.ClientName,
                                        [DivCode] = Entity.DivisionCode,
                                        [DivName] = Entity.DivisionName,
                                        [PrdCode] = Entity.ProductCode,
                                        [PrdName] = Entity.ProductDescription).Distinct.Select(Function(JobView) New AdvantageFramework.Database.Views.JobView With {.JobNumber = JobView.JobNbr,
                                                                                                                                                                     .JobDescription = JobView.JobDescription,
                                                                                                                                                                     .OfficeCode = JobView.OfficeCode,
                                                                                                                                                                     .OfficeName = JobView.OfficeName,
                                                                                                                                                                     .ClientCode = JobView.ClCode,
                                                                                                                                                                     .ClientName = JobView.ClName,
                                                                                                                                                                     .DivisionCode = JobView.DivCode,
                                                                                                                                                                     .DivisionName = JobView.DivName,
                                                                                                                                                                     .ProductCode = JobView.PrdCode,
                                                                                                                                                                     .ProductDescription = JobView.PrdName,
                                                                                                                                                                     .IsOpen = 1}) 'always open based on _AllowedProcessControlFilter

        End Function
        Public Function LoadAvailableComponents(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal UserCode As String, Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                                                Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber As Integer? = Nothing) As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)

            Try

                LoadAvailableComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, UserCode, ClientCode, DivisionCode, ProductCode, JobNumber.GetValueOrDefault(0), False, _AllowedProcessContols)

            Catch ex As Exception
                LoadAvailableComponents = Nothing
            End Try

        End Function
        Public Function LoadBatchReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [From] As Date, ByVal [To] As Date, ByVal UserCode As String) As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnlyBatchReport)

            Try

                [From] = [From].Date
                [To] = [To].Date.AddDays(1).AddSeconds(-1)

				LoadBatchReport = DbContext.Database.SqlQuery(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnlyBatchReport)(String.Format("EXEC [dbo].[advsp_income_only_batch_report] '{0}', '{1}', '{2}'", UserCode, [From].ToString("MM/dd/yyyy"), [To].ToString("MM/dd/yyyy"))).ToList

			Catch ex As Exception
                LoadBatchReport = Nothing
            End Try

        End Function
        Public Function LoadServiceFeeContractFees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ServiceFeeContractID As Integer, ByVal GenerateMissing As Boolean) As IEnumerable(Of AdvantageFramework.Database.Classes.ServiceFee)

            'objects
            Dim SQLString As String = Nothing

            SQLString = String.Format("EXEC [dbo].[advsp_job_service_fee_contract_items_load] {0}, {1}", ServiceFeeContractID, If(GenerateMissing, 1, 0))

            LoadServiceFeeContractFees = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ServiceFee)(SQLString).ToList

        End Function
        Public Function CopyIncomeOnlys(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String,
                                        ByVal CopyToJobNumber As Integer, ByVal CopyToJobComponentNumber As Short,
                                        Optional ByVal CopyFromClientCode As String = Nothing, Optional ByVal CopyFromDivisionCode As String = Nothing,
                                        Optional ByVal CopyFromProductCode As String = Nothing, Optional ByVal CopyFromJobNumber As Integer? = Nothing,
                                        Optional ByVal CopyFromJobComponentNumber As Integer? = Nothing, Optional ByVal CopyFromIncomeOnlyIDs As Integer() = Nothing,
                                        Optional ByVal IncludeMediaOrderInfo As Boolean = False) As Integer()

            'objects
            Dim CopiedIDs As Integer() = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyFromIncomeOnlyIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyToJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCopyToJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeMediaOrderInfo As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
                SqlParameterCopyFromClientCode = New System.Data.SqlClient.SqlParameter("@COPY_FROM_CL_CODE", SqlDbType.VarChar)
                SqlParameterCopyFromDivisionCode = New System.Data.SqlClient.SqlParameter("@COPY_FROM_DIV_CODE", SqlDbType.VarChar)
                SqlParameterCopyFromProductCode = New System.Data.SqlClient.SqlParameter("@COPY_FROM_PRD_CODE", SqlDbType.VarChar)
                SqlParameterCopyFromJobNumber = New System.Data.SqlClient.SqlParameter("@COPY_FROM_JOB_NUMBER", SqlDbType.Int)
                SqlParameterCopyFromJobComponentNumber = New System.Data.SqlClient.SqlParameter("@COPY_FROM_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                SqlParameterCopyFromIncomeOnlyIDs = New System.Data.SqlClient.SqlParameter("@COPY_FROM_IO_IDS", SqlDbType.VarChar)
                SqlParameterCopyToJobNumber = New System.Data.SqlClient.SqlParameter("@COPY_TO_JOB_NUMBER", SqlDbType.Int)
                SqlParameterCopyToJobComponentNumber = New System.Data.SqlClient.SqlParameter("@COPY_TO_JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                SqlParameterIncludeMediaOrderInfo = New System.Data.SqlClient.SqlParameter("@INCLUDE_MEDIA_ORDER_INFO", SqlDbType.Bit)

                SqlParameterUserCode.Value = UserCode
                SqlParameterCopyToJobNumber.Value = CopyToJobNumber
                SqlParameterCopyToJobComponentNumber.Value = CopyToJobComponentNumber
                SqlParameterIncludeMediaOrderInfo.Value = If(IncludeMediaOrderInfo, 1, 0)

                If String.IsNullOrWhiteSpace(CopyFromClientCode) = False Then

                    SqlParameterCopyFromClientCode.Value = CopyFromClientCode

                Else

                    SqlParameterCopyFromClientCode.Value = System.DBNull.Value

                End If

                If String.IsNullOrWhiteSpace(CopyFromDivisionCode) = False Then

                    SqlParameterCopyFromDivisionCode.Value = CopyFromDivisionCode

                Else

                    SqlParameterCopyFromDivisionCode.Value = System.DBNull.Value

                End If

                If String.IsNullOrWhiteSpace(CopyFromProductCode) = False Then

                    SqlParameterCopyFromProductCode.Value = CopyFromProductCode

                Else

                    SqlParameterCopyFromProductCode.Value = System.DBNull.Value

                End If

                If CopyFromJobNumber.GetValueOrDefault(0) > 0 Then

                    SqlParameterCopyFromJobNumber.Value = CopyFromJobNumber

                Else

                    SqlParameterCopyFromJobNumber.Value = System.DBNull.Value

                End If

                If CopyFromJobComponentNumber.GetValueOrDefault(0) > 0 Then

                    SqlParameterCopyFromJobComponentNumber.Value = CopyFromJobComponentNumber

                Else

                    SqlParameterCopyFromJobComponentNumber.Value = System.DBNull.Value

                End If

                If CopyFromIncomeOnlyIDs IsNot Nothing AndAlso CopyFromIncomeOnlyIDs.Count > 0 Then

                    SqlParameterCopyFromIncomeOnlyIDs.Value = String.Join(",", CopyFromIncomeOnlyIDs)

                Else

                    SqlParameterCopyFromIncomeOnlyIDs.Value = System.DBNull.Value

                End If

                CopiedIDs = DbContext.Database.SqlQuery(Of Integer)("EXEC dbo.advsp_income_only_copy @COPY_FROM_CL_CODE, @COPY_FROM_DIV_CODE, @COPY_FROM_PRD_CODE, @COPY_FROM_JOB_NUMBER, @COPY_FROM_JOB_COMPONENT_NBR, @COPY_FROM_IO_IDS, @COPY_TO_JOB_NUMBER, @COPY_TO_JOB_COMPONENT_NBR, @USER_ID, @INCLUDE_MEDIA_ORDER_INFO",
                    SqlParameterUserCode, SqlParameterCopyFromClientCode, SqlParameterCopyFromDivisionCode, SqlParameterCopyFromProductCode, SqlParameterCopyFromJobNumber,
                    SqlParameterCopyFromJobComponentNumber, SqlParameterCopyFromIncomeOnlyIDs, SqlParameterCopyToJobNumber, SqlParameterCopyToJobComponentNumber, SqlParameterIncludeMediaOrderInfo).ToArray

            Catch ex As Exception
                CopiedIDs = Nothing
            Finally
                CopyIncomeOnlys = CopiedIDs
            End Try

        End Function

#End Region

    End Module

End Namespace