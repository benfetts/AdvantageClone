Namespace Database.Procedures.JobView

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

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, DbContext.JobViews, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobViews As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.JobView), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

            'objects
            Dim UserClientDivisionProductAccessList As List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
            Dim CDPList As String() = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                UserClientDivisionProductAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, DbContext.UserCode).ToList

            End Using

            If UserClientDivisionProductAccessList IsNot Nothing AndAlso UserClientDivisionProductAccessList.Count > 0 Then

                CDPList = UserClientDivisionProductAccessList.Select(Function(s) s.ClientCode & "|" & s.DivisionCode & "|" & s.ProductCode).ToArray

                LoadWithOfficeLimits = From JobView In JobViews
                                       Let CD = JobView.ClientCode & "|" & JobView.DivisionCode, CDP = CD & "|" & JobView.ProductCode
                                       Where (HasLimitedOfficeCodes = False OrElse
                                             OfficeCodes.Contains(JobView.OfficeCode)) AndAlso
                                             CDPList.Contains(CDP)
                                       Select JobView

            Else

                LoadWithOfficeLimits = From JobView In JobViews
                                       Where (HasLimitedOfficeCodes = False OrElse
                                                 OfficeCodes.Contains(JobView.OfficeCode))
                                       Select JobView

            End If

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.JobView)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(DbContext, LoadByUserCode(DbContext, SecurityDbContext, UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllOpenByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

            LoadAllOpenByClientCode = From JobView In LoadAllOpen(DbContext)
                                      Where JobView.ClientCode = ClientCode
                                      Select JobView

        End Function
        Public Function LoadAllOpen(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.JobView)

            LoadAllOpen = From Job In DbContext.GetQuery(Of Database.Views.JobView)
                          Where Job.IsOpen = 1
                          Select Job

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

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

                    LoadByUserCode = From JobView In DbContext.GetQuery(Of Database.Views.JobView)
                                     Where JobNumbers.Contains(JobView.JobNumber)
                                     Select JobView

                Else

                    LoadByUserCode = Load(DbContext)

                End If

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadByJobNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer) As AdvantageFramework.Database.Views.JobView

            Try

                LoadByJobNumber = (From JobView In DbContext.GetQuery(Of Database.Views.JobView)
                                   Where JobView.JobNumber = JobNumber
                                   Select JobView).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumber = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobView)

            Load = From JobView In DbContext.GetQuery(Of Database.Views.JobView)
                   Select JobView

        End Function

#End Region

    End Module

End Namespace
