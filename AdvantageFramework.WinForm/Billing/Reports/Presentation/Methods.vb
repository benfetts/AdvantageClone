Namespace Billing.Reports.Presentation

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

		Private Function CreateSMTP(DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
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
        Private Function SendEmail(SMTP As MailBee.SmtpMail.Smtp, [To] As String, [CC] As String, [Bcc] As String, Subject As String, Body As String, Priority As Integer,
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

                If String.IsNullOrWhiteSpace([CC]) = False AndAlso [CC].Length > 0 Then

                    SMTP.Message.Cc.AsString = [CC]

                End If

                If String.IsNullOrWhiteSpace([Bcc]) = False AndAlso [Bcc].Length > 0 Then

                    SMTP.Message.Bcc.AsString = [Bcc]

                End If

                SMTP.Message.Subject = Subject

                SMTP.Message.BodyPlainText = Body

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
        Public Sub PrintInvoices(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                 InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, IsDraft As Boolean, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                 InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

            'objects
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False
            Dim PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings = Nothing
            Dim XtraReports As Generic.List(Of DevExpress.XtraReports.UI.XtraReport) = Nothing
            Dim ClientCodes() As String = Nothing
            Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default

            PrintSettings = New AdvantageFramework.InvoicePrinting.Classes.PrintSettings
            XtraReports = New Generic.List(Of DevExpress.XtraReports.UI.XtraReport)

            If AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingPrintDialog.ShowFormDialog(PrintSettings, True, False) = Windows.Forms.DialogResult.OK Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

                Catch ex As Exception
                    ClientCodes = Nothing
                End Try

                If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
                        InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

                        AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
                        OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

                    End Using

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

                    End Using

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                        Catch ex As Exception
                            CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                        End Try

                        Try

                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                        Catch ex As Exception
                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                        End Try

                    End Using

                    For Each ClientCode In ClientCodes

                        Try

                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                            If PrintSettings.IncludeCoverSheet Then

                                Report = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                               InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                If Report IsNot Nothing Then

                                    Report.DisplayName = ClientCode & " Cover Sheet"

                                    Report.CreateDocument()

                                    XtraReports.Add(Report)

                                End If

                            End If

                            InvoicePrintingComboSetting = Nothing
                            InvoicePrintingMediaSetting = Nothing
                            InvoicePrintingSetting = Nothing

                            If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                            Else

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                            End If

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                IsCustomReport = False

                                If AccountReceivableInvoice.RecordType = "P" Then

                                    If InvoicePrintingSetting IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                            IsCustomReport = True

                                        End If

                                    End If

                                Else

                                    If InvoicePrintingMediaSetting IsNot Nothing Then

                                        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                            IsCustomReport = True

                                        End If

                                    End If

                                End If

                                If IsCustomReport = False Then

                                    Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                                AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft, InvoicePrinting.InvoicePrintingTypes.Print)

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        If InvoicePrintingPageSetting IsNot Nothing Then

                                            InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                                        End If

                                        Report.DisplayName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        XtraReports.Add(Report)

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    If AccountReceivableInvoice.RecordType = "P" AndAlso InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) = True Then

                                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                                    AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft, InvoicePrinting.InvoicePrintingTypes.Print)

                                        If Report IsNot Nothing Then

                                            Report.CreateDocument()

                                            Report.DisplayName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)
                                            Report.Name = Report.DisplayName

                                            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                Report.PrintingSystem.Document.Name = Report.DisplayName

                                            End If

                                            XtraReports.Add(Report)

                                            If PrintSettings.SendToDocumentManager Then

                                                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        Catch ex As Exception

                        End Try

                    Next

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    If XtraReports.Count > 1 Then

                        AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReports, UserLookAndFeel)

                    ElseIf XtraReports.Count = 1 Then

                        AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReports.FirstOrDefault, True, UserLookAndFeel, False, False)

                    End If

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Print Custom Legacy Formats...", ParentForm)

                    AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, IsDraft,
                                                                                    AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.Print)

                End If

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show("Invoices have been printed.")

            End If

        End Sub
        Public Sub QuickPrintInvoices(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                      InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, IsDraft As Boolean, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                      InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

            'objects
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False
            Dim PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings = Nothing
            Dim ClientCodes() As String = Nothing
            Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default

            PrintSettings = New AdvantageFramework.InvoicePrinting.Classes.PrintSettings

            If AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingPrintDialog.ShowFormDialog(PrintSettings, True, False) = Windows.Forms.DialogResult.OK Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

                Try

                    Try

                        ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

                    Catch ex As Exception
                        ClientCodes = Nothing
                    End Try

                    If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
                            InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

                            AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
                            OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

                        End Using

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

                        End Using

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Try

                                CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                            Catch ex As Exception
                                CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                            End Try

                            Try

                                OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                            Catch ex As Exception
                                OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                            End Try

                        End Using

                        For Each ClientCode In ClientCodes

                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                            If PrintSettings.IncludeCoverSheet Then

                                Report = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                               InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                If Report IsNot Nothing Then

                                    Report.CreateDocument()

                                    Report.DisplayName = ClientCode & " Cover Sheet"
                                    Report.Name = Report.DisplayName

                                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                    End If

                                    AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                End If

                            End If

                            InvoicePrintingComboSetting = Nothing
                            InvoicePrintingMediaSetting = Nothing
                            InvoicePrintingSetting = Nothing

                            If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                            Else

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                            End If

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                IsCustomReport = False

                                If AccountReceivableInvoice.RecordType = "P" Then

                                    If InvoicePrintingSetting IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                            IsCustomReport = True

                                        End If

                                    End If

                                Else

                                    If InvoicePrintingMediaSetting IsNot Nothing Then

                                        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                            IsCustomReport = True

                                        End If

                                    End If

                                End If

                                If IsCustomReport = False Then

                                    Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                                AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft, InvoicePrinting.InvoicePrintingTypes.Print)

                                    If Report IsNot Nothing Then

                                        Report.CreateDocument()

                                        If InvoicePrintingPageSetting IsNot Nothing Then

                                            InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                                        End If

                                        Report.DisplayName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)
                                        Report.Name = Report.DisplayName

                                        If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                            Report.PrintingSystem.Document.Name = Report.DisplayName

                                        End If

                                        AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    If AccountReceivableInvoice.RecordType = "P" AndAlso InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) = True Then

                                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                                AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft, InvoicePrinting.InvoicePrintingTypes.Print)

                                        If Report IsNot Nothing Then

                                            Report.CreateDocument()

                                            Report.DisplayName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)
                                            Report.Name = Report.DisplayName

                                            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                Report.PrintingSystem.Document.Name = Report.DisplayName

                                            End If

                                            AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False)

                                            If PrintSettings.SendToDocumentManager Then

                                                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                        Next

                    End If

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Print Custom Legacy Formats...", ParentForm)

                    AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, IsDraft,
                                                                     AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.Print)

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show(ParentForm, "Invoices have been printed.")

            End If

        End Sub
        Public Sub CreateInvoiceAndOpenEmailClient(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
												   InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, IsDraft As Boolean,
												   InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

			'objects
			Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
			Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
			Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
			Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
			Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
			Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent
			Dim ErrorMessage As String = ""
			Dim DefaultFileName As String = Nothing
			Dim DefaultBackupFileName As String = Nothing
			Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
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

						InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
						InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

						AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
						OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

						InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

						Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

						Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

						ZipFileName = ""

						For Each AccountReceivableInvoice In AccountReceivableInvoices

							DocumentList = Nothing
							InvoicePrintingMediaSetting = Nothing
							InvoicePrintingSetting = Nothing
							InvoicePrintingComboSetting = Nothing
							Report = Nothing
							BackupReport = Nothing
							DefaultFileName = ""
							DefaultBackupFileName = ""
							ZipFileName = ""
							IsCustomReport = False

							If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

								If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

									InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

								ElseIf AccountReceivableInvoice.RecordType = "P" Then

									InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

								ElseIf AccountReceivableInvoice.RecordType = "C" Then

									InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
									InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
									InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

								End If

							Else

								If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

									InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

								ElseIf AccountReceivableInvoice.RecordType = "P" Then

									InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

								ElseIf AccountReceivableInvoice.RecordType = "C" Then

									InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
									InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
									InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

								End If

							End If

							If InvoicePrintingComboSetting IsNot Nothing Then

								'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

								'    IsCustomReport = True

								'End If

							ElseIf InvoicePrintingSetting IsNot Nothing Then

								If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

									IsCustomReport = True

								End If

							ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

								If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
											(AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
											(AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
											(AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
											(AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
											(AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

									IsCustomReport = True

								End If

							End If

							If IsCustomReport = False Then

								Package(Session, DbContext, InvoicePrinting.Methods.ToFileOptions.PDF, False, False, AccountReceivableInvoice,
										InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
										InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

								If Report IsNot Nothing Then

									DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                    AddToAttachments(InvoicePrinting.Methods.ToFileOptions.PDF, DefaultFileName, Report, Attachments, InvoicePrintingPageSetting, AccountReceivableInvoice, InvoicePrinting.OverrideInvoiceFilename.Default)

                                End If

								If BackupReport IsNot Nothing Then

									DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                    AddToAttachments(InvoicePrinting.Methods.ToFileOptions.PDF, DefaultBackupFileName, BackupReport, Attachments, InvoicePrintingPageSetting, AccountReceivableInvoice, InvoicePrinting.OverrideInvoiceFilename.Default)

                                End If

							End If

						Next

					End If

				End Using

			Catch ex As Exception

			End Try

			AdvantageFramework.WinForm.Presentation.CloseWaitForm()

			If Attachments IsNot Nothing AndAlso Attachments.Count > 0 Then

				AdvantageFramework.Email.CreateEmailAndOpenEmailClient(AgencyImportPath, DefaultFileName, DefaultFileName & " Invoice", "", "", Attachments)

			End If

		End Sub
		Public Sub SendInvoiceEmails(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
									 InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, IsDraft As Boolean, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
									 InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

			'objects
			Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
			Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
			Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
			Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
			Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
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
			Dim EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings = Nothing
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
			Dim ClientCodes() As String = Nothing
			Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
			Dim MediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
			Dim DocumentIndex As Integer = 0
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = 0

            If InvoicePrintingSendEmailsDialog.ShowFormDialog(EmailSettings, ToFileOption) = Windows.Forms.DialogResult.OK AndAlso EmailSettings IsNot Nothing Then

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

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

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

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                SMTP = CreateSMTP(DbContext, SecurityDbContext, Agency, From, ReplyTo)

                                If String.IsNullOrWhiteSpace(EmailSettings.FromEmail) = False Then

                                    From = EmailSettings.FromEmail

                                End If

                                If String.IsNullOrWhiteSpace(EmailSettings.ReplyTo) = False Then

                                    ReplyTo = EmailSettings.ReplyTo

                                End If

                                MaxEmailSize = AdvantageFramework.Email.LoadMaxEmailSize(DbContext)

                                InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
                                InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

                                AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
                                OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

                                InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

                                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                    Try

                                        CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                                    Catch ex As Exception
                                        CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                                    End Try

                                    Try

                                        OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                                    Catch ex As Exception
                                        OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                                    End Try

                                End Using

                                Try

                                    ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

                                Catch ex As Exception
                                    ClientCodes = Nothing
                                End Try

                                If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                                    Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                    For Each ClientCode In ClientCodes

                                        ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                                        If EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZip Then

                                            ZipFile = New Ionic.Zip.ZipFile

                                            If EmailSettings.SinglePDF Then

                                                DocumentList = Nothing
                                                InvoicePrintingMediaSetting = Nothing
                                                InvoicePrintingSetting = Nothing
                                                InvoicePrintingComboSetting = Nothing
                                                Report = Nothing
                                                BackupReport = Nothing
                                                DefaultFileName = ""
                                                DefaultBackupFileName = ""
                                                ZipFileName = ""
                                                IsCustomReport = False
                                                MediaReport = Nothing
                                                MediaDocumentList = Nothing

                                                If EmailSettings.IncludeCoverSheet Then

                                                    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                                                         InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    If CoverSheetReport IsNot Nothing Then

                                                        AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & ClientCode & " CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    End If

                                                End If

                                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                                    InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                                    InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                                                Else

                                                    InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                End If

                                                PackageToSingleFile(Session, DbContext, ToFileOption, EmailSettings, ClientAccountReceivableInvoices,
                                                                InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                                                OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                                                DocumentList, MediaReport, MediaDocumentList, IsDraft)

                                                If Report IsNot Nothing Then

                                                    DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                                                    If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                            ExportReport(Session, Report, CreateSingleFileName(ClientCode, False, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                                                     False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        Next

                                                    End If

                                                End If

                                                If BackupReport IsNot Nothing Then

                                                    DefaultBackupFileName = CreateSingleFileName(ClientCode, True, False)

                                                    If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                            ExportReport(Session, BackupReport, CreateSingleFileName(ClientCode, True, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                                                     InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        Next

                                                    End If

                                                End If

                                                AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                If MediaReport IsNot Nothing Then

                                                    DefaultFileName = CreateSingleFileName(ClientCode, False, True)

                                                    AddToZipFile(Agency, ToFileOption, DefaultFileName, MediaReport, "", Nothing, "", Nothing, MediaDocumentList, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                End If

                                            Else

                                                If EmailSettings.IncludeCoverSheet Then

                                                    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                                         InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                                         InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    If CoverSheetReport IsNot Nothing Then

                                                        AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & ClientCode & " CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    End If

                                                End If

                                                For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    DocumentList = Nothing
                                                    InvoicePrintingMediaSetting = Nothing
                                                    InvoicePrintingSetting = Nothing
                                                    InvoicePrintingComboSetting = Nothing
                                                    Report = Nothing
                                                    BackupReport = Nothing
                                                    DefaultFileName = ""
                                                    DefaultBackupFileName = ""
                                                    ZipFileName = ""
                                                    IsCustomReport = False

                                                    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        End If

                                                    Else

                                                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                        End If

                                                    End If

                                                    If InvoicePrintingComboSetting IsNot Nothing Then

                                                        'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                        '    IsCustomReport = True

                                                        'End If

                                                    ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                            IsCustomReport = True

                                                        End If

                                                    ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                            IsCustomReport = True

                                                        End If

                                                    End If

                                                    If IsCustomReport = False Then

                                                        Package(Session, DbContext, ToFileOption, EmailSettings.IncludeAPDocuments, EmailSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                        InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                        InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                        If Report IsNot Nothing Then

                                                            DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                                            If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                            End If

                                                        End If

                                                        If BackupReport IsNot Nothing Then

                                                            DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                                            If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                                ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                            End If

                                                        End If

                                                        AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, AccountReceivableInvoice, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    End If

                                                Next

                                            End If

                                            If ZipFile.Entries.Count > 0 Then

                                                ZipFileName = ClientCode & " - Invoices"

                                                Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                                                    ZipFileName = ClientCode & " - Invoices(" & Counter & ")"

                                                    Counter = Counter + 1

                                                Loop

                                                ZipFileName = ZipFileName & ".zip"

                                                ZipFile.Save(ZipFileName)

                                                Try

                                                    ZipFile.Dispose()

                                                    ZipFile = Nothing

                                                Catch ex As Exception

                                                End Try

                                                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                                            End If

                                        ElseIf EmailSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then

                                            ZipFileName = ""

                                            If EmailSettings.IncludeCoverSheet Then

                                                CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                                     InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                                     InvoiceFormatType, IsDraft, CoversheetLayout)

                                                If CoverSheetReport IsNot Nothing Then

                                                    AddToAttachments(ToFileOption, ClientCode & " !CoverSheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                                                End If

                                            End If

                                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                DocumentList = Nothing
                                                InvoicePrintingMediaSetting = Nothing
                                                InvoicePrintingSetting = Nothing
                                                InvoicePrintingComboSetting = Nothing
                                                Report = Nothing
                                                BackupReport = Nothing
                                                DefaultFileName = ""
                                                DefaultBackupFileName = ""
                                                ZipFileName = ""
                                                IsCustomReport = False

                                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    End If

                                                Else

                                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    End If

                                                End If

                                                If InvoicePrintingComboSetting IsNot Nothing Then

                                                    'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                    '    IsCustomReport = True

                                                    'End If

                                                ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                        IsCustomReport = True

                                                    End If

                                                ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                    If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                        IsCustomReport = True

                                                    End If

                                                End If

                                                If IsCustomReport = False Then

                                                    Package(Session, DbContext, ToFileOption, EmailSettings.IncludeAPDocuments, EmailSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                        InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                        InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                    If Report IsNot Nothing Then

                                                        DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                                        If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        End If

                                                    End If

                                                    If BackupReport IsNot Nothing Then

                                                        DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                                        If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                            ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        End If

                                                    End If

                                                    CreateInvoiceZipFileForPrintToMultipleFiles(Agency, ToFileOption, AgencyImportPath, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFileName, AccountReceivableInvoice, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                                                End If

                                            Next

                                        Else

                                            ZipFileName = ""

                                            If EmailSettings.SinglePDF Then

                                                DocumentList = Nothing
                                                InvoicePrintingMediaSetting = Nothing
                                                InvoicePrintingSetting = Nothing
                                                InvoicePrintingComboSetting = Nothing
                                                Report = Nothing
                                                BackupReport = Nothing
                                                DefaultFileName = ""
                                                DefaultBackupFileName = ""
                                                ZipFileName = ""
                                                IsCustomReport = False
                                                MediaReport = Nothing
                                                MediaDocumentList = Nothing

                                                If EmailSettings.IncludeCoverSheet Then

                                                    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                                                         InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    If CoverSheetReport IsNot Nothing Then

                                                        AddToAttachments(ToFileOption, ClientCode & " !CoverSheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    End If

                                                End If

                                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                                    InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                                                    InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                                                Else

                                                    InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                End If

                                                PackageToSingleFile(Session, DbContext, ToFileOption, EmailSettings, ClientAccountReceivableInvoices,
                                                                InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                                                OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                                                DocumentList, MediaReport, MediaDocumentList, IsDraft)

                                                If Report IsNot Nothing Then

                                                    DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                                                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments, Nothing, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                                                    If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                            ExportReport(Session, Report, CreateSingleFileName(ClientCode, False, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                                                     False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        Next

                                                    End If

                                                End If

                                                If BackupReport IsNot Nothing Then

                                                    DefaultBackupFileName = CreateSingleFileName(ClientCode, True, False)

                                                    AddToAttachments(ToFileOption, DefaultBackupFileName, BackupReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                                                    If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                            ExportReport(Session, BackupReport, CreateSingleFileName(ClientCode, True, False),
                                                                     AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                                                     InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                        Next

                                                    End If

                                                End If

                                                If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                                                    AddToDocumentsToAttachments(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                                                End If

                                                If MediaReport IsNot Nothing Then

                                                    DefaultFileName = CreateSingleFileName(ClientCode, False, True)

                                                    AddToAttachments(ToFileOption, DefaultFileName, MediaReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                                                End If

                                                If MediaDocumentList IsNot Nothing AndAlso MediaDocumentList.Count > 0 Then

                                                    AddToDocumentsToAttachments(Agency, MediaDocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                                                End If

                                            Else

                                                If EmailSettings.IncludeCoverSheet Then

                                                    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                                         InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                                         InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    If CoverSheetReport IsNot Nothing Then

                                                        AddToAttachments(ToFileOption, ClientCode & " !CoverSheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                                                    End If

                                                End If

                                                For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    DocumentList = Nothing
                                                    InvoicePrintingMediaSetting = Nothing
                                                    InvoicePrintingSetting = Nothing
                                                    InvoicePrintingComboSetting = Nothing
                                                    Report = Nothing
                                                    BackupReport = Nothing
                                                    DefaultFileName = ""
                                                    DefaultBackupFileName = ""
                                                    ZipFileName = ""
                                                    IsCustomReport = False

                                                    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                        End If

                                                    Else

                                                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                        End If

                                                    End If

                                                    If InvoicePrintingComboSetting IsNot Nothing Then

                                                        'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                        '    IsCustomReport = True

                                                        'End If

                                                    ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                            IsCustomReport = True

                                                        End If

                                                    ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                                (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                                (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                                (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                                (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                                (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                            IsCustomReport = True

                                                        End If

                                                    End If

                                                    If IsCustomReport = False Then

                                                        Package(Session, DbContext, ToFileOption, EmailSettings.IncludeAPDocuments, EmailSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                            InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                            InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                        If Report IsNot Nothing Then

                                                            If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                            End If

                                                        End If

                                                        If BackupReport IsNot Nothing Then

                                                            If EmailSettings.SendToDocumentManager OrElse (EmailSettings.IncludeAPDocuments OrElse EmailSettings.IncludeExpenseReportReceipts) Then

                                                                ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                                            End If

                                                        End If

                                                        AddToAttachments(Agency, ToFileOption, Report, BackupReport, DocumentList, AccountReceivableInvoice, Attachments, InvoicePrintingPageSetting, OverrideInvoiceFilename)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    Next

                                End If

                                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Sending...", ParentForm)

                                If Attachments.Count > 0 Then

                                    EmailSent = SendEmail(SMTP, [To], [Cc], [Bcc], EmailSettings.Subject, EmailSettings.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                          Attachments, SendingEmailStatus, Agency, EmailSettings.SenderName, From, ReplyTo, MaxEmailSize)

                                    Try

                                        For Each Attachment In Attachments

                                            If String.IsNullOrWhiteSpace(Attachment.File) = False Then

                                                My.Computer.FileSystem.DeleteFile(Attachment.File)

                                            End If

                                        Next

                                    Catch ex As Exception

                                    End Try

                                End If

                                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Print Custom Legacy Formats...", ParentForm)

                                AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, IsDraft,
                                                                                     AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.SMTP, EmailSettings)

                            End If

                        End Using

                    End Using

                Catch ex As Exception

				End Try

				AdvantageFramework.WinForm.Presentation.CloseWaitForm()

				If EmailSent OrElse (Attachments IsNot Nothing AndAlso Attachments.Count = 0) Then

					AdvantageFramework.WinForm.MessageBox.Show("Invoices have been printed and sent.")

				Else

					If SendingEmailStatus <> AdvantageFramework.Email.SendingEmailStatus.EmailSent Then

						AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

					ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

						AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

					Else

						AdvantageFramework.WinForm.MessageBox.Show("Failed creating or sending invoices.  Please contact software support.")

					End If

				End If

			End If

		End Sub
		Public Sub PrintToFile(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session,
							   AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
							   InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, ToSingleFile As Boolean,
							   ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions, IsDraft As Boolean,
							   InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

			'objects
			Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
			Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
			Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
			Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
			Dim AgencyImportPath As String = Nothing
			Dim DefaultFileName As String = Nothing
			Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim MainReport As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim IsAgencyASP As Boolean = False
			Dim ClientCodes() As String = Nothing
			Dim AccessReportTempPath As String = Nothing
			Dim PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings = Nothing
			Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
			Dim KeepProcessing As Boolean = True
			Dim ErrorMessage As String = Nothing

			PrintSettings = New AdvantageFramework.InvoicePrinting.Classes.PrintSettings

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

			Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

				If ToFileOption = InvoicePrinting.ToFileOptions.DocumentManager Then

					KeepProcessing = AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage)

				Else

					If AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingPrintDialog.ShowFormDialog(PrintSettings, False, ToSingleFile) = Windows.Forms.DialogResult.OK Then

						KeepProcessing = True

					End If

				End If

			End Using

			If KeepProcessing = True Then

				If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager Then

					PrintSettings.SendToDocumentManager = True

				Else

					PrintSettings.ExportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(PrintSettings.ExportPath.Trim, "\")

				End If

				AdvantageFramework.WinForm.Presentation.ShowWaitForm("Printing...", ParentForm)

				Try

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
						InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

						AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
						OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

					End Using

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

					End Using

					If ToSingleFile Then

						PrintToSingleFile(Session, Agency, ToFileOption, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
										  AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, PrintSettings, InvoiceFormatType, IsDraft, InvoicePrintingPageSetting)

					Else

						PrintToMultipleFiles(Session, Agency, ToFileOption, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
											 AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, PrintSettings, InvoiceFormatType, IsDraft, InvoicePrintingPageSetting)

					End If

					AdvantageFramework.WinForm.Presentation.ShowWaitForm("Print Custom Legacy Formats...", ParentForm)

					AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, IsDraft,
																			 If(ToSingleFile = True, AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.All, AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.Individual))

				Catch ex As Exception

				End Try

				AdvantageFramework.WinForm.Presentation.CloseWaitForm()

				If ToFileOption = InvoicePrinting.ToFileOptions.DocumentManager Then

					AdvantageFramework.WinForm.MessageBox.Show("Invoices have been uploaded.")

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Invoices have been printed.")

				End If

			Else

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

		End Sub
		Private Sub PrintToSingleFile(Session As AdvantageFramework.Security.Session,
									  Agency As AdvantageFramework.Database.Entities.Agency,
									  ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
									  AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
									  InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
									  InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
									  AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
									  OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
									  InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
									  PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings,
									  InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
									  IsDraft As Boolean, InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

			'objects
			Dim ClientCodes() As String = Nothing
			Dim DefaultFileName As String = Nothing
			Dim DefaultBackupFileName As String = Nothing
			Dim DefaultMediaFileName As String = Nothing
			Dim MainReport As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim MainBackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
			Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
			Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
			Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
			Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
			Dim MainMediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
			Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
			Dim ZipFileName As String = Nothing
			Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

				Try

					ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

				Catch ex As Exception
					ClientCodes = Nothing
				End Try

				If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                        Catch ex As Exception
                            CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                        End Try

                        Try

                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                        Catch ex As Exception
                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                        End Try

                    End Using

                    For Each ClientCode In ClientCodes

						MainReport = Nothing
						MainBackupReport = Nothing
						MainMediaReport = Nothing
						ClientAccountReceivableInvoices = Nothing
						InvoicePrintingMediaSetting = Nothing
						InvoicePrintingSetting = Nothing
						InvoicePrintingComboSetting = Nothing
						DefaultFileName = ""
						DefaultBackupFileName = ""
						DocumentList = Nothing
						MediaDocumentList = Nothing
						ZipFileName = ""

						If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

							InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
							InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
							InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

						Else

							InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
							InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
							InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

						End If

						ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

						If PrintSettings.IncludeCoverSheet Then

                            CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                     InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                     InvoiceFormatType, IsDraft, CoversheetLayout)

                            If CoverSheetReport IsNot Nothing Then

                                'If PrintSettings.ZipFiles = False Then

                                '    CreateInvoiceZipFile(Agency, ToFileOption, PrintSettings.ExportPath, "", Nothing, "", Nothing, "Cover Sheet " & ClientCode, CoverSheetReport, Nothing, ZipFileName)

                                'Else

                                ExportReport(Session, CoverSheetReport, PrintSettings.ExportPath & ClientCode & " Cover Sheet", ToFileOption, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                                'End If

                            End If

						End If

                        PackageToSingleFile(Session, DbContext, ToFileOption, PrintSettings, ClientAccountReceivableInvoices, InvoicePrintingSetting, InvoicePrintingMediaSetting,
                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                            MainReport, MainBackupReport, DocumentList, MainMediaReport, MediaDocumentList, IsDraft)

                        If MainReport IsNot Nothing Then

                            If ClientAccountReceivableInvoices.Select(Function(Entity) Format(Entity.InvoiceNumber, "00000000#") & "_" & Format(Entity.InvoiceSequenceNumber, "000#")).Distinct.Count = 1 Then

                                If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                                    DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                                    DefaultFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                                    DefaultFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                                    DefaultFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber, ClientAccountReceivableInvoices(0).ClientCode, ClientAccountReceivableInvoices(0).DivisionCode, ClientAccountReceivableInvoices(0).ProductCode, ClientAccountReceivableInvoices(0).CampaignCode)

                                End If

                            Else

                                DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                            End If

                            'If PrintSettings.ZipFiles = False Then

                            DefaultFileName = PrintSettings.ExportPath & DefaultFileName

                            ExportReport(Session, MainReport, DefaultFileName, ToFileOption, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                            If PrintSettings.SendToDocumentManager Then

                                For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                    ExportReport(Session, MainReport, CreateSingleFileName(ClientCode, False, False), AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                Next

                            End If

                            'End If

                        End If

                        If MainBackupReport IsNot Nothing Then

                            DefaultBackupFileName = CreateSingleFileName(ClientCode, True, False)

                            'If PrintSettings.ZipFiles = False Then

                            DefaultBackupFileName = PrintSettings.ExportPath & DefaultBackupFileName

                            ExportReport(Session, MainBackupReport, DefaultBackupFileName, ToFileOption, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                            If PrintSettings.SendToDocumentManager Then

                                For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                    ExportReport(Session, MainBackupReport, CreateSingleFileName(ClientCode, True, False), AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                Next

                            End If

                            'End If

                        End If

                        'If PrintSettings.ZipFiles AndAlso MainReport IsNot Nothing Then

                        '    CreateInvoiceZipFile(Agency, ToFileOption, PrintSettings.ExportPath, DefaultFileName, MainReport, DefaultBackupFileName, MainBackupReport, "", Nothing, DocumentList, ZipFileName)

                        'Else

                        For Each Document In DocumentList

                            AdvantageFramework.FileSystem.Download(Agency, Document.GetDocumentEntity, PrintSettings.ExportPath)

                        Next

                        'End If

                        If MainMediaReport IsNot Nothing Then

                            If ClientAccountReceivableInvoices.Select(Function(Entity) Format(Entity.InvoiceNumber, "00000000#") & "_" & Format(Entity.InvoiceSequenceNumber, "000#")).Distinct.Count = 1 Then

                                If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                                    DefaultMediaFileName = CreateSingleFileName(ClientCode, False, True)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                                    DefaultMediaFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                                    DefaultMediaFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber)

                                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                                    DefaultMediaFileName = CreateInvoiceNumberStringWithNoLeadingZeros(ClientAccountReceivableInvoices(0).InvoiceNumber, ClientAccountReceivableInvoices(0).InvoiceSequenceNumber, ClientAccountReceivableInvoices(0).ClientCode, ClientAccountReceivableInvoices(0).DivisionCode, ClientAccountReceivableInvoices(0).ProductCode, ClientAccountReceivableInvoices(0).CampaignCode)

                                End If

                            Else

                                DefaultMediaFileName = CreateSingleFileName(ClientCode, False, True)

                            End If

                            'If PrintSettings.ZipFiles = False Then

                            DefaultMediaFileName = PrintSettings.ExportPath & DefaultMediaFileName

                            ExportReport(Session, MainMediaReport, DefaultMediaFileName, ToFileOption, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                            'End If

                        End If

                        'If PrintSettings.ZipFiles AndAlso MainMediaReport IsNot Nothing Then

                        '    CreateInvoiceZipFile(Agency, ToFileOption, PrintSettings.ExportPath, DefaultMediaFileName, MainMediaReport, "", Nothing, "", Nothing, MediaDocumentList, ZipFileName)

                        'End If

                    Next

                End If

            End Using

        End Sub
        Private Sub PrintToMultipleFiles(Session As AdvantageFramework.Security.Session,
                                         Agency As AdvantageFramework.Database.Entities.Agency,
                                         ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                         AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                         InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                         InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                         AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                         OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                         InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
                                         PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings,
                                         InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
                                         IsDraft As Boolean, InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)

            'objects
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ZipFileName As String = Nothing
            Dim IsCustomReport As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ClientCodes() As String = Nothing
            Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToArray

                Catch ex As Exception
                    ClientCodes = Nothing
                End Try

                If ClientCodes IsNot Nothing AndAlso ClientCodes.Count > 0 Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Try

                            CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                        Catch ex As Exception
                            CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                        End Try

                        Try

                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                        Catch ex As Exception
                            OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                        End Try

                    End Using

                    For Each ClientCode In ClientCodes

                        CoverSheetReport = Nothing
                        ClientAccountReceivableInvoices = Nothing

                        ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                        If PrintSettings.PackageType = InvoicePrinting.Methods.PackageTypes.OneZip Then

                            ZipFile = New Ionic.Zip.ZipFile

                            If PrintSettings.IncludeCoverSheet Then

                                CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                                         InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                If CoverSheetReport IsNot Nothing Then

                                    AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & ClientCode & " Cover Sheet", CoverSheetReport, Nothing, ZipFile, Nothing, InvoicePrintingPageSetting, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                End If

                            End If

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                Report = Nothing
                                BackupReport = Nothing
                                InvoicePrintingMediaSetting = Nothing
                                InvoicePrintingComboSetting = Nothing
                                InvoicePrintingSetting = Nothing
                                DefaultFileName = ""
                                DefaultBackupFileName = ""
                                DocumentList = Nothing
                                ZipFileName = ""
                                IsCustomReport = False

                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    End If

                                Else

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                    End If

                                End If

                                If InvoicePrintingComboSetting IsNot Nothing Then

                                    'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                    '    IsCustomReport = True

                                    'End If

                                ElseIf InvoicePrintingSetting IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                        IsCustomReport = True

                                    End If

                                ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                    If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                        IsCustomReport = True

                                    End If

                                End If

                                If IsCustomReport = False Then

                                    Package(Session, DbContext, ToFileOption, PrintSettings.IncludeAPDocuments, PrintSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting,
                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                    If Report IsNot Nothing Then

                                        DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                        'If PrintSettings.ZipFiles = False Then

                                        'DefaultFileName = PrintSettings.ExportPath & DefaultFileName

                                        'ExportReport(Session, Report, DefaultFileName, ToFileOption, AccountReceivableInvoice)

                                        'End If

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    If BackupReport IsNot Nothing Then

                                        DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                        'If PrintSettings.ZipFiles = False Then

                                        'DefaultBackupFileName = PrintSettings.ExportPath & DefaultBackupFileName

                                        'ExportReport(Session, BackupReport, DefaultBackupFileName, ToFileOption)

                                        'End If

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    'If PrintSettings.ZipFiles AndAlso Report IsNot Nothing Then

                                    '	CreateInvoiceZipFile(Agency, ToFileOption, PrintSettings.ExportPath, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFileName)

                                    'Else

                                    '	For Each Document In DocumentList

                                    '		AdvantageFramework.FileSystem.Download(Agency, Document.GetDocumentEntity, PrintSettings.ExportPath)

                                    '	Next

                                    'End If

                                    If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly AndAlso
                                            ClientAccountReceivableInvoices.Select(Function(Entity) Entity.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber).Count > 1 Then

                                        AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing,
                                                     DocumentList, ZipFile, AccountReceivableInvoice, InvoicePrintingPageSetting, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                                    Else

                                        AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing,
                                                     DocumentList, ZipFile, AccountReceivableInvoice, InvoicePrintingPageSetting, OverrideInvoiceFilename)

                                    End If

                                End If

                            Next

                            ZipFileName = PrintSettings.ExportPath & ClientCode & " - Invoices"

                            Counter = 0

                            Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                                ZipFileName = PrintSettings.ExportPath & ClientCode & " - Invoices(" & Counter & ")"

                                Counter = Counter + 1

                            Loop

                            ZipFileName = ZipFileName & ".zip"

                            ZipFile.Save(ZipFileName)

                            Try

                                ZipFile.Dispose()
                                ZipFile = Nothing

                            Catch ex As Exception

                            End Try

                        ElseIf PrintSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then

                            If PrintSettings.IncludeCoverSheet Then

                                CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                         InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                         InvoiceFormatType, IsDraft, CoversheetLayout)

                                If CoverSheetReport IsNot Nothing Then

                                    ExportReport(Session, CoverSheetReport, PrintSettings.ExportPath & ClientCode & " !Cover Sheet", ToFileOption, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                                End If

                            End If

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                Report = Nothing
                                BackupReport = Nothing
                                InvoicePrintingMediaSetting = Nothing
                                InvoicePrintingSetting = Nothing
                                InvoicePrintingComboSetting = Nothing
                                DefaultFileName = ""
                                DefaultBackupFileName = ""
                                DocumentList = Nothing
                                ZipFileName = ""
                                IsCustomReport = False

                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    End If

                                Else

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                    End If

                                End If

                                If InvoicePrintingComboSetting IsNot Nothing Then

                                    'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                    '    IsCustomReport = True

                                    'End If

                                ElseIf InvoicePrintingSetting IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                        IsCustomReport = True

                                    End If

                                ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                    If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                        IsCustomReport = True

                                    End If

                                End If

                                If IsCustomReport = False Then

                                    Package(Session, DbContext, ToFileOption, PrintSettings.IncludeAPDocuments, PrintSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting,
                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                    If Report IsNot Nothing Then

                                        DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                        'If PrintSettings.ZipFiles = False Then

                                        'DefaultFileName = PrintSettings.ExportPath & DefaultFileName

                                        '	ExportReport(Session, Report, DefaultFileName, ToFileOption, AccountReceivableInvoice)

                                        'End If

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    If BackupReport IsNot Nothing Then

                                        DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                        'If PrintSettings.ZipFiles = False Then

                                        'DefaultBackupFileName = PrintSettings.ExportPath & DefaultBackupFileName

                                        '	ExportReport(Session, BackupReport, DefaultBackupFileName, ToFileOption)

                                        'End If

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                    End If

                                    'If PrintSettings.ZipFiles AndAlso Report IsNot Nothing Then

                                    CreateInvoiceZipFileForPrintToMultipleFiles(Agency, ToFileOption, PrintSettings.ExportPath, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFileName, AccountReceivableInvoice, InvoicePrintingPageSetting, OverrideInvoiceFilename)

                                    'Else

                                    '	For Each Document In DocumentList

                                    '		AdvantageFramework.FileSystem.Download(Agency, Document.GetDocumentEntity, PrintSettings.ExportPath)

                                    '	Next

                                    'End If

                                End If

                            Next

                        Else

                            If PrintSettings.IncludeCoverSheet Then

                                CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                         InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                         InvoiceFormatType, IsDraft, CoversheetLayout)

                                If CoverSheetReport IsNot Nothing Then

                                    ExportReport(Session, CoverSheetReport, PrintSettings.ExportPath & ClientCode & " !Cover Sheet", ToFileOption, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, Nothing)

                                End If

                            End If

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                Report = Nothing
                                BackupReport = Nothing
                                InvoicePrintingMediaSetting = Nothing
                                InvoicePrintingSetting = Nothing
                                InvoicePrintingComboSetting = Nothing
                                DefaultFileName = ""
                                DefaultBackupFileName = ""
                                DocumentList = Nothing
                                ZipFileName = ""
                                IsCustomReport = False

                                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                    End If

                                Else

                                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                    End If

                                End If

                                If InvoicePrintingComboSetting IsNot Nothing Then

                                    'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                    '    IsCustomReport = True

                                    'End If

                                ElseIf InvoicePrintingSetting IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                        IsCustomReport = True

                                    End If

                                ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                    If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                        IsCustomReport = True

                                    End If

                                End If

                                If IsCustomReport = False Then

                                    Package(Session, DbContext, ToFileOption, PrintSettings.IncludeAPDocuments, PrintSettings.IncludeExpenseReportReceipts, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting,
                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                    If Report IsNot Nothing Then

                                        'DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                        'DefaultFileName = PrintSettings.ExportPath & AccountReceivableInvoice.ClientCode & " " & CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                                        'ExportReport(Session, Report, DefaultFileName, ToFileOption, False)

                                    End If

                                    If BackupReport IsNot Nothing Then

                                        'DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                        If PrintSettings.SendToDocumentManager Then

                                            ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                                        End If

                                        'DefaultBackupFileName = PrintSettings.ExportPath & AccountReceivableInvoice.ClientCode & " " & CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber) & " Backup"

                                        'ExportReport(Session, BackupReport, DefaultBackupFileName, ToFileOption, True)

                                    End If

                                    'If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                                    '	For Each Document In DocumentList

                                    '		AdvantageFramework.FileSystem.Download(Agency, Document.GetDocumentEntity, PrintSettings.ExportPath)

                                    '	Next

                                    'End If

                                    ExportFiles(Agency, ToFileOption, PrintSettings.ExportPath, Report, BackupReport, DocumentList, AccountReceivableInvoice, InvoicePrintingPageSetting, OverrideInvoiceFilename)

                                End If

                            Next

                        End If

                    Next

                End If

            End Using

        End Sub
        Private Sub PackageToSingleFile(Session As AdvantageFramework.Security.Session,
                                        DbContext As AdvantageFramework.Database.DbContext,
                                        ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                        PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings,
                                        AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                        InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                                        InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                                        ByRef FullReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef FullBackupReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                        ByRef FullMediaReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                        IsDraft As Boolean)

            'objects
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

            FullReport = Nothing
            FullBackupReport = Nothing
            DocumentList = Nothing
            FullMediaReport = Nothing
            MediaDocumentList = Nothing

            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
            MediaDocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "C").ToList

                If FullReport Is Nothing Then

                    FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                    If FullReport IsNot Nothing Then

                        FullReport.CreateDocument()

                    End If

                Else

                    Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                    If Report IsNot Nothing Then

                        Report.CreateDocument()

                        FullReport.Pages.AddRange(Report.Pages)

                    End If

                End If

            Next

            Report = Nothing

            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) Then

                For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "P").ToList

                    If FullReport Is Nothing Then

                        FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If FullReport IsNot Nothing Then

                            FullReport.CreateDocument()

                        End If

                    Else

                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If Report IsNot Nothing Then

                            Report.CreateDocument()

                            FullReport.Pages.AddRange(Report.Pages)

                        End If

                    End If

                Next

                Report = Nothing

                If InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) = True Then

                    For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "P").ToList

                        If FullReport Is Nothing Then

                            FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft)

                            If FullReport IsNot Nothing Then

                                FullReport.CreateDocument()

                            End If

                        Else

                            Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                        AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft)

                            If Report IsNot Nothing Then

                                Report.CreateDocument()

                                FullReport.Pages.AddRange(Report.Pages)

                            End If

                        End If

                    Next

                End If

            End If

            For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType <> "P").ToList

                If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName)) Then

                    If FullMediaReport Is Nothing Then

                        FullMediaReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                             AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If FullMediaReport IsNot Nothing Then

                            FullMediaReport.CreateDocument()

                        End If

                    Else

                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                    AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If Report IsNot Nothing Then

                            Report.CreateDocument()

                            FullMediaReport.Pages.AddRange(Report.Pages)

                        End If

                    End If

                End If

            Next

        End Sub
        Private Sub PackageToSingleFile(Session As AdvantageFramework.Security.Session,
                                        DbContext As AdvantageFramework.Database.DbContext,
                                        ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                        EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings,
                                        AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                        InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                                        InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                        InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                                        ByRef FullReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef FullBackupReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                        ByRef FullMediaReport As DevExpress.XtraReports.UI.XtraReport,
                                        ByRef MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                        IsDraft As Boolean)

            'objects
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

            FullReport = Nothing
            FullBackupReport = Nothing
            DocumentList = Nothing
            FullMediaReport = Nothing
            MediaDocumentList = Nothing

            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
            MediaDocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)

            For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "C").ToList

                If FullReport Is Nothing Then

                    FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                    If FullReport IsNot Nothing Then

                        FullReport.CreateDocument()

                    End If

                Else

                    Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                    If Report IsNot Nothing Then

                        Report.CreateDocument()

                        FullReport.Pages.AddRange(Report.Pages)

                    End If

                End If

            Next

            Report = Nothing

            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) Then

                For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "P").ToList

                    If FullReport Is Nothing Then

                        FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If FullReport IsNot Nothing Then

                            FullReport.CreateDocument()

                        End If

                    Else

                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If Report IsNot Nothing Then

                            Report.CreateDocument()

                            FullReport.Pages.AddRange(Report.Pages)

                        End If

                    End If

                Next

                Report = Nothing

                If InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) = True Then

                    For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType = "P").ToList

                        If FullReport Is Nothing Then

                            FullReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft)

                            If FullReport IsNot Nothing Then

                                FullReport.CreateDocument()

                            End If

                        Else

                            Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                        AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft)

                            If Report IsNot Nothing Then

                                Report.CreateDocument()

                                FullReport.Pages.AddRange(Report.Pages)

                            End If

                        End If

                    Next

                End If

            End If

            For Each AccountReceivableInvoice In AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType <> "P" AndAlso Entity.RecordType <> "C").ToList

                If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName)) OrElse
                        (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName)) Then

                    If FullMediaReport Is Nothing Then

                        FullMediaReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                             AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If FullMediaReport IsNot Nothing Then

                            FullMediaReport.CreateDocument()

                        End If

                    Else

                        Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                    AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

                        If Report IsNot Nothing Then

                            Report.CreateDocument()

                            FullMediaReport.Pages.AddRange(Report.Pages)

                        End If

                    End If

                End If

            Next

        End Sub
        Public Sub AutoEmailInvoices(ParentForm As System.Windows.Forms.Form, Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                     InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, IsDraft As Boolean, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                     UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting)


            'objects
            Dim ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim EmailSetting As AdvantageFramework.InvoicePrinting.Classes.EmailSettings = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim ReportExportPath As String = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim EmailStatusReports As Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.EmailStatusReport) = Nothing
            Dim EmailSent As Boolean = False
            Dim ErrorMessage As String = ""
            Dim FailedToPrint As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim ContactsCount As Integer = 0
            Dim ContactsCounter As Integer = 1
            Dim SMTP As MailBee.SmtpMail.Smtp = Nothing
            Dim [From] As String = ""
            Dim ReplyTo As String = ""
            Dim MaxEmailSize As Long = 0
            Dim MediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim DocumentIndex As Integer = 0
            Dim CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
            Dim AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact) = Nothing
            Dim SingleEmailGroups As Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.SingleEmailGroup) = Nothing
            Dim SingleEmailGroup As AdvantageFramework.Billing.Reports.Presentation.Classes.SingleEmailGroup = Nothing
            Dim OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default

            If AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingAutoEmailDialog.ShowFormDialog(AccountReceivableInvoices, ToFileOption, EmailSetting) = Windows.Forms.DialogResult.OK AndAlso EmailSetting IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...", ParentForm)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

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

                                MaxEmailSize = AdvantageFramework.Email.LoadMaxEmailSize(DbContext)
                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                                SMTP = CreateSMTP(DbContext, SecurityDbContext, Agency, From, ReplyTo)

                                If String.IsNullOrWhiteSpace(EmailSetting.FromEmail) = False Then

                                    From = EmailSetting.FromEmail

                                End If

                                If String.IsNullOrWhiteSpace(EmailSetting.ReplyTo) = False Then

                                    ReplyTo = EmailSetting.ReplyTo

                                End If

                                InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
                                InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

                                AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
                                OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

                                InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

                                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                    Try

                                        CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                                    Catch ex As Exception
                                        CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
                                    End Try

                                    Try

                                        OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.LoadOverrideInvoiceFilename(DataContext)

                                    Catch ex As Exception
                                        OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default
                                    End Try

                                End Using

                                EmailStatusReports = New Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.EmailStatusReport)

                                If EmailSetting.SendSingleEmail Then

                                    SingleEmailGroups = New Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.SingleEmailGroup)

                                    For Each AutoEmailContact In EmailSetting.AutoEmailContacts.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ThenBy(Function(Entity) Entity.ClientContactCode).ToList

                                        SingleEmailGroup = New AdvantageFramework.Billing.Reports.Presentation.Classes.SingleEmailGroup(AutoEmailContact)

                                        If SingleEmailGroups.Any(Function(Entity) Entity.Equals(SingleEmailGroup) = True) = False Then

                                            SingleEmailGroups.Add(SingleEmailGroup)

                                        End If

                                    Next

                                    If SingleEmailGroups IsNot Nothing AndAlso SingleEmailGroups.Count > 0 Then

                                        ContactsCount = SingleEmailGroups.Count

                                        For Each SingleEmailGroup In SingleEmailGroups

                                            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing " & ContactsCounter & " of " & ContactsCount & "...", ParentForm)

                                            AutoEmailContacts = EmailSetting.AutoEmailContacts.Where(Function(Entity) Entity.ClientCode = SingleEmailGroup.ClientCode AndAlso Entity.DivisionCode = SingleEmailGroup.DivisionCode AndAlso Entity.ProductCode = SingleEmailGroup.ProductCode AndAlso Entity.Type = SingleEmailGroup.Type).ToList

                                            If AutoEmailContacts IsNot Nothing AndAlso AutoEmailContacts.Count > 0 Then

                                                If AutoEmailContacts.Any(Function(Entity) Entity.Email) OrElse AutoEmailContacts.Any(Function(Entity) Entity.Print) Then

                                                    If String.IsNullOrWhiteSpace(SingleEmailGroup.ProductCode) = False Then

                                                        If SingleEmailGroup.Type = "Production" Then

                                                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = SingleEmailGroup.ClientCode AndAlso
                                                                                                                                               Entity.DivisionCode = SingleEmailGroup.DivisionCode AndAlso
                                                                                                                                               Entity.ProductCode = SingleEmailGroup.ProductCode AndAlso Entity.RecordType = "P").ToList

                                                        Else

                                                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = SingleEmailGroup.ClientCode AndAlso
                                                                                                                                               Entity.DivisionCode = SingleEmailGroup.DivisionCode AndAlso
                                                                                                                                               Entity.ProductCode = SingleEmailGroup.ProductCode AndAlso Entity.RecordType <> "P").ToList

                                                        End If

                                                    Else

                                                        If SingleEmailGroup.Type = "Production" Then

                                                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = SingleEmailGroup.ClientCode AndAlso Entity.RecordType = "P").ToList

                                                        Else

                                                            ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = SingleEmailGroup.ClientCode AndAlso Entity.RecordType <> "P").ToList

                                                        End If

                                                    End If

                                                    If ClientAccountReceivableInvoices.Count > 0 Then

                                                        If EmailSetting.PackageType = InvoicePrinting.PackageTypes.OneZip Then

                                                            AutoEmailInvoices_OneZip(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                                     UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                     AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                                     EmailStatusReports, SMTP, MaxEmailSize, AutoEmailContacts, ClientAccountReceivableInvoices, OverrideInvoiceFilename)

                                                        ElseIf EmailSetting.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then

                                                            AutoEmailInvoices_OneZipPerInvoice(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                                               UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                               AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                                               EmailStatusReports, SMTP, MaxEmailSize, AutoEmailContacts, ClientAccountReceivableInvoices, OverrideInvoiceFilename)

                                                        Else

                                                            AutoEmailInvoices_NoZip(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                                    UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                    AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                                    EmailStatusReports, SMTP, MaxEmailSize, AutoEmailContacts, ClientAccountReceivableInvoices, OverrideInvoiceFilename)

                                                        End If

                                                    End If

                                                End If

                                            End If

                                            ContactsCounter += 1

                                        Next

                                    End If

                                Else

                                    ContactsCount = EmailSetting.AutoEmailContacts.Count

                                    For Each AutoEmailContact In EmailSetting.AutoEmailContacts.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ThenBy(Function(Entity) Entity.ClientContactCode).ToList

                                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing " & ContactsCounter & " of " & ContactsCount & "...", ParentForm)

                                        InvoicePrintingSetting = Nothing
                                        InvoicePrintingMediaSetting = Nothing
                                        InvoicePrintingComboSetting = Nothing
                                        Attachments = Nothing
                                        Report = Nothing
                                        DefaultFileName = Nothing
                                        DefaultBackupFileName = Nothing
                                        MemoryStream = Nothing
                                        CoverSheetReport = Nothing

                                        If AutoEmailContact.Email OrElse AutoEmailContact.Print Then

                                            If String.IsNullOrWhiteSpace(AutoEmailContact.ProductCode) = False Then

                                                If AutoEmailContact.Type = "Production" Then

                                                    ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode AndAlso
                                                                                                                                   Entity.DivisionCode = AutoEmailContact.DivisionCode AndAlso
                                                                                                                                   Entity.ProductCode = AutoEmailContact.ProductCode AndAlso Entity.RecordType = "P").ToList

                                                Else

                                                    ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode AndAlso
                                                                                                                                   Entity.DivisionCode = AutoEmailContact.DivisionCode AndAlso
                                                                                                                                   Entity.ProductCode = AutoEmailContact.ProductCode AndAlso Entity.RecordType <> "P").ToList

                                                End If

                                            Else

                                                If AutoEmailContact.Type = "Production" Then

                                                    ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode AndAlso Entity.RecordType = "P").ToList

                                                Else

                                                    ClientAccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode AndAlso Entity.RecordType <> "P").ToList

                                                End If

                                            End If

                                            If ClientAccountReceivableInvoices.Count > 0 Then

                                                If EmailSetting.PackageType = InvoicePrinting.PackageTypes.OneZip Then

                                                    AutoEmailInvoices_OneZip(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                             UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                             AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                             EmailStatusReports, SMTP, MaxEmailSize, New List(Of InvoicePrinting.Classes.AutoEmailContact)({AutoEmailContact}),
                                                                             ClientAccountReceivableInvoices, OverrideInvoiceFilename)


                                                    'Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                                    'ZipFile = New Ionic.Zip.ZipFile

                                                    'If EmailSetting.SinglePDF Then

                                                    '    DocumentList = Nothing
                                                    '    InvoicePrintingMediaSetting = Nothing
                                                    '    InvoicePrintingSetting = Nothing
                                                    '    InvoicePrintingComboSetting = Nothing
                                                    '    Report = Nothing
                                                    '    BackupReport = Nothing
                                                    '    DefaultFileName = ""
                                                    '    DefaultBackupFileName = ""
                                                    '    ZipFileName = ""
                                                    '    IsCustomReport = False
                                                    '    MediaReport = Nothing
                                                    '    MediaDocumentList = Nothing

                                                    '    If EmailSetting.IncludeCoverSheet Then

                                                    '        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                    '                                                                             InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    '        If CoverSheetReport IsNot Nothing Then

                                                    '            If AutoEmailContact.Print Then

                                                    '                CoverSheetReport.DisplayName = AutoEmailContact.ClientCode & " - Coversheet"
                                                    '                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                                    '                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                                    '                End If

                                                    '                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                    FailedToPrint = True

                                                    '                End If

                                                    '            End If

                                                    '            If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & AutoEmailContact.ClientCode & " CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing)

                                                    '            End If

                                                    '        End If

                                                    '    End If

                                                    '    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    '        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)
                                                    '        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)
                                                    '        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)

                                                    '    Else

                                                    '        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    '        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    '        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    '    End If

                                                    '    PackageToSingleFile(Session, DbContext, ToFileOption, EmailSetting, ClientAccountReceivableInvoices,
                                                    '                    InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                                    '                    OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                                    '                    DocumentList, MediaReport, MediaDocumentList, IsDraft)

                                                    '    If Report IsNot Nothing Then

                                                    '        DefaultFileName = CreateSingleFileName(AutoEmailContact.ClientCode, False, False)

                                                    '        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '                ExportReport(Session, Report, CreateSingleFileName(AutoEmailContact.ClientCode, False, False),
                                                    '                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                                    '                 False, InvoicePrintingPageSetting, AccountReceivableInvoice)

                                                    '            Next

                                                    '        End If

                                                    '        If AutoEmailContact.Print Then

                                                    '            Report.DisplayName = DefaultFileName
                                                    '            Report.Name = Report.DisplayName

                                                    '            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                    '                Report.PrintingSystem.Document.Name = Report.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '    End If

                                                    '    If BackupReport IsNot Nothing Then

                                                    '        DefaultBackupFileName = CreateSingleFileName(AutoEmailContact.ClientCode, True, False)

                                                    '        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '                ExportReport(Session, BackupReport, CreateSingleFileName(AutoEmailContact.ClientCode, True, False),
                                                    '                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                                    '                 InvoicePrintingPageSetting, AccountReceivableInvoice)

                                                    '            Next

                                                    '        End If

                                                    '        If AutoEmailContact.Print Then

                                                    '            BackupReport.DisplayName = DefaultFileName
                                                    '            BackupReport.Name = BackupReport.DisplayName

                                                    '            If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '    End If

                                                    '    If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '        AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, Nothing, Nothing)

                                                    '    End If

                                                    '    If MediaReport IsNot Nothing Then

                                                    '        DefaultFileName = CreateSingleFileName(AutoEmailContact.ClientCode, False, True)

                                                    '        If AutoEmailContact.Print Then

                                                    '            MediaReport.DisplayName = DefaultFileName
                                                    '            MediaReport.Name = MediaReport.DisplayName

                                                    '            If MediaReport.PrintingSystem IsNot Nothing AndAlso MediaReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                MediaReport.PrintingSystem.Document.Name = MediaReport.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(MediaReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToZipFile(Agency, ToFileOption, DefaultFileName, MediaReport, "", Nothing, "", Nothing, MediaDocumentList, ZipFile, Nothing, Nothing)

                                                    '        End If

                                                    '    End If

                                                    'Else

                                                    '    If EmailSetting.IncludeCoverSheet Then

                                                    '        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                    '                                                                             InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                    '                                                                             InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    '        If CoverSheetReport IsNot Nothing Then

                                                    '            If AutoEmailContact.Print Then

                                                    '                CoverSheetReport.DisplayName = AutoEmailContact.ClientCode & " - Coversheet"
                                                    '                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                                    '                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                                    '                End If

                                                    '                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                    FailedToPrint = True

                                                    '                End If

                                                    '            End If

                                                    '            If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & AutoEmailContact.ClientCode & " - CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing)

                                                    '            End If

                                                    '        End If

                                                    '    End If

                                                    '    For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '        DocumentList = Nothing
                                                    '        InvoicePrintingMediaSetting = Nothing
                                                    '        InvoicePrintingSetting = Nothing
                                                    '        InvoicePrintingComboSetting = Nothing
                                                    '        Report = Nothing
                                                    '        BackupReport = Nothing
                                                    '        DefaultFileName = ""
                                                    '        DefaultBackupFileName = ""
                                                    '        ZipFileName = ""
                                                    '        IsCustomReport = False
                                                    '        SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
                                                    '        EmailSent = False
                                                    '        ErrorMessage = ""

                                                    '        If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    '            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            End If

                                                    '        Else

                                                    '            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    '                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    '            End If

                                                    '        End If

                                                    '        If InvoicePrintingComboSetting IsNot Nothing Then

                                                    '            'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                    '            '    IsCustomReport = True

                                                    '            'End If

                                                    '        ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                    '            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                    '                IsCustomReport = True

                                                    '            End If

                                                    '        ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                    '            If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                    '                IsCustomReport = True

                                                    '            End If

                                                    '        End If

                                                    '        If IsCustomReport = False Then

                                                    '            Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                    '                InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                    '                InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                    '            If Report IsNot Nothing Then

                                                    '                DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                                    '                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                    ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                    '                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, AccountReceivableInvoice)

                                                    '                End If

                                                    '                If AutoEmailContact.Print Then

                                                    '                    Report.DisplayName = DefaultFileName
                                                    '                    Report.Name = Report.DisplayName

                                                    '                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                    '                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                                    '                    End If

                                                    '                    If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                                    '                        FailedToPrint = True

                                                    '                    End If

                                                    '                End If

                                                    '            End If

                                                    '            If BackupReport IsNot Nothing Then

                                                    '                DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                                    '                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                    ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                    '                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, AccountReceivableInvoice)

                                                    '                End If

                                                    '                If AutoEmailContact.Print Then

                                                    '                    BackupReport.DisplayName = DefaultBackupFileName
                                                    '                    BackupReport.Name = BackupReport.DisplayName

                                                    '                    If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                        BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                                    '                    End If

                                                    '                    If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                        FailedToPrint = True

                                                    '                    End If

                                                    '                End If

                                                    '            End If

                                                    '            If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, AccountReceivableInvoice, Nothing)

                                                    '            End If

                                                    '        End If

                                                    '    Next

                                                    'End If

                                                    'System.GC.Collect()

                                                    'If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) AndAlso ZipFile.Entries.Count > 0 Then

                                                    '    ZipFileName = AutoEmailContact.ClientCode & " - Invoices"

                                                    '    Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                                                    '        ZipFileName = AutoEmailContact.ClientCode & " - Invoices(" & Counter & ")"

                                                    '        Counter = Counter + 1

                                                    '    Loop

                                                    '    ZipFileName = ZipFileName & ".zip"

                                                    '    ZipFile.Save(ZipFileName)

                                                    '    Try

                                                    '        ZipFile.Dispose()

                                                    '        ZipFile = Nothing

                                                    '    Catch ex As Exception

                                                    '    End Try

                                                    '    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                                                    '    If EmailSetting.CCToSender Then

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    Else

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    End If

                                                    '    If EmailSent Then

                                                    '        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                                                    '        Next

                                                    '    End If

                                                    '    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, AutoEmailContact.EmailAddress, ErrorMessage))

                                                    '    Try

                                                    '        For Each Attachment In Attachments

                                                    '            If String.IsNullOrWhiteSpace(Attachment.File) = False Then

                                                    '                My.Computer.FileSystem.DeleteFile(Attachment.File)

                                                    '            End If

                                                    '        Next

                                                    '    Catch ex As Exception

                                                    '    End Try

                                                    'End If

                                                ElseIf EmailSetting.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice Then

                                                    AutoEmailInvoices_OneZipPerInvoice(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                                       UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                       AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                                       EmailStatusReports, SMTP, MaxEmailSize, New List(Of InvoicePrinting.Classes.AutoEmailContact)({AutoEmailContact}),
                                                                                       ClientAccountReceivableInvoices, OverrideInvoiceFilename)

                                                    'Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                                    'ZipFileName = ""

                                                    'If EmailSetting.IncludeCoverSheet Then

                                                    '    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                    '                                                                         InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                    '                                                                         InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    '    If CoverSheetReport IsNot Nothing Then

                                                    '        If AutoEmailContact.Print Then

                                                    '            CoverSheetReport.DisplayName = AutoEmailContact.ClientCode & " - Coversheet"
                                                    '            CoverSheetReport.Name = CoverSheetReport.DisplayName

                                                    '            If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToAttachments(ToFileOption, AutoEmailContact.ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing)

                                                    '        End If

                                                    '    End If

                                                    'End If

                                                    'For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '    DocumentList = Nothing
                                                    '    InvoicePrintingMediaSetting = Nothing
                                                    '    InvoicePrintingSetting = Nothing
                                                    '    InvoicePrintingComboSetting = Nothing
                                                    '    Report = Nothing
                                                    '    BackupReport = Nothing
                                                    '    DefaultFileName = ""
                                                    '    DefaultBackupFileName = ""
                                                    '    ZipFileName = ""
                                                    '    IsCustomReport = False
                                                    '    SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
                                                    '    EmailSent = False
                                                    '    ErrorMessage = ""

                                                    '    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    '        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '            InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '        End If

                                                    '    Else

                                                    '        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                    '        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                    '        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    '            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    '            InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    '        End If

                                                    '    End If

                                                    '    If InvoicePrintingComboSetting IsNot Nothing Then

                                                    '        'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                    '        '    IsCustomReport = True

                                                    '        'End If

                                                    '    ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                    '        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                    '            IsCustomReport = True

                                                    '        End If

                                                    '    ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                    '        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                    '                (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                    '                (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                    '                (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                    '                (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                    '                (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                    '            IsCustomReport = True

                                                    '        End If

                                                    '    End If

                                                    '    If IsCustomReport = False Then

                                                    '        Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                    '            InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                    '            InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                    '        If Report IsNot Nothing Then

                                                    '            DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                                    '            If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                    '                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, AccountReceivableInvoice)

                                                    '            End If

                                                    '            If AutoEmailContact.Print Then

                                                    '                Report.DisplayName = DefaultFileName
                                                    '                Report.Name = Report.DisplayName

                                                    '                If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                    '                    Report.PrintingSystem.Document.Name = Report.DisplayName

                                                    '                End If

                                                    '                If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                                    '                    FailedToPrint = True

                                                    '                End If

                                                    '            End If

                                                    '        End If

                                                    '        If BackupReport IsNot Nothing Then

                                                    '            DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                                    '            If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                    '                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, AccountReceivableInvoice)

                                                    '            End If

                                                    '            If AutoEmailContact.Print Then

                                                    '                BackupReport.DisplayName = DefaultBackupFileName
                                                    '                BackupReport.Name = BackupReport.DisplayName

                                                    '                If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                    BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                                    '                End If

                                                    '                If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                    FailedToPrint = True

                                                    '                End If

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            CreateInvoiceZipFile(Agency, ToFileOption, AgencyImportPath, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFileName, AccountReceivableInvoice, Nothing)

                                                    '            Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                                                    '        End If

                                                    '    End If

                                                    'Next

                                                    'System.GC.Collect()

                                                    'If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) AndAlso Attachments.Count > 0 Then

                                                    '    If EmailSetting.CCToSender Then

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    Else

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    End If

                                                    '    If EmailSent Then

                                                    '        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                                                    '        Next

                                                    '    End If

                                                    '    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, AutoEmailContact.EmailAddress, ErrorMessage))

                                                    '    Try

                                                    '        For Each Attachment In Attachments

                                                    '            If String.IsNullOrWhiteSpace(Attachment.File) = False Then

                                                    '                My.Computer.FileSystem.DeleteFile(Attachment.File)

                                                    '            End If

                                                    '        Next

                                                    '    Catch ex As Exception

                                                    '    End Try

                                                    'End If

                                                Else

                                                    AutoEmailInvoices_NoZip(Session, DbContext, Agency, AgencyImportPath, EmailSetting, Employee, From, ReplyTo, InvoiceFormatType, IsDraft, ToFileOption,
                                                                            UserLookAndFeel, InvoicePrintingPageSetting, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                            AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, CoversheetLayout,
                                                                            EmailStatusReports, SMTP, MaxEmailSize, New List(Of InvoicePrinting.Classes.AutoEmailContact)({AutoEmailContact}),
                                                                            ClientAccountReceivableInvoices, OverrideInvoiceFilename)

                                                    'Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                                    'ZipFileName = ""

                                                    'If EmailSetting.SinglePDF Then

                                                    '    DocumentList = Nothing
                                                    '    InvoicePrintingMediaSetting = Nothing
                                                    '    InvoicePrintingSetting = Nothing
                                                    '    InvoicePrintingComboSetting = Nothing
                                                    '    Report = Nothing
                                                    '    BackupReport = Nothing
                                                    '    DefaultFileName = ""
                                                    '    DefaultBackupFileName = ""
                                                    '    ZipFileName = ""
                                                    '    IsCustomReport = False
                                                    '    MediaReport = Nothing
                                                    '    MediaDocumentList = Nothing

                                                    '    If EmailSetting.IncludeCoverSheet Then

                                                    '        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                    '                                                                             InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    '        If AutoEmailContact.Print Then

                                                    '            CoverSheetReport.DisplayName = AutoEmailContact.ClientCode & " - Coversheet"
                                                    '            CoverSheetReport.Name = CoverSheetReport.DisplayName

                                                    '            If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToAttachments(ToFileOption, AutoEmailContact.ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing)

                                                    '        End If

                                                    '    End If

                                                    '    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    '        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)
                                                    '        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)
                                                    '        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AutoEmailContact.ClientCode)

                                                    '    Else

                                                    '        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    '        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    '        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    '    End If

                                                    '    PackageToSingleFile(Session, DbContext, ToFileOption, EmailSetting, ClientAccountReceivableInvoices,
                                                    '                    InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                                    '                    OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                                    '                    DocumentList, MediaReport, MediaDocumentList, IsDraft)

                                                    '    If Report IsNot Nothing Then

                                                    '        DefaultFileName = CreateSingleFileName(AutoEmailContact.ClientCode, False, False)

                                                    '        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '                ExportReport(Session, Report, CreateSingleFileName(AutoEmailContact.ClientCode, False, False),
                                                    '                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                                    '                         False, InvoicePrintingPageSetting, AccountReceivableInvoice)

                                                    '            Next

                                                    '        End If

                                                    '        If AutoEmailContact.Print Then

                                                    '            Report.DisplayName = DefaultFileName
                                                    '            Report.Name = Report.DisplayName

                                                    '            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                    '                Report.PrintingSystem.Document.Name = Report.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments, InvoicePrintingPageSetting)

                                                    '        End If

                                                    '    End If

                                                    '    If BackupReport IsNot Nothing Then

                                                    '        DefaultBackupFileName = CreateSingleFileName(AutoEmailContact.ClientCode, True, False)

                                                    '        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '                ExportReport(Session, BackupReport, CreateSingleFileName(AutoEmailContact.ClientCode, True, False),
                                                    '                         AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                                    '                         InvoicePrintingPageSetting, AccountReceivableInvoice)

                                                    '            Next

                                                    '        End If

                                                    '        If AutoEmailContact.Print Then

                                                    '            BackupReport.DisplayName = DefaultBackupFileName
                                                    '            BackupReport.Name = BackupReport.DisplayName

                                                    '            If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                BackupReport.PrintingSystem.Document.Name = Report.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToAttachments(ToFileOption, DefaultFileName, BackupReport, Attachments, InvoicePrintingPageSetting)

                                                    '        End If

                                                    '    End If

                                                    '    If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                                                    '        AddToDocumentsToAttachments(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                                                    '    End If

                                                    '    If MediaReport IsNot Nothing Then

                                                    '        DefaultFileName = CreateSingleFileName(AutoEmailContact.ClientCode, False, True)

                                                    '        If AutoEmailContact.Print Then

                                                    '            MediaReport.DisplayName = DefaultBackupFileName
                                                    '            MediaReport.Name = MediaReport.DisplayName

                                                    '            If MediaReport.PrintingSystem IsNot Nothing AndAlso MediaReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                MediaReport.PrintingSystem.Document.Name = Report.DisplayName

                                                    '            End If

                                                    '            If AdvantageFramework.Reporting.Reports.SendToPrinter(MediaReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                FailedToPrint = True

                                                    '            End If

                                                    '        End If

                                                    '        If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '            AddToAttachments(ToFileOption, DefaultFileName, MediaReport, Attachments, InvoicePrintingPageSetting)

                                                    '        End If

                                                    '    End If

                                                    '    If MediaDocumentList IsNot Nothing AndAlso MediaDocumentList.Count > 0 Then

                                                    '        AddToDocumentsToAttachments(Agency, MediaDocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                                                    '    End If

                                                    'Else

                                                    '    If EmailSetting.IncludeCoverSheet Then

                                                    '        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                    '                                                                             InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                    '                                                                             InvoiceFormatType, IsDraft, CoversheetLayout)

                                                    '        If CoverSheetReport IsNot Nothing Then

                                                    '            If AutoEmailContact.Print Then

                                                    '                CoverSheetReport.DisplayName = AutoEmailContact.ClientCode & " - Coversheet"
                                                    '                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                                    '                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                                    '                End If

                                                    '                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                    FailedToPrint = True

                                                    '                End If

                                                    '            End If

                                                    '            If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                AddToAttachments(ToFileOption, AutoEmailContact.ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing)

                                                    '            End If

                                                    '        End If

                                                    '    End If

                                                    '    For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '        DocumentList = Nothing
                                                    '        InvoicePrintingMediaSetting = Nothing
                                                    '        InvoicePrintingSetting = Nothing
                                                    '        InvoicePrintingComboSetting = Nothing
                                                    '        Report = Nothing
                                                    '        BackupReport = Nothing
                                                    '        DefaultFileName = ""
                                                    '        DefaultBackupFileName = ""
                                                    '        ZipFileName = ""
                                                    '        IsCustomReport = False

                                                    '        If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                                                    '            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                                    '                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                                                    '            End If

                                                    '        Else

                                                    '            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                                                    '            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                                    '                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                                    '                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                                    '                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                                                    '            End If

                                                    '        End If

                                                    '        If InvoicePrintingComboSetting IsNot Nothing Then

                                                    '            'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                                                    '            '    IsCustomReport = True

                                                    '            'End If

                                                    '        ElseIf InvoicePrintingSetting IsNot Nothing Then

                                                    '            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                                    '                IsCustomReport = True

                                                    '            End If

                                                    '        ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                                                    '            If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                    '                    (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                                    '                IsCustomReport = True

                                                    '            End If

                                                    '        End If

                                                    '        If IsCustomReport = False Then

                                                    '            Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                                    '                    InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                                    '                    InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                                                    '            If Report IsNot Nothing Then

                                                    '                DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                                    '                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                    ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                    '                                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, AccountReceivableInvoice)

                                                    '                End If

                                                    '                If AutoEmailContact.Print Then

                                                    '                    Report.DisplayName = DefaultFileName
                                                    '                    Report.Name = Report.DisplayName

                                                    '                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                                    '                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                                    '                    End If

                                                    '                    If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                                    '                        FailedToPrint = True

                                                    '                    End If

                                                    '                End If

                                                    '                If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments, InvoicePrintingPageSetting)

                                                    '                End If

                                                    '            End If

                                                    '            If BackupReport IsNot Nothing Then

                                                    '                DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                                    '                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                                    '                    ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                    '                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, AccountReceivableInvoice)

                                                    '                End If

                                                    '                If AutoEmailContact.Print Then

                                                    '                    BackupReport.DisplayName = DefaultBackupFileName
                                                    '                    BackupReport.Name = BackupReport.DisplayName

                                                    '                    If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                                    '                        BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                                    '                    End If

                                                    '                    If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                                    '                        FailedToPrint = True

                                                    '                    End If

                                                    '                End If

                                                    '                If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                                                    '                    AddToAttachments(ToFileOption, DefaultBackupFileName, BackupReport, Attachments, Nothing)

                                                    '                End If

                                                    '            End If

                                                    '        End If

                                                    '        If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                                                    '            Try

                                                    '                AdvantageFramework.DocumentManager.AddToAttachments(Agency, DocumentList.Select(Function(Entity) Entity.GetDocumentEntity()).ToList, Attachments)

                                                    '            Catch ex As Exception

                                                    '            End Try

                                                    '        End If

                                                    '    Next

                                                    'End If

                                                    'System.GC.Collect()

                                                    'If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) AndAlso Attachments.Count > 0 Then

                                                    '    If EmailSetting.CCToSender Then

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    Else

                                                    '        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                                                    '        EmailSent = SendEmail(SMTP, AutoEmailContact.EmailAddress, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                                    '                          Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                                                    '    End If

                                                    '    If EmailSent Then

                                                    '        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                                    '            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                                                    '        Next

                                                    '    End If

                                                    '    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, AutoEmailContact.EmailAddress, ErrorMessage))

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

                                            End If

                                        End If

                                        ContactsCounter += 1

                                    Next

                                End If

                                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Print Custom Legacy Formats...", ParentForm)

                                AdvantageFramework.Reporting.Reports.CreateCustomInvoice(Session, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings, IsDraft,
                                                                                         AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.AutoEmail, EmailSetting)

                            End If

                        End Using

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                If (EmailStatusReports IsNot Nothing AndAlso (EmailStatusReports.All(Function(Entity) Entity.EmailSent = True AndAlso Entity.SendingEmailStatus = Email.SendingEmailStatus.EmailSent) AndAlso FailedToPrint = False)) OrElse (Attachments IsNot Nothing AndAlso Attachments.Count = 0) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Invoices have been sent/printed.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Failed creating,sending and/or printing invoices.  Please contact software support.")

                End If

            End If

        End Sub
        Private Sub AutoEmailInvoices_OneZip(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext,
                                             Agency As AdvantageFramework.Database.Entities.Agency,
                                             AgencyImportPath As String,
                                             EmailSetting As AdvantageFramework.InvoicePrinting.Classes.EmailSettings,
                                             Employee As AdvantageFramework.Database.Views.Employee,
                                             [From] As String, ReplyTo As String,
                                             InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
                                             IsDraft As Boolean, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                             InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                             InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                             InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                             AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                             OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                             InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
                                             CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts,
                                             ByRef EmailStatusReports As Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.EmailStatusReport),
                                             SMTP As MailBee.SmtpMail.Smtp,
                                             MaxEmailSize As Long,
                                             AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact),
                                             ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                             OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim EmailSent As Boolean = False
            Dim ErrorMessage As String = ""
            Dim FailedToPrint As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim EmailReport As Boolean = False
            Dim PrintReport As Boolean = False
            Dim HasOneValidEmailAddress As Boolean = False
            Dim ClientCode As String = String.Empty
            Dim EmailAddresses As String = String.Empty

            If AutoEmailContacts IsNot Nothing AndAlso AutoEmailContacts.Count > 0 Then

                EmailReport = AutoEmailContacts.Any(Function(Entity) Entity.Email = True)
                PrintReport = AutoEmailContacts.Any(Function(Entity) Entity.Print = True)
                HasOneValidEmailAddress = AutoEmailContacts.Any(Function(Entity) Entity.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(Entity.EmailAddress))
                ClientCode = AutoEmailContacts(0).ClientCode

                For Each AutoEmailContact In AutoEmailContacts

                    If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                        If String.IsNullOrWhiteSpace(EmailAddresses) = True Then

                            EmailAddresses = AutoEmailContact.EmailAddress

                        Else

                            EmailAddresses &= "; " & AutoEmailContact.EmailAddress

                        End If

                    End If

                Next

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                ZipFile = New Ionic.Zip.ZipFile

                If EmailSetting.SinglePDF Then

                    DocumentList = Nothing
                    InvoicePrintingMediaSetting = Nothing
                    InvoicePrintingSetting = Nothing
                    InvoicePrintingComboSetting = Nothing
                    Report = Nothing
                    BackupReport = Nothing
                    DefaultFileName = ""
                    DefaultBackupFileName = ""
                    ZipFileName = ""
                    IsCustomReport = False
                    MediaReport = Nothing
                    MediaDocumentList = Nothing

                    If EmailSetting.IncludeCoverSheet Then

                        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                                 InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                        If CoverSheetReport IsNot Nothing Then

                            If PrintReport Then

                                CoverSheetReport.DisplayName = ClientCode & " - Coversheet"
                                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                End If

                                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                    FailedToPrint = True

                                End If

                            End If

                            If EmailReport AndAlso HasOneValidEmailAddress Then

                                AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & ClientCode & " CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                            End If

                        End If

                    End If

                    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                    Else

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                    End If

                    PackageToSingleFile(Session, DbContext, ToFileOption, EmailSetting, ClientAccountReceivableInvoices,
                                        InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                        OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                        DocumentList, MediaReport, MediaDocumentList, IsDraft)

                    If Report IsNot Nothing Then

                        DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                ExportReport(Session, Report, CreateSingleFileName(ClientCode, False, False),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                             False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                            Next

                        End If

                        If PrintReport Then

                            Report.DisplayName = DefaultFileName
                            Report.Name = Report.DisplayName

                            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                Report.PrintingSystem.Document.Name = Report.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                    End If

                    If BackupReport IsNot Nothing Then

                        DefaultBackupFileName = CreateSingleFileName(ClientCode, True, False)

                        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                ExportReport(Session, BackupReport, CreateSingleFileName(ClientCode, True, False),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                             InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                            Next

                        End If

                        If PrintReport Then

                            BackupReport.DisplayName = DefaultFileName
                            BackupReport.Name = BackupReport.DisplayName

                            If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                    End If

                    If EmailReport AndAlso HasOneValidEmailAddress Then

                        AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                    End If

                    If MediaReport IsNot Nothing Then

                        DefaultFileName = CreateSingleFileName(ClientCode, False, True)

                        If PrintReport Then

                            MediaReport.DisplayName = DefaultFileName
                            MediaReport.Name = MediaReport.DisplayName

                            If MediaReport.PrintingSystem IsNot Nothing AndAlso MediaReport.PrintingSystem.Document IsNot Nothing Then

                                MediaReport.PrintingSystem.Document.Name = MediaReport.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(MediaReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToZipFile(Agency, ToFileOption, DefaultFileName, MediaReport, "", Nothing, "", Nothing, MediaDocumentList, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                        End If

                    End If

                Else

                    If EmailSetting.IncludeCoverSheet Then

                        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                 InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                 InvoiceFormatType, IsDraft, CoversheetLayout)

                        If CoverSheetReport IsNot Nothing Then

                            If PrintReport Then

                                CoverSheetReport.DisplayName = ClientCode & " - Coversheet"
                                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                End If

                                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                    FailedToPrint = True

                                End If

                            End If

                            If EmailReport AndAlso HasOneValidEmailAddress Then

                                AddToZipFile(Agency, ToFileOption, "", Nothing, "", Nothing, "!" & ClientCode & " - CoverSheet", CoverSheetReport, Nothing, ZipFile, Nothing, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                            End If

                        End If

                    End If

                    For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                        DocumentList = Nothing
                        InvoicePrintingMediaSetting = Nothing
                        InvoicePrintingSetting = Nothing
                        InvoicePrintingComboSetting = Nothing
                        Report = Nothing
                        BackupReport = Nothing
                        DefaultFileName = ""
                        DefaultBackupFileName = ""
                        ZipFileName = ""
                        IsCustomReport = False
                        SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
                        EmailSent = False
                        ErrorMessage = ""

                        If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            End If

                        Else

                            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                            End If

                        End If

                        If InvoicePrintingComboSetting IsNot Nothing Then

                            'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                            '    IsCustomReport = True

                            'End If

                        ElseIf InvoicePrintingSetting IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                IsCustomReport = True

                            End If

                        ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                            If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                IsCustomReport = True

                            End If

                        End If

                        If IsCustomReport = False Then

                            Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                    InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                    InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                            If Report IsNot Nothing Then

                                DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                    ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber,
                                                                                                  AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                End If

                                If PrintReport Then

                                    Report.DisplayName = DefaultFileName
                                    Report.Name = Report.DisplayName

                                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                    End If

                                    If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                        FailedToPrint = True

                                    End If

                                End If

                            End If

                            If BackupReport IsNot Nothing Then

                                DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                    ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber,
                                                                                                        AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                End If

                                If PrintReport Then

                                    BackupReport.DisplayName = DefaultBackupFileName
                                    BackupReport.Name = BackupReport.DisplayName

                                    If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                        BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                    End If

                                    If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                        FailedToPrint = True

                                    End If

                                End If

                            End If

                            If EmailReport AndAlso HasOneValidEmailAddress Then

                                AddToZipFile(Agency, ToFileOption, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "", Nothing, DocumentList, ZipFile, AccountReceivableInvoice, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                            End If

                        End If

                    Next

                End If

                System.GC.Collect()

                If EmailReport AndAlso HasOneValidEmailAddress AndAlso ZipFile.Entries.Count > 0 Then

                    ZipFileName = ClientCode & " - Invoices"

                    Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                        ZipFileName = ClientCode & " - Invoices(" & Counter & ")"

                        Counter = Counter + 1

                    Loop

                    ZipFileName = ZipFileName & ".zip"

                    ZipFile.Save(ZipFileName)

                    Try

                        ZipFile.Dispose()

                        ZipFile = Nothing

                    Catch ex As Exception

                    End Try

                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                    If EmailSetting.CCToSender Then

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, Employee.Email, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    Else

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, "", "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    End If

                    If EmailSent Then

                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                        Next

                    End If

                    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, EmailAddresses, ErrorMessage))

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

        End Sub
        Private Sub AutoEmailInvoices_OneZipPerInvoice(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext,
                                                       Agency As AdvantageFramework.Database.Entities.Agency,
                                                       AgencyImportPath As String,
                                                       EmailSetting As AdvantageFramework.InvoicePrinting.Classes.EmailSettings,
                                                       Employee As AdvantageFramework.Database.Views.Employee,
                                                       [From] As String, ReplyTo As String,
                                                       InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
                                                       IsDraft As Boolean, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                                       InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                                       InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                                       InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                                       AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                                       OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                                       InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
                                                       CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts,
                                                       ByRef EmailStatusReports As Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.EmailStatusReport),
                                                       SMTP As MailBee.SmtpMail.Smtp,
                                                       MaxEmailSize As Long,
                                                       AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact),
                                                       ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                                       OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim EmailSent As Boolean = False
            Dim ErrorMessage As String = ""
            Dim FailedToPrint As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim EmailReport As Boolean = False
            Dim PrintReport As Boolean = False
            Dim HasOneValidEmailAddress As Boolean = False
            Dim ClientCode As String = String.Empty
            Dim EmailAddresses As String = String.Empty

            If AutoEmailContacts IsNot Nothing AndAlso AutoEmailContacts.Count > 0 Then

                EmailReport = AutoEmailContacts.Any(Function(Entity) Entity.Email = True)
                PrintReport = AutoEmailContacts.Any(Function(Entity) Entity.Print = True)
                HasOneValidEmailAddress = AutoEmailContacts.Any(Function(Entity) Entity.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(Entity.EmailAddress))
                ClientCode = AutoEmailContacts(0).ClientCode

                For Each AutoEmailContact In AutoEmailContacts

                    If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                        If String.IsNullOrWhiteSpace(EmailAddresses) = True Then

                            EmailAddresses = AutoEmailContact.EmailAddress

                        Else

                            EmailAddresses &= "; " & AutoEmailContact.EmailAddress

                        End If

                    End If

                Next

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                ZipFileName = ""

                If EmailSetting.IncludeCoverSheet Then

                    CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                             InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                             InvoiceFormatType, IsDraft, CoversheetLayout)

                    If CoverSheetReport IsNot Nothing Then

                        If PrintReport Then

                            CoverSheetReport.DisplayName = ClientCode & " - Coversheet"
                            CoverSheetReport.Name = CoverSheetReport.DisplayName

                            If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToAttachments(ToFileOption, ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                        End If

                    End If

                End If

                For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                    DocumentList = Nothing
                    InvoicePrintingMediaSetting = Nothing
                    InvoicePrintingSetting = Nothing
                    InvoicePrintingComboSetting = Nothing
                    Report = Nothing
                    BackupReport = Nothing
                    DefaultFileName = ""
                    DefaultBackupFileName = ""
                    ZipFileName = ""
                    IsCustomReport = False
                    SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
                    EmailSent = False
                    ErrorMessage = ""

                    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                        End If

                    Else

                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                            InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                        End If

                    End If

                    If InvoicePrintingComboSetting IsNot Nothing Then

                        'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                        '    IsCustomReport = True

                        'End If

                    ElseIf InvoicePrintingSetting IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                            IsCustomReport = True

                        End If

                    ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                        If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                                                    (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                                                    (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                                                    (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                                                    (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                                                    (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                            IsCustomReport = True

                        End If

                    End If

                    If IsCustomReport = False Then

                        Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                        If Report IsNot Nothing Then

                            DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                            If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                            End If

                            If PrintReport Then

                                Report.DisplayName = DefaultFileName
                                Report.Name = Report.DisplayName

                                If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                    Report.PrintingSystem.Document.Name = Report.DisplayName

                                End If

                                If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                    FailedToPrint = True

                                End If

                            End If

                        End If

                        If BackupReport IsNot Nothing Then

                            DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                            If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                            End If

                            If PrintReport Then

                                BackupReport.DisplayName = DefaultBackupFileName
                                BackupReport.Name = BackupReport.DisplayName

                                If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                    BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                End If

                                If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                    FailedToPrint = True

                                End If

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            CreateInvoiceZipFile(Agency, ToFileOption, AgencyImportPath, DefaultFileName, Report, DefaultBackupFileName, BackupReport, "",
                                                 Nothing, DocumentList, ZipFileName, AccountReceivableInvoice, Nothing, AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default)

                            Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ZipFileName))

                        End If

                    End If

                Next

                System.GC.Collect()

                If EmailReport AndAlso HasOneValidEmailAddress AndAlso Attachments.Count > 0 Then

                    If EmailSetting.CCToSender Then

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, Employee.Email, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    Else

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, "", "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    End If

                    If EmailSent Then

                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                        Next

                    End If

                    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, EmailAddresses, ErrorMessage))

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

        End Sub
        Private Sub AutoEmailInvoices_NoZip(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext,
                                            Agency As AdvantageFramework.Database.Entities.Agency,
                                            AgencyImportPath As String,
                                            EmailSetting As AdvantageFramework.InvoicePrinting.Classes.EmailSettings,
                                            Employee As AdvantageFramework.Database.Views.Employee,
                                            [From] As String, ReplyTo As String,
                                            InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
                                            IsDraft As Boolean, ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions, UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                            InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                            InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                            InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                            AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                            OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                            InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
                                            CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts,
                                            ByRef EmailStatusReports As Generic.List(Of AdvantageFramework.Billing.Reports.Presentation.Classes.EmailStatusReport),
                                            SMTP As MailBee.SmtpMail.Smtp,
                                            MaxEmailSize As Long,
                                            AutoEmailContacts As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AutoEmailContact),
                                            ClientAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                            OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String = Nothing
            Dim DefaultBackupFileName As String = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.FailedToSend
            Dim BackupReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim ZipFileName As String = Nothing
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing
            Dim Counter As Integer = 0
            Dim IsCustomReport As Boolean = False
            Dim EmailSent As Boolean = False
            Dim ErrorMessage As String = ""
            Dim FailedToPrint As Boolean = False
            Dim CoverSheetReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim MediaDocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing
            Dim EmailReport As Boolean = False
            Dim PrintReport As Boolean = False
            Dim HasOneValidEmailAddress As Boolean = False
            Dim ClientCode As String = String.Empty
            Dim EmailAddresses As String = String.Empty

            If AutoEmailContacts IsNot Nothing AndAlso AutoEmailContacts.Count > 0 Then

                EmailReport = AutoEmailContacts.Any(Function(Entity) Entity.Email = True)
                PrintReport = AutoEmailContacts.Any(Function(Entity) Entity.Print = True)
                HasOneValidEmailAddress = AutoEmailContacts.Any(Function(Entity) Entity.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(Entity.EmailAddress))
                ClientCode = AutoEmailContacts(0).ClientCode

                For Each AutoEmailContact In AutoEmailContacts

                    If AutoEmailContact.Email AndAlso AdvantageFramework.StringUtilities.IsValidEmailAddress(AutoEmailContact.EmailAddress) Then

                        If String.IsNullOrWhiteSpace(EmailAddresses) = True Then

                            EmailAddresses = AutoEmailContact.EmailAddress

                        Else

                            EmailAddresses &= "; " & AutoEmailContact.EmailAddress

                        End If

                    End If

                Next

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                ZipFileName = ""

                If EmailSetting.SinglePDF Then

                    DocumentList = Nothing
                    InvoicePrintingMediaSetting = Nothing
                    InvoicePrintingSetting = Nothing
                    InvoicePrintingComboSetting = Nothing
                    Report = Nothing
                    BackupReport = Nothing
                    DefaultFileName = ""
                    DefaultBackupFileName = ""
                    ZipFileName = ""
                    IsCustomReport = False
                    MediaReport = Nothing
                    MediaDocumentList = Nothing

                    If EmailSetting.IncludeCoverSheet Then

                        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                                                                 InvoicePrintingComboSettings, InvoiceFormatType, IsDraft, CoversheetLayout)

                        If PrintReport Then

                            CoverSheetReport.DisplayName = ClientCode & " - Coversheet"
                            CoverSheetReport.Name = CoverSheetReport.DisplayName

                            If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToAttachments(ToFileOption, ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                        End If

                    End If

                    If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode)

                    Else

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                    End If

                    PackageToSingleFile(Session, DbContext, ToFileOption, EmailSetting, ClientAccountReceivableInvoices,
                                        InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting,
                                        OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSetting, Report, BackupReport,
                                        DocumentList, MediaReport, MediaDocumentList, IsDraft)

                    If Report IsNot Nothing Then

                        DefaultFileName = CreateSingleFileName(ClientCode, False, False)

                        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                ExportReport(Session, Report, CreateSingleFileName(ClientCode, False, False),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager,
                                             False, InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                            Next

                        End If

                        If PrintReport Then

                            Report.DisplayName = DefaultFileName
                            Report.Name = Report.DisplayName

                            If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                Report.PrintingSystem.Document.Name = Report.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments, InvoicePrintingPageSetting, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                        End If

                    End If

                    If BackupReport IsNot Nothing Then

                        DefaultBackupFileName = CreateSingleFileName(ClientCode, True, False)

                        If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                            For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                                ExportReport(Session, BackupReport, CreateSingleFileName(ClientCode, True, False),
                                             AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True,
                                             InvoicePrintingPageSetting, OverrideInvoiceFilename, AccountReceivableInvoice)

                            Next

                        End If

                        If PrintReport Then

                            BackupReport.DisplayName = DefaultBackupFileName
                            BackupReport.Name = BackupReport.DisplayName

                            If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                BackupReport.PrintingSystem.Document.Name = Report.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToAttachments(ToFileOption, DefaultFileName, BackupReport, Attachments, InvoicePrintingPageSetting, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                        End If

                    End If

                    If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                        AddToDocumentsToAttachments(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                    End If

                    If MediaReport IsNot Nothing Then

                        DefaultFileName = CreateSingleFileName(ClientCode, False, True)

                        If PrintReport Then

                            MediaReport.DisplayName = DefaultBackupFileName
                            MediaReport.Name = MediaReport.DisplayName

                            If MediaReport.PrintingSystem IsNot Nothing AndAlso MediaReport.PrintingSystem.Document IsNot Nothing Then

                                MediaReport.PrintingSystem.Document.Name = Report.DisplayName

                            End If

                            If AdvantageFramework.Reporting.Reports.SendToPrinter(MediaReport, False, UserLookAndFeel, False, False) = False Then

                                FailedToPrint = True

                            End If

                        End If

                        If EmailReport AndAlso HasOneValidEmailAddress Then

                            AddToAttachments(ToFileOption, DefaultFileName, MediaReport, Attachments, InvoicePrintingPageSetting, ClientAccountReceivableInvoices(0), OverrideInvoiceFilename)

                        End If

                    End If

                    If MediaDocumentList IsNot Nothing AndAlso MediaDocumentList.Count > 0 Then

                        AddToDocumentsToAttachments(Agency, MediaDocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, Attachments)

                    End If

                Else

                    If EmailSetting.IncludeCoverSheet Then

                        CoverSheetReport = AdvantageFramework.Reporting.Reports.CreateCoverSheet(Session, ClientAccountReceivableInvoices, InvoicePrintingSettings,
                                                                                                 InvoicePrintingMediaSettings, InvoicePrintingComboSettings,
                                                                                                 InvoiceFormatType, IsDraft, CoversheetLayout)

                        If CoverSheetReport IsNot Nothing Then

                            If PrintReport Then

                                CoverSheetReport.DisplayName = ClientCode & " - Coversheet"
                                CoverSheetReport.Name = CoverSheetReport.DisplayName

                                If CoverSheetReport.PrintingSystem IsNot Nothing AndAlso CoverSheetReport.PrintingSystem.Document IsNot Nothing Then

                                    CoverSheetReport.PrintingSystem.Document.Name = CoverSheetReport.DisplayName

                                End If

                                If AdvantageFramework.Reporting.Reports.SendToPrinter(CoverSheetReport, False, UserLookAndFeel, False, False) = False Then

                                    FailedToPrint = True

                                End If

                            End If

                            If EmailReport AndAlso HasOneValidEmailAddress Then

                                AddToAttachments(ToFileOption, ClientCode & " Cover Sheet", CoverSheetReport, Attachments, Nothing, ClientAccountReceivableInvoices(0), InvoicePrinting.OverrideInvoiceFilename.Default)

                            End If

                        End If

                    End If

                    For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                        DocumentList = Nothing
                        InvoicePrintingMediaSetting = Nothing
                        InvoicePrintingSetting = Nothing
                        InvoicePrintingComboSetting = Nothing
                        Report = Nothing
                        BackupReport = Nothing
                        DefaultFileName = ""
                        DefaultBackupFileName = ""
                        ZipFileName = ""
                        IsCustomReport = False

                        If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                            End If

                        Else

                            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                                InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                                InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                                InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                            End If

                        End If

                        If InvoicePrintingComboSetting IsNot Nothing Then

                            'If String.IsNullOrWhiteSpace(InvoicePrintingComboSetting.CustomFormatName) = False Then

                            '    IsCustomReport = True

                            'End If

                        ElseIf InvoicePrintingSetting IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                                IsCustomReport = True

                            End If

                        ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                            If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                    (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                                IsCustomReport = True

                            End If

                        End If

                        If IsCustomReport = False Then

                            Package(Session, DbContext, ToFileOption, EmailSetting.IncludeAPDocuments, EmailSetting.IncludeExpenseReportReceipts, AccountReceivableInvoice,
                                    InvoicePrintingSetting, InvoicePrintingMediaSetting, AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting,
                                    InvoicePrintingComboSetting, Report, BackupReport, DocumentList, IsDraft)

                            If Report IsNot Nothing Then

                                DefaultFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, False)

                                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                    ExportReport(Session, Report, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, False),
                                                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, False, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                End If

                                If PrintReport Then

                                    Report.DisplayName = DefaultFileName
                                    Report.Name = Report.DisplayName

                                    If Report.PrintingSystem IsNot Nothing AndAlso Report.PrintingSystem.Document IsNot Nothing Then

                                        Report.PrintingSystem.Document.Name = Report.DisplayName

                                    End If

                                    If AdvantageFramework.Reporting.Reports.SendToPrinter(Report, False, UserLookAndFeel, False, False) = False Then

                                        FailedToPrint = True

                                    End If

                                End If

                                If EmailReport AndAlso HasOneValidEmailAddress Then

                                    AddToAttachments(ToFileOption, DefaultFileName, Report, Attachments, InvoicePrintingPageSetting, AccountReceivableInvoice, OverrideInvoiceFilename)

                                End If

                            End If

                            If BackupReport IsNot Nothing Then

                                DefaultBackupFileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, True)

                                If EmailSetting.SendToDocumentManager OrElse (EmailSetting.IncludeAPDocuments OrElse EmailSetting.IncludeExpenseReportReceipts) Then

                                    ExportReport(Session, BackupReport, CreateARDocumentManagerFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.RecordType, AccountReceivableInvoice.ClientCode, True),
                                                 AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager, True, Nothing, OverrideInvoiceFilename, AccountReceivableInvoice)

                                End If

                                If PrintReport Then

                                    BackupReport.DisplayName = DefaultBackupFileName
                                    BackupReport.Name = BackupReport.DisplayName

                                    If BackupReport.PrintingSystem IsNot Nothing AndAlso BackupReport.PrintingSystem.Document IsNot Nothing Then

                                        BackupReport.PrintingSystem.Document.Name = BackupReport.DisplayName

                                    End If

                                    If AdvantageFramework.Reporting.Reports.SendToPrinter(BackupReport, False, UserLookAndFeel, False, False) = False Then

                                        FailedToPrint = True

                                    End If

                                End If

                                If EmailReport AndAlso HasOneValidEmailAddress Then

                                    AddToAttachments(ToFileOption, DefaultBackupFileName, BackupReport, Attachments, Nothing, AccountReceivableInvoice, OverrideInvoiceFilename)

                                End If

                            End If

                        End If

                        If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                            Try

                                AdvantageFramework.DocumentManager.AddToAttachments(Agency, DocumentList.Select(Function(Entity) Entity.GetDocumentEntity()).ToList, Attachments)

                            Catch ex As Exception

                            End Try

                        End If

                    Next

                End If

                System.GC.Collect()

                If EmailReport AndAlso HasOneValidEmailAddress AndAlso Attachments.Count > 0 Then

                    If EmailSetting.CCToSender Then

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, Employee.Email, "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    Else

                        'EmailSent = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee.Email, EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal), Attachments, SendingEmailStatus, ErrorMessage)
                        EmailSent = SendEmail(SMTP, EmailAddresses, "", "", EmailSetting.Subject, EmailSetting.Body, CInt(AlertSystem.PriorityLevels.Normal),
                                              Attachments, SendingEmailStatus, Agency, EmailSetting.SenderName, From, ReplyTo, MaxEmailSize)

                    End If

                    If EmailSent Then

                        For Each AccountReceivableInvoice In ClientAccountReceivableInvoices

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                        Next

                    End If

                    EmailStatusReports.Add(New Classes.EmailStatusReport(EmailSent, SendingEmailStatus, EmailAddresses, ErrorMessage))

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

        End Sub
        Public Function LoadLastInvoiceDate(Session As AdvantageFramework.Security.Session) As Date

            'objects
            Dim LastInvoiceDate As Date = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    LastInvoiceDate = DbContext.Database.SqlQuery(Of Date)("SELECT MAX(AR.AR_INV_DATE) FROM (SELECT AR.AR_INV_NBR, AR.AR_TYPE, [AR_INV_DATE] = MAX(AR.AR_INV_DATE) FROM [dbo].[ACCT_REC] AS AR WHERE AR.AR_INV_NBR NOT IN (SELECT AR_INV_NBR FROM dbo.ACCT_REC WHERE AR_TYPE = 'VO') GROUP BY AR.AR_INV_NBR, AR.AR_TYPE) AS AR").FirstOrDefault

                Catch ex As Exception
                    LastInvoiceDate = Now
                End Try

            End Using

            LoadLastInvoiceDate = LastInvoiceDate

        End Function
        Private Sub ExportFiles(Agency As AdvantageFramework.Database.Entities.Agency,
                                ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                ExportPath As String,
                                Report As DevExpress.XtraReports.UI.XtraReport,
                                BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

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

                    If InvoicePrintingPageSetting IsNot Nothing Then

                        InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                    End If

                    If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                        ReportName = ExportPath & AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                        ReportName = ExportPath & CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                        ReportName = ExportPath & CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.DivisionCode, AccountReceivableInvoice.ProductCode, AccountReceivableInvoice.CampaignCode)

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                        ReportName = ExportPath & CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    End If

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
                                 InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                 OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename,
                                 AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

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
            Dim ErrorMessage As String = Nothing

            If Report IsNot Nothing Then

                If InvoicePrintingPageSetting IsNot Nothing AndAlso IsBackup = False Then

                    InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                End If

                If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                    'do nothing

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence AndAlso AccountReceivableInvoice IsNot Nothing Then

                    FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly AndAlso AccountReceivableInvoice IsNot Nothing Then

                    FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode AndAlso AccountReceivableInvoice IsNot Nothing Then

                    FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.DivisionCode, AccountReceivableInvoice.ProductCode, AccountReceivableInvoice.CampaignCode)

                End If

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
        Private Sub Package(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext,
                            ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                            IncludeAPDocuments As Boolean,
                            IncludeExpenseReportReceipts As Boolean,
                            AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                            InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                            InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                            AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                            OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                            InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                            ByRef Report As DevExpress.XtraReports.UI.XtraReport,
                            ByRef BackupReport As DevExpress.XtraReports.UI.XtraReport,
                            ByRef DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                            IsDraft As Boolean)

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            Report = Nothing
            BackupReport = Nothing
            DocumentList = Nothing

            DocumentList = New Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)
            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            Report = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                        AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, False, IsDraft)

            If (AccountReceivableInvoice.RecordType = "P" AndAlso ToFileOption <> AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager AndAlso
                InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) = True) Then

                BackupReport = AdvantageFramework.Reporting.Reports.CreateInvoice(Session, AccountReceivableInvoice, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                                  AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, True, IsDraft)

            End If

            If ToFileOption <> InvoicePrinting.ToFileOptions.DocumentManager AndAlso (IncludeAPDocuments OrElse IncludeExpenseReportReceipts) Then

                If IncludeAPDocuments Then

                    DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice) With {.AccountReceivableInvoiceNumber = AccountReceivableInvoice.InvoiceNumber, .AccountReceivableSequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber, .AccountReceivableType = AccountReceivableInvoice.InvoiceType})
                    DocumentLevelSettings.AddRange(GetAccountPayableInvoiceDocumentLevelSettings(DbContext, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType))
                    DocumentLevelSettings.AddRange(GetAccountPayableInvoicesWithMediaDocumentLevelSettings(DbContext, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType))

                    DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadAccountPayableInvoiceDocuments(DocumentLevelSettings, Session))
                    DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadAccountReceivableInvoiceDocuments(DocumentLevelSettings, Session).Where(Function(Entity) Entity.Keywords <> "Invoice" AndAlso Entity.Keywords <> "Backup Report").ToList)

                End If

                If IncludeExpenseReportReceipts Then

                    DocumentLevelSettings.AddRange(GetExpenseReportDetailDocumentLevelSettings(DbContext, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType))

                    DocumentList.AddRange(AdvantageFramework.DocumentManager.LoadExpenseDetailDocuments(DocumentLevelSettings, Session))

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
                                 AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                 InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                 OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocumentIndex As Integer = 1
            Dim FileName As String = String.Empty

            If ZipFile IsNot Nothing Then

                DocumentIndex = ZipFile.Entries.Count

                If DocumentIndex <> 1 Then

                    DocumentIndex = 1

                End If

                If Report IsNot Nothing Then

                    If InvoicePrintingPageSetting IsNot Nothing Then

                        InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                    End If

                    If AccountReceivableInvoice IsNot Nothing Then

                        If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                            FileName = CreateFileName(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, DocumentIndex, False)

                        ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                            FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                        ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                            FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.DivisionCode, AccountReceivableInvoice.ProductCode, AccountReceivableInvoice.CampaignCode)

                        ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                            FileName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                        End If

                    Else

                        FileName = ReportName

                    End If

                    MemoryStream = New System.IO.MemoryStream

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        Report.ExportToPdf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(FileName & ".pdf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".pdf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        Report.ExportToRtf(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(FileName & ".rtf", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".rtf", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        Report.ExportToXls(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(FileName & ".xls", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".xls", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        Report.ExportToXlsx(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(FileName & ".xlsx", MemoryStream.ToArray)

                        Else

                            ZipFile.AddEntry(ReportName & ".xlsx", MemoryStream.ToArray)

                        End If

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        Report.ExportToImage(MemoryStream)

                        If AccountReceivableInvoice IsNot Nothing Then

                            ZipFile.AddEntry(FileName & ".png", MemoryStream.ToArray)

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
        Private Sub AddToAttachments(Agency As AdvantageFramework.Database.Entities.Agency,
                                     ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                     Report As DevExpress.XtraReports.UI.XtraReport,
                                     BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                     DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                     AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                     Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment),
                                     InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                     OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim DocumentIndex As Integer = 1
            Dim ReportName As String = ""
            Dim InvoiceNumberString As String = ""
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If Agency IsNot Nothing AndAlso AccountReceivableInvoice IsNot Nothing AndAlso Attachments IsNot Nothing Then

                InvoiceNumberString = CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                If DocumentIndex <> 1 Then

                    DocumentIndex = 1

                End If

                If Report IsNot Nothing Then

                    If InvoicePrintingPageSetting IsNot Nothing Then

                        InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                    End If

                    MemoryStream = New System.IO.MemoryStream

                    If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                        ReportName = AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                        ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                        ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                    ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                        ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.DivisionCode, AccountReceivableInvoice.ProductCode, AccountReceivableInvoice.CampaignCode)

                    End If

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        Report.ExportToPdf(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".pdf", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        Report.ExportToRtf(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".rtf", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        Report.ExportToXls(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xls", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        Report.ExportToXlsx(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xlsx", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        Report.ExportToImage(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".png", MemoryStream.ToArray))

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

                    ReportName = AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString & " Backup"

                    If ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.PDF Then

                        BackupReport.ExportToPdf(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".pdf", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.RTF Then

                        BackupReport.ExportToRtf(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".rtf", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLS Then

                        BackupReport.ExportToXls(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xls", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX Then

                        BackupReport.ExportToXlsx(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".xlsx", MemoryStream.ToArray))

                        DocumentIndex += 1

                    ElseIf ToFileOption = AdvantageFramework.InvoicePrinting.ToFileOptions.Image Then

                        BackupReport.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        BackupReport.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        BackupReport.ExportToImage(MemoryStream)

                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(ReportName & ".png", MemoryStream.ToArray))

                        DocumentIndex += 1

                    End If

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                    Catch ex As Exception

                    End Try

                    MemoryStream = Nothing

                End If

                If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                    AddToDocumentsToAttachments(Agency, DocumentList.Select(Function(Document) Document.GetDocumentEntity).ToList, DocumentIndex, AccountReceivableInvoice, Attachments)

                End If

            End If

        End Sub
        Private Sub AddToDocumentsToAttachments(Agency As AdvantageFramework.Database.Entities.Agency, Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document),
                                                ByRef Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment))

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim SaveToLocation As String = Nothing

            Try

                If Agency IsNot Nothing AndAlso Documents IsNot Nothing Then

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

                                    SaveAsFileName = Document.FileName

                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(SaveAsFileName, ByteFile))

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub AddToDocumentsToAttachments(Agency As AdvantageFramework.Database.Entities.Agency, Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document), DocumentIndex As Integer,
                                               AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                               ByRef Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment))

            'Objects
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader
            Dim ByteFile() As Byte = Nothing
            Dim FileSystemFile As String = Nothing
            Dim SaveAsFileName As String = Nothing
            Dim FileExtension As String = ""
            Dim Counter As Integer = 0
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim SaveToLocation As String = Nothing
            Dim InvoiceNumberString As String = ""

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

                                    SaveAsFileName = AccountReceivableInvoice.ClientCode & " " & InvoiceNumberString & "_" & DocumentIndex.ToString & " " & Document.FileName

                                    Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(SaveAsFileName, ByteFile))

                                    DocumentIndex = DocumentIndex + 1

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub AddToAttachments(ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                     ReportName As String,
                                     Report As DevExpress.XtraReports.UI.XtraReport,
                                     Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment),
                                     InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                     AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                     OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If Report IsNot Nothing AndAlso Attachments IsNot Nothing Then

                If InvoicePrintingPageSetting IsNot Nothing Then

                    InvoicePrintingPageSetting.PlaceSettingsOnReport(Report)

                End If

                If OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.Default Then

                    'do nothing

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequence Then

                    ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberOnly Then

                    ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

                ElseIf OverrideInvoiceFilename = AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename.InvoiceNumberWithSequenceCDPCodesCampaignCode Then

                    ReportName = CreateInvoiceNumberStringWithNoLeadingZeros(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.DivisionCode, AccountReceivableInvoice.ProductCode, AccountReceivableInvoice.CampaignCode)

                End If

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
        Private Sub CreateInvoiceZipFileForPrintToMultipleFiles(Agency As AdvantageFramework.Database.Entities.Agency,
                                                                ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                                                ExportPath As String,
                                                                ReportName As String,
                                                                Report As DevExpress.XtraReports.UI.XtraReport,
                                                                BackupReportName As String,
                                                                BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                                                CoverSheetName As String,
                                                                CoverSheet As DevExpress.XtraReports.UI.XtraReport,
                                                                DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                                                ByRef ZipFileName As String,
                                                                AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                                                InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                                                OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim Counter As Integer = 0
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing

            ZipFile = New Ionic.Zip.ZipFile

            AddToZipFile(Agency, ToFileOption, ReportName, Report, BackupReportName, BackupReport, CoverSheetName, CoverSheet, DocumentList, ZipFile, AccountReceivableInvoice, InvoicePrintingPageSetting, OverrideInvoiceFilename)

            ZipFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportPath, "\") & AccountReceivableInvoice.ClientCode & " " & CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

            Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                ZipFileName = ExportPath & ReportName & "(" & Counter & ")"

                Counter = Counter + 1

            Loop

            ZipFileName = ZipFileName & ".zip"

            ZipFile.Save(ZipFileName)

            Try

                ZipFile.Dispose()

                ZipFile = Nothing

            Catch ex As Exception

            End Try

        End Sub
        Private Sub CreateInvoiceZipFile(Agency As AdvantageFramework.Database.Entities.Agency,
                                         ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions,
                                         ExportPath As String,
                                         ReportName As String,
                                         Report As DevExpress.XtraReports.UI.XtraReport,
                                         BackupReportName As String,
                                         BackupReport As DevExpress.XtraReports.UI.XtraReport,
                                         CoverSheetName As String,
                                         CoverSheet As DevExpress.XtraReports.UI.XtraReport,
                                         DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document),
                                         ByRef ZipFileName As String,
                                         AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                         InvoicePrintingPageSetting As AdvantageFramework.Billing.Reports.Presentation.Classes.InvoicePrintingPageSetting,
                                         OverrideInvoiceFilename As AdvantageFramework.InvoicePrinting.OverrideInvoiceFilename)

            'objects
            Dim Counter As Integer = 0
            Dim ZipFile As Ionic.Zip.ZipFile = Nothing

            ZipFile = New Ionic.Zip.ZipFile

            AddToZipFile(Agency, ToFileOption, ReportName, Report, BackupReportName, BackupReport, CoverSheetName, CoverSheet, DocumentList, ZipFile, AccountReceivableInvoice, InvoicePrintingPageSetting, OverrideInvoiceFilename)

            ZipFileName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(ExportPath, "\") & AccountReceivableInvoice.ClientCode & " " & CreateInvoiceNumberString(AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber)

            Do While New System.IO.FileInfo(ZipFileName & ".zip").Exists

                ZipFileName = ExportPath & ReportName & "(" & Counter & ")"

                Counter = Counter + 1

            Loop

            ZipFileName = ZipFileName & ".zip"

            ZipFile.Save(ZipFileName)

            Try

                ZipFile.Dispose()

                ZipFile = Nothing

            Catch ex As Exception

            End Try

        End Sub
        Private Function GetAccountPayableInvoicesWithMediaDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                                 ByVal ARInvoiceNumber As Integer,
                                                                                 ByVal ARInvoiceSequenceNumber As Short,
                                                                                 ByVal ARType As String) As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

            'objects
            Dim ClientInvoiceMediaWithAPDocumentList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceMediaWithAPDocument) = Nothing
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            ClientInvoiceMediaWithAPDocumentList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoiceMediaWithAPDocument) _
                                                            (String.Format("exec advsp_ar_invoice_select_ap_media_documents {0},{1},'{2}'",
                                                                            ARInvoiceNumber, ARInvoiceSequenceNumber, ARType)).ToList

            DocumentLevelSettings = (From Entity In ClientInvoiceMediaWithAPDocumentList
                                     Select Entity.AccountPayableID, Entity.InvoiceNumber, Entity.SequenceNumber, Entity.Type).Distinct.ToList.Select(Function(Doc) _
                                            New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With
                                                                                                           {.AccountPayableID = Doc.AccountPayableID,
                                                                                                            .AccountReceivableInvoiceNumber = Doc.InvoiceNumber,
                                                                                                            .AccountReceivableSequenceNumber = Doc.SequenceNumber,
                                                                                                            .AccountReceivableType = Doc.Type}).ToList

            GetAccountPayableInvoicesWithMediaDocumentLevelSettings = DocumentLevelSettings

        End Function
        Private Function GetAccountPayableInvoiceDocumentLevelSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
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
                                        ARS.ARInvoiceNumber = InvoiceNumber AndAlso
                                        ARS.ARInvoiceSequence = InvoiceSequenceNumber AndAlso
                                        ARS.ARType = Type
                                     Select APH.ID, ARS.ARInvoiceNumber, ARS.ARInvoiceSequence, ARS.ARType).Distinct.ToList.Select(Function(DLS) _
                                        New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice) With
                                                                                                        {.AccountPayableID = DLS.ID,
                                                                                                        .AccountReceivableInvoiceNumber = DLS.ARInvoiceNumber,
                                                                                                        .AccountReceivableSequenceNumber = DLS.ARInvoiceSequence,
                                                                                                        .AccountReceivableType = DLS.ARType}).ToList

            GetAccountPayableInvoiceDocumentLevelSettings = DocumentLevelSettings

        End Function
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
        Public Function CreateARDocumentManagerFileName(InvoiceNumber As Integer, SequenceNumber As Integer, MediaType As String, ClientCode As String, IsBackup As Boolean) As String

            'objects
            Dim FileName As String = ""

            If String.IsNullOrWhiteSpace(MediaType) = False AndAlso MediaType <> "P" Then

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & MediaType & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & MediaType & " " & ClientCode

                End If

            Else

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & ClientCode

                End If

            End If

            CreateARDocumentManagerFileName = FileName

        End Function
        Public Function CreateFileName(InvoiceNumber As Integer, SequenceNumber As Integer, ClientCode As String, IsBackup As Boolean) As String

            'objects
            Dim FileName As String = ""

            If SequenceNumber > 0 Then

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & "_" & Format(SequenceNumber, "000#") & " " & ClientCode

                End If

            Else

                If IsBackup Then

                    FileName = Format(InvoiceNumber, "00000000#") & " " & ClientCode & " Backup"

                Else

                    FileName = Format(InvoiceNumber, "00000000#") & " " & ClientCode

                End If

            End If

            CreateFileName = FileName

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
        Public Function CreateInvoiceNumberStringWithNoLeadingZeros(InvoiceNumber As Integer, SequenceNumber As Integer) As String

            'objects
            Dim InvoiceNumberString As String = ""

            If SequenceNumber > 0 Then

                InvoiceNumberString = InvoiceNumber.ToString & "_" & SequenceNumber.ToString

            Else

                InvoiceNumberString = InvoiceNumber.ToString

            End If

            CreateInvoiceNumberStringWithNoLeadingZeros = InvoiceNumberString

        End Function
        Public Function CreateInvoiceNumberStringWithNoLeadingZeros(InvoiceNumber As Integer, SequenceNumber As Integer, ClientCode As String, DivisionCode As String, ProductCode As String, CampaignCode As String) As String

            'objects
            Dim InvoiceNumberString As String = ""

            If SequenceNumber > 0 Then

                InvoiceNumberString = InvoiceNumber.ToString & "_" & SequenceNumber.ToString

            Else

                InvoiceNumberString = InvoiceNumber.ToString

            End If

            InvoiceNumberString &= "_" & ClientCode & "_" & DivisionCode & "_" & ProductCode

            If String.IsNullOrWhiteSpace(CampaignCode) = False Then

                InvoiceNumberString &= "_" & CampaignCode

            End If

            CreateInvoiceNumberStringWithNoLeadingZeros = InvoiceNumberString

        End Function
        Public Function CreateSingleFileName(ClientCode As String, IsBackup As Boolean, IsMedia As Boolean) As String

			'objects
			Dim FileName As String = ""

			If IsBackup Then

				FileName = ClientCode & " PB " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

			Else

				If IsMedia Then

					FileName = ClientCode & " MI " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

				Else

					FileName = ClientCode & " PI " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#")

				End If

			End If

			CreateSingleFileName = FileName

		End Function

#End Region

	End Module

End Namespace

