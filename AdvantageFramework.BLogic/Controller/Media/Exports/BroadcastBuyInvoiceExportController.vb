Namespace Controller.Media.Exports

    Public Class BroadcastBuyInvoiceExportController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        'Private Sub AppendTVSpotDateColumns(TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail, ByRef Header As String, ByRef Data As String)

        '    If TVOrderDetail.Date1.HasValue Then

        '        Header += "," & TVOrderDetail.Date1.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots1.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date2.HasValue Then

        '        Header += "," & TVOrderDetail.Date2.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots2.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date3.HasValue Then

        '        Header += "," & TVOrderDetail.Date3.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots3.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date4.HasValue Then

        '        Header += "," & TVOrderDetail.Date4.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots4.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date5.HasValue Then

        '        Header += "," & TVOrderDetail.Date5.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots5.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date6.HasValue Then

        '        Header += "," & TVOrderDetail.Date6.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots6.GetValueOrDefault(0)

        '    End If

        '    If TVOrderDetail.Date7.HasValue Then

        '        Header += "," & TVOrderDetail.Date7.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & TVOrderDetail.Spots7.GetValueOrDefault(0)

        '    End If

        'End Sub
        'Private Sub AppendRadioSpotDateColumns(RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail, ByRef Header As String, ByRef Data As String)

        '    If RadioOrderDetail.Date1.HasValue Then

        '        Header += "," & RadioOrderDetail.Date1.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots1.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date2.HasValue Then

        '        Header += "," & RadioOrderDetail.Date2.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots2.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date3.HasValue Then

        '        Header += "," & RadioOrderDetail.Date3.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots3.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date4.HasValue Then

        '        Header += "," & RadioOrderDetail.Date4.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots4.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date5.HasValue Then

        '        Header += "," & RadioOrderDetail.Date5.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots5.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date6.HasValue Then

        '        Header += "," & RadioOrderDetail.Date6.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots6.GetValueOrDefault(0)

        '    End If

        '    If RadioOrderDetail.Date7.HasValue Then

        '        Header += "," & RadioOrderDetail.Date7.Value.ToString("yyMMdd") & "SPOTS"
        '        Data += "," & RadioOrderDetail.Spots7.GetValueOrDefault(0)

        '    End If

        'End Sub
        Private Sub AppendSpotDateColumns(BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.BroadcastCalendar),
                                          MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate),
                                          ByRef Data As String)

            For Each BroadcastCalendar In BroadcastCalendars

                Data += "," & MediaBroadcastWorksheetMarketDetailDates.Where(Function(DD) DD.Date >= BroadcastCalendar.BRD_WEEK_START AndAlso DD.Date <= BroadcastCalendar.BRD_WEEK_END).Sum(Function(DD) DD.Spots)

            Next

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel

            'objects
            Dim ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel = Nothing

            ViewModel = New AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If ViewModel.IsAgencyASP Then

                    ViewModel.AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Reports"

                End If

                ViewModel.BroadcastMonthList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.FiscalMonths)).Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList
                ViewModel.BroadcastQuarterList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateQuarterValue)).Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                ViewModel.ClientList = (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList
                                        Select New AdvantageFramework.DTO.Client(Entity)).ToList

            End Using

            Load = ViewModel

        End Function
        Public Function ExportBuyAndInvoiceFiles(ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel,
                                                 ByRef ErrorMessage As String) As Boolean

            Dim Exported As Boolean = False
            Dim BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.BroadcastCalendar) = Nothing
            Dim BroadcastBuyFileName As String = ""
            Dim BroadcastInvoiceFileName As String = ""
            Dim Header As String = Nothing
            Dim Data As String = Nothing
            Dim StreamWriter As IO.StreamWriter = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim BuyList As Generic.List(Of AdvantageFramework.DTO.Media.Buy) = Nothing
            Dim InvoiceList As Generic.List(Of AdvantageFramework.DTO.Media.Invoice) = Nothing
            Dim HostedSent As Boolean = False

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If ViewModel.SelectedClientCodes IsNot Nothing AndAlso ViewModel.SelectedClientCodes.Count > 0 Then

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList

                    Else

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList

                    End If

                    BroadcastCalendars = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.BroadcastCalendar)(String.Format("SELECT * FROM dbo.fn_BroadcastCal2('01/01/1996') WHERE BRD_YEAR = {0}", ViewModel.Year)).ToList
                                          Where ViewModel.Months.Contains(Entity.BRD_MONTH)
                                          Select Entity).ToList

                    Header = "MEDIA,CLIENT,PRODUCT,EST,ESTIMATE,BUY_DATES,MARKET,STATION,LINE,PROGRAMMING,DAYPART,LEN,ROTATION,TIMES,COST_PER_SPOT,RATING"

                    For Each BroadcastCalendar In BroadcastCalendars

                        Header += "," & BroadcastCalendar.BRD_WEEK_START.ToString("yyMMdd") & "SPOTS"

                    Next

                    StartDate = BroadcastCalendars.Min(Function(BC) BC.BRD_WEEK_START)
                    EndDate = BroadcastCalendars.Max(Function(BC) BC.BRD_WEEK_END)

                    If ViewModel.OutputFolder.EndsWith("\") = False Then

                        ViewModel.OutputFolder = ViewModel.OutputFolder & "\"

                    End If

                    BroadcastBuyFileName = ViewModel.OutputFolder & "Buy_" & ViewModel.FilePrefix & ".csv"

                    StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(BroadcastBuyFileName, False)

                    StreamWriter.WriteLine(Header)

                    For Each Buy In BuyList

                        With Buy

                            Data = .MEDIA & "," & .CLIENT & "," & .PRODUCT & "," & .EST & "," & .ESTIMATE & "," & .BUY_DATES & "," & .MARKET & "," & .STATION & "," & .LINE & "," & .PROGRAMMING & "," & .DAYPART &
                            "," & .LEN & "," & .ROTATION & "," & .TIMES & "," & .COST_PER_SPOT & "," & .RATING.GetValueOrDefault(0)

                        End With

                        MediaBroadcastWorksheetMarketDetailDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                    Where Entity.OrderNumber = Buy.EST AndAlso
                                                                      Entity.OrderLineNumber = Buy.LINE AndAlso
                                                                      Entity.Date >= StartDate AndAlso
                                                                      Entity.Date <= EndDate).ToList

                        AppendSpotDateColumns(BroadcastCalendars, MediaBroadcastWorksheetMarketDetailDates, Data)

                        StreamWriter.WriteLine(Data)

                    Next

                    StreamWriter.Close()

                    'start invoice file
                    BroadcastInvoiceFileName = ViewModel.OutputFolder & "Invoice_" & ViewModel.FilePrefix & ".csv"

                    Header = "MEDIA,CLIENT,PRODUCT,EST,ESTIMATE,MARKET,STATION,[DATE],TIME,LEN,InvoiceCost,InvoiceNumber,FILM,SpotsInvoice"

                    StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(BroadcastInvoiceFileName, False)

                    StreamWriter.WriteLine(Header)

                    For Each Invoice In InvoiceList

                        With Invoice

                            Data = .MEDIA & "," & .CLIENT & "," & .PRODUCT & "," & .EST & "," & .ESTIMATE & "," & .MARKET & "," & .STATION & "," & .DATE & "," & .TIME.ToString.Substring(0, 5) & "," & .LEN &
                            "," & .InvoiceCost & "," & .InvoiceNumber & "," & .FILM & "," & .SpotsInvoice

                        End With

                        StreamWriter.WriteLine(Data)

                    Next

                    StreamWriter.Close()
                    'end invoice file

                    Exported = True

                    If ViewModel.IsAgencyASP Then

                        HostedSent = AdvantageFramework.Email.SendASPReportDownloadEmail(Session, BroadcastBuyFileName) AndAlso AdvantageFramework.Email.SendASPReportDownloadEmail(Session, BroadcastInvoiceFileName)

                        If HostedSent = False Then

                            ErrorMessage = "File(s) exported successfully but email link could not be sent to your email."

                            Exported = False

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            ExportBuyAndInvoiceFiles = Exported

        End Function
        Public Sub SetBroadcastStartEndDates(Month As Integer, Year As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, Month)).FirstOrDefault
                ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, Month)).FirstOrDefault
                ViewModel.Months = {Month}

            End Using

        End Sub
        Public Sub SetQuarterStartEndDates(Quarter As Integer, Year As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Select Case Quarter

                    Case 1

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 1)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 3)).FirstOrDefault
                        ViewModel.Months = {1, 2, 3}
                        ViewModel.Quarter = "Q1"

                    Case 2

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 4)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 6)).FirstOrDefault
                        ViewModel.Months = {4, 5, 6}
                        ViewModel.Quarter = "Q2"

                    Case 3

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 7)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 9)).FirstOrDefault
                        ViewModel.Months = {7, 8, 9}
                        ViewModel.Quarter = "Q3"

                    Case 4

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 10)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 12)).FirstOrDefault
                        ViewModel.Months = {10, 11, 12}
                        ViewModel.Quarter = "Q4"

                End Select

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
