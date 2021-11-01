Namespace Reporting.Database.Procedures.AlertsWithCommentsReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.AlertsWithCommentsReport)

            Load = From AlertsWithCommentsReport In ReportingDbContext.GetQuery(Of Database.Views.AlertsWithCommentsReport)
                   Select AlertsWithCommentsReport

        End Function

#End Region

    End Module

End Namespace
