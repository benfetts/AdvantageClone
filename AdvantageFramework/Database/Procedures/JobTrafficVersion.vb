Namespace Database.Procedures.JobTrafficVersion

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

        'Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficVersion)

        '    Load = From JobTrafficVersion In DbContext.GetQuery(Of Database.Entities.JobTrafficVersion) _
        '           Select JobTrafficVersion

        'End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext,
                                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer,
                                                             ByVal IncludeVersionsCreatedForTemplates As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficVersion)

            If IncludeVersionsCreatedForTemplates = True Then

                LoadByJobNumberAndJobComponentNumber = From JobTrafficVersion In DbContext.GetQuery(Of Database.Entities.JobTrafficVersion)
                                                       Where JobTrafficVersion.JobNumber = JobNumber AndAlso JobTrafficVersion.JobComponentNumber = JobComponentNumber
                                                       Select JobTrafficVersion
            Else

                LoadByJobNumberAndJobComponentNumber = From JobTrafficVersion In DbContext.GetQuery(Of Database.Entities.JobTrafficVersion)
                                                       Where JobTrafficVersion.JobNumber = JobNumber AndAlso JobTrafficVersion.JobComponentNumber = JobComponentNumber _
                                                  AndAlso (JobTrafficVersion.VersionCreatedComment.Contains("Created for template:") = False)
                                                       Select JobTrafficVersion

            End If

        End Function
        Public Function LoadByVersionID(ByVal DbContext As Database.DbContext,
                                                           ByVal VersionID As Integer) As Database.Entities.JobTrafficVersion

            LoadByVersionID = (From JobTrafficVersion In DbContext.GetQuery(Of Database.Entities.JobTrafficVersion)
                               Where JobTrafficVersion.ID = VersionID
                               Select JobTrafficVersion).SingleOrDefault

        End Function
        Public Function Apply(ByVal DbContext As Database.DbContext,
                              ByVal VersionId As Integer,
                              ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer,
                              ByVal ApplyComment As String, ByVal UserCode As String
                              ) As Boolean

            Dim SqlParameterVersionId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterApplyComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVersionId = New System.Data.SqlClient.SqlParameter("@VERSION_ID", SqlDbType.Int)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            SqlParameterApplyComment = New System.Data.SqlClient.SqlParameter("@VER_APPLIED_COMMENT", SqlDbType.VarChar)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)

            SqlParameterVersionId.Value = VersionId
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterApplyComment.Value = ApplyComment
            SqlParameterUserCode.Value = UserCode

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_TrafficScheduleVersion_Apply @USER_CODE, @VERSION_ID, @VER_APPLIED_COMMENT, @JOB_NUMBER, @JOB_COMPONENT_NBR",
                    SqlParameterVersionId, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterApplyComment, SqlParameterUserCode)

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function
        Public Function Copy(ByVal DbContext As Database.DbContext,
                             ByVal UserCode As String,
                             ByVal VersionName As String,
                             ByVal VersionComment As String,
                             ByVal VersionCreatedComment As String,
                             ByVal SourceVersionId As Integer) As Integer

            Dim i As Integer = 0
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVersionName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVersionComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVersionCreatedComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSourceVersionId As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            SqlParameterVersionName = New System.Data.SqlClient.SqlParameter("@VER_NAME", SqlDbType.VarChar)
            SqlParameterVersionComment = New System.Data.SqlClient.SqlParameter("@VER_COMMENT", SqlDbType.VarChar)
            SqlParameterVersionCreatedComment = New System.Data.SqlClient.SqlParameter("@VER_CREATED_COMMENT", SqlDbType.VarChar)
            SqlParameterSourceVersionId = New System.Data.SqlClient.SqlParameter("@SOURCE_VERSION_ID", SqlDbType.Int)

            SqlParameterUserCode.Value = UserCode
            SqlParameterVersionName.Value = VersionName
            SqlParameterVersionComment.Value = VersionComment
            SqlParameterVersionCreatedComment.Value = VersionCreatedComment
            SqlParameterSourceVersionId.Value = SourceVersionId

            Try

                i = DbContext.Database.SqlQuery(Of Integer)("EXEC dbo.usp_wv_TrafficScheduleVersion_Copy @USER_CODE, @VER_NAME, @VER_COMMENT, @VER_CREATED_COMMENT, @SOURCE_VERSION_ID",
                    SqlParameterUserCode, SqlParameterVersionName, SqlParameterVersionComment, SqlParameterVersionCreatedComment, SqlParameterSourceVersionId).FirstOrDefault()

            Catch ex As Exception

                Return -1

            Finally

                Copy = i

            End Try

        End Function
        Public Function Delete(ByVal DbContext As Database.DbContext,
                               ByVal VersionId As Integer) As Boolean

            Dim SqlParameterVersionId As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterVersionId = New System.Data.SqlClient.SqlParameter("@VERSION_ID", SqlDbType.Int)

                SqlParameterVersionId.Value = VersionId

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.usp_wv_TrafficScheduleVersion_Delete @VERSION_ID", SqlParameterVersionId)
                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function
        Public Function Delete(ByVal DbContext As Database.DbContext,
                               ByVal JobTrafficVersion As AdvantageFramework.Database.Entities.JobTrafficVersion) As Boolean

            Return Delete(DbContext, JobTrafficVersion.ID)

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext,
                               ByVal JobTrafficVersion As AdvantageFramework.Database.Entities.JobTrafficVersion) As Boolean

            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim NewVersionID As Integer = 0

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("USER_CODE", JobTrafficVersion.VersionCreatedByUserCode)
            Dim VersionSequenceNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("VER_SEQ_NBR", JobTrafficVersion.VersionSequenceNumber)
            Dim VersionNameParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("VER_NAME", JobTrafficVersion.VersionName)
            Dim VersionCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("VER_COMMENT", JobTrafficVersion.VersionComment)
            Dim VersionCreatedCommentParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("VER_CREATED_COMMENT", JobTrafficVersion.VersionCreatedComment)
            Dim JobNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("JOB_NUMBER", JobTrafficVersion.JobNumber)
            Dim JobComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("JOB_COMPONENT_NBR", JobTrafficVersion.JobComponentNumber)

            Try

                If JobTrafficVersion.DbContext Is Nothing Then JobTrafficVersion.DbContext = DbContext

                'DbContext.JobTrafficVersions.Add(JobTrafficVersion)
                ErrorText = JobTrafficVersion.ValidateEntity(IsValid)

                If IsValid = True Then

                    'DbContext.Database.ExecuteSqlCommand("JobTrafficVersionInsert", UserCodeParameter, VersionSequenceNumberParameter, VersionNameParameter, _
                    '                              VersionCommentParameter, VersionCreatedCommentParameter, JobNumberParameter, JobComponentNumberParameter)

                    NewVersionID = DbContext.Database.SqlQuery(Of Integer)("EXEC usp_wv_TrafficScheduleVersion_Insert @USER_CODE, @VER_SEQ_NBR, @VER_NAME, @VER_COMMENT, @VER_CREATED_COMMENT, @JOB_NUMBER, @JOB_COMPONENT_NBR", _
                                                       UserCodeParameter, VersionSequenceNumberParameter, VersionNameParameter, VersionCommentParameter, VersionCreatedCommentParameter, JobNumberParameter, JobComponentNumberParameter).FirstOrDefault()

                    JobTrafficVersion.ID = NewVersionID

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
        Public Function Update(ByVal DbContext As Database.DbContext, _
                               ByVal VersionID As Integer, _
                               ByVal VersionName As String, _
                               ByVal VersionComment As String, _
                               ByVal IsActive As Boolean) As Boolean

            Dim JobTrafficVersion As AdvantageFramework.Database.Entities.JobTrafficVersion = Nothing
            JobTrafficVersion = LoadByVersionID(DbContext, VersionID)

            If Not JobTrafficVersion Is Nothing Then

                JobTrafficVersion.VersionName = VersionName
                JobTrafficVersion.VersionComment = VersionComment
                JobTrafficVersion.VersionIsActive = IsActive

                Return Update(DbContext, JobTrafficVersion)

            Else

                Return False

            End If

        End Function
        Public Function Update(ByVal DbContext As Database.DbContext, _
                               ByVal JobTrafficVersion As AdvantageFramework.Database.Entities.JobTrafficVersion) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If JobTrafficVersion.DbContext Is Nothing Then JobTrafficVersion.DbContext = DbContext

                DbContext.UpdateObject(JobTrafficVersion)
                ErrorText = JobTrafficVersion.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
