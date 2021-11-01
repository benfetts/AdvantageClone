Namespace Media.Presentation

    Public Class MediaPlanUpdateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanClass As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing
        Private _DateRangeWarningBypassed As Boolean = False
        Private _HasNoMediaPlanEstimates As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanClass = MediaPlan

        End Sub
        Private Sub New(ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan

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

            If ComboBoxForm_Client.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                                                           Where Division.ClientCode = ClientCode
                                                           Select Division

                    End Using

                End Using

            Else

                ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

            End If

            ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue Then

                ClientCode = ComboBoxForm_Client.GetSelectedValue
                DivisionCode = ComboBoxForm_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_Product.DataSource = From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False)
                                                          Where Product.ClientCode = ClientCode AndAlso
                                                                Product.DivisionCode = DivisionCode
                                                          Select Product

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
        Private Sub SetIsApprovedMediaPlanMode()

            TextBoxForm_Description.SecurityEnabled = False
            ComboBoxForm_Client.ReadOnly = True
            ComboBoxForm_Division.ReadOnly = True
            ComboBoxForm_Product.ReadOnly = True
            ComboBoxForm_ClientContact.ReadOnly = True
            DateEditForm_StartDate.ReadOnly = True
            DateEditForm_EndDate.ReadOnly = True
            NumericInputForm_GrossBudgetAmount.SecurityEnabled = False
            TextBoxForm_Comment.SecurityEnabled = False
            CheckBoxForm_SyncEstimateSettings.SecurityEnabled = False
            ButtonForm_Update.SecurityEnabled = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanUpdateDialog As AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog = Nothing

            MediaPlanUpdateDialog = New AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog(MediaPlan)

            ShowFormDialog = MediaPlanUpdateDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.Database.Entities.MediaPlan) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanUpdateDialog As AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog = Nothing

            MediaPlanUpdateDialog = New AdvantageFramework.Media.Presentation.MediaPlanUpdateDialog(MediaPlan)

            ShowFormDialog = MediaPlanUpdateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanUpdateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.SpellChecker.ShowSpellCheckCompleteMessage = False
            TextBoxForm_Comment.ShowSpellCheckCompleteMessage = False
            ComboBoxForm_Client.ReadOnly = True
            ComboBoxForm_Division.ReadOnly = True
            ComboBoxForm_Product.ReadOnly = True

            CheckBoxForm_IsTemplate.SecurityEnabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, Security.Methods.Modules.Media_MediaPlanning_Actions_EditTemplate, Me.Session.User)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.Description)
                    ComboBoxForm_Client.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ClientCode)
                    ComboBoxForm_Division.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.DivisionCode)
                    ComboBoxForm_Product.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ProductCode)
                    ComboBoxForm_ClientContact.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.ClientContactID)
                    ComboBoxForm_Campaign.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.CampaignID)
                    'DateEditForm_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.StartDate)
                    'DateEditForm_EndDate.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.EndDate)
                    NumericInputForm_GrossBudgetAmount.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.GrossBudgetAmount)
                    NumericInputForm_GrossBudgetAmount.Properties.MaxValue = 1.0E+16
                    NumericInputForm_GrossBudgetAmount.Properties.IsFloatValue = True

                    TextBoxForm_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.Comment)

                    ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)
                    ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                    ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

                    ComboBoxForm_ClientContact.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.ClientContact)
                    ComboBoxForm_Campaign.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

                    DateEditForm_StartDate.EditValue = CDate(Now.ToShortDateString)
                    DateEditForm_EndDate.EditValue = CDate(Now.ToShortDateString)

                    ComboBoxForm_Country.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlan.Properties.CountryID)
                    ComboBoxForm_Country.DataSource = DbContext.Countries.ToList

                    CheckBoxForm_SyncEstimateSettings.Enabled = False

                    If _MediaPlan IsNot Nothing Then

                        TextBoxForm_Description.Text = _MediaPlan.Description
                        ComboBoxForm_Client.SelectedValue = _MediaPlan.ClientCode
                        ComboBoxForm_Division.SelectedValue = _MediaPlan.DivisionCode
                        ComboBoxForm_Product.SelectedValue = _MediaPlan.ProductCode
                        ComboBoxForm_ClientContact.SelectedValue = _MediaPlan.ClientContactID
                        DateEditForm_StartDate.EditValue = _MediaPlan.StartDate
                        DateEditForm_EndDate.EditValue = _MediaPlan.EndDate
                        NumericInputForm_GrossBudgetAmount.EditValue = _MediaPlan.GrossBudgetAmount
                        TextBoxForm_Comment.Text = _MediaPlan.Comment
                        CheckBoxForm_SyncEstimateSettings.Checked = _MediaPlan.SyncDetailSettings
                        CheckBoxForm_IsInactive.Checked = _MediaPlan.IsInactive
                        CheckBoxForm_SyncFieldWidths.Checked = _MediaPlan.SyncFieldWidths
                        CheckBoxForm_IsTemplate.Checked = _MediaPlan.IsTemplate
                        ComboBoxForm_Country.SelectedValue = _MediaPlan.CountryID

                        If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Where(Function(Data) Data.OrderNumber IsNot Nothing OrElse Data.HasPendingOrders = True).Any Then

                            DateEditForm_StartDate.Enabled = False

                            DateEditForm_EndDate.Properties.MinValue = _MediaPlan.EndDate
                            DateEditForm_EndDate.Enabled = True

                        End If

                        LoadCampaigns()

                        ComboBoxForm_Campaign.SelectedValue = _MediaPlan.CampaignID

                        ComboBoxForm_Country.Enabled = (AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Any = False)

                        'If _MediaPlan.IsApproved Then

                        '    SetIsApprovedMediaPlanMode()

                        'End If

                    ElseIf _MediaPlanClass IsNot Nothing Then

                        TextBoxForm_Description.Text = _MediaPlanClass.Description
                        ComboBoxForm_Client.SelectedValue = _MediaPlanClass.ClientCode
                        ComboBoxForm_Division.SelectedValue = _MediaPlanClass.DivisionCode
                        ComboBoxForm_Product.SelectedValue = _MediaPlanClass.ProductCode
                        ComboBoxForm_ClientContact.SelectedValue = _MediaPlanClass.ClientContactID
                        DateEditForm_StartDate.EditValue = _MediaPlanClass.StartDate
                        DateEditForm_EndDate.EditValue = _MediaPlanClass.EndDate
                        NumericInputForm_GrossBudgetAmount.EditValue = _MediaPlanClass.GrossBudgetAmount
                        TextBoxForm_Comment.Text = _MediaPlanClass.Comment
                        CheckBoxForm_SyncEstimateSettings.Checked = _MediaPlanClass.SyncDetailSettings
                        CheckBoxForm_IsInactive.Checked = _MediaPlanClass.IsInactive
                        CheckBoxForm_SyncFieldWidths.Checked = _MediaPlanClass.SyncFieldWidths
                        CheckBoxForm_IsTemplate.Checked = _MediaPlanClass.IsTemplate
                        ComboBoxForm_Country.SelectedValue = _MediaPlan.CountryID

                        If _MediaPlanClass.HasMediaOrder Then

                            DateEditForm_StartDate.Enabled = False

                            DateEditForm_EndDate.Properties.MinValue = _MediaPlanClass.EndDate
                            DateEditForm_EndDate.Enabled = True

                        End If

                        If CheckBoxForm_SyncEstimateSettings.Checked Then

                            CheckBoxForm_SyncFieldWidths.Enabled = False

                        Else

                            CheckBoxForm_SyncFieldWidths.Enabled = True

                        End If

                        LoadCampaigns()

                        ComboBoxForm_Campaign.SelectedValue = _MediaPlanClass.CampaignID
                        ComboBoxForm_Country.Enabled = (AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLine.LoadByMediaPlanID(DbContext, _MediaPlanClass.ID).Any = False)

                        'If _MediaPlanClass.IsApproved Then

                        '    SetIsApprovedMediaPlanMode()

                        'End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to view does not exist anymore.")
                        Me.Close()

                    End If

                    If _MediaPlan IsNot Nothing Then

                        _HasNoMediaPlanEstimates = (AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Count = 0)

                    ElseIf _MediaPlanClass IsNot Nothing Then

                        _HasNoMediaPlanEstimates = (_MediaPlanClass.MediaPlanEstimates.Count = 0)

                    End If

                    If CheckBoxForm_SyncEstimateSettings.Checked Then

                        CheckBoxForm_SyncEstimateSettings.Enabled = True

                    Else

                        CheckBoxForm_SyncEstimateSettings.Enabled = _HasNoMediaPlanEstimates

                    End If

                End Using

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanUpdateDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            TextBoxForm_Description.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Client_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            LoadDivisions()

            LoadClientContacts()

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            LoadProducts()

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim ErrorMessage As String = Nothing
            Dim LevelWidths As Hashtable = Nothing
            Dim FieldWidths As Hashtable = Nothing
            Dim IsFirstPlanEstimate As Boolean = True
            Dim SyncFieldWidthsChanged As Boolean = False
            Dim LockMessage As String = Nothing

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

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")

                    Try

                        If _MediaPlan IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, _MediaPlan.ID, LockMessage) Then

                                    AdvantageFramework.WinForm.MessageBox.Show(LockMessage)

                                Else

                                    _MediaPlan.DbContext = DbContext

                                    _MediaPlan.Description = TextBoxForm_Description.Text
                                    '_MediaPlan.IsApproved = False
                                    _MediaPlan.ClientContactID = ComboBoxForm_ClientContact.GetSelectedValue
                                    _MediaPlan.CampaignID = ComboBoxForm_Campaign.GetSelectedValue
                                    _MediaPlan.StartDate = DateEditForm_StartDate.GetValue
                                    _MediaPlan.EndDate = DateEditForm_EndDate.GetValue
                                    _MediaPlan.StartDate = CDate(_MediaPlan.StartDate.ToShortDateString)
                                    _MediaPlan.EndDate = CDate(_MediaPlan.EndDate.ToShortDateString)
                                    _MediaPlan.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                                    _MediaPlan.Comment = TextBoxForm_Comment.Text
                                    _MediaPlan.SyncDetailSettings = CheckBoxForm_SyncEstimateSettings.Checked
                                    _MediaPlan.IsInactive = CheckBoxForm_IsInactive.Checked
                                    _MediaPlan.IsTemplate = CheckBoxForm_IsTemplate.Checked
                                    _MediaPlan.CountryID = ComboBoxForm_Country.GetSelectedValue

                                    If _MediaPlan.SyncFieldWidths <> CheckBoxForm_SyncFieldWidths.Checked Then

                                        SyncFieldWidthsChanged = True

                                    End If

                                    _MediaPlan.SyncFieldWidths = CheckBoxForm_SyncFieldWidths.Checked

                                    If AdvantageFramework.Database.Procedures.MediaPlan.Update(DbContext, _MediaPlan) Then

                                        Try

                                            For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Include("MediaPlanDetailLevels").Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines").Include("MediaPlanDetailLevels.MediaPlanDetailLevelLines.MediaPlanDetailLevelLineTags").ToList

                                                For Each MediaPlanDetailLevel In MediaPlanDetail.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate OrElse Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate).ToList

                                                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                                                        For Each MediaPlanDetailLevelLineTag In MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.ToList

                                                            If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate Then

                                                                If MediaPlanDetailLevelLineTag.StartDate < _MediaPlan.StartDate OrElse MediaPlanDetailLevelLineTag.StartDate > _MediaPlan.EndDate Then

                                                                    MediaPlanDetailLevelLine.Description = ""

                                                                    DbContext.UpdateObject(MediaPlanDetailLevelLine)

                                                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                                    Try

                                                                        DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                                    Catch ex As Exception
                                                                        MediaPlanDetailLevelLineTag = Nothing
                                                                    End Try

                                                                End If

                                                            ElseIf MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                                                                If MediaPlanDetailLevelLineTag.EndDate < _MediaPlan.StartDate OrElse MediaPlanDetailLevelLineTag.EndDate > _MediaPlan.EndDate Then

                                                                    MediaPlanDetailLevelLine.Description = ""

                                                                    DbContext.UpdateObject(MediaPlanDetailLevelLine)

                                                                    MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                                                    Try

                                                                        DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                                                    Catch ex As Exception
                                                                        MediaPlanDetailLevelLineTag = Nothing
                                                                    End Try

                                                                End If

                                                            End If

                                                        Next

                                                    Next

                                                Next

                                            Next

                                            For Each MediaPlanDetailLevelLineData In AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Where(Function(Entity) Entity.StartDate < _MediaPlan.StartDate OrElse Entity.StartDate > _MediaPlan.EndDate).ToList

                                                DbContext.DeleteEntityObject(MediaPlanDetailLevelLineData)

                                            Next

                                            If _MediaPlan.SyncFieldWidths AndAlso SyncFieldWidthsChanged Then

                                                For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Include("MediaPlanDetailLevels").Include("MediaPlanDetailFields").ToList

                                                    If IsFirstPlanEstimate Then

                                                        LevelWidths = New Hashtable
                                                        FieldWidths = New Hashtable

                                                    End If

                                                    For Each MediaPlanDetailLevel In MediaPlanDetail.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                                                        DbContext.UpdateObject(MediaPlanDetailLevel)

                                                        If IsFirstPlanEstimate Then

                                                            LevelWidths(MediaPlanDetailLevel.OrderNumber) = MediaPlanDetailLevel.Width

                                                        Else

                                                            If LevelWidths.ContainsKey(MediaPlanDetailLevel.OrderNumber) Then

                                                                MediaPlanDetailLevel.Width = LevelWidths(MediaPlanDetailLevel.OrderNumber)

                                                            End If

                                                        End If

                                                    Next

                                                    For Each MediaPlanDetailField In MediaPlanDetail.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea OrElse Entity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                                                        DbContext.UpdateObject(MediaPlanDetailField)

                                                        If IsFirstPlanEstimate Then

                                                            FieldWidths(MediaPlanDetailField.FieldID) = MediaPlanDetailField.Width

                                                        Else

                                                            MediaPlanDetailField.Width = FieldWidths(MediaPlanDetailField.FieldID)

                                                        End If

                                                    Next

                                                    If IsFirstPlanEstimate Then

                                                        IsFirstPlanEstimate = False

                                                    End If

                                                Next

                                            End If

                                            If _DateRangeWarningBypassed Then

                                                For Each MediaPlanDetail In AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanID(DbContext, _MediaPlan.ID).Include("MediaPlanDetailSettings").ToList

                                                    Try

                                                        MediaPlanDetailSetting = MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusWeeks.ToString)

                                                    Catch ex As Exception
                                                        MediaPlanDetailSetting = Nothing
                                                    End Try

                                                    If MediaPlanDetailSetting IsNot Nothing Then

                                                        DbContext.UpdateObject(MediaPlanDetailSetting)

                                                        MediaPlanDetailSetting.StringValue = ""

                                                    End If

                                                    Try

                                                        MediaPlanDetailSetting = MediaPlanDetail.MediaPlanDetailSettings.SingleOrDefault(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.HiatusMonths.ToString)

                                                    Catch ex As Exception
                                                        MediaPlanDetailSetting = Nothing
                                                    End Try

                                                    If MediaPlanDetailSetting IsNot Nothing Then

                                                        DbContext.UpdateObject(MediaPlanDetailSetting)

                                                        MediaPlanDetailSetting.StringValue = ""

                                                    End If

                                                Next

                                            End If

                                            DbContext.SaveChanges()

                                        Catch ex As Exception

                                        End Try

                                        Me.ClearChanged()

                                        Me.DialogResult = Windows.Forms.DialogResult.OK
                                        Me.Close()

                                    End If

                                End If

                            End Using

                        ElseIf _MediaPlanClass IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlan(DbContext, _MediaPlanClass.ID, LockMessage) Then

                                    AdvantageFramework.WinForm.MessageBox.Show(LockMessage)

                                Else

                                    _MediaPlanClass.Description = TextBoxForm_Description.Text
                                    '_MediaPlanClass.IsApproved = False
                                    _MediaPlanClass.ClientContactID = ComboBoxForm_ClientContact.GetSelectedValue
                                    _MediaPlanClass.CampaignID = ComboBoxForm_Campaign.GetSelectedValue
                                    _MediaPlanClass.StartDate = DateEditForm_StartDate.GetValue
                                    _MediaPlanClass.EndDate = DateEditForm_EndDate.GetValue
                                    _MediaPlanClass.StartDate = CDate(_MediaPlanClass.StartDate.ToShortDateString)
                                    _MediaPlanClass.EndDate = CDate(_MediaPlanClass.EndDate.ToShortDateString)
                                    _MediaPlanClass.GrossBudgetAmount = NumericInputForm_GrossBudgetAmount.GetValue
                                    _MediaPlanClass.Comment = TextBoxForm_Comment.Text
                                    _MediaPlanClass.SyncDetailSettings = CheckBoxForm_SyncEstimateSettings.Checked
                                    _MediaPlanClass.IsInactive = CheckBoxForm_IsInactive.Checked
                                    _MediaPlanClass.IsTemplate = CheckBoxForm_IsTemplate.Checked
                                    _MediaPlanClass.CountryID = ComboBoxForm_Country.GetSelectedValue

                                    If _MediaPlanClass.SyncFieldWidths <> CheckBoxForm_SyncFieldWidths.Checked Then

                                        SyncFieldWidthsChanged = True

                                    End If

                                    _MediaPlanClass.SyncFieldWidths = CheckBoxForm_SyncFieldWidths.Checked

                                    If _MediaPlanClass.SyncFieldWidths AndAlso SyncFieldWidthsChanged Then

                                        For Each MediaPlanEstimate In _MediaPlanClass.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

                                            If IsFirstPlanEstimate Then

                                                LevelWidths = New Hashtable
                                                FieldWidths = New Hashtable

                                            End If

                                            For Each MediaPlanDetailLevel In MediaPlanEstimate.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                                                If IsFirstPlanEstimate Then

                                                    LevelWidths(MediaPlanDetailLevel.OrderNumber) = MediaPlanDetailLevel.Width

                                                Else

                                                    If LevelWidths.ContainsKey(MediaPlanDetailLevel.OrderNumber) Then

                                                        MediaPlanDetailLevel.Width = LevelWidths(MediaPlanDetailLevel.OrderNumber)

                                                    End If

                                                End If

                                            Next

                                            For Each MediaPlanDetailField In MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea OrElse Entity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                                                If IsFirstPlanEstimate Then

                                                    FieldWidths(MediaPlanDetailField.FieldID) = MediaPlanDetailField.Width

                                                Else

                                                    MediaPlanDetailField.Width = FieldWidths(MediaPlanDetailField.FieldID)

                                                End If

                                            Next

                                            If IsFirstPlanEstimate Then

                                                IsFirstPlanEstimate = False

                                            End If

                                        Next

                                    End If

                                    If _DateRangeWarningBypassed Then

                                        For Each MediaPlanEstimate In _MediaPlanClass.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                                            MediaPlanEstimate.HiatusWeeks.Clear()
                                            MediaPlanEstimate.HiatusMonths.Clear()

                                            MediaPlanEstimate.SaveHiatusWeeks()
                                            MediaPlanEstimate.SaveHiatusMonths()

                                        Next

                                    End If

                                    Me.ClearChanged()

                                    Me.DialogResult = Windows.Forms.DialogResult.OK
                                    Me.Close()

                                End If

                            End Using

                        End If

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
        Private Sub DateEditForm_StartDate_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles DateEditForm_StartDate.Validating

            If Not _DateRangeWarningBypassed AndAlso ((_MediaPlan IsNot Nothing AndAlso IsDate(DateEditForm_StartDate.EditValue) AndAlso _MediaPlan.StartDate < DateEditForm_StartDate.EditValue) OrElse
                    (_MediaPlanClass IsNot Nothing AndAlso IsDate(DateEditForm_StartDate.EditValue) AndAlso _MediaPlanClass.StartDate < DateEditForm_StartDate.EditValue)) Then

                If AdvantageFramework.WinForm.MessageBox.Show("By changing this date range, any data that falls outside the date range will be deleted and also all hiatus settings.  Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                    If _MediaPlan IsNot Nothing Then

                        DateEditForm_StartDate.EditValue = _MediaPlan.StartDate

                    ElseIf _MediaPlanClass IsNot Nothing Then

                        DateEditForm_StartDate.EditValue = _MediaPlanClass.StartDate

                    End If

                    e.Cancel = True

                Else

                    _DateRangeWarningBypassed = True

                End If

            End If

        End Sub
        Private Sub DateEditForm_EndDate_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles DateEditForm_EndDate.Validating

            If Not _DateRangeWarningBypassed AndAlso ((_MediaPlan IsNot Nothing AndAlso IsDate(DateEditForm_EndDate.EditValue) AndAlso _MediaPlan.EndDate > DateEditForm_EndDate.EditValue) OrElse
                    (_MediaPlanClass IsNot Nothing AndAlso IsDate(DateEditForm_EndDate.EditValue) AndAlso _MediaPlanClass.EndDate > DateEditForm_EndDate.EditValue)) Then

                If AdvantageFramework.WinForm.MessageBox.Show("By changing this date range, any data that falls outside the date range will be deleted and also all hiatus settings.  Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                    If _MediaPlan IsNot Nothing Then

                        DateEditForm_EndDate.EditValue = _MediaPlan.EndDate

                    ElseIf _MediaPlanClass IsNot Nothing Then

                        DateEditForm_EndDate.EditValue = _MediaPlanClass.EndDate

                    End If

                    e.Cancel = True

                Else

                    _DateRangeWarningBypassed = True

                End If

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
        Private Sub CheckBoxForm_SyncEstimateSettings_CheckedChanging(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_SyncEstimateSettings.CheckedChanging

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If CheckBoxForm_SyncEstimateSettings.Checked Then

                    If _HasNoMediaPlanEstimates = False Then

                        If AdvantageFramework.WinForm.MessageBox.Show("You are about to unsync this media plan.  Once its changed it cannot be changed back.  Are you sure you want to unsync?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                            e.Cancel = True

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub CheckBoxForm_SyncEstimateSettings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_SyncEstimateSettings.CheckedChanged

            If CheckBoxForm_SyncEstimateSettings.Checked Then

                CheckBoxForm_SyncFieldWidths.Checked = True
                CheckBoxForm_SyncFieldWidths.Enabled = False

            Else

                CheckBoxForm_SyncFieldWidths.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
