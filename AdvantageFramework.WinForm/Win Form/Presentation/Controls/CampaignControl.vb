Namespace WinForm.Presentation.Controls

    Public Class CampaignControl

        Public Event SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event SelectedDocumentChanged()
        Public Event CampaignDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CampaignDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _CampaignID As Integer = 0
        Private _CampaignCode As String = ""
        Private _HasAccessToDocuments As Boolean = False
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property CanUserUpdate As Boolean
            Set(ByVal value As Boolean)

                TabControlPanelGeneralTab_General.Enabled = value
                TabControlPanelCampaignDetailsTab_CampaignDetails.Enabled = value
                TabControlPanelJobsAndMediaOrdersTab_JobsAndMediaOrders.Enabled = value
                TabControlPanelDocumentsTab_Documents.Enabled = value

                CheckBoxGeneral_Closed.SecurityEnabled = value

            End Set
        End Property
        Public Property CampaignClosedEnabled As Boolean
            Get
                CampaignClosedEnabled = CheckBoxGeneral_Closed.Enabled
            End Get
            Set(ByVal value As Boolean)
                CheckBoxGeneral_Closed.Enabled = value
            End Set
        End Property
        Public ReadOnly Property HasASelectedDocument As Boolean
            Get
                HasASelectedDocument = DocumentManagerControlDocuments_CampaignDocuments.HasASelectedDocument
            End Get
        End Property
        Public ReadOnly Property CampaignDetailsIsNewItemRow As Boolean
            Get
                CampaignDetailsIsNewItemRow = DataGridViewCampaignDetails_CampaignDetails.IsNewItemRow
            End Get
        End Property
        Public ReadOnly Property CampaignDetailsHasASelectedRow As Boolean
            Get
                CampaignDetailsHasASelectedRow = DataGridViewCampaignDetails_CampaignDetails.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property SelectedTab As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property DocumentManager As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_CampaignDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Campaign)

                        TabItemCampaignDetails_DocumentsTab.Visible = _HasAccessToDocuments

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            '
                            ' PROPERTY SETTINGS
                            '

                            TextBoxGeneral_Code.ByPassUserEntryChanged = True

                            ' Information tab
                            TextBoxGeneral_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.Name)
                            TextBoxMediaTypes_Other.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.OtherDescription)

                            ' Campaign Details tab
                            NumericInputCampaignDetails_TotalBilling.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.BillingBudgetAmount)
                            NumericInputCampaignDetails_TotalIncome.SetPropertySettings(AdvantageFramework.Database.Entities.Campaign.Properties.IncomeBudgetAmount)


                            '
                            ' DATA SOURCES
                            '

                            ' Information Tab

                            DbContext.Database.Connection.Open()

                            ComboBoxGeneral_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me._Session)

                            ComboBoxGeneral_AlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext)

                            ComboBoxGeneral_Market.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)

                            ComboBoxGeneral_JobComponent.DataSource = AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Where(Function(Entity) Entity.JobNumber = 0)

                            ComboBoxGeneral_AdNumber.DataSource = AdvantageFramework.Database.Procedures.Ad.LoadAllActive(DbContext).Where(Function(Entity) Entity.Number Is Nothing)

                            DbContext.Database.Connection.Close()

                        End Using

                        SearchableComboBoxGeneral_LandingPage.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.PleaseSelect

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject() As AdvantageFramework.Database.Entities.Campaign

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Try

                Campaign = LoadEntity()

                If Campaign IsNot Nothing Then

                    LoadCampaignEntity(Campaign)

                End If

            Catch ex As Exception
                Campaign = Nothing
            End Try

            FillObject = Campaign

        End Function
        Private Sub LoadCampaignEntity(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            If Campaign IsNot Nothing Then

                If TabItemCampaignDetails_GeneralTab.Tag = True Then

                    SaveGeneralTab(Campaign)

                End If

                If TabItemCampaignDetails_CampaignDetailsTab.Tag = True Then

                    SaveCampaignDetailsTab(Campaign)

                End If

                If TabItemCampaignDetails_JobsAndMediaOrdersTab.Tag = True Then

                    SaveJobsAndMediaOrdersTab(Campaign)

                End If

                If TabItemCampaignDetails_DocumentsTab.Tag = True Then

                    SaveDocumentsTab(Campaign)

                End If

            End If

        End Sub
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem, ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            If Campaign IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If TabItem Is Nothing Then

                        For Each TabItem In TabControlControl_CampaignDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            TabItem.Tag = False

                        Next

                        TabItem = TabControlControl_CampaignDetails.SelectedTab

                    End If

                    If TabItem.Tag = False Then

                        If TabItem Is TabItemCampaignDetails_GeneralTab Then

                            LoadGeneralTab(Campaign)

                        End If

                        If TabItem Is TabItemCampaignDetails_CampaignDetailsTab Then

                            LoadCampaignDetailsTab(Campaign)

                        End If

                        If TabItem Is TabItemCampaignDetails_JobsAndMediaOrdersTab Then

                            LoadJobsAndMediaOrdersTab(Campaign)

                        End If

                        If TabItem Is TabItemCampaignDetails_DocumentsTab Then

                            LoadDocumentsTab(Campaign)

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Campaign = LoadEntity()

            LoadEntityDetails(TabItem, Campaign)

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Sub LoadGeneralTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            If Campaign IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CheckBoxGeneral_Closed.CheckValue = Campaign.IsClosed.GetValueOrDefault(0)

                    ComboBoxGeneral_Office.SelectedValue = Campaign.OfficeCode
                    TextBoxGeneral_Client.Text = Campaign.Client.ToString
                    TextBoxGeneral_Division.Text = If(Campaign.Division Is Nothing, "", Campaign.Division.ToString)
                    TextBoxGeneral_Product.Text = If(Campaign.Product Is Nothing, "", Campaign.Product.ToString)

                    LabelGeneral_ID.Text = Campaign.ID
                    TextBoxGeneral_Code.Text = Campaign.Code
                    TextBoxGeneral_Name.Text = Campaign.Name

                    ComboBoxGeneral_AdNumber.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Ad.LoadAllActive(DbContext)
                                                           Where (Entity.ClientCode = Campaign.ClientCode OrElse
                                                                  Entity.ClientCode Is Nothing OrElse
                                                                  Entity.ClientCode = "") AndAlso
                                                                  (Entity.ExpirationDate.HasValue = False OrElse
                                                                  Entity.ExpirationDate.Value >= System.DateTime.Today)
                                                           Select Entity)

                    ComboBoxGeneral_AlertGroup.SelectedValue = Campaign.AlertGroupCode
                    ComboBoxGeneral_AdNumber.SelectedValue = Campaign.AdNumber
                    ComboBoxGeneral_Market.SelectedValue = Campaign.MarketCode

                    JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, Campaign.ClientCode, Nothing, Nothing, 0, True, Nothing).ToList

                    If Campaign.JobNumber.HasValue AndAlso Campaign.JobComponentNumber.HasValue Then

                        If Not JobComponents.Any(Function(jc) jc.JobNumber = Campaign.JobNumber AndAlso jc.JobComponentNumber = Campaign.JobComponentNumber) Then

                            JobComponents.AddRange((From Item In AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)
                                                    Where Item.JobNumber = Campaign.JobNumber AndAlso
                                                          Item.JobComponentNumber = Campaign.JobComponentNumber
                                                    Select Item).ToList)

                        End If

                    End If

                    ComboBoxGeneral_JobComponent.DataSource = JobComponents.OrderByDescending(Function(Entity) Entity.JobNumber).ThenByDescending(Function(Entity) Entity.JobComponentNumber)

                    ComboBoxGeneral_JobComponent.SelectedValue = AdvantageFramework.StringUtilities.PadWithCharacter(Campaign.JobNumber.GetValueOrDefault(0), 6, "0", True, True).Trim & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Campaign.JobComponentNumber.GetValueOrDefault(0), 2, "0", True, True).Trim

                    If Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.Overall Then

                        RadioButtonGeneral_AssignedToJobsAndOrders.Checked = False
                        RadioButtonGeneral_Overall.Checked = True

                    ElseIf Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders Then

                        RadioButtonGeneral_AssignedToJobsAndOrders.Checked = True
                        RadioButtonGeneral_Overall.Checked = False

                    End If

                    DateTimePickerGeneral_BeginningDate.Value = Campaign.StartDate.GetValueOrDefault(Nothing)
                    DateTimePickerGeneral_EndingDate.Value = Campaign.EndDate.GetValueOrDefault(Nothing)

                    CheckBoxMediaTypes_DirectResponse.CheckValue = Campaign.IsDirectResponse.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Internet.CheckValue = Campaign.IsInternetAds.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Magazine.CheckValue = Campaign.IsMagazine.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Newspaper.CheckValue = Campaign.IsNewspaper.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Other.CheckValue = Campaign.IsOther.GetValueOrDefault(0)
                    CheckBoxMediaTypes_OutOfHome.CheckValue = Campaign.IsOutOfHome.GetValueOrDefault(0)
                    CheckBoxMediaTypes_PrintCollateral.CheckValue = Campaign.IsPrint.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Radio.CheckValue = Campaign.IsRadio.GetValueOrDefault(0)
                    CheckBoxMediaTypes_Television.CheckValue = Campaign.IsTelevision.GetValueOrDefault(0)

                    TextBoxMediaTypes_Other.Text = Campaign.OtherDescription

                    SearchableComboBoxGeneral_LandingPage.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, Campaign.ClientCode)
                                                                        Where Entity.IsInactive = False
                                                                        Select Entity).ToList

                    SearchableComboBoxGeneral_LandingPage.SelectedValue = Campaign.ClientWebsiteID

                    If Campaign.ClientWebsiteID.HasValue Then

                        TextBoxGeneral_WebsiteName.Text = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientWebsite)
                                                           Where Entity.ID = Campaign.ClientWebsiteID.Value
                                                           Select Entity).FirstOrDefault.WebsiteName

                    Else

                        TextBoxGeneral_WebsiteName.Text = Nothing

                    End If

                    TextBoxComments_Comments.Text = Campaign.Comment

                End Using

                TabItemCampaignDetails_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadCampaignDetailsTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim CampaignDetails As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail) = Nothing

            If Campaign IsNot Nothing Then

                CampaignDetails = Campaign.CampaignDetails.OrderBy(Function(CampaignDetail) CampaignDetail.ID).ToList

                DataGridViewCampaignDetails_CampaignDetails.DataSource = CampaignDetails

                If DataGridViewCampaignDetails_CampaignDetails.Columns("UserCode") IsNot Nothing Then

                    If DataGridViewCampaignDetails_CampaignDetails.Columns("UserCode").Visible Then

                        DataGridViewCampaignDetails_CampaignDetails.Columns("UserCode").Visible = False

                    End If

                End If

                DataGridViewCampaignDetails_CampaignDetails.CurrentView.BestFitColumns()

                NumericInputCampaignDetails_TotalBilling.EditValue = Campaign.BillingBudgetAmount
                NumericInputCampaignDetails_TotalIncome.EditValue = Campaign.IncomeBudgetAmount

                LabelCampaignDetails_BillingMediaBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_BillingProductionBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_BillingCombinedBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_BillingTotalAllocatedAmount.Text = FormatCurrency(CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))

                LabelCampaignDetails_IncomeMediaBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_IncomeProductionBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_IncomeCombinedBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                LabelCampaignDetails_IncomeTotalAllocatedAmount.Text = FormatCurrency(CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))

                TabItemCampaignDetails_CampaignDetailsTab.Tag = True

            End If

        End Sub
        Private Sub LoadJobsAndMediaOrdersTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim CampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing
            Dim SelectedCampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing

            If Campaign IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)
                    SelectedCampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)

                    If Campaign.Product IsNot Nothing Then

                        CampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where Job.CampaignID Is Nothing AndAlso
                                                               Job.IsOpen = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        CampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where InternetOrder.CampaignID Is Nothing AndAlso
                                                               InternetOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        CampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where MagazineOrder.CampaignID Is Nothing AndAlso
                                                               MagazineOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        CampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where NewspaperOrder.CampaignID Is Nothing AndAlso
                                                               NewspaperOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        CampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where OutOfHomeOrder.CampaignID Is Nothing AndAlso
                                                               OutOfHomeOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        CampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where RadioOrder.CampaignID Is Nothing AndAlso
                                                               RadioOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        CampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                         Where TVOrder.CampaignID Is Nothing AndAlso
                                                               TVOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))


                        SelectedCampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where Job.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        SelectedCampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where InternetOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        SelectedCampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where MagazineOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        SelectedCampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where NewspaperOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        SelectedCampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where OutOfHomeOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        SelectedCampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where RadioOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        SelectedCampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientAndDivisionAndProductCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode, Campaign.ProductCode).ToList
                                                                 Where TVOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))

                    ElseIf Campaign.Division IsNot Nothing Then

                        CampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where Job.CampaignID Is Nothing AndAlso
                                                               Job.IsOpen = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        CampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where InternetOrder.CampaignID Is Nothing AndAlso
                                                               InternetOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        CampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where MagazineOrder.CampaignID Is Nothing AndAlso
                                                               MagazineOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        CampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where NewspaperOrder.CampaignID Is Nothing AndAlso
                                                               NewspaperOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        CampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where OutOfHomeOrder.CampaignID Is Nothing AndAlso
                                                               OutOfHomeOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        CampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where RadioOrder.CampaignID Is Nothing AndAlso
                                                               RadioOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        CampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                         Where TVOrder.CampaignID Is Nothing AndAlso
                                                               TVOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))


                        SelectedCampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where Job.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        SelectedCampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where InternetOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        SelectedCampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where MagazineOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        SelectedCampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where NewspaperOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        SelectedCampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where OutOfHomeOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        SelectedCampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where RadioOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        SelectedCampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientCodeAndDivisionCode(DbContext, Campaign.ClientCode, Campaign.DivisionCode).ToList
                                                                 Where TVOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))

                    Else

                        CampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where Job.CampaignID Is Nothing AndAlso
                                                               Job.IsOpen = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        CampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where InternetOrder.CampaignID Is Nothing AndAlso
                                                               InternetOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        CampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where MagazineOrder.CampaignID Is Nothing AndAlso
                                                               MagazineOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        CampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where NewspaperOrder.CampaignID Is Nothing AndAlso
                                                               NewspaperOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        CampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where OutOfHomeOrder.CampaignID Is Nothing AndAlso
                                                               OutOfHomeOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        CampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where RadioOrder.CampaignID Is Nothing AndAlso
                                                               RadioOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        CampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                         Where TVOrder.CampaignID Is Nothing AndAlso
                                                               TVOrder.OrderProcessControl = 1
                                                         Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))


                        SelectedCampaignDetailItemsList.AddRange(From Job In AdvantageFramework.Database.Procedures.Job.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where Job.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(Job))

                        SelectedCampaignDetailItemsList.AddRange(From InternetOrder In AdvantageFramework.Database.Procedures.InternetOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where InternetOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(InternetOrder))

                        SelectedCampaignDetailItemsList.AddRange(From MagazineOrder In AdvantageFramework.Database.Procedures.MagazineOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where MagazineOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(MagazineOrder))

                        SelectedCampaignDetailItemsList.AddRange(From NewspaperOrder In AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where NewspaperOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(NewspaperOrder))

                        SelectedCampaignDetailItemsList.AddRange(From OutOfHomeOrder In AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where OutOfHomeOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(OutOfHomeOrder))

                        SelectedCampaignDetailItemsList.AddRange(From RadioOrder In AdvantageFramework.Database.Procedures.RadioOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where RadioOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(RadioOrder))

                        SelectedCampaignDetailItemsList.AddRange(From TVOrder In AdvantageFramework.Database.Procedures.TVOrder.LoadByClientCode(DbContext, Campaign.ClientCode).ToList
                                                                 Where TVOrder.CampaignID = Campaign.ID
                                                                 Select New AdvantageFramework.Database.Classes.CampaignDetailItem(TVOrder))

                    End If

                End Using

                DataGridViewRightSection_JobsAndMediaOrders.DataSource = SelectedCampaignDetailItemsList
                DataGridViewLeftSection_AvailableJobsAndMediaOrders.DataSource = CampaignDetailItemsList

                If DataGridViewRightSection_JobsAndMediaOrders.Columns("DetailItem") IsNot Nothing Then

                    If DataGridViewRightSection_JobsAndMediaOrders.Columns("DetailItem").Visible Then

                        DataGridViewRightSection_JobsAndMediaOrders.Columns("DetailItem").Visible = False

                    End If

                End If

                If DataGridViewLeftSection_AvailableJobsAndMediaOrders.Columns("DetailItem") IsNot Nothing Then

                    If DataGridViewLeftSection_AvailableJobsAndMediaOrders.Columns("DetailItem").Visible Then

                        DataGridViewLeftSection_AvailableJobsAndMediaOrders.Columns("DetailItem").Visible = False

                    End If

                End If

                DataGridViewRightSection_JobsAndMediaOrders.CurrentView.BestFitColumns()
                DataGridViewLeftSection_AvailableJobsAndMediaOrders.CurrentView.BestFitColumns()

                TabItemCampaignDetails_JobsAndMediaOrdersTab.Tag = True

            End If

        End Sub
        Private Sub LoadDocumentsTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If Campaign IsNot Nothing Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Campaign) With {.CampaignID = Campaign.ID}

                DocumentManagerControlDocuments_CampaignDocuments.ClearControl()

                DocumentManagerControlDocuments_CampaignDocuments.Enabled = DocumentManagerControlDocuments_CampaignDocuments.LoadControl(Database.Entities.DocumentLevel.Campaign, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemCampaignDetails_DocumentsTab.Tag = True

            End If

        End Sub
        Private Sub SaveGeneralTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim JobComponent() As String = Nothing

            If Campaign IsNot Nothing Then

                Campaign.IsClosed = CShort(CheckBoxGeneral_Closed.CheckValue)

                Campaign.OfficeCode = ComboBoxGeneral_Office.GetSelectedValue

                Campaign.Name = TextBoxGeneral_Name.Text

                Campaign.AlertGroupCode = ComboBoxGeneral_AlertGroup.GetSelectedValue
                Campaign.AdNumber = ComboBoxGeneral_AdNumber.GetSelectedValue
                Campaign.MarketCode = ComboBoxGeneral_Market.GetSelectedValue

                If ComboBoxGeneral_JobComponent.HasASelectedValue Then

                    JobComponent = CStr(ComboBoxGeneral_JobComponent.GetSelectedValue).Split("-")

                    If JobComponent.Length = 2 AndAlso IsNumeric(JobComponent(0)) AndAlso IsNumeric(JobComponent(1)) Then

                        Campaign.JobNumber = CInt(JobComponent(0))
                        Campaign.JobComponentNumber = CShort(JobComponent(1))

                    Else

                        Campaign.JobNumber = Nothing
                        Campaign.JobComponentNumber = Nothing

                    End If

                Else

                    Campaign.JobNumber = Nothing
                    Campaign.JobComponentNumber = Nothing

                End If

                If RadioButtonGeneral_Overall.Checked Then

                    Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.Overall

                Else

                    Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders

                End If

                Campaign.StartDate = DateTimePickerGeneral_BeginningDate.GetValue
                Campaign.EndDate = DateTimePickerGeneral_EndingDate.GetValue

                Campaign.IsDirectResponse = CShort(CheckBoxMediaTypes_DirectResponse.CheckValue)
                Campaign.IsInternetAds = CShort(CheckBoxMediaTypes_Internet.CheckValue)
                Campaign.IsMagazine = CShort(CheckBoxMediaTypes_Magazine.CheckValue)
                Campaign.IsNewspaper = CShort(CheckBoxMediaTypes_Newspaper.CheckValue)
                Campaign.IsOther = CShort(CheckBoxMediaTypes_Other.CheckValue)
                Campaign.IsOutOfHome = CShort(CheckBoxMediaTypes_OutOfHome.CheckValue)
                Campaign.IsPrint = CShort(CheckBoxMediaTypes_PrintCollateral.CheckValue)
                Campaign.IsRadio = CShort(CheckBoxMediaTypes_Radio.CheckValue)
                Campaign.IsTelevision = CShort(CheckBoxMediaTypes_Television.CheckValue)

                Campaign.OtherDescription = TextBoxMediaTypes_Other.Text

                Campaign.ClientWebsiteID = SearchableComboBoxGeneral_LandingPage.GetSelectedValue

                Campaign.Comment = TextBoxComments_Comments.Text

            End If

        End Sub
        Private Sub SaveCampaignDetailsTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            If Campaign IsNot Nothing Then

                Campaign.BillingBudgetAmount = NumericInputCampaignDetails_TotalBilling.GetValue
                Campaign.IncomeBudgetAmount = NumericInputCampaignDetails_TotalIncome.GetValue

            End If

        End Sub
        Private Sub SaveJobsAndMediaOrdersTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            If Campaign IsNot Nothing Then



            End If

        End Sub
        Private Sub SaveDocumentsTab(ByVal Campaign As AdvantageFramework.Database.Entities.Campaign)

            If Campaign IsNot Nothing Then



            End If

        End Sub
        Private Function LoadEntity() As AdvantageFramework.Database.Entities.Campaign

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    Campaign = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Include("CampaignDetails").Include("Office").Include("Client").Include("Division").Include("Product")
                                Where Entity.ID = _CampaignID
                                Select Entity).SingleOrDefault

                Catch ex As Exception
                    Campaign = Nothing
                End Try

            End Using

            LoadEntity = Campaign

        End Function

#Region " Public "

        Public Function LoadControl(ByVal CampaignID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            _CampaignID = CampaignID

            If _CampaignID <> 0 Then

                Campaign = LoadEntity()

                If Campaign IsNot Nothing Then

                    _CampaignCode = Campaign.Code

                    LoadEntityDetails(Nothing, Campaign)

                    TabItemCampaignDetails_JobsAndMediaOrdersTab.Visible = RadioButtonGeneral_AssignedToJobsAndOrders.Checked
                    TextBoxMediaTypes_Other.Enabled = CheckBoxMediaTypes_OutOfHome.Checked

                Else

                    Loaded = False

                End If

            Else

                Loaded = False

            End If

            EnableOrDisableActions()

            If Loaded = False Then

                Me.ClearControl()

            End If

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            'objects
            Dim CampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing
            Dim SelectedCampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing
            Dim CampaignDetails As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail) = Nothing

            ComboBoxGeneral_Office.SelectedIndex = 0
            TextBoxGeneral_Client.Text = ""
            TextBoxGeneral_Division.Text = ""
            TextBoxGeneral_Product.Text = ""

            LabelGeneral_ID.Text = ""
            TextBoxGeneral_Code.Text = ""
            TextBoxGeneral_Name.Text = ""

            ComboBoxGeneral_AlertGroup.SelectedIndex = 0
            ComboBoxGeneral_AdNumber.SelectedIndex = 0
            ComboBoxGeneral_Market.SelectedIndex = 0
            ComboBoxGeneral_JobComponent.SelectedIndex = 0

            RadioButtonGeneral_AssignedToJobsAndOrders.Checked = True
            RadioButtonGeneral_Overall.Checked = False

            NumericInputCampaignDetails_TotalBilling.EditValue = Nothing
            NumericInputCampaignDetails_TotalIncome.EditValue = Nothing

            DateTimePickerGeneral_BeginningDate.ValueObject = Nothing
            DateTimePickerGeneral_EndingDate.ValueObject = Nothing

            CheckBoxMediaTypes_DirectResponse.Checked = False
            CheckBoxMediaTypes_Internet.Checked = False
            CheckBoxMediaTypes_Magazine.Checked = False
            CheckBoxMediaTypes_Newspaper.Checked = False
            CheckBoxMediaTypes_Other.Checked = False
            CheckBoxMediaTypes_OutOfHome.Checked = False
            CheckBoxMediaTypes_PrintCollateral.Checked = False
            CheckBoxMediaTypes_Radio.Checked = False
            CheckBoxMediaTypes_Television.Checked = False

            TextBoxMediaTypes_Other.Text = ""

            TextBoxComments_Comments.Text = ""

            CampaignDetails = New Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail)

            DataGridViewCampaignDetails_CampaignDetails.DataSource = CampaignDetails

            LabelCampaignDetails_BillingMediaBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_BillingProductionBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_BillingCombinedBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_BillingTotalAllocatedAmount.Text = FormatCurrency(0)

            LabelCampaignDetails_IncomeMediaBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_IncomeProductionBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_IncomeCombinedBudgetAmount.Text = FormatCurrency(0)
            LabelCampaignDetails_IncomeTotalAllocatedAmount.Text = FormatCurrency(0)

            CampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)
            SelectedCampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)

            DataGridViewRightSection_JobsAndMediaOrders.DataSource = SelectedCampaignDetailItemsList
            DataGridViewLeftSection_AvailableJobsAndMediaOrders.DataSource = CampaignDetailItemsList

            CheckBoxGeneral_Closed.Checked = False

            DocumentManagerControlDocuments_CampaignDocuments.ClearControl()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = Me.FillObject()

                    If Campaign IsNot Nothing Then

                        Campaign.DbContext = DbContext

                        ErrorMessage = Campaign.ValidateEntity(IsValid)

                        If IsValid Then

                            If AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign) Then

                                Saved = True

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                For Each CampaignDetail In DataGridViewCampaignDetails_CampaignDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CampaignDetail)().ToList

                                    CampaignDetail.DbContext = DbContext

                                    CampaignDetail.RevisedDate = Now
                                    CampaignDetail.UserCode = _Session.UserCode

                                    If AdvantageFramework.Database.Procedures.CampaignDetail.Update(DbContext, CampaignDetail) = False Then

                                        DbContext.UndoChanges(CampaignDetail)

                                    End If

                                Next

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                            End If

                            If Not Saved Then

                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = Me.FillObject()

                    If Campaign IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Campaign.Delete(DbContext, Campaign)

                        If Deleted = False Then

                            ErrorMessage = "The campaign is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef CampaignID As Integer) As Boolean

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = Me.FillObject()

                    If Campaign IsNot Nothing Then

                        Campaign.DbContext = DbContext

                        ErrorMessage = Campaign.ValidateEntity(IsValid)

                        If IsValid Then

                            If AdvantageFramework.Database.Procedures.Campaign.Insert(DbContext, Campaign) Then

                                CampaignID = Campaign.ID

                                Inserted = True

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub LoadRequiredNonGridControlsForValidation()

            If _CampaignID <> 0 Then

                If TabItemCampaignDetails_GeneralTab IsNot TabControlControl_CampaignDetails.SelectedTab Then

                    LoadEntityDetails(TabItemCampaignDetails_GeneralTab)

                End If

            End If

        End Sub
        Public Sub CreateBudget()

            If _CampaignID <> 0 Then

                If AdvantageFramework.ProjectManagement.Presentation.CreateBudgetDialog.ShowFormDialog(_CampaignID) = System.Windows.Forms.DialogResult.OK Then

                    TabItemCampaignDetails_CampaignDetailsTab.Tag = False

                    LoadEntityDetails(TabItemCampaignDetails_CampaignDetailsTab)

                End If

            End If

        End Sub
        Public Sub ReAllocateBudget()

            'objects
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim BillingBudgetAmount As Decimal = 0
            Dim IncomeBudgetAmount As Decimal = 0

            If _CampaignID <> 0 Then

                If AdvantageFramework.Navigation.ShowMessageBox("The current budget amounts will be cleared and re-allocated. " & vbCrLf & "Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Campaign = LoadEntity()

                            If Campaign IsNot Nothing Then

                                If NumericInputCampaignDetails_TotalBilling.Value > 0 Then

                                    Try

                                        BillingBudgetAmount = CDec(FormatNumber(NumericInputCampaignDetails_TotalBilling.Value / Campaign.CampaignDetails.Count, 2))

                                    Catch ex As Exception
                                        BillingBudgetAmount = 0
                                    End Try

                                End If

                                If NumericInputCampaignDetails_TotalIncome.Value > 0 Then

                                    Try

                                        IncomeBudgetAmount = CDec(FormatNumber(NumericInputCampaignDetails_TotalIncome.Value / Campaign.CampaignDetails.Count, 2))

                                    Catch ex As Exception
                                        IncomeBudgetAmount = 0
                                    End Try

                                End If

                                For Each CampaignDetail In Campaign.CampaignDetails.ToList

                                    CampaignDetail.BillingBudgetAmount = BillingBudgetAmount
                                    CampaignDetail.IncomeBudgetAmount = IncomeBudgetAmount

                                    AdvantageFramework.Database.Procedures.CampaignDetail.Update(DbContext, CampaignDetail)

                                Next

                            End If

                        End Using

                        TabItemCampaignDetails_CampaignDetailsTab.Tag = False

                        LoadEntityDetails(TabItemCampaignDetails_CampaignDetailsTab)

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Public Sub DeleteSelectedDocument()

            DocumentManagerControlDocuments_CampaignDocuments.DeleteSelectedDocument()

        End Sub
        Public Sub DownloadSelectedDocument()

            DocumentManagerControlDocuments_CampaignDocuments.DownloadSelectedDocument()

        End Sub
		Public Sub UploadNewDocument()

			DocumentManagerControlDocuments_CampaignDocuments.UploadNewDocument()

		End Sub
		Public Sub SendASPUploadEmail()

			DocumentManagerControlDocuments_CampaignDocuments.SendASPUploadEmail()

		End Sub
		Public Sub CancelNewCampaignDetail()

            DataGridViewCampaignDetails_CampaignDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteCampaignDetail()

            'objects
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If _CampaignID <> 0 Then

                If DataGridViewCampaignDetails_CampaignDetails.HasASelectedRow Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        DataGridViewCampaignDetails_CampaignDetails.CurrentView.CloseEditorForUpdating()

                        Me.ShowWaitForm("Processing...")

                        Try

                            RowHandlesAndDataBoundItems = DataGridViewCampaignDetails_CampaignDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                    Try

                                        CampaignDetail = RowHandleAndDataBoundItem.Value

                                    Catch ex As Exception
                                        CampaignDetail = Nothing
                                    End Try

                                    If CampaignDetail IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.CampaignDetail.Delete(DbContext, CampaignDetail) Then

                                            DataGridViewCampaignDetails_CampaignDetails.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    End If

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Public Function ChangeCampaignCode() As Boolean

            'objects
            Dim CodeChanged As Boolean = False
            Dim IsCodeInUse As Boolean = True
            Dim CampaignCode As String = ""
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, _CampaignID)

                If Campaign IsNot Nothing Then

                    IsCodeInUse = AdvantageFramework.Database.Procedures.Campaign.IsCampaignInUse(DbContext, Campaign.ID, Campaign.Code, True)

                    If IsCodeInUse = False Then

                        Do While True

                            CampaignCode = ""

                            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Update Campaign Code", "Enter new campaign code: ", Campaign.Code, CampaignCode, AdvantageFramework.Database.Entities.Campaign.Properties.Code) = Windows.Forms.DialogResult.OK Then

                                If CampaignCode <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(CampaignCode) Then

                                    AdvantageFramework.Navigation.ShowMessageBox("Please enter a valid code.")

                                ElseIf CampaignCode = "" Then

                                    AdvantageFramework.Navigation.ShowMessageBox("Please enter a code.")

                                ElseIf (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext)
                                        Where Entity.ID <> Campaign.ID AndAlso
                                                      Entity.Code.ToUpper = CampaignCode.ToUpper AndAlso
                                                      Entity.ClientCode = Campaign.ClientCode AndAlso
                                                      Entity.DivisionCode = Campaign.DivisionCode AndAlso
                                                      Entity.ProductCode = Campaign.ProductCode
                                        Select Entity).Any Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a unique campaign code.")

                                Else

                                    Campaign.Code = CampaignCode

                                    CodeChanged = AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign)

                                    If CodeChanged Then

                                        TextBoxGeneral_Code.Text = CampaignCode
                                        _CampaignCode = CampaignCode

                                    End If

                                    Exit Do

                                End If

                            Else

                                Exit Do

                            End If

                        Loop

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The campaign code is in use and cannot be changed.")

                    End If

                End If

            End Using

            ChangeCampaignCode = CodeChanged

        End Function
        Public Sub SpellCheckSelectedTab()

            If TabControlControl_CampaignDetails.SelectedTab Is TabItemCampaignDetails_GeneralTab Then

                TextBoxComments_Comments.CheckSpelling()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub CampaignControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TabControlControl_CampaignDetails.SelectedTab = TabItemCampaignDetails_GeneralTab

            DataGridViewCampaignDetails_CampaignDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_CampaignDetails_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_CampaignDetails.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

                LoadEntityDetails(e.NewTab)

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub RadioButtonGeneral_AssignedToJobsAndOrders_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonGeneral_AssignedToJobsAndOrders.CheckedChanged

            TabItemCampaignDetails_JobsAndMediaOrdersTab.Visible = RadioButtonGeneral_AssignedToJobsAndOrders.Checked

        End Sub
        Private Sub CheckBoxMediaTypes_Other_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMediaTypes_Other.CheckedChanged

            TextBoxMediaTypes_Other.Enabled = CheckBoxMediaTypes_Other.Checked

        End Sub
        Private Sub ButtonRightSection_AddJobsAndMediaOrders_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddJobsAndMediaOrders.Click

            'objects
            Dim CampaignID As Integer = Nothing
            Dim CampaignCode As String = Nothing

            If _CampaignID <> 0 Then

                CampaignID = _CampaignID
                CampaignCode = _CampaignCode

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each CampaignDetailItem In DataGridViewLeftSection_AvailableJobsAndMediaOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.CampaignDetailItem)().ToList

                        If TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.Job Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.Job).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.Job).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.Job.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.InternetOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.InternetOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.InternetOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.InternetOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.MagazineOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.MagazineOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.MagazineOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.MagazineOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.NewspaperOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.NewspaperOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.NewspaperOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.NewspaperOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.OutOfHomeOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.OutOfHomeOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.OutOfHomeOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.OutOfHomeOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.RadioOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.RadioOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.RadioOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.RadioOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.TVOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.TVOrder).CampaignID = CampaignID
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.TVOrder).CampaignCode = CampaignCode

                            AdvantageFramework.Database.Procedures.TVOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        End If

                    Next

                    TabItemCampaignDetails_JobsAndMediaOrdersTab.Tag = False

                    LoadEntityDetails(TabItemCampaignDetails_JobsAndMediaOrdersTab)

                End Using

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveJobsAndMediaOrders_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveJobsAndMediaOrders.Click

            If _CampaignID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each CampaignDetailItem In DataGridViewRightSection_JobsAndMediaOrders.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.CampaignDetailItem)().ToList

                        If TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.Job Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.Job).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.Job).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.Job.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.InternetOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.InternetOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.InternetOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.InternetOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.MagazineOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.MagazineOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.MagazineOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.MagazineOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.NewspaperOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.NewspaperOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.NewspaperOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.NewspaperOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.OutOfHomeOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.OutOfHomeOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.OutOfHomeOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.OutOfHomeOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.RadioOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.RadioOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.RadioOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.RadioOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        ElseIf TypeOf CampaignDetailItem.DetailItem Is AdvantageFramework.Database.Entities.TVOrder Then

                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.TVOrder).CampaignID = Nothing
                            DirectCast(CampaignDetailItem.DetailItem, AdvantageFramework.Database.Entities.TVOrder).CampaignCode = Nothing

                            AdvantageFramework.Database.Procedures.TVOrder.Update(DbContext, CampaignDetailItem.DetailItem)

                        End If

                    Next

                    TabItemCampaignDetails_JobsAndMediaOrdersTab.Tag = False

                    LoadEntityDetails(TabItemCampaignDetails_JobsAndMediaOrdersTab)

                End Using

            End If

        End Sub
        Private Sub DataGridViewCampaignDetails_CampaignDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewCampaignDetails_CampaignDetails.AddNewRowEvent

            'objects
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.CampaignDetail Then

                Me.ShowWaitForm("Processing...")

                Try

                    CampaignDetail = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If CampaignDetail.IsEntityBeingAdded() Then

                            CampaignDetail.DbContext = DbContext

                            CampaignDetail.CampaignID = _CampaignID
                            CampaignDetail.RevisedDate = Now
                            CampaignDetail.UserCode = _Session.UserCode

                            AdvantageFramework.Database.Procedures.CampaignDetail.Insert(DbContext, CampaignDetail)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewCampaignDetails_CampaignDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewCampaignDetails_CampaignDetails.InitNewRowEvent

            RaiseEvent CampaignDetailsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewCampaignDetails_CampaignDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewCampaignDetails_CampaignDetails.SelectionChangedEvent

            RaiseEvent CampaignDetailsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DocumentManagerControlDocuments_CampaignDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_CampaignDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub SearchableComboBoxGeneral_LandingPage_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_LandingPage.EditValueChanged

            TextBoxGeneral_WebsiteName.Text = SearchableComboBoxGeneral_LandingPage.Properties.View.GetRowCellValue(SearchableComboBoxGeneral_LandingPage.Properties.View.FocusedRowHandle, "WebsiteName")

        End Sub

#End Region

#End Region

    End Class

End Namespace
