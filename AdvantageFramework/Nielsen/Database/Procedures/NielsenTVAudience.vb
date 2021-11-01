Namespace Nielsen.Database.Procedures.NielsenTVAudience

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

            GetMaxIDByNielsenTVBookID = DbContext.Database.SqlQuery(Of Long)(String.Format("SELECT COALESCE(MAX(NIELSEN_TV_AUDIENCE_ID),0) FROM dbo.NIELSEN_TV_AUDIENCE WITH (FORCESEEK, INDEX(NIELSEN_TV_AUDIENCE_UNIQUE)) WHERE NIELSEN_TV_BOOK_ID = {0}", NielsenTVBookID)).First

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVAudience)

            Load = From NielsenTVAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVAudience)
                   Select NielsenTVAudience

        End Function

#End Region

    End Module

End Namespace
