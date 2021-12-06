Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetEditViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property MediaBroadcastWorksheetID As Integer
            Get
                MediaBroadcastWorksheetID = _MediaBroadcastWorksheetID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Edit_Load(_MediaBroadcastWorksheetID)

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.Worksheet.MediaTypeCode = ComboBoxInformation_MediaType.GetSelectedValue
            _ViewModel.Worksheet.Name = TextBoxInformation_Name.Text
            _ViewModel.Worksheet.ClientCode = ComboBoxInformation_Client.GetSelectedValue
            _ViewModel.Worksheet.DivisionCode = ComboBoxInformation_Division.GetSelectedValue
            _ViewModel.Worksheet.ProductCode = ComboBoxInformation_Product.GetSelectedValue
            _ViewModel.Worksheet.SalesClassCode = ComboBoxInformation_SalesClass.GetSelectedValue
            _ViewModel.Worksheet.CampaignID = ComboBoxInformation_Campaign.GetSelectedValue
            _ViewModel.Worksheet.MediaPlanID = ComboBoxInformation_MediaPlan.GetSelectedValue
            _ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID = ComboBoxInformation_DateType.GetSelectedValue
            _ViewModel.Worksheet.MediaCalendarTypeID = ComboBoxInformation_Calendar.GetSelectedValue
            _ViewModel.Worksheet.StartDate = DateEditInformation_StartDate.EditValue
            _ViewModel.Worksheet.EndDate = DateEditInformation_EndDate.EditValue
            _ViewModel.Worksheet.Length = NumericInputInformation_Length.EditValue
            _ViewModel.Worksheet.CountryID = ComboBoxInformation_Country.GetSelectedValue
            _ViewModel.Worksheet.IsInactive = CheckBoxInformation_IsInactive.Checked
            _ViewModel.Worksheet.DefaultToLatestSharebook = CheckBoxInformation_DefaultToLatestSharebook.Visible AndAlso CheckBoxInformation_DefaultToLatestSharebook.Checked
            _ViewModel.Worksheet.NPRPrepopulateDates = CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Visible AndAlso CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Checked
            _ViewModel.Worksheet.ArePiggybacksOK = CheckBoxInformation_ArePiggybacksOK.Checked
            _ViewModel.Worksheet.ProrateSecondaryDemosToPrimary = CheckBoxInformation_ProrateSecondaryDemosToPrimary.Checked
            _ViewModel.Worksheet.PrimaryMediaDemographicID = SearchableComboBoxDemos_PrimaryDemo.GetSelectedValue
            _ViewModel.Worksheet.RatingsServiceID = ComboBoxDemos_Source.GetSelectedValue
            _ViewModel.Worksheet.Comment = TextBoxComments_Comment.GetText
            _ViewModel.Worksheet.IsGross = RadioButtonInformation_Gross.Checked

        End Sub
        Private Sub RefreshViewModel(RefreshData As Boolean)

            ButtonItemActions_Add.Visible = _ViewModel.AddVisible
            ButtonItemActions_Update.Visible = _ViewModel.UpdateVisible
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonItemDemos_Delete.Enabled = _ViewModel.SecondaryDemo_DeleteEnabled
            ButtonItemDemos_Cancel.Enabled = _ViewModel.SecondaryDemo_CancelEnabled

            ComboBoxInformation_MediaType.Enabled = _ViewModel.AddVisible
            ComboBoxInformation_Client.Enabled = _ViewModel.AddVisible
            ComboBoxInformation_Division.Enabled = _ViewModel.AddVisible
            ComboBoxInformation_Product.Enabled = _ViewModel.AddVisible
            ComboBoxInformation_SalesClass.Enabled = _ViewModel.AddVisible

            ComboBoxInformation_Country.Enabled = (_ViewModel.HasOrdersBeenCreated = False AndAlso _ViewModel.HasDataBeenEnteredInAnyMarketSchedules = False)

            ComboBoxInformation_DateType.Enabled = (_ViewModel.HasOrdersBeenCreated = False AndAlso _ViewModel.HasRevisionBeenCreatedInAnyMarketSchedules = False)
            ComboBoxInformation_Calendar.Enabled = (_ViewModel.HasOrdersBeenCreated = False AndAlso _ViewModel.HasRevisionBeenCreatedInAnyMarketSchedules = False)
            DateEditInformation_StartDate.Enabled = (_ViewModel.HasOrdersBeenCreated = False)
            NumericInputInformation_Length.Enabled = (_ViewModel.HasDataBeenEnteredInAnyMarketSchedules = False)
            CheckBoxInformation_ArePiggybacksOK.Enabled = (_ViewModel.HasOrdersBeenCreated = False)

            CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Enabled = _ViewModel.DefaultToLatestSharebookEnabled

            If _ViewModel.Worksheet.ID = 0 Then

                If _ViewModel.Worksheet.CountryID = AdvantageFramework.DTO.Countries.UnitedStates Then

                    ComboBoxDemos_Source.Enabled = True

                Else

                    ComboBoxDemos_Source.Enabled = False

                End If

            Else

                ComboBoxDemos_Source.Enabled = False

            End If

            SearchableComboBoxDemos_PrimaryDemo.Enabled = (_ViewModel.HasOrdersBeenCreated = False)
            DataGridViewDemos_SecondaryDemos.Enabled = _ViewModel.SecondaryDemoEnabled

            CheckBoxInformation_DefaultToLatestSharebook.Enabled = _ViewModel.DefaultToLatestSharebookEnabled
            CheckBoxInformation_ProrateSecondaryDemosToPrimary.Enabled = _ViewModel.ProrateSecondaryDemosToPrimaryEnabled
            RadioButtonInformation_Gross.Enabled = (_ViewModel.HasOrdersBeenCreated = False)
            RadioButtonInformation_Net.Enabled = (_ViewModel.HasOrdersBeenCreated = False)

            TabItemWorksheetDetails_MatchingTab.Visible = (_ViewModel.UserHasAccessToMatchingTab AndAlso _ViewModel.Worksheet.ID > 0)

            If _ViewModel.Worksheet.MediaCalendarTypeID = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

                DateEditInformation_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast
                DateEditInformation_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast

            Else

                DateEditInformation_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Default
                DateEditInformation_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Default

            End If

            If RefreshData Then

                ComboBoxInformation_MediaType.SelectedValue = _ViewModel.Worksheet.MediaTypeCode
                TextBoxInformation_Name.Text = _ViewModel.Worksheet.Name
                ComboBoxInformation_Client.SelectedValue = _ViewModel.Worksheet.ClientCode
                ComboBoxInformation_Division.SelectedValue = _ViewModel.Worksheet.DivisionCode
                ComboBoxInformation_Product.SelectedValue = _ViewModel.Worksheet.ProductCode
                ComboBoxInformation_SalesClass.SelectedValue = _ViewModel.Worksheet.SalesClassCode
                ComboBoxInformation_Campaign.SelectedValue = CInt(_ViewModel.Worksheet.CampaignID.GetValueOrDefault(-1)).ToString
                ComboBoxInformation_MediaPlan.SelectedValue = CInt(_ViewModel.Worksheet.MediaPlanID.GetValueOrDefault(-1)).ToString
                ComboBoxInformation_DateType.SelectedValue = CInt(_ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID).ToString
                ComboBoxInformation_Calendar.SelectedValue = CInt(_ViewModel.Worksheet.MediaCalendarTypeID).ToString
                DateEditInformation_StartDate.EditValue = _ViewModel.Worksheet.StartDate
                DateEditInformation_EndDate.EditValue = _ViewModel.Worksheet.EndDate
                NumericInputInformation_Length.EditValue = _ViewModel.Worksheet.Length
                CheckBoxInformation_IsInactive.Checked = _ViewModel.Worksheet.IsInactive
                ComboBoxInformation_Country.SelectedValue = CInt(_ViewModel.Worksheet.CountryID).ToString
                CheckBoxInformation_DefaultToLatestSharebook.Checked = _ViewModel.Worksheet.DefaultToLatestSharebook
                CheckBoxInformation_ArePiggybacksOK.Checked = _ViewModel.Worksheet.ArePiggybacksOK
                CheckBoxInformation_ProrateSecondaryDemosToPrimary.Checked = _ViewModel.Worksheet.ProrateSecondaryDemosToPrimary
                CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Checked = _ViewModel.Worksheet.NPRPrepopulateDates

                If _ViewModel.Worksheet.IsGross Then

                    RadioButtonInformation_Gross.Checked = True
                    RadioButtonInformation_Net.Checked = False

                Else

                    RadioButtonInformation_Gross.Checked = False
                    RadioButtonInformation_Net.Checked = True

                End If

                SearchableComboBoxDemos_PrimaryDemo.SelectedValue = CInt(_ViewModel.Worksheet.PrimaryMediaDemographicID.GetValueOrDefault(-1)).ToString
                DataGridViewDemos_SecondaryDemos.DataSource = _ViewModel.WorksheetSecondaryDemos

                ComboBoxDemos_Source.SelectedValue = CStr(_ViewModel.Worksheet.RatingsServiceID)

                TextBoxComments_Comment.Text = _ViewModel.Worksheet.Comment
                TextBoxComments_MediaPlanComments.Text = _ViewModel.Worksheet.MediaPlanComments

                If TabItemWorksheetDetails_MatchingTab.Visible Then

                    RefreshSpotMatching()

                End If

            End If

            DataGridViewDemos_SecondaryDemos.Tag = _ViewModel.Worksheet.RatingsServiceID

            CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Visible = (ComboBoxDemos_Source.SelectedValue = CInt(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico).ToString)
            CheckBoxInformation_DefaultToLatestSharebook.Visible = Not CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Visible

        End Sub
        Private Sub RefreshSpotMatching()

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            If _ViewModel.MediaBroadcastWorksheetSpotMatchingSettings IsNot Nothing AndAlso _ViewModel.MediaBroadcastWorksheetSpotMatchingSettings.Count = 1 Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.Media.SpotMatchingSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                    EntityAttribute = Nothing
                    Row = Nothing

                    Row = AdvantageFramework.WinForm.MVC.Presentation.Controls.GetRowAndInitialize(VerticalGridMatching_Settings, PropertyDescriptor, EntityAttribute)

                    If Row IsNot Nothing Then

                        RepositoryItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.CreateDefaultSubItem(Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.DTO.Media.SpotMatchingSetting), EntityAttribute)

                        If TypeOf RepositoryItem Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                            CType(RepositoryItem, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                        End If

                        VerticalGridMatching_Settings.RepositoryItems.Add(RepositoryItem)

                        Row.Properties.RowEdit = RepositoryItem

                    End If

                Next

            End If

            VerticalGridMatching_Settings.DataSource = _ViewModel.MediaBroadcastWorksheetSpotMatchingSettings

            VerticalGridMatching_Settings.ExpandAllRows()

            VerticalGridMatching_Settings.BestFit()

        End Sub
        Private Sub SetControlDataSources()

            ComboBoxInformation_MediaType.DataSource = _ViewModel.MediaTypes.ToList
            ComboBoxInformation_Client.DataSource = _ViewModel.Clients.ToList
            ComboBoxInformation_Division.DataSource = _ViewModel.Divisions.ToList
            ComboBoxInformation_Product.DataSource = _ViewModel.Products.ToList
            ComboBoxInformation_SalesClass.DataSource = _ViewModel.SalesClasses.ToList
            ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList
            ComboBoxInformation_MediaPlan.DataSource = _ViewModel.MediaPlans.ToList
            ComboBoxInformation_DateType.DataSource = _ViewModel.DateTypes.ToList
            ComboBoxInformation_Calendar.DataSource = _ViewModel.CalendarTypes.ToList
            SearchableComboBoxDemos_PrimaryDemo.DataSource = _ViewModel.MediaDemographics.ToList
            ComboBoxDemos_Source.DataSource = _ViewModel.RatingsServiceList.ToList
            ComboBoxInformation_Country.DataSource = _ViewModel.Countries.ToList

        End Sub
        Private Sub SetControlPropertySettings()

            ComboBoxInformation_MediaType.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.MediaTypeCode)
            TextBoxInformation_Name.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.Name)
            ComboBoxInformation_Client.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.ClientCode)
            ComboBoxInformation_Division.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.DivisionCode)
            ComboBoxInformation_Product.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.ProductCode)
            ComboBoxInformation_SalesClass.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.SalesClassCode)
            ComboBoxInformation_Campaign.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.CampaignID)
            ComboBoxInformation_MediaPlan.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.MediaPlanID)
            ComboBoxInformation_DateType.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.MediaBroadcastWorksheetDateTypeID)
            ComboBoxInformation_Calendar.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.MediaCalendarTypeID)
            DateEditInformation_StartDate.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.StartDate)
            DateEditInformation_EndDate.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.EndDate)
            ComboBoxDemos_Source.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.RatingsServiceID)
            TextBoxComments_Comment.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.Comment)
            ComboBoxInformation_Country.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.CountryID)

            NumericInputInformation_Length.Properties.MinValue = 0
            NumericInputInformation_Length.Properties.MaxValue = 999
            NumericInputInformation_Length.Properties.EditMask = "##0"

            SearchableComboBoxDemos_PrimaryDemo.SetPropertySettings(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet.Properties.PrimaryMediaDemographicID)

            SearchableComboBoxDemos_PrimaryDemo.HideValueMemberColumn = True

            DataGridViewDemos_SecondaryDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewDemos_SecondaryDemos.SetupForEditableGrid()

            DataGridViewDemos_SecondaryDemos.OptionsDetail.EnableMasterViewMode = False

            DataGridViewDemos_SecondaryDemos.OptionsView.ColumnAutoWidth = True

            DataGridViewDemos_SecondaryDemos.OptionsView.ShowColumnHeaders = False

        End Sub
        Private Sub AddNewRow(WorksheetSecondaryDemo As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)

            Dim ErrorMessage As String = Nothing

            If WorksheetSecondaryDemo IsNot Nothing Then

                DataGridViewDemos_SecondaryDemos.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                DataGridViewDemos_SecondaryDemos.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                DataGridViewDemos_SecondaryDemos.CurrentView.RefreshData()

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub HideOrShowDemoSource()

            If Me.FormShown Then

                If _ViewModel.Worksheet.MediaTypeCode = "R" Then

                    LabelDemos_Source.Visible = False
                    ComboBoxDemos_Source.Visible = False

                    LabelDemos_PrimaryDemo.Location = New System.Drawing.Point(4, 4)
                    SearchableComboBoxDemos_PrimaryDemo.Location = New System.Drawing.Point(110, 5)

                    DataGridViewDemos_SecondaryDemos.Location = New System.Drawing.Point(4, 32)
                    DataGridViewDemos_SecondaryDemos.Height = 367

                ElseIf _ViewModel.Worksheet.MediaTypeCode = "T" Then

                    LabelDemos_Source.Visible = True
                    ComboBoxDemos_Source.Visible = True

                    LabelDemos_PrimaryDemo.Location = New System.Drawing.Point(4, 32)
                    SearchableComboBoxDemos_PrimaryDemo.Location = New System.Drawing.Point(110, 33)

                    DataGridViewDemos_SecondaryDemos.Location = New System.Drawing.Point(4, 59)
                    DataGridViewDemos_SecondaryDemos.Height = 350

                End If

            End If

        End Sub
        Private Sub ReloadDemoSource()

            ComboBoxDemos_Source.DataSource = _ViewModel.RatingsServiceList.ToList

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef MediaBroadcastWorksheetID As Integer = 0) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetEditDialog As MediaBroadcastWorksheetEditDialog = Nothing

            MediaBroadcastWorksheetEditDialog = New MediaBroadcastWorksheetEditDialog(MediaBroadcastWorksheetID)

            ShowFormDialog = MediaBroadcastWorksheetEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                MediaBroadcastWorksheetID = MediaBroadcastWorksheetEditDialog.MediaBroadcastWorksheetID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDemos_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDemos_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage

            ButtonItemMatching_Defaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage
            ButtonItemMatching_SeparationSettings.Image = AdvantageFramework.My.Resources.EditImage

            TextBoxComments_MediaPlanComments.ReadOnly = True

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            TabControlForm_WorksheetDetails.SelectedTab = TabItemWorksheetDetails_InformationTab

            LoadViewModel()

            SetControlDataSources()

            RefreshViewModel(True)

            HideOrShowDemoSource()

            If _ViewModel.HasOrdersBeenCreated Then

                DateEditInformation_EndDate.Properties.MinValue = _ViewModel.Worksheet.EndDate

            End If

            If _ViewModel.MediaRequireCampaign Then

                ComboBoxInformation_Campaign.SetRequired(True)

            End If

            RibbonBarFilePanel_Actions.ResetCachedContentSize()

            RibbonBarFilePanel_Actions.Refresh()

            RibbonBarFilePanel_Actions.Width = RibbonBarFilePanel_Actions.GetAutoSizeWidth

            RibbonBarFilePanel_Actions.Refresh()

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                SaveViewModel()

                _Controller.Edit_Add(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    _MediaBroadcastWorksheetID = _ViewModel.Worksheet.ID

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonItemActions_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Update.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If _Controller.IsAnyMarketLockedByWorksheet(_MediaBroadcastWorksheetID, ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            Else

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                    SaveViewModel()

                    _Controller.Edit_Save(_ViewModel, ErrorMessage)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If String.IsNullOrWhiteSpace(ErrorMessage) Then

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDemos_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDemos_Delete.Click

            If DataGridViewDemos_SecondaryDemos.HasASelectedRow Then

                DataGridViewDemos_SecondaryDemos.CurrentView.CloseEditorForUpdating()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                SaveViewModel()

                _Controller.Edit_SecondaryDemoDelete(_ViewModel, DataGridViewDemos_SecondaryDemos.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo).ToList)

                RefreshViewModel(True)

                DataGridViewDemos_SecondaryDemos.CurrentView.RefreshData()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                _Controller.Edit_SecondaryDemoSelectionChanged(_ViewModel, DataGridViewDemos_SecondaryDemos.IsNewItemRow, DataGridViewDemos_SecondaryDemos.GetFirstSelectedRowDataBoundItem)

            End If

        End Sub
        Private Sub ButtonItemDemos_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDemos_Cancel.Click

            DataGridViewDemos_SecondaryDemos.CancelNewItemRow()

            _Controller.Edit_SecondaryDemoCancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemMatching_Defaults_Click(sender As Object, e As EventArgs) Handles ButtonItemMatching_Defaults.Click

            _Controller.Edit_RestoreDefaultMatchingSettings(_ViewModel, _ViewModel.Worksheet.MediaTypeCode, _ViewModel.Worksheet.ClientCode)

            VerticalGridMatching_Settings.SetUserEntryChanged()

            RefreshViewModel(True)

        End Sub
        Private Sub ButtonItemMatching_SeparationSettings_Click(sender As Object, e As EventArgs) Handles ButtonItemMatching_SeparationSettings.Click

            AdvantageFramework.Maintenance.Media.Presentation.TimeSeparationSettingsEditDialog.ShowFormDialog(_ViewModel.Worksheet.ID, AdvantageFramework.ViewModels.Maintenance.Media.TimeSeparationSettingViewModel.TimeSeparationSettingSource.Worksheet)

        End Sub
        Private Sub ComboBoxInformation_MediaType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_MediaType.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                'If ComboBoxInformation_MediaType.SelectedValue = "R" Then

                '    ComboBoxDemos_Source.SelectedValue = CStr(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen)

                'End If

                SaveViewModel()

                _Controller.Edit_MediaTypeChanged(_ViewModel)

                ComboBoxInformation_SalesClass.DataSource = _ViewModel.SalesClasses.ToList

                RefreshViewModel(True)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.SalesClasses.Count = 1 Then

                    ComboBoxInformation_SalesClass.SelectedValue = _ViewModel.SalesClasses(0).Value

                End If

                HideOrShowDemoSource()

            End If

        End Sub
        Private Sub ComboBoxInformation_Client_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_Client.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.Edit_LoadDivisions(_ViewModel, ComboBoxInformation_Client.GetSelectedValue)
                _Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                                               DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)

                ComboBoxInformation_Division.DataSource = _ViewModel.Divisions.ToList
                ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.Divisions.Count = 1 Then

                    ComboBoxInformation_Division.SelectedValue = _ViewModel.Divisions(0).Value

                End If

            End If

        End Sub
        Private Sub ComboBoxInformation_Division_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_Division.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.Edit_LoadProducts(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_Division.GetSelectedValue)
                '_Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                '							   DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)

                ComboBoxInformation_Product.DataSource = _ViewModel.Products.ToList
                'ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If _ViewModel.Products.Count = 1 Then

                    ComboBoxInformation_Product.SelectedValue = _ViewModel.Products(0).Value

                End If

            End If

        End Sub
        Private Sub ComboBoxInformation_Product_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_Product.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                '_Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                '								DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)
                _Controller.Edit_LoadMediaPlans(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_Division.GetSelectedValue, ComboBoxInformation_Product.GetSelectedValue)

                'ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList
                ComboBoxInformation_MediaPlan.DataSource = _ViewModel.MediaPlans.ToList

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxInformation_Calendar_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_Calendar.SelectedValueChanged

            'objects
            Dim [Continue] As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _MediaBroadcastWorksheetID > 0 AndAlso _ViewModel.ClearGoalGRPAndMarketScheduleSpotsData = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Changing the Calendar Type will clear Goal GRP and Market Schedule spot data" &
                                                                  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        [Continue] = True
                        _ViewModel.ClearGoalGRPAndMarketScheduleSpotsData = True

                    Else

                        [Continue] = False

                    End If

                End If

                If [Continue] Then

                    If ComboBoxInformation_Calendar.GetSelectedValue = AdvantageFramework.DTO.Media.CalendarTypes.Broadcast Then

                        DateEditInformation_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast
                        DateEditInformation_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast

                    Else
                        DateEditInformation_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Default
                        DateEditInformation_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Default

                    End If

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxInformation_Calendar.SelectedValue = CInt(_ViewModel.Worksheet.MediaCalendarTypeID).ToString

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub ComboBoxInformation_DateType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_DateType.SelectedValueChanged

            'objects
            Dim [Continue] As Boolean = True

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _MediaBroadcastWorksheetID > 0 AndAlso _ViewModel.ClearGoalGRPAndMarketScheduleSpotsData = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Changing the Date Type will clear Goal GRP and Market Schedule spot data." &
                                                                  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        [Continue] = True
                        _ViewModel.ClearGoalGRPAndMarketScheduleSpotsData = True

                    Else

                        [Continue] = False

                    End If

                End If

                If [Continue] = False Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxInformation_DateType.SelectedValue = CInt(_ViewModel.Worksheet.MediaBroadcastWorksheetDateTypeID).ToString

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Else

                    SaveViewModel()

                    '_Controller.Edit_DateTypeChanged(_ViewModel)

                End If

            End If

        End Sub
        Private Sub ComboBoxInformation_MediaPlan_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_MediaPlan.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                                               DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)

                ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList

                If ComboBoxInformation_MediaPlan.HasASelectedValue Then

                    If _ViewModel.Worksheet.ID > 0 Then

                        _Controller.Edit_MediaPlanChanged(_ViewModel, ComboBoxInformation_MediaPlan.SelectedValue)

                        If DateEditInformation_StartDate.EditValue <> _ViewModel.Worksheet.StartDate OrElse
                                DateEditInformation_EndDate.EditValue <> _ViewModel.Worksheet.EndDate Then

                            If _ViewModel.DateRangeWarningBypassed = False Then

                                If AdvantageFramework.WinForm.MessageBox.Show("By changing this date range, any data that falls outside the date range will be deleted and also all hiatus settings.  Do you want to continue?",
                                                                              AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                    _ViewModel.DateRangeWarningBypassed = True

                                End If

                            End If

                            If _ViewModel.DateRangeWarningBypassed Then

                                DateEditInformation_StartDate.EditValue = _ViewModel.Worksheet.StartDate
                                DateEditInformation_EndDate.EditValue = _ViewModel.Worksheet.EndDate

                            End If

                        End If

                    Else

                        _Controller.Edit_MediaPlanChanged(_ViewModel, ComboBoxInformation_MediaPlan.SelectedValue)

                        DateEditInformation_StartDate.EditValue = _ViewModel.Worksheet.StartDate
                        DateEditInformation_EndDate.EditValue = _ViewModel.Worksheet.EndDate

                    End If

                    TextBoxComments_MediaPlanComments.Text = _ViewModel.Worksheet.MediaPlanComments

                Else

                    _Controller.Edit_MediaPlanChanged(_ViewModel, 0)
                    TextBoxComments_MediaPlanComments.Text = String.Empty

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ComboBoxInformation_Country_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxInformation_Country.SelectedValueChanged

            'objects
            Dim [Continue] As Boolean = False

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If (SearchableComboBoxDemos_PrimaryDemo.SelectedValue IsNot Nothing AndAlso SearchableComboBoxDemos_PrimaryDemo.SelectedValue <> "-1") OrElse (DataGridViewDemos_SecondaryDemos.CurrentView.DataRowCount > 0) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Warning, by changing country, all demographic settings will be erased. Do you want to continue?",
                                                                  AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        [Continue] = True

                    End If

                Else

                    [Continue] = True

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    If ComboBoxInformation_Country.SelectedValue = "2" Then

                        ComboBoxDemos_Source.SelectedValue = "3"

                    ElseIf ComboBoxInformation_Country.SelectedValue = "3" Then

                        ComboBoxDemos_Source.SelectedValue = "4"

                    ElseIf ComboBoxInformation_Country.SelectedValue = CInt(AdvantageFramework.DTO.Countries.PuertoRico).ToString Then

                        ComboBoxDemos_Source.SelectedValue = CInt(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.NielsenPuertoRico).ToString
                        CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Checked = True

                    Else

                        ComboBoxDemos_Source.SelectedValue = "1"

                    End If

                    SearchableComboBoxDemos_PrimaryDemo.SelectedValue = Nothing

                    SaveViewModel()

                    _Controller.Edit_CountryChanged(_ViewModel)

                    ReloadDemoSource()

                    If ComboBoxDemos_Source.SelectedIndex < 0 Then

                        ComboBoxDemos_Source.SelectedIndex = 0

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    RefreshViewModel(False)

                    DataGridViewDemos_SecondaryDemos.CurrentView.RefreshData()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    ComboBoxInformation_Country.SelectedValue = CInt(_ViewModel.Worksheet.CountryID).ToString

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DateEditInformation_StartDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditInformation_StartDate.EditValueChanged

            'objects
            Dim [Continue] As Boolean = True
            Dim CampaignID As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.Worksheet.ID > 0 AndAlso _ViewModel.DateRangeWarningBypassed = False AndAlso DateEditInformation_StartDate.EditValue > _ViewModel.Worksheet.StartDate Then

                    If AdvantageFramework.WinForm.MessageBox.Show("By shortening the date range, any scheduling outside the new dates will be deleted.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DateEditInformation_StartDate.EditValue = DateEditInformation_StartDate.OldEditValue

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        [Continue] = False

                    Else

                        _ViewModel.DateRangeWarningBypassed = True

                    End If

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    CampaignID = ComboBoxInformation_Campaign.GetSelectedValue

                    _Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                                                   DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)

                    ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList

                    If CampaignID > 0 AndAlso _ViewModel.Campaigns IsNot Nothing AndAlso
                            _ViewModel.Campaigns.Any(Function(Entity) Entity.Value = CampaignID) Then

                        ComboBoxInformation_Campaign.SelectedValue = CampaignID.ToString

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub DateEditInformation_EndDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditInformation_EndDate.EditValueChanged

            'objects
            Dim [Continue] As Boolean = True
            Dim CampaignID As Integer = 0

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _ViewModel.Worksheet.ID > 0 AndAlso _ViewModel.DateRangeWarningBypassed = False AndAlso DateEditInformation_EndDate.EditValue < _ViewModel.Worksheet.EndDate Then

                    If AdvantageFramework.WinForm.MessageBox.Show("By shortening the date range, any scheduling outside the new dates will be deleted.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

                        DateEditInformation_StartDate.EditValue = DateEditInformation_StartDate.OldEditValue

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        [Continue] = False

                    Else

                        _ViewModel.DateRangeWarningBypassed = True

                    End If

                End If

                If [Continue] Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    CampaignID = ComboBoxInformation_Campaign.GetSelectedValue

                    _Controller.Edit_LoadCampaigns(_ViewModel, ComboBoxInformation_Client.GetSelectedValue, ComboBoxInformation_MediaPlan.GetSelectedValue,
                                                   DateEditInformation_StartDate.GetValue, DateEditInformation_EndDate.GetValue)

                    ComboBoxInformation_Campaign.DataSource = _ViewModel.Campaigns.ToList

                    If CampaignID > 0 AndAlso _ViewModel.Campaigns IsNot Nothing AndAlso
                            _ViewModel.Campaigns.Any(Function(Entity) Entity.Value = CampaignID) Then

                        ComboBoxInformation_Campaign.SelectedValue = CampaignID.ToString

                    End If

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            End If

        End Sub
        Private Sub TabControlForm_WorksheetDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_WorksheetDetails.SelectedTabChanged

            RibbonBarFilePanel_Demos.Visible = e.NewTab.Equals(TabItemWorksheetDetails_DemosTab)
            RibbonBarFilePanel_Matching.Visible = e.NewTab.Equals(TabItemWorksheetDetails_MatchingTab)

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDemos_SecondaryDemos.SelectionChangedEvent

            _Controller.Edit_SecondaryDemoSelectionChanged(_ViewModel, DataGridViewDemos_SecondaryDemos.IsNewItemRow, DataGridViewDemos_SecondaryDemos.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewDemos_SecondaryDemos.InitNewRowEvent

            _Controller.Edit_SecondaryDemoInitNewRowEvent(_ViewModel)
            DataGridViewDemos_SecondaryDemos.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo.Properties.MediaBroadcastWorksheetID.ToString, _MediaBroadcastWorksheetID)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewDemos_SecondaryDemos.QueryPopupNeedDatasourceEvent

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo.Properties.MediaDemographicID.ToString Then

                Datasource = _Controller.Edit_LoadSecondaryMediaDemographics(_ViewModel, ComboBoxInformation_MediaType.GetSelectedValue, SearchableComboBoxDemos_PrimaryDemo.GetSelectedValue, ComboBoxDemos_Source.GetSelectedValue)
                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewDemos_SecondaryDemos.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo.Properties.MediaDemographicID.ToString Then

                Datasource = _ViewModel.MediaDemographics.ToList

            End If

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewDemos_SecondaryDemos.ShowingEditorEvent

            If DataGridViewDemos_SecondaryDemos.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo.Properties.MediaDemographicID.ToString Then

                e.Cancel = (DataGridViewDemos_SecondaryDemos.IsNewItemRow = False)

            End If

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewDemos_SecondaryDemos.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.Edit_SecondaryDemoValidateEntity(e.Row, e.Valid)

                If DataGridViewDemos_SecondaryDemos.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewDemos_SecondaryDemos.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewDemos_SecondaryDemos.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewDemos_SecondaryDemos.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.Edit_SecondaryDemoValidateProperty(FocusedRow, DataGridViewDemos_SecondaryDemos.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewDemos_SecondaryDemos_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDemos_SecondaryDemos.CellValueChangedEvent

            If DataGridViewDemos_SecondaryDemos.IsNewItemRow() AndAlso e.Column.FieldName = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo.Properties.MediaDemographicID.ToString Then

                DirectCast(DataGridViewDemos_SecondaryDemos.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo).MediaDemographicCode = _Controller.Edit_GetRepositoryMediaDemographicCode(_ViewModel, e.Value)
                DirectCast(DataGridViewDemos_SecondaryDemos.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo).MediaDemographicDescription = _Controller.Edit_GetRepositoryMediaDemographicDescription(_ViewModel, e.Value)

            End If

        End Sub
        Private Sub SearchableComboBoxDemos_PrimaryDemo_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBoxDemos_PrimaryDemo.QueryPopUp

            SearchableComboBoxDemos_PrimaryDemo.DataSource = _Controller.Edit_LoadPrimaryMediaDemographics(_ViewModel, ComboBoxInformation_MediaType.GetSelectedValue, ComboBoxDemos_Source.GetSelectedValue)

            SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.ID.ToString).Visible = False

            If _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Group.ToString).Visible = False
                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Category.ToString).Visible = False

            ElseIf _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Group.ToString).Visible = True
                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Category.ToString).Visible = True

            ElseIf _ViewModel.Worksheet.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Numeris Then

                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Group.ToString).Visible = False
                SearchableComboBoxDemos_PrimaryDemo.Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Category.ToString).Visible = False

            End If

        End Sub
        Private Sub SearchableComboBoxDemos_PrimaryDemo_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SearchableComboBoxDemos_PrimaryDemo.EditValueChanging

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If _MediaBroadcastWorksheetID > 0 AndAlso (e.OldValue IsNot Nothing AndAlso e.OldValue <> "-1") AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.HasPrimaryDemographicChanged = False Then

                    If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Changing the demo will cause all market schedule data to be recalculated." &
                                                                  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        _ViewModel.HasPrimaryDemographicChanged = True

                    Else

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxDemos_PrimaryDemo_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxDemos_PrimaryDemo.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SaveViewModel()

                _Controller.Edit_PrimaryMediaDemographicsChanged(_ViewModel)

                RefreshViewModel(False)

                DataGridViewDemos_SecondaryDemos.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub ComboBoxDemos_Source_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDemos_Source.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SearchableComboBoxDemos_PrimaryDemo.SelectedValue = Nothing

                SaveViewModel()

                _Controller.Edit_RatingsServiceChanged(_ViewModel)

                RefreshViewModel(False)

                DataGridViewDemos_SecondaryDemos.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub VerticalGridMatching_Settings_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles VerticalGridMatching_Settings.ShowingEditor

            If _ViewModel.Worksheet.MediaTypeCode = "R" AndAlso VerticalGridMatching_Settings.FocusedRow.Name = "rowNetwork" Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
