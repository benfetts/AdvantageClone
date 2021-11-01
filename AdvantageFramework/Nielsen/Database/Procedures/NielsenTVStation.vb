Namespace Nielsen.Database.Procedures.NielsenTVStation

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

                GetMaxIDByNielsenMarketNumber = (From NielsenTVStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStation)
                                                 Where NielsenTVStation.NielsenMarketNumber = NielsenMarketNumber
                                                 Select NielsenTVStation.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenMarketNumber = 0
            End Try

        End Function
        Public Function LoadByNielsenMarketNumber(DbContext As Nielsen.Database.DbContext, NielsenMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVStation)

            LoadByNielsenMarketNumber = From NielsenTVStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStation)
                                        Where NielsenTVStation.NielsenMarketNumber = NielsenMarketNumber
                                        Select NielsenTVStation

        End Function
        Public Function LoadByNielsenMarketNumberAndSourceType(DbContext As Nielsen.Database.DbContext, NielsenMarketNumber As Integer, SourceType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVStation)

            LoadByNielsenMarketNumberAndSourceType = From NielsenTVStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStation)
                                                     Where NielsenTVStation.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                           NielsenTVStation.SourceType = SourceType
                                                     Select NielsenTVStation

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenTVStation

            LoadByID = (From NielsenTVStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStation)
                        Where NielsenTVStation.ID = ID
                        Select NielsenTVStation).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVStation)

            Load = From NielsenTVStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVStation)
                   Select NielsenTVStation

        End Function

#End Region

    End Module

End Namespace
