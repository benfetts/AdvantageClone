Namespace Nielsen.Database.Procedures.NielsenTVProgramBook

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

                GetMaxID = (From NielsenTVProgramBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgramBook)
                            Select NielsenTVProgramBook.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenTVProgramBook

            Try

                LoadByID = (From NielsenTVProgramBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgramBook)
                            Where NielsenTVProgramBook.ID = ID
                            Select NielsenTVProgramBook).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        'Public Function LoadByBookIDs(DbContext As Database.DbContext, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVProgramBook)

        '    LoadByBookIDs = From NielsenTVProgramBook In DbContext.GetQuery(Of Database.Entities.NielsenTVProgramBook)
        '                    Where BookIDs.Contains(NielsenTVProgramBook.ID)
        '                    Select NielsenTVProgramBook

        'End Function
        'Public Function LoadValidatedByNielsenMarketNumberAndBookIDs(DbContext As Database.DbContext, NielsenMarketNumber As Integer, BookIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVProgramBook)

        '    LoadValidatedByNielsenMarketNumberAndBookIDs = From NielsenTVProgramBook In DbContext.GetQuery(Of Database.Entities.NielsenTVProgramBook)
        '                                                   Where NielsenTVProgramBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
        '                                                         BookIDs.Contains(NielsenTVProgramBook.ID) AndAlso
        '                                                         NielsenTVProgramBook.Validated = True
        '                                                   Select NielsenTVProgramBook

        'End Function
        'Public Function LoadValidatedByNielsenMarketNumber(DbContext As Database.DbContext, NielsenMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenTVProgramBook)

        '    LoadValidatedByNielsenMarketNumber = From NielsenTVProgramBook In DbContext.GetQuery(Of Database.Entities.NielsenTVProgramBook)
        '                                         Where NielsenTVProgramBook.NielsenMarketNumber = NielsenMarketNumber AndAlso
        '                                               NielsenTVProgramBook.Validated = True
        '                                         Select NielsenTVProgramBook

        'End Function
        'Public Function GetValidatedCount(DbContext As Nielsen.Database.DbContext) As Integer

        '    GetValidatedCount = (From NielsenTVProgramBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgramBook)
        '                         Where NielsenTVProgramBook.Validated = True
        '                         Select NielsenTVProgramBook).Count

        'End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVProgramBook)

            Load = From NielsenTVProgramBook In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgramBook)
                   Select NielsenTVProgramBook

        End Function

#End Region

    End Module

End Namespace
