Namespace Reporting.Database.Procedures.AROpenAgedComplexType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.AROpenAged)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.UsedID.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.PeriodCutoff.ToString), ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.AgingOption.ToString), ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.IncludeDetails.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.AROpenAgedParameters.RecordSource.ToString))

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal UserID As String,
                             ByVal PeriodCutoff As String, ByVal AgingDate As DateTime, ByVal AgingOption As Short,
                             ByVal IncludeDetails As Boolean, ByVal RecordSource As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.AROpenAged)

            'objects
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPeriodCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAgingDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAgingOption As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeDetails As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRecordSource As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
            SqlParameterPeriodCutoff = New System.Data.SqlClient.SqlParameter("@PeriodCutoff", SqlDbType.VarChar)
            SqlParameterAgingDate = New System.Data.SqlClient.SqlParameter("@AgingDate", SqlDbType.SmallDateTime)
            SqlParameterAgingOption = New System.Data.SqlClient.SqlParameter("@AgingOption", SqlDbType.SmallInt)
            SqlParameterIncludeDetails = New System.Data.SqlClient.SqlParameter("@IncludeDetails", SqlDbType.Bit)
            SqlParameterRecordSource = New System.Data.SqlClient.SqlParameter("@RecordSource", SqlDbType.Int)

            SqlParameterUserID.Value = UserID
            SqlParameterPeriodCutoff.Value = PeriodCutoff
            SqlParameterAgingDate.Value = AgingDate
            SqlParameterAgingOption.Value = AgingOption
            SqlParameterIncludeDetails.Value = IncludeDetails
            SqlParameterRecordSource.Value = RecordSource

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.AROpenAged)("EXEC dbo.usp_wv_Dataset_AR_Aging @UserID, @PeriodCutoff, @AgingDate, @AgingOption, @IncludeDetails, @RecordSource",
                SqlParameterUserID, SqlParameterPeriodCutoff, SqlParameterAgingDate, SqlParameterAgingOption, SqlParameterIncludeDetails, SqlParameterRecordSource)

        End Function

#End Region

    End Module

End Namespace
