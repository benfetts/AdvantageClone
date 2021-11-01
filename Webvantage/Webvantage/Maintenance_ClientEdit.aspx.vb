Public Class Maintenance_ClientEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ClientCode As String = ""
    Private _IsCRMUser As Boolean = False
    Private _SortNameMaxLength As Long = Nothing
    Private _WebsiteTypesList As Generic.List(Of AdvantageFramework.Database.Entities.WebsiteType) = Nothing
    Private _IsCopy As Boolean = False
    Private _ClientSortKeyList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel) = Nothing
    Private _ClientSortKeyEntityList As Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey) = Nothing
    Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadClient()

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                If Client IsNot Nothing Then

                    If _IsCopy = False Then

                        TextBoxClientCode.Enabled = False
                        TextBoxClientCode.Text = Client.Code
                        TextBoxClientName.Text = Client.Name

                        DivNewClientOptions.Visible = False
                        CollapsablePanelMediaIntegrationSettings.Visible = True
                        CollapsablePanelWebsites.Visible = True
                        CollapsablePanelDivisionProduct.Visible = True
                        CollapsablePanelContacts.Visible = True
                        RadToolBarRefresh.Visible = True

                        Me.RadToolbarClient.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

                    Else

                        TextBoxClientCode.Enabled = True
                        TextBoxClientCode.Text = ""
                        TextBoxClientName.Text = Client.Name

                        DivNewClientOptions.Visible = True
                        CollapsablePanelMediaIntegrationSettings.Visible = False
                        CollapsablePanelWebsites.Visible = False
                        CollapsablePanelDivisionProduct.Visible = False
                        CollapsablePanelContacts.Visible = False
                        RadToolBarRefresh.Visible = False

                        RadToolBarButtonDocuments.Visible = False
                        RadToolBarButtonUploadDocument.Visible = False
                        RadToolBarButtonNew.Visible = False
                        RadToolBarButtonSeparator1.Visible = False
                        RadToolBarButtonSeparator2.Visible = False
                        RadToolBarButtonSeparator3.Visible = False

                    End If

                    CheckBoxIsNewBusiness.Checked = CBool(Client.IsNewBusiness.GetValueOrDefault(0))
                    CheckBoxIsInactive.Checked = Not CBool(Client.IsActive.GetValueOrDefault(0))

                    TextBoxAddress1.Text = Client.Address
                    TextBoxAddress2.Text = Client.Address2
                    TextBoxCity.Text = Client.City
                    TextBoxCounty.Text = Client.County
                    TextBoxState.Text = Client.State
                    TextBoxZip.Text = Client.Zip
                    TextBoxCountry.Text = Client.Country

                    LoadSortKeys()
                    LoadBilling(Client)
                    LoadMediaIntegrationSettings(Client)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) Then

                    Else

                        TableRowAvalara.Visible = False

                    End If

                    'LoadProduction(Client)
                    'LoadMedia(Client)
                    'LoadMediaInvoiceFormats(Client)
                    'LoadRequiredFields(Client)
                    LoadWebsites()
                    LoadContacts()
                    'LoadContracts()
                    LoadDivisions()
                    LoadProducts(Nothing)

                    If _IsCRMUser Then

                        CheckBoxIsNewBusiness.Enabled = False

                    End If

                Else

                    RadToolBarButtonDocuments.Visible = False
                    RadToolBarButtonUploadDocument.Visible = False
                    RadToolBarButtonNew.Visible = False
                    RadToolBarButtonSeparator1.Visible = False
                    RadToolBarButtonSeparator2.Visible = False
                    RadToolBarButtonSeparator3.Visible = False

                    CollapsablePanelMediaIntegrationSettings.Visible = False
                    CollapsablePanelWebsites.Visible = False
                    CollapsablePanelContacts.Visible = False
                    CollapsablePanelDivisionProduct.Visible = False
                    DivNewClientOptions.Visible = True
                    RadToolBarRefresh.Visible = False

                    RadComboBoxFiscalStartMonth.SelectedValue = Nothing

                    If _IsCRMUser Then

                        CheckBoxIsNewBusiness.Checked = True
                        CheckBoxIsNewBusiness.Enabled = False

                    End If

                    LoadSortKeys()

                    TextBoxClientCode.Focus()

                    Me.RadToolbarClient.FindItemByValue("Bookmark").Visible = False

                End If

                If _IsCRMUser Then

                    CollapsablePanelProduction.Visible = False
                    CollapsablePanelMedia.Visible = False
                    CollapsablePanelMediaInvoiceFormat.Visible = False
                    CollapsablePanelRequiredFields.Visible = False
                    CollapsablePanelMediaIntegrationSettings.Visible = False

                End If

            End Using

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try

    End Sub
    Private Sub LoadBilling(ByVal Client As AdvantageFramework.Database.Entities.Client)

        If Client IsNot Nothing Then

            ' Billing Address
            TextBoxBillingAddress1.Text = Client.BillingAddress
            TextBoxBillingAddress2.Text = Client.BillingAddress2
            TextBoxBillingCity.Text = Client.BillingCity
            TextBoxBillingCounty.Text = Client.BillingCounty
            TextBoxBillingState.Text = Client.BillingState
            TextBoxBillingZip.Text = Client.BillingZip
            TextBoxBillingCountry.Text = Client.BillingCountry

            ' Statement Address
            TextBoxStatementAddress1.Text = Client.StatementAddress
            TextBoxStatementAddress2.Text = Client.StatementAddress2
            TextBoxStatementCity.Text = Client.StatementCity
            TextBoxStatementCounty.Text = Client.StatementCounty
            TextBoxStatementState.Text = Client.StatementState
            TextBoxStatementZip.Text = Client.StatementZip
            TextBoxStatementCountry.Text = Client.StatementCountry

            RadNumericTextBoxCreditLimit.Value = Client.CreditLimit
            RadComboBoxFiscalStartMonth.SelectedValue = CLng(Client.FiscalStart.GetValueOrDefault(0))

            ' A/R Comment
            TextBoxARComment.Text = Client.ARComment

            RadComboBoxAvalaraSalesClass.SelectedValue = Client.AvalaraSalesClassCode

            CheckBoxAvalaraTaxExempt.Checked = Client.AvalaraTaxExempt.GetValueOrDefault(False)

        End If

    End Sub
    Private Sub LoadMediaIntegrationSettings(ByVal Client As AdvantageFramework.Database.Entities.Client)

        If Client IsNot Nothing Then

            CheckBoxDoubleClickEnabled.Checked = Client.DoubleClickEnabled
            RadNumericTextBoxDoubleClickProfileID.Value = Client.DoubleClickProfileID
            RadNumericTextBoxDoubleClickReportID.Value = Client.DoubleClickReportID

        End If

    End Sub
    Private Sub LoadProduction(ByVal Client As AdvantageFramework.Database.Entities.Client)

        Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing

        If Client IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case CShort(Client.AssignProductionInvoicesBy.GetValueOrDefault(1))

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Campaign
                        RadioButtonCampaign.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Client
                        RadioButtonClient.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Division
                        RadioButtonDivision.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Job
                        RadioButtonJob.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.JobComponent
                        RadioButtonJobComponent.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Product
                        RadioButtonProduct.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.ProductSalesClass
                        RadioButtonProductSalesClass.Checked = True

                    Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.PurchaseOrder
                        RadioButtonProductClientPO.Checked = True

                End Select

                ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                If ProductionInvoiceDefault IsNot Nothing Then

                    If ProductionInvoiceDefault.CustomFormatName IsNot Nothing Then

                        RadComboBoxProdInvType.SelectedValue = "Custom"
                        RadComboBoxProdInvFormat.SelectedValue = ProductionInvoiceDefault.CustomFormatName

                    End If

                Else

                    If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext) IsNot Nothing Then

                        RadComboBoxProdInvType.SelectedValue = "Agency Default"

                    End If

                End If

                TextBoxProdAttentionLine.Text = Client.ProductionAttentionLine
                TextBoxProdInvoiceFooter.Text = Client.ProductionFooterComments
                TextBoxProdDaysToPay.Text = Client.ProductionDaysToPay.GetValueOrDefault(0)

            End Using

        End If

    End Sub
    Private Sub LoadMedia(ByVal Client As AdvantageFramework.Database.Entities.Client)

        If Client IsNot Nothing Then

            Select Case CShort(Client.AssignMediaInvoicesBy.GetValueOrDefault(1))

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.Campaign
                    RadioButtonMediaCampaign.Checked = True

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.ClientPurchaseOrder
                    RadioButtonMediaClientPO.Checked = True

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.Market
                    RadioButtonMediaMarket.Checked = True

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.SalesClass
                    RadioButtonSalesClass.Checked = True

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.OrderNumber
                    RadioButtonMediaOrderNumber.Checked = True

                Case AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.OrderType
                    RadioButtonOrderType.Checked = True

            End Select

            TextBoxMediaAttention.Text = Client.MediaAttentionLine
            TextBoxMediaInvoiceFooter.Text = Client.MediaFooterComments
            TextBoxMediaDaysToPay.Text = Client.MediaDaysToPay.GetValueOrDefault(0)

        End If

    End Sub
    Private Sub LoadMediaInvoiceFormats(ByVal Client As AdvantageFramework.Database.Entities.Client)

        Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing

        If Client IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                If MediaInvoiceDefault IsNot Nothing Then

                    If MediaInvoiceDefault.TVCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.TVCustomFormat <> "" Then
                        RadComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxTVInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.TVCustomFormat
                    End If

                    If MediaInvoiceDefault.NewspaperCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.NewspaperCustomFormat <> "" Then
                        RadComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxNewspaperInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.NewspaperCustomFormat
                    End If

                    If MediaInvoiceDefault.MagazineCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.MagazineCustomFormat <> "" Then
                        RadComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxMagazineInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.MagazineCustomFormat
                    End If

                    If MediaInvoiceDefault.RadioCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.RadioCustomFormat <> "" Then
                        RadComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxRadioInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.RadioCustomFormat
                    End If

                    If MediaInvoiceDefault.OutOfHomeCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.OutOfHomeCustomFormat <> "" Then
                        RadComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxOutOfHomeInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.OutOfHomeCustomFormat
                    End If

                    If MediaInvoiceDefault.InternetCustomFormat IsNot Nothing AndAlso MediaInvoiceDefault.InternetCustomFormat <> "" Then
                        RadComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                        RadComboBoxInternetInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.InternetCustomFormat
                    End If

                End If

            End Using

        End If

    End Sub
    Private Sub LoadRequiredFields(ByVal Client As AdvantageFramework.Database.Entities.Client)

        If Client IsNot Nothing Then

            CheckBoxOverrideAgencySettings.Checked = Client.OverrideAgencySettings.GetValueOrDefault(0)

            CheckBoxAccountNumber.Checked = Client.AccountNumberRequired.GetValueOrDefault(0)
            CheckBoxJobType.Checked = Client.JobTypeRequired.GetValueOrDefault(0)
            CheckBoxPromotion.Checked = Client.PromotionRequired.GetValueOrDefault(0)
            CheckBoxDueDate.Checked = Client.DueDateRequired.GetValueOrDefault(0)
            CheckBoxComplexityCode.Checked = Client.ComplexityCodeRequired.GetValueOrDefault(0)
            CheckBoxSCFormat.Checked = Client.SCFormatRequired.GetValueOrDefault(0)
            CheckBoxDeptTeam.Checked = Client.DepartmentCodeRequired.GetValueOrDefault(0)
            CheckBoxMarketCode.Checked = Client.MarketCodeRequired.GetValueOrDefault(0)
            CheckBoxAlertGroup.Checked = Client.AlertGroupRequired.GetValueOrDefault(0)
            CheckBoxServiceFeeType.Checked = Client.ServiceFeeTypeRequired.GetValueOrDefault(0)

            CheckBoxCoopBillingCode.Checked = Client.CoopBillingCodeRequired.GetValueOrDefault(0)
            CheckBoxAdNumber.Checked = Client.AdNumberRequired.GetValueOrDefault(0)
            CheckBoxClientReference.Checked = Client.ClientReferenceRequired.GetValueOrDefault(0)
            CheckBoxDateOpened.Checked = Client.DateOpenedRequired.GetValueOrDefault(0)
            CheckBoxFormatAdSize.Checked = Client.FormatRequired.GetValueOrDefault(0)
            CheckBoxProductContact.Checked = Client.ProductContactRequired.GetValueOrDefault(0)
            CheckBoxComponentBudget.Checked = Client.ComponentBudgetRequired.GetValueOrDefault(0)
            CheckBoxTaxFlag.Checked = Client.TaxFlagRequired.GetValueOrDefault(0)
            CheckBoxBlackplate1.Checked = Client.Blackplate1Required.GetValueOrDefault(0)
            CheckBoxBlackplate2.Checked = Client.Blackplate2Required.GetValueOrDefault(0)

            CheckBoxJobLogCustom1.Checked = Client.JobLogCustom1.GetValueOrDefault(0)
            CheckBoxJobLogCustom2.Checked = Client.JobLogCustom2.GetValueOrDefault(0)
            CheckBoxJobLogCustom3.Checked = Client.JobLogCustom3.GetValueOrDefault(0)
            CheckBoxJobLogCustom4.Checked = Client.JobLogCustom4.GetValueOrDefault(0)
            CheckBoxJobLogCustom5.Checked = Client.JobLogCustom5.GetValueOrDefault(0)
            CheckBoxJobComponentCustom1.Checked = Client.JobCustomComponent1Required.GetValueOrDefault(0)
            CheckBoxJobComponentCustom2.Checked = Client.JobCustomComponent2Required.GetValueOrDefault(0)
            CheckBoxJobComponentCustom3.Checked = Client.JobCustomComponent3Required.GetValueOrDefault(0)
            CheckBoxJobComponentCustom4.Checked = Client.JobCustomComponent4Required.GetValueOrDefault(0)
            CheckBoxJobComponentCustom5.Checked = Client.JobCustomComponent5Required.GetValueOrDefault(0)

            CheckBoxCampaignCode.Checked = Client.CampaignCodeRequired.GetValueOrDefault(0)
            CheckBoxFiscalPeriod.Checked = Client.FiscalPeriodRequired.GetValueOrDefault(0)

            CheckBoxRequireProductCategorySelectionInTimesheet.Checked = Client.ProductCategoryInTimesheetRequired.GetValueOrDefault(0)

            CheckBoxRequireTimeComments.Checked = Client.RequireTimeComment

        End If

    End Sub
    Private Sub LoadWebsites()

        Dim ClientWebsites As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ClientWebsites = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, _ClientCode).ToList

        End Using

        RadGridWebsites.DataSource = ClientWebsites
        RadGridWebsites.MasterTableView.IsItemInserted = True
        RadGridWebsites.DataBind()

    End Sub
    Private Sub LoadContacts()

        Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        Dim ClientContactDetailList As Integer() = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If String.IsNullOrEmpty(_ClientCode) = False Then

                ClientContacts = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).ToList

            End If

            If CheckBoxContactsShowInactive.Checked Then

                RadGridContacts.DataSource = (From Contact In ClientContacts
                                              Select New With {.ContactID = Contact.ContactID,
                                                               .Code = Contact.ContactCode,
                                                               .Name = Contact.ToString,
                                                               .IsInactive = CBool(Contact.IsInactive.GetValueOrDefault(0))}).ToList

            Else

                RadGridContacts.DataSource = (From Contact In ClientContacts
                                              Where Contact.IsInactive Is Nothing OrElse
                                                    Contact.IsInactive = 0
                                              Select New With {.ContactID = Contact.ContactID,
                                                               .Code = Contact.ContactCode,
                                                               .Name = Contact.ToString,
                                                               .IsInactive = CBool(Contact.IsInactive.GetValueOrDefault(0))}).ToList

            End If

            RadGridContacts.DataBind()

        End Using

    End Sub
    Private Sub LoadDivisions()

        If _ClientCode <> "" Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _FromMaintenance Then

                        If CheckBoxDivisionShowInactive.Checked Then

                            RadGridDivisions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadWithOfficeLimits(DbContext, _Session)
                                                           Where Entity.ClientCode = _ClientCode
                                                           Select Entity).ToList

                        Else

                            RadGridDivisions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                                           Where Entity.ClientCode = _ClientCode AndAlso
                                                                 Entity.IsActive = 1
                                                           Select Entity).ToList

                        End If

                    Else

                        If CheckBoxDivisionShowInactive.Checked Then

                            RadGridDivisions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                           Where Entity.ClientCode = _ClientCode
                                                           Select Entity).ToList

                        Else

                            RadGridDivisions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                           Where Entity.ClientCode = _ClientCode AndAlso
                                                                 Entity.IsActive = 1
                                                           Select Entity).ToList

                        End If

                    End If

                    RadGridDivisions.DataBind()

                End Using

            End Using

            If RadGridDivisions.Items.Count = 1 Then

                LoadProducts(Nothing)

            End If

        End If

    End Sub
    Private Sub LoadProducts(ByVal DivisionCode As String)

        Dim ProductCodes As String() = Nothing

        If _ClientCode <> "" Then

            If DivisionCode Is Nothing AndAlso Session("ClientEdit_SelectedDivisionCode") IsNot Nothing Then

                DivisionCode = Session("ClientEdit_SelectedDivisionCode")

            End If

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _FromMaintenance Then

                        If CheckBoxProductShowInactive.Checked Then

                            RadGridProducts.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, _Session).Include("Office").Include("Client").Include("Division")
                                                          Where Product.ClientCode = _ClientCode AndAlso
                                                                Product.DivisionCode = If(DivisionCode Is Nothing, Product.DivisionCode, DivisionCode)
                                                          Select Product).ToList

                        Else

                            RadGridProducts.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveWithOfficeLimits(_Session, DbContext).Include("Office").Include("Client").Include("Division")
                                                          Where Product.ClientCode = _ClientCode AndAlso
                                                                Product.DivisionCode = If(DivisionCode Is Nothing, Product.DivisionCode, DivisionCode) AndAlso
                                                                Product.IsActive = 1
                                                          Select Product).ToList

                        End If

                    Else

                        If CheckBoxProductShowInactive.Checked Then

                            RadGridProducts.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                                          Where Product.ClientCode = _ClientCode AndAlso
                                                                Product.DivisionCode = If(DivisionCode Is Nothing, Product.DivisionCode, DivisionCode)
                                                          Select Product).ToList

                        Else

                            RadGridProducts.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Office").Include("Client").Include("Division")
                                                          Where Product.ClientCode = _ClientCode AndAlso
                                                                Product.DivisionCode = If(DivisionCode Is Nothing, Product.DivisionCode, DivisionCode) AndAlso
                                                                Product.IsActive = 1
                                                          Select Product).ToList

                        End If

                    End If

                    RadGridProducts.DataBind()

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadSortKeys()

        If _IsCopy OrElse _ClientCode = "" Then

            _ClientSortKeyList = Session("ClientEdit_RadGridSortKeys")

        End If

        If _ClientSortKeyList Is Nothing Then

            _ClientSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel)

            If _ClientCode <> "" Then

                _ClientSortKeyList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ClientSortKeyEntityList = Nothing
                    _ClientSortKeyEntityList = AdvantageFramework.Database.Procedures.ClientSortKey.LoadByClientCode(DbContext, _ClientCode).ToList()

                    If _ClientSortKeyEntityList IsNot Nothing Then

                        _ClientSortKeyList = (From Entity In _ClientSortKeyEntityList
                                              Select New AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel With {.ClientCode = Entity.ClientCode,
                                                                                                                                     .SortKey = Entity.SortKey}).ToList()

                    End If

                End Using

            End If

        End If

        RadGridSortKeys.DataSource = _ClientSortKeyList
        RadGridSortKeys.MasterTableView.IsItemInserted = True
        RadGridSortKeys.DataBind()

        If _IsCopy OrElse _ClientCode = "" Then

            Session("ClientEdit_RadGridSortKeys") = _ClientSortKeyList

        End If

    End Sub
    Private Sub LoadLists(ByVal DbContext As AdvantageFramework.Database.DbContext)

        'Dim InvoiceFormatsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

        'If _IsCopy Then

        RadComboBoxOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session).ToList
        RadComboBoxOffice.DataValueField = "Code"
        RadComboBoxOffice.DataBind()
        RadComboBoxOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        CheckBoxDuplicateForProduct.Enabled = False
        RadComboBoxOffice.Enabled = False

        'End If

        RadComboBoxFiscalStartMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
        RadComboBoxFiscalStartMonth.DataTextField = "Value"
        RadComboBoxFiscalStartMonth.DataValueField = "Key"
        RadComboBoxFiscalStartMonth.DataBind()
        RadComboBoxFiscalStartMonth.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxAvalaraSalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList
        RadComboBoxAvalaraSalesClass.DataTextField = "Description"
        RadComboBoxAvalaraSalesClass.DataValueField = "Code"
        RadComboBoxAvalaraSalesClass.DataBind()
        RadComboBoxAvalaraSalesClass.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        'InvoiceFormatsList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.InvoiceFormats))

        'RadComboBoxProdInvType.DataSource = InvoiceFormatsList
        'RadComboBoxProdInvType.DataValueField = "Code"
        'RadComboBoxProdInvType.DataTextField = "Description"
        'RadComboBoxProdInvType.DataBind()

        'ComboBoxTVInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadTVReports(DbContext)
        'ComboBoxOutOfHomeInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadOutOfHomeReports(DbContext)
        'ComboBoxMagazineInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadMagazineReports(DbContext)
        'ComboBoxNewspaperInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadNewspaperReports(DbContext)
        'ComboBoxRadioInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadRadioReports(DbContext)
        'ComboBoxInternetInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadInternetReports(DbContext)

        'RadComboBoxProdInvFormat.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadProductionReports(DbContext)
        'RadComboBoxProdInvFormat.DataValueField = "ReportCode"
        'RadComboBoxProdInvType.DataTextField = "Name"
        'RadComboBoxProdInvFormat.DataBind()

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        TextBoxClientCode.CssClass = "RequiredInput"
        TextBoxClientName.CssClass = "RequiredInput"

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Code, TextBoxClientCode)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Name, TextBoxClientName)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Address, TextBoxAddress1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Address2, TextBoxAddress2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.County, TextBoxCounty)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.City, TextBoxCity)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.State, TextBoxState)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Zip, TextBoxZip)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Country, TextBoxCountry)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingAddress, TextBoxBillingAddress1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingAddress2, TextBoxBillingAddress2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingCounty, TextBoxBillingCounty)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingCity, TextBoxBillingCity)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingState, TextBoxBillingState)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingZip, TextBoxBillingZip)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.BillingCountry, TextBoxBillingCountry)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementAddress, TextBoxStatementAddress1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementAddress2, TextBoxStatementAddress2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementCounty, TextBoxStatementCounty)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementCity, TextBoxStatementCity)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementState, TextBoxStatementState)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementZip, TextBoxStatementZip)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.StatementCountry, TextBoxStatementCountry)

        RadNumericTextBoxCreditLimit.MaxValue = 9999999999999.99
        RadNumericTextBoxCreditLimit.MinValue = -9999999999999.99
        RadNumericTextBoxCreditLimit.NumberFormat.GroupSeparator = ","
        RadNumericTextBoxCreditLimit.NumberFormat.DecimalDigits = 2

        RadNumericTextBoxDoubleClickProfileID.MinValue = 0
        RadNumericTextBoxDoubleClickProfileID.MaxValue = 9223372036854775807
        RadNumericTextBoxDoubleClickProfileID.NumberFormat.GroupSeparator = ""
        RadNumericTextBoxDoubleClickProfileID.NumberFormat.DecimalDigits = 0

        RadNumericTextBoxDoubleClickReportID.MinValue = 0
        RadNumericTextBoxDoubleClickReportID.MaxValue = 9223372036854775807
        RadNumericTextBoxDoubleClickReportID.NumberFormat.GroupSeparator = ""
        RadNumericTextBoxDoubleClickReportID.NumberFormat.DecimalDigits = 0

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.ARComment, TextBoxARComment)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.MediaAttentionLine, TextBoxMediaAttention)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.MediaDaysToPay, TextBoxMediaDaysToPay)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.MediaFooterComments, TextBoxMediaInvoiceFooter)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.ProductionAttentionLine, TextBoxProdAttentionLine)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.ProductionDaysToPay, TextBoxProdDaysToPay)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Client.Properties.ProductionFooterComments, TextBoxProdInvoiceFooter)

    End Sub
    Private Sub LoadClientEntity(ByVal Client As AdvantageFramework.Database.Entities.Client, ByVal IsNew As Boolean)

        If Client IsNot Nothing Then

            Client.Code = TextBoxClientCode.Text
            Client.Name = TextBoxClientName.Text

            If Client.Name.Length > _SortNameMaxLength Then

                Client.SortName = Client.Name.Substring(0, _SortNameMaxLength)

            Else

                Client.SortName = Client.Name

            End If

            Client.Address = TextBoxAddress1.Text
            Client.Address2 = TextBoxAddress2.Text
            Client.City = TextBoxCity.Text
            Client.County = TextBoxCounty.Text
            Client.State = TextBoxState.Text
            Client.Zip = TextBoxZip.Text
            Client.Country = TextBoxCountry.Text

            Client.IsActive = If(CheckBoxIsInactive.Checked, 0, 1)
            Client.IsNewBusiness = If(CheckBoxIsNewBusiness.Checked, 1, 0)

            'billing
            Client.BillingAddress = TextBoxBillingAddress1.Text
            Client.BillingAddress2 = TextBoxBillingAddress2.Text
            Client.BillingCity = TextBoxBillingCity.Text
            Client.BillingCounty = TextBoxBillingCounty.Text
            Client.BillingState = TextBoxBillingState.Text
            Client.BillingZip = TextBoxBillingZip.Text
            Client.BillingCountry = TextBoxBillingCountry.Text

            Client.StatementAddress = TextBoxStatementAddress1.Text
            Client.StatementAddress2 = TextBoxStatementAddress2.Text
            Client.StatementCity = TextBoxStatementCity.Text
            Client.StatementCounty = TextBoxStatementCounty.Text
            Client.StatementState = TextBoxStatementState.Text
            Client.StatementZip = TextBoxStatementZip.Text
            Client.StatementCountry = TextBoxStatementCountry.Text

            Client.CreditLimit = If(IsNumeric(RadNumericTextBoxCreditLimit.Value), CDec(RadNumericTextBoxCreditLimit.Value), Nothing)

            If RadComboBoxFiscalStartMonth.SelectedValue <> "" Then

                Client.FiscalStart = CShort(RadComboBoxFiscalStartMonth.SelectedValue)

            Else

                Client.FiscalStart = Nothing

            End If

            Client.ARComment = TextBoxARComment.Text

            Client.AvalaraSalesClassCode = RadComboBoxAvalaraSalesClass.SelectedValue
            Client.AvalaraTaxExempt = CheckBoxAvalaraTaxExempt.Checked

            If IsNew Then

                Client.AssignProductionInvoicesBy = 1
                Client.AssignMediaInvoicesBy = 1

            End If

            If CollapsablePanelMediaIntegrationSettings.Visible Then

                Client.DoubleClickEnabled = CheckBoxDoubleClickEnabled.Checked
                Client.DoubleClickProfileID = If(IsNumeric(RadNumericTextBoxDoubleClickProfileID.Value), RadNumericTextBoxDoubleClickProfileID.Value, Nothing)
                Client.DoubleClickReportID = If(IsNumeric(RadNumericTextBoxDoubleClickReportID.Value), RadNumericTextBoxDoubleClickReportID.Value, Nothing)

            End If

            'If IsNew OrElse TabItemClientDetails_ProductionTab.Tag = True Then

            '    SaveProductionTab(Client)

            'End If

            'If IsNew OrElse TabItemClientDetails_MediaTab.Tag = True Then

            '    SaveMediaTab(Client)

            'End If

            'If IsNew OrElse TabItemClientDetails_RequiredFieldsTab.Tag = True Then

            '    SaveRequiredFieldsTab(Client)

            'End If

        End If

    End Sub
    Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Client

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

        Try

            If IsNew Then

                Client = New AdvantageFramework.Database.Entities.Client

                LoadClientEntity(Client, True)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    If Client IsNot Nothing Then

                        LoadClientEntity(Client, False)

                    End If

                End Using

            End If

        Catch ex As Exception
            Client = Nothing
        End Try

        FillObject = Client

    End Function
    Private Function Insert() As Boolean

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
        Dim ErrorMessage As String = Nothing
        Dim ClSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing
        Dim Inserted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Client = Me.FillObject(True)

                If Client IsNot Nothing Then

                    Client.DbContext = DbContext

                    Inserted = AdvantageFramework.Database.Procedures.Client.Insert(DbContext, Client)

                    If Inserted Then

                        SaveSortKeys(DbContext, Client)

                        _ClientCode = Client.Code

                        If CheckBoxDuplicateForDivision.Checked Then

                            SaveNewClientOptions(Client)

                        End If

                        '    MediaInvoiceDefault = FillMediaInvoiceFormatObject(DbContext, True)

                        '    If MediaInvoiceDefault IsNot Nothing Then

                        '        MediaInvoiceDefault.DbContext = DbContext
                        '        MediaInvoiceDefault.ClientCode = Client.Code
                        '        MediaInvoiceDefault.ClientOrDefault = 2
                        '        AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                        '    End If

                        '    ProductionInvoiceDefault = FillProductionInvoiceFormatObject(DbContext, True)

                        '    If ProductionInvoiceDefault IsNot Nothing Then

                        '        ProductionInvoiceDefault.DbContext = DbContext
                        '        ProductionInvoiceDefault.ClientCode = Client.Code
                        '        ProductionInvoiceDefault.ClientOrDefault = 2
                        '        AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault)

                        '    End If

                        '    If Me.ClientWebsiteList IsNot Nothing Then

                        '        For Each ClientWebsite In Me.ClientWebsiteList

                        '            ClientWebsite.DbContext = DbContext
                        '            ClientWebsite.ClientCode = Client.Code

                        '            AdvantageFramework.Database.Procedures.ClientWebsite.Insert(DbContext, ClientWebsite)

                        '        Next

                        '    End If

                        '    ClientCode = Client.Code

                    Else

                        ErrorMessage = "Error saving client to database."

                    End If

                End If

            End Using

        Catch ex As Exception
            ErrorMessage = "Failed trying to insert into the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Insert = Inserted

    End Function
    Private Function Save() As Boolean

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
        Dim ErrorMessage As String = ""
        Dim IsNewMediaInvoiceDefault As Boolean = False
        Dim IsNewProductionInvoiceDefault As Boolean = False
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Client = Me.FillObject(False)

                If Client IsNot Nothing Then

                    Saved = AdvantageFramework.Database.Procedures.Client.Update(DbContext, Client)

                    'If Saved Then

                    '    MediaInvoiceDefault = FillMediaInvoiceFormatObject(DbContext, IsNewMediaInvoiceDefault)

                    '    ProductionInvoiceDefault = FillProductionInvoiceFormatObject(DbContext, IsNewProductionInvoiceDefault)

                    '    If MediaInvoiceDefault IsNot Nothing Then

                    '        If IsNewMediaInvoiceDefault Then

                    '            MediaInvoiceDefault.DbContext = DbContext
                    '            MediaInvoiceDefault.ClientCode = Client.Code
                    '            MediaInvoiceDefault.ClientOrDefault = 2
                    '            AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault)

                    '        Else

                    '            AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Update(DbContext, MediaInvoiceDefault)

                    '        End If

                    '    End If

                    '    If ProductionInvoiceDefault IsNot Nothing Then

                    '        If IsNewProductionInvoiceDefault Then

                    '            ProductionInvoiceDefault.DbContext = DbContext
                    '            ProductionInvoiceDefault.ClientCode = Client.Code
                    '            ProductionInvoiceDefault.ClientOrDefault = 2
                    '            AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault)

                    '        Else

                    '            AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Update(DbContext, ProductionInvoiceDefault)

                    '        End If

                    '    End If

                    'End If

                End If

            End Using

            If Not Saved Then

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Save = Saved

    End Function
    Private Sub SaveNewClientOptions(ByVal Client As AdvantageFramework.Database.Entities.Client)

        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        If Client IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If CheckBoxDuplicateForDivision.Checked Then

                    Division = AdvantageFramework.Database.Procedures.Division.CreateFromClient(Client)

                    If Division IsNot Nothing Then

                        Division.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division) AndAlso CheckBoxDuplicateForProduct.Checked Then

                            Product = AdvantageFramework.Database.Procedures.Product.CreateFromClient(Client)

                            If Product IsNot Nothing Then

                                Product.DbContext = DbContext
                                Product.OfficeCode = RadComboBoxOffice.SelectedValue

                                AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                            End If

                        End If

                    End If

                End If

            End Using

        End If

    End Sub
    Private Sub SaveSortKeys(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Client As AdvantageFramework.Database.Entities.Client)

        _ClientSortKeyList = Session("ClientEdit_RadGridSortKeys")

        If _ClientSortKeyList IsNot Nothing Then

            Dim NewClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing

            For Each ClientSortKey In _ClientSortKeyList

                If _IsCopy Or _ClientCode = "" Then

                    NewClientSortKey = New AdvantageFramework.Database.Entities.ClientSortKey

                    NewClientSortKey.DbContext = DbContext
                    NewClientSortKey.ClientCode = Client.Code
                    NewClientSortKey.SortKey = ClientSortKey.SortKey

                    AdvantageFramework.Database.Procedures.ClientSortKey.Insert(DbContext, NewClientSortKey)

                    NewClientSortKey = Nothing

                End If

            Next

        End If

    End Sub
    Protected Sub RadButtonSelected_Click(sender As Object, e As EventArgs)

        'objects
        Dim DivisionCode As String = Nothing

        If DirectCast(sender, Telerik.Web.UI.RadButton).Checked Then

            DivisionCode = DirectCast(sender, Telerik.Web.UI.RadButton).CommandArgument

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDivisions.MasterTableView.Items

                If TryCast(dataItem.FindControl("RadButtonSelected"), Telerik.Web.UI.RadButton).CommandArgument <> DivisionCode Then

                    TryCast(dataItem.FindControl("RadButtonSelected"), Telerik.Web.UI.RadButton).Checked = False

                End If

            Next

            Session("ClientEdit_SelectedDivisionCode") = DivisionCode

        Else

            Session("ClientEdit_SelectedDivisionCode") = Nothing

        End If

        LoadProducts(Session("ClientEdit_SelectedDivisionCode"))

    End Sub

    Private Sub UpdateWebsite(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ClientWebsite = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

            If ClientWebsite IsNot Nothing Then

                ClientWebsite.WebsiteAddress = CType(GridDataItem.FindControl("TextBoxWebsiteAddress"), TextBox).Text.Trim

                If DirectCast(GridDataItem.FindControl("CheckBoxWebsiteIsInactive"), CheckBox).Checked Then

                    ClientWebsite.IsInactive = True

                Else

                    ClientWebsite.IsInactive = False

                End If

                AdvantageFramework.Database.Procedures.ClientWebsite.Update(DbContext, ClientWebsite)

            End If

        End Using

    End Sub
    Private Sub Upload()

        Session("DocCaption") = ""

        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=CL&FK=" & _ClientCode, 500, 550)

    End Sub
    Private Sub ViewDocs()

        'Dim URL As String

        'URL = "Documents_List2.aspx?doclvl=" & AdvantageFramework.Database.Entities.DocumentLevel.Client & "&cl_code=" & _ClientCode & "&client_desc=" & Me.TextBoxClientCode.Text & "-" & Me.TextBoxClientName.Text

        'Me.OpenWindow("View Documents", URL)

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "Documents_List2.aspx"
            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Client
            .ClientCode = Me._ClientCode
            .Add("client_desc", Me.TextBoxClientCode.Text & "-" & Me.TextBoxClientName.Text)

        End With

        Me.OpenWindow(qs, "Document List")

    End Sub
    Private Sub MediaInvoiceDefaultHandler(ByVal InvoiceTypeComboBox As Telerik.Web.UI.RadComboBox, ByVal InvoiceFormatComboBox As Telerik.Web.UI.RadComboBox)

        Dim AgencyMediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Dim AgencyProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing

        If InvoiceTypeComboBox.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

            If InvoiceTypeComboBox.ID = "RadComboBoxProdInvType" Then

                InvoiceFormatComboBox.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If InvoiceTypeComboBox.ID = "RadComboBoxProdInvType" Then

                        AgencyProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                        If AgencyProductionInvoiceDefault IsNot Nothing Then

                            If AgencyProductionInvoiceDefault.CustomFormatName IsNot Nothing Then

                                Try
                                    InvoiceFormatComboBox.SelectedValue = AgencyProductionInvoiceDefault.CustomFormatName
                                Catch ex As Exception
                                    InvoiceFormatComboBox.SelectedValue = ""
                                End Try

                            End If

                        End If

                    Else

                        AgencyMediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)

                        If AgencyMediaInvoiceDefault IsNot Nothing Then

                            Try

                                Select Case InvoiceTypeComboBox.ID

                                    Case "RadComboBoxMediaTVInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.TVCustomFormat

                                    Case "RadComboBoxMediaNewspaperInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.NewspaperCustomFormat

                                    Case "RadComboBoxMediaMagazineInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.MagazineCustomFormat

                                    Case "RadComboBoxMediaRadioInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.RadioCustomFormat

                                    Case "RadComboBoxMediaOutOfHomeInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.OutOfHomeCustomFormat

                                    Case "RadComboBoxMediaInternetInvType"
                                        InvoiceFormatComboBox.SelectedValue = AgencyMediaInvoiceDefault.InternetCustomFormat

                                End Select

                            Catch ex As Exception
                                InvoiceFormatComboBox.SelectedValue = ""
                            End Try

                        End If

                    End If

                End Using

            End If

            InvoiceFormatComboBox.Enabled = False

        ElseIf InvoiceTypeComboBox.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

            InvoiceFormatComboBox.Enabled = True

        End If

    End Sub
    Private Sub UpdatedDCEnabled()

        'objects
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Token As String = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            Token = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DC_OAUTH2_TOKEN FROM dbo.CLIENT WHERE CL_CODE = '{0}'", _ClientCode)).FirstOrDefault

            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

            If Client IsNot Nothing Then

                If String.IsNullOrWhiteSpace(Token) Then

                    Client.DoubleClickEnabled = False

                Else

                    Client.DoubleClickEnabled = True

                End If

                AdvantageFramework.Database.Procedures.Client.Update(DbContext, Client)

            End If

        End Using

    End Sub
    Private Sub DeauthorizeDoubleClick()

        'objects
        Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

        Try

            Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, True, _ClientCode)

            If Service IsNot Nothing Then

                Service.Deauthorize()

            End If

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ClientEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client, False))
        RadToolBarButtonUploadDocument.Enabled = HasAccessToDocuments
        RadToolBarButtonDocuments.Enabled = HasAccessToDocuments

        If HasAccessToDocuments Then

            RadToolBarButtonUploadDocument.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
            RadToolBarButtonDocuments.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        End If

        RadToolBarButtonNew.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        RadToolBarButtonSave.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelBilling.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            CollapsablePanelContacts.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode)

        End Using

        CollapsablePanelDivisionProduct.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelGeneral.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelHeader.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelMedia.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelMediaInvoiceFormat.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelProduction.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelRequiredFields.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelWebsites.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        If Request.QueryString("From") IsNot Nothing Then

            If Request.QueryString("From").ToString = "Maintenance" Then

                _FromMaintenance = True

            End If

        End If

        If Request.QueryString("ClientCode") IsNot Nothing Then

            _ClientCode = Request.QueryString("ClientCode").ToString

        End If

        If Request.QueryString("Mode") IsNot Nothing Then

            If Request.QueryString("Mode").ToString = "Add" Then

                _ClientCode = ""

            ElseIf Request.QueryString("Mode").ToString = "Copy" Then

                _IsCopy = True

            End If

        End If

    End Sub
    Private Sub Maintenance_ClientEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Request.QueryString("RefreshMediaIntegrationSettings") IsNot Nothing Then

                UpdatedDCEnabled()

            End If

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

                Try

                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Client.Properties.SortName))

                Catch ex As Exception
                    _SortNameMaxLength = Nothing
                End Try

                LoadLists(DbContext)

            End Using

            Try

                LoadClient()

            Catch ex As Exception
                _ClientCode = ""
            End Try

        Else

            If Me.EventArgument = "Refresh" Then
                LoadClient()
            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonAddContact_Click(sender As Object, e As EventArgs) Handles ButtonAddContact.Click

        Try

            Me.OpenWindow("Add Contact", "popContactsAdd.aspx?From=ClientEdit&client=" & _ClientCode, 750, 950, False, True, "RefreshPage")

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButtonAddDivision_Click(sender As Object, e As EventArgs) Handles ButtonAddDivision.Click

        Try

            If _FromMaintenance Then

                Me.OpenWindow("Add Division", "Maintenance_DivisionEdit.aspx?From=Maintenance&Mode=Add&ClientCode=" & _ClientCode, 750, 950, False, True)

            Else

                Me.OpenWindow("Add Division", "Maintenance_DivisionEdit.aspx?Mode=Add&ClientCode=" & _ClientCode, 750, 950, False, True)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButtonAddProduct_Click(sender As Object, e As EventArgs) Handles ButtonAddProduct.Click

        Try

            If _FromMaintenance Then

                Me.OpenWindow("Add Product", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Add&ClientCode=" & _ClientCode, 750, 950, False, True)

            Else

                Me.OpenWindow("Add Product", "Maintenance_ProductEdit.aspx?Mode=Add&ClientCode=" & _ClientCode, 750, 950, False, True)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridSortKeys_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSortKeys.ItemCommand

        'objects
        Dim ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing
        Dim MyClientSortKey As AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel = Nothing

        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridSortKeys.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                ClientSortKey = New AdvantageFramework.Database.Entities.ClientSortKey

                ClientSortKey.ClientCode = _ClientCode
                ClientSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                MyClientSortKey = New AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel

                MyClientSortKey.ClientCode = _ClientCode
                MyClientSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy OrElse _ClientCode = "" Then

                        _ClientSortKeyList = Session("ClientEdit_RadGridSortKeys")

                        If _ClientSortKeyList Is Nothing Then

                            _ClientSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ClientSortViewModel)

                        End If

                        If _ClientSortKeyList.Where(Function(Entity) Entity.SortKey = ClientSortKey.SortKey).Any = True Then

                            Me.ShowMessage("Sort option has already been added.  Please choose another.")

                        Else

                            ErrorMessage = ClientSortKey.ValidateEntity(IsValid)

                            If IsValid Then

                                _ClientSortKeyList.Add(MyClientSortKey)

                                Session("ClientEdit_RadGridSortKeys") = _ClientSortKeyList

                            Else

                                Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                    Else

                        ClientSortKey.DbContext = DbContext
                        ClientSortKey.ClientCode = _ClientCode

                        Reload = AdvantageFramework.Database.Procedures.ClientSortKey.Insert(DbContext, ClientSortKey)

                    End If

                End Using

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _ClientCode = "" Then

                        _ClientSortKeyList = Session("ClientEdit_RadGridSortKeys")

                        TextBox = CType(e.Item.FindControl("TextBoxSortKey"), TextBox)

                        If _ClientSortKeyList IsNot Nothing Then

                            MyClientSortKey = Nothing

                            Try

                                MyClientSortKey = (From Entity In _ClientSortKeyList
                                                   Where Entity.SortKey = TextBox.Text
                                                   Select Entity).Single

                            Catch ex As Exception
                                MyClientSortKey = Nothing
                            End Try

                            If MyClientSortKey IsNot Nothing Then

                                _ClientSortKeyList.Remove(MyClientSortKey)

                            End If

                        End If

                        Session("ClientEdit_RadGridSortKeys") = _ClientSortKeyList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ClientSortKey = AdvantageFramework.Database.Procedures.ClientSortKey.LoadByClientCodeAndSortKey(DbContext, _ClientCode, CurrentGridDataItem.GetDataKeyValue("SortKey"))

                            If ClientSortKey IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ClientSortKey.Delete(DbContext, ClientSortKey)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

            _ClientSortKeyList = Nothing
            LoadSortKeys()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridSortKeys_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSortKeys.ItemDataBound

        Dim TextBoxSortKeyEditTextBox As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            TextBoxSortKeyEditTextBox = DirectCast(e.Item.FindControl("TextBoxSortKey"), System.Web.UI.WebControls.TextBox)

            If TextBoxSortKeyEditTextBox IsNot Nothing AndAlso CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                TextBoxSortKeyEditTextBox.Enabled = False

            End If

        Catch ex As Exception

        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadToolbarClient_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarClient.ButtonClick

        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
        Dim WebQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ErrorMessage As String = ""

        Select Case e.Item.Value

            Case "Save"

                If _IsCopy OrElse _ClientCode = "" Then

                    If Insert() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Client Detail", "Maintenance_ClientEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode, , , True)

                        Else

                            Me.OpenWindow("Client Detail", "Maintenance_ClientEdit.aspx?ClientCode=" & _ClientCode, , , True)

                        End If

                    End If

                Else

                    If Save() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Client Detail", "Maintenance_ClientEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode, , , True)

                        Else

                            Me.OpenWindow("Client Detail", "Maintenance_ClientEdit.aspx?ClientCode=" & _ClientCode, , , True)

                        End If

                    End If

                End If

            Case "Refresh"

                LoadClient()

            Case "New"

                If _FromMaintenance Then

                    Me.OpenWindow("New Client", "Maintenance_ClientEdit.aspx?From=Maintenance&Mode=Add&ClientCode=", , , False)

                Else

                    Me.OpenWindow("New Client", "Maintenance_ClientEdit.aspx?&Mode=AddClientCode=", , , False)

                End If

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

            Case "Bookmark"

                Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                WebQueryString = New AdvantageFramework.Web.QueryString()

                WebQueryString = WebQueryString.FromCurrent()

                With Bookmark

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Maintenance_ClientEdit
                    .UserCode = Session("UserCode")
                    .Name = "Client: " & _ClientCode
                    .PageURL = "Maintenance_ClientEdit.aspx" & WebQueryString.ToString()

                End With

                If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub
    Private Sub RadComboBoxProdInvType_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxProdInvType.SelectedIndexChanged

        MediaInvoiceDefaultHandler(RadComboBoxProdInvType, RadComboBoxProdInvFormat)

    End Sub
    Private Sub CheckBoxNewClientOptions_Duplicate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDuplicateForDivision.CheckedChanged, CheckBoxDuplicateForProduct.CheckedChanged

        If sender Is CheckBoxDuplicateForProduct Then

            RadComboBoxOffice.Enabled = CheckBoxDuplicateForProduct.Checked
            RFVOffice.Enabled = CheckBoxDuplicateForProduct.Checked

        ElseIf sender Is CheckBoxDuplicateForDivision Then

            If CheckBoxDuplicateForDivision.Checked Then

                CheckBoxDuplicateForProduct.Enabled = True

            Else

                CheckBoxDuplicateForProduct.Enabled = False
                CheckBoxDuplicateForProduct.Checked = False
                RadComboBoxOffice.Enabled = False
                RFVOffice.EnableClientScript = False

            End If

        End If

    End Sub
    Private Sub RadGridWebsites_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridWebsites.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridWebsites.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridWebsites.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateWebsite(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientWebsite = New AdvantageFramework.Database.Entities.ClientWebsite

                    ClientWebsite.DbContext = DbContext
                    ClientWebsite.ClientCode = _ClientCode

                    ClientWebsite.WebsiteTypeCode = CType(e.Item.FindControl("RadComboBoxWebsiteTypeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue
                    ClientWebsite.WebsiteAddress = CType(e.Item.FindControl("TextBoxWebsiteAddressEditTextBox"), TextBox).Text.Trim

                    If DirectCast(e.Item.FindControl("CheckBoxWebsiteIsInactiveEditCheckBox"), CheckBox).Checked Then

                        ClientWebsite.IsInactive = True

                    Else

                        ClientWebsite.IsInactive = False

                    End If

                    Reload = AdvantageFramework.Database.Procedures.ClientWebsite.Insert(DbContext, ClientWebsite)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateWebsite(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxWebsiteAddressEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("RadComboBoxWebsiteTypeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("CheckBoxWebsiteIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientWebsite = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If ClientWebsite IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.ClientWebsite.Delete(DbContext, ClientWebsite)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadWebsites()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxWebsiteAddressEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridWebsites_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridWebsites.ItemDataBound

        'objects
        Dim RadComboBoxWebsiteTypes As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveWebsiteType As AdvantageFramework.Database.Entities.WebsiteType = Nothing

        If _WebsiteTypesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _WebsiteTypesList = AdvantageFramework.Database.Procedures.WebsiteType.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxWebsiteTypes = DirectCast(e.Item.FindControl("RadComboBoxWebsiteType"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxWebsiteTypes Is Nothing Then

                RadComboBoxWebsiteTypes = DirectCast(e.Item.FindControl("RadComboBoxWebsiteTypeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxWebsiteTypes IsNot Nothing Then

                RadComboBoxWebsiteTypes.DataSource = (From WebsiteType In _WebsiteTypesList
                                                      Where WebsiteType.IsInactive = False
                                                      Select WebsiteType.Code,
                                                             [Description] = If(WebsiteType.IsInactive = False, CStr(WebsiteType.Description & " ").Trim, WebsiteType.Description & "*")).ToList

                RadComboBoxWebsiteTypes.DataBind()

                RadComboBoxWebsiteTypes.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From WebsiteTypes In _WebsiteTypesList
                        Where WebsiteTypes.Code = e.Item.DataItem.WebsiteTypeCode
                        Select WebsiteTypes).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveWebsiteType = AdvantageFramework.Database.Procedures.WebsiteType.LoadByCode(DbContext, e.Item.DataItem.WebsiteTypeCode)

                            If InactiveWebsiteType IsNot Nothing Then

                                RadComboBoxWebsiteTypes.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveWebsiteType.Description & "*", InactiveWebsiteType.Code))

                                RadComboBoxWebsiteTypes.SelectedValue = InactiveWebsiteType.Code

                            End If

                        End Using

                    Else

                        RadComboBoxWebsiteTypes.SelectedValue = e.Item.DataItem.WebsiteTypeCode

                    End If

                    RadComboBoxWebsiteTypes.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxWebsiteTypes = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridContacts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContacts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
        Dim DetailQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContacts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                Me.OpenWindow("Edit Contact", "popContactsAdd.aspx?From=ClientEdit&ccid=" & CurrentGridDataItem.GetDataKeyValue("ContactID") & "&client=" & _ClientCode & "&code=" & CurrentGridDataItem.GetDataKeyValue("Code"), 750, 950, , True)

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, CurrentGridDataItem.GetDataKeyValue("ContactID"))

                        If ClientContact IsNot Nothing Then

                            Reload = AdvantageFramework.Database.Procedures.ClientContact.Delete(DbContext, ClientContact)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContacts()

        End If

    End Sub
    Private Sub RadGridDivisions_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDivisions.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridDivisions.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Copy"

                If _FromMaintenance Then

                    Me.OpenWindow("Copy Division", "Maintenance_DivisionEdit.aspx?From=Maintenance&Mode=Copy&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                Else

                    Me.OpenWindow("Copy Division", "Maintenance_DivisionEdit.aspx?Mode=Copy&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                End If

                Reload = False

            Case "Detail"

                If _FromMaintenance Then

                    Me.OpenWindow("Detail", "Maintenance_DivisionEdit.aspx?From=Maintenance&Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                Else

                    Me.OpenWindow("Detail", "Maintenance_DivisionEdit.aspx?Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                End If

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, CurrentGridDataItem.GetDataKeyValue("ClientCode"), CurrentGridDataItem.GetDataKeyValue("Code"))

                        If Division IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Division.Delete(DbContext, Division) = False Then

                                Me.ShowMessage("Division is in use and cannot be deleted.")
                                Reload = False

                            End If

                        End If

                    End Using

                End If

            Case "SelectDivision"

                Reload = False

        End Select

        If Reload Then

            LoadDivisions()

        End If

    End Sub
    Private Sub RadGridProducts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProducts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim DetailQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridProducts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Copy"

                If _FromMaintenance Then

                    Me.OpenWindow("Copy Product", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Copy&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                Else

                    Me.OpenWindow("Copy Product", "Maintenance_ProductEdit.aspx?Mode=Copy&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                End If

                Reload = False

            Case "Detail"

                If _FromMaintenance Then

                    Me.OpenWindow("Product Detail", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                Else

                    Me.OpenWindow("Product Detail", "Maintenance_ProductEdit.aspx?Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                End If

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, CurrentGridDataItem.GetDataKeyValue("ClientCode"), CurrentGridDataItem.GetDataKeyValue("DivisionCode"), CurrentGridDataItem.GetDataKeyValue("Code"))

                        If AdvantageFramework.Database.Procedures.Product.Delete(DbContext, Product) = False Then

                            Me.ShowMessage("The product is in use and cannot be deleted.")

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadProducts(Nothing)

        End If

    End Sub
    Protected Sub LinkButtonBilling_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonBilling_Client.Click

        TextBoxBillingAddress1.Text = TextBoxAddress1.Text
        TextBoxBillingAddress2.Text = TextBoxAddress2.Text
        TextBoxBillingCity.Text = TextBoxCity.Text
        TextBoxBillingCounty.Text = TextBoxCounty.Text
        TextBoxBillingState.Text = TextBoxState.Text
        TextBoxBillingZip.Text = TextBoxZip.Text
        TextBoxBillingCountry.Text = TextBoxCountry.Text

    End Sub
    Private Sub LinkButtonStatement_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Client.Click

        TextBoxStatementAddress1.Text = TextBoxAddress1.Text
        TextBoxStatementAddress2.Text = TextBoxAddress2.Text
        TextBoxStatementCity.Text = TextBoxCity.Text
        TextBoxStatementCounty.Text = TextBoxCounty.Text
        TextBoxStatementState.Text = TextBoxState.Text
        TextBoxStatementZip.Text = TextBoxZip.Text
        TextBoxStatementCountry.Text = TextBoxCountry.Text

    End Sub
    Private Sub LinkButtonStatement_Billing_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Billing.Click

        TextBoxStatementAddress1.Text = TextBoxBillingAddress1.Text
        TextBoxStatementAddress2.Text = TextBoxBillingAddress2.Text
        TextBoxStatementCity.Text = TextBoxBillingCity.Text
        TextBoxStatementCounty.Text = TextBoxBillingCounty.Text
        TextBoxStatementState.Text = TextBoxBillingState.Text
        TextBoxStatementZip.Text = TextBoxBillingZip.Text
        TextBoxStatementCountry.Text = TextBoxBillingCountry.Text

    End Sub
    Private Sub RadGridDivisions_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDivisions.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridProducts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProducts.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridContacts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContacts.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub CheckBoxDivisionShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDivisionShowInactive.CheckedChanged

        LoadDivisions()

    End Sub
    Private Sub CheckBoxProductShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProductShowInactive.CheckedChanged

        LoadProducts(Nothing)

    End Sub
    Private Sub CheckBoxContactsShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxContactsShowInactive.CheckedChanged

        LoadContacts()

    End Sub
    Private Sub CheckBoxDoubleClickEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDoubleClickEnabled.CheckedChanged

        Save()

        If CheckBoxDoubleClickEnabled.Checked Then

            Me.OpenWindow("", "Google_Authentication.aspx?ServiceType=DoubleClick&ServiceLevel=Client&ClientCode=" & _ClientCode, 300, 500, False, True)

        Else

            DeauthorizeDoubleClick()

        End If

    End Sub

#End Region

#End Region
    <Serializable()> Private Class ClientSortKey
        Public Property ClientCode As String = String.Empty
        Public Property SortKey As String = String.Empty
        Sub New()

        End Sub
    End Class

End Class
