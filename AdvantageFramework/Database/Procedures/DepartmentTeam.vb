Namespace Database.Procedures.DepartmentTeam

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

#Region "  Core Entities "

        Public Function LoadCore(ByVal DepartmentTeams As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DepartmentTeam)) As IEnumerable(Of AdvantageFramework.Database.Core.DepartmentTeam)

            Try

                LoadCore = DepartmentTeams _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.Description,
                                                              Entity.IsInactive}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.DepartmentTeam With {.Code = Entity.Code,
                                                                                                              .Description = Entity.Description,
                                                                                                              .IsInactive = Entity.IsInactive}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.DepartmentTeam)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DepartmentTeam)

            LoadAllActive = From DepartmentTeam In DbContext.GetQuery(Of Database.Entities.DepartmentTeam)
                            Where DepartmentTeam.IsInactive Is Nothing OrElse
                                  DepartmentTeam.IsInactive = 0
                            Select DepartmentTeam

        End Function
        Public Function LoadByDepartmentTeamCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeamCode As String) As AdvantageFramework.Database.Entities.DepartmentTeam

            Try

                LoadByDepartmentTeamCode = (From DepartmentTeam In DbContext.GetQuery(Of Database.Entities.DepartmentTeam)
                                            Where DepartmentTeam.Code = DepartmentTeamCode
                                            Select DepartmentTeam).SingleOrDefault

            Catch ex As Exception
                LoadByDepartmentTeamCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DepartmentTeam)

            Load = From DepartmentTeam In DbContext.GetQuery(Of Database.Entities.DepartmentTeam)
                   Select DepartmentTeam

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DepartmentTeams.Add(DepartmentTeam)

                ErrorText = DepartmentTeam.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim CodeParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DescriptionParameter As System.Data.SqlClient.SqlParameter = Nothing

            Try

                DbContext.UpdateObject(DepartmentTeam)

                ErrorText = DepartmentTeam.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    CodeParameter = New SqlClient.SqlParameter("CodeParam", SqlDbType.VarChar) With {.Value = DepartmentTeam.Code}

                    DescriptionParameter = New SqlClient.SqlParameter("DescParam", SqlDbType.VarChar) With {.Value = DBNull.Value}

                    If Not String.IsNullOrWhiteSpace(DepartmentTeam.Description) Then

                        DescriptionParameter.Value = DepartmentTeam.Description

                    End If

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMP_DP_TM SET DP_TM_DESC = @DescParam WHERE DP_TM_CODE = @CodeParam", CodeParameter, DescriptionParameter)
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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByDepartmentTeamCode(DbContext, DepartmentTeam.Code).Any Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                End If

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext).Where(Function(JobComp) JobComp.DepartmentTeamCode = DepartmentTeam.Code).Any Then

                        IsValid = False
                        ErrorText = "This code is in use and cannot be deleted."

                    End If

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(DepartmentTeam)

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

#End Region

    End Module

End Namespace
