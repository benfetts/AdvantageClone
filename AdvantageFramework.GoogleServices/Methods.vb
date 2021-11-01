<HideModuleName()>
Public Module Methods

#Region " Constants "

    ' IF THESE ARE CHANGED, UPDATE THEM IN FRAMEWORK.EMAIL!!!
    Public Const ClientID As String = "641931340891-99hr8ijdob0b40mkk5ar2s2nn0nnss12.apps.googleusercontent.com"
    Public Const ClientSecret As String = "iEnotTrS7pjQ94gDoKm2eS7G"
    Public Const RedirectUri As String = "urn:ietf:wg:oauth:2.0:oob:auto"
    Public Const WebvantageRedirectUri As String = "urn:ietf:wg:oauth:2.0:oob"

    Public Const DFAClientID As String = "628387697351-v6orf0brgf2v050f70uuh3191j6eneb3.apps.googleusercontent.com"
    Public Const DFAClientSecret As String = "jyILfVaWp6R2yEWyBDSDZSHb"

#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private startingchars As Char() = New Char() {"<", "&"}

#End Region

#Region " Properties "

    Private ReadOnly Property AllScopes As String()
        Get
            Return {Services.Calendar.Scope,
                        Services.Gmail.Scope}
        End Get
    End Property

#End Region

#Region " Methods "

    Public Function ExchangeCodeForTokenForAllServices(ByVal ConnectionString As String,
                                                       ByVal EmployeeCode As String, ByVal AuthorizationCode As String,
                                                       ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean, ClientCode As String) As Boolean

        Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(ConnectionString, UseWindowsAuthentication)

            ExchangeCodeForTokenForAllServices = ExchangeCodeForToken(DataContext, EmployeeCode, AuthorizationCode, AllScopes, IsWebvantage, ClientCode)

        End Using

    End Function
    Public Function ExchangeCodeForToken(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                         ByVal EmployeeCode As String, ByVal AuthorizationCode As String, ByVal Scopes As String(),
                                         ByVal IsWebvantage As Boolean, ClientCode As String) As Boolean

        'objects
        Dim TokenResponse As Google.Apis.Auth.OAuth2.Responses.TokenResponse = Nothing
        Dim GoogleAuthorizationCodeFlow As Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow = Nothing
        Dim Initializer As Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow.Initializer = Nothing
        Dim Exchanged As Boolean = False
        Dim CurrentRedirectUri As String = Nothing
        Dim IsDoubleClick As Boolean = False

        Try

            If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                IsDoubleClick = True

            End If

            Initializer = New Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow.Initializer() With {.ClientSecrets = LoadClientSecrets(IsDoubleClick),
                                                                                                            .Scopes = Scopes,
                                                                                                            .DataStore = New AdvantageFramework.GoogleServices.Database.Classes.DataStore(DataContext, IsDoubleClick, ClientCode)}

            GoogleAuthorizationCodeFlow = New Google.Apis.Auth.OAuth2.Flows.GoogleAuthorizationCodeFlow(Initializer)

            If IsWebvantage Then

                CurrentRedirectUri = WebvantageRedirectUri

            Else

                CurrentRedirectUri = RedirectUri

            End If

            TokenResponse = GoogleAuthorizationCodeFlow.ExchangeCodeForTokenAsync(EmployeeCode, AuthorizationCode, CurrentRedirectUri, System.Threading.CancellationToken.None).Result

            If TokenResponse IsNot Nothing Then

                Exchanged = True

            End If

        Catch ex As Exception
            Exchanged = False
        Finally
            ExchangeCodeForToken = Exchanged
        End Try

    End Function
    Public Function GetAuthorizationCodeUri(ByVal EmployeeEmail As String, ByVal Scopes As String(), ByVal IsWebvantage As Boolean) As System.Uri

        'objects
        Dim GoogleAuthorizationCodeRequestUrl As Google.Apis.Auth.OAuth2.Requests.GoogleAuthorizationCodeRequestUrl = Nothing
        Dim AuthorizationUri As System.Uri = Nothing
        Dim IsDoubleClick As Boolean = False

        Try

            If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                IsDoubleClick = True

            End If

        Catch ex As Exception

        End Try

        Try

            GoogleAuthorizationCodeRequestUrl = New Google.Apis.Auth.OAuth2.Requests.GoogleAuthorizationCodeRequestUrl(New System.Uri(Google.Apis.Auth.OAuth2.GoogleAuthConsts.AuthorizationUrl))

            If IsWebvantage Then

                GoogleAuthorizationCodeRequestUrl.RedirectUri = WebvantageRedirectUri

            Else

                GoogleAuthorizationCodeRequestUrl.RedirectUri = RedirectUri

            End If

            If IsDoubleClick Then

                GoogleAuthorizationCodeRequestUrl.ClientId = DFAClientID

            Else

                GoogleAuthorizationCodeRequestUrl.ClientId = ClientID

            End If

            GoogleAuthorizationCodeRequestUrl.Scope = String.Join(" ", Scopes)
            GoogleAuthorizationCodeRequestUrl.LoginHint = EmployeeEmail

            AuthorizationUri = GoogleAuthorizationCodeRequestUrl.Build()

        Catch ex As Exception
            GoogleAuthorizationCodeRequestUrl = Nothing
        Finally
            GetAuthorizationCodeUri = AuthorizationUri
        End Try

    End Function
    Public Function GetAuthorizationCodeUriForAllServices(ByVal EmployeeEmail As String, ByVal IsWebvantage As Boolean) As System.Uri

        GetAuthorizationCodeUriForAllServices = GetAuthorizationCodeUri(EmployeeEmail, AllScopes, IsWebvantage)

    End Function
    Public Function GetGmailAuthorizationCodeUri(ByVal EmployeeEmail As String, ByVal IsWebvantage As Boolean) As System.Uri

        GetGmailAuthorizationCodeUri = GetAuthorizationCodeUri(EmployeeEmail, {Services.Gmail.Scope}, IsWebvantage)

    End Function
    Public Function GetCalendarAuthorizationCodeUri(ByVal EmployeeEmail As String, ByVal IsWebvantage As Boolean) As System.Uri

        GetCalendarAuthorizationCodeUri = GetAuthorizationCodeUri(EmployeeEmail, {Services.Calendar.Scope}, IsWebvantage)

    End Function
    Public Function LoadUserCredential(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                       ByVal EmployeeCode As String,
                                       ByVal Scopes As IEnumerable(Of String),
                                       ClientCode As String) As Google.Apis.Auth.OAuth2.UserCredential
        'objects
        Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
        Dim IsDoubleClick As Boolean = False

        Try

            If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                IsDoubleClick = True

            End If

            UserCredential = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(LoadClientSecrets(IsDoubleClick),
                                                                                                 Scopes,
                                                                                                 EmployeeCode,
                                                                                                 System.Threading.CancellationToken.None,
                                                                                                 New AdvantageFramework.GoogleServices.Database.Classes.DataStore(DataContext, IsDoubleClick, ClientCode)).Result

        Catch ex As Exception
            UserCredential = Nothing
        Finally
            LoadUserCredential = UserCredential
        End Try

    End Function
    Public Function ShowGoogleAuthorizeScreen(DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                              EmployeeCode As String,
                                              Scopes As IEnumerable(Of String),
                                              ClientCode As String) As Google.Apis.Auth.OAuth2.UserCredential
        'objects
        Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
        Dim IsDoubleClick As Boolean = False
        Dim CancellationTokenSource As System.Threading.CancellationTokenSource = Nothing

        Try

            If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                IsDoubleClick = True

            End If

            CancellationTokenSource = New System.Threading.CancellationTokenSource(New TimeSpan(0, 2, 0))

            UserCredential = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(LoadClientSecrets(IsDoubleClick),
                                                                                                 Scopes,
                                                                                                 EmployeeCode,
                                                                                                 CancellationTokenSource.Token,
                                                                                                 New AdvantageFramework.GoogleServices.Database.Classes.DataStore(DataContext, IsDoubleClick, ClientCode)).Result

        Catch ex As Exception
            UserCredential = Nothing
        End Try

        ShowGoogleAuthorizeScreen = UserCredential

    End Function
    Private Function LoadClientSecrets(IsDoubleClick As Boolean) As Google.Apis.Auth.OAuth2.ClientSecrets

        'objects
        Dim ClientSecrets As Google.Apis.Auth.OAuth2.ClientSecrets = Nothing

        ClientSecrets = New Google.Apis.Auth.OAuth2.ClientSecrets

        If IsDoubleClick Then

            ClientSecrets.ClientId = DFAClientID
            ClientSecrets.ClientSecret = DFAClientSecret

        Else

            ClientSecrets.ClientId = ClientID
            ClientSecrets.ClientSecret = ClientSecret

        End If

        LoadClientSecrets = ClientSecrets

    End Function
    Public Function Authorize(ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal Scopes As String(), ByVal UseWindowsAuthentication As Boolean, ClientCode As String) As Boolean


        'objects
        Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
        Dim Authorized As Boolean = Nothing

        Try

            Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(ConnectionString, UseWindowsAuthentication)

                UserCredential = ShowGoogleAuthorizeScreen(DataContext, EmployeeCode, Scopes, ClientCode)

                If UserCredential IsNot Nothing Then

                    Authorized = True

                End If

            End Using

        Catch ex As Exception
            Authorized = False
        Finally
            Authorize = Authorized
        End Try

    End Function
    Public Function Deauthorize(ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal Scopes As String(), ByVal UseWindowsAuthentication As Boolean, ClientCode As String) As Boolean

        'objects
        Dim Deauthorized As Boolean = Nothing
        Dim Token As String = Nothing
        Dim IsDoubleClick As Boolean = False

        Try

            Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(ConnectionString, UseWindowsAuthentication)

                Try

                    Deauthorized = AdvantageFramework.GoogleServices.LoadUserCredential(DataContext, EmployeeCode, Scopes, ClientCode).RevokeTokenAsync(System.Threading.CancellationToken.None).Result

                Catch ex As Exception
                    Deauthorized = False
                End Try

                If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                    IsDoubleClick = True

                    AdvantageFramework.GoogleServices.Database.Classes.DataStore.Delete(DataContext, EmployeeCode, IsDoubleClick, ClientCode)

                End If

                If Deauthorized = False Then ' Google Services Token not found, but go ahead and clear GOOGLE_TOKEN in EMPLOYEE/AGENCY SETTINGS

                    Deauthorized = AdvantageFramework.GoogleServices.Database.Classes.DataStore.Delete(DataContext, EmployeeCode, IsDoubleClick, ClientCode)

                End If

            End Using

        Catch ex As Exception
            Deauthorized = False
        Finally
            Deauthorize = Deauthorized
        End Try

    End Function
    ''' <summary>
    ''' Use this method to Authorize ALL Google Services (gmail + calendar sync)
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="EmployeeCode"></param>
    ''' <returns></returns>
    Public Function AuthorizeAll(ConnectionString As String, EmployeeCode As String, ByVal UseWindowsAuthentication As Boolean, ClientCode As String) As Boolean

        AuthorizeAll = Authorize(ConnectionString, EmployeeCode, {Services.Calendar.Scope, Services.Gmail.Scope}, UseWindowsAuthentication, ClientCode)

    End Function
    ''' <summary>
    ''' Use this method to Deauthorize ALL Google Services (gmail + calendar sync)
    ''' </summary>
    ''' <param name="ConnectionString"></param>
    ''' <param name="EmployeeCode"></param>
    ''' <returns></returns>
    Public Function DeauthorizeAll(ConnectionString As String, EmployeeCode As String, ByVal UseWindowsAuthentication As Boolean, ClientCode As String) As Boolean

        DeauthorizeAll = Deauthorize(ConnectionString, EmployeeCode, AllScopes, UseWindowsAuthentication, ClientCode)

    End Function
    Public Function GetAccessTokenFromToken(Token As String) As String

        Dim TokenResponse As Google.Apis.Auth.OAuth2.Responses.TokenResponse = Nothing
        Dim AccessToken As String = Nothing

        Try

            TokenResponse = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize(Token, GetType(Google.Apis.Auth.OAuth2.Responses.TokenResponse))

            If TokenResponse IsNot Nothing Then

                AccessToken = TokenResponse.AccessToken

            End If

        Catch ex As Exception
            AccessToken = Nothing
        Finally
            GetAccessTokenFromToken = AccessToken
        End Try

    End Function
    Public Function GetOrRefreshToken(ConnectionString As String, UseWindowsAuthentication As Boolean, EmployeeCode As String, Scopes() As String, ClientCode As String) As String

        Dim AccessToken As String = String.Empty
        Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
        Dim IsDoubleClick As Boolean = False
        Dim CancellationTokenSource As System.Threading.CancellationTokenSource = Nothing
        Dim RefreshToken As Boolean = False

        Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(ConnectionString, UseWindowsAuthentication)

            Try

                If Scopes.Where(Function(scope) InStr(scope, "dfareporting") > 0).Any Then

                    IsDoubleClick = True

                End If

                CancellationTokenSource = New System.Threading.CancellationTokenSource(New TimeSpan(0, 2, 0))

                UserCredential = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(LoadClientSecrets(IsDoubleClick),
                                                                                                     Scopes,
                                                                                                     EmployeeCode,
                                                                                                     CancellationTokenSource.Token,
                                                                                                     New AdvantageFramework.GoogleServices.Database.Classes.DataStore(DataContext, IsDoubleClick, ClientCode)).Result

            Catch ex As Exception
                UserCredential = Nothing
            End Try

            If UserCredential IsNot Nothing Then

                If UserCredential.Token.IsExpired(UserCredential.Flow.Clock) Then

                    Try

                        CancellationTokenSource = New System.Threading.CancellationTokenSource(New TimeSpan(0, 2, 0))

                        RefreshToken = UserCredential.RefreshTokenAsync(CancellationTokenSource.Token).Result

                    Catch e As Exception
                        RefreshToken = False
                    End Try

                    If RefreshToken Then

                        AccessToken = UserCredential.Token.AccessToken

                    End If

                Else

                    AccessToken = UserCredential.Token.AccessToken

                End If

            End If

        End Using

        GetOrRefreshToken = AccessToken

    End Function

    Public Function IsDangerousString(ByVal comments As String, ByRef matchIndex As Integer)
        Try
            matchIndex = 0
            Dim startIndex As Integer = 0

            While (True)
                Dim num2 As Integer = comments.IndexOfAny(startingchars, startIndex)

                If num2 < 0 Then
                    Return False
                End If

                If num2 = comments.Length - 1 Then
                    Return False
                End If

                matchIndex = num2
                Dim ch As Char = comments(num2)

                If ch <> "&" Then
                    If ((ch = "<") And ((IsAtoZ(comments(num2 + 1)) Or (comments(num2 + 1) = "!")) Or ((comments(num2 + 1) = "/") Or (comments(num2 + 1) = "?")))) Then
                        Return True
                    End If
                ElseIf comments(num2 + 1) = "#" Then
                    Return True
                End If
                startIndex = num2 + 1

            End While
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function IsAtoZ(ByVal c As Char)
        Try
            Return (((c >= "a") And (c <= "z")) Or ((c >= "A") And (c <= "Z")))
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region

End Module
