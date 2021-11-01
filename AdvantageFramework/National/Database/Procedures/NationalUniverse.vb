Namespace National.Database.Procedures.NationalUniverse

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

        Public Function Load(DbContext As National.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of National.Database.Entities.NationalUniverse)

            Load = From NationalUniverse In DbContext.GetQuery(Of National.Database.Entities.NationalUniverse)
                   Select NationalUniverse

        End Function

#End Region

    End Module

End Namespace
