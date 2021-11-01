Namespace Reporting.Database.Procedures.CampaignReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CampaignReport)

            If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString) AndAlso
                    ParameterDictionary(AdvantageFramework.Reporting.CampaignParameters.IncludeClosed.ToString) = True Then

                Load = From CampaignReport In ReportingDbContext.GetQuery(Of Database.Views.CampaignReport)
                       Select CampaignReport

            Else

                Load = From CampaignReport In ReportingDbContext.GetQuery(Of Database.Views.CampaignReport)
                       Where CampaignReport.Closed = "No"
                       Select CampaignReport

            End If

        End Function

#End Region

    End Module

End Namespace
