Namespace Database.Procedures.Client

    <HideModuleName()>
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

#Region "  Core Entities "

        Public Function LoadCore(ByVal Clients As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)) As IEnumerable(Of AdvantageFramework.Database.Core.Client)

            Try

                LoadCore = Clients _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Name,
                                                              Entity.IsActive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Client With {.Code = Entity.Code,
                                                                                                      .Name = Entity.Name,
                                                                                                      .IsActive = Entity.IsActive}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Client)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Clients, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Clients As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            LoadWithOfficeLimits = From Client In Clients.Include("Products")
                                   Where HasLimitedOfficeCodes = False OrElse
                                         (Client.Products.Any = False OrElse
                                          Client.Products.Any(Function(Entity) OfficeCodes.Contains(Entity.OfficeCode)))
                                   Select Client

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal Clients As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            LoadAllActiveWithOfficeLimits = From Client In Clients.Include("Products")
                                            Where HasLimitedOfficeCodes = False OrElse
                                                (Client.Products.Any = False OrElse
                                                 Client.Products.Any(Function(Entity) OfficeCodes.Contains(Entity.OfficeCode))) AndAlso
                                                 Client.IsActive = 1
                                            Select Client

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            LoadAllActiveByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserForEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal ActiveOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            'objects
            Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UniqueKeyValues As String() = Nothing
            Dim EmployeeUserCodes As String() = Nothing

            Try

                Try

                    EmployeeUserCodes = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
                                         Select [UC] = Entity.UserCode).ToArray

                Catch ex As Exception
                    EmployeeUserCodes = Nothing
                End Try

                If EmployeeUserCodes IsNot Nothing Then

                    If EmployeeUserCodes.Contains(UserCode) Then

                        EmployeeUserCodes = {UserCode}

                    End If

                    Try

                        UserClientDivisionProductAccess = (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
                                                           Where EmployeeUserCodes.Contains(Entity.UserCode)
                                                           Select Entity).ToList

                    Catch ex As Exception
                        UserClientDivisionProductAccess = Nothing
                    End Try

                End If

                If UserClientDivisionProductAccess IsNot Nothing AndAlso UserClientDivisionProductAccess.Count > 0 Then

                    UniqueKeyValues = (From Entity In UserClientDivisionProductAccess
                                       Select Entity.ClientCode).ToArray

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = From Client In LoadAllActive(DbContext)
                                                    Where UniqueKeyValues.Contains(Client.Code)
                                                    Select Client
                    Else

                        LoadByUserForEmployeeCode = From Client In LoadAllActive(DbContext)
                                                    Where UniqueKeyValues.Contains(Client.Code)
                                                    Select Client

                    End If

                Else

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = From Client In LoadAllActive(DbContext)
                                                    Select Client

                    Else

                        LoadByUserForEmployeeCode = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                                                    Select Client

                    End If

                End If

            Catch ex As Exception
                LoadByUserForEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            Try

                LoadAllActiveByUserCode = From Client In LoadByUserCode(DbContext, SecurityDbContext, UserCode)
                                          Where Client.IsActive = 1
                                          Select Client

            Catch ex As Exception
                LoadAllActiveByUserCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UniqueKeyValues As String() = Nothing

            Try

                UserClientDivisionProductAccess = (From Entity In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess).ToList
                                                   Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                                   Select Entity).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    UniqueKeyValues = (From Entity In UserClientDivisionProductAccess
                                       Select Entity.ClientCode).ToArray

                    LoadByUserCode = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                                     Where UniqueKeyValues.Contains(Client.Code)
                                     Select Client

                Else

                    LoadByUserCode = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                                     Select Client

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            LoadByBatchName = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                              Where Client.BatchName = BatchName
                              Select Client

        End Function
        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As AdvantageFramework.Database.Entities.Client

            Try

                LoadByClientCode = (From Client In DbContext.GetQuery(Of Database.Entities.Client)
                                    Where Client.Code = ClientCode
                                    Select Client).SingleOrDefault

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            LoadAllActive = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                            Where Client.IsActive = 1
                            Select Client

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client)

            Load = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                   Select Client

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Client As AdvantageFramework.Database.Entities.Client) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Clients.Add(Client)

                ErrorText = Client.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Client As AdvantageFramework.Database.Entities.Client) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Client)

                ErrorText = Client.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Client As AdvantageFramework.Database.Entities.Client) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CLIENT WHERE CL_CODE = '{0}'", Client.Code))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If IsValid Then
                        ' DELETE SORT KEYS
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CL_SRT_KEY WHERE CL_CODE = '{0}'", Client.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.AGENCY_CLIENTS WHERE CL_CODE = '{0}'", Client.Code))

                        Deleted = True

                    End If

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
