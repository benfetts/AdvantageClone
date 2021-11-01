Namespace Database.Procedures.ServiceFeeReconcileComplexType

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

        Public Function Load(ByVal DbContext As Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ServiceFeeReconcile)

            Load = Load(DbContext, ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeReconParameters.StartingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeReconParameters.EndingPostPeriodCode.ToString), ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeReconParameters.StartDate.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeReconParameters.EndDate.ToString))

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext, ByVal StartingPostPeriodCode As String,
                             ByVal EndingPostPeriodCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ServiceFeeReconcile)

            Load = DbContext.Database.SqlQuery(Of Database.Classes.ServiceFeeReconcile)(String.Format("EXEC [dbo].[usp_wv_Dataset_ServiceFee] '{0}', '{1}', '{2}', '{3}', '{4}'", DbContext.UserCode, StartingPostPeriodCode, EndingPostPeriodCode, StartDate.ToString(System.Globalization.CultureInfo.InvariantCulture), EndDate.ToString(System.Globalization.CultureInfo.InvariantCulture)))

        End Function

#End Region

    End Module

End Namespace
