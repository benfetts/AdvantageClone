Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Text.RegularExpressions

Namespace Web

    <Serializable()>
    Public Class DeepLink

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum LinkType

            Internal = 1
            External = 2
            ClientPortalExternal = 3

        End Enum
        Public Enum LinkDisplay

            Rename
            ShowURL
            Blank

        End Enum

#End Region

#Region " Variables "

        Private _QueryString As AdvantageFramework.Web.QueryString
        Private _WebvantageURL As String = String.Empty
        Private _ClientPortalURL As String = String.Empty
        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property URL As String = String.Empty
        Public Property DeepLinkContentType As AdvantageFramework.Web.QueryString.ContentAreaName
        Public Property QueryString As AdvantageFramework.Web.QueryString
            Get
                Return Me._QueryString
            End Get
            Set(value As AdvantageFramework.Web.QueryString)
                Me._QueryString = value
            End Set
        End Property
        Public ReadOnly Property ClientPortalVisible As Boolean
            Get
                Return Not String.IsNullOrWhiteSpace(Me._ClientPortalURL)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Function UrlToInternalLink(ByRef TextString As String, ByRef PlaceHolder As System.Web.UI.WebControls.PlaceHolder, ByVal DisplayAs As LinkDisplay) As Boolean

            Dim HasInternalLink As Boolean = False

            If String.IsNullOrWhiteSpace(TextString) = True OrElse
                    TextString.Contains("<img") = True OrElse
                    TextString.Contains("data:image") = True OrElse
                    TextString.Contains("Click here to navigate") = True Then

                HasInternalLink = False

            Else

                Dim FixedBodyText As String = String.Empty
                Dim Splitter As String = "?dl="
                Dim URL As String = String.Empty
                Dim MatchCollection As System.Text.RegularExpressions.MatchCollection = Nothing
                Dim InternalPage As String = String.Empty
                Dim Counter As Integer = 0
                Dim ReferenceText As String = String.Empty

                Try

                    FixedBodyText = TextString
                    MatchCollection = AdvantageFramework.AlertSystem.GetUrlMatchCollection(FixedBodyText, Me._WebvantageURL, Me._ClientPortalURL)

                    If MatchCollection IsNot Nothing Then

                        Dim ListOpenLiteral As New System.Web.UI.WebControls.Literal
                        Dim ListCloseLiteral As New System.Web.UI.WebControls.Literal

                        ListOpenLiteral.Text = "<ul>"
                        ListCloseLiteral.Text = "</ul>"

                        If PlaceHolder.Visible = True Then PlaceHolder.Controls.Add(ListOpenLiteral)

                        For Each Match In MatchCollection.OfType(Of System.Text.RegularExpressions.Match).Where(Function(m) m.Success = True)

                            InternalPage = String.Empty
                            ReferenceText = String.Empty

                            Try

                                URL = Match.Value

                            Catch ex As Exception
                                URL = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(URL) = False Then

                                Try

                                    InternalPage = URL.Substring(URL.IndexOf(Splitter) + Splitter.Length, URL.Length - URL.IndexOf(Splitter) - Splitter.Length)
                                    InternalPage = AdvantageFramework.Web.DecryptDeepLinkString(InternalPage)

                                Catch ex As Exception
                                    InternalPage = String.Empty
                                End Try

                                If String.IsNullOrWhiteSpace(InternalPage) = False Then

                                    Counter += 1

                                    Select Case DisplayAs
                                        Case LinkDisplay.Blank

                                            ReferenceText = String.Format("Link {0}", Counter.ToString)
                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("&nbsp;"))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>&nbsp;</div>"))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, ReferenceText)

                                        Case LinkDisplay.Rename

                                            ReferenceText = String.Format("Link {0}", Counter.ToString)
                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("{0}", ReferenceText))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", ReferenceText))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, ReferenceText)

                                        Case LinkDisplay.ShowURL

                                            FixedBodyText = FixedBodyText.Replace(URL, String.Format("{0}", URL))
                                            'FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", URL))
                                            If PlaceHolder.Visible = True Then AddInternalLinkToPlaceHolder(PlaceHolder, InternalPage, URL)

                                    End Select

                                    HasInternalLink = True

                                End If

                            End If

                        Next

                        If PlaceHolder.Visible = True Then PlaceHolder.Controls.Add(ListCloseLiteral)

                        TextString = FixedBodyText

                    End If

                Catch ex As Exception
                    HasInternalLink = False
                End Try

            End If

            Return HasInternalLink

        End Function
        Private Function AddInternalLinkToPlaceHolder(ByRef PlaceHolder As System.Web.UI.WebControls.PlaceHolder, ByVal InternalPage As String, ByVal ReferenceText As String) As Boolean
            Try

                InternalPage = InternalPage.Replace(String.Format("{0}/", _WebvantageURL), "").Replace(String.Format("{0}/", _ClientPortalURL), "")

                Dim InternalLinkButton As New System.Web.UI.WebControls.LinkButton
                Dim DivOpenLiteral As New System.Web.UI.WebControls.Literal
                Dim DivCloseLiteral As New System.Web.UI.WebControls.Literal

                DivOpenLiteral.Text = "<li style=""display: block !important;word-break:break-all !important;font-size: 14px !important;"">"
                DivCloseLiteral.Text = "</li>"

                InternalLinkButton.CssClass = "permalink-text"
                InternalLinkButton.OnClientClick = String.Format("OpenRadWindow('', '" & InternalPage & "', 0, 0); return false;")
                InternalLinkButton.Text = ReferenceText
                InternalLinkButton.ToolTip = "Click to open " & ReferenceText

                PlaceHolder.Controls.Add(DivOpenLiteral)
                PlaceHolder.Controls.Add(InternalLinkButton)
                PlaceHolder.Controls.Add(DivCloseLiteral)

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Function
        Public Function Build(ByVal Type As AdvantageFramework.Web.DeepLinkType, ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryString) As String

            Return AdvantageFramework.Web.BuildDeepLink(_SecuritySession, Type, QueryString.ToString(True))

        End Function
        Public Sub BuildJavascriptFromQueryString(ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryString, ByRef WebvantageLink As String, ByRef ClientPortalLink As String)

            WebvantageLink = String.Empty
            ClientPortalLink = String.Empty

            BuildFromQueryString(DeepLinkQueryString, WebvantageLink, ClientPortalLink)

            If String.IsNullOrWhiteSpace(WebvantageLink) = False Then

                WebvantageLink = String.Format("copyToClipboard('{0}');", WebvantageLink)

            End If
            If String.IsNullOrWhiteSpace(ClientPortalLink) = False Then

                ClientPortalLink = String.Format("copyToClipboard('{0}');", ClientPortalLink)

            End If

        End Sub
        Public Sub BuildFromQueryString(ByVal DeepLinkQueryString As AdvantageFramework.Web.QueryString, ByRef WebvantageLink As String, ByRef ClientPortalLink As String)

            WebvantageLink = String.Empty
            ClientPortalLink = String.Empty

            If DeepLinkQueryString IsNot Nothing Then

                Dim Link As String = String.Empty 'DeepLinkQueryString.DeepLink

                Try

                    If String.IsNullOrWhiteSpace(DeepLinkQueryString.Page) = False Then

                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, Me._WebvantageURL, "", RegexOptions.IgnoreCase)
                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, Me._ClientPortalURL, "", RegexOptions.IgnoreCase)

                        If DeepLinkQueryString.Page.StartsWith("/") = True Then

                            DeepLinkQueryString.Page = DeepLinkQueryString.Page.Substring(1, DeepLinkQueryString.Page.Length - 1)

                        End If

                    End If

                Catch ex As Exception

                End Try
                Try

                    If String.IsNullOrWhiteSpace(DeepLinkQueryString.DeepLink) = True Then

                        Link = AdvantageFramework.Web.EncryptDeepLinkQueryString(DeepLinkQueryString.ToString(True))

                    Else

                        Link = DeepLinkQueryString.DeepLink

                    End If

                Catch ex As Exception
                    Link = String.Empty
                End Try

                If String.IsNullOrWhiteSpace(Link) = False Then

                    If String.IsNullOrWhiteSpace(Me._WebvantageURL) = False Then

                        WebvantageLink = String.Format("{0}/NewApp?dl={1}", Me._WebvantageURL, Link)

                    End If
                    If String.IsNullOrWhiteSpace(Me._ClientPortalURL) = False Then

                        ClientPortalLink = String.Format("{0}/NewApp?dl={1}", Me._ClientPortalURL, Link)

                    End If

                End If

            End If

        End Sub
        Public Function TextHasInternalLinks(ByVal TextString As String) As Boolean

            Return AdvantageFramework.AlertSystem.TextHasInternalLinks(TextString, Me._WebvantageURL, Me._ClientPortalURL)

        End Function
        Private Sub SetApplicationURL()

            Me._WebvantageURL = String.Empty
            Me._ClientPortalURL = String.Empty

            If Me._SecuritySession IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    Dim Agency As AdvantageFramework.Database.Entities.Agency

                    Agency = Nothing
                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.WebvantageURL IsNot Nothing Then Me._WebvantageURL = Agency.WebvantageURL
                        If Agency.ClientPortalURL IsNot Nothing Then Me._ClientPortalURL = Agency.ClientPortalURL

                        Me.CheckURLs()

                    End If

                End Using

            End If

        End Sub
        Private Sub CheckURLs()

            If Me._WebvantageURL.EndsWith("/") = True Then Me._WebvantageURL = Me._WebvantageURL.Substring(0, Me._WebvantageURL.Length - 1)
            If Me._ClientPortalURL.EndsWith("/") = True Then Me._ClientPortalURL = Me._ClientPortalURL.Substring(0, Me._ClientPortalURL.Length - 1)

            If Me._WebvantageURL.ToLower.StartsWith("http://") = False AndAlso Me._WebvantageURL.ToLower.StartsWith("https://") = False Then

                Me._WebvantageURL = "http://" & Me._WebvantageURL

            End If
            If Me._ClientPortalURL.ToLower.StartsWith("http://") = False AndAlso Me._ClientPortalURL.ToLower.StartsWith("https://") = False Then

                Me._ClientPortalURL = "http://" & Me._ClientPortalURL

            End If

            'If Me._WebvantageURL.EndsWith("/") = False Then Me._WebvantageURL &= "/"
            'If Me._ClientPortalURL.EndsWith("/") = False Then Me._ClientPortalURL &= "/"

        End Sub

        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession
            Me._QueryString = New AdvantageFramework.Web.QueryString

            Me.SetApplicationURL()

        End Sub
        Sub New(ByVal SecuritySession As AdvantageFramework.Security.Session,
                ByVal QueryString As AdvantageFramework.Web.QueryString)

            Me._SecuritySession = SecuritySession

            If QueryString IsNot Nothing Then

                Me._QueryString = QueryString

            Else

                Me._QueryString = New AdvantageFramework.Web.QueryString

            End If

            Me.SetApplicationURL()

        End Sub

#End Region

    End Class

End Namespace
