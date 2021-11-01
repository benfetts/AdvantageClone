Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports Webvantage.ViewModels

Namespace Controllers

    Public Class ConceptShareController
        Inherits MVCControllerBase

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        <AcceptVerbs("POST")>
        Public Function GetReviewLatestAssetVersionThumbnail(ByVal ReviewID As Integer) As String

            Dim Base64jpeg As String = String.Empty

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing

            If MiscFN.IsClientPortal = False Then

                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            Else

                ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

            End If

            If ConceptShareConnection IsNot Nothing Then

                Try

                    Base64jpeg = String.Format("data:image/jpeg;base64,{0}",
                                                       Convert.ToBase64String(AdvantageFramework.ConceptShare.DownloadReviewBaseAssetImage(ConceptShareConnection, ReviewID)))


                Catch ex As Exception
                    Base64jpeg = String.Empty
                End Try

            End If

            Return Base64jpeg

        End Function

        Public Function Index() As ActionResult

            Return View()

        End Function

#End Region

    End Class

End Namespace