Namespace Nielsen.Database.Procedures.NielsenTVProgram

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

        Public Function GetMaxIDByNielsenTVProgramBookID(DbContext As Nielsen.Database.DbContext, NielsenTVProgramBookID As Integer) As Long

            Try

                GetMaxIDByNielsenTVProgramBookID = (From NielsenTVProgram In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgram)
                                                    Where NielsenTVProgram.NielsenTVProgramBookID = NielsenTVProgramBookID
                                                    Select NielsenTVProgram.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenTVProgramBookID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVProgram)

            Load = From NielsenTVProgram In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVProgram)
                   Select NielsenTVProgram

        End Function

#End Region

    End Module

End Namespace
