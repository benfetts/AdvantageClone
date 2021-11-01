Namespace Media.Presentation

    Public Class MediaPlanNewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _AddedFromMediaPlanTemplate As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanID As Integer
            Get
                MediaPlanID = _MediaPlanID
            End Get
        End Property
        Private ReadOnly Property AddedFromMediaPlanTemplate As Boolean
            Get
                AddedFromMediaPlanTemplate = _AddedFromMediaPlanTemplate
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadClientContacts()

            'objects
            Dim ClientCode As String = ""

            If ComboBoxForm_Client.HasASelectedValue Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue

                    ComboBoxForm_ClientContact.DataSource = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadAllActive(SecurityDbContext).OrderBy(Function(Entity) Entity.FullNameFML).Where(Function(Entity) Entity.ClientCode = ClientCode)

                End Using

            Else

                ComboBoxForm_ClientContact.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientContact)

            End If

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Divisions = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                     Where Division.ClientCode = ClientCode
                                     Select Division).ToList

                        ComboBoxForm_Division.DataSource = Divisions

                        If Divisions.Count = 1 Then

                            ComboBoxForm_Division.SelectedValue = Divisions(0).Code

                        End If

                    End Using

                End Using

            Else

                ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

            End If

            If ComboBoxForm_Division.SelectedValue = "-1" Then

                ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            End If

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Products = (From Product In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                    Where Product.ClientCode = ClientCode AndAlso
                                          Product.DivisionCode = DivisionCode
                                    Select Product).ToList

                        ComboBoxForm_Product.DataSource = Products

                        If Products.Count = 1 Then

                            ComboBoxForm_Product.SelectedValue = Products(0).Code

                        End If

                    End Using

                End Using

            Else

                ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

            End If

        End Sub
        Private Sub LoadCampaigns()

            'objects
            Dim ClientCode As String = String.Empty
            Dim DivisionCode As String = String.Empty
            Dim ProductCode As String = String.Empty
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

            End If

            If ComboBoxForm_Division.HasASelectedValue Then

                DivisionCode = ComboBoxForm_Division.GetSelectedValue

            End If

            If ComboBoxForm_Product.HasASelectedValue Then

                ProductCode = ComboBoxForm_Product.GetSelectedValue

            End If

            StartDate = DateEditForm_StartDate.EditValue
            EndDate = DateEditForm_EndDate.EditValue

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If String.IsNullOrWhiteSpace(ClientCode) = False Then

                    ComboBoxForm_Campaign.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(DbContext).Where(Function(Entity) ((Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode = ProductCode) OrElse
                                                                                                                                                               (Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode = DivisionCode AndAlso Entity.ProductCode Is Nothing) OrElse
                                                                                                                                                               (Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)) AndAlso (Entity.IsClosed Is Nothing OrElse Entity.IsClosed = 0)).ToList
                                                        Where Entity.CampaignType = 2 AndAlso
                                                              ((Entity.StartDate.HasValue = False OrElse Entity.EndDate.HasValue = False) OrElse
                                                               (StartDate >= Entity.StartDate.GetValueOrDefault(StartDate) AndAlso StartDate <= Entity.EndDate.GetValueOrDefault(EndDate)) OrElse
                                                               (EndDate >= Entity.StartDate.GetValueOrDefault(StartDate) AndAlso EndDate <= Entity.EndDate.GetValueOrDefault(EndDate)))
                                                        Select Entity.ID,
                                                               Entity.Code,
                                                               Entity.Name).ToList.Select(Function(Campaign) New With {.Code = Campaign.ID,
                                                                                                                       .Name = Campaign.Code & " - " & Campaign.Name}).ToList

                Else

                    ComboBoxForm_Campaign.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

                End If

            End Using

        End Sub
        Private Sub AddEstimatesByTemplate(MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

            'objects
            Dim MediaPlanClass As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
            Dim MediaPlanTemplateHeaderID As Integer = 0
            Dim MediaPlanTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanTemplateDetail) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim TotalGrossBudgetAmount As Decimal = 0
            Dim OrderNumber As Integer = 0

            _AddedFromMediaPlanTemplate = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaPlanClass = New MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, MediaPlan.ID)

                MediaPlanTemplateHeaderID = Me.ComboBoxForm_MediaPlanTemplate.GetSelectedValue()

                MediaPlanTemplateDetails = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateDetail)
                                            Where Entity.MediaPlanTemplateHeaderID = MediaPlanTemplateHeaderID
                                            Select Entity).ToList

                For Each MediaPlanTemplateDetail In MediaPlanTemplateDetails

                    Try

                        MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanTemplateDetail.MediaPlanEstimateTemplateID)

                        MediaPlanDetail = New AdvantageFramework.Database.Entities.MediaPlanDetail

                        MediaPlanDetail.MediaPlanDetailLevelLineDatas = New HashSet(Of Database.Entities.MediaPlanDetailLevelLineData)
                        MediaPlanDetail.MediaPlanDetailLevelLines = New HashSet(Of Database.Entities.MediaPlanDetailLevelLine)
                        MediaPlanDetail.MediaPlanDetailLevels = New HashSet(Of Database.Entities.MediaPlanDetailLevel)
                        MediaPlanDetail.MediaPlanDetailFields = New HashSet(Of Database.Entities.MediaPlanDetailField)
                        MediaPlanDetail.MediaPlanDetailLevelLineTags = New HashSet(Of Database.Entities.MediaPlanDetailLevelLineTag)
                        MediaPlanDetail.MediaPlanDetailSettings = New HashSet(Of Database.Entities.MediaPlanDetailSetting)
                        MediaPlanDetail.MediaPlanDetailChangeLogs = New HashSet(Of Database.Entities.MediaPlanDetailChangeLog)
                        MediaPlanDetail.DigitalResults = New HashSet(Of Database.Entities.DigitalResult)
                        MediaPlanDetail.MediaPlanDetailPackageDetails = New HashSet(Of Database.Entities.MediaPlanDetailPackageDetail)
                        MediaPlanDetail.MediaPlanDetailPackagePlacementNames = New HashSet(Of Database.Entities.MediaPlanDetailPackagePlacementName)

                        MediaPlanDetail.DbContext = DbContext ' _MediaPlan.DbContext

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

                        Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

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

                        MediaPlanDetail.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplate.ID

                        If MediaPlanClass.AddMediaPlanEstimate(MediaPlanDetail, OrderNumber) Then

                            MediaPlanClass.SelectMediaPlanEstimate(OrderNumber)

                            AdvantageFramework.Media.Presentation.AddEstimateLevelsLinesBudget(MediaPlanEstimateTemplate.ID, MediaPlanEstimateTemplate.Type, MediaPlanClass, Me.Session, MediaPlanDetail.GrossBudgetAmount, False)

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                Next

            End Using

        End Sub
        Private Sub LoadTemplates()

            'objects
            Dim ClientCode As String = String.Empty
            Dim DivisionCode As String = String.Empty
            Dim ProductCode As String = String.Empty
            Dim MediaPlanTemplateProducts As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanTemplateProduct) = Nothing
            Dim MediaPlanTemplateHeaderIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaPlanTemplateHeaders As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader) = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Product.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                ProductCode = ComboBoxForm_Product.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlanTemplateProducts = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateProduct)
                                                 Where Entity.ClientCode = ClientCode AndAlso
                                                       Entity.DivisionCode = DivisionCode AndAlso
                                                       Entity.ProductCode = ProductCode AndAlso
                                                       Entity.MediaPlanTemplateHeader.IsInactive = False).ToList

                    If MediaPlanTemplateProducts.Count > 0 Then

                        MediaPlanTemplateHeaderIDs = MediaPlanTemplateProducts.Select(Function(P) P.MediaPlanTemplateHeaderID).ToArray

                        MediaPlanTemplateHeaders = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)
                                                    Where MediaPlanTemplateHeaderIDs.Contains(Entity.ID) AndAlso
                                                          Entity.IsInactive = False
                                                    Select Entity).ToList

                        ComboBoxForm_MediaPlanTemplate.DataSource = (From Entity In MediaPlanTemplateHeaders
                                                                     Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity)).ToList

                        If MediaPlanTemplateProducts.Any(Function(Entity) Entity.IsDefault = True) Then

                            ComboBoxForm_MediaPlanTemplate.SelectedValue = MediaPlanTemplateProducts.Where(Function(Entity) Entity.IsDefault = True).First.MediaPlanTemplateHeaderID

                        End If

                    Else

                        MediaPlanTemplateHeaders = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)
                                                    Where Entity.IsInactive = False
                                                    Select Entity).ToList

                        ComboBoxForm_MediaPlanTemplate.DataSource = (From Entity In MediaPlanTemplateHeaders
                                                                     Select New AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate(Entity)).ToList

                    End If

                End Using

            Else

                ComboBoxForm_MediaPlanTemplate.DataSource = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
                ComboBoxForm_MediaPlanTemplate.SelectedIndex = 0

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef MediaPlanID As Integer = 0, Optional ByRef AddedFromMediaPlanTemplate As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanNewDialog As AdvantageFramework.Media.Presentation.MediaPlanNewDialog = Nothing

            MediaPlanNewDialog = New AdvantageFramework.Media.Presentation.MediaPlanNewDialog

            ShowFormDialog = MediaPlanNewDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                MediaPlanID = MediaPlanNewDialog.MediaPlanID
                AddedFromMediaPlanTemplate = MediaPlanNewDialog.AddedFromMediaPlanTemplate

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanNewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxForm_IsTemplate.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Methods.Modules.Media_MediaPlanning_Actions_EditTemplate, Me.Session.User)

            Me.SpellChecker.ShowSpellCheckCompleteMessage = False
            TextBoxForm_Comment.ShowSpellCheckCompleteMessage = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.Description)
                    ComboBoxForm_Client.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ClientCode)
                    ComboBoxForm_Division.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.DivisionCode)
                    ComboBoxForm_Product.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ProductCode)
                    ComboBoxForm_ClientContact.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ClientContactID)
                    ComboBoxForm_Campaign.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.CampaignID)
                    DateEditForm_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.StartDate)
                    DateEditForm_EndDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.EndDate)
                    NumericInputForm_GrossBudgetAmount.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.GrossBudgetAmount)
                    NumericInputForm_GrossBudgetAmount.Properties.MaxValue = 1.0E+16
                    NumericInputForm_GrossBudgetAmount.Properties.IsFloatValue = True

                    TextBoxForm_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.Comment)

                    CheckBoxForm_SyncEstimateSettings.Checked = False
                    CheckBoxForm_SyncFieldWidths.Checked = True

                    ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                    ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                    ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

                    ComboBoxForm_ClientContact.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientContact)
                    ComboBoxForm_Campaign.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

                    DateEditForm_StartDate.EditValue = CDate(Now.ToShortDateString)
                    DateEditForm_EndDate.EditValue = CDate(Now.ToShortDateString)

                    CheckBoxForm_IsTemplate.Checked = False

                    ComboBoxForm_Country.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.CountryID)
                    ComboBoxForm_Country.DataSource = DbContext.Countries.ToList

                    ComboBoxForm_MediaPlanTemplate.DataSource = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanTemplate.PlanTemplate)
                    ComboBoxForm_MediaPlanTemplate.SelectedIndex = 0

                End Using

            End Using

        End Sub
        Private Sub MediaPlanNewDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            TextBoxForm_Description.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Client_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            If Me.FormShown Then

                LoadDivisions()

                LoadClientContacts()

                LoadCampaigns()

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            If Me.FormShown Then

                LoadProducts()

                LoadCampaigns()

            End If

        End Sub
        Private Sub ComboBoxForm_Product_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Product.SelectedValueChanged

            If Me.FormShown Then

                LoadCampaigns()

                LoadTemplates()

            End If

        End Sub
        Private Sub DateEditForm_StartDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditForm_StartDate.EditValueChanged

            If Me.FormShown Then

                LoadCampaigns()

            End If

        End Sub
        Private Sub DateEditForm_EndDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditForm_EndDate.EditValueChanged

            If Me.FormShown Then

                LoadCampaigns()

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateEditForm_StartDate.EditValue > DateEditForm_EndDate.EditValue Then

                    ErrorMessage = "Please select a start date on or before the end date."

                End If

                If ErrorMessage = "" Then

                    If DateAdd(DateInterval.Month, 18, DateEditForm_StartDate.EditValue) < DateEditForm_EndDate.EditValue Then

                        ErrorMessage = "Please select a date range of 18 months or less."

                    End If

                End If

                If ErrorMessage = "" Then

                    TextBoxForm_Comment.CheckSpelling()

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Adding...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            MediaPlan = New AdvantageFramework.Database.Entities.MediaPlan

                            MediaPlan.DbContext = DbContext

                            MediaPlan.Description = TextBoxForm_Description.Text
                            'MediaPlan.IsApproved = False
                            MediaPlan.ClientCode = ComboBoxForm_Client.GetSelectedValue
                            MediaPlan.DivisionCode = ComboBoxForm_Division.GetSelectedValue
                            MediaPlan.ProductCode = ComboBoxForm_Product.GetSelectedValue
                            MediaPlan.ClientContactID = ComboBoxForm_ClientContact.GetSelectedValue
                            MediaPlan.CampaignID = ComboBoxForm_Campaign.GetSelectedValue
                            MediaPlan.StartDate = DateEditForm_StartDate.GetValue
                            MediaPlan.EndDate = DateEditForm_EndDate.GetValue
                            MediaPlan.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                            MediaPlan.Comment = TextBoxForm_Comment.Text
                            MediaPlan.SyncDetailSettings = CheckBoxForm_SyncEstimateSettings.Checked
                            MediaPlan.SyncFieldWidths = CheckBoxForm_SyncFieldWidths.Checked
                            MediaPlan.IsTemplate = CheckBoxForm_IsTemplate.Checked
                            MediaPlan.CountryID = ComboBoxForm_Country.GetSelectedValue
                            MediaPlan.MediaPlanTemplateHeaderID = ComboBoxForm_MediaPlanTemplate.GetSelectedValue

                            If AdvantageFramework.Database.Procedures.MediaPlan.Insert(DbContext, MediaPlan) Then

                                Me.ClearChanged()

                                _MediaPlanID = MediaPlan.ID

                                If ComboBoxForm_MediaPlanTemplate.HasASelectedValue Then

                                    AddEstimatesByTemplate(MediaPlan)

                                End If

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        End Using

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

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
        Private Sub CheckBoxForm_SyncEstimateSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_SyncEstimateSettings.CheckedChanged

            If CheckBoxForm_SyncEstimateSettings.Checked Then

                CheckBoxForm_SyncFieldWidths.Checked = True
                CheckBoxForm_SyncFieldWidths.Enabled = False

            Else

                CheckBoxForm_SyncFieldWidths.Enabled = True

            End If

        End Sub
        Private Sub ComboBoxForm_MediaPlanTemplate_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_MediaPlanTemplate.SelectedValueChanged

            If ComboBoxForm_MediaPlanTemplate.HasASelectedValue Then

                CheckBoxForm_SyncEstimateSettings.Enabled = False
                CheckBoxForm_SyncEstimateSettings.Checked = False

            Else

                CheckBoxForm_SyncEstimateSettings.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
