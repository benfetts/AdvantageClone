Namespace Reporting.Database.Procedures.CRMOpportunityToInvestmentReport

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

        Public Function LoadGreaterThanEndDate(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport)

            LoadGreaterThanEndDate = From CRMOpportunityToInvestmentReport In ReportingDbContext.GetQuery(Of Database.Views.CRMOpportunityToInvestmentReport)
                                     Where CRMOpportunityToInvestmentReport.ContractEndDate > EndDate
                                     Select CRMOpportunityToInvestmentReport

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMOpportunityToInvestmentReport)

            Load = From CRMOpportunityToInvestmentReport In ReportingDbContext.GetQuery(Of Database.Views.CRMOpportunityToInvestmentReport)
                   Select CRMOpportunityToInvestmentReport

        End Function

#End Region

    End Module

End Namespace
