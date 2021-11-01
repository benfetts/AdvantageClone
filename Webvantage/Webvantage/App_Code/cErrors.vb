Imports System.IO

<Serializable()> Public Class cErrors

    Private Property SbErrorMessage As System.Text.StringBuilder = New System.Text.StringBuilder

    Public Sub SendToEventLog(Optional ByVal ClearLastError As Boolean = True)
        Dim myError As Exception = Nothing

        If HttpContext.Current.Server.GetLastError() IsNot Nothing Then

            Dim eventLog As String = "Webvantage"
            Dim eventSource As String = "Application_Error Event"

            Dim SbContactInfo As New System.Text.StringBuilder

            myError = HttpContext.Current.Server.GetLastError()

            If myError IsNot Nothing Then

                Try

                    WriteMessage(myError)

                Catch ex As Exception

                End Try

                If SbErrorMessage.Length > 0 Then

                    Dim MessageToWrite As String = ""

                    With SbContactInfo

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

                    MessageToWrite = SbErrorMessage.ToString() & SbContactInfo.ToString()

                    ' Log error to the Event Log
                    Try

                        AdvantageFramework.Security.AddWebvantageEventLog(MessageToWrite, Diagnostics.EventLogEntryType.Error)

                    Catch ex As Exception
                    End Try

                End If

            End If

        End If

        'clear
        'If ClearLastError = True Then

        '    HttpContext.Current.Server.ClearError()

        'End If

        myError = Nothing

    End Sub


    Public Sub SendToEventLog(ExceptionToSend As Exception, Optional ByVal ClearLastError As Boolean = True)
        Dim myError As Exception = Nothing

        If ExceptionToSend IsNot Nothing Then

            Dim SbContactInfo As New System.Text.StringBuilder

            myError = ExceptionToSend

            If myError IsNot Nothing Then

                Try

                    WriteMessage(myError)

                Catch ex As Exception

                End Try

                If SbErrorMessage.Length > 0 Then

                    Dim MessageToWrite As String = ""

                    With SbContactInfo

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

                    MessageToWrite = SbErrorMessage.ToString() & SbContactInfo.ToString()

                    ' Log error to the Event Log
                    Try

                        AdvantageFramework.Security.AddWebvantageEventLog(MessageToWrite, Diagnostics.EventLogEntryType.Error)

                    Catch ex As Exception
                    End Try

                End If

            End If

        End If

        'clear
        If ClearLastError = True Then

            HttpContext.Current.Server.ClearError()

        End If

        myError = Nothing

    End Sub

    Private Sub WriteMessage(ByRef ex As Exception)

        Try

            If Not ex Is Nothing Then

                With SbErrorMessage

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

                        If ex.InnerException IsNot Nothing Then

                            .Append(ex.InnerException.Message.ToString())

                        End If

                    Catch ex3 As Exception

                    End Try
                    .Append(Environment.NewLine)
                    .Append(Environment.NewLine)

                End With

            End If

        Catch ex1 As Exception

        End Try

        If Not ex.InnerException Is Nothing Then

            WriteMessage(ex.InnerException)

        End If

    End Sub

    Public Sub New()

    End Sub

End Class

<Serializable()>
Public Class AsyncErrorMessage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property _Key As String = ""
    Private Property _Filename As String = ""
    Private Property _PhysicalApplicationPath As String = ""
    Private Property _FullFilePath As String = ""

    Public Property SessionID As String
        Get
            Return _Key
        End Get
        Set(value As String)

            Me._Key = MiscFN.JavascriptSafe(value).ToUpper() & "_ASYNC_MESSAGE__" &
                Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & Now.Hour.ToString & Now.Minute.ToString & Now.Second.ToString

            'Me._Filename = Me._Key & ".txt"

        End Set
    End Property
    Public Property PhysicalApplicationPath As String
        Get
            Return Me._FullFilePath
        End Get
        Set(value As String)
            'Me._PhysicalApplicationPath = value
            'Me._FullFilePath = _PhysicalApplicationPath & "TEMP\" & Me._Filename
        End Set
    End Property

#End Region

#Region " Methods "

    Public Function HasError() As Boolean

        'Return File.Exists(Me._FullFilePath)
        Return False

    End Function
    Public Function GetMessage() As String

        Dim Message As String = ""
        'Try

        '    If File.Exists(Me._FullFilePath) Then

        '        Message = File.ReadAllText(Me._FullFilePath)

        '    End If

        'Catch ex As Exception
        '    Message = ""
        'Finally
        '    Me.Delete()
        'End Try

        Return Message

    End Function
    Public Sub Create(ByVal Message As String)

        'If Me.Delete() = True Then

        '    Try

        '        File.WriteAllText(Me._FullFilePath, Message)

        '    Catch ex As Exception
        '    End Try

        'End If
        Try

            AdvantageFramework.Security.AddWebvantageEventLog(_Key & " | " & Message, Diagnostics.EventLogEntryType.Error)

        Catch ex As Exception
        End Try

    End Sub

    Private Function Delete() As Boolean

        Dim Deleted As Boolean = False

        'Try

        '    If File.Exists(Me._FullFilePath) Then

        '        File.Delete(Me._FullFilePath)
        '        Deleted = True

        '    Else

        '        Deleted = True

        '    End If

        'Catch ex As Exception
        '    Deleted = False
        'End Try

        Return Deleted

    End Function

    Sub New()

    End Sub

#End Region

End Class
