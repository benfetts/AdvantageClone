Namespace Reporting.Database.Procedures.ClientContactReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.ClientContactReport)

            Load = From ClientContactReport In ReportingDbContext.GetQuery(Of Database.Views.ClientContactReport)
                   Select ClientContactReport

        End Function

#End Region

    End Module

End Namespace
