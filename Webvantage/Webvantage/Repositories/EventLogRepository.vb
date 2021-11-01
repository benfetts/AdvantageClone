Namespace Repositories
    Public Class EventLogRepository
        Public Sub SendToEventLog(ExceptionToSend As Exception, Optional ByVal ClearLastError As Boolean = True)
            Dim StringBuilder_ErrorMessage As System.Text.StringBuilder = Nothing

            If ExceptionToSend IsNot Nothing Then
                StringBuilder_ErrorMessage = New System.Text.StringBuilder
                If ExceptionToSend IsNot Nothing Then

                    Try

                        FormatErrorMessage(StringBuilder_ErrorMessage, ExceptionToSend)

                    Catch ex As Exception

                    End Try

                    If StringBuilder_ErrorMessage.Length > 0 Then
                        With StringBuilder_ErrorMessage

                            .Append(Environment.NewLine)
                            .Append(Environment.NewLine)
                            .Append("Contact Advantage Software")
                            .Append(Environment.NewLine)
                            .Append("==================================================")
                            .Append(Environment.NewLine)
                            .Append("Toll Free:   800.841.2078")
                            .Append(Environment.NewLine)
                            .Append("Local:   704.662.9980")
                            .Append(Environment.NewLine)
                            .Append("Email:   support@gotoadvantage.com")
                            .Append(Environment.NewLine)
                            .Append(Environment.NewLine)
                            .Append(Environment.NewLine)
                            .Append(Environment.NewLine)

                        End With

                        ' Log error to the Event Log
                        Try

                            AdvantageFramework.Security.AddWebvantageEventLog(StringBuilder_ErrorMessage.ToString(), Diagnostics.EventLogEntryType.Error)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

            'clear
            If ClearLastError = True Then

                HttpContext.Current.Server.ClearError()

            End If

            ExceptionToSend = Nothing
        End Sub

        Public Function FormatErrorMessage(ByRef StringBuilder_FormatMessage As System.Text.StringBuilder, ByRef ex As Exception) As String
            Try

                If Not ex Is Nothing Then

                    With StringBuilder_FormatMessage

                        .Append("Exception")
                        .Append(Environment.NewLine)
                        .Append("==================================================")
                        .Append(Environment.NewLine)
                        .Append(ex.Message.ToString())
                        .Append(Environment.NewLine)
                        .Append(Environment.NewLine)
                        .Append("Source")
                        .Append(Environment.NewLine)
                        .Append("==================================================")
                        .Append(Environment.NewLine)
                        .Append(ex.Source)
                        .Append(Environment.NewLine)
                        .Append(Environment.NewLine)
                        .Append("Target Site")
                        .Append(Environment.NewLine)
                        .Append("==================================================")
                        .Append(Environment.NewLine)
                        .Append(ex.TargetSite.ToString())
                        .Append(Environment.NewLine)
                        .Append(Environment.NewLine)
                        .Append("Stack Trace")
                        .Append(Environment.NewLine)
                        .Append("==================================================")
                        .Append(Environment.NewLine)
                        .Append(ex.StackTrace)
                        .Append(Environment.NewLine)
                        .Append(Environment.NewLine)
                        .Append("Error Message")
                        .Append(Environment.NewLine)
                        .Append("==================================================")
                        .Append(Environment.NewLine)
                        .Append(ex.ToString().Replace("--->", Environment.NewLine & "  --->"))
                        Try
                            .Append("Inner Message")
                            .Append(Environment.NewLine)
                            .Append("==================================================")
                            .Append(Environment.NewLine)
                            .Append(ex.InnerException.Message.ToString())
                        Catch ex3 As Exception

                        End Try
                        .Append(Environment.NewLine)
                        .Append(Environment.NewLine)

                    End With

                End If

            Catch ex1 As Exception

            End Try

            If Not ex.InnerException Is Nothing Then

                FormatErrorMessage(StringBuilder_FormatMessage, ex.InnerException)

            End If

        End Function
    End Class
End Namespace

