Namespace Database.Procedures.Division

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

        Public Function LoadCore(ByVal Divisions As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)) As IEnumerable(Of AdvantageFramework.Database.Core.Division)

            Try

                LoadCore = Divisions _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.ClientCode,
                                                              Entity.Name,
                                                              Entity.IsActive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Division With {.Code = Entity.Code,
                                                                                                        .ClientCode = Entity.ClientCode,
                                                                                                        .Name = Entity.Name,
                                                                                                        .IsActive = Entity.IsActive}).ToList()

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Division)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Division)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Division)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Divisions, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Divisions As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Division)

            LoadWithOfficeLimits = From Division In Divisions.Include("Products")
                                   Where HasLimitedOfficeCodes = False OrElse
                                         (Division.Products.Any = False OrElse
                                          Division.Products.Any(Function(Entity) OfficeCodes.Contains(Entity.OfficeCode)))
                                   Select Division

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Division)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadAllActiveByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllActiveByUserCode(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByUserForEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal ActiveOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

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
                                       Select Entity.ClientCode & "|" & Entity.DivisionCode).ToArray

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = From Division In LoadAllActive(DbContext)
                                                    Where UniqueKeyValues.Contains(Division.ClientCode & "|" & Division.Code)
                                                    Select Division

                    Else

                        LoadByUserForEmployeeCode = From Division In Load(DbContext)
                                                    Where UniqueKeyValues.Contains(Division.ClientCode & "|" & Division.Code)
                                                    Select Division

                    End If

                Else

                    If ActiveOnly Then

                        LoadByUserForEmployeeCode = From Division In LoadAllActive(DbContext)
                                                    Select Division

                    Else

                        LoadByUserForEmployeeCode = From Division In Load(DbContext)
                                                    Select Division

                    End If

                End If

            Catch ex As Exception
                LoadByUserForEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadAllActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadAllActiveByUserCode = From Division In LoadByUserCode(DbContext, SecurityDbContext, UserCode)
                                      Where Division.IsActive = 1
                                      Select Division

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim UniqueKeyValues As String() = Nothing

            Try

                UserClientDivisionProductAccess = (From Entity In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess).ToList
                                                   Where Entity.UserCode.ToUpper = UserCode.ToUpper
                                                   Select Entity).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    UniqueKeyValues = (From Entity In UserClientDivisionProductAccess
                                       Select Entity.ClientCode & "|" & Entity.DivisionCode).ToArray

                    LoadByUserCode = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                                     Where UniqueKeyValues.Contains(Division.ClientCode & "|" & Division.Code)
                                     Select Division

                Else

                    LoadByUserCode = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                                     Select Division

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        'Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal IncludeClient As Boolean) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Division)

        '    Dim UserClientDivisionProductAccess As IEnumerable(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

        '    Try

        '        UserClientDivisionProductAccess = (From Entity In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess).ToList
        '                                           Where Entity.UserCode = UserCode _
        '                                           Select Entity).ToList

        '        If UserClientDivisionProductAccess.Count > 0 Then

        '            If IncludeClient Then

        '                LoadByUserCode = (From Division In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.Division).Include("Client").ToList _
        '                                  Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Division.ClientCode AndAlso UserCDP.DivisionCode = Division.Code) = True _
        '                                  Select Division).ToList

        '            Else

        '                LoadByUserCode = (From Division In DbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.Division).ToList _
        '                                  Where UserClientDivisionProductAccess.Any(Function(UserCDP) UserCDP.ClientCode = Division.ClientCode AndAlso UserCDP.DivisionCode = Division.Code) = True _
        '                                  Select Division).ToList

        '            End If

        '        Else

        '            If IncludeClient Then

        '                LoadByUserCode = (From Division In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Division).Include("Client").ToList _
        '                                  Select Division).ToList

        '            Else

        '                LoadByUserCode = (From Division In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Division).ToList _
        '                                  Select Division).ToList

        '            End If

        '        End If

        '    Catch ex As Exception
        '        LoadByUserCode = Nothing
        '    End Try

        'End Function
        Public Function LoadByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadByBatchName = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                              Where Division.BatchName = BatchName
                              Select Division

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As AdvantageFramework.Database.Entities.Division

            Try

                LoadByClientAndDivisionCode = (From Division In DbContext.GetQuery(Of Database.Entities.Division)
                                               Where Division.ClientCode = ClientCode AndAlso
                                                     Division.Code = DivisionCode
                                               Select Division).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadByClientCode = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                               Where Division.ClientCode = ClientCode
                               Select Division

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            LoadAllActive = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                            Where Division.IsActive = 1
                            Select Division

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division)

            Load = From Division In DbContext.GetQuery(Of Database.Entities.Division)
                   Select Division

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Division As AdvantageFramework.Database.Entities.Division) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Divisions.Add(Division)

                ErrorText = Division.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Division As AdvantageFramework.Database.Entities.Division) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Division)

                ErrorText = Division.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Division As AdvantageFramework.Database.Entities.Division) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM DIV_SRT_KEY WHERE CL_CODE = '{0}' and DIV_CODE = '{1}'", Division.ClientCode, Division.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.DIVISION WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}'", Division.ClientCode, Division.Code))

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

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
        Public Function Copy(ByVal Division As AdvantageFramework.Database.Entities.Division) As AdvantageFramework.Database.Entities.Division

            Dim NewDivision As AdvantageFramework.Database.Entities.Division

            Try

                NewDivision = New AdvantageFramework.Database.Entities.Division

                NewDivision.ClientCode = Division.ClientCode
                NewDivision.Code = Division.Code
                NewDivision.Name = Division.Name
                NewDivision.Address = Division.Address
                NewDivision.Address2 = Division.Address2
                NewDivision.City = Division.City
                NewDivision.County = Division.County
                NewDivision.State = Division.State
                NewDivision.Country = Division.Country
                NewDivision.Zip = Division.Zip
                NewDivision.IsActive = Division.IsActive
                NewDivision.BillingAddress = Division.BillingAddress
                NewDivision.BillingAddress2 = Division.BillingAddress2
                NewDivision.BillingCity = Division.BillingCity
                NewDivision.BillingCounty = Division.BillingCounty
                NewDivision.BillingState = Division.BillingState
                NewDivision.BillingZip = Division.BillingZip
                NewDivision.BillingCountry = Division.BillingCountry
                NewDivision.AttentionLine = Division.AttentionLine
                NewDivision.SortName = Division.SortName

                Copy = NewDivision

            Catch ex As Exception
                Copy = Nothing
            End Try

        End Function
        Public Function CreateFromClient(ByVal Client As AdvantageFramework.Database.Entities.Client) As AdvantageFramework.Database.Entities.Division

            Dim Division As AdvantageFramework.Database.Entities.Division

            Try

                Division = New AdvantageFramework.Database.Entities.Division

                Division.ClientCode = Client.Code
                Division.Code = Client.Code
                Division.Name = Client.Name
                Division.BillingAddress = Client.BillingAddress
                Division.BillingAddress2 = Client.BillingAddress2
                Division.BillingCity = Client.BillingCity
                Division.BillingCounty = Client.BillingCounty
                Division.BillingState = Client.BillingState
                Division.BillingZip = Client.BillingZip
                Division.BillingCountry = Client.BillingCountry
                Division.Address = Client.StatementAddress
                Division.Address2 = Client.StatementAddress2
                Division.City = Client.StatementCity
                Division.County = Client.StatementCounty
                Division.State = Client.StatementState
                Division.Zip = Client.StatementZip
                Division.Country = Client.StatementCountry
                Division.SortName = Client.SortName
                Division.IsActive = Client.IsActive

                CreateFromClient = Division

            Catch ex As Exception
                CreateFromClient = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
