Namespace Nielsen.Database.Procedures.NielsenTVCumeBook

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Integer

            Try

                GetMaxID = (From NielsenTVCumeBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeBook)
                            Select NielsenTVCumeBook.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenTVCumeBook

            Try

                LoadByID = (From NielsenTVCumeBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeBook)
                            Where NielsenTVCumeBook.ID = ID
                            Select NielsenTVCumeBook).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function LoadByBookIDs(DbContext As Database.DbContext, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVCumeBook)

            LoadByBookIDs = From NielsenTVCumeBook In DbContext.GetQuery(Of Database.Entities.NielsenTVCumeBook)
                            Where BookIDs.Contains(NielsenTVCumeBook.ID)
                            Select NielsenTVCumeBook

        End Function
        Public Function LoadValidatedByNielsenMarketNumberAndBookIDs(DbContext As Database.DbContext, NielsenMarketNumber As Integer, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVCumeBook)

            LoadValidatedByNielsenMarketNumberAndBookIDs = From NielsenTVCumeBook In DbContext.GetQuery(Of Database.Entities.NielsenTVCumeBook)
                                                           Where NielsenTVCumeBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                                 BookIDs.Contains(NielsenTVCumeBook.ID) AndAlso
                                                                 NielsenTVCumeBook.Validated = True
                                                           Select NielsenTVCumeBook

        End Function
        Public Function LoadValidatedByNielsenMarketNumber(DbContext As Database.DbContext, NielsenMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVCumeBook)

            LoadValidatedByNielsenMarketNumber = From NielsenTVCumeBook In DbContext.GetQuery(Of Database.Entities.NielsenTVCumeBook)
                                                 Where NielsenTVCumeBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                       NielsenTVCumeBook.Validated = True
                                                 Select NielsenTVCumeBook

        End Function
        Public Function GetValidatedCount(DbContext As Nielsen.Database.DbContext) As Integer

            GetValidatedCount = (From NielsenTVCumeBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeBook)
                                 Where NielsenTVCumeBook.Validated = True
                                 Select NielsenTVCumeBook).Count

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVCumeBook)

            Load = From NielsenTVCumeBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeBook)
                   Select NielsenTVCumeBook

        End Function

#End Region

    End Module

End Namespace
