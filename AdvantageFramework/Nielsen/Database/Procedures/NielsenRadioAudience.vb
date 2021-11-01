Namespace Nielsen.Database.Procedures.NielsenRadioAudience

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

                GetMaxIDBySegmentParentIDs = (From NielsenRadioAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioAudience)
                                              Where SegmentParentIDs.Contains(NielsenRadioAudience.SegmentParentID)
                                              Select NielsenRadioAudience.ID).Max

            Catch ex As Exception
                GetMaxIDBySegmentParentIDs = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioAudience)

            Load = From NielsenRadioAudience In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioAudience)
                   Select NielsenRadioAudience

        End Function

#End Region

    End Module

End Namespace
