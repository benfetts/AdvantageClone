Namespace Services.ScheduledReports

    <HideModuleName()>
    Public Module Methods

        Public Event EntryLogWrittenEvent(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RegistrySetting
            <AdvantageFramework.Registry.Attributes.RegistryAttribute("\Services\Scheduled Reports\", "OutputFolder", "")>
            OutputFolder
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _EventLog As System.Diagnostics.EventLog = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub _EventLog_EntryWritten(ByVal sender As Object, ByVal e As System.Diagnostics.EntryWrittenEventArgs) Handles _EventLog.EntryWritten

            RaiseEvent EntryLogWrittenEvent(e.Entry)

        End Sub
        Private Sub LoadDynamicReportTemplateColumnDetails(ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, DynamicReportID As Integer,
                                                           GridView As DevExpress.XtraGrid.Views.Grid.GridView)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing
            Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
            Dim DynamicReportColumns As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn) = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            DynamicReportColumns = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReportID).ToList

            For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.IsVisible = False AndAlso Entity.GroupIndex = -1).ToList

                GridColumn = GridView.Columns(DynamicReportColumn.FieldName)

                If GridColumn IsNot Nothing Then

                    GridColumn.Caption = DynamicReportColumn.HeaderText
                    GridColumn.Visible = DynamicReportColumn.IsVisible
                    GridColumn.SortIndex = DynamicReportColumn.SortIndex
                    GridColumn.SortOrder = DynamicReportColumn.SortOrder
                    GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                    GridColumn.Width = DynamicReportColumn.Width
                    'GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                End If

            Next

            For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.GroupIndex > -1).OrderBy(Function(Column) Column.GroupIndex).ToList

                GridColumn = GridView.Columns(DynamicReportColumn.FieldName)

                If GridColumn IsNot Nothing Then

                    GridColumn.Caption = DynamicReportColumn.HeaderText
                    GridColumn.SortIndex = DynamicReportColumn.SortIndex
                    GridColumn.SortOrder = DynamicReportColumn.SortOrder
                    GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                    GridColumn.Width = DynamicReportColumn.Width

                End If

            Next

            For Each DynamicReportColumn In DynamicReportColumns.Where(Function(Entity) Entity.IsVisible = True AndAlso Entity.GroupIndex = -1).OrderBy(Function(Column) Column.VisibleIndex).ToList

                GridColumn = GridView.Columns(DynamicReportColumn.FieldName)

                If GridColumn IsNot Nothing Then

                    GridColumn.Caption = DynamicReportColumn.HeaderText
                    GridColumn.SortIndex = DynamicReportColumn.SortIndex
                    GridColumn.SortOrder = DynamicReportColumn.SortOrder
                    GridColumn.GroupIndex = DynamicReportColumn.GroupIndex
                    GridColumn.Width = DynamicReportColumn.Width
                    GridColumn.VisibleIndex = DynamicReportColumn.VisibleIndex

                End If

            Next

            For Each GridColumn In GridView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)().Where(Function(GC) GC.UnboundType = DevExpress.Data.UnboundColumnType.Bound).ToList

                If DynamicReportColumns.Any(Function(Entity) Entity.FieldName = GridColumn.FieldName) = False Then

                    GridColumn.Visible = False

                End If

            Next

            For Each DynamicReportUnboundColumn In AdvantageFramework.Reporting.Database.Procedures.DynamicReportUnboundColumn.LoadByDynamicReportID(ReportingDbContext, DynamicReportID).OrderBy(Function(Column) Column.VisibleIndex).ToList

                GridColumn = GridView.Columns.AddField(DynamicReportUnboundColumn.FieldName)

                GridColumn.ShowUnboundExpressionMenu = True

                GridColumn.VisibleIndex = GridView.Columns.Count

                GridColumn.Caption = DynamicReportUnboundColumn.HeaderText
                GridColumn.Visible = DynamicReportUnboundColumn.IsVisible
                GridColumn.SortIndex = DynamicReportUnboundColumn.SortIndex
                GridColumn.SortOrder = DynamicReportUnboundColumn.SortOrder
                GridColumn.GroupIndex = DynamicReportUnboundColumn.GroupIndex
                GridColumn.Width = DynamicReportUnboundColumn.Width
                GridColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex
                GridColumn.UnboundType = DynamicReportUnboundColumn.UnboundType
                GridColumn.UnboundExpression = DynamicReportUnboundColumn.Expression

                If String.IsNullOrEmpty(DynamicReportUnboundColumn.Format) = False Then

                    If GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = DynamicReportUnboundColumn.Format

                    End If

                End If

                GridColumn.VisibleIndex = DynamicReportUnboundColumn.VisibleIndex

            Next

            For Each DynamicReportSummaryItem In AdvantageFramework.Reporting.Database.Procedures.DynamicReportSummaryItem.LoadByDynamicReportID(ReportingDbContext, DynamicReportID).ToList

                If DynamicReportSummaryItem.OnFooter = False AndAlso String.IsNullOrWhiteSpace(DynamicReportSummaryItem.ColumnName) = False Then

                    GridColumn = GridView.Columns(DynamicReportSummaryItem.FieldName)

                    If GridColumn IsNot Nothing Then

                        GridColumn.SummaryItem.FieldName = DynamicReportSummaryItem.ColumnName
                        GridColumn.SummaryItem.SummaryType = DynamicReportSummaryItem.SummaryItemType
                        GridColumn.SummaryItem.DisplayFormat = DynamicReportSummaryItem.DisplayFormat

                    End If

                Else

                    If DynamicReportSummaryItem.OnFooter Then

                        If GridView.Columns(DynamicReportSummaryItem.ColumnName) IsNot Nothing Then

                            GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DynamicReportSummaryItem.SummaryItemType,
                                                                                                                                                   DynamicReportSummaryItem.FieldName,
                                                                                                                                                   GridView.Columns(DynamicReportSummaryItem.ColumnName),
                                                                                                                                                   DynamicReportSummaryItem.DisplayFormat)})

                        End If

                    Else

                        GridView.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DynamicReportSummaryItem.SummaryItemType,
                                                                                                                                               DynamicReportSummaryItem.FieldName,
                                                                                                                                               Nothing,
                                                                                                                                               DynamicReportSummaryItem.DisplayFormat)})

                    End If

                End If

            Next

        End Sub
        Private Sub SendASPReportDownloadEmail(DbContext As AdvantageFramework.Database.DbContext, File As String, EmailAddress As String)

            'objects
            Dim EmailSent As Boolean = False
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = String.Empty
            Dim MIMEType As String = String.Empty
            Dim FileName As String = String.Empty

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                MIMEType = AdvantageFramework.FileSystem.GetMIMEType(File)
                FileName = AdvantageFramework.FileSystem.GetFileName(File)

                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                HtmlEmail.AddHeaderRow("Report Link")
                HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "Document/ReportDownload?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database &
                                                                                                                                                                                   "&Date=" & Now.ToString("MM/dd/yyyy hh:mm:ss tt") &
                                                                                                                                                                                   "&File=" & File.Replace("&", "<>") &
                                                                                                                                                                                   "&MIMEType=" & MIMEType) & "%7C"" > Click Here to download your report</a>")

                HtmlEmail.AddBlankRow()
                HtmlEmail.AddBlankRow()

                HtmlEmail.Finish()

                EmailSent = AdvantageFramework.Email.Send(DbContext, EmailAddress, "", "", "Report Download - " & FileName, HtmlEmail.ToString, 3, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus)

            End If

        End Sub
        Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Bold)

            CreateTextBrick = TextBrick

        End Function
        Private Sub CreateReportHeaderAreaEvent(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim TextSize As System.Drawing.Size = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DataGridViewReport_Report As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            If TypeOf sender Is AdvantageFramework.Reporting.Reports.CustomLink Then

                DataGridViewReport_Report = sender.Tag
                DynamicReport = DataGridViewReport_Report.Tag

            End If

            If DynamicReport IsNot Nothing Then

                Try

                    TextSize = System.Windows.Forms.TextRenderer.MeasureText(DynamicReport.Description, New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Bold))

                    If TextSize = Nothing Then

                        If DataGridViewReport_Report.CurrentView.VisibleColumns.Count = 0 Then

                            TextBrick = CreateTextBrick(0, 0, e.Graph.ClientPageSize.Width, 15)

                        Else

                            TextBrick = CreateTextBrick(0, 0, DataGridViewReport_Report.CurrentView.VisibleColumns(0).VisibleWidth, 15)

                        End If

                    Else

                        TextBrick = CreateTextBrick(0, 0, TextSize.Width + 15, TextSize.Height + 5)

                    End If

                    TextBrick.Text = DynamicReport.Description

                    e.Graph.DrawBrick(TextBrick)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub ExportData(ByRef DbContext As AdvantageFramework.Database.DbContext,
                               ByRef ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByRef DynamicReportObjects As IEnumerable,
                               AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule,
                               DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport, OutputPath As String)

            'objects
            Dim DataGridViewReport_Report As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim SaveToFilename As String = Nothing
            Dim UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel = Nothing
            Dim AdvantageServiceReportScheduleEntity As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule = Nothing

            DataGridViewReport_Report = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            DataGridViewReport_Report.Tag = DynamicReport

            DataGridViewReport_Report.DataSource = DynamicReportObjects
            DataGridViewReport_Report.CurrentView.AFActiveFilterString = DynamicReport.ActiveFilter

            DataGridViewReport_Report.GridControl.ForceInitialize()
            DataGridViewReport_Report.CurrentView.PopulateColumns()

            LoadDynamicReportTemplateColumnDetails(ReportingDbContext, DynamicReport.ID, DataGridViewReport_Report.CurrentView)

            AddHandler DataGridViewReport_Report.CreateReportHeaderAreaEvent, AddressOf CreateReportHeaderAreaEvent

            DataGridViewReport_Report.OptionsView.AllowCellMerge = DynamicReport.AllowCellMerge
            DataGridViewReport_Report.OptionsPrint.AutoWidth = DynamicReport.AutoSizeColumnsWhenPrinting
            DataGridViewReport_Report.OptionsPrint.PrintHeader = DynamicReport.PrintHeader
            DataGridViewReport_Report.OptionsPrint.PrintFooter = DynamicReport.PrintFooter
            DataGridViewReport_Report.OptionsPrint.PrintGroupFooter = DynamicReport.PrintGroupFooter
            DataGridViewReport_Report.OptionsPrint.PrintSelectedRowsOnly = DynamicReport.PrintSelectedRowsOnly
            DataGridViewReport_Report.OptionsPrint.PrintFilterInfo = DynamicReport.PrintFilterInformation
            DataGridViewReport_Report.OptionsView.ShowGroupPanel = DynamicReport.ShowGroupByBox
            DataGridViewReport_Report.OptionsView.ShowViewCaption = DynamicReport.ShowViewCaption
            DataGridViewReport_Report.OptionsView.ShowAutoFilterRow = DynamicReport.ShowAutoFilterRow
            DynamicReport.ActiveFilter = DataGridViewReport_Report.CurrentView.AFActiveFilterString

            SaveToFilename = AdvantageFramework.FileSystem.CreateValidFileName(AdvantageServiceReportSchedule.EmployeeCode & "_" & DynamicReport.Description) & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

            UserLookAndFeel = New DevExpress.LookAndFeel.UserLookAndFeel(DataGridViewReport_Report)

            SaveToFilename = System.IO.Path.Combine(OutputPath, SaveToFilename)

            If AdvantageServiceReportSchedule.ExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.CSV Then

                SaveToFilename = SaveToFilename & ".csv"

            ElseIf AdvantageServiceReportSchedule.ExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.XLS Then

                SaveToFilename = SaveToFilename & ".xls"

            ElseIf AdvantageServiceReportSchedule.ExportType = Database.Entities.Methods.AdvantageServiceReportScheduleExportType.XLSX Then

                SaveToFilename = SaveToFilename & ".xlsx"

            End If

            DataGridViewReport_Report.Print(UserLookAndFeel, DynamicReport.Description, IsScheduledReportService:=True, SaveToFilename:=SaveToFilename, AdvantageServiceReportScheduleExportType:=AdvantageServiceReportSchedule.ExportType)

            AdvantageServiceReportScheduleEntity = AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.LoadByID(DbContext, AdvantageServiceReportSchedule.ID)

            If AdvantageServiceReportScheduleEntity IsNot Nothing Then

                AdvantageServiceReportScheduleEntity.LastRan = Now

                AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.Update(DbContext, AdvantageServiceReportScheduleEntity)

            End If

            RemoveHandler DataGridViewReport_Report.CreateReportHeaderAreaEvent, AddressOf CreateReportHeaderAreaEvent

            If Not String.IsNullOrWhiteSpace(AdvantageServiceReportSchedule.EmailAddress) Then

                SendASPReportDownloadEmail(DbContext, SaveToFilename, AdvantageServiceReportSchedule.EmailAddress)

            End If

            DataGridViewReport_Report.ClearDatasource()

            DataGridViewReport_Report = Nothing

        End Sub
        Private Function ExecuteReport(ByRef DbContext As AdvantageFramework.Database.DbContext, ByRef ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                                       DataContext As AdvantageFramework.Database.DataContext, Session As AdvantageFramework.Security.Session,
                                       AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule,
                                       OutputFolder As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim DynamicReportObjects As IEnumerable = Nothing
            Dim Executed As Boolean = True
            Dim [Continue] As Boolean = True
            Dim VirtualCreditCardTransactionEFSDetails As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail) = Nothing

            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, AdvantageServiceReportSchedule.ReportID)

            If DynamicReport IsNot Nothing Then

                If DynamicReport.Type = AdvantageFramework.Reporting.DynamicReports.VirtualCreditCardTransactionEFS Then

                    If AdvantageFramework.VCC.LoadVCCProvider(DataContext) <> AdvantageFramework.VCC.VCCProviders.EFS Then

                        ErrorMessage = "VCC Provider must be EFS."
                        Executed = False
                        [Continue] = False

                    ElseIf Not AdvantageFramework.VCC.IsVCCServiceSetup(Session) Then

                        ErrorMessage = "VCC settings are not configured correctly."
                        Executed = False
                        [Continue] = False

                    Else

                        VirtualCreditCardTransactionEFSDetails = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail)

                        If AdvantageFramework.VCC.GetTransactionsForDataset(Session, Now.AddDays(-1).ToShortDateString, Now.AddDays(-1).ToShortDateString, VirtualCreditCardTransactionEFSDetails, ErrorMessage) = True Then

                            ParameterDictionary = New Generic.Dictionary(Of String, Object)

                            ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.DateRangeType.ToString) = 1
                            ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.VirtualCreditCardTransactionEFSDetails.ToString) = VirtualCreditCardTransactionEFSDetails
                            ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.StartDate.ToString) = Now.AddDays(-1).ToShortDateString
                            ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.EndDate.ToString) = Now.AddDays(-1).ToShortDateString
                            ParameterDictionary(AdvantageFramework.Reporting.VirtualCreditCardTransactionsEFSInitialCriteria.IncludeTransactionDetail.ToString) = True

                        Else

                            Executed = False
                            [Continue] = False

                        End If

                    End If

                Else

                    ParameterDictionary = AdvantageFramework.ClassUtilities.ReadObjectContentInDocument(AdvantageServiceReportSchedule.ParameterDictionary)

                End If

                If [Continue] Then

                    DynamicReportObjects = AdvantageFramework.Reporting.LoadDynamicReportData(DbContext, ReportingDbContext, DynamicReport.Type, False, AdvantageServiceReportSchedule.Criteria.GetValueOrDefault(0), AdvantageServiceReportSchedule.FilterString, AdvantageServiceReportSchedule.FromDate.GetValueOrDefault("1/1/1900"), AdvantageServiceReportSchedule.ToDate.GetValueOrDefault("1/1/1900"), AdvantageServiceReportSchedule.ShowJobsWithNoDetails, ParameterDictionary, Nothing).OfType(Of Object).ToList

                    If DynamicReportObjects IsNot Nothing Then

                        ExportData(DbContext, ReportingDbContext, DynamicReportObjects, AdvantageServiceReportSchedule, DynamicReport, OutputFolder)

                    End If

                End If

            End If

            ExecuteReport = Executed

        End Function
        Public Sub ProcessDatabase(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile, ProcessNow As Boolean)

            'objects
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim IsAgencyASP As Boolean = False
            Dim OutputFolder As String = Nothing
            Dim AdvantageServiceReportScheduleList As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule) = Nothing
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim DynamicReportObjects As IEnumerable = Nothing
            Dim RunReport As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                If DatabaseProfile IsNot Nothing Then

                    WriteToEventLog("Connecting to database --> " & DatabaseProfile.DatabaseName)

                    Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                            If IsAgencyASP Then

                                OutputFolder = System.IO.Path.Combine(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "ScheduledReports")

                                If Not My.Computer.FileSystem.DirectoryExists(OutputFolder) Then

                                    Throw New Exception("Output folder does not exist: " & DatabaseProfile.DatabaseName & Space(1) & OutputFolder)

                                End If

                            Else

                                LoadSettings(DataContext, OutputFolder)

                                If Not My.Computer.FileSystem.DirectoryExists(OutputFolder) Then

                                    My.Computer.FileSystem.CreateDirectory(OutputFolder)

                                End If

                            End If

                            AdvantageServiceReportScheduleList = AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.Load(DbContext).ToList

                            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                For Each AdvantageServiceReportSchedule In AdvantageServiceReportScheduleList

                                    RunReport = False

                                    If Now >= AdvantageServiceReportSchedule.ScheduleStartTime AndAlso Now.TimeOfDay > AdvantageServiceReportSchedule.ScheduleStartTime.TimeOfDay AndAlso
                                            (Not AdvantageServiceReportSchedule.ScheduleEndDate.HasValue OrElse AdvantageServiceReportSchedule.ScheduleEndDate.Value > Now) Then

                                        If AdvantageServiceReportSchedule.LastRan.HasValue = False OrElse AdvantageServiceReportSchedule.LastRan.Value.ToShortDateString <> Now.ToShortDateString Then

                                            If AdvantageServiceReportSchedule.Frequency = Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Daily Then

                                                RunReport = True

                                            ElseIf AdvantageServiceReportSchedule.Frequency = Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Weekly Then

                                                If (Now.DayOfWeek = DayOfWeek.Sunday AndAlso AdvantageServiceReportSchedule.Sunday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Monday AndAlso AdvantageServiceReportSchedule.Monday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Tuesday AndAlso AdvantageServiceReportSchedule.Tuesday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Wednesday AndAlso AdvantageServiceReportSchedule.Wednesday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Thursday AndAlso AdvantageServiceReportSchedule.Thursday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Friday AndAlso AdvantageServiceReportSchedule.Friday) OrElse
                                                        (Now.DayOfWeek = DayOfWeek.Saturday AndAlso AdvantageServiceReportSchedule.Saturday) Then

                                                    RunReport = True

                                                End If

                                            ElseIf AdvantageServiceReportSchedule.Frequency = Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Monthly Then

                                                If Now.Day = AdvantageServiceReportSchedule.DayOfMonth.Value Then

                                                    RunReport = True

                                                End If

                                            End If

                                        End If

                                    End If

                                    If RunReport OrElse ProcessNow Then

                                        ErrorMessage = String.Empty

                                        If ExecuteReport(DbContext, ReportingDbContext, DataContext, Session, AdvantageServiceReportSchedule, OutputFolder, ErrorMessage) = False AndAlso String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                            WriteToEventLog("Scheduled reports Error Processing - " & ErrorMessage & " --> " & DatabaseProfile.DatabaseName)

                                        End If

                                        System.GC.Collect()

                                    End If

                                Next

                            End Using

                        End Using

                    End Using

                End If

            Catch ex As Exception

                WriteToEventLog("Scheduled reports Error Processing - " & ex.Message & " --> " & DatabaseProfile.DatabaseName)

            End Try

        End Sub
        Public Function IsServiceReadyToRun(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile) As Boolean

            'objects
            Dim ServiceIsReadyToRun As Boolean = False
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            If DatabaseProfile IsNot Nothing Then

                Try

                    Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                        AdvantageService = LoadAdvantageService(DataContext)

                        If AdvantageService IsNot Nothing AndAlso AdvantageService.Enabled Then

                            ServiceIsReadyToRun = True

                        End If

                    End Using

                Catch ex As Exception
                    ServiceIsReadyToRun = False
                End Try

            End If

            IsServiceReadyToRun = ServiceIsReadyToRun

        End Function
        Public Sub Run(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            If DatabaseProfile IsNot Nothing Then

                Try

                    If IsServiceReadyToRun(DatabaseProfile) Then

                        ProcessDatabase(DatabaseProfile, False)

                    End If

                Catch ex As Exception
                    WriteToEventLog("Error -->" & ex.Message & Space(1) & DatabaseProfile.DatabaseName)
                End Try

                WriteToEventLog("Running -->" & Space(1) & DatabaseProfile.DatabaseName)

            End If

        End Sub
        Public Function LoadLogEntries() As String

            'objects
            Dim Log As String = ""

            Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

            LoadLogEntries = Log

        End Function
        Public Function LoadLog(ByVal LoadEntries As Boolean, Optional ByRef LastEntryMessage As String = "") As String

            'objects
            Dim Log As String = ""
            Dim Entry As System.Diagnostics.EventLogEntry = Nothing

            If System.Diagnostics.EventLog.SourceExists("Scheduled Reports Source") = False Then

                System.Diagnostics.EventLog.CreateEventSource("Scheduled Reports Source", "Scheduled Reports Log")

            End If

            _EventLog = New System.Diagnostics.EventLog("Scheduled Reports Log", My.Computer.Name, "Scheduled Reports Source")

            _EventLog.ModifyOverflowPolicy(System.Diagnostics.OverflowAction.OverwriteAsNeeded, _EventLog.MinimumRetentionDays)

            _EventLog.EnableRaisingEvents = True

            If LoadEntries Then

                Log = AdvantageFramework.Services.LoadLogEntries(_EventLog)

                Try

                    Entry = _EventLog.Entries.OfType(Of System.Diagnostics.EventLogEntry).OrderByDescending(Function(EventLogEntry) EventLogEntry.TimeGenerated).FirstOrDefault

                Catch ex As Exception
                    Entry = Nothing
                End Try

                If Entry IsNot Nothing Then

                    LastEntryMessage = Entry.Message & "...."

                End If

            End If

            LoadLog = Log

        End Function
        Public Function LoadAdvantageService(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.AdvantageService

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            Try

                AdvantageService = AdvantageFramework.Services.LoadAdvantageService(DataContext, AdvantageFramework.Services.Service.AdvantageScheduledReportsService)

            Catch ex As Exception
                AdvantageService = Nothing
            End Try

            LoadAdvantageService = AdvantageService

        End Function
        Public Function LoadAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.ScheduledReports.RegistrySetting) As Object

            'objects
            Dim SettingValue As Object = Nothing

            Try

                SettingValue = AdvantageFramework.Services.LoadAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString)

            Catch ex As Exception
                SettingValue = Nothing
            End Try

            LoadAdvantageServiceSettingValue = SettingValue

        End Function
        Public Function SaveAdvantageServiceSettingValue(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AdvantageServiceID As Integer, ByVal RegistrySetting As AdvantageFramework.Services.ScheduledReports.RegistrySetting, ByVal SettingValue As Object) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                Saved = AdvantageFramework.Services.SaveAdvantageServiceSettingValue(DataContext, AdvantageServiceID, RegistrySetting.ToString, SettingValue)

            Catch ex As Exception
                Saved = False
            End Try

            SaveAdvantageServiceSettingValue = Saved

        End Function
        Public Sub LoadSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef OutputFolder As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                OutputFolder = LoadAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ScheduledReports.RegistrySetting.OutputFolder)

            End If

        End Sub
        Public Sub SaveSettings(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal OutputFolder As String)

            'objects
            Dim AdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing

            AdvantageService = LoadAdvantageService(DataContext)

            If AdvantageService IsNot Nothing Then

                SaveAdvantageServiceSettingValue(DataContext, AdvantageService.ID, AdvantageFramework.Services.ScheduledReports.RegistrySetting.OutputFolder, OutputFolder)

            End If

        End Sub
        Public Sub WriteToEventLog(ByVal Message As String)

            Try

                If _EventLog IsNot Nothing Then

                    SyncLock _EventLog

                        _EventLog.WriteEntry(Message)

                    End SyncLock

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ClearLog()

            Try

                If _EventLog Is Nothing Then

                    LoadLog(False)

                End If

                If _EventLog IsNot Nothing Then

                    SyncLock _EventLog

                        _EventLog.Clear()

                    End SyncLock

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Module

End Namespace

