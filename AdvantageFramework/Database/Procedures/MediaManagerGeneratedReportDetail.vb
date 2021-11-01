Namespace Database.Procedures.MediaManagerGeneratedReportDetail

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

        Public Function LoadByMediaManagerGeneratedReportID(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail)

            LoadByMediaManagerGeneratedReportID = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail)().Where(Function(Entity) Entity.MediaManagerGeneratedReportID = MediaManagerGeneratedReportID)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail)()

        End Function

#End Region

    End Module

End Namespace
