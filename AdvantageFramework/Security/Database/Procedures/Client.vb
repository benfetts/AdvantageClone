Namespace Security.Database.Procedures.Client

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Client)

            Load = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                   Select Client

        End Function

#End Region

    End Module

End Namespace
