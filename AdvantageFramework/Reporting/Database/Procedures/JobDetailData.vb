Namespace Reporting.Database.Procedures.JobDetailData

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.JobDetailData)

            Load = From JobDetailData In ReportingDbContext.GetQuery(Of Database.Entities.JobDetailData)
                   Select JobDetailData

        End Function

#End Region

    End Module

End Namespace
