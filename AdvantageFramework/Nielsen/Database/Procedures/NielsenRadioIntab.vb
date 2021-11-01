Namespace Nielsen.Database.Procedures.NielsenRadioIntab

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

                GetMaxIDBySegmentParentIDs = (From NielsenRadioIntab In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioIntab)
                                              Where SegmentParentIDs.Contains(NielsenRadioIntab.SegmentParentID)
                                              Select NielsenRadioIntab.ID).Max

            Catch ex As Exception
                GetMaxIDBySegmentParentIDs = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioIntab)

            Load = From NielsenRadioIntab In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioIntab)
                   Select NielsenRadioIntab

        End Function

#End Region

    End Module

End Namespace
