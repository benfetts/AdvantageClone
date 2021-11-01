<HideModuleName()>
Public Module Methods

#Region " Constants "

    Private Const RequestLog As String = "API-Requests"
    Private Const ResponseLog As String = "API-Responses"
    Private Const Response500Log As String = "API-500Responses"
    Private Const Response400Log As String = "API-400Responses"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub ProcessRequest()

        Dim Message As String = String.Empty

        Try

            Message = "Request: " & System.Environment.NewLine & HttpContext.Current.Request.RawUrl
            Message &= System.Environment.NewLine & System.Environment.NewLine & "HttpMethod: " & System.Environment.NewLine & HttpContext.Current.Request.HttpMethod
            Message &= System.Environment.NewLine & System.Environment.NewLine & "ServerProtocol: " & System.Environment.NewLine & HttpContext.Current.Request.ServerVariables("SERVER_PROTOCOL")
            Message &= System.Environment.NewLine & System.Environment.NewLine & "Headers: "

            For Each Header In HttpContext.Current.Request.Headers.AllKeys

                Message &= System.Environment.NewLine & Header & ": " & "  " & HttpContext.Current.Request.Headers.Get(Header)

            Next

            AddEventLog(RequestLog, "API-Request", Message)

        Catch ex As Exception
            ProcessException(ex, "APIService-ApplicationError")
        End Try

    End Sub
    Public Sub ProcessResponse()

        Dim Message As String = String.Empty
        Dim OutputFilterStream As OutputFilterStream = Nothing

        Try

            Message = "Response: " & System.Environment.NewLine
            Message &= System.Environment.NewLine & System.Environment.NewLine & "Status: " & System.Environment.NewLine & HttpContext.Current.Response.Status
            Message &= System.Environment.NewLine & System.Environment.NewLine & "StatusCode: " & System.Environment.NewLine & HttpContext.Current.Response.StatusCode
            Message &= System.Environment.NewLine & System.Environment.NewLine & "StatusDescription: " & System.Environment.NewLine & HttpContext.Current.Response.StatusDescription
            Message &= System.Environment.NewLine & System.Environment.NewLine & "SubStatusCode: " & System.Environment.NewLine & HttpContext.Current.Response.SubStatusCode
            Message &= System.Environment.NewLine & System.Environment.NewLine & "Headers: "

            For Each Header In HttpContext.Current.Response.Headers.AllKeys

                Message &= System.Environment.NewLine & Header & ": " & "  " & HttpContext.Current.Response.Headers.Get(Header)

            Next

            If HttpContext.Current.Items("OutputFilterStream") IsNot Nothing Then

                OutputFilterStream = HttpContext.Current.Items("OutputFilterStream")

                Message &= System.Environment.NewLine & System.Environment.NewLine & "Output: " & System.Environment.NewLine & OutputFilterStream.ReadStream

            End If

            If HttpContext.Current.Response.StatusCode >= 400 AndAlso HttpContext.Current.Response.StatusCode <= 499 Then

                AddEventLog(Response400Log, "API-400Response", Message)

            ElseIf HttpContext.Current.Response.StatusCode >= 500 AndAlso HttpContext.Current.Response.StatusCode <= 599 Then

                AddEventLog(Response500Log, "API-500Response", Message)

            Else

                AddEventLog(ResponseLog, "API-Response", Message)

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-ApplicationError")
        End Try

    End Sub
    Public Sub ProcessException(Exception As Exception, EventSource As String)

        Dim ExceptionError As Exception = Nothing
        Dim ExceptionMessage As String = String.Empty

        If Exception IsNot Nothing Then

            ExceptionError = Exception

            Do Until ExceptionError Is Nothing

                If String.IsNullOrWhiteSpace(ExceptionMessage) Then

                    ExceptionMessage = GetExceptionMessage(ExceptionError)

                Else

                    ExceptionMessage &= System.Environment.NewLine & System.Environment.NewLine & GetExceptionMessage(ExceptionError)

                End If

                ExceptionError = ExceptionError.InnerException

            Loop

            If HttpContext.Current.Request IsNot Nothing Then

                ExceptionMessage &= System.Environment.NewLine & System.Environment.NewLine & "Request: " & System.Environment.NewLine & HttpContext.Current.Request.RawUrl
                ExceptionMessage &= System.Environment.NewLine & System.Environment.NewLine & "UserHostAddress: " & System.Environment.NewLine & HttpContext.Current.Request.UserHostAddress
                ExceptionMessage &= System.Environment.NewLine & System.Environment.NewLine & "UserHostName: " & System.Environment.NewLine & HttpContext.Current.Request.UserHostName

            End If

            'If HttpContext.Current.Response IsNot Nothing Then

            '    ExceptionMessage &= System.Environment.NewLine & System.Environment.NewLine & "Response  -->  " & HttpContext.Current.Response.RedirectLocation

            'End If

            AddEventLog(ExceptionMessage, EventSource)

        End If

    End Sub
    Private Function GetExceptionMessage(Exception As Exception) As String

        Dim ExceptionMessage As String = String.Empty

        Try

            ExceptionMessage &= "Message:" & System.Environment.NewLine & Exception.Message & System.Environment.NewLine & System.Environment.NewLine
            ExceptionMessage &= "Source:" & System.Environment.NewLine & Exception.Source & System.Environment.NewLine & System.Environment.NewLine
            ExceptionMessage &= "Target Site:" & System.Environment.NewLine & If(Exception.TargetSite IsNot Nothing, Exception.TargetSite.ToString(), String.Empty) & System.Environment.NewLine & System.Environment.NewLine
            ExceptionMessage &= "Stack Trace:" & System.Environment.NewLine & Exception.StackTrace & System.Environment.NewLine & System.Environment.NewLine
            ExceptionMessage &= "ToString():" & System.Environment.NewLine & Exception.ToString()

        Catch ex As Exception

        End Try

        GetExceptionMessage = ExceptionMessage

    End Function
    Private Sub AddEventLog(ExceptionMessage As String, EventSource As String)

        'objects
        Dim EventLogName As String = "AdvantageAPI"
        Dim EventLog As EventLog = Nothing

        'If WriteToWebvantageEventLog Then

        Try

            ' Create an EventLog instance and assign its source.
            EventLog = New EventLog(EventLogName)

            EventLog.Source = EventSource
            ' Write the error entry to the event log.    
            EventLog.WriteEntry(ExceptionMessage, EventLogEntryType.Error)

        Catch ex As Exception

        End Try

        'End If

    End Sub
    Private Sub AddEventLog(EventLogName As String, EventSource As String, Message As String)

        'objects
        Dim EventLog As EventLog = Nothing

        'If WriteToWebvantageEventLog Then

        Try

            ' Create an EventLog instance and assign its source.
            EventLog = New EventLog(EventLogName)

            EventLog.Source = EventSource
            ' Write the error entry to the event log.    
            EventLog.WriteEntry(Message, EventLogEntryType.Information)

        Catch ex As Exception

        End Try

        'End If

    End Sub
    Public Function CreateEntityConnectionString(ByVal ConnectionString As String, ByVal Metadata As String) As String

		'objects
		Dim EntityConnectionStringBuilder As System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder = Nothing
		Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

		SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString)
		SqlConnectionStringBuilder.MultipleActiveResultSets = True

		EntityConnectionStringBuilder = New System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder

		EntityConnectionStringBuilder.Provider = "System.Data.SqlClient"
		EntityConnectionStringBuilder.ProviderConnectionString = SqlConnectionStringBuilder.ToString
		EntityConnectionStringBuilder.Metadata = Metadata

		CreateEntityConnectionString = EntityConnectionStringBuilder.ToString

	End Function

#End Region

End Module
