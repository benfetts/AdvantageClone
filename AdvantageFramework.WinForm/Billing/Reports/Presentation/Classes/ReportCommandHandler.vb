Namespace Billing.Reports.Presentation.Classes

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
            Dim InvoiceType As InvoicePrinting.InvoiceTypes = InvoicePrinting.Methods.InvoiceTypes.Production
            Dim ContinueShowingInvoice As Boolean = True
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim CustomInvoiceID As Integer = 0
            Dim AgencyImportPath As String = ""
            Dim IsAgencyASP As Boolean = False
            Dim ReportPrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing

            If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then



            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then



            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFile Then

                Save()

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.SaveFileAs Then

                If TypeOf _XRDesignMdiController.Form Is AdvantageFramework.Billing.Reports.Presentation.CustomInvoiceReportWriterEditForm AndAlso
                        CType(_XRDesignMdiController.Form, AdvantageFramework.Billing.Reports.Presentation.CustomInvoiceReportWriterEditForm).IsFormClosing Then

                    Save()

                Else

                    SaveAs()

                End If

            ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.ShowPreviewTab Then

                Save()

                If _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved Then

                    Try

                        InvoiceType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).InvoiceType

                    Catch ex As Exception
                        ContinueShowingInvoice = False
                    End Try

                    If ContinueShowingInvoice Then

                        Try

                            CustomInvoiceID = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).CustomInvoiceID

                        Catch ex As Exception
                            ContinueShowingInvoice = False
                        End Try

                    End If

                    If ContinueShowingInvoice Then

                        If InvoiceType = InvoicePrinting.InvoiceTypes.Media Then

                            ContinueShowingInvoice = (AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingQuickSelectionDialog.ShowFormDialog(AccountReceivableInvoices, InvoicePrintingQuickSelectionDialog.InvoiceTypes.MediaOnly, False) = Windows.Forms.DialogResult.OK)

                        Else

                            ContinueShowingInvoice = (AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingQuickSelectionDialog.ShowFormDialog(AccountReceivableInvoices, InvoicePrintingQuickSelectionDialog.InvoiceTypes.ProductionOnly, False) = Windows.Forms.DialogResult.OK)

                        End If

                    End If

                    If ContinueShowingInvoice Then

                        If AccountReceivableInvoices.Count > 0 Then

                            If InvoiceType = InvoicePrinting.Methods.InvoiceTypes.Media Then

                                Try

                                    AccountReceivableInvoice = AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.RecordType <> "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                            Else

                                Try

                                    AccountReceivableInvoice = AccountReceivableInvoices.FirstOrDefault(Function(Entity) Entity.RecordType = "P")

                                Catch ex As Exception
                                    AccountReceivableInvoice = Nothing
                                End Try

                            End If

                            If AccountReceivableInvoice IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).ToList
                                    InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).ToList

                                End Using

                                'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                '    InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).ToList

                                'End Using

                                If InvoiceType = InvoicePrinting.Methods.InvoiceTypes.Media Then

                                    If InvoicePrintingMediaSettings.Count > 0 Then

										InvoicePrintingMediaSettings.First.MagazineCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.NewspaperCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.InternetCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.OutdoorCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.RadioCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.TVCustomInvoiceID = CustomInvoiceID
										InvoicePrintingMediaSettings.First.MagazineCustomFormatName = ""
										InvoicePrintingMediaSettings.First.NewspaperCustomFormatName = ""
                                        InvoicePrintingMediaSettings.First.InternetCustomFormatName = ""
                                        InvoicePrintingMediaSettings.First.OutdoorCustomFormatName = ""
                                        InvoicePrintingMediaSettings.First.RadioCustomFormatName = ""
                                        InvoicePrintingMediaSettings.First.TVCustomFormatName = ""

                                    Else

                                        ContinueShowingInvoice = False

                                    End If

                                Else

                                    If InvoicePrintingSettings.Count > 0 Then

                                        InvoicePrintingSettings.First.CustomInvoiceID = CustomInvoiceID
                                        InvoicePrintingSettings.First.ReportFormatType = InvoiceType
                                        InvoicePrintingSettings.First.CustomFormatName = ""

                                    Else

                                        ContinueShowingInvoice = False

                                    End If

                                End If

                                If ContinueShowingInvoice Then

                                    Report = AdvantageFramework.Reporting.Reports.CreateInvoice(_Session, AccountReceivableInvoice, InvoicePrintingSettings.FirstOrDefault,
                                                                                                InvoicePrintingMediaSettings.FirstOrDefault, Nothing, InvoicePrintingMediaSettings.FirstOrDefault,
                                                                                                InvoicePrintingMediaSettings.FirstOrDefault, False, False, InvoicePrinting.InvoicePrintingTypes.Preview)

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
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
            Dim ReportID As Integer = 0

            Try

                If _XRDesignMdiController.ActiveDesignPanel IsNot Nothing AndAlso _XRDesignMdiController.ActiveDesignPanel.Report IsNot Nothing Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            ReportID = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).CustomInvoiceID

                        Catch ex As Exception
                            ReportID = 0
                        End Try

                        CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, ReportID)

                        If CustomInvoice IsNot Nothing Then

                            CustomInvoice.Type = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).InvoiceType
                            CustomInvoice.ReportDefinition = LoadReportDefinition()
                            CustomInvoice.UpdatedByUserCode = ReportingDbContext.UserCode
                            CustomInvoice.UpdatedDate = Now

                            If AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.Update(ReportingDbContext, CustomInvoice) Then

                                _XRDesignMdiController.ActiveDesignPanel.ReportState = DevExpress.XtraReports.UserDesigner.ReportState.Saved

                            End If

                        Else

                            If AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.Insert(ReportingDbContext, DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).InvoiceType, Description,
                                                                                                     ReportingDbContext.UserCode, Now,
                                                                                                     LoadReportDefinition(), CustomInvoice) Then

                                _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = CustomInvoice.Description
                                DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).CustomInvoiceID = CustomInvoice.ID
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
            Dim InvoiceType As AdvantageFramework.InvoicePrinting.InvoiceTypes = InvoicePrinting.InvoiceTypes.Production
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
            Dim Description As String = ""
            Dim ReportDefinition As String = ""

            InvoiceType = DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).InvoiceType

            If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Invoice, 0, InvoiceType, Description, 0, False) = System.Windows.Forms.DialogResult.OK Then

                _Description = Description

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ReportDefinition = LoadReportDefinition()

                    If AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.Insert(ReportingDbContext, InvoiceType, Description,
                                                                                                ReportingDbContext.UserCode, Now,
                                                                                                ReportDefinition, CustomInvoice) Then

                        _XRDesignMdiController.ActiveDesignPanel.Report.DisplayName = CustomInvoice.Description
                        DirectCast(_XRDesignMdiController.ActiveDesignPanel.Report, AdvantageFramework.Reporting.Reports.ICustomInvoice).CustomInvoiceID = CustomInvoice.ID
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

