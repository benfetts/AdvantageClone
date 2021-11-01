Namespace Nielsen.Database.Procedures.NielsenRadioUniverse

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

        Public Function GetMaxIDBySegmentParentIDs(DbContext As Nielsen.Database.DbContext, SegmentParentIDs As Generic.List(Of Integer)) As Long

            Try

                GetMaxIDBySegmentParentIDs = (From NielsenRadioUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioUniverse)
                                              Where SegmentParentIDs.Contains(NielsenRadioUniverse.SegmentParentID)
                                              Select NielsenRadioUniverse.ID).Max

            Catch ex As Exception
                GetMaxIDBySegmentParentIDs = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioUniverse)

            Load = From NielsenRadioUniverse In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioUniverse)
                   Select NielsenRadioUniverse

        End Function

#End Region

    End Module

End Namespace
