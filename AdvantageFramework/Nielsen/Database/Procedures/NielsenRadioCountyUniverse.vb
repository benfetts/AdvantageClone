Namespace Nielsen.Database.Procedures.NielsenRadioCountyUniverse

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

        Public Function GetMaxIDByNielsenRadioCountyPeriodID(DbContext As Nielsen.Database.DbContext, NielsenRadioCountyPeriodID As Integer) As Long

            Try

                GetMaxIDByNielsenRadioCountyPeriodID = (From NielsenRadioCountyUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyUniverse)
                                                        Where NielsenRadioCountyUniverse.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriodID
                                                        Select NielsenRadioCountyUniverse.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenRadioCountyPeriodID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyUniverse)

            Load = From NielsenRadioCountyUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyUniverse)
                   Select NielsenRadioCountyUniverse

        End Function

#End Region

    End Module

End Namespace
