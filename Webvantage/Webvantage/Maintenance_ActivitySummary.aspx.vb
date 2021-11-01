Public Class Maintenance_ActivitySummary
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _ActivityCompetitionList As Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition) = Nothing
    Private _CompetitionList As Generic.List(Of AdvantageFramework.Database.Entities.Competition) = Nothing
    Private _IsCRMUser As Boolean = False
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function FillObject() As AdvantageFramework.Database.Entities.Activity

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

        Try

            Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

            If Activity IsNot Nothing Then

                LoadEntity(Activity)

            Else

                Activity = New AdvantageFramework.Database.Entities.Activity

                LoadEntity(Activity)

            End If

        Catch ex As Exception
            Activity = Nothing
        End Try

        FillObject = Activity

    End Function
    Private Sub LoadEntity(ByVal Activity As AdvantageFramework.Database.Entities.Activity)

        If Activity IsNot Nothing Then

            Activity.LeadDate = RadDatePickerLeadDate.SelectedDate

            If RadComboBoxSource.SelectedValue <> "" Then

                Activity.SourceID = RadComboBoxSource.SelectedValue

            End If

            Activity.LastContactDate = RadDatePickerLastContactDate.SelectedDate
            Activity.SoldDate = RadDatePickerSoldDate.SelectedDate
            Activity.LostDate = RadDatePickerLostDate.SelectedDate
            Activity.Probability = RadNumericTextBoxProbability.Value

            If RadComboBoxRating.SelectedValue <> "" Then

                Activity.RatingID = RadComboBoxRating.SelectedValue

            End If

            Activity.CurrentProvider = TextBoxCurrentProvider.Text

        End If

    End Sub
    Private Sub LoadActivitySummary()

        Dim CRMActivitySummaryList As Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary) = Nothing
        Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

        CRMActivitySummaryList = New Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary)

        CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Alert.LoadByTypeIDAndClientAndDivisionAndProductCode(_DbContext, 11, _ClientCode, _DivisionCode, _ProductCode).ToList
                                        Select New AdvantageFramework.Database.Classes.CRMActivitySummary(_DbContext, Entity))

        CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(_DbContext, "C", _ClientCode, _DivisionCode, _ProductCode).ToList
                                        Select New AdvantageFramework.Database.Classes.CRMActivitySummary(_DbContext, Entity))

        If CRMActivitySummaryList.Count > 0 Then

            RadGridActivitySummary.DataSource = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate)

        Else

            RadGridActivitySummary.DataSource = CRMActivitySummaryList

        End If

        RadGridActivitySummary.DataBind()

        Try

            CRMActivitySummary = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate).First

            TextBoxLastActivityDate.Text = CRMActivitySummary.ActivityDate

        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadActivitySummaryCompetitors()

        If _ProductCode = "" OrElse IsNumeric(TextBoxActivityID.Text) = False Then

            _ActivityCompetitionList = Session("ActivitySummary_RadGridCompetitors")

        End If

        If _ActivityCompetitionList Is Nothing Then

            _ActivityCompetitionList = New Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                _ActivityCompetitionList.Clear()

                If IsNumeric(TextBoxActivityID.Text) Then

                    _ActivityCompetitionList = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByActivityID(_DbContext, TextBoxActivityID.Text).ToList

                End If

            End If

        End If

        RadGridCompetitors.DataSource = _ActivityCompetitionList

        RadGridCompetitors.MasterTableView.IsItemInserted = True

        RadGridCompetitors.DataBind()

        If _ProductCode = "" Then

            Session("ActivitySummary_RadGridCompetitors") = _ActivityCompetitionList

        End If

    End Sub
    Private Sub LoadActivitySummaryTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

        RowTotalOpportunity.Visible = CheckBoxIsNewBusiness.Checked

        If Product IsNot Nothing Then

            Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

            If Activity IsNot Nothing Then

                If Activity.LeadDate IsNot Nothing Then

                    RadDatePickerLeadDate.SelectedDate = Activity.LeadDate

                End If

                If Activity.SourceID IsNot Nothing Then

                    RadComboBoxSource.SelectedValue = Activity.SourceID

                End If

                If Activity.LastContactDate IsNot Nothing Then

                    RadDatePickerLastContactDate.SelectedDate = Activity.LastContactDate

                End If

                If Activity.SoldDate IsNot Nothing Then

                    RadDatePickerSoldDate.SelectedDate = Activity.SoldDate

                End If

                If Activity.LostDate IsNot Nothing Then

                    RadDatePickerLostDate.SelectedDate = Activity.LostDate

                End If

                RadNumericTextBoxProbability.Value = Activity.Probability

                If Activity.RatingID IsNot Nothing Then

                    RadComboBoxRating.SelectedValue = Activity.RatingID

                End If

                TextBoxCurrentProvider.Text = Activity.CurrentProvider

                TextBoxActivityID.Text = Activity.ID

            End If

            If CheckBoxIsNewBusiness.Checked Then

                LoadTotalOpportunity()

            End If

        End If

        LoadActivitySummaryCompetitors()

        LoadActivitySummary()

    End Sub
    Private Sub LoadTotalOpportunity()

        Dim TotalAmount As Decimal = 0
        Dim Contract As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

        Try

            Contract = (From Entity In AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)
                        Where Entity.IsInactive = False
                        Select Entity).ToList

            TotalAmount = Contract.Sum(Function(Entity) Entity.FeeIncentiveBonus.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeProjectHourly.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeRetainer.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeRoyalty.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.MediaCommission.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.ProductionCommission.GetValueOrDefault(0))


        Catch ex As Exception
            TotalAmount = 0
        End Try

        RadNumericTextBoxTotalOpportunity.Value = TotalAmount

    End Sub
    Private Sub LoadControlSettings()

        RadNumericTextBoxProbability.MaxLength = 3
        RadNumericTextBoxProbability.MinValue = 0
        RadNumericTextBoxProbability.MaxValue = 100

    End Sub
    Private Sub ResetDataSources()

        RadComboBoxSource.DataSource = AdvantageFramework.Database.Procedures.Source.LoadAllActive(_DbContext).ToList
        RadComboBoxSource.DataValueField = "ID"
        RadComboBoxSource.DataTextField = "Description"
        RadComboBoxSource.DataBind()
        RadComboBoxSource.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxRating.DataSource = AdvantageFramework.Database.Procedures.Rating.LoadAllActive(_DbContext).ToList
        RadComboBoxRating.DataValueField = "ID"
        RadComboBoxRating.DataTextField = "Description"
        RadComboBoxRating.DataBind()
        RadComboBoxRating.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ActivitySummary_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        _DbContext.Database.Connection.Open()

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller").ToString

        End If

        If Request.QueryString("ClientCode") IsNot Nothing Then

            _ClientCode = Request.QueryString("ClientCode").ToString

        End If

        If Request.QueryString("DivisionCode") IsNot Nothing Then

            _DivisionCode = Request.QueryString("DivisionCode").ToString

        End If

        If Request.QueryString("ProductCode") IsNot Nothing Then

            _ProductCode = Request.QueryString("ProductCode").ToString

        End If

    End Sub
    Private Sub Maintenance_ActivitySummary_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

        Me.PageTitle = "Activity Summary"

        RadToolBarButtonSave.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        RadDatePickerLeadDate.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadComboBoxSource.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        TextBoxLastActivityDate.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadDatePickerLastContactDate.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadDatePickerSoldDate.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadDatePickerLostDate.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadNumericTextBoxProbability.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadComboBoxRating.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        TextBoxCurrentProvider.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadNumericTextBoxTotalOpportunity.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        ButtonAddDiary.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadGridActivitySummary.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            LoadControlSettings()

            ResetDataSources()

            Try

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(_DbContext, _ClientCode)

            Catch ex As Exception
                Client = Nothing
            End Try

            If Client IsNot Nothing AndAlso Client.IsNewBusiness.GetValueOrDefault(0) = 1 Then

                CheckBoxIsNewBusiness.Checked = True

            Else

                CheckBoxIsNewBusiness.Checked = False

            End If

            Try

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

            Catch ex As Exception
                Product = Nothing
            End Try

            LoadActivitySummaryTab(Product)
        Else
            Dim eventArgument As String = IIf(Me.Request("__EVENTARGUMENT") = Nothing, String.Empty, Me.Request("__EVENTARGUMENT"))

            If (eventArgument = "Refresh") Then
                'LoadActivitySummaryCompetitors()
                'RadGridActivitySummary.Rebind()
                LoadActivitySummary()
            End If

        End If

    End Sub
    Private Sub Maintenance_ActivitySummary_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        _DbContext.Database.Connection.Close()

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarActivitySummary_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarActivitySummary.ButtonClick

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                Activity = FillObject()

                If Activity.IsEntityBeingAdded() Then

                    Activity.ClientCode = _ClientCode
                    Activity.DivisionCode = _DivisionCode
                    Activity.ProductCode = _ProductCode

                    Activity.CreatedByUserCode = _Session.UserCode
                    Activity.CreateDate = Now

                    If AdvantageFramework.Database.Procedures.Activity.Insert(_DbContext, Activity) Then

                        _ActivityCompetitionList = Session("ActivitySummary_RadGridCompetitors")

                        For Each Competition In _ActivityCompetitionList

                            If Competition.IsEntityBeingAdded() Then

                                ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                                ActivityCompetition.DbContext = _DbContext
                                ActivityCompetition.ActivityID = Activity.ID
                                ActivityCompetition.CompetitionID = Competition.CompetitionID

                                AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(_DbContext, ActivityCompetition)

                            End If

                        Next

                    End If

                Else

                    Activity.ModifiedByUserCode = _Session.UserCode
                    Activity.ModifiedDate = Now

                    AdvantageFramework.Database.Procedures.Activity.Update(_DbContext, Activity)

                End If

                Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx", True, True)

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

            Case RadToolBarButtonAddActivity.Value

                Me.OpenWindow("Add Activity", "Calendar_NewActivity.aspx?Caller=Maintenance_ActivitySummary&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

            Case RadToolBarButtonAddDiary.Value

                Me.OpenWindow("Diary Edit", "Maintenance_DiaryEdit.aspx?Caller=Maintenance_ActivitySummary&Mode=Add&AlertTypeID=11&AlertCategoryID=58&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode, 0, 0, False, False, "Refresh")

        End Select

    End Sub
    Private Sub RadGridCompetitors_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridCompetitors.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridCompetitors.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                If CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                    ActivityCompetition.CompetitionID = CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If IsNumeric(TextBoxActivityID.Text) = False Then

                            _ActivityCompetitionList = Session("ActivitySummary_RadGridCompetitors")

                            If _ActivityCompetitionList Is Nothing Then

                                _ActivityCompetitionList = New Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition)

                            End If

                            If _ActivityCompetitionList.Where(Function(Entity) Entity.CompetitionID = ActivityCompetition.CompetitionID).Any = True Then

                                Me.ShowMessage("Competitor has already been added.  Please choose another.")

                            Else

                                ErrorMessage = ActivityCompetition.ValidateEntity(IsValid)

                                If IsValid Then

                                    _ActivityCompetitionList.Add(ActivityCompetition)
                                    Session("ActivitySummary_RadGridCompetitors") = _ActivityCompetitionList

                                Else

                                    Me.ShowMessage(ErrorMessage)

                                End If

                            End If

                        Else

                            ActivityCompetition.DbContext = DbContext
                            ActivityCompetition.ActivityID = TextBoxActivityID.Text

                            Reload = AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                        End If

                    End Using

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If IsNumeric(TextBoxActivityID.Text) = False Then

                        _ActivityCompetitionList = Session("ActivitySummary_RadGridCompetitors")

                        RadComboBox = CType(e.Item.FindControl("RadComboBoxCompetitor"), Telerik.Web.UI.RadComboBox)

                        Try

                            ActivityCompetition = (From Entity In _ActivityCompetitionList
                                                   Where Entity.CompetitionID = RadComboBox.SelectedValue
                                                   Select Entity).Single

                        Catch ex As Exception
                            _ActivityCompetitionList = Nothing
                        End Try

                        _ActivityCompetitionList.Remove(ActivityCompetition)

                        Session("ActivitySummary_RadGridCompetitors") = _ActivityCompetitionList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ActivityCompetition = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If ActivityCompetition IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ActivityCompetition.Delete(DbContext, ActivityCompetition)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

            LoadActivitySummaryCompetitors()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridCompetitors_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCompetitors.ItemDataBound

        'objects
        Dim RadComboBoxCompetitor As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveCompetitor As AdvantageFramework.Database.Entities.Competition = Nothing

        If _CompetitionList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _CompetitionList = AdvantageFramework.Database.Procedures.Competition.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxCompetitor = DirectCast(e.Item.FindControl("RadComboBoxCompetitor"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxCompetitor Is Nothing Then

                RadComboBoxCompetitor = DirectCast(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxCompetitor IsNot Nothing Then

                RadComboBoxCompetitor.DataSource = (From Competition In _CompetitionList
                                                    Where Competition.IsInactive = False
                                                    Select Competition.ID,
                                                           [Description] = If(Competition.IsInactive = False, CStr(Competition.Description & " ").Trim, Competition.Description & "*")).ToList

                RadComboBoxCompetitor.DataBind()

                RadComboBoxCompetitor.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Competition In _CompetitionList
                        Where Competition.ID = e.Item.DataItem.CompetitionID
                        Select Competition).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveCompetitor = AdvantageFramework.Database.Procedures.Competition.LoadByID(DbContext, e.Item.DataItem.CompetitionID)

                            If InactiveCompetitor IsNot Nothing Then

                                RadComboBoxCompetitor.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveCompetitor.Description & "*", InactiveCompetitor.ID))

                                RadComboBoxCompetitor.SelectedValue = InactiveCompetitor.ID

                            End If

                        End Using

                    Else

                        RadComboBoxCompetitor.SelectedValue = e.Item.DataItem.CompetitionID

                    End If

                    RadComboBoxCompetitor.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxCompetitor = Nothing
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
    Private Sub RadGridActivitySummary_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridActivitySummary.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridActivitySummary.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "EditDiary"

                Me.OpenWindow("Diary Edit", "Maintenance_DiaryEdit.aspx?Mode=Update&AlertID=" & CurrentGridDataItem.GetDataKeyValue("AlertID"))

        End Select

        If Reload Then

            LoadActivitySummary()

        End If

    End Sub
    Private Sub RadGridActivitySummary_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridActivitySummary.ItemDataBound

        Dim ImageButtonEdit As System.Web.UI.WebControls.ImageButton = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            ImageButtonEdit = e.Item.FindControl("ImageButtonEdit")

            If ImageButtonEdit IsNot Nothing Then

                If e.Item.DataItem.ActivityType = "Diary" Then

                    ImageButtonEdit.Visible = True

                Else

                    ImageButtonEdit.Visible = False

                End If

            End If

        End If

    End Sub
    Private Sub ButtonAddDiary_Click(sender As Object, e As EventArgs) Handles ButtonAddDiary.Click

        Me.OpenWindow("Diary Edit", "Maintenance_DiaryEdit.aspx?Caller=Maintenance_ActivitySummary&Mode=Add&AlertTypeID=11&AlertCategoryID=58&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

    End Sub

    Private Sub ButtonAddActivity_Click(sender As Object, e As EventArgs) Handles ButtonAddActivity.Click

        Me.OpenWindow("Add Activity", "Calendar_NewActivity.aspx?Caller=Maintenance_ActivitySummary&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

    End Sub

#End Region

#End Region

End Class
