Namespace Services.ComScore.Classes

    Class Api

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BaseUrl As System.Uri

        Public Property TimeoutSec As Integer

        Public Property ClientId As String

        Public Property ClientSecret As String

        Public Property RetriveDatasetEndpoint As String

#End Region

#Region " Methods "

        'Private Shared RetriveDatasetEndpoint As String = "/mrtv/v7/retrieve_dataset"

        Public Sub New(ByVal BaseUrl As System.Uri, ByVal ClientId As String, ByVal ClientSecret As String, ByVal TimeoutSec As Integer)

            Me.BaseUrl = BaseUrl
            Me.TimeoutSec = Math.Max(TimeoutSec, 300)
            Me.ClientId = ClientId
            Me.ClientSecret = ClientSecret

            If BaseUrl.Equals(AdvantageFramework.ComScore.COMSCORE_URL) Then

                RetriveDatasetEndpoint = "/mrtv/v7/retrieve_dataset"

            Else

                RetriveDatasetEndpoint = "/tv/v3/retrieve_dataset"

            End If

        End Sub
        Private Shared Function GenerateTimestamp() As String

            GenerateTimestamp = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss G\MT")

        End Function
        Private Function GenerateSignature(ByVal EndpointPath As String, ByVal Timestamp As String, ByVal Request As String) As String

            Dim Encoding As System.Text.Encoding = Nothing
            Dim StringToSign As String = Nothing
            Dim HMACSHA1 As System.Security.Cryptography.HMACSHA1 = Nothing

            Encoding = New System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier:=True, throwOnInvalidBytes:=True)

            StringToSign = String.Join(vbLf, New String() {EndpointPath, Timestamp, Request})

            HMACSHA1 = New System.Security.Cryptography.HMACSHA1(Encoding.GetBytes(ClientSecret))

            HMACSHA1.Initialize()

            GenerateSignature = Convert.ToBase64String(HMACSHA1.ComputeHash(Encoding.GetBytes(StringToSign)))

        End Function
        Private Function HandleWebException(ByVal WebException As System.Net.WebException, ByVal EndpointVersion As String, ByVal PageNo As Int32) As Services.ComScore.Classes.Response

            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim httpResponse As System.Net.HttpWebResponse = Nothing
            Dim IsJson As Boolean
            Dim rawData As String = Nothing

            If WebException.Status = System.Net.WebExceptionStatus.ProtocolError Then

                httpResponse = TryCast(WebException.Response, System.Net.HttpWebResponse)

                If httpResponse IsNot Nothing Then

                    If httpResponse.StatusCode = System.Net.HttpStatusCode.OK OrElse httpResponse.StatusCode = System.Net.HttpStatusCode.BadRequest OrElse
                            httpResponse.StatusCode = System.Net.HttpStatusCode.Forbidden OrElse httpResponse.StatusCode = System.Net.HttpStatusCode.RequestTimeout Then

                        If WebException.Response IsNot Nothing Then

                            IsJson = httpResponse.ContentType = "application/json; charset=UTF-8"
                            rawData = New System.IO.StreamReader(WebException.Response.GetResponseStream()).ReadToEnd()
                            Response = New Services.ComScore.Classes.Response(rawData, IsJson, EndpointVersion, PageNo)

                        End If

                    ElseIf httpResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized Then

                        Throw New Exception("Comscore credentials not accepted, please contact your Comscore rep.")

                    End If

                End If

            ElseIf WebException.Status = System.Net.WebExceptionStatus.Timeout Then
                Throw New Exception("Timeout occurred from Comscore API.")
            End If

            If Response Is Nothing Then
                Throw New Exception("Response from Comscore API: " & WebException.Message)
            End If

            HandleWebException = Response

        End Function
        Public Function Process(ByVal Request As Services.ComScore.Classes.Request) As Services.ComScore.Classes.Response

            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim Timestamp As String = Nothing
            Dim Signature As String = Nothing
            Dim EncodedRequest As Byte() = Nothing
            Dim HttpWebResponse As System.Net.HttpWebResponse = Nothing
            Dim RawData As String = Nothing

            Try

                If System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.SystemDefault OrElse
                            System.Net.ServicePointManager.SecurityProtocol = (Net.SecurityProtocolType.Ssl3 Or Net.SecurityProtocolType.Tls) Then

                    System.Net.ServicePointManager.SecurityProtocol = (Net.SecurityProtocolType.Ssl3 Or Net.SecurityProtocolType.Tls Or Net.SecurityProtocolType.Tls11 Or Net.SecurityProtocolType.Tls12)

                End If

                HttpWebRequest = CType(System.Net.WebRequest.Create(New Uri(BaseUrl, Request.Endpoint)), System.Net.HttpWebRequest)

                HttpWebRequest.Method = "POST"
                HttpWebRequest.ContentType = "application/json"
                HttpWebRequest.Date = DateTime.UtcNow
                HttpWebRequest.Timeout = TimeoutSec * 1000
                HttpWebRequest.ReadWriteTimeout = TimeoutSec * 1000

                Timestamp = GenerateTimestamp()

                Signature = GenerateSignature(Request.Endpoint, Timestamp, Request.RawRequest)
                EncodedRequest = System.Text.Encoding.UTF8.GetBytes(Request.RawRequest)

                HttpWebRequest.Headers(System.Net.HttpRequestHeader.Authorization) = String.Format("RTK {0}:{1}", ClientId, Signature)
                HttpWebRequest.ContentLength = EncodedRequest.Length

                Using stream = HttpWebRequest.GetRequestStream()

                    stream.Write(EncodedRequest, 0, EncodedRequest.Length)

                End Using

                HttpWebResponse = CType(HttpWebRequest.GetResponse(), System.Net.HttpWebResponse)

                If HttpWebResponse.ContentType <> "application/json; charset=UTF-8" Then

                    Throw New ApiException("Unexpected content type: " & HttpWebResponse.ContentType, Nothing)

                End If

                RawData = New System.IO.StreamReader(HttpWebResponse.GetResponseStream()).ReadToEnd()
                Response = New Response(RawData, True, Request.EndpointVersion, Request.PageNo)

            Catch ex As System.Net.WebException

                Response = HandleWebException(ex, Request.EndpointVersion, Request.PageNo)

            End Try

            Process = Response

        End Function
        Private Shared Function WaitForDataRequest(ByVal Response As Services.ComScore.Classes.Response, ByVal RetriveDatasetEndpoint As String) As Services.ComScore.Classes.Request

            Dim Request As Services.ComScore.Classes.Request = Nothing

            Request = New Request(String.Format("
					{{
						'endpoint_path': '{0}',
						'request': {{
							'token': '{1}',
							'timeout': 120 
						}}
					}}

					", RetriveDatasetEndpoint, Response.NextPageToken), Response.PageNo)

            WaitForDataRequest = Request

        End Function
        Public Function NextPageRequest(ByVal Response As Services.ComScore.Classes.Response) As Services.ComScore.Classes.Request

            Dim Request As Services.ComScore.Classes.Request = Nothing

            If Response.Status = "success" AndAlso Response.NextPageToken IsNot Nothing Then

                Request = New Request(String.Format("
						{{
							'endpoint_path': '{0}',
							'request': {{
								'token': '{1}',
								'timeout': 120 
							}}
						}}", RetriveDatasetEndpoint, Response.NextPageToken), Response.PageNo + 1)

            End If

            NextPageRequest = Request

        End Function
        Public Function RetrievePage(ByVal Request As Services.ComScore.Classes.Request) As Services.ComScore.Classes.Response

            Dim Response As Services.ComScore.Classes.Response = Nothing

            Response = Process(Request)

            While Response.StillProcessing AndAlso Response.NextPageToken IsNot Nothing

                Response = Process(Api.WaitForDataRequest(Response, Me.RetriveDatasetEndpoint))

            End While

            RetrievePage = Response

        End Function

#End Region

    End Class

End Namespace
