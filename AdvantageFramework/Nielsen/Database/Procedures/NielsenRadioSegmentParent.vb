Namespace Nielsen.Database.Procedures.NielsenRadioSegmentParent

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

        Public Function GetMaxIDByNielsenRadioPeriodID(DbContext As Nielsen.Database.DbContext, NielsenRadioPeriodID As Integer) As Integer

            Try

                GetMaxIDByNielsenRadioPeriodID = (From NielsenRadioSegmentParent In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentParent)
                                                  Where NielsenRadioSegmentParent.NielsenRadioPeriodID = NielsenRadioPeriodID
                                                  Select NielsenRadioSegmentParent.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenRadioPeriodID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentParent)

            Load = From NielsenRadioSegmentParent In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentParent)
                   Select NielsenRadioSegmentParent

        End Function

#End Region

    End Module

End Namespace
