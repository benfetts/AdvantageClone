Namespace Base

    Public MustInherit Class ServiceBase

        Public Event WriteToEventLogEvent(ByVal Message As String)

#Region " Variables "

#End Region

#Region " Properties "

        Protected Property ConnectionString As String
        Protected Property EmployeeCode As String
        Protected Property IsWebvantage As Boolean
        Protected Property EmailAddress As String
        Protected Property UseWindowsAuthentication As Boolean
        Protected Property ClientCode As String

#End Region

#Region " Methods "

        Protected Sub WriteToEventLog(ByVal Message As String)

            RaiseEvent WriteToEventLogEvent(Message)

        End Sub
        Private Function LoadUserCredential(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeCode As String, ClientCode As String) As Google.Apis.Auth.OAuth2.UserCredential
            'objects
            Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing

            Try

                UserCredential = AdvantageFramework.GoogleServices.LoadUserCredential(DataContext, EmployeeCode, GetScope(), ClientCode)

            Catch ex As Exception
                UserCredential = Nothing
            Finally
                LoadUserCredential = UserCredential
            End Try

        End Function
        Protected Function CreateInitializer(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext,
                                             ByVal Employee As AdvantageFramework.GoogleServices.Database.Entities.Employee) As Google.Apis.Services.BaseClientService.Initializer

            'objects
            Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
            Dim Initializer As Google.Apis.Services.BaseClientService.Initializer = Nothing
            Dim TokenResponse As Google.Apis.Auth.OAuth2.Responses.TokenResponse = Nothing

            Try

                If String.IsNullOrWhiteSpace(Employee.GoogleToken) = False Then

                    Try

                        TokenResponse = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize(Of Google.Apis.Auth.OAuth2.Responses.TokenResponse)(Employee.GoogleToken)

                    Catch ex As Exception
                        TokenResponse = Nothing
                    End Try

                    If TokenResponse IsNot Nothing Then

                        UserCredential = LoadUserCredential(DataContext, Employee.EmployeeCode, Nothing)

                        Initializer = New Google.Apis.Services.BaseClientService.Initializer()

                        Initializer.HttpClientInitializer = UserCredential
                        Initializer.ApplicationName = "The Advantage Software Company - Advantage - 1"

                    End If

                End If

            Catch ex As Exception
                Initializer = Nothing
            Finally
                CreateInitializer = Initializer
            End Try

        End Function
        Protected Function CreateInitializerDoubleClick(ProfileID As Long, ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByRef ErrorMessage As String) As Google.Apis.Services.BaseClientService.Initializer

            'objects
            Dim GoogleToken As String = Nothing
            Dim UserCredential As Google.Apis.Auth.OAuth2.UserCredential = Nothing
            Dim Initializer As Google.Apis.Services.BaseClientService.Initializer = Nothing
            Dim TokenResponse As Google.Apis.Auth.OAuth2.Responses.TokenResponse = Nothing
            Dim DoubleClickValidToken As DoubleClickValidToken = Nothing

            Try

                DoubleClickValidToken = DataContext.ExecuteQuery(Of DoubleClickValidToken)(String.Format("exec advsp_doubleclick_validate_profileid {0}", ProfileID)).SingleOrDefault

                If DoubleClickValidToken.IsValid = 1 Then

                    GoogleToken = DoubleClickValidToken.GoogleToken

                    If String.IsNullOrWhiteSpace(Me.ClientCode) = True Then

                        Me.ClientCode = DoubleClickValidToken.ClientCode

                    End If

                Else

                    ErrorMessage = "Cannot find token for ProfileID " & ProfileID & "."

                End If

                If String.IsNullOrWhiteSpace(GoogleToken) = False Then

                    Try

                        TokenResponse = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize(Of Google.Apis.Auth.OAuth2.Responses.TokenResponse)(GoogleToken)

                    Catch ex As Exception
                        TokenResponse = Nothing
                    End Try

                    If TokenResponse IsNot Nothing Then

                        UserCredential = LoadUserCredential(DataContext, Nothing, ClientCode)

                        Initializer = New Google.Apis.Services.BaseClientService.Initializer()

                        Initializer.HttpClientInitializer = UserCredential
                        Initializer.ApplicationName = "The Advantage Software Company - Advantage - 1"

                    End If

                End If

            Catch ex As Exception
                Initializer = Nothing
            Finally
                CreateInitializerDoubleClick = Initializer
            End Try

        End Function

#Region "  Public "

        Public Function Authorize() As Boolean

            Authorize = AdvantageFramework.GoogleServices.Authorize(Me.ConnectionString, Me.EmployeeCode, GetScope(), Me.UseWindowsAuthentication, Me.ClientCode)

        End Function
        Public Function Deauthorize() As Boolean

            Deauthorize = AdvantageFramework.GoogleServices.Deauthorize(Me.ConnectionString, Me.EmployeeCode, GetScope(), Me.UseWindowsAuthentication, Me.ClientCode)

        End Function
        Public Function GetAuthorizationUri() As System.Uri

            GetAuthorizationUri = AdvantageFramework.GoogleServices.GetAuthorizationCodeUri(Me.EmailAddress, GetScope(), _IsWebvantage)

        End Function
        Public Function ExchangeCodeForToken(ByVal AuthorizationCode As String) As Boolean

            Using DataContext = New AdvantageFramework.GoogleServices.Database.DataContext(Me.ConnectionString, Me.UseWindowsAuthentication)

                ExchangeCodeForToken = AdvantageFramework.GoogleServices.ExchangeCodeForToken(DataContext, Me.EmployeeCode, AuthorizationCode, GetScope(), Me.IsWebvantage, Me.ClientCode)

            End Using

        End Function
        Public Sub New(ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal EmailAddress As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean,
                       Optional ByVal ClientCode As String = Nothing)

            Me.ConnectionString = ConnectionString
            Me.EmployeeCode = EmployeeCode
            Me.IsWebvantage = IsWebvantage
            Me.EmailAddress = EmailAddress
            Me.UseWindowsAuthentication = UseWindowsAuthentication
            Me.ClientCode = ClientCode

        End Sub
        Public MustOverride Function GetScope() As IEnumerable(Of String)

#End Region

#End Region

        Private Class DoubleClickValidToken

            Public IsValid As Integer
            Public GoogleToken As String
            Public ClientCode As String

        End Class

    End Class

End Namespace

