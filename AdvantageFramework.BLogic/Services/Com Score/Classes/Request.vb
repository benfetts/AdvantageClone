Namespace Services.ComScore.Classes

    Class Request

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RawRequest As String

        Public Property Endpoint As String

        Public Property PageNo As System.Int32

        Public Property EndpointVersion As String

#End Region

#Region " Methods "

        Public Sub New(ByVal jsonRequest As String, ByVal Optional pageNo As Integer = 0)

            'objects
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JToken As Newtonsoft.Json.Linq.JToken = Nothing

            JObject = Newtonsoft.Json.Linq.JObject.Parse(jsonRequest)

            JToken = JObject.SelectToken("endpoint_path")

            If JToken Is Nothing Then

                Throw New ApiException("Mandatory 'endpoint_path' element is missing from the file", Nothing)

            Else

                Endpoint = JToken.ToString

            End If

            JToken = JObject.SelectToken("request")

            If JToken Is Nothing Then

                Throw New ApiException("Mandatory 'request' element is missing from the file", Nothing)

            Else

                RawRequest = JToken.ToString

            End If

            pageNo = pageNo

            Dim parts = Endpoint.Split(New Char() {"/"c}, 4)

            If parts.Length < 3 Then

                Throw New ApiException("Invalid endpoint : " & Endpoint, Nothing)

            End If

            EndpointVersion = parts(2)

        End Sub

#End Region

    End Class

End Namespace