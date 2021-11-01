Namespace Security.Database.Procedures.ClientPortalUserModuleAccess

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

        Public Function LoadByModuleIDAndClientPortalUserID(ByVal DbContext As Database.DbContext, ByVal ModuleID As Integer, ByVal ClientPortalUserID As System.Guid) As Security.Database.Entities.ClientPortalUserModuleAccess

            Try

                LoadByModuleIDAndClientPortalUserID = (From ClientPortalUserModuleAccess In DbContext.GetQuery(Of Database.Entities.ClientPortalUserModuleAccess)
                                                       Where ClientPortalUserModuleAccess.ClientPortalUserID = ClientPortalUserID AndAlso
                                                             ClientPortalUserModuleAccess.ModuleID = ModuleID
                                                       Select ClientPortalUserModuleAccess).SingleOrDefault

            Catch ex As Exception
                LoadByModuleIDAndClientPortalUserID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUserModuleAccess)

            Load = From ClientPortalUserModuleAccess In DbContext.GetQuery(Of Database.Entities.ClientPortalUserModuleAccess)
                   Select ClientPortalUserModuleAccess

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserID As System.Guid,
                               ByVal ModuleID As Integer, ByVal IsBlocked As Boolean, _
                               ByRef ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ClientPortalUserModuleAccess = New AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess

                ClientPortalUserModuleAccess.DbContext = DbContext
                ClientPortalUserModuleAccess.ClientPortalUserID = ClientPortalUserID
                ClientPortalUserModuleAccess.ModuleID = ModuleID
                ClientPortalUserModuleAccess.IsBlocked = IsBlocked
                ClientPortalUserModuleAccess.CanAdd = True
                ClientPortalUserModuleAccess.CanPrint = True
                ClientPortalUserModuleAccess.CanUpdate = True
                ClientPortalUserModuleAccess.Custom1 = False
                ClientPortalUserModuleAccess.Custom2 = False

                Inserted = Insert(DbContext, ClientPortalUserModuleAccess)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientPortalUserModuleAccesses.Add(ClientPortalUserModuleAccess)

                ErrorText = ClientPortalUserModuleAccess.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientPortalUserModuleAccess)

                ErrorText = ClientPortalUserModuleAccess.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUserModuleAccess As AdvantageFramework.Security.Database.Entities.ClientPortalUserModuleAccess) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientPortalUserModuleAccess)

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

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.SEC_CPUSER_MODACCESS WHERE CPUSER_GUID = '" & ClientPortalUserID.ToString & "'")

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
