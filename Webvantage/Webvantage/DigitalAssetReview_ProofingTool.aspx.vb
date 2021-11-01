'THIS PAGE IS USED ONLY FOR PERMALINK/DEEPLINK REDIRECT!
Public Class DigitalAssetReview_ProofingTool
    Inherits Webvantage.BaseChildPage


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property AlertID As Integer
        Get
            If ViewState("AlertID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("AlertID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("AlertID") = value
        End Set
    End Property
    Private Property ConceptShareProjectID As Integer
        Get
            If ViewState("ConceptShareProjectID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareProjectID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareProjectID") = value
        End Set
    End Property
    Private Property ConceptShareReviewID As Integer
        Get
            If ViewState("ConceptShareReviewID") Is Nothing Then
                Return 0
            Else
                Return CType(ViewState("ConceptShareReviewID"), Integer)
            End If
        End Get
        Set(value As Integer)
            ViewState("ConceptShareReviewID") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub DigitalAssetReview_ProofingTool_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.CurrentQuerystring.AlertID > 0 Then Me.AlertID = Me.CurrentQuerystring.AlertID
        If Me.CurrentQuerystring.ConceptShareProjectID > 0 Then Me.ConceptShareProjectID = Me.CurrentQuerystring.ConceptShareProjectID
        If Me.CurrentQuerystring.ConceptShareReviewID > 0 Then Me.ConceptShareReviewID = Me.CurrentQuerystring.ConceptShareReviewID

        If Me.ConceptShareProjectID > 0 AndAlso Me.ConceptShareReviewID > 0 Then

            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

            ConceptShareConnection = Nothing

            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

            If ConceptShareConnection IsNot Nothing Then

                Dim URL As String = String.Empty

                URL = AdvantageFramework.ConceptShare.GetReviewProofingURL(ConceptShareConnection, Me.ConceptShareProjectID, Me.ConceptShareReviewID)

                If String.IsNullOrEmpty(URL) = False Then

                    'If Me.AlertID > 0 Then

                    '    Try

                    '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    '            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    '            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertID)

                    '            If Alert IsNot Nothing Then

                    '                Me.Title = "Proofing Tool: " & AdvantageFramework.StringUtilities.JavascriptSafe(Alert.Subject)

                    '            End If

                    '        End Using

                    '    Catch ex As Exception
                    '    End Try

                    'End If

                    Response.Redirect(URL, True)

                Else

                    Me.ShowMessage("Could not get proofing URL")
                    Me.CloseThisWindow()

                End If

            End If

        End If

    End Sub

#End Region

#End Region

End Class