Namespace Database.Procedures.JobComponentView

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

        Public Function LoadAllOpenByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobComponentView)

            LoadAllOpenByClientCode = From JobComponentView In LoadAllOpen(DbContext)
                                      Where JobComponentView.ClientCode = ClientCode
                                      Select JobComponentView

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String,
                                       Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "",
                                       Optional ByVal ProductCode As String = "", Optional ByVal JobNumber As Integer? = 0,
                                       Optional ByVal OpenComponentsOnly As Boolean = False, Optional ByVal AllowedProcessControls As Integer() = Nothing) As System.Collections.Generic.List(Of Database.Views.JobComponentView)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumer As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOpenComponentsOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAllowedProcessControls As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSkip As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTake As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            SqlParameterJobNumer = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterOpenComponentsOnly = New System.Data.SqlClient.SqlParameter("@OPEN_COMP_ONLY", SqlDbType.Bit)
            SqlParameterAllowedProcessControls = New System.Data.SqlClient.SqlParameter("@ALLOWED_PROC_CONTROLS", SqlDbType.VarChar)
            SqlParameterSkip = New System.Data.SqlClient.SqlParameter("@SKIP", SqlDbType.Int)
            SqlParameterTake = New System.Data.SqlClient.SqlParameter("@TAKE", SqlDbType.Int)

            Try

                SqlParameterUserCode.Value = UserCode
                SqlParameterClientCode.Value = If(String.IsNullOrWhiteSpace(ClientCode), "", ClientCode)
                SqlParameterDivisionCode.Value = If(String.IsNullOrWhiteSpace(DivisionCode), "", DivisionCode)
                SqlParameterProductCode.Value = If(String.IsNullOrWhiteSpace(ProductCode), "", ProductCode)
                If JobNumber Is Nothing Then JobNumber = 0
                SqlParameterJobNumer.Value = JobNumber
                SqlParameterOpenComponentsOnly.Value = If(OpenComponentsOnly, 1, 0)
                SqlParameterSkip.Value = 0
                SqlParameterTake.Value = 0

                If AllowedProcessControls IsNot Nothing Then

                    SqlParameterAllowedProcessControls.Value = String.Join(",", AllowedProcessControls)

                Else

                    SqlParameterAllowedProcessControls.Value = ""

                End If

                LoadByUserCode = DbContext.Database.SqlQuery(Of Database.Views.JobComponentView)("EXEC [dbo].[advsp_job_component_load_by_user] @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @OPEN_COMP_ONLY, @ALLOWED_PROC_CONTROLS, @USER_CODE, @SKIP, @TAKE;",
                                                                                                 SqlParameterClientCode,
                                                                                                 SqlParameterDivisionCode,
                                                                                                 SqlParameterProductCode,
                                                                                                 SqlParameterJobNumer,
                                                                                                 SqlParameterOpenComponentsOnly,
                                                                                                 SqlParameterAllowedProcessControls,
                                                                                                 SqlParameterUserCode,
                                                                                                 SqlParameterSkip,
                                                                                                 SqlParameterTake).ToList

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        'Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal OpenJobComponentsOnly As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobComponentView)

        '    'objects
        '    Dim JobNumbers As Integer() = Nothing
        '    Dim SQL As String = ""

        '    Try

        '        If (From Entity In AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, UserCode) _
        '            Select Entity).Any Then

        '            SQL = String.Format("SELECT JOB_NUMBER FROM dbo.JOB_LOG JL " & _
        '                                "JOIN dbo.SEC_CLIENT SC ON SC.CL_CODE = JL.CL_CODE AND SC.DIV_CODE = JL.DIV_CODE AND SC.PRD_CODE = JL.PRD_CODE " & _
        '                                "WHERE SC.[USER_ID] = '{0}'", UserCode)

        '            Try

        '                JobNumbers = DbContext.Database.SqlQuery(Of Integer)(SQL).ToArray

        '            Catch ex As Exception
        '                JobNumbers = Nothing
        '            End Try

        '            If OpenJobComponentsOnly Then

        '                LoadByUserCode = From JobComponent In LoadAllOpen(DbContext) _
        '                                 Where JobNumbers.Contains(JobComponent.JobNumber) _
        '                                 Select JobComponent

        '            Else

        '                LoadByUserCode = From JobComponent In Load(DbContext) _
        '                                 Where JobNumbers.Contains(JobComponent.JobNumber) _
        '                                 Select JobComponent

        '            End If

        '        Else

        '            If OpenJobComponentsOnly Then

        '                LoadByUserCode = LoadAllOpen(DbContext)

        '            Else

        '                LoadByUserCode = Load(DbContext)

        '            End If

        '        End If

        '    Catch ex As Exception
        '        LoadByUserCode = Nothing
        '    End Try

        'End Function
        Public Function LoadAllOpen(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobComponentView)

            LoadAllOpen = From JobComponentView In DbContext.GetQuery(Of Database.Views.JobComponentView)
                          Where JobComponentView.JobProcessControl <> 12 AndAlso
                                JobComponentView.JobProcessControl <> 6
                          Select JobComponentView

        End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Database.Views.JobComponentView

            Try

                LoadByJobNumberAndJobComponentNumber = (From JobComponent In DbContext.GetQuery(Of Database.Views.JobComponentView)
                                                        Where JobComponent.JobNumber = JobNumber AndAlso
                                                              JobComponent.JobComponentNumber = JobComponentNumber
                                                        Select JobComponent).SingleOrDefault

            Catch ex As Exception
                LoadByJobNumberAndJobComponentNumber = Nothing
            End Try

        End Function
        Public Function LoadByJobComponentID(ByVal DbContext As Database.DbContext, ByVal JobComponentID As Integer) As Database.Views.JobComponentView

            Try

                LoadByJobComponentID = (From JobComponent In DbContext.GetQuery(Of Database.Views.JobComponentView)
                                        Where JobComponent.ID = JobComponentID
                                        Select JobComponent).SingleOrDefault

            Catch ex As Exception
                LoadByJobComponentID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.JobComponentView)

            Load = From JobComponentView In DbContext.GetQuery(Of Database.Views.JobComponentView)
                   Select JobComponentView

        End Function

#End Region

    End Module

End Namespace
