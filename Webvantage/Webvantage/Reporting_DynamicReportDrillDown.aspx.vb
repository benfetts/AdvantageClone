Public Class Reporting_DynamicReportDrillDown
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected WithEvents RadComboBoxDynamicReport As Telerik.Web.UI.RadComboBox = Nothing
    Protected _DynamicReportTemplateID As Integer = 0
    Protected _DynamicReportType As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private _ClientCode As String = ""
    Private _ColumnName As String = ""

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadGrid()

        Dim CashReportDetails As Generic.List(Of AdvantageFramework.Database.Classes.CashAnalysisDetailReport) = Nothing
        Dim CashParameters As AdvantageFramework.Reporting.Classes.CashAnalysisDrillDownParameter = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _DynamicReportTemplateID = 48 Then

                    'Me.Text = "Cash Analysis Report Details"

                    _ParameterDictionary = Session("DRPT_ParameterDictionary")

                    CashReportDetails = AdvantageFramework.Reporting.LoadCashAnalysisDataDetail(DbContext, _ParameterDictionary("StartingPostPeriodCode"), _ParameterDictionary("EndingPostPeriodCode"), _ClientCode, _ColumnName)

                    ASPxGridViewDynamicReport.DataSource = CashReportDetails

                End If

            End Using

        Catch ex As Exception

        End Try

    End Sub


#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReportDrillDown_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Try

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            _DynamicReportTemplateID = qs.Get("DynamicReportTemplateID")
            _ClientCode = qs.ClientCode
            _ColumnName = qs.Get("ColumnName")

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try


    End Sub
    Private Sub Reporting_DynamicReportDrillDown_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If ASPxGridViewDynamicReport.FilterEnabled = False Then

            ASPxGridViewDynamicReport.FilterEnabled = True

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarPrinting_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPrinting.ButtonClick

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim GridViewLink As DevExpress.Web.Export.GridViewLink = Nothing
        Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
        Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
        Dim FileName As String = ""

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportTemplateID)

                If DynamicReport IsNot Nothing Then

                    ASPxGridViewExporter.ReportHeader = DynamicReport.Description

                    ASPxGridViewExporter.ReportFooter = DynamicReport.ActiveFilter

                    ASPxGridViewExporter.FileName = DynamicReport.Description

                    ASPxGridViewExporter.PageHeader.Font.Name = "Arial"
                    ASPxGridViewExporter.PageFooter.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Cell.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.AlternatingRowCell.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Default.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Footer.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.GroupFooter.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.GroupRow.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Header.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.HyperLink.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Preview.Font.Name = "Arial"
                    ASPxGridViewExporter.Styles.Title.Font.Name = "Arial"

                    FileName = ASPxGridViewExporter.FileName

                Else

                    If AdvantageFramework.EnumUtilities.IsMemberOfEnum(GetType(AdvantageFramework.Reporting.DynamicReports), CInt(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.DynamicReports), RadComboBoxDynamicReport.SelectedValue))) Then

                        FileName = CType(RadComboBoxDynamicReport.SelectedValue, AdvantageFramework.Reporting.DynamicReports).ToString

                    Else

                        FileName = "ASPxGridViewExporter"

                    End If

                End If

                GridViewLink = New DevExpress.Web.Export.GridViewLink(ASPxGridViewExporter)

                PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem

                CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

                CompositeLink.Links.Add(GridViewLink)

                CompositeLink.CreateDocument(False)

                Using MemoryStream As New System.IO.MemoryStream()

                    Select Case e.Item.Value

                        Case RadToolBarButtonPrintToPDF.Value

                            'ASPxGridViewExporter.WritePdfToResponse()
                            CompositeLink.ExportToPdf(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/pdf")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".pdf")

                        Case RadToolBarButtonPrintToXLS.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xls")

                        Case RadToolBarButtonPrintToXLSValue.Value

                            'ASPxGridViewExporter.WriteXlsToResponse()
                            CompositeLink.ExportToXls(MemoryStream, New DevExpress.XtraPrinting.XlsExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/ms-excel")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xls")

                        Case RadToolBarButtonPrintToXLSX.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Text, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xlsx")

                        Case RadToolBarButtonPrintToXLSXValue.Value

                            'ASPxGridViewExporter.WriteXlsxToResponse()
                            CompositeLink.ExportToXlsx(MemoryStream, New DevExpress.XtraPrinting.XlsxExportOptions(DevExpress.XtraPrinting.TextExportMode.Value, False, False))

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".xlsx")

                        Case RadToolBarButtonPrintToRTF.Value

                            'ASPxGridViewExporter.WriteRtfToResponse()
                            CompositeLink.ExportToRtf(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/rtf")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".rtf")

                        Case RadToolBarButtonPrintToCSV.Value

                            'ASPxGridViewExporter.WriteCsvToResponse()
                            CompositeLink.ExportToCsv(MemoryStream)

                            System.Web.HttpContext.Current.Response.Clear()

                            System.Web.HttpContext.Current.Response.Buffer = True
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Type", "application/csv")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Transfer-Encoding", "binary")
                            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName & ".csv")

                    End Select

                    System.Web.HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray)
                    'System.Web.HttpContext.Current.Response.Flush()
                    'System.Web.HttpContext.Current.Response.End()
                    'System.Web.HttpContext.Current.Response.Clear()

                    'Response.BinaryWrite(MemoryStream.GetBuffer())

                    HttpContext.Current.ApplicationInstance.CompleteRequest()

                    Try

                        System.Web.HttpContext.Current.Response.End()

                    Catch ex As Exception

                    End Try

                End Using

                PrintingSystem.Dispose()

            End Using

        Catch ex As Exception
            'AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
        End Try

    End Sub
    Private Sub ASPxGridViewDynamicReport_ClientLayout(sender As Object, e As DevExpress.Web.ASPxClientLayoutArgs) Handles ASPxGridViewDynamicReport.ClientLayout

        If e.LayoutMode = DevExpress.Web.ClientLayoutMode.Saving Then

            Session("DRPT_Layout") = e.LayoutData

        Else

            e.LayoutData = Session("DRPT_Layout")

        End If

    End Sub

#End Region

#End Region


End Class