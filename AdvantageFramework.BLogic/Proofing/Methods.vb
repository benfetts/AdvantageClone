Namespace Proofing

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const ProofingSessionKey As String = "gN$uYrs&5X6$a"
        Public Const ConceptShareSessionKey As String = "bLnaNBeJk4y$f"
        Public Const IsClientPortalSessionKey As String = "t%SxGu@G7bAuAz"
        Public Const ShowProofingReviewsSessionKey As String = "urgN$s&YbLnaNBeJk4y$f$a5X6"
        Public Const GroupSecuritySessionKey As String = "m%LyH86Go#c^Y^E9p^R"
        Public Const TimesheetSessionKey As String = "SXUUpMf966c$HH@fzhS"

#End Region

#Region " Enum "

        Public Enum ProofingStatus

            Approved = 1
            Rejected = 2
            Deferred = 3

        End Enum
        Public Enum ExternalReviewerEmailAction

            SendForReview = 1
            NewVersionUploaded = 2

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " List "
        Public Function LoadProofingListByJob(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer?,
                                              ByVal JobComponentNumber As Short?,
                                              ByVal ShowCompleted As Boolean?,
                                              ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary)

            Dim List As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary) = Nothing

            Try

                Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterShowCompleted As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                SqlParameterShowCompleted = New System.Data.SqlClient.SqlParameter("@SHOW_COMPLETED", SqlDbType.Bit)

                If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                    SqlParameterJobNumber.Value = JobNumber

                Else

                    SqlParameterJobNumber.Value = System.DBNull.Value

                End If
                If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                Else

                    SqlParameterJobComponentNumber.Value = System.DBNull.Value

                End If
                If ShowCompleted IsNot Nothing Then

                    SqlParameterShowCompleted.Value = ShowCompleted

                Else

                    SqlParameterShowCompleted.Value = False

                End If

                List = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary)("EXEC [dbo].[advsp_proofing_get_list] @JOB_NUMBER, @JOB_COMPONENT_NBR, @SHOW_COMPLETED;",
                                                                                                                                 SqlParameterJobNumber,
                                                                                                                                 SqlParameterJobComponentNumber,
                                                                                                                                 SqlParameterShowCompleted).ToList

                If List IsNot Nothing Then

                    For Each Item As AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingSummary In List

                        Item.StatusDisplay = (Item.TotalApproved + Item.TotalDeferred + Item.TotalRejected).ToString().PadLeft(2, "0") & "/" & Item.TotalReviewers.ToString.PadLeft(2, "0")

                    Next

                End If

            Catch ex As Exception
                List = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return List

        End Function

#End Region

#Region " External Reviewers "
        Public Function ResetExternalReviewer(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer,
                                              ByVal ProofingExternalReviewerID As Integer?,
                                              ByRef ErrorMessage As String) As Boolean

            Dim Reset As Boolean = True

            Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProofingExternalReviewerID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProofingStatusID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDocumentID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUnset As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            SqlParameterProofingExternalReviewerID = New System.Data.SqlClient.SqlParameter("@PROOFER_X_REVIEWER_ID", SqlDbType.Int)
            SqlParameterProofingStatusID = New System.Data.SqlClient.SqlParameter("@PROOFING_STATUS_ID", SqlDbType.Int)
            SqlParameterDocumentID = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            SqlParameterUnset = New System.Data.SqlClient.SqlParameter("@UNSET", SqlDbType.Bit)

            SqlParameterAlertID.Value = AlertID
            SqlParameterProofingExternalReviewerID.Value = ProofingExternalReviewerID
            SqlParameterProofingStatusID.Value = System.DBNull.Value
            SqlParameterDocumentID.Value = System.DBNull.Value
            SqlParameterUnset.Value = True

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_proofing_external_reviewer_set_status] @ALERT_ID, @PROOFER_X_REVIEWER_ID, @PROOFING_STATUS_ID, @DOCUMENT_ID, @UNSET;",
                                                      SqlParameterAlertID,
                                                      SqlParameterProofingExternalReviewerID,
                                                      SqlParameterProofingStatusID,
                                                      SqlParameterDocumentID,
                                                      SqlParameterUnset)

            Catch ex As Exception
                Reset = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Reset

        End Function
        Public Function SendExternalReviewerEmail(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                                  ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                  ByVal EmailAction As ExternalReviewerEmailAction,
                                                  ByVal AlertID As Integer,
                                                  ByVal ProofingExternalReviewerID As Integer?,
                                                  ByVal OnlyUnMarked As Boolean,
                                                  ByRef ErrorMessages As Generic.List(Of String)) As Boolean

            Dim AtLeastOneSent As Boolean = False
            Dim DocumentID As Integer = 0

            If ErrorMessages Is Nothing Then ErrorMessages = New List(Of String)

            Try

                DocumentID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(DOCUMENT_ID) FROM ALERT_ATTACHMENT AA WITH(NOLOCK) WHERE ALERT_ID = {0};", AlertID)).SingleOrDefault

            Catch ex As Exception
                DocumentID = 0
            End Try

            If DocumentID > 0 Then

                Dim Subject As String = String.Empty
                Dim Body As String = String.Empty
                Dim HtmlEmail As New AdvantageFramework.Email.Classes.HtmlEmail(True, False)
                Dim URL As String = String.Empty
                Dim RandomKey As String = String.Empty
                Dim Sent As Boolean = False
                Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
                Dim TotalEmails As Integer = 0
                Dim EmailsSent As Integer = 0
                Dim EmailsFailed As Integer = 0
                Dim NoEmails As Integer = 0
                Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
                Dim ImageString As String = String.Empty
                Dim ImageBytes As Byte() = Nothing
                Dim ErrorMessage As String = String.Empty
                Dim ProofingExternalReviewers As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer) = Nothing
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim EmployeeName As String = String.Empty
                Dim AgencyName As String = String.Empty
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim JobInfo As Generic.List(Of String) = Nothing
                Dim FileName As String = String.Empty

                Try

                    If OnlyUnMarked = True Then

                        ProofingExternalReviewers = (From Entity In GetExternalReviewersByAlertID(DbContext, AlertID, ProofingExternalReviewerID, ErrorMessage)
                                                     Where Entity.ProofingStatusID Is Nothing OrElse Entity.ProofingStatusID = 0).ToList()


                    Else

                        ProofingExternalReviewers = GetExternalReviewersByAlertID(DbContext, AlertID, ProofingExternalReviewerID, ErrorMessage)

                    End If

                Catch ex As Exception
                    ProofingExternalReviewers = Nothing
                End Try
                If ProofingExternalReviewers IsNot Nothing AndAlso ProofingExternalReviewers.Count > 0 Then

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, DbContext.UserCode)
                    JobInfo = LoadJobInfoForTagListDbContext(DbContext, Alert.JobNumber, Alert.JobComponentNumber)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.FirstName & " " & Employee.LastName

                    End If

                    Try

                        AgencyName = DbContext.Database.SqlQuery(Of String)("SELECT [NAME] FROM AGENCY WITH(NOLOCK);").FirstOrDefault

                    Catch ex As Exception
                        AgencyName = String.Empty
                    End Try

                    If DocumentID > 0 Then

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Document IsNot Nothing Then

                            FileName = Document.FileName

                            Try

                                ImageBytes = Document.Thumbnail

                                If ImageBytes IsNot Nothing Then

                                    ImageString = System.Convert.ToBase64String(ImageBytes, 0, ImageBytes.Length)

                                End If

                            Catch ex As Exception
                                ImageString = String.Empty
                            End Try

                        End If

                    End If
                    For Each Reviewer As AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer In ProofingExternalReviewers

                        ErrorMessage = String.Empty

                        'If ResetExternalReviewer(DbContext, AlertID, Reviewer.ProofingExternalReviewerID, ErrorMessage) = True Then

                        TotalEmails += 1
                        URL = String.Empty

                        If String.IsNullOrWhiteSpace(Reviewer.EmailAddress) = False Then

                            URL = AdvantageFramework.Web.GetProofingURL(SecuritySession, AlertID, DocumentID, Reviewer.ProofingExternalReviewerID, ErrorMessage)

                            HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(True, False)

                            'Build email
                            HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello {0},</span>", Reviewer.Name))
                            HtmlEmail.AddBlankRow()

                            Select Case EmailAction
                                Case ExternalReviewerEmailAction.NewVersionUploaded

                                    Subject = "[Review request] A new version is ready for review."
                                        'HtmlEmail.AddCustomRow("A new version has been uploaded!")

                                Case ExternalReviewerEmailAction.SendForReview

                                    Subject = "[Review request] A proof is ready for review."
                                    'HtmlEmail.AddCustomRow("A proof needs reviewing!")

                            End Select

                            HtmlEmail.AddCustomRow(String.Format("{0} from {1} has included you in the '{2}' proof where your feedback is requested.",
                                                             EmployeeName,
                                                             AgencyName,
                                                             Alert.Subject))
                            HtmlEmail.AddBlankRow()

                            Try

                                If JobInfo IsNot Nothing Then

                                    For Each BitOfInfo As String In JobInfo

                                        HtmlEmail.AddCustomRow(String.Format("{0}<br/>", BitOfInfo))

                                    Next

                                End If

                            Catch ex As Exception
                            End Try

                            Try

                                If Alert.DueDate IsNot Nothing AndAlso IsDate(Alert.DueDate) = True Then

                                    HtmlEmail.AddCustomRow(String.Format("Due date:  {0}<br/>", Alert.DueDate))

                                End If

                            Catch ex As Exception
                            End Try

                            Try

                                ''If String.IsNullOrWhiteSpace(ImageString) = False Then

                                ''    HtmlEmail.AddImageRow(FileName, ImageString)

                                ''End If
                                HtmlEmail.AddLatestVersionsThumbnails(DbContext, Alert.ID)

                            Catch ex As Exception
                            End Try

                            HtmlEmail.AddCustomRow("Please use the button below to launch the proof:")

                            HtmlEmail.AddBlankRow()

                            HtmlEmail.AddButtonLinkRow(URL, "Launch Proof")
                            HtmlEmail.AddCustomRow("If the button above does not work, copy and paste the entire link below into your browser.")
                            HtmlEmail.AddCustomRow(String.Format("<div style='margin: 10px; padding: 20px; width: 450px; border: 1px solid gray 
                                                                  !important; word-break: break-all;'><span style='word-break: break-all;'>{0}</span></div>", URL))
                            HtmlEmail.AddBlankRow()
                            HtmlEmail.AddCustomRow("Thank you!")
                            HtmlEmail.AddBlankRow()
                            HtmlEmail.AddAdvantageLogoImageRow()

                            HtmlEmail.Finish()

                            'Send individual email
                            SendingEmailStatus = Nothing
                            Sent = False

                            Sent = AdvantageFramework.Email.Send(DbContext,
                                                                 SecurityDbContext,
                                                                 HtmlEmail.FormatNameAndEmail(Reviewer.Name, Reviewer.EmailAddress),
                                                                 Subject,
                                                                 HtmlEmail.ToString(AlertID),
                                                                 3,
                                                                 Nothing,
                                                                 True,
                                                                 SendingEmailStatus,
                                                                 ErrorMessage)

                            If Sent = False Then

                                Try

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso
                                                           String.IsNullOrWhiteSpace(SendingEmailStatus.ToString) = False Then

                                        ErrorMessage = SendingEmailStatus.ToString

                                    End If
                                Catch ex As Exception
                                    ErrorMessage = "Email failed to send."
                                End Try

                                If String.IsNullOrWhiteSpace(ErrorMessage) = False AndAlso ErrorMessage.Contains("550 5.1.1") Then

                                    ErrorMessage = AdvantageFramework.Security.Password.BadEmailAddressMessage

                                End If

                                ErrorMessages.Add(ErrorMessage)

                                EmailsFailed += 1

                            Else

                                AtLeastOneSent = True
                                EmailsSent += 1

                            End If

                        Else

                            NoEmails += 1

                        End If

                        'Else

                        '    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        '        ErrorMessages.Add(ErrorMessage)

                        '    End If

                        'End If

                        HtmlEmail = Nothing

                    Next

                End If

            Else

                ErrorMessages.Add("No file to review.")

            End If

            Return AtLeastOneSent

        End Function
        Public Function GetExternalReviewersByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal AlertID As Integer,
                                                      ByVal ProofingExternalReviewerID As Integer?,
                                                      ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer)

            Dim List As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer) = Nothing

            Try

                List = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer)(String.Format("EXEC [dbo].[advsp_proofing_get_external_reviewers_for_assignment] {0}, {1};", AlertID,
                                                                                                                                                       If(ProofingExternalReviewerID IsNot Nothing AndAlso ProofingExternalReviewerID > 0, ProofingExternalReviewerID, "NULL"))).ToList()

            Catch ex As Exception
                List = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If List Is Nothing Then List = New List(Of ViewModels.ProjectManagement.Proofing.ProofingExternalReviewer)

            Return List

        End Function
        Public Function LoadJobInfoForTagListDbContext(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Generic.List(Of String)

            Dim Tags As New Generic.List(Of String)

            Dim Query = (From JobComponent In DbContext.JobComponents
                         Join Job In DbContext.Jobs On JobComponent.JobNumber Equals Job.Number
                         Join Client In DbContext.Clients On Job.ClientCode Equals Client.Code
                         Join Division In DbContext.Divisions On Job.ClientCode Equals Division.ClientCode And Job.DivisionCode Equals Division.Code
                         Join Product In DbContext.Products On Job.ClientCode Equals Product.ClientCode And Job.DivisionCode Equals Product.DivisionCode And Job.ProductCode Equals Product.Code
                         Where JobComponent.JobNumber = JobNumber And JobComponent.Number = JobComponentNumber).FirstOrDefault

            If Query IsNot Nothing Then

                Tags.Add(String.Format("Client:  {0} - {1}", Query.Client.Code, Query.Client.Name))
                Tags.Add(String.Format("Division:  {0} - {1}", Query.Division.Code, Query.Division.Name))
                Tags.Add(String.Format("Product:  {0} - {1}", Query.Product.Code, Query.Product.Name))
                Tags.Add(String.Format("Job:  {0}/{1} - {2}", JobNumber.ToString.PadLeft(6, "0"), JobComponentNumber.ToString.PadLeft(2, "0"), Query.JobComponent.Description))

            End If

            Return Tags

        End Function

#End Region

#Region " Proofing Tool "
        Public Function CanDeleteDocument(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal AlertID As Integer?,
                                          ByVal DocumentID As Integer?) As AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult

            Dim Result As AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult = Nothing

            Try

                If AlertID IsNot Nothing AndAlso DocumentID IsNot Nothing Then

                    Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim DocumentIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                    AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                    DocumentIDSqlParameter = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

                    AlertIDSqlParameter.Value = AlertID
                    DocumentIDSqlParameter.Value = DocumentID

                    Result = DbContext.Database.SqlQuery(Of AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult)("EXEC [dbo].[advsp_proofing_can_delete_document] @ALERT_ID, @DOCUMENT_ID;",
                                                                                             AlertIDSqlParameter, DocumentIDSqlParameter).SingleOrDefault

                Else

                    Result = New AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult
                    Result.CanDelete = 1
                    Result.CanDeleteMessage = String.Empty

                End If

            Catch ex As Exception
                Result = New AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult
                Result.CanDelete = 0
                Result.CanDeleteMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Result

        End Function

        Public Function CheckForTemplateAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal AlertID As Integer,
                                                  ByVal SourceAlertID As Integer?,
                                                  ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_assignment_check_for_template] {0}, {1};",
                                                                   AlertID,
                                                                   If(SourceAlertID Is Nothing OrElse SourceAlertID = 0, "NULL", SourceAlertID.ToString())))

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Success

        End Function
        Public Function MoveToNextState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal AlertID As Integer) As Boolean

            Dim Moved As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Moved = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_proofing_check_move_to_next_state] '{0}', {1}, {2};",
                                                                DbContext.UserCode, AlertID, "NULL")).SingleOrDefault

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Moved

        End Function
        Public Function IsProof(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Boolean

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CASE WHEN A.ALERT_CAT_ID = 79 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END FROM ALERT A WITH(NOLOCK) WHERE A.ALERT_ID = {0};", AlertID)).SingleOrDefault()

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function GetExternalReviewersList(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal AlertID As Integer,
                                                 ByVal SearchText As String,
                                                 ByVal ShowAll As Short?,
                                                 ByVal ErrorMessage As String) As Generic.List(Of AdvantageFramework.ViewModels.Desktop.ExternalReviewerViewModel)

            Dim ExternalReviewers As Generic.List(Of AdvantageFramework.ViewModels.Desktop.ExternalReviewerViewModel) = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SearchTextSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ShowAllSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            SearchTextSqlParameter = New System.Data.SqlClient.SqlParameter("@TEXT", SqlDbType.VarChar)
            ShowAllSqlParameter = New System.Data.SqlClient.SqlParameter("@SHOW_ALL", SqlDbType.SmallInt)

            AlertIDSqlParameter.Value = AlertID

            If String.IsNullOrWhiteSpace(SearchText) = True Then

                SearchTextSqlParameter.Value = DBNull.Value

            Else

                SearchTextSqlParameter.Value = SearchText

            End If
            If ShowAll Is Nothing OrElse ShowAll = 0 Then

                ShowAllSqlParameter.Value = DBNull.Value

            Else

                ShowAllSqlParameter.Value = ShowAll

            End If

            Try

                ExternalReviewers = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Desktop.ExternalReviewerViewModel)("EXEC [dbo].[advsp_proofing_load_external_reviewers] @ALERT_ID, @TEXT, @SHOW_ALL;",
                                                                                                                                    AlertIDSqlParameter,
                                                                                                                                    SearchTextSqlParameter,
                                                                                                                                    ShowAllSqlParameter).ToList()

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                ExternalReviewers = Nothing
            End Try

            If ExternalReviewers Is Nothing Then ExternalReviewers = New List(Of ViewModels.Desktop.ExternalReviewerViewModel)

            Return ExternalReviewers

        End Function
        Public Function GetCurrentProofersList(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal AlertID As Integer,
                                               ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.Proofing.Classes.CurrentProofers)

            Dim AllProofers As Generic.List(Of AdvantageFramework.Proofing.Classes.CurrentProofers) = Nothing
            Dim Proofers As Generic.List(Of AdvantageFramework.Proofing.Classes.CurrentProofers) = Nothing
            Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDocumentId As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterDocumentId = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

                SqlParameterAlertId.Value = AlertID
                SqlParameterDocumentId.Value = DBNull.Value

                AllProofers = DbContext.Database.SqlQuery(Of AdvantageFramework.Proofing.Classes.CurrentProofers)("EXEC [dbo].[advsp_proofing_get_approvals_list] @ALERT_ID, @DOCUMENT_ID;",
                                                                               SqlParameterAlertId,
                                                                               SqlParameterDocumentId).ToList

            Catch ex As Exception
                AllProofers = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If AllProofers IsNot Nothing Then

                Proofers = (From Entity In AllProofers
                            Where Entity.IsCurrentState = True
                            Select Entity).ToList

            Else

                Proofers = New List(Of AdvantageFramework.Proofing.Classes.CurrentProofers)

            End If

            Return Proofers

        End Function
        Public Function CanComplete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal UserCode As String,
                                    ByVal EmployeeCode As String,
                                    ByVal AlertID As Integer,
                                    ByRef ErrorMessage As String) As AdvantageFramework.Proofing.Classes.ProofingCanCompleteResult

            Dim EmployeeCanComplete As Boolean = True
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing
            Dim Result As AdvantageFramework.Proofing.Classes.ProofingCanCompleteResult = Nothing

            Try

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)

                SqlParameterUserCode.Value = UserCode
                If String.IsNullOrWhiteSpace(EmployeeCode) = False Then
                    SqlParameterEmployeeCode.Value = EmployeeCode
                Else
                    SqlParameterEmployeeCode.Value = System.DBNull.Value
                End If
                SqlParameterAlertId.Value = AlertID

                Result = DbContext.Database.SqlQuery(Of AdvantageFramework.Proofing.Classes.ProofingCanCompleteResult)("EXEC [dbo].[advsp_proofing_can_complete] @USER_CODE, @EMP_CODE, @ALERT_ID;",
                                                                                    SqlParameterUserCode,
                                                                                    SqlParameterEmployeeCode,
                                                                                    SqlParameterAlertId).SingleOrDefault

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                EmployeeCanComplete = False
            End Try

            Return Result

        End Function
        Public Function ResetStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal AlertID As Integer,
                                    ByRef ErrorMessage As String) As Boolean

            Dim StatusReset As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_proofing_reset_approval] '{0}', {1}, NULL;", DbContext.UserCode, AlertID))

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                StatusReset = False
            End Try

            Return StatusReset

        End Function
        Public Function GetProofingURL(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                       ByVal AlertID As Integer,
                                       ByVal DocumentID As Integer?,
                                       ByVal ProofingExternalReviewerID As Integer?,
                                       ByRef ErrorMessage As String) As String

            Return AdvantageFramework.Web.GetProofingURL(SecuritySession, AlertID, DocumentID, ProofingExternalReviewerID, ErrorMessage)

        End Function
        Public Function GetDocument(ByVal QueryString As AdvantageFramework.Web.QueryString,
                                    ByRef ByteFile As Byte(),
                                    ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = False
            Dim ConnectionString As String = QueryString.ConnectionString
            Dim UserCode As String = QueryString.UserCode
            Dim AlertID As Integer = QueryString.AlertID
            Dim DocumentID As Integer = QueryString.DocumentID
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileExists As Boolean = False

            ByteFile = Nothing

            If String.IsNullOrWhiteSpace(ConnectionString) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Agency IsNot Nothing AndAlso Document IsNot Nothing Then

                        If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                            If ByteFile IsNot Nothing Then

                                Success = True

                            End If

                        End If

                    End If

                End Using

            End If

            Return Success

        End Function

#End Region

#Region " Private "
        Private Function GetProofingBaseURL(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As String

            Return AdvantageFramework.Web.GetProofingBaseURL(SecurityDbContext)

        End Function

#End Region

#Region " Application "

        Public Function IsConceptShareActive(ByRef SecuritySession As AdvantageFramework.Security.Session,
                                             ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal IsClientPortal As Boolean) As Boolean

            Dim ConceptShareIsActive As Boolean = False

            Try

                ConceptShareIsActive = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS BIT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'CS_ENABLED';").SingleOrDefault

            Catch ex As Exception
                ConceptShareIsActive = False
            End Try
            If ConceptShareIsActive = True Then

                ConceptShareIsActive = False

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        Dim ConceptShareAccountUser As AdvantageFramework.ConceptShareAPI.AccountUser = Nothing
                        Dim ConceptShareUser As AdvantageFramework.ConceptShareAPI.User = Nothing

                        If IsClientPortal = False Then

                            Dim Employee As AdvantageFramework.Database.Views.Employee

                            Employee = Nothing
                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SecuritySession.User.EmployeeCode)

                            If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID IsNot Nothing AndAlso Employee.ConceptShareUserID > 0 Then

                                ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, Employee, ConceptShareUser)

                                If ConceptShareAccountUser IsNot Nothing AndAlso ConceptShareAccountUser.IsActive = True Then

                                    ConceptShareIsActive = True

                                End If

                            End If

                        Else

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                Dim ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser

                                ClientPortalUser = Nothing
                                ClientPortalUser = New AdvantageFramework.Security.Classes.ClientPortalUser(AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(SecurityDbContext, SecuritySession.ClientPortalUser.ClientContactID))

                                If ClientPortalUser IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID > 0 Then

                                    ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, SecurityDbContext, ClientPortalUser, ConceptShareUser)

                                    If ConceptShareAccountUser IsNot Nothing AndAlso ConceptShareAccountUser.IsActive = True Then

                                        ConceptShareIsActive = True

                                    End If

                                End If

                            End Using

                        End If

                    End Using

                Catch ex As Exception
                    ConceptShareIsActive = False
                End Try

            End If

            Return ConceptShareIsActive

        End Function
        Public Function IsProofingToolActive(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                             ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal IsClientPortal As Boolean) As Boolean

            Dim ProofingIsActive As Boolean = False
            Dim URL As String = String.Empty
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim LicenseKey As String = String.Empty
            Dim ProofingInfo As AdvantageFramework.Proofing.Classes.ProofingInfo = Nothing
            Dim AgencyName As String = String.Empty
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Try

                ProofingInfo = DbContext.Database.SqlQuery(Of AdvantageFramework.Proofing.Classes.ProofingInfo)("SELECT [LicenseKey] = LICENSE_KEY, [URL] = PROOFING_URL FROM AGENCY WITH(NOLOCK);").SingleOrDefault()

            Catch ex As Exception
                ProofingInfo = Nothing
            End Try
            If ProofingInfo IsNot Nothing Then

                If String.IsNullOrWhiteSpace(ProofingInfo.URL) = False Then

                    If String.IsNullOrWhiteSpace(ProofingInfo.LicenseKey) = False Then

                        LicenseKey = AdvantageFramework.Security.LicenseKey.Read(ProofingInfo.LicenseKey,
                                                                                 LicenseKeyDate,
                                                                                 DaysUntilFileExpires,
                                                                                 DaysUntilKeyExpires,
                                                                                 PowerUsersQuantity,
                                                                                 WVOnlyUsersQuantity,
                                                                                 ClientPortalUsersQuantity,
                                                                                 AgencyName,
                                                                                 DatabaseID,
                                                                                 MediaToolsUsersQuantity,
                                                                                 APIUsersQuantity,
                                                                                 EnableProofingTool,
                                                                                 ErrorMessage)

                        ProofingIsActive = EnableProofingTool

                    End If

                End If

            End If

            Return ProofingIsActive

        End Function

#End Region

#End Region

    End Module

End Namespace
