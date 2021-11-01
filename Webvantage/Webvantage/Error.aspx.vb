Public Class ErrorPage
    Inherits Page

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Page "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If Session(MiscFN.ShowErrorSessionKey) Is Nothing OrElse CType(Session(MiscFN.ShowErrorSessionKey), Boolean) = True Then

                Dim AspNetException As Exception = HttpContext.Current.Server.GetLastError()

                If AspNetException IsNot Nothing Then

                    Me.LabelMessage.Text = AspNetException.Message

                    Dim Errors As New System.Text.StringBuilder
                    Dim RawURL As String = String.Empty
                    Dim OriginalString As String = String.Empty
                    Dim URL As String = String.Empty
                    Dim AbsoluteUri As String = String.Empty
                    Dim PhysicalPath As String = String.Empty

                    Try

                        Errors.Append("Triggered from Error.aspx.vb")
                        Errors.Append(Environment.NewLine)

                    Catch ex As Exception
                    End Try
                    'Try

                    '    RawURL = Request.RawUrl

                    'Catch ex As Exception
                    '    RawURL = String.Empty
                    'End Try
                    'Try

                    '    OriginalString = Request.Url.OriginalString

                    'Catch ex As Exception
                    '    OriginalString = String.Empty
                    'End Try
                    'Try

                    '    URL = Request.Url.ToString

                    'Catch ex As Exception
                    '    URL = String.Empty
                    'End Try
                    Try

                        AbsoluteUri = Request.Url.AbsoluteUri

                    Catch ex As Exception
                        AbsoluteUri = String.Empty
                    End Try
                    Try

                        PhysicalPath = Request.PhysicalPath

                    Catch ex As Exception
                        PhysicalPath = String.Empty
                    End Try
                    Try

                        'If String.IsNullOrWhiteSpace(RawURL) = False Then

                        '    Errors.Append("RawURL:  ")
                        '    Errors.Append(RawURL)
                        '    Errors.Append(Environment.NewLine)

                        'End If
                        'If String.IsNullOrWhiteSpace(OriginalString) = False Then

                        '    Errors.Append("OriginalString:  ")
                        '    Errors.Append(OriginalString)
                        '    Errors.Append(Environment.NewLine)

                        'End If
                        'If String.IsNullOrWhiteSpace(URL) = False Then

                        '    Errors.Append("URL:  ")
                        '    Errors.Append(URL)
                        '    Errors.Append(Environment.NewLine)

                        'End If
                        If String.IsNullOrWhiteSpace(AbsoluteUri) = False Then

                            Errors.Append("AbsoluteUri:  ")
                            Errors.Append(AbsoluteUri)
                            Errors.Append(Environment.NewLine)

                        End If
                        If String.IsNullOrWhiteSpace(PhysicalPath) = False Then

                            Errors.Append("PhysicalPath:  ")
                            Errors.Append(PhysicalPath)
                            Errors.Append(Environment.NewLine)

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        Errors.Append(Environment.NewLine)
                        Errors.Append(Environment.NewLine)
                        Errors.Append(AdvantageFramework.StringUtilities.FullErrorToString(AspNetException))

                    Catch ex As Exception
                    End Try
                    If Errors IsNot Nothing AndAlso Errors.Length > 0 Then

                        Errors.Append(Environment.NewLine)
                        Errors.Append(Environment.NewLine)
                        Errors.Append("Contact Advantage Software".ToUpper())
                        Errors.Append(Environment.NewLine)
                        Errors.Append("Toll Free:   800.841.2078")
                        Errors.Append(Environment.NewLine)
                        Errors.Append("Local:   704.662.9980")
                        Errors.Append(Environment.NewLine)
                        Errors.Append("Email:   support@gotoadvantage.com")
                        Errors.Append(Environment.NewLine)
                        Errors.Append(Environment.NewLine)

                    End If
                    Try

                        If Errors IsNot Nothing AndAlso Errors.Length > 0 Then

                            Dim Message As String = Errors.ToString

                            If AdvantageFramework.StringUtilities.IgnoreError(Message) = False Then

                                AdvantageFramework.Security.AddWebvantageEventLog(Message, Diagnostics.EventLogEntryType.Error)

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                Else

                    Me.LabelMessage.Text = "Please contact Advantage support."

                End If

            Else

                Me.LabelMessage.Text = "Please contact Advantage support."

            End If

        Catch exxxx As Exception
        End Try

    End Sub

#End Region

#End Region

End Class
