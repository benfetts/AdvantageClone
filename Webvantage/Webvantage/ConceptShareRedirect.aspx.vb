Public Class ConceptShareRedirect
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("a") IsNot Nothing Then

            Dim AlertID As Integer = 0
            Dim URL As String = String.Empty

            Try

                AlertID = CType(Request.QueryString("a"), Integer)

                If Me.SecuritySession IsNot Nothing Then

                    Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                    Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                    ConceptShareConnection = Nothing
                    ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                    If ConceptShareConnection IsNot Nothing Then

                        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                            If Alert IsNot Nothing AndAlso
                            Alert.ConceptShareProjectID IsNot Nothing AndAlso Alert.ConceptShareReviewID IsNot Nothing Then

                                URL = AdvantageFramework.ConceptShare.GetReviewProofingURL(ConceptShareConnection, Alert.ConceptShareProjectID, Alert.ConceptShareReviewID)

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception
                URL = String.Empty
            End Try
            If String.IsNullOrWhiteSpace(URL) = False Then

                LabelMessage.Visible = False
                Response.Redirect(URL, True)

            End If

        End If

    End Sub

End Class
