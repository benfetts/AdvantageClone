Namespace Database.Procedures.MediaManagerGeneratedReportSentInfo

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

        Public Function LoadByOrderNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)

            LoadByOrderNumber = From MediaManagerGeneratedReportSentInfo In DbContext.GetQuery(Of Database.Entities.MediaManagerGeneratedReportSentInfo).Include("MediaManagerGeneratedReport")
                                Where MediaManagerGeneratedReportSentInfo.MediaManagerGeneratedReport.OrderNumber = OrderNumber
                                Select MediaManagerGeneratedReportSentInfo

        End Function
        Public Function LoadByMediaManagerGeneratedReportID(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedReportID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)

            LoadByMediaManagerGeneratedReportID = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)().Where(Function(Entity) Entity.MediaManagerGeneratedReportID = MediaManagerGeneratedReportID)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)()

        End Function

#End Region

    End Module

End Namespace
