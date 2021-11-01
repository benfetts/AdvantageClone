Namespace Security.Database.Procedures.ModuleView

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

        Public Function LoadByModuleCode(ByVal DbContext As Database.DbContext, ByVal ModuleCode As String) As Security.Database.Views.ModuleView

            Try

                LoadByModuleCode = (From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                    Where ModuleView.ModuleCode = ModuleCode
                                    Select ModuleView).FirstOrDefault

            Catch ex As Exception
                LoadByModuleCode = Nothing
            End Try

        End Function
        Public Function LoadByModuleID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer) As Security.Database.Views.ModuleView

            Try

                LoadByModuleID = (From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                  Where ModuleView.ModuleID = ModuleID
                                  Select ModuleView).FirstOrDefault

            Catch ex As Exception
                LoadByModuleID = Nothing
            End Try

        End Function
        Public Function LoadActiveModulesByModuleID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer) As Security.Database.Views.ModuleView

            Try

                LoadActiveModulesByModuleID = (From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                               Where ModuleView.ModuleID = ModuleID AndAlso
                                                     ModuleView.IsInactive = False
                                               Select ModuleView).FirstOrDefault

            Catch ex As Exception
                LoadActiveModulesByModuleID = Nothing
            End Try

        End Function
        Public Function LoadActiveModulesByApplicationID(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ModuleView)

            LoadActiveModulesByApplicationID = From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                               Where ModuleView.ApplicationID = ApplicationID AndAlso
                                                     ModuleView.IsInactive = False
                                               Select ModuleView

        End Function
        Public Function LoadByApplicationID(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ModuleView)

            LoadByApplicationID = From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                  Where ModuleView.ApplicationID = ApplicationID
                                  Select ModuleView

        End Function
        Public Function LoadActiveModules(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ModuleView)

            LoadActiveModules = From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                                Where ModuleView.IsInactive = False
                                Select ModuleView

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.ModuleView)

            Load = From ModuleView In DbContext.GetQuery(Of Database.Views.ModuleView)
                   Select ModuleView

        End Function

#End Region

    End Module

End Namespace
