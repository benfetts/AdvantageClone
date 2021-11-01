Namespace AvaTax.API

    <Serializable()>
    Public Class TaxService

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

        Public Sub New(ByVal AccountNumber As String, ByVal LicenseKey As String, ByVal ServiceURL As String)

            _AccountNumber = AccountNumber
            _LicenseKey = LicenseKey

            If ServiceURL IsNot Nothing Then

                _ServiceURL = ServiceURL.TrimEnd("/"c) & "/1.0/"

            End If

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext)

            _AccountNumber = AdvantageFramework.Agency.GetOptionAvaTaxAccountNumber(DbContext)
            _LicenseKey = AdvantageFramework.Agency.GetOptionAvaTaxLicenseKey(DbContext)
            _ServiceURL = AdvantageFramework.Agency.GetOptionAvaTaxURL(DbContext)

            If _ServiceURL IsNot Nothing Then

                _ServiceURL = _ServiceURL.TrimEnd("/"c) & "/1.0/"

            End If

        End Sub
        Public Function Ping() As AdvantageFramework.AvaTax.API.GeoTaxResult

            Try

                Ping = Me.EstimateTax(CDec(47.627935), CDec(-122.51702), CDec(10))

            Catch ex As Exception
                Ping = Nothing
            End Try

        End Function
        Private Function EstimateTax(ByVal Latitude As Decimal, ByVal Longitude As Decimal, ByVal SaleAmount As Decimal) As AdvantageFramework.AvaTax.API.GeoTaxResult

            ' Call the service
            Dim Uri As System.Uri = Nothing
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim GeoTaxResult As AdvantageFramework.AvaTax.API.GeoTaxResult = Nothing
            Dim WebResponse As System.Net.WebResponse = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim ResponseStream As System.IO.Stream = Nothing
            Dim StreamReader As System.IO.StreamReader = Nothing
            Dim ResponseString As String = Nothing
            Dim Message As AdvantageFramework.AvaTax.API.Message = Nothing
            Dim ByteArray() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            GeoTaxResult = New AdvantageFramework.AvaTax.API.GeoTaxResult

            Uri = New System.Uri(_ServiceURL & "tax/" & Latitude.ToString() & "," & Longitude.ToString() & "/get.xml?saleamount=" & SaleAmount)

            HttpWebRequest = TryCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)
            HttpWebRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, "Basic " & Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_AccountNumber & ":" & _LicenseKey)))
            HttpWebRequest.Method = "GET"

            Try

                WebResponse = HttpWebRequest.GetResponse()
                XmlSerializer = New System.Xml.Serialization.XmlSerializer(GeoTaxResult.[GetType]())

                GeoTaxResult = DirectCast(XmlSerializer.Deserialize(WebResponse.GetResponseStream()), AdvantageFramework.AvaTax.API.GeoTaxResult)

            Catch ex As System.Net.WebException

                ResponseStream = DirectCast(ex.Response, System.Net.HttpWebResponse).GetResponseStream()
                StreamReader = New System.IO.StreamReader(ResponseStream)
                ResponseString = StreamReader.ReadToEnd()

                ' The service returns some error messages in JSON for authentication/unhandled errors.
                If ResponseString.StartsWith("{") OrElse ResponseString.StartsWith("[") Then

                    GeoTaxResult = New AdvantageFramework.AvaTax.API.GeoTaxResult
                    GeoTaxResult.ResultCode = AdvantageFramework.AvaTax.API.SeverityLevel.Error

                    Message = New AdvantageFramework.AvaTax.API.Message()

                    Message.Severity = GeoTaxResult.ResultCode
                    Message.Summary = "The request was unable to be successfully serviced, please try again or contact Customer Service."
                    Message.Source = "Avalara.Web.REST"

                    If Not DirectCast(ex.Response, System.Net.HttpWebResponse).StatusCode.Equals(System.Net.HttpStatusCode.InternalServerError) Then
                        Message.Summary = "The user or account could not be authenticated."
                        Message.Source = "Avalara.Web.Authorization"
                    End If

                    GeoTaxResult.Messages = New AdvantageFramework.AvaTax.API.Message(0) {Message}

                Else

                    XmlSerializer = New System.Xml.Serialization.XmlSerializer(GeoTaxResult.[GetType]())
                    ByteArray = System.Text.Encoding.ASCII.GetBytes(ResponseString)
                    MemoryStream = New System.IO.MemoryStream(ByteArray)
                    ' Inelegant, but the deserializer only takes streams, and we already read ours out.
                    GeoTaxResult = DirectCast(XmlSerializer.Deserialize(MemoryStream), AdvantageFramework.AvaTax.API.GeoTaxResult)

                End If

            End Try

            EstimateTax = GeoTaxResult

        End Function
        Public Function GetTax(GetTaxRequest As AdvantageFramework.AvaTax.API.GetTaxRequest) As AdvantageFramework.AvaTax.API.GetTaxResult

            Dim XmlSerializerNamespaces As System.Xml.Serialization.XmlSerializerNamespaces = Nothing
            Dim XmlWriterSettings As System.Xml.XmlWriterSettings = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim XmlDocument As System.Xml.XmlDocument = Nothing
            Dim Uri As System.Uri = Nothing
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim Stream As System.IO.Stream = Nothing
            Dim GetTaxResult As AdvantageFramework.AvaTax.API.GetTaxResult = Nothing
            Dim WebResponse As System.Net.WebResponse = Nothing

            XmlSerializerNamespaces = New System.Xml.Serialization.XmlSerializerNamespaces
            XmlSerializerNamespaces.Add(String.Empty, String.Empty)

            XmlWriterSettings = New System.Xml.XmlWriterSettings()
            XmlWriterSettings.OmitXmlDeclaration = True

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetTaxRequest.[GetType]())

            StringBuilder = New System.Text.StringBuilder()

            XmlSerializer.Serialize(System.Xml.XmlTextWriter.Create(StringBuilder, XmlWriterSettings), GetTaxRequest, XmlSerializerNamespaces)

            XmlDocument = New System.Xml.XmlDocument()
            XmlDocument.LoadXml(StringBuilder.ToString())

            Uri = New Uri(_ServiceURL & "tax/get")

            HttpWebRequest = TryCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)

            HttpWebRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, "Basic " & Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_AccountNumber & ":" & _LicenseKey)))
            HttpWebRequest.Method = "POST"
            HttpWebRequest.ContentType = "text/xml"
            HttpWebRequest.ContentLength = StringBuilder.Length

            Stream = HttpWebRequest.GetRequestStream()
            Stream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(StringBuilder.ToString()), 0, StringBuilder.Length)

            GetTaxResult = New AdvantageFramework.AvaTax.API.GetTaxResult()

            Try

                WebResponse = HttpWebRequest.GetResponse()
                XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetTaxResult.[GetType]())
                GetTaxResult = DirectCast(XmlSerializer.Deserialize(WebResponse.GetResponseStream()), AdvantageFramework.AvaTax.API.GetTaxResult)

            Catch ex As System.Net.WebException
                XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetTaxResult.[GetType]())
                GetTaxResult = DirectCast(XmlSerializer.Deserialize(DirectCast(ex.Response, System.Net.HttpWebResponse).GetResponseStream()), AdvantageFramework.AvaTax.API.GetTaxResult)
            End Try

            GetTax = GetTaxResult

        End Function
        Public Function CancelTax(CancelTaxRequest As AdvantageFramework.AvaTax.API.CancelTaxRequest) As AdvantageFramework.AvaTax.API.CancelTaxResult

            Dim XmlSerializerNamespaces As System.Xml.Serialization.XmlSerializerNamespaces = Nothing
            Dim XmlWriterSettings As System.Xml.XmlWriterSettings = Nothing
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim XmlDocument As System.Xml.XmlDocument = Nothing
            Dim Uri As System.Uri = Nothing
            Dim HttpWebRequest As System.Net.HttpWebRequest = Nothing
            Dim Stream As System.IO.Stream = Nothing
            Dim CancelTaxResponse As AdvantageFramework.AvaTax.API.CancelTaxResponse = Nothing
            Dim WebResponse As System.Net.WebResponse = Nothing

            XmlSerializerNamespaces = New System.Xml.Serialization.XmlSerializerNamespaces()
            XmlSerializerNamespaces.Add(String.Empty, String.Empty)

            XmlWriterSettings = New System.Xml.XmlWriterSettings
            XmlWriterSettings.OmitXmlDeclaration = True

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(CancelTaxRequest.[GetType]())

            StringBuilder = New System.Text.StringBuilder()

            XmlSerializer.Serialize(System.Xml.XmlTextWriter.Create(StringBuilder, XmlWriterSettings), CancelTaxRequest, XmlSerializerNamespaces)

            XmlDocument = New System.Xml.XmlDocument()
            XmlDocument.LoadXml(StringBuilder.ToString())

            Uri = New System.Uri(_ServiceURL & "tax/cancel")

            HttpWebRequest = TryCast(System.Net.WebRequest.Create(Uri), System.Net.HttpWebRequest)

            HttpWebRequest.Headers.Add(System.Net.HttpRequestHeader.Authorization, "Basic " & Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(_AccountNumber & ":" & _LicenseKey)))
            HttpWebRequest.Method = "POST"
            HttpWebRequest.ContentType = "text/xml"
            HttpWebRequest.ContentLength = StringBuilder.Length

            Stream = HttpWebRequest.GetRequestStream()

            Stream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(StringBuilder.ToString()), 0, StringBuilder.Length)

            CancelTaxResponse = New AdvantageFramework.AvaTax.API.CancelTaxResponse()

            Try

                WebResponse = HttpWebRequest.GetResponse()

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(CancelTaxResponse.[GetType]())

                CancelTaxResponse = DirectCast(XmlSerializer.Deserialize(WebResponse.GetResponseStream()), AdvantageFramework.AvaTax.API.CancelTaxResponse)

            Catch ex As System.Net.WebException

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(CancelTaxResponse.[GetType]())

                CancelTaxResponse = DirectCast(XmlSerializer.Deserialize(DirectCast(ex.Response, System.Net.HttpWebResponse).GetResponseStream()), AdvantageFramework.AvaTax.API.CancelTaxResponse)

                ' If the error is returned at the cancelResponse level, translate it to the cancelResult.
                If CancelTaxResponse.ResultCode.Equals(SeverityLevel.[Error]) Then

                    CancelTaxResponse.CancelTaxResult = New AdvantageFramework.AvaTax.API.CancelTaxResult()
                    CancelTaxResponse.CancelTaxResult.ResultCode = CancelTaxResponse.ResultCode
                    CancelTaxResponse.CancelTaxResult.Messages = CancelTaxResponse.Messages

                End If

            End Try

            CancelTax = CancelTaxResponse.CancelTaxResult

        End Function

#End Region

    End Class

End Namespace