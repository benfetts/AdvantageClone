Namespace Database.Procedures.Job

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

        Public Function LoadCore(ByVal Jobs As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job)) As IEnumerable(Of AdvantageFramework.Database.Core.Job)

            Try

                LoadCore = Jobs _
                           .Select(Function(Entity) New With {Entity.Number,
                                                              Entity.OfficeCode,
                                                              Entity.ClientCode,
                                                              Entity.DivisionCode,
                                                              Entity.ProductCode,
                                                              Entity.Description,
                                                              Entity.IsOpen}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Job With {.Number = Entity.Number,
                                                                                                   .OfficeCode = Entity.OfficeCode,
                                                                                                   .ClientCode = Entity.ClientCode,
                                                                                                   .DivisionCode = Entity.DivisionCode,
                                                                                                   .ProductCode = Entity.ProductCode,
                                                                                                   .Description = Entity.Description,
                                                                                                   .IsOpen = Entity.IsOpen}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Job)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadAllOpenByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            LoadAllOpenByClientCode = From Job In LoadAllOpen(DbContext)
                                      Where Job.ClientCode = ClientCode
                                      Select Job

        End Function
        Public Function LoadByUserForEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal OpenByJobProcessNumberOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            Dim ExcludedJobProcessControlNumbers As Integer() = Nothing
            Dim UserClientDivisionProductAccessList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim EmployeeUserCodes As String() = Nothing
            Dim JobNumbers As Integer() = Nothing

            ExcludedJobProcessControlNumbers = New Integer() {2, 5, 7, 10, 11, 6, 12}

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

                        UserClientDivisionProductAccessList = (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.Load(SecurityDbContext)
                                                               Where EmployeeUserCodes.Contains(Entity.UserCode)
                                                               Select Entity).ToList

                    Catch ex As Exception
                        UserClientDivisionProductAccessList = Nothing
                    End Try

                End If

                JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                              Where ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False OrElse
                                        ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = If(OpenByJobProcessNumberOnly = False, True, False)
                              Select Entity.JobNumber).Distinct.ToArray

                If UserClientDivisionProductAccessList IsNot Nothing AndAlso UserClientDivisionProductAccessList.Count > 0 Then

                    JobNumbers = (From Entity In (From Job In LoadAllOpen(DbContext)
                                                  Select New With {.ClientCode = Job.ClientCode,
                                                                   .DivisionCode = Job.DivisionCode,
                                                                   .ProductCode = Job.ProductCode,
                                                                   .Number = Job.Number}).ToList
                                  Where UserClientDivisionProductAccessList.Any(Function(UserAccess) UserAccess.ClientCode = Entity.ClientCode AndAlso
                                                                                                    UserAccess.DivisionCode = Entity.DivisionCode AndAlso
                                                                                                    UserAccess.ProductCode = Entity.ProductCode) AndAlso
                                       JobNumbers.Contains(Entity.Number)
                                  Select Entity.Number).ToArray

                End If

                LoadByUserForEmployeeCode = From Job In LoadAllOpen(DbContext)
                                            Where JobNumbers.Contains(Job.Number)
                                            Select Job

            Catch ex As Exception
                LoadByUserForEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim SQL As String = ""

            Try

                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    SQL = String.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " &
                                        "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " &
                                        "WHERE SC.[USER_ID] = '{0}'", UserCode)

                    Try

                        JobNumbers = DbContext.Database.SqlQuery(Of Integer)(SQL).ToArray

                    Catch ex As Exception
                        JobNumbers = Nothing
                    End Try

                    LoadByUserCode = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                                     Where JobNumbers.Contains(Job.Number)
                                     Select Job

                Else

                    LoadByUserCode = Load(DbContext)

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadOpenByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            Dim UserClientDivisionProductAccess As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim JobNumbers As Integer() = Nothing
            Dim SQL As String = ""

            Try

                UserClientDivisionProductAccess = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                If UserClientDivisionProductAccess.Count > 0 Then

                    SQL = String.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " &
                                        "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " &
                                        "WHERE SC.[USER_ID] = '{0}'", UserCode)

                    Try

                        JobNumbers = DbContext.Database.SqlQuery(Of Integer)(SQL).ToArray

                    Catch ex As Exception
                        JobNumbers = Nothing
                    End Try

                    LoadOpenByUserCode = From Job In LoadAllOpen(DbContext)
                                         Where JobNumbers.Contains(Job.Number)
                                         Select Job

                Else

                    LoadOpenByUserCode = LoadAllOpen(DbContext)

                End If

            Catch ex As Exception
                LoadOpenByUserCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            LoadByClientCode = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                               Where Job.ClientCode = ClientCode
                               Select Job

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            LoadByClientAndDivisionCode = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                                          Where Job.ClientCode = ClientCode AndAlso
                                                Job.DivisionCode = DivisionCode
                                          Select Job

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            LoadByClientAndDivisionAndProductCode = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                                                    Where Job.ClientCode = ClientCode AndAlso
                                                          Job.DivisionCode = DivisionCode AndAlso
                                                          Job.ProductCode = ProductCode
                                                    Select Job

        End Function
        Public Function LoadByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job)

            LoadByOfficeCode = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                               Where Job.OfficeCode = OfficeCode
                               Select Job

        End Function
        Public Function LoadByJobID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobID As Integer) As AdvantageFramework.Database.Entities.Job

            Try

                LoadByJobID = (From Job In DbContext.GetQuery(Of Database.Entities.Job)
                               Where Job.ID = JobID
                               Select Job).SingleOrDefault

            Catch ex As Exception
                LoadByJobID = Nothing
            End Try

        End Function
        Public Function LoadByJobNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As AdvantageFramework.Database.Entities.Job

            Try

                LoadByJobNumber = (From Job In DbContext.GetQuery(Of Database.Entities.Job)
                                   Where Job.Number = JobNumber
                                   Select Job).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumber = Nothing
            End Try

        End Function
        Public Function LoadBySalesClassAndFormatCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClassCode As String, ByVal SalesClassFormatCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Job)

            Try

                LoadBySalesClassAndFormatCode = (From Job In DbContext.GetQuery(Of Database.Entities.Job)
                                                 Where Job.SalesClassCode = SalesClassCode AndAlso Job.SalesClassFormatCode = SalesClassFormatCode
                                                 Select Job)

            Catch ex As Exception
                LoadBySalesClassAndFormatCode = Nothing
            End Try

        End Function
        Public Function LoadAllOpen(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job)

            LoadAllOpen = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                          Where Job.IsOpen = 1
                          Select Job

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Job)

            Load = From Job In DbContext.GetQuery(Of Database.Entities.Job)
                   Select Job

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Job As AdvantageFramework.Database.Entities.Job) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Job)

                ErrorText = Job.ValidateEntity(IsValid)

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
        Public Function ClearUserDefinedValue(ByVal DbContext As AdvantageFramework.Database.DbContext, UserDefinedLabelTable As AdvantageFramework.Database.Entities.UserDefinedLabelTables) As Boolean

            'objects
            Dim UserDefinedValueCleared As Boolean = False

            Try

                If UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV1_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV2_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV3_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV4_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_LOG SET UDV5_CODE = NULL")

                End If

                UserDefinedValueCleared = True

            Catch ex As Exception
                UserDefinedValueCleared = False
            Finally
                ClearUserDefinedValue = UserDefinedValueCleared
            End Try

        End Function

#End Region

    End Module

End Namespace

