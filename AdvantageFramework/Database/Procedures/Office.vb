Namespace Database.Procedures.Office

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

        Public Function LoadCore(ByVal Offices As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office)) As IEnumerable(Of AdvantageFramework.Database.Core.Office)

            Try

                LoadCore = Offices _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Name,
                                                              Entity.IsInactive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Office With {.Code = Entity.Code,
                                                                                                      .Name = Entity.Name,
                                                                                                      .IsInactive = Entity.IsInactive}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Office)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Office)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Office)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Offices, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Offices As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Office)

            LoadWithOfficeLimits = From Office In Offices
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Office.Code)
                                   Select Office

        End Function
        Public Function LoadAllActiveWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String) As AdvantageFramework.Database.Entities.Office

            Try

                LoadByOfficeCode = (From Office In DbContext.GetQuery(Of Database.Entities.Office)
                                    Where Office.Code = OfficeCode
                                    Select Office).SingleOrDefault

            Catch ex As Exception
                LoadByOfficeCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office)

            LoadAllActive = From Office In DbContext.GetQuery(Of Database.Entities.Office)
                            Where Office.IsInactive Is Nothing OrElse
                                  Office.IsInactive = 0
                            Select Office

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office)

            Load = From Office In DbContext.GetQuery(Of Database.Entities.Office)
                   Select Office

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Office As AdvantageFramework.Database.Entities.Office) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Offices.Add(Office)

                ErrorText = Office.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Office As AdvantageFramework.Database.Entities.Office) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Office)

                ErrorText = Office.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Office As AdvantageFramework.Database.Entities.Office) As Boolean

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

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.GLOXREF WHERE GLOXOFFICE='{0}'", Office.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.OFF_INTER_CO WHERE OFFICE_CODE='{0}' or INTER_CO_CODE='{0}'", Office.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.OFF_SC_FNC_ACCTS WHERE OFFICE_CODE='{0}'", Office.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.OFF_SC_ACCTS WHERE OFFICE_CODE='{0}'", Office.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.OFF_FNC_ACCTS WHERE OFFICE_CODE='{0}'", Office.Code))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.OFF_TAX_ACCTS WHERE OFFICE_CODE='{0}'", Office.Code))

                        DbContext.DeleteEntityObject(Office)

                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    Try

                        If Deleted Then

                            DbTransaction.Commit()

                        Else

                            DbTransaction.Rollback()

                        End If

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    DbContext.Database.Connection.Close()

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
