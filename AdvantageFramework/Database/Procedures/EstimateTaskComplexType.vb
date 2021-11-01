Namespace Database.Procedures.EstimateTaskComplexType

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

        Public Function Load(DbContext As Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer,
                             RevisionNumber As Integer, QuoteNumber As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.EstimateTask)

            'objects
            Dim SqlParameterEstimateNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEstimateComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRevisionNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterQuoteNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterEstimateNumber = New System.Data.SqlClient.SqlParameter("@EST_NUMBER", SqlDbType.Int)
            SqlParameterEstimateComponentNumber = New System.Data.SqlClient.SqlParameter("@EST_COMP_NUMBER", SqlDbType.Int)
            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@QUOTE_NUMBER", SqlDbType.Int)
            SqlParameterQuoteNumber = New System.Data.SqlClient.SqlParameter("@REVISION_NUMBER", SqlDbType.Int)

            SqlParameterEstimateNumber.Value = EstimateNumber
            SqlParameterEstimateComponentNumber.Value = EstimateComponentNumber
            SqlParameterRevisionNumber.Value = RevisionNumber
            SqlParameterQuoteNumber.Value = QuoteNumber

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EstimateTask)("EXEC dbo.advsp_traffic_schedule_GetEstimateTasks @EST_NUMBER, @EST_COMP_NUMBER, @QUOTE_NUMBER, @REVISION_NUMBER",
                SqlParameterEstimateNumber, SqlParameterEstimateComponentNumber, SqlParameterRevisionNumber, SqlParameterQuoteNumber).ToList

        End Function

#End Region

    End Module

End Namespace

