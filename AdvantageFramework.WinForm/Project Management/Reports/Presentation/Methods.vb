Namespace ProjectManagement.Reports.Presentation

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

        Public Function CreateSMTP(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                   Agency As AdvantageFramework.Database.Entities.Agency,
                                   ByRef [From] As String, ByRef ReplyTo As String) As MailBee.SmtpMail.Smtp

            'objects
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim SMTPSettings As AdvantageFramework.Email.Classes.SMTPSettings = Nothing

            Try

                SMTPSettings = New AdvantageFramework.Email.Classes.SMTPSettings(DbContext, Agency, False)

                If AdvantageFramework.Email.LoadSMTPSettings(DbContext, SecurityDbContext, SMTPSettings, UserName, Password, [From], ReplyTo) Then

                    SMTP = AdvantageFramework.Email.CreateMailBeeSMTP(Agency.MailBeeLicenseKey, SMTPSettings.SMTPAuthMethod, SMTPSettings.SMTPServer,
                                                                      SMTPSettings.SMTPPortNumber, UserName, Password, SMTPSettings.SMTPSecureType)

                    If SMTP.Connect = False Then

                        SMTP = Nothing

                    End If

                End If

            Catch ex As Exception
                SMTP = Nothing
            Finally
                CreateSMTP = SMTP
            End Try

        End Function
        Public Function SendEmail(SMTP As MailBee.SmtpMail.Smtp, [To] As String, Subject As String, Body As String, Priority As Integer,
                                  Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment), ByRef SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus,
                                  Agency As AdvantageFramework.Database.Entities.Agency, SenderName As String, [From] As String, ByRef ReplyTo As String, MaxEmailSize As Long) As Boolean

            'objects
            Dim EmailSent As Boolean = False
            Dim AttachmentsAdded As Boolean = True
            Dim HasAttachment As Boolean = False
            Dim Impersonating As Boolean = False
            Dim DecrpytedPassword As String = ""

            Try

                SMTP.ResetMessage()

                SMTP.Message.From.AsString = From

                If String.IsNullOrWhiteSpace(SenderName) = False Then

                    SMTP.Message.From.DisplayName = SenderName

                End If

                SMTP.Message.ReplyTo.AsString = ReplyTo

                SMTP.Message.To.AsString = [To]

                SMTP.Message.Subject = Subject

                SMTP.Message.BodyHtmlText = Body

                AdvantageFramework.Email.SetPriority(SMTP, Priority)

                If Attachments IsNot Nothing AndAlso Attachments.Any Then

                    HasAttachment = True

                    DecrpytedPassword = AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword)

                    If Agency.FileSystemUserName <> "" AndAlso Agency.FileSystemDomain <> "" AndAlso DecrpytedPassword <> "" Then

                        AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, DecrpytedPassword)
                        Impersonating = True

                    End If

                    For Each Attachment In Attachments

                        If String.IsNullOrEmpty(Attachment.File) = False Then

                            Try

                                If String.IsNullOrWhiteSpace(Attachment.AttachmentName) = False Then

                                    If SMTP.Message.Attachments.Add(Attachment.File, Attachment.AttachmentName, Nothing) = False Then

                                        AttachmentsAdded = False

                                    End If

                                Else

                                    If SMTP.AddAttachment(Attachment.File) = False Then

                                        AttachmentsAdded = False

                                    End If

                                End If

                            Catch ex As Exception
                                AttachmentsAdded = False
                            End Try

                        ElseIf Attachment.FileBytes IsNot Nothing Then

                            Try

                                SMTP.Message.Attachments.Add(Attachment.FileBytes,
                                                                Attachment.AttachmentName,
                                                                Nothing, Nothing, Nothing, MailBee.Mime.NewAttachmentOptions.ReplaceIfExists, MailBee.Mime.MailTransferEncoding.Base64)

                            Catch ex As Exception
                                AttachmentsAdded = False
                            End Try

                        Else

                            AttachmentsAdded = False

                        End If

                    Next

                    AdvantageFramework.Email.CheckEmailSize(SMTP, MaxEmailSize, AttachmentsAdded)

                    If Impersonating = True Then

                        AdvantageFramework.Security.Impersonate.EndImpersonation()

                    End If

                Else

                    AttachmentsAdded = False

                End If

                If SMTP.Send() Then

                    If HasAttachment Then

                        If AttachmentsAdded Then

                            SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent

                        Else

                            SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSentWithoutAttachment

                        End If

                    Else

                        SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent

                    End If

                    EmailSent = True

                Else

                    SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToSend

                End If

            Catch ex As Exception
                EmailSent = False
            End Try

            SendEmail = EmailSent

        End Function
        Public Sub PrintEstimates(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                                 EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False
            Dim PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings = Nothing
            Dim XtraReports As Generic.List(Of DevExpress.XtraReports.UI.XtraReport) = Nothing

            PrintSettings = New AdvantageFramework.Estimate.Classes.PrintSettings
            XtraReports = New Generic.List(Of DevExpress.XtraReports.UI.XtraReport)

            If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingPrintDialog.ShowFormDialog(PrintSettings, True, False) = Windows.Forms.DialogResult.OK Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                        End Using
                    End Using

                    Dim quotes As String = ""
                    Dim qtedesc As String = ""
                    Dim qtedescs As String = ""
                    Dim comps As String = ""
                    Dim qte As Integer = 0
                    Dim comp As Integer = 0
                    Dim count As Integer = 0
                    Dim est As Integer = 0
                    Dim estcomp As String = ""
                    Dim ClCodeString As String = ""

                    Dim estCount As Integer = 0

                    For Each EstimateQuote In EstimateQuotes

                        If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                            End If
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                            End If
                        ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                        Else
                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                        End If

                        If EstimatePrintingSetting IsNot Nothing Then
                            If EstimatePrintingSetting.SummaryLevel = 2 Then
                                If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber <> 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                    End If

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        Report.DisplayName = DefaultFileName
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        XtraReports.Add(Report)

                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            Else
                                If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber = 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    End If

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        Report.DisplayName = DefaultFileName
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        XtraReports.Add(Report)

                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            End If

                            Try
                                est = EstimateQuote.EstimateNumber
                                comp = EstimateQuote.EstimateComponentNumber
                                estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                qte = EstimateQuote.QuoteNumber
                                If EstimateQuote.QuoteDesc IsNot Nothing Then
                                    qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                End If
                            Catch ex As Exception
                                qte = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            count += 1
                            estCount += 1

                            If estCount = EstimateQuotes.Count Then

                                If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                    End If
                                ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                End If

                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If

                                _EstimateQuote = EstimateQuote

                                CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.JobNumber <> 0 Then
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                Else
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                End If

                                If Report IsNot Nothing Then

                                    Report.CreateDocument()

                                    Report.DisplayName = DefaultFileName
                                    Report.Name = Report.DisplayName

                                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                    End If

                                    XtraReports.Add(Report)

                                End If

                            End If
                        Else

                            _EstimateQuote = EstimateQuote

                            EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                            CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote)

                            If EstimateQuote.ClientCode <> "" Then
                                ClCodeString = "_" & EstimateQuote.ClientCode
                            End If

                            If EstimateQuote.JobNumber = 0 Then
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            Else
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            End If

                            If Report IsNot Nothing Then

                                Report.CreateDocument()

                                Report.DisplayName = DefaultFileName
                                Report.Name = Report.DisplayName

                                If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                    Report.PrintingSystem.Document.Name = Report.DisplayName

                                End If

                                XtraReports.Add(Report)

                            End If

                        End If

                    Next

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    If XtraReports.Count > 1 Then

                        AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReports, UserLookAndFeel)

                    ElseIf XtraReports.Count = 1 Then

                        AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReports.FirstOrDefault, True, UserLookAndFeel, False, False)

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed.")

            End If

        End Sub
        Public Sub QuickPrintEstimates(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                                      EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False
            Dim PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings = Nothing

            PrintSettings = New AdvantageFramework.Estimate.Classes.PrintSettings

            If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingPrintDialog.ShowFormDialog(PrintSettings, True, False) = Windows.Forms.DialogResult.OK Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                        End Using
                    End Using

                    Dim quotes As String = ""
                    Dim qtedesc As String = ""
                    Dim qtedescs As String = ""
                    Dim comps As String = ""
                    Dim qte As Integer = 0
                    Dim comp As Integer = 0
                    Dim count As Integer = 0
                    Dim est As Integer = 0
                    Dim estcomp As String = ""
                    Dim ClCodeString As String = ""

                    Dim estCount As Integer = 0

                    For Each EstimateQuote In EstimateQuotes

                        If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                            End If
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                            End If
                        ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                        Else
                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                        End If

                        If EstimatePrintingSetting IsNot Nothing Then
                            If EstimatePrintingSetting.SummaryLevel = 2 Then
                                If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber <> 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                    End If

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        Report.DisplayName = DefaultFileName
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            Else
                                If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber = 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    End If

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        Report.DisplayName = DefaultFileName
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            End If

                            Try
                                est = EstimateQuote.EstimateNumber
                                comp = EstimateQuote.EstimateComponentNumber
                                estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                qte = EstimateQuote.QuoteNumber
                                If EstimateQuote.QuoteDesc IsNot Nothing Then
                                    qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                End If
                            Catch ex As Exception
                                qte = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            count += 1
                            estCount += 1

                            If estCount = EstimateQuotes.Count Then

                                If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                    End If
                                ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                End If

                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If

                                _EstimateQuote = EstimateQuote

                                CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.JobNumber <> 0 Then
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                Else
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                End If

                                If Report IsNot Nothing Then

                                    Report.CreateDocument()

                                    Report.DisplayName = DefaultFileName
                                    Report.Name = Report.DisplayName

                                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                    End If

                                    AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                End If

                            End If
                        Else

                            _EstimateQuote = EstimateQuote

                            EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                            CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote)

                            If EstimateQuote.ClientCode <> "" Then
                                ClCodeString = "_" & EstimateQuote.ClientCode
                            End If

                            If EstimateQuote.JobNumber = 0 Then
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            Else
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            End If

                            If Report IsNot Nothing Then

                                Report.CreateDocument()

                                Report.DisplayName = DefaultFileName
                                Report.Name = Report.DisplayName

                                If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                    Report.PrintingSystem.Document.Name = Report.DisplayName

                                End If

                                AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed.")

            End If

        End Sub
        Public Sub SendEstimateEmails(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                                     EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim ErrorMessage As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim [Bcc] As String = Nothing
            Dim EmailSent As Boolean = False
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim ReportExportPath As String = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If EstimatePrintingSendEmailsDialog.ShowFormDialog(EmailSettings) = Windows.Forms.DialogResult.OK AndAlso EmailSettings IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    If EmailSettings.ToRecipients IsNot Nothing AndAlso EmailSettings.ToRecipients.Count > 0 Then

                        [To] = Join(EmailSettings.ToRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If EmailSettings.CCRecipients IsNot Nothing AndAlso EmailSettings.CCRecipients.Count > 0 Then

                        [Cc] = Join(EmailSettings.CCRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If EmailSettings.BCCRecipients IsNot Nothing AndAlso EmailSettings.BCCRecipients.Count > 0 Then

                        [Bcc] = Join(EmailSettings.BCCRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")
                                AgencyImportPath = AgencyImportPath & "Reports\"

                            End If

                        Else

                            Try

                                ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                            Catch ex As Exception
                                ReportExportPath = ""
                            End Try

                            If String.IsNullOrWhiteSpace(ReportExportPath) Then

                                ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                            End If

                            If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

                                AgencyImportPath = ReportExportPath

                            End If

                        End If

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                            End Using

                            Dim quotes As String = ""
                            Dim qtedesc As String = ""
                            Dim qtedescs As String = ""
                            Dim comps As String = ""
                            Dim qte As Integer = 0
                            Dim comp As Integer = 0
                            Dim count As Integer = 0
                            Dim est As Integer = 0
                            Dim estcomp As String = ""
                            Dim ClCodeString As String = ""

                            Dim estCount As Integer = 0

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZip Then


                            ElseIf EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then


                            Else

                                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                ZipFileName = ""

                                For Each EstimateQuote In EstimateQuotes

                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If EstimatePrintingSetting IsNot Nothing Then
                                        If EstimatePrintingSetting.SummaryLevel = 2 Then
                                            If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                                If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                    End If
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                    End If
                                                ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                                Else
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                                End If

                                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                    Exit Sub
                                                End If

                                                _EstimateQuote = EstimateQuotes(estCount - 1)

                                                CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                                If EstimateQuote.ClientCode <> "" Then
                                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                                End If

                                                If EstimateQuote.JobNumber <> 0 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                                End If

                                                If Report IsNot Nothing Then

                                                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                                End If

                                                quotes = ""
                                                qtedescs = ""
                                                count = 0
                                            End If
                                        Else
                                            If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                                If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                                    End If
                                                    If EstimatePrintingSetting Is Nothing Then
                                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                                    End If
                                                ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                                Else
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                                End If

                                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                    Exit Sub
                                                End If

                                                _EstimateQuote = EstimateQuotes(estCount - 1)

                                                CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                                If EstimateQuote.ClientCode <> "" Then
                                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                                End If

                                                If EstimateQuote.JobNumber = 0 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                End If

                                                If Report IsNot Nothing Then

                                                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                                End If

                                                quotes = ""
                                                qtedescs = ""
                                                count = 0
                                            End If
                                        End If

                                        Try
                                            est = EstimateQuote.EstimateNumber
                                            comp = EstimateQuote.EstimateComponentNumber
                                            estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                            qte = EstimateQuote.QuoteNumber
                                            If EstimateQuote.QuoteDesc IsNot Nothing Then
                                                qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                            End If
                                        Catch ex As Exception
                                            qte = 0
                                            qtedesc = ""
                                        End Try
                                        quotes &= qte & ","
                                        qtedescs &= qtedesc & ","
                                        comps &= comp & ","
                                        count += 1
                                        estCount += 1

                                        If estCount = EstimateQuotes.Count Then

                                            If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                                End If
                                                If EstimatePrintingSetting Is Nothing Then
                                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                                End If
                                            ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                            Else
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                            End If

                                            If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                                AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                                Exit Sub
                                            End If

                                            _EstimateQuote = EstimateQuote

                                            CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                            If EstimateQuote.ClientCode <> "" Then
                                                ClCodeString = "_" & EstimateQuote.ClientCode
                                            End If

                                            If EstimateQuote.ClientCode <> "" Then
                                                ClCodeString = "_" & EstimateQuote.ClientCode
                                            End If

                                            If EstimateQuote.JobNumber <> 0 Then
                                                'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                End If
                                            Else
                                                'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                                If EstimatePrintingSetting.SummaryLevel = 2 Then
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                                Else
                                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                                End If
                                            End If

                                            If Report IsNot Nothing Then

                                                AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                            End If

                                        End If
                                    Else

                                        _EstimateQuote = EstimateQuote

                                        EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                                        CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote)

                                        If EstimateQuote.ClientCode <> "" Then
                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                        End If

                                        If EstimateQuote.JobNumber = 0 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                        End If

                                        If Report IsNot Nothing Then

                                            AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                        End If

                                    End If

                                Next

                            End If

                            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Sending...", ParentForm)

                            If Attachments.Count > 0 Then

                                EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], EmailSettings.Subject, EmailSettings.Body, 3, Attachments, SendingEmailStatus, ErrorMessage, False)

                                Try

                                    For Each Attachment In Attachments

                                        If String.IsNullOrWhiteSpace(Attachment.File) = False Then

                                            My.Computer.FileSystem.DeleteFile(Attachment.File)

                                        End If

                                    Next

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                If EmailSent OrElse (Attachments IsNot Nothing AndAlso Attachments.Count = 0) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed and sent.")

                Else

                    If SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent Then

                        AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

                    ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Failed creating or sending estimates.  Please contact software support.")

                    End If

                End If

            End If

        End Sub
        Public Sub PrintToFile(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session,
                               EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                               EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, ByVal ToSingleFile As Boolean,
                               ByVal ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MainReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim IsAgencyASP As Boolean = False
            Dim ClientCodes() As String = Nothing
            Dim AccessReportTempPath As String = Nothing
            Dim PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing



            PrintSettings = New AdvantageFramework.Estimate.Classes.PrintSettings

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            If IsAgencyASP Then

                If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                        My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                    End If

                    PrintSettings.ExportPath = AgencyImportPath & "Reports\"

                End If

            End If

            If AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingPrintDialog.ShowFormDialog(PrintSettings, False, ToSingleFile) = Windows.Forms.DialogResult.OK Then

                If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager Then

                    PrintSettings.SendToDocumentManager = True

                Else

                    PrintSettings.ExportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(PrintSettings.ExportPath.Trim, "\")

                End If

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                        End Using
                    End Using

                    Dim quotes As String = ""
                    Dim qtedesc As String = ""
                    Dim qtedescs As String = ""
                    Dim comps As String = ""
                    Dim qte As Integer = 0
                    Dim comp As Integer = 0
                    Dim count As Integer = 0
                    Dim est As Integer = 0
                    Dim estcomp As String = ""
                    Dim ClCodeString As String = ""

                    Dim estCount As Integer = 0

                    For Each EstimateQuote In EstimateQuotes

                        If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                            End If
                            If EstimatePrintingSetting Is Nothing Then
                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                            End If
                        ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                        Else
                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                        End If

                        If EstimatePrintingSetting IsNot Nothing Then
                            If EstimatePrintingSetting.SummaryLevel = 2 Then
                                If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(MainReport, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber <> 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            Else
                                If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuotes(estCount - 1)

                                    CreateEstimate(MainReport, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber = 0 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    End If

                                    quotes = ""
                                    qtedescs = ""
                                    count = 0
                                End If
                            End If

                            Try
                                est = EstimateQuote.EstimateNumber
                                comp = EstimateQuote.EstimateComponentNumber
                                estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                qte = EstimateQuote.QuoteNumber
                                If EstimateQuote.QuoteDesc IsNot Nothing Then
                                    qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                End If
                            Catch ex As Exception
                                qte = 0
                                qtedesc = ""
                            End Try
                            quotes &= qte & ","
                            qtedescs &= qtedesc & ","
                            comps &= comp & ","
                            count += 1
                            estCount += 1

                            If estCount = EstimateQuotes.Count Then

                                If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                    End If
                                    If EstimatePrintingSetting Is Nothing Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                    End If
                                ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                Else
                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                End If

                                If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                    AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                    Exit Sub
                                End If

                                _EstimateQuote = EstimateQuote

                                CreateEstimate(MainReport, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.JobNumber <> 0 Then
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                Else
                                    'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                    If EstimatePrintingSetting.SummaryLevel = 2 Then
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                    Else
                                        DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                    End If
                                End If

                            End If
                        Else

                            _EstimateQuote = EstimateQuote

                            EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                            CreateEstimate(MainReport, Session, EstimatePrintingSetting, EstimateQuote)

                            If EstimateQuote.ClientCode <> "" Then
                                ClCodeString = "_" & EstimateQuote.ClientCode
                            End If

                            If EstimateQuote.JobNumber = 0 Then
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            Else
                                DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                            End If

                        End If

                    Next

                    If MainReport IsNot Nothing Then

                        DefaultFileName = PrintSettings.ExportPath & DefaultFileName

                        ExportReport(Session, MainReport, DefaultFileName, ToFileOption, False)

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                If ToFileOption = InvoicePrinting.ToFileOptions.DocumentManager Then

                    AdvantageFramework.WinForm.MessageBox.Show("Estimates have been uploaded.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Estimates have been printed.")

                End If

            End If

        End Sub
        Private Sub CreateEstimate(ByRef FullReport As DevExpress.XtraReports.UI.XtraReport, Session As AdvantageFramework.Security.Session, ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting,
                                   ByVal EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote, Optional ByVal Comps As String = "", Optional ByVal Quotes As String = "", Optional ByVal QuoteDescriptions As String = "", Optional ByVal Combine As Integer = 0)

            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim EstimatePrintingDefault As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim datetoprint As DateTime = Nothing

            Try
                If EstimatePrintingSetting Is Nothing Then

                    EstimatePrintingDefault = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Session, EstimateQuote, EstimatePrintingDefault, EstimatePrintingDefault.ReportFormat, EstimateQuote.EstimateComponentNumber.ToString & ",", EstimateQuote.QuoteNumber.ToString & ",")

                Else

                    'Report = AdvantageFramework.Reporting.Reports.CreateEstimate(_Session, _EstimateQuote, EstimatePrintingSetting, _EstimateFormat, _EstimateQuote.EstimateComponentNumber.ToString & ",", _EstimateQuote.QuoteNumber.ToString & ",")
                    FullReport = AdvantageFramework.Reporting.Reports.CreateEstimate(Session, EstimateQuote, EstimatePrintingSetting, EstimatePrintingSetting.ReportFormat, Comps, Quotes, QuoteDescriptions, Combine, datetoprint)

                End If

                If FullReport IsNot Nothing Then

                    FullReport.CreateDocument(True)

                End If
            Catch ex As Exception

            End Try
        End Sub
        Private Sub ExportFiles(Agency As AdvantageFramework.Database.Entities.Agency,
                                ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                ExportPath As String,
                                Report As DevExpress.XtraReports.UI.XtraReport,
                                BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'objects
            Dim DocumentIndex As Integer = 1
            Dim ReportName As String = ""
            Dim InvoiceNumberString As String = ""

            If Agency IsNot Nothing AndAlso AccountReceivableInvoice IsNot Nothing Then

                InvoiceNumberString = CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                If DocumentIndex <> 1 Then

                    DocumentIndex = 1

                End If

                If Report IsNot Nothing Then

                    ReportName = ExportPath & AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        Report.ExportToPdf(ReportName & ".pdf")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        Report.ExportToRtf(ReportName & ".rtf")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        Report.ExportToXls(ReportName & ".xls")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        Report.ExportToXlsx(ReportName & ".xlsx")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        Report.ExportToImage(ReportName & ".png")

                        DocumentIndex += 1

                    End If

                End If

                If BackupReport IsNot Nothing Then

                    ReportName = ExportPath & AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString & " Backup"

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        BackupReport.ExportToPdf(ReportName & ".pdf")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        BackupReport.ExportToRtf(ReportName & ".rtf")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        BackupReport.ExportToXls(ReportName & ".xls")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        BackupReport.ExportToXlsx(ReportName & ".xlsx")

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        BackupReport.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        BackupReport.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        BackupReport.ExportToImage(ReportName & ".png")

                        DocumentIndex += 1

                    End If

                End If

                If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                    ExportDocuments(Agency, ExportPath, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, DocumentIndex, AccountReceivableInvoice)

                End If

            End If

        End Sub
        Private Sub ExportDocuments(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ExportPath As String,
                                    ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), DocumentIndex As Integer,
                                    AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim Links As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim InvoiceNumberString As String = ""
            Dim FileWriter As System.IO.FileStream = Nothing

            Try

                If Agency IsNot Nothing AndAlso AccountReceivableInvoice IsNot Nothing AndAlso Documents IsNot Nothing Then

                    InvoiceNumberString = CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    SaveAsFileName = ExportPath & AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString & " " & Document.FileName

                                    Try

                                        FileWriter = New System.IO.FileStream(SaveAsFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write)
                                        FileWriter.Write(ByteFile, 0, ByteFile.Length)

                                    Catch ex As Exception

                                    End Try

                                    If FileWriter IsNot Nothing Then

                                        FileWriter.Close()

                                    End If

                                    DocumentIndex = DocumentIndex + 1

                                End If

                            Else

                                Links &= Document.Description & vbTab & "[" & Document.FileSystemFileName & "]" & vbNewLine

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If String.IsNullOrEmpty(Links) = False Then

                        My.Computer.FileSystem.WriteAllText(ExportPath & AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString & " " & "Links.txt", Links, False)

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ExportReport(Session As AdvantageFramework.Security.Session, Report As DevExpress.XtraReports.UI.XtraReport, FileName As String,
                                 ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions, IsBackup As Boolean,
                                 Optional ByVal AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileSystemFile As String = Nothing
            Dim FileSystemFileName As String = Nothing
            Dim FileSize As Integer = Nothing
            Dim MimeType As String = Nothing
            Dim FinalLevelDescription As String = Nothing
            Dim FinalLevel As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim AccountReceivableDocument As AdvantageFramework.Database.Entities.AccountReceivableDocument = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = ""

            If Report IsNot Nothing Then

                If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                    Report.ExportToPdf(FileName & ".pdf")

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                    Report.ExportToRtf(FileName & ".rtf")

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                    Report.ExportToXls(FileName & ".xls")

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                    Report.ExportToXlsx(FileName & ".xls")

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                    Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                    Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                    Report.ExportToImage(FileName & ".png")

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing AndAlso AccountReceivableInvoice IsNot Nothing Then

                            FileName = FileName & ".pdf"

                            Try

                                For Each ARD In AdvantageFramework.Database.Procedures.AccountReceivableDocument.LoadRelated(DbContext, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber,
                                                                                                                            AccountReceivableInvoice.InvoiceType, FileName).ToList

                                    If AdvantageFramework.DocumentManager.DeleteAccountReceivableInvoiceDocument(DbContext, ARD.DocumentID) Then

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, ARD.DocumentID)

                                        If Document IsNot Nothing Then

                                            DbContext.DeleteEntityObject(Document)

                                            Try

                                                DbContext.SaveChanges()

                                            Catch ex As Exception
                                                IsValid = False
                                            End Try

                                            If IsValid Then

                                                If AdvantageFramework.FileSystem.Delete(Agency, Document.FileSystemFileName) = False Then

                                                    IsValid = False

                                                End If

                                            Else

                                                IsValid = False

                                            End If

                                        End If

                                    Else

                                        IsValid = False

                                    End If

                                Next

                                If IsValid Then

                                    IsValid = AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage)

                                End If

                                If IsValid Then

                                    MemoryStream = New System.IO.MemoryStream
                                    Report.ExportToPdf(MemoryStream)

                                    MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(".pdf")
                                    FileSize = MemoryStream.Length
                                    FinalLevelDescription = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice.ToString & ":" & AccountReceivableInvoice.InvoiceNumber
                                    FinalLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice.ToString

                                    If IsBackup Then

                                        If AdvantageFramework.FileSystem.Add(Session, Agency, MemoryStream, FileName, "Backup Report", "Backup Report", Session.UserCode, FinalLevel, FinalLevelDescription, FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName, False) Then

                                            Document = New AdvantageFramework.Database.Entities.Document

                                            Document.DbContext = DbContext
                                            Document.FileName = FileName
                                            Document.FileSystemFileName = FileSystemFileName
                                            Document.MIMEType = MimeType
                                            Document.Description = "Backup Report"
                                            Document.Keywords = "Backup Report"
                                            Document.UploadedDate = System.DateTime.Now
                                            Document.UserCode = Session.UserCode
                                            Document.FileSize = FileSize
                                            Document.DocumentTypeID = 1
                                            Document.IsPrivate = False

                                            If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                                                AccountReceivableDocument.DocumentID = Document.ID
                                                AccountReceivableDocument.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                                AccountReceivableDocument.SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                                AccountReceivableDocument.Type = AccountReceivableInvoice.InvoiceType

                                                AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, AccountReceivableDocument)

                                            End If

                                        End If

                                    Else

                                        If AdvantageFramework.FileSystem.Add(Session, Agency, MemoryStream, FileName, "Invoice", "Invoice", Session.UserCode, FinalLevel, FinalLevelDescription, FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName, False) Then

                                            Document = New AdvantageFramework.Database.Entities.Document

                                            Document.DbContext = DbContext
                                            Document.FileName = FileName
                                            Document.FileSystemFileName = FileSystemFileName
                                            Document.MIMEType = MimeType
                                            Document.Description = "Invoice"
                                            Document.Keywords = "Invoice"
                                            Document.UploadedDate = System.DateTime.Now
                                            Document.UserCode = Session.UserCode
                                            Document.FileSize = FileSize
                                            Document.DocumentTypeID = 1
                                            Document.IsPrivate = False

                                            If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                AccountReceivableDocument = New AdvantageFramework.Database.Entities.AccountReceivableDocument

                                                AccountReceivableDocument.DocumentID = Document.ID
                                                AccountReceivableDocument.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                                AccountReceivableDocument.SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                                AccountReceivableDocument.Type = AccountReceivableInvoice.InvoiceType

                                                AdvantageFramework.Database.Procedures.AccountReceivableDocument.Insert(DbContext, AccountReceivableDocument)

                                            End If

                                        End If

                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                            If MemoryStream IsNot Nothing Then

                                MemoryStream.Dispose()
                                MemoryStream.Close()

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub AddToZipFile(Agency As AdvantageFramework.Database.Entities.Agency,
                                 ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                 ReportName As String,
                                 Report As DevExpress.XtraReports.UI.XtraReport,
                                 BackupReportName As String,
                                 BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                 CoverSheetName As String,
                                 CoverSheet As DevExpress.XtraReports.UI.XtraReport,
                                 DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                 ZipFile As Ionic.Zip.ZipFile,
                                 AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocumentIndex As Integer = 1

            If ZipFile IsNot Nothing Then

                DocumentIndex = ZipFile.Entries.Count

                If DocumentIndex <> 1 Then

                    DocumentIndex = 1

                End If

                If Report IsNot Nothing Then

                    MemoryStream = New System.IO.MemoryStream

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        Report.ExportToPdf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False) & ".pdf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".pdf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        Report.ExportToRtf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False) & ".rtf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".rtf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        Report.ExportToXls(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False) & ".xls", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".xls", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        Report.ExportToXlsx(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False) & ".xlsx", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".xlsx", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        Report.ExportToImage(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False) & ".png", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".png", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    End If

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                    Catch ex As Exception

                    End Try

                    MemoryStream = Nothing

                End If

                If BackupReport IsNot Nothing Then

                    MemoryStream = New System.IO.MemoryStream

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        BackupReport.ExportToPdf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, True) & ".pdf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(BackupReportName & ".pdf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        BackupReport.ExportToRtf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, True) & ".rtf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(BackupReportName & ".rtf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        BackupReport.ExportToXls(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, True) & ".xls", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(BackupReportName & ".xls", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        BackupReport.ExportToXlsx(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, True) & ".xlsx", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(BackupReportName & ".xlsx", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        BackupReport.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        BackupReport.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        BackupReport.ExportToImage(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, True) & ".png", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(BackupReportName & ".png", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    End If

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                    Catch ex As Exception

                    End Try

                    MemoryStream = Nothing

                End If

                If CoverSheet IsNot Nothing Then

                    MemoryStream = New System.IO.MemoryStream

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        CoverSheet.ExportToPdf(MemoryStream)

                        ZipFile.AddEntry(CoverSheetName & ".pdf", MemoryStream.ToArray)

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        CoverSheet.ExportToRtf(MemoryStream)

                        ZipFile.AddEntry(CoverSheetName & ".rtf", MemoryStream.ToArray)

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        CoverSheet.ExportToXls(MemoryStream)

                        ZipFile.AddEntry(CoverSheetName & ".xls", MemoryStream.ToArray)

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        CoverSheet.ExportToXlsx(MemoryStream)

                        ZipFile.AddEntry(CoverSheetName & ".xlsx", MemoryStream.ToArray)

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        CoverSheet.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        CoverSheet.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        CoverSheet.ExportToImage(MemoryStream)

                        ZipFile.AddEntry(CoverSheetName & ".png", MemoryStream.ToArray)

                    End If

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                    Catch ex As Exception

                    End Try

                    MemoryStream = Nothing

                End If

                If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                    If AccountReceivableInvoice IsNot Nothing Then

                        AddDocumentsZipPackage(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, DocumentIndex, ZipFile, AccountReceivableInvoice)

                    Else

                        AdvantageFramework.DocumentManager.CreateZipPackage(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, ZipFile.Entries.Count, ZipFile)

                    End If

                End If

            End If

        End Sub
        Private Sub AddDocumentsZipPackage(ByVal Agency As AdvantageFramework.Database.Entities.Agency, ByVal Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), DocumentIndex As Integer,
                                          ByRef ZipFile As Ionic.Zip.ZipFile, AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Links As String = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim SaveToLocation As String = Nothing
            Dim InvoiceNumberString As String = ""

            Try

                If Agency IsNot Nothing Then

                    InvoiceNumberString = CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                    For Each Document In Documents

                        Try

                            If Document.FileType <> FileSystem.FileTypes.URL Then

                                FileSystemFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\") & Document.FileSystemFileName

                                If System.IO.File.Exists(FileSystemFile) Then

                                    FileStream = New System.IO.FileStream(FileSystemFile, IO.FileMode.OpenOrCreate)
                                    BinaryReader = New System.IO.BinaryReader(FileStream)
                                    ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FileSystemFile).Length)

                                    FileStream.Read(ByteFile, 0, FileStream.Length)
                                    FileStream.Close()

                                    If (From Doc In Documents
                                        Where Doc.ID <> Document.ID AndAlso
                                              Doc.FileName.ToUpper = Document.FileName.ToUpper
                                        Select Doc).Any Then

                                        FileExtension = New System.IO.FileInfo(Document.FileName).Extension

                                        SaveAsFileName = InvoiceNumberString & "_" & DocumentIndex.ToString & " " & Document.FileName.Replace(FileExtension, "") & "(" & Counter & ")" & FileExtension

                                        Counter = Counter + 1

                                    Else

                                        SaveAsFileName = InvoiceNumberString & "_" & DocumentIndex.ToString & " " & Document.FileName

                                        Counter = 0

                                    End If

                                    ZipFile.AddEntry(SaveAsFileName, ByteFile)

                                    DocumentIndex = DocumentIndex + 1

                                End If

                            Else

                                Links &= Document.Description & vbTab & "[" & Document.FileSystemFileName & "]" & vbNewLine

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If String.IsNullOrEmpty(Links) = False Then

                        ZipFile.AddEntry(InvoiceNumberString & "_" & DocumentIndex.ToString & " " & "Links.txt", Links)

                    End If

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub AddToAttachments(ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                     ReportName As String,
                                     Report As DevExpress.XtraReports.UI.XtraReport,
                                     Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment))

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If Report IsNot Nothing AndAlso Attachments IsNot Nothing Then

                MemoryStream = New System.IO.MemoryStream

                If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                    Report.ExportToPdf(MemoryStream)

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".pdf", MemoryStream.ToArray))

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                    Report.ExportToRtf(MemoryStream)

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".rtf", MemoryStream.ToArray))

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                    Report.ExportToXls(MemoryStream)

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xls", MemoryStream.ToArray))

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                    Report.ExportToXlsx(MemoryStream)

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xlsx", MemoryStream.ToArray))

                ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                    Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                    Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                    Report.ExportToImage(MemoryStream)

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".png", MemoryStream.ToArray))

                End If

                Try

                    MemoryStream.Close()
                    MemoryStream.Dispose()

                Catch ex As Exception

                End Try

                MemoryStream = Nothing

            End If

        End Sub
        Private Function GetExpenseReportDetailDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal InvoiceNumber As Integer,
                                                                     ByVal InvoiceSequenceNumber As Short,
                                                                     ByVal Type As String) As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            DocumentLevelSettings = (From ARS In AdvantageFramework.Database.Procedures.AccountReceivableSummary.Load(DbContext)
                                     Join APP In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                            On ARS.ARInvoiceNumber.Value Equals APP.AccountReceivableInvoiceNumber.Value And
                                                ARS.ARInvoiceSequence.Value Equals APP.AccountReceivableInvoiceSequenceNumber.Value And
                                                ARS.JobNumber.Value Equals APP.JobNumber And
                                                ARS.JobComponentNumber.Value Equals APP.JobComponentNumber
                                     Join APH In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext) On APP.AccountPayableID Equals APH.ID
                                     Where (APP.ModifyDelete Is Nothing OrElse APP.ModifyDelete = 0) AndAlso
                                        (APH.Modified Is Nothing OrElse APH.Modified = 0) AndAlso
                                        (APH.Deleted Is Nothing OrElse APH.Deleted = 0) AndAlso
                                        APP.ExpenseReportDetailID IsNot Nothing AndAlso
                                        ARS.ARInvoiceNumber = InvoiceNumber AndAlso
                                        ARS.ARInvoiceSequence = InvoiceSequenceNumber AndAlso
                                        ARS.ARType = Type
                                     Select APH.ID, ARS.ARInvoiceNumber, ARS.ARInvoiceSequence, ARS.ARType, APP.ExpenseReportDetailID).Distinct.ToList.Select(Function(DLS) _
                                        New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts, Database.Entities.DocumentSubLevel.ExpenseDetailDocument) With
                                                                                                        {.AccountPayableID = DLS.ID,
                                                                                                        .AccountReceivableInvoiceNumber = DLS.ARInvoiceNumber,
                                                                                                        .AccountReceivableSequenceNumber = DLS.ARInvoiceSequence,
                                                                                                        .AccountReceivableType = DLS.ARType,
                                                                                                        .ExpenseDetailID = DLS.ExpenseReportDetailID}).ToList

            GetExpenseReportDetailDocumentLevelSettings = DocumentLevelSettings

        End Function
        Public Function CreateFileName(InvoiceNumber As Integer, SequenceNumber As Integer, ClientCode As String, DocumentIndex As Integer, IsBackup As Boolean) As String

            'objects
            Dim FileName As String = ""

            If SequenceNumber > 0 Then

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & "_" & DocumentIndex.ToString & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & "_" & DocumentIndex.ToString & " " & ClientCode

                End If

            Else

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & DocumentIndex.ToString & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & DocumentIndex.ToString & " " & ClientCode

                End If

            End If

            CreateFileName = FileName

        End Function
        Public Function CreateInvoiceNumberString(InvoiceNumber As Integer, SequenceNumber As Integer) As String

            'objects
            Dim InvoiceNumberString As String = ""

            If SequenceNumber > 0 Then

                InvoiceNumberString = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#")

            Else

                InvoiceNumberString = Format(InvoiceNumber, "00000000#")

            End If

            CreateInvoiceNumberString = InvoiceNumberString

        End Function

        Public Sub CreateEstimateAndOpenEmailClient(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote),
                                     EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim _EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
            Dim ErrorMessage As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim [Bcc] As String = Nothing
            Dim EmailSent As Boolean = False
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim EmailSettings As AdvantageFramework.Estimate.Printing.Classes.EmailSettings = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim ReportExportPath As String = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing


            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)


            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                            My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")
                            AgencyImportPath = AgencyImportPath & "Reports\"

                        End If

                    Else

                        Try

                            ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                        Catch ex As Exception
                            ReportExportPath = ""
                        End Try

                        If String.IsNullOrWhiteSpace(ReportExportPath) Then

                            ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                        End If

                        If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

                            AgencyImportPath = ReportExportPath

                        End If

                    End If

                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, EstimateFormatType).ToList

                        End Using

                        Dim quotes As String = ""
                        Dim qtedesc As String = ""
                        Dim qtedescs As String = ""
                        Dim comps As String = ""
                        Dim qte As Integer = 0
                        Dim comp As Integer = 0
                        Dim count As Integer = 0
                        Dim est As Integer = 0
                        Dim estcomp As String = ""
                        Dim ClCodeString As String = ""

                        Dim estCount As Integer = 0

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        'If EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZip Then


                        'ElseIf EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then


                        'Else

                        Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                        ZipFileName = ""

                        For Each EstimateQuote In EstimateQuotes

                            If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                If EstimatePrintingSetting Is Nothing Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                End If
                                If EstimatePrintingSetting Is Nothing Then
                                    EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                End If
                            ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                            Else
                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                            End If

                            If EstimatePrintingSetting IsNot Nothing Then
                                If EstimatePrintingSetting.SummaryLevel = 2 Then
                                    If (est <> 0 And est <> EstimateQuote.EstimateNumber) Then
                                        If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                            End If
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                            End If
                                        ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                        Else
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                        End If

                                        If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                            AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                            Exit Sub
                                        End If

                                        _EstimateQuote = EstimateQuotes(estCount - 1)

                                        CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                        If EstimateQuote.ClientCode <> "" Then
                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                        End If

                                        If EstimateQuote.JobNumber <> 0 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#")
                                        End If

                                        If Report IsNot Nothing Then

                                            AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                        End If

                                        quotes = ""
                                        qtedescs = ""
                                        count = 0
                                    End If
                                Else
                                    If (estcomp <> "" And estcomp <> EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber) Then
                                        If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuotes(estCount - 1).CDP AndAlso Entity.Type = 3)
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode AndAlso Entity.Type = 2)
                                            End If
                                            If EstimatePrintingSetting Is Nothing Then
                                                EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuotes(estCount - 1).ClientCode)
                                            End If
                                        ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                        Else
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                        End If

                                        If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                            AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                            Exit Sub
                                        End If

                                        _EstimateQuote = EstimateQuotes(estCount - 1)

                                        CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                        If EstimateQuote.ClientCode <> "" Then
                                            ClCodeString = "_" & EstimateQuote.ClientCode
                                        End If

                                        If EstimateQuote.JobNumber = 0 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                        End If

                                        If Report IsNot Nothing Then

                                            AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                        End If

                                        quotes = ""
                                        qtedescs = ""
                                        count = 0
                                    End If
                                End If

                                Try
                                    est = EstimateQuote.EstimateNumber
                                    comp = EstimateQuote.EstimateComponentNumber
                                    estcomp = EstimateQuote.EstimateNumber & "-" & EstimateQuote.EstimateComponentNumber
                                    qte = EstimateQuote.QuoteNumber
                                    If EstimateQuote.QuoteDesc IsNot Nothing Then
                                        qtedesc = EstimateQuote.QuoteDesc.Replace("&nbsp;", "").Replace(",", "_")
                                    End If
                                Catch ex As Exception
                                    qte = 0
                                    qtedesc = ""
                                End Try
                                quotes &= qte & ","
                                qtedescs &= qtedesc & ","
                                comps &= comp & ","
                                count += 1
                                estCount += 1

                                If estCount = EstimateQuotes.Count Then

                                    If EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.CDP = EstimateQuote.CDP AndAlso Entity.Type = 3)
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode AndAlso Entity.Type = 2)
                                        End If
                                        If EstimatePrintingSetting Is Nothing Then
                                            EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault(Function(Entity) Entity.ClientCode = EstimateQuote.ClientCode)
                                        End If
                                    ElseIf EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then
                                        EstimatePrintingSetting = EstimatePrintingSettings.SingleOrDefault(Function(Entity) Entity.UserID = Session.UserCode)
                                    Else
                                        EstimatePrintingSetting = EstimatePrintingSettings.FirstOrDefault
                                    End If

                                    If count > 4 And EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then
                                        AdvantageFramework.WinForm.MessageBox.Show("Only 4 quotes may be selected per component for this report format.")
                                        Exit Sub
                                    End If

                                    _EstimateQuote = EstimateQuote

                                    CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote, comps, quotes, qtedescs, EstimatePrintingSetting.SummaryLevel)

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.ClientCode <> "" Then
                                        ClCodeString = "_" & EstimateQuote.ClientCode
                                    End If

                                    If EstimateQuote.JobNumber <> 0 Then
                                        'DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                        If EstimatePrintingSetting.SummaryLevel = 2 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                        End If
                                    Else
                                        'DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(est, "000000#") & "_" & Format(comp, "00#")
                                        If EstimatePrintingSetting.SummaryLevel = 2 Then
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#")
                                        Else
                                            DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#")
                                        End If
                                    End If

                                    If Report IsNot Nothing Then

                                        AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                    End If

                                End If
                            Else

                                _EstimateQuote = EstimateQuote

                                EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting()

                                CreateEstimate(Report, Session, EstimatePrintingSetting, EstimateQuote)

                                If EstimateQuote.ClientCode <> "" Then
                                    ClCodeString = "_" & EstimateQuote.ClientCode
                                End If

                                If EstimateQuote.JobNumber = 0 Then
                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                Else
                                    DefaultFileName = "ESTIMATE" & ClCodeString & "_JOB_" & Format(EstimateQuote.JobNumber, "000000#") & "_" & Format(EstimateQuote.JobComponentNumber, "00#") & "_EST_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & Format(EstimateQuote.EstimateComponentNumber, "00#") & "_" & Format(EstimateQuote.QuoteNumber, "00#")
                                End If

                                If Report IsNot Nothing Then

                                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments)

                                End If

                            End If

                        Next

                        'End If

                        'AdvantageFramework.WinForm.Presentation.ShowWaitForm("Sending...", ParentForm)

                        'If Attachments.Count > 0 Then

                        '    EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], EmailSettings.Subject, EmailSettings.Body, 3, Attachments, SendingEmailStatus, ErrorMessage, False)

                        '    Try

                        '        For Each Attachment In Attachments

                        '            If String.IsNullOrWhiteSpace(Attachment.File) = False Then

                        '                My.Computer.FileSystem.DeleteFile(Attachment.File)

                        '            End If

                        '        Next

                        '    Catch ex As Exception

                        '    End Try

                        'End If

                    End If

                End Using

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            AdvantageFramework.Email.CreateEmailAndOpenEmailClient(AgencyImportPath, DefaultFileName, DefaultFileName & " Estimate", "", "", Attachments)

        End Sub

#End Region

    End Module

End Namespace

