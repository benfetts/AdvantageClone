Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MvcCodeRouting.Web.Mvc
Imports System.Data.SqlClient
Imports Microsoft.AspNet.SignalR

Namespace Controllers.ProjectManagement
    <Serializable()>
    Public Class ProofingController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/Proofing/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.ProjectManagement.ProofingController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Initialize "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.ProjectManagement.ProofingController(Me.SecuritySession)

        End Sub

#End Region
#Region " Razor Views "
        Public Function FeedbackSummary() As ActionResult

            Return View()

        End Function
        Public Function _FeedbackSummaryGrid() As ActionResult

            Return PartialView()

        End Function
        Public Function SyncTool() As ActionResult


            Dim Backup As AdvantageFramework.ConceptShare.ThreadableAssetBackup = New AdvantageFramework.ConceptShare.ThreadableAssetBackup(Me.SecuritySession)
            Backup.BackupAllReviews()

            Return View()

        End Function
        Public Function _SyncToolGrid() As ActionResult

            Return PartialView()

        End Function
        Public Function ExternalReviewers() As ActionResult

            Dim List As Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer) = Nothing

            Return View(List)

        End Function
        Public Function _ExternalReviewersGrid() As ActionResult

            Return PartialView()

        End Function
        Public Function _ProofsByJobGrid() As ActionResult

            Return PartialView()

        End Function
        Public Function ProofsByJob() As ActionResult

            Return View()

        End Function

#End Region
#Region " Methods "

        <HttpGet>
        Public Function TryGetFeedbackSummary(ByVal AlertID As Integer,
                                              ByVal ProjectID As Integer,
                                              ByVal ReviewID As Integer,
                                              ByVal ID As Integer,
                                              ByVal EmailAddress As String) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Key As String = String.Empty

            Try

                If ProjectID > 0 AndAlso ReviewID > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                        If ConceptShareConnection IsNot Nothing Then

                            Dim Filename As String = String.Empty
                            Dim PdfBytes As Byte()
                            Dim Alert As AdvantageFramework.Database.Entities.Alert

                            Alert = Nothing
                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByConceptShareReviewID(DbContext, ReviewID)

                            If Alert IsNot Nothing Then

                                Filename = String.Format("{0}_Feedback Summary_{1}-{2}-{3}-{4}{5}{6}.pdf",
                                                            Alert.Subject,
                                                            Now.Year.ToString(),
                                                            Now.Month.ToString().PadLeft(2, "0"),
                                                            Now.Day.ToString().PadLeft(2, "0"),
                                                            Now.Hour.ToString().PadLeft(2, "0"),
                                                            Now.Minute.ToString().PadLeft(2, "0"),
                                                            Now.Second.ToString().PadLeft(2, "0"))

                            End If

                            Filename = AdvantageFramework.StringUtilities.RemoveIllegalFilenameIllegalCharacters(Filename)

                            Server.ScriptTimeout = 3200

                            If String.IsNullOrWhiteSpace(EmailAddress) = True Then 'Download

                                PdfBytes = AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(ConceptShareConnection, ProjectID, ReviewID)

                                If PdfBytes IsNot Nothing Then

                                    Success = DownloadFeedbackSummaryBytesToTemp(DbContext, PdfBytes, Filename, Key)

                                End If

                            Else

                                Dim EmailSyncThread = New Thread(Sub() AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(ConceptShareConnection,
                                                                                                         ProjectID,
                                                                                                         ReviewID,
                                                                                                         EmailAddress,
                                                                                                         Filename, AlertID))

                                EmailSyncThread.Start()

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Success = Success, .Key = Key, .Message = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function DownloadFeedbackSummary(ByVal Key As String) As FileResult

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim ByteFile As Byte() = Nothing
            Dim FileExists As Boolean = False
            Dim FullPath As String = String.Empty

            Try

                If String.IsNullOrWhiteSpace(Key) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Try

                            FullPath = AdvantageFramework.Security.Encryption.Decrypt(Key)

                        Catch ex As Exception
                            FullPath = String.Empty
                        End Try

                        If String.IsNullOrWhiteSpace(FullPath) = False Then

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then

                                Dim FileStream As System.IO.FileStream = Nothing
                                Dim BinaryReader As System.IO.BinaryReader = Nothing

                                FileStream = New System.IO.FileStream(FullPath, IO.FileMode.OpenOrCreate)
                                BinaryReader = New System.IO.BinaryReader(FileStream)
                                ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FullPath).Length)

                                If ByteFile IsNot Nothing Then

                                    FileContentResult = Me.File(ByteFile, "application/pdf")
                                    FileContentResult.FileDownloadName = FullPath.Substring(FullPath.LastIndexOf("\") + 1, FullPath.Length - FullPath.LastIndexOf("\") - 1)

                                End If
                                'If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                '    FileContentResult = Me.File(ByteFile, Document.MIMEType)

                                '    FileContentResult.FileDownloadName = Document.FILENAME

                                'End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
            End Try

            Return FileContentResult

        End Function
        Private Function DownloadFeedbackSummaryBytesToTemp(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal ByteFile() As Byte,
                                                            ByRef FileName As String,
                                                            ByRef Key As String) As Boolean

            'objects
            Dim Downloaded As Boolean = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim File As String = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim Counter As Integer = 0
            Dim FileExtension As String = "pdf"
            Dim TempDirectory As String = HttpContext.Request.PhysicalApplicationPath & "TEMP\"

            Try

                If ByteFile IsNot Nothing AndAlso ByteFile.Length > 0 Then

                    FileName = TempDirectory & FileName

                    Try

                        FileWriter = New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(ByteFile, 0, ByteFile.Length)

                        Downloaded = True

                        Key = AdvantageFramework.Security.Encryption.Encrypt(FileName)

                    Catch ex As Exception
                        Downloaded = False
                    End Try
                    If FileWriter IsNot Nothing Then

                        FileWriter.Close()

                    End If

                End If

            Catch ex As Exception
                Downloaded = False
            Finally
                DownloadFeedbackSummaryBytesToTemp = Downloaded
            End Try

            Return DownloadFeedbackSummaryBytesToTemp

        End Function
        <HttpPost>
        Public Function StartAssetBackup() As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty

            Dim Backup As AdvantageFramework.ConceptShare.ThreadableAssetBackup = New AdvantageFramework.ConceptShare.ThreadableAssetBackup(Me.SecuritySession)
            Backup.BackupAllReviews()

            Return Json(New With {.Success = Success,
                                  .ErrorMessage = ErrorMessage})

        End Function
        <HttpGet>
        Public Function LoadAssetBackupStats() As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim Stats As AdvantageFramework.ConceptShare.BackupStats = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Stats = AdvantageFramework.ConceptShare.LoadAssetBackupStats(DbContext, Me.SecuritySession, ErrorMessage)

            End Using

            Return MaxJson(New With {.Success = Success,
                                     .Stats = Stats,
                                     .ErrorMessage = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function MarkAsFailedFeedbackSummary(ByVal AlertID As Integer, ByVal ReviewID As Integer, ByVal ID As Integer) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Success = MarkAsFailed(DbContext, ID, ErrorMessage)

            End Using

            Return MaxJson(New With {.Success = Success,
                                     .ErrorMessage = ErrorMessage})

        End Function
        <HttpPost>
        Public Function MarkAsRecivedFeedbackSummary(ByVal AlertID As Integer, ByVal ReviewID As Integer, ByVal ID As Integer) As JsonResult

            Dim Success As Boolean = True
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Success = MarkAsRecieved(DbContext, ID, ErrorMessage)

            End Using

            Return MaxJson(New With {.Success = Success,
                                     .ErrorMessage = ErrorMessage})

        End Function
        Private Function MarkAsRecieved(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ID As Integer,
                                        ByRef ErrorMessage As String) As Boolean

            Dim Marked As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CS_FEEDBACK_LOG WITH(ROWLOCK) SET BackedUp = 1, BackupDate = GETDATE(), EmployeeCode='{1}' WHERE ID = {0};", ID, Me.SecuritySession.User.EmployeeCode))

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Marked = False
            End Try

            Return Marked

        End Function
        Private Function MarkAsFailed(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal ID As Integer,
                                        ByRef ErrorMessage As String) As Boolean

            Dim Marked As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CS_FEEDBACK_LOG WITH(ROWLOCK) SET BackUpFailed = 1, BackupDate = NULL, BackedUp = NULL WHERE ID = {0};", ID, Me.SecuritySession.User.EmployeeCode))

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Marked = False
            End Try

            Return Marked

        End Function
        <HttpGet>
        Public Function FeedbackSummaryLogGet() As JsonResult

            Dim Logs As Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog) = Nothing
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Logs = AdvantageFramework.ConceptShare.LoadFeedbackSummaryLog(DbContext, ErrorMessage)

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Logs = Nothing
            End Try

            ViewData("ErrorMessage") = ErrorMessage

            Return MaxJson(Logs, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function FeedbackSummaryLogUpdate(ByVal models As String) As JsonResult

            Dim Logs As Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog) = Nothing
            Dim ErrorMessages As New Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty

            If String.IsNullOrWhiteSpace(models) = False Then

                Try

                    Logs = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog))(models)

                Catch ex As Exception
                    Logs = Nothing
                    ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
                End Try
                If Logs IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        For Each Log As AdvantageFramework.ConceptShare.ConceptShareFeedbackLog In Logs




                        Next

                    End Using

                End If

            End If

            Return MaxJson(New With {.Logs = Logs,
                                     .ErrorMessages = ErrorMessages})

        End Function

        <HttpGet>
        Public Function ExternalReviewersGet() As JsonResult

            Dim ProofingExternalReviewers As Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer) = Nothing
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    ProofingExternalReviewers = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.Load(DbContext).ToList()

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                ProofingExternalReviewers = Nothing
            End Try

            If ProofingExternalReviewers Is Nothing Then

                ProofingExternalReviewers = New List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)

            End If

            ViewData("ErrorMessage") = ErrorMessage

            Return MaxJson(ProofingExternalReviewers, JsonRequestBehavior.AllowGet)

        End Function
        <AcceptVerbs("POST")>
        Public Function ExternalReviewersUpdate(ByVal models As String) As JsonResult

            Dim ExternalReviewers As Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)
            Dim ErrorMessages As New Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty
            Dim ExternalReviewerEntity As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing
            Dim CanUpdate As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExistingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing
            Dim InternalError As String = String.Empty
            Dim HasActiveChange As Boolean = False

            If String.IsNullOrWhiteSpace(models) = False Then

                ExternalReviewers = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer))(models)

                If ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        For Each ExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer In ExternalReviewers

                            ErrorMessage = String.Empty
                            CanUpdate = True
                            Employee = Nothing
                            InternalError = String.Empty
                            ExternalReviewerEntity = Nothing
                            ExistingExternalReviewer = Nothing

                            ExternalReviewerEntity = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByID(DbContext, ExternalReviewer.ID)

                            If ExternalReviewerEntity IsNot Nothing Then

                                ExternalReviewerEntity.Name = ExternalReviewer.Name

                                If ExternalReviewerEntity.Email <> ExternalReviewer.Email Then 'Only check if email changed

                                    Try

                                        ExistingExternalReviewer = AdvantageFramework.Database.Procedures.ProofingExternalReviewer.LoadByEmailAddress(DbContext, ExternalReviewer.Email)

                                    Catch ex As Exception
                                        ExistingExternalReviewer = Nothing
                                        InternalError = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                        If InternalError.Contains("Sequence contains") = True Then
                                            '   More than one record with same email address
                                            'block? allow?
                                        End If
                                    End Try
                                    If ExistingExternalReviewer IsNot Nothing AndAlso ExistingExternalReviewer.ID <> ExternalReviewerEntity.ID Then

                                        ErrorMessages.Add("Email address already assigned to external reviewer.")
                                        CanUpdate = False

                                    End If
                                    Try

                                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, ExternalReviewer.Email)

                                        If Employee IsNot Nothing Then

                                            If Employee.Email.ToUpper() = ExternalReviewer.Email.ToUpper() OrElse Employee.ReplyToEmail.ToUpper() = ExternalReviewer.Email.ToUpper() Then

                                                CanUpdate = False
                                                ErrorMessages.Add("Email address belongs to an employee.")

                                            End If

                                        End If

                                    Catch ex As Exception
                                        CanUpdate = False
                                    End Try

                                End If
                                If CanUpdate = True Then

                                    ExternalReviewerEntity.Email = ExternalReviewer.Email

                                End If
                                If ExternalReviewerEntity.IsActive <> ExternalReviewer.IsActive Then

                                    HasActiveChange = True

                                End If

                                ExternalReviewerEntity.IsActive = ExternalReviewer.IsActive

                                If CanUpdate = True Then

                                    If AdvantageFramework.Database.Procedures.ProofingExternalReviewer.Update(DbContext, ExternalReviewerEntity, ErrorMessage) = False Then

                                        ErrorMessages.Add(String.Format("Error updating {0}. {1}", ExternalReviewerEntity.Name, ErrorMessage))

                                    End If

                                End If

                            End If

                        Next

                    End Using

                End If

            End If
            If ExternalReviewers Is Nothing Then

                ExternalReviewers = New List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer)

            End If

            Return MaxJson(New With {.ExternalReviewers = ExternalReviewers,
                                     .ErrorMessages = ErrorMessages,
                                     .HasActiveChange = HasActiveChange})

        End Function
        <HttpGet, HttpPost>
        Public Function ExternalReviewersDestroy(ByVal models As Object) As JsonResult

            Dim ExternalReviewers = Me.DeserializeObject(Of Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer))("ID")

            If ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0 Then

                For Each ExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer In ExternalReviewers

                Next

            End If

            Return MaxJson(ExternalReviewers, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet, HttpPost>
        Public Function ExternalReviewersCreate(ByVal models As Object) As JsonResult

            Dim ExternalReviewers = Me.DeserializeObject(Of Generic.List(Of AdvantageFramework.Database.Entities.ProofingExternalReviewer))("ID")

            If ExternalReviewers IsNot Nothing AndAlso ExternalReviewers.Count > 0 Then

                For Each ExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer In ExternalReviewers

                Next

            End If

            Return MaxJson(ExternalReviewers, JsonRequestBehavior.AllowGet)

        End Function

#End Region

    End Class

End Namespace

