Namespace Email

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

        Public Sub CreateEmailAndOpenEmailClient(Folder As String, FileName As String, Subject As String, BodyText As String, BodyHtml As String, Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment))

            'objects
            Dim MailMessage As Rebex.Mail.MailMessage = Nothing

            If My.Computer.FileSystem.DirectoryExists(Folder) AndAlso String.IsNullOrWhiteSpace(FileName) = False Then

                MailMessage = New Rebex.Mail.MailMessage

                MailMessage.Subject = Subject
                MailMessage.BodyText = BodyText
                MailMessage.BodyHtml = BodyHtml

                If Attachments IsNot Nothing AndAlso Attachments.Count > 0 Then

                    For Each Attachment In Attachments

                        MailMessage.Attachments.Add(New Rebex.Mail.Attachment(Attachment.FileBytes, Attachment.AttachmentName))

                    Next

                End If

                MailMessage.Headers.Add("X-Unsent", "1")
                MailMessage.Save(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & FileName & ".eml", Rebex.Mail.MailFormat.Mime)

                System.Diagnostics.Process.Start(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & FileName & ".eml")

            End If

        End Sub
        Public Function SendASPReportDownloadEmail(Session As AdvantageFramework.Security.Session, File As String, Optional EmailAddress As String = "") As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = String.Empty
            Dim EmployeeEmailAddress As String = String.Empty
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MIMEType As String = String.Empty
            Dim FileName As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(EmailAddress) Then

                        Try

                            EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

                        Catch ex As Exception
                            EmployeeEmailAddress = ""
                        End Try

                    Else

                        EmployeeEmailAddress = EmailAddress

                    End If

                    If String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                        MIMEType = AdvantageFramework.FileSystem.GetMIMEType(File)
                        FileName = AdvantageFramework.FileSystem.GetFileName(File)

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        HtmlEmail.AddHeaderRow("Report Link")
                        HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "Document/ReportDownload?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName &
                                                                                                                                                                                           "&Date=" & Now.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                                                                           "&File=" & File.Replace("&", "<>") &
                                                                                                                                                                                           "&MIMEType=" & MIMEType) & "%7C"" > Click Here to download your report</a>")

                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.Finish()

                        EmailSent = AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", "Report Download - " & FileName, HtmlEmail.ToString, 3, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus)

                    End If

                End If

            End Using

            SendASPReportDownloadEmail = EmailSent

        End Function
        Public Function SendASPUploadEmail(Session As AdvantageFramework.Security.Session, DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                           DocumentSubLevel As AdvantageFramework.Database.Entities.DocumentSubLevel, DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = String.Empty
            Dim EmployeeEmailAddress As String = String.Empty
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                EnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(DocumentLevel)
                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing AndAlso EnumObject IsNot Nothing Then

                    Try

                        EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

                    Catch ex As Exception
                        EmployeeEmailAddress = ""
                    End Try

                    If String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                        WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        HtmlEmail.AddHeaderRow("Upload Link")
                        HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "Document/Upload?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Date=" & Now.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                                                                     "&DatabaseName=" & Session.DatabaseName &
                                                                                                                                                                                     "&UserCode=" & Session.UserCode &
                                                                                                                                                                                     DocumentLevelSetting.LoadDocumentLevelSettingASPString) & "%7C"" > Click Here to upload your documents</a>")

                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.Finish()

                        EmailSent = AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", "Upload Link - " & EnumObject.Description, HtmlEmail.ToString, 3, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus)

                    End If

                End If

            End Using

            SendASPUploadEmail = EmailSent

        End Function

#End Region

    End Module

End Namespace
