Namespace Security.Database.Procedures.ApplicationSetting

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ApplicationSetting)

            Load = From ApplicationSetting In DbContext.GetQuery(Of Database.Entities.ApplicationSetting)
                   Select ApplicationSetting

        End Function

#End Region

    End Module

End Namespace
