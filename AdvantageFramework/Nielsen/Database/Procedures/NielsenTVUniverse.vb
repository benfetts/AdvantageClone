Namespace Nielsen.Database.Procedures.NielsenTVUniverse

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext, NielsenMarketNumber As Integer, Year As Short, Month As Short) As Long

            Try

                GetMaxID = (From NielsenTVUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVUniverse)
                            Where NielsenTVUniverse.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                  NielsenTVUniverse.Year = Year AndAlso
                                  NielsenTVUniverse.Month = Month
                            Select NielsenTVUniverse.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function GetUniverse(DbContext As Nielsen.Database.DbContext, NielsenMarketNumber As Integer, Year As Short, Month As Short, ReportingService As String, Exclusion As String, Ethnicity As String) As Nielsen.Database.Entities.NielsenTVUniverse

            GetUniverse = (From NielsenTVUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVUniverse)
                           Where NielsenTVUniverse.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                 NielsenTVUniverse.Year = Year AndAlso
                                 NielsenTVUniverse.Month = Month AndAlso
                                 NielsenTVUniverse.ReportingService = ReportingService AndAlso
                                 NielsenTVUniverse.Exclusion = Exclusion AndAlso
                                 NielsenTVUniverse.Ethnicity = Ethnicity
                           Select NielsenTVUniverse).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVUniverse)

            Load = From NielsenTVUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVUniverse)
                   Select NielsenTVUniverse

        End Function

#End Region

    End Module

End Namespace
