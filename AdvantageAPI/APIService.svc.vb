<System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode:=System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Allowed)>
Public Class APIService
    Implements IAPIService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim _AdvSession As AdvantageFramework.Security.Session = Nothing
    'Dim _ErrorMessage As String = Nothing
    'Dim _NewMediaPlanID As Integer = 0
    Dim _MediaPlanAddResponse As MediaPlanAddResponse = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function AddInternetOrder(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     OrderDescription As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                                     CampaignCode As String, SalesClassCode As String, VendorCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                                     ClientPO As String, BuyerName As String, BuyerEmployeeCode As String, OrderDate As Date, OrderComment As String, HouseComment As String, MarketCode As String,
                                     IsNetAmount As Boolean, StartDate As Date, EndDate As Date, AdNumber As String, Headline As String,
                                     AdSizeCode As String, JobNumber As Integer, JobComponentNumber As Integer, InternetTypeCode As String, URL As String,
                                     TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As Integer, GuaranteedImpressions As Integer,
                                     ActualImpressions As Integer, LineMarketCode As String, Rate As Decimal, NetCharge As Decimal, AdditionalCharge As Decimal,
                                     CostType As String, RebateAmount As String, DiscountAmount As String,
                                     Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse Implements IAPIService.AddInternetOrder

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim JobNbr As Nullable(Of Integer) = Nothing
        Dim JobComponentNbr As Nullable(Of Integer) = Nothing
        Dim MarkupPercentage As Nullable(Of Decimal) = Nothing
        Dim RebatePercentage As Nullable(Of Decimal) = Nothing
        Dim CommissionPercentage As Nullable(Of Decimal) = Nothing
        Dim RebateAmountDec As Nullable(Of Decimal) = Nothing
        Dim DiscountAmountDec As Nullable(Of Decimal) = Nothing
        Dim VendorMarketCode As String = String.Empty

        MediaOrderResponse = New MediaOrderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                If RebateAmount = "" Then

                    RebateAmountDec = Nothing

                Else

                    RebateAmountDec = ConvertDecimal(RebateAmount, 0, "Rebate Amount", ErrorMessage)

                End If

                If DiscountAmount = "" Then

                    DiscountAmountDec = Nothing

                Else

                    DiscountAmountDec = ConvertDecimal(DiscountAmount, 0, "Discount Amount", ErrorMessage)

                End If

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    If ValidateInternetOrder(DbContext, 0, OrderDescription, ClientCode, DivisionCode, ProductCode,
                                             CampaignCode, SalesClassCode, VendorCode, VendorRepresentativeCode1, VendorRepresentativeCode2,
                                             ClientPO, BuyerName, BuyerEmployeeCode, OrderDate, OrderComment, HouseComment, MarketCode,
                                             StartDate, EndDate, IsNetAmount, 0, AdNumber, Headline,
                                             AdSizeCode, JobNumber, JobComponentNumber, InternetTypeCode, URL,
                                             TargetAudience, Placement1, Placement2, ProjectedImpressions, GuaranteedImpressions,
                                             ActualImpressions, LineMarketCode, Rate, NetCharge, AdditionalCharge,
                                             CostType, MarkupPercentage, RebatePercentage, RebateAmountDec,
                                             Instructions, MiscInfo, OrderCopy, MaterialNotes, ErrorMessage) Then

                        If String.IsNullOrWhiteSpace(MarketCode) Then

                            Try

                                VendorMarketCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT MARKET_CODE FROM dbo.VENDOR WHERE VN_CODE = '{0}'", VendorCode)).FirstOrDefault

                            Catch ex As Exception
                                VendorMarketCode = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(VendorMarketCode) = False Then

                                MarketCode = VendorMarketCode

                            End If

                        End If

                        'PJH 05/16/19 - Allow 0 to be passed to indicate no value (null)
                        If JobNumber = 0 OrElse JobComponentNumber = 0 Then
                            JobNbr = Nothing
                            JobComponentNbr = Nothing
                        Else
                            JobNbr = JobNumber
                            JobComponentNbr = JobComponentNumber
                        End If

                        'PJH 05/16/19 - If(IsNetAmount, 1, 0) needs to be passed by user, default from Vendor, else set to Net for Inet
                        'PJH 05/16/19 - Uses Rate for Cost Rate also

                        MediaOrderInternalResponse = AddReviseMediaOrder(DbContext, APISession.UserCode, "", "I", "I",
                                                                         0, OrderDescription, ClientCode, DivisionCode, ProductCode,
                                                                         CampaignCode, SalesClassCode, VendorCode, VendorRepresentativeCode1,
                                                                         VendorRepresentativeCode2, ClientPO, BuyerName, BuyerEmployeeCode,
                                                                         OrderDate, OrderComment, HouseComment,
                                                                         MarketCode, StartDate, EndDate, If(IsNetAmount, 0, 1), "", 0, "",
                                                                         AdNumber, Headline, "", "", "", AdSizeCode,
                                                                         "", JobNbr, JobComponentNbr, "",
                                                                         InternetTypeCode, URL, TargetAudience, Placement1,
                                                                         Placement2, ProjectedImpressions, GuaranteedImpressions,
                                                                         ActualImpressions, LineMarketCode, 0, Rate, NetCharge,
                                                                         AdditionalCharge, DiscountAmountDec, 0, 0, 0,
                                                                         CostType, Rate, "", MarkupPercentage, RebatePercentage, RebateAmountDec,
                                                                         CommissionPercentage, 0, 0, Instructions, OrderCopy, MaterialNotes,
                                                                         "", "", "", MiscInfo, "")

                    End If

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderInternalResponse IsNot Nothing Then

            MediaOrderResponse.IsSuccessful = MediaOrderInternalResponse.IsSuccessful
            MediaOrderResponse.Message = MediaOrderInternalResponse.Message
            MediaOrderResponse.OrderNumber = MediaOrderInternalResponse.OrderNumber
            MediaOrderResponse.OrderLineNumber = MediaOrderInternalResponse.OrderLineNumber

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage
            MediaOrderResponse.OrderNumber = 0
            MediaOrderResponse.OrderLineNumber = 0

        End If

        AddInternetOrder = MediaOrderResponse

    End Function
    Public Function ReviseInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                            OrderNumber As Integer, OrderLineNumber As Integer, StartDate As String, EndDate As String, AdNumber As String, Headline As String,
                                            AdSizeCode As String, JobNumber As String, JobComponentNumber As String, InternetTypeCode As String, URL As String,
                                            TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As String, GuaranteedImpressions As String,
                                            ActualImpressions As String, LineMarketCode As String, Rate As String, NetCharge As String, AdditionalCharge As String,
                                            CostType As String, RebateAmount As String, DiscountAmount As String,
                                            Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse Implements IAPIService.ReviseInternetOrderLine

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim InternetOrder As InternetOrder = Nothing
        Dim InternetOrderDetail As InternetOrderDetail = Nothing
        Dim InternetOrderDetailComment As InternetOrderDetailComment = Nothing
        Dim MarkupPercentage As String = String.Empty
        Dim RebatePercentage As String = String.Empty
        Dim RebateAmountDec As Nullable(Of Decimal) = Nothing
        Dim DiscountAmountDec As Nullable(Of Decimal) = Nothing

        MediaOrderResponse = New MediaOrderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    MarkupPercentage = "*"
                    RebatePercentage = "*"

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        InternetOrder = DbContext.InternetOrders.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber)

                    Catch ex As Exception
                        InternetOrder = Nothing
                    End Try

                    If InternetOrder IsNot Nothing Then

                        Try

                            InternetOrderDetail = DbContext.InternetOrderDetails.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.LineNumber = OrderLineNumber AndAlso Entity.IsActiveRevision = 1)

                        Catch ex As Exception
                            InternetOrderDetail = Nothing
                        End Try

                        'PJH 05/16/19 - Added - Nothing if "". If something then oveeride.
                        If InternetOrderDetail IsNot Nothing Then

                            If RebateAmount = "" Then

                                RebateAmountDec = Nothing

                            Else

                                RebateAmountDec = ConvertDecimal(RebateAmount, InternetOrderDetail.RebateAmount, "Rebate Amount", ErrorMessage)

                            End If

                            If DiscountAmount = "" Then

                                DiscountAmountDec = Nothing

                            Else

                                DiscountAmountDec = ConvertDecimal(DiscountAmount, InternetOrderDetail.DiscountAmount, "Discount Amount", ErrorMessage)

                            End If

                        End If

                        If InternetOrderDetail IsNot Nothing Then

                            InternetOrderDetail.StartDate = ConvertDate(StartDate, InternetOrderDetail.StartDate, "Start Date", ErrorMessage)
                            InternetOrderDetail.EndDate = ConvertDate(EndDate, InternetOrderDetail.EndDate, "End Date", ErrorMessage)
                            InternetOrderDetail.AdNumber = ConvertString(AdNumber, InternetOrderDetail.AdNumber, "Ad Number", ErrorMessage)
                            InternetOrderDetail.Headline = ConvertString(Headline, InternetOrderDetail.Headline, "Headline", ErrorMessage)
                            InternetOrderDetail.Size = ConvertString(AdSizeCode, InternetOrderDetail.Size, "Ad Size Code", ErrorMessage)
                            InternetOrderDetail.JobNumber = ConvertInteger(JobNumber, InternetOrderDetail.JobNumber, "Job Number", ErrorMessage)
                            InternetOrderDetail.JobComponentNumber = ConvertShort(JobComponentNumber, InternetOrderDetail.JobComponentNumber, "Job Component Number", ErrorMessage)
                            InternetOrderDetail.InternetTypeCode = ConvertString(InternetTypeCode, InternetOrderDetail.InternetTypeCode, "Internet Type Code", ErrorMessage)
                            InternetOrderDetail.Url = ConvertString(URL, InternetOrderDetail.Url, "URL", ErrorMessage)
                            InternetOrderDetail.TargetAudience = ConvertString(TargetAudience, InternetOrderDetail.TargetAudience, "Target Audience", ErrorMessage)
                            InternetOrderDetail.Placement1 = ConvertString(Placement1, InternetOrderDetail.Placement1, "Placement 1", ErrorMessage)
                            InternetOrderDetail.Placement2 = ConvertString(Placement2, InternetOrderDetail.Placement2, "Placement 2", ErrorMessage)
                            InternetOrderDetail.ProjectedImpressions = ConvertInteger(ProjectedImpressions, InternetOrderDetail.ProjectedImpressions, "Projected Impressions", ErrorMessage)
                            InternetOrderDetail.GuaranteedImpressions = ConvertInteger(GuaranteedImpressions, InternetOrderDetail.GuaranteedImpressions, "Guaranteed Impressions", ErrorMessage)
                            InternetOrderDetail.ActualImpressions = ConvertInteger(ActualImpressions, InternetOrderDetail.ActualImpressions, "Actual Impressions", ErrorMessage)
                            InternetOrderDetail.MarketCode = ConvertString(LineMarketCode, InternetOrderDetail.MarketCode, "Line Market Code", ErrorMessage)
                            InternetOrderDetail.Rate = ConvertDecimal(Rate, InternetOrderDetail.Rate, "Rate", ErrorMessage)
                            InternetOrderDetail.NetCharge = ConvertDecimal(NetCharge, InternetOrderDetail.NetCharge, "Net Charge", ErrorMessage)
                            InternetOrderDetail.AdditionalCharge = ConvertDecimal(AdditionalCharge, InternetOrderDetail.AdditionalCharge, "Additional Charge", ErrorMessage)
                            InternetOrderDetail.CostType = ConvertString(CostType, InternetOrderDetail.CostType, "Cost Type", ErrorMessage)
                            InternetOrderDetail.MarkupPercent = ConvertDecimal(MarkupPercentage, InternetOrderDetail.MarkupPercent, "Markup Percentage", ErrorMessage)
                            InternetOrderDetail.DiscountAmount = DiscountAmountDec
                            InternetOrderDetail.RebatePercent = ConvertDecimal(RebatePercentage, InternetOrderDetail.RebatePercent, "Rebate Percentage", ErrorMessage)
                            InternetOrderDetail.RebateAmount = RebateAmountDec

                            Try

                                InternetOrderDetailComment = DbContext.InternetOrderDetailComments.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.LineNumber = OrderLineNumber)

                            Catch ex As Exception
                                InternetOrderDetailComment = Nothing
                            End Try

                            If InternetOrderDetailComment IsNot Nothing Then

                                InternetOrderDetailComment.Instructions = ConvertString(Instructions, InternetOrderDetailComment.Instructions, "Instructions", ErrorMessage)
                                InternetOrderDetailComment.MiscInfo = ConvertString(MiscInfo, InternetOrderDetailComment.MiscInfo, "Misc Info", ErrorMessage)
                                InternetOrderDetailComment.OrderCopy = ConvertString(OrderCopy, InternetOrderDetailComment.OrderCopy, "Order Copy", ErrorMessage)
                                InternetOrderDetailComment.MaterialNotes = ConvertString(MaterialNotes, InternetOrderDetailComment.MaterialNotes, "Material Notes", ErrorMessage)

                            Else

                                InternetOrderDetailComment = New InternetOrderDetailComment

                                InternetOrderDetailComment.Instructions = ConvertString(Instructions, "", "Instructions", ErrorMessage)
                                InternetOrderDetailComment.MiscInfo = ConvertString(MiscInfo, "", "Misc Info", ErrorMessage)
                                InternetOrderDetailComment.OrderCopy = ConvertString(OrderCopy, "", "Order Copy", ErrorMessage)
                                InternetOrderDetailComment.MaterialNotes = ConvertString(MaterialNotes, "", "Material Notes", ErrorMessage)

                            End If

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                If ValidateInternetOrder(DbContext, OrderNumber, InternetOrder.Description, InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                         InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorCode, InternetOrder.VendorRepCode1, InternetOrder.VendorRepCode2,
                                                         InternetOrder.ClientPO, InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode, InternetOrder.OrderDate, InternetOrder.OrderComment,
                                                         InternetOrder.HouseComment, InternetOrder.MarketCode, InternetOrderDetail.StartDate, InternetOrderDetail.EndDate, InternetOrder.NetGross.GetValueOrDefault(0),
                                                         OrderLineNumber, InternetOrderDetail.AdNumber, InternetOrderDetail.Headline, InternetOrderDetail.Size, InternetOrderDetail.JobNumber,
                                                         InternetOrderDetail.JobComponentNumber, InternetOrderDetail.InternetTypeCode, InternetOrderDetail.Url,
                                                         InternetOrderDetail.TargetAudience, InternetOrderDetail.Placement1, InternetOrderDetail.Placement2,
                                                         InternetOrderDetail.ProjectedImpressions, InternetOrderDetail.GuaranteedImpressions, InternetOrderDetail.ActualImpressions,
                                                         InternetOrderDetail.MarketCode, InternetOrderDetail.Rate, InternetOrderDetail.NetCharge, InternetOrderDetail.AdditionalCharge,
                                                         InternetOrderDetail.CostType, InternetOrderDetail.MarkupPercent, InternetOrderDetail.RebatePercent, InternetOrderDetail.RebateAmount,
                                                         InternetOrderDetailComment.Instructions, InternetOrderDetailComment.MiscInfo, InternetOrderDetailComment.OrderCopy,
                                                         InternetOrderDetailComment.MaterialNotes, ErrorMessage) Then

                                    'PJH 05/17/19 - Use InternetOrderDetail.Rate for CostRate also

                                    MediaOrderInternalResponse = AddReviseMediaOrder(DbContext, APISession.UserCode, "", "I", "I",
                                                                                              OrderNumber, InternetOrder.Description, InternetOrder.ClientCode,
                                                                                              InternetOrder.DivisionCode, InternetOrder.ProductCode, InternetOrder.CampaignCode,
                                                                                              InternetOrder.MediaTypeCode, InternetOrder.VendorCode, InternetOrder.VendorRepCode1,
                                                                                              InternetOrder.VendorRepCode2, InternetOrder.ClientPO, InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode,
                                                                                              InternetOrder.OrderDate, InternetOrder.OrderComment, InternetOrder.HouseComment,
                                                                                              InternetOrder.MarketCode, InternetOrderDetail.StartDate, InternetOrderDetail.EndDate,
                                                                                              InternetOrder.NetGross.GetValueOrDefault(0), "", OrderLineNumber, "",
                                                                                              InternetOrderDetail.AdNumber, InternetOrderDetail.Headline,
                                                                                              "", "", "", InternetOrderDetail.Size,
                                                                                              "", InternetOrderDetail.JobNumber, InternetOrderDetail.JobComponentNumber, "",
                                                                                              InternetOrderDetail.InternetTypeCode, InternetOrderDetail.Url, InternetOrderDetail.TargetAudience,
                                                                                              InternetOrderDetail.Placement1,
                                                                                              InternetOrderDetail.Placement2, InternetOrderDetail.ProjectedImpressions,
                                                                                              InternetOrderDetail.GuaranteedImpressions,
                                                                                              InternetOrderDetail.ActualImpressions, InternetOrderDetail.MarketCode, Nothing,
                                                                                              InternetOrderDetail.Rate, InternetOrderDetail.NetCharge,
                                                                                              InternetOrderDetail.AdditionalCharge, InternetOrderDetail.DiscountAmount, Nothing, Nothing, Nothing,
                                                                                              InternetOrderDetail.CostType, InternetOrderDetail.Rate, "", InternetOrderDetail.MarkupPercent,
                                                                                              InternetOrderDetail.RebatePercent, InternetOrderDetail.RebateAmount,
                                                                                              Nothing, Nothing, Nothing, InternetOrderDetailComment.Instructions, InternetOrderDetailComment.OrderCopy,
                                                                                              InternetOrderDetailComment.MaterialNotes,
                                                                                              "", "", "", InternetOrderDetailComment.MiscInfo, "")

                                End If

                            End If

                        Else

                            ErrorMessage = "Order does not exist"

                        End If

                    Else

                        ErrorMessage = "Order does not exist"

                    End If

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderInternalResponse IsNot Nothing Then

            MediaOrderResponse.IsSuccessful = MediaOrderInternalResponse.IsSuccessful
            MediaOrderResponse.Message = MediaOrderInternalResponse.Message
            MediaOrderResponse.OrderNumber = MediaOrderInternalResponse.OrderNumber
            MediaOrderResponse.OrderLineNumber = MediaOrderInternalResponse.OrderLineNumber

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage
            MediaOrderResponse.OrderNumber = 0
            MediaOrderResponse.OrderLineNumber = 0

        End If

        ReviseInternetOrderLine = MediaOrderResponse

    End Function
    Public Function AddInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                         OrderNumber As Integer, StartDate As Date, EndDate As Date, AdNumber As String, Headline As String,
                                         AdSizeCode As String, JobNumber As Integer, JobComponentNumber As Integer, InternetTypeCode As String, URL As String,
                                         TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As Integer, GuaranteedImpressions As Integer,
                                         ActualImpressions As Integer, LineMarketCode As String, Rate As Decimal, NetCharge As Decimal, AdditionalCharge As Decimal,
                                         CostType As String, RebateAmount As String, DiscountAmount As String,
                                         Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse Implements IAPIService.AddInternetOrderLine

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim InternetOrder As InternetOrder = Nothing
        Dim MarkupPercentage As Nullable(Of Decimal) = Nothing
        Dim RebatePercentage As Nullable(Of Decimal) = Nothing
        Dim CommissionPercentage As Nullable(Of Decimal) = Nothing
        Dim RebateAmountDec As Nullable(Of Decimal) = Nothing
        Dim DiscountAmountDec As Nullable(Of Decimal) = Nothing

        MediaOrderResponse = New MediaOrderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If RebateAmount = "" Then

                        RebateAmountDec = Nothing

                    Else

                        RebateAmountDec = ConvertDecimal(RebateAmount, 0, "Rebate Amount", ErrorMessage)

                    End If

                    If DiscountAmount = "" Then

                        DiscountAmountDec = Nothing

                    Else

                        DiscountAmountDec = ConvertDecimal(DiscountAmount, 0, "Discount Amount", ErrorMessage)

                    End If

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        InternetOrder = DbContext.InternetOrders.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber)

                    Catch ex As Exception
                        InternetOrder = Nothing
                    End Try

                    If InternetOrder IsNot Nothing Then

                        If ValidateInternetOrder(DbContext, OrderNumber, InternetOrder.Description, InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                 InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorCode, InternetOrder.VendorRepCode1, InternetOrder.VendorRepCode2,
                                                 InternetOrder.ClientPO, InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode, InternetOrder.OrderDate, InternetOrder.OrderComment, InternetOrder.HouseComment, InternetOrder.MarketCode,
                                                 StartDate, EndDate, False, 0, AdNumber, Headline,
                                                 AdSizeCode, JobNumber, JobComponentNumber, InternetTypeCode, URL,
                                                 TargetAudience, Placement1, Placement2, ProjectedImpressions, GuaranteedImpressions,
                                                 ActualImpressions, LineMarketCode, Rate, NetCharge, AdditionalCharge,
                                                 CostType, MarkupPercentage, RebatePercentage, RebateAmountDec,
                                                 Instructions, MiscInfo, OrderCopy, MaterialNotes, ErrorMessage) Then

                            MediaOrderInternalResponse = AddReviseMediaOrder(DbContext, APISession.UserCode, "", "I", "I",
                                                                             OrderNumber, InternetOrder.Description, InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                                             InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorCode, InternetOrder.VendorRepCode1,
                                                                             InternetOrder.VendorRepCode2, InternetOrder.ClientPO, InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode,
                                                                             InternetOrder.OrderDate, InternetOrder.OrderComment, InternetOrder.HouseComment,
                                                                             InternetOrder.MarketCode, StartDate, EndDate, 0, "", 0, "",
                                                                             AdNumber, Headline, "", "", "", AdSizeCode,
                                                                             "", JobNumber, JobComponentNumber, "",
                                                                             InternetTypeCode, URL, TargetAudience, Placement1,
                                                                             Placement2, ProjectedImpressions, GuaranteedImpressions,
                                                                             ActualImpressions, LineMarketCode, 0, Rate, NetCharge,
                                                                             AdditionalCharge, DiscountAmountDec, 0, 0, 0,
                                                                             CostType, Rate, "", MarkupPercentage, RebatePercentage, RebateAmountDec,
                                                                             CommissionPercentage, 0, 0, Instructions, OrderCopy, MaterialNotes,
                                                                             "", "", "", MiscInfo, "")

                        End If

                    Else

                        ErrorMessage = "Order does not exist"

                    End If

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderInternalResponse IsNot Nothing Then

            MediaOrderResponse.IsSuccessful = MediaOrderInternalResponse.IsSuccessful
            MediaOrderResponse.Message = MediaOrderInternalResponse.Message
            MediaOrderResponse.OrderNumber = MediaOrderInternalResponse.OrderNumber
            MediaOrderResponse.OrderLineNumber = MediaOrderInternalResponse.OrderLineNumber

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage
            MediaOrderResponse.OrderNumber = 0
            MediaOrderResponse.OrderLineNumber = 0

        End If

        AddInternetOrderLine = MediaOrderResponse

    End Function
    Public Function UpdateInternetOrderHeader(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                              OrderNumber As Integer, OrderDescription As String, CampaignCode As String, SalesClassCode As String,
                                              VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String, ClientPO As String, ClientRef As String,
                                              OrderDate As String, BuyerName As String, BuyerEmployeeCode As String, MarketCode As String, FiscalPeriodCode As String,
                                              MailToVendor As Boolean, MailToRep1 As Boolean, MailToRep2 As Boolean, OrderComment As String, HouseComment As String) As MediaOrderResponse Implements IAPIService.UpdateInternetOrderHeader

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim InternetOrder As InternetOrder = Nothing
        Dim Campaign As Campaign = Nothing
        Dim CampaignID As Nullable(Of Integer)
        Dim MediaOrderDate As Date = Date.MinValue

        MediaOrderResponse = New MediaOrderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        InternetOrder = DbContext.InternetOrders.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber)

                    Catch ex As Exception
                        InternetOrder = Nothing
                    End Try

                    If InternetOrder IsNot Nothing Then
                        If InternetOrder.OrderProcessControl = "6" OrElse InternetOrder.OrderProcessControl = "13" Then
                            InternetOrder = Nothing
                            ErrorMessage = "The order is closed and can't be updated."
                        End If
                    End If

                    If InternetOrder IsNot Nothing Then

                        InternetOrder.Description = ConvertString(OrderDescription, InternetOrder.Description, "Order Description", ErrorMessage)
                        InternetOrder.CampaignCode = ConvertString(CampaignCode, InternetOrder.CampaignCode, "Campaign Code", ErrorMessage)
                        InternetOrder.MediaTypeCode = ConvertString(SalesClassCode, InternetOrder.MediaTypeCode, "Sales Class Code", ErrorMessage)
                        InternetOrder.VendorRepCode1 = ConvertString(VendorRepresentativeCode1, InternetOrder.VendorRepCode1, "Vendor Representative Code 1", ErrorMessage)
                        InternetOrder.VendorRepCode2 = ConvertString(VendorRepresentativeCode2, InternetOrder.VendorRepCode2, "Vendor Representative Code 2", ErrorMessage)
                        InternetOrder.ClientPO = ConvertString(ClientPO, InternetOrder.ClientPO, "Client PO", ErrorMessage)
                        InternetOrder.ClientReference = ConvertString(ClientRef, InternetOrder.ClientReference, "Client Ref", ErrorMessage)
                        InternetOrder.OrderDate = ConvertDate(OrderDate, InternetOrder.OrderDate, "Order Date", ErrorMessage)
                        InternetOrder.Buyer = ConvertString(BuyerName, InternetOrder.Buyer, "Buyer Name", ErrorMessage)
                        InternetOrder.BuyerEmployeeCode = ConvertString(BuyerEmployeeCode, InternetOrder.BuyerEmployeeCode, "Buyer Employee Code", ErrorMessage)
                        InternetOrder.MarketCode = ConvertString(MarketCode, InternetOrder.MarketCode, "Market Code", ErrorMessage)
                        InternetOrder.PostPeriodCode = ConvertString(FiscalPeriodCode, InternetOrder.PostPeriodCode, "Fiscal Period Code", ErrorMessage)
                        InternetOrder.OrderComment = ConvertString(OrderComment, InternetOrder.OrderComment, "Order Comment", ErrorMessage)
                        InternetOrder.HouseComment = ConvertString(HouseComment, InternetOrder.HouseComment, "House Comment", ErrorMessage)

                        InternetOrder.MailToVender = If(MailToVendor, 1, 0)
                        InternetOrder.MailToVenderRep1 = If(MailToRep1, 1, 0)
                        InternetOrder.MailToVenderRep2 = If(MailToRep2, 1, 0)

                        If ValidateInternetOrderHeader(DbContext, OrderNumber, InternetOrder.Description, InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                       InternetOrder.VendorCode, InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorRepCode1,
                                                       InternetOrder.VendorRepCode2, InternetOrder.ClientPO, InternetOrder.ClientReference, InternetOrder.OrderDate,
                                                       InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode, InternetOrder.MarketCode,
                                                       InternetOrder.PostPeriodCode, InternetOrder.MailToVender, InternetOrder.MailToVenderRep1, InternetOrder.MailToVenderRep2,
                                                       InternetOrder.OrderComment, InternetOrder.HouseComment, ErrorMessage) Then

                            'PJH 05/16/19 - Allow campaign from any level or Client only and is not closed
                            Campaign = DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = InternetOrder.ClientCode AndAlso Entity.DivisionCode = InternetOrder.DivisionCode AndAlso
                                                 Entity.ProductCode = InternetOrder.ProductCode AndAlso Entity.Code = InternetOrder.CampaignCode AndAlso Entity.IsClosed = 0)

                            If Campaign Is Nothing Then
                                Campaign = DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = InternetOrder.ClientCode AndAlso Entity.DivisionCode = InternetOrder.DivisionCode AndAlso
                                                     Entity.ProductCode Is Nothing AndAlso Entity.Code = InternetOrder.CampaignCode AndAlso Entity.IsClosed = 0)
                            End If

                            If Campaign Is Nothing Then
                                Campaign = DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = InternetOrder.ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso
                                                     Entity.ProductCode Is Nothing AndAlso Entity.Code = InternetOrder.CampaignCode AndAlso Entity.IsClosed = 0)
                            End If

                            If Campaign IsNot Nothing Then
                                CampaignID = Campaign.ID
                            End If

                            MediaOrderInternalResponse = UpdateReviseMediaOrder(DbContext, APISession.UserCode, "UPDATE", "IN", InternetOrder.OrderNumber, InternetOrder.Description,
                                                                                InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                                                InternetOrder.OfficeCode, InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorCode,
                                                                                InternetOrder.VendorRepCode1, InternetOrder.VendorRepCode2, InternetOrder.ClientPO, InternetOrder.ClientReference,
                                                                                InternetOrder.Status, InternetOrder.OrderDate, InternetOrder.Buyer, InternetOrder.OrderComment,
                                                                                InternetOrder.HouseComment, InternetOrder.MailToVender, InternetOrder.MailToVenderRep1, InternetOrder.MailToVenderRep2,
                                                                                InternetOrder.BillingCoopCode, InternetOrder.OrderProcessControl, InternetOrder.MarketCode,
                                                                                InternetOrder.StartDate, InternetOrder.EndDate, InternetOrder.Units, Nothing, InternetOrder.NetGross,
                                                                                InternetOrder.CreatedDate, InternetOrder.Cancelled, InternetOrder.CancelledByUserCode, InternetOrder.CancelledDate,
                                                                                APISession.UserCode, Now, "Modified from API", InternetOrder.Revised,
                                                                                InternetOrder.LinkID, InternetOrder.Reconile,
                                                                                CampaignID, InternetOrder.Printed,
                                                                                InternetOrder.OrderAccepted, InternetOrder.PostPeriodCode, InternetOrder.IsLocked, InternetOrder.LockedByUserCode,
                                                                                InternetOrder.BCCUserID, Nothing, InternetOrder.BuyerEmployeeCode)

                        Else

                            If ErrorMessage = Nothing Then

                                ErrorMessage = "Order does not exist or is closed"

                            End If

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderInternalResponse IsNot Nothing Then

            MediaOrderResponse.IsSuccessful = MediaOrderInternalResponse.IsSuccessful
            MediaOrderResponse.Message = MediaOrderInternalResponse.Message
            MediaOrderResponse.OrderNumber = MediaOrderInternalResponse.OrderNumber
            MediaOrderResponse.OrderLineNumber = MediaOrderInternalResponse.OrderLineNumber

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage
            MediaOrderResponse.OrderNumber = 0
            MediaOrderResponse.OrderLineNumber = 0

        End If

        UpdateInternetOrderHeader = MediaOrderResponse

    End Function
    Public Function UpdateInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                            OrderNumber As Integer, OrderLineNumber As Integer, StartDate As String, EndDate As String, CloseDate As String, MaterialCloseDate As String,
                                            ExtCloseDate As String, ExtMaterialDate As String, DateToBill As String, AdNumber As String, URL As String, Headline As String, FileSize As String,
                                            TargetAudience As String, AdSizeCode As String, Placement1 As String, PackageName As String, InternetTypeCode As String,
                                            JobNumber As String, JobComponentNumber As String, LineMarketCode As String, CostType As String, GuaranteedImpressions As String,
                                            ProjectedImpressions As String, ActualImpressions As String, Rate As String, NetCharge As String, NetChargeDescription As String,
                                            AdditionalCharge As String, AdditionalChargeDescription As String,
                                            DiscountAmount As String, DiscountAmountDescription As String, RebateAmount As String,
                                            Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse Implements IAPIService.UpdateInternetOrderLine

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim InternetOrder As InternetOrder = Nothing
        Dim InternetOrderDetail As InternetOrderDetail = Nothing
        Dim InternetOrderDetailComment As InternetOrderDetailComment = Nothing
        Dim TaxCode As String = String.Empty
        Dim TaxApplyToLineNet As String = String.Empty
        Dim TaxApplyToNetCharge As String = String.Empty
        Dim TaxApplyToAdditionalCharge As String = String.Empty
        Dim TaxApplyToCommission As String = String.Empty
        Dim TaxApplyToRebate As String = String.Empty
        Dim TaxApplyToDiscount As String = String.Empty
        Dim MarkupPercentage As String = String.Empty
        Dim RebatePercentage As String = String.Empty
        Dim CommissionPercentage As String = String.Empty
        Dim BillType As String = String.Empty
        Dim RebateAmountOverride As Integer = 0
        Dim RebateAmountDec As Nullable(Of Decimal) = Nothing
        Dim DiscountAmountDec As Nullable(Of Decimal) = Nothing
        Dim NetAmount As String = String.Empty

        MediaOrderResponse = New MediaOrderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    TaxCode = "*"
                    TaxApplyToLineNet = "*"
                    TaxApplyToNetCharge = "*"
                    TaxApplyToAdditionalCharge = "*"
                    TaxApplyToCommission = "*"
                    TaxApplyToRebate = "*"
                    TaxApplyToDiscount = "*"
                    BillType = "*"
                    MarkupPercentage = "*"
                    RebatePercentage = "*"
                    CommissionPercentage = "*"

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    Try

                        InternetOrder = DbContext.InternetOrders.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber)

                    Catch ex As Exception
                        InternetOrder = Nothing
                    End Try

                    If InternetOrder IsNot Nothing Then

                        Try

                            InternetOrderDetail = DbContext.InternetOrderDetails.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.LineNumber = OrderLineNumber AndAlso Entity.IsActiveRevision = 1)

                        Catch ex As Exception
                            InternetOrderDetail = Nothing
                        End Try

                        If InternetOrder.OrderProcessControl = "6" OrElse InternetOrder.OrderProcessControl = "13" Then
                            InternetOrderDetail = Nothing
                            ErrorMessage = "The order is closed and can't be updated."
                        End If

                        If InternetOrderDetail IsNot Nothing Then
                            If InternetOrderDetail.IsLineCancelled = 1 Then
                                InternetOrderDetail = Nothing
                                ErrorMessage = "The order line is cancelled and can't be updated."
                            End If
                        End If

                        'If String.IsNullOrWhiteSpace(InternetOrderDetail.ARInvoiceNumber) = False Then
                        '    InternetOrderDetail = Nothing
                        '    ErrorMessage = "The order line has been billed and can't be updated. Please revise."
                        'End If

                        'PJH 05/16/19 - Added - Nothing if "". If something then oveeride.
                        If InternetOrderDetail IsNot Nothing Then
                            If RebateAmount = "" Then

                                RebateAmountDec = Nothing

                            Else

                                RebateAmountDec = ConvertDecimal(RebateAmount, InternetOrderDetail.RebateAmount, "Rebate Amount", ErrorMessage)

                            End If

                            If DiscountAmount = "" Then

                                DiscountAmountDec = Nothing

                            Else

                                DiscountAmountDec = ConvertDecimal(DiscountAmount, InternetOrderDetail.DiscountAmount, "Discount Amount", ErrorMessage)

                            End If

                            If RebateAmountDec > 0 Then
                                RebateAmountOverride = 1
                            End If

                        End If

                        If InternetOrderDetail IsNot Nothing Then

                            InternetOrderDetail.StartDate = ConvertDate(StartDate, InternetOrderDetail.StartDate, "Start Date", ErrorMessage)
                            InternetOrderDetail.EndDate = ConvertDate(EndDate, InternetOrderDetail.EndDate, "End Date", ErrorMessage)
                            InternetOrderDetail.CloseDate = ConvertDate(CloseDate, InternetOrderDetail.CloseDate, "Close Date", ErrorMessage)
                            InternetOrderDetail.MaterialCloseDate = ConvertDate(MaterialCloseDate, InternetOrderDetail.MaterialCloseDate, "Material Close Date", ErrorMessage)
                            InternetOrderDetail.ExtendedCloseDate = ConvertDate(ExtCloseDate, InternetOrderDetail.ExtendedCloseDate, "Ext Close Date", ErrorMessage)
                            InternetOrderDetail.ExtendedMaterialDate = ConvertDate(ExtMaterialDate, InternetOrderDetail.ExtendedMaterialDate, "Ext Material Date", ErrorMessage)
                            InternetOrderDetail.DateToBill = ConvertDate(DateToBill, InternetOrderDetail.DateToBill, "Date To Bill", ErrorMessage)
                            InternetOrderDetail.AdNumber = ConvertString(AdNumber, InternetOrderDetail.AdNumber, "Ad Number", ErrorMessage)
                            InternetOrderDetail.Url = ConvertString(URL, InternetOrderDetail.Url, "URL", ErrorMessage)
                            InternetOrderDetail.Headline = ConvertString(Headline, InternetOrderDetail.Headline, "Headline", ErrorMessage)
                            InternetOrderDetail.CopyArea = ConvertString(FileSize, InternetOrderDetail.CopyArea, "File Size", ErrorMessage)
                            InternetOrderDetail.TargetAudience = ConvertString(TargetAudience, InternetOrderDetail.TargetAudience, "Target Audience", ErrorMessage)
                            InternetOrderDetail.Size = ConvertString(AdSizeCode, InternetOrderDetail.Size, "Ad Size Code", ErrorMessage)
                            InternetOrderDetail.Placement1 = ConvertString(Placement1, InternetOrderDetail.Placement1, "Placement 1", ErrorMessage)
                            InternetOrderDetail.Placement2 = ConvertString(PackageName, InternetOrderDetail.Placement2, "Package Name", ErrorMessage)
                            InternetOrderDetail.InternetTypeCode = ConvertString(InternetTypeCode, InternetOrderDetail.InternetTypeCode, "Internet Type Code", ErrorMessage)
                            InternetOrderDetail.JobNumber = ConvertInteger(JobNumber, InternetOrderDetail.JobNumber, "Job Number", ErrorMessage)
                            InternetOrderDetail.JobComponentNumber = ConvertShort(JobComponentNumber, InternetOrderDetail.JobComponentNumber, "Job Component Number", ErrorMessage)
                            InternetOrderDetail.MarketCode = ConvertString(LineMarketCode, InternetOrderDetail.MarketCode, "Line Market Code", ErrorMessage)
                            InternetOrderDetail.CostType = ConvertString(CostType, InternetOrderDetail.CostType, "Cost Type", ErrorMessage)
                            InternetOrderDetail.GuaranteedImpressions = ConvertInteger(GuaranteedImpressions, InternetOrderDetail.GuaranteedImpressions, "Guaranteed Impressions", ErrorMessage)
                            InternetOrderDetail.ProjectedImpressions = ConvertInteger(ProjectedImpressions, InternetOrderDetail.ProjectedImpressions, "Projected Impressions", ErrorMessage)
                            InternetOrderDetail.ActualImpressions = ConvertInteger(ActualImpressions, InternetOrderDetail.ActualImpressions, "Actual Impressions", ErrorMessage)
                            InternetOrderDetail.Rate = ConvertDecimal(Rate, InternetOrderDetail.Rate, "Rate", ErrorMessage)
                            'PJH 05/16/19 - Add Cost Rate
                            InternetOrderDetail.CostRate = InternetOrderDetail.Rate
                            'PJH 06/05/19 - Add Net and Gross Rates
                            If InternetOrder.NetGross = 0 Then

                                InternetOrderDetail.NetRate = InternetOrderDetail.Rate

                            Else

                                InternetOrderDetail.GrossRate = InternetOrderDetail.Rate

                            End If
                            InternetOrderDetail.NetRate = ConvertDecimal(NetAmount, InternetOrderDetail.NetRate, "Net Amount", ErrorMessage)
                            InternetOrderDetail.NetCharge = ConvertDecimal(NetCharge, InternetOrderDetail.NetCharge, "Net Charge", ErrorMessage)
                            InternetOrderDetail.NetChargeDescription = ConvertString(NetChargeDescription, InternetOrderDetail.NetChargeDescription, "Net Charge Description", ErrorMessage)
                            InternetOrderDetail.AdditionalCharge = ConvertDecimal(AdditionalCharge, InternetOrderDetail.AdditionalCharge, "Additional Charge", ErrorMessage)
                            InternetOrderDetail.AdditionalChargeDescription = ConvertString(AdditionalChargeDescription, InternetOrderDetail.AdditionalChargeDescription, "Additional Charge Description", ErrorMessage)
                            InternetOrderDetail.DiscountAmount = DiscountAmountDec
                            InternetOrderDetail.DiscountDescription = ConvertString(DiscountAmountDescription, InternetOrderDetail.DiscountDescription, "Discount Amount Description", ErrorMessage)
                            InternetOrderDetail.BillTypeFlag = ConvertShort(BillType, InternetOrderDetail.BillTypeFlag, "Bill Type", ErrorMessage)
                            InternetOrderDetail.CommissionPercent = ConvertDecimal(CommissionPercentage, InternetOrderDetail.CommissionPercent, "Commission Percentage", ErrorMessage)
                            InternetOrderDetail.MarkupPercent = ConvertDecimal(MarkupPercentage, InternetOrderDetail.MarkupPercent, "Markup Percentage", ErrorMessage)
                            InternetOrderDetail.RebatePercent = ConvertDecimal(RebatePercentage, InternetOrderDetail.RebatePercent, "Rebate Percentage", ErrorMessage)
                            'PJH 05/16/19 - Added RebateAmount
                            InternetOrderDetail.RebateAmount = RebateAmountDec
                            InternetOrderDetail.SalesTaxCode = ConvertString(TaxCode, InternetOrderDetail.SalesTaxCode, "Tax Code", ErrorMessage)
                            InternetOrderDetail.TaxApplyLN = ConvertShort(TaxApplyToLineNet, InternetOrderDetail.TaxApplyLN, "Tax Apply To Line Net", ErrorMessage)
                            InternetOrderDetail.TaxApplyNC = ConvertShort(TaxApplyToNetCharge, InternetOrderDetail.TaxApplyNC, "Tax Apply To Net Charge", ErrorMessage)
                            InternetOrderDetail.TaxApplyAI = ConvertShort(TaxApplyToAdditionalCharge, InternetOrderDetail.TaxApplyAI, "Tax Apply To Additional Charge", ErrorMessage)
                            InternetOrderDetail.TaxApplyC = ConvertShort(TaxApplyToCommission, InternetOrderDetail.TaxApplyC, "Tax Apply To Commission", ErrorMessage)
                            InternetOrderDetail.TaxApplyR = ConvertShort(TaxApplyToRebate, InternetOrderDetail.TaxApplyR, "Tax Apply To Rebate", ErrorMessage)
                            InternetOrderDetail.TaxApplyLND = ConvertShort(TaxApplyToDiscount, InternetOrderDetail.TaxApplyLND, "Tax Apply To Discount", ErrorMessage)

                            Try

                                InternetOrderDetailComment = DbContext.InternetOrderDetailComments.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.LineNumber = OrderLineNumber)

                            Catch ex As Exception
                                InternetOrderDetailComment = Nothing
                            End Try

                            If InternetOrderDetailComment IsNot Nothing Then

                                InternetOrderDetailComment.Instructions = ConvertString(Instructions, InternetOrderDetailComment.Instructions, "Instructions", ErrorMessage)
                                InternetOrderDetailComment.MiscInfo = ConvertString(MiscInfo, InternetOrderDetailComment.MiscInfo, "Misc Info", ErrorMessage)
                                InternetOrderDetailComment.OrderCopy = ConvertString(OrderCopy, InternetOrderDetailComment.OrderCopy, "Order Copy", ErrorMessage)
                                InternetOrderDetailComment.MaterialNotes = ConvertString(MaterialNotes, InternetOrderDetailComment.MaterialNotes, "Material Notes", ErrorMessage)

                            Else

                                InternetOrderDetailComment = New InternetOrderDetailComment

                                InternetOrderDetailComment.Instructions = ConvertString(Instructions, "", "Instructions", ErrorMessage)
                                InternetOrderDetailComment.MiscInfo = ConvertString(MiscInfo, "", "Misc Info", ErrorMessage)
                                InternetOrderDetailComment.OrderCopy = ConvertString(OrderCopy, "", "Order Copy", ErrorMessage)
                                InternetOrderDetailComment.MaterialNotes = ConvertString(MaterialNotes, "", "Material Notes", ErrorMessage)

                            End If

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                                If ValidateInternetOrder(DbContext, OrderNumber, InternetOrder.Description, InternetOrder.ClientCode, InternetOrder.DivisionCode, InternetOrder.ProductCode,
                                                         InternetOrder.CampaignCode, InternetOrder.MediaTypeCode, InternetOrder.VendorCode, InternetOrder.VendorRepCode1, InternetOrder.VendorRepCode2,
                                                         InternetOrder.ClientPO, InternetOrder.Buyer, InternetOrder.BuyerEmployeeCode, InternetOrder.OrderDate, InternetOrder.OrderComment,
                                                         InternetOrder.HouseComment, InternetOrder.MarketCode, InternetOrderDetail.StartDate, InternetOrderDetail.EndDate, InternetOrder.NetGross.GetValueOrDefault(0),
                                                         OrderLineNumber, InternetOrderDetail.AdNumber, InternetOrderDetail.Headline, InternetOrderDetail.Size, InternetOrderDetail.JobNumber,
                                                         InternetOrderDetail.JobComponentNumber, InternetOrderDetail.InternetTypeCode, InternetOrderDetail.Url,
                                                         InternetOrderDetail.TargetAudience, InternetOrderDetail.Placement1, InternetOrderDetail.Placement2,
                                                         InternetOrderDetail.ProjectedImpressions, InternetOrderDetail.GuaranteedImpressions, InternetOrderDetail.ActualImpressions,
                                                         InternetOrderDetail.MarketCode, InternetOrderDetail.Rate, InternetOrderDetail.NetCharge, InternetOrderDetail.AdditionalCharge,
                                                         InternetOrderDetail.CostType, InternetOrderDetail.MarkupPercent, InternetOrderDetail.RebatePercent, InternetOrderDetail.RebateAmount,
                                                         InternetOrderDetailComment.Instructions, InternetOrderDetailComment.MiscInfo, InternetOrderDetailComment.OrderCopy,
                                                         InternetOrderDetailComment.MaterialNotes, ErrorMessage) Then

                                    MediaOrderInternalResponse = UpdateReviseMediaOrderLine(DbContext, APISession.UserCode, "UPDATE", "IN", RebateAmountOverride, 0, 0, 0, OrderNumber, OrderLineNumber,
                                                                        InternetOrderDetail.RevisionNumber, InternetOrderDetail.SequenceNumber, InternetOrderDetail.IsActiveRevision,
                                                                        InternetOrderDetail.LinkDetailID, InternetOrderDetail.StartDate, InternetOrderDetail.EndDate, InternetOrderDetail.CloseDate,
                                                                        InternetOrderDetail.MaterialCloseDate, InternetOrderDetail.ExtendedCloseDate, InternetOrderDetail.ExtendedMaterialDate,
                                                                        "", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                                        Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                                        Nothing, InternetOrderDetail.JobNumber, InternetOrderDetail.JobComponentNumber, InternetOrderDetail.Quantity,
                                                                        InternetOrderDetail.Rate, InternetOrderDetail.NetRate, InternetOrderDetail.GrossRate, InternetOrderDetail.ExtendedNetAmount,
                                                                        InternetOrderDetail.ExtendedGrossAmount, InternetOrderDetail.CommissionAmount, InternetOrderDetail.RebateAmount,
                                                                        InternetOrderDetail.DiscountAmount, InternetOrderDetail.DiscountDescription, InternetOrderDetail.StateTaxAmount,
                                                                        InternetOrderDetail.CountyTaxAmount, InternetOrderDetail.CityTaxAmount, InternetOrderDetail.NonResalesAmount,
                                                                        InternetOrderDetail.NetCharge, InternetOrderDetail.NetChargeDescription, InternetOrderDetail.AdditionalCharge,
                                                                        InternetOrderDetail.AdditionalChargeDescription, InternetOrderDetail.LineTotal, InternetOrderDetail.DateToBill,
                                                                        InternetOrderDetail.IsNonBillable, InternetOrderDetail.ModifiedBy, InternetOrderDetail.ModifiedDate, InternetOrderDetail.ModifiedComments,
                                                                        InternetOrderDetail.BillTypeFlag, InternetOrderDetail.CommissionPercent, InternetOrderDetail.MarkupPercent, InternetOrderDetail.RebatePercent,
                                                                        InternetOrderDetail.DiscountPercent, InternetOrderDetail.SalesTaxCode, InternetOrderDetail.CityTaxPercent, InternetOrderDetail.CountyTaxPercent,
                                                                        InternetOrderDetail.StateTaxPercent, InternetOrderDetail.IsResaleTax, InternetOrderDetail.TaxApplyC, InternetOrderDetail.TaxApplyLN,
                                                                        InternetOrderDetail.TaxApplyLND, InternetOrderDetail.TaxApplyNC, InternetOrderDetail.TaxApplyR, InternetOrderDetail.TaxApplyAI,
                                                                        Nothing, InternetOrderDetail.BillingAmount, InternetOrderDetail.EstimateNumber, InternetOrderDetail.EstimateLineNumber, InternetOrderDetail.EstimateRevisionNumber,
                                                                        InternetOrderDetail.AdNumber, InternetOrderDetail.MatCompDate, Nothing, InternetOrderDetail.CostType, InternetOrderDetail.CostRate,
                                                                        InternetOrderDetail.NetBaseRate, InternetOrderDetail.GrossBaseRate, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                                        InternetOrderDetail.Headline, InternetOrderDetail.Size, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                                        Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing,
                                                                        Nothing, InternetOrderDetail.InternetTypeCode, InternetOrderDetail.Url, InternetOrderDetail.CopyArea, Nothing, Nothing, Nothing,
                                                                        InternetOrderDetail.ProjectedImpressions, InternetOrderDetail.GuaranteedImpressions, InternetOrderDetail.ActualImpressions, InternetOrderDetail.TargetAudience,
                                                                        InternetOrderDetail.CreativeSize, InternetOrderDetail.Placement1, InternetOrderDetail.Placement2, Nothing, InternetOrderDetail.AdServerPlacementID,
                                                                        InternetOrderDetail.AdServerCreatedBy, InternetOrderDetail.AdServerCreatedDateTime, InternetOrderDetail.AdServerLastModifiedBy, InternetOrderDetail.AdServerLastModifiedByDateTime,
                                                                        InternetOrderDetail.AdServerPlacementManual, False, InternetOrderDetail.AdServerPlacementGroupID, Nothing, Nothing, Nothing, Nothing,
                                                                        Nothing, Nothing, Nothing, Nothing, InternetOrderDetail.AdServerID, InternetOrderDetail.MarketCode, Nothing)

                                End If

                            End If

                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) Then
                                ErrorMessage = "Order line does not exist or is cancelled"
                            End If

                        End If
                        '*
                    Else

                        ErrorMessage = "Order does not exist or is closed"

                    End If

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderInternalResponse IsNot Nothing Then

            MediaOrderResponse.IsSuccessful = MediaOrderInternalResponse.IsSuccessful
            MediaOrderResponse.Message = MediaOrderInternalResponse.Message
            MediaOrderResponse.OrderNumber = MediaOrderInternalResponse.OrderNumber
            MediaOrderResponse.OrderLineNumber = MediaOrderInternalResponse.OrderLineNumber

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage
            MediaOrderResponse.OrderNumber = 0
            MediaOrderResponse.OrderLineNumber = 0

        End If

        UpdateInternetOrderLine = MediaOrderResponse

    End Function
    Public Function DeleteInternetOrder(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, OrderNumber As Integer) As MediaOrderResponse Implements IAPIService.DeleteInternetOrder

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    MediaOrderResponse = DeleteOrder(DbContext, "I", OrderNumber)

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderResponse Is Nothing Then

            MediaOrderResponse = New MediaOrderResponse

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage

        End If

        DeleteInternetOrder = MediaOrderResponse

    End Function
    Public Function DeleteInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, OrderNumber As Integer, OrderLineNumber As Integer) As MediaOrderResponse Implements IAPIService.DeleteInternetOrderLine

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = String.Empty

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    MediaOrderResponse = DeleteOrderLine(DbContext, "I", OrderNumber, OrderLineNumber)

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If MediaOrderResponse Is Nothing Then

            MediaOrderResponse = New MediaOrderResponse

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage

        End If

        DeleteInternetOrderLine = MediaOrderResponse

    End Function

    Private Function ValidateInternetOrderHeader(DbContext As APIDbContext, OrderNumber As Integer, OrderDescription As String,
                                                 ClientCode As String, DivisionCode As String, ProductCode As String, VendorCode As String,
                                                 CampaignCode As String, SalesClassCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                                                 ClientPO As String, ClientRef As String, OrderDate As Nullable(Of Date), BuyerName As String, BuyerEmployeeCode As String, MarketCode As String,
                                                 FiscalPeriodCode As String, MailToVendor As Boolean, MailToRep1 As Boolean, MailToRep2 As Boolean, OrderComment As String, HouseComment As String,
                                                 ByRef ErrorMessage As String) As Boolean

        'objects
        Dim IsValid As Boolean = True

        If OrderNumber > 0 Then

            If DbContext.MediaOrderViews.Any(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.MediaType = "I") = False Then

                ErrorMessage &= System.Environment.NewLine & "Order Number does not exist"
                IsValid = False

            End If

        End If

        If String.IsNullOrWhiteSpace(OrderDescription) Then

            ErrorMessage &= System.Environment.NewLine & "Order Description is required"
            IsValid = False

        End If

        If String.IsNullOrWhiteSpace(CampaignCode) = False Then

            Try

                'PJH 05/16/19 - Allow campaign from any level or Client only and is not closed
                If DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso
                                                                        Entity.ProductCode = ProductCode AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing AndAlso
                    DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso
                                                                        Entity.ProductCode Is Nothing AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing AndAlso
                    DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso
                                                                        Entity.ProductCode Is Nothing AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Campaign Code - does not exist or is closed"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Campaign Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(SalesClassCode) Then

            ErrorMessage &= System.Environment.NewLine & "Sales Class Code is required"
            IsValid = False

        Else

            Try

                If DbContext.SalesClasses.SingleOrDefault(Function(Entity) Entity.Code = SalesClassCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Sales Class Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Sales Class Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(VendorRepresentativeCode1) = False Then

            Try

                If String.IsNullOrWhiteSpace(VendorCode) = False Then

                    If DbContext.VendorRepresentatives.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorRepresentativeCode1) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 1 - does not exist"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 1 - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(VendorRepresentativeCode2) = False Then

            Try

                If String.IsNullOrWhiteSpace(VendorCode) = False Then

                    If DbContext.VendorRepresentatives.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorRepresentativeCode2) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 2 - does not exist"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 2 - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(BuyerEmployeeCode) = False Then

            Try

                If DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = BuyerEmployeeCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Buyer Employee Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Buyer Employee Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(MarketCode) = False Then

            Try

                If DbContext.Markets.SingleOrDefault(Function(Entity) Entity.Code = MarketCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Market Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Market Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(FiscalPeriodCode) = False Then

            Try

                If DbContext.FiscalPeriods.SingleOrDefault(Function(Entity) Entity.Code = FiscalPeriodCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Fiscal Period Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Fiscal Period Code - error validating"
                IsValid = False
            End Try

        End If

        ValidateInternetOrderHeader = IsValid

    End Function
    Private Function ValidateInternetOrder(DbContext As APIDbContext, OrderNumber As Integer, OrderDescription As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                                          CampaignCode As String, SalesClassCode As String, VendorCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                                          ClientPO As String, BuyerName As String, BuyerEmployeeCode As String, OrderDate As Nullable(Of Date), OrderComment As String, HouseComment As String, MarketCode As String,
                                          StartDate As Nullable(Of Date), EndDate As Nullable(Of Date), IsNetAmount As Boolean, OrderLineNumber As Integer, AdNumber As String, Headline As String,
                                          AdSizeCode As String, JobNumber As Nullable(Of Integer), JobComponentNumber As Nullable(Of Short), InternetTypeCode As String, URL As String,
                                          TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As Nullable(Of Integer), GuaranteedImpressions As Nullable(Of Integer),
                                          ActualImpressions As Nullable(Of Integer), LineMarketCode As String, Rate As Nullable(Of Decimal), NetCharge As Nullable(Of Decimal), AdditionalCharge As Nullable(Of Decimal),
                                          CostType As String, MarkupPercentage As Nullable(Of Decimal), RebatePercentage As Nullable(Of Decimal), RebateAmount As Nullable(Of Decimal),
                                          Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim IsValid As Boolean = True

        If OrderNumber > 0 Then

            If DbContext.MediaOrderViews.Any(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.MediaType = "I") = False Then

                ErrorMessage &= System.Environment.NewLine & "Order Number does not exist"
                IsValid = False

            End If

        End If

        If String.IsNullOrWhiteSpace(OrderDescription) Then

            ErrorMessage &= System.Environment.NewLine & "Order Description is required"
            IsValid = False

        End If

        If String.IsNullOrWhiteSpace(ClientCode) Then

            ErrorMessage &= System.Environment.NewLine & "Client Code is required"
            IsValid = False

        Else

            Try

                If DbContext.Clients.SingleOrDefault(Function(Entity) Entity.Code = ClientCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Client Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Client Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(DivisionCode) Then

            ErrorMessage &= System.Environment.NewLine & "Division Code is required"
            IsValid = False

        Else

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    If DbContext.Divisions.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Code = DivisionCode) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Division Code - does not exist"
                        IsValid = False

                    End If

                Catch ex As Exception
                    ErrorMessage &= System.Environment.NewLine & "Invalid Division Code - error validating"
                    IsValid = False
                End Try

            End If

        End If

        If String.IsNullOrWhiteSpace(ProductCode) Then

            ErrorMessage &= System.Environment.NewLine & "Product Code is required"
            IsValid = False

        Else

            If String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                Try

                    If DbContext.Products.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.Code = ProductCode) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Product Code - does not exist"
                        IsValid = False

                    End If

                Catch ex As Exception
                    ErrorMessage &= System.Environment.NewLine & "Invalid Product Code - error validating"
                    IsValid = False
                End Try

            End If

        End If

        If String.IsNullOrWhiteSpace(CampaignCode) = False Then

            Try
                'PJH 05/16/19 - Allow campaign from any level or Client only and is not closed
                If DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso
                                                                        Entity.ProductCode = ProductCode AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing AndAlso
                    DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso
                                                                        Entity.ProductCode Is Nothing AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing AndAlso
                    DbContext.Campaigns.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso
                                                                        Entity.ProductCode Is Nothing AndAlso Entity.Code = CampaignCode AndAlso Entity.IsClosed = 0) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Campaign Code - does not exist or is closed"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Campaign Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(SalesClassCode) Then

            ErrorMessage &= System.Environment.NewLine & "Sales Class Code is required"
            IsValid = False

        Else

            Try

                If DbContext.SalesClasses.SingleOrDefault(Function(Entity) Entity.Code = SalesClassCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Sales Class Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Sales Class Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(VendorCode) Then

            ErrorMessage &= System.Environment.NewLine & "Vendor Code is required"
            IsValid = False

        Else

            Try

                If DbContext.Vendors.SingleOrDefault(Function(Entity) Entity.Code = VendorCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(VendorRepresentativeCode1) = False Then

            Try

                If String.IsNullOrWhiteSpace(VendorCode) = False Then

                    If DbContext.VendorRepresentatives.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorRepresentativeCode1) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 1 - does not exist"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 1 - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(VendorRepresentativeCode2) = False Then

            Try

                If String.IsNullOrWhiteSpace(VendorCode) = False Then

                    If DbContext.VendorRepresentatives.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorRepresentativeCode2) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 2 - does not exist"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Vendor Rep Code 2 - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(BuyerEmployeeCode) = False Then

            Try

                If DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = BuyerEmployeeCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Buyer Employee Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Buyer Employee Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(MarketCode) = False Then

            Try

                If DbContext.Markets.SingleOrDefault(Function(Entity) Entity.Code = MarketCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Market Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Market Code - error validating"
                IsValid = False
            End Try

        End If

        If StartDate.HasValue = False OrElse StartDate = Date.MinValue Then

            ErrorMessage &= System.Environment.NewLine & "Start Date is required"
            IsValid = False

        End If

        If EndDate.HasValue = False OrElse EndDate = Date.MinValue Then

            ErrorMessage &= System.Environment.NewLine & "End Date is required"
            IsValid = False

        End If

        If (StartDate.HasValue = False OrElse StartDate = Date.MinValue) = False AndAlso
                (EndDate.HasValue = False OrElse EndDate = Date.MinValue) = False Then

            If StartDate > EndDate Then

                ErrorMessage &= System.Environment.NewLine & "Start Date cannot be greater than End Date"
                IsValid = False

            End If

        End If

        If OrderLineNumber > 0 Then

            If DbContext.InternetOrderDetails.Any(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.LineNumber = OrderLineNumber) = False Then

                ErrorMessage &= System.Environment.NewLine & "Order Line Number does not exist"
                IsValid = False

            End If

        End If

        If String.IsNullOrWhiteSpace(AdNumber) = False Then

            Try

                If DbContext.AdNumbers.SingleOrDefault(Function(Entity) Entity.Number = AdNumber AndAlso Entity.ClientCode = ClientCode) Is Nothing Then

                    If DbContext.AdNumbers.SingleOrDefault(Function(Entity) Entity.Number = AdNumber AndAlso Entity.ClientCode = Nothing) Is Nothing Then

                        ErrorMessage &= System.Environment.NewLine & "Invalid Ad Number - does not exist"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Ad Number - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(AdSizeCode) = False Then

            Try

                If DbContext.AdSizes.SingleOrDefault(Function(Entity) Entity.MediaType = "I" AndAlso Entity.Code = AdSizeCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Ad Size Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Ad Size Code - error validating"
                IsValid = False
            End Try

        End If

        If JobNumber.GetValueOrDefault(0) > 0 AndAlso JobComponentNumber.GetValueOrDefault(0) = 0 Then

            ErrorMessage &= System.Environment.NewLine & "Invalid Job Component Number"
            IsValid = False

        ElseIf JobNumber.GetValueOrDefault(0) = 0 AndAlso JobComponentNumber.GetValueOrDefault(0) > 0 Then

            ErrorMessage &= System.Environment.NewLine & "Invalid Job Number"
            IsValid = False

        ElseIf JobNumber.GetValueOrDefault(0) > 0 AndAlso JobComponentNumber.GetValueOrDefault(0) > 0 Then

            Try

                If DbContext.JobComponents.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso
                                                                            Entity.ProductCode = ProductCode AndAlso Entity.JobNumber = JobNumber AndAlso
                                                                            Entity.JobComponentNumber = JobComponentNumber) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Job\Component Number - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Job\Component Number - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(InternetTypeCode) = False Then

            Try

                If DbContext.InternetTypes.SingleOrDefault(Function(Entity) Entity.Code = InternetTypeCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Internet Type Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Internet Type Code - error validating"
                IsValid = False
            End Try

        End If

        If GuaranteedImpressions.GetValueOrDefault(0) = 0 Then

            If CostType <> AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                ErrorMessage &= System.Environment.NewLine & "Guaranteed Impressions is required"
                IsValid = False

            End If

        End If

        If String.IsNullOrWhiteSpace(LineMarketCode) = False Then

            Try

                If DbContext.Markets.SingleOrDefault(Function(Entity) Entity.Code = LineMarketCode) Is Nothing Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Line Market Code - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Line Market Code - error validating"
                IsValid = False
            End Try

        End If

        If String.IsNullOrWhiteSpace(CostType) Then

            ErrorMessage &= System.Environment.NewLine & "Cost Type is required"
            IsValid = False

        Else

            Try

                If CostType <> AdvantageFramework.Database.Entities.CostType.CPM.ToString AndAlso
                        CostType <> AdvantageFramework.Database.Entities.CostType.CPC.ToString AndAlso
                        CostType <> AdvantageFramework.Database.Entities.CostType.CPA.ToString AndAlso
                        CostType <> AdvantageFramework.Database.Entities.CostType.NA.ToString Then

                    ErrorMessage &= System.Environment.NewLine & "Invalid Cost Type - does not exist"
                    IsValid = False

                End If

            Catch ex As Exception
                ErrorMessage &= System.Environment.NewLine & "Invalid Cost Type - error validating"
                IsValid = False
            End Try

        End If

        ValidateInternetOrder = IsValid

    End Function

    Private Function DeleteOrder(DbContext As APIDbContext, MediaType As String, OrderNumber As Integer) As MediaOrderResponse

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim SqlParametermedia_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        MediaOrderResponse = New MediaOrderResponse

        Try

            SqlParametermedia_type = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar) With {.Value = MediaType}
            SqlParameterorder_nbr = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int) With {.Value = OrderNumber}
            SqlParameterline_nbr = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.Int) With {.Value = System.DBNull.Value}

            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, 200) With {.Value = "", .Direction = ParameterDirection.Output}


            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                 "EXEC advsp_media_delete_order @media_type,@order_nbr,@line_nbr,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                 SqlParametermedia_type, SqlParameterorder_nbr, SqlParameterline_nbr, SqlParameterReturnValue, SqlParameterReturnValueMessage)

        Catch ex As Exception

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        MediaOrderResponse.OrderNumber = OrderNumber
        MediaOrderResponse.OrderLineNumber = Nothing

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            If SqlParameterReturnValue.Value <> 0 Then

                MediaOrderResponse.IsSuccessful = False
                MediaOrderResponse.Message = SqlParameterReturnValueMessage.Value

            Else

                MediaOrderResponse.IsSuccessful = True
                MediaOrderResponse.Message = SqlParameterReturnValueMessage.Value

            End If

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage

        End If

        DeleteOrder = MediaOrderResponse

    End Function
    Private Function DeleteOrderLine(DbContext As APIDbContext, MediaType As String, OrderNumber As Integer, OrderLineNumber As Integer) As MediaOrderResponse

        'objects
        Dim MediaOrderResponse As MediaOrderResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim SqlParametermedia_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        MediaOrderResponse = New MediaOrderResponse

        Try

            SqlParametermedia_type = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar) With {.Value = MediaType}
            SqlParameterorder_nbr = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int) With {.Value = OrderNumber}
            SqlParameterline_nbr = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.Int) With {.Value = OrderLineNumber}

            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, 200) With {.Value = "", .Direction = ParameterDirection.Output}


            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                 "EXEC advsp_media_delete_order @media_type,@order_nbr,@line_nbr,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                 SqlParametermedia_type, SqlParameterorder_nbr, SqlParameterline_nbr, SqlParameterReturnValue, SqlParameterReturnValueMessage)

        Catch ex As Exception

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        MediaOrderResponse.OrderNumber = OrderNumber
        MediaOrderResponse.OrderLineNumber = OrderLineNumber

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            If SqlParameterReturnValue.Value <> 0 Then

                MediaOrderResponse.IsSuccessful = False
                MediaOrderResponse.Message = SqlParameterReturnValueMessage.Value

            Else

                MediaOrderResponse.IsSuccessful = True
                MediaOrderResponse.Message = SqlParameterReturnValueMessage.Value

            End If

        Else

            MediaOrderResponse.IsSuccessful = False
            MediaOrderResponse.Message = ErrorMessage

        End If

        DeleteOrderLine = MediaOrderResponse

    End Function
    Private Function AddReviseMediaOrder(DbContext As APIDbContext, UserCode As String, Action As String, OrderType As String, MediaType As String,
                                         OrderNumber As Integer, OrderDescription As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                                         CampaignCode As String, SalesClassCode As String, VendorCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                                         ClientPO As String, BuyerName As String, BuyerEmployeeCode As String, OrderDate As Nullable(Of Date), OrderComment As String,
                                         HouseComment As String, MarketCode As String, StartDate As Nullable(Of Date), EndDate As Nullable(Of Date), NetGross As Integer,
                                         Units As String, OrderLineNumber As Integer, Size As String, AdNumber As String, Headline As String, Material As String, EditionIssue As String,
                                         Section As String, SizeCode As String, ProductionSize As String, JobNumber As Nullable(Of Integer), JobComponentNumber As Nullable(Of Short),
                                         CreativeSize As String, InternetOutdoorTypeCode As String, URLLocation As String, TargetAudience As String, Placement1 As String,
                                         Placement2 As String, ProjectedImpressions As Nullable(Of Integer), GuaranteedImpressions As Nullable(Of Integer),
                                         ActualImpressions As Nullable(Of Integer), LineMarketCode As String, ColorCharge As Nullable(Of Decimal), Rate As Nullable(Of Decimal), NetCharge As Nullable(Of Decimal),
                                         AdditionalCharge As Nullable(Of Decimal), DiscountAmount As Nullable(Of Decimal), PrintColumns As Nullable(Of Decimal), PrintInches As Nullable(Of Decimal), PrintLines As Nullable(Of Decimal),
                                         CostType As String, CostRate As Nullable(Of Decimal), RateType As String, MarkupPercentage As Nullable(Of Decimal), RebatePercentage As Nullable(Of Decimal),
                                         RebateAmount As Nullable(Of Decimal), CommissionPercentage As Nullable(Of Decimal), IsQuote As Nullable(Of Integer),
                                         PRCStatus As Nullable(Of Integer), Insturctions As String, OrderCopy As String, MaterialNotes As String,
                                         PositionInfo As String, CloseInfo As String, RateInfo As String, MiscInfo As String, InHouseComments As String) As MediaOrderInternalResponse

        'objects
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_desc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercl_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiv_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprd_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercmp_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermedia_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersales_class_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervn_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervr_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervr_code2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterclient_po As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbuyer As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbuyer_emp_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_comment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterhouse_comment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermarket_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstart_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterend_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternet_gross As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterunits As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterline_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersize As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_number As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterheadline As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermaterial As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteredition_issue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersection As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersize_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterproduction_size As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterjob_number As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterjob_component_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercreative_size As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametero_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterurl_location As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertarget_audience As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterplacement_1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterplacement_2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterproj_impressions As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterguaranteed_impress As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteract_impressions As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_market_code As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametercolor_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternetcharge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteraddl_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_columns As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_inches As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_lines As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercost_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercost_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermarkup_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercomm_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiscount_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteris_quote As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprc_status As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterinstructions As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_copy As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermatl_notes As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterposition_info As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterclose_info As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_info As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermisc_info As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterin_house_cmts As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterorder_nbr_o As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_nbr_o As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        MediaOrderInternalResponse = New MediaOrderInternalResponse

        Try

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar) With {.Value = UserCode}
            SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar) With {.Value = Action}

            SqlParameterorder_type = New System.Data.SqlClient.SqlParameter("@order_type", SqlDbType.VarChar) With {.Value = OrderType}
            SqlParameterorder_nbr = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int) With {.Value = OrderNumber}
            SqlParameterorder_desc = New System.Data.SqlClient.SqlParameter("@order_desc", SqlDbType.VarChar) With {.Value = OrderDescription}
            SqlParametercl_code = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar) With {.Value = ClientCode}
            SqlParameterdiv_code = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar) With {.Value = DivisionCode}
            SqlParameterprd_code = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar) With {.Value = ProductCode}
            SqlParametercmp_code = New System.Data.SqlClient.SqlParameter("@cmp_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CampaignCode), DBNull.Value, CampaignCode)}
            SqlParametermedia_type = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar) With {.Value = MediaType}
            SqlParametersales_class_code = New System.Data.SqlClient.SqlParameter("@sales_class_code", SqlDbType.VarChar) With {.Value = SalesClassCode}
            SqlParametervn_code = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar) With {.Value = VendorCode}
            SqlParametervr_code = New System.Data.SqlClient.SqlParameter("@vr_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(VendorRepresentativeCode1), DBNull.Value, VendorRepresentativeCode1)}
            SqlParametervr_code2 = New System.Data.SqlClient.SqlParameter("@vr_code2", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(VendorRepresentativeCode2), DBNull.Value, VendorRepresentativeCode2)}
            SqlParameterclient_po = New System.Data.SqlClient.SqlParameter("@client_po", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ClientPO), DBNull.Value, ClientPO)}
            SqlParameterbuyer = New System.Data.SqlClient.SqlParameter("@buyer", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BuyerName), DBNull.Value, BuyerName)}
            SqlParameterbuyer_emp_code = New System.Data.SqlClient.SqlParameter("@buyer_emp_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BuyerEmployeeCode), DBNull.Value, BuyerEmployeeCode)}
            SqlParameterorder_date = New System.Data.SqlClient.SqlParameter("@order_date", SqlDbType.SmallDateTime) With {.Value = If(OrderDate = Date.MinValue, DBNull.Value, OrderDate)}
            SqlParameterorder_comment = New System.Data.SqlClient.SqlParameter("@order_comment", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(OrderComment), DBNull.Value, OrderComment)}
            SqlParameterhouse_comment = New System.Data.SqlClient.SqlParameter("@house_comment", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(HouseComment), DBNull.Value, HouseComment)}
            SqlParametermarket_code = New System.Data.SqlClient.SqlParameter("@market_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(MarketCode), DBNull.Value, MarketCode)}
            SqlParameterstart_date = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime) With {.Value = If(StartDate.HasValue = False, DBNull.Value, StartDate)}
            SqlParameterend_date = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.SmallDateTime) With {.Value = If(EndDate.HasValue = False, DBNull.Value, EndDate)}
            SqlParameternet_gross = New System.Data.SqlClient.SqlParameter("@net_gross", SqlDbType.SmallInt) With {.Value = NetGross}
            SqlParameterunits = New System.Data.SqlClient.SqlParameter("@units", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Units), DBNull.Value, Units)}

            SqlParameterline_nbr = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.Int) With {.Value = OrderLineNumber}
            SqlParametersize = New System.Data.SqlClient.SqlParameter("@size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Size), DBNull.Value, Size)}
            SqlParameterad_number = New System.Data.SqlClient.SqlParameter("@ad_number", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(AdNumber), DBNull.Value, AdNumber)}
            SqlParameterheadline = New System.Data.SqlClient.SqlParameter("@headline", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Headline), DBNull.Value, Headline)}
            SqlParametermaterial = New System.Data.SqlClient.SqlParameter("@material", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Material), DBNull.Value, Material)}
            SqlParameteredition_issue = New System.Data.SqlClient.SqlParameter("@edition_issue", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(EditionIssue), DBNull.Value, EditionIssue)}
            SqlParametersection = New System.Data.SqlClient.SqlParameter("@section", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Section), DBNull.Value, Section)}
            SqlParametersize_code = New System.Data.SqlClient.SqlParameter("@size_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(SizeCode), DBNull.Value, SizeCode)}
            SqlParameterproduction_size = New System.Data.SqlClient.SqlParameter("@production_size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ProductionSize), DBNull.Value, ProductionSize)}

            SqlParameterjob_number = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int) With {.Value = If(JobNumber.HasValue = False, DBNull.Value, JobNumber)}
            SqlParameterjob_component_nbr = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt) With {.Value = If(JobComponentNumber.HasValue = False, DBNull.Value, JobComponentNumber)}
            SqlParametercreative_size = New System.Data.SqlClient.SqlParameter("@creative_size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CreativeSize), DBNull.Value, CreativeSize)}
            SqlParametero_type = New System.Data.SqlClient.SqlParameter("@o_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(InternetOutdoorTypeCode), DBNull.Value, InternetOutdoorTypeCode)}
            SqlParameterurl_location = New System.Data.SqlClient.SqlParameter("@url_location", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(URLLocation), DBNull.Value, URLLocation)}
            SqlParametertarget_audience = New System.Data.SqlClient.SqlParameter("@target_audience", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(TargetAudience), DBNull.Value, TargetAudience)}
            SqlParameterplacement_1 = New System.Data.SqlClient.SqlParameter("@placement_1", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Placement1), DBNull.Value, Placement1)}
            SqlParameterplacement_2 = New System.Data.SqlClient.SqlParameter("@placement_2", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Placement2), DBNull.Value, Placement2)}
            SqlParameterproj_impressions = New System.Data.SqlClient.SqlParameter("@proj_impressions", SqlDbType.Int) With {.Value = If(ProjectedImpressions.HasValue = False, DBNull.Value, ProjectedImpressions)}
            SqlParameterguaranteed_impress = New System.Data.SqlClient.SqlParameter("@guaranteed_impress", SqlDbType.Int) With {.Value = If(GuaranteedImpressions.HasValue = False, DBNull.Value, GuaranteedImpressions)}
            SqlParameteract_impressions = New System.Data.SqlClient.SqlParameter("@act_impressions", SqlDbType.Int) With {.Value = If(ActualImpressions.HasValue = False, DBNull.Value, ActualImpressions)}
            SqlParameterline_market_code = New System.Data.SqlClient.SqlParameter("@line_market_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(LineMarketCode), DBNull.Value, LineMarketCode)}

            SqlParametercolor_charge = New System.Data.SqlClient.SqlParameter("@color_charge", SqlDbType.Decimal) With {.Value = If(ColorCharge.HasValue = False, DBNull.Value, ColorCharge)}
            SqlParameterrate = New System.Data.SqlClient.SqlParameter("@rate", SqlDbType.Decimal) With {.Value = If(Rate.HasValue = False, DBNull.Value, Rate)}
            SqlParameternetcharge = New System.Data.SqlClient.SqlParameter("@netcharge", SqlDbType.Decimal) With {.Value = If(NetCharge.HasValue = False, DBNull.Value, NetCharge)}
            SqlParameteraddl_charge = New System.Data.SqlClient.SqlParameter("@addl_charge", SqlDbType.Decimal) With {.Value = If(AdditionalCharge.HasValue = False, DBNull.Value, AdditionalCharge)}
            SqlParameterprint_columns = New System.Data.SqlClient.SqlParameter("@print_columns", SqlDbType.Decimal) With {.Value = If(PrintColumns.HasValue = False, DBNull.Value, PrintColumns)}
            SqlParameterprint_inches = New System.Data.SqlClient.SqlParameter("@print_inches", SqlDbType.Decimal) With {.Value = If(PrintInches.HasValue = False, DBNull.Value, PrintInches)}
            SqlParameterprint_lines = New System.Data.SqlClient.SqlParameter("@print_lines", SqlDbType.Decimal) With {.Value = If(PrintLines.HasValue = False, DBNull.Value, PrintLines)}
            SqlParametercost_type = New System.Data.SqlClient.SqlParameter("@cost_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CostType), DBNull.Value, CostType)}
            SqlParametercost_rate = New System.Data.SqlClient.SqlParameter("@cost_rate", SqlDbType.Decimal) With {.Value = If(CostRate.HasValue = False, DBNull.Value, CostRate)}
            SqlParameterrate_type = New System.Data.SqlClient.SqlParameter("@rate_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(RateType), DBNull.Value, RateType)}
            SqlParametermarkup_pct = New System.Data.SqlClient.SqlParameter("@markup_pct", SqlDbType.Decimal) With {.Value = If(MarkupPercentage.HasValue = False, DBNull.Value, MarkupPercentage)}
            SqlParameterrebate_pct = New System.Data.SqlClient.SqlParameter("@rebate_pct", SqlDbType.Decimal) With {.Value = If(RebatePercentage.HasValue = False, DBNull.Value, RebatePercentage)}
            SqlParameterrebate_amt = New System.Data.SqlClient.SqlParameter("@rebate_amt", SqlDbType.Decimal) With {.Value = If(RebateAmount.HasValue = False, DBNull.Value, RebateAmount)}
            SqlParametercomm_pct = New System.Data.SqlClient.SqlParameter("@comm_pct", SqlDbType.Decimal) With {.Value = If(CommissionPercentage.HasValue = False, DBNull.Value, CommissionPercentage)}
            SqlParameterdiscount_amt = New System.Data.SqlClient.SqlParameter("@discount_amt", SqlDbType.Decimal) With {.Value = If(DiscountAmount.HasValue = False, DBNull.Value, DiscountAmount)}
            SqlParameteris_quote = New System.Data.SqlClient.SqlParameter("@is_quote", SqlDbType.SmallInt) With {.Value = If(IsQuote.HasValue = False, DBNull.Value, IsQuote)}
            SqlParameterprc_status = New System.Data.SqlClient.SqlParameter("@prc_status", SqlDbType.SmallInt) With {.Value = If(PRCStatus.HasValue = False, DBNull.Value, PRCStatus)}
            SqlParameterinstructions = New System.Data.SqlClient.SqlParameter("@instructions", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Insturctions), DBNull.Value, Insturctions)}
            SqlParameterorder_copy = New System.Data.SqlClient.SqlParameter("@order_copy", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(OrderCopy), DBNull.Value, OrderCopy)}
            SqlParametermatl_notes = New System.Data.SqlClient.SqlParameter("@matl_notes", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(MaterialNotes), DBNull.Value, MaterialNotes)}
            SqlParameterposition_info = New System.Data.SqlClient.SqlParameter("@position_info", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(PositionInfo), DBNull.Value, PositionInfo)}
            SqlParameterclose_info = New System.Data.SqlClient.SqlParameter("@close_info", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CloseInfo), DBNull.Value, CloseInfo)}
            SqlParameterrate_info = New System.Data.SqlClient.SqlParameter("@rate_info", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(RateInfo), DBNull.Value, RateInfo)}
            SqlParametermisc_info = New System.Data.SqlClient.SqlParameter("@misc_info", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(MiscInfo), DBNull.Value, MiscInfo)}
            SqlParameterin_house_cmts = New System.Data.SqlClient.SqlParameter("@in_house_cmts", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(InHouseComments), DBNull.Value, InHouseComments)}

            SqlParameterorder_nbr_o = New System.Data.SqlClient.SqlParameter("@order_nbr_o", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterline_nbr_o = New System.Data.SqlClient.SqlParameter("@line_nbr_o", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, 200) With {.Value = "", .Direction = ParameterDirection.Output}

            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                 "EXEC advsp_revise_order_process_api @user_id,@action,@order_type,@order_nbr,
                                                  @order_desc,@cl_code,@div_code,@prd_code,
                                                  @cmp_code,@media_type,@sales_class_code,
                                                  @vn_code,@vr_code,@vr_code2,@client_po,
                                                  @buyer,@buyer_emp_code,@order_date,@order_comment,@house_comment,@market_code,
                                                  @start_date,@end_date,@net_gross,@units,
                                                  @line_nbr,@size,@ad_number,@headline,
                                                  @material,@edition_issue,@section,@size_code,
                                                  @production_size,@job_number,@job_component_nbr,@creative_size,
                                                  @o_type,@url_location,@target_audience,@placement_1,
                                                  @placement_2,@proj_impressions,@guaranteed_impress,@act_impressions,
                                                  @line_market_code,@color_charge,@rate,@netcharge,
                                                  @addl_charge,@print_columns,@print_inches,@print_lines,
                                                  @cost_type,@cost_rate,@rate_type,@markup_pct,
                                                  @rebate_pct,@rebate_amt,@comm_pct,@discount_amt,@is_quote,
                                                  @prc_status,@instructions,@order_copy,@matl_notes,
                                                  @position_info,@close_info,@rate_info,@misc_info,@in_house_cmts,
                                                  @order_nbr_o OUTPUT,@line_nbr_o OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                 SqlParameterUserID, SqlParameterAction, SqlParameterorder_type, SqlParameterorder_nbr,
                                                 SqlParameterorder_desc, SqlParametercl_code, SqlParameterdiv_code, SqlParameterprd_code,
                                                 SqlParametercmp_code, SqlParametermedia_type, SqlParametersales_class_code,
                                                 SqlParametervn_code, SqlParametervr_code, SqlParametervr_code2, SqlParameterclient_po,
                                                 SqlParameterbuyer, SqlParameterbuyer_emp_code, SqlParameterorder_date, SqlParameterorder_comment, SqlParameterhouse_comment, SqlParametermarket_code,
                                                 SqlParameterstart_date, SqlParameterend_date, SqlParameternet_gross, SqlParameterunits,
                                                 SqlParameterline_nbr, SqlParametersize, SqlParameterad_number, SqlParameterheadline,
                                                 SqlParametermaterial, SqlParameteredition_issue, SqlParametersection, SqlParametersize_code,
                                                 SqlParameterproduction_size, SqlParameterjob_number, SqlParameterjob_component_nbr, SqlParametercreative_size,
                                                 SqlParametero_type, SqlParameterurl_location, SqlParametertarget_audience, SqlParameterplacement_1,
                                                 SqlParameterplacement_2, SqlParameterproj_impressions, SqlParameterguaranteed_impress, SqlParameteract_impressions,
                                                 SqlParameterline_market_code, SqlParametercolor_charge, SqlParameterrate, SqlParameternetcharge,
                                                 SqlParameteraddl_charge, SqlParameterprint_columns, SqlParameterprint_inches, SqlParameterprint_lines,
                                                 SqlParametercost_type, SqlParametercost_rate, SqlParameterrate_type, SqlParametermarkup_pct,
                                                 SqlParameterrebate_pct, SqlParameterrebate_amt, SqlParametercomm_pct, SqlParameterdiscount_amt, SqlParameteris_quote,
                                                 SqlParameterprc_status, SqlParameterinstructions, SqlParameterorder_copy, SqlParametermatl_notes,
                                                 SqlParameterposition_info, SqlParameterclose_info, SqlParameterrate_info, SqlParametermisc_info, SqlParameterin_house_cmts,
                                                 SqlParameterorder_nbr_o, SqlParameterline_nbr_o, SqlParameterReturnValue, SqlParameterReturnValueMessage)

        Catch ex As Exception

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            If SqlParameterReturnValue.Value <> 0 Then

                MediaOrderInternalResponse.IsSuccessful = False
                MediaOrderInternalResponse.Message = SqlParameterReturnValueMessage.Value

            Else

                MediaOrderInternalResponse.IsSuccessful = True
                MediaOrderInternalResponse.Message = SqlParameterReturnValueMessage.Value
                MediaOrderInternalResponse.OrderNumber = SqlParameterorder_nbr_o.Value
                MediaOrderInternalResponse.OrderLineNumber = SqlParameterline_nbr_o.Value

                If MediaOrderInternalResponse.Message = "N" Then

                    MediaOrderInternalResponse.Message = String.Empty

                End If

            End If

        Else

            MediaOrderInternalResponse.IsSuccessful = False
            MediaOrderInternalResponse.Message = ErrorMessage

        End If

        AddReviseMediaOrder = MediaOrderInternalResponse

    End Function
    Private Function UpdateReviseMediaOrder(DbContext As APIDbContext, UserCode As String, Action As String, OrderType As String, OrderNumber As Integer,
                                            OrderDescription As String, ClientCode As String, DivisionCode As String, ProductCode As String, OfficeCode As String,
                                            CampaignCode As String, SalesClassCode As String, VendorCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                                            ClientPO As String, ClientRef As String, Status As String, OrderDate As Nullable(Of Date), BuyerName As String, OrderComment As String, HouseComment As String,
                                            MailToVendor As Nullable(Of Short), MailToRep1 As Nullable(Of Short), MailToRep2 As Nullable(Of Short), BillCoopCode As String, OrderProcessControl As Nullable(Of Short),
                                            MarketCode As String, StartDate As Nullable(Of Date), EndDate As Nullable(Of Date), Units As String, NumberOfUntis As Nullable(Of Integer),
                                            IsNetAmount As Nullable(Of Short), CreatedDate As Nullable(Of Date), Cancelled As Nullable(Of Short), CancelledByUserCode As String, CancelledDate As Nullable(Of Date),
                                            ModifiedByUserCode As String, ModifiedDate As Nullable(Of Date), ModifiedComments As String, RevisedFlag As Nullable(Of Short), LinkID As Nullable(Of Integer),
                                            ReconcileFlag As Nullable(Of Short), CampaignID As Nullable(Of Integer), Printed As Nullable(Of Short), OrderAccepted As Nullable(Of Short), FiscalPeriodCode As String, Locked As String,
                                            LockedByUserCode As String, BCCID As Nullable(Of Integer), IsQuote As Nullable(Of Integer), BuyerEmployeeCode As String) As MediaOrderInternalResponse

        'objects
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim SqlParameteruser_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteraction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterret_val As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterret_val_s As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_desc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercl_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiv_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprd_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteroffice_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercmp_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersales_class_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervn_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervr_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametervr_code2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterclient_po As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterclient_ref As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstatus As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbuyer As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_comment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterhouse_comment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterpub_station As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrep1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrep2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbill_coop_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterord_process_contrl As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermarket_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstart_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterend_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterunits As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternbr_of_units As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternet_gross As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercreate_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercancelled As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercancelled_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercancelled_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_comments As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrevised_flag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterlink_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterreconcile_flag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercmp_identifier As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprinted As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_accepted As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterfiscal_period_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterlocked As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterlocked_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbcc_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteris_quote As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbuyer_emp_code As System.Data.SqlClient.SqlParameter = Nothing

        MediaOrderInternalResponse = New MediaOrderInternalResponse

        Try

            SqlParameteruser_id = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar) With {.Value = UserCode}
            SqlParameteraction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar) With {.Value = Action}
            SqlParameterorder_type = New System.Data.SqlClient.SqlParameter("@order_type", SqlDbType.VarChar) With {.Value = OrderType}
            SqlParameterret_val = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterret_val_s = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, -1) With {.Value = "", .Direction = ParameterDirection.Output}
            SqlParameterorder_nbr = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int) With {.Value = OrderNumber}
            SqlParameterorder_desc = New System.Data.SqlClient.SqlParameter("@order_desc", SqlDbType.VarChar) With {.Value = OrderDescription}
            SqlParametercl_code = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar) With {.Value = ClientCode}
            SqlParameterdiv_code = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar) With {.Value = DivisionCode}
            SqlParameterprd_code = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar) With {.Value = ProductCode}
            SqlParameteroffice_code = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(OfficeCode), DBNull.Value, OfficeCode)}
            SqlParametercmp_code = New System.Data.SqlClient.SqlParameter("@cmp_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CampaignCode), DBNull.Value, CampaignCode)}
            SqlParametersales_class_code = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar) With {.Value = SalesClassCode}
            SqlParametervn_code = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar) With {.Value = VendorCode}
            SqlParametervr_code = New System.Data.SqlClient.SqlParameter("@vr_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(VendorRepresentativeCode1), DBNull.Value, VendorRepresentativeCode1)}
            SqlParametervr_code2 = New System.Data.SqlClient.SqlParameter("@vr_code2", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(VendorRepresentativeCode2), DBNull.Value, VendorRepresentativeCode2)}
            SqlParameterclient_po = New System.Data.SqlClient.SqlParameter("@client_po", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ClientPO), DBNull.Value, ClientPO)}
            SqlParameterclient_ref = New System.Data.SqlClient.SqlParameter("@client_ref", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ClientRef), DBNull.Value, ClientRef)}
            SqlParameterstatus = New System.Data.SqlClient.SqlParameter("@status", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Status), DBNull.Value, Status)}
            SqlParameterorder_date = New System.Data.SqlClient.SqlParameter("@order_date", SqlDbType.SmallDateTime) With {.Value = If(OrderDate.HasValue = False, DBNull.Value, OrderDate)}
            SqlParameterbuyer = New System.Data.SqlClient.SqlParameter("@buyer", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BuyerName), DBNull.Value, BuyerName)}
            SqlParameterorder_comment = New System.Data.SqlClient.SqlParameter("@order_comment", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(OrderComment), DBNull.Value, OrderComment)}
            SqlParameterhouse_comment = New System.Data.SqlClient.SqlParameter("@house_comment", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(HouseComment), DBNull.Value, HouseComment)}
            SqlParameterpub_station = New System.Data.SqlClient.SqlParameter("@pub_station", SqlDbType.SmallInt) With {.Value = If(MailToVendor.HasValue = False, DBNull.Value, MailToVendor)}
            SqlParameterrep1 = New System.Data.SqlClient.SqlParameter("@rep1", SqlDbType.SmallInt) With {.Value = If(MailToRep1.HasValue = False, DBNull.Value, MailToRep1)}
            SqlParameterrep2 = New System.Data.SqlClient.SqlParameter("@rep2", SqlDbType.SmallInt) With {.Value = If(MailToRep2.HasValue = False, DBNull.Value, MailToRep2)}
            SqlParameterbill_coop_code = New System.Data.SqlClient.SqlParameter("@bill_coop_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BillCoopCode), DBNull.Value, BillCoopCode)}
            SqlParameterord_process_contrl = New System.Data.SqlClient.SqlParameter("@ord_process_contrl", SqlDbType.SmallInt) With {.Value = If(OrderProcessControl.HasValue = False, DBNull.Value, OrderProcessControl)}
            SqlParametermarket_code = New System.Data.SqlClient.SqlParameter("@market_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(MarketCode), DBNull.Value, MarketCode)}
            SqlParameterstart_date = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime) With {.Value = If(StartDate.HasValue = False, DBNull.Value, StartDate)}
            SqlParameterend_date = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.SmallDateTime) With {.Value = If(EndDate.HasValue = False, DBNull.Value, EndDate)}
            SqlParameterunits = New System.Data.SqlClient.SqlParameter("@units", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Units), DBNull.Value, Units)}
            SqlParameternbr_of_units = New System.Data.SqlClient.SqlParameter("@nbr_of_units", SqlDbType.Int) With {.Value = If(NumberOfUntis.HasValue = False, DBNull.Value, NumberOfUntis)}
            SqlParameternet_gross = New System.Data.SqlClient.SqlParameter("@net_gross", SqlDbType.SmallInt) With {.Value = If(IsNetAmount.HasValue = False, DBNull.Value, IsNetAmount)}
            SqlParametercreate_date = New System.Data.SqlClient.SqlParameter("@create_date", SqlDbType.SmallDateTime) With {.Value = If(CreatedDate.HasValue = False, DBNull.Value, CreatedDate)}
            SqlParametercancelled = New System.Data.SqlClient.SqlParameter("@cancelled", SqlDbType.SmallInt) With {.Value = If(Cancelled.HasValue = False, DBNull.Value, Cancelled)}
            SqlParametercancelled_by = New System.Data.SqlClient.SqlParameter("@cancelled_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CancelledByUserCode), DBNull.Value, CancelledByUserCode)}
            SqlParametercancelled_date = New System.Data.SqlClient.SqlParameter("@cancelled_date", SqlDbType.SmallDateTime) With {.Value = If(CancelledDate.HasValue = False, DBNull.Value, CancelledDate)}
            SqlParametermodified_by = New System.Data.SqlClient.SqlParameter("@modified_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ModifiedByUserCode), DBNull.Value, ModifiedByUserCode)}
            SqlParametermodified_date = New System.Data.SqlClient.SqlParameter("@modified_date", SqlDbType.SmallDateTime) With {.Value = If(ModifiedDate.HasValue = False, DBNull.Value, ModifiedDate)}
            SqlParametermodified_comments = New System.Data.SqlClient.SqlParameter("@modified_comments", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ModifiedComments), DBNull.Value, ModifiedComments)}
            SqlParameterrevised_flag = New System.Data.SqlClient.SqlParameter("@revised_flag", SqlDbType.SmallInt) With {.Value = If(RevisedFlag.HasValue = False, DBNull.Value, RevisedFlag)}
            SqlParameterlink_id = New System.Data.SqlClient.SqlParameter("@link_id", SqlDbType.Int) With {.Value = If(LinkID.HasValue = False, DBNull.Value, LinkID)}
            SqlParameterreconcile_flag = New System.Data.SqlClient.SqlParameter("@reconcile_flag", SqlDbType.SmallInt) With {.Value = If(ReconcileFlag.HasValue = False, DBNull.Value, ReconcileFlag)}
            SqlParametercmp_identifier = New System.Data.SqlClient.SqlParameter("@cmp_identifier", SqlDbType.Int) With {.Value = If(CampaignID.HasValue = False, DBNull.Value, CampaignID)}
            SqlParameterprinted = New System.Data.SqlClient.SqlParameter("@printed", SqlDbType.SmallInt) With {.Value = If(Printed.HasValue = False, DBNull.Value, Printed)}
            SqlParameterorder_accepted = New System.Data.SqlClient.SqlParameter("@order_accepted", SqlDbType.SmallInt) With {.Value = If(OrderAccepted.HasValue = False, DBNull.Value, OrderAccepted)}
            SqlParameterfiscal_period_code = New System.Data.SqlClient.SqlParameter("@fiscal_period_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(FiscalPeriodCode), DBNull.Value, FiscalPeriodCode)}
            SqlParameterlocked = New System.Data.SqlClient.SqlParameter("@locked", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Locked), DBNull.Value, Locked)}
            SqlParameterlocked_by = New System.Data.SqlClient.SqlParameter("@locked_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(LockedByUserCode), DBNull.Value, LockedByUserCode)}
            SqlParameterbcc_id = New System.Data.SqlClient.SqlParameter("@bcc_id", SqlDbType.Int) With {.Value = If(BCCID.HasValue = False, DBNull.Value, BCCID)}
            SqlParameteris_quote = New System.Data.SqlClient.SqlParameter("@is_quote", SqlDbType.Int) With {.Value = If(IsQuote.HasValue = False, DBNull.Value, IsQuote)}
            SqlParameterbuyer_emp_code = New System.Data.SqlClient.SqlParameter("@buyer_emp_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BuyerEmployeeCode), DBNull.Value, BuyerEmployeeCode)}

            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                 "EXEC advsp_revise_order_header 
                                                  @user_id,@action,@order_type,@ret_val OUTPUT,@ret_val_s OUTPUT,
                                                  @order_nbr,@order_desc,@cl_code,@div_code,@prd_code,@office_code,@cmp_code, 
                                                  @media_type,@vn_code,@vr_code,@vr_code2,@client_po,@client_ref,@status, 
                                                  @order_date,@buyer,@order_comment,@house_comment,@pub_station,@rep1,@rep2, 
                                                  @bill_coop_code,@ord_process_contrl,@market_code,@start_date,@end_date, 
                                                  @units,@nbr_of_units,@net_gross,@create_date,@cancelled,@cancelled_by, 
                                                  @cancelled_date,@modified_by,@modified_date,@modified_comments,@revised_flag, 
                                                  @link_id,@reconcile_flag,@cmp_identifier,@printed,@order_accepted, 
                                                  @fiscal_period_code,@locked,@locked_by,@bcc_id,@is_quote,@buyer_emp_code",
                                                 SqlParameteruser_id, SqlParameteraction, SqlParameterorder_type, SqlParameterret_val,
                                                 SqlParameterret_val_s, SqlParameterorder_nbr, SqlParameterorder_desc, SqlParametercl_code,
                                                 SqlParameterdiv_code, SqlParameterprd_code, SqlParameteroffice_code, SqlParametercmp_code,
                                                 SqlParametersales_class_code, SqlParametervn_code, SqlParametervr_code, SqlParametervr_code2,
                                                 SqlParameterclient_po, SqlParameterclient_ref, SqlParameterstatus, SqlParameterorder_date,
                                                 SqlParameterbuyer, SqlParameterorder_comment, SqlParameterhouse_comment, SqlParameterpub_station,
                                                 SqlParameterrep1, SqlParameterrep2, SqlParameterbill_coop_code, SqlParameterord_process_contrl,
                                                 SqlParametermarket_code, SqlParameterstart_date, SqlParameterend_date, SqlParameterunits,
                                                 SqlParameternbr_of_units, SqlParameternet_gross, SqlParametercreate_date, SqlParametercancelled,
                                                 SqlParametercancelled_by, SqlParametercancelled_date, SqlParametermodified_by, SqlParametermodified_date,
                                                 SqlParametermodified_comments, SqlParameterrevised_flag, SqlParameterlink_id, SqlParameterreconcile_flag,
                                                 SqlParametercmp_identifier, SqlParameterprinted, SqlParameterorder_accepted, SqlParameterfiscal_period_code,
                                                 SqlParameterlocked, SqlParameterlocked_by, SqlParameterbcc_id, SqlParameteris_quote, SqlParameterbuyer_emp_code)

        Catch ex As Exception

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            If SqlParameterret_val.Value <> 0 Then

                MediaOrderInternalResponse.IsSuccessful = False
                MediaOrderInternalResponse.Message = SqlParameterret_val_s.Value

            Else

                MediaOrderInternalResponse.IsSuccessful = True
                MediaOrderInternalResponse.Message = SqlParameterret_val_s.Value
                MediaOrderInternalResponse.OrderNumber = OrderNumber
                MediaOrderInternalResponse.OrderLineNumber = 0

                If MediaOrderInternalResponse.Message = "N" Then

                    MediaOrderInternalResponse.Message = String.Empty

                End If

            End If

        Else

            MediaOrderInternalResponse.IsSuccessful = False
            MediaOrderInternalResponse.Message = ErrorMessage

        End If

        UpdateReviseMediaOrder = MediaOrderInternalResponse

    End Function
    Private Function UpdateReviseMediaOrderLine(DbContext As APIDbContext, UserCode As String, Action As String, OrderType As String, RebateAmountOverride As Short,
                                                RebatePercentageOverride As Short, MarkupPercentageOverride As Short, CommissionPercentageOverride As Short, OrderNumber As Integer,
                                                OrderLineNumber As Nullable(Of Integer), RevisionNumber As Nullable(Of Short), SequenceNumber As Nullable(Of Short),
                                                ActiveRevision As Nullable(Of Short), LinkDetailID As Nullable(Of Integer),
                                                StartDate As Nullable(Of Date), EndDate As Nullable(Of Date), CloseDate As Nullable(Of Date), MaterialCloseDate As Nullable(Of Date), ExtCloseDate As Nullable(Of Date), ExtMaterialCloseDate As Nullable(Of Date),
                                                BuyType As String, Month As Nullable(Of Integer), Year As Nullable(Of Integer), Date1 As Nullable(Of Date), Date2 As Nullable(Of Date), Date3 As Nullable(Of Date), Date4 As Nullable(Of Date), Date5 As Nullable(Of Date),
                                                Date6 As Nullable(Of Date), Date7 As Nullable(Of Date), Monday As Nullable(Of Boolean), Tuesday As Nullable(Of Boolean), Wednesday As Nullable(Of Boolean), Thursday As Nullable(Of Boolean), Friday As Nullable(Of Boolean),
                                                Saturday As Nullable(Of Boolean), Sunday As Nullable(Of Boolean),
                                                Spots1 As Nullable(Of Integer), Spots2 As Nullable(Of Integer), Spots3 As Nullable(Of Integer), Spots4 As Nullable(Of Integer), Spots5 As Nullable(Of Integer),
                                                Spots6 As Nullable(Of Integer), Spots7 As Nullable(Of Integer), TotalSpots As Nullable(Of Integer),
                                                JobNumber As Nullable(Of Integer), JobComponentNumber As Nullable(Of Short), Quantity As Nullable(Of Integer),
                                                Rate As Nullable(Of Decimal), NetRate As Nullable(Of Decimal), GrossRate As Nullable(Of Decimal), ExtNetAmount As Nullable(Of Decimal), ExtGrossAmount As Nullable(Of Decimal), CommissionAmount As Nullable(Of Decimal),
                                                RebateAmount As Nullable(Of Decimal), DiscountAmount As Nullable(Of Decimal), DiscountDescription As String, StateAmount As Nullable(Of Decimal), CountyAmount As Nullable(Of Decimal), CityAmount As Nullable(Of Decimal),
                                                NonResaleAmount As Nullable(Of Decimal), NetCharge As Nullable(Of Decimal), NetChargeDescription As String, AdditionalCharge As Nullable(Of Decimal), AdditionalChargeDescription As String,
                                                LineTotal As Nullable(Of Decimal), DateToBill As Nullable(Of Date), NonBillFlag As Nullable(Of Short), ModifiedByUserCode As String, ModifiedDate As Nullable(Of Date), ModifiedComments As String,
                                                BillTypeFlag As Nullable(Of Short), CommissionPercentage As Nullable(Of Decimal), MarkupPercentage As Nullable(Of Decimal), RebatePercentage As Nullable(Of Decimal), DiscountPercentage As Nullable(Of Decimal),
                                                TaxCode As String, TaxCityPercentage As Nullable(Of Decimal), TaxCountryPercentage As Nullable(Of Decimal), TaxStatePercentage As Nullable(Of Decimal), TaxResale As Nullable(Of Short),
                                                TaxApplyC As Nullable(Of Short), TaxApplyLN As Nullable(Of Short), TaxApplyND As Nullable(Of Short), TaxApplyNC As Nullable(Of Short), TaxApplyR As Nullable(Of Short), TaxApplyAI As Nullable(Of Short), ReconcileFlag As Nullable(Of Short),
                                                BillingAmount As Nullable(Of Decimal), EstimateNumber As Nullable(Of Integer), EstimateLineNumber As Nullable(Of Short), EstimateRevisionNumber As Nullable(Of Short), AdNumber As String, MaterialCompletion As Nullable(Of Date),
                                                Units As String, CostType As String, CostRate As Nullable(Of Decimal), NetBaseRate As Nullable(Of Decimal), GrossBaseRate As Nullable(Of Decimal), Programming As String, StartTime As String, EndTime As String,
                                                Length As Nullable(Of Short), Remarks As String, Tag As String, NetworkID As String, Headline As String, Size As String, EditionIssue As String,
                                                Material As String, Section As String, RateCardID As Nullable(Of Integer), RateDetailID As Nullable(Of Short), ContractQuantity As Nullable(Of Decimal), FlatNetAmount As Nullable(Of Decimal),
                                                FlatGrossAmount As Nullable(Of Decimal), ProductionChargeAmount As Nullable(Of Decimal), ProductionChargeDescription As String, ColorCharge As Nullable(Of Decimal), ColorChargeDescription As String,
                                                PrintColumns As Nullable(Of Decimal), PrintInches As Nullable(Of Decimal), PrintLines As Nullable(Of Decimal), NPCirculation As Nullable(Of Integer), PrintQuantity As Nullable(Of Decimal),
                                                BleedPercentage As Nullable(Of Decimal), BleedAmount As Nullable(Of Decimal), PositionPercentage As Nullable(Of Decimal), PositionAmount As Nullable(Of Decimal), PremiumPercentage As Nullable(Of Decimal),
                                                PremiumAmount As Nullable(Of Decimal), FlatNetCharge As Nullable(Of Decimal), FlatAdditionalCharge As Nullable(Of Decimal), FlatDiscountAmount As Nullable(Of Decimal), ProductionSize As String,
                                                SizeCode As String, MGCirculation As Nullable(Of Integer), OutdoorInternetTypeCode As String, URLLocation As String, CopyArea As String, RateCard As String,
                                                RateType As String, RateTypeDescription As String, ProjectedImpressions As Nullable(Of Integer), GuaranteedImpressions As Nullable(Of Integer), ActualImpressions As Nullable(Of Integer),
                                                TargetAudience As String, CreativeSize As String, Placement1 As String, Placement2 As String, PRCStatus As Nullable(Of Short), AdServerPlacementID As Nullable(Of Long),
                                                AdServerCreatedByUserCode As String, AdServerCreatedByDate As Nullable(Of Date), AdServerLastModifiedUserCode As String, AdServerLastModifiedDate As Nullable(Of Date),
                                                AdServerPlacementManual As Nullable(Of Boolean), PackageParent As Boolean, AdServerPlacementGroupID As Nullable(Of Long), CableNetworkStationCode As String,
                                                DaypartID As Nullable(Of Integer), AddedValue As Nullable(Of Boolean), Bookend As Nullable(Of Boolean), LinkLineNumber As Nullable(Of Integer), IsQuote As String, OverrideNonResaleAmount As Nullable(Of Decimal),
                                                OverrideRates As Nullable(Of Boolean), AdServerID As Nullable(Of Short), LineMarketCode As String, StrataNetCalc As Nullable(Of Boolean)) As MediaOrderInternalResponse

        'objects
        Dim MediaOrderInternalResponse As MediaOrderInternalResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim SqlParameteruser_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteraction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterorder_type_chg As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_amt_override As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_pct_override As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermarkup_pct_override As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercomm_pct_override As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterret_val As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterret_val_s As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterorder_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrev_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterseq_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteractive_rev As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterlink_detid As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstart_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterend_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterclose_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermatl_close_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterext_close_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterext_matl_date As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterbuy_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermonth_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteryear_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate3 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate4 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate5 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate6 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate7 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermonday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertuesday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterwednesday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterthursday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterfriday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersaturday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersunday As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots3 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots4 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots5 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots6 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterspots7 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertotal_spots As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterjob_number As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterjob_component_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterquantity As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternet_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametergross_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterext_net_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterext_gross_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercomm_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiscount_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiscount_desc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstate_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercounty_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercity_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternon_resale_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternetcharge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterncdesc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteraddl_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteraddl_charge_desc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_total As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdate_to_bill As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameternon_bill_flag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_date As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermodified_comments As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbill_type_flag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercomm_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermarkup_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrebate_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdiscount_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertax_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertax_city_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertax_county_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertax_state_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertax_resale As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplyc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplyln As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplynd As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplync As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplyr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertaxapplyai As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterreconcile_flag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbilling_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterest_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterest_line_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterest_rev_nbr As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_number As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermat_comp As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterunits As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametercost_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercost_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternet_base_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametergross_base_rate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprogramming As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterstart_time As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterend_time As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterlength As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterremarks As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametertag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternetwork_id As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterheadline As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametersize As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteredition_issue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermaterial As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersection As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_card_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_dtl_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercontract_qty As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterflat_net As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterflat_gross As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprod_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprod_desc As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercolor_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercolor_desc As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterprint_columns As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_inches As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_lines As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameternp_circulation As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprint_quantity As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterbleed_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbleed_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterposition_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterposition_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterpremium_pct As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterpremium_amt As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterflat_netcharge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterflat_addl_charge As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterflat_discount_amt As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterproduction_size As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametersize_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametermg_circulation As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametero_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterurl_location As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercopy_area As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_card As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_type As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterrate_desc As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterproj_impressions As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterguaranteed_impress As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteract_impressions As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametertarget_audience As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParametercreative_size As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterplacement_1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterplacement_2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterprc_status As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_placement_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_created_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_created_datetime As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_last_modified_by As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_last_modified_datetime As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_placement_manual As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterpackage_parent As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterad_server_placement_group_id As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParametercable_network_station_code As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterdaypart_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteradded_value As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterbookend As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterlink_line_number As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameteris_quote As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteroverride_non_resale_amt As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameteroverride_rates As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterad_server_id As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterline_market_code As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterstrata_net_calc As System.Data.SqlClient.SqlParameter = Nothing

        MediaOrderInternalResponse = New MediaOrderInternalResponse

        Try

            SqlParameteruser_id = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar) With {.Value = UserCode}
            SqlParameteraction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar) With {.Value = Action}
            SqlParameterorder_type = New System.Data.SqlClient.SqlParameter("@order_type", SqlDbType.VarChar) With {.Value = OrderType}
            SqlParameterorder_type_chg = New System.Data.SqlClient.SqlParameter("@order_type_chg", SqlDbType.SmallInt) With {.Value = 0}
            SqlParameterrebate_amt_override = New System.Data.SqlClient.SqlParameter("@rebate_amt_override", SqlDbType.SmallInt) With {.Value = RebateAmountOverride}
            SqlParameterrebate_pct_override = New System.Data.SqlClient.SqlParameter("@rebate_pct_override", SqlDbType.SmallInt) With {.Value = RebatePercentageOverride}
            SqlParametermarkup_pct_override = New System.Data.SqlClient.SqlParameter("@markup_pct_override", SqlDbType.SmallInt) With {.Value = MarkupPercentageOverride}
            SqlParametercomm_pct_override = New System.Data.SqlClient.SqlParameter("@comm_pct_override", SqlDbType.SmallInt) With {.Value = CommissionPercentageOverride}
            SqlParameterret_val = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int) With {.Value = 0, .Direction = ParameterDirection.Output}
            SqlParameterret_val_s = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, -1) With {.Value = "", .Direction = ParameterDirection.Output}

            SqlParameterorder_nbr = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int) With {.Value = OrderNumber}
            SqlParameterline_nbr = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.SmallInt) With {.Value = If(OrderLineNumber.HasValue = False, DBNull.Value, OrderLineNumber)}
            SqlParameterrev_nbr = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt) With {.Value = If(RevisionNumber.HasValue = False, DBNull.Value, RevisionNumber)}
            SqlParameterseq_nbr = New System.Data.SqlClient.SqlParameter("@seq_nbr", SqlDbType.SmallInt) With {.Value = If(SequenceNumber.HasValue = False, DBNull.Value, SequenceNumber)}
            SqlParameteractive_rev = New System.Data.SqlClient.SqlParameter("@active_rev", SqlDbType.SmallInt) With {.Value = If(ActiveRevision.HasValue = False, DBNull.Value, ActiveRevision)}
            SqlParameterlink_detid = New System.Data.SqlClient.SqlParameter("@link_detid", SqlDbType.Int) With {.Value = If(LinkDetailID.HasValue = False, DBNull.Value, LinkDetailID)}
            SqlParameterstart_date = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime) With {.Value = If(StartDate.HasValue = False, DBNull.Value, StartDate)}
            SqlParameterend_date = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.SmallDateTime) With {.Value = If(EndDate.HasValue = False, DBNull.Value, EndDate)}
            SqlParameterclose_date = New System.Data.SqlClient.SqlParameter("@close_date", SqlDbType.SmallDateTime) With {.Value = If(CloseDate.HasValue = False, DBNull.Value, CloseDate)}
            SqlParametermatl_close_date = New System.Data.SqlClient.SqlParameter("@matl_close_date", SqlDbType.SmallDateTime) With {.Value = If(MaterialCloseDate.HasValue = False, DBNull.Value, MaterialCloseDate)}
            SqlParameterext_close_date = New System.Data.SqlClient.SqlParameter("@ext_close_date", SqlDbType.SmallDateTime) With {.Value = If(ExtCloseDate.HasValue = False, DBNull.Value, ExtCloseDate)}
            SqlParameterext_matl_date = New System.Data.SqlClient.SqlParameter("@ext_matl_date", SqlDbType.SmallDateTime) With {.Value = If(ExtMaterialCloseDate.HasValue = False, DBNull.Value, ExtMaterialCloseDate)}

            SqlParameterbuy_type = New System.Data.SqlClient.SqlParameter("@buy_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(BuyType), DBNull.Value, BuyType)}
            SqlParametermonth_nbr = New System.Data.SqlClient.SqlParameter("@month_nbr", SqlDbType.SmallInt) With {.Value = If(Month.HasValue = False, DBNull.Value, Month)}
            SqlParameteryear_nbr = New System.Data.SqlClient.SqlParameter("@year_nbr", SqlDbType.SmallInt) With {.Value = If(Year.HasValue = False, DBNull.Value, Year)}
            SqlParameterdate1 = New System.Data.SqlClient.SqlParameter("@date1", SqlDbType.SmallDateTime) With {.Value = If(Date1.HasValue = False, DBNull.Value, Date1)}
            SqlParameterdate2 = New System.Data.SqlClient.SqlParameter("@date2", SqlDbType.SmallDateTime) With {.Value = If(Date2.HasValue = False, DBNull.Value, Date2)}
            SqlParameterdate3 = New System.Data.SqlClient.SqlParameter("@date3", SqlDbType.SmallDateTime) With {.Value = If(Date3.HasValue = False, DBNull.Value, Date3)}
            SqlParameterdate4 = New System.Data.SqlClient.SqlParameter("@date4", SqlDbType.SmallDateTime) With {.Value = If(Date4.HasValue = False, DBNull.Value, Date4)}
            SqlParameterdate5 = New System.Data.SqlClient.SqlParameter("@date5", SqlDbType.SmallDateTime) With {.Value = If(Date5.HasValue = False, DBNull.Value, Date5)}
            SqlParameterdate6 = New System.Data.SqlClient.SqlParameter("@date6", SqlDbType.SmallDateTime) With {.Value = If(Date6.HasValue = False, DBNull.Value, Date6)}
            SqlParameterdate7 = New System.Data.SqlClient.SqlParameter("@date7", SqlDbType.SmallDateTime) With {.Value = If(Date7.HasValue = False, DBNull.Value, Date7)}
            SqlParametermonday = New System.Data.SqlClient.SqlParameter("@monday", SqlDbType.SmallInt) With {.Value = If(Monday.HasValue = False, DBNull.Value, Monday)}
            SqlParametertuesday = New System.Data.SqlClient.SqlParameter("@tuesday", SqlDbType.SmallInt) With {.Value = If(Tuesday.HasValue = False, DBNull.Value, Tuesday)}
            SqlParameterwednesday = New System.Data.SqlClient.SqlParameter("@wednesday", SqlDbType.SmallInt) With {.Value = If(Wednesday.HasValue = False, DBNull.Value, Wednesday)}
            SqlParameterthursday = New System.Data.SqlClient.SqlParameter("@thursday", SqlDbType.SmallInt) With {.Value = If(Thursday.HasValue = False, DBNull.Value, Thursday)}
            SqlParameterfriday = New System.Data.SqlClient.SqlParameter("@friday", SqlDbType.SmallInt) With {.Value = If(Friday.HasValue = False, DBNull.Value, Friday)}
            SqlParametersaturday = New System.Data.SqlClient.SqlParameter("@saturday", SqlDbType.SmallInt) With {.Value = If(Saturday.HasValue = False, DBNull.Value, Saturday)}
            SqlParametersunday = New System.Data.SqlClient.SqlParameter("@sunday", SqlDbType.SmallInt) With {.Value = If(Sunday.HasValue = False, DBNull.Value, Sunday)}
            SqlParameterspots1 = New System.Data.SqlClient.SqlParameter("@spots1", SqlDbType.Int) With {.Value = If(Spots1.HasValue = False, DBNull.Value, Spots1)}
            SqlParameterspots2 = New System.Data.SqlClient.SqlParameter("@spots2", SqlDbType.Int) With {.Value = If(Spots2.HasValue = False, DBNull.Value, Spots2)}
            SqlParameterspots3 = New System.Data.SqlClient.SqlParameter("@spots3", SqlDbType.Int) With {.Value = If(Spots3.HasValue = False, DBNull.Value, Spots3)}
            SqlParameterspots4 = New System.Data.SqlClient.SqlParameter("@spots4", SqlDbType.Int) With {.Value = If(Spots4.HasValue = False, DBNull.Value, Spots4)}
            SqlParameterspots5 = New System.Data.SqlClient.SqlParameter("@spots5", SqlDbType.Int) With {.Value = If(Spots5.HasValue = False, DBNull.Value, Spots5)}
            SqlParameterspots6 = New System.Data.SqlClient.SqlParameter("@spots6", SqlDbType.Int) With {.Value = If(Spots6.HasValue = False, DBNull.Value, Spots6)}
            SqlParameterspots7 = New System.Data.SqlClient.SqlParameter("@spots7", SqlDbType.Int) With {.Value = If(Spots7.HasValue = False, DBNull.Value, Spots7)}
            SqlParametertotal_spots = New System.Data.SqlClient.SqlParameter("@total_spots", SqlDbType.Int) With {.Value = If(TotalSpots.HasValue = False, DBNull.Value, TotalSpots)}

            SqlParameterjob_number = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int) With {.Value = If(JobNumber.HasValue = False, DBNull.Value, JobNumber)}
            SqlParameterjob_component_nbr = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt) With {.Value = If(JobComponentNumber.HasValue = False, DBNull.Value, JobComponentNumber)}
            SqlParameterquantity = New System.Data.SqlClient.SqlParameter("@quantity", SqlDbType.Int) With {.Value = If(Quantity.HasValue = False, DBNull.Value, Quantity)}
            SqlParameterrate = New System.Data.SqlClient.SqlParameter("@rate", SqlDbType.Decimal) With {.Value = If(Rate.HasValue = False, DBNull.Value, Rate)}
            SqlParameternet_rate = New System.Data.SqlClient.SqlParameter("@net_rate", SqlDbType.Decimal) With {.Value = If(NetRate.HasValue = False, DBNull.Value, NetRate)}
            SqlParametergross_rate = New System.Data.SqlClient.SqlParameter("@gross_rate", SqlDbType.Decimal) With {.Value = If(GrossRate.HasValue = False, DBNull.Value, GrossRate)}
            SqlParameterext_net_amt = New System.Data.SqlClient.SqlParameter("@ext_net_amt", SqlDbType.Decimal) With {.Value = If(ExtNetAmount.HasValue = False, DBNull.Value, ExtNetAmount)}
            SqlParameterext_gross_amt = New System.Data.SqlClient.SqlParameter("@ext_gross_amt", SqlDbType.Decimal) With {.Value = If(ExtGrossAmount.HasValue = False, DBNull.Value, ExtGrossAmount)}
            SqlParametercomm_amt = New System.Data.SqlClient.SqlParameter("@comm_amt", SqlDbType.Decimal) With {.Value = If(CommissionAmount.HasValue = False, DBNull.Value, CommissionAmount)}
            SqlParameterrebate_amt = New System.Data.SqlClient.SqlParameter("@rebate_amt", SqlDbType.Decimal) With {.Value = If(RebateAmount.HasValue = False, DBNull.Value, RebateAmount)}
            SqlParameterdiscount_amt = New System.Data.SqlClient.SqlParameter("@discount_amt", SqlDbType.Decimal) With {.Value = If(DiscountAmount.HasValue = False, DBNull.Value, DiscountAmount)}
            SqlParameterdiscount_desc = New System.Data.SqlClient.SqlParameter("@discount_desc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(DiscountDescription), DBNull.Value, DiscountDescription)}
            SqlParameterstate_amt = New System.Data.SqlClient.SqlParameter("@state_amt", SqlDbType.Decimal) With {.Value = If(StateAmount.HasValue = False, DBNull.Value, StateAmount)}
            SqlParametercounty_amt = New System.Data.SqlClient.SqlParameter("@county_amt", SqlDbType.Decimal) With {.Value = If(CountyAmount.HasValue = False, DBNull.Value, CountyAmount)}
            SqlParametercity_amt = New System.Data.SqlClient.SqlParameter("@city_amt", SqlDbType.Decimal) With {.Value = If(CityAmount.HasValue = False, DBNull.Value, CityAmount)}
            SqlParameternon_resale_amt = New System.Data.SqlClient.SqlParameter("@non_resale_amt", SqlDbType.Decimal) With {.Value = If(NonResaleAmount.HasValue = False, DBNull.Value, NonResaleAmount)}
            SqlParameternetcharge = New System.Data.SqlClient.SqlParameter("@netcharge", SqlDbType.Decimal) With {.Value = If(NetCharge.HasValue = False, DBNull.Value, NetCharge)}
            SqlParameterncdesc = New System.Data.SqlClient.SqlParameter("@ncdesc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(NetChargeDescription), DBNull.Value, NetChargeDescription)}
            SqlParameteraddl_charge = New System.Data.SqlClient.SqlParameter("@addl_charge", SqlDbType.Decimal) With {.Value = If(AdditionalCharge.HasValue = False, DBNull.Value, AdditionalCharge)}
            SqlParameteraddl_charge_desc = New System.Data.SqlClient.SqlParameter("@addl_charge_desc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(AdditionalChargeDescription), DBNull.Value, AdditionalChargeDescription)}
            SqlParameterline_total = New System.Data.SqlClient.SqlParameter("@line_total", SqlDbType.Decimal) With {.Value = If(LineTotal.HasValue = False, DBNull.Value, LineTotal)}
            SqlParameterdate_to_bill = New System.Data.SqlClient.SqlParameter("@date_to_bill", SqlDbType.SmallDateTime) With {.Value = If(DateToBill.HasValue = False, DBNull.Value, DateToBill)}

            SqlParameternon_bill_flag = New System.Data.SqlClient.SqlParameter("@non_bill_flag", SqlDbType.SmallInt) With {.Value = If(NonBillFlag.HasValue = False, DBNull.Value, NonBillFlag)}
            SqlParametermodified_by = New System.Data.SqlClient.SqlParameter("@modified_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ModifiedByUserCode), DBNull.Value, ModifiedByUserCode)}
            SqlParametermodified_date = New System.Data.SqlClient.SqlParameter("@modified_date", SqlDbType.SmallDateTime) With {.Value = If(ModifiedDate.HasValue = False, DBNull.Value, ModifiedDate)}
            SqlParametermodified_comments = New System.Data.SqlClient.SqlParameter("@modified_comments", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ModifiedComments), DBNull.Value, ModifiedComments)}
            SqlParameterbill_type_flag = New System.Data.SqlClient.SqlParameter("@bill_type_flag", SqlDbType.SmallInt) With {.Value = If(BillTypeFlag.HasValue = False, DBNull.Value, BillTypeFlag)}
            SqlParametercomm_pct = New System.Data.SqlClient.SqlParameter("@comm_pct", SqlDbType.Decimal) With {.Value = If(CommissionPercentage.HasValue = False, DBNull.Value, CommissionPercentage)}
            SqlParametermarkup_pct = New System.Data.SqlClient.SqlParameter("@markup_pct", SqlDbType.Decimal) With {.Value = If(MarkupPercentage.HasValue = False, DBNull.Value, MarkupPercentage)}
            SqlParameterrebate_pct = New System.Data.SqlClient.SqlParameter("@rebate_pct", SqlDbType.Decimal) With {.Value = If(RebatePercentage.HasValue = False, DBNull.Value, RebatePercentage)}
            SqlParameterdiscount_pct = New System.Data.SqlClient.SqlParameter("@discount_pct", SqlDbType.Decimal) With {.Value = If(DiscountPercentage.HasValue = False, DBNull.Value, DiscountPercentage)}
            SqlParametertax_code = New System.Data.SqlClient.SqlParameter("@tax_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(TaxCode), DBNull.Value, TaxCode)}
            SqlParametertax_city_pct = New System.Data.SqlClient.SqlParameter("@tax_city_pct", SqlDbType.Decimal) With {.Value = If(TaxCityPercentage.HasValue = False, DBNull.Value, TaxCityPercentage)}
            SqlParametertax_county_pct = New System.Data.SqlClient.SqlParameter("@tax_county_pct", SqlDbType.Decimal) With {.Value = If(TaxCountryPercentage.HasValue = False, DBNull.Value, TaxCountryPercentage)}
            SqlParametertax_state_pct = New System.Data.SqlClient.SqlParameter("@tax_state_pct", SqlDbType.Decimal) With {.Value = If(TaxStatePercentage.HasValue = False, DBNull.Value, TaxStatePercentage)}
            SqlParametertax_resale = New System.Data.SqlClient.SqlParameter("@tax_resale", SqlDbType.SmallInt) With {.Value = If(TaxResale.HasValue = False, DBNull.Value, TaxResale)}
            SqlParametertaxapplyc = New System.Data.SqlClient.SqlParameter("@taxapplyc", SqlDbType.SmallInt) With {.Value = If(TaxApplyC.HasValue = False, DBNull.Value, TaxApplyC)}
            SqlParametertaxapplyln = New System.Data.SqlClient.SqlParameter("@taxapplyln", SqlDbType.SmallInt) With {.Value = If(TaxApplyLN.HasValue = False, DBNull.Value, TaxApplyLN)}
            SqlParametertaxapplynd = New System.Data.SqlClient.SqlParameter("@taxapplynd", SqlDbType.SmallInt) With {.Value = If(TaxApplyND.HasValue = False, DBNull.Value, TaxApplyND)}
            SqlParametertaxapplync = New System.Data.SqlClient.SqlParameter("@taxapplync", SqlDbType.SmallInt) With {.Value = If(TaxApplyNC.HasValue = False, DBNull.Value, TaxApplyNC)}
            SqlParametertaxapplyr = New System.Data.SqlClient.SqlParameter("@taxapplyr", SqlDbType.SmallInt) With {.Value = If(TaxApplyR.HasValue = False, DBNull.Value, TaxApplyR)}
            SqlParametertaxapplyai = New System.Data.SqlClient.SqlParameter("@taxapplyai", SqlDbType.SmallInt) With {.Value = If(TaxApplyAI.HasValue = False, DBNull.Value, TaxApplyAI)}
            SqlParameterreconcile_flag = New System.Data.SqlClient.SqlParameter("@reconcile_flag", SqlDbType.SmallInt) With {.Value = If(ReconcileFlag.HasValue = False, DBNull.Value, ReconcileFlag)}
            SqlParameterbilling_amt = New System.Data.SqlClient.SqlParameter("@billing_amt", SqlDbType.Decimal) With {.Value = If(BillingAmount.HasValue = False, DBNull.Value, BillingAmount)}
            SqlParameterest_nbr = New System.Data.SqlClient.SqlParameter("@est_nbr", SqlDbType.Int) With {.Value = If(EstimateNumber.HasValue = False, DBNull.Value, EstimateNumber)}
            SqlParameterest_line_nbr = New System.Data.SqlClient.SqlParameter("@est_line_nbr", SqlDbType.SmallInt) With {.Value = If(EstimateLineNumber.HasValue = False, DBNull.Value, EstimateLineNumber)}
            SqlParameterest_rev_nbr = New System.Data.SqlClient.SqlParameter("@est_rev_nbr", SqlDbType.SmallInt) With {.Value = If(EstimateRevisionNumber.HasValue = False, DBNull.Value, EstimateRevisionNumber)}
            SqlParameterad_number = New System.Data.SqlClient.SqlParameter("@ad_number", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(AdNumber), DBNull.Value, AdNumber)}
            SqlParametermat_comp = New System.Data.SqlClient.SqlParameter("@mat_comp", SqlDbType.SmallDateTime) With {.Value = If(MaterialCompletion.HasValue = False, DBNull.Value, MaterialCompletion)}
            SqlParameterunits = New System.Data.SqlClient.SqlParameter("@units", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Units), DBNull.Value, Units)}

            SqlParametercost_type = New System.Data.SqlClient.SqlParameter("@cost_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CostType), DBNull.Value, CostType)}
            SqlParametercost_rate = New System.Data.SqlClient.SqlParameter("@cost_rate", SqlDbType.Decimal) With {.Value = If(CostRate.HasValue = False, DBNull.Value, CostRate)}
            SqlParameternet_base_rate = New System.Data.SqlClient.SqlParameter("@net_base_rate", SqlDbType.Decimal) With {.Value = If(NetBaseRate.HasValue = False, DBNull.Value, NetBaseRate)}
            SqlParametergross_base_rate = New System.Data.SqlClient.SqlParameter("@gross_base_rate", SqlDbType.Decimal) With {.Value = If(GrossBaseRate.HasValue = False, DBNull.Value, GrossBaseRate)}
            SqlParameterprogramming = New System.Data.SqlClient.SqlParameter("@programming", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Programming), DBNull.Value, Programming)}
            SqlParameterstart_time = New System.Data.SqlClient.SqlParameter("@start_time", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(StartTime), DBNull.Value, StartTime)}
            SqlParameterend_time = New System.Data.SqlClient.SqlParameter("@end_time", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(EndTime), DBNull.Value, EndTime)}
            SqlParameterlength = New System.Data.SqlClient.SqlParameter("@length", SqlDbType.SmallInt) With {.Value = If(Length.HasValue = False, DBNull.Value, Length)}
            SqlParameterremarks = New System.Data.SqlClient.SqlParameter("@remarks", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Remarks), DBNull.Value, Remarks)}
            SqlParametertag = New System.Data.SqlClient.SqlParameter("@tag", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Tag), DBNull.Value, Tag)}
            SqlParameternetwork_id = New System.Data.SqlClient.SqlParameter("@network_id", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(NetworkID), DBNull.Value, NetworkID)}

            SqlParameterheadline = New System.Data.SqlClient.SqlParameter("@headline", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Headline), DBNull.Value, Headline)}

            SqlParametersize = New System.Data.SqlClient.SqlParameter("@size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Size), DBNull.Value, Size)}
            SqlParameteredition_issue = New System.Data.SqlClient.SqlParameter("@edition_issue", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(EditionIssue), DBNull.Value, EditionIssue)}
            SqlParametermaterial = New System.Data.SqlClient.SqlParameter("@material", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Material), DBNull.Value, Material)}
            SqlParametersection = New System.Data.SqlClient.SqlParameter("@section", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Section), DBNull.Value, Section)}
            SqlParameterrate_card_id = New System.Data.SqlClient.SqlParameter("@rate_card_id", SqlDbType.Int) With {.Value = If(RateCardID.HasValue = False, DBNull.Value, RateCardID)}
            SqlParameterrate_dtl_id = New System.Data.SqlClient.SqlParameter("@rate_dtl_id", SqlDbType.SmallInt) With {.Value = If(RateDetailID.HasValue = False, DBNull.Value, RateDetailID)}
            SqlParametercontract_qty = New System.Data.SqlClient.SqlParameter("@contract_qty", SqlDbType.Decimal) With {.Value = If(ContractQuantity.HasValue = False, DBNull.Value, ContractQuantity)}
            SqlParameterflat_net = New System.Data.SqlClient.SqlParameter("@flat_net", SqlDbType.Decimal) With {.Value = If(FlatNetAmount.HasValue = False, DBNull.Value, FlatNetAmount)}
            SqlParameterflat_gross = New System.Data.SqlClient.SqlParameter("@flat_gross", SqlDbType.Decimal) With {.Value = If(FlatGrossAmount.HasValue = False, DBNull.Value, FlatGrossAmount)}
            SqlParameterprod_charge = New System.Data.SqlClient.SqlParameter("@prod_charge", SqlDbType.Decimal) With {.Value = If(ProductionChargeAmount.HasValue = False, DBNull.Value, ProductionChargeAmount)}
            SqlParameterprod_desc = New System.Data.SqlClient.SqlParameter("@prod_desc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ProductionChargeDescription), DBNull.Value, ProductionChargeDescription)}
            SqlParametercolor_charge = New System.Data.SqlClient.SqlParameter("@color_charge", SqlDbType.Decimal) With {.Value = If(ColorCharge.HasValue = False, DBNull.Value, ColorCharge)}
            SqlParametercolor_desc = New System.Data.SqlClient.SqlParameter("@color_desc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ColorChargeDescription), DBNull.Value, ColorChargeDescription)}

            SqlParameterprint_columns = New System.Data.SqlClient.SqlParameter("@print_columns", SqlDbType.Decimal) With {.Value = If(PrintColumns.HasValue = False, DBNull.Value, PrintColumns)}
            SqlParameterprint_inches = New System.Data.SqlClient.SqlParameter("@print_inches", SqlDbType.Decimal) With {.Value = If(PrintInches.HasValue = False, DBNull.Value, PrintInches)}
            SqlParameterprint_lines = New System.Data.SqlClient.SqlParameter("@print_lines", SqlDbType.Decimal) With {.Value = If(PrintLines.HasValue = False, DBNull.Value, PrintLines)}
            SqlParameternp_circulation = New System.Data.SqlClient.SqlParameter("@np_circulation", SqlDbType.Int) With {.Value = If(NPCirculation.HasValue = False, DBNull.Value, NPCirculation)}
            SqlParameterprint_quantity = New System.Data.SqlClient.SqlParameter("@print_quantity", SqlDbType.Decimal) With {.Value = If(PrintQuantity.HasValue = False, DBNull.Value, PrintQuantity)}

            SqlParameterbleed_pct = New System.Data.SqlClient.SqlParameter("@bleed_pct", SqlDbType.Decimal) With {.Value = If(BleedPercentage.HasValue = False, DBNull.Value, BleedPercentage)}
            SqlParameterbleed_amt = New System.Data.SqlClient.SqlParameter("@bleed_amt", SqlDbType.Decimal) With {.Value = If(BleedAmount.HasValue = False, DBNull.Value, BleedAmount)}
            SqlParameterposition_pct = New System.Data.SqlClient.SqlParameter("@position_pct", SqlDbType.Decimal) With {.Value = If(PositionPercentage.HasValue = False, DBNull.Value, PositionPercentage)}
            SqlParameterposition_amt = New System.Data.SqlClient.SqlParameter("@position_amt", SqlDbType.Decimal) With {.Value = If(PositionAmount.HasValue = False, DBNull.Value, PositionAmount)}
            SqlParameterpremium_pct = New System.Data.SqlClient.SqlParameter("@premium_pct", SqlDbType.Decimal) With {.Value = If(PremiumPercentage.HasValue = False, DBNull.Value, PremiumPercentage)}
            SqlParameterpremium_amt = New System.Data.SqlClient.SqlParameter("@premium_amt", SqlDbType.Decimal) With {.Value = If(PremiumAmount.HasValue = False, DBNull.Value, PremiumAmount)}

            SqlParameterflat_netcharge = New System.Data.SqlClient.SqlParameter("@flat_netcharge", SqlDbType.Decimal) With {.Value = If(FlatNetCharge.HasValue = False, DBNull.Value, FlatNetCharge)}
            SqlParameterflat_addl_charge = New System.Data.SqlClient.SqlParameter("@flat_addl_charge", SqlDbType.Decimal) With {.Value = If(FlatAdditionalCharge.HasValue = False, DBNull.Value, FlatAdditionalCharge)}
            SqlParameterflat_discount_amt = New System.Data.SqlClient.SqlParameter("@flat_discount_amt", SqlDbType.Decimal) With {.Value = If(FlatDiscountAmount.HasValue = False, DBNull.Value, FlatDiscountAmount)}

            SqlParameterproduction_size = New System.Data.SqlClient.SqlParameter("@production_size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(ProductionSize), DBNull.Value, ProductionSize)}
            SqlParametersize_code = New System.Data.SqlClient.SqlParameter("@size_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(SizeCode), DBNull.Value, SizeCode)}
            SqlParametermg_circulation = New System.Data.SqlClient.SqlParameter("@mg_circulation", SqlDbType.Int) With {.Value = If(MGCirculation.HasValue = False, DBNull.Value, MGCirculation)}

            SqlParametero_type = New System.Data.SqlClient.SqlParameter("@o_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(OutdoorInternetTypeCode), DBNull.Value, OutdoorInternetTypeCode)}
            SqlParameterurl_location = New System.Data.SqlClient.SqlParameter("@url_location", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(URLLocation), DBNull.Value, URLLocation)}
            SqlParametercopy_area = New System.Data.SqlClient.SqlParameter("@copy_area", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CopyArea), DBNull.Value, CopyArea)}
            SqlParameterrate_card = New System.Data.SqlClient.SqlParameter("@rate_card", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(RateCard), DBNull.Value, RateCard)}
            SqlParameterrate_type = New System.Data.SqlClient.SqlParameter("@rate_type", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(RateType), DBNull.Value, RateType)}
            SqlParameterrate_desc = New System.Data.SqlClient.SqlParameter("@rate_desc", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(RateTypeDescription), DBNull.Value, RateTypeDescription)}

            SqlParameterproj_impressions = New System.Data.SqlClient.SqlParameter("@proj_impressions", SqlDbType.Int) With {.Value = If(ProjectedImpressions.HasValue = False, DBNull.Value, ProjectedImpressions)}
            SqlParameterguaranteed_impress = New System.Data.SqlClient.SqlParameter("@guaranteed_impress", SqlDbType.Int) With {.Value = If(GuaranteedImpressions.HasValue = False, DBNull.Value, GuaranteedImpressions)}
            SqlParameteract_impressions = New System.Data.SqlClient.SqlParameter("@act_impressions", SqlDbType.Int) With {.Value = If(ActualImpressions.HasValue = False, DBNull.Value, ActualImpressions)}

            SqlParametertarget_audience = New System.Data.SqlClient.SqlParameter("@target_audience", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(TargetAudience), DBNull.Value, TargetAudience)}
            SqlParametercreative_size = New System.Data.SqlClient.SqlParameter("@creative_size", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CreativeSize), DBNull.Value, CreativeSize)}
            SqlParameterplacement_1 = New System.Data.SqlClient.SqlParameter("@placement_1", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Placement1), DBNull.Value, Placement1)}
            SqlParameterplacement_2 = New System.Data.SqlClient.SqlParameter("@placement_2", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(Placement2), DBNull.Value, Placement2)}
            SqlParameterprc_status = New System.Data.SqlClient.SqlParameter("@prc_status", SqlDbType.SmallInt) With {.Value = If(PRCStatus.HasValue = False, DBNull.Value, PRCStatus)}
            SqlParameterad_server_placement_id = New System.Data.SqlClient.SqlParameter("@ad_server_placement_id", SqlDbType.BigInt) With {.Value = If(AdServerPlacementID.HasValue = False, DBNull.Value, AdServerPlacementID)}
            SqlParameterad_server_created_by = New System.Data.SqlClient.SqlParameter("@ad_server_created_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(AdServerCreatedByUserCode), DBNull.Value, AdServerCreatedByUserCode)}
            SqlParameterad_server_created_datetime = New System.Data.SqlClient.SqlParameter("@ad_server_created_datetime", SqlDbType.SmallDateTime) With {.Value = If(AdServerCreatedByDate.HasValue = False, DBNull.Value, AdServerCreatedByDate)}
            SqlParameterad_server_last_modified_by = New System.Data.SqlClient.SqlParameter("@ad_server_last_modified_by", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(AdServerLastModifiedUserCode), DBNull.Value, AdServerLastModifiedUserCode)}
            SqlParameterad_server_last_modified_datetime = New System.Data.SqlClient.SqlParameter("@ad_server_last_modified_datetime", SqlDbType.SmallDateTime) With {.Value = If(AdServerLastModifiedDate.HasValue = False, DBNull.Value, AdServerLastModifiedDate)}
            SqlParameterad_server_placement_manual = New System.Data.SqlClient.SqlParameter("@ad_server_placement_manual", SqlDbType.Bit) With {.Value = If(AdServerPlacementManual.HasValue = False, DBNull.Value, AdServerPlacementManual)}
            SqlParameterpackage_parent = New System.Data.SqlClient.SqlParameter("@package_parent", SqlDbType.Bit) With {.Value = PackageParent}
            SqlParameterad_server_placement_group_id = New System.Data.SqlClient.SqlParameter("@ad_server_placement_group_id", SqlDbType.BigInt) With {.Value = If(AdServerPlacementGroupID.HasValue = False, DBNull.Value, AdServerPlacementGroupID)}

            SqlParametercable_network_station_code = New System.Data.SqlClient.SqlParameter("@cable_network_station_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(CableNetworkStationCode), DBNull.Value, CableNetworkStationCode)}
            SqlParameterdaypart_id = New System.Data.SqlClient.SqlParameter("@daypart_id", SqlDbType.Int) With {.Value = If(DaypartID.HasValue = False, DBNull.Value, DaypartID)}
            SqlParameteradded_value = New System.Data.SqlClient.SqlParameter("@added_value", SqlDbType.Bit) With {.Value = If(AddedValue.HasValue = False, 0, AddedValue)}
            SqlParameterbookend = New System.Data.SqlClient.SqlParameter("@bookend", SqlDbType.Bit) With {.Value = If(Bookend.HasValue = False, 0, Bookend)}

            SqlParameterlink_line_number = New System.Data.SqlClient.SqlParameter("@link_line_number", SqlDbType.Int) With {.Value = If(LinkLineNumber.HasValue = False, DBNull.Value, LinkLineNumber)}

            SqlParameteris_quote = New System.Data.SqlClient.SqlParameter("@is_quote", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(IsQuote), DBNull.Value, IsQuote)}
            SqlParameteroverride_non_resale_amt = New System.Data.SqlClient.SqlParameter("@override_non_resale_amt", SqlDbType.Decimal) With {.Value = If(OverrideNonResaleAmount.HasValue = False, DBNull.Value, OverrideNonResaleAmount)}
            SqlParameteroverride_rates = New System.Data.SqlClient.SqlParameter("@override_rates", SqlDbType.Bit) With {.Value = If(OverrideRates.HasValue = False, 0, OverrideRates)}

            SqlParameterad_server_id = New System.Data.SqlClient.SqlParameter("@ad_server_id", SqlDbType.SmallInt) With {.Value = If(AdServerID.HasValue = False, DBNull.Value, AdServerID)}
            SqlParameterline_market_code = New System.Data.SqlClient.SqlParameter("@line_market_code", SqlDbType.VarChar) With {.Value = If(String.IsNullOrWhiteSpace(LineMarketCode), DBNull.Value, LineMarketCode)}

            SqlParameterstrata_net_calc = New System.Data.SqlClient.SqlParameter("@strata_net_calc", SqlDbType.Bit) With {.Value = If(StrataNetCalc.HasValue = False, 0, StrataNetCalc)}

            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                 "EXEC advsp_revise_order_detail 
                                                  @user_id,@action,@order_type,@order_type_chg,@rebate_amt_override,
                                                  @rebate_pct_override,@markup_pct_override,@comm_pct_override,
                                                  @ret_val OUTPUT,@ret_val_s OUTPUT,@order_nbr,@line_nbr,@rev_nbr,@seq_nbr,@active_rev,
                                                  @link_detid,@start_date,@end_date,@close_date,@matl_close_date,@ext_close_date,
                                                  @ext_matl_date,@buy_type,@month_nbr,@year_nbr,@date1,@date2,@date3,@date4,
                                                  @date5,@date6,@date7,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,
                                                  @sunday,@spots1,@spots2,@spots3,@spots4,@spots5,@spots6,@spots7,@total_spots,
                                                  @job_number,@job_component_nbr,@quantity,@rate,@net_rate,@gross_rate,@ext_net_amt,
                                                  @ext_gross_amt,@comm_amt,@rebate_amt,@discount_amt,@discount_desc,@state_amt,
                                                  @county_amt,@city_amt,@non_resale_amt,@netcharge,@ncdesc,@addl_charge,@addl_charge_desc,
                                                  @line_total,@date_to_bill,@non_bill_flag,@modified_by,@modified_date,@modified_comments,
                                                  @bill_type_flag,@comm_pct,@markup_pct,@rebate_pct,@discount_pct,@tax_code,@tax_city_pct,
                                                  @tax_county_pct,@tax_state_pct,@tax_resale,@taxapplyc,@taxapplyln,@taxapplynd,@taxapplync,
                                                  @taxapplyr,@taxapplyai,@reconcile_flag,@billing_amt,@est_nbr,@est_line_nbr,@est_rev_nbr,
                                                  @ad_number,@mat_comp,@units,@cost_type,@cost_rate,@net_base_rate,@gross_base_rate,
                                                  @programming,@start_time,@end_time,@length,@remarks,@tag,@network_id,@headline,@size,
                                                  @edition_issue,@material,@section,@rate_card_id,@rate_dtl_id,@contract_qty,@flat_net,
                                                  @flat_gross,@prod_charge,@prod_desc,@color_charge,@color_desc,@print_columns,@print_inches,
                                                  @print_lines,@np_circulation,@print_quantity,@bleed_pct,@bleed_amt,@position_pct,
                                                  @position_amt,@premium_pct,@premium_amt,@flat_netcharge,@flat_addl_charge,
                                                  @flat_discount_amt,@production_size,@size_code,@mg_circulation,@o_type,@url_location,
                                                  @copy_area,@rate_card,@rate_type,@rate_desc,@proj_impressions,@guaranteed_impress,
                                                  @act_impressions,@target_audience,@creative_size,@placement_1,@placement_2,@prc_status,
                                                  @ad_server_placement_id,@ad_server_created_by,@ad_server_created_datetime,
                                                  @ad_server_last_modified_by,@ad_server_last_modified_datetime,@ad_server_placement_manual,
                                                  @package_parent,@ad_server_placement_group_id,@cable_network_station_code,@daypart_id,
                                                  @added_value,@bookend,@link_line_number,@is_quote,@override_non_resale_amt,
                                                  @override_rates,@ad_server_id,@line_market_code,@strata_net_calc",
                                                 SqlParameteruser_id, SqlParameteraction, SqlParameterorder_type, SqlParameterorder_type_chg,
                                                 SqlParameterrebate_amt_override, SqlParameterrebate_pct_override, SqlParametermarkup_pct_override,
                                                 SqlParametercomm_pct_override, SqlParameterret_val, SqlParameterret_val_s, SqlParameterorder_nbr,
                                                 SqlParameterline_nbr, SqlParameterrev_nbr, SqlParameterseq_nbr, SqlParameteractive_rev,
                                                 SqlParameterlink_detid, SqlParameterstart_date, SqlParameterend_date, SqlParameterclose_date,
                                                 SqlParametermatl_close_date, SqlParameterext_close_date, SqlParameterext_matl_date, SqlParameterbuy_type,
                                                 SqlParametermonth_nbr, SqlParameteryear_nbr, SqlParameterdate1, SqlParameterdate2, SqlParameterdate3,
                                                 SqlParameterdate4, SqlParameterdate5, SqlParameterdate6, SqlParameterdate7, SqlParametermonday,
                                                 SqlParametertuesday, SqlParameterwednesday, SqlParameterthursday, SqlParameterfriday, SqlParametersaturday,
                                                 SqlParametersunday, SqlParameterspots1, SqlParameterspots2, SqlParameterspots3, SqlParameterspots4,
                                                 SqlParameterspots5, SqlParameterspots6, SqlParameterspots7, SqlParametertotal_spots, SqlParameterjob_number,
                                                 SqlParameterjob_component_nbr, SqlParameterquantity, SqlParameterrate, SqlParameternet_rate,
                                                 SqlParametergross_rate, SqlParameterext_net_amt, SqlParameterext_gross_amt, SqlParametercomm_amt,
                                                 SqlParameterrebate_amt, SqlParameterdiscount_amt, SqlParameterdiscount_desc, SqlParameterstate_amt,
                                                 SqlParametercounty_amt, SqlParametercity_amt, SqlParameternon_resale_amt, SqlParameternetcharge,
                                                 SqlParameterncdesc, SqlParameteraddl_charge, SqlParameteraddl_charge_desc, SqlParameterline_total,
                                                 SqlParameterdate_to_bill, SqlParameternon_bill_flag, SqlParametermodified_by, SqlParametermodified_date,
                                                 SqlParametermodified_comments, SqlParameterbill_type_flag, SqlParametercomm_pct, SqlParametermarkup_pct,
                                                 SqlParameterrebate_pct, SqlParameterdiscount_pct, SqlParametertax_code, SqlParametertax_city_pct,
                                                 SqlParametertax_county_pct, SqlParametertax_state_pct, SqlParametertax_resale, SqlParametertaxapplyc,
                                                 SqlParametertaxapplyln, SqlParametertaxapplynd, SqlParametertaxapplync, SqlParametertaxapplyr,
                                                 SqlParametertaxapplyai, SqlParameterreconcile_flag, SqlParameterbilling_amt, SqlParameterest_nbr,
                                                 SqlParameterest_line_nbr, SqlParameterest_rev_nbr, SqlParameterad_number, SqlParametermat_comp,
                                                 SqlParameterunits, SqlParametercost_type, SqlParametercost_rate, SqlParameternet_base_rate,
                                                 SqlParametergross_base_rate, SqlParameterprogramming, SqlParameterstart_time, SqlParameterend_time,
                                                 SqlParameterlength, SqlParameterremarks, SqlParametertag, SqlParameternetwork_id, SqlParameterheadline,
                                                 SqlParametersize, SqlParameteredition_issue, SqlParametermaterial, SqlParametersection,
                                                 SqlParameterrate_card_id, SqlParameterrate_dtl_id, SqlParametercontract_qty, SqlParameterflat_net,
                                                 SqlParameterflat_gross, SqlParameterprod_charge, SqlParameterprod_desc, SqlParametercolor_charge,
                                                 SqlParametercolor_desc, SqlParameterprint_columns, SqlParameterprint_inches, SqlParameterprint_lines,
                                                 SqlParameternp_circulation, SqlParameterprint_quantity, SqlParameterbleed_pct, SqlParameterbleed_amt,
                                                 SqlParameterposition_pct, SqlParameterposition_amt, SqlParameterpremium_pct, SqlParameterpremium_amt,
                                                 SqlParameterflat_netcharge, SqlParameterflat_addl_charge, SqlParameterflat_discount_amt,
                                                 SqlParameterproduction_size, SqlParametersize_code, SqlParametermg_circulation, SqlParametero_type,
                                                 SqlParameterurl_location, SqlParametercopy_area, SqlParameterrate_card, SqlParameterrate_type,
                                                 SqlParameterrate_desc, SqlParameterproj_impressions, SqlParameterguaranteed_impress,
                                                 SqlParameteract_impressions, SqlParametertarget_audience, SqlParametercreative_size,
                                                 SqlParameterplacement_1, SqlParameterplacement_2, SqlParameterprc_status, SqlParameterad_server_placement_id,
                                                 SqlParameterad_server_created_by, SqlParameterad_server_created_datetime,
                                                 SqlParameterad_server_last_modified_by, SqlParameterad_server_last_modified_datetime,
                                                 SqlParameterad_server_placement_manual, SqlParameterpackage_parent, SqlParameterad_server_placement_group_id,
                                                 SqlParametercable_network_station_code, SqlParameterdaypart_id, SqlParameteradded_value, SqlParameterbookend,
                                                 SqlParameterlink_line_number, SqlParameteris_quote, SqlParameteroverride_non_resale_amt,
                                                 SqlParameteroverride_rates, SqlParameterad_server_id, SqlParameterline_market_code, SqlParameterstrata_net_calc)

        Catch ex As Exception

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            If SqlParameterret_val.Value <> 0 Then

                MediaOrderInternalResponse.IsSuccessful = False
                MediaOrderInternalResponse.Message = SqlParameterret_val_s.Value

            Else

                MediaOrderInternalResponse.IsSuccessful = True
                MediaOrderInternalResponse.Message = SqlParameterret_val_s.Value
                MediaOrderInternalResponse.OrderNumber = OrderNumber
                MediaOrderInternalResponse.OrderLineNumber = OrderLineNumber.GetValueOrDefault(0)

                If MediaOrderInternalResponse.Message = "N" Then

                    MediaOrderInternalResponse.Message = String.Empty

                End If

            End If

        Else

            MediaOrderInternalResponse.IsSuccessful = False
            MediaOrderInternalResponse.Message = ErrorMessage

        End If

        UpdateReviseMediaOrderLine = MediaOrderInternalResponse

    End Function

    Private Function ConvertString(StringValue As String, OriginalValue As String, PropertyName As String, ByRef ErrorMessage As String) As String

        'objects
        Dim ConvertedString As String = String.Empty

        If StringValue = "*" Then

            ConvertedString = OriginalValue

        ElseIf StringValue = "" Then

            ConvertedString = String.Empty

        Else

            ConvertedString = StringValue

        End If

        ConvertString = ConvertedString

    End Function
    Private Function ConvertDate(DateString As String, OriginalValue As Nullable(Of Date), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Date)

        'objects
        Dim ConvertedDate As Nullable(Of Date) = Nothing
        Dim ConvertedDateString As String = String.Empty

        If DateString = "*" Then

            ConvertedDate = OriginalValue

        ElseIf DateString = "" Then

            ConvertedDate = Nothing

        Else

            ConvertedDateString = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(DateString)

            If String.IsNullOrWhiteSpace(ConvertedDateString) Then

                ConvertedDate = Nothing

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid date."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid date."

                End If

            Else

                ConvertedDate = CDate(ConvertedDateString)

            End If

        End If

        ConvertDate = ConvertedDate

    End Function
    Private Function ConvertDate(DateString As String, OriginalValue As Date, PropertyName As String, ByRef ErrorMessage As String) As Date

        'objects
        Dim ConvertedDate As Date = Date.MinValue
        Dim ConvertedDateString As String = String.Empty

        If DateString = "*" Then

            ConvertedDate = OriginalValue

        ElseIf DateString = "" Then

            ConvertedDate = Date.MinValue

        Else

            ConvertedDateString = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(DateString)

            If String.IsNullOrWhiteSpace(ConvertedDateString) Then

                ConvertedDate = Date.MinValue

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid date."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid date."

                End If

            Else

                ConvertedDate = CDate(ConvertedDateString)

            End If

        End If

        ConvertDate = ConvertedDate

    End Function
    Private Function ConvertInteger(IntegerString As String, OriginalValue As Nullable(Of Integer), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Integer)

        'objects
        Dim ConvertedInteger As Nullable(Of Integer) = Nothing
        Dim ConvertedIntegerString As String = String.Empty

        If IntegerString = "*" Then

            ConvertedInteger = OriginalValue

        ElseIf IntegerString = "" Then

            ConvertedInteger = Nothing

        Else

            Try

                ConvertedInteger = Convert.ToInt32(IntegerString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid integer."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid integer."

                End If

            End Try

        End If

        ConvertInteger = ConvertedInteger

    End Function
    Private Function ConvertInteger(IntegerString As String, OriginalValue As Integer, PropertyName As String, ByRef ErrorMessage As String) As Integer

        'objects
        Dim ConvertedInteger As Integer = 0
        Dim ConvertedIntegerString As String = String.Empty

        If IntegerString = "*" Then

            ConvertedInteger = OriginalValue

        ElseIf IntegerString = "" Then

            ConvertedInteger = 0

        Else

            Try

                ConvertedInteger = Convert.ToInt32(IntegerString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid integer."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid integer."

                End If

            End Try

        End If

        ConvertInteger = ConvertedInteger

    End Function
    Private Function ConvertShort(ShortString As String, OriginalValue As Nullable(Of Short), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Short)

        'objects
        Dim ConvertedShort As Nullable(Of Short) = Nothing
        Dim ConvertedShortString As String = String.Empty

        If ShortString = "*" Then

            ConvertedShort = OriginalValue

        ElseIf ShortString = "" Then

            ConvertedShort = Nothing

        Else

            Try

                ConvertedShort = Convert.ToInt16(ShortString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid short."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid short."

                End If

            End Try

        End If

        ConvertShort = ConvertedShort

    End Function
    Private Function ConvertShort(ShortString As String, OriginalValue As Short, PropertyName As String, ByRef ErrorMessage As String) As Short

        'objects
        Dim ConvertedShort As Short = 0
        Dim ConvertedShortString As String = String.Empty

        If ShortString = "*" Then

            ConvertedShort = OriginalValue

        ElseIf ShortString = "" Then

            ConvertedShort = 0

        Else

            Try

                ConvertedShort = Convert.ToInt16(ShortString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid short."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid short."

                End If

            End Try

        End If

        ConvertShort = ConvertedShort

    End Function
    Private Function ConvertLong(LongString As String, OriginalValue As Nullable(Of Long), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Long)

        'objects
        Dim ConvertedLong As Nullable(Of Long) = Nothing
        Dim ConvertedLongString As String = String.Empty

        If LongString = "*" Then

            ConvertedLong = OriginalValue

        ElseIf LongString = "" Then

            ConvertedLong = Nothing

        Else

            Try

                ConvertedLong = Convert.ToInt64(LongString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid long."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid long."

                End If

            End Try

        End If

        ConvertLong = ConvertedLong

    End Function
    Private Function ConvertLong(LongString As String, OriginalValue As Long, PropertyName As String, ByRef ErrorMessage As String) As Long

        'objects
        Dim ConvertedLong As Long = 0
        Dim ConvertedLongString As String = String.Empty

        If LongString = "*" Then

            ConvertedLong = OriginalValue

        ElseIf LongString = "" Then

            ConvertedLong = 0

        Else

            Try

                ConvertedLong = Convert.ToInt64(LongString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid long."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid long."

                End If

            End Try

        End If

        ConvertLong = ConvertedLong

    End Function
    Private Function ConvertDecimal(DecimalString As String, OriginalValue As Nullable(Of Decimal), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Decimal)

        'objects
        Dim ConvertedDecimal As Nullable(Of Decimal) = Nothing
        Dim ConvertedDecimalString As String = String.Empty

        If DecimalString = "*" Then

            ConvertedDecimal = OriginalValue

        ElseIf DecimalString = "" Then

            ConvertedDecimal = Nothing

        Else

            Try

                ConvertedDecimal = Convert.ToDecimal(DecimalString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid decimal."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid decimal."

                End If

            End Try

        End If

        ConvertDecimal = ConvertedDecimal

    End Function
    Private Function ConvertDecimal(DecimalString As String, OriginalValue As Decimal, PropertyName As String, ByRef ErrorMessage As String) As Decimal

        'objects
        Dim ConvertedDecimal As Decimal = 0
        Dim ConvertedDecimalString As String = String.Empty

        If DecimalString = "*" Then

            ConvertedDecimal = OriginalValue

        ElseIf DecimalString = "" Then

            ConvertedDecimal = 0

        Else

            Try

                ConvertedDecimal = Convert.ToDecimal(DecimalString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid decimal."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid decimal."

                End If

            End Try

        End If

        ConvertDecimal = ConvertedDecimal

    End Function
    Private Function ConvertDouble(DoubleString As String, OriginalValue As Nullable(Of Double), PropertyName As String, ByRef ErrorMessage As String) As Nullable(Of Double)

        'objects
        Dim ConvertedDouble As Nullable(Of Double) = Nothing
        Dim ConvertedDoubleString As String = String.Empty

        If DoubleString = "*" Then

            ConvertedDouble = OriginalValue

        ElseIf DoubleString = "" Then

            ConvertedDouble = Nothing

        Else

            Try

                ConvertedDouble = Convert.ToDouble(DoubleString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid double."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid double."

                End If

            End Try

        End If

        ConvertDouble = ConvertedDouble

    End Function
    Private Function ConvertDouble(DoubleString As String, OriginalValue As Double, PropertyName As String, ByRef ErrorMessage As String) As Double

        'objects
        Dim ConvertedDouble As Double = 0
        Dim ConvertedDoubleString As String = String.Empty

        If DoubleString = "*" Then

            ConvertedDouble = OriginalValue

        ElseIf DoubleString = "" Then

            ConvertedDouble = 0

        Else

            Try

                ConvertedDouble = Convert.ToDouble(DoubleString)

            Catch ex As Exception

                If ErrorMessage = String.Empty Then

                    ErrorMessage = PropertyName & " is invalid double."

                Else

                    ErrorMessage &= System.Environment.NewLine & PropertyName & " is invalid double."

                End If

            End Try

        End If

        ConvertDouble = ConvertedDouble

    End Function

    Public Function AddJobAndComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                       JobClientReference As String, JobNumber As Integer, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String,
                       JobDescription As String, JobComment As String, AccountExecutive As String, JobComponentDescription As String, CampaignId As Integer,
                       DueDate As String, JobTypeCode As String, ClientDiscountCode As String, BillingCoopCode As String, NonBillFlag As Integer,
                       MediaDateToBill As String, JobProcessContrl As Integer, JobComponentComment As String, JobComponentBudget As Decimal,
                       JobTaxFlag As Integer, ClientPO As String) As AddJobAndComponentResponse Implements IAPIService.AddJobAndComponent

        'objects
        Dim AddJobAndComponentResponse As AddJobAndComponentResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobNumberIn As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobClientReference As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSalesClassCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAccountExecutive As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCampaignId As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDueDate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobTypeCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientDiscountCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterBillingCoopCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterNonBillFlag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterMediaDateToBill As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobProcessControl As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentComment As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobComponentBudget As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobTaxFlag As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientPO As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim JobComponentNumber As Integer = 0
        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty
        'Dim JobNumberIn As Integer

        'If JobNumberIn = Nothing Then
        '    JobNumberIn = 0
        'End If

        'JobNumber = JobNumberIn

        AddJobAndComponentResponse = New AddJobAndComponentResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterJobClientReference = New System.Data.SqlClient.SqlParameter("@job_cli_ref", SqlDbType.VarChar)
                    SqlParameterJobClientReference.Value = JobClientReference

                    SqlParameterJobNumberIn = New System.Data.SqlClient.SqlParameter("@job_number_in", SqlDbType.Int)
                    SqlParameterJobNumberIn.Value = JobNumber

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterClientCode.Value = ClientCode

                    SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterDivisionCode.Value = DivisionCode

                    SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterProductCode.Value = ProductCode

                    SqlParameterSalesClassCode = New System.Data.SqlClient.SqlParameter("@sales_class", SqlDbType.VarChar)
                    SqlParameterSalesClassCode.Value = SalesClassCode

                    SqlParameterJobDescription = New System.Data.SqlClient.SqlParameter("@job_desc", SqlDbType.VarChar)
                    SqlParameterJobDescription.Value = JobDescription

                    SqlParameterJobComment = New System.Data.SqlClient.SqlParameter("@job_comment", SqlDbType.VarChar)
                    SqlParameterJobComment.Value = JobComment

                    SqlParameterAccountExecutive = New System.Data.SqlClient.SqlParameter("@acct_exec", SqlDbType.VarChar)
                    SqlParameterAccountExecutive.Value = AccountExecutive

                    SqlParameterJobComponentDescription = New System.Data.SqlClient.SqlParameter("@job_comp_desc", SqlDbType.VarChar)
                    SqlParameterJobComponentDescription.Value = JobComponentDescription

                    SqlParameterCampaignId = New System.Data.SqlClient.SqlParameter("@cmp_id", SqlDbType.Int)
                    SqlParameterCampaignId.Value = CampaignId

                    SqlParameterDueDate = New System.Data.SqlClient.SqlParameter("@due_date", SqlDbType.VarChar)
                    SqlParameterDueDate.Value = DueDate

                    SqlParameterJobTypeCode = New System.Data.SqlClient.SqlParameter("@job_type", SqlDbType.VarChar)
                    SqlParameterJobTypeCode.Value = JobTypeCode

                    SqlParameterClientDiscountCode = New System.Data.SqlClient.SqlParameter("@client_discount_code", SqlDbType.VarChar)
                    SqlParameterClientDiscountCode.Value = ClientDiscountCode

                    SqlParameterBillingCoopCode = New System.Data.SqlClient.SqlParameter("@billing_coop_code", SqlDbType.VarChar)
                    SqlParameterBillingCoopCode.Value = BillingCoopCode

                    SqlParameterNonBillFlag = New System.Data.SqlClient.SqlParameter("@non_bill_flag", SqlDbType.Int)
                    SqlParameterNonBillFlag.Value = NonBillFlag

                    SqlParameterMediaDateToBill = New System.Data.SqlClient.SqlParameter("@media_bill_date", SqlDbType.VarChar)
                    SqlParameterMediaDateToBill.Value = MediaDateToBill

                    SqlParameterJobProcessControl = New System.Data.SqlClient.SqlParameter("@job_process_contrl", SqlDbType.Int)
                    SqlParameterJobProcessControl.Value = JobProcessContrl

                    SqlParameterJobComponentComment = New System.Data.SqlClient.SqlParameter("@job_comp_comment", SqlDbType.VarChar)
                    SqlParameterJobComponentComment.Value = JobComponentComment

                    SqlParameterJobComponentBudget = New System.Data.SqlClient.SqlParameter("@job_comp_budget_am", SqlDbType.Decimal)
                    SqlParameterJobComponentBudget.Value = JobComponentBudget

                    SqlParameterJobTaxFlag = New System.Data.SqlClient.SqlParameter("@job_tax_flag", SqlDbType.Int)
                    If JobTaxFlag = Nothing Then
                        SqlParameterJobTaxFlag.Value = DBNull.Value
                    Else
                        SqlParameterJobTaxFlag.Value = JobTaxFlag
                    End If

                    'This allows them to not send anything for ClientPO
                    If ClientPO = Nothing Then
                        ClientPO = ""
                    End If

                    SqlParameterClientPO = New System.Data.SqlClient.SqlParameter("@client_po", SqlDbType.VarChar)
                    SqlParameterClientPO.Value = ClientPO

                    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                    SqlParameterJobNumber.Direction = ParameterDirection.Output
                    SqlParameterJobNumber.Value = Nothing

                    SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
                    SqlParameterJobComponentNumber.Direction = ParameterDirection.Output
                    SqlParameterJobComponentNumber.Value = Nothing

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                         "EXEC advsp_job_comp_add_api @user_id,@action,@job_cli_ref,@job_number_in,@cl_code,@div_code,@prd_code," &
                                                         "@sales_class,@job_desc,@job_comment,@acct_exec,@job_comp_desc," &
                                                         "@cmp_id,@due_date,@job_type,@client_discount_code,@billing_coop_code,@non_bill_flag,
                                                         @media_bill_date,@job_process_contrl,@job_comp_comment,@job_comp_budget_am, @job_tax_flag, @client_po,
                                                         @job_number OUTPUT,@job_component_nbr OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterUserID, SqlParameterAction, SqlParameterJobClientReference, SqlParameterJobNumberIn, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode,
                                                         SqlParameterSalesClassCode, SqlParameterJobDescription, SqlParameterJobComment, SqlParameterAccountExecutive, SqlParameterJobComponentDescription,
                                                         SqlParameterCampaignId, SqlParameterDueDate, SqlParameterJobTypeCode, SqlParameterClientDiscountCode, SqlParameterBillingCoopCode, SqlParameterNonBillFlag,
                                                         SqlParameterMediaDateToBill, SqlParameterJobProcessControl, SqlParameterJobComponentComment, SqlParameterJobComponentBudget, SqlParameterJobTaxFlag, SqlParameterClientPO,
                                                         SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                AddJobAndComponentResponse.IsSuccessful = False
                AddJobAndComponentResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddJobAndComponentResponse.IsSuccessful = True
                AddJobAndComponentResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddJobAndComponentResponse.JobNumber = SqlParameterJobNumber.Value
                AddJobAndComponentResponse.JobComponentNumber = SqlParameterJobComponentNumber.Value

            End If

        Else

            AddJobAndComponentResponse.IsSuccessful = False
            AddJobAndComponentResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddJobAndComponent = AddJobAndComponentResponse

    End Function
    Public Function UpdateJobAndComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            JobNumber As Integer, JobComponentNumber As Short,
                            JobDescription As String, JobComments As String, JobComponentDescription As String, JobComponentComments As String,
                            JobClientReference As String, JobProcessControl As Integer, JobType As String, NonBillFlag As Integer, MediaDateToBill As String,
                            JobComponentBudget As Decimal, JobTaxFlag As Integer, ClientPO As String, CampaignId As Integer) As AddJobAndComponentResponse Implements IAPIService.UpdateJobAndComponent

        'objects
        Dim AddJobAndComponentResponse As AddJobAndComponentResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComments As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentComments As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobClientReference As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobProcessControl As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobType As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterNonBillFlag As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterMediaDateToBill As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobComponentBudget As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobTaxFlag As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientPO As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCampaignId As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobNumberOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumberOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty
        'Dim JobNumberIn As Integer

        'If JobNumberIn = Nothing Then
        '    JobNumberIn = 0
        'End If

        'JobNumber = JobNumberIn

        AddJobAndComponentResponse = New AddJobAndComponentResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                    SqlParameterJobNumber.Value = JobNumber

                    SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                    SqlParameterJobDescription = New System.Data.SqlClient.SqlParameter("@job_desc", SqlDbType.VarChar)
                    SqlParameterJobDescription.Value = JobDescription

                    SqlParameterJobComments = New System.Data.SqlClient.SqlParameter("@job_comments", SqlDbType.VarChar)
                    SqlParameterJobComments.Value = JobComments

                    SqlParameterJobComponentDescription = New System.Data.SqlClient.SqlParameter("@job_comp_desc", SqlDbType.VarChar)
                    SqlParameterJobComponentDescription.Value = JobComponentDescription

                    SqlParameterJobComponentComments = New System.Data.SqlClient.SqlParameter("@job_comp_comments", SqlDbType.VarChar)
                    SqlParameterJobComponentComments.Value = JobComponentComments

                    SqlParameterJobClientReference = New System.Data.SqlClient.SqlParameter("@job_cli_ref", SqlDbType.VarChar)
                    SqlParameterJobClientReference.Value = JobClientReference

                    SqlParameterJobProcessControl = New System.Data.SqlClient.SqlParameter("@job_process_contrl", SqlDbType.Int)
                    SqlParameterJobProcessControl.Value = JobProcessControl

                    SqlParameterJobType = New System.Data.SqlClient.SqlParameter("@job_type", SqlDbType.VarChar)
                    SqlParameterJobType.Value = JobType

                    SqlParameterNonBillFlag = New System.Data.SqlClient.SqlParameter("@non_bill_flag", SqlDbType.Int)
                    SqlParameterNonBillFlag.Value = NonBillFlag

                    SqlParameterMediaDateToBill = New System.Data.SqlClient.SqlParameter("@media_bill_date", SqlDbType.VarChar)
                    SqlParameterMediaDateToBill.Value = MediaDateToBill

                    SqlParameterJobComponentBudget = New System.Data.SqlClient.SqlParameter("@job_comp_budget_am", SqlDbType.Decimal)
                    SqlParameterJobComponentBudget.Value = JobComponentBudget

                    SqlParameterJobTaxFlag = New System.Data.SqlClient.SqlParameter("@job_tax_flag", SqlDbType.Int)
                    If JobTaxFlag = Nothing Then
                        SqlParameterJobTaxFlag.Value = DBNull.Value
                    Else
                        SqlParameterJobTaxFlag.Value = JobTaxFlag
                    End If

                    SqlParameterClientPO = New System.Data.SqlClient.SqlParameter("@client_po", SqlDbType.VarChar)
                    SqlParameterClientPO.Value = ClientPO

                    SqlParameterCampaignId = New System.Data.SqlClient.SqlParameter("@cmp_id", SqlDbType.Int)
                    SqlParameterCampaignId.Value = CampaignId

                    SqlParameterJobNumberOut = New System.Data.SqlClient.SqlParameter("@job_number_out", SqlDbType.Int)
                    SqlParameterJobNumberOut.Direction = ParameterDirection.Output
                    SqlParameterJobNumberOut.Value = Nothing

                    SqlParameterJobComponentNumberOut = New System.Data.SqlClient.SqlParameter("@job_component_nbr_out", SqlDbType.SmallInt)
                    SqlParameterJobComponentNumberOut.Direction = ParameterDirection.Output
                    SqlParameterJobComponentNumberOut.Value = Nothing

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction,
                                                         "EXEC advsp_job_comp_update_api @user_id,@action,@job_number,@job_component_nbr," &
                                                         "@job_desc,@job_comments,@job_comp_desc,@job_comp_comments," &
                                                         "@job_cli_ref,@job_process_contrl,@job_type,@non_bill_flag,@media_bill_date," &
                                                         "@job_comp_budget_am, @job_tax_flag, @client_po, @cmp_id," &
                                                         "@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterUserID, SqlParameterAction, SqlParameterJobNumber, SqlParameterJobComponentNumber,
                                                         SqlParameterJobDescription, SqlParameterJobComments, SqlParameterJobComponentDescription, SqlParameterJobComponentComments,
                                                         SqlParameterJobClientReference, SqlParameterJobProcessControl, SqlParameterJobType, SqlParameterNonBillFlag, SqlParameterMediaDateToBill,
                                                         SqlParameterJobComponentBudget, SqlParameterJobTaxFlag, SqlParameterClientPO, SqlParameterCampaignId,
                                                         SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                AddJobAndComponentResponse.IsSuccessful = False
                AddJobAndComponentResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddJobAndComponentResponse.IsSuccessful = True
                AddJobAndComponentResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddJobAndComponentResponse.JobNumber = SqlParameterJobNumber.Value
                AddJobAndComponentResponse.JobComponentNumber = SqlParameterJobComponentNumber.Value

            End If

        Else

            AddJobAndComponentResponse.IsSuccessful = False
            AddJobAndComponentResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        UpdateJobAndComponent = AddJobAndComponentResponse

    End Function
    Public Function AddOrUpdateEstimate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                        JobNumber As Integer, JobComponentNumber As Short, CreateRevision As Short, AutoApprove As Short, ClientDiscountCode As String,
                                        CampaignID As String, SalesClass As String,
                                        EstimateRevisionDetails() As EstimateRevisionDetail) As AddOrUpdateEstimateResponse Implements IAPIService.AddOrUpdateEstimate

        'objects
        Dim AddOrUpdateEstimateResponse As AddOrUpdateEstimateResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEstimateRevisionDetails As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCreateRevision As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAutoApprove As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientDiscountCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEstimateNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEstimateComponetNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEstimateQuoteNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEstimateRevisionNumber As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterCampaignCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSalesClass As System.Data.SqlClient.SqlParameter = Nothing

        Dim EstimateNumber As Integer = 0
        Dim EstimateComponentNumber As Integer = 0
        Dim EstimateQuoteNumber As Integer = 0
        Dim EstimateRevisionNumber As Integer = 0
        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        AddOrUpdateEstimateResponse = New AddOrUpdateEstimateResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                    SqlParameterJobNumber.Value = JobNumber

                    SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                    SqlParameterEstimateRevisionDetails = New System.Data.SqlClient.SqlParameter("@FunctionTable", SqlDbType.Structured)
                    SqlParameterEstimateRevisionDetails.TypeName = "ESTIMATE_REV_DET_API_TYPE"
                    SqlParameterEstimateRevisionDetails.Value = AdvantageFramework.Database.ToDataTable(EstimateRevisionDetails)

                    SqlParameterCreateRevision = New System.Data.SqlClient.SqlParameter("@create_revision", SqlDbType.Bit)
                    SqlParameterCreateRevision.Value = CreateRevision

                    SqlParameterAutoApprove = New System.Data.SqlClient.SqlParameter("@auto_approve", SqlDbType.SmallInt)
                    SqlParameterAutoApprove.Value = AutoApprove

                    SqlParameterClientDiscountCode = New System.Data.SqlClient.SqlParameter("@client_discount_code", SqlDbType.VarChar)
                    SqlParameterClientDiscountCode.Value = ClientDiscountCode

                    SqlParameterEstimateNumber = New System.Data.SqlClient.SqlParameter("@est_nbr_new", SqlDbType.Int)
                    SqlParameterEstimateNumber.Direction = ParameterDirection.Output
                    SqlParameterEstimateNumber.Value = EstimateNumber

                    SqlParameterEstimateComponetNumber = New System.Data.SqlClient.SqlParameter("@comp_nbr_new", SqlDbType.Int)
                    SqlParameterEstimateComponetNumber.Direction = ParameterDirection.Output
                    SqlParameterEstimateComponetNumber.Value = EstimateComponentNumber

                    SqlParameterEstimateQuoteNumber = New System.Data.SqlClient.SqlParameter("@quote_nbr_new", SqlDbType.Int)
                    SqlParameterEstimateQuoteNumber.Direction = ParameterDirection.Output
                    SqlParameterEstimateQuoteNumber.Value = EstimateQuoteNumber

                    SqlParameterEstimateRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr_new", SqlDbType.Int)
                    SqlParameterEstimateRevisionNumber.Direction = ParameterDirection.Output
                    SqlParameterEstimateRevisionNumber.Value = EstimateRevisionNumber

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@cmp_indentifier", SqlDbType.VarChar)
                    SqlParameterCampaignID.Value = CampaignID

                    SqlParameterSalesClass = New System.Data.SqlClient.SqlParameter("@sales_class", SqlDbType.VarChar)
                    SqlParameterSalesClass.Value = SalesClass

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_estimate_add_update_api @user_id,@action,@job_number,@job_component_nbr,@FunctionTable,@create_revision,@auto_approve,@client_discount_code,@est_nbr_new OUTPUT,@comp_nbr_new OUTPUT,@quote_nbr_new OUTPUT,@rev_nbr_new OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT,@cmp_indentifier,@sales_class",
                                                         SqlParameterUserID, SqlParameterAction, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterEstimateRevisionDetails, SqlParameterCreateRevision,
                                                         SqlParameterAutoApprove, SqlParameterClientDiscountCode, SqlParameterEstimateNumber, SqlParameterEstimateComponetNumber,
                                                         SqlParameterEstimateQuoteNumber, SqlParameterEstimateRevisionNumber, SqlParameterReturnValue, SqlParameterReturnValueMessage,
                                                         SqlParameterCampaignID, SqlParameterSalesClass)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value < 0 Then   '(-1)

                'AddOrUpdateEstimateResponse.Message &= LTrim(RTrim(" " & ErrorMessage))
                AddOrUpdateEstimateResponse.ID = 0
                AddOrUpdateEstimateResponse.IsSuccessful = False
                AddOrUpdateEstimateResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddOrUpdateEstimateResponse.ID = SqlParameterReturnValue.Value
                AddOrUpdateEstimateResponse.IsSuccessful = True
                AddOrUpdateEstimateResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddOrUpdateEstimateResponse.EstimateNumber = SqlParameterEstimateNumber.Value
                AddOrUpdateEstimateResponse.EstimateComponentNumber = SqlParameterEstimateComponetNumber.Value
                AddOrUpdateEstimateResponse.EstimateQuoteNumber = SqlParameterEstimateQuoteNumber.Value
                AddOrUpdateEstimateResponse.EstimateRevisionNumber = SqlParameterEstimateRevisionNumber.Value

            End If
        Else

            AddOrUpdateEstimateResponse.IsSuccessful = False
            AddOrUpdateEstimateResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If


        AddOrUpdateEstimate = AddOrUpdateEstimateResponse

    End Function
    'Public Function CreateJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
    '						  CreateJobComponents As Boolean, CreateSchedule As Boolean, ClientCode As String, DivisionCode As String, ProductCode As String,
    '						  CopyFromJobNumber As Integer, CopyAllJobComponents As Boolean, CopyFromJobComponentNumber As Short, SalesClassCode As String, CampaignID As Integer,
    '						  JobDescription As String, JobComment As String, BillingComment As String, JobNumber As Integer, JobComponentDescription As String,
    '						  AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String) As CreateJobResponse Implements IAPIService.CreateJob

    '	'objects
    '	Dim CreateJobResponse As CreateJobResponse = Nothing
    '	Dim ErrorMessage As String = ""
    '	Dim APISession As AdvantageFramework.Security.APISession = Nothing
    '	Dim ProcessedSuccessfully As Boolean = False

    '	CreateJobResponse = New CreateJobResponse

    '	Try

    '		If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

    '			Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

    '				If CopyFromJobNumber <> 0 AndAlso CopyAllJobComponents = False AndAlso CopyFromJobComponentNumber = 0 Then

    '					ProcessedSuccessfully = CopyJob(DbContext, CreateJobResponse, CopyFromJobNumber, CreateJobComponents, ClientCode, DivisionCode, ProductCode,
    '													SalesClassCode, CampaignID, JobDescription, JobComment, BillingComment)

    '				ElseIf CopyFromJobNumber <> 0 AndAlso CopyAllJobComponents = True AndAlso CopyFromJobComponentNumber = 0 Then

    '					ProcessedSuccessfully = Me.CopyAllJobComponents(DbContext, CreateJobResponse, CopyFromJobNumber, CreateSchedule, ClientCode, DivisionCode, ProductCode,
    '																	SalesClassCode, CampaignID, JobDescription, JobComment, BillingComment)

    '				ElseIf CopyFromJobNumber <> 0 AndAlso CopyAllJobComponents = False AndAlso CopyFromJobComponentNumber <> 0 Then

    '					ProcessedSuccessfully = CopyJobComponent(DbContext, CreateJobResponse, CopyFromJobNumber, CopyFromJobComponentNumber, CreateSchedule, ClientCode, DivisionCode, ProductCode,
    '															 SalesClassCode, CampaignID, JobDescription, JobComment, BillingComment, JobComponentDescription,
    '															 AccountExecutiveEmployeeCode, JobTypeCode, AlertGroupCode, JobComponentComment)

    '				ElseIf CopyFromJobNumber = 0 Then

    '					If JobNumber <> 0 Then

    '						ProcessedSuccessfully = CreateJobComponent(DbContext, CreateJobResponse, JobNumber, CreateSchedule, ClientCode, DivisionCode, ProductCode,
    '																   JobComponentDescription, AccountExecutiveEmployeeCode, JobTypeCode, AlertGroupCode, JobComponentComment)

    '					Else

    '						ProcessedSuccessfully = CreateNewJobComponent(DbContext, CreateJobResponse, ClientCode, DivisionCode, ProductCode,
    '																	  SalesClassCode, CampaignID, JobDescription, JobComment, BillingComment,
    '																	  JobComponentDescription, AccountExecutiveEmployeeCode, JobTypeCode, AlertGroupCode, JobComponentComment)

    '					End If

    '				End If

    '			End Using

    '		End If

    '	Catch ex As Exception
    '		ErrorMessage &= LTrim(RTrim(" " & ex.Message))
    '	End Try

    '	If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

    '		CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

    '	End If

    '	CreateJob = CreateJobResponse

    'End Function
    Private Function CreateNewJobComponent(DbContext As APIDbContext, ByRef CreateJobResponse As CreateJobResponse, ClientCode As String, DivisionCode As String,
                                           ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                                           JobDescription As String, JobComment As String, BillingComment As String, JobComponentDescription As String,
                                           AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String) As Boolean

        'objects
        Dim IsValid As Boolean = True
        Dim JobComponentCreated As Boolean = False

        IsValid = ValidateCDP(DbContext, CreateJobResponse, ClientCode, DivisionCode, ProductCode)

        If ValidateSalesClass(DbContext, CreateJobResponse, SalesClassCode, True) Then

            IsValid = False

        End If

        If ValidateCampaign(DbContext, CreateJobResponse, CampaignID, ClientCode) Then

            IsValid = False

        End If

        If ValidateJobDescription(DbContext, CreateJobResponse, JobDescription, True) Then

            IsValid = False

        End If

        If ValidateJobComponentDescription(DbContext, CreateJobResponse, JobComponentDescription, True) Then

            IsValid = False

        End If

        If ValidateAccountExecutive(DbContext, CreateJobResponse, ClientCode, DivisionCode, ProductCode, AccountExecutiveEmployeeCode, True) Then

            IsValid = False

        End If

        If ValidateJobType(DbContext, CreateJobResponse, JobTypeCode, True) Then

            IsValid = False

        End If

        If ValidateAlertGroup(DbContext, CreateJobResponse, AlertGroupCode, True) Then

            IsValid = False

        End If

        If IsValid Then


        End If

        CreateNewJobComponent = JobComponentCreated

    End Function
    Public Function CopyJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            JobNumber As Integer, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                            JobDescription As String, JobComment As String, JobComponentDescription As String, AccountExecutive As String,
                            UserDefined1 As String, UserDefined2 As String, OfficeCode As String, SendMail As Boolean, IncludeSchedule As Boolean, Status As String,
                            IncludeTaskEmployees As Boolean, IncludeTaskComment As Boolean, IncludeTaskDueDateComment As Boolean, IncludeTaskStartAndDueDate As Boolean) As CreateJobResponse Implements IAPIService.CopyJob


        'objects
        Dim JobCopied As Boolean = False
        Dim CreateJobResponse As CreateJobResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobNumberIn As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSalesClassCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCampaignId As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentDescription As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterAccountExecutive As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterUserDefined1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined2 As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSendMail As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterIncludeSchedule As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterStatus As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeTaskEmployees As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeTaskComment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeTaskDueDateComment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeTaskStartAndDueDates As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty
        Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
        Dim JobLog As AdvantageFramework.Database.Entities.Job = Nothing
        'Dim AcctExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
        Dim EmailToAddress As String = String.Empty
        Dim EmailMsg As String = String.Empty
        Dim EmailSubject As String = String.Empty
        Dim ErrorMsg As String = String.Empty
        Dim TempString As String = String.Empty
        Dim EmailAttachments As String() = Nothing
        Dim JobComponentNumber As Integer = 0
        Dim JobNumberNew As Integer = 0
        Dim AEEmpCode As String = String.Empty
        Dim CrLf As String = String.Empty
        Dim HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
        'Dim JobNumberIn As Integer

        'If JobNumberIn = Nothing Then
        '    JobNumberIn = 0
        'End If

        'JobNumber = JobNumberIn

        CreateJobResponse = New CreateJobResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterJobNumberIn = New System.Data.SqlClient.SqlParameter("@job_number_in", SqlDbType.Int)
                    SqlParameterJobNumberIn.Value = JobNumber
                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterClientCode.Value = ClientCode
                    SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterDivisionCode.Value = DivisionCode
                    SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterProductCode.Value = ProductCode
                    SqlParameterSalesClassCode = New System.Data.SqlClient.SqlParameter("@sales_class", SqlDbType.VarChar)
                    SqlParameterSalesClassCode.Value = SalesClassCode
                    SqlParameterCampaignId = New System.Data.SqlClient.SqlParameter("@cmp_id", SqlDbType.Int)
                    SqlParameterCampaignId.Value = CampaignID

                    SqlParameterJobDescription = New System.Data.SqlClient.SqlParameter("@job_desc", SqlDbType.VarChar)
                    SqlParameterJobDescription.Value = JobDescription
                    SqlParameterJobComment = New System.Data.SqlClient.SqlParameter("@job_comment", SqlDbType.VarChar)
                    SqlParameterJobComment.Value = JobComment
                    SqlParameterJobComponentDescription = New System.Data.SqlClient.SqlParameter("@job_comp_desc", SqlDbType.VarChar)
                    SqlParameterJobComponentDescription.Value = JobComponentDescription

                    SqlParameterAccountExecutive = New System.Data.SqlClient.SqlParameter("@acct_exec", SqlDbType.VarChar)
                    SqlParameterAccountExecutive.Value = AccountExecutive

                    SqlParameterUserDefined1 = New System.Data.SqlClient.SqlParameter("@user_defined_1", SqlDbType.VarChar)
                    SqlParameterUserDefined1.Value = UserDefined1
                    SqlParameterUserDefined2 = New System.Data.SqlClient.SqlParameter("@user_defined_2", SqlDbType.VarChar)
                    SqlParameterUserDefined2.Value = UserDefined2

                    SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
                    SqlParameterOfficeCode.Value = OfficeCode

                    SqlParameterSendMail = New System.Data.SqlClient.SqlParameter("@send_mail", SqlDbType.Bit)
                    SqlParameterSendMail.Value = IncludeSchedule

                    SqlParameterIncludeSchedule = New System.Data.SqlClient.SqlParameter("@include_schedule", SqlDbType.Bit)
                    SqlParameterIncludeSchedule.Value = IncludeSchedule
                    SqlParameterStatus = New System.Data.SqlClient.SqlParameter("@status", SqlDbType.VarChar)
                    SqlParameterStatus.Value = Status
                    SqlParameterIncludeTaskEmployees = New System.Data.SqlClient.SqlParameter("@include_task_employees", SqlDbType.Bit)
                    SqlParameterIncludeTaskEmployees.Value = IncludeTaskEmployees
                    SqlParameterIncludeTaskComment = New System.Data.SqlClient.SqlParameter("@include_task_comment", SqlDbType.Bit)
                    SqlParameterIncludeTaskComment.Value = IncludeTaskComment
                    SqlParameterIncludeTaskDueDateComment = New System.Data.SqlClient.SqlParameter("@include_task_due_date_comment", SqlDbType.Bit)
                    SqlParameterIncludeTaskDueDateComment.Value = IncludeTaskDueDateComment
                    SqlParameterIncludeTaskStartAndDueDates = New System.Data.SqlClient.SqlParameter("@include_task_start_and_due_dates", SqlDbType.Bit)
                    SqlParameterIncludeTaskStartAndDueDates.Value = IncludeTaskStartAndDueDate

                    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                    SqlParameterJobNumber.Direction = ParameterDirection.Output
                    SqlParameterJobNumber.Value = Nothing

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_job_comp_copy_api @user_id,@action,@job_number_in,@cl_code,@div_code,@prd_code,@sales_class,@cmp_id,@job_desc,@job_comment,@job_comp_desc,@acct_exec,@user_defined_1,@user_defined_2,@office_code,@send_mail,@status,@include_schedule,@include_task_employees,@include_task_comment,@include_task_due_date_comment,@include_task_start_and_due_dates,@job_number OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterUserID, SqlParameterAction, SqlParameterJobNumberIn, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode,
                                                         SqlParameterSalesClassCode, SqlParameterCampaignId, SqlParameterJobDescription, SqlParameterJobComment, SqlParameterJobComponentDescription,
                                                         SqlParameterAccountExecutive, SqlParameterUserDefined1, SqlParameterUserDefined2, SqlParameterOfficeCode, SqlParameterSendMail, SqlParameterStatus,
                                                         SqlParameterIncludeSchedule, SqlParameterIncludeTaskEmployees, SqlParameterIncludeTaskComment, SqlParameterIncludeTaskDueDateComment, SqlParameterIncludeTaskStartAndDueDates,
                                                         SqlParameterJobNumber, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                CreateJobResponse.IsSuccessful = False
                CreateJobResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                CreateJobResponse.IsSuccessful = True
                CreateJobResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                CreateJobResponse.JobNumber = SqlParameterJobNumber.Value

                If SendMail Then

                    CrLf = "<br>"

                    JobNumberNew = SqlParameterJobNumber.Value
                    JobComponentNumber = 1

                    Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                        JobLog = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(AFDbContext, JobNumberNew)
                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(AFDbContext, JobNumberNew, JobComponentNumber)

                        If JobComponent.AccountExecutiveEmployeeCode = Nothing Then
                            'No Email
                        Else
                            AEEmpCode = JobComponent.AccountExecutiveEmployeeCode
                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(AFDbContext, AEEmpCode)
                        End If

                        'End Using

                        HTMLEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                        If AEEmpCode <> Nothing Then

                            EmailSubject = "New Job " & (JobNumberNew) & " Created by User " & UserName

                            HTMLEmail.AddHeaderRow("Job Details")

                            EmailMsg = "Client: " & JobLog.Client.Code & " - " & JobLog.Client.Name
                            HTMLEmail.AddCustomRow(EmailMsg)
                            EmailMsg = "Division: " & JobLog.Division.Code & " - " & JobLog.Division.Name
                            HTMLEmail.AddCustomRow(EmailMsg)
                            EmailMsg = "Product: " & JobLog.ProductCode & " - " & JobLog.Product.Name
                            HTMLEmail.AddCustomRow(EmailMsg)
                            EmailMsg = "Job: " & JobLog.Number & " - " & JobLog.Description
                            HTMLEmail.AddCustomRow(EmailMsg)
                            EmailMsg = "Sales Class: " & JobLog.SalesClassCode & " - " & JobLog.SalesClass.Description
                            HTMLEmail.AddCustomRow(EmailMsg)
                            EmailMsg = "Office: " & JobLog.OfficeCode & " - " & JobLog.Office.Name
                            HTMLEmail.AddCustomRow(EmailMsg)
                            'EmailMsg = "Job Component: " & JobComponent.Number & " - " & JobComponent.Description
                            'HTMLEmail.AddCustomRow(EmailMsg)
                            TempString = Trim(Employee.FirstName & " " & Employee.LastName)
                            EmailMsg = "Account Executive: " & AEEmpCode & " - " & TempString
                            HTMLEmail.AddCustomRow(EmailMsg)

                            HTMLEmail.AddBlankRow()

                            EmailMsg = HTMLEmail.ToString()

                            EmailToAddress = Employee.Email

                            If AdvantageFramework.Email.Send(AFDbContext, EmailToAddress, "", "", EmailSubject,
                                                EmailMsg, 3, EmailAttachments, SendingEmailStatus, ErrorMsg, True) = False Then
                                'Mail Failed


                            End If

                        End If

                    End Using

                End If

            End If

        Else

            CreateJobResponse.IsSuccessful = False
            CreateJobResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        CopyJob = CreateJobResponse

    End Function
    Private Function CreateJobComponent(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobNumber As Integer,
                                        CreateSchedule As Boolean, ClientCode As String, DivisionCode As String, ProductCode As String, JobComponentDescription As String,
                                        AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String) As Boolean

        'objects
        Dim JobComponentCreated As Boolean = False

        CreateJobComponent = JobComponentCreated

    End Function
    Private Function CopyJobComponent(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, CopyFromJobNumber As Integer, CopyFromJobComponentNumber As Short,
                                      CreateSchedule As Boolean, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                                      JobDescription As String, JobComment As String, BillingComment As String, JobComponentDescription As String,
                                      AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String) As Boolean

        'objects
        Dim JobComponentCopied As Boolean = False

        CopyJobComponent = JobComponentCopied

    End Function
    Private Function CopyAllJobComponents(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, CopyFromJobNumber As Integer,
                                          CreateSchedule As Boolean, ClientCode As String, DivisionCode As String, ProductCode As String,
                                          SalesClassCode As String, CampaignID As Integer, JobDescription As String, JobComment As String, BillingComment As String) As Boolean

        'objects
        Dim JobComponentsCopied As Boolean = False

        CopyAllJobComponents = JobComponentsCopied

    End Function

    Public Function CreateJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                              ClientCode As String, DivisionCode As String, ProductCode As String, JobDescription As String, JobComment As String,
                              BillingComment As String, SalesClassCode As String, CampaignID As Integer) As CreateJobResponse Implements IAPIService.CreateJob

        'objects
        Dim CreateJobResponse As CreateJobResponse = Nothing
        Dim ErrorMessage As String = ""
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        CreateJobResponse = New CreateJobResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)



                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

        End If

        CreateJob = CreateJobResponse

    End Function
    'Public Function CopyJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
    '						ClientCode As String, DivisionCode As String, ProductCode As String, CopyFromJobNumber As Integer, CopyAllJobComponents As Boolean,
    '						SalesClassCode As String, CampaignID As Integer, JobDescription As String, JobComment As String, BillingComment As String) As CreateJobResponse Implements IAPIService.CopyJob

    '	'objects
    '	Dim CreateJobResponse As CreateJobResponse = Nothing
    '	Dim ErrorMessage As String = ""
    '	Dim APISession As AdvantageFramework.Security.APISession = Nothing

    '	CreateJobResponse = New CreateJobResponse

    '	Try

    '		If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

    '			Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)



    '			End Using

    '		End If

    '	Catch ex As Exception
    '		ErrorMessage &= LTrim(RTrim(" " & ex.Message))
    '	End Try

    '	If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

    '		CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

    '	End If

    '	CopyJob = CreateJobResponse

    'End Function
    Public Function CreateJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                       ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                                       JobDescription As String, JobComment As String, BillingComment As String, JobNumber As Integer, JobComponentDescription As String,
                                       AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                                       JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse Implements IAPIService.CreateJobComponent

        'objects
        Dim CreateJobResponse As CreateJobResponse = Nothing
        Dim ErrorMessage As String = ""
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        CreateJobResponse = New CreateJobResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)



                End Using

            End If

        Catch ex As Exception

            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

        End If

        CreateJobComponent = CreateJobResponse

    End Function
    Public Function CreateJobComponentFromExistingJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                                      JobNumber As Integer, JobComponentDescription As String, AccountExecutiveEmployeeCode As String, JobTypeCode As String,
                                                      AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                                                      JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse Implements IAPIService.CreateJobComponentFromExistingJob

        'objects
        Dim CreateJobResponse As CreateJobResponse = Nothing
        Dim ErrorMessage As String = ""
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        CreateJobResponse = New CreateJobResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)



                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

        End If

        CreateJobComponentFromExistingJob = CreateJobResponse

    End Function
    Public Function CopyJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     CopyFromJobNumber As Integer, CopyFromJobComponentNumber As Short, JobComponentDescription As String, AccountExecutiveEmployeeCode As String,
                                     JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                                     JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse Implements IAPIService.CopyJobComponent

        'objects
        Dim CreateJobResponse As CreateJobResponse = Nothing
        Dim ErrorMessage As String = ""
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        CreateJobResponse = New CreateJobResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)



                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            CreateJobResponse.Message &= LTrim(RTrim(" " & ErrorMessage))

        End If

        CopyJobComponent = CreateJobResponse

    End Function

    Public Function AddOrUpdateClientType(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                        ClientTypeInd As Integer, ClientTypeDesc As String, InactiveFlag As Boolean) As ClientTypeResponse Implements IAPIService.AddOrUpdateClientType

        'objects
        Dim ClientTypeResponse As ClientTypeResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientTypeInd As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientTypeDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterInactiveFlag As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientTypeId As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ClientTypeID As Integer = 0
        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        ClientTypeResponse = New ClientTypeResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterClientTypeInd = New System.Data.SqlClient.SqlParameter("@client_type_ind", SqlDbType.Int)
                    SqlParameterClientTypeInd.Value = ClientTypeInd

                    SqlParameterClientTypeDescription = New System.Data.SqlClient.SqlParameter("@client_type_desc", SqlDbType.VarChar)
                    SqlParameterClientTypeDescription.Value = ClientTypeDesc

                    SqlParameterInactiveFlag = New System.Data.SqlClient.SqlParameter("@inactive_flag", SqlDbType.Bit)
                    SqlParameterInactiveFlag.Value = InactiveFlag

                    SqlParameterClientTypeId = New System.Data.SqlClient.SqlParameter("@client_type_id", SqlDbType.Int)
                    SqlParameterClientTypeId.Direction = ParameterDirection.Output
                    SqlParameterClientTypeId.Value = ClientTypeID

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_client_type_add_update_api @user_id,@action,@client_type_ind,@client_type_desc,@inactive_flag,@client_type_id OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterUserID, SqlParameterAction, SqlParameterClientTypeInd, SqlParameterClientTypeDescription, SqlParameterInactiveFlag,
                                                         SqlParameterClientTypeId, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ClientTypeResponse.IsSuccessful = False
                ClientTypeResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                ClientTypeResponse.IsSuccessful = True
                ClientTypeResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                ClientTypeResponse.ClientTypeID = SqlParameterClientTypeId.Value
                ClientTypeResponse.InactiveFlag = SqlParameterInactiveFlag.Value
                ClientTypeResponse.ClientTypeDescription = SqlParameterClientTypeDescription.Value

            End If
        Else

            ClientTypeResponse.IsSuccessful = False
            ClientTypeResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrUpdateClientType = ClientTypeResponse

    End Function

    Public Function UpdateProjectScheduleDueDate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                                 JobNumber As Integer, JobComponentNumber As Short, DueDate As Date) As APIReponse Implements IAPIService.UpdateProjectScheduleDueDate

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim APIReponse As APIReponse = Nothing
        Dim Updated As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim IsValid As Boolean = True
        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If IsValid Then

                        If DbContext.JobComponents.Any(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNumber) = False Then

                            ErrorMessage = "Invalid job\component."
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(AFDbContext, JobNumber, JobComponentNumber)

                            If DueDate = Nothing OrElse DueDate = Date.MinValue Then

                                JobComponent.DueDate = Nothing

                            Else

                                JobComponent.DueDate = DueDate

                            End If

                            Updated = AdvantageFramework.Database.Procedures.JobComponent.Update(AFDbContext, JobComponent)

                        End Using

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            Updated = False
            ErrorMessage = "Runtime failure - " & ex.Message
        End Try

        APIReponse = New APIReponse(Updated, ErrorMessage)

        UpdateProjectScheduleDueDate = APIReponse

    End Function
    Public Function UpdateProjectScheduleStatus(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                                JobNumber As Integer, JobComponentNumber As Short, ScheduleStatusCode As String) As APIReponse Implements IAPIService.UpdateProjectScheduleStatus

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim APIReponse As APIReponse = Nothing
        Dim Updated As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim IsValid As Boolean = True
        Dim ScheduleStatus As ScheduleStatus = Nothing
        Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                        If String.IsNullOrWhiteSpace(ScheduleStatusCode) Then

                            ErrorMessage = "Schedule status code is required."
                            IsValid = False

                        End If

                        If IsValid Then

                            If DbContext.JobComponents.Any(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNumber) = False Then

                                ErrorMessage = "Invalid job\component."
                                IsValid = False

                            End If

                        End If

                        If IsValid Then

                            If AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(AFDbContext, JobNumber, JobComponentNumber) Is Nothing Then

                                ErrorMessage = "Job\component schedule does not exist."
                                IsValid = False

                            End If

                        End If

                        If IsValid Then

                            If DbContext.ScheduleStatuses.Any(Function(Entity) Entity.Code.ToUpper = ScheduleStatusCode.ToUpper) = False Then

                                ScheduleStatus = New ScheduleStatus

                                ScheduleStatus.Code = ScheduleStatusCode
                                ScheduleStatus.Description = ScheduleStatusCode
                                ScheduleStatus.IsInactive = Nothing

                                DbContext.ScheduleStatuses.Add(ScheduleStatus)

                                DbContext.SaveChanges()

                            Else

                                ScheduleStatus = DbContext.ScheduleStatuses.SingleOrDefault(Function(Entity) Entity.Code.ToUpper AndAlso ScheduleStatusCode.ToUpper)

                            End If

                            JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(AFDbContext, JobNumber, JobComponentNumber)

                            JobTraffic.TrafficCode = ScheduleStatus.Code

                            Updated = AdvantageFramework.Database.Procedures.JobTraffic.Update(AFDbContext, JobTraffic)

                        End If

                    End Using

                End Using

            End If

        Catch ex As Exception
            Updated = False
            ErrorMessage = "Runtime failure - " & ex.Message
        End Try

        APIReponse = New APIReponse(Updated, ErrorMessage)

        UpdateProjectScheduleStatus = APIReponse

    End Function
    Public Function CheckForValidSettings(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As ValidationMessage Implements IAPIService.CheckForValidSettings

        'objects
        Dim ValidationMessage As ValidationMessage = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = ""
        Dim IsValid As Boolean = False

        Try

            IsValid = LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage)

        Catch ex As Exception
            IsValid = False
            ErrorMessage = ex.Message
            ProcessException(ex, "APIService-NotCaught")
        End Try

        ValidationMessage = New ValidationMessage(ErrorMessage, IsValid)

        CheckForValidSettings = ValidationMessage

    End Function
    Public Function LoadBillingCoops(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As List(Of BillingCoop) Implements IAPIService.LoadBillingCoops

        'objects
        Dim BillingCoops As Generic.List(Of BillingCoop) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        BillingCoops = New Generic.List(Of BillingCoop)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    BillingCoops = DbContext.BillingCoops.ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            BillingCoops = New Generic.List(Of BillingCoop)
        End Try

        LoadBillingCoops = BillingCoops

    End Function
    Public Function LoadClientDiscounts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of ClientDiscount) Implements IAPIService.LoadClientDiscounts

        'objects
        Dim ClientDiscounts As Generic.List(Of ClientDiscount) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        ClientDiscounts = New Generic.List(Of ClientDiscount)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        ClientDiscounts = DbContext.ClientDiscounts.ToList

                    Else

                        ClientDiscounts = DbContext.ClientDiscounts.Where(Function(Entity) Entity.IsInactive = False).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ClientDiscounts = New Generic.List(Of ClientDiscount)
        End Try

        LoadClientDiscounts = ClientDiscounts

    End Function
    Public Function LoadScheduleStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of ScheduleStatus) Implements IAPIService.LoadScheduleStatuses

        'objects
        Dim ScheduleStatuses As Generic.List(Of ScheduleStatus) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        ScheduleStatuses = New Generic.List(Of ScheduleStatus)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        ScheduleStatuses = DbContext.ScheduleStatuses.ToList

                    Else

                        ScheduleStatuses = DbContext.ScheduleStatuses.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ScheduleStatuses = New Generic.List(Of ScheduleStatus)
        End Try

        LoadScheduleStatuses = ScheduleStatuses

    End Function
    Public Function LoadSalesClasses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of SalesClass) Implements IAPIService.LoadSalesClasses

        'objects
        Dim SalesClasss As Generic.List(Of SalesClass) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        SalesClasss = New Generic.List(Of SalesClass)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        SalesClasss = DbContext.SalesClasses.ToList

                    Else

                        SalesClasss = DbContext.SalesClasses.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            SalesClasss = New Generic.List(Of SalesClass)
        End Try

        LoadSalesClasses = SalesClasss

    End Function
    Public Function LoadSalesClasses2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As SalesClassAPIResponse Implements IAPIService.LoadSalesClasses2

        'objects
        Dim SalesClasss As Generic.List(Of SalesClass) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As SalesClassAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        SalesClasss = New Generic.List(Of SalesClass)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        SalesClasss = DbContext.SalesClasses.ToList

                    Else

                        SalesClasss = DbContext.SalesClasses.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            SalesClasss = New Generic.List(Of SalesClass)
        End Try

        ResultAPIResponse = New SalesClassAPIResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = SalesClasss
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadSalesClasses2 = ResultAPIResponse

    End Function

    Public Function LoadAccountExecutives(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of AccountExecutive) Implements IAPIService.LoadAccountExecutives

        'objects
        Dim AccountExecutives As Generic.List(Of AccountExecutive) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        AccountExecutives = New Generic.List(Of AccountExecutive)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        AccountExecutives = DbContext.AccountExecutives.ToList

                    Else

                        AccountExecutives = DbContext.AccountExecutives.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            AccountExecutives = New Generic.List(Of AccountExecutive)
        End Try

        LoadAccountExecutives = AccountExecutives

    End Function
    Public Function LoadAlertGroups(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of AlertGroup) Implements IAPIService.LoadAlertGroups

        'objects
        Dim AlertGroups As Generic.List(Of AlertGroup) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        AlertGroups = New Generic.List(Of AlertGroup)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        AlertGroups = DbContext.AlertGroups.ToList

                    Else

                        AlertGroups = DbContext.AlertGroups.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            AlertGroups = New Generic.List(Of AlertGroup)
        End Try

        LoadAlertGroups = AlertGroups

    End Function
    Public Function LoadJobTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of JobType) Implements IAPIService.LoadJobTypes

        'objects
        Dim JobTypes As Generic.List(Of JobType) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        JobTypes = New Generic.List(Of JobType)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        JobTypes = DbContext.JobTypes.ToList

                    Else

                        JobTypes = DbContext.JobTypes.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            JobTypes = New Generic.List(Of JobType)
        End Try

        LoadJobTypes = JobTypes

    End Function

    Public Function LoadMediaOrderStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, MediaType As String,
                                           OrderNumber As Integer, LineNumber As Short, RevisionNumber As Short) As List(Of OrderStatusResponse) Implements IAPIService.LoadMediaOrderStatuses

        Dim InternetOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderDetail) = Nothing
        Dim NewspaperOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperOrderDetail) = Nothing
        Dim MagazineOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.MagazineOrderDetail) = Nothing
        Dim OutOfHomeOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeOrderDetail) = Nothing
        Dim TVOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
        Dim RadioOrderDetail As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing

        Dim InternetOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderStatus) = Nothing
        Dim NewspaperOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.NewspaperOrderStatus) = Nothing
        Dim MagazineOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MagazineOrderStatus) = Nothing
        Dim OutOfHomeOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.OutOfHomeOrderStatus) = Nothing
        Dim TVOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderStatus) = Nothing
        Dim RadioOrderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderStatus) = Nothing

        Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing

        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim SearchWithinThis As String = "I,N,M,O,T,R"

        Dim ErrorMessage As String = String.Empty

        Dim OrderStatusResponses As Generic.List(Of OrderStatusResponse) = Nothing

        MediaType = UCase(Left(MediaType, 1))

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    If SearchWithinThis.IndexOf(MediaType) = -1 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = "Invalid Media Type - Must be I,N,M,O,T, or R."

                    Else

                        Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                            Using AdvanDbContext As New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                                'Throw New System.Exception("An exception has occurred.") 'Test Code

                                'Verify Order/Line/Rev
                                If MediaType = "I" Then

                                    InternetOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(AdvanDbContext)
                                                           Where (Entity.InternetOrderOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                           Select Entity).ToList

                                    If InternetOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If

                                ElseIf MediaType = "N" Then

                                    NewspaperOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(AdvanDbContext)
                                                            Where (Entity.NewspaperOrderOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                            Select Entity).ToList

                                    If NewspaperOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If


                                ElseIf MediaType = "M" Then

                                    MagazineOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(AdvanDbContext)
                                                           Where (Entity.MagazineOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                           Select Entity).ToList

                                    If MagazineOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If

                                ElseIf MediaType = "O" Then

                                    OutOfHomeOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(AdvanDbContext)
                                                            Where (Entity.OutofHomeOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                            Select Entity).ToList

                                    If OutOfHomeOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If

                                ElseIf MediaType = "T" Then

                                    TVOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.Load(AdvanDbContext)
                                                     Where (Entity.TVOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                     Select Entity).ToList

                                    If TVOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If

                                ElseIf MediaType = "R" Then

                                    RadioOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(AdvanDbContext)
                                                        Where (Entity.RadioOrderNumber = OrderNumber OrElse OrderNumber = -1) AndAlso
                                                                   (Entity.LineNumber = LineNumber OrElse LineNumber = -1) AndAlso
                                                                   (Entity.RevisionNumber = RevisionNumber OrElse RevisionNumber = -1)
                                                        Select Entity).ToList

                                    If RadioOrderDetail.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order Nbr, Line Nbr, or Revision Nbr."

                                    End If

                                End If

                                'Load by Order/Line/Revision
                                If ErrorMessage = Nothing Then
                                    If MediaType = "I" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            InternetOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                                     Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            InternetOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                                     Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            InternetOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber
                                                                     Select Entity).ToList
                                        Else
                                            InternetOrderStatuses = AdvantageFramework.Database.Procedures.InternetOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    ElseIf MediaType = "N" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            NewspaperOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                                      Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            NewspaperOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                                      Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            NewspaperOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber
                                                                      Select Entity).ToList
                                        Else
                                            NewspaperOrderStatuses = AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    ElseIf MediaType = "M" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            MagazineOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                                     Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            MagazineOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                                     Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            MagazineOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.Load(AdvanDbContext)
                                                                     Where Entity.OrderNumber = OrderNumber
                                                                     Select Entity).ToList
                                        Else
                                            MagazineOrderStatuses = AdvantageFramework.Database.Procedures.MagazineOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    ElseIf MediaType = "O" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            OutOfHomeOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                                      Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            OutOfHomeOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                                      Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            OutOfHomeOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Load(AdvanDbContext)
                                                                      Where Entity.OrderNumber = OrderNumber
                                                                      Select Entity).ToList
                                        Else
                                            OutOfHomeOrderStatuses = AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    ElseIf MediaType = "T" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            TVOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.Load(AdvanDbContext)
                                                               Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                               Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            TVOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.Load(AdvanDbContext)
                                                               Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                               Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            TVOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.Load(AdvanDbContext)
                                                               Where Entity.OrderNumber = OrderNumber
                                                               Select Entity).ToList
                                        Else
                                            TVOrderStatuses = AdvantageFramework.Database.Procedures.TVOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    ElseIf MediaType = "R" Then

                                        If OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 Then
                                            RadioOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.Load(AdvanDbContext)
                                                                  Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber AndAlso
                                                                       Entity.RevisionNumber = RevisionNumber
                                                                  Select Entity).ToList
                                        ElseIf OrderNumber > 0 AndAlso LineNumber > 0 Then
                                            RadioOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.Load(AdvanDbContext)
                                                                  Where Entity.OrderNumber = OrderNumber AndAlso
                                                                       Entity.LineNumber = LineNumber
                                                                  Select Entity).ToList
                                        ElseIf OrderNumber > 0 Then
                                            RadioOrderStatuses = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.Load(AdvanDbContext)
                                                                  Where Entity.OrderNumber = OrderNumber
                                                                  Select Entity).ToList
                                        Else
                                            RadioOrderStatuses = AdvantageFramework.Database.Procedures.RadioOrderStatus.Load(AdvanDbContext).ToList
                                        End If

                                    Else

                                        LoadMediaOrderStatuses = OrderStatusResponses

                                        Exit Function

                                    End If

                                End If

                            End Using

                        End Using

                    End If

                End If

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

            InternetOrderStatus.OrderNumber = Nothing
            InternetOrderStatus.LineNumber = Nothing
            InternetOrderStatus.RevisionNumber = Nothing
            InternetOrderStatus.OrderStatusID = Nothing
            InternetOrderStatus.RevisedByUserCode = Nothing
            InternetOrderStatus.RevisedByName = ex.Message
            InternetOrderStatus.RevisedDate = Nothing

            InternetOrderStatuses = New Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

            InternetOrderStatuses.Add(InternetOrderStatus)

            OrderStatusResponses = InternetOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            LoadMediaOrderStatuses = OrderStatusResponses

            Exit Function

        End Try

        'Copy into to response class
        If ErrorMessage = Nothing Then

            If MediaType = "I" Then

                OrderStatusResponses = InternetOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            ElseIf MediaType = "N" Then

                OrderStatusResponses = NewspaperOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            ElseIf MediaType = "M" Then

                OrderStatusResponses = MagazineOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            ElseIf MediaType = "O" Then

                OrderStatusResponses = OutOfHomeOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            ElseIf MediaType = "R" Then

                OrderStatusResponses = RadioOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            ElseIf MediaType = "T" Then

                OrderStatusResponses = TVOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            Else

                OrderStatusResponses = InternetOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            End If

            If OrderStatusResponses.Count() = 0 Then

                ErrorMessage = "No matching records"

                InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

                InternetOrderStatus.OrderNumber = Nothing
                InternetOrderStatus.LineNumber = Nothing
                InternetOrderStatus.RevisionNumber = Nothing
                InternetOrderStatus.OrderStatusID = Nothing
                InternetOrderStatus.RevisedByUserCode = Nothing
                InternetOrderStatus.RevisedByName = ErrorMessage
                InternetOrderStatus.RevisedDate = Nothing

                InternetOrderStatuses = New Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

                InternetOrderStatuses.Add(InternetOrderStatus)

                OrderStatusResponses = InternetOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

            End If

        Else

            'ErrorMessage - Set Above

            InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

            InternetOrderStatus.OrderNumber = Nothing
            InternetOrderStatus.LineNumber = Nothing
            InternetOrderStatus.RevisionNumber = Nothing
            InternetOrderStatus.OrderStatusID = Nothing
            InternetOrderStatus.RevisedByUserCode = Nothing
            InternetOrderStatus.RevisedByName = ErrorMessage
            InternetOrderStatus.RevisedDate = Nothing

            InternetOrderStatuses = New Generic.List(Of AdvantageFramework.Database.Entities.InternetOrderStatus)

            InternetOrderStatuses.Add(InternetOrderStatus)

            OrderStatusResponses = InternetOrderStatuses.Select(Function(Entity) New OrderStatusResponse(Entity)).ToList

        End If

        LoadMediaOrderStatuses = OrderStatusResponses

    End Function

    Private Function ValidateJobComponentDescription(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobComponentDescription As String, IsRequried As Boolean) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(JobComponentDescription) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Job Component Description is required."))

            End If

        End If

        ValidateJobComponentDescription = IsValid

    End Function
    Private Function ValidateJobDescription(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobDescription As String, IsRequried As Boolean) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(JobDescription) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Job Description is required."))

            End If

        End If

        ValidateJobDescription = IsValid

    End Function
    Private Function ValidateJobComponent(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobNumber As Integer, JobComponentNumber As Short) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If DbContext.JobComponents.Any(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNumber) = False Then

            IsValid = False
            CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Job\Component Number."))

        End If

        ValidateJobComponent = IsValid

    End Function
    Private Function ValidateJob(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobNumber As Integer) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If DbContext.Jobs.Any(Function(Entity) Entity.JobNumber = JobNumber) = False Then

            IsValid = False
            CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Job Number."))

        End If

        ValidateJob = IsValid

    End Function
    Private Function ValidateAlertGroup(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, AlertGroupCode As String, IsRequried As Boolean) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(AlertGroupCode) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Alert Group Code is required."))

            End If

        End If

        If IsValid AndAlso String.IsNullOrWhiteSpace(AlertGroupCode) = False Then

            If DbContext.AlertGroups.Any(Function(Entity) Entity.Code = AlertGroupCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Alert Group Code."))

            End If

        End If

        ValidateAlertGroup = IsValid

    End Function
    Private Function ValidateJobType(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, JobTypeCode As String, IsRequried As Boolean) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(JobTypeCode) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Job Type Code is required."))

            End If

        End If

        If IsValid AndAlso String.IsNullOrWhiteSpace(JobTypeCode) = False Then

            If DbContext.JobTypes.Any(Function(Entity) Entity.Code = JobTypeCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Job Type Code."))

            End If

        End If

        ValidateJobType = IsValid

    End Function
    Private Function ValidateAccountExecutive(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, ClientCode As String, DivisionCode As String, ProductCode As String, AccountExecutiveEmployeeCode As String, IsRequried As Boolean) As Boolean

        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(AccountExecutiveEmployeeCode) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Account Executive Employee Code is required."))

            End If

        End If

        If IsValid AndAlso String.IsNullOrWhiteSpace(AccountExecutiveEmployeeCode) = False Then

            If DbContext.AccountExecutives.Any(Function(Entity) Entity.EmployeeCode = AccountExecutiveEmployeeCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Account Executive Employee Code."))

            End If

            If IsValid Then

                If DbContext.AccountExecutives.Any(Function(Entity) Entity.EmployeeCode = AccountExecutiveEmployeeCode AndAlso Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode = ProductCode) = False Then

                    IsValid = False
                    CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Account Executive Employee Code for Client\Division\Product."))

                End If

            End If

        End If

        ValidateAccountExecutive = IsValid

    End Function
    Private Function ValidateCampaign(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, ClientCode As String, CampaignID As Integer) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If CampaignID > 0 Then

            If DbContext.Campaigns.Any(Function(Entity) Entity.ID = CampaignID) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Campaign ID."))

            End If

            If IsValid Then

                If DbContext.Campaigns.Any(Function(Entity) Entity.ID = CampaignID AndAlso Entity.ClientCode = ClientCode) = False Then

                    IsValid = False
                    CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Campaign ID for Client."))

                End If

            End If

        End If

        ValidateCampaign = IsValid

    End Function
    Private Function ValidateSalesClass(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, SalesClassCode As String, IsRequried As Boolean) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If IsRequried Then

            If String.IsNullOrWhiteSpace(SalesClassCode) = True Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Sales Class Code is required."))

            End If

        End If

        If IsValid AndAlso String.IsNullOrWhiteSpace(SalesClassCode) = False Then

            If DbContext.SalesClasses.Any(Function(Entity) Entity.Code = SalesClassCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Sales Class Code."))

            End If

        End If

        ValidateSalesClass = IsValid

    End Function
    Private Function ValidateCDP(DbContext As APIDbContext, CreateJobResponse As CreateJobResponse, ClientCode As String, DivisionCode As String, ProductCode As String) As Boolean


        'objects
        Dim IsValid As Boolean = True

        If String.IsNullOrWhiteSpace(ClientCode) = True Then

            IsValid = False
            CreateJobResponse.Message &= LTrim(RTrim("  " & "Client Code is required."))

        Else

            If DbContext.Clients.Any(Function(Entity) Entity.Code = ClientCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Client Code."))

            End If

        End If

        If String.IsNullOrWhiteSpace(DivisionCode) = True Then

            IsValid = False
            CreateJobResponse.Message &= LTrim(RTrim("  " & "Division Code is required."))

        Else

            If DbContext.Divisions.Any(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Code = DivisionCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Division Code."))

            End If

        End If

        If String.IsNullOrWhiteSpace(ProductCode) = True Then

            IsValid = False
            CreateJobResponse.Message &= LTrim(RTrim("  " & "Product Code is required."))

        Else

            If DbContext.Products.Any(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.Code = ProductCode) = False Then

                IsValid = False
                CreateJobResponse.Message &= LTrim(RTrim("  " & "Invalid Product Code."))

            End If

        End If

        ValidateCDP = IsValid

    End Function
    Public Function LoadMediaOrders(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                    OrderStatus As String, StartDate As Date, StartMonth As Integer, StartYear As Integer, EndDate As Date, EndMonth As Integer,
                                    EndYear As Integer, IncludeInternet As Boolean, IncludeMagazine As Boolean, IncludeNewspaper As Boolean, IncludeOutOfHome As Boolean,
                                    IncludeRadio As Boolean, IncludeTV As Boolean, OrderNumbers As String) As List(Of MediaOrder) Implements IAPIService.LoadMediaOrders

        'objects
        Dim MediaOrders As Generic.List(Of MediaOrder) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        MediaOrders = New Generic.List(Of MediaOrder)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    MediaOrders = DbContext.LoadMediaOrders(OrderStatus, StartDate, StartMonth, StartYear, EndDate, EndMonth, EndYear, IncludeInternet, IncludeMagazine, IncludeNewspaper, IncludeOutOfHome, IncludeRadio, IncludeTV, OrderNumbers).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadMediaOrders = MediaOrders

    End Function
    Public Function LoadMediaBroadcastDetails(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                    Optional ByVal MediaType As String = "A") As MediaBroadcastDetailsAPIResponse Implements IAPIService.LoadMediaBroadcastDetails

        'objects
        Dim MediaBroadcastDetails As Generic.List(Of MediaBroadcastDetails) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = ""
        Dim ResultAPIResponse As MediaBroadcastDetailsAPIResponse = Nothing

        MediaBroadcastDetails = New Generic.List(Of MediaBroadcastDetails)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    MediaBroadcastDetails = DbContext.LoadMediaBroadcastDetails(MediaType, ErrorMessage)

                End Using

            End If


        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            MediaBroadcastDetails = New Generic.List(Of MediaBroadcastDetails)
        End Try

        ResultAPIResponse = New MediaBroadcastDetailsAPIResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = MediaBroadcastDetails
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If


        LoadMediaBroadcastDetails = ResultAPIResponse

    End Function
    Public Function LoadCampaigns(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As List(Of Campaign) Implements IAPIService.LoadCampaigns

        'objects
        Dim Campaigns As Generic.List(Of Campaign) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim sql As String

        Campaigns = New Generic.List(Of Campaign)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadClosed Then

                        'Campaigns = DbContext.Campaigns.ToList

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " ORDER BY CMP_CODE;"

                    Else

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " WHERE ISNULL(CMP_CLOSED, 0) = 0" +
                            " ORDER BY CMP_CODE;"

                        'Campaigns = DbContext.Campaigns.Where(Function(Entity) Entity.IsClosed = 0).ToList

                    End If

                    Campaigns = DbContext.Database.SqlQuery(Of Campaign)(String.Format(sql)).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Campaigns = New Generic.List(Of Campaign)
        End Try

        LoadCampaigns = Campaigns

    End Function
    Public Function LoadCampaigns2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As CampaignAPIResponse Implements IAPIService.LoadCampaigns2

        'objects
        Dim Campaigns As Generic.List(Of Campaign) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As CampaignAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Dim sql As String

        'Dim Campaign As Campaign

        Campaigns = New Generic.List(Of Campaign)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadClosed Then

                        'Campaigns = DbContext.Campaigns.ToList

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " ORDER BY CMP_CODE;"

                    Else

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " WHERE ISNULL(CMP_CLOSED, 0) = 0" +
                            " ORDER BY CMP_CODE;"

                        'Campaigns = DbContext.Campaigns.Where(Function(Entity) Entity.IsClosed = 0).ToList

                    End If

                    Campaigns = DbContext.Database.SqlQuery(Of Campaign)(String.Format(sql)).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Campaigns = New Generic.List(Of Campaign)
        End Try

        ResultAPIResponse = New CampaignAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Campaigns
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadCampaigns2 = ResultAPIResponse

    End Function
    Public Function LoadAdNumbers(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of AdNumber) Implements IAPIService.LoadAdNumbers

        'objects
        Dim AdNumbers As Generic.List(Of AdNumber) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        AdNumbers = New Generic.List(Of AdNumber)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        AdNumbers = DbContext.AdNumbers.ToList

                    Else

                        AdNumbers = DbContext.AdNumbers.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            AdNumbers = New Generic.List(Of AdNumber)
        End Try

        LoadAdNumbers = AdNumbers

    End Function
    Public Function LoadAdSizes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of AdSize) Implements IAPIService.LoadAdSizes

        'objects
        Dim AdSizes As Generic.List(Of AdSize) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        AdSizes = New Generic.List(Of AdSize)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        AdSizes = DbContext.AdSizes.ToList

                    Else

                        AdSizes = DbContext.AdSizes.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            AdSizes = New Generic.List(Of AdSize)
        End Try

        LoadAdSizes = AdSizes

    End Function
    Public Function LoadInternetTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of InternetType) Implements IAPIService.LoadInternetTypes

        'objects
        Dim InternetTypes As Generic.List(Of InternetType) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        InternetTypes = New Generic.List(Of InternetType)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        InternetTypes = DbContext.InternetTypes.ToList

                    Else

                        InternetTypes = DbContext.InternetTypes.Where(Function(Entity) Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            InternetTypes = New Generic.List(Of InternetType)
        End Try

        LoadInternetTypes = InternetTypes

    End Function
    Public Function LoadInternetCostTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As List(Of InternetCostType) Implements IAPIService.LoadInternetCostTypes

        'objects
        Dim InternetCostTypes As Generic.List(Of InternetCostType) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        InternetCostTypes = New Generic.List(Of InternetCostType)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                InternetCostTypes.Add(New InternetCostType With {.Code = AdvantageFramework.Database.Entities.CostType.CPM.ToString, .Description = "Cost Per Thousand"})
                InternetCostTypes.Add(New InternetCostType With {.Code = AdvantageFramework.Database.Entities.CostType.CPC.ToString, .Description = "Cost Per Click"})
                InternetCostTypes.Add(New InternetCostType With {.Code = AdvantageFramework.Database.Entities.CostType.CPA.ToString, .Description = "Cost Per Acquisition"})
                InternetCostTypes.Add(New InternetCostType With {.Code = AdvantageFramework.Database.Entities.CostType.NA.ToString, .Description = "Not Applicable"})

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            InternetCostTypes = New Generic.List(Of InternetCostType)
        End Try

        LoadInternetCostTypes = InternetCostTypes

    End Function
    Public Function LoadFiscalPeriods(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of FiscalPeriod) Implements IAPIService.LoadFiscalPeriods

        'objects
        Dim FiscalPeriods As Generic.List(Of FiscalPeriod) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        FiscalPeriods = New Generic.List(Of FiscalPeriod)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        FiscalPeriods = DbContext.FiscalPeriods.ToList

                    Else

                        FiscalPeriods = DbContext.FiscalPeriods.Where(Function(Entity) Entity.IsInactive = 0 OrElse Entity.IsInactive Is Nothing).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            FiscalPeriods = New Generic.List(Of FiscalPeriod)
        End Try

        LoadFiscalPeriods = FiscalPeriods

    End Function
    Public Function LoadMarkets(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Market) Implements IAPIService.LoadMarkets

        'objects
        Dim Markets As Generic.List(Of Market) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Markets = New Generic.List(Of Market)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Markets = DbContext.Markets.ToList

                    Else

                        Markets = DbContext.Markets.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Markets = New Generic.List(Of Market)
        End Try

        LoadMarkets = Markets

    End Function
    Public Function SaveMarket(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, MarketCode As String, Description As String, IsInactive As Short) As Boolean Implements IAPIService.SaveMarket

        'objects
        Dim Saved As Boolean = False
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim Market As Market = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Try

                        Market = DbContext.Markets.ToList.SingleOrDefault(Function(Entity) Entity.Code.ToUpper = MarketCode.ToUpper)

                    Catch ex As Exception
                        Market = Nothing
                    End Try

                    If Market IsNot Nothing Then

                        Market.Description = Description

                        If IsInactive = 1 Then

                            Market.IsInactive = 1

                        Else

                            Market.IsInactive = Nothing

                        End If

                        Saved = (DbContext.SaveChanges() > 0)

                    Else

                        Market = New Market

                        Market.Code = MarketCode
                        Market.Description = Description

                        If IsInactive = 1 Then

                            Market.IsInactive = 1

                        Else

                            Market.IsInactive = Nothing

                        End If

                        DbContext.Markets.Add(Market)

                        Saved = (DbContext.SaveChanges() > 0)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Saved = False
        End Try

        SaveMarket = Saved

    End Function
    'Public Function Login(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As LoginReponse Implements IAPIService.Login

    '    'objects
    '    Dim ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String = ""
    '    Dim ErrorMessage As String = ""
    '    Dim APISession As AdvantageFramework.Security.APISession = Nothing
    '    Dim LoginReponse As LoginReponse = Nothing

    '    Try

    '        If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

    '            SessionID = HttpContext.Current.Session.SessionID
    '            HttpContext.Current.Session(SessionID) = APISession

    '        Else

    '            SessionID = ""
    '            APISession = Nothing

    '        End If

    '    Catch ex As Exception
    '        ErrorMessage &= LTrim(RTrim(" " & ex.Message))
    '        SessionID = ""
    '        APISession = Nothing
    '    End Try

    '    If String.IsNullOrWhiteSpace(SessionID) = False AndAlso APISession IsNot Nothing Then

    '        LoginReponse = New LoginReponse(True, SessionID, "")

    '    Else

    '        LoginReponse = New LoginReponse(False, "", ErrorMessage)

    '    End If

    '    Login = LoginReponse

    'End Function
    Public Function LoadVCCStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As List(Of VCCStatus) Implements IAPIService.LoadVCCStatuses

        'objects
        Dim VCCStatuses As Generic.List(Of VCCStatus) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        VCCStatuses = New Generic.List(Of VCCStatus)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                VCCStatuses.Add(New VCCStatus(AdvantageFramework.Database.Entities.VCCStatuses.Accepted))
                VCCStatuses.Add(New VCCStatus(AdvantageFramework.Database.Entities.VCCStatuses.Declined))

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            VCCStatuses = New Generic.List(Of VCCStatus)
        End Try

        LoadVCCStatuses = VCCStatuses

    End Function
    Public Function LoadVendorCategories(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As List(Of VendorCategory) Implements IAPIService.LoadVendorCategories

        'objects
        Dim VendorCategories As Generic.List(Of VendorCategory) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        VendorCategories = New Generic.List(Of VendorCategory)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                VendorCategories = GetVendorCategories()

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            VendorCategories = New Generic.List(Of VendorCategory)
        End Try

        LoadVendorCategories = VendorCategories

    End Function
    Public Function SaveVendorContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, VendorCode As String,
                                      VendorContactCode As String, Address1 As String, Address2 As String, City As String, County As String, State As String, Country As String,
                                      Zip As String, Phone As String, PhoneExt As String, Fax As String, FaxExt As String, Email As String, Cell As String) As Boolean Implements IAPIService.SaveVendorContact

        'objects
        Dim Saved As Boolean = False
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim VendorContact As VendorContact = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Try

                        VendorContact = DbContext.VendorContacts.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorContactCode)

                    Catch ex As Exception
                        VendorContact = Nothing
                    End Try

                    If VendorContact IsNot Nothing Then

                        VendorContact.Address1 = LoadImportedDataToUpdate(VendorContact.Address1, Address1)
                        VendorContact.Address2 = LoadImportedDataToUpdate(VendorContact.Address2, Address2)
                        VendorContact.City = LoadImportedDataToUpdate(VendorContact.City, City)
                        VendorContact.County = LoadImportedDataToUpdate(VendorContact.County, County)
                        VendorContact.State = LoadImportedDataToUpdate(VendorContact.State, State)
                        VendorContact.Country = LoadImportedDataToUpdate(VendorContact.Country, Country)
                        VendorContact.Zip = LoadImportedDataToUpdate(VendorContact.Zip, Zip)
                        VendorContact.Phone = LoadImportedDataToUpdate(VendorContact.Phone, Phone)
                        VendorContact.PhoneExt = LoadImportedDataToUpdate(VendorContact.PhoneExt, PhoneExt)
                        VendorContact.Fax = LoadImportedDataToUpdate(VendorContact.Fax, Fax)
                        VendorContact.FaxExt = LoadImportedDataToUpdate(VendorContact.FaxExt, FaxExt)
                        VendorContact.Email = LoadImportedDataToUpdate(VendorContact.Email, Email)
                        VendorContact.Cell = LoadImportedDataToUpdate(VendorContact.Cell, Cell)

                        Saved = (DbContext.SaveChanges() > 0)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Saved = False
        End Try

        SaveVendorContact = Saved

    End Function
    Public Function SaveVendorRepresentative(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            VendorCode As String, VendorRepresentativeCode As String,
                            FirstName As String, LastName As String, MiddleInitial As String, FirmName As String,
                            Address1 As String, Address2 As String, City As String, County As String, State As String, Country As String, Zip As String, Telephone As String,
                            TelephoneExtension As String, Fax As String, FaxExtension As String, EmailAddress As String, CellPhone As String,
                            ContactTypeID As Integer, IsInactive As Integer) As Boolean Implements IAPIService.SaveVendorRepresentative

        'objects
        Dim Saved As Boolean = True
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim VendorRepresentative As VendorRepresentative = Nothing
        Dim Vendors As Generic.List(Of Vendor) = Nothing
        Dim ChangesSaved As Integer = 0
        Dim Categories As String = Nothing
        Dim Vendor As Vendor = Nothing
        Dim ContactType As ContactType = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Try

                        VendorRepresentative = DbContext.VendorRepresentatives.SingleOrDefault(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.Code = VendorRepresentativeCode)

                    Catch ex As Exception
                        VendorRepresentative = Nothing
                    End Try

                    If ContactTypeID = 0 Then
                        ContactTypeID = 1 'Default to 1 if not passed
                    End If

                    If VendorRepresentative IsNot Nothing Then

                        VendorRepresentative.FirstName = LoadImportedDataToUpdate(VendorRepresentative.FirstName, FirstName)
                        VendorRepresentative.LastName = LoadImportedDataToUpdate(VendorRepresentative.LastName, LastName)
                        VendorRepresentative.MiddleInitial = LoadImportedDataToUpdate(VendorRepresentative.MiddleInitial, MiddleInitial)
                        VendorRepresentative.FirmName = LoadImportedDataToUpdate(VendorRepresentative.FirmName, FirmName)
                        VendorRepresentative.Address1 = LoadImportedDataToUpdate(VendorRepresentative.Address1, Address1)
                        VendorRepresentative.Address2 = LoadImportedDataToUpdate(VendorRepresentative.Address2, Address2)
                        VendorRepresentative.City = LoadImportedDataToUpdate(VendorRepresentative.City, City)
                        VendorRepresentative.County = LoadImportedDataToUpdate(VendorRepresentative.County, County)
                        VendorRepresentative.State = LoadImportedDataToUpdate(VendorRepresentative.State, State)
                        VendorRepresentative.Country = LoadImportedDataToUpdate(VendorRepresentative.Country, Country)
                        VendorRepresentative.Zip = LoadImportedDataToUpdate(VendorRepresentative.Zip, Zip)
                        VendorRepresentative.Telephone = LoadImportedDataToUpdate(VendorRepresentative.Telephone, Telephone)
                        VendorRepresentative.TelephoneExtension = LoadImportedDataToUpdate(VendorRepresentative.TelephoneExtension, TelephoneExtension)
                        VendorRepresentative.Fax = LoadImportedDataToUpdate(VendorRepresentative.Fax, Fax)
                        VendorRepresentative.FaxExtension = LoadImportedDataToUpdate(VendorRepresentative.FaxExtension, FaxExtension)
                        VendorRepresentative.EmailAddress = LoadImportedDataToUpdate(VendorRepresentative.EmailAddress, EmailAddress)
                        VendorRepresentative.CellPhone = LoadImportedDataToUpdate(VendorRepresentative.CellPhone, CellPhone)

                        VendorRepresentative.ContactTypeID = LoadImportedDataToUpdate(VendorRepresentative.ContactTypeID, ContactTypeID)
                        VendorRepresentative.IsInactive = LoadImportedDataToUpdate(VendorRepresentative.IsInactive, IsInactive)

                        'Saved = (DbContext.SaveChanges() > 0)

                        ChangesSaved = DbContext.SaveChanges() 'Only return False on Error

                    Else

                        VendorRepresentative = New VendorRepresentative

                        If String.IsNullOrEmpty(VendorCode) = False AndAlso String.IsNullOrEmpty(VendorRepresentativeCode) = False Then

                            Vendor = DbContext.Vendors.Find(VendorCode)

                            ContactType = DbContext.ContactTypes.Find(ContactTypeID)

                            If Vendor IsNot Nothing AndAlso Vendor.ActiveFlag = 1 AndAlso ContactType IsNot Nothing Then

                                VendorRepresentative.VendorCode = VendorCode
                                VendorRepresentative.Code = VendorRepresentativeCode

                                VendorRepresentative.FirstName = ConvertEmptyToNothing(FirstName)
                                VendorRepresentative.LastName = ConvertEmptyToNothing(LastName)
                                VendorRepresentative.MiddleInitial = ConvertEmptyToNothing(MiddleInitial)
                                VendorRepresentative.FirmName = ConvertEmptyToNothing(FirmName)

                                VendorRepresentative.Address1 = ConvertEmptyToNothing(Address1)
                                VendorRepresentative.Address2 = ConvertEmptyToNothing(Address2)
                                VendorRepresentative.City = ConvertEmptyToNothing(City)
                                VendorRepresentative.County = ConvertEmptyToNothing(County)
                                VendorRepresentative.State = ConvertEmptyToNothing(State)
                                VendorRepresentative.Country = ConvertEmptyToNothing(Country)
                                VendorRepresentative.Zip = ConvertEmptyToNothing(Zip)
                                VendorRepresentative.Telephone = ConvertEmptyToNothing(Telephone)
                                VendorRepresentative.TelephoneExtension = ConvertEmptyToNothing(TelephoneExtension)
                                VendorRepresentative.Fax = ConvertEmptyToNothing(Fax)
                                VendorRepresentative.FaxExtension = ConvertEmptyToNothing(FaxExtension)
                                VendorRepresentative.EmailAddress = ConvertEmptyToNothing(EmailAddress)
                                VendorRepresentative.CellPhone = ConvertEmptyToNothing(CellPhone)

                                VendorRepresentative.ContactTypeID = ContactTypeID
                                VendorRepresentative.IsInactive = IsInactive

                                VendorRepresentative = DbContext.VendorRepresentatives.Add(VendorRepresentative)

                                ChangesSaved = DbContext.SaveChanges()

                                Saved = (ChangesSaved > 0)

                            Else

                                Saved = False

                            End If

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Saved = False
        End Try

        SaveVendorRepresentative = Saved

    End Function
    Public Function SaveVendor(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                               VendorCode As String, StreetAddressLine1 As String, StreetAddressLine2 As String, StreetAddressLine3 As String,
                               City As String, County As String, State As String, Country As String, ZipCode As String,
                               PhoneNumber As String, PhoneNumberExtension As String, FaxPhoneNumber As String, FaxPhoneNumberExtension As String,
                               EmailAddress As String, PaymentManagerEmailAddress As String, VCCStatus As String, VendorTermCode As String,
                               HasSpecialTerms As Boolean) As Boolean Implements IAPIService.SaveVendor

        'objects
        Dim Saved As Boolean = False
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim Vendor As Vendor = Nothing
        Dim VCCStatusID As Short = 0

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Try

                        Vendor = DbContext.Vendors.SingleOrDefault(Function(Entity) Entity.Code = VendorCode)

                    Catch ex As Exception
                        Vendor = Nothing
                    End Try

                    If Vendor IsNot Nothing Then

                        Vendor.StreetAddressLine1 = LoadImportedDataToUpdate(Vendor.StreetAddressLine1, StreetAddressLine1)
                        Vendor.StreetAddressLine2 = LoadImportedDataToUpdate(Vendor.StreetAddressLine2, StreetAddressLine2)
                        Vendor.StreetAddressLine3 = LoadImportedDataToUpdate(Vendor.StreetAddressLine3, StreetAddressLine3)
                        Vendor.City = LoadImportedDataToUpdate(Vendor.City, City)
                        Vendor.County = LoadImportedDataToUpdate(Vendor.County, County)
                        Vendor.State = LoadImportedDataToUpdate(Vendor.State, State)
                        Vendor.Country = LoadImportedDataToUpdate(Vendor.Country, Country)
                        Vendor.ZipCode = LoadImportedDataToUpdate(Vendor.ZipCode, ZipCode)
                        Vendor.PhoneNumber = LoadImportedDataToUpdate(Vendor.PhoneNumber, PhoneNumber)
                        Vendor.PhoneNumberExtension = LoadImportedDataToUpdate(Vendor.PhoneNumberExtension, PhoneNumberExtension)
                        Vendor.FaxPhoneNumber = LoadImportedDataToUpdate(Vendor.FaxPhoneNumber, FaxPhoneNumber)
                        Vendor.FaxPhoneNumberExtension = LoadImportedDataToUpdate(Vendor.FaxPhoneNumberExtension, FaxPhoneNumberExtension)
                        Vendor.EmailAddress = LoadImportedDataToUpdate(Vendor.EmailAddress, EmailAddress)
                        Vendor.PaymentManagerEmailAddress = LoadImportedDataToUpdate(Vendor.PaymentManagerEmailAddress, PaymentManagerEmailAddress)

                        If String.IsNullOrWhiteSpace(VCCStatus) = False Then

                            VCCStatus = VCCStatus.Trim

                            If IsNumeric(VCCStatus) Then

                                Try

                                    VCCStatusID = Convert.ToInt16(VCCStatus)

                                Catch ex As Exception
                                    VCCStatusID = 0
                                End Try

                                If VCCStatusID = 1 OrElse VCCStatusID = 2 Then

                                    Vendor.VCCStatus = VCCStatusID

                                End If

                            Else

                                If VCCStatus.ToUpper = AdvantageFramework.Database.Entities.VCCStatuses.Accepted.ToString.ToUpper Then

                                    Vendor.VCCStatus = 1

                                ElseIf VCCStatus.ToUpper = AdvantageFramework.Database.Entities.VCCStatuses.Declined.ToString.ToUpper Then

                                    Vendor.VCCStatus = 2

                                ElseIf VCCStatus = "*" Then

                                    Vendor.VCCStatus = Nothing

                                End If

                            End If

                        End If

                        Vendor.VendorTermCode = LoadImportedDataToUpdate(Vendor.VendorTermCode, VendorTermCode)
                        Vendor.HasSpecialTerms = HasSpecialTerms

                        Saved = (DbContext.SaveChanges() > 0)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Saved = False
        End Try

        SaveVendor = Saved

    End Function
    Public Function LoadVendorTerms(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of VendorTerm) Implements IAPIService.LoadVendorTerms

        'objects
        Dim VendorTerms As Generic.List(Of VendorTerm) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        VendorTerms = New Generic.List(Of VendorTerm)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        VendorTerms = DbContext.VendorTerms.ToList

                    Else

                        VendorTerms = DbContext.VendorTerms.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            VendorTerms = New Generic.List(Of VendorTerm)
        End Try

        LoadVendorTerms = VendorTerms

    End Function
    Public Function LoadBanks(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Bank) Implements IAPIService.LoadBanks

        'objects
        Dim Banks As Generic.List(Of Bank) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Banks = New Generic.List(Of Bank)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Banks = DbContext.Banks.ToList

                    Else

                        Banks = DbContext.Banks.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Banks = New Generic.List(Of Bank)
        End Try

        LoadBanks = Banks

    End Function
    Public Function LoadContactTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As List(Of ContactType) Implements IAPIService.LoadContactTypes

        'objects
        Dim ContactTypes As Generic.List(Of ContactType) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        ContactTypes = New Generic.List(Of ContactType)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    ContactTypes = DbContext.ContactTypes.ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ContactTypes = New Generic.List(Of ContactType)
        End Try

        LoadContactTypes = ContactTypes

    End Function
    Public Function LoadVendorRepresentatives(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of VendorRepResponse) Implements IAPIService.LoadVendorRepresentatives

        'objects
        Dim VendorRepresentatives As Generic.List(Of VendorRepresentative) = Nothing
        Dim VendorRepResponses As Generic.List(Of VendorRepResponse) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        VendorRepresentatives = New Generic.List(Of VendorRepresentative)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        VendorRepresentatives = DbContext.VendorRepresentatives.Include("Vendor").ToList

                    Else

                        VendorRepresentatives = DbContext.VendorRepresentatives.Include("Vendor").Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            VendorRepresentatives = New Generic.List(Of VendorRepresentative)
        End Try

        VendorRepResponses = VendorRepresentatives.Select(Function(Entity) New VendorRepResponse(Entity)).ToList

        LoadVendorRepresentatives = VendorRepResponses

    End Function
    Public Function LoadClients(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Client) Implements IAPIService.LoadClients

        'objects
        Dim Clients As Generic.List(Of Client) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Clients = New Generic.List(Of Client)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Clients = DbContext.Clients.ToList

                    Else

                        Clients = DbContext.Clients.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Clients = New Generic.List(Of Client)
        End Try

        LoadClients = Clients

    End Function

    Public Function LoadClients2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As ClientAPIResponse Implements IAPIService.LoadClients2

        'objects
        Dim Clients As Generic.List(Of Client) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As ClientAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Clients = New Generic.List(Of Client)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Clients = DbContext.Clients.ToList

                    Else

                        Clients = DbContext.Clients.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Clients = New Generic.List(Of Client)
        End Try

        ResultAPIResponse = New ClientAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Clients
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadClients2 = ResultAPIResponse

    End Function
    Public Function LoadDivisions(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Division) Implements IAPIService.LoadDivisions

        'objects
        Dim Divisions As Generic.List(Of Division) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Divisions = New Generic.List(Of Division)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Divisions = DbContext.Divisions.ToList

                    Else

                        Divisions = DbContext.Divisions.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Divisions = New Generic.List(Of Division)
        End Try

        LoadDivisions = Divisions

    End Function
    Public Function LoadDivisions2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As DivisionAPIResponse Implements IAPIService.LoadDivisions2

        'objects
        Dim Divisions As Generic.List(Of Division) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As DivisionAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Divisions = New Generic.List(Of Division)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Divisions = DbContext.Divisions.ToList

                    Else

                        Divisions = DbContext.Divisions.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Divisions = New Generic.List(Of Division)
        End Try

        ResultAPIResponse = New DivisionAPIResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Divisions
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If


        LoadDivisions2 = ResultAPIResponse

    End Function

    Public Function LoadProducts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Product) Implements IAPIService.LoadProducts

        'objects
        Dim Products As Generic.List(Of Product) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Products = New Generic.List(Of Product)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Products = DbContext.Products.ToList

                    Else

                        Products = DbContext.Products.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Products = New Generic.List(Of Product)
        End Try

        LoadProducts = Products

    End Function
    Public Function LoadProducts2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String,
                                  Password As String, LoadInactive As Boolean) As ProductAPIResponse Implements IAPIService.LoadProducts2

        'objects
        Dim Products As Generic.List(Of Product) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As ProductAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Products = New Generic.List(Of Product)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Products = DbContext.Products.ToList

                    Else

                        Products = DbContext.Products.Where(Function(Entity) Entity.IsActive = 1).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Products = New Generic.List(Of Product)
        End Try

        ResultAPIResponse = New ProductAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Products
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If


        LoadProducts2 = ResultAPIResponse

    End Function

    Public Function LoadVendorContacts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of VendorContact) Implements IAPIService.LoadVendorContacts

        'objects
        Dim VendorContacts As Generic.List(Of VendorContact) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        VendorContacts = New Generic.List(Of VendorContact)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        VendorContacts = DbContext.VendorContacts.ToList

                    Else

                        VendorContacts = DbContext.VendorContacts.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            VendorContacts = New Generic.List(Of VendorContact)
        End Try

        LoadVendorContacts = VendorContacts

    End Function
    Public Function LoadVendors(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, Categories As String) As List(Of Vendor) Implements IAPIService.LoadVendors

        'objects
        Dim Vendors As Generic.List(Of Vendor) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim VendorCategories As Generic.List(Of VendorCategory) = Nothing
        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonMediaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowMagazineSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNewspaperSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowRadioSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowTelevisionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowOutOfHomeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowInternetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonClientSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Vendors = New Generic.List(Of Vendor)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeInactive", SqlDbType.Bit) With {.Value = LoadInactive}

                    AllowNonMediaSqlParameter = New System.Data.SqlClient.SqlParameter("@NonMedia", SqlDbType.Bit) With {.Value = False}
                    AllowMagazineSqlParameter = New System.Data.SqlClient.SqlParameter("@Magazine", SqlDbType.Bit) With {.Value = False}
                    AllowNewspaperSqlParameter = New System.Data.SqlClient.SqlParameter("@Newspaper", SqlDbType.Bit) With {.Value = False}
                    AllowRadioSqlParameter = New System.Data.SqlClient.SqlParameter("@Radio", SqlDbType.Bit) With {.Value = False}
                    AllowTelevisionSqlParameter = New System.Data.SqlClient.SqlParameter("@Television", SqlDbType.Bit) With {.Value = False}
                    AllowOutOfHomeSqlParameter = New System.Data.SqlClient.SqlParameter("@OutOfHome", SqlDbType.Bit) With {.Value = False}
                    AllowInternetSqlParameter = New System.Data.SqlClient.SqlParameter("@Internet", SqlDbType.Bit) With {.Value = False}
                    AllowNonClientSqlParameter = New System.Data.SqlClient.SqlParameter("@NonClient", SqlDbType.Bit) With {.Value = False}

                    VendorCategories = GetVendorCategories()

                    If Not String.IsNullOrWhiteSpace(Categories) Then

                        VendorCategories = (From Item In VendorCategories
                                            Where Categories.Split(",").ToList.Any(Function(c) c.Trim.ToUpper = Item.Code)
                                            Select Item).ToList

                    End If

                    For Each VendorCategory In VendorCategories

                        Select Case VendorCategory.Code

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Internet).Code

                                AllowInternetSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Magazine).Code

                                AllowMagazineSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Newspaper).Code

                                AllowNewspaperSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonClient).Code

                                AllowNonClientSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonMedia).Code

                                AllowNonMediaSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome).Code

                                AllowOutOfHomeSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Radio).Code

                                AllowRadioSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Television).Code

                                AllowTelevisionSqlParameter.Value = True

                        End Select

                    Next

                    Vendors = DbContext.Database.SqlQuery(Of Vendor)("exec [dbo].[advsp_api_load_vendors] @IncludeInactive, @NonMedia, @Magazine, @Newspaper, @Radio, @Television, @OutOfHome, @Internet, @NonClient", IncludeInactiveSqlParameter, AllowNonMediaSqlParameter, AllowMagazineSqlParameter, AllowNewspaperSqlParameter, AllowRadioSqlParameter, AllowTelevisionSqlParameter, AllowOutOfHomeSqlParameter, AllowInternetSqlParameter, AllowNonClientSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Vendors = New Generic.List(Of Vendor)
        End Try

        LoadVendors = Vendors

    End Function
    Public Function LoadVendors2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, Categories As String) As VendorAPIResponse Implements IAPIService.LoadVendors2

        'objects
        Dim Vendors As Generic.List(Of Vendor) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim VendorCategories As Generic.List(Of VendorCategory) = Nothing
        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonMediaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowMagazineSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNewspaperSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowRadioSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowTelevisionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowOutOfHomeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowInternetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonClientSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Dim ResultAPIResponse As VendorAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Vendors = New Generic.List(Of Vendor)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeInactive", SqlDbType.Bit) With {.Value = LoadInactive}

                    AllowNonMediaSqlParameter = New System.Data.SqlClient.SqlParameter("@NonMedia", SqlDbType.Bit) With {.Value = False}
                    AllowMagazineSqlParameter = New System.Data.SqlClient.SqlParameter("@Magazine", SqlDbType.Bit) With {.Value = False}
                    AllowNewspaperSqlParameter = New System.Data.SqlClient.SqlParameter("@Newspaper", SqlDbType.Bit) With {.Value = False}
                    AllowRadioSqlParameter = New System.Data.SqlClient.SqlParameter("@Radio", SqlDbType.Bit) With {.Value = False}
                    AllowTelevisionSqlParameter = New System.Data.SqlClient.SqlParameter("@Television", SqlDbType.Bit) With {.Value = False}
                    AllowOutOfHomeSqlParameter = New System.Data.SqlClient.SqlParameter("@OutOfHome", SqlDbType.Bit) With {.Value = False}
                    AllowInternetSqlParameter = New System.Data.SqlClient.SqlParameter("@Internet", SqlDbType.Bit) With {.Value = False}
                    AllowNonClientSqlParameter = New System.Data.SqlClient.SqlParameter("@NonClient", SqlDbType.Bit) With {.Value = False}

                    VendorCategories = GetVendorCategories()

                    If Not String.IsNullOrWhiteSpace(Categories) Then

                        VendorCategories = (From Item In VendorCategories
                                            Where Categories.Split(",").ToList.Any(Function(c) c.Trim.ToUpper = Item.Code)
                                            Select Item).ToList

                    End If

                    For Each VendorCategory In VendorCategories

                        Select Case VendorCategory.Code

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Internet).Code

                                AllowInternetSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Magazine).Code

                                AllowMagazineSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Newspaper).Code

                                AllowNewspaperSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonClient).Code

                                AllowNonClientSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonMedia).Code

                                AllowNonMediaSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome).Code

                                AllowOutOfHomeSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Radio).Code

                                AllowRadioSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Television).Code

                                AllowTelevisionSqlParameter.Value = True

                        End Select

                    Next

                    Vendors = DbContext.Database.SqlQuery(Of Vendor)("exec [dbo].[advsp_api_load_vendors] @IncludeInactive, @NonMedia, @Magazine, @Newspaper, @Radio, @Television, @OutOfHome, @Internet, @NonClient", IncludeInactiveSqlParameter, AllowNonMediaSqlParameter, AllowMagazineSqlParameter, AllowNewspaperSqlParameter, AllowRadioSqlParameter, AllowTelevisionSqlParameter, AllowOutOfHomeSqlParameter, AllowInternetSqlParameter, AllowNonClientSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Vendors = New Generic.List(Of Vendor)
        End Try

        ResultAPIResponse = New VendorAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Vendors
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadVendors2 = ResultAPIResponse

    End Function
    Public Function LoadVendorsHistory(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, Categories As String, FromDate As String, ToDate As String) As List(Of VendorHist) Implements IAPIService.LoadVendorsHistory

        'objects
        Dim Vendors As Generic.List(Of VendorHist) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim VendorCategories As Generic.List(Of VendorCategory) = Nothing
        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonMediaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowMagazineSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNewspaperSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowRadioSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowTelevisionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowOutOfHomeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowInternetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim AllowNonClientSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Dim VendorFromDate As System.Data.SqlClient.SqlParameter = Nothing
        Dim VendorToDate As System.Data.SqlClient.SqlParameter = Nothing

        Vendors = New Generic.List(Of VendorHist)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeInactive", SqlDbType.Bit) With {.Value = LoadInactive}

                    AllowNonMediaSqlParameter = New System.Data.SqlClient.SqlParameter("@NonMedia", SqlDbType.Bit) With {.Value = False}
                    AllowMagazineSqlParameter = New System.Data.SqlClient.SqlParameter("@Magazine", SqlDbType.Bit) With {.Value = False}
                    AllowNewspaperSqlParameter = New System.Data.SqlClient.SqlParameter("@Newspaper", SqlDbType.Bit) With {.Value = False}
                    AllowRadioSqlParameter = New System.Data.SqlClient.SqlParameter("@Radio", SqlDbType.Bit) With {.Value = False}
                    AllowTelevisionSqlParameter = New System.Data.SqlClient.SqlParameter("@Television", SqlDbType.Bit) With {.Value = False}
                    AllowOutOfHomeSqlParameter = New System.Data.SqlClient.SqlParameter("@OutOfHome", SqlDbType.Bit) With {.Value = False}
                    AllowInternetSqlParameter = New System.Data.SqlClient.SqlParameter("@Internet", SqlDbType.Bit) With {.Value = False}
                    AllowNonClientSqlParameter = New System.Data.SqlClient.SqlParameter("@NonClient", SqlDbType.Bit) With {.Value = False}

                    VendorFromDate = New System.Data.SqlClient.SqlParameter("@FromDate", SqlDbType.VarChar)
                    VendorFromDate.Value = FromDate

                    VendorToDate = New System.Data.SqlClient.SqlParameter("@ToDate", SqlDbType.VarChar)
                    VendorToDate.Value = ToDate

                    VendorCategories = GetVendorCategories()

                    If Not String.IsNullOrWhiteSpace(Categories) Then

                        VendorCategories = (From Item In VendorCategories
                                            Where Categories.Split(",").ToList.Any(Function(c) c.Trim.ToUpper = Item.Code)
                                            Select Item).ToList

                    End If

                    For Each VendorCategory In VendorCategories

                        Select Case VendorCategory.Code

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Internet).Code

                                AllowInternetSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Magazine).Code

                                AllowMagazineSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Newspaper).Code

                                AllowNewspaperSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonClient).Code

                                AllowNonClientSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.NonMedia).Code

                                AllowNonMediaSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome).Code

                                AllowOutOfHomeSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Radio).Code

                                AllowRadioSqlParameter.Value = True

                            Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.VendorCategory.Television).Code

                                AllowTelevisionSqlParameter.Value = True

                        End Select

                    Next

                    Vendors = DbContext.Database.SqlQuery(Of VendorHist)("exec [dbo].[advsp_api_load_vendors_hist] @IncludeInactive, @NonMedia, @Magazine, @Newspaper, @Radio, @Television, @OutOfHome, @Internet, @NonClient, @FromDate, @ToDate", IncludeInactiveSqlParameter, AllowNonMediaSqlParameter, AllowMagazineSqlParameter, AllowNewspaperSqlParameter, AllowRadioSqlParameter, AllowTelevisionSqlParameter, AllowOutOfHomeSqlParameter, AllowInternetSqlParameter, AllowNonClientSqlParameter, VendorFromDate, VendorToDate).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            LoadVendorsHistory = New Generic.List(Of VendorHist)
        End Try

        LoadVendorsHistory = Vendors

    End Function
    Public Function LoadEmployees(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Employee) Implements IAPIService.LoadEmployees

        'objects
        Dim Employees As Generic.List(Of Employee) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Employees = New Generic.List(Of Employee)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Employees = DbContext.Employees.ToList

                    Else

                        Employees = DbContext.Employees.Where(Function(Entity) Entity.TerminationDate Is Nothing).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Employees = New Generic.List(Of Employee)
        End Try

        LoadEmployees = Employees

    End Function
    Public Function LoadDepartmentTeams(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of DepartmentTeam) Implements IAPIService.LoadDepartmentTeams

        'objects
        Dim DepartmentTeams As Generic.List(Of DepartmentTeam) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        DepartmentTeams = New Generic.List(Of DepartmentTeam)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        DepartmentTeams = DbContext.DepartmentTeams.ToList

                    Else

                        DepartmentTeams = DbContext.DepartmentTeams.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadDepartmentTeams = DepartmentTeams

    End Function
    Public Function LoadFunctions(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of [Function]) Implements IAPIService.LoadFunctions

        'objects
        Dim Functions As Generic.List(Of [Function]) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Functions = New Generic.List(Of [Function])

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Functions = DbContext.Functions.ToList

                    Else

                        Functions = DbContext.Functions.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadFunctions = Functions

    End Function
    Public Function LoadIndirectCategories(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of IndirectCategory) Implements IAPIService.LoadIndirectCategories

        'objects
        Dim IndirectCategories As Generic.List(Of IndirectCategory) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        IndirectCategories = New Generic.List(Of IndirectCategory)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        IndirectCategories = DbContext.IndirectCategories.ToList

                    Else

                        IndirectCategories = DbContext.IndirectCategories.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadIndirectCategories = IndirectCategories

    End Function
    Public Function LoadJobComponents(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                      LoadClosed As Boolean) As Generic.List(Of JobComponents) Implements IAPIService.LoadJobComponents

        'objects
        Dim JobComponents As Generic.List(Of JobComponents) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        JobComponents = New Generic.List(Of JobComponents)

        'Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        'Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@LoadClosed", SqlDbType.Bit) With {.Value = LoadClosed}
        'JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int) With {.Value = 0}
        'JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.Int) With {.Value = 0}

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'PJH 10/15/18 - Change to SP
                    JobComponents = DbContext.Database.SqlQuery(Of JobComponents)("exec [dbo].[advsp_job_component_get_api] @LoadClosed", IncludeInactiveSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadJobComponents = JobComponents

    End Function
    Public Function LoadJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                        JobNumber As Integer, JobComponentNumber As Integer) As Generic.List(Of JobComponents) Implements IAPIService.LoadJobComponent

        'objects
        Dim JobComponents As Generic.List(Of JobComponents) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        JobComponents = New Generic.List(Of JobComponents)

        Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@LoadClosed", SqlDbType.Bit) With {.Value = 1}
        JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int) With {.Value = JobNumber}
        JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.Int) With {.Value = JobComponentNumber}

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'PJH 10/15/18 - Change to SP
                    JobComponents = DbContext.Database.SqlQuery(Of JobComponents)("exec [dbo].[advsp_job_component_get_api] @LoadClosed, @JobNumber, @JobComponentNumber", IncludeInactiveSqlParameter, JobNumberSqlParameter, JobComponentNumberSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadJobComponent = JobComponents

    End Function
    Public Function LoadJobs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As Generic.List(Of Jobs) Implements IAPIService.LoadJobs

        'objects
        Dim Jobs As Generic.List(Of Jobs) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Jobs = New Generic.List(Of Jobs)

        IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@LoadClosed", SqlDbType.Bit) With {.Value = LoadClosed}

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'If LoadClosed Then
                    '    Jobs = DbContext.Jobs.ToList
                    'Else
                    '    Jobs = DbContext.Jobs.Where(Function(Entity) Entity.IsOpen = 1).ToList
                    'End If

                    'PJH 10/15/18 - Change to SP
                    Jobs = DbContext.Database.SqlQuery(Of Jobs)("exec [dbo].[advsp_job_log_get_api] @LoadClosed", IncludeInactiveSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadJobs = Jobs

    End Function
    Public Function LoadJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            JobNumber As Integer) As Generic.List(Of Jobs) Implements IAPIService.LoadJob

        'objects
        Dim Jobs As Generic.List(Of Jobs) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        Dim IncludeInactiveSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        IncludeInactiveSqlParameter = New System.Data.SqlClient.SqlParameter("@LoadClosed", SqlDbType.Bit) With {.Value = 1}
        JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int) With {.Value = JobNumber}

        Jobs = New Generic.List(Of Jobs)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'PJH 10/15/18 - Change to SP
                    Jobs = DbContext.Database.SqlQuery(Of Jobs)("exec [dbo].[advsp_job_log_get_api] @LoadClosed, @JobNumber", IncludeInactiveSqlParameter, JobNumberSqlParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadJob = Jobs

    End Function
    Public Function SaveEmployeeJobTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            EmployeeTimeID As Integer,
                            EmployeeTimeDetailID As Integer,
                            EmployeeCode As String,
                            [Date] As Date,
                            FunctionCode As String,
                            Hours As Decimal,
                            JobNumber As Integer,
                            JobComponentNumber As Short,
                            DepartmentTeamCode As String,
                            Comments As String,
                            TaskCode As String,
                            Optional ByVal NonBillFlag As String = "") As SaveEmployeeTimeReponse Implements IAPIService.SaveEmployeeJobTime

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SaveEmployeeTimeReponse As SaveEmployeeTimeReponse = Nothing
        Dim ErrorMessage As String = ""
        Dim FrameworkSaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse = Nothing

        Dim EmployeeTimeRecords As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex) = Nothing
        Dim EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing

        Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

        Dim Updated As Integer
        Dim NonBillFlagInt As Integer

        SaveEmployeeTimeReponse = New SaveEmployeeTimeReponse(0, 0, "", 0)

        'PJH 07/2021 - Override must be 1 or 0
        If String.IsNullOrWhiteSpace(NonBillFlag) = False Then

            If NonBillFlag <> "1" AndAlso NonBillFlag <> "0" Then

                ErrorMessage = "Invalid Non Bill Flag. Flag must be 0, 1, or blank."

            End If

        End If

        Try
            If ErrorMessage = "" Then

                If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                    Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                        If IsAPIUser(DbContext, EmployeeCode) Then

                            If EmployeeTimeID = 0 Then
                                Try
                                    Using DbContextX As New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                                        EmployeeTimeRecords = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContextX, EmployeeCode, [Date], [Date], "JOB_NUMBER", UserName).ToList

                                        EmployeeTimeRecord = EmployeeTimeRecords.FirstOrDefault(Function(Entity) Entity.EmployeeDate.GetValueOrDefault("01/01/1900").ToShortDateString = [Date].ToShortDateString)

                                    End Using
                                Catch ex As Exception
                                    EmployeeTimeRecord = Nothing
                                End Try
                            End If

                            If EmployeeTimeRecord IsNot Nothing Then

                                ErrorMessage = "Employee time record has already been entered for this date"

                            Else

                                FrameworkSaveEmployeeTimeReponse = AdvantageFramework.EmployeeTimesheet.SaveEmployeeJobTime(APISession.ConnectionString, APISession.UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], FunctionCode, Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, Comments, TaskCode, ErrorMessage)

                                SaveEmployeeTimeReponse.UpdateProperties(FrameworkSaveEmployeeTimeReponse)

                            End If

                            'FrameworkSaveEmployeeTimeReponse = AdvantageFramework.EmployeeTimesheet.SaveEmployeeJobTime(APISession.ConnectionString, APISession.UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], FunctionCode, Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, Comments, TaskCode, ErrorMessage)

                            'SaveEmployeeTimeReponse.UpdateProperties(FrameworkSaveEmployeeTimeReponse)

                        Else

                            ErrorMessage = "Employee is not a valid API user"

                        End If

                    End Using

                End If

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            SaveEmployeeTimeReponse.Message &= LTrim(RTrim(" " & ErrorMessage))
        Else
            'PJH 07/2021 - Override NB Flag
            If String.IsNullOrWhiteSpace(NonBillFlag) = False Then 'If flag is 0 or 1
                NonBillFlagInt = CInt(NonBillFlag)

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    DbTransaction = DbContext.Database.BeginTransaction

                    If NonBillFlagInt >= 1 Then

                        NonBillFlagInt = 1 'Billable

                    Else

                        NonBillFlagInt = 0 'Non-Billable

                    End If

                    Try

                        Updated = DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_DTL SET EMP_NON_BILL_FLAG = '{2}' WHERE ET_ID = '{0}' AND ET_DTL_ID = {1}", SaveEmployeeTimeReponse.EmployeeTimeID, SaveEmployeeTimeReponse.EmployeeTimeDetailID, NonBillFlagInt))

                    Catch ex As Exception
                        Updated = 0
                    End Try

                    If Updated > 0 Then

                        DbTransaction.Commit()

                        If SaveEmployeeTimeReponse.Message = "NO_CHANGE" Then

                            SaveEmployeeTimeReponse.Message = "UPDATE_NB_FLAG_COMPLETE"
                            SaveEmployeeTimeReponse.SaveSuccessful = 1
                            SaveEmployeeTimeReponse.IsNonBillable = NonBillFlagInt

                        End If

                        If (SaveEmployeeTimeReponse.Message = "UPDATE_SUCCESS" OrElse SaveEmployeeTimeReponse.Message = "INSERT_SUCCESS") And
                            String.IsNullOrWhiteSpace(NonBillFlag) = False Then

                            SaveEmployeeTimeReponse.IsNonBillable = NonBillFlagInt

                        End If

                    Else

                        DbTransaction.Rollback()
                        ErrorMessage = "Non-Bill Flag update Failed"
                        SaveEmployeeTimeReponse.Message &= LTrim(RTrim(" " & ErrorMessage))

                    End If

                End Using

            Else

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Dim SqlParameterET_ID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterET_DTL_ID As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterET_ID = New System.Data.SqlClient.SqlParameter("@et_id", SqlDbType.Int)
                    SqlParameterET_ID.Value = SaveEmployeeTimeReponse.EmployeeTimeID

                    SqlParameterET_DTL_ID = New System.Data.SqlClient.SqlParameter("@et_dtl_id", SqlDbType.Int)
                    SqlParameterET_DTL_ID.Value = SaveEmployeeTimeReponse.EmployeeTimeDetailID

                    NonBillFlagInt = DbContext.Database.SqlQuery(Of Int16)("SELECT EMP_NON_BILL_FLAG FROM dbo.EMP_TIME_DTL WHERE ET_ID = @et_id AND ET_DTL_ID = @et_dtl_id", SqlParameterET_ID, SqlParameterET_DTL_ID).FirstOrDefault
                    SaveEmployeeTimeReponse.IsNonBillable = NonBillFlagInt

                End Using

            End If

        End If

        SaveEmployeeJobTime = SaveEmployeeTimeReponse

    End Function
    Public Function SaveEmployeeNonProductionTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, EmployeeTimeID As Integer,
                                                  EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, IndirectCategoryCode As String, Hours As Decimal, DepartmentTeamCode As String, Comments As String) As SaveEmployeeTimeReponse Implements IAPIService.SaveEmployeeNonProductionTime

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SaveEmployeeTimeReponse As SaveEmployeeTimeReponse = Nothing
        Dim ErrorMessage As String = ""
        Dim FrameworkSaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse = Nothing

        SaveEmployeeTimeReponse = New SaveEmployeeTimeReponse(0, 0, "", 0)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If IsAPIUser(DbContext, EmployeeCode) Then

                        FrameworkSaveEmployeeTimeReponse = AdvantageFramework.EmployeeTimesheet.SaveEmployeeNonProductionTime(APISession.ConnectionString, APISession.UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], IndirectCategoryCode, Hours, DepartmentTeamCode, Comments, ErrorMessage)

                        SaveEmployeeTimeReponse.UpdateProperties(FrameworkSaveEmployeeTimeReponse)

                    Else

                        ErrorMessage = "Employee is not a valid API user"

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            SaveEmployeeTimeReponse.Message &= LTrim(RTrim(" " & ErrorMessage))

        End If

        SaveEmployeeNonProductionTime = SaveEmployeeTimeReponse

    End Function
    Public Function LoadUsers(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of User) Implements IAPIService.LoadUsers

        'objects
        Dim Users As Generic.List(Of User) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Users = New Generic.List(Of User)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Users = DbContext.Users.ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadUsers = Users

    End Function
    Public Function LoadEmployeeTimeRecords(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, EmployeeCode As String, StartDate As Date, EndDate As Date) As List(Of EmployeeTimeRecord) Implements IAPIService.LoadEmployeeTimeRecords

        'objects
        Dim EmployeeTimeRecords As Generic.List(Of EmployeeTimeRecord) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        EmployeeTimeRecords = New Generic.List(Of EmployeeTimeRecord)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    EmployeeTimeRecords = DbContext.LoadEmployeeTime(EmployeeCode, StartDate, EndDate, "JOB_NUMBER", APISession.UserCode).Select(Function(Entity) New EmployeeTimeRecord(Entity)).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadEmployeeTimeRecords = EmployeeTimeRecords

    End Function
    Private Function LoginToAPI(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                ByRef APISession As AdvantageFramework.Security.APISession, ByRef ErrorMessage As String) As Boolean

        'objects
        Dim LoginSuccessful As Boolean = False
        Dim ConnectionString As String = ""
        Dim DbContext As AdvantageAPI.APIDbContext = Nothing
        Dim User As AdvantageAPI.User = Nothing
        Dim Employee As AdvantageAPI.Employee = Nothing
        Dim FullUserName As String = ""
        Dim AgencyLicenseKey As String = ""
        Dim APIUsersQuantity As Integer = 0
        Dim SingleSignOnUserName As String = String.Empty
        Dim SingleSignOnPassword As String = String.Empty
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

        APISession = Nothing
        _AdvSession = Nothing 'Global to the API

        ErrorMessage = ""

        ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfiles

        If ConnectionDatabaseProfiles IsNot Nothing AndAlso ConnectionDatabaseProfiles.Count > 0 Then

            For Each ConnectionDatabaseProfile In ConnectionDatabaseProfiles

                If ConnectionDatabaseProfile.DatabaseName = DatabaseName Then

                    SingleSignOnUserName = ConnectionDatabaseProfile.UserName
                    SingleSignOnPassword = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)
                    Exit For

                End If

            Next

        End If

        If AdvantageFramework.Database.ValidateServerAndDatabase(ServerName, DatabaseName, UseWindowsAuthentication, SingleSignOnUserName, SingleSignOnPassword, "Advantage API", True, ErrorMessage) Then

            ConnectionString = AdvantageFramework.Database.CreateConnectionString(ServerName, DatabaseName, UseWindowsAuthentication, SingleSignOnUserName, SingleSignOnPassword, "Advantage API")

            If AdvantageFramework.Database.TestConnectionString(ConnectionString, ErrorMessage) Then

                FullUserName = UserName

                If UseWindowsAuthentication Then

                    If UserName.Contains("\") Then

                        UserName = UserName.Substring(UserName.IndexOf("\") + 1)

                    End If

                End If

                Try

                    DbContext = New AdvantageAPI.APIDbContext(ConnectionString, UserName)

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    DbContext = Nothing
                End Try

                If DbContext IsNot Nothing Then

                    Try

                        User = DbContext.Users.SingleOrDefault(Function(Entity) Entity.UserCode.ToUpper = UserName.ToUpper)

                    Catch ex As Exception
                        User = Nothing
                    End Try

                    If User IsNot Nothing AndAlso String.IsNullOrWhiteSpace(User.Password) = False AndAlso AdvantageFramework.Security.Encryption.EncryptPassword(Password) = User.Password Then

                        Try

                            Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code.ToUpper = User.EmployeeCode.ToUpper)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                        If Employee IsNot Nothing Then

                            AgencyLicenseKey = LoadLicenseKey(DbContext)

                            If AgencyLicenseKey <> "" Then

                                Read(AgencyLicenseKey, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, APIUsersQuantity)

                                If APIUsersQuantity <> 0 Then

                                    If IsAPIUser(Employee.Code, Employee.IsAPIUser) Then

                                        APISession = New AdvantageFramework.Security.APISession(ServerName, DatabaseName, UseWindowsAuthentication, FullUserName, Password, User.UserCode, User.EmployeeCode, ConnectionString)
                                        LoginSuccessful = True

                                        _AdvSession = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, ConnectionString, User.UserCode, 0, ConnectionString)

                                    Else

                                        ErrorMessage = "Employee is not a valid API user"

                                    End If

                                Else

                                    ErrorMessage = "No API licenses in current license key"

                                End If

                            Else

                                ErrorMessage = "Could not load license key data"

                            End If

                        Else

                            ErrorMessage = "Employee not found - Access denied"

                        End If

                    Else

                        ErrorMessage = "User not found - Access denied"

                    End If

                    Try

                        If DbContext IsNot Nothing Then

                            DbContext.Dispose()
                            DbContext = Nothing

                        End If

                    Catch ex As Exception

                    End Try

                Else

                    ErrorMessage = "Please verify that you are connecting to the correct server and database and that your login username and password is correct."

                End If

            End If

        End If

        Try

            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                'ProcessException(New Exception(ErrorMessage), "LoginToAPI")
                Throw New System.Exception(ErrorMessage)

            End If

        Catch ex As Exception
            ProcessException(ex, "LoginToAPI")
        End Try

        LoginToAPI = LoginSuccessful

    End Function
    Private Function IsAPIUser(DbContext As APIDbContext, EmployeeCode As String) As Boolean

        'objects
        Dim IsAAPIUser As Boolean = False
        Dim Employee As Employee = Nothing

        Try

            Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code.ToUpper = EmployeeCode.ToUpper)

        Catch ex As Exception
            Employee = Nothing
        End Try

        If Employee IsNot Nothing Then

            IsAAPIUser = IsAPIUser(Employee.Code, Employee.IsAPIUser)

        End If

        IsAPIUser = IsAAPIUser

    End Function
    Private Function LoadLicenseKey(DbContext As APIDbContext) As String

        Try

            LoadLicenseKey = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(LICENSE_KEY, '') FROM dbo.AGENCY").FirstOrDefault

        Catch ex As Exception
            LoadLicenseKey = ""
            ProcessException(ex, "APIService-NotCaught")
        End Try

    End Function
    Private Function LoadImportedDataToUpdate(CurrentValue As String, NewValue As String) As String

        'objects
        Dim NewImportedValue As String = Nothing

        If String.IsNullOrEmpty(NewValue) = False Then

            If NewValue = "*" Then

                NewImportedValue = Nothing

            Else

                NewImportedValue = NewValue

            End If

        Else

            If String.IsNullOrEmpty(CurrentValue) = False Then
                NewImportedValue = CurrentValue
            Else
                NewImportedValue = Nothing
            End If

        End If

        LoadImportedDataToUpdate = NewImportedValue

    End Function
    Private Function Read(EncryptedLicenseKey As String, ByRef LicenseKeyDate As Date, ByRef DaysUntilFileExpires As Integer, ByRef DaysUntilKeyExpires As Integer,
                          ByRef PowerUsersQuantity As Integer, ByRef WVOnlyUsersQuantity As Integer, ByRef ClientPortalUsersQuantity As Integer, ByRef AgencyName As String,
                          ByRef DatabaseID As Integer, ByRef MediaToolsUsersQuantity As Integer, ByRef APIUsersQuantity As Integer) As String

        'objects
        Dim LicenseKey As String = ""

        Try

            LicenseKey = AdvantageFramework.Security.Encryption.DecryptLicenseKey(EncryptedLicenseKey)

            LicenseKeyDate = CDate(AdvantageFramework.DateUtilities.ConvertStringToShortDateString(LicenseKey.Substring(2, 4) & "20" & LicenseKey.Substring(0, 2), AdvantageFramework.DateUtilities.DateFormat.MDY.ToString))
            DaysUntilFileExpires = CInt(LicenseKey.Substring(6, 4))
            DaysUntilKeyExpires = CInt(LicenseKey.Substring(10, 4))

            Try

                If IsNumeric(LicenseKey.Substring(14, 5)) Then

                    PowerUsersQuantity = CInt(LicenseKey.Substring(14, 5))

                Else

                    PowerUsersQuantity = -1

                End If

            Catch ex As Exception
                PowerUsersQuantity = -1
            End Try

            Try

                If IsNumeric(LicenseKey.Substring(19, 5)) Then

                    WVOnlyUsersQuantity = CInt(LicenseKey.Substring(19, 5))

                Else

                    WVOnlyUsersQuantity = -1

                End If

            Catch ex As Exception
                WVOnlyUsersQuantity = -1
            End Try

            Try

                If IsNumeric(LicenseKey.Substring(24, 5)) Then

                    ClientPortalUsersQuantity = CInt(LicenseKey.Substring(24, 5))

                Else

                    ClientPortalUsersQuantity = -1

                End If

            Catch ex As Exception
                ClientPortalUsersQuantity = -1
            End Try

            AgencyName = LicenseKey.Substring(29, 40).Replace(",amp,", "&")

            If LicenseKey.Length > 69 Then

                Try

                    If IsNumeric(LicenseKey.Substring(69, 4)) Then

                        DatabaseID = CInt(LicenseKey.Substring(69, 4))

                    Else

                        DatabaseID = 0

                    End If

                Catch ex As Exception
                    DatabaseID = 0
                End Try

                If LicenseKey.Length > 73 Then

                    Try

                        If IsNumeric(LicenseKey.Substring(73, 5)) Then

                            MediaToolsUsersQuantity = CInt(LicenseKey.Substring(73, 5))

                        Else

                            MediaToolsUsersQuantity = -1

                        End If

                    Catch ex As Exception
                        MediaToolsUsersQuantity = -1
                    End Try

                End If

                If LicenseKey.Length > 78 Then

                    Try

                        If IsNumeric(LicenseKey.Substring(78, 5)) Then

                            APIUsersQuantity = CInt(LicenseKey.Substring(78, 5))

                        Else

                            APIUsersQuantity = -1

                        End If

                    Catch ex As Exception
                        APIUsersQuantity = -1
                    End Try

                End If

            End If

        Catch ex As Exception
            LicenseKey = ""
            ProcessException(ex, "APIService-NotCaught")
        Finally
            Read = LicenseKey
        End Try

    End Function
    'Private Function Decrypt(EncryptedText As String) As String

    '    'objects
    '    Dim CipherBytes() As Byte = Nothing
    '    Dim DecryptedBytes() As Byte = Nothing
    '    Dim DecryptedText As String = ""
    '    Dim Rfc2898DeriveBytes As System.Security.Cryptography.Rfc2898DeriveBytes = Nothing
    '    Dim DB32Bytes As Byte() = Nothing
    '    Dim DB16Bytes As Byte() = Nothing


    '    Try

    '        EncryptedText = EncryptedText.Replace(" ", "+")

    '        CipherBytes = Convert.FromBase64String(EncryptedText)

    '        If Rfc2898DeriveBytes Is Nothing Then

    '            Rfc2898DeriveBytes = New System.Security.Cryptography.Rfc2898DeriveBytes("JustinBieber", New Byte() {&H45, &HF1, &H61, &H6E, &H20, &H0, &H65, &H64, &H76, &H65, &H64, &H3, &H76})
    '            DB32Bytes = Rfc2898DeriveBytes.GetBytes(32)
    '            DB16Bytes = Rfc2898DeriveBytes.GetBytes(16)

    '        End If

    '        DecryptedBytes = Decrypt(CipherBytes, DB32Bytes, DB16Bytes)

    '        DecryptedText = System.Text.Encoding.Unicode.GetString(DecryptedBytes)

    '    Catch ex As Exception
    '        DecryptedText = EncryptedText
    '        ProcessException(ex, "APIService-NotCaught")
    '    Finally
    '        Decrypt = DecryptedText
    '    End Try

    'End Function
    'Private Function Decrypt(CipherBytes() As Byte, KeyBytes() As Byte, IVBytes() As Byte) As Byte()

    '    'objects
    '    Dim MemoryStream As System.IO.MemoryStream = Nothing
    '    Dim CryptoStream As System.Security.Cryptography.CryptoStream = Nothing
    '    Dim Rijndael As System.Security.Cryptography.Rijndael = Nothing
    '    Dim DecryptedBytes() As Byte = Nothing

    '    Try

    '        MemoryStream = New System.IO.MemoryStream

    '        Rijndael = System.Security.Cryptography.Rijndael.Create

    '        Rijndael.Key = KeyBytes
    '        Rijndael.IV = IVBytes

    '        CryptoStream = New System.Security.Cryptography.CryptoStream(MemoryStream, Rijndael.CreateDecryptor, System.Security.Cryptography.CryptoStreamMode.Write)

    '        CryptoStream.Write(CipherBytes, 0, CipherBytes.Length)
    '        CryptoStream.FlushFinalBlock()

    '        DecryptedBytes = MemoryStream.ToArray

    '    Catch ex As Exception
    '        DecryptedBytes = Nothing
    '        ProcessException(ex, "APIService-NotCaught")
    '    Finally

    '        If CryptoStream IsNot Nothing Then

    '            CryptoStream.Close()

    '        End If

    '        Decrypt = DecryptedBytes

    '    End Try

    'End Function
    Private Function IsAPIUser(EmployeeCode As String, StringValue As String) As Boolean

        'objects
        Dim IsAAPIUser As Boolean = False

        If String.IsNullOrEmpty(StringValue) = False AndAlso AdvantageFramework.Security.Encryption.Decrypt(StringValue) = EmployeeCode Then

            IsAAPIUser = True

        End If

        IsAPIUser = IsAAPIUser

    End Function
    Private Function ConvertEmptyToNothing(CurrentValue As String) As String

        'objects
        Dim NewImportedValue As String = Nothing

        If String.IsNullOrEmpty(CurrentValue) = True Then

            NewImportedValue = Nothing

        Else

            NewImportedValue = CurrentValue

        End If

        ConvertEmptyToNothing = NewImportedValue

    End Function
    Public Function LoadTasks(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As List(Of Task) Implements IAPIService.LoadTasks

        'objects
        Dim Tasks As Generic.List(Of Task) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Tasks = New Generic.List(Of Task)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        Tasks = DbContext.Tasks.ToList

                    Else

                        Tasks = DbContext.Tasks.Where(Function(Entity) Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Tasks = New Generic.List(Of Task)
        End Try

        LoadTasks = Tasks

    End Function
    Public Function SaveTask(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, TaskCode As String, Description As String, IsInactive As Short) As Boolean Implements IAPIService.SaveTask

        'objects
        Dim Saved As Boolean = False
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim Task As Task = Nothing

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Try

                        Task = DbContext.Tasks.ToList.SingleOrDefault(Function(Entity) Entity.Code.ToUpper = TaskCode.ToUpper)

                    Catch ex As Exception
                        Task = Nothing
                    End Try

                    If Task IsNot Nothing Then

                        Task.Description = Description

                        If IsInactive = 1 Then

                            Task.IsInactive = 1

                        Else

                            Task.IsInactive = Nothing

                        End If

                        Saved = (DbContext.SaveChanges() > 0)

                    Else

                        Task = New Task

                        Task.Code = TaskCode
                        Task.Description = Description

                        If IsInactive = 1 Then

                            Task.IsInactive = 1

                        Else

                            Task.IsInactive = Nothing

                        End If

                        DbContext.Tasks.Add(Task)

                        Saved = (DbContext.SaveChanges() > 0)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Saved = False
        End Try

        SaveTask = Saved

    End Function
    Private Function GetVendorCategories() As Generic.List(Of VendorCategory)

        'objects
        Dim VendorCategories As Generic.List(Of VendorCategory) = Nothing

        VendorCategories = New Generic.List(Of VendorCategory)

        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.NonMedia))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.Magazine))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.Newspaper))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.Radio))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.Television))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.Internet))
        VendorCategories.Add(New VendorCategory(AdvantageFramework.Database.Entities.VendorCategory.NonClient))

        GetVendorCategories = VendorCategories

    End Function

    Public Function UpdateMatCompDate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, MatCompDate As String) As MatCompDateResponse Implements IAPIService.UpdateMatCompDate

        'objects
        Dim MatCompDateResponse As MatCompDateResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterMatCompDate As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterOrderNumberValidate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterLineNumberValidate As System.Data.SqlClient.SqlParameter = Nothing

        Dim OrderNbr As Integer = 0
        'Dim LineNbr As Int16 = 0

        MatCompDateResponse = New MatCompDateResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'SqlParameterMediaType = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
                    'SqlParameterMediaType.Value = MediaType

                    If IsDate(MatCompDate) = False Then

                        ErrorMessage = "Invalid Date"

                    End If

                    SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.VarChar)
                    SqlParameterOrderNumber.Value = OrderNumber

                    SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.SmallInt)
                    SqlParameterLineNumber.Value = LineNumber

                    SqlParameterMatCompDate = New System.Data.SqlClient.SqlParameter("@mat_comp", SqlDbType.VarChar)
                    SqlParameterMatCompDate.Value = MatCompDate

                    'Validation Vars
                    SqlParameterOrderNumberValidate = New System.Data.SqlClient.SqlParameter("@order_nbr2", SqlDbType.Int)
                    SqlParameterOrderNumberValidate.Value = OrderNumber

                    SqlParameterLineNumberValidate = New System.Data.SqlClient.SqlParameter("@line_nbr2", SqlDbType.SmallInt)
                    SqlParameterLineNumberValidate.Value = LineNumber

                    MediaType = UCase(Left(MediaType, 1))

                    Dim SearchWithinThis As String = "I,N,M,O,T,R"
                    Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(MediaType)

                    If FirstCharacter = -1 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = "Invalid Media Type - Must be I,N,M,O,T, or R."

                        OrderNbr = -1

                    Else

                        If MediaType = "I" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "N" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "M" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "O" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "T" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.TV_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "R" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        End If

                    End If

                    If OrderNbr = 0 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso OrderNbr > 0 Then

                        If MediaType = "I" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE INTERNET_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "N" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE NEWSPAPER_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "M" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE MAGAZINE_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "O" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE OUTDOOR_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "T" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE TV_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "R" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE RADIO_DETAIL SET MAT_COMP = @mat_comp WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND ACTIVE_REV = 1",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            MatCompDateResponse.IsSuccessful = True
            MatCompDateResponse.Message = Nothing 'LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

        Else

            MatCompDateResponse.IsSuccessful = False
            MatCompDateResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        UpdateMatCompDate = MatCompDateResponse
    End Function

    Public Function UpdateMaterialNotes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, MaterialNotes As String) As BasicResponse Implements IAPIService.UpdateMaterialNotes

        'objects
        Dim BasicResponse As BasicResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterMatCompDate As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterOrderNumberValidate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterLineNumberValidate As System.Data.SqlClient.SqlParameter = Nothing

        Dim OrderNbr As Integer = 0
        'Dim LineNbr As Int16 = 0

        BasicResponse = New BasicResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    'SqlParameterMediaType = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
                    'SqlParameterMediaType.Value = MediaType

                    If (MaterialNotes) = Nothing Then

                        ErrorMessage = "Invalid Note"

                    End If

                    SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.VarChar)
                    SqlParameterOrderNumber.Value = OrderNumber

                    SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.SmallInt)
                    SqlParameterLineNumber.Value = LineNumber

                    SqlParameterMatCompDate = New System.Data.SqlClient.SqlParameter("@matl_notes", SqlDbType.VarChar)
                    SqlParameterMatCompDate.Value = MaterialNotes

                    'Validation Vars
                    SqlParameterOrderNumberValidate = New System.Data.SqlClient.SqlParameter("@order_nbr2", SqlDbType.Int)
                    SqlParameterOrderNumberValidate.Value = OrderNumber

                    SqlParameterLineNumberValidate = New System.Data.SqlClient.SqlParameter("@line_nbr2", SqlDbType.SmallInt)
                    SqlParameterLineNumberValidate.Value = LineNumber

                    MediaType = UCase(Left(MediaType, 1))

                    Dim SearchWithinThis As String = "I,N,M,O,T,R"
                    Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(MediaType)

                    If FirstCharacter = -1 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = "Invalid Media Type - Must be I,N,M,O,T, or R."

                    Else

                        If MediaType = "I" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.INTERNET_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "N" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.NEWSPAPER_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "M" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.MAGAZINE_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "O" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.OUTDOOR_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "T" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.TV_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        ElseIf MediaType = "R" Then
                            OrderNbr = DbContext.Database.SqlQuery(Of Integer)("SELECT ORDER_NBR FROM dbo.RADIO_DETAIL WHERE ORDER_NBR = @order_nbr2 AND LINE_NBR = @line_nbr2", SqlParameterOrderNumberValidate, SqlParameterLineNumberValidate).FirstOrDefault
                        End If

                    End If

                    If OrderNbr = 0 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                    End If

                    If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso OrderNbr > 0 Then

                        If MediaType = "I" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE INTERNET_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "N" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE NEWSPAPER_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END  WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "M" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE MAGAZINE_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END  WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "O" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE OUTDOOR_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END  WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "T" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE TV_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END  WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        ElseIf MediaType = "R" Then
                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "UPDATE RADIO_COMMENTS SET MATL_NOTES = CASE WHEN MATL_NOTES IS NULL THEN @matl_notes ELSE (CONCAT(MATL_NOTES, ' - ' , @matl_notes)) END  WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr",
                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMatCompDate)
                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            BasicResponse.IsSuccessful = True
            BasicResponse.Message = Nothing 'LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

        Else

            BasicResponse.IsSuccessful = False
            BasicResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        UpdateMaterialNotes = BasicResponse
    End Function

    Public Function UpdateMediaOrderStatus(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, Status As Int16) As BasicResponse Implements IAPIService.UpdateMediaOrderStatus

        'objects
        Dim BasicResponse As BasicResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim InternetOrderDetail As AdvantageFramework.Database.Entities.InternetOrderDetail = Nothing
        Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing

        Dim NewspaperOrderDetail As AdvantageFramework.Database.Entities.NewspaperOrderDetail = Nothing
        Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing

        Dim MagazineOrderDetail As AdvantageFramework.Database.Entities.MagazineOrderDetail = Nothing
        Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing

        Dim OutOfHomeOrderDetail As AdvantageFramework.Database.Entities.OutOfHomeOrderDetail = Nothing
        Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing

        Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
        Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing

        Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
        Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing

        Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterRevisionNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterRevisedByUserCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterRevisedByName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterRevisedDate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOrderStatusID As System.Data.SqlClient.SqlParameter = Nothing

        Dim Employees As Generic.List(Of Employee) = Nothing

        Dim Users As Generic.List(Of User) = Nothing
        Dim User As User = Nothing

        Dim OrderNbr As Integer = 0
        Dim ValidStatus As String = "6,7"

        Dim SearchWithinThis As String = "I,N,M,O,T,R"
        Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(MediaType)

        Dim FullName As String

        BasicResponse = New BasicResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Users = DbContext.Users.Where(Function(Entity) Entity.UserCode = UserName).ToList

                    FullName = Users(0).EmployeeCode

                    Employees = DbContext.Employees.Where(Function(Entity) Entity.Code = FullName).ToList

                    If Not String.IsNullOrWhiteSpace(Employees(0).MiddleInitial) Then

                        FullName = " " + Employees(0).MiddleInitial + ". "

                    Else

                        FullName = " "

                    End If

                    FullName = Employees(0).FirstName + FullName + Employees(0).LastName

                    If ValidStatus.IndexOf(Status) = -1 Then

                        ErrorMessage = "Invalid Status - Status must be 6 or 7."

                    End If

                    MediaType = UCase(Left(MediaType, 1))

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        If FirstCharacter = -1 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = "Invalid Media Type - Must be I,N,M,O,T, or R."

                        Else

                            Using AdvanDbContext As New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                                'Used for updates if the status exists for the given order/line/rev
                                SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.VarChar)
                                SqlParameterOrderNumber.Value = OrderNumber

                                SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.SmallInt)
                                SqlParameterLineNumber.Value = LineNumber

                                SqlParameterOrderStatusID = New System.Data.SqlClient.SqlParameter("@status", SqlDbType.SmallInt)
                                SqlParameterOrderStatusID.Value = Status

                                SqlParameterRevisedByUserCode = New System.Data.SqlClient.SqlParameter("@revised_by", SqlDbType.VarChar)
                                SqlParameterRevisedByUserCode.Value = UserName

                                SqlParameterRevisedByName = New System.Data.SqlClient.SqlParameter("@revised_by_name", SqlDbType.VarChar)
                                SqlParameterRevisedByName.Value = FullName

                                SqlParameterRevisedDate = New System.Data.SqlClient.SqlParameter("@revised_date", SqlDbType.VarChar)
                                SqlParameterRevisedDate.Value = Now()

                                If MediaType = "I" Then
                                    InternetOrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadActiveByOrderNumberLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If InternetOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, InternetOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

                                            InternetOrderStatus.DbContext = AdvanDbContext

                                            InternetOrderStatus.OrderNumber = OrderNumber
                                            InternetOrderStatus.LineNumber = LineNumber
                                            InternetOrderStatus.RevisionNumber = InternetOrderDetail.RevisionNumber
                                            InternetOrderStatus.OrderStatusID = Status
                                            InternetOrderStatus.RevisedByUserCode = UserName
                                            InternetOrderStatus.RevisedByName = FullName
                                            InternetOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.InternetOrderStatus.Insert(AdvanDbContext, InternetOrderStatus)

                                            'AdvanDbContext.InternetOrderStatuses.

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = InternetOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE INTERNET_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)


                                            'If (ErrorMessage > "") Then
                                            '    ErrorMessage = ErrorMessage + ", "
                                            'End If

                                            'ErrorMessage = ErrorMessage + "Materials Delivery status has already been set."

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If
                                ElseIf MediaType = "N" Then

                                    NewspaperOrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadActiveRevisionByOrderNumberAndLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If NewspaperOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, NewspaperOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus

                                            NewspaperOrderStatus.DbContext = AdvanDbContext

                                            NewspaperOrderStatus.OrderNumber = OrderNumber
                                            NewspaperOrderStatus.LineNumber = LineNumber
                                            NewspaperOrderStatus.RevisionNumber = NewspaperOrderDetail.RevisionNumber
                                            NewspaperOrderStatus.OrderStatusID = Status
                                            NewspaperOrderStatus.RevisedByUserCode = UserName
                                            NewspaperOrderStatus.RevisedByName = FullName
                                            NewspaperOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Insert(AdvanDbContext, NewspaperOrderStatus)

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = NewspaperOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE NEWSPAPER_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If

                                ElseIf MediaType = "M" Then

                                    MagazineOrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadActiveByOrderNumberLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If MagazineOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, MagazineOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus

                                            MagazineOrderStatus.DbContext = AdvanDbContext

                                            MagazineOrderStatus.OrderNumber = OrderNumber
                                            MagazineOrderStatus.LineNumber = LineNumber
                                            MagazineOrderStatus.RevisionNumber = MagazineOrderDetail.RevisionNumber
                                            MagazineOrderStatus.OrderStatusID = Status
                                            MagazineOrderStatus.RevisedByUserCode = UserName
                                            MagazineOrderStatus.RevisedByName = FullName
                                            MagazineOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.MagazineOrderStatus.Insert(AdvanDbContext, MagazineOrderStatus)

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = MagazineOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE MAGAZINE_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If

                                ElseIf MediaType = "O" Then

                                    OutOfHomeOrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadActiveByOrderNumberLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If OutOfHomeOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, OutOfHomeOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus

                                            OutOfHomeOrderStatus.DbContext = AdvanDbContext

                                            OutOfHomeOrderStatus.OrderNumber = OrderNumber
                                            OutOfHomeOrderStatus.LineNumber = LineNumber
                                            OutOfHomeOrderStatus.RevisionNumber = OutOfHomeOrderDetail.RevisionNumber
                                            OutOfHomeOrderStatus.OrderStatusID = Status
                                            OutOfHomeOrderStatus.RevisedByUserCode = UserName
                                            OutOfHomeOrderStatus.RevisedByName = FullName
                                            OutOfHomeOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Insert(AdvanDbContext, OutOfHomeOrderStatus)

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = OutOfHomeOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE OUTDOOR_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If

                                ElseIf MediaType = "T" Then

                                    TVOrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumberLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If TVOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, TVOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus

                                            TVOrderStatus.DbContext = AdvanDbContext

                                            TVOrderStatus.OrderNumber = OrderNumber
                                            TVOrderStatus.LineNumber = LineNumber
                                            TVOrderStatus.RevisionNumber = TVOrderDetail.RevisionNumber
                                            TVOrderStatus.OrderStatusID = Status
                                            TVOrderStatus.RevisedByUserCode = UserName
                                            TVOrderStatus.RevisedByName = FullName
                                            TVOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.TVOrderStatus.Insert(AdvanDbContext, TVOrderStatus)

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = TVOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE TV_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If

                                ElseIf MediaType = "R" Then

                                    RadioOrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumberLineNumber(AdvanDbContext, OrderNumber, LineNumber)

                                    If RadioOrderDetail IsNot Nothing Then

                                        If (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumberRevision(AdvanDbContext, OrderNumber, LineNumber, RadioOrderDetail.RevisionNumber)
                                            Where (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialsDelivered AndAlso Status = 6) OrElse
                                                  (Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.MaterialDeliveryVerified AndAlso Status = 7)
                                            Select Entity).Any = False Then

                                            RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus

                                            RadioOrderStatus.DbContext = AdvanDbContext

                                            RadioOrderStatus.OrderNumber = OrderNumber
                                            RadioOrderStatus.LineNumber = LineNumber
                                            RadioOrderStatus.RevisionNumber = RadioOrderDetail.RevisionNumber
                                            RadioOrderStatus.OrderStatusID = Status
                                            RadioOrderStatus.RevisedByUserCode = UserName
                                            RadioOrderStatus.RevisedByName = FullName
                                            RadioOrderStatus.RevisedDate = Now()

                                            AdvantageFramework.Database.Procedures.RadioOrderStatus.Insert(AdvanDbContext, RadioOrderStatus)

                                        Else

                                            SqlParameterRevisionNumber = New System.Data.SqlClient.SqlParameter("@rev_nbr", SqlDbType.SmallInt)
                                            SqlParameterRevisionNumber.Value = RadioOrderDetail.RevisionNumber

                                            DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                            UPDATE RADIO_ORDER_STATUS SET REVISED_DATE = @revised_date, REVISED_BY = @revised_by, REVISED_BY_NAME = @revised_by_name
                                            WHERE ORDER_NBR = @order_nbr AND LINE_NBR = @line_nbr AND REV_NBR = @rev_nbr AND STATUS = @status",
                                            SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRevisionNumber,
                                            SqlParameterOrderStatusID, SqlParameterRevisedByUserCode, SqlParameterRevisedByName, SqlParameterRevisedDate)

                                        End If

                                    Else

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Order or Line Number"

                                    End If

                                End If

                            End Using

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) Then

            BasicResponse.IsSuccessful = True
            BasicResponse.Message = Nothing 'LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

        Else

            BasicResponse.IsSuccessful = False
            BasicResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        UpdateMediaOrderStatus = BasicResponse

    End Function

    Public Function AddClientDivisionProduct(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                    ClientCode As String, ClientName As String, DivisionCode As String, DivisionName As String, ProductCode As String, ProductDescription As String,
                    OfficeCode As String, UserDefined1 As String, UserDefined2 As String, UserDefined3 As String, UserDefined4 As String,
                    ClientAddress1 As String, ClientAddress2 As String, ClientCity As String, ClientCounty As String, ClientState As String,
                    ClientCountry As String, ClientZip As String, ClientType1 As String, ClientType2 As String, ClientType3 As String) As AddClientDivisionProductResponse Implements IAPIService.AddClientDivisionProduct

        'objects
        Dim AddClientDivisionProductResponse As AddClientDivisionProductResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterUserDefined1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined3 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined4 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSalesClassCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientAddress1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientAddress2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCity As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCounty As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientState As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCountry As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientZip As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientType1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientType2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientType3 As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        AddClientDivisionProductResponse = New AddClientDivisionProductResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterClientCode.Value = ClientCode
                    SqlParameterClientName = New System.Data.SqlClient.SqlParameter("@cl_name", SqlDbType.VarChar)
                    SqlParameterClientName.Value = ClientName

                    SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterDivisionCode.Value = DivisionCode
                    SqlParameterDivisionName = New System.Data.SqlClient.SqlParameter("@div_name", SqlDbType.VarChar)
                    SqlParameterDivisionName.Value = DivisionName

                    SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterProductCode.Value = ProductCode
                    SqlParameterProductDescription = New System.Data.SqlClient.SqlParameter("@prd_description", SqlDbType.VarChar)
                    SqlParameterProductDescription.Value = ProductDescription

                    SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
                    SqlParameterOfficeCode.Value = OfficeCode

                    SqlParameterUserDefined1 = New System.Data.SqlClient.SqlParameter("@user_defined_1", SqlDbType.VarChar)
                    SqlParameterUserDefined1.Value = UserDefined1
                    SqlParameterUserDefined2 = New System.Data.SqlClient.SqlParameter("@user_defined_2", SqlDbType.VarChar)
                    SqlParameterUserDefined2.Value = UserDefined2
                    SqlParameterUserDefined3 = New System.Data.SqlClient.SqlParameter("@user_defined_3", SqlDbType.VarChar)
                    SqlParameterUserDefined3.Value = UserDefined3
                    SqlParameterUserDefined4 = New System.Data.SqlClient.SqlParameter("@user_defined_4", SqlDbType.VarChar)
                    SqlParameterUserDefined4.Value = UserDefined4

                    SqlParameterClientAddress1 = New System.Data.SqlClient.SqlParameter("@cl_address1", SqlDbType.VarChar)
                    SqlParameterClientAddress1.Value = ClientAddress1
                    SqlParameterClientAddress2 = New System.Data.SqlClient.SqlParameter("@cl_address2", SqlDbType.VarChar)
                    SqlParameterClientAddress2.Value = ClientAddress2
                    SqlParameterClientCity = New System.Data.SqlClient.SqlParameter("@cl_city", SqlDbType.VarChar)
                    SqlParameterClientCity.Value = ClientCity
                    SqlParameterClientCounty = New System.Data.SqlClient.SqlParameter("@cl_county", SqlDbType.VarChar)
                    SqlParameterClientCounty.Value = ClientCounty
                    SqlParameterClientState = New System.Data.SqlClient.SqlParameter("@cl_state", SqlDbType.VarChar)
                    SqlParameterClientState.Value = ClientState
                    SqlParameterClientCountry = New System.Data.SqlClient.SqlParameter("@cl_country", SqlDbType.VarChar)
                    SqlParameterClientCountry.Value = ClientCountry
                    SqlParameterClientZip = New System.Data.SqlClient.SqlParameter("@cl_zip", SqlDbType.VarChar)
                    SqlParameterClientZip.Value = ClientZip

                    SqlParameterClientType1 = New System.Data.SqlClient.SqlParameter("@cl_type_1", SqlDbType.VarChar)
                    SqlParameterClientType1.Value = ClientType1
                    SqlParameterClientType2 = New System.Data.SqlClient.SqlParameter("@cl_type_2", SqlDbType.VarChar)
                    SqlParameterClientType2.Value = ClientType2
                    SqlParameterClientType3 = New System.Data.SqlClient.SqlParameter("@cl_type_3", SqlDbType.VarChar)
                    SqlParameterClientType3.Value = ClientType3

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_cli_div_prd_add_api @user_id,@action,@cl_code,@cl_name,@div_code,@div_name,@prd_code,@prd_description,@office_code,@user_defined_1,@user_defined_2,@user_defined_3,@user_defined_4,@cl_address1,@cl_address2,@cl_city,@cl_county,@cl_state,@cl_country,@cl_zip,@cl_type_1,@cl_type_2,@cl_type_3,@ret_val OUTPUT,@ret_val_s OUTPUT",
                            SqlParameterUserID, SqlParameterAction, SqlParameterClientCode, SqlParameterClientName, SqlParameterDivisionCode, SqlParameterDivisionName, SqlParameterProductCode, SqlParameterProductDescription,
                            SqlParameterOfficeCode, SqlParameterUserDefined1, SqlParameterUserDefined2, SqlParameterUserDefined3, SqlParameterUserDefined4,
                            SqlParameterClientAddress1, SqlParameterClientAddress2, SqlParameterClientCity, SqlParameterClientCounty, SqlParameterClientState, SqlParameterClientCountry, SqlParameterClientZip,
                            SqlParameterClientType1, SqlParameterClientType2, SqlParameterClientType3, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                AddClientDivisionProductResponse.IsSuccessful = False
                AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddClientDivisionProductResponse.IsSuccessful = True
                AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddClientDivisionProductResponse.ClientCode = SqlParameterClientCode.Value
                AddClientDivisionProductResponse.DivisionCode = SqlParameterDivisionCode.Value
                AddClientDivisionProductResponse.ProductCode = SqlParameterProductCode.Value

            End If

        Else

            AddClientDivisionProductResponse.IsSuccessful = False
            AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddClientDivisionProduct = AddClientDivisionProductResponse
    End Function

    Public Function UpdateClientDivisionProduct(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                 ClientCode As String, ClientName As String, DivisionCode As String, DivisionName As String, ProductCode As String, ProductDescription As String,
                 OfficeCode As String, UserDefined1 As String, UserDefined2 As String, UserDefined3 As String, UserDefined4 As String,
                 ClientAddress1 As String, ClientAddress2 As String, ClientCity As String, ClientCounty As String, ClientState As String,
                 ClientCountry As String, ClientZip As String, ClientType1 As String, ClientType2 As String, ClientType3 As String) As AddClientDivisionProductResponse Implements IAPIService.UpdateClientDivisionProduct

        'objects
        Dim AddClientDivisionProductResponse As AddClientDivisionProductResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterOfficeCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterUserDefined1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined3 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUserDefined4 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSalesClassCode As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientAddress1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientAddress2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCity As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCounty As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientState As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCountry As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientZip As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientType1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientType2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientType3 As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        AddClientDivisionProductResponse = New AddClientDivisionProductResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterClientCode.Value = ClientCode
                    SqlParameterClientName = New System.Data.SqlClient.SqlParameter("@cl_name", SqlDbType.VarChar)
                    SqlParameterClientName.Value = ClientName

                    SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterDivisionCode.Value = DivisionCode
                    SqlParameterDivisionName = New System.Data.SqlClient.SqlParameter("@div_name", SqlDbType.VarChar)
                    SqlParameterDivisionName.Value = DivisionName

                    SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterProductCode.Value = ProductCode
                    SqlParameterProductDescription = New System.Data.SqlClient.SqlParameter("@prd_description", SqlDbType.VarChar)
                    SqlParameterProductDescription.Value = ProductDescription

                    SqlParameterOfficeCode = New System.Data.SqlClient.SqlParameter("@office_code", SqlDbType.VarChar)
                    SqlParameterOfficeCode.Value = OfficeCode

                    SqlParameterUserDefined1 = New System.Data.SqlClient.SqlParameter("@user_defined_1", SqlDbType.VarChar)
                    SqlParameterUserDefined1.Value = UserDefined1
                    SqlParameterUserDefined2 = New System.Data.SqlClient.SqlParameter("@user_defined_2", SqlDbType.VarChar)
                    SqlParameterUserDefined2.Value = UserDefined2
                    SqlParameterUserDefined3 = New System.Data.SqlClient.SqlParameter("@user_defined_3", SqlDbType.VarChar)
                    SqlParameterUserDefined3.Value = UserDefined3
                    SqlParameterUserDefined4 = New System.Data.SqlClient.SqlParameter("@user_defined_4", SqlDbType.VarChar)
                    SqlParameterUserDefined4.Value = UserDefined4

                    SqlParameterClientAddress1 = New System.Data.SqlClient.SqlParameter("@cl_address1", SqlDbType.VarChar)
                    SqlParameterClientAddress1.Value = ClientAddress1
                    SqlParameterClientAddress2 = New System.Data.SqlClient.SqlParameter("@cl_address2", SqlDbType.VarChar)
                    SqlParameterClientAddress2.Value = ClientAddress2
                    SqlParameterClientCity = New System.Data.SqlClient.SqlParameter("@cl_city", SqlDbType.VarChar)
                    SqlParameterClientCity.Value = ClientCity
                    SqlParameterClientCounty = New System.Data.SqlClient.SqlParameter("@cl_county", SqlDbType.VarChar)
                    SqlParameterClientCounty.Value = ClientCounty
                    SqlParameterClientState = New System.Data.SqlClient.SqlParameter("@cl_state", SqlDbType.VarChar)
                    SqlParameterClientState.Value = ClientState
                    SqlParameterClientCountry = New System.Data.SqlClient.SqlParameter("@cl_country", SqlDbType.VarChar)
                    SqlParameterClientCountry.Value = ClientCountry
                    SqlParameterClientZip = New System.Data.SqlClient.SqlParameter("@cl_zip", SqlDbType.VarChar)
                    SqlParameterClientZip.Value = ClientZip

                    SqlParameterClientType1 = New System.Data.SqlClient.SqlParameter("@cl_type_1", SqlDbType.VarChar)
                    SqlParameterClientType1.Value = ClientType1
                    SqlParameterClientType2 = New System.Data.SqlClient.SqlParameter("@cl_type_2", SqlDbType.VarChar)
                    SqlParameterClientType2.Value = ClientType2
                    SqlParameterClientType3 = New System.Data.SqlClient.SqlParameter("@cl_type_3", SqlDbType.VarChar)
                    SqlParameterClientType3.Value = ClientType3

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_cli_div_prd_update_api @user_id,@action,@cl_code,@cl_name,@div_code,@div_name,@prd_code,@prd_description,@office_code,@user_defined_1,@user_defined_2,@user_defined_3,@user_defined_4,@cl_address1,@cl_address2,@cl_city,@cl_county,@cl_state,@cl_country,@cl_zip,@cl_type_1,@cl_type_2,@cl_type_3,@ret_val OUTPUT,@ret_val_s OUTPUT",
                            SqlParameterUserID, SqlParameterAction, SqlParameterClientCode, SqlParameterClientName, SqlParameterDivisionCode, SqlParameterDivisionName, SqlParameterProductCode, SqlParameterProductDescription,
                            SqlParameterOfficeCode, SqlParameterUserDefined1, SqlParameterUserDefined2, SqlParameterUserDefined3, SqlParameterUserDefined4,
                            SqlParameterClientAddress1, SqlParameterClientAddress2, SqlParameterClientCity, SqlParameterClientCounty, SqlParameterClientState, SqlParameterClientCountry, SqlParameterClientZip,
                            SqlParameterClientType1, SqlParameterClientType2, SqlParameterClientType3, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                AddClientDivisionProductResponse.IsSuccessful = False
                AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddClientDivisionProductResponse.IsSuccessful = True
                AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddClientDivisionProductResponse.ClientCode = SqlParameterClientCode.Value
                AddClientDivisionProductResponse.DivisionCode = SqlParameterDivisionCode.Value
                AddClientDivisionProductResponse.ProductCode = SqlParameterProductCode.Value

            End If

        Else

            AddClientDivisionProductResponse.IsSuccessful = False
            AddClientDivisionProductResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        UpdateClientDivisionProduct = AddClientDivisionProductResponse
    End Function

    Public Function AddCampaign(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  ClientCode As String, DivisionCode As String, ProductCode As String, CampaignCode As String, CampaignName As String,
                  StartDate As String, EndDate As String, JobNumber As Integer, JobComponentNumber As Integer) As AddCampaignResponse Implements IAPIService.AddCampaign

        'objects
        Dim AddCampaignResponse As AddCampaignResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCampaignCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCampaignName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        AddCampaignResponse = New AddCampaignResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterClientCode.Value = ClientCode

                    SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterDivisionCode.Value = DivisionCode

                    SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterProductCode.Value = ProductCode

                    SqlParameterCampaignCode = New System.Data.SqlClient.SqlParameter("@campaign_code", SqlDbType.VarChar)
                    SqlParameterCampaignCode.Value = CampaignCode

                    SqlParameterCampaignName = New System.Data.SqlClient.SqlParameter("@campaign_name", SqlDbType.VarChar)
                    SqlParameterCampaignName.Value = CampaignName

                    SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.VarChar)
                    SqlParameterStartDate.Value = StartDate

                    SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.VarChar)
                    SqlParameterEndDate.Value = EndDate

                    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
                    SqlParameterJobNumber.Value = JobNumber

                    SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.Int)
                    SqlParameterJobComponentNumber.Value = JobComponentNumber

                    SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@campaign_id", SqlDbType.Int)
                    SqlParameterCampaignID.Direction = ParameterDirection.Output
                    SqlParameterCampaignID.Value = ReturnValue

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_campaign_add_api @user_id,@action,@cl_code,@div_code,@prd_code,@campaign_code,@campaign_name,@start_date,@end_date,@job_number,@job_component_nbr,@campaign_id OUTPUT,@ret_val OUTPUT,@ret_val_s OUTPUT",
                            SqlParameterUserID, SqlParameterAction, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode,
                            SqlParameterCampaignCode, SqlParameterCampaignName, SqlParameterStartDate, SqlParameterEndDate, SqlParameterJobNumber, SqlParameterJobComponentNumber,
                            SqlParameterCampaignID, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                AddCampaignResponse.IsSuccessful = False
                AddCampaignResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            Else

                AddCampaignResponse.IsSuccessful = True
                AddCampaignResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                AddCampaignResponse.CampaignID = SqlParameterCampaignID.Value

            End If

        Else

            AddCampaignResponse.IsSuccessful = False
            AddCampaignResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddCampaign = AddCampaignResponse
    End Function

    Public Function LoadClientTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     ClientTypeIndicator As Integer, LoadInactive As Boolean) As List(Of ClientTypes) Implements IAPIService.LoadClientTypes

        'objects
        Dim ClientTypes As Generic.List(Of ClientTypes) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        ClientTypes = New Generic.List(Of ClientTypes)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    ClientTypes = DbContext.LoadClientTypes(ClientTypeIndicator, LoadInactive).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadClientTypes = ClientTypes

    End Function

    Public Function LoadAPInvoices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     VendorCode As String, StartDate As Date, EndDate As Date, PaymentStatus As Integer) As List(Of APInvoices) Implements IAPIService.LoadAPInvoices

        'objects
        Dim APInvoices As Generic.List(Of APInvoices) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing

        APInvoices = New Generic.List(Of APInvoices)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    APInvoices = DbContext.LoadAPInvoices(VendorCode, StartDate, EndDate, PaymentStatus).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            LoadAPInvoices = APInvoices

        Else

            Dim APInvoice = New APInvoices

            APInvoices.Clear()

            APInvoice.AP_ID = 0
            APInvoice.InvoiceDate = "01/01/1900"
            APInvoice.VendorCode = ErrorMessage

            APInvoices.Add(APInvoice)

            LoadAPInvoices = APInvoices

        End If

    End Function
    Public Function LoadAPInvoiceDetails(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     ApId As Integer) As List(Of APInvoiceDetails) Implements IAPIService.LoadAPInvoiceDetails

        'objects
        Dim APInvoices As Generic.List(Of APInvoiceDetails) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing

        APInvoices = New Generic.List(Of APInvoiceDetails)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    APInvoices = DbContext.LoadAPInvoiceDetails(ApId).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            LoadAPInvoiceDetails = APInvoices

        Else

            Dim APInvoice = New APInvoiceDetails

            APInvoices.Clear()

            APInvoice.ID = 0
            APInvoice.InvoiceDate = "01/01/1900"
            APInvoice.InvoiceDescription = ErrorMessage

            APInvoices.Add(APInvoice)

            LoadAPInvoiceDetails = APInvoices

        End If

    End Function

    Public Function LoadARInvoices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     JobNumber As Integer, JobComponentNumber As Integer, InvoiceNumber As Integer, InvoiceSequence As Integer) As List(Of ARInvoices) Implements IAPIService.LoadARInvoices


        'objects
        Dim ARInvoices As Generic.List(Of ARInvoices) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing

        ARInvoices = New Generic.List(Of ARInvoices)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    ARInvoices = DbContext.LoadARInvoices(JobNumber, JobComponentNumber, InvoiceNumber, InvoiceSequence).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            LoadARInvoices = ARInvoices

        Else

            'Dim ARInvoice = New ARInvoices

            'ARInvoices.Clear()

            'ARInvoice.InvoiceNumber = 0
            'ARInvoice.InvoiceDate = "01/01/1900"
            'ARInvoice.SalePostPeriod = ErrorMessage

            'ARInvoices.Add(ARInvoice)

            LoadARInvoices = ARInvoices

        End If

    End Function

    Public Function LoadJobLogUserDefinedValues(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     UserDefinedValueId As Integer, LoadInactive As Boolean) As List(Of JobLogUserDefinedValues) Implements IAPIService.LoadJobLogUserDefinedValues

        'objects
        Dim JobLogUserDefinedValues As Generic.List(Of JobLogUserDefinedValues) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        JobLogUserDefinedValues = New Generic.List(Of JobLogUserDefinedValues)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    JobLogUserDefinedValues = DbContext.LoadJobLogUserDefinedValues(UserDefinedValueId, LoadInactive).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadJobLogUserDefinedValues = JobLogUserDefinedValues

    End Function

    Public Function LoadOffices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     LoadInactive As Boolean) As List(Of Offices) Implements IAPIService.LoadOffices

        'objects
        Dim Offices As Generic.List(Of Offices) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Offices = New Generic.List(Of Offices)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Offices = DbContext.LoadOffices(LoadInactive).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

        End Try

        LoadOffices = Offices

    End Function

    Public Function LoadIndirectTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     StartDate As Date, EndDate As Date, EmployeeCode As String) As List(Of IndirectTime) Implements IAPIService.LoadIndirectTime

        'objects
        Dim IndirectTime As Generic.List(Of IndirectTime) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing

        IndirectTime = New Generic.List(Of IndirectTime)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    IndirectTime = DbContext.LoadIndirectTime(StartDate, EndDate, EmployeeCode, ErrorMessage).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            LoadIndirectTime = IndirectTime

        Else

            Dim IndirectTimeRecord = New IndirectTime

            IndirectTime.Clear()

            IndirectTimeRecord.ET_ID = 0
            IndirectTimeRecord.ET_DTL_ID = 0
            'IndirectTimeRecord.TimesheetDate = "01/01/1900"
            IndirectTimeRecord.Comments = ErrorMessage

            IndirectTime.Add(IndirectTimeRecord)

            LoadIndirectTime = IndirectTime

        End If

    End Function
    Public Function LoadSecClients2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, UserCode As String) As SecClientAPIResponse Implements IAPIService.LoadSecClients2

        Dim SecClients As Generic.List(Of SecClient) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As SecClientAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        SecClients = New Generic.List(Of SecClient)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SecClients = DbContext.LoadSecClients(UserCode, ErrorMessage).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            SecClients = New Generic.List(Of SecClient)
        End Try

        ResultAPIResponse = New SecClientAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = SecClients
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadSecClients2 = ResultAPIResponse

    End Function

    Public Function LoadContactTypes2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As ContactTypeAPIResponse Implements IAPIService.LoadContactTypes2

        'objects
        Dim ContactTypes As Generic.List(Of ContactType) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As ContactTypeAPIResponse = Nothing
        Dim ErrorMessage As String = Nothing

        ContactTypes = New Generic.List(Of ContactType)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    ContactTypes = DbContext.ContactTypes.ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ContactTypes = New Generic.List(Of ContactType)
        End Try

        ResultAPIResponse = New ContactTypeAPIResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = ContactTypes
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadContactTypes2 = ResultAPIResponse

    End Function

    Public Function LoadARStmtProductContacts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ClientCode As String, ClientLevelOnlyContacts As Boolean, LoadInactive As Boolean) As ARStmtProductContactResponse Implements IAPIService.LoadARStmtProductContacts

        'objects
        Dim ARStmtProductContacts As Generic.List(Of ARStmtProductContact) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = ""
        Dim ResultAPIResponse As ARStmtProductContactResponse = Nothing

        Dim ClientIDParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim ClientLevelOnlyContactsParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim LoadInactiveParameter As System.Data.SqlClient.SqlParameter = Nothing

        ARStmtProductContacts = New Generic.List(Of ARStmtProductContact)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    ClientIDParameter = New System.Data.SqlClient.SqlParameter("@ClientCode", SqlDbType.VarChar) With {.Value = ClientCode}
                    ClientLevelOnlyContactsParameter = New System.Data.SqlClient.SqlParameter("@ClientLevelOnlyContacts", SqlDbType.Bit) With {.Value = ClientLevelOnlyContacts}
                    LoadInactiveParameter = New System.Data.SqlClient.SqlParameter("@LoadInactive", SqlDbType.Bit) With {.Value = LoadInactive}

                    ARStmtProductContacts = DbContext.Database.SqlQuery(Of ARStmtProductContact)("exec [dbo].[advsp_api_load_ar_stmt_product_contacts] @ClientCode, @ClientLevelOnlyContacts, @LoadInactive", ClientIDParameter, ClientLevelOnlyContactsParameter, LoadInactiveParameter).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            ARStmtProductContacts = New Generic.List(Of ARStmtProductContact)
        End Try

        ResultAPIResponse = New ARStmtProductContactResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = ARStmtProductContacts
            ResultAPIResponse.IsSuccessful = True
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadARStmtProductContacts = ResultAPIResponse

    End Function

    Public Function AddOrUpdateContactType(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                           ContactTypeId As Integer, ContactTypeDesc As String) As ContactTypeResponse Implements IAPIService.AddOrUpdateContactType

        'objects
        Dim ContactTypeResponse As ContactTypeResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactTypeIdIn As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactTypeDescription As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterInactiveFlag As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterContactTypeIdOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        ContactTypeResponse = New ContactTypeResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterContactTypeIdIn = New System.Data.SqlClient.SqlParameter("@contact_type_id_in", SqlDbType.Int)
                    SqlParameterContactTypeIdIn.Value = ContactTypeId

                    SqlParameterContactTypeDescription = New System.Data.SqlClient.SqlParameter("@contact_type_desc", SqlDbType.VarChar)
                    SqlParameterContactTypeDescription.Value = ContactTypeDesc

                    SqlParameterContactTypeIdOut = New System.Data.SqlClient.SqlParameter("@contact_type_id_out", SqlDbType.Int)
                    SqlParameterContactTypeIdOut.Direction = ParameterDirection.Output
                    SqlParameterContactTypeIdOut.Value = ContactTypeId

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_contact_type_add_update_api @contact_type_id_in,@contact_type_desc,@contact_type_id_out OUTPUT, @ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterContactTypeIdIn, SqlParameterContactTypeDescription,
                                                         SqlParameterContactTypeIdOut, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ContactTypeResponse.IsSuccessful = False
                ContactTypeResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                ContactTypeResponse.ContactTypeID = SqlParameterContactTypeIdOut.Value

            Else

                ContactTypeResponse.IsSuccessful = True
                ContactTypeResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                ContactTypeResponse.ContactTypeID = SqlParameterContactTypeIdOut.Value
                ContactTypeResponse.ContactTypeDescription = SqlParameterContactTypeDescription.Value

            End If
        Else

            ContactTypeResponse.IsSuccessful = False
            ContactTypeResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrUpdateContactType = ContactTypeResponse

    End Function

    Public Function AddOrUpdateClientContactHdr(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        ContactID As Integer,
                        ContactCode As String,
                        ClientCode As String,
                        EmailAddress As String,
                        ContactFirstName As String,
                        ContactLastName As String,
                        ContactMiddleInitial As String,
                        ContactTitle As String,
                        ContactAddress1 As String,
                        ContactAddress2 As String,
                        ContactCity As String,
                        ContactCounty As String,
                        ContactState As String,
                        ContactCountry As String,
                        ContactZip As String,
                        ContactTelephone As String,
                        ConatctPhoneExtenstion As String,
                        ContactFax As String,
                        ContactFaxExtension As String,
                        ScheduleUser As Short,
                        ClientPortalUser As Short,
                        ClientPortalAlerts As Short,
                        ClientPortalEmailRecipient As Short,
                        ContactMobilePhone As String,
                        ContactComment As String,
                        ContactTypeID As Integer,      'DefaultTask As String, 'PrimaryTask As Short
                        IsInactive As Short
                        ) As ContactHeaderResponse Implements IAPIService.AddOrUpdateClientContactHdr

        'objects
        Dim ContactHeaderResponse As ContactHeaderResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactHdrIdIn As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterContactCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactEmailAddress As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactFirstName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactLastName As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactMiddleInitial As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactTitle As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactAddress1 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactAddress2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactCity As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactCounty As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactState As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactCountry As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactZip As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactTelephone As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterConatctPhoneExtenstion As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactFax As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactFaxExtension As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterScheduleUser As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientPortalUser As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientPortalAlerts As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterClientPortalEmailRecipient As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactMobilePhone As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactComment As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactTypeID As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterInactiveFlag As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterContactHdrIdOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ContactHdrIdOut = 0
        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        ContactHeaderResponse = New ContactHeaderResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterContactHdrIdIn = New System.Data.SqlClient.SqlParameter("@cdp_contact_id_in", SqlDbType.Int)
                    SqlParameterContactHdrIdIn.Value = ContactID

                    SqlParameterContactCode = New System.Data.SqlClient.SqlParameter("@cont_code", SqlDbType.VarChar)
                    SqlParameterContactCode.Value = ContactCode

                    SqlParameterContactClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                    SqlParameterContactClientCode.Value = ClientCode

                    SqlParameterContactEmailAddress = New System.Data.SqlClient.SqlParameter("@email_address", SqlDbType.VarChar)
                    SqlParameterContactEmailAddress.Value = EmailAddress

                    SqlParameterContactFirstName = New System.Data.SqlClient.SqlParameter("@cont_fname", SqlDbType.VarChar)
                    SqlParameterContactFirstName.Value = ContactFirstName

                    SqlParameterContactLastName = New System.Data.SqlClient.SqlParameter("@cont_lname", SqlDbType.VarChar)
                    SqlParameterContactLastName.Value = ContactLastName

                    SqlParameterContactMiddleInitial = New System.Data.SqlClient.SqlParameter("@cont_mi", SqlDbType.VarChar)
                    SqlParameterContactMiddleInitial.Value = ContactMiddleInitial

                    SqlParameterContactTitle = New System.Data.SqlClient.SqlParameter("@cont_title", SqlDbType.VarChar)
                    SqlParameterContactTitle.Value = ContactTitle

                    SqlParameterContactAddress1 = New System.Data.SqlClient.SqlParameter("@cont_address1", SqlDbType.VarChar)
                    SqlParameterContactAddress1.Value = ContactAddress1

                    SqlParameterContactAddress2 = New System.Data.SqlClient.SqlParameter("@cont_address2", SqlDbType.VarChar)
                    SqlParameterContactAddress2.Value = ContactAddress2

                    SqlParameterContactCity = New System.Data.SqlClient.SqlParameter("@cont_city", SqlDbType.VarChar)
                    SqlParameterContactCity.Value = ContactCity

                    SqlParameterContactCounty = New System.Data.SqlClient.SqlParameter("@cont_county", SqlDbType.VarChar)
                    SqlParameterContactCounty.Value = ContactCounty

                    SqlParameterContactState = New System.Data.SqlClient.SqlParameter("@cont_state", SqlDbType.VarChar)
                    SqlParameterContactState.Value = ContactState

                    SqlParameterContactCountry = New System.Data.SqlClient.SqlParameter("@cont_country", SqlDbType.VarChar)
                    SqlParameterContactCountry.Value = ContactCountry

                    SqlParameterContactZip = New System.Data.SqlClient.SqlParameter("@cont_zip", SqlDbType.VarChar)
                    SqlParameterContactZip.Value = ContactZip

                    SqlParameterContactTelephone = New System.Data.SqlClient.SqlParameter("@cont_telephone", SqlDbType.VarChar)
                    SqlParameterContactTelephone.Value = ContactTelephone

                    SqlParameterConatctPhoneExtenstion = New System.Data.SqlClient.SqlParameter("@cont_extention", SqlDbType.VarChar)
                    SqlParameterConatctPhoneExtenstion.Value = ConatctPhoneExtenstion

                    SqlParameterContactFax = New System.Data.SqlClient.SqlParameter("@cont_fax", SqlDbType.VarChar)
                    SqlParameterContactFax.Value = ContactFax

                    SqlParameterContactFaxExtension = New System.Data.SqlClient.SqlParameter("@cont_fax_extention", SqlDbType.VarChar)
                    SqlParameterContactFaxExtension.Value = ContactFaxExtension

                    SqlParameterScheduleUser = New System.Data.SqlClient.SqlParameter("@schedule_user", SqlDbType.Int)
                    SqlParameterScheduleUser.Value = ScheduleUser

                    SqlParameterClientPortalUser = New System.Data.SqlClient.SqlParameter("@cp_user", SqlDbType.Int)
                    SqlParameterClientPortalUser.Value = ClientPortalUser

                    SqlParameterClientPortalAlerts = New System.Data.SqlClient.SqlParameter("@cp_alerts", SqlDbType.Int)
                    SqlParameterClientPortalAlerts.Value = ClientPortalAlerts

                    SqlParameterClientPortalEmailRecipient = New System.Data.SqlClient.SqlParameter("@email_rcpt", SqlDbType.Int)
                    SqlParameterClientPortalEmailRecipient.Value = ClientPortalEmailRecipient

                    SqlParameterContactMobilePhone = New System.Data.SqlClient.SqlParameter("@cell_phone", SqlDbType.VarChar)
                    SqlParameterContactMobilePhone.Value = ContactMobilePhone

                    SqlParameterContactComment = New System.Data.SqlClient.SqlParameter("@cont_comment", SqlDbType.VarChar)
                    SqlParameterContactComment.Value = ContactComment

                    SqlParameterContactTypeID = New System.Data.SqlClient.SqlParameter("@contact_type_id", SqlDbType.Int)
                    SqlParameterContactTypeID.Value = ContactTypeID

                    SqlParameterInactiveFlag = New System.Data.SqlClient.SqlParameter("@inactive_flag", SqlDbType.Int)
                    SqlParameterInactiveFlag.Value = IsInactive

                    SqlParameterContactHdrIdOut = New System.Data.SqlClient.SqlParameter("@cdp_contact_id_out", SqlDbType.Int)
                    SqlParameterContactHdrIdOut.Direction = ParameterDirection.Output
                    SqlParameterContactHdrIdOut.Value = ContactHdrIdOut

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "
                                                    EXEC advsp_client_contact_add_update_api 
                                                        @cdp_contact_id_in,
                                                        @cont_code,
                                                        @cl_code,
                                                        @email_address,
                                                        @cont_fname,
                                                        @cont_lname,
                                                        @cont_mi,
                                                        @cont_title,
                                                        @cont_address1,
                                                        @cont_address2,
                                                        @cont_city,
                                                        @cont_county,
                                                        @cont_state,
                                                        @cont_country,
                                                        @cont_zip,
                                                        @cont_telephone,
                                                        @cont_extention,
                                                        @cont_fax,
                                                        @cont_fax_extention,
                                                        @schedule_user,
                                                        @cp_user,
                                                        @cp_alerts,
                                                        @email_rcpt,
                                                        @cell_phone,
                                                        @cont_comment,
                                                        @contact_type_id,
                                                        @inactive_flag,
                                                        @cdp_contact_id_out OUTPUT, @ret_val OUTPUT,@ret_val_s OUTPUT",
                                                         SqlParameterContactHdrIdIn,
                                                         SqlParameterContactCode,
                                                         SqlParameterContactClientCode,
                                                         SqlParameterContactEmailAddress,
                                                         SqlParameterContactFirstName,
                                                         SqlParameterContactLastName,
                                                         SqlParameterContactMiddleInitial,
                                                         SqlParameterContactTitle,
                                                         SqlParameterContactAddress1,
                                                         SqlParameterContactAddress2,
                                                         SqlParameterContactCity,
                                                         SqlParameterContactCounty,
                                                         SqlParameterContactState,
                                                         SqlParameterContactCountry,
                                                         SqlParameterContactZip,
                                                         SqlParameterContactTelephone,
                                                         SqlParameterConatctPhoneExtenstion,
                                                         SqlParameterContactFax,
                                                         SqlParameterContactFaxExtension,
                                                         SqlParameterScheduleUser,
                                                         SqlParameterClientPortalUser,
                                                         SqlParameterClientPortalAlerts,
                                                         SqlParameterClientPortalEmailRecipient,
                                                         SqlParameterContactMobilePhone,
                                                         SqlParameterContactComment,
                                                         SqlParameterContactTypeID,
                                                         SqlParameterInactiveFlag,
                                                         SqlParameterContactHdrIdOut, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ContactHeaderResponse.IsSuccessful = False
                ContactHeaderResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

                If Not IsDBNull(SqlParameterContactHdrIdOut.Value) Then
                    ContactHeaderResponse.ContactHeaderID = SqlParameterContactHdrIdOut.Value
                Else
                    ContactHeaderResponse.ContactHeaderID = 0
                End If

            Else

                ContactHeaderResponse.IsSuccessful = True
                ContactHeaderResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                ContactHeaderResponse.ContactHeaderID = SqlParameterContactHdrIdOut.Value
                'ContactHeaderResponse.ContactTypeDescription = SqlParameterContactTypeDescription.Value

            End If
        Else

            ContactHeaderResponse.IsSuccessful = False
            ContactHeaderResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrUpdateClientContactHdr = ContactHeaderResponse

    End Function

    Public Function AddOrDeleteClientContactDtl(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        ContactID As Integer,
                        SeqNumber As Integer,
                        DivisionCode As String,
                        ProductCode As String,
                        DeleteSeq As Boolean) As ContactDetailResponse Implements IAPIService.AddOrDeleteClientContactDtl

        'objects
        Dim ContactDetailResponse As ContactDetailResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterContactHdrIdIn As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterSeqNumberIn As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDeleteSeq As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterContactSeqNumberOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ContactSeqNbr As Integer = 0
        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        ContactDetailResponse = New ContactDetailResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                    SqlParameterUserID.Value = APISession.UserCode

                    SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                    SqlParameterAction.Value = String.Empty

                    SqlParameterContactHdrIdIn = New System.Data.SqlClient.SqlParameter("@cdp_contact_id_in", SqlDbType.Int)
                    SqlParameterContactHdrIdIn.Value = ContactID

                    SqlParameterSeqNumberIn = New System.Data.SqlClient.SqlParameter("@seq_nbr_in", SqlDbType.Int)
                    SqlParameterSeqNumberIn.Value = SeqNumber

                    SqlParameterContactDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                    SqlParameterContactDivisionCode.Value = DivisionCode

                    SqlParameterContactProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                    SqlParameterContactProductCode.Value = ProductCode

                    SqlParameterDeleteSeq = New System.Data.SqlClient.SqlParameter("@delete_seq", SqlDbType.Bit)
                    SqlParameterDeleteSeq.Value = DeleteSeq

                    SqlParameterContactSeqNumberOut = New System.Data.SqlClient.SqlParameter("@seq_nbr_out", SqlDbType.Int)
                    SqlParameterContactSeqNumberOut.Direction = ParameterDirection.Output
                    SqlParameterContactSeqNumberOut.Value = ContactSeqNbr

                    SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                    SqlParameterReturnValue.Direction = ParameterDirection.Output
                    SqlParameterReturnValue.Value = ReturnValue

                    SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                    SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                    SqlParameterReturnValueMessage.Size = 4096
                    SqlParameterReturnValueMessage.Value = ReturnValueMessage

                    DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_client_contact_detail_add_update_api 
                                @cdp_contact_id_in,
                                @seq_nbr_in,
                                @div_code,
                                @prd_code,
                                @delete_seq,
                                @seq_nbr_out OUTPUT, @ret_val OUTPUT,@ret_val_s OUTPUT",
                                SqlParameterContactHdrIdIn,
                                SqlParameterSeqNumberIn,
                                SqlParameterContactDivisionCode,
                                SqlParameterContactProductCode,
                                SqlParameterDeleteSeq,
                                SqlParameterContactSeqNumberOut, SqlParameterReturnValue, SqlParameterReturnValueMessage)

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ContactDetailResponse.IsSuccessful = False
                ContactDetailResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

                If Not IsDBNull(SqlParameterContactSeqNumberOut.Value) Then
                    ContactDetailResponse.SeqNumber = SqlParameterContactSeqNumberOut.Value
                Else
                    ContactDetailResponse.SeqNumber = 0
                End If

            Else

                ContactDetailResponse.IsSuccessful = True
                ContactDetailResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))
                ContactDetailResponse.SeqNumber = SqlParameterContactSeqNumberOut.Value

            End If
        Else

            ContactDetailResponse.IsSuccessful = False
            ContactDetailResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrDeleteClientContactDtl = ContactDetailResponse

    End Function

    Public Function AddOrUpdateARStmtClientContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        ClientCode As String,
                        ContactID As Integer,
                        EmailInvoice As Short,
                        PrintInvoice As Short,
                        UseAddress As Short,
                        IncludeOnAccount As Short,
                        Optional ByVal DeleteContact As Boolean = False
                        ) As ContactStatementResponse Implements IAPIService.AddOrUpdateARStmtClientContact

        'objects
        Dim ContactStatementResponse As ContactStatementResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEmailInvoice As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterPrintInvoice As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUseAddress As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeOnAccount As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDeleteContact As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientCodeOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactIDOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

        Dim Deleted As Integer

        ContactStatementResponse = New ContactStatementResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If DeleteContact = True Then

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)

                        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                        SqlParameterReturnValueMessage.Size = 4096

                        DbTransaction = DbContext.Database.BeginTransaction

                        Try

                            Deleted = DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CLIENT_AR_STMT WHERE CL_CODE = '{0}' AND CDP_CONTACT_ID = {1}", ClientCode, ContactID))

                        Catch ex As Exception
                            Deleted = 0
                        End Try

                        If Deleted > 0 Then

                            DbTransaction.Commit()

                            SqlParameterReturnValue.Value = 0
                            SqlParameterReturnValueMessage.Value = "DELETE"

                        Else

                            DbTransaction.Rollback()

                            ErrorMessage = "DELETE Failed"

                        End If

                    Else

                        SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                        SqlParameterUserID.Value = APISession.UserCode

                        SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                        SqlParameterAction.Value = String.Empty

                        SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                        SqlParameterClientCode.Value = ClientCode

                        SqlParameterContactID = New System.Data.SqlClient.SqlParameter("@cdp_contact_id", SqlDbType.Int)
                        SqlParameterContactID.Value = ContactID

                        SqlParameterEmailInvoice = New System.Data.SqlClient.SqlParameter("@dist_via_email", SqlDbType.SmallInt)
                        SqlParameterEmailInvoice.Value = EmailInvoice

                        SqlParameterPrintInvoice = New System.Data.SqlClient.SqlParameter("@dist_via_print", SqlDbType.SmallInt)
                        SqlParameterPrintInvoice.Value = PrintInvoice

                        SqlParameterUseAddress = New System.Data.SqlClient.SqlParameter("@use_address", SqlDbType.SmallInt)
                        SqlParameterUseAddress.Value = UseAddress

                        SqlParameterIncludeOnAccount = New System.Data.SqlClient.SqlParameter("@incl_on_acct", SqlDbType.SmallInt)
                        SqlParameterIncludeOnAccount.Value = IncludeOnAccount

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                        SqlParameterReturnValue.Direction = ParameterDirection.Output
                        SqlParameterReturnValue.Value = ReturnValue

                        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                        SqlParameterReturnValueMessage.Size = 4096
                        SqlParameterReturnValueMessage.Value = ReturnValueMessage

                        DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_client_ar_stmt_contact_add_update_api 
                                @cl_code,
                                @cdp_contact_id,
                                @dist_via_email,
                                @dist_via_print,
                                @use_address,
                                @incl_on_acct,
                                @ret_val OUTPUT,@ret_val_s OUTPUT",
                                    SqlParameterClientCode,
                                    SqlParameterContactID,
                                    SqlParameterEmailInvoice,
                                    SqlParameterPrintInvoice,
                                    SqlParameterUseAddress,
                                    SqlParameterIncludeOnAccount,
                                    SqlParameterReturnValue, SqlParameterReturnValueMessage)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ContactStatementResponse.IsSuccessful = False
                ContactStatementResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

                'If Not IsDBNull(SqlParameterClientCode.Value) Then
                '    ContactDetailResponse.ContactID = SqlParameterContactID.Value
                'Else
                '    ContactDetailResponse.ContactID = 0
                'End If

            Else

                ContactStatementResponse.IsSuccessful = True
                ContactStatementResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            End If
        Else

            ContactStatementResponse.IsSuccessful = False
            ContactStatementResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrUpdateARStmtClientContact = ContactStatementResponse

    End Function

    Public Function AddOrUpdateARStmtProductContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        ClientCode As String,
                        DivisionCode As String,
                        ProductCode As String,
                        ContactID As Integer,
                        EmailInvoice As Short,
                        PrintInvoice As Short,
                        UseAddress As Short,
                        IncludeOnAccount As Short,
                        Optional ByVal DeleteContact As Boolean = False
                        ) As ContactStatementResponse Implements IAPIService.AddOrUpdateARStmtProductContact

        'objects
        Dim ContactStatementResponse As ContactStatementResponse = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterEmailInvoice As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterPrintInvoice As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterUseAddress As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterIncludeOnAccount As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterDeleteContact As System.Data.SqlClient.SqlParameter = Nothing

        Dim SqlParameterClientCodeOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterContactIDOut As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterReturnValueMessage As System.Data.SqlClient.SqlParameter = Nothing

        Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

        Dim Deleted As Integer

        Dim ReturnValue As Integer = 0
        Dim ReturnValueMessage As String = String.Empty

        ContactStatementResponse = New ContactStatementResponse

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If DeleteContact = True Then

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)

                        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                        SqlParameterReturnValueMessage.Size = 4096

                        DbTransaction = DbContext.Database.BeginTransaction

                        Try

                            Deleted = DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.PRODUCT_AR_STMT WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}' AND CDP_CONTACT_ID = {3}", ClientCode, DivisionCode, ProductCode, ContactID))

                        Catch ex As Exception
                            Deleted = 0
                        End Try

                        If Deleted > 0 Then

                            DbTransaction.Commit()

                            SqlParameterReturnValue.Value = 0
                            SqlParameterReturnValueMessage.Value = "DELETE"

                        Else

                            DbTransaction.Rollback()

                            ErrorMessage = "DELETE Failed"

                        End If

                    Else

                        SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
                        SqlParameterUserID.Value = APISession.UserCode

                        SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
                        SqlParameterAction.Value = String.Empty

                        SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                        SqlParameterClientCode.Value = ClientCode

                        SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                        SqlParameterDivisionCode.Value = DivisionCode

                        SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                        SqlParameterProductCode.Value = ProductCode

                        SqlParameterContactID = New System.Data.SqlClient.SqlParameter("@cdp_contact_id", SqlDbType.Int)
                        SqlParameterContactID.Value = ContactID

                        SqlParameterEmailInvoice = New System.Data.SqlClient.SqlParameter("@dist_via_email", SqlDbType.SmallInt)
                        SqlParameterEmailInvoice.Value = EmailInvoice

                        SqlParameterPrintInvoice = New System.Data.SqlClient.SqlParameter("@dist_via_print", SqlDbType.SmallInt)
                        SqlParameterPrintInvoice.Value = PrintInvoice

                        SqlParameterUseAddress = New System.Data.SqlClient.SqlParameter("@use_address", SqlDbType.SmallInt)
                        SqlParameterUseAddress.Value = UseAddress

                        SqlParameterIncludeOnAccount = New System.Data.SqlClient.SqlParameter("@incl_on_acct", SqlDbType.SmallInt)
                        SqlParameterIncludeOnAccount.Value = IncludeOnAccount

                        SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
                        SqlParameterReturnValue.Direction = ParameterDirection.Output
                        SqlParameterReturnValue.Value = ReturnValue

                        SqlParameterReturnValueMessage = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar)
                        SqlParameterReturnValueMessage.Direction = ParameterDirection.Output
                        SqlParameterReturnValueMessage.Size = 4096
                        SqlParameterReturnValueMessage.Value = ReturnValueMessage

                        DbContext.Database.ExecuteSqlCommand(Entity.TransactionalBehavior.DoNotEnsureTransaction, "EXEC advsp_product_ar_stmt_contact_add_update_api 
                                @cl_code,
                                @div_code,
                                @prd_code,
                                @cdp_contact_id,
                                @dist_via_email,
                                @dist_via_print,
                                @use_address,
                                @incl_on_acct,
                                @ret_val OUTPUT,@ret_val_s OUTPUT",
                                    SqlParameterClientCode,
                                    SqlParameterDivisionCode,
                                    SqlParameterProductCode,
                                    SqlParameterContactID,
                                    SqlParameterEmailInvoice,
                                    SqlParameterPrintInvoice,
                                    SqlParameterUseAddress,
                                    SqlParameterIncludeOnAccount,
                                    SqlParameterReturnValue, SqlParameterReturnValueMessage)

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage &= LTrim(RTrim(" " & ex.Message))
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) <> False Then

            If SqlParameterReturnValue.Value <> 0 Then

                ContactStatementResponse.IsSuccessful = False
                ContactStatementResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

                'If Not IsDBNull(SqlParameterClientCode.Value) Then
                '    ContactStatementResponse.ContactID = SqlParameterContactID.Value
                'Else
                '    ContactStatementResponse.ContactID = 0
                'End If

            Else

                ContactStatementResponse.IsSuccessful = True
                ContactStatementResponse.Message = LTrim(RTrim(" " & SqlParameterReturnValueMessage.Value))

            End If
        Else

            ContactStatementResponse.IsSuccessful = False
            ContactStatementResponse.Message = LTrim(RTrim(" " & ErrorMessage))

        End If

        AddOrUpdateARStmtProductContact = ContactStatementResponse

    End Function

    'Public Function CopyMediaPlan(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
    '                        MediaPlanID As Integer,
    '                        ClientCode As String, DivisionCode As String, ProductCode As String,
    '                        Optional ByVal Description As String = "",
    '                        Optional ByVal StartDate As String = "01-01-1900", Optional ByVal EndDate As String = "01-01-1900",
    '                        Optional ByVal GrossBudgetAmount As Decimal = -1, Optional ByVal Comment As String = "") As MediaPlanAddResponse Implements IAPIService.CopyMediaPlan

    '    'objects

    '    Dim CampaignID As Integer
    '    Dim CountryID As Integer

    '    Call CopyMediaPlan2(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password,
    '                        MediaPlanID,
    '                        ClientCode, DivisionCode, ProductCode,
    '                        CampaignID,
    '                        CountryID,
    '                        Description,
    '                        StartDate, EndDate,
    '                        GrossBudgetAmount, Comment)

    '    Dim MediaPlanAddResponse As MediaPlanAddResponse = Nothing

    '    MediaPlanAddResponse = _MediaPlanAddResponse

    '    CopyMediaPlan = MediaPlanAddResponse

    'End Function

    Public Function CopyMediaPlan(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            MediaPlanID As Integer,
                            ClientCode As String, DivisionCode As String, ProductCode As String,
                            Optional ByVal Description As String = "",
                            Optional ByVal StartDate As String = "01-01-1900", Optional ByVal EndDate As String = "01-01-1900",
                            Optional ByVal GrossBudgetAmount As Decimal = -1, Optional ByVal Comment As String = "",
                            Optional ByVal CampaignID As Integer = 0,
                            Optional ByVal CountryID As Integer = 0) As MediaPlanAddResponse Implements IAPIService.CopyMediaPlan

        'objects

        Dim MediaPlanOrig_ As AdvantageFramework.Database.Entities.MediaPlan = Nothing
        Dim MediaPlan_ As AdvantageFramework.Database.Entities.MediaPlan = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing
        Dim MediaPlanAddResponse As MediaPlanAddResponse = Nothing

        Dim Clients As New Generic.List(Of Client)
        Dim Divisions As New Generic.List(Of Division)
        Dim Products As New Generic.List(Of Product)
        Dim CampaignID_ As Nullable(Of Integer)
        Dim CountryID_ As Nullable(Of Integer)
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign

        'Dim CampaignsWithDates As New Generic.List(Of CampaignWithDates)
        'Dim CampaignWithDates As CampaignWithDates = Nothing

        If String.IsNullOrWhiteSpace(StartDate) = True Then StartDate = "01/01/1900"
        If String.IsNullOrWhiteSpace(EndDate) = True Then EndDate = "01/01/1900"

        Dim StartDate_ As Date = AdvantageFramework.DateUtilities.ConvertShortDateStringToDate(StartDate)
        Dim EndDate_ As Date = AdvantageFramework.DateUtilities.ConvertShortDateStringToDate(EndDate)

        Dim NewMediaPlanID As Integer = 0
        Dim Copied As Boolean = False
        Dim ContinueCopying As Boolean = True

        Dim RecordCount As Nullable(Of Integer)

        'SelectedProduct = Nothing

        If MediaPlanID <> 0 Then

            Try

                If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                    If 1 = 1 Then

                        If StartDate > EndDate Then

                            ErrorMessage = "Please select a start date on or before the end date."

                        End If

                        If ErrorMessage = "" Then

                            If DateAdd(DateInterval.Month, 18, StartDate_) < EndDate_ Then

                                ErrorMessage = "Please select a date range of 18 months or less."

                            End If

                        End If
                    End If

                    Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                        If String.IsNullOrWhiteSpace(ClientCode) OrElse String.IsNullOrWhiteSpace(DivisionCode) OrElse String.IsNullOrWhiteSpace(ProductCode) Then
                            ClientCode = Nothing
                            DivisionCode = Nothing
                            ProductCode = Nothing
                        Else

                            Clients = DbContext.Clients.Where(Function(Entity) Entity.Code = ClientCode AndAlso Entity.IsActive = 1).ToList

                            If Clients.Count() = 0 Then

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Client Code."

                            Else

                                Divisions = DbContext.Divisions.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Code = DivisionCode AndAlso Entity.IsActive = 1).ToList

                                If Divisions.Count() = 0 Then

                                    If (ErrorMessage > "") Then
                                        ErrorMessage = ErrorMessage + ", "
                                    End If

                                    ErrorMessage = ErrorMessage + "Invalid Division Code."

                                Else

                                    Products = DbContext.Products.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.Code = ProductCode AndAlso Entity.IsActive = 1).ToList

                                    If Products.Count() = 0 Then

                                        If (ErrorMessage > "") Then
                                            ErrorMessage = ErrorMessage + ", "
                                        End If

                                        ErrorMessage = ErrorMessage + "Invalid Product Code."

                                    End If

                                End If

                            End If

                        End If

                        If MediaPlanID > 0 Then

                            Dim SqlParameterPLAN_ID As System.Data.SqlClient.SqlParameter = Nothing

                            SqlParameterPLAN_ID = New System.Data.SqlClient.SqlParameter("@media_plan_id", SqlDbType.Int)
                            SqlParameterPLAN_ID.Value = MediaPlanID

                            RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.MEDIA_PLAN WHERE MEDIA_PLAN_ID = @media_plan_id", SqlParameterPLAN_ID).FirstOrDefault

                            If RecordCount = 0 Then

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Media Plan ID."

                            End If

                        Else

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Media Plan ID."

                        End If

                        '---------------------

                        If CampaignID > 0 Then

                            Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(AFDbContext, CampaignID)

                                If Campaign IsNot Nothing Then

                                    If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode = ProductCode) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                        'Do Nothing

                                    Else
                                        If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode Is Nothing) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                            'Do Nothing

                                        Else

                                            If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                            (Campaign.ClientCode = ClientCode) AndAlso
                                            (Campaign.DivisionCode Is Nothing) AndAlso
                                            (Campaign.ProductCode Is Nothing) AndAlso
                                            (Campaign.IsClosed = 0) Then

                                                'Do Nothing

                                            Else

                                                If (ErrorMessage > "") Then
                                                    ErrorMessage = ErrorMessage + ", "
                                                End If

                                                ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                                            End If

                                        End If

                                    End If

                                    CampaignID_ = CampaignID

                                Else

                                    If (ErrorMessage > "") Then
                                        ErrorMessage = ErrorMessage + ", "
                                    End If

                                    ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                                End If

                            End Using

                        End If

                        If CountryID = 0 Then CountryID = 1 'USA

                        If CountryID > 0 Then

                            Dim SqlParameterCOUNTRY_ID As System.Data.SqlClient.SqlParameter = Nothing

                            SqlParameterCOUNTRY_ID = New System.Data.SqlClient.SqlParameter("@country_id", SqlDbType.Int)
                            SqlParameterCOUNTRY_ID.Value = CountryID

                            RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.COUNTRY WHERE COUNTRY_ID = @country_id", SqlParameterCOUNTRY_ID).FirstOrDefault

                            If RecordCount = 0 Then

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Country ID."

                            Else

                                CountryID_ = CountryID

                            End If

                        End If

                    End Using

                    '---------------------

                    If GrossBudgetAmount > 1000000000.0 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Your Budget Amount exceeded the maximum of $1,000,000,000.00."

                    End If

                End If

            Catch ex As Exception

                ProcessException(ex, "APIService-NotCaught")

                ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                    If ex.InnerException.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                    End If

                End If

            End Try

            If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_AdvSession.ConnectionString, _AdvSession.UserCode)

                        MediaPlanOrig_ = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, MediaPlanID)

                        'MediaPlanOrig_.DbContext = DbContext

                        Copied = AdvantageFramework.MediaPlanning.CopyMediaPlan(_AdvSession, MediaPlanID, NewMediaPlanID, Nothing, ClientCode, DivisionCode, ProductCode)

                    End Using

                Catch ex As Exception
                    Copied = False
                End Try

                If Copied Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_AdvSession.ConnectionString, _AdvSession.UserCode)

                            MediaPlan_ = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, NewMediaPlanID)

                            MediaPlan_.DbContext = DbContext

                            If String.IsNullOrWhiteSpace(Description) = False Then
                                MediaPlan_.Description = Description
                            End If

                            If GrossBudgetAmount > -1 Then
                                MediaPlan_.GrossBudgetAmount = GrossBudgetAmount
                            End If

                            If String.IsNullOrWhiteSpace(Comment) = False Then
                                MediaPlan_.Comment = Comment
                            End If

                            If CampaignID_ > 0 Then
                                MediaPlan_.CampaignID = CampaignID_
                            Else
                                If MediaPlanOrig_.CampaignID > 0 Then
                                    MediaPlan_.CampaignID = MediaPlanOrig_.CampaignID
                                End If
                            End If

                            If CountryID_ > 0 Then
                                MediaPlan_.CountryID = CountryID_
                            Else
                                If MediaPlanOrig_.CountryID > 0 Then
                                    MediaPlan_.CountryID = MediaPlanOrig_.CountryID
                                End If
                            End If

                            If (StartDate_) > "01/01/1900" AndAlso (EndDate_) > "01/01/1900" Then

                                MediaPlan_.StartDate = StartDate_
                                MediaPlan_.EndDate = EndDate_
                                MediaPlan_.StartDate = CDate(MediaPlan_.StartDate.ToShortDateString)
                                MediaPlan_.EndDate = CDate(MediaPlan_.EndDate.ToShortDateString)

                            End If

                            'If MediaPlan_.CampaignID > 0 Then

                            '    Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
                            '    Dim SqlParameterMediaPlanStartDate As System.Data.SqlClient.SqlParameter = Nothing
                            '    Dim SqlParameterMediaPlanEndDate As System.Data.SqlClient.SqlParameter = Nothing

                            '    SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@campaign_id", SqlDbType.Int)
                            '    SqlParameterMediaPlanStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.VarChar)
                            '    SqlParameterMediaPlanEndDate = New System.Data.SqlClient.SqlParameter("@end_date", SqlDbType.VarChar)

                            '    SqlParameterCampaignID.Value = MediaPlan_.CampaignID
                            '    SqlParameterMediaPlanStartDate.Value = CStr(MediaPlan_.StartDate)
                            '    SqlParameterMediaPlanEndDate.Value = CStr(MediaPlan_.EndDate)

                            '    RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.CAMPAIGN WHERE CMP_IDENTIFIER = @campaign_id AND CMP_BEG_DATE <= @end_date OR CMP_END_DATE >= @start_date", SqlParameterCampaignID, SqlParameterMediaPlanEndDate, SqlParameterMediaPlanStartDate).FirstOrDefault

                            '    If RecordCount = 0 Then
                            '        MediaPlan_.CampaignID = Nothing
                            '    End If

                            'Else

                            '    MediaPlan_.CampaignID = Nothing

                            'End If

                            AdvantageFramework.Database.Procedures.MediaPlan.Update(DbContext, MediaPlan_)

                            If 1 = 1 Then

                                If (StartDate_) > "01/01/1900" AndAlso (EndDate_) > "01/01/1900" Then ' Calculate dates if needed

                                    For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlan_.ID).Include("MediaPlanDetailLevels").Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines").Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines.MediaPlanDetailLevelLineTags").ToList

                                        For Each MediaPlanDetailLevel In MediaPlanDetail.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate OrElse Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate).ToList

                                            For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                                For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                                    If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate Then

                                                        If MediaPlanDetailLevelLineTag.StartDate < MediaPlan_.StartDate OrElse MediaPlanDetailLevelLineTag.StartDate > MediaPlan_.EndDate Then

                                                            MediaPlanDetailLevelLine.Description = ""

                                                            DbContext.UpdateObject(MediaPlanDetailLevelLine)

                                                            MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                            Try

                                                                DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                            Catch ex As Exception
                                                                MediaPlanDetailLevelLineTag = Nothing
                                                            End Try

                                                        End If

                                                    ElseIf MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                                                        If MediaPlanDetailLevelLineTag.EndDate < MediaPlan_.StartDate OrElse MediaPlanDetailLevelLineTag.EndDate > MediaPlan_.EndDate Then

                                                            MediaPlanDetailLevelLine.Description = ""

                                                            DbContext.UpdateObject(MediaPlanDetailLevelLine)

                                                            MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                            Try

                                                                DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                            Catch ex As Exception
                                                                MediaPlanDetailLevelLineTag = Nothing
                                                            End Try

                                                        End If

                                                    End If

                                                Next

                                            Next

                                        Next

                                    Next

                                    For Each MediaPlanDetailLevelLineData In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, MediaPlan_.ID).Where(Function(Entity) Entity.StartDate < MediaPlan_.StartDate OrElse Entity.StartDate > MediaPlan_.EndDate).ToList

                                        DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

                                    Next

                                End If

                            End If

                            DbContext.SaveChanges()

                        End Using

                    Catch ex As Exception

                        ProcessException(ex, "APIService-NotCaught")

                        ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                            If ex.InnerException.InnerException IsNot Nothing Then

                                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                            End If

                        End If

                    End Try

                End If

            End If

        Else

            If (ErrorMessage > "") Then
                ErrorMessage = ErrorMessage + ", "
            End If

            ErrorMessage = ErrorMessage + "Invalid Media Plan ID."

        End If

        MediaPlanAddResponse = New MediaPlanAddResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            MediaPlanAddResponse.Message = ErrorMessage
            MediaPlanAddResponse.IsSuccessful = False
            MediaPlanAddResponse.PlanID = 0
        Else
            MediaPlanAddResponse.PlanID = NewMediaPlanID
            MediaPlanAddResponse.IsSuccessful = True
            MediaPlanAddResponse.Message = "INSERT_SUCCESS"
        End If

        _MediaPlanAddResponse = MediaPlanAddResponse 'For CopyMediaPlan calls

        CopyMediaPlan = MediaPlanAddResponse

    End Function

    'Private Function MediaPlanLoadDetail(DbContext As AdvantageFramework.Database.DbContext, MediaPlanID As Integer)

    '    'objects
    '    Dim DataRow As System.Data.DataRow = Nothing
    '    Dim DataColumn As System.Data.DataColumn = Nothing
    '    Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
    '    Dim MediaPlanDetailLevelLineDataList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
    '    Dim DateDayCounter As Integer = 0
    '    Dim MediaPlanDetailDate As Date = Date.MinValue
    '    Dim MediaType As String = String.Empty
    '    Dim Estimate As String = String.Empty
    '    Dim SalesClass As String = String.Empty
    '    Dim Campaign As String = String.Empty
    '    Dim Buyer As String = String.Empty
    '    Dim CampaignEntity As AdvantageFramework.Database.Entities.Campaign = Nothing
    '    Dim Campaigns As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
    '    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
    '    Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
    '    Dim EstimateBudgetAmount As Decimal = 0

    '    'Campaigns = AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).ToList
    '    'Employees = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

    '    'For Each MediaPlanDetailID In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID).Select(Function(Entity) Entity.ID).ToList

    '    '    MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID, True)

    '    '    If MediaPlanDetail IsNot Nothing Then

    '    '        MediaType = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), MediaPlanDetail.SalesClassType)
    '    '        Estimate = MediaPlanDetail.Name
    '    '        SalesClass = If(MediaPlanDetail.SalesClass IsNot Nothing, MediaPlanDetail.SalesClass.ToString, String.Empty)
    '    '        Campaign = String.Empty
    '    '        Buyer = String.Empty
    '    '        CampaignEntity = Nothing
    '    '        Employee = Nothing
    '    '        EstimateBudgetAmount = MediaPlanDetail.GrossBudgetAmount

    '    '        If MediaPlanDetail.CampaignID.GetValueOrDefault(0) > 0 Then

    '    '            Try

    '    '                CampaignEntity = Campaigns.SingleOrDefault(Function(Entity) Entity.ID = MediaPlanDetail.CampaignID.GetValueOrDefault(0))

    '    '            Catch ex As Exception
    '    '                CampaignEntity = Nothing
    '    '            End Try

    '    '        End If

    '    '        If CampaignEntity IsNot Nothing Then

    '    '            Campaign = CampaignEntity.ToString

    '    '        End If

    '    '        If String.IsNullOrWhiteSpace(MediaPlanDetail.BuyerEmployeeCode) = False Then

    '    '            Try

    '    '                Employee = Employees.SingleOrDefault(Function(Entity) Entity.Code = MediaPlanDetail.BuyerEmployeeCode)

    '    '            Catch ex As Exception
    '    '                Employee = Nothing
    '    '            End Try

    '    '        End If

    '    '        If Employee IsNot Nothing Then

    '    '            Buyer = Employee.ToString

    '    '        End If

    '    '        MediaPlanDetailLevelLineDataList = MediaPlanDetail.MediaPlanDetailLevelLineDatas.ToList

    '    '        For DateDayCounter = 0 To Math.Abs(DateDiff(DateInterval.Day, StartDate, EndDate))

    '    '            MediaPlanDetailDate = StartDate.AddDays(DateDayCounter)

    '    '            If MediaPlanDetailLevelLineDataList.Where(Function(Entity) Entity.StartDate.ToShortDateString = MediaPlanDetailDate.ToShortDateString).Any Then

    '    '                For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDataList.Where(Function(Entity) Entity.StartDate.ToShortDateString = MediaPlanDetailDate.ToShortDateString).ToList

    '    '                    DataRow = DataTable.Rows.Add()

    '    '                    DataRow(Columns.Estimate.ToString) = Estimate
    '    '                    DataRow(Columns.MediaType.ToString) = MediaType
    '    '                    DataRow(Columns.SalesClass.ToString) = SalesClass
    '    '                    DataRow(Columns.Campaign.ToString) = Campaign
    '    '                    DataRow(Columns.Buyer.ToString) = Buyer
    '    '                    DataRow(Columns.EstimateBudgetAmount.ToString) = EstimateBudgetAmount
    '    '                    DataRow(Columns.EntryDate.ToString) = MediaPlanDetailDate
    '    '                    DataRow(Columns.Demo1.ToString) = MediaPlanDetailLevelLineData.Demo1.GetValueOrDefault(0)
    '    '                    DataRow(Columns.Demo2.ToString) = MediaPlanDetailLevelLineData.Demo2.GetValueOrDefault(0)
    '    '                    DataRow(Columns.Units.ToString) = MediaPlanDetailLevelLineData.Units.GetValueOrDefault(0)
    '    '                    DataRow(Columns.Impressions.ToString) = MediaPlanDetailLevelLineData.Impressions.GetValueOrDefault(0)
    '    '                    DataRow(Columns.Clicks.ToString) = MediaPlanDetailLevelLineData.Clicks.GetValueOrDefault(0)
    '    '                    DataRow(Columns.Dollars.ToString) = MediaPlanDetailLevelLineData.Dollars.GetValueOrDefault(0)
    '    '                    DataRow(Columns.BillAmount.ToString) = MediaPlanDetailLevelLineData.BillAmount.GetValueOrDefault(0)
    '    '                    DataRow(Columns.GrossBudgetAmount.ToString) = GrossBudgetAmount

    '    '                Next

    '    '            Else

    '    '                DataRow = DataTable.Rows.Add()

    '    '                DataRow(Columns.Estimate.ToString) = Estimate
    '    '                DataRow(Columns.MediaType.ToString) = MediaType
    '    '                DataRow(Columns.SalesClass.ToString) = SalesClass
    '    '                DataRow(Columns.Campaign.ToString) = Campaign
    '    '                DataRow(Columns.Buyer.ToString) = Buyer
    '    '                DataRow(Columns.EstimateBudgetAmount.ToString) = EstimateBudgetAmount
    '    '                DataRow(Columns.EntryDate.ToString) = MediaPlanDetailDate
    '    '                DataRow(Columns.Demo1.ToString) = 0
    '    '                DataRow(Columns.Demo2.ToString) = 0
    '    '                DataRow(Columns.Units.ToString) = 0
    '    '                DataRow(Columns.Impressions.ToString) = 0
    '    '                DataRow(Columns.Clicks.ToString) = 0
    '    '                DataRow(Columns.Dollars.ToString) = 0
    '    '                DataRow(Columns.BillAmount.ToString) = 0
    '    '                DataRow(Columns.GrossBudgetAmount.ToString) = GrossBudgetAmount

    '    '            End If

    '    '        Next

    '    '    End If

    '    'Next

    'End Function

    Public Function AddMediaPlanHeader(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            Description As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                            StartDate As String, EndDate As String,
                            Optional ByVal GrossBudgetAmount As Decimal = 0, Optional ByVal Comment As String = "",
                            Optional ByVal ClientContactID As Integer = 0, Optional ByVal CampaignID As Integer = 0,
                            Optional ByVal CountryID As Integer = 1, Optional ByVal MixAndRateTemplateID As Integer = 0) As MediaPlanAddResponse Implements IAPIService.AddMediaPlanHeader


        'objects
        Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing
        Dim MediaPlanAddResponse As MediaPlanAddResponse = Nothing
        Dim PlanID_ As Integer = Nothing
        Dim CampaignID_ As Nullable(Of Integer)
        Dim ClientContactID_ As Nullable(Of Integer)
        Dim MediaPlanTemplateHeaderID_ As Nullable(Of Integer)

        Dim Clients As New Generic.List(Of Client)
        Dim Divisions As New Generic.List(Of Division)
        Dim Products As New Generic.List(Of Product)
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign

        Dim RecordCount As Nullable(Of Integer)

        Try

            Dim StartDate_ As Date = Convert.ToDateTime(StartDate)
            Dim EndDate_ As Date = Convert.ToDateTime(EndDate)

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                If StartDate > EndDate Then

                    ErrorMessage = "Please select a start date on or before the end date."

                End If

                If ErrorMessage = "" Then

                    If DateAdd(DateInterval.Month, 18, StartDate_) < EndDate_ Then

                        ErrorMessage = "Please select a date range of 18 months or less."

                    End If

                End If

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Clients = DbContext.Clients.Where(Function(Entity) Entity.Code = ClientCode AndAlso Entity.IsActive = 1).ToList

                    If Clients.Count() = 0 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Client Code."

                    Else

                        Divisions = DbContext.Divisions.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Code = DivisionCode AndAlso Entity.IsActive = 1).ToList

                        If Divisions.Count() = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Division Code."

                        Else

                            Products = DbContext.Products.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.Code = ProductCode AndAlso Entity.IsActive = 1).ToList

                            If Products.Count() = 0 Then

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Product Code."

                            End If

                        End If

                    End If

                    If CampaignID > 0 Then

                        Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(AFDbContext, CampaignID)

                            If Campaign IsNot Nothing Then

                                If ((Campaign.StartDate <= StartDate_ Or Campaign.StartDate Is Nothing) Or (Campaign.EndDate >= EndDate_ Or Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode = ProductCode) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                    'Do Nothing

                                Else
                                    If ((Campaign.StartDate <= StartDate_ Or Campaign.StartDate Is Nothing) Or (Campaign.EndDate >= EndDate_ Or Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode Is Nothing) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                        'Do Nothing

                                    Else

                                        If ((Campaign.StartDate <= StartDate_ Or Campaign.StartDate Is Nothing) Or (Campaign.EndDate >= EndDate_ Or Campaign.EndDate Is Nothing)) AndAlso
                                            (Campaign.ClientCode = ClientCode) AndAlso
                                            (Campaign.DivisionCode Is Nothing) AndAlso
                                            (Campaign.ProductCode Is Nothing) AndAlso
                                            (Campaign.IsClosed = 0) Then

                                            'Do Nothing

                                        Else

                                            If (ErrorMessage > "") Then
                                                ErrorMessage = ErrorMessage + ", "
                                            End If

                                            ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                                        End If

                                    End If

                                End If

                                CampaignID_ = CampaignID

                            Else

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                            End If

                        End Using

                    End If

                    If CountryID = 0 Then CountryID = 1 'USA

                    If CountryID > 0 Then

                        Dim SqlParameterCOUNTRY_ID As System.Data.SqlClient.SqlParameter = Nothing

                        SqlParameterCOUNTRY_ID = New System.Data.SqlClient.SqlParameter("@country_id", SqlDbType.Int)
                        SqlParameterCOUNTRY_ID.Value = CountryID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.COUNTRY WHERE COUNTRY_ID = @country_id", SqlParameterCOUNTRY_ID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Country ID."

                        End If

                    End If

                    If ClientContactID > 0 Then

                        Dim SqlParameterCDP_CONTACT_ID As System.Data.SqlClient.SqlParameter = Nothing
                        Dim SqlParameterCL_CODE As System.Data.SqlClient.SqlParameter = Nothing

                        SqlParameterCDP_CONTACT_ID = New System.Data.SqlClient.SqlParameter("@cdp_contact_id", SqlDbType.Int)
                        SqlParameterCDP_CONTACT_ID.Value = ClientContactID

                        SqlParameterCL_CODE = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                        SqlParameterCL_CODE.Value = ClientCode

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.CDP_CONTACT_HDR WHERE CDP_CONTACT_ID = @cdp_contact_id AND CL_CODE = @cl_code", SqlParameterCDP_CONTACT_ID, SqlParameterCL_CODE).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Client Contact ID."

                        End If

                    End If

                    If MixAndRateTemplateID > 0 Then

                        Dim SqlParameterTEMPLATE_ID As System.Data.SqlClient.SqlParameter = Nothing

                        SqlParameterTEMPLATE_ID = New System.Data.SqlClient.SqlParameter("@template_id", SqlDbType.Int)
                        SqlParameterTEMPLATE_ID.Value = MixAndRateTemplateID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.MEDIA_PLAN_TEMPLATE_HEADER WHERE MEDIA_PLAN_TEMPLATE_HEADER_ID = @template_id", SqlParameterTEMPLATE_ID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Mix and Rate Template ID."

                        End If

                    End If

                End Using

                If GrossBudgetAmount > 1000000000.0 Then

                    If (ErrorMessage > "") Then
                        ErrorMessage = ErrorMessage + ", "
                    End If

                    ErrorMessage = ErrorMessage + "Your Budget Amount exceeded the maximum of $1,000,000,000.00."

                End If

                CampaignID_ = CampaignID
                ClientContactID_ = ClientContactID
                MediaPlanTemplateHeaderID_ = MixAndRateTemplateID

                If ClientContactID_ = 0 Then ClientContactID_ = Nothing
                If CampaignID_ = 0 Then CampaignID_ = Nothing
                If MediaPlanTemplateHeaderID_ = 0 Then MediaPlanTemplateHeaderID_ = Nothing

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                    MediaPlan = New AdvantageFramework.Database.Entities.MediaPlan

                    MediaPlan.DbContext = DbContext

                    If String.IsNullOrWhiteSpace(Comment) Then
                        Comment = ""
                    End If

                    If String.IsNullOrWhiteSpace(Description) Then
                        Description = "New Plan - From API"
                    End If

                    MediaPlan.Description = Description
                    'MediaPlan.IsApproved = False
                    MediaPlan.ClientCode = ClientCode
                    MediaPlan.DivisionCode = DivisionCode
                    MediaPlan.ProductCode = ProductCode
                    MediaPlan.ClientContactID = ClientContactID_
                    MediaPlan.CampaignID = CampaignID_
                    MediaPlan.StartDate = StartDate
                    MediaPlan.EndDate = EndDate
                    MediaPlan.GrossBudgetAmount = GrossBudgetAmount
                    MediaPlan.Comment = Comment
                    If MediaPlanTemplateHeaderID_ > 0 Then
                        MediaPlan.SyncDetailSettings = False
                    Else
                        MediaPlan.SyncDetailSettings = True
                    End If

                    MediaPlan.SyncFieldWidths = True
                    MediaPlan.IsTemplate = False
                    MediaPlan.CountryID = CountryID
                    MediaPlan.MediaPlanTemplateHeaderID = MediaPlanTemplateHeaderID_

                    If AdvantageFramework.Database.Procedures.MediaPlan.Insert(DbContext, MediaPlan) Then

                        PlanID_ = MediaPlan.ID

                        If MediaPlanTemplateHeaderID_ > 0 Then

                            AddEstimatesByTemplateAPI(MediaPlan, APISession, ErrorMessage)

                        End If

                    Else

                        ErrorMessage = "INSERT_FAILED"

                    End If

                End Using

            Catch ex As Exception

                ProcessException(ex, "APIService-NotCaught")

                ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                    If ex.InnerException.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                    End If

                End If

            End Try

        End If

        MediaPlanAddResponse = New MediaPlanAddResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            MediaPlanAddResponse.Message = ErrorMessage
            MediaPlanAddResponse.IsSuccessful = False
            MediaPlanAddResponse.PlanID = 0
        Else
            MediaPlanAddResponse.PlanID = PlanID_
            MediaPlanAddResponse.IsSuccessful = True
            MediaPlanAddResponse.Message = "INSERT_SUCCESS"
        End If

        AddMediaPlanHeader = MediaPlanAddResponse

        'End Sub
    End Function

    Private Sub AddEstimatesByTemplateAPI(MediaPlan As AdvantageFramework.Database.Entities.MediaPlan,
                                       ByRef APISession As AdvantageFramework.Security.APISession,
                                       ByRef ErrorMessage As String)

        'objects
        Dim MediaPlanClass As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Dim MediaPlanTemplateHeaderID As Integer = 0
        Dim MediaPlanTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanTemplateDetail) = Nothing
        Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
        Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
        Dim SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
        Dim TotalGrossBudgetAmount As Decimal = 0
        Dim OrderNumber As Integer = 0

        Dim _AddedFromMediaPlanTemplate As Boolean

        _AddedFromMediaPlanTemplate = True

        Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

            MediaPlanClass = New AdvantageFramework.MediaPlanning.Classes.MediaPlan(APISession.ConnectionString, APISession.UserCode, MediaPlan.ID)

            MediaPlanTemplateHeaderID = MediaPlan.MediaPlanTemplateHeaderID

            MediaPlanTemplateDetails = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateDetail)
                                        Where Entity.MediaPlanTemplateHeaderID = MediaPlanTemplateHeaderID
                                        Select Entity).ToList

            For Each MediaPlanTemplateDetail In MediaPlanTemplateDetails

                Try

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanTemplateDetail.MediaPlanEstimateTemplateID)

                    MediaPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanDetail

                    MediaPlanDetail.MediaPlanDetailLevelLineDatas = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)
                    MediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)
                    MediaPlanDetail.MediaPlanDetailLevels = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel)
                    MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailField)
                    MediaPlanDetail.MediaPlanDetailLevelLineTags = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag)
                    MediaPlanDetail.MediaPlanDetailSettings = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailSetting)
                    MediaPlanDetail.MediaPlanDetailChangeLogs = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailChangeLog)
                    MediaPlanDetail.DigitalResults = New HashSet(Of AdvantageFramework.Database.Entities.DigitalResult)
                    MediaPlanDetail.MediaPlanDetailPackageDetails = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail)
                    MediaPlanDetail.MediaPlanDetailPackagePlacementNames = New HashSet(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

                    MediaPlanDetail.DbContext = DbContext

                    MediaPlanDetail.SalesClassType = MediaPlanEstimateTemplate.Type
                    MediaPlanDetail.SalesClassCode = MediaPlanTemplateDetail.SalesClassCode
                    MediaPlanDetail.Name = MediaPlanEstimateTemplate.Description
                    MediaPlanDetail.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen
                    MediaPlanDetail.PeriodType = MediaPlanTemplateDetail.PeriodType
                    MediaPlanDetail.GrossBudgetAmount = Math.Round(MediaPlanClass.GrossBudgetAmount.GetValueOrDefault(0) * MediaPlanTemplateDetail.Percentage / 100, 2, MidpointRounding.AwayFromZero)

                    TotalGrossBudgetAmount += MediaPlanDetail.GrossBudgetAmount

                    If MediaPlanTemplateDetails.Last.Equals(MediaPlanTemplateDetail) AndAlso MediaPlanTemplateDetails.Any(Function(MPTD) MPTD.Percentage <> 0) AndAlso TotalGrossBudgetAmount <> MediaPlanClass.GrossBudgetAmount.GetValueOrDefault(0) Then

                        If TotalGrossBudgetAmount > MediaPlanClass.GrossBudgetAmount.GetValueOrDefault(0) Then

                            MediaPlanDetail.GrossBudgetAmount -= TotalGrossBudgetAmount - MediaPlanClass.GrossBudgetAmount.GetValueOrDefault(0)

                        Else

                            MediaPlanDetail.GrossBudgetAmount += MediaPlanClass.GrossBudgetAmount.GetValueOrDefault(0) - TotalGrossBudgetAmount

                        End If

                    End If

                    MediaPlanDetail.ShowColumnGrandTotals = True
                    MediaPlanDetail.ShowRowGrandTotals = False
                    MediaPlanDetail.ShowColumnTotals = False
                    MediaPlanDetail.ShowRowTotals = False

                    Using DataContext As New AdvantageFramework.Database.DataContext(APISession.ConnectionString, APISession.UserCode)

                        If AdvantageFramework.Agency.LoadMediaPlanningAddLinesToExistingOrder(DataContext) Then

                            MediaPlanDetail.CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.AddToOrder

                        Else

                            MediaPlanDetail.CreateOrderOption = AdvantageFramework.MediaPlanning.CreateOrderOptions.Default

                        End If

                    End Using

                    SalesClassTypeEnumObject = AdvantageFramework.EnumUtilities.LoadEnumObject(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), MediaPlanDetail.SalesClassType)

                    Try

                        If SalesClassTypeEnumObject.Code = "R" OrElse
                                SalesClassTypeEnumObject.Code = "T" OrElse
                                SalesClassTypeEnumObject.Code = "M" Then

                            MediaPlanDetail.IsEstimateGrossAmount = True

                        ElseIf SalesClassTypeEnumObject.Code = "I" OrElse
                                SalesClassTypeEnumObject.Code = "N" OrElse
                                SalesClassTypeEnumObject.Code = "O" Then

                            MediaPlanDetail.IsEstimateGrossAmount = False

                        Else

                            MediaPlanDetail.IsEstimateGrossAmount = False

                        End If

                    Catch ex As Exception
                        MediaPlanDetail.IsEstimateGrossAmount = False
                    End Try

                    Try

                        If SalesClassTypeEnumObject.Code = "R" OrElse SalesClassTypeEnumObject.Code = "T" Then

                            MediaPlanDetail.IsCalendarMonth = False
                            MediaPlanDetail.SplitWeeks = False

                        Else

                            MediaPlanDetail.IsCalendarMonth = True
                            MediaPlanDetail.SplitWeeks = True

                        End If

                    Catch ex As Exception
                        MediaPlanDetail.IsCalendarMonth = True
                    End Try

                    MediaPlanDetail.CampaignID = MediaPlan.CampaignID '4894-1-4389 - campaign carries down to the estimates on that plan

                    MediaPlanDetail.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID

                    If MediaPlanClass.AddMediaPlanEstimate(MediaPlanDetail, OrderNumber) Then

                        MediaPlanClass.SelectMediaPlanEstimate(OrderNumber)

                        AdvantageFramework.Media.Presentation.AddEstimateLevelsLinesBudget(MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplate.Type, MediaPlanClass, _AdvSession, MediaPlanDetail.GrossBudgetAmount, False)

                    End If

                Catch ex As Exception

                    ProcessException(ex, "APIService-NotCaught")

                    ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                    If ex.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                        If ex.InnerException.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                        End If

                    End If

                End Try

            Next

        End Using

    End Sub

    Public Function LoadMixRateTemplates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As MediaPlanMixRateTemplatesResponse Implements IAPIService.LoadMixRateTemplates

        'objects
        Dim MixRateTemplates As Generic.List(Of MixRateTemplates) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim MediaPlanMixRateTemplatesResponse As MediaPlanMixRateTemplatesResponse = Nothing
        Dim ErrorMessage As String = Nothing

        MixRateTemplates = New Generic.List(Of MixRateTemplates)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadInactive Then

                        MixRateTemplates = DbContext.Database.SqlQuery(Of MixRateTemplates)(String.Format("SELECT DISTINCT X.MEDIA_PLAN_TEMPLATE_HEADER_ID ID, X.DESCRIPTION Description,X.IS_INACTIVE 'IsInactive' FROM MEDIA_PLAN_TEMPLATE_HEADER X WITH(NOLOCK);")).ToList

                    Else

                        MixRateTemplates = DbContext.Database.SqlQuery(Of MixRateTemplates)(String.Format("SELECT DISTINCT X.MEDIA_PLAN_TEMPLATE_HEADER_ID ID, X.DESCRIPTION Description, X.IS_INACTIVE 'IsInactive' FROM MEDIA_PLAN_TEMPLATE_HEADER X WITH(NOLOCK) WHERE (X.IS_INACTIVE = 0);")).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            MixRateTemplates = New Generic.List(Of MixRateTemplates)
        End Try

        MediaPlanMixRateTemplatesResponse = New MediaPlanMixRateTemplatesResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            MediaPlanMixRateTemplatesResponse.Message = ErrorMessage
            MediaPlanMixRateTemplatesResponse.IsSuccessful = False
            MediaPlanMixRateTemplatesResponse.Results = Nothing
        Else
            MediaPlanMixRateTemplatesResponse.Results = MixRateTemplates
            MediaPlanMixRateTemplatesResponse.Message = CStr(MediaPlanMixRateTemplatesResponse.Results.Count) + " records"
        End If

        LoadMixRateTemplates = MediaPlanMixRateTemplatesResponse

    End Function

    Public Function AddBroadcastWorksheetHeader(
                            ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            MediaTypeCode As String, Name As String,
                            ClientCode As String, DivisionCode As String, ProductCode As String,
                            SalesClassCode As String,
                            MediaBroadcastWorksheetDateTypeID As Integer, MediaCalendarTypeID As Integer,
                            StartDate As String, EndDate As String,
                            IsInactive As Boolean,
                            ProrateSecondaryDemosToPrimary As Boolean,
                            IsGross As Boolean,
                            DefaultToLatestSharebook As Boolean,
                            Optional RatingsServiceID As Integer = Nothing,
                            Optional PrimaryMediaDemographicID As Integer = Nothing,
                            Optional MediaPlanID As Integer = Nothing,
                            Optional CampaignID As Integer = Nothing,
                            Optional CountryID As Integer = 1,
                            Optional Length As Integer = 0,
                            Optional Comment As String = Nothing
        ) As BroadcastWorksheetAddResponse Implements IAPIService.AddBroadcastWorksheetHeader

        'objects

        Dim APISession As AdvantageFramework.Security.APISession = Nothing
        Dim ErrorMessage As String = Nothing
        Dim BroadcastWorksheetAddResponse As BroadcastWorksheetAddResponse = Nothing

        Dim ViewModel_ As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel = Nothing
        Dim Controller_ As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Dim Worksheet_ As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Dim MediaBroadcastWorksheetEditViewModel_ As New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel
        Dim MediaDemographics_ As New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)
        Dim Found_ As Boolean = False
        Dim MediaBroadcastWorksheetID_ As Integer = 0

        Dim CampaignID_ As Nullable(Of Integer)
        Dim MediaPlanID_ As Nullable(Of Integer)
        Dim CountryID_ As Nullable(Of Integer)
        'Dim RatingsServiceID_ As Nullable(Of Integer)
        Dim PrimaryMediaDemographicID_ As Nullable(Of Integer)
        Dim ProrateSecondaryDemosToPrimary_ As Nullable(Of Boolean)
        Dim ArePiggybacksOK As Nullable(Of Boolean) = False

        Dim Clients As New Generic.List(Of Client)
        Dim Divisions As New Generic.List(Of Division)
        Dim Products As New Generic.List(Of Product)
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign

        Dim RecordCount As Nullable(Of Integer)
        Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterID2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCODE As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCODE2 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCODE3 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCODE4 As System.Data.SqlClient.SqlParameter = Nothing
        Dim SqlParameterCODE5 As System.Data.SqlClient.SqlParameter = Nothing

        Dim X As Integer
        Dim S As String

        Try

            Dim StartDate_ As Date = Convert.ToDateTime(StartDate)
            Dim EndDate_ As Date = Convert.ToDateTime(EndDate)

            'If String.IsNullOrWhiteSpace(ProrateSecondaryDemosToPrimary) = True OrElse (ProrateSecondaryDemosToPrimary <> "1" AndAlso ProrateSecondaryDemosToPrimary <> "0") Then
            '    ProrateSecondaryDemosToPrimary_ = False
            'Else
            '    ProrateSecondaryDemosToPrimary_ = Convert.ToBoolean(ProrateSecondaryDemosToPrimary)
            'End If

            ProrateSecondaryDemosToPrimary_ = ProrateSecondaryDemosToPrimary

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                ViewModel_ = New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel
                Controller_ = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(_AdvSession)
                Worksheet_ = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
                ViewModel_.Worksheet = Worksheet_

                If StartDate > EndDate Then

                    ErrorMessage = "Please select a start date on or before the end date."

                End If

                If ErrorMessage = "" Then

                    If DateAdd(DateInterval.Month, 18, StartDate_) < EndDate_ Then

                        ErrorMessage = "Please select a date range of 18 months or less."

                    End If

                End If

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    Clients = DbContext.Clients.Where(Function(Entity) Entity.Code = ClientCode AndAlso Entity.IsActive = 1).ToList

                    If Clients.Count() = 0 Then

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Client Code."

                    Else

                        Divisions = DbContext.Divisions.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Code = DivisionCode AndAlso Entity.IsActive = 1).ToList

                        If Divisions.Count() = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Division Code."

                        Else

                            Products = DbContext.Products.Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.Code = ProductCode AndAlso Entity.IsActive = 1).ToList

                            If Products.Count() = 0 Then

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Product Code."

                            End If

                        End If

                    End If

                    If CampaignID > 0 Then

                        Using AFDbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(AFDbContext, CampaignID)

                            If Campaign IsNot Nothing Then

                                If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode = ProductCode) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                    'Do Nothing

                                Else
                                    If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                        (Campaign.ClientCode = ClientCode) AndAlso
                                        (Campaign.DivisionCode = DivisionCode) AndAlso
                                        (Campaign.ProductCode Is Nothing) AndAlso
                                        (Campaign.IsClosed = 0) Then

                                        'Do Nothing

                                    Else

                                        If ((Campaign.StartDate <= StartDate_ OrElse Campaign.StartDate Is Nothing) OrElse (Campaign.EndDate >= EndDate_ OrElse Campaign.EndDate Is Nothing)) AndAlso
                                            (Campaign.ClientCode = ClientCode) AndAlso
                                            (Campaign.DivisionCode Is Nothing) AndAlso
                                            (Campaign.ProductCode Is Nothing) AndAlso
                                            (Campaign.IsClosed = 0) Then

                                            'Do Nothing

                                        Else

                                            If (ErrorMessage > "") Then
                                                ErrorMessage = ErrorMessage + ", "
                                            End If

                                            ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                                        End If

                                    End If

                                End If

                                CampaignID_ = CampaignID

                            Else

                                If (ErrorMessage > "") Then
                                    ErrorMessage = ErrorMessage + ", "
                                End If

                                ErrorMessage = ErrorMessage + "Invalid Campaign ID."

                            End If

                        End Using

                    End If

                    If (MediaTypeCode = "T" OrElse MediaTypeCode = "R") Then
                        'Do Nothing
                    Else

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Media Type Code."

                    End If

                    If SalesClassCode > "" Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@sales_class_code", SqlDbType.VarChar)
                        SqlParameterID.Value = SalesClassCode

                        SqlParameterCODE = New System.Data.SqlClient.SqlParameter("@media_type_code", SqlDbType.VarChar)
                        SqlParameterCODE.Value = MediaTypeCode

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.SALES_CLASS WHERE SC_CODE = @sales_class_code AND (SC_TYPE = @media_type_code OR SC_TYPE IS NULL) AND ISNULL(INACTIVE_FLAG, 0) = 0", SqlParameterID, SqlParameterCODE).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Sales Class Code."

                        End If

                    Else

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Sales Class Code."

                    End If

                    If MediaCalendarTypeID > 0 Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@media_calendar_type_id", SqlDbType.Int)
                        SqlParameterID.Value = MediaCalendarTypeID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.BROADCAST_TYPE WHERE BROADCAST_TYPE_ID = @media_calendar_type_id", SqlParameterID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Media Calendar Type ID."

                        End If

                    End If

                    If MediaBroadcastWorksheetDateTypeID > 0 Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@media_broadcast_worksheet_date_type_id", SqlDbType.Int)
                        SqlParameterID.Value = MediaBroadcastWorksheetDateTypeID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.MEDIA_BROADCAST_WORKSHEET_DATE_TYPE WHERE MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID = @media_broadcast_worksheet_date_type_id", SqlParameterID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Media Date Type ID."

                        End If

                    End If

                    If CountryID = 0 Then CountryID = 1 'USA

                    If CountryID > 0 Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@country_id", SqlDbType.Int)
                        SqlParameterID.Value = CountryID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.COUNTRY WHERE COUNTRY_ID = @country_id", SqlParameterID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Country ID."

                        End If

                    End If

                    If MediaPlanID > 0 Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@id", SqlDbType.Int)
                        SqlParameterID.Value = MediaPlanID
                        SqlParameterCODE = New System.Data.SqlClient.SqlParameter("@cl_code", SqlDbType.VarChar)
                        SqlParameterCODE.Value = ClientCode
                        SqlParameterCODE2 = New System.Data.SqlClient.SqlParameter("@div_code", SqlDbType.VarChar)
                        SqlParameterCODE2.Value = DivisionCode
                        SqlParameterCODE3 = New System.Data.SqlClient.SqlParameter("@prd_code", SqlDbType.VarChar)
                        SqlParameterCODE3.Value = ProductCode
                        'SqlParameterCODE4 = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
                        'SqlParameterCODE4.Value = MediaTypeCode

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.MEDIA_PLAN " &
                                                                            " A JOIN dbo.MEDIA_PLAN_DTL AS B ON A.MEDIA_PLAN_ID = B.MEDIA_PLAN_ID" &
                                                                            " AND A.MEDIA_PLAN_ID = @id AND ISNULL(A.IS_INACTIVE, 0) = 0" &
                                                                            " WHERE (A.CL_CODE = @cl_code) AND (A.DIV_CODE = @div_code) AND" &
                                                                            " (A.PRD_CODE = @prd_code) AND (B.SC_TYPE IN ('R','T'))",
                                                                            SqlParameterID,
                                                                            SqlParameterCODE, SqlParameterCODE2,
                                                                            SqlParameterCODE3).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Media Plan ID."

                        End If

                    End If

                End Using

                'RatingsServiceID_ = RatingsServiceID
                PrimaryMediaDemographicID_ = PrimaryMediaDemographicID
                MediaPlanID_ = MediaPlanID
                CampaignID_ = CampaignID
                CountryID_ = CountryID

                'If RatingsServiceID_ = 0 Then RatingsServiceID_ = Nothing
                If PrimaryMediaDemographicID_ = 0 Then PrimaryMediaDemographicID_ = Nothing
                If MediaPlanID_ = 0 Then MediaPlanID_ = Nothing
                If CampaignID_ = 0 Then CampaignID_ = Nothing
                If Comment = "" Then Comment = Nothing

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")

            ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If
        End Try

        If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                    If String.IsNullOrWhiteSpace(Name) Then
                        Name = "New Plan from API - " + DateTime.Now.ToString("yyyyMMdd.hhmmss")
                    End If

                    If RatingsServiceID = 0 Then
                        RatingsServiceID = 1  'Nielsen
                    End If

                    ViewModel_.Worksheet.MediaTypeCode = MediaTypeCode
                    ViewModel_.Worksheet.Name = Name
                    ViewModel_.Worksheet.ClientCode = ClientCode
                    ViewModel_.Worksheet.DivisionCode = DivisionCode
                    ViewModel_.Worksheet.ProductCode = ProductCode
                    ViewModel_.Worksheet.SalesClassCode = SalesClassCode

                    ViewModel_.Worksheet.MediaBroadcastWorksheetDateTypeID = MediaBroadcastWorksheetDateTypeID
                    ViewModel_.Worksheet.MediaCalendarTypeID = MediaCalendarTypeID
                    ViewModel_.Worksheet.StartDate = StartDate
                    ViewModel_.Worksheet.EndDate = EndDate
                    ViewModel_.Worksheet.IsInactive = IsInactive
                    ViewModel_.Worksheet.ProrateSecondaryDemosToPrimary = ProrateSecondaryDemosToPrimary
                    ViewModel_.Worksheet.IsGross = IsGross
                    ViewModel_.Worksheet.DefaultToLatestSharebook = DefaultToLatestSharebook

                    ViewModel_.Worksheet.RatingsServiceID = RatingsServiceID
                    ViewModel_.Worksheet.PrimaryMediaDemographicID = PrimaryMediaDemographicID_
                    ViewModel_.Worksheet.MediaPlanID = MediaPlanID_
                    ViewModel_.Worksheet.CampaignID = CampaignID_
                    ViewModel_.Worksheet.CountryID = CountryID

                    ViewModel_.Worksheet.Length = Length
                    ViewModel_.Worksheet.Comment = Comment

                    ViewModel_.Worksheet.ArePiggybacksOK = ArePiggybacksOK

                    'Nielsen = 1
                    'Comscore = 2
                    'Numeris = 3
                    'OzTAM = 4 (Australia)

                    If (RatingsServiceID > 0) Then

                        MediaBroadcastWorksheetEditViewModel_.Worksheet = ViewModel_.Worksheet

                        Controller_.Edit_LoadDemoSource(MediaBroadcastWorksheetEditViewModel_)

                        For X = 0 To (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Count - 1) AndAlso Found_ = False
                            If RatingsServiceID = (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Item(X).Value) Then
                                Found_ = True
                            End If
                        Next X

                        If Found_ = False Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Rating Service ID."
                        Else

                            RecordCount = 0 'Reset

                            If PrimaryMediaDemographicID > 0 Then

                                S = "SELECT 1 FROM MEDIA_DEMO  WITH(NOLOCK)" +
                                " WHERE TYPE = '" + MediaTypeCode + "' AND IS_INACTIVE = 0" +
                                " AND MEDIA_DEMO_SOURCE_ID = " + CStr(RatingsServiceID - 1) +
                                " AND MEDIA_DEMO_ID = " + CStr(PrimaryMediaDemographicID) +
                                " ORDER BY DESCRIPTION;"

                                RecordCount = DbContext.Database.SqlQuery(Of Int32)(S).FirstOrDefault


                                'MediaDemographics_ = AdvantageFramework.Database.Procedures.MediaDemographic.Load(DbContext).
                                '    Where(Function(Entity) Entity.ID = PrimaryMediaDemographicID).
                                '    OrderBy(Function(Entity) Entity.Description).ToList.Select(Function(Entity)
                                '                                                                   Return New AdvantageFramework.DTO.Media.MediaDemographic(Entity)
                                '                                                               End Function).ToList

                                'MediaBroadcastWorksheetEditViewModel_.MediaDemographics = MediaDemographics_

                                'Controller_.Edit_LoadPrimaryMediaDemographics(MediaBroadcastWorksheetEditViewModel_, MediaTypeCode, RatingsServiceID)

                                'For X = 0 To (MediaBroadcastWorksheetEditViewModel_.MediaDemographics.Count - 1) AndAlso Found_ = False
                                '    If PrimaryMediaDemographicID = (MediaBroadcastWorksheetEditViewModel_.MediaDemographics.Item(X).ID) Then
                                '        Found_ = True
                                '    End If
                                'Next X

                                If RecordCount = 0 Then

                                    If (ErrorMessage > "") Then
                                        ErrorMessage = ErrorMessage + ", "
                                    End If

                                    ErrorMessage = ErrorMessage + "Invalid Primary Rating Demo ID."

                                End If

                            Else

                                PrimaryMediaDemographicID = 0

                            End If

                        End If

                    Else

                        RatingsServiceID = 0

                    End If

                    '/** ADD WORKSHEET HERE **/
                    Controller_.Edit_Add(ViewModel_, ErrorMessage)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        MediaBroadcastWorksheetID_ = ViewModel_.Worksheet.ID

                        'MediaBroadcastWorksheetID_ = DbContext.Database.SqlQuery(Of Int32)("SELECT MAX(MEDIA_BROADCAST_WORKSHEET_ID) FROM dbo.MEDIA_BROADCAST_WORKSHEET").FirstOrDefault

                    Else

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = "INSERT_FAILED - " + ErrorMessage

                    End If

                End Using

            Catch ex As Exception

                ProcessException(ex, "APIService-NotCaught")

                ErrorMessage = "Critical Failure in API" & System.Environment.NewLine & System.Environment.NewLine & ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                    If ex.InnerException.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.InnerException.Message

                    End If

                End If

            End Try

        End If

        BroadcastWorksheetAddResponse = New BroadcastWorksheetAddResponse

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            BroadcastWorksheetAddResponse.Message = ErrorMessage
            BroadcastWorksheetAddResponse.IsSuccessful = False
            BroadcastWorksheetAddResponse.WorksheetID = 0
        Else
            BroadcastWorksheetAddResponse.WorksheetID = MediaBroadcastWorksheetID_
            BroadcastWorksheetAddResponse.IsSuccessful = True
            BroadcastWorksheetAddResponse.Message = "INSERT_SUCCESS"
        End If

        AddBroadcastWorksheetHeader = BroadcastWorksheetAddResponse

        'End Sub
    End Function

    Public Function LoadMediaBroadcastWorksheetDateTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As BasicIDNames Implements IAPIService.LoadMediaBroadcastWorksheetDateTypes

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As BasicIDNames = Nothing
        Dim ErrorMessage As String = Nothing

        Dim BasicIDNames As New List(Of BasicIDName)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    BasicIDNames = DbContext.Database.SqlQuery(Of BasicIDName)(String.Format("SELECT MEDIA_BROADCAST_WORKSHEET_DATE_TYPE_ID ID, NAME 'NAME' FROM MEDIA_BROADCAST_WORKSHEET_DATE_TYPE WITH(NOLOCK);")).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            BasicIDNames = New Generic.List(Of BasicIDName)
        End Try

        ResultAPIResponse = New BasicIDNames


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = BasicIDNames
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadMediaBroadcastWorksheetDateTypes = ResultAPIResponse

    End Function

    Public Function LoadMediaCalendarTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As BasicIDNames Implements IAPIService.LoadMediaCalendarTypes

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As BasicIDNames = Nothing
        Dim ErrorMessage As String = Nothing

        Dim BasicIDNames As New List(Of BasicIDName)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    BasicIDNames = DbContext.Database.SqlQuery(Of BasicIDName)(String.Format("SELECT MEDIA_CALENDAR_TYPE_ID ID, NAME 'NAME' FROM MEDIA_CALENDAR_TYPE WITH(NOLOCK);")).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            BasicIDNames = New Generic.List(Of BasicIDName)
        End Try

        ResultAPIResponse = New BasicIDNames


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = BasicIDNames
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadMediaCalendarTypes = ResultAPIResponse

    End Function

    Public Function LoadRatingsServiceIDs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                          MediaTypeCode As String, CountryID As Integer) As BasicIDNames Implements IAPIService.LoadRatingsServiceIDs

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As BasicIDNames = Nothing
        Dim ErrorMessage As String = Nothing

        Dim RecordCount As Nullable(Of Integer)
        Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing

        Dim BasicIDNames As New List(Of BasicIDName)
        Dim BasicIDName As New BasicIDName

        Dim ViewModel_ As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel = Nothing
        Dim Controller_ As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Dim Worksheet_ As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Dim MediaBroadcastWorksheetEditViewModel_ As New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel

        Dim X As Integer

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If (MediaTypeCode = "T" OrElse MediaTypeCode = "R") Then
                        'Do Nothing
                    Else

                        If (ErrorMessage > "") Then
                            ErrorMessage = ErrorMessage + ", "
                        End If

                        ErrorMessage = ErrorMessage + "Invalid Media Type Code."

                    End If

                    If CountryID = 0 Then CountryID = 1 'USA

                    If CountryID > 0 Then

                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@country_id", SqlDbType.Int)
                        SqlParameterID.Value = CountryID

                        RecordCount = DbContext.Database.SqlQuery(Of Int32)("SELECT COUNT(*) FROM dbo.COUNTRY WHERE COUNTRY_ID = @country_id", SqlParameterID).FirstOrDefault

                        If RecordCount = 0 Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Country ID."

                        End If

                    End If

                    ViewModel_ = New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel
                    Controller_ = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(_AdvSession)
                    Worksheet_ = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
                    ViewModel_.Worksheet = Worksheet_

                    ViewModel_.Worksheet.MediaTypeCode = MediaTypeCode
                    ViewModel_.Worksheet.CountryID = CountryID

                    Controller_ = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(_AdvSession)

                    MediaBroadcastWorksheetEditViewModel_.Worksheet = ViewModel_.Worksheet

                    Controller_.Edit_LoadDemoSource(MediaBroadcastWorksheetEditViewModel_)

                    For X = 0 To (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Count - 1)

                        BasicIDName = New BasicIDName

                        BasicIDName.ID = (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Item(X).Value)
                        BasicIDName.Name = (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Item(X).Display)
                        BasicIDNames.Add(BasicIDName)

                    Next X

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            BasicIDNames = New Generic.List(Of BasicIDName)
        End Try

        ResultAPIResponse = New BasicIDNames


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = BasicIDNames
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadRatingsServiceIDs = ResultAPIResponse

    End Function

    Public Function LoadPrimaryMediaDemographicIDs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                            MediaTypeCode As String, CountryID As Integer, RatingsServiceID As Integer) As BasicIDNames Implements IAPIService.LoadPrimaryMediaDemographicIDs

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As BasicIDNames = Nothing
        Dim ErrorMessage As String = Nothing

        Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing

        Dim BasicIDNames As New List(Of BasicIDName)
        Dim BasicIDName As New BasicIDName

        Dim ViewModel_ As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel = Nothing
        Dim Controller_ As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Dim Worksheet_ As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Dim MediaBroadcastWorksheetEditViewModel_ As New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel

        Dim MediaDemographics_ As New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)
        Dim Found_ As Boolean = False
        Dim MediaBroadcastWorksheetID_ As Integer = 0

        Dim X As Integer
        Dim S As String

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                    ViewModel_ = New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel
                    Controller_ = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(_AdvSession)
                    Worksheet_ = New AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
                    ViewModel_.Worksheet = Worksheet_

                    ViewModel_.Worksheet.MediaTypeCode = MediaTypeCode
                    ViewModel_.Worksheet.CountryID = CountryID

                    If (RatingsServiceID > 0) Then

                        MediaBroadcastWorksheetEditViewModel_.Worksheet = ViewModel_.Worksheet

                        Controller_.Edit_LoadDemoSource(MediaBroadcastWorksheetEditViewModel_)

                        For X = 0 To (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Count - 1) AndAlso Found_ = False
                            If RatingsServiceID = (MediaBroadcastWorksheetEditViewModel_.RatingsServiceList.Item(X).Value) Then
                                Found_ = True
                            End If
                        Next X

                        If Found_ = False Then

                            If (ErrorMessage > "") Then
                                ErrorMessage = ErrorMessage + ", "
                            End If

                            ErrorMessage = ErrorMessage + "Invalid Rating Service ID."
                        Else

                            S = "SELECT MEDIA_DEMO_ID ID, DESCRIPTION 'NAME' FROM MEDIA_DEMO  WITH(NOLOCK)" +
                                " WHERE TYPE = '" + MediaTypeCode + "' AND IS_INACTIVE = 0" +
                                " AND MEDIA_DEMO_SOURCE_ID = " + CStr(RatingsServiceID - 1) +
                                " ORDER BY DESCRIPTION;"

                            BasicIDNames = DbContext.Database.SqlQuery(Of BasicIDName)(String.Format(S)).ToList

                        End If

                    Else

                        RatingsServiceID = 0

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            BasicIDNames = New Generic.List(Of BasicIDName)
        End Try

        ResultAPIResponse = New BasicIDNames


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = BasicIDNames
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadPrimaryMediaDemographicIDs = ResultAPIResponse

    End Function

    Public Function LoadPurchaseOrders(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String
                                            ) As PurchaseOrderResponse Implements IAPIService.LoadPurchaseOrders

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As PurchaseOrderResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing

        Dim PurchaseOrders As New List(Of PurchaseOrder)

        Dim X As Integer
        Dim Sql As String

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                    If (1 = 1) Then


                        Sql = "SELECT A.PO_NUMBER PurchaseOrderNumber, A.PO_DESCRIPTION PurchaseOrderDescription, A.PO_DATE PurchaseOrderDate, B.LINE_NUMBER LineNumber, B.LINE_DESC LineDescription," +
                                " B.JOB_NUMBER JobNumber, B.JOB_COMPONENT_NBR JobComponentNumber, B.FNC_CODE FunctionCode, B.GLACODE GLAccountCode, B.PO_EXT_AMOUNT LineExtendedAmount" +
                                " FROM PURCHASE_ORDER A JOIN PURCHASE_ORDER_DET B WITH(NOLOCK) ON A.PO_NUMBER = B.PO_NUMBER" +
                                " WHERE ISNULL(A.PO_COMPLETE, 0) = 0" +
                                " ORDER BY A.PO_NUMBER;"

                        PurchaseOrders = DbContext.Database.SqlQuery(Of PurchaseOrder)(String.Format(Sql)).ToList

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            PurchaseOrders = New Generic.List(Of PurchaseOrder)
        End Try

        ResultAPIResponse = New PurchaseOrderResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = PurchaseOrders
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadPurchaseOrders = ResultAPIResponse

    End Function

    Public Function LoadGLAccounts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String
                                            ) As GeneralLedgerAccountResponse Implements IAPIService.LoadGLAccounts

        'objects
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As GeneralLedgerAccountResponse = Nothing
        Dim ErrorMessage As String = Nothing

        Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing

        Dim GLAccounts As New List(Of GeneralLedgerAccount)

        Dim AccountType As String

        Dim X As Integer
        Dim Sql As String

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(APISession.ConnectionString, APISession.UserCode)

                    If (1 = 1) Then

                        Sql = "SELECT GLAccountCode = GLACODE, GLAccountNumberDescription = GLADESC, GLAccountTypeCode = GLATYPE, GLAccountTypeDescription = NULL" +
                                " FROM GLACCOUNT WITH(NOLOCK)" +
                                " WHERE ISNULL(GLAACTIVE, 'X') = 'A'" +
                                " ORDER BY GLACODE;"

                        GLAccounts = DbContext.Database.SqlQuery(Of GeneralLedgerAccount)(String.Format(Sql)).ToList

                        For X = 0 To (GLAccounts.Count - 1)
                            AccountType = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes),
                                                                                          CInt(GLAccounts.Item(X).GLAccountTypeCode))
                            GLAccounts.Item(X).GLAccountTypeDescription = AccountType
                        Next X

                    End If

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            GLAccounts = New Generic.List(Of GeneralLedgerAccount)
        End Try

        ResultAPIResponse = New GeneralLedgerAccountResponse


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = GLAccounts
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadGLAccounts = ResultAPIResponse

    End Function

    Public Function LoadCampaignsWithDates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As List(Of CampaignWithDates) Implements IAPIService.LoadCampaignsWithDates

        'objects
        Dim Campaigns As Generic.List(Of CampaignWithDates) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim sql As String

        Campaigns = New Generic.List(Of CampaignWithDates)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, "") Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadClosed Then

                        'Campaigns = DbContext.Campaigns.ToList

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " ORDER BY CMP_CODE;"

                    Else

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " WHERE ISNULL(CMP_CLOSED, 0) = 0" +
                            " ORDER BY CMP_CODE;"

                        'Campaigns = DbContext.Campaigns.Where(Function(Entity) Entity.IsClosed = 0).ToList

                    End If

                    Campaigns = DbContext.Database.SqlQuery(Of CampaignWithDates)(String.Format(sql)).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Campaigns = New Generic.List(Of CampaignWithDates)
        End Try

        LoadCampaignsWithDates = Campaigns

    End Function
    Public Function LoadCampaigns2WithDates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As CampaignAPIResponseWithDates Implements IAPIService.LoadCampaigns2WithDates

        'objects
        Dim Campaigns As Generic.List(Of CampaignWithDates) = Nothing
        Dim APISession As AdvantageFramework.Security.APISession = Nothing

        Dim ResultAPIResponse As CampaignAPIResponseWithDates = Nothing
        Dim ErrorMessage As String = Nothing

        Dim sql As String

        Dim Campaign As Campaign

        Campaigns = New Generic.List(Of CampaignWithDates)

        Try

            If LoginToAPI(ServerName, DatabaseName, UseWindowsAuthentication, UserName, Password, APISession, ErrorMessage) Then

                Using DbContext = New APIDbContext(APISession.ConnectionString, APISession.UserCode)

                    If LoadClosed Then

                        'Campaigns = DbContext.Campaigns.ToList

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " ORDER BY CMP_CODE;"

                    Else

                        sql = "SELECT ID=CMP_IDENTIFIER, ClientCode=CL_CODE, DivisionCode=DIV_CODE, ProductCode=PRD_CODE, Code=CMP_CODE, Name=CMP_NAME, IsClosed=CMP_CLOSED, IsActive=ACTIVE_FLAG, BeginDate=CMP_BEG_DATE, EndDate=CMP_END_DATE" +
                            " FROM CAMPAIGN WITH(NOLOCK)" +
                            " WHERE ISNULL(CMP_CLOSED, 0) = 0" +
                            " ORDER BY CMP_CODE;"

                        'Campaigns = DbContext.Campaigns.Where(Function(Entity) Entity.IsClosed = 0).ToList

                    End If

                    Campaigns = DbContext.Database.SqlQuery(Of CampaignWithDates)(String.Format(sql)).ToList

                End Using

            End If

        Catch ex As Exception
            ProcessException(ex, "APIService-NotCaught")
            Campaigns = New Generic.List(Of CampaignWithDates)
        End Try

        ResultAPIResponse = New CampaignAPIResponseWithDates


        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then
            ResultAPIResponse.Message = ErrorMessage
            ResultAPIResponse.IsSuccessful = False
            ResultAPIResponse.Results = Nothing
        Else
            ResultAPIResponse.Results = Campaigns
            ResultAPIResponse.Message = CStr(ResultAPIResponse.Results.Count) + " records"
        End If

        LoadCampaigns2WithDates = ResultAPIResponse

    End Function

#End Region

End Class
