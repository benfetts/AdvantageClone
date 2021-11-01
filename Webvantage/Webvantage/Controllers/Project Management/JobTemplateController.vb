Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions

Namespace Controllers.ProjectManagement

    Public Class JobTemplateController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region "View"

        <HttpPost()>
        <AuthorizationFilter(SecurityModuleCode:="ProjectManagement_JobTemplate")>
        Public Function FindAndReplace(ByVal Model As AdvantageFramework.ViewModels.JobTemplate.UpdateJobViewModel) As ActionResult

            'objects
            Dim Validator As Webvantage.cValidations = New cValidations(Me.SecuritySession.ConnectionString)
            Dim Controller As AdvantageFramework.Controller.ProjectManagement.JobTemplateController = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Select Case Model.SelectedCriteria

                    Case "AccountExecutive"

                        If String.IsNullOrWhiteSpace(Model.EmployeeCodeAE) = False Then

                            If Validator.ValidateEmpCode(Model.EmployeeCodeAE) = False Then

                                ModelState.AddModelError("EmployeeCodeAE", "Invalid Account Executive.")

                            End If

                        Else

                            ModelState.AddModelError("EmployeeCodeAE", "Account Executive is required.")

                        End If

                    Case "AlertGroup"

                        If String.IsNullOrWhiteSpace(Model.AlertGroupJob) = False Then

                            If Validator.ValidateEmpCode(Model.AlertGroupJob) = False Then

                                ModelState.AddModelError("AlertGroupJob", "Invalid Alert Group.")

                            End If

                        Else

                            ModelState.AddModelError("AlertGroupJob", "Alert Group is required.")

                        End If

                End Select

            End Using

            If ModelState.IsValid Then

                Controller = New AdvantageFramework.Controller.ProjectManagement.JobTemplateController(Me.SecuritySession)

                If Controller.UpdateJob(Model) = False Then

                    ModelState.AddModelError("InternalError", "Something went wrong.")

                End If

            End If

            If ModelState.IsValid Then

                Return Json(New With {.Success = True, .Data = Model})

            Else


                Return Json(New With {.Success = False, .Data = ModelState.SerializeErrors()})

            End If

        End Function


#End Region

#Region " Methods "

        <AcceptVerbs("POST")>
        Public Function JobComponentIsMissingRequiredField(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String
            Try

                Using oc = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                    Return AdvantageFramework.ProjectManagement.JobComponentIsMissingRequiredField(oc, JobNumber, JobComponentNumber).ToString.ToLower

                End Using

            Catch ex As Exception

                Return AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString)

            End Try

        End Function

        Public Function Index() As ActionResult

            Return View()

        End Function

#End Region

    End Class

End Namespace
