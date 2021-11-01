Namespace Security.Database.Procedures.GroupPermissionView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.GroupPermission)

            Load = From GroupPermission In DbContext.GetQuery(Of Database.Views.GroupPermission)
                   Select GroupPermission

        End Function

#End Region

    End Module

End Namespace
