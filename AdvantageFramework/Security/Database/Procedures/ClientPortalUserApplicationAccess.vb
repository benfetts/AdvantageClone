Namespace Security.Database.Procedures.ClientPortalUserApplicationAccess

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

        Public Function LoadByApplicationIDAndClientPortalUserID(ByVal DbContext As Database.DbContext, ByVal ApplicationID As Integer, ByVal ClientPortalUserID As System.Guid) As Security.Database.Entities.ClientPortalUserApplicationAccess

            Try

                LoadByApplicationIDAndClientPortalUserID = (From ClientPortalUserApplicationAccess In DbContext.GetQuery(Of Database.Entities.ClientPortalUserApplicationAccess)
                                                            Where ClientPortalUserApplicationAccess.ClientPortalUserID = ClientPortalUserID AndAlso
                                                                  ClientPortalUserApplicationAccess.ApplicationID = ApplicationID
                                                            Select ClientPortalUserApplicationAccess).SingleOrDefault

            Catch ex As Exception
                LoadByApplicationIDAndClientPortalUserID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUserApplicationAccess)

            Load = From ClientPortalUserApplicationAccess In DbContext.GetQuery(Of Database.Entities.ClientPortalUserApplicationAccess)
                   Select ClientPortalUserApplicationAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserID As System.Guid,
                               ByVal ApplicationID As Integer, ByVal IsBlocked As Boolean, _
                               ByRef ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ClientPortalUserApplicationAccess = New AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess

                ClientPortalUserApplicationAccess.DbContext = DbContext
                ClientPortalUserApplicationAccess.ClientPortalUserID = ClientPortalUserID
                ClientPortalUserApplicationAccess.ApplicationID = ApplicationID
                ClientPortalUserApplicationAccess.IsBlocked = IsBlocked
                ClientPortalUserApplicationAccess.CanAdd = True
                ClientPortalUserApplicationAccess.CanPrint = True
                ClientPortalUserApplicationAccess.CanUpdate = True
                ClientPortalUserApplicationAccess.Custom1 = False
                ClientPortalUserApplicationAccess.Custom2 = False

                Inserted = Insert(DbContext, ClientPortalUserApplicationAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientPortalUserApplicationAccesses.Add(ClientPortalUserApplicationAccess)

                ErrorText = ClientPortalUserApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientPortalUserApplicationAccess)

                ErrorText = ClientPortalUserApplicationAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserApplicationAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserApplicationAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientPortalUserApplicationAccess)

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
        Public Function DeleteByClientPortalUserID(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserID As System.Guid) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_CPUSER_APPACCESS WHERE CPUSER_GUID = '" & ClientPortalUserID.ToString & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByClientPortalUserID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
