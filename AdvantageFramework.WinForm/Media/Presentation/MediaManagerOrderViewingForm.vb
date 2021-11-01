Namespace Media.Presentation

    Public Class MediaManagerOrderViewingForm

#Region " Constants "

        Private Const Win_FormTitleDoubleClick As Integer = 163

#End Region

#Region " Enum "

        Private Enum FileOption
            PDF
            Image
            XLS
            XLSX
            RTF
        End Enum

#End Region

#Region " Variables "

        Private _Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Private _PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Medthods "

        Private Sub New(Report As DevExpress.XtraReports.UI.XtraReport, PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Report = Report
            _PrintingSystemCommandHandler = PrintingSystemCommandHandler

        End Sub
        Private Sub SendEmails(ToFileOption As FileOption)

            'objects
            Dim ReportExportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
            Dim ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim EmailSubject As String = ""
            Dim EmailBody As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim [Bcc] As String = Nothing
            Dim EmailSent As Boolean = False
            Dim SendingEmailStatus As Email.SendingEmailStatus = Nothing
            Dim ErrorMessage As String = ""

            Try

                ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

            Catch ex As Exception
                ReportExportPath = ""
            End Try

            If String.IsNullOrWhiteSpace(ReportExportPath) Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                End Using

            End If

            If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

                DefaultFileName = _Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                MemoryStream = New System.IO.MemoryStream

                Select Case ToFileOption

                    Case FileOption.PDF

                        _Report.ExportToPdf(MemoryStream)
                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".pdf", MemoryStream.ToArray))

                    Case FileOption.Image

                        _Report.ExportOptions.Image.Format = System.Drawing.Imaging.ImageFormat.Png
                        _Report.ExportOptions.Image.ExportMode = DevExpress.XtraPrinting.ImageExportMode.SingleFilePageByPage

                        _Report.ExportToImage(MemoryStream)
                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".png", MemoryStream.ToArray))

                    Case FileOption.RTF

                        _Report.ExportToRtf(MemoryStream)
                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".rtf", MemoryStream.ToArray))

                    Case FileOption.XLS

                        _Report.ExportToXls(MemoryStream)
                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".xls", MemoryStream.ToArray))

                    Case FileOption.XLSX

                        _Report.ExportToXlsx(MemoryStream)
                        Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".xlxs", MemoryStream.ToArray))

                End Select

                EmailSubject = DefaultFileName

                If AdvantageFramework.WinForm.Presentation.EmailRecipientDialog.ShowFormDialog(ToRecipients, CcRecipients, BccRecipients, EmailSubject, EmailBody) = Windows.Forms.DialogResult.OK Then

                    If ToRecipients IsNot Nothing AndAlso ToRecipients.Count > 0 Then

                        [To] = Join(ToRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If CcRecipients IsNot Nothing AndAlso CcRecipients.Count > 0 Then

                        [Cc] = Join(CcRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If BccRecipients IsNot Nothing AndAlso BccRecipients.Count > 0 Then

                        [Bcc] = Join(BccRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], EmailSubject, EmailBody, 3, Attachments, SendingEmailStatus, ErrorMessage, False)

                    End Using

                    If SendingEmailStatus <> Email.SendingEmailStatus.EmailSent Then

                        AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

                    ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

                Try

                    MemoryStream.Close()
                    MemoryStream.Dispose()

                Catch ex As Exception

                End Try

                MemoryStream = Nothing

            End If

        End Sub
        Protected Overrides Sub WndProc(ByRef msg As System.Windows.Forms.Message)

            If msg.Msg = Win_FormTitleDoubleClick Then

                msg.Result = IntPtr.Zero

            Else

                MyBase.WndProc(msg)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Report As DevExpress.XtraReports.UI.XtraReport, PrintingSystemCommandHandler As AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler) As Windows.Forms.DialogResult

            'objects
            Dim MediaManagerOrderViewingForm As AdvantageFramework.Media.Presentation.MediaManagerOrderViewingForm = Nothing

            MediaManagerOrderViewingForm = New MediaManagerOrderViewingForm(Report, PrintingSystemCommandHandler)

            ShowFormDialog = MediaManagerOrderViewingForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerOrderViewingForm_Load(sender As Object, e As EventArgs) Handles Me.Load

            Me.DocumentViewer.DocumentSource = _Report

            If _PrintingSystemCommandHandler IsNot Nothing Then

                BarButtonItemQuickEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                Me.DocumentViewer.PrintingSystem.AddCommandHandler(_PrintingSystemCommandHandler)

            End If

        End Sub
        Private Sub MediaManagerOrderViewingForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            PrintPreviewBarItemEmailAs.Enabled = True
            PrintPreviewBarItemEmailAsPDF.Enabled = True
            PrintPreviewBarItemEmailAsImage.Enabled = True
            PrintPreviewBarItemEmailAsRTF.Enabled = True
            PrintPreviewBarItemEmailAsXLS.Enabled = True
            PrintPreviewBarItemEmailAsXLSX.Enabled = True

            Me.MinimizeBox = False
            Me.MaximizeBox = False

            Me.WindowState = Windows.Forms.FormWindowState.Maximized

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BarButtonItemQuickEmail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemQuickEmail.ItemClick

            'objects
            Dim ReportExportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing

            Try

                ReportExportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

            Catch ex As Exception
                ReportExportPath = ""
            End Try

            If String.IsNullOrWhiteSpace(ReportExportPath) Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ReportExportPath = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                End Using

            End If

            If My.Computer.FileSystem.DirectoryExists(ReportExportPath) Then

                DefaultFileName = _Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName

                Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                MemoryStream = New System.IO.MemoryStream

                _Report.ExportToPdf(MemoryStream)

                Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(DefaultFileName & ".pdf", MemoryStream.ToArray))

                AdvantageFramework.Email.CreateEmailAndOpenEmailClient(ReportExportPath, DefaultFileName, DefaultFileName & " Order", "", "", Attachments)

                Try

                    MemoryStream.Close()
                    MemoryStream.Dispose()

                Catch ex As Exception

                End Try

                MemoryStream = Nothing

            End If

        End Sub
        Private Sub PrintPreviewBarItemEmailAs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAs.ItemClick

            SendEmails(FileOption.PDF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsImage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsImage.ItemClick

            SendEmails(FileOption.Image)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsPDF.ItemClick

            SendEmails(FileOption.PDF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsRTF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsRTF.ItemClick

            SendEmails(FileOption.RTF)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsXLS_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsXLS.ItemClick

            SendEmails(FileOption.XLS)

        End Sub
        Private Sub PrintPreviewBarItemEmailAsXLSX_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintPreviewBarItemEmailAsXLSX.ItemClick

            SendEmails(FileOption.XLSX)

        End Sub

#End Region

#End Region

    End Class

End Namespace