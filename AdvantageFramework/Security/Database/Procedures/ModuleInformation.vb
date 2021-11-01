Namespace Security.Database.Procedures.ModuleInformation

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

        Public Function LoadByApplicationCode(ByVal DbContext As Database.DbContext, ByVal ApplicationCode As String) As Security.Database.Entities.ModuleInformation

            Try

                LoadByApplicationCode = (From ModuleInformation In DbContext.GetQuery(Of Database.Entities.ModuleInformation)
                                         Where ModuleInformation.ApplicationCode = ApplicationCode
                                         Select ModuleInformation).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ModuleInformation)

            Load = From ModuleInformation In DbContext.GetQuery(Of Database.Entities.ModuleInformation)
                   Select ModuleInformation

        End Function

#End Region

    End Module

End Namespace
