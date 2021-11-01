Namespace WinForm.MVC.Presentation.Controls

    Public Class MediaDemographicControl

        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum Type
            TV
            National
            Radio
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _MediaDemographicID As Integer = 0
        Private _Type As Type = Type.TV
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.Maintenance.Media.DemographicController = Nothing
        Private _IsRefreshing As Boolean = False
        Private _MediaDemoSourceID As AdvantageFramework.Database.Entities.MediaDemoSourceID = AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.Maintenance.Media.DemographicController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                    CheckBoxControl_System.AutoCheck = False

                    TextBoxControl_Code.SetPropertySettings(AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel.Properties.Code)
                    TextBoxControl_Code.Enabled = False

                    TextBoxControl_Description.SetPropertySettings(AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel.Properties.Description)

                    ComboBoxControl_AgeFrom.SetPropertySettings("Age From", GetType(Short), True)
                    ComboBoxControl_AgeTo.SetPropertySettings("Age To", GetType(Short?), False)

                    DataGridViewControl_DemoDetails.CurrentView.OptionsMenu.EnableColumnMenu = False
                    DataGridViewControl_DemoDetails.CurrentView.OptionsCustomization.AllowFilter = False
                    DataGridViewControl_DemoDetails.CurrentView.OptionsCustomization.AllowSort = False

                    CheckBoxGender_Boys.Tag = "B"
                    CheckBoxGender_Girls.Tag = "G"

                    CheckBoxGender_Men.Tag = "M"
                    CheckBoxGender_Women.Tag = "F"

                    CheckBoxGender_WorkingWomen.Tag = "W"
                    CheckBoxGender_Children.Tag = "C"

                    CheckBoxUseFor_County.Enabled = False

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub CheckBoxGender_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If _FormSettingsLoaded AndAlso Not _IsRefreshing AndAlso _ViewModel IsNot Nothing Then

                _Controller.UpdateGenderChecked(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox).Tag, DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox).Checked)

                RefreshViewModel(True)

            End If

        End Sub
        Private Sub RefreshViewModel(ReloadAgeFrom As Boolean)

            _IsRefreshing = True

            If _MediaDemoSourceID = Database.Entities.MediaDemoSourceID.Numeris Then

                GroupBoxControl_UseFor.Visible = False

            Else

                GroupBoxControl_UseFor.Visible = (_Type = Type.Radio)

            End If

            CheckBoxUseFor_Market.Checked = _ViewModel.UseForMarket
            CheckBoxUseFor_County.Checked = _ViewModel.UseForCounty

            CheckBoxControl_Inactive.AutoCheck = Not _ViewModel.IsSystem
            CheckBoxControl_Inactive.Visible = If(_ViewModel.ID = 0, False, True)

            TextBoxControl_Description.ReadOnly = _ViewModel.IsSystem

            GroupBoxControl_Gender.Enabled = Not _ViewModel.IsSystem

            If _MediaDemoSourceID = Database.Entities.MediaDemoSourceID.Numeris Then

                CheckBoxGender_WorkingWomen.Enabled = False
                CheckBoxGender_Children.Enabled = False

            Else

                CheckBoxGender_WorkingWomen.Enabled = (_Type = Type.National) AndAlso Not _ViewModel.IsSystem AndAlso (Not _ViewModel.GetMediaDemographicEntity.IsMales AndAlso
                                                                                                                       Not _ViewModel.GetMediaDemographicEntity.IsFemales)
                CheckBoxGender_Children.Enabled = (_Type = Type.TV) AndAlso Not _ViewModel.IsSystem

            End If

            CheckBoxGender_Men.Enabled = (_Type <> Type.National) OrElse (_Type = Type.National) AndAlso Not _ViewModel.IsSystem AndAlso Not _ViewModel.GetMediaDemographicEntity.IsWorkingWomen
            CheckBoxGender_Women.Enabled = (_Type <> Type.National) OrElse (_Type = Type.National) AndAlso Not _ViewModel.IsSystem AndAlso Not _ViewModel.GetMediaDemographicEntity.IsWorkingWomen

            If _MediaDemoSourceID = Database.Entities.MediaDemoSourceID.Numeris Then

                CheckBoxGender_Boys.Enabled = False
                CheckBoxGender_Girls.Enabled = False

            Else

                CheckBoxGender_Boys.Enabled = (_Type = Type.Radio) AndAlso Not _ViewModel.IsSystem
                CheckBoxGender_Girls.Enabled = (_Type = Type.Radio) AndAlso Not _ViewModel.IsSystem

            End If

            ComboBoxControl_AgeFrom.Enabled = (_ViewModel.HasGenderChecked) AndAlso Not _ViewModel.IsSystem

            ComboBoxControl_AgeTo.Enabled = (_ViewModel.HasGenderChecked) AndAlso _ViewModel.AgeFrom.HasValue AndAlso Not _ViewModel.IsSystem

            If _ViewModel.NielsenDemographics IsNot Nothing Then

                ComboBoxControl_AgeTo.SetRequired(Not _ViewModel.NielsenDemographics.Where(Function(ND) ND.AgeTo Is Nothing).Any)

            Else

                ComboBoxControl_AgeTo.SetRequired(False)
                ComboBoxControl_AgeTo.Validate(Nothing)

            End If

            If ReloadAgeFrom Then

                ComboBoxControl_AgeFrom.DataSource = _ViewModel.AgeFromDatasource

                If _ViewModel.GetMediaDemographicEntity.AgeFrom.HasValue Then

                    ComboBoxControl_AgeFrom.SelectedValue = CStr(_ViewModel.GetMediaDemographicEntity.AgeFrom)

                Else

                    ComboBoxControl_AgeFrom.SelectedValue = Nothing

                End If

            End If

            ComboBoxControl_AgeTo.DataSource = _ViewModel.AgeToDatasource

            If _ViewModel.GetMediaDemographicEntity.AgeTo.HasValue Then

                ComboBoxControl_AgeTo.SelectedValue = CStr(_ViewModel.GetMediaDemographicEntity.AgeTo)

            ElseIf _ViewModel.ID = 0 Then

                ComboBoxControl_AgeTo.SelectedValue = Nothing

            Else

                ComboBoxControl_AgeTo.SelectedValue = "+"

            End If

            TextBoxControl_Code.Text = _ViewModel.GetMediaDemographicEntity.Code

            DataGridViewControl_DemoDetails.DataSource = _ViewModel.NielsenDemographics
            DataGridViewControl_DemoDetails.CurrentView.BestFitColumns()

            Me.CheckBoxControl_Inactive.Enabled = (Not _ViewModel.UseForCounty)
            Me.TextBoxControl_Description.Enabled = (Not _ViewModel.UseForCounty)
            Me.GroupBoxControl_Gender.Enabled = (Not _ViewModel.UseForCounty)

            Me.ComboBoxControl_AgeFrom.Enabled = (Not _ViewModel.UseForCounty)
            Me.ComboBoxControl_AgeTo.Enabled = (Not _ViewModel.UseForCounty)

            _IsRefreshing = False

        End Sub
        Private Sub FillObject()

            Dim NielsenCodeIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaDemographicDetail As AdvantageFramework.Database.Entities.MediaDemographicDetail = Nothing

            _ViewModel.GetMediaDemographicEntity.Code = TextBoxControl_Code.GetText
            _ViewModel.GetMediaDemographicEntity.Description = TextBoxControl_Description.GetText
            _ViewModel.GetMediaDemographicEntity.IsSystem = CheckBoxControl_System.Checked
            _ViewModel.GetMediaDemographicEntity.IsInactive = CheckBoxControl_Inactive.Checked

            _ViewModel.GetMediaDemographicEntity.IsChildren = CheckBoxGender_Children.Checked
            _ViewModel.GetMediaDemographicEntity.IsBoys = CheckBoxGender_Boys.Checked
            _ViewModel.GetMediaDemographicEntity.IsGirls = CheckBoxGender_Girls.Checked
            _ViewModel.GetMediaDemographicEntity.IsMales = CheckBoxGender_Men.Checked
            _ViewModel.GetMediaDemographicEntity.IsFemales = CheckBoxGender_Women.Checked
            _ViewModel.GetMediaDemographicEntity.IsWorkingWomen = CheckBoxGender_WorkingWomen.Checked

            _ViewModel.GetMediaDemographicEntity.AgeFrom = ComboBoxControl_AgeFrom.GetSelectedValue

            _ViewModel.GetMediaDemographicEntity.UseForMarket = CheckBoxUseFor_Market.Checked
            _ViewModel.GetMediaDemographicEntity.UseForCounty = CheckBoxUseFor_County.Checked

            If Not IsNumeric(ComboBoxControl_AgeTo.GetSelectedValue) Then

                _ViewModel.GetMediaDemographicEntity.AgeTo = Nothing

            Else

                _ViewModel.GetMediaDemographicEntity.AgeTo = ComboBoxControl_AgeTo.GetSelectedValue

            End If

            NielsenCodeIDs = DataGridViewControl_DemoDetails.GetAllRowsBookmarkValues(0).Cast(Of Integer)

            _ViewModel.GetMediaDemographicEntity.MediaDemographicDetails.Clear()

            For Each NielsenID In NielsenCodeIDs

                MediaDemographicDetail = New AdvantageFramework.Database.Entities.MediaDemographicDetail

                MediaDemographicDetail.NielsenDemographicID = NielsenID

                _ViewModel.GetMediaDemographicEntity.MediaDemographicDetails.Add(MediaDemographicDetail)

            Next

        End Sub

#Region "  Public "

        Public Function CheckForUnsavedChanges(ByRef DemographicSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupViewModel) As Boolean

            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = ""
            Dim DemographicSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.DemographicSetupDetailViewModel = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validate Then

                        IsOkay = Me.Save(ErrorMessage, _MediaDemographicID)

                        If IsOkay Then

                            DemographicSetupDetailViewModel = DemographicSetupViewModel.MediaDemographics.Where(Function(Entity) Entity.ID = _MediaDemographicID).FirstOrDefault

                            If DemographicSetupDetailViewModel IsNot Nothing Then

                                DemographicSetupDetailViewModel.GetMediaDemographicEntity.Description = _ViewModel.Description

                            End If

                        End If

                        If Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Public Sub ClearControl()

            _IsRefreshing = True

            TextBoxControl_Code.Text = Nothing
            TextBoxControl_Description.Text = Nothing
            CheckBoxControl_Inactive.CheckValue = 0

            CheckBoxGender_Children.Checked = False
            CheckBoxGender_Boys.Checked = False
            CheckBoxGender_Girls.Checked = False
            CheckBoxGender_Men.Checked = False
            CheckBoxGender_Women.Checked = False
            CheckBoxGender_WorkingWomen.Checked = False

            ComboBoxControl_AgeFrom.SelectedValue = Nothing
            ComboBoxControl_AgeTo.SelectedValue = Nothing

            CheckBoxUseFor_Market.Checked = False
            CheckBoxUseFor_County.Checked = False

            DataGridViewControl_DemoDetails.ClearDatasource()

            _IsRefreshing = False

        End Sub
        Public Function Delete() As Boolean

            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = Nothing

            If CheckBoxUseFor_County.Checked Then

                AdvantageFramework.WinForm.MessageBox.Show("A county demographic cannot be deleted.")

            ElseIf AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Deleted = _Controller.Delete(_MediaDemographicID, ErrorMessage)

                If Not Deleted AndAlso Not String.IsNullOrWhiteSpace(ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

            Delete = Deleted

        End Function
        Public Function LoadControl(MediaDemographicID As Integer, Type As String, MediaDemoSourceID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _IsRefreshing = True

            _MediaDemographicID = MediaDemographicID
            _MediaDemoSourceID = MediaDemoSourceID

            Select Case Type

                Case "T"

                    _Type = MediaDemographicControl.Type.TV

                Case "N"

                    _Type = MediaDemographicControl.Type.National

                Case "R"

                    _Type = MediaDemographicControl.Type.Radio

            End Select

            _ViewModel = _Controller.Load(_MediaDemographicID, Type, MediaDemoSourceID)

            If _MediaDemographicID <> 0 Then

                If _ViewModel.MediaDemographic Is Nothing Then

                    Loaded = False

                End If

            Else

                _ViewModel.GetMediaDemographicEntity.Type = Type
                _ViewModel.GetMediaDemographicEntity.MediaDemoSourceID = MediaDemoSourceID

                CheckBoxControl_System.Checked = False
                CheckBoxControl_System.Visible = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

            TextBoxControl_Description.Text = _ViewModel.GetMediaDemographicEntity.Description
            CheckBoxControl_System.Checked = _ViewModel.GetMediaDemographicEntity.IsSystem
            CheckBoxControl_Inactive.Checked = _ViewModel.GetMediaDemographicEntity.IsInactive

            CheckBoxGender_Children.Checked = _ViewModel.GetMediaDemographicEntity.IsChildren
            CheckBoxGender_Boys.Checked = _ViewModel.GetMediaDemographicEntity.IsBoys
            CheckBoxGender_Girls.Checked = _ViewModel.GetMediaDemographicEntity.IsGirls
            CheckBoxGender_Men.Checked = _ViewModel.GetMediaDemographicEntity.IsMales
            CheckBoxGender_Women.Checked = _ViewModel.GetMediaDemographicEntity.IsFemales
            CheckBoxGender_WorkingWomen.Checked = _ViewModel.GetMediaDemographicEntity.IsWorkingWomen

            _IsRefreshing = False

            RefreshViewModel(True)

        End Function
        Public Function Save(ByRef ErrorMessage As String, ByRef MediaDemographicID As Integer) As Boolean

            'objects
            Dim Saved As Boolean = False

            FillObject()

            If _MediaDemographicID = 0 Then

                Saved = _Controller.Add(_ViewModel, MediaDemographicID, ErrorMessage)

            Else

                Saved = _Controller.Update(_ViewModel, ErrorMessage)

                MediaDemographicID = _MediaDemographicID

            End If

            Save = Saved

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub MediaDemographicControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler CheckBoxGender_Boys.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            RemoveHandler CheckBoxGender_Girls.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            RemoveHandler CheckBoxGender_Children.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            RemoveHandler CheckBoxGender_Men.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            RemoveHandler CheckBoxGender_Women.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            RemoveHandler CheckBoxGender_WorkingWomen.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx

        End Sub
        Private Sub MediaDemographicControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            AddHandler CheckBoxGender_Boys.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            AddHandler CheckBoxGender_Girls.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            AddHandler CheckBoxGender_Children.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            AddHandler CheckBoxGender_Men.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            AddHandler CheckBoxGender_Women.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx
            AddHandler CheckBoxGender_WorkingWomen.CheckedChangedEx, AddressOf CheckBoxGender_CheckedChangedEx

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxControl_Inactive.Checked, e.Cancel)

            End If

        End Sub
        Private Sub ComboBoxControl_AgeFrom_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_AgeFrom.TextChanged

            If _FormSettingsLoaded AndAlso Not _IsRefreshing AndAlso _ViewModel IsNot Nothing Then

                _Controller.SetDemoDetailsBasedOnAge(_ViewModel, True, ComboBoxControl_AgeFrom.GetSelectedValue, Nothing)

                RefreshViewModel(True)

            End If

        End Sub
        Private Sub ComboBoxControl_AgeTo_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_AgeTo.TextChanged

            If _FormSettingsLoaded AndAlso Not _IsRefreshing AndAlso _ViewModel IsNot Nothing Then

                _Controller.SetDemoDetailsBasedOnAge(_ViewModel, False, ComboBoxControl_AgeFrom.GetSelectedValue, ComboBoxControl_AgeTo.GetSelectedValue)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub CheckBoxUseFor_Market_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxUseFor_Market.CheckedChangedEx

            If _FormSettingsLoaded AndAlso Not _IsRefreshing AndAlso _ViewModel IsNot Nothing Then

                _Controller.UpdateUseForMarket(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox).Checked)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
