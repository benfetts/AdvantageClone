Namespace Security.Database.Procedures.UserMenu

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

        Public Function LoadByUserIDAndModuleIDAndMenuTypeAndOrder(ByVal DbContext As Database.DbContext, ByVal UserID As Integer, _
                                                                   ByVal ModuleID As Integer, ByVal MenuType As Integer, _
                                                                   ByVal Order As Integer) As Security.Database.Entities.UserMenu

            Try

                LoadByUserIDAndModuleIDAndMenuTypeAndOrder = (From UserMenu In DbContext.GetQuery(Of Database.Entities.UserMenu)
                                                              Where UserMenu.UserID = UserID AndAlso
                                                                    UserMenu.ModuleID = ModuleID AndAlso
                                                                    UserMenu.MenuType = MenuType AndAlso
                                                                    UserMenu.Order = Order
                                                              Select UserMenu).SingleOrDefault

            Catch ex As Exception
                LoadByUserIDAndModuleIDAndMenuTypeAndOrder = Nothing
            End Try

        End Function
        Public Function LoadByUserMenuID(ByVal DbContext As Database.DbContext, ByVal UserMenuID As Integer) As Security.Database.Entities.UserMenu

            Try

                LoadByUserMenuID = (From UserMenu In DbContext.GetQuery(Of Database.Entities.UserMenu)
                                    Where UserMenu.ID = UserMenuID
                                    Select UserMenu).SingleOrDefault

            Catch ex As Exception
                LoadByUserMenuID = Nothing
            End Try

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserMenu)

            LoadByUserID = From UserMenu In DbContext.GetQuery(Of Database.Entities.UserMenu)
                           Where UserMenu.UserID = UserID
                           Select UserMenu

        End Function
        Public Function LoadByUserIDAndMenuType(ByVal DbContext As Database.DbContext, ByVal UserID As Integer, ByVal MenuType As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserMenu)

            LoadByUserIDAndMenuType = From UserMenu In DbContext.GetQuery(Of Database.Entities.UserMenu)
                                      Where UserMenu.UserID = UserID AndAlso
                                            UserMenu.MenuType = MenuType
                                      Select UserMenu

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserMenu)

            Load = From UserMenu In DbContext.GetQuery(Of Database.Entities.UserMenu)
                   Select UserMenu

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, ByVal ModuleID As Integer, _
                               ByVal MenuType As Integer, ByVal Order As Integer, ByVal UserMenuTabID As System.Nullable(Of Integer), _
                               ByRef UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserMenu = New AdvantageFramework.Security.Database.Entities.UserMenu

                UserMenu.DbContext = DbContext
                UserMenu.UserID = UserID
                UserMenu.ModuleID = ModuleID
                UserMenu.MenuType = MenuType
                UserMenu.Order = Order
                UserMenu.UserMenuTabID = UserMenuTabID

                Inserted = Insert(DbContext, UserMenu)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserMenus.Add(UserMenu)

                ErrorText = UserMenu.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserMenu)

                ErrorText = UserMenu.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserMenu)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_MENU WHERE SEC_USER_ID = " & UserID)

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
