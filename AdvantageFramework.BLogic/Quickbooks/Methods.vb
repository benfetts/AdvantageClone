Namespace Quickbooks

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        'next 4 are for sandbox only        
        'Public Const QBO_BASEURL = "https://sandbox-quickbooks.api.intuit.com"
        'Public Const QBO_DISCOVERY_URI = "https://developer.api.intuit.com/.well-known/openid_sandbox_configuration/"
        'Public Const QB_CLIENT_ID = "ABCQhnvDbWL4Jn4Cy0sUEm6Vejs6kSzOlJ4BpgjFq7lpRxhsNF"
        'Public Const QB_CLIENT_SECRET = "pWz7tEZWOJRvrOWZfVFnZPJN7OdrRgQY9NZA4SD0"

        'next 4 are for production
        Public Const QBO_BASEURL = "https://quickbooks.api.intuit.com"
        Public Const QBO_DISCOVERY_URI = "https://developer.api.intuit.com/.well-known/openid_configuration/"
        Public Const QB_CLIENT_ID = "ABLSIwubZii3uat8qV7uv06whPtE8EjIXjy4PhS8aE5a8x9zWI"
        Public Const QB_CLIENT_SECRET = "z4oFQOOmYmmLYqcnvTAfxXNZo9CMcWg3vj1rtsRG"

#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub GetJWKSkeys(jwksEndpoint As String)

            'output("Making Get JWKS Keys Call.")

            Dim jwksEndpointDecoded As AdvantageFramework.Quickbooks.Classes.JWKS = Nothing
            Dim jwksRequest As System.Net.HttpWebRequest = Nothing
            Dim [mod] As String = Nothing
            Dim expo As String = Nothing

            jwksRequest = CType(System.Net.WebRequest.Create(jwksEndpoint), System.Net.HttpWebRequest)
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
        Private Function GetAccessToken(DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AccessToken As String = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.QB_ACCESS_TOKEN.ToString)

            If Setting IsNot Nothing Then

                AccessToken = Setting.Value

            End If

            GetAccessToken = AccessToken

        End Function
        Private Function GetRefreshToken(DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim RefreshToken As String = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.QB_REFRESH_TOKEN.ToString)

            If Setting IsNot Nothing Then

                RefreshToken = Setting.Value

            End If

            GetRefreshToken = RefreshToken

        End Function
        Private Function GetRealmID(DataContext As AdvantageFramework.Database.DataContext) As String

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim RealmID As String = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.QB_REALM_ID.ToString)

            If Setting IsNot Nothing Then

                RealmID = Setting.Value

            End If

            GetRealmID = RealmID

        End Function
        Private Sub SaveSetting(DataContext As AdvantageFramework.Database.DataContext, SettingCode As String, SettingValue As Object)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Saved As Boolean = False

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

            If Setting IsNot Nothing Then

                Setting.Value = SettingValue

                Saved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            End If

        End Sub
        Private Function PerformRefreshToken(DataContext As AdvantageFramework.Database.DataContext, ByVal RefreshToken As String) As Boolean
            'output("Exchanging refresh token for access token.")
            Dim Refreshed As Boolean = False
            Dim DiscoveryData As AdvantageFramework.Quickbooks.Classes.DiscoveryData = Nothing
            Dim Credential As String = Nothing
            Dim EncodedCredential As String = Nothing
            Dim BasicAuth As String = Nothing
            Dim RefreshTokenRequestBody As String = Nothing
            Dim RefreshTokenRequest As System.Net.HttpWebRequest = Nothing
            Dim ByteVersion As Byte() = Nothing
            Dim Stream As System.IO.Stream = Nothing
            Dim RefreshTokenResponse As System.Net.HttpWebResponse = Nothing
            Dim ResponseText As String = Nothing
            Dim RefreshTokenEndpointDecoded As Dictionary(Of String, String) = Nothing

            DiscoveryData = GetDiscoveryData()

            Credential = String.Format("{0}:{1}", AdvantageFramework.Quickbooks.QB_CLIENT_ID, AdvantageFramework.Quickbooks.QB_CLIENT_SECRET)

            EncodedCredential = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Credential))

            BasicAuth = String.Format("{0} {1}", "Basic", EncodedCredential)

            RefreshTokenRequestBody = String.Format("grant_type=refresh_token&refresh_token={0}", RefreshToken)
            RefreshTokenRequest = CType(System.Net.WebRequest.Create(DiscoveryData.TokenEndpoint), System.Net.HttpWebRequest)
            RefreshTokenRequest.Method = "POST"
            RefreshTokenRequest.ContentType = "application/x-www-form-urlencoded"
            RefreshTokenRequest.Accept = "application/json"
            RefreshTokenRequest.Headers(System.Net.HttpRequestHeader.Authorization) = BasicAuth
            ByteVersion = System.Text.Encoding.ASCII.GetBytes(RefreshTokenRequestBody)
            RefreshTokenRequest.ContentLength = ByteVersion.Length
            Stream = RefreshTokenRequest.GetRequestStream()
            Stream.Write(ByteVersion, 0, ByteVersion.Length)
            Stream.Close()

            Try

                RefreshTokenResponse = CType(RefreshTokenRequest.GetResponse(), System.Net.HttpWebResponse)

                Using RefreshTokenReader = New System.IO.StreamReader(RefreshTokenResponse.GetResponseStream())

                    ResponseText = RefreshTokenReader.ReadToEnd()
                    RefreshTokenEndpointDecoded = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(ResponseText)

                    If RefreshTokenEndpointDecoded.ContainsKey("error") Then

                        If RefreshTokenEndpointDecoded("error") IsNot Nothing Then
                            ''output(String.Format("OAuth token refresh error: {0}.", refreshtokenEndpointDecoded("error")))


                        End If

                    Else

                        If RefreshTokenEndpointDecoded.ContainsKey("refresh_token") Then

                            SaveSetting(DataContext, AdvantageFramework.Agency.Settings.QB_REFRESH_TOKEN.ToString, RefreshTokenEndpointDecoded("refresh_token"))

                            If RefreshTokenEndpointDecoded.ContainsKey("access_token") Then

                                SaveSetting(DataContext, AdvantageFramework.Agency.Settings.QB_ACCESS_TOKEN.ToString, RefreshTokenEndpointDecoded("access_token"))

                                Refreshed = True

                            End If

                        End If

                    End If

                End Using

            Catch ex As System.Net.WebException

                'If ex.Status = WebExceptionStatus.ProtocolError Then
                '    Dim response = TryCast(ex.Response, HttpWebResponse)

                '    If response IsNot Nothing Then
                '        output("HTTP Status: " & response.StatusCode)
                '        Dim exceptionDetail = response.GetResponseHeader("WWW-Authenticate")

                '        If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then
                '            output(exceptionDetail)
                '        End If

                '        Using reader As StreamReader = New StreamReader(response.GetResponseStream())
                '            Dim responseText As String = reader.ReadToEnd()

                '            If responseText IsNot Nothing AndAlso responseText <> "" Then
                '                output(responseText)
                '            End If
                '        End Using
                '    End If
                'End If
            Finally
                PerformRefreshToken = Refreshed
            End Try

        End Function
        Private Function CreateCustomer(ClientName As String) As Intuit.Ipp.Data.Customer

            Dim Customer As Intuit.Ipp.Data.Customer = Nothing

            Customer = New Intuit.Ipp.Data.Customer()
            Customer.GivenName = If(ClientName.Length > 100, ClientName.Substring(0, 100), ClientName)
            Customer.DisplayName = If(ClientName.Length > 500, ClientName.Substring(0, 500), ClientName)

            CreateCustomer = Customer

        End Function
        Private Function GetQuickBooksSetting(DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting

            Dim Loaded As Boolean = False
            Dim QuickBooksSettingEntity As AdvantageFramework.Database.Entities.QuickbooksSetting = Nothing
            Dim QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting = Nothing

            QuickBooksSettingEntity = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.QuickbooksSetting).FirstOrDefault

            If QuickBooksSettingEntity Is Nothing Then

                Throw New Exception("QuickBooks Settings are incomplete.")

            Else

                QuickBooksSetting = New AdvantageFramework.Quickbooks.Classes.QuickBooksSetting(QuickBooksSettingEntity)

            End If

            GetQuickBooksSetting = QuickBooksSetting

        End Function

#Region " Public "

        Public Function IsQuickBooksEnabled(DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim QuickBooksEnabled As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.QB_ENABLED.ToString)

                If Setting IsNot Nothing AndAlso IsNumeric(Setting.Value) AndAlso CBool(Setting.Value) = True Then

                    QuickBooksEnabled = True

                End If

            End Using

            IsQuickBooksEnabled = QuickBooksEnabled

        End Function
        Public Function GetDiscoveryData() As AdvantageFramework.Quickbooks.Classes.DiscoveryData

            Dim DiscoveryData As AdvantageFramework.Quickbooks.Classes.DiscoveryData = Nothing
            Dim DiscoveryRequest As System.Net.HttpWebRequest = Nothing
            Dim DiscoveryResponse As System.Net.HttpWebResponse = Nothing
            Dim ResponseText As String = Nothing

            DiscoveryRequest = CType(System.Net.WebRequest.Create(QBO_DISCOVERY_URI), System.Net.HttpWebRequest)

            'output("Fetching Discovery Data.")

            DiscoveryRequest.Method = "GET"
            DiscoveryRequest.Accept = "application/json"

            Try

                DiscoveryResponse = CType(DiscoveryRequest.GetResponse(), System.Net.HttpWebResponse)

                Using DiscoveryDataReader = New System.IO.StreamReader(DiscoveryResponse.GetResponseStream())

                    ResponseText = DiscoveryDataReader.ReadToEnd()
                    DiscoveryData = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AdvantageFramework.Quickbooks.Classes.DiscoveryData)(ResponseText)

                End Using

                GetJWKSkeys(DiscoveryData.JWKS_uri)

                'authorizationEndpoint = discoveryDataDecoded.Authorization_endpoint
                'tokenEndpoint = discoveryDataDecoded.Token_endpoint
                'userinfoEndPoint = discoveryDataDecoded.Userinfo_endpoint
                'revokeEndpoint = discoveryDataDecoded.Revocation_endpoint
                'issuerUrl = discoveryDataDecoded.Issuer
                'jwksEndpoint = discoveryDataDecoded.JWKS_uri

                'output("Discovery Data obtained.")

            Catch ex As System.Net.WebException

                If ex.Status = System.Net.WebExceptionStatus.ProtocolError Then

                    DiscoveryResponse = TryCast(ex.Response, System.Net.HttpWebResponse)

                    If DiscoveryResponse IsNot Nothing Then

                        'output("HTTP Status: " & response.StatusCode)

                        Dim exceptionDetail = DiscoveryResponse.GetResponseHeader("WWW-Authenticate")

                        If exceptionDetail IsNot Nothing AndAlso exceptionDetail <> "" Then

                            'output(exceptionDetail)

                        End If

                        Using reader As System.IO.StreamReader = New System.IO.StreamReader(DiscoveryResponse.GetResponseStream())

                            ResponseText = reader.ReadToEnd()

                            If String.IsNullOrWhiteSpace(ResponseText) = False Then

                                'output(ResponseText)

                            End If

                        End Using

                    End If

                Else

                    'output(ex.Message)

                End If

            End Try

            GetDiscoveryData = DiscoveryData

        End Function
        Public Function GetQuickBooksRecordSourceID(DbContext As AdvantageFramework.Database.DbContext) As Integer

            Dim RecordSource As AdvantageFramework.Database.Entities.RecordSource = Nothing
            Dim RecordSourceID As Integer = 0

            RecordSource = (From Entity In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
                            Where Entity.Name = "QuickBooks" AndAlso
                                  Entity.IsSystemSource = True
                            Select Entity).SingleOrDefault

            If RecordSource IsNot Nothing Then

                RecordSourceID = RecordSource.ID

            Else

                Throw New Exception("Cannot find RecordSource for QuickBooks!")

            End If

            GetQuickBooksRecordSourceID = RecordSourceID

        End Function
        Public Function GetClientCrossReferenceCustomerID(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, ByRef HasQuickBookInvoice As Boolean) As String

            Dim RecordSourceID As Integer = 0
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim CustomerID As String = Nothing

            RecordSourceID = GetQuickBooksRecordSourceID(DbContext)

            ClientCrossReference = (From Entity In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                                    Where Entity.ClientCode = ClientCode
                                    Select Entity).SingleOrDefault

            If ClientCrossReference IsNot Nothing Then

                CustomerID = ClientCrossReference.SourceClientCode

                HasQuickBookInvoice = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                                       Where Entity.ClientCode = ClientCode AndAlso
                                             Entity.QuickbooksInvoiceID IsNot Nothing
                                       Select Entity).Any

            End If

            GetClientCrossReferenceCustomerID = CustomerID

        End Function
        Public Function UpdateClientCrossReference(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, QBCustomerID As String) As Boolean

            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim RecordSourceID As Integer = 0
            Dim Updated As Boolean = False

            RecordSourceID = GetQuickBooksRecordSourceID(DbContext)

            If (From Entity In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                Where Entity.SourceClientCode = QBCustomerID AndAlso
                      Entity.ClientCode <> ClientCode
                Select Entity).Any = False Then

                ClientCrossReference = (From Entity In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                                        Where Entity.ClientCode = ClientCode
                                        Select Entity).SingleOrDefault

                If ClientCrossReference Is Nothing Then

                    ClientCrossReference = New Database.Entities.ClientCrossReference
                    ClientCrossReference.DbContext = DbContext
                    ClientCrossReference.ClientCode = ClientCode
                    ClientCrossReference.RecordSourceID = RecordSourceID
                    ClientCrossReference.SourceClientCode = QBCustomerID

                    Updated = AdvantageFramework.Database.Procedures.ClientCrossReference.Insert(DbContext, ClientCrossReference)

                Else

                    ClientCrossReference.SourceClientCode = QBCustomerID
                    DbContext.Entry(ClientCrossReference).State = Entity.EntityState.Modified
                    DbContext.SaveChanges()

                    Updated = True

                End If

            End If

            UpdateClientCrossReference = Updated

        End Function
        'Public Function CreateCustomer(Session As AdvantageFramework.Security.Session, ClientCode As String, ClientName As String, ByRef ErrorMessage As String) As Boolean

        '    Dim Created As Boolean = False
        '    Dim RefreshToken As String = Nothing
        '    Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
        '    Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
        '    Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
        '    Dim Customer As Intuit.Ipp.Data.Customer = Nothing
        '    Dim CustomerCreated As Intuit.Ipp.Data.Customer = Nothing

        '    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        RefreshToken = GetRefreshToken(DataContext)

        '        Try

        '            OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

        '            ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
        '            ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

        '            DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

        '            Customer = CreateCustomer(ClientName)

        '            CustomerCreated = DataService.Add(Of Intuit.Ipp.Data.Customer)(Customer)

        '            Using DbContext As New AdvantageFramework.Database.DbContext(DataContext.Connection.ConnectionString, DataContext.UserCode)

        '                Created = UpdateClientCrossReference(DbContext, ClientCode, CustomerCreated.Id)

        '            End Using

        '        Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
        '            If InvalidTokenException.Message = "Unauthorized-401" Then
        '                If PerformRefreshToken(DataContext, RefreshToken) Then
        '                    Created = CreateCustomer(Session, ClientCode, ClientName, ErrorMessage)
        '                Else
        '                    ErrorMessage = "Could not refresh access token."
        '                End If
        '            End If
        '        Catch ex As Exception
        '            ErrorMessage = ex.Message
        '        End Try

        '    End Using

        '    CreateCustomer = Created

        'End Function
        Public Function GetCustomer(Session As AdvantageFramework.Security.Session, ID As String,
                                    ByRef ReturnCustomer As AdvantageFramework.Quickbooks.Classes.Customer, ByRef ErrorMessage As String) As Boolean

            Dim Loaded As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Customer As Intuit.Ipp.Data.Customer = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RefreshToken = GetRefreshToken(DataContext)

                Try

                    OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                    ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                    ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                    DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                    Customer = DataService.FindById(Of Intuit.Ipp.Data.Customer)(New Intuit.Ipp.Data.Customer With {.Id = ID})

                    If Customer IsNot Nothing Then

                        ReturnCustomer = New AdvantageFramework.Quickbooks.Classes.Customer(Customer)
                        Loaded = True

                    End If

                Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                    If InvalidTokenException.Message = "Unauthorized-401" Then
                        If PerformRefreshToken(DataContext, RefreshToken) Then
                            Loaded = GetCustomer(Session, ID, ReturnCustomer, ErrorMessage)
                        Else
                            ErrorMessage = "Could not refresh access token."
                        End If
                    End If
                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            GetCustomer = Loaded

        End Function
        Public Function GetCustomers(Session As AdvantageFramework.Security.Session, ByRef CustomerList As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer),
                                     ByRef ErrorMessage As String) As Boolean

            Dim Loaded As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Customer As Intuit.Ipp.Data.Customer = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RefreshToken = GetRefreshToken(DataContext)

                Try

                    OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                    ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                    ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                    DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                    CustomerList = (From Entity In DataService.FindAll(Of Intuit.Ipp.Data.Customer)(New Intuit.Ipp.Data.Customer).ToList
                                    Select New AdvantageFramework.Quickbooks.Classes.Customer(Entity)).ToList

                    Loaded = True

                Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                    If InvalidTokenException.Message = "Unauthorized-401" Then
                        If PerformRefreshToken(DataContext, RefreshToken) Then
                            Loaded = GetCustomers(Session, CustomerList, ErrorMessage)
                        Else
                            ErrorMessage = "Could not refresh access token."
                        End If
                    End If
                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            GetCustomers = Loaded

        End Function
        Public Function GetUnMappedCustomers(Session As AdvantageFramework.Security.Session, ByRef Customers As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer),
                                             ByRef ErrorMessage As String) As Boolean

            Dim QuickBooksRecordSourceID As Integer = 0
            Dim MappedCustomerIDs As IEnumerable(Of String) = Nothing
            Dim Loaded As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                QuickBooksRecordSourceID = GetQuickBooksRecordSourceID(DbContext)

                MappedCustomerIDs = (From Entity In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, QuickBooksRecordSourceID)
                                     Select Entity.SourceClientCode).ToArray

            End Using

            If GetCustomers(Session, Customers, ErrorMessage) Then

                Customers = (From Entity In Customers
                             Where MappedCustomerIDs.Contains(Entity.Id) = False
                             Select Entity).ToList

                Loaded = True

            Else

                Customers = New Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer)

            End If

            GetUnMappedCustomers = Loaded

        End Function
        Public Function GetVendor(Session As AdvantageFramework.Security.Session, ID As String,
                                  ByRef ReturnVendor As AdvantageFramework.Quickbooks.Classes.Vendor, ByRef ErrorMessage As String) As Boolean

            Dim Loaded As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Vendor As Intuit.Ipp.Data.Vendor = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RefreshToken = GetRefreshToken(DataContext)

                Try

                    OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                    ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                    ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                    DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                    Vendor = DataService.FindById(Of Intuit.Ipp.Data.Vendor)(New Intuit.Ipp.Data.Vendor With {.Id = ID})

                    If Vendor IsNot Nothing Then

                        ReturnVendor = New AdvantageFramework.Quickbooks.Classes.Vendor(Vendor)
                        Loaded = True

                    End If

                Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                    If InvalidTokenException.Message = "Unauthorized-401" Then
                        If PerformRefreshToken(DataContext, RefreshToken) Then
                            Loaded = GetVendor(Session, ID, ReturnVendor, ErrorMessage)
                        Else
                            ErrorMessage = "Could not refresh access token."
                        End If
                    End If
                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            GetVendor = Loaded

        End Function
        Public Function GetVendors(Session As AdvantageFramework.Security.Session, ByRef VendorList As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Vendor),
                                   ByRef ErrorMessage As String) As Boolean

            Dim Loaded As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Vendor As Intuit.Ipp.Data.Vendor = Nothing

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                RefreshToken = GetRefreshToken(DataContext)

                Try

                    OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                    ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                    ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                    DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                    VendorList = (From Entity In DataService.FindAll(Of Intuit.Ipp.Data.Vendor)(New Intuit.Ipp.Data.Vendor).ToList
                                  Select New AdvantageFramework.Quickbooks.Classes.Vendor(Entity)).ToList

                    Loaded = True

                Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                    If InvalidTokenException.Message = "Unauthorized-401" Then
                        If PerformRefreshToken(DataContext, RefreshToken) Then
                            Loaded = GetVendors(Session, VendorList, ErrorMessage)
                        Else
                            ErrorMessage = "Could not refresh access token."
                        End If
                    End If
                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            GetVendors = Loaded

        End Function
        Public Function GetUnMappedVendors(Session As AdvantageFramework.Security.Session, ByRef Vendors As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Vendor),
                                           ByRef ErrorMessage As String) As Boolean

            Dim QuickBooksRecordSourceID As Integer = 0
            Dim MappedVendorIDs As IEnumerable(Of String) = Nothing
            Dim Loaded As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                QuickBooksRecordSourceID = GetQuickBooksRecordSourceID(DbContext)

                MappedVendorIDs = (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, QuickBooksRecordSourceID)
                                   Select Entity.SourceVendorCode).ToArray

            End Using

            If GetVendors(Session, Vendors, ErrorMessage) Then

                Vendors = (From Entity In Vendors
                           Where MappedVendorIDs.Contains(Entity.Id) = False
                           Select Entity).ToList

                Loaded = True

            Else

                Vendors = New Generic.List(Of AdvantageFramework.Quickbooks.Classes.Vendor)

            End If

            GetUnMappedVendors = Loaded

        End Function
        Public Function GetVendorCrossReferenceVendorID(DbContext As AdvantageFramework.Database.DbContext, VendorCode As String, ByRef HasQuickBookBill As Boolean) As String

            Dim RecordSourceID As Integer = 0
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim VendorID As String = Nothing

            RecordSourceID = GetQuickBooksRecordSourceID(DbContext)

            VendorCrossReference = (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                                    Where Entity.VendorCode = VendorCode
                                    Select Entity).SingleOrDefault

            If VendorCrossReference IsNot Nothing Then

                VendorID = VendorCrossReference.SourceVendorCode

                HasQuickBookBill = (From Entity In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext)
                                    Where Entity.VendorCode = VendorCode AndAlso
                                          Entity.QuickbooksBillID IsNot Nothing
                                    Select Entity).Any

            End If

            GetVendorCrossReferenceVendorID = VendorID

        End Function
        Public Function UpdateVendorCrossReference(DbContext As AdvantageFramework.Database.DbContext, VendorCode As String, QBVendorID As String) As Boolean

            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim RecordSourceID As Integer = 0
            Dim Updated As Boolean = False

            RecordSourceID = GetQuickBooksRecordSourceID(DbContext)

            If (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                Where Entity.SourceVendorCode = QBVendorID AndAlso
                      Entity.VendorCode <> VendorCode
                Select Entity).Any = False Then

                VendorCrossReference = (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, RecordSourceID)
                                        Where Entity.VendorCode = VendorCode
                                        Select Entity).SingleOrDefault

                If VendorCrossReference Is Nothing Then

                    VendorCrossReference = New Database.Entities.VendorCrossReference
                    VendorCrossReference.DbContext = DbContext
                    VendorCrossReference.VendorCode = VendorCode
                    VendorCrossReference.RecordSourceID = RecordSourceID
                    VendorCrossReference.SourceVendorCode = QBVendorID

                    Updated = AdvantageFramework.Database.Procedures.VendorCrossReference.Insert(DbContext, VendorCrossReference)

                Else

                    VendorCrossReference.SourceVendorCode = QBVendorID
                    DbContext.Entry(VendorCrossReference).State = Entity.EntityState.Modified
                    DbContext.SaveChanges()

                    Updated = True

                End If

            End If

            UpdateVendorCrossReference = Updated

        End Function
        Public Function CreateInvoice(Session As AdvantageFramework.Security.Session, InvoiceNumber As Integer, InvoiceSequenceNumber As Short, Type As String,
                                      QBCustomerID As String, Details As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceDetail), ByRef ErrorMessage As String) As Boolean

            Dim Created As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Invoice As Intuit.Ipp.Data.Invoice = Nothing
            Dim CustomerReferenceType As Intuit.Ipp.Data.ReferenceType = Nothing
            Dim Line As Intuit.Ipp.Data.Line = Nothing
            Dim SalesItemLineDetail As Intuit.Ipp.Data.SalesItemLineDetail = Nothing
            Dim ItemReferenceType As Intuit.Ipp.Data.ReferenceType = Nothing
            Dim LineList As Generic.List(Of Intuit.Ipp.Data.Line) = Nothing
            Dim InvoiceCreated As Intuit.Ipp.Data.Invoice = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing
            Dim QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Try

                        QuickBooksSetting = GetQuickBooksSetting(DbContext)

                        AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumberAndType(DbContext, InvoiceNumber, InvoiceSequenceNumber, Type)

                        If AccountReceivable Is Nothing Then

                            Throw New Exception("Cannot find AR invoice.  Please contact software support.")

                        End If

                        RefreshToken = GetRefreshToken(DataContext)

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        If DataService.FindAll(Of Intuit.Ipp.Data.Invoice)(New Intuit.Ipp.Data.Invoice).Where(Function(I) I.DocNumber = InvoiceNumber & QuickBooksSetting.InvoiceNumberSuffix).Any Then

                            Throw New Exception("Invoice no: " & InvoiceNumber & QuickBooksSetting.InvoiceNumberSuffix & " already exists in QuickBooks.")

                        End If

                        Invoice = New Intuit.Ipp.Data.Invoice

                        CustomerReferenceType = New Intuit.Ipp.Data.ReferenceType
                        CustomerReferenceType.Value = QBCustomerID

                        LineList = New Generic.List(Of Intuit.Ipp.Data.Line)

                        For Each Detail In Details

                            StringBuilder = New Text.StringBuilder

                            Line = New Intuit.Ipp.Data.Line
                            Line.Id = Nothing
                            Line.DetailType = Intuit.Ipp.Data.LineDetailTypeEnum.SalesItemLineDetail
                            Line.DetailTypeSpecified = True
                            Line.Amount = Detail.TotalWithTax
                            Line.AmountSpecified = True

                            StringBuilder.Capacity = 4000

                            If String.IsNullOrWhiteSpace(Detail.FunctionType) Then 'media

                                If QuickBooksSetting.InvoiceLineMediaSalesClass Then

                                    StringBuilder.Append(Detail.SalesClassDescription & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineMediaOrderNumber AndAlso Detail.OrderNumber.HasValue Then

                                    StringBuilder.Append(Detail.OrderNumber.Value & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineMediaOrderLineNumber AndAlso Detail.OrderLineNumber.HasValue Then

                                    StringBuilder.Append(Detail.OrderLineNumber & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineMediaOrderNumber AndAlso String.IsNullOrWhiteSpace(Detail.OrderDescription) = False Then

                                    StringBuilder.Append(Detail.OrderDescription & "|")

                                End If

                            Else

                                If QuickBooksSetting.InvoiceLineProductionSalesClass Then

                                    StringBuilder.Append(Detail.SalesClassDescription & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineProductionJobNumber AndAlso Detail.JobNumber.HasValue Then

                                    StringBuilder.Append(Detail.JobNumber.Value & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineProductionJobDescription Then

                                    StringBuilder.Append(Detail.JobDescription & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineProductionComponentNumber AndAlso Detail.JobComponentNumber.HasValue Then

                                    StringBuilder.Append(Detail.JobComponentNumber.Value & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineProductionComponentDescription Then

                                    StringBuilder.Append(Detail.JobComponentDescription & "|")

                                End If

                                If QuickBooksSetting.InvoiceLineProductionFunctionDescription Then

                                    StringBuilder.Append(Detail.FunctionDescription & "|")

                                End If

                            End If
                            '4000 chars max
                            Line.Description = StringBuilder.ToString

                            If Line.Description IsNot Nothing AndAlso Line.Description.EndsWith("|") Then

                                Line.Description = Mid(Line.Description, 1, Line.Description.Length - 1)

                            End If

                            SalesItemLineDetail = New Intuit.Ipp.Data.SalesItemLineDetail
                            SalesItemLineDetail.TaxInclusiveAmt = Detail.TotalWithTax
                            SalesItemLineDetail.TaxInclusiveAmtSpecified = True

                            ItemReferenceType = New Intuit.Ipp.Data.ReferenceType

                            If Detail.FunctionType = "E" Then

                                ItemReferenceType.Value = QuickBooksSetting.InvoiceEmployeeTimeItem

                            ElseIf Detail.FunctionType = "I" Then

                                ItemReferenceType.Value = QuickBooksSetting.InvoiceIncomeOnlyItem

                            ElseIf Detail.FunctionType = "V" Then

                                ItemReferenceType.Value = QuickBooksSetting.InvoiceProductionItem

                            ElseIf String.IsNullOrWhiteSpace(Detail.FunctionType) Then

                                ItemReferenceType.Value = QuickBooksSetting.InvoiceOrderItem

                            Else

                                Throw New Exception("Unknown invoice function type.  Please contact software support.")

                            End If

                            SalesItemLineDetail.ItemRef = ItemReferenceType

                            Line.AnyIntuitObject = SalesItemLineDetail

                            LineList.Add(Line)

                        Next

                        With Invoice
                            .CustomerRef = CustomerReferenceType
                            .Line = LineList.ToArray
                            .DocNumber = InvoiceNumber & QuickBooksSetting.InvoiceNumberSuffix

                            If AccountReceivable.InvoiceDate.HasValue Then

                                .TxnDate = AccountReceivable.InvoiceDate.Value
                                .TxnDateSpecified = True

                            End If

                            If AccountReceivable.DueDate.HasValue Then

                                .DueDate = AccountReceivable.DueDate.Value
                                .DueDateSpecified = True

                            End If

                            '.CurrencyRef = 'required if multicurrency is enabled A three letter string representing the ISO 4217 code for the currency. For example, USD, AUD, EUR, and so on.
                        End With

                        InvoiceCreated = DataService.Add(Of Intuit.Ipp.Data.Invoice)(Invoice)

                        AccountReceivable.QuickbooksInvoiceID = InvoiceCreated.Id
                        AccountReceivable.QuickbooksCreateDate = Now
                        AccountReceivable.QuickbooksCreateByUserCode = Session.UserCode

                        DbContext.Entry(AccountReceivable).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                        Created = True

                        'Dim item As Item = CreateItem(accountAdded)
                        'Dim itemAdded As Item = dataService.Add(Of Item)(item)
                        'Dim objInvoice As Invoice = CreateInvoice("4620816365169835120", customerCreated, itemAdded)
                        'Dim addedInvoice As Invoice = dataService.Add(Of Invoice)(objInvoice)
                        'dataService.SendEmail(Of Invoice)(addedInvoice, "abc@gmail.com")
                        'Dim payment As Payment = CreatePayment(customerCreated, addedInvoice)
                        'dataService.Add(Of Payment)(payment)
                        'Return View("Index", CObj(("QBO API calls Success!")))

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Created = CreateInvoice(Session, InvoiceNumber, InvoiceSequenceNumber, Type, QBCustomerID, Details, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            CreateInvoice = Created

        End Function
        Public Function VoidInvoice(Session As AdvantageFramework.Security.Session, InvoiceNumber As Integer, InvoiceSequenceNumber As Short, Type As String,
                                    ByRef ErrorMessage As String) As Boolean

            Dim Voided As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Invoice As Intuit.Ipp.Data.Invoice = Nothing
            Dim InvoiceUpdated As Intuit.Ipp.Data.Invoice = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumberAndType(DbContext, InvoiceNumber, InvoiceSequenceNumber, Type)

                If AccountReceivable Is Nothing Then

                    Throw New Exception("Cannot find AR invoice.  Please contact software support.")

                End If

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RefreshToken = GetRefreshToken(DataContext)

                    Try

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        Invoice = DataService.FindById(Of Intuit.Ipp.Data.Invoice)(New Intuit.Ipp.Data.Invoice With {.Id = AccountReceivable.QuickbooksInvoiceID})

                        If Invoice IsNot Nothing Then

                            InvoiceUpdated = DataService.Void(Of Intuit.Ipp.Data.Invoice)(Invoice)

                            Voided = True

                        Else

                            Throw New Exception("Invoice is not found in QuickBooks.")

                        End If

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Voided = VoidInvoice(Session, InvoiceNumber, InvoiceSequenceNumber, Type, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            VoidInvoice = Voided

        End Function
        Public Function CreateBill(Session As AdvantageFramework.Security.Session, AccountPayableID As Integer, SequenceNumber As Short,
                                   QBVendorID As String, APDetails As Generic.List(Of AdvantageFramework.Quickbooks.Classes.APDetail), ByRef ErrorMessage As String) As Boolean

            Dim Created As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Bill As Intuit.Ipp.Data.Bill = Nothing
            Dim VendorReferenceType As Intuit.Ipp.Data.ReferenceType = Nothing
            Dim Line As Intuit.Ipp.Data.Line = Nothing
            Dim AccountBasedExpenseLineDetail As Intuit.Ipp.Data.AccountBasedExpenseLineDetail = Nothing
            Dim ItemReferenceType As Intuit.Ipp.Data.ReferenceType = Nothing
            Dim LineList As Generic.List(Of Intuit.Ipp.Data.Line) = Nothing
            Dim BillCreated As Intuit.Ipp.Data.Bill = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Try

                        QuickBooksSetting = GetQuickBooksSetting(DbContext)

                        AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, AccountPayableID, SequenceNumber)

                        If AccountPayable Is Nothing Then

                            Throw New Exception("Cannot find AP invoice.  Please contact software support.")

                        ElseIf String.IsNullOrWhiteSpace(AccountPayable.QuickbooksBillID) = False Then

                            Throw New Exception("AP invoice was already sent to QuickBooks.")

                        End If

                        RefreshToken = GetRefreshToken(DataContext)

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        If DataService.FindAll(Of Intuit.Ipp.Data.Bill)(New Intuit.Ipp.Data.Bill).Where(Function(I) I.DocNumber = AccountPayable.InvoiceNumber AndAlso I.VendorRef IsNot Nothing AndAlso I.VendorRef.Value = QBVendorID).Any Then

                            Throw New Exception("Bill no: " & AccountPayable.InvoiceNumber & " already exists in QuickBooks.")

                        End If

                        Bill = New Intuit.Ipp.Data.Bill

                        VendorReferenceType = New Intuit.Ipp.Data.ReferenceType
                        VendorReferenceType.Value = QBVendorID

                        LineList = New Generic.List(Of Intuit.Ipp.Data.Line)

                        For Each APDetail In APDetails

                            StringBuilder = New Text.StringBuilder

                            Line = New Intuit.Ipp.Data.Line
                            Line.Id = Nothing
                            Line.DetailType = Intuit.Ipp.Data.LineDetailTypeEnum.AccountBasedExpenseLineDetail
                            Line.DetailTypeSpecified = True
                            Line.Amount = APDetail.Amount
                            Line.AmountSpecified = True

                            StringBuilder.Capacity = 4000

                            If APDetail.OrderNumber.HasValue Then

                                StringBuilder.Append(APDetail.OrderNumber.Value & "|")

                            End If

                            If APDetail.OrderLineNumber.HasValue Then

                                StringBuilder.Append(APDetail.OrderLineNumber.Value & "|")

                            End If

                            If APDetail.JobNumber.HasValue Then

                                StringBuilder.Append(APDetail.JobNumber.Value & "|")

                            End If

                            If APDetail.JobComponentNumber.HasValue Then

                                StringBuilder.Append(APDetail.JobComponentNumber.Value & "|")

                            End If

                            If String.IsNullOrWhiteSpace(APDetail.Description) = False Then

                                StringBuilder.Append(APDetail.Description & "|")

                            End If

                            '4000 chars max
                            Line.Description = StringBuilder.ToString

                            If Line.Description IsNot Nothing AndAlso Line.Description.EndsWith("|") Then

                                Line.Description = Mid(Line.Description, 1, Line.Description.Length - 1)

                            End If

                            AccountBasedExpenseLineDetail = New Intuit.Ipp.Data.AccountBasedExpenseLineDetail
                            AccountBasedExpenseLineDetail.TaxInclusiveAmt = APDetail.Amount
                            AccountBasedExpenseLineDetail.TaxInclusiveAmtSpecified = True

                            ItemReferenceType = New Intuit.Ipp.Data.ReferenceType

                            If APDetail.IsOrder Then

                                ItemReferenceType.Value = QuickBooksSetting.BillMediaAccount

                            ElseIf APDetail.IsProduction Then

                                ItemReferenceType.Value = QuickBooksSetting.BillProductionAccount

                            Else

                                ItemReferenceType.Value = QuickBooksSetting.BillNonClientAccount

                            End If

                            AccountBasedExpenseLineDetail.AccountRef = ItemReferenceType

                            Line.AnyIntuitObject = AccountBasedExpenseLineDetail

                            LineList.Add(Line)

                        Next

                        With Bill
                            .VendorRef = VendorReferenceType
                            .Line = LineList.ToArray
                            .TxnDate = AccountPayable.InvoiceDate
                            .TxnDateSpecified = True
                            .DueDate = AccountPayable.PaidDate
                            .DueDateSpecified = True
                            .DocNumber = AccountPayable.InvoiceNumber
                            '.CurrencyRef = 'required if multicurrency is enabled A three letter string representing the ISO 4217 code for the currency. For example, USD, AUD, EUR, and so on.
                        End With

                        BillCreated = DataService.Add(Of Intuit.Ipp.Data.Bill)(Bill)

                        AccountPayable.QuickbooksBillID = BillCreated.Id
                        AccountPayable.QuickbooksCreateDate = Now
                        AccountPayable.QuickbooksCreateByUserCode = Session.UserCode

                        DbContext.Entry(AccountPayable).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                        Created = True

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Created = CreateBill(Session, AccountPayableID, SequenceNumber, QBVendorID, APDetails, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            CreateBill = Created

        End Function
        Public Function DeleteBill(Session As AdvantageFramework.Security.Session, AccountPayableID As Integer, SequenceNumber As Short,
                                   ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Bill As Intuit.Ipp.Data.Bill = Nothing
            Dim BillDeleted As Intuit.Ipp.Data.Bill = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, AccountPayableID, SequenceNumber)

                If AccountPayable Is Nothing Then

                    Throw New Exception("Cannot find AP invoice.  Please contact software support.")

                ElseIf String.IsNullOrWhiteSpace(AccountPayable.QuickbooksBillID) Then

                    Throw New Exception("AP invoice was deleted from QuickBooks.")

                End If

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RefreshToken = GetRefreshToken(DataContext)

                    Try

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        Bill = DataService.FindById(Of Intuit.Ipp.Data.Bill)(New Intuit.Ipp.Data.Bill With {.Id = AccountPayable.QuickbooksBillID})

                        If Bill IsNot Nothing Then

                            BillDeleted = DataService.Delete(Of Intuit.Ipp.Data.Bill)(Bill)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_HEADER SET QUICKBOOKS_BILL_ID = NULL WHERE AP_ID = {0}", AccountPayableID))

                            Deleted = True

                        Else

                            Throw New Exception("Bill is not found in QuickBooks.")

                        End If

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Deleted = DeleteBill(Session, AccountPayableID, SequenceNumber, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            DeleteBill = Deleted

        End Function
        Public Function GetSettings(Session As AdvantageFramework.Security.Session, ByRef Items As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Item),
                                    ByRef Accounts As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Account),
                                    ByRef QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting, ByRef ErrorMessage As String) As Boolean

            Dim Loaded As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim ItemList As List(Of Intuit.Ipp.Data.Item) = Nothing
            Dim AccountList As List(Of Intuit.Ipp.Data.Account) = Nothing
            Dim QuickBooksSettingEntity As AdvantageFramework.Database.Entities.QuickbooksSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                QuickBooksSettingEntity = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.QuickbooksSetting).FirstOrDefault

                If QuickBooksSettingEntity IsNot Nothing Then

                    QuickBooksSetting = New AdvantageFramework.Quickbooks.Classes.QuickBooksSetting(QuickBooksSettingEntity)

                Else

                    QuickBooksSetting = New AdvantageFramework.Quickbooks.Classes.QuickBooksSetting()

                End If

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    RefreshToken = GetRefreshToken(DataContext)

                    Try

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        'Dim Preferences As Generic.List(Of Intuit.Ipp.Data.Preferences) = Nothing

                        'Preferences = DataService.FindAll(Of Intuit.Ipp.Data.Preferences)(New Intuit.Ipp.Data.Preferences).ToList

                        'this is needed to create Invoice 
                        ItemList = DataService.FindAll(Of Intuit.Ipp.Data.Item)(New Intuit.Ipp.Data.Item).ToList

                        Items = (From Entity In ItemList
                                 Select New AdvantageFramework.Quickbooks.Classes.Item(Entity)).ToList

                        AccountList = DataService.FindAll(Of Intuit.Ipp.Data.Account)(New Intuit.Ipp.Data.Account).Where(Function(A) A.AccountType = Intuit.Ipp.Data.AccountTypeEnum.Expense OrElse
                                                                                                                                     A.AccountType = Intuit.Ipp.Data.AccountTypeEnum.CostofGoodsSold).ToList

                        Accounts = (From Entity In AccountList
                                    Select New AdvantageFramework.Quickbooks.Classes.Account(Entity)).ToList

                        Loaded = True

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Loaded = GetSettings(Session, Items, Accounts, QuickBooksSetting, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            GetSettings = Loaded

        End Function
        Public Function SaveSettings(Session As AdvantageFramework.Security.Session, QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting, ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim QuickBooksSettingEntity As AdvantageFramework.Database.Entities.QuickbooksSetting = Nothing

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    QuickBooksSettingEntity = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.QuickbooksSetting).FirstOrDefault

                    If QuickBooksSettingEntity Is Nothing Then

                        QuickBooksSettingEntity = New AdvantageFramework.Database.Entities.QuickbooksSetting
                        QuickBooksSettingEntity.DbContext = DbContext

                        QuickBooksSetting.SaveToEntity(QuickBooksSettingEntity)
                        DbContext.QuickbooksSettings.Add(QuickBooksSettingEntity)
                        DbContext.SaveChanges()

                    Else

                        QuickBooksSetting.SaveToEntity(QuickBooksSettingEntity)
                        DbContext.Entry(QuickBooksSettingEntity).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                    End If

                End Using

                Saved = True

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            SaveSettings = Saved

        End Function
        Public Function UpdateBill(Session As AdvantageFramework.Security.Session, AccountPayableID As Integer, SequenceNumber As Short, APDetails As Generic.List(Of AdvantageFramework.Quickbooks.Classes.APDetail),
                                   ByRef ErrorMessage As String) As Boolean

            Dim Updated As Boolean = False
            Dim RefreshToken As String = Nothing
            Dim OAuth2RequestValidator As Intuit.Ipp.Security.OAuth2RequestValidator = Nothing
            Dim ServiceContext As Intuit.Ipp.Core.ServiceContext = Nothing
            Dim DataService As Intuit.Ipp.DataService.DataService = Nothing
            Dim Bill As Intuit.Ipp.Data.Bill = Nothing
            Dim BillUpdated As Intuit.Ipp.Data.Bill = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim LineList As Generic.List(Of Intuit.Ipp.Data.Line) = Nothing
            Dim StringBuilder As Text.StringBuilder = Nothing
            Dim Line As Intuit.Ipp.Data.Line = Nothing
            Dim AccountBasedExpenseLineDetail As Intuit.Ipp.Data.AccountBasedExpenseLineDetail = Nothing
            Dim ItemReferenceType As Intuit.Ipp.Data.ReferenceType = Nothing
            Dim QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    Try

                        QuickBooksSetting = GetQuickBooksSetting(DbContext)

                        AccountPayable = AdvantageFramework.Database.Procedures.AccountPayable.LoadByAccountPayableIDAndSequenceNumber(DbContext, AccountPayableID, SequenceNumber)

                        If AccountPayable Is Nothing Then

                            Throw New Exception("Cannot find AP invoice.  Please contact software support.")

                        ElseIf String.IsNullOrWhiteSpace(AccountPayable.QuickbooksBillID) Then

                            Throw New Exception("AP invoice was deleted from QuickBooks.")

                        End If

                        RefreshToken = GetRefreshToken(DataContext)

                        OAuth2RequestValidator = New Intuit.Ipp.Security.OAuth2RequestValidator(GetAccessToken(DataContext))

                        ServiceContext = New Intuit.Ipp.Core.ServiceContext(GetRealmID(DataContext), Intuit.Ipp.Core.IntuitServicesType.QBO, OAuth2RequestValidator)
                        ServiceContext.IppConfiguration.BaseUrl.Qbo = AdvantageFramework.Quickbooks.QBO_BASEURL

                        DataService = New Intuit.Ipp.DataService.DataService(ServiceContext)

                        Bill = DataService.FindById(Of Intuit.Ipp.Data.Bill)(New Intuit.Ipp.Data.Bill With {.Id = AccountPayable.QuickbooksBillID})

                        If Bill IsNot Nothing Then

                            LineList = New Generic.List(Of Intuit.Ipp.Data.Line)

                            For Each APDetail In APDetails

                                StringBuilder = New Text.StringBuilder

                                Line = New Intuit.Ipp.Data.Line
                                Line.Id = Nothing
                                Line.DetailType = Intuit.Ipp.Data.LineDetailTypeEnum.AccountBasedExpenseLineDetail
                                Line.DetailTypeSpecified = True
                                Line.Amount = APDetail.Amount
                                Line.AmountSpecified = True

                                StringBuilder.Capacity = 4000

                                If APDetail.OrderNumber.HasValue Then

                                    StringBuilder.Append(APDetail.OrderNumber.Value & "|")

                                End If

                                If APDetail.OrderLineNumber.HasValue Then

                                    StringBuilder.Append(APDetail.OrderLineNumber.Value & "|")

                                End If

                                If APDetail.JobNumber.HasValue Then

                                    StringBuilder.Append(APDetail.JobNumber.Value & "|")

                                End If

                                If APDetail.JobComponentNumber.HasValue Then

                                    StringBuilder.Append(APDetail.JobComponentNumber.Value & "|")

                                End If

                                If String.IsNullOrWhiteSpace(APDetail.Description) = False Then

                                    StringBuilder.Append(APDetail.Description & "|")

                                End If

                                '4000 chars max
                                Line.Description = StringBuilder.ToString

                                If Line.Description IsNot Nothing AndAlso Line.Description.EndsWith("|") Then

                                    Line.Description = Mid(Line.Description, 1, Line.Description.Length - 1)

                                End If

                                AccountBasedExpenseLineDetail = New Intuit.Ipp.Data.AccountBasedExpenseLineDetail
                                AccountBasedExpenseLineDetail.TaxInclusiveAmt = APDetail.Amount
                                AccountBasedExpenseLineDetail.TaxInclusiveAmtSpecified = True

                                ItemReferenceType = New Intuit.Ipp.Data.ReferenceType

                                If APDetail.IsOrder Then

                                    ItemReferenceType.Value = QuickBooksSetting.BillMediaAccount

                                ElseIf APDetail.IsProduction Then

                                    ItemReferenceType.Value = QuickBooksSetting.BillProductionAccount

                                Else

                                    ItemReferenceType.Value = QuickBooksSetting.BillNonClientAccount

                                End If

                                AccountBasedExpenseLineDetail.AccountRef = ItemReferenceType

                                Line.AnyIntuitObject = AccountBasedExpenseLineDetail

                                LineList.Add(Line)

                            Next

                            With Bill
                                '.VendorRef = VendorReferenceType
                                .Line = LineList.ToArray
                                .TxnDate = AccountPayable.InvoiceDate
                                .TxnDateSpecified = True
                                .DueDate = AccountPayable.PaidDate
                                .DueDateSpecified = True
                                .DocNumber = AccountPayable.InvoiceNumber
                                '.CurrencyRef = 'required if multicurrency is enabled A three letter string representing the ISO 4217 code for the currency. For example, USD, AUD, EUR, and so on.
                            End With

                            BillUpdated = DataService.Update(Of Intuit.Ipp.Data.Bill)(Bill)

                            Updated = True

                        Else

                            Throw New Exception("Bill is not found in QuickBooks.")

                        End If

                    Catch InvalidTokenException As Intuit.Ipp.Exception.InvalidTokenException
                        If InvalidTokenException.Message = "Unauthorized-401" Then
                            If PerformRefreshToken(DataContext, RefreshToken) Then
                                Updated = UpdateBill(Session, AccountPayableID, SequenceNumber, APDetails, ErrorMessage)
                            Else
                                ErrorMessage = "Could not refresh access token."
                            End If
                        End If
                    Catch ex As Exception
                        ErrorMessage = ex.Message
                    End Try

                End Using

            End Using

            UpdateBill = Updated

        End Function

#End Region

#End Region

    End Module

End Namespace
