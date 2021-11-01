Namespace Security.Database.Procedures.UserMenuTab

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

        Public Function LoadByUserMenuTabID(ByVal DbContext As Database.DbContext, ByVal UserMenuTabID As Integer) As Security.Database.Entities.UserMenuTab

            Try

                LoadByUserMenuTabID = (From UserMenuTab In DbContext.GetQuery(Of Database.Entities.UserMenuTab)
                                       Where UserMenuTab.ID = UserMenuTabID
                                       Select UserMenuTab).SingleOrDefault

            Catch ex As Exception
                LoadByUserMenuTabID = Nothing
            End Try

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserMenuTab)

            LoadByUserID = From UserMenuTab In DbContext.GetQuery(Of Database.Entities.UserMenuTab)
                           Where UserMenuTab.UserID = UserID
                           Select UserMenuTab

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserMenuTab)

            Load = From UserMenuTab In DbContext.GetQuery(Of Database.Entities.UserMenuTab)
                   Select UserMenuTab

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, _
                               ByVal Name As String, ByVal Order As Integer, ByVal HasSmallIcons As Boolean, _
                               ByRef UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserMenuTab = New AdvantageFramework.Security.Database.Entities.UserMenuTab

                UserMenuTab.DbContext = DbContext
                UserMenuTab.UserID = UserID
                UserMenuTab.Name = Name
                UserMenuTab.Order = Order
                UserMenuTab.HasSmallIcons = HasSmallIcons

                Inserted = Insert(DbContext, UserMenuTab)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserMenuTabs.Add(UserMenuTab)

                ErrorText = UserMenuTab.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserMenuTab)

                ErrorText = UserMenuTab.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

            Try

                If IsValid Then

                    For Each UserMenu In UserMenuTab.UserMenus

                        AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(DbContext, UserMenu)

                    Next

                    DbContext.DeleteEntityObject(UserMenuTab)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_MENU_TAB WHERE SEC_USER_ID = " & UserID)

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
