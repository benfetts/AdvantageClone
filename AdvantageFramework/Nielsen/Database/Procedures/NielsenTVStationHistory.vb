Namespace Nielsen.Database.Procedures.NielsenTVStationHistory

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

        Public Function GetMaxIDByNielsenMarketNumber(DbContext As Nielsen.Database.DbContext, NielsenMarketNumber As Integer) As Integer

            Try

                GetMaxIDByNielsenMarketNumber = (From NielsenTVStationHistory In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStationHistory)
                                                 Where NielsenTVStationHistory.NielsenMarketNumber = NielsenMarketNumber
                                                 Select NielsenTVStationHistory.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenMarketNumber = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVStationHistory)

            Load = From NielsenTVStationHistory In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStationHistory)
                   Select NielsenTVStationHistory

        End Function

#End Region

    End Module

End Namespace
