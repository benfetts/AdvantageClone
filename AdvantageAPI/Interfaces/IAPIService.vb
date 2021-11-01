Imports AdvantageAPI

<ServiceContract()>
Public Interface IAPIService

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    '<OperationContract()>
    '<System.Web.Services.WebMethod>
    '<WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    'Function Login(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As LoginReponse

    '<WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    '<OperationContract()>
    'Function CreateJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
    '				   CreateJobComponents As Boolean, CreateSchedule As Boolean, ClientCode As String, DivisionCode As String, ProductCode As String,
    '				   CopyFromJobNumber As Integer, CopyAllJobComponents As Boolean, CopyFromJobComponentNumber As Short, SalesClassCode As String, CampaignID As Integer,
    '				   JobDescription As String, JobComment As String, BillingComment As String, JobNumber As Integer, JobComponentDescription As String,
    '				   AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String) As CreateJobResponse

    'UriTemplate:="CreateEstimate?ServerName={SERVERNAME}&DatabaseName={DATABASENAME}&UseWindowsAuthentication={USEWINDOWSAUTHENTICATION}&UserName={USERNAME}&Password={PASSWORD}&EstimateRevisionDetails={ESTIMATEREVISIONDETAILS}", 

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddInternetOrder(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                              OrderDescription As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                              CampaignCode As String, SalesClassCode As String, VendorCode As String, VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String,
                              ClientPO As String, BuyerName As String, BuyerEmployeeCode As String, OrderDate As Date, OrderComment As String,
                              HouseComment As String, MarketCode As String, IsNetAmount As Boolean,
                              StartDate As Date, EndDate As Date, AdNumber As String, Headline As String,
                              AdSizeCode As String, JobNumber As Integer, JobComponentNumber As Integer, InternetTypeCode As String, URL As String,
                              TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As Integer, GuaranteedImpressions As Integer,
                              ActualImpressions As Integer, LineMarketCode As String, Rate As Decimal, NetCharge As Decimal, AdditionalCharge As Decimal,
                              CostType As String, RebateAmount As String, DiscountAmount As String,
                              Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function ReviseInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                     OrderNumber As Integer, OrderLineNumber As Integer, StartDate As String, EndDate As String, AdNumber As String, Headline As String,
                                     AdSizeCode As String, JobNumber As String, JobComponentNumber As String, InternetTypeCode As String, URL As String,
                                     TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As String, GuaranteedImpressions As String,
                                     ActualImpressions As String, LineMarketCode As String, Rate As String, NetCharge As String, AdditionalCharge As String,
                                     CostType As String, RebateAmount As String, DiscountAmount As String,
                                     Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                  OrderNumber As Integer, StartDate As Date, EndDate As Date, AdNumber As String, Headline As String,
                                  AdSizeCode As String, JobNumber As Integer, JobComponentNumber As Integer, InternetTypeCode As String, URL As String,
                                  TargetAudience As String, Placement1 As String, Placement2 As String, ProjectedImpressions As Integer, GuaranteedImpressions As Integer,
                                  ActualImpressions As Integer, LineMarketCode As String, Rate As Decimal, NetCharge As Decimal, AdditionalCharge As Decimal,
                                  CostType As String, RebateAmount As String, DiscountAmount As String,
                                  Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateInternetOrderHeader(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                       OrderNumber As Integer, OrderDescription As String, CampaignCode As String, SalesClassCode As String,
                                       VendorRepresentativeCode1 As String, VendorRepresentativeCode2 As String, ClientPO As String, ClientRef As String,
                                       OrderDate As String, BuyerName As String, BuyerEmployeeCode As String, MarketCode As String, FiscalPeriodCode As String,
                                       MailToVendor As Boolean, MailToRep1 As Boolean, MailToRep2 As Boolean, OrderComment As String, HouseComment As String) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                    OrderNumber As Integer, OrderLineNumber As Integer, StartDate As String, EndDate As String, CloseDate As String, MaterialCloseDate As String,
                                    ExtCloseDate As String, ExtMaterialDate As String, DateToBill As String, AdNumber As String, URL As String, Headline As String, FileSize As String,
                                    TargetAudience As String, AdSizeCode As String, Placement1 As String, PackageName As String, InternetTypeCode As String,
                                    JobNumber As String, JobComponentNumber As String, LineMarketCode As String, CostType As String, GuaranteedImpressions As String,
                                    ProjectedImpressions As String, ActualImpressions As String, Rate As String, NetCharge As String, NetChargeDescription As String,
                                    AdditionalCharge As String, AdditionalChargeDescription As String,
                                    DiscountAmount As String, DiscountAmountDescription As String, RebateAmount As String,
                                    Instructions As String, MiscInfo As String, OrderCopy As String, MaterialNotes As String) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function DeleteInternetOrder(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, OrderNumber As Integer) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function DeleteInternetOrderLine(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, OrderNumber As Integer, OrderLineNumber As Integer) As MediaOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddJobAndComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                JobClientReference As String, JobNumber As Integer, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String,
                                JobDescription As String, JobComment As String, AccountExecutive As String,
                                JobComponentDescription As String, CampaignId As Integer, DueDate As String, JobTypeCode As String,
                                ClientDiscountCode As String, BillingCoopCode As String, NonBillFlag As Integer,
                                MediaDateToBill As String, JobProcessContrl As Integer, JobComponentComment As String, JobComponentBudget As Decimal,
                                JobTaxFlag As Integer, ClientPO As String) As AddJobAndComponentResponse

    <WebInvoke(UriTemplate:="AddOrUpdateEstimate?ServerName={SERVERNAME}&DatabaseName={DATABASENAME}&UseWindowsAuthentication={USEWINDOWSAUTHENTICATION}&UserName={USERNAME}&Password={PASSWORD}&JobNumber={JOBNUMBER}&JobComponentNumber={JOBCOMPONENTNUMBER}&CreateRevision={CREATEREVISION}&AutoApprove={AUTOAPPROVE}",
               Method:="POST", BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateEstimate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                 JobNumber As Integer, JobComponentNumber As Short, CreateRevision As Short, AutoApprove As Short, ClientDiscountCode As String,
                                 CampaignID As String, SalesClass As String, EstimateRevisionDetails() As EstimateRevisionDetail) As AddOrUpdateEstimateResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddClientDivisionProduct(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                    ClientCode As String, ClientName As String, DivisionCode As String, DivisionName As String, ProductCode As String, ProductDescription As String,
                                    OfficeCode As String, UserDefined1 As String, UserDefined2 As String, UserDefined3 As String, UserDefined4 As String,
                                    ClientAddress1 As String, ClientAddress2 As String, ClientCity As String, ClientCounty As String, ClientState As String, ClientCountry As String, ClientZip As String,
                                    ClientType1 As String, ClientType2 As String, ClientType3 As String) As AddClientDivisionProductResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateClientDivisionProduct(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ClientCode As String, ClientName As String, DivisionCode As String, DivisionName As String, ProductCode As String, ProductDescription As String,
                            OfficeCode As String, UserDefined1 As String, UserDefined2 As String, UserDefined3 As String, UserDefined4 As String,
                            ClientAddress1 As String, ClientAddress2 As String, ClientCity As String, ClientCounty As String, ClientState As String, ClientCountry As String, ClientZip As String,
                            ClientType1 As String, ClientType2 As String, ClientType3 As String) As AddClientDivisionProductResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateClientType(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ClientTypeInd As Integer, ClientTypeDesc As String, InactiveFlag As Boolean) As ClientTypeResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddCampaign(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ClientCode As String, DivisionCode As String, ProductCode As String, CampaignCode As String, CampaignName As String,
                            StartDate As String, EndDate As String, JobNumber As Integer, JobComponentNumber As Integer) As AddCampaignResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CreateJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                       ClientCode As String, DivisionCode As String, ProductCode As String, JobDescription As String, JobComment As String,
                       BillingComment As String, SalesClassCode As String, CampaignID As Integer) As CreateJobResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CopyJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            JobNumber As Integer, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                            JobDescription As String, JobComment As String, JobComponentDescription As String, AccountExecutive As String,
                            UserDefined1 As String, UserDefined2 As String, OfficeCode As String, SendMail As Boolean, IncludeSchedule As Boolean, Status As String,
                            IncludeTaskEmployees As Boolean, IncludeTaskComment As Boolean, IncludeTaskDueDateComment As Boolean, IncludeTaskStartAndDueDate As Boolean) As CreateJobResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CreateJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, CampaignID As Integer,
                                JobDescription As String, JobComment As String, BillingComment As String, JobNumber As Integer, JobComponentDescription As String,
                                AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                                JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateMatCompDate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, MatCompDate As String) As MatCompDateResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateMaterialNotes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, MaterialNote As String) As BasicResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateMediaOrderStatus(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                  MediaType As String, OrderNumber As Integer, LineNumber As Int16, Status As Int16) As BasicResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CreateJobComponentFromExistingJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                               JobNumber As Integer, JobComponentDescription As String, AccountExecutiveEmployeeCode As String, JobTypeCode As String,
                                               AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                                               JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse
    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateJobAndComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                JobNumber As Integer, JobComponentNumber As Short,
                                JobDescription As String, JobComments As String, JobComponentDescription As String, JobComponentComments As String,
                                JobClientReference As String, JobProcessControl As Integer, JobType As String, NonBillFlag As Integer, MediaDateToBill As String,
                                JobComponentBudget As Decimal, JobTaxFlag As Integer, ClientPO As String, CampaignId As Integer) As AddJobAndComponentResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CopyJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                              CopyFromJobNumber As Integer, CopyFromJobComponentNumber As Short, JobComponentDescription As String,
                              AccountExecutiveEmployeeCode As String, JobTypeCode As String, AlertGroupCode As String, JobComponentComment As String, CreateSchedule As Boolean,
                              JobDueDate As Date, ScheduleStatusCode As String) As CreateJobResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateProjectScheduleDueDate(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                          JobNumber As Integer, JobComponentNumber As Short, DueDate As Date) As APIReponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function UpdateProjectScheduleStatus(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                         JobNumber As Integer, JobComponentNumber As Short, ScheduleStatusCode As String) As APIReponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadBillingCoops(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of BillingCoop)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadClientDiscounts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of ClientDiscount)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadScheduleStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of ScheduleStatus)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadSalesClasses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of SalesClass)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadSalesClasses2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As SalesClassAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAccountExecutives(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of AccountExecutive)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAlertGroups(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of AlertGroup)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJobTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of JobType)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CheckForValidSettings(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As ValidationMessage

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveVendorRepresentative(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            VendorCode As String, VendorRepresentativeCode As String,
                            FirstName As String, LastName As String, MiddleInitial As String, FirmName As String,
                            Address1 As String, Address2 As String, City As String, County As String, State As String, Country As String, Zip As String, Telephone As String,
                            TelephoneExtension As String, Fax As String, FaxExtension As String, EmailAddress As String, CellPhone As String,
                            ContactTypeID As Integer, IsInactive As Integer) As Boolean

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveVendorContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                               VendorCode As String, VendorContactCode As String, AddressLine1 As String, AddressLine2 As String,
                               City As String, County As String, State As String, Country As String, Zip As String,
                               Phone As String, PhoneExt As String, Fax As String, FaxExt As String,
                               Email As String, Cell As String) As Boolean

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveVendor(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        VendorCode As String, StreetAddressLine1 As String, StreetAddressLine2 As String, StreetAddressLine3 As String,
                        City As String, County As String, State As String, Country As String, ZipCode As String,
                        PhoneNumber As String, PhoneNumberExtension As String, FaxPhoneNumber As String, FaxPhoneNumberExtension As String,
                        EmailAddress As String, PaymentManagerEmailAddress As String, VCCStatus As String, VendorTermCode As String,
                        HasSpecialTerms As Boolean) As Boolean

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveMarket(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        MarketCode As String, Description As String, IsInactive As Short) As Boolean

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMediaOrders(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                             OrderStatus As String, StartDate As Date, StartMonth As Integer, StartYear As Integer,
                             EndDate As Date, EndMonth As Integer, EndYear As Integer, IncludeInternet As Boolean,
                             IncludeMagazine As Boolean, IncludeNewspaper As Boolean, IncludeOutOfHome As Boolean,
                             IncludeRadio As Boolean, IncludeTV As Boolean, OrderNumbers As String) As Generic.List(Of MediaOrder)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVCCStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of VCCStatus)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendorCategories(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of VendorCategory)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadCampaigns(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As Generic.List(Of Campaign)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadCampaigns2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As CampaignAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendorTerms(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of VendorTerm)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMarkets(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Market)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAdNumbers(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of AdNumber)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAdSizes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of AdSize)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadInternetTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of InternetType)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadInternetCostTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of InternetCostType)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadFiscalPeriods(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of FiscalPeriod)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadContactTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of ContactType)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadBanks(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Bank)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadClients(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Client)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadClients2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As ClientAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadDivisions(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Division)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadDivisions2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As DivisionAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadProducts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Product)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadProducts2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String,
                           Password As String, LoadInactive As Boolean) As ProductAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendors(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, ByVal Categories As String) As Generic.List(Of Vendor)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendors2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, ByVal Categories As String) As VendorAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendorsHistory(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean, ByVal Categories As String, ByVal FromDate As String, ByVal ToDate As String) As Generic.List(Of VendorHist)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendorContacts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of VendorContact)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadVendorRepresentatives(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of VendorRepResponse)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadEmployees(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Employee)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJobs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As Generic.List(Of Jobs)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJob(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, JobNumber As Integer) As Generic.List(Of Jobs)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJobComponents(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As Generic.List(Of JobComponents)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJobComponent(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, JobNumber As Integer, JobComponentNumber As Integer) As Generic.List(Of JobComponents)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadDepartmentTeams(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of DepartmentTeam)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadFunctions(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of [Function])

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadIndirectCategories(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of IndirectCategory)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveEmployeeJobTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, EmployeeTimeID As Integer,
                                 EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, FunctionCode As String, Hours As Decimal, JobNumber As Integer, JobComponentNumber As Short,
                                 DepartmentTeamCode As String, Comments As String, TaskCode As String, Optional ByVal NonBillFlag As String = "") As SaveEmployeeTimeReponse
    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveEmployeeNonProductionTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, EmployeeTimeID As Integer,
                                           EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, IndirectCategoryCode As String, Hours As Decimal, DepartmentTeamCode As String, Comments As String) As SaveEmployeeTimeReponse
    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadUsers(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As Generic.List(Of User)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadEmployeeTimeRecords(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, EmployeeCode As String, StartDate As Date, EndDate As Date) As Generic.List(Of EmployeeTimeRecord)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadTasks(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadInactive As Boolean) As Generic.List(Of Task)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function SaveTask(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        TaskCode As String, Description As String, IsInactive As Short) As Boolean

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadJobLogUserDefinedValues(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                              UserDefinedValueId As Integer, LoadInactive As Boolean) As Generic.List(Of JobLogUserDefinedValues)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadClientTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                             ClientTypeInd As Integer, LoadInactive As Boolean) As Generic.List(Of ClientTypes)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAPInvoices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         VendorCode As String, StartDate As Date, EndDate As Date, PaymentStatus As Integer) As Generic.List(Of APInvoices)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadAPInvoiceDetails(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                        ApId As Integer) As Generic.List(Of APInvoiceDetails)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadARInvoices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         JobNumber As Integer, JobComponentNumber As Integer, InvoiceNumber As Integer, InvoiceSequence As Integer) As Generic.List(Of ARInvoices)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadOffices(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         LoadInactive As Boolean) As Generic.List(Of Offices)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMediaOrderStatuses(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String,
                         Password As String, MediaType As String, OrderNumber As Integer, LineNumber As Short, RevisionNumber As Short) As Generic.List(Of OrderStatusResponse)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadIndirectTime(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         StartDate As Date, EndDate As Date, EmployeeCode As String) As Generic.List(Of IndirectTime)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadSecClients2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         UserCode As String) As SecClientAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadContactTypes2(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) As ContactTypeAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateContactType(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ContactTypeId As Integer, ContactTypeDesc As String) As ContactTypeResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateClientContactHdr(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
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
                        ContactTypeID As Integer,
                        IsInactive As Short) As ContactHeaderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrDeleteClientContactDtl(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                    ContactID As Integer,
                    SeqNumber As Integer,
                    DivisionCode As String,
                    ProductCode As String,
                    DeleteSeq As Boolean) As ContactDetailResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateARStmtClientContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                ClientCode As String,
                ContactID As Integer,
                EmailInvoice As Short,
                PrintInvoice As Short,
                UseAddress As Short,
                IncludeOnAccount As Short,
                Optional ByVal DeleteContact As Boolean = False) As ContactStatementResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddOrUpdateARStmtProductContact(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                ClientCode As String,
                DivisionCode As String,
                ProductCode As String,
                ContactID As Integer,
                EmailInvoice As Short,
                PrintInvoice As Short,
                UseAddress As Short,
                IncludeOnAccount As Short,
                Optional ByVal DeleteContact As Boolean = False) As ContactStatementResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMediaBroadcastDetails(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                         Optional ByVal MediaType As String = "A") As MediaBroadcastDetailsAPIResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadARStmtProductContacts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            ClientCode As String, ClientLevelOnlyContacts As Boolean, LoadInactive As Boolean) As ARStmtProductContactResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddMediaPlanHeader(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            Description As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                            StartDate As String, EndDate As String,
                            Optional ByVal GrossBudgetAmount As Decimal = 0, Optional ByVal Comment As String = "",
                            Optional ByVal ClientContactID As Integer = 0, Optional ByVal CampaignID As Integer = 0,
                            Optional ByVal CountryID As Integer = 1, Optional ByVal MixAndRateTemplateID As Integer = 0) As MediaPlanAddResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function CopyMediaPlan(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                            MediaPlanID As Integer,
                            ClientCode As String, DivisionCode As String, ProductCode As String,
                            Optional ByVal Description As String = "",
                            Optional ByVal StartDate As String = "01-01-1900", Optional ByVal EndDate As String = "01-01-1900",
                            Optional ByVal GrossBudgetAmount As Decimal = -1, Optional ByVal Comment As String = "") As MediaPlanAddResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMixRateTemplates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                  LoadInactive As Boolean) As MediaPlanMixRateTemplatesResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function AddBroadcastWorksheetHeader(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
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
                            Optional Comment As String = Nothing) As BroadcastWorksheetAddResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMediaBroadcastWorksheetDateTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) _
                            As BasicIDNames

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadMediaCalendarTypes(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String) _
                            As BasicIDNames

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadRatingsServiceIDs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                           MediaTypeCode As String, CountryID As Integer) As BasicIDNames


    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadPrimaryMediaDemographicIDs(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String,
                                            MediaTypeCode As String, CountryID As Integer, RatingsServiceID As Integer) As BasicIDNames

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadPurchaseOrders(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String
                                            ) As PurchaseOrderResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadGLAccounts(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String
                                            ) As GeneralLedgerAccountResponse

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadCampaignsWithDates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As Generic.List(Of CampaignWithDates)

    <WebGet(BodyStyle:=WebMessageBodyStyle.Wrapped, ResponseFormat:=WebMessageFormat.Json, RequestFormat:=WebMessageFormat.Json)>
    <OperationContract()>
    Function LoadCampaigns2WithDates(ServerName As String, DatabaseName As String, UseWindowsAuthentication As Integer, UserName As String, Password As String, LoadClosed As Boolean) As CampaignAPIResponseWithDates


#End Region
End Interface
