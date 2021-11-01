Namespace Reporting.Presentation

    Public Class MediaCurrentStatusInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext)

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadCDPs()

            DataGridViewSelectCDPs_CDPs.ClearGridCustomization()

            If RadioButtonSelectionCriteria_Client.Checked Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewSelectCDPs_CDPs.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

                    DataGridViewSelectCDPs_CDPs.CurrentView.BestFitColumns()

                End Using

            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewSelectCDPs_CDPs.DataSource = AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext).Include("Client")

                    DataGridViewSelectCDPs_CDPs.CurrentView.BestFitColumns()

                End Using

            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewSelectCDPs_CDPs.DataSource = AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Include("Office").Include("Client").Include("Division")

                    DataGridViewSelectCDPs_CDPs.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub LoadCampaigns()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectCampaigns_Campaigns.DataSource = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)

                DataGridViewSelectCampaigns_Campaigns.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadVendors()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectVendors_Vendors.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext))

                DataGridViewSelectVendors_Vendors.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadMarkets()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectMarkets_Markets.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)

                DataGridViewSelectMarkets_Markets.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadOrders()

            If RadioButtonSelectOrders_ChooseOrders.Checked Then

                DataGridViewSelectOrders_Orders.DataSource = LoadMediaOrders()

                DataGridViewSelectOrders_Orders.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ClearOrders()

            RadioButtonSelectOrders_AllOrders.Checked = True
            DataGridViewSelectOrders_Orders.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    OfficeCodesList = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                End If

                If RadioButtonSelectCDPs_Choose.Checked Then

                    If RadioButtonSelectionCriteria_Client.Checked Then

                        ClientCodesList = DataGridViewSelectCDPs_CDPs.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                    ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                        DivisionCodesList = DataGridViewSelectCDPs_CDPs.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                        ProductCodesList = DataGridViewSelectCDPs_CDPs.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                End If

                If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                    CampaignIDsList = DataGridViewSelectCampaigns_Campaigns.GetAllSelectedRowsBookmarkValues().OfType(Of Integer).ToList

                End If

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    VendorCodesList = DataGridViewSelectVendors_Vendors.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                End If

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    MarketCodesList = DataGridViewSelectMarkets_Markets.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                End If

                If CheckBoxMediaTypes_Internet.Checked Then

                    Try

                        InternetOrdersObjectQuery = AdvantageFramework.Database.Procedures.InternetOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.InternetOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.InternetOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("InternetOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.InternetOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                            InternetOrdersObjectQuery = InternetOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                        End If

                        For Each InternetOrder In InternetOrdersObjectQuery.ToList

                            MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(InternetOrder))

                        Next

                    Catch ex As Exception

                    End Try

                End If

                If CheckBoxMediaTypes_Magazine.Checked Then

                    Try

                        MagazineOrdersObjectQuery = AdvantageFramework.Database.Procedures.MagazineOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.MagazineOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.MagazineOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("MagazineOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.MagazineOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                            MagazineOrdersObjectQuery = MagazineOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                        End If

                        For Each MagazineOrder In MagazineOrdersObjectQuery.ToList

                            MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(MagazineOrder))

                        Next

                    Catch ex As Exception

                    End Try

                End If

                If CheckBoxMediaTypes_Newspaper.Checked Then

                    Try

                        NewspaperOrdersObjectQuery = AdvantageFramework.Database.Procedures.NewspaperOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.NewspaperOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.NewspaperOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("NewspaperOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.NewspaperOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                            NewspaperOrdersObjectQuery = NewspaperOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                        End If

                        For Each NewspaperOrder In NewspaperOrdersObjectQuery.ToList

                            MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(NewspaperOrder))

                        Next

                    Catch ex As Exception

                    End Try

                End If

                If CheckBoxMediaTypes_OutOfHome.Checked Then

                    Try

                        OutOfHomeOrdersObjectQuery = AdvantageFramework.Database.Procedures.OutOfHomeOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.OutOfHomeOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.OutOfHomeOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("OutOfHomeOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.OutOfHomeOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VenderCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                            OutOfHomeOrdersObjectQuery = OutOfHomeOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                        End If

                        For Each OutOfHomeOrder In OutOfHomeOrdersObjectQuery.ToList

                            MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(OutOfHomeOrder))

                        Next

                    Catch ex As Exception

                    End Try

                End If

                If CheckBoxMediaTypes_Radio.Checked Then

                    Try

                        RadioOrdersObjectQuery = AdvantageFramework.Database.Procedures.RadioOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.RadioOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.RadioOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("RadioOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.RadioOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                            RadioOrdersObjectQuery = RadioOrdersObjectQuery.Where(Function(Entity) MarketCodesList.Contains(Entity.MarketCode))

                        End If

                        For Each RadioOrder In RadioOrdersObjectQuery.ToList

                            MediaOrdersList.Add(New AdvantageFramework.Database.Classes.MediaOrder(RadioOrder))

                        Next

                    Catch ex As Exception

                    End Try

                End If

                If CheckBoxMediaTypes_Television.Checked Then

                    Try

                        TVOrdersObjectQuery = AdvantageFramework.Database.Procedures.TVOrder.Load(DbContext)

                        If RadioButtonInclude_OpenOnly.Checked Then

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) Entity.OrderProcessControl = 1)

                        End If

                        If RadioButtonSelectOffices_ChooseOffices.Checked Then

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OfficeCodesList.Contains(Entity.OfficeCode))

                        End If

                        If RadioButtonSelectCDPs_Choose.Checked Then

                            If RadioButtonSelectionCriteria_Client.Checked Then

                                TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) ClientCodesList.Contains(Entity.ClientCode))

                            ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Products").Include("Products.TVOrders").ToList.Where(Function(Entity) DivisionCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.Products).SelectMany(Function(Entity) Entity.TVOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                                OrderNumbersList = AdvantageFramework.Database.Procedures.Product.Load(DbContext).Include("TVOrders").ToList.Where(Function(Entity) ProductCodesList.Contains(Entity.ID)).SelectMany(Function(Entity) Entity.TVOrders).Select(Function(Entity) Entity.OrderNumber).ToList

                                TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) OrderNumbersList.Contains(Entity.OrderNumber))

                            End If

                        End If

                        If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) CampaignIDsList.Contains(Entity.CampaignID))

                        End If

                        If RadioButtonSelectVendors_ChooseVendors.Checked Then

                            TVOrdersObjectQuery = TVOrdersObjectQuery.Where(Function(Entity) VendorCodesList.Contains(Entity.VendorCode))

                        End If

                        If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

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

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As Windows.Forms.DialogResult

            'objects
            Dim MediaCurrentStatusInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaCurrentStatusInitialLoadingDialog = Nothing

            MediaCurrentStatusInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaCurrentStatusInitialLoadingDialog()

            ShowFormDialog = MediaCurrentStatusInitialLoadingDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaCurrentStatusInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TabControlForm_MCS.SelectedTab = TabItemMCS_OptionsTab

            DataGridViewSelectCampaigns_Campaigns.OptionsView.ShowFooter = False
            DataGridViewSelectCDPs_CDPs.OptionsView.ShowFooter = False
            DataGridViewSelectMarkets_Markets.OptionsView.ShowFooter = False
            DataGridViewSelectOffices_Offices.OptionsView.ShowFooter = False
            DataGridViewSelectOrders_Orders.OptionsView.ShowFooter = False
            DataGridViewSelectVendors_Vendors.OptionsView.ShowFooter = False

            CheckBoxMediaTypes_All.Checked = True

            ComboBoxMonthlyBroadcast_FromMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxMonthlyBroadcast_ToMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

            ComboBoxMonthlyBroadcast_FromMonth.SelectedValue = CLng(Now.Month)
            ComboBoxMonthlyBroadcast_ToMonth.SelectedValue = CLng(Now.Month)

            NumericInputMonthlyBroadcast_FromYear.EditValue = Now.Year
            NumericInputMonthlyBroadcast_ToYear.EditValue = Now.Year

            DateTimePickerNonDailyBroadcast_From.Value = Now
            DateTimePickerNonDailyBroadcast_To.Value = Now

            DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = True
            DataGridViewSelectOffices_Offices.MultiSelect = True

            DataGridViewSelectOffices_Offices.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Office)

            DataGridViewSelectCDPs_CDPs.ShowSelectDeselectAllButtons = True
            DataGridViewSelectCDPs_CDPs.MultiSelect = True

            DataGridViewSelectCDPs_CDPs.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

            DataGridViewSelectCampaigns_Campaigns.ShowSelectDeselectAllButtons = True
            DataGridViewSelectCampaigns_Campaigns.MultiSelect = True

            DataGridViewSelectCampaigns_Campaigns.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

            DataGridViewSelectVendors_Vendors.ShowSelectDeselectAllButtons = True
            DataGridViewSelectVendors_Vendors.MultiSelect = True

            DataGridViewSelectVendors_Vendors.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

            DataGridViewSelectMarkets_Markets.ShowSelectDeselectAllButtons = True
            DataGridViewSelectMarkets_Markets.MultiSelect = True

            DataGridViewSelectMarkets_Markets.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Market)

            DataGridViewSelectOrders_Orders.ShowSelectDeselectAllButtons = True
            DataGridViewSelectOrders_Orders.MultiSelect = True

            DataGridViewSelectOrders_Orders.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.MediaOrder)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = '{0}'", Me.Session.UserCode))

                    If RadioButtonSelectOrders_ChooseOrders.Checked Then

                        For Each MediaOrder In DataGridViewSelectOrders_Orders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaOrder).ToList

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.MEDIA_RPT_ORDERS([USER_ID], [ORDER_NBR], [ORDER_TYPE]) VALUES('{0}', {1}, '{2}')", Me.Session.UserCode, MediaOrder.ShortNumber, MediaOrder.TypeInitial))

                        Next

                    Else

                        For Each MediaOrder In LoadMediaOrders()

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.MEDIA_RPT_ORDERS([USER_ID], [ORDER_NBR], [ORDER_TYPE]) VALUES('{0}', {1}, '{2}')", Me.Session.UserCode, MediaOrder.ShortNumber, MediaOrder.TypeInitial))

                        Next

                    End If

                End Using

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxMediaTypes_All_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_All.CheckedChanged

            CheckBoxMediaTypes_Internet.Checked = CheckBoxMediaTypes_All.Checked
            CheckBoxMediaTypes_Magazine.Checked = CheckBoxMediaTypes_All.Checked
            CheckBoxMediaTypes_Newspaper.Checked = CheckBoxMediaTypes_All.Checked
            CheckBoxMediaTypes_OutOfHome.Checked = CheckBoxMediaTypes_All.Checked
            CheckBoxMediaTypes_Radio.Checked = CheckBoxMediaTypes_All.Checked
            CheckBoxMediaTypes_Television.Checked = CheckBoxMediaTypes_All.Checked

        End Sub
        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectOffices_Offices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectOffices_Offices.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectCDPs_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCDPs_All.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCDPs_All.Checked Then

                    PanelSelectCDP_SelectionCriteria.Enabled = False
                    DataGridViewSelectCDPs_CDPs.Enabled = False

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectCDPs_Choose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCDPs_Choose.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCDPs_Choose.Checked Then

                    LoadCDPs()

                    PanelSelectCDP_SelectionCriteria.Enabled = True
                    DataGridViewSelectCDPs_CDPs.Enabled = True

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_Client_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectionCriteria_Client.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCDPs_Choose.Checked AndAlso RadioButtonSelectionCriteria_Client.Checked Then

                    LoadCDPs()

                    PanelSelectCDP_SelectionCriteria.Enabled = True
                    DataGridViewSelectCDPs_CDPs.Enabled = True

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_ClientDivision_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectionCriteria_ClientDivision.CheckedChanged

            If Me.FormShown Then
                
                If RadioButtonSelectCDPs_Choose.Checked AndAlso RadioButtonSelectionCriteria_ClientDivision.Checked Then

                    LoadCDPs()

                    PanelSelectCDP_SelectionCriteria.Enabled = True
                    DataGridViewSelectCDPs_CDPs.Enabled = True

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_ClientDivisionProduct_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectionCriteria_ClientDivisionProduct.CheckedChanged

            If Me.FormShown Then
                
                If RadioButtonSelectCDPs_Choose.Checked AndAlso RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                    LoadCDPs()

                    PanelSelectCDP_SelectionCriteria.Enabled = True
                    DataGridViewSelectCDPs_CDPs.Enabled = True

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectCDPs_CDPs_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectCDPs_CDPs.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectCDPs_Choose.Checked Then

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectCampaigns_AllCampaigns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_AllCampaigns.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCampaigns_AllCampaigns.Checked Then

                    DataGridViewSelectCampaigns_Campaigns.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectCampaigns_ChooseCampaigns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_ChooseCampaigns.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                    If DataGridViewSelectCampaigns_Campaigns.HasRows = False Then

                        LoadCampaigns()

                    End If

                    DataGridViewSelectCampaigns_Campaigns.Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectCampaigns_Campaigns_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectCampaigns_Campaigns.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectVendors_AllVendors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectVendors_AllVendors.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectVendors_AllVendors.Checked Then

                    DataGridViewSelectVendors_Vendors.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectVendors_ChooseVendors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectVendors_ChooseVendors.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    If DataGridViewSelectVendors_Vendors.HasRows = False Then

                        LoadVendors()

                    End If

                    DataGridViewSelectVendors_Vendors.Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectVendors_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectVendors_Vendors.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectMarkets_AllMarkets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectMarkets_AllMarkets.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectMarkets_AllMarkets.Checked Then

                    DataGridViewSelectMarkets_Markets.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectMarkets_ChooseMarkets_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectMarkets_ChooseMarkets.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    If DataGridViewSelectMarkets_Markets.HasRows = False Then

                        LoadMarkets()

                    End If

                    DataGridViewSelectMarkets_Markets.Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectMarkets_Markets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectMarkets_Markets.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOrders_AllOrders_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOrders_AllOrders.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOrders_AllOrders.Checked Then

                    DataGridViewSelectOrders_Orders.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOrders_ChooseOrders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOrders_ChooseOrders.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOrders_ChooseOrders.Checked Then

                    LoadOrders()

                    DataGridViewSelectOrders_Orders.Enabled = True

                End If

            End If

        End Sub

        Private Sub CheckBoxBroadcastDates_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBroadcastDates.CheckedChanged
            If CheckBoxBroadcastDates.Checked = True Then
                LabelOptions_NonDailyBroadcast.Visible = False
                PanelOptions_NonDailyBroadcast.Visible = False
                LabelOptions_WarningMessage.Visible = False
            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace