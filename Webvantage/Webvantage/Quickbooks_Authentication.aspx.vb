Public Class Quickbooks_Authentication
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

    'Shared redirectURI As String = AdvantageFramework.Quickbooks.QBO_REDIRECT_URI  ' ConfigurationManager.AppSettings("redirectURI")
    Shared discoveryURI As String = AdvantageFramework.Quickbooks.QBO_DISCOVERY_URI ' "https://developer.api.intuit.com/.well-known/openid_sandbox_configuration/" 'ConfigurationManager.AppSettings("discoveryURI")
    Shared qboBaseUrl As String = AdvantageFramework.Quickbooks.QBO_BASEURL ' "sandbox-quickbooks.api.intuit.com" 'ConfigurationManager.AppSettings("qboBaseUrl")
    'Shared logPath As String = "C:\\Log\\" 'ConfigurationManager.AppSettings("logPath")
    'Shared scopeValC2QB As String = System.Uri.EscapeDataString(ConfigurationManager.AppSettings("scopeValC2QB"))
    Shared scopeValOpenId As String = System.Uri.EscapeDataString("com.intuit.quickbooks.accounting com.intuit.quickbooks.payment openid email profile phone address") ' System.Uri.EscapeDataString(ConfigurationManager.AppSettings("scopeValOpenId"))
    'Shared scopeValSIWI As String = System.Uri.EscapeDataString(ConfigurationManager.AppSettings("scopeValSIWI"))
    Shared authorizationEndpoint As String
    Shared tokenEndpoint As String
    Shared userinfoEndPoint As String
    Shared revokeEndpoint As String
    Shared issuerUrl As String
    Shared jwksEndpoint As String
    Shared [mod] As String
    Shared expo As String

    Private code As String = ""
    'Private incoming_state As String = ""
    Private realmId As String = ""
    Shared IsLoaded As Boolean
    Shared Exchanged As Boolean
    Shared Session As AdvantageFramework.Security.Session = Nothing

    Private Sub SaveSetting(SettingCode As String, SettingValue As Object)

        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim Saved As Boolean = False

        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

            If Setting IsNot Nothing Then

                Setting.Value = SettingValue

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            End If

        End Using

    End Sub
    Private Sub GetServerName(ByVal DatabaseName As String, ByRef ServerName As String, ByRef UserName As String, ByRef Password As String)

        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

        ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

        If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

            For Each CDP In ConnectionDatabaseProfiles

                If CDP.DatabaseName = DatabaseName Then

                    ConnectionDatabaseProfile = CDP
                    Exit For

                End If

            Next

        End If

        If ConnectionDatabaseProfile IsNot Nothing Then

            ServerName = ConnectionDatabaseProfile.ServerName.Replace("#", "\")
            UserName = ConnectionDatabaseProfile.UserName
            Password = ConnectionDatabaseProfile.GetDecryptPassword()

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Quickbooks_Authentication_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Dim RedirectURI As String = Nothing
        Dim DatabaseName As String = Nothing
        Dim DateTime As String = Nothing
        Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        Dim DecodedQueryString As String = Nothing
        Dim QueryItems() As String = Nothing
        Dim VariableValues() As String = Nothing
        Dim IsValid As Boolean = True
        Dim DateParam As Date = Nothing

        'output("Load")

        If Me.IsCallback = False AndAlso IsLoaded = False Then

            IsLoaded = True

            GetDiscoveryData()
            GetJWKSkeys()
            'DoOAuth("OpenId")

        End If

        If Request.QueryString.Count > 0 Then

            Dim queryKeys As System.Collections.Generic.List(Of String) = New System.Collections.Generic.List(Of String)(Request.QueryString.AllKeys)

            If queryKeys.Contains("error") = True Then

                'output(String.Format("OAuth authorization error: {0}.", Request.QueryString("error").ToString()))
                Return

            End If

            If queryKeys.Contains("code") = False OrElse queryKeys.Contains("state") = False Then

                'output("Malformed authorization response.")
                Return

            End If

            Try

                DecodedQueryString = AdvantageFramework.Security.Encryption.Decrypt(Request.QueryString("state"))

                QueryItems = DecodedQueryString.Split("&")

                For Each QueryItem In QueryItems

                    VariableValues = QueryItem.Split("=")

                    Select Case VariableValues(0)

                        Case "Database"

                            DatabaseName = VariableValues(1).ToString

                        Case "DateTime"

                            DateTime = VariableValues(1).ToString
                            DateParam = New Date(DateTime.Substring(0, 4), DateTime.Substring(4, 2), DateTime.Substring(6, 2), DateTime.Substring(8, 2), DateTime.Substring(10, 2), DateTime.Substring(12, 2))
                            'output(DateParam)
                            If DateDiff(DateInterval.Day, DateParam, Now) > 1 Then
                                IsValid = False
                            End If

                    End Select

                Next

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid Then
                'output(DatabaseName)
                'output(DateTime)

                SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder()

                GetServerName(DatabaseName, SqlConnectionStringBuilder.DataSource, SqlConnectionStringBuilder.UserID, SqlConnectionStringBuilder.Password)

                SqlConnectionStringBuilder.InitialCatalog = DatabaseName

                If String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.DataSource) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.InitialCatalog) = False AndAlso
                        String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.UserID) = False AndAlso String.IsNullOrWhiteSpace(SqlConnectionStringBuilder.Password) = False Then

                    Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, SqlConnectionStringBuilder.ConnectionString, SqlConnectionStringBuilder.UserID, 0, SqlConnectionStringBuilder.ConnectionString)

                    If Request.QueryString("realmId") IsNot Nothing Then

                        realmId = Request.QueryString("realmId").ToString()

                        SaveSetting(AdvantageFramework.Agency.Settings.QB_REALM_ID.ToString, realmId)

                    End If

                    If Request.QueryString("code") IsNot Nothing Then

                        code = Request.QueryString("code").ToString()

                        SaveSetting(AdvantageFramework.Agency.Settings.QB_AUTH_CODE.ToString, code)

                        'output("Authorization code obtained.")
                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            RedirectURI = DbContext.Database.SqlQuery(Of String)("SELECT WEBVANTAGE_URL from dbo.AGENCY").FirstOrDefault

                            If RedirectURI.EndsWith("/") Then

                                RedirectURI += "Quickbooks_Authentication.aspx"

                            Else

                                RedirectURI += "/Quickbooks_Authentication.aspx"

                            End If

                        End Using

                        Exchanged = PerformCodeExchange(code, RedirectURI, realmId)

                        If Exchanged Then

                            SaveSetting(AdvantageFramework.Agency.Settings.QB_ENABLED.ToString, True)

                        Else

                            SaveSetting(AdvantageFramework.Agency.Settings.QB_ENABLED.ToString, False)

                        End If

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub Quickbooks_Authentication_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        If Exchanged Then

            Me.CloseThisWindow()

        End If

    End Sub

#End Region

    Private Sub GetDiscoveryData()

        Dim discoveryDataDecoded As AdvantageFramework.Quickbooks.Classes.DiscoveryData = Nothing
        Dim discoveryRequest As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(discoveryURI), System.Net.HttpWebRequest)

        'output("Fetching Discovery Data.")

        discoveryRequest.Method = "GET"
        discoveryRequest.Accept = "application/json"

        Try
            Dim discoveryResponse As System.Net.HttpWebResponse = CType(discoveryRequest.GetResponse(), System.Net.HttpWebResponse)

            Using discoveryDataReader = New System.IO.StreamReader(discoveryResponse.GetResponseStream())

                Dim responseText As String = discoveryDataReader.ReadToEnd()
                discoveryDataDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Quickbooks.Classes.DiscoveryData)(responseText)

            End Using

            authorizationEndpoint = discoveryDataDecoded.AuthorizationEndpoint
            tokenEndpoint = discoveryDataDecoded.TokenEndpoint
            userinfoEndPoint = discoveryDataDecoded.UserinfoEndpoint
            revokeEndpoint = discoveryDataDecoded.RevocationEndpoint
            issuerUrl = discoveryDataDecoded.Issuer
            jwksEndpoint = discoveryDataDecoded.JWKS_uri

            'output("Discovery Data obtained.")

        Catch ex As System.Net.WebException

            If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then

                Dim response = TryCast(ex.Response, System.Net.HttpWebResponse)

                If response IsNot Nothing Then

                    'output("HTTP Status: " & response.StatusCode)

                    Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

                    If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then

                        'output(exceptionDetail)

                    End If

                    Using reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                        Dim responseText As String = reader.ReadToEnd()

                        If responseText IsNot Nothing AndAlso responseText <> "" Then

                            'output(responseText)

                        End If

                    End Using

                End If

            Else

                'output(ex.Message)

            End If

        End Try

    End Sub

    'Private Sub DoOAuth(ByVal callMadeBy As String)

    '    output("Intiating OAuth2 call to get code.")

    '    Dim authorizationRequest As String = ""
    '    Dim scopeVal As String = ""
    '    Dim stateVal As String = randomDataBase64url(32)

    '    If Session("CSRF") Is Nothing Then
    '        Session("CSRF") = stateVal
    '    End If

    '    If callMadeBy = "OpenId" Then

    '        Session("callMadeBy") = "OpenId"
    '        scopeVal = scopeValOpenId

    '    End If

    '    If authorizationEndpoint <> "" AndAlso authorizationEndpoint IsNot Nothing Then

    '        authorizationRequest = String.Format("{0}?client_id={1}&response_type=code&scope={2}&redirect_uri={3}&state={4}", authorizationEndpoint, ClientID, scopeVal, System.Uri.EscapeDataString(redirectURI), stateVal)

    '        HiddenFieldLink.Value = authorizationRequest

    '        AddJavascriptToPage("OpenQuickbooksAuthorization()")

    '        'Response.Redirect(authorizationRequest, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10")
    '        Response.Redirect(authorizationRequest)

    '    Else

    '        output("Missing authorizationEndpoint url!")

    '    End If

    'End Sub

    Private Function PerformCodeExchange(ByVal code As String, ByVal redirectURI As String, ByVal realmId As String) As Boolean

        'output("Exchanging code for tokens.")
        'output(code)

        Dim IDToken As String = ""
        Dim RefreshToken As String = ""
        Dim AccessToken As String = ""
        Dim IsTokenValid As Boolean = False
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim ClientID As String = Nothing
        Dim ClientSecret As String = Nothing
        Dim cred As String = Nothing
        Dim enc As String = Nothing
        Dim BasicAuth As String = Nothing
        Dim AccessTokenRequestBody As String = Nothing
        Dim AccessTokenRequest As System.Net.HttpWebRequest = Nothing
        Dim ByteVersion As Byte() = Nothing
        Dim Stream As System.IO.Stream = Nothing
        Dim AccesstokenResponse As System.Net.HttpWebResponse = Nothing
        Dim ResponseText As String = Nothing
        Dim AccessTokenEndpointDecoded As System.Collections.Generic.Dictionary(Of String, String) = Nothing
        Dim Exchanged As Boolean = False

        ClientID = AdvantageFramework.Quickbooks.GetClientID()

        ClientSecret = AdvantageFramework.Quickbooks.GetClientSecret()

        cred = String.Format("{0}:{1}", ClientID, ClientSecret)
        enc = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(cred))
        BasicAuth = String.Format("{0} {1}", "Basic", enc)
        AccesstokenRequestBody = String.Format("grant_type=authorization_code&code={0}&redirect_uri={1}", code, System.Uri.EscapeDataString(redirectURI))
        AccesstokenRequest = CType(System.Net.WebRequest.Create(tokenEndpoint), System.Net.HttpWebRequest)

        AccessTokenRequest.Method = "POST"
        AccessTokenRequest.ContentType = "application/x-www-form-urlencoded"
        AccessTokenRequest.Accept = "application/json"
        AccessTokenRequest.Headers(System.Net.HttpRequestHeader.Authorization) = BasicAuth

        ByteVersion = System.Text.Encoding.ASCII.GetBytes(AccessTokenRequestBody)
        AccessTokenRequest.ContentLength = ByteVersion.Length

        Stream = AccessTokenRequest.GetRequestStream()
        Stream.Write(ByteVersion, 0, ByteVersion.Length)
        Stream.Close()

        Try

            AccesstokenResponse = CType(AccesstokenRequest.GetResponse(), System.Net.HttpWebResponse)

            Using AccessTokenReader = New System.IO.StreamReader(AccesstokenResponse.GetResponseStream())

                ResponseText = AccessTokenReader.ReadToEnd()

                AccessTokenEndpointDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of System.Collections.Generic.Dictionary(Of String, String))(ResponseText)

                If accesstokenEndpointDecoded.ContainsKey("id_token") Then

                    IDToken = accesstokenEndpointDecoded("id_token")
                    IsTokenValid = isIdTokenValid(IDToken)

                End If

                If accesstokenEndpointDecoded.ContainsKey("refresh_token") Then

                    RefreshToken = accesstokenEndpointDecoded("refresh_token")

                    SaveSetting(AdvantageFramework.Agency.Settings.QB_REFRESH_TOKEN.ToString, RefreshToken)

                    If accesstokenEndpointDecoded.ContainsKey("access_token") Then

                        'output("Access token obtained.")
                        AccessToken = accesstokenEndpointDecoded("access_token")

                        SaveSetting(AdvantageFramework.Agency.Settings.QB_ACCESS_TOKEN.ToString, AccessToken)

                        Exchanged = True

                    End If

                End If

            End Using

        Catch ex As System.Net.WebException

            If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then

                Dim response = TryCast(ex.Response, System.Net.HttpWebResponse)

                If response IsNot Nothing Then

                    'output("HTTP Status: " & response.StatusCode)

                    Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

                    If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then

                        'output(exceptionDetail)

                    End If

                    Using reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                        ResponseText = reader.ReadToEnd()

                        If ResponseText IsNot Nothing AndAlso ResponseText <> "" Then

                            'output(ResponseText)

                        End If

                    End Using

                End If

            End If

        End Try

        PerformCodeExchange = Exchanged

    End Function

    'Private Sub PerformRefreshToken(ByVal refresh_token As String)
    '    output("Exchanging refresh token for access token.")
    '    Dim access_token As String = ""
    '    Dim cred As String = String.Format("{0}:{1}", clientID, clientSecret)
    '    Dim enc As String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(cred))
    '    Dim basicAuth As String = String.Format("{0} {1}", "Basic", enc)
    '    Dim refreshtokenRequestBody As String = String.Format("grant_type=refresh_token&refresh_token={0}", refresh_token)
    '    Dim refreshtokenRequest As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(tokenEndpoint), System.Net.HttpWebRequest)
    '    refreshtokenRequest.Method = "POST"
    '    refreshtokenRequest.ContentType = "application/x-www-form-urlencoded"
    '    refreshtokenRequest.Accept = "application/json"
    '    refreshtokenRequest.Headers(System.Net.HttpRequestHeader.Authorization) = basicAuth
    '    Dim _byteVersion As Byte() = System.Text.Encoding.ASCII.GetBytes(refreshtokenRequestBody)
    '    refreshtokenRequest.ContentLength = _byteVersion.Length
    '    Dim stream As System.IO.Stream = refreshtokenRequest.GetRequestStream()
    '    stream.Write(_byteVersion, 0, _byteVersion.Length)
    '    stream.Close()

    '    Try

    '        Dim refreshtokenResponse As System.Net.HttpWebResponse = CType(refreshtokenRequest.GetResponse(), System.Net.HttpWebResponse)

    '        Using refreshTokenReader = New System.IO.StreamReader(refreshtokenResponse.GetResponseStream())
    '            Dim responseText As String = refreshTokenReader.ReadToEnd()
    '            Dim refreshtokenEndpointDecoded As System.Collections.Generic.Dictionary(Of String, String) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of System.Collections.Generic.Dictionary(Of String, String))(responseText)

    '            If refreshtokenEndpointDecoded.ContainsKey("error") Then

    '                If refreshtokenEndpointDecoded("error") IsNot Nothing Then
    '                    output(String.Format("OAuth token refresh error: {0}.", refreshtokenEndpointDecoded("error")))
    '                    Return
    '                End If
    '            Else

    '                If refreshtokenEndpointDecoded.ContainsKey("refresh_token") Then
    '                    refresh_token = refreshtokenEndpointDecoded("refresh_token")
    '                    Session("refreshToken") = refresh_token

    '                    If refreshtokenEndpointDecoded.ContainsKey("access_token") Then
    '                        access_token = refreshtokenEndpointDecoded("access_token")
    '                        Session("accessToken") = access_token
    '                    End If
    '                End If
    '            End If
    '        End Using

    '    Catch ex As System.Net.WebException

    '        If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then
    '            Dim response = TryCast(ex.Response, System.Net.HttpWebResponse)

    '            If response IsNot Nothing Then
    '                output("HTTP Status: " & response.StatusCode)
    '                Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

    '                If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then
    '                    output(exceptionDetail)
    '                End If

    '                Using reader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
    '                    Dim responseText As String = reader.ReadToEnd()

    '                    If responseText IsNot Nothing AndAlso responseText <> "" Then
    '                        output(responseText)
    '                    End If
    '                End Using
    '            End If
    '        End If
    '    End Try

    '    output("Access token refreshed.")
    'End Sub

    Private Sub GetJWKSkeys()
        'output("Making Get JWKS Keys Call.")
        Dim jwksEndpointDecoded As AdvantageFramework.Quickbooks.Classes.JWKS
        Dim jwksRequest As System.Net.HttpWebRequest = CType(System.Net.WebRequest.Create(jwksEndpoint), System.Net.HttpWebRequest)
        jwksRequest.Method = "GET"
        jwksRequest.Accept = "application/json"
        Dim jwksResponse As System.Net.HttpWebResponse = CType(jwksRequest.GetResponse(), System.Net.HttpWebResponse)

        Using jwksReader = New System.IO.StreamReader(jwksResponse.GetResponseStream())
            Dim responseText As String = jwksReader.ReadToEnd()
            jwksEndpointDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Quickbooks.Classes.JWKS)(responseText)
        End Using

        For Each key In jwksEndpointDecoded.Keys

            If key.N IsNot Nothing Then
                [mod] = key.N
            End If

            If key.E IsNot Nothing Then
                expo = key.E
            End If
        Next

        'output("JWKS Keys obtained.")
    End Sub
    Private Function isIdTokenValid(ByVal id_token As String) As Boolean
        'output("Making IsIdToken Valid Call.")
        Dim idToken As String = id_token
        Dim splitValues As String() = idToken.Split("."c)

        If splitValues(0) IsNot Nothing Then
            Dim headerJson = System.Text.Encoding.UTF8.GetString(FromBase64Url(splitValues(0).ToString()))
            Dim headerData As AdvantageFramework.Quickbooks.Classes.IdTokenHeader = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Quickbooks.Classes.IdTokenHeader)(headerJson)

            If headerData.Kid Is Nothing Then
                Return False
            End If

            If headerData.Alg Is Nothing Then
                Return False
            End If
        End If

        If splitValues(1) IsNot Nothing Then
            Dim payloadJson = System.Text.Encoding.UTF8.GetString(FromBase64Url(splitValues(1).ToString()))
            Dim payloadData As AdvantageFramework.Quickbooks.Classes.IdTokenPayload = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Quickbooks.Classes.IdTokenPayload)(payloadJson)

            If payloadData.Aud IsNot Nothing Then

                If payloadData.Aud(0).ToString() <> clientID Then
                    Return False
                End If
            Else
                Return False
            End If

            If payloadData.Auth_time Is Nothing Then
                Return False
            End If

            If payloadData.Exp IsNot Nothing Then
                Dim expiration As ULong = Convert.ToUInt64(payloadData.Exp)
                Dim epochTicks As TimeSpan = New TimeSpan(New DateTime(1970, 1, 1).Ticks)
                Dim unixTicks As TimeSpan = New TimeSpan(DateTime.UtcNow.Ticks) - epochTicks
                Dim unixTime As ULong = Convert.ToUInt64(unixTicks.Milliseconds)

                If (expiration - unixTime) <= 0 Then
                    Return False
                End If
            Else
                Return False
            End If

            If payloadData.Iat Is Nothing Then
                Return False
            End If

            If payloadData.Iss IsNot Nothing Then

                If payloadData.Iss.ToString() <> issuerUrl Then
                    Return False
                End If
            Else
                Return False
            End If

            If payloadData.[Sub] Is Nothing Then
                Return False
            End If
        End If

        Dim rsa As System.Security.Cryptography.RSACryptoServiceProvider = New System.Security.Cryptography.RSACryptoServiceProvider()
        rsa.ImportParameters(New System.Security.Cryptography.RSAParameters() With {
            .Modulus = FromBase64Url([mod]),
            .Exponent = FromBase64Url(expo)
        })
        Dim sha256 As System.Security.Cryptography.SHA256 = sha256.Create()
        Dim hash As Byte() = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(splitValues(0) & "."c & splitValues(1)))
        Dim rsaDeformatter As System.Security.Cryptography.RSAPKCS1SignatureDeformatter = New System.Security.Cryptography.RSAPKCS1SignatureDeformatter(rsa)
        rsaDeformatter.SetHashAlgorithm("SHA256")

        If rsaDeformatter.VerifySignature(hash, FromBase64Url(splitValues(2))) Then
            'output("IdToken Signature is verified.")
            'output("IsIdToken Valid Call completed.")
            Return True
        Else
            'output("Signature is compromised.")
            'output("IsIdToken Valid Call completed.")
            Return False
        End If
    End Function
    'Public Function GetLogPath() As String

    '    Try

    '        If logPath = "" Then
    '            logPath = System.Environment.GetEnvironmentVariable("TEMP")
    '            If Not logPath.EndsWith("\") Then logPath += "\"
    '        End If

    '    Catch
    '        output("Log error path not found.")
    '    End Try

    '    Return logPath

    'End Function
    'Public Sub output(ByVal logMsg As String)

    '    Dim sw As System.IO.StreamWriter = System.IO.File.AppendText(GetLogPath() & "OAuth2SampleAppLogs.txt")

    '    Try
    '        Dim logLine As String = System.String.Format("{0:G}: {1}.", System.DateTime.Now, logMsg)
    '        sw.WriteLine(logLine)
    '    Finally
    '        sw.Close()
    '    End Try

    'End Sub
    'Public Shared Function randomDataBase64url(ByVal length As UInteger) As String
    '    Dim rng As System.Security.Cryptography.RNGCryptoServiceProvider = New System.Security.Cryptography.RNGCryptoServiceProvider()
    '    Dim bytes As Byte() = New Byte(length - 1) {}
    '    rng.GetBytes(bytes)
    '    Return Base64urlencodeNoPadding(bytes)
    'End Function

    'Public Shared Function sha256(ByVal inputString As String) As Byte()
    '    Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(inputString)
    '    Dim sha256val As System.Security.Cryptography.SHA256Managed = New System.Security.Cryptography.SHA256Managed()
    '    Return sha256val.ComputeHash(bytes)
    'End Function

    'Public Shared Function Base64urlencodeNoPadding(ByVal buffer As Byte()) As String
    '    Dim base64 As String = Convert.ToBase64String(buffer)
    '    base64 = base64.Replace("+", "-")
    '    base64 = base64.Replace("/", "_")
    '    base64 = base64.Replace("=", "")
    '    Return base64
    'End Function

    Private Shared Function FromBase64Url(ByVal base64Url As String) As Byte()
        Dim padded As String = If(base64Url.Length Mod 4 = 0, base64Url, base64Url & "====".Substring(base64Url.Length Mod 4))
        Dim base64 As String = padded.Replace("_", "/").Replace("-", "+")
        Return Convert.FromBase64String(base64)
    End Function

End Class

Module ResponseHelper
    <System.Runtime.CompilerServices.Extension()>
    Sub Redirect(ByVal response As HttpResponse, ByVal url As String, ByVal target As String, ByVal windowFeatures As String)

        If (String.IsNullOrEmpty(target) OrElse target.Equals("_self", StringComparison.OrdinalIgnoreCase)) AndAlso String.IsNullOrEmpty(windowFeatures) Then

            response.Redirect(url)

        Else

            Dim page As Page = CType(HttpContext.Current.Handler, Page)

            If page Is Nothing Then
                Throw New InvalidOperationException("Cannot redirect to new window outside Page context.")
            End If

            url = page.ResolveClientUrl(url)
            Dim script As String

            If Not String.IsNullOrEmpty(windowFeatures) Then
                script = "window.open(""{0}"", ""{1}"", ""{2}"");"
            Else
                script = "window.open(""{0}"", ""{1}"");"
            End If

            script = String.Format(script, url, target, windowFeatures)
            ScriptManager.RegisterStartupScript(page, GetType(Page), "Redirect", script, True)

        End If

    End Sub

End Module
