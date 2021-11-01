Namespace Reporting.Database.Procedures.DivisionReport

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Views.DivisionReport)

            Load = From DivisionReport In ReportingDbContext.GetQuery(Of Database.Views.DivisionReport)
                   Select DivisionReport

        End Function

#End Region

    End Module

End Namespace
