Namespace Database.Procedures.JobComponent

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

        Public Function LoadCore(ByVal JobComponents As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobComponent)) As IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)

            Try

                LoadCore = JobComponents _
                           .Select(Function(Entity) New With {Entity.JobNumber,
                                                              Entity.Number,
                                                              Entity.ID,
                                                              Entity.JobProcessNumber,
                                                              Entity.Description}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.JobComponent With {.JobNumber = Entity.JobNumber,
                                                                                                            .Number = Entity.Number,
                                                                                                            .ID = Entity.ID,
                                                                                                            .JobProcessNumber = Entity.JobProcessNumber,
                                                                                                            .Description = Entity.Description}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.JobComponent)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadAllOpenByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            LoadAllOpenByClientCode = From JobComponent In LoadAllOpen(DbContext)
                                      Where JobComponent.Job.ClientCode = ClientCode
                                      Select JobComponent

        End Function
        Public Function LoadByUserForEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal OpenByJobProcessNumberOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            Dim ExcludedJobProcessControlNumbers As Integer() = Nothing
            Dim UserClientDivisionProductAccessList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim EmployeeUserCodes As String() = Nothing
            Dim JobCompIDs As Integer() = Nothing

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

                JobCompIDs = (From Entity In Load(DbContext)
                              Where ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = False OrElse
                                    ExcludedJobProcessControlNumbers.Contains(Entity.JobProcessNumber) = Not OpenByJobProcessNumberOnly
                              Select Entity.ID).Distinct.ToArray

                If UserClientDivisionProductAccessList IsNot Nothing AndAlso UserClientDivisionProductAccessList.Count > 0 Then

                    JobCompIDs = (From Entity In (From JobComp In Load(DbContext)
                                                  Select New With {.ClientCode = JobComp.Job.ClientCode,
                                                                   .DivisionCode = JobComp.Job.DivisionCode,
                                                                   .ProductCode = JobComp.Job.ProductCode,
                                                                   .ID = JobComp.ID}).ToList
                                  Where UserClientDivisionProductAccessList.Any(Function(UserAccess) UserAccess.ClientCode = Entity.ClientCode AndAlso
                                                                                                    UserAccess.DivisionCode = Entity.DivisionCode AndAlso
                                                                                                    UserAccess.ProductCode = Entity.ProductCode) AndAlso
                                       JobCompIDs.Contains(Entity.ID)
                                  Select Entity.ID).ToArray

                End If

                LoadByUserForEmployeeCode = From JobComp In Load(DbContext)
                                            Where JobCompIDs.Contains(JobComp.ID)
                                            Select JobComp

            Catch ex As Exception
                LoadByUserForEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal OpenJobComponentsOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            'objects
            Dim JobNumbers As Integer() = Nothing
            Dim SQL As String = ""

            Try

                If (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode)
                    Select Entity).Any Then

                    SQL = String.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " &
                                        "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " &
                                        "WHERE SC.[USER_ID] = '{0}'", UserCode)

                    Try

                        JobNumbers = DbContext.Database.SqlQuery(Of Integer)(SQL).ToArray

                    Catch ex As Exception
                        JobNumbers = Nothing
                    End Try

                    If OpenJobComponentsOnly Then

                        LoadByUserCode = From JobComponent In LoadAllOpen(DbContext)
                                         Where JobNumbers.Contains(JobComponent.JobNumber)
                                         Select JobComponent

                    Else

                        LoadByUserCode = From JobComponent In Load(DbContext)
                                         Where JobNumbers.Contains(JobComponent.JobNumber)
                                         Select JobComponent

                    End If

                Else

                    If OpenJobComponentsOnly Then

                        LoadByUserCode = LoadAllOpen(DbContext)

                    Else

                        LoadByUserCode = Load(DbContext)

                    End If

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadAndFilterByClientDivisionProductAndJob(ByVal DbContext As Database.DbContext, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "",
                                                                   Optional ByVal ProductCode As String = "", Optional ByVal JobNumber As String = "") As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            'objects
            Dim Jobs As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing

            If String.IsNullOrEmpty(JobNumber) = False Then

                LoadAndFilterByClientDivisionProductAndJob = From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                                             Where JobComponent.JobProcessNumber <> 12 AndAlso
                                                                   JobComponent.JobProcessNumber <> 6 AndAlso
                                                                   JobComponent.JobNumber = JobNumber
                                                             Select JobComponent
            Else

                If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                    Jobs = AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).ToList

                ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                    Jobs = AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList

                ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                    Jobs = AdvantageFramework.Database.Procedures.Job.LoadByClientCode(DbContext, ClientCode).ToList

                End If

                Try

                    LoadAndFilterByClientDivisionProductAndJob = From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                                                 Where JobComponent.JobProcessNumber <> 12 AndAlso
                                                                       JobComponent.JobProcessNumber <> 6 AndAlso
                                                                       Jobs.Any(Function(Job) Job.Number = JobComponent.JobNumber)
                                                                 Select JobComponent

                Catch ex As Exception
                    LoadAndFilterByClientDivisionProductAndJob = Nothing
                End Try

            End If

        End Function
        Public Function LoadByJobTypeCode(ByVal DbContext As Database.DbContext, ByVal JobTypeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            LoadByJobTypeCode = From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                Where JobComponent.JobTypeCode = JobTypeCode
                                Select JobComponent

        End Function
        Public Function LoadAllOpen(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            LoadAllOpen = From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                          Where JobComponent.JobProcessNumber <> 12 AndAlso
                                JobComponent.JobProcessNumber <> 6
                          Select JobComponent

        End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Database.Entities.JobComponent

            Try

                LoadByJobNumberAndJobComponentNumber = (From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                                                        Where JobComponent.JobNumber = JobNumber AndAlso
                                                              JobComponent.Number = JobComponentNumber
                                                        Select JobComponent).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function
        Public Function LoadAllOpenByJobNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            LoadAllOpenByJobNumber = From JobComponent In DbContext.JobComponents
                                     Where JobComponent.JobProcessNumber <> 12 AndAlso
                                           JobComponent.JobProcessNumber <> 6 AndAlso
                                           JobComponent.JobNumber = JobNumber
                                     Select JobComponent
                                     Order By JobComponent.Number

        End Function
        Public Function LoadAllByJobNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            LoadAllByJobNumber = From JobComponent In DbContext.JobComponents
                                 Where JobComponent.JobNumber = JobNumber
                                 Select JobComponent
                                 Order By JobComponent.Number

        End Function
        Public Function LoadByJobComponentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponentID As Integer) As Database.Entities.JobComponent

            Try

                LoadByJobComponentID = (From JobComponent In DbContext.JobComponents
                                        Where JobComponent.ID = JobComponentID
                                        Select JobComponent).SingleOrDefault

            Catch ex As Exception
                LoadByJobComponentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobComponent)

            Load = From JobComponent In DbContext.GetQuery(Of Database.Entities.JobComponent)
                   Select JobComponent

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobComponent As AdvantageFramework.Database.Entities.JobComponent) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobComponent)

                ErrorText = JobComponent.ValidateEntity(IsValid)

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

                If UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_COMPONENT SET UDV1_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_COMPONENT SET UDV2_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_COMPONENT SET UDV3_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_COMPONENT SET UDV4_CODE = NULL")

                ElseIf UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE dbo.JOB_COMPONENT SET UDV5_CODE = NULL")

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
