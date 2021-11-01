Namespace ProjectManagement

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


        Public Function GetQvABilling(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal Group As String, ByVal CampaignID As Integer, ByVal Includeclosedjobs As Integer, ByVal DesktopObject As String) As Generic.List(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary)

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGroup As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeClosedJobs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDesktopObject As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim QouteVsActualBillingSummaryList As Generic.List(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary) = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.VarChar, 6)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComp", SqlDbType.VarChar, 6)
            SqlParameterGroup = New System.Data.SqlClient.SqlParameter("@Group", SqlDbType.VarChar, 10)
            SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@CampaignID", SqlDbType.Int)
            SqlParameterIncludeClosedJobs = New System.Data.SqlClient.SqlParameter("@IncludeClosedJobs", SqlDbType.SmallInt)
            SqlParameterDesktopObject = New System.Data.SqlClient.SqlParameter("@DesktopObject", SqlDbType.VarChar, 20)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 100)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterGroup.Value = Group
            SqlParameterCampaignID.Value = CampaignID
            SqlParameterIncludeClosedJobs.Value = Includeclosedjobs
            If DesktopObject IsNot Nothing Then
                SqlParameterDesktopObject.Value = DesktopObject
            Else
                SqlParameterDesktopObject.Value = ""
            End If
            SqlParameterUserCode.Value = DbContext.UserCode

            QouteVsActualBillingSummaryList = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Classes.QouteVsActualInvoiceBillingSummary) _
                                                    ("exec dbo.usp_wv_getQvABillingSummary @JobNum, @JobComp, @Group, @CampaignID, @IncludeClosedJobs, @DesktopObject, @UserID", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterGroup, SqlParameterCampaignID, SqlParameterIncludeClosedJobs, SqlParameterDesktopObject, SqlParameterUserCode).ToList

            GetQvABilling = QouteVsActualBillingSummaryList

        End Function
        Public Function JobComponentIsMissingRequiredField(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

            Try

                Return DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT 1 FROM [dbo].[advtf_job_template_get] ({0}, {1}) WHERE (IS_REQUIRED = 1) AND (FIELD_VALUE = '' OR FIELD_VALUE IS NULL) AND ITEM_CODE NOT IN ('JOB_LOG.USER_ID');", JobNumber, JobComponentNumber)).ToList().Count() > 0

            Catch ex As Exception

                Return False

            End Try

        End Function
        'Public Function LoadAccountExecutiveLabelFromJobTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateCode As String) As String

        '    Try

        '        Dim Label As String = String.Empty

        '        Label = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL([LABEL], 'Account Executive') FROM [dbo].[JOB_TMPLT_DTL] WHERE [JOB_TMPLT_CODE] = '{0}' AND [ITEM_CODE] = 'JOB_COMPONENT.EMP_CODE';", JobTemplateCode)).FirstOrDefault

        '        If String.IsNullOrWhiteSpace(Label) = True Then Label = "Account Executive"

        '        Return Label

        '    Catch ex As Exception
        '        Return "Account Executive"
        '    End Try

        'End Function
        'Public Function LoadAccountExecutiveLabelFromJobComponent(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String

        '    Try

        '        Dim Label As String = String.Empty

        '        Label = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL([LABEL], 'Account Executive') FROM [dbo].[JOB_TMPLT_DTL] INNER JOIN [dbo].[JOB_COMPONENT] ON JOB_TMPLT_DTL.JOB_TMPLT_CODE = JOB_COMPONENT.JOB_TMPLT_CODE WHERE [ITEM_CODE] = 'JOB_COMPONENT.EMP_CODE' AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNumber)).FirstOrDefault

        '        If String.IsNullOrWhiteSpace(Label) = True Then Label = "Account Executive"

        '        Return Label

        '    Catch ex As Exception
        '        Return "Account Executive"
        '    End Try

        'End Function

        Public Sub LoadJobTemplateLabelsByJobComponent(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                       ByRef Office As String, ByRef Client As String, ByRef Division As String, ByRef Product As String,
                                                       ByRef AccountExecutive As String, ByRef SalesClass As String, ByRef ProcessControl As String, ByRef JobType As String)

            Dim JobTemplateCode As String = String.Empty
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent

            JobComponent = Nothing
            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

            If JobComponent IsNot Nothing Then

                JobTemplateCode = JobComponent.JobTemplateCode

            End If

            LoadLabelsFromJobTemplate(DbContext, JobTemplateCode, Office, Client, Division, Product, AccountExecutive, SalesClass, ProcessControl, JobType)

        End Sub
        Public Sub LoadLabelsFromJobTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTemplateCode As String,
                                             ByRef Office As String, ByRef Client As String, ByRef Division As String, ByRef Product As String,
                                             ByRef AccountExecutive As String, ByRef SalesClass As String, ByRef ProcessControl As String, ByRef JobType As String)

            Dim JobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateDetail)

            JobTemplateDetails = Nothing
            JobTemplateDetails = AdvantageFramework.Database.Procedures.JobTemplateDetail.LoadByJobTemplateCode(DbContext, JobTemplateCode).ToList

            If JobTemplateDetails IsNot Nothing Then

                Try

                    Office = (From Entity In JobTemplateDetails
                              Where Entity.ItemCode = "JOB_LOG.OFFICE_CODE"
                              Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    Office = String.Empty
                End Try
                Try

                    Client = (From Entity In JobTemplateDetails
                              Where Entity.ItemCode = "JOB_LOG.CL_CODE"
                              Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    Client = String.Empty
                End Try
                Try

                    Division = (From Entity In JobTemplateDetails
                                Where Entity.ItemCode = "JOB_LOG.DIV_CODE"
                                Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    Division = String.Empty
                End Try
                Try

                    Product = (From Entity In JobTemplateDetails
                               Where Entity.ItemCode = "JOB_LOG.PRD_CODE"
                               Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    Product = String.Empty
                End Try
                Try

                    AccountExecutive = (From Entity In JobTemplateDetails
                                        Where Entity.ItemCode = "JOB_COMPONENT.EMP_CODE"
                                        Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    AccountExecutive = String.Empty
                End Try
                Try

                    SalesClass = (From Entity In JobTemplateDetails
                                  Where Entity.ItemCode = "JOB_LOG.SC_CODE"
                                  Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    SalesClass = String.Empty
                End Try
                Try

                    ProcessControl = (From Entity In JobTemplateDetails
                                      Where Entity.ItemCode = "JOB_COMPONENT.JOB_PROCESS_CONTRL"
                                      Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    ProcessControl = String.Empty
                End Try
                Try

                    JobType = (From Entity In JobTemplateDetails
                               Where Entity.ItemCode = "JOB_COMPONENT.JT_CODE"
                               Select Entity.Label).FirstOrDefault

                Catch ex As Exception
                    JobType = String.Empty
                End Try


            End If

            If String.IsNullOrWhiteSpace(Office) Then Office = "Office"
            If String.IsNullOrWhiteSpace(Client) Then Client = "Client"
            If String.IsNullOrWhiteSpace(Division) Then Division = "Division"
            If String.IsNullOrWhiteSpace(Product) Then Product = "Product"
            If String.IsNullOrWhiteSpace(AccountExecutive) Then AccountExecutive = "Account Executive"
            If String.IsNullOrWhiteSpace(SalesClass) Then SalesClass = "Sales Class"
            If String.IsNullOrWhiteSpace(ProcessControl) Then ProcessControl = "Process Control"
            If String.IsNullOrWhiteSpace(JobType) Then JobType = "Job Type"

        End Sub

#End Region

    End Module

End Namespace