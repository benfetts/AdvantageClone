Namespace Nielsen.Database.Procedures.NielsenRadioDemographic

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

                GetMaxID = (From NielsenRadioDemographic In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDemographic)
                            Select NielsenRadioDemographic.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioDemographic)

            Load = From NielsenRadioDemographic In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDemographic)
                   Select NielsenRadioDemographic

        End Function

#End Region

    End Module

End Namespace
