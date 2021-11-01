Namespace Database.Procedures.MyObjectDefinitionStaticOption

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MyObjectDefinitionStaticOption)

            Load = From MyObjectDefinitionStaticOption In DbContext.GetQuery(Of Database.Entities.MyObjectDefinitionStaticOption)
                   Select MyObjectDefinitionStaticOption

        End Function

#End Region

    End Module

End Namespace
