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

