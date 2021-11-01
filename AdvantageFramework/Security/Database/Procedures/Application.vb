Namespace Security.Database.Procedures.Application

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

        Public Function LoadByApplicationID(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer) As Security.Database.Entities.Application

            Try

                LoadByApplicationID = (From Application In DbContext.GetQuery(Of Database.Entities.Application)
                                       Where Application.ID = ApplicationID
                                       Select Application).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Application)

            Load = From Application In DbContext.GetQuery(Of Database.Entities.Application)
                   Select Application

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Name As String, ByVal Description As String, _
                               ByRef Application As AdvantageFramework.Security.Database.Entities.Application) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                Application = New AdvantageFramework.Security.Database.Entities.Application

                Application.DbContext = DbContext
                Application.Name = Name
                Application.Description = Description

                Inserted = Insert(DbContext, Application)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Application As AdvantageFramework.Security.Database.Entities.Application) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Applications.Add(Application)

                ErrorText = Application.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Application As AdvantageFramework.Security.Database.Entities.Application) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Application)

                ErrorText = Application.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal Application As AdvantageFramework.Security.Database.Entities.Application) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule = Nothing
            Dim GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess = Nothing
            Dim UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess = Nothing

            Try

                If IsValid Then

                    For Each ApplicationModule In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.ApplicationModule).Where(Function(AppMod) AppMod.ApplicationID = Application.ID)

                        AdvantageFramework.Security.Database.Procedures.ApplicationModule.Delete(DbContext, ApplicationModule)

                    Next

                    For Each GroupApplicationAccess In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupApplicationAccess).Where(Function(GrpAppAccess) GrpAppAccess.ApplicationID = Application.ID)

                        AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.Delete(DbContext, GroupApplicationAccess)

                    Next

                    For Each UserApplicationAccess In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserApplicationAccess).Where(Function(UsrAppAccess) UsrAppAccess.ApplicationID = Application.ID)

                        AdvantageFramework.Security.Database.Procedures.UserApplicationAccess.Delete(DbContext, UserApplicationAccess)

                    Next

                    DbContext.DeleteEntityObject(Application)

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
