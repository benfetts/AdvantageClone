Namespace Security.Database.Procedures.[Module]

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

        Public Function LoadByModuleCode(ByVal DbContext As Database.DbContext, ByVal ModuleCode As String) As Security.Database.Entities.Module

            Try

                LoadByModuleCode = (From ModuleView In DbContext.GetQuery(Of Database.Entities.Module)
                                    Where ModuleView.Code = ModuleCode
                                    Select ModuleView).SingleOrDefault

            Catch ex As Exception
                LoadByModuleCode = Nothing
            End Try

        End Function
        Public Function LoadByModuleID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer) As Security.Database.Entities.Module

            Try

                LoadByModuleID = (From [Module] In DbContext.GetQuery(Of Database.Entities.Module)
                                  Where [Module].ID = ModuleID
                                  Select [Module]).SingleOrDefault

            Catch ex As Exception
                LoadByModuleID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.[Module])

            Load = From [Module] In DbContext.GetQuery(Of Database.Entities.Module)
                   Select [Module]

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Code As String, ByVal Description As String, _
                               ByVal IsInactive As Boolean, ByVal IsMenuItem As Boolean, ByVal IsCategory As Boolean, ByVal IsApplication As Boolean, _
                               ByVal IsReport As Boolean, ByVal IsDesktopObject As Boolean, ByVal IsDashQuery As Boolean, _
                               ByRef [Module] As AdvantageFramework.Security.Database.Entities.[Module]) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                [Module] = New AdvantageFramework.Security.Database.Entities.[Module]

                [Module].DbContext = DbContext
                [Module].Code = Code
                [Module].Description = Description
                [Module].IsInactive = IsInactive
                [Module].IsMenuItem = IsMenuItem
                [Module].IsCategory = IsCategory
                [Module].IsApplication = IsApplication
                [Module].IsReport = IsReport
                [Module].IsDesktopObject = IsDesktopObject
                [Module].IsDashQuery = IsDashQuery

                Inserted = Insert(DbContext, [Module])

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal [Module] As AdvantageFramework.Security.Database.Entities.[Module]) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Modules.Add([Module])

                ErrorText = [Module].ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal [Module] As AdvantageFramework.Security.Database.Entities.[Module]) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject([Module])

                ErrorText = [Module].ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal [Module] As AdvantageFramework.Security.Database.Entities.[Module]) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing

            Try

                If IsValid Then

                    For Each GroupModuleAccess In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess).Where(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ID)

                        AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.Delete(DbContext, GroupModuleAccess)

                    Next

                    For Each UserModuleAccess In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess).Where(Function(UserModAccess) UserModAccess.ModuleID = [Module].ID)

                        AdvantageFramework.Security.Database.Procedures.UserModuleAccess.Delete(DbContext, UserModuleAccess)

                    Next

                    DbContext.DeleteEntityObject([Module])

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
