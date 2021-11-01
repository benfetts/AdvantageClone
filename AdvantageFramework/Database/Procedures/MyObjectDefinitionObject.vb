Namespace Database.Procedures.MyObjectDefinitionObject

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

        Public Function LoadByType(ByVal DbContext As Database.DbContext, ByVal MyObjectDefinitionObjectType As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MyObjectDefinitionObject)

            LoadByType = From MyObjectDefinitionObject In DbContext.GetQuery(Of Database.Entities.MyObjectDefinitionObject)
                         Where MyObjectDefinitionObject.Type = MyObjectDefinitionObjectType
                         Select MyObjectDefinitionObject

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MyObjectDefinitionObject)

            Load = From MyObjectDefinitionObject In DbContext.GetQuery(Of Database.Entities.MyObjectDefinitionObject)
                   Select MyObjectDefinitionObject

        End Function

#End Region

    End Module

End Namespace
