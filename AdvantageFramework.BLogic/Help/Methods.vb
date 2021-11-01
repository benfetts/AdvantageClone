Namespace Help

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum IssueTypes
            Bug = 1
            Problem = 2
            Enhancement = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CreateAndSendSupportMessage(ByVal Session As AdvantageFramework.Security.Session, ByVal ContactSupportMessage As AdvantageFramework.Help.Classes.ContactSupportMessage,
                                                    ByVal ScreenShotImages As Generic.List(Of System.Drawing.Image), ByRef ErrorMessage As String) As Boolean

            'objects
            Dim CreatedAndSentSupportMessage As Boolean = False
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim TechincalSupportSendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim SoftwareSupportSendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim TechincalSupportEmailSent As Boolean = False
            Dim SoftwareSupportEmailSent As Boolean = False
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim ImageConverter As System.Drawing.ImageConverter = Nothing

            Try

                If ContactSupportMessage IsNot Nothing Then

                    If ContactSupportMessage.ContactTechincalSupport OrElse ContactSupportMessage.ContactSoftwareSupport Then

                        StringBuilder = New System.Text.StringBuilder

                        StringBuilder.AppendLine("<table width=""98%"" style=""vertical-align:top"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Client: " & ContactSupportMessage.Name & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Phone Number: " & ContactSupportMessage.PhoneNumber & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Employee Name: " & ContactSupportMessage.EmployeeName & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Email Address: " & ContactSupportMessage.EmailAddress & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Address 1: " & ContactSupportMessage.Address & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Address 2: " & ContactSupportMessage.Address2 & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">City: " & ContactSupportMessage.City & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">State: " & ContactSupportMessage.State & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Zip: " & ContactSupportMessage.Zip & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Issue Type: " & ContactSupportMessage.IssueType.ToString & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Priority: " & ContactSupportMessage.Priorty.ToString & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Description of Issue: " & ContactSupportMessage.Description & "</font></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")
                        StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")

                        If ContactSupportMessage.ContactTechincalSupport AndAlso ContactSupportMessage.ContactSoftwareSupport Then

                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Sent To: This message has been sent to Software Support and Technical Support" & "</font></td></tr>")

                        ElseIf ContactSupportMessage.ContactTechincalSupport = False AndAlso ContactSupportMessage.ContactSoftwareSupport Then

                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Sent To: This message has been sent to Software Support" & "</font></td></tr>")

                        ElseIf ContactSupportMessage.ContactTechincalSupport AndAlso ContactSupportMessage.ContactSoftwareSupport = False Then

                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">Sent To: This message has been sent to Technical Support" & "</font></td></tr>")

                        End If

                        If String.IsNullOrEmpty(ContactSupportMessage.SupportInformation) = False Then

                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri""></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">--- Support Information ---" & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""3"" face=""Calibri"">" & ContactSupportMessage.SupportInformation & "</font></td></tr>")

                        End If

                        StringBuilder.AppendLine("</table>")

                        If ScreenShotImages IsNot Nothing AndAlso ScreenShotImages.Any Then

                            Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)
                            ImageConverter = New System.Drawing.ImageConverter

                            For Each ScreenShotImage In ScreenShotImages

                                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment("ScreenShot" & ScreenShotImages.IndexOf(ScreenShotImage) & ".bmp", CType(ImageConverter.ConvertTo(ScreenShotImage, GetType(Byte())), Byte())))

                            Next

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                If ContactSupportMessage.ContactTechincalSupport Then

                                    TechincalSupportEmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, "techsupport@gotoadvantage.com", "Contact Customer Support - The Advantage Software Company", StringBuilder.ToString, CInt(ContactSupportMessage.Priorty), Attachments, True, TechincalSupportSendingEmailStatus)

                                End If

                                If ContactSupportMessage.ContactSoftwareSupport Then

                                    SoftwareSupportEmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, "softwaresupport@gotoadvantage.com", "Contact Customer Support - The Advantage Software Company", StringBuilder.ToString, CInt(ContactSupportMessage.Priorty), Attachments, True, SoftwareSupportSendingEmailStatus)

                                End If

                            End Using

                        End Using

                        If ContactSupportMessage.ContactTechincalSupport AndAlso ContactSupportMessage.ContactSoftwareSupport Then

                            If TechincalSupportEmailSent AndAlso SoftwareSupportEmailSent Then

                                CreatedAndSentSupportMessage = True

                            Else

                                If TechincalSupportEmailSent = False Then

                                    ErrorMessage = "Technical Support Email Failed reason: " & TechincalSupportSendingEmailStatus.ToString

                                End If

                                If SoftwareSupportEmailSent = False Then

                                    If ErrorMessage = "" Then

                                        ErrorMessage = "Software Support Email Failed reason: " & SoftwareSupportSendingEmailStatus.ToString

                                    Else

                                        ErrorMessage &= vbNewLine & vbNewLine & "Software Support Email Failed reason: " & SoftwareSupportSendingEmailStatus.ToString

                                    End If

                                End If

                            End If

                        ElseIf ContactSupportMessage.ContactTechincalSupport = False AndAlso ContactSupportMessage.ContactSoftwareSupport Then

                            If SoftwareSupportEmailSent Then

                                CreatedAndSentSupportMessage = True

                            Else

                                ErrorMessage = "Software Support Email Failed reason: " & SoftwareSupportSendingEmailStatus.ToString

                            End If

                        ElseIf ContactSupportMessage.ContactTechincalSupport AndAlso ContactSupportMessage.ContactSoftwareSupport = False Then

                            If TechincalSupportEmailSent Then

                                CreatedAndSentSupportMessage = True

                            Else

                                ErrorMessage = "Technical Support Email Failed reason: " & TechincalSupportSendingEmailStatus.ToString

                            End If

                        End If

                    Else

                        ErrorMessage = "No support department selected."

                    End If

                Else

                    ErrorMessage = "Invalid message data."

                End If

            Catch ex As Exception
                CreatedAndSentSupportMessage = False
                ErrorMessage = ex.Message
            End Try

            CreateAndSendSupportMessage = CreatedAndSentSupportMessage

        End Function

#End Region

    End Module

End Namespace
