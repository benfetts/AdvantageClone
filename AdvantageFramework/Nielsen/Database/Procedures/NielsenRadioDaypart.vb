Namespace Nielsen.Database.Procedures.NielsenRadioDaypart

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

                GetMaxID = (From NielsenRadioDaypart In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)
                            Select NielsenRadioDaypart.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function LoadByNielsenDaypartID(DbContext As Nielsen.Database.DbContext, NielsenDaypartID As Short) As Nielsen.Database.Entities.NielsenRadioDaypart

            LoadByNielsenDaypartID = (From NielsenRadioDaypart In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)
                                      Where NielsenRadioDaypart.NielsenDaypartID = NielsenDaypartID
                                      Select NielsenRadioDaypart).SingleOrDefault

        End Function
        Public Function LoadExcludeNielsenDaypartIDs(DbContext As Nielsen.Database.DbContext, ExcludeNielsenDaypartIDs As Generic.List(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)

            LoadExcludeNielsenDaypartIDs = From NielsenRadioDaypart In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)
                                           Where ExcludeNielsenDaypartIDs.Contains(NielsenRadioDaypart.ID) = False
                                           Select NielsenRadioDaypart

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)

            Load = From NielsenRadioDaypart In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioDaypart)
                   Select NielsenRadioDaypart

        End Function

#End Region

    End Module

End Namespace
