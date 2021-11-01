Namespace Reporting.Database.Procedures.JobPurchaseOrderReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Classes.JobPurchaseOrderReportSP)

            Load = From JobPurchaseOrderReport In ReportingDbContext.GetQuery(Of Database.Classes.JobPurchaseOrderReportSP)
                   Select JobPurchaseOrderReport

        End Function

#End Region

    End Module

End Namespace
