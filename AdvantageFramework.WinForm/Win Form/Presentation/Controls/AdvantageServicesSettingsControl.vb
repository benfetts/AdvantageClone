Namespace WinForm.Presentation.Controls

    Public Class AdvantageServicesSettingsControl

        Public Event EnableOrDisableServiceActionsEvent()
        Public Event EnableOrDisableActionsEvent()
        Public Event EnableOrDisableSaveEvent(ByVal Enabled As Boolean)
        Public Event NielsenTabSelectedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FromAdvantageServices As Boolean = False
        'all services
        Private _SelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
        Private _Initialized As Boolean = False
        Private _SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
        Private _AdvantageServices As Generic.List(Of AdvantageFramework.Database.Entities.AdvantageService) = Nothing
        Private _SelectedAdvantageService As AdvantageFramework.Database.Entities.AdvantageService = Nothing
        Private _ServicesChangedDictionary As Generic.Dictionary(Of String, Boolean) = Nothing
        Private _HasBeenLoaded As Boolean = False
        Private _IsAgencyASP As Boolean = False
        'QvA Variables
        Private _QvAAlertLevel1Enabled As Boolean = False
        Private _QvAAlertLevel1Start As Decimal = 0
        Private _QvAAlertLevel1End As Decimal = 0
        Private _QvAAlertLevel1Description As String = ""
        Private _QvAAlertLevel2Enabled As Boolean = False
        Private _QvAAlertLevel2Start As Decimal = 0
        Private _QvAAlertLevel2End As Decimal = 0
        Private _QvAAlertLevel2Description As String = ""
        Private _QvAAlertLevel3Enabled As Boolean = False
        Private _QvAAlertLevel3Start As Decimal = 0
        Private _QvAAlertLevel3Description As String = ""
        Private _SendAlertTo As Integer = -1
        Private _SetAlertLevel As Integer = -1
        Private _ShowLevel As Integer = -1

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedAdvantageService As AdvantageFramework.Database.Entities.AdvantageService
            Get
                SelectedAdvantageService = _SelectedAdvantageService
            End Get
        End Property
        Public ReadOnly Property SelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile
            Get
                SelectedDatabaseProfile = _SelectedDatabaseProfile
            End Get
        End Property
        Public ReadOnly Property FromAdvantageServices As Boolean
            Get
                FromAdvantageServices = _FromAdvantageServices
            End Get
        End Property
        Public ReadOnly Property HasASelectedExportTemplate As Boolean
            Get

                'objects
                Dim Selected As Boolean = False

                If TabControlForm_Services.SelectedTab Is TabItemServices_ExportsTab Then

                    If TabControlExports_ExportsSettings.SelectedTab Is TabItemExportsSettings_ExportsSettingsTab Then

                        Selected = DataGridViewExports_AvailableExports.HasASelectedRow

                    End If

                End If

                HasASelectedExportTemplate = Selected

            End Get
        End Property
        Public ReadOnly Property IsNielsenServiceTabSelected As Boolean
            Get
                If TabControlForm_Services.SelectedTab Is TabItemServices_NielsenTab Then
                    IsNielsenServiceTabSelected = True
                Else
                    IsNielsenServiceTabSelected = False
                End If
            End Get
        End Property

#End Region

#Region " Methods "

#Region "  Email Listener "

        Private Sub SetEmailListenerStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelEmailListener_StatusDescription, Message)

        End Sub
        Private Sub LoadEmailListenerSettings()

            AdvantageFramework.Services.EmailListener.LoadSettings(_DataContext, NumericInputEmailListenerSettings_RunAtEvery.EditValue, TextBoxEmailListenerSettings_StartofSignatureCode.Text, CheckBoxEmailListenerSettings_SendEmailToAlertRecipients.Checked)

        End Sub
        Private Sub SaveEmailListenerSettings()

            AdvantageFramework.Services.EmailListener.SaveSettings(_DataContext, NumericInputEmailListenerSettings_RunAtEvery.EditValue, TextBoxEmailListenerSettings_StartofSignatureCode.Text, CheckBoxEmailListenerSettings_SendEmailToAlertRecipients.Checked)

        End Sub
        Private Sub EmailListenerEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetEmailListenerStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  QvA Alert "

        Private Sub SetQvAAlertStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelQvAAlert_StatusDescription, Message)

        End Sub
        Private Sub LoadQvAAlertSettings()

            AdvantageFramework.Services.QvAAlert.LoadSettings(_DataContext, DateTimePickerQvAAlertSettings_RunAt.Value, _SendAlertTo,
                                                              _QvAAlertLevel1Enabled, _QvAAlertLevel1Start, _QvAAlertLevel1End, _QvAAlertLevel1Description,
                                                              _QvAAlertLevel2Enabled, _QvAAlertLevel2Start, _QvAAlertLevel2End, _QvAAlertLevel2Description,
                                                              _QvAAlertLevel3Enabled, _QvAAlertLevel3Start, _QvAAlertLevel3Description,
                                                              CheckBoxCalculationOptions_Time.Checked, CheckBoxCalculationOptions_IncomeOnly.Checked,
                                                              CheckBoxCalculationOptions_VendorCharges.Checked, CheckBoxCalculationOptions_IncludeEstimate.Checked,
                                                              CheckBoxCalculationOptions_IncludeNonBillableTime.Checked, CheckBoxCalculationOptions_IncludeTimeMarkedFeeTime.Checked,
                                                             _SetAlertLevel, _ShowLevel, False)

        End Sub
        Private Sub SaveQvAAlertSettings()

            If _Initialized Then

                AdvantageFramework.Services.QvAAlert.SaveSettings(_DataContext, DateTimePickerQvAAlertSettings_RunAt.Value, _SendAlertTo,
                                                                  _QvAAlertLevel1Enabled, _QvAAlertLevel1Start, _QvAAlertLevel1End, _QvAAlertLevel1Description,
                                                                  _QvAAlertLevel2Enabled, _QvAAlertLevel2Start, _QvAAlertLevel2End, _QvAAlertLevel2Description,
                                                                  _QvAAlertLevel3Enabled, _QvAAlertLevel3Start, _QvAAlertLevel3Description,
                                                                  CheckBoxCalculationOptions_Time.Checked, CheckBoxCalculationOptions_IncomeOnly.Checked,
                                                                  CheckBoxCalculationOptions_VendorCharges.Checked, CheckBoxCalculationOptions_IncludeEstimate.Checked,
                                                                  CheckBoxCalculationOptions_IncludeNonBillableTime.Checked, CheckBoxCalculationOptions_IncludeTimeMarkedFeeTime.Checked,
                                                                  _SetAlertLevel, _ShowLevel)
            End If

        End Sub
        Private Function CheckValidValue(ByVal NewValue As Decimal, ByVal Enable As Boolean, ByVal StartValue As Decimal, ByVal EndValue As Decimal)

            'objects
            Dim IsValidValue As Boolean = True

            If Enable Then

                If EndValue <> 0 AndAlso StartValue > EndValue Then

                    If NewValue <= StartValue Then

                        If NewValue >= EndValue Then

                            IsValidValue = False

                        End If

                    End If

                Else

                    If NewValue >= StartValue Then

                        If EndValue = 0 Then

                            IsValidValue = False

                        Else

                            If NewValue <= EndValue Then

                                IsValidValue = False

                            End If

                        End If

                    End If

                End If

            End If

            CheckValidValue = IsValidValue

        End Function
        Private Sub QvAAlertEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetQvAAlertStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Media Export "

        Private Sub SetMediaExportStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelMediaExport_StatusDescription, Message)

        End Sub
        Private Sub LoadMediaExportSettings()

            'objects
            Dim ExportDataEnum As AdvantageFramework.Services.MediaExport.SelectedData = AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            AdvantageFramework.Services.MediaExport.LoadSettings(_DataContext, DateTimePickerMediaExportSettings_RunAt.Value, TextBoxMediaExportSettings_ExportPath.Text, ExportDataEnum, StartDate, EndDate)

            Select Case ExportDataEnum

                Case AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected

                    RadioButtonMediaExportSettings_AllData.Checked = True
                    DateTimePickerMediaExportSettings_DataStart.Value = DateTime.Today
                    DateTimePickerMediaExportSettings_DataEnd.Value = DateTime.Today

                Case AdvantageFramework.Services.MediaExport.SelectedData.TodaysDataSelected

                    RadioButtonMediaExportSettings_TodaysData.Checked = True
                    DateTimePickerMediaExportSettings_DataStart.Value = DateTime.Today
                    DateTimePickerMediaExportSettings_DataEnd.Value = DateTime.Today

                Case Else

                    RadioButtonMediaExportSettings_DataFrom.Checked = True
                    DateTimePickerMediaExportSettings_DataStart.Value = StartDate
                    DateTimePickerMediaExportSettings_DataEnd.Value = EndDate

            End Select

            ComboBoxExportCriteria_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(_DbContext)

            LoadMediaExportClientCampaigns()

        End Sub
        Private Sub LoadMediaExportClientCampaigns()

            'objects
            Dim LoadedCampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            LoadedCampaignList = AdvantageFramework.Services.MediaExport.LoadClientCampaigns(_DataContext).OrderBy(Function(Campaign) Campaign.CampaignClient).ToList

            AddCampaignCriteria(LoadedCampaignList, False)

        End Sub
        Private Sub SaveMediaExportSettings()

            'objects
            Dim ExportDataString As String = AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected.ToString()

            If _Initialized Then

                If RadioButtonMediaExportSettings_AllData.Checked Then

                    ExportDataString = AdvantageFramework.Services.MediaExport.SelectedData.AllDataSelected.ToString()

                ElseIf RadioButtonMediaExportSettings_TodaysData.Checked Then

                    ExportDataString = AdvantageFramework.Services.MediaExport.SelectedData.TodaysDataSelected.ToString()

                ElseIf RadioButtonMediaExportSettings_DataFrom.Checked Then

                    ExportDataString = DateTimePickerMediaExportSettings_DataStart.Value.ToString()

                    If DateTimePickerMediaExportSettings_DataEnd.Value.Date <> DateTime.Today Then

                        ExportDataString += "," + DateTimePickerMediaExportSettings_DataEnd.Value.ToString()

                    End If

                End If

                AdvantageFramework.Services.MediaExport.SaveSettings(_DataContext, DateTimePickerMediaExportSettings_RunAt.Value, TextBoxMediaExportSettings_ExportPath.Text, ExportDataString)

            End If

        End Sub
        Private Sub SaveMediaExportClientCampaigns()

            AdvantageFramework.Services.MediaExport.DeleteClientCampaigns(_DataContext)

            For Each ClientCampaign In DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

                AdvantageFramework.Services.MediaExport.InsertClientCampaign(_DataContext, ClientCampaign)

            Next

            SetUserChangedValue(True)

        End Sub
        Private Sub MediaExportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetMediaExportStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub AddCampaignCriteria(ByVal CampaignsToAddList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign), ByVal SaveSettings As Boolean)

            'objects
            Dim CampaignList As List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            If CampaignsToAddList IsNot Nothing Then

                CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

                If SaveSettings Then

                    CampaignList = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

                End If

                CampaignList.AddRange(CampaignsToAddList)

                DataGridViewExportCriteria_SelectedCampaigns.ItemDescription = "Selected Campaign(s)"

                DataGridViewExportCriteria_SelectedCampaigns.DataSource = CampaignList

                DataGridViewExportCriteria_SelectedCampaigns.MakeColumnNotVisible("ID")

                DataGridViewExportCriteria_SelectedCampaigns.CurrentView.BestFitColumns()

                LoadAvailableCampaigns()

                If SaveSettings Then

                    SaveMediaExportClientCampaigns()

                End If

            End If

        End Sub
        Private Sub RemoveCampaignCriteria(ByVal CampaignsToRemoveList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign))

            'objects
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            If CampaignsToRemoveList IsNot Nothing Then

                CampaignList = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

                For Each CampaignToRemove As AdvantageFramework.Database.Classes.Campaign In CampaignsToRemoveList

                    CampaignList.Remove(CampaignToRemove)

                Next

                DataGridViewExportCriteria_SelectedCampaigns.DataSource = CampaignList

                DataGridViewExportCriteria_SelectedCampaigns.CurrentView.BestFitColumns()

                LoadAvailableCampaigns()

                SaveMediaExportClientCampaigns()

            End If

        End Sub
        Private Function GetAllCampaignsByClientPlusNull(ByVal ClientCode As String, ByVal ClientName As String) As Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

            'objects
            Dim NewCampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
            Dim NullCampaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim NewClient As AdvantageFramework.Database.Entities.Client = Nothing

            NewCampaignList = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)()

            NullCampaign = New AdvantageFramework.Database.Entities.Campaign()
            NullCampaign.ID = -1

            NewClient = New AdvantageFramework.Database.Entities.Client()
            NewClient.Code = ClientCode

            If ClientName.IndexOf("-") > 0 Then

                NewClient.Name = ClientName.Substring(ClientName.IndexOf("-") + 1).Trim

            Else

                NewClient.Name = ClientName

            End If

            NullCampaign.Client = NewClient
            NullCampaign.Code = ""
            NullCampaign.Name = "No Campaign"

            NewCampaignList.Add(NullCampaign)

            For Each Campaign In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(_DbContext, ClientCode).Include("Office").Include("Client").Include("Division").Include("Product").ToList

                NewCampaignList.Add(Campaign)

            Next

            GetAllCampaignsByClientPlusNull = NewCampaignList

        End Function
        Private Sub LoadAvailableCampaigns()

            'objects
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing
            Dim FoundCampaign As Boolean = False
            Dim AllCampaignListPlusNull As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
            Dim AvailableCampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing

            If ComboBoxExportCriteria_Clients.HasASelectedValue Then

                CampaignList = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

                AllCampaignListPlusNull = GetAllCampaignsByClientPlusNull(ComboBoxExportCriteria_Clients.SelectedItem.Code, ComboBoxExportCriteria_Clients.SelectedItem.Name)

                If CampaignList.Count = 0 Then

                    DataGridViewExportCriteria_Campaigns.DataSource = AllCampaignListPlusNull

                Else

                    AvailableCampaignList = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

                    For Each Campaign In AllCampaignListPlusNull

                        FoundCampaign = False

                        For Each SelectedCampaign In CampaignList

                            If SelectedCampaign.ID = Campaign.ID AndAlso SelectedCampaign.CampaignClient = Campaign.Client.ToString() Then

                                FoundCampaign = True
                                Exit For

                            End If

                        Next

                        If FoundCampaign = False Then

                            AvailableCampaignList.Add(Campaign)

                        End If

                    Next

                    DataGridViewExportCriteria_Campaigns.DataSource = AvailableCampaignList

                End If

                DataGridViewExportCriteria_Campaigns.CurrentView.BestFitColumns()

            End If

        End Sub

#End Region

#Region "  Task "

        Private Sub SetTaskStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelTask_StatusDescription, Message)

        End Sub
        Private Sub LoadTaskSettings()

            'objects
            Dim RunAtDay As String = ""
            Dim UpcomingDays As String = ""
            Dim SplitString() As String
            Dim StartDays As Integer = 0
            Dim EndDays As Integer = 0

            AdvantageFramework.Services.Task.LoadSettings(_DataContext, DateTimePickerTaskSettings_RunAt.Value, RunAtDay, CheckBoxTaskSettings_PastDue.Checked, TextBoxTaskSettings_PastDue_CustomMessage.Text,
                                                          CheckBoxTaskSettings_Upcoming.Checked, TextBoxTaskSettings_Upcoming_CustomMessage.Text, UpcomingDays, CheckBoxTaskSettings_UseProductName.Checked, CheckBoxTaskSettings_RemoveTaskComments.Checked)
            SplitString = UpcomingDays.Split(",")

            Integer.TryParse(SplitString(0), StartDays)
            Integer.TryParse(SplitString(1), EndDays)

            NumericInputTaskSettings_Upcoming_StartDays.EditValue = StartDays
            NumericInputTaskSettings_Upcoming_EndDays.EditValue = EndDays

            ComboBoxTaskSettings_RunDay.SelectedValue = RunAtDay

            UpdatePastDueSettings()

            UpdateUpcomingSettings()

        End Sub
        Private Sub SaveTaskSettings()

            ' objects
            Dim UpcomingDays As String = ""

            If _Initialized Then

                UpcomingDays = NumericInputTaskSettings_Upcoming_StartDays.EditValue.ToString() + "," + NumericInputTaskSettings_Upcoming_EndDays.EditValue.ToString()

                AdvantageFramework.Services.Task.SaveSettings(_DataContext, DateTimePickerTaskSettings_RunAt.Value, ComboBoxTaskSettings_RunDay.SelectedValue, CheckBoxTaskSettings_PastDue.Checked, TextBoxTaskSettings_PastDue_CustomMessage.Text,
                                                              CheckBoxTaskSettings_Upcoming.Checked, TextBoxTaskSettings_Upcoming_CustomMessage.Text, UpcomingDays, CheckBoxTaskSettings_UseProductName.Checked, CheckBoxTaskSettings_RemoveTaskComments.Checked)

            End If

        End Sub
        Private Sub TaskEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetTaskStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub UpdatePastDueSettings()

            If CheckBoxTaskSettings_PastDue.Checked Then

                TextBoxTaskSettings_PastDue_CustomMessage.Enabled = True

            Else

                TextBoxTaskSettings_PastDue_CustomMessage.Enabled = False

            End If

        End Sub
        Private Sub UpdateUpcomingSettings()

            If CheckBoxTaskSettings_Upcoming.Checked Then

                TextBoxTaskSettings_Upcoming_CustomMessage.Enabled = True
                NumericInputTaskSettings_Upcoming_StartDays.Enabled = True
                NumericInputTaskSettings_Upcoming_EndDays.Enabled = True

            Else

                TextBoxTaskSettings_Upcoming_CustomMessage.Enabled = False
                NumericInputTaskSettings_Upcoming_StartDays.Enabled = False
                NumericInputTaskSettings_Upcoming_EndDays.Enabled = False

            End If

        End Sub

#End Region

#Region "  Missing Time "

        Private Sub LoadMissingTimeSettings()

            LoadMissingTimeServiceSettings()
            LoadMissingTimeProcessSettings()

        End Sub
        Private Sub LoadMissingTimeServiceSettings()

            'objects
            Dim ProcessTime As Boolean = False
            Dim ProcessTimeValue As Date = Nothing
            Dim ProcessTimeDaily As Boolean = False
            Dim ProcessTimeWeekday As String = ""
            Dim ProcessStopAfterHours As Boolean = False
            Dim ProcessAfterHours As Integer = 0
            Dim StopAfterHours As Integer = 0

            Try

                AdvantageFramework.Services.MissingTime.LoadServiceSettings(_DataContext,
                                                                            ProcessTime,
                                                                            ProcessTimeValue,
                                                                            ProcessTimeWeekday,
                                                                            ProcessTimeDaily,
                                                                            ProcessAfterHours,
                                                                            ProcessStopAfterHours,
                                                                            StopAfterHours)

                CheckBoxMissingTimeSettings_Interval_RunAt.Checked = ProcessTime
                DateTimePickerMissingTimeSettings_Interval_RunAtTime.Value = ProcessTimeValue

                ComboBoxMissingTimeSettings_Interval_RunDay.SelectedValue = ProcessTimeWeekday

                CheckBoxMissingTimeSettings_Interval_RunEvery.Checked = ProcessTimeDaily

                NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MinValue = 0
                NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MaxValue = 23
                NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValue = ProcessAfterHours

                CheckBoxMissingTimeSettings_Interval_StopAfter.Checked = ProcessStopAfterHours

                NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MinValue = 0
                NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MaxValue = 23
                NumericInputMissingTimeSettings_Interval_StopAfter.EditValue = StopAfterHours

                UpdateMissingTimeIntervalRunAtSettings(ProcessTime)
                UpdateMissingTimeIntervalRunEverySettings(ProcessTimeDaily)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadMissingTimeProcessSettings()

            'objects
            Dim RangeDaysToCheck As Boolean = False
            Dim DaysToCheck As Integer = 0
            Dim SendEmailToEmployee As Boolean = False
            Dim SendEmailToSupervisor As Boolean = False
            Dim SendEmailToITContact As Boolean = True
            Dim HighPriority As Boolean = False
            Dim MediumPriority As Boolean = False
            Dim LowPriority As Boolean = False
            Dim DontCountWeekendsHoliday As Boolean = False
            Dim MissingTimeOnly As Boolean = False
            Dim EmployeeGracePeriod As Integer = 0
            Dim SupervisorGracePeriod As Integer = 0
            Dim ITContactGracePeriod As Integer = 0
            Dim CustomMessage As String = ""
            Dim LogFileDirectory As String = ""
            Dim LogFileMissingTimeOnly As Boolean = False

            Try

                AdvantageFramework.Services.MissingTime.LoadProcessSettings(_DataContext,
                                                                            RangeDaysToCheck,
                                                                            DaysToCheck,
                                                                            SendEmailToEmployee,
                                                                            SendEmailToSupervisor,
                                                                            HighPriority,
                                                                            MediumPriority,
                                                                            LowPriority,
                                                                            DontCountWeekendsHoliday,
                                                                            MissingTimeOnly,
                                                                            EmployeeGracePeriod,
                                                                            SupervisorGracePeriod,
                                                                            ITContactGracePeriod,
                                                                            CustomMessage,
                                                                            LogFileDirectory,
                                                                            LogFileMissingTimeOnly)

                If RangeDaysToCheck Then

                    RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked = True

                Else

                    RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Checked = True

                End If

                NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MinValue = 0
                'NumericInputMissingTimeSettings_Range_DaysToCheck.MaxValue = 7
                NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MaxValue = 99
                NumericInputMissingTimeSettings_Range_DaysToCheck.EditValue = DaysToCheck

                CheckBoxMissingTimeAlerts_Recipient_Employee.Checked = SendEmailToEmployee
                CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked = SendEmailToSupervisor
                CheckBoxMissingTimeAlerts_Recipient_ITContact.Checked = SendEmailToITContact

                If HighPriority Then

                    RadioButtonMissingTimeSettings_Priority_High.Checked = True

                Else

                    If MediumPriority Then

                        RadioButtonMissingTimeSettings_Priority_Medium.Checked = True

                    Else

                        If LowPriority Then

                            RadioButtonMissingTimeSettings_Priority_Low.Checked = True

                        End If

                    End If

                End If

                CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Checked = DontCountWeekendsHoliday
                CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Checked = MissingTimeOnly

                NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MinValue = 0
                'NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.MaxValue = 7
                NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MaxValue = 99
                NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValue = EmployeeGracePeriod

                NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MinValue = 0
                'NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.MaxValue = 7
                NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MaxValue = 99
                NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValue = SupervisorGracePeriod

                NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MinValue = 0
                'NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.MaxValue = 7
                NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MaxValue = 99
                NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValue = ITContactGracePeriod

                TextBoxMissingTimeAlerts_CustomMessage.Text = CustomMessage

                TextBoxMissingTimeSettings_LogFilePath.Text = LogFileDirectory
                CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Checked = LogFileMissingTimeOnly

                UpdateMissingTimeRangeSettings(RangeDaysToCheck)

                UpdateMissingTimeRecipientEmployeeSettings(SendEmailToEmployee)
                UpdateMissingTimeRecipientSupervisorSettings(SendEmailToSupervisor)
                UpdateMissingTimeRecipientITContactSettings(SendEmailToITContact)

                CheckBoxMissingTimeAlerts_Recipient_ITContact.Enabled = False
                CheckBoxMissingTimeAlerts_Recipient_ITContact.Visible = False

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveMissingTimeSettings()

            SaveMissingTimeServiceSettings()
            SaveMissingTimeProcessSettings()

        End Sub
        Private Sub SaveMissingTimeProcessSettings()

            AdvantageFramework.Services.MissingTime.SaveProcessSettings(_DataContext,
                                                                        RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked,
                                                                        NumericInputMissingTimeSettings_Range_DaysToCheck.EditValue,
                                                                        CheckBoxMissingTimeAlerts_Recipient_Employee.Checked,
                                                                        CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked,
                                                                        RadioButtonMissingTimeSettings_Priority_High.Checked,
                                                                        RadioButtonMissingTimeSettings_Priority_Medium.Checked,
                                                                        RadioButtonMissingTimeSettings_Priority_Low.Checked,
                                                                        CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Checked,
                                                                        CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Checked,
                                                                        NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValue,
                                                                        NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValue,
                                                                        NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValue,
                                                                        TextBoxMissingTimeAlerts_CustomMessage.Text,
                                                                        TextBoxMissingTimeSettings_LogFilePath.Text,
                                                                        CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Checked)

        End Sub
        Private Sub SaveMissingTimeServiceSettings()

            AdvantageFramework.Services.MissingTime.SaveServiceSettings(_DataContext,
                                                                        CheckBoxMissingTimeSettings_Interval_RunAt.Checked,
                                                                        DateTimePickerMissingTimeSettings_Interval_RunAtTime.Value,
                                                                        ComboBoxMissingTimeSettings_Interval_RunDay.SelectedValue,
                                                                        CheckBoxMissingTimeSettings_Interval_RunEvery.Checked,
                                                                        NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValue,
                                                                        CheckBoxMissingTimeSettings_Interval_StopAfter.Checked,
                                                                        NumericInputMissingTimeSettings_Interval_StopAfter.EditValue)

        End Sub
        Private Sub UpdateMissingTimeIntervalRunAtSettings(ByVal Setting As Boolean)

            DateTimePickerMissingTimeSettings_Interval_RunAtTime.Enabled = Setting
            ComboBoxMissingTimeSettings_Interval_RunDay.Enabled = Setting

        End Sub
        Private Sub UpdateMissingTimeIntervalRunEverySettings(ByVal Setting As Boolean)

            NumericInputMissingTimeSettings_Interval_RunEveryHours.Enabled = Setting
            CheckBoxMissingTimeSettings_Interval_StopAfter.Enabled = Setting

            UpdateMissingTimeIntervalStopAfterSettings(Setting AndAlso CheckBoxMissingTimeSettings_Interval_StopAfter.Checked)

        End Sub
        Private Sub UpdateMissingTimeIntervalStopAfterSettings(ByVal Setting As Boolean)

            NumericInputMissingTimeSettings_Interval_StopAfter.Enabled = Setting

        End Sub
        Private Sub UpdateMissingTimeRangeSettings(ByVal Setting As Boolean)

            NumericInputMissingTimeSettings_Range_DaysToCheck.Enabled = Setting

        End Sub
        Private Sub UpdateMissingTimeRecipientEmployeeSettings(ByVal Setting As Boolean)

            NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Enabled = Setting

        End Sub
        Private Sub UpdateMissingTimeRecipientSupervisorSettings(ByVal Setting As Boolean)

            NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Enabled = Setting

        End Sub
        Private Sub UpdateMissingTimeRecipientITContactSettings(ByVal Setting As Boolean)

            NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Enabled = Setting

        End Sub
        Private Sub SetMissingTimeStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelMissingTime_StatusDescription, Message)

        End Sub
        Private Sub MissingTimeEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetMissingTimeStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Calendar "

        Private Sub SetCalendarStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelCalendar_StatusDescription, Message)

        End Sub
        Private Sub LoadCalendarSettings()

            AdvantageFramework.Services.Calendar.LoadSettings(_DataContext, NumericInputCalendarSettings_RunAt.EditValue, Nothing)

        End Sub
        Private Sub SaveCalendarSettings()

            AdvantageFramework.Services.Calendar.SaveSettings(_DataContext, NumericInputCalendarSettings_RunAt.EditValue)

        End Sub
        Private Sub CalendarEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetCalendarStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Core Media Check Export "

        Private Sub SetCoreMediaCheckExportStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelCoreMediaCheckExport_StatusDescription, Message)

        End Sub
        Private Sub LoadCoreMediaCheckExportSettings()

            AdvantageFramework.Services.CoreMediaCheckExport.LoadSettings(_DataContext, DateTimePickerCoreMediaCheckExportSettings_RunAt.Value, TextBoxCoreMediaCheckExportSettings_ExportPath.Text)

        End Sub
        Private Sub SaveCoreMediaCheckExportSettings()

            AdvantageFramework.Services.CoreMediaCheckExport.SaveSettings(_DataContext, DateTimePickerCoreMediaCheckExportSettings_RunAt.Value, TextBoxCoreMediaCheckExportSettings_ExportPath.Text)

        End Sub
        Private Sub CoreMediaCheckExportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetCoreMediaCheckExportStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Paid Time Off Accruals "

        Private Sub SetPaidTimeOffAccrualsStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelPaidTimeOffAccruals_StatusDescription, Message)

        End Sub
        Private Sub LoadPaidTimeOffAccrualsSettings()

            AdvantageFramework.Services.PaidTimeOffAccruals.LoadSettings(_DataContext, ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValue)

        End Sub
        Private Sub SavePaidTimeOffAccrualsSettings()

            AdvantageFramework.Services.PaidTimeOffAccruals.SaveSettings(_DataContext, ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValue)

        End Sub
        Private Sub PaidTimeOffAccrualsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetPaidTimeOffAccrualsStatus(EventLogEntry.Message & "....")

        End Sub
        Public Function LoadDays() As Generic.List(Of Int32)

            Dim DaysList As Generic.List(Of Int32) = Nothing

            DaysList = New Generic.List(Of Int32)

            DaysList.Add(1)
            DaysList.Add(2)
            DaysList.Add(3)
            DaysList.Add(4)
            DaysList.Add(5)
            DaysList.Add(6)
            DaysList.Add(7)
            DaysList.Add(8)
            DaysList.Add(9)
            DaysList.Add(10)
            DaysList.Add(11)
            DaysList.Add(12)
            DaysList.Add(13)
            DaysList.Add(14)
            DaysList.Add(15)
            DaysList.Add(16)
            DaysList.Add(17)
            DaysList.Add(18)
            DaysList.Add(19)
            DaysList.Add(20)
            DaysList.Add(21)
            DaysList.Add(22)
            DaysList.Add(23)
            DaysList.Add(24)
            DaysList.Add(25)
            DaysList.Add(26)
            DaysList.Add(27)
            DaysList.Add(28)

            LoadDays = DaysList

        End Function

#End Region

#Region "  Contract "

        Private Sub ContractEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetContractStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetContractStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelContract_StatusDescription, Message)

        End Sub
        Private Sub LoadContractSettings()

            AdvantageFramework.Services.Contract.LoadSettings(_DataContext, DateTimePickerContractAlertSettings_RunAt.Value, CheckBoxContractSettings_ContractRenewal.Checked, NumericInputContractSettings_RenewalDaysPrior.EditValue)

        End Sub
        Private Sub SaveContractAlertSettings()

            AdvantageFramework.Services.Contract.SaveSettings(_DataContext, DateTimePickerContractAlertSettings_RunAt.Value, CheckBoxContractSettings_ContractRenewal.Checked, NumericInputContractSettings_RenewalDaysPrior.EditValue)

        End Sub

#End Region

#Region "  Media Ocean Import "

        Private Sub MediaOceanImportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetMediaOceanImportStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetMediaOceanImportStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelMediaOceanImport_StatusDescription, Message)

        End Sub
        Private Sub LoadMediaOceanImportSettings()

            Dim ImportType As Short = 0

            AdvantageFramework.Services.MediaOceanImport.LoadSettings(_DataContext, DateTimePickerMediaOceanImportSettings_RunAt.Value)

            Try

                ComboBoxMediaOceanImportSettings_Employee.DataSource = AdvantageFramework.Services.MediaOceanImport.LoadEmployees(_DbContext)

                AdvantageFramework.Services.MediaOceanImport.LoadServiceSettings(_DataContext,
                                                                                 TextBoxMediaOceanImportSettings_FTPAddress.Text,
                                                                                 TextBoxMediaOceanImportSettings_FTPUser.Text,
                                                                                 TextBoxMediaOceanImportSettings_FTPPassword.Text,
                                                                                 TextBoxMediaOceanImportSettings_LocalFolder.Text,
                                                                                 ComboBoxMediaOceanImportSettings_Employee.SelectedValue,
                                                                                 ImportType)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(_DbContext) Then

                    TextBoxMediaOceanImportSettings_LocalFolder.Enabled = False

                End If

                If ImportType = 1 Then

                    RadioButtonMediaOceanImportSetting_ImportTypeDefault.Checked = True

                ElseIf ImportType = 2 Then

                    RadioButtonMediaOceanImportSetting_ImportTypeGLIFace.Checked = True

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveMediaOceanImportSettings()

            Dim ImportType As Short = 0

            If RadioButtonMediaOceanImportSetting_ImportTypeDefault.Checked Then

                ImportType = 1

            ElseIf RadioButtonMediaOceanImportSetting_ImportTypeGLIFace.Checked Then

                ImportType = 2

            End If

            AdvantageFramework.Services.MediaOceanImport.SaveSettings(_DataContext, DateTimePickerMediaOceanImportSettings_RunAt.Value)

            AdvantageFramework.Services.MediaOceanImport.SaveServiceSettings(_DataContext,
                                                                             TextBoxMediaOceanImportSettings_FTPAddress.Text,
                                                                             TextBoxMediaOceanImportSettings_FTPUser.Text,
                                                                             TextBoxMediaOceanImportSettings_FTPPassword.Text,
                                                                             TextBoxMediaOceanImportSettings_LocalFolder.Text,
                                                                             ComboBoxMediaOceanImportSettings_Employee.SelectedValue,
                                                                             ImportType)

        End Sub

#End Region

#Region "  CSI Preferred Partner "

        Private Sub CSIPreferredPartnerEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetCSIPreferredPartnerStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetCSIPreferredPartnerStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelCSIPreferredPartner_StatusDescription, Message)

        End Sub
        Private Sub LoadCSIPreferredPartnerSettings()

            'objects
            Dim DownloadFolder As String = ""
            Dim UploadFolder As String = ""
            Dim ImportFolder As String = ""

            If _IsAgencyASP = False Then

                AdvantageFramework.Services.CSIPreferredPartner.LoadSettings(_DataContext, TextBoxCSIPreferredPartnerSettings_DownloadFolder.Text, TextBoxCSIPreferredPartnerSettings_UploadFolder.Text)

            Else

                If _DbContext IsNot Nothing Then

                    ImportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(_DbContext), "\")

                    DownloadFolder = ImportFolder & "CSI\Download"
                    UploadFolder = ImportFolder & "CSI\Upload"

                End If

                TextBoxCSIPreferredPartnerSettings_DownloadFolder.Text = DownloadFolder
                TextBoxCSIPreferredPartnerSettings_UploadFolder.Text = UploadFolder

            End If

        End Sub
        Private Sub SaveCSIPreferredPartnerSettings()

            AdvantageFramework.Services.CSIPreferredPartner.SaveSettings(_DataContext, TextBoxCSIPreferredPartnerSettings_DownloadFolder.Text, TextBoxCSIPreferredPartnerSettings_UploadFolder.Text)

        End Sub

#End Region

#Region "  JobComp UDF Import "

        Private Sub JobCompUDFImportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetJobCompUDFImportStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetJobCompUDFImportStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelJobCompUDFImport_StatusDescription, Message)

        End Sub
        Private Sub LoadJobCompUDFImportSettings()

            AdvantageFramework.Services.JobCompUDFImport.LoadSettings(_DataContext, DateTimePickerJobCompUDFImportSettings_RunAt.Value, TextBoxJobCompUDFImportSettings_ImportPath.Text)

        End Sub
        Private Sub SaveJobCompUDFImportSettings()

            AdvantageFramework.Services.JobCompUDFImport.SaveSettings(_DataContext, DateTimePickerJobCompUDFImportSettings_RunAt.Value, TextBoxJobCompUDFImportSettings_ImportPath.Text)

        End Sub

#End Region

#Region "  Imports "

        Private Sub ImportsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetImportsStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetImportsStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelImports_StatusDescription, Message)

        End Sub
        Private Sub LoadImportsSettings()

            'AdvantageFramework.Services.Imports.LoadSettings(_DataContext)

            DataGridViewImports_AvailableImports.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AdvantageServiceImport.Load(_DbContext).ToList
                                                               Select New AdvantageFramework.Services.Imports.Classes.ImportTemplate(Entity.ImportTemplate, Entity.ID))

            DataGridViewImports_AvailableImports.CurrentView.BestFitColumns()

            DataGridViewImports_AvailableImports.SetBookmarkColumnIndex(0)

            LoadServiceImportSettings()

        End Sub
        Private Sub SaveImportsSettings()

            Dim ImportSetting As AdvantageFramework.Services.Imports.Classes.ImportSetting = Nothing

            PropertyGridControlImports_Properties.CloseEditor()

            'AdvantageFramework.Services.Imports.SaveSettings(_DataContext)

            ImportSetting = PropertyGridControlImports_Properties.SelectedObject
            ImportSetting.Save(_DataContext)

        End Sub
        Private Sub LoadServiceImportSettings()

            Dim AdvantageServiceImportID As Integer = 0
            Dim ImportSetting As AdvantageFramework.Services.Imports.Classes.ImportSetting = Nothing
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            AdvantageServiceImportID = DataGridViewImports_AvailableImports.GetFirstSelectedRowBookmarkValue()

            If AdvantageServiceImportID <> 0 Then

                ImportSetting = New AdvantageFramework.Services.Imports.Classes.ImportSetting(AdvantageServiceImportID, _DataContext)

                PropertyGridControlImports_Properties.SelectedObject = ImportSetting

                BaseRow = Me.PropertyGridControlImports_Properties.GetRowByFieldName("OverridePath")

                If BaseRow IsNot Nothing Then

                    AddSubItemTextBox(BaseRow, SubItemTextBox.Type.Folder, Me.PropertyGridControlImports_Properties)

                End If

                BaseRow = Me.PropertyGridControlImports_Properties.GetRowByFieldName("EmployeeCode")

                If BaseRow IsNot Nothing Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        SubItemGridLookUpEditControl.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                    End If

                End If
            End If

        End Sub

#End Region

#Region " Exports "

        Private Sub ExportsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetExportsStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetExportsStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelImports_StatusDescription, Message)

        End Sub
        Private Sub LoadExportsSettings()

            DataGridViewExports_AvailableExports.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AdvantageServiceExport.Load(_DbContext).ToList
                                                               Select New AdvantageFramework.Services.Exports.Classes.ExportTemplate(Entity.ExportTemplate, Entity.ID))

            DataGridViewExports_AvailableExports.CurrentView.BestFitColumns()

            DataGridViewExports_AvailableExports.SetBookmarkColumnIndex(0)

            LoadServiceExportSettings()

        End Sub
        Private Sub SaveExportsSettings()

            Dim ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting = Nothing

            PropertyGridControlExports_Properties.CloseEditor()

            ExportSetting = PropertyGridControlExports_Properties.SelectedObject
            ExportSetting.Save(_DataContext)

        End Sub
        Private Sub LoadServiceExportSettings()

            Dim AdvantageServiceExportID As Integer = 0
            Dim AdvantageServiceExport As AdvantageFramework.Database.Entities.AdvantageServiceExport = Nothing
            Dim ExportTemplateType As Integer = 0
            Dim ExportSetting As AdvantageFramework.Services.Exports.Classes.ExportSetting = Nothing
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim Folder As String = Nothing

            AdvantageServiceExportID = DataGridViewExports_AvailableExports.GetFirstSelectedRowBookmarkValue()
            ExportTemplateType = DataGridViewExports_AvailableExports.CurrentView.GetFocusedRowCellValue(AdvantageFramework.Services.Exports.Classes.ExportTemplate.Properties.ExportTemplateType.ToString)

            If AdvantageServiceExportID <> 0 Then

                AdvantageServiceExport = (From Entity In AdvantageFramework.Database.Procedures.AdvantageServiceExport.Load(_DbContext)
                                          Where Entity.ID = AdvantageServiceExportID
                                          Select Entity).SingleOrDefault

                ExportSetting = New AdvantageFramework.Services.Exports.Classes.ExportSetting(AdvantageServiceExport, _DataContext)

                If _IsAgencyASP Then

                    Folder = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(_DbContext)

                    If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\")) Then

                        Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder.Trim, "\") & "Reports\"

                        If My.Computer.FileSystem.DirectoryExists(Folder) = False Then

                            My.Computer.FileSystem.CreateDirectory(Folder)

                        End If

                    End If

                    ExportSetting.ExportPath = Folder

                End If

                PropertyGridControlExports_Properties.SelectedObject = ExportSetting

                BaseRow = Me.PropertyGridControlExports_Properties.GetRowByFieldName("ExportPath")

                If BaseRow IsNot Nothing Then

                    AddSubItemTextBox(BaseRow, SubItemTextBox.Type.Folder, Me.PropertyGridControlExports_Properties)

                End If

                BaseRow = Me.PropertyGridControlExports_Properties.GetRowByFieldName(AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.RunAt.ToString)

                If BaseRow IsNot Nothing Then

                    AddSubItemTimeEdit(BaseRow, Me.PropertyGridControlExports_Properties)

                End If

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(PropertyGridControlExports_Properties.SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    BaseRow = PropertyGridControlExports_Properties.GetRowByFieldName(PropertyDescriptor.Name)

                    If BaseRow IsNot Nothing Then

                        BaseRow.Visible = ExportSetting.IsExportSettingCodeUsed(PropertyDescriptor.Name)

                        If BaseRow.Visible Then

                            If BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.ChangeToProcessControl.ToString OrElse
                                    BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.CurrentProcessControl.ToString OrElse
                                    BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.CurrentProcessControl2.ToString Then

                                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl()

                                SubItemGridLookUpEditControl.ValueType = GetType(Short)

                                If BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.CurrentProcessControl2.ToString Then

                                    SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                Else

                                    SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.Nothing

                                End If

                                SubItemGridLookUpEditControl.ControlType = Presentation.Controls.SubItemGridLookUpEditControl.Type.JobProcessControl
                                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                                SubItemGridLookUpEditControl.DataSource = AdvantageFramework.Database.Procedures.JobProcess.Load(_DataContext)

                                PropertyGridControlExports_Properties.RepositoryItems.Add(SubItemGridLookUpEditControl)

                                BaseRow.Properties.RowEdit = SubItemGridLookUpEditControl

                            ElseIf BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.NumberOfDaysOldCutoff.ToString Then

                                If BaseRow.Properties.RowEdit IsNot Nothing AndAlso TypeOf BaseRow.Properties.RowEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput Then

                                    DirectCast(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MinValue = 0

                                End If

                            ElseIf BaseRow.Properties.FieldName = AdvantageFramework.Services.Exports.Classes.ExportSetting.Properties.ProcessNowTransactionDate.ToString Then

                                BaseRow.Properties.RowEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemDateEdit

                            End If

                        End If

                    End If

                Next

            End If

        End Sub
        Protected Sub AddSubItemTimeEdit(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal PropertyGridContol As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl)

            'objects
            Dim SubItemTimeInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemTimeInput = Nothing

            SubItemTimeInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTimeEdit(SubItemTimeInput.Type.HourAndMinute)

            SubItemTimeInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret

            If SubItemTimeInput IsNot Nothing Then

                PropertyGridContol.RepositoryItems.Add(SubItemTimeInput)

                BaseRow.Properties.RowEdit = SubItemTimeInput

            End If

        End Sub
        Private Function LoadSelectedAdvantageServiceExport() As AdvantageFramework.Database.Entities.AdvantageServiceExport

            'objects
            Dim AdvantageServiceExportID As Integer = 0
            Dim AdvantageServiceExport As AdvantageFramework.Database.Entities.AdvantageServiceExport = Nothing

            AdvantageServiceExportID = DataGridViewExports_AvailableExports.GetFirstSelectedRowBookmarkValue()

            AdvantageServiceExport = (From Entity In AdvantageFramework.Database.Procedures.AdvantageServiceExport.Load(_DbContext)
                                      Where Entity.ID = AdvantageServiceExportID
                                      Select Entity).SingleOrDefault

            LoadSelectedAdvantageServiceExport = AdvantageServiceExport

        End Function

#End Region

#Region "  Vendor Contract "

        Private Sub VendorContractEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetVendorContractStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetVendorContractStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelVendorContracts_StatusDescription, Message)

        End Sub
        Private Sub LoadVendorContractSettings()

            AdvantageFramework.Services.VendorContract.LoadSettings(_DataContext, DateTimePickerVendorContractSettings_RunAt.Value, CheckBoxVendorContractNotifications_ContractRenewal.Checked, NumericInputVendorContractNotifications_DaysPrior.EditValue)

        End Sub
        Private Sub SaveVendorContractAlertSettings()

            AdvantageFramework.Services.VendorContract.SaveSettings(_DataContext, DateTimePickerVendorContractSettings_RunAt.Value, CheckBoxVendorContractNotifications_ContractRenewal.Checked, NumericInputVendorContractNotifications_DaysPrior.EditValue)

        End Sub

#End Region

#Region "  Currency Exchange "

        Private Sub CurrencyExchangeEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetCurrencyExchangeStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetCurrencyExchangeStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelCurrencyExchange_StatusDescription, Message)

        End Sub
        Private Sub LoadCurrencyExchangeSettings()

            AdvantageFramework.Services.CurrencyExchange.LoadSettings(_DataContext, DateTimePickerCurrencyExchangeSettings_Interval_RunAtTime.Value)

        End Sub
        Private Sub SaveCurrencyExchangeSettings()

            AdvantageFramework.Services.CurrencyExchange.SaveSettings(_DataContext, DateTimePickerCurrencyExchangeSettings_Interval_RunAtTime.Value)

        End Sub

#End Region

#Region "  VCC "

        Private Sub VCCEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetVCCStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetVCCStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelVCC_StatusDescription, Message)

        End Sub
        Private Sub LoadVCCSettings()

            Dim Schedule As AdvantageFramework.Services.Classes.Schedule = Nothing

            Schedule = New AdvantageFramework.Services.Classes.Schedule

            AdvantageFramework.Services.VCC.LoadSettings(_DataContext, Schedule)

            ScheduleControlVCCSettings_Schedule.LoadControl(Schedule)

        End Sub
        Private Sub SaveVCCSettings()

            Dim Schedule As AdvantageFramework.Services.Classes.Schedule = Nothing

            Schedule = ScheduleControlVCCSettings_Schedule.GetSettings

            AdvantageFramework.Services.VCC.SaveSettings(_DataContext, Schedule)

        End Sub

#End Region

#Region "  Nielsen "

        Private Sub NielsenEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetNielsenStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetNielsenStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelNielsen_StatusDescription, Message)

        End Sub
        Private Sub LoadNielsenSettings()

            ComboBoxNielsenSettings_Employee.DataSource = AdvantageFramework.Services.Nielsen.LoadEmployees(_DbContext)

            AdvantageFramework.Services.Nielsen.LoadSettings(_DataContext, DateTimePickerNielsenSettings_RunAtDaily.Value, ComboBoxNielsenSettings_Employee.SelectedValue)

        End Sub
        Private Sub SaveNielsenSettings()

            AdvantageFramework.Services.Nielsen.SaveSettings(_DataContext, DateTimePickerNielsenSettings_RunAtDaily.Value, ComboBoxNielsenSettings_Employee.GetSelectedValue)

        End Sub

#End Region

#Region "  Time Sheet "

        Private Sub SetTimeSheetStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelTimeSheet_StatusDescription, Message)

        End Sub
        Private Sub LoadTimeSheetSettings()

            AdvantageFramework.Services.CalendarTimeSheetImport.LoadSettings(_DataContext, NumericInputTimeSheetSettings_RunAtEvery.EditValue, NumericInput_Timesheet.EditValue, Nothing)

        End Sub
        Private Sub SaveTimeSheetSettings()

            AdvantageFramework.Services.CalendarTimeSheetImport.SaveSettings(_DataContext, NumericInputTimeSheetSettings_RunAtEvery.EditValue, NumericInput_Timesheet.EditValue)

        End Sub
        Private Sub TimeSheetEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetTimeSheetStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Scheduled Reports "

        Private Sub ScheduledReportsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetScheduledReportsStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetScheduledReportsStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelScheduledReports_StatusDescription, Message)

        End Sub
        Private Sub LoadScheduledReportsSettings()

            'objects
            Dim OutputFolder As String = ""

            If _IsAgencyASP = False Then

                AdvantageFramework.Services.ScheduledReports.LoadSettings(_DataContext, TextBoxScheduledReportsSettings_OutputFolder.Text)

            Else

                If _DbContext IsNot Nothing Then

                    OutputFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(_DbContext), "\")

                    OutputFolder = OutputFolder & "ScheduledReports"

                End If

                TextBoxScheduledReportsSettings_OutputFolder.Text = OutputFolder

            End If

            ScheduledReportControlScheduledReports_ScheduledReports.LoadControl(False, DatabaseProfile:=Me.SelectedDatabaseProfile)

        End Sub
        Private Sub SaveScheduledReportsSettings()

            If _IsAgencyASP = False Then

                AdvantageFramework.Services.ScheduledReports.SaveSettings(_DataContext, TextBoxScheduledReportsSettings_OutputFolder.Text)

            End If

            ScheduledReportControlScheduledReports_ScheduledReports.Save()

        End Sub
        Private Sub ScheduledReportControlScheduledReports_ScheduledReports_ScheduledReportChangedEvent() Handles ScheduledReportControlScheduledReports_ScheduledReports.ScheduledReportChangedEvent

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  comScore "

        Private Sub ComScoreEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetComScoreStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetComScoreStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelComScore_StatusDescription, Message)

        End Sub
        Private Sub LoadComScoreSettings()

            ComboBoxComScoreSettings_Employee.DataSource = AdvantageFramework.Services.ComScore.LoadEmployees(_DbContext)

            AdvantageFramework.Services.ComScore.LoadSettings(_DataContext, DateTimePickerComScoreSettings_RunAtDaily.Value, ComboBoxComScoreSettings_Employee.SelectedValue)

        End Sub
        Private Sub SaveComScoreSettings()

            AdvantageFramework.Services.ComScore.SaveSettings(_DataContext, DateTimePickerComScoreSettings_RunAtDaily.Value, ComboBoxComScoreSettings_Employee.GetSelectedValue)

        End Sub

#End Region

#Region "  InOut Board "

        Private Sub InOutEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetInoutStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetInoutStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelInOut_StatusDescription, Message)

        End Sub
        Private Sub LoadInOutSettings()

            AdvantageFramework.Services.InOutBoard.LoadSettings(_DataContext, DateTimePickerInOutSettings_RunAtDaily.Value)

        End Sub
        Private Sub SaveInOutSettings()

            AdvantageFramework.Services.InOutBoard.SaveSettings(_DataContext, DateTimePickerInOutSettings_RunAtDaily.Value)

        End Sub

#End Region

#Region "  Automated Assignments "

        Private Sub SetAutomatedAssignmentsStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelAutomatedAssignments_StatusDescription, Message)

        End Sub
        Private Sub LoadAutomatedAssignmentsSettings()

            AdvantageFramework.Services.AutomatedAssignments.LoadSettings(_DataContext, NumericInputAutomatedAssignmentsSettings_RunAtEvery.EditValue)

        End Sub
        Private Sub SaveAutomatedAssignmentsSettings()

            AdvantageFramework.Services.AutomatedAssignments.SaveSettings(_DataContext, NumericInputAutomatedAssignmentsSettings_RunAtEvery.EditValue)

        End Sub
        Private Sub AutomatedAssignmentsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetAutomatedAssignmentsStatus(EventLogEntry.Message & "....")

        End Sub

#End Region

#Region "  Document Repository Capacity Warning "

        Private Sub DocumentRepositoryCapacityWarningEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetDocumentRepositoryCapacityWarningStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetDocumentRepositoryCapacityWarningStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelDocumentRepositoryCapacityWarning_StatusDescription, Message)

        End Sub
        Private Sub LoadDocumentRepositoryCapacityWarningSettings()

            AdvantageFramework.Services.DocumentRepositoryCapacityWarning.LoadSettings(_DataContext, DateTimePickerDocumentRepositoryCapacityWarningSettings_RunAt.Value, TextBoxDocumentRepositoryCapacityWarningSettings_Email.Text, NumericInputDocumentRepositoryCapacityWarningSettings_Threshold.Value)

        End Sub
        Private Sub SaveDocumentRepositoryCapacityWarningSettings()

            AdvantageFramework.Services.DocumentRepositoryCapacityWarning.SaveSettings(_DataContext, DateTimePickerDocumentRepositoryCapacityWarningSettings_RunAt.Value, TextBoxDocumentRepositoryCapacityWarningSettings_Email.Text, NumericInputDocumentRepositoryCapacityWarningSettings_Threshold.GetValue)

        End Sub

#End Region

#Region "  Nielsen Puerto Rico "

        Private Sub NielsenPuertoRicoEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

            SetNielsenPuertoRicoStatus(EventLogEntry.Message & "....")

        End Sub
        Private Sub SetNielsenPuertoRicoStatus(ByVal Message As String)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelNielsenPuertoRico_StatusDescription, Message)

        End Sub
        Private Sub LoadNielsenPuertoRicoSettings()

            ComboBoxNielsenPuertoRicoSettings_Employee.DataSource = AdvantageFramework.Services.NielsenPuertoRico.LoadEmployees(_DbContext)

            AdvantageFramework.Services.NielsenPuertoRico.LoadSettings(_DataContext, DateTimePickerNielsenPuertoRicoSettings_RunAtDaily.Value, ComboBoxNielsenPuertoRicoSettings_Employee.SelectedValue, TextBoxNielsenPuertoRicoSettings_LocalFolder.Text)

        End Sub
        Private Sub SaveNielsenPuertoRicoSettings()

            AdvantageFramework.Services.NielsenPuertoRico.SaveSettings(_DataContext, DateTimePickerNielsenPuertoRicoSettings_RunAtDaily.Value, ComboBoxNielsenPuertoRicoSettings_Employee.GetSelectedValue, TextBoxNielsenPuertoRicoSettings_LocalFolder.GetText)

        End Sub

#End Region

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Private Sub EnableOrDisableActions()

            If _SelectedDatabaseProfile IsNot Nothing Then

                TabControlPanelSettingsTab_EmailListenerSettings.Enabled = True
                TabControlPanelQvAAlertSettings_QvAAlertSettings.Enabled = True
                TabControlPanelSettingsTab_MediaExportSettings.Enabled = True
                TabControlPanelCriteriaTab_ExportCriteria.Enabled = True
                TabControlPanelSettingsTab_TaskSettings.Enabled = True
                TabControlPanelSettingsTab_MissingTimeSettings.Enabled = True
                TabControlPanelAlertsTab_Alerts.Enabled = True
                TabControlPanelCalendarSettingsTab_CalendarSettings.Enabled = True
                TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Enabled = True
                TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Enabled = True
                TabControlPanelContractSettingsTab_ContractSettings.Enabled = True
                TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Enabled = True
                TabControlPanelCSIPreferredPartnerSettingsTab_CSIPreferredPartnerSettings.Enabled = True
                TabControlPanelJobCompUDFImportSettingsTab_JobCompUDFImportSettings.Enabled = True
                TabControlPanelImportsSettingsTab_ImportsSettings.Enabled = True
                TabControlPanelVendorContractsTab_VendorContracts.Enabled = True
                TabControlPanelCurrencyExchangeTab_CurrencyExchange.Enabled = True
                TabControlPanelVCCTab_VCC.Enabled = True
                TabControlPanelTimeSheetTab_TimeSheet.Enabled = True
                TabControlPanelScheduledReportsTab_ScheduledReports.Enabled = True
                TabControlPanelComScoreTab_ComScore.Enabled = True
                TabControlPanelInOutTab_InOut.Enabled = True
                TabControlPanelAutomatedAssignmentsSettingsTab_AutomatedAssignmentsSettings.Enabled = True
                TabControlPanelDocumentRepositoryCapacityWarningSettingsTab_DocumentRepositoryCapacityWarningSettings.Enabled = True
                TabControlPanelNielsenPuertoRicoSettingsTab_NielsenPuertoRicoSettings.Enabled = True

            Else

                TabControlPanelSettingsTab_EmailListenerSettings.Enabled = False
                TabControlPanelQvAAlertSettings_QvAAlertSettings.Enabled = False
                TabControlPanelSettingsTab_MediaExportSettings.Enabled = False
                TabControlPanelCriteriaTab_ExportCriteria.Enabled = False
                TabControlPanelSettingsTab_TaskSettings.Enabled = False
                TabControlPanelSettingsTab_MissingTimeSettings.Enabled = False
                TabControlPanelAlertsTab_Alerts.Enabled = False
                TabControlPanelCalendarSettingsTab_CalendarSettings.Enabled = False
                TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Enabled = False
                TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Enabled = False
                TabControlPanelContractSettingsTab_ContractSettings.Enabled = False
                TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Enabled = False
                TabControlPanelCSIPreferredPartnerSettingsTab_CSIPreferredPartnerSettings.Enabled = False
                TabControlPanelJobCompUDFImportSettingsTab_JobCompUDFImportSettings.Enabled = False
                TabControlPanelImportsSettingsTab_ImportsSettings.Enabled = False
                TabControlPanelVendorContractsTab_VendorContracts.Enabled = False
                TabControlPanelCurrencyExchangeTab_CurrencyExchange.Enabled = False
                TabControlPanelVCCTab_VCC.Enabled = False
                TabControlPanelTimeSheetTab_TimeSheet.Enabled = False
                TabControlPanelScheduledReportsTab_ScheduledReports.Enabled = False
                TabControlPanelComScoreTab_ComScore.Enabled = False
                TabControlPanelInOutTab_InOut.Enabled = False
                TabControlPanelAutomatedAssignmentsSettingsTab_AutomatedAssignmentsSettings.Enabled = False
                TabControlPanelDocumentRepositoryCapacityWarningSettingsTab_DocumentRepositoryCapacityWarningSettings.Enabled = False
                TabControlPanelNielsenPuertoRicoSettingsTab_NielsenPuertoRicoSettings.Enabled = False

            End If

            RaiseEvent EnableOrDisableActionsEvent()

        End Sub
        Private Sub EnableOrDisableServiceActions()

            RaiseEvent EnableOrDisableServiceActionsEvent()

        End Sub
        Private Sub LoadServiceSettings(ByVal LoadAll As Boolean, Optional ByVal ServiceCode As String = Nothing)

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageWindowsService.ToString Then

                LoadEmailListenerSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageQvAAlertWindowsService.ToString Then

                LoadQvAAlertSettings()

                ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndex = _SendAlertTo

                ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndex = _SetAlertLevel

                ComboBoxQvAAlertSettings_ShowLevel.SelectedIndex = _ShowLevel

                NumericInputThresholds_Level1Start.EditValue = _QvAAlertLevel1Start
                NumericInputThresholds_Level1End.EditValue = _QvAAlertLevel1End
                TextBoxThresholds_Level1Description.Text = _QvAAlertLevel1Description

                NumericInputThresholds_Level2Start.EditValue = _QvAAlertLevel2Start
                NumericInputThresholds_Level2End.EditValue = _QvAAlertLevel2End
                TextBoxThresholds_Level2Description.Text = _QvAAlertLevel2Description

                NumericInputThresholds_Level3Start.EditValue = _QvAAlertLevel3Start
                TextBoxThresholds_Level3Description.Text = _QvAAlertLevel3Description

                CheckBoxThresholds_Level1.Checked = _QvAAlertLevel1Enabled
                CheckBoxThresholds_Level2.Checked = _QvAAlertLevel2Enabled
                CheckBoxThresholds_Level3.Checked = _QvAAlertLevel3Enabled

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageExportWindowsService.ToString Then

                LoadMediaExportSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageTaskWindowsService.ToString Then

                LoadTaskSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageMissingTimeWindowsService.ToString Then

                LoadMissingTimeSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageCalendarWindowsService.ToString Then

                LoadCalendarSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString Then

                LoadCoreMediaCheckExportSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageContractWindowsService.ToString Then

                LoadContractSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageMediaOceanImportWindowsService.ToString Then

                LoadMediaOceanImportSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString Then

                LoadPaidTimeOffAccrualsSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString Then

                LoadCSIPreferredPartnerSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageJobCompUDFImportWindowsService.ToString Then

                LoadJobCompUDFImportSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageImportTemplateWindowsService.ToString Then

                LoadImportsSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageExportTemplateWindowsService.ToString Then

                LoadExportsSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageVendorContractWindowsService.ToString Then

                LoadVendorContractSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageCurrencyExchangeWindowsService.ToString Then

                LoadCurrencyExchangeSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageVCCWindowsService.ToString Then

                LoadVCCSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageNielsenWindowsService.ToString Then

                LoadNielsenSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageCalendarTimeSheetImportService.ToString Then

                LoadTimeSheetSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageScheduledReportsService.ToString Then

                LoadScheduledReportsSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageComScoreWindowsService.ToString Then

                LoadComScoreSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageInOutWindowService.ToString Then

                LoadInOutSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageAutomatedAssignmentsService.ToString Then

                LoadAutomatedAssignmentsSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString Then

                LoadDocumentRepositoryCapacityWarningSettings()

            End If

            If LoadAll OrElse ServiceCode = Services.Service.AdvantageNielsenPuertoRicoWindowsService.ToString Then

                LoadNielsenPuertoRicoSettings()

            End If

        End Sub
        Private Function CheckUserEntryChangedSetting(ByVal TabItem As DevComponents.DotNetBar.TabItem) As Boolean

            'objects
            Dim UserEntryChanged As Boolean = False

            If TabItem Is TabItemServices_EmailListenerTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelEmailListenerTab_EmailListener)

            ElseIf TabItem Is TabItemServices_QvAAlertTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelQvAAlertTab_QvAAlert)

            ElseIf TabItem Is TabItemServices_MediaExportTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelExportTab_Export)

            ElseIf TabItem Is TabItemServices_TasksTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelTasksTab_Tasks)

            ElseIf TabItem Is TabItemServices_MissingTimeTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelMissingTimeTab_MissingTime)

            ElseIf TabItem Is TabItemServices_CalendarTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelCalendarTab_Calendar)

            ElseIf TabItem Is TabItemServices_CoreMediaCheckExportTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport)

            ElseIf TabItem Is TabItemServices_PaidTimeOffAccrualsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals)

            ElseIf TabItem Is TabItemServices_ContractTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelContractTab_Contract)

            ElseIf TabItem Is TabItemServices_MediaOceanImportTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelMediaOceanImportTab_MediaOceanImport)

            ElseIf TabItem Is TabItemServices_CSIPreferredPartnerTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelCSIPreferredPartnerTab_CSIPreferredPartner)

            ElseIf TabItem Is TabItemServices_JobCompUDFImportTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelJobCompUDFImportTab_JobCompUDFImport)

            ElseIf TabItem Is TabItemServices_ImportsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelImportsTab_Imports)

            ElseIf TabItem Is TabItemServices_ExportsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelExportsTab_Exports)

            ElseIf TabItem Is TabItemServices_VendorContractsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelVendorContractsTab_VendorContracts)

            ElseIf TabItem Is TabItemServices_CurrencyExchangeTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelCurrencyExchangeTab_CurrencyExchange)

            ElseIf TabItem Is TabItemServices_VCCTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelVCCTab_VCC)

            ElseIf TabItem Is TabItemServices_NielsenTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelNielsenTab_Nielsen)

            ElseIf TabItem Is TabItemServices_CalendarTimesheetTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelTimeSheetTab_TimeSheet)

            ElseIf TabItem Is TabItemServices_ScheduledReportsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelScheduledReportsTab_ScheduledReports)

            ElseIf TabItem Is TabItemServices_ComscoreTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelComScoreTab_ComScore)

            ElseIf TabItem Is TabItemServices_AutomatedAssignmentsTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments)

            ElseIf TabItem Is TabItemServices_DocumentRepositoryCapacityWarningTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelDocumentRepositoryCapacityWarningTab_DocumentRepositoryCapacityWarning)

            ElseIf TabItem Is TabItemServices_NielsenPuertoRicoTab Then

                UserEntryChanged = AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(TabControlPanelNielsenPuertoRicoTab_NielsenPuertoRico)

            End If

            CheckUserEntryChangedSetting = UserEntryChanged

        End Function
        Private Sub ClearChanged(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is TabItemServices_EmailListenerTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelEmailListenerTab_EmailListener)

            ElseIf TabItem Is TabItemServices_QvAAlertTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelQvAAlertTab_QvAAlert)

            ElseIf TabItem Is TabItemServices_MediaExportTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelExportTab_Export)

            ElseIf TabItem Is TabItemServices_TasksTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelTasksTab_Tasks)

            ElseIf TabItem Is TabItemServices_MissingTimeTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelMissingTimeTab_MissingTime)

            ElseIf TabItem Is TabItemServices_CalendarTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelCalendarTab_Calendar)

            ElseIf TabItem Is TabItemServices_CoreMediaCheckExportTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport)

            ElseIf TabItem Is TabItemServices_PaidTimeOffAccrualsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals)

            ElseIf TabItem Is TabItemServices_ContractTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelContractTab_Contract)

            ElseIf TabItem Is TabItemServices_MediaOceanImportTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelMediaOceanImportTab_MediaOceanImport)

            ElseIf TabItem Is TabItemServices_CSIPreferredPartnerTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelCSIPreferredPartnerTab_CSIPreferredPartner)

            ElseIf TabItem Is TabItemServices_JobCompUDFImportTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelJobCompUDFImportTab_JobCompUDFImport)

            ElseIf TabItem Is TabItemServices_ImportsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelImportsTab_Imports)

            ElseIf TabItem Is TabItemServices_ExportsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelExportsTab_Exports)

            ElseIf TabItem Is TabItemServices_VendorContractsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelVendorContractsTab_VendorContracts)

            ElseIf TabItem Is TabItemServices_CurrencyExchangeTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelCurrencyExchangeTab_CurrencyExchange)

            ElseIf TabItem Is TabItemServices_VCCTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelVCCTab_VCC)

            ElseIf TabItem Is TabItemServices_NielsenTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelNielsenTab_Nielsen)

            ElseIf TabItem Is TabItemServices_CalendarTimesheetTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelTimeSheetTab_TimeSheet)

            ElseIf TabItem Is TabItemServices_ScheduledReportsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelScheduledReportsTab_ScheduledReports)

            ElseIf TabItem Is TabItemServices_ComscoreTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelComScoreTab_ComScore)

            ElseIf TabItem Is TabItemServices_AutomatedAssignmentsTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelAutomatedAssignmentsTab_AutomatedAssignments)

            ElseIf TabItem Is TabItemServices_DocumentRepositoryCapacityWarningTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelDocumentRepositoryCapacityWarningTab_DocumentRepositoryCapacityWarning)

            ElseIf TabItem Is TabItemServices_NielsenPuertoRicoTab Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(TabControlPanelNielsenPuertoRicoTab_NielsenPuertoRico)

            End If

        End Sub
        Private Sub SaveSettings(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is TabItemServices_EmailListenerTab Then

                SaveEmailListenerSettings()

            ElseIf TabItem Is TabItemServices_QvAAlertTab Then

                SaveQvAAlertSettings()

            ElseIf TabItem Is TabItemServices_MediaExportTab Then

                SaveMediaExportSettings()

            ElseIf TabItem Is TabItemServices_TasksTab Then

                SaveTaskSettings()

            ElseIf TabItem Is TabItemServices_MissingTimeTab Then

                SaveMissingTimeSettings()

            ElseIf TabItem Is TabItemServices_CalendarTab Then

                SaveCalendarSettings()

            ElseIf TabItem Is TabItemServices_CoreMediaCheckExportTab Then

                SaveCoreMediaCheckExportSettings()

            ElseIf TabItem Is TabItemServices_PaidTimeOffAccrualsTab Then

                SavePaidTimeOffAccrualsSettings()

            ElseIf TabItem Is TabItemServices_ContractTab Then

                SaveContractAlertSettings()

            ElseIf TabItem Is TabItemServices_MediaOceanImportTab Then

                SaveMediaOceanImportSettings()

            ElseIf TabItem Is TabItemServices_MediaOceanImportTab Then

                SaveMediaOceanImportSettings()

            ElseIf TabItem Is TabItemServices_CSIPreferredPartnerTab Then

                SaveCSIPreferredPartnerSettings()

            ElseIf TabItem Is TabItemServices_JobCompUDFImportTab Then

                SaveJobCompUDFImportSettings()

            ElseIf TabItem Is TabItemServices_ImportsTab Then

                SaveImportsSettings()

            ElseIf TabItem Is TabItemServices_ExportsTab Then

                SaveExportsSettings()

            ElseIf TabItem Is TabItemServices_VendorContractsTab Then

                SaveVendorContractAlertSettings()

            ElseIf TabItem Is TabItemServices_CurrencyExchangeTab Then

                SaveCurrencyExchangeSettings()

            ElseIf TabItem Is TabItemServices_VCCTab Then

                SaveVCCSettings()

            ElseIf TabItem Is TabItemServices_NielsenTab Then

                SaveNielsenSettings()

            ElseIf TabItem Is TabItemServices_CalendarTimesheetTab Then

                SaveTimeSheetSettings()

            ElseIf TabItem Is TabItemServices_ScheduledReportsTab Then

                SaveScheduledReportsSettings()

            ElseIf TabItem Is TabItemServices_ComscoreTab Then

                SaveComScoreSettings()

            ElseIf TabItem Is TabItemServices_InOutTab Then

                SaveInOutSettings()

            ElseIf TabItem Is TabItemServices_AutomatedAssignmentsTab Then

                SaveAutomatedAssignmentsSettings()

            ElseIf TabItem Is TabItemServices_DocumentRepositoryCapacityWarningTab Then

                SaveDocumentRepositoryCapacityWarningSettings()

            ElseIf TabItem Is TabItemServices_NielsenPuertoRicoTab Then

                SaveNielsenPuertoRicoSettings()

            End If

            SetUserChangedValue(True)

        End Sub
        Private Sub SetUserChangedValue(ByVal Changed As Boolean)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If _FromAdvantageServices = False Then

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(_DataContext, AdvantageFramework.Agency.Settings.ADV_SERV_USER_CHANGE.ToString)

                If Setting IsNot Nothing Then

                    Setting.Value = Changed

                    AdvantageFramework.Database.Procedures.Setting.Update(_DataContext, Setting)

                End If

            End If

        End Sub
        Protected Sub AddSubItemTextBox(ByRef BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByVal SubItemTextBoxType As Presentation.Controls.SubItemTextBox.Type, ByVal PropertyGridContol As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl)

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing

            SubItemTextBox = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemTextBox(Nothing, SubItemTextBoxType, BaseRow.Properties.FieldName, PropertyGridContol.SelectedObject.GetType)

            If SubItemTextBox IsNot Nothing Then

                PropertyGridContol.RepositoryItems.Add(SubItemTextBox)

                BaseRow.Properties.RowEdit = SubItemTextBox

            End If

        End Sub

#Region "  Public "

        Public Sub EnableOrDisableService()

            If _SelectedAdvantageService IsNot Nothing Then

                If _SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString Then

                    If AdvantageFramework.CSIPreferredPartner.HasAgreementBeenSigned(_DbContext, _DataContext) = False Then

                        If _SelectedAdvantageService.Enabled = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please sign up for our CSI Preferred Partner if you wish to enable this service.  Please contact Software Support with any questions.")

                        End If

                        _SelectedAdvantageService.Enabled = False

                    Else

                        _SelectedAdvantageService.Enabled = Not _SelectedAdvantageService.Enabled

                    End If

                    'ElseIf _SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString Then

                    '    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(_DbContext) Then

                    '        If _SelectedAdvantageService.Enabled = False Then

                    '            AdvantageFramework.WinForm.MessageBox.Show("This service cannot be enabled for Hosted clients.  Please contact Software Support with any questions.")

                    '        End If

                    '        _SelectedAdvantageService.Enabled = False

                    '    Else

                    '        _SelectedAdvantageService.Enabled = Not _SelectedAdvantageService.Enabled

                    '    End If

                Else

                    _SelectedAdvantageService.Enabled = Not _SelectedAdvantageService.Enabled

                End If

                AdvantageFramework.Database.Procedures.AdvantageService.Update(_DataContext, _SelectedAdvantageService)

                EnableOrDisableServiceActions()

            End If

        End Sub
        Public Sub ProcessNow()

            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

            Try

                If TabControlForm_Services.SelectedTab Is TabItemServices_EmailListenerTab Then

                    AdvantageFramework.Services.EmailListener.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_QvAAlertTab Then

                    AdvantageFramework.Services.QvAAlert.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaExportTab Then

                    AdvantageFramework.Services.MediaExport.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_TasksTab Then

                    AdvantageFramework.Services.Task.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MissingTimeTab Then

                    AdvantageFramework.Services.MissingTime.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CalendarTab Then

                    AdvantageFramework.Services.Calendar.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CoreMediaCheckExportTab Then

                    AdvantageFramework.Services.CoreMediaCheckExport.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_PaidTimeOffAccrualsTab Then

                    AdvantageFramework.Services.PaidTimeOffAccruals.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ContractTab Then

                    AdvantageFramework.Services.Contract.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaOceanImportTab Then

                    AdvantageFramework.Services.MediaOceanImport.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CSIPreferredPartnerTab Then

                    AdvantageFramework.Services.CSIPreferredPartner.ProcessDatabase(_SelectedDatabaseProfile, False)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_JobCompUDFImportTab Then

                    AdvantageFramework.Services.JobCompUDFImport.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ImportsTab Then

                    AdvantageFramework.Services.Imports.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ExportsTab Then

                    AdvantageFramework.Services.Exports.ProcessDatabase(_SelectedDatabaseProfile, LoadSelectedAdvantageServiceExport(), True)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_VendorContractsTab Then

                    AdvantageFramework.Services.VendorContract.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CurrencyExchangeTab Then

                    AdvantageFramework.Services.CurrencyExchange.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_VCCTab Then

                    AdvantageFramework.Services.VCC.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_NielsenTab Then

                    AdvantageFramework.Services.Nielsen.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CalendarTimesheetTab Then

                    AdvantageFramework.Services.CalendarTimeSheetImport.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ScheduledReportsTab Then

                    AdvantageFramework.Services.ScheduledReports.ProcessDatabase(_SelectedDatabaseProfile, True)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ComscoreTab Then

                    AdvantageFramework.Services.ComScore.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_InOutTab Then

                    AdvantageFramework.Services.InOutBoard.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_AutomatedAssignmentsTab Then

                    AdvantageFramework.Services.AutomatedAssignments.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_DocumentRepositoryCapacityWarningTab Then

                    AdvantageFramework.Services.DocumentRepositoryCapacityWarning.ProcessDatabase(_SelectedDatabaseProfile)

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_NielsenPuertoRicoTab Then

                    AdvantageFramework.Services.NielsenPuertoRico.ProcessDatabase(_SelectedDatabaseProfile)

                End If

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub
        Public Sub SelectDatabaseProfile(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim HasUnsavedChanges As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            For Each TabItem In TabControlForm_Services.Tabs

                If CheckUserEntryChangedSetting(TabItem) Then

                    HasUnsavedChanges = True
                    Exit For

                End If

            Next

            If HasUnsavedChanges Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    For Each TabItem In TabControlForm_Services.Tabs

                        If CheckUserEntryChangedSetting(TabItem) Then

                            SaveSettings(TabItem)

                            ClearChanged(TabItem)

                            _ServicesChangedDictionary(TabItem.Tag) = False

                        End If

                    Next

                Else

                    For Each TabItem In TabControlForm_Services.Tabs

                        _ServicesChangedDictionary(TabItem.Tag) = False

                    Next

                End If

                RaiseEvent EnableOrDisableSaveEvent(False)

            End If

            _SelectedDatabaseProfile = Nothing
            _SelectedAdvantageService = Nothing
            _AdvantageServices = Nothing

            Try

                AdvantageFramework.Database.CloseDataContext(_DataContext)

            Catch ex As Exception

            End Try

            Try

                AdvantageFramework.Database.CloseDbContext(_DbContext)

            Catch ex As Exception

            End Try

            Try

                AdvantageFramework.Database.CloseDbContext(_SecurityDbContext)

            Catch ex As Exception

            End Try

            If DatabaseProfile IsNot Nothing Then

                _SelectedDatabaseProfile = DatabaseProfile

                _DataContext = New AdvantageFramework.Database.DataContext(_SelectedDatabaseProfile.ConnectionString, _SelectedDatabaseProfile.DatabaseUserName)
                _DbContext = New AdvantageFramework.Database.DbContext(_SelectedDatabaseProfile.ConnectionString, _SelectedDatabaseProfile.DatabaseUserName)
                _SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_SelectedDatabaseProfile.ConnectionString, _SelectedDatabaseProfile.DatabaseUserName)

                _AdvantageServices = _DataContext.AdvantageServices.ToList

                _Initialized = False
                AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                Try

                    _SelectedAdvantageService = _AdvantageServices.SingleOrDefault(Function(Entity) Entity.Code = TabControlForm_Services.SelectedTab.Tag)

                Catch ex As Exception
                    _SelectedAdvantageService = Nothing
                End Try

                Try

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(_DataContext, AdvantageFramework.Agency.Settings.NIELSEN_PR_ENABLED.ToString)

                    If Setting IsNot Nothing AndAlso Setting.Value IsNot Nothing AndAlso CInt(Setting.Value) = 1 Then

                        TabItemServices_NielsenPuertoRicoTab.Visible = True

                    Else

                        TabItemServices_NielsenPuertoRicoTab.Visible = False

                    End If

                Catch ex As Exception
                    TabItemServices_NielsenPuertoRicoTab.Visible = False
                End Try

                Try

                    LoadServiceSettings(False, TabControlForm_Services.SelectedTab.Tag)

                Catch ex As Exception

                End Try

                _Initialized = True
                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

            If _Initialized Then

                Try

                    For Each TabItem In TabControlForm_Services.Tabs

                        ClearChanged(TabItem)

                        _ServicesChangedDictionary(TabItem.Tag) = False

                    Next

                Catch ex As Exception

                End Try

                RaiseEvent EnableOrDisableSaveEvent(False)

            End If

            EnableOrDisableActions()
            EnableOrDisableServiceActions()

        End Sub
        Public Sub SaveButtonEnabledChanged(ByVal Enabled As Boolean)

            If TabControlForm_Services.SelectedTab IsNot Nothing Then

                _ServicesChangedDictionary(TabControlForm_Services.SelectedTab.Tag) = Enabled

            End If

        End Sub
        Public Sub SaveSettings()

            SaveSettings(TabControlForm_Services.SelectedTab)

            ClearChanged(TabControlForm_Services.SelectedTab)

            RaiseEvent EnableOrDisableSaveEvent(False)

        End Sub
        Public Sub RefreshLog()

            AdvantageFramework.WinForm.Presentation.ShowWaitForm()

            Try

                If TabControlForm_Services.SelectedTab Is TabItemServices_EmailListenerTab Then

                    TextBoxEmailListenerLog_Log.Text = AdvantageFramework.Services.EmailListener.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_QvAAlertTab Then

                    TextBoxQvAAlertLog_Log.Text = AdvantageFramework.Services.QvAAlert.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaExportTab Then

                    TextBoxExportLog_Log.Text = AdvantageFramework.Services.MediaExport.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_TasksTab Then

                    TextBoxTaskLog_Log.Text = AdvantageFramework.Services.Task.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MissingTimeTab Then

                    TextBoxMissingTimeLog_Log.Text = AdvantageFramework.Services.MissingTime.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CalendarTab Then

                    TextBoxCalendarLog_Log.Text = AdvantageFramework.Services.Calendar.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CoreMediaCheckExportTab Then

                    TextBoxCoreMediaCheckExportLog_Log.Text = AdvantageFramework.Services.CoreMediaCheckExport.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_PaidTimeOffAccrualsTab Then

                    TextBoxPaidTimeOffAccrualsLog_Log.Text = AdvantageFramework.Services.PaidTimeOffAccruals.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ContractTab Then

                    TextBoxContractLog_Log.Text = AdvantageFramework.Services.Contract.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaOceanImportTab Then

                    TextBoxMediaOceanImportLog_Log.Text = AdvantageFramework.Services.MediaOceanImport.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CSIPreferredPartnerTab Then

                    TextBoxCSIPreferredPartnerLog_Log.Text = AdvantageFramework.Services.CSIPreferredPartner.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_JobCompUDFImportTab Then

                    TextBoxJobCompUDFImportLog_Log.Text = AdvantageFramework.Services.JobCompUDFImport.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ImportsTab Then

                    TextBoxImportsLog_Log.Text = AdvantageFramework.Services.Imports.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ExportsTab Then

                    TextBoxExportsLog_Log.Text = AdvantageFramework.Services.Exports.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_VendorContractsTab Then

                    TextBoxVendorContractLog_Log.Text = AdvantageFramework.Services.VendorContract.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CurrencyExchangeTab Then

                    TextBoxCurrencyExchangeLog_Log.Text = AdvantageFramework.Services.CurrencyExchange.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_VCCTab Then

                    TextBoxVCCLog_Log.Text = AdvantageFramework.Services.VCC.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_NielsenTab Then

                    TextBoxNielsenLog_Log.Text = AdvantageFramework.Services.Nielsen.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CalendarTimesheetTab Then

                    TextBoxTimeSheetLog_Log.Text = AdvantageFramework.Services.CalendarTimeSheetImport.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ScheduledReportsTab Then

                    TextBoxScheduledReportsLog_Log.Text = AdvantageFramework.Services.ScheduledReports.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ComscoreTab Then

                    TextBoxComScoreLog_Log.Text = AdvantageFramework.Services.ComScore.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_InOutTab Then

                    TextBoxInOutLog_Log.Text = AdvantageFramework.Services.InOutBoard.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_AutomatedAssignmentsTab Then

                    TextBoxAutomatedAssignmentsLog_Log.Text = AdvantageFramework.Services.AutomatedAssignments.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_DocumentRepositoryCapacityWarningTab Then

                    TextBoxDocumentRepositoryCapacityWarningLog_Log.Text = AdvantageFramework.Services.DocumentRepositoryCapacityWarning.LoadLogEntries

                ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_NielsenPuertoRicoTab Then

                    TextBoxNielsenPuertoRicoLog_Log.Text = AdvantageFramework.Services.NielsenPuertoRico.LoadLogEntries

                End If

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

        End Sub
        Public Sub SetDefaults()

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing

            EnableOrDisableActions()
            EnableOrDisableServiceActions()

            For Each TabItem In TabControlForm_Services.Tabs

                ClearChanged(TabItem)

                _ServicesChangedDictionary(TabItem.Tag) = False

            Next

        End Sub
        Public Sub LoadDefaults(ByVal FromAdvantageServices As Boolean, ByVal IsAgencyASP As Boolean)

            _FromAdvantageServices = FromAdvantageServices
            _IsAgencyASP = IsAgencyASP

            _ServicesChangedDictionary = New Generic.Dictionary(Of String, Boolean)

            For Each ServiceCode In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Services.Service), False)

                _ServicesChangedDictionary(ServiceCode) = False

            Next

            '******************************************************************************************************************************************************
            Try

                TabItemServices_EmailListenerTab.Tag = AdvantageFramework.Services.Service.AdvantageWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxEmailListenerLog_Log.Text = AdvantageFramework.Services.EmailListener.LoadLog(True, LabelEmailListener_StatusDescription.Text)
                    LabelEmailListener_StatusDescription.Visible = True
                    TabItemEmailListenerSettings_LogTab.Visible = True
                    LabelEmailListener_Status.Visible = True

                    AddHandler AdvantageFramework.Services.EmailListener.EntryLogWrittenEvent, AddressOf EmailListenerEntryLogWritten

                Else

                    TextBoxEmailListenerLog_Log.Text = ""
                    LabelEmailListener_StatusDescription.Text = ""
                    LabelEmailListener_StatusDescription.Visible = False
                    TabItemEmailListenerSettings_LogTab.Visible = False
                    LabelEmailListener_Status.Visible = False

                End If

                TextBoxEmailListenerLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    NumericInputEmailListenerSettings_RunAtEvery.Properties.MinValue = 5

                Else

                    NumericInputEmailListenerSettings_RunAtEvery.Properties.MinValue = 1

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_QvAAlertTab.Tag = AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString

                ComboBoxQvAAlertSettings_SendAlertTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.SendAlertTo))
                ComboBoxQvAAlertSettings_SetAlertLevel.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.SetAlertLevel))
                ComboBoxQvAAlertSettings_ShowLevel.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.ShowLevel))

                NumericInputThresholds_Level1Start.Properties.IsFloatValue = True
                NumericInputThresholds_Level1End.Properties.IsFloatValue = True
                NumericInputThresholds_Level2Start.Properties.IsFloatValue = True
                NumericInputThresholds_Level2End.Properties.IsFloatValue = True
                NumericInputThresholds_Level3Start.Properties.IsFloatValue = True

                If Me.FromAdvantageServices Then

                    TextBoxQvAAlertLog_Log.Text = AdvantageFramework.Services.QvAAlert.LoadLog(True, LabelQvAAlert_StatusDescription.Text)
                    LabelQvAAlert_StatusDescription.Visible = True
                    TabItemQvAAlertSettings_LogTab.Visible = True
                    LabelQvAAlert_Status.Visible = True

                    AddHandler AdvantageFramework.Services.QvAAlert.EntryLogWrittenEvent, AddressOf QvAAlertEntryLogWritten

                Else

                    TextBoxQvAAlertLog_Log.Text = ""
                    LabelQvAAlert_StatusDescription.Text = ""
                    LabelQvAAlert_StatusDescription.Visible = False
                    TabItemQvAAlertSettings_LogTab.Visible = False
                    LabelQvAAlert_Status.Visible = False

                End If

                TextBoxQvAAlertLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_MediaExportTab.Tag = AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString

                ComboBoxExportCriteria_Clients.ByPassUserEntryChanged = True

                If Me.FromAdvantageServices Then

                    TextBoxExportLog_Log.Text = AdvantageFramework.Services.MediaExport.LoadLog(True, LabelMediaExport_StatusDescription.Text)
                    LabelMediaExport_StatusDescription.Visible = True
                    TabItemMediaExportSettings_LogTab.Visible = True
                    LabelMediaExport_Status.Visible = True

                    AddHandler AdvantageFramework.Services.MediaExport.EntryLogWrittenEvent, AddressOf MediaExportEntryLogWritten

                Else

                    TextBoxExportLog_Log.Text = ""
                    LabelMediaExport_StatusDescription.Text = ""
                    LabelMediaExport_StatusDescription.Visible = False
                    TabItemMediaExportSettings_LogTab.Visible = False
                    LabelMediaExport_Status.Visible = False

                End If

                TextBoxExportLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    TabItemServices_MediaExportTab.Visible = False

                Else

                    TabItemServices_MediaExportTab.Visible = True

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                ComboBoxTaskSettings_RunDay.DisplayName = "Run Day"
                ComboBoxTaskSettings_RunDay.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Services.Task.RunDayofWeek))

                TabItemServices_TasksTab.Tag = AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxTaskLog_Log.Text = AdvantageFramework.Services.Task.LoadLog(True, LabelTask_StatusDescription.Text)
                    LabelTask_StatusDescription.Visible = True
                    TabItemTaskSettings_LogTab.Visible = True
                    LabelTask_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Task.EntryLogWrittenEvent, AddressOf TaskEntryLogWritten

                Else

                    TextBoxTaskLog_Log.Text = ""
                    LabelTask_StatusDescription.Text = ""
                    LabelTask_StatusDescription.Visible = False
                    TabItemTaskSettings_LogTab.Visible = False
                    LabelTask_Status.Visible = False

                End If

                TextBoxTaskLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                ComboBoxMissingTimeSettings_Interval_RunDay.DisplayName = "Run Day"
                ComboBoxMissingTimeSettings_Interval_RunDay.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Services.MissingTime.RunDayofWeek))

                TabItemServices_MissingTimeTab.Tag = AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxMissingTimeLog_Log.Text = AdvantageFramework.Services.MissingTime.LoadLog(True, LabelMissingTime_StatusDescription.Text)
                    LabelMissingTime_StatusDescription.Visible = True
                    TabItemMissingTimeSettings_LogTab.Visible = True
                    LabelMissingTime_Status.Visible = True

                    AddHandler AdvantageFramework.Services.MissingTime.EntryLogWrittenEvent, AddressOf MissingTimeEntryLogWritten

                Else

                    TextBoxMissingTimeLog_Log.Text = ""
                    LabelMissingTime_StatusDescription.Text = ""
                    LabelMissingTime_StatusDescription.Visible = False
                    TabItemMissingTimeSettings_LogTab.Visible = False
                    LabelMissingTime_Status.Visible = False

                End If

                TextBoxMissingTimeLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    CheckBoxMissingTimeSettings_Interval_RunEvery.SecurityEnabled = False
                    CheckBoxMissingTimeSettings_Interval_StopAfter.SecurityEnabled = False
                    NumericInputMissingTimeSettings_Interval_RunEveryHours.SecurityEnabled = False
                    NumericInputMissingTimeSettings_Interval_StopAfter.SecurityEnabled = False
                    TextBoxMissingTimeSettings_LogFilePath.SecurityEnabled = False

                Else

                    CheckBoxMissingTimeSettings_Interval_RunEvery.SecurityEnabled = True
                    CheckBoxMissingTimeSettings_Interval_StopAfter.SecurityEnabled = True
                    NumericInputMissingTimeSettings_Interval_RunEveryHours.SecurityEnabled = True
                    NumericInputMissingTimeSettings_Interval_StopAfter.SecurityEnabled = True
                    TextBoxMissingTimeSettings_LogFilePath.SecurityEnabled = True

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_CalendarTab.Tag = AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxCalendarLog_Log.Text = AdvantageFramework.Services.Calendar.LoadLog(True, LabelCalendar_StatusDescription.Text)
                    LabelCalendar_StatusDescription.Visible = True
                    TabItemCalendarSettings_CalendarLogTab.Visible = True
                    LabelCalendar_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Calendar.EntryLogWrittenEvent, AddressOf CalendarEntryLogWritten

                Else

                    TextBoxCalendarLog_Log.Text = ""
                    LabelCalendar_StatusDescription.Text = ""
                    LabelCalendar_StatusDescription.Visible = False
                    TabItemCalendarSettings_CalendarLogTab.Visible = False
                    LabelCalendar_Status.Visible = False

                End If

                TextBoxCalendarLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    NumericInputCalendarSettings_RunAt.Properties.MinValue = 5

                Else

                    NumericInputCalendarSettings_RunAt.Properties.MinValue = 1

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_CoreMediaCheckExportTab.Tag = AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxCoreMediaCheckExportLog_Log.Text = AdvantageFramework.Services.CoreMediaCheckExport.LoadLog(True, LabelCoreMediaCheckExport_StatusDescription.Text)
                    LabelCoreMediaCheckExport_StatusDescription.Visible = True
                    TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab.Visible = True
                    LabelCoreMediaCheckExport_Status.Visible = True

                    AddHandler AdvantageFramework.Services.CoreMediaCheckExport.EntryLogWrittenEvent, AddressOf CoreMediaCheckExportEntryLogWritten

                Else

                    TextBoxCoreMediaCheckExportLog_Log.Text = ""
                    LabelCoreMediaCheckExport_StatusDescription.Text = ""
                    LabelCoreMediaCheckExport_StatusDescription.Visible = False
                    TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab.Visible = False
                    LabelCoreMediaCheckExport_Status.Visible = False

                End If

                TextBoxCoreMediaCheckExportLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    TabItemServices_CoreMediaCheckExportTab.Visible = False

                Else

                    TabItemServices_CoreMediaCheckExportTab.Visible = True

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_ContractTab.Tag = AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString

                CheckBoxContractSettings_ContractReports.Checked = True

                If Me.FromAdvantageServices Then

                    TextBoxContractLog_Log.Text = AdvantageFramework.Services.Contract.LoadLog(True, LabelContract_StatusDescription.Text)
                    LabelContract_StatusDescription.Visible = True
                    TabItemContractSettings_ContractLogTab.Visible = True
                    LabelContract_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Contract.EntryLogWrittenEvent, AddressOf ContractEntryLogWritten

                Else

                    TextBoxContractLog_Log.Text = ""
                    LabelContract_StatusDescription.Text = ""
                    LabelContract_StatusDescription.Visible = False
                    TabItemContractSettings_ContractLogTab.Visible = False
                    LabelContract_Status.Visible = False

                End If

                TextBoxContractLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_MediaOceanImportTab.Tag = AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxMediaOceanImportLog_Log.Text = AdvantageFramework.Services.MediaOceanImport.LoadLog(True, LabelMediaOceanImport_StatusDescription.Text)
                    LabelMediaOceanImport_StatusDescription.Visible = True
                    TabItemMediaOceanImportSettings_MediaOceanImportLogTab.Visible = True
                    LabelMediaOceanImport_Status.Visible = True

                    AddHandler AdvantageFramework.Services.MediaOceanImport.EntryLogWrittenEvent, AddressOf MediaOceanImportEntryLogWritten

                Else

                    TextBoxMediaOceanImportLog_Log.Text = ""
                    LabelMediaOceanImport_StatusDescription.Text = ""
                    LabelMediaOceanImport_StatusDescription.Visible = False
                    TabItemMediaOceanImportSettings_MediaOceanImportLogTab.Visible = False
                    LabelMediaOceanImport_Status.Visible = False

                End If

                TextBoxMediaOceanImportLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    TabItemServices_MediaOceanImportTab.Visible = False

                Else

                    TabItemServices_MediaOceanImportTab.Visible = True

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_PaidTimeOffAccrualsTab.Tag = AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString

                ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DataSource = LoadDays()

                If Me.FromAdvantageServices Then

                    TextBoxPaidTimeOffAccrualsLog_Log.Text = AdvantageFramework.Services.PaidTimeOffAccruals.LoadLog(True, LabelPaidTimeOffAccruals_StatusDescription.Text)
                    LabelPaidTimeOffAccruals_StatusDescription.Visible = True
                    TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab.Visible = True
                    LabelPaidTimeOffAccruals_Status.Visible = True

                    AddHandler AdvantageFramework.Services.PaidTimeOffAccruals.EntryLogWrittenEvent, AddressOf PaidTimeOffAccrualsEntryLogWritten

                Else

                    TextBoxPaidTimeOffAccrualsLog_Log.Text = ""
                    LabelPaidTimeOffAccruals_StatusDescription.Text = ""
                    LabelPaidTimeOffAccruals_StatusDescription.Visible = False
                    TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab.Visible = False
                    LabelPaidTimeOffAccruals_Status.Visible = False

                End If

                TextBoxPaidTimeOffAccrualsLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_CSIPreferredPartnerTab.Tag = AdvantageFramework.Services.Service.AdvantageCSIPreferredPartnerWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxCSIPreferredPartnerLog_Log.Text = AdvantageFramework.Services.CSIPreferredPartner.LoadLog(True, LabelCSIPreferredPartner_StatusDescription.Text)
                    LabelCSIPreferredPartner_StatusDescription.Visible = True
                    TabItemCSIPreferredPartnerSettings_CSIPreferredPartnerLogTab.Visible = True
                    LabelCSIPreferredPartner_Status.Visible = True

                    AddHandler AdvantageFramework.Services.CSIPreferredPartner.EntryLogWrittenEvent, AddressOf CSIPreferredPartnerEntryLogWritten

                Else

                    TextBoxCSIPreferredPartnerLog_Log.Text = ""
                    LabelCSIPreferredPartner_StatusDescription.Text = ""
                    LabelCSIPreferredPartner_StatusDescription.Visible = False
                    TabItemCSIPreferredPartnerSettings_CSIPreferredPartnerLogTab.Visible = False
                    LabelCSIPreferredPartner_Status.Visible = False

                End If

                TextBoxCSIPreferredPartnerLog_Log.ByPassUserEntryChanged = True

                If IsAgencyASP Then

                    TextBoxCSIPreferredPartnerSettings_DownloadFolder.ReadOnly = True
                    TextBoxCSIPreferredPartnerSettings_UploadFolder.ReadOnly = True

                Else

                    TextBoxCSIPreferredPartnerSettings_DownloadFolder.ReadOnly = False
                    TextBoxCSIPreferredPartnerSettings_UploadFolder.ReadOnly = False

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_JobCompUDFImportTab.Tag = AdvantageFramework.Services.Service.AdvantageJobCompUDFImportWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxJobCompUDFImportLog_Log.Text = AdvantageFramework.Services.JobCompUDFImport.LoadLog(True, LabelJobCompUDFImport_StatusDescription.Text)
                    LabelJobCompUDFImport_StatusDescription.Visible = True
                    TabItemJobCompUDFImportSettings_JobCompUDFImportLogTab.Visible = True
                    LabelJobCompUDFImport_Status.Visible = True

                    AddHandler AdvantageFramework.Services.JobCompUDFImport.EntryLogWrittenEvent, AddressOf JobCompUDFImportEntryLogWritten

                Else

                    TextBoxJobCompUDFImportLog_Log.Text = ""
                    LabelJobCompUDFImport_StatusDescription.Text = ""
                    LabelJobCompUDFImport_StatusDescription.Visible = False
                    TabItemJobCompUDFImportSettings_JobCompUDFImportLogTab.Visible = False
                    LabelJobCompUDFImport_Status.Visible = False

                End If

                TextBoxJobCompUDFImportLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    TabItemServices_JobCompUDFImportTab.Visible = False

                Else

                    TabItemServices_JobCompUDFImportTab.Visible = True

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_ImportsTab.Tag = AdvantageFramework.Services.Service.AdvantageImportTemplateWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxImportsLog_Log.Text = AdvantageFramework.Services.Imports.LoadLog(True, LabelImports_StatusDescription.Text)
                    LabelImports_StatusDescription.Visible = True
                    TabItemImportsSettings_ImportsLogTab.Visible = True
                    LabelImports_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Imports.EntryLogWrittenEvent, AddressOf ImportsEntryLogWritten

                Else

                    TextBoxImportsLog_Log.Text = ""
                    LabelImports_StatusDescription.Text = ""
                    LabelImports_StatusDescription.Visible = False
                    TabItemImportsSettings_ImportsLogTab.Visible = False
                    LabelImports_Status.Visible = False

                End If

                TextBoxImportsLog_Log.ByPassUserEntryChanged = True

                TabItemServices_ImportsTab.Visible = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_ExportsTab.Tag = AdvantageFramework.Services.Service.AdvantageExportTemplateWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxExportsLog_Log.Text = AdvantageFramework.Services.Exports.LoadLog(True, LabelExports_StatusDescription.Text)
                    LabelExports_StatusDescription.Visible = True
                    TabItemExportsSettings_ExportsLogTab.Visible = True
                    LabelExports_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Exports.EntryLogWrittenEvent, AddressOf ExportsEntryLogWritten

                Else

                    TextBoxExportsLog_Log.Text = ""
                    LabelExports_StatusDescription.Text = ""
                    LabelExports_StatusDescription.Visible = False
                    TabItemExportsSettings_ExportsLogTab.Visible = False
                    LabelExports_Status.Visible = False

                End If

                TextBoxExportsLog_Log.ByPassUserEntryChanged = True

                'If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                '    TabItemServices_ExportsTab.Visible = False

                'Else

                '    TabItemServices_ExportsTab.Visible = True

                'End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_VendorContractsTab.Tag = AdvantageFramework.Services.Service.AdvantageVendorContractWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxVendorContractLog_Log.Text = AdvantageFramework.Services.VendorContract.LoadLog(True, LabelVendorContracts_StatusDescription.Text)
                    LabelVendorContracts_StatusDescription.Visible = True
                    TabItemVendorContractSettings_LogTab.Visible = True
                    LabelVendorContracts_Status.Visible = True

                    AddHandler AdvantageFramework.Services.VendorContract.EntryLogWrittenEvent, AddressOf VendorContractEntryLogWritten

                Else

                    TextBoxVendorContractLog_Log.Text = ""
                    LabelVendorContracts_StatusDescription.Text = ""
                    LabelVendorContracts_StatusDescription.Visible = False
                    TabItemVendorContractSettings_LogTab.Visible = False
                    LabelVendorContracts_Status.Visible = False

                End If

                TextBoxVendorContractLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_CurrencyExchangeTab.Tag = AdvantageFramework.Services.Service.AdvantageCurrencyExchangeWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxCurrencyExchangeLog_Log.Text = AdvantageFramework.Services.CurrencyExchange.LoadLog(True, LabelCurrencyExchange_StatusDescription.Text)
                    LabelCurrencyExchange_StatusDescription.Visible = True
                    TabItemCurrencyExchangeSettings_LogTab.Visible = True
                    LabelCurrencyExchange_Status.Visible = True

                    AddHandler AdvantageFramework.Services.CurrencyExchange.EntryLogWrittenEvent, AddressOf CurrencyExchangeEntryLogWritten

                Else

                    TextBoxCurrencyExchangeLog_Log.Text = ""
                    LabelCurrencyExchange_StatusDescription.Text = ""
                    LabelCurrencyExchange_StatusDescription.Visible = False
                    TabItemCurrencyExchangeSettings_LogTab.Visible = False
                    LabelCurrencyExchange_Status.Visible = False

                End If

                TextBoxCurrencyExchangeLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_VCCTab.Tag = AdvantageFramework.Services.Service.AdvantageVCCWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxVCCLog_Log.Text = AdvantageFramework.Services.VCC.LoadLog(True, LabelVCC_StatusDescription.Text)
                    LabelVCC_StatusDescription.Visible = True
                    TabItemVCCSettings_LogTab.Visible = True
                    LabelVCC_Status.Visible = True

                    AddHandler AdvantageFramework.Services.VCC.EntryLogWrittenEvent, AddressOf VCCEntryLogWritten

                Else

                    TextBoxVCCLog_Log.Text = ""
                    LabelVCC_StatusDescription.Text = ""
                    LabelVCC_StatusDescription.Visible = False
                    TabItemVCCSettings_LogTab.Visible = False
                    LabelVCC_Status.Visible = False

                End If

                TextBoxVCCLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_NielsenTab.Tag = AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxNielsenLog_Log.Text = AdvantageFramework.Services.Nielsen.LoadLog(True, LabelNielsen_StatusDescription.Text)
                    LabelNielsen_StatusDescription.Visible = True
                    TabItemNielsenSettings_NielsenLogTab.Visible = True
                    LabelNielsen_Status.Visible = True

                    AddHandler AdvantageFramework.Services.Nielsen.EntryLogWrittenEvent, AddressOf NielsenEntryLogWritten

                Else

                    TextBoxNielsenLog_Log.Text = ""
                    LabelNielsen_StatusDescription.Text = ""
                    LabelNielsen_StatusDescription.Visible = False
                    TabItemNielsenSettings_NielsenLogTab.Visible = False
                    LabelNielsen_Status.Visible = False

                End If

                TextBoxNielsenLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_CalendarTimesheetTab.Tag = AdvantageFramework.Services.Service.AdvantageCalendarTimeSheetImportService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxTimeSheetLog_Log.Text = AdvantageFramework.Services.CalendarTimeSheetImport.LoadLog(True, LabelCalendar_StatusDescription.Text)
                    LabelTimeSheet_StatusDescription.Visible = True
                    TabItemTimeSheetSettings_TimeSheetLogTab.Visible = True
                    LabelTimeSheet_Status.Visible = True

                    AddHandler AdvantageFramework.Services.CalendarTimeSheetImport.EntryLogWrittenEvent, AddressOf TimeSheetEntryLogWritten

                Else

                    TextBoxTimeSheetLog_Log.Text = ""
                    LabelTimeSheet_StatusDescription.Text = ""
                    LabelTimeSheet_StatusDescription.Visible = False
                    TabItemTimeSheetSettings_TimeSheetLogTab.Visible = False
                    LabelTimeSheet_Status.Visible = False

                End If

                TextBoxTimeSheetLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    NumericInputTimeSheetSettings_RunAtEvery.Properties.MinValue = 15

                Else

                    NumericInputTimeSheetSettings_RunAtEvery.Properties.MinValue = 15

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_ScheduledReportsTab.Tag = AdvantageFramework.Services.Service.AdvantageScheduledReportsService.ToString

                If IsAgencyASP Then

                    TextBoxScheduledReportsSettings_OutputFolder.Enabled = False

                Else

                    TextBoxScheduledReportsSettings_OutputFolder.Enabled = True

                End If

                If Me.FromAdvantageServices Then

                    TextBoxScheduledReportsLog_Log.Text = AdvantageFramework.Services.ScheduledReports.LoadLog(True, LabelScheduledReports_StatusDescription.Text)
                    LabelScheduledReports_StatusDescription.Visible = True
                    TabItemScheduledReportsLog_LogTab.Visible = True
                    LabelScheduledReports_Status.Visible = True

                    AddHandler AdvantageFramework.Services.ScheduledReports.EntryLogWrittenEvent, AddressOf ScheduledReportsEntryLogWritten

                Else

                    TextBoxScheduledReportsLog_Log.Text = ""
                    LabelScheduledReports_StatusDescription.Text = ""
                    LabelScheduledReports_StatusDescription.Visible = False
                    TabItemScheduledReportsLog_LogTab.Visible = False
                    LabelScheduledReports_Status.Visible = False

                End If

                TextBoxScheduledReportsLog_Log.ByPassUserEntryChanged = True

                'If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                '    NumericInputTimeSheetSettings_RunAtEvery.Properties.MinValue = 15

                'Else

                '    NumericInputTimeSheetSettings_RunAtEvery.Properties.MinValue = 15

                'End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_ComscoreTab.Tag = AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxComScoreLog_Log.Text = AdvantageFramework.Services.ComScore.LoadLog(True, LabelComScore_StatusDescription.Text)
                    LabelComScore_StatusDescription.Visible = True
                    TabItemComScoreSettings_ComScoreLogTab.Visible = True
                    LabelComScore_Status.Visible = True

                    AddHandler AdvantageFramework.Services.ComScore.EntryLogWrittenEvent, AddressOf ComScoreEntryLogWritten

                Else

                    TextBoxComScoreLog_Log.Text = ""
                    LabelComScore_StatusDescription.Text = ""
                    LabelComScore_StatusDescription.Visible = False
                    TabItemComScoreSettings_ComScoreLogTab.Visible = False
                    LabelComScore_Status.Visible = False

                End If

                TextBoxComScoreLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_InOutTab.Tag = AdvantageFramework.Services.Service.AdvantageInOutWindowService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxInOutLog_Log.Text = AdvantageFramework.Services.InOutBoard.LoadLog(True, LabelInOut_StatusDescription.Text)
                    LabelInOut_StatusDescription.Visible = True
                    TabItemInOutSettings_InOutLogTab.Visible = True
                    LabelInOut_Status.Visible = True

                    AddHandler AdvantageFramework.Services.InOutBoard.EntryLogWrittenEvent, AddressOf InOutEntryLogWritten

                Else

                    TextBoxInOutLog_Log.Text = ""
                    LabelInOut_StatusDescription.Text = ""
                    LabelInOut_StatusDescription.Visible = False
                    TabItemInOutSettings_InOutLogTab.Visible = False
                    LabelInOut_Status.Visible = False

                End If

                TextBoxInOutLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_AutomatedAssignmentsTab.Tag = AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxAutomatedAssignmentsLog_Log.Text = AdvantageFramework.Services.AutomatedAssignments.LoadLog(True, LabelAutomatedAssignments_StatusDescription.Text)
                    LabelAutomatedAssignments_StatusDescription.Visible = True
                    TabItemAutomatedAssignments_AutomatedAssignmentsLogTab.Visible = True
                    LabelAutomatedAssignments_Status.Visible = True

                    AddHandler AdvantageFramework.Services.AutomatedAssignments.EntryLogWrittenEvent, AddressOf AutomatedAssignmentsEntryLogWritten

                Else

                    TextBoxAutomatedAssignmentsLog_Log.Text = ""
                    LabelAutomatedAssignments_StatusDescription.Text = ""
                    LabelAutomatedAssignments_StatusDescription.Visible = False
                    TabItemAutomatedAssignments_AutomatedAssignmentsLogTab.Visible = False
                    LabelAutomatedAssignments_Status.Visible = False

                End If

                TextBoxAutomatedAssignmentsLog_Log.ByPassUserEntryChanged = True

                If _FromAdvantageServices = False AndAlso IsAgencyASP Then

                    NumericInputAutomatedAssignmentsSettings_RunAtEvery.Properties.MinValue = 5

                Else

                    NumericInputAutomatedAssignmentsSettings_RunAtEvery.Properties.MinValue = 1

                End If

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_DocumentRepositoryCapacityWarningTab.Tag = AdvantageFramework.Services.Service.AdvantageDocumentRepositoryCapacityWarningWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxDocumentRepositoryCapacityWarningLog_Log.Text = AdvantageFramework.Services.DocumentRepositoryCapacityWarning.LoadLog(True, LabelDocumentRepositoryCapacityWarning_StatusDescription.Text)
                    LabelDocumentRepositoryCapacityWarning_StatusDescription.Visible = True
                    TabItemDocumentRepositoryCapacityWarningSettings_DocumentRepositoryCapacityWarningLogTab.Visible = True
                    LabelDocumentRepositoryCapacityWarning_Status.Visible = True

                    AddHandler AdvantageFramework.Services.DocumentRepositoryCapacityWarning.EntryLogWrittenEvent, AddressOf DocumentRepositoryCapacityWarningEntryLogWritten

                Else

                    TextBoxDocumentRepositoryCapacityWarningLog_Log.Text = ""
                    LabelDocumentRepositoryCapacityWarning_StatusDescription.Text = ""
                    LabelDocumentRepositoryCapacityWarning_StatusDescription.Visible = False
                    TabItemDocumentRepositoryCapacityWarningSettings_DocumentRepositoryCapacityWarningLogTab.Visible = False
                    LabelDocumentRepositoryCapacityWarning_Status.Visible = False

                End If

                TextBoxDocumentRepositoryCapacityWarningLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************
            Try

                TabItemServices_NielsenPuertoRicoTab.Tag = AdvantageFramework.Services.Service.AdvantageNielsenPuertoRicoWindowsService.ToString

                If Me.FromAdvantageServices Then

                    TextBoxNielsenPuertoRicoLog_Log.Text = AdvantageFramework.Services.NielsenPuertoRico.LoadLog(True, LabelNielsenPuertoRico_StatusDescription.Text)
                    LabelNielsenPuertoRico_StatusDescription.Visible = True
                    TabItemNielsenPuertoRicoSettings_NielsenPuertoRicoLogTab.Visible = True
                    LabelNielsenPuertoRico_Status.Visible = True

                    AddHandler AdvantageFramework.Services.NielsenPuertoRico.EntryLogWrittenEvent, AddressOf NielsenPuertoRicoEntryLogWritten

                Else

                    TextBoxNielsenPuertoRicoLog_Log.Text = ""
                    LabelNielsenPuertoRico_StatusDescription.Text = ""
                    LabelNielsenPuertoRico_StatusDescription.Visible = False
                    TabItemNielsenPuertoRicoSettings_NielsenPuertoRicoLogTab.Visible = False
                    LabelNielsenPuertoRico_Status.Visible = False

                End If

                TextBoxNielsenPuertoRicoLog_Log.ByPassUserEntryChanged = True

            Catch ex As Exception

            End Try

            '******************************************************************************************************************************************************

            If Me.FromAdvantageServices Then

                If AdvantageFramework.Email.TestMailBee() = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("MailBee not registered", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK)

                End If

            End If

            For Each TabItem In TabControlForm_Services.Tabs


                Try

                    ClearChanged(TabItem)

                    _ServicesChangedDictionary(TabItem.Tag) = False

                Catch ex As Exception

                End Try

            Next

            _Initialized = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub AdvantageServicesSettingsControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'objects
            Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
            Dim ServiceStartupType As AdvantageFramework.Services.ServiceStartupType = Nothing

            DateTimePickerContractAlertSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerCoreMediaCheckExportSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerMediaExportSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerTaskSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerQvAAlertSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerMissingTimeSettings_Interval_RunAtTime.ButtonDropDown.Visible = True
            DateTimePickerMediaOceanImportSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerJobCompUDFImportSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerVendorContractSettings_RunAt.ButtonDropDown.Visible = True
            DateTimePickerCurrencyExchangeSettings_Interval_RunAtTime.ButtonDropDown.Visible = True

            DataGridViewImports_AvailableImports.MultiSelect = False

            PropertyGridControlImports_Properties.ControlType = PropertyGridControl.ControlTypes.Editable
            PropertyGridControlImports_Properties.AutoFilterLookupColumns = False
            PropertyGridControlImports_Properties.AutoloadRepositoryDatasource = False

            PropertyGridControlExports_Properties.ControlType = PropertyGridControl.ControlTypes.Editable
            PropertyGridControlExports_Properties.AutoFilterLookupColumns = False
            PropertyGridControlExports_Properties.AutoloadRepositoryDatasource = False

            If _HasBeenLoaded = False Then

                _HasBeenLoaded = True

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

#Region "   Toolbar"

        Private Sub TabControlForm_Services_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_Services.SelectedTabChanged

            If e.NewTab.Equals(TabItemServices_NielsenTab) Then

                RaiseEvent NielsenTabSelectedEvent()

            End If

        End Sub
        Private Sub TabControlForm_Services_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Services.SelectedTabChanging

            If _HasBeenLoaded Then

                If CheckUserEntryChangedSetting(e.OldTab) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        SaveSettings(e.OldTab)

                    End If

                End If

                ClearChanged(e.OldTab)

                Try

                    _ServicesChangedDictionary(e.OldTab.Tag) = False

                Catch ex As Exception

                End Try

                Try

                    _SelectedAdvantageService = _AdvantageServices.SingleOrDefault(Function(Entity) Entity.Code = e.NewTab.Tag)

                Catch ex As Exception
                    _SelectedAdvantageService = Nothing
                End Try

                Try

                    LoadServiceSettings(False, e.NewTab.Tag)

                Catch ex As Exception

                End Try

                ClearChanged(e.NewTab)

                Try

                    _ServicesChangedDictionary(e.NewTab.Tag) = False

                Catch ex As Exception

                End Try

                EnableOrDisableActions()
                EnableOrDisableServiceActions()

                Try

                    RaiseEvent EnableOrDisableSaveEvent(False)

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#Region "   Email Listener "

        Private Sub NumericInputEmailListenerSettings_RunAtEvery_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputEmailListenerSettings_RunAtEvery.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxEmailListenerSettings_StartofSignatureCode_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmailListenerSettings_StartofSignatureCode.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxEmailListenerSettings_SendEmailToAlertRecipients_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEmailListenerSettings_SendEmailToAlertRecipients.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   QvA"

        Private Sub CheckBoxThresholds_Level1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level1.CheckedChanged

            If CheckBoxThresholds_Level1.Checked Then

                NumericInputThresholds_Level1Start.Enabled = True
                NumericInputThresholds_Level1End.Enabled = True
                TextBoxThresholds_Level1Description.Enabled = True

            Else

                NumericInputThresholds_Level1Start.Enabled = False
                NumericInputThresholds_Level1End.Enabled = False
                TextBoxThresholds_Level1Description.Enabled = False

            End If

            If _Initialized Then

                _QvAAlertLevel1Enabled = CheckBoxThresholds_Level1.Checked

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxThresholds_Level2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level2.CheckedChanged

            If CheckBoxThresholds_Level2.Checked Then

                NumericInputThresholds_Level2Start.Enabled = True
                NumericInputThresholds_Level2End.Enabled = True
                TextBoxThresholds_Level2Description.Enabled = True

            Else

                NumericInputThresholds_Level2Start.Enabled = False
                NumericInputThresholds_Level2End.Enabled = False
                TextBoxThresholds_Level2Description.Enabled = False

            End If

            If _Initialized Then

                _QvAAlertLevel2Enabled = CheckBoxThresholds_Level2.Checked

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxThresholds_Level3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level3.CheckedChanged

            If CheckBoxThresholds_Level3.Checked Then

                NumericInputThresholds_Level3Start.Enabled = True
                TextBoxThresholds_Level3Description.Enabled = True

            Else

                NumericInputThresholds_Level3Start.Enabled = False
                TextBoxThresholds_Level3Description.Enabled = False

            End If

            If _Initialized Then

                _QvAAlertLevel3Enabled = CheckBoxThresholds_Level3.Checked

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxCalculationOptions_Time_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_Time.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub CheckBoxCalculationOptions_IncomeOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncomeOnly.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub CheckBoxCalculationOptions_VendorCharges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_VendorCharges.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub CheckBoxCalculationOptions_IncludeEstimate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncludeEstimate.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub CheckBoxCalculationOptions_IncludeNonBillableTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncludeNonBillableTime.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub CheckBoxCalculationOptions_IncludeTimeMarkedFeeTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncludeTimeMarkedFeeTime.CheckedChanged

            RaiseEvent EnableOrDisableSaveEvent(True)

        End Sub
        Private Sub ComboBoxQvAAlertSettings_SendAlertTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndexChanged

            If _Initialized Then

                _SendAlertTo = ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndex

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxQvAAlertSettings_SetAlertLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndexChanged

            If _Initialized Then

                _SetAlertLevel = ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndex

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxQvAAlertSettings_ShowLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_ShowLevel.SelectedIndexChanged

            If _Initialized Then

                _ShowLevel = ComboBoxQvAAlertSettings_ShowLevel.SelectedIndex

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputThresholds_Level1Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level1Start.EditValueChanged

            'objects
            Dim SaveValue As Boolean = True
            Dim NewValue As Decimal

            If _Initialized Then

                NewValue = NumericInputThresholds_Level1Start.EditValue

                If NewValue <> _QvAAlertLevel1Start Then

                    If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

                        SaveValue = False

                    Else

                        If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

                            SaveValue = False

                        End If

                    End If

                    If SaveValue Then

                        _QvAAlertLevel1Start = NumericInputThresholds_Level1Start.EditValue

                        RaiseEvent EnableOrDisableSaveEvent(True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Invalid value")

                        NumericInputThresholds_Level1Start.EditValue = _QvAAlertLevel1Start

                        NumericInputThresholds_Level1Start.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputThresholds_Level1End_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level1End.EditValueChanged

            'objects
            Dim SaveValue As Boolean = True
            Dim NewValue As Decimal

            If _Initialized Then

                NewValue = NumericInputThresholds_Level1End.EditValue

                If NewValue <> _QvAAlertLevel1End Then

                    If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

                        SaveValue = False

                    Else

                        If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

                            SaveValue = False

                        End If

                    End If

                    If SaveValue Then

                        _QvAAlertLevel1End = NumericInputThresholds_Level1End.EditValue

                        RaiseEvent EnableOrDisableSaveEvent(True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Invalid value")

                        NumericInputThresholds_Level1End.EditValue = _QvAAlertLevel1End

                        NumericInputThresholds_Level1End.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputThresholds_Level2Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level2Start.EditValueChanged

            'objects
            Dim SaveValue As Boolean = True
            Dim NewValue As Decimal

            If _Initialized Then

                NewValue = NumericInputThresholds_Level2Start.EditValue

                If NewValue <> _QvAAlertLevel2Start Then

                    If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

                        SaveValue = False

                    Else

                        If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

                            SaveValue = False

                        End If

                    End If

                    If SaveValue Then

                        _QvAAlertLevel2Start = NumericInputThresholds_Level2Start.EditValue

                        RaiseEvent EnableOrDisableSaveEvent(True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

                        NumericInputThresholds_Level2Start.EditValue = _QvAAlertLevel2Start

                        NumericInputThresholds_Level2Start.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputThresholds_Level2End_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level2End.EditValueChanged

            'objects
            Dim SaveValue As Boolean = True
            Dim NewValue As Decimal = 0

            If _Initialized Then

                NewValue = NumericInputThresholds_Level2End.EditValue

                If NewValue <> _QvAAlertLevel2End Then

                    If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

                        SaveValue = False

                    Else

                        If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

                            SaveValue = False

                        End If

                    End If

                    If SaveValue Then

                        _QvAAlertLevel2End = NumericInputThresholds_Level2End.EditValue

                        RaiseEvent EnableOrDisableSaveEvent(True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

                        NumericInputThresholds_Level2End.EditValue = _QvAAlertLevel2End

                        NumericInputThresholds_Level2End.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputThresholds_Level3Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level3Start.EditValueChanged

            'objects
            Dim SaveValue As Boolean = True
            Dim NewValue As Decimal = 0

            If _Initialized Then

                NewValue = NumericInputThresholds_Level3Start.EditValue

                If NewValue <> _QvAAlertLevel3Start Then

                    If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

                        SaveValue = False

                    Else

                        If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

                            SaveValue = False

                        End If

                    End If

                    If SaveValue Then

                        _QvAAlertLevel3Start = NumericInputThresholds_Level3Start.EditValue

                        RaiseEvent EnableOrDisableSaveEvent(True)

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

                        NumericInputThresholds_Level3Start.EditValue = _QvAAlertLevel3Start

                        NumericInputThresholds_Level3Start.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub TextBoxThresholds_Level1Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level1Description.TextChanged

            If _Initialized Then

                _QvAAlertLevel1Description = TextBoxThresholds_Level1Description.Text

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxThresholds_Level2Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level2Description.TextChanged

            If _Initialized Then

                _QvAAlertLevel2Description = TextBoxThresholds_Level2Description.Text

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxThresholds_Level3Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level3Description.TextChanged

            If _Initialized Then

                _QvAAlertLevel3Description = TextBoxThresholds_Level3Description.Text

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub DateTimePickerQvAAlert_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerQvAAlertSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Media Export"

        Private Sub TextBoxMediaExportSettings_ExportPath_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaExportSettings_ExportPath.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub RadioButtonMediaExportSettings_AllData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMediaExportSettings_AllData.CheckedChanged

            If _Initialized Then

                If RadioButtonMediaExportSettings_AllData.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMediaExportSettings_TodaysData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMediaExportSettings_TodaysData.CheckedChanged

            If _Initialized Then

                If RadioButtonMediaExportSettings_TodaysData.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMediaExportSettings_DataFrom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMediaExportSettings_DataFrom.CheckedChanged

            If _Initialized Then

                If RadioButtonMediaExportSettings_DataFrom.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub ButtonExportCriteriaCampaign_AddSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_AddSelected.Click

            'objects
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

            For Each Campaign In DataGridViewExportCriteria_Campaigns.GetAllSelectedRowsDataBoundItems

                CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(Campaign.ID, Campaign.Client, Campaign.Code, Campaign.Campaign))

            Next

            AddCampaignCriteria(CampaignList, True)

        End Sub
        Private Sub ButtonExportCriteriaCampaign_AddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_AddAll.Click

            'objects
            Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

            CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

            For Each Campaign In DataGridViewExportCriteria_Campaigns.GetAllRowsDataBoundItems

                CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(Campaign.ID, Campaign.Client, Campaign.Code, Campaign.Campaign))

            Next

            AddCampaignCriteria(CampaignList, True)

        End Sub
        Private Sub ButtonExportCriteriaCampaign_RemoveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_RemoveSelected.Click

            RemoveCampaignCriteria(DataGridViewExportCriteria_SelectedCampaigns.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList)

        End Sub
        Private Sub ButtonExportCriteriaCampaign_RemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_RemoveAll.Click

            RemoveCampaignCriteria(DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList)

        End Sub
        Private Sub ComboBoxExportCriteria_Clients_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxExportCriteria_Clients.SelectedValueChanged

            If ComboBoxExportCriteria_Clients.HasASelectedValue Then

                GroupBoxExportCriteria_SelectedCampaigns.Enabled = True

                LoadAvailableCampaigns()

            Else

                GroupBoxExportCriteria_SelectedCampaigns.Enabled = False

            End If

        End Sub
        Private Sub DateTimePickerMediaExportSettings_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerMediaExportSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Task"

        Private Sub CheckBoxTaskSettings_PastDue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTaskSettings_PastDue.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

                UpdatePastDueSettings()

            End If

        End Sub
        Private Sub CheckBoxTaskSettings_Upcoming_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTaskSettings_Upcoming.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

                UpdateUpcomingSettings()

            End If

        End Sub
        Private Sub NumericInputTaskSettings_Upcoming_StartDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputTaskSettings_Upcoming_StartDays.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

                If NumericInputTaskSettings_Upcoming_StartDays.EditValue > NumericInputTaskSettings_Upcoming_EndDays.EditValue Then

                    NumericInputTaskSettings_Upcoming_EndDays.EditValue = NumericInputTaskSettings_Upcoming_StartDays.EditValue

                End If

            End If

        End Sub
        Private Sub NumericInputTaskSettings_Upcoming_EndDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputTaskSettings_Upcoming_EndDays.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

                If NumericInputTaskSettings_Upcoming_EndDays.EditValue < NumericInputTaskSettings_Upcoming_StartDays.EditValue Then

                    NumericInputTaskSettings_Upcoming_StartDays.EditValue = NumericInputTaskSettings_Upcoming_EndDays.EditValue

                End If

            End If

        End Sub
        Private Sub DateTimePickerTaskSettings_RunAt_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerTaskSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxTaskSettings_PastDue_CustomMessage_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTaskSettings_PastDue_CustomMessage.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxTaskSettings_Upcoming_CustomMessage_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTaskSettings_Upcoming_CustomMessage.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxTaskSettings_RunDay_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTaskSettings_RunDay.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxTaskSettings_UseProductName_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTaskSettings_UseProductName.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxTaskSettings_RemoveTaskComments_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTaskSettings_RemoveTaskComments.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Missing Time"

        Private Sub CheckBoxMissingTimeSettings_Interval_RunEvery_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_RunEvery.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeIntervalRunEverySettings(CheckBoxMissingTimeSettings_Interval_RunEvery.Checked)

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeSettings_Interval_RunAt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_RunAt.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeIntervalRunAtSettings(CheckBoxMissingTimeSettings_Interval_RunAt.Checked)

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeSettings_Interval_StopAfter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_StopAfter.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeIntervalStopAfterSettings((CheckBoxMissingTimeSettings_Interval_RunEvery.Checked) And (CheckBoxMissingTimeSettings_Interval_StopAfter.Checked))

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeSettings_Tracking_DontCountWeekends_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeAlerts_Recipient_Employee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_Employee.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeRecipientEmployeeSettings(CheckBoxMissingTimeAlerts_Recipient_Employee.Checked)

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeAlerts_Recipient_Supervisor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeRecipientSupervisorSettings(CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked)

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeAlerts_Recipient_ITContact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckedChanged

            If _Initialized Then

                UpdateMissingTimeRecipientITContactSettings(CheckBoxMissingTimeAlerts_Recipient_ITContact.Checked)

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxMissingTimeSettings_Interval_RunDay_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMissingTimeSettings_Interval_RunDay.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub DateTimePickerMissingTimeSettings_Interval_RunAtTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerMissingTimeSettings_Interval_RunAtTime.Click

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub DateTimePickerMissingTimeSettings_Interval_RunAtTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerMissingTimeSettings_Interval_RunAtTime.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeSettings_Interval_RunEveryHours_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeSettings_Interval_StopAfter_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Interval_StopAfter.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeSettings_Range_DaysToCheck_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Range_DaysToCheck.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub RadioButtonMissingTimeSettings_Priority_High_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_High.CheckedChanged

            If _Initialized Then

                If RadioButtonMissingTimeSettings_Priority_High.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMissingTimeSettings_Priority_Medium_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_Medium.CheckedChanged

            If _Initialized Then

                If RadioButtonMissingTimeSettings_Priority_Medium.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMissingTimeSettings_Priority_Low_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_Low.CheckedChanged

            If _Initialized Then

                If RadioButtonMissingTimeSettings_Priority_Low.Checked Then

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMissingTimeSettings_Range_DaysToCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Range_DaysToCheck.CheckedChanged

            If _Initialized Then

                If RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked Then

                    UpdateMissingTimeRangeSettings(RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked)

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.CheckedChanged

            If _Initialized Then

                If RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Checked Then

                    UpdateMissingTimeRangeSettings(RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked)

                    RaiseEvent EnableOrDisableSaveEvent(True)

                End If

            End If

        End Sub
        Private Sub TextBoxMissingTimeSettings_LogFilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxMissingTimeSettings_LogFilePath.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxMissingTimeAlerts_CustomMessage_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMissingTimeAlerts_CustomMessage.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Calendar"

        Private Sub NumericInputCalendarSettings_RunAt_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputCalendarSettings_RunAt.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Core Media Check Export"

        Private Sub DateTimePickerCoreMediaCheckExportSettings_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerCoreMediaCheckExportSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxCoreMediaCheckExportSettings_ExportPath_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCoreMediaCheckExportSettings_ExportPath.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Paid Time Off Accruals"

        Private Sub ComboBoxPaidTimeOffAccrualsSettings_RunOnDay_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Contract"

        Private Sub DateTimePickerContractAlertSettings_RunAt_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerContractAlertSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputContractSettings_RenewalDaysPrior_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericInputContractSettings_RenewalDaysPrior.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxContractSettings_ContractRenewal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxContractSettings_ContractRenewal.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  Media Ocean Import "

        Private Sub DateTimePickerMediaOceanImportSettings_RunAt_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerMediaOceanImportSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxMediaOceanImportSettings_LocalFolder_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_LocalFolder.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxMediaOceanImportSettings_Employee_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaOceanImportSettings_Employee.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxMediaOceanImportSettings_FTPAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPAddress.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxMediaOceanImportSettings_FTPUser_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPUser.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxMediaOceanImportSettings_FTPPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPPassword.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ButtonMediaOceanImportSettings_ValidateFTP_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportSettings_ValidateFTP.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If RadioButtonMediaOceanImportSetting_ImportTypeDefault.Checked Then

                If Mid(TextBoxMediaOceanImportSettings_FTPAddress.Text, 1, 5).ToUpper = "SFTP:" Then

                    If AdvantageFramework.FTP.ValidateSFTP(Replace(TextBoxMediaOceanImportSettings_FTPAddress.Text.ToUpper, "SFTP://", ""), 22, TextBoxMediaOceanImportSettings_FTPUser.Text, TextBoxMediaOceanImportSettings_FTPPassword.Text) Then

                        AdvantageFramework.WinForm.MessageBox.Show("FTP Validated!")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Could not validate FTP!")

                    End If

                ElseIf Mid(TextBoxMediaOceanImportSettings_FTPAddress.Text, 1, 4).ToUpper = "FTP:" Then

                    If AdvantageFramework.FTP.ValidateFTP(TextBoxMediaOceanImportSettings_FTPAddress.Text, TextBoxMediaOceanImportSettings_FTPUser.Text, TextBoxMediaOceanImportSettings_FTPPassword.Text, False, ErrorMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show("FTP Validated!")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Could not validate FTP!")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("FTP Address must begin with 'sftp:' or 'ftp:'!")

                End If

            ElseIf RadioButtonMediaOceanImportSetting_ImportTypeGLIFace.Checked Then

                If AdvantageFramework.FTP.ValidateFTP(TextBoxMediaOceanImportSettings_FTPAddress.Text, TextBoxMediaOceanImportSettings_FTPUser.Text, TextBoxMediaOceanImportSettings_FTPPassword.Text, False, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show("FTP Validated!")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Could not validate FTP!")

                End If

            End If

        End Sub
        Private Sub RadioButtonMediaOceanImportSetting_ImportTypeDefault_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonMediaOceanImportSetting_ImportTypeDefault.CheckedChangedEx

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub RadioButtonMediaOceanImportSetting_ImportTypeGLIFace_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonMediaOceanImportSetting_ImportTypeGLIFace.CheckedChangedEx

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  CSI Preferred Partner "

        Private Sub TextBoxCSIPreferredPartnerSettings_DownloadFolder_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCSIPreferredPartnerSettings_DownloadFolder.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxCSIPreferredPartnerSettings_UploadFolder_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCSIPreferredPartnerSettings_UploadFolder.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   JobComp UDF Import"

        Private Sub TextBoxJobCompUDFImportSettings_ImportPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxJobCompUDFImportSettings_ImportPath.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub DateTimePickerJobCompUDFImportSettings_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerJobCompUDFImportSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Imports"

        Private Sub DataGridViewImports_AvailableImports_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewImports_AvailableImports.LeavingRowEvent

            If CheckUserEntryChangedSetting(TabItemServices_ImportsTab) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    SaveSettings()

                Else

                    ClearChanged(TabControlForm_Services.SelectedTab)

                    RaiseEvent EnableOrDisableSaveEvent(False)

                End If

            End If

        End Sub
        Private Sub DataGridViewImports_AvailableImports_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewImports_AvailableImports.SelectionChangedEvent

            LoadServiceImportSettings()

        End Sub
        Private Sub PropertyGridControlImports_Properties_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridControlImports_Properties.CellValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub PropertyGridControlImports_Properties_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridControlImports_Properties.QueryPopupNeedDatasource

            If FieldName = AdvantageFramework.Services.Imports.Classes.ImportSetting.Properties.EmployeeCode.ToString Then

                OverrideDefaultDatasource = True

                Datasource = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(_DbContext)
                              Where Employee.Email IsNot Nothing AndAlso
                                    Employee.Email <> ""
                              Select Employee).ToList

            End If

        End Sub
        Private Sub PropertyGridControlImports_Properties_ShowingEditor(sender As Object, e As ComponentModel.CancelEventArgs) Handles PropertyGridControlImports_Properties.ShowingEditor

            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(_DbContext) AndAlso (PropertyGridControlImports_Properties.FocusedRow.Name = "rowOverrideDefaultDirectory" OrElse
                    PropertyGridControlImports_Properties.FocusedRow.Name = "rowOverridePath") Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region "   Exports "

        Private Sub TabControlExports_ExportsSettings_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlExports_ExportsSettings.SelectedTabChanging

            EnableOrDisableServiceActions()

        End Sub
        Private Sub DataGridViewExports_AvailableExports_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewExports_AvailableExports.LeavingRowEvent

            If CheckUserEntryChangedSetting(TabItemServices_ExportsTab) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    SaveSettings()

                Else

                    ClearChanged(TabControlForm_Services.SelectedTab)

                    RaiseEvent EnableOrDisableSaveEvent(False)

                End If

            End If

        End Sub
        Private Sub DataGridViewExports_AvailableExports_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewExports_AvailableExports.SelectionChangedEvent

            LoadServiceExportSettings()

        End Sub
        Private Sub PropertyGridControlExports_Properties_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridControlExports_Properties.CellValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub PropertyGridControlExports_Properties_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PropertyGridControlExports_Properties.ShowingEditor

            If _IsAgencyASP AndAlso PropertyGridControlExports_Properties.FocusedRow.Properties.FieldName = "ExportPath" Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region "   Vendor Contract"

        Private Sub DateTimePickerVendorContractSettings_RunAt_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimePickerVendorContractSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputVendorContractNotifications_DaysPrior_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericInputVendorContractNotifications_DaysPrior.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub CheckBoxVendorContractNotifications_ContractRenewal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxVendorContractNotifications_ContractRenewal.CheckedChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  Currency Exchange "

        Private Sub DateTimePickerCurrencyExchangeSettings_Interval_RunAtTime_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerCurrencyExchangeSettings_Interval_RunAtTime.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  VCC "

        Private Sub ScheduleControlVCCSettings_Schedule_ScheduleChanged() Handles ScheduleControlVCCSettings_Schedule.ScheduleChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  Nielsen "

        Private Sub DateTimePickerNielsenSettings_RunAtDaily_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerNielsenSettings_RunAtDaily.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxNielsenSettings_Employee_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxNielsenSettings_Employee.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Time Sheet"

        Private Sub NumericInputTimeSheetSettings_RunAtEvery_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputTimeSheetSettings_RunAtEvery.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

        Private Sub NumericInput_Timesheet_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInput_Timesheet.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Scheduled Reports"

        Private Sub TextBoxScheduledReportsSettings_OutputFolder_TextChanged(sender As Object, e As EventArgs) Handles TextBoxScheduledReportsSettings_OutputFolder.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  ComScore "

        Private Sub DateTimePickerComScoreSettings_RunAtDaily_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerComScoreSettings_RunAtDaily.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxComScoreSettings_Employee_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxComScoreSettings_Employee.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  In Out Board "

        Private Sub DateTimePickeInOutSettings_RunAtDaily_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerInOutSettings_RunAtDaily.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "   Automated Assignments "

        Private Sub NumericInputAutomatedAssignmentsSettings_RunAtEvery_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputAutomatedAssignmentsSettings_RunAtEvery.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  Document Repository Capacity Warning "

        Private Sub DateTimePickerDocumentRepositoryCapacityWarningSettings_RunAt_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerDocumentRepositoryCapacityWarningSettings_RunAt.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxDocumentRepositoryCapacityWarningSettings_Email_TextChanged(sender As Object, e As EventArgs) Handles TextBoxDocumentRepositoryCapacityWarningSettings_Email.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub NumericInputDocumentRepositoryCapacityWarningSettings_Threshold_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputDocumentRepositoryCapacityWarningSettings_Threshold.EditValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#Region "  Nielsen Puerto Rico "

        Private Sub DateTimePickerNielsenPuertoRicoSettings_RunAtDaily_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerNielsenPuertoRicoSettings_RunAtDaily.ValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub ComboBoxNielsenPuertoRicoSettings_Employee_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxNielsenPuertoRicoSettings_Employee.SelectedValueChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub
        Private Sub TextBoxNielsenPuertoRicoSettings_LocalFolder_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNielsenPuertoRicoSettings_LocalFolder.TextChanged

            If _Initialized Then

                RaiseEvent EnableOrDisableSaveEvent(True)

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
