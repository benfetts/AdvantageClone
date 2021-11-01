Public Class Campaign_Setup
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _PostPeriodsList As Generic.IEnumerable(Of Object) = Nothing
    Private _CampaignDetailTypesList As Generic.IEnumerable(Of Object) = Nothing
    Private _SalesClassesList As Generic.IEnumerable(Of Object) = Nothing
    Private _DepartmentTeamsList As Generic.IEnumerable(Of Object) = Nothing

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

    Private Sub LoadCampaigns()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ASPxGridViewCampaigns.DataSource = (From Campaign In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Include("Office").Include("Client").Include("Division").Include("Product").ToList
                                                Select [ID] = Campaign.ID,
                                                       [Office] = If(Campaign.Office Is Nothing, "", Campaign.Office.ToString),
                                                       [Client] = If(Campaign.Client Is Nothing, "", Campaign.Client.ToString),
                                                       [Division] = If(Campaign.Division Is Nothing, "", Campaign.Division.ToString),
                                                       [Product] = If(Campaign.Product Is Nothing, "", Campaign.Product.ToString),
                                                       [Campaign] = If(Campaign Is Nothing, "", Campaign.ToString),
                                                       [Closed] = If(Campaign.IsClosed.GetValueOrDefault(0) = 0, "No", "Yes")).ToList

            ASPxGridViewCampaigns.KeyFieldName = "ID"
            ASPxGridViewCampaigns.DataBind()

            If ASPxGridViewCampaigns.Columns("ID") IsNot Nothing Then

                ASPxGridViewCampaigns.Columns("ID").Visible = False

            End If

        End Using

    End Sub
    Private Sub LoadSelectedCampaign()

        'objects
        Dim CampaignID As Integer = Nothing
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        If (ASPxGridViewCampaigns.Selection.Count = 1) Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    CampaignID = ASPxGridViewCampaigns.GetSelectedFieldValues("ID").First()

                Catch ex As Exception
                    CampaignID = 0
                End Try

                Try

                    Campaign = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Include("CampaignDetails").Include("Office").Include("Client").Include("Division").Include("Product")
                                Where Entity.ID = CampaignID
                                Select Entity).Single

                Catch ex As Exception
                    Campaign = Nothing
                End Try

                If Campaign IsNot Nothing Then

                    RadMultiPageCampaignDetails.Enabled = True
                    RadTabStripCampaignDetails.Enabled = True

                    CheckBoxIsClosed.Checked = Convert.ToBoolean(Campaign.IsClosed.GetValueOrDefault(0))

                    RadComboBoxOffice.SelectedValue = If(Campaign.OfficeCode Is Nothing, "0", Campaign.OfficeCode)
                    TextBoxClient.Text = Campaign.Client.ToString
                    TextBoxDivision.Text = If(Campaign.Division Is Nothing, "", Campaign.Division.ToString)
                    TextBoxProduct.Text = If(Campaign.Product Is Nothing, "", Campaign.Product.ToString)

                    TextBoxCode.Text = Campaign.Code
                    TextBoxName.Text = Campaign.Name

                    RadComboBoxAlertGroup.SelectedValue = If(Campaign.AlertGroupCode Is Nothing OrElse Campaign.AlertGroupCode = "", "0", Campaign.AlertGroupCode)

                    If Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.Overall Then

                        RadButtonAssignedToJobsAndOrders.Checked = False
                        RadButtonOverall.Checked = True

                        RadTabStripCampaignDetails.Tabs(2).Visible = False

                    ElseIf Campaign.CampaignType = AdvantageFramework.Database.Entities.CampaignTypes.AssignedToJobsAndOrders Then

                        RadButtonAssignedToJobsAndOrders.Checked = True
                        RadButtonOverall.Checked = False

                        RadTabStripCampaignDetails.Tabs(2).Visible = True

                    End If

                    RadDatePickerBeginningDate.SelectedDate = Campaign.StartDate
                    RadDatePickerEndingDate.SelectedDate = Campaign.EndDate

                    CheckBoxDirectResponse.Checked = Convert.ToBoolean(Campaign.IsDirectResponse.GetValueOrDefault(0))
                    CheckBoxInternet.Checked = Convert.ToBoolean(Campaign.IsInternetAds.GetValueOrDefault(0))
                    CheckBoxMagazine.Checked = Convert.ToBoolean(Campaign.IsMagazine.GetValueOrDefault(0))
                    CheckBoxNewspaper.Checked = Convert.ToBoolean(Campaign.IsNewspaper.GetValueOrDefault(0))
                    CheckBoxOther.Checked = Convert.ToBoolean(Campaign.IsOther.GetValueOrDefault(0))
                    CheckBoxOutOfHome.Checked = Convert.ToBoolean(Campaign.IsOutOfHome.GetValueOrDefault(0))
                    CheckBoxPrintCollateral.Checked = Convert.ToBoolean(Campaign.IsPrint.GetValueOrDefault(0))
                    CheckBoxRadio.Checked = Convert.ToBoolean(Campaign.IsRadio.GetValueOrDefault(0))
                    CheckBoxTelevision.Checked = Convert.ToBoolean(Campaign.IsTelevision.GetValueOrDefault(0))

                    TextBoxOther.Text = Campaign.OtherDescription

                    TextBoxComments.Text = Campaign.Comment

                Else

                    ClearCampaignInformation()

                End If

            End Using

        Else

            ClearCampaignInformation()

        End If

    End Sub
    Private Sub LoadCampaignDetails()

        'objects
        Dim CampaignDetails As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail) = Nothing
        Dim CampaignID As Integer = Nothing
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        If (ASPxGridViewCampaigns.Selection.Count = 1) Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    CampaignID = ASPxGridViewCampaigns.GetSelectedFieldValues("ID").First()

                Catch ex As Exception
                    CampaignID = 0
                End Try

                Try

                    Campaign = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Include("CampaignDetails").Include("Office").Include("Client").Include("Division").Include("Product")
                                Where Entity.ID = CampaignID
                                Select Entity).Single

                Catch ex As Exception
                    Campaign = Nothing
                End Try

                If Campaign IsNot Nothing Then

                    CampaignDetails = Campaign.CampaignDetails.OrderBy(Function(CampaignDetail) CampaignDetail.ID).ToList

                    RadGridCampaignDetails.DataSource = CampaignDetails

                    If RadGridCampaignDetails.Columns("UserCode") IsNot Nothing Then

                        If RadGridCampaignDetails.Columns("UserCode").Visible Then

                            RadGridCampaignDetails.Columns("UserCode").Visible = False

                        End If

                    End If

                    RadNumericTextBoxTotalBilling.Value = Campaign.BillingBudgetAmount
                    RadNumericTextBoxTotalIncome.Value = Campaign.IncomeBudgetAmount

                    LabelBillingMediaBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                    LabelBillingProductionBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                    LabelBillingCombinedBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))
                    LabelBillingTotalAllocatedAmount.Text = FormatCurrency(CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0)))

                    LabelIncomeMediaBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                    LabelIncomeProductionBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                    LabelIncomeCombinedBudgetAmount.Text = FormatCurrency(CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))
                    LabelIncomeTotalAllocatedAmount.Text = FormatCurrency(CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0)))

                Else

                    ClearCampaignInformation()

                End If

            End Using

        Else

            ClearCampaignInformation()

        End If

    End Sub
    Private Sub EnableOrDisableActions()

        RadToolbarButtonSave.Enabled = (ASPxGridViewCampaigns.Selection.Count = 1)

    End Sub
    Private Sub ClearCampaignInformation()

        'objects
        Dim CampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing
        Dim SelectedCampaignDetailItemsList As Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem) = Nothing
        Dim CampaignDetails As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail) = Nothing

        RadComboBoxOffice.SelectedValue = "0"
        TextBoxClient.Text = ""
        TextBoxDivision.Text = ""
        TextBoxProduct.Text = ""

        TextBoxCode.Text = ""
        TextBoxName.Text = ""

        RadComboBoxAlertGroup.SelectedValue = "0"

        RadButtonAssignedToJobsAndOrders.Checked = True
        RadButtonOverall.Checked = False

        RadDatePickerBeginningDate.SelectedDate = Nothing
        RadDatePickerEndingDate.SelectedDate = Nothing

        CheckBoxDirectResponse.Checked = False
        CheckBoxInternet.Checked = False
        CheckBoxMagazine.Checked = False
        CheckBoxNewspaper.Checked = False
        CheckBoxOther.Checked = False
        CheckBoxOutOfHome.Checked = False
        CheckBoxPrintCollateral.Checked = False
        CheckBoxRadio.Checked = False
        CheckBoxTelevision.Checked = False

        TextBoxOther.Text = ""

        TextBoxComments.Text = ""

        'CampaignDetails = New Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail)

        'DataGridViewCampaignDetails_CampaignDetails.DataSource = CampaignDetails

        'LabelCampaignDetails_BillingMediaBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_BillingProductionBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_BillingCombinedBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_BillingTotalAllocatedAmount.Text = FormatCurrency(0)

        'LabelCampaignDetails_IncomeMediaBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_IncomeProductionBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_IncomeCombinedBudgetAmount.Text = FormatCurrency(0)
        'LabelCampaignDetails_IncomeTotalAllocatedAmount.Text = FormatCurrency(0)

        'CampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)
        'SelectedCampaignDetailItemsList = New Generic.List(Of AdvantageFramework.Database.Classes.CampaignDetailItem)

        'DataGridViewRightSection_JobsAndMediaOrders.DataSource = SelectedCampaignDetailItemsList
        'DataGridViewLeftSection_AvailableJobsAndMediaOrders.DataSource = CampaignDetailItemsList

        RadMultiPageCampaignDetails.Enabled = False
        RadTabStripCampaignDetails.Enabled = False

    End Sub

#Region "  Form Event Handlers "

    Private Sub Campaign_Setup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxOffice.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext).ToList

                RadComboBoxAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).ToList

            End Using

        End If

        LoadCampaigns()

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ASPxGridViewCampaigns_SelectionChanged(sender As Object, e As System.EventArgs) Handles ASPxGridViewCampaigns.SelectionChanged

        If RadTabStripCampaignDetails.SelectedIndex = 0 Then

            LoadSelectedCampaign()

        ElseIf RadTabStripCampaignDetails.SelectedIndex = 1 Then

            LoadCampaignDetails()

        ElseIf RadTabStripCampaignDetails.SelectedIndex = 2 Then

            'LoadCampaignDetails()

        End If

        EnableOrDisableActions()

    End Sub
    Private Sub RadGridCampaignDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCampaignDetails.ItemDataBound

        'objects
        Dim RadComboBoxPostPeriod As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadComboBoxCampaignDetailType As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadComboBoxSalesClass As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadComboBoxDepartmentTeam As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactivePostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Dim InactiveSalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing
        Dim InactiveDepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

        If _SalesClassesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _SalesClassesList = (From SalesClass In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                     Select SalesClass.Code,
                                            SalesClass.Description).ToList

            End Using

        End If

        If _DepartmentTeamsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _DepartmentTeamsList = (From DepartmentTeam In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                        Select DepartmentTeam.Code,
                                               DepartmentTeam.Description).ToList

            End Using

        End If

        If _CampaignDetailTypesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _CampaignDetailTypesList = (From CampaignDetailType In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes))
                                            Select CampaignDetailType.Code,
                                                   CampaignDetailType.Description).ToList

            End Using

        End If

        If _PostPeriodsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _PostPeriodsList = (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext)
                                    Select New With {.Code = PostPeriod.Code}).ToList

            End Using

        End If

        Try

            RadComboBoxPostPeriod = DirectCast(e.Item.FindControl("RadComboBoxPostPeriod"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxPostPeriod Is Nothing Then

                RadComboBoxPostPeriod = DirectCast(e.Item.FindControl("RadComboBoxPostPeriodEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxPostPeriod IsNot Nothing Then

                RadComboBoxPostPeriod.DataSource = _PostPeriodsList

                RadComboBoxPostPeriod.DataBind()

                RadComboBoxPostPeriod.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From PostPeriod In _PostPeriodsList
                        Where PostPeriod.Code = e.Item.DataItem.PostPeriodCode
                        Select PostPeriod).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactivePostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, e.Item.DataItem.PostPeriodCode)

                            If InactivePostPeriod IsNot Nothing Then

                                RadComboBoxPostPeriod.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactivePostPeriod.Code & "*", InactivePostPeriod.Code))

                                RadComboBoxPostPeriod.SelectedValue = InactivePostPeriod.Code

                            End If

                        End Using

                    Else

                        RadComboBoxPostPeriod.SelectedValue = e.Item.DataItem.PostPeriodCode

                    End If

                End If

            End If

        Catch ex As Exception
            RadComboBoxPostPeriod = Nothing
        End Try

        Try

            RadComboBoxCampaignDetailType = DirectCast(e.Item.FindControl("RadComboBoxCampaignDetailType"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxCampaignDetailType Is Nothing Then

                RadComboBoxCampaignDetailType = DirectCast(e.Item.FindControl("RadComboBoxCampaignDetailTypeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxCampaignDetailType IsNot Nothing Then

                RadComboBoxCampaignDetailType.DataSource = _CampaignDetailTypesList

                RadComboBoxCampaignDetailType.DataBind()

                RadComboBoxCampaignDetailType.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    RadComboBoxPostPeriod.SelectedValue = e.Item.DataItem.CampaignDetailType

                End If

            End If

        Catch ex As Exception
            RadComboBoxCampaignDetailType = Nothing
        End Try


        Try

            RadComboBoxSalesClass = DirectCast(e.Item.FindControl("RadComboBoxSalesClass"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxSalesClass Is Nothing Then

                RadComboBoxSalesClass = DirectCast(e.Item.FindControl("RadComboBoxSalesClassEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxSalesClass IsNot Nothing Then

                RadComboBoxSalesClass.DataSource = _SalesClassesList

                RadComboBoxSalesClass.DataBind()

                RadComboBoxSalesClass.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From SalesClass In _SalesClassesList
                        Where SalesClass.Code = e.Item.DataItem.SalesClassCode
                        Select SalesClass).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveSalesClass = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, e.Item.DataItem.SalesClassCode)

                            If InactiveSalesClass IsNot Nothing Then

                                RadComboBoxSalesClass.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveSalesClass.Description & "*", InactiveSalesClass.Code))

                                RadComboBoxSalesClass.SelectedValue = InactiveSalesClass.Code

                            End If

                        End Using

                    Else

                        RadComboBoxSalesClass.SelectedValue = e.Item.DataItem.SalesClassCode

                    End If

                End If

            End If

        Catch ex As Exception
            RadComboBoxSalesClass = Nothing
        End Try


        Try

            RadComboBoxDepartmentTeam = DirectCast(e.Item.FindControl("RadComboBoxDepartmentTeam"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxDepartmentTeam Is Nothing Then

                RadComboBoxDepartmentTeam = DirectCast(e.Item.FindControl("RadComboBoxDepartmentTeamEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxDepartmentTeam IsNot Nothing Then

                RadComboBoxDepartmentTeam.DataSource = _DepartmentTeamsList

                RadComboBoxDepartmentTeam.DataBind()

                RadComboBoxDepartmentTeam.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From DepartmentTeam In _DepartmentTeamsList
                        Where DepartmentTeam.Code = e.Item.DataItem.DepartmentTeamCode
                        Select DepartmentTeam).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveDepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, e.Item.DataItem.DepartmentTeamCode)

                            If InactiveDepartmentTeam IsNot Nothing Then

                                RadComboBoxDepartmentTeam.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveDepartmentTeam.Description & "*", InactiveDepartmentTeam.Code))

                                RadComboBoxDepartmentTeam.SelectedValue = InactiveDepartmentTeam.Code

                            End If

                        End Using

                    Else

                        RadComboBoxDepartmentTeam.SelectedValue = e.Item.DataItem.DepartmentTeamCode

                    End If

                End If

            End If

        Catch ex As Exception
            RadComboBoxDepartmentTeam = Nothing
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
    Private Sub RadTabStripCampaignDetails_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripCampaignDetails.TabClick

        If RadTabStripCampaignDetails.SelectedIndex = 0 Then

            LoadSelectedCampaign()

        ElseIf RadTabStripCampaignDetails.SelectedIndex = 1 Then

            LoadCampaignDetails()

        ElseIf RadTabStripCampaignDetails.SelectedIndex = 2 Then

            'LoadCampaignDetails()

        End If

        EnableOrDisableActions()


    End Sub

#End Region

#End Region

End Class