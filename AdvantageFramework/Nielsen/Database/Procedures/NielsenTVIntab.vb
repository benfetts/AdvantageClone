Namespace Nielsen.Database.Procedures.NielsenTVIntab

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

        Public Function GetMaxIDByNielsenTVBookID(DbContext As Nielsen.Database.DbContext, NielsenTVBookID As Integer) As Long

            Try

                GetMaxIDByNielsenTVBookID = (From NielsenTVIntab In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVIntab)
                                             Where NielsenTVIntab.NielsenTVBookID = NielsenTVBookID
                                             Select NielsenTVIntab.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenTVBookID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVIntab)

            Load = From NielsenTVIntab In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVIntab)
                   Select NielsenTVIntab

        End Function

#End Region

    End Module

End Namespace
