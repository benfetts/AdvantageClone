Namespace AvaTax.API

    Public Class AddressService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AccountNumber As String = Nothing
        Private _LicenseKey As String = Nothing
        Private _ServiceURL As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _AccountNumber = AdvantageFramework.Agency.GetOptionAvaTaxAccountNumber(DbContext)
                _LicenseKey = AdvantageFramework.Agency.GetOptionAvaTaxLicenseKey(DbContext)
                _ServiceURL = AdvantageFramework.Agency.GetOptionAvaTaxURL(DbContext)

                If _ServiceURL IsNot Nothing Then

                    _ServiceURL = _ServiceURL.TrimEnd("/"c) & "/1.0/"

                End If

            End Using

        End Sub
        Public Function Validate(Address As AdvantageFramework.AvaTax.API.Address) As AdvantageFramework.AvaTax.API.ValidateResult

            Dim QueryString As String = String.Empty
            Dim Uri As System.Uri = Nothing
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim ValidateResult As AdvantageFramework.AvaTax.API.ValidateResult = Nothing
            Dim WebResponse As System.Net.WebResponse = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim ResponseStream As System.IO.Stream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim ResponseString As String = Nothing
            Dim Message As AdvantageFramework.AvaTax.API.Message = Nothing
            Dim ByteArray() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            QueryString += If((Address.Line1 Is Nothing), String.Empty, "Line1=" & Address.Line1.Replace(" ", "+"))
            QueryString += If((Address.Line2 Is Nothing), String.Empty, "&Line2=" & Address.Line2.Replace(" ", "+"))
            QueryString += If((Address.Line3 Is Nothing), String.Empty, "&Line3=" & Address.Line3.Replace(" ", "+"))
            QueryString += If((Address.City Is Nothing), String.Empty, "&City=" & Address.City.Replace(" ", "+"))
            QueryString += If((Address.Region Is Nothing), String.Empty, "&Region=" & Address.Region.Replace(" ", "+"))
            QueryString += If((Address.PostalCode Is Nothing), String.Empty, "&PostalCode=" & Address.PostalCode.Replace(" ", "+"))
            QueryString += If((Address.Country Is Nothing), String.Empty, "&Country=" & Address.Country.Replace(" ", "+"))

            Uri = New System.Uri(_ServiceURL & "address/validate.xml?" & QueryString)
            HttpWebRequest = TryCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)

            HttpWebRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, "Basic " & Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_AccountNumber & ":" & _LicenseKey)))
            HttpWebRequest.Method = "GET"

            ValidateResult = New AdvantageFramework.AvaTax.API.ValidateResult()

            Try

                WebResponse = HttpWebRequest.GetResponse()
                XmlSerializer = New System.Xml.Serialization.XmlSerializer(ValidateResult.GetType())

                ValidateResult = DirectCast(XmlSerializer.Deserialize(WebResponse.GetResponseStream()), ValidateResult)

                Address = ValidateResult.Address

            Catch ex As System.Net.WebException

                ResponseStream = DirectCast(ex.Response, System.Net.HttpWebResponse).GetResponseStream()
                StreamReader = New System.IO.StreamReader(ResponseStream)
                ResponseString = StreamReader.ReadToEnd()

                ' The service returns some error messages in JSON for authentication/unhandled errors.
                If ResponseString.StartsWith("{") OrElse ResponseString.StartsWith("[") Then

                    ValidateResult = New AdvantageFramework.AvaTax.API.ValidateResult()
                    ValidateResult.ResultCode = AdvantageFramework.AvaTax.API.SeverityLevel.Error

                    Message = New AdvantageFramework.AvaTax.API.Message()

                    Message.Severity = ValidateResult.ResultCode
                    Message.Summary = "The request was unable to be successfully serviced, please try again or contact Customer Service."
                    Message.Source = "Avalara.Web.REST"

                    If Not DirectCast(ex.Response, System.Net.HttpWebResponse).StatusCode.Equals(System.Net.HttpStatusCode.InternalServerError) Then

                        Message.Summary = "The user or account could not be authenticated."
                        Message.Source = "Avalara.Web.Authorization"

                    End If

                    ValidateResult.Messages = New AdvantageFramework.AvaTax.API.Message(0) {Message}

                Else

                    XmlSerializer = New System.Xml.Serialization.XmlSerializer(ValidateResult.GetType())
                    ByteArray = System.Text.Encoding.ASCII.GetBytes(ResponseString)
                    MemoryStream = New System.IO.MemoryStream(ByteArray)

                    ' Inelegant, but the deserializer only takes streams, and we already read ours out.
                    ValidateResult = DirectCast(XmlSerializer.Deserialize(MemoryStream), ValidateResult)

                End If

            End Try

            Validate = ValidateResult

        End Function

#End Region

    End Class

End Namespace