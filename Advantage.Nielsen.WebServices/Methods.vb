<HideModuleName()>
Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

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
        Dim EventLogName As String = "APINielsen"
        Dim EventLog As EventLog = Nothing

        Try

            ' Create an EventLog instance and assign its source.
            EventLog = New EventLog(EventLogName)

            EventLog.Source = EventSource
            ' Write the error entry to the event log.    
            EventLog.WriteEntry(ExceptionMessage, EventLogEntryType.Error)

        Catch ex As Exception

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

#End Region

End Module
