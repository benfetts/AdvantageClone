Namespace ProjectManagement.Reports.Presentation.Classes

    Public Class ReportCommandHandler
        Implements DevExpress.XtraReports.UserDesigner.ICommandHandler

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _XRDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Type As Integer = 0
        Private _Description As String = ""
        Private _Category As Integer = 0

#End Region

#Region " Properties "

        Public Property Type As Integer
            Get
                Type = _Type
            End Get
            Set(value As Integer)
                _Type = value
            End Set
        End Property
        Public Property Description As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Category As Integer
            Get
                Category = _Category
            End Get
            Set(value As Integer)
                _Category = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal XrDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController, ByVal Session As AdvantageFramework.Security.Session)

            _XRDesignMdiController = XrDesignMdiController
            _Session = Session

        End Sub
        Public Overridable Function CanHandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.CanHandleCommand

            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFile Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs Then

                CanHandleCommand = True
                useNextHandler = False

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab Then

                CanHandleCommand = True
                useNextHandler = False

            Else

                CanHandleCommand = False

            End If

        End Function
        Public Overridable Sub HandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal Args() As Object) Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.HandleCommand

            'objects
            Dim EstimateType As Estimate.Printing.ReportFormats = Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim ContinueShowingEstimate As Boolean = True
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim CustomEstimateID As Integer = 0
            Dim AgencyImportPath As String = ""
            Dim IsAgencyASP As Boolean = False
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing


            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then



            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then



            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFile Then

                Save()

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs Then

                SaveAs()

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab Then

                Save()

                If _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved Then

                    Try

                        EstimateType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport

                    Catch ex As Exception
                        ContinueShowingEstimate = False
                    End Try

                    If ContinueShowingEstimate Then

                        Try

                            CustomEstimateID = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID

                        Catch ex As Exception
                            ContinueShowingEstimate = False
                        End Try

                    End If

                    If ContinueShowingEstimate Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            EstimateQuotes = AdvantageFramework.Estimate.Printing.LoadEstimateQuotes(DbContext, _Session.UserCode, Now.AddYears(-1), Now).ToList

                        End Using

                        If EstimateQuotes.Count > 0 Then

                            Try

                                EstimateQuote = EstimateQuotes.FirstOrDefault

                            Catch ex As Exception
                                EstimateQuote = Nothing
                            End Try


                            If EstimateQuote IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, DataContext, Estimate.Printing.EstimateFormatTypes.Agency).ToList

                                    End Using
                                End Using


                                If EstimatePrintingSettings.Count > 0 Then

                                    EstimatePrintingSettings.First.CustomEstimateID = CustomEstimateID

                                Else

                                    ContinueShowingEstimate = False

                                End If



                                If ContinueShowingEstimate Then

                                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(_Session, EstimateQuote, EstimatePrintingSettings.FirstOrDefault, EstimateType, EstimateQuote.EstimateComponentNumber.ToString & ",", EstimateQuote.QuoteNumber.ToString & ",",
                                                                                                 "", IIf(EstimatePrintingSettings.FirstOrDefault.SummaryLevel = 2, 1, 0))

                                    'Report = AdvantageFramework.Reporting.Reports.CreateInvoice(_Session, AccountReceivableInvoice, InvoicePrintingSettings.FirstOrDefault,
                                    '                                                           InvoicePrintingMediaSettings.FirstOrDefault, False, False, InvoicePrinting.InvoicePrintingTypes.Preview)


                                    If Report IsNot Nothing Then

                                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                            IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                                            If IsAgencyASP Then

                                                AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                            End If

                                        End Using

                                        If IsAgencyASP Then

                                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                                                End If

                                            End If

                                            ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(_XRDesignMdiController.ActiveDesignPanel.Report.DisplayName)
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                            ReportPrintTool.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                            ReportPrintTool.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(_Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName))

                                            'ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                                            ReportPrintTool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                                            ReportPrintTool.ShowRibbonPreviewDialog()

                                        Else

                                            ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                            ReportPrintTool.ShowRibbonPreviewDialog()

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub Save()

            'objects
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim ReportID As Integer = 0

            Try

                If _XRDesignMdiController.ActiveDesignPanel IsNot Nothing AndAlso _XRDesignMdiController.ActiveDesignPanel.Report IsNot Nothing Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            ReportID = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID

                        Catch ex As Exception
                            ReportID = 0
                        End Try

                        EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, ReportID)

                        If EstimateReport IsNot Nothing Then

                            'EstimateReport.EstimateReportType = _Type 'DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport
                            EstimateReport.ReportDefinition = LoadReportDefinition()
                            EstimateReport.UpdatedByUserCode = ReportingDbContext.UserCode
                            EstimateReport.UpdatedDate = Now

                            If AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Update(ReportingDbContext, EstimateReport) Then

                                _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                            End If

                        Else

                            If AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Insert(ReportingDbContext, _Type, Description,
                            ReportingDbContext.UserCode, Now,
                            LoadReportDefinition(), Category, EstimateReport) Then

                                _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = EstimateReport.Description
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID
                                _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveAs()

            'objects
            Dim EstimateReportType As AdvantageFramework.Reporting.EstimateReportTypes = Reporting.EstimateReportTypes.OneQuotePerPage
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim Description As String = ""
            Dim ReportDefinition As String = ""

            EstimateReportType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReport

            If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Estimate, 0, EstimateReportType, Description, 0, False) = System.Windows.Forms.DialogResult.OK Then

                _Description = Description

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ReportDefinition = LoadReportDefinition()

                    If AdvantageFramework.Reporting.Database.Procedures.EstimateReport.Insert(ReportingDbContext, EstimateReportType, Description,
                                                                                                ReportingDbContext.UserCode, Now,
                                                                                                ReportDefinition, Category, EstimateReport) Then

                        _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = EstimateReport.Description
                        DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID
                        _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                    End If

                End Using

            End If

        End Sub
        Private Function LoadReportDefinition() As String

            'objects
            Dim ReportDefinition As String = ""
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            _XRDesignMdiController.ActiveDesignPanel.Report.SaveLayout(MemoryStream)

            MemoryStream.Position = 0

            Using StreamReader = New System.IO.StreamReader(MemoryStream)

                ReportDefinition = StreamReader.ReadToEnd

            End Using

            If MemoryStream IsNot Nothing Then

                MemoryStream.Close()
                MemoryStream.Dispose()

                MemoryStream = Nothing

            End If

            LoadReportDefinition = ReportDefinition

        End Function

#End Region

    End Class

End Namespace

