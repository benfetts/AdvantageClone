Namespace Reporting.Database.Procedures.CRMOpportunityDetailReport

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

        Public Function LoadGreaterThanEndDate(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMOpportunityDetailReport)

            LoadGreaterThanEndDate = From CRMOpportunityDetailReport In ReportingDbContext.GetQuery(Of Database.Views.CRMOpportunityDetailReport)
                                     Where CRMOpportunityDetailReport.EndDate > EndDate
                                     Select CRMOpportunityDetailReport

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMOpportunityDetailReport)

            Load = From CRMOpportunityDetailReport In ReportingDbContext.GetQuery(Of Database.Views.CRMOpportunityDetailReport)
                   Select CRMOpportunityDetailReport

        End Function

#End Region

    End Module

End Namespace
