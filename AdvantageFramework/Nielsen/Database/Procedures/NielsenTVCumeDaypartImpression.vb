Namespace Nielsen.Database.Procedures.NielsenTVCumeDaypartImpression

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

        Public Function GetMaxIDByNielsenTVCumeBookID(DbContext As Nielsen.Database.DbContext, NielsenTVCumeBookID As Integer) As Long

            Try

                GetMaxIDByNielsenTVCumeBookID = (From NielsenTVCumeDaypartImpression In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)
                                                 Where NielsenTVCumeDaypartImpression.NielsenTVCumeBookID = NielsenTVCumeBookID
                                                 Select NielsenTVCumeDaypartImpression.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenTVCumeBookID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)

            Load = From NielsenTVCumeDaypartImpression In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenTVCumeDaypartImpression)
                   Select NielsenTVCumeDaypartImpression

        End Function

#End Region

    End Module

End Namespace
