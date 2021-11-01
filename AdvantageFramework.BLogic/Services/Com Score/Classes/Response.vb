Namespace Services.ComScore.Classes

    Structure Warning

        Public Sub New(ByVal Code As Int32, ByVal Message As String)

            Me.Code = Code
            Me.Message = Message

        End Sub

        Public Code As Int32
        Public Message As String

    End Structure

    Class Response

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RawResponse As String

        Public Property Status As String

        Public Property RequestId As String

        Public Property NextPageToken As String

        Public Property Warnings As AdvantageFramework.Services.ComScore.Classes.Warning()

        Public Property Disclosures As String()

        Public Property ApiTime As System.TimeSpan

        Public Property FinalDate As System.DateTime?

        Public Property StillProcessing As Boolean

        Public Property PageNo As System.Int32

        Public Property EndpointVersion As String

        Public Property IsJson As Boolean

#End Region

#Region " Methods "

        Public Sub New(ByVal RawResponse As String, ByVal IsJson As Boolean, ByVal EndpointVersion As String, ByVal PageNo As Integer)

            'objects
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing

            Me.IsJson = IsJson
            Me.RawResponse = RawResponse
            Me.EndpointVersion = EndpointVersion
            Me.PageNo = PageNo

            If IsJson Then

                JObject = Newtonsoft.Json.Linq.JObject.Parse(RawResponse)

                Status = JObject.SelectToken("status").ToString
                RequestId = JObject.SelectToken("api_request_id").ToString

                If JObject.SelectToken("next_page_token") IsNot Nothing Then

                    NextPageToken = JObject.SelectToken("next_page_token").ToString

                End If

                If EndpointVersion = "v1" OrElse EndpointVersion = "v2" Then

                    Dim warnings As String() = If(JObject.SelectToken("warnings") IsNot Nothing, JObject.SelectToken("warnings").ToObject(Of String())(), New String(-1) {})
                    Me.Warnings = Me.Warnings.Select(Function(w) New AdvantageFramework.Services.ComScore.Classes.Warning(Code:=0, Message:=w.Message)).ToArray

                Else

                    Warnings = If(JObject.SelectToken("warnings") IsNot Nothing, JObject.SelectToken("warnings").ToObject(Of Warning())(), New Warning(-1) {})

                End If

                Disclosures = If(JObject.SelectToken("disclosures") IsNot Nothing, JObject.SelectToken("disclosures").ToObject(Of String())(), New String(-1) {})
                ApiTime = If(JObject.SelectToken("api_time") IsNot Nothing, TimeSpan.FromMilliseconds(Convert.ToDouble(JObject.SelectToken("api_time"))), Nothing)
                FinalDate = If(JObject.SelectToken("final_date") IsNot Nothing, DateTime.Parse(JObject.SelectToken("final_date").ToString()), Nothing)

            Else

                Status = "error"

            End If

            StillProcessing = (Status = "processing")

        End Sub

#End Region

    End Class

End Namespace