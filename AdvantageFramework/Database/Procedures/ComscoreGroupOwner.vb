Namespace Database.Procedures.ComscoreGroupOwner

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreGroupOwner)

            Load = From ComscoreGroupOwner In DbContext.GetQuery(Of Database.Entities.ComscoreGroupOwner)
                   Select ComscoreGroupOwner

        End Function

#End Region

    End Module

End Namespace
