Namespace Nielsen.Database.Procedures.NCCTVMVPD

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Long

            If (From NCCTVMVPD In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVMVPD)
                Select NCCTVMVPD.ID).Any Then

                GetMaxID = (From NCCTVMVPD In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVMVPD)
                            Select NCCTVMVPD.ID).Max

            Else

                GetMaxID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVMVPD)

            Load = From NCCTVMVPD In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVMVPD)
                   Select NCCTVMVPD

        End Function

#End Region

    End Module

End Namespace
