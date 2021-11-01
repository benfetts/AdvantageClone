Namespace Reporting.Database.Procedures.NewspaperOrderDetailReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.NewspaperOrderDetailReport)

            Load = From NewspaperOrderDetailReport In ReportingDbContext.GetQuery(Of Database.Views.NewspaperOrderDetailReport)
                   Select NewspaperOrderDetailReport

        End Function

#End Region

    End Module

End Namespace
