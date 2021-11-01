Namespace Database.Procedures.NonbilledEmployeeTimeComplexType

    <HideModuleName()>
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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext, UserCode As String,
                             Optional ByVal EmployeeCode As String = Nothing,
                             Optional ByVal JobNumber As Integer? = Nothing, Optional ByVal JobComponentNumber As Short? = Nothing,
                             Optional ByVal DateFrom? As Date = Nothing, Optional ByVal DateTo? As Date = Nothing,
                             Optional ByVal JobTimeOnly As Boolean = False, Optional ByVal ClientCode As String = Nothing,
                             Optional ByVal IncludeBilledTime As Boolean = False) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex)

            'objects
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateFrom As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateTo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobTimeOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeBilledTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMP_NBR", SqlDbType.SmallInt)
            SqlParameterDateFrom = New System.Data.SqlClient.SqlParameter("@DATE_FROM", SqlDbType.DateTime)
            SqlParameterDateTo = New System.Data.SqlClient.SqlParameter("@DATE_TO", SqlDbType.DateTime)
            SqlParameterJobTimeOnly = New System.Data.SqlClient.SqlParameter("@JOB_TIME_ONLY", SqlDbType.Bit)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterIncludeBilledTime = New System.Data.SqlClient.SqlParameter("@INCLUDE_BILLED_TIME", SqlDbType.Bit)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            If EmployeeCode IsNot Nothing Then

                SqlParameterEmployeeCode.Value = EmployeeCode

            Else

                SqlParameterEmployeeCode.Value = System.DBNull.Value

            End If

            If JobNumber.HasValue Then

                SqlParameterJobNumber.Value = JobNumber.Value

            Else

                SqlParameterJobNumber.Value = System.DBNull.Value

            End If

            If JobComponentNumber.HasValue Then

                SqlParameterJobComponentNumber.Value = JobComponentNumber.Value

            Else

                SqlParameterJobComponentNumber.Value = System.DBNull.Value

            End If

            If DateFrom.HasValue Then

                SqlParameterDateFrom.Value = DateFrom

            Else

                SqlParameterDateFrom.Value = System.DBNull.Value

            End If

            If DateTo.HasValue Then

                SqlParameterDateTo.Value = DateTo

            Else

                SqlParameterDateTo.Value = System.DBNull.Value

            End If

            SqlParameterJobTimeOnly.Value = If(JobTimeOnly, 1, 0)

            If ClientCode IsNot Nothing Then

                SqlParameterClientCode.Value = ClientCode

            Else

                SqlParameterClientCode.Value = System.DBNull.Value

            End If

            SqlParameterIncludeBilledTime.Value = If(IncludeBilledTime, 1, 0)

            SqlParameterUserCode.Value = UserCode

            Load = DbContext.Database.SqlQuery(Of Database.Classes.NonbilledEmployeeTimeComplex)("EXEC dbo.advsp_load_nonbilled_time @EMP_CODE, @JOB_NUMBER, @JOB_COMP_NBR, @DATE_FROM, @DATE_TO, @JOB_TIME_ONLY, @CL_CODE, @INCLUDE_BILLED_TIME, @USER_CODE",
                                                                                                   SqlParameterEmployeeCode, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterDateFrom, SqlParameterDateTo, SqlParameterJobTimeOnly,
                                                                                                   SqlParameterClientCode, SqlParameterIncludeBilledTime, SqlParameterUserCode).ToList

        End Function
        Public Function Update(ByVal DbContext As Database.DbContext, ByVal NonbilledEmployeeTime As AdvantageFramework.Database.Classes.NonbilledEmployeeTime) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim UpdateString As String = Nothing
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim AdjusterComments As String = ""

            Try

                If NonbilledEmployeeTime.Assignment.HasValue Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("Update [dbo].[EMP_TIME_DTL] Set ALERT_ID = {0} WHERE ET_ID = {1} AND SEQ_NBR = {2}", NonbilledEmployeeTime.Assignment.Value,
                                                    NonbilledEmployeeTime.EmployeeTimeID, NonbilledEmployeeTime.SequenceNumber))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("Update [dbo].[EMP_TIME_DTL] Set ALERT_ID = NULL WHERE ET_ID = {0} AND SEQ_NBR = {1}",
                                                    NonbilledEmployeeTime.EmployeeTimeID, NonbilledEmployeeTime.SequenceNumber))

                End If

                If NonbilledEmployeeTime.EmployeeTimeFlag <> AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Unbilled Then

                    If NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Billed OrElse
                        NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.SelectedForBilling Then

                        UpdateString = String.Format("UPDATE [dbo].[EMP_TIME_DTL] SET DP_TM_CODE = '{0}' WHERE ET_ID = {1} AND SEQ_NBR = {2}",
                                                     NonbilledEmployeeTime.DepartmentTeamCode,
                                                     NonbilledEmployeeTime.EmployeeTimeID,
                                                     NonbilledEmployeeTime.SequenceNumber)

                    ElseIf NonbilledEmployeeTime.EmployeeTimeFlag = AdvantageFramework.Database.Classes.NonbilledEmployeeTimeComplex.EmployeeTimeFlags.Indirect Then

                        UpdateString = String.Format("UPDATE [dbo].[EMP_TIME_NP] SET DP_TM_CODE = '{0}' WHERE ET_ID = {1} AND SEQ_NBR = {2}",
                                                     NonbilledEmployeeTime.DepartmentTeamCode,
                                                     NonbilledEmployeeTime.EmployeeTimeID,
                                                     NonbilledEmployeeTime.SequenceNumber)

                    End If

                    DbContext.Database.ExecuteSqlCommand(UpdateString)

                    Updated = True

                Else

                    Try

                        EmployeeTimeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeID(DbContext, NonbilledEmployeeTime.EmployeeTimeID).Include("JobComponent")
                                              Where Entity.SequenceNumber = NonbilledEmployeeTime.SequenceNumber
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        EmployeeTimeDetail = Nothing
                    End Try

                    If EmployeeTimeDetail IsNot Nothing Then

                        If (EmployeeTimeDetail.IsAdvancedBill.HasValue = False OrElse (EmployeeTimeDetail.IsAdvancedBill <> 3 AndAlso EmployeeTimeDetail.IsAdvancedBill <> 6)) AndAlso
                                EmployeeTimeDetail.ARInvoiceNumber.GetValueOrDefault(0) = 0 AndAlso String.IsNullOrEmpty(EmployeeTimeDetail.BillingUserCode) AndAlso
                                EmployeeTimeDetail.HasBeenEdited.GetValueOrDefault(0) = 0 AndAlso IsValidJobProcessControl(EmployeeTimeDetail.JobComponent.JobProcessNumber.GetValueOrDefault(1)) Then

                            If EmployeeTimeDetail.BillableRate.GetValueOrDefault(0) <> NonbilledEmployeeTime.BillingRate.GetValueOrDefault(0) Then

                                If NonbilledEmployeeTime.GetPropertyAutomaticallyChanged("BillingRate") = True Then

                                    AdjusterComments = String.Format("- Updated on {0} by user {1}",
                                                                     Now.ToString,
                                                                     DbContext.UserCode)

                                    AdjusterComments = "- Updated on " & Now.ToString & " by user " & DbContext.UserCode

                                Else

                                    AdjusterComments = String.Format("- Billing rate manually changed from {0} to {1} - {2} by {3}",
                                                                     EmployeeTimeDetail.BillableRate.GetValueOrDefault(0).ToString,
                                                                     NonbilledEmployeeTime.BillingRate.GetValueOrDefault(0).ToString,
                                                                     Now.ToString,
                                                                     DbContext.UserCode)

                                    NonbilledEmployeeTime.EmployeeRateFrom = "Manually Changed"

                                End If

                            End If

                            If EmployeeTimeDetail.IsNonBillable.GetValueOrDefault(0) <> NonbilledEmployeeTime.EmployeeNonBillableFlag.GetValueOrDefault(0) Then

                                If NonbilledEmployeeTime.GetPropertyAutomaticallyChanged("BillingRate") = True AndAlso NonbilledEmployeeTime.GetPropertyAutomaticallyChanged("EmployeeNonBillableFlag") = True Then

                                    'already added 

                                Else

                                    AdjusterComments = String.Format("- Manually changed from {0} to {1} - {2} by {3}",
                                                                     If(EmployeeTimeDetail.IsNonBillable.GetValueOrDefault(0) = 0, "billable", "non-billable"),
                                                                     If(NonbilledEmployeeTime.EmployeeNonBillableFlag.GetValueOrDefault(0) = 0, "billable", "non-billable"),
                                                                     Now.ToString,
                                                                     DbContext.UserCode)

                                End If

                            End If

                            EmployeeTimeDetail.DepartmentTeamCode = NonbilledEmployeeTime.DepartmentTeamCode
                            EmployeeTimeDetail.EmployeeTitleID = NonbilledEmployeeTime.EmployeeTitleID
                            EmployeeTimeDetail.TotalBilledAmount = NonbilledEmployeeTime.TotalBill
                            EmployeeTimeDetail.BillableRate = Math.Round(NonbilledEmployeeTime.BillingRate.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)
                            EmployeeTimeDetail.IsNonBillable = NonbilledEmployeeTime.EmployeeNonBillableFlag
                            EmployeeTimeDetail.FeeTimeType = NonbilledEmployeeTime.FeeTimeFlag
                            EmployeeTimeDetail.CommissionPercentage = NonbilledEmployeeTime.EmployeeCommissionPercent
                            EmployeeTimeDetail.SalesTaxCode = NonbilledEmployeeTime.TaxCode
                            EmployeeTimeDetail.SalesTaxResale = NonbilledEmployeeTime.TaxResale
                            EmployeeTimeDetail.SalesTaxStatePercentage = NonbilledEmployeeTime.TaxStatePercent
                            EmployeeTimeDetail.SalesTaxCountyPercentage = NonbilledEmployeeTime.TaxCountyPercent
                            EmployeeTimeDetail.SalesTaxCityPercentage = NonbilledEmployeeTime.TaxCityPercent
                            EmployeeTimeDetail.TaxCommission = NonbilledEmployeeTime.TaxCommission
                            EmployeeTimeDetail.TaxCommissionOnly = NonbilledEmployeeTime.TaxCommissionOnly
                            EmployeeTimeDetail.StateResaleAmount = NonbilledEmployeeTime.ExtendedStateResale
                            EmployeeTimeDetail.CountyResaleAmount = NonbilledEmployeeTime.ExtendedCountyResale
                            EmployeeTimeDetail.CityResaleAmount = NonbilledEmployeeTime.ExtendedCityResale

                            EmployeeTimeDetail.TotalBilledAmount = Math.Round(EmployeeTimeDetail.Hours * EmployeeTimeDetail.BillableRate.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)
                            EmployeeTimeDetail.MarkupAmount = Math.Round(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) * (EmployeeTimeDetail.CommissionPercentage.GetValueOrDefault(0) / 100), 2, MidpointRounding.AwayFromZero)

                            If NonbilledEmployeeTime.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                                EmployeeTimeDetail.StateResaleAmount = CalculateResale(0, EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxStatePercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CountyResaleAmount = CalculateResale(0, EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxCountyPercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CityResaleAmount = CalculateResale(0, EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxCityPercentage.GetValueOrDefault(0))

                            ElseIf NonbilledEmployeeTime.TaxCommission.GetValueOrDefault(0) = 1 Then

                                EmployeeTimeDetail.StateResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxStatePercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CountyResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxCountyPercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CityResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0), EmployeeTimeDetail.SalesTaxCityPercentage.GetValueOrDefault(0))

                            Else

                                EmployeeTimeDetail.StateResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), 0, EmployeeTimeDetail.SalesTaxStatePercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CountyResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), 0, EmployeeTimeDetail.SalesTaxCountyPercentage.GetValueOrDefault(0))
                                EmployeeTimeDetail.CityResaleAmount = CalculateResale(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0), 0, EmployeeTimeDetail.SalesTaxCityPercentage.GetValueOrDefault(0))

                            End If

                            EmployeeTimeDetail.TotalAmount = EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) +
                                                             EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0) +
                                                             EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0) +
                                                             EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0) +
                                                             EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0)

                            EmployeeTimeDetail.AdjusterComments &= AdjusterComments
                            EmployeeTimeDetail.EmployeeRateFrom = NonbilledEmployeeTime.EmployeeRateFrom

                            EmployeeTimeDetail.TaskCode = NonbilledEmployeeTime.TaskCode

                            DbContext.UpdateObject(EmployeeTimeDetail)

                            Updated = True

                        Else

                            Updated = True

                        End If

                    End If

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Private Function CalculateResale(ByVal ExtendedAmount As Decimal, ByVal MarkupAmount As Decimal, ByVal TaxPercent As Decimal) As Decimal

            'objects
            Dim TaxAmount As Decimal = Nothing

            Try

                TaxAmount = Math.Round((ExtendedAmount + MarkupAmount) * TaxPercent / 100, 2, MidpointRounding.AwayFromZero)

            Catch ex As Exception
                TaxAmount = 0
            Finally
                CalculateResale = TaxAmount
            End Try

        End Function
        Private Function IsValidJobProcessControl(ByVal JobProcessControl As Short) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim ValidProcessControls As Short() = Nothing

            ValidProcessControls = {1, 3, 4, 5, 7, 8, 9, 10, 11}

            If ValidProcessControls.Contains(JobProcessControl) = True Then

                IsValid = True

            End If

            IsValidJobProcessControl = IsValid

        End Function

#End Region

    End Module

End Namespace
