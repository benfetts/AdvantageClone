Imports Webvantage.cSecurity
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports MyGeneration.dOOdads
Imports System.Text.RegularExpressions
Imports System.Threading
Imports MailBee
Imports MailBee.Mime
Imports MailBee.SmtpMail

Public Class Alert

    Inherits _ALERT
    Dim oSQL As SqlHelper
    Public Property ErrorString As String = ""

#Region " Email "

    'Moved over from cWebServices
    ' '' '' ''Public Function SendEmailNew(ByVal strFileName As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, ByVal [Priority] As Integer, _
    ' '' '' ''                             ByVal DocLinkList As System.Collections.Generic.List(Of Integer), _
    ' '' '' ''                                 Optional ByVal strFileNameJS As String = "", Optional ByVal strCCList As String = "", Optional ByVal strBCCList As String = "", _
    ' '' '' ''                                 Optional ByVal strCCListDelimiter As String = ",", Optional ByVal strBCCListDelimiter As String = ",", Optional ByVal strFileNameJV As String = "", _
    ' '' '' ''                                 Optional ByVal strFileNameEST As String = "", Optional ByVal combine As Integer = 0, Optional ByVal strFileNameCB As String = "", Optional ByVal AlertId As Integer = 0, _
    ' '' '' ''                                 Optional ByVal strFileNamePS As String = "", Optional ByRef ErrorMessage As String = "", Optional ByVal DocIDs() As Integer = Nothing) As Boolean
    ' '' '' ''    Try
    ' '' '' ''        If strTo.Trim() = "" Then
    ' '' '' ''            'no email addresses to send to...
    ' '' '' ''            'just return a true so as to not trigger an error alert
    ' '' '' ''            Return True
    ' '' '' ''        End If
    ' '' '' ''        Dim strFrom As String = String.Empty
    ' '' '' ''        Dim x As Integer
    ' '' '' ''        Dim arrayTo As Boolean = True
    ' '' '' ''        Dim arrayCc As Boolean = True
    ' '' '' ''        Dim arrayBcc As Boolean = True
    ' '' '' ''        Dim toArray() As String
    ' '' '' ''        Dim ccArray() As String
    ' '' '' ''        Dim bccArray() As String
    ' '' '' ''        Dim boolMisc As Boolean = False

    ' '' '' ''        Dim ws As New cWebServices(Me.ConnectionString)
    ' '' '' ''        boolMisc = ws.GetSMPTSettingsByUser()
    ' '' '' ''        If boolMisc = False Then
    ' '' '' ''            Me.ErrorString = "Error collecting SMTP database data."
    ' '' '' ''            Return False
    ' '' '' ''        End If

    ' '' '' ''        Dim SMTPUsername As String = ws.oSMTPSettings.EMAIL_USERNAME
    ' '' '' ''        Dim SMTPPassword As String = ws.oSMTPSettings.EMAIL_PWD

    ' '' '' ''        strFrom = ws.oSMTPSettings.SMTP_SENDER

    ' '' '' ''        MailBee.Global.SafeMode = True
    ' '' '' ''        Dim mbSMTP As New MailBee.SmtpMail.Smtp
    ' '' '' ''        mbSMTP.LicenseKey = ws.oSMTPSettings.MB_LICENSE_KEY

    ' '' '' ''        Dim mbServerInfo As New MailBee.SmtpMail.SmtpServer
    ' '' '' ''        With mbServerInfo
    ' '' '' ''            .AuthMethods = ws.oSMTPSettings.SMTP_AUTH_METHOD
    ' '' '' ''            .Name = ws.oSMTPSettings.SMTP_SERVER
    ' '' '' ''            .AccountName = [SMTPUsername]
    ' '' '' ''            .Password = [SMTPPassword]
    ' '' '' ''            If ws.oSMTPSettings.SMTP_PORT_NUMBER > 0 Then
    ' '' '' ''                .Port = ws.oSMTPSettings.SMTP_PORT_NUMBER
    ' '' '' ''            End If
    ' '' '' ''            Select Case ws.oSMTPSettings.SMTP_SECURE_TYPE
    ' '' '' ''                Case 1
    ' '' '' ''                    .SslMode = MailBee.Security.SslStartupMode.OnConnect
    ' '' '' ''                Case 2
    ' '' '' ''                    .SslMode = MailBee.Security.SslStartupMode.UseStartTls
    ' '' '' ''            End Select
    ' '' '' ''            '.SmtpOptions = ExtendedSmtpOptions.ClassicSmtpMode _
    ' '' '' ''            '               And ExtendedSmtpOptions.NoChunking _
    ' '' '' ''            '               And ExtendedSmtpOptions.NoDsn _
    ' '' '' ''            '               And ExtendedSmtpOptions.NoSize
    ' '' '' ''        End With

    ' '' '' ''        'assume email server disabled
    ' '' '' ''        If mbServerInfo.Name.Trim() = "" Then
    ' '' '' ''            Me.ErrorString = ""
    ' '' '' ''            ErrorMessage = Me.ErrorString
    ' '' '' ''            Return True
    ' '' '' ''        End If

    ' '' '' ''        mbServerInfo.HelloDomain = mbServerInfo.Name
    ' '' '' ''        mbSMTP.DirectSendDefaults.HelloDomain = mbServerInfo.Name

    ' '' '' ''        mbSMTP.SmtpServers.Add(mbServerInfo)

    ' '' '' ''        Dim SmtpServerConnected As Boolean = False
    ' '' '' ''        Try
    ' '' '' ''            SmtpServerConnected = mbSMTP.Connect()
    ' '' '' ''            If SmtpServerConnected = False Then
    ' '' '' ''                Me.ErrorString = mbSMTP.GetErrorDescription
    ' '' '' ''                ErrorMessage = mbSMTP.GetErrorDescription
    ' '' '' ''                If Not mbSMTP Is Nothing Then
    ' '' '' ''                    mbSMTP = Nothing
    ' '' '' ''                End If
    ' '' '' ''                If Not mbServerInfo Is Nothing Then
    ' '' '' ''                    mbServerInfo = Nothing
    ' '' '' ''                End If
    ' '' '' ''                Return False
    ' '' '' ''            End If
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''            Me.ErrorString = "Could not connect to SMTP server.  " & Me.ErrorString & " " & ex.Message.ToString()
    ' '' '' ''            ErrorMessage = Me.ErrorString
    ' '' '' ''            Return False
    ' '' '' ''        End Try

    ' '' '' ''        strTo = MiscFN.CleanStringForSplit(strTo, ",", True, True, True, True)
    ' '' '' ''        strCCList = MiscFN.CleanStringForSplit(strCCList, ",", True, True, True, True)
    ' '' '' ''        strBCCList = MiscFN.CleanStringForSplit(strBCCList, ",", True, True, True, True)

    ' '' '' ''        If strTo <> "" And strTo.Contains(",") = True Then
    ' '' '' ''            toArray = strTo.Split(",")
    ' '' '' ''        ElseIf strTo <> "" Then
    ' '' '' ''            If AdvantageFramework.Email.IsValidEmailAddress(strTo) = False Then
    ' '' '' ''                Me.ErrorString = "Invalid Send To email address"
    ' '' '' ''                Return False
    ' '' '' ''                Exit Function
    ' '' '' ''            End If
    ' '' '' ''            arrayTo = False
    ' '' '' ''        Else
    ' '' '' ''            arrayTo = False
    ' '' '' ''        End If
    ' '' '' ''        If strCCList <> "" And strCCList.Contains(",") Then
    ' '' '' ''            ccArray = strCCList.Split(",")
    ' '' '' ''        ElseIf strCCList <> "" Then
    ' '' '' ''            If AdvantageFramework.Email.IsValidEmailAddress(strCCList) = False Then
    ' '' '' ''                Me.ErrorString = "Invalid CC email address"
    ' '' '' ''                Return False
    ' '' '' ''                Exit Function
    ' '' '' ''            End If
    ' '' '' ''            arrayCc = False
    ' '' '' ''        Else
    ' '' '' ''            arrayCc = False
    ' '' '' ''        End If
    ' '' '' ''        If strBCCList <> "" And strBCCList.Contains(",") Then
    ' '' '' ''            bccArray = strBCCList.Split(",")
    ' '' '' ''        ElseIf strBCCList <> "" Then
    ' '' '' ''            If AdvantageFramework.Email.IsValidEmailAddress(strBCCList) = False Then
    ' '' '' ''                Me.ErrorString = "Invalid BCC email address"
    ' '' '' ''                Return False
    ' '' '' ''                Exit Function
    ' '' '' ''            End If
    ' '' '' ''            arrayBcc = False
    ' '' '' ''        Else
    ' '' '' ''            arrayBcc = False
    ' '' '' ''        End If

    ' '' '' ''        If arrayTo = True Then
    ' '' '' ''            If toArray.Length > 0 Then
    ' '' '' ''                For x = 0 To toArray.Length - 1
    ' '' '' ''                    If AdvantageFramework.Email.IsValidEmailAddress(toArray(x).ToString().Trim()) = False Then
    ' '' '' ''                        Me.ErrorString = "Invalid email address"
    ' '' '' ''                        Return False
    ' '' '' ''                        Exit Function
    ' '' '' ''                    End If
    ' '' '' ''                Next
    ' '' '' ''            End If
    ' '' '' ''        End If


    ' '' '' ''        If arrayCc = True Then
    ' '' '' ''            If ccArray.Length > 0 Then
    ' '' '' ''                For x = 0 To ccArray.Length - 1
    ' '' '' ''                    If AdvantageFramework.Email.IsValidEmailAddress(ccArray(x).ToString().Trim()) = False Then
    ' '' '' ''                        Me.ErrorString = "Invalid CC address"
    ' '' '' ''                        Return False
    ' '' '' ''                        Exit Function
    ' '' '' ''                    End If
    ' '' '' ''                Next
    ' '' '' ''            End If
    ' '' '' ''        End If

    ' '' '' ''        If arrayBcc = True Then
    ' '' '' ''            If bccArray.Length > 0 Then
    ' '' '' ''                For x = 0 To bccArray.Length - 1
    ' '' '' ''                    If AdvantageFramework.Email.IsValidEmailAddress(bccArray(x).ToString().Trim()) = False Then
    ' '' '' ''                        Me.ErrorString = "Invalid BCC address"
    ' '' '' ''                        Return False
    ' '' '' ''                        Exit Function
    ' '' '' ''                    End If
    ' '' '' ''                Next
    ' '' '' ''            End If
    ' '' '' ''        End If


    ' '' '' ''        Dim boolHasAttachment As Boolean = False

    ' '' '' ''        Dim emp As New cEmployee(Me.ConnectionString)
    ' '' '' ''        Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact
    ' '' '' ''        If MiscFN.IsClientPortal = True Then
    ' '' '' ''            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
    ' '' '' ''            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
    ' '' '' ''                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
    ' '' '' ''                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
    ' '' '' ''                    If Agency.UseEmployeeEmail = 1 Then
    ' '' '' ''                        ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, HttpContext.Current.Session("UserID"))
    ' '' '' ''                        If ClientContact.EmailAddress <> "" Then
    ' '' '' ''                            mbSMTP.Message.From.AsString = ClientContact.FullNameFML & " <" & ClientContact.EmailAddress & ">"
    ' '' '' ''                        Else
    ' '' '' ''                            mbSMTP.Message.From.AsString = ws.oSMTPSettings.SMTP_SENDER
    ' '' '' ''                        End If
    ' '' '' ''                    Else
    ' '' '' ''                        mbSMTP.Message.From.AsString = ws.oSMTPSettings.SMTP_SENDER
    ' '' '' ''                    End If
    ' '' '' ''                End Using
    ' '' '' ''            End Using
    ' '' '' ''        Else
    ' '' '' ''            mbSMTP.Message.From.AsString = emp.GetFromAddress(HttpContext.Current.Session("EmpCode"))
    ' '' '' ''        End If
    ' '' '' ''        mbSMTP.Message.To.AsString = strTo
    ' '' '' ''        mbSMTP.Message.Subject = strSubject
    ' '' '' ''        mbSMTP.Message.ReplyTo.AsString = ws.oSMTPSettings.EMAIL_REPLY_TO

    ' '' '' ''        Dim a As New cAlerts()
    ' '' '' ''        a.SetPriority(mbSMTP, [Priority])

    ' '' '' ''        If AlertId = 0 Then
    ' '' '' ''            Try
    ' '' '' ''                If strFileName <> "" And strFileName.Length > 0 And strFileName <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    mbSMTP.AddAttachment(strFileName)
    ' '' '' ''                End If
    ' '' '' ''                If strFileNameJS <> "" And strFileNameJS.Length > 0 And strFileNameJS <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    mbSMTP.AddAttachment(strFileNameJS)
    ' '' '' ''                End If
    ' '' '' ''                If strFileNameJV <> "" And strFileNameJV.Length > 0 And strFileNameJV <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    mbSMTP.AddAttachment(strFileNameJV)
    ' '' '' ''                End If
    ' '' '' ''                If strFileNameEST <> "" And strFileNameEST.Length > 0 And strFileNameEST <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    If combine = 1 Then
    ' '' '' ''                        mbSMTP.AddAttachment(strFileNameEST)
    ' '' '' ''                    Else
    ' '' '' ''                        Dim files() As String = strFileNameEST.Split(",")
    ' '' '' ''                        For p As Integer = 0 To files.Length - 1
    ' '' '' ''                            mbSMTP.AddAttachment(files(p))
    ' '' '' ''                        Next
    ' '' '' ''                    End If
    ' '' '' ''                End If
    ' '' '' ''                If strFileNameCB <> "" And strFileNameCB.Length > 0 And strFileNameCB <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    mbSMTP.AddAttachment(strFileNameCB)
    ' '' '' ''                End If
    ' '' '' ''                If strFileNamePS <> "" And strFileNamePS.Length > 0 And strFileNamePS <> String.Empty Then
    ' '' '' ''                    boolHasAttachment = True
    ' '' '' ''                    mbSMTP.AddAttachment(strFileNamePS)
    ' '' '' ''                End If
    ' '' '' ''            Catch ex As Exception
    ' '' '' ''                Me.ErrorString = ex.Message
    ' '' '' ''                Return False
    ' '' '' ''            End Try
    ' '' '' ''        End If

    ' '' '' ''        Dim DocumentRepository As New DocumentRepository(Me.ConnectionString)
    ' '' '' ''        Dim oAgency As New cAgency(Me.ConnectionString)
    ' '' '' ''        Dim Document As New Document(Me.ConnectionString)
    ' '' '' ''        Dim BoolHasLinksHeader As Boolean = False
    ' '' '' ''        Dim HTMLNewLine As String = "<br />"
    ' '' '' ''        Dim sb As New System.Text.StringBuilder

    ' '' '' ''        If AlertId = 0 Then
    ' '' '' ''            For Each l As Integer In DocLinkList
    ' '' '' ''                Document.Where.DOCUMENT_ID.Value = l
    ' '' '' ''                If Document.Query.Load() = True Then

    ' '' '' ''                    If Document.MIME_TYPE = "URL" Then
    ' '' '' ''                        If BoolHasLinksHeader = False Then
    ' '' '' ''                            sb.AppendLine("<b>Attached Links:</b>&nbsp;&nbsp;" & HTMLNewLine)
    ' '' '' ''                            BoolHasLinksHeader = True
    ' '' '' ''                        End If
    ' '' '' ''                        sb.AppendLine("<a href=""" & Document.REPOSITORY_FILENAME & """>" & Document.FILENAME & "</a>" & HTMLNewLine)
    ' '' '' ''                    Else
    ' '' '' ''                        Try
    ' '' '' ''                            Dim ByteStream As Byte()
    ' '' '' ''                            ByteStream = DocumentRepository.GetDocument(Document.DOCUMENT_ID)
    ' '' '' ''                            mbSMTP.Message.Attachments.Add(ByteStream, Document.FILENAME, Nothing, Document.MIME_TYPE, Nothing, _
    ' '' '' ''                                                            MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)
    ' '' '' ''                            If Not ByteStream Is Nothing Then
    ' '' '' ''                                ByteStream = Nothing
    ' '' '' ''                            End If
    ' '' '' ''                            ByteStream = Nothing
    ' '' '' ''                        Catch ex As Exception
    ' '' '' ''                        End Try
    ' '' '' ''                    End If
    ' '' '' ''                    Document = New Document(Me.ConnectionString)

    ' '' '' ''                End If
    ' '' '' ''            Next
    ' '' '' ''            For Each z As Integer In DocIDs
    ' '' '' ''                Document.Where.DOCUMENT_ID.Value = z
    ' '' '' ''                If Document.Query.Load() = True Then
    ' '' '' ''                    Try
    ' '' '' ''                        Dim ByteStream As Byte()
    ' '' '' ''                        ByteStream = DocumentRepository.GetDocument(Document.DOCUMENT_ID)
    ' '' '' ''                        mbSMTP.Message.Attachments.Add(ByteStream, Document.FILENAME, Nothing, Document.MIME_TYPE, Nothing, _
    ' '' '' ''                                                        MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)
    ' '' '' ''                        If Not ByteStream Is Nothing Then
    ' '' '' ''                            ByteStream = Nothing
    ' '' '' ''                        End If
    ' '' '' ''                        ByteStream = Nothing
    ' '' '' ''                    Catch ex As Exception
    ' '' '' ''                    End Try
    ' '' '' ''                    Document = New Document(Me.ConnectionString)
    ' '' '' ''                End If
    ' '' '' ''            Next
    ' '' '' ''        End If
    ' '' '' ''        If AlertId > 0 Then
    ' '' '' ''            Dim AlertAttachments As New vAlertAttachmentList(Me.ConnectionString)
    ' '' '' ''            AlertAttachments.Where.AlertID.Value = AlertId
    ' '' '' ''            AlertAttachments.Where.EMAILSENT.Value = False
    ' '' '' ''            AlertAttachments.Query.Load()
    ' '' '' ''            Do Until AlertAttachments.EOF
    ' '' '' ''                If AlertAttachments.MimeType = "URL" Then
    ' '' '' ''                    If BoolHasLinksHeader = False Then
    ' '' '' ''                        sb.AppendLine("<b>Attached Links:</b>&nbsp;&nbsp;" & HTMLNewLine)
    ' '' '' ''                        BoolHasLinksHeader = True
    ' '' '' ''                    End If
    ' '' '' ''                    sb.AppendLine("<a href=""" & AlertAttachments.REPOSITORY_FILENAME & """>" & AlertAttachments.RealFileName & "</a>" & HTMLNewLine)
    ' '' '' ''                Else
    ' '' '' ''                    Try
    ' '' '' ''                        Dim ByteStream As Byte()

    ' '' '' ''                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
    ' '' '' ''                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
    ' '' '' ''                        If MiscFN.IsNTAuth = True Then
    ' '' '' ''                            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
    ' '' '' ''                            impersonationContext = currentWindowsIdentity.Impersonate()
    ' '' '' ''                        End If

    ' '' '' ''                        ByteStream = DocumentRepository.GetDocument(AlertAttachments.DOCUMENT_ID)

    ' '' '' ''                        If MiscFN.IsNTAuth = True Then
    ' '' '' ''                            impersonationContext.Undo()
    ' '' '' ''                        End If

    ' '' '' ''                        mbSMTP.Message.Attachments.Add(ByteStream, AlertAttachments.RealFileName, Nothing, AlertAttachments.MimeType, _
    ' '' '' ''                                                        Nothing, MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64)
    ' '' '' ''                        If Not ByteStream Is Nothing Then
    ' '' '' ''                            ByteStream = Nothing
    ' '' '' ''                        End If
    ' '' '' ''                    Catch ex As Exception

    ' '' '' ''                    End Try

    ' '' '' ''                End If
    ' '' '' ''                AlertAttachments.MoveNext()
    ' '' '' ''            Loop
    ' '' '' ''        End If

    ' '' '' ''        mbSMTP.Message.BodyHtmlText = strBody & sb.ToString

    ' '' '' ''        Try
    ' '' '' ''            If strCCList <> "" Then
    ' '' '' ''                strCCList = MiscFN.RemoveTrailingDelimiter(strCCList, strCCListDelimiter)
    ' '' '' ''                mbSMTP.Message.Cc.AsString = strCCList
    ' '' '' ''            End If
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''            Me.ErrorString = ex.Message
    ' '' '' ''            Return False
    ' '' '' ''        End Try

    ' '' '' ''        Try
    ' '' '' ''            If strBCCList <> "" Then
    ' '' '' ''                strBCCList = MiscFN.RemoveTrailingDelimiter(strBCCList, strBCCListDelimiter)
    ' '' '' ''                mbSMTP.Message.Bcc.AsString = strBCCList
    ' '' '' ''            End If
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''            Me.ErrorString = ex.Message
    ' '' '' ''            Return False
    ' '' '' ''        End Try

    ' '' '' ''        Try
    ' '' '' ''            If mbSMTP.Message.To.AsString = "" And mbSMTP.Message.Cc.AsString = "" And mbSMTP.Bcc.AsString = "" Then
    ' '' '' ''            Else
    ' '' '' ''                If Me.MessageIsOverSized(mbSMTP, , Me.ErrorString) = True Then

    ' '' '' ''                    ErrorMessage = Me.ErrorString

    ' '' '' ''                End If
    ' '' '' ''                boolMisc = mbSMTP.Send()
    ' '' '' ''            End If
    ' '' '' ''            If boolMisc = False Then
    ' '' '' ''                Me.ErrorString = mbSMTP.GetErrorDescription
    ' '' '' ''                Return False
    ' '' '' ''            End If
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''            Me.ErrorString = ex.Message
    ' '' '' ''            Return False
    ' '' '' ''        End Try

    ' '' '' ''        Try
    ' '' '' ''            mbSMTP.Disconnect()
    ' '' '' ''            mbSMTP = Nothing
    ' '' '' ''            Return True
    ' '' '' ''        Catch ex As Exception
    ' '' '' ''        End Try

    ' '' '' ''    Catch ex As Exception
    ' '' '' ''        Me.ErrorString = ex.Message
    ' '' '' ''        Return False
    ' '' '' ''    End Try

    ' '' '' ''    Return True

    ' '' '' ''End Function
    Public Shared Property BaseMessageIsOverSizedMessage As String = "Message exceeds maximum email size."
    Public Function MessageIsOverSized(ByRef Smtp As MailBee.SmtpMail.Smtp, Optional ByVal ClearAttachments As Boolean = True, Optional ByRef Message As String = "") As Boolean

        Dim MaxEmailSize As Long = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            MaxEmailSize = AdvantageFramework.Email.LoadMaxEmailSize(DbContext)

        End Using

        If MaxEmailSize > 0 AndAlso Smtp.Message.Size > MaxEmailSize Then

            Message = BaseMessageIsOverSizedMessage

            If ClearAttachments = True Then

                Smtp.Message.Attachments.Clear()
                Message &= "  Attachments were excluded but the email was still sent."

            End If

            Return True

        Else

            Message = ""
            Return False

        End If

    End Function

#End Region
#Region " HTML "

    Public Function GeneralInfoTable(ByVal AlertID As Integer) As String
        Dim sb As New System.Text.StringBuilder
        Dim AlertDetails As New vMyAlerts(Me.ConnectionString)
        Dim cs As New cSecurity(Me.ConnectionString)
        Dim HTMLNewLine As String = "<br />"
        Dim returnstr As String

        Me.LoadByPrimaryKey(AlertID)

        AlertDetails.Where.ALERT_ID.Value = AlertID
        AlertDetails.Query.Load()

        sb.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF""><tr>")
        sb.AppendLine("<td height=""23"" align=""left"" valign=""middle"" bgcolor=""#92B4E0""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"" color=""#FFFFFF"">")

        sb.AppendLine("General Information</font></td></tr><tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        'sb.AppendLine("Type:&nbsp;&nbsp;Webvantage Alert" & HTMLNewLine)
        sb.AppendLine("Generated Date:&nbsp;&nbsp;" & String.Format("Generated Date:&nbsp;&nbsp;{0:G}", Me.GENERATED) & HTMLNewLine)
        If Me.s_CP_ALERT = "1" Then
            sb.AppendLine("Generated By: &nbsp;&nbsp;" & cs.GetAlertClientContact(CInt(Me.ALERT_USER)) & HTMLNewLine)
        Else
            sb.AppendLine("Generated By: &nbsp;&nbsp;" & Me.ALERT_USER & HTMLNewLine)
        End If

        Dim a As New cAlerts()
        sb.AppendLine("Priority:&nbsp;&nbsp;" & a.GetPriorityText(PRIORITY) & HTMLNewLine)
        'sb.AppendLine("Category:&nbsp;&nbsp;" & AlertDetails.CATEGORY & HTMLNewLine & HTMLNewLine)
        sb.Append("</td> </tr> </table>")
        Return sb.ToString
    End Function


    Public Function GeneralInfo(ByVal AlertID As Integer) As String
        Dim AlertDetails As New vMyAlerts(Me.ConnectionString)
        Dim cs As New cSecurity(Me.ConnectionString)
        Dim returnstr As String
        Dim AltAlertID As Integer = 0

        Me.LoadByPrimaryKey(AlertID)

        AlertDetails.Where.ALERT_ID.Value = AlertID
        AlertDetails.Query.Load()

        Try
            If AlertDetails.s_ALERT_SEQ_NBR <> "" Then
                If CInt(AlertDetails.ALERT_SEQ_NBR) > 0 Then
                    AltAlertID = CInt(AlertDetails.ALERT_SEQ_NBR)
                End If
            End If
        Catch ex As Exception
            AltAlertID = 0
        End Try

        Try
            If AltAlertID = 0 Then
                AltAlertID = AlertDetails.ALERT_ID
            End If
        Catch ex As Exception
            AltAlertID = 0
        End Try

        Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(False)

        Dim a As New cAlerts()
        With EmailBody
            .AddHeaderRow("General Information")
            .AddKeyValueRow("ID", AltAlertID.ToString())
            If MiscFN.IsClientPortal = True Then
                .AddKeyValueRow("Type", "Client Portal Alert")
            Else
                .AddKeyValueRow("Type", "Webvantage Alert")
            End If

            .AddKeyValueRow("Generated", String.Format("{0:G}", Me.GENERATED))
            If Me.s_CP_ALERT = "1" Then
                .AddKeyValueRow("By", cs.GetAlertClientContact(CInt(Me.ALERT_USER)))
            Else
                .AddKeyValueRow("By", Me.ALERT_USER)
            End If
            Try
                If s_PRIORITY <> "" Then
                    .AddKeyValueRow("Priority", a.GetPriorityText(PRIORITY))
                End If
            Catch ex As Exception
            End Try
            Try
                If AlertDetails.s_CATEGORY <> "" Then
                    .AddKeyValueRow("Category", AlertDetails.CATEGORY)
                End If
            Catch ex As Exception
            End Try
            Try
                If AlertDetails.s_DUE_DATE <> "" Then
                    .AddKeyValueRow("Due Date", String.Format("{0:G}", AlertDetails.DUE_DATE))
                End If
            Catch ex As Exception
            End Try
            Try
                If AlertDetails.s_TIME_DUE <> "" Then
                    .AddKeyValueRow("Time Due", AlertDetails.TIME_DUE)
                End If
            Catch ex As Exception
            End Try
            Try
                If AlertDetails.s_VER <> "" Then
                    .AddKeyValueRow("Version", AlertDetails.VER)
                End If
            Catch ex As Exception
            End Try
            Try
                If AlertDetails.s_BUILD <> "" Then
                    .AddKeyValueRow("Build", AlertDetails.BUILD)
                End If
            Catch ex As Exception
            End Try

            .Finish()
        End With

        Return EmailBody.ToString()
    End Function

    Public Function GeneralInfoNoAlert(ByVal UserCode As String, ByVal PriorityEmail As String) As String
        Dim EnumType As System.Type = GetType(cAlerts.Priority)
        Dim Priority As String = System.Enum.GetName(EnumType, cAlerts.Priority.Normal)
        If IsNumeric(PriorityEmail) = True Then
            Priority = System.Enum.GetName(EnumType, CType(PriorityEmail, Integer))
        End If

        Dim EmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(False)
        With EmailBody
            .AddHeaderRow("General Information")
            .AddKeyValueRow("Generated", String.Format("{0:G}", cEmployee.TimeZoneToday))
            .AddKeyValueRow("By", UserCode)
            .AddKeyValueRow("Priority", Priority)
            .Finish()
        End With

        Return EmailBody.ToString()
    End Function

    Public Function CreateHyperlinkRow(ByVal URL As String, Optional ByVal LinkText As String = "")
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("<a href=""" & URL & """>")
            If LinkText.Trim() <> "" Then
                .Append(LinkText)
            Else
                .Append(URL)
            End If
            .Append("</a>")
        End With
        Return sb.ToString()
    End Function

#End Region
#Region " Data "

    Public Function GetDefaultGroup(ByVal strClient As String, ByVal strDivision As String, ByVal strProduct As String) As String
        Dim SessionKey As String = "GetDefaultGroup" & strClient & strDivision & strProduct
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim dr As SqlDataReader
                Dim arParams(5) As SqlParameter

                Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
                parameterClient.Value = strClient
                arParams(0) = parameterClient
                Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
                parameterDivision.Value = strDivision
                arParams(1) = parameterDivision
                Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
                parameterProduct.Value = strProduct
                arParams(2) = parameterProduct

                Try
                    dr = oSQL.ExecuteReader(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_defaults_email_group", arParams)

                    If dr.HasRows Then
                        Do While dr.Read
                            If IsDBNull(dr("EmailGroup")) Then
                                ReturnString = ""
                            Else
                                ReturnString = CStr(dr("EmailGroup"))
                            End If
                        Loop
                    End If

                Catch
                    Err.Raise(Err.Number, "Class:cAlerts Routine:GetDefaultGroup", Err.Description)
                End Try

            Catch ex As Exception
                ReturnString = ""
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function


    Public Function GetJobComments(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As DataTable
        Try
            Dim arP(2) As SqlParameter

            Dim pJobNumber As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJobNumber.Value = JobNumber
            arP(0) = pJobNumber

            Dim pJobComponentNbr As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJobComponentNbr.Value = JobComponentNbr
            arP(1) = pJobComponentNbr

            Return oSQL.ExecuteDataTable(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_ALERT_COMMENTS_BY_JOB", "DtAlertComments", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Obsolete()>
    Public Overrides Sub Save()

        '' '' '' Go get the next alertID
        ' '' ''Dim Alert As New Alert(Me.ConnectionString)
        ' '' ''Dim ap As AggregateParameter = Alert.Aggregate.TearOff.ALERT_ID
        ' '' ''ap.Function = AggregateParameter.Func.Max


        ' '' ''Alert.Query.Load()
        ' '' ''Dim NextAlertID As Integer = 1
        ' '' ''Try
        ' '' ''    If Alert.RowCount > 0 Then
        ' '' ''        NextAlertID = Alert.ALERT_ID + 1
        ' '' ''    End If

        ' '' ''Catch ex As Exception
        ' '' ''    NextAlertID = 1
        ' '' ''End Try

        ' '' ''MyBase.ALERT_ID = NextAlertID
        ' '' ''MyBase.Save()

    End Sub

    Private Function ExcludeSelfFromAlertEmail() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ExcludeSelfFromAlertEmail" & Me.ALERT_ID.ToString()

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim parameterAlertID As New SqlParameter("@ALERT_ID", SqlDbType.Int)
                parameterAlertID.Value = Me.ALERT_ID

                IsValid = MiscFN.IntToBool(CType(SqlHelper.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure,
                                               "usp_wv_ALERT_EXCLUDE_SELF_FROM_EMAIL", parameterAlertID), Integer))
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Private Function CheckAlertOriginator() As String
        ''''If Me.EmailAssignmentOrigintorOverride_DontEmailMe = True Then Return ""

        Dim SessionKey As String = "CheckAlertOriginator" & Me.ALERT_ID.ToString()
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim sb As New System.Text.StringBuilder
                With sb
                    .Append("SELECT ISNULL(ALERT.EMP_CODE, '') ")
                    .Append("FROM   ALERT WITH (NOLOCK) ")
                    .Append("       INNER JOIN EMPLOYEE WITH (NOLOCK) ")
                    .Append("            ON  ALERT.EMP_CODE = EMPLOYEE.EMP_CODE ")
                    .Append("WHERE  (EMPLOYEE.ALERT_EMAIL = 1 OR EMPLOYEE.ALERT_EMAIL = 3) AND (EMPLOYEE.EMP_TERM_DATE IS NULL OR EMPLOYEE.EMP_TERM_DATE > GETDATE()) ")
                    .Append("       AND ALERT.ALERT_ID =  ")
                    .Append(Me.ALERT_ID)
                    .Append(";")
                End With

                ReturnString = SqlHelper.ExecuteScalar(Me.ConnectionString, CommandType.Text, sb.ToString())

                If ReturnString <> "" Then
                    'check user override


                End If

            Catch ex As Exception
                ReturnString = ""
            End Try

            HttpContext.Current.Session(SessionKey) = ReturnString

        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Public Function GetCommentsView() As vAlertComments
        Try
            Dim Comments As New vAlertComments(Me.ConnectionString)
            Comments.Where.AlertID.Value = Me.ALERT_ID
            Comments.Query.AddOrderBy(Comments.ColumnNames.Generated, WhereParameter.Dir.DESC)
            Comments.Query.AddOrderBy(Comments.ColumnNames.CommentID, WhereParameter.Dir.DESC)
            Comments.Query.Load()

            Return Comments

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAttachmentList() As vAlertAttachmentList
        Try
            Dim attachments As New vAlertAttachmentList(Me.ConnectionString)
            attachments.Where.AlertID.Value = Me.ALERT_ID
            attachments.Query.Load()

            Return attachments

        Catch ex As Exception
            Throw New Exception("Error retrieving attachment list.", ex)

        End Try
    End Function

    Public Function AddComment(ByVal userCode As String, ByVal comment As String) As Integer
        Dim newComment As New AlertComment(Me.ConnectionString)
        Try
            With newComment
                .ALERT_ID = Me.ALERT_ID
                .USER_CODE = userCode
                .COMMENT = comment
                .GENERATED_DATE = Date.Now
                .EMAILSENT = False
                .Save()
                Return .s_COMMENT_ID
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DismissAlert(ByVal empCode As String) As Boolean
        Try

            Dim AlertRecipient As New AlertRecipient(Me.ConnectionString)
            AlertRecipient.Where.ALERT_ID.Value = Me.ALERT_ID
            AlertRecipient.Where.EMP_CODE.Value = empCode
            AlertRecipient.Query.Load()

            If AlertRecipient.RowCount > 0 Then
                'Set the PROCESSED date to now
                AlertRecipient.PROCESSED = Date.Now
                AlertRecipient.Save()
            Else
                ' This seems to happen when a user created an alert (Diary) with no recipients.
                Me.AddAlertRecipient(empCode)
                AlertRecipient.Where.ALERT_ID.Value = Me.ALERT_ID
                AlertRecipient.Where.EMP_CODE.Value = empCode
                AlertRecipient.Query.Load()
                AlertRecipient.PROCESSED = Date.Now
                AlertRecipient.Save()
            End If
            Return True
        Catch ex As Exception
            Throw New Exception("Error dismissing alert.", ex)

        End Try

    End Function

    Public Function GetAttachmentCount() As Integer
        Try
            Dim Attachments As New vAlertAttachmentList(Me.ConnectionString)
            Attachments.Where.AlertID.Value = Me.ALERT_ID
            Attachments.Query.Load()
            Return Attachments.RowCount

        Catch ex As Exception
            Throw New Exception("Error getting attachment count.", ex)
        End Try

    End Function

    Public Function AddAlertRecipient(ByVal empCode As String, Optional ByVal IgnoreEmailFlag As Boolean = False) As Boolean
        Try

            Dim ReturnValue As Boolean = True

            Using oc = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient

                Recipient = Nothing
                Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertIDAndEmployeeCode(oc, Me.ALERT_ID, empCode)

                If Recipient Is Nothing OrElse (Recipient.IsCurrentNotify IsNot Nothing AndAlso Recipient.IsCurrentNotify = 1) Then

                    Dim EmailAddress As String = ""
                    Dim Employee As New cEmployee(Me.ConnectionString)

                    If IgnoreEmailFlag = True Then

                        EmailAddress = Employee.GetEmail(empCode)

                    Else

                        Dim EmailFlag As Integer = 0

                        EmailFlag = Employee.GetAlertEmailFlag(empCode)

                        'FLAG DESCRIPTION
                        ' 0 = NO ALERT, NO EMAIL
                        ' 1 = NO ALERT, YES EMAIL
                        ' 2 = YES ALERT, NO EMAIL
                        ' 3 = YES ALERT, YES EMAIL

                        Select Case EmailFlag
                            Case 0
                                Exit Function
                            Case 1, 3
                                EmailAddress = Employee.GetEmail(empCode)
                            Case 2
                                EmailAddress = ""
                        End Select

                    End If

                    Recipient = New AdvantageFramework.Database.Entities.AlertRecipient

                    Recipient.AlertID = Me.ALERT_ID
                    Recipient.EmployeeCode = empCode
                    Recipient.EmployeeEmail = EmailAddress
                    Recipient.IsNewAlert = 1
                    If empCode = HttpContext.Current.Session("EmpCode") Then
                        Recipient.HasBeenRead = 1
                    End If

                    ReturnValue = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(oc, Recipient)

                End If

            End Using

            Return ReturnValue

        Catch ex As Exception
        End Try
    End Function

    Public Function AddAlertRecipientCC(ByVal ContactCode As Integer, Optional ByVal IgnoreEmailFlag As Boolean = False) As Boolean
        Try
            Dim ReturnValue As Boolean = True
            Dim MaxCurrentAlertRecipients As New vCPAlertRecipientList(Me.ConnectionString)
            Dim oAlerts As New cAlerts(Me.ConnectionString)
            Dim EmailAddress As String = ""
            Dim EmailFlag As Integer = 0

            ' Get next EmpRCPTID 
            MaxCurrentAlertRecipients.Where.ALERT_ID.Value = Me.ALERT_ID
            MaxCurrentAlertRecipients.Query.Load()

            If IgnoreEmailFlag = True Then

                EmailAddress = oAlerts.GetEmail(ContactCode)

            Else

                EmailFlag = oAlerts.GetCPAlertEmailFlag(ContactCode)

                If EmailFlag = 1 Then ' Email Only or Both 

                    EmailAddress = oAlerts.GetEmail(ContactCode)

                End If

            End If


            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim Recipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                Recipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, Me.ALERT_ID, ContactCode)

                If Recipient Is Nothing Then

                    Recipient = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                    Recipient.AlertID = Me.ALERT_ID
                    Recipient.ClientContactID = ContactCode
                    Recipient.AlertRecipientID = MaxCurrentAlertRecipients.RowCount + 1
                    Recipient.EmailAddress = EmailAddress

                    ReturnValue = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, Recipient)

                End If

            End Using

            Return ReturnValue

        Catch ex As Exception
        End Try

    End Function

    Public Overloads Function AddAttachment(ByVal DocumentId As Integer, ByVal UserCode As String, ByVal ClientPortalUserID As Integer) As Boolean
        Try

            If DocumentId > 0 Then

                Dim attachment As New AlertAttachment(Me.ConnectionString)

                attachment.AddNew()
                attachment.ALERT_ID = Me.ALERT_ID
                attachment.DOCUMENT_ID = DocumentId
                attachment.GENERATED_DATE = Date.Now
                attachment.USER_CODE = UserCode
                attachment.EMAILSENT = False

                If ClientPortalUserID > 0 Then attachment.USER_CODE_CP = ClientPortalUserID

                attachment.Save()

                Return True

            Else

                Return False

            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overloads Function AddAttachment(ByVal FileName As String, ByVal MimeType As String, ByVal RepositoryFilename As String,
                                            ByVal FileSize As Integer, ByVal UserCode As String, ByVal ClientPortalUserID As Integer,
                                            ByVal Description As String, ByVal Keywords As String) As Integer
        Try

            Dim Document As New Document(Me.ConnectionString)
            Dim DocumentId As Integer = 0

            DocumentId = Document.Add(FileName, MimeType, RepositoryFilename, FileSize, UserCode, Description, Keywords)

            If DocumentId > 0 Then

                If AddAttachment(DocumentId, UserCode, ClientPortalUserID) = True Then

                    Return DocumentId

                Else

                    Return -1

                End If

            Else

                Return -1

            End If

            Return DocumentId

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Function GetAttachment(ByVal attachmentId As Integer) As AlertAttachment
        Dim attachment As New AlertAttachment(Me.ConnectionString)
        attachment.Where.ATTACHMENT_ID.Value = attachmentId

        Try
            attachment.Query.Load()
            Return attachment
        Catch ex As Exception
            Throw New Exception("Error loading attachment.", ex)
        End Try

    End Function

    Public Function GetRecipientList() As vAlertRecipientList
        Try
            Dim Recipients As New vAlertRecipientList(Me.ConnectionString)
            Recipients.Where.AlertID.Value = Me.ALERT_ID
            Recipients.Query.AddOrderBy(Recipients.ColumnNames.UserName, WhereParameter.Dir.ASC)
            Recipients.Query.Load()

            Return Recipients

        Catch ex As Exception
            Throw New Exception("Error retrieving attachment list.", ex)

        End Try
    End Function

    Public Function GetRecipientListCP() As vCPAlertRecipientList
        Try
            Dim Recipients As New vCPAlertRecipientList(Me.ConnectionString)
            Recipients.Where.ALERT_ID.Value = Me.ALERT_ID
            Recipients.Query.AddOrderBy(Recipients.ColumnNames.CONT_FML, WhereParameter.Dir.ASC)
            Recipients.Query.Load()

            Return Recipients

        Catch ex As Exception
            Throw New Exception("Error retrieving CP recipient list.", ex)

        End Try
    End Function

    Private Function UpdateAttachment(ByVal AlertID As Integer, ByVal AttachmentID As Integer) As String
        Using MyConn As New SqlConnection(Me.ConnectionString)
            Dim MyTrans As SqlTransaction
            MyConn.Open()
            MyTrans = MyConn.BeginTransaction
            Dim MyCmd As New SqlCommand("UPDATE ALERT_ATTACHMENT WITH(ROWLOCK) SET EMAILSENT = 1 WHERE ATTACHMENT_ID = " & AttachmentID & " AND ALERT_ID = " & AlertID, MyConn, MyTrans)
            Try
                MyCmd.ExecuteNonQuery()
                MyTrans.Commit()
                Return ""
            Catch ex As Exception
                MyTrans.Rollback()
                Return ex.Message.ToString()
            Finally
                If MyConn.State = ConnectionState.Open Then MyConn.Close()
            End Try
        End Using
    End Function

    Public Function AlertCheckForDuplicates(ByVal AlertID As Integer, ByVal EmpCode As String) As Boolean
        Try
            Dim myReturnMessage As Integer = 0

            Dim arParams(2) As SqlParameter

            Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
            parameterAlertID.Value = AlertID
            arParams(0) = parameterAlertID

            Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = EmpCode
            arParams(1) = parameterEmpCode

            myReturnMessage = oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_alert_checkforduplicates", arParams)

            If myReturnMessage = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function AlertCPCheckForDuplicates(ByVal AlertID As Integer, ByVal CDP_ID As Integer) As Boolean
        Try
            Dim myReturnMessage As Integer = 0

            Dim arParams(2) As SqlParameter

            Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
            parameterAlertID.Value = AlertID
            arParams(0) = parameterAlertID

            Dim parameterCDP_ID As New SqlParameter("@CDP_ID", SqlDbType.Int)
            parameterCDP_ID.Value = CDP_ID
            arParams(1) = parameterCDP_ID

            myReturnMessage = oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_cp_alert_checkforduplicates", arParams)

            If myReturnMessage = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetMaxAlertRecipientID(ByVal AlertID As Integer)
        Try
            Dim max As Integer
            Dim arParams(1) As SqlParameter

            Dim parameterAlertID As New SqlParameter("@AlertID", SqlDbType.Int)
            parameterAlertID.Value = AlertID
            arParams(0) = parameterAlertID

            max = oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_alert_GetMaxAlertRecipientID", arParams)

            Return max
        Catch ex As Exception

        End Try
    End Function

    Public Function getAlertCategoryDesc(ByVal alert_cat_id As Integer) As String
        Dim SessionKey As String = "getAlertCategoryDesc" & alert_cat_id.ToString()
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim dr As SqlDataReader
                Dim SQL, desc As String
                Dim oSQL As SqlHelper

                SQL = "SELECT ALERT_DESC FROM ALERT_CATEGORY WHERE ALERT_CAT_ID = " & CStr(alert_cat_id)

                Try
                    dr = oSQL.ExecuteReader(CStr(Me.ConnectionString), CommandType.Text, SQL)
                    If dr.HasRows Then
                        dr.Read()
                        desc = dr.GetString(0)
                    Else
                        desc = ""
                    End If
                Catch
                    Err.Raise(Err.Number, "Class:Alert Routine:getAlertCategoryDesc", Err.Description)
                Finally
                    dr.Close()
                End Try

            Catch ex As Exception
                ReturnString = ""
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

#End Region
    Public Function getErrMsg()
        Return ErrorString
    End Function
    Public Sub New(Optional ByVal connectionString As String = "")
        If connectionString.Trim() = "" Then
            Me.ConnectionString = HttpContext.Current.Session("ConnString").ToString()
        Else
            Me.ConnectionString = connectionString
        End If
    End Sub
End Class

<Serializable()>
Public Class CalendarSyncSessionObject

    Public Property SessionID As String = ""
    Public Property PhysicalApplicationPath As String = ""

    Private Property _ConnectionString As String = ""
    Private Property _UserCode As String = ""
    Private Property _SecuritySession As AdvantageFramework.Security.Session = Nothing
    Private Property _EmployeeNonTaskID As Integer = 0
    Private Property _EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
    Private Property _IsHoliday As Boolean = False
    Private Property _IsDeleting As Boolean = False
    'Private _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
    'Private _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private _CurrentIdentity As Object = Nothing

    Public Function Sync() As Boolean

        Me.SyncOnSeparateThread()
        'Me.SyncCalendar()

    End Function
    Private Function SyncOnSeparateThread() As Boolean

        Dim SyncThreadStart As New ThreadStart(AddressOf SyncCalendar)
        Dim SyncThread As New Thread(SyncThreadStart)
        SyncThread.Start()

    End Function
    Private Function SyncCalendar() As Boolean

        If MiscFN.IsNTAuth = True Then

            Dim _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
            Dim _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
            _CurrentWindowsIdentity = Me._CurrentIdentity 'System.Security.Principal.WindowsIdentity.GetCurrent()

            _ImpersonationContext = _CurrentWindowsIdentity.Impersonate

            Using _ImpersonationContext

                If _EmployeeNonTask IsNot Nothing Then

                    AdvantageFramework.Calendar.Sync(_ConnectionString, _UserCode, _EmployeeNonTask, _IsHoliday, _IsDeleting, True, True)

                Else

                    AdvantageFramework.Calendar.Sync(_ConnectionString, _UserCode, _EmployeeNonTaskID, _IsHoliday, _IsDeleting, True, True)

                End If

            End Using

            _ImpersonationContext.Undo()

        Else

            If _EmployeeNonTask IsNot Nothing Then

                AdvantageFramework.Calendar.Sync(_ConnectionString, _UserCode, _EmployeeNonTask, _IsHoliday, _IsDeleting, True, False)

            Else

                AdvantageFramework.Calendar.Sync(_ConnectionString, _UserCode, _EmployeeNonTaskID, _IsHoliday, _IsDeleting, True, False)

            End If

        End If

    End Function
    Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String,
                   ByVal SecuritySession As AdvantageFramework.Security.Session,
                   ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)

        _ConnectionString = ConnectionString
        _UserCode = UserCode
        _SecuritySession = SecuritySession
        _EmployeeNonTaskID = EmployeeNonTaskID
        _IsHoliday = IsHoliday
        _IsDeleting = IsDeleting

        '_CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        Me._CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

    End Sub
    Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String,
                   ByVal SecuritySession As AdvantageFramework.Security.Session,
                   ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)

        _ConnectionString = ConnectionString
        _UserCode = UserCode
        _SecuritySession = SecuritySession
        _EmployeeNonTask = EmployeeNonTask
        _IsHoliday = IsHoliday
        _IsDeleting = IsDeleting

        '_CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        Me._CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

    End Sub

End Class

<Serializable()> Public Class EmailSessionObject

    Public Enum EmailType

        SendEmail
        SendAlertEmail

    End Enum

    Public Property AlertId As Integer = 0
    Public Property Subject As String = ""
    Public Property EmployeeCodesToSendEmailTo As String = ""
    Public Property ClientPortalEmailAddressessToSendTo As String = ""
    Public Property AppName As String = ""
    Public Property SupervisorApprovalComment As String = ""
    Public Property ExcludeAttachments As Boolean = False
    Public Property InsertEmailBodyAsAlertDescription As Boolean = False
    Public Property IsClientPortal As Boolean = False
    Public Property IncludeOriginator As Boolean = False
    Public Property ErrorMessage As String = ""
    Public Property MessageExceedsMaximumEmailSize As Boolean = False
    Public Property SessionID As String = ""
    Public Property PhysicalApplicationPath As String = ""
    Public Property ResetAssignedToEmployeeCodeReadFlag As Boolean
    Public Property DocumentID As Integer? = 0
    Private Property _Guid As String = ""
    Private Property _ConnectionString As String = ""
    Private Property _UserCode As String = ""
    Private Property _WebvantageURL As String = ""
    Private Property _ClientPortalURL As String = ""

    'Private _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
    'Private _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private _CurrentIdentity As Object = Nothing
    Public Property ProofingURL As String = ""

    Public Function ToSession() As String

        Me._Guid = "EML" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True, True)
        HttpContext.Current.Session(Me._Guid) = Me
        Return Me._Guid

    End Function
    Public Shared Function FromSession(ByVal Guid As String) As EmailSessionObject

        If HttpContext.Current.Session(Guid) IsNot Nothing Then

            Dim eso As EmailSessionObject = Nothing

            eso = HttpContext.Current.Session(Guid)

            Return eso

        Else

            Return Nothing

        End If

    End Function
    Public Function Send() As Boolean

        Return Me.SendEmailOnSeparateThread()
        'Me.SendEmail()

    End Function
    Public Function SendEmailOnSeparateThread() As Boolean

        Try

            If Me.AlertId > 0 Then

                ''Webvantage.SignalR.Classes.NotificationHub.NotifyRecipients(AlertId, Me._ConnectionString, Me._UserCode)

            End If

        Catch ex As Exception
        End Try

        Dim EmailThreadStart As New ParameterizedThreadStart(AddressOf SendEmail)
        Dim EmailThread As New Thread(EmailThreadStart)

        Try

            EmailThread.CurrentCulture = LoGlo.GetCultureInfo
            EmailThread.CurrentUICulture = LoGlo.GetCultureInfo

        Catch ex As Exception
        End Try

        EmailThread.Start()

        Return True

    End Function
    Private Function SendEmail() As Boolean

        Dim Sent As Boolean = False

        Try

            Me.EmployeeCodesToSendEmailTo = MiscFN.CleanStringForSplit(Me.EmployeeCodesToSendEmailTo, ",")
            Me.ClientPortalEmailAddressessToSendTo = MiscFN.CleanStringForSplit(Me.ClientPortalEmailAddressessToSendTo, ",")

            If MiscFN.IsNTAuth = True Then

                Dim _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
                Dim _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
                _CurrentWindowsIdentity = Me._CurrentIdentity 'System.Security.Principal.WindowsIdentity.GetCurrent()
                _ImpersonationContext = _CurrentWindowsIdentity.Impersonate

                Using _ImpersonationContext

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                        Dim alrt As New AdvantageFramework.Database.Entities.Alert
                        alrt = Nothing
                        alrt = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertId)

                        If Not alrt Is Nothing Then

                            Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Me._ConnectionString, Me._UserCode,
                                                                                         alrt, Me.Subject, Me.EmployeeCodesToSendEmailTo, Me.ClientPortalEmailAddressessToSendTo,
                                                                                         Me.AppName, Me.SupervisorApprovalComment, Me.ExcludeAttachments, Me.InsertEmailBodyAsAlertDescription, Me.IsClientPortal,
                                                                                         Me.IncludeOriginator,
                                                                                         Me._WebvantageURL,
                                                                                         Me._ClientPortalURL, Me.ErrorMessage,
                                                                                         Me.ResetAssignedToEmployeeCodeReadFlag, True, "",
                                                                                         DocumentID, ProofingURL)


                        End If

                    End Using

                End Using

                _ImpersonationContext.Undo()

            Else

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                    Dim user As AdvantageFramework.Security.Database.Entities.User = Nothing

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me._ConnectionString, Me._UserCode)
                        user = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Me._UserCode)
                    End Using

                    Dim alrt As New AdvantageFramework.Database.Entities.Alert
                    alrt = Nothing
                    alrt = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertId)

                    If Not alrt Is Nothing Then

                        If MiscFN.IsClientPortal And user Is Nothing Then

                            Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Me._ConnectionString, Me._UserCode, alrt, Me.Subject, Me.EmployeeCodesToSendEmailTo, Me.ClientPortalEmailAddressessToSendTo,
                                                                                     Me.AppName, Me.SupervisorApprovalComment, Me.ExcludeAttachments, Me.InsertEmailBodyAsAlertDescription, Me.IsClientPortal,
                                                                                     Me.IncludeOriginator,
                                                                                     Me._WebvantageURL, Me._ClientPortalURL, Me.ErrorMessage,
                                                                                     Me.ResetAssignedToEmployeeCodeReadFlag, True, "", DocumentID, ProofingURL)

                        Else

                            Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Me._ConnectionString, Me._UserCode, alrt, Me.Subject, Me.EmployeeCodesToSendEmailTo, Me.ClientPortalEmailAddressessToSendTo,
                                                                                         Me.AppName, Me.SupervisorApprovalComment, Me.ExcludeAttachments, Me.InsertEmailBodyAsAlertDescription, Me.IsClientPortal,
                                                                                         Me.IncludeOriginator,
                                                                                         Me._WebvantageURL, Me._ClientPortalURL, Me.ErrorMessage,
                                                                                         Me.ResetAssignedToEmployeeCodeReadFlag, True, user.EmployeeCode, DocumentID, ProofingURL)

                        End If



                    End If

                End Using

            End If

            If Sent = False Then

                Me.ErrorMessage = Me.ErrorMessage

            Else

                If Me.ErrorMessage.ToString().Contains("Message exceeds maximum email size") Then

                    Sent = False

                End If

            End If

        Catch ThreadAbortEx As ThreadAbortException

            Sent = False
            Me.ErrorMessage = ThreadAbortEx.Message.ToString() & Environment.NewLine & ThreadAbortEx.InnerException.Message.ToString()

        Catch ex As Exception

            Sent = False
            Me.ErrorMessage = ex.Message.ToString() & Environment.NewLine & ex.InnerException.Message.ToString()

        Finally

            If Sent = True Then

                Me.ErrorMessage = ""

            Else

                Me.ErrorMessage = "Error sending email:  " & Me.ErrorMessage

                AdvantageFramework.Security.AddWebvantageEventLog(Me.ErrorMessage, Diagnostics.EventLogEntryType.Error)

                'Dim AsyncError As New AsyncErrorMessage()
                'AsyncError.SessionID = Me._UserCode
                'AsyncError.PhysicalApplicationPath = Me.PhysicalApplicationPath

                'AsyncError.Create(Me.ErrorMessage)

                Webvantage.SignalR.Classes.NotificationHub.MessageUser(Me._UserCode, Me.ErrorMessage)

            End If

        End Try

        Return Sent

    End Function
    Private Sub Discard()

        If Not HttpContext.Current.Session(Me._Guid) Is Nothing Then

            HttpContext.Current.Session(Me._Guid) = Nothing

        End If

    End Sub

    'Sub New()
    'End Sub

    Sub New(ByVal ConnectionString As String, ByVal UserCode As String,
            ByVal SecuritySession As AdvantageFramework.Security.Session,
            ByVal WebvantageURL As String, ByVal ClientPortalURL As String)

        Me._ConnectionString = ConnectionString
        Me._UserCode = UserCode
        'Me._SecuritySession = SecuritySession
        Me._WebvantageURL = WebvantageURL
        Me._ClientPortalURL = ClientPortalURL

        Me.ResetAssignedToEmployeeCodeReadFlag = True

        'Me._CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        Me._CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

    End Sub

End Class

<Serializable()>
Public Class EmailWithDocumentsSessionObject

    'Public Property IsNTAuth As Boolean = False
    Public Property BaseMessageIsOverSizedMessage As String = "Message exceeds maximum email size."
    Public Property strFileName As String = ""
    Public Property strTo As String = ""
    Public Property strSubject As String = ""
    Public Property strBody As String = ""
    Public Property [Priority] As Integer = 3
    Public Property DocLinkList As System.Collections.Generic.List(Of Integer)
    Public Property strFileNameJS As String = ""
    Public Property strCCList As String = ""
    Public Property strBCCList As String = ""
    Public Property strCCListDelimiter As String = ","
    Public Property strBCCListDelimiter As String = ","
    Public Property strFileNameJV As String = ""
    Public Property strFileNameEST As String = ""
    Public Property combine As Integer = 0
    Public Property strFileNameCB As String = ""
    Public Property AlertId As Integer = 0
    Public Property strFileNamePS As String = ""
    Public Property ErrorMessage As String = ""

    Public Property DocumentIdList As Generic.List(Of Integer)

    Public Property SessionID As String = ""
    Public Property PhysicalApplicationPath As String = ""
    Public Property Guid As String = ""
    Public Property ConnectionString As String = ""
    Public Property UserCode As String = ""
    Public Property EmployeeCode As String = ""
    Public Property ClientPortalUserID As Integer = 0

    'Private _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
    'Private _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private _CurrentIdentity As Object = Nothing

    Public Function Send() As Boolean

        Me.SendEmailOnSeparateThread()
        'Me.SendEmail()

    End Function

    Private Function SendEmailOnSeparateThread() As Boolean

        Try

            If Me.AlertId > 0 Then

                ''Webvantage.SignalR.Classes.NotificationHub.NotifyRecipients(AlertId, Me._ConnectionString, Me._UserCode)

            End If

        Catch ex As Exception
        End Try

        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf SendEmail))

        'Dim EmailThreadStart As New ParameterizedThreadStart(AddressOf SendEmail)
        'Dim EmailThread As New Thread(EmailThreadStart)
        'EmailThread.Start()

    End Function
    Private Function SendEmail() As Boolean

        If MiscFN.IsNTAuth = True Then

            Dim _ImpersonationContext As System.Security.Principal.WindowsImpersonationContext
            Dim _CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
            _CurrentWindowsIdentity = Me._CurrentIdentity 'System.Security.Principal.WindowsIdentity.GetCurrent()

            _ImpersonationContext = _CurrentWindowsIdentity.Impersonate

            Using _ImpersonationContext

                Return _SendEmail()

            End Using

            _ImpersonationContext.Undo()

        Else

            Return _SendEmail()

        End If

    End Function
    Private Function _SendEmail() As Boolean

        Dim ErrorString As String = ""
        Dim Success As Boolean = True
        Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

        Try
            If strTo.Trim() = "" Then Return True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.ConnectionString, Me.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.ConnectionString, Me.UserCode)

                    Dim Agency As AdvantageFramework.Database.Entities.Agency

                    Agency = Nothing
                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        Dim strFrom As String = String.Empty
                        Dim x As Integer
                        Dim arrayTo As Boolean = True
                        Dim arrayCc As Boolean = True
                        Dim arrayBcc As Boolean = True
                        Dim toArray() As String
                        Dim ccArray() As String
                        Dim bccArray() As String
                        Dim boolMisc As Boolean = False
                        Dim SMTPUsername As String = String.Empty
                        Dim SMTPPassword As String = String.Empty
                        Dim ReplyTo As String = String.Empty

                        SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                        If ClientPortalUserID > 0 Then

                            boolMisc = AdvantageFramework.Email.LoadSMTPSettings(DbContext, SecurityDbContext, Agency, SMTPUsername, SMTPPassword, strFrom, ReplyTo, True, ClientPortalUserID)

                        Else

                            boolMisc = AdvantageFramework.Email.LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, SMTPUsername, SMTPPassword, strFrom, ReplyTo)

                        End If

                        If boolMisc = False Then

                            ErrorString = "Error collecting SMTP database data."
                            Return False

                        End If

                        MailBee.Global.SafeMode = True

                        Dim MailBeeSmtp As MailBee.SmtpMail.Smtp = Nothing
                        MailBeeSmtp = Nothing

                        MailBeeSmtp = AdvantageFramework.Email.CreateMailBeeSMTP(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer, SMTPSettings.SMTPPortNumber, SMTPUsername, SMTPPassword, SMTPSettings.SMTPSecureType)

                        If MailBeeSmtp IsNot Nothing Then

                            strTo = MiscFN.CleanStringForSplit(strTo, ",", False, True, True, True, True)
                            strCCList = MiscFN.CleanStringForSplit(strCCList, ",", False, True, True, True, True)
                            strBCCList = MiscFN.CleanStringForSplit(strBCCList, ",", False, True, True, True, True)

                            If strTo <> "" And strTo.Contains(",") = True Then

                                toArray = strTo.Split(",")

                            ElseIf strTo <> "" Then

                                If AdvantageFramework.Email.IsValidEmailAddress(strTo) = False Then

                                    ErrorString = "Invalid Send To email address"
                                    Success = False

                                End If

                                arrayTo = False

                            Else

                                arrayTo = False

                            End If

                            If strCCList <> "" And strCCList.Contains(",") Then

                                ccArray = strCCList.Split(",")

                            ElseIf strCCList <> "" Then

                                If AdvantageFramework.Email.IsValidEmailAddress(strCCList) = False Then

                                    ErrorString = "Invalid CC email address"
                                    Success = False

                                End If

                                arrayCc = False

                            Else

                                arrayCc = False

                            End If
                            If strBCCList <> "" And strBCCList.Contains(",") Then

                                bccArray = strBCCList.Split(",")

                            ElseIf strBCCList <> "" Then

                                If AdvantageFramework.Email.IsValidEmailAddress(strBCCList) = False Then

                                    ErrorString = "Invalid BCC email address"
                                    Return False

                                End If

                                arrayBcc = False

                            Else

                                arrayBcc = False

                            End If
                            If arrayTo = True Then

                                If toArray.Length > 0 Then

                                    For x = 0 To toArray.Length - 1

                                        If AdvantageFramework.Email.IsValidEmailAddress(toArray(x).ToString().Trim()) = False Then

                                            ErrorString = "Invalid email address"
                                            Success = False

                                        End If

                                    Next

                                End If

                            End If
                            If arrayCc = True Then

                                If ccArray.Length > 0 Then

                                    For x = 0 To ccArray.Length - 1

                                        If AdvantageFramework.Email.IsValidEmailAddress(ccArray(x).ToString().Trim()) = False Then

                                            ErrorString = "Invalid CC address"
                                            Success = False

                                        End If

                                    Next

                                End If

                            End If
                            If arrayBcc = True Then

                                If bccArray.Length > 0 Then

                                    For x = 0 To bccArray.Length - 1

                                        If AdvantageFramework.Email.IsValidEmailAddress(bccArray(x).ToString().Trim()) = False Then

                                            ErrorString = "Invalid BCC address"
                                            Success = False

                                        End If

                                    Next

                                End If

                            End If

                            Dim boolHasAttachment As Boolean = False
                            Dim emp As New cEmployee(Me.ConnectionString)
                            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact

                            If MiscFN.IsClientPortal = True Then

                                ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, Me.ClientPortalUserID)

                                If ClientContact Is Nothing Then

                                    MailBeeSmtp.Message.From.AsString = SMTPUsername

                                Else

                                    If Agency.UseEmployeeEmail = 1 Then

                                        MailBeeSmtp.Message.From.AsString = ClientContact.FullNameFML & " <" & SMTPUsername & ">"

                                    Else

                                        MailBeeSmtp.Message.From.AsString = SMTPUsername

                                    End If

                                End If

                            Else

                                MailBeeSmtp.Message.From.AsString = emp.GetFromAddress(Me.EmployeeCode)

                            End If

                            MailBeeSmtp.Message.To.AsString = strTo
                            MailBeeSmtp.Message.Subject = strSubject
                            MailBeeSmtp.Message.ReplyTo.AsString = ReplyTo

                            Try

                                Dim a As New cAlerts(Me.UserCode, Me.EmployeeCode, Me.ConnectionString)
                                a.SetPriority(MailBeeSmtp, [Priority])

                            Catch ex As Exception
                                MailBeeSmtp.Message.Priority = MailPriority.Normal
                            End Try

                            If AlertId = 0 Then

                                Try

                                    If String.IsNullOrWhiteSpace(strFileName) = False Then

                                        boolHasAttachment = True
                                        MailBeeSmtp.AddAttachment(strFileName)

                                    End If
                                    If String.IsNullOrWhiteSpace(strFileNameJS) = False Then

                                        boolHasAttachment = True
                                        MailBeeSmtp.AddAttachment(strFileNameJS)

                                    End If
                                    If String.IsNullOrWhiteSpace(strFileNameJV) = False Then

                                        boolHasAttachment = True
                                        MailBeeSmtp.AddAttachment(strFileNameJV)

                                    End If
                                    If String.IsNullOrWhiteSpace(strFileNameEST) = False Then

                                        boolHasAttachment = True

                                        If combine = 1 Then

                                            MailBeeSmtp.AddAttachment(strFileNameEST)

                                        Else

                                            Dim files() As String = strFileNameEST.Split(",")

                                            For p As Integer = 0 To files.Length - 1

                                                MailBeeSmtp.AddAttachment(files(p))

                                            Next

                                        End If

                                    End If
                                    If String.IsNullOrWhiteSpace(strFileNameCB) = False Then

                                        boolHasAttachment = True
                                        MailBeeSmtp.AddAttachment(strFileNameCB)

                                    End If
                                    If String.IsNullOrWhiteSpace(strFileNamePS) = False Then

                                        boolHasAttachment = True
                                        MailBeeSmtp.AddAttachment(strFileNamePS)

                                    End If
                                Catch ex As Exception

                                    ErrorString = ex.Message
                                    Success = False

                                End Try

                            End If

                            Dim DocumentRepository As New DocumentRepository(Me.ConnectionString)
                            Dim oAgency As New cAgency(Me.ConnectionString)
                            Dim Document As New Document(Me.ConnectionString)
                            Dim BoolHasLinksHeader As Boolean = False
                            Dim HTMLNewLine As String = "<br/>"
                            Dim sb As New System.Text.StringBuilder

                            If AlertId = 0 Then

                                Try

                                    If Not DocLinkList Is Nothing Then

                                        For Each l As Integer In DocLinkList

                                            Document.Where.DOCUMENT_ID.Value = l

                                            If Document.Query.Load() = True Then

                                                If Document.MIME_TYPE = "URL" Then

                                                    If BoolHasLinksHeader = False Then

                                                        sb.AppendLine("<b>Attached Links:</b>&nbsp;&nbsp;" & HTMLNewLine)
                                                        BoolHasLinksHeader = True

                                                    End If

                                                    sb.AppendLine("<a href=""" & Document.REPOSITORY_FILENAME & """>" & Document.FILENAME & "</a>" & HTMLNewLine)

                                                Else

                                                    Try

                                                        Dim ByteStream As Byte()

                                                        ByteStream = DocumentRepository.GetDocument(Document.DOCUMENT_ID)
                                                        MailBeeSmtp.Message.Attachments.Add(ByteStream, Document.FILENAME, Nothing, Document.MIME_TYPE, Nothing,
                                                                                MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)

                                                        If Not ByteStream Is Nothing Then

                                                            ByteStream = Nothing

                                                        End If

                                                        ByteStream = Nothing

                                                    Catch ex As Exception
                                                    End Try

                                                End If

                                                Document = New Document(Me.ConnectionString)

                                            End If

                                        Next

                                    End If

                                Catch ex As Exception
                                End Try
                                Try

                                    If Not DocumentIdList Is Nothing Then

                                        For Each z As Integer In DocumentIdList

                                            Document.Where.DOCUMENT_ID.Value = z

                                            If Document.Query.Load() = True Then

                                                Try

                                                    Dim ByteStream As Byte()

                                                    ByteStream = DocumentRepository.GetDocument(Document.DOCUMENT_ID)
                                                    MailBeeSmtp.Message.Attachments.Add(ByteStream, Document.FILENAME, Nothing, Document.MIME_TYPE, Nothing,
                                                                            MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)

                                                    If Not ByteStream Is Nothing Then

                                                        ByteStream = Nothing

                                                    End If

                                                    ByteStream = Nothing

                                                Catch ex As Exception
                                                End Try

                                                Document = New Document(Me.ConnectionString)

                                            End If

                                        Next

                                    End If

                                Catch ex As Exception
                                End Try

                            End If
                            If AlertId > 0 Then

                                Try

                                    Dim AlertAttachments As New vAlertAttachmentList(Me.ConnectionString)

                                    AlertAttachments.Where.AlertID.Value = AlertId
                                    AlertAttachments.Where.EMAILSENT.Value = False
                                    AlertAttachments.Query.Load()

                                    If Not AlertAttachments Is Nothing Then

                                        Do Until AlertAttachments.EOF

                                            If AlertAttachments.MimeType = "URL" Then

                                                If BoolHasLinksHeader = False Then

                                                    sb.AppendLine("<b>Attached Links:</b>&nbsp;&nbsp;" & HTMLNewLine)
                                                    BoolHasLinksHeader = True

                                                End If

                                                sb.AppendLine("<a href=""" & AlertAttachments.REPOSITORY_FILENAME & """>" & AlertAttachments.RealFileName & "</a>" & HTMLNewLine)

                                            Else

                                                Try

                                                    Dim ByteStream As Byte()
                                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                                    Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

                                                    If MiscFN.IsNTAuth = True Then

                                                        currentWindowsIdentity = Me._CurrentIdentity 'CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                                        impersonationContext = currentWindowsIdentity.Impersonate()

                                                    End If

                                                    ByteStream = DocumentRepository.GetDocument(AlertAttachments.DOCUMENT_ID)

                                                    If MiscFN.IsNTAuth = True Then

                                                        impersonationContext.Undo()

                                                    End If

                                                    MailBeeSmtp.Message.Attachments.Add(ByteStream, AlertAttachments.RealFileName, Nothing, AlertAttachments.MimeType,
                                                                            Nothing, MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64)

                                                    If Not ByteStream Is Nothing Then

                                                        ByteStream = Nothing

                                                    End If

                                                Catch ex As Exception
                                                End Try

                                            End If

                                            AlertAttachments.MoveNext()

                                        Loop

                                    End If

                                Catch ex As Exception
                                End Try

                            End If

                            MailBeeSmtp.Message.BodyHtmlText = strBody & sb.ToString()

                            Try
                                If strCCList <> "" Then

                                    MailBeeSmtp.Message.Cc.AsString = strCCList

                                End If
                            Catch ex As Exception
                                ErrorString = ex.Message
                                Success = False
                            End Try
                            Try
                                If strBCCList <> "" Then

                                    MailBeeSmtp.Message.Bcc.AsString = strBCCList

                                End If
                            Catch ex As Exception
                                ErrorString = ex.Message
                                Success = False
                            End Try
                            Try

                                If MailBeeSmtp.Message.To.AsString = "" AndAlso MailBeeSmtp.Message.Cc.AsString = "" AndAlso MailBeeSmtp.Bcc.AsString = "" Then

                                Else

                                    If Me.MessageIsOverSized(MailBeeSmtp, , ErrorString) = True Then

                                        ErrorMessage = ErrorString
                                        Success = False

                                    End If

                                    boolMisc = MailBeeSmtp.Send()

                                End If
                                If boolMisc = False Then

                                    ErrorString = MailBeeSmtp.GetErrorDescription
                                    Success = False

                                End If

                            Catch ex As Exception
                                ErrorString = ex.Message
                                Success = False
                            End Try
                            Try

                                MailBeeSmtp.Disconnect()

                            Catch ex As Exception
                            End Try
                            Try

                                MailBeeSmtp = Nothing

                            Catch ex As Exception
                            End Try

                        End If

                    End If

                End Using

            End Using

        Catch ThreadAbortEx As ThreadAbortException
            Success = False
            Me.ErrorMessage = ThreadAbortEx.Message.ToString() & Environment.NewLine & ThreadAbortEx.InnerException.Message.ToString()
        Catch ex As Exception
            ErrorString = ex.Message.ToString() & Environment.NewLine & ex.InnerException.Message.ToString()
            Success = False
        End Try
        Try

            If String.IsNullOrWhiteSpace(strFileName) = False Then
                If strFileName <> "" Then
                    Try
                        My.Computer.FileSystem.DeleteFile(strFileName)
                    Catch ex As Exception
                    End Try
                End If
            End If
            If String.IsNullOrWhiteSpace(strFileNameJS) = False Then
                If strFileNameJS <> "" Then
                    Try
                        My.Computer.FileSystem.DeleteFile(strFileNameJS)
                    Catch ex As Exception
                    End Try
                End If
            End If
            If String.IsNullOrWhiteSpace(strFileNameJV) = False Then
                If strFileNameJV <> "" Then
                    Try
                        My.Computer.FileSystem.DeleteFile(strFileNameJV)
                    Catch ex As Exception
                    End Try
                End If
            End If
            If String.IsNullOrWhiteSpace(strFileNameEST) = False Then
                If strFileNameEST.IndexOf(",") > -1 Then
                    Dim files() As String = strFileNameEST.Split(",")
                    For j As Integer = 0 To files.Length - 1
                        Try
                            My.Computer.FileSystem.DeleteFile(files(j).Trim())
                        Catch ex As Exception
                        End Try
                    Next
                Else
                    Try
                        My.Computer.FileSystem.DeleteFile(strFileNameEST)
                    Catch ex As Exception
                    End Try
                End If
            End If
            If String.IsNullOrWhiteSpace(strFileNameCB) = False Then
                Try
                    My.Computer.FileSystem.DeleteFile(strFileNameCB)
                Catch ex As Exception
                End Try
            End If
            If String.IsNullOrWhiteSpace(strFileNamePS) = False Then
                Try
                    My.Computer.FileSystem.DeleteFile(strFileNamePS)
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
        End Try

        If Success = False Then

            Me.ErrorMessage = ErrorString

            If Me.ErrorMessage.Trim() <> "" Then

                Me.ErrorMessage = "Error sending email:  " & Me.ErrorMessage

                AdvantageFramework.Security.AddWebvantageEventLog(Me.ErrorMessage, Diagnostics.EventLogEntryType.Error)

                'Dim AsyncError As New AsyncErrorMessage()
                'AsyncError.SessionID = Me.UserCode
                'AsyncError.PhysicalApplicationPath = Me.PhysicalApplicationPath

                'AsyncError.Create(Me.ErrorMessage)

            End If

        End If

    End Function

    Public Function MessageIsOverSized(ByRef Smtp As MailBee.SmtpMail.Smtp, Optional ByVal ClearAttachments As Boolean = True, Optional ByRef Message As String = "") As Boolean

        Dim MaxEmailSize As Long = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(Me.ConnectionString, Me.UserCode)

            MaxEmailSize = AdvantageFramework.Email.LoadMaxEmailSize(DbContext)

        End Using

        If MaxEmailSize > 0 AndAlso Smtp.Message.Size > MaxEmailSize Then

            Message = BaseMessageIsOverSizedMessage

            If ClearAttachments = True Then

                Smtp.Message.Attachments.Clear()
                Message &= "  Attachments were excluded but the email was still sent."

            End If

            Return True

        Else

            Message = ""
            Return False

        End If

    End Function

    Public Sub New()

        '_CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
        Me._CurrentIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

    End Sub

End Class
