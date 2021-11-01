Namespace Reporting.Presentation

    Public Class ReportViewerForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BindingSource As System.Windows.Forms.BindingSource = Nothing
        Private _XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Private _Report As AdvantageFramework.Reporting.ReportTypes = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Protected _HasLoaded As Boolean = False
        Private _Criteria As Integer = Nothing
        Private _FilterString As String = Nothing
        Private _From As Date = Nothing
        Private _To As Date = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, _
                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date)

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Report = Report
            _ParameterDictionary = ParameterDictionary
            _Session = Session
            _Criteria = Criteria
            _FilterString = FilterString
            _From = [From]
            _To = [To]

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

            DialogResult = AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To])

        End Sub
        Public Shared Function ShowFormDialog(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As Windows.Forms.DialogResult

            'objects
            Dim ReportViewerForm As ReportViewerForm = Nothing

            ReportViewerForm = New ReportViewerForm(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To])

            ShowFormDialog = ReportViewerForm.ShowDialog()



        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportViewerForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If _Report = ReportTypes.ServiceFeeReconciliationReport Then

                RemoveHandler AdvantageFramework.Navigation.ShowReportViewerEvent, AddressOf AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog

            End If

        End Sub
        Private Sub ReportViewerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            Me.WindowState = Windows.Forms.FormWindowState.Maximized

            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

            Try

                If _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport AndAlso _ParameterDictionary("IncludeReceipts") = True Then

                    Dim exReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport = Nothing

                    If _ParameterDictionary("IncludeReport") = False Then

                        _XtraReport = ExpenseReciptPrinting(Nothing, _ParameterDictionary("DataSource"))

                    Else

                        exReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, _ParameterDictionary, _Criteria, _FilterString, _From, _To)

                        exReport.CreateDocument()

                        ExpenseReciptPrinting(exReport, _ParameterDictionary("DataSource"))

                        _XtraReport = exReport

                    End If

                Else

                    _XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, _Report, _ParameterDictionary, _Criteria, _FilterString, _From, _To)

                End If

                If _Report = AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport OrElse (_Report = ReportTypes.UserDefined AndAlso TypeOf _XtraReport Is AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport) Then

                    BarButtonItemStatusBar_ExpandAllDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    BarButtonItemStatusBar_CollapseAllDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                Else

                    BarButtonItemStatusBar_ExpandAllDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    BarButtonItemStatusBar_CollapseAllDetails.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                End If

                If _XtraReport IsNot Nothing Then

                    If _Report = AdvantageFramework.Reporting.ReportTypes.UserDefined OrElse _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionSummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetail OrElse _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetMediaSummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailV2 OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailWithComments OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetMediaByOrderDescription OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetail OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailSalesClass OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailDirectSummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofBilling OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryBySalesClassClient OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryExtendedGPofGI OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByPeriodMediaSeparate OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyCDPSCYTDMargin OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofTimeIncAndHourlyRate OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomebyClient12PeriodWtihBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCCurrentYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientwithBudgetIncomeCostsHours OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientSalesClassCurrentYTDBillingIncome OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossBillingByClient12PeriodWithBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilityDetail OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummaryWithOverhead OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaCurrentStatusDetailbyTypeClient OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliation OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaBillingandPaymentSummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaBillingandPaymentDetail OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliationReportWithBilled OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersUnbilledWithoutAPByMonth OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersUnbilledWithoutAPByOrder OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliationReportWithBilledByClientAndType OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGross OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGrossIncludeNonbillableCost OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNet OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNetIncludeNonbillableCost OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGross OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGrossIncludeNonbillableCost OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNet OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNetIncludeNonbillableCost Then

                        Try

                            _BindingSource = TryCast(_XtraReport, AdvantageFramework.Reporting.Reports.IUserDefinedReport).BindingSourceControl

                        Catch ex As Exception
                            _BindingSource = Nothing
                        End Try

                        If _BindingSource IsNot Nothing Then

                            BarButtonItemFilter.Enabled = True

                        End If

                        If _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetail OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailSalesClass OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailDirectSummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofBilling OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryBySalesClassClient OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryExtendedGPofGI OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByPeriodMediaSeparate OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyCDPSCYTDMargin OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofTimeIncAndHourlyRate OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomebyClient12PeriodWtihBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCCurrentYTDBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientwithBudgetIncomeCostsHours OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientSalesClassCurrentYTDBillingIncome OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.GrossBillingByClient12PeriodWithBudget OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilityDetail OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummary OrElse
                            _Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummaryWithOverhead Then

                            BarButtonItemFilter.Enabled = False
                        End If

                    End If

                    PrintControl.PrintingSystem = _XtraReport.PrintingSystem

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    If _Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport AndAlso _ParameterDictionary("IncludeReceipts") = True Then



                    Else

                        _XtraReport.CreateDocument(True)

                    End If



                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            PrintControl.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = _XtraReport.DisplayName & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                            PrintControl.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            PrintControl.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            PrintControl.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintControl.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), _XtraReport.DisplayName))

                            'PrintControl.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            PrintControl.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

            Catch ex As Exception
                AdvantageFramework.Navigation.ShowMessageBox("Error creating report!")
                Me.Close()
            End Try

            If KeepLoading = False Then

                Me.Close()

            End If

            _HasLoaded = True


        End Sub


        Private Function ExpenseReciptPrinting(ByRef Report As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport, ByVal ExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport))

            Dim RecReportAll As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts = Nothing

            Try

                Dim RecReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts = Nothing
                Dim picture As DevExpress.XtraReports.UI.XRPictureBox
                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                Dim DocumentIDs As Generic.List(Of Integer) = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ExpenseReports IsNot Nothing Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        For Each ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport In ExpenseReports

                            DocumentIDs = Nothing

                            Try

                                DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[advsp_expense_get_receipts] {0};", ExpenseReport.InvoiceNumber)).ToList

                            Catch ex As Exception
                                DocumentIDs = Nothing
                            End Try
                            If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                                Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

                                RecReportAll = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts
                                RecReportAll.CreateDocument()

                                For Each DocumentID As Integer In DocumentIDs

                                    Document = Nothing

                                    Try

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                                    Catch ex As Exception
                                        Document = Nothing
                                    End Try

                                    If Document IsNot Nothing Then

                                        If Report Is Nothing Then

                                            Try

                                                If Document.MIMEType.Contains("image") Then

                                                    RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                    picture = New DevExpress.XtraReports.UI.XRPictureBox

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                           AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    picture.Image = System.Drawing.Image.FromFile(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                                                    picture.Size = New Drawing.Size(400, 750)

                                                    RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                    RecReport.CreateDocument()

                                                    RecReportAll.Pages.Add(RecReport.Pages(0))

                                                End If
                                                If Document.FileName.ToUpper.EndsWith(".PDF") Then

                                                    Dim PDFDocument As Aspose.Pdf.Document = Nothing
                                                    Dim Resolution As Aspose.Pdf.Devices.Resolution = Nothing
                                                    Dim PDFPngDevice As Aspose.Pdf.Devices.PngDevice = Nothing
                                                    Dim MemoryStream As System.IO.MemoryStream = Nothing
                                                    Dim License As Aspose.Pdf.License = Nothing

                                                    License = New Aspose.Pdf.License

                                                    License.SetLicense("Aspose.Total.lic")
                                                    License.Embedded = True

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                           AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    PDFDocument = New Aspose.Pdf.Document(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    Resolution = New Aspose.Pdf.Devices.Resolution(300)
                                                    PDFPngDevice = New Aspose.Pdf.Devices.PngDevice(800, 1000, Resolution)

                                                    For Each pdfpage In PDFDocument.Pages

                                                        MemoryStream = New System.IO.MemoryStream

                                                        PDFPngDevice.Process(pdfpage, MemoryStream)

                                                        If PDFDocument.PageInfo.IsLandscape Then
                                                            RecReport.Landscape = True
                                                        End If

                                                        RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                        picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                        picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                        picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                        picture.Size = New Drawing.Size(800, 1000)

                                                        RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                        RecReport.CreateDocument()

                                                        RecReportAll.Pages.Add(RecReport.Pages(0))

                                                    Next

                                                End If
                                                If Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                                                    Dim WordDocument As Aspose.Words.Document = Nothing
                                                    Dim PageInfo As Aspose.Words.Rendering.PageInfo = Nothing
                                                    Dim PageSize As System.Drawing.Size = Nothing
                                                    Dim MemoryStream As System.IO.MemoryStream = Nothing
                                                    Dim License As Aspose.Words.License = Nothing

                                                    License = New Aspose.Words.License

                                                    License.SetLicense("Aspose.Total.lic")

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                           AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    WordDocument = New Aspose.Words.Document(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    For x As Integer = 0 To WordDocument.PageCount - 1

                                                        PageInfo = WordDocument.GetPageInfo(x)

                                                        PageSize = PageInfo.GetSizeInPixels(0.8, 100)

                                                        Using Bitmap = New System.Drawing.Bitmap(PageSize.Width, PageSize.Height)

                                                            Bitmap.SetResolution(100, 100)

                                                            Using Graphics = System.Drawing.Graphics.FromImage(Bitmap)

                                                                Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

                                                                Graphics.FillRectangle(Drawing.Brushes.White, 0, 0, PageSize.Width, PageSize.Height)

                                                                WordDocument.RenderToScale(x, Graphics, 0, 0, 0.8)

                                                            End Using

                                                            MemoryStream = New System.IO.MemoryStream

                                                            Bitmap.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                                                        End Using

                                                        RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                        picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                        picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                        picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                        picture.Size = New Drawing.Size(800, 1000)

                                                        RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                        RecReport.CreateDocument()

                                                        RecReportAll.Pages.Add(RecReport.Pages(0))

                                                    Next

                                                End If

                                            Catch ex As Exception
                                            End Try

                                        Else

                                            Try

                                                If Document.MIMEType.Contains("image") Then

                                                    RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                    picture = New DevExpress.XtraReports.UI.XRPictureBox

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                           AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    picture.Image = System.Drawing.Image.FromFile(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze
                                                    picture.Size = New Drawing.Size(400, 750)

                                                    RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                    RecReport.CreateDocument()

                                                    Report.Pages.Add(RecReport.Pages(0))

                                                End If
                                                If Document.FileName.ToUpper.EndsWith(".PDF") Then

                                                    Dim PDFDocument As Aspose.Pdf.Document = Nothing
                                                    Dim Resolution As Aspose.Pdf.Devices.Resolution = Nothing
                                                    Dim PDFPngDevice As Aspose.Pdf.Devices.PngDevice = Nothing
                                                    Dim MemoryStream As System.IO.MemoryStream = Nothing
                                                    Dim License As Aspose.Pdf.License = Nothing

                                                    License = New Aspose.Pdf.License

                                                    License.SetLicense("Aspose.Total.lic")
                                                    License.Embedded = True

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                       AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    PDFDocument = New Aspose.Pdf.Document(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    Resolution = New Aspose.Pdf.Devices.Resolution(300)
                                                    PDFPngDevice = New Aspose.Pdf.Devices.PngDevice(800, 1000, Resolution)

                                                    For Each pdfpage In PDFDocument.Pages

                                                        MemoryStream = New System.IO.MemoryStream

                                                        PDFPngDevice.Process(pdfpage, MemoryStream)

                                                        If PDFDocument.PageInfo.IsLandscape Then
                                                            RecReport.Landscape = True
                                                        End If

                                                        RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                        picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                        picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                        picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                        picture.Size = New Drawing.Size(800, 1000)

                                                        RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                        RecReport.CreateDocument()

                                                        Report.Pages.Add(RecReport.Pages(0))

                                                    Next

                                                End If
                                                If Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                                                    Dim WordDocument As Aspose.Words.Document = Nothing
                                                    Dim PageInfo As Aspose.Words.Rendering.PageInfo = Nothing
                                                    Dim PageSize As System.Drawing.Size = Nothing
                                                    Dim MemoryStream As System.IO.MemoryStream = Nothing
                                                    Dim License As Aspose.Words.License = Nothing

                                                    License = New Aspose.Words.License

                                                    License.SetLicense("Aspose.Total.lic")

                                                    AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain,
                                                                                                       AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                                                    WordDocument = New Aspose.Words.Document(Agency.FileSystemDirectory & "\" & Document.FileSystemFileName)

                                                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                                                    For x As Integer = 0 To WordDocument.PageCount - 1

                                                        PageInfo = WordDocument.GetPageInfo(x)

                                                        PageSize = PageInfo.GetSizeInPixels(0.8, 100)

                                                        Using Bitmap = New System.Drawing.Bitmap(PageSize.Width, PageSize.Height)

                                                            Bitmap.SetResolution(100, 100)

                                                            Using Graphics = System.Drawing.Graphics.FromImage(Bitmap)

                                                                Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

                                                                Graphics.FillRectangle(Drawing.Brushes.White, 0, 0, PageSize.Width, PageSize.Height)

                                                                WordDocument.RenderToScale(x, Graphics, 0, 0, 0.8)

                                                            End Using

                                                            MemoryStream = New System.IO.MemoryStream

                                                            Bitmap.Save(MemoryStream, System.Drawing.Imaging.ImageFormat.Bmp)

                                                        End Using

                                                        RecReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReportReceipts

                                                        picture = New DevExpress.XtraReports.UI.XRPictureBox
                                                        picture.Image = System.Drawing.Image.FromStream(MemoryStream)
                                                        picture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                                                        picture.Size = New Drawing.Size(800, 1000)

                                                        RecReport.Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(picture)

                                                        RecReport.CreateDocument()

                                                        Report.Pages.Add(RecReport.Pages(0))

                                                    Next

                                                End If

                                            Catch ex As Exception
                                            End Try

                                        End If

                                    End If

                                Next

                            End If

                        Next

                    End If

                End Using

            Catch ex As Exception
                RecReportAll = Nothing
            End Try

            Return RecReportAll

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub BarButtonItemFilter_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemFilter.ItemClick

            'objects
            Dim FilterString As String = ""

            FilterString = _XtraReport.FilterString

            If AdvantageFramework.WinForm.Presentation.FilterDialog.ShowFormDialog(_BindingSource, FilterString) = Windows.Forms.DialogResult.OK Then

                _XtraReport.FilterString = FilterString

                _XtraReport.ApplyFiltering()

                _XtraReport.CreateDocument(True)

            End If

        End Sub
        Private Sub BarButtonItemStatusBar_ExpandAllDetails_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemStatusBar_ExpandAllDetails.ItemClick

            If TypeOf _XtraReport Is AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport Then

                CType(_XtraReport, AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport).ExpandCollapseAllDetails(True)

            End If

        End Sub
        Private Sub BarButtonItemStatusBar_CollapseAllDetails_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemStatusBar_CollapseAllDetails.ItemClick

            If TypeOf _XtraReport Is AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport Then

                CType(_XtraReport, AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport).ExpandCollapseAllDetails(False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
