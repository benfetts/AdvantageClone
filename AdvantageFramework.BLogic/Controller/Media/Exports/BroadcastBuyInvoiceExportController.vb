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

        Private Sub AppendSpotDateColumns(BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.BroadcastCalendar),
                                          MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate),
                                          ByRef Data As String, ByRef DataList As Generic.List(Of String))

            For Each BroadcastCalendar In BroadcastCalendars

                Data += "," & MediaBroadcastWorksheetMarketDetailDates.Where(Function(DD) DD.Date >= BroadcastCalendar.BRD_WEEK_START AndAlso DD.Date <= BroadcastCalendar.BRD_WEEK_END).Sum(Function(DD) DD.Spots)

                If DataList IsNot Nothing Then

                    DataList.Add(MediaBroadcastWorksheetMarketDetailDates.Where(Function(DD) DD.Date >= BroadcastCalendar.BRD_WEEK_START AndAlso DD.Date <= BroadcastCalendar.BRD_WEEK_END).Sum(Function(DD) DD.Spots))

                End If

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
        Public Function ExportBuyAndInvoiceFilesToExcel(ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel,
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
            Dim NCCTVSyscodeList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode) = Nothing

            Try

                If Session.IsNielsenSetup Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.Load(NielsenDbContext).ToList

                    End Using

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If ViewModel.SelectedClientCodes IsNot Nothing AndAlso ViewModel.SelectedClientCodes.Count > 0 Then

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList

                    Else

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList

                    End If

                    BroadcastCalendars = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.BroadcastCalendar)(String.Format("SELECT * FROM dbo.fn_BroadcastCal2('01/01/1996') WHERE BRD_YEAR = {0}", ViewModel.Year)).ToList
                                          Where Entity.BRD_WEEK_START >= ViewModel.StartDate AndAlso
                                                Entity.BRD_WEEK_END <= ViewModel.EndDate
                                          Select Entity).ToList

                    Header = "MEDIA,CLIENT,PRODUCT,EST,ESTIMATE,BUY_DATES,MARKET,SYSCODE,STATION,LINE,CABLE_NETWORK_CODE,PROGRAMMING,DAYPART,LEN,ROTATION,TIMES,COST_PER_SPOT,RATING"

                    For Each BroadcastCalendar In BroadcastCalendars

                        Header += "," & "SPOTS" & BroadcastCalendar.BRD_WEEK_START.ToString("yyMMdd")

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
                            Data = """" & .MEDIA & """" & ","
                            Data += """" & .CLIENT & """" & ","
                            Data += """" & .PRODUCT & """" & ","
                            Data += .EST & ","
                            Data += """" & .ESTIMATE & """" & ","
                            Data += """" & .BUY_DATES & """" & ","
                            Data += """" & .MARKET & """" & ","

                            If .SYSCODE.HasValue AndAlso NCCTVSyscodeList.Where(Function(SC) SC.ID = .SYSCODE.Value).Count = 1 Then

                                Data += """" & NCCTVSyscodeList.Where(Function(SC) SC.ID = .SYSCODE.Value).First.Syscode.ToString & """" & ","

                            Else

                                Data += """" & "" & """" & ","

                            End If

                            Data += """" & .STATION & """" & ","
                            Data += .LINE & ","
                            Data += .CABLE_NETWORK_CODE & ","
                            Data += """" & .PROGRAMMING & """" & ","
                            Data += """" & .DAYPART & """" & ","
                            Data += .LEN & ","
                            Data += """" & .ROTATION & """" & ","
                            Data += """" & .TIMES & """" & ","
                            Data += .COST_PER_SPOT & ","
                            Data += .RATING.GetValueOrDefault(0).ToString
                        End With

                        MediaBroadcastWorksheetMarketDetailDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                    Where Entity.OrderNumber = Buy.EST AndAlso
                                                                          Entity.OrderLineNumber = Buy.LINE AndAlso
                                                                          Entity.Date >= StartDate AndAlso
                                                                          Entity.Date <= EndDate).ToList

                        AppendSpotDateColumns(BroadcastCalendars, MediaBroadcastWorksheetMarketDetailDates, Data, Nothing)

                        StreamWriter.WriteLine(Data)

                    Next

                    StreamWriter.Close()

                    'start invoice file
                    BroadcastInvoiceFileName = ViewModel.OutputFolder & "Invoice_" & ViewModel.FilePrefix & ".csv"

                    Header = "MEDIA,CLIENT,PRODUCT,EST,ESTIMATE,MARKET,STATION,[DATE],TIME,LEN,InvoiceCost,InvoiceNumber,FILM,SpotsInvoice,PerCostSpot,APApprovalComment"

                    StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(BroadcastInvoiceFileName, False)

                    StreamWriter.WriteLine(Header)

                    For Each Invoice In InvoiceList

                        With Invoice
                            Data = """" & .MEDIA & """" & ","
                            Data += """" & .CLIENT & """" & ","
                            Data += """" & .PRODUCT & """" & ","
                            Data += .EST & ","
                            Data += """" & .ESTIMATE & """" & ","
                            Data += """" & .MARKET & """" & ","
                            Data += """" & .STATION & """" & ","
                            Data += """" & .DATE & """" & ","
                            Data += """" & .TIME.ToString.Substring(0, 5) & """" & ","
                            Data += .LEN & ","
                            Data += .InvoiceCost & ","
                            Data += """" & .InvoiceNumber & """" & ","
                            Data += """" & .FILM & """" & ","
                            Data += .SpotsInvoice.ToString & ","
                            Data += .PerCostSpot.ToString & ","
                            Data += """" & .APApprovalComment & """"
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

            ExportBuyAndInvoiceFilesToExcel = Exported

        End Function
        Public Sub SetBroadcastStartEndDates(Month As Integer, Year As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, Month)).FirstOrDefault
                ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, Month)).FirstOrDefault

            End Using

        End Sub
        Public Sub SetQuarterStartEndDates(Quarter As Integer, Year As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Select Case Quarter

                    Case 1

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 1)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 3)).FirstOrDefault
                        ViewModel.Quarter = "Q1"

                    Case 2

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 4)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 6)).FirstOrDefault
                        ViewModel.Quarter = "Q2"

                    Case 3

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 7)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 9)).FirstOrDefault
                        ViewModel.Quarter = "Q3"

                    Case 4

                        ViewModel.StartDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MIN(BRD_WEEK_START) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 10)).FirstOrDefault
                        ViewModel.EndDate = DbContext.Database.SqlQuery(Of Date)(String.Format("SELECT MAX(BRD_WEEK_END) FROM dbo.fn_BroadcastCal2('12/31/1996') WHERE BRD_YEAR = {0} AND BRD_MONTH = {1}", Year, 12)).FirstOrDefault
                        ViewModel.Quarter = "Q4"

                End Select

            End Using

        End Sub
        Public Sub SetBroadcastStartEndDates(StartDate As Date, EndDate As Date, ByRef ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ViewModel.StartDate = StartDate
                ViewModel.EndDate = EndDate

            End Using

        End Sub
        Private Sub CreateNodes(ByVal NodeDescription As String, ByVal Headers As Generic.List(Of String), ByVal Data As Generic.List(Of String), ByVal XmlTextWriter As System.Xml.XmlTextWriter)

            XmlTextWriter.WriteStartElement(NodeDescription)

            For i As Integer = 0 To Headers.Count - 1

                XmlTextWriter.WriteStartElement(Headers(i))
                XmlTextWriter.WriteString(Data(i))
                XmlTextWriter.WriteEndElement()

            Next

            XmlTextWriter.WriteEndElement()

        End Sub
        Public Function ExportBuyAndInvoiceFilesToXml(ViewModel As AdvantageFramework.ViewModels.Media.Exports.BroadcastBuyInvoiceExportViewModel,
                                                      ByRef ErrorMessage As String) As Boolean

            Dim Exported As Boolean = False
            Dim BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.BroadcastCalendar) = Nothing
            Dim BroadcastBuyFileName As String = ""
            Dim BroadcastInvoiceFileName As String = ""
            Dim Header As Generic.List(Of String) = Nothing
            Dim Data As Generic.List(Of String) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim BuyList As Generic.List(Of AdvantageFramework.DTO.Media.Buy) = Nothing
            Dim InvoiceList As Generic.List(Of AdvantageFramework.DTO.Media.Invoice) = Nothing
            Dim HostedSent As Boolean = False
            Dim XmlTextWriter As System.Xml.XmlTextWriter = Nothing
            Dim NCCTVSyscodeList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode) = Nothing

            Try

                If Session.IsNielsenSetup Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.Load(NielsenDbContext).ToList

                    End Using

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If ViewModel.SelectedClientCodes IsNot Nothing AndAlso ViewModel.SelectedClientCodes.Count > 0 Then

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}','{2}'", ViewModel.StartDate, ViewModel.EndDate, String.Join(",", ViewModel.SelectedClientCodes.ToArray))).ToList

                    Else

                        BuyList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Buy)(String.Format("[advsp_broadcast_audit_export_buy] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList
                        InvoiceList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Invoice)(String.Format("[advsp_broadcast_audit_export_invoice] '{0}','{1}',null", ViewModel.StartDate, ViewModel.EndDate)).ToList

                    End If

                    BroadcastCalendars = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.BroadcastCalendar)(String.Format("SELECT * FROM dbo.fn_BroadcastCal2('01/01/1996') WHERE BRD_YEAR = {0}", ViewModel.Year)).ToList
                                          Where Entity.BRD_WEEK_START >= ViewModel.StartDate AndAlso
                                                Entity.BRD_WEEK_END <= ViewModel.EndDate
                                          Select Entity).ToList

                    Header = New Generic.List(Of String)
                    Header.Add("MEDIA")
                    Header.Add("CLIENT")
                    Header.Add("PRODUCT")
                    Header.Add("EST")
                    Header.Add("ESTIMATE")
                    Header.Add("BUY_DATES")
                    Header.Add("MARKET")
                    Header.Add("SYSCODE")
                    Header.Add("STATION")
                    Header.Add("LINE")
                    Header.Add("CABLE_NETWORK_CODE")
                    Header.Add("PROGRAMMING")
                    Header.Add("DAYPART")
                    Header.Add("LEN")
                    Header.Add("ROTATION")
                    Header.Add("TIMES")
                    Header.Add("COST_PER_SPOT")
                    Header.Add("RATING")

                    For Each BroadcastCalendar In BroadcastCalendars

                        Header.Add("SPOTS" & BroadcastCalendar.BRD_WEEK_START.ToString("yyMMdd"))

                    Next

                    StartDate = BroadcastCalendars.Min(Function(BC) BC.BRD_WEEK_START)
                    EndDate = BroadcastCalendars.Max(Function(BC) BC.BRD_WEEK_END)

                    If ViewModel.OutputFolder.EndsWith("\") = False Then

                        ViewModel.OutputFolder = ViewModel.OutputFolder & "\"

                    End If

                    BroadcastBuyFileName = ViewModel.OutputFolder & "Buy_" & ViewModel.FilePrefix & ".xml"

                    XmlTextWriter = New System.Xml.XmlTextWriter(BroadcastBuyFileName, System.Text.Encoding.UTF8)

                    XmlTextWriter.WriteStartDocument(True)
                    XmlTextWriter.Formatting = System.Xml.Formatting.Indented
                    XmlTextWriter.Indentation = 2
                    XmlTextWriter.WriteStartElement("Buys")

                    For Each Buy In BuyList

                        Data = New Generic.List(Of String)
                        Data.Add(Buy.MEDIA)
                        Data.Add(Buy.CLIENT)
                        Data.Add(Buy.PRODUCT)
                        Data.Add(Buy.EST)
                        Data.Add(Buy.ESTIMATE)
                        Data.Add(Buy.BUY_DATES)
                        Data.Add(Buy.MARKET)

                        If Buy.SYSCODE.HasValue AndAlso NCCTVSyscodeList.Where(Function(SC) SC.ID = Buy.SYSCODE.Value).Count = 1 Then

                            Data.Add(NCCTVSyscodeList.Where(Function(SC) SC.ID = Buy.SYSCODE.Value).First.Syscode.ToString)

                        Else

                            Data.Add("")

                        End If

                        Data.Add(Buy.STATION)
                        Data.Add(Buy.LINE)
                        Data.Add(Buy.CABLE_NETWORK_CODE)
                        Data.Add(Buy.PROGRAMMING)
                        Data.Add(Buy.DAYPART)
                        Data.Add(Buy.LEN)
                        Data.Add(Buy.ROTATION)
                        Data.Add(Buy.TIMES)
                        Data.Add(Buy.COST_PER_SPOT)
                        Data.Add(Buy.RATING.GetValueOrDefault(0))

                        MediaBroadcastWorksheetMarketDetailDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                    Where Entity.OrderNumber = Buy.EST AndAlso
                                                                          Entity.OrderLineNumber = Buy.LINE AndAlso
                                                                          Entity.Date >= StartDate AndAlso
                                                                          Entity.Date <= EndDate).ToList

                        AppendSpotDateColumns(BroadcastCalendars, MediaBroadcastWorksheetMarketDetailDates, Nothing, Data)

                        CreateNodes("Buy", Header, Data, XmlTextWriter)

                    Next

                    XmlTextWriter.WriteEndElement()
                    XmlTextWriter.WriteEndDocument()
                    XmlTextWriter.Close()

                    'start invoice file
                    BroadcastInvoiceFileName = ViewModel.OutputFolder & "Invoice_" & ViewModel.FilePrefix & ".xml"

                    Header = New Generic.List(Of String)
                    Header.Add("MEDIA")
                    Header.Add("CLIENT")
                    Header.Add("PRODUCT")
                    Header.Add("EST")
                    Header.Add("ESTIMATE")
                    Header.Add("MARKET")
                    Header.Add("STATION")
                    Header.Add("DATE")
                    Header.Add("TIME")
                    Header.Add("LEN")
                    Header.Add("InvoiceCost")
                    Header.Add("InvoiceNumber")
                    Header.Add("FILM")
                    Header.Add("SpotsInvoice")
                    Header.Add("PerCostSpot")
                    Header.Add("APApprovalComment")

                    XmlTextWriter = New System.Xml.XmlTextWriter(BroadcastInvoiceFileName, System.Text.Encoding.UTF8)

                    XmlTextWriter.WriteStartDocument(True)
                    XmlTextWriter.Formatting = System.Xml.Formatting.Indented
                    XmlTextWriter.Indentation = 2
                    XmlTextWriter.WriteStartElement("Invoices")

                    For Each Invoice In InvoiceList

                        Data = New Generic.List(Of String)
                        Data.Add(Invoice.MEDIA)
                        Data.Add(Invoice.CLIENT)
                        Data.Add(Invoice.PRODUCT)
                        Data.Add(Invoice.EST)
                        Data.Add(Invoice.ESTIMATE)
                        Data.Add(Invoice.MARKET)
                        Data.Add(Invoice.STATION)
                        Data.Add(Invoice.DATE)
                        Data.Add(Invoice.TIME.ToString.Substring(0, 5))
                        Data.Add(Invoice.LEN)
                        Data.Add(Invoice.InvoiceCost)
                        Data.Add(Invoice.InvoiceNumber)
                        Data.Add(Invoice.FILM)
                        Data.Add(Invoice.SpotsInvoice)
                        Data.Add(Invoice.PerCostSpot)
                        Data.Add(Invoice.APApprovalComment)

                        CreateNodes("Invoice", Header, Data, XmlTextWriter)

                    Next

                    XmlTextWriter.WriteEndElement()
                    XmlTextWriter.WriteEndDocument()
                    XmlTextWriter.Close()
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

            ExportBuyAndInvoiceFilesToXml = Exported

        End Function

#End Region

#End Region

    End Class

End Namespace
