Namespace Security.Database.Procedures.UserApplicationAccess

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

        Public Function LoadByApplicationIDAndUserID(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer, ByVal UserID As Integer) As Security.Database.Entities.UserApplicationAccess

            Try

                LoadByApplicationIDAndUserID = (From UserApplicationAccess In DbContext.GetQuery(Of Database.Entities.UserApplicationAccess)
                                                Where UserApplicationAccess.ApplicationID = ApplicationID AndAlso
                                                      UserApplicationAccess.UserID = UserID
                                                Select UserApplicationAccess).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationIDAndUserID = Nothing
            End Try

        End Function
        Public Function LoadByUserID(ByVal DbContext As Database.DbContext, ByVal UserID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserApplicationAccess)

            LoadByUserID = From UserApplicationAccess In DbContext.GetQuery(Of Database.Entities.UserApplicationAccess)
                           Where UserApplicationAccess.UserID = UserID
                           Select UserApplicationAccess

        End Function
        Public Function LoadByUserIDs(ByVal DbContext As Database.DbContext, ByVal UserIDs() As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserApplicationAccess)

            LoadByUserIDs = From UserApplicationAccess In DbContext.GetQuery(Of Database.Entities.UserApplicationAccess)
                            Where UserIDs.Contains(UserApplicationAccess.UserID)
                            Select UserApplicationAccess

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.UserApplicationAccess)

            Load = From UserApplicationAccess In DbContext.GetQuery(Of Database.Entities.UserApplicationAccess)
                   Select UserApplicationAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer, ByVal ApplicationID As Integer,
                       ByVal IsBlocked As Boolean, ByVal CanAdd As Boolean, ByVal CanPrint As Boolean,
                       ByVal CanUpdate As Boolean, ByVal Custom1 As Boolean, ByVal Custom2 As Boolean,
                       ByRef UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                UserApplicationAccess = New AdvantageFramework.Security.Database.Entities.UserApplicationAccess

                UserApplicationAccess.DbContext = DbContext
                UserApplicationAccess.UserID = UserID
                UserApplicationAccess.ApplicationID = ApplicationID
                UserApplicationAccess.IsBlocked = IsBlocked
                UserApplicationAccess.CanAdd = CanAdd
                UserApplicationAccess.CanPrint = CanPrint
                UserApplicationAccess.CanUpdate = CanUpdate
                UserApplicationAccess.Custom1 = Custom1
                UserApplicationAccess.Custom2 = Custom2

                Inserted = Insert(DbContext, UserApplicationAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserApplicationAccesses.Add(UserApplicationAccess)

                ErrorText = UserApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserApplicationAccess)

                ErrorText = UserApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserApplicationAccess As AdvantageFramework.Security.Database.Entities.UserApplicationAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(UserApplicationAccess)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_USER_APPACCESS WHERE SEC_USER_ID = " & UserID)

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
