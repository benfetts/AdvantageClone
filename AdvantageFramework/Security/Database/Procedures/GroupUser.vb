Namespace Security.Database.Procedures.GroupUser

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

        Public Function LoadByGroupIDAndUserID(ByVal DbContext As Database.DbContext, ByVal GroupID As Integer, ByVal UserID As Integer) As Security.Database.Entities.GroupUser

            Try

                LoadByGroupIDAndUserID = (From GroupUser In DbContext.GetQuery(Of Database.Entities.GroupUser)
                                          Where GroupUser.GroupID = GroupID AndAlso
                                                GroupUser.UserID = UserID
                                          Select GroupUser).SingleOrDefault

            Catch ex As Exception
                LoadByGroupIDAndUserID = Nothing
            End Try

        End Function
        Public Function LoadByGroupID(ByVal DbContext As Database.DbContext, ByVal GroupID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupUser)

            LoadByGroupID = From GroupUser In DbContext.GetQuery(Of Database.Entities.GroupUser)
                            Where GroupUser.GroupID = GroupID
                            Select GroupUser

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupUser)

            LoadByUserID = From GroupUser In DbContext.GetQuery(Of Database.Entities.GroupUser)
                           Where GroupUser.UserID = UserID
                           Select GroupUser

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.GroupUser)

            Load = From GroupUser In DbContext.GetQuery(Of Database.Entities.GroupUser)
                   Select GroupUser

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer, ByVal UserID As Integer, _
                               ByRef GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                GroupUser = New AdvantageFramework.Security.Database.Entities.GroupUser

                GroupUser.DbContext = DbContext
                GroupUser.GroupID = GroupID
                GroupUser.UserID = UserID

                Inserted = Insert(DbContext, GroupUser)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.GroupUsers.Add(GroupUser)

                ErrorText = GroupUser.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GroupUser)

                ErrorText = GroupUser.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(GroupUser)

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
        Public Function DeleteByGroupID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal GroupID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_USER WHERE SEC_GROUP_ID = " & GroupID)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByGroupID = Deleted
            End Try

        End Function
        Public Function DeleteByUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_GROUP_USER WHERE SEC_USER_ID = " & UserID)

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
