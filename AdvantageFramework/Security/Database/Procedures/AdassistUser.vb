Namespace Security.Database.Procedures.AdassistUser

    <HideModuleName()> _
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.AdassistUser)

            Load = From AdassistUser In DbContext.GetQuery(Of Database.Entities.AdassistUser)
                   Select AdassistUser

        End Function

#End Region

    End Module

End Namespace
