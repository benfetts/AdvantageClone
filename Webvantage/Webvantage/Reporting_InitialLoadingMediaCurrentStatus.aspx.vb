Public Class Reporting_InitialLoadingMediaCurrentStatus
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Private _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

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

    Private Sub LoadDynamicReport()

        _DynamicReportType = Session("DRPT_Type")

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub
    Private Sub LoadOffices()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext)
            RadGridOffice.DataBind()

        End Using

    End Sub
    Private Sub LoadCDPs()

        If RadioButtonClient.Checked Then
            Me.RadGridClient.Visible = True
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridClient.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                                            Select Client.Code,
                                                   Client.Name,
                                                   Client.IsNewBusiness,
                                                   Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                    .Client = Client.Code & " - " & Client.Name,
                                                                                                                    .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                    .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList
                RadGridClient.DataBind()

            End Using

        ElseIf RadioButtonClientDivision.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = True
            Me.RadGridCDP.Visible = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridCD.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext).Include("Client")
                                        Select Division.ClientCode,
                                               Division.Code,
                                               [ClientName] = Division.Client.Name,
                                               Division.Name,
                                               Division.IsActive).ToList.Select(Function(Division) New With {.ClientCode = Division.ClientCode,
                                                                                                             .Code = Division.Code,
                                                                                                             .Client = Division.ClientCode & " - " & Division.ClientName,
                                                                                                             .Division = Division.Code & " - " & Division.Name,
                                                                                                             .IsInactive = Not CBool(Division.IsActive.GetValueOrDefault(0))}).ToList
                RadGridCD.DataBind()

            End Using

        ElseIf RadioButtonClientDivisionProduct.Checked Then
            Me.RadGridClient.Visible = False
            Me.RadGridCD.Visible = False
            Me.RadGridCDP.Visible = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridCDP.DataSource = (From product In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Include("Office").Include("Client").Include("Division")
                                         Select product.OfficeCode,
                                         product.ClientCode,
                                         product.DivisionCode,
                                         product.Code,
                                         [OfficeName] = product.Office.Name,
                                         [ClientName] = product.Client.Name,
                                         [DivisionName] = product.Division.Name,
                                         product.Name,
                                         product.IsActive).ToList.Select(Function(Entity) New With {.OfficeCode = Entity.OfficeCode,
                                                                                                    .ClientCode = Entity.ClientCode,
                                                                                                    .DivisionCode = Entity.DivisionCode,
                                                                                                    .Code = Entity.Code,
                                                                                                    .Office = Entity.OfficeCode & " - " & Entity.OfficeName,
                                                                                                    .Client = Entity.ClientCode & " - " & Entity.ClientName,
                                                                                                    .Division = Entity.DivisionCode & " - " & Entity.DivisionName,
                                                                                                    .Product = Entity.Code & " - " & Entity.Name,
                                                                                                    .[IsInactive] = Not CBool(Entity.IsActive.GetValueOrDefault(0))}).ToList
                RadGridCDP.DataBind()

            End Using

        End If

    End Sub
    Private Sub LoadCampaigns()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridCampaign.DataSource = (From Campaign In AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)
                                          Select New With {.ID = Campaign.ID,
                                                   .ClientCode = If(Campaign.ClientCode Is Nothing, "", Campaign.ClientCode),
                                                   .DivisionCode = If(Campaign.DivisionCode Is Nothing, "", Campaign.DivisionCode),
                                                   .ProductCode = If(Campaign.ProductCode Is Nothing, "", Campaign.ProductCode),
                                                   .Code = If(Campaign.Code Is Nothing, "", Campaign.Code),
                                                   .Campaign = If(Campaign Is Nothing, "", Campaign.ToString),
                                                   .Client = If(Campaign.ClientCode Is Nothing, "", Campaign.ClientCode.ToString),
                                                   .Division = If(Campaign.DivisionCode Is Nothing, "", Campaign.DivisionCode.ToString),
                                                   .Product = If(Campaign.ProductCode Is Nothing, "", Campaign.ProductCode.ToString),
                                                   .IsClosed = CBool(Campaign.IsClosed.GetValueOrDefault(0))}).ToList
            RadGridCampaign.DataBind()

        End Using

    End Sub
    Private Sub LoadVendors()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridVendors.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext))
            RadGridVendors.DataBind()

        End Using

    End Sub
    Private Sub LoadMarkets()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridMarkets.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)
            RadGridMarkets.DataBind()

        End Using

    End Sub
    Private Sub LoadOrders()

        If RadioButtonChooseOrders.Checked Then

            RadGridOrders.DataSource = LoadMediaOrders()
            RadGridOrders.DataBind()

        End If

    End Sub
    Private Sub ClearOrders()

        RadioButtonAllOrders.Checked = True
        RadGridOrders.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)
        RadGridOrders.DataBind()

    End Sub
    Private Function LoadMediaOrders() As Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)

        'objects
        Dim MediaOrdersList As Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder) = Nothing
        Dim InternetOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.InternetOrder) = Nothing
        Dim MagazineOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.MagazineOrder) = Nothing
        Dim NewspaperOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.NewspaperOrder) = Nothing
        Dim OutOfHomeOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.OutOfHomeOrder) = Nothing
        Dim RadioOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.RadioOrder) = Nothing
        Dim TVOrdersObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.TVOrder) = Nothing
        Dim OfficeCodesList As Generic.List(Of String) = Nothing
        Dim ClientCodesList As Generic.List(Of String) = Nothing
        Dim DivisionCodesList As Generic.List(Of String) = Nothing
        Dim ProductCodesList As Generic.List(Of String) = Nothing
        Dim CampaignIDsList As Generic.List(Of Integer) = Nothing
        Dim VendorCodesList As Generic.List(Of String) = Nothing
        Dim MarketCodesList As Generic.List(Of String) = Nothing
        Dim OrderNumbersList As Generic.List(Of Integer) = Nothing


        MediaOrdersList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If RadioButtonChooseOffices.Checked Then
                If RadGridOffice.Items.Count > 0 Then
                    OfficeCodesList = New Generic.List(Of String)
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOffice.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            OfficeCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                        End If
                    Next
                End If
            End If

            If RadioButtonChoose.Checked Then

                If RadioButtonClient.Checked Then
                    If RadGridClient.Items.Count > 0 Then
                        ClientCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridClient.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                ClientCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If
                ElseIf RadioButtonClientDivision.Checked Then
                    If RadGridCD.Items.Count > 0 Then
                        DivisionCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCD.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                DivisionCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If
                ElseIf RadioButtonClientDivisionProduct.Checked Then
                    If RadGridCDP.Items.Count > 0 Then
                        ProductCodesList = New Generic.List(Of String)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCDP.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                ProductCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If
                End If

            End If

            If RadioButtonChooseCampaigns.Checked Then
                If RadGridCampaign.Items.Count > 0 Then
                    CampaignIDsList = New Generic.List(Of Integer)
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCampaign.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            CampaignIDsList.Add(gridDataItem.GetDataKeyValue("ID"))
                        End If
                    Next
                End If
            End If

            If RadioButtonChooseVendors.Checked Then
                If RadGridVendors.Items.Count > 0 Then
                    VendorCodesList = New Generic.List(Of String)
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendors.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            VendorCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                        End If
                    Next
                End If
            End If

            If RadioButtonChooseMarkets.Checked Then
                If RadGridMarkets.Items.Count > 0 Then
                    MarketCodesList = New Generic.List(Of String)
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridMarkets.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            MarketCodesList.Add(gridDataItem.GetDataKeyValue("Code"))
                        End If
                    Next
                End If
            End If

            If CheckBoxInternet.Checked Then

                Try

                    InternetOrdersObjectQuery = AdvantageFramework.Database.Procedures.InternetOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.InternetOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.InternetOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("InternetOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.InternetOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each InternetOrder In InternetOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(InternetOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

            If CheckBoxMagazine.Checked Then

                Try

                    MagazineOrdersObjectQuery = AdvantageFramework.Database.Procedures.MagazineOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.MagazineOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.MagazineOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("MagazineOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.MagazineOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each MagazineOrder In MagazineOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(MagazineOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

            If CheckBoxNewspaper.Checked Then

                Try

                    NewspaperOrdersObjectQuery = AdvantageFramework.Database.Procedures.NewspaperOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.NewspaperOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.NewspaperOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("NewspaperOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.NewspaperOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each NewspaperOrder In NewspaperOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(NewspaperOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

            If CheckBoxOutOfHome.Checked Then

                Try

                    OutOfHomeOrdersObjectQuery = AdvantageFramework.Database.Procedures.OutOfHomeOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.OutOfHomeOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.OutOfHomeOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("OutOfHomeOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.OutOfHomeOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VenderCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each OutOfHomeOrder In OutOfHomeOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(OutOfHomeOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

            If CheckBoxRadio.Checked Then

                Try

                    RadioOrdersObjectQuery = AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.RadioOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.RadioOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("RadioOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.RadioOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each RadioOrder In RadioOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(RadioOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

            If CheckBoxTelevision.Checked Then

                Try

                    TVOrdersObjectQuery = AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)

                    If RadioButtonOpenOnly.Checked Then

                        TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                    End If

                    If RadioButtonChooseOffices.Checked Then

                        TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                    End If

                    If RadioButtonChoose.Checked Then

                        If RadioButtonClient.Checked Then

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                        ElseIf RadioButtonClientDivision.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.TVOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.TVOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        ElseIf RadioButtonClientDivisionProduct.Checked Then

                            OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("TVOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.TVOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                        End If

                    End If

                    If RadioButtonChooseCampaigns.Checked Then

                        TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                    End If

                    If RadioButtonChooseVendors.Checked Then

                        TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                    End If

                    If RadioButtonChooseMarkets.Checked Then

                        TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                    End If

                    For Each TVOrder In TVOrdersObjectQuery.ToList

                        MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(TVOrder))

                    Next

                Catch ex As Exception

                End Try

            End If

        End Using

        LoadMediaOrders = MediaOrdersList

    End Function

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingMediaCurrentStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            CheckBoxAll.Checked = True
            CheckBoxInternet.Checked = True
            CheckBoxMagazine.Checked = True
            CheckBoxNewspaper.Checked = True
            CheckBoxOutOfHome.Checked = True
            CheckBoxRadio.Checked = True
            CheckBoxTelevision.Checked = True

            RadComboBoxFromMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            RadComboBoxToMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            RadComboBoxFromMonth.DataBind()
            RadComboBoxToMonth.DataBind()

            RadComboBoxFromMonth.SelectedValue = CLng(Now.Month)
            RadComboBoxToMonth.SelectedValue = CLng(Now.Month)

            TextBoxFromYear.Text = Now.Year
            TextBoxToYear.Text = Now.Year

            RadDatePickerStartDate.SelectedDate = cEmployee.TimeZoneToday
            RadDatePickerEndDate.SelectedDate = cEmployee.TimeZoneToday

            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

            RadGridCampaign.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

            RadGridVendors.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

            RadGridMarkets.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Market)

            RadGridOrders.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)

            Me.PanelCDP.Visible = False

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = '{0}'", _Session.UserCode))

                    If RadioButtonChooseOrders.Checked Then

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridOrders.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.MEDIA_RPT_ORDERS([USER_ID], [ORDER_NBR], [ORDER_TYPE]) VALUES('{0}', {1}, '{2}')", _Session.UserCode, gridDataItem.GetDataKeyValue("ShortNumber"), gridDataItem.GetDataKeyValue("TypeInitial")))
                            End If
                        Next

                    Else

                        For Each MediaOrder In LoadMediaOrders()

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.MEDIA_RPT_ORDERS([USER_ID], [ORDER_NBR], [ORDER_TYPE]) VALUES('{0}', {1}, '{2}')", _Session.UserCode, MediaOrder.ShortNumber, MediaOrder.TypeInitial))

                        Next

                    End If

                End Using

                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = Nothing

                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub
    Private Sub CheckBoxAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAll.CheckedChanged

        CheckBoxInternet.Checked = CheckBoxAll.Checked
        CheckBoxMagazine.Checked = CheckBoxAll.Checked
        CheckBoxNewspaper.Checked = CheckBoxAll.Checked
        CheckBoxOutOfHome.Checked = CheckBoxAll.Checked
        CheckBoxRadio.Checked = CheckBoxAll.Checked
        CheckBoxTelevision.Checked = CheckBoxAll.Checked

    End Sub
    Private Sub RadioButtonAllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllOffices.Checked Then

            RadGridOffice.Enabled = False
            RadGridOffice.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)
            RadGridOffice.DataBind()
            ClearOrders()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOffices.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseOffices.Checked Then

            If RadGridOffice.Items.Count = 0 Then

                LoadOffices()

            End If

            RadGridOffice.Enabled = True

            ClearOrders()

        End If

        'End If

    End Sub
    Private Sub RadGridOffice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridOffice.SelectedIndexChanged
        Try
            If RadioButtonChooseOffices.Checked Then

                ClearOrders()

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadioButtonSelectCDPs_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAll.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAll.Checked Then

            PanelCDP.Visible = False
            RadGridClient.Enabled = False
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False
            RadGridClient.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
            RadGridClient.DataBind()
            ClearOrders()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChoose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChoose.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChoose.Checked Then

            LoadCDPs()

            PanelCDP.Visible = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

            ClearOrders()

        End If

        'End If

    End Sub
    Private Sub RadioButtonClient_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClient.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClient.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridClient.Enabled = True
            RadGridClient.Visible = True
            RadGridCD.Visible = False
            RadGridCDP.Visible = False

            ClearOrders()

        End If

    End Sub
    Private Sub RadioButtonClientDivision_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivision.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivision.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCD.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = True
            RadGridCDP.Visible = False

            ClearOrders()

        End If


    End Sub
    Private Sub RadioButtonClientDivisionProduct_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClientDivisionProduct.CheckedChanged

        If RadioButtonChoose.Checked AndAlso RadioButtonClientDivisionProduct.Checked Then

            LoadCDPs()

            PanelCDP.Enabled = True
            RadGridCDP.Enabled = True
            RadGridClient.Visible = False
            RadGridCD.Visible = False
            RadGridCDP.Visible = True

            ClearOrders()

        End If

    End Sub
    Private Sub RadGridClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridClient.SelectedIndexChanged

        If RadioButtonChoose.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadGridCD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridCD.SelectedIndexChanged

        If RadioButtonChoose.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadGridCDP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridCDP.SelectedIndexChanged

        If RadioButtonChoose.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadioButtonSelectCampaigns_AllCampaigns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllCampaigns.CheckedChanged

        If RadioButtonAllCampaigns.Checked Then

            RadGridCampaign.Enabled = False
            RadGridCampaign.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)
            RadGridCampaign.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseCampaigns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseCampaigns.CheckedChanged

        If RadioButtonChooseCampaigns.Checked Then

            If RadGridCampaign.Items.Count = 0 Then

                LoadCampaigns()

            End If

            RadGridCampaign.Enabled = True

        End If

    End Sub
    Private Sub RadGridCampaign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridCampaign.SelectedIndexChanged

        If RadioButtonChooseCampaigns.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadioButtonSelectVendors_AllVendors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllVendors.CheckedChanged

        If RadioButtonAllVendors.Checked Then

            RadGridVendors.Enabled = False
            RadGridVendors.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)
            RadGridVendors.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseVendors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseVendors.CheckedChanged

        If RadioButtonChooseVendors.Checked Then

            If RadGridVendors.Items.Count = 0 Then

                LoadVendors()

            End If

            RadGridVendors.Enabled = True

        End If

    End Sub
    Private Sub RadGridVendors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridVendors.SelectedIndexChanged

        If RadioButtonChooseVendors.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadioButtonSelectMarkets_AllMarkets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllMarkets.CheckedChanged

        If RadioButtonAllMarkets.Checked Then

            RadGridMarkets.Enabled = False
            RadGridMarkets.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Market)
            RadGridMarkets.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseMarkets_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseMarkets.CheckedChanged

        If RadioButtonChooseMarkets.Checked Then

            If RadGridMarkets.Items.Count = 0 Then

                LoadMarkets()

            End If

            RadGridMarkets.Enabled = True

        End If

    End Sub
    Private Sub RadGridMarkets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridMarkets.SelectedIndexChanged

        If RadioButtonChooseMarkets.Checked Then

            ClearOrders()

        End If

    End Sub
    Private Sub RadioButtonAllOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllOrders.CheckedChanged

        If RadioButtonAllOrders.Checked Then

            RadGridOrders.Enabled = False
            RadGridOrders.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)
            RadGridOrders.DataBind()

        End If

    End Sub
    Private Sub RadioButtonChooseOrders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseOrders.CheckedChanged

        If RadioButtonChooseOrders.Checked Then

            LoadOrders()

            RadGridOrders.Enabled = True

        End If

    End Sub

#End Region

#End Region

End Class
