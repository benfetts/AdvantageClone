Namespace Reporting.Database.Procedures.ServiceFeeComplexType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ServiceFee)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString))

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal StartingPostPeriodCode As String,
                             ByVal EndingPostPeriodCode As String, ByVal UserID As String, ByVal IncludeCampaign As Boolean,
                             ByVal IncludeClient As Boolean, ByVal IncludeDivision As Boolean, ByVal IncludeProduct As Boolean,
                             ByVal IncludeJobNumber As Boolean, ByVal IncludeSalesClass As Boolean, ByVal IncludeFeeType As Boolean,
                             ByVal IncludeFunctionCode As Boolean, ByVal IncludeFunctionHeading As Boolean, ByVal IncludeFunctionConsolidation As Boolean,
                             ByVal IncludeEmployee As Boolean, ByVal IncludeDate As Boolean, ByVal DesktopObject As Integer, ByVal ServiceFeeType As String, ByVal IncludePostPeriod As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ServiceFee)

            'objects
            Dim SqlParameterStartPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeCampaign As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeClient As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeDivision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeProduct As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeSalesClass As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeFeeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeFunctionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeFunctionHeading As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeFunctionConsolidation As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeEmployee As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDesktopObject As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterServiceFeeTypeObject As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludePostPeriod As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterStartPeriod = New System.Data.SqlClient.SqlParameter("@StartPeriod", SqlDbType.VarChar)
            SqlParameterEndPeriod = New System.Data.SqlClient.SqlParameter("@EndPeriod", SqlDbType.VarChar)
            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar)
            SqlParameterIncludeClient = New System.Data.SqlClient.SqlParameter("@IncludeClient", SqlDbType.Bit)
            SqlParameterIncludeDivision = New System.Data.SqlClient.SqlParameter("@IncludeDivision", SqlDbType.Bit)
            SqlParameterIncludeProduct = New System.Data.SqlClient.SqlParameter("@IncludeProduct", SqlDbType.Bit)
            SqlParameterIncludeCampaign = New System.Data.SqlClient.SqlParameter("@IncludeCampaign", SqlDbType.Bit)
            SqlParameterIncludeSalesClass = New System.Data.SqlClient.SqlParameter("@IncludeSalesClass", SqlDbType.Bit)
            SqlParameterIncludeJobNumber = New System.Data.SqlClient.SqlParameter("@IncludeJobNumber", SqlDbType.Bit)
            SqlParameterIncludeFeeType = New System.Data.SqlClient.SqlParameter("@IncludeFeeType", SqlDbType.Bit)
            SqlParameterIncludeFunctionCode = New System.Data.SqlClient.SqlParameter("@IncludeFunctionCode", SqlDbType.Bit)
            SqlParameterIncludeFunctionHeading = New System.Data.SqlClient.SqlParameter("@IncludeFunctionHeading", SqlDbType.Bit)
            SqlParameterIncludeFunctionConsolidation = New System.Data.SqlClient.SqlParameter("@IncludeFunctionConsolidation", SqlDbType.Bit)
            SqlParameterIncludeEmployee = New System.Data.SqlClient.SqlParameter("@IncludeEmployee", SqlDbType.Bit)
            SqlParameterIncludeDate = New System.Data.SqlClient.SqlParameter("@IncludeDate", SqlDbType.Bit)
            SqlParameterDesktopObject = New System.Data.SqlClient.SqlParameter("@DesktopObject", SqlDbType.SmallInt)
            SqlParameterServiceFeeTypeObject = New System.Data.SqlClient.SqlParameter("@ServiceFeeType", SqlDbType.VarChar)
            SqlParameterIncludePostPeriod = New System.Data.SqlClient.SqlParameter("@IncludePostPeriod", SqlDbType.Bit)

            SqlParameterStartPeriod.Value = StartingPostPeriodCode
            SqlParameterEndPeriod.Value = EndingPostPeriodCode
            SqlParameterUserID.Value = UserID
            SqlParameterIncludeCampaign.Value = IncludeCampaign
            SqlParameterIncludeClient.Value = IncludeClient
            SqlParameterIncludeDivision.Value = IncludeDivision
            SqlParameterIncludeProduct.Value = IncludeProduct
            SqlParameterIncludeJobNumber.Value = IncludeJobNumber
            SqlParameterIncludeSalesClass.Value = IncludeSalesClass
            SqlParameterIncludeFeeType.Value = IncludeFeeType
            SqlParameterIncludeFunctionCode.Value = IncludeFunctionCode
            SqlParameterIncludeFunctionHeading.Value = IncludeFunctionHeading
            SqlParameterIncludeFunctionConsolidation.Value = IncludeFunctionConsolidation
            SqlParameterIncludeEmployee.Value = IncludeEmployee
            SqlParameterIncludeDate.Value = IncludeDate
            SqlParameterDesktopObject.Value = DesktopObject
            SqlParameterServiceFeeTypeObject.Value = ServiceFeeType
            SqlParameterIncludePostPeriod.Value = IncludePostPeriod

            Load = ReportingDbContext.Database.SqlQuery(Of Database.Classes.ServiceFee)("EXEC dbo.usp_wv_dto_MyServiceFee @StartPeriod, @EndPeriod, @UserID, @IncludeClient, @IncludeDivision, @IncludeProduct, @IncludeCampaign, @IncludeSalesClass, @IncludeJobNumber, @IncludeFeeType, @IncludeFunctionCode, @IncludeFunctionHeading, @IncludeFunctionConsolidation, @IncludeEmployee, @IncludeDate, @DesktopObject, @ServiceFeeType, @IncludePostPeriod",
                SqlParameterStartPeriod, SqlParameterEndPeriod, SqlParameterUserID, SqlParameterIncludeCampaign, SqlParameterIncludeClient, SqlParameterIncludeDivision,
                SqlParameterIncludeProduct, SqlParameterIncludeJobNumber, SqlParameterIncludeSalesClass, SqlParameterIncludeFeeType, SqlParameterIncludeFunctionCode,
                SqlParameterIncludeFunctionHeading, SqlParameterIncludeFunctionConsolidation, SqlParameterIncludeEmployee, SqlParameterIncludeDate, SqlParameterDesktopObject,
                SqlParameterServiceFeeTypeObject, SqlParameterIncludePostPeriod)

        End Function

#End Region

    End Module

End Namespace
