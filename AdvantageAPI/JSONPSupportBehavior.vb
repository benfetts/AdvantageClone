Friend Class JSONPSupportInspector
    Implements System.ServiceModel.Dispatcher.IDispatchMessageInspector

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
    ' Assume utf-8, note that Data Services supports
    ' charset negotation, so this needs to be more
    ' sophisticated (and per-request) if clients will 
    ' use multiple charsets
    Private Shared ReadOnly encoding As Encoding = Encoding.UTF8

#End Region

#Region " Methods "

#Region "IDispatchMessageInspector Members"

    Public Function AfterReceiveRequest(ByRef request As System.ServiceModel.Channels.Message, ByVal channel As IClientChannel, ByVal instanceContext As InstanceContext) As Object Implements System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest
        If request.Properties.ContainsKey("UriTemplateMatchResults") Then
            Dim httpmsg As System.ServiceModel.Channels.HttpRequestMessageProperty = CType(request.Properties(System.ServiceModel.Channels.HttpRequestMessageProperty.Name), System.ServiceModel.Channels.HttpRequestMessageProperty)
            Dim match As UriTemplateMatch = CType(request.Properties("UriTemplateMatchResults"), UriTemplateMatch)

            Dim format As String = match.QueryParameters("$format")
            If "json".Equals(format, StringComparison.InvariantCultureIgnoreCase) Then
                ' strip out $format from the query options to avoid an error
                ' due to use of a reserved option (starts with "$")
                match.QueryParameters.Remove("$format")

                ' replace the Accept header so that the Data Services runtime 
                ' assumes the client asked for a JSON representation
                httpmsg.Headers("Accept") = "application/json;odata=verbose, text/plain;q=0.5"
                httpmsg.Headers("Accept-Charset") = "utf-8"

                Dim callback As String = match.QueryParameters("$callback")
                If (Not String.IsNullOrEmpty(callback)) Then
                    match.QueryParameters.Remove("$callback")
                    Return callback
                End If
            End If
        End If

        Return Nothing
    End Function
    Public Sub BeforeSendReply(ByRef reply As System.ServiceModel.Channels.Message, ByVal correlationState As Object) Implements System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply
        If correlationState IsNot Nothing AndAlso TypeOf correlationState Is String Then
            ' if we have a JSONP callback then buffer the response, wrap it with the
            ' callback call and then re-create the response message
            Dim callback As String = CStr(correlationState)

            Dim bodyIsText As Boolean = False
            Dim response As System.ServiceModel.Channels.HttpResponseMessageProperty = TryCast(reply.Properties(System.ServiceModel.Channels.HttpResponseMessageProperty.Name), System.ServiceModel.Channels.HttpResponseMessageProperty)
            If response IsNot Nothing Then
                Dim contentType As String = response.Headers("Content-Type")
                If contentType IsNot Nothing Then
                    ' Check the response type and change it to text/javascript if we know how.
                    If contentType.StartsWith("text/plain", StringComparison.InvariantCultureIgnoreCase) Then
                        bodyIsText = True
                        response.Headers("Content-Type") = "text/javascript;charset=utf-8"
                    ElseIf contentType.StartsWith("application/json", StringComparison.InvariantCultureIgnoreCase) Then
                        response.Headers("Content-Type") = contentType.Replace("application/json", "text/javascript")
                    End If
                End If
            End If

            Dim reader As System.Xml.XmlDictionaryReader = reply.GetReaderAtBodyContents()
            reader.ReadStartElement()

            Dim content As String = JSONPSupportInspector.encoding.GetString(reader.ReadContentAsBase64())
            If bodyIsText Then
                ' Escape the body as a string literal.
                content = """" & QuoteJScriptString(content) & """"
            End If

            content = callback & "(" & content & ")"

            Dim newreply As System.ServiceModel.Channels.Message = System.ServiceModel.Channels.Message.CreateMessage(System.ServiceModel.Channels.MessageVersion.None, "", New Writer(content))
            newreply.Properties.CopyProperties(reply.Properties)

            reply = newreply
        End If
    End Sub
    Private Shared Function QuoteJScriptString(ByVal s As String) As String
        If String.IsNullOrEmpty(s) Then
            Return String.Empty
        End If

        Dim builder As StringBuilder = Nothing
        Dim startIndex As Integer = 0
        Dim count As Integer = 0
        For i As Integer = 0 To s.Length - 1
            Dim ch As Char = s.Chars(i)
            If ((((ch = ControlChars.Cr) OrElse (ch = ControlChars.Tab)) OrElse ((ch = """"c) OrElse (ch = "\"c))) OrElse (((ch = ControlChars.Lf) OrElse (ch < " "c)) OrElse ((ch > ChrW(&H7F)) OrElse (ch = ControlChars.Back)))) OrElse (ch = ControlChars.FormFeed) Then
                If builder Is Nothing Then
                    builder = New StringBuilder(s.Length + 6)
                End If

                If count > 0 Then
                    builder.Append(s, startIndex, count)
                End If

                startIndex = i + 1
                count = 0
            End If

            Select Case ch
                Case ControlChars.Back
                    builder.Append("\b")
                Case ControlChars.Tab
                    builder.Append("\t")
                Case ControlChars.Lf
                    builder.Append("\n")
                Case ControlChars.FormFeed
                    builder.Append("\f")
                Case ControlChars.Cr
                    builder.Append("\r")
                Case """"c
                    builder.Append("\""")
                Case "\"c
                    builder.Append("\\")
                Case Else
                    If (ch < " "c) OrElse (ch > ChrW(&H7F)) Then
                        builder.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "\u{0:x4}", System.Convert.ToInt32(ch))
                    Else
                        count += 1
                    End If
            End Select
        Next i

        Dim result As String
        If builder Is Nothing Then
            result = s
        Else
            If count > 0 Then
                builder.Append(s, startIndex, count)
            End If

            result = builder.ToString()
        End If

        Return result
    End Function

#End Region

#End Region

    Private Class Writer
        Inherits System.ServiceModel.Channels.BodyWriter

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private content As String

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal content As String)

            MyBase.New(False)
            Me.content = content

        End Sub
        Protected Overrides Sub OnWriteBodyContents(ByVal writer As System.Xml.XmlDictionaryWriter)

            writer.WriteStartElement("Binary")
            Dim buffer() As Byte = JSONPSupportInspector.encoding.GetBytes(Me.content)
            writer.WriteBase64(buffer, 0, buffer.Length)
            writer.WriteEndElement()

        End Sub

#End Region

    End Class

End Class

