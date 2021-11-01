Namespace Reporting.Database.Procedures.VendorContractsReport

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

        Public Function LoadGreaterThanEndDate(ByVal ReportingDbContext As Reporting.Database.DbContext, EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.VendorContractsReport)

            LoadGreaterThanEndDate = From VendorContractsReport In ReportingDbContext.GetQuery(Of Database.Views.VendorContractsReport)
                                     Where VendorContractsReport.ContractEndDate > EndDate
                                     Select VendorContractsReport

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.VendorContractsReport)

            Load = From VendorContractsReport In ReportingDbContext.GetQuery(Of Database.Views.VendorContractsReport)
                   Select VendorContractsReport

        End Function

#End Region

    End Module

End Namespace
