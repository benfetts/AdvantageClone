Namespace Nielsen.Database

    Public Class DbContext
        Inherits BaseClasses.DbContext

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            'MediaMarketBreaks
            NCCTVAIUEs
            NCCTVAIUELogs
            NCCTVAIUELogRevisions
            NCCTVCablenets
            NCCTVCarriageUEs
            NCCTVCarriageUELogs
            NCCTVCarriageUELogRevisions
            NCCTVFusionAudiences
            NCCTVFusionHutputs
            NCCTVFusionUniverses
            NCCTVFusionUniverseRevisions
            NCCTVLPMMarkets
            NCCTVMVPDs
            NCCTVSyscodes
            NielsenMarkets
            'NielsenNationalTVAudiences
            'NielsenNationalTVHutputs
            'NielsenNationalTVUniverses
            NielsenRadioAudiences
            NielsenRadioCountyAudiences
            NielsenRadioCountyClusters
            NielsenRadioCountyIntabs
            NielsenRadioCountyPeriods
            NielsenRadioCountyStations
            NielsenRadioCountyUniverses
            NielsenRadioDayparts
            NielsenRadioDemographics
            NielsenRadioFormats
            NielsenRadioIntabs
            NielsenRadioMarkets
            NielsenRadioPeriods
            NielsenRadioPeriodRevisions
            NielsenRadioPurs
            NielsenRadioQualitatives
            NielsenRadioReportTypes
            NielsenRadioSegmentChilds
            NielsenRadioSegmentParents
            NielsenRadioStations
            NielsenRadioStationHistorys
            NielsenRadioStationSimulcasts
            NielsenRadioUniverses
            NielsenRadioVStagings
            NielsenTVAudiences
            NielsenTVBooks
            NielsenTVBookRevisions
            NielsenTVCumeBooks
            NielsenTVCumeBookRevisions
            NielsenTVCumeDaypartImpressions
            NielsenTVDayparts
            NielsenTVHutputs
            NielsenTVIntabs
            NielsenTVPrograms
            NielsenTVStations
            NielsenTVStationHistorys
            NielsenTVUniverses
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Public Overridable Property MediaMarketBreaks As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.MediaMarketBreak)
        Public Overridable Property NCCTVAIUEs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVAIUE)
        Public Overridable Property NCCTVAIUELogs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVAIUELog)
        Public Overridable Property NCCTVAIUELogRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVAIUELogRevision)
        Public Overridable Property NCCTVCablenets As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVCablenet)
        Public Overridable Property NCCTVCarriageUEs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVCarriageUE)
        Public Overridable Property NCCTVCarriageUELogs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVCarriageUELog)
        Public Overridable Property NCCTVCarriageUELogRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVCarriageUELogRevision)
        Public Overridable Property NCCTVFusionAudiences As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVFusionAudience)
        Public Overridable Property NCCTVFusionHutputs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVFusionHutput)
        Public Overridable Property NCCTVFusionUniverses As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVFusionUniverse)
        Public Overridable Property NCCTVFusionUniverseRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVFusionUniverseRevision)
        Public Overridable Property NCCTVLPMMarkets As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVLPMMarket)
        Public Overridable Property NCCTVMVPDs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVMVPD)
        Public Overridable Property NCCTVSyscodes As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NCCTVSyscode)
        Public Overridable Property NielsenMarkets As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenMarket)
        Public Overridable Property NielsenRadioAudiences As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioAudience)
        Public Overridable Property NielsenRadioCountyAudiences As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyAudience)
        Public Overridable Property NielsenRadioCountyClusters As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyCluster)
        Public Overridable Property NielsenRadioCountyIntabs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyIntab)
        Public Overridable Property NielsenRadioCountyPeriods As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)
        Public Overridable Property NielsenRadioCountyStations As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
        Public Overridable Property NielsenRadioCountyUniverses As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioCountyUniverse)
        Public Overridable Property NielsenRadioDayparts As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioDaypart)
        Public Overridable Property NielsenRadioDemographics As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioDemographic)
        Public Overridable Property NielsenRadioFormats As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioFormat)
        Public Overridable Property NielsenRadioIntabs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioIntab)
        Public Overridable Property NielsenRadioMarkets As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioMarket)
        Public Overridable Property NielsenRadioPeriods As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioPeriod)
        Public Overridable Property NielsenRadioPeriodRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioPeriodRevision)
        Public Overridable Property NielsenRadioPurs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioPur)
        Public Overridable Property NielsenRadioQualitatives As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioQualitative)
        Public Overridable Property NielsenRadioReportTypes As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioReportType)
        Public Overridable Property NielsenRadioSegmentChilds As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioSegmentChild)
        Public Overridable Property NielsenRadioSegmentParents As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioSegmentParent)
        Public Overridable Property NielsenRadioStations As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioStation)
        Public Overridable Property NielsenRadioStationHistorys As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioStationHistory)
        Public Overridable Property NielsenRadioUniverses As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioUniverse)
        Public Overridable Property NielsenRadioVStagings As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenRadioVStaging)
        Public Overridable Property NielsenTVAudiences As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVAudience)
        Public Overridable Property NielsenTVBooks As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVBook)
        Public Overridable Property NielsenTVBookRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVBookRevision)
        Public Overridable Property NielsenTVCumeBooks As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVCumeBook)
        Public Overridable Property NielsenTVCumeBookRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVCumeBookRevision)
        Public Overridable Property NielsenTVCumeDaypartImpressions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)
        Public Overridable Property NielsenTVDayparts As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVDaypart)
        Public Overridable Property NielsenTVHutputs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVHutput)
        Public Overridable Property NielsenTVIntabs As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVIntab)
        Public Overridable Property NielsenTVProgramBooks As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVProgramBook)
        Public Overridable Property NielsenTVProgramBookRevisions As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVProgramBookRevision)
        Public Overridable Property NielsenTVPrograms As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVProgram)
        Public Overridable Property NielsenTVStations As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVStation)
        Public Overridable Property NielsenTVStationHistorys As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVStationHistory)
        Public Overridable Property NielsenTVUniverses As System.Data.Entity.DbSet(Of Nielsen.Database.Entities.NielsenTVUniverse)

#End Region

        <System.Obsolete>
        Public Sub New()

            MyBase.New("Data Source=TASC-CODE\TFS;Initial Catalog=ADV67000;Persist Security Info=True;User ID=SYSADM;Password=sysadm;MultipleActiveResultSets=True;APP=EntityFramework")

        End Sub
        <System.Obsolete>
        Public Sub New(ConnectionString As String)

            MyBase.New(ConnectionString)

        End Sub
        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            MyBase.New(ConnectionString, UserCode, AdvantageFramework.Database.Methods.DatabaseTypes.Nielsen)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Security.Database.DbContext)(Nothing)

        End Sub
        Public Sub New(ByVal SqlConnection As SqlClient.SqlConnection)

            MyBase.New(SqlConnection.ConnectionString, Nothing, AdvantageFramework.Database.Methods.DatabaseTypes.Nielsen)

            System.Data.Entity.Database.SetInitializer(Of AdvantageFramework.Security.Database.DbContext)(Nothing)

        End Sub
        Protected Overrides Sub OnModelCreating(modelBuilder As System.Data.Entity.DbModelBuilder)

            MyBase.OnModelCreating(modelBuilder)

        End Sub

    End Class

End Namespace