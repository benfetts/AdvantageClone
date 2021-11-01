Namespace Database.Procedures.ComscoreCacheDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreCacheDetail)

            Load = From ComscoreCacheDetail In DbContext.GetQuery(Of Database.Entities.ComscoreCacheDetail)
                   Select ComscoreCacheDetail

        End Function

#End Region

    End Module

End Namespace
