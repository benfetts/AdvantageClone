Namespace Security.Database.Procedures.ApplicationModule

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ApplicationModule)

            Load = From ApplicationModule In DbContext.GetQuery(Of Database.Entities.ApplicationModule)
                   Select ApplicationModule

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal ModuleID As Integer, _
                               ByRef ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ApplicationModule = New AdvantageFramework.Security.Database.Entities.ApplicationModule

                ApplicationModule.DbContext = DbContext
                ApplicationModule.ApplicationID = ApplicationID
                ApplicationModule.ModuleID = ModuleID

                Inserted = Insert(DbContext, ApplicationModule)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ApplicationModules.Add(ApplicationModule)

                ErrorText = ApplicationModule.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ApplicationModule)

                ErrorText = ApplicationModule.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ApplicationModule)

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
