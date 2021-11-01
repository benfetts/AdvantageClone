Namespace Security.Database.Procedures.GroupPermissionsReportView

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.GroupPermissionsReport)

            Load = From GroupPermissionsReport In DbContext.GetQuery(Of Database.Views.GroupPermissionsReport)
                   Select GroupPermissionsReport

        End Function

#End Region

    End Module

End Namespace
