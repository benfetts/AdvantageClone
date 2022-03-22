<HideModuleName()>
Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _PrinterSettings As System.Drawing.Printing.PrinterSettings = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function ProcessGenerateOrders(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder),
                                          DocumentTypeIDs As Generic.List(Of Long), ByVal UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                          SubjectIn As String, BodyIn As String, CCSender As Boolean, UploadDocumentManager As Boolean,
                                          ByRef AtLeastOneEmailFailed As Boolean) As Boolean

        'objects
        Dim Processed As Boolean = True
        Dim GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder = Nothing
        Dim GenerateOrdersToProcess As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Dim SuccessfulGenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Dim ReportGeneratedOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Dim OrderNumbers As Generic.List(Of Integer) = Nothing
        Dim LineNumbers As Generic.List(Of Integer) = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim OrderStatus As Boolean = False
        Dim OrderStatusMessage As String = ""
        Dim HtmlEmailBody As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing
        Dim AllowPrivateAccess As Boolean = False
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim DocumentFileName As String = ""
        Dim WebvantageURL As String = ""
        Dim MediaManagerGeneratedReportID As Integer = 0
        Dim PrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
        Dim HasPrintedFirstReport As Boolean = False
        Dim ContinueGenerateOrders As Boolean = False
        Dim EmployeeEmailAddress As String = ""
        Dim VCCVendorCodes As Generic.List(Of String) = Nothing
        Dim EmailSubjectPrefix As String = ""
        Dim JobComponents As IEnumerable(Of String) = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing
        Dim IsOrderFromWorksheet As Boolean = False
        Dim BroadcastOrdersForVendorRep As AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep = Nothing
        Dim MediaExcludeOrderPDFWithEmail As Boolean = False
        Dim AlertID As Nullable(Of Integer) = Nothing
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim ErrorMessage As String = Nothing
        Dim EmailBody As System.Text.StringBuilder = Nothing
        Dim AlertSubject As String = Nothing
        Dim EmailSubject As String = Nothing
        Dim VendorRepCode As String = Nothing
        Dim AlertRecipientEmployeeCodes As Generic.List(Of String) = Nothing
        Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
        Dim StartDate As Nullable(Of Date) = Nothing
        Dim EndDate As Nullable(Of Date) = Nothing
        Dim IsDaily As Boolean = False
        Dim MediaTypes As IEnumerable(Of String) = Nothing
        Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Dim MediaBroadcastWorksheetMarketID As Integer = 0

        Try

            GenerateOrdersToProcess = GenerateOrders.Where(Function(Entity) Entity.Status.GetValueOrDefault(False) = True AndAlso Entity.GetGenerateOrderVendorReps.Any(Function(GOVR) GOVR.Process = True)).ToList

        Catch ex As Exception
            GenerateOrdersToProcess = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)
        End Try

        If GenerateOrdersToProcess IsNot Nothing AndAlso GenerateOrdersToProcess.Count > 0 Then

            MediaTypes = (From GO In GenerateOrdersToProcess
                          Select GO.MediaFrom.Substring(0, 1)).Distinct.ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each MediaType In MediaTypes

                    MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, MediaType)

                    If MediaOrderPrintSetting Is Nothing Then

                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaType)

                        MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting
                        MediaOrderPrintSetting.UserCode = Session.UserCode.ToUpper
                        MediaOrderPrintSetting.MediaType = MediaType

                        OrderPrintSetting.Save(MediaOrderPrintSetting)

                        AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, MediaOrderPrintSetting, Nothing)

                    End If

                Next

            End Using

            Try

                Try

                    AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                Catch ex As Exception
                    AllowPrivateAccess = False
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        VCCVendorCodes = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Where(Function(Entity) Entity.VCCStatus = 1 AndAlso Entity.SendVCCWithMediaOrder).Select(Function(Entity) Entity.Code).ToList

                    Catch ex As Exception
                        VCCVendorCodes = GenerateOrdersToProcess.Select(Function(Entity) Entity.VendorCode).ToList
                    End Try

                    Try

                        EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

                    Catch ex As Exception
                        EmployeeEmailAddress = ""
                    End Try

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        If GenerateOrdersToProcess.Any(Function(Entity) VCCVendorCodes.Contains(Entity.VendorCode) = True AndAlso Entity.Quote = False AndAlso Entity.Cancelled = False) Then

                            If AdvantageFramework.VCC.LoadVCCProvider(DataContext) <> 0 Then

                                If AdvantageFramework.VCC.IsVCCServiceSetup(Session) = False Then

                                    If AdvantageFramework.Navigation.ShowMessageBox("Failed trying to connect to VCC service.  Please check all your VCC settings. " & System.Environment.NewLine & System.Environment.NewLine & " Do you want to continue generating orders?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                        ContinueGenerateOrders = True

                                    End If

                                Else

                                    ContinueGenerateOrders = True

                                    AdvantageFramework.MediaManager.CreateUpdateVCCCardsForOrders(Session, GenerateOrdersToProcess)

                                End If

                            Else

                                If AdvantageFramework.Navigation.ShowMessageBox("Your VCC settings are not configured properly.  Please check all your VCC settings. " & System.Environment.NewLine & System.Environment.NewLine & " Do you want to continue generating orders?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    ContinueGenerateOrders = True

                                End If

                            End If

                        Else

                            ContinueGenerateOrders = True

                        End If

                        MediaExcludeOrderPDFWithEmail = AdvantageFramework.Agency.LoadMediaExcludeOrderPDFWithEmail(DataContext)

                        If ContinueGenerateOrders Then

                            SuccessfulGenerateOrders = GenerateOrdersToProcess.Where(Function(Entity) Entity.Status.GetValueOrDefault(False) = True AndAlso Entity.GetGenerateOrderVendorReps.Any(Function(GOVR) GOVR.Process = True)).ToList

                            Try

                                OrderNumbers = SuccessfulGenerateOrders.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email).Select(Function(Entity) Entity.OrderNumber).Distinct.ToList

                                For Each OrderNumber In OrderNumbers

                                    OrderStatus = True
                                    OrderStatusMessage = ""
                                    ReportGeneratedOrders = Nothing
                                    MediaOrderPrintSetting = Nothing
                                    OrderPrintSetting = Nothing
                                    StartDate = Nothing
                                    EndDate = Nothing
                                    IsDaily = False

                                    IsOrderFromWorksheet = (From Entity In AdvantageFramework.Database.Procedures.BroadcastImportCrossReference.Load(DbContext)
                                                            Where Entity.OrderNumber = OrderNumber AndAlso
                                                              Entity.ImportedFrom = "AW").Any

                                    Try

                                        GenerateOrder = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).First
                                        ReportGeneratedOrders = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).ToList
                                        LineNumbers = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).Select(Function(Entity) Entity.LineNumber).Distinct.ToList
                                        JobComponents = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.JobNumber.HasValue AndAlso Entity.JobComponentNumber.HasValue).Select(Function(Entity) Entity.JobNumber.Value & "|" & Entity.JobComponentNumber.Value).Distinct.ToArray

                                        MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, GenerateOrder.MediaFrom.Substring(0, 1).ToUpper)

                                        StartDate = GenerateOrder.StartDate
                                        EndDate = GenerateOrder.EndDate

                                        If StartDate.HasValue AndAlso EndDate.HasValue AndAlso (StartDate.Value = EndDate.Value) Then

                                            IsDaily = True

                                        End If

                                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaOrderPrintSetting, IsDaily)

                                        Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, OrderNumber, LineNumbers, GenerateOrder.MediaFrom, OrderPrintSetting.ReportFormat)

                                        If Report IsNot Nothing Then

                                            MediaManagerGeneratedReportID = AdvantageFramework.MediaManager.CreateUpdateGeneratedOrderReport(Session, OrderNumber, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                                            Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                            If Not MediaExcludeOrderPDFWithEmail Then

                                                MemoryStream = New System.IO.MemoryStream()

                                                Report.ExportToPdf(MemoryStream)

                                                If GenerateOrder.Quote Then

                                                    Attachments.Add(New Email.Classes.Attachment("Quote Request " & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".pdf", MemoryStream.ToArray))

                                                Else

                                                    Attachments.Add(New Email.Classes.Attachment("Order Report " & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".pdf", MemoryStream.ToArray))

                                                End If

                                                If IsOrderFromWorksheet AndAlso GenerateOrder.MediaFrom = "TV" Then

                                                    Vendor = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail.Vendor")
                                                              Where Entity.OrderNumber = OrderNumber
                                                              Select Entity).FirstOrDefault.MediaBroadcastWorksheetMarketDetail.Vendor

                                                    If Vendor IsNot Nothing AndAlso Vendor.IsCableSystem = True AndAlso Vendor.NCCTVSyscodeID.HasValue Then

                                                        Try

                                                            Attachments.Add(New Email.Classes.Attachment("Order_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".SCX", AdvantageFramework.Media.BuildXMLFile(Session, DbContext, DataContext, GenerateOrder.OrderNumber, GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList, Vendor.Code).ToArray))

                                                        Catch ex As Exception
                                                            AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                                                            If ex.InnerException IsNot Nothing Then
                                                                AdvantageFramework.Navigation.ShowMessageBox(ex.InnerException.Message)
                                                            End If
                                                        End Try

                                                    Else

                                                        Try

                                                            Attachments.Add(New Email.Classes.Attachment("Order_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".XML", AdvantageFramework.Media.BuildBroadcastXMLFile(Session, DbContext, DataContext, GenerateOrder.OrderNumber, GenerateOrder.MediaFrom, GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList).ToArray))

                                                        Catch ex As Exception
                                                            AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                                                            If ex.InnerException IsNot Nothing Then
                                                                AdvantageFramework.Navigation.ShowMessageBox(ex.InnerException.Message)
                                                            End If
                                                        End Try

                                                    End If

                                                ElseIf IsOrderFromWorksheet AndAlso GenerateOrder.MediaFrom = "Radio" Then

                                                    Try

                                                        Attachments.Add(New Email.Classes.Attachment("Order_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".XML", AdvantageFramework.Media.BuildRadioBroadcastXMLFile(Session, DbContext, DataContext, GenerateOrder.OrderNumber, GenerateOrder.MediaFrom, GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList).ToArray))

                                                    Catch ex As Exception
                                                        AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                                                        If ex.InnerException IsNot Nothing Then
                                                            AdvantageFramework.Navigation.ShowMessageBox(ex.InnerException.Message)
                                                        End If
                                                    End Try

                                                    Try

                                                        MediaBroadcastWorksheetMarketID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                                                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                                                            "WHERE ORDER_NBR = {0}", GenerateOrder.OrderNumber)).FirstOrDefault

                                                        Attachments.Add(New Email.Classes.Attachment("Proposal_" & GenerateOrder.ClientName & "_" & GenerateOrder.Vendor & "_" & GenerateOrder.OrderNumber & ".XML", AdvantageFramework.Media.BuildXMLProposalFile(Session, DbContext, MediaBroadcastWorksheetMarketID, False, GenerateOrder.VendorCode, Nothing).ToArray))

                                                    Catch ex As Exception
                                                        AdvantageFramework.Navigation.ShowMessageBox(ex.Message)
                                                        If ex.InnerException IsNot Nothing Then
                                                            AdvantageFramework.Navigation.ShowMessageBox(ex.InnerException.Message)
                                                        End If
                                                    End Try

                                                End If

                                            End If

                                            'JOB DOCUMENTS
                                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                            If GenerateOrder.JobNumber.HasValue Then

                                                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Job) With {.JobNumber = GenerateOrder.JobNumber.Value})

                                            End If

                                            For Each Document In AdvantageFramework.DocumentManager.LoadJobDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                    If AdvantageFramework.FileSystem.LoadRepositoryFilePath(Agency, Document.FileSystemFileName, DocumentFileName) Then

                                                        Attachments.Add(New Email.Classes.Attachment(Document.FileName, DocumentFileName))

                                                    End If

                                                End If

                                            Next
                                            'JOB COMP DOCUMENTS
                                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                            For Each JobComponent In JobComponents

                                                With JobComponent.Split("|")

                                                    JobNumber = CInt(.First)

                                                    JobComponentNumber = CShort(.Last)

                                                End With

                                                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent) With {.JobNumber = JobNumber,
                                                                                                                                                                                                              .JobComponentNumber = JobComponentNumber})

                                            Next

                                            For Each Document In AdvantageFramework.DocumentManager.LoadJobComponentDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                    If AdvantageFramework.FileSystem.LoadRepositoryFilePath(Agency, Document.FileSystemFileName, DocumentFileName) Then

                                                        Attachments.Add(New Email.Classes.Attachment(Document.FileName, DocumentFileName))

                                                    End If

                                                End If

                                            Next
                                            'CAMPAIGN DOCUMENTS
                                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                            If GenerateOrder.GetMediaManagerReviewDetail.CampaignID.HasValue Then

                                                DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Campaign) With {.CampaignID = GenerateOrder.GetMediaManagerReviewDetail.CampaignID.Value})

                                            End If

                                            For Each Document In AdvantageFramework.DocumentManager.LoadCampaignDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                    If AdvantageFramework.FileSystem.LoadRepositoryFilePath(Agency, Document.FileSystemFileName, DocumentFileName) Then

                                                        Attachments.Add(New Email.Classes.Attachment(Document.FileName, DocumentFileName))

                                                    End If

                                                End If

                                            Next
                                            'MEDIA ORDER DOCUMENTS
                                            DocumentLevelSettings = New Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting)

                                            DocumentLevelSettings.Add(New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder) With {.OrderNumber = GenerateOrder.GetMediaManagerReviewDetail.OrderNumber,
                                                                                                                                                                                                        .MediaType = GenerateOrder.GetMediaManagerReviewDetail.MediaFrom.ToUpper.Substring(0, 1)})

                                            For Each Document In AdvantageFramework.DocumentManager.LoadMediaOrderDocuments(Session, DocumentLevelSettings, AllowPrivateAccess)

                                                If DocumentTypeIDs.Contains(Document.DocumentTypeID.GetValueOrDefault(0)) Then

                                                    If AdvantageFramework.FileSystem.LoadRepositoryFilePath(Agency, Document.FileSystemFileName, DocumentFileName) Then

                                                        Attachments.Add(New Email.Classes.Attachment(Document.FileName, DocumentFileName))

                                                    End If

                                                End If

                                            Next

                                            If GenerateOrder.Quote Then

                                                EmailSubjectPrefix = "Quote Request "

                                            ElseIf ReportGeneratedOrders.All(Function(Entity) Entity.Cancelled = True) Then

                                                EmailSubjectPrefix = "Media Order Cancellation "

                                            ElseIf ReportGeneratedOrders.Any(Function(Entity) Entity.Cancelled = True) Then

                                                EmailSubjectPrefix = "Media Order Revision "

                                            Else

                                                EmailSubjectPrefix = "Media Order "

                                            End If

                                            VendorRepCode = GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).FirstOrDefault.VendorRepCode

                                            If IsOrderFromWorksheet AndAlso Not String.IsNullOrWhiteSpace(VendorRepCode) Then

                                                Try

                                                    BroadcastOrdersForVendorRep = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)(String.Format("exec advsp_broadcast_orders_for_vendor_rep_by_order_number '{0}', '{1}', 0, {2}", GenerateOrder.VendorCode, VendorRepCode, GenerateOrder.OrderNumber)).SingleOrDefault

                                                Catch ex As Exception
                                                    BroadcastOrdersForVendorRep = Nothing
                                                End Try

                                                If BroadcastOrdersForVendorRep IsNot Nothing Then

                                                    AlertSubject = GenerateOrder.MediaFrom & " order #" & OrderNumber.ToString & " for " & BroadcastOrdersForVendorRep.MarketDescription & "-" & BroadcastOrdersForVendorRep.Station & " " & BroadcastOrdersForVendorRep.Period

                                                    If String.IsNullOrWhiteSpace(SubjectIn) Then

                                                        EmailSubject = AlertSubject

                                                    Else

                                                        EmailSubject = SubjectIn

                                                    End If

                                                    HtmlEmailBody = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                                                    EmailBody = New System.Text.StringBuilder()

                                                    If Not String.IsNullOrWhiteSpace(BodyIn) Then

                                                        HtmlEmailBody.AddCustomRow(BodyIn)
                                                        HtmlEmailBody.AddBlankRow()

                                                        EmailBody.Append(BodyIn)
                                                        EmailBody.AppendLine()

                                                    End If

                                                    HtmlEmailBody.AddCustomRow("This email is notification of order # " & BroadcastOrdersForVendorRep.OrderNumber.ToString)
                                                    HtmlEmailBody.AddCustomRow("")
                                                    HtmlEmailBody.AddBoldKeyValueRow("Agency Worksheet Name", BroadcastOrdersForVendorRep.WorksheetName)
                                                    HtmlEmailBody.AddBoldKeyValueRow("Market", BroadcastOrdersForVendorRep.MarketDescription)
                                                    HtmlEmailBody.AddBoldKeyValueRow("Station", BroadcastOrdersForVendorRep.Station)
                                                    HtmlEmailBody.AddBoldKeyValueRow("Period", BroadcastOrdersForVendorRep.Period)
                                                    HtmlEmailBody.AddCustomRow("")
                                                    HtmlEmailBody.AddBoldKeyValueRow("Agency", BroadcastOrdersForVendorRep.AgencyName)
                                                    HtmlEmailBody.AddBoldKeyValueRow("Buyer", BroadcastOrdersForVendorRep.BuyerName)
                                                    HtmlEmailBody.AddBoldKeyValueRow("", BroadcastOrdersForVendorRep.BuyerEmail, False)
                                                    HtmlEmailBody.AddBoldKeyValueRow("", BroadcastOrdersForVendorRep.BuyerWorkPhone, False)
                                                    HtmlEmailBody.AddCustomRow("")
                                                    HtmlEmailBody.AddBoldKeyValueRow("Client", BroadcastOrdersForVendorRep.ClientName)
                                                    HtmlEmailBody.AddBoldKeyValueRow("Product", BroadcastOrdersForVendorRep.ProductDescription)

                                                    EmailBody.AppendLine("This email is notification of order # " & BroadcastOrdersForVendorRep.OrderNumber.ToString)
                                                    EmailBody.AppendLine("Agency Worksheet Name: " & BroadcastOrdersForVendorRep.WorksheetName)
                                                    EmailBody.AppendLine("Market: " & BroadcastOrdersForVendorRep.MarketDescription)
                                                    EmailBody.AppendLine("Station: " & BroadcastOrdersForVendorRep.Station)
                                                    EmailBody.AppendLine("Period: " & BroadcastOrdersForVendorRep.Period)
                                                    EmailBody.AppendLine("Agency: " & BroadcastOrdersForVendorRep.AgencyName)
                                                    EmailBody.AppendLine("Buyer: " & BroadcastOrdersForVendorRep.BuyerName)
                                                    EmailBody.AppendLine(BroadcastOrdersForVendorRep.BuyerEmail)
                                                    EmailBody.AppendLine(BroadcastOrdersForVendorRep.BuyerWorkPhone)
                                                    EmailBody.AppendLine("Client: " & BroadcastOrdersForVendorRep.ClientName)
                                                    EmailBody.AppendLine("Product: " & BroadcastOrdersForVendorRep.ProductDescription)

                                                End If

                                            End If

                                            If IsOrderFromWorksheet Then

                                                AlertID = GetAlertID(DbContext, OrderNumber, GenerateOrdersToProcess.Where(Function(O) O.OrderNumber = OrderNumber).FirstOrDefault.MediaFrom.Substring(0, 1))

                                                If AlertID.HasValue Then

                                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID.Value)

                                                    If Alert IsNot Nothing Then

                                                        Alert.Body = EmailBody.ToString
                                                        Alert.EmailBody = Replace(HtmlEmailBody.ToString, vbCrLf, "<br/>")
                                                        Alert.LastUpdated = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                                        Alert.Subject = AlertSubject

                                                        AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                                                        InsertAlertCommentsForOrder(DbContext, GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True AndAlso GOVR.OrderNumber = OrderNumber).ToList, GenerateOrder.VendorCode, Alert.ID, BodyIn)

                                                        UpdateAlertRecipients(Session, Alert, GenerateOrdersToProcess.Where(Function(O) O.OrderNumber = OrderNumber).FirstOrDefault.AlertRecipientEmployeeCodes)

                                                        AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[Alert Updated]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

                                                    End If

                                                Else

                                                    AlertID = 0

                                                    AlertRecipientEmployeeCodes = GenerateOrdersToProcess.Where(Function(O) O.OrderNumber = OrderNumber).FirstOrDefault.AlertRecipientEmployeeCodes

                                                    If Not CreateMediaOrderAlert(Session, DbContext, OrderNumber, GenerateOrdersToProcess.Where(Function(O) O.OrderNumber = OrderNumber).FirstOrDefault.MediaFrom.Substring(0, 1),
                                                        AlertSubject, EmailBody.ToString, HtmlEmailBody.ToString,
                                                        GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True AndAlso GOVR.OrderNumber = OrderNumber).ToList,
                                                        AlertRecipientEmployeeCodes, ErrorMessage, AlertID, BodyIn) Then

                                                        Throw New Exception(ErrorMessage)

                                                    End If

                                                End If

                                            End If

                                            For Each GenerateOrderVendorRep In GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList

                                                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                                                If Not IsOrderFromWorksheet Then

                                                    HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "Media/MediaManager/OrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaManagerGeneratedReportID=" & MediaManagerGeneratedReportID & "&Email=" & GenerateOrderVendorRep.VendorRepEmail) & "%7C"" > Click Here</a> to View the Order")

                                                Else

                                                    HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "Media/MakegoodDelivery/MakegoodOutstandingForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&VendorCode=" & GenerateOrder.VendorCode & "&VendorRepCode=" & GenerateOrderVendorRep.VendorRepCode) & "%7C"" > Click Here</a> to review open orders and take various actions.")

                                                End If

                                                HtmlEmail.AddBlankRow()
                                                HtmlEmail.AddBlankRow()

                                                HtmlEmail.AddHeaderRow("Message")

                                                'If Not String.IsNullOrWhiteSpace(BodyIn) Then

                                                '    HtmlEmail.AddCustomRow(BodyIn.Replace(vbCrLf, "<br />"))

                                                'End If

                                                If HtmlEmailBody IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                                                    HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                                                ElseIf Not String.IsNullOrWhiteSpace(BodyIn) Then

                                                    HtmlEmail.AddCustomRow(BodyIn.Replace(vbCrLf, "<br />"))

                                                End If

                                                If AlertID <> 0 Then

                                                    HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                                                    AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                                                End If

                                                HtmlEmail.Finish()

                                                If IsOrderFromWorksheet Then

                                                    If AdvantageFramework.Email.Send(DbContext, GenerateOrderVendorRep.VendorRepEmail, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus) = False Then

                                                        AtLeastOneEmailFailed = True

                                                    Else

                                                        AdvantageFramework.MediaManager.CreateGeneratedOrderReportSentInfo(Session, MediaManagerGeneratedReportID, GenerateOrderVendorRep.VendorCode, GenerateOrderVendorRep.VendorRepCode, GenerateOrderVendorRep.VendorRepEmail)

                                                    End If

                                                Else

                                                    If AdvantageFramework.Email.Send(DbContext, GenerateOrderVendorRep.VendorRepEmail, "", "",
                                                                                     If(String.IsNullOrWhiteSpace(SubjectIn) = True, EmailSubjectPrefix & GenerateOrder.OrderNumber & " from " & Agency.Name & " – Important Message – Do Not Delete – Open Immediately", SubjectIn),
                                                                                     HtmlEmail.ToString, 3, Attachments, SendingEmailStatus) = False Then

                                                        OrderStatus = False
                                                        AtLeastOneEmailFailed = True

                                                    Else

                                                        AdvantageFramework.MediaManager.CreateGeneratedOrderReportSentInfo(Session, MediaManagerGeneratedReportID, GenerateOrderVendorRep.VendorCode, GenerateOrderVendorRep.VendorRepCode, GenerateOrderVendorRep.VendorRepEmail)

                                                    End If

                                                End If

                                            Next

                                            If CCSender AndAlso String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                                                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                                                If IsOrderFromWorksheet Then

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddBlankRow()

                                                    HtmlEmail.AddHeaderRow("Message")

                                                    If Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                                                        HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                                                    End If

                                                    HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                                                    AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                                                    HtmlEmail.Finish()

                                                    AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus)

                                                Else

                                                    HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "MediaManager/OrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaManagerGeneratedReportID=" & MediaManagerGeneratedReportID & "&Email=" & EmployeeEmailAddress) & "%7C"" > Click Here</a> to View the Order")

                                                    HtmlEmail.AddHeaderRow("Order Instructions Below")

                                                    If Not IsOrderFromWorksheet Then

                                                        HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "MediaManager/OrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaManagerGeneratedReportID=" & MediaManagerGeneratedReportID & "&Email=" & EmployeeEmailAddress) & "%7C"" > Click Here</a> to View the Order")

                                                    End If

                                                    HtmlEmail.AddHeaderRow("Message")

                                                    If Not String.IsNullOrWhiteSpace(BodyIn) Then

                                                        HtmlEmail.AddCustomRow(BodyIn.Replace(vbCrLf, "<br />"))

                                                    End If

                                                    HtmlEmail.Finish()

                                                    AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "",
                                                                                  If(String.IsNullOrWhiteSpace(SubjectIn) = True, EmailSubjectPrefix & GenerateOrder.OrderNumber & " from " & Agency.Name & " – Important Message – Do Not Delete – Open Immediately", SubjectIn),
                                                                                  HtmlEmail.ToString, 3, Attachments, SendingEmailStatus)

                                                End If

                                            End If

                                            AdvantageFramework.MediaManager.SetOrderStatusGenerated(Session, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                                            If UploadDocumentManager Then

                                                SendToDocumentManager(DbContext, Report, Agency, GenerateOrder.VendorCode, OrderNumber, GenerateOrder.MediaFrom, EmailSubjectPrefix)

                                            End If

                                        End If

                                    Catch ex As Exception
                                        OrderStatus = False
                                        OrderStatusMessage = "Failed trying to create order and/or email."
                                        AtLeastOneEmailFailed = True
                                    End Try

                                    For Each GenerateOrder In SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).ToList

                                        GenerateOrder.Status = OrderStatus
                                        GenerateOrder.OrderMessage = OrderStatusMessage

                                    Next

                                Next

                            Catch ex As Exception

                            End Try

                            Try

                                OrderNumbers = SuccessfulGenerateOrders.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print).Select(Function(Entity) Entity.OrderNumber).Distinct.ToList

                                For Each OrderNumber In OrderNumbers

                                    OrderStatus = True
                                    OrderStatusMessage = ""
                                    ReportGeneratedOrders = Nothing
                                    MediaOrderPrintSetting = Nothing
                                    OrderPrintSetting = Nothing
                                    StartDate = Nothing
                                    EndDate = Nothing
                                    IsDaily = False

                                    Try

                                        GenerateOrder = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).First
                                        ReportGeneratedOrders = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).ToList
                                        LineNumbers = SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).Select(Function(Entity) Entity.LineNumber).Distinct.ToList

                                        MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, GenerateOrder.MediaFrom.Substring(0, 1).ToUpper)

                                        StartDate = GenerateOrder.StartDate
                                        EndDate = GenerateOrder.EndDate

                                        If StartDate.HasValue AndAlso EndDate.HasValue AndAlso (StartDate.Value = EndDate.Value) Then

                                            IsDaily = True

                                        End If

                                        OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaOrderPrintSetting, IsDaily)

                                        Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, OrderNumber, LineNumbers, GenerateOrder.MediaFrom, OrderPrintSetting.ReportFormat)

                                        If Report IsNot Nothing Then

                                            MediaManagerGeneratedReportID = AdvantageFramework.MediaManager.CreateUpdateGeneratedOrderReport(Session, OrderNumber, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                                            If HasPrintedFirstReport = False Then

                                                PrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                                AddHandler PrintTool.PrintingSystem.StartPrint, AddressOf PrintingSystem_StartPrint

                                                HasPrintedFirstReport = PrintTool.PrintDialog(UserLookAndFeel).GetValueOrDefault(False)

                                            Else

                                                PrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                                AddHandler PrintTool.PrintingSystem.StartPrint, AddressOf PrintTool_StartPrint

                                                PrintTool.Print()

                                            End If

                                            If HasPrintedFirstReport Then

                                                For Each GenerateOrderVendorRep In GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList

                                                    AdvantageFramework.MediaManager.CreateGeneratedOrderReportSentInfo(Session, MediaManagerGeneratedReportID, GenerateOrderVendorRep.VendorCode, GenerateOrderVendorRep.VendorRepCode, GenerateOrderVendorRep.VendorRepEmail)

                                                Next

                                                AdvantageFramework.MediaManager.SetOrderStatusGenerated(Session, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                                                If UploadDocumentManager Then

                                                    SendToDocumentManager(DbContext, Report, Agency, GenerateOrder.VendorCode, OrderNumber, GenerateOrder.MediaFrom, EmailSubjectPrefix)

                                                End If

                                                OrderStatus = True

                                            Else

                                                Exit For

                                            End If

                                        End If

                                    Catch ex As Exception
                                        OrderStatus = False
                                        OrderStatusMessage = "Failed trying to create order and/or print."
                                    End Try

                                    For Each GenerateOrder In SuccessfulGenerateOrders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).ToList

                                        GenerateOrder.Status = OrderStatus
                                        GenerateOrder.OrderMessage = OrderStatusMessage

                                    Next

                                Next

                                If HasPrintedFirstReport = False Then

                                    For Each GenerateOrder In SuccessfulGenerateOrders.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print).ToList

                                        GenerateOrder.Status = False
                                        GenerateOrder.OrderMessage = "Printing was cancelled."

                                    Next

                                End If

                            Catch ex As Exception

                            End Try

                            Processed = True

                        Else

                            For Each GenerateOrder In GenerateOrdersToProcess.Where(Function(Entity) Entity.Status.GetValueOrDefault(False) = True).ToList

                                GenerateOrder.Status = Nothing
                                GenerateOrder.OrderMessage = "User cancellation of order generation."

                            Next

                            Processed = False

                        End If

                    End Using

                End Using

            Catch ex As Exception
                Processed = False
            End Try

        End If

        ProcessGenerateOrders = Processed

    End Function
    Private Sub SendToDocumentManager(DbContext As AdvantageFramework.Database.DbContext, Report As DevExpress.XtraReports.UI.XtraReport,
                                      Agency As AdvantageFramework.Database.Entities.Agency, VendorCode As String, OrderNumber As Integer,
                                      MediaFrom As String, Description As String)

        'objects
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim FileName As String = String.Empty
        Dim FileSystemFile As String = String.Empty
        Dim FileSystemFileName As String = String.Empty
        Dim FileSize As Integer = Integer.MinValue
        Dim MimeType As String = String.Empty
        Dim FinalLevelDescription As String = String.Empty
        Dim FinalLevel As String = String.Empty
        Dim Keywords As String = String.Empty
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim IsValid As Boolean = True
        Dim ErrorMessage As String = String.Empty
        Dim MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument = Nothing
        Dim NewspaperDocument As AdvantageFramework.Database.Entities.NewspaperDocument = Nothing
        Dim InternetDocument As AdvantageFramework.Database.Entities.InternetDocument = Nothing
        Dim OutOfHomeDocument As AdvantageFramework.Database.Entities.OutOfHomeDocument = Nothing
        Dim RadioDocument As AdvantageFramework.Database.Entities.RadioDocument = Nothing
        Dim TVDocument As AdvantageFramework.Database.Entities.TVDocument = Nothing

        IsValid = AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage)

        If IsValid Then

            MemoryStream = New System.IO.MemoryStream
            Report.ExportToPdf(MemoryStream)

            MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(".pdf")
            FileSize = MemoryStream.Length
            FinalLevelDescription = AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder.ToString & ":" & OrderNumber
            FinalLevel = AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder.ToString
            Description = Description.Trim
            Keywords = Description
            FileName = Description & " - " & VendorCode & " - " & DbContext.UserCode & " - " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#") & ".pdf"

            If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, FileName, Description, Keywords, DbContext.UserCode, FinalLevel,
                                                 FinalLevelDescription, FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName, False) Then

                Document = New AdvantageFramework.Database.Entities.Document

                Document.DbContext = DbContext
                Document.FileName = FileName
                Document.FileSystemFileName = FileSystemFileName
                Document.MIMEType = MimeType
                Document.Description = Description
                Document.Keywords = Keywords
                Document.UploadedDate = System.DateTime.Now
                Document.UserCode = DbContext.UserCode
                Document.FileSize = FileSize
                Document.DocumentTypeID = 1
                Document.IsPrivate = False

                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                    If MediaFrom.Substring(0, 1) = "M" Then

                        MagazineDocument = New AdvantageFramework.Database.Entities.MagazineDocument

                        MagazineDocument.DocumentID = Document.ID
                        MagazineDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.MagazineDocument.Insert(DbContext, MagazineDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "N" Then

                        NewspaperDocument = New AdvantageFramework.Database.Entities.NewspaperDocument

                        NewspaperDocument.DocumentID = Document.ID
                        NewspaperDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.NewspaperDocument.Insert(DbContext, NewspaperDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "I" Then

                        InternetDocument = New AdvantageFramework.Database.Entities.InternetDocument

                        InternetDocument.DocumentID = Document.ID
                        InternetDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.InternetDocument.Insert(DbContext, InternetDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "O" Then

                        OutOfHomeDocument = New AdvantageFramework.Database.Entities.OutOfHomeDocument

                        OutOfHomeDocument.DocumentID = Document.ID
                        OutOfHomeDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.OutOfHomeDocument.Insert(DbContext, OutOfHomeDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "R" Then

                        RadioDocument = New AdvantageFramework.Database.Entities.RadioDocument

                        RadioDocument.DocumentID = Document.ID
                        RadioDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.RadioDocument.Insert(DbContext, RadioDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "T" Then

                        TVDocument = New AdvantageFramework.Database.Entities.TVDocument

                        TVDocument.DocumentID = Document.ID
                        TVDocument.OrderNumber = OrderNumber

                        AdvantageFramework.Database.Procedures.TVDocument.Insert(DbContext, TVDocument)

                    End If

                End If

            End If

        End If

    End Sub
    Public Function SendToPrinter(ByVal XtraReports As Generic.List(Of DevExpress.XtraReports.UI.XtraReport), ByVal UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel) As Boolean

        'objects
        Dim Printed As Boolean = False
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim PrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing

        Try

            If XtraReports IsNot Nothing AndAlso XtraReports.Count > 0 Then

                XtraReport = XtraReports.FirstOrDefault

                If XtraReports.Remove(XtraReport) Then

                    Using ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(XtraReport)

                        AddHandler ReportPrintTool.PrintingSystem.StartPrint, AddressOf PrintingSystem_StartPrint

                        Printed = ReportPrintTool.PrintDialog(UserLookAndFeel).GetValueOrDefault(False)

                        If Printed Then

                            For Each Report In XtraReports

                                PrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                                AddHandler PrintTool.PrintingSystem.StartPrint, AddressOf PrintTool_StartPrint

                                PrintTool.Print()

                            Next

                        End If

                    End Using

                End If

            End If

        Catch ex As Exception
            Printed = False
        End Try

        If _PrinterSettings IsNot Nothing Then

            _PrinterSettings = Nothing

        End If

        SendToPrinter = Printed

    End Function
    Private Sub PrintingSystem_StartPrint(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintDocumentEventArgs)

        _PrinterSettings = e.PrintDocument.PrinterSettings

    End Sub
    Private Sub PrintTool_StartPrint(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintDocumentEventArgs)

        'objects
        Dim PageCount As Integer = 0

        PageCount = e.PrintDocument.PrinterSettings.ToPage

        e.PrintDocument.PrinterSettings = _PrinterSettings
        ' Do this if your reports contain different number of pages,
        ' and you always need to print all pages in a report.
        e.PrintDocument.PrinterSettings.ToPage = PageCount

    End Sub
    Public Function CreateAdvancedReportWriterReport(ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectSchedule Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectScheduleReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientContact Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ClientContactReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DirectIndirectTime Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DirectIndirectTimeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DirectTime Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DirectTimeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DirectIndirectTimeWithEmployeeCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DirectIndirectTimeCostReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DirectTimeWithEmployeeCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DirectTimeCostReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobProjectScheduleSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobProjectScheduleSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailBillMonth Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFunction Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailItem Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Alerts Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AlertsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AlertsWithComments Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AlertsWithCommentsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AlertsWithRecipients Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AlertsWithRecipientsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByJobComponentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version29.DetailByFunctionVendorReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByJobComponentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version31.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByJobComponentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByClientDivisionProduct

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version6.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version7.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version8.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.DetailByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByJobComponentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Security.PermissionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectHoursUsed Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectHoursUsedReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeReconciliation Then

            XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Security.EmployeeSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectSummaryTask Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectSummaryTaskReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaCurrentStatus Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaCurrentStatusReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimatedAndActualIncome Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EstimatedAndActualIncomeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobPurchaseOrder Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobPurchaseOrderReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CRMOpportunityDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CRMOpportunityDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CRMOpportunityToInvestment Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CRMOpportunityToInvestmentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CRMProspects Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CRMProspectsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CRMClientContracts Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CRMClientContractsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaPlan Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MeidaPlanReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaCurrentStatusSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaCurrentStatusSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaPlanComparisonSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaPlanComparisonSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientPL Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ClientPLReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFee Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ServiceFeeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Clients Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ClientsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Divisions Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DivisionsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Products Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProductsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Employees Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeesReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Vendors Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.VendorsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Campaign Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CampaignReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.NewspaperOrderDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.NewspaperOrderDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AROpenAged Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AROpenAgedReport

        ElseIf AdvancedReportWriterReport = Reporting.AdvancedReportWriterReports.PurchaseOrder Then

            XtraReport = New AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CashAnalysis Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CashAnalysisReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SalesJournal Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SalesJournalReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SalesJournalWithComments Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SalesJournalWithCommentsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AuthorizationToBuy Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AuthorizationToBuyReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeTimeApproval Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeTimeApprovalReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GeneralLedgerDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.GeneralLedgerDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CampaignWithProductionAndMedia Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CampaignProductionMediaReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CampaignWithProductionAndMediaSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CampaignProductionMediaSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateDetailApproved Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EstimateDetailApprovedReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobWriteOff Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobWriteOffReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Transfer Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.TransferReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsPayableInvoiceDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsPayableInvoiceDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsPayableInvoiceDetailPayments Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsPayableInvoiceDetailPaymentsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsPayableInvoiceDetailPaidByClient Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsPayableInvoiceDetailPaidByClientReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsPayableInvoiceWithBalanceAging Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsPayableInvoiceWithBalanceAgingReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EstimateReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaResults Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaResultsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeContract Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobServiceFeeContractReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.IncomeOnly Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.IncomeOnlyReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BillingWorksheetProduction Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.BillingWorksheetProductionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectSummaryAnalysis Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectSummaryAnalysisReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ARPaymentHistory Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ARPaymentHistoryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientPLDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ClientPLDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BillingWorksheetMedia Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.BillingWorksheetMediaReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailItemAccountSplit Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemAccountSplitReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ExpenseReportAndApproval Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ExpenseReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.VendorContract Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.VendorContractsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.VirtualCreditCardTransactionEFS Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.VirtualCreditCardTransactionEFSReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobForecast Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobForecastReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.OpenPurchaseOrderDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.OpenPurchaseOrderDetail

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DigitalResultsComparison Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DigitalResultsComparisonReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaSpecificationsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecificationsByDestination Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaSpecificationsByDestinationReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GeneralLedgerReport Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.GeneralLedgerReport

            'ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaResultsComparisonByClientAndType Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaResultsComparisonByClientAndTypeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.TrialBalance Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.TrialBalanceReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsPayableBalanceByVendor Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsPayableBalanceByVendorReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.AccountsReceivableBalanceByClient Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.AccountsReceivableBalanceByClientReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SalesAndCostOfSalesByClient Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SalesAndCostOfSalesByClientReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.TimeReport Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.TimeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.RevenueBreakdownByClient Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.RevenueBreakdownByClientReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilization Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeUtilizationReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilizationBreakoutNonDirect Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeUtilizationReportBreakoutNonDirect

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BroadcastWorksheetTVPreBuy Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaBroadcastWorksheetPreBuyReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BroadcastWorksheetTVPostBuy Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaBroadcastWorksheetPostBuyReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CheckRegister Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CheckRegisterReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CheckRegisterWithInvoiceDetails Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CheckRegisterWithInvoiceDetailsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeInOutBoard Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeInOutBoardReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaPlanComparisonByVendor Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaPlanComparisonByVendorReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaPlanComparisonDetailByVendor Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaPlanComparisonDetailByVendorReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ResourcesAllocationByWeek Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ResourceAllocationByWeek

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GLChartOfAccounts Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.GLChartOfAccountsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GLReportRow Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.GLReportRowReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CashTransactions Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CashTransactionsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaCurrentStatusCoopBreakout Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaCurrentStatusCoopBreakoutReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByFunction Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByJobComponent Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPJobComponentReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByJob Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPJobReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByCampaign Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPCampaignReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByFunctionMinimized Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPFunctionMinimizedReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByJob1Minimized Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPJob1MinimizedReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFeesAndOOPByJob2Minimized Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailIFeesOOPJob2MinimizedReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ProjectScheduleTasksByEmployee Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.ProjectScheduleTasksByEmployeeReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MonthEndMediaWIP Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MonthEndMediaWIPReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MonthEndProductionWIP Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MonthEndProductionWIPReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MonthEndAccruedLiability Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MonthEndAccruedLiabilityReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MonthEndAccountsPayable Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MonthEndAccountsPayableReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeTimeForecast Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeTimeForecastReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityGroupModuleAccess Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityGroupModuleAccessReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityGroupUserSettings Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityGroupUserSettingsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityGroupSettings Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityGroupSettingsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityUserModuleAccess Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityUserModuleAccessReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityUserSettings Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityUserSettingsReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityUserLoginAudit Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.SecurityUserLoginAuditReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeHoursAllocation Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeHoursAllocationReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.InvoiceBilledBackup Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.InvoiceBilledBackupReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.CashManagementProduction Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.CashManagementProductionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaTrafficInstructions Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaTrafficInstructionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaTrafficMissingInstructions Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.MediaTrafficMissingInstructionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityUserTimesheetFunction Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.UserTimesheetFunctionReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BillingApproval Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.BillingApprovalReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BroadcastInvoiceSummary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.BroadcastInvoiceSummaryReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeTimeAnalysis Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.EmployeeTimeAnalysisReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.DeferredSalesVsOpenAR Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.DeferredSalesVsOpenAR

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BroadcastInvoiceDetail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.BroadcastInvoiceDetailReport

        ElseIf AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GLCrossOffice Then

            XtraReport = New AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.GLCrossOfficeReport

        End If

        XtraReport.DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(AdvancedReportWriterReport.ToString)

        CreateAdvancedReportWriterReport = XtraReport

    End Function
    Public Function CreateAdvancedReportWriterReportEstimate(ByVal EstimateReport As AdvantageFramework.Estimate.Printing.ReportFormats) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If EstimateReport = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport

        End If

        XtraReport.DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(EstimateReport.ToString)

        CreateAdvancedReportWriterReportEstimate = XtraReport

    End Function
    Public Function CreateCustomInvoiceReport(ByVal InvoiceType As AdvantageFramework.InvoicePrinting.InvoiceTypes) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If InvoiceType = InvoicePrinting.InvoiceTypes.Production Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionCurrentTTD Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionEstimatePriorCurrentTTD Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionGrandTotal Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionNetCommissionTaxCurrent Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.Media Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionEstimateCurrentTTD Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice

        ElseIf InvoiceType = InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUpComment Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice

        End If

        'XtraReport.DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(InvoiceType.ToString)

        CreateCustomInvoiceReport = XtraReport

    End Function
    Private Function CreateGroupSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Security.GroupSummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Security.GroupSummaryReport

        XtraReport.Session = Session

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

            If ParameterDictionary IsNot Nothing AndAlso
                    ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                XtraReport.DataSource = ParameterDictionary("DataSource")

            Else

                XtraReport.DataSource = (From EmployeeSummary In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                         Select EmployeeSummary
                                         Order By EmployeeSummary.GroupName).ToList

            End If

            XtraReport.DisplayName = "Group Summary Report"

        End Using

        CreateGroupSummaryReport = XtraReport

    End Function
    Private Function CreateEmployeeSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                 ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Security.EmployeeSummaryReport = Nothing
        Dim EmployeeCodes As Generic.List(Of String) = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Security.EmployeeSummaryReport

        XtraReport.Session = Session

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

            If ParameterDictionary IsNot Nothing AndAlso
                    ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                XtraReport.DataSource = ParameterDictionary("DataSource")

            Else

                EmployeeCodes = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, Session).Select(Function(Entity) Entity.Code).Distinct.ToList

                XtraReport.DataSource = (From EmployeeSummary In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                         Where EmployeeCodes.Contains(EmployeeSummary.EmployeeCode) = True
                                         Select EmployeeSummary
                                         Order By EmployeeSummary.Employee).ToList

            End If

            XtraReport.DisplayName = "Employee Summary Report"

        End Using

        CreateEmployeeSummaryReport = XtraReport

    End Function
    Private Function CreateGroupSecurityReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Security.GroupPermissionReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Security.GroupPermissionReport

        XtraReport.Session = Session

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

            If ParameterDictionary IsNot Nothing AndAlso
                    ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                XtraReport.DataSource = ParameterDictionary("DataSource")

            Else

                XtraReport.DataSource = (From GroupPermissionsReport In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityDbContext)
                                         Where GroupPermissionsReport.ModuleIsCategory = False AndAlso
                                               GroupPermissionsReport.ApplicationIsBlocked = False
                                         Select GroupPermissionsReport
                                         Order By GroupPermissionsReport.ParentModuleSortOrder,
                                                  GroupPermissionsReport.SubParentModuleSortOrder,
                                                  GroupPermissionsReport.ModuleSortOrder).ToList

            End If

            XtraReport.DisplayName = "Group Security Report"

        End Using

        CreateGroupSecurityReport = XtraReport

    End Function
    Private Function CreateSecurityReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Security.PermissionReport = Nothing
        Dim UserIDsList As Generic.List(Of Integer) = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Security.PermissionReport

        XtraReport.Session = Session

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

            If ParameterDictionary IsNot Nothing AndAlso
                    ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                XtraReport.DataSource = ParameterDictionary("DataSource")

            Else

                UserIDsList = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, Session).Include("Users").SelectMany(Function(Employee) Employee.Users).Distinct.ToList.Select(Function(Entity) Entity.ID).Distinct.ToList

                XtraReport.DataSource = (From UserPermissionsReport In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityDbContext)
                                         Where UserIDsList.Contains(UserPermissionsReport.UserID) = True AndAlso
                                               UserPermissionsReport.ModuleIsCategory = False AndAlso
                                               UserPermissionsReport.ApplicationIsBlocked = False
                                         Select UserPermissionsReport
                                         Order By UserPermissionsReport.ParentModuleSortOrder,
                                                  UserPermissionsReport.SubParentModuleSortOrder,
                                                  UserPermissionsReport.ModuleSortOrder).ToList

            End If

            XtraReport.DisplayName = "Security Report"

        End Using

        CreateSecurityReport = XtraReport

    End Function
    Private Function LoadAdvancedBillingHistory(DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory)

        Dim AdvancedBillingHistoryList As Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory) = Nothing

        Try

            AdvancedBillingHistoryList = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory)(String.Format("exec dbo.advsp_job_detail_adv_bill_hist")).ToList

        Catch ex As Exception
            AdvancedBillingHistoryList = Nothing
        End Try

        LoadAdvancedBillingHistory = AdvancedBillingHistoryList

    End Function
    Private Function CreateJobDetailAnalysisReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Session As AdvantageFramework.Security.Session) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.DetailByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.DetailByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.DetailByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.SummaryByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByFunctionReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.DetailByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.DetailByFunctionReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.DetailByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByJobComponentReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByJobComponentReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByJobComponentReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version11.SummaryByJobComponentReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version29.DetailByFunctionVendorReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisCategoryData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version29.DetailByFunctionVendorReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail Then

            Dim XtraReport2 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.DetailByFunctionReport = Nothing

            XtraReport2 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.DetailByFunctionReport

            XtraReport2.Session = Session

            XtraReport2.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisQVAData(Session, DbContext, Report, ParameterDictionary)

            XtraReport = XtraReport2

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary Then

            Dim XtraReport2 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByFunctionReport = Nothing

            XtraReport2 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByFunctionReport

            XtraReport2.Session = Session

            XtraReport2.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisQVAData(Session, DbContext, Report, ParameterDictionary)

            XtraReport = XtraReport2

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp Then

            Dim XtraReport2 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByJobComponentReport = Nothing

            XtraReport2 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByJobComponentReport

            XtraReport2.Session = Session

            XtraReport2.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisQVAData(Session, DbContext, Report, ParameterDictionary)

            XtraReport = XtraReport2

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31 Then

            Dim XtraReport2 As AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version31.SummaryByFunctionReport = Nothing

            XtraReport2 = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version31.SummaryByFunctionReport

            XtraReport2.Session = Session

            XtraReport2.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisQVAData(Session, DbContext, Report, ParameterDictionary)

            XtraReport = XtraReport2

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.SummaryByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.DetailByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.DetailByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version2.DetailByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByJobComponentReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByJobComponentReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version3.SummaryByJobComponentReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.DetailByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.DetailByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version4.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisDataEmployeeTime(Session, ReportDbContext, Report, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByClientDivisionProduct

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version5.SummaryByClientDivisionProduct).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisDataCDP(Session, ReportDbContext, Report, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version6.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version6.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisCurrentPriorData(Session, ReportDbContext, Report, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version7.SummaryByFunctionReport

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version7.SummaryByFunctionReport).Grouping = ParameterDictionary("JobDetailAnalysis_SortBy")

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisCurrentPriorData(Session, ReportDbContext, Report, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8 Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version8.SummaryByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisDataAdvanceBilling(Session, ReportDbContext, Report, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByFunctionReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.DetailByFunctionReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.DetailByFunctionReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.DetailByFunctionReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp Then

            XtraReport = New AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByJobComponentReport

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadJobDetailAnalysisData(Session, DbContext, Report, ParameterDictionary)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByJobComponentReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(DbContext)

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByJobComponentReport).XrSubreport2.ReportSource.DataSource = AdvantageFramework.Reporting.LoadBillingPaymentsData(DbContext).ToList

            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version9.SummaryByJobComponentReport).XrSubreport1.ReportSource.DataSource = AdvantageFramework.Reporting.LoadAdvanceRconciliationHistoryData(DbContext).ToList

        End If

        If XtraReport IsNot Nothing Then

            XtraReport.DisplayName = Report.ToString

        End If

        CreateJobDetailAnalysisReport = XtraReport

    End Function
    Private Function CreateAccountExecutiveUpdateReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.AccountExecutiveUpdateReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.AccountExecutiveUpdateReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Account Executive Update Report"

        CreateAccountExecutiveUpdateReport = XtraReport

    End Function
    Public Function CreateUserDefinedReport(ByVal UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim ParameterCriteria As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterDateFrom As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterDateTo As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCutoffsEmployeeTimeDate As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCutoffsIncomeOnlyDate As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCutoffsAPPostingPeriod As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCurrentStartDate As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCurrentEndDate As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterCurrentPeriod As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterBilledRecordsStartingPostPeriod As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim ParameterBilledRecordsEndingPostPeriod As DevExpress.XtraReports.Parameters.Parameter = Nothing
        Dim CreateParameters As Boolean = False

        Try

            Using MemoryStream = New System.IO.MemoryStream

                Using StreamWriter = New System.IO.StreamWriter(MemoryStream)

                    StreamWriter.Write(UserDefinedReport.ReportDefinition)
                    StreamWriter.Flush()

                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    XtraReport = DevExpress.XtraReports.UI.XtraReport.FromStream(MemoryStream, True)

                    If UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.IUserDefinedReport).UserDefinedReportID = UserDefinedReport.ID

                    End If

                    If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetail OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailItem OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailBillMonth OrElse
                            UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFunction Then

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport Then

                            If XtraReport.Parameters.Count = 0 Then

                                CreateParameters = True

                            End If

                        End If

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport Then

                            If XtraReport.Parameters.Count = 0 Then

                                CreateParameters = True

                            End If

                        End If

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport Then

                            If XtraReport.Parameters.Count = 0 Then

                                CreateParameters = True

                            End If

                        End If

                        If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport Then

                            If XtraReport.Parameters.Count = 0 Then

                                CreateParameters = True

                            End If

                        End If

                        If CreateParameters Then

                            ParameterCriteria = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterDateFrom = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterDateTo = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCutoffsEmployeeTimeDate = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCutoffsIncomeOnlyDate = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCutoffsAPPostingPeriod = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCurrentStartDate = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCurrentEndDate = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterCurrentPeriod = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterBilledRecordsStartingPostPeriod = New DevExpress.XtraReports.Parameters.Parameter()
                            ParameterBilledRecordsEndingPostPeriod = New DevExpress.XtraReports.Parameters.Parameter()

                            ParameterCriteria.Name = "ParameterCriteria"
                            ParameterCriteria.Visible = False

                            ParameterDateFrom.Name = "ParameterDateFrom"
                            ParameterDateFrom.Visible = False

                            ParameterDateTo.Name = "ParameterDateTo"
                            ParameterDateTo.Visible = False

                            ParameterCutoffsEmployeeTimeDate.Name = "ParameterCutoffsEmployeeTimeDate"
                            ParameterCutoffsEmployeeTimeDate.Visible = False

                            ParameterCutoffsIncomeOnlyDate.Name = "ParameterCutoffsIncomeOnlyDate"
                            ParameterCutoffsIncomeOnlyDate.Visible = False

                            ParameterCutoffsAPPostingPeriod.Name = "ParameterCutoffsAPPostingPeriod"
                            ParameterCutoffsAPPostingPeriod.Visible = False

                            ParameterCurrentStartDate.Name = "ParameterCurrentStartDate"
                            ParameterCurrentStartDate.Visible = False

                            ParameterCurrentEndDate.Name = "ParameterCurrentEndDate"
                            ParameterCurrentEndDate.Visible = False

                            ParameterCurrentPeriod.Name = "ParameterCurrentPeriod"
                            ParameterCurrentPeriod.Visible = False

                            ParameterBilledRecordsStartingPostPeriod.Name = "ParameterBilledRecordsStartingPostPeriod"
                            ParameterBilledRecordsStartingPostPeriod.Visible = False

                            ParameterBilledRecordsEndingPostPeriod.Name = "ParameterBilledRecordsEndingPostPeriod"
                            ParameterBilledRecordsEndingPostPeriod.Visible = False

                            XtraReport.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {ParameterCriteria, ParameterDateFrom, ParameterDateTo, ParameterCutoffsEmployeeTimeDate,
                                                           ParameterCutoffsIncomeOnlyDate, ParameterCutoffsAPPostingPeriod, ParameterCurrentStartDate, ParameterCurrentEndDate, ParameterCurrentPeriod,
                                                           ParameterBilledRecordsStartingPostPeriod, ParameterBilledRecordsEndingPostPeriod})

                        End If

                    End If

                    XtraReport.DisplayName = UserDefinedReport.Description

                End Using

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateUserDefinedReport = XtraReport

    End Function
    Public Function CreateCustomInvoiceReport(ByVal CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        Try

            Using MemoryStream = New System.IO.MemoryStream

                Using StreamWriter = New System.IO.StreamWriter(MemoryStream)

                    StreamWriter.Write(CustomInvoice.ReportDefinition)
                    StreamWriter.Flush()

                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    XtraReport = DevExpress.XtraReports.UI.XtraReport.FromStream(MemoryStream, True)

                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.ICustomInvoice).CustomInvoiceID = CustomInvoice.ID

                    XtraReport.DisplayName = CustomInvoice.Description

                End Using

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateCustomInvoiceReport = XtraReport

    End Function
    Public Function CreateCustomEstimateReport(ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        Try

            Using MemoryStream = New System.IO.MemoryStream

                Using StreamWriter = New System.IO.StreamWriter(MemoryStream)

                    StreamWriter.Write(EstimateReport.ReportDefinition)
                    StreamWriter.Flush()

                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    XtraReport = DevExpress.XtraReports.UI.XtraReport.FromStream(MemoryStream, True)

                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID

                    XtraReport.DisplayName = EstimateReport.Description

                End Using

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateCustomEstimateReport = XtraReport

    End Function
    Private Function CreateCashManagementReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object), ByVal Session As AdvantageFramework.Security.Session) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNet Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdSummaryARPdNet

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNetIncludeNonbillableCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdSummaryARPdNetIncludeNBCost

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGross Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdSummaryARPdGross

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGrossIncludeNonbillableCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdSummaryARPdGrossIncludeNBCost

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNet Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdDetailARPdNet

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNetIncludeNonbillableCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdDetailARPdNetIncludeNBCost

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGross Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdDetailARPdGross

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGrossIncludeNonbillableCost Then

            XtraReport = New AdvantageFramework.Reporting.Reports.CashManagement.CashManagementProdDetailARPdGrossIncludeNBCost

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadCashManagementProductionData(DbContext, Nothing, Nothing, Nothing, Nothing, ParameterDictionary)

        End If

        If XtraReport IsNot Nothing Then

            XtraReport.DisplayName = Report.ToString

        End If

        CreateCashManagementReport = XtraReport

    End Function
    Public Function CreateUserDefinedEstimateReport(ByVal EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        Try

            Using MemoryStream = New System.IO.MemoryStream

                Using StreamWriter = New System.IO.StreamWriter(MemoryStream)

                    StreamWriter.Write(EstimateReport.ReportDefinition)
                    StreamWriter.Flush()

                    MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                    XtraReport = DevExpress.XtraReports.UI.XtraReport.FromStream(MemoryStream, True)

                    If EstimateReport.EstimateReportType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.IEstimateReport).EstimateReportID = EstimateReport.ID

                    End If

                    XtraReport.DisplayName = EstimateReport.Description

                End Using

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateUserDefinedEstimateReport = XtraReport

    End Function
    Private Function CreateUserDefinedReport(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                             ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
        Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, ParameterDictionary("UserDefinedReportID"))

                If UserDefinedReport IsNot Nothing Then

                    XtraReport = CreateUserDefinedReport(UserDefinedReport)

                    If UserDefinedReport.AdvancedReportWriterType <> AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                XtraReport.DataSource = AdvantageFramework.Reporting.LoadUserDefinedReportData(SecurityDbContext, DbContext, ReportingDbContext, UserDefinedReport.AdvancedReportWriterType, ParameterDictionary, Criteria, FilterString, [From], [To], Session)

                                If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecifications Then

                                    XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecificationsData(DbContext, ParameterDictionary, Session)

                                End If

                                If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeUtilizationBreakoutNonDirect Then

                                    XtraReport.DataSource = AdvantageFramework.Reporting.LoadEmployeeUtilizationReportData(DbContext, ParameterDictionary, Session)

                                End If

                                If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.MediaSpecificationsByDestination Then

                                    XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaSpecificationsByDestinationData(DbContext, ParameterDictionary, Session)

                                End If

                            End Using

                        End Using

                    End If

                    If UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)).ToList

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version10.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)).ToList

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.DetailByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)).ToList

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version1.SummaryByFunctionReport).XrSubreport1.ReportSource.DataSource = LoadAdvancedBillingHistory(New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)).ToList

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.DetailByFunctionReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByFunctionReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version30.SummaryByJobComponentReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version31.SummaryByFunctionReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.JobAnalysisDetail.Version29.DetailByFunctionVendorReport).XrSubreport3.ReportSource.DataSource = LoadAdvancedBillingHistory(New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)).ToList

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Security.PermissionReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeReconciliation Then

                        CreateServiceFeeReconciliationReport(XtraReport, Session, Report, ParameterDictionary)

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Security.EmployeeSummaryReport).Session = Session

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.PurchaseOrder Then

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport).Session = Session

                        If ParameterDictionary.ContainsKey("DefaultLocation") Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport).DefaultLocation = ParameterDictionary("DefaultLocation")

                        End If

                        If ParameterDictionary.ContainsKey("PrintDefaults") Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport).PrintDefaults = ParameterDictionary("PrintDefaults")

                        End If

                        If ParameterDictionary.ContainsKey("UsePrintedDate") Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport).UsePrintedDate = ParameterDictionary("UsePrintedDate")

                        End If

                        If ParameterDictionary.ContainsKey("FooterAboveSignature") Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport).FooterAboveSignature = ParameterDictionary("FooterAboveSignature")

                        End If

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetail Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                        End Using

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCriteria.Value = AdvantageFramework.StringUtilities.GetNameAsWords(CType(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString), AdvantageFramework.Reporting.JobDetailItemInitialCriteria).ToString)

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterDateFrom.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterDateTo.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCutoffsEmployeeTimeDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCutoffsIncomeOnlyDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCutoffsAPPostingPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCurrentStartDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCurrentEndDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterCurrentPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterBilledRecordsStartingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailReport).ParameterBilledRecordsEndingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailFunction Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                        End Using

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCriteria.Value = AdvantageFramework.StringUtilities.GetNameAsWords(CType(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString), AdvantageFramework.Reporting.JobDetailItemInitialCriteria).ToString)

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterDateFrom.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterDateTo.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCutoffsEmployeeTimeDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCutoffsIncomeOnlyDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCutoffsAPPostingPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCurrentStartDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCurrentEndDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterCurrentPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterBilledRecordsStartingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailFunctionReport).ParameterBilledRecordsEndingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailBillMonth Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                        End Using

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCriteria.Value = AdvantageFramework.StringUtilities.GetNameAsWords(CType(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString), AdvantageFramework.Reporting.JobDetailItemInitialCriteria).ToString)

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterDateFrom.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterDateTo.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCutoffsEmployeeTimeDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCutoffsIncomeOnlyDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCutoffsAPPostingPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCurrentStartDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCurrentEndDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterCurrentPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterBilledRecordsStartingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailBillMonthReport).ParameterBilledRecordsEndingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                    ElseIf UserDefinedReport.AdvancedReportWriterType = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailItem Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).ToList

                        End Using

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCriteria.Value = AdvantageFramework.StringUtilities.GetNameAsWords(CType(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobDateCriteria.ToString), AdvantageFramework.Reporting.JobDetailItemInitialCriteria).ToString)

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterDateFrom.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterDateTo.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.JobEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCutoffsEmployeeTimeDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EmployeeDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCutoffsIncomeOnlyDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.IncomeOnlyDateCutoff.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.AccountsPayablePostingPeriodCutoff.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCutoffsAPPostingPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCurrentStartDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentStartDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString) Then

                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCurrentEndDate.Value = CDate(ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentEndDate.ToString)).ToShortDateString

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.CurrentPeriod.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterCurrentPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.StartingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterBilledRecordsStartingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                        If ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString) Then

                            PostPeriod = PostPeriods.SingleOrDefault(Function(Entity) Entity.Code = ParameterDictionary(AdvantageFramework.Reporting.JobDetailInitialParameters.EndingPostPeriodCode.ToString))

                            If PostPeriod IsNot Nothing Then

                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.AdvancedReportWriterReports.JobDetailItemReport).ParameterBilledRecordsEndingPostPeriod.Value = PostPeriod.Code & " - " & PostPeriod.Description

                            End If

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateUserDefinedReport = XtraReport

    End Function
    Private Function CreateUserDefinedEstimateReport(ByVal Session As AdvantageFramework.Security.Session,
                                             ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                             ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
        Dim FooterType As String = ""
        Dim FooterFont As Integer = 9
        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, ParameterDictionary("EstimateReportID"))

                If EstimateReport IsNot Nothing Then

                    XtraReport = CreateUserDefinedEstimateReport(EstimateReport)

                    If EstimateReport.EstimateReportType = AdvantageFramework.Reporting.EstimateReportTypes.OneQuotePerPage Then

                        Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
                        Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
                        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

                        DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Session = Session

                        If ParameterDictionary.ContainsKey("EstimateQuote") Then
                            EstimateQuote = ParameterDictionary("EstimateQuote")
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateNumber = EstimateQuote.EstimateNumber
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UserCode = Session.UserCode
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ClientCode = EstimateQuote.ClientCode
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DivisionCode = EstimateQuote.DivisionCode
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ProductCode = EstimateQuote.ProductCode
                            DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateQuote.EstimateDate
                            If ParameterDictionary.ContainsKey("PrintDefaults") Then
                                EstimatePrintingSetting = ParameterDictionary("PrintDefaults")
                                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                                End Using
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintingSetting = EstimatePrintingSetting
                                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultLocation = Location
                                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)

                                    DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).SetParameterValues()
                                End Using

                            End If
                            If EstimatePrintingSetting.DateToPrint = True Then
                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimatePrintingSetting.DatePrint
                            End If
                        End If

                    End If

                End If

            End Using

        Catch ex As Exception
            XtraReport = Nothing
        End Try

        CreateUserDefinedEstimateReport = XtraReport

    End Function
    Private Function CreateEmployeeAddressListingReport(ByVal Session As AdvantageFramework.Security.Session,
                                                        ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeAddressListingReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeAddressListingReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Employee Address Listing Report"

        CreateEmployeeAddressListingReport = XtraReport

    End Function
    Private Function CreateEmployeeRateHistoryReport(ByVal Session As AdvantageFramework.Security.Session,
                                                     ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                     ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeRateHistoryReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeRateHistoryReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Employee Rate History Report"

        CreateEmployeeRateHistoryReport = XtraReport

    End Function
    Private Function CreateEmployeeDetailListingReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeDetailListingReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeDetailListingReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Employee Detail Listing Report"

        CreateEmployeeDetailListingReport = XtraReport

    End Function
    Private Function CreateEmployeeDetailListingWithHRReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeDetailListingWithHRReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeDetailListingWithHRReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Employee Detail Listing with HR Report"

        CreateEmployeeDetailListingWithHRReport = XtraReport

    End Function
    Private Function CreateEmployeeExpenseReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                 ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim InvoiceNumbers As Integer() = Nothing

        Try

            XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeExpenseReport

            XtraReport.Session = Session

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    XtraReport.AgencyName = Agency.Name

                End If

                If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                    XtraReport.DataSource = ParameterDictionary("DataSource")

                ElseIf ParameterDictionary.ContainsKey("InvoiceNumbers") Then

                    InvoiceNumbers = ParameterDictionary("InvoiceNumbers")

                    XtraReport.DataSource = (From Item In AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext)
                                             Where InvoiceNumbers.Contains(Item.InvoiceNumber)
                                             Select Item).ToList

                End If

            End Using

            If ParameterDictionary.ContainsKey("ExcludeEmployeeSignature") Then

                XtraReport.ExcludeEmployeeSignature = ParameterDictionary("ExcludeEmployeeSignature")

            End If

            If ParameterDictionary.ContainsKey("PrintApproverName") Then

                XtraReport.PrintApproverName = ParameterDictionary("PrintApproverName")

            End If

            If ParameterDictionary.ContainsKey("ExcludeSupervisorSignature") Then

                XtraReport.ExcludeSupervisorSignature = ParameterDictionary("ExcludeSupervisorSignature")

            End If

            XtraReport.DisplayName = "Employee Expense Report"

        Catch ex As Exception

        End Try

        CreateEmployeeExpenseReport = XtraReport

    End Function
    Private Function CreateStandard1099Report(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099Report = Nothing
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099Report

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_COMPANYNAME.ToString)

            If Setting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Setting.Value) = False Then

                    XtraReport.AgencyName = Setting.Value

                End If

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.ReportRange = ParameterDictionary("CheckDateRange")

        XtraReport.DisplayName = "1099 Report"

        CreateStandard1099Report = XtraReport

    End Function
    Private Function CreateStandard1099FormReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                  ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099FormReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099FormReport

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "1099 Forms"

        CreateStandard1099FormReport = XtraReport

    End Function
    Private Function CreateSummary1099AllVendorsReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                       ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Summary1099AllVendors = Nothing
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Summary1099AllVendors

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_COMPANYNAME.ToString)

            If Setting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Setting.Value) = False Then

                    XtraReport.AgencyName = Setting.Value

                End If

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportCriteria = ParameterDictionary("CheckDateRange")

        XtraReport.DisplayName = "1099 All Vendors (Summary)"

        CreateSummary1099AllVendorsReport = XtraReport

    End Function
    Private Function CreateDetail1099WithDisbursementReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                            ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Detail1099WithDisbursementReport = Nothing
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Detail1099WithDisbursementReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_COMPANYNAME.ToString)

            If Setting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Setting.Value) = False Then

                    XtraReport.AgencyName = Setting.Value

                End If

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportCriteria = ParameterDictionary("CheckDateRange")
        XtraReport.StartDate = ParameterDictionary("StartDate")
        XtraReport.EndDate = ParameterDictionary("EndDate")

        XtraReport.DisplayName = "1099 Detail with AP Disbursement"

        CreateDetail1099WithDisbursementReport = XtraReport

    End Function
    Private Function CreateAccountReceivableImportBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountReceivableImportBatchReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountReceivableImportBatchReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")

        XtraReport.DisplayName = "Account Receivable Import Batch"

        CreateAccountReceivableImportBatchReport = XtraReport

    End Function
    Private Function CreateClientCashReceiptBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptBatchReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptBatchReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.DetailPageBreak = ParameterDictionary("DetailPageBreak")

        XtraReport.DisplayName = "Client Cash Receipt Batch Report"

        CreateClientCashReceiptBatchReport = XtraReport

    End Function
    Private Function CreateAuthorizationToBuyDigitalMedia(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                         ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaATBReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaATBReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Authorization to Buy Digital Media"

        If ParameterDictionary.ContainsKey("ReportTitle") Then

            Try

                If CStr(ParameterDictionary("ReportTitle")) <> "" Then

                    XtraReport.ReportTitle = ParameterDictionary("ReportTitle")

                End If

            Catch ex As Exception

            End Try

        End If

        If ParameterDictionary.ContainsKey("Location") Then

            Try

                XtraReport.DefaultLocation = ParameterDictionary("Location")

            Catch ex As Exception

            End Try

        End If

        CreateAuthorizationToBuyDigitalMedia = XtraReport

    End Function
    Private Function CreateAuthorizationToBuyDigitalMediaForm(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaATBFormReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaATBFormReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")

        If ParameterDictionary.ContainsKey("SignatureLines") Then

            Try

                XtraReport.SignatureLines = CInt(ParameterDictionary("SignatureLines"))

            Catch ex As Exception
                XtraReport.SignatureLines = 0
            End Try

        End If

        XtraReport.DisplayName = "Authorization to Buy Digital Media"

        If ParameterDictionary.ContainsKey("ReportTitle") Then

            Try

                If CStr(ParameterDictionary("ReportTitle")) <> "" Then

                    XtraReport.ReportTitle = ParameterDictionary("ReportTitle")

                End If

            Catch ex As Exception

            End Try

        End If

        If ParameterDictionary.ContainsKey("Location") Then

            Try

                XtraReport.DefaultLocation = ParameterDictionary("Location")

            Catch ex As Exception

            End Try

        End If

        CreateAuthorizationToBuyDigitalMediaForm = XtraReport

    End Function
    Private Function CreateIncomeOnlyBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                 ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.IncomeOnlyBatchReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.IncomeOnlyBatchReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.DisplayName = "Income Only Batch List"
        XtraReport.ForUser = ParameterDictionary("ForUser")

        CreateIncomeOnlyBatchReport = XtraReport

    End Function
    Private Function CreateIncomeOnlyBatchSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.IncomeOnlyBatchSummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.IncomeOnlyBatchSummaryReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.DisplayName = "Income Only Batch List"
        XtraReport.ForUser = ParameterDictionary("ForUser")

        CreateIncomeOnlyBatchSummaryReport = XtraReport

    End Function
    Private Function CreateClientCashReceiptBatchSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptBatchSummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientCashReceiptBatchSummaryReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")

        XtraReport.DisplayName = "Client Cash Receipt Batch Summary Report"

        CreateClientCashReceiptBatchSummaryReport = XtraReport

    End Function
    Private Function CreateClientInvoiceBatchDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceBatchDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceBatchDetailReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")

        XtraReport.DisplayName = "Client Invoice Batch Detail Report"

        CreateClientInvoiceBatchDetailReport = XtraReport

    End Function
    Private Function CreateClientInvoiceBatchSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                           ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceBatchSummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceBatchSummaryReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")

        XtraReport.DisplayName = "Client Invoice Batch Summary Report"

        CreateClientInvoiceBatchSummaryReport = XtraReport

    End Function
    Private Function CreateClientInvoiceReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientInvoiceReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ClientCode = ParameterDictionary("ClientCode")
        XtraReport.DateFrom = ParameterDictionary("From")
        XtraReport.DateTo = ParameterDictionary("To")

        XtraReport.DisplayName = "Client Invoices Report"

        CreateClientInvoiceReport = XtraReport

    End Function
    Private Function CreatePaymentManagerReport(Session As AdvantageFramework.Security.Session,
                                                ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.PaymentManagerReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.PaymentManagerReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

        End Using

        XtraReport.Session = Session

        XtraReport.BankCode = ParameterDictionary("BankCode")
        XtraReport.CheckRunID = ParameterDictionary("CheckRunID")

        XtraReport.DisplayName = "Payment Manager Report"

        CreatePaymentManagerReport = XtraReport

    End Function
    Private Function CreateAccountPayableImportExpenseReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableImportExpenseReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableImportExpenseReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.DetailPageBreak = ParameterDictionary("DetailPageBreak")

        XtraReport.DisplayName = "Account Payable Import Expense Report"

        CreateAccountPayableImportExpenseReport = XtraReport

    End Function
    Private Function CreateTaskTemplateReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.DisplayName = "Task Templates Report"

        CreateTaskTemplateReport = XtraReport

    End Function
    Private Function CreateTaskTemplateWithRolesReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                       ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateWithRolesReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.TaskTemplateWithRolesReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.DisplayName = "Task Templates with Roles Report"

        CreateTaskTemplateWithRolesReport = XtraReport

    End Function
    Private Function CreateServiceFeeReconciliationReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        CreateServiceFeeReconciliationReport = CreateServiceFeeReconciliationReport(Nothing, Session, Report, ParameterDictionary)

    End Function
    Private Function CreateServiceFeeReconciliationReport(ByVal XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport,
                                                          ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing

        Try

            ServiceFeeReconciliationSetting = ParameterDictionary("ServiceFeeReconciliationSetting")

        Catch ex As Exception
            ServiceFeeReconciliationSetting = Nothing
        End Try

        If ServiceFeeReconciliationSetting Is Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ServiceFeeReconciliationSetting = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.LoadByUserCode(SecurityDbContext, Session.UserCode)

            End Using

        End If

        If ServiceFeeReconciliationSetting IsNot Nothing Then

            If XtraReport Is Nothing Then

                XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationReport

            End If

            XtraReport.Session = Session
            XtraReport.ServiceFeeReconciliationSetting = ServiceFeeReconciliationSetting
            XtraReport.FeePostPeriodFrom = ParameterDictionary("FeePostPeriodFrom")
            XtraReport.FeePostPeriodTo = ParameterDictionary("FeePostPeriodTo")
            XtraReport.FeeTimeFrom = ParameterDictionary("FeeTimeFrom")
            XtraReport.FeeTimeTo = ParameterDictionary("FeeTimeTo")
            XtraReport.ServiceFeeReconciliationGroupByOption = ParameterDictionary("ServiceFeeReconciliationGroupByOption")
            XtraReport.ServiceFeeReconciliationSummaryStyle = ParameterDictionary("ServiceFeeReconciliationSummaryStyle")

            XtraReport.DataSource = ParameterDictionary("DataSource")

            XtraReport.DisplayName = "Service Fee Reconciliation Report"

        End If

        CreateServiceFeeReconciliationReport = XtraReport

    End Function
    Private Function CreateServiceFeeReconciliationDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationDetailReport = Nothing
        Dim ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing

        Try

            ServiceFeeReconciliationSetting = ParameterDictionary("ServiceFeeReconciliationSetting")

        Catch ex As Exception
            ServiceFeeReconciliationSetting = Nothing
        End Try

        If ServiceFeeReconciliationSetting IsNot Nothing Then

            XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationDetailReport

            XtraReport.Session = Session
            XtraReport.ServiceFeeReconciliationSetting = ServiceFeeReconciliationSetting
            XtraReport.FeePostPeriodFrom = ParameterDictionary("FeePostPeriodFrom")
            XtraReport.FeePostPeriodTo = ParameterDictionary("FeePostPeriodTo")
            XtraReport.FeeTimeFrom = ParameterDictionary("FeeTimeFrom")
            XtraReport.FeeTimeTo = ParameterDictionary("FeeTimeTo")
            XtraReport.ServiceFeeReconciliationGroupByOption = ParameterDictionary("ServiceFeeReconciliationGroupByOption")
            XtraReport.ServiceFeeReconciliationSummaryStyle = ParameterDictionary("ServiceFeeReconciliationSummaryStyle")

            XtraReport.DataSource = ParameterDictionary("DataSource")

            XtraReport.DisplayName = "Service Fee Reconciliation Detail Report"

        End If

        CreateServiceFeeReconciliationDetailReport = XtraReport

    End Function
    Private Function CreateAccountsPayableBatchDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                            ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchDetailReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchDetailReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.DetailPageBreak = ParameterDictionary("DetailPageBreak")

        XtraReport.DisplayName = "Account Payable Batch Detail Report"

        CreateAccountsPayableBatchDetailReport = XtraReport

    End Function
    Private Function CreateAccountsPayableBatchSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchSummaryReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchSummaryReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")

        XtraReport.DisplayName = "Account Payable Batch Summary Report"

        CreateAccountsPayableBatchSummaryReport = XtraReport

    End Function
    Private Function CreateAccountPayableBatchSummaryDataEntryOrderReport(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                                          ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchSummaryDataEntryOrderReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableBatchSummaryDataEntryOrderReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")

        XtraReport.DisplayName = "Account Payable Batch Summary Report"

        CreateAccountPayableBatchSummaryDataEntryOrderReport = XtraReport

    End Function
    Private Function CreateAccountsPayableRecurBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                           ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableRecurBatchReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.AccountPayableRecurBatchReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.DetailPageBreak = ParameterDictionary("DetailPageBreak")

        XtraReport.DisplayName = "Account Payable Recur Batch Report"

        CreateAccountsPayableRecurBatchReport = XtraReport

    End Function
    Private Function CreateOfficeAndDepartmentCrossReferenceReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.GeneralLedger.OfficeAndDepartmentCrossReferenceReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.OfficeAndDepartmentCrossReferenceReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        'XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Office and Department Cross Reference Report"

        CreateOfficeAndDepartmentCrossReferenceReport = XtraReport

    End Function
    Private Function CreateGLAccountGroupReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.GeneralLedger.GLAccountGroupReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.GLAccountGroupReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Account Group Report"

        CreateGLAccountGroupReport = XtraReport

    End Function
    Private Function CreateGLAccountAllocationReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                     ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.GeneralLedger.StandardGLAccountAllocationReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.StandardGLAccountAllocationReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Account Allocation Report"

        CreateGLAccountAllocationReport = XtraReport

    End Function
    Private Function CreateBankReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.BankReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.BankReport

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Bank Report"

        CreateBankReport = XtraReport

    End Function
    Private Function CreateClientDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Client.ClientDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Client.ClientDetailReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        'XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Client Report - 001 - Detail"

        CreateClientDetailReport = XtraReport

    End Function
    Private Function CreateClientReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                    ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.ClientReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.ClientReport

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Client Report"

        CreateClientReport = XtraReport

    End Function
    Private Function CreateDivisionDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Client.DivisionDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Client.DivisionDetailReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        'XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Division Report - 002 - Detail"

        CreateDivisionDetailReport = XtraReport

    End Function
    Private Function CreateProductDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Client.ProductDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Client.ProductDetailReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        'XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Product Report - 003 - Detail"

        CreateProductDetailReport = XtraReport

    End Function
    Private Function CreateClientContractOpportunityDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                 ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Client.ClientContractOpportunityDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Client.ClientContractOpportunityDetailReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        'XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Client Contract/Opportunity Detail Report - 004"

        CreateClientContractOpportunityDetailReport = XtraReport

    End Function
    Private Function CreateCRMDetailedInformationReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Client.CRMDetailedInformationReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Client.CRMDetailedInformationReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        'XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "CRM Detailed Information Report - 005"

        CreateCRMDetailedInformationReport = XtraReport

    End Function
    Private Function CreatePurchaseOrderReport(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        If ParameterDictionary IsNot Nothing AndAlso
                ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

            XtraReport.DataSource = ParameterDictionary("DataSource")

        Else

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadPurchaseOrderData(DbContext, ParameterDictionary)

        End If

        If ParameterDictionary.ContainsKey("DefaultLocation") Then

            XtraReport.DefaultLocation = ParameterDictionary("DefaultLocation")

        End If

        If ParameterDictionary.ContainsKey("PrintDefaults") Then

            XtraReport.PrintDefaults = ParameterDictionary("PrintDefaults")

        End If

        If ParameterDictionary.ContainsKey("FooterAboveSignature") Then

            XtraReport.FooterAboveSignature = ParameterDictionary("FooterAboveSignature")

        End If

        If ParameterDictionary.ContainsKey("UsePrintedDate") Then

            XtraReport.UsePrintedDate = ParameterDictionary("UsePrintedDate")

        End If

        If ParameterDictionary.ContainsKey("ClientName") Then

            XtraReport.Clientname = ParameterDictionary("ClientName")

        End If

        XtraReport.DisplayName = "Purchase Order"

        CreatePurchaseOrderReport = XtraReport

    End Function
    Private Function CreateVendorDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorDetailReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 001 - Detail"

        CreateVendorDetailReport = XtraReport

    End Function
    Private Function CreateVendorContractReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorContractReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorContractReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 008 - Vendor Contract"

        CreateVendorContractReport = XtraReport

    End Function
    Private Function CreateGeneralLedgerReport(ByVal Session As AdvantageFramework.Security.Session, ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        Select Case ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Report.ToString)

            Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape,
                 AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait

                XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.GLDetailByAccountReport

                With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.GLDetailByAccountReport)

                    .Session = Session

                    .DataSource = AdvantageFramework.Reporting.Database.Procedures.GeneralLedgerDetailByAccountReport.Load(ReportingDbContext, ParameterDictionary).ToList

                    .FromPostPeriod = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                    .ToPostPeriod = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                    If ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.Report.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape Then

                        .Landscape = True

                    End If

                    .DisplayName = "General Ledger Report"

                End With

            Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TrialBalance

                XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.TrialBalanceReport

                With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.TrialBalanceReport)

                    .Session = Session

                    .DataSource = AdvantageFramework.Reporting.Database.Procedures.TrialBalanceReport.Load(ReportingDbContext, ParameterDictionary).ToList

                    .EndingPostPeriod = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)

                    .DisplayName = "Trial Balance Report"

                End With

            Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByTransaction

                XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.DetailGeneralLedgerByTransactionReport

                With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.DetailGeneralLedgerByTransactionReport)

                    .Session = Session

                    .DataSource = AdvantageFramework.Reporting.Database.Procedures.GeneralLedgerDetailByAccountReport.Load(ReportingDbContext, ParameterDictionary).ToList

                    .FromPostPeriod = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                    .ToPostPeriod = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                    .DisplayName = "Detail General Ledger By Transaction Report"

                End With

                'Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TransactionsByYearAndPeriod

                '    XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByYearAndPeriod

                '    With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByYearAndPeriod)

                '        .Session = Session

                '        .DataSource = AdvantageFramework.Reporting.LoadGLCrossOfficeData(ReportingDbContext, ParameterDictionary)

                '        .start_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                '        .end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                '        .DisplayName = "Transaction By Year and Period Report"

                '    End With

                'Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TransactionsByYear

                '    XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByYear

                '    With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByYear)

                '        .Session = Session

                '        .DataSource = AdvantageFramework.Reporting.LoadGLCrossOfficeData(ReportingDbContext, ParameterDictionary)

                '        .start_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                '        .end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                '        .DisplayName = "Transaction By Year Report"

                '    End With

                'Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TransactionsByPeriodAndAccount

                '    XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByPeriodAndAccount

                '    With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByPeriodAndAccount)

                '        .Session = Session

                '        .DataSource = AdvantageFramework.Reporting.LoadGLCrossOfficeData(ReportingDbContext, ParameterDictionary)

                '        .start_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                '        .end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                '        .DisplayName = "Transaction By Period and Account Report"

                '    End With

                'Case AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TransactionsByPeriod

                '    XtraReport = New AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByPeriod

                '    With DirectCast(XtraReport, AdvantageFramework.Reporting.Reports.GeneralLedger.CrossOffice.TransactionsByPeriod)

                '        .Session = Session

                '        .DataSource = AdvantageFramework.Reporting.LoadGLCrossOfficeData(ReportingDbContext, ParameterDictionary)

                '        .start_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.StartingPostPeriodCode.ToString)
                '        .end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerReportParameters.EndingPostPeriodCode.ToString)

                '        .DisplayName = "Transaction By Period Report"

                '    End With

        End Select

        CreateGeneralLedgerReport = XtraReport

    End Function
    Private Function CreateVendorDetailWithContactsReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorDetailWithContactsReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorDetailWithContactsReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 002 - Detail - Vendor Contacts"

        CreateVendorDetailWithContactsReport = XtraReport

    End Function
    Private Function CreateVendorDetailMediaReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorDetailMediaReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorDetailMediaReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 003 - Detail - Media"

        CreateVendorDetailMediaReport = XtraReport

    End Function
    Private Function CreateVendorDetailProductionReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorDetailProductionReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorDetailProductionReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 004 - Detail - Production"

        CreateVendorDetailProductionReport = XtraReport

    End Function
    Private Function CreateVendorSummaryListReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorSummaryListReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorSummaryListReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 005 - Summary - Vendor List"

        CreateVendorSummaryListReport = XtraReport

    End Function
    Private Function CreateVendorSummaryListWithPayToEEOCStatusReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                      ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorSummaryListWithPayToEEOCReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorSummaryListWithPayToEEOCReport

        XtraReport.Session = Session

        XtraReport.SortedBy = ParameterDictionary("SortedBy")

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 006 - Summary - Vendor List with Pay To - EEOC"

        CreateVendorSummaryListWithPayToEEOCStatusReport = XtraReport

    End Function
    Private Function CreateVendorHistoryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Vendor.VendorHistoryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Vendor.VendorHistoryReport

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Vendor Report - 007 - History Report"

        CreateVendorHistoryReport = XtraReport

    End Function
    Private Function CreatePurchaseOrderApprovalRuleReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                           ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Maintenance.PurchaseOrderApprovalRuleReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Maintenance.PurchaseOrderApprovalRuleReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name

            End If

        End Using

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "Purchase Order Approval Report"

        CreatePurchaseOrderApprovalRuleReport = XtraReport

    End Function
    Private Function CreateEmployeeTimesheetReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeTimesheetReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeTimesheetReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name
                XtraReport.UseProductCategory = CBool(Agency.EnableProductCategory.GetValueOrDefault(0))

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ExcludeEmployeeSignature = ParameterDictionary("ExcludeEmployeeSignature")
        XtraReport.WeekOfDate = ParameterDictionary("WeekOfDate")
        XtraReport.SortBy = ParameterDictionary("SortBy")

        XtraReport.DisplayName = "Employee Timesheet"

        CreateEmployeeTimesheetReport = XtraReport

    End Function
    Private Function CreateEmployeeTimesheetDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                         ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.EmployeeTimesheetDetailReport = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.EmployeeTimesheetDetailReport

        XtraReport.Session = Session

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                XtraReport.AgencyName = Agency.Name
                XtraReport.UseProductCategory = CBool(Agency.EnableProductCategory.GetValueOrDefault(0))

            End If

        End Using

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ExcludeEmployeeSignature = ParameterDictionary("ExcludeEmployeeSignature")

        XtraReport.DisplayName = "Employee Timesheet"

        CreateEmployeeTimesheetDetailReport = XtraReport

    End Function
    Private Function CreateClientPLGrossIncomeSummaryByClientDivisionProductReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryByClientDivisionProduct = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryByClientDivisionProduct

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientPLGrossIncomeSummaryByClientDivisionProductReport = XtraReport

    End Function
    Private Function CreateClientPLGrossIncomeSummaryByClientDivisionProductSalesClassReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryByClientDivisionProductSalesClass = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryByClientDivisionProductSalesClass

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientPLGrossIncomeSummaryByClientDivisionProductSalesClassReport = XtraReport

    End Function
    Private Function CreateClientPLGrossIncomeSummaryBySalesClassClientReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryBySalesClassClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummaryBySalesClassClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientPLGrossIncomeSummaryBySalesClassClientReport = XtraReport

    End Function
    Private Function CreateClientPLGrossIncomeSummaryByClientDivisionProductPostPeriodReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientDivisionProductPostPeriod = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientDivisionProductPostPeriod

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientPLGrossIncomeSummaryByClientDivisionProductPostPeriodReport = XtraReport

    End Function
    Private Function CreateClientSummaryGPofBillingReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryGPofBilling = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryGPofBilling

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientSummaryGPofBillingReport = XtraReport

    End Function
    Private Function CreateClientSummaryExtendedGPofGI(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                       ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryExtendedGPofGI = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryExtendedGPofGI

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientSummaryExtendedGPofGI = XtraReport

    End Function
    Private Function CreateSummaryByPeriodMediaSeparate(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByPeriodMediaSeparate = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByPeriodMediaSeparate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateSummaryByPeriodMediaSeparate = XtraReport

    End Function
    Private Function CreateGrossIncomeSummarybyCDPSCYTDMargin(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCYTDMargin = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCYTDMargin

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossIncomeSummarybyCDPSCYTDMargin = XtraReport

    End Function
    Private Function CreateGrossIncomeSummarybyClientSCYTDBudget(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCYTDBudget = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCYTDBudget

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossIncomeSummarybyClientSCYTDBudget = XtraReport

    End Function
    Private Function CreateGrossIncomeSummarybyClientYTDBudget(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPYTDBudget = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPYTDBudget

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossIncomeSummarybyClientYTDBudget = XtraReport

    End Function
    Private Function CreateGrossIncomebyClient12PeriodWtihBudget(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyClient12PeriodBudget = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyClient12PeriodBudget

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossIncomebyClient12PeriodWtihBudget = XtraReport

    End Function
    Private Function CreateGrossIncomeSummarybyCDPSCCurrentYTDBudget(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCCurrentYTDBudget = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossIncomeSummarybyCDPSCCurrentYTDBudget

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossIncomeSummarybyCDPSCCurrentYTDBudget = XtraReport

    End Function
    Private Function CreateSummaryByClientwithBudgetIncomeCostsHours(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientwithBudgetIncomeCostsHours = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientwithBudgetIncomeCostsHours

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateSummaryByClientwithBudgetIncomeCostsHours = XtraReport

    End Function
    Private Function CreateClientSummaryGPofTimeIncAndHourlyRate(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                          ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryGPofTimeIncandHourlyRate = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientSummaryGPofTimeIncandHourlyRate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateClientSummaryGPofTimeIncAndHourlyRate = XtraReport

    End Function
    Private Function CreateBillingWorksheetProductionSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                             ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.SummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.SummaryReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

            XtraReport.Parameters.Item("IncludeContingency").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString)
            XtraReport.Parameters.Item("include_non_billable_ap_io_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString)
            XtraReport.Parameters.Item("include_non_billable_time_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString)

        End Using

        CreateBillingWorksheetProductionSummary = XtraReport

    End Function
    Private Function CreateBillingWorksheetMediaSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                        ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.MediaSummaryReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.MediaSummaryReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetMediaDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("brdcast_date1").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastStartDate.ToString)
            XtraReport.Parameters.Item("brdcast_date2").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastEndDate.ToString)

            XtraReport.Parameters.Item("date_to_use").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.DateToUse.ToString)

            XtraReport.Parameters.Item("job_media_date_from").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateFrom.ToString)
            XtraReport.Parameters.Item("job_media_date_to").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateTo.ToString)

            XtraReport.Parameters.Item("m_start_date").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaStartDate.ToString)
            XtraReport.Parameters.Item("m_cutoff_date").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaEndDate.ToString)

        End Using

        CreateBillingWorksheetMediaSummary = XtraReport

    End Function
    Private Function CreateJobProfitabilitySummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilitySummary = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilitySummary

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

            End Using
        End Using

        CreateJobProfitabilitySummary = XtraReport

    End Function
    Private Function CreateJobProfitabilitySummaryWithOverhead(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilitySummarywithOverhead = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilitySummarywithOverhead

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

            End Using
        End Using

        CreateJobProfitabilitySummaryWithOverhead = XtraReport

    End Function
    Private Function CreateJobProfitabilityDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilityDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.JobProfitabilityDetail

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

            End Using
        End Using

        CreateJobProfitabilityDetail = XtraReport

    End Function
    Private Function CreateSummaryByClientSalesClassCurrentYTDBillingIncome(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientSalesClassCurrentYTDBillingIncome = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.SummaryByClientSalesClassCurrentYTDBillingIncome

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateSummaryByClientSalesClassCurrentYTDBillingIncome = XtraReport

    End Function
    Private Function CreateGrossBillingbyClient12PeriodwithBudget(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossBillingbyClient12PeriodwithBudget = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.GrossBillingbyClient12PeriodwithBudget

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.Database.Procedures.ClientPLComplexType.Load(ReportingDbContext, ParameterDictionary).ToList

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
            If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
            End If

        End Using

        CreateGrossBillingbyClient12PeriodwithBudget = XtraReport

    End Function
    Private Function CreateBillingWorksheetProductionUnbilledDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                    ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

            XtraReport.Parameters.Item("IncludeContingency").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString)
            XtraReport.Parameters.Item("include_non_billable_ap_io_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString)
            XtraReport.Parameters.Item("include_non_billable_time_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString)

        End Using

        CreateBillingWorksheetProductionUnbilledDetail = XtraReport

    End Function
    Private Function CreateBillingApprovalBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                    ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.BillingApprovalBatchReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.BillingApprovalBatchReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

        End Using

        CreateBillingApprovalBatchReport = XtraReport

    End Function
    Private Function CreateBillingWorksheetProductionUnbilledDetailwithComments(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                    ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailwithCommentsReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailwithCommentsReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

            XtraReport.Parameters.Item("IncludeContingency").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString)
            XtraReport.Parameters.Item("include_non_billable_ap_io_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString)
            XtraReport.Parameters.Item("include_non_billable_time_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString)

        End Using

        CreateBillingWorksheetProductionUnbilledDetailwithComments = XtraReport

    End Function
    Private Function CreateBillingWorksheetProductionUnbilledDetailV2(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                                    ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailReportV2 = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.UnbilledDetailReportV2

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

            XtraReport.Parameters.Item("IncludeContingency").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString)
            XtraReport.Parameters.Item("include_non_billable_ap_io_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString)
            XtraReport.Parameters.Item("include_non_billable_time_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString)

        End Using

        CreateBillingWorksheetProductionUnbilledDetailV2 = XtraReport

    End Function
    Private Function CreateMediaCurrentStatusDetailbyTypeClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaCurrentStatusDetailbyTypeClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaCurrentStatusDetailbyTypeClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaCurrentStatusDetailbyTypeClient = XtraReport

    End Function
    Private Function CreateMediaReconcilation(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaReconciliation = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaReconciliation

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)
            XtraReport.standard.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.Standard.ToString)

        End Using

        CreateMediaReconcilation = XtraReport

    End Function
    Private Function CreateMediaBillingandPaymentSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaBillingandPaymentSummary = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaBillingandPaymentSummary

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaBillingandPaymentSummary = XtraReport

    End Function
    Private Function CreateClientProfitandLossDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetail

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
                If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                    XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
                End If

            End Using
        End Using

        CreateClientProfitandLossDetail = XtraReport

    End Function
    Private Function CreateClientProfitandLossDetailSalesClass(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetailSalesClass = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetailSalesClass

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

            End Using
        End Using

        CreateClientProfitandLossDetailSalesClass = XtraReport

    End Function
    Private Function CreateClientProfitandLossDetailDirectSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetailDirectSummary = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ClientPL.ClientProfitandLossDetailDirectSummary

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadClientPLDetailReportData(DbContext, ReportingDbContext, ParameterDictionary).ToList

                XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)
                XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)
                If ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = "0" AndAlso ParameterDictionary("SelectedOfficeDescriptions") IsNot Nothing Then
                    XtraReport.OfficeFilter.Value = Join(ParameterDictionary("SelectedOfficeDescriptions").ToArray, ", ")
                End If

            End Using
        End Using

        CreateClientProfitandLossDetailDirectSummary = XtraReport

    End Function
    Private Function CreateMediaBillingandPaymentDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaBillingandPaymentDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaBillingandPaymentDetail

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaBillingandPaymentDetail = XtraReport

    End Function
    Private Function CreateSalesJournal(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

        End Using

        CreateSalesJournal = XtraReport

    End Function
    Private Function CreateSalesJournalExpanded(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalExpanded = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalExpanded

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

        End Using

        CreateSalesJournalExpanded = XtraReport

    End Function
    Private Function CreateSalesJournalSummaryByInvoice(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalSummaryByInvoice = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalSummaryByInvoice

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)
            XtraReport.PeriodType.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.PeriodType.ToString)

        End Using

        CreateSalesJournalSummaryByInvoice = XtraReport

    End Function
    Private Function CreateSalesJournal12PeriodByType(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal12PeriodByTypeJob = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal12PeriodByTypeJob

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

        End Using

        CreateSalesJournal12PeriodByType = XtraReport

    End Function
    Private Function CreateSalesJournal12PeriodByTypeNoTax(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal12PeriodByTypeJobNoTax = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournal12PeriodByTypeJobNoTax

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

        End Using

        CreateSalesJournal12PeriodByTypeNoTax = XtraReport

    End Function
    Private Function CreateSalesJournalTaxableSalesDetailByClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalTaxableSalesDetailByClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.SalesJournal.SalesJournalTaxableSalesDetailByClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadSalesJournalData(ReportingDbContext, ParameterDictionary)

            XtraReport.StartPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.StartingPostPeriodCode.ToString)
            XtraReport.EndPeriod.Value = ParameterDictionary(AdvantageFramework.Reporting.SalesJournalParameters.EndingPostPeriodCode.ToString)

        End Using

        CreateSalesJournalTaxableSalesDetailByClient = XtraReport

    End Function
    Private Function CreatePurchaseOrderDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderDetail

        Using ReportingDbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadOpenPurchaseOrderDetail(ReportingDbContext, ParameterDictionary)

            XtraReport.StartingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POStartDate.ToString)
            XtraReport.EndingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.OpenPurchaseOrderDetailInitialCriteria.POEndDate.ToString)

        End Using

        CreatePurchaseOrderDetail = XtraReport

    End Function
    Private Function CreateDirectTimeReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Employee.DirectTime.EmployeeDirectTimeReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Employee.DirectTime.EmployeeDirectTimeReport

        Using ReportingDbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Database.Procedures.DirectTime.LoadByEmployee(ReportingDbContext, ParameterDictionary("DirectTimeStartDate"), ParameterDictionary("DirectTimeEndDate"), ParameterDictionary("DirectTimeEmployeeCode"), ParameterDictionary("DirectTimeClientCode"), ParameterDictionary("DirectTimeJobNumber"), ParameterDictionary("DirectTimeComponentNumber"), Session.UserCode)

            XtraReport.PDFPageBreak = ParameterDictionary("DirectTimePageBreak")

        End Using

        CreateDirectTimeReport = XtraReport

    End Function
    Private Function CreateDirectTimeByClientSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        If ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.IncludeMarkup.ToString) = 0 Then
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientSummary

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryReport = XtraReport
        Else
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientSummaryMarkUpDown

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryReport = XtraReport
        End If



    End Function
    Private Function CreateDirectTimeByClientSummaryJobDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        If ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.IncludeMarkup.ToString) = 0 Then
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientJobDetail

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryJobDetailReport = XtraReport
        Else
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientJobDetailMarkUpDown

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryJobDetailReport = XtraReport
        End If



    End Function
    Private Function CreateDirectTimeByClientSummaryEmployeeDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        If ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.IncludeMarkup.ToString) = 0 Then
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientEmployeeDetail

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryEmployeeDetailReport = XtraReport
        Else
            Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectTime.DirectTimeClientEmployeeDetailMarkUpDown

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                XtraReport.DataSource = LoadDirectTime(ReportingDbContext, ParameterDictionary("DateType"), ParameterDictionary("FromDate"), ParameterDictionary("ToDate"), False, ParameterDictionary)
                XtraReport.START_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString)
                XtraReport.END_DATE.Value = ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString)

            End Using

            CreateDirectTimeByClientSummaryEmployeeDetailReport = XtraReport
        End If



    End Function
    Private Function CreateBillingWorksheetMediaByOrderDescription(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                                   ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.MediaByOrderDescriptionReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.MediaByOrderDescriptionReport

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetMediaDetail(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("brdcast_date1").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastStartDate.ToString)
            XtraReport.Parameters.Item("brdcast_date2").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastEndDate.ToString)

            XtraReport.Parameters.Item("date_to_use").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.DateToUse.ToString)

            XtraReport.Parameters.Item("job_media_date_from").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateFrom.ToString)
            XtraReport.Parameters.Item("job_media_date_to").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateTo.ToString)

            XtraReport.Parameters.Item("m_start_date").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaStartDate.ToString)
            XtraReport.Parameters.Item("m_cutoff_date").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaEndDate.ToString)

        End Using

        CreateBillingWorksheetMediaByOrderDescription = XtraReport

    End Function
    Private Function CreateMediaReconciliationReportWithBilled(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaReconciliationReportWithBilled = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaReconciliationReportWithBilled

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaReconciliationReportWithBilled = XtraReport

    End Function
    Private Function CreateMediaReconciliationReportWithBilledbyClientandType(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaReconciliationwithBilledbyClientandType = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaReconciliationwithBilledbyClientandType

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaReconciliationReportWithBilledbyClientandType = XtraReport

    End Function
    Private Function CreateMediaOrdersUnbilledWithoutAPByMonth(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaOrdersUnbilledWithoutAPByMonth = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaOrdersUnbilledWithoutAPByMonth

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaOrdersUnbilledWithoutAPByMonth = XtraReport

    End Function
    Private Function CreateMediaOrdersUnbilledWithoutAPByOrder(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaOrdersUnbilledWithoutAPByOrder = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaOrdersUnbilledWithoutAPByOrder

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaOrdersUnbilledWithoutAPByOrder = XtraReport

    End Function
    Private Function CreateMediaActivitySummaryByType(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaActivitySummarybyType = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaActivitySummarybyType

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaActivitySummaryByType = XtraReport

    End Function
    Private Function CreateMediaActivityDetailByType(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaActivityDetailbyType = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaActivityDetailbyType

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaActivityDetailByType = XtraReport

    End Function
    Private Function CreateMediaActivityDetailByCampaign(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaActivityDetailbyCampaignType = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaActivityDetailbyCampaignType

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaActivityDetailByCampaign = XtraReport

    End Function
    Private Function CreateMediaOrdersBilledWithoutAPByTypeClient(Session As AdvantageFramework.Security.Session, Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaOrdersBilledWithoutAPByTypeClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaOrdersBilledWithoutAPByTypeClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMediaCurrentStatusSummaryReport(ReportingDbContext, ParameterDictionary)

            XtraReport.order_status.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.OrderStatus.ToString)
            XtraReport.start_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString)
            XtraReport.start_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartMonth.ToString)
            XtraReport.start_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartYear.ToString)
            XtraReport.end_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString)
            XtraReport.end_month.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndMonth.ToString)
            XtraReport.end_year.Value = ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndYear.ToString)

        End Using

        CreateMediaOrdersBilledWithoutAPByTypeClient = XtraReport

    End Function
    Public Function CreateReport(ByVal Session As AdvantageFramework.Security.Session,
                                 ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                 ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                 ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29 Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31 Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6 Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7 Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8 Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp Then

                    XtraReport = CreateJobDetailAnalysisReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        XtraReport = CreateSecurityReport(Session, Report, ParameterDictionary)

                    End Using

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountExecutiveUpdate Then

                    XtraReport = CreateAccountExecutiveUpdateReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeAddressListing Then

                    XtraReport = CreateEmployeeAddressListingReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeDetailListing Then

                    XtraReport = CreateEmployeeDetailListingReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeDetailListingWithHR Then

                    XtraReport = CreateEmployeeDetailListingWithHRReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationReport Then

                    XtraReport = CreateServiceFeeReconciliationReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ServiceFeeReconciliationDetailReport Then

                    XtraReport = CreateServiceFeeReconciliationDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BankReport Then

                    XtraReport = CreateBankReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientReport Then

                    XtraReport = CreateClientReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.UserDefined Then

                    XtraReport = CreateUserDefinedReport(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EstimateReport Then

                    XtraReport = CreateUserDefinedEstimateReport(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        XtraReport = CreateEmployeeSummaryReport(Session, Report, ParameterDictionary)

                    End Using

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        XtraReport = CreateGroupSummaryReport(Session, Report, ParameterDictionary)

                    End Using

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        XtraReport = CreateGroupSecurityReport(Session, Report, ParameterDictionary)

                    End Using

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummary Then

                    XtraReport = CreateAccountsPayableBatchSummaryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport Then

                    XtraReport = CreateEmployeeExpenseReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.TaskTemplates Then

                    XtraReport = CreateTaskTemplateReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.TaskTemplatesWithRoles Then

                    XtraReport = CreateTaskTemplateWithRolesReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchDetail Then

                    XtraReport = CreateAccountsPayableBatchDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorDetail Then

                    XtraReport = CreateVendorDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorDetailVendorContacts Then

                    XtraReport = CreateVendorDetailWithContactsReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorDetailMedia Then

                    XtraReport = CreateVendorDetailMediaReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorDetailProduction Then

                    XtraReport = CreateVendorDetailProductionReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorSummaryVendorList Then

                    XtraReport = CreateVendorSummaryListReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorSummaryVendorListWithPayToEEOC Then

                    XtraReport = CreateVendorSummaryListWithPayToEEOCStatusReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorHistoryReport Then

                    XtraReport = CreateVendorHistoryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.PurchaseOrderApprovalRuleReport Then

                    XtraReport = CreatePurchaseOrderApprovalRuleReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountPayableRecurBatch Then

                    XtraReport = CreateAccountsPayableRecurBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.OfficeAndDepartmentCrossReference Then

                    XtraReport = CreateOfficeAndDepartmentCrossReferenceReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GLAccountGroup Then

                    XtraReport = CreateGLAccountGroupReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GLAccountGroup Then

                    XtraReport = CreateGLAccountGroupReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GLAccountAllocation Then

                    XtraReport = CreateGLAccountAllocationReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientDetail Then

                    XtraReport = CreateClientDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.DivisionDetail Then

                    XtraReport = CreateDivisionDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductDetail Then

                    XtraReport = CreateProductDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientContractAndOpportunityDetail Then

                    XtraReport = CreateClientContractOpportunityDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CRMDetailedInformation Then

                    XtraReport = CreateCRMDetailedInformationReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport Then

                    XtraReport = CreatePurchaseOrderReport(Session, DbContext, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.Standard1099 Then

                    XtraReport = CreateStandard1099Report(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.Standard1099Form Then

                    XtraReport = CreateStandard1099FormReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.Summary1099AllVendors Then

                    XtraReport = CreateSummary1099AllVendorsReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.Detail1099WithDisbursement Then

                    XtraReport = CreateDetail1099WithDisbursementReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientCashReceiptBatchReport Then

                    XtraReport = CreateClientCashReceiptBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeTimesheetReport Then

                    XtraReport = CreateEmployeeTimesheetReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeTimesheetDetailReport Then

                    XtraReport = CreateEmployeeTimesheetDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountReceivableImportBatch Then

                    XtraReport = CreateAccountReceivableImportBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientCashReceiptBatchSummaryReport Then

                    XtraReport = CreateClientCashReceiptBatchSummaryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchDetailReport Then

                    XtraReport = CreateClientInvoiceBatchDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceBatchSummaryReport Then

                    XtraReport = CreateClientInvoiceBatchSummaryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountPayableImportExpenseReport Then

                    XtraReport = CreateAccountPayableImportExpenseReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia Then

                    XtraReport = CreateAuthorizationToBuyDigitalMedia(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.EmployeeRateHistory Then

                    XtraReport = CreateEmployeeRateHistoryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMediaForm Then

                    XtraReport = CreateAuthorizationToBuyDigitalMediaForm(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.IncomeOnlyBatchReport Then

                    XtraReport = CreateIncomeOnlyBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientInvoiceReport Then

                    XtraReport = CreateClientInvoiceReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.OneQuotePerPage Then

                    XtraReport = CreateEstimate(Session, ParameterDictionary("EstimateQuote"), ParameterDictionary("PrintDefaults"), ParameterDictionary("EstimateFormat"))

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.OtherCashReceiptBatchReport Then

                    XtraReport = CreateOtherCashReceiptBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.IncomeOnlyBatchSummaryReport Then

                    XtraReport = CreateIncomeOnlyBatchSummaryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct Then

                    XtraReport = CreateClientPLGrossIncomeSummaryByClientDivisionProductReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass Then

                    XtraReport = CreateClientPLGrossIncomeSummaryByClientDivisionProductSalesClassReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryBySalesClassClient Then

                    XtraReport = CreateClientPLGrossIncomeSummaryBySalesClassClientReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod Then

                    XtraReport = CreateClientPLGrossIncomeSummaryByClientDivisionProductPostPeriodReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofBilling Then

                    XtraReport = CreateClientSummaryGPofBillingReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryExtendedGPofGI Then

                    XtraReport = CreateClientSummaryExtendedGPofGI(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SummaryByPeriodMediaSeparate Then

                    XtraReport = CreateSummaryByPeriodMediaSeparate(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyCDPSCYTDMargin Then

                    XtraReport = CreateGrossIncomeSummarybyCDPSCYTDMargin(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionSummary Then

                    XtraReport = CreateBillingWorksheetProductionSummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetMediaSummary Then

                    XtraReport = CreateBillingWorksheetMediaSummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummary Then

                    XtraReport = CreateJobProfitabilitySummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilitySummaryWithOverhead Then

                    XtraReport = CreateJobProfitabilitySummaryWithOverhead(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.JobProfitabilityDetail Then

                    XtraReport = CreateJobProfitabilityDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCYTDBudget Then

                    XtraReport = CreateGrossIncomeSummarybyClientSCYTDBudget(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientSummaryGPofTimeIncAndHourlyRate Then

                    XtraReport = CreateClientSummaryGPofTimeIncAndHourlyRate(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientYTDBudget Then

                    XtraReport = CreateGrossIncomeSummarybyClientYTDBudget(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomebyClient12PeriodWtihBudget Then

                    XtraReport = CreateGrossIncomebyClient12PeriodWtihBudget(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossIncomeSummarybyClientSCCurrentYTDBudget Then

                    XtraReport = CreateGrossIncomeSummarybyCDPSCCurrentYTDBudget(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientwithBudgetIncomeCostsHours Then

                    XtraReport = CreateSummaryByClientwithBudgetIncomeCostsHours(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SummaryByClientSalesClassCurrentYTDBillingIncome Then

                    XtraReport = CreateSummaryByClientSalesClassCurrentYTDBillingIncome(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GrossBillingByClient12PeriodWithBudget Then

                    XtraReport = CreateGrossBillingbyClient12PeriodwithBudget(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetail Then

                    XtraReport = CreateBillingWorksheetProductionUnbilledDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.VendorContract Then

                    XtraReport = CreateVendorContractReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetail Then

                    XtraReport = CreateClientProfitandLossDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailSalesClass Then

                    XtraReport = CreateClientProfitandLossDetailSalesClass(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ClientProfitAndLossDetailDirectSummary Then

                    XtraReport = CreateClientProfitandLossDetailDirectSummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.GeneralLedgerReport Then

                    XtraReport = CreateGeneralLedgerReport(Session, ReportingDbContext, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaCurrentStatusDetailbyTypeClient Then

                    XtraReport = CreateMediaCurrentStatusDetailbyTypeClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliation Then

                    XtraReport = CreateMediaReconcilation(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaBillingandPaymentSummary Then

                    XtraReport = CreateMediaBillingandPaymentSummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaBillingandPaymentDetail Then

                    XtraReport = CreateMediaBillingandPaymentDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournal Then

                    XtraReport = CreateSalesJournal(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournalExpanded Then

                    XtraReport = CreateSalesJournalExpanded(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournalSummaryByInvoice Then

                    XtraReport = CreateSalesJournalSummaryByInvoice(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournal12PeriodByTypeJob Then

                    XtraReport = CreateSalesJournal12PeriodByType(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournal12PeriodByTypeJobNoTax Then

                    XtraReport = CreateSalesJournal12PeriodByTypeNoTax(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.SalesJournalTaxableSalesDetailByClient Then

                    XtraReport = CreateSalesJournalTaxableSalesDetailByClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountPayableBatchSummaryDataEntryOrder Then

                    XtraReport = CreateAccountPayableBatchSummaryDataEntryOrderReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.PurchaseOrderDetail Then

                    XtraReport = CreatePurchaseOrderDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.DirectTime Then

                    XtraReport = CreateDirectTimeReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetMediaByOrderDescription Then

                    XtraReport = CreateBillingWorksheetMediaByOrderDescription(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliationReportWithBilled Then

                    XtraReport = CreateMediaReconciliationReportWithBilled(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersUnbilledWithoutAPByMonth Then

                    XtraReport = CreateMediaOrdersUnbilledWithoutAPByMonth(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersUnbilledWithoutAPByOrder Then

                    XtraReport = CreateMediaOrdersUnbilledWithoutAPByOrder(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.DirectTimebyClientSummary Then

                    XtraReport = CreateDirectTimeByClientSummaryReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.DirectTimebyClientSummaryJobDetail Then

                    XtraReport = CreateDirectTimeByClientSummaryJobDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.DirectTimebyClientSummaryEmployeeDetail Then

                    XtraReport = CreateDirectTimeByClientSummaryEmployeeDetailReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaActivitySummaryByType Then

                    XtraReport = CreateMediaActivitySummaryByType(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaActivityDetailByType Then

                    XtraReport = CreateMediaActivityDetailByType(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaActivityDetailByCampaign Then

                    XtraReport = CreateMediaActivityDetailByCampaign(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingApprovalBatch Then

                    XtraReport = CreateBillingApprovalBatchReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailWithComments Then

                    XtraReport = CreateBillingWorksheetProductionUnbilledDetailwithComments(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionUnbilledDetailV2 Then

                    XtraReport = CreateBillingWorksheetProductionUnbilledDetailV2(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.HoursWorkedSummaryByDate Then

                    XtraReport = CreateHoursWorkedSummaryByDateReport(Session, Report, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.HoursWorkedSummaryByEmployee Then

                    XtraReport = CreateHoursWorkedSummaryByEmployeeReport(Session, Report, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.HoursWorkedDetailByDate Then

                    XtraReport = CreateHoursWorkedDetailByDateReport(Session, Report, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.HoursWorkedDetailByEmployee Then

                    XtraReport = CreateHoursWorkedDetailByEmployeeReport(Session, Report, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MarketScheduleWeeklyDetail Then

                    XtraReport = CreateMarketScheduleWeeklyDetailReport(Session, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BillingWorksheetProductionSummaryV2 Then

                    XtraReport = CreateBillingWorksheetProductionSummaryV2(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaReconciliationReportWithBilledByClientAndType Then

                    XtraReport = CreateMediaReconciliationReportWithBilledbyClientandType(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNet Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidNetIncludeNonbillableCost Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNet Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidNetIncludeNonbillableCost Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGross Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionSummaryARPaidGrossIncludeNonbillableCost Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGross Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.CashManagementProductionDetailARPaidGrossIncludeNonbillableCost Then

                    XtraReport = CreateCashManagementReport(DbContext, ReportingDbContext, Report, ParameterDictionary, Session)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPSummaryByClientBillingAPBalance Then

                    XtraReport = CreateMediaWIPAgedSummaryByClientBillingAPBalance(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPDetailByGLAccount Then

                    XtraReport = CreateMediaWIPDetailByGLAccount(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPSummaryByVendorBalanceOnly Then

                    XtraReport = CreateMediaWIPSummaryByVendorBalanceOnly(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPSummaryByClientBalanceOnly Then

                    XtraReport = CreateMediaWIPSummaryByClientBalanceOnly(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersWithZeroBalance Then

                    XtraReport = CreateMediaOrdersWithZeroBalance(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPSummaryByClientPOBalanceOnly Then

                    XtraReport = CreateMediaWIPSummaryByClientPOBalanceOnly(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPAgedSummaryByVendor Then

                    XtraReport = CreateMediaWIPAgedSummaryByVendor(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPAgedSummaryByClient Then

                    XtraReport = CreateMediaWIPAgedSummaryByClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPAgedSummaryByClient Then

                    XtraReport = CreateProductionWIPAgedSummaryByClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaWIPAgedSummaryByMediaType Then

                    XtraReport = CreateMediaWIPAgedSummaryByMediaType(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccruedAccountsPayableByClientVendorPeriod Then

                    XtraReport = CreateAccruedAccountsPayableByClientVendorPeriod(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.MediaOrdersBilledWithoutAPByTypeClient Then

                    XtraReport = CreateMediaOrdersBilledWithoutAPByTypeClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedSummarybyClient Then

                    XtraReport = CreateAccountsReceivableAgedSummarybyClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedSummarybyProduct Then

                    XtraReport = CreateAccountsReceivableAgedSummarybyProduct(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedDetailbyClient Then

                    XtraReport = CreateAccountsReceivableAgedDetailbyClient(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedDetailbyProduct Then

                    XtraReport = CreateAccountsReceivableAgedDetailbyProduct(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedwithDisbursementDetail Then

                    XtraReport = CreateAccountsReceivableAgedwithDisbursementDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsReceivableAgedDetailbyClientNoGL Then

                    XtraReport = CreateAccountsReceivableAgedDetailbyClientNoGL(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.UpdatedRateRequestReport Then

                    XtraReport = CreateUpdatedRateRequestReport(Session, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPDetailbyJobVendorOnly Then

                    XtraReport = CreateProductionWIPDetailbyJobVendorOnly(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobWithEstimate Then

                    XtraReport = CreateProductionWIPSummarybyJobwithEstimate(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobWithRecIncome Then

                    XtraReport = CreateProductionWIPSummarybyJobwithRecIncome(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobWithPayments Then

                    XtraReport = CreateProductionWIPSummarybyJobwithPayments(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByVendorWithPayments Then

                    XtraReport = CreateProductionWIPSummarybyVendorwithPayments(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPAgedSummaryByJob Then

                    XtraReport = CreateProductionWIPAgedSummarybyJob(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPAgedSummaryByJobWithEstimate Then

                    XtraReport = CreateProductionWIPAgedSummarybyJobwithEstimate(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPAgedSummaryByJobVendorOnly Then

                    XtraReport = CreateProductionWIPAgedSummarybyJobVendorOnly(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccruedLiabilitySummaryByJobAPLimited Then

                    XtraReport = CreateAccruedLiabilitySummarybyJobAPLimited(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccruedLiabilitySummaryByJobAPPosted Then

                    XtraReport = CreateAccruedLiabilitySummarybyJobAPPosted(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccruedLiabilitySummaryByJobSalesClass Then

                    XtraReport = CreateAccruedLiabilitySummarybyJobandSalesClass(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccruedLiabilitySummaryByJobSalesClassFunction Then

                    XtraReport = CreateAccruedLiabilitySummarybyJobSalesClassFunction(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableDetailwithDaysAged Then

                    XtraReport = CreateAccountsPayableDetailwithDaysAged(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableDisbDetailByInvoiceNumber Then

                    XtraReport = CreateAccountsPayableDisbDetailbyInvoiceNumber(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableDisbDetailByInvoiceDate Then

                    XtraReport = CreateAccountsPayableDisbDetailbyInvoiceDate(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableAgedSummary Then

                    XtraReport = CreateAccountsPayableAgedSummary(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableAgedDetail Then

                    XtraReport = CreateAccountsPayableAgedDetail(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.AccountsPayableAgedDetailNoGL Then

                    XtraReport = CreateAccountsPayableAgedDetailNoGL(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.Standard1099NECForm Then

                    XtraReport = CreateStandard1099NECFormReport(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.TrafficFlightSummaryReport Then

                    XtraReport = CreateTrafficFlightSummaryReport(Session, ParameterDictionary, Criteria, FilterString, From, [To])

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProofingFeedbackSummary Then

                    XtraReport = CreateProofingFeedbackSummary(Session, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.PaymentManagerReport Then

                    XtraReport = CreatePaymentManagerReport(Session, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobDeferredSalesCosIncluded Then

                    XtraReport = CreateProductionWIPSummarybyJobDeferredSalesCosIncluded(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobHoursDeferredSalesCos Then

                    XtraReport = CreateProductionWIPSummarybyJobHoursDeferredSalesCos(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BroadcastInvoiceSummary Then

                    XtraReport = CreateBroadcastInvoiceSummary(Session, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.BroadcastInvoiceDetail Then

                    XtraReport = CreateBroadcastInvoiceDetail(Session, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPAgedSummaryByJobWithAccrLiabPO Then

                    XtraReport = CreateProductionWIPAgedSummarybyJobwithAccrLiabilityPO(Session, Report, ParameterDictionary)

                ElseIf Report = AdvantageFramework.Reporting.ReportTypes.ProductionWIPSummaryByJobEstHrsDefRecSls Then

                    XtraReport = CreateProductionWIPSummaryByJobEstHrsDefRecSls(Session, Report, ParameterDictionary)

                End If

            End Using

        End Using

        CreateReport = XtraReport

    End Function
    Private Function GetAgencyName(ByVal Session As AdvantageFramework.Security.Session) As String

        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim AgencyName As String = ""

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    AgencyName = Agency.Name

                End If

            End Using

        Catch ex As Exception

        Finally
            GetAgencyName = AgencyName
        End Try

    End Function
    Public Function AddReportToDocumentRepository(ByVal Session As AdvantageFramework.Security.Session,
                                                  ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                  ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                  ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date,
                                                  ByVal SaveAsFileName As String, ByVal Description As String, ByVal Keywords As String, ByRef DocumentID As Integer) As Boolean

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Added As Boolean = False
        Dim ErrorMessage As String = Nothing

        Try

            XtraReport = CreateReport(Session, Report, ParameterDictionary, Criteria, FilterString, [From], [To])

            If XtraReport IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    MemoryStream = New System.IO.MemoryStream
                    XtraReport.ExportToPdf(MemoryStream)

                    If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                        If AdvantageFramework.FileSystem.Add(Session, Agency, MemoryStream, SaveAsFileName, Description, Keywords, Session.UserCode, Nothing, Nothing,
                                                             FileSystem.DocumentSource.Alert, Nothing, Nothing, True, DocumentID) Then

                            Added = True

                        End If

                    End If

                    MemoryStream.Dispose()
                    MemoryStream.Close()

                End Using

            End If

        Catch ex As Exception
            Added = False
            XtraReport = Nothing
        Finally
            AddReportToDocumentRepository = Added
        End Try

    End Function
    Public Function SendToPrinter(ByVal XtraReport As DevExpress.XtraReports.UI.XtraReport, ByVal ShowPrintDialog As Boolean, ByVal UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                  ShowPrintStatusDialog As Boolean,
                                  ShowPrintMarginsWarning As Boolean) As Boolean

        'objects
        Dim Printed As Boolean = False

        Try

            XtraReport.ShowPrintMarginsWarning = False
            XtraReport.ShowPrintStatusDialog = ShowPrintStatusDialog

            If XtraReport IsNot Nothing Then

                Using ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(XtraReport)

                    If ShowPrintDialog Then

                        Printed = ReportPrintTool.PrintDialog(UserLookAndFeel).GetValueOrDefault(False)

                    Else

                        ReportPrintTool.Print()
                        Printed = True

                    End If

                End Using

            End If

        Catch ex As Exception
            Printed = False
        End Try

        SendToPrinter = Printed

    End Function
    Public Function CreateCoverSheet(Session As AdvantageFramework.Security.Session,
                                     AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                     InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                     InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                     InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting),
                                     InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes,
                                     IsDraft As Boolean,
                                     CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim CoverSheetInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing

        If Session IsNot Nothing AndAlso AccountReceivableInvoices IsNot Nothing Then

            CoverSheetInvoices = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            For Each AccountReceivableInvoice In AccountReceivableInvoices

                InvoicePrintingMediaSetting = Nothing
                InvoicePrintingSetting = Nothing
                InvoicePrintingComboSetting = Nothing

                If InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                    If String.IsNullOrWhiteSpace(AccountReceivableInvoice.RecordType) = False AndAlso AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                    ElseIf AccountReceivableInvoice.RecordType = "P" OrElse String.IsNullOrWhiteSpace(AccountReceivableInvoice.RecordType) Then

                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                        InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                    End If

                Else

                    If String.IsNullOrWhiteSpace(AccountReceivableInvoice.RecordType) = False AndAlso AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                    ElseIf AccountReceivableInvoice.RecordType = "P" OrElse String.IsNullOrWhiteSpace(AccountReceivableInvoice.RecordType) Then

                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                    ElseIf AccountReceivableInvoice.RecordType = "C" Then

                        InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault
                        InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault
                        InvoicePrintingComboSetting = InvoicePrintingComboSettings.FirstOrDefault

                    End If

                End If

                If InvoicePrintingComboSetting IsNot Nothing AndAlso InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingMediaSetting IsNot Nothing Then

                    If ((InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = False OrElse
                            InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = False OrElse
                            InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = False OrElse
                            InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = False OrElse
                            InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = False OrElse
                            InvoicePrintingMediaSetting.TVShowZeroLineAmounts = False) AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False OrElse
                            (InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False Then

                        CoverSheetInvoices.Add(AccountReceivableInvoice)

                    End If

                ElseIf InvoicePrintingSetting IsNot Nothing Then

                    If (InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False Then

                        CoverSheetInvoices.Add(AccountReceivableInvoice)

                    End If

                ElseIf InvoicePrintingMediaSetting IsNot Nothing Then

                    If (((AccountReceivableInvoice.RecordType = "M" AndAlso InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = False) OrElse
                            (AccountReceivableInvoice.RecordType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = False) OrElse
                            (AccountReceivableInvoice.RecordType = "I" AndAlso InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = False) OrElse
                            (AccountReceivableInvoice.RecordType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = False) OrElse
                            (AccountReceivableInvoice.RecordType = "R" AndAlso InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = False) OrElse
                            (AccountReceivableInvoice.RecordType = "T" AndAlso InvoicePrintingMediaSetting.TVShowZeroLineAmounts = False)) AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False Then

                        CoverSheetInvoices.Add(AccountReceivableInvoice)

                    End If

                End If

            Next

            If CoverSheetInvoices.Count > 0 Then

                If CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default Then

                    Report = New AdvantageFramework.Reporting.Reports.Invoices.CoverSheet

                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheet).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheet).UserCode = Session.UserCode
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheet).AccountReceivableInvoices = CoverSheetInvoices
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheet).IsDraft = IsDraft

                ElseIf CoversheetLayout = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Alternate Then

                    Report = New AdvantageFramework.Reporting.Reports.Invoices.CoverSheetAlternate

                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheetAlternate).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheetAlternate).UserCode = Session.UserCode
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheetAlternate).AccountReceivableInvoices = CoverSheetInvoices
                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CoverSheetAlternate).IsDraft = IsDraft

                End If

            End If

        End If

        CreateCoverSheet = Report

    End Function
    Public Function CreateInvoice(Session As AdvantageFramework.Security.Session, AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice,
                                  InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                                  InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                  InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                                  AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                  OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting,
                                  ShowBackupReport As Boolean, IsDraft As Boolean,
                                  Optional InvoicePrintingType As AdvantageFramework.InvoicePrinting.InvoicePrintingTypes = AdvantageFramework.InvoicePrinting.InvoicePrintingTypes.Preview) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
        Dim MediaOrderLineSelectionInIncomeOnly As Boolean = False
        Dim ComboInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail) = Nothing
        Dim RecordTypes As Generic.List(Of String) = Nothing
        Dim TotalAmount As Decimal = 0

        If AccountReceivableInvoice IsNot Nothing Then

            If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                If InvoicePrintingMediaSetting IsNot Nothing AndAlso AgencyInvoicePrintingMediaSetting IsNot Nothing AndAlso OneTimeInvoicePrintingMediaSetting IsNot Nothing Then

                    If (AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                            (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                            (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                            (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                            (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                            (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False) Then

                        CreateCustomInvoice(Session, New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)({AccountReceivableInvoice}),
                                            New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)({InvoicePrintingSetting}),
                                            New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)({InvoicePrintingMediaSetting}), IsDraft, InvoicePrintingType)

                    Else

                        If (((AccountReceivableInvoice.RecordType = "M" AndAlso InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = False) OrElse
                                (AccountReceivableInvoice.RecordType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = False) OrElse
                                (AccountReceivableInvoice.RecordType = "I" AndAlso InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = False) OrElse
                                (AccountReceivableInvoice.RecordType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = False) OrElse
                                (AccountReceivableInvoice.RecordType = "R" AndAlso InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = False) OrElse
                                (AccountReceivableInvoice.RecordType = "T" AndAlso InvoicePrintingMediaSetting.TVShowZeroLineAmounts = False)) AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False Then

                            If (AccountReceivableInvoice.RecordType = "M" AndAlso InvoicePrintingMediaSetting.MagazineCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.MagazineCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            ElseIf (AccountReceivableInvoice.RecordType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.NewspaperCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            ElseIf (AccountReceivableInvoice.RecordType = "I" AndAlso InvoicePrintingMediaSetting.InternetCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.InternetCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            ElseIf (AccountReceivableInvoice.RecordType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.OutdoorCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            ElseIf (AccountReceivableInvoice.RecordType = "R" AndAlso InvoicePrintingMediaSetting.RadioCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.RadioCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            ElseIf (AccountReceivableInvoice.RecordType = "T" AndAlso InvoicePrintingMediaSetting.TVCustomInvoiceID.GetValueOrDefault(0) > 0) Then

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingMediaSetting.TVCustomInvoiceID.GetValueOrDefault(0))

                                End Using

                            End If

                            If CustomInvoice Is Nothing Then

                                Report = New AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice

                            Else

                                Report = AdvantageFramework.Reporting.Reports.CreateCustomInvoiceReport(CustomInvoice)

                            End If

                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).IsDraft = IsDraft
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).MediaType = AccountReceivableInvoice.RecordType
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).AgencyInvoicePrintingMediaSetting = AgencyInvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).OneTimeInvoicePrintingMediaSetting = OneTimeInvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.Invoice).SetParameterValues()

                        End If

                    End If

                End If

            ElseIf AccountReceivableInvoice.RecordType = "P" Then

                If InvoicePrintingSetting IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                        CreateCustomInvoice(Session, New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)({AccountReceivableInvoice}),
                                            New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)({InvoicePrintingSetting}),
                                            New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)({InvoicePrintingMediaSetting}), IsDraft, InvoicePrintingType)

                    Else

                        If (InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False AndAlso AccountReceivableInvoice.InvoiceAmount = 0) = False Then

                            If ShowBackupReport AndAlso InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False) Then

                                If InvoicePrintingSetting.BackupReportColumnOption.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.BackupReportColumnOptions.DateHoursAmount Then

                                    Report = New AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHT).SetParameterValues()

                                ElseIf InvoicePrintingSetting.BackupReportColumnOption.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.BackupReportColumnOptions.DateHoursAmountCommissionTaxTotal Then

                                    Report = New AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.InvoiceBackupDHNCTT).SetParameterValues()

                                End If

                            Else

                                If InvoicePrintingSetting.CustomInvoiceID.GetValueOrDefault(0) > 0 Then

                                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                        CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, InvoicePrintingSetting.CustomInvoiceID.GetValueOrDefault(0))

                                    End Using

                                End If

                                If CustomInvoice Is Nothing Then

                                    If InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.Production Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionCurrentTTD Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimatePriorCurrentTTD Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionNetCommissionTaxCurrent Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionGrandTotal Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimateCurrentTTD Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUp Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice

                                    ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUpComment Then

                                        Report = New AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice

                                    End If

                                Else

                                    Report = AdvantageFramework.Reporting.Reports.CreateCustomInvoiceReport(CustomInvoice)

                                End If

                                If InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.Production Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionCurrentTTD Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimatePriorCurrentTTD Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionNetCommissionTaxCurrent Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionGrandTotal Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimateCurrentTTD Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUp Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUp.Invoice).SetParameterValues()

                                ElseIf InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionJobDescriptionRollUpComment Then

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).IsDraft = IsDraft
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).UserCode = Session.UserCode
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).Session = Session
                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).AccountReceivableInvoice = AccountReceivableInvoice

                                    CType(Report, AdvantageFramework.Reporting.Reports.Invoices.JobDescriptionRollUpComment.Invoice).SetParameterValues()

                                End If

                            End If

                        End If

                    End If

                End If

            ElseIf AccountReceivableInvoice.RecordType = "C" Then

                If InvoicePrintingComboSetting IsNot Nothing AndAlso InvoicePrintingSetting IsNot Nothing AndAlso InvoicePrintingMediaSetting IsNot Nothing AndAlso
                        AgencyInvoicePrintingMediaSetting IsNot Nothing AndAlso OneTimeInvoicePrintingMediaSetting IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        MediaOrderLineSelectionInIncomeOnly = AdvantageFramework.Agency.LoadMediaOrderLineSelectionInIncomeOnly(DataContext)

                    End Using

                    If MediaOrderLineSelectionInIncomeOnly Then

                        Report = New AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice

                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).IsDraft = IsDraft
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).InvoicePrintingComboSetting = InvoicePrintingComboSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).InvoicePrintingSetting = InvoicePrintingSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).AgencyInvoicePrintingMediaSetting = AgencyInvoicePrintingMediaSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).OneTimeInvoicePrintingMediaSetting = OneTimeInvoicePrintingMediaSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).AccountReceivableInvoice = AccountReceivableInvoice

                        CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.IncomeOnlyInvoice).SetParameterValues()

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            ComboInvoiceDetails = AdvantageFramework.InvoicePrinting.LoadComboInvoiceDetails(DbContext, Session.UserCode, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber,
                                                                                                             InvoicePrintingComboSetting.AddressBlockType,
                                                                                                             InvoicePrintingComboSetting.PrintClientName, InvoicePrintingComboSetting.PrintDivisionName,
                                                                                                             InvoicePrintingComboSetting.PrintProductDescription, InvoicePrintingComboSetting.PrintContactAfterAddress,
                                                                                                             InvoicePrintingComboSetting.ApplyExchangeRate, InvoicePrintingComboSetting.ExchangeRateAmount,
                                                                                                             InvoicePrintingComboSetting.UseInvoiceCategoryDescription,
                                                                                                             InvoicePrintingComboSetting.InvoiceTitle, InvoicePrintingComboSetting.InvoiceFooterCommentType,
                                                                                                             InvoicePrintingComboSetting.InvoiceFooterComment, InvoicePrintingComboSetting.ShowCodes, InvoicePrintingComboSetting.ContactType,
                                                                                                             IsDraft, AccountReceivableInvoice.Batch).ToList

                        End Using

                        RecordTypes = ComboInvoiceDetails.Select(Function(Entity) Entity.MediaType).Distinct.ToList

                        For Each RecordType In RecordTypes

                            TotalAmount = ComboInvoiceDetails.Where(Function(Entity) Entity.MediaType = RecordType).Select(Function(Entity) Entity.TotalAmount.GetValueOrDefault(0)).Sum

                            If RecordType <> "P" Then

                                If (((RecordType = "M" AndAlso InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = False) OrElse
                                        (RecordType = "N" AndAlso InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = False) OrElse
                                        (RecordType = "I" AndAlso InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = False) OrElse
                                        (RecordType = "O" AndAlso InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = False) OrElse
                                        (RecordType = "R" AndAlso InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = False) OrElse
                                        (RecordType = "T" AndAlso InvoicePrintingMediaSetting.TVShowZeroLineAmounts = False)) AndAlso TotalAmount = 0) = False Then

                                    ComboInvoiceDetails.ForEach(Sub(ComboInvoiceDetail)

                                                                    If ComboInvoiceDetail.MediaType = RecordType Then

                                                                        ComboInvoiceDetail.SortOrder = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.InvoicePrinting.MediaTypeSortOrder), RecordType)

                                                                    End If

                                                                End Sub)

                                Else

                                    ComboInvoiceDetails.ToList.ForEach(Sub(ComboInvoiceDetail)

                                                                           If ComboInvoiceDetail.MediaType = RecordType Then

                                                                               ComboInvoiceDetails.Remove(ComboInvoiceDetail)

                                                                           End If

                                                                       End Sub)

                                End If

                            Else

                                If (InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False AndAlso TotalAmount = 0) = False Then

                                    ComboInvoiceDetails.ForEach(Sub(ComboInvoiceDetail)

                                                                    If ComboInvoiceDetail.MediaType = RecordType Then

                                                                        ComboInvoiceDetail.SortOrder = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.InvoicePrinting.MediaTypeSortOrder), RecordType)

                                                                    End If

                                                                End Sub)

                                Else

                                    ComboInvoiceDetails.ToList.ForEach(Sub(ComboInvoiceDetail)

                                                                           If ComboInvoiceDetail.MediaType = RecordType Then

                                                                               ComboInvoiceDetails.Remove(ComboInvoiceDetail)

                                                                           End If

                                                                       End Sub)

                                End If

                            End If

                        Next

                        If ComboInvoiceDetails.Count > 0 Then

                            Report = New AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice

                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).IsDraft = IsDraft
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).SequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).InvoiceDate = AccountReceivableInvoice.InvoiceDate.GetValueOrDefault(Now)
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).InvoicePrintingComboSetting = InvoicePrintingComboSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).InvoicePrintingSetting = InvoicePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).AgencyInvoicePrintingMediaSetting = AgencyInvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).OneTimeInvoicePrintingMediaSetting = OneTimeInvoicePrintingMediaSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).AccountReceivableInvoice = AccountReceivableInvoice
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).ApplyExchangeRate = InvoicePrintingComboSetting.ApplyExchangeRate.GetValueOrDefault(1)
                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).ExchangeRateAmount = InvoicePrintingComboSetting.ExchangeRateAmount.GetValueOrDefault(1.0)

                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).SetParameterValues()

                            CType(Report, AdvantageFramework.Reporting.Reports.Invoices.ComboInvoice.Invoice).DataSource = ComboInvoiceDetails

                        End If

                    End If

                End If

            End If

        End If

        CreateInvoice = Report

    End Function
    Public Sub CreateCustomInvoice(Session As AdvantageFramework.Security.Session, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                   InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting),
                                   InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting),
                                   IsDraft As Boolean, InvoicePrintingType As AdvantageFramework.InvoicePrinting.InvoicePrintingTypes,
                                   Optional EmailSettings As AdvantageFramework.InvoicePrinting.Classes.EmailSettings = Nothing)
        '[To] As String, [Cc] As String, [Bcc] As String, Subject As String, Body As String)

        'objects
        Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
        Dim CustomAccessReportFileName As String = ""
        Dim AgencyReportFolder As String = ""
        Dim AgencyReportTempFolder As String = ""
        Dim HasMediaInvoices As Boolean = False
        Dim HasProductionInvoices As Boolean = False
        Dim HasComboInvoices As Boolean = False
        Dim ReportRuntimeNumber As AdvantageFramework.Database.Entities.ReportRuntimeNumber = Nothing
        Dim ReportRuntimeSpecs As Generic.List(Of AdvantageFramework.Database.Entities.ReportRuntimeSpec) = Nothing
        Dim ProductionReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec = Nothing
        Dim MediaReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec = Nothing
        Dim AccessReportPath As String = Nothing
        Dim AccessReportTempPath As String = Nothing
        Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Dim ProductionInvoiceDate As Date = Date.MinValue
        Dim MediaInvoiceDate As Date = Date.MinValue
        Dim ComboReports As Generic.List(Of AdvantageFramework.Database.Entities.CustomReport) = Nothing
        Dim ComboCustomFormatName As String = ""
        Dim CustomAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

        If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AgencyReportFolder = AdvantageFramework.Database.Procedures.Agency.LoadReportPath(DbContext)
                AgencyReportTempFolder = AdvantageFramework.Database.Procedures.Agency.LoadReportTempPath(DbContext)

                AdvantageFramework.Database.Procedures.ReportRuntimeNumber.DeleteByUserCode(DbContext, Session.UserCode)

                ComboReports = AdvantageFramework.Database.Procedures.CustomReport.LoadByLegacyModuleCode(DbContext, "CI").ToList

                CustomAccountReceivableInvoices = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

                For Each AccountReceivableInvoice In AccountReceivableInvoices

                    InvoicePrintingMediaSetting = Nothing
                    InvoicePrintingSetting = Nothing
                    ReportRuntimeNumber = Nothing

                    If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                        If InvoicePrintingMediaSettings.Count > 1 Then

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                        Else

                            InvoicePrintingMediaSetting = InvoicePrintingMediaSettings.FirstOrDefault

                        End If

                        If InvoicePrintingMediaSetting IsNot Nothing AndAlso
                                ((AccountReceivableInvoice.RecordType = "M" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.MagazineCustomFormatName) = False) OrElse
                                 (AccountReceivableInvoice.RecordType = "N" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.NewspaperCustomFormatName) = False) OrElse
                                 (AccountReceivableInvoice.RecordType = "I" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.InternetCustomFormatName) = False) OrElse
                                 (AccountReceivableInvoice.RecordType = "O" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.OutdoorCustomFormatName) = False) OrElse
                                 (AccountReceivableInvoice.RecordType = "R" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.RadioCustomFormatName) = False) OrElse
                                 (AccountReceivableInvoice.RecordType = "T" AndAlso String.IsNullOrWhiteSpace(InvoicePrintingMediaSetting.TVCustomFormatName) = False)) Then

                            ReportRuntimeNumber = New AdvantageFramework.Database.Entities.ReportRuntimeNumber

                            ReportRuntimeNumber.UserCode = Session.UserCode
                            ReportRuntimeNumber.ReportType = "MI"
                            ReportRuntimeNumber.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                            ReportRuntimeNumber.ClientCode = AccountReceivableInvoice.ClientCode
                            ReportRuntimeNumber.OrderType = AccountReceivableInvoice.RecordType
                            ReportRuntimeNumber.BillingUser = AccountReceivableInvoice.Batch

                            If MediaInvoiceDate = Date.MinValue AndAlso AccountReceivableInvoice.InvoiceDate.HasValue Then

                                HasMediaInvoices = True
                                MediaInvoiceDate = AccountReceivableInvoice.InvoiceDate.Value

                            End If

                            DbContext.ReportRuntimeNumbers.Add(ReportRuntimeNumber)

                            CustomAccountReceivableInvoices.Add(AccountReceivableInvoice)

                            If HasComboInvoices = False Then

                                If AccountReceivableInvoice.RecordType = "M" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.MagazineCustomFormatName)

                                ElseIf AccountReceivableInvoice.RecordType = "N" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.NewspaperCustomFormatName)

                                ElseIf AccountReceivableInvoice.RecordType = "I" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.InternetCustomFormatName)

                                ElseIf AccountReceivableInvoice.RecordType = "O" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.OutdoorCustomFormatName)

                                ElseIf AccountReceivableInvoice.RecordType = "R" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.RadioCustomFormatName)

                                ElseIf AccountReceivableInvoice.RecordType = "T" Then

                                    HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingMediaSetting.TVCustomFormatName)

                                End If

                                If HasComboInvoices Then

                                    If AccountReceivableInvoice.RecordType = "M" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.MagazineCustomFormatName

                                    ElseIf AccountReceivableInvoice.RecordType = "N" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.NewspaperCustomFormatName

                                    ElseIf AccountReceivableInvoice.RecordType = "I" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.InternetCustomFormatName

                                    ElseIf AccountReceivableInvoice.RecordType = "O" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.OutdoorCustomFormatName

                                    ElseIf AccountReceivableInvoice.RecordType = "R" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.RadioCustomFormatName

                                    ElseIf AccountReceivableInvoice.RecordType = "T" Then

                                        ComboCustomFormatName = InvoicePrintingMediaSetting.TVCustomFormatName

                                    End If

                                End If

                            End If

                            'DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.RPT_SEL_NBRS ([USER_ID], [APP_TYPE], [AR_INV_NBR], [CL_CODE], [ORDER_TYPE]) VALUES('{0}', 'MI', {1}, '{2}', '{3}')", Session.UserCode, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.ClientCode, AccountReceivableInvoice.RecordType))

                        End If

                    ElseIf AccountReceivableInvoice.RecordType = "P" Then

                        If InvoicePrintingSettings.Count > 1 Then

                            InvoicePrintingSetting = InvoicePrintingSettings.SingleOrDefault(Function(Entity) Entity.ClientCode = AccountReceivableInvoice.ClientCode)

                        Else

                            InvoicePrintingSetting = InvoicePrintingSettings.FirstOrDefault

                        End If

                        If InvoicePrintingSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(InvoicePrintingSetting.CustomFormatName) = False Then

                            ReportRuntimeNumber = New AdvantageFramework.Database.Entities.ReportRuntimeNumber

                            ReportRuntimeNumber.UserCode = Session.UserCode
                            ReportRuntimeNumber.ReportType = "PI"
                            ReportRuntimeNumber.ClientCode = AccountReceivableInvoice.ClientCode
                            ReportRuntimeNumber.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber
                            ReportRuntimeNumber.BillingUser = AccountReceivableInvoice.Batch

                            If ProductionInvoiceDate = Date.MinValue AndAlso AccountReceivableInvoice.InvoiceDate.HasValue Then

                                HasProductionInvoices = True
                                ProductionInvoiceDate = AccountReceivableInvoice.InvoiceDate.Value

                            End If

                            DbContext.ReportRuntimeNumbers.Add(ReportRuntimeNumber)

                            CustomAccountReceivableInvoices.Add(AccountReceivableInvoice)

                            If HasComboInvoices = False Then

                                HasComboInvoices = ComboReports.Any(Function(Entity) Entity.Name = InvoicePrintingSetting.CustomFormatName)

                                If HasComboInvoices Then

                                    ComboCustomFormatName = InvoicePrintingSetting.CustomFormatName

                                End If

                            End If

                            'DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.RPT_SEL_NBRS ([USER_ID], [APP_TYPE], [AR_INV_NBR], [CL_CODE]) VALUES('{0}', 'PI', {1}, '{2}')", Session.UserCode, AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.ClientCode))

                        End If

                    End If

                Next

                Try

                    AccessReportPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessRptPath)

                Catch ex As Exception
                    AccessReportPath = Nothing
                End Try

                If String.IsNullOrWhiteSpace(AccessReportPath) = False Then

                    AgencyReportFolder = AccessReportPath

                End If

                Try

                    AccessReportTempPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                Catch ex As Exception
                    AccessReportTempPath = Nothing
                End Try

                If String.IsNullOrWhiteSpace(AccessReportTempPath) = False Then

                    AgencyReportTempFolder = AccessReportTempPath

                End If

                ReportRuntimeSpecs = AdvantageFramework.Database.Procedures.ReportRuntimeSpec.LoadByUserCode(DbContext, Session.UserCode).ToList

                If HasMediaInvoices Then

                    If ReportRuntimeSpecs.Any(Function(Entity) Entity.ReportType = "MI") Then

                        MediaReportRuntimeSpec = ReportRuntimeSpecs.SingleOrDefault(Function(Entity) Entity.ReportType = "MI")

                        DbContext.Entry(MediaReportRuntimeSpec).State = Entity.EntityState.Modified

                    Else

                        MediaReportRuntimeSpec = New AdvantageFramework.Database.Entities.ReportRuntimeSpec

                        MediaReportRuntimeSpec.UserCode = Session.UserCode
                        MediaReportRuntimeSpec.ReportType = "MI"
                        MediaReportRuntimeSpec.LinkID = 1

                        DbContext.ReportRuntimeSpecs.Add(MediaReportRuntimeSpec)

                    End If

                    MediaReportRuntimeSpec.AccessConnectionString = CreateDSNString(Session.DatabaseName, Session.SQLUserName, Session.SQLPassword)
                    MediaReportRuntimeSpec.SelectedDate = MediaInvoiceDate
                    MediaReportRuntimeSpec.SQLPrintedDate = MediaInvoiceDate
                    MediaReportRuntimeSpec.PrintedDate = MediaInvoiceDate
                    MediaReportRuntimeSpec.FunctionOption = 1
                    MediaReportRuntimeSpec.NameOverrideOption = Nothing
                    MediaReportRuntimeSpec.AddressOption = 3
                    MediaReportRuntimeSpec.MemoOption = 1
                    MediaReportRuntimeSpec.PrintOption = InvoicePrintingType
                    MediaReportRuntimeSpec.IsOneTime = If(InvoicePrintingMediaSettings.Any(Function(Entity) Entity.IsOneTime.GetValueOrDefault(False) = True), 1, 0)
                    MediaReportRuntimeSpec.IsDraft = If(IsDraft = True, 1, 0)
                    MediaReportRuntimeSpec.AccessReportPath = AgencyReportFolder
                    MediaReportRuntimeSpec.AccessReportTemporaryPath = AgencyReportTempFolder

                    If (InvoicePrintingType = InvoicePrinting.Methods.InvoicePrintingTypes.AutoEmail OrElse InvoicePrintingType = InvoicePrinting.Methods.InvoicePrintingTypes.SMTP) AndAlso
                            EmailSettings IsNot Nothing Then

                        'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        '    MediaReportRuntimeSpec.EmailFrom = AdvantageFramework.Email.LoadEmployeeEmail(DbContext, Session.User.EmployeeCode)

                        'End Using

                        MediaReportRuntimeSpec.EmailSubject = EmailSettings.Subject
                        MediaReportRuntimeSpec.EmailBody = EmailSettings.Body
                        MediaReportRuntimeSpec.EmailCC = If(EmailSettings.CCToSender = True, 1, 0)

                    End If

                End If

                If HasProductionInvoices Then

                    If ReportRuntimeSpecs.Any(Function(Entity) Entity.ReportType = "PI") Then

                        ProductionReportRuntimeSpec = ReportRuntimeSpecs.SingleOrDefault(Function(Entity) Entity.ReportType = "PI")

                        DbContext.Entry(ProductionReportRuntimeSpec).State = Entity.EntityState.Modified

                    Else

                        ProductionReportRuntimeSpec = New AdvantageFramework.Database.Entities.ReportRuntimeSpec

                        ProductionReportRuntimeSpec.UserCode = Session.UserCode
                        ProductionReportRuntimeSpec.ReportType = "PI"
                        ProductionReportRuntimeSpec.LinkID = 1

                        DbContext.ReportRuntimeSpecs.Add(ProductionReportRuntimeSpec)

                    End If

                    ProductionReportRuntimeSpec.AccessConnectionString = CreateDSNString(Session.DatabaseName, Session.SQLUserName, Session.SQLPassword)
                    ProductionReportRuntimeSpec.SelectedDate = ProductionInvoiceDate
                    ProductionReportRuntimeSpec.SQLPrintedDate = ProductionInvoiceDate
                    ProductionReportRuntimeSpec.PrintedDate = ProductionInvoiceDate
                    ProductionReportRuntimeSpec.FunctionOption = 1
                    ProductionReportRuntimeSpec.NameOverrideOption = Nothing
                    ProductionReportRuntimeSpec.AddressOption = 3
                    ProductionReportRuntimeSpec.MemoOption = 1
                    ProductionReportRuntimeSpec.PrintOption = InvoicePrintingType
                    ProductionReportRuntimeSpec.IsOneTime = If(InvoicePrintingSettings.Any(Function(Entity) Entity.IsOneTime.GetValueOrDefault(False) = True), 1, 0)
                    ProductionReportRuntimeSpec.IsDraft = If(IsDraft = True, 1, 0)
                    ProductionReportRuntimeSpec.AccessReportPath = AgencyReportFolder
                    ProductionReportRuntimeSpec.AccessReportTemporaryPath = AgencyReportTempFolder

                    If (InvoicePrintingType = InvoicePrinting.Methods.InvoicePrintingTypes.AutoEmail OrElse InvoicePrintingType = InvoicePrinting.Methods.InvoicePrintingTypes.SMTP) AndAlso
                            EmailSettings IsNot Nothing Then

                        'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        '    ProductionReportRuntimeSpec.EmailFrom = AdvantageFramework.Email.LoadEmployeeEmail(DbContext, Session.User.EmployeeCode)

                        'End Using

                        ProductionReportRuntimeSpec.EmailSubject = EmailSettings.Subject
                        ProductionReportRuntimeSpec.EmailBody = EmailSettings.Body
                        ProductionReportRuntimeSpec.EmailCC = If(EmailSettings.CCToSender = True, 1, 0)

                    End If

                End If

                DbContext.SaveChanges()

                If InvoicePrintingType = InvoicePrinting.Methods.InvoicePrintingTypes.AutoEmail AndAlso CustomAccountReceivableInvoices IsNot Nothing Then

                    For Each AccountReceivableInvoice In CustomAccountReceivableInvoices

                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.ACCT_REC SET LAST_AUTO_EMAIL_DATE = GETDATE() WHERE AR_INV_NBR = " & AccountReceivableInvoice.InvoiceNumber & " AND AR_INV_SEQ = " & AccountReceivableInvoice.InvoiceSequenceNumber)

                    Next

                End If

            End Using

            If HasMediaInvoices AndAlso HasComboInvoices = False Then

                StartCustomReportAccessDatabase(Session, AgencyReportFolder, AgencyReportTempFolder, "armediaobj_cusrpts.accdb", Nothing, Nothing, ComboCustomFormatName)

            End If

            If HasProductionInvoices AndAlso HasComboInvoices = False Then

                StartCustomReportAccessDatabase(Session, AgencyReportFolder, AgencyReportTempFolder, "ARInvObj_CusRpts.accdb", Nothing, Nothing, ComboCustomFormatName)

            End If

            If HasComboInvoices Then

                If MediaReportRuntimeSpec IsNot Nothing Then

                    StartCustomReportAccessDatabase(Session, AgencyReportFolder, AgencyReportTempFolder, "ARComboObj_CusRpts.accdb", MediaReportRuntimeSpec, AccountReceivableInvoices, ComboCustomFormatName)

                ElseIf ProductionReportRuntimeSpec IsNot Nothing Then

                    StartCustomReportAccessDatabase(Session, AgencyReportFolder, AgencyReportTempFolder, "ARComboObj_CusRpts.accdb", ProductionReportRuntimeSpec, AccountReceivableInvoices, ComboCustomFormatName)

                End If

            End If

        End If

    End Sub
    Private Sub StartCustomReportAccessDatabase(Session As AdvantageFramework.Security.Session, AgencyReportFolder As String, AgencyReportTempFolder As String,
                                                CustomAccessReportFileName As String, ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec,
                                                AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice),
                                                ComboCustomFormatName As String)

        'objects
        Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
        Dim UserFolder As String = ""
        Dim CustomAccessReportFullFileName As String = ""
        Dim UserCustomAccessReportFullFileName As String = ""
        Dim FileInfo As System.IO.FileInfo = Nothing
        Dim OleDbConnection As System.Data.OleDb.OleDbConnection = Nothing
        Dim RegistryKey As Microsoft.Win32.RegistryKey = Nothing
        Dim MSAccessEXE As String = ""
        Dim ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing
        Dim CurrentDirectory As String = String.Empty
        Dim IsMedia As Boolean = False
        Dim ARInvoiceString As String = String.Empty

        AgencyReportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyReportFolder, "\")
        AgencyReportTempFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyReportTempFolder, "\")

        If My.Computer.FileSystem.DirectoryExists(AgencyReportFolder) Then

            CustomAccessReportFullFileName = AgencyReportFolder & CustomAccessReportFileName

            If My.Computer.FileSystem.FileExists(CustomAccessReportFullFileName) Then

                UserFolder = AgencyReportTempFolder & Session.UserCode & "\"

                If My.Computer.FileSystem.DirectoryExists(UserFolder) = False Then

                    My.Computer.FileSystem.CreateDirectory(UserFolder)

                End If

                If My.Computer.FileSystem.DirectoryExists(UserFolder) Then

                    UserCustomAccessReportFullFileName = UserFolder & CustomAccessReportFileName

                    My.Computer.FileSystem.CopyFile(CustomAccessReportFullFileName, UserCustomAccessReportFullFileName, True)

                    If My.Computer.FileSystem.FileExists(UserCustomAccessReportFullFileName) Then

                        CustomAccessReportFileName = CustomAccessReportFileName & Now.ToString("yyyyMMddhhmmss")

                        If My.Computer.FileSystem.FileExists(UserFolder & CustomAccessReportFileName) = False Then

                            My.Computer.FileSystem.RenameFile(UserCustomAccessReportFullFileName, CustomAccessReportFileName)

                        End If

                    End If

                    If My.Computer.FileSystem.FileExists(UserFolder & "advan.ico") = False AndAlso
                                My.Computer.FileSystem.FileExists(My.Computer.FileSystem.GetDirectoryInfo(My.Computer.FileSystem.CurrentDirectory).Parent.FullName & "\advan.ico") Then

                        My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.GetDirectoryInfo(My.Computer.FileSystem.CurrentDirectory).Parent.FullName & "\advan.ico", UserFolder & "advan.ico")

                    End If

                    If My.Computer.FileSystem.FileExists(UserFolder & CustomAccessReportFileName) Then

                        CurrentDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\")
                        IsMedia = If(ReportRuntimeSpec IsNot Nothing AndAlso ReportRuntimeSpec.ReportType = "MI", True, False)

                        If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                            For Each ARI In AccountReceivableInvoices

                                ARInvoiceString &= ARI.InvoiceNumber & "," & ARI.RecordType & "," & ARI.ClientCode & "|"

                            Next

                        Else

                            ARInvoiceString = " "

                        End If

                        System.Diagnostics.Process.Start(CurrentDirectory & "Advantage MSAccess.EXE", """" & Session.ServerName & """ """ &
                                                                                                             Session.DatabaseName & """ """ &
                                                                                                             Session.SQLUserName & """ """ &
                                                                                                             Session.SQLPassword & """ """ &
                                                                                                             Session.UseWindowsAuthentication.ToString & """ """ &
                                                                                                             Session.UserCode & """ """ &
                                                                                                             UserFolder & CustomAccessReportFileName & """ """ &
                                                                                                             ComboCustomFormatName & """ """ &
                                                                                                             IsMedia & """ """ &
                                                                                                             ARInvoiceString & """")

                        'Try

                        '	FileInfo = My.Computer.FileSystem.GetFileInfo(UserFolder & CustomAccessReportFileName)

                        'Catch ex As Exception
                        '	FileInfo = Nothing
                        'End Try

                        'If FileInfo IsNot Nothing Then

                        '	FileInfo.IsReadOnly = False

                        '	OleDbConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Persist Security Info=False;Data Source=" & UserFolder & CustomAccessReportFileName & ";")

                        '	OleDbConnection.Open()

                        '	If DeleteRuntimeSpecRows(OleDbConnection) Then

                        '		If InsertRuntimeSpecRows(OleDbConnection, Session, AgencyReportFolder, AgencyReportTempFolder, ReportRuntimeSpec) Then

                        '			If String.IsNullOrWhiteSpace(ComboCustomFormatName) = False AndAlso AccountReceivableInvoices IsNot Nothing Then

                        '				InsertRuntimeInvoiceNumbers(OleDbConnection, AccountReceivableInvoices)

                        '				Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        '					If DbContext.ComboInvoiceDefaults.Count = 0 Then

                        '						ComboInvoiceDefault = New AdvantageFramework.Database.Entities.ComboInvoiceDefault

                        '						ComboInvoiceDefault.ClientOrDefault = 1
                        '						ComboInvoiceDefault.AddressBlockType = 1
                        '						ComboInvoiceDefault.ApplyExchangeRate = 0
                        '						ComboInvoiceDefault.ExchangeRateAmount = 1
                        '						ComboInvoiceDefault.CustomFormatName = ComboCustomFormatName

                        '						AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Insert(DbContext, ComboInvoiceDefault)

                        '					Else

                        '						ComboInvoiceDefault = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).FirstOrDefault

                        '						If ComboInvoiceDefault IsNot Nothing Then

                        '							ComboInvoiceDefault.ClientOrDefault = 1
                        '							ComboInvoiceDefault.AddressBlockType = 1
                        '							ComboInvoiceDefault.ApplyExchangeRate = 0
                        '							ComboInvoiceDefault.ExchangeRateAmount = 1
                        '							ComboInvoiceDefault.CustomFormatName = ComboCustomFormatName

                        '							AdvantageFramework.Database.Procedures.ComboInvoiceDefault.Update(DbContext, ComboInvoiceDefault)

                        '						End If

                        '					End If

                        '				End Using

                        '			End If

                        '			OleDbConnection.Close()


                        '                              Try

                        '				MSAccessEXE = AdvantageFramework.Registry.LoadMicrosoftAccessEXEPath

                        '			Catch ex As Exception
                        '				MSAccessEXE = ""
                        '			End Try

                        '			If String.IsNullOrWhiteSpace(MSAccessEXE) = False Then

                        '				MSAccessEXE = AdvantageFramework.StringUtilities.AppendTrailingCharacter(MSAccessEXE, "\")

                        '				System.Diagnostics.Process.Start(MSAccessEXE & "MSACCESS.EXE", """" & UserFolder & CustomAccessReportFileName & """ /Runtime")


                        '                              Else

                        '				AdvantageFramework.Navigation.ShowMessageBox("Cannot find microsoft access exe.  This is just for testing purposes!")

                        '			End If

                        '		End If

                        '	End If

                        'End If

                    End If

                End If

            End If

        End If

    End Sub
    Public Sub ClearAllCustomReportsFiles(Session As AdvantageFramework.Security.Session)

        'objects
        Dim AgencyReportFolder As String = ""
        Dim UserFolder As String = ""
        Dim FileInfo As System.IO.FileInfo = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            AgencyReportFolder = AdvantageFramework.Database.Procedures.Agency.LoadReportPath(DbContext)

        End Using

        AgencyReportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyReportFolder, "\")

        UserFolder = AgencyReportFolder & Session.UserCode & "\"

        If My.Computer.FileSystem.DirectoryExists(UserFolder) Then

            For Each FileInfo In My.Computer.FileSystem.GetDirectoryInfo(UserFolder).GetFiles

                If FileInfo.Extension.Contains("ico") = False Then

                    Try

                        FileInfo.Delete()

                    Catch ex As Exception

                    End Try

                End If

            Next

        End If

    End Sub
    Private Function DeleteRuntimeSpecRows(OleDbConnection As System.Data.OleDb.OleDbConnection) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowsDeleted As Boolean = False

        SQLString = "DELETE FROM InvoiceRuntimeSpecs"

        OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

        Try

            OleDbCommand.ExecuteNonQuery()

            RowsDeleted = True

        Catch ex As Exception
            RowsDeleted = False
        End Try

        DeleteRuntimeSpecRows = RowsDeleted

    End Function
    'Private Function InsertRuntimeSpecRows(DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, AgencyReportFolder As String) As Boolean

    '    Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
    '    Dim SQLString As String = ""
    '    Dim RowInserted As Boolean = False

    '    SQLString = "INSERT INTO InvoiceRuntimeSpecs ([AdvanDSN], [USER_ID], [InvoiceDate], [InvDateSQL], [InvoicePrintDate], [InvoiceMemoOpt], [AddressOpt], [NameOverideOpt], [FunctionOpt], [PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH]) " &
    '        "VALUES (""ODBC;DSN=" & Session.DatabaseName & ";UID=" & Session.UserName & ";PWD=" & Session.Password & ";APP=Advantage"", """ & Session.UserCode & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, 1, 3, NULL, 1, 2, 0, 1, """ & AgencyReportFolder & """)"

    '    OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

    '    If OleDbCommand.ExecuteNonQuery > 0 Then

    '        RowInserted = True

    '    End If

    '    InsertRuntimeSpecRows = RowInserted

    'End Function
    Private Function InsertRuntimeSpecRows(OleDbConnection As System.Data.OleDb.OleDbConnection, Session As AdvantageFramework.Security.Session, AgencyReportFolder As String,
                                           AgencyReportTempFolder As String, ReportRuntimeSpec As AdvantageFramework.Database.Entities.ReportRuntimeSpec) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowInserted As Boolean = False

        If OleDbConnection.DataSource.Contains("armediaobj_cusrpts.accdb") Then

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([AdvanDSN], [USER_ID], [INVOICE_DATE], [InvDateSQL], [INVOICE_PRINT_DATE], " &
                                                         "[INVOICE_MEMO_OPT], [ADDRESS_OPT], [PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH]) " &
                        "VALUES (""ODBC;DSN=" & Session.DatabaseName & ";UID=" & Session.SQLUserName & ";PWD=" & Session.SQLPassword & ";APP=Advantage"", """ & Session.UserCode & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, " &
                                                         "1, 3, 2, 0, 1, """ & AgencyReportFolder & """)"

        ElseIf OleDbConnection.DataSource.Contains("ARComboObj_CusRpts.accdb") Then

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([LINK_ID], [ADVAN_DSN], [USER_ID], [INVOICE_DATE], " &
                                                         "[InvDateSQL], [INVOICE_PRINT_DATE], [INVOICE_MEMO_OPT], [ADDRESS_OPT], " &
                                                         "[PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH], " &
                                                         "[ACCESS_TMP_PATH], [SUBJECT], [BODY], [CC_ME]) " &
                        "VALUES (" & ReportRuntimeSpec.LinkID & ", """ & ReportRuntimeSpec.AccessConnectionString & """, """ & ReportRuntimeSpec.UserCode & """, """ & ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, """ &
                                     ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, """ & ReportRuntimeSpec.SelectedDate.Value.ToShortDateString & """, " & ReportRuntimeSpec.MemoOption.GetValueOrDefault(1) & ", " & ReportRuntimeSpec.AddressOption & ", " &
                                     ReportRuntimeSpec.PrintOption & ", " & ReportRuntimeSpec.IsDraft & ", " & ReportRuntimeSpec.IsOneTime & ", """ & ReportRuntimeSpec.AccessReportPath & """, """ &
                                     ReportRuntimeSpec.AccessReportTemporaryPath & """, """ & ReportRuntimeSpec.EmailSubject & """, """ & ReportRuntimeSpec.EmailBody & """, " & ReportRuntimeSpec.EmailCC.GetValueOrDefault(0) & ")"

        Else

            SQLString = "INSERT INTO InvoiceRuntimeSpecs ([AdvanDSN], [USER_ID], [InvoiceDate], [InvDateSQL], [InvoicePrintDate], [InvoiceMemoOpt], [AddressOpt], [NameOverideOpt], [FunctionOpt], [PREVIEW], [DRAFT], [ONE_TIME], [USER_FORMS_PATH]) " &
                        "VALUES (""ODBC;DSN=" & Session.DatabaseName & ";UID=" & Session.SQLUserName & ";PWD=" & Session.SQLPassword & ";APP=Advantage"", """ & Session.UserCode & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, """ & Now.ToShortDateString & """, 1, 3, NULL, 1, 2, 0, 1, """ & AgencyReportFolder & """)"

        End If

        OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

        If OleDbCommand.ExecuteNonQuery > 0 Then

            RowInserted = True

        End If

        InsertRuntimeSpecRows = RowInserted

    End Function
    Private Function InsertRuntimeInvoiceNumbers(OleDbConnection As System.Data.OleDb.OleDbConnection, AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)) As Boolean

        Dim OleDbCommand As System.Data.OleDb.OleDbCommand = Nothing
        Dim SQLString As String = ""
        Dim RowInserted As Boolean = True

        For Each AccountReceivableInvoice In AccountReceivableInvoices

            SQLString = "INSERT INTO SelARInv ([AR_INV_NBR], [ORDER_TYPE], [CL_CODE]) " &
                        "VALUES (" & AccountReceivableInvoice.InvoiceNumber & ", """ & AccountReceivableInvoice.RecordType & """, """ & AccountReceivableInvoice.ClientCode & """)"

            OleDbCommand = New System.Data.OleDb.OleDbCommand(SQLString, OleDbConnection)

            If OleDbCommand.ExecuteNonQuery = 0 Then

                RowInserted = False

            End If

        Next

        InsertRuntimeInvoiceNumbers = RowInserted

    End Function
    Private Function CreateDSNString(ByVal DatabaseName As String, ByVal UserName As String, ByVal Password As String)

        CreateDSNString = "ODBC;DSN=" & DatabaseName & ";UID=" & UserName & ";PWD=" & Password & ";APP=Advantage"

    End Function
    Public Function CreateCustomEstimateReport(ByVal EstimateType As AdvantageFramework.Estimate.Printing.ReportFormats) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If EstimateType = Estimate.Printing.ReportFormats.OneQuotePerPage Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport

        ElseIf EstimateType = Estimate.Printing.ReportFormats.SideBySideQuote Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002

        ElseIf EstimateType = Estimate.Printing.ReportFormats.RevisionComparison Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003

        ElseIf EstimateType = Estimate.Printing.ReportFormats.RevisionComparisonWithVariance Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004

        ElseIf EstimateType = Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005

        ElseIf EstimateType = Estimate.Printing.ReportFormats.RevisionComparisonNoActual Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006

        ElseIf EstimateType = Estimate.Printing.ReportFormats.RevisionComparisonPrevLastRevisions Then

            XtraReport = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007

        End If

        'XtraReport.DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(InvoiceType.ToString)

        CreateCustomEstimateReport = XtraReport

    End Function
    Public Function CreateEstimate(Session As AdvantageFramework.Security.Session, EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote,
                                  EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting, EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats,
                                  Optional ByVal Comps As String = "", Optional ByVal Quotes As String = "", Optional ByVal QuoteDescriptions As String = "", Optional ByVal Combine As Integer = 0, Optional ByVal DateToPrint As DateTime = Nothing, Optional ByVal CultureCode As String = "") As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim CustomEstimate As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
        Dim FooterType As String = ""
        Dim FooterFont As Integer = 9

        If EstimateQuote IsNot Nothing Then

            If EstimatePrintingSetting IsNot Nothing Then

                If EstimatePrintingSetting.CustomEstimateID.GetValueOrDefault(0) > 0 Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        CustomEstimate = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, EstimatePrintingSetting.CustomEstimateID.GetValueOrDefault(0))

                    End Using

                End If

                If CustomEstimate Is Nothing Then

                    If EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.OneQuotePerPage Then

                        If EstimatePrintingSetting.PrintQuantityTotals = True Then
                            Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport
                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                            End Using
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateNumber = EstimateQuote.EstimateNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UserCode = Session.UserCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintingSetting = EstimatePrintingSetting
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintSetting = Nothing
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ClientCode = EstimateQuote.ClientCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DivisionCode = EstimateQuote.DivisionCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ProductCode = EstimateQuote.ProductCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Session = Session
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).AgencyName = Agency.Name
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultLocation = Location
                                If DateToPrint = Nothing Then
                                    CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateQuote.EstimateDate
                                Else
                                    CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = DateToPrint
                                End If
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooterType = FooterType
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooterFont = FooterFont
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumbers = Quotes
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateCompNumbers = Comps
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Combine = Combine
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).CultureCode = CultureCode

                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).SetParameterValues()
                            End Using
                        Else
                            Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001

                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                            End Using
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateNumber = EstimateQuote.EstimateNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UserCode = Session.UserCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimatePrintingSetting = EstimatePrintingSetting
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimatePrintSetting = Nothing
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).ClientCode = EstimateQuote.ClientCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DivisionCode = EstimateQuote.DivisionCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).ProductCode = EstimateQuote.ProductCode
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).Session = Session
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).AgencyName = Agency.Name
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultLocation = Location
                                If DateToPrint = Nothing Then
                                    CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UsePrintedDate = EstimateQuote.EstimateDate
                                Else
                                    CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UsePrintedDate = DateToPrint
                                End If
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultFooterType = FooterType
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultFooterFont = FooterFont
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateQuoteNumbers = Quotes
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateCompNumbers = Comps
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).Combine = Combine
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).CultureCode = CultureCode

                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).SetParameterValues()
                            End Using
                        End If

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.SideBySideQuote Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).QuoteDescriptions = QuoteDescriptions
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).CultureCode = CultureCode
                        End Using

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.RevisionComparison Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).CultureCode = CultureCode
                        End Using

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.RevisionComparisonWithVariance Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).CultureCode = CultureCode
                        End Using

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).CultureCode = CultureCode
                        End Using

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.RevisionComparisonNoActual Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).CultureCode = CultureCode
                        End Using

                    ElseIf EstimatePrintingSetting.ReportFormat = Estimate.Printing.ReportFormats.RevisionComparisonPrevLastRevisions Then

                        Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).CultureCode = CultureCode
                        End Using

                    End If

                Else

                    Report = AdvantageFramework.Reporting.Reports.CreateCustomEstimateReport(CustomEstimate)

                    If CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.OneQuotePerPage Then

                        'If EstimatePrintingSetting.PrintQuantityTotals = True Then
                        'Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport
                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooterFont = FooterFont
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).CultureCode = CultureCode

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).SetParameterValues()
                        End Using
                        'Else
                        '    'Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001

                        '    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        '        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        '    End Using
                        '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        '        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateNumber = EstimateQuote.EstimateNumber
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UserCode = Session.UserCode
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimatePrintingSetting = EstimatePrintingSetting
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimatePrintSetting = Nothing
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).ClientCode = EstimateQuote.ClientCode
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DivisionCode = EstimateQuote.DivisionCode
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).ProductCode = EstimateQuote.ProductCode
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).Session = Session
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).AgencyName = Agency.Name
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultLocation = Location
                        '        If DateToPrint = Nothing Then
                        '            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UsePrintedDate = EstimateQuote.EstimateDate
                        '        Else
                        '            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).UsePrintedDate = DateToPrint
                        '        End If
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType)
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).DefaultFooterType = FooterType
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateQuoteNumbers = Quotes
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).EstimateCompNumbers = Comps
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).Combine = Combine
                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).CultureCode = CultureCode

                        '        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport001).SetParameterValues()
                        '    End Using
                        'End If



                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.SideBySideQuote Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).QuoteDescriptions = QuoteDescriptions
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).CultureCode = CultureCode
                        End Using

                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.RevisionComparison Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).CultureCode = CultureCode
                        End Using

                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.RevisionComparisonWithVariance Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).CultureCode = CultureCode
                        End Using

                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).CultureCode = CultureCode
                        End Using

                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.RevisionComparisonNoActual Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).CultureCode = CultureCode
                        End Using

                    ElseIf CustomEstimate.EstimateReportType = Estimate.Printing.ReportFormats.RevisionComparisonPrevLastRevisions Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintingSetting.LocationCode)
                        End Using
                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateNumber = EstimateQuote.EstimateNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UserCode = Session.UserCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintingSetting = EstimatePrintingSetting
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintSetting = Nothing
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateComponentNumber = EstimateQuote.EstimateComponentNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ClientCode = EstimateQuote.ClientCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DivisionCode = EstimateQuote.DivisionCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ProductCode = EstimateQuote.ProductCode
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Session = Session
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).AgencyName = Agency.Name
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultLocation = Location
                            If DateToPrint = Nothing Then
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = EstimateQuote.EstimateDate
                            Else
                                CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = DateToPrint
                            End If
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooterType = FooterType
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooterFont = FooterFont

                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).SetParameterValues()
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumbers = Quotes
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateCompNumbers = Comps
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Combine = Combine
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).CultureCode = CultureCode
                        End Using

                    End If

                End If


            End If

        End If

        CreateEstimate = Report

    End Function
    Public Function CreateEstimateWV(Session As AdvantageFramework.Security.Session, EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote,
                                  EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting,
                                  EstimateNumber As Integer, EstimateComponentNumber As Integer, Comps As String, Quotes As String, EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting,
                                  ByVal EstimateDatePrint As DateTime, ByVal CultureCode As String, ByVal Format As String, ByVal QuoteDescriptions As String, ByVal Combine As Integer) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim FooterType As String = ""
        Dim FooterFont As Integer = 9

        If EstimateQuote IsNot Nothing Then

            If EstimatePrintSetting IsNot Nothing Then

                If Format = "Estimating" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).Combine = Combine
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating002" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).Combine = Combine
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport002).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating003" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).Combine = Combine
                        'CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport003).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating004" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).Combine = Combine
                        'CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport004).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating005" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).Combine = Combine
                        'CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport005).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating006" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).Combine = Combine
                        'CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport006).CultureCode = CultureCode
                    End Using

                ElseIf Format = "Estimating007" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).Combine = Combine
                        'CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).QuoteDescriptions = QuoteDescriptions
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport007).CultureCode = CultureCode
                    End Using

                ElseIf Format = "EstimatingSS2" Then

                    Report = New AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)
                        Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, EstimatePrintSetting.LocationCode)
                    End Using
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimateNumber = EstimateNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).UserCode = Session.UserCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimatePrintingSetting = Nothing
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimatePrintSetting = EstimatePrintSetting
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimateComponentNumber = EstimateComponentNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimateQuoteNumber = EstimateQuote.QuoteNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).ClientCode = EstimateQuote.ClientCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).DivisionCode = EstimateQuote.DivisionCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).ProductCode = EstimateQuote.ProductCode
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).AgencyName = Agency.Name
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).DefaultLocation = Location
                        If EstimatePrintSetting.DateToPrint = True Then
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).UsePrintedDate = EstimateQuote.EstimateDate
                        Else
                            CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).UsePrintedDate = EstimateDatePrint
                        End If
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).DefaultFooter = AdvantageFramework.Estimate.Printing.LoadEstimateFooter(DbContext, EstimateNumber, EstimateComponentNumber, Session.UserCode, FooterType, FooterFont)
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).DefaultFooterType = FooterType

                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).SetParameterValues()
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimateQuoteNumbers = Quotes
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).EstimateCompNumbers = Comps
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).Combine = Combine
                        CType(Report, AdvantageFramework.Reporting.Reports.Estimating.EstimateReport301).CultureCode = CultureCode
                    End Using

                End If

            End If

        End If

        CreateEstimateWV = Report

    End Function
    Private Function CreateOtherCashReceiptBatchReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                       ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.OtherCashReceiptBatchReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.OtherCashReceiptBatchReport

        XtraReport.Session = Session

        XtraReport.AgencyName = GetAgencyName(Session)

        XtraReport.DataSource = ParameterDictionary("DataSource")
        XtraReport.ReportRange = ParameterDictionary("ReportRange")
        XtraReport.ForUser = ParameterDictionary("ForUser")
        XtraReport.DetailPageBreak = ParameterDictionary("DetailPageBreak")

        XtraReport.DisplayName = "Other Cash Receipt Batch Report"

        CreateOtherCashReceiptBatchReport = XtraReport

    End Function
    Public Function CreateOrder(ByVal Session As AdvantageFramework.Security.Session, ByVal OrderNumber As Integer, ByVal LineNumbers As Generic.List(Of Integer),
                                ByVal MediaFrom As String, Optional ByVal ReportFormat As Integer = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.Landscape,
                                Optional ByVal UseImpersonation As Boolean = False) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim InternetOrderFormat As AdvantageFramework.Media.InternetOrderFormats = AdvantageFramework.Media.Methods.InternetOrderFormats.Portrait
        Dim NonBroadcastMediaOrderFormat As AdvantageFramework.Media.NonBroadcastMediaOrderFormats = AdvantageFramework.Media.Methods.NonBroadcastMediaOrderFormats.Portrait

        If Session IsNot Nothing Then
            ' Braxton
            If MediaFrom = "TV" OrElse MediaFrom = "Radio" Then

                If (ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.Landscape) Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport).MediaFrom = MediaFrom
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderReport).UseImpersonation = UseImpersonation

                ElseIf (ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.DailyBroadcastBySpot) Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderBySpotReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderBySpotReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderBySpotReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderBySpotReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderBySpotReport).MediaFrom = MediaFrom

                ElseIf (ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.DailyBroadcastByWeek) Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderByWeekReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderByWeekReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderByWeekReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderByWeekReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.BroadcastOrderByWeekReport).MediaFrom = MediaFrom

                End If

            ElseIf MediaFrom = "Internet" Then

                InternetOrderFormat = GetInternetOrderFormat(Session, MediaFrom)

                If InternetOrderFormat = AdvantageFramework.Media.Methods.InternetOrderFormats.Portrait Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).MediaFrom = MediaFrom

                ElseIf InternetOrderFormat = AdvantageFramework.Media.Methods.InternetOrderFormats.Detail Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.InternetOrderReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.InternetOrderReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.InternetOrderReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.InternetOrderReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.InternetOrderReport).MediaFrom = MediaFrom

                ElseIf InternetOrderFormat = AdvantageFramework.Media.Methods.InternetOrderFormats.NetOrderWithGrossClientTotals Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).MediaFrom = MediaFrom

                End If

            Else

                NonBroadcastMediaOrderFormat = GetNonBroadcastMediaOrderFormat(Session, MediaFrom)

                If NonBroadcastMediaOrderFormat = AdvantageFramework.Media.Methods.NonBroadcastMediaOrderFormats.Portrait Then

                    If MediaFrom = "Newspaper" Then

                        Report = New AdvantageFramework.Reporting.Reports.MediaManager.NewspaperOrderReport

                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.NewspaperOrderReport).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.NewspaperOrderReport).OrderNumber = OrderNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.NewspaperOrderReport).LineNumbers = LineNumbers

                    Else

                        Report = New AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport

                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).Session = Session
                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).OrderNumber = OrderNumber
                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).LineNumbers = LineNumbers
                        CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.PrintOrderReport).MediaFrom = MediaFrom

                    End If

                ElseIf NonBroadcastMediaOrderFormat = AdvantageFramework.Media.Methods.NonBroadcastMediaOrderFormats.NetOrderWithGrossClientTotals Then

                    Report = New AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport

                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).Session = Session
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).OrderNumber = OrderNumber
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).LineNumbers = LineNumbers
                    CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ClientBillingAuthReport).MediaFrom = MediaFrom

                End If

            End If

        End If

        CreateOrder = Report

    End Function
    Public Function CreateMediaManagerReminderReport(Session As AdvantageFramework.Security.Session,
                                                     ReminderContact As AdvantageFramework.MediaManager.Classes.ReminderContact,
                                                     VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                                                     LocationCode As String) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport

            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).ReminderContact = ReminderContact
            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).VCCOrders = VCCOrders
            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.ReminderReport).LocationCode = LocationCode

        End If

        CreateMediaManagerReminderReport = Report

    End Function
    Public Function CreateGLReportWriterAccountReport(Session As AdvantageFramework.Security.Session, GLReportWriterGLRowFormatList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        Report = New AdvantageFramework.Reporting.Reports.GeneralLedger.GLReportWriterAccountReport
        CType(Report, AdvantageFramework.Reporting.Reports.GeneralLedger.GLReportWriterAccountReport).Session = Session

        Report.DataSource = GLReportWriterGLRowFormatList

        CreateGLReportWriterAccountReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPreBuyReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                              Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPreBuyReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPreBuyDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                            Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPreBuyDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPreBuyStationDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                   Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPreBuyStationDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPreBuyStationSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                            Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPreBuyStationSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPreBuyStationSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPostBuyReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                               Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPostBuyReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPostBuyDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                             Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPostBuyDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPostBuyStationDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                    Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPostBuyStationDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetPostBuyStationSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                             Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyStationSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetPostBuyStationSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetBroadcastScheduleDetailReport(Session As AdvantageFramework.Security.Session,
                                                                         ParameterDictionary As Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleDetailReport
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleDetailReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleDetailReport).Session = Session

        End If

        CreateMediaBroadcastWorksheetBroadcastScheduleDetailReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport(Session As AdvantageFramework.Security.Session,
                                                                         ParameterDictionary As Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport).Session = Session

        End If

        CreateMediaBroadcastWorksheetBroadcastScheduleMarketSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetBroadcastScheduleStationSummaryReport(Session As AdvantageFramework.Security.Session,
                                                                         ParameterDictionary As Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleStationSummaryReport).Session = Session

        End If

        CreateMediaBroadcastWorksheetBroadcastScheduleStationSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport(Session As AdvantageFramework.Security.Session,
                                                                         ParameterDictionary As Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport).Session = Session

        End If

        CreateMediaBroadcastWorksheetBroadcastScheduleWeeklySummaryReport = Report

    End Function
    Private Function CreateHoursWorkedSummaryByDateReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                          ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport
        'objects

        Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectIndirectTime.HoursWorkedSummaryByDate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = LoadIndirectTime(ReportingDbContext, Criteria, [From], [To], False, ParameterDictionary)
            XtraReport.DateType.Value = Criteria
            XtraReport.StartDate.Value = [From]
            XtraReport.EndDate.Value = [To]

        End Using

        CreateHoursWorkedSummaryByDateReport = XtraReport

    End Function
    Private Function CreateHoursWorkedSummaryByEmployeeReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                          ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport
        'objects

        Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectIndirectTime.HoursWorkedSummaryByEmployee

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = LoadIndirectTime(ReportingDbContext, Criteria, [From], [To], False, ParameterDictionary)
            XtraReport.DateType.Value = Criteria
            XtraReport.StartDate.Value = [From]
            XtraReport.EndDate.Value = [To]

        End Using

        CreateHoursWorkedSummaryByEmployeeReport = XtraReport

    End Function
    Private Function CreateHoursWorkedDetailByDateReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                          ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport
        'objects

        Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectIndirectTime.HoursWorkedDetailByDate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = LoadIndirectTime(ReportingDbContext, Criteria, [From], [To], False, ParameterDictionary)
            XtraReport.DateType.Value = Criteria
            XtraReport.StartDate.Value = [From]
            XtraReport.EndDate.Value = [To]

        End Using

        CreateHoursWorkedDetailByDateReport = XtraReport

    End Function
    Private Function CreateHoursWorkedDetailByEmployeeReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                          ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport
        'objects

        Dim XtraReport As New AdvantageFramework.Reporting.Reports.Employee.DirectIndirectTime.HoursWorkedDetailByEmployee

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = LoadIndirectTime(ReportingDbContext, Criteria, [From], [To], False, ParameterDictionary)
            XtraReport.DateType.Value = Criteria
            XtraReport.StartDate.Value = [From]
            XtraReport.EndDate.Value = [To]

        End Using

        CreateHoursWorkedDetailByEmployeeReport = XtraReport

    End Function
    Private Function CreateMarketScheduleWeeklyDetailReport(ByVal Session As AdvantageFramework.Security.Session, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                            ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.MarketScheduleWeeklyDetailReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.MarketScheduleWeeklyDetailReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.MarketScheduleWeeklyDetailReport).ParameterDictionary = ParameterDictionary
            'CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).LocationEntity = Location

        End If

        CreateMarketScheduleWeeklyDetailReport = Report

    End Function
    Private Function CreateBillingWorksheetProductionSummaryV2(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                               ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Billing.SummaryReportV2 = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Billing.SummaryReportV2

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadBillingWorksheetProductionDetailV2(DbContext, ParameterDictionary)

            XtraReport.Parameters.Item("ap_pp_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString)
            XtraReport.Parameters.Item("et_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString)
            XtraReport.Parameters.Item("io_date_cutoff").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString)

            XtraReport.Parameters.Item("IncludeContingency").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString)
            XtraReport.Parameters.Item("include_non_billable_ap_io_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString)
            XtraReport.Parameters.Item("include_non_billable_time_detail").Value = ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString)

        End Using

        CreateBillingWorksheetProductionSummaryV2 = XtraReport

    End Function
    Private Function CreateUpdatedRateRequestReport(ByVal Session As AdvantageFramework.Security.Session, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                    ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.UpdatedRateRequestReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.UpdatedRateRequestReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.UpdatedRateRequestReport).ParameterDictionary = ParameterDictionary

        End If

        CreateUpdatedRateRequestReport = Report

    End Function
    Public Function GetPurchaseOrderReportParameterDictionary(Session As AdvantageFramework.Security.Session, PONumber As Integer) As Generic.Dictionary(Of String, Object)

        'objects
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

        ParameterDictionary = New Generic.Dictionary(Of String, Object)

        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Session.UserCode)

            If PurchaseOrderPrintDefault Is Nothing Then

                PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
                PurchaseOrderPrintDefault.UserID = Session.UserCode

                AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Insert(DbContext, PurchaseOrderPrintDefault)

            End If

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, PurchaseOrderPrintDefault.LocationID)

            End Using

        End Using

        Select Case PurchaseOrderPrintDefault.ReportFormat

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                ParameterDictionary("FooterAboveSignature") = False

            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code

                ParameterDictionary("FooterAboveSignature") = True

        End Select

        ParameterDictionary("PONumbers") = {PONumber}

        ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

        ParameterDictionary("DefaultLocation") = Location

        If PurchaseOrderPrintDefault.DateToPrint = 1 Then

            ParameterDictionary("UsePrintedDate") = Now.ToShortDateString

        End If

        GetPurchaseOrderReportParameterDictionary = ParameterDictionary

    End Function
    Public Function ProcessGeneratePurchaseOrders(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact),
                                                  UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel,
                                                  Subject As String, Body As String, CCSender As Boolean, UploadDocumentManager As Boolean,
                                                  ByRef AtLeastOneEmailFailed As Boolean) As Boolean

        'objects
        'Dim AllowPrivateAccess As Boolean = False
        Dim Processed As Boolean = True
        Dim MediaManagerGeneratePurchaseOrderVendorContactsToProcess As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) = Nothing
        Dim MediaManagerGeneratePurchaseOrderVendorContact As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact = Nothing
        Dim SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) = Nothing
        Dim PONumbers As Generic.List(Of Integer) = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim OrderStatus As Boolean = False
        Dim OrderStatusMessage As String = ""
        Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim DocumentFileName As String = ""
        Dim WebvantageURL As String = ""
        Dim MediaManagerGeneratedPOReportID As Integer = 0
        Dim PrintTool As DevExpress.XtraReports.UI.ReportPrintTool = Nothing
        Dim HasPrintedFirstReport As Boolean = False
        Dim ContinueGenerateOrders As Boolean = False
        Dim EmployeeEmailAddress As String = ""
        Dim VCCVendorCodes As Generic.List(Of String) = Nothing
        Dim EmailSubjectPrefix As String = ""

        MediaManagerGeneratePurchaseOrderVendorContactsToProcess = MediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.Process = True).ToList

        If MediaManagerGeneratePurchaseOrderVendorContactsToProcess IsNot Nothing AndAlso MediaManagerGeneratePurchaseOrderVendorContactsToProcess.Count > 0 Then

            Try

                'Try

                '    AllowPrivateAccess = AdvantageFramework.Security.LoadUserGroupSetting(Session, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Where(Function(Setting) Setting = True).Any

                'Catch ex As Exception
                '    AllowPrivateAccess = False
                'End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    VCCVendorCodes = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Where(Function(Entity) Entity.VCCStatus = 1 AndAlso Entity.SendVCCWithMediaOrder).Select(Function(Entity) Entity.Code).ToList

                    If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode) IsNot Nothing Then

                        EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

                    End If

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        If VCCVendorCodes IsNot Nothing AndAlso VCCVendorCodes.Count > 0 AndAlso MediaManagerGeneratePurchaseOrderVendorContactsToProcess.Any(Function(Entity) VCCVendorCodes.Contains(Entity.VendorCode) = True) Then

                            If AdvantageFramework.VCC.LoadVCCProvider(DataContext) <> 0 Then

                                If AdvantageFramework.VCC.IsVCCServiceSetup(Session) = False Then

                                    If AdvantageFramework.Navigation.ShowMessageBox("Failed trying to connect to VCC service.  Please check all your VCC settings. " & System.Environment.NewLine & System.Environment.NewLine & " Do you want to continue generating orders?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                        ContinueGenerateOrders = True

                                    End If

                                Else

                                    ContinueGenerateOrders = True

                                    AdvantageFramework.MediaManager.CreateUpdateVCCCardsForPurchaseOrders(Session, MediaManagerGeneratePurchaseOrderVendorContactsToProcess)

                                End If

                            Else

                                If AdvantageFramework.Navigation.ShowMessageBox("Your VCC settings are not configured properly.  Please check all your VCC settings. " & System.Environment.NewLine & System.Environment.NewLine & " Do you want to continue generating orders?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    ContinueGenerateOrders = True

                                End If

                            End If

                        Else

                            ContinueGenerateOrders = True

                        End If

                    End Using

                    If ContinueGenerateOrders Then

                        SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts = MediaManagerGeneratePurchaseOrderVendorContactsToProcess.Where(Function(Entity) Entity.Process = True).ToList

                        Try

                            PONumbers = SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email).Select(Function(Entity) Entity.PONumber).Distinct.ToList

                            For Each PONumber In PONumbers

                                OrderStatus = True
                                OrderStatusMessage = ""

                                Try

                                    MediaManagerGeneratePurchaseOrderVendorContact = SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.PONumber = PONumber).First

                                    AdvantageFramework.MediaManager.SetPrintedPOFlag(Session, PONumber)

                                    Report = AdvantageFramework.Reporting.Reports.CreateReport(Session, Reporting.ReportTypes.PurchaseOrderReport, GetPurchaseOrderReportParameterDictionary(Session, PONumber), Nothing, Nothing, Nothing, Nothing)

                                    If Report IsNot Nothing Then

                                        MediaManagerGeneratedPOReportID = AdvantageFramework.MediaManager.CreateUpdateGeneratedPOReport(Session, MediaManagerGeneratePurchaseOrderVendorContact)

                                        Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

                                        MemoryStream = New System.IO.MemoryStream()

                                        Report.ExportToPdf(MemoryStream)

                                        Attachments.Add(New Email.Classes.Attachment("Purchase Order Report " & MediaManagerGeneratePurchaseOrderVendorContact.PONumber & ".pdf", MemoryStream.ToArray))

                                        EmailSubjectPrefix = "Purchase Order "

                                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                                        HtmlEmail.AddHeaderRow("Purchase Order Instructions Below")
                                        HtmlEmail.AddCustomRow(Nothing, 3, Nothing, "#FF0000", "<a href=""" & WebvantageURL & "MediaManager/PurchaseOrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaManagerGeneratedPOReportID=" & MediaManagerGeneratedPOReportID & "&Email=" & MediaManagerGeneratePurchaseOrderVendorContact.VendorContactEmail) & "%7C"" > Click Here</a> to View the Purchase Order")

                                        HtmlEmail.AddBlankRow()
                                        HtmlEmail.AddBlankRow()

                                        HtmlEmail.AddHeaderRow("Message")

                                        If Not String.IsNullOrWhiteSpace(Body) Then

                                            HtmlEmail.AddCustomRow(Body.Replace(vbCrLf, "<br />"))

                                        End If

                                        HtmlEmail.Finish()

                                        If AdvantageFramework.Email.Send(DbContext, MediaManagerGeneratePurchaseOrderVendorContact.VendorContactEmail, "", "",
                                                                         If(String.IsNullOrWhiteSpace(Subject) = True, EmailSubjectPrefix & MediaManagerGeneratePurchaseOrderVendorContact.PONumber & " from " & Agency.Name & " – Important Message – Do Not Delete – Open Immediately", Subject),
                                                                         HtmlEmail.ToString, 3, Attachments, SendingEmailStatus) = False Then

                                            OrderStatus = False
                                            AtLeastOneEmailFailed = True

                                        End If

                                        If CCSender AndAlso String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                                            HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                                            HtmlEmail.AddHeaderRow("Purchase Order Instructions Below")
                                            HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "MediaManager/PurchaseOrderForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaManagerGeneratedPOReportID=" & MediaManagerGeneratedPOReportID & "&Email=" & EmployeeEmailAddress) & "%7C"" > Click Here</a> to View the Purchase Order")

                                            HtmlEmail.AddHeaderRow("Message")

                                            If Not String.IsNullOrWhiteSpace(Body) Then

                                                HtmlEmail.AddCustomRow(Body.Replace(vbCrLf, "<br />"))

                                            End If

                                            HtmlEmail.Finish()

                                            AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "",
                                                                          If(String.IsNullOrWhiteSpace(Subject) = True, EmailSubjectPrefix & MediaManagerGeneratePurchaseOrderVendorContact.PONumber & " from " & Agency.Name & " – Important Message – Do Not Delete – Open Immediately", Subject),
                                                                          HtmlEmail.ToString, 3, Attachments, SendingEmailStatus)

                                        End If

                                        AdvantageFramework.MediaManager.SetPurchaseOrderStatusGenerated(Session, MediaManagerGeneratePurchaseOrderVendorContact)

                                        'If UploadDocumentManager Then

                                        '    SendToDocumentManager(DbContext, Report, Agency, GenerateOrder.VendorCode, OrderNumber, GenerateOrder.MediaFrom, EmailSubjectPrefix)

                                        'End If

                                    End If

                                Catch ex As Exception
                                    OrderStatus = False
                                    OrderStatusMessage = "Failed trying to create order and/or email."
                                    AtLeastOneEmailFailed = True
                                End Try

                                For Each SuccessfulMediaManagerGeneratePurchaseOrderVendorContact In SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.PONumber = PONumber).ToList

                                    SuccessfulMediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = OrderStatusMessage

                                Next

                            Next

                        Catch ex As Exception

                        End Try

                        'Try

                        '    PONumbers = SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print).Select(Function(Entity) Entity.PONumber).Distinct.ToList

                        '    For Each PONumber In PONumbers

                        '        OrderStatus = True
                        '        OrderStatusMessage = ""
                        '        SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts = Nothing

                        '        Try

                        '            GenerateOrder = SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.PONumber = PONumber).First
                        '            ReportGeneratedOrders = SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.PONumber = PONumber).ToList

                        '            Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, OrderNumber, LineNumbers, GenerateOrder.MediaFrom)

                        '            If Report IsNot Nothing Then

                        '                MediaManagerGeneratedReportID = AdvantageFramework.MediaManager.CreateUpdateGeneratedOrderReport(Session, OrderNumber, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                        '                If HasPrintedFirstReport = False Then

                        '                    PrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                        '                    AddHandler PrintTool.PrintingSystem.StartPrint, AddressOf PrintingSystem_StartPrint

                        '                    HasPrintedFirstReport = PrintTool.PrintDialog(UserLookAndFeel).GetValueOrDefault(False)

                        '                Else

                        '                    PrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

                        '                    AddHandler PrintTool.PrintingSystem.StartPrint, AddressOf PrintTool_StartPrint

                        '                    PrintTool.Print()

                        '                End If

                        '                If HasPrintedFirstReport Then

                        '                    For Each GenerateOrderVendorRep In GenerateOrder.GetGenerateOrderVendorReps.Where(Function(GOVR) GOVR.Process = True).ToList

                        '                        AdvantageFramework.MediaManager.CreateGeneratedOrderReportSentInfo(Session, MediaManagerGeneratedReportID, GenerateOrderVendorRep.VendorCode, GenerateOrderVendorRep.VendorRepCode, GenerateOrderVendorRep.VendorRepEmail)

                        '                    Next

                        '                    AdvantageFramework.MediaManager.SetOrderStatusGenerated(Session, ReportGeneratedOrders, GenerateOrder.MediaFrom)

                        '                    'If UploadDocumentManager Then

                        '                    '    SendToDocumentManager(DbContext, Report, Agency, GenerateOrder.VendorCode, OrderNumber, GenerateOrder.MediaFrom, EmailSubjectPrefix)

                        '                    'End If

                        '                    OrderStatus = True

                        '                Else

                        '                    Exit For

                        '                End If

                        '            End If

                        '        Catch ex As Exception
                        '            OrderStatus = False
                        '            OrderStatusMessage = "Failed trying to create order and/or print."
                        '        End Try

                        '        For Each SuccessfulMediaManagerGeneratePurchaseOrderVendorContact In SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.PONumber = PONumber).ToList

                        '            SuccessfulMediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = OrderStatusMessage

                        '        Next

                        '    Next

                        '    If HasPrintedFirstReport = False Then

                        '        For Each SuccessfulMediaManagerGeneratePurchaseOrderVendorContact In SuccessfulMediaManagerGeneratePurchaseOrderVendorContacts.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print).ToList

                        '            SuccessfulMediaManagerGeneratePurchaseOrderVendorContact.OrderMessage = "Printing was cancelled."

                        '        Next

                        '    End If

                        'Catch ex As Exception

                        'End Try

                        Processed = True

                    Else

                        For Each GenerateOrder In MediaManagerGeneratePurchaseOrderVendorContactsToProcess.ToList

                            GenerateOrder.OrderMessage = "User cancellation of order generation."

                        Next

                        Processed = False

                    End If

                End Using

            Catch ex As Exception
                Processed = False
            End Try

        End If

        ProcessGeneratePurchaseOrders = Processed

    End Function
    Public Function ProcessGenerateRFPs(Session As AdvantageFramework.Security.Session, GenerateRFPVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep),
                                        SubjectIn As String, BodyIn As String, CCSender As Boolean, ByRef AtLeastOneEmailFailed As Boolean) As Boolean

        'objects
        Dim AlertSubject As String = Nothing
        Dim Processed As Boolean = True
        Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim WebvantageURL As String = ""
        Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim ErrorMessage As String = Nothing
        Dim MediaRFPHeaderID As Integer = 0
        Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
        Dim MediaRFPHeaderStatus As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing
        Dim AlertID As Integer = 0
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
        Dim EmployeeEmailAddress As String = Nothing
        Dim HtmlEmailBody As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim EmailSubject As String = Nothing
        Dim EmailBody As String = Nothing
        Dim RFPReport As AdvantageFramework.DTO.Media.RFP.RFPReport = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

            If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode) IsNot Nothing Then

                EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

            End If

            For Each VendorCode In GenerateRFPVendorRepList.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email).Select(Function(Entity) Entity.VendorCode).Distinct.ToList

                MediaRFPHeaderID = (From Entity In GenerateRFPVendorRepList
                                    Where Entity.VendorCode = VendorCode
                                    Select Entity).First.MediaRFPHeaderID

                MediaRFPHeader = DbContext.MediaRFPHeaders.Find(MediaRFPHeaderID)

                If MediaRFPHeader IsNot Nothing Then

                    AlertSubject = "Media Request for Proposal: " & MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name & " | " & MediaRFPHeader.MediaBroadcastWorksheetMarket.Market.Description & " | " & MediaRFPHeader.Vendor.Name

                    If String.IsNullOrWhiteSpace(SubjectIn) Then

                        EmailSubject = AlertSubject

                    Else

                        EmailSubject = SubjectIn

                    End If

                    UpdateMediaRFPHeader(DbContext, MediaRFPHeader)

                    HtmlEmailBody = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                    If Not String.IsNullOrWhiteSpace(BodyIn) Then

                        HtmlEmailBody.AddCustomRow(BodyIn)
                        HtmlEmailBody.AddBlankRow()

                    End If

                    If Not String.IsNullOrWhiteSpace(GenerateRFPVendorRepList.Where(Function(VR) VR.VendorCode = VendorCode).FirstOrDefault.CommentToVendor) Then

                        HtmlEmailBody.AddCustomRow(GenerateRFPVendorRepList.Where(Function(VR) VR.VendorCode = VendorCode).FirstOrDefault.CommentToVendor)
                        HtmlEmailBody.AddBlankRow()

                    End If

                    EmailBody = IIf(String.IsNullOrWhiteSpace(BodyIn), "", BodyIn) & vbCrLf & GenerateRFPVendorRepList.Where(Function(VR) VR.VendorCode = VendorCode).FirstOrDefault.CommentToVendor & vbCrLf

                    EmailBody += CreateRFPReport(Session, DbContext, MediaRFPHeader, HtmlEmailBody, RFPReport)

                    HtmlEmailBody.Finish()

                    'Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, OrderNumber, LineNumbers, GenerateOrder.MediaFrom)

                    If MediaRFPHeader.AlertID.HasValue Then

                        AlertID = MediaRFPHeader.AlertID.Value

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, MediaRFPHeader.AlertID)

                        If Alert IsNot Nothing Then

                            Alert.Body = EmailBody
                            Alert.EmailBody = Replace(HtmlEmailBody.ToString, vbCrLf, "<br/>")

                            Alert.LastUpdated = Now
                            Alert.DueDate = MediaRFPHeader.DueDate
                            Alert.TimeDue = MediaRFPHeader.TimeDue

                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                            InsertAlertCommentsForRFP(DbContext, GenerateRFPVendorRepList, VendorCode, Alert.ID, BodyIn)

                            UpdateAlertRecipients(Session, Alert, GenerateRFPVendorRepList.Where(Function(VR) VR.MediaRFPHeaderID = MediaRFPHeader.ID).FirstOrDefault.AlertRecipientEmployeeCodes)

                            AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[Alert Updated]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

                        End If

                    Else

                        If Not CreateRFPAlert(Session, MediaRFPHeader, VendorCode, AlertSubject, EmailBody, HtmlEmailBody.ToString, GenerateRFPVendorRepList, ErrorMessage, AlertID) Then

                            Throw New Exception(ErrorMessage)

                        End If

                    End If

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, MediaRFPHeaderID)
                        Where Entity.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Generated).Any = False Then

                        MediaRFPHeaderStatus = New AdvantageFramework.Database.Entities.MediaRFPHeaderStatus
                        MediaRFPHeaderStatus.CreatedDate = Now
                        MediaRFPHeaderStatus.CreatedByUserCode = DbContext.UserCode
                        MediaRFPHeaderStatus.MediaRFPHeaderID = MediaRFPHeaderID
                        MediaRFPHeaderStatus.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Generated

                        DbContext.MediaRFPHeaderStatuses.Add(MediaRFPHeaderStatus)

                        DbContext.SaveChanges()

                    Else

                        MediaRFPHeaderStatus = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, MediaRFPHeaderID)
                                                Where Entity.MediaRFPStatusID = AdvantageFramework.Database.Entities.MediaRFPStatusID.Generated).SingleOrDefault

                        MediaRFPHeaderStatus.CreatedDate = Now
                        MediaRFPHeaderStatus.CreatedByUserCode = DbContext.UserCode

                        DbContext.Entry(MediaRFPHeaderStatus).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                    End If

                    For Each VendorRepEmail In GenerateRFPVendorRepList.Where(Function(Entity) Entity.VendorCode = VendorCode).Select(Function(Entity) Entity.VendorRepEmail).ToList

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        'HtmlEmail.AddHeaderRow("RFP Instructions Below")

                        'Tests:
                        'HtmlEmail.AddHyperlinkRow(WebvantageURL & "MediaManager/RequestForProposalForm", "Test link with no querystring")
                        'HtmlEmail.AddHyperlinkRow(WebvantageURL & "MediaManager/RequestForProposalForm?q=1", "Test link with simple querystring")
                        'HtmlEmail.AddHyperlinkRow(WebvantageURL & "MediaManager/RequestForProposalForm?q=|" &
                        '                          AdvantageFramework.Security.LicenseKey.Encrypt("Database=" & Session.DatabaseName & "&MediaRFPHeaderID=" & MediaRFPHeaderID & "&Email=" & VendorRepEmail) & "|",
                        '                          "Test link with querystring key")
                        ' NOTE: The WebvantageURL if set to localhost will NOT show in in GMAIL

                        HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "MediaManager/RequestForProposalForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaRFPHeaderID=" & MediaRFPHeaderID & "&Email=" & VendorRepEmail) & "%7C"" > Click Here</a> to View the RFP")


                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.AddHeaderRow("Message")

                        If Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                            HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                        End If

                        HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                        AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                        HtmlEmail.Finish()

                        If AdvantageFramework.Email.Send(DbContext, VendorRepEmail, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus) = False Then

                            AtLeastOneEmailFailed = True

                        End If

                    Next

                    If CCSender AndAlso String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                        HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        'HtmlEmail.AddHeaderRow("RFP Instructions Below")
                        HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "MediaManager/RequestForProposalForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaRFPHeaderID=" & MediaRFPHeaderID & "&Email=" & EmployeeEmailAddress) & "%7C"" > Click Here</a> to View the RFP")

                        HtmlEmail.AddBlankRow()
                        HtmlEmail.AddBlankRow()

                        HtmlEmail.AddHeaderRow("Message")

                        If Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                            HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                        End If

                        HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                        AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                        HtmlEmail.Finish()

                        AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus)

                    End If

                End If

            Next

        End Using

        ProcessGenerateRFPs = Processed

    End Function
    Public Function CreateRFPReport(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader,
                                     ByRef HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail, ByRef RFPReport As AdvantageFramework.DTO.Media.RFP.RFPReport) As String

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
        Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        Dim MediaBroadcastWorksheetSecondaryDemos As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSecondaryDemo) = Nothing
        Dim MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting = Nothing
        Dim CPPOption As AdvantageFramework.Media.MediaRFPIncludeCPPSettings = AdvantageFramework.Media.Methods.MediaRFPIncludeCPPSettings.ShowTotal
        Dim GRPTotal As Decimal = 0
        Dim TotalBudgetAmount As Decimal = 0
        Dim GRPOption As AdvantageFramework.Media.MediaRFPIncludeGRPSettings = AdvantageFramework.Media.Methods.MediaRFPIncludeGRPSettings.Show

        StringBuilder = New System.Text.StringBuilder()

        If RFPReport Is Nothing Then

            RFPReport = New AdvantageFramework.DTO.Media.RFP.RFPReport

        End If

        If MediaRFPHeader.RequestDate.HasValue Then

            RFPReport.DateRequested = MediaRFPHeader.RequestDate.Value
            StringBuilder.AppendLine("Date Requested: " & MediaRFPHeader.RequestDate.Value.ToShortDateString)

            HtmlEmail.AddBoldKeyValueRow("Date Requested", MediaRFPHeader.RequestDate.Value.ToShortDateString)
            HtmlEmail.AddBlankRow()

        End If

        If MediaRFPHeader.DueDate.HasValue Then

            RFPReport.DateAvailsDue = MediaRFPHeader.DueDate.Value.ToShortDateString & If(String.IsNullOrWhiteSpace(MediaRFPHeader.TimeDue), "", " @ " & MediaRFPHeader.TimeDue)
            StringBuilder.AppendLine("Date Avails Due: " & RFPReport.DateAvailsDue)

            HtmlEmail.AddBoldKeyValueRow("Date Avails Due", MediaRFPHeader.DueDate.Value.ToShortDateString & If(String.IsNullOrWhiteSpace(MediaRFPHeader.TimeDue), "", " @ " & MediaRFPHeader.TimeDue))
            HtmlEmail.AddBlankRow()

        End If

        RFPReport.MarketDescription = MediaRFPHeader.MediaBroadcastWorksheetMarket.Market.Description
        StringBuilder.AppendLine("Market: " & RFPReport.MarketDescription)

        HtmlEmail.AddBoldKeyValueRow("Market", MediaRFPHeader.MediaBroadcastWorksheetMarket.Market.Description)
        HtmlEmail.AddBlankRow()

        If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen AndAlso Session.IsNielsenSetup Then

            If MediaRFPHeader.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value)

                    If NielsenTVBook IsNot Nothing Then

                        RFPReport.RatingsSource = "Nielsen" & Space(1) & MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & GetStreamName(NielsenTVBook)

                    End If

                    If MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.HasValue AndAlso MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value > 0 Then

                        NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value)

                        If NielsenTVBook IsNot Nothing Then

                            RFPReport.RatingsSource += " / " & MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & GetStreamName(NielsenTVBook)

                        End If

                    End If

                End Using

            ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.NeilsenRadioPeriodIDs.Count > 0 Then

                If MediaRFPHeader.MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                    RFPReport.RatingsSource = "Nielsen" & Space(1) & AdvantageFramework.Reporting.Reports.Media.GetRadioBooks(Session, MediaRFPHeader.MediaBroadcastWorksheetMarket.NeilsenRadioPeriodIDs)

                ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                    RFPReport.RatingsSource = "Eastlan" & Space(1) & AdvantageFramework.Reporting.Reports.Media.GetRadioBooks(Session, MediaRFPHeader.MediaBroadcastWorksheetMarket.NeilsenRadioPeriodIDs)

                End If

            End If

        ElseIf MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso Session.IsComscoreSetup AndAlso
                MediaRFPHeader.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.HasValue Then

            ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID.Value)

            If ComscoreTVBook IsNot Nothing Then

                RFPReport.RatingsSource = "Comscore" & Space(1) & MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year.ToString.Substring(2) & "-" & GetStreamName(ComscoreTVBook)

            End If

            If MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.HasValue AndAlso MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value > 0 Then

                ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID.Value)

                If ComscoreTVBook IsNot Nothing Then

                    RFPReport.RatingsSource += " / " & MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year.ToString.Substring(2) & "-" & GetStreamName(ComscoreTVBook)

                End If

            End If

        End If

        If Not String.IsNullOrWhiteSpace(RFPReport.RatingsSource) Then

            StringBuilder.AppendLine("Rating Source: " & RFPReport.RatingsSource)

            HtmlEmail.AddBoldKeyValueRow("Rating Source", RFPReport.RatingsSource)
            HtmlEmail.AddBlankRow()

        End If

        If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

            RFPReport.TargetAudience = MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.Description
            StringBuilder.AppendLine("Target Audience: " & RFPReport.TargetAudience)

            HtmlEmail.AddBoldKeyValueRow("Target Audience", RFPReport.TargetAudience)
            HtmlEmail.AddBlankRow()

        End If

        MediaBroadcastWorksheetSecondaryDemos = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetSecondaryDemo.LoadByMediaBroadcastWorksheetID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID).Include("MediaDemographic").ToList

        For Each MediaBroadcastWorksheetSecondaryDemo In MediaBroadcastWorksheetSecondaryDemos

            RFPReport.SecondaryTargetAudiences += MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.Description & Environment.NewLine

        Next

        If Not String.IsNullOrWhiteSpace(RFPReport.SecondaryTargetAudiences) Then

            StringBuilder.AppendLine("Secondary Target Audience(s): " & RFPReport.SecondaryTargetAudiences)

            HtmlEmail.AddBoldKeyValueRow("Secondary Target Audience(s)", RFPReport.SecondaryTargetAudiences)
            HtmlEmail.AddBlankRow()

        End If

        MediaRFPPrintSetting = AdvantageFramework.Database.Procedures.MediaRFPPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode)

        If MediaRFPPrintSetting IsNot Nothing Then

            CPPOption = MediaRFPPrintSetting.IncludeCPP
            GRPOption = MediaRFPPrintSetting.IncludeGRP

        End If

        For Each MediaBroadcastWorksheetMarketGoal In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketGoal.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaRFPHeader.MediaBroadcastWorksheetMarket.ID).Include("Daypart").Include("MediaBroadcastWorksheetMarketGoalDates").ToList

            If MediaBroadcastWorksheetMarketGoal.Daypart IsNot Nothing Then

                RFPReport.Daypart += MediaBroadcastWorksheetMarketGoal.Daypart.Code & "/"

            End If

            RFPReport.Daypart += MediaBroadcastWorksheetMarketGoal.Length & " - " & FormatNumber(MediaBroadcastWorksheetMarketGoal.BudgetPercentage * 100, 0) & "%, "

            If CPPOption = AdvantageFramework.Media.Methods.MediaRFPIncludeCPPSettings.ShowTotal Then

                TotalBudgetAmount += MediaBroadcastWorksheetMarketGoal.BudgetAmount

            ElseIf CPPOption = AdvantageFramework.Media.Methods.MediaRFPIncludeCPPSettings.ShowByDaypart Then

                If MediaBroadcastWorksheetMarketGoal.Daypart IsNot Nothing Then

                    RFPReport.CPPGoal += MediaBroadcastWorksheetMarketGoal.Daypart.Code & "/"

                End If

                RFPReport.CPPGoal += MediaBroadcastWorksheetMarketGoal.Length & " - " & FormatNumber(MediaBroadcastWorksheetMarketGoal.CPP, 2) & ", "

            End If

            GRPTotal += MediaBroadcastWorksheetMarketGoal.GRP

            'Commenting out 2022-01-12 we should just load from worksheet 735-2-129 - Add a Print Preview of the RFP that is being sent out so they can check before they send
            'If RFPReport.FlightDates = "" Then

            '    For Each MediaBroadcastWorksheetMarketGoalDate In MediaBroadcastWorksheetMarketGoal.MediaBroadcastWorksheetMarketGoalDates

            '        If Not MediaBroadcastWorksheetMarketGoalDate.IsHiatus Then

            '            RFPReport.FlightDates += MediaBroadcastWorksheetMarketGoalDate.Date.ToShortDateString & ", "

            '        End If

            '    Next

            'End If

        Next

        If RFPReport.FlightDates = "" Then

            If MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails IsNot Nothing AndAlso MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Count > 0 Then

                For Each DtlDate In MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.First.MediaBroadcastWorksheetMarketDetailDates

                    If Not DtlDate.IsHiatus Then

                        RFPReport.FlightDates += DtlDate.Date.ToShortDateString & ", "

                    End If

                Next

            End If

        End If

        RFPReport.GRPGoal = GRPTotal

        If Not String.IsNullOrWhiteSpace(RFPReport.Daypart) AndAlso RFPReport.Daypart.Length > 2 Then

            RFPReport.Daypart = RFPReport.Daypart.Substring(0, RFPReport.Daypart.Length - 2)

        End If

        If Not String.IsNullOrWhiteSpace(RFPReport.Daypart) Then

            StringBuilder.AppendLine("Daypart/Length: " & RFPReport.Daypart)

            HtmlEmail.AddBoldKeyValueRow("Daypart/Length", RFPReport.Daypart)
            HtmlEmail.AddBlankRow()

        End If

        If Not String.IsNullOrWhiteSpace(RFPReport.FlightDates) AndAlso RFPReport.FlightDates.Length > 2 Then

            RFPReport.FlightDates = RFPReport.FlightDates.Substring(0, RFPReport.FlightDates.Length - 2)

            StringBuilder.AppendLine("Flight Dates: " & RFPReport.FlightDates)
            HtmlEmail.AddBoldKeyValueRow("Flight Dates", RFPReport.FlightDates)
            HtmlEmail.AddBlankRow()

        End If

        If CPPOption = AdvantageFramework.Media.Methods.MediaRFPIncludeCPPSettings.ShowTotal Then

            If GRPTotal <> 0 Then

                RFPReport.CPPGoal = FormatNumber(TotalBudgetAmount / GRPTotal, 2)

                StringBuilder.AppendLine("CPP Goal: " & RFPReport.CPPGoal)
                HtmlEmail.AddBoldKeyValueRow("CPP Goal", RFPReport.CPPGoal)
                HtmlEmail.AddBlankRow()

            End If

        ElseIf CPPOption = AdvantageFramework.Media.Methods.MediaRFPIncludeCPPSettings.ShowByDaypart AndAlso Not String.IsNullOrWhiteSpace(RFPReport.CPPGoal) Then

            StringBuilder.AppendLine("CPP Goal: " & RFPReport.CPPGoal)
            HtmlEmail.AddBoldKeyValueRow("CPP Goal", RFPReport.CPPGoal)
            HtmlEmail.AddBlankRow()

        End If

        If GRPOption = AdvantageFramework.Media.Methods.MediaRFPIncludeGRPSettings.Show AndAlso CDec(RFPReport.GRPGoal) <> 0 Then

            StringBuilder.AppendLine("GRP Goal: " & RFPReport.GRPGoal)
            HtmlEmail.AddBoldKeyValueRow("GRP Goal", RFPReport.GRPGoal)
            HtmlEmail.AddBlankRow()

        End If

        If Not String.IsNullOrWhiteSpace(MediaRFPHeader.MediaBroadcastWorksheetMarket.RFPGuidelines) Then

            RFPReport.AdditionalGuidelines = MediaRFPHeader.MediaBroadcastWorksheetMarket.RFPGuidelines
            StringBuilder.AppendLine("Additional Guidelines: " & RFPReport.AdditionalGuidelines)
            HtmlEmail.AddBoldKeyValueRow("Additional Guidelines", RFPReport.AdditionalGuidelines)
            HtmlEmail.AddBlankRow()

        End If

        CreateRFPReport = StringBuilder.ToString

    End Function
    Private Sub UpdateMediaRFPHeader(DbContext As AdvantageFramework.Database.DbContext, ByRef MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader)

        If Not MediaRFPHeader.RequestDate.HasValue Then

            MediaRFPHeader.RequestDate = Now.ToShortDateString

        End If

        If Not MediaRFPHeader.DueDate.HasValue Then

            MediaRFPHeader.DueDate = Now.AddDays(7).ToShortDateString

        End If

        If String.IsNullOrWhiteSpace(MediaRFPHeader.TimeDue) Then

            MediaRFPHeader.TimeDue = "5 PM"

        End If

        DbContext.TryAttach(MediaRFPHeader)
        DbContext.Entry(MediaRFPHeader).State = Entity.EntityState.Modified
        DbContext.SaveChanges()

    End Sub
    Private Function CreateRFPAlert(Session As AdvantageFramework.Security.Session, MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader, VendorCode As String, Subject As String, Body As String, HtmlBody As String,
                                    GenerateRFPVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep), ByRef ErrorMessage As String, ByRef AlertID As Integer) As Boolean

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AlertCreated As Boolean = False
        Dim EmailSent As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Alert = New AdvantageFramework.Database.Entities.Alert

                Alert.DbContext = DbContext

                Alert.AlertTypeID = AdvantageFramework.Database.Entities.AlertTypes.Alert
                Alert.ClientCode = MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ClientCode
                Alert.DivisionCode = MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.DivisionCode
                Alert.ProductCode = MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ProductCode

                Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated
                Alert.PriorityLevel = 3
                Alert.Subject = Subject
                Alert.Body = Body
                Alert.EmailBody = Replace(HtmlBody, vbCrLf, "<br/>")
                Alert.GeneratedDate = System.DateTime.Now
                Alert.IsWorkItem = False
                Alert.EmployeeCode = Session.User.EmployeeCode
                Alert.UserCode = Session.User.UserCode
                Alert.IsCPAlert = Nothing
                Alert.ClientContactID = Nothing
                Alert.VendorCode = VendorCode

                Alert.StartDate = Now.ToShortDateString
                Alert.DueDate = MediaRFPHeader.DueDate
                Alert.TimeDue = MediaRFPHeader.TimeDue
                Alert.AlertLevel = "MRFP"
                Alert.VendorCode = VendorCode

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                    AlertID = Alert.ID

                    If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(Employee) Then

                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, Employee.Email, Nothing, 1, 0, Nothing)

                    End If

                    UpdateAlertRecipients(Session, Alert, GenerateRFPVendorRepList.Where(Function(VR) VR.MediaRFPHeaderID = MediaRFPHeader.ID).FirstOrDefault.AlertRecipientEmployeeCodes)

                    InsertAlertCommentsForRFP(DbContext, GenerateRFPVendorRepList, VendorCode, AlertID, Body)

                    AlertCreated = True

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_RFP_HEADER SET ALERT_ID = {0} WHERE MEDIA_RFP_HEADER_ID = {1}", AlertID, MediaRFPHeader.ID))

                    EmailSent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

                End If

            End Using

        Catch ex As Exception
            ErrorMessage = ex.Message
            AlertCreated = False
        Finally
            CreateRFPAlert = AlertCreated
        End Try

    End Function
    Private Sub InsertAlertCommentsForRFP(DbContext As AdvantageFramework.Database.DbContext, GenerateRFPVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep),
                                          VendorCode As String, AlertID As Integer, BodyIn As String)

        Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

        For Each VenRep In (From Entity In GenerateRFPVendorRepList
                            Where Entity.VendorCode = VendorCode
                            Select Entity).ToList

            AlertComment = New AdvantageFramework.Database.Entities.AlertComment
            AlertComment.AlertID = AlertID
            AlertComment.UserCode = DbContext.UserCode
            AlertComment.GeneratedDate = Now

            If Not String.IsNullOrWhiteSpace(BodyIn) Then

                AlertComment.Comment = BodyIn & vbCrLf & "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            Else

                AlertComment.Comment = "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            End If

            AlertComment.VendorRepresentativeCode = VenRep.VendorRepCode
            AlertComment.DbContext = DbContext

            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

        Next

    End Sub
    Private Sub UpdateAlertRecipients(Session As AdvantageFramework.Security.Session, Alert As AdvantageFramework.Database.Entities.Alert, AlertRecipientEmployeeCodes As Generic.List(Of String))

        Dim AlertController As AdvantageFramework.Controller.Desktop.AlertController = Nothing
        Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

        AlertController = New AdvantageFramework.Controller.Desktop.AlertController(Session)

        AlertRecipients = AlertController.LoadAlertRecipients(Alert.ID)

        If AlertRecipientEmployeeCodes Is Nothing Then

            AlertRecipientEmployeeCodes = New Generic.List(Of String)

        End If

        AlertRecipientEmployeeCodes.Add(Alert.EmployeeCode)

        For Each AlertRecipient In AlertRecipients

            If AlertRecipientEmployeeCodes.Contains(AlertRecipient.EmployeeCode) = False Then

                AlertController.RemoveRecipient(Alert.ID, AlertRecipient.EmployeeCode)

            End If

        Next

        For Each EmpCode In AlertRecipientEmployeeCodes

            If Not AlertRecipients.Where(Function(AR) AR.EmployeeCode = EmpCode AndAlso AR.IsCurrentRecipient = True).Any Then

                AlertController.AddRecipient(Alert.ID, EmpCode)

            End If

        Next

    End Sub
    Public Function CalculateTVReach(BuyImpressions As Decimal, CumeImpressions As Long, TotalSpots As Integer, Universe As Long, Rating As Decimal, BookRating As Decimal) As Double

        'objects
        Dim Reach As Double = 0
        Dim CIOverU As Decimal = 0

        If CumeImpressions = 0 OrElse Rating <> BookRating Then

            'Reach = (1 - ((1 - (Rating / 100)) ^ TotalSpots))
            Reach = 0
            Reach = CalculateCumlessReach(Rating, TotalSpots)

        ElseIf Universe = 0 Then

            Reach = 0

        Else

            'Reach = (BuyImpressions / CumeImpressions)

            'Reach = (1 - Reach)

            'Reach = (1 - Reach ^ TotalSpots)

            'CIOverU = (CumeImpressions / Universe)

            'Reach = Reach * CIOverU

            Reach = (1 - (1 - (BuyImpressions / CumeImpressions)) ^ TotalSpots) * (CumeImpressions / Universe)

            If Reach < 0 OrElse Reach > (CumeImpressions / Universe) Then

                Reach = (CumeImpressions / Universe)

            End If

        End If

        Reach = Math.Round(Reach, 3)

        CalculateTVReach = Reach

    End Function
    Public Function CalculateRadioReach(AQH As Long, Cume As Long, TotalSpots As Integer, Universe As Long, Rating As Decimal, BookRating As Decimal) As Double

        'objects
        Dim Reach As Double = 0
        Dim CIOverU As Decimal = 0

        If Cume = 0 OrElse Rating <> BookRating Then

            'Reach = (1 - ((1 - (Rating / 100)) ^ TotalSpots))
            Reach = 0
            Reach = CalculateCumlessReach(Rating, TotalSpots)

        ElseIf Universe = 0 Then

            Reach = 0

        Else

            'Reach = (BuyImpressions / CumeImpressions)

            'Reach = (1 - Reach)

            'Reach = (1 - Reach ^ TotalSpots)

            'CIOverU = (CumeImpressions / Universe)

            'Reach = Reach * CIOverU

            Reach = (1 - (1 - (AQH / Cume)) ^ TotalSpots) * (Cume / Universe)

            If Reach < 0 OrElse Reach > (Cume / Universe) Then

                Reach = (Cume / Universe)

            End If

        End If

        Reach = Math.Round(Reach, 3)

        CalculateRadioReach = Reach

    End Function
    Public Function CalculateTVFrequency(GRP As Decimal, Reach As Decimal) As Decimal

        'objects
        Dim Frequency As Decimal = 0

        If Reach = 0 Then

            Frequency = 0

        Else

            Frequency = GRP / (Reach * 100)

        End If

        CalculateTVFrequency = Frequency

    End Function
    Public Function CalculateRadioFrequency(GRP As Decimal, Reach As Decimal) As Decimal

        'objects
        Dim Frequency As Decimal = 0

        If Reach = 0 Then

            Frequency = 0

        Else

            Frequency = GRP / (Reach * 100)

        End If

        CalculateRadioFrequency = Frequency

    End Function
    Public Function CalculateCumlessReach(Rating As Decimal, TotalSpots As Integer) As Double

        'objects
        Dim Reach As Double = 0
        Dim SpotReach As Double = 0
        Dim Factor As Double = 0

        Factor = 0.667

        If TotalSpots = 0 Then

            Reach = 0

        Else

            Reach = Rating

        End If

        For Spot As Integer = 2 To TotalSpots

            SpotReach = 100 * (1 - (1 - Rating / 100) ^ Spot)
            SpotReach = SpotReach - ((Spot - 1) * Rating * Factor)

            If Reach > SpotReach Then

                Exit For

            Else

                Reach = SpotReach

            End If

        Next

        If Reach <> 0 Then

            Reach = Reach / 100

        End If

        Reach = Math.Round(Reach, 3)

        CalculateCumlessReach = Reach

    End Function
    Public Function GetTemplateTable() As DataTable

        Dim TemplateTable As DataTable = Nothing

        TemplateTable = New DataTable With {
            .TableName = "XX"
        }

        TemplateTable.Columns.Add(New DataColumn("OnHold", System.Type.GetType("System.Boolean")))
        TemplateTable.Columns.Add(New DataColumn("VendorCode", System.Type.GetType("System.String")))
        TemplateTable.Columns.Add(New DataColumn("VendorNielsenTVStationCode", System.Type.GetType("System.String")))
        TemplateTable.Columns.Add(New DataColumn("CableNetworkNielsenTVStationCode", System.Type.GetType("System.String")))
        TemplateTable.Columns.Add(New DataColumn("VendorRadioStationComboID", System.Type.GetType("System.Int32")))

        TemplateTable.Columns.Add(New DataColumn("PrimaryImpressions", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryCumeImpressions", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryCume", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryUniverse", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("BookPrimaryRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryAQH", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("BookPrimaryAQHRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryGRP", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryReach", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("PrimaryFrequency", System.Type.GetType("System.Decimal")))

        TemplateTable.Columns.Add(New DataColumn("SecondaryImpressions", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryCumeImpressions", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryCume", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryUniverse", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("BookSecondaryRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryAQH", System.Type.GetType("System.Int64")))
        TemplateTable.Columns.Add(New DataColumn("BookSecondaryAQHRating", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryGRP", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryReach", System.Type.GetType("System.Decimal")))
        TemplateTable.Columns.Add(New DataColumn("SecondaryFrequency", System.Type.GetType("System.Decimal")))

        TemplateTable.Columns.Add(New DataColumn("Spots", System.Type.GetType("System.Int32")))

        GetTemplateTable = TemplateTable

    End Function
    Public Function LoadDataView(ByRef ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail),
                                  ByVal TemplateTable As DataTable) As DataView

        Dim XDataView As DataView = Nothing
        Dim DetailRow As DataRow

        For Each DetailLine In ReachFreqDetailLines

            DetailRow = TemplateTable.NewRow()

            DetailRow("OnHold") = DetailLine.OnHold
            DetailRow("VendorCode") = DetailLine.VendorCode
            DetailRow("VendorNielsenTVStationCode") = DetailLine.VendorNielsenTVStationCode
            DetailRow("CableNetworkNielsenTVStationCode") = DetailLine.CableNetworkNielsenTVStationCode

            If (DetailLine.VendorRadioStationComboID.HasValue) Then
                DetailRow("VendorRadioStationComboID") = DetailLine.VendorRadioStationComboID
            End If

            DetailRow("Spots") = DetailLine.Spots.GetValueOrDefault(0)

            DetailRow("PrimaryImpressions") = DetailLine.PrimaryBuyImpressions
            DetailRow("PrimaryCumeImpressions") = DetailLine.PrimaryCumeImpressions
            DetailRow("PrimaryCume") = DetailLine.PrimaryCume
            DetailRow("PrimaryUniverse") = DetailLine.PrimaryUniverse
            DetailRow("PrimaryRating") = DetailLine.PrimaryRating
            DetailRow("BookPrimaryRating") = DetailLine.PrimaryBookRating
            DetailRow("PrimaryAQH") = DetailLine.PrimaryAQH
            DetailRow("BookPrimaryAQHRating") = DetailLine.PrimaryBookAQHRating
            DetailRow("PrimaryGRP") = DetailLine.PrimaryGRP
            DetailRow("PrimaryReach") = DetailLine.PrimaryReach

            DetailRow("SecondaryImpressions") = DetailLine.SecondaryBuyImpressions
            DetailRow("SecondaryCumeImpressions") = DetailLine.SecondaryCumeImpressions
            DetailRow("SecondaryCume") = DetailLine.SecondaryCume
            DetailRow("SecondaryUniverse") = DetailLine.SecondaryUniverse
            DetailRow("SecondaryRating") = DetailLine.SecondaryRating
            DetailRow("BookSecondaryRating") = DetailLine.SecondaryBookRating
            DetailRow("SecondaryAQH") = DetailLine.SecondaryAQH
            DetailRow("BookSecondaryAQHRating") = DetailLine.SecondaryBookAQHRating
            DetailRow("SecondaryGRP") = DetailLine.SecondaryGRP
            DetailRow("SecondaryReach") = DetailLine.SecondaryReach

            TemplateTable.Rows.Add(DetailRow)

        Next

        XDataView = New DataView With {
            .Table = TemplateTable
        }

        LoadDataView = XDataView

    End Function
    Public Function LoadDetailDates(ByRef ReachFreqDetailLines As Generic.List(Of Database.Classes.ReachFreqDetail)) As Hashtable

        Dim DateHashTable = New Hashtable

        Dim DaysAndWeeks = ReachFreqDetailLines.Select(Function(X) New DayAndWeek(X.DetailDate, X.Spots)).Distinct.ToList

        For Each DetailDate In DaysAndWeeks
            If Not (DateHashTable.Contains(DetailDate.DetailDate)) Then
                DateHashTable.Add(DetailDate.DetailDate, DetailDate.Spots)
            End If
        Next

        LoadDetailDates = DateHashTable
    End Function
    Public Function GetStreamName(TVBook As Object) As String

        'objects
        Dim StreamName As String = Nothing

        Select Case TVBook.Stream

            Case "LO"

                StreamName = "L"

            Case "LS"

                StreamName = "LS"

            Case "L1"

                StreamName = "L1"

            Case "L3"

                StreamName = "L3"

            Case "L7"

                StreamName = "L7"

        End Select

        GetStreamName = StreamName

    End Function
    Private Function RadioPeriodSearch(ByRef NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod), ByVal RadioPeriod As Integer) As String

        Dim RPSearch As String = String.Empty

        If (RadioPeriod > 0) Then
            Dim NielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing

            NielsenRadioPeriod = NielsenRadioPeriods.FirstOrDefault(Function(Entity) Entity.ID = RadioPeriod)

            If NielsenRadioPeriod IsNot Nothing Then

                RPSearch = NielsenRadioPeriod.Description

            End If

        Else
            RPSearch = String.Empty
        End If

        RadioPeriodSearch = RPSearch

    End Function
    Public Function RadioPeriods(ByRef NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod), ByRef Period1 As Integer, ByRef Period2 As Integer, ByRef Period3 As Integer, ByRef Period4 As Integer, ByRef Period5 As Integer) As String

        Dim ListOfPeriods As String
        Dim RadioPeriod1 As String
        Dim RadioPeriod2 As String
        Dim RadioPeriod3 As String
        Dim RadioPeriod4 As String
        Dim RadioPeriod5 As String

        RadioPeriod1 = RadioPeriodSearch(NielsenRadioPeriods, Period1)
        RadioPeriod2 = RadioPeriodSearch(NielsenRadioPeriods, Period2)
        RadioPeriod3 = RadioPeriodSearch(NielsenRadioPeriods, Period3)
        RadioPeriod4 = RadioPeriodSearch(NielsenRadioPeriods, Period4)
        RadioPeriod5 = RadioPeriodSearch(NielsenRadioPeriods, Period5)

        If Not (String.IsNullOrEmpty(RadioPeriod2)) Then
            ListOfPeriods = RadioPeriod1 + "; " + RadioPeriod2 + "; " _
                + IIf(String.IsNullOrEmpty(RadioPeriod3), String.Empty, RadioPeriod3 + "; ") _
                + IIf(String.IsNullOrEmpty(RadioPeriod4), String.Empty, RadioPeriod4 + "; ") _
                + IIf(String.IsNullOrEmpty(RadioPeriod5), String.Empty, RadioPeriod5 + "; ")

        Else
            ListOfPeriods = RadioPeriod1
        End If

        ListOfPeriods = ListOfPeriods.Trim

        If (ListOfPeriods.EndsWith(";")) Then
            ListOfPeriods = ListOfPeriods.Substring(0, ListOfPeriods.Length - 1)
        End If
        RadioPeriods = ListOfPeriods
    End Function
    Private Sub AppendBuyerDetails(DbContext As AdvantageFramework.Database.DbContext, BroadcastOrdersForVendorRep As AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep,
                                   ByRef HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail)

        'objects
        Dim BuyerEmployeeCode As String = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        If BroadcastOrdersForVendorRep.MediaFrom = "TV" Then

            Try

                BuyerEmployeeCode = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, BroadcastOrdersForVendorRep.OrderNumber).BuyerEmployeeCode

            Catch ex As Exception

            End Try

        Else

            Try

                BuyerEmployeeCode = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, BroadcastOrdersForVendorRep.OrderNumber).BuyerEmployeeCode

            Catch ex As Exception

            End Try

        End If

        If Not String.IsNullOrWhiteSpace(BuyerEmployeeCode) Then

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, BuyerEmployeeCode)

            If Employee IsNot Nothing Then

                HtmlEmail.AddCustomRow(Employee.ToString)

                If Not String.IsNullOrWhiteSpace(Employee.Address) Then

                    HtmlEmail.AddCustomRow(Employee.Address)

                End If

                If Not String.IsNullOrWhiteSpace(Employee.Address2) Then

                    HtmlEmail.AddCustomRow(Employee.Address2)

                End If

                If Not String.IsNullOrWhiteSpace(Employee.City & ", " & Employee.State & "  " & Employee.Zip & "") Then

                    HtmlEmail.AddCustomRow(Employee.City & ", " & Employee.State & "  " & Employee.Zip & "")

                End If

                If Not String.IsNullOrWhiteSpace(Employee.PhoneNumber) Then

                    HtmlEmail.AddCustomRow(Employee.PhoneNumber)

                End If

                If Not String.IsNullOrWhiteSpace(Employee.Email) Then

                    HtmlEmail.AddCustomRow(Employee.Email)

                End If

            End If

        End If

    End Sub
    Public Function GetInternetOrderFormat(Session As AdvantageFramework.Security.Session, MediaType As String) As AdvantageFramework.Media.InternetOrderFormats

        Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, DbContext.UserCode, Mid(MediaType, 1, 1))

            If MediaOrderPrintSetting Is Nothing Then

                OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaType)

                MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting
                MediaOrderPrintSetting.UserCode = DbContext.UserCode.ToUpper
                MediaOrderPrintSetting.MediaType = MediaType

                OrderPrintSetting.Save(MediaOrderPrintSetting)

                AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, MediaOrderPrintSetting, Nothing)

            End If

        End Using

        GetInternetOrderFormat = MediaOrderPrintSetting.ReportFormat

    End Function
    Public Function GetLogoImage(Agency As AdvantageFramework.Database.Entities.Agency, LogoPath As String) As System.Drawing.Image

        Dim Image As System.Drawing.Image = Nothing
        Dim Impersonating As Boolean = False

        If Agency IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(LogoPath) Then

            If String.IsNullOrWhiteSpace(Agency.FileSystemUserName) = False AndAlso String.IsNullOrWhiteSpace(Agency.FileSystemDomain) = False AndAlso
                    String.IsNullOrWhiteSpace(Agency.FileSystemPassword) = False Then

                Impersonating = True

            End If

            Try

                If Impersonating Then

                    If AdvantageFramework.Security.Impersonate.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword)) Then

                        Image = System.Drawing.Image.FromFile(LogoPath)

                    End If

                Else

                    Image = System.Drawing.Image.FromFile(LogoPath)

                End If

            Catch ex As Exception

            End Try

            If Impersonating Then

                Try

                    AdvantageFramework.Security.Impersonate.EndImpersonation()

                Catch ex As Exception

                End Try

            End If

        End If

        GetLogoImage = Image

    End Function
    Private Function GetAlertID(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String) As Nullable(Of Integer)

        Dim AlertID As Nullable(Of Integer) = Nothing

        If MediaFrom = "T" Then

            If AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber) IsNot Nothing Then

                AlertID = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber).AlertID

            End If

        ElseIf MediaFrom = "R" Then

            If AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber) IsNot Nothing Then

                AlertID = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber).AlertID

            End If

        End If

        GetAlertID = AlertID

    End Function
    Private Function CreateMediaOrderAlert(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String,
                                           Subject As String, Body As String, HtmlBody As String,
                                           GenerateOrderVendorRepList As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep),
                                           AlertRecipientEmployeeCodes As Generic.List(Of String), ByRef ErrorMessage As String, ByRef AlertID As Integer, BodyIn As String) As Boolean

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AlertCreated As Boolean = False
        Dim EmailSent As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try

            Alert = New AdvantageFramework.Database.Entities.Alert
            Alert.DbContext = DbContext

            SetAlertProperties(DbContext, OrderNumber, MediaFrom, Alert)

            Alert.AlertTypeID = AdvantageFramework.Database.Entities.AlertTypes.Alert

            Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.OrderGenerated
            Alert.PriorityLevel = 3
            Alert.Subject = Subject
            Alert.Body = Body
            Alert.EmailBody = Replace(HtmlBody, vbCrLf, "<br/>")
            Alert.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
            Alert.IsWorkItem = False
            Alert.EmployeeCode = Session.User.EmployeeCode
            Alert.UserCode = Session.User.UserCode
            Alert.IsCPAlert = Nothing
            Alert.ClientContactID = Nothing

            Alert.AlertLevel = "MO"

            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                AlertID = Alert.ID

                If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(Employee) Then

                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, Employee.Email, Nothing, 1, 0, Nothing)

                End If

                UpdateAlertRecipients(Session, Alert, AlertRecipientEmployeeCodes)

                InsertAlertCommentsForOrder(DbContext, GenerateOrderVendorRepList, Alert.VendorCode, AlertID, BodyIn)

                AlertCreated = True

                If MediaFrom = "T" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.TV_HDR SET ALERT_ID = {0} WHERE ORDER_NBR = {1}", AlertID, OrderNumber))

                ElseIf MediaFrom = "R" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.RADIO_HDR SET ALERT_ID = {0} WHERE ORDER_NBR = {1}", AlertID, OrderNumber))

                End If

                EmailSent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

            End If

        Catch ex As Exception
            ErrorMessage = ex.Message
            AlertCreated = False
        Finally
            CreateMediaOrderAlert = AlertCreated
        End Try

    End Function
    Private Sub SetAlertProperties(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String, ByRef Alert As AdvantageFramework.Database.Entities.Alert)

        Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
        Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing

        If MediaFrom = "T" Then

            TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

            If TVOrder IsNot Nothing Then

                Alert.ClientCode = TVOrder.ClientCode
                Alert.DivisionCode = TVOrder.DivisionCode
                Alert.ProductCode = TVOrder.ProductCode
                Alert.VendorCode = TVOrder.VendorCode

            End If

        ElseIf MediaFrom = "R" Then

            RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

            If RadioOrder IsNot Nothing Then

                Alert.ClientCode = RadioOrder.ClientCode
                Alert.DivisionCode = RadioOrder.DivisionCode
                Alert.ProductCode = RadioOrder.ProductCode
                Alert.VendorCode = RadioOrder.VendorCode

            End If

        End If

    End Sub
    Private Sub InsertAlertCommentsForOrder(DbContext As AdvantageFramework.Database.DbContext, GenerateOrderVendorRepList As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep), VendorCode As String, AlertID As Integer,
                                            BodyIn As String)

        Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

        For Each VenRep In (From Entity In GenerateOrderVendorRepList
                            Where Entity.VendorCode = VendorCode
                            Select Entity).ToList

            AlertComment = New AdvantageFramework.Database.Entities.AlertComment
            AlertComment.AlertID = AlertID
            AlertComment.UserCode = DbContext.UserCode
            AlertComment.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

            If Not String.IsNullOrWhiteSpace(BodyIn) Then

                AlertComment.Comment = BodyIn & vbCrLf & "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            Else

                AlertComment.Comment = "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            End If

            AlertComment.VendorRepresentativeCode = VenRep.VendorRepCode
            AlertComment.DbContext = DbContext

            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

        Next

    End Sub
    Public Function GetOrderReport(DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Session As AdvantageFramework.Security.Session = Nothing
        Dim LineNumbers As Generic.List(Of Integer) = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        Try

            If MediaManagerGeneratedReport IsNot Nothing Then

                Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, MediaManagerGeneratedReport.CreatedByUserCode, 0, DbContext.ConnectionString)

                LineNumbers = New Generic.List(Of Integer)

                For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReport.ID).ToList

                    LineNumbers.Add(CInt(MediaManagerGeneratedReportDetail.LineNumber))

                Next

                Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, MediaManagerGeneratedReport.OrderNumber, LineNumbers, MediaManagerGeneratedReport.MediaFrom)

            End If

        Catch ex As Exception
            Report = Nothing
        End Try

        GetOrderReport = Report

    End Function
    Public Function SendToDocumentManager(DbContext As AdvantageFramework.Database.DbContext, Report As DevExpress.XtraReports.UI.XtraReport,
                                          Agency As AdvantageFramework.Database.Entities.Agency, VendorCode As String, OrderNumber As Integer,
                                          MediaFrom As String, Description As String, ByRef DocumentID As Integer) As Boolean

        'objects
        Dim SentToDocumentManager As Boolean = False
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim FileName As String = String.Empty
        Dim FileSystemFile As String = String.Empty
        Dim FileSystemFileName As String = String.Empty
        Dim FileSize As Integer = Integer.MinValue
        Dim MimeType As String = String.Empty
        Dim FinalLevelDescription As String = String.Empty
        Dim FinalLevel As String = String.Empty
        Dim Keywords As String = String.Empty
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim IsValid As Boolean = True
        Dim ErrorMessage As String = String.Empty
        Dim MagazineDocument As AdvantageFramework.Database.Entities.MagazineDocument = Nothing
        Dim NewspaperDocument As AdvantageFramework.Database.Entities.NewspaperDocument = Nothing
        Dim InternetDocument As AdvantageFramework.Database.Entities.InternetDocument = Nothing
        Dim OutOfHomeDocument As AdvantageFramework.Database.Entities.OutOfHomeDocument = Nothing
        Dim RadioDocument As AdvantageFramework.Database.Entities.RadioDocument = Nothing
        Dim TVDocument As AdvantageFramework.Database.Entities.TVDocument = Nothing

        IsValid = AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage)

        If IsValid Then

            MemoryStream = New System.IO.MemoryStream
            Report.ExportToPdf(MemoryStream)

            MimeType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(".pdf")
            FileSize = MemoryStream.Length
            FinalLevelDescription = AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder.ToString & ":" & OrderNumber
            FinalLevel = AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder.ToString
            Description = Description.Trim
            Keywords = Description
            FileName = Description & " SIGNED - " & VendorCode & " - " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & "_" & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#") & ".pdf"

            If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, FileName, Description, Keywords, DbContext.UserCode, FinalLevel,
                                                 FinalLevelDescription, AdvantageFramework.FileSystem.DocumentSource.DocumentUpload, FileSystemFile, FileSystemFileName, False) Then

                Document = New AdvantageFramework.Database.Entities.Document

                Document.DbContext = DbContext
                Document.FileName = FileName
                Document.FileSystemFileName = FileSystemFileName
                Document.MIMEType = MimeType
                Document.Description = Description
                Document.Keywords = Keywords
                Document.UploadedDate = System.DateTime.Now
                Document.UserCode = DbContext.UserCode
                Document.FileSize = FileSize
                Document.DocumentTypeID = 1
                Document.IsPrivate = False

                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                    If MediaFrom.Substring(0, 1) = "M" Then

                        MagazineDocument = New AdvantageFramework.Database.Entities.MagazineDocument

                        MagazineDocument.DocumentID = Document.ID
                        MagazineDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.MagazineDocument.Insert(DbContext, MagazineDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "N" Then

                        NewspaperDocument = New AdvantageFramework.Database.Entities.NewspaperDocument

                        NewspaperDocument.DocumentID = Document.ID
                        NewspaperDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.NewspaperDocument.Insert(DbContext, NewspaperDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "I" Then

                        InternetDocument = New AdvantageFramework.Database.Entities.InternetDocument

                        InternetDocument.DocumentID = Document.ID
                        InternetDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.InternetDocument.Insert(DbContext, InternetDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "O" Then

                        OutOfHomeDocument = New AdvantageFramework.Database.Entities.OutOfHomeDocument

                        OutOfHomeDocument.DocumentID = Document.ID
                        OutOfHomeDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.OutOfHomeDocument.Insert(DbContext, OutOfHomeDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "R" Then

                        RadioDocument = New AdvantageFramework.Database.Entities.RadioDocument

                        RadioDocument.DocumentID = Document.ID
                        RadioDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.RadioDocument.Insert(DbContext, RadioDocument)

                    ElseIf MediaFrom.Substring(0, 1) = "T" Then

                        TVDocument = New AdvantageFramework.Database.Entities.TVDocument

                        TVDocument.DocumentID = Document.ID
                        TVDocument.OrderNumber = OrderNumber

                        SentToDocumentManager = AdvantageFramework.Database.Procedures.TVDocument.Insert(DbContext, TVDocument)

                    End If

                End If

            End If

        End If

        If SentToDocumentManager AndAlso Document IsNot Nothing Then

            DocumentID = Document.ID

        End If

        SendToDocumentManager = SentToDocumentManager

    End Function
    Public Function GetOrderReportForMakegoods(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String, CreatedByUserCode As String) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Session As AdvantageFramework.Security.Session = Nothing
        Dim LineNumbers As Generic.List(Of Integer) = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
        Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
        Dim ReportFormat As Integer = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.Landscape

        Try

            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, DbContext.ConnectionString, CreatedByUserCode, 0, DbContext.ConnectionString)

            LineNumbers = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DISTINCT CAST(b.LINE_NBR as int)
                                                                                 FROM dbo.MEDIA_MGR_GENERATED_REPORT a
	                                                                                INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                 WHERE a.ORDER_NBR = {0}", OrderNumber)).ToList

            If MediaFrom.Substring(0, 1).ToUpper = "T" Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrder IsNot Nothing AndAlso TVOrder.Units = "DB" Then

                    ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.DailyBroadcastBySpot

                End If

            ElseIf MediaFrom.Substring(0, 1).ToUpper = "R" Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrder IsNot Nothing AndAlso RadioOrder.Units = "DB" Then

                    ReportFormat = AdvantageFramework.Media.Methods.BroadcastMediaOrderFormats.DailyBroadcastBySpot

                End If

            End If

            Report = AdvantageFramework.Reporting.Reports.CreateOrder(Session, OrderNumber, LineNumbers, MediaFrom, ReportFormat)

        Catch ex As Exception
            Report = Nothing
        End Try

        GetOrderReportForMakegoods = Report

    End Function
    Private Function CreateMediaTrafficAlert(Session As AdvantageFramework.Security.Session, MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket,
                                             Agency As AdvantageFramework.Database.Entities.Agency, Report As DevExpress.XtraReports.UI.XtraReport, ReportFileName As String,
                                             MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor, Subject As String, Body As String, HtmlBody As String, BodyIn As String,
                                             GenerateVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep), ByRef ErrorMessage As String, ByRef AlertID As Integer) As Boolean

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AlertCreated As Boolean = False
        Dim EmailSent As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Alert = New AdvantageFramework.Database.Entities.Alert

                Alert.DbContext = DbContext

                Alert.AlertTypeID = AdvantageFramework.Database.Entities.AlertTypes.Alert
                Alert.ClientCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ClientCode
                Alert.DivisionCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.DivisionCode
                Alert.ProductCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ProductCode

                Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.MediaTrafficGenerated
                Alert.PriorityLevel = 3
                Alert.Subject = Subject
                Alert.Body = Body
                Alert.EmailBody = Replace(HtmlBody, vbCrLf, "<br/>")
                Alert.GeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext) ' System.DateTime.Now
                Alert.IsWorkItem = False
                Alert.EmployeeCode = Session.User.EmployeeCode
                Alert.UserCode = Session.User.UserCode
                Alert.IsCPAlert = Nothing
                Alert.ClientContactID = Nothing
                Alert.VendorCode = MediaTrafficVendor.VendorCode

                Alert.StartDate = Now.ToShortDateString
                Alert.AlertLevel = "MTRF"
                Alert.VendorCode = MediaTrafficVendor.VendorCode

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                    AddReportToAlertAttachment(DbContext, Agency, Report, ReportFileName, Alert.ID)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode)

                    AlertID = Alert.ID

                    If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(Employee) Then

                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, Employee.Email, Nothing, 1, 0, Nothing)

                    End If

                    UpdateAlertRecipients(Session, Alert, GenerateVendorRepList.Where(Function(VR) VR.MediaTrafficVendorID = MediaTrafficVendor.ID).FirstOrDefault.AlertRecipientEmployeeCodes)

                    InsertAlertCommentsForMediaTraffic(DbContext, GenerateVendorRepList, MediaTrafficVendor.VendorCode, AlertID, BodyIn)

                    AlertCreated = True

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_TRAFFIC_VENDOR SET ALERT_ID = {0} WHERE MEDIA_TRAFFIC_VENDOR_ID = {1}", AlertID, MediaTrafficVendor.ID))

                    EmailSent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

                End If

            End Using

        Catch ex As Exception
            ErrorMessage = ex.Message
            AlertCreated = False
        Finally
            CreateMediaTrafficAlert = AlertCreated
        End Try

    End Function
    Private Sub InsertAlertCommentsForMediaTraffic(DbContext As AdvantageFramework.Database.DbContext, GenerateVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep),
                                                   VendorCode As String, AlertID As Integer, BodyIn As String)

        Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

        For Each VenRep In (From Entity In GenerateVendorRepList
                            Where Entity.VendorCode = VendorCode
                            Select Entity).ToList

            AlertComment = New AdvantageFramework.Database.Entities.AlertComment
            AlertComment.AlertID = AlertID
            AlertComment.UserCode = DbContext.UserCode
            AlertComment.GeneratedDate = Now

            If Not String.IsNullOrWhiteSpace(BodyIn) Then

                AlertComment.Comment = BodyIn & vbCrLf & "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            Else

                AlertComment.Comment = "Sent to: " & VenRep.VendorRep & " (" & VenRep.VendorRepEmail & ")"

            End If

            AlertComment.VendorRepresentativeCode = VenRep.VendorRepCode
            AlertComment.DbContext = DbContext

            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

        Next

    End Sub
    Public Function ProcessGenerateMediaTrafficInstructions(Session As AdvantageFramework.Security.Session, GenerateVendorRepList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep),
                                                            SubjectIn As String, BodyIn As String, CCSender As Boolean, ByRef AtLeastOneEmailFailed As Boolean) As Boolean

        'objects
        Dim AlertSubject As String = Nothing
        Dim Processed As Boolean = True
        Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
        Dim MediaBroadcastWorksheetMarketID As Integer = 0
        Dim WebvantageURL As String = ""
        Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim ErrorMessage As String = Nothing
        Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing
        Dim AlertID As Integer = 0
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
        Dim EmployeeEmailAddress As String = Nothing
        Dim HtmlEmailBody As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        Dim EmailSubject As String = Nothing
        Dim EmailBody As String = Nothing
        Dim MediaTrafficInstructionReport As AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport = Nothing
        Dim GeneratedString As String = Now.ToString("M/d/yyyy h:mm tt")
        Dim MediaTrafficController As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Dim MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel = Nothing
        Dim ReportFileName As String = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/")

            If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode) IsNot Nothing Then

                EmployeeEmailAddress = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Email

            End If

            For Each MediaTrafficVendorID In GenerateVendorRepList.Where(Function(Entity) Entity.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email).Select(Function(Entity) Entity.MediaTrafficVendorID).Distinct.ToList

                MediaTrafficVendor = DbContext.MediaTrafficVendors.Find(MediaTrafficVendorID)

                If MediaTrafficVendor IsNot Nothing Then

                    MediaBroadcastWorksheetMarketID = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketTraffic.Load(DbContext)
                                                       Where Entity.MediaTrafficID = MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID
                                                       Select Entity).Single.MediaBroadcastWorksheetMarketID

                    MediaTrafficController = New AdvantageFramework.Controller.Media.MediaTrafficController(Session)
                    MediaTrafficViewModel = MediaTrafficController.Load(MediaBroadcastWorksheetMarketID)

                    MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)

                    MediaTrafficInstructionReport = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport)(String.Format("exec advsp_media_traffic_instruction_report {0}, '{1}'", MediaTrafficVendorID, DbContext.UserCode)).FirstOrDefault

                    If MediaTrafficInstructionReport IsNot Nothing Then

                        AlertSubject = "Traffic Instruction REV" & MediaTrafficVendor.MediaTrafficRevision.RevisionNumber.ToString & " | Order #" & MediaTrafficInstructionReport.OrderNumber.ToString & ", " & MediaTrafficVendor.Vendor.Name & " | " & MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name & " | " & MediaBroadcastWorksheetMarket.Market.Description

                        If String.IsNullOrWhiteSpace(SubjectIn) Then

                            EmailSubject = AlertSubject

                        Else

                            EmailSubject = SubjectIn

                        End If

                        HtmlEmailBody = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                        If Not String.IsNullOrWhiteSpace(BodyIn) Then

                            HtmlEmailBody.AddCustomRow(BodyIn)
                            HtmlEmailBody.AddBlankRow()

                        End If

                        EmailBody = IIf(String.IsNullOrWhiteSpace(BodyIn), "", BodyIn) & vbCrLf

                        EmailBody += "Instruction #: " & MediaTrafficInstructionReport.InstructionNumber.ToString
                        EmailBody += "Revision #: " & MediaTrafficInstructionReport.RevisionNumber.ToString
                        EmailBody += "Generated: " & GeneratedString
                        EmailBody += "Schedule #: " & MediaTrafficInstructionReport.Schedule
                        EmailBody += "Schedule Flight Range: " & MediaTrafficInstructionReport.ScheduleFlightRange
                        EmailBody += "Instruction Dates: " & MediaTrafficInstructionReport.InstructionDates
                        EmailBody += "Agency: " & MediaTrafficInstructionReport.AgencyName
                        EmailBody += "Buyer: " & MediaTrafficInstructionReport.Buyer
                        EmailBody += "Client / Division: " & MediaTrafficInstructionReport.ClientDivision
                        EmailBody += "Product: " & MediaTrafficInstructionReport.Product
                        EmailBody += "Market / Station: " & MediaTrafficInstructionReport.Market
                        EmailBody += "Order Number: " & MediaTrafficInstructionReport.OrderNumber.ToString

                        HtmlEmailBody.AddBlankRow()
                        HtmlEmailBody.AddBoldKeyValueRow("Instruction #", MediaTrafficInstructionReport.InstructionNumber.ToString, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Revision #", MediaTrafficInstructionReport.RevisionNumber.ToString, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Generated", GeneratedString, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Schedule #", MediaTrafficInstructionReport.Schedule, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Schedule Flight Range", MediaTrafficInstructionReport.ScheduleFlightRange, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Instruction Dates", MediaTrafficInstructionReport.InstructionDates, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Agency", MediaTrafficInstructionReport.AgencyName, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Buyer", MediaTrafficInstructionReport.Buyer, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Client / Division", MediaTrafficInstructionReport.ClientDivision, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Product", MediaTrafficInstructionReport.Product, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Market / Station", MediaTrafficInstructionReport.Market, LeftColumnWidth:=200)
                        HtmlEmailBody.AddBoldKeyValueRow("Order Number", MediaTrafficInstructionReport.OrderNumber.ToString, LeftColumnWidth:=200)

                        If Not String.IsNullOrWhiteSpace(MediaBroadcastWorksheetMarket.TrafficGuidelines) Then

                            EmailBody += "Additional Guidelines: " & MediaBroadcastWorksheetMarket.TrafficGuidelines

                            HtmlEmailBody.AddBoldKeyValueRow("Additional Guidelines", MediaBroadcastWorksheetMarket.TrafficGuidelines, LeftColumnWidth:=200)

                        End If

                        HtmlEmailBody.Finish()

                        Report = AdvantageFramework.Reporting.Reports.CreateMediaTrafficReport(Session, MediaTrafficVendor.ID, MediaTrafficViewModel.Location, If(MediaTrafficViewModel.IncludeGuidelines, MediaTrafficViewModel.TrafficGuidelines, ""))
                        ReportFileName = "Traffic_Instruction_Report_" & MediaTrafficInstructionReport.OrderNumber.ToString & "_" & MediaTrafficInstructionReport.InstructionNumber.ToString & ".pdf"

                        If MediaTrafficVendor.AlertID.HasValue Then

                            AlertID = MediaTrafficVendor.AlertID.Value

                            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, MediaTrafficVendor.AlertID)

                            If Alert IsNot Nothing Then

                                AddReportToAlertAttachment(DbContext, Agency, Report, ReportFileName, Alert.ID)

                                Alert.Body = EmailBody
                                Alert.EmailBody = Replace(HtmlEmailBody.ToString, vbCrLf, "<br/>")
                                Alert.LastUpdated = Now

                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                                InsertAlertCommentsForMediaTraffic(DbContext, GenerateVendorRepList, MediaTrafficVendor.VendorCode, Alert.ID, BodyIn)

                                UpdateAlertRecipients(Session, Alert, GenerateVendorRepList.Where(Function(VR) VR.MediaTrafficVendorID = MediaTrafficVendor.ID).FirstOrDefault.AlertRecipientEmployeeCodes)

                                AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[Alert Updated]", IncludeOriginator:=True, ErrorMessage:=ErrorMessage, IncludeAlertVendorReps:=False)

                            End If

                        Else

                            If Not CreateMediaTrafficAlert(Session, MediaBroadcastWorksheetMarket, Agency, Report, ReportFileName, MediaTrafficVendor, AlertSubject, EmailBody, HtmlEmailBody.ToString, BodyIn, GenerateVendorRepList, ErrorMessage, AlertID) Then

                                Throw New Exception(ErrorMessage)

                            End If

                        End If

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID)
                            Where Entity.MediaTrafficStatus.ID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Generated).Any = False Then

                            MediaTrafficVendorStatus = New AdvantageFramework.Database.Entities.MediaTrafficVendorStatus
                            MediaTrafficVendorStatus.MediaTrafficVendorID = MediaTrafficVendorID
                            MediaTrafficVendorStatus.MediaTrafficStatusID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Generated
                            MediaTrafficVendorStatus.CreatedDate = Now
                            MediaTrafficVendorStatus.UserCreated = DbContext.UserCode

                            DbContext.MediaTrafficVendorStatuses.Add(MediaTrafficVendorStatus)

                            DbContext.SaveChanges()

                        Else

                            MediaTrafficVendorStatus = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID)
                                                        Where Entity.MediaTrafficStatus.ID = AdvantageFramework.Database.Entities.MediaTrafficStatusID.Generated).SingleOrDefault

                            MediaTrafficVendorStatus.CreatedDate = Now
                            MediaTrafficVendorStatus.UserCreated = DbContext.UserCode

                            DbContext.TryAttach(MediaTrafficVendorStatus)

                            DbContext.Entry(MediaTrafficVendorStatus).State = Entity.EntityState.Modified

                            DbContext.SaveChanges()

                        End If

                        For Each VendorRepEmail In GenerateVendorRepList.Where(Function(Entity) Entity.VendorCode = MediaTrafficVendor.VendorCode).Select(Function(Entity) Entity.VendorRepEmail).ToList

                            HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                            ' NOTE: The WebvantageURL if set to localhost will NOT show in in GMAIL

                            HtmlEmail.AddCustomRow("<a href=""" & WebvantageURL & "Media/MediaTraffic/TrafficInstructionForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & Session.DatabaseName & "&MediaTrafficID=" & MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID & "&VendorCode=" & MediaTrafficVendor.VendorCode & "&RevisionNumber=" & MediaTrafficVendor.MediaTrafficRevision.RevisionNumber & "&Email=" & VendorRepEmail) & "%7C"" > Click Here</a> to View the Traffic Instruction")

                            HtmlEmail.AddBlankRow()
                            HtmlEmail.AddBlankRow()

                            HtmlEmail.AddHeaderRow("Message")

                            If Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                                HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                            End If

                            HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                            AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                            HtmlEmail.Finish()

                            If AdvantageFramework.Email.Send(DbContext, VendorRepEmail, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus) = False Then

                                AtLeastOneEmailFailed = True

                            End If

                        Next

                        If CCSender AndAlso String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                            HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                            HtmlEmail.AddBlankRow()
                            HtmlEmail.AddBlankRow()

                            HtmlEmail.AddHeaderRow("Message")

                            If Not String.IsNullOrWhiteSpace(HtmlEmailBody.ToString) Then

                                HtmlEmail.AddCustomRow(HtmlEmailBody.ToString)

                            End If

                            HtmlEmail.AddCustomRow(AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(AlertID, False))

                            AdvantageFramework.AlertSystem.CommentsHistory(DbContext, False, AlertID, Agency, HtmlEmail)

                            HtmlEmail.Finish()

                            AdvantageFramework.Email.Send(DbContext, EmployeeEmailAddress, "", "", EmailSubject, Replace(HtmlEmail.ToString, vbCrLf, "<br/>"), 3, Attachments, SendingEmailStatus)

                        End If

                    End If

                End If

            Next

        End Using

        ProcessGenerateMediaTrafficInstructions = Processed

    End Function
    Public Function CreateMediaTrafficReport(ByVal Session As AdvantageFramework.Security.Session, MediaTrafficVendorID As Integer, Location As AdvantageFramework.Database.Entities.Location,
                                             Guidelines As String) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.Media.MediaTrafficReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.Media.MediaTrafficReport

        XtraReport.Session = Session
        XtraReport.MediaTrafficVendorID = MediaTrafficVendorID
        XtraReport.LocationEntity = Location
        XtraReport.Guidelines = Guidelines

        CreateMediaTrafficReport = XtraReport

    End Function
    Private Sub AddReportToAlertAttachment(DbContext As AdvantageFramework.Database.DbContext, Agency As AdvantageFramework.Database.Entities.Agency, Report As DevExpress.XtraReports.UI.XtraReport,
                                           ReportFileName As String, AlertID As Integer)

        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocumentID As Integer = 0
        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Dim FileSystemFile As String = Nothing

        If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, Nothing) Then

            MemoryStream = New System.IO.MemoryStream()

            Report.ExportToPdf(MemoryStream)

            If AdvantageFramework.FileSystem.Add(DbContext, Agency, MemoryStream, ReportFileName, "", "", DbContext.UserCode, DocumentSource:=FileSystem.DocumentSource.Alert, FileSystemFile:=FileSystemFile, AddToDocumentRepository:=True, DocumentID:=DocumentID) Then

                AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                AlertAttachment.DbContext = DbContext
                AlertAttachment.AlertID = AlertID
                AlertAttachment.UserCode = DbContext.UserCode
                AlertAttachment.GeneratedDate = Now
                AlertAttachment.HasEmailBeenSent = False
                AlertAttachment.DocumentID = DocumentID

                AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

            End If

        End If

    End Sub
    Private Function CreateProductionWIPAgedSummaryByClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.ProductionWIP.ProductionWIPAgedSummarybyClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.ProductionWIP.ProductionWIPAgedSummarybyClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            'XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            'XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateProductionWIPAgedSummaryByClient = XtraReport

    End Function
    Public Function GetNonBroadcastMediaOrderFormat(Session As AdvantageFramework.Security.Session, MediaType As String) As AdvantageFramework.Media.NonBroadcastMediaOrderFormats

        Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
        Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            MediaOrderPrintSetting = AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.LoadByUserCodeAndMediaType(DbContext, DbContext.UserCode, Mid(MediaType, 1, 1))

            If MediaOrderPrintSetting Is Nothing Then

                OrderPrintSetting = New AdvantageFramework.Media.Classes.OrderPrintSetting(MediaType)

                MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting
                MediaOrderPrintSetting.UserCode = DbContext.UserCode.ToUpper
                MediaOrderPrintSetting.MediaType = MediaType

                OrderPrintSetting.Save(MediaOrderPrintSetting)

                AdvantageFramework.Database.Procedures.MediaOrderPrintSetting.Insert(DbContext, MediaOrderPrintSetting, Nothing)

            End If

        End Using

        GetNonBroadcastMediaOrderFormat = MediaOrderPrintSetting.ReportFormat

    End Function
    Public Function CreateRFPReport(Session As AdvantageFramework.Security.Session, MediaRFPHeaderID As Integer) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.MediaManager.RequestForProposalReport

            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.RequestForProposalReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.MediaManager.RequestForProposalReport).MediaRFPHeaderID = MediaRFPHeaderID

        End If

        CreateRFPReport = Report

    End Function
    Public Function SetReportHeaderLogoLandscape(DbContext As AdvantageFramework.Database.DbContext, Location As AdvantageFramework.Database.Entities.Location, ByRef XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox) As Boolean

        'objects
        Dim LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
        Dim LogoIsSet As Boolean = False

        If Location IsNot Nothing AndAlso Location.LogoLocation = "C" Then 'Show logo

            If String.IsNullOrWhiteSpace(Location.LogoLandscapePath) = False AndAlso My.Computer.FileSystem.FileExists(Location.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = Location.LogoLandscapePath
                LogoIsSet = True

            Else

                LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Location.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                If LocationLogo IsNot Nothing AndAlso LocationLogo.Image IsNot Nothing Then

                    Using MemoryStream = New System.IO.MemoryStream(LocationLogo.Image)

                        XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                    End Using

                    LogoIsSet = True

                End If

            End If

        End If

        SetReportHeaderLogoLandscape = LogoIsSet

    End Function

#Region " Month End Reports "

    Private Function CreateMediaWIPAgedSummaryByMediaType(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyMediaType = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyMediaType

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPAgedSummaryByMediaType = XtraReport

    End Function
    Private Function CreateAccruedAccountsPayableByClientVendorPeriod(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccruedAccountsPayablebyClientVendorPeriod = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccruedAccountsPayablebyClientVendorPeriod

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateAccruedAccountsPayableByClientVendorPeriod = XtraReport

    End Function
    Private Function CreateMediaWIPAgedSummaryByClientBillingAPBalance(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientBillingAPBalance = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientBillingAPBalance

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPAgedSummaryByClientBillingAPBalance = XtraReport

    End Function
    Private Function CreateMediaWIPDetailByGLAccount(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPDetailbyGLAccount = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPDetailbyGLAccount

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPDetailByGLAccount = XtraReport

    End Function
    Private Function CreateMediaWIPSummaryByVendorBalanceOnly(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyVendorBalanceOnly = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyVendorBalanceOnly

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPSummaryByVendorBalanceOnly = XtraReport

    End Function
    Private Function CreateMediaWIPSummaryByClientBalanceOnly(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientBalanceOnly = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientBalanceOnly

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPSummaryByClientBalanceOnly = XtraReport

    End Function
    Private Function CreateMediaOrdersWithZeroBalance(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaOrderswithZeroBalance = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaOrderswithZeroBalance

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaOrdersWithZeroBalance = XtraReport

    End Function
    Private Function CreateMediaWIPSummaryByClientPOBalanceOnly(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientPOBalanceOnly = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPSummarybyClientPOBalanceOnly

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPSummaryByClientPOBalanceOnly = XtraReport

    End Function
    Private Function CreateMediaWIPAgedSummaryByVendor(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyVendor = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyVendor

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPAgedSummaryByVendor = XtraReport

    End Function
    Private Function CreateMediaWIPAgedSummaryByClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.MediaWIPAgedSummarybyClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndMediaWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.order_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.OrderOption.ToString)

        End Using

        CreateMediaWIPAgedSummaryByClient = XtraReport

    End Function

    Private Function CreateAccountsReceivableAgedSummarybyClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedSummarybyClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedSummarybyClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedSummarybyClient = XtraReport

    End Function
    Private Function CreateAccountsReceivableAgedSummarybyProduct(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedSummarybyProduct = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedSummarybyProduct

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedSummarybyProduct = XtraReport

    End Function
    Private Function CreateAccountsReceivableAgedDetailbyClient(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyClient = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyClient

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedDetailbyClient = XtraReport

    End Function
    Private Function CreateAccountsReceivableAgedDetailbyClientNoGL(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyClientNoGLAccount = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyClientNoGLAccount

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            'XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedDetailbyClientNoGL = XtraReport

    End Function
    Private Function CreateAccountsReceivableAgedDetailbyProduct(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyProduct = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedDetailbyProduct

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedDetailbyProduct = XtraReport

    End Function
    Private Function CreateAccountsReceivableAgedwithDisbursementDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedwithDisbursementDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsReceivable.AccountsReceivableAgedwithDisbursementDetail

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsReceivable(ReportingDbContext, ParameterDictionary)

            XtraReport.UserID.Value = Session.UserCode
            XtraReport.PeriodCutoff.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.EndPeriod.ToString)
            XtraReport.AgingDate.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingDate.ToString)
            XtraReport.AgingOption.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.AgingOption.ToString)
            XtraReport.IncludeDetails.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndMediaWIPParameters.IncludeDetails.ToString)


        End Using

        CreateAccountsReceivableAgedwithDisbursementDetail = XtraReport

    End Function

    Private Function CreateProductionWIPDetailbyJobVendorOnly(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPDetailbyJobVendorOnly = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPDetailbyJobVendorOnly

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPDetailbyJobVendorOnly = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyJobwithEstimate(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithEstimate = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithEstimate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyJobwithEstimate = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyJobwithRecIncome(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithRecIncome = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithRecIncome

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyJobwithRecIncome = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyJobwithPayments(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithPayments = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobwithPayments

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyJobwithPayments = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyVendorwithPayments(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyVendorwithPayments = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyVendorwithPayments

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyVendorwithPayments = XtraReport

    End Function
    Private Function CreateProductionWIPAgedSummarybyJob(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJob = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJob

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPAgedSummarybyJob = XtraReport

    End Function
    Private Function CreateProductionWIPAgedSummarybyJobwithEstimate(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobwithEstimate = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobwithEstimate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPAgedSummarybyJobwithEstimate = XtraReport

    End Function
    Private Function CreateProductionWIPAgedSummarybyJobVendorOnly(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobVendorOnly = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobVendorOnly

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPAgedSummarybyJobVendorOnly = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyJobDeferredSalesCosIncluded(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobDefSalesCosInc = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobDefSalesCosInc

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyJobDeferredSalesCosIncluded = XtraReport

    End Function
    Private Function CreateProductionWIPSummarybyJobHoursDeferredSalesCos(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobHrsDefSalesCos = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobHrsDefSalesCos

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummarybyJobHoursDeferredSalesCos = XtraReport

    End Function

    Private Function CreateAccruedLiabilitySummarybyJobAPLimited(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobAPLimited = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobAPLimited

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccruedLiability(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString)

        End Using

        CreateAccruedLiabilitySummarybyJobAPLimited = XtraReport

    End Function
    Private Function CreateAccruedLiabilitySummarybyJobAPPosted(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobAPPosted = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobAPPosted

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccruedLiability(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString)

        End Using

        CreateAccruedLiabilitySummarybyJobAPPosted = XtraReport

    End Function
    Private Function CreateAccruedLiabilitySummarybyJobandSalesClass(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobandSalesClass = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobandSalesClass

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccruedLiability(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString)

        End Using

        CreateAccruedLiabilitySummarybyJobandSalesClass = XtraReport

    End Function
    Private Function CreateAccruedLiabilitySummarybyJobSalesClassFunction(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobSalesClassFunction = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccruedLiabilities.AccruedLiabilitySummarybyJobSalesClassFunction

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccruedLiability(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccruedLiabilityParameters.EndPeriod.ToString)

        End Using

        CreateAccruedLiabilitySummarybyJobSalesClassFunction = XtraReport

    End Function

    Private Function CreateAccountsPayableDetailwithDaysAged(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDetailwithDaysAged = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDetailwithDaysAged

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableDetailwithDaysAged = XtraReport

    End Function
    Private Function CreateAccountsPayableDisbDetailbyInvoiceNumber(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDisbDetailbyInvoiceNumber = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDisbDetailbyInvoiceNumber

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableDisbDetailbyInvoiceNumber = XtraReport

    End Function
    Private Function CreateAccountsPayableDisbDetailbyInvoiceDate(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDisbDetailbyInvoiceDate = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableDisbDetailbyInvoiceDate

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableDisbDetailbyInvoiceDate = XtraReport

    End Function
    Private Function CreateAccountsPayableAgedSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedSummary = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedSummary

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableAgedSummary = XtraReport

    End Function
    Private Function CreateAccountsPayableAgedDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedDetail = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedDetail

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableAgedDetail = XtraReport

    End Function
    Private Function CreateAccountsPayableAgedDetailNoGL(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedDetailNoGLAccount = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.AccountsPayable.AccountsPayableAgedDetailNoGLAccount

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndAccountsPayable(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.EndPeriod.ToString)

            XtraReport.aging_date.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingDate.ToString)

            XtraReport.aging_option.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndAccountsPayableParameters.AgingOption.ToString)

        End Using

        CreateAccountsPayableAgedDetailNoGL = XtraReport

    End Function
    Private Function CreateStandard1099NECFormReport(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                     ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099NECFormReport = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.Standard1099NECFormReport

        XtraReport.Session = Session

        XtraReport.DataSource = ParameterDictionary("DataSource")

        XtraReport.DisplayName = "1099 Forms"

        CreateStandard1099NECFormReport = XtraReport

    End Function
    Private Function CreateTrafficFlightSummaryReport(ByVal Session As AdvantageFramework.Security.Session, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object),
                                                      ByVal Criteria As Integer, ByVal FilterString As String, ByVal [From] As Date, ByVal [To] As Date) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.TrafficFlightSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.TrafficFlightSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastWorksheetOther.TrafficFlightSummaryReport).ParameterDictionary = ParameterDictionary
            'CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).LocationEntity = Location

        End If

        CreateTrafficFlightSummaryReport = Report

    End Function

    Private Function CreateProductionWIPAgedSummarybyJobwithAccrLiabilityPO(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobwithAccrLiabilityPO = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPAgedSummarybyJobwithAccrLiabilityPO

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPAgedSummarybyJobwithAccrLiabilityPO = XtraReport

    End Function
    Private Function CreateBroadcastInvoiceSummary(ByVal Session As AdvantageFramework.Security.Session, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceSummaryReport).ParameterDictionary = ParameterDictionary
            'CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).LocationEntity = Location

        End If

        CreateBroadcastInvoiceSummary = Report

    End Function
    Private Function CreateBroadcastInvoiceDetail(ByVal Session As AdvantageFramework.Security.Session, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceDetailReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceDetailReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.BroadcastInvoiceDetailReport).ParameterDictionary = ParameterDictionary
            'CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetPostBuyReport).LocationEntity = Location

        End If

        CreateBroadcastInvoiceDetail = Report

    End Function

    Private Function CreateProductionWIPSummaryByJobEstHrsDefRecSls(ByVal Session As AdvantageFramework.Security.Session, ByVal Report As AdvantageFramework.Reporting.ReportTypes,
                                                              ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim XtraReport As AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobEstHrsDefRecSls = Nothing

        XtraReport = New AdvantageFramework.Reporting.Reports.MediaWIP.ProductionWIP.ProductionWIPSummarybyJobEstHrsDefRecSls

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Session.ConnectionString, Session.UserCode)

            XtraReport.DataSource = AdvantageFramework.Reporting.LoadMonthEndProductionWIP(ReportingDbContext, ParameterDictionary)

            XtraReport.end_period.Value = ParameterDictionary(AdvantageFramework.Reporting.MonthEndProductionWIPParameters.EndPeriod.ToString)

        End Using

        CreateProductionWIPSummaryByJobEstHrsDefRecSls = XtraReport

    End Function
#End Region

#Region " Broadcast Worksheet Radio Pre/Post Buy Reports "

    Public Function CreateMediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                 Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                        Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPreBuyStationDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPreBuyStationSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                 Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyStationSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPreBuyStationSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPreBuyReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                   Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPreBuyReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPreBuyReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                  Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                         Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPostBuyStationDaypartSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPostBuyStationSummaryReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                                  Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyStationSummaryReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPostBuyStationSummaryReport = Report

    End Function
    Public Function CreateMediaBroadcastWorksheetRadioPostBuyReport(Session As AdvantageFramework.Security.Session, ParameterDictionary As Dictionary(Of String, Object),
                                                                    Location As AdvantageFramework.Database.Entities.Location) As DevExpress.XtraReports.UI.XtraReport

        'objects
        Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing

        If Session IsNot Nothing Then

            Report = New AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport

            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport).Session = Session
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport).ParameterDictionary = ParameterDictionary
            CType(Report, AdvantageFramework.Reporting.Reports.Media.MediaBroadcastWorksheetRadioPostBuyReport).LocationEntity = Location

        End If

        CreateMediaBroadcastWorksheetRadioPostBuyReport = Report

    End Function

#End Region

#Region " Proofing "
    Private Function CreateProofingFeedbackSummary(ByVal Session As AdvantageFramework.Security.Session,
                                                   ByVal ParameterDictionary As Generic.Dictionary(Of String, Object)) As DevExpress.XtraReports.UI.XtraReport

        Dim AlertID As Integer = 0
        Dim EmployeeTimezoneOffset As Decimal = 0
        Dim IsClientPortal As Boolean = False
        Dim ClientContactID As Integer = 0
        Dim CultureCode As String = String.Empty

        If ParameterDictionary.ContainsKey("AlertID") Then AlertID = ParameterDictionary("AlertID")
        If ParameterDictionary.ContainsKey("EmployeeTimezoneOffset") Then EmployeeTimezoneOffset = ParameterDictionary("EmployeeTimezoneOffset")
        If ParameterDictionary.ContainsKey("IsClientPortal") Then IsClientPortal = ParameterDictionary("IsClientPortal")
        If ParameterDictionary.ContainsKey("ClientContactID") Then EmployeeTimezoneOffset = ParameterDictionary("ClientContactID")
        If ParameterDictionary.ContainsKey("CultureCode") Then EmployeeTimezoneOffset = ParameterDictionary("CultureCode")

        Return CreateProofingFeedbackSummary(Session, AlertID, EmployeeTimezoneOffset, IsClientPortal, ClientContactID, CultureCode)

    End Function
    Public Function CreateProofingFeedbackSummary(ByVal Session As AdvantageFramework.Security.Session,
                                                  ByVal AlertID As Integer,
                                                  ByVal EmployeeTimezoneOffset As Decimal,
                                                  ByVal IsClientPortal As Boolean,
                                                  ByVal ClientContactID As Integer,
                                                  ByVal CultureCode As String) As DevExpress.XtraReports.UI.XtraReport

        Dim XtraReport As AdvantageFramework.Reporting.Reports.Proofing.FeedbackSummaryReport = New AdvantageFramework.Reporting.Reports.Proofing.FeedbackSummaryReport

        XtraReport.DisplayName = "Feedback Summary"
        XtraReport.SecuritySession = Session
        XtraReport.AlertID = AlertID
        XtraReport.EmployeeTimezoneOffset = EmployeeTimezoneOffset
        XtraReport.IsClientPortal = IsClientPortal
        XtraReport.ClientContactID = ClientContactID
        XtraReport.CultureCode = CultureCode

        Return XtraReport

    End Function

#End Region

#End Region

End Module

Friend Class DayAndWeek
    Public Property DetailDate As Date
    Public Property Spots As Integer

    Public Sub New(ByRef DetailDate As Date, ByRef Spots As Integer)
        Me.DetailDate = DetailDate
        Me.Spots = Spots
    End Sub

End Class
