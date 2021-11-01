Namespace DigitalResults

    <HideModuleName()>
    Public Module Methods

        Public Sub LoadValidationObjects(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EntityList As IEnumerable)

            'objects
            Dim DigitalResult As AdvantageFramework.Database.Entities.DigitalResult = Nothing
            Dim DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView = Nothing
            Dim ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging = Nothing
            Dim DigitalResultError As AdvantageFramework.Database.Classes.DigitalResultError = Nothing
            Dim MediaPlanList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlan) = Nothing
            Dim ClientList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim DivisionList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim ProductList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
            Dim MediaPlanDetailList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail) = Nothing
            Dim SalesClassList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim CampaignList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Campaign) = Nothing
            Dim VendorList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
            Dim MarketList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim AdSizeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.AdSize) = Nothing
            Dim AdNumberList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Ad) = Nothing
            Dim InternetTypeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.InternetType) = Nothing
            Dim MediaPlanDetailLevelLineTagList As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
            Dim DaypartList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing

            MediaPlanList = AdvantageFramework.Database.Procedures.MediaPlan.Load(DbContext).ToList
            ClientList = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext).ToList
            DivisionList = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext).ToList
            ProductList = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext).ToList
            MediaPlanDetailList = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).ToList
            SalesClassList = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList
            CampaignList = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext).ToList
            VendorList = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).ToList
            MarketList = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList
            AdSizeList = AdvantageFramework.Database.Procedures.AdSize.Load(DbContext).ToList
            AdNumberList = AdvantageFramework.Database.Procedures.Ad.Load(DbContext).ToList
            InternetTypeList = AdvantageFramework.Database.Procedures.InternetType.Load(DbContext).ToList
            MediaPlanDetailLevelLineTagList = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineTag.Load(DbContext).ToList
            DaypartList = AdvantageFramework.Database.Procedures.Daypart.Load(DbContext).ToList

            If EntityList IsNot Nothing Then

                For Each EntityItem In EntityList

                    DigitalResultError = Nothing

                    If TypeOf EntityItem Is AdvantageFramework.Database.Entities.DigitalResult Then

                        DigitalResult = DirectCast(EntityItem, AdvantageFramework.Database.Entities.DigitalResult)

                        If DigitalResult IsNot Nothing Then

                            DigitalResultError = ValidateObject(DbContext, MediaPlanList, ClientList, DivisionList, ProductList, MediaPlanDetailList, MediaPlanDetailLevelLineTagList, SalesClassList, CampaignList,
                                                                VendorList, MarketList, AdSizeList, AdNumberList, InternetTypeList, DaypartList, DigitalResult.MediaPlanID, DigitalResult.ClientCode, DigitalResult.DivisionCode,
                                                                DigitalResult.ProductCode, DigitalResult.MediaPlanDetailID, DigitalResult.SalesClassCode, DigitalResult.CampaignID, DigitalResult.CampaignCode,
                                                                DigitalResult.VendorCode, DigitalResult.MarketCode, DigitalResult.AdSizeCode, DigitalResult.MediaType, DigitalResult.AdNumber, DigitalResult.InternetTypeCode,
                                                                DigitalResult.JobNumber, DigitalResult.DaypartCode)

                            DigitalResult.SetDigitalResultErrorObject(DigitalResultError)

                        End If

                    ElseIf TypeOf EntityItem Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                        ImportDigitalResultsStaging = DirectCast(EntityItem, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

                        If ImportDigitalResultsStaging IsNot Nothing Then

                            DigitalResultError = ValidateObject(DbContext, MediaPlanList, ClientList, DivisionList, ProductList, MediaPlanDetailList, MediaPlanDetailLevelLineTagList, SalesClassList, CampaignList,
                                                                VendorList, MarketList, AdSizeList, AdNumberList, InternetTypeList, DaypartList, ImportDigitalResultsStaging.MediaPlanID, ImportDigitalResultsStaging.ClientCode,
                                                                ImportDigitalResultsStaging.DivisionCode, ImportDigitalResultsStaging.ProductCode, ImportDigitalResultsStaging.MediaPlanDetailID,
                                                                ImportDigitalResultsStaging.SalesClassCode, ImportDigitalResultsStaging.CampaignID, ImportDigitalResultsStaging.CampaignCode,
                                                                ImportDigitalResultsStaging.VendorCode, ImportDigitalResultsStaging.MarketCode, ImportDigitalResultsStaging.AdSizeCode,
                                                                ImportDigitalResultsStaging.MediaType, ImportDigitalResultsStaging.AdNumber, ImportDigitalResultsStaging.InternetTypeCode,
                                                                ImportDigitalResultsStaging.JobNumber, ImportDigitalResultsStaging.DaypartCode)

                            ImportDigitalResultsStaging.SetDigitalResultErrorObject(DigitalResultError)

                        End If

                    ElseIf TypeOf EntityItem Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                        DigitalResultsView = DirectCast(EntityItem, AdvantageFramework.Database.Entities.DigitalResultsView)

                        If DigitalResultsView IsNot Nothing Then

                            DigitalResultError = ValidateObject(DbContext, MediaPlanList, ClientList, DivisionList, ProductList, MediaPlanDetailList, MediaPlanDetailLevelLineTagList, SalesClassList, CampaignList,
                                                                VendorList, MarketList, AdSizeList, AdNumberList, InternetTypeList, DaypartList, DigitalResultsView.MediaPlanID, DigitalResultsView.ClientCode,
                                                                DigitalResultsView.DivisionCode, DigitalResultsView.ProductCode, DigitalResultsView.EstimateID,
                                                                DigitalResultsView.SalesClassCode, DigitalResultsView.CampaignID, DigitalResultsView.CampaignCode,
                                                                DigitalResultsView.VendorCode, DigitalResultsView.MarketCode, DigitalResultsView.AdSizeCode,
                                                                DigitalResultsView.MediaType, DigitalResultsView.AdNumber, DigitalResultsView.InternetTypeCode,
                                                                DigitalResultsView.JobNumber, DigitalResultsView.DaypartCode)

                            If DigitalResultError IsNot Nothing Then

                                If Not String.IsNullOrWhiteSpace(DigitalResultError.CampaignErrorMessage) AndAlso Not DigitalResultsView.CampaignID.HasValue Then

                                    DigitalResultError.CampaignErrorMessage = ""

                                End If

                            End If

                            DigitalResultsView.SetDigitalResultErrorObject(DigitalResultError)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Function ValidateObject(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal MediaPlanList As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlan),
                                        ByVal ClientList As IEnumerable(Of AdvantageFramework.Database.Core.Client),
                                        ByVal DivisionList As IEnumerable(Of AdvantageFramework.Database.Core.Division),
                                        ByVal ProductList As IEnumerable(Of AdvantageFramework.Database.Core.Product),
                                        ByVal MediaPlanDetailList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetail),
                                        ByVal MediaPlanDetailLevelLineTagList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag),
                                        ByVal SalesClassList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.SalesClass),
                                        ByVal CampaignList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Campaign),
                                        ByVal VendorList As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor),
                                        ByVal MarketList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Market),
                                        ByVal AdSizeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.AdSize),
                                        ByVal AdNumberList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Ad),
                                        ByVal InternetTypeList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.InternetType),
                                        ByVal DaypartList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Daypart),
                                        ByVal MediaPlanID As Integer?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                        ByVal MediaPlanDetailID As Integer?, ByVal SalesClassCode As String, ByVal CampaignID As Integer?, ByVal CampaignCode As String,
                                        ByVal VendorCode As String, ByVal MarketCode As String, ByVal AdSizeCode As String, ByVal MediaType As String,
                                        ByVal AdNumber As String, ByVal InternetTypeCode As String, ByVal JobNumber As Integer?, ByVal DaypartCode As String) As AdvantageFramework.Database.Classes.DigitalResultError

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim Client As AdvantageFramework.Database.Core.Client = Nothing
            Dim Division As AdvantageFramework.Database.Core.Division = Nothing
            Dim Product As AdvantageFramework.Database.Core.Product = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing
            Dim Campaign As AdvantageFramework.Database.Core.Campaign = Nothing
            Dim Vendor As AdvantageFramework.Database.Core.Vendor = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim InternetType As AdvantageFramework.Database.Entities.InternetType = Nothing
            Dim DigitalResultError As AdvantageFramework.Database.Classes.DigitalResultError = Nothing
            Dim MediaPlanSalesClasses As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim CurrentMediaPlanDetailLevelLineTagList As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim Codes As String() = Nothing
            Dim MediaPlanErrorMessage As String = Nothing
            Dim ClientErrorMessage As String = Nothing
            Dim DivisionErrorMessage As String = Nothing
            Dim ProductErrorMessage As String = Nothing
            Dim MediaPlanDetailErrorMessage As String = Nothing
            Dim SalesClassErrorMessage As String = Nothing
            Dim CampaignErrorMessage As String = Nothing
            Dim VendorErrorMessage As String = Nothing
            Dim MarketErrorMessage As String = Nothing
            Dim AdSizeErrorMessage As String = Nothing
            Dim AdNumberErrorMessage As String = Nothing
            Dim InternetTypeErrorMessage As String = Nothing
            Dim DaypartCodeErrorMessage As String = Nothing
            Dim MediaPlanError As Boolean = False
            Dim ClientError As Boolean = False
            Dim DivisionError As Boolean = False
            Dim ProductError As Boolean = False
            Dim MediaPlanDetailError As Boolean = False
            Dim SalesClassError As Boolean = False
            Dim CampaignError As Boolean = False
            Dim VendorError As Boolean = False
            Dim MarketError As Boolean = False
            Dim AdSizeError As Boolean = False
            Dim AdNumberError As Boolean = False
            Dim InternetTypeError As Boolean = False
            Dim DaypartCodeError As Boolean = False

            If MediaPlanID.HasValue Then

                MediaPlan = (From Entity In MediaPlanList
                             Where Entity.ID = MediaPlanID.GetValueOrDefault(0)
                             Select Entity).SingleOrDefault

                If MediaPlan Is Nothing Then

                    MediaPlanError = True

                Else

                    MediaPlanError = False

                End If

                If MediaPlanError Then

                    MediaPlanErrorMessage = "Please select a valid media plan."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(ClientCode) Then

                Client = (From Entity In ClientList
                          Where Entity.Code = ClientCode
                          Select Entity).SingleOrDefault

                If Client Is Nothing Then

                    ClientError = True

                ElseIf MediaPlan IsNot Nothing AndAlso MediaPlan.ClientCode <> ClientCode Then

                    ClientError = True

                Else

                    ClientError = False

                End If

                If ClientError Then

                    ClientErrorMessage = "Please select a valid client."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(DivisionCode) Then

                Division = (From Entity In DivisionList
                            Where Entity.ClientCode = ClientCode AndAlso
                                  Entity.Code = DivisionCode
                            Select Entity).SingleOrDefault

                If Division Is Nothing Then

                    DivisionError = True

                ElseIf MediaPlan IsNot Nothing AndAlso (MediaPlan.ClientCode <> ClientCode OrElse MediaPlan.DivisionCode <> DivisionCode) Then

                    DivisionError = True

                Else

                    DivisionError = False

                End If

                If DivisionError Then

                    DivisionErrorMessage = "Please select a valid division."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(ProductCode) Then

                Product = (From Entity In ProductList
                           Where Entity.ClientCode = ClientCode AndAlso
                                  Entity.DivisionCode = DivisionCode AndAlso
                                  Entity.Code = ProductCode
                           Select Entity).SingleOrDefault

                If Product Is Nothing Then

                    ProductError = True

                ElseIf MediaPlan IsNot Nothing AndAlso (MediaPlan.ClientCode <> ClientCode OrElse MediaPlan.DivisionCode <> DivisionCode OrElse MediaPlan.ProductCode <> ProductCode) Then

                    ProductError = True

                Else

                    ProductError = False

                End If

                If ProductError Then

                    ProductErrorMessage = "Please select a valid product."

                End If

            End If

            If MediaPlanDetailID.HasValue Then

                MediaPlanDetail = (From Entity In MediaPlanDetailList
                                   Where Entity.MediaPlanID = MediaPlanID.GetValueOrDefault(0) AndAlso
                                         Entity.ID = MediaPlanDetailID.GetValueOrDefault(0)
                                   Select Entity).SingleOrDefault

                If MediaPlanDetail Is Nothing Then

                    MediaPlanDetailError = True

                Else

                    MediaPlanDetailError = False

                End If

                If MediaPlanDetailError Then

                    MediaPlanDetailErrorMessage = "Please select a valid estimate."

                End If

            End If

            If MediaPlan IsNot Nothing Then

                If MediaPlanDetail IsNot Nothing Then

                    CurrentMediaPlanDetailLevelLineTagList = (From Entity In MediaPlanDetailLevelLineTagList
                                                              Where Entity.MediaPlanID = MediaPlan.ID AndAlso
                                                                    Entity.MediaPlanDetailID = MediaPlanDetail.ID
                                                              Select Entity).ToList

                Else

                    CurrentMediaPlanDetailLevelLineTagList = (From Entity In MediaPlanDetailLevelLineTagList
                                                              Where Entity.MediaPlanID = MediaPlan.ID
                                                              Select Entity).ToList

                End If

            Else

                CurrentMediaPlanDetailLevelLineTagList = Nothing

            End If

            If Not String.IsNullOrWhiteSpace(SalesClassCode) Then

                SalesClass = (From Entity In SalesClassList
                              Where Entity.Code = SalesClassCode AndAlso
                                    Entity.SalesClassTypeCode = MediaType
                              Select Entity).SingleOrDefault

                SalesClassError = False

                If SalesClass Is Nothing Then

                    SalesClassError = True

                End If

                If SalesClassError = False Then

                    If MediaPlan IsNot Nothing Then

                        LoadColumnEditorDatasource(DbContext, AdvantageFramework.Database.Entities.DigitalResult.Properties.SalesClassCode.ToString, False, MediaPlanSalesClasses, MediaPlan.ID,
                                                   MediaPlan.ClientCode, MediaPlan.DivisionCode, MediaPlan.ProductCode, MediaPlanDetailID, VendorCode, MarketCode, AdSizeCode, InternetTypeCode, MediaType, JobNumber)

                        If MediaPlanSalesClasses IsNot Nothing Then

                            If (From Entity In MediaPlanSalesClasses
                                Where Entity.Code = SalesClassCode
                                Select Entity).Any = False Then

                                SalesClassError = True

                            End If

                        Else

                            SalesClassError = True

                        End If

                    End If

                End If

                If SalesClassError Then

                    SalesClassErrorMessage = "Please select a valid sales class."

                End If

            End If

            If CampaignID.HasValue OrElse Not String.IsNullOrWhiteSpace(CampaignCode) Then

                Campaign = (From Entity In CampaignList
                            Where Entity.ID = If(CampaignID.HasValue, CampaignID.GetValueOrDefault(0), Entity.ID) AndAlso
                                  Entity.Code = If(String.IsNullOrWhiteSpace(CampaignCode) = False, CampaignCode, Entity.Name)
                            Select Entity).SingleOrDefault

                If Campaign Is Nothing Then

                    CampaignError = True

                ElseIf Client IsNot Nothing AndAlso Campaign.ClientCode <> Client.Code Then

                    CampaignError = True

                ElseIf Division IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Campaign.DivisionCode) AndAlso Campaign.DivisionCode <> Division.Code Then

                    CampaignError = True

                ElseIf Product IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Campaign.ProductCode) AndAlso Campaign.ProductCode <> Product.Code Then

                    CampaignError = True

                Else

                    CampaignError = False

                End If

                If CampaignError Then

                    CampaignErrorMessage = "Please select a valid campaign."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(VendorCode) Then

                Vendor = (From Entity In VendorList
                          Where Entity.Code = VendorCode
                          Select Entity).SingleOrDefault

                VendorError = False

                If Vendor Is Nothing Then

                    VendorError = True

                End If

                If VendorError = False Then

                    If MediaPlan IsNot Nothing Then

                        If CurrentMediaPlanDetailLevelLineTagList IsNot Nothing Then

                            Codes = (From Entity In CurrentMediaPlanDetailLevelLineTagList
                                     Where String.IsNullOrWhiteSpace(Entity.VendorCode) = False
                                     Select [VC] = Entity.VendorCode).ToArray

                            If Codes IsNot Nothing AndAlso Codes.Count > 0 Then

                                If Codes.Contains(VendorCode) = False Then

                                    VendorError = True

                                End If

                            End If

                        End If

                    End If

                End If

                If VendorError Then

                    VendorErrorMessage = "Please select a valid vendor."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MarketCode) Then

                Market = (From Entity In MarketList
                          Where Entity.Code = MarketCode
                          Select Entity).SingleOrDefault

                MarketError = False

                If Market Is Nothing Then

                    MarketError = True

                End If

                If MarketError = False Then

                    If MediaPlan IsNot Nothing Then

                        If CurrentMediaPlanDetailLevelLineTagList IsNot Nothing Then

                            Codes = (From Entity In CurrentMediaPlanDetailLevelLineTagList
                                     Where String.IsNullOrWhiteSpace(Entity.MarketCode) = False
                                     Select [MC] = Entity.MarketCode).ToArray

                            If Codes IsNot Nothing AndAlso Codes.Count > 0 Then

                                If Codes.Contains(MarketCode) = False Then

                                    MarketError = True

                                End If

                            End If

                        End If

                    End If

                End If

                If MarketError Then

                    MarketErrorMessage = "Please select a valid market code."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(AdSizeCode) Then

                AdSize = (From Entity In AdSizeList
                          Where Entity.Code = AdSizeCode AndAlso
                                Entity.MediaType = MediaType
                          Select Entity).SingleOrDefault

                AdSizeError = False

                If AdSize Is Nothing Then

                    AdSizeError = True

                End If

                If AdSizeError = False Then

                    If MediaPlan IsNot Nothing Then

                        If CurrentMediaPlanDetailLevelLineTagList IsNot Nothing Then

                            Codes = (From Entity In CurrentMediaPlanDetailLevelLineTagList
                                     Where String.IsNullOrWhiteSpace(Entity.SizeCode) = False
                                     Select [AC] = Entity.SizeCode).ToArray

                            If Codes IsNot Nothing AndAlso Codes.Count > 0 Then

                                If Codes.Contains(AdSizeCode) = False Then

                                    AdSizeError = True

                                End If

                            End If

                        End If

                    End If

                End If

                If AdSizeError Then

                    AdSizeErrorMessage = "Please select a valid ad size."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(AdNumber) Then

                Ad = (From Entity In AdNumberList
                      Where Entity.Number = AdNumber AndAlso
                            (String.IsNullOrWhiteSpace(Entity.ClientCode) OrElse
                             Entity.ClientCode = If(String.IsNullOrWhiteSpace(ClientCode), Entity.ClientCode, ClientCode))
                      Select Entity).SingleOrDefault

                If Ad Is Nothing Then

                    AdNumberError = True

                Else

                    AdNumberError = False

                End If

                If AdNumberError Then

                    AdNumberErrorMessage = "Please select a valid ad number."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(InternetTypeCode) Then

                InternetType = (From Entity In InternetTypeList
                                Where Entity.Code = InternetTypeCode
                                Select Entity).SingleOrDefault

                InternetTypeError = False

                If InternetType Is Nothing Then

                    InternetTypeError = True

                End If

                If InternetTypeError = False Then

                    If MediaPlan IsNot Nothing Then

                        If CurrentMediaPlanDetailLevelLineTagList IsNot Nothing Then

                            Codes = (From Entity In CurrentMediaPlanDetailLevelLineTagList
                                     Where String.IsNullOrWhiteSpace(Entity.InternetTypeCode) = False
                                     Select [ITC] = Entity.InternetTypeCode).ToArray

                            If Codes IsNot Nothing AndAlso Codes.Count > 0 Then

                                If Codes.Contains(InternetTypeCode) = False Then

                                    InternetTypeError = True

                                End If

                            End If

                        End If

                    End If

                End If

                If InternetTypeError Then

                    InternetTypeErrorMessage = "Please select a valid internet type."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(DaypartCode) Then

                Daypart = (From Entity In DaypartList
                           Where Entity.Code = DaypartCode
                           Select Entity).SingleOrDefault

                If Daypart Is Nothing Then

                    DaypartCodeError = True

                Else

                    DaypartCodeError = False

                End If

                If DaypartCodeError Then

                    DaypartCodeErrorMessage = "Please select a valid daypart code."

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MediaPlanErrorMessage) OrElse Not String.IsNullOrWhiteSpace(ClientErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(DivisionErrorMessage) OrElse Not String.IsNullOrWhiteSpace(ProductErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(MediaPlanDetailErrorMessage) OrElse Not String.IsNullOrWhiteSpace(SalesClassErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(CampaignErrorMessage) OrElse Not String.IsNullOrWhiteSpace(VendorErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(MarketErrorMessage) OrElse Not String.IsNullOrWhiteSpace(AdSizeErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(AdNumberErrorMessage) OrElse Not String.IsNullOrWhiteSpace(InternetTypeErrorMessage) OrElse
               Not String.IsNullOrWhiteSpace(DaypartCodeErrorMessage) Then

                DigitalResultError = New AdvantageFramework.Database.Classes.DigitalResultError

                DigitalResultError.MediaPlanErrorMessage = MediaPlanErrorMessage
                DigitalResultError.ClientErrorMessage = ClientErrorMessage
                DigitalResultError.DivisionErrorMessage = DivisionErrorMessage
                DigitalResultError.ProductErrorMessage = ProductErrorMessage
                DigitalResultError.MediaPlanDetailErrorMessage = MediaPlanDetailErrorMessage
                DigitalResultError.SalesClassErrorMessage = SalesClassErrorMessage
                DigitalResultError.CampaignErrorMessage = CampaignErrorMessage
                DigitalResultError.VendorErrorMessage = VendorErrorMessage
                DigitalResultError.MarketErrorMessage = MarketErrorMessage
                DigitalResultError.AdSizeErrorMessage = AdSizeErrorMessage
                DigitalResultError.AdNumberErrorMessage = AdNumberErrorMessage
                DigitalResultError.InternetTypeErrorMessage = InternetTypeErrorMessage
                DigitalResultError.DaypartCodeErrorMessage = DaypartCodeErrorMessage

            Else

                DigitalResultError = Nothing

            End If

            ValidateObject = DigitalResultError

        End Function
        Public Function LoadImportStagingsByBatchName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String, ByVal IncludeValidationObjects As Boolean) As IEnumerable(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

            'objects
            Dim ImportDigitalResultsStagingList As Generic.List(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) = Nothing

            ImportDigitalResultsStagingList = AdvantageFramework.Database.Procedures.ImportDigitalResultsStaging.LoadByBatchName(DbContext, BatchName).ToList

            If IncludeValidationObjects Then

                LoadValidationObjects(DbContext, ImportDigitalResultsStagingList)

            End If

            LoadImportStagingsByBatchName = ImportDigitalResultsStagingList

        End Function
        Public Function LoadDigitalResults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncludeValidationObjects As Boolean) As Object

            'objects
            Dim DigitalResultList As Generic.List(Of AdvantageFramework.Database.Entities.DigitalResult) = Nothing

            DigitalResultList = AdvantageFramework.Database.Procedures.DigitalResult.Load(DbContext).ToList

            If IncludeValidationObjects Then

                LoadValidationObjects(DbContext, DigitalResultList)

            End If

            LoadDigitalResults = DigitalResultList

        End Function
        Public Function LoadDigitalResultViews(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StartDate As Date, ByVal EndDate As Date, ByVal IncludeValidationObjects As Boolean) As Object

            'objects
            Dim DigitalResultList As Generic.List(Of AdvantageFramework.Database.Entities.DigitalResultsView) = Nothing

            DigitalResultList = AdvantageFramework.Database.Procedures.DigitalResultsView.LoadByDateRange(DbContext, StartDate, EndDate).ToList

            If IncludeValidationObjects Then

                LoadValidationObjects(DbContext, DigitalResultList)

            End If

            LoadDigitalResultViews = DigitalResultList

        End Function
        Public Sub LoadColumnEditorDatasouce(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult,
                                             ByVal FieldName As String, ByRef OverrideDefaultDataSource As Boolean, ByRef Datasource As Object)

            LoadColumnEditorDatasource(DbContext, FieldName, OverrideDefaultDataSource, Datasource, DigitalResult.MediaPlanID, DigitalResult.ClientCode, DigitalResult.DivisionCode, DigitalResult.ProductCode,
                                       DigitalResult.MediaPlanDetailID, DigitalResult.VendorCode, DigitalResult.MarketCode, DigitalResult.AdSizeCode, DigitalResult.InternetTypeCode, DigitalResult.MediaType, DigitalResult.JobNumber)

        End Sub
        Public Sub LoadColumnEditorDatasouce(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal DigitalResultView As AdvantageFramework.Database.Entities.DigitalResultsView,
                                             ByVal FieldName As String, ByRef OverrideDefaultDataSource As Boolean, ByRef Datasource As Object)

            LoadColumnEditorDatasource(DbContext, FieldName, OverrideDefaultDataSource, Datasource, DigitalResultView.MediaPlanID, DigitalResultView.ClientCode, DigitalResultView.DivisionCode, DigitalResultView.ProductCode,
                                       DigitalResultView.EstimateID, DigitalResultView.VendorCode, DigitalResultView.MarketCode, DigitalResultView.AdSizeCode, DigitalResultView.InternetTypeCode, DigitalResultView.MediaType, DigitalResultView.JobNumber)

        End Sub
        Public Sub LoadColumnEditorDatasouce(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging,
                                             ByVal FieldName As String, ByRef OverrideDefaultDataSource As Boolean, ByRef Datasource As Object)

            LoadColumnEditorDatasource(DbContext, FieldName, OverrideDefaultDataSource, Datasource, ImportDigitalResultsStaging.MediaPlanID, ImportDigitalResultsStaging.ClientCode, ImportDigitalResultsStaging.DivisionCode,
                                       ImportDigitalResultsStaging.ProductCode, ImportDigitalResultsStaging.MediaPlanDetailID, ImportDigitalResultsStaging.VendorCode, ImportDigitalResultsStaging.MarketCode,
                                       ImportDigitalResultsStaging.AdSizeCode, ImportDigitalResultsStaging.InternetTypeCode, ImportDigitalResultsStaging.MediaType, ImportDigitalResultsStaging.JobNumber)

        End Sub
        Public Sub LoadColumnEditorDatasource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FieldName As String, ByRef OverrideDefaultDataSource As Boolean, ByRef Datasource As Object,
                                              ByVal MediaPlanID As Integer?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MediaPlanDetailID As Integer?,
                                              ByVal VendorCode As String, ByVal MarketCode As String, ByVal AdSizeCode As String, ByVal InternetTypeCode As String, ByVal MediaType As String,
                                              ByVal JobNumber As Integer?)

            'objects
            Dim Codes As String() = Nothing
            Dim MediaPlanDetailLevelLineTags As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag) = Nothing
            Dim SalesClassCodes As String() = Nothing
            Dim MediaPlanDetailLevels As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing
            Dim MediaPlanDetailLevelLines As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim MediaPlanDetailLevelIDs As Integer() = Nothing
            Dim MappingType As Integer = Nothing

            Select Case FieldName

                Case AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaPlanID.ToString,
                        AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanID.ToString

                    OverrideDefaultDataSource = True

                    Datasource = AdvantageFramework.Database.Procedures.MediaPlan.Load(DbContext).Include("Client").Include("MediaPlanDetails").ToList

                Case AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaPlanDetailID.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString,
                         AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString

                    OverrideDefaultDataSource = True

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID.GetValueOrDefault(0)).Include("SalesClass")
                                  Where (MediaType Is Nothing OrElse
                                         Entity.SalesClassType = MediaType)
                                  Select Entity).ToList

                Case AdvantageFramework.Database.Entities.DigitalResult.Properties.CampaignID.ToString,
                         AdvantageFramework.Database.Entities.DigitalResult.Properties.CampaignCode.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignID.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignCode.ToString

                    OverrideDefaultDataSource = True

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, ClientCode, DivisionCode, ProductCode)
                                      Where Entity.IsClosed Is Nothing OrElse
                                             Entity.IsClosed = 0
                                      Select Entity).ToList

                    End If

                Case AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString,
                         AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketCode.ToString,
                         AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeCode.ToString,
                         AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString,
                         AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString,
                         AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString

                    OverrideDefaultDataSource = True

                    If MediaPlanID.HasValue Then

                        'If FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString OrElse
                        '    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString Then

                        '    MappingType = AdvantageFramework.MediaPlanning.MappingTypes.AdNumber

                        '    If MediaPlanDetailID.GetValueOrDefault(0) > 0 Then

                        'MediaPlanDetailLevels = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID.GetValueOrDefault(0))
                        '                         Where Entity.MappingType = MappingType
                        '                         Select Entity).ToList

                        '    Else

                        'MediaPlanDetailLevels = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevel.LoadByMediaPlanID(DbContext, MediaPlanID.GetValueOrDefault(0))
                        '                         Where Entity.MappingType = MappingType
                        '                         Select Entity).ToList

                        '    End If

                        '    If MediaPlanDetailLevels IsNot Nothing Then

                        '        MediaPlanDetailLevelIDs = MediaPlanDetailLevels.Select(Function(MediaPlanDtlLvl) MediaPlanDtlLvl.ID).ToArray

                        'MediaPlanDetailLevelLines = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.Load(DbContext)
                        '                             Where MediaPlanDetailLevelIDs.Contains(Entity.MediaPlanDetailLevelID) = True
                        '                             Select Entity).ToList

                        '        If MediaPlanDetailLevelLines IsNot Nothing Then

                        'Codes = (From Entity In MediaPlanDetailLevelLines
                        '         Where String.IsNullOrWhiteSpace(Entity.Description) = False
                        '         Select [AdNbr] = Entity.Description).ToArray

                        '        End If

                        '    End If

                        'Else

                        MediaPlanDetailLevelLineTags = AdvantageFramework.MediaPlanning.LoadAvailableMediaPlanDetailLevelLineTags(DbContext, CInt(MediaPlanID.GetValueOrDefault(0)), CInt(MediaPlanDetailID.GetValueOrDefault(0)))

                        If MediaPlanDetailLevelLineTags IsNot Nothing AndAlso MediaPlanDetailLevelLineTags.Count > 0 Then

                            If FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString OrElse
                                    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString Then

                                Codes = (From Entity In MediaPlanDetailLevelLineTags
                                         Where String.IsNullOrWhiteSpace(Entity.VendorCode) = False
                                         Select [VC] = Entity.VendorCode).ToArray

                            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketCode.ToString OrElse
                                    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString Then

                                Codes = (From Entity In MediaPlanDetailLevelLineTags
                                         Where String.IsNullOrWhiteSpace(Entity.MarketCode) = False
                                         Select [MC] = Entity.MarketCode).ToArray

                            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeCode.ToString OrElse
                                    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString Then

                                Codes = (From Entity In MediaPlanDetailLevelLineTags
                                         Where String.IsNullOrWhiteSpace(Entity.SizeCode) = False
                                         Select Entity.SizeCode).ToArray

                            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString OrElse
                                    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString Then

                                Codes = (From Entity In MediaPlanDetailLevelLineTags
                                         Where String.IsNullOrWhiteSpace(Entity.InternetTypeCode) = False
                                         Select [ITC] = Entity.InternetTypeCode).ToArray

                            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString OrElse
                                    FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString Then

                                Codes = (From Entity In MediaPlanDetailLevelLineTags
                                         Where String.IsNullOrWhiteSpace(Entity.AdNumber) = False
                                         Select [AdNbr] = Entity.AdNumber).ToArray

                            End If

                        End If

                        ' End If

                    End If

                    If Codes IsNot Nothing AndAlso Codes.Count > 0 Then

                        If FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                                          Where Codes.Contains(Entity.Code)
                                          Select Entity).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)
                                          Where Codes.Contains(Entity.Code)
                                          Select Entity).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(DbContext)
                                          Where Codes.Contains(Entity.Code)
                                          Select Entity).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.InternetType.LoadAllActive(DbContext)
                                          Where Codes.Contains(Entity.Code)
                                          Select Entity).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.Ad.LoadAllActive(DbContext)
                                          Where Codes.Contains(Entity.Number)
                                          Select Entity).ToList

                        End If

                    Else

                        If FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString Then

                            Datasource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketCode.ToString Then

                            Datasource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeCode.ToString Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(DbContext)
                                          Where Entity.MediaType = MediaType
                                          Select Entity).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString Then

                            Datasource = AdvantageFramework.Database.Procedures.InternetType.LoadAllActive(DbContext).ToList

                        ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString OrElse
                                FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString Then

                            Datasource = (From Item In AdvantageFramework.Database.Procedures.Ad.LoadAllActive(DbContext).ToList
                                          Where Item.ClientCode = If(String.IsNullOrWhiteSpace(ClientCode), Item.ClientCode, ClientCode)
                                          Select Item).ToList

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.DigitalResult.Properties.SalesClassCode.ToString,
                        AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.SalesClassCode.ToString

                    OverrideDefaultDataSource = True

                    If MediaPlanID.HasValue Then

                        If MediaPlanDetailID.HasValue Then

                            SalesClassCodes = {AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID.Value).SalesClassCode}


                        Else

                            SalesClassCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, MediaPlanID.Value)
                                               Select Entity.SalesClassCode).ToArray

                        End If

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, MediaType)
                                      Where SalesClassCodes.Contains(Entity.Code)
                                      Select Entity).ToList

                    Else

                        Datasource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, MediaType).ToList

                    End If

            End Select

        End Sub
        Public Function ProcessShowingEditor(ByVal FieldName As String, ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult) As Boolean

            ProcessShowingEditor = ProcessShowingEditor(FieldName, DigitalResult.MediaPlanID, DigitalResult.ClientCode, DigitalResult.DivisionCode, DigitalResult.ProductCode,
                                                        DigitalResult.MediaPlanDetailID, DigitalResult.CampaignID, DigitalResult.VendorCode, DigitalResult.AdNumber, DigitalResult.JobNumber,
                                                        DigitalResult.JobComponentNumber, DigitalResult.MarketCode, DigitalResult.InternetTypeCode, DigitalResult.AdSizeCode, DigitalResult.MediaType)

        End Function
        Public Function ProcessShowingEditor(ByVal FieldName As String, ByVal DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView) As Boolean

            ProcessShowingEditor = ProcessShowingEditor(FieldName, DigitalResultsView.MediaPlanID, DigitalResultsView.ClientCode, DigitalResultsView.DivisionCode, DigitalResultsView.ProductCode,
                                                        DigitalResultsView.EstimateID, DigitalResultsView.CampaignID, DigitalResultsView.VendorCode, DigitalResultsView.AdNumber, DigitalResultsView.JobNumber,
                                                        DigitalResultsView.JobComponentNumber, DigitalResultsView.MarketCode, DigitalResultsView.InternetTypeCode, DigitalResultsView.AdSizeCode, DigitalResultsView.MediaType)

        End Function
        Public Function ProcessShowingEditor(ByVal FieldName As String, ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging) As Boolean

            ProcessShowingEditor = ProcessShowingEditor(FieldName, ImportDigitalResultsStaging.MediaPlanID, ImportDigitalResultsStaging.ClientCode, ImportDigitalResultsStaging.DivisionCode,
                                                        ImportDigitalResultsStaging.ProductCode, ImportDigitalResultsStaging.MediaPlanDetailID, ImportDigitalResultsStaging.CampaignID,
                                                        ImportDigitalResultsStaging.VendorCode, ImportDigitalResultsStaging.AdNumber, ImportDigitalResultsStaging.JobNumber,
                                                        ImportDigitalResultsStaging.JobComponentNumber, ImportDigitalResultsStaging.MarketCode, ImportDigitalResultsStaging.InternetTypeCode,
                                                        ImportDigitalResultsStaging.AdSizeCode, ImportDigitalResultsStaging.MediaType)

        End Function
        Private Function ProcessShowingEditor(ByVal FieldName As String, ByVal MediaPlanID As Integer?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                              ByVal MediaPlanDetailID As Integer?, ByVal CampaignID As Integer?, ByVal VendorCode As String, ByVal AdNumber As String, ByVal JobNumber As Integer?,
                                              ByVal JobComponentNumber As Short?, ByVal MarketCode As String, ByVal InternetTypeCode As String, ByVal AdSizeCode As String, ByVal MediaType As String) As Boolean

            'objects
            Dim CancelEdit As Boolean = False

            If FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ClientCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.DivisionCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ProductCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ClientCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DivisionCode.ToString OrElse
               FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ProductCode.ToString Then

                If MediaPlanID.HasValue = True Then

                    CancelEdit = True

                ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.DivisionCode.ToString OrElse
                       FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DivisionCode.ToString Then

                    If String.IsNullOrWhiteSpace(ClientCode) Then

                        CancelEdit = True

                    End If

                ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ProductCode.ToString OrElse
                       FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ProductCode.ToString Then

                    If String.IsNullOrWhiteSpace(DivisionCode) Then

                        CancelEdit = True

                    End If

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ClientName.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ClientName.ToString Then

                CancelEdit = Not String.IsNullOrWhiteSpace(ClientCode)

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.CampaignName.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignName.ToString Then

                CancelEdit = CampaignID.HasValue

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorName.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorName.ToString Then

                CancelEdit = Not String.IsNullOrWhiteSpace(VendorCode)

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumberDescription.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumberDescription.ToString Then

                CancelEdit = Not String.IsNullOrWhiteSpace(AdNumber)

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaPlanDetailID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString Then

                If MediaPlanID.HasValue = False Then

                    CancelEdit = True

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaType.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.CampaignID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.CampaignCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.SalesClassCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaType.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.CampaignCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.SalesClassCode.ToString Then

                If MediaPlanID.HasValue AndAlso MediaPlanDetailID.HasValue Then

                    CancelEdit = True

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MarketDescription.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketDescription.ToString Then

                CancelEdit = Not String.IsNullOrWhiteSpace(MarketCode)

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeDescription.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeDescription.ToString Then

                If MediaType <> "I" Then

                    CancelEdit = True

                Else

                    CancelEdit = Not String.IsNullOrWhiteSpace(InternetTypeCode)

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdSizeDescription.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeDescription.ToString Then

                CancelEdit = Not String.IsNullOrWhiteSpace(AdSizeCode)

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.InternetTypeCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.InternetTypeCode.ToString Then

                If MediaType <> "I" Then

                    CancelEdit = True

                End If

            End If

            ProcessShowingEditor = CancelEdit

        End Function
        Public Sub ProcessCellValueChanged(ByVal Session As AdvantageFramework.Security.Session, ByVal FieldName As String, ByVal Value As Object, ByRef RefreshGrid As Boolean,
                                           ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult)

            ProcessCellValueChanged(Session, FieldName, Value, RefreshGrid, DigitalResult.MediaPlanID, DigitalResult.ClientCode, DigitalResult.ClientName, DigitalResult.DivisionCode,
                                    DigitalResult.ProductCode, DigitalResult.MediaPlanDetailID, DigitalResult.CampaignID, DigitalResult.CampaignCode,
                                    DigitalResult.CampaignName, DigitalResult.VendorCode, DigitalResult.VendorName, DigitalResult.SalesClassCode, DigitalResult.AdNumberDescription,
                                    DigitalResult.AdSizeCode, DigitalResult.InternetTypeCode, DigitalResult.MarketCode, DigitalResult.NetGrossRate, DigitalResult.MediaType, DigitalResult.JobNumber)

        End Sub
        Public Sub ProcessCellValueChanged(ByVal Session As AdvantageFramework.Security.Session, ByVal FieldName As String, ByVal Value As Object, ByRef RefreshGrid As Boolean,
                                           ByVal DigitalResultsView As AdvantageFramework.Database.Entities.DigitalResultsView)

            ProcessCellValueChanged(Session, FieldName, Value, RefreshGrid, DigitalResultsView.MediaPlanID, DigitalResultsView.ClientCode, DigitalResultsView.ClientName, DigitalResultsView.DivisionCode,
                                    DigitalResultsView.ProductCode, DigitalResultsView.EstimateID, DigitalResultsView.CampaignID, DigitalResultsView.CampaignCode,
                                    DigitalResultsView.CampaignName, DigitalResultsView.VendorCode, DigitalResultsView.VendorName, DigitalResultsView.SalesClassCode, DigitalResultsView.AdNumberDescription,
                                    DigitalResultsView.AdSizeCode, DigitalResultsView.InternetTypeCode, DigitalResultsView.MarketCode, DigitalResultsView.NetGrossRate, DigitalResultsView.MediaType, DigitalResultsView.JobNumber)

        End Sub
        Public Sub ProcessCellValueChanged(ByVal Session As AdvantageFramework.Security.Session, ByVal FieldName As String, ByVal Value As Object, ByRef RefreshGrid As Boolean,
                                           ByVal ImportDigitalResultsStaging As AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

            ProcessCellValueChanged(Session, FieldName, Value, RefreshGrid, ImportDigitalResultsStaging.MediaPlanID, ImportDigitalResultsStaging.ClientCode, ImportDigitalResultsStaging.ClientName,
                                    ImportDigitalResultsStaging.DivisionCode, ImportDigitalResultsStaging.ProductCode, ImportDigitalResultsStaging.MediaPlanDetailID, ImportDigitalResultsStaging.CampaignID,
                                    ImportDigitalResultsStaging.CampaignCode, ImportDigitalResultsStaging.CampaignName, ImportDigitalResultsStaging.VendorCode, ImportDigitalResultsStaging.VendorName,
                                    ImportDigitalResultsStaging.SalesClassCode, ImportDigitalResultsStaging.AdNumberDescription, ImportDigitalResultsStaging.AdSizeCode, ImportDigitalResultsStaging.InternetTypeCode,
                                    ImportDigitalResultsStaging.MarketCode, ImportDigitalResultsStaging.NetGrossRate, ImportDigitalResultsStaging.MediaType, ImportDigitalResultsStaging.JobNumber)

        End Sub
        Private Sub ProcessCellValueChanged(ByVal Session As AdvantageFramework.Security.Session, ByVal FieldName As String, ByVal Value As Object, ByRef RefreshGrid As Boolean, ByRef MediaPlanID As Integer?,
                                            ByRef ClientCode As String, ByRef ClientName As String, ByRef DivisionCode As String, ByRef ProductCode As String, ByRef MediaPlanDetailID As Integer?, ByRef CampaignID As Integer?,
                                            ByRef CampaignCode As String, ByRef CampaignName As String, ByRef VendorCode As String, ByRef VendorName As String, ByRef SalesClassCode As String, ByRef AdNumberDescription As String,
                                            ByRef AdSizeCode As String, ByRef InternetTypeCode As String, ByRef MarketCode As String, ByRef NetGrossRate As Decimal?, ByRef MediaType As String, ByVal JobNumber As Integer?)

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim ThisClientCode As String = Nothing
            Dim ThisClientName As String = Nothing
            Dim ThisDivisionCode As String = Nothing
            Dim ThisProductCode As String = Nothing
            Dim ThisSalesClassCode As String = Nothing
            Dim ThisCampaignID As Integer? = Nothing
            Dim ThisCampaignCode As String = Nothing
            Dim ThisCampaignName As String = Nothing
            Dim ThisVendorCode As String = Nothing
            Dim ThisVendorName As String = Nothing
            Dim ThisMarketCode As String = Nothing
            Dim ThisInternetTypeCode As String = Nothing
            Dim ThisAdSizeCode As String = Nothing
            Dim ThisAdNumberDescription As String = Nothing
            Dim ThisNetGrossRateFlag As Decimal? = Nothing
            Dim VendorList As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim MarketList As IEnumerable(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim InternetTypeList As IEnumerable(Of AdvantageFramework.Database.Entities.InternetType) = Nothing
            Dim AdSizeList As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) = Nothing
            Dim ThisMediaType As String = Nothing

            If FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanID.ToString OrElse
                FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaPlanID.ToString Then

                If Value IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, CInt(Value))

                        If MediaPlan IsNot Nothing Then

                            ThisClientCode = MediaPlan.ClientCode
                            ThisDivisionCode = MediaPlan.DivisionCode
                            ThisProductCode = MediaPlan.ProductCode
                            ThisClientName = MediaPlan.Client.Name

                        End If

                    End Using

                End If

                ClientCode = ThisClientCode
                ClientName = ThisClientName
                DivisionCode = ThisDivisionCode
                ProductCode = ThisProductCode
                MediaPlanDetailID = Nothing

                RefreshGrid = True

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.MediaPlanDetailID.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString Then

                If String.IsNullOrWhiteSpace(VendorCode) Then

                    ThisVendorName = VendorName

                End If

                If Value IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, CInt(Value))

                        If MediaPlanDetail IsNot Nothing Then

                            ThisSalesClassCode = MediaPlanDetail.SalesClassCode
                            ThisCampaignID = MediaPlanDetail.CampaignID
                            ThisNetGrossRateFlag = If(MediaPlanDetail.IsEstimateGrossAmount = True, 1, 0)
                            ThisMediaType = MediaPlanDetail.SalesClassType

                            If ThisCampaignID.HasValue Then

                                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ThisCampaignID.GetValueOrDefault(0))

                                If Campaign IsNot Nothing Then

                                    ThisCampaignCode = Campaign.Code
                                    ThisCampaignName = Campaign.Name

                                End If

                            End If

                            Try

                                LoadColumnEditorDatasource(DbContext, AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString, False, VendorList, MediaPlanID, Nothing, Nothing, Nothing, MediaPlanDetailID, Nothing, Nothing, Nothing, Nothing, MediaType, JobNumber)

                            Catch ex As Exception

                            End Try

                            If VendorList IsNot Nothing Then

                                If VendorList.Count = 1 Then

                                    ThisVendorCode = VendorList.First.Code
                                    ThisVendorName = VendorList.First.Name

                                ElseIf Not String.IsNullOrWhiteSpace(VendorCode) Then

                                    ThisVendorCode = VendorCode
                                    ThisVendorName = VendorName

                                    If Not VendorList.Any(Function(item) item.Code = ThisVendorCode) Then

                                        ThisVendorCode = Nothing
                                        ThisVendorName = Nothing

                                    End If

                                End If

                            End If

                            Try

                                LoadColumnEditorDatasource(DbContext, AdvantageFramework.Database.Entities.DigitalResult.Properties.MarketCode.ToString, False, MarketList, MediaPlanID, Nothing, Nothing, Nothing, MediaPlanDetailID, Nothing, Nothing, Nothing, Nothing, MediaType, JobNumber)

                            Catch ex As Exception

                            End Try

                            If MarketList IsNot Nothing Then

                                If MarketList.Count = 1 Then

                                    ThisMarketCode = MarketList.First.Code

                                ElseIf Not String.IsNullOrWhiteSpace(MarketCode) Then

                                    ThisMarketCode = MarketCode

                                    If Not MarketList.Any(Function(item) item.Code = ThisMarketCode) Then

                                        MarketCode = Nothing

                                    End If

                                End If

                            End If

                            Try

                                LoadColumnEditorDatasource(DbContext, AdvantageFramework.Database.Entities.DigitalResult.Properties.InternetTypeCode.ToString, False, InternetTypeList, MediaPlanID, Nothing, Nothing, Nothing, MediaPlanDetailID, Nothing, Nothing, Nothing, Nothing, MediaType, JobNumber)

                            Catch ex As Exception

                            End Try

                            If InternetTypeList IsNot Nothing Then

                                If InternetTypeList.Count = 1 Then

                                    ThisInternetTypeCode = InternetTypeList.First.Code

                                ElseIf Not String.IsNullOrWhiteSpace(InternetTypeCode) Then

                                    ThisInternetTypeCode = InternetTypeCode

                                    If Not InternetTypeList.Any(Function(item) item.Code = ThisInternetTypeCode) Then

                                        ThisInternetTypeCode = Nothing

                                    End If

                                End If


                            End If

                            Try

                                LoadColumnEditorDatasource(DbContext, AdvantageFramework.Database.Entities.DigitalResult.Properties.AdSizeCode.ToString, False, AdSizeList, MediaPlanID, Nothing, Nothing, Nothing, MediaPlanDetailID, Nothing, Nothing, Nothing, Nothing, MediaType, JobNumber)

                            Catch ex As Exception

                            End Try

                            If AdSizeList IsNot Nothing Then

                                If AdSizeList.Count = 1 Then

                                    ThisAdSizeCode = AdSizeList.First.Code

                                ElseIf Not String.IsNullOrWhiteSpace(AdSizeCode) Then

                                    ThisAdSizeCode = AdSizeCode

                                    If Not AdSizeList.Any(Function(item) item.Code = ThisAdSizeCode) Then

                                        ThisAdSizeCode = Nothing

                                    End If

                                End If

                            End If

                        End If

                    End Using

                Else

                    ThisVendorCode = VendorCode
                    ThisVendorName = VendorName
                    ThisMarketCode = MarketCode
                    ThisInternetTypeCode = InternetTypeCode
                    AdSizeCode = ThisAdSizeCode

                End If

                VendorCode = ThisVendorCode
                VendorName = ThisVendorName
                MarketCode = ThisMarketCode
                InternetTypeCode = ThisInternetTypeCode
                AdSizeCode = ThisAdSizeCode

                SalesClassCode = ThisSalesClassCode
                CampaignID = ThisCampaignID
                CampaignCode = ThisCampaignCode
                CampaignName = ThisCampaignName
                NetGrossRate = ThisNetGrossRateFlag
                MediaType = ThisMediaType

                RefreshGrid = True

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.VendorCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.VendorCode.ToString Then

                If Value IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, CStr(Value))

                        If Vendor IsNot Nothing Then

                            ThisVendorName = Vendor.Name

                        End If

                    End Using

                End If

                VendorName = ThisVendorName

                RefreshGrid = True

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.AdNumber.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.AdNumber.ToString Then

                If Value IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Ad = AdvantageFramework.Database.Procedures.Ad.LoadByAdNumber(DbContext, Value.ToString)

                        If Ad IsNot Nothing Then

                            ThisAdNumberDescription = Ad.Description

                        End If

                    End Using

                End If

                AdNumberDescription = ThisAdNumberDescription

                RefreshGrid = True

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ClientCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.DivisionCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ProductCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ClientCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.DivisionCode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.DigitalResult.Properties.ProductCode.ToString Then

                If String.IsNullOrWhiteSpace(CampaignCode) = False OrElse CampaignID.HasValue Then

                    ThisCampaignCode = CampaignCode
                    ThisCampaignID = CampaignID

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, ClientCode, DivisionCode, ProductCode)
                            Where (Entity.IsClosed Is Nothing OrElse
                                   Entity.IsClosed = 0) AndAlso
                                   Entity.Code = If(ThisCampaignCode = Nothing, Entity.Code, ThisCampaignCode) AndAlso
                                   Entity.ID = If(ThisCampaignID Is Nothing, Entity.ID, ThisCampaignID)
                            Select Entity).Any = False Then

                            CampaignID = Nothing
                            CampaignCode = Nothing
                            CampaignName = Nothing

                        End If

                    End Using

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaType.ToString Then

                If MediaType <> "I" Then

                    InternetTypeCode = Nothing

                End If

                AdSizeCode = Nothing

            End If

        End Sub
        Public Sub SetDigitalResultsAutoFillDependentProperties(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SelectedItems As IEnumerable)

            'objects
            Dim FirstItem As Object = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Core.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Core.Product) = Nothing
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Core.Campaign) = Nothing
            Dim VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
            Dim MarketList As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim AdSizeList As Generic.List(Of AdvantageFramework.Database.Entities.AdSize) = Nothing
            Dim InternetTypeList As Generic.List(Of AdvantageFramework.Database.Entities.InternetType) = Nothing
            Dim JobList As Generic.List(Of AdvantageFramework.Database.Core.Job) = Nothing
            Dim JobComponentList As Generic.List(Of AdvantageFramework.Database.Core.JobComponent) = Nothing
            Dim AdNumberList As Generic.List(Of AdvantageFramework.Database.Entities.Ad) = Nothing
            Dim LoadClients As Boolean = False
            Dim LoadDivisions As Boolean = False
            Dim LoadProducts As Boolean = False
            Dim LoadJobs As Boolean = False
            Dim LoadJobComponents As Boolean = False
            Dim LoadCampaigns As Boolean = False
            Dim LoadVendors As Boolean = False
            Dim LoadMarkets As Boolean = False
            Dim LoadAdSizes As Boolean = False
            Dim LoadInternetTypes As Boolean = False
            Dim LoadAdNumbers As Boolean = False

            FirstItem = (From Item In SelectedItems Select Item).First

            If FirstItem IsNot Nothing Then

                If TypeOf FirstItem Is AdvantageFramework.Database.Entities.DigitalResult Then

                    With SelectedItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResult).ToList

                        LoadClients = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ClientCode))
                        LoadDivisions = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.DivisionCode))
                        LoadProducts = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ProductCode))
                        LoadJobs = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0)
                        LoadJobComponents = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0 AndAlso item.JobComponentNumber.GetValueOrDefault(0) > 0)
                        LoadCampaigns = .Any(Function(item) item.CampaignID.GetValueOrDefault(0) > 0)
                        LoadVendors = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.VendorCode))
                        LoadMarkets = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.MarketCode))
                        LoadAdSizes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdSizeCode))
                        LoadInternetTypes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.InternetTypeCode))
                        LoadAdNumbers = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdNumber))

                    End With

                ElseIf TypeOf FirstItem Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                    With SelectedItems.OfType(Of AdvantageFramework.Database.Entities.ImportDigitalResultsStaging).ToList

                        LoadClients = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ClientCode))
                        LoadDivisions = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.DivisionCode))
                        LoadProducts = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ProductCode))
                        LoadJobs = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0)
                        LoadJobComponents = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0 AndAlso item.JobComponentNumber.GetValueOrDefault(0) > 0)
                        LoadCampaigns = .Any(Function(item) item.CampaignID.GetValueOrDefault(0) > 0)
                        LoadVendors = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.VendorCode))
                        LoadMarkets = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.MarketCode))
                        LoadAdSizes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdSizeCode))
                        LoadInternetTypes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.InternetTypeCode))
                        LoadAdNumbers = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdNumber))

                    End With

                ElseIf TypeOf FirstItem Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                    With SelectedItems.OfType(Of AdvantageFramework.Database.Entities.DigitalResultsView).ToList

                        LoadClients = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ClientCode))
                        LoadDivisions = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.DivisionCode))
                        LoadProducts = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.ProductCode))
                        LoadJobs = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0)
                        LoadJobComponents = .Any(Function(item) item.JobNumber.GetValueOrDefault(0) > 0 AndAlso item.JobComponentNumber.GetValueOrDefault(0) > 0)
                        LoadCampaigns = .Any(Function(item) item.CampaignID.GetValueOrDefault(0) > 0)
                        LoadVendors = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.VendorCode))
                        LoadMarkets = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.MarketCode))
                        LoadAdSizes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdSizeCode))
                        LoadInternetTypes = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.InternetTypeCode))
                        LoadAdNumbers = .Any(Function(item) Not String.IsNullOrWhiteSpace(item.AdNumber))

                    End With

                End If

                If LoadClients OrElse LoadJobs Then

                    ClientList = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)

                End If

                If LoadDivisions OrElse LoadJobs Then

                    DivisionList = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)

                End If

                If LoadProducts OrElse LoadJobs Then

                    ProductList = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)

                End If

                If LoadJobs Then

                    JobList = AdvantageFramework.Database.Procedures.Job.LoadCore(DbContext)

                    If LoadJobComponents Then

                        JobComponentList = AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext)

                    End If

                End If

                If LoadCampaigns Then

                    CampaignList = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext).ToList

                End If

                If LoadVendors Then

                    VendorList = AdvantageFramework.Database.Procedures.Vendor.LoadCore(DbContext).ToList

                End If

                If LoadMarkets Then

                    MarketList = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList

                End If

                If LoadAdSizes Then

                    AdSizeList = AdvantageFramework.Database.Procedures.AdSize.Load(DbContext).ToList

                End If

                If LoadInternetTypes Then

                    InternetTypeList = AdvantageFramework.Database.Procedures.InternetType.Load(DbContext).ToList

                End If

                If LoadAdNumbers Then

                    AdNumberList = AdvantageFramework.Database.Procedures.Ad.Load(DbContext).ToList

                End If

                For Each SelectedItem In SelectedItems

                    If TypeOf SelectedItem Is AdvantageFramework.Database.Entities.DigitalResult Then

                        With DirectCast(SelectedItem, AdvantageFramework.Database.Entities.DigitalResult)

                            SetDigitalResultsAutoFillDependentProperties(ClientList, DivisionList, ProductList, JobList, JobComponentList, CampaignList, VendorList, MarketList, AdSizeList, InternetTypeList, AdNumberList,
                                                                         .ClientCode, .ClientName, .DivisionCode, .ProductCode, .JobNumber, .JobDescription, .JobComponentNumber, .JobComponentDescription, .CampaignID, .CampaignCode,
                                                                         .CampaignName, .VendorCode, .VendorName, .MarketCode, .MarketDescription, .AdSizeCode, .AdSizeDescription, .InternetTypeCode, .InternetTypeDescription,
                                                                         .AdNumber, .AdNumberDescription)

                        End With

                    ElseIf TypeOf SelectedItem Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                        With DirectCast(SelectedItem, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging)

                            SetDigitalResultsAutoFillDependentProperties(ClientList, DivisionList, ProductList, JobList, JobComponentList, CampaignList, VendorList, MarketList, AdSizeList, InternetTypeList, AdNumberList,
                                                                         .ClientCode, .ClientName, .DivisionCode, .ProductCode, .JobNumber, .JobDescription, .JobComponentNumber, .JobComponentDescription, .CampaignID, .CampaignCode,
                                                                         .CampaignName, .VendorCode, .VendorName, .MarketCode, .MarketDescription, .AdSizeCode, .AdSizeDescription, .InternetTypeCode, .InternetTypeDescription,
                                                                         .AdNumber, .AdNumberDescription)

                        End With

                    ElseIf TypeOf SelectedItem Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                        With DirectCast(SelectedItem, AdvantageFramework.Database.Entities.DigitalResultsView)

                            SetDigitalResultsAutoFillDependentProperties(ClientList, DivisionList, ProductList, JobList, JobComponentList, CampaignList, VendorList, MarketList, AdSizeList, InternetTypeList, AdNumberList,
                                                                         .ClientCode, .ClientName, .DivisionCode, .ProductCode, .JobNumber, .JobDescription, .JobComponentNumber, .JobComponentDescription, .CampaignID, .CampaignCode,
                                                                         .CampaignName, .VendorCode, .VendorName, .MarketCode, .MarketDescription, .AdSizeCode, .AdSizeDescription, .InternetTypeCode, .InternetTypeDescription,
                                                                         .AdNumber, .AdNumberDescription)

                        End With

                    End If

                Next

            End If

        End Sub
        Private Sub SetDigitalResultsAutoFillDependentProperties(ByVal ClientList As Generic.List(Of AdvantageFramework.Database.Core.Client),
                                                                 ByVal DivisionList As Generic.List(Of AdvantageFramework.Database.Core.Division),
                                                                 ByVal ProductList As Generic.List(Of AdvantageFramework.Database.Core.Product),
                                                                 ByVal JobList As Generic.List(Of AdvantageFramework.Database.Core.Job),
                                                                 ByVal JobComponentList As Generic.List(Of AdvantageFramework.Database.Core.JobComponent),
                                                                 ByVal CampaignList As Generic.List(Of AdvantageFramework.Database.Core.Campaign),
                                                                 ByVal VendorList As Generic.List(Of AdvantageFramework.Database.Core.Vendor),
                                                                 ByVal MarketList As Generic.List(Of AdvantageFramework.Database.Entities.Market),
                                                                 ByVal AdSizeList As Generic.List(Of AdvantageFramework.Database.Entities.AdSize),
                                                                 ByVal InternetTypeList As Generic.List(Of AdvantageFramework.Database.Entities.InternetType),
                                                                 ByVal AdNumberList As Generic.List(Of AdvantageFramework.Database.Entities.Ad),
                                                                 ByRef ClientCode As String, ByRef ClientName As String, ByRef DivisionCode As String,
                                                                 ByRef ProductCode As String, ByVal JobNumber As Integer?, ByRef JobDescription As String,
                                                                 ByVal JobComponentNumber As Short?, ByRef JobComponentDescription As String, ByRef CampaignID As Integer?,
                                                                 ByRef CampaignCode As String, ByRef CampaignName As String, ByVal VendorCode As String, ByRef VendorName As String,
                                                                 ByVal MarketCode As String, ByRef MarketDescription As String, ByVal AdSizeCode As String, ByRef AdSizeDescription As String,
                                                                 ByVal InternetTypeCode As String, ByRef InternetTypeDescription As String, ByVal AdNumber As String, ByRef AdNumberDescription As String)

            'objects
            Dim ValidCampaigns As Generic.List(Of AdvantageFramework.Database.Core.Campaign) = Nothing
            Dim Job As AdvantageFramework.Database.Core.Job = Nothing
            Dim Campaign As AdvantageFramework.Database.Core.Campaign = Nothing
            Dim Vendor As AdvantageFramework.Database.Core.Vendor = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim InternetType As AdvantageFramework.Database.Entities.InternetType = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim ThisClientCode As String = Nothing
            Dim ThisDivisionCode As String = Nothing
            Dim ThisProductCode As String = Nothing
            Dim ThisCampaignID As Integer = Nothing

            If JobNumber.GetValueOrDefault(0) > 0 Then

                Job = JobList.Where(Function(Entity) Entity.Number = JobNumber.GetValueOrDefault(0)).SingleOrDefault

                If Job IsNot Nothing Then

                    ClientCode = Job.ClientCode
                    DivisionCode = Job.DivisionCode
                    ProductCode = Job.ProductCode
                    JobDescription = Job.Description

                    If JobComponentNumber.GetValueOrDefault(0) > 0 Then

                        JobComponentDescription = JobComponentList.Where(Function(Entity) Entity.JobNumber = Job.Number AndAlso Entity.Number = JobComponentNumber.GetValueOrDefault(0)).SingleOrDefault.Description

                    End If

                End If

            End If

            If Not String.IsNullOrEmpty(ClientCode) Then

                ThisClientCode = ClientCode
                ThisDivisionCode = DivisionCode
                ThisProductCode = ProductCode

                ClientName = ClientList.Where(Function(Entity) Entity.Code = ThisClientCode).Select(Function(Entity) Entity.Name).FirstOrDefault

                If Not String.IsNullOrWhiteSpace(ThisDivisionCode) Then

                    If (From Entity In DivisionList
                        Where Entity.ClientCode = ThisClientCode AndAlso
                              Entity.Code = ThisDivisionCode
                        Select Entity).Any = False Then

                        DivisionCode = Nothing
                        ProductCode = Nothing

                    ElseIf Not String.IsNullOrWhiteSpace(ThisProductCode) Then

                        If (From Entity In ProductList
                            Where Entity.ClientCode = ThisClientCode AndAlso
                                  Entity.DivisionCode = ThisDivisionCode AndAlso
                                  Entity.Code = ThisProductCode
                            Select Entity).Any = False Then

                            ProductCode = Nothing

                        End If

                    End If

                End If

                If CampaignList IsNot Nothing Then

                    ValidCampaigns = (From Entity In CampaignList
                                      Where Entity.ClientCode = ThisClientCode AndAlso
                                        (Entity.DivisionCode = Nothing OrElse
                                         Entity.DivisionCode = If(ThisDivisionCode = Nothing, Entity.DivisionCode, ThisDivisionCode)) AndAlso
                                        (Entity.ProductCode = Nothing OrElse
                                         Entity.ProductCode = If(ThisProductCode = Nothing, Entity.ProductCode, ThisProductCode))
                                      Select Entity).ToList

                End If

            Else

                ValidCampaigns = CampaignList

            End If

            If CampaignID.HasValue Then

                ThisCampaignID = CampaignID.GetValueOrDefault(0)

                Try

                    Campaign = ValidCampaigns.Where(Function(Entity) Entity.ID = ThisCampaignID).Select(Function(Entity) Entity).SingleOrDefault

                Catch ex As Exception

                End Try

                If Campaign IsNot Nothing Then

                    CampaignCode = ValidCampaigns.Where(Function(Entity) Entity.ID = ThisCampaignID).Select(Function(Entity) Entity.Code).FirstOrDefault
                    CampaignName = ValidCampaigns.Where(Function(Entity) Entity.ID = ThisCampaignID).Select(Function(Entity) Entity.Name).FirstOrDefault

                Else

                    CampaignCode = Nothing
                    CampaignName = Nothing
                    CampaignID = Nothing

                End If

            End If

            If String.IsNullOrWhiteSpace(VendorCode) = False Then

                Vendor = VendorList.Where(Function(Ven) Ven.Code = VendorCode).SingleOrDefault

                If Vendor IsNot Nothing Then

                    VendorName = Vendor.Name

                Else

                    VendorName = Nothing

                End If

            End If

            If Not String.IsNullOrWhiteSpace(MarketCode) Then

                Market = MarketList.Where(Function(item) item.Code = MarketCode).SingleOrDefault

                If Market IsNot Nothing Then

                    MarketDescription = Market.Description

                Else

                    MarketDescription = Nothing

                End If

            End If

            If Not String.IsNullOrWhiteSpace(AdSizeCode) Then

                AdSize = AdSizeList.Where(Function(item) item.Code = AdSizeCode).SingleOrDefault

                If AdSize IsNot Nothing Then

                    AdSizeDescription = AdSize.Description

                Else

                    AdSizeDescription = Nothing

                End If

            End If

            If Not String.IsNullOrWhiteSpace(InternetTypeCode) Then

                InternetType = InternetTypeList.Where(Function(item) item.Code = InternetTypeCode).SingleOrDefault

                If InternetType IsNot Nothing Then

                    InternetTypeDescription = InternetType.Description

                Else

                    InternetTypeDescription = Nothing

                End If

            End If

            If Not String.IsNullOrWhiteSpace(AdNumber) Then

                Ad = AdNumberList.Where(Function(item) item.Number = AdNumber).SingleOrDefault

                If Ad IsNot Nothing Then

                    AdNumberDescription = Ad.Description

                Else

                    AdNumberDescription = Nothing

                End If

            End If

        End Sub

    End Module

End Namespace
