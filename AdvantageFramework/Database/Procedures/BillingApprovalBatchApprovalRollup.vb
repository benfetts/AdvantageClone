Namespace Database.Procedures.BillingApprovalBatchApprovalRollup

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

        Public Function Load(ByVal DbContext As Database.DbContext,
                             ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As Collections.Generic.List(Of AdvantageFramework.Database.Classes.BillingApprovalBatchApprovalRollup)

            Load = Load(DbContext,
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.JobNumber.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.JobComponentNumber.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.CampaignIdentifier.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.RollupType.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.BillingApprovalID.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.BillingApprovalBatchID.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.TempCutoffDate.ToString()),
                        ParameterDictionary(AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupParameter.TempCutoffFunctionType.ToString())
                        )

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext,
                             ByVal JobNumber As Integer,
                             ByVal JobComponentNumber As Integer,
                             ByVal CampaignIdentifier As Integer,
                             ByVal RollupType As AdvantageFramework.Database.Entities.BillingApprovalBatchApprovalRollupType,
                             ByVal BillingApprovalID As Integer,
                             ByVal BillingApprovalBatchID As Integer,
                             ByVal TempCutoffDate As Date,
                             ByVal TempCutoffFunctionType As String) As Collections.Generic.List(Of AdvantageFramework.Database.Classes.BillingApprovalBatchApprovalRollup)

            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRollupType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBAID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBABatchID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTempCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTempCutoffFunctionType As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            SqlParameterRollupType = New System.Data.SqlClient.SqlParameter("@ROLLUP_TYPE", SqlDbType.SmallInt)
            SqlParameterBAID = New System.Data.SqlClient.SqlParameter("@BA_ID", SqlDbType.Int)
            SqlParameterBABatchID = New System.Data.SqlClient.SqlParameter("@BA_BATCH_ID", SqlDbType.Int)
            SqlParameterTempCutoff = New System.Data.SqlClient.SqlParameter("@TEMP_CUTOFF", SqlDbType.SmallDateTime)
            SqlParameterTempCutoffFunctionType = New System.Data.SqlClient.SqlParameter("@TEMP_CUTOFF_FNC_TYPE", SqlDbType.VarChar)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterCampaignID.Value = CampaignIdentifier
            SqlParameterRollupType.Value = RollupType
            SqlParameterBAID.Value = BillingApprovalID
            SqlParameterBABatchID.Value = BillingApprovalBatchID
            SqlParameterTempCutoff.Value = IIf(TempCutoffDate = #12:00:00 AM#, System.DBNull.Value, TempCutoffDate)
            SqlParameterTempCutoffFunctionType.Value = TempCutoffFunctionType

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.BillingApprovalBatchApprovalRollup)("EXEC dbo.advsp_billing_approval_rollup @JOB_NUMBER, @JOB_COMPONENT_NBR, @CMP_IDENTIFIER, @ROLLUP_TYPE, @BA_ID, @BA_BATCH_ID, @TEMP_CUTOFF, @TEMP_CUTOFF_FNC_TYPE",
                                                                                                                          SqlParameterJobNumber,
                                                                                                                          SqlParameterJobComponentNumber,
                                                                                                                          SqlParameterCampaignID,
                                                                                                                          SqlParameterRollupType,
                                                                                                                          SqlParameterBAID,
                                                                                                                          SqlParameterBABatchID,
                                                                                                                          SqlParameterTempCutoff,
                                                                                                                          SqlParameterTempCutoffFunctionType).ToList
        End Function

#End Region

    End Module

End Namespace
