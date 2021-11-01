Namespace Security.Database.Procedures.UserPermissionsReportView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.UserPermissionsReport)

            Load = From UserPermissionsReport In DbContext.GetQuery(Of Database.Views.UserPermissionsReport)
                   Select UserPermissionsReport

        End Function

#End Region

    End Module

End Namespace
