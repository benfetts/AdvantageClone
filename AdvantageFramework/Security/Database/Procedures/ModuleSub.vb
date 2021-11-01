Namespace Security.Database.Procedures.ModuleSub

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

        Public Function LoadByParentModuleID(ByVal DbContext As Database.DbContext, ByVal ParentModuleID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ModuleSub)

            LoadByParentModuleID = From ModuleSub In DbContext.GetQuery(Of Database.Entities.ModuleSub)
                                   Where ModuleSub.ParentModuleID = ParentModuleID
                                   Select ModuleSub

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ModuleSub)

            Load = From ModuleSub In DbContext.GetQuery(Of Database.Entities.ModuleSub)
                   Select ModuleSub

        End Function

#End Region

    End Module

End Namespace
