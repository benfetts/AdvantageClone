Namespace Security.Database.Procedures.UserModuleAccess

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

        Public Function LoadByModuleIDAndUserID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer, ByVal UserID As Integer) As Security.Database.Entities.UserModuleAccess

            Try

                LoadByModuleIDAndUserID = (From UserModuleAccess In DbContext.GetQuery(Of Database.Entities.UserModuleAccess)
                                           Where UserModuleAccess.UserID = UserID AndAlso
                                                 UserModuleAccess.ModuleID = ModuleID
                                           Select UserModuleAccess).SingleOrDefault

            Catch ex As Exception
                LoadByModuleIDAndUserID = Nothing
            End Try

        End Function
        Public Function LoadByModuleID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserModuleAccess)

            LoadByModuleID = From UserModuleAccess In DbContext.GetQuery(Of Database.Entities.UserModuleAccess)
                             Where UserModuleAccess.ModuleID = ModuleID
                             Select UserModuleAccess

        End Function
        Public Function LoadByUserIDs(ByVal DbContext As Database.DbContext, ByVal UserIDs() As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserModuleAccess)

            LoadByUserIDs = From UserModuleAccess In DbContext.GetQuery(Of Database.Entities.UserModuleAccess)
                            Where UserIDs.Contains(UserModuleAccess.UserID)
                            Select UserModuleAccess

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserModuleAccess)

            LoadByUserID = From UserModuleAccess In DbContext.GetQuery(Of Database.Entities.UserModuleAccess)
                           Where UserModuleAccess.UserID = UserID
                           Select UserModuleAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserModuleAccess)

            Load = From UserModuleAccess In DbContext.GetQuery(Of Database.Entities.UserModuleAccess)
                   Select UserModuleAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, ByVal ModuleID As Integer, _
                               ByVal IsBlocked As Boolean, ByVal CanAdd As Boolean, ByVal CanPrint As Boolean, _
                               ByVal CanUpdate As Boolean, ByVal Custom1 As Boolean, ByVal Custom2 As Boolean, _
                               ByRef UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserModuleAccess = New AdvantageFramework.Security.Database.Entities.UserModuleAccess

                UserModuleAccess.DbContext = DbContext
                UserModuleAccess.UserID = UserID
                UserModuleAccess.ModuleID = ModuleID
                UserModuleAccess.IsBlocked = IsBlocked
                UserModuleAccess.CanAdd = CanAdd
                UserModuleAccess.CanPrint = CanPrint
                UserModuleAccess.CanUpdate = CanUpdate
                UserModuleAccess.Custom1 = Custom1
                UserModuleAccess.Custom2 = Custom2

                Inserted = Insert(DbContext, UserModuleAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserModuleAccesses.Add(UserModuleAccess)

                ErrorText = UserModuleAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserModuleAccess)

                ErrorText = UserModuleAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserModuleAccess)

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
        Public Function DeleteByUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_MODACCESS WHERE SEC_USER_ID = " & UserID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByUserID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
