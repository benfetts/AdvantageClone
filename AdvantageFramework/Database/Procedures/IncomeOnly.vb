Namespace Database.Procedures.IncomeOnly

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ReverseAction
            Modify
            Delete
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.IncomeOnly)

            Load = From IncomeOnly In DbContext.GetQuery(Of Database.Entities.IncomeOnly)
                   Select IncomeOnly

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.IncomeOnly)

            LoadByID = From IncomeOnly In DbContext.GetQuery(Of Database.Entities.IncomeOnly)
                       Where IncomeOnly.ID = ID
                       Select IncomeOnly

        End Function
        Public Function LoadByIDAndSequenceNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer, ByVal SequenceNumber As Integer) As AdvantageFramework.Database.Entities.IncomeOnly

            LoadByIDAndSequenceNumber = (From IncomeOnly In DbContext.GetQuery(Of Database.Entities.IncomeOnly)
                                         Where IncomeOnly.ID = ID AndAlso
                                               IncomeOnly.SequenceNumber = SequenceNumber
                                         Select IncomeOnly).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UpdateAssignNumberTable As Boolean = False

            Try

                Try

                    IncomeOnly.AdvanceBillFlag = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, IncomeOnly.JobNumber, IncomeOnly.JobComponentNumber).IsAdvanceBilling.GetValueOrDefault(0)

                Catch ex As Exception
                    IncomeOnly.AdvanceBillFlag = 0
                End Try
                
                If IncomeOnly.InvoiceDate.HasValue Then

                    IncomeOnly.InvoiceDate = IncomeOnly.InvoiceDate.Value.Date

                End If

                IncomeOnly.DbContext = DbContext

                DbContext.IncomeOnlys.Add(IncomeOnly)

                ErrorText = IncomeOnly.ValidateEntity(IsValid)

                If IsValid Then

                    If IncomeOnly.ID = Nothing OrElse IncomeOnly.ID = 0 Then

                        UpdateAssignNumberTable = True

                        Try

                            IncomeOnly.ID = (From Entity In Load(DbContext) _
                                             Select Entity.ID).Max + 1

                        Catch ex As Exception
                            IncomeOnly.ID = 1
                        End Try

                    End If

                    Try

                        IncomeOnly.SequenceNumber = (From Entity In Load(DbContext) _
                                                     Where Entity.ID = IncomeOnly.ID _
                                                     Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        IncomeOnly.SequenceNumber = 0
                    End Try

                    DbContext.SaveChanges()

                    If UpdateAssignNumberTable Then

                        AdvantageFramework.Database.Procedures.AssignNumber.SetNextNumber(DbContext, "IO_ID", IncomeOnly.ID)

                    End If

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IncomeOnly.InvoiceDate.HasValue Then

                    IncomeOnly.InvoiceDate = IncomeOnly.InvoiceDate.Value.Date

                End If

                DbContext.UpdateObject(IncomeOnly)

                ErrorText = IncomeOnly.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If String.IsNullOrWhiteSpace(IncomeOnly.BillingUser) = False Then

                    ErrorText = "Income only has been selected for billing & cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    Deleted = Reverse(DbContext, IncomeOnly, ReverseAction.Delete)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Reverse(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                                ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly, _
                                ByVal ReverseAction As AdvantageFramework.Database.Procedures.IncomeOnly.ReverseAction, _
                                Optional ByVal IncomeOnlyReversalOverride As AdvantageFramework.Database.Entities.IncomeOnly = Nothing) As Boolean

            'objects
            Dim Reversed As Boolean = False
            Dim HasBilledRecord As Boolean = False
            Dim ContinueReversal As Boolean = True
            Dim ReverseIncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim BilledIncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing

            Try

                If ReverseAction = Methods.ReverseAction.Delete Then

                    If IncomeOnly.ARInvoiceNumber.HasValue OrElse (From Entity In LoadByID(DbContext, IncomeOnly.ID) _
                                                                   Where Entity.ARInvoiceNumber IsNot Nothing _
                                                                   Select Entity).Any Then

                        HasBilledRecord = True

                    End If

                    If HasBilledRecord = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[INCOME_ONLY] WHERE [IO_ID] = {0}", IncomeOnly.ID))

                        ContinueReversal = False

                        Reversed = True

                    ElseIf IncomeOnly.Amount = 0 Then

                        ContinueReversal = False

                    End If

                End If

                If ContinueReversal Then

                    ReverseIncomeOnly = New AdvantageFramework.Database.Entities.IncomeOnly

                    ReverseIncomeOnly.ID = IncomeOnly.ID
                    ReverseIncomeOnly.SequenceNumber = Nothing
                    ReverseIncomeOnly.ReferenceNumber = IncomeOnly.ReferenceNumber
                    ReverseIncomeOnly.JobNumber = IncomeOnly.JobNumber
                    ReverseIncomeOnly.JobComponentNumber = IncomeOnly.JobComponentNumber
                    ReverseIncomeOnly.OrderNumber = IncomeOnly.OrderNumber
                    ReverseIncomeOnly.LineNumber = IncomeOnly.LineNumber
                    ReverseIncomeOnly.FunctionCode = IncomeOnly.FunctionCode
                    ReverseIncomeOnly.InvoiceDate = IncomeOnly.InvoiceDate
                    ReverseIncomeOnly.Amount = IncomeOnly.Amount.GetValueOrDefault(0) * -1
                    ReverseIncomeOnly.Description = IncomeOnly.Description
                    ReverseIncomeOnly.CommissionPercent = IncomeOnly.CommissionPercent
                    ReverseIncomeOnly.TaxCode = IncomeOnly.TaxCode
                    ReverseIncomeOnly.BillHoldFlag = IncomeOnly.BillHoldFlag
                    ReverseIncomeOnly.ARInvoiceNumber = Nothing
                    ReverseIncomeOnly.ARInvoiceSequence = Nothing
                    ReverseIncomeOnly.ARType = Nothing
                    ReverseIncomeOnly.BillingUser = If(IncomeOnlyReversalOverride IsNot Nothing, IncomeOnlyReversalOverride.BillingUser, Nothing)
                    ReverseIncomeOnly.TaxStatePercent = IncomeOnly.TaxStatePercent
                    ReverseIncomeOnly.TaxCountyPercent = IncomeOnly.TaxCountyPercent
                    ReverseIncomeOnly.TaxCityPercent = IncomeOnly.TaxCityPercent
                    ReverseIncomeOnly.TaxCommission = IncomeOnly.TaxCommission
                    ReverseIncomeOnly.TaxCommissionOnly = IncomeOnly.TaxCommissionOnly
                    ReverseIncomeOnly.TaxResale = IncomeOnly.TaxResale
                    ReverseIncomeOnly.AdjusterComments = If(IncomeOnlyReversalOverride IsNot Nothing, IncomeOnlyReversalOverride.AdjusterComments, Nothing)
                    ReverseIncomeOnly.GeneralLedgerBilling = Nothing
                    ReverseIncomeOnly.GeneralLedgerSales = Nothing
                    ReverseIncomeOnly.GeneralLedgerState = Nothing
                    ReverseIncomeOnly.GeneralLedgerCounty = Nothing
                    ReverseIncomeOnly.GeneralLedgerCity = Nothing
                    ReverseIncomeOnly.GeneralLedgerAccountSales = Nothing
                    ReverseIncomeOnly.GeneralLedgerAccountState = Nothing
                    ReverseIncomeOnly.GeneralLedgerAccountCounty = Nothing
                    ReverseIncomeOnly.GeneralLedgerAccountCity = Nothing
                    ReverseIncomeOnly.AdvanceBillFlag = IncomeOnly.AdvanceBillFlag
                    ReverseIncomeOnly.DepartmentTeamCode = IncomeOnly.DepartmentTeamCode
                    ReverseIncomeOnly.ExtendedMarkupAmount = IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0) * -1
                    ReverseIncomeOnly.ExtendedStateResale = IncomeOnly.ExtendedStateResale.GetValueOrDefault(0) * -1
                    ReverseIncomeOnly.ExtendedCountyResale = IncomeOnly.ExtendedCountyResale.GetValueOrDefault(0) * -1
                    ReverseIncomeOnly.ExtendedCityResale = IncomeOnly.ExtendedCityResale.GetValueOrDefault(0) * -1

                    If IncomeOnly.Quantity.HasValue Then

                        ReverseIncomeOnly.Quantity = IncomeOnly.Quantity * -1

                    Else

                        ReverseIncomeOnly.Quantity = Nothing
                    End If

                    If IncomeOnly.Rate.HasValue Then

                        ReverseIncomeOnly.Rate = IncomeOnly.Rate

                    Else

                        ReverseIncomeOnly.Rate = Nothing

                    End If

                    ReverseIncomeOnly.LineTotal = IncomeOnly.LineTotal.GetValueOrDefault(0) * -1
                    ReverseIncomeOnly.NonBillable = IncomeOnly.NonBillable
                    ReverseIncomeOnly.IsModified = 1
                    ReverseIncomeOnly.ModifiedBy = DbContext.UserCode
                    ReverseIncomeOnly.ModifiedDate = System.DateTime.Today
                    ReverseIncomeOnly.PostPeriod = Nothing
                    ReverseIncomeOnly.AdvanceBillID = IncomeOnly.AdvanceBillID
                    ReverseIncomeOnly.Comment = IncomeOnly.Comment
                    ReverseIncomeOnly.CampaignUpdatedInvoiceDate = IncomeOnly.CampaignUpdatedInvoiceDate
                    ReverseIncomeOnly.CampaignUpdatedPostPeriod = IncomeOnly.CampaignUpdatedPostPeriod
                    ReverseIncomeOnly.TransferFromJob = Nothing
                    ReverseIncomeOnly.TransferFromJobComponent = Nothing
                    ReverseIncomeOnly.TransferFromFunction = Nothing
                    ReverseIncomeOnly.TransferFromIncomeOnlyID = Nothing
                    ReverseIncomeOnly.TransferFromSequenceNumber = Nothing
                    ReverseIncomeOnly.TransferAdjustedUser = If(IncomeOnlyReversalOverride IsNot Nothing, IncomeOnlyReversalOverride.TransferAdjustedUser, Nothing)
                    ReverseIncomeOnly.TransferAdjustedDate = If(IncomeOnlyReversalOverride IsNot Nothing, IncomeOnlyReversalOverride.TransferAdjustedDate, Nothing)
                    ReverseIncomeOnly.FeeInvoice = IncomeOnly.FeeInvoice
                    ReverseIncomeOnly.IsArchived = Nothing
                    ReverseIncomeOnly.BillingApprovalID = Nothing
                    ReverseIncomeOnly.BillingCommandCenterID = If(IncomeOnlyReversalOverride IsNot Nothing, IncomeOnlyReversalOverride.BillingCommandCenterID, Nothing)
                    ReverseIncomeOnly.JobServiceFeeID = IncomeOnly.JobServiceFeeID

                    If IncomeOnly.ARInvoiceNumber.HasValue Then

                        ReverseIncomeOnly.IsBilledReversal = True

                    End If

                    If ReverseAction = Methods.ReverseAction.Delete Then

                        BilledIncomeOnly = New AdvantageFramework.Database.Entities.IncomeOnly

                        BilledIncomeOnly.ID = IncomeOnly.ID
                        BilledIncomeOnly.SequenceNumber = Nothing
                        BilledIncomeOnly.ReferenceNumber = IncomeOnly.ReferenceNumber
                        BilledIncomeOnly.JobNumber = IncomeOnly.JobNumber
                        BilledIncomeOnly.JobComponentNumber = IncomeOnly.JobComponentNumber
                        BilledIncomeOnly.OrderNumber = IncomeOnly.OrderNumber
                        BilledIncomeOnly.LineNumber = IncomeOnly.LineNumber
                        BilledIncomeOnly.FunctionCode = IncomeOnly.FunctionCode
                        BilledIncomeOnly.InvoiceDate = IncomeOnly.InvoiceDate
                        BilledIncomeOnly.Amount = 0
                        BilledIncomeOnly.Description = IncomeOnly.Description
                        BilledIncomeOnly.CommissionPercent = IncomeOnly.CommissionPercent
                        BilledIncomeOnly.TaxCode = IncomeOnly.TaxCode
                        BilledIncomeOnly.BillHoldFlag = IncomeOnly.BillHoldFlag
                        BilledIncomeOnly.ARInvoiceNumber = Nothing
                        BilledIncomeOnly.ARInvoiceSequence = Nothing
                        BilledIncomeOnly.ARType = Nothing
                        BilledIncomeOnly.BillingUser = Nothing
                        BilledIncomeOnly.TaxStatePercent = IncomeOnly.TaxStatePercent
                        BilledIncomeOnly.TaxCountyPercent = IncomeOnly.TaxCountyPercent
                        BilledIncomeOnly.TaxCityPercent = IncomeOnly.TaxCityPercent
                        BilledIncomeOnly.TaxCommission = IncomeOnly.TaxCommission
                        BilledIncomeOnly.TaxCommissionOnly = IncomeOnly.TaxCommissionOnly
                        BilledIncomeOnly.TaxResale = IncomeOnly.TaxResale
                        BilledIncomeOnly.AdjusterComments = Nothing
                        BilledIncomeOnly.GeneralLedgerBilling = Nothing
                        BilledIncomeOnly.GeneralLedgerSales = Nothing
                        BilledIncomeOnly.GeneralLedgerState = Nothing
                        BilledIncomeOnly.GeneralLedgerCounty = Nothing
                        BilledIncomeOnly.GeneralLedgerCity = Nothing
                        BilledIncomeOnly.GeneralLedgerAccountSales = Nothing
                        BilledIncomeOnly.GeneralLedgerAccountState = Nothing
                        BilledIncomeOnly.GeneralLedgerAccountCounty = Nothing
                        BilledIncomeOnly.GeneralLedgerAccountCity = Nothing
                        BilledIncomeOnly.AdvanceBillFlag = IncomeOnly.AdvanceBillFlag
                        BilledIncomeOnly.DepartmentTeamCode = IncomeOnly.DepartmentTeamCode
                        BilledIncomeOnly.ExtendedMarkupAmount = 0
                        BilledIncomeOnly.ExtendedStateResale = 0
                        BilledIncomeOnly.ExtendedCountyResale = 0
                        BilledIncomeOnly.ExtendedCityResale = 0
                        BilledIncomeOnly.Quantity = Nothing
                        BilledIncomeOnly.Rate = IncomeOnly.Rate
                        BilledIncomeOnly.LineTotal = 0
                        BilledIncomeOnly.NonBillable = IncomeOnly.NonBillable
                        BilledIncomeOnly.IsModified = Nothing
                        BilledIncomeOnly.ModifiedBy = DbContext.UserCode
                        BilledIncomeOnly.ModifiedDate = System.DateTime.Today
                        BilledIncomeOnly.PostPeriod = Nothing
                        BilledIncomeOnly.AdvanceBillID = IncomeOnly.AdvanceBillID
                        BilledIncomeOnly.Comment = IncomeOnly.Comment
                        BilledIncomeOnly.CampaignUpdatedInvoiceDate = IncomeOnly.CampaignUpdatedInvoiceDate
                        BilledIncomeOnly.CampaignUpdatedPostPeriod = IncomeOnly.CampaignUpdatedPostPeriod
                        BilledIncomeOnly.TransferFromJob = Nothing
                        BilledIncomeOnly.TransferFromJobComponent = Nothing
                        BilledIncomeOnly.TransferFromFunction = Nothing
                        BilledIncomeOnly.TransferFromIncomeOnlyID = Nothing
                        BilledIncomeOnly.TransferFromSequenceNumber = Nothing
                        BilledIncomeOnly.TransferAdjustedUser = Nothing
                        BilledIncomeOnly.TransferAdjustedDate = Nothing
                        BilledIncomeOnly.FeeInvoice = IncomeOnly.FeeInvoice
                        BilledIncomeOnly.IsArchived = Nothing
                        BilledIncomeOnly.BillingApprovalID = Nothing
                        BilledIncomeOnly.BillingCommandCenterID = Nothing
                        BilledIncomeOnly.JobServiceFeeID = IncomeOnly.JobServiceFeeID

                    End If

                    IncomeOnly.IsModified = 1
                    IncomeOnly.ModifiedBy = DbContext.UserCode
                    IncomeOnly.ModifiedDate = System.DateTime.Today

                    ReverseIncomeOnly.IsModified = 1
                    ReverseIncomeOnly.ModifiedBy = DbContext.UserCode
                    ReverseIncomeOnly.ModifiedDate = System.DateTime.Today

                    If Update(DbContext, IncomeOnly) Then

                        If Insert(DbContext, ReverseIncomeOnly) Then

                            Reversed = True

                            If ReverseAction = Methods.ReverseAction.Delete Then

                                Reversed = Insert(DbContext, BilledIncomeOnly)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Reversed = False
            Finally
                Reverse = Reversed
            End Try

        End Function

#End Region

    End Module

End Namespace

