Namespace Media.Presentation

    Public Class MediaPlanDetailEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        Private _CampaignLevelName As String = String.Empty
        Private _DoesHaveACampaignLevel As Boolean = False
        Private _HasCampaignLevelBeenDeleted As Boolean = False
        Private _MediaRequireCampaign As Boolean = False
        Private _MediaAutoBuyer As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan
            _MediaPlanEstimate = MediaPlanEstimate

        End Sub
        Private Sub LoadSalesClasses()

            'objects
            Dim MediaTypeCode As String = ""
            Dim MediaPlanEstimateTemplateProducts As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct) = Nothing
            Dim MediaPlanEstimateTemplateIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaPlanEstimateTemplates As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate) = Nothing

            If ComboBoxForm_MediaType.HasASelectedValue Then

                MediaTypeCode = ComboBoxForm_MediaType.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).Where(Function(Entity) Entity.SalesClassTypeCode = MediaTypeCode OrElse
                                                                                                                                                           Entity.SalesClassTypeCode Is Nothing OrElse
                                                                                                                                                           Entity.SalesClassTypeCode = "")

                    If ComboBoxForm_MediaType.HasASelectedValue AndAlso _MediaPlan IsNot Nothing AndAlso
                            String.IsNullOrWhiteSpace(_MediaPlan.ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_MediaPlan.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(_MediaPlan.ProductCode) = False Then

                        MediaTypeCode = ComboBoxForm_MediaType.GetSelectedValue

                        MediaPlanEstimateTemplateProducts = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateProduct)
                                                             Where Entity.ClientCode = _MediaPlan.ClientCode AndAlso
                                                                   Entity.DivisionCode = _MediaPlan.DivisionCode AndAlso
                                                                   Entity.ProductCode = _MediaPlan.ProductCode AndAlso
                                                                   Entity.MediaPlanEstimateTemplate.Type = MediaTypeCode AndAlso
                                                                   Entity.MediaPlanEstimateTemplate.IsInactive = False).ToList

                        If MediaPlanEstimateTemplateProducts.Count > 0 Then

                            MediaPlanEstimateTemplateIDs = MediaPlanEstimateTemplateProducts.Select(Function(P) P.MediaPlanEstimateTemplateID).ToArray

                            MediaPlanEstimateTemplates = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                                                          Where MediaPlanEstimateTemplateIDs.Contains(Entity.ID) AndAlso
                                                                Entity.IsInactive = False
                                                          Select Entity).ToList

                            SearchableComboBox_EstimateTemplate.DataSource = (From Entity In MediaPlanEstimateTemplates
                                                                              Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity)).Where(Function(Entity) Entity.HasDatas).ToList

                            If MediaPlanEstimateTemplateProducts.Any(Function(Entity) Entity.IsDefault = True) Then

                                SearchableComboBox_EstimateTemplate.SelectedValue = MediaPlanEstimateTemplateProducts.Where(Function(Entity) Entity.IsDefault = True).First.MediaPlanEstimateTemplateID

                            End If

                        Else

                            MediaPlanEstimateTemplates = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate)
                                                          Where Entity.Type = MediaTypeCode AndAlso
                                                                Entity.IsInactive = False
                                                          Select Entity).ToList

                            SearchableComboBox_EstimateTemplate.DataSource = (From Entity In MediaPlanEstimateTemplates
                                                                              Select New AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate(Entity)).Where(Function(Entity) Entity.HasDatas).ToList

                        End If

                    Else

                        SearchableComboBox_EstimateTemplate.DataSource = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
                        SearchableComboBox_EstimateTemplate.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect))

                    End If

                End Using

            Else

                ComboBoxForm_SalesClass.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            End If

            ComboBoxForm_SalesClass.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect))

        End Sub
        Private Sub LoadDemos()

            'objects
            Dim MediaType As String = String.Empty

            If ComboBoxForm_MediaType.HasASelectedValue Then

                MediaType = ComboBoxForm_MediaType.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SearchableComboBoxForm_Demo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByMediaDemoSourceIDAndType(DbContext, AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen, MediaType)
                                                              Where Entity.IsSystem = False
                                                              Select Entity).OrderBy(Function(MD) MD.Description).ToList

                End Using

            Else

                SearchableComboBoxForm_Demo.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaDemographic)

            End If

            SearchableComboBoxForm_Demo.SelectedValue = Nothing

        End Sub
        Private Sub LoadMediaPlanDetail(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            If MediaPlanEstimate IsNot Nothing Then

                ComboBoxForm_Campaign.SelectedValue = MediaPlanEstimate.CampaignID
                ColorPickerForm_Color.SelectedColor = System.Drawing.Color.FromArgb(MediaPlanEstimate.Color)
                TextBoxComment_Comment.Text = MediaPlanEstimate.Notes
                TextBoxForm_Name.Text = MediaPlanEstimate.Name
                LabelForm_EstimateIDData.Text = If(MediaPlanEstimate.ID = 0, "", MediaPlanEstimate.ID)
                SearchableComboBoxForm_Buyer.SelectedValue = MediaPlanEstimate.BuyerEmployeeCode
                NumericInputForm_GrossBudgetAmount.EditValue = MediaPlanEstimate.GrossBudgetAmount
                CheckBoxForm_IsCable.Checked = MediaPlanEstimate.IsCable
                CheckBoxForm_AllowCampaignLevel.Checked = MediaPlanEstimate.AllowCampaignLevel
                ComboBoxForm_PeriodType.SelectedValue = CInt(MediaPlanEstimate.PeriodType).ToString

            End If

        End Sub
        Private Sub SaveMediaPlanDetail(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim UpdateEstimateColor As Boolean = False

            If MediaPlanEstimate IsNot Nothing Then

                MediaPlanEstimate.CampaignID = ComboBoxForm_Campaign.GetSelectedValue

                If MediaPlanEstimate.Color <> ColorPickerForm_Color.SelectedColor.ToArgb Then

                    UpdateEstimateColor = True

                End If

                MediaPlanEstimate.Color = If(ColorPickerForm_Color.SelectedColor.ToArgb = -1, 0, ColorPickerForm_Color.SelectedColor.ToArgb)

                If UpdateEstimateColor Then

                    MediaPlanEstimate.UpdateMediaPlanDetailLevelLineDataColor()

                End If

                MediaPlanEstimate.Notes = TextBoxComment_Comment.Text
                MediaPlanEstimate.Name = TextBoxForm_Name.Text
                MediaPlanEstimate.BuyerEmployeeCode = SearchableComboBoxForm_Buyer.GetSelectedValue
                MediaPlanEstimate.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                MediaPlanEstimate.IsCable = CheckBoxForm_IsCable.Checked
                MediaPlanEstimate.AllowCampaignLevel = CheckBoxForm_AllowCampaignLevel.Checked
                MediaPlanEstimate.PeriodType = ComboBoxForm_PeriodType.GetSelectedValue
                MediaPlanEstimate.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen
                MediaPlanEstimate.MediaDemographicID = SearchableComboBoxForm_Demo.GetSelectedValue

                MediaPlanEstimate.MediaPlanEstimateTemplateID = SearchableComboBox_EstimateTemplate.GetSelectedValue

            End If

        End Sub
        Private Sub SaveMediaPlanDetail(ByVal MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail)

            If MediaPlanDetail IsNot Nothing Then

                MediaPlanDetail.CampaignID = ComboBoxForm_Campaign.GetSelectedValue
                MediaPlanDetail.Color = ColorPickerForm_Color.SelectedColor.ToArgb
                MediaPlanDetail.Notes = TextBoxComment_Comment.Text
                MediaPlanDetail.Name = TextBoxForm_Name.GetText
                MediaPlanDetail.BuyerEmployeeCode = SearchableComboBoxForm_Buyer.GetSelectedValue
                MediaPlanDetail.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                MediaPlanDetail.IsCable = CheckBoxForm_IsCable.Checked
                MediaPlanDetail.AllowCampaignLevel = CheckBoxForm_AllowCampaignLevel.Checked
                MediaPlanDetail.PeriodType = ComboBoxForm_PeriodType.GetSelectedValue
                MediaPlanDetail.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen
                MediaPlanDetail.MediaDemographicID = SearchableComboBoxForm_Demo.GetSelectedValue

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailEditDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailEditDialog = Nothing

            MediaPlanDetailEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailEditDialog(MediaPlan, MediaPlanEstimate)

            ShowFormDialog = MediaPlanDetailEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaBuyers As Generic.List(Of AdvantageFramework.Database.Entities.MediaBuyer) = Nothing
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim SuperTooltipInfo As DevComponents.DotNetBar.SuperTooltipInfo = Nothing
            Dim IsNewEstimate As Boolean = False

            Me.SpellChecker.ShowSpellCheckCompleteMessage = False
            TextBoxComment_Comment.ShowSpellCheckCompleteMessage = False

            If _MediaPlan IsNot Nothing Then

                ComboBoxForm_MediaType.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.SalesClassType)
                ComboBoxForm_SalesClass.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.SalesClassCode)
                ComboBoxForm_Campaign.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.CampaignID)
                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.Name)
                TextBoxComment_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.Notes)
                SearchableComboBoxForm_Buyer.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.BuyerEmployeeCode)
                ComboBoxForm_PeriodType.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.PeriodType)

                SearchableComboBoxForm_Buyer.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
                NumericInputForm_GrossBudgetAmount.Properties.MaxValue = 1.0E+16
                NumericInputForm_GrossBudgetAmount.Properties.IsFloatValue = True

                ComboBoxForm_MediaType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType)).Where(Function(EnumObject) EnumObject.Code <> "P").OrderBy(Function(EnumObject) EnumObject.Description).ToList
                ComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = True
                ComboBoxForm_SalesClass.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

                SearchableComboBoxForm_Demo.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetail.Properties.MediaDemographicID)
                SearchableComboBoxForm_Demo.HideValueMemberColumn = True

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_Campaign.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(_MediaPlan.DbContext).Where(Function(Entity) ((Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode = _MediaPlan.DivisionCode AndAlso Entity.ProductCode = _MediaPlan.ProductCode) OrElse
                                                                                                                                                                          (Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode = _MediaPlan.DivisionCode AndAlso Entity.ProductCode Is Nothing) OrElse
                                                                                                                                                                          (Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)) AndAlso (Entity.IsClosed Is Nothing OrElse Entity.IsClosed = 0)).ToList
                                                        Where Entity.CampaignType = 2 AndAlso
                                                              ((Entity.StartDate.HasValue = False OrElse Entity.EndDate.HasValue = False) OrElse
                                                               (_MediaPlan.StartDate >= Entity.StartDate.GetValueOrDefault(_MediaPlan.StartDate) AndAlso _MediaPlan.StartDate <= Entity.EndDate.GetValueOrDefault(_MediaPlan.EndDate)) OrElse
                                                               (_MediaPlan.EndDate >= Entity.StartDate.GetValueOrDefault(_MediaPlan.StartDate) AndAlso _MediaPlan.EndDate <= Entity.EndDate.GetValueOrDefault(_MediaPlan.EndDate)))
                                                        Select Entity.ID,
                                                               Entity.Code,
                                                               Entity.Name).ToList.Select(Function(Campaign) New With {.Code = Campaign.ID,
                                                                                                                       .Name = Campaign.Code & " - " & Campaign.Name}).ToList

                    MediaBuyers = DbContext.GetQuery(Of Database.Entities.MediaBuyer).Include("Employee").Where(Function(Entity) Entity.IsInactive = False).ToList

                    SearchableComboBoxForm_Buyer.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(MediaBuyers.Select(Function(Entity) Entity.Employee), Me.Session.AccessibleOfficeCodes, Me.Session.HasLimitedOfficeCodes, Nothing)
                    SearchableComboBoxViewForm_Buyer.AFActiveFilterString = "[Terminated] = False"

                    SearchableComboBoxForm_Demo.DataSource = AdvantageFramework.Database.Procedures.MediaDemographic.Load(DbContext).Where(Function(Entity) Entity.MediaDemoSourceID = -1).OrderBy(Function(Entity) Entity.Description).ToList

                End Using

                ComboBoxForm_MediaType.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect))
                ComboBoxForm_SalesClass.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect))
                ComboBoxForm_Campaign.SelectedValue = CStr(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect))

                IsNewEstimate = (_MediaPlanEstimate Is Nothing)

                If _MediaPlan.SyncDetailSettings Then

                    If _MediaPlanEstimate IsNot Nothing Then

                        MediaPlanEstimate = _MediaPlanEstimate

                    Else

                        If _MediaPlan.MediaPlanEstimates.Count > 0 Then

                            MediaPlanEstimate = _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).FirstOrDefault

                        End If

                    End If

                Else

                    MediaPlanEstimate = _MediaPlanEstimate

                End If

                If MediaPlanEstimate IsNot Nothing Then

                    If MediaPlanEstimate.IsLevelAndLinesLoaded = False Then

                        MediaPlanEstimate.CreateLevelsAndLinesDataTable()

                    End If

                    For Each DataColumn In MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                        If DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = AdvantageFramework.MediaPlanning.TagTypes.Campaign Then

                            _DoesHaveACampaignLevel = True
                            _CampaignLevelName = DataColumn.ColumnName
                            Exit For

                        End If

                    Next

                End If

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Agency.LoadMediaRequireCampaign(DataContext) Then

                        _MediaRequireCampaign = True

                    End If

                    If AdvantageFramework.Agency.LoadMediaAutoBuyer(DataContext) Then

                        If MediaBuyers.Any(Function(Entity) Entity.EmployeeCode = Me.Session.User.EmployeeCode AndAlso Entity.IsInactive = False) Then

                            Try

                                _MediaAutoBuyer = True

                                If IsNewEstimate Then

                                    SearchableComboBoxForm_Buyer.SelectedValue = Me.Session.User.EmployeeCode

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End Using

                SearchableComboBox_EstimateTemplate.HideValueMemberColumn = True
                SearchableComboBox_EstimateTemplate.ExtraComboBoxItem = WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None

                SuperTooltipInfo = New DevComponents.DotNetBar.SuperTooltipInfo

                SuperTooltipInfo.BodyText = "Check to auto add data for levels/lines."
                SuperTooltip.SetSuperTooltip(CheckBoxForm_Auto, SuperTooltipInfo)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub MediaPlanDetailEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If _MediaPlanEstimate Is Nothing Then

                Me.Text = "Add " & Me.Text

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

                ComboBoxForm_MediaType.ReadOnly = False
                ComboBoxForm_SalesClass.ReadOnly = False
                ComboBoxForm_Campaign.ReadOnly = False
                ComboBoxForm_PeriodType.SecurityEnabled = True
                ComboBoxForm_PeriodType.Enabled = False

                ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0").ToList

                SearchableComboBoxForm_Demo.SelectedValue = Nothing

                If _MediaPlan.CampaignID.GetValueOrDefault(0) > 0 Then

                    ComboBoxForm_Campaign.SelectedValue = _MediaPlan.CampaignID.Value

                End If

            Else

                Me.Text = "Edit " & Me.Text

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

                ComboBoxForm_MediaType.ReadOnly = True
                ComboBoxForm_SalesClass.ReadOnly = True
                ComboBoxForm_Campaign.ReadOnly = False

                ComboBoxForm_MediaType.SelectedValue = _MediaPlanEstimate.SalesClassTypeEnumObject.Code
                LoadSalesClasses()
                ComboBoxForm_SalesClass.SelectedValue = _MediaPlanEstimate.SalesClassCode
                SearchableComboBox_EstimateTemplate.SelectedValue = _MediaPlanEstimate.MediaPlanEstimateTemplateID

                If SearchableComboBox_EstimateTemplate.HasASelectedValue Then

                    SearchableComboBox_EstimateTemplate.ReadOnly = True

                End If

                If _MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    If _MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                        ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).ToList

                    Else

                        ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "4").ToList

                    End If

                Else

                    If _MediaPlanEstimate.SalesClassTypeEnumObject.Code = "O" Then

                        ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0").ToList

                    Else

                        ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "4" AndAlso Entity.Code <> "0").ToList

                    End If

                End If

                If _MediaPlanEstimate.DoesEstimateHaveData Then

                    ComboBoxForm_PeriodType.SecurityEnabled = False

                Else

                    ComboBoxForm_PeriodType.SecurityEnabled = True

                End If

                ComboBoxForm_PeriodType.Enabled = (_MediaPlanEstimate.DoesEstimateHaveAnyData = False)

                LoadMediaPlanDetail(_MediaPlanEstimate)

                LoadDemos()

                SearchableComboBoxForm_Demo.SelectedValue = _MediaPlanEstimate.MediaDemographicID

                If SearchableComboBoxForm_Buyer.HasASelectedValue = False AndAlso String.IsNullOrWhiteSpace(_MediaPlanEstimate.BuyerEmployeeCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _MediaPlanEstimate.BuyerEmployeeCode)

                        If Employee IsNot Nothing Then

                            SearchableComboBoxForm_Buyer.AddComboItemToExistingDataSource(Employee.ToString & "*", Employee.Code, False)

                            Try

                                SearchableComboBoxForm_Buyer.SelectedValue = _MediaPlanEstimate.BuyerEmployeeCode

                            Catch ex As Exception
                                SearchableComboBoxForm_Buyer.SelectedValue = Nothing
                            End Try

                        End If

                    End Using

                End If

            End If

            ButtonForm_Add.SecurityEnabled = True ' Not _MediaPlan.IsApproved
            TextBoxForm_Name.SecurityEnabled = True ' Not _MediaPlan.IsApproved
            TextBoxComment_Comment.SecurityEnabled = True ' Not _MediaPlan.IsApproved

            If _MediaPlan.SyncDetailSettings Then

                If _MediaPlan.MediaPlanEstimates.Count > 0 Then

                    ComboBoxForm_Campaign.SecurityEnabled = (_DoesHaveACampaignLevel = False)

                    CheckBoxForm_AllowCampaignLevel.SecurityEnabled = _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).All(Function(MPE) MPE.HasMediaOrder = False)

                Else

                    ComboBoxForm_Campaign.SecurityEnabled = True
                    CheckBoxForm_AllowCampaignLevel.SecurityEnabled = True

                End If

            Else

                If _MediaPlanEstimate IsNot Nothing Then

                    ComboBoxForm_Campaign.SecurityEnabled = (_DoesHaveACampaignLevel = False)

                    CheckBoxForm_AllowCampaignLevel.SecurityEnabled = (_MediaPlanEstimate.HasMediaOrder = False)

                Else

                    ComboBoxForm_Campaign.SecurityEnabled = True
                    CheckBoxForm_AllowCampaignLevel.SecurityEnabled = True

                End If

            End If

            ComboBoxForm_Campaign.Enabled = (CheckBoxForm_AllowCampaignLevel.Checked = False)

            If ComboBoxForm_Campaign.Enabled Then

                If _MediaRequireCampaign Then

                    ComboBoxForm_Campaign.SetRequired(True)

                End If

            End If

            Me.ClearChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim SalesClassTypeEnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim OrderNumber As Integer = 0
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                TextBoxComment_Comment.CheckSpelling()

                If CheckMappings(Me.Session, SearchableComboBox_EstimateTemplate.GetSelectedValue, ComboBoxForm_MediaType.GetSelectedValue) Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Adding...")

                    Try

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

                        MediaPlanDetail.DbContext = _MediaPlan.DbContext

                        MediaPlanDetail.SalesClassType = ComboBoxForm_MediaType.GetSelectedValue
                        MediaPlanDetail.SalesClassCode = ComboBoxForm_SalesClass.GetSelectedValue

                        SaveMediaPlanDetail(MediaPlanDetail)

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

                        MediaPlanDetail.MediaPlanEstimateTemplateID = SearchableComboBox_EstimateTemplate.GetSelectedValue

                        If _MediaPlan.AddMediaPlanEstimate(MediaPlanDetail, OrderNumber) Then

                            _MediaPlan.SelectMediaPlanEstimate(OrderNumber)

                            If SearchableComboBox_EstimateTemplate.HasASelectedValue Then

                                AddEstimateLevelsLinesBudget(SearchableComboBox_EstimateTemplate.SelectedValue, ComboBoxForm_MediaType.GetSelectedValue, _MediaPlan, Me.Session, Me.NumericInputForm_GrossBudgetAmount.GetValue, CheckBoxForm_Auto.Checked)

                            End If

                            Me.ClearChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing

            If Me.Validator Then

                TextBoxComment_Comment.CheckSpelling()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")

                Try

                    SaveMediaPlanDetail(_MediaPlanEstimate)

                    If SearchableComboBoxForm_Demo.UserEntryChanged Then

                        Try

                            MediaPlanDetailField = _MediaPlanEstimate.MediaPlanDetailFields.SingleOrDefault(Function(Entity) Entity.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)

                        Catch ex As Exception
                            MediaPlanDetailField = Nothing
                        End Try

                        If MediaPlanDetailField IsNot Nothing Then

                            If SearchableComboBoxForm_Demo.HasASelectedValue Then

                                MediaPlanDetailField.Caption = SearchableComboBoxForm_Demo.Text

                            Else

                                MediaPlanDetailField.Caption = "Demo 1"

                            End If

                        End If

                    End If

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

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
        Private Sub ComboBoxForm_MediaType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_MediaType.SelectedValueChanged

            'objects
            Dim OrderNumber As Integer = 1

            LoadSalesClasses()

            If ComboBoxForm_MediaType.HasASelectedValue Then

                If _MediaPlan.MediaPlanEstimates.Count > 0 Then

                    Do Until _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).All(Function(Entity) Entity.Name.StartsWith(Format(OrderNumber, "00000#")) = False)

                        OrderNumber += 1

                    Loop

                End If

                TextBoxForm_Name.Text = Format(OrderNumber, "00000#") & " - " & AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType), ComboBoxForm_MediaType.GetSelectedValue)

                If ComboBoxForm_MediaType.GetSelectedValue = "T" Then

                    CheckBoxForm_IsCable.Enabled = True

                Else

                    CheckBoxForm_IsCable.Enabled = False
                    CheckBoxForm_IsCable.Checked = False

                End If

                SearchableComboBoxForm_Demo.Enabled = False

                SearchableComboBoxForm_Demo.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaDemographic)

                If ComboBoxForm_MediaType.GetSelectedValue = "O" Then

                    ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0").ToList
                    ComboBoxForm_PeriodType.Enabled = True
                    ComboBoxForm_PeriodType.SelectedValue = "4"

                ElseIf ComboBoxForm_MediaType.GetSelectedValue = "R" OrElse ComboBoxForm_MediaType.GetSelectedValue = "T" Then

                    SearchableComboBoxForm_Demo.Enabled = True

                    LoadDemos()

                    ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0" AndAlso
                                                                                                                                                                                        Entity.Code <> "4").ToList
                    ComboBoxForm_PeriodType.Enabled = True
                    ComboBoxForm_PeriodType.SelectedValue = "2"

                    CheckBoxForm_Auto.Enabled = True

                ElseIf ComboBoxForm_MediaType.GetSelectedValue = "I" Then

                    ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0" AndAlso
                                                                                                                                                                                        Entity.Code <> "4").ToList
                    ComboBoxForm_PeriodType.Enabled = True
                    ComboBoxForm_PeriodType.SelectedValue = "3"

                ElseIf ComboBoxForm_MediaType.GetSelectedValue = "N" Then

                    ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0" AndAlso
                                                                                                                                                                                        Entity.Code <> "4").ToList
                    ComboBoxForm_PeriodType.Enabled = True
                    ComboBoxForm_PeriodType.SelectedValue = "1"

                Else

                    ComboBoxForm_PeriodType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.MediaPlanning.PeriodTypes)).Where(Function(Entity) Entity.Code <> "0" AndAlso
                                                                                                                                                                                        Entity.Code <> "4").ToList
                    ComboBoxForm_PeriodType.Enabled = True
                    ComboBoxForm_PeriodType.SelectedValue = "3"

                End If

            Else

                SearchableComboBoxForm_Demo.Enabled = False

                SearchableComboBoxForm_Demo.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaDemographic)

                CheckBoxForm_IsCable.Enabled = False
                CheckBoxForm_IsCable.Checked = False
                ComboBoxForm_PeriodType.Enabled = False

                CheckBoxForm_Auto.Checked = False
                CheckBoxForm_Auto.Enabled = False

            End If

        End Sub
        Private Sub CheckBoxForm_AllowCampaignLevel_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_AllowCampaignLevel.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If CheckBoxForm_AllowCampaignLevel.Checked Then

                    ComboBoxForm_Campaign.SelectedValue = "-1"
                    ComboBoxForm_Campaign.Enabled = False

                Else

                    If _DoesHaveACampaignLevel = False AndAlso _HasCampaignLevelBeenDeleted = False Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete all level campaign data?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            _MediaPlan.RemoveLevelLineColumn(_CampaignLevelName)
                            ComboBoxForm_Campaign.Enabled = True

                        End If

                    Else

                        ComboBoxForm_Campaign.Enabled = True

                    End If

                End If

                If ComboBoxForm_Campaign.Enabled Then

                    If _MediaRequireCampaign Then

                        ComboBoxForm_Campaign.SetRequired(True)

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBox_EstimateTemplate_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBox_EstimateTemplate.QueryPopUp

            For Each Column As DevExpress.XtraGrid.Columns.GridColumn In SearchableComboBox_EstimateTemplate.Properties.View.Columns

                If Column.FieldName <> AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Description.ToString Then

                    Column.Visible = False

                End If

            Next

        End Sub
        Private Sub ComboBoxForm_Source_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadDemos()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
