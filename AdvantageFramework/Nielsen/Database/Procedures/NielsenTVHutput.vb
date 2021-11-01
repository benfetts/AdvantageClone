Namespace Nielsen.Database.Procedures.NielsenTVHutput

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

                GetMaxIDByNielsenTVBookID = (From NielsenTVHutput In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVHutput)
                                             Where NielsenTVHutput.NielsenTVBookID = NielsenTVBookID
                                             Select NielsenTVHutput.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenTVBookID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVHutput)

            Load = From NielsenTVHutput In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVHutput)
                   Select NielsenTVHutput

        End Function

#End Region

    End Module

End Namespace
