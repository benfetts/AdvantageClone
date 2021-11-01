Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Partial Public Class CampaignPage
    Inherits Webvantage.BaseChildPage

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

    Private CmpCode As String = ""
    Private Property CmpIdentifier As Integer
        Get
            If ViewState("CmpIdentifier") Is Nothing Then ViewState("CmpIdentifier") = 0
            Return ViewState("CmpIdentifier")
        End Get
        Set(value As Integer)
            ViewState("CmpIdentifier") = value
        End Set
    End Property

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        Try

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.CampaignIdentifier > 0 Then

                Me.CmpIdentifier = qs.CampaignIdentifier

            End If
        Catch ex As Exception

            CmpIdentifier = 0

        End Try

        If CmpIdentifier = 0 AndAlso Not Request.QueryString("cmp") = Nothing Then

            If IsNumeric(Request.QueryString("cmp")) = True Then

                Me.CmpIdentifier = CType(Request.QueryString("cmp"), Integer)

            End If

        End If

        RadToolbarCampaign.FindItemByValue("Upload").Enabled = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False))

        RadToolbarCampaign.FindItemByValue("ViewDocs").Enabled = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False))

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Campaign, False))
        RadToolbarCampaign.FindItemByValue("ViewDocs").Enabled = HasAccessToDocuments
        RadToolbarCampaign.FindItemByValue("Upload").Enabled = HasAccessToDocuments

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

        If Page.IsPostBack = False And Page.IsCallback = False Then

            'Me.RadToolbarCampaign.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            RadToolbarCampaign.FindItemByValue("New").Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)

            RadToolbarCampaign.FindItemByValue("Save").Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)

            If RadToolbarCampaign.FindItemByValue("Save").Enabled = False Then

                CollapsablePanelHeader.Collapsed = False
                CollapsablePanelHeader.Enabled = False

                CollapsablePanelHeaderDetails.Collapsed = False
                CollapsablePanelHeaderDetails.Enabled = False

                CollapsablePanelCampaignDetail.Collapsed = False
                CollapsablePanelCampaignDetail.Enabled = False

                CollapsablePanelMediaTypes.Collapsed = False
                CollapsablePanelMediaTypes.Enabled = False

                CollapsablePanelComment.Collapsed = False
                CollapsablePanelComment.Enabled = False

                CollapsablePanelMediaGrid.Collapsed = False
                CollapsablePanelMediaGrid.Enabled = False

                CollapsablePanelAttachMedia.Collapsed = False
                CollapsablePanelAttachMedia.Enabled = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxMarket.DataSource = (From Market In AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext).ToList
                                                Select [Code] = Market.Code,
                                                       [Description] = Market.ToString).ToList
                RadComboBoxMarket.DataBind()

                Try

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                Catch ex As Exception
                    Campaign = Nothing
                End Try

                If Campaign IsNot Nothing Then

                    JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, Campaign.ClientCode, Nothing, Nothing, 0, True, Nothing).ToList

                    If Campaign.JobNumber.HasValue AndAlso Campaign.JobComponentNumber.HasValue Then

                        If Not JobComponents.Any(Function(jc) jc.JobNumber = Campaign.JobNumber AndAlso jc.JobComponentNumber = Campaign.JobComponentNumber) Then

                            JobComponents = JobComponents.Union(AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext).Where(Function(jc) jc.JobNumber = Campaign.JobNumber AndAlso jc.JobComponentNumber = Campaign.JobComponentNumber).ToList).ToList

                        End If

                    End If

                    RadComboBoxLandingPage.DataSource = (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, Campaign.ClientCode)
                                                         Where Entity.IsInactive = False
                                                         Select Entity).ToList

                    RadComboBoxLandingPage.DataBind()

                Else

                    JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, _Session.UserCode, Nothing, Nothing, Nothing, 0, True, Nothing).ToList

                End If

                RadComboBoxJobComponent.DataSource = (From JobComponent In JobComponents
                                                      Select [JobComponent] = JobComponent.ToString(True, False),
                                                             [Description] = JobComponent.ToString(True, True)).ToList

                RadComboBoxJobComponent.DataBind()

                RadComboBoxMarket.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                RadComboBoxJobComponent.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            End Using

            Try
                LoadCampaign()
                LoadListboxes()
            Catch ex As Exception
                CmpCode = 0
            End Try
        Else
            Select Case Me.EventArgument
                Case "HidePopups"

                    Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
                    If cmp.isALertGroupActive(cmp.ALERT_GROUP) = 0 Then
                        DDAlertGrp.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(cmp.ALERT_GROUP, cmp.ALERT_GROUP))
                    End If
                    DDAlertGrp.Text = cmp.ALERT_GROUP

                    If DDAlertGrp.Text = "" Then
                        DDAlertGrp.Text = "[None]"
                    End If

                Case "Refresh"

                    MiscFN.ResponseRedirect("Campaign.aspx?cmp=" & CmpIdentifier.ToString)

                Case "HidePopUpRefresh"

                    Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
                    If cmp.isALertGroupActive(cmp.ALERT_GROUP) = 0 Then
                        DDAlertGrp.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(cmp.ALERT_GROUP, cmp.ALERT_GROUP))
                    End If
                    DDAlertGrp.Text = cmp.ALERT_GROUP

                    If DDAlertGrp.Text = "" Then
                        DDAlertGrp.Text = "[None]"
                    End If

                Case "Notify"
                    Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
                    If cmp.CMP_IDENTIFIER > 0 Then
                        Me.OpenWindow("Alert", "Alert_New.aspx?caller=campaign&f=" & CType(MiscFN.Source_App.Campaign, Integer).ToString() & "&cmp=" & cmp.CMP_IDENTIFIER.ToString())
                    End If
                Case "Print"
                    Me.OpenWindow("Campaign Print", "Campaign_Print.aspx?cmp=" & CmpIdentifier.ToString)
            End Select

        End If

    End Sub

    Private Sub LoadCampaign()

        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        SetLookups()

        Me.RadToolbarCampaign.Visible = True

        'CollapsablePanelHeader.Visible = True
        CollapsablePanelCampaignDetail.Visible = True
        CollapsablePanelMediaTypes.Visible = True
        CollapsablePanelComment.Visible = True
        CollapsablePanelMediaGrid.Visible = True
        CollapsablePanelAttachMedia.Visible = True

        cbCloseCmp.Visible = True

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                If Campaign IsNot Nothing Then

                    Me.CmpCode = Campaign.Code

                    RadComboBoxAdNumber.DataSource = (From Ad In AdvantageFramework.Database.Procedures.Ad.LoadAllActiveByClientCodeAndNotExpired(DbContext, Campaign.ClientCode)
                                                      Select [Number] = Ad.Number,
                                                             [Description] = Ad.ToString).ToList
                    RadComboBoxAdNumber.DataBind()

                    RadComboBoxAdNumber.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                    txtOffice.Text = If(Campaign.OfficeCode Is Nothing OrElse Campaign.OfficeCode = "", "", Campaign.OfficeCode)
                    txtOfficeDesc.Text = If(Campaign.Office Is Nothing OrElse Campaign.Office.Name = "", "", Campaign.Office.Name)

                    txtClient.Text = If(Campaign.ClientCode Is Nothing OrElse Campaign.ClientCode = "", "", Campaign.ClientCode)
                    txtClientDesc.Text = If(Campaign.Client Is Nothing OrElse Campaign.Client.Name = "", "", Campaign.Client.Name)

                    txtDivision.Text = If(Campaign.DivisionCode Is Nothing OrElse Campaign.DivisionCode = "", "", Campaign.DivisionCode)
                    txtDivisionDesc.Text = If(Campaign.Division Is Nothing OrElse Campaign.Division.Name = "", "", Campaign.Division.Name)

                    txtProduct.Text = If(Campaign.ProductCode Is Nothing OrElse Campaign.ProductCode = "", "", Campaign.ProductCode)
                    txtProductDesc.Text = If(Campaign.Product Is Nothing OrElse Campaign.Product.Name = "", "", Campaign.Product.Name)

                    txtCampaignCode.Text = If(Campaign.Code Is Nothing OrElse Campaign.Code = "", "", Campaign.Code)
                    txtCampaignCodeDesc.Text = If(Campaign.Name Is Nothing OrElse Campaign.Name = "", "", Campaign.Name)

                    LabelCampaignID.Text = If(Campaign.ID = Nothing OrElse Campaign.ID = 0, "", Campaign.ID)

                    If Not Campaign.AlertGroupCode Is Nothing Then

                        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
                        If cmp.isALertGroupActive(Campaign.AlertGroupCode) = 0 Then

                            DDAlertGrp.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(Campaign.AlertGroupCode, Campaign.AlertGroupCode))

                        End If

                    End If
                    MiscFN.RadComboBoxSetIndex(Me.DDAlertGrp, Campaign.AlertGroupCode, False)

                    If Not Campaign.CampaignType = Nothing Then rbType.SelectedValue = Campaign.CampaignType


                    If rbType.SelectedIndex > -1 AndAlso rbType.SelectedValue = 1 Then

                        CollapsablePanelMediaGrid.Visible = False
                        CollapsablePanelAttachMedia.Visible = False

                    Else

                        CollapsablePanelMediaGrid.Visible = True
                        CollapsablePanelAttachMedia.Visible = True

                    End If


                    txtCmp_ID.Text = Campaign.ID
                    Me.CmpIdentifier = Campaign.ID

                    cbCloseCmp.Checked = If(Campaign.IsClosed Is Nothing OrElse Campaign.IsClosed = 0, False, True)

                    txtTotalBilling.Text = If(Campaign.BillingBudgetAmount Is Nothing, "", FormatNumber(Campaign.BillingBudgetAmount, 2, TriState.True, TriState.False, TriState.True))
                    txtTotalIncome.Text = If(Campaign.IncomeBudgetAmount Is Nothing, "", FormatNumber(Campaign.IncomeBudgetAmount, 2, TriState.True, TriState.False, TriState.True))

                    Try
                        If Not Campaign.StartDate Is Nothing Then

                            Dim startDate As Date = Campaign.StartDate
                            If LoGlo.FormatDate(startDate.ToString("d")) <> LoGlo.FormatDate("1/1/1900") Then

                                Me.RadDatePickerBeginningDate.SelectedDate = startDate

                            End If

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not Campaign.EndDate Is Nothing Then

                            Dim EndDate As Date = Campaign.EndDate
                            If LoGlo.FormatDate(EndDate.ToString("d")) <> LoGlo.FormatDate("1/1/1900") Then

                                Me.RadDatePickerEndDate.SelectedDate = EndDate

                            End If

                        End If
                    Catch ex As Exception
                    End Try

                    Me.cbDirect.Checked = If(Campaign.IsDirectResponse Is Nothing OrElse Campaign.IsDirectResponse = 0, False, True)
                    Me.cbMagazine.Checked = If(Campaign.IsMagazine Is Nothing OrElse Campaign.IsMagazine = 0, False, True)
                    Me.cbNewspaper.Checked = If(Campaign.IsNewspaper Is Nothing OrElse Campaign.IsNewspaper = 0, False, True)
                    Me.cbOutOfHome.Checked = If(Campaign.IsOutOfHome Is Nothing OrElse Campaign.IsOutOfHome = 0, False, True)
                    Me.cbPrint.Checked = If(Campaign.IsPrint Is Nothing OrElse Campaign.IsPrint = 0, False, True)
                    Me.cbRadio.Checked = If(Campaign.IsRadio Is Nothing OrElse Campaign.IsRadio = 0, False, True)
                    Me.cbTV.Checked = If(Campaign.IsTelevision Is Nothing OrElse Campaign.IsTelevision = 0, False, True)


                    If (If(Campaign.IsOther Is Nothing OrElse Campaign.IsOther = 0, False, True)) = True Then

                        cbOther.Checked = True
                        txtOther.Text = If(Campaign.OtherDescription Is Nothing OrElse Campaign.OtherDescription = "", "", Campaign.OtherDescription)

                    Else

                        cbOther.Checked = False
                        txtOther.Text = ""

                    End If

                    Me.cbInternet.Checked = If(Campaign.IsInternetAds Is Nothing OrElse Campaign.IsInternetAds = 0, False, True)

                    Me.txtComment.Text = If(Campaign.Comment Is Nothing OrElse Campaign.Comment = "", "", Campaign.Comment)

                    RadComboBoxAdNumber.SelectedValue = If(Campaign.AdNumber Is Nothing OrElse Campaign.AdNumber = "", "", Campaign.AdNumber)
                    RadComboBoxMarket.SelectedValue = If(Campaign.MarketCode Is Nothing OrElse Campaign.MarketCode = "", "", Campaign.MarketCode)
                    RadComboBoxJobComponent.SelectedValue = If(Campaign.JobNumber Is Nothing OrElse Campaign.JobNumber = 0 OrElse Campaign.JobComponentNumber Is Nothing OrElse Campaign.JobComponentNumber = 0, "", AdvantageFramework.StringUtilities.PadWithCharacter(Campaign.JobNumber, 6, "0", True, True).Trim & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Campaign.JobComponentNumber, 2, "0", True, True).Trim)
                    RadComboBoxLandingPage.SelectedValue = If(Campaign.ClientWebsiteID Is Nothing, "", Campaign.ClientWebsiteID)

                    If Campaign.ClientWebsiteID.HasValue Then

                        TextBoxWebsiteName.Text = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientWebsite)
                                                   Where Entity.ID = Campaign.ClientWebsiteID.Value
                                                   Select Entity).FirstOrDefault.WebsiteName

                    Else

                        TextBoxWebsiteName.Text = Nothing

                    End If

                End If

            End Using

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try

        MiscFN.SetFocus(txtOffice)

    End Sub

    Private Sub LoadListboxes()
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), Me.CmpIdentifier)

        Dim drA As SqlDataReader
        Dim drN As SqlDataReader
        Dim prd As String = ""
        Dim div As String = ""
        Dim grp As String = ""

        If txtDivision.Text.Length > 0 Then
            div = txtDivision.Text
        End If
        If txtProduct.Text.Length > 0 Then
            prd = txtProduct.Text
        End If

        grp = getSelectedGroup()

        drA = cmp.GetAvailableMedia(grp, txtClient.Text, div, prd)
        Me.listAllow.DataSource = drA
        Me.listAllow.DataValueField() = "Code"
        Me.listAllow.DataTextField() = "Description"
        Me.listAllow.DataBind()

        drN = cmp.GetAttachedMedia(grp, CInt(cmp.CMP_IDENTIFIER))
        Me.listNotAllowed.DataSource = drN
        Me.listNotAllowed.DataValueField() = "Code"
        Me.listNotAllowed.DataTextField() = "Description"
        Me.listNotAllowed.DataBind()
    End Sub

    Private Sub RadToolbarCampaign_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCampaign.ButtonClick

        'objects
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
        Dim Msg As String = String.Empty

        Select Case e.Item.Value
            Case "Save"

                If SaveCampaign(False, Msg) = False Then

                    If String.IsNullOrWhiteSpace(Msg) = False Then

                        Me.ShowMessage(Msg)

                    End If

                End If

                Me.LoadCampaign()

            Case "Search"

                Me.OpenWindow("Campaign Search", "Campaign_Search.aspx")

            Case "Refresh"

                MiscFN.ResponseRedirect("Campaign.aspx?cmp=" & CmpIdentifier.ToString)

            Case "New"

                Me.OpenWindow("New Campaign", "Campaign_New.aspx")

            Case "NewAlert"

                If SaveCampaign(True, Msg) = False Then

                    If String.IsNullOrWhiteSpace(Msg) = False Then

                        Me.ShowMessage(Msg)

                    End If


                Else

                    Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)

                    If cmp.CMP_IDENTIFIER > 0 Then

                        Me.OpenWindow("Campaign Alert", "Alert_New.aspx?assn=0&caller=campaign&f=" & CType(MiscFN.Source_App.Campaign, Integer).ToString() & "&cmp=" & cmp.CMP_IDENTIFIER.ToString())

                    End If

                End If

                Me.LoadCampaign()

            Case "NewAlertAssignment"

                If SaveCampaign(True, Msg) = False Then

                    If String.IsNullOrWhiteSpace(Msg) = False Then

                        Me.ShowMessage(Msg)

                    End If

                Else

                    Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)

                    If cmp.CMP_IDENTIFIER > 0 Then

                        Me.OpenWindow("Campaign Alert", "Alert_New.aspx?assn=1&caller=campaign&f=" & CType(MiscFN.Source_App.Campaign, Integer).ToString() & "&cmp=" & cmp.CMP_IDENTIFIER.ToString())

                    End If

                End If

                Me.LoadCampaign()

                'Case "Print"

                '    Me.OpenWindow("Print Campaign", "Campaign_Print.aspx?cmp=" & Me.CmpIdentifier)

            Case "Print"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Campaign_Print.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                Me.OpenPrintSendSilently(qs)

            Case "SendAlert"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Campaign_Print.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                Me.OpenPrintSendSilently(qs)

            Case "SendAssignment"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Campaign_Print.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                Me.OpenPrintSendSilently(qs)

            Case "SendEmail"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Campaign_Print.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                Me.OpenPrintSendSilently(qs)

            Case "PrintSendOptions"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Campaign_Print.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                Me.OpenWindow(qs)

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.CampaignCode = Me.CmpCode

                qs.Page = "Campaign.aspx"

                qs.Add("bm", "1")

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Campaign
                    .UserCode = Session("UserCode")
                    .Name = "Campaign: " & Me.CmpIdentifier & " " & MiscFN.JavascriptSafe(Me.txtCampaignCodeDesc.Text)
                    .Description = Me.txtCampaignCodeDesc.Text & " Campaign"
                    .PageURL = qs.ToString(True)

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    ' Me.RefreshBookmarksDesktopObject()

                End If

            Case "Alerts"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_List.aspx"
                qs.CampaignIdentifier = Me.CmpIdentifier
                qs.Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.Campaign)

                Me.OpenWindow(qs)

            Case RadToolbarCampaign.FindItemByValue("Delete").Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                    If Campaign IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Campaign.Delete(DbContext, Campaign) Then

                            Me.CloseThisWindowAndRefreshCaller("Campaign_Search.aspx")

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("The campaign is in use and cannot be deleted.")

                        End If

                    End If

                End Using

            Case RadToolbarCampaign.FindItemByValue("ChangeCode").Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                    If Campaign IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Campaign.IsCampaignInUse(DbContext, Campaign.ID, Campaign.Code, True) = False Then

                            Me.OpenWindow("Update Campaign Code", "Campaign_ChangeCode.aspx?CampaignID=" & Me.CmpIdentifier, 200, 400, False, True)

                        Else

                            AdvantageFramework.Navigation.ShowMessageBox("The campaign code is in use and cannot be changed.")

                        End If

                    End If

                End Using
            Case "Detail"
                '?CampaignID=" & Me.CmpIdentifier
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                    If Campaign IsNot Nothing Then
                        Me.OpenWindow("Campaign " & If(Campaign.Code = Me.CmpIdentifier.ToString, Me.CmpIdentifier.ToString, Campaign.Code & " (" & Me.CmpIdentifier.ToString & ")") & " Periods ", "modules/project-management/campaigns/campaign-periods?CampaignID=" & Me.CmpIdentifier, 200, 400, False, True)
                    Else
                        Me.OpenWindow("Campaign " & Me.CmpIdentifier.ToString & " Periods ", "modules/project-management/campaigns/campaign-periods?CampaignID=" & Me.CmpIdentifier, 200, 400, False, True)
                    End If

                End Using


        End Select

    End Sub

    Private Sub ViewDocs()
        Dim strURL As String
        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder

        strURL = "Documents_List.aspx?DocPopupType=campaign&cmp=" & Me.CmpIdentifier

        Me.OpenWindow("View documents", strURL)
    End Sub

    Private Sub Upload()
        'Dim cCmp As New cCampaign(CStr(Session("ConnString")), Me.CmpIdentifier)

        Session("DocCaption") = ""  ' "Campaign: " & cCmp.CMP_CODE   'Displays in Description, Specs said no default. Clear for Expense Issue
        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx??caller=" & Me.PageFilename & "&Level=CM&FK=" & Me.CmpIdentifier.ToString() & "&Value=" & Me.CmpCode, 550, 575)
    End Sub

    Private Sub SendAlerts(ByVal origCmp As cCampaign)

        CmpCode = Me.txtCampaignCode.Text

        'Dim Alert As New Alert(Session("ConnString"))
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
        Dim NowDate As Date = Now
        Dim url As String
        Dim catID As Integer
        Dim empCode, subject As String
        Dim dr As SqlDataReader
        Dim IsAgencyAutoEmail As Boolean = cmp.IsAgencyAutoEmail()
        Dim bool As Boolean
        Dim body, bodyHTML As String

        If cmp.ALERT_GROUP <> "" Then
            Dim newCmp As String = "0"
            If Not Session("newCampaign") Is Nothing And Not Request.QueryString("New") Is Nothing Then
                If Session("newCampaign") = True And Request.QueryString("New") = "1" Then
                    newCmp = "1"
                End If
            End If

            If newCmp = "1" Then
                subject = "New Campaign - " & CmpCode & " - " & Me.txtCampaignCodeDesc.Text & " for client " & txtClient.Text & " created by " & cmp.getUserFullEmpName(Session("UserCode"))
                catID = 6
            Else
                subject = "Existing Campaign - " & CmpCode & " - " & Me.txtCampaignCodeDesc.Text & " for client " & txtClient.Text & " modified by " & cmp.getUserFullEmpName(Session("UserCode"))
                catID = 7
            End If


            url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath
            bodyHTML = cmp.CreateBody(subject, url, origCmp)
            body = cmp.CreateBodyString(subject, url, origCmp)

            If IsAgencyAutoEmail = True Then
                Dim IsCategoryPrompt As Boolean = cmp.IsAlertCategoryPrompt(catID)
                'Dim IsCategoryPrompt As Boolean = True 'Debug
                If IsCategoryPrompt = True Then
                    'Open prompt window
                    Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
                    Dim emailGrp As String = Me.DDAlertGrp.Text
                    If emailGrp = "[None]" Then
                        emailGrp = ""
                    End If

                    Try
                        With sbQSVars
                            .Append("?")
                            .Append("EmailGroup=" & emailGrp)
                            .Append("&Recipients=" & "")
                            .Append("&IsHTML=True")
                            .Append("&New=" & newCmp)
                            .Append("&cmp=" & Me.txtCmp_ID.Text)
                            .Append("&ClientCode=" & Me.txtClient.Text)
                            .Append("&DivCode=" & Me.txtDivision.Text)
                            .Append("&ProdCode=" & Me.txtProduct.Text)
                            .Append("&OfficeCode=" & Me.txtOffice.Text)
                            .Append("&f=")
                            .Append(MiscFN.SourceApp_ToInt(Source_App.Campaign))
                        End With

                        Session("AlertPopUp_Title") = subject
                        Session("AlertPopUp_Body") = body
                        Session("AlertPopUp_BodyHTML") = bodyHTML
                        Dim str_PopEmail As String = Server.UrlDecode("window.open('popup_email_alert.aspx" & sbQSVars.ToString() & "','','screenX=150,left=150,screenY=150,top=150,width=310,height=575,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
                        Session("JobSpecsEmailPopup") = "CMP"
                        PageLoadJS(str_PopEmail)

                    Catch ex As Exception
                        Me.ShowMessage("Error setting sbQSVars: " & ex.Message.ToString())
                    End Try

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                        'just send to default group, if exists, without prompting
                        dr = cmp.GetEmailAddressFromGroup(cmp.ALERT_GROUP)
                        If dr.HasRows Then

                            Dim wsEmail As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                            Dim Employee As New cEmployee(CStr(Session("ConnString")))
                            Dim EmailFlag As Integer
                            Dim emailAddress As String

                            With FxAlert
                                .AlertTypeID = 2
                                .AlertCategoryID = catID
                                .Subject = subject
                                .Body = body
                                .EmailBody = bodyHTML
                                .GeneratedDate = NowDate
                                .LastUpdated = .GeneratedDate
                                .PriorityLevel = 3
                                .EmployeeCode = Session("EmpCode")
                                .AlertLevel = "CM"
                                .UserCode = Session("UserCode")
                                .ClientCode = txtClient.Text
                                .DivisionCode = txtDivision.Text
                                .ProductCode = txtProduct.Text
                                .CampaignCode = CmpCode
                                .OfficeCode = txtOffice.Text
                                .CampaignID = cmp.CMP_IDENTIFIER
                            End With

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                                Dim Alert As New Alert(Session("ConnString"))
                                Alert.LoadByPrimaryKey(FxAlert.ID)

                                Do While dr.Read
                                    empCode = dr.GetString(0)
                                    emailAddress = dr.GetString(1)
                                    EmailFlag = Employee.GetAlertEmailFlag(empCode)

                                    Select Case EmailFlag
                                        Case 0 'no alerts or email
                                        Case 1  'email only
                                            bool = wsEmail.SendEmail("", emailAddress, subject, bodyHTML, "", "", True)
                                            'If bool = False Then
                                            '    Me.ShowMessage(wsEmail.getErrMsg)
                                            'End If

                                        Case 2  'alert only
                                            Alert.AddAlertRecipient(empCode)

                                        Case 3  'both alert and email
                                            Alert.AddAlertRecipient(empCode)
                                            bool = wsEmail.SendEmail("", emailAddress, subject, bodyHTML, "", "", True)
                                            'If bool = False Then
                                            '    Me.ShowMessage(wsEmail.getErrMsg)
                                            'End If
                                            'AlertFlag = True
                                    End Select
                                Loop

                                Me.CheckForAsyncMessage()

                                'If AlertFlag = True Then
                                '    SendEmailAlert(Alert.ALERT_ID)
                                'End If

                            Else

                                Me.ShowMessage("Alert failed to save")

                            End If


                        End If

                    End Using

                End If
            End If
        End If

    End Sub

    Private Function SaveCampaign(ByVal manual As Boolean, ByRef Message As String) As Boolean

        Dim li_rc As Integer
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
        Dim JobComponent() As String = Nothing
        Dim Updated As Boolean = True
        'Me.CmpIdentifier = txtCmp_ID.Text

        Dim cmpOrig As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), CmpIdentifier)

        If Me.ValidateInput = False Then

            Message = "Invalid input"
            Return False

        End If

        Try

            Dim TypeBefore As Integer = 0
            Dim emailGrp As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CmpIdentifier)

                If Campaign IsNot Nothing Then

                    With Campaign

                        TypeBefore = .CampaignType

                        .OfficeCode = IIf(Me.txtOffice.Text.Trim() = "", Nothing, Me.txtOffice.Text.Trim())
                        .Name = Me.txtCampaignCodeDesc.Text.Trim()

                        Try

                            emailGrp = Me.DDAlertGrp.SelectedValue

                        Catch ex As Exception

                            emailGrp = ""

                        End Try

                        If emailGrp = "[None]" Then

                            emailGrp = ""

                        End If

                        If emailGrp = "" Then

                            .AlertGroupCode = Nothing

                        Else

                            .AlertGroupCode = emailGrp

                        End If

                        .CampaignType = rbType.SelectedValue
                        .OtherDescription = txtOther.Text.Trim()
                        .Comment = txtComment.Text.Trim()

                        If Me.RadDatePickerBeginningDate.DateInput.Text.Trim() = "" Then

                            .StartDate = Nothing

                        Else

                            If MiscFN.ValidDate(Me.RadDatePickerBeginningDate) = True Then

                                .StartDate = Me.RadDatePickerBeginningDate.SelectedDate

                            Else

                                Message = "Invalid Start date."
                                Updated = False

                            End If

                        End If
                        If Me.RadDatePickerEndDate.DateInput.Text.Trim() = "" Then

                            .EndDate = Nothing

                        Else

                            If MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then

                                .EndDate = Me.RadDatePickerEndDate.SelectedDate

                            Else

                                Message = "Invalid End date."
                                Updated = False

                            End If

                        End If

                        If Me.txtTotalBilling.Text.Trim() = "" Then

                            .BillingBudgetAmount = 0.0

                        Else

                            If IsNumeric(Me.txtTotalBilling.Text) = True Then

                                .BillingBudgetAmount = Me.txtTotalBilling.Text

                            Else

                                Message = "Invalid Total Billing Amount."
                                Updated = False

                            End If

                        End If
                        If Me.txtTotalIncome.Text.Trim() = "" Then

                            .IncomeBudgetAmount = 0.0

                        Else

                            If IsNumeric(Me.txtTotalIncome.Text) = True Then

                                .IncomeBudgetAmount = Me.txtTotalIncome.Text

                            Else

                                Message = "Invalid Income Amount."
                                Updated = False

                            End If

                        End If

                        .IsClosed = CType(IIf(Me.cbCloseCmp.Checked = True, 1, 0), Short)
                        .IsDirectResponse = CType(IIf(Me.cbDirect.Checked = True, 1, 0), Short)
                        .IsMagazine = CType(IIf(Me.cbMagazine.Checked = True, 1, 0), Short)
                        .IsNewspaper = CType(IIf(Me.cbNewspaper.Checked = True, 1, 0), Short)
                        .IsOutOfHome = CType(IIf(Me.cbOutOfHome.Checked = True, 1, 0), Short)
                        .IsPrint = CType(IIf(Me.cbPrint.Checked = True, 1, 0), Short)
                        .IsRadio = CType(IIf(Me.cbRadio.Checked = True, 1, 0), Short)
                        .IsTelevision = CType(IIf(Me.cbTV.Checked = True, 1, 0), Short)
                        .IsOther = CType(IIf(Me.cbOther.Checked = True, 1, 0), Short)
                        .IsInternetAds = CType(IIf(Me.cbInternet.Checked = True, 1, 0), Short)

                        .AdNumber = IIf(RadComboBoxAdNumber.SelectedValue = "", Nothing, RadComboBoxAdNumber.SelectedValue)
                        .MarketCode = IIf(RadComboBoxMarket.SelectedValue = "", Nothing, RadComboBoxMarket.SelectedValue)

                        If RadComboBoxJobComponent.SelectedValue <> "" Then

                            JobComponent = CStr(RadComboBoxJobComponent.SelectedValue).Split("-")

                            If JobComponent.Length = 2 AndAlso IsNumeric(JobComponent(0)) AndAlso IsNumeric(JobComponent(1)) Then

                                .JobNumber = CInt(JobComponent(0))
                                .JobComponentNumber = CShort(JobComponent(1))

                            Else

                                .JobNumber = Nothing
                                .JobComponentNumber = Nothing

                            End If

                        Else

                            .JobNumber = Nothing
                            .JobComponentNumber = Nothing

                        End If

                        If RadComboBoxLandingPage.SelectedValue = "" Then

                            .ClientWebsiteID = Nothing

                        Else

                            .ClientWebsiteID = CInt(RadComboBoxLandingPage.SelectedValue)

                        End If

                    End With

                End If

                If Updated = True Then

                    Updated = AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign, Message)

                End If

                If Updated = True Then

                    If Campaign.CampaignType = 2 And TypeBefore = 2 Then

                        If saveListboxAttachments() = False Then

                            Message = "Error saving media attachments to database."
                            Updated = False

                        End If

                        radGridAllMedia.Rebind()

                    Else

                        If Campaign.CampaignType = 2 Then

                            radGridAllMedia.DataSource = cmp.GetAllAttachedMedia(Me.CmpIdentifier)
                            radGridAllMedia.DataBind()

                        End If

                    End If

                End If

            End Using

            If Updated = True AndAlso manual = False AndAlso emailGrp <> "" Then

                SendAlerts(cmpOrig)

            End If

            Session("newCampaign") = False
            LoadCampaign()

            Return Updated

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Function

    Private Function saveListboxAttachments() As Boolean
        Dim idx As Integer
        Dim grp As String = getSelectedGroup()
        'Dim cmpCode As String = Request.QueryString("CmpCode")
        Dim cmpID As Integer = Me.CmpIdentifier
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), cmpID)
        Dim type, ls_rc As String
        Dim orderNbr As Integer

        type = getSelectedGroup()

        'Null out cmp_ID & Code in case user detached any Jobs/Media
        For idx = 0 To Me.listAllow.Items.Count - 1
            orderNbr = CInt(Me.listAllow.Items.Item(idx).Value)
            ls_rc = cmp.UpdateMediaAttachments(type, 0, orderNbr)
            If ls_rc <> "" Then
                Me.ShowMessage(ls_rc)
                Return False
            End If
        Next

        'Attach current campaign to selected jobs/media
        For idx = 0 To Me.listNotAllowed.Items.Count - 1
            orderNbr = CInt(Me.listNotAllowed.Items.Item(idx).Value)
            ls_rc = cmp.UpdateMediaAttachments(type, cmp.CMP_IDENTIFIER, orderNbr)
            If ls_rc <> "" Then
                Me.ShowMessage(ls_rc)
                Return False
            End If
        Next

        Return True

    End Function

    Private Function ValidateInput() As Boolean

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

        InvalidOffice.Visible = False
        InvalidBilling.Visible = False
        InvalidIncome.Visible = False
        InvalidBegDate.Visible = False
        InvalidEndDate.Visible = False
        InvalidEndDate.Text = "Invalid Ending Date"
        InvalidDescription.Visible = False

        If Me.txtOffice.Text <> "" Then

            If myVal.ValidateOffice(Me.txtOffice.Text.Trim, True) = False Then

                InvalidOffice.Visible = True
                MiscFN.SetFocus(txtOffice)
                Return False

            End If

        End If

        If Me.txtCampaignCodeDesc.Text = "" Then

            InvalidDescription.Visible = True
            MiscFN.SetFocus(txtCampaignCodeDesc)
            Return False

        End If

        'Dates

        If MiscFN.EmptyDate(Me.RadDatePickerBeginningDate) = False AndAlso MiscFN.ValidDate(Me.RadDatePickerBeginningDate) = False Then

            InvalidBegDate.Visible = True
            Me.RadDatePickerBeginningDate.DateInput.Focus()
            Return False

        End If

        If MiscFN.EmptyDate(Me.RadDatePickerEndDate) = False AndAlso MiscFN.ValidDate(Me.RadDatePickerEndDate) = False Then

            InvalidEndDate.Visible = True
            Me.RadDatePickerEndDate.DateInput.Focus()
            Return False

        End If

        MiscFN.ValidDateRange(Me.RadDatePickerBeginningDate, Me.RadDatePickerEndDate, True)

        'Amounts
        If txtTotalBilling.Text <> "" Then

            If Not IsNumeric(txtTotalBilling.Text) Then

                InvalidBilling.Visible = True
                MiscFN.SetFocus(txtTotalBilling)
                Return False

            End If

        End If

        If txtTotalIncome.Text <> "" Then

            If Not IsNumeric(txtTotalIncome.Text) Then

                InvalidIncome.Visible = True
                MiscFN.SetFocus(txtTotalIncome)
                Return False

            End If

        End If

        Return True

    End Function

    Private Sub SetLookups()
        Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtOffice.ClientID & "&type=office');return false;")
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With DDAlertGrp
            .DataSource = oDD.ddAlertGroups()
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
        End With
    End Sub

    Private Sub ddGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGroups.SelectedIndexChanged
        LoadListboxes()
    End Sub

    Private Sub SortNotAllowListBox()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim sl As New System.Collections.SortedList
        Dim de As DictionaryEntry

        For I = Me.listNotAllowed.Items.Count - 1 To 0 Step -1
            sl.Add(Me.listNotAllowed.Items(I).Text, Me.listNotAllowed.Items(I).Value)
            Me.listNotAllowed.Items.Remove(Me.listNotAllowed.Items(I))
        Next I

        For Each de In sl
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            ThisItem.Value = de.Value
            ThisItem.Text = de.Key
            Me.listNotAllowed.Items.Add(ThisItem)
        Next

    End Sub

    Private Sub SortAllowListBox()
        Dim I As Integer
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim sl As New System.Collections.SortedList
        Dim de As DictionaryEntry

        For I = Me.listAllow.Items.Count - 1 To 0 Step -1
            sl.Add(Me.listAllow.Items(I).Text, Me.listAllow.Items(I).Value)
            Me.listAllow.Items.Remove(Me.listAllow.Items(I))
        Next I

        For Each de In sl
            ThisItem = New Telerik.Web.UI.RadListBoxItem
            ThisItem.Value = de.Value
            ThisItem.Text = de.Key
            Me.listAllow.Items.Add(ThisItem)
        Next

    End Sub

    Private Sub imgbtnAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnAdd.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listAllow.Items.Count - 1 To 0 Step -1
            If Me.listAllow.Items(I).Selected Then
                ThisItem = Me.listAllow.Items(I)
                Me.listAllow.Items.Remove(ThisItem)
                Me.listNotAllowed.Items.Add(ThisItem)
            End If
        Next I
        SortNotAllowListBox()

        If saveListboxAttachments() = False Then
            Me.ShowMessage("Error saving Media Attachments to database.")
            Exit Sub
        End If
        radGridAllMedia.Rebind()

    End Sub

    Private Sub imgbtnRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnRemove.Click
        Dim ThisItem As Telerik.Web.UI.RadListBoxItem
        Dim I As Integer

        For I = Me.listNotAllowed.Items.Count - 1 To 0 Step -1
            If Me.listNotAllowed.Items(I).Selected Then
                ThisItem = Me.listNotAllowed.Items(I)
                Me.listNotAllowed.Items.Remove(ThisItem)
                Me.listAllow.Items.Add(ThisItem)
            End If
        Next I
        SortAllowListBox()

        If saveListboxAttachments() = False Then
            Me.ShowMessage("Error saving Media Attachments to database.")
            Exit Sub
        End If
        radGridAllMedia.Rebind()
    End Sub

    Private Function getSelectedGroup(Optional ByVal grp As String = "") As String
        If grp = "" Then
            grp = ddGroups.SelectedValue
        End If

        Select Case grp
            Case "Production", "PRODUCTION"
                Return "JOB"

            Case "Internet", "INTERNET"
                Return "INT"

            Case "Magazine", "MAGAZINE"
                Return "MAG"

            Case "Newspaper", "NEWSPAPER"
                Return "NEW"

            Case "Outdoor", "OUTDOOR"
                Return "OOH"

            Case "Radio", "RADIO"
                Return "RAD"

            Case "TV"
                Return "TV"
        End Select
    End Function

    Dim labJT As System.Web.UI.WebControls.Label
    Private Sub radGridAllMedia_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles radGridAllMedia.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                labJT = e.Item.FindControl("lblOrderNum")
                If labJT.Text = "0" Then
                    labJT.Text = "&nbsp;"
                Else
                    labJT.Text = labJT.Text.PadLeft(6, "0")
                End If
                e.Item.Cells(9).Text = LoGlo.FormatDate(e.Item.Cells(9).Text)
        End Select
    End Sub

    Private Sub radGridAllMedia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles radGridAllMedia.SelectedIndexChanged
        Try
            Dim jobtemp As Job_Template = New Job_Template(Session("ConnString"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.radGridAllMedia.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    Dim type As String = gridDataItem.GetDataKeyValue("TYPE")
                    Dim num As String = gridDataItem.GetDataKeyValue("ORDER_NBR")
                    If type = "JOB" Then
                        Dim dt As DataTable = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), "", "", "", num, "", "", "", "", True, "", Me.IsClientPortal, Session("UserID"))
                        If dt.Rows.Count = 1 Then
                            Me.OpenWindow("", "Content.aspx?PageMode=Edit&JobNum=" & num & "&JobCompNum=" & dt.Rows(0)("JOB_COMPONENT_NBR") & "&NewComp=0")
                        Else
                            Me.OpenWindow("", "JobTemplate_Search.aspx?f=2&l=2&j=" & num)
                        End If

                    End If
                    gridDataItem.Selected = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub radGridAllMedia_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles radGridAllMedia.NeedDataSource
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"), Me.CmpIdentifier)

        radGridAllMedia.DataSource = cmp.GetAllAttachedMedia(cmp.CMP_IDENTIFIER)
    End Sub

    Private Sub PageLoadJS(ByVal str As String)
        Dim strTmp As String = String.Empty
        strTmp = "<script type=""text/javascript"">function init() { " & str & " } window.onload = init;</script>"
        If Not Page.IsStartupScriptRegistered("CMPAlert" & Now.Millisecond) Then
            Page.RegisterStartupScript("CMPAlert" & Now.Millisecond, strTmp)
        End If
    End Sub

    Private Sub rbType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbType.SelectedIndexChanged
        '1 - Overall
        '2 - Assigned to Jobs and Orders
        If rbType.SelectedValue = 1 Then
            CollapsablePanelMediaGrid.Visible = False
            CollapsablePanelAttachMedia.Visible = False
        Else
            CollapsablePanelMediaGrid.Visible = True
            CollapsablePanelAttachMedia.Visible = True
        End If
    End Sub

    Private Sub LBtnClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnClient.Click
        Me.OpenWindow("", "Campaign_Search.aspx?c=&d=&p=")
    End Sub

    Private Sub LBtnDivision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnDivision.Click
        Me.OpenWindow("", "Campaign_Search.aspx?c=" & Me.txtClient.Text & "&d=&p=")
    End Sub

    Private Sub LBtnProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnProduct.Click
        Me.OpenWindow("", "Campaign_Search.aspx?c=" & Me.txtClient.Text & "&d=" & Me.txtDivision.Text & "&p=")
    End Sub

    Private Sub LBtnCampaign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnCampaign.Click
        Me.OpenWindow("", "Campaign_Search.aspx?c=" & Me.txtClient.Text & "&d=" & Me.txtDivision.Text & "&p=" & Me.txtProduct.Text)
    End Sub

    Private Sub RadComboBoxLandingPage_DataBound(sender As Object, e As EventArgs) Handles RadComboBoxLandingPage.DataBound

        RadComboBoxLandingPage.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

    End Sub

    Private Sub RadComboBoxLandingPage_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLandingPage.SelectedIndexChanged

        If IsNumeric(e.Value) Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                TextBoxWebsiteName.Text = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientWebsite)
                                           Where Entity.ID = CInt(e.Value)
                                           Select Entity).FirstOrDefault.WebsiteName

            End Using

        Else

            TextBoxWebsiteName.Text = Nothing

        End If

    End Sub

    Private Sub CampaignPage_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        qs.CampaignIdentifier = Me.CmpIdentifier
        qs.CampaignCode = Me.CmpCode

        qs.Page = "Campaign.aspx"
        Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
        Deep.BuildJavascriptFromQueryString(qs, WebvantageLink, ClientPortalLink)
        Me.RadToolbarCampaign.FindItemByValue("CpPermaLink").Visible = False 'Deep.ClientPortalVisible
        If Me.IsClientPortal = True Then

            Me.RadToolbarCampaign.FindItemByValue("WvPermaLink").Visible = False
            Me.RadToolbarCampaign.FindItemByValue("CpPermaLink").Visible = False

        End If

    End Sub
End Class
