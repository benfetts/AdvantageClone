Namespace Reporting.Database.Procedures.CRMClientContractsReport

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

        Public Function LoadGreaterThanEndDate(ByVal ReportingDbContext As Reporting.Database.DbContext, EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMClientContractsReport)

            LoadGreaterThanEndDate = From CRMClientContractsReport In ReportingDbContext.GetQuery(Of Database.Views.CRMClientContractsReport)
                                     Where CRMClientContractsReport.ContractEndDate > EndDate
                                     Select CRMClientContractsReport

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.CRMClientContractsReport)

            Load = From CRMClientContractsReport In ReportingDbContext.GetQuery(Of Database.Views.CRMClientContractsReport)
                   Select CRMClientContractsReport

        End Function

#End Region

    End Module

End Namespace
