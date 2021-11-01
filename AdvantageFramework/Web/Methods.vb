Namespace Web

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum DeepLinkType

            Internal = 1
            External = 2
            ClientPortalExternal = 3

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " API Querystring "

        Public Function GetProofingURL(ByVal SecuritySession As AdvantageFramework.Security.Session,
                                       ByVal AlertID As Integer,
                                       ByVal DocumentID As Integer?,
                                       ByVal ProofingExternalReviewerID As Integer?,
                                       ByRef ErrorMessage As String) As String

            Dim URL As String = String.Empty

            Try

                Dim QueryString As New AdvantageFramework.Web.QueryString(SecuritySession)

                If DocumentID Is Nothing OrElse DocumentID = 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                        DocumentID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT MAX(D.DOCUMENT_ID) FROM DOCUMENTS D WITH(NOLOCK)	INNER JOIN ALERT_ATTACHMENT AA WITH(NOLOCK) ON D.DOCUMENT_ID = AA.DOCUMENT_ID WHERE	AA.ALERT_ID = {0}", AlertID)).SingleOrDefault()

                    End Using

                End If

                QueryString.Page = "Proofing"
                QueryString.AlertID = AlertID
                QueryString.DocumentID = DocumentID

                If ProofingExternalReviewerID IsNot Nothing AndAlso ProofingExternalReviewerID > 0 Then

                    QueryString.ProofingStatusExternalReviewerID = ProofingExternalReviewerID

                Else

                    QueryString.EmployeeCode = SecuritySession.User.EmployeeCode

                End If

                URL = QueryString.ToString() & "&xyz=" & AlertID

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return URL

        End Function

        Public Function GetProofingBaseURL(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As String

            Dim ApiURL As String = String.Empty

            Try

                ApiURL = SecurityDbContext.Database.SqlQuery(Of String)("SELECT PROOFING_URL FROM AGENCY WITH(NOLOCK);").SingleOrDefault

            Catch ex As Exception
                ApiURL = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(ApiURL) = False Then

                'Make sure only one slash between domain and action
                If ApiURL.EndsWith("/") = False Then

                    ApiURL &= "/"

                End If

            End If

            Return ApiURL

        End Function
        'Public Function GenerateAPIQueryString(ByVal InputQueryString As AdvantageFramework.Web.QueryString) As AdvantageFramework.Web.QueryString

        '    Dim OutputQueryString As New AdvantageFramework.Web.QueryString

        '    Return OutputQueryString

        'End Function
        'Public Function ParseAPIQueryString(ByVal InputQueryString As AdvantageFramework.Web.QueryString) As AdvantageFramework.Web.QueryString

        '    Dim OutputQueryString As New AdvantageFramework.Web.QueryString

        '    Return OutputQueryString

        'End Function

#End Region

#Region " Deeplink "
        Public Function BuildDeepLink(ByVal Session As AdvantageFramework.Security.Session,
                                      ByVal Type As DeepLinkType, ByVal QueryString As String) As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Return BuildDeepLink(DbContext, Type, QueryString)

            End Using

        End Function
        Public Function BuildDeepLink(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal Type As DeepLinkType,
                                      ByVal QueryString As String) As String

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Return BuildDeepLink(Agency, Type, QueryString)

        End Function
        Public Function BuildDeepLink(ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                      ByVal Type As DeepLinkType,
                                      ByVal QueryString As String) As String

            Dim Value As String = String.Empty
            Dim DeepLinkString As String = String.Empty ' Me.Encrypt(DeepLinkQueryString)
            Dim WebvantageURL As String = ""
            Dim ClientPortalURL As String = ""

            If Agency.WebvantageURL IsNot Nothing Then WebvantageURL = Agency.WebvantageURL
            If Agency.ClientPortalURL IsNot Nothing Then ClientPortalURL = Agency.ClientPortalURL

            WebvantageURL = FormatAgencyWebvantageURL(WebvantageURL)
            ClientPortalURL = FormatAgencyWebvantageURL(ClientPortalURL)

            DeepLinkString = DeepLinkString.Replace(WebvantageURL, "").Replace(ClientPortalURL, "")
            DeepLinkString = EncryptDeepLinkQueryString(QueryString)

            Select Case Type

                Case DeepLinkType.External

                    If String.IsNullOrWhiteSpace(WebvantageURL) = False Then

                        Value = String.Format("{0}/NewApp?dl={1}", WebvantageURL, DeepLinkString)

                    End If

                Case DeepLinkType.ClientPortalExternal

                    If String.IsNullOrWhiteSpace(ClientPortalURL) = False Then

                        Value = String.Format("{0}/NewApp?dl={1}", ClientPortalURL, DeepLinkString)

                    End If

            End Select

            Return Value

        End Function

#End Region

#Region " Encryption "
        Public Function EncryptDeepLinkQueryString(ByVal QueryString As String) As String

            Return AdvantageFramework.Security.Encryption.RijndaelSimpleEncrypt(QueryString) & "A"

        End Function
        Public Function DecryptDeepLinkString(ByVal DeepLink As String) As String

            Return AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt(DeepLink.Substring(0, DeepLink.Length - 1))

        End Function
#End Region

#Region " Helpers "
        Private Function FormatAgencyWebvantageURL(ByVal Url As String) As String

            Dim FormattedURL As String = Url

            If FormattedURL.EndsWith("/") = True Then FormattedURL = FormattedURL.Substring(0, FormattedURL.Length - 1)

            If FormattedURL.ToLower.StartsWith("http://") = False AndAlso FormattedURL.ToLower.StartsWith("https://") = False Then

                FormattedURL = "http://" & FormattedURL

            End If

            Return FormattedURL

        End Function

#End Region

#End Region

    End Module

End Namespace
